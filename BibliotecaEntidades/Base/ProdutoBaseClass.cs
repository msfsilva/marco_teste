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
     [Table("produto","pro")]
     public class ProdutoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProdutoClass";
protected const string ErroDelete = "Erro ao excluir o ProdutoClass  ";
protected const string ErroSave = "Erro ao salvar o ProdutoClass.";
protected const string ErroCollectionContratoFornecimentoClassProduto = "Erro ao carregar a coleção de ContratoFornecimentoClass.";
protected const string ErroCollectionEstoqueGavetaItemClassProduto = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected const string ErroCollectionFomularioRetiradaManualEstoqueClassProduto = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
protected const string ErroCollectionHistoricoCompraProdutoClassProduto = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
protected const string ErroCollectionKanbanAcionamentoClassProduto = "Erro ao carregar a coleção de KanbanAcionamentoClass.";
protected const string ErroCollectionLoteClassProduto = "Erro ao carregar a coleção de LoteClass.";
protected const string ErroCollectionOrcamentoCompraItemClassProduto = "Erro ao carregar a coleção de OrcamentoCompraItemClass.";
protected const string ErroCollectionOrcamentoConfiguradoClassProduto = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
protected const string ErroCollectionOrcamentoItemClassProduto = "Erro ao carregar a coleção de OrcamentoItemClass.";
protected const string ErroCollectionOrdemProducaoClassProduto = "Erro ao carregar a coleção de OrdemProducaoClass.";
protected const string ErroCollectionOrdemProducaoProdutoComponenteClassProduto = "Erro ao carregar a coleção de OrdemProducaoProdutoComponenteClass.";
protected const string ErroCollectionOrderItemEtiquetaClassProduto = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
protected const string ErroCollectionPedidoItemClassProduto = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionProdutoAcabamentoClassProduto = "Erro ao carregar a coleção de ProdutoAcabamentoClass.";
protected const string ErroCollectionProdutoBloqueioQualidadeClassProduto = "Erro ao carregar a coleção de ProdutoBloqueioQualidadeClass.";
protected const string ErroCollectionProdutoDocumentoTipoClassProduto = "Erro ao carregar a coleção de ProdutoDocumentoTipoClass.";
protected const string ErroCollectionProdutoEstruturaInconsistenciaClassProduto = "Erro ao carregar a coleção de ProdutoEstruturaInconsistenciaClass.";
protected const string ErroCollectionProdutoEstruturaLockClassProduto = "Erro ao carregar a coleção de ProdutoEstruturaLockClass.";
protected const string ErroCollectionProdutoFiscalClassProduto = "Erro ao carregar a coleção de ProdutoFiscalClass.";
protected const string ErroCollectionProdutoFornecedorClassProduto = "Erro ao carregar a coleção de ProdutoFornecedorClass.";
protected const string ErroCollectionProdutoKProdutoClassProduto = "Erro ao carregar a coleção de ProdutoKProdutoClass.";
protected const string ErroCollectionProdutoMaterialClassProduto = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected const string ErroCollectionProdutoPaiFilhoClassProdutoPai = "Erro ao carregar a coleção de ProdutoPaiFilhoClass.";
protected const string ErroCollectionProdutoPaiFilhoClassProdutoFilho = "Erro ao carregar a coleção de ProdutoPaiFilhoClass.";
protected const string ErroCollectionProdutoPermissaoVendaPeriodosClassProduto = "Erro ao carregar a coleção de ProdutoPermissaoVendaPeriodosClass.";
protected const string ErroCollectionProdutoPostoTrabalhoClassProduto = "Erro ao carregar a coleção de ProdutoPostoTrabalhoClass.";
protected const string ErroCollectionProdutoPrecoClassProduto = "Erro ao carregar a coleção de ProdutoPrecoClass.";
protected const string ErroCollectionProdutoRecursoClassProduto = "Erro ao carregar a coleção de ProdutoRecursoClass.";
protected const string ErroCollectionProdutoRevisaoClassProduto = "Erro ao carregar a coleção de ProdutoRevisaoClass.";
protected const string ErroCollectionSolicitacaoCompraClassProduto = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroModeloEtiquetaExpedicaoObrigatorio = "O campo ModeloEtiquetaExpedicao é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ProdutoClass.";
protected const string MensagemUtilizadoCollectionContratoFornecimentoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ContratoFornecimentoClass:";
protected const string MensagemUtilizadoCollectionEstoqueGavetaItemClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
protected const string MensagemUtilizadoCollectionKanbanAcionamentoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes KanbanAcionamentoClass:";
protected const string MensagemUtilizadoCollectionLoteClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes LoteClass:";
protected const string MensagemUtilizadoCollectionOrcamentoCompraItemClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes OrcamentoCompraItemClass:";
protected const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes OrcamentoItemClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes OrdemProducaoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoProdutoComponenteClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes OrdemProducaoProdutoComponenteClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionProdutoAcabamentoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoAcabamentoClass:";
protected const string MensagemUtilizadoCollectionProdutoBloqueioQualidadeClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoBloqueioQualidadeClass:";
protected const string MensagemUtilizadoCollectionProdutoDocumentoTipoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoDocumentoTipoClass:";
protected const string MensagemUtilizadoCollectionProdutoEstruturaInconsistenciaClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoEstruturaInconsistenciaClass:";
protected const string MensagemUtilizadoCollectionProdutoEstruturaLockClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoEstruturaLockClass:";
protected const string MensagemUtilizadoCollectionProdutoFiscalClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoFiscalClass:";
protected const string MensagemUtilizadoCollectionProdutoFornecedorClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoFornecedorClass:";
protected const string MensagemUtilizadoCollectionProdutoKProdutoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoKProdutoClass:";
protected const string MensagemUtilizadoCollectionProdutoMaterialClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected const string MensagemUtilizadoCollectionProdutoPaiFilhoClassProdutoPai =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoPaiFilhoClass:";
protected const string MensagemUtilizadoCollectionProdutoPaiFilhoClassProdutoFilho =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoPaiFilhoClass:";
protected const string MensagemUtilizadoCollectionProdutoPermissaoVendaPeriodosClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoPermissaoVendaPeriodosClass:";
protected const string MensagemUtilizadoCollectionProdutoPostoTrabalhoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoPostoTrabalhoClass:";
protected const string MensagemUtilizadoCollectionProdutoPrecoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoPrecoClass:";
protected const string MensagemUtilizadoCollectionProdutoRecursoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoRecursoClass:";
protected const string MensagemUtilizadoCollectionProdutoRevisaoClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoRevisaoClass:";
protected const string MensagemUtilizadoCollectionSolicitacaoCompraClassProduto =  "A entidade ProdutoClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
protected const string ErroFiguraLoad = "O campo Figura não pode ser carregado";
protected const string ErroImagemLoad = "O campo Imagem não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoClass está sendo utilizada.";
#endregion
       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("pro_codigo")]
        public virtual string Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected string _codigoClienteOriginal{get;private set;}
       private string _codigoClienteOriginalCommited{get; set;}
        private string _valueCodigoCliente;
         [Column("pro_codigo_cliente")]
        public virtual string CodigoCliente
         { 
            get { return this._valueCodigoCliente; } 
            set 
            { 
                if (this._valueCodigoCliente == value)return;
                 this._valueCodigoCliente = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("pro_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected bool _emiteOpOriginal{get;private set;}
       private bool _emiteOpOriginalCommited{get; set;}
        private bool _valueEmiteOp;
         [Column("pro_emite_op")]
        public virtual bool EmiteOp
         { 
            get { return this._valueEmiteOp; } 
            set 
            { 
                if (this._valueEmiteOp == value)return;
                 this._valueEmiteOp = value; 
            } 
        } 

       protected int _leadTimeFabricaOriginal{get;private set;}
       private int _leadTimeFabricaOriginalCommited{get; set;}
        private int _valueLeadTimeFabrica;
         [Column("pro_lead_time_fabrica")]
        public virtual int LeadTimeFabrica
         { 
            get { return this._valueLeadTimeFabrica; } 
            set 
            { 
                if (this._valueLeadTimeFabrica == value)return;
                 this._valueLeadTimeFabrica = value; 
            } 
        } 

       protected string _regraDimensaoOriginal{get;private set;}
       private string _regraDimensaoOriginalCommited{get; set;}
        private string _valueRegraDimensao;
         [Column("pro_regra_dimensao")]
        public virtual string RegraDimensao
         { 
            get { return this._valueRegraDimensao; } 
            set 
            { 
                if (this._valueRegraDimensao == value)return;
                 this._valueRegraDimensao = value; 
            } 
        } 

       protected string _figuraOriginal= null;
        private string _figuraOriginalCommited= null;
        private bool _FiguraLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool FiguraLoaded 
       { 
            get {                     return _FiguraLoaded; } 
           set 
           { 
                this._FiguraLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueFigura;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("pro_figura")]
        public virtual byte[] Figura
         { 
            get { 
                   if (!this.FiguraLoaded) 
                   {
                       this.LoadFigura();
                   }
                   return this._valueFigura; } 
            set 
            { 
                FiguraLoaded = true; 
                if (this._valueFigura == value)return;
                 this._valueFigura = value; 
            } 
        } 

       protected TipoCalculoPrecoProdudo _calculoPrecoOriginal{get;private set;}
       private TipoCalculoPrecoProdudo _calculoPrecoOriginalCommited{get; set;}
        private TipoCalculoPrecoProdudo _valueCalculoPreco;
         [Column("pro_calculo_preco")]
        public virtual TipoCalculoPrecoProdudo CalculoPreco
         { 
            get { return this._valueCalculoPreco; } 
            set 
            { 
                if (this._valueCalculoPreco == value)return;
                 this._valueCalculoPreco = value; 
            } 
        } 

        public bool CalculoPreco_Fixo
         { 
            get { return this._valueCalculoPreco == BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.Fixo; } 
            set { if (value) this._valueCalculoPreco = BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.Fixo; }
         } 

        public bool CalculoPreco_VariavelRegra
         { 
            get { return this._valueCalculoPreco == BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.VariavelRegra; } 
            set { if (value) this._valueCalculoPreco = BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.VariavelRegra; }
         } 

        public bool CalculoPreco_VariavelSomaTodosFilhosPedido
         { 
            get { return this._valueCalculoPreco == BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedido; } 
            set { if (value) this._valueCalculoPreco = BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedido; }
         } 

        public bool CalculoPreco_VariavelSomaFilhosPedidoSelecionados
         { 
            get { return this._valueCalculoPreco == BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.VariavelSomaFilhosPedidoSelecionados; } 
            set { if (value) this._valueCalculoPreco = BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.VariavelSomaFilhosPedidoSelecionados; }
         } 

        public bool CalculoPreco_VariavelSomaTodosFilhosPedidoEEstrutura
         { 
            get { return this._valueCalculoPreco == BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedidoEEstrutura; } 
            set { if (value) this._valueCalculoPreco = BibliotecaEntidades.Base.TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedidoEEstrutura; }
         } 

       protected double _loteEconomicoOriginal{get;private set;}
       private double _loteEconomicoOriginalCommited{get; set;}
        private double _valueLoteEconomico;
         [Column("pro_lote_economico")]
        public virtual double LoteEconomico
         { 
            get { return this._valueLoteEconomico; } 
            set 
            { 
                if (this._valueLoteEconomico == value)return;
                 this._valueLoteEconomico = value; 
            } 
        } 

       protected string _motivoRevisaoOriginal{get;private set;}
       private string _motivoRevisaoOriginalCommited{get; set;}
        private string _valueMotivoRevisao;
         [Column("pro_motivo_revisao")]
        public virtual string MotivoRevisao
         { 
            get { return this._valueMotivoRevisao; } 
            set 
            { 
                if (this._valueMotivoRevisao == value)return;
                 this._valueMotivoRevisao = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuario;
        [Column("id_acs_usuario", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuario
        { 
           get {                 return this._valueAcsUsuario; } 
           set 
           { 
                if (this._valueAcsUsuario == value)return;
                 this._valueAcsUsuario = value; 
           } 
       } 

       protected DateTime _dataRevisaoCadastroOriginal{get;private set;}
       private DateTime _dataRevisaoCadastroOriginalCommited{get; set;}
        private DateTime _valueDataRevisaoCadastro;
         [Column("pro_data_revisao_cadastro")]
        public virtual DateTime DataRevisaoCadastro
         { 
            get { return this._valueDataRevisaoCadastro; } 
            set 
            { 
                if (this._valueDataRevisaoCadastro == value)return;
                 this._valueDataRevisaoCadastro = value; 
            } 
        } 

       protected TipoAquisicao _tipoAquisicaoOriginal{get;private set;}
       private TipoAquisicao _tipoAquisicaoOriginalCommited{get; set;}
        private TipoAquisicao _valueTipoAquisicao;
         [Column("pro_tipo_aquisicao")]
        public virtual TipoAquisicao TipoAquisicao
         { 
            get { return this._valueTipoAquisicao; } 
            set 
            { 
                if (this._valueTipoAquisicao == value)return;
                 this._valueTipoAquisicao = value; 
            } 
        } 

        public bool TipoAquisicao_Fabricado
         { 
            get { return this._valueTipoAquisicao == BibliotecaEntidades.Base.TipoAquisicao.Fabricado; } 
            set { if (value) this._valueTipoAquisicao = BibliotecaEntidades.Base.TipoAquisicao.Fabricado; }
         } 

        public bool TipoAquisicao_Comprado
         { 
            get { return this._valueTipoAquisicao == BibliotecaEntidades.Base.TipoAquisicao.Comprado; } 
            set { if (value) this._valueTipoAquisicao = BibliotecaEntidades.Base.TipoAquisicao.Comprado; }
         } 

       protected PoliticaEstoque _politicaEstoqueOriginal{get;private set;}
       private PoliticaEstoque _politicaEstoqueOriginalCommited{get; set;}
        private PoliticaEstoque _valuePoliticaEstoque;
         [Column("pro_politica_estoque")]
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

       protected BibliotecaEntidades.Entidades.ClassificacaoProduto2Class _classificacaoProduto2Original{get;private set;}
       private BibliotecaEntidades.Entidades.ClassificacaoProduto2Class _classificacaoProduto2OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ClassificacaoProduto2Class _valueClassificacaoProduto2;
        [Column("id_classificacao_produto_2", "classificacao_produto_2", "id_classificacao_produto_2")]
       public virtual BibliotecaEntidades.Entidades.ClassificacaoProduto2Class ClassificacaoProduto2
        { 
           get {                 return this._valueClassificacaoProduto2; } 
           set 
           { 
                if (this._valueClassificacaoProduto2 == value)return;
                 this._valueClassificacaoProduto2 = value; 
           } 
       } 

       protected int _qtdEtiquetaExpedicaoVolumeOriginal{get;private set;}
       private int _qtdEtiquetaExpedicaoVolumeOriginalCommited{get; set;}
        private int _valueQtdEtiquetaExpedicaoVolume;
         [Column("pro_qtd_etiqueta_expedicao_volume")]
        public virtual int QtdEtiquetaExpedicaoVolume
         { 
            get { return this._valueQtdEtiquetaExpedicaoVolume; } 
            set 
            { 
                if (this._valueQtdEtiquetaExpedicaoVolume == value)return;
                 this._valueQtdEtiquetaExpedicaoVolume = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EmbalagemClass _embalagemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EmbalagemClass _embalagemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EmbalagemClass _valueEmbalagem;
        [Column("id_embalagem", "embalagem", "id_embalagem")]
       public virtual BibliotecaEntidades.Entidades.EmbalagemClass Embalagem
        { 
           get {                 return this._valueEmbalagem; } 
           set 
           { 
                if (this._valueEmbalagem == value)return;
                 this._valueEmbalagem = value; 
           } 
       } 

       protected string _descricaoInglesOriginal{get;private set;}
       private string _descricaoInglesOriginalCommited{get; set;}
        private string _valueDescricaoIngles;
         [Column("pro_descricao_ingles")]
        public virtual string DescricaoIngles
         { 
            get { return this._valueDescricaoIngles; } 
            set 
            { 
                if (this._valueDescricaoIngles == value)return;
                 this._valueDescricaoIngles = value; 
            } 
        } 

       protected string _descricaoEspanholOriginal{get;private set;}
       private string _descricaoEspanholOriginalCommited{get; set;}
        private string _valueDescricaoEspanhol;
         [Column("pro_descricao_espanhol")]
        public virtual string DescricaoEspanhol
         { 
            get { return this._valueDescricaoEspanhol; } 
            set 
            { 
                if (this._valueDescricaoEspanhol == value)return;
                 this._valueDescricaoEspanhol = value; 
            } 
        } 

       protected double _pesoUnitarioOriginal{get;private set;}
       private double _pesoUnitarioOriginalCommited{get; set;}
        private double _valuePesoUnitario;
         [Column("pro_peso_unitario")]
        public virtual double PesoUnitario
         { 
            get { return this._valuePesoUnitario; } 
            set 
            { 
                if (this._valuePesoUnitario == value)return;
                 this._valuePesoUnitario = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.FamiliaClienteClass _familiaClienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FamiliaClienteClass _familiaClienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FamiliaClienteClass _valueFamiliaCliente;
        [Column("id_familia_cliente", "familia_cliente", "id_familia_cliente")]
       public virtual BibliotecaEntidades.Entidades.FamiliaClienteClass FamiliaCliente
        { 
           get {                 return this._valueFamiliaCliente; } 
           set 
           { 
                if (this._valueFamiliaCliente == value)return;
                 this._valueFamiliaCliente = value; 
           } 
       } 

       protected bool _cadastroPcpOriginal{get;private set;}
       private bool _cadastroPcpOriginalCommited{get; set;}
        private bool _valueCadastroPcp;
         [Column("pro_cadastro_pcp")]
        public virtual bool CadastroPcp
         { 
            get { return this._valueCadastroPcp; } 
            set 
            { 
                if (this._valueCadastroPcp == value)return;
                 this._valueCadastroPcp = value; 
            } 
        } 

       protected bool _cadastroEngenhariaOriginal{get;private set;}
       private bool _cadastroEngenhariaOriginalCommited{get; set;}
        private bool _valueCadastroEngenharia;
         [Column("pro_cadastro_engenharia")]
        public virtual bool CadastroEngenharia
         { 
            get { return this._valueCadastroEngenharia; } 
            set 
            { 
                if (this._valueCadastroEngenharia == value)return;
                 this._valueCadastroEngenharia = value; 
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

       protected BibliotecaEntidades.Entidades.VariavelClass _variavel1Original{get;private set;}
       private BibliotecaEntidades.Entidades.VariavelClass _variavel1OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.VariavelClass _valueVariavel1;
        [Column("id_variavel_1", "variavel", "id_variavel")]
       public virtual BibliotecaEntidades.Entidades.VariavelClass Variavel1
        { 
           get {                 return this._valueVariavel1; } 
           set 
           { 
                if (this._valueVariavel1 == value)return;
                 this._valueVariavel1 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.VariavelClass _variavel2Original{get;private set;}
       private BibliotecaEntidades.Entidades.VariavelClass _variavel2OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.VariavelClass _valueVariavel2;
        [Column("id_variavel_2", "variavel", "id_variavel")]
       public virtual BibliotecaEntidades.Entidades.VariavelClass Variavel2
        { 
           get {                 return this._valueVariavel2; } 
           set 
           { 
                if (this._valueVariavel2 == value)return;
                 this._valueVariavel2 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.VariavelClass _variavel3Original{get;private set;}
       private BibliotecaEntidades.Entidades.VariavelClass _variavel3OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.VariavelClass _valueVariavel3;
        [Column("id_variavel_3", "variavel", "id_variavel")]
       public virtual BibliotecaEntidades.Entidades.VariavelClass Variavel3
        { 
           get {                 return this._valueVariavel3; } 
           set 
           { 
                if (this._valueVariavel3 == value)return;
                 this._valueVariavel3 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.VariavelClass _variavel4Original{get;private set;}
       private BibliotecaEntidades.Entidades.VariavelClass _variavel4OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.VariavelClass _valueVariavel4;
        [Column("id_variavel_4", "variavel", "id_variavel")]
       public virtual BibliotecaEntidades.Entidades.VariavelClass Variavel4
        { 
           get {                 return this._valueVariavel4; } 
           set 
           { 
                if (this._valueVariavel4 == value)return;
                 this._valueVariavel4 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ClienteClass _clienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ClienteClass _clienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ClienteClass _valueCliente;
        [Column("id_cliente", "cliente", "id_cliente")]
       public virtual BibliotecaEntidades.Entidades.ClienteClass Cliente
        { 
           get {                 return this._valueCliente; } 
           set 
           { 
                if (this._valueCliente == value)return;
                 this._valueCliente = value; 
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

       protected bool _utilizaDimensaoMaiorFilhoOriginal{get;private set;}
       private bool _utilizaDimensaoMaiorFilhoOriginalCommited{get; set;}
        private bool _valueUtilizaDimensaoMaiorFilho;
         [Column("pro_utiliza_dimensao_maior_filho")]
        public virtual bool UtilizaDimensaoMaiorFilho
         { 
            get { return this._valueUtilizaDimensaoMaiorFilho; } 
            set 
            { 
                if (this._valueUtilizaDimensaoMaiorFilho == value)return;
                 this._valueUtilizaDimensaoMaiorFilho = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.LocalFabricacaoClass _localFabricacaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.LocalFabricacaoClass _localFabricacaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.LocalFabricacaoClass _valueLocalFabricacao;
        [Column("id_local_fabricacao", "local_fabricacao", "id_local_fabricacao")]
       public virtual BibliotecaEntidades.Entidades.LocalFabricacaoClass LocalFabricacao
        { 
           get {                 return this._valueLocalFabricacao; } 
           set 
           { 
                if (this._valueLocalFabricacao == value)return;
                 this._valueLocalFabricacao = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.AgrupadorOpClass _agrupadorOpOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.AgrupadorOpClass _agrupadorOpOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.AgrupadorOpClass _valueAgrupadorOp;
        [Column("id_agrupador_op", "agrupador_op", "id_agrupador_op")]
       public virtual BibliotecaEntidades.Entidades.AgrupadorOpClass AgrupadorOp
        { 
           get {                 return this._valueAgrupadorOp; } 
           set 
           { 
                if (this._valueAgrupadorOp == value)return;
                 this._valueAgrupadorOp = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.AplicacaoClienteClass _aplicacaoClienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.AplicacaoClienteClass _aplicacaoClienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.AplicacaoClienteClass _valueAplicacaoCliente;
        [Column("id_aplicacao_cliente", "aplicacao_cliente", "id_aplicacao_cliente")]
       public virtual BibliotecaEntidades.Entidades.AplicacaoClienteClass AplicacaoCliente
        { 
           get {                 return this._valueAplicacaoCliente; } 
           set 
           { 
                if (this._valueAplicacaoCliente == value)return;
                 this._valueAplicacaoCliente = value; 
           } 
       } 

       protected int? _tempoLimiteOriginal{get;private set;}
       private int? _tempoLimiteOriginalCommited{get; set;}
        private int? _valueTempoLimite;
         [Column("pro_tempo_limite")]
        public virtual int? TempoLimite
         { 
            get { return this._valueTempoLimite; } 
            set 
            { 
                if (this._valueTempoLimite == value)return;
                 this._valueTempoLimite = value; 
            } 
        } 

       protected bool _cadastroPrecoOriginal{get;private set;}
       private bool _cadastroPrecoOriginalCommited{get; set;}
        private bool _valueCadastroPreco;
         [Column("pro_cadastro_preco")]
        public virtual bool CadastroPreco
         { 
            get { return this._valueCadastroPreco; } 
            set 
            { 
                if (this._valueCadastroPreco == value)return;
                 this._valueCadastroPreco = value; 
            } 
        } 

       protected bool _etiquetaInternaOriginal{get;private set;}
       private bool _etiquetaInternaOriginalCommited{get; set;}
        private bool _valueEtiquetaInterna;
         [Column("pro_etiqueta_interna")]
        public virtual bool EtiquetaInterna
         { 
            get { return this._valueEtiquetaInterna; } 
            set 
            { 
                if (this._valueEtiquetaInterna == value)return;
                 this._valueEtiquetaInterna = value; 
            } 
        } 

       protected bool _temporarioOriginal{get;private set;}
       private bool _temporarioOriginalCommited{get; set;}
        private bool _valueTemporario;
         [Column("pro_temporario")]
        public virtual bool Temporario
         { 
            get { return this._valueTemporario; } 
            set 
            { 
                if (this._valueTemporario == value)return;
                 this._valueTemporario = value; 
            } 
        } 

       protected double _vermelhoOriginal{get;private set;}
       private double _vermelhoOriginalCommited{get; set;}
        private double _valueVermelho;
         [Column("pro_vermelho")]
        public virtual double Vermelho
         { 
            get { return this._valueVermelho; } 
            set 
            { 
                if (this._valueVermelho == value)return;
                 this._valueVermelho = value; 
            } 
        } 

       protected double _verdeOriginal{get;private set;}
       private double _verdeOriginalCommited{get; set;}
        private double _valueVerde;
         [Column("pro_verde")]
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
         [Column("pro_amarelo")]
        public virtual double Amarelo
         { 
            get { return this._valueAmarelo; } 
            set 
            { 
                if (this._valueAmarelo == value)return;
                 this._valueAmarelo = value; 
            } 
        } 

       protected double? _lotePadraoCompraOriginal{get;private set;}
       private double? _lotePadraoCompraOriginalCommited{get; set;}
        private double? _valueLotePadraoCompra;
         [Column("pro_lote_padrao_compra")]
        public virtual double? LotePadraoCompra
         { 
            get { return this._valueLotePadraoCompra; } 
            set 
            { 
                if (this._valueLotePadraoCompra == value)return;
                 this._valueLotePadraoCompra = value; 
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
         [Column("pro_unidades_por_un_compra")]
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
         [Column("pro_lead_time_compra")]
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
         [Column("pro_marcas_homologadas")]
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
         [Column("pro_impedir_solicitacao_auto")]
        public virtual bool ImpedirSolicitacaoAuto
         { 
            get { return this._valueImpedirSolicitacaoAuto; } 
            set 
            { 
                if (this._valueImpedirSolicitacaoAuto == value)return;
                 this._valueImpedirSolicitacaoAuto = value; 
            } 
        } 

       protected int _versaoEstruturaAtualOriginal{get;private set;}
       private int _versaoEstruturaAtualOriginalCommited{get; set;}
        private int _valueVersaoEstruturaAtual;
         [Column("pro_versao_estrutura_atual")]
        public virtual int VersaoEstruturaAtual
         { 
            get { return this._valueVersaoEstruturaAtual; } 
            set 
            { 
                if (this._valueVersaoEstruturaAtual == value)return;
                 this._valueVersaoEstruturaAtual = value; 
            } 
        } 

       protected bool _rastreamentoMaterialOriginal{get;private set;}
       private bool _rastreamentoMaterialOriginalCommited{get; set;}
        private bool _valueRastreamentoMaterial;
         [Column("pro_rastreamento_material")]
        public virtual bool RastreamentoMaterial
         { 
            get { return this._valueRastreamentoMaterial; } 
            set 
            { 
                if (this._valueRastreamentoMaterial == value)return;
                 this._valueRastreamentoMaterial = value; 
            } 
        } 

       protected string _regraValidVar1Original{get;private set;}
       private string _regraValidVar1OriginalCommited{get; set;}
        private string _valueRegraValidVar1;
         [Column("pro_regra_valid_var1")]
        public virtual string RegraValidVar1
         { 
            get { return this._valueRegraValidVar1; } 
            set 
            { 
                if (this._valueRegraValidVar1 == value)return;
                 this._valueRegraValidVar1 = value; 
            } 
        } 

       protected string _regraValidVar2Original{get;private set;}
       private string _regraValidVar2OriginalCommited{get; set;}
        private string _valueRegraValidVar2;
         [Column("pro_regra_valid_var2")]
        public virtual string RegraValidVar2
         { 
            get { return this._valueRegraValidVar2; } 
            set 
            { 
                if (this._valueRegraValidVar2 == value)return;
                 this._valueRegraValidVar2 = value; 
            } 
        } 

       protected string _regraValidVar3Original{get;private set;}
       private string _regraValidVar3OriginalCommited{get; set;}
        private string _valueRegraValidVar3;
         [Column("pro_regra_valid_var3")]
        public virtual string RegraValidVar3
         { 
            get { return this._valueRegraValidVar3; } 
            set 
            { 
                if (this._valueRegraValidVar3 == value)return;
                 this._valueRegraValidVar3 = value; 
            } 
        } 

       protected string _regraValidVar4Original{get;private set;}
       private string _regraValidVar4OriginalCommited{get; set;}
        private string _valueRegraValidVar4;
         [Column("pro_regra_valid_var4")]
        public virtual string RegraValidVar4
         { 
            get { return this._valueRegraValidVar4; } 
            set 
            { 
                if (this._valueRegraValidVar4 == value)return;
                 this._valueRegraValidVar4 = value; 
            } 
        } 

       protected bool _estruturaEmRevisaoOriginal{get;private set;}
       private bool _estruturaEmRevisaoOriginalCommited{get; set;}
        private bool _valueEstruturaEmRevisao;
         [Column("pro_estrutura_em_revisao")]
        public virtual bool EstruturaEmRevisao
         { 
            get { return this._valueEstruturaEmRevisao; } 
            set 
            { 
                if (this._valueEstruturaEmRevisao == value)return;
                 this._valueEstruturaEmRevisao = value; 
            } 
        } 

       protected EstoqueSeguranca _utilizandoEstoqueSegurancaOriginal{get;private set;}
       private EstoqueSeguranca _utilizandoEstoqueSegurancaOriginalCommited{get; set;}
        private EstoqueSeguranca _valueUtilizandoEstoqueSeguranca;
         [Column("pro_utilizando_estoque_seguranca")]
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
         [Column("pro_utilizando_estoque_seguranca_data")]
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
         [Column("pro_imagem")]
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

       protected ResponsavelFrete? _responsavelFreteOriginal{get;private set;}
       private ResponsavelFrete? _responsavelFreteOriginalCommited{get; set;}
        private ResponsavelFrete? _valueResponsavelFrete;
         [Column("pro_responsavel_frete")]
        public virtual ResponsavelFrete? ResponsavelFrete
         { 
            get { return this._valueResponsavelFrete; } 
            set 
            { 
                if (this._valueResponsavelFrete == value)return;
                 this._valueResponsavelFrete = value; 
            } 
        } 

        public bool ResponsavelFrete_ProprioRemetente
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.ProprioRemetente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.ProprioRemetente; }
         } 

        public bool ResponsavelFrete_ProprioDestinatario
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.ProprioDestinatario; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.ProprioDestinatario; }
         } 

        public bool ResponsavelFrete_Emitente
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.Emitente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Emitente; }
         } 

        public bool ResponsavelFrete_Cliente
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.Cliente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Cliente; }
         } 

        public bool ResponsavelFrete_Terceiros
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.Terceiros; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Terceiros; }
         } 

        public bool ResponsavelFrete_SemFrete
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.SemFrete; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.SemFrete; }
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

       protected bool _permiteVendaOriginal{get;private set;}
       private bool _permiteVendaOriginalCommited{get; set;}
        private bool _valuePermiteVenda;
         [Column("pro_permite_venda")]
        public virtual bool PermiteVenda
         { 
            get { return this._valuePermiteVenda; } 
            set 
            { 
                if (this._valuePermiteVenda == value)return;
                 this._valuePermiteVenda = value; 
            } 
        } 

       protected string _descricaoAdicionalOriginal{get;private set;}
       private string _descricaoAdicionalOriginalCommited{get; set;}
        private string _valueDescricaoAdicional;
         [Column("pro_descricao_adicional")]
        public virtual string DescricaoAdicional
         { 
            get { return this._valueDescricaoAdicional; } 
            set 
            { 
                if (this._valueDescricaoAdicional == value)return;
                 this._valueDescricaoAdicional = value; 
            } 
        } 

       protected bool _imprimirEstruturaOpOriginal{get;private set;}
       private bool _imprimirEstruturaOpOriginalCommited{get; set;}
        private bool _valueImprimirEstruturaOp;
         [Column("pro_imprimir_estrutura_op")]
        public virtual bool ImprimirEstruturaOp
         { 
            get { return this._valueImprimirEstruturaOp; } 
            set 
            { 
                if (this._valueImprimirEstruturaOp == value)return;
                 this._valueImprimirEstruturaOp = value; 
            } 
        } 

       protected bool _imprimeOpsRelacionadasOriginal{get;private set;}
       private bool _imprimeOpsRelacionadasOriginalCommited{get; set;}
        private bool _valueImprimeOpsRelacionadas;
         [Column("pro_imprime_ops_relacionadas")]
        public virtual bool ImprimeOpsRelacionadas
         { 
            get { return this._valueImprimeOpsRelacionadas; } 
            set 
            { 
                if (this._valueImprimeOpsRelacionadas == value)return;
                 this._valueImprimeOpsRelacionadas = value; 
            } 
        } 

       protected double? _margemRecebimentoOriginal{get;private set;}
       private double? _margemRecebimentoOriginalCommited{get; set;}
        private double? _valueMargemRecebimento;
         [Column("pro_margem_recebimento")]
        public virtual double? MargemRecebimento
         { 
            get { return this._valueMargemRecebimento; } 
            set 
            { 
                if (this._valueMargemRecebimento == value)return;
                 this._valueMargemRecebimento = value; 
            } 
        } 

       protected bool _emitePlanoCorteOriginal{get;private set;}
       private bool _emitePlanoCorteOriginalCommited{get; set;}
        private bool _valueEmitePlanoCorte;
         [Column("pro_emite_plano_corte")]
        public virtual bool EmitePlanoCorte
         { 
            get { return this._valueEmitePlanoCorte; } 
            set 
            { 
                if (this._valueEmitePlanoCorte == value)return;
                 this._valueEmitePlanoCorte = value; 
            } 
        } 

       protected bool _validacaoPesoExpedicaoOriginal{get;private set;}
       private bool _validacaoPesoExpedicaoOriginalCommited{get; set;}
        private bool _valueValidacaoPesoExpedicao;
         [Column("pro_validacao_peso_expedicao")]
        public virtual bool ValidacaoPesoExpedicao
         { 
            get { return this._valueValidacaoPesoExpedicao; } 
            set 
            { 
                if (this._valueValidacaoPesoExpedicao == value)return;
                 this._valueValidacaoPesoExpedicao = value; 
            } 
        } 

       protected string _gtinOriginal{get;private set;}
       private string _gtinOriginalCommited{get; set;}
        private string _valueGtin;
         [Column("pro_gtin")]
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
         [Column("pro_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       protected string _estruturaEmRevisaoObservacaoOriginal{get;private set;}
       private string _estruturaEmRevisaoObservacaoOriginalCommited{get; set;}
        private string _valueEstruturaEmRevisaoObservacao;
         [Column("pro_estrutura_em_revisao_observacao")]
        public virtual string EstruturaEmRevisaoObservacao
         { 
            get { return this._valueEstruturaEmRevisaoObservacao; } 
            set 
            { 
                if (this._valueEstruturaEmRevisaoObservacao == value)return;
                 this._valueEstruturaEmRevisaoObservacao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass _modeloEtiquetaExpedicaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass _modeloEtiquetaExpedicaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass _valueModeloEtiquetaExpedicao;
        [Column("id_modelo_etiqueta_expedicao", "modelo_etiqueta_expedicao", "id_modelo_etiqueta_expedicao")]
       public virtual BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass ModeloEtiquetaExpedicao
        { 
           get {                 return this._valueModeloEtiquetaExpedicao; } 
           set 
           { 
                if (this._valueModeloEtiquetaExpedicao == value)return;
                 this._valueModeloEtiquetaExpedicao = value; 
           } 
       } 

       protected double? _loteMinimoOriginal{get;private set;}
       private double? _loteMinimoOriginalCommited{get; set;}
        private double? _valueLoteMinimo;
         [Column("pro_lote_minimo")]
        public virtual double? LoteMinimo
         { 
            get { return this._valueLoteMinimo; } 
            set 
            { 
                if (this._valueLoteMinimo == value)return;
                 this._valueLoteMinimo = value; 
            } 
        } 

       protected bool _bloqueioPrecoVencidoOriginal{get;private set;}
       private bool _bloqueioPrecoVencidoOriginalCommited{get; set;}
        private bool _valueBloqueioPrecoVencido;
         [Column("pro_bloqueio_preco_vencido")]
        public virtual bool BloqueioPrecoVencido
         { 
            get { return this._valueBloqueioPrecoVencido; } 
            set 
            { 
                if (this._valueBloqueioPrecoVencido == value)return;
                 this._valueBloqueioPrecoVencido = value; 
            } 
        } 

       private List<long> _collectionContratoFornecimentoClassProdutoOriginal;
       private List<Entidades.ContratoFornecimentoClass > _collectionContratoFornecimentoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContratoFornecimentoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContratoFornecimentoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContratoFornecimentoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContratoFornecimentoClass> _valueCollectionContratoFornecimentoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContratoFornecimentoClass> CollectionContratoFornecimentoClassProduto 
       { 
           get { if(!_valueCollectionContratoFornecimentoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionContratoFornecimentoClassProduto();}
return this._valueCollectionContratoFornecimentoClassProduto; } 
           set 
           { 
               this._valueCollectionContratoFornecimentoClassProduto = value; 
               this._valueCollectionContratoFornecimentoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionEstoqueGavetaItemClassProdutoOriginal;
       private List<Entidades.EstoqueGavetaItemClass > _collectionEstoqueGavetaItemClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueGavetaItemClass> _valueCollectionEstoqueGavetaItemClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueGavetaItemClass> CollectionEstoqueGavetaItemClassProduto 
       { 
           get { if(!_valueCollectionEstoqueGavetaItemClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueGavetaItemClassProduto();}
return this._valueCollectionEstoqueGavetaItemClassProduto; } 
           set 
           { 
               this._valueCollectionEstoqueGavetaItemClassProduto = value; 
               this._valueCollectionEstoqueGavetaItemClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionFomularioRetiradaManualEstoqueClassProdutoOriginal;
       private List<Entidades.FomularioRetiradaManualEstoqueClass > _collectionFomularioRetiradaManualEstoqueClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FomularioRetiradaManualEstoqueClass> _valueCollectionFomularioRetiradaManualEstoqueClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FomularioRetiradaManualEstoqueClass> CollectionFomularioRetiradaManualEstoqueClassProduto 
       { 
           get { if(!_valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionFomularioRetiradaManualEstoqueClassProduto();}
return this._valueCollectionFomularioRetiradaManualEstoqueClassProduto; } 
           set 
           { 
               this._valueCollectionFomularioRetiradaManualEstoqueClassProduto = value; 
               this._valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraProdutoClassProdutoOriginal;
       private List<Entidades.HistoricoCompraProdutoClass > _collectionHistoricoCompraProdutoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraProdutoClass> _valueCollectionHistoricoCompraProdutoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraProdutoClass> CollectionHistoricoCompraProdutoClassProduto 
       { 
           get { if(!_valueCollectionHistoricoCompraProdutoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraProdutoClassProduto();}
return this._valueCollectionHistoricoCompraProdutoClassProduto; } 
           set 
           { 
               this._valueCollectionHistoricoCompraProdutoClassProduto = value; 
               this._valueCollectionHistoricoCompraProdutoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionKanbanAcionamentoClassProdutoOriginal;
       private List<Entidades.KanbanAcionamentoClass > _collectionKanbanAcionamentoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.KanbanAcionamentoClass> _valueCollectionKanbanAcionamentoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.KanbanAcionamentoClass> CollectionKanbanAcionamentoClassProduto 
       { 
           get { if(!_valueCollectionKanbanAcionamentoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionKanbanAcionamentoClassProduto();}
return this._valueCollectionKanbanAcionamentoClassProduto; } 
           set 
           { 
               this._valueCollectionKanbanAcionamentoClassProduto = value; 
               this._valueCollectionKanbanAcionamentoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionLoteClassProdutoOriginal;
       private List<Entidades.LoteClass > _collectionLoteClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LoteClass> _valueCollectionLoteClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LoteClass> CollectionLoteClassProduto 
       { 
           get { if(!_valueCollectionLoteClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionLoteClassProduto();}
return this._valueCollectionLoteClassProduto; } 
           set 
           { 
               this._valueCollectionLoteClassProduto = value; 
               this._valueCollectionLoteClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoCompraItemClassProdutoOriginal;
       private List<Entidades.OrcamentoCompraItemClass > _collectionOrcamentoCompraItemClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoCompraItemClass> _valueCollectionOrcamentoCompraItemClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoCompraItemClass> CollectionOrcamentoCompraItemClassProduto 
       { 
           get { if(!_valueCollectionOrcamentoCompraItemClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoCompraItemClassProduto();}
return this._valueCollectionOrcamentoCompraItemClassProduto; } 
           set 
           { 
               this._valueCollectionOrcamentoCompraItemClassProduto = value; 
               this._valueCollectionOrcamentoCompraItemClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoConfiguradoClassProdutoOriginal;
       private List<Entidades.OrcamentoConfiguradoClass > _collectionOrcamentoConfiguradoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoConfiguradoClass> _valueCollectionOrcamentoConfiguradoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoConfiguradoClass> CollectionOrcamentoConfiguradoClassProduto 
       { 
           get { if(!_valueCollectionOrcamentoConfiguradoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoConfiguradoClassProduto();}
return this._valueCollectionOrcamentoConfiguradoClassProduto; } 
           set 
           { 
               this._valueCollectionOrcamentoConfiguradoClassProduto = value; 
               this._valueCollectionOrcamentoConfiguradoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemClassProdutoOriginal;
       private List<Entidades.OrcamentoItemClass > _collectionOrcamentoItemClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemClass> _valueCollectionOrcamentoItemClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemClass> CollectionOrcamentoItemClassProduto 
       { 
           get { if(!_valueCollectionOrcamentoItemClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemClassProduto();}
return this._valueCollectionOrcamentoItemClassProduto; } 
           set 
           { 
               this._valueCollectionOrcamentoItemClassProduto = value; 
               this._valueCollectionOrcamentoItemClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoClassProdutoOriginal;
       private List<Entidades.OrdemProducaoClass > _collectionOrdemProducaoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoClass> _valueCollectionOrdemProducaoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoClass> CollectionOrdemProducaoClassProduto 
       { 
           get { if(!_valueCollectionOrdemProducaoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoClassProduto();}
return this._valueCollectionOrdemProducaoClassProduto; } 
           set 
           { 
               this._valueCollectionOrdemProducaoClassProduto = value; 
               this._valueCollectionOrdemProducaoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoProdutoComponenteClassProdutoOriginal;
       private List<Entidades.OrdemProducaoProdutoComponenteClass > _collectionOrdemProducaoProdutoComponenteClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoProdutoComponenteClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoProdutoComponenteClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoProdutoComponenteClass> _valueCollectionOrdemProducaoProdutoComponenteClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoProdutoComponenteClass> CollectionOrdemProducaoProdutoComponenteClassProduto 
       { 
           get { if(!_valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoProdutoComponenteClassProduto();}
return this._valueCollectionOrdemProducaoProdutoComponenteClassProduto; } 
           set 
           { 
               this._valueCollectionOrdemProducaoProdutoComponenteClassProduto = value; 
               this._valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaClassProdutoOriginal;
       private List<Entidades.OrderItemEtiquetaClass > _collectionOrderItemEtiquetaClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaClass> _valueCollectionOrderItemEtiquetaClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaClass> CollectionOrderItemEtiquetaClassProduto 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaClassProduto();}
return this._valueCollectionOrderItemEtiquetaClassProduto; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaClassProduto = value; 
               this._valueCollectionOrderItemEtiquetaClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassProdutoOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassProduto 
       { 
           get { if(!_valueCollectionPedidoItemClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassProduto();}
return this._valueCollectionPedidoItemClassProduto; } 
           set 
           { 
               this._valueCollectionPedidoItemClassProduto = value; 
               this._valueCollectionPedidoItemClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoAcabamentoClassProdutoOriginal;
       private List<Entidades.ProdutoAcabamentoClass > _collectionProdutoAcabamentoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoAcabamentoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoAcabamentoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoAcabamentoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoAcabamentoClass> _valueCollectionProdutoAcabamentoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoAcabamentoClass> CollectionProdutoAcabamentoClassProduto 
       { 
           get { if(!_valueCollectionProdutoAcabamentoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoAcabamentoClassProduto();}
return this._valueCollectionProdutoAcabamentoClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoAcabamentoClassProduto = value; 
               this._valueCollectionProdutoAcabamentoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoBloqueioQualidadeClassProdutoOriginal;
       private List<Entidades.ProdutoBloqueioQualidadeClass > _collectionProdutoBloqueioQualidadeClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoBloqueioQualidadeClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoBloqueioQualidadeClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoBloqueioQualidadeClass> _valueCollectionProdutoBloqueioQualidadeClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoBloqueioQualidadeClass> CollectionProdutoBloqueioQualidadeClassProduto 
       { 
           get { if(!_valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoBloqueioQualidadeClassProduto();}
return this._valueCollectionProdutoBloqueioQualidadeClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoBloqueioQualidadeClassProduto = value; 
               this._valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoDocumentoTipoClassProdutoOriginal;
       private List<Entidades.ProdutoDocumentoTipoClass > _collectionProdutoDocumentoTipoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoDocumentoTipoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoDocumentoTipoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoDocumentoTipoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoDocumentoTipoClass> _valueCollectionProdutoDocumentoTipoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoDocumentoTipoClass> CollectionProdutoDocumentoTipoClassProduto 
       { 
           get { if(!_valueCollectionProdutoDocumentoTipoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoDocumentoTipoClassProduto();}
return this._valueCollectionProdutoDocumentoTipoClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoDocumentoTipoClassProduto = value; 
               this._valueCollectionProdutoDocumentoTipoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoEstruturaInconsistenciaClassProdutoOriginal;
       private List<Entidades.ProdutoEstruturaInconsistenciaClass > _collectionProdutoEstruturaInconsistenciaClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoEstruturaInconsistenciaClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoEstruturaInconsistenciaClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoEstruturaInconsistenciaClass> _valueCollectionProdutoEstruturaInconsistenciaClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoEstruturaInconsistenciaClass> CollectionProdutoEstruturaInconsistenciaClassProduto 
       { 
           get { if(!_valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoEstruturaInconsistenciaClassProduto();}
return this._valueCollectionProdutoEstruturaInconsistenciaClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoEstruturaInconsistenciaClassProduto = value; 
               this._valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoEstruturaLockClassProdutoOriginal;
       private List<Entidades.ProdutoEstruturaLockClass > _collectionProdutoEstruturaLockClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoEstruturaLockClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoEstruturaLockClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoEstruturaLockClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoEstruturaLockClass> _valueCollectionProdutoEstruturaLockClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoEstruturaLockClass> CollectionProdutoEstruturaLockClassProduto 
       { 
           get { if(!_valueCollectionProdutoEstruturaLockClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoEstruturaLockClassProduto();}
return this._valueCollectionProdutoEstruturaLockClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoEstruturaLockClassProduto = value; 
               this._valueCollectionProdutoEstruturaLockClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoFiscalClassProdutoOriginal;
       private List<Entidades.ProdutoFiscalClass > _collectionProdutoFiscalClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFiscalClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFiscalClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFiscalClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoFiscalClass> _valueCollectionProdutoFiscalClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoFiscalClass> CollectionProdutoFiscalClassProduto 
       { 
           get { if(!_valueCollectionProdutoFiscalClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoFiscalClassProduto();}
return this._valueCollectionProdutoFiscalClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoFiscalClassProduto = value; 
               this._valueCollectionProdutoFiscalClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoFornecedorClassProdutoOriginal;
       private List<Entidades.ProdutoFornecedorClass > _collectionProdutoFornecedorClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFornecedorClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFornecedorClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFornecedorClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoFornecedorClass> _valueCollectionProdutoFornecedorClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoFornecedorClass> CollectionProdutoFornecedorClassProduto 
       { 
           get { if(!_valueCollectionProdutoFornecedorClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoFornecedorClassProduto();}
return this._valueCollectionProdutoFornecedorClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoFornecedorClassProduto = value; 
               this._valueCollectionProdutoFornecedorClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoKProdutoClassProdutoOriginal;
       private List<Entidades.ProdutoKProdutoClass > _collectionProdutoKProdutoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKProdutoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKProdutoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKProdutoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoKProdutoClass> _valueCollectionProdutoKProdutoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoKProdutoClass> CollectionProdutoKProdutoClassProduto 
       { 
           get { if(!_valueCollectionProdutoKProdutoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoKProdutoClassProduto();}
return this._valueCollectionProdutoKProdutoClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoKProdutoClassProduto = value; 
               this._valueCollectionProdutoKProdutoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoMaterialClassProdutoOriginal;
       private List<Entidades.ProdutoMaterialClass > _collectionProdutoMaterialClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoMaterialClass> _valueCollectionProdutoMaterialClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoMaterialClass> CollectionProdutoMaterialClassProduto 
       { 
           get { if(!_valueCollectionProdutoMaterialClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoMaterialClassProduto();}
return this._valueCollectionProdutoMaterialClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoMaterialClassProduto = value; 
               this._valueCollectionProdutoMaterialClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoPaiFilhoClassProdutoPaiOriginal;
       private List<Entidades.ProdutoPaiFilhoClass > _collectionProdutoPaiFilhoClassProdutoPaiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPaiFilhoClassProdutoPaiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPaiFilhoClassProdutoPaiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoPaiFilhoClass> _valueCollectionProdutoPaiFilhoClassProdutoPai { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoPaiFilhoClass> CollectionProdutoPaiFilhoClassProdutoPai 
       { 
           get { if(!_valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoPaiFilhoClassProdutoPai();}
return this._valueCollectionProdutoPaiFilhoClassProdutoPai; } 
           set 
           { 
               this._valueCollectionProdutoPaiFilhoClassProdutoPai = value; 
               this._valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoPaiFilhoClassProdutoFilhoOriginal;
       private List<Entidades.ProdutoPaiFilhoClass > _collectionProdutoPaiFilhoClassProdutoFilhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPaiFilhoClassProdutoFilhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPaiFilhoClassProdutoFilhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoPaiFilhoClass> _valueCollectionProdutoPaiFilhoClassProdutoFilho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoPaiFilhoClass> CollectionProdutoPaiFilhoClassProdutoFilho 
       { 
           get { if(!_valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoPaiFilhoClassProdutoFilho();}
return this._valueCollectionProdutoPaiFilhoClassProdutoFilho; } 
           set 
           { 
               this._valueCollectionProdutoPaiFilhoClassProdutoFilho = value; 
               this._valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoPermissaoVendaPeriodosClassProdutoOriginal;
       private List<Entidades.ProdutoPermissaoVendaPeriodosClass > _collectionProdutoPermissaoVendaPeriodosClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoPermissaoVendaPeriodosClass> _valueCollectionProdutoPermissaoVendaPeriodosClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoPermissaoVendaPeriodosClass> CollectionProdutoPermissaoVendaPeriodosClassProduto 
       { 
           get { if(!_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoPermissaoVendaPeriodosClassProduto();}
return this._valueCollectionProdutoPermissaoVendaPeriodosClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoPermissaoVendaPeriodosClassProduto = value; 
               this._valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoPostoTrabalhoClassProdutoOriginal;
       private List<Entidades.ProdutoPostoTrabalhoClass > _collectionProdutoPostoTrabalhoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPostoTrabalhoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPostoTrabalhoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPostoTrabalhoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoPostoTrabalhoClass> _valueCollectionProdutoPostoTrabalhoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoPostoTrabalhoClass> CollectionProdutoPostoTrabalhoClassProduto 
       { 
           get { if(!_valueCollectionProdutoPostoTrabalhoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoPostoTrabalhoClassProduto();}
return this._valueCollectionProdutoPostoTrabalhoClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoPostoTrabalhoClassProduto = value; 
               this._valueCollectionProdutoPostoTrabalhoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoPrecoClassProdutoOriginal;
       private List<Entidades.ProdutoPrecoClass > _collectionProdutoPrecoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPrecoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPrecoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPrecoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoPrecoClass> _valueCollectionProdutoPrecoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoPrecoClass> CollectionProdutoPrecoClassProduto 
       { 
           get { if(!_valueCollectionProdutoPrecoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoPrecoClassProduto();}
return this._valueCollectionProdutoPrecoClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoPrecoClassProduto = value; 
               this._valueCollectionProdutoPrecoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoRecursoClassProdutoOriginal;
       private List<Entidades.ProdutoRecursoClass > _collectionProdutoRecursoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoRecursoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoRecursoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoRecursoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoRecursoClass> _valueCollectionProdutoRecursoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoRecursoClass> CollectionProdutoRecursoClassProduto 
       { 
           get { if(!_valueCollectionProdutoRecursoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoRecursoClassProduto();}
return this._valueCollectionProdutoRecursoClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoRecursoClassProduto = value; 
               this._valueCollectionProdutoRecursoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoRevisaoClassProdutoOriginal;
       private List<Entidades.ProdutoRevisaoClass > _collectionProdutoRevisaoClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoRevisaoClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoRevisaoClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoRevisaoClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoRevisaoClass> _valueCollectionProdutoRevisaoClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoRevisaoClass> CollectionProdutoRevisaoClassProduto 
       { 
           get { if(!_valueCollectionProdutoRevisaoClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoRevisaoClassProduto();}
return this._valueCollectionProdutoRevisaoClassProduto; } 
           set 
           { 
               this._valueCollectionProdutoRevisaoClassProduto = value; 
               this._valueCollectionProdutoRevisaoClassProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionSolicitacaoCompraClassProdutoOriginal;
       private List<Entidades.SolicitacaoCompraClass > _collectionSolicitacaoCompraClassProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.SolicitacaoCompraClass> _valueCollectionSolicitacaoCompraClassProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.SolicitacaoCompraClass> CollectionSolicitacaoCompraClassProduto 
       { 
           get { if(!_valueCollectionSolicitacaoCompraClassProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionSolicitacaoCompraClassProduto();}
return this._valueCollectionSolicitacaoCompraClassProduto; } 
           set 
           { 
               this._valueCollectionSolicitacaoCompraClassProduto = value; 
               this._valueCollectionSolicitacaoCompraClassProdutoLoaded = true; 
           } 
       } 

        public ProdutoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.EmiteOp = true;
           this.LeadTimeFabrica = 0;
           this.CalculoPreco = (TipoCalculoPrecoProdudo)0;
           this.LoteEconomico = 1;
           this.DataRevisaoCadastro = Configurations.DataIndependenteClass.GetData();
           this.TipoAquisicao = (TipoAquisicao)0;
           this.PoliticaEstoque = (PoliticaEstoque)0;
           this.QtdEtiquetaExpedicaoVolume = 2;
           this.PesoUnitario = 0;
           this.CadastroPcp = false;
           this.CadastroEngenharia = false;
           this.UtilizaDimensaoMaiorFilho = false;
           this.CadastroPreco = false;
           this.EtiquetaInterna = true;
           this.Temporario = false;
           this.Vermelho = 0;
           this.Verde = 0;
           this.Amarelo = 0;
           this.LotePadraoCompra = 1;
           this.UnidadesPorUnCompra = 1;
           this.LeadTimeCompra = 0;
           this.ImpedirSolicitacaoAuto = false;
           this.VersaoEstruturaAtual = 0;
           this.RastreamentoMaterial = false;
           this.EstruturaEmRevisao = false;
           this.UtilizandoEstoqueSeguranca = (EstoqueSeguranca)0;
           this.PermiteVenda = false;
           this.ImprimirEstruturaOp = false;
           this.ImprimeOpsRelacionadas = false;
           this.EmitePlanoCorte = false;
           this.ValidacaoPesoExpedicao = false;
           this.Ativo = true;
           this.LoteMinimo = 1;
           this.BloqueioPrecoVencido = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ProdutoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProdutoClass) GetEntity(typeof(ProdutoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionContratoFornecimentoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContratoFornecimentoClassProdutoChanged = true;
                  _valueCollectionContratoFornecimentoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContratoFornecimentoClassProdutoChanged = true; 
                  _valueCollectionContratoFornecimentoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ContratoFornecimentoClass item in e.OldItems) 
                 { 
                     _collectionContratoFornecimentoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContratoFornecimentoClassProdutoChanged = true; 
                  _valueCollectionContratoFornecimentoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ContratoFornecimentoClass item in _valueCollectionContratoFornecimentoClassProduto) 
                 { 
                     _collectionContratoFornecimentoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContratoFornecimentoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ContratoFornecimentoClass> oc;
                _valueCollectionContratoFornecimentoClassProdutoChanged = false;
                 _valueCollectionContratoFornecimentoClassProdutoCommitedChanged = false;
                _collectionContratoFornecimentoClassProdutoRemovidos = new List<Entidades.ContratoFornecimentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContratoFornecimentoClass>();
                }
                else{ 
                   Entidades.ContratoFornecimentoClass search = new Entidades.ContratoFornecimentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContratoFornecimentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.ContratoFornecimentoClass>().ToList());
                 }
                 _valueCollectionContratoFornecimentoClassProduto = new BindingList<Entidades.ContratoFornecimentoClass>(oc); 
                 _collectionContratoFornecimentoClassProdutoOriginal= (from a in _valueCollectionContratoFornecimentoClassProduto select a.ID).ToList();
                 _valueCollectionContratoFornecimentoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionContratoFornecimentoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContratoFornecimentoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionEstoqueGavetaItemClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueGavetaItemClassProdutoChanged = true;
                  _valueCollectionEstoqueGavetaItemClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueGavetaItemClassProdutoChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassProdutoCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in e.OldItems) 
                 { 
                     _collectionEstoqueGavetaItemClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueGavetaItemClassProdutoChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassProdutoCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in _valueCollectionEstoqueGavetaItemClassProduto) 
                 { 
                     _collectionEstoqueGavetaItemClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueGavetaItemClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueGavetaItemClass> oc;
                _valueCollectionEstoqueGavetaItemClassProdutoChanged = false;
                 _valueCollectionEstoqueGavetaItemClassProdutoCommitedChanged = false;
                _collectionEstoqueGavetaItemClassProdutoRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueGavetaItemClass>();
                }
                else{ 
                   Entidades.EstoqueGavetaItemClass search = new Entidades.EstoqueGavetaItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueGavetaItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.EstoqueGavetaItemClass>().ToList());
                 }
                 _valueCollectionEstoqueGavetaItemClassProduto = new BindingList<Entidades.EstoqueGavetaItemClass>(oc); 
                 _collectionEstoqueGavetaItemClassProdutoOriginal= (from a in _valueCollectionEstoqueGavetaItemClassProduto select a.ID).ToList();
                 _valueCollectionEstoqueGavetaItemClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueGavetaItemClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueGavetaItemClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFomularioRetiradaManualEstoqueClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassProdutoChanged = true;
                  _valueCollectionFomularioRetiradaManualEstoqueClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassProdutoChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassProdutoCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in e.OldItems) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassProdutoChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassProdutoCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in _valueCollectionFomularioRetiradaManualEstoqueClassProduto) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFomularioRetiradaManualEstoqueClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass> oc;
                _valueCollectionFomularioRetiradaManualEstoqueClassProdutoChanged = false;
                 _valueCollectionFomularioRetiradaManualEstoqueClassProdutoCommitedChanged = false;
                _collectionFomularioRetiradaManualEstoqueClassProdutoRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>();
                }
                else{ 
                   Entidades.FomularioRetiradaManualEstoqueClass search = new Entidades.FomularioRetiradaManualEstoqueClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.FomularioRetiradaManualEstoqueClass>().ToList());
                 }
                 _valueCollectionFomularioRetiradaManualEstoqueClassProduto = new BindingList<Entidades.FomularioRetiradaManualEstoqueClass>(oc); 
                 _collectionFomularioRetiradaManualEstoqueClassProdutoOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassProduto select a.ID).ToList();
                 _valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionFomularioRetiradaManualEstoqueClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFomularioRetiradaManualEstoqueClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraProdutoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraProdutoClassProdutoChanged = true;
                  _valueCollectionHistoricoCompraProdutoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraProdutoClassProdutoChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassProdutoCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraProdutoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraProdutoClassProdutoChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassProdutoCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in _valueCollectionHistoricoCompraProdutoClassProduto) 
                 { 
                     _collectionHistoricoCompraProdutoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraProdutoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraProdutoClass> oc;
                _valueCollectionHistoricoCompraProdutoClassProdutoChanged = false;
                 _valueCollectionHistoricoCompraProdutoClassProdutoCommitedChanged = false;
                _collectionHistoricoCompraProdutoClassProdutoRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraProdutoClass>();
                }
                else{ 
                   Entidades.HistoricoCompraProdutoClass search = new Entidades.HistoricoCompraProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.HistoricoCompraProdutoClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraProdutoClassProduto = new BindingList<Entidades.HistoricoCompraProdutoClass>(oc); 
                 _collectionHistoricoCompraProdutoClassProdutoOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassProduto select a.ID).ToList();
                 _valueCollectionHistoricoCompraProdutoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraProdutoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraProdutoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionKanbanAcionamentoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionKanbanAcionamentoClassProdutoChanged = true;
                  _valueCollectionKanbanAcionamentoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionKanbanAcionamentoClassProdutoChanged = true; 
                  _valueCollectionKanbanAcionamentoClassProdutoCommitedChanged = true;
                 foreach (Entidades.KanbanAcionamentoClass item in e.OldItems) 
                 { 
                     _collectionKanbanAcionamentoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionKanbanAcionamentoClassProdutoChanged = true; 
                  _valueCollectionKanbanAcionamentoClassProdutoCommitedChanged = true;
                 foreach (Entidades.KanbanAcionamentoClass item in _valueCollectionKanbanAcionamentoClassProduto) 
                 { 
                     _collectionKanbanAcionamentoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionKanbanAcionamentoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.KanbanAcionamentoClass> oc;
                _valueCollectionKanbanAcionamentoClassProdutoChanged = false;
                 _valueCollectionKanbanAcionamentoClassProdutoCommitedChanged = false;
                _collectionKanbanAcionamentoClassProdutoRemovidos = new List<Entidades.KanbanAcionamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.KanbanAcionamentoClass>();
                }
                else{ 
                   Entidades.KanbanAcionamentoClass search = new Entidades.KanbanAcionamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.KanbanAcionamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.KanbanAcionamentoClass>().ToList());
                 }
                 _valueCollectionKanbanAcionamentoClassProduto = new BindingList<Entidades.KanbanAcionamentoClass>(oc); 
                 _collectionKanbanAcionamentoClassProdutoOriginal= (from a in _valueCollectionKanbanAcionamentoClassProduto select a.ID).ToList();
                 _valueCollectionKanbanAcionamentoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionKanbanAcionamentoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionKanbanAcionamentoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionLoteClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLoteClassProdutoChanged = true;
                  _valueCollectionLoteClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLoteClassProdutoChanged = true; 
                  _valueCollectionLoteClassProdutoCommitedChanged = true;
                 foreach (Entidades.LoteClass item in e.OldItems) 
                 { 
                     _collectionLoteClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLoteClassProdutoChanged = true; 
                  _valueCollectionLoteClassProdutoCommitedChanged = true;
                 foreach (Entidades.LoteClass item in _valueCollectionLoteClassProduto) 
                 { 
                     _collectionLoteClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLoteClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.LoteClass> oc;
                _valueCollectionLoteClassProdutoChanged = false;
                 _valueCollectionLoteClassProdutoCommitedChanged = false;
                _collectionLoteClassProdutoRemovidos = new List<Entidades.LoteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LoteClass>();
                }
                else{ 
                   Entidades.LoteClass search = new Entidades.LoteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LoteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.LoteClass>().ToList());
                 }
                 _valueCollectionLoteClassProduto = new BindingList<Entidades.LoteClass>(oc); 
                 _collectionLoteClassProdutoOriginal= (from a in _valueCollectionLoteClassProduto select a.ID).ToList();
                 _valueCollectionLoteClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionLoteClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLoteClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoCompraItemClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoCompraItemClassProdutoChanged = true;
                  _valueCollectionOrcamentoCompraItemClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoCompraItemClassProdutoChanged = true; 
                  _valueCollectionOrcamentoCompraItemClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoCompraItemClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoCompraItemClassProdutoChanged = true; 
                  _valueCollectionOrcamentoCompraItemClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraItemClass item in _valueCollectionOrcamentoCompraItemClassProduto) 
                 { 
                     _collectionOrcamentoCompraItemClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoCompraItemClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoCompraItemClass> oc;
                _valueCollectionOrcamentoCompraItemClassProdutoChanged = false;
                 _valueCollectionOrcamentoCompraItemClassProdutoCommitedChanged = false;
                _collectionOrcamentoCompraItemClassProdutoRemovidos = new List<Entidades.OrcamentoCompraItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoCompraItemClass>();
                }
                else{ 
                   Entidades.OrcamentoCompraItemClass search = new Entidades.OrcamentoCompraItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoCompraItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.OrcamentoCompraItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoCompraItemClassProduto = new BindingList<Entidades.OrcamentoCompraItemClass>(oc); 
                 _collectionOrcamentoCompraItemClassProdutoOriginal= (from a in _valueCollectionOrcamentoCompraItemClassProduto select a.ID).ToList();
                 _valueCollectionOrcamentoCompraItemClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoCompraItemClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoCompraItemClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoConfiguradoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoConfiguradoClassProdutoChanged = true;
                  _valueCollectionOrcamentoConfiguradoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoConfiguradoClassProdutoChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoConfiguradoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoConfiguradoClassProdutoChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in _valueCollectionOrcamentoConfiguradoClassProduto) 
                 { 
                     _collectionOrcamentoConfiguradoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoConfiguradoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoConfiguradoClass> oc;
                _valueCollectionOrcamentoConfiguradoClassProdutoChanged = false;
                 _valueCollectionOrcamentoConfiguradoClassProdutoCommitedChanged = false;
                _collectionOrcamentoConfiguradoClassProdutoRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoConfiguradoClass>();
                }
                else{ 
                   Entidades.OrcamentoConfiguradoClass search = new Entidades.OrcamentoConfiguradoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoConfiguradoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.OrcamentoConfiguradoClass>().ToList());
                 }
                 _valueCollectionOrcamentoConfiguradoClassProduto = new BindingList<Entidades.OrcamentoConfiguradoClass>(oc); 
                 _collectionOrcamentoConfiguradoClassProdutoOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassProduto select a.ID).ToList();
                 _valueCollectionOrcamentoConfiguradoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoConfiguradoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoConfiguradoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemClassProdutoChanged = true;
                  _valueCollectionOrcamentoItemClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemClassProdutoChanged = true; 
                  _valueCollectionOrcamentoItemClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemClassProdutoChanged = true; 
                  _valueCollectionOrcamentoItemClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in _valueCollectionOrcamentoItemClassProduto) 
                 { 
                     _collectionOrcamentoItemClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemClass> oc;
                _valueCollectionOrcamentoItemClassProdutoChanged = false;
                 _valueCollectionOrcamentoItemClassProdutoCommitedChanged = false;
                _collectionOrcamentoItemClassProdutoRemovidos = new List<Entidades.OrcamentoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemClass>();
                }
                else{ 
                   Entidades.OrcamentoItemClass search = new Entidades.OrcamentoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.OrcamentoItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemClassProduto = new BindingList<Entidades.OrcamentoItemClass>(oc); 
                 _collectionOrcamentoItemClassProdutoOriginal= (from a in _valueCollectionOrcamentoItemClassProduto select a.ID).ToList();
                 _valueCollectionOrcamentoItemClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoClassProdutoChanged = true;
                  _valueCollectionOrdemProducaoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoClassProdutoChanged = true; 
                  _valueCollectionOrdemProducaoClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoClassProdutoChanged = true; 
                  _valueCollectionOrdemProducaoClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoClass item in _valueCollectionOrdemProducaoClassProduto) 
                 { 
                     _collectionOrdemProducaoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoClass> oc;
                _valueCollectionOrdemProducaoClassProdutoChanged = false;
                 _valueCollectionOrdemProducaoClassProdutoCommitedChanged = false;
                _collectionOrdemProducaoClassProdutoRemovidos = new List<Entidades.OrdemProducaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoClass search = new Entidades.OrdemProducaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this)                    }                       ).Cast<Entidades.OrdemProducaoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoClassProduto = new BindingList<Entidades.OrdemProducaoClass>(oc); 
                 _collectionOrdemProducaoClassProdutoOriginal= (from a in _valueCollectionOrdemProducaoClassProduto select a.ID).ToList();
                 _valueCollectionOrdemProducaoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoProdutoComponenteClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoChanged = true;
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoChanged = true; 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoProdutoComponenteClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoProdutoComponenteClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoChanged = true; 
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoProdutoComponenteClass item in _valueCollectionOrdemProducaoProdutoComponenteClassProduto) 
                 { 
                     _collectionOrdemProducaoProdutoComponenteClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoProdutoComponenteClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoProdutoComponenteClass> oc;
                _valueCollectionOrdemProducaoProdutoComponenteClassProdutoChanged = false;
                 _valueCollectionOrdemProducaoProdutoComponenteClassProdutoCommitedChanged = false;
                _collectionOrdemProducaoProdutoComponenteClassProdutoRemovidos = new List<Entidades.OrdemProducaoProdutoComponenteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoProdutoComponenteClass>();
                }
                else{ 
                   Entidades.OrdemProducaoProdutoComponenteClass search = new Entidades.OrdemProducaoProdutoComponenteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoProdutoComponenteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.OrdemProducaoProdutoComponenteClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoProdutoComponenteClassProduto = new BindingList<Entidades.OrdemProducaoProdutoComponenteClass>(oc); 
                 _collectionOrdemProducaoProdutoComponenteClassProdutoOriginal= (from a in _valueCollectionOrdemProducaoProdutoComponenteClassProduto select a.ID).ToList();
                 _valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoProdutoComponenteClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoProdutoComponenteClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaClassProdutoChanged = true;
                  _valueCollectionOrderItemEtiquetaClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaClassProdutoChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaClassProdutoChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassProdutoCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in _valueCollectionOrderItemEtiquetaClassProduto) 
                 { 
                     _collectionOrderItemEtiquetaClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaClass> oc;
                _valueCollectionOrderItemEtiquetaClassProdutoChanged = false;
                 _valueCollectionOrderItemEtiquetaClassProdutoCommitedChanged = false;
                _collectionOrderItemEtiquetaClassProdutoRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaClass search = new Entidades.OrderItemEtiquetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaClassProduto = new BindingList<Entidades.OrderItemEtiquetaClass>(oc); 
                 _collectionOrderItemEtiquetaClassProdutoOriginal= (from a in _valueCollectionOrderItemEtiquetaClassProduto select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassProdutoChanged = true;
                  _valueCollectionPedidoItemClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassProdutoChanged = true; 
                  _valueCollectionPedidoItemClassProdutoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassProdutoChanged = true; 
                  _valueCollectionPedidoItemClassProdutoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassProduto) 
                 { 
                     _collectionPedidoItemClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassProdutoChanged = false;
                 _valueCollectionPedidoItemClassProdutoCommitedChanged = false;
                _collectionPedidoItemClassProdutoRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassProduto = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassProdutoOriginal= (from a in _valueCollectionPedidoItemClassProduto select a.ID).ToList();
                 _valueCollectionPedidoItemClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoAcabamentoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoAcabamentoClassProdutoChanged = true;
                  _valueCollectionProdutoAcabamentoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoAcabamentoClassProdutoChanged = true; 
                  _valueCollectionProdutoAcabamentoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoAcabamentoClass item in e.OldItems) 
                 { 
                     _collectionProdutoAcabamentoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoAcabamentoClassProdutoChanged = true; 
                  _valueCollectionProdutoAcabamentoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoAcabamentoClass item in _valueCollectionProdutoAcabamentoClassProduto) 
                 { 
                     _collectionProdutoAcabamentoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoAcabamentoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoAcabamentoClass> oc;
                _valueCollectionProdutoAcabamentoClassProdutoChanged = false;
                 _valueCollectionProdutoAcabamentoClassProdutoCommitedChanged = false;
                _collectionProdutoAcabamentoClassProdutoRemovidos = new List<Entidades.ProdutoAcabamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoAcabamentoClass>();
                }
                else{ 
                   Entidades.ProdutoAcabamentoClass search = new Entidades.ProdutoAcabamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoAcabamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.ProdutoAcabamentoClass>().ToList());
                 }
                 _valueCollectionProdutoAcabamentoClassProduto = new BindingList<Entidades.ProdutoAcabamentoClass>(oc); 
                 _collectionProdutoAcabamentoClassProdutoOriginal= (from a in _valueCollectionProdutoAcabamentoClassProduto select a.ID).ToList();
                 _valueCollectionProdutoAcabamentoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoAcabamentoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoAcabamentoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoBloqueioQualidadeClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoBloqueioQualidadeClassProdutoChanged = true;
                  _valueCollectionProdutoBloqueioQualidadeClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoBloqueioQualidadeClassProdutoChanged = true; 
                  _valueCollectionProdutoBloqueioQualidadeClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoBloqueioQualidadeClass item in e.OldItems) 
                 { 
                     _collectionProdutoBloqueioQualidadeClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoBloqueioQualidadeClassProdutoChanged = true; 
                  _valueCollectionProdutoBloqueioQualidadeClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoBloqueioQualidadeClass item in _valueCollectionProdutoBloqueioQualidadeClassProduto) 
                 { 
                     _collectionProdutoBloqueioQualidadeClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoBloqueioQualidadeClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoBloqueioQualidadeClass> oc;
                _valueCollectionProdutoBloqueioQualidadeClassProdutoChanged = false;
                 _valueCollectionProdutoBloqueioQualidadeClassProdutoCommitedChanged = false;
                _collectionProdutoBloqueioQualidadeClassProdutoRemovidos = new List<Entidades.ProdutoBloqueioQualidadeClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoBloqueioQualidadeClass>();
                }
                else{ 
                   Entidades.ProdutoBloqueioQualidadeClass search = new Entidades.ProdutoBloqueioQualidadeClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoBloqueioQualidadeClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.ProdutoBloqueioQualidadeClass>().ToList());
                 }
                 _valueCollectionProdutoBloqueioQualidadeClassProduto = new BindingList<Entidades.ProdutoBloqueioQualidadeClass>(oc); 
                 _collectionProdutoBloqueioQualidadeClassProdutoOriginal= (from a in _valueCollectionProdutoBloqueioQualidadeClassProduto select a.ID).ToList();
                 _valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoBloqueioQualidadeClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoBloqueioQualidadeClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoDocumentoTipoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoDocumentoTipoClassProdutoChanged = true;
                  _valueCollectionProdutoDocumentoTipoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoDocumentoTipoClassProdutoChanged = true; 
                  _valueCollectionProdutoDocumentoTipoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoDocumentoTipoClass item in e.OldItems) 
                 { 
                     _collectionProdutoDocumentoTipoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoDocumentoTipoClassProdutoChanged = true; 
                  _valueCollectionProdutoDocumentoTipoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoDocumentoTipoClass item in _valueCollectionProdutoDocumentoTipoClassProduto) 
                 { 
                     _collectionProdutoDocumentoTipoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoDocumentoTipoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoDocumentoTipoClass> oc;
                _valueCollectionProdutoDocumentoTipoClassProdutoChanged = false;
                 _valueCollectionProdutoDocumentoTipoClassProdutoCommitedChanged = false;
                _collectionProdutoDocumentoTipoClassProdutoRemovidos = new List<Entidades.ProdutoDocumentoTipoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoDocumentoTipoClass>();
                }
                else{ 
                   Entidades.ProdutoDocumentoTipoClass search = new Entidades.ProdutoDocumentoTipoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoDocumentoTipoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.ProdutoDocumentoTipoClass>().ToList());
                 }
                 _valueCollectionProdutoDocumentoTipoClassProduto = new BindingList<Entidades.ProdutoDocumentoTipoClass>(oc); 
                 _collectionProdutoDocumentoTipoClassProdutoOriginal= (from a in _valueCollectionProdutoDocumentoTipoClassProduto select a.ID).ToList();
                 _valueCollectionProdutoDocumentoTipoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoDocumentoTipoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoDocumentoTipoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoEstruturaInconsistenciaClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoChanged = true;
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoChanged = true; 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoEstruturaInconsistenciaClass item in e.OldItems) 
                 { 
                     _collectionProdutoEstruturaInconsistenciaClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoChanged = true; 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoEstruturaInconsistenciaClass item in _valueCollectionProdutoEstruturaInconsistenciaClassProduto) 
                 { 
                     _collectionProdutoEstruturaInconsistenciaClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoEstruturaInconsistenciaClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoEstruturaInconsistenciaClass> oc;
                _valueCollectionProdutoEstruturaInconsistenciaClassProdutoChanged = false;
                 _valueCollectionProdutoEstruturaInconsistenciaClassProdutoCommitedChanged = false;
                _collectionProdutoEstruturaInconsistenciaClassProdutoRemovidos = new List<Entidades.ProdutoEstruturaInconsistenciaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoEstruturaInconsistenciaClass>();
                }
                else{ 
                   Entidades.ProdutoEstruturaInconsistenciaClass search = new Entidades.ProdutoEstruturaInconsistenciaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoEstruturaInconsistenciaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this)                    }                       ).Cast<Entidades.ProdutoEstruturaInconsistenciaClass>().ToList());
                 }
                 _valueCollectionProdutoEstruturaInconsistenciaClassProduto = new BindingList<Entidades.ProdutoEstruturaInconsistenciaClass>(oc); 
                 _collectionProdutoEstruturaInconsistenciaClassProdutoOriginal= (from a in _valueCollectionProdutoEstruturaInconsistenciaClassProduto select a.ID).ToList();
                 _valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoEstruturaInconsistenciaClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoEstruturaInconsistenciaClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoEstruturaLockClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoEstruturaLockClassProdutoChanged = true;
                  _valueCollectionProdutoEstruturaLockClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoEstruturaLockClassProdutoChanged = true; 
                  _valueCollectionProdutoEstruturaLockClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoEstruturaLockClass item in e.OldItems) 
                 { 
                     _collectionProdutoEstruturaLockClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoEstruturaLockClassProdutoChanged = true; 
                  _valueCollectionProdutoEstruturaLockClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoEstruturaLockClass item in _valueCollectionProdutoEstruturaLockClassProduto) 
                 { 
                     _collectionProdutoEstruturaLockClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoEstruturaLockClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoEstruturaLockClass> oc;
                _valueCollectionProdutoEstruturaLockClassProdutoChanged = false;
                 _valueCollectionProdutoEstruturaLockClassProdutoCommitedChanged = false;
                _collectionProdutoEstruturaLockClassProdutoRemovidos = new List<Entidades.ProdutoEstruturaLockClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoEstruturaLockClass>();
                }
                else{ 
                   Entidades.ProdutoEstruturaLockClass search = new Entidades.ProdutoEstruturaLockClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoEstruturaLockClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this)                    }                       ).Cast<Entidades.ProdutoEstruturaLockClass>().ToList());
                 }
                 _valueCollectionProdutoEstruturaLockClassProduto = new BindingList<Entidades.ProdutoEstruturaLockClass>(oc); 
                 _collectionProdutoEstruturaLockClassProdutoOriginal= (from a in _valueCollectionProdutoEstruturaLockClassProduto select a.ID).ToList();
                 _valueCollectionProdutoEstruturaLockClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoEstruturaLockClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoEstruturaLockClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoFiscalClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoFiscalClassProdutoChanged = true;
                  _valueCollectionProdutoFiscalClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoFiscalClassProdutoChanged = true; 
                  _valueCollectionProdutoFiscalClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoFiscalClass item in e.OldItems) 
                 { 
                     _collectionProdutoFiscalClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoFiscalClassProdutoChanged = true; 
                  _valueCollectionProdutoFiscalClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoFiscalClass item in _valueCollectionProdutoFiscalClassProduto) 
                 { 
                     _collectionProdutoFiscalClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoFiscalClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoFiscalClass> oc;
                _valueCollectionProdutoFiscalClassProdutoChanged = false;
                 _valueCollectionProdutoFiscalClassProdutoCommitedChanged = false;
                _collectionProdutoFiscalClassProdutoRemovidos = new List<Entidades.ProdutoFiscalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoFiscalClass>();
                }
                else{ 
                   Entidades.ProdutoFiscalClass search = new Entidades.ProdutoFiscalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoFiscalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this)                    }                       ).Cast<Entidades.ProdutoFiscalClass>().ToList());
                 }
                 _valueCollectionProdutoFiscalClassProduto = new BindingList<Entidades.ProdutoFiscalClass>(oc); 
                 _collectionProdutoFiscalClassProdutoOriginal= (from a in _valueCollectionProdutoFiscalClassProduto select a.ID).ToList();
                 _valueCollectionProdutoFiscalClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoFiscalClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoFiscalClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoFornecedorClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoFornecedorClassProdutoChanged = true;
                  _valueCollectionProdutoFornecedorClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoFornecedorClassProdutoChanged = true; 
                  _valueCollectionProdutoFornecedorClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoFornecedorClass item in e.OldItems) 
                 { 
                     _collectionProdutoFornecedorClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoFornecedorClassProdutoChanged = true; 
                  _valueCollectionProdutoFornecedorClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoFornecedorClass item in _valueCollectionProdutoFornecedorClassProduto) 
                 { 
                     _collectionProdutoFornecedorClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoFornecedorClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoFornecedorClass> oc;
                _valueCollectionProdutoFornecedorClassProdutoChanged = false;
                 _valueCollectionProdutoFornecedorClassProdutoCommitedChanged = false;
                _collectionProdutoFornecedorClassProdutoRemovidos = new List<Entidades.ProdutoFornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoFornecedorClass>();
                }
                else{ 
                   Entidades.ProdutoFornecedorClass search = new Entidades.ProdutoFornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoFornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.ProdutoFornecedorClass>().ToList());
                 }
                 _valueCollectionProdutoFornecedorClassProduto = new BindingList<Entidades.ProdutoFornecedorClass>(oc); 
                 _collectionProdutoFornecedorClassProdutoOriginal= (from a in _valueCollectionProdutoFornecedorClassProduto select a.ID).ToList();
                 _valueCollectionProdutoFornecedorClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoFornecedorClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoFornecedorClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoKProdutoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoKProdutoClassProdutoChanged = true;
                  _valueCollectionProdutoKProdutoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoKProdutoClassProdutoChanged = true; 
                  _valueCollectionProdutoKProdutoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoKProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoKProdutoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoKProdutoClassProdutoChanged = true; 
                  _valueCollectionProdutoKProdutoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoKProdutoClass item in _valueCollectionProdutoKProdutoClassProduto) 
                 { 
                     _collectionProdutoKProdutoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoKProdutoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoKProdutoClass> oc;
                _valueCollectionProdutoKProdutoClassProdutoChanged = false;
                 _valueCollectionProdutoKProdutoClassProdutoCommitedChanged = false;
                _collectionProdutoKProdutoClassProdutoRemovidos = new List<Entidades.ProdutoKProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoKProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoKProdutoClass search = new Entidades.ProdutoKProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoKProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this)                    }                       ).Cast<Entidades.ProdutoKProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoKProdutoClassProduto = new BindingList<Entidades.ProdutoKProdutoClass>(oc); 
                 _collectionProdutoKProdutoClassProdutoOriginal= (from a in _valueCollectionProdutoKProdutoClassProduto select a.ID).ToList();
                 _valueCollectionProdutoKProdutoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoKProdutoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoKProdutoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoMaterialClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoMaterialClassProdutoChanged = true;
                  _valueCollectionProdutoMaterialClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoMaterialClassProdutoChanged = true; 
                  _valueCollectionProdutoMaterialClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in e.OldItems) 
                 { 
                     _collectionProdutoMaterialClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoMaterialClassProdutoChanged = true; 
                  _valueCollectionProdutoMaterialClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in _valueCollectionProdutoMaterialClassProduto) 
                 { 
                     _collectionProdutoMaterialClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoMaterialClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoMaterialClass> oc;
                _valueCollectionProdutoMaterialClassProdutoChanged = false;
                 _valueCollectionProdutoMaterialClassProdutoCommitedChanged = false;
                _collectionProdutoMaterialClassProdutoRemovidos = new List<Entidades.ProdutoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoMaterialClass>();
                }
                else{ 
                   Entidades.ProdutoMaterialClass search = new Entidades.ProdutoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.ProdutoMaterialClass>().ToList());
                 }
                 _valueCollectionProdutoMaterialClassProduto = new BindingList<Entidades.ProdutoMaterialClass>(oc); 
                 _collectionProdutoMaterialClassProdutoOriginal= (from a in _valueCollectionProdutoMaterialClassProduto select a.ID).ToList();
                 _valueCollectionProdutoMaterialClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoMaterialClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoMaterialClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoPaiFilhoClassProdutoPaiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoPaiFilhoClassProdutoPaiChanged = true;
                  _valueCollectionProdutoPaiFilhoClassProdutoPaiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoPaiFilhoClassProdutoPaiChanged = true; 
                  _valueCollectionProdutoPaiFilhoClassProdutoPaiCommitedChanged = true;
                 foreach (Entidades.ProdutoPaiFilhoClass item in e.OldItems) 
                 { 
                     _collectionProdutoPaiFilhoClassProdutoPaiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoPaiFilhoClassProdutoPaiChanged = true; 
                  _valueCollectionProdutoPaiFilhoClassProdutoPaiCommitedChanged = true;
                 foreach (Entidades.ProdutoPaiFilhoClass item in _valueCollectionProdutoPaiFilhoClassProdutoPai) 
                 { 
                     _collectionProdutoPaiFilhoClassProdutoPaiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoPaiFilhoClassProdutoPai()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoPaiFilhoClass> oc;
                _valueCollectionProdutoPaiFilhoClassProdutoPaiChanged = false;
                 _valueCollectionProdutoPaiFilhoClassProdutoPaiCommitedChanged = false;
                _collectionProdutoPaiFilhoClassProdutoPaiRemovidos = new List<Entidades.ProdutoPaiFilhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoPaiFilhoClass>();
                }
                else{ 
                   Entidades.ProdutoPaiFilhoClass search = new Entidades.ProdutoPaiFilhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoPaiFilhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoPai", this),                     }                       ).Cast<Entidades.ProdutoPaiFilhoClass>().ToList());
                 }
                 _valueCollectionProdutoPaiFilhoClassProdutoPai = new BindingList<Entidades.ProdutoPaiFilhoClass>(oc); 
                 _collectionProdutoPaiFilhoClassProdutoPaiOriginal= (from a in _valueCollectionProdutoPaiFilhoClassProdutoPai select a.ID).ToList();
                 _valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded = true;
                 oc.CollectionChanged += CollectionProdutoPaiFilhoClassProdutoPaiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoPaiFilhoClassProdutoPai+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoPaiFilhoClassProdutoFilhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoPaiFilhoClassProdutoFilhoChanged = true;
                  _valueCollectionProdutoPaiFilhoClassProdutoFilhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoPaiFilhoClassProdutoFilhoChanged = true; 
                  _valueCollectionProdutoPaiFilhoClassProdutoFilhoCommitedChanged = true;
                 foreach (Entidades.ProdutoPaiFilhoClass item in e.OldItems) 
                 { 
                     _collectionProdutoPaiFilhoClassProdutoFilhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoPaiFilhoClassProdutoFilhoChanged = true; 
                  _valueCollectionProdutoPaiFilhoClassProdutoFilhoCommitedChanged = true;
                 foreach (Entidades.ProdutoPaiFilhoClass item in _valueCollectionProdutoPaiFilhoClassProdutoFilho) 
                 { 
                     _collectionProdutoPaiFilhoClassProdutoFilhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoPaiFilhoClassProdutoFilho()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoPaiFilhoClass> oc;
                _valueCollectionProdutoPaiFilhoClassProdutoFilhoChanged = false;
                 _valueCollectionProdutoPaiFilhoClassProdutoFilhoCommitedChanged = false;
                _collectionProdutoPaiFilhoClassProdutoFilhoRemovidos = new List<Entidades.ProdutoPaiFilhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoPaiFilhoClass>();
                }
                else{ 
                   Entidades.ProdutoPaiFilhoClass search = new Entidades.ProdutoPaiFilhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoPaiFilhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoFilho", this),                     }                       ).Cast<Entidades.ProdutoPaiFilhoClass>().ToList());
                 }
                 _valueCollectionProdutoPaiFilhoClassProdutoFilho = new BindingList<Entidades.ProdutoPaiFilhoClass>(oc); 
                 _collectionProdutoPaiFilhoClassProdutoFilhoOriginal= (from a in _valueCollectionProdutoPaiFilhoClassProdutoFilho select a.ID).ToList();
                 _valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoPaiFilhoClassProdutoFilhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoPaiFilhoClassProdutoFilho+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoPermissaoVendaPeriodosClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoChanged = true;
                  _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoChanged = true; 
                  _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoPermissaoVendaPeriodosClass item in e.OldItems) 
                 { 
                     _collectionProdutoPermissaoVendaPeriodosClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoChanged = true; 
                  _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoPermissaoVendaPeriodosClass item in _valueCollectionProdutoPermissaoVendaPeriodosClassProduto) 
                 { 
                     _collectionProdutoPermissaoVendaPeriodosClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoPermissaoVendaPeriodosClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoPermissaoVendaPeriodosClass> oc;
                _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoChanged = false;
                 _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoCommitedChanged = false;
                _collectionProdutoPermissaoVendaPeriodosClassProdutoRemovidos = new List<Entidades.ProdutoPermissaoVendaPeriodosClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoPermissaoVendaPeriodosClass>();
                }
                else{ 
                   Entidades.ProdutoPermissaoVendaPeriodosClass search = new Entidades.ProdutoPermissaoVendaPeriodosClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoPermissaoVendaPeriodosClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this)                    }                       ).Cast<Entidades.ProdutoPermissaoVendaPeriodosClass>().ToList());
                 }
                 _valueCollectionProdutoPermissaoVendaPeriodosClassProduto = new BindingList<Entidades.ProdutoPermissaoVendaPeriodosClass>(oc); 
                 _collectionProdutoPermissaoVendaPeriodosClassProdutoOriginal= (from a in _valueCollectionProdutoPermissaoVendaPeriodosClassProduto select a.ID).ToList();
                 _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoPermissaoVendaPeriodosClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoPermissaoVendaPeriodosClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoPostoTrabalhoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoPostoTrabalhoClassProdutoChanged = true;
                  _valueCollectionProdutoPostoTrabalhoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoPostoTrabalhoClassProdutoChanged = true; 
                  _valueCollectionProdutoPostoTrabalhoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoPostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionProdutoPostoTrabalhoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoPostoTrabalhoClassProdutoChanged = true; 
                  _valueCollectionProdutoPostoTrabalhoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoPostoTrabalhoClass item in _valueCollectionProdutoPostoTrabalhoClassProduto) 
                 { 
                     _collectionProdutoPostoTrabalhoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoPostoTrabalhoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoPostoTrabalhoClass> oc;
                _valueCollectionProdutoPostoTrabalhoClassProdutoChanged = false;
                 _valueCollectionProdutoPostoTrabalhoClassProdutoCommitedChanged = false;
                _collectionProdutoPostoTrabalhoClassProdutoRemovidos = new List<Entidades.ProdutoPostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoPostoTrabalhoClass>();
                }
                else{ 
                   Entidades.ProdutoPostoTrabalhoClass search = new Entidades.ProdutoPostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoPostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.ProdutoPostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionProdutoPostoTrabalhoClassProduto = new BindingList<Entidades.ProdutoPostoTrabalhoClass>(oc); 
                 _collectionProdutoPostoTrabalhoClassProdutoOriginal= (from a in _valueCollectionProdutoPostoTrabalhoClassProduto select a.ID).ToList();
                 _valueCollectionProdutoPostoTrabalhoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoPostoTrabalhoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoPostoTrabalhoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoPrecoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoPrecoClassProdutoChanged = true;
                  _valueCollectionProdutoPrecoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoPrecoClassProdutoChanged = true; 
                  _valueCollectionProdutoPrecoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoPrecoClass item in e.OldItems) 
                 { 
                     _collectionProdutoPrecoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoPrecoClassProdutoChanged = true; 
                  _valueCollectionProdutoPrecoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoPrecoClass item in _valueCollectionProdutoPrecoClassProduto) 
                 { 
                     _collectionProdutoPrecoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoPrecoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoPrecoClass> oc;
                _valueCollectionProdutoPrecoClassProdutoChanged = false;
                 _valueCollectionProdutoPrecoClassProdutoCommitedChanged = false;
                _collectionProdutoPrecoClassProdutoRemovidos = new List<Entidades.ProdutoPrecoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoPrecoClass>();
                }
                else{ 
                   Entidades.ProdutoPrecoClass search = new Entidades.ProdutoPrecoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoPrecoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this)                    }                       ).Cast<Entidades.ProdutoPrecoClass>().ToList());
                 }
                 _valueCollectionProdutoPrecoClassProduto = new BindingList<Entidades.ProdutoPrecoClass>(oc); 
                 _collectionProdutoPrecoClassProdutoOriginal= (from a in _valueCollectionProdutoPrecoClassProduto select a.ID).ToList();
                 _valueCollectionProdutoPrecoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoPrecoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoPrecoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoRecursoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoRecursoClassProdutoChanged = true;
                  _valueCollectionProdutoRecursoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoRecursoClassProdutoChanged = true; 
                  _valueCollectionProdutoRecursoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoRecursoClass item in e.OldItems) 
                 { 
                     _collectionProdutoRecursoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoRecursoClassProdutoChanged = true; 
                  _valueCollectionProdutoRecursoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoRecursoClass item in _valueCollectionProdutoRecursoClassProduto) 
                 { 
                     _collectionProdutoRecursoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoRecursoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoRecursoClass> oc;
                _valueCollectionProdutoRecursoClassProdutoChanged = false;
                 _valueCollectionProdutoRecursoClassProdutoCommitedChanged = false;
                _collectionProdutoRecursoClassProdutoRemovidos = new List<Entidades.ProdutoRecursoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoRecursoClass>();
                }
                else{ 
                   Entidades.ProdutoRecursoClass search = new Entidades.ProdutoRecursoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoRecursoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.ProdutoRecursoClass>().ToList());
                 }
                 _valueCollectionProdutoRecursoClassProduto = new BindingList<Entidades.ProdutoRecursoClass>(oc); 
                 _collectionProdutoRecursoClassProdutoOriginal= (from a in _valueCollectionProdutoRecursoClassProduto select a.ID).ToList();
                 _valueCollectionProdutoRecursoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoRecursoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoRecursoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoRevisaoClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoRevisaoClassProdutoChanged = true;
                  _valueCollectionProdutoRevisaoClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoRevisaoClassProdutoChanged = true; 
                  _valueCollectionProdutoRevisaoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoRevisaoClass item in e.OldItems) 
                 { 
                     _collectionProdutoRevisaoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoRevisaoClassProdutoChanged = true; 
                  _valueCollectionProdutoRevisaoClassProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoRevisaoClass item in _valueCollectionProdutoRevisaoClassProduto) 
                 { 
                     _collectionProdutoRevisaoClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoRevisaoClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoRevisaoClass> oc;
                _valueCollectionProdutoRevisaoClassProdutoChanged = false;
                 _valueCollectionProdutoRevisaoClassProdutoCommitedChanged = false;
                _collectionProdutoRevisaoClassProdutoRemovidos = new List<Entidades.ProdutoRevisaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoRevisaoClass>();
                }
                else{ 
                   Entidades.ProdutoRevisaoClass search = new Entidades.ProdutoRevisaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoRevisaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.ProdutoRevisaoClass>().ToList());
                 }
                 _valueCollectionProdutoRevisaoClassProduto = new BindingList<Entidades.ProdutoRevisaoClass>(oc); 
                 _collectionProdutoRevisaoClassProdutoOriginal= (from a in _valueCollectionProdutoRevisaoClassProduto select a.ID).ToList();
                 _valueCollectionProdutoRevisaoClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoRevisaoClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoRevisaoClassProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionSolicitacaoCompraClassProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionSolicitacaoCompraClassProdutoChanged = true;
                  _valueCollectionSolicitacaoCompraClassProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionSolicitacaoCompraClassProdutoChanged = true; 
                  _valueCollectionSolicitacaoCompraClassProdutoCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in e.OldItems) 
                 { 
                     _collectionSolicitacaoCompraClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionSolicitacaoCompraClassProdutoChanged = true; 
                  _valueCollectionSolicitacaoCompraClassProdutoCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in _valueCollectionSolicitacaoCompraClassProduto) 
                 { 
                     _collectionSolicitacaoCompraClassProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionSolicitacaoCompraClassProduto()
         {
            try
            {
                 ObservableCollection<Entidades.SolicitacaoCompraClass> oc;
                _valueCollectionSolicitacaoCompraClassProdutoChanged = false;
                 _valueCollectionSolicitacaoCompraClassProdutoCommitedChanged = false;
                _collectionSolicitacaoCompraClassProdutoRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.SolicitacaoCompraClass>();
                }
                else{ 
                   Entidades.SolicitacaoCompraClass search = new Entidades.SolicitacaoCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.SolicitacaoCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Produto", this),                     }                       ).Cast<Entidades.SolicitacaoCompraClass>().ToList());
                 }
                 _valueCollectionSolicitacaoCompraClassProduto = new BindingList<Entidades.SolicitacaoCompraClass>(oc); 
                 _collectionSolicitacaoCompraClassProdutoOriginal= (from a in _valueCollectionSolicitacaoCompraClassProduto select a.ID).ToList();
                 _valueCollectionSolicitacaoCompraClassProdutoLoaded = true;
                 oc.CollectionChanged += CollectionSolicitacaoCompraClassProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionSolicitacaoCompraClassProduto+"\r\n" + e.Message, e);
            }
         } 
private void LoadFigura()
        {
            try
            {
                if (this.ID == -1)
                {

                    FiguraLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT pro_figura FROM produto WHERE id_produto = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueFigura = (byte[]) tmp;
                }
                if (this._valueFigura != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _figuraOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueFigura));
                     }
                  } 
                  else 
                  { 
                        _figuraOriginal = null ;
                  } 
                FiguraLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroFiguraLoad + "\r\n" + e.Message, e);
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
                command.CommandText = "SELECT pro_imagem FROM produto WHERE id_produto = :id ";
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
                if (string.IsNullOrEmpty(Codigo))
                {
                    throw new Exception(ErroCodigoObrigatorio);
                }
                if (Codigo.Length >255)
                {
                    throw new Exception( ErroCodigoComprimento);
                }
                if ( _valueAcsUsuario == null)
                {
                    throw new Exception(ErroAcsUsuarioObrigatorio);
                }
                if ( _valueModeloEtiquetaExpedicao == null)
                {
                    throw new Exception(ErroModeloEtiquetaExpedicaoObrigatorio);
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
                    "  public.produto  " +
                    "WHERE " +
                    "  id_produto = :id";
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
                        "  public.produto   " +
                        "SET  " + 
                        "  pro_codigo = :pro_codigo, " + 
                        "  pro_codigo_cliente = :pro_codigo_cliente, " + 
                        "  pro_descricao = :pro_descricao, " + 
                        "  pro_emite_op = :pro_emite_op, " + 
                        "  pro_lead_time_fabrica = :pro_lead_time_fabrica, " + 
                        "  pro_regra_dimensao = :pro_regra_dimensao, " + 
                        "  pro_figura = :pro_figura, " + 
                        "  pro_calculo_preco = :pro_calculo_preco, " + 
                        "  pro_lote_economico = :pro_lote_economico, " + 
                        "  pro_motivo_revisao = :pro_motivo_revisao, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  pro_data_revisao_cadastro = :pro_data_revisao_cadastro, " + 
                        "  pro_tipo_aquisicao = :pro_tipo_aquisicao, " + 
                        "  pro_politica_estoque = :pro_politica_estoque, " + 
                        "  id_classificacao_produto = :id_classificacao_produto, " + 
                        "  id_classificacao_produto_2 = :id_classificacao_produto_2, " + 
                        "  pro_qtd_etiqueta_expedicao_volume = :pro_qtd_etiqueta_expedicao_volume, " + 
                        "  id_embalagem = :id_embalagem, " + 
                        "  pro_descricao_ingles = :pro_descricao_ingles, " + 
                        "  pro_descricao_espanhol = :pro_descricao_espanhol, " + 
                        "  pro_peso_unitario = :pro_peso_unitario, " + 
                        "  id_familia_cliente = :id_familia_cliente, " + 
                        "  pro_cadastro_pcp = :pro_cadastro_pcp, " + 
                        "  pro_cadastro_engenharia = :pro_cadastro_engenharia, " + 
                        "  id_acabamento = :id_acabamento, " + 
                        "  id_variavel_1 = :id_variavel_1, " + 
                        "  id_variavel_2 = :id_variavel_2, " + 
                        "  id_variavel_3 = :id_variavel_3, " + 
                        "  id_variavel_4 = :id_variavel_4, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  id_unidade_medida = :id_unidade_medida, " + 
                        "  pro_utiliza_dimensao_maior_filho = :pro_utiliza_dimensao_maior_filho, " + 
                        "  id_local_fabricacao = :id_local_fabricacao, " + 
                        "  id_agrupador_op = :id_agrupador_op, " + 
                        "  id_aplicacao_cliente = :id_aplicacao_cliente, " + 
                        "  pro_tempo_limite = :pro_tempo_limite, " + 
                        "  pro_cadastro_preco = :pro_cadastro_preco, " + 
                        "  pro_etiqueta_interna = :pro_etiqueta_interna, " + 
                        "  pro_temporario = :pro_temporario, " + 
                        "  pro_vermelho = :pro_vermelho, " + 
                        "  pro_verde = :pro_verde, " + 
                        "  pro_amarelo = :pro_amarelo, " + 
                        "  pro_lote_padrao_compra = :pro_lote_padrao_compra, " + 
                        "  id_unidade_medida_compra = :id_unidade_medida_compra, " + 
                        "  pro_unidades_por_un_compra = :pro_unidades_por_un_compra, " + 
                        "  pro_lead_time_compra = :pro_lead_time_compra, " + 
                        "  pro_marcas_homologadas = :pro_marcas_homologadas, " + 
                        "  pro_impedir_solicitacao_auto = :pro_impedir_solicitacao_auto, " + 
                        "  pro_versao_estrutura_atual = :pro_versao_estrutura_atual, " + 
                        "  pro_rastreamento_material = :pro_rastreamento_material, " + 
                        "  pro_regra_valid_var1 = :pro_regra_valid_var1, " + 
                        "  pro_regra_valid_var2 = :pro_regra_valid_var2, " + 
                        "  pro_regra_valid_var3 = :pro_regra_valid_var3, " + 
                        "  pro_regra_valid_var4 = :pro_regra_valid_var4, " + 
                        "  pro_estrutura_em_revisao = :pro_estrutura_em_revisao, " + 
                        "  pro_utilizando_estoque_seguranca = :pro_utilizando_estoque_seguranca, " + 
                        "  pro_utilizando_estoque_seguranca_data = :pro_utilizando_estoque_seguranca_data, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  pro_imagem = :pro_imagem, " + 
                        "  pro_responsavel_frete = :pro_responsavel_frete, " + 
                        "  id_comprador = :id_comprador, " + 
                        "  pro_permite_venda = :pro_permite_venda, " + 
                        "  pro_descricao_adicional = :pro_descricao_adicional, " + 
                        "  pro_imprimir_estrutura_op = :pro_imprimir_estrutura_op, " + 
                        "  pro_imprime_ops_relacionadas = :pro_imprime_ops_relacionadas, " + 
                        "  pro_margem_recebimento = :pro_margem_recebimento, " + 
                        "  pro_emite_plano_corte = :pro_emite_plano_corte, " + 
                        "  pro_validacao_peso_expedicao = :pro_validacao_peso_expedicao, " + 
                        "  pro_gtin = :pro_gtin, " + 
                        "  pro_ativo = :pro_ativo, " + 
                        "  pro_estrutura_em_revisao_observacao = :pro_estrutura_em_revisao_observacao, " + 
                        "  id_modelo_etiqueta_expedicao = :id_modelo_etiqueta_expedicao, " + 
                        "  pro_lote_minimo = :pro_lote_minimo, " + 
                        "  pro_bloqueio_preco_vencido = :pro_bloqueio_preco_vencido "+
                        "WHERE  " +
                        "  id_produto = :id " +
                        "RETURNING id_produto;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.produto " +
                        "( " +
                        "  pro_codigo , " + 
                        "  pro_codigo_cliente , " + 
                        "  pro_descricao , " + 
                        "  pro_emite_op , " + 
                        "  pro_lead_time_fabrica , " + 
                        "  pro_regra_dimensao , " + 
                        "  pro_figura , " + 
                        "  pro_calculo_preco , " + 
                        "  pro_lote_economico , " + 
                        "  pro_motivo_revisao , " + 
                        "  id_acs_usuario , " + 
                        "  pro_data_revisao_cadastro , " + 
                        "  pro_tipo_aquisicao , " + 
                        "  pro_politica_estoque , " + 
                        "  id_classificacao_produto , " + 
                        "  id_classificacao_produto_2 , " + 
                        "  pro_qtd_etiqueta_expedicao_volume , " + 
                        "  id_embalagem , " + 
                        "  pro_descricao_ingles , " + 
                        "  pro_descricao_espanhol , " + 
                        "  pro_peso_unitario , " + 
                        "  id_familia_cliente , " + 
                        "  pro_cadastro_pcp , " + 
                        "  pro_cadastro_engenharia , " + 
                        "  id_acabamento , " + 
                        "  id_variavel_1 , " + 
                        "  id_variavel_2 , " + 
                        "  id_variavel_3 , " + 
                        "  id_variavel_4 , " + 
                        "  id_cliente , " + 
                        "  id_unidade_medida , " + 
                        "  pro_utiliza_dimensao_maior_filho , " + 
                        "  id_local_fabricacao , " + 
                        "  id_agrupador_op , " + 
                        "  id_aplicacao_cliente , " + 
                        "  pro_tempo_limite , " + 
                        "  pro_cadastro_preco , " + 
                        "  pro_etiqueta_interna , " + 
                        "  pro_temporario , " + 
                        "  pro_vermelho , " + 
                        "  pro_verde , " + 
                        "  pro_amarelo , " + 
                        "  pro_lote_padrao_compra , " + 
                        "  id_unidade_medida_compra , " + 
                        "  pro_unidades_por_un_compra , " + 
                        "  pro_lead_time_compra , " + 
                        "  pro_marcas_homologadas , " + 
                        "  pro_impedir_solicitacao_auto , " + 
                        "  pro_versao_estrutura_atual , " + 
                        "  pro_rastreamento_material , " + 
                        "  pro_regra_valid_var1 , " + 
                        "  pro_regra_valid_var2 , " + 
                        "  pro_regra_valid_var3 , " + 
                        "  pro_regra_valid_var4 , " + 
                        "  pro_estrutura_em_revisao , " + 
                        "  pro_utilizando_estoque_seguranca , " + 
                        "  pro_utilizando_estoque_seguranca_data , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  pro_imagem , " + 
                        "  pro_responsavel_frete , " + 
                        "  id_comprador , " + 
                        "  pro_permite_venda , " + 
                        "  pro_descricao_adicional , " + 
                        "  pro_imprimir_estrutura_op , " + 
                        "  pro_imprime_ops_relacionadas , " + 
                        "  pro_margem_recebimento , " + 
                        "  pro_emite_plano_corte , " + 
                        "  pro_validacao_peso_expedicao , " + 
                        "  pro_gtin , " + 
                        "  pro_ativo , " + 
                        "  pro_estrutura_em_revisao_observacao , " + 
                        "  id_modelo_etiqueta_expedicao , " + 
                        "  pro_lote_minimo , " + 
                        "  pro_bloqueio_preco_vencido  "+
                        ")  " +
                        "VALUES ( " +
                        "  :pro_codigo , " + 
                        "  :pro_codigo_cliente , " + 
                        "  :pro_descricao , " + 
                        "  :pro_emite_op , " + 
                        "  :pro_lead_time_fabrica , " + 
                        "  :pro_regra_dimensao , " + 
                        "  :pro_figura , " + 
                        "  :pro_calculo_preco , " + 
                        "  :pro_lote_economico , " + 
                        "  :pro_motivo_revisao , " + 
                        "  :id_acs_usuario , " + 
                        "  :pro_data_revisao_cadastro , " + 
                        "  :pro_tipo_aquisicao , " + 
                        "  :pro_politica_estoque , " + 
                        "  :id_classificacao_produto , " + 
                        "  :id_classificacao_produto_2 , " + 
                        "  :pro_qtd_etiqueta_expedicao_volume , " + 
                        "  :id_embalagem , " + 
                        "  :pro_descricao_ingles , " + 
                        "  :pro_descricao_espanhol , " + 
                        "  :pro_peso_unitario , " + 
                        "  :id_familia_cliente , " + 
                        "  :pro_cadastro_pcp , " + 
                        "  :pro_cadastro_engenharia , " + 
                        "  :id_acabamento , " + 
                        "  :id_variavel_1 , " + 
                        "  :id_variavel_2 , " + 
                        "  :id_variavel_3 , " + 
                        "  :id_variavel_4 , " + 
                        "  :id_cliente , " + 
                        "  :id_unidade_medida , " + 
                        "  :pro_utiliza_dimensao_maior_filho , " + 
                        "  :id_local_fabricacao , " + 
                        "  :id_agrupador_op , " + 
                        "  :id_aplicacao_cliente , " + 
                        "  :pro_tempo_limite , " + 
                        "  :pro_cadastro_preco , " + 
                        "  :pro_etiqueta_interna , " + 
                        "  :pro_temporario , " + 
                        "  :pro_vermelho , " + 
                        "  :pro_verde , " + 
                        "  :pro_amarelo , " + 
                        "  :pro_lote_padrao_compra , " + 
                        "  :id_unidade_medida_compra , " + 
                        "  :pro_unidades_por_un_compra , " + 
                        "  :pro_lead_time_compra , " + 
                        "  :pro_marcas_homologadas , " + 
                        "  :pro_impedir_solicitacao_auto , " + 
                        "  :pro_versao_estrutura_atual , " + 
                        "  :pro_rastreamento_material , " + 
                        "  :pro_regra_valid_var1 , " + 
                        "  :pro_regra_valid_var2 , " + 
                        "  :pro_regra_valid_var3 , " + 
                        "  :pro_regra_valid_var4 , " + 
                        "  :pro_estrutura_em_revisao , " + 
                        "  :pro_utilizando_estoque_seguranca , " + 
                        "  :pro_utilizando_estoque_seguranca_data , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :pro_imagem , " + 
                        "  :pro_responsavel_frete , " + 
                        "  :id_comprador , " + 
                        "  :pro_permite_venda , " + 
                        "  :pro_descricao_adicional , " + 
                        "  :pro_imprimir_estrutura_op , " + 
                        "  :pro_imprime_ops_relacionadas , " + 
                        "  :pro_margem_recebimento , " + 
                        "  :pro_emite_plano_corte , " + 
                        "  :pro_validacao_peso_expedicao , " + 
                        "  :pro_gtin , " + 
                        "  :pro_ativo , " + 
                        "  :pro_estrutura_em_revisao_observacao , " + 
                        "  :id_modelo_etiqueta_expedicao , " + 
                        "  :pro_lote_minimo , " + 
                        "  :pro_bloqueio_preco_vencido  "+
                        ")RETURNING id_produto;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_codigo_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_emite_op", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmiteOp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_lead_time_fabrica", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LeadTimeFabrica ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_regra_dimensao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RegraDimensao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_figura", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Figura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_calculo_preco", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.CalculoPreco);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_lote_economico", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LoteEconomico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_motivo_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MotivoRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_data_revisao_cadastro", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRevisaoCadastro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_tipo_aquisicao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoAquisicao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_politica_estoque", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.PoliticaEstoque);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_classificacao_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ClassificacaoProduto==null ? (object) DBNull.Value : this.ClassificacaoProduto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_classificacao_produto_2", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ClassificacaoProduto2==null ? (object) DBNull.Value : this.ClassificacaoProduto2.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_qtd_etiqueta_expedicao_volume", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdEtiquetaExpedicaoVolume ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_embalagem", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Embalagem==null ? (object) DBNull.Value : this.Embalagem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_descricao_ingles", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoIngles ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_descricao_espanhol", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoEspanhol ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_peso_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PesoUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_familia_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FamiliaCliente==null ? (object) DBNull.Value : this.FamiliaCliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_cadastro_pcp", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CadastroPcp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_cadastro_engenharia", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CadastroEngenharia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acabamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Acabamento==null ? (object) DBNull.Value : this.Acabamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_variavel_1", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Variavel1==null ? (object) DBNull.Value : this.Variavel1.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_variavel_2", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Variavel2==null ? (object) DBNull.Value : this.Variavel2.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_variavel_3", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Variavel3==null ? (object) DBNull.Value : this.Variavel3.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_variavel_4", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Variavel4==null ? (object) DBNull.Value : this.Variavel4.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedida==null ? (object) DBNull.Value : this.UnidadeMedida.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_utiliza_dimensao_maior_filho", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UtilizaDimensaoMaiorFilho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_local_fabricacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.LocalFabricacao==null ? (object) DBNull.Value : this.LocalFabricacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_agrupador_op", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AgrupadorOp==null ? (object) DBNull.Value : this.AgrupadorOp.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_aplicacao_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AplicacaoCliente==null ? (object) DBNull.Value : this.AplicacaoCliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_tempo_limite", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TempoLimite ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_cadastro_preco", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CadastroPreco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_etiqueta_interna", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaInterna ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_temporario", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Temporario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_vermelho", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Vermelho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_verde", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Verde ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_amarelo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Amarelo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_lote_padrao_compra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LotePadraoCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaCompra==null ? (object) DBNull.Value : this.UnidadeMedidaCompra.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_unidades_por_un_compra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UnidadesPorUnCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_lead_time_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LeadTimeCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_marcas_homologadas", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MarcasHomologadas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_impedir_solicitacao_auto", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpedirSolicitacaoAuto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_versao_estrutura_atual", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoEstruturaAtual ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_rastreamento_material", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RastreamentoMaterial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_regra_valid_var1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RegraValidVar1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_regra_valid_var2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RegraValidVar2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_regra_valid_var3", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RegraValidVar3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_regra_valid_var4", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RegraValidVar4 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_estrutura_em_revisao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EstruturaEmRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_utilizando_estoque_seguranca", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.UtilizandoEstoqueSeguranca);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_utilizando_estoque_seguranca_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UtilizandoEstoqueSegurancaData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_imagem", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Imagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_responsavel_frete", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.ResponsavelFrete.HasValue ? (object)Convert.ToInt16(this.ResponsavelFrete) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_comprador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Comprador==null ? (object) DBNull.Value : this.Comprador.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_permite_venda", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PermiteVenda ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_descricao_adicional", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoAdicional ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_imprimir_estrutura_op", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImprimirEstruturaOp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_imprime_ops_relacionadas", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImprimeOpsRelacionadas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_margem_recebimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MargemRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_emite_plano_corte", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmitePlanoCorte ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_validacao_peso_expedicao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValidacaoPesoExpedicao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_gtin", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Gtin ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_estrutura_em_revisao_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EstruturaEmRevisaoObservacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_modelo_etiqueta_expedicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ModeloEtiquetaExpedicao==null ? (object) DBNull.Value : this.ModeloEtiquetaExpedicao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_lote_minimo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LoteMinimo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_bloqueio_preco_vencido", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BloqueioPrecoVencido ?? DBNull.Value;

 
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
 if (CollectionContratoFornecimentoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContratoFornecimentoClassProduto+"\r\n";
                foreach (Entidades.ContratoFornecimentoClass tmp in CollectionContratoFornecimentoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionEstoqueGavetaItemClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueGavetaItemClassProduto+"\r\n";
                foreach (Entidades.EstoqueGavetaItemClass tmp in CollectionEstoqueGavetaItemClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFomularioRetiradaManualEstoqueClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassProduto+"\r\n";
                foreach (Entidades.FomularioRetiradaManualEstoqueClass tmp in CollectionFomularioRetiradaManualEstoqueClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraProdutoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraProdutoClassProduto+"\r\n";
                foreach (Entidades.HistoricoCompraProdutoClass tmp in CollectionHistoricoCompraProdutoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionKanbanAcionamentoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionKanbanAcionamentoClassProduto+"\r\n";
                foreach (Entidades.KanbanAcionamentoClass tmp in CollectionKanbanAcionamentoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionLoteClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLoteClassProduto+"\r\n";
                foreach (Entidades.LoteClass tmp in CollectionLoteClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoCompraItemClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoCompraItemClassProduto+"\r\n";
                foreach (Entidades.OrcamentoCompraItemClass tmp in CollectionOrcamentoCompraItemClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoConfiguradoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoConfiguradoClassProduto+"\r\n";
                foreach (Entidades.OrcamentoConfiguradoClass tmp in CollectionOrcamentoConfiguradoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassProduto+"\r\n";
                foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoClassProduto+"\r\n";
                foreach (Entidades.OrdemProducaoClass tmp in CollectionOrdemProducaoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoProdutoComponenteClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoProdutoComponenteClassProduto+"\r\n";
                foreach (Entidades.OrdemProducaoProdutoComponenteClass tmp in CollectionOrdemProducaoProdutoComponenteClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaClassProduto+"\r\n";
                foreach (Entidades.OrderItemEtiquetaClass tmp in CollectionOrderItemEtiquetaClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassProduto+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoAcabamentoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoAcabamentoClassProduto+"\r\n";
                foreach (Entidades.ProdutoAcabamentoClass tmp in CollectionProdutoAcabamentoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoBloqueioQualidadeClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoBloqueioQualidadeClassProduto+"\r\n";
                foreach (Entidades.ProdutoBloqueioQualidadeClass tmp in CollectionProdutoBloqueioQualidadeClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoDocumentoTipoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoDocumentoTipoClassProduto+"\r\n";
                foreach (Entidades.ProdutoDocumentoTipoClass tmp in CollectionProdutoDocumentoTipoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoEstruturaInconsistenciaClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoEstruturaInconsistenciaClassProduto+"\r\n";
                foreach (Entidades.ProdutoEstruturaInconsistenciaClass tmp in CollectionProdutoEstruturaInconsistenciaClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoEstruturaLockClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoEstruturaLockClassProduto+"\r\n";
                foreach (Entidades.ProdutoEstruturaLockClass tmp in CollectionProdutoEstruturaLockClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoFiscalClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoFiscalClassProduto+"\r\n";
                foreach (Entidades.ProdutoFiscalClass tmp in CollectionProdutoFiscalClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoFornecedorClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoFornecedorClassProduto+"\r\n";
                foreach (Entidades.ProdutoFornecedorClass tmp in CollectionProdutoFornecedorClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoKProdutoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoKProdutoClassProduto+"\r\n";
                foreach (Entidades.ProdutoKProdutoClass tmp in CollectionProdutoKProdutoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoMaterialClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassProduto+"\r\n";
                foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoPaiFilhoClassProdutoPai.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoPaiFilhoClassProdutoPai+"\r\n";
                foreach (Entidades.ProdutoPaiFilhoClass tmp in CollectionProdutoPaiFilhoClassProdutoPai)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoPaiFilhoClassProdutoFilho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoPaiFilhoClassProdutoFilho+"\r\n";
                foreach (Entidades.ProdutoPaiFilhoClass tmp in CollectionProdutoPaiFilhoClassProdutoFilho)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoPermissaoVendaPeriodosClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoPermissaoVendaPeriodosClassProduto+"\r\n";
                foreach (Entidades.ProdutoPermissaoVendaPeriodosClass tmp in CollectionProdutoPermissaoVendaPeriodosClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoPostoTrabalhoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoPostoTrabalhoClassProduto+"\r\n";
                foreach (Entidades.ProdutoPostoTrabalhoClass tmp in CollectionProdutoPostoTrabalhoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoPrecoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoPrecoClassProduto+"\r\n";
                foreach (Entidades.ProdutoPrecoClass tmp in CollectionProdutoPrecoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoRecursoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoRecursoClassProduto+"\r\n";
                foreach (Entidades.ProdutoRecursoClass tmp in CollectionProdutoRecursoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoRevisaoClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoRevisaoClassProduto+"\r\n";
                foreach (Entidades.ProdutoRevisaoClass tmp in CollectionProdutoRevisaoClassProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionSolicitacaoCompraClassProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionSolicitacaoCompraClassProduto+"\r\n";
                foreach (Entidades.SolicitacaoCompraClass tmp in CollectionSolicitacaoCompraClassProduto)
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
        public static ProdutoClass CopiarEntidade(ProdutoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProdutoClass toRet = new ProdutoClass(usuario,conn);
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.CodigoCliente= entidadeCopiar.CodigoCliente;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.EmiteOp= entidadeCopiar.EmiteOp;
 toRet.LeadTimeFabrica= entidadeCopiar.LeadTimeFabrica;
 toRet.RegraDimensao= entidadeCopiar.RegraDimensao;
 toRet.Figura= entidadeCopiar.Figura;
 toRet.CalculoPreco= entidadeCopiar.CalculoPreco;
 toRet.LoteEconomico= entidadeCopiar.LoteEconomico;
 toRet.MotivoRevisao= entidadeCopiar.MotivoRevisao;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.DataRevisaoCadastro= entidadeCopiar.DataRevisaoCadastro;
 toRet.TipoAquisicao= entidadeCopiar.TipoAquisicao;
 toRet.PoliticaEstoque= entidadeCopiar.PoliticaEstoque;
 toRet.ClassificacaoProduto= entidadeCopiar.ClassificacaoProduto;
 toRet.ClassificacaoProduto2= entidadeCopiar.ClassificacaoProduto2;
 toRet.QtdEtiquetaExpedicaoVolume= entidadeCopiar.QtdEtiquetaExpedicaoVolume;
 toRet.Embalagem= entidadeCopiar.Embalagem;
 toRet.DescricaoIngles= entidadeCopiar.DescricaoIngles;
 toRet.DescricaoEspanhol= entidadeCopiar.DescricaoEspanhol;
 toRet.PesoUnitario= entidadeCopiar.PesoUnitario;
 toRet.FamiliaCliente= entidadeCopiar.FamiliaCliente;
 toRet.CadastroPcp= entidadeCopiar.CadastroPcp;
 toRet.CadastroEngenharia= entidadeCopiar.CadastroEngenharia;
 toRet.Acabamento= entidadeCopiar.Acabamento;
 toRet.Variavel1= entidadeCopiar.Variavel1;
 toRet.Variavel2= entidadeCopiar.Variavel2;
 toRet.Variavel3= entidadeCopiar.Variavel3;
 toRet.Variavel4= entidadeCopiar.Variavel4;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.UnidadeMedida= entidadeCopiar.UnidadeMedida;
 toRet.UtilizaDimensaoMaiorFilho= entidadeCopiar.UtilizaDimensaoMaiorFilho;
 toRet.LocalFabricacao= entidadeCopiar.LocalFabricacao;
 toRet.AgrupadorOp= entidadeCopiar.AgrupadorOp;
 toRet.AplicacaoCliente= entidadeCopiar.AplicacaoCliente;
 toRet.TempoLimite= entidadeCopiar.TempoLimite;
 toRet.CadastroPreco= entidadeCopiar.CadastroPreco;
 toRet.EtiquetaInterna= entidadeCopiar.EtiquetaInterna;
 toRet.Temporario= entidadeCopiar.Temporario;
 toRet.Vermelho= entidadeCopiar.Vermelho;
 toRet.Verde= entidadeCopiar.Verde;
 toRet.Amarelo= entidadeCopiar.Amarelo;
 toRet.LotePadraoCompra= entidadeCopiar.LotePadraoCompra;
 toRet.UnidadeMedidaCompra= entidadeCopiar.UnidadeMedidaCompra;
 toRet.UnidadesPorUnCompra= entidadeCopiar.UnidadesPorUnCompra;
 toRet.LeadTimeCompra= entidadeCopiar.LeadTimeCompra;
 toRet.MarcasHomologadas= entidadeCopiar.MarcasHomologadas;
 toRet.ImpedirSolicitacaoAuto= entidadeCopiar.ImpedirSolicitacaoAuto;
 toRet.VersaoEstruturaAtual= entidadeCopiar.VersaoEstruturaAtual;
 toRet.RastreamentoMaterial= entidadeCopiar.RastreamentoMaterial;
 toRet.RegraValidVar1= entidadeCopiar.RegraValidVar1;
 toRet.RegraValidVar2= entidadeCopiar.RegraValidVar2;
 toRet.RegraValidVar3= entidadeCopiar.RegraValidVar3;
 toRet.RegraValidVar4= entidadeCopiar.RegraValidVar4;
 toRet.EstruturaEmRevisao= entidadeCopiar.EstruturaEmRevisao;
 toRet.UtilizandoEstoqueSeguranca= entidadeCopiar.UtilizandoEstoqueSeguranca;
 toRet.UtilizandoEstoqueSegurancaData= entidadeCopiar.UtilizandoEstoqueSegurancaData;
 toRet.Imagem= entidadeCopiar.Imagem;
 toRet.ResponsavelFrete= entidadeCopiar.ResponsavelFrete;
 toRet.Comprador= entidadeCopiar.Comprador;
 toRet.PermiteVenda= entidadeCopiar.PermiteVenda;
 toRet.DescricaoAdicional= entidadeCopiar.DescricaoAdicional;
 toRet.ImprimirEstruturaOp= entidadeCopiar.ImprimirEstruturaOp;
 toRet.ImprimeOpsRelacionadas= entidadeCopiar.ImprimeOpsRelacionadas;
 toRet.MargemRecebimento= entidadeCopiar.MargemRecebimento;
 toRet.EmitePlanoCorte= entidadeCopiar.EmitePlanoCorte;
 toRet.ValidacaoPesoExpedicao= entidadeCopiar.ValidacaoPesoExpedicao;
 toRet.Gtin= entidadeCopiar.Gtin;
 toRet.Ativo= entidadeCopiar.Ativo;
 toRet.EstruturaEmRevisaoObservacao= entidadeCopiar.EstruturaEmRevisaoObservacao;
 toRet.ModeloEtiquetaExpedicao= entidadeCopiar.ModeloEtiquetaExpedicao;
 toRet.LoteMinimo= entidadeCopiar.LoteMinimo;
 toRet.BloqueioPrecoVencido= entidadeCopiar.BloqueioPrecoVencido;

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
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _codigoClienteOriginal = CodigoCliente;
       _codigoClienteOriginalCommited = _codigoClienteOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _emiteOpOriginal = EmiteOp;
       _emiteOpOriginalCommited = _emiteOpOriginal;
       _leadTimeFabricaOriginal = LeadTimeFabrica;
       _leadTimeFabricaOriginalCommited = _leadTimeFabricaOriginal;
       _regraDimensaoOriginal = RegraDimensao;
       _regraDimensaoOriginalCommited = _regraDimensaoOriginal;
       _calculoPrecoOriginal = CalculoPreco;
       _calculoPrecoOriginalCommited = _calculoPrecoOriginal;
       _loteEconomicoOriginal = LoteEconomico;
       _loteEconomicoOriginalCommited = _loteEconomicoOriginal;
       _motivoRevisaoOriginal = MotivoRevisao;
       _motivoRevisaoOriginalCommited = _motivoRevisaoOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _dataRevisaoCadastroOriginal = DataRevisaoCadastro;
       _dataRevisaoCadastroOriginalCommited = _dataRevisaoCadastroOriginal;
       _tipoAquisicaoOriginal = TipoAquisicao;
       _tipoAquisicaoOriginalCommited = _tipoAquisicaoOriginal;
       _politicaEstoqueOriginal = PoliticaEstoque;
       _politicaEstoqueOriginalCommited = _politicaEstoqueOriginal;
       _classificacaoProdutoOriginal = ClassificacaoProduto;
       _classificacaoProdutoOriginalCommited = _classificacaoProdutoOriginal;
       _classificacaoProduto2Original = ClassificacaoProduto2;
       _classificacaoProduto2OriginalCommited = _classificacaoProduto2Original;
       _qtdEtiquetaExpedicaoVolumeOriginal = QtdEtiquetaExpedicaoVolume;
       _qtdEtiquetaExpedicaoVolumeOriginalCommited = _qtdEtiquetaExpedicaoVolumeOriginal;
       _embalagemOriginal = Embalagem;
       _embalagemOriginalCommited = _embalagemOriginal;
       _descricaoInglesOriginal = DescricaoIngles;
       _descricaoInglesOriginalCommited = _descricaoInglesOriginal;
       _descricaoEspanholOriginal = DescricaoEspanhol;
       _descricaoEspanholOriginalCommited = _descricaoEspanholOriginal;
       _pesoUnitarioOriginal = PesoUnitario;
       _pesoUnitarioOriginalCommited = _pesoUnitarioOriginal;
       _familiaClienteOriginal = FamiliaCliente;
       _familiaClienteOriginalCommited = _familiaClienteOriginal;
       _cadastroPcpOriginal = CadastroPcp;
       _cadastroPcpOriginalCommited = _cadastroPcpOriginal;
       _cadastroEngenhariaOriginal = CadastroEngenharia;
       _cadastroEngenhariaOriginalCommited = _cadastroEngenhariaOriginal;
       _acabamentoOriginal = Acabamento;
       _acabamentoOriginalCommited = _acabamentoOriginal;
       _variavel1Original = Variavel1;
       _variavel1OriginalCommited = _variavel1Original;
       _variavel2Original = Variavel2;
       _variavel2OriginalCommited = _variavel2Original;
       _variavel3Original = Variavel3;
       _variavel3OriginalCommited = _variavel3Original;
       _variavel4Original = Variavel4;
       _variavel4OriginalCommited = _variavel4Original;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _unidadeMedidaOriginal = UnidadeMedida;
       _unidadeMedidaOriginalCommited = _unidadeMedidaOriginal;
       _utilizaDimensaoMaiorFilhoOriginal = UtilizaDimensaoMaiorFilho;
       _utilizaDimensaoMaiorFilhoOriginalCommited = _utilizaDimensaoMaiorFilhoOriginal;
       _localFabricacaoOriginal = LocalFabricacao;
       _localFabricacaoOriginalCommited = _localFabricacaoOriginal;
       _agrupadorOpOriginal = AgrupadorOp;
       _agrupadorOpOriginalCommited = _agrupadorOpOriginal;
       _aplicacaoClienteOriginal = AplicacaoCliente;
       _aplicacaoClienteOriginalCommited = _aplicacaoClienteOriginal;
       _tempoLimiteOriginal = TempoLimite;
       _tempoLimiteOriginalCommited = _tempoLimiteOriginal;
       _cadastroPrecoOriginal = CadastroPreco;
       _cadastroPrecoOriginalCommited = _cadastroPrecoOriginal;
       _etiquetaInternaOriginal = EtiquetaInterna;
       _etiquetaInternaOriginalCommited = _etiquetaInternaOriginal;
       _temporarioOriginal = Temporario;
       _temporarioOriginalCommited = _temporarioOriginal;
       _vermelhoOriginal = Vermelho;
       _vermelhoOriginalCommited = _vermelhoOriginal;
       _verdeOriginal = Verde;
       _verdeOriginalCommited = _verdeOriginal;
       _amareloOriginal = Amarelo;
       _amareloOriginalCommited = _amareloOriginal;
       _lotePadraoCompraOriginal = LotePadraoCompra;
       _lotePadraoCompraOriginalCommited = _lotePadraoCompraOriginal;
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
       _versaoEstruturaAtualOriginal = VersaoEstruturaAtual;
       _versaoEstruturaAtualOriginalCommited = _versaoEstruturaAtualOriginal;
       _rastreamentoMaterialOriginal = RastreamentoMaterial;
       _rastreamentoMaterialOriginalCommited = _rastreamentoMaterialOriginal;
       _regraValidVar1Original = RegraValidVar1;
       _regraValidVar1OriginalCommited = _regraValidVar1Original;
       _regraValidVar2Original = RegraValidVar2;
       _regraValidVar2OriginalCommited = _regraValidVar2Original;
       _regraValidVar3Original = RegraValidVar3;
       _regraValidVar3OriginalCommited = _regraValidVar3Original;
       _regraValidVar4Original = RegraValidVar4;
       _regraValidVar4OriginalCommited = _regraValidVar4Original;
       _estruturaEmRevisaoOriginal = EstruturaEmRevisao;
       _estruturaEmRevisaoOriginalCommited = _estruturaEmRevisaoOriginal;
       _utilizandoEstoqueSegurancaOriginal = UtilizandoEstoqueSeguranca;
       _utilizandoEstoqueSegurancaOriginalCommited = _utilizandoEstoqueSegurancaOriginal;
       _utilizandoEstoqueSegurancaDataOriginal = UtilizandoEstoqueSegurancaData;
       _utilizandoEstoqueSegurancaDataOriginalCommited = _utilizandoEstoqueSegurancaDataOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _responsavelFreteOriginal = ResponsavelFrete;
       _responsavelFreteOriginalCommited = _responsavelFreteOriginal;
       _compradorOriginal = Comprador;
       _compradorOriginalCommited = _compradorOriginal;
       _permiteVendaOriginal = PermiteVenda;
       _permiteVendaOriginalCommited = _permiteVendaOriginal;
       _descricaoAdicionalOriginal = DescricaoAdicional;
       _descricaoAdicionalOriginalCommited = _descricaoAdicionalOriginal;
       _imprimirEstruturaOpOriginal = ImprimirEstruturaOp;
       _imprimirEstruturaOpOriginalCommited = _imprimirEstruturaOpOriginal;
       _imprimeOpsRelacionadasOriginal = ImprimeOpsRelacionadas;
       _imprimeOpsRelacionadasOriginalCommited = _imprimeOpsRelacionadasOriginal;
       _margemRecebimentoOriginal = MargemRecebimento;
       _margemRecebimentoOriginalCommited = _margemRecebimentoOriginal;
       _emitePlanoCorteOriginal = EmitePlanoCorte;
       _emitePlanoCorteOriginalCommited = _emitePlanoCorteOriginal;
       _validacaoPesoExpedicaoOriginal = ValidacaoPesoExpedicao;
       _validacaoPesoExpedicaoOriginalCommited = _validacaoPesoExpedicaoOriginal;
       _gtinOriginal = Gtin;
       _gtinOriginalCommited = _gtinOriginal;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;
       _estruturaEmRevisaoObservacaoOriginal = EstruturaEmRevisaoObservacao;
       _estruturaEmRevisaoObservacaoOriginalCommited = _estruturaEmRevisaoObservacaoOriginal;
       _modeloEtiquetaExpedicaoOriginal = ModeloEtiquetaExpedicao;
       _modeloEtiquetaExpedicaoOriginalCommited = _modeloEtiquetaExpedicaoOriginal;
       _loteMinimoOriginal = LoteMinimo;
       _loteMinimoOriginalCommited = _loteMinimoOriginal;
       _bloqueioPrecoVencidoOriginal = BloqueioPrecoVencido;
       _bloqueioPrecoVencidoOriginalCommited = _bloqueioPrecoVencidoOriginal;

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
       _codigoOriginalCommited = Codigo;
       _codigoClienteOriginalCommited = CodigoCliente;
       _descricaoOriginalCommited = Descricao;
       _emiteOpOriginalCommited = EmiteOp;
       _leadTimeFabricaOriginalCommited = LeadTimeFabrica;
       _regraDimensaoOriginalCommited = RegraDimensao;
       _calculoPrecoOriginalCommited = CalculoPreco;
       _loteEconomicoOriginalCommited = LoteEconomico;
       _motivoRevisaoOriginalCommited = MotivoRevisao;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _dataRevisaoCadastroOriginalCommited = DataRevisaoCadastro;
       _tipoAquisicaoOriginalCommited = TipoAquisicao;
       _politicaEstoqueOriginalCommited = PoliticaEstoque;
       _classificacaoProdutoOriginalCommited = ClassificacaoProduto;
       _classificacaoProduto2OriginalCommited = ClassificacaoProduto2;
       _qtdEtiquetaExpedicaoVolumeOriginalCommited = QtdEtiquetaExpedicaoVolume;
       _embalagemOriginalCommited = Embalagem;
       _descricaoInglesOriginalCommited = DescricaoIngles;
       _descricaoEspanholOriginalCommited = DescricaoEspanhol;
       _pesoUnitarioOriginalCommited = PesoUnitario;
       _familiaClienteOriginalCommited = FamiliaCliente;
       _cadastroPcpOriginalCommited = CadastroPcp;
       _cadastroEngenhariaOriginalCommited = CadastroEngenharia;
       _acabamentoOriginalCommited = Acabamento;
       _variavel1OriginalCommited = Variavel1;
       _variavel2OriginalCommited = Variavel2;
       _variavel3OriginalCommited = Variavel3;
       _variavel4OriginalCommited = Variavel4;
       _clienteOriginalCommited = Cliente;
       _unidadeMedidaOriginalCommited = UnidadeMedida;
       _utilizaDimensaoMaiorFilhoOriginalCommited = UtilizaDimensaoMaiorFilho;
       _localFabricacaoOriginalCommited = LocalFabricacao;
       _agrupadorOpOriginalCommited = AgrupadorOp;
       _aplicacaoClienteOriginalCommited = AplicacaoCliente;
       _tempoLimiteOriginalCommited = TempoLimite;
       _cadastroPrecoOriginalCommited = CadastroPreco;
       _etiquetaInternaOriginalCommited = EtiquetaInterna;
       _temporarioOriginalCommited = Temporario;
       _vermelhoOriginalCommited = Vermelho;
       _verdeOriginalCommited = Verde;
       _amareloOriginalCommited = Amarelo;
       _lotePadraoCompraOriginalCommited = LotePadraoCompra;
       _unidadeMedidaCompraOriginalCommited = UnidadeMedidaCompra;
       _unidadesPorUnCompraOriginalCommited = UnidadesPorUnCompra;
       _leadTimeCompraOriginalCommited = LeadTimeCompra;
       _marcasHomologadasOriginalCommited = MarcasHomologadas;
       _impedirSolicitacaoAutoOriginalCommited = ImpedirSolicitacaoAuto;
       _versaoEstruturaAtualOriginalCommited = VersaoEstruturaAtual;
       _rastreamentoMaterialOriginalCommited = RastreamentoMaterial;
       _regraValidVar1OriginalCommited = RegraValidVar1;
       _regraValidVar2OriginalCommited = RegraValidVar2;
       _regraValidVar3OriginalCommited = RegraValidVar3;
       _regraValidVar4OriginalCommited = RegraValidVar4;
       _estruturaEmRevisaoOriginalCommited = EstruturaEmRevisao;
       _utilizandoEstoqueSegurancaOriginalCommited = UtilizandoEstoqueSeguranca;
       _utilizandoEstoqueSegurancaDataOriginalCommited = UtilizandoEstoqueSegurancaData;
       _versionOriginalCommited = Version;
       _responsavelFreteOriginalCommited = ResponsavelFrete;
       _compradorOriginalCommited = Comprador;
       _permiteVendaOriginalCommited = PermiteVenda;
       _descricaoAdicionalOriginalCommited = DescricaoAdicional;
       _imprimirEstruturaOpOriginalCommited = ImprimirEstruturaOp;
       _imprimeOpsRelacionadasOriginalCommited = ImprimeOpsRelacionadas;
       _margemRecebimentoOriginalCommited = MargemRecebimento;
       _emitePlanoCorteOriginalCommited = EmitePlanoCorte;
       _validacaoPesoExpedicaoOriginalCommited = ValidacaoPesoExpedicao;
       _gtinOriginalCommited = Gtin;
       _ativoOriginalCommited = Ativo;
       _estruturaEmRevisaoObservacaoOriginalCommited = EstruturaEmRevisaoObservacao;
       _modeloEtiquetaExpedicaoOriginalCommited = ModeloEtiquetaExpedicao;
       _loteMinimoOriginalCommited = LoteMinimo;
       _bloqueioPrecoVencidoOriginalCommited = BloqueioPrecoVencido;

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
               if (FiguraLoaded)
               {
                  if(this._valueFigura != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _figuraOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueFigura));
                     }
                  } 
                  else 
                  { 
                        _figuraOriginal = null ;
                  } 
               }
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
               if (_valueCollectionContratoFornecimentoClassProdutoLoaded) 
               {
                  if (_collectionContratoFornecimentoClassProdutoRemovidos != null) 
                  {
                     _collectionContratoFornecimentoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContratoFornecimentoClassProdutoRemovidos = new List<Entidades.ContratoFornecimentoClass>();
                  }
                  _collectionContratoFornecimentoClassProdutoOriginal= (from a in _valueCollectionContratoFornecimentoClassProduto select a.ID).ToList();
                  _valueCollectionContratoFornecimentoClassProdutoChanged = false;
                  _valueCollectionContratoFornecimentoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoLoaded) 
               {
                  if (_collectionEstoqueGavetaItemClassProdutoRemovidos != null) 
                  {
                     _collectionEstoqueGavetaItemClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueGavetaItemClassProdutoRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                  }
                  _collectionEstoqueGavetaItemClassProdutoOriginal= (from a in _valueCollectionEstoqueGavetaItemClassProduto select a.ID).ToList();
                  _valueCollectionEstoqueGavetaItemClassProdutoChanged = false;
                  _valueCollectionEstoqueGavetaItemClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded) 
               {
                  if (_collectionFomularioRetiradaManualEstoqueClassProdutoRemovidos != null) 
                  {
                     _collectionFomularioRetiradaManualEstoqueClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFomularioRetiradaManualEstoqueClassProdutoRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                  }
                  _collectionFomularioRetiradaManualEstoqueClassProdutoOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassProduto select a.ID).ToList();
                  _valueCollectionFomularioRetiradaManualEstoqueClassProdutoChanged = false;
                  _valueCollectionFomularioRetiradaManualEstoqueClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraProdutoClassProdutoLoaded) 
               {
                  if (_collectionHistoricoCompraProdutoClassProdutoRemovidos != null) 
                  {
                     _collectionHistoricoCompraProdutoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraProdutoClassProdutoRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                  }
                  _collectionHistoricoCompraProdutoClassProdutoOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassProduto select a.ID).ToList();
                  _valueCollectionHistoricoCompraProdutoClassProdutoChanged = false;
                  _valueCollectionHistoricoCompraProdutoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoLoaded) 
               {
                  if (_collectionKanbanAcionamentoClassProdutoRemovidos != null) 
                  {
                     _collectionKanbanAcionamentoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionKanbanAcionamentoClassProdutoRemovidos = new List<Entidades.KanbanAcionamentoClass>();
                  }
                  _collectionKanbanAcionamentoClassProdutoOriginal= (from a in _valueCollectionKanbanAcionamentoClassProduto select a.ID).ToList();
                  _valueCollectionKanbanAcionamentoClassProdutoChanged = false;
                  _valueCollectionKanbanAcionamentoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionLoteClassProdutoLoaded) 
               {
                  if (_collectionLoteClassProdutoRemovidos != null) 
                  {
                     _collectionLoteClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLoteClassProdutoRemovidos = new List<Entidades.LoteClass>();
                  }
                  _collectionLoteClassProdutoOriginal= (from a in _valueCollectionLoteClassProduto select a.ID).ToList();
                  _valueCollectionLoteClassProdutoChanged = false;
                  _valueCollectionLoteClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoCompraItemClassProdutoLoaded) 
               {
                  if (_collectionOrcamentoCompraItemClassProdutoRemovidos != null) 
                  {
                     _collectionOrcamentoCompraItemClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoCompraItemClassProdutoRemovidos = new List<Entidades.OrcamentoCompraItemClass>();
                  }
                  _collectionOrcamentoCompraItemClassProdutoOriginal= (from a in _valueCollectionOrcamentoCompraItemClassProduto select a.ID).ToList();
                  _valueCollectionOrcamentoCompraItemClassProdutoChanged = false;
                  _valueCollectionOrcamentoCompraItemClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoLoaded) 
               {
                  if (_collectionOrcamentoConfiguradoClassProdutoRemovidos != null) 
                  {
                     _collectionOrcamentoConfiguradoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoConfiguradoClassProdutoRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                  }
                  _collectionOrcamentoConfiguradoClassProdutoOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassProduto select a.ID).ToList();
                  _valueCollectionOrcamentoConfiguradoClassProdutoChanged = false;
                  _valueCollectionOrcamentoConfiguradoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemClassProdutoLoaded) 
               {
                  if (_collectionOrcamentoItemClassProdutoRemovidos != null) 
                  {
                     _collectionOrcamentoItemClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemClassProdutoRemovidos = new List<Entidades.OrcamentoItemClass>();
                  }
                  _collectionOrcamentoItemClassProdutoOriginal= (from a in _valueCollectionOrcamentoItemClassProduto select a.ID).ToList();
                  _valueCollectionOrcamentoItemClassProdutoChanged = false;
                  _valueCollectionOrcamentoItemClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoClassProdutoLoaded) 
               {
                  if (_collectionOrdemProducaoClassProdutoRemovidos != null) 
                  {
                     _collectionOrdemProducaoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoClassProdutoRemovidos = new List<Entidades.OrdemProducaoClass>();
                  }
                  _collectionOrdemProducaoClassProdutoOriginal= (from a in _valueCollectionOrdemProducaoClassProduto select a.ID).ToList();
                  _valueCollectionOrdemProducaoClassProdutoChanged = false;
                  _valueCollectionOrdemProducaoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded) 
               {
                  if (_collectionOrdemProducaoProdutoComponenteClassProdutoRemovidos != null) 
                  {
                     _collectionOrdemProducaoProdutoComponenteClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoProdutoComponenteClassProdutoRemovidos = new List<Entidades.OrdemProducaoProdutoComponenteClass>();
                  }
                  _collectionOrdemProducaoProdutoComponenteClassProdutoOriginal= (from a in _valueCollectionOrdemProducaoProdutoComponenteClassProduto select a.ID).ToList();
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoChanged = false;
                  _valueCollectionOrdemProducaoProdutoComponenteClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoLoaded) 
               {
                  if (_collectionOrderItemEtiquetaClassProdutoRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaClassProdutoRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                  }
                  _collectionOrderItemEtiquetaClassProdutoOriginal= (from a in _valueCollectionOrderItemEtiquetaClassProduto select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaClassProdutoChanged = false;
                  _valueCollectionOrderItemEtiquetaClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassProdutoLoaded) 
               {
                  if (_collectionPedidoItemClassProdutoRemovidos != null) 
                  {
                     _collectionPedidoItemClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassProdutoRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassProdutoOriginal= (from a in _valueCollectionPedidoItemClassProduto select a.ID).ToList();
                  _valueCollectionPedidoItemClassProdutoChanged = false;
                  _valueCollectionPedidoItemClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoAcabamentoClassProdutoLoaded) 
               {
                  if (_collectionProdutoAcabamentoClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoAcabamentoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoAcabamentoClassProdutoRemovidos = new List<Entidades.ProdutoAcabamentoClass>();
                  }
                  _collectionProdutoAcabamentoClassProdutoOriginal= (from a in _valueCollectionProdutoAcabamentoClassProduto select a.ID).ToList();
                  _valueCollectionProdutoAcabamentoClassProdutoChanged = false;
                  _valueCollectionProdutoAcabamentoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded) 
               {
                  if (_collectionProdutoBloqueioQualidadeClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoBloqueioQualidadeClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoBloqueioQualidadeClassProdutoRemovidos = new List<Entidades.ProdutoBloqueioQualidadeClass>();
                  }
                  _collectionProdutoBloqueioQualidadeClassProdutoOriginal= (from a in _valueCollectionProdutoBloqueioQualidadeClassProduto select a.ID).ToList();
                  _valueCollectionProdutoBloqueioQualidadeClassProdutoChanged = false;
                  _valueCollectionProdutoBloqueioQualidadeClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoDocumentoTipoClassProdutoLoaded) 
               {
                  if (_collectionProdutoDocumentoTipoClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoDocumentoTipoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoDocumentoTipoClassProdutoRemovidos = new List<Entidades.ProdutoDocumentoTipoClass>();
                  }
                  _collectionProdutoDocumentoTipoClassProdutoOriginal= (from a in _valueCollectionProdutoDocumentoTipoClassProduto select a.ID).ToList();
                  _valueCollectionProdutoDocumentoTipoClassProdutoChanged = false;
                  _valueCollectionProdutoDocumentoTipoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded) 
               {
                  if (_collectionProdutoEstruturaInconsistenciaClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoEstruturaInconsistenciaClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoEstruturaInconsistenciaClassProdutoRemovidos = new List<Entidades.ProdutoEstruturaInconsistenciaClass>();
                  }
                  _collectionProdutoEstruturaInconsistenciaClassProdutoOriginal= (from a in _valueCollectionProdutoEstruturaInconsistenciaClassProduto select a.ID).ToList();
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoChanged = false;
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoEstruturaLockClassProdutoLoaded) 
               {
                  if (_collectionProdutoEstruturaLockClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoEstruturaLockClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoEstruturaLockClassProdutoRemovidos = new List<Entidades.ProdutoEstruturaLockClass>();
                  }
                  _collectionProdutoEstruturaLockClassProdutoOriginal= (from a in _valueCollectionProdutoEstruturaLockClassProduto select a.ID).ToList();
                  _valueCollectionProdutoEstruturaLockClassProdutoChanged = false;
                  _valueCollectionProdutoEstruturaLockClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoFiscalClassProdutoLoaded) 
               {
                  if (_collectionProdutoFiscalClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoFiscalClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoFiscalClassProdutoRemovidos = new List<Entidades.ProdutoFiscalClass>();
                  }
                  _collectionProdutoFiscalClassProdutoOriginal= (from a in _valueCollectionProdutoFiscalClassProduto select a.ID).ToList();
                  _valueCollectionProdutoFiscalClassProdutoChanged = false;
                  _valueCollectionProdutoFiscalClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoFornecedorClassProdutoLoaded) 
               {
                  if (_collectionProdutoFornecedorClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoFornecedorClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoFornecedorClassProdutoRemovidos = new List<Entidades.ProdutoFornecedorClass>();
                  }
                  _collectionProdutoFornecedorClassProdutoOriginal= (from a in _valueCollectionProdutoFornecedorClassProduto select a.ID).ToList();
                  _valueCollectionProdutoFornecedorClassProdutoChanged = false;
                  _valueCollectionProdutoFornecedorClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoKProdutoClassProdutoLoaded) 
               {
                  if (_collectionProdutoKProdutoClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoKProdutoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoKProdutoClassProdutoRemovidos = new List<Entidades.ProdutoKProdutoClass>();
                  }
                  _collectionProdutoKProdutoClassProdutoOriginal= (from a in _valueCollectionProdutoKProdutoClassProduto select a.ID).ToList();
                  _valueCollectionProdutoKProdutoClassProdutoChanged = false;
                  _valueCollectionProdutoKProdutoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoMaterialClassProdutoLoaded) 
               {
                  if (_collectionProdutoMaterialClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoMaterialClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoMaterialClassProdutoRemovidos = new List<Entidades.ProdutoMaterialClass>();
                  }
                  _collectionProdutoMaterialClassProdutoOriginal= (from a in _valueCollectionProdutoMaterialClassProduto select a.ID).ToList();
                  _valueCollectionProdutoMaterialClassProdutoChanged = false;
                  _valueCollectionProdutoMaterialClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded) 
               {
                  if (_collectionProdutoPaiFilhoClassProdutoPaiRemovidos != null) 
                  {
                     _collectionProdutoPaiFilhoClassProdutoPaiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoPaiFilhoClassProdutoPaiRemovidos = new List<Entidades.ProdutoPaiFilhoClass>();
                  }
                  _collectionProdutoPaiFilhoClassProdutoPaiOriginal= (from a in _valueCollectionProdutoPaiFilhoClassProdutoPai select a.ID).ToList();
                  _valueCollectionProdutoPaiFilhoClassProdutoPaiChanged = false;
                  _valueCollectionProdutoPaiFilhoClassProdutoPaiCommitedChanged = false;
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded) 
               {
                  if (_collectionProdutoPaiFilhoClassProdutoFilhoRemovidos != null) 
                  {
                     _collectionProdutoPaiFilhoClassProdutoFilhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoPaiFilhoClassProdutoFilhoRemovidos = new List<Entidades.ProdutoPaiFilhoClass>();
                  }
                  _collectionProdutoPaiFilhoClassProdutoFilhoOriginal= (from a in _valueCollectionProdutoPaiFilhoClassProdutoFilho select a.ID).ToList();
                  _valueCollectionProdutoPaiFilhoClassProdutoFilhoChanged = false;
                  _valueCollectionProdutoPaiFilhoClassProdutoFilhoCommitedChanged = false;
               }
               if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded) 
               {
                  if (_collectionProdutoPermissaoVendaPeriodosClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoPermissaoVendaPeriodosClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoPermissaoVendaPeriodosClassProdutoRemovidos = new List<Entidades.ProdutoPermissaoVendaPeriodosClass>();
                  }
                  _collectionProdutoPermissaoVendaPeriodosClassProdutoOriginal= (from a in _valueCollectionProdutoPermissaoVendaPeriodosClassProduto select a.ID).ToList();
                  _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoChanged = false;
                  _valueCollectionProdutoPermissaoVendaPeriodosClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoPostoTrabalhoClassProdutoLoaded) 
               {
                  if (_collectionProdutoPostoTrabalhoClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoPostoTrabalhoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoPostoTrabalhoClassProdutoRemovidos = new List<Entidades.ProdutoPostoTrabalhoClass>();
                  }
                  _collectionProdutoPostoTrabalhoClassProdutoOriginal= (from a in _valueCollectionProdutoPostoTrabalhoClassProduto select a.ID).ToList();
                  _valueCollectionProdutoPostoTrabalhoClassProdutoChanged = false;
                  _valueCollectionProdutoPostoTrabalhoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoPrecoClassProdutoLoaded) 
               {
                  if (_collectionProdutoPrecoClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoPrecoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoPrecoClassProdutoRemovidos = new List<Entidades.ProdutoPrecoClass>();
                  }
                  _collectionProdutoPrecoClassProdutoOriginal= (from a in _valueCollectionProdutoPrecoClassProduto select a.ID).ToList();
                  _valueCollectionProdutoPrecoClassProdutoChanged = false;
                  _valueCollectionProdutoPrecoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoRecursoClassProdutoLoaded) 
               {
                  if (_collectionProdutoRecursoClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoRecursoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoRecursoClassProdutoRemovidos = new List<Entidades.ProdutoRecursoClass>();
                  }
                  _collectionProdutoRecursoClassProdutoOriginal= (from a in _valueCollectionProdutoRecursoClassProduto select a.ID).ToList();
                  _valueCollectionProdutoRecursoClassProdutoChanged = false;
                  _valueCollectionProdutoRecursoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoRevisaoClassProdutoLoaded) 
               {
                  if (_collectionProdutoRevisaoClassProdutoRemovidos != null) 
                  {
                     _collectionProdutoRevisaoClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoRevisaoClassProdutoRemovidos = new List<Entidades.ProdutoRevisaoClass>();
                  }
                  _collectionProdutoRevisaoClassProdutoOriginal= (from a in _valueCollectionProdutoRevisaoClassProduto select a.ID).ToList();
                  _valueCollectionProdutoRevisaoClassProdutoChanged = false;
                  _valueCollectionProdutoRevisaoClassProdutoCommitedChanged = false;
               }
               if (_valueCollectionSolicitacaoCompraClassProdutoLoaded) 
               {
                  if (_collectionSolicitacaoCompraClassProdutoRemovidos != null) 
                  {
                     _collectionSolicitacaoCompraClassProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionSolicitacaoCompraClassProdutoRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                  }
                  _collectionSolicitacaoCompraClassProdutoOriginal= (from a in _valueCollectionSolicitacaoCompraClassProduto select a.ID).ToList();
                  _valueCollectionSolicitacaoCompraClassProdutoChanged = false;
                  _valueCollectionSolicitacaoCompraClassProdutoCommitedChanged = false;
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
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               CodigoCliente=_codigoClienteOriginal;
               _codigoClienteOriginalCommited=_codigoClienteOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               EmiteOp=_emiteOpOriginal;
               _emiteOpOriginalCommited=_emiteOpOriginal;
               LeadTimeFabrica=_leadTimeFabricaOriginal;
               _leadTimeFabricaOriginalCommited=_leadTimeFabricaOriginal;
               RegraDimensao=_regraDimensaoOriginal;
               _regraDimensaoOriginalCommited=_regraDimensaoOriginal;
               FiguraLoaded = false;
               this._figuraOriginal = null;
               this._figuraOriginalCommited = null;
               this._valueFigura = null;
               CalculoPreco=_calculoPrecoOriginal;
               _calculoPrecoOriginalCommited=_calculoPrecoOriginal;
               LoteEconomico=_loteEconomicoOriginal;
               _loteEconomicoOriginalCommited=_loteEconomicoOriginal;
               MotivoRevisao=_motivoRevisaoOriginal;
               _motivoRevisaoOriginalCommited=_motivoRevisaoOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               DataRevisaoCadastro=_dataRevisaoCadastroOriginal;
               _dataRevisaoCadastroOriginalCommited=_dataRevisaoCadastroOriginal;
               TipoAquisicao=_tipoAquisicaoOriginal;
               _tipoAquisicaoOriginalCommited=_tipoAquisicaoOriginal;
               PoliticaEstoque=_politicaEstoqueOriginal;
               _politicaEstoqueOriginalCommited=_politicaEstoqueOriginal;
               ClassificacaoProduto=_classificacaoProdutoOriginal;
               _classificacaoProdutoOriginalCommited=_classificacaoProdutoOriginal;
               ClassificacaoProduto2=_classificacaoProduto2Original;
               _classificacaoProduto2OriginalCommited=_classificacaoProduto2Original;
               QtdEtiquetaExpedicaoVolume=_qtdEtiquetaExpedicaoVolumeOriginal;
               _qtdEtiquetaExpedicaoVolumeOriginalCommited=_qtdEtiquetaExpedicaoVolumeOriginal;
               Embalagem=_embalagemOriginal;
               _embalagemOriginalCommited=_embalagemOriginal;
               DescricaoIngles=_descricaoInglesOriginal;
               _descricaoInglesOriginalCommited=_descricaoInglesOriginal;
               DescricaoEspanhol=_descricaoEspanholOriginal;
               _descricaoEspanholOriginalCommited=_descricaoEspanholOriginal;
               PesoUnitario=_pesoUnitarioOriginal;
               _pesoUnitarioOriginalCommited=_pesoUnitarioOriginal;
               FamiliaCliente=_familiaClienteOriginal;
               _familiaClienteOriginalCommited=_familiaClienteOriginal;
               CadastroPcp=_cadastroPcpOriginal;
               _cadastroPcpOriginalCommited=_cadastroPcpOriginal;
               CadastroEngenharia=_cadastroEngenhariaOriginal;
               _cadastroEngenhariaOriginalCommited=_cadastroEngenhariaOriginal;
               Acabamento=_acabamentoOriginal;
               _acabamentoOriginalCommited=_acabamentoOriginal;
               Variavel1=_variavel1Original;
               _variavel1OriginalCommited=_variavel1Original;
               Variavel2=_variavel2Original;
               _variavel2OriginalCommited=_variavel2Original;
               Variavel3=_variavel3Original;
               _variavel3OriginalCommited=_variavel3Original;
               Variavel4=_variavel4Original;
               _variavel4OriginalCommited=_variavel4Original;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               UnidadeMedida=_unidadeMedidaOriginal;
               _unidadeMedidaOriginalCommited=_unidadeMedidaOriginal;
               UtilizaDimensaoMaiorFilho=_utilizaDimensaoMaiorFilhoOriginal;
               _utilizaDimensaoMaiorFilhoOriginalCommited=_utilizaDimensaoMaiorFilhoOriginal;
               LocalFabricacao=_localFabricacaoOriginal;
               _localFabricacaoOriginalCommited=_localFabricacaoOriginal;
               AgrupadorOp=_agrupadorOpOriginal;
               _agrupadorOpOriginalCommited=_agrupadorOpOriginal;
               AplicacaoCliente=_aplicacaoClienteOriginal;
               _aplicacaoClienteOriginalCommited=_aplicacaoClienteOriginal;
               TempoLimite=_tempoLimiteOriginal;
               _tempoLimiteOriginalCommited=_tempoLimiteOriginal;
               CadastroPreco=_cadastroPrecoOriginal;
               _cadastroPrecoOriginalCommited=_cadastroPrecoOriginal;
               EtiquetaInterna=_etiquetaInternaOriginal;
               _etiquetaInternaOriginalCommited=_etiquetaInternaOriginal;
               Temporario=_temporarioOriginal;
               _temporarioOriginalCommited=_temporarioOriginal;
               Vermelho=_vermelhoOriginal;
               _vermelhoOriginalCommited=_vermelhoOriginal;
               Verde=_verdeOriginal;
               _verdeOriginalCommited=_verdeOriginal;
               Amarelo=_amareloOriginal;
               _amareloOriginalCommited=_amareloOriginal;
               LotePadraoCompra=_lotePadraoCompraOriginal;
               _lotePadraoCompraOriginalCommited=_lotePadraoCompraOriginal;
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
               VersaoEstruturaAtual=_versaoEstruturaAtualOriginal;
               _versaoEstruturaAtualOriginalCommited=_versaoEstruturaAtualOriginal;
               RastreamentoMaterial=_rastreamentoMaterialOriginal;
               _rastreamentoMaterialOriginalCommited=_rastreamentoMaterialOriginal;
               RegraValidVar1=_regraValidVar1Original;
               _regraValidVar1OriginalCommited=_regraValidVar1Original;
               RegraValidVar2=_regraValidVar2Original;
               _regraValidVar2OriginalCommited=_regraValidVar2Original;
               RegraValidVar3=_regraValidVar3Original;
               _regraValidVar3OriginalCommited=_regraValidVar3Original;
               RegraValidVar4=_regraValidVar4Original;
               _regraValidVar4OriginalCommited=_regraValidVar4Original;
               EstruturaEmRevisao=_estruturaEmRevisaoOriginal;
               _estruturaEmRevisaoOriginalCommited=_estruturaEmRevisaoOriginal;
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
               ResponsavelFrete=_responsavelFreteOriginal;
               _responsavelFreteOriginalCommited=_responsavelFreteOriginal;
               Comprador=_compradorOriginal;
               _compradorOriginalCommited=_compradorOriginal;
               PermiteVenda=_permiteVendaOriginal;
               _permiteVendaOriginalCommited=_permiteVendaOriginal;
               DescricaoAdicional=_descricaoAdicionalOriginal;
               _descricaoAdicionalOriginalCommited=_descricaoAdicionalOriginal;
               ImprimirEstruturaOp=_imprimirEstruturaOpOriginal;
               _imprimirEstruturaOpOriginalCommited=_imprimirEstruturaOpOriginal;
               ImprimeOpsRelacionadas=_imprimeOpsRelacionadasOriginal;
               _imprimeOpsRelacionadasOriginalCommited=_imprimeOpsRelacionadasOriginal;
               MargemRecebimento=_margemRecebimentoOriginal;
               _margemRecebimentoOriginalCommited=_margemRecebimentoOriginal;
               EmitePlanoCorte=_emitePlanoCorteOriginal;
               _emitePlanoCorteOriginalCommited=_emitePlanoCorteOriginal;
               ValidacaoPesoExpedicao=_validacaoPesoExpedicaoOriginal;
               _validacaoPesoExpedicaoOriginalCommited=_validacaoPesoExpedicaoOriginal;
               Gtin=_gtinOriginal;
               _gtinOriginalCommited=_gtinOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               EstruturaEmRevisaoObservacao=_estruturaEmRevisaoObservacaoOriginal;
               _estruturaEmRevisaoObservacaoOriginalCommited=_estruturaEmRevisaoObservacaoOriginal;
               ModeloEtiquetaExpedicao=_modeloEtiquetaExpedicaoOriginal;
               _modeloEtiquetaExpedicaoOriginalCommited=_modeloEtiquetaExpedicaoOriginal;
               LoteMinimo=_loteMinimoOriginal;
               _loteMinimoOriginalCommited=_loteMinimoOriginal;
               BloqueioPrecoVencido=_bloqueioPrecoVencidoOriginal;
               _bloqueioPrecoVencidoOriginalCommited=_bloqueioPrecoVencidoOriginal;
               if (_valueCollectionContratoFornecimentoClassProdutoLoaded) 
               {
                  CollectionContratoFornecimentoClassProduto.Clear();
                  foreach(int item in _collectionContratoFornecimentoClassProdutoOriginal)
                  {
                    CollectionContratoFornecimentoClassProduto.Add(Entidades.ContratoFornecimentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContratoFornecimentoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoLoaded) 
               {
                  CollectionEstoqueGavetaItemClassProduto.Clear();
                  foreach(int item in _collectionEstoqueGavetaItemClassProdutoOriginal)
                  {
                    CollectionEstoqueGavetaItemClassProduto.Add(Entidades.EstoqueGavetaItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueGavetaItemClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded) 
               {
                  CollectionFomularioRetiradaManualEstoqueClassProduto.Clear();
                  foreach(int item in _collectionFomularioRetiradaManualEstoqueClassProdutoOriginal)
                  {
                    CollectionFomularioRetiradaManualEstoqueClassProduto.Add(Entidades.FomularioRetiradaManualEstoqueClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFomularioRetiradaManualEstoqueClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraProdutoClassProdutoLoaded) 
               {
                  CollectionHistoricoCompraProdutoClassProduto.Clear();
                  foreach(int item in _collectionHistoricoCompraProdutoClassProdutoOriginal)
                  {
                    CollectionHistoricoCompraProdutoClassProduto.Add(Entidades.HistoricoCompraProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraProdutoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoLoaded) 
               {
                  CollectionKanbanAcionamentoClassProduto.Clear();
                  foreach(int item in _collectionKanbanAcionamentoClassProdutoOriginal)
                  {
                    CollectionKanbanAcionamentoClassProduto.Add(Entidades.KanbanAcionamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionKanbanAcionamentoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionLoteClassProdutoLoaded) 
               {
                  CollectionLoteClassProduto.Clear();
                  foreach(int item in _collectionLoteClassProdutoOriginal)
                  {
                    CollectionLoteClassProduto.Add(Entidades.LoteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLoteClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoCompraItemClassProdutoLoaded) 
               {
                  CollectionOrcamentoCompraItemClassProduto.Clear();
                  foreach(int item in _collectionOrcamentoCompraItemClassProdutoOriginal)
                  {
                    CollectionOrcamentoCompraItemClassProduto.Add(Entidades.OrcamentoCompraItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoCompraItemClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoLoaded) 
               {
                  CollectionOrcamentoConfiguradoClassProduto.Clear();
                  foreach(int item in _collectionOrcamentoConfiguradoClassProdutoOriginal)
                  {
                    CollectionOrcamentoConfiguradoClassProduto.Add(Entidades.OrcamentoConfiguradoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoConfiguradoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemClassProdutoLoaded) 
               {
                  CollectionOrcamentoItemClassProduto.Clear();
                  foreach(int item in _collectionOrcamentoItemClassProdutoOriginal)
                  {
                    CollectionOrcamentoItemClassProduto.Add(Entidades.OrcamentoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoClassProdutoLoaded) 
               {
                  CollectionOrdemProducaoClassProduto.Clear();
                  foreach(int item in _collectionOrdemProducaoClassProdutoOriginal)
                  {
                    CollectionOrdemProducaoClassProduto.Add(Entidades.OrdemProducaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded) 
               {
                  CollectionOrdemProducaoProdutoComponenteClassProduto.Clear();
                  foreach(int item in _collectionOrdemProducaoProdutoComponenteClassProdutoOriginal)
                  {
                    CollectionOrdemProducaoProdutoComponenteClassProduto.Add(Entidades.OrdemProducaoProdutoComponenteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoProdutoComponenteClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoLoaded) 
               {
                  CollectionOrderItemEtiquetaClassProduto.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaClassProdutoOriginal)
                  {
                    CollectionOrderItemEtiquetaClassProduto.Add(Entidades.OrderItemEtiquetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassProdutoLoaded) 
               {
                  CollectionPedidoItemClassProduto.Clear();
                  foreach(int item in _collectionPedidoItemClassProdutoOriginal)
                  {
                    CollectionPedidoItemClassProduto.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoAcabamentoClassProdutoLoaded) 
               {
                  CollectionProdutoAcabamentoClassProduto.Clear();
                  foreach(int item in _collectionProdutoAcabamentoClassProdutoOriginal)
                  {
                    CollectionProdutoAcabamentoClassProduto.Add(Entidades.ProdutoAcabamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoAcabamentoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded) 
               {
                  CollectionProdutoBloqueioQualidadeClassProduto.Clear();
                  foreach(int item in _collectionProdutoBloqueioQualidadeClassProdutoOriginal)
                  {
                    CollectionProdutoBloqueioQualidadeClassProduto.Add(Entidades.ProdutoBloqueioQualidadeClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoBloqueioQualidadeClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoDocumentoTipoClassProdutoLoaded) 
               {
                  CollectionProdutoDocumentoTipoClassProduto.Clear();
                  foreach(int item in _collectionProdutoDocumentoTipoClassProdutoOriginal)
                  {
                    CollectionProdutoDocumentoTipoClassProduto.Add(Entidades.ProdutoDocumentoTipoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoDocumentoTipoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded) 
               {
                  CollectionProdutoEstruturaInconsistenciaClassProduto.Clear();
                  foreach(int item in _collectionProdutoEstruturaInconsistenciaClassProdutoOriginal)
                  {
                    CollectionProdutoEstruturaInconsistenciaClassProduto.Add(Entidades.ProdutoEstruturaInconsistenciaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoEstruturaInconsistenciaClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoEstruturaLockClassProdutoLoaded) 
               {
                  CollectionProdutoEstruturaLockClassProduto.Clear();
                  foreach(int item in _collectionProdutoEstruturaLockClassProdutoOriginal)
                  {
                    CollectionProdutoEstruturaLockClassProduto.Add(Entidades.ProdutoEstruturaLockClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoEstruturaLockClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoFiscalClassProdutoLoaded) 
               {
                  CollectionProdutoFiscalClassProduto.Clear();
                  foreach(int item in _collectionProdutoFiscalClassProdutoOriginal)
                  {
                    CollectionProdutoFiscalClassProduto.Add(Entidades.ProdutoFiscalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoFiscalClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoFornecedorClassProdutoLoaded) 
               {
                  CollectionProdutoFornecedorClassProduto.Clear();
                  foreach(int item in _collectionProdutoFornecedorClassProdutoOriginal)
                  {
                    CollectionProdutoFornecedorClassProduto.Add(Entidades.ProdutoFornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoFornecedorClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoKProdutoClassProdutoLoaded) 
               {
                  CollectionProdutoKProdutoClassProduto.Clear();
                  foreach(int item in _collectionProdutoKProdutoClassProdutoOriginal)
                  {
                    CollectionProdutoKProdutoClassProduto.Add(Entidades.ProdutoKProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoKProdutoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoMaterialClassProdutoLoaded) 
               {
                  CollectionProdutoMaterialClassProduto.Clear();
                  foreach(int item in _collectionProdutoMaterialClassProdutoOriginal)
                  {
                    CollectionProdutoMaterialClassProduto.Add(Entidades.ProdutoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoMaterialClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded) 
               {
                  CollectionProdutoPaiFilhoClassProdutoPai.Clear();
                  foreach(int item in _collectionProdutoPaiFilhoClassProdutoPaiOriginal)
                  {
                    CollectionProdutoPaiFilhoClassProdutoPai.Add(Entidades.ProdutoPaiFilhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoPaiFilhoClassProdutoPaiRemovidos.Clear();
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded) 
               {
                  CollectionProdutoPaiFilhoClassProdutoFilho.Clear();
                  foreach(int item in _collectionProdutoPaiFilhoClassProdutoFilhoOriginal)
                  {
                    CollectionProdutoPaiFilhoClassProdutoFilho.Add(Entidades.ProdutoPaiFilhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoPaiFilhoClassProdutoFilhoRemovidos.Clear();
               }
               if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded) 
               {
                  CollectionProdutoPermissaoVendaPeriodosClassProduto.Clear();
                  foreach(int item in _collectionProdutoPermissaoVendaPeriodosClassProdutoOriginal)
                  {
                    CollectionProdutoPermissaoVendaPeriodosClassProduto.Add(Entidades.ProdutoPermissaoVendaPeriodosClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoPermissaoVendaPeriodosClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoPostoTrabalhoClassProdutoLoaded) 
               {
                  CollectionProdutoPostoTrabalhoClassProduto.Clear();
                  foreach(int item in _collectionProdutoPostoTrabalhoClassProdutoOriginal)
                  {
                    CollectionProdutoPostoTrabalhoClassProduto.Add(Entidades.ProdutoPostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoPostoTrabalhoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoPrecoClassProdutoLoaded) 
               {
                  CollectionProdutoPrecoClassProduto.Clear();
                  foreach(int item in _collectionProdutoPrecoClassProdutoOriginal)
                  {
                    CollectionProdutoPrecoClassProduto.Add(Entidades.ProdutoPrecoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoPrecoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoRecursoClassProdutoLoaded) 
               {
                  CollectionProdutoRecursoClassProduto.Clear();
                  foreach(int item in _collectionProdutoRecursoClassProdutoOriginal)
                  {
                    CollectionProdutoRecursoClassProduto.Add(Entidades.ProdutoRecursoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoRecursoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoRevisaoClassProdutoLoaded) 
               {
                  CollectionProdutoRevisaoClassProduto.Clear();
                  foreach(int item in _collectionProdutoRevisaoClassProdutoOriginal)
                  {
                    CollectionProdutoRevisaoClassProduto.Add(Entidades.ProdutoRevisaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoRevisaoClassProdutoRemovidos.Clear();
               }
               if (_valueCollectionSolicitacaoCompraClassProdutoLoaded) 
               {
                  CollectionSolicitacaoCompraClassProduto.Clear();
                  foreach(int item in _collectionSolicitacaoCompraClassProdutoOriginal)
                  {
                    CollectionSolicitacaoCompraClassProduto.Add(Entidades.SolicitacaoCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionSolicitacaoCompraClassProdutoRemovidos.Clear();
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
               if (_valueCollectionContratoFornecimentoClassProdutoLoaded) 
               {
                  if (_valueCollectionContratoFornecimentoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassProdutoLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoLoaded) 
               {
                  if (_valueCollectionKanbanAcionamentoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassProdutoLoaded) 
               {
                  if (_valueCollectionLoteClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassProdutoLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraItemClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassProdutoLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoClassProdutoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassProdutoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoAcabamentoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoAcabamentoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoBloqueioQualidadeClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoDocumentoTipoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoDocumentoTipoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoEstruturaLockClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoEstruturaLockClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFiscalClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoFiscalClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFornecedorClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoFornecedorClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoKProdutoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoKProdutoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoMaterialClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded) 
               {
                  if (_valueCollectionProdutoPaiFilhoClassProdutoPaiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded) 
               {
                  if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPostoTrabalhoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoPostoTrabalhoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPrecoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoPrecoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoRecursoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoRecursoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoRevisaoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoRevisaoClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassProdutoLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContratoFornecimentoClassProdutoLoaded) 
               {
                   tempRet = CollectionContratoFornecimentoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassProdutoLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoLoaded) 
               {
                   tempRet = CollectionKanbanAcionamentoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassProdutoLoaded) 
               {
                   tempRet = CollectionLoteClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoCompraItemClassProdutoLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraItemClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassProdutoLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoClassProdutoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoProdutoComponenteClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassProdutoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoAcabamentoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoAcabamentoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoBloqueioQualidadeClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoDocumentoTipoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoDocumentoTipoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoEstruturaInconsistenciaClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoEstruturaLockClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoEstruturaLockClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFiscalClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoFiscalClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFornecedorClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoFornecedorClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoKProdutoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoKProdutoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoMaterialClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded) 
               {
                   tempRet = CollectionProdutoPaiFilhoClassProdutoPai.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded) 
               {
                   tempRet = CollectionProdutoPaiFilhoClassProdutoFilho.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoPermissaoVendaPeriodosClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPostoTrabalhoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoPostoTrabalhoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPrecoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoPrecoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoRecursoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoRecursoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoRevisaoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoRevisaoClassProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassProdutoLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassProduto.Any(item => item.IsDirty());
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
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       dirty = _codigoClienteOriginal != CodigoCliente;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _emiteOpOriginal != EmiteOp;
      if (dirty) return true;
       dirty = _leadTimeFabricaOriginal != LeadTimeFabrica;
      if (dirty) return true;
       dirty = _regraDimensaoOriginal != RegraDimensao;
      if (dirty) return true;
               if (FiguraLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpFigura ;
                      if (this._valueFigura == null) 
                      { 
                         tmpFigura = null; 
                      } 
                      else 
                      { 
                         tmpFigura = Convert.ToBase64String(sha1.ComputeHash(this._valueFigura));
                      } 
                       dirty = _figuraOriginal != tmpFigura;
                   }
               }
      if (dirty) return true;
       dirty = _calculoPrecoOriginal != CalculoPreco;
      if (dirty) return true;
       dirty = _loteEconomicoOriginal != LoteEconomico;
      if (dirty) return true;
       dirty = _motivoRevisaoOriginal != MotivoRevisao;
      if (dirty) return true;
       if (_acsUsuarioOriginal!=null)
       {
          dirty = !_acsUsuarioOriginal.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataRevisaoCadastroOriginal != DataRevisaoCadastro;
      if (dirty) return true;
       dirty = _tipoAquisicaoOriginal != TipoAquisicao;
      if (dirty) return true;
       dirty = _politicaEstoqueOriginal != PoliticaEstoque;
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
       if (_classificacaoProduto2Original!=null)
       {
          dirty = !_classificacaoProduto2Original.Equals(ClassificacaoProduto2);
       }
       else
       {
            dirty = ClassificacaoProduto2 != null;
       }
      if (dirty) return true;
       dirty = _qtdEtiquetaExpedicaoVolumeOriginal != QtdEtiquetaExpedicaoVolume;
      if (dirty) return true;
       if (_embalagemOriginal!=null)
       {
          dirty = !_embalagemOriginal.Equals(Embalagem);
       }
       else
       {
            dirty = Embalagem != null;
       }
      if (dirty) return true;
       dirty = _descricaoInglesOriginal != DescricaoIngles;
      if (dirty) return true;
       dirty = _descricaoEspanholOriginal != DescricaoEspanhol;
      if (dirty) return true;
       dirty = _pesoUnitarioOriginal != PesoUnitario;
      if (dirty) return true;
       if (_familiaClienteOriginal!=null)
       {
          dirty = !_familiaClienteOriginal.Equals(FamiliaCliente);
       }
       else
       {
            dirty = FamiliaCliente != null;
       }
      if (dirty) return true;
       dirty = _cadastroPcpOriginal != CadastroPcp;
      if (dirty) return true;
       dirty = _cadastroEngenhariaOriginal != CadastroEngenharia;
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
       if (_variavel1Original!=null)
       {
          dirty = !_variavel1Original.Equals(Variavel1);
       }
       else
       {
            dirty = Variavel1 != null;
       }
      if (dirty) return true;
       if (_variavel2Original!=null)
       {
          dirty = !_variavel2Original.Equals(Variavel2);
       }
       else
       {
            dirty = Variavel2 != null;
       }
      if (dirty) return true;
       if (_variavel3Original!=null)
       {
          dirty = !_variavel3Original.Equals(Variavel3);
       }
       else
       {
            dirty = Variavel3 != null;
       }
      if (dirty) return true;
       if (_variavel4Original!=null)
       {
          dirty = !_variavel4Original.Equals(Variavel4);
       }
       else
       {
            dirty = Variavel4 != null;
       }
      if (dirty) return true;
       if (_clienteOriginal!=null)
       {
          dirty = !_clienteOriginal.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
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
       dirty = _utilizaDimensaoMaiorFilhoOriginal != UtilizaDimensaoMaiorFilho;
      if (dirty) return true;
       if (_localFabricacaoOriginal!=null)
       {
          dirty = !_localFabricacaoOriginal.Equals(LocalFabricacao);
       }
       else
       {
            dirty = LocalFabricacao != null;
       }
      if (dirty) return true;
       if (_agrupadorOpOriginal!=null)
       {
          dirty = !_agrupadorOpOriginal.Equals(AgrupadorOp);
       }
       else
       {
            dirty = AgrupadorOp != null;
       }
      if (dirty) return true;
       if (_aplicacaoClienteOriginal!=null)
       {
          dirty = !_aplicacaoClienteOriginal.Equals(AplicacaoCliente);
       }
       else
       {
            dirty = AplicacaoCliente != null;
       }
      if (dirty) return true;
       dirty = _tempoLimiteOriginal != TempoLimite;
      if (dirty) return true;
       dirty = _cadastroPrecoOriginal != CadastroPreco;
      if (dirty) return true;
       dirty = _etiquetaInternaOriginal != EtiquetaInterna;
      if (dirty) return true;
       dirty = _temporarioOriginal != Temporario;
      if (dirty) return true;
       dirty = _vermelhoOriginal != Vermelho;
      if (dirty) return true;
       dirty = _verdeOriginal != Verde;
      if (dirty) return true;
       dirty = _amareloOriginal != Amarelo;
      if (dirty) return true;
       dirty = _lotePadraoCompraOriginal != LotePadraoCompra;
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
       dirty = _versaoEstruturaAtualOriginal != VersaoEstruturaAtual;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginal != RastreamentoMaterial;
      if (dirty) return true;
       dirty = _regraValidVar1Original != RegraValidVar1;
      if (dirty) return true;
       dirty = _regraValidVar2Original != RegraValidVar2;
      if (dirty) return true;
       dirty = _regraValidVar3Original != RegraValidVar3;
      if (dirty) return true;
       dirty = _regraValidVar4Original != RegraValidVar4;
      if (dirty) return true;
       dirty = _estruturaEmRevisaoOriginal != EstruturaEmRevisao;
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
       dirty = _responsavelFreteOriginal != ResponsavelFrete;
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
       dirty = _permiteVendaOriginal != PermiteVenda;
      if (dirty) return true;
       dirty = _descricaoAdicionalOriginal != DescricaoAdicional;
      if (dirty) return true;
       dirty = _imprimirEstruturaOpOriginal != ImprimirEstruturaOp;
      if (dirty) return true;
       dirty = _imprimeOpsRelacionadasOriginal != ImprimeOpsRelacionadas;
      if (dirty) return true;
       dirty = _margemRecebimentoOriginal != MargemRecebimento;
      if (dirty) return true;
       dirty = _emitePlanoCorteOriginal != EmitePlanoCorte;
      if (dirty) return true;
       dirty = _validacaoPesoExpedicaoOriginal != ValidacaoPesoExpedicao;
      if (dirty) return true;
       dirty = _gtinOriginal != Gtin;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;
      if (dirty) return true;
       dirty = _estruturaEmRevisaoObservacaoOriginal != EstruturaEmRevisaoObservacao;
      if (dirty) return true;
       if (_modeloEtiquetaExpedicaoOriginal!=null)
       {
          dirty = !_modeloEtiquetaExpedicaoOriginal.Equals(ModeloEtiquetaExpedicao);
       }
       else
       {
            dirty = ModeloEtiquetaExpedicao != null;
       }
      if (dirty) return true;
       dirty = _loteMinimoOriginal != LoteMinimo;
      if (dirty) return true;
       dirty = _bloqueioPrecoVencidoOriginal != BloqueioPrecoVencido;

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
               if (_valueCollectionContratoFornecimentoClassProdutoLoaded) 
               {
                  if (_valueCollectionContratoFornecimentoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassProdutoLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoLoaded) 
               {
                  if (_valueCollectionKanbanAcionamentoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassProdutoLoaded) 
               {
                  if (_valueCollectionLoteClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassProdutoLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraItemClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassProdutoLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoClassProdutoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassProdutoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoAcabamentoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoAcabamentoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoBloqueioQualidadeClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoDocumentoTipoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoDocumentoTipoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoEstruturaLockClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoEstruturaLockClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFiscalClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoFiscalClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFornecedorClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoFornecedorClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoKProdutoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoKProdutoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoMaterialClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded) 
               {
                  if (_valueCollectionProdutoPaiFilhoClassProdutoPaiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded) 
               {
                  if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPostoTrabalhoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoPostoTrabalhoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPrecoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoPrecoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoRecursoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoRecursoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoRevisaoClassProdutoLoaded) 
               {
                  if (_valueCollectionProdutoRevisaoClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassProdutoLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContratoFornecimentoClassProdutoLoaded) 
               {
                   tempRet = CollectionContratoFornecimentoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassProdutoLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoLoaded) 
               {
                   tempRet = CollectionKanbanAcionamentoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassProdutoLoaded) 
               {
                   tempRet = CollectionLoteClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoCompraItemClassProdutoLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraItemClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassProdutoLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoClassProdutoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoProdutoComponenteClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassProdutoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoAcabamentoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoAcabamentoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoBloqueioQualidadeClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoDocumentoTipoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoDocumentoTipoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoEstruturaInconsistenciaClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoEstruturaLockClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoEstruturaLockClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFiscalClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoFiscalClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFornecedorClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoFornecedorClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoKProdutoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoKProdutoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoMaterialClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded) 
               {
                   tempRet = CollectionProdutoPaiFilhoClassProdutoPai.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded) 
               {
                   tempRet = CollectionProdutoPaiFilhoClassProdutoFilho.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoPermissaoVendaPeriodosClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPostoTrabalhoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoPostoTrabalhoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPrecoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoPrecoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoRecursoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoRecursoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoRevisaoClassProdutoLoaded) 
               {
                   tempRet = CollectionProdutoRevisaoClassProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassProdutoLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassProduto.Any(item => item.IsDirtyCommited());
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
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       dirty = _codigoClienteOriginalCommited != CodigoCliente;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _emiteOpOriginalCommited != EmiteOp;
      if (dirty) return true;
       dirty = _leadTimeFabricaOriginalCommited != LeadTimeFabrica;
      if (dirty) return true;
       dirty = _regraDimensaoOriginalCommited != RegraDimensao;
      if (dirty) return true;
               if (FiguraLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpFigura ;
                      if (this._valueFigura == null) 
                      { 
                         tmpFigura = null; 
                      } 
                      else 
                      { 
                         tmpFigura = Convert.ToBase64String(sha1.ComputeHash(this._valueFigura));
                      } 
                       dirty = _figuraOriginalCommited != tmpFigura;
                   }
               }
      if (dirty) return true;
       dirty = _calculoPrecoOriginalCommited != CalculoPreco;
      if (dirty) return true;
       dirty = _loteEconomicoOriginalCommited != LoteEconomico;
      if (dirty) return true;
       dirty = _motivoRevisaoOriginalCommited != MotivoRevisao;
      if (dirty) return true;
       if (_acsUsuarioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioOriginalCommited.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataRevisaoCadastroOriginalCommited != DataRevisaoCadastro;
      if (dirty) return true;
       dirty = _tipoAquisicaoOriginalCommited != TipoAquisicao;
      if (dirty) return true;
       dirty = _politicaEstoqueOriginalCommited != PoliticaEstoque;
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
       if (_classificacaoProduto2OriginalCommited!=null)
       {
          dirty = !_classificacaoProduto2OriginalCommited.Equals(ClassificacaoProduto2);
       }
       else
       {
            dirty = ClassificacaoProduto2 != null;
       }
      if (dirty) return true;
       dirty = _qtdEtiquetaExpedicaoVolumeOriginalCommited != QtdEtiquetaExpedicaoVolume;
      if (dirty) return true;
       if (_embalagemOriginalCommited!=null)
       {
          dirty = !_embalagemOriginalCommited.Equals(Embalagem);
       }
       else
       {
            dirty = Embalagem != null;
       }
      if (dirty) return true;
       dirty = _descricaoInglesOriginalCommited != DescricaoIngles;
      if (dirty) return true;
       dirty = _descricaoEspanholOriginalCommited != DescricaoEspanhol;
      if (dirty) return true;
       dirty = _pesoUnitarioOriginalCommited != PesoUnitario;
      if (dirty) return true;
       if (_familiaClienteOriginalCommited!=null)
       {
          dirty = !_familiaClienteOriginalCommited.Equals(FamiliaCliente);
       }
       else
       {
            dirty = FamiliaCliente != null;
       }
      if (dirty) return true;
       dirty = _cadastroPcpOriginalCommited != CadastroPcp;
      if (dirty) return true;
       dirty = _cadastroEngenhariaOriginalCommited != CadastroEngenharia;
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
       if (_variavel1OriginalCommited!=null)
       {
          dirty = !_variavel1OriginalCommited.Equals(Variavel1);
       }
       else
       {
            dirty = Variavel1 != null;
       }
      if (dirty) return true;
       if (_variavel2OriginalCommited!=null)
       {
          dirty = !_variavel2OriginalCommited.Equals(Variavel2);
       }
       else
       {
            dirty = Variavel2 != null;
       }
      if (dirty) return true;
       if (_variavel3OriginalCommited!=null)
       {
          dirty = !_variavel3OriginalCommited.Equals(Variavel3);
       }
       else
       {
            dirty = Variavel3 != null;
       }
      if (dirty) return true;
       if (_variavel4OriginalCommited!=null)
       {
          dirty = !_variavel4OriginalCommited.Equals(Variavel4);
       }
       else
       {
            dirty = Variavel4 != null;
       }
      if (dirty) return true;
       if (_clienteOriginalCommited!=null)
       {
          dirty = !_clienteOriginalCommited.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
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
       dirty = _utilizaDimensaoMaiorFilhoOriginalCommited != UtilizaDimensaoMaiorFilho;
      if (dirty) return true;
       if (_localFabricacaoOriginalCommited!=null)
       {
          dirty = !_localFabricacaoOriginalCommited.Equals(LocalFabricacao);
       }
       else
       {
            dirty = LocalFabricacao != null;
       }
      if (dirty) return true;
       if (_agrupadorOpOriginalCommited!=null)
       {
          dirty = !_agrupadorOpOriginalCommited.Equals(AgrupadorOp);
       }
       else
       {
            dirty = AgrupadorOp != null;
       }
      if (dirty) return true;
       if (_aplicacaoClienteOriginalCommited!=null)
       {
          dirty = !_aplicacaoClienteOriginalCommited.Equals(AplicacaoCliente);
       }
       else
       {
            dirty = AplicacaoCliente != null;
       }
      if (dirty) return true;
       dirty = _tempoLimiteOriginalCommited != TempoLimite;
      if (dirty) return true;
       dirty = _cadastroPrecoOriginalCommited != CadastroPreco;
      if (dirty) return true;
       dirty = _etiquetaInternaOriginalCommited != EtiquetaInterna;
      if (dirty) return true;
       dirty = _temporarioOriginalCommited != Temporario;
      if (dirty) return true;
       dirty = _vermelhoOriginalCommited != Vermelho;
      if (dirty) return true;
       dirty = _verdeOriginalCommited != Verde;
      if (dirty) return true;
       dirty = _amareloOriginalCommited != Amarelo;
      if (dirty) return true;
       dirty = _lotePadraoCompraOriginalCommited != LotePadraoCompra;
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
       dirty = _versaoEstruturaAtualOriginalCommited != VersaoEstruturaAtual;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginalCommited != RastreamentoMaterial;
      if (dirty) return true;
       dirty = _regraValidVar1OriginalCommited != RegraValidVar1;
      if (dirty) return true;
       dirty = _regraValidVar2OriginalCommited != RegraValidVar2;
      if (dirty) return true;
       dirty = _regraValidVar3OriginalCommited != RegraValidVar3;
      if (dirty) return true;
       dirty = _regraValidVar4OriginalCommited != RegraValidVar4;
      if (dirty) return true;
       dirty = _estruturaEmRevisaoOriginalCommited != EstruturaEmRevisao;
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
       dirty = _responsavelFreteOriginalCommited != ResponsavelFrete;
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
       dirty = _permiteVendaOriginalCommited != PermiteVenda;
      if (dirty) return true;
       dirty = _descricaoAdicionalOriginalCommited != DescricaoAdicional;
      if (dirty) return true;
       dirty = _imprimirEstruturaOpOriginalCommited != ImprimirEstruturaOp;
      if (dirty) return true;
       dirty = _imprimeOpsRelacionadasOriginalCommited != ImprimeOpsRelacionadas;
      if (dirty) return true;
       dirty = _margemRecebimentoOriginalCommited != MargemRecebimento;
      if (dirty) return true;
       dirty = _emitePlanoCorteOriginalCommited != EmitePlanoCorte;
      if (dirty) return true;
       dirty = _validacaoPesoExpedicaoOriginalCommited != ValidacaoPesoExpedicao;
      if (dirty) return true;
       dirty = _gtinOriginalCommited != Gtin;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;
      if (dirty) return true;
       dirty = _estruturaEmRevisaoObservacaoOriginalCommited != EstruturaEmRevisaoObservacao;
      if (dirty) return true;
       if (_modeloEtiquetaExpedicaoOriginalCommited!=null)
       {
          dirty = !_modeloEtiquetaExpedicaoOriginalCommited.Equals(ModeloEtiquetaExpedicao);
       }
       else
       {
            dirty = ModeloEtiquetaExpedicao != null;
       }
      if (dirty) return true;
       dirty = _loteMinimoOriginalCommited != LoteMinimo;
      if (dirty) return true;
       dirty = _bloqueioPrecoVencidoOriginalCommited != BloqueioPrecoVencido;

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
               if (_valueCollectionContratoFornecimentoClassProdutoLoaded) 
               {
                  foreach(ContratoFornecimentoClass item in CollectionContratoFornecimentoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassProdutoLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoLoaded) 
               {
                  foreach(KanbanAcionamentoClass item in CollectionKanbanAcionamentoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionLoteClassProdutoLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassProdutoLoaded) 
               {
                  foreach(OrcamentoCompraItemClass item in CollectionOrcamentoCompraItemClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemClassProdutoLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoClassProdutoLoaded) 
               {
                  foreach(OrdemProducaoClass item in CollectionOrdemProducaoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded) 
               {
                  foreach(OrdemProducaoProdutoComponenteClass item in CollectionOrdemProducaoProdutoComponenteClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassProdutoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoAcabamentoClassProdutoLoaded) 
               {
                  foreach(ProdutoAcabamentoClass item in CollectionProdutoAcabamentoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded) 
               {
                  foreach(ProdutoBloqueioQualidadeClass item in CollectionProdutoBloqueioQualidadeClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoDocumentoTipoClassProdutoLoaded) 
               {
                  foreach(ProdutoDocumentoTipoClass item in CollectionProdutoDocumentoTipoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded) 
               {
                  foreach(ProdutoEstruturaInconsistenciaClass item in CollectionProdutoEstruturaInconsistenciaClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoEstruturaLockClassProdutoLoaded) 
               {
                  foreach(ProdutoEstruturaLockClass item in CollectionProdutoEstruturaLockClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoFiscalClassProdutoLoaded) 
               {
                  foreach(ProdutoFiscalClass item in CollectionProdutoFiscalClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoFornecedorClassProdutoLoaded) 
               {
                  foreach(ProdutoFornecedorClass item in CollectionProdutoFornecedorClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoKProdutoClassProdutoLoaded) 
               {
                  foreach(ProdutoKProdutoClass item in CollectionProdutoKProdutoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoMaterialClassProdutoLoaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded) 
               {
                  foreach(ProdutoPaiFilhoClass item in CollectionProdutoPaiFilhoClassProdutoPai)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded) 
               {
                  foreach(ProdutoPaiFilhoClass item in CollectionProdutoPaiFilhoClassProdutoFilho)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded) 
               {
                  foreach(ProdutoPermissaoVendaPeriodosClass item in CollectionProdutoPermissaoVendaPeriodosClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoPostoTrabalhoClassProdutoLoaded) 
               {
                  foreach(ProdutoPostoTrabalhoClass item in CollectionProdutoPostoTrabalhoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoPrecoClassProdutoLoaded) 
               {
                  foreach(ProdutoPrecoClass item in CollectionProdutoPrecoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoRecursoClassProdutoLoaded) 
               {
                  foreach(ProdutoRecursoClass item in CollectionProdutoRecursoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoRevisaoClassProdutoLoaded) 
               {
                  foreach(ProdutoRevisaoClass item in CollectionProdutoRevisaoClassProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassProdutoLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassProduto)
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
             case "Codigo":
                return this.Codigo;
             case "CodigoCliente":
                return this.CodigoCliente;
             case "Descricao":
                return this.Descricao;
             case "EmiteOp":
                return this.EmiteOp;
             case "LeadTimeFabrica":
                return this.LeadTimeFabrica;
             case "RegraDimensao":
                return this.RegraDimensao;
             case "Figura":
                return this.Figura;
             case "CalculoPreco":
                return this.CalculoPreco;
             case "LoteEconomico":
                return this.LoteEconomico;
             case "MotivoRevisao":
                return this.MotivoRevisao;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "DataRevisaoCadastro":
                return this.DataRevisaoCadastro;
             case "TipoAquisicao":
                return this.TipoAquisicao;
             case "PoliticaEstoque":
                return this.PoliticaEstoque;
             case "ClassificacaoProduto":
                return this.ClassificacaoProduto;
             case "ClassificacaoProduto2":
                return this.ClassificacaoProduto2;
             case "QtdEtiquetaExpedicaoVolume":
                return this.QtdEtiquetaExpedicaoVolume;
             case "Embalagem":
                return this.Embalagem;
             case "DescricaoIngles":
                return this.DescricaoIngles;
             case "DescricaoEspanhol":
                return this.DescricaoEspanhol;
             case "PesoUnitario":
                return this.PesoUnitario;
             case "FamiliaCliente":
                return this.FamiliaCliente;
             case "CadastroPcp":
                return this.CadastroPcp;
             case "CadastroEngenharia":
                return this.CadastroEngenharia;
             case "Acabamento":
                return this.Acabamento;
             case "Variavel1":
                return this.Variavel1;
             case "Variavel2":
                return this.Variavel2;
             case "Variavel3":
                return this.Variavel3;
             case "Variavel4":
                return this.Variavel4;
             case "Cliente":
                return this.Cliente;
             case "UnidadeMedida":
                return this.UnidadeMedida;
             case "UtilizaDimensaoMaiorFilho":
                return this.UtilizaDimensaoMaiorFilho;
             case "LocalFabricacao":
                return this.LocalFabricacao;
             case "AgrupadorOp":
                return this.AgrupadorOp;
             case "AplicacaoCliente":
                return this.AplicacaoCliente;
             case "TempoLimite":
                return this.TempoLimite;
             case "CadastroPreco":
                return this.CadastroPreco;
             case "EtiquetaInterna":
                return this.EtiquetaInterna;
             case "Temporario":
                return this.Temporario;
             case "Vermelho":
                return this.Vermelho;
             case "Verde":
                return this.Verde;
             case "Amarelo":
                return this.Amarelo;
             case "LotePadraoCompra":
                return this.LotePadraoCompra;
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
             case "VersaoEstruturaAtual":
                return this.VersaoEstruturaAtual;
             case "RastreamentoMaterial":
                return this.RastreamentoMaterial;
             case "RegraValidVar1":
                return this.RegraValidVar1;
             case "RegraValidVar2":
                return this.RegraValidVar2;
             case "RegraValidVar3":
                return this.RegraValidVar3;
             case "RegraValidVar4":
                return this.RegraValidVar4;
             case "EstruturaEmRevisao":
                return this.EstruturaEmRevisao;
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
             case "ResponsavelFrete":
                return this.ResponsavelFrete;
             case "Comprador":
                return this.Comprador;
             case "PermiteVenda":
                return this.PermiteVenda;
             case "DescricaoAdicional":
                return this.DescricaoAdicional;
             case "ImprimirEstruturaOp":
                return this.ImprimirEstruturaOp;
             case "ImprimeOpsRelacionadas":
                return this.ImprimeOpsRelacionadas;
             case "MargemRecebimento":
                return this.MargemRecebimento;
             case "EmitePlanoCorte":
                return this.EmitePlanoCorte;
             case "ValidacaoPesoExpedicao":
                return this.ValidacaoPesoExpedicao;
             case "Gtin":
                return this.Gtin;
             case "Ativo":
                return this.Ativo;
             case "EstruturaEmRevisaoObservacao":
                return this.EstruturaEmRevisaoObservacao;
             case "ModeloEtiquetaExpedicao":
                return this.ModeloEtiquetaExpedicao;
             case "LoteMinimo":
                return this.LoteMinimo;
             case "BloqueioPrecoVencido":
                return this.BloqueioPrecoVencido;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
             if (ClassificacaoProduto!=null)
                ClassificacaoProduto.ChangeSingleConnection(newConnection);
             if (ClassificacaoProduto2!=null)
                ClassificacaoProduto2.ChangeSingleConnection(newConnection);
             if (Embalagem!=null)
                Embalagem.ChangeSingleConnection(newConnection);
             if (FamiliaCliente!=null)
                FamiliaCliente.ChangeSingleConnection(newConnection);
             if (Acabamento!=null)
                Acabamento.ChangeSingleConnection(newConnection);
             if (Variavel1!=null)
                Variavel1.ChangeSingleConnection(newConnection);
             if (Variavel2!=null)
                Variavel2.ChangeSingleConnection(newConnection);
             if (Variavel3!=null)
                Variavel3.ChangeSingleConnection(newConnection);
             if (Variavel4!=null)
                Variavel4.ChangeSingleConnection(newConnection);
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
             if (UnidadeMedida!=null)
                UnidadeMedida.ChangeSingleConnection(newConnection);
             if (LocalFabricacao!=null)
                LocalFabricacao.ChangeSingleConnection(newConnection);
             if (AgrupadorOp!=null)
                AgrupadorOp.ChangeSingleConnection(newConnection);
             if (AplicacaoCliente!=null)
                AplicacaoCliente.ChangeSingleConnection(newConnection);
             if (UnidadeMedidaCompra!=null)
                UnidadeMedidaCompra.ChangeSingleConnection(newConnection);
             if (Comprador!=null)
                Comprador.ChangeSingleConnection(newConnection);
             if (ModeloEtiquetaExpedicao!=null)
                ModeloEtiquetaExpedicao.ChangeSingleConnection(newConnection);
               if (_valueCollectionContratoFornecimentoClassProdutoLoaded) 
               {
                  foreach(ContratoFornecimentoClass item in CollectionContratoFornecimentoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassProdutoLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassProdutoLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassProdutoLoaded) 
               {
                  foreach(KanbanAcionamentoClass item in CollectionKanbanAcionamentoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionLoteClassProdutoLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassProdutoLoaded) 
               {
                  foreach(OrcamentoCompraItemClass item in CollectionOrcamentoCompraItemClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassProdutoLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemClassProdutoLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoClassProdutoLoaded) 
               {
                  foreach(OrdemProducaoClass item in CollectionOrdemProducaoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassProdutoLoaded) 
               {
                  foreach(OrdemProducaoProdutoComponenteClass item in CollectionOrdemProducaoProdutoComponenteClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassProdutoLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassProdutoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoAcabamentoClassProdutoLoaded) 
               {
                  foreach(ProdutoAcabamentoClass item in CollectionProdutoAcabamentoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoBloqueioQualidadeClassProdutoLoaded) 
               {
                  foreach(ProdutoBloqueioQualidadeClass item in CollectionProdutoBloqueioQualidadeClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoDocumentoTipoClassProdutoLoaded) 
               {
                  foreach(ProdutoDocumentoTipoClass item in CollectionProdutoDocumentoTipoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoLoaded) 
               {
                  foreach(ProdutoEstruturaInconsistenciaClass item in CollectionProdutoEstruturaInconsistenciaClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoEstruturaLockClassProdutoLoaded) 
               {
                  foreach(ProdutoEstruturaLockClass item in CollectionProdutoEstruturaLockClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoFiscalClassProdutoLoaded) 
               {
                  foreach(ProdutoFiscalClass item in CollectionProdutoFiscalClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoFornecedorClassProdutoLoaded) 
               {
                  foreach(ProdutoFornecedorClass item in CollectionProdutoFornecedorClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoKProdutoClassProdutoLoaded) 
               {
                  foreach(ProdutoKProdutoClass item in CollectionProdutoKProdutoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoMaterialClassProdutoLoaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded) 
               {
                  foreach(ProdutoPaiFilhoClass item in CollectionProdutoPaiFilhoClassProdutoPai)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded) 
               {
                  foreach(ProdutoPaiFilhoClass item in CollectionProdutoPaiFilhoClassProdutoFilho)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoPermissaoVendaPeriodosClassProdutoLoaded) 
               {
                  foreach(ProdutoPermissaoVendaPeriodosClass item in CollectionProdutoPermissaoVendaPeriodosClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoPostoTrabalhoClassProdutoLoaded) 
               {
                  foreach(ProdutoPostoTrabalhoClass item in CollectionProdutoPostoTrabalhoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoPrecoClassProdutoLoaded) 
               {
                  foreach(ProdutoPrecoClass item in CollectionProdutoPrecoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoRecursoClassProdutoLoaded) 
               {
                  foreach(ProdutoRecursoClass item in CollectionProdutoRecursoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoRevisaoClassProdutoLoaded) 
               {
                  foreach(ProdutoRevisaoClass item in CollectionProdutoRevisaoClassProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassProdutoLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassProduto)
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
                  command.CommandText += " COUNT(produto.id_produto) " ;
               }
               else
               {
               command.CommandText += "produto.id_produto, " ;
               command.CommandText += "produto.pro_codigo, " ;
               command.CommandText += "produto.pro_codigo_cliente, " ;
               command.CommandText += "produto.pro_descricao, " ;
               command.CommandText += "produto.pro_emite_op, " ;
               command.CommandText += "produto.pro_lead_time_fabrica, " ;
               command.CommandText += "produto.pro_regra_dimensao, " ;
               command.CommandText += "produto.pro_calculo_preco, " ;
               command.CommandText += "produto.pro_lote_economico, " ;
               command.CommandText += "produto.pro_motivo_revisao, " ;
               command.CommandText += "produto.id_acs_usuario, " ;
               command.CommandText += "produto.pro_data_revisao_cadastro, " ;
               command.CommandText += "produto.pro_tipo_aquisicao, " ;
               command.CommandText += "produto.pro_politica_estoque, " ;
               command.CommandText += "produto.id_classificacao_produto, " ;
               command.CommandText += "produto.id_classificacao_produto_2, " ;
               command.CommandText += "produto.pro_qtd_etiqueta_expedicao_volume, " ;
               command.CommandText += "produto.id_embalagem, " ;
               command.CommandText += "produto.pro_descricao_ingles, " ;
               command.CommandText += "produto.pro_descricao_espanhol, " ;
               command.CommandText += "produto.pro_peso_unitario, " ;
               command.CommandText += "produto.id_familia_cliente, " ;
               command.CommandText += "produto.pro_cadastro_pcp, " ;
               command.CommandText += "produto.pro_cadastro_engenharia, " ;
               command.CommandText += "produto.id_acabamento, " ;
               command.CommandText += "produto.id_variavel_1, " ;
               command.CommandText += "produto.id_variavel_2, " ;
               command.CommandText += "produto.id_variavel_3, " ;
               command.CommandText += "produto.id_variavel_4, " ;
               command.CommandText += "produto.id_cliente, " ;
               command.CommandText += "produto.id_unidade_medida, " ;
               command.CommandText += "produto.pro_utiliza_dimensao_maior_filho, " ;
               command.CommandText += "produto.id_local_fabricacao, " ;
               command.CommandText += "produto.id_agrupador_op, " ;
               command.CommandText += "produto.id_aplicacao_cliente, " ;
               command.CommandText += "produto.pro_tempo_limite, " ;
               command.CommandText += "produto.pro_cadastro_preco, " ;
               command.CommandText += "produto.pro_etiqueta_interna, " ;
               command.CommandText += "produto.pro_temporario, " ;
               command.CommandText += "produto.pro_vermelho, " ;
               command.CommandText += "produto.pro_verde, " ;
               command.CommandText += "produto.pro_amarelo, " ;
               command.CommandText += "produto.pro_lote_padrao_compra, " ;
               command.CommandText += "produto.id_unidade_medida_compra, " ;
               command.CommandText += "produto.pro_unidades_por_un_compra, " ;
               command.CommandText += "produto.pro_lead_time_compra, " ;
               command.CommandText += "produto.pro_marcas_homologadas, " ;
               command.CommandText += "produto.pro_impedir_solicitacao_auto, " ;
               command.CommandText += "produto.pro_versao_estrutura_atual, " ;
               command.CommandText += "produto.pro_rastreamento_material, " ;
               command.CommandText += "produto.pro_regra_valid_var1, " ;
               command.CommandText += "produto.pro_regra_valid_var2, " ;
               command.CommandText += "produto.pro_regra_valid_var3, " ;
               command.CommandText += "produto.pro_regra_valid_var4, " ;
               command.CommandText += "produto.pro_estrutura_em_revisao, " ;
               command.CommandText += "produto.pro_utilizando_estoque_seguranca, " ;
               command.CommandText += "produto.pro_utilizando_estoque_seguranca_data, " ;
               command.CommandText += "produto.entity_uid, " ;
               command.CommandText += "produto.version, " ;
               command.CommandText += "produto.pro_responsavel_frete, " ;
               command.CommandText += "produto.id_comprador, " ;
               command.CommandText += "produto.pro_permite_venda, " ;
               command.CommandText += "produto.pro_descricao_adicional, " ;
               command.CommandText += "produto.pro_imprimir_estrutura_op, " ;
               command.CommandText += "produto.pro_imprime_ops_relacionadas, " ;
               command.CommandText += "produto.pro_margem_recebimento, " ;
               command.CommandText += "produto.pro_emite_plano_corte, " ;
               command.CommandText += "produto.pro_validacao_peso_expedicao, " ;
               command.CommandText += "produto.pro_gtin, " ;
               command.CommandText += "produto.pro_ativo, " ;
               command.CommandText += "produto.pro_estrutura_em_revisao_observacao, " ;
               command.CommandText += "produto.id_modelo_etiqueta_expedicao, " ;
               command.CommandText += "produto.pro_lote_minimo, " ;
               command.CommandText += "produto.pro_bloqueio_preco_vencido " ;
               }
               command.CommandText += " FROM  produto ";
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
                        orderByClause += " , pro_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pro_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = produto.id_acs_usuario_ultima_revisao ";
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
                     case "id_produto":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.id_produto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.id_produto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_codigo_cliente":
                     case "CodigoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_codigo_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_codigo_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_emite_op":
                     case "EmiteOp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_emite_op " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_emite_op) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_lead_time_fabrica":
                     case "LeadTimeFabrica":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_lead_time_fabrica " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_lead_time_fabrica) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_regra_dimensao":
                     case "RegraDimensao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_regra_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_regra_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_figura":
                     case "Figura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_figura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_figura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_calculo_preco":
                     case "CalculoPreco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_calculo_preco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_calculo_preco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_lote_economico":
                     case "LoteEconomico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_lote_economico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_lote_economico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_motivo_revisao":
                     case "MotivoRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_motivo_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_motivo_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , produto.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "pro_data_revisao_cadastro":
                     case "DataRevisaoCadastro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_data_revisao_cadastro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_data_revisao_cadastro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_tipo_aquisicao":
                     case "TipoAquisicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_tipo_aquisicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_tipo_aquisicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_politica_estoque":
                     case "PoliticaEstoque":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_politica_estoque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_politica_estoque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_classificacao_produto":
                     case "ClassificacaoProduto":
                     command.CommandText += " LEFT JOIN classificacao_produto as classificacao_produto_ClassificacaoProduto ON classificacao_produto_ClassificacaoProduto.id_classificacao_produto = produto.id_classificacao_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_classificacao_produto_2":
                     case "ClassificacaoProduto2":
                     orderByClause += " , produto.id_classificacao_produto_2 " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "pro_qtd_etiqueta_expedicao_volume":
                     case "QtdEtiquetaExpedicaoVolume":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_qtd_etiqueta_expedicao_volume " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_qtd_etiqueta_expedicao_volume) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_embalagem":
                     case "Embalagem":
                     command.CommandText += " LEFT JOIN embalagem as embalagem_Embalagem ON embalagem_Embalagem.id_embalagem = produto.id_embalagem ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , embalagem_Embalagem.emb_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(embalagem_Embalagem.emb_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_descricao_ingles":
                     case "DescricaoIngles":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_descricao_ingles " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_descricao_ingles) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_descricao_espanhol":
                     case "DescricaoEspanhol":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_descricao_espanhol " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_descricao_espanhol) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_peso_unitario":
                     case "PesoUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_peso_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_peso_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_familia_cliente":
                     case "FamiliaCliente":
                     command.CommandText += " LEFT JOIN familia_cliente as familia_cliente_FamiliaCliente ON familia_cliente_FamiliaCliente.id_familia_cliente = produto.id_familia_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_cliente_FamiliaCliente.fac_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_cliente_FamiliaCliente.fac_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_cadastro_pcp":
                     case "CadastroPcp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_cadastro_pcp " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_cadastro_pcp) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_cadastro_engenharia":
                     case "CadastroEngenharia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_cadastro_engenharia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_cadastro_engenharia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acabamento":
                     case "Acabamento":
                     command.CommandText += " LEFT JOIN acabamento as acabamento_Acabamento ON acabamento_Acabamento.id_acabamento = produto.id_acabamento ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_variavel_1":
                     case "Variavel1":
                     command.CommandText += " LEFT JOIN variavel as variavel_Variavel1 ON variavel_Variavel1.id_variavel = produto.id_variavel_1 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , variavel_Variavel1.var_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(variavel_Variavel1.var_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_variavel_2":
                     case "Variavel2":
                     command.CommandText += " LEFT JOIN variavel as variavel_Variavel2 ON variavel_Variavel2.id_variavel = produto.id_variavel_2 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , variavel_Variavel2.var_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(variavel_Variavel2.var_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_variavel_3":
                     case "Variavel3":
                     command.CommandText += " LEFT JOIN variavel as variavel_Variavel3 ON variavel_Variavel3.id_variavel = produto.id_variavel_3 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , variavel_Variavel3.var_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(variavel_Variavel3.var_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_variavel_4":
                     case "Variavel4":
                     command.CommandText += " LEFT JOIN variavel as variavel_Variavel4 ON variavel_Variavel4.id_variavel = produto.id_variavel_4 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , variavel_Variavel4.var_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(variavel_Variavel4.var_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = produto.id_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente_Cliente.cli_nome_resumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente_Cliente.cli_nome_resumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida":
                     case "UnidadeMedida":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedida ON unidade_medida_UnidadeMedida.id_unidade_medida = produto.id_unidade_medida ";                     switch (parametro.TipoOrdenacao)
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
                     case "pro_utiliza_dimensao_maior_filho":
                     case "UtilizaDimensaoMaiorFilho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_utiliza_dimensao_maior_filho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_utiliza_dimensao_maior_filho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_local_fabricacao":
                     case "LocalFabricacao":
                     command.CommandText += " LEFT JOIN local_fabricacao as local_fabricacao_LocalFabricacao ON local_fabricacao_LocalFabricacao.id_local_fabricacao = produto.id_local_fabricacao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , local_fabricacao_LocalFabricacao.lof_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(local_fabricacao_LocalFabricacao.lof_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_agrupador_op":
                     case "AgrupadorOp":
                     command.CommandText += " LEFT JOIN agrupador_op as agrupador_op_AgrupadorOp ON agrupador_op_AgrupadorOp.id_agrupador_op = produto.id_agrupador_op ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_op_AgrupadorOp.ago_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_op_AgrupadorOp.ago_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_aplicacao_cliente":
                     case "AplicacaoCliente":
                     command.CommandText += " LEFT JOIN aplicacao_cliente as aplicacao_cliente_AplicacaoCliente ON aplicacao_cliente_AplicacaoCliente.id_aplicacao_cliente = produto.id_aplicacao_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , aplicacao_cliente_AplicacaoCliente.apc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(aplicacao_cliente_AplicacaoCliente.apc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_tempo_limite":
                     case "TempoLimite":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_tempo_limite " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_tempo_limite) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_cadastro_preco":
                     case "CadastroPreco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_cadastro_preco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_cadastro_preco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_etiqueta_interna":
                     case "EtiquetaInterna":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_etiqueta_interna " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_etiqueta_interna) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_temporario":
                     case "Temporario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_temporario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_temporario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_vermelho":
                     case "Vermelho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_vermelho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_vermelho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_verde":
                     case "Verde":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_verde " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_verde) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_amarelo":
                     case "Amarelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_amarelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_amarelo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_lote_padrao_compra":
                     case "LotePadraoCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_lote_padrao_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_lote_padrao_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_compra":
                     case "UnidadeMedidaCompra":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaCompra ON unidade_medida_UnidadeMedidaCompra.id_unidade_medida = produto.id_unidade_medida_compra ";                     switch (parametro.TipoOrdenacao)
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
                     case "pro_unidades_por_un_compra":
                     case "UnidadesPorUnCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_unidades_por_un_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_unidades_por_un_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_lead_time_compra":
                     case "LeadTimeCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_lead_time_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_lead_time_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_marcas_homologadas":
                     case "MarcasHomologadas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_marcas_homologadas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_marcas_homologadas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_impedir_solicitacao_auto":
                     case "ImpedirSolicitacaoAuto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_impedir_solicitacao_auto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_impedir_solicitacao_auto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_versao_estrutura_atual":
                     case "VersaoEstruturaAtual":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_versao_estrutura_atual " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_versao_estrutura_atual) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_rastreamento_material":
                     case "RastreamentoMaterial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_rastreamento_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_rastreamento_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_regra_valid_var1":
                     case "RegraValidVar1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_regra_valid_var1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_regra_valid_var1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_regra_valid_var2":
                     case "RegraValidVar2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_regra_valid_var2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_regra_valid_var2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_regra_valid_var3":
                     case "RegraValidVar3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_regra_valid_var3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_regra_valid_var3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_regra_valid_var4":
                     case "RegraValidVar4":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_regra_valid_var4 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_regra_valid_var4) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_estrutura_em_revisao":
                     case "EstruturaEmRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_estrutura_em_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_estrutura_em_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_utilizando_estoque_seguranca":
                     case "UtilizandoEstoqueSeguranca":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_utilizando_estoque_seguranca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_utilizando_estoque_seguranca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_utilizando_estoque_seguranca_data":
                     case "UtilizandoEstoqueSegurancaData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_utilizando_estoque_seguranca_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_utilizando_estoque_seguranca_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , produto.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_imagem":
                     case "Imagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_imagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_imagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_responsavel_frete":
                     case "ResponsavelFrete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_responsavel_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_responsavel_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_comprador":
                     case "Comprador":
                     command.CommandText += " LEFT JOIN comprador as comprador_Comprador ON comprador_Comprador.id_comprador = produto.id_comprador ";                     switch (parametro.TipoOrdenacao)
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
                     case "pro_permite_venda":
                     case "PermiteVenda":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_permite_venda " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_permite_venda) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_descricao_adicional":
                     case "DescricaoAdicional":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_descricao_adicional " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_descricao_adicional) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_imprimir_estrutura_op":
                     case "ImprimirEstruturaOp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_imprimir_estrutura_op " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_imprimir_estrutura_op) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_imprime_ops_relacionadas":
                     case "ImprimeOpsRelacionadas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_imprime_ops_relacionadas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_imprime_ops_relacionadas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_margem_recebimento":
                     case "MargemRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_margem_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_margem_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_emite_plano_corte":
                     case "EmitePlanoCorte":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_emite_plano_corte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_emite_plano_corte) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_validacao_peso_expedicao":
                     case "ValidacaoPesoExpedicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_validacao_peso_expedicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_validacao_peso_expedicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_gtin":
                     case "Gtin":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_gtin " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_gtin) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_estrutura_em_revisao_observacao":
                     case "EstruturaEmRevisaoObservacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto.pro_estrutura_em_revisao_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto.pro_estrutura_em_revisao_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_modelo_etiqueta_expedicao":
                     case "ModeloEtiquetaExpedicao":
                     command.CommandText += " LEFT JOIN modelo_etiqueta_expedicao as modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao ON modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao.id_modelo_etiqueta_expedicao = produto.id_modelo_etiqueta_expedicao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao.mee_descricao_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao.mee_descricao_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_lote_minimo":
                     case "LoteMinimo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_lote_minimo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_lote_minimo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pro_bloqueio_preco_vencido":
                     case "BloqueioPrecoVencido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto.pro_bloqueio_preco_vencido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto.pro_bloqueio_preco_vencido) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_codigo")) 
                        {
                           whereClause += " OR UPPER(produto.pro_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_codigo_cliente")) 
                        {
                           whereClause += " OR UPPER(produto.pro_codigo_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_codigo_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_descricao")) 
                        {
                           whereClause += " OR UPPER(produto.pro_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_regra_dimensao")) 
                        {
                           whereClause += " OR UPPER(produto.pro_regra_dimensao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_regra_dimensao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_motivo_revisao")) 
                        {
                           whereClause += " OR UPPER(produto.pro_motivo_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_motivo_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_descricao_ingles")) 
                        {
                           whereClause += " OR UPPER(produto.pro_descricao_ingles) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_descricao_ingles) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_descricao_espanhol")) 
                        {
                           whereClause += " OR UPPER(produto.pro_descricao_espanhol) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_descricao_espanhol) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_marcas_homologadas")) 
                        {
                           whereClause += " OR UPPER(produto.pro_marcas_homologadas) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_marcas_homologadas) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_regra_valid_var1")) 
                        {
                           whereClause += " OR UPPER(produto.pro_regra_valid_var1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_regra_valid_var1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_regra_valid_var2")) 
                        {
                           whereClause += " OR UPPER(produto.pro_regra_valid_var2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_regra_valid_var2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_regra_valid_var3")) 
                        {
                           whereClause += " OR UPPER(produto.pro_regra_valid_var3) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_regra_valid_var3) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_regra_valid_var4")) 
                        {
                           whereClause += " OR UPPER(produto.pro_regra_valid_var4) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_regra_valid_var4) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(produto.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_descricao_adicional")) 
                        {
                           whereClause += " OR UPPER(produto.pro_descricao_adicional) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_descricao_adicional) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_gtin")) 
                        {
                           whereClause += " OR UPPER(produto.pro_gtin) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_gtin) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pro_estrutura_em_revisao_observacao")) 
                        {
                           whereClause += " OR UPPER(produto.pro_estrutura_em_revisao_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto.pro_estrutura_em_revisao_observacao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_produto = :produto_ID_3270 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_ID_3270", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "pro_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_codigo LIKE :produto_Codigo_8733 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Codigo_8733", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoCliente" || parametro.FieldName == "pro_codigo_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_codigo_cliente LIKE :produto_CodigoCliente_1244 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_CodigoCliente_1244", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "pro_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_descricao LIKE :produto_Descricao_2545 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Descricao_2545", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmiteOp" || parametro.FieldName == "pro_emite_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_emite_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_emite_op = :produto_EmiteOp_4922 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_EmiteOp_4922", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LeadTimeFabrica" || parametro.FieldName == "pro_lead_time_fabrica")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_lead_time_fabrica IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_lead_time_fabrica = :produto_LeadTimeFabrica_7426 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_LeadTimeFabrica_7426", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraDimensao" || parametro.FieldName == "pro_regra_dimensao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_dimensao LIKE :produto_RegraDimensao_7977 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraDimensao_7977", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Figura" || parametro.FieldName == "pro_figura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_figura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_figura = :produto_Figura_9164 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Figura_9164", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CalculoPreco" || parametro.FieldName == "pro_calculo_preco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoCalculoPrecoProdudo)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoCalculoPrecoProdudo");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_calculo_preco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_calculo_preco = :produto_CalculoPreco_5172 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_CalculoPreco_5172", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LoteEconomico" || parametro.FieldName == "pro_lote_economico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_lote_economico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_lote_economico = :produto_LoteEconomico_660 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_LoteEconomico_660", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoRevisao" || parametro.FieldName == "pro_motivo_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_motivo_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_motivo_revisao LIKE :produto_MotivoRevisao_9614 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_MotivoRevisao_9614", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuario" || parametro.FieldName == "id_acs_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_acs_usuario = :produto_AcsUsuario_2705 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_AcsUsuario_2705", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRevisaoCadastro" || parametro.FieldName == "pro_data_revisao_cadastro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_data_revisao_cadastro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_data_revisao_cadastro = :produto_DataRevisaoCadastro_7957 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_DataRevisaoCadastro_7957", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoAquisicao" || parametro.FieldName == "pro_tipo_aquisicao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoAquisicao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoAquisicao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_tipo_aquisicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_tipo_aquisicao = :produto_TipoAquisicao_1776 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_TipoAquisicao_1776", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PoliticaEstoque" || parametro.FieldName == "pro_politica_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is PoliticaEstoque)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo PoliticaEstoque");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_politica_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_politica_estoque = :produto_PoliticaEstoque_5652 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_PoliticaEstoque_5652", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  produto.id_classificacao_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_classificacao_produto = :produto_ClassificacaoProduto_7849 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_ClassificacaoProduto_7849", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClassificacaoProduto2" || parametro.FieldName == "id_classificacao_produto_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ClassificacaoProduto2Class)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ClassificacaoProduto2Class");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_classificacao_produto_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_classificacao_produto_2 = :produto_ClassificacaoProduto2_2322 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_ClassificacaoProduto2_2322", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdEtiquetaExpedicaoVolume" || parametro.FieldName == "pro_qtd_etiqueta_expedicao_volume")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_qtd_etiqueta_expedicao_volume IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_qtd_etiqueta_expedicao_volume = :produto_QtdEtiquetaExpedicaoVolume_802 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_QtdEtiquetaExpedicaoVolume_802", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Embalagem" || parametro.FieldName == "id_embalagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EmbalagemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EmbalagemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_embalagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_embalagem = :produto_Embalagem_3451 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Embalagem_3451", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoIngles" || parametro.FieldName == "pro_descricao_ingles")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_descricao_ingles IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_descricao_ingles LIKE :produto_DescricaoIngles_1679 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_DescricaoIngles_1679", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoEspanhol" || parametro.FieldName == "pro_descricao_espanhol")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_descricao_espanhol IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_descricao_espanhol LIKE :produto_DescricaoEspanhol_814 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_DescricaoEspanhol_814", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PesoUnitario" || parametro.FieldName == "pro_peso_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_peso_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_peso_unitario = :produto_PesoUnitario_2581 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_PesoUnitario_2581", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FamiliaCliente" || parametro.FieldName == "id_familia_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FamiliaClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FamiliaClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_familia_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_familia_cliente = :produto_FamiliaCliente_53 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_FamiliaCliente_53", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CadastroPcp" || parametro.FieldName == "pro_cadastro_pcp")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_cadastro_pcp IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_cadastro_pcp = :produto_CadastroPcp_2446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_CadastroPcp_2446", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CadastroEngenharia" || parametro.FieldName == "pro_cadastro_engenharia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_cadastro_engenharia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_cadastro_engenharia = :produto_CadastroEngenharia_3405 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_CadastroEngenharia_3405", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  produto.id_acabamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_acabamento = :produto_Acabamento_1984 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Acabamento_1984", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel1" || parametro.FieldName == "id_variavel_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.VariavelClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.VariavelClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_variavel_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_variavel_1 = :produto_Variavel1_4567 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Variavel1_4567", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel2" || parametro.FieldName == "id_variavel_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.VariavelClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.VariavelClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_variavel_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_variavel_2 = :produto_Variavel2_4766 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Variavel2_4766", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel3" || parametro.FieldName == "id_variavel_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.VariavelClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.VariavelClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_variavel_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_variavel_3 = :produto_Variavel3_9882 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Variavel3_9882", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel4" || parametro.FieldName == "id_variavel_4")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.VariavelClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.VariavelClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_variavel_4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_variavel_4 = :produto_Variavel4_5193 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Variavel4_5193", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cliente" || parametro.FieldName == "id_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_cliente = :produto_Cliente_2928 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Cliente_2928", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  produto.id_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_unidade_medida = :produto_UnidadeMedida_3384 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_UnidadeMedida_3384", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizaDimensaoMaiorFilho" || parametro.FieldName == "pro_utiliza_dimensao_maior_filho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_utiliza_dimensao_maior_filho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_utiliza_dimensao_maior_filho = :produto_UtilizaDimensaoMaiorFilho_8933 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_UtilizaDimensaoMaiorFilho_8933", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LocalFabricacao" || parametro.FieldName == "id_local_fabricacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.LocalFabricacaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.LocalFabricacaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_local_fabricacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_local_fabricacao = :produto_LocalFabricacao_8408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_LocalFabricacao_8408", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgrupadorOp" || parametro.FieldName == "id_agrupador_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.AgrupadorOpClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.AgrupadorOpClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_agrupador_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_agrupador_op = :produto_AgrupadorOp_6992 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_AgrupadorOp_6992", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AplicacaoCliente" || parametro.FieldName == "id_aplicacao_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.AplicacaoClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.AplicacaoClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_aplicacao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_aplicacao_cliente = :produto_AplicacaoCliente_4271 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_AplicacaoCliente_4271", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TempoLimite" || parametro.FieldName == "pro_tempo_limite")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_tempo_limite IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_tempo_limite = :produto_TempoLimite_2497 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_TempoLimite_2497", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CadastroPreco" || parametro.FieldName == "pro_cadastro_preco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_cadastro_preco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_cadastro_preco = :produto_CadastroPreco_7460 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_CadastroPreco_7460", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaInterna" || parametro.FieldName == "pro_etiqueta_interna")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_etiqueta_interna IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_etiqueta_interna = :produto_EtiquetaInterna_972 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_EtiquetaInterna_972", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Temporario" || parametro.FieldName == "pro_temporario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_temporario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_temporario = :produto_Temporario_5055 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Temporario_5055", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Vermelho" || parametro.FieldName == "pro_vermelho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_vermelho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_vermelho = :produto_Vermelho_6012 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Vermelho_6012", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Verde" || parametro.FieldName == "pro_verde")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_verde IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_verde = :produto_Verde_6182 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Verde_6182", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Amarelo" || parametro.FieldName == "pro_amarelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_amarelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_amarelo = :produto_Amarelo_5147 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Amarelo_5147", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LotePadraoCompra" || parametro.FieldName == "pro_lote_padrao_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_lote_padrao_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_lote_padrao_compra = :produto_LotePadraoCompra_4415 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_LotePadraoCompra_4415", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  produto.id_unidade_medida_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_unidade_medida_compra = :produto_UnidadeMedidaCompra_1229 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_UnidadeMedidaCompra_1229", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadesPorUnCompra" || parametro.FieldName == "pro_unidades_por_un_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_unidades_por_un_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_unidades_por_un_compra = :produto_UnidadesPorUnCompra_7483 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_UnidadesPorUnCompra_7483", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LeadTimeCompra" || parametro.FieldName == "pro_lead_time_compra")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_lead_time_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_lead_time_compra = :produto_LeadTimeCompra_6589 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_LeadTimeCompra_6589", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MarcasHomologadas" || parametro.FieldName == "pro_marcas_homologadas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_marcas_homologadas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_marcas_homologadas LIKE :produto_MarcasHomologadas_1780 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_MarcasHomologadas_1780", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpedirSolicitacaoAuto" || parametro.FieldName == "pro_impedir_solicitacao_auto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_impedir_solicitacao_auto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_impedir_solicitacao_auto = :produto_ImpedirSolicitacaoAuto_8065 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_ImpedirSolicitacaoAuto_8065", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoEstruturaAtual" || parametro.FieldName == "pro_versao_estrutura_atual")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_versao_estrutura_atual IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_versao_estrutura_atual = :produto_VersaoEstruturaAtual_3267 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_VersaoEstruturaAtual_3267", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RastreamentoMaterial" || parametro.FieldName == "pro_rastreamento_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_rastreamento_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_rastreamento_material = :produto_RastreamentoMaterial_1267 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RastreamentoMaterial_1267", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraValidVar1" || parametro.FieldName == "pro_regra_valid_var1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_valid_var1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_valid_var1 LIKE :produto_RegraValidVar1_9474 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraValidVar1_9474", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraValidVar2" || parametro.FieldName == "pro_regra_valid_var2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_valid_var2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_valid_var2 LIKE :produto_RegraValidVar2_2409 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraValidVar2_2409", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraValidVar3" || parametro.FieldName == "pro_regra_valid_var3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_valid_var3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_valid_var3 LIKE :produto_RegraValidVar3_2840 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraValidVar3_2840", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraValidVar4" || parametro.FieldName == "pro_regra_valid_var4")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_valid_var4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_valid_var4 LIKE :produto_RegraValidVar4_1013 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraValidVar4_1013", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstruturaEmRevisao" || parametro.FieldName == "pro_estrutura_em_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_estrutura_em_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_estrutura_em_revisao = :produto_EstruturaEmRevisao_689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_EstruturaEmRevisao_689", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizandoEstoqueSeguranca" || parametro.FieldName == "pro_utilizando_estoque_seguranca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EstoqueSeguranca)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EstoqueSeguranca");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_utilizando_estoque_seguranca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_utilizando_estoque_seguranca = :produto_UtilizandoEstoqueSeguranca_8680 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_UtilizandoEstoqueSeguranca_8680", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizandoEstoqueSegurancaData" || parametro.FieldName == "pro_utilizando_estoque_seguranca_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_utilizando_estoque_seguranca_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_utilizando_estoque_seguranca_data = :produto_UtilizandoEstoqueSegurancaData_8797 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_UtilizandoEstoqueSegurancaData_8797", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  produto.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.entity_uid LIKE :produto_EntityUid_9138 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_EntityUid_9138", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.version = :produto_Version_2938 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Version_2938", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Imagem" || parametro.FieldName == "pro_imagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_imagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_imagem = :produto_Imagem_2860 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Imagem_2860", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ResponsavelFrete" || parametro.FieldName == "pro_responsavel_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ResponsavelFrete?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ResponsavelFrete?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_responsavel_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_responsavel_frete = :produto_ResponsavelFrete_3212 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_ResponsavelFrete_3212", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  produto.id_comprador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_comprador = :produto_Comprador_9280 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Comprador_9280", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PermiteVenda" || parametro.FieldName == "pro_permite_venda")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_permite_venda IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_permite_venda = :produto_PermiteVenda_9978 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_PermiteVenda_9978", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoAdicional" || parametro.FieldName == "pro_descricao_adicional")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_descricao_adicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_descricao_adicional LIKE :produto_DescricaoAdicional_7731 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_DescricaoAdicional_7731", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImprimirEstruturaOp" || parametro.FieldName == "pro_imprimir_estrutura_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_imprimir_estrutura_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_imprimir_estrutura_op = :produto_ImprimirEstruturaOp_6230 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_ImprimirEstruturaOp_6230", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImprimeOpsRelacionadas" || parametro.FieldName == "pro_imprime_ops_relacionadas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_imprime_ops_relacionadas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_imprime_ops_relacionadas = :produto_ImprimeOpsRelacionadas_3770 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_ImprimeOpsRelacionadas_3770", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MargemRecebimento" || parametro.FieldName == "pro_margem_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_margem_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_margem_recebimento = :produto_MargemRecebimento_9547 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_MargemRecebimento_9547", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmitePlanoCorte" || parametro.FieldName == "pro_emite_plano_corte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_emite_plano_corte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_emite_plano_corte = :produto_EmitePlanoCorte_4783 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_EmitePlanoCorte_4783", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValidacaoPesoExpedicao" || parametro.FieldName == "pro_validacao_peso_expedicao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_validacao_peso_expedicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_validacao_peso_expedicao = :produto_ValidacaoPesoExpedicao_1381 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_ValidacaoPesoExpedicao_1381", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Gtin" || parametro.FieldName == "pro_gtin")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_gtin IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_gtin LIKE :produto_Gtin_5353 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Gtin_5353", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "pro_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_ativo = :produto_Ativo_4860 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Ativo_4860", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstruturaEmRevisaoObservacao" || parametro.FieldName == "pro_estrutura_em_revisao_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_estrutura_em_revisao_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_estrutura_em_revisao_observacao LIKE :produto_EstruturaEmRevisaoObservacao_9829 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_EstruturaEmRevisaoObservacao_9829", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloEtiquetaExpedicao" || parametro.FieldName == "id_modelo_etiqueta_expedicao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.id_modelo_etiqueta_expedicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.id_modelo_etiqueta_expedicao = :produto_ModeloEtiquetaExpedicao_8394 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_ModeloEtiquetaExpedicao_8394", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LoteMinimo" || parametro.FieldName == "pro_lote_minimo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_lote_minimo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_lote_minimo = :produto_LoteMinimo_5665 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_LoteMinimo_5665", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BloqueioPrecoVencido" || parametro.FieldName == "pro_bloqueio_preco_vencido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_bloqueio_preco_vencido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_bloqueio_preco_vencido = :produto_BloqueioPrecoVencido_4630 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_BloqueioPrecoVencido_4630", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  produto.pro_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_codigo LIKE :produto_Codigo_7433 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Codigo_7433", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoClienteExato" || parametro.FieldName == "CodigoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_codigo_cliente LIKE :produto_CodigoCliente_5637 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_CodigoCliente_5637", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto.pro_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_descricao LIKE :produto_Descricao_1218 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Descricao_1218", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraDimensaoExato" || parametro.FieldName == "RegraDimensaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_dimensao LIKE :produto_RegraDimensao_5921 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraDimensao_5921", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoRevisaoExato" || parametro.FieldName == "MotivoRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_motivo_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_motivo_revisao LIKE :produto_MotivoRevisao_5393 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_MotivoRevisao_5393", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoInglesExato" || parametro.FieldName == "DescricaoInglesExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_descricao_ingles IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_descricao_ingles LIKE :produto_DescricaoIngles_2787 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_DescricaoIngles_2787", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoEspanholExato" || parametro.FieldName == "DescricaoEspanholExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_descricao_espanhol IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_descricao_espanhol LIKE :produto_DescricaoEspanhol_6700 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_DescricaoEspanhol_6700", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto.pro_marcas_homologadas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_marcas_homologadas LIKE :produto_MarcasHomologadas_6616 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_MarcasHomologadas_6616", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraValidVar1Exato" || parametro.FieldName == "RegraValidVar1Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_valid_var1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_valid_var1 LIKE :produto_RegraValidVar1_3926 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraValidVar1_3926", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraValidVar2Exato" || parametro.FieldName == "RegraValidVar2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_valid_var2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_valid_var2 LIKE :produto_RegraValidVar2_3453 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraValidVar2_3453", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraValidVar3Exato" || parametro.FieldName == "RegraValidVar3Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_valid_var3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_valid_var3 LIKE :produto_RegraValidVar3_975 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraValidVar3_975", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraValidVar4Exato" || parametro.FieldName == "RegraValidVar4Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_regra_valid_var4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_regra_valid_var4 LIKE :produto_RegraValidVar4_6094 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_RegraValidVar4_6094", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.entity_uid LIKE :produto_EntityUid_7396 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_EntityUid_7396", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto.pro_descricao_adicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_descricao_adicional LIKE :produto_DescricaoAdicional_6303 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_DescricaoAdicional_6303", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto.pro_gtin IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_gtin LIKE :produto_Gtin_5590 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_Gtin_5590", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstruturaEmRevisaoObservacaoExato" || parametro.FieldName == "EstruturaEmRevisaoObservacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto.pro_estrutura_em_revisao_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto.pro_estrutura_em_revisao_observacao LIKE :produto_EstruturaEmRevisaoObservacao_3699 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_EstruturaEmRevisaoObservacao_3699", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProdutoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProdutoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProdutoClass), Convert.ToInt32(read["id_produto"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProdutoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_produto"]);
                     entidade.Codigo = (read["pro_codigo"] != DBNull.Value ? read["pro_codigo"].ToString() : null);
                     entidade.CodigoCliente = (read["pro_codigo_cliente"] != DBNull.Value ? read["pro_codigo_cliente"].ToString() : null);
                     entidade.Descricao = (read["pro_descricao"] != DBNull.Value ? read["pro_descricao"].ToString() : null);
                     entidade.EmiteOp = Convert.ToBoolean(Convert.ToInt16(read["pro_emite_op"]));
                     entidade.LeadTimeFabrica = (int)read["pro_lead_time_fabrica"];
                     entidade.RegraDimensao = (read["pro_regra_dimensao"] != DBNull.Value ? read["pro_regra_dimensao"].ToString() : null);
                     entidade.CalculoPreco = (TipoCalculoPrecoProdudo) (read["pro_calculo_preco"] != DBNull.Value ? Enum.ToObject(typeof(TipoCalculoPrecoProdudo), read["pro_calculo_preco"]) : null);
                     entidade.LoteEconomico = (double)read["pro_lote_economico"];
                     entidade.MotivoRevisao = (read["pro_motivo_revisao"] != DBNull.Value ? read["pro_motivo_revisao"].ToString() : null);
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.DataRevisaoCadastro = (DateTime)read["pro_data_revisao_cadastro"];
                     entidade.TipoAquisicao = (TipoAquisicao) (read["pro_tipo_aquisicao"] != DBNull.Value ? Enum.ToObject(typeof(TipoAquisicao), read["pro_tipo_aquisicao"]) : null);
                     entidade.PoliticaEstoque = (PoliticaEstoque) (read["pro_politica_estoque"] != DBNull.Value ? Enum.ToObject(typeof(PoliticaEstoque), read["pro_politica_estoque"]) : null);
                     if (read["id_classificacao_produto"] != DBNull.Value)
                     {
                        entidade.ClassificacaoProduto = (BibliotecaEntidades.Entidades.ClassificacaoProdutoClass)BibliotecaEntidades.Entidades.ClassificacaoProdutoClass.GetEntidade(Convert.ToInt32(read["id_classificacao_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ClassificacaoProduto = null ;
                     }
                     if (read["id_classificacao_produto_2"] != DBNull.Value)
                     {
                        entidade.ClassificacaoProduto2 = (BibliotecaEntidades.Entidades.ClassificacaoProduto2Class)BibliotecaEntidades.Entidades.ClassificacaoProduto2Class.GetEntidade(Convert.ToInt32(read["id_classificacao_produto_2"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ClassificacaoProduto2 = null ;
                     }
                     entidade.QtdEtiquetaExpedicaoVolume = (int)read["pro_qtd_etiqueta_expedicao_volume"];
                     if (read["id_embalagem"] != DBNull.Value)
                     {
                        entidade.Embalagem = (BibliotecaEntidades.Entidades.EmbalagemClass)BibliotecaEntidades.Entidades.EmbalagemClass.GetEntidade(Convert.ToInt32(read["id_embalagem"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Embalagem = null ;
                     }
                     entidade.DescricaoIngles = (read["pro_descricao_ingles"] != DBNull.Value ? read["pro_descricao_ingles"].ToString() : null);
                     entidade.DescricaoEspanhol = (read["pro_descricao_espanhol"] != DBNull.Value ? read["pro_descricao_espanhol"].ToString() : null);
                     entidade.PesoUnitario = (double)read["pro_peso_unitario"];
                     if (read["id_familia_cliente"] != DBNull.Value)
                     {
                        entidade.FamiliaCliente = (BibliotecaEntidades.Entidades.FamiliaClienteClass)BibliotecaEntidades.Entidades.FamiliaClienteClass.GetEntidade(Convert.ToInt32(read["id_familia_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FamiliaCliente = null ;
                     }
                     entidade.CadastroPcp = Convert.ToBoolean(Convert.ToInt16(read["pro_cadastro_pcp"]));
                     entidade.CadastroEngenharia = Convert.ToBoolean(Convert.ToInt16(read["pro_cadastro_engenharia"]));
                     if (read["id_acabamento"] != DBNull.Value)
                     {
                        entidade.Acabamento = (BibliotecaEntidades.Entidades.AcabamentoClass)BibliotecaEntidades.Entidades.AcabamentoClass.GetEntidade(Convert.ToInt32(read["id_acabamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Acabamento = null ;
                     }
                     if (read["id_variavel_1"] != DBNull.Value)
                     {
                        entidade.Variavel1 = (BibliotecaEntidades.Entidades.VariavelClass)BibliotecaEntidades.Entidades.VariavelClass.GetEntidade(Convert.ToInt32(read["id_variavel_1"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Variavel1 = null ;
                     }
                     if (read["id_variavel_2"] != DBNull.Value)
                     {
                        entidade.Variavel2 = (BibliotecaEntidades.Entidades.VariavelClass)BibliotecaEntidades.Entidades.VariavelClass.GetEntidade(Convert.ToInt32(read["id_variavel_2"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Variavel2 = null ;
                     }
                     if (read["id_variavel_3"] != DBNull.Value)
                     {
                        entidade.Variavel3 = (BibliotecaEntidades.Entidades.VariavelClass)BibliotecaEntidades.Entidades.VariavelClass.GetEntidade(Convert.ToInt32(read["id_variavel_3"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Variavel3 = null ;
                     }
                     if (read["id_variavel_4"] != DBNull.Value)
                     {
                        entidade.Variavel4 = (BibliotecaEntidades.Entidades.VariavelClass)BibliotecaEntidades.Entidades.VariavelClass.GetEntidade(Convert.ToInt32(read["id_variavel_4"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Variavel4 = null ;
                     }
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     if (read["id_unidade_medida"] != DBNull.Value)
                     {
                        entidade.UnidadeMedida = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedida = null ;
                     }
                     entidade.UtilizaDimensaoMaiorFilho = Convert.ToBoolean(Convert.ToInt16(read["pro_utiliza_dimensao_maior_filho"]));
                     if (read["id_local_fabricacao"] != DBNull.Value)
                     {
                        entidade.LocalFabricacao = (BibliotecaEntidades.Entidades.LocalFabricacaoClass)BibliotecaEntidades.Entidades.LocalFabricacaoClass.GetEntidade(Convert.ToInt32(read["id_local_fabricacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.LocalFabricacao = null ;
                     }
                     if (read["id_agrupador_op"] != DBNull.Value)
                     {
                        entidade.AgrupadorOp = (BibliotecaEntidades.Entidades.AgrupadorOpClass)BibliotecaEntidades.Entidades.AgrupadorOpClass.GetEntidade(Convert.ToInt32(read["id_agrupador_op"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AgrupadorOp = null ;
                     }
                     if (read["id_aplicacao_cliente"] != DBNull.Value)
                     {
                        entidade.AplicacaoCliente = (BibliotecaEntidades.Entidades.AplicacaoClienteClass)BibliotecaEntidades.Entidades.AplicacaoClienteClass.GetEntidade(Convert.ToInt32(read["id_aplicacao_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AplicacaoCliente = null ;
                     }
                     entidade.TempoLimite = read["pro_tempo_limite"] as int?;
                     entidade.CadastroPreco = Convert.ToBoolean(Convert.ToInt16(read["pro_cadastro_preco"]));
                     entidade.EtiquetaInterna = Convert.ToBoolean(Convert.ToInt16(read["pro_etiqueta_interna"]));
                     entidade.Temporario = Convert.ToBoolean(Convert.ToInt16(read["pro_temporario"]));
                     entidade.Vermelho = (double)read["pro_vermelho"];
                     entidade.Verde = (double)read["pro_verde"];
                     entidade.Amarelo = (double)read["pro_amarelo"];
                     entidade.LotePadraoCompra = read["pro_lote_padrao_compra"] as double?;
                     if (read["id_unidade_medida_compra"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaCompra = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_compra"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaCompra = null ;
                     }
                     entidade.UnidadesPorUnCompra = (double)read["pro_unidades_por_un_compra"];
                     entidade.LeadTimeCompra = (int)read["pro_lead_time_compra"];
                     entidade.MarcasHomologadas = (read["pro_marcas_homologadas"] != DBNull.Value ? read["pro_marcas_homologadas"].ToString() : null);
                     entidade.ImpedirSolicitacaoAuto = Convert.ToBoolean(Convert.ToInt16(read["pro_impedir_solicitacao_auto"]));
                     entidade.VersaoEstruturaAtual = (int)read["pro_versao_estrutura_atual"];
                     entidade.RastreamentoMaterial = Convert.ToBoolean(Convert.ToInt16(read["pro_rastreamento_material"]));
                     entidade.RegraValidVar1 = (read["pro_regra_valid_var1"] != DBNull.Value ? read["pro_regra_valid_var1"].ToString() : null);
                     entidade.RegraValidVar2 = (read["pro_regra_valid_var2"] != DBNull.Value ? read["pro_regra_valid_var2"].ToString() : null);
                     entidade.RegraValidVar3 = (read["pro_regra_valid_var3"] != DBNull.Value ? read["pro_regra_valid_var3"].ToString() : null);
                     entidade.RegraValidVar4 = (read["pro_regra_valid_var4"] != DBNull.Value ? read["pro_regra_valid_var4"].ToString() : null);
                     entidade.EstruturaEmRevisao = Convert.ToBoolean(Convert.ToInt16(read["pro_estrutura_em_revisao"]));
                     entidade.UtilizandoEstoqueSeguranca = (EstoqueSeguranca) (read["pro_utilizando_estoque_seguranca"] != DBNull.Value ? Enum.ToObject(typeof(EstoqueSeguranca), read["pro_utilizando_estoque_seguranca"]) : null);
                     entidade.UtilizandoEstoqueSegurancaData = read["pro_utilizando_estoque_seguranca_data"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ResponsavelFrete = (ResponsavelFrete?) (read["pro_responsavel_frete"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(ResponsavelFrete?)), read["pro_responsavel_frete"]) : null);
                     if (read["id_comprador"] != DBNull.Value)
                     {
                        entidade.Comprador = (BibliotecaEntidades.Entidades.CompradorClass)BibliotecaEntidades.Entidades.CompradorClass.GetEntidade(Convert.ToInt32(read["id_comprador"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Comprador = null ;
                     }
                     entidade.PermiteVenda = Convert.ToBoolean(Convert.ToInt16(read["pro_permite_venda"]));
                     entidade.DescricaoAdicional = (read["pro_descricao_adicional"] != DBNull.Value ? read["pro_descricao_adicional"].ToString() : null);
                     entidade.ImprimirEstruturaOp = Convert.ToBoolean(Convert.ToInt16(read["pro_imprimir_estrutura_op"]));
                     entidade.ImprimeOpsRelacionadas = Convert.ToBoolean(Convert.ToInt16(read["pro_imprime_ops_relacionadas"]));
                     entidade.MargemRecebimento = read["pro_margem_recebimento"] as double?;
                     entidade.EmitePlanoCorte = Convert.ToBoolean(Convert.ToInt16(read["pro_emite_plano_corte"]));
                     entidade.ValidacaoPesoExpedicao = Convert.ToBoolean(Convert.ToInt16(read["pro_validacao_peso_expedicao"]));
                     entidade.Gtin = (read["pro_gtin"] != DBNull.Value ? read["pro_gtin"].ToString() : null);
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["pro_ativo"]));
                     entidade.EstruturaEmRevisaoObservacao = (read["pro_estrutura_em_revisao_observacao"] != DBNull.Value ? read["pro_estrutura_em_revisao_observacao"].ToString() : null);
                     if (read["id_modelo_etiqueta_expedicao"] != DBNull.Value)
                     {
                        entidade.ModeloEtiquetaExpedicao = (BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass)BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass.GetEntidade(Convert.ToInt32(read["id_modelo_etiqueta_expedicao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ModeloEtiquetaExpedicao = null ;
                     }
                     entidade.LoteMinimo = read["pro_lote_minimo"] as double?;
                     entidade.BloqueioPrecoVencido = Convert.ToBoolean(Convert.ToInt16(read["pro_bloqueio_preco_vencido"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProdutoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
