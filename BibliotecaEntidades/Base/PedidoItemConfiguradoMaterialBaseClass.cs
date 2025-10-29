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
     [Table("pedido_item_configurado_material","pcm")]
     public class PedidoItemConfiguradoMaterialBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PedidoItemConfiguradoMaterialClass";
protected const string ErroDelete = "Erro ao excluir o PedidoItemConfiguradoMaterialClass  ";
protected const string ErroSave = "Erro ao salvar o PedidoItemConfiguradoMaterialClass.";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroUnidadeMedidaObrigatorio = "O campo UnidadeMedida é obrigatório";
protected const string ErroFamiliaMaterialObrigatorio = "O campo FamiliaMaterial é obrigatório";
protected const string ErroAcabamentoObrigatorio = "O campo Acabamento é obrigatório";
protected const string ErroOrderItemEtiquetaObrigatorio = "O campo OrderItemEtiqueta é obrigatório";
protected const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do PedidoItemConfiguradoMaterialClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoItemConfiguradoMaterialClass está sendo utilizada.";
#endregion
       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("pcm_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected double _medidaOriginal{get;private set;}
       private double _medidaOriginalCommited{get; set;}
        private double _valueMedida;
         [Column("pcm_medida")]
        public virtual double Medida
         { 
            get { return this._valueMedida; } 
            set 
            { 
                if (this._valueMedida == value)return;
                 this._valueMedida = value; 
            } 
        } 

       protected double _medidaLarguraOriginal{get;private set;}
       private double _medidaLarguraOriginalCommited{get; set;}
        private double _valueMedidaLargura;
         [Column("pcm_medida_largura")]
        public virtual double MedidaLargura
         { 
            get { return this._valueMedidaLargura; } 
            set 
            { 
                if (this._valueMedidaLargura == value)return;
                 this._valueMedidaLargura = value; 
            } 
        } 

       protected double _medidaComprimentoOriginal{get;private set;}
       private double _medidaComprimentoOriginalCommited{get; set;}
        private double _valueMedidaComprimento;
         [Column("pcm_medida_comprimento")]
        public virtual double MedidaComprimento
         { 
            get { return this._valueMedidaComprimento; } 
            set 
            { 
                if (this._valueMedidaComprimento == value)return;
                 this._valueMedidaComprimento = value; 
            } 
        } 

       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("pcm_codigo")]
        public virtual string Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedida;
        [Column("id_unidade_medida", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedida
        { 
           get {                 return this._valueUnidadeMedida; } 
           set 
           { 
                if (this._valueUnidadeMedida == value)return;
                 this._valueUnidadeMedida = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.FamiliaMaterialClass _familiaMaterialOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FamiliaMaterialClass _familiaMaterialOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FamiliaMaterialClass _valueFamiliaMaterial;
        [Column("id_familia_material", "familia_material", "id_familia_material")]
       public virtual BibliotecaEntidades.Entidades.FamiliaMaterialClass FamiliaMaterial
        { 
           get {                 return this._valueFamiliaMaterial; } 
           set 
           { 
                if (this._valueFamiliaMaterial == value)return;
                 this._valueFamiliaMaterial = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.AcabamentoClass _acabamentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.AcabamentoClass _acabamentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.AcabamentoClass _valueAcabamento;
        [Column("id_acabamento", "acabamento", "id_acabamento")]
       public virtual BibliotecaEntidades.Entidades.AcabamentoClass Acabamento
        { 
           get {                 return this._valueAcabamento; } 
           set 
           { 
                if (this._valueAcabamento == value)return;
                 this._valueAcabamento = value; 
           } 
       } 

       protected string _descricaoAdicionalOriginal{get;private set;}
       private string _descricaoAdicionalOriginalCommited{get; set;}
        private string _valueDescricaoAdicional;
         [Column("pcm_descricao_adicional")]
        public virtual string DescricaoAdicional
         { 
            get { return this._valueDescricaoAdicional; } 
            set 
            { 
                if (this._valueDescricaoAdicional == value)return;
                 this._valueDescricaoAdicional = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _valueOrderItemEtiqueta;
        [Column("id_order_item_etiqueta", "order_item_etiqueta", "id_order_item_etiqueta")]
       public virtual BibliotecaEntidades.Entidades.OrderItemEtiquetaClass OrderItemEtiqueta
        { 
           get {                 return this._valueOrderItemEtiqueta; } 
           set 
           { 
                if (this._valueOrderItemEtiqueta == value)return;
                 this._valueOrderItemEtiqueta = value; 
           } 
       } 

       protected double _quantidadeUnidadePaiOriginal{get;private set;}
       private double _quantidadeUnidadePaiOriginalCommited{get; set;}
        private double _valueQuantidadeUnidadePai;
         [Column("pcm_quantidade_unidade_pai")]
        public virtual double QuantidadeUnidadePai
         { 
            get { return this._valueQuantidadeUnidadePai; } 
            set 
            { 
                if (this._valueQuantidadeUnidadePai == value)return;
                 this._valueQuantidadeUnidadePai = value; 
            } 
        } 

       protected double _quantidadeTotalOriginal{get;private set;}
       private double _quantidadeTotalOriginalCommited{get; set;}
        private double _valueQuantidadeTotal;
         [Column("pcm_quantidade_total")]
        public virtual double QuantidadeTotal
         { 
            get { return this._valueQuantidadeTotal; } 
            set 
            { 
                if (this._valueQuantidadeTotal == value)return;
                 this._valueQuantidadeTotal = value; 
            } 
        } 

       protected bool _planoCorteOriginal{get;private set;}
       private bool _planoCorteOriginalCommited{get; set;}
        private bool _valuePlanoCorte;
         [Column("pcm_plano_corte")]
        public virtual bool PlanoCorte
         { 
            get { return this._valuePlanoCorte; } 
            set 
            { 
                if (this._valuePlanoCorte == value)return;
                 this._valuePlanoCorte = value; 
            } 
        } 

       protected double? _planoCorteQuantidadeOriginal{get;private set;}
       private double? _planoCorteQuantidadeOriginalCommited{get; set;}
        private double? _valuePlanoCorteQuantidade;
         [Column("pcm_plano_corte_quantidade")]
        public virtual double? PlanoCorteQuantidade
         { 
            get { return this._valuePlanoCorteQuantidade; } 
            set 
            { 
                if (this._valuePlanoCorteQuantidade == value)return;
                 this._valuePlanoCorteQuantidade = value; 
            } 
        } 

       protected string _planoCorteDimensao1ValorOriginal{get;private set;}
       private string _planoCorteDimensao1ValorOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao1Valor;
         [Column("pcm_plano_corte_dimensao_1_valor")]
        public virtual string PlanoCorteDimensao1Valor
         { 
            get { return this._valuePlanoCorteDimensao1Valor; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao1Valor == value)return;
                 this._valuePlanoCorteDimensao1Valor = value; 
            } 
        } 

       protected string _planoCorteDimensao1IdentificacaoOriginal{get;private set;}
       private string _planoCorteDimensao1IdentificacaoOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao1Identificacao;
         [Column("pcm_plano_corte_dimensao_1_identificacao")]
        public virtual string PlanoCorteDimensao1Identificacao
         { 
            get { return this._valuePlanoCorteDimensao1Identificacao; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao1Identificacao == value)return;
                 this._valuePlanoCorteDimensao1Identificacao = value; 
            } 
        } 

       protected string _planoCorteDimensao1DescricaoOriginal{get;private set;}
       private string _planoCorteDimensao1DescricaoOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao1Descricao;
         [Column("pcm_plano_corte_dimensao_1_descricao")]
        public virtual string PlanoCorteDimensao1Descricao
         { 
            get { return this._valuePlanoCorteDimensao1Descricao; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao1Descricao == value)return;
                 this._valuePlanoCorteDimensao1Descricao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.DimensaoClass _dimensaoCorte1Original{get;private set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _dimensaoCorte1OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _valueDimensaoCorte1;
        [Column("id_dimensao_corte_1", "dimensao", "id_dimensao")]
       public virtual BibliotecaEntidades.Entidades.DimensaoClass DimensaoCorte1
        { 
           get {                 return this._valueDimensaoCorte1; } 
           set 
           { 
                if (this._valueDimensaoCorte1 == value)return;
                 this._valueDimensaoCorte1 = value; 
           } 
       } 

       protected string _planoCorteDimensao2ValorOriginal{get;private set;}
       private string _planoCorteDimensao2ValorOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao2Valor;
         [Column("pcm_plano_corte_dimensao_2_valor")]
        public virtual string PlanoCorteDimensao2Valor
         { 
            get { return this._valuePlanoCorteDimensao2Valor; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao2Valor == value)return;
                 this._valuePlanoCorteDimensao2Valor = value; 
            } 
        } 

       protected string _planoCorteDimensao2IdentificacaoOriginal{get;private set;}
       private string _planoCorteDimensao2IdentificacaoOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao2Identificacao;
         [Column("pcm_plano_corte_dimensao_2_identificacao")]
        public virtual string PlanoCorteDimensao2Identificacao
         { 
            get { return this._valuePlanoCorteDimensao2Identificacao; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao2Identificacao == value)return;
                 this._valuePlanoCorteDimensao2Identificacao = value; 
            } 
        } 

       protected string _planoCorteDimensao2DescricaoOriginal{get;private set;}
       private string _planoCorteDimensao2DescricaoOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao2Descricao;
         [Column("pcm_plano_corte_dimensao_2_descricao")]
        public virtual string PlanoCorteDimensao2Descricao
         { 
            get { return this._valuePlanoCorteDimensao2Descricao; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao2Descricao == value)return;
                 this._valuePlanoCorteDimensao2Descricao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.DimensaoClass _dimensaoCorte2Original{get;private set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _dimensaoCorte2OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _valueDimensaoCorte2;
        [Column("id_dimensao_corte_2", "dimensao", "id_dimensao")]
       public virtual BibliotecaEntidades.Entidades.DimensaoClass DimensaoCorte2
        { 
           get {                 return this._valueDimensaoCorte2; } 
           set 
           { 
                if (this._valueDimensaoCorte2 == value)return;
                 this._valueDimensaoCorte2 = value; 
           } 
       } 

       protected string _planoCorteDimensao3ValorOriginal{get;private set;}
       private string _planoCorteDimensao3ValorOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao3Valor;
         [Column("pcm_plano_corte_dimensao_3_valor")]
        public virtual string PlanoCorteDimensao3Valor
         { 
            get { return this._valuePlanoCorteDimensao3Valor; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao3Valor == value)return;
                 this._valuePlanoCorteDimensao3Valor = value; 
            } 
        } 

       protected string _planoCorteDimensao3IdentificacaoOriginal{get;private set;}
       private string _planoCorteDimensao3IdentificacaoOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao3Identificacao;
         [Column("pcm_plano_corte_dimensao_3_identificacao")]
        public virtual string PlanoCorteDimensao3Identificacao
         { 
            get { return this._valuePlanoCorteDimensao3Identificacao; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao3Identificacao == value)return;
                 this._valuePlanoCorteDimensao3Identificacao = value; 
            } 
        } 

       protected string _planoCorteDimensao3DescricaoOriginal{get;private set;}
       private string _planoCorteDimensao3DescricaoOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao3Descricao;
         [Column("pcm_plano_corte_dimensao_3_descricao")]
        public virtual string PlanoCorteDimensao3Descricao
         { 
            get { return this._valuePlanoCorteDimensao3Descricao; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao3Descricao == value)return;
                 this._valuePlanoCorteDimensao3Descricao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.DimensaoClass _dimensaoCorte3Original{get;private set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _dimensaoCorte3OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _valueDimensaoCorte3;
        [Column("id_dimensao_corte_3", "dimensao", "id_dimensao")]
       public virtual BibliotecaEntidades.Entidades.DimensaoClass DimensaoCorte3
        { 
           get {                 return this._valueDimensaoCorte3; } 
           set 
           { 
                if (this._valueDimensaoCorte3 == value)return;
                 this._valueDimensaoCorte3 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoCorteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoCorteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _valuePostoTrabalhoCorte;
        [Column("id_posto_trabalho_corte", "posto_trabalho", "id_posto_trabalho")]
       public virtual BibliotecaEntidades.Entidades.PostoTrabalhoClass PostoTrabalhoCorte
        { 
           get {                 return this._valuePostoTrabalhoCorte; } 
           set 
           { 
                if (this._valuePostoTrabalhoCorte == value)return;
                 this._valuePostoTrabalhoCorte = value; 
           } 
       } 

       protected string _postoTrabalhoCorteIdentificacaoOriginal{get;private set;}
       private string _postoTrabalhoCorteIdentificacaoOriginalCommited{get; set;}
        private string _valuePostoTrabalhoCorteIdentificacao;
         [Column("pcm_posto_trabalho_corte_identificacao")]
        public virtual string PostoTrabalhoCorteIdentificacao
         { 
            get { return this._valuePostoTrabalhoCorteIdentificacao; } 
            set 
            { 
                if (this._valuePostoTrabalhoCorteIdentificacao == value)return;
                 this._valuePostoTrabalhoCorteIdentificacao = value; 
            } 
        } 

       protected string _postoTrabalhoCorteDescricaoOriginal{get;private set;}
       private string _postoTrabalhoCorteDescricaoOriginalCommited{get; set;}
        private string _valuePostoTrabalhoCorteDescricao;
         [Column("pcm_posto_trabalho_corte_descricao")]
        public virtual string PostoTrabalhoCorteDescricao
         { 
            get { return this._valuePostoTrabalhoCorteDescricao; } 
            set 
            { 
                if (this._valuePostoTrabalhoCorteDescricao == value)return;
                 this._valuePostoTrabalhoCorteDescricao = value; 
            } 
        } 

       protected string _planoCorteInformacoesAdicionaisOriginal{get;private set;}
       private string _planoCorteInformacoesAdicionaisOriginalCommited{get; set;}
        private string _valuePlanoCorteInformacoesAdicionais;
         [Column("prm_plano_corte_informacoes_adicionais")]
        public virtual string PlanoCorteInformacoesAdicionais
         { 
            get { return this._valuePlanoCorteInformacoesAdicionais; } 
            set 
            { 
                if (this._valuePlanoCorteInformacoesAdicionais == value)return;
                 this._valuePlanoCorteInformacoesAdicionais = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.MaterialClass _materialOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MaterialClass _materialOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MaterialClass _valueMaterial;
        [Column("id_material", "material", "id_material")]
       public virtual BibliotecaEntidades.Entidades.MaterialClass Material
        { 
           get {                 return this._valueMaterial; } 
           set 
           { 
                if (this._valueMaterial == value)return;
                 this._valueMaterial = value; 
           } 
       } 

       protected bool _planoCorteGeradoOriginal{get;private set;}
       private bool _planoCorteGeradoOriginalCommited{get; set;}
        private bool _valuePlanoCorteGerado;
         [Column("pcm_plano_corte_gerado")]
        public virtual bool PlanoCorteGerado
         { 
            get { return this._valuePlanoCorteGerado; } 
            set 
            { 
                if (this._valuePlanoCorteGerado == value)return;
                 this._valuePlanoCorteGerado = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao1Original{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao1OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedidaDimensao1;
        [Column("id_unidade_medida_dimensao_1", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedidaDimensao1
        { 
           get {                 return this._valueUnidadeMedidaDimensao1; } 
           set 
           { 
                if (this._valueUnidadeMedidaDimensao1 == value)return;
                 this._valueUnidadeMedidaDimensao1 = value; 
           } 
       } 

       protected string _planoCorteDimensao1UnidadeMedidaOriginal{get;private set;}
       private string _planoCorteDimensao1UnidadeMedidaOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao1UnidadeMedida;
         [Column("pcm_plano_corte_dimensao_1_unidade_medida")]
        public virtual string PlanoCorteDimensao1UnidadeMedida
         { 
            get { return this._valuePlanoCorteDimensao1UnidadeMedida; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao1UnidadeMedida == value)return;
                 this._valuePlanoCorteDimensao1UnidadeMedida = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao2Original{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao2OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedidaDimensao2;
        [Column("id_unidade_medida_dimensao_2", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedidaDimensao2
        { 
           get {                 return this._valueUnidadeMedidaDimensao2; } 
           set 
           { 
                if (this._valueUnidadeMedidaDimensao2 == value)return;
                 this._valueUnidadeMedidaDimensao2 = value; 
           } 
       } 

       protected string _planoCorteDimensao2UnidadeMedidaOriginal{get;private set;}
       private string _planoCorteDimensao2UnidadeMedidaOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao2UnidadeMedida;
         [Column("pcm_plano_corte_dimensao_2_unidade_medida")]
        public virtual string PlanoCorteDimensao2UnidadeMedida
         { 
            get { return this._valuePlanoCorteDimensao2UnidadeMedida; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao2UnidadeMedida == value)return;
                 this._valuePlanoCorteDimensao2UnidadeMedida = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao3Original{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao3OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedidaDimensao3;
        [Column("id_unidade_medida_dimensao_3", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedidaDimensao3
        { 
           get {                 return this._valueUnidadeMedidaDimensao3; } 
           set 
           { 
                if (this._valueUnidadeMedidaDimensao3 == value)return;
                 this._valueUnidadeMedidaDimensao3 = value; 
           } 
       } 

       protected string _planoCorteDimensao3UnidadeMedidaOriginal{get;private set;}
       private string _planoCorteDimensao3UnidadeMedidaOriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao3UnidadeMedida;
         [Column("pcm_plano_corte_dimensao_3_unidade_medida")]
        public virtual string PlanoCorteDimensao3UnidadeMedida
         { 
            get { return this._valuePlanoCorteDimensao3UnidadeMedida; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao3UnidadeMedida == value)return;
                 this._valuePlanoCorteDimensao3UnidadeMedida = value; 
            } 
        } 

        public PedidoItemConfiguradoMaterialBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.PlanoCorte = false;
           this.PlanoCorteGerado = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static PedidoItemConfiguradoMaterialClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PedidoItemConfiguradoMaterialClass) GetEntity(typeof(PedidoItemConfiguradoMaterialClass),id,usuarioAtual,connection, operacao);
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
                if (string.IsNullOrEmpty(Codigo))
                {
                    throw new Exception(ErroCodigoObrigatorio);
                }
                if (Codigo.Length >255)
                {
                    throw new Exception( ErroCodigoComprimento);
                }
                if ( _valueUnidadeMedida == null)
                {
                    throw new Exception(ErroUnidadeMedidaObrigatorio);
                }
                if ( _valueFamiliaMaterial == null)
                {
                    throw new Exception(ErroFamiliaMaterialObrigatorio);
                }
                if ( _valueAcabamento == null)
                {
                    throw new Exception(ErroAcabamentoObrigatorio);
                }
                if ( _valueOrderItemEtiqueta == null)
                {
                    throw new Exception(ErroOrderItemEtiquetaObrigatorio);
                }
                if ( _valueMaterial == null)
                {
                    throw new Exception(ErroMaterialObrigatorio);
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
                    "  public.pedido_item_configurado_material  " +
                    "WHERE " +
                    "  id_pedido_item_configurado_material = :id";
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
                        "  public.pedido_item_configurado_material   " +
                        "SET  " + 
                        "  pcm_descricao = :pcm_descricao, " + 
                        "  pcm_medida = :pcm_medida, " + 
                        "  pcm_medida_largura = :pcm_medida_largura, " + 
                        "  pcm_medida_comprimento = :pcm_medida_comprimento, " + 
                        "  pcm_codigo = :pcm_codigo, " + 
                        "  id_unidade_medida = :id_unidade_medida, " + 
                        "  id_familia_material = :id_familia_material, " + 
                        "  id_acabamento = :id_acabamento, " + 
                        "  pcm_descricao_adicional = :pcm_descricao_adicional, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_order_item_etiqueta = :id_order_item_etiqueta, " + 
                        "  pcm_quantidade_unidade_pai = :pcm_quantidade_unidade_pai, " + 
                        "  pcm_quantidade_total = :pcm_quantidade_total, " + 
                        "  pcm_plano_corte = :pcm_plano_corte, " + 
                        "  pcm_plano_corte_quantidade = :pcm_plano_corte_quantidade, " + 
                        "  pcm_plano_corte_dimensao_1_valor = :pcm_plano_corte_dimensao_1_valor, " + 
                        "  pcm_plano_corte_dimensao_1_identificacao = :pcm_plano_corte_dimensao_1_identificacao, " + 
                        "  pcm_plano_corte_dimensao_1_descricao = :pcm_plano_corte_dimensao_1_descricao, " + 
                        "  id_dimensao_corte_1 = :id_dimensao_corte_1, " + 
                        "  pcm_plano_corte_dimensao_2_valor = :pcm_plano_corte_dimensao_2_valor, " + 
                        "  pcm_plano_corte_dimensao_2_identificacao = :pcm_plano_corte_dimensao_2_identificacao, " + 
                        "  pcm_plano_corte_dimensao_2_descricao = :pcm_plano_corte_dimensao_2_descricao, " + 
                        "  id_dimensao_corte_2 = :id_dimensao_corte_2, " + 
                        "  pcm_plano_corte_dimensao_3_valor = :pcm_plano_corte_dimensao_3_valor, " + 
                        "  pcm_plano_corte_dimensao_3_identificacao = :pcm_plano_corte_dimensao_3_identificacao, " + 
                        "  pcm_plano_corte_dimensao_3_descricao = :pcm_plano_corte_dimensao_3_descricao, " + 
                        "  id_dimensao_corte_3 = :id_dimensao_corte_3, " + 
                        "  id_posto_trabalho_corte = :id_posto_trabalho_corte, " + 
                        "  pcm_posto_trabalho_corte_identificacao = :pcm_posto_trabalho_corte_identificacao, " + 
                        "  pcm_posto_trabalho_corte_descricao = :pcm_posto_trabalho_corte_descricao, " + 
                        "  prm_plano_corte_informacoes_adicionais = :prm_plano_corte_informacoes_adicionais, " + 
                        "  id_material = :id_material, " + 
                        "  pcm_plano_corte_gerado = :pcm_plano_corte_gerado, " + 
                        "  id_unidade_medida_dimensao_1 = :id_unidade_medida_dimensao_1, " + 
                        "  pcm_plano_corte_dimensao_1_unidade_medida = :pcm_plano_corte_dimensao_1_unidade_medida, " + 
                        "  id_unidade_medida_dimensao_2 = :id_unidade_medida_dimensao_2, " + 
                        "  pcm_plano_corte_dimensao_2_unidade_medida = :pcm_plano_corte_dimensao_2_unidade_medida, " + 
                        "  id_unidade_medida_dimensao_3 = :id_unidade_medida_dimensao_3, " + 
                        "  pcm_plano_corte_dimensao_3_unidade_medida = :pcm_plano_corte_dimensao_3_unidade_medida "+
                        "WHERE  " +
                        "  id_pedido_item_configurado_material = :id " +
                        "RETURNING id_pedido_item_configurado_material;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.pedido_item_configurado_material " +
                        "( " +
                        "  pcm_descricao , " + 
                        "  pcm_medida , " + 
                        "  pcm_medida_largura , " + 
                        "  pcm_medida_comprimento , " + 
                        "  pcm_codigo , " + 
                        "  id_unidade_medida , " + 
                        "  id_familia_material , " + 
                        "  id_acabamento , " + 
                        "  pcm_descricao_adicional , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_order_item_etiqueta , " + 
                        "  pcm_quantidade_unidade_pai , " + 
                        "  pcm_quantidade_total , " + 
                        "  pcm_plano_corte , " + 
                        "  pcm_plano_corte_quantidade , " + 
                        "  pcm_plano_corte_dimensao_1_valor , " + 
                        "  pcm_plano_corte_dimensao_1_identificacao , " + 
                        "  pcm_plano_corte_dimensao_1_descricao , " + 
                        "  id_dimensao_corte_1 , " + 
                        "  pcm_plano_corte_dimensao_2_valor , " + 
                        "  pcm_plano_corte_dimensao_2_identificacao , " + 
                        "  pcm_plano_corte_dimensao_2_descricao , " + 
                        "  id_dimensao_corte_2 , " + 
                        "  pcm_plano_corte_dimensao_3_valor , " + 
                        "  pcm_plano_corte_dimensao_3_identificacao , " + 
                        "  pcm_plano_corte_dimensao_3_descricao , " + 
                        "  id_dimensao_corte_3 , " + 
                        "  id_posto_trabalho_corte , " + 
                        "  pcm_posto_trabalho_corte_identificacao , " + 
                        "  pcm_posto_trabalho_corte_descricao , " + 
                        "  prm_plano_corte_informacoes_adicionais , " + 
                        "  id_material , " + 
                        "  pcm_plano_corte_gerado , " + 
                        "  id_unidade_medida_dimensao_1 , " + 
                        "  pcm_plano_corte_dimensao_1_unidade_medida , " + 
                        "  id_unidade_medida_dimensao_2 , " + 
                        "  pcm_plano_corte_dimensao_2_unidade_medida , " + 
                        "  id_unidade_medida_dimensao_3 , " + 
                        "  pcm_plano_corte_dimensao_3_unidade_medida  "+
                        ")  " +
                        "VALUES ( " +
                        "  :pcm_descricao , " + 
                        "  :pcm_medida , " + 
                        "  :pcm_medida_largura , " + 
                        "  :pcm_medida_comprimento , " + 
                        "  :pcm_codigo , " + 
                        "  :id_unidade_medida , " + 
                        "  :id_familia_material , " + 
                        "  :id_acabamento , " + 
                        "  :pcm_descricao_adicional , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_order_item_etiqueta , " + 
                        "  :pcm_quantidade_unidade_pai , " + 
                        "  :pcm_quantidade_total , " + 
                        "  :pcm_plano_corte , " + 
                        "  :pcm_plano_corte_quantidade , " + 
                        "  :pcm_plano_corte_dimensao_1_valor , " + 
                        "  :pcm_plano_corte_dimensao_1_identificacao , " + 
                        "  :pcm_plano_corte_dimensao_1_descricao , " + 
                        "  :id_dimensao_corte_1 , " + 
                        "  :pcm_plano_corte_dimensao_2_valor , " + 
                        "  :pcm_plano_corte_dimensao_2_identificacao , " + 
                        "  :pcm_plano_corte_dimensao_2_descricao , " + 
                        "  :id_dimensao_corte_2 , " + 
                        "  :pcm_plano_corte_dimensao_3_valor , " + 
                        "  :pcm_plano_corte_dimensao_3_identificacao , " + 
                        "  :pcm_plano_corte_dimensao_3_descricao , " + 
                        "  :id_dimensao_corte_3 , " + 
                        "  :id_posto_trabalho_corte , " + 
                        "  :pcm_posto_trabalho_corte_identificacao , " + 
                        "  :pcm_posto_trabalho_corte_descricao , " + 
                        "  :prm_plano_corte_informacoes_adicionais , " + 
                        "  :id_material , " + 
                        "  :pcm_plano_corte_gerado , " + 
                        "  :id_unidade_medida_dimensao_1 , " + 
                        "  :pcm_plano_corte_dimensao_1_unidade_medida , " + 
                        "  :id_unidade_medida_dimensao_2 , " + 
                        "  :pcm_plano_corte_dimensao_2_unidade_medida , " + 
                        "  :id_unidade_medida_dimensao_3 , " + 
                        "  :pcm_plano_corte_dimensao_3_unidade_medida  "+
                        ")RETURNING id_pedido_item_configurado_material;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_medida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Medida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_medida_largura", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MedidaLargura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_medida_comprimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MedidaComprimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedida==null ? (object) DBNull.Value : this.UnidadeMedida.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_familia_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FamiliaMaterial==null ? (object) DBNull.Value : this.FamiliaMaterial.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acabamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Acabamento==null ? (object) DBNull.Value : this.Acabamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_descricao_adicional", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoAdicional ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiqueta==null ? (object) DBNull.Value : this.OrderItemEtiqueta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_quantidade_unidade_pai", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeUnidadePai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_quantidade_total", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorte ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteQuantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_1_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao1Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_1_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao1Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_1_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao1Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_dimensao_corte_1", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DimensaoCorte1==null ? (object) DBNull.Value : this.DimensaoCorte1.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_2_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao2Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_2_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao2Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_2_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao2Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_dimensao_corte_2", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DimensaoCorte2==null ? (object) DBNull.Value : this.DimensaoCorte2.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_3_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao3Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_3_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao3Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_3_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao3Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_dimensao_corte_3", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DimensaoCorte3==null ? (object) DBNull.Value : this.DimensaoCorte3.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho_corte", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PostoTrabalhoCorte==null ? (object) DBNull.Value : this.PostoTrabalhoCorte.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_posto_trabalho_corte_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PostoTrabalhoCorteIdentificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_posto_trabalho_corte_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PostoTrabalhoCorteDescricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_plano_corte_informacoes_adicionais", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteInformacoesAdicionais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_gerado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteGerado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_dimensao_1", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaDimensao1==null ? (object) DBNull.Value : this.UnidadeMedidaDimensao1.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_1_unidade_medida", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao1UnidadeMedida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_dimensao_2", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaDimensao2==null ? (object) DBNull.Value : this.UnidadeMedidaDimensao2.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_2_unidade_medida", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao2UnidadeMedida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_dimensao_3", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaDimensao3==null ? (object) DBNull.Value : this.UnidadeMedidaDimensao3.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcm_plano_corte_dimensao_3_unidade_medida", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao3UnidadeMedida ?? DBNull.Value;

 
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
        public static PedidoItemConfiguradoMaterialClass CopiarEntidade(PedidoItemConfiguradoMaterialClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PedidoItemConfiguradoMaterialClass toRet = new PedidoItemConfiguradoMaterialClass(usuario,conn);
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Medida= entidadeCopiar.Medida;
 toRet.MedidaLargura= entidadeCopiar.MedidaLargura;
 toRet.MedidaComprimento= entidadeCopiar.MedidaComprimento;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.UnidadeMedida= entidadeCopiar.UnidadeMedida;
 toRet.FamiliaMaterial= entidadeCopiar.FamiliaMaterial;
 toRet.Acabamento= entidadeCopiar.Acabamento;
 toRet.DescricaoAdicional= entidadeCopiar.DescricaoAdicional;
 toRet.OrderItemEtiqueta= entidadeCopiar.OrderItemEtiqueta;
 toRet.QuantidadeUnidadePai= entidadeCopiar.QuantidadeUnidadePai;
 toRet.QuantidadeTotal= entidadeCopiar.QuantidadeTotal;
 toRet.PlanoCorte= entidadeCopiar.PlanoCorte;
 toRet.PlanoCorteQuantidade= entidadeCopiar.PlanoCorteQuantidade;
 toRet.PlanoCorteDimensao1Valor= entidadeCopiar.PlanoCorteDimensao1Valor;
 toRet.PlanoCorteDimensao1Identificacao= entidadeCopiar.PlanoCorteDimensao1Identificacao;
 toRet.PlanoCorteDimensao1Descricao= entidadeCopiar.PlanoCorteDimensao1Descricao;
 toRet.DimensaoCorte1= entidadeCopiar.DimensaoCorte1;
 toRet.PlanoCorteDimensao2Valor= entidadeCopiar.PlanoCorteDimensao2Valor;
 toRet.PlanoCorteDimensao2Identificacao= entidadeCopiar.PlanoCorteDimensao2Identificacao;
 toRet.PlanoCorteDimensao2Descricao= entidadeCopiar.PlanoCorteDimensao2Descricao;
 toRet.DimensaoCorte2= entidadeCopiar.DimensaoCorte2;
 toRet.PlanoCorteDimensao3Valor= entidadeCopiar.PlanoCorteDimensao3Valor;
 toRet.PlanoCorteDimensao3Identificacao= entidadeCopiar.PlanoCorteDimensao3Identificacao;
 toRet.PlanoCorteDimensao3Descricao= entidadeCopiar.PlanoCorteDimensao3Descricao;
 toRet.DimensaoCorte3= entidadeCopiar.DimensaoCorte3;
 toRet.PostoTrabalhoCorte= entidadeCopiar.PostoTrabalhoCorte;
 toRet.PostoTrabalhoCorteIdentificacao= entidadeCopiar.PostoTrabalhoCorteIdentificacao;
 toRet.PostoTrabalhoCorteDescricao= entidadeCopiar.PostoTrabalhoCorteDescricao;
 toRet.PlanoCorteInformacoesAdicionais= entidadeCopiar.PlanoCorteInformacoesAdicionais;
 toRet.Material= entidadeCopiar.Material;
 toRet.PlanoCorteGerado= entidadeCopiar.PlanoCorteGerado;
 toRet.UnidadeMedidaDimensao1= entidadeCopiar.UnidadeMedidaDimensao1;
 toRet.PlanoCorteDimensao1UnidadeMedida= entidadeCopiar.PlanoCorteDimensao1UnidadeMedida;
 toRet.UnidadeMedidaDimensao2= entidadeCopiar.UnidadeMedidaDimensao2;
 toRet.PlanoCorteDimensao2UnidadeMedida= entidadeCopiar.PlanoCorteDimensao2UnidadeMedida;
 toRet.UnidadeMedidaDimensao3= entidadeCopiar.UnidadeMedidaDimensao3;
 toRet.PlanoCorteDimensao3UnidadeMedida= entidadeCopiar.PlanoCorteDimensao3UnidadeMedida;

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
       _medidaOriginal = Medida;
       _medidaOriginalCommited = _medidaOriginal;
       _medidaLarguraOriginal = MedidaLargura;
       _medidaLarguraOriginalCommited = _medidaLarguraOriginal;
       _medidaComprimentoOriginal = MedidaComprimento;
       _medidaComprimentoOriginalCommited = _medidaComprimentoOriginal;
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _unidadeMedidaOriginal = UnidadeMedida;
       _unidadeMedidaOriginalCommited = _unidadeMedidaOriginal;
       _familiaMaterialOriginal = FamiliaMaterial;
       _familiaMaterialOriginalCommited = _familiaMaterialOriginal;
       _acabamentoOriginal = Acabamento;
       _acabamentoOriginalCommited = _acabamentoOriginal;
       _descricaoAdicionalOriginal = DescricaoAdicional;
       _descricaoAdicionalOriginalCommited = _descricaoAdicionalOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _orderItemEtiquetaOriginal = OrderItemEtiqueta;
       _orderItemEtiquetaOriginalCommited = _orderItemEtiquetaOriginal;
       _quantidadeUnidadePaiOriginal = QuantidadeUnidadePai;
       _quantidadeUnidadePaiOriginalCommited = _quantidadeUnidadePaiOriginal;
       _quantidadeTotalOriginal = QuantidadeTotal;
       _quantidadeTotalOriginalCommited = _quantidadeTotalOriginal;
       _planoCorteOriginal = PlanoCorte;
       _planoCorteOriginalCommited = _planoCorteOriginal;
       _planoCorteQuantidadeOriginal = PlanoCorteQuantidade;
       _planoCorteQuantidadeOriginalCommited = _planoCorteQuantidadeOriginal;
       _planoCorteDimensao1ValorOriginal = PlanoCorteDimensao1Valor;
       _planoCorteDimensao1ValorOriginalCommited = _planoCorteDimensao1ValorOriginal;
       _planoCorteDimensao1IdentificacaoOriginal = PlanoCorteDimensao1Identificacao;
       _planoCorteDimensao1IdentificacaoOriginalCommited = _planoCorteDimensao1IdentificacaoOriginal;
       _planoCorteDimensao1DescricaoOriginal = PlanoCorteDimensao1Descricao;
       _planoCorteDimensao1DescricaoOriginalCommited = _planoCorteDimensao1DescricaoOriginal;
       _dimensaoCorte1Original = DimensaoCorte1;
       _dimensaoCorte1OriginalCommited = _dimensaoCorte1Original;
       _planoCorteDimensao2ValorOriginal = PlanoCorteDimensao2Valor;
       _planoCorteDimensao2ValorOriginalCommited = _planoCorteDimensao2ValorOriginal;
       _planoCorteDimensao2IdentificacaoOriginal = PlanoCorteDimensao2Identificacao;
       _planoCorteDimensao2IdentificacaoOriginalCommited = _planoCorteDimensao2IdentificacaoOriginal;
       _planoCorteDimensao2DescricaoOriginal = PlanoCorteDimensao2Descricao;
       _planoCorteDimensao2DescricaoOriginalCommited = _planoCorteDimensao2DescricaoOriginal;
       _dimensaoCorte2Original = DimensaoCorte2;
       _dimensaoCorte2OriginalCommited = _dimensaoCorte2Original;
       _planoCorteDimensao3ValorOriginal = PlanoCorteDimensao3Valor;
       _planoCorteDimensao3ValorOriginalCommited = _planoCorteDimensao3ValorOriginal;
       _planoCorteDimensao3IdentificacaoOriginal = PlanoCorteDimensao3Identificacao;
       _planoCorteDimensao3IdentificacaoOriginalCommited = _planoCorteDimensao3IdentificacaoOriginal;
       _planoCorteDimensao3DescricaoOriginal = PlanoCorteDimensao3Descricao;
       _planoCorteDimensao3DescricaoOriginalCommited = _planoCorteDimensao3DescricaoOriginal;
       _dimensaoCorte3Original = DimensaoCorte3;
       _dimensaoCorte3OriginalCommited = _dimensaoCorte3Original;
       _postoTrabalhoCorteOriginal = PostoTrabalhoCorte;
       _postoTrabalhoCorteOriginalCommited = _postoTrabalhoCorteOriginal;
       _postoTrabalhoCorteIdentificacaoOriginal = PostoTrabalhoCorteIdentificacao;
       _postoTrabalhoCorteIdentificacaoOriginalCommited = _postoTrabalhoCorteIdentificacaoOriginal;
       _postoTrabalhoCorteDescricaoOriginal = PostoTrabalhoCorteDescricao;
       _postoTrabalhoCorteDescricaoOriginalCommited = _postoTrabalhoCorteDescricaoOriginal;
       _planoCorteInformacoesAdicionaisOriginal = PlanoCorteInformacoesAdicionais;
       _planoCorteInformacoesAdicionaisOriginalCommited = _planoCorteInformacoesAdicionaisOriginal;
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _planoCorteGeradoOriginal = PlanoCorteGerado;
       _planoCorteGeradoOriginalCommited = _planoCorteGeradoOriginal;
       _unidadeMedidaDimensao1Original = UnidadeMedidaDimensao1;
       _unidadeMedidaDimensao1OriginalCommited = _unidadeMedidaDimensao1Original;
       _planoCorteDimensao1UnidadeMedidaOriginal = PlanoCorteDimensao1UnidadeMedida;
       _planoCorteDimensao1UnidadeMedidaOriginalCommited = _planoCorteDimensao1UnidadeMedidaOriginal;
       _unidadeMedidaDimensao2Original = UnidadeMedidaDimensao2;
       _unidadeMedidaDimensao2OriginalCommited = _unidadeMedidaDimensao2Original;
       _planoCorteDimensao2UnidadeMedidaOriginal = PlanoCorteDimensao2UnidadeMedida;
       _planoCorteDimensao2UnidadeMedidaOriginalCommited = _planoCorteDimensao2UnidadeMedidaOriginal;
       _unidadeMedidaDimensao3Original = UnidadeMedidaDimensao3;
       _unidadeMedidaDimensao3OriginalCommited = _unidadeMedidaDimensao3Original;
       _planoCorteDimensao3UnidadeMedidaOriginal = PlanoCorteDimensao3UnidadeMedida;
       _planoCorteDimensao3UnidadeMedidaOriginalCommited = _planoCorteDimensao3UnidadeMedidaOriginal;

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
       _medidaOriginalCommited = Medida;
       _medidaLarguraOriginalCommited = MedidaLargura;
       _medidaComprimentoOriginalCommited = MedidaComprimento;
       _codigoOriginalCommited = Codigo;
       _unidadeMedidaOriginalCommited = UnidadeMedida;
       _familiaMaterialOriginalCommited = FamiliaMaterial;
       _acabamentoOriginalCommited = Acabamento;
       _descricaoAdicionalOriginalCommited = DescricaoAdicional;
       _versionOriginalCommited = Version;
       _orderItemEtiquetaOriginalCommited = OrderItemEtiqueta;
       _quantidadeUnidadePaiOriginalCommited = QuantidadeUnidadePai;
       _quantidadeTotalOriginalCommited = QuantidadeTotal;
       _planoCorteOriginalCommited = PlanoCorte;
       _planoCorteQuantidadeOriginalCommited = PlanoCorteQuantidade;
       _planoCorteDimensao1ValorOriginalCommited = PlanoCorteDimensao1Valor;
       _planoCorteDimensao1IdentificacaoOriginalCommited = PlanoCorteDimensao1Identificacao;
       _planoCorteDimensao1DescricaoOriginalCommited = PlanoCorteDimensao1Descricao;
       _dimensaoCorte1OriginalCommited = DimensaoCorte1;
       _planoCorteDimensao2ValorOriginalCommited = PlanoCorteDimensao2Valor;
       _planoCorteDimensao2IdentificacaoOriginalCommited = PlanoCorteDimensao2Identificacao;
       _planoCorteDimensao2DescricaoOriginalCommited = PlanoCorteDimensao2Descricao;
       _dimensaoCorte2OriginalCommited = DimensaoCorte2;
       _planoCorteDimensao3ValorOriginalCommited = PlanoCorteDimensao3Valor;
       _planoCorteDimensao3IdentificacaoOriginalCommited = PlanoCorteDimensao3Identificacao;
       _planoCorteDimensao3DescricaoOriginalCommited = PlanoCorteDimensao3Descricao;
       _dimensaoCorte3OriginalCommited = DimensaoCorte3;
       _postoTrabalhoCorteOriginalCommited = PostoTrabalhoCorte;
       _postoTrabalhoCorteIdentificacaoOriginalCommited = PostoTrabalhoCorteIdentificacao;
       _postoTrabalhoCorteDescricaoOriginalCommited = PostoTrabalhoCorteDescricao;
       _planoCorteInformacoesAdicionaisOriginalCommited = PlanoCorteInformacoesAdicionais;
       _materialOriginalCommited = Material;
       _planoCorteGeradoOriginalCommited = PlanoCorteGerado;
       _unidadeMedidaDimensao1OriginalCommited = UnidadeMedidaDimensao1;
       _planoCorteDimensao1UnidadeMedidaOriginalCommited = PlanoCorteDimensao1UnidadeMedida;
       _unidadeMedidaDimensao2OriginalCommited = UnidadeMedidaDimensao2;
       _planoCorteDimensao2UnidadeMedidaOriginalCommited = PlanoCorteDimensao2UnidadeMedida;
       _unidadeMedidaDimensao3OriginalCommited = UnidadeMedidaDimensao3;
       _planoCorteDimensao3UnidadeMedidaOriginalCommited = PlanoCorteDimensao3UnidadeMedida;

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
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Medida=_medidaOriginal;
               _medidaOriginalCommited=_medidaOriginal;
               MedidaLargura=_medidaLarguraOriginal;
               _medidaLarguraOriginalCommited=_medidaLarguraOriginal;
               MedidaComprimento=_medidaComprimentoOriginal;
               _medidaComprimentoOriginalCommited=_medidaComprimentoOriginal;
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               UnidadeMedida=_unidadeMedidaOriginal;
               _unidadeMedidaOriginalCommited=_unidadeMedidaOriginal;
               FamiliaMaterial=_familiaMaterialOriginal;
               _familiaMaterialOriginalCommited=_familiaMaterialOriginal;
               Acabamento=_acabamentoOriginal;
               _acabamentoOriginalCommited=_acabamentoOriginal;
               DescricaoAdicional=_descricaoAdicionalOriginal;
               _descricaoAdicionalOriginalCommited=_descricaoAdicionalOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               OrderItemEtiqueta=_orderItemEtiquetaOriginal;
               _orderItemEtiquetaOriginalCommited=_orderItemEtiquetaOriginal;
               QuantidadeUnidadePai=_quantidadeUnidadePaiOriginal;
               _quantidadeUnidadePaiOriginalCommited=_quantidadeUnidadePaiOriginal;
               QuantidadeTotal=_quantidadeTotalOriginal;
               _quantidadeTotalOriginalCommited=_quantidadeTotalOriginal;
               PlanoCorte=_planoCorteOriginal;
               _planoCorteOriginalCommited=_planoCorteOriginal;
               PlanoCorteQuantidade=_planoCorteQuantidadeOriginal;
               _planoCorteQuantidadeOriginalCommited=_planoCorteQuantidadeOriginal;
               PlanoCorteDimensao1Valor=_planoCorteDimensao1ValorOriginal;
               _planoCorteDimensao1ValorOriginalCommited=_planoCorteDimensao1ValorOriginal;
               PlanoCorteDimensao1Identificacao=_planoCorteDimensao1IdentificacaoOriginal;
               _planoCorteDimensao1IdentificacaoOriginalCommited=_planoCorteDimensao1IdentificacaoOriginal;
               PlanoCorteDimensao1Descricao=_planoCorteDimensao1DescricaoOriginal;
               _planoCorteDimensao1DescricaoOriginalCommited=_planoCorteDimensao1DescricaoOriginal;
               DimensaoCorte1=_dimensaoCorte1Original;
               _dimensaoCorte1OriginalCommited=_dimensaoCorte1Original;
               PlanoCorteDimensao2Valor=_planoCorteDimensao2ValorOriginal;
               _planoCorteDimensao2ValorOriginalCommited=_planoCorteDimensao2ValorOriginal;
               PlanoCorteDimensao2Identificacao=_planoCorteDimensao2IdentificacaoOriginal;
               _planoCorteDimensao2IdentificacaoOriginalCommited=_planoCorteDimensao2IdentificacaoOriginal;
               PlanoCorteDimensao2Descricao=_planoCorteDimensao2DescricaoOriginal;
               _planoCorteDimensao2DescricaoOriginalCommited=_planoCorteDimensao2DescricaoOriginal;
               DimensaoCorte2=_dimensaoCorte2Original;
               _dimensaoCorte2OriginalCommited=_dimensaoCorte2Original;
               PlanoCorteDimensao3Valor=_planoCorteDimensao3ValorOriginal;
               _planoCorteDimensao3ValorOriginalCommited=_planoCorteDimensao3ValorOriginal;
               PlanoCorteDimensao3Identificacao=_planoCorteDimensao3IdentificacaoOriginal;
               _planoCorteDimensao3IdentificacaoOriginalCommited=_planoCorteDimensao3IdentificacaoOriginal;
               PlanoCorteDimensao3Descricao=_planoCorteDimensao3DescricaoOriginal;
               _planoCorteDimensao3DescricaoOriginalCommited=_planoCorteDimensao3DescricaoOriginal;
               DimensaoCorte3=_dimensaoCorte3Original;
               _dimensaoCorte3OriginalCommited=_dimensaoCorte3Original;
               PostoTrabalhoCorte=_postoTrabalhoCorteOriginal;
               _postoTrabalhoCorteOriginalCommited=_postoTrabalhoCorteOriginal;
               PostoTrabalhoCorteIdentificacao=_postoTrabalhoCorteIdentificacaoOriginal;
               _postoTrabalhoCorteIdentificacaoOriginalCommited=_postoTrabalhoCorteIdentificacaoOriginal;
               PostoTrabalhoCorteDescricao=_postoTrabalhoCorteDescricaoOriginal;
               _postoTrabalhoCorteDescricaoOriginalCommited=_postoTrabalhoCorteDescricaoOriginal;
               PlanoCorteInformacoesAdicionais=_planoCorteInformacoesAdicionaisOriginal;
               _planoCorteInformacoesAdicionaisOriginalCommited=_planoCorteInformacoesAdicionaisOriginal;
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               PlanoCorteGerado=_planoCorteGeradoOriginal;
               _planoCorteGeradoOriginalCommited=_planoCorteGeradoOriginal;
               UnidadeMedidaDimensao1=_unidadeMedidaDimensao1Original;
               _unidadeMedidaDimensao1OriginalCommited=_unidadeMedidaDimensao1Original;
               PlanoCorteDimensao1UnidadeMedida=_planoCorteDimensao1UnidadeMedidaOriginal;
               _planoCorteDimensao1UnidadeMedidaOriginalCommited=_planoCorteDimensao1UnidadeMedidaOriginal;
               UnidadeMedidaDimensao2=_unidadeMedidaDimensao2Original;
               _unidadeMedidaDimensao2OriginalCommited=_unidadeMedidaDimensao2Original;
               PlanoCorteDimensao2UnidadeMedida=_planoCorteDimensao2UnidadeMedidaOriginal;
               _planoCorteDimensao2UnidadeMedidaOriginalCommited=_planoCorteDimensao2UnidadeMedidaOriginal;
               UnidadeMedidaDimensao3=_unidadeMedidaDimensao3Original;
               _unidadeMedidaDimensao3OriginalCommited=_unidadeMedidaDimensao3Original;
               PlanoCorteDimensao3UnidadeMedida=_planoCorteDimensao3UnidadeMedidaOriginal;
               _planoCorteDimensao3UnidadeMedidaOriginalCommited=_planoCorteDimensao3UnidadeMedidaOriginal;

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
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _medidaOriginal != Medida;
      if (dirty) return true;
       dirty = _medidaLarguraOriginal != MedidaLargura;
      if (dirty) return true;
       dirty = _medidaComprimentoOriginal != MedidaComprimento;
      if (dirty) return true;
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       if (_unidadeMedidaOriginal!=null)
       {
          dirty = !_unidadeMedidaOriginal.Equals(UnidadeMedida);
       }
       else
       {
            dirty = UnidadeMedida != null;
       }
      if (dirty) return true;
       if (_familiaMaterialOriginal!=null)
       {
          dirty = !_familiaMaterialOriginal.Equals(FamiliaMaterial);
       }
       else
       {
            dirty = FamiliaMaterial != null;
       }
      if (dirty) return true;
       if (_acabamentoOriginal!=null)
       {
          dirty = !_acabamentoOriginal.Equals(Acabamento);
       }
       else
       {
            dirty = Acabamento != null;
       }
      if (dirty) return true;
       dirty = _descricaoAdicionalOriginal != DescricaoAdicional;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_orderItemEtiquetaOriginal!=null)
       {
          dirty = !_orderItemEtiquetaOriginal.Equals(OrderItemEtiqueta);
       }
       else
       {
            dirty = OrderItemEtiqueta != null;
       }
      if (dirty) return true;
       dirty = _quantidadeUnidadePaiOriginal != QuantidadeUnidadePai;
      if (dirty) return true;
       dirty = _quantidadeTotalOriginal != QuantidadeTotal;
      if (dirty) return true;
       dirty = _planoCorteOriginal != PlanoCorte;
      if (dirty) return true;
       dirty = _planoCorteQuantidadeOriginal != PlanoCorteQuantidade;
      if (dirty) return true;
       dirty = _planoCorteDimensao1ValorOriginal != PlanoCorteDimensao1Valor;
      if (dirty) return true;
       dirty = _planoCorteDimensao1IdentificacaoOriginal != PlanoCorteDimensao1Identificacao;
      if (dirty) return true;
       dirty = _planoCorteDimensao1DescricaoOriginal != PlanoCorteDimensao1Descricao;
      if (dirty) return true;
       if (_dimensaoCorte1Original!=null)
       {
          dirty = !_dimensaoCorte1Original.Equals(DimensaoCorte1);
       }
       else
       {
            dirty = DimensaoCorte1 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao2ValorOriginal != PlanoCorteDimensao2Valor;
      if (dirty) return true;
       dirty = _planoCorteDimensao2IdentificacaoOriginal != PlanoCorteDimensao2Identificacao;
      if (dirty) return true;
       dirty = _planoCorteDimensao2DescricaoOriginal != PlanoCorteDimensao2Descricao;
      if (dirty) return true;
       if (_dimensaoCorte2Original!=null)
       {
          dirty = !_dimensaoCorte2Original.Equals(DimensaoCorte2);
       }
       else
       {
            dirty = DimensaoCorte2 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao3ValorOriginal != PlanoCorteDimensao3Valor;
      if (dirty) return true;
       dirty = _planoCorteDimensao3IdentificacaoOriginal != PlanoCorteDimensao3Identificacao;
      if (dirty) return true;
       dirty = _planoCorteDimensao3DescricaoOriginal != PlanoCorteDimensao3Descricao;
      if (dirty) return true;
       if (_dimensaoCorte3Original!=null)
       {
          dirty = !_dimensaoCorte3Original.Equals(DimensaoCorte3);
       }
       else
       {
            dirty = DimensaoCorte3 != null;
       }
      if (dirty) return true;
       if (_postoTrabalhoCorteOriginal!=null)
       {
          dirty = !_postoTrabalhoCorteOriginal.Equals(PostoTrabalhoCorte);
       }
       else
       {
            dirty = PostoTrabalhoCorte != null;
       }
      if (dirty) return true;
       dirty = _postoTrabalhoCorteIdentificacaoOriginal != PostoTrabalhoCorteIdentificacao;
      if (dirty) return true;
       dirty = _postoTrabalhoCorteDescricaoOriginal != PostoTrabalhoCorteDescricao;
      if (dirty) return true;
       dirty = _planoCorteInformacoesAdicionaisOriginal != PlanoCorteInformacoesAdicionais;
      if (dirty) return true;
       if (_materialOriginal!=null)
       {
          dirty = !_materialOriginal.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
      if (dirty) return true;
       dirty = _planoCorteGeradoOriginal != PlanoCorteGerado;
      if (dirty) return true;
       if (_unidadeMedidaDimensao1Original!=null)
       {
          dirty = !_unidadeMedidaDimensao1Original.Equals(UnidadeMedidaDimensao1);
       }
       else
       {
            dirty = UnidadeMedidaDimensao1 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao1UnidadeMedidaOriginal != PlanoCorteDimensao1UnidadeMedida;
      if (dirty) return true;
       if (_unidadeMedidaDimensao2Original!=null)
       {
          dirty = !_unidadeMedidaDimensao2Original.Equals(UnidadeMedidaDimensao2);
       }
       else
       {
            dirty = UnidadeMedidaDimensao2 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao2UnidadeMedidaOriginal != PlanoCorteDimensao2UnidadeMedida;
      if (dirty) return true;
       if (_unidadeMedidaDimensao3Original!=null)
       {
          dirty = !_unidadeMedidaDimensao3Original.Equals(UnidadeMedidaDimensao3);
       }
       else
       {
            dirty = UnidadeMedidaDimensao3 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao3UnidadeMedidaOriginal != PlanoCorteDimensao3UnidadeMedida;

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
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _medidaOriginalCommited != Medida;
      if (dirty) return true;
       dirty = _medidaLarguraOriginalCommited != MedidaLargura;
      if (dirty) return true;
       dirty = _medidaComprimentoOriginalCommited != MedidaComprimento;
      if (dirty) return true;
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       if (_unidadeMedidaOriginalCommited!=null)
       {
          dirty = !_unidadeMedidaOriginalCommited.Equals(UnidadeMedida);
       }
       else
       {
            dirty = UnidadeMedida != null;
       }
      if (dirty) return true;
       if (_familiaMaterialOriginalCommited!=null)
       {
          dirty = !_familiaMaterialOriginalCommited.Equals(FamiliaMaterial);
       }
       else
       {
            dirty = FamiliaMaterial != null;
       }
      if (dirty) return true;
       if (_acabamentoOriginalCommited!=null)
       {
          dirty = !_acabamentoOriginalCommited.Equals(Acabamento);
       }
       else
       {
            dirty = Acabamento != null;
       }
      if (dirty) return true;
       dirty = _descricaoAdicionalOriginalCommited != DescricaoAdicional;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_orderItemEtiquetaOriginalCommited!=null)
       {
          dirty = !_orderItemEtiquetaOriginalCommited.Equals(OrderItemEtiqueta);
       }
       else
       {
            dirty = OrderItemEtiqueta != null;
       }
      if (dirty) return true;
       dirty = _quantidadeUnidadePaiOriginalCommited != QuantidadeUnidadePai;
      if (dirty) return true;
       dirty = _quantidadeTotalOriginalCommited != QuantidadeTotal;
      if (dirty) return true;
       dirty = _planoCorteOriginalCommited != PlanoCorte;
      if (dirty) return true;
       dirty = _planoCorteQuantidadeOriginalCommited != PlanoCorteQuantidade;
      if (dirty) return true;
       dirty = _planoCorteDimensao1ValorOriginalCommited != PlanoCorteDimensao1Valor;
      if (dirty) return true;
       dirty = _planoCorteDimensao1IdentificacaoOriginalCommited != PlanoCorteDimensao1Identificacao;
      if (dirty) return true;
       dirty = _planoCorteDimensao1DescricaoOriginalCommited != PlanoCorteDimensao1Descricao;
      if (dirty) return true;
       if (_dimensaoCorte1OriginalCommited!=null)
       {
          dirty = !_dimensaoCorte1OriginalCommited.Equals(DimensaoCorte1);
       }
       else
       {
            dirty = DimensaoCorte1 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao2ValorOriginalCommited != PlanoCorteDimensao2Valor;
      if (dirty) return true;
       dirty = _planoCorteDimensao2IdentificacaoOriginalCommited != PlanoCorteDimensao2Identificacao;
      if (dirty) return true;
       dirty = _planoCorteDimensao2DescricaoOriginalCommited != PlanoCorteDimensao2Descricao;
      if (dirty) return true;
       if (_dimensaoCorte2OriginalCommited!=null)
       {
          dirty = !_dimensaoCorte2OriginalCommited.Equals(DimensaoCorte2);
       }
       else
       {
            dirty = DimensaoCorte2 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao3ValorOriginalCommited != PlanoCorteDimensao3Valor;
      if (dirty) return true;
       dirty = _planoCorteDimensao3IdentificacaoOriginalCommited != PlanoCorteDimensao3Identificacao;
      if (dirty) return true;
       dirty = _planoCorteDimensao3DescricaoOriginalCommited != PlanoCorteDimensao3Descricao;
      if (dirty) return true;
       if (_dimensaoCorte3OriginalCommited!=null)
       {
          dirty = !_dimensaoCorte3OriginalCommited.Equals(DimensaoCorte3);
       }
       else
       {
            dirty = DimensaoCorte3 != null;
       }
      if (dirty) return true;
       if (_postoTrabalhoCorteOriginalCommited!=null)
       {
          dirty = !_postoTrabalhoCorteOriginalCommited.Equals(PostoTrabalhoCorte);
       }
       else
       {
            dirty = PostoTrabalhoCorte != null;
       }
      if (dirty) return true;
       dirty = _postoTrabalhoCorteIdentificacaoOriginalCommited != PostoTrabalhoCorteIdentificacao;
      if (dirty) return true;
       dirty = _postoTrabalhoCorteDescricaoOriginalCommited != PostoTrabalhoCorteDescricao;
      if (dirty) return true;
       dirty = _planoCorteInformacoesAdicionaisOriginalCommited != PlanoCorteInformacoesAdicionais;
      if (dirty) return true;
       if (_materialOriginalCommited!=null)
       {
          dirty = !_materialOriginalCommited.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
      if (dirty) return true;
       dirty = _planoCorteGeradoOriginalCommited != PlanoCorteGerado;
      if (dirty) return true;
       if (_unidadeMedidaDimensao1OriginalCommited!=null)
       {
          dirty = !_unidadeMedidaDimensao1OriginalCommited.Equals(UnidadeMedidaDimensao1);
       }
       else
       {
            dirty = UnidadeMedidaDimensao1 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao1UnidadeMedidaOriginalCommited != PlanoCorteDimensao1UnidadeMedida;
      if (dirty) return true;
       if (_unidadeMedidaDimensao2OriginalCommited!=null)
       {
          dirty = !_unidadeMedidaDimensao2OriginalCommited.Equals(UnidadeMedidaDimensao2);
       }
       else
       {
            dirty = UnidadeMedidaDimensao2 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao2UnidadeMedidaOriginalCommited != PlanoCorteDimensao2UnidadeMedida;
      if (dirty) return true;
       if (_unidadeMedidaDimensao3OriginalCommited!=null)
       {
          dirty = !_unidadeMedidaDimensao3OriginalCommited.Equals(UnidadeMedidaDimensao3);
       }
       else
       {
            dirty = UnidadeMedidaDimensao3 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao3UnidadeMedidaOriginalCommited != PlanoCorteDimensao3UnidadeMedida;

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
             case "Descricao":
                return this.Descricao;
             case "Medida":
                return this.Medida;
             case "MedidaLargura":
                return this.MedidaLargura;
             case "MedidaComprimento":
                return this.MedidaComprimento;
             case "Codigo":
                return this.Codigo;
             case "UnidadeMedida":
                return this.UnidadeMedida;
             case "FamiliaMaterial":
                return this.FamiliaMaterial;
             case "Acabamento":
                return this.Acabamento;
             case "DescricaoAdicional":
                return this.DescricaoAdicional;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "OrderItemEtiqueta":
                return this.OrderItemEtiqueta;
             case "QuantidadeUnidadePai":
                return this.QuantidadeUnidadePai;
             case "QuantidadeTotal":
                return this.QuantidadeTotal;
             case "PlanoCorte":
                return this.PlanoCorte;
             case "PlanoCorteQuantidade":
                return this.PlanoCorteQuantidade;
             case "PlanoCorteDimensao1Valor":
                return this.PlanoCorteDimensao1Valor;
             case "PlanoCorteDimensao1Identificacao":
                return this.PlanoCorteDimensao1Identificacao;
             case "PlanoCorteDimensao1Descricao":
                return this.PlanoCorteDimensao1Descricao;
             case "DimensaoCorte1":
                return this.DimensaoCorte1;
             case "PlanoCorteDimensao2Valor":
                return this.PlanoCorteDimensao2Valor;
             case "PlanoCorteDimensao2Identificacao":
                return this.PlanoCorteDimensao2Identificacao;
             case "PlanoCorteDimensao2Descricao":
                return this.PlanoCorteDimensao2Descricao;
             case "DimensaoCorte2":
                return this.DimensaoCorte2;
             case "PlanoCorteDimensao3Valor":
                return this.PlanoCorteDimensao3Valor;
             case "PlanoCorteDimensao3Identificacao":
                return this.PlanoCorteDimensao3Identificacao;
             case "PlanoCorteDimensao3Descricao":
                return this.PlanoCorteDimensao3Descricao;
             case "DimensaoCorte3":
                return this.DimensaoCorte3;
             case "PostoTrabalhoCorte":
                return this.PostoTrabalhoCorte;
             case "PostoTrabalhoCorteIdentificacao":
                return this.PostoTrabalhoCorteIdentificacao;
             case "PostoTrabalhoCorteDescricao":
                return this.PostoTrabalhoCorteDescricao;
             case "PlanoCorteInformacoesAdicionais":
                return this.PlanoCorteInformacoesAdicionais;
             case "Material":
                return this.Material;
             case "PlanoCorteGerado":
                return this.PlanoCorteGerado;
             case "UnidadeMedidaDimensao1":
                return this.UnidadeMedidaDimensao1;
             case "PlanoCorteDimensao1UnidadeMedida":
                return this.PlanoCorteDimensao1UnidadeMedida;
             case "UnidadeMedidaDimensao2":
                return this.UnidadeMedidaDimensao2;
             case "PlanoCorteDimensao2UnidadeMedida":
                return this.PlanoCorteDimensao2UnidadeMedida;
             case "UnidadeMedidaDimensao3":
                return this.UnidadeMedidaDimensao3;
             case "PlanoCorteDimensao3UnidadeMedida":
                return this.PlanoCorteDimensao3UnidadeMedida;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (UnidadeMedida!=null)
                UnidadeMedida.ChangeSingleConnection(newConnection);
             if (FamiliaMaterial!=null)
                FamiliaMaterial.ChangeSingleConnection(newConnection);
             if (Acabamento!=null)
                Acabamento.ChangeSingleConnection(newConnection);
             if (OrderItemEtiqueta!=null)
                OrderItemEtiqueta.ChangeSingleConnection(newConnection);
             if (DimensaoCorte1!=null)
                DimensaoCorte1.ChangeSingleConnection(newConnection);
             if (DimensaoCorte2!=null)
                DimensaoCorte2.ChangeSingleConnection(newConnection);
             if (DimensaoCorte3!=null)
                DimensaoCorte3.ChangeSingleConnection(newConnection);
             if (PostoTrabalhoCorte!=null)
                PostoTrabalhoCorte.ChangeSingleConnection(newConnection);
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
             if (UnidadeMedidaDimensao1!=null)
                UnidadeMedidaDimensao1.ChangeSingleConnection(newConnection);
             if (UnidadeMedidaDimensao2!=null)
                UnidadeMedidaDimensao2.ChangeSingleConnection(newConnection);
             if (UnidadeMedidaDimensao3!=null)
                UnidadeMedidaDimensao3.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(pedido_item_configurado_material.id_pedido_item_configurado_material) " ;
               }
               else
               {
               command.CommandText += "pedido_item_configurado_material.id_pedido_item_configurado_material, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_descricao, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_medida, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_medida_largura, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_medida_comprimento, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_codigo, " ;
               command.CommandText += "pedido_item_configurado_material.id_unidade_medida, " ;
               command.CommandText += "pedido_item_configurado_material.id_familia_material, " ;
               command.CommandText += "pedido_item_configurado_material.id_acabamento, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_descricao_adicional, " ;
               command.CommandText += "pedido_item_configurado_material.entity_uid, " ;
               command.CommandText += "pedido_item_configurado_material.version, " ;
               command.CommandText += "pedido_item_configurado_material.id_order_item_etiqueta, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_quantidade_unidade_pai, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_quantidade_total, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_quantidade, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_1_valor, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_1_identificacao, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_1_descricao, " ;
               command.CommandText += "pedido_item_configurado_material.id_dimensao_corte_1, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_2_valor, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_2_identificacao, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_2_descricao, " ;
               command.CommandText += "pedido_item_configurado_material.id_dimensao_corte_2, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_3_valor, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_3_identificacao, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_3_descricao, " ;
               command.CommandText += "pedido_item_configurado_material.id_dimensao_corte_3, " ;
               command.CommandText += "pedido_item_configurado_material.id_posto_trabalho_corte, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_posto_trabalho_corte_identificacao, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_posto_trabalho_corte_descricao, " ;
               command.CommandText += "pedido_item_configurado_material.prm_plano_corte_informacoes_adicionais, " ;
               command.CommandText += "pedido_item_configurado_material.id_material, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_gerado, " ;
               command.CommandText += "pedido_item_configurado_material.id_unidade_medida_dimensao_1, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_1_unidade_medida, " ;
               command.CommandText += "pedido_item_configurado_material.id_unidade_medida_dimensao_2, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_2_unidade_medida, " ;
               command.CommandText += "pedido_item_configurado_material.id_unidade_medida_dimensao_3, " ;
               command.CommandText += "pedido_item_configurado_material.pcm_plano_corte_dimensao_3_unidade_medida " ;
               }
               command.CommandText += " FROM  pedido_item_configurado_material ";
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
                        orderByClause += " , pcm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pcm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = pedido_item_configurado_material.id_acs_usuario_ultima_revisao ";
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
                     case "id_pedido_item_configurado_material":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_configurado_material.id_pedido_item_configurado_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.id_pedido_item_configurado_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_medida":
                     case "Medida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_configurado_material.pcm_medida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_medida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_medida_largura":
                     case "MedidaLargura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_configurado_material.pcm_medida_largura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_medida_largura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_medida_comprimento":
                     case "MedidaComprimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_configurado_material.pcm_medida_comprimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_medida_comprimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida":
                     case "UnidadeMedida":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedida ON unidade_medida_UnidadeMedida.id_unidade_medida = pedido_item_configurado_material.id_unidade_medida ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedida.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedida.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_familia_material":
                     case "FamiliaMaterial":
                     command.CommandText += " LEFT JOIN familia_material as familia_material_FamiliaMaterial ON familia_material_FamiliaMaterial.id_familia_material = pedido_item_configurado_material.id_familia_material ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_material_FamiliaMaterial.fam_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_material_FamiliaMaterial.fam_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acabamento":
                     case "Acabamento":
                     command.CommandText += " LEFT JOIN acabamento as acabamento_Acabamento ON acabamento_Acabamento.id_acabamento = pedido_item_configurado_material.id_acabamento ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , acabamento_Acabamento.acb_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(acabamento_Acabamento.acb_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_descricao_adicional":
                     case "DescricaoAdicional":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_descricao_adicional " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_descricao_adicional) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , pedido_item_configurado_material.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_order_item_etiqueta":
                     case "OrderItemEtiqueta":
                     command.CommandText += " LEFT JOIN order_item_etiqueta as order_item_etiqueta_OrderItemEtiqueta ON order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta = pedido_item_configurado_material.id_order_item_etiqueta ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.oie_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.oie_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.oie_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.oie_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_quantidade_unidade_pai":
                     case "QuantidadeUnidadePai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_configurado_material.pcm_quantidade_unidade_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_quantidade_unidade_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_quantidade_total":
                     case "QuantidadeTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_configurado_material.pcm_quantidade_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_quantidade_total) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte":
                     case "PlanoCorte":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_quantidade":
                     case "PlanoCorteQuantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_1_valor":
                     case "PlanoCorteDimensao1Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_1_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_1_identificacao":
                     case "PlanoCorteDimensao1Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_1_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_1_descricao":
                     case "PlanoCorteDimensao1Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_1_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_dimensao_corte_1":
                     case "DimensaoCorte1":
                     command.CommandText += " LEFT JOIN dimensao as dimensao_DimensaoCorte1 ON dimensao_DimensaoCorte1.id_dimensao = pedido_item_configurado_material.id_dimensao_corte_1 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao_DimensaoCorte1.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao_DimensaoCorte1.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_2_valor":
                     case "PlanoCorteDimensao2Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_2_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_2_identificacao":
                     case "PlanoCorteDimensao2Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_2_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_2_descricao":
                     case "PlanoCorteDimensao2Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_2_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_dimensao_corte_2":
                     case "DimensaoCorte2":
                     command.CommandText += " LEFT JOIN dimensao as dimensao_DimensaoCorte2 ON dimensao_DimensaoCorte2.id_dimensao = pedido_item_configurado_material.id_dimensao_corte_2 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao_DimensaoCorte2.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao_DimensaoCorte2.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_3_valor":
                     case "PlanoCorteDimensao3Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_3_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_3_identificacao":
                     case "PlanoCorteDimensao3Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_3_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_3_descricao":
                     case "PlanoCorteDimensao3Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_3_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_dimensao_corte_3":
                     case "DimensaoCorte3":
                     command.CommandText += " LEFT JOIN dimensao as dimensao_DimensaoCorte3 ON dimensao_DimensaoCorte3.id_dimensao = pedido_item_configurado_material.id_dimensao_corte_3 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao_DimensaoCorte3.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao_DimensaoCorte3.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_posto_trabalho_corte":
                     case "PostoTrabalhoCorte":
                     command.CommandText += " LEFT JOIN posto_trabalho as posto_trabalho_PostoTrabalhoCorte ON posto_trabalho_PostoTrabalhoCorte.id_posto_trabalho = pedido_item_configurado_material.id_posto_trabalho_corte ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho_PostoTrabalhoCorte.pos_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho_PostoTrabalhoCorte.pos_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_posto_trabalho_corte_identificacao":
                     case "PostoTrabalhoCorteIdentificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_posto_trabalho_corte_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_posto_trabalho_corte_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_posto_trabalho_corte_descricao":
                     case "PostoTrabalhoCorteDescricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_posto_trabalho_corte_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_posto_trabalho_corte_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_plano_corte_informacoes_adicionais":
                     case "PlanoCorteInformacoesAdicionais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.prm_plano_corte_informacoes_adicionais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.prm_plano_corte_informacoes_adicionais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = pedido_item_configurado_material.id_material ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material_Material.mat_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material_Material.mat_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_gerado":
                     case "PlanoCorteGerado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_gerado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_gerado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_dimensao_1":
                     case "UnidadeMedidaDimensao1":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaDimensao1 ON unidade_medida_UnidadeMedidaDimensao1.id_unidade_medida = pedido_item_configurado_material.id_unidade_medida_dimensao_1 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedidaDimensao1.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedidaDimensao1.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_1_unidade_medida":
                     case "PlanoCorteDimensao1UnidadeMedida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_1_unidade_medida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_unidade_medida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_dimensao_2":
                     case "UnidadeMedidaDimensao2":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaDimensao2 ON unidade_medida_UnidadeMedidaDimensao2.id_unidade_medida = pedido_item_configurado_material.id_unidade_medida_dimensao_2 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedidaDimensao2.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedidaDimensao2.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_2_unidade_medida":
                     case "PlanoCorteDimensao2UnidadeMedida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_2_unidade_medida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_unidade_medida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_dimensao_3":
                     case "UnidadeMedidaDimensao3":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaDimensao3 ON unidade_medida_UnidadeMedidaDimensao3.id_unidade_medida = pedido_item_configurado_material.id_unidade_medida_dimensao_3 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedidaDimensao3.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedidaDimensao3.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcm_plano_corte_dimensao_3_unidade_medida":
                     case "PlanoCorteDimensao3UnidadeMedida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_configurado_material.pcm_plano_corte_dimensao_3_unidade_medida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_unidade_medida) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_descricao")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_codigo")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_descricao_adicional")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_descricao_adicional) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_descricao_adicional) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_1_valor")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_1_identificacao")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_1_descricao")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_2_valor")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_2_identificacao")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_2_descricao")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_3_valor")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_3_identificacao")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_3_descricao")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_posto_trabalho_corte_identificacao")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_posto_trabalho_corte_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_posto_trabalho_corte_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_posto_trabalho_corte_descricao")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_posto_trabalho_corte_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_posto_trabalho_corte_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prm_plano_corte_informacoes_adicionais")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.prm_plano_corte_informacoes_adicionais) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.prm_plano_corte_informacoes_adicionais) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_1_unidade_medida")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_unidade_medida) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_1_unidade_medida) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_2_unidade_medida")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_unidade_medida) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_2_unidade_medida) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcm_plano_corte_dimensao_3_unidade_medida")) 
                        {
                           whereClause += " OR UPPER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_unidade_medida) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_configurado_material.pcm_plano_corte_dimensao_3_unidade_medida) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_pedido_item_configurado_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_pedido_item_configurado_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_pedido_item_configurado_material = :pedido_item_configurado_material_ID_4579 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_ID_4579", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "pcm_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_descricao LIKE :pedido_item_configurado_material_Descricao_3183 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_Descricao_3183", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Medida" || parametro.FieldName == "pcm_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_medida = :pedido_item_configurado_material_Medida_3898 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_Medida_3898", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MedidaLargura" || parametro.FieldName == "pcm_medida_largura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_medida_largura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_medida_largura = :pedido_item_configurado_material_MedidaLargura_9211 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_MedidaLargura_9211", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MedidaComprimento" || parametro.FieldName == "pcm_medida_comprimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_medida_comprimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_medida_comprimento = :pedido_item_configurado_material_MedidaComprimento_2996 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_MedidaComprimento_2996", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "pcm_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_codigo LIKE :pedido_item_configurado_material_Codigo_602 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_Codigo_602", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedida" || parametro.FieldName == "id_unidade_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_unidade_medida = :pedido_item_configurado_material_UnidadeMedida_3151 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_UnidadeMedida_3151", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FamiliaMaterial" || parametro.FieldName == "id_familia_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FamiliaMaterialClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FamiliaMaterialClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_familia_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_familia_material = :pedido_item_configurado_material_FamiliaMaterial_7866 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_FamiliaMaterial_7866", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Acabamento" || parametro.FieldName == "id_acabamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.AcabamentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.AcabamentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_acabamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_acabamento = :pedido_item_configurado_material_Acabamento_4322 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_Acabamento_4322", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoAdicional" || parametro.FieldName == "pcm_descricao_adicional")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_descricao_adicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_descricao_adicional LIKE :pedido_item_configurado_material_DescricaoAdicional_9196 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_DescricaoAdicional_9196", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  pedido_item_configurado_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.entity_uid LIKE :pedido_item_configurado_material_EntityUid_6275 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_EntityUid_6275", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  pedido_item_configurado_material.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.version = :pedido_item_configurado_material_Version_2898 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_Version_2898", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderItemEtiqueta" || parametro.FieldName == "id_order_item_etiqueta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrderItemEtiquetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_order_item_etiqueta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_order_item_etiqueta = :pedido_item_configurado_material_OrderItemEtiqueta_7866 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_OrderItemEtiqueta_7866", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeUnidadePai" || parametro.FieldName == "pcm_quantidade_unidade_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_quantidade_unidade_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_quantidade_unidade_pai = :pedido_item_configurado_material_QuantidadeUnidadePai_5069 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_QuantidadeUnidadePai_5069", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeTotal" || parametro.FieldName == "pcm_quantidade_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_quantidade_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_quantidade_total = :pedido_item_configurado_material_QuantidadeTotal_8084 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_QuantidadeTotal_8084", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorte" || parametro.FieldName == "pcm_plano_corte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte = :pedido_item_configurado_material_PlanoCorte_5382 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorte_5382", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteQuantidade" || parametro.FieldName == "pcm_plano_corte_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_quantidade = :pedido_item_configurado_material_PlanoCorteQuantidade_87 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteQuantidade_87", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1Valor" || parametro.FieldName == "pcm_plano_corte_dimensao_1_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_valor LIKE :pedido_item_configurado_material_PlanoCorteDimensao1Valor_5740 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao1Valor_5740", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1Identificacao" || parametro.FieldName == "pcm_plano_corte_dimensao_1_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_identificacao LIKE :pedido_item_configurado_material_PlanoCorteDimensao1Identificacao_3623 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao1Identificacao_3623", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1Descricao" || parametro.FieldName == "pcm_plano_corte_dimensao_1_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_descricao LIKE :pedido_item_configurado_material_PlanoCorteDimensao1Descricao_4124 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao1Descricao_4124", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DimensaoCorte1" || parametro.FieldName == "id_dimensao_corte_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DimensaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DimensaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_dimensao_corte_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_dimensao_corte_1 = :pedido_item_configurado_material_DimensaoCorte1_5249 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_DimensaoCorte1_5249", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2Valor" || parametro.FieldName == "pcm_plano_corte_dimensao_2_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_valor LIKE :pedido_item_configurado_material_PlanoCorteDimensao2Valor_9553 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao2Valor_9553", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2Identificacao" || parametro.FieldName == "pcm_plano_corte_dimensao_2_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_identificacao LIKE :pedido_item_configurado_material_PlanoCorteDimensao2Identificacao_1760 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao2Identificacao_1760", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2Descricao" || parametro.FieldName == "pcm_plano_corte_dimensao_2_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_descricao LIKE :pedido_item_configurado_material_PlanoCorteDimensao2Descricao_258 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao2Descricao_258", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DimensaoCorte2" || parametro.FieldName == "id_dimensao_corte_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DimensaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DimensaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_dimensao_corte_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_dimensao_corte_2 = :pedido_item_configurado_material_DimensaoCorte2_6425 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_DimensaoCorte2_6425", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3Valor" || parametro.FieldName == "pcm_plano_corte_dimensao_3_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_valor LIKE :pedido_item_configurado_material_PlanoCorteDimensao3Valor_2434 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao3Valor_2434", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3Identificacao" || parametro.FieldName == "pcm_plano_corte_dimensao_3_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_identificacao LIKE :pedido_item_configurado_material_PlanoCorteDimensao3Identificacao_8119 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao3Identificacao_8119", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3Descricao" || parametro.FieldName == "pcm_plano_corte_dimensao_3_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_descricao LIKE :pedido_item_configurado_material_PlanoCorteDimensao3Descricao_3992 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao3Descricao_3992", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DimensaoCorte3" || parametro.FieldName == "id_dimensao_corte_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DimensaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DimensaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_dimensao_corte_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_dimensao_corte_3 = :pedido_item_configurado_material_DimensaoCorte3_4319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_DimensaoCorte3_4319", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalhoCorte" || parametro.FieldName == "id_posto_trabalho_corte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PostoTrabalhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PostoTrabalhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_posto_trabalho_corte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_posto_trabalho_corte = :pedido_item_configurado_material_PostoTrabalhoCorte_4255 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PostoTrabalhoCorte_4255", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalhoCorteIdentificacao" || parametro.FieldName == "pcm_posto_trabalho_corte_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_posto_trabalho_corte_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_posto_trabalho_corte_identificacao LIKE :pedido_item_configurado_material_PostoTrabalhoCorteIdentificacao_398 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PostoTrabalhoCorteIdentificacao_398", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalhoCorteDescricao" || parametro.FieldName == "pcm_posto_trabalho_corte_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_posto_trabalho_corte_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_posto_trabalho_corte_descricao LIKE :pedido_item_configurado_material_PostoTrabalhoCorteDescricao_9255 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PostoTrabalhoCorteDescricao_9255", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteInformacoesAdicionais" || parametro.FieldName == "prm_plano_corte_informacoes_adicionais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.prm_plano_corte_informacoes_adicionais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.prm_plano_corte_informacoes_adicionais LIKE :pedido_item_configurado_material_PlanoCorteInformacoesAdicionais_2746 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteInformacoesAdicionais_2746", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Material" || parametro.FieldName == "id_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MaterialClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MaterialClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_material = :pedido_item_configurado_material_Material_6103 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_Material_6103", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteGerado" || parametro.FieldName == "pcm_plano_corte_gerado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_gerado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_gerado = :pedido_item_configurado_material_PlanoCorteGerado_9541 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteGerado_9541", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaDimensao1" || parametro.FieldName == "id_unidade_medida_dimensao_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_unidade_medida_dimensao_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_unidade_medida_dimensao_1 = :pedido_item_configurado_material_UnidadeMedidaDimensao1_8864 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_UnidadeMedidaDimensao1_8864", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1UnidadeMedida" || parametro.FieldName == "pcm_plano_corte_dimensao_1_unidade_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_unidade_medida LIKE :pedido_item_configurado_material_PlanoCorteDimensao1UnidadeMedida_9370 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao1UnidadeMedida_9370", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaDimensao2" || parametro.FieldName == "id_unidade_medida_dimensao_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_unidade_medida_dimensao_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_unidade_medida_dimensao_2 = :pedido_item_configurado_material_UnidadeMedidaDimensao2_4228 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_UnidadeMedidaDimensao2_4228", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2UnidadeMedida" || parametro.FieldName == "pcm_plano_corte_dimensao_2_unidade_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_unidade_medida LIKE :pedido_item_configurado_material_PlanoCorteDimensao2UnidadeMedida_7707 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao2UnidadeMedida_7707", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaDimensao3" || parametro.FieldName == "id_unidade_medida_dimensao_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.id_unidade_medida_dimensao_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.id_unidade_medida_dimensao_3 = :pedido_item_configurado_material_UnidadeMedidaDimensao3_7086 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_UnidadeMedidaDimensao3_7086", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3UnidadeMedida" || parametro.FieldName == "pcm_plano_corte_dimensao_3_unidade_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_unidade_medida LIKE :pedido_item_configurado_material_PlanoCorteDimensao3UnidadeMedida_8267 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao3UnidadeMedida_8267", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  pedido_item_configurado_material.pcm_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_descricao LIKE :pedido_item_configurado_material_Descricao_7607 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_Descricao_7607", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoExato" || parametro.FieldName == "CodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_codigo LIKE :pedido_item_configurado_material_Codigo_3534 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_Codigo_3534", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoAdicionalExato" || parametro.FieldName == "DescricaoAdicionalExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_descricao_adicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_descricao_adicional LIKE :pedido_item_configurado_material_DescricaoAdicional_631 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_DescricaoAdicional_631", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  pedido_item_configurado_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.entity_uid LIKE :pedido_item_configurado_material_EntityUid_1511 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_EntityUid_1511", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1ValorExato" || parametro.FieldName == "PlanoCorteDimensao1ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_valor LIKE :pedido_item_configurado_material_PlanoCorteDimensao1Valor_5877 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao1Valor_5877", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1IdentificacaoExato" || parametro.FieldName == "PlanoCorteDimensao1IdentificacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_identificacao LIKE :pedido_item_configurado_material_PlanoCorteDimensao1Identificacao_1787 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao1Identificacao_1787", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1DescricaoExato" || parametro.FieldName == "PlanoCorteDimensao1DescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_descricao LIKE :pedido_item_configurado_material_PlanoCorteDimensao1Descricao_1293 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao1Descricao_1293", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2ValorExato" || parametro.FieldName == "PlanoCorteDimensao2ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_valor LIKE :pedido_item_configurado_material_PlanoCorteDimensao2Valor_2617 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao2Valor_2617", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2IdentificacaoExato" || parametro.FieldName == "PlanoCorteDimensao2IdentificacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_identificacao LIKE :pedido_item_configurado_material_PlanoCorteDimensao2Identificacao_3722 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao2Identificacao_3722", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2DescricaoExato" || parametro.FieldName == "PlanoCorteDimensao2DescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_descricao LIKE :pedido_item_configurado_material_PlanoCorteDimensao2Descricao_2634 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao2Descricao_2634", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3ValorExato" || parametro.FieldName == "PlanoCorteDimensao3ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_valor LIKE :pedido_item_configurado_material_PlanoCorteDimensao3Valor_5891 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao3Valor_5891", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3IdentificacaoExato" || parametro.FieldName == "PlanoCorteDimensao3IdentificacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_identificacao LIKE :pedido_item_configurado_material_PlanoCorteDimensao3Identificacao_9032 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao3Identificacao_9032", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3DescricaoExato" || parametro.FieldName == "PlanoCorteDimensao3DescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_descricao LIKE :pedido_item_configurado_material_PlanoCorteDimensao3Descricao_2921 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao3Descricao_2921", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalhoCorteIdentificacaoExato" || parametro.FieldName == "PostoTrabalhoCorteIdentificacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_posto_trabalho_corte_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_posto_trabalho_corte_identificacao LIKE :pedido_item_configurado_material_PostoTrabalhoCorteIdentificacao_1970 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PostoTrabalhoCorteIdentificacao_1970", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalhoCorteDescricaoExato" || parametro.FieldName == "PostoTrabalhoCorteDescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_posto_trabalho_corte_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_posto_trabalho_corte_descricao LIKE :pedido_item_configurado_material_PostoTrabalhoCorteDescricao_5025 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PostoTrabalhoCorteDescricao_5025", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteInformacoesAdicionaisExato" || parametro.FieldName == "PlanoCorteInformacoesAdicionaisExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.prm_plano_corte_informacoes_adicionais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.prm_plano_corte_informacoes_adicionais LIKE :pedido_item_configurado_material_PlanoCorteInformacoesAdicionais_1423 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteInformacoesAdicionais_1423", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1UnidadeMedidaExato" || parametro.FieldName == "PlanoCorteDimensao1UnidadeMedidaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_1_unidade_medida LIKE :pedido_item_configurado_material_PlanoCorteDimensao1UnidadeMedida_3640 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao1UnidadeMedida_3640", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2UnidadeMedidaExato" || parametro.FieldName == "PlanoCorteDimensao2UnidadeMedidaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_2_unidade_medida LIKE :pedido_item_configurado_material_PlanoCorteDimensao2UnidadeMedida_2786 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao2UnidadeMedida_2786", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3UnidadeMedidaExato" || parametro.FieldName == "PlanoCorteDimensao3UnidadeMedidaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_configurado_material.pcm_plano_corte_dimensao_3_unidade_medida LIKE :pedido_item_configurado_material_PlanoCorteDimensao3UnidadeMedida_563 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_configurado_material_PlanoCorteDimensao3UnidadeMedida_563", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PedidoItemConfiguradoMaterialClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PedidoItemConfiguradoMaterialClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PedidoItemConfiguradoMaterialClass), Convert.ToInt32(read["id_pedido_item_configurado_material"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PedidoItemConfiguradoMaterialClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_pedido_item_configurado_material"]);
                     entidade.Descricao = (read["pcm_descricao"] != DBNull.Value ? read["pcm_descricao"].ToString() : null);
                     entidade.Medida = (double)read["pcm_medida"];
                     entidade.MedidaLargura = (double)read["pcm_medida_largura"];
                     entidade.MedidaComprimento = (double)read["pcm_medida_comprimento"];
                     entidade.Codigo = (read["pcm_codigo"] != DBNull.Value ? read["pcm_codigo"].ToString() : null);
                     if (read["id_unidade_medida"] != DBNull.Value)
                     {
                        entidade.UnidadeMedida = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedida = null ;
                     }
                     if (read["id_familia_material"] != DBNull.Value)
                     {
                        entidade.FamiliaMaterial = (BibliotecaEntidades.Entidades.FamiliaMaterialClass)BibliotecaEntidades.Entidades.FamiliaMaterialClass.GetEntidade(Convert.ToInt32(read["id_familia_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FamiliaMaterial = null ;
                     }
                     if (read["id_acabamento"] != DBNull.Value)
                     {
                        entidade.Acabamento = (BibliotecaEntidades.Entidades.AcabamentoClass)BibliotecaEntidades.Entidades.AcabamentoClass.GetEntidade(Convert.ToInt32(read["id_acabamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Acabamento = null ;
                     }
                     entidade.DescricaoAdicional = (read["pcm_descricao_adicional"] != DBNull.Value ? read["pcm_descricao_adicional"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_order_item_etiqueta"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiqueta = (BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiqueta = null ;
                     }
                     entidade.QuantidadeUnidadePai = (double)read["pcm_quantidade_unidade_pai"];
                     entidade.QuantidadeTotal = (double)read["pcm_quantidade_total"];
                     entidade.PlanoCorte = Convert.ToBoolean(Convert.ToInt16(read["pcm_plano_corte"]));
                     entidade.PlanoCorteQuantidade = read["pcm_plano_corte_quantidade"] as double?;
                     entidade.PlanoCorteDimensao1Valor = (read["pcm_plano_corte_dimensao_1_valor"] != DBNull.Value ? read["pcm_plano_corte_dimensao_1_valor"].ToString() : null);
                     entidade.PlanoCorteDimensao1Identificacao = (read["pcm_plano_corte_dimensao_1_identificacao"] != DBNull.Value ? read["pcm_plano_corte_dimensao_1_identificacao"].ToString() : null);
                     entidade.PlanoCorteDimensao1Descricao = (read["pcm_plano_corte_dimensao_1_descricao"] != DBNull.Value ? read["pcm_plano_corte_dimensao_1_descricao"].ToString() : null);
                     if (read["id_dimensao_corte_1"] != DBNull.Value)
                     {
                        entidade.DimensaoCorte1 = (BibliotecaEntidades.Entidades.DimensaoClass)BibliotecaEntidades.Entidades.DimensaoClass.GetEntidade(Convert.ToInt32(read["id_dimensao_corte_1"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DimensaoCorte1 = null ;
                     }
                     entidade.PlanoCorteDimensao2Valor = (read["pcm_plano_corte_dimensao_2_valor"] != DBNull.Value ? read["pcm_plano_corte_dimensao_2_valor"].ToString() : null);
                     entidade.PlanoCorteDimensao2Identificacao = (read["pcm_plano_corte_dimensao_2_identificacao"] != DBNull.Value ? read["pcm_plano_corte_dimensao_2_identificacao"].ToString() : null);
                     entidade.PlanoCorteDimensao2Descricao = (read["pcm_plano_corte_dimensao_2_descricao"] != DBNull.Value ? read["pcm_plano_corte_dimensao_2_descricao"].ToString() : null);
                     if (read["id_dimensao_corte_2"] != DBNull.Value)
                     {
                        entidade.DimensaoCorte2 = (BibliotecaEntidades.Entidades.DimensaoClass)BibliotecaEntidades.Entidades.DimensaoClass.GetEntidade(Convert.ToInt32(read["id_dimensao_corte_2"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DimensaoCorte2 = null ;
                     }
                     entidade.PlanoCorteDimensao3Valor = (read["pcm_plano_corte_dimensao_3_valor"] != DBNull.Value ? read["pcm_plano_corte_dimensao_3_valor"].ToString() : null);
                     entidade.PlanoCorteDimensao3Identificacao = (read["pcm_plano_corte_dimensao_3_identificacao"] != DBNull.Value ? read["pcm_plano_corte_dimensao_3_identificacao"].ToString() : null);
                     entidade.PlanoCorteDimensao3Descricao = (read["pcm_plano_corte_dimensao_3_descricao"] != DBNull.Value ? read["pcm_plano_corte_dimensao_3_descricao"].ToString() : null);
                     if (read["id_dimensao_corte_3"] != DBNull.Value)
                     {
                        entidade.DimensaoCorte3 = (BibliotecaEntidades.Entidades.DimensaoClass)BibliotecaEntidades.Entidades.DimensaoClass.GetEntidade(Convert.ToInt32(read["id_dimensao_corte_3"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DimensaoCorte3 = null ;
                     }
                     if (read["id_posto_trabalho_corte"] != DBNull.Value)
                     {
                        entidade.PostoTrabalhoCorte = (BibliotecaEntidades.Entidades.PostoTrabalhoClass)BibliotecaEntidades.Entidades.PostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_posto_trabalho_corte"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PostoTrabalhoCorte = null ;
                     }
                     entidade.PostoTrabalhoCorteIdentificacao = (read["pcm_posto_trabalho_corte_identificacao"] != DBNull.Value ? read["pcm_posto_trabalho_corte_identificacao"].ToString() : null);
                     entidade.PostoTrabalhoCorteDescricao = (read["pcm_posto_trabalho_corte_descricao"] != DBNull.Value ? read["pcm_posto_trabalho_corte_descricao"].ToString() : null);
                     entidade.PlanoCorteInformacoesAdicionais = (read["prm_plano_corte_informacoes_adicionais"] != DBNull.Value ? read["prm_plano_corte_informacoes_adicionais"].ToString() : null);
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     entidade.PlanoCorteGerado = Convert.ToBoolean(Convert.ToInt16(read["pcm_plano_corte_gerado"]));
                     if (read["id_unidade_medida_dimensao_1"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaDimensao1 = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_dimensao_1"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaDimensao1 = null ;
                     }
                     entidade.PlanoCorteDimensao1UnidadeMedida = (read["pcm_plano_corte_dimensao_1_unidade_medida"] != DBNull.Value ? read["pcm_plano_corte_dimensao_1_unidade_medida"].ToString() : null);
                     if (read["id_unidade_medida_dimensao_2"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaDimensao2 = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_dimensao_2"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaDimensao2 = null ;
                     }
                     entidade.PlanoCorteDimensao2UnidadeMedida = (read["pcm_plano_corte_dimensao_2_unidade_medida"] != DBNull.Value ? read["pcm_plano_corte_dimensao_2_unidade_medida"].ToString() : null);
                     if (read["id_unidade_medida_dimensao_3"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaDimensao3 = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_dimensao_3"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaDimensao3 = null ;
                     }
                     entidade.PlanoCorteDimensao3UnidadeMedida = (read["pcm_plano_corte_dimensao_3_unidade_medida"] != DBNull.Value ? read["pcm_plano_corte_dimensao_3_unidade_medida"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PedidoItemConfiguradoMaterialClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
