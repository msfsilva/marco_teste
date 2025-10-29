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
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("material","mat")]
     public class MaterialBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MaterialClass";
protected const string ErroDelete = "Erro ao excluir o MaterialClass  ";
protected const string ErroSave = "Erro ao salvar o MaterialClass.";
protected const string ErroCollectionContratoFornecimentoClassMaterial = "Erro ao carregar a coleção de ContratoFornecimentoClass.";
protected const string ErroCollectionDeclaracaoImportacaoAdicaoItemClassMaterial = "Erro ao carregar a coleção de DeclaracaoImportacaoAdicaoItemClass.";
protected const string ErroCollectionEstoqueGavetaItemClassMaterial = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected const string ErroCollectionFomularioRetiradaManualEstoqueClassMaterial = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
protected const string ErroCollectionHistoricoCompraMaterialClassMaterial = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
protected const string ErroCollectionKanbanAcionamentoClassMaterial = "Erro ao carregar a coleção de KanbanAcionamentoClass.";
protected const string ErroCollectionLoteClassMaterial = "Erro ao carregar a coleção de LoteClass.";
protected const string ErroCollectionMaterialFiscalClassMaterial = "Erro ao carregar a coleção de MaterialFiscalClass.";
protected const string ErroCollectionMaterialFornecedorClassMaterial = "Erro ao carregar a coleção de MaterialFornecedorClass.";
protected const string ErroCollectionOrcamentoCompraItemClassMaterial = "Erro ao carregar a coleção de OrcamentoCompraItemClass.";
protected const string ErroCollectionOrdemProducaoMaterialClassMaterial = "Erro ao carregar a coleção de OrdemProducaoMaterialClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassMaterial = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPlanoCorteItemClassMaterial = "Erro ao carregar a coleção de PlanoCorteItemClass.";
protected const string ErroCollectionProdutoMaterialClassMaterial = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected const string ErroCollectionSolicitacaoCompraClassMaterial = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroUnidadeMedidaObrigatorio = "O campo UnidadeMedida é obrigatório";
protected const string ErroFamiliaMaterialObrigatorio = "O campo FamiliaMaterial é obrigatório";
protected const string ErroAcabamentoObrigatorio = "O campo Acabamento é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do MaterialClass.";
protected const string MensagemUtilizadoCollectionContratoFornecimentoClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes ContratoFornecimentoClass:";
protected const string MensagemUtilizadoCollectionDeclaracaoImportacaoAdicaoItemClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes DeclaracaoImportacaoAdicaoItemClass:";
protected const string MensagemUtilizadoCollectionEstoqueGavetaItemClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
protected const string MensagemUtilizadoCollectionKanbanAcionamentoClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes KanbanAcionamentoClass:";
protected const string MensagemUtilizadoCollectionLoteClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes LoteClass:";
protected const string MensagemUtilizadoCollectionMaterialFiscalClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes MaterialFiscalClass:";
protected const string MensagemUtilizadoCollectionMaterialFornecedorClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes MaterialFornecedorClass:";
protected const string MensagemUtilizadoCollectionOrcamentoCompraItemClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes OrcamentoCompraItemClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoMaterialClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes OrdemProducaoMaterialClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
protected const string MensagemUtilizadoCollectionProdutoMaterialClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected const string MensagemUtilizadoCollectionSolicitacaoCompraClassMaterial =  "A entidade MaterialClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
protected const string ErroImagemLoad = "O campo Imagem não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MaterialClass está sendo utilizada.";
#endregion
       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("mat_descricao")]
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
         [Column("mat_medida")]
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
         [Column("mat_medida_largura")]
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
         [Column("mat_medida_comprimento")]
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
         [Column("mat_codigo")]
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

       protected PoliticaEstoque _politicaEstoqueOriginal{get;private set;}
       private PoliticaEstoque _politicaEstoqueOriginalCommited{get; set;}
        private PoliticaEstoque _valuePoliticaEstoque;
         [Column("mat_politica_estoque")]
        public virtual PoliticaEstoque PoliticaEstoque
         { 
            get { return this._valuePoliticaEstoque; } 
            set 
            { 
                if (this._valuePoliticaEstoque == value)return;
                 this._valuePoliticaEstoque = value; 
            } 
        } 

        public bool PoliticaEstoque_MRP
         { 
            get { return this._valuePoliticaEstoque == BibliotecaEntidades.Base.PoliticaEstoque.MRP; } 
            set { if (value) this._valuePoliticaEstoque = BibliotecaEntidades.Base.PoliticaEstoque.MRP; }
         } 

        public bool PoliticaEstoque_Kanban
         { 
            get { return this._valuePoliticaEstoque == BibliotecaEntidades.Base.PoliticaEstoque.Kanban; } 
            set { if (value) this._valuePoliticaEstoque = BibliotecaEntidades.Base.PoliticaEstoque.Kanban; }
         } 

        public bool PoliticaEstoque_NaoAplicavel
         { 
            get { return this._valuePoliticaEstoque == BibliotecaEntidades.Base.PoliticaEstoque.NaoAplicavel; } 
            set { if (value) this._valuePoliticaEstoque = BibliotecaEntidades.Base.PoliticaEstoque.NaoAplicavel; }
         } 

       protected string _codigoAntigoOriginal{get;private set;}
       private string _codigoAntigoOriginalCommited{get; set;}
        private string _valueCodigoAntigo;
         [Column("mat_codigo_antigo")]
        public virtual string CodigoAntigo
         { 
            get { return this._valueCodigoAntigo; } 
            set 
            { 
                if (this._valueCodigoAntigo == value)return;
                 this._valueCodigoAntigo = value; 
            } 
        } 

       protected string _descricaoAdicionalOriginal{get;private set;}
       private string _descricaoAdicionalOriginalCommited{get; set;}
        private string _valueDescricaoAdicional;
         [Column("mat_descricao_adicional")]
        public virtual string DescricaoAdicional
         { 
            get { return this._valueDescricaoAdicional; } 
            set 
            { 
                if (this._valueDescricaoAdicional == value)return;
                 this._valueDescricaoAdicional = value; 
            } 
        } 

       protected double _lotePadraoOriginal{get;private set;}
       private double _lotePadraoOriginalCommited{get; set;}
        private double _valueLotePadrao;
         [Column("mat_lote_padrao")]
        public virtual double LotePadrao
         { 
            get { return this._valueLotePadrao; } 
            set 
            { 
                if (this._valueLotePadrao == value)return;
                 this._valueLotePadrao = value; 
            } 
        } 

       protected double _verdeOriginal{get;private set;}
       private double _verdeOriginalCommited{get; set;}
        private double _valueVerde;
         [Column("mat_verde")]
        public virtual double Verde
         { 
            get { return this._valueVerde; } 
            set 
            { 
                if (this._valueVerde == value)return;
                 this._valueVerde = value; 
            } 
        } 

       protected double _amareloOriginal{get;private set;}
       private double _amareloOriginalCommited{get; set;}
        private double _valueAmarelo;
         [Column("mat_amarelo")]
        public virtual double Amarelo
         { 
            get { return this._valueAmarelo; } 
            set 
            { 
                if (this._valueAmarelo == value)return;
                 this._valueAmarelo = value; 
            } 
        } 

       protected double _vermelhoOriginal{get;private set;}
       private double _vermelhoOriginalCommited{get; set;}
        private double _valueVermelho;
         [Column("mat_vermelho")]
        public virtual double Vermelho
         { 
            get { return this._valueVermelho; } 
            set 
            { 
                if (this._valueVermelho == value)return;
                 this._valueVermelho = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaCompraOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaCompraOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedidaCompra;
        [Column("id_unidade_medida_compra", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedidaCompra
        { 
           get {                 return this._valueUnidadeMedidaCompra; } 
           set 
           { 
                if (this._valueUnidadeMedidaCompra == value)return;
                 this._valueUnidadeMedidaCompra = value; 
           } 
       } 

       protected double _unidadesPorUnCompraOriginal{get;private set;}
       private double _unidadesPorUnCompraOriginalCommited{get; set;}
        private double _valueUnidadesPorUnCompra;
         [Column("mat_unidades_por_un_compra")]
        public virtual double UnidadesPorUnCompra
         { 
            get { return this._valueUnidadesPorUnCompra; } 
            set 
            { 
                if (this._valueUnidadesPorUnCompra == value)return;
                 this._valueUnidadesPorUnCompra = value; 
            } 
        } 

       protected int _leadTimeCompraOriginal{get;private set;}
       private int _leadTimeCompraOriginalCommited{get; set;}
        private int _valueLeadTimeCompra;
         [Column("mat_lead_time_compra")]
        public virtual int LeadTimeCompra
         { 
            get { return this._valueLeadTimeCompra; } 
            set 
            { 
                if (this._valueLeadTimeCompra == value)return;
                 this._valueLeadTimeCompra = value; 
            } 
        } 

       protected string _marcasHomologadasOriginal{get;private set;}
       private string _marcasHomologadasOriginalCommited{get; set;}
        private string _valueMarcasHomologadas;
         [Column("mat_marcas_homologadas")]
        public virtual string MarcasHomologadas
         { 
            get { return this._valueMarcasHomologadas; } 
            set 
            { 
                if (this._valueMarcasHomologadas == value)return;
                 this._valueMarcasHomologadas = value; 
            } 
        } 

       protected bool _impedirSolicitacaoAutoOriginal{get;private set;}
       private bool _impedirSolicitacaoAutoOriginalCommited{get; set;}
        private bool _valueImpedirSolicitacaoAuto;
         [Column("mat_impedir_solicitacao_auto")]
        public virtual bool ImpedirSolicitacaoAuto
         { 
            get { return this._valueImpedirSolicitacaoAuto; } 
            set 
            { 
                if (this._valueImpedirSolicitacaoAuto == value)return;
                 this._valueImpedirSolicitacaoAuto = value; 
            } 
        } 

       protected EstoqueSeguranca _utilizandoEstoqueSegurancaOriginal{get;private set;}
       private EstoqueSeguranca _utilizandoEstoqueSegurancaOriginalCommited{get; set;}
        private EstoqueSeguranca _valueUtilizandoEstoqueSeguranca;
         [Column("mat_utilizando_estoque_seguranca")]
        public virtual EstoqueSeguranca UtilizandoEstoqueSeguranca
         { 
            get { return this._valueUtilizandoEstoqueSeguranca; } 
            set 
            { 
                if (this._valueUtilizandoEstoqueSeguranca == value)return;
                 this._valueUtilizandoEstoqueSeguranca = value; 
            } 
        } 

        public bool UtilizandoEstoqueSeguranca_NaoUtilizando
         { 
            get { return this._valueUtilizandoEstoqueSeguranca == BibliotecaEntidades.Base.EstoqueSeguranca.NaoUtilizando; } 
            set { if (value) this._valueUtilizandoEstoqueSeguranca = BibliotecaEntidades.Base.EstoqueSeguranca.NaoUtilizando; }
         } 

        public bool UtilizandoEstoqueSeguranca_Verde
         { 
            get { return this._valueUtilizandoEstoqueSeguranca == BibliotecaEntidades.Base.EstoqueSeguranca.Verde; } 
            set { if (value) this._valueUtilizandoEstoqueSeguranca = BibliotecaEntidades.Base.EstoqueSeguranca.Verde; }
         } 

        public bool UtilizandoEstoqueSeguranca_Amarelo
         { 
            get { return this._valueUtilizandoEstoqueSeguranca == BibliotecaEntidades.Base.EstoqueSeguranca.Amarelo; } 
            set { if (value) this._valueUtilizandoEstoqueSeguranca = BibliotecaEntidades.Base.EstoqueSeguranca.Amarelo; }
         } 

        public bool UtilizandoEstoqueSeguranca_Vermelho
         { 
            get { return this._valueUtilizandoEstoqueSeguranca == BibliotecaEntidades.Base.EstoqueSeguranca.Vermelho; } 
            set { if (value) this._valueUtilizandoEstoqueSeguranca = BibliotecaEntidades.Base.EstoqueSeguranca.Vermelho; }
         } 

       protected DateTime? _utilizandoEstoqueSegurancaDataOriginal{get;private set;}
       private DateTime? _utilizandoEstoqueSegurancaDataOriginalCommited{get; set;}
        private DateTime? _valueUtilizandoEstoqueSegurancaData;
         [Column("mat_utilizando_estoque_seguranca_data")]
        public virtual DateTime? UtilizandoEstoqueSegurancaData
         { 
            get { return this._valueUtilizandoEstoqueSegurancaData; } 
            set 
            { 
                if (this._valueUtilizandoEstoqueSegurancaData == value)return;
                 this._valueUtilizandoEstoqueSegurancaData = value; 
            } 
        } 

       protected string _imagemOriginal= null;
        private string _imagemOriginalCommited= null;
        private bool _ImagemLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool ImagemLoaded 
       { 
            get {                     return _ImagemLoaded; } 
           set 
           { 
                this._ImagemLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueImagem;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("mat_imagem")]
        public virtual byte[] Imagem
         { 
            get { 
                   if (!this.ImagemLoaded) 
                   {
                       this.LoadImagem();
                   }
                   return this._valueImagem; } 
            set 
            { 
                ImagemLoaded = true; 
                if (this._valueImagem == value)return;
                 this._valueImagem = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.CompradorClass _compradorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CompradorClass _compradorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CompradorClass _valueComprador;
        [Column("id_comprador", "comprador", "id_comprador")]
       public virtual BibliotecaEntidades.Entidades.CompradorClass Comprador
        { 
           get {                 return this._valueComprador; } 
           set 
           { 
                if (this._valueComprador == value)return;
                 this._valueComprador = value; 
           } 
       } 

       protected bool _controleValidadeOriginal{get;private set;}
       private bool _controleValidadeOriginalCommited{get; set;}
        private bool _valueControleValidade;
         [Column("mat_controle_validade")]
        public virtual bool ControleValidade
         { 
            get { return this._valueControleValidade; } 
            set 
            { 
                if (this._valueControleValidade == value)return;
                 this._valueControleValidade = value; 
            } 
        } 

       protected int? _controleValidadeMesesOriginal{get;private set;}
       private int? _controleValidadeMesesOriginalCommited{get; set;}
        private int? _valueControleValidadeMeses;
         [Column("mat_controle_validade_meses")]
        public virtual int? ControleValidadeMeses
         { 
            get { return this._valueControleValidadeMeses; } 
            set 
            { 
                if (this._valueControleValidadeMeses == value)return;
                 this._valueControleValidadeMeses = value; 
            } 
        } 

       protected double? _margemRecebimentoOriginal{get;private set;}
       private double? _margemRecebimentoOriginalCommited{get; set;}
        private double? _valueMargemRecebimento;
         [Column("mat_margem_recebimento")]
        public virtual double? MargemRecebimento
         { 
            get { return this._valueMargemRecebimento; } 
            set 
            { 
                if (this._valueMargemRecebimento == value)return;
                 this._valueMargemRecebimento = value; 
            } 
        } 

       protected string _gtinOriginal{get;private set;}
       private string _gtinOriginalCommited{get; set;}
        private string _valueGtin;
         [Column("mat_gtin")]
        public virtual string Gtin
         { 
            get { return this._valueGtin; } 
            set 
            { 
                if (this._valueGtin == value)return;
                 this._valueGtin = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("mat_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       protected double _loteMinimoOriginal{get;private set;}
       private double _loteMinimoOriginalCommited{get; set;}
        private double _valueLoteMinimo;
         [Column("mat_lote_minimo")]
        public virtual double LoteMinimo
         { 
            get { return this._valueLoteMinimo; } 
            set 
            { 
                if (this._valueLoteMinimo == value)return;
                 this._valueLoteMinimo = value; 
            } 
        } 

       private List<long> _collectionContratoFornecimentoClassMaterialOriginal;
       private List<Entidades.ContratoFornecimentoClass > _collectionContratoFornecimentoClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContratoFornecimentoClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContratoFornecimentoClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContratoFornecimentoClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContratoFornecimentoClass> _valueCollectionContratoFornecimentoClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContratoFornecimentoClass> CollectionContratoFornecimentoClassMaterial 
       { 
           get { if(!_valueCollectionContratoFornecimentoClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionContratoFornecimentoClassMaterial();}
return this._valueCollectionContratoFornecimentoClassMaterial; } 
           set 
           { 
               this._valueCollectionContratoFornecimentoClassMaterial = value; 
               this._valueCollectionContratoFornecimentoClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionDeclaracaoImportacaoAdicaoItemClassMaterialOriginal;
       private List<Entidades.DeclaracaoImportacaoAdicaoItemClass > _collectionDeclaracaoImportacaoAdicaoItemClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.DeclaracaoImportacaoAdicaoItemClass> _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.DeclaracaoImportacaoAdicaoItemClass> CollectionDeclaracaoImportacaoAdicaoItemClassMaterial 
       { 
           get { if(!_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionDeclaracaoImportacaoAdicaoItemClassMaterial();}
return this._valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterial; } 
           set 
           { 
               this._valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterial = value; 
               this._valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionEstoqueGavetaItemClassMaterialOriginal;
       private List<Entidades.EstoqueGavetaItemClass > _collectionEstoqueGavetaItemClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueGavetaItemClass> _valueCollectionEstoqueGavetaItemClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueGavetaItemClass> CollectionEstoqueGavetaItemClassMaterial 
       { 
           get { if(!_valueCollectionEstoqueGavetaItemClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueGavetaItemClassMaterial();}
return this._valueCollectionEstoqueGavetaItemClassMaterial; } 
           set 
           { 
               this._valueCollectionEstoqueGavetaItemClassMaterial = value; 
               this._valueCollectionEstoqueGavetaItemClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionFomularioRetiradaManualEstoqueClassMaterialOriginal;
       private List<Entidades.FomularioRetiradaManualEstoqueClass > _collectionFomularioRetiradaManualEstoqueClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FomularioRetiradaManualEstoqueClass> _valueCollectionFomularioRetiradaManualEstoqueClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FomularioRetiradaManualEstoqueClass> CollectionFomularioRetiradaManualEstoqueClassMaterial 
       { 
           get { if(!_valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionFomularioRetiradaManualEstoqueClassMaterial();}
return this._valueCollectionFomularioRetiradaManualEstoqueClassMaterial; } 
           set 
           { 
               this._valueCollectionFomularioRetiradaManualEstoqueClassMaterial = value; 
               this._valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraMaterialClassMaterialOriginal;
       private List<Entidades.HistoricoCompraMaterialClass > _collectionHistoricoCompraMaterialClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraMaterialClass> _valueCollectionHistoricoCompraMaterialClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraMaterialClass> CollectionHistoricoCompraMaterialClassMaterial 
       { 
           get { if(!_valueCollectionHistoricoCompraMaterialClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraMaterialClassMaterial();}
return this._valueCollectionHistoricoCompraMaterialClassMaterial; } 
           set 
           { 
               this._valueCollectionHistoricoCompraMaterialClassMaterial = value; 
               this._valueCollectionHistoricoCompraMaterialClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionKanbanAcionamentoClassMaterialOriginal;
       private List<Entidades.KanbanAcionamentoClass > _collectionKanbanAcionamentoClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.KanbanAcionamentoClass> _valueCollectionKanbanAcionamentoClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.KanbanAcionamentoClass> CollectionKanbanAcionamentoClassMaterial 
       { 
           get { if(!_valueCollectionKanbanAcionamentoClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionKanbanAcionamentoClassMaterial();}
return this._valueCollectionKanbanAcionamentoClassMaterial; } 
           set 
           { 
               this._valueCollectionKanbanAcionamentoClassMaterial = value; 
               this._valueCollectionKanbanAcionamentoClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionLoteClassMaterialOriginal;
       private List<Entidades.LoteClass > _collectionLoteClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LoteClass> _valueCollectionLoteClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LoteClass> CollectionLoteClassMaterial 
       { 
           get { if(!_valueCollectionLoteClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionLoteClassMaterial();}
return this._valueCollectionLoteClassMaterial; } 
           set 
           { 
               this._valueCollectionLoteClassMaterial = value; 
               this._valueCollectionLoteClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionMaterialFiscalClassMaterialOriginal;
       private List<Entidades.MaterialFiscalClass > _collectionMaterialFiscalClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFiscalClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFiscalClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFiscalClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialFiscalClass> _valueCollectionMaterialFiscalClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialFiscalClass> CollectionMaterialFiscalClassMaterial 
       { 
           get { if(!_valueCollectionMaterialFiscalClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialFiscalClassMaterial();}
return this._valueCollectionMaterialFiscalClassMaterial; } 
           set 
           { 
               this._valueCollectionMaterialFiscalClassMaterial = value; 
               this._valueCollectionMaterialFiscalClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionMaterialFornecedorClassMaterialOriginal;
       private List<Entidades.MaterialFornecedorClass > _collectionMaterialFornecedorClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFornecedorClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFornecedorClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFornecedorClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialFornecedorClass> _valueCollectionMaterialFornecedorClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialFornecedorClass> CollectionMaterialFornecedorClassMaterial 
       { 
           get { if(!_valueCollectionMaterialFornecedorClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialFornecedorClassMaterial();}
return this._valueCollectionMaterialFornecedorClassMaterial; } 
           set 
           { 
               this._valueCollectionMaterialFornecedorClassMaterial = value; 
               this._valueCollectionMaterialFornecedorClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoCompraItemClassMaterialOriginal;
       private List<Entidades.OrcamentoCompraItemClass > _collectionOrcamentoCompraItemClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoCompraItemClass> _valueCollectionOrcamentoCompraItemClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoCompraItemClass> CollectionOrcamentoCompraItemClassMaterial 
       { 
           get { if(!_valueCollectionOrcamentoCompraItemClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoCompraItemClassMaterial();}
return this._valueCollectionOrcamentoCompraItemClassMaterial; } 
           set 
           { 
               this._valueCollectionOrcamentoCompraItemClassMaterial = value; 
               this._valueCollectionOrcamentoCompraItemClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoMaterialClassMaterialOriginal;
       private List<Entidades.OrdemProducaoMaterialClass > _collectionOrdemProducaoMaterialClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoMaterialClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoMaterialClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoMaterialClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoMaterialClass> _valueCollectionOrdemProducaoMaterialClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoMaterialClass> CollectionOrdemProducaoMaterialClassMaterial 
       { 
           get { if(!_valueCollectionOrdemProducaoMaterialClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoMaterialClassMaterial();}
return this._valueCollectionOrdemProducaoMaterialClassMaterial; } 
           set 
           { 
               this._valueCollectionOrdemProducaoMaterialClassMaterial = value; 
               this._valueCollectionOrdemProducaoMaterialClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassMaterialOriginal;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassMaterial 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassMaterial();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassMaterial; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassMaterial = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemClassMaterialOriginal;
       private List<Entidades.PlanoCorteItemClass > _collectionPlanoCorteItemClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemClass> _valueCollectionPlanoCorteItemClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemClass> CollectionPlanoCorteItemClassMaterial 
       { 
           get { if(!_valueCollectionPlanoCorteItemClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemClassMaterial();}
return this._valueCollectionPlanoCorteItemClassMaterial; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemClassMaterial = value; 
               this._valueCollectionPlanoCorteItemClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoMaterialClassMaterialOriginal;
       private List<Entidades.ProdutoMaterialClass > _collectionProdutoMaterialClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoMaterialClass> _valueCollectionProdutoMaterialClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoMaterialClass> CollectionProdutoMaterialClassMaterial 
       { 
           get { if(!_valueCollectionProdutoMaterialClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoMaterialClassMaterial();}
return this._valueCollectionProdutoMaterialClassMaterial; } 
           set 
           { 
               this._valueCollectionProdutoMaterialClassMaterial = value; 
               this._valueCollectionProdutoMaterialClassMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionSolicitacaoCompraClassMaterialOriginal;
       private List<Entidades.SolicitacaoCompraClass > _collectionSolicitacaoCompraClassMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.SolicitacaoCompraClass> _valueCollectionSolicitacaoCompraClassMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.SolicitacaoCompraClass> CollectionSolicitacaoCompraClassMaterial 
       { 
           get { if(!_valueCollectionSolicitacaoCompraClassMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionSolicitacaoCompraClassMaterial();}
return this._valueCollectionSolicitacaoCompraClassMaterial; } 
           set 
           { 
               this._valueCollectionSolicitacaoCompraClassMaterial = value; 
               this._valueCollectionSolicitacaoCompraClassMaterialLoaded = true; 
           } 
       } 

        public MaterialBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.PoliticaEstoque = (PoliticaEstoque)2;
           this.LotePadrao = 1;
           this.Verde = 0;
           this.Amarelo = 0;
           this.Vermelho = 0;
           this.UnidadesPorUnCompra = 1;
           this.LeadTimeCompra = 0;
           this.ImpedirSolicitacaoAuto = false;
           this.UtilizandoEstoqueSeguranca = (EstoqueSeguranca)0;
           this.ControleValidade = false;
           this.Ativo = true;
           this.LoteMinimo = 1;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static MaterialClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MaterialClass) GetEntity(typeof(MaterialClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionContratoFornecimentoClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContratoFornecimentoClassMaterialChanged = true;
                  _valueCollectionContratoFornecimentoClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContratoFornecimentoClassMaterialChanged = true; 
                  _valueCollectionContratoFornecimentoClassMaterialCommitedChanged = true;
                 foreach (Entidades.ContratoFornecimentoClass item in e.OldItems) 
                 { 
                     _collectionContratoFornecimentoClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContratoFornecimentoClassMaterialChanged = true; 
                  _valueCollectionContratoFornecimentoClassMaterialCommitedChanged = true;
                 foreach (Entidades.ContratoFornecimentoClass item in _valueCollectionContratoFornecimentoClassMaterial) 
                 { 
                     _collectionContratoFornecimentoClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContratoFornecimentoClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.ContratoFornecimentoClass> oc;
                _valueCollectionContratoFornecimentoClassMaterialChanged = false;
                 _valueCollectionContratoFornecimentoClassMaterialCommitedChanged = false;
                _collectionContratoFornecimentoClassMaterialRemovidos = new List<Entidades.ContratoFornecimentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContratoFornecimentoClass>();
                }
                else{ 
                   Entidades.ContratoFornecimentoClass search = new Entidades.ContratoFornecimentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContratoFornecimentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.ContratoFornecimentoClass>().ToList());
                 }
                 _valueCollectionContratoFornecimentoClassMaterial = new BindingList<Entidades.ContratoFornecimentoClass>(oc); 
                 _collectionContratoFornecimentoClassMaterialOriginal= (from a in _valueCollectionContratoFornecimentoClassMaterial select a.ID).ToList();
                 _valueCollectionContratoFornecimentoClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionContratoFornecimentoClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContratoFornecimentoClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionDeclaracaoImportacaoAdicaoItemClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialChanged = true;
                  _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialChanged = true; 
                  _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialCommitedChanged = true;
                 foreach (Entidades.DeclaracaoImportacaoAdicaoItemClass item in e.OldItems) 
                 { 
                     _collectionDeclaracaoImportacaoAdicaoItemClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialChanged = true; 
                  _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialCommitedChanged = true;
                 foreach (Entidades.DeclaracaoImportacaoAdicaoItemClass item in _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterial) 
                 { 
                     _collectionDeclaracaoImportacaoAdicaoItemClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionDeclaracaoImportacaoAdicaoItemClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.DeclaracaoImportacaoAdicaoItemClass> oc;
                _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialChanged = false;
                 _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialCommitedChanged = false;
                _collectionDeclaracaoImportacaoAdicaoItemClassMaterialRemovidos = new List<Entidades.DeclaracaoImportacaoAdicaoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.DeclaracaoImportacaoAdicaoItemClass>();
                }
                else{ 
                   Entidades.DeclaracaoImportacaoAdicaoItemClass search = new Entidades.DeclaracaoImportacaoAdicaoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.DeclaracaoImportacaoAdicaoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this)                    }                       ).Cast<Entidades.DeclaracaoImportacaoAdicaoItemClass>().ToList());
                 }
                 _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterial = new BindingList<Entidades.DeclaracaoImportacaoAdicaoItemClass>(oc); 
                 _collectionDeclaracaoImportacaoAdicaoItemClassMaterialOriginal= (from a in _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterial select a.ID).ToList();
                 _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionDeclaracaoImportacaoAdicaoItemClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionDeclaracaoImportacaoAdicaoItemClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionEstoqueGavetaItemClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueGavetaItemClassMaterialChanged = true;
                  _valueCollectionEstoqueGavetaItemClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueGavetaItemClassMaterialChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassMaterialCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in e.OldItems) 
                 { 
                     _collectionEstoqueGavetaItemClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueGavetaItemClassMaterialChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassMaterialCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in _valueCollectionEstoqueGavetaItemClassMaterial) 
                 { 
                     _collectionEstoqueGavetaItemClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueGavetaItemClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueGavetaItemClass> oc;
                _valueCollectionEstoqueGavetaItemClassMaterialChanged = false;
                 _valueCollectionEstoqueGavetaItemClassMaterialCommitedChanged = false;
                _collectionEstoqueGavetaItemClassMaterialRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueGavetaItemClass>();
                }
                else{ 
                   Entidades.EstoqueGavetaItemClass search = new Entidades.EstoqueGavetaItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueGavetaItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.EstoqueGavetaItemClass>().ToList());
                 }
                 _valueCollectionEstoqueGavetaItemClassMaterial = new BindingList<Entidades.EstoqueGavetaItemClass>(oc); 
                 _collectionEstoqueGavetaItemClassMaterialOriginal= (from a in _valueCollectionEstoqueGavetaItemClassMaterial select a.ID).ToList();
                 _valueCollectionEstoqueGavetaItemClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueGavetaItemClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueGavetaItemClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFomularioRetiradaManualEstoqueClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassMaterialChanged = true;
                  _valueCollectionFomularioRetiradaManualEstoqueClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassMaterialChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassMaterialCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in e.OldItems) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassMaterialChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassMaterialCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in _valueCollectionFomularioRetiradaManualEstoqueClassMaterial) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFomularioRetiradaManualEstoqueClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass> oc;
                _valueCollectionFomularioRetiradaManualEstoqueClassMaterialChanged = false;
                 _valueCollectionFomularioRetiradaManualEstoqueClassMaterialCommitedChanged = false;
                _collectionFomularioRetiradaManualEstoqueClassMaterialRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>();
                }
                else{ 
                   Entidades.FomularioRetiradaManualEstoqueClass search = new Entidades.FomularioRetiradaManualEstoqueClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.FomularioRetiradaManualEstoqueClass>().ToList());
                 }
                 _valueCollectionFomularioRetiradaManualEstoqueClassMaterial = new BindingList<Entidades.FomularioRetiradaManualEstoqueClass>(oc); 
                 _collectionFomularioRetiradaManualEstoqueClassMaterialOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassMaterial select a.ID).ToList();
                 _valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionFomularioRetiradaManualEstoqueClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFomularioRetiradaManualEstoqueClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraMaterialClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraMaterialClassMaterialChanged = true;
                  _valueCollectionHistoricoCompraMaterialClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraMaterialClassMaterialChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassMaterialCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraMaterialClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraMaterialClassMaterialChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassMaterialCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in _valueCollectionHistoricoCompraMaterialClassMaterial) 
                 { 
                     _collectionHistoricoCompraMaterialClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraMaterialClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraMaterialClass> oc;
                _valueCollectionHistoricoCompraMaterialClassMaterialChanged = false;
                 _valueCollectionHistoricoCompraMaterialClassMaterialCommitedChanged = false;
                _collectionHistoricoCompraMaterialClassMaterialRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraMaterialClass>();
                }
                else{ 
                   Entidades.HistoricoCompraMaterialClass search = new Entidades.HistoricoCompraMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.HistoricoCompraMaterialClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraMaterialClassMaterial = new BindingList<Entidades.HistoricoCompraMaterialClass>(oc); 
                 _collectionHistoricoCompraMaterialClassMaterialOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassMaterial select a.ID).ToList();
                 _valueCollectionHistoricoCompraMaterialClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraMaterialClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraMaterialClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionKanbanAcionamentoClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionKanbanAcionamentoClassMaterialChanged = true;
                  _valueCollectionKanbanAcionamentoClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionKanbanAcionamentoClassMaterialChanged = true; 
                  _valueCollectionKanbanAcionamentoClassMaterialCommitedChanged = true;
                 foreach (Entidades.KanbanAcionamentoClass item in e.OldItems) 
                 { 
                     _collectionKanbanAcionamentoClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionKanbanAcionamentoClassMaterialChanged = true; 
                  _valueCollectionKanbanAcionamentoClassMaterialCommitedChanged = true;
                 foreach (Entidades.KanbanAcionamentoClass item in _valueCollectionKanbanAcionamentoClassMaterial) 
                 { 
                     _collectionKanbanAcionamentoClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionKanbanAcionamentoClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.KanbanAcionamentoClass> oc;
                _valueCollectionKanbanAcionamentoClassMaterialChanged = false;
                 _valueCollectionKanbanAcionamentoClassMaterialCommitedChanged = false;
                _collectionKanbanAcionamentoClassMaterialRemovidos = new List<Entidades.KanbanAcionamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.KanbanAcionamentoClass>();
                }
                else{ 
                   Entidades.KanbanAcionamentoClass search = new Entidades.KanbanAcionamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.KanbanAcionamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.KanbanAcionamentoClass>().ToList());
                 }
                 _valueCollectionKanbanAcionamentoClassMaterial = new BindingList<Entidades.KanbanAcionamentoClass>(oc); 
                 _collectionKanbanAcionamentoClassMaterialOriginal= (from a in _valueCollectionKanbanAcionamentoClassMaterial select a.ID).ToList();
                 _valueCollectionKanbanAcionamentoClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionKanbanAcionamentoClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionKanbanAcionamentoClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionLoteClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLoteClassMaterialChanged = true;
                  _valueCollectionLoteClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLoteClassMaterialChanged = true; 
                  _valueCollectionLoteClassMaterialCommitedChanged = true;
                 foreach (Entidades.LoteClass item in e.OldItems) 
                 { 
                     _collectionLoteClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLoteClassMaterialChanged = true; 
                  _valueCollectionLoteClassMaterialCommitedChanged = true;
                 foreach (Entidades.LoteClass item in _valueCollectionLoteClassMaterial) 
                 { 
                     _collectionLoteClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLoteClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.LoteClass> oc;
                _valueCollectionLoteClassMaterialChanged = false;
                 _valueCollectionLoteClassMaterialCommitedChanged = false;
                _collectionLoteClassMaterialRemovidos = new List<Entidades.LoteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LoteClass>();
                }
                else{ 
                   Entidades.LoteClass search = new Entidades.LoteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LoteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.LoteClass>().ToList());
                 }
                 _valueCollectionLoteClassMaterial = new BindingList<Entidades.LoteClass>(oc); 
                 _collectionLoteClassMaterialOriginal= (from a in _valueCollectionLoteClassMaterial select a.ID).ToList();
                 _valueCollectionLoteClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionLoteClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLoteClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMaterialFiscalClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialFiscalClassMaterialChanged = true;
                  _valueCollectionMaterialFiscalClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialFiscalClassMaterialChanged = true; 
                  _valueCollectionMaterialFiscalClassMaterialCommitedChanged = true;
                 foreach (Entidades.MaterialFiscalClass item in e.OldItems) 
                 { 
                     _collectionMaterialFiscalClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialFiscalClassMaterialChanged = true; 
                  _valueCollectionMaterialFiscalClassMaterialCommitedChanged = true;
                 foreach (Entidades.MaterialFiscalClass item in _valueCollectionMaterialFiscalClassMaterial) 
                 { 
                     _collectionMaterialFiscalClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialFiscalClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialFiscalClass> oc;
                _valueCollectionMaterialFiscalClassMaterialChanged = false;
                 _valueCollectionMaterialFiscalClassMaterialCommitedChanged = false;
                _collectionMaterialFiscalClassMaterialRemovidos = new List<Entidades.MaterialFiscalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialFiscalClass>();
                }
                else{ 
                   Entidades.MaterialFiscalClass search = new Entidades.MaterialFiscalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialFiscalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.MaterialFiscalClass>().ToList());
                 }
                 _valueCollectionMaterialFiscalClassMaterial = new BindingList<Entidades.MaterialFiscalClass>(oc); 
                 _collectionMaterialFiscalClassMaterialOriginal= (from a in _valueCollectionMaterialFiscalClassMaterial select a.ID).ToList();
                 _valueCollectionMaterialFiscalClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionMaterialFiscalClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialFiscalClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMaterialFornecedorClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialFornecedorClassMaterialChanged = true;
                  _valueCollectionMaterialFornecedorClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialFornecedorClassMaterialChanged = true; 
                  _valueCollectionMaterialFornecedorClassMaterialCommitedChanged = true;
                 foreach (Entidades.MaterialFornecedorClass item in e.OldItems) 
                 { 
                     _collectionMaterialFornecedorClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialFornecedorClassMaterialChanged = true; 
                  _valueCollectionMaterialFornecedorClassMaterialCommitedChanged = true;
                 foreach (Entidades.MaterialFornecedorClass item in _valueCollectionMaterialFornecedorClassMaterial) 
                 { 
                     _collectionMaterialFornecedorClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialFornecedorClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialFornecedorClass> oc;
                _valueCollectionMaterialFornecedorClassMaterialChanged = false;
                 _valueCollectionMaterialFornecedorClassMaterialCommitedChanged = false;
                _collectionMaterialFornecedorClassMaterialRemovidos = new List<Entidades.MaterialFornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialFornecedorClass>();
                }
                else{ 
                   Entidades.MaterialFornecedorClass search = new Entidades.MaterialFornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialFornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.MaterialFornecedorClass>().ToList());
                 }
                 _valueCollectionMaterialFornecedorClassMaterial = new BindingList<Entidades.MaterialFornecedorClass>(oc); 
                 _collectionMaterialFornecedorClassMaterialOriginal= (from a in _valueCollectionMaterialFornecedorClassMaterial select a.ID).ToList();
                 _valueCollectionMaterialFornecedorClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionMaterialFornecedorClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialFornecedorClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoCompraItemClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoCompraItemClassMaterialChanged = true;
                  _valueCollectionOrcamentoCompraItemClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoCompraItemClassMaterialChanged = true; 
                  _valueCollectionOrcamentoCompraItemClassMaterialCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoCompraItemClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoCompraItemClassMaterialChanged = true; 
                  _valueCollectionOrcamentoCompraItemClassMaterialCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraItemClass item in _valueCollectionOrcamentoCompraItemClassMaterial) 
                 { 
                     _collectionOrcamentoCompraItemClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoCompraItemClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoCompraItemClass> oc;
                _valueCollectionOrcamentoCompraItemClassMaterialChanged = false;
                 _valueCollectionOrcamentoCompraItemClassMaterialCommitedChanged = false;
                _collectionOrcamentoCompraItemClassMaterialRemovidos = new List<Entidades.OrcamentoCompraItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoCompraItemClass>();
                }
                else{ 
                   Entidades.OrcamentoCompraItemClass search = new Entidades.OrcamentoCompraItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoCompraItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.OrcamentoCompraItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoCompraItemClassMaterial = new BindingList<Entidades.OrcamentoCompraItemClass>(oc); 
                 _collectionOrcamentoCompraItemClassMaterialOriginal= (from a in _valueCollectionOrcamentoCompraItemClassMaterial select a.ID).ToList();
                 _valueCollectionOrcamentoCompraItemClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoCompraItemClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoCompraItemClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoMaterialClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoMaterialClassMaterialChanged = true;
                  _valueCollectionOrdemProducaoMaterialClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoMaterialClassMaterialChanged = true; 
                  _valueCollectionOrdemProducaoMaterialClassMaterialCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoMaterialClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoMaterialClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoMaterialClassMaterialChanged = true; 
                  _valueCollectionOrdemProducaoMaterialClassMaterialCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoMaterialClass item in _valueCollectionOrdemProducaoMaterialClassMaterial) 
                 { 
                     _collectionOrdemProducaoMaterialClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoMaterialClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoMaterialClass> oc;
                _valueCollectionOrdemProducaoMaterialClassMaterialChanged = false;
                 _valueCollectionOrdemProducaoMaterialClassMaterialCommitedChanged = false;
                _collectionOrdemProducaoMaterialClassMaterialRemovidos = new List<Entidades.OrdemProducaoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoMaterialClass>();
                }
                else{ 
                   Entidades.OrdemProducaoMaterialClass search = new Entidades.OrdemProducaoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.OrdemProducaoMaterialClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoMaterialClassMaterial = new BindingList<Entidades.OrdemProducaoMaterialClass>(oc); 
                 _collectionOrdemProducaoMaterialClassMaterialOriginal= (from a in _valueCollectionOrdemProducaoMaterialClassMaterial select a.ID).ToList();
                 _valueCollectionOrdemProducaoMaterialClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoMaterialClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoMaterialClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassMaterialChanged = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassMaterialChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassMaterialCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassMaterialChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassMaterialCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassMaterial) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassMaterialChanged = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassMaterialCommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassMaterialRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassMaterial = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassMaterialOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassMaterial select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemClassMaterialChanged = true;
                  _valueCollectionPlanoCorteItemClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemClassMaterialChanged = true; 
                  _valueCollectionPlanoCorteItemClassMaterialCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemClassMaterialChanged = true; 
                  _valueCollectionPlanoCorteItemClassMaterialCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in _valueCollectionPlanoCorteItemClassMaterial) 
                 { 
                     _collectionPlanoCorteItemClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemClass> oc;
                _valueCollectionPlanoCorteItemClassMaterialChanged = false;
                 _valueCollectionPlanoCorteItemClassMaterialCommitedChanged = false;
                _collectionPlanoCorteItemClassMaterialRemovidos = new List<Entidades.PlanoCorteItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemClass search = new Entidades.PlanoCorteItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this)                    }                       ).Cast<Entidades.PlanoCorteItemClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemClassMaterial = new BindingList<Entidades.PlanoCorteItemClass>(oc); 
                 _collectionPlanoCorteItemClassMaterialOriginal= (from a in _valueCollectionPlanoCorteItemClassMaterial select a.ID).ToList();
                 _valueCollectionPlanoCorteItemClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoMaterialClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoMaterialClassMaterialChanged = true;
                  _valueCollectionProdutoMaterialClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoMaterialClassMaterialChanged = true; 
                  _valueCollectionProdutoMaterialClassMaterialCommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in e.OldItems) 
                 { 
                     _collectionProdutoMaterialClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoMaterialClassMaterialChanged = true; 
                  _valueCollectionProdutoMaterialClassMaterialCommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in _valueCollectionProdutoMaterialClassMaterial) 
                 { 
                     _collectionProdutoMaterialClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoMaterialClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoMaterialClass> oc;
                _valueCollectionProdutoMaterialClassMaterialChanged = false;
                 _valueCollectionProdutoMaterialClassMaterialCommitedChanged = false;
                _collectionProdutoMaterialClassMaterialRemovidos = new List<Entidades.ProdutoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoMaterialClass>();
                }
                else{ 
                   Entidades.ProdutoMaterialClass search = new Entidades.ProdutoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.ProdutoMaterialClass>().ToList());
                 }
                 _valueCollectionProdutoMaterialClassMaterial = new BindingList<Entidades.ProdutoMaterialClass>(oc); 
                 _collectionProdutoMaterialClassMaterialOriginal= (from a in _valueCollectionProdutoMaterialClassMaterial select a.ID).ToList();
                 _valueCollectionProdutoMaterialClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionProdutoMaterialClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoMaterialClassMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionSolicitacaoCompraClassMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionSolicitacaoCompraClassMaterialChanged = true;
                  _valueCollectionSolicitacaoCompraClassMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionSolicitacaoCompraClassMaterialChanged = true; 
                  _valueCollectionSolicitacaoCompraClassMaterialCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in e.OldItems) 
                 { 
                     _collectionSolicitacaoCompraClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionSolicitacaoCompraClassMaterialChanged = true; 
                  _valueCollectionSolicitacaoCompraClassMaterialCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in _valueCollectionSolicitacaoCompraClassMaterial) 
                 { 
                     _collectionSolicitacaoCompraClassMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionSolicitacaoCompraClassMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.SolicitacaoCompraClass> oc;
                _valueCollectionSolicitacaoCompraClassMaterialChanged = false;
                 _valueCollectionSolicitacaoCompraClassMaterialCommitedChanged = false;
                _collectionSolicitacaoCompraClassMaterialRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.SolicitacaoCompraClass>();
                }
                else{ 
                   Entidades.SolicitacaoCompraClass search = new Entidades.SolicitacaoCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.SolicitacaoCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Material", this),                     }                       ).Cast<Entidades.SolicitacaoCompraClass>().ToList());
                 }
                 _valueCollectionSolicitacaoCompraClassMaterial = new BindingList<Entidades.SolicitacaoCompraClass>(oc); 
                 _collectionSolicitacaoCompraClassMaterialOriginal= (from a in _valueCollectionSolicitacaoCompraClassMaterial select a.ID).ToList();
                 _valueCollectionSolicitacaoCompraClassMaterialLoaded = true;
                 oc.CollectionChanged += CollectionSolicitacaoCompraClassMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionSolicitacaoCompraClassMaterial+"\r\n" + e.Message, e);
            }
         } 
private void LoadImagem()
        {
            try
            {
                if (this.ID == -1)
                {

                    ImagemLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT mat_imagem FROM material WHERE id_material = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueImagem = (byte[]) tmp;
                }
                if (this._valueImagem != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _imagemOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueImagem));
                     }
                  } 
                  else 
                  { 
                        _imagemOriginal = null ;
                  } 
                ImagemLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroImagemLoad + "\r\n" + e.Message, e);
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
                    "  public.material  " +
                    "WHERE " +
                    "  id_material = :id";
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
                        "  public.material   " +
                        "SET  " + 
                        "  mat_descricao = :mat_descricao, " + 
                        "  mat_medida = :mat_medida, " + 
                        "  mat_medida_largura = :mat_medida_largura, " + 
                        "  mat_medida_comprimento = :mat_medida_comprimento, " + 
                        "  mat_codigo = :mat_codigo, " + 
                        "  id_unidade_medida = :id_unidade_medida, " + 
                        "  id_familia_material = :id_familia_material, " + 
                        "  id_acabamento = :id_acabamento, " + 
                        "  mat_politica_estoque = :mat_politica_estoque, " + 
                        "  mat_codigo_antigo = :mat_codigo_antigo, " + 
                        "  mat_descricao_adicional = :mat_descricao_adicional, " + 
                        "  mat_lote_padrao = :mat_lote_padrao, " + 
                        "  mat_verde = :mat_verde, " + 
                        "  mat_amarelo = :mat_amarelo, " + 
                        "  mat_vermelho = :mat_vermelho, " + 
                        "  id_unidade_medida_compra = :id_unidade_medida_compra, " + 
                        "  mat_unidades_por_un_compra = :mat_unidades_por_un_compra, " + 
                        "  mat_lead_time_compra = :mat_lead_time_compra, " + 
                        "  mat_marcas_homologadas = :mat_marcas_homologadas, " + 
                        "  mat_impedir_solicitacao_auto = :mat_impedir_solicitacao_auto, " + 
                        "  mat_ultima_revisao = :mat_ultima_revisao, " + 
                        "  mat_ultima_revisao_data = :mat_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  mat_utilizando_estoque_seguranca = :mat_utilizando_estoque_seguranca, " + 
                        "  mat_utilizando_estoque_seguranca_data = :mat_utilizando_estoque_seguranca_data, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  mat_imagem = :mat_imagem, " + 
                        "  id_comprador = :id_comprador, " + 
                        "  mat_controle_validade = :mat_controle_validade, " + 
                        "  mat_controle_validade_meses = :mat_controle_validade_meses, " + 
                        "  mat_margem_recebimento = :mat_margem_recebimento, " + 
                        "  mat_gtin = :mat_gtin, " + 
                        "  mat_ativo = :mat_ativo, " + 
                        "  mat_lote_minimo = :mat_lote_minimo "+
                        "WHERE  " +
                        "  id_material = :id " +
                        "RETURNING id_material;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.material " +
                        "( " +
                        "  mat_descricao , " + 
                        "  mat_medida , " + 
                        "  mat_medida_largura , " + 
                        "  mat_medida_comprimento , " + 
                        "  mat_codigo , " + 
                        "  id_unidade_medida , " + 
                        "  id_familia_material , " + 
                        "  id_acabamento , " + 
                        "  mat_politica_estoque , " + 
                        "  mat_codigo_antigo , " + 
                        "  mat_descricao_adicional , " + 
                        "  mat_lote_padrao , " + 
                        "  mat_verde , " + 
                        "  mat_amarelo , " + 
                        "  mat_vermelho , " + 
                        "  id_unidade_medida_compra , " + 
                        "  mat_unidades_por_un_compra , " + 
                        "  mat_lead_time_compra , " + 
                        "  mat_marcas_homologadas , " + 
                        "  mat_impedir_solicitacao_auto , " + 
                        "  mat_ultima_revisao , " + 
                        "  mat_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  mat_utilizando_estoque_seguranca , " + 
                        "  mat_utilizando_estoque_seguranca_data , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  mat_imagem , " + 
                        "  id_comprador , " + 
                        "  mat_controle_validade , " + 
                        "  mat_controle_validade_meses , " + 
                        "  mat_margem_recebimento , " + 
                        "  mat_gtin , " + 
                        "  mat_ativo , " + 
                        "  mat_lote_minimo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :mat_descricao , " + 
                        "  :mat_medida , " + 
                        "  :mat_medida_largura , " + 
                        "  :mat_medida_comprimento , " + 
                        "  :mat_codigo , " + 
                        "  :id_unidade_medida , " + 
                        "  :id_familia_material , " + 
                        "  :id_acabamento , " + 
                        "  :mat_politica_estoque , " + 
                        "  :mat_codigo_antigo , " + 
                        "  :mat_descricao_adicional , " + 
                        "  :mat_lote_padrao , " + 
                        "  :mat_verde , " + 
                        "  :mat_amarelo , " + 
                        "  :mat_vermelho , " + 
                        "  :id_unidade_medida_compra , " + 
                        "  :mat_unidades_por_un_compra , " + 
                        "  :mat_lead_time_compra , " + 
                        "  :mat_marcas_homologadas , " + 
                        "  :mat_impedir_solicitacao_auto , " + 
                        "  :mat_ultima_revisao , " + 
                        "  :mat_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :mat_utilizando_estoque_seguranca , " + 
                        "  :mat_utilizando_estoque_seguranca_data , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :mat_imagem , " + 
                        "  :id_comprador , " + 
                        "  :mat_controle_validade , " + 
                        "  :mat_controle_validade_meses , " + 
                        "  :mat_margem_recebimento , " + 
                        "  :mat_gtin , " + 
                        "  :mat_ativo , " + 
                        "  :mat_lote_minimo  "+
                        ")RETURNING id_material;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_medida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Medida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_medida_largura", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MedidaLargura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_medida_comprimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MedidaComprimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedida==null ? (object) DBNull.Value : this.UnidadeMedida.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_familia_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FamiliaMaterial==null ? (object) DBNull.Value : this.FamiliaMaterial.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acabamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Acabamento==null ? (object) DBNull.Value : this.Acabamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_politica_estoque", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.PoliticaEstoque);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_codigo_antigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoAntigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_descricao_adicional", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoAdicional ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_lote_padrao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LotePadrao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_verde", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Verde ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_amarelo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Amarelo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_vermelho", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Vermelho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaCompra==null ? (object) DBNull.Value : this.UnidadeMedidaCompra.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_unidades_por_un_compra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UnidadesPorUnCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_lead_time_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LeadTimeCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_marcas_homologadas", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MarcasHomologadas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_impedir_solicitacao_auto", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpedirSolicitacaoAuto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_utilizando_estoque_seguranca", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.UtilizandoEstoqueSeguranca);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_utilizando_estoque_seguranca_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UtilizandoEstoqueSegurancaData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_imagem", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Imagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_comprador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Comprador==null ? (object) DBNull.Value : this.Comprador.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_controle_validade", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ControleValidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_controle_validade_meses", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ControleValidadeMeses ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_margem_recebimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MargemRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_gtin", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Gtin ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mat_lote_minimo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LoteMinimo ?? DBNull.Value;

 
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
 if (CollectionContratoFornecimentoClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContratoFornecimentoClassMaterial+"\r\n";
                foreach (Entidades.ContratoFornecimentoClass tmp in CollectionContratoFornecimentoClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionDeclaracaoImportacaoAdicaoItemClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionDeclaracaoImportacaoAdicaoItemClassMaterial+"\r\n";
                foreach (Entidades.DeclaracaoImportacaoAdicaoItemClass tmp in CollectionDeclaracaoImportacaoAdicaoItemClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionEstoqueGavetaItemClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueGavetaItemClassMaterial+"\r\n";
                foreach (Entidades.EstoqueGavetaItemClass tmp in CollectionEstoqueGavetaItemClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFomularioRetiradaManualEstoqueClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassMaterial+"\r\n";
                foreach (Entidades.FomularioRetiradaManualEstoqueClass tmp in CollectionFomularioRetiradaManualEstoqueClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraMaterialClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraMaterialClassMaterial+"\r\n";
                foreach (Entidades.HistoricoCompraMaterialClass tmp in CollectionHistoricoCompraMaterialClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionKanbanAcionamentoClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionKanbanAcionamentoClassMaterial+"\r\n";
                foreach (Entidades.KanbanAcionamentoClass tmp in CollectionKanbanAcionamentoClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionLoteClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLoteClassMaterial+"\r\n";
                foreach (Entidades.LoteClass tmp in CollectionLoteClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMaterialFiscalClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialFiscalClassMaterial+"\r\n";
                foreach (Entidades.MaterialFiscalClass tmp in CollectionMaterialFiscalClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMaterialFornecedorClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialFornecedorClassMaterial+"\r\n";
                foreach (Entidades.MaterialFornecedorClass tmp in CollectionMaterialFornecedorClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoCompraItemClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoCompraItemClassMaterial+"\r\n";
                foreach (Entidades.OrcamentoCompraItemClass tmp in CollectionOrcamentoCompraItemClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoMaterialClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoMaterialClassMaterial+"\r\n";
                foreach (Entidades.OrdemProducaoMaterialClass tmp in CollectionOrdemProducaoMaterialClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassMaterial+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemClassMaterial+"\r\n";
                foreach (Entidades.PlanoCorteItemClass tmp in CollectionPlanoCorteItemClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoMaterialClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassMaterial+"\r\n";
                foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionSolicitacaoCompraClassMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionSolicitacaoCompraClassMaterial+"\r\n";
                foreach (Entidades.SolicitacaoCompraClass tmp in CollectionSolicitacaoCompraClassMaterial)
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
        public static MaterialClass CopiarEntidade(MaterialClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MaterialClass toRet = new MaterialClass(usuario,conn);
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Medida= entidadeCopiar.Medida;
 toRet.MedidaLargura= entidadeCopiar.MedidaLargura;
 toRet.MedidaComprimento= entidadeCopiar.MedidaComprimento;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.UnidadeMedida= entidadeCopiar.UnidadeMedida;
 toRet.FamiliaMaterial= entidadeCopiar.FamiliaMaterial;
 toRet.Acabamento= entidadeCopiar.Acabamento;
 toRet.PoliticaEstoque= entidadeCopiar.PoliticaEstoque;
 toRet.CodigoAntigo= entidadeCopiar.CodigoAntigo;
 toRet.DescricaoAdicional= entidadeCopiar.DescricaoAdicional;
 toRet.LotePadrao= entidadeCopiar.LotePadrao;
 toRet.Verde= entidadeCopiar.Verde;
 toRet.Amarelo= entidadeCopiar.Amarelo;
 toRet.Vermelho= entidadeCopiar.Vermelho;
 toRet.UnidadeMedidaCompra= entidadeCopiar.UnidadeMedidaCompra;
 toRet.UnidadesPorUnCompra= entidadeCopiar.UnidadesPorUnCompra;
 toRet.LeadTimeCompra= entidadeCopiar.LeadTimeCompra;
 toRet.MarcasHomologadas= entidadeCopiar.MarcasHomologadas;
 toRet.ImpedirSolicitacaoAuto= entidadeCopiar.ImpedirSolicitacaoAuto;
 toRet.UtilizandoEstoqueSeguranca= entidadeCopiar.UtilizandoEstoqueSeguranca;
 toRet.UtilizandoEstoqueSegurancaData= entidadeCopiar.UtilizandoEstoqueSegurancaData;
 toRet.Imagem= entidadeCopiar.Imagem;
 toRet.Comprador= entidadeCopiar.Comprador;
 toRet.ControleValidade= entidadeCopiar.ControleValidade;
 toRet.ControleValidadeMeses= entidadeCopiar.ControleValidadeMeses;
 toRet.MargemRecebimento= entidadeCopiar.MargemRecebimento;
 toRet.Gtin= entidadeCopiar.Gtin;
 toRet.Ativo= entidadeCopiar.Ativo;
 toRet.LoteMinimo= entidadeCopiar.LoteMinimo;

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
       _politicaEstoqueOriginal = PoliticaEstoque;
       _politicaEstoqueOriginalCommited = _politicaEstoqueOriginal;
       _codigoAntigoOriginal = CodigoAntigo;
       _codigoAntigoOriginalCommited = _codigoAntigoOriginal;
       _descricaoAdicionalOriginal = DescricaoAdicional;
       _descricaoAdicionalOriginalCommited = _descricaoAdicionalOriginal;
       _lotePadraoOriginal = LotePadrao;
       _lotePadraoOriginalCommited = _lotePadraoOriginal;
       _verdeOriginal = Verde;
       _verdeOriginalCommited = _verdeOriginal;
       _amareloOriginal = Amarelo;
       _amareloOriginalCommited = _amareloOriginal;
       _vermelhoOriginal = Vermelho;
       _vermelhoOriginalCommited = _vermelhoOriginal;
       _unidadeMedidaCompraOriginal = UnidadeMedidaCompra;
       _unidadeMedidaCompraOriginalCommited = _unidadeMedidaCompraOriginal;
       _unidadesPorUnCompraOriginal = UnidadesPorUnCompra;
       _unidadesPorUnCompraOriginalCommited = _unidadesPorUnCompraOriginal;
       _leadTimeCompraOriginal = LeadTimeCompra;
       _leadTimeCompraOriginalCommited = _leadTimeCompraOriginal;
       _marcasHomologadasOriginal = MarcasHomologadas;
       _marcasHomologadasOriginalCommited = _marcasHomologadasOriginal;
       _impedirSolicitacaoAutoOriginal = ImpedirSolicitacaoAuto;
       _impedirSolicitacaoAutoOriginalCommited = _impedirSolicitacaoAutoOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _utilizandoEstoqueSegurancaOriginal = UtilizandoEstoqueSeguranca;
       _utilizandoEstoqueSegurancaOriginalCommited = _utilizandoEstoqueSegurancaOriginal;
       _utilizandoEstoqueSegurancaDataOriginal = UtilizandoEstoqueSegurancaData;
       _utilizandoEstoqueSegurancaDataOriginalCommited = _utilizandoEstoqueSegurancaDataOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _compradorOriginal = Comprador;
       _compradorOriginalCommited = _compradorOriginal;
       _controleValidadeOriginal = ControleValidade;
       _controleValidadeOriginalCommited = _controleValidadeOriginal;
       _controleValidadeMesesOriginal = ControleValidadeMeses;
       _controleValidadeMesesOriginalCommited = _controleValidadeMesesOriginal;
       _margemRecebimentoOriginal = MargemRecebimento;
       _margemRecebimentoOriginalCommited = _margemRecebimentoOriginal;
       _gtinOriginal = Gtin;
       _gtinOriginalCommited = _gtinOriginal;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;
       _loteMinimoOriginal = LoteMinimo;
       _loteMinimoOriginalCommited = _loteMinimoOriginal;

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
       _politicaEstoqueOriginalCommited = PoliticaEstoque;
       _codigoAntigoOriginalCommited = CodigoAntigo;
       _descricaoAdicionalOriginalCommited = DescricaoAdicional;
       _lotePadraoOriginalCommited = LotePadrao;
       _verdeOriginalCommited = Verde;
       _amareloOriginalCommited = Amarelo;
       _vermelhoOriginalCommited = Vermelho;
       _unidadeMedidaCompraOriginalCommited = UnidadeMedidaCompra;
       _unidadesPorUnCompraOriginalCommited = UnidadesPorUnCompra;
       _leadTimeCompraOriginalCommited = LeadTimeCompra;
       _marcasHomologadasOriginalCommited = MarcasHomologadas;
       _impedirSolicitacaoAutoOriginalCommited = ImpedirSolicitacaoAuto;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _utilizandoEstoqueSegurancaOriginalCommited = UtilizandoEstoqueSeguranca;
       _utilizandoEstoqueSegurancaDataOriginalCommited = UtilizandoEstoqueSegurancaData;
       _versionOriginalCommited = Version;
       _compradorOriginalCommited = Comprador;
       _controleValidadeOriginalCommited = ControleValidade;
       _controleValidadeMesesOriginalCommited = ControleValidadeMeses;
       _margemRecebimentoOriginalCommited = MargemRecebimento;
       _gtinOriginalCommited = Gtin;
       _ativoOriginalCommited = Ativo;
       _loteMinimoOriginalCommited = LoteMinimo;

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
               if (ImagemLoaded)
               {
                  if(this._valueImagem != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _imagemOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueImagem));
                     }
                  } 
                  else 
                  { 
                        _imagemOriginal = null ;
                  } 
               }
               if (_valueCollectionContratoFornecimentoClassMaterialLoaded) 
               {
                  if (_collectionContratoFornecimentoClassMaterialRemovidos != null) 
                  {
                     _collectionContratoFornecimentoClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContratoFornecimentoClassMaterialRemovidos = new List<Entidades.ContratoFornecimentoClass>();
                  }
                  _collectionContratoFornecimentoClassMaterialOriginal= (from a in _valueCollectionContratoFornecimentoClassMaterial select a.ID).ToList();
                  _valueCollectionContratoFornecimentoClassMaterialChanged = false;
                  _valueCollectionContratoFornecimentoClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded) 
               {
                  if (_collectionDeclaracaoImportacaoAdicaoItemClassMaterialRemovidos != null) 
                  {
                     _collectionDeclaracaoImportacaoAdicaoItemClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionDeclaracaoImportacaoAdicaoItemClassMaterialRemovidos = new List<Entidades.DeclaracaoImportacaoAdicaoItemClass>();
                  }
                  _collectionDeclaracaoImportacaoAdicaoItemClassMaterialOriginal= (from a in _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterial select a.ID).ToList();
                  _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialChanged = false;
                  _valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionEstoqueGavetaItemClassMaterialLoaded) 
               {
                  if (_collectionEstoqueGavetaItemClassMaterialRemovidos != null) 
                  {
                     _collectionEstoqueGavetaItemClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueGavetaItemClassMaterialRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                  }
                  _collectionEstoqueGavetaItemClassMaterialOriginal= (from a in _valueCollectionEstoqueGavetaItemClassMaterial select a.ID).ToList();
                  _valueCollectionEstoqueGavetaItemClassMaterialChanged = false;
                  _valueCollectionEstoqueGavetaItemClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded) 
               {
                  if (_collectionFomularioRetiradaManualEstoqueClassMaterialRemovidos != null) 
                  {
                     _collectionFomularioRetiradaManualEstoqueClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFomularioRetiradaManualEstoqueClassMaterialRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                  }
                  _collectionFomularioRetiradaManualEstoqueClassMaterialOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassMaterial select a.ID).ToList();
                  _valueCollectionFomularioRetiradaManualEstoqueClassMaterialChanged = false;
                  _valueCollectionFomularioRetiradaManualEstoqueClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraMaterialClassMaterialLoaded) 
               {
                  if (_collectionHistoricoCompraMaterialClassMaterialRemovidos != null) 
                  {
                     _collectionHistoricoCompraMaterialClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraMaterialClassMaterialRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                  }
                  _collectionHistoricoCompraMaterialClassMaterialOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassMaterial select a.ID).ToList();
                  _valueCollectionHistoricoCompraMaterialClassMaterialChanged = false;
                  _valueCollectionHistoricoCompraMaterialClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionKanbanAcionamentoClassMaterialLoaded) 
               {
                  if (_collectionKanbanAcionamentoClassMaterialRemovidos != null) 
                  {
                     _collectionKanbanAcionamentoClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionKanbanAcionamentoClassMaterialRemovidos = new List<Entidades.KanbanAcionamentoClass>();
                  }
                  _collectionKanbanAcionamentoClassMaterialOriginal= (from a in _valueCollectionKanbanAcionamentoClassMaterial select a.ID).ToList();
                  _valueCollectionKanbanAcionamentoClassMaterialChanged = false;
                  _valueCollectionKanbanAcionamentoClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionLoteClassMaterialLoaded) 
               {
                  if (_collectionLoteClassMaterialRemovidos != null) 
                  {
                     _collectionLoteClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLoteClassMaterialRemovidos = new List<Entidades.LoteClass>();
                  }
                  _collectionLoteClassMaterialOriginal= (from a in _valueCollectionLoteClassMaterial select a.ID).ToList();
                  _valueCollectionLoteClassMaterialChanged = false;
                  _valueCollectionLoteClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionMaterialFiscalClassMaterialLoaded) 
               {
                  if (_collectionMaterialFiscalClassMaterialRemovidos != null) 
                  {
                     _collectionMaterialFiscalClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialFiscalClassMaterialRemovidos = new List<Entidades.MaterialFiscalClass>();
                  }
                  _collectionMaterialFiscalClassMaterialOriginal= (from a in _valueCollectionMaterialFiscalClassMaterial select a.ID).ToList();
                  _valueCollectionMaterialFiscalClassMaterialChanged = false;
                  _valueCollectionMaterialFiscalClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionMaterialFornecedorClassMaterialLoaded) 
               {
                  if (_collectionMaterialFornecedorClassMaterialRemovidos != null) 
                  {
                     _collectionMaterialFornecedorClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialFornecedorClassMaterialRemovidos = new List<Entidades.MaterialFornecedorClass>();
                  }
                  _collectionMaterialFornecedorClassMaterialOriginal= (from a in _valueCollectionMaterialFornecedorClassMaterial select a.ID).ToList();
                  _valueCollectionMaterialFornecedorClassMaterialChanged = false;
                  _valueCollectionMaterialFornecedorClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoCompraItemClassMaterialLoaded) 
               {
                  if (_collectionOrcamentoCompraItemClassMaterialRemovidos != null) 
                  {
                     _collectionOrcamentoCompraItemClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoCompraItemClassMaterialRemovidos = new List<Entidades.OrcamentoCompraItemClass>();
                  }
                  _collectionOrcamentoCompraItemClassMaterialOriginal= (from a in _valueCollectionOrcamentoCompraItemClassMaterial select a.ID).ToList();
                  _valueCollectionOrcamentoCompraItemClassMaterialChanged = false;
                  _valueCollectionOrcamentoCompraItemClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoMaterialClassMaterialLoaded) 
               {
                  if (_collectionOrdemProducaoMaterialClassMaterialRemovidos != null) 
                  {
                     _collectionOrdemProducaoMaterialClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoMaterialClassMaterialRemovidos = new List<Entidades.OrdemProducaoMaterialClass>();
                  }
                  _collectionOrdemProducaoMaterialClassMaterialOriginal= (from a in _valueCollectionOrdemProducaoMaterialClassMaterial select a.ID).ToList();
                  _valueCollectionOrdemProducaoMaterialClassMaterialChanged = false;
                  _valueCollectionOrdemProducaoMaterialClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassMaterialRemovidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassMaterialRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassMaterialOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassMaterial select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassMaterialChanged = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemClassMaterialLoaded) 
               {
                  if (_collectionPlanoCorteItemClassMaterialRemovidos != null) 
                  {
                     _collectionPlanoCorteItemClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemClassMaterialRemovidos = new List<Entidades.PlanoCorteItemClass>();
                  }
                  _collectionPlanoCorteItemClassMaterialOriginal= (from a in _valueCollectionPlanoCorteItemClassMaterial select a.ID).ToList();
                  _valueCollectionPlanoCorteItemClassMaterialChanged = false;
                  _valueCollectionPlanoCorteItemClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionProdutoMaterialClassMaterialLoaded) 
               {
                  if (_collectionProdutoMaterialClassMaterialRemovidos != null) 
                  {
                     _collectionProdutoMaterialClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoMaterialClassMaterialRemovidos = new List<Entidades.ProdutoMaterialClass>();
                  }
                  _collectionProdutoMaterialClassMaterialOriginal= (from a in _valueCollectionProdutoMaterialClassMaterial select a.ID).ToList();
                  _valueCollectionProdutoMaterialClassMaterialChanged = false;
                  _valueCollectionProdutoMaterialClassMaterialCommitedChanged = false;
               }
               if (_valueCollectionSolicitacaoCompraClassMaterialLoaded) 
               {
                  if (_collectionSolicitacaoCompraClassMaterialRemovidos != null) 
                  {
                     _collectionSolicitacaoCompraClassMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionSolicitacaoCompraClassMaterialRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                  }
                  _collectionSolicitacaoCompraClassMaterialOriginal= (from a in _valueCollectionSolicitacaoCompraClassMaterial select a.ID).ToList();
                  _valueCollectionSolicitacaoCompraClassMaterialChanged = false;
                  _valueCollectionSolicitacaoCompraClassMaterialCommitedChanged = false;
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
               PoliticaEstoque=_politicaEstoqueOriginal;
               _politicaEstoqueOriginalCommited=_politicaEstoqueOriginal;
               CodigoAntigo=_codigoAntigoOriginal;
               _codigoAntigoOriginalCommited=_codigoAntigoOriginal;
               DescricaoAdicional=_descricaoAdicionalOriginal;
               _descricaoAdicionalOriginalCommited=_descricaoAdicionalOriginal;
               LotePadrao=_lotePadraoOriginal;
               _lotePadraoOriginalCommited=_lotePadraoOriginal;
               Verde=_verdeOriginal;
               _verdeOriginalCommited=_verdeOriginal;
               Amarelo=_amareloOriginal;
               _amareloOriginalCommited=_amareloOriginal;
               Vermelho=_vermelhoOriginal;
               _vermelhoOriginalCommited=_vermelhoOriginal;
               UnidadeMedidaCompra=_unidadeMedidaCompraOriginal;
               _unidadeMedidaCompraOriginalCommited=_unidadeMedidaCompraOriginal;
               UnidadesPorUnCompra=_unidadesPorUnCompraOriginal;
               _unidadesPorUnCompraOriginalCommited=_unidadesPorUnCompraOriginal;
               LeadTimeCompra=_leadTimeCompraOriginal;
               _leadTimeCompraOriginalCommited=_leadTimeCompraOriginal;
               MarcasHomologadas=_marcasHomologadasOriginal;
               _marcasHomologadasOriginalCommited=_marcasHomologadasOriginal;
               ImpedirSolicitacaoAuto=_impedirSolicitacaoAutoOriginal;
               _impedirSolicitacaoAutoOriginalCommited=_impedirSolicitacaoAutoOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               UtilizandoEstoqueSeguranca=_utilizandoEstoqueSegurancaOriginal;
               _utilizandoEstoqueSegurancaOriginalCommited=_utilizandoEstoqueSegurancaOriginal;
               UtilizandoEstoqueSegurancaData=_utilizandoEstoqueSegurancaDataOriginal;
               _utilizandoEstoqueSegurancaDataOriginalCommited=_utilizandoEstoqueSegurancaDataOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ImagemLoaded = false;
               this._imagemOriginal = null;
               this._imagemOriginalCommited = null;
               this._valueImagem = null;
               Comprador=_compradorOriginal;
               _compradorOriginalCommited=_compradorOriginal;
               ControleValidade=_controleValidadeOriginal;
               _controleValidadeOriginalCommited=_controleValidadeOriginal;
               ControleValidadeMeses=_controleValidadeMesesOriginal;
               _controleValidadeMesesOriginalCommited=_controleValidadeMesesOriginal;
               MargemRecebimento=_margemRecebimentoOriginal;
               _margemRecebimentoOriginalCommited=_margemRecebimentoOriginal;
               Gtin=_gtinOriginal;
               _gtinOriginalCommited=_gtinOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               LoteMinimo=_loteMinimoOriginal;
               _loteMinimoOriginalCommited=_loteMinimoOriginal;
               if (_valueCollectionContratoFornecimentoClassMaterialLoaded) 
               {
                  CollectionContratoFornecimentoClassMaterial.Clear();
                  foreach(int item in _collectionContratoFornecimentoClassMaterialOriginal)
                  {
                    CollectionContratoFornecimentoClassMaterial.Add(Entidades.ContratoFornecimentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContratoFornecimentoClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded) 
               {
                  CollectionDeclaracaoImportacaoAdicaoItemClassMaterial.Clear();
                  foreach(int item in _collectionDeclaracaoImportacaoAdicaoItemClassMaterialOriginal)
                  {
                    CollectionDeclaracaoImportacaoAdicaoItemClassMaterial.Add(Entidades.DeclaracaoImportacaoAdicaoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionDeclaracaoImportacaoAdicaoItemClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionEstoqueGavetaItemClassMaterialLoaded) 
               {
                  CollectionEstoqueGavetaItemClassMaterial.Clear();
                  foreach(int item in _collectionEstoqueGavetaItemClassMaterialOriginal)
                  {
                    CollectionEstoqueGavetaItemClassMaterial.Add(Entidades.EstoqueGavetaItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueGavetaItemClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded) 
               {
                  CollectionFomularioRetiradaManualEstoqueClassMaterial.Clear();
                  foreach(int item in _collectionFomularioRetiradaManualEstoqueClassMaterialOriginal)
                  {
                    CollectionFomularioRetiradaManualEstoqueClassMaterial.Add(Entidades.FomularioRetiradaManualEstoqueClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFomularioRetiradaManualEstoqueClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraMaterialClassMaterialLoaded) 
               {
                  CollectionHistoricoCompraMaterialClassMaterial.Clear();
                  foreach(int item in _collectionHistoricoCompraMaterialClassMaterialOriginal)
                  {
                    CollectionHistoricoCompraMaterialClassMaterial.Add(Entidades.HistoricoCompraMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraMaterialClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionKanbanAcionamentoClassMaterialLoaded) 
               {
                  CollectionKanbanAcionamentoClassMaterial.Clear();
                  foreach(int item in _collectionKanbanAcionamentoClassMaterialOriginal)
                  {
                    CollectionKanbanAcionamentoClassMaterial.Add(Entidades.KanbanAcionamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionKanbanAcionamentoClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionLoteClassMaterialLoaded) 
               {
                  CollectionLoteClassMaterial.Clear();
                  foreach(int item in _collectionLoteClassMaterialOriginal)
                  {
                    CollectionLoteClassMaterial.Add(Entidades.LoteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLoteClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionMaterialFiscalClassMaterialLoaded) 
               {
                  CollectionMaterialFiscalClassMaterial.Clear();
                  foreach(int item in _collectionMaterialFiscalClassMaterialOriginal)
                  {
                    CollectionMaterialFiscalClassMaterial.Add(Entidades.MaterialFiscalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialFiscalClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionMaterialFornecedorClassMaterialLoaded) 
               {
                  CollectionMaterialFornecedorClassMaterial.Clear();
                  foreach(int item in _collectionMaterialFornecedorClassMaterialOriginal)
                  {
                    CollectionMaterialFornecedorClassMaterial.Add(Entidades.MaterialFornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialFornecedorClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoCompraItemClassMaterialLoaded) 
               {
                  CollectionOrcamentoCompraItemClassMaterial.Clear();
                  foreach(int item in _collectionOrcamentoCompraItemClassMaterialOriginal)
                  {
                    CollectionOrcamentoCompraItemClassMaterial.Add(Entidades.OrcamentoCompraItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoCompraItemClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoMaterialClassMaterialLoaded) 
               {
                  CollectionOrdemProducaoMaterialClassMaterial.Clear();
                  foreach(int item in _collectionOrdemProducaoMaterialClassMaterialOriginal)
                  {
                    CollectionOrdemProducaoMaterialClassMaterial.Add(Entidades.OrdemProducaoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoMaterialClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassMaterial.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassMaterialOriginal)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassMaterial.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemClassMaterialLoaded) 
               {
                  CollectionPlanoCorteItemClassMaterial.Clear();
                  foreach(int item in _collectionPlanoCorteItemClassMaterialOriginal)
                  {
                    CollectionPlanoCorteItemClassMaterial.Add(Entidades.PlanoCorteItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionProdutoMaterialClassMaterialLoaded) 
               {
                  CollectionProdutoMaterialClassMaterial.Clear();
                  foreach(int item in _collectionProdutoMaterialClassMaterialOriginal)
                  {
                    CollectionProdutoMaterialClassMaterial.Add(Entidades.ProdutoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoMaterialClassMaterialRemovidos.Clear();
               }
               if (_valueCollectionSolicitacaoCompraClassMaterialLoaded) 
               {
                  CollectionSolicitacaoCompraClassMaterial.Clear();
                  foreach(int item in _collectionSolicitacaoCompraClassMaterialOriginal)
                  {
                    CollectionSolicitacaoCompraClassMaterial.Add(Entidades.SolicitacaoCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionSolicitacaoCompraClassMaterialRemovidos.Clear();
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
               if (_valueCollectionContratoFornecimentoClassMaterialLoaded) 
               {
                  if (_valueCollectionContratoFornecimentoClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded) 
               {
                  if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassMaterialLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassMaterialLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassMaterialLoaded) 
               {
                  if (_valueCollectionKanbanAcionamentoClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassMaterialLoaded) 
               {
                  if (_valueCollectionLoteClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFiscalClassMaterialLoaded) 
               {
                  if (_valueCollectionMaterialFiscalClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFornecedorClassMaterialLoaded) 
               {
                  if (_valueCollectionMaterialFornecedorClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassMaterialLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraItemClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoMaterialClassMaterialLoaded) 
               {
                  if (_valueCollectionOrdemProducaoMaterialClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassMaterialLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassMaterialLoaded) 
               {
                  if (_valueCollectionProdutoMaterialClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassMaterialLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContratoFornecimentoClassMaterialLoaded) 
               {
                   tempRet = CollectionContratoFornecimentoClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded) 
               {
                   tempRet = CollectionDeclaracaoImportacaoAdicaoItemClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueGavetaItemClassMaterialLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassMaterialLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionKanbanAcionamentoClassMaterialLoaded) 
               {
                   tempRet = CollectionKanbanAcionamentoClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassMaterialLoaded) 
               {
                   tempRet = CollectionLoteClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFiscalClassMaterialLoaded) 
               {
                   tempRet = CollectionMaterialFiscalClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFornecedorClassMaterialLoaded) 
               {
                   tempRet = CollectionMaterialFornecedorClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoCompraItemClassMaterialLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraItemClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoMaterialClassMaterialLoaded) 
               {
                   tempRet = CollectionOrdemProducaoMaterialClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassMaterialLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassMaterialLoaded) 
               {
                   tempRet = CollectionProdutoMaterialClassMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassMaterialLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassMaterial.Any(item => item.IsDirty());
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
       dirty = _politicaEstoqueOriginal != PoliticaEstoque;
      if (dirty) return true;
       dirty = _codigoAntigoOriginal != CodigoAntigo;
      if (dirty) return true;
       dirty = _descricaoAdicionalOriginal != DescricaoAdicional;
      if (dirty) return true;
       dirty = _lotePadraoOriginal != LotePadrao;
      if (dirty) return true;
       dirty = _verdeOriginal != Verde;
      if (dirty) return true;
       dirty = _amareloOriginal != Amarelo;
      if (dirty) return true;
       dirty = _vermelhoOriginal != Vermelho;
      if (dirty) return true;
       if (_unidadeMedidaCompraOriginal!=null)
       {
          dirty = !_unidadeMedidaCompraOriginal.Equals(UnidadeMedidaCompra);
       }
       else
       {
            dirty = UnidadeMedidaCompra != null;
       }
      if (dirty) return true;
       dirty = _unidadesPorUnCompraOriginal != UnidadesPorUnCompra;
      if (dirty) return true;
       dirty = _leadTimeCompraOriginal != LeadTimeCompra;
      if (dirty) return true;
       dirty = _marcasHomologadasOriginal != MarcasHomologadas;
      if (dirty) return true;
       dirty = _impedirSolicitacaoAutoOriginal != ImpedirSolicitacaoAuto;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaOriginal != UtilizandoEstoqueSeguranca;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaDataOriginal != UtilizandoEstoqueSegurancaData;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
               if (ImagemLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpImagem ;
                      if (this._valueImagem == null) 
                      { 
                         tmpImagem = null; 
                      } 
                      else 
                      { 
                         tmpImagem = Convert.ToBase64String(sha1.ComputeHash(this._valueImagem));
                      } 
                       dirty = _imagemOriginal != tmpImagem;
                   }
               }
      if (dirty) return true;
       if (_compradorOriginal!=null)
       {
          dirty = !_compradorOriginal.Equals(Comprador);
       }
       else
       {
            dirty = Comprador != null;
       }
      if (dirty) return true;
       dirty = _controleValidadeOriginal != ControleValidade;
      if (dirty) return true;
       dirty = _controleValidadeMesesOriginal != ControleValidadeMeses;
      if (dirty) return true;
       dirty = _margemRecebimentoOriginal != MargemRecebimento;
      if (dirty) return true;
       dirty = _gtinOriginal != Gtin;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;
      if (dirty) return true;
       dirty = _loteMinimoOriginal != LoteMinimo;

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
               if (_valueCollectionContratoFornecimentoClassMaterialLoaded) 
               {
                  if (_valueCollectionContratoFornecimentoClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded) 
               {
                  if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassMaterialLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassMaterialLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassMaterialLoaded) 
               {
                  if (_valueCollectionKanbanAcionamentoClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassMaterialLoaded) 
               {
                  if (_valueCollectionLoteClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFiscalClassMaterialLoaded) 
               {
                  if (_valueCollectionMaterialFiscalClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFornecedorClassMaterialLoaded) 
               {
                  if (_valueCollectionMaterialFornecedorClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassMaterialLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraItemClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoMaterialClassMaterialLoaded) 
               {
                  if (_valueCollectionOrdemProducaoMaterialClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassMaterialLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassMaterialLoaded) 
               {
                  if (_valueCollectionProdutoMaterialClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassMaterialLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContratoFornecimentoClassMaterialLoaded) 
               {
                   tempRet = CollectionContratoFornecimentoClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded) 
               {
                   tempRet = CollectionDeclaracaoImportacaoAdicaoItemClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueGavetaItemClassMaterialLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassMaterialLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionKanbanAcionamentoClassMaterialLoaded) 
               {
                   tempRet = CollectionKanbanAcionamentoClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassMaterialLoaded) 
               {
                   tempRet = CollectionLoteClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFiscalClassMaterialLoaded) 
               {
                   tempRet = CollectionMaterialFiscalClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFornecedorClassMaterialLoaded) 
               {
                   tempRet = CollectionMaterialFornecedorClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoCompraItemClassMaterialLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraItemClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoMaterialClassMaterialLoaded) 
               {
                   tempRet = CollectionOrdemProducaoMaterialClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassMaterialLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassMaterialLoaded) 
               {
                   tempRet = CollectionProdutoMaterialClassMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassMaterialLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassMaterial.Any(item => item.IsDirtyCommited());
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
       dirty = _politicaEstoqueOriginalCommited != PoliticaEstoque;
      if (dirty) return true;
       dirty = _codigoAntigoOriginalCommited != CodigoAntigo;
      if (dirty) return true;
       dirty = _descricaoAdicionalOriginalCommited != DescricaoAdicional;
      if (dirty) return true;
       dirty = _lotePadraoOriginalCommited != LotePadrao;
      if (dirty) return true;
       dirty = _verdeOriginalCommited != Verde;
      if (dirty) return true;
       dirty = _amareloOriginalCommited != Amarelo;
      if (dirty) return true;
       dirty = _vermelhoOriginalCommited != Vermelho;
      if (dirty) return true;
       if (_unidadeMedidaCompraOriginalCommited!=null)
       {
          dirty = !_unidadeMedidaCompraOriginalCommited.Equals(UnidadeMedidaCompra);
       }
       else
       {
            dirty = UnidadeMedidaCompra != null;
       }
      if (dirty) return true;
       dirty = _unidadesPorUnCompraOriginalCommited != UnidadesPorUnCompra;
      if (dirty) return true;
       dirty = _leadTimeCompraOriginalCommited != LeadTimeCompra;
      if (dirty) return true;
       dirty = _marcasHomologadasOriginalCommited != MarcasHomologadas;
      if (dirty) return true;
       dirty = _impedirSolicitacaoAutoOriginalCommited != ImpedirSolicitacaoAuto;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaOriginalCommited != UtilizandoEstoqueSeguranca;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaDataOriginalCommited != UtilizandoEstoqueSegurancaData;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
               if (ImagemLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpImagem ;
                      if (this._valueImagem == null) 
                      { 
                         tmpImagem = null; 
                      } 
                      else 
                      { 
                         tmpImagem = Convert.ToBase64String(sha1.ComputeHash(this._valueImagem));
                      } 
                       dirty = _imagemOriginalCommited != tmpImagem;
                   }
               }
      if (dirty) return true;
       if (_compradorOriginalCommited!=null)
       {
          dirty = !_compradorOriginalCommited.Equals(Comprador);
       }
       else
       {
            dirty = Comprador != null;
       }
      if (dirty) return true;
       dirty = _controleValidadeOriginalCommited != ControleValidade;
      if (dirty) return true;
       dirty = _controleValidadeMesesOriginalCommited != ControleValidadeMeses;
      if (dirty) return true;
       dirty = _margemRecebimentoOriginalCommited != MargemRecebimento;
      if (dirty) return true;
       dirty = _gtinOriginalCommited != Gtin;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;
      if (dirty) return true;
       dirty = _loteMinimoOriginalCommited != LoteMinimo;

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
               if (_valueCollectionContratoFornecimentoClassMaterialLoaded) 
               {
                  foreach(ContratoFornecimentoClass item in CollectionContratoFornecimentoClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded) 
               {
                  foreach(DeclaracaoImportacaoAdicaoItemClass item in CollectionDeclaracaoImportacaoAdicaoItemClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassMaterialLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassMaterialLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassMaterialLoaded) 
               {
                  foreach(KanbanAcionamentoClass item in CollectionKanbanAcionamentoClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionLoteClassMaterialLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMaterialFiscalClassMaterialLoaded) 
               {
                  foreach(MaterialFiscalClass item in CollectionMaterialFiscalClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMaterialFornecedorClassMaterialLoaded) 
               {
                  foreach(MaterialFornecedorClass item in CollectionMaterialFornecedorClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassMaterialLoaded) 
               {
                  foreach(OrcamentoCompraItemClass item in CollectionOrcamentoCompraItemClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoMaterialClassMaterialLoaded) 
               {
                  foreach(OrdemProducaoMaterialClass item in CollectionOrdemProducaoMaterialClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassMaterialLoaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoMaterialClassMaterialLoaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassMaterialLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassMaterial)
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
             case "PoliticaEstoque":
                return this.PoliticaEstoque;
             case "CodigoAntigo":
                return this.CodigoAntigo;
             case "DescricaoAdicional":
                return this.DescricaoAdicional;
             case "LotePadrao":
                return this.LotePadrao;
             case "Verde":
                return this.Verde;
             case "Amarelo":
                return this.Amarelo;
             case "Vermelho":
                return this.Vermelho;
             case "UnidadeMedidaCompra":
                return this.UnidadeMedidaCompra;
             case "UnidadesPorUnCompra":
                return this.UnidadesPorUnCompra;
             case "LeadTimeCompra":
                return this.LeadTimeCompra;
             case "MarcasHomologadas":
                return this.MarcasHomologadas;
             case "ImpedirSolicitacaoAuto":
                return this.ImpedirSolicitacaoAuto;
             case "UtilizandoEstoqueSeguranca":
                return this.UtilizandoEstoqueSeguranca;
             case "UtilizandoEstoqueSegurancaData":
                return this.UtilizandoEstoqueSegurancaData;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Imagem":
                return this.Imagem;
             case "Comprador":
                return this.Comprador;
             case "ControleValidade":
                return this.ControleValidade;
             case "ControleValidadeMeses":
                return this.ControleValidadeMeses;
             case "MargemRecebimento":
                return this.MargemRecebimento;
             case "Gtin":
                return this.Gtin;
             case "Ativo":
                return this.Ativo;
             case "LoteMinimo":
                return this.LoteMinimo;
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
             if (UnidadeMedidaCompra!=null)
                UnidadeMedidaCompra.ChangeSingleConnection(newConnection);
             if (Comprador!=null)
                Comprador.ChangeSingleConnection(newConnection);
               if (_valueCollectionContratoFornecimentoClassMaterialLoaded) 
               {
                  foreach(ContratoFornecimentoClass item in CollectionContratoFornecimentoClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoItemClassMaterialLoaded) 
               {
                  foreach(DeclaracaoImportacaoAdicaoItemClass item in CollectionDeclaracaoImportacaoAdicaoItemClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassMaterialLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassMaterialLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassMaterialLoaded) 
               {
                  foreach(KanbanAcionamentoClass item in CollectionKanbanAcionamentoClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionLoteClassMaterialLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMaterialFiscalClassMaterialLoaded) 
               {
                  foreach(MaterialFiscalClass item in CollectionMaterialFiscalClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMaterialFornecedorClassMaterialLoaded) 
               {
                  foreach(MaterialFornecedorClass item in CollectionMaterialFornecedorClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassMaterialLoaded) 
               {
                  foreach(OrcamentoCompraItemClass item in CollectionOrcamentoCompraItemClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoMaterialClassMaterialLoaded) 
               {
                  foreach(OrdemProducaoMaterialClass item in CollectionOrdemProducaoMaterialClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassMaterialLoaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoMaterialClassMaterialLoaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassMaterialLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassMaterial)
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
                  command.CommandText += " COUNT(material.id_material) " ;
               }
               else
               {
               command.CommandText += "material.id_material, " ;
               command.CommandText += "material.mat_descricao, " ;
               command.CommandText += "material.mat_medida, " ;
               command.CommandText += "material.mat_medida_largura, " ;
               command.CommandText += "material.mat_medida_comprimento, " ;
               command.CommandText += "material.mat_codigo, " ;
               command.CommandText += "material.id_unidade_medida, " ;
               command.CommandText += "material.id_familia_material, " ;
               command.CommandText += "material.id_acabamento, " ;
               command.CommandText += "material.mat_politica_estoque, " ;
               command.CommandText += "material.mat_codigo_antigo, " ;
               command.CommandText += "material.mat_descricao_adicional, " ;
               command.CommandText += "material.mat_lote_padrao, " ;
               command.CommandText += "material.mat_verde, " ;
               command.CommandText += "material.mat_amarelo, " ;
               command.CommandText += "material.mat_vermelho, " ;
               command.CommandText += "material.id_unidade_medida_compra, " ;
               command.CommandText += "material.mat_unidades_por_un_compra, " ;
               command.CommandText += "material.mat_lead_time_compra, " ;
               command.CommandText += "material.mat_marcas_homologadas, " ;
               command.CommandText += "material.mat_impedir_solicitacao_auto, " ;
               command.CommandText += "material.mat_ultima_revisao, " ;
               command.CommandText += "material.mat_ultima_revisao_data, " ;
               command.CommandText += "material.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "material.mat_utilizando_estoque_seguranca, " ;
               command.CommandText += "material.mat_utilizando_estoque_seguranca_data, " ;
               command.CommandText += "material.entity_uid, " ;
               command.CommandText += "material.version, " ;
               command.CommandText += "material.id_comprador, " ;
               command.CommandText += "material.mat_controle_validade, " ;
               command.CommandText += "material.mat_controle_validade_meses, " ;
               command.CommandText += "material.mat_margem_recebimento, " ;
               command.CommandText += "material.mat_gtin, " ;
               command.CommandText += "material.mat_ativo, " ;
               command.CommandText += "material.mat_lote_minimo " ;
               }
               command.CommandText += " FROM  material ";
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
                        orderByClause += " , mat_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mat_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = material.id_acs_usuario_ultima_revisao ";
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
                     case "id_material":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.id_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.id_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material.mat_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material.mat_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_medida":
                     case "Medida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_medida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_medida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_medida_largura":
                     case "MedidaLargura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_medida_largura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_medida_largura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_medida_comprimento":
                     case "MedidaComprimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_medida_comprimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_medida_comprimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material.mat_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material.mat_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida":
                     case "UnidadeMedida":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedida ON unidade_medida_UnidadeMedida.id_unidade_medida = material.id_unidade_medida ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN familia_material as familia_material_FamiliaMaterial ON familia_material_FamiliaMaterial.id_familia_material = material.id_familia_material ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN acabamento as acabamento_Acabamento ON acabamento_Acabamento.id_acabamento = material.id_acabamento ";                     switch (parametro.TipoOrdenacao)
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
                     case "mat_politica_estoque":
                     case "PoliticaEstoque":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_politica_estoque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_politica_estoque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_codigo_antigo":
                     case "CodigoAntigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material.mat_codigo_antigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material.mat_codigo_antigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_descricao_adicional":
                     case "DescricaoAdicional":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material.mat_descricao_adicional " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material.mat_descricao_adicional) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_lote_padrao":
                     case "LotePadrao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_lote_padrao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_lote_padrao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_verde":
                     case "Verde":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_verde " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_verde) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_amarelo":
                     case "Amarelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_amarelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_amarelo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_vermelho":
                     case "Vermelho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_vermelho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_vermelho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_compra":
                     case "UnidadeMedidaCompra":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaCompra ON unidade_medida_UnidadeMedidaCompra.id_unidade_medida = material.id_unidade_medida_compra ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedidaCompra.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedidaCompra.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_unidades_por_un_compra":
                     case "UnidadesPorUnCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_unidades_por_un_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_unidades_por_un_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_lead_time_compra":
                     case "LeadTimeCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_lead_time_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_lead_time_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_marcas_homologadas":
                     case "MarcasHomologadas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material.mat_marcas_homologadas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material.mat_marcas_homologadas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_impedir_solicitacao_auto":
                     case "ImpedirSolicitacaoAuto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_impedir_solicitacao_auto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_impedir_solicitacao_auto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material.mat_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material.mat_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , material.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "mat_utilizando_estoque_seguranca":
                     case "UtilizandoEstoqueSeguranca":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_utilizando_estoque_seguranca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_utilizando_estoque_seguranca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_utilizando_estoque_seguranca_data":
                     case "UtilizandoEstoqueSegurancaData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_utilizando_estoque_seguranca_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_utilizando_estoque_seguranca_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , material.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_imagem":
                     case "Imagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_imagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_imagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_comprador":
                     case "Comprador":
                     command.CommandText += " LEFT JOIN comprador as comprador_Comprador ON comprador_Comprador.id_comprador = material.id_comprador ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador_Comprador.com_apelido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador_Comprador.com_apelido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_controle_validade":
                     case "ControleValidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_controle_validade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_controle_validade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_controle_validade_meses":
                     case "ControleValidadeMeses":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_controle_validade_meses " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_controle_validade_meses) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_margem_recebimento":
                     case "MargemRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_margem_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_margem_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_gtin":
                     case "Gtin":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material.mat_gtin " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material.mat_gtin) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mat_lote_minimo":
                     case "LoteMinimo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material.mat_lote_minimo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material.mat_lote_minimo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mat_descricao")) 
                        {
                           whereClause += " OR UPPER(material.mat_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material.mat_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mat_codigo")) 
                        {
                           whereClause += " OR UPPER(material.mat_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material.mat_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mat_codigo_antigo")) 
                        {
                           whereClause += " OR UPPER(material.mat_codigo_antigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material.mat_codigo_antigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mat_descricao_adicional")) 
                        {
                           whereClause += " OR UPPER(material.mat_descricao_adicional) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material.mat_descricao_adicional) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mat_marcas_homologadas")) 
                        {
                           whereClause += " OR UPPER(material.mat_marcas_homologadas) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material.mat_marcas_homologadas) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mat_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(material.mat_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material.mat_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(material.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mat_gtin")) 
                        {
                           whereClause += " OR UPPER(material.mat_gtin) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material.mat_gtin) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.id_material = :material_ID_109 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_ID_109", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "mat_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_descricao LIKE :material_Descricao_2106 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Descricao_2106", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Medida" || parametro.FieldName == "mat_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_medida = :material_Medida_8324 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Medida_8324", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MedidaLargura" || parametro.FieldName == "mat_medida_largura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_medida_largura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_medida_largura = :material_MedidaLargura_9066 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_MedidaLargura_9066", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MedidaComprimento" || parametro.FieldName == "mat_medida_comprimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_medida_comprimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_medida_comprimento = :material_MedidaComprimento_2772 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_MedidaComprimento_2772", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "mat_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_codigo LIKE :material_Codigo_6488 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Codigo_6488", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  material.id_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.id_unidade_medida = :material_UnidadeMedida_3462 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_UnidadeMedida_3462", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  material.id_familia_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.id_familia_material = :material_FamiliaMaterial_3922 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_FamiliaMaterial_3922", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  material.id_acabamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.id_acabamento = :material_Acabamento_3159 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Acabamento_3159", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PoliticaEstoque" || parametro.FieldName == "mat_politica_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is PoliticaEstoque)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo PoliticaEstoque");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_politica_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_politica_estoque = :material_PoliticaEstoque_1025 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_PoliticaEstoque_1025", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoAntigo" || parametro.FieldName == "mat_codigo_antigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_codigo_antigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_codigo_antigo LIKE :material_CodigoAntigo_3805 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_CodigoAntigo_3805", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoAdicional" || parametro.FieldName == "mat_descricao_adicional")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_descricao_adicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_descricao_adicional LIKE :material_DescricaoAdicional_9532 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_DescricaoAdicional_9532", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LotePadrao" || parametro.FieldName == "mat_lote_padrao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_lote_padrao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_lote_padrao = :material_LotePadrao_8764 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_LotePadrao_8764", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Verde" || parametro.FieldName == "mat_verde")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_verde IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_verde = :material_Verde_5862 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Verde_5862", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Amarelo" || parametro.FieldName == "mat_amarelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_amarelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_amarelo = :material_Amarelo_9319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Amarelo_9319", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Vermelho" || parametro.FieldName == "mat_vermelho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_vermelho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_vermelho = :material_Vermelho_8914 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Vermelho_8914", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaCompra" || parametro.FieldName == "id_unidade_medida_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.id_unidade_medida_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.id_unidade_medida_compra = :material_UnidadeMedidaCompra_6323 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_UnidadeMedidaCompra_6323", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadesPorUnCompra" || parametro.FieldName == "mat_unidades_por_un_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_unidades_por_un_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_unidades_por_un_compra = :material_UnidadesPorUnCompra_7769 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_UnidadesPorUnCompra_7769", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LeadTimeCompra" || parametro.FieldName == "mat_lead_time_compra")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_lead_time_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_lead_time_compra = :material_LeadTimeCompra_5233 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_LeadTimeCompra_5233", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MarcasHomologadas" || parametro.FieldName == "mat_marcas_homologadas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_marcas_homologadas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_marcas_homologadas LIKE :material_MarcasHomologadas_5829 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_MarcasHomologadas_5829", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpedirSolicitacaoAuto" || parametro.FieldName == "mat_impedir_solicitacao_auto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_impedir_solicitacao_auto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_impedir_solicitacao_auto = :material_ImpedirSolicitacaoAuto_2233 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_ImpedirSolicitacaoAuto_2233", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "mat_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_ultima_revisao LIKE :material_UltimaRevisao_9272 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_UltimaRevisao_9272", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "mat_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_ultima_revisao_data = :material_UltimaRevisaoData_2440 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_UltimaRevisaoData_2440", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario" || parametro.FieldName == "id_acs_usuario_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.id_acs_usuario_ultima_revisao = :material_UltimaRevisaoUsuario_3973 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_UltimaRevisaoUsuario_3973", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizandoEstoqueSeguranca" || parametro.FieldName == "mat_utilizando_estoque_seguranca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EstoqueSeguranca)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EstoqueSeguranca");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_utilizando_estoque_seguranca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_utilizando_estoque_seguranca = :material_UtilizandoEstoqueSeguranca_3975 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_UtilizandoEstoqueSeguranca_3975", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizandoEstoqueSegurancaData" || parametro.FieldName == "mat_utilizando_estoque_seguranca_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_utilizando_estoque_seguranca_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_utilizando_estoque_seguranca_data = :material_UtilizandoEstoqueSegurancaData_6699 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_UtilizandoEstoqueSegurancaData_6699", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.entity_uid LIKE :material_EntityUid_4438 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_EntityUid_4438", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  material.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.version = :material_Version_3203 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Version_3203", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Imagem" || parametro.FieldName == "mat_imagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_imagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_imagem = :material_Imagem_8568 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Imagem_8568", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Comprador" || parametro.FieldName == "id_comprador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CompradorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CompradorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.id_comprador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.id_comprador = :material_Comprador_8968 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Comprador_8968", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ControleValidade" || parametro.FieldName == "mat_controle_validade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_controle_validade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_controle_validade = :material_ControleValidade_3494 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_ControleValidade_3494", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ControleValidadeMeses" || parametro.FieldName == "mat_controle_validade_meses")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_controle_validade_meses IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_controle_validade_meses = :material_ControleValidadeMeses_5696 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_ControleValidadeMeses_5696", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MargemRecebimento" || parametro.FieldName == "mat_margem_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_margem_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_margem_recebimento = :material_MargemRecebimento_9503 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_MargemRecebimento_9503", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Gtin" || parametro.FieldName == "mat_gtin")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_gtin IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_gtin LIKE :material_Gtin_5503 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Gtin_5503", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "mat_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_ativo = :material_Ativo_601 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Ativo_601", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LoteMinimo" || parametro.FieldName == "mat_lote_minimo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_lote_minimo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_lote_minimo = :material_LoteMinimo_6326 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_LoteMinimo_6326", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  material.mat_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_descricao LIKE :material_Descricao_4837 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Descricao_4837", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  material.mat_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_codigo LIKE :material_Codigo_6430 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Codigo_6430", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoAntigoExato" || parametro.FieldName == "CodigoAntigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_codigo_antigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_codigo_antigo LIKE :material_CodigoAntigo_9748 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_CodigoAntigo_9748", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  material.mat_descricao_adicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_descricao_adicional LIKE :material_DescricaoAdicional_532 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_DescricaoAdicional_532", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MarcasHomologadasExato" || parametro.FieldName == "MarcasHomologadasExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_marcas_homologadas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_marcas_homologadas LIKE :material_MarcasHomologadas_6415 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_MarcasHomologadas_6415", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoExato" || parametro.FieldName == "UltimaRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_ultima_revisao LIKE :material_UltimaRevisao_1142 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_UltimaRevisao_1142", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.entity_uid LIKE :material_EntityUid_6293 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_EntityUid_6293", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GtinExato" || parametro.FieldName == "GtinExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material.mat_gtin IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material.mat_gtin LIKE :material_Gtin_2731 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_Gtin_2731", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MaterialClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MaterialClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MaterialClass), Convert.ToInt32(read["id_material"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MaterialClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_material"]);
                     entidade.Descricao = (read["mat_descricao"] != DBNull.Value ? read["mat_descricao"].ToString() : null);
                     entidade.Medida = (double)read["mat_medida"];
                     entidade.MedidaLargura = (double)read["mat_medida_largura"];
                     entidade.MedidaComprimento = (double)read["mat_medida_comprimento"];
                     entidade.Codigo = (read["mat_codigo"] != DBNull.Value ? read["mat_codigo"].ToString() : null);
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
                     entidade.PoliticaEstoque = (PoliticaEstoque) (read["mat_politica_estoque"] != DBNull.Value ? Enum.ToObject(typeof(PoliticaEstoque), read["mat_politica_estoque"]) : null);
                     entidade.CodigoAntigo = (read["mat_codigo_antigo"] != DBNull.Value ? read["mat_codigo_antigo"].ToString() : null);
                     entidade.DescricaoAdicional = (read["mat_descricao_adicional"] != DBNull.Value ? read["mat_descricao_adicional"].ToString() : null);
                     entidade.LotePadrao = (double)read["mat_lote_padrao"];
                     entidade.Verde = (double)read["mat_verde"];
                     entidade.Amarelo = (double)read["mat_amarelo"];
                     entidade.Vermelho = (double)read["mat_vermelho"];
                     if (read["id_unidade_medida_compra"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaCompra = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_compra"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaCompra = null ;
                     }
                     entidade.UnidadesPorUnCompra = (double)read["mat_unidades_por_un_compra"];
                     entidade.LeadTimeCompra = (int)read["mat_lead_time_compra"];
                     entidade.MarcasHomologadas = (read["mat_marcas_homologadas"] != DBNull.Value ? read["mat_marcas_homologadas"].ToString() : null);
                     entidade.ImpedirSolicitacaoAuto = Convert.ToBoolean(Convert.ToInt16(read["mat_impedir_solicitacao_auto"]));
                     entidade.UltimaRevisao = (read["mat_ultima_revisao"] != DBNull.Value ? read["mat_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["mat_ultima_revisao_data"] as DateTime?;
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.UtilizandoEstoqueSeguranca = (EstoqueSeguranca) (read["mat_utilizando_estoque_seguranca"] != DBNull.Value ? Enum.ToObject(typeof(EstoqueSeguranca), read["mat_utilizando_estoque_seguranca"]) : null);
                     entidade.UtilizandoEstoqueSegurancaData = read["mat_utilizando_estoque_seguranca_data"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_comprador"] != DBNull.Value)
                     {
                        entidade.Comprador = (BibliotecaEntidades.Entidades.CompradorClass)BibliotecaEntidades.Entidades.CompradorClass.GetEntidade(Convert.ToInt32(read["id_comprador"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Comprador = null ;
                     }
                     entidade.ControleValidade = Convert.ToBoolean(Convert.ToInt16(read["mat_controle_validade"]));
                     entidade.ControleValidadeMeses = read["mat_controle_validade_meses"] as int?;
                     entidade.MargemRecebimento = read["mat_margem_recebimento"] as double?;
                     entidade.Gtin = (read["mat_gtin"] != DBNull.Value ? read["mat_gtin"].ToString() : null);
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["mat_ativo"]));
                     entidade.LoteMinimo = (double)read["mat_lote_minimo"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MaterialClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
