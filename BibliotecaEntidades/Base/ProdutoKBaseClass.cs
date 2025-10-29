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
     [Table("produto_k","prk")]
     public class ProdutoKBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProdutoKClass";
protected const string ErroDelete = "Erro ao excluir o ProdutoKClass  ";
protected const string ErroSave = "Erro ao salvar o ProdutoKClass.";
protected const string ErroCollectionEstoqueGavetaItemClassProdutoK = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected const string ErroCollectionKanbanAcionamentoClassProdutoK = "Erro ao carregar a coleção de KanbanAcionamentoClass.";
protected const string ErroCollectionOrcamentoConfiguradoClassProdutoK = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
protected const string ErroCollectionOrdemProducaoClassProdutoK = "Erro ao carregar a coleção de OrdemProducaoClass.";
protected const string ErroCollectionOrdemProducaoProdutoComponenteClassProdutoK = "Erro ao carregar a coleção de OrdemProducaoProdutoComponenteClass.";
protected const string ErroCollectionOrderItemEtiquetaClassProdutoK = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
protected const string ErroCollectionProdutoKEtiquetaClassProdutoK = "Erro ao carregar a coleção de ProdutoKEtiquetaClass.";
protected const string ErroCollectionProdutoKProdutoClassProdutoK = "Erro ao carregar a coleção de ProdutoKProdutoClass.";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected const string ErroDimensaoObrigatorio = "O campo Dimensao é obrigatório";
protected const string ErroDimensaoComprimento = "O campo Dimensao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do ProdutoKClass.";
protected const string MensagemUtilizadoCollectionEstoqueGavetaItemClassProdutoK =  "A entidade ProdutoKClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected const string MensagemUtilizadoCollectionKanbanAcionamentoClassProdutoK =  "A entidade ProdutoKClass está sendo utilizada nos seguintes KanbanAcionamentoClass:";
protected const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassProdutoK =  "A entidade ProdutoKClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoClassProdutoK =  "A entidade ProdutoKClass está sendo utilizada nos seguintes OrdemProducaoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoProdutoComponenteClassProdutoK =  "A entidade ProdutoKClass está sendo utilizada nos seguintes OrdemProducaoProdutoComponenteClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaClassProdutoK =  "A entidade ProdutoKClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
protected const string MensagemUtilizadoCollectionProdutoKEtiquetaClassProdutoK =  "A entidade ProdutoKClass está sendo utilizada nos seguintes ProdutoKEtiquetaClass:";
protected const string MensagemUtilizadoCollectionProdutoKProdutoClassProdutoK =  "A entidade ProdutoKClass está sendo utilizada nos seguintes ProdutoKProdutoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoKClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.ClassificacaoProdutoClass _classificacaoProdutoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ClassificacaoProdutoClass _classificacaoProdutoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ClassificacaoProdutoClass _valueClassificacaoProduto;
        [Column("id_classificacao_produto", "classificacao_produto", "id_classificacao_produto")]
       public virtual BibliotecaEntidades.Entidades.ClassificacaoProdutoClass ClassificacaoProduto
        { 
           get {                 return this._valueClassificacaoProduto; } 
           set 
           { 
                if (this._valueClassificacaoProduto == value)return;
                 this._valueClassificacaoProduto = value; 
           } 
       } 

       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("prk_codigo")]
        public virtual string Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected string _dimensaoOriginal{get;private set;}
       private string _dimensaoOriginalCommited{get; set;}
        private string _valueDimensao;
         [Column("prk_dimensao")]
        public virtual string Dimensao
         { 
            get { return this._valueDimensao; } 
            set 
            { 
                if (this._valueDimensao == value)return;
                 this._valueDimensao = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("prk_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       protected bool _imprimeEtiquetaOriginal{get;private set;}
       private bool _imprimeEtiquetaOriginalCommited{get; set;}
        private bool _valueImprimeEtiqueta;
         [Column("prk_imprime_etiqueta")]
        public virtual bool ImprimeEtiqueta
         { 
            get { return this._valueImprimeEtiqueta; } 
            set 
            { 
                if (this._valueImprimeEtiqueta == value)return;
                 this._valueImprimeEtiqueta = value; 
            } 
        } 

       protected bool _emiteOpOriginal{get;private set;}
       private bool _emiteOpOriginalCommited{get; set;}
        private bool _valueEmiteOp;
         [Column("prk_emite_op")]
        public virtual bool EmiteOp
         { 
            get { return this._valueEmiteOp; } 
            set 
            { 
                if (this._valueEmiteOp == value)return;
                 this._valueEmiteOp = value; 
            } 
        } 

       protected double _verdeOriginal{get;private set;}
       private double _verdeOriginalCommited{get; set;}
        private double _valueVerde;
         [Column("prk_verde")]
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
         [Column("prk_amarelo")]
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
         [Column("prk_vermelho")]
        public virtual double Vermelho
         { 
            get { return this._valueVermelho; } 
            set 
            { 
                if (this._valueVermelho == value)return;
                 this._valueVermelho = value; 
            } 
        } 

       protected double _loteProducaoOriginal{get;private set;}
       private double _loteProducaoOriginalCommited{get; set;}
        private double _valueLoteProducao;
         [Column("prk_lote_producao")]
        public virtual double LoteProducao
         { 
            get { return this._valueLoteProducao; } 
            set 
            { 
                if (this._valueLoteProducao == value)return;
                 this._valueLoteProducao = value; 
            } 
        } 

       protected double _qtdContainerOriginal{get;private set;}
       private double _qtdContainerOriginalCommited{get; set;}
        private double _valueQtdContainer;
         [Column("prk_qtd_container")]
        public virtual double QtdContainer
         { 
            get { return this._valueQtdContainer; } 
            set 
            { 
                if (this._valueQtdContainer == value)return;
                 this._valueQtdContainer = value; 
            } 
        } 

       protected bool _utilizaDimensaoQuantidadeBaixaOriginal{get;private set;}
       private bool _utilizaDimensaoQuantidadeBaixaOriginalCommited{get; set;}
        private bool _valueUtilizaDimensaoQuantidadeBaixa;
         [Column("prk_utiliza_dimensao_quantidade_baixa")]
        public virtual bool UtilizaDimensaoQuantidadeBaixa
         { 
            get { return this._valueUtilizaDimensaoQuantidadeBaixa; } 
            set 
            { 
                if (this._valueUtilizaDimensaoQuantidadeBaixa == value)return;
                 this._valueUtilizaDimensaoQuantidadeBaixa = value; 
            } 
        } 

       protected EstoqueSeguranca _utilizandoEstoqueSegurancaOriginal{get;private set;}
       private EstoqueSeguranca _utilizandoEstoqueSegurancaOriginalCommited{get; set;}
        private EstoqueSeguranca _valueUtilizandoEstoqueSeguranca;
         [Column("prk_utilizando_estoque_seguranca")]
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
         [Column("prk_utilizando_estoque_seguranca_data")]
        public virtual DateTime? UtilizandoEstoqueSegurancaData
         { 
            get { return this._valueUtilizandoEstoqueSegurancaData; } 
            set 
            { 
                if (this._valueUtilizandoEstoqueSegurancaData == value)return;
                 this._valueUtilizandoEstoqueSegurancaData = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("prk_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       private List<long> _collectionEstoqueGavetaItemClassProdutoKOriginal;
       private List<Entidades.EstoqueGavetaItemClass > _collectionEstoqueGavetaItemClassProdutoKRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassProdutoKLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassProdutoKChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassProdutoKCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueGavetaItemClass> _valueCollectionEstoqueGavetaItemClassProdutoK { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueGavetaItemClass> CollectionEstoqueGavetaItemClassProdutoK 
       { 
           get { if(!_valueCollectionEstoqueGavetaItemClassProdutoKLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueGavetaItemClassProdutoK();}
return this._valueCollectionEstoqueGavetaItemClassProdutoK; } 
           set 
           { 
               this._valueCollectionEstoqueGavetaItemClassProdutoK = value; 
               this._valueCollectionEstoqueGavetaItemClassProdutoKLoaded = true; 
           } 
       } 

       private List<long> _collectionKanbanAcionamentoClassProdutoKOriginal;
       private List<Entidades.KanbanAcionamentoClass > _collectionKanbanAcionamentoClassProdutoKRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassProdutoKLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassProdutoKChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassProdutoKCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.KanbanAcionamentoClass> _valueCollectionKanbanAcionamentoClassProdutoK { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.KanbanAcionamentoClass> CollectionKanbanAcionamentoClassProdutoK 
       { 
           get { if(!_valueCollectionKanbanAcionamentoClassProdutoKLoaded && !this.DisableLoadCollection){this.LoadCollectionKanbanAcionamentoClassProdutoK();}
return this._valueCollectionKanbanAcionamentoClassProdutoK; } 
           set 
           { 
               this._valueCollectionKanbanAcionamentoClassProdutoK = value; 
               this._valueCollectionKanbanAcionamentoClassProdutoKLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoConfiguradoClassProdutoKOriginal;
       private List<Entidades.OrcamentoConfiguradoClass > _collectionOrcamentoConfiguradoClassProdutoKRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassProdutoKLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassProdutoKChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassProdutoKCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoConfiguradoClass> _valueCollectionOrcamentoConfiguradoClassProdutoK { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoConfiguradoClass> CollectionOrcamentoConfiguradoClassProdutoK 
       { 
           get { if(!_valueCollectionOrcamentoConfiguradoClassProdutoKLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoConfiguradoClassProdutoK();}
return this._valueCollectionOrcamentoConfiguradoClassProdutoK; } 
           set 
           { 
               this._valueCollectionOrcamentoConfiguradoClassProdutoK = value; 
               this._valueCollectionOrcamentoConfiguradoClassProdutoKLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoClassProdutoKOriginal;
       private List<Entidades.OrdemProducaoClass > _collectionOrdemProducaoClassProdutoKRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassProdutoKLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassProdutoKChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassProdutoKCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoClass> _valueCollectionOrdemProducaoClassProdutoK { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoClass> CollectionOrdemProducaoClassProdutoK 
       { 
           get { if(!_valueCollectionOrdemProducaoClassProdutoKLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoClassProdutoK();}
return this._valueCollectionOrdemProducaoClassProdutoK; } 
           set 
           { 
               this._valueCollectionOrdemProducaoClassProdutoK = value; 
               this._valueCollectionOrdemProducaoClassProdutoKLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoProdutoComponenteClassProdutoKOriginal;
       private List<Entidades.OrdemProducaoProdutoComponenteClass > _collectionOrdemProducaoProdutoComponenteClassProdutoKRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoProdutoComponenteClass> _valueCollectionOrdemProducaoProdutoComponenteClassProdutoK { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoProdutoComponenteClass> CollectionOrdemProducaoProdutoComponenteClassProdutoK 
       { 
           get { if(!_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoProdutoComponenteClassProdutoK();}
return this._valueCollectionOrdemProducaoProdutoComponenteClassProdutoK; } 
           set 
           { 
               this._valueCollectionOrdemProducaoProdutoComponenteClassProdutoK = value; 
               this._valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaClassProdutoKOriginal;
       private List<Entidades.OrderItemEtiquetaClass > _collectionOrderItemEtiquetaClassProdutoKRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassProdutoKLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassProdutoKChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassProdutoKCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaClass> _valueCollectionOrderItemEtiquetaClassProdutoK { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaClass> CollectionOrderItemEtiquetaClassProdutoK 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaClassProdutoKLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaClassProdutoK();}
return this._valueCollectionOrderItemEtiquetaClassProdutoK; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaClassProdutoK = value; 
               this._valueCollectionOrderItemEtiquetaClassProdutoKLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoKEtiquetaClassProdutoKOriginal;
       private List<Entidades.ProdutoKEtiquetaClass > _collectionProdutoKEtiquetaClassProdutoKRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKEtiquetaClassProdutoKLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKEtiquetaClassProdutoKChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKEtiquetaClassProdutoKCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoKEtiquetaClass> _valueCollectionProdutoKEtiquetaClassProdutoK { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoKEtiquetaClass> CollectionProdutoKEtiquetaClassProdutoK 
       { 
           get { if(!_valueCollectionProdutoKEtiquetaClassProdutoKLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoKEtiquetaClassProdutoK();}
return this._valueCollectionProdutoKEtiquetaClassProdutoK; } 
           set 
           { 
               this._valueCollectionProdutoKEtiquetaClassProdutoK = value; 
               this._valueCollectionProdutoKEtiquetaClassProdutoKLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoKProdutoClassProdutoKOriginal;
       private List<Entidades.ProdutoKProdutoClass > _collectionProdutoKProdutoClassProdutoKRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKProdutoClassProdutoKLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKProdutoClassProdutoKChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKProdutoClassProdutoKCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoKProdutoClass> _valueCollectionProdutoKProdutoClassProdutoK { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoKProdutoClass> CollectionProdutoKProdutoClassProdutoK 
       { 
           get { if(!_valueCollectionProdutoKProdutoClassProdutoKLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoKProdutoClassProdutoK();}
return this._valueCollectionProdutoKProdutoClassProdutoK; } 
           set 
           { 
               this._valueCollectionProdutoKProdutoClassProdutoK = value; 
               this._valueCollectionProdutoKProdutoClassProdutoKLoaded = true; 
           } 
       } 

        public ProdutoKBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Ativo = true;
           this.ImprimeEtiqueta = true;
           this.EmiteOp = true;
           this.Verde = 0;
           this.Amarelo = 0;
           this.Vermelho = 0;
           this.LoteProducao = 0;
           this.QtdContainer = 0;
           this.UtilizaDimensaoQuantidadeBaixa = false;
           this.UtilizandoEstoqueSeguranca = (EstoqueSeguranca)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ProdutoKClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProdutoKClass) GetEntity(typeof(ProdutoKClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEstoqueGavetaItemClassProdutoKChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueGavetaItemClassProdutoKChanged = true;
                  _valueCollectionEstoqueGavetaItemClassProdutoKCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueGavetaItemClassProdutoKChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassProdutoKCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in e.OldItems) 
                 { 
                     _collectionEstoqueGavetaItemClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueGavetaItemClassProdutoKChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassProdutoKCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in _valueCollectionEstoqueGavetaItemClassProdutoK) 
                 { 
                     _collectionEstoqueGavetaItemClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueGavetaItemClassProdutoK()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueGavetaItemClass> oc;
                _valueCollectionEstoqueGavetaItemClassProdutoKChanged = false;
                 _valueCollectionEstoqueGavetaItemClassProdutoKCommitedChanged = false;
                _collectionEstoqueGavetaItemClassProdutoKRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueGavetaItemClass>();
                }
                else{ 
                   Entidades.EstoqueGavetaItemClass search = new Entidades.EstoqueGavetaItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueGavetaItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoK", this),                     }                       ).Cast<Entidades.EstoqueGavetaItemClass>().ToList());
                 }
                 _valueCollectionEstoqueGavetaItemClassProdutoK = new BindingList<Entidades.EstoqueGavetaItemClass>(oc); 
                 _collectionEstoqueGavetaItemClassProdutoKOriginal= (from a in _valueCollectionEstoqueGavetaItemClassProdutoK select a.ID).ToList();
                 _valueCollectionEstoqueGavetaItemClassProdutoKLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueGavetaItemClassProdutoKChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueGavetaItemClassProdutoK+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionKanbanAcionamentoClassProdutoKChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionKanbanAcionamentoClassProdutoKChanged = true;
                  _valueCollectionKanbanAcionamentoClassProdutoKCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionKanbanAcionamentoClassProdutoKChanged = true; 
                  _valueCollectionKanbanAcionamentoClassProdutoKCommitedChanged = true;
                 foreach (Entidades.KanbanAcionamentoClass item in e.OldItems) 
                 { 
                     _collectionKanbanAcionamentoClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionKanbanAcionamentoClassProdutoKChanged = true; 
                  _valueCollectionKanbanAcionamentoClassProdutoKCommitedChanged = true;
                 foreach (Entidades.KanbanAcionamentoClass item in _valueCollectionKanbanAcionamentoClassProdutoK) 
                 { 
                     _collectionKanbanAcionamentoClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionKanbanAcionamentoClassProdutoK()
         {
            try
            {
                 ObservableCollection<Entidades.KanbanAcionamentoClass> oc;
                _valueCollectionKanbanAcionamentoClassProdutoKChanged = false;
                 _valueCollectionKanbanAcionamentoClassProdutoKCommitedChanged = false;
                _collectionKanbanAcionamentoClassProdutoKRemovidos = new List<Entidades.KanbanAcionamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.KanbanAcionamentoClass>();
                }
                else{ 
                   Entidades.KanbanAcionamentoClass search = new Entidades.KanbanAcionamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.KanbanAcionamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoK", this),                     }                       ).Cast<Entidades.KanbanAcionamentoClass>().ToList());
                 }
                 _valueCollectionKanbanAcionamentoClassProdutoK = new BindingList<Entidades.KanbanAcionamentoClass>(oc); 
                 _collectionKanbanAcionamentoClassProdutoKOriginal= (from a in _valueCollectionKanbanAcionamentoClassProdutoK select a.ID).ToList();
                 _valueCollectionKanbanAcionamentoClassProdutoKLoaded = true;
                 oc.CollectionChanged += CollectionKanbanAcionamentoClassProdutoKChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionKanbanAcionamentoClassProdutoK+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoConfiguradoClassProdutoKChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoConfiguradoClassProdutoKChanged = true;
                  _valueCollectionOrcamentoConfiguradoClassProdutoKCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoConfiguradoClassProdutoKChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassProdutoKCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoConfiguradoClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoConfiguradoClassProdutoKChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassProdutoKCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in _valueCollectionOrcamentoConfiguradoClassProdutoK) 
                 { 
                     _collectionOrcamentoConfiguradoClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoConfiguradoClassProdutoK()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoConfiguradoClass> oc;
                _valueCollectionOrcamentoConfiguradoClassProdutoKChanged = false;
                 _valueCollectionOrcamentoConfiguradoClassProdutoKCommitedChanged = false;
                _collectionOrcamentoConfiguradoClassProdutoKRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoConfiguradoClass>();
                }
                else{ 
                   Entidades.OrcamentoConfiguradoClass search = new Entidades.OrcamentoConfiguradoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoConfiguradoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoK", this),                     }                       ).Cast<Entidades.OrcamentoConfiguradoClass>().ToList());
                 }
                 _valueCollectionOrcamentoConfiguradoClassProdutoK = new BindingList<Entidades.OrcamentoConfiguradoClass>(oc); 
                 _collectionOrcamentoConfiguradoClassProdutoKOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassProdutoK select a.ID).ToList();
                 _valueCollectionOrcamentoConfiguradoClassProdutoKLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoConfiguradoClassProdutoKChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoConfiguradoClassProdutoK+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoClassProdutoKChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoClassProdutoKChanged = true;
                  _valueCollectionOrdemProducaoClassProdutoKCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoClassProdutoKChanged = true; 
                  _valueCollectionOrdemProducaoClassProdutoKCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoClassProdutoKChanged = true; 
                  _valueCollectionOrdemProducaoClassProdutoKCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoClass item in _valueCollectionOrdemProducaoClassProdutoK) 
                 { 
                     _collectionOrdemProducaoClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoClassProdutoK()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoClass> oc;
                _valueCollectionOrdemProducaoClassProdutoKChanged = false;
                 _valueCollectionOrdemProducaoClassProdutoKCommitedChanged = false;
                _collectionOrdemProducaoClassProdutoKRemovidos = new List<Entidades.OrdemProducaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoClass search = new Entidades.OrdemProducaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoK", this)                    }                       ).Cast<Entidades.OrdemProducaoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoClassProdutoK = new BindingList<Entidades.OrdemProducaoClass>(oc); 
                 _collectionOrdemProducaoClassProdutoKOriginal= (from a in _valueCollectionOrdemProducaoClassProdutoK select a.ID).ToList();
                 _valueCollectionOrdemProducaoClassProdutoKLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoClassProdutoKChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoClassProdutoK+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoProdutoComponenteClassProdutoKChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKChanged = true;
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKChanged = true; 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoProdutoComponenteClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoProdutoComponenteClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKChanged = true; 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoProdutoComponenteClass item in _valueCollectionOrdemProducaoProdutoComponenteClassProdutoK) 
                 { 
                     _collectionOrdemProducaoProdutoComponenteClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoProdutoComponenteClassProdutoK()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoProdutoComponenteClass> oc;
                _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKChanged = false;
                 _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKCommitedChanged = false;
                _collectionOrdemProducaoProdutoComponenteClassProdutoKRemovidos = new List<Entidades.OrdemProducaoProdutoComponenteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoProdutoComponenteClass>();
                }
                else{ 
                   Entidades.OrdemProducaoProdutoComponenteClass search = new Entidades.OrdemProducaoProdutoComponenteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoProdutoComponenteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoK", this),                     }                       ).Cast<Entidades.OrdemProducaoProdutoComponenteClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoProdutoComponenteClassProdutoK = new BindingList<Entidades.OrdemProducaoProdutoComponenteClass>(oc); 
                 _collectionOrdemProducaoProdutoComponenteClassProdutoKOriginal= (from a in _valueCollectionOrdemProducaoProdutoComponenteClassProdutoK select a.ID).ToList();
                 _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoProdutoComponenteClassProdutoKChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoProdutoComponenteClassProdutoK+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaClassProdutoKChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaClassProdutoKChanged = true;
                  _valueCollectionOrderItemEtiquetaClassProdutoKCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaClassProdutoKChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassProdutoKCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaClassProdutoKChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassProdutoKCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in _valueCollectionOrderItemEtiquetaClassProdutoK) 
                 { 
                     _collectionOrderItemEtiquetaClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaClassProdutoK()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaClass> oc;
                _valueCollectionOrderItemEtiquetaClassProdutoKChanged = false;
                 _valueCollectionOrderItemEtiquetaClassProdutoKCommitedChanged = false;
                _collectionOrderItemEtiquetaClassProdutoKRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaClass search = new Entidades.OrderItemEtiquetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoK", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaClassProdutoK = new BindingList<Entidades.OrderItemEtiquetaClass>(oc); 
                 _collectionOrderItemEtiquetaClassProdutoKOriginal= (from a in _valueCollectionOrderItemEtiquetaClassProdutoK select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaClassProdutoKLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaClassProdutoKChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaClassProdutoK+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoKEtiquetaClassProdutoKChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoKEtiquetaClassProdutoKChanged = true;
                  _valueCollectionProdutoKEtiquetaClassProdutoKCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoKEtiquetaClassProdutoKChanged = true; 
                  _valueCollectionProdutoKEtiquetaClassProdutoKCommitedChanged = true;
                 foreach (Entidades.ProdutoKEtiquetaClass item in e.OldItems) 
                 { 
                     _collectionProdutoKEtiquetaClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoKEtiquetaClassProdutoKChanged = true; 
                  _valueCollectionProdutoKEtiquetaClassProdutoKCommitedChanged = true;
                 foreach (Entidades.ProdutoKEtiquetaClass item in _valueCollectionProdutoKEtiquetaClassProdutoK) 
                 { 
                     _collectionProdutoKEtiquetaClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoKEtiquetaClassProdutoK()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoKEtiquetaClass> oc;
                _valueCollectionProdutoKEtiquetaClassProdutoKChanged = false;
                 _valueCollectionProdutoKEtiquetaClassProdutoKCommitedChanged = false;
                _collectionProdutoKEtiquetaClassProdutoKRemovidos = new List<Entidades.ProdutoKEtiquetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoKEtiquetaClass>();
                }
                else{ 
                   Entidades.ProdutoKEtiquetaClass search = new Entidades.ProdutoKEtiquetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoKEtiquetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoK", this)                    }                       ).Cast<Entidades.ProdutoKEtiquetaClass>().ToList());
                 }
                 _valueCollectionProdutoKEtiquetaClassProdutoK = new BindingList<Entidades.ProdutoKEtiquetaClass>(oc); 
                 _collectionProdutoKEtiquetaClassProdutoKOriginal= (from a in _valueCollectionProdutoKEtiquetaClassProdutoK select a.ID).ToList();
                 _valueCollectionProdutoKEtiquetaClassProdutoKLoaded = true;
                 oc.CollectionChanged += CollectionProdutoKEtiquetaClassProdutoKChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoKEtiquetaClassProdutoK+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoKProdutoClassProdutoKChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoKProdutoClassProdutoKChanged = true;
                  _valueCollectionProdutoKProdutoClassProdutoKCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoKProdutoClassProdutoKChanged = true; 
                  _valueCollectionProdutoKProdutoClassProdutoKCommitedChanged = true;
                 foreach (Entidades.ProdutoKProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoKProdutoClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoKProdutoClassProdutoKChanged = true; 
                  _valueCollectionProdutoKProdutoClassProdutoKCommitedChanged = true;
                 foreach (Entidades.ProdutoKProdutoClass item in _valueCollectionProdutoKProdutoClassProdutoK) 
                 { 
                     _collectionProdutoKProdutoClassProdutoKRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoKProdutoClassProdutoK()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoKProdutoClass> oc;
                _valueCollectionProdutoKProdutoClassProdutoKChanged = false;
                 _valueCollectionProdutoKProdutoClassProdutoKCommitedChanged = false;
                _collectionProdutoKProdutoClassProdutoKRemovidos = new List<Entidades.ProdutoKProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoKProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoKProdutoClass search = new Entidades.ProdutoKProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoKProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoK", this)                    }                       ).Cast<Entidades.ProdutoKProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoKProdutoClassProdutoK = new BindingList<Entidades.ProdutoKProdutoClass>(oc); 
                 _collectionProdutoKProdutoClassProdutoKOriginal= (from a in _valueCollectionProdutoKProdutoClassProdutoK select a.ID).ToList();
                 _valueCollectionProdutoKProdutoClassProdutoKLoaded = true;
                 oc.CollectionChanged += CollectionProdutoKProdutoClassProdutoKChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoKProdutoClassProdutoK+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Codigo))
                {
                    throw new Exception(ErroCodigoObrigatorio);
                }
                if (Codigo.Length >255)
                {
                    throw new Exception( ErroCodigoComprimento);
                }
                if (string.IsNullOrEmpty(Dimensao))
                {
                    throw new Exception(ErroDimensaoObrigatorio);
                }
                if (Dimensao.Length >255)
                {
                    throw new Exception( ErroDimensaoComprimento);
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
                    "  public.produto_k  " +
                    "WHERE " +
                    "  id_produto_k = :id";
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
                        "  public.produto_k   " +
                        "SET  " + 
                        "  id_classificacao_produto = :id_classificacao_produto, " + 
                        "  prk_codigo = :prk_codigo, " + 
                        "  prk_dimensao = :prk_dimensao, " + 
                        "  prk_ativo = :prk_ativo, " + 
                        "  prk_imprime_etiqueta = :prk_imprime_etiqueta, " + 
                        "  prk_emite_op = :prk_emite_op, " + 
                        "  prk_verde = :prk_verde, " + 
                        "  prk_amarelo = :prk_amarelo, " + 
                        "  prk_vermelho = :prk_vermelho, " + 
                        "  prk_lote_producao = :prk_lote_producao, " + 
                        "  prk_qtd_container = :prk_qtd_container, " + 
                        "  prk_ultima_revisao = :prk_ultima_revisao, " + 
                        "  prk_ultima_revisao_data = :prk_ultima_revisao_data, " + 
                        "  prk_utiliza_dimensao_quantidade_baixa = :prk_utiliza_dimensao_quantidade_baixa, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  prk_utilizando_estoque_seguranca = :prk_utilizando_estoque_seguranca, " + 
                        "  prk_utilizando_estoque_seguranca_data = :prk_utilizando_estoque_seguranca_data, " + 
                        "  prk_descricao = :prk_descricao "+
                        "WHERE  " +
                        "  id_produto_k = :id " +
                        "RETURNING id_produto_k;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.produto_k " +
                        "( " +
                        "  id_classificacao_produto , " + 
                        "  prk_codigo , " + 
                        "  prk_dimensao , " + 
                        "  prk_ativo , " + 
                        "  prk_imprime_etiqueta , " + 
                        "  prk_emite_op , " + 
                        "  prk_verde , " + 
                        "  prk_amarelo , " + 
                        "  prk_vermelho , " + 
                        "  prk_lote_producao , " + 
                        "  prk_qtd_container , " + 
                        "  prk_ultima_revisao , " + 
                        "  prk_ultima_revisao_data , " + 
                        "  prk_utiliza_dimensao_quantidade_baixa , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  prk_utilizando_estoque_seguranca , " + 
                        "  prk_utilizando_estoque_seguranca_data , " + 
                        "  prk_descricao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_classificacao_produto , " + 
                        "  :prk_codigo , " + 
                        "  :prk_dimensao , " + 
                        "  :prk_ativo , " + 
                        "  :prk_imprime_etiqueta , " + 
                        "  :prk_emite_op , " + 
                        "  :prk_verde , " + 
                        "  :prk_amarelo , " + 
                        "  :prk_vermelho , " + 
                        "  :prk_lote_producao , " + 
                        "  :prk_qtd_container , " + 
                        "  :prk_ultima_revisao , " + 
                        "  :prk_ultima_revisao_data , " + 
                        "  :prk_utiliza_dimensao_quantidade_baixa , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :prk_utilizando_estoque_seguranca , " + 
                        "  :prk_utilizando_estoque_seguranca_data , " + 
                        "  :prk_descricao  "+
                        ")RETURNING id_produto_k;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_classificacao_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ClassificacaoProduto==null ? (object) DBNull.Value : this.ClassificacaoProduto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_dimensao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Dimensao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_imprime_etiqueta", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImprimeEtiqueta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_emite_op", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmiteOp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_verde", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Verde ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_amarelo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Amarelo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_vermelho", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Vermelho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_lote_producao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LoteProducao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_qtd_container", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdContainer ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_utiliza_dimensao_quantidade_baixa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UtilizaDimensaoQuantidadeBaixa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_utilizando_estoque_seguranca", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.UtilizandoEstoqueSeguranca);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_utilizando_estoque_seguranca_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UtilizandoEstoqueSegurancaData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prk_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;

 
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
 if (CollectionEstoqueGavetaItemClassProdutoK.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueGavetaItemClassProdutoK+"\r\n";
                foreach (Entidades.EstoqueGavetaItemClass tmp in CollectionEstoqueGavetaItemClassProdutoK)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionKanbanAcionamentoClassProdutoK.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionKanbanAcionamentoClassProdutoK+"\r\n";
                foreach (Entidades.KanbanAcionamentoClass tmp in CollectionKanbanAcionamentoClassProdutoK)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoConfiguradoClassProdutoK.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoConfiguradoClassProdutoK+"\r\n";
                foreach (Entidades.OrcamentoConfiguradoClass tmp in CollectionOrcamentoConfiguradoClassProdutoK)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoClassProdutoK.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoClassProdutoK+"\r\n";
                foreach (Entidades.OrdemProducaoClass tmp in CollectionOrdemProducaoClassProdutoK)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoProdutoComponenteClassProdutoK.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoProdutoComponenteClassProdutoK+"\r\n";
                foreach (Entidades.OrdemProducaoProdutoComponenteClass tmp in CollectionOrdemProducaoProdutoComponenteClassProdutoK)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaClassProdutoK.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaClassProdutoK+"\r\n";
                foreach (Entidades.OrderItemEtiquetaClass tmp in CollectionOrderItemEtiquetaClassProdutoK)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoKEtiquetaClassProdutoK.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoKEtiquetaClassProdutoK+"\r\n";
                foreach (Entidades.ProdutoKEtiquetaClass tmp in CollectionProdutoKEtiquetaClassProdutoK)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoKProdutoClassProdutoK.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoKProdutoClassProdutoK+"\r\n";
                foreach (Entidades.ProdutoKProdutoClass tmp in CollectionProdutoKProdutoClassProdutoK)
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
        public static ProdutoKClass CopiarEntidade(ProdutoKClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProdutoKClass toRet = new ProdutoKClass(usuario,conn);
 toRet.ClassificacaoProduto= entidadeCopiar.ClassificacaoProduto;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Dimensao= entidadeCopiar.Dimensao;
 toRet.Ativo= entidadeCopiar.Ativo;
 toRet.ImprimeEtiqueta= entidadeCopiar.ImprimeEtiqueta;
 toRet.EmiteOp= entidadeCopiar.EmiteOp;
 toRet.Verde= entidadeCopiar.Verde;
 toRet.Amarelo= entidadeCopiar.Amarelo;
 toRet.Vermelho= entidadeCopiar.Vermelho;
 toRet.LoteProducao= entidadeCopiar.LoteProducao;
 toRet.QtdContainer= entidadeCopiar.QtdContainer;
 toRet.UtilizaDimensaoQuantidadeBaixa= entidadeCopiar.UtilizaDimensaoQuantidadeBaixa;
 toRet.UtilizandoEstoqueSeguranca= entidadeCopiar.UtilizandoEstoqueSeguranca;
 toRet.UtilizandoEstoqueSegurancaData= entidadeCopiar.UtilizandoEstoqueSegurancaData;
 toRet.Descricao= entidadeCopiar.Descricao;

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
       _classificacaoProdutoOriginal = ClassificacaoProduto;
       _classificacaoProdutoOriginalCommited = _classificacaoProdutoOriginal;
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _dimensaoOriginal = Dimensao;
       _dimensaoOriginalCommited = _dimensaoOriginal;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;
       _imprimeEtiquetaOriginal = ImprimeEtiqueta;
       _imprimeEtiquetaOriginalCommited = _imprimeEtiquetaOriginal;
       _emiteOpOriginal = EmiteOp;
       _emiteOpOriginalCommited = _emiteOpOriginal;
       _verdeOriginal = Verde;
       _verdeOriginalCommited = _verdeOriginal;
       _amareloOriginal = Amarelo;
       _amareloOriginalCommited = _amareloOriginal;
       _vermelhoOriginal = Vermelho;
       _vermelhoOriginalCommited = _vermelhoOriginal;
       _loteProducaoOriginal = LoteProducao;
       _loteProducaoOriginalCommited = _loteProducaoOriginal;
       _qtdContainerOriginal = QtdContainer;
       _qtdContainerOriginalCommited = _qtdContainerOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _utilizaDimensaoQuantidadeBaixaOriginal = UtilizaDimensaoQuantidadeBaixa;
       _utilizaDimensaoQuantidadeBaixaOriginalCommited = _utilizaDimensaoQuantidadeBaixaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _utilizandoEstoqueSegurancaOriginal = UtilizandoEstoqueSeguranca;
       _utilizandoEstoqueSegurancaOriginalCommited = _utilizandoEstoqueSegurancaOriginal;
       _utilizandoEstoqueSegurancaDataOriginal = UtilizandoEstoqueSegurancaData;
       _utilizandoEstoqueSegurancaDataOriginalCommited = _utilizandoEstoqueSegurancaDataOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;

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
       _classificacaoProdutoOriginalCommited = ClassificacaoProduto;
       _codigoOriginalCommited = Codigo;
       _dimensaoOriginalCommited = Dimensao;
       _ativoOriginalCommited = Ativo;
       _imprimeEtiquetaOriginalCommited = ImprimeEtiqueta;
       _emiteOpOriginalCommited = EmiteOp;
       _verdeOriginalCommited = Verde;
       _amareloOriginalCommited = Amarelo;
       _vermelhoOriginalCommited = Vermelho;
       _loteProducaoOriginalCommited = LoteProducao;
       _qtdContainerOriginalCommited = QtdContainer;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _utilizaDimensaoQuantidadeBaixaOriginalCommited = UtilizaDimensaoQuantidadeBaixa;
       _versionOriginalCommited = Version;
       _utilizandoEstoqueSegurancaOriginalCommited = UtilizandoEstoqueSeguranca;
       _utilizandoEstoqueSegurancaDataOriginalCommited = UtilizandoEstoqueSegurancaData;
       _descricaoOriginalCommited = Descricao;

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
               if (_valueCollectionEstoqueGavetaItemClassProdutoKLoaded) 
               {
                  if (_collectionEstoqueGavetaItemClassProdutoKRemovidos != null) 
                  {
                     _collectionEstoqueGavetaItemClassProdutoKRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueGavetaItemClassProdutoKRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                  }
                  _collectionEstoqueGavetaItemClassProdutoKOriginal= (from a in _valueCollectionEstoqueGavetaItemClassProdutoK select a.ID).ToList();
                  _valueCollectionEstoqueGavetaItemClassProdutoKChanged = false;
                  _valueCollectionEstoqueGavetaItemClassProdutoKCommitedChanged = false;
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoKLoaded) 
               {
                  if (_collectionKanbanAcionamentoClassProdutoKRemovidos != null) 
                  {
                     _collectionKanbanAcionamentoClassProdutoKRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionKanbanAcionamentoClassProdutoKRemovidos = new List<Entidades.KanbanAcionamentoClass>();
                  }
                  _collectionKanbanAcionamentoClassProdutoKOriginal= (from a in _valueCollectionKanbanAcionamentoClassProdutoK select a.ID).ToList();
                  _valueCollectionKanbanAcionamentoClassProdutoKChanged = false;
                  _valueCollectionKanbanAcionamentoClassProdutoKCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoKLoaded) 
               {
                  if (_collectionOrcamentoConfiguradoClassProdutoKRemovidos != null) 
                  {
                     _collectionOrcamentoConfiguradoClassProdutoKRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoConfiguradoClassProdutoKRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                  }
                  _collectionOrcamentoConfiguradoClassProdutoKOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassProdutoK select a.ID).ToList();
                  _valueCollectionOrcamentoConfiguradoClassProdutoKChanged = false;
                  _valueCollectionOrcamentoConfiguradoClassProdutoKCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoClassProdutoKLoaded) 
               {
                  if (_collectionOrdemProducaoClassProdutoKRemovidos != null) 
                  {
                     _collectionOrdemProducaoClassProdutoKRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoClassProdutoKRemovidos = new List<Entidades.OrdemProducaoClass>();
                  }
                  _collectionOrdemProducaoClassProdutoKOriginal= (from a in _valueCollectionOrdemProducaoClassProdutoK select a.ID).ToList();
                  _valueCollectionOrdemProducaoClassProdutoKChanged = false;
                  _valueCollectionOrdemProducaoClassProdutoKCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded) 
               {
                  if (_collectionOrdemProducaoProdutoComponenteClassProdutoKRemovidos != null) 
                  {
                     _collectionOrdemProducaoProdutoComponenteClassProdutoKRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoProdutoComponenteClassProdutoKRemovidos = new List<Entidades.OrdemProducaoProdutoComponenteClass>();
                  }
                  _collectionOrdemProducaoProdutoComponenteClassProdutoKOriginal= (from a in _valueCollectionOrdemProducaoProdutoComponenteClassProdutoK select a.ID).ToList();
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKChanged = false;
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoKCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoKLoaded) 
               {
                  if (_collectionOrderItemEtiquetaClassProdutoKRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaClassProdutoKRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaClassProdutoKRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                  }
                  _collectionOrderItemEtiquetaClassProdutoKOriginal= (from a in _valueCollectionOrderItemEtiquetaClassProdutoK select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaClassProdutoKChanged = false;
                  _valueCollectionOrderItemEtiquetaClassProdutoKCommitedChanged = false;
               }
               if (_valueCollectionProdutoKEtiquetaClassProdutoKLoaded) 
               {
                  if (_collectionProdutoKEtiquetaClassProdutoKRemovidos != null) 
                  {
                     _collectionProdutoKEtiquetaClassProdutoKRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoKEtiquetaClassProdutoKRemovidos = new List<Entidades.ProdutoKEtiquetaClass>();
                  }
                  _collectionProdutoKEtiquetaClassProdutoKOriginal= (from a in _valueCollectionProdutoKEtiquetaClassProdutoK select a.ID).ToList();
                  _valueCollectionProdutoKEtiquetaClassProdutoKChanged = false;
                  _valueCollectionProdutoKEtiquetaClassProdutoKCommitedChanged = false;
               }
               if (_valueCollectionProdutoKProdutoClassProdutoKLoaded) 
               {
                  if (_collectionProdutoKProdutoClassProdutoKRemovidos != null) 
                  {
                     _collectionProdutoKProdutoClassProdutoKRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoKProdutoClassProdutoKRemovidos = new List<Entidades.ProdutoKProdutoClass>();
                  }
                  _collectionProdutoKProdutoClassProdutoKOriginal= (from a in _valueCollectionProdutoKProdutoClassProdutoK select a.ID).ToList();
                  _valueCollectionProdutoKProdutoClassProdutoKChanged = false;
                  _valueCollectionProdutoKProdutoClassProdutoKCommitedChanged = false;
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
               ClassificacaoProduto=_classificacaoProdutoOriginal;
               _classificacaoProdutoOriginalCommited=_classificacaoProdutoOriginal;
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               Dimensao=_dimensaoOriginal;
               _dimensaoOriginalCommited=_dimensaoOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               ImprimeEtiqueta=_imprimeEtiquetaOriginal;
               _imprimeEtiquetaOriginalCommited=_imprimeEtiquetaOriginal;
               EmiteOp=_emiteOpOriginal;
               _emiteOpOriginalCommited=_emiteOpOriginal;
               Verde=_verdeOriginal;
               _verdeOriginalCommited=_verdeOriginal;
               Amarelo=_amareloOriginal;
               _amareloOriginalCommited=_amareloOriginal;
               Vermelho=_vermelhoOriginal;
               _vermelhoOriginalCommited=_vermelhoOriginal;
               LoteProducao=_loteProducaoOriginal;
               _loteProducaoOriginalCommited=_loteProducaoOriginal;
               QtdContainer=_qtdContainerOriginal;
               _qtdContainerOriginalCommited=_qtdContainerOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               UtilizaDimensaoQuantidadeBaixa=_utilizaDimensaoQuantidadeBaixaOriginal;
               _utilizaDimensaoQuantidadeBaixaOriginalCommited=_utilizaDimensaoQuantidadeBaixaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               UtilizandoEstoqueSeguranca=_utilizandoEstoqueSegurancaOriginal;
               _utilizandoEstoqueSegurancaOriginalCommited=_utilizandoEstoqueSegurancaOriginal;
               UtilizandoEstoqueSegurancaData=_utilizandoEstoqueSegurancaDataOriginal;
               _utilizandoEstoqueSegurancaDataOriginalCommited=_utilizandoEstoqueSegurancaDataOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               if (_valueCollectionEstoqueGavetaItemClassProdutoKLoaded) 
               {
                  CollectionEstoqueGavetaItemClassProdutoK.Clear();
                  foreach(int item in _collectionEstoqueGavetaItemClassProdutoKOriginal)
                  {
                    CollectionEstoqueGavetaItemClassProdutoK.Add(Entidades.EstoqueGavetaItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueGavetaItemClassProdutoKRemovidos.Clear();
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoKLoaded) 
               {
                  CollectionKanbanAcionamentoClassProdutoK.Clear();
                  foreach(int item in _collectionKanbanAcionamentoClassProdutoKOriginal)
                  {
                    CollectionKanbanAcionamentoClassProdutoK.Add(Entidades.KanbanAcionamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionKanbanAcionamentoClassProdutoKRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoKLoaded) 
               {
                  CollectionOrcamentoConfiguradoClassProdutoK.Clear();
                  foreach(int item in _collectionOrcamentoConfiguradoClassProdutoKOriginal)
                  {
                    CollectionOrcamentoConfiguradoClassProdutoK.Add(Entidades.OrcamentoConfiguradoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoConfiguradoClassProdutoKRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoClassProdutoKLoaded) 
               {
                  CollectionOrdemProducaoClassProdutoK.Clear();
                  foreach(int item in _collectionOrdemProducaoClassProdutoKOriginal)
                  {
                    CollectionOrdemProducaoClassProdutoK.Add(Entidades.OrdemProducaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoClassProdutoKRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded) 
               {
                  CollectionOrdemProducaoProdutoComponenteClassProdutoK.Clear();
                  foreach(int item in _collectionOrdemProducaoProdutoComponenteClassProdutoKOriginal)
                  {
                    CollectionOrdemProducaoProdutoComponenteClassProdutoK.Add(Entidades.OrdemProducaoProdutoComponenteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoProdutoComponenteClassProdutoKRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoKLoaded) 
               {
                  CollectionOrderItemEtiquetaClassProdutoK.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaClassProdutoKOriginal)
                  {
                    CollectionOrderItemEtiquetaClassProdutoK.Add(Entidades.OrderItemEtiquetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaClassProdutoKRemovidos.Clear();
               }
               if (_valueCollectionProdutoKEtiquetaClassProdutoKLoaded) 
               {
                  CollectionProdutoKEtiquetaClassProdutoK.Clear();
                  foreach(int item in _collectionProdutoKEtiquetaClassProdutoKOriginal)
                  {
                    CollectionProdutoKEtiquetaClassProdutoK.Add(Entidades.ProdutoKEtiquetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoKEtiquetaClassProdutoKRemovidos.Clear();
               }
               if (_valueCollectionProdutoKProdutoClassProdutoKLoaded) 
               {
                  CollectionProdutoKProdutoClassProdutoK.Clear();
                  foreach(int item in _collectionProdutoKProdutoClassProdutoKOriginal)
                  {
                    CollectionProdutoKProdutoClassProdutoK.Add(Entidades.ProdutoKProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoKProdutoClassProdutoKRemovidos.Clear();
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
               if (_valueCollectionEstoqueGavetaItemClassProdutoKLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassProdutoKChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoKLoaded) 
               {
                  if (_valueCollectionKanbanAcionamentoClassProdutoKChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoKLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassProdutoKChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoClassProdutoKLoaded) 
               {
                  if (_valueCollectionOrdemProducaoClassProdutoKChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded) 
               {
                  if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoKLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassProdutoKChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoKEtiquetaClassProdutoKLoaded) 
               {
                  if (_valueCollectionProdutoKEtiquetaClassProdutoKChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoKProdutoClassProdutoKLoaded) 
               {
                  if (_valueCollectionProdutoKProdutoClassProdutoKChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoKLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassProdutoK.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoKLoaded) 
               {
                   tempRet = CollectionKanbanAcionamentoClassProdutoK.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoKLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassProdutoK.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoClassProdutoKLoaded) 
               {
                   tempRet = CollectionOrdemProducaoClassProdutoK.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded) 
               {
                   tempRet = CollectionOrdemProducaoProdutoComponenteClassProdutoK.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoKLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassProdutoK.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoKEtiquetaClassProdutoKLoaded) 
               {
                   tempRet = CollectionProdutoKEtiquetaClassProdutoK.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoKProdutoClassProdutoKLoaded) 
               {
                   tempRet = CollectionProdutoKProdutoClassProdutoK.Any(item => item.IsDirty());
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
       if (_classificacaoProdutoOriginal!=null)
       {
          dirty = !_classificacaoProdutoOriginal.Equals(ClassificacaoProduto);
       }
       else
       {
            dirty = ClassificacaoProduto != null;
       }
      if (dirty) return true;
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       dirty = _dimensaoOriginal != Dimensao;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;
      if (dirty) return true;
       dirty = _imprimeEtiquetaOriginal != ImprimeEtiqueta;
      if (dirty) return true;
       dirty = _emiteOpOriginal != EmiteOp;
      if (dirty) return true;
       dirty = _verdeOriginal != Verde;
      if (dirty) return true;
       dirty = _amareloOriginal != Amarelo;
      if (dirty) return true;
       dirty = _vermelhoOriginal != Vermelho;
      if (dirty) return true;
       dirty = _loteProducaoOriginal != LoteProducao;
      if (dirty) return true;
       dirty = _qtdContainerOriginal != QtdContainer;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
       dirty = _utilizaDimensaoQuantidadeBaixaOriginal != UtilizaDimensaoQuantidadeBaixa;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaOriginal != UtilizandoEstoqueSeguranca;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaDataOriginal != UtilizandoEstoqueSegurancaData;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;

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
               if (_valueCollectionEstoqueGavetaItemClassProdutoKLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassProdutoKCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoKLoaded) 
               {
                  if (_valueCollectionKanbanAcionamentoClassProdutoKCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoKLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassProdutoKCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoClassProdutoKLoaded) 
               {
                  if (_valueCollectionOrdemProducaoClassProdutoKCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded) 
               {
                  if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoKLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassProdutoKCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoKEtiquetaClassProdutoKLoaded) 
               {
                  if (_valueCollectionProdutoKEtiquetaClassProdutoKCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoKProdutoClassProdutoKLoaded) 
               {
                  if (_valueCollectionProdutoKProdutoClassProdutoKCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoKLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassProdutoK.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoKLoaded) 
               {
                   tempRet = CollectionKanbanAcionamentoClassProdutoK.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoKLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassProdutoK.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoClassProdutoKLoaded) 
               {
                   tempRet = CollectionOrdemProducaoClassProdutoK.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded) 
               {
                   tempRet = CollectionOrdemProducaoProdutoComponenteClassProdutoK.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoKLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassProdutoK.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoKEtiquetaClassProdutoKLoaded) 
               {
                   tempRet = CollectionProdutoKEtiquetaClassProdutoK.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoKProdutoClassProdutoKLoaded) 
               {
                   tempRet = CollectionProdutoKProdutoClassProdutoK.Any(item => item.IsDirtyCommited());
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
       if (_classificacaoProdutoOriginalCommited!=null)
       {
          dirty = !_classificacaoProdutoOriginalCommited.Equals(ClassificacaoProduto);
       }
       else
       {
            dirty = ClassificacaoProduto != null;
       }
      if (dirty) return true;
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       dirty = _dimensaoOriginalCommited != Dimensao;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;
      if (dirty) return true;
       dirty = _imprimeEtiquetaOriginalCommited != ImprimeEtiqueta;
      if (dirty) return true;
       dirty = _emiteOpOriginalCommited != EmiteOp;
      if (dirty) return true;
       dirty = _verdeOriginalCommited != Verde;
      if (dirty) return true;
       dirty = _amareloOriginalCommited != Amarelo;
      if (dirty) return true;
       dirty = _vermelhoOriginalCommited != Vermelho;
      if (dirty) return true;
       dirty = _loteProducaoOriginalCommited != LoteProducao;
      if (dirty) return true;
       dirty = _qtdContainerOriginalCommited != QtdContainer;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
       dirty = _utilizaDimensaoQuantidadeBaixaOriginalCommited != UtilizaDimensaoQuantidadeBaixa;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaOriginalCommited != UtilizandoEstoqueSeguranca;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaDataOriginalCommited != UtilizandoEstoqueSegurancaData;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;

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
               if (_valueCollectionEstoqueGavetaItemClassProdutoKLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassProdutoK)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoKLoaded) 
               {
                  foreach(KanbanAcionamentoClass item in CollectionKanbanAcionamentoClassProdutoK)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoKLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassProdutoK)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoClassProdutoKLoaded) 
               {
                  foreach(OrdemProducaoClass item in CollectionOrdemProducaoClassProdutoK)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded) 
               {
                  foreach(OrdemProducaoProdutoComponenteClass item in CollectionOrdemProducaoProdutoComponenteClassProdutoK)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoKLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassProdutoK)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoKEtiquetaClassProdutoKLoaded) 
               {
                  foreach(ProdutoKEtiquetaClass item in CollectionProdutoKEtiquetaClassProdutoK)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoKProdutoClassProdutoKLoaded) 
               {
                  foreach(ProdutoKProdutoClass item in CollectionProdutoKProdutoClassProdutoK)
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
             case "ClassificacaoProduto":
                return this.ClassificacaoProduto;
             case "Codigo":
                return this.Codigo;
             case "Dimensao":
                return this.Dimensao;
             case "Ativo":
                return this.Ativo;
             case "ImprimeEtiqueta":
                return this.ImprimeEtiqueta;
             case "EmiteOp":
                return this.EmiteOp;
             case "Verde":
                return this.Verde;
             case "Amarelo":
                return this.Amarelo;
             case "Vermelho":
                return this.Vermelho;
             case "LoteProducao":
                return this.LoteProducao;
             case "QtdContainer":
                return this.QtdContainer;
             case "UtilizaDimensaoQuantidadeBaixa":
                return this.UtilizaDimensaoQuantidadeBaixa;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "UtilizandoEstoqueSeguranca":
                return this.UtilizandoEstoqueSeguranca;
             case "UtilizandoEstoqueSegurancaData":
                return this.UtilizandoEstoqueSegurancaData;
             case "Descricao":
                return this.Descricao;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (ClassificacaoProduto!=null)
                ClassificacaoProduto.ChangeSingleConnection(newConnection);
               if (_valueCollectionEstoqueGavetaItemClassProdutoKLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassProdutoK)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoKLoaded) 
               {
                  foreach(KanbanAcionamentoClass item in CollectionKanbanAcionamentoClassProdutoK)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoKLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassProdutoK)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoClassProdutoKLoaded) 
               {
                  foreach(OrdemProducaoClass item in CollectionOrdemProducaoClassProdutoK)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoKLoaded) 
               {
                  foreach(OrdemProducaoProdutoComponenteClass item in CollectionOrdemProducaoProdutoComponenteClassProdutoK)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoKLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassProdutoK)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoKEtiquetaClassProdutoKLoaded) 
               {
                  foreach(ProdutoKEtiquetaClass item in CollectionProdutoKEtiquetaClassProdutoK)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoKProdutoClassProdutoKLoaded) 
               {
                  foreach(ProdutoKProdutoClass item in CollectionProdutoKProdutoClassProdutoK)
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
                  command.CommandText += " COUNT(produto_k.id_produto_k) " ;
               }
               else
               {
               command.CommandText += "produto_k.id_produto_k, " ;
               command.CommandText += "produto_k.id_classificacao_produto, " ;
               command.CommandText += "produto_k.prk_codigo, " ;
               command.CommandText += "produto_k.prk_dimensao, " ;
               command.CommandText += "produto_k.prk_ativo, " ;
               command.CommandText += "produto_k.prk_imprime_etiqueta, " ;
               command.CommandText += "produto_k.prk_emite_op, " ;
               command.CommandText += "produto_k.prk_verde, " ;
               command.CommandText += "produto_k.prk_amarelo, " ;
               command.CommandText += "produto_k.prk_vermelho, " ;
               command.CommandText += "produto_k.prk_lote_producao, " ;
               command.CommandText += "produto_k.prk_qtd_container, " ;
               command.CommandText += "produto_k.prk_ultima_revisao, " ;
               command.CommandText += "produto_k.prk_ultima_revisao_data, " ;
               command.CommandText += "produto_k.prk_utiliza_dimensao_quantidade_baixa, " ;
               command.CommandText += "produto_k.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "produto_k.entity_uid, " ;
               command.CommandText += "produto_k.version, " ;
               command.CommandText += "produto_k.prk_utilizando_estoque_seguranca, " ;
               command.CommandText += "produto_k.prk_utilizando_estoque_seguranca_data, " ;
               command.CommandText += "produto_k.prk_descricao " ;
               }
               command.CommandText += " FROM  produto_k ";
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
                        orderByClause += " , prk_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(prk_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = produto_k.id_acs_usuario_ultima_revisao ";
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
                     case "id_produto_k":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.id_produto_k " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.id_produto_k) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_classificacao_produto":
                     case "ClassificacaoProduto":
                     command.CommandText += " LEFT JOIN classificacao_produto as classificacao_produto_ClassificacaoProduto ON classificacao_produto_ClassificacaoProduto.id_classificacao_produto = produto_k.id_classificacao_produto ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , classificacao_produto_ClassificacaoProduto.clp_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(classificacao_produto_ClassificacaoProduto.clp_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k.prk_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k.prk_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_dimensao":
                     case "Dimensao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k.prk_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k.prk_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_imprime_etiqueta":
                     case "ImprimeEtiqueta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_imprime_etiqueta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_imprime_etiqueta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_emite_op":
                     case "EmiteOp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_emite_op " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_emite_op) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_verde":
                     case "Verde":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_verde " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_verde) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_amarelo":
                     case "Amarelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_amarelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_amarelo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_vermelho":
                     case "Vermelho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_vermelho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_vermelho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_lote_producao":
                     case "LoteProducao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_lote_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_lote_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_qtd_container":
                     case "QtdContainer":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_qtd_container " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_qtd_container) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k.prk_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k.prk_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_utiliza_dimensao_quantidade_baixa":
                     case "UtilizaDimensaoQuantidadeBaixa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_utiliza_dimensao_quantidade_baixa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_utiliza_dimensao_quantidade_baixa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , produto_k.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , produto_k.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_utilizando_estoque_seguranca":
                     case "UtilizandoEstoqueSeguranca":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_utilizando_estoque_seguranca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_utilizando_estoque_seguranca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_utilizando_estoque_seguranca_data":
                     case "UtilizandoEstoqueSegurancaData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_k.prk_utilizando_estoque_seguranca_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_k.prk_utilizando_estoque_seguranca_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prk_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k.prk_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k.prk_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prk_codigo")) 
                        {
                           whereClause += " OR UPPER(produto_k.prk_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_k.prk_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prk_dimensao")) 
                        {
                           whereClause += " OR UPPER(produto_k.prk_dimensao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_k.prk_dimensao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prk_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(produto_k.prk_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_k.prk_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(produto_k.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_k.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prk_descricao")) 
                        {
                           whereClause += " OR UPPER(produto_k.prk_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_k.prk_descricao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_produto_k")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.id_produto_k IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.id_produto_k = :produto_k_ID_3619 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_ID_3619", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClassificacaoProduto" || parametro.FieldName == "id_classificacao_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ClassificacaoProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ClassificacaoProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.id_classificacao_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.id_classificacao_produto = :produto_k_ClassificacaoProduto_1001 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_ClassificacaoProduto_1001", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "prk_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_codigo LIKE :produto_k_Codigo_7750 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Codigo_7750", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao" || parametro.FieldName == "prk_dimensao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_dimensao LIKE :produto_k_Dimensao_4639 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Dimensao_4639", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "prk_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_ativo = :produto_k_Ativo_9857 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Ativo_9857", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImprimeEtiqueta" || parametro.FieldName == "prk_imprime_etiqueta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_imprime_etiqueta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_imprime_etiqueta = :produto_k_ImprimeEtiqueta_4588 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_ImprimeEtiqueta_4588", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmiteOp" || parametro.FieldName == "prk_emite_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_emite_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_emite_op = :produto_k_EmiteOp_750 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_EmiteOp_750", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Verde" || parametro.FieldName == "prk_verde")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_verde IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_verde = :produto_k_Verde_4965 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Verde_4965", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Amarelo" || parametro.FieldName == "prk_amarelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_amarelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_amarelo = :produto_k_Amarelo_5635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Amarelo_5635", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Vermelho" || parametro.FieldName == "prk_vermelho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_vermelho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_vermelho = :produto_k_Vermelho_9544 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Vermelho_9544", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LoteProducao" || parametro.FieldName == "prk_lote_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_lote_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_lote_producao = :produto_k_LoteProducao_148 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_LoteProducao_148", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdContainer" || parametro.FieldName == "prk_qtd_container")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_qtd_container IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_qtd_container = :produto_k_QtdContainer_5806 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_QtdContainer_5806", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "prk_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_ultima_revisao LIKE :produto_k_UltimaRevisao_6248 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_UltimaRevisao_6248", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "prk_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_ultima_revisao_data = :produto_k_UltimaRevisaoData_1771 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_UltimaRevisaoData_1771", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizaDimensaoQuantidadeBaixa" || parametro.FieldName == "prk_utiliza_dimensao_quantidade_baixa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_utiliza_dimensao_quantidade_baixa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_utiliza_dimensao_quantidade_baixa = :produto_k_UtilizaDimensaoQuantidadeBaixa_1389 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_UtilizaDimensaoQuantidadeBaixa_1389", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  produto_k.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.id_acs_usuario_ultima_revisao = :produto_k_UltimaRevisaoUsuario_5856 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_UltimaRevisaoUsuario_5856", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  produto_k.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.entity_uid LIKE :produto_k_EntityUid_5289 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_EntityUid_5289", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_k.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.version = :produto_k_Version_6395 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Version_6395", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizandoEstoqueSeguranca" || parametro.FieldName == "prk_utilizando_estoque_seguranca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EstoqueSeguranca)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EstoqueSeguranca");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_utilizando_estoque_seguranca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_utilizando_estoque_seguranca = :produto_k_UtilizandoEstoqueSeguranca_7370 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_UtilizandoEstoqueSeguranca_7370", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizandoEstoqueSegurancaData" || parametro.FieldName == "prk_utilizando_estoque_seguranca_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_utilizando_estoque_seguranca_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_utilizando_estoque_seguranca_data = :produto_k_UtilizandoEstoqueSegurancaData_3660 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_UtilizandoEstoqueSegurancaData_3660", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "prk_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_descricao LIKE :produto_k_Descricao_7138 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Descricao_7138", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_k.prk_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_codigo LIKE :produto_k_Codigo_3839 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Codigo_3839", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DimensaoExato" || parametro.FieldName == "DimensaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_k.prk_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_dimensao LIKE :produto_k_Dimensao_5319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Dimensao_5319", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_k.prk_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_ultima_revisao LIKE :produto_k_UltimaRevisao_9309 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_UltimaRevisao_9309", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_k.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.entity_uid LIKE :produto_k_EntityUid_2698 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_EntityUid_2698", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_k.prk_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_k.prk_descricao LIKE :produto_k_Descricao_5040 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_k_Descricao_5040", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProdutoKClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProdutoKClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProdutoKClass), Convert.ToInt32(read["id_produto_k"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProdutoKClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_produto_k"]);
                     if (read["id_classificacao_produto"] != DBNull.Value)
                     {
                        entidade.ClassificacaoProduto = (BibliotecaEntidades.Entidades.ClassificacaoProdutoClass)BibliotecaEntidades.Entidades.ClassificacaoProdutoClass.GetEntidade(Convert.ToInt32(read["id_classificacao_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ClassificacaoProduto = null ;
                     }
                     entidade.Codigo = (read["prk_codigo"] != DBNull.Value ? read["prk_codigo"].ToString() : null);
                     entidade.Dimensao = (read["prk_dimensao"] != DBNull.Value ? read["prk_dimensao"].ToString() : null);
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["prk_ativo"]));
                     entidade.ImprimeEtiqueta = Convert.ToBoolean(Convert.ToInt16(read["prk_imprime_etiqueta"]));
                     entidade.EmiteOp = Convert.ToBoolean(Convert.ToInt16(read["prk_emite_op"]));
                     entidade.Verde = (double)read["prk_verde"];
                     entidade.Amarelo = (double)read["prk_amarelo"];
                     entidade.Vermelho = (double)read["prk_vermelho"];
                     entidade.LoteProducao = (double)read["prk_lote_producao"];
                     entidade.QtdContainer = (double)read["prk_qtd_container"];
                     entidade.UltimaRevisao = (read["prk_ultima_revisao"] != DBNull.Value ? read["prk_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["prk_ultima_revisao_data"] as DateTime?;
                     entidade.UtilizaDimensaoQuantidadeBaixa = Convert.ToBoolean(Convert.ToInt16(read["prk_utiliza_dimensao_quantidade_baixa"]));
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.UtilizandoEstoqueSeguranca = (EstoqueSeguranca) (read["prk_utilizando_estoque_seguranca"] != DBNull.Value ? Enum.ToObject(typeof(EstoqueSeguranca), read["prk_utilizando_estoque_seguranca"]) : null);
                     entidade.UtilizandoEstoqueSegurancaData = read["prk_utilizando_estoque_seguranca_data"] as DateTime?;
                     entidade.Descricao = (read["prk_descricao"] != DBNull.Value ? read["prk_descricao"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProdutoKClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
