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
     [Table("epi","epi")]
     public class EpiBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EpiClass";
protected const string ErroDelete = "Erro ao excluir o EpiClass  ";
protected const string ErroSave = "Erro ao salvar o EpiClass.";
protected const string ErroCollectionEpiFornecedorClassEpi = "Erro ao carregar a coleção de EpiFornecedorClass.";
protected const string ErroCollectionEstoqueGavetaItemClassEpi = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected const string ErroCollectionFomularioRetiradaManualEstoqueClassEpi = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
protected const string ErroCollectionFuncaoEpiClassEpi = "Erro ao carregar a coleção de FuncaoEpiClass.";
protected const string ErroCollectionFuncionarioEpiClassEpi = "Erro ao carregar a coleção de FuncionarioEpiClass.";
protected const string ErroCollectionHistoricoCompraEpiClassEpi = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
protected const string ErroCollectionKanbanAcionamentoClassEpi = "Erro ao carregar a coleção de KanbanAcionamentoClass.";
protected const string ErroCollectionLoteClassEpi = "Erro ao carregar a coleção de LoteClass.";
protected const string ErroCollectionOrcamentoCompraItemClassEpi = "Erro ao carregar a coleção de OrcamentoCompraItemClass.";
protected const string ErroCollectionSolicitacaoCompraClassEpi = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 50 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroUltimaRevisaoObrigatorio = "O campo UltimaRevisao é obrigatório";
protected const string ErroUltimaRevisaoComprimento = "O campo UltimaRevisao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroUnidadeMedidaUsoObrigatorio = "O campo UnidadeMedidaUso é obrigatório";
protected const string ErroEpiCaObrigatorio = "O campo EpiCa é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do EpiClass.";
protected const string MensagemUtilizadoCollectionEpiFornecedorClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes EpiFornecedorClass:";
protected const string MensagemUtilizadoCollectionEstoqueGavetaItemClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
protected const string MensagemUtilizadoCollectionFuncaoEpiClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes FuncaoEpiClass:";
protected const string MensagemUtilizadoCollectionFuncionarioEpiClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes FuncionarioEpiClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraEpiClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
protected const string MensagemUtilizadoCollectionKanbanAcionamentoClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes KanbanAcionamentoClass:";
protected const string MensagemUtilizadoCollectionLoteClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes LoteClass:";
protected const string MensagemUtilizadoCollectionOrcamentoCompraItemClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes OrcamentoCompraItemClass:";
protected const string MensagemUtilizadoCollectionSolicitacaoCompraClassEpi =  "A entidade EpiClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EpiClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("epi_identificacao")]
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
         [Column("epi_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected string _descricaoAdicionalOriginal{get;private set;}
       private string _descricaoAdicionalOriginalCommited{get; set;}
        private string _valueDescricaoAdicional;
         [Column("epi_descricao_adicional")]
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
         [Column("epi_lote_padrao")]
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
         [Column("epi_verde")]
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
         [Column("epi_amarelo")]
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
         [Column("epi_vermelho")]
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

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaUsoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaUsoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedidaUso;
        [Column("id_unidade_medida_uso", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedidaUso
        { 
           get {                 return this._valueUnidadeMedidaUso; } 
           set 
           { 
                if (this._valueUnidadeMedidaUso == value)return;
                 this._valueUnidadeMedidaUso = value; 
           } 
       } 

       protected double _unidadesPorUnidadeCompraOriginal{get;private set;}
       private double _unidadesPorUnidadeCompraOriginalCommited{get; set;}
        private double _valueUnidadesPorUnidadeCompra;
         [Column("epi_unidades_por_unidade_compra")]
        public virtual double UnidadesPorUnidadeCompra
         { 
            get { return this._valueUnidadesPorUnidadeCompra; } 
            set 
            { 
                if (this._valueUnidadesPorUnidadeCompra == value)return;
                 this._valueUnidadesPorUnidadeCompra = value; 
            } 
        } 

       protected int _leadTimeCompraOriginal{get;private set;}
       private int _leadTimeCompraOriginalCommited{get; set;}
        private int _valueLeadTimeCompra;
         [Column("epi_lead_time_compra")]
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
         [Column("epi_marcas_homologadas")]
        public virtual string MarcasHomologadas
         { 
            get { return this._valueMarcasHomologadas; } 
            set 
            { 
                if (this._valueMarcasHomologadas == value)return;
                 this._valueMarcasHomologadas = value; 
            } 
        } 

       protected bool _impedirSolicitacaoAutomaticaOriginal{get;private set;}
       private bool _impedirSolicitacaoAutomaticaOriginalCommited{get; set;}
        private bool _valueImpedirSolicitacaoAutomatica;
         [Column("epi_impedir_solicitacao_automatica")]
        public virtual bool ImpedirSolicitacaoAutomatica
         { 
            get { return this._valueImpedirSolicitacaoAutomatica; } 
            set 
            { 
                if (this._valueImpedirSolicitacaoAutomatica == value)return;
                 this._valueImpedirSolicitacaoAutomatica = value; 
            } 
        } 

       protected double? _margemRecebimentoOriginal{get;private set;}
       private double? _margemRecebimentoOriginalCommited{get; set;}
        private double? _valueMargemRecebimento;
         [Column("epi_margem_recebimento")]
        public virtual double? MargemRecebimento
         { 
            get { return this._valueMargemRecebimento; } 
            set 
            { 
                if (this._valueMargemRecebimento == value)return;
                 this._valueMargemRecebimento = value; 
            } 
        } 

       protected bool _controleValidadeOriginal{get;private set;}
       private bool _controleValidadeOriginalCommited{get; set;}
        private bool _valueControleValidade;
         [Column("epi_controle_validade")]
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
         [Column("epi_controle_validade_meses")]
        public virtual int? ControleValidadeMeses
         { 
            get { return this._valueControleValidadeMeses; } 
            set 
            { 
                if (this._valueControleValidadeMeses == value)return;
                 this._valueControleValidadeMeses = value; 
            } 
        } 

       protected string _observacaoOriginal{get;private set;}
       private string _observacaoOriginalCommited{get; set;}
        private string _valueObservacao;
         [Column("epi_observacao")]
        public virtual string Observacao
         { 
            get { return this._valueObservacao; } 
            set 
            { 
                if (this._valueObservacao == value)return;
                 this._valueObservacao = value; 
            } 
        } 

       protected EstoqueSeguranca _utilizandoEstoqueSegurancaOriginal{get;private set;}
       private EstoqueSeguranca _utilizandoEstoqueSegurancaOriginalCommited{get; set;}
        private EstoqueSeguranca _valueUtilizandoEstoqueSeguranca;
         [Column("epi_utilizando_estoque_seguranca")]
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
         [Column("epi_utilizando_estoque_seguranca_data")]
        public virtual DateTime? UtilizandoEstoqueSegurancaData
         { 
            get { return this._valueUtilizandoEstoqueSegurancaData; } 
            set 
            { 
                if (this._valueUtilizandoEstoqueSegurancaData == value)return;
                 this._valueUtilizandoEstoqueSegurancaData = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EpiCaClass _epiCaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EpiCaClass _epiCaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EpiCaClass _valueEpiCa;
        [Column("id_epi_ca", "epi_ca", "id_epi_ca")]
       public virtual BibliotecaEntidades.Entidades.EpiCaClass EpiCa
        { 
           get {                 return this._valueEpiCa; } 
           set 
           { 
                if (this._valueEpiCa == value)return;
                 this._valueEpiCa = value; 
           } 
       } 

       protected double _loteMinimoOriginal{get;private set;}
       private double _loteMinimoOriginalCommited{get; set;}
        private double _valueLoteMinimo;
         [Column("epi_lote_minimo")]
        public virtual double LoteMinimo
         { 
            get { return this._valueLoteMinimo; } 
            set 
            { 
                if (this._valueLoteMinimo == value)return;
                 this._valueLoteMinimo = value; 
            } 
        } 

       private List<long> _collectionEpiFornecedorClassEpiOriginal;
       private List<Entidades.EpiFornecedorClass > _collectionEpiFornecedorClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiFornecedorClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiFornecedorClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiFornecedorClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EpiFornecedorClass> _valueCollectionEpiFornecedorClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EpiFornecedorClass> CollectionEpiFornecedorClassEpi 
       { 
           get { if(!_valueCollectionEpiFornecedorClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionEpiFornecedorClassEpi();}
return this._valueCollectionEpiFornecedorClassEpi; } 
           set 
           { 
               this._valueCollectionEpiFornecedorClassEpi = value; 
               this._valueCollectionEpiFornecedorClassEpiLoaded = true; 
           } 
       } 

       private List<long> _collectionEstoqueGavetaItemClassEpiOriginal;
       private List<Entidades.EstoqueGavetaItemClass > _collectionEstoqueGavetaItemClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueGavetaItemClass> _valueCollectionEstoqueGavetaItemClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueGavetaItemClass> CollectionEstoqueGavetaItemClassEpi 
       { 
           get { if(!_valueCollectionEstoqueGavetaItemClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueGavetaItemClassEpi();}
return this._valueCollectionEstoqueGavetaItemClassEpi; } 
           set 
           { 
               this._valueCollectionEstoqueGavetaItemClassEpi = value; 
               this._valueCollectionEstoqueGavetaItemClassEpiLoaded = true; 
           } 
       } 

       private List<long> _collectionFomularioRetiradaManualEstoqueClassEpiOriginal;
       private List<Entidades.FomularioRetiradaManualEstoqueClass > _collectionFomularioRetiradaManualEstoqueClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FomularioRetiradaManualEstoqueClass> _valueCollectionFomularioRetiradaManualEstoqueClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FomularioRetiradaManualEstoqueClass> CollectionFomularioRetiradaManualEstoqueClassEpi 
       { 
           get { if(!_valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionFomularioRetiradaManualEstoqueClassEpi();}
return this._valueCollectionFomularioRetiradaManualEstoqueClassEpi; } 
           set 
           { 
               this._valueCollectionFomularioRetiradaManualEstoqueClassEpi = value; 
               this._valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded = true; 
           } 
       } 

       private List<long> _collectionFuncaoEpiClassEpiOriginal;
       private List<Entidades.FuncaoEpiClass > _collectionFuncaoEpiClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncaoEpiClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncaoEpiClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncaoEpiClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FuncaoEpiClass> _valueCollectionFuncaoEpiClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FuncaoEpiClass> CollectionFuncaoEpiClassEpi 
       { 
           get { if(!_valueCollectionFuncaoEpiClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionFuncaoEpiClassEpi();}
return this._valueCollectionFuncaoEpiClassEpi; } 
           set 
           { 
               this._valueCollectionFuncaoEpiClassEpi = value; 
               this._valueCollectionFuncaoEpiClassEpiLoaded = true; 
           } 
       } 

       private List<long> _collectionFuncionarioEpiClassEpiOriginal;
       private List<Entidades.FuncionarioEpiClass > _collectionFuncionarioEpiClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioEpiClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioEpiClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioEpiClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FuncionarioEpiClass> _valueCollectionFuncionarioEpiClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FuncionarioEpiClass> CollectionFuncionarioEpiClassEpi 
       { 
           get { if(!_valueCollectionFuncionarioEpiClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionFuncionarioEpiClassEpi();}
return this._valueCollectionFuncionarioEpiClassEpi; } 
           set 
           { 
               this._valueCollectionFuncionarioEpiClassEpi = value; 
               this._valueCollectionFuncionarioEpiClassEpiLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraEpiClassEpiOriginal;
       private List<Entidades.HistoricoCompraEpiClass > _collectionHistoricoCompraEpiClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraEpiClass> _valueCollectionHistoricoCompraEpiClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraEpiClass> CollectionHistoricoCompraEpiClassEpi 
       { 
           get { if(!_valueCollectionHistoricoCompraEpiClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraEpiClassEpi();}
return this._valueCollectionHistoricoCompraEpiClassEpi; } 
           set 
           { 
               this._valueCollectionHistoricoCompraEpiClassEpi = value; 
               this._valueCollectionHistoricoCompraEpiClassEpiLoaded = true; 
           } 
       } 

       private List<long> _collectionKanbanAcionamentoClassEpiOriginal;
       private List<Entidades.KanbanAcionamentoClass > _collectionKanbanAcionamentoClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKanbanAcionamentoClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.KanbanAcionamentoClass> _valueCollectionKanbanAcionamentoClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.KanbanAcionamentoClass> CollectionKanbanAcionamentoClassEpi 
       { 
           get { if(!_valueCollectionKanbanAcionamentoClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionKanbanAcionamentoClassEpi();}
return this._valueCollectionKanbanAcionamentoClassEpi; } 
           set 
           { 
               this._valueCollectionKanbanAcionamentoClassEpi = value; 
               this._valueCollectionKanbanAcionamentoClassEpiLoaded = true; 
           } 
       } 

       private List<long> _collectionLoteClassEpiOriginal;
       private List<Entidades.LoteClass > _collectionLoteClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LoteClass> _valueCollectionLoteClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LoteClass> CollectionLoteClassEpi 
       { 
           get { if(!_valueCollectionLoteClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionLoteClassEpi();}
return this._valueCollectionLoteClassEpi; } 
           set 
           { 
               this._valueCollectionLoteClassEpi = value; 
               this._valueCollectionLoteClassEpiLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoCompraItemClassEpiOriginal;
       private List<Entidades.OrcamentoCompraItemClass > _collectionOrcamentoCompraItemClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoCompraItemClass> _valueCollectionOrcamentoCompraItemClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoCompraItemClass> CollectionOrcamentoCompraItemClassEpi 
       { 
           get { if(!_valueCollectionOrcamentoCompraItemClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoCompraItemClassEpi();}
return this._valueCollectionOrcamentoCompraItemClassEpi; } 
           set 
           { 
               this._valueCollectionOrcamentoCompraItemClassEpi = value; 
               this._valueCollectionOrcamentoCompraItemClassEpiLoaded = true; 
           } 
       } 

       private List<long> _collectionSolicitacaoCompraClassEpiOriginal;
       private List<Entidades.SolicitacaoCompraClass > _collectionSolicitacaoCompraClassEpiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassEpiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassEpiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassEpiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.SolicitacaoCompraClass> _valueCollectionSolicitacaoCompraClassEpi { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.SolicitacaoCompraClass> CollectionSolicitacaoCompraClassEpi 
       { 
           get { if(!_valueCollectionSolicitacaoCompraClassEpiLoaded && !this.DisableLoadCollection){this.LoadCollectionSolicitacaoCompraClassEpi();}
return this._valueCollectionSolicitacaoCompraClassEpi; } 
           set 
           { 
               this._valueCollectionSolicitacaoCompraClassEpi = value; 
               this._valueCollectionSolicitacaoCompraClassEpiLoaded = true; 
           } 
       } 

        public EpiBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.LotePadrao = 1;
           this.Verde = 0;
           this.Amarelo = 0;
           this.Vermelho = 0;
           this.UnidadesPorUnidadeCompra = 1;
           this.LeadTimeCompra = 0;
           this.ImpedirSolicitacaoAutomatica = false;
           this.ControleValidade = false;
           this.UtilizandoEstoqueSeguranca = (EstoqueSeguranca)0;
           this.LoteMinimo = 1;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static EpiClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EpiClass) GetEntity(typeof(EpiClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEpiFornecedorClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEpiFornecedorClassEpiChanged = true;
                  _valueCollectionEpiFornecedorClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEpiFornecedorClassEpiChanged = true; 
                  _valueCollectionEpiFornecedorClassEpiCommitedChanged = true;
                 foreach (Entidades.EpiFornecedorClass item in e.OldItems) 
                 { 
                     _collectionEpiFornecedorClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEpiFornecedorClassEpiChanged = true; 
                  _valueCollectionEpiFornecedorClassEpiCommitedChanged = true;
                 foreach (Entidades.EpiFornecedorClass item in _valueCollectionEpiFornecedorClassEpi) 
                 { 
                     _collectionEpiFornecedorClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEpiFornecedorClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.EpiFornecedorClass> oc;
                _valueCollectionEpiFornecedorClassEpiChanged = false;
                 _valueCollectionEpiFornecedorClassEpiCommitedChanged = false;
                _collectionEpiFornecedorClassEpiRemovidos = new List<Entidades.EpiFornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EpiFornecedorClass>();
                }
                else{ 
                   Entidades.EpiFornecedorClass search = new Entidades.EpiFornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EpiFornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.EpiFornecedorClass>().ToList());
                 }
                 _valueCollectionEpiFornecedorClassEpi = new BindingList<Entidades.EpiFornecedorClass>(oc); 
                 _collectionEpiFornecedorClassEpiOriginal= (from a in _valueCollectionEpiFornecedorClassEpi select a.ID).ToList();
                 _valueCollectionEpiFornecedorClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionEpiFornecedorClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEpiFornecedorClassEpi+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionEstoqueGavetaItemClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueGavetaItemClassEpiChanged = true;
                  _valueCollectionEstoqueGavetaItemClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueGavetaItemClassEpiChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassEpiCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in e.OldItems) 
                 { 
                     _collectionEstoqueGavetaItemClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueGavetaItemClassEpiChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassEpiCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in _valueCollectionEstoqueGavetaItemClassEpi) 
                 { 
                     _collectionEstoqueGavetaItemClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueGavetaItemClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueGavetaItemClass> oc;
                _valueCollectionEstoqueGavetaItemClassEpiChanged = false;
                 _valueCollectionEstoqueGavetaItemClassEpiCommitedChanged = false;
                _collectionEstoqueGavetaItemClassEpiRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueGavetaItemClass>();
                }
                else{ 
                   Entidades.EstoqueGavetaItemClass search = new Entidades.EstoqueGavetaItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueGavetaItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.EstoqueGavetaItemClass>().ToList());
                 }
                 _valueCollectionEstoqueGavetaItemClassEpi = new BindingList<Entidades.EstoqueGavetaItemClass>(oc); 
                 _collectionEstoqueGavetaItemClassEpiOriginal= (from a in _valueCollectionEstoqueGavetaItemClassEpi select a.ID).ToList();
                 _valueCollectionEstoqueGavetaItemClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueGavetaItemClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueGavetaItemClassEpi+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFomularioRetiradaManualEstoqueClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEpiChanged = true;
                  _valueCollectionFomularioRetiradaManualEstoqueClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEpiChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEpiCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in e.OldItems) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEpiChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEpiCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in _valueCollectionFomularioRetiradaManualEstoqueClassEpi) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFomularioRetiradaManualEstoqueClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass> oc;
                _valueCollectionFomularioRetiradaManualEstoqueClassEpiChanged = false;
                 _valueCollectionFomularioRetiradaManualEstoqueClassEpiCommitedChanged = false;
                _collectionFomularioRetiradaManualEstoqueClassEpiRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>();
                }
                else{ 
                   Entidades.FomularioRetiradaManualEstoqueClass search = new Entidades.FomularioRetiradaManualEstoqueClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.FomularioRetiradaManualEstoqueClass>().ToList());
                 }
                 _valueCollectionFomularioRetiradaManualEstoqueClassEpi = new BindingList<Entidades.FomularioRetiradaManualEstoqueClass>(oc); 
                 _collectionFomularioRetiradaManualEstoqueClassEpiOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassEpi select a.ID).ToList();
                 _valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionFomularioRetiradaManualEstoqueClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFomularioRetiradaManualEstoqueClassEpi+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFuncaoEpiClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFuncaoEpiClassEpiChanged = true;
                  _valueCollectionFuncaoEpiClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFuncaoEpiClassEpiChanged = true; 
                  _valueCollectionFuncaoEpiClassEpiCommitedChanged = true;
                 foreach (Entidades.FuncaoEpiClass item in e.OldItems) 
                 { 
                     _collectionFuncaoEpiClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFuncaoEpiClassEpiChanged = true; 
                  _valueCollectionFuncaoEpiClassEpiCommitedChanged = true;
                 foreach (Entidades.FuncaoEpiClass item in _valueCollectionFuncaoEpiClassEpi) 
                 { 
                     _collectionFuncaoEpiClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFuncaoEpiClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.FuncaoEpiClass> oc;
                _valueCollectionFuncaoEpiClassEpiChanged = false;
                 _valueCollectionFuncaoEpiClassEpiCommitedChanged = false;
                _collectionFuncaoEpiClassEpiRemovidos = new List<Entidades.FuncaoEpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FuncaoEpiClass>();
                }
                else{ 
                   Entidades.FuncaoEpiClass search = new Entidades.FuncaoEpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FuncaoEpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.FuncaoEpiClass>().ToList());
                 }
                 _valueCollectionFuncaoEpiClassEpi = new BindingList<Entidades.FuncaoEpiClass>(oc); 
                 _collectionFuncaoEpiClassEpiOriginal= (from a in _valueCollectionFuncaoEpiClassEpi select a.ID).ToList();
                 _valueCollectionFuncaoEpiClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionFuncaoEpiClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFuncaoEpiClassEpi+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFuncionarioEpiClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFuncionarioEpiClassEpiChanged = true;
                  _valueCollectionFuncionarioEpiClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFuncionarioEpiClassEpiChanged = true; 
                  _valueCollectionFuncionarioEpiClassEpiCommitedChanged = true;
                 foreach (Entidades.FuncionarioEpiClass item in e.OldItems) 
                 { 
                     _collectionFuncionarioEpiClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFuncionarioEpiClassEpiChanged = true; 
                  _valueCollectionFuncionarioEpiClassEpiCommitedChanged = true;
                 foreach (Entidades.FuncionarioEpiClass item in _valueCollectionFuncionarioEpiClassEpi) 
                 { 
                     _collectionFuncionarioEpiClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFuncionarioEpiClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.FuncionarioEpiClass> oc;
                _valueCollectionFuncionarioEpiClassEpiChanged = false;
                 _valueCollectionFuncionarioEpiClassEpiCommitedChanged = false;
                _collectionFuncionarioEpiClassEpiRemovidos = new List<Entidades.FuncionarioEpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FuncionarioEpiClass>();
                }
                else{ 
                   Entidades.FuncionarioEpiClass search = new Entidades.FuncionarioEpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FuncionarioEpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.FuncionarioEpiClass>().ToList());
                 }
                 _valueCollectionFuncionarioEpiClassEpi = new BindingList<Entidades.FuncionarioEpiClass>(oc); 
                 _collectionFuncionarioEpiClassEpiOriginal= (from a in _valueCollectionFuncionarioEpiClassEpi select a.ID).ToList();
                 _valueCollectionFuncionarioEpiClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionFuncionarioEpiClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFuncionarioEpiClassEpi+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraEpiClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraEpiClassEpiChanged = true;
                  _valueCollectionHistoricoCompraEpiClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraEpiClassEpiChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassEpiCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraEpiClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraEpiClassEpiChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassEpiCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in _valueCollectionHistoricoCompraEpiClassEpi) 
                 { 
                     _collectionHistoricoCompraEpiClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraEpiClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraEpiClass> oc;
                _valueCollectionHistoricoCompraEpiClassEpiChanged = false;
                 _valueCollectionHistoricoCompraEpiClassEpiCommitedChanged = false;
                _collectionHistoricoCompraEpiClassEpiRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraEpiClass>();
                }
                else{ 
                   Entidades.HistoricoCompraEpiClass search = new Entidades.HistoricoCompraEpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraEpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.HistoricoCompraEpiClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraEpiClassEpi = new BindingList<Entidades.HistoricoCompraEpiClass>(oc); 
                 _collectionHistoricoCompraEpiClassEpiOriginal= (from a in _valueCollectionHistoricoCompraEpiClassEpi select a.ID).ToList();
                 _valueCollectionHistoricoCompraEpiClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraEpiClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraEpiClassEpi+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionKanbanAcionamentoClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionKanbanAcionamentoClassEpiChanged = true;
                  _valueCollectionKanbanAcionamentoClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionKanbanAcionamentoClassEpiChanged = true; 
                  _valueCollectionKanbanAcionamentoClassEpiCommitedChanged = true;
                 foreach (Entidades.KanbanAcionamentoClass item in e.OldItems) 
                 { 
                     _collectionKanbanAcionamentoClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionKanbanAcionamentoClassEpiChanged = true; 
                  _valueCollectionKanbanAcionamentoClassEpiCommitedChanged = true;
                 foreach (Entidades.KanbanAcionamentoClass item in _valueCollectionKanbanAcionamentoClassEpi) 
                 { 
                     _collectionKanbanAcionamentoClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionKanbanAcionamentoClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.KanbanAcionamentoClass> oc;
                _valueCollectionKanbanAcionamentoClassEpiChanged = false;
                 _valueCollectionKanbanAcionamentoClassEpiCommitedChanged = false;
                _collectionKanbanAcionamentoClassEpiRemovidos = new List<Entidades.KanbanAcionamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.KanbanAcionamentoClass>();
                }
                else{ 
                   Entidades.KanbanAcionamentoClass search = new Entidades.KanbanAcionamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.KanbanAcionamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.KanbanAcionamentoClass>().ToList());
                 }
                 _valueCollectionKanbanAcionamentoClassEpi = new BindingList<Entidades.KanbanAcionamentoClass>(oc); 
                 _collectionKanbanAcionamentoClassEpiOriginal= (from a in _valueCollectionKanbanAcionamentoClassEpi select a.ID).ToList();
                 _valueCollectionKanbanAcionamentoClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionKanbanAcionamentoClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionKanbanAcionamentoClassEpi+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionLoteClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLoteClassEpiChanged = true;
                  _valueCollectionLoteClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLoteClassEpiChanged = true; 
                  _valueCollectionLoteClassEpiCommitedChanged = true;
                 foreach (Entidades.LoteClass item in e.OldItems) 
                 { 
                     _collectionLoteClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLoteClassEpiChanged = true; 
                  _valueCollectionLoteClassEpiCommitedChanged = true;
                 foreach (Entidades.LoteClass item in _valueCollectionLoteClassEpi) 
                 { 
                     _collectionLoteClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLoteClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.LoteClass> oc;
                _valueCollectionLoteClassEpiChanged = false;
                 _valueCollectionLoteClassEpiCommitedChanged = false;
                _collectionLoteClassEpiRemovidos = new List<Entidades.LoteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LoteClass>();
                }
                else{ 
                   Entidades.LoteClass search = new Entidades.LoteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LoteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.LoteClass>().ToList());
                 }
                 _valueCollectionLoteClassEpi = new BindingList<Entidades.LoteClass>(oc); 
                 _collectionLoteClassEpiOriginal= (from a in _valueCollectionLoteClassEpi select a.ID).ToList();
                 _valueCollectionLoteClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionLoteClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLoteClassEpi+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoCompraItemClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoCompraItemClassEpiChanged = true;
                  _valueCollectionOrcamentoCompraItemClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoCompraItemClassEpiChanged = true; 
                  _valueCollectionOrcamentoCompraItemClassEpiCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoCompraItemClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoCompraItemClassEpiChanged = true; 
                  _valueCollectionOrcamentoCompraItemClassEpiCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraItemClass item in _valueCollectionOrcamentoCompraItemClassEpi) 
                 { 
                     _collectionOrcamentoCompraItemClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoCompraItemClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoCompraItemClass> oc;
                _valueCollectionOrcamentoCompraItemClassEpiChanged = false;
                 _valueCollectionOrcamentoCompraItemClassEpiCommitedChanged = false;
                _collectionOrcamentoCompraItemClassEpiRemovidos = new List<Entidades.OrcamentoCompraItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoCompraItemClass>();
                }
                else{ 
                   Entidades.OrcamentoCompraItemClass search = new Entidades.OrcamentoCompraItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoCompraItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.OrcamentoCompraItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoCompraItemClassEpi = new BindingList<Entidades.OrcamentoCompraItemClass>(oc); 
                 _collectionOrcamentoCompraItemClassEpiOriginal= (from a in _valueCollectionOrcamentoCompraItemClassEpi select a.ID).ToList();
                 _valueCollectionOrcamentoCompraItemClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoCompraItemClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoCompraItemClassEpi+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionSolicitacaoCompraClassEpiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionSolicitacaoCompraClassEpiChanged = true;
                  _valueCollectionSolicitacaoCompraClassEpiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionSolicitacaoCompraClassEpiChanged = true; 
                  _valueCollectionSolicitacaoCompraClassEpiCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in e.OldItems) 
                 { 
                     _collectionSolicitacaoCompraClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionSolicitacaoCompraClassEpiChanged = true; 
                  _valueCollectionSolicitacaoCompraClassEpiCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in _valueCollectionSolicitacaoCompraClassEpi) 
                 { 
                     _collectionSolicitacaoCompraClassEpiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionSolicitacaoCompraClassEpi()
         {
            try
            {
                 ObservableCollection<Entidades.SolicitacaoCompraClass> oc;
                _valueCollectionSolicitacaoCompraClassEpiChanged = false;
                 _valueCollectionSolicitacaoCompraClassEpiCommitedChanged = false;
                _collectionSolicitacaoCompraClassEpiRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.SolicitacaoCompraClass>();
                }
                else{ 
                   Entidades.SolicitacaoCompraClass search = new Entidades.SolicitacaoCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.SolicitacaoCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Epi", this),                     }                       ).Cast<Entidades.SolicitacaoCompraClass>().ToList());
                 }
                 _valueCollectionSolicitacaoCompraClassEpi = new BindingList<Entidades.SolicitacaoCompraClass>(oc); 
                 _collectionSolicitacaoCompraClassEpiOriginal= (from a in _valueCollectionSolicitacaoCompraClassEpi select a.ID).ToList();
                 _valueCollectionSolicitacaoCompraClassEpiLoaded = true;
                 oc.CollectionChanged += CollectionSolicitacaoCompraClassEpiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionSolicitacaoCompraClassEpi+"\r\n" + e.Message, e);
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
                if (Identificacao.Length >50)
                {
                    throw new Exception( ErroIdentificacaoComprimento);
                }
                if (string.IsNullOrEmpty(Descricao))
                {
                    throw new Exception(ErroDescricaoObrigatorio);
                }
                if (Descricao.Length >255)
                {
                    throw new Exception( ErroDescricaoComprimento);
                }
                if ( _valueUnidadeMedidaUso == null)
                {
                    throw new Exception(ErroUnidadeMedidaUsoObrigatorio);
                }
                if ( _valueEpiCa == null)
                {
                    throw new Exception(ErroEpiCaObrigatorio);
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
                    "  public.epi  " +
                    "WHERE " +
                    "  id_epi = :id";
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
                        "  public.epi   " +
                        "SET  " + 
                        "  epi_identificacao = :epi_identificacao, " + 
                        "  epi_descricao = :epi_descricao, " + 
                        "  epi_descricao_adicional = :epi_descricao_adicional, " + 
                        "  epi_lote_padrao = :epi_lote_padrao, " + 
                        "  epi_verde = :epi_verde, " + 
                        "  epi_amarelo = :epi_amarelo, " + 
                        "  epi_vermelho = :epi_vermelho, " + 
                        "  id_unidade_medida_compra = :id_unidade_medida_compra, " + 
                        "  id_unidade_medida_uso = :id_unidade_medida_uso, " + 
                        "  epi_unidades_por_unidade_compra = :epi_unidades_por_unidade_compra, " + 
                        "  epi_lead_time_compra = :epi_lead_time_compra, " + 
                        "  epi_marcas_homologadas = :epi_marcas_homologadas, " + 
                        "  epi_impedir_solicitacao_automatica = :epi_impedir_solicitacao_automatica, " + 
                        "  epi_margem_recebimento = :epi_margem_recebimento, " + 
                        "  epi_controle_validade = :epi_controle_validade, " + 
                        "  epi_controle_validade_meses = :epi_controle_validade_meses, " + 
                        "  epi_ultima_revisao = :epi_ultima_revisao, " + 
                        "  epi_ultima_revisao_data = :epi_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  epi_observacao = :epi_observacao, " + 
                        "  epi_utilizando_estoque_seguranca = :epi_utilizando_estoque_seguranca, " + 
                        "  epi_utilizando_estoque_seguranca_data = :epi_utilizando_estoque_seguranca_data, " + 
                        "  id_epi_ca = :id_epi_ca, " + 
                        "  epi_lote_minimo = :epi_lote_minimo "+
                        "WHERE  " +
                        "  id_epi = :id " +
                        "RETURNING id_epi;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.epi " +
                        "( " +
                        "  epi_identificacao , " + 
                        "  epi_descricao , " + 
                        "  epi_descricao_adicional , " + 
                        "  epi_lote_padrao , " + 
                        "  epi_verde , " + 
                        "  epi_amarelo , " + 
                        "  epi_vermelho , " + 
                        "  id_unidade_medida_compra , " + 
                        "  id_unidade_medida_uso , " + 
                        "  epi_unidades_por_unidade_compra , " + 
                        "  epi_lead_time_compra , " + 
                        "  epi_marcas_homologadas , " + 
                        "  epi_impedir_solicitacao_automatica , " + 
                        "  epi_margem_recebimento , " + 
                        "  epi_controle_validade , " + 
                        "  epi_controle_validade_meses , " + 
                        "  epi_ultima_revisao , " + 
                        "  epi_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  epi_observacao , " + 
                        "  epi_utilizando_estoque_seguranca , " + 
                        "  epi_utilizando_estoque_seguranca_data , " + 
                        "  id_epi_ca , " + 
                        "  epi_lote_minimo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :epi_identificacao , " + 
                        "  :epi_descricao , " + 
                        "  :epi_descricao_adicional , " + 
                        "  :epi_lote_padrao , " + 
                        "  :epi_verde , " + 
                        "  :epi_amarelo , " + 
                        "  :epi_vermelho , " + 
                        "  :id_unidade_medida_compra , " + 
                        "  :id_unidade_medida_uso , " + 
                        "  :epi_unidades_por_unidade_compra , " + 
                        "  :epi_lead_time_compra , " + 
                        "  :epi_marcas_homologadas , " + 
                        "  :epi_impedir_solicitacao_automatica , " + 
                        "  :epi_margem_recebimento , " + 
                        "  :epi_controle_validade , " + 
                        "  :epi_controle_validade_meses , " + 
                        "  :epi_ultima_revisao , " + 
                        "  :epi_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :epi_observacao , " + 
                        "  :epi_utilizando_estoque_seguranca , " + 
                        "  :epi_utilizando_estoque_seguranca_data , " + 
                        "  :id_epi_ca , " + 
                        "  :epi_lote_minimo  "+
                        ")RETURNING id_epi;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_descricao_adicional", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoAdicional ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_lote_padrao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LotePadrao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_verde", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Verde ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_amarelo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Amarelo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_vermelho", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Vermelho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaCompra==null ? (object) DBNull.Value : this.UnidadeMedidaCompra.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_uso", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaUso==null ? (object) DBNull.Value : this.UnidadeMedidaUso.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_unidades_por_unidade_compra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UnidadesPorUnidadeCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_lead_time_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LeadTimeCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_marcas_homologadas", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MarcasHomologadas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_impedir_solicitacao_automatica", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpedirSolicitacaoAutomatica ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_margem_recebimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MargemRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_controle_validade", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ControleValidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_controle_validade_meses", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ControleValidadeMeses ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_utilizando_estoque_seguranca", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.UtilizandoEstoqueSeguranca);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_utilizando_estoque_seguranca_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UtilizandoEstoqueSegurancaData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi_ca", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EpiCa==null ? (object) DBNull.Value : this.EpiCa.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_lote_minimo", NpgsqlDbType.Double));
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
 if (CollectionEpiFornecedorClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEpiFornecedorClassEpi+"\r\n";
                foreach (Entidades.EpiFornecedorClass tmp in CollectionEpiFornecedorClassEpi)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionEstoqueGavetaItemClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueGavetaItemClassEpi+"\r\n";
                foreach (Entidades.EstoqueGavetaItemClass tmp in CollectionEstoqueGavetaItemClassEpi)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFomularioRetiradaManualEstoqueClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassEpi+"\r\n";
                foreach (Entidades.FomularioRetiradaManualEstoqueClass tmp in CollectionFomularioRetiradaManualEstoqueClassEpi)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFuncaoEpiClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFuncaoEpiClassEpi+"\r\n";
                foreach (Entidades.FuncaoEpiClass tmp in CollectionFuncaoEpiClassEpi)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFuncionarioEpiClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFuncionarioEpiClassEpi+"\r\n";
                foreach (Entidades.FuncionarioEpiClass tmp in CollectionFuncionarioEpiClassEpi)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraEpiClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraEpiClassEpi+"\r\n";
                foreach (Entidades.HistoricoCompraEpiClass tmp in CollectionHistoricoCompraEpiClassEpi)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionKanbanAcionamentoClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionKanbanAcionamentoClassEpi+"\r\n";
                foreach (Entidades.KanbanAcionamentoClass tmp in CollectionKanbanAcionamentoClassEpi)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionLoteClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLoteClassEpi+"\r\n";
                foreach (Entidades.LoteClass tmp in CollectionLoteClassEpi)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoCompraItemClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoCompraItemClassEpi+"\r\n";
                foreach (Entidades.OrcamentoCompraItemClass tmp in CollectionOrcamentoCompraItemClassEpi)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionSolicitacaoCompraClassEpi.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionSolicitacaoCompraClassEpi+"\r\n";
                foreach (Entidades.SolicitacaoCompraClass tmp in CollectionSolicitacaoCompraClassEpi)
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
        public static EpiClass CopiarEntidade(EpiClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EpiClass toRet = new EpiClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.DescricaoAdicional= entidadeCopiar.DescricaoAdicional;
 toRet.LotePadrao= entidadeCopiar.LotePadrao;
 toRet.Verde= entidadeCopiar.Verde;
 toRet.Amarelo= entidadeCopiar.Amarelo;
 toRet.Vermelho= entidadeCopiar.Vermelho;
 toRet.UnidadeMedidaCompra= entidadeCopiar.UnidadeMedidaCompra;
 toRet.UnidadeMedidaUso= entidadeCopiar.UnidadeMedidaUso;
 toRet.UnidadesPorUnidadeCompra= entidadeCopiar.UnidadesPorUnidadeCompra;
 toRet.LeadTimeCompra= entidadeCopiar.LeadTimeCompra;
 toRet.MarcasHomologadas= entidadeCopiar.MarcasHomologadas;
 toRet.ImpedirSolicitacaoAutomatica= entidadeCopiar.ImpedirSolicitacaoAutomatica;
 toRet.MargemRecebimento= entidadeCopiar.MargemRecebimento;
 toRet.ControleValidade= entidadeCopiar.ControleValidade;
 toRet.ControleValidadeMeses= entidadeCopiar.ControleValidadeMeses;
 toRet.Observacao= entidadeCopiar.Observacao;
 toRet.UtilizandoEstoqueSeguranca= entidadeCopiar.UtilizandoEstoqueSeguranca;
 toRet.UtilizandoEstoqueSegurancaData= entidadeCopiar.UtilizandoEstoqueSegurancaData;
 toRet.EpiCa= entidadeCopiar.EpiCa;
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
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
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
       _unidadeMedidaUsoOriginal = UnidadeMedidaUso;
       _unidadeMedidaUsoOriginalCommited = _unidadeMedidaUsoOriginal;
       _unidadesPorUnidadeCompraOriginal = UnidadesPorUnidadeCompra;
       _unidadesPorUnidadeCompraOriginalCommited = _unidadesPorUnidadeCompraOriginal;
       _leadTimeCompraOriginal = LeadTimeCompra;
       _leadTimeCompraOriginalCommited = _leadTimeCompraOriginal;
       _marcasHomologadasOriginal = MarcasHomologadas;
       _marcasHomologadasOriginalCommited = _marcasHomologadasOriginal;
       _impedirSolicitacaoAutomaticaOriginal = ImpedirSolicitacaoAutomatica;
       _impedirSolicitacaoAutomaticaOriginalCommited = _impedirSolicitacaoAutomaticaOriginal;
       _margemRecebimentoOriginal = MargemRecebimento;
       _margemRecebimentoOriginalCommited = _margemRecebimentoOriginal;
       _controleValidadeOriginal = ControleValidade;
       _controleValidadeOriginalCommited = _controleValidadeOriginal;
       _controleValidadeMesesOriginal = ControleValidadeMeses;
       _controleValidadeMesesOriginalCommited = _controleValidadeMesesOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _observacaoOriginal = Observacao;
       _observacaoOriginalCommited = _observacaoOriginal;
       _utilizandoEstoqueSegurancaOriginal = UtilizandoEstoqueSeguranca;
       _utilizandoEstoqueSegurancaOriginalCommited = _utilizandoEstoqueSegurancaOriginal;
       _utilizandoEstoqueSegurancaDataOriginal = UtilizandoEstoqueSegurancaData;
       _utilizandoEstoqueSegurancaDataOriginalCommited = _utilizandoEstoqueSegurancaDataOriginal;
       _epiCaOriginal = EpiCa;
       _epiCaOriginalCommited = _epiCaOriginal;
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
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
       _descricaoAdicionalOriginalCommited = DescricaoAdicional;
       _lotePadraoOriginalCommited = LotePadrao;
       _verdeOriginalCommited = Verde;
       _amareloOriginalCommited = Amarelo;
       _vermelhoOriginalCommited = Vermelho;
       _unidadeMedidaCompraOriginalCommited = UnidadeMedidaCompra;
       _unidadeMedidaUsoOriginalCommited = UnidadeMedidaUso;
       _unidadesPorUnidadeCompraOriginalCommited = UnidadesPorUnidadeCompra;
       _leadTimeCompraOriginalCommited = LeadTimeCompra;
       _marcasHomologadasOriginalCommited = MarcasHomologadas;
       _impedirSolicitacaoAutomaticaOriginalCommited = ImpedirSolicitacaoAutomatica;
       _margemRecebimentoOriginalCommited = MargemRecebimento;
       _controleValidadeOriginalCommited = ControleValidade;
       _controleValidadeMesesOriginalCommited = ControleValidadeMeses;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;
       _observacaoOriginalCommited = Observacao;
       _utilizandoEstoqueSegurancaOriginalCommited = UtilizandoEstoqueSeguranca;
       _utilizandoEstoqueSegurancaDataOriginalCommited = UtilizandoEstoqueSegurancaData;
       _epiCaOriginalCommited = EpiCa;
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
               if (_valueCollectionEpiFornecedorClassEpiLoaded) 
               {
                  if (_collectionEpiFornecedorClassEpiRemovidos != null) 
                  {
                     _collectionEpiFornecedorClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEpiFornecedorClassEpiRemovidos = new List<Entidades.EpiFornecedorClass>();
                  }
                  _collectionEpiFornecedorClassEpiOriginal= (from a in _valueCollectionEpiFornecedorClassEpi select a.ID).ToList();
                  _valueCollectionEpiFornecedorClassEpiChanged = false;
                  _valueCollectionEpiFornecedorClassEpiCommitedChanged = false;
               }
               if (_valueCollectionEstoqueGavetaItemClassEpiLoaded) 
               {
                  if (_collectionEstoqueGavetaItemClassEpiRemovidos != null) 
                  {
                     _collectionEstoqueGavetaItemClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueGavetaItemClassEpiRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                  }
                  _collectionEstoqueGavetaItemClassEpiOriginal= (from a in _valueCollectionEstoqueGavetaItemClassEpi select a.ID).ToList();
                  _valueCollectionEstoqueGavetaItemClassEpiChanged = false;
                  _valueCollectionEstoqueGavetaItemClassEpiCommitedChanged = false;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded) 
               {
                  if (_collectionFomularioRetiradaManualEstoqueClassEpiRemovidos != null) 
                  {
                     _collectionFomularioRetiradaManualEstoqueClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFomularioRetiradaManualEstoqueClassEpiRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                  }
                  _collectionFomularioRetiradaManualEstoqueClassEpiOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassEpi select a.ID).ToList();
                  _valueCollectionFomularioRetiradaManualEstoqueClassEpiChanged = false;
                  _valueCollectionFomularioRetiradaManualEstoqueClassEpiCommitedChanged = false;
               }
               if (_valueCollectionFuncaoEpiClassEpiLoaded) 
               {
                  if (_collectionFuncaoEpiClassEpiRemovidos != null) 
                  {
                     _collectionFuncaoEpiClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFuncaoEpiClassEpiRemovidos = new List<Entidades.FuncaoEpiClass>();
                  }
                  _collectionFuncaoEpiClassEpiOriginal= (from a in _valueCollectionFuncaoEpiClassEpi select a.ID).ToList();
                  _valueCollectionFuncaoEpiClassEpiChanged = false;
                  _valueCollectionFuncaoEpiClassEpiCommitedChanged = false;
               }
               if (_valueCollectionFuncionarioEpiClassEpiLoaded) 
               {
                  if (_collectionFuncionarioEpiClassEpiRemovidos != null) 
                  {
                     _collectionFuncionarioEpiClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFuncionarioEpiClassEpiRemovidos = new List<Entidades.FuncionarioEpiClass>();
                  }
                  _collectionFuncionarioEpiClassEpiOriginal= (from a in _valueCollectionFuncionarioEpiClassEpi select a.ID).ToList();
                  _valueCollectionFuncionarioEpiClassEpiChanged = false;
                  _valueCollectionFuncionarioEpiClassEpiCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraEpiClassEpiLoaded) 
               {
                  if (_collectionHistoricoCompraEpiClassEpiRemovidos != null) 
                  {
                     _collectionHistoricoCompraEpiClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraEpiClassEpiRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                  }
                  _collectionHistoricoCompraEpiClassEpiOriginal= (from a in _valueCollectionHistoricoCompraEpiClassEpi select a.ID).ToList();
                  _valueCollectionHistoricoCompraEpiClassEpiChanged = false;
                  _valueCollectionHistoricoCompraEpiClassEpiCommitedChanged = false;
               }
               if (_valueCollectionKanbanAcionamentoClassEpiLoaded) 
               {
                  if (_collectionKanbanAcionamentoClassEpiRemovidos != null) 
                  {
                     _collectionKanbanAcionamentoClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionKanbanAcionamentoClassEpiRemovidos = new List<Entidades.KanbanAcionamentoClass>();
                  }
                  _collectionKanbanAcionamentoClassEpiOriginal= (from a in _valueCollectionKanbanAcionamentoClassEpi select a.ID).ToList();
                  _valueCollectionKanbanAcionamentoClassEpiChanged = false;
                  _valueCollectionKanbanAcionamentoClassEpiCommitedChanged = false;
               }
               if (_valueCollectionLoteClassEpiLoaded) 
               {
                  if (_collectionLoteClassEpiRemovidos != null) 
                  {
                     _collectionLoteClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLoteClassEpiRemovidos = new List<Entidades.LoteClass>();
                  }
                  _collectionLoteClassEpiOriginal= (from a in _valueCollectionLoteClassEpi select a.ID).ToList();
                  _valueCollectionLoteClassEpiChanged = false;
                  _valueCollectionLoteClassEpiCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoCompraItemClassEpiLoaded) 
               {
                  if (_collectionOrcamentoCompraItemClassEpiRemovidos != null) 
                  {
                     _collectionOrcamentoCompraItemClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoCompraItemClassEpiRemovidos = new List<Entidades.OrcamentoCompraItemClass>();
                  }
                  _collectionOrcamentoCompraItemClassEpiOriginal= (from a in _valueCollectionOrcamentoCompraItemClassEpi select a.ID).ToList();
                  _valueCollectionOrcamentoCompraItemClassEpiChanged = false;
                  _valueCollectionOrcamentoCompraItemClassEpiCommitedChanged = false;
               }
               if (_valueCollectionSolicitacaoCompraClassEpiLoaded) 
               {
                  if (_collectionSolicitacaoCompraClassEpiRemovidos != null) 
                  {
                     _collectionSolicitacaoCompraClassEpiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionSolicitacaoCompraClassEpiRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                  }
                  _collectionSolicitacaoCompraClassEpiOriginal= (from a in _valueCollectionSolicitacaoCompraClassEpi select a.ID).ToList();
                  _valueCollectionSolicitacaoCompraClassEpiChanged = false;
                  _valueCollectionSolicitacaoCompraClassEpiCommitedChanged = false;
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
               UnidadeMedidaUso=_unidadeMedidaUsoOriginal;
               _unidadeMedidaUsoOriginalCommited=_unidadeMedidaUsoOriginal;
               UnidadesPorUnidadeCompra=_unidadesPorUnidadeCompraOriginal;
               _unidadesPorUnidadeCompraOriginalCommited=_unidadesPorUnidadeCompraOriginal;
               LeadTimeCompra=_leadTimeCompraOriginal;
               _leadTimeCompraOriginalCommited=_leadTimeCompraOriginal;
               MarcasHomologadas=_marcasHomologadasOriginal;
               _marcasHomologadasOriginalCommited=_marcasHomologadasOriginal;
               ImpedirSolicitacaoAutomatica=_impedirSolicitacaoAutomaticaOriginal;
               _impedirSolicitacaoAutomaticaOriginalCommited=_impedirSolicitacaoAutomaticaOriginal;
               MargemRecebimento=_margemRecebimentoOriginal;
               _margemRecebimentoOriginalCommited=_margemRecebimentoOriginal;
               ControleValidade=_controleValidadeOriginal;
               _controleValidadeOriginalCommited=_controleValidadeOriginal;
               ControleValidadeMeses=_controleValidadeMesesOriginal;
               _controleValidadeMesesOriginalCommited=_controleValidadeMesesOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Observacao=_observacaoOriginal;
               _observacaoOriginalCommited=_observacaoOriginal;
               UtilizandoEstoqueSeguranca=_utilizandoEstoqueSegurancaOriginal;
               _utilizandoEstoqueSegurancaOriginalCommited=_utilizandoEstoqueSegurancaOriginal;
               UtilizandoEstoqueSegurancaData=_utilizandoEstoqueSegurancaDataOriginal;
               _utilizandoEstoqueSegurancaDataOriginalCommited=_utilizandoEstoqueSegurancaDataOriginal;
               EpiCa=_epiCaOriginal;
               _epiCaOriginalCommited=_epiCaOriginal;
               LoteMinimo=_loteMinimoOriginal;
               _loteMinimoOriginalCommited=_loteMinimoOriginal;
               if (_valueCollectionEpiFornecedorClassEpiLoaded) 
               {
                  CollectionEpiFornecedorClassEpi.Clear();
                  foreach(int item in _collectionEpiFornecedorClassEpiOriginal)
                  {
                    CollectionEpiFornecedorClassEpi.Add(Entidades.EpiFornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEpiFornecedorClassEpiRemovidos.Clear();
               }
               if (_valueCollectionEstoqueGavetaItemClassEpiLoaded) 
               {
                  CollectionEstoqueGavetaItemClassEpi.Clear();
                  foreach(int item in _collectionEstoqueGavetaItemClassEpiOriginal)
                  {
                    CollectionEstoqueGavetaItemClassEpi.Add(Entidades.EstoqueGavetaItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueGavetaItemClassEpiRemovidos.Clear();
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded) 
               {
                  CollectionFomularioRetiradaManualEstoqueClassEpi.Clear();
                  foreach(int item in _collectionFomularioRetiradaManualEstoqueClassEpiOriginal)
                  {
                    CollectionFomularioRetiradaManualEstoqueClassEpi.Add(Entidades.FomularioRetiradaManualEstoqueClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFomularioRetiradaManualEstoqueClassEpiRemovidos.Clear();
               }
               if (_valueCollectionFuncaoEpiClassEpiLoaded) 
               {
                  CollectionFuncaoEpiClassEpi.Clear();
                  foreach(int item in _collectionFuncaoEpiClassEpiOriginal)
                  {
                    CollectionFuncaoEpiClassEpi.Add(Entidades.FuncaoEpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFuncaoEpiClassEpiRemovidos.Clear();
               }
               if (_valueCollectionFuncionarioEpiClassEpiLoaded) 
               {
                  CollectionFuncionarioEpiClassEpi.Clear();
                  foreach(int item in _collectionFuncionarioEpiClassEpiOriginal)
                  {
                    CollectionFuncionarioEpiClassEpi.Add(Entidades.FuncionarioEpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFuncionarioEpiClassEpiRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraEpiClassEpiLoaded) 
               {
                  CollectionHistoricoCompraEpiClassEpi.Clear();
                  foreach(int item in _collectionHistoricoCompraEpiClassEpiOriginal)
                  {
                    CollectionHistoricoCompraEpiClassEpi.Add(Entidades.HistoricoCompraEpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraEpiClassEpiRemovidos.Clear();
               }
               if (_valueCollectionKanbanAcionamentoClassEpiLoaded) 
               {
                  CollectionKanbanAcionamentoClassEpi.Clear();
                  foreach(int item in _collectionKanbanAcionamentoClassEpiOriginal)
                  {
                    CollectionKanbanAcionamentoClassEpi.Add(Entidades.KanbanAcionamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionKanbanAcionamentoClassEpiRemovidos.Clear();
               }
               if (_valueCollectionLoteClassEpiLoaded) 
               {
                  CollectionLoteClassEpi.Clear();
                  foreach(int item in _collectionLoteClassEpiOriginal)
                  {
                    CollectionLoteClassEpi.Add(Entidades.LoteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLoteClassEpiRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoCompraItemClassEpiLoaded) 
               {
                  CollectionOrcamentoCompraItemClassEpi.Clear();
                  foreach(int item in _collectionOrcamentoCompraItemClassEpiOriginal)
                  {
                    CollectionOrcamentoCompraItemClassEpi.Add(Entidades.OrcamentoCompraItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoCompraItemClassEpiRemovidos.Clear();
               }
               if (_valueCollectionSolicitacaoCompraClassEpiLoaded) 
               {
                  CollectionSolicitacaoCompraClassEpi.Clear();
                  foreach(int item in _collectionSolicitacaoCompraClassEpiOriginal)
                  {
                    CollectionSolicitacaoCompraClassEpi.Add(Entidades.SolicitacaoCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionSolicitacaoCompraClassEpiRemovidos.Clear();
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
               if (_valueCollectionEpiFornecedorClassEpiLoaded) 
               {
                  if (_valueCollectionEpiFornecedorClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassEpiLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncaoEpiClassEpiLoaded) 
               {
                  if (_valueCollectionFuncaoEpiClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioEpiClassEpiLoaded) 
               {
                  if (_valueCollectionFuncionarioEpiClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassEpiLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassEpiLoaded) 
               {
                  if (_valueCollectionKanbanAcionamentoClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassEpiLoaded) 
               {
                  if (_valueCollectionLoteClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassEpiLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraItemClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassEpiLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassEpiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiFornecedorClassEpiLoaded) 
               {
                   tempRet = CollectionEpiFornecedorClassEpi.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueGavetaItemClassEpiLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassEpi.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassEpi.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncaoEpiClassEpiLoaded) 
               {
                   tempRet = CollectionFuncaoEpiClassEpi.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioEpiClassEpiLoaded) 
               {
                   tempRet = CollectionFuncionarioEpiClassEpi.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraEpiClassEpiLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassEpi.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionKanbanAcionamentoClassEpiLoaded) 
               {
                   tempRet = CollectionKanbanAcionamentoClassEpi.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassEpiLoaded) 
               {
                   tempRet = CollectionLoteClassEpi.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoCompraItemClassEpiLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraItemClassEpi.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassEpiLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassEpi.Any(item => item.IsDirty());
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
       if (_unidadeMedidaUsoOriginal!=null)
       {
          dirty = !_unidadeMedidaUsoOriginal.Equals(UnidadeMedidaUso);
       }
       else
       {
            dirty = UnidadeMedidaUso != null;
       }
      if (dirty) return true;
       dirty = _unidadesPorUnidadeCompraOriginal != UnidadesPorUnidadeCompra;
      if (dirty) return true;
       dirty = _leadTimeCompraOriginal != LeadTimeCompra;
      if (dirty) return true;
       dirty = _marcasHomologadasOriginal != MarcasHomologadas;
      if (dirty) return true;
       dirty = _impedirSolicitacaoAutomaticaOriginal != ImpedirSolicitacaoAutomatica;
      if (dirty) return true;
       dirty = _margemRecebimentoOriginal != MargemRecebimento;
      if (dirty) return true;
       dirty = _controleValidadeOriginal != ControleValidade;
      if (dirty) return true;
       dirty = _controleValidadeMesesOriginal != ControleValidadeMeses;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _observacaoOriginal != Observacao;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaOriginal != UtilizandoEstoqueSeguranca;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaDataOriginal != UtilizandoEstoqueSegurancaData;
      if (dirty) return true;
       if (_epiCaOriginal!=null)
       {
          dirty = !_epiCaOriginal.Equals(EpiCa);
       }
       else
       {
            dirty = EpiCa != null;
       }
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
               if (_valueCollectionEpiFornecedorClassEpiLoaded) 
               {
                  if (_valueCollectionEpiFornecedorClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassEpiLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncaoEpiClassEpiLoaded) 
               {
                  if (_valueCollectionFuncaoEpiClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioEpiClassEpiLoaded) 
               {
                  if (_valueCollectionFuncionarioEpiClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassEpiLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassEpiLoaded) 
               {
                  if (_valueCollectionKanbanAcionamentoClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassEpiLoaded) 
               {
                  if (_valueCollectionLoteClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassEpiLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraItemClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassEpiLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassEpiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiFornecedorClassEpiLoaded) 
               {
                   tempRet = CollectionEpiFornecedorClassEpi.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueGavetaItemClassEpiLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassEpi.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassEpi.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncaoEpiClassEpiLoaded) 
               {
                   tempRet = CollectionFuncaoEpiClassEpi.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioEpiClassEpiLoaded) 
               {
                   tempRet = CollectionFuncionarioEpiClassEpi.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraEpiClassEpiLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassEpi.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionKanbanAcionamentoClassEpiLoaded) 
               {
                   tempRet = CollectionKanbanAcionamentoClassEpi.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassEpiLoaded) 
               {
                   tempRet = CollectionLoteClassEpi.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoCompraItemClassEpiLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraItemClassEpi.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassEpiLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassEpi.Any(item => item.IsDirtyCommited());
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
       if (_unidadeMedidaUsoOriginalCommited!=null)
       {
          dirty = !_unidadeMedidaUsoOriginalCommited.Equals(UnidadeMedidaUso);
       }
       else
       {
            dirty = UnidadeMedidaUso != null;
       }
      if (dirty) return true;
       dirty = _unidadesPorUnidadeCompraOriginalCommited != UnidadesPorUnidadeCompra;
      if (dirty) return true;
       dirty = _leadTimeCompraOriginalCommited != LeadTimeCompra;
      if (dirty) return true;
       dirty = _marcasHomologadasOriginalCommited != MarcasHomologadas;
      if (dirty) return true;
       dirty = _impedirSolicitacaoAutomaticaOriginalCommited != ImpedirSolicitacaoAutomatica;
      if (dirty) return true;
       dirty = _margemRecebimentoOriginalCommited != MargemRecebimento;
      if (dirty) return true;
       dirty = _controleValidadeOriginalCommited != ControleValidade;
      if (dirty) return true;
       dirty = _controleValidadeMesesOriginalCommited != ControleValidadeMeses;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _observacaoOriginalCommited != Observacao;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaOriginalCommited != UtilizandoEstoqueSeguranca;
      if (dirty) return true;
       dirty = _utilizandoEstoqueSegurancaDataOriginalCommited != UtilizandoEstoqueSegurancaData;
      if (dirty) return true;
       if (_epiCaOriginalCommited!=null)
       {
          dirty = !_epiCaOriginalCommited.Equals(EpiCa);
       }
       else
       {
            dirty = EpiCa != null;
       }
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
               if (_valueCollectionEpiFornecedorClassEpiLoaded) 
               {
                  foreach(EpiFornecedorClass item in CollectionEpiFornecedorClassEpi)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassEpiLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassEpi)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassEpi)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFuncaoEpiClassEpiLoaded) 
               {
                  foreach(FuncaoEpiClass item in CollectionFuncaoEpiClassEpi)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFuncionarioEpiClassEpiLoaded) 
               {
                  foreach(FuncionarioEpiClass item in CollectionFuncionarioEpiClassEpi)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassEpiLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassEpi)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassEpiLoaded) 
               {
                  foreach(KanbanAcionamentoClass item in CollectionKanbanAcionamentoClassEpi)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionLoteClassEpiLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassEpi)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassEpiLoaded) 
               {
                  foreach(OrcamentoCompraItemClass item in CollectionOrcamentoCompraItemClassEpi)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassEpiLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassEpi)
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
             case "UnidadeMedidaUso":
                return this.UnidadeMedidaUso;
             case "UnidadesPorUnidadeCompra":
                return this.UnidadesPorUnidadeCompra;
             case "LeadTimeCompra":
                return this.LeadTimeCompra;
             case "MarcasHomologadas":
                return this.MarcasHomologadas;
             case "ImpedirSolicitacaoAutomatica":
                return this.ImpedirSolicitacaoAutomatica;
             case "MargemRecebimento":
                return this.MargemRecebimento;
             case "ControleValidade":
                return this.ControleValidade;
             case "ControleValidadeMeses":
                return this.ControleValidadeMeses;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Observacao":
                return this.Observacao;
             case "UtilizandoEstoqueSeguranca":
                return this.UtilizandoEstoqueSeguranca;
             case "UtilizandoEstoqueSegurancaData":
                return this.UtilizandoEstoqueSegurancaData;
             case "EpiCa":
                return this.EpiCa;
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
             if (UnidadeMedidaCompra!=null)
                UnidadeMedidaCompra.ChangeSingleConnection(newConnection);
             if (UnidadeMedidaUso!=null)
                UnidadeMedidaUso.ChangeSingleConnection(newConnection);
             if (EpiCa!=null)
                EpiCa.ChangeSingleConnection(newConnection);
               if (_valueCollectionEpiFornecedorClassEpiLoaded) 
               {
                  foreach(EpiFornecedorClass item in CollectionEpiFornecedorClassEpi)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassEpiLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassEpi)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassEpi)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFuncaoEpiClassEpiLoaded) 
               {
                  foreach(FuncaoEpiClass item in CollectionFuncaoEpiClassEpi)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFuncionarioEpiClassEpiLoaded) 
               {
                  foreach(FuncionarioEpiClass item in CollectionFuncionarioEpiClassEpi)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassEpiLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassEpi)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionKanbanAcionamentoClassEpiLoaded) 
               {
                  foreach(KanbanAcionamentoClass item in CollectionKanbanAcionamentoClassEpi)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionLoteClassEpiLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassEpi)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassEpiLoaded) 
               {
                  foreach(OrcamentoCompraItemClass item in CollectionOrcamentoCompraItemClassEpi)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassEpiLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassEpi)
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
                  command.CommandText += " COUNT(epi.id_epi) " ;
               }
               else
               {
               command.CommandText += "epi.id_epi, " ;
               command.CommandText += "epi.epi_identificacao, " ;
               command.CommandText += "epi.epi_descricao, " ;
               command.CommandText += "epi.epi_descricao_adicional, " ;
               command.CommandText += "epi.epi_lote_padrao, " ;
               command.CommandText += "epi.epi_verde, " ;
               command.CommandText += "epi.epi_amarelo, " ;
               command.CommandText += "epi.epi_vermelho, " ;
               command.CommandText += "epi.id_unidade_medida_compra, " ;
               command.CommandText += "epi.id_unidade_medida_uso, " ;
               command.CommandText += "epi.epi_unidades_por_unidade_compra, " ;
               command.CommandText += "epi.epi_lead_time_compra, " ;
               command.CommandText += "epi.epi_marcas_homologadas, " ;
               command.CommandText += "epi.epi_impedir_solicitacao_automatica, " ;
               command.CommandText += "epi.epi_margem_recebimento, " ;
               command.CommandText += "epi.epi_controle_validade, " ;
               command.CommandText += "epi.epi_controle_validade_meses, " ;
               command.CommandText += "epi.epi_ultima_revisao, " ;
               command.CommandText += "epi.epi_ultima_revisao_data, " ;
               command.CommandText += "epi.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "epi.entity_uid, " ;
               command.CommandText += "epi.version, " ;
               command.CommandText += "epi.epi_observacao, " ;
               command.CommandText += "epi.epi_utilizando_estoque_seguranca, " ;
               command.CommandText += "epi.epi_utilizando_estoque_seguranca_data, " ;
               command.CommandText += "epi.id_epi_ca, " ;
               command.CommandText += "epi.epi_lote_minimo " ;
               }
               command.CommandText += " FROM  epi ";
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
                        orderByClause += " , epi_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(epi_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = epi.id_acs_usuario_ultima_revisao ";
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
                     case "id_epi":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.id_epi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.id_epi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi.epi_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi.epi_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi.epi_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi.epi_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_descricao_adicional":
                     case "DescricaoAdicional":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi.epi_descricao_adicional " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi.epi_descricao_adicional) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_lote_padrao":
                     case "LotePadrao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_lote_padrao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_lote_padrao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_verde":
                     case "Verde":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_verde " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_verde) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_amarelo":
                     case "Amarelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_amarelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_amarelo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_vermelho":
                     case "Vermelho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_vermelho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_vermelho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_compra":
                     case "UnidadeMedidaCompra":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaCompra ON unidade_medida_UnidadeMedidaCompra.id_unidade_medida = epi.id_unidade_medida_compra ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_unidade_medida_uso":
                     case "UnidadeMedidaUso":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaUso ON unidade_medida_UnidadeMedidaUso.id_unidade_medida = epi.id_unidade_medida_uso ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedidaUso.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedidaUso.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_unidades_por_unidade_compra":
                     case "UnidadesPorUnidadeCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_unidades_por_unidade_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_unidades_por_unidade_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_lead_time_compra":
                     case "LeadTimeCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_lead_time_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_lead_time_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_marcas_homologadas":
                     case "MarcasHomologadas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi.epi_marcas_homologadas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi.epi_marcas_homologadas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_impedir_solicitacao_automatica":
                     case "ImpedirSolicitacaoAutomatica":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_impedir_solicitacao_automatica " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_impedir_solicitacao_automatica) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_margem_recebimento":
                     case "MargemRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_margem_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_margem_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_controle_validade":
                     case "ControleValidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_controle_validade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_controle_validade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_controle_validade_meses":
                     case "ControleValidadeMeses":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_controle_validade_meses " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_controle_validade_meses) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi.epi_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi.epi_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , epi.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , epi.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_observacao":
                     case "Observacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi.epi_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi.epi_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_utilizando_estoque_seguranca":
                     case "UtilizandoEstoqueSeguranca":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_utilizando_estoque_seguranca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_utilizando_estoque_seguranca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_utilizando_estoque_seguranca_data":
                     case "UtilizandoEstoqueSegurancaData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_utilizando_estoque_seguranca_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_utilizando_estoque_seguranca_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_epi_ca":
                     case "EpiCa":
                     command.CommandText += " LEFT JOIN epi_ca as epi_ca_EpiCa ON epi_ca_EpiCa.id_epi_ca = epi.id_epi_ca ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi_ca_EpiCa.eca_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi_ca_EpiCa.eca_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epi_lote_minimo":
                     case "LoteMinimo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi.epi_lote_minimo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi.epi_lote_minimo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("epi_identificacao")) 
                        {
                           whereClause += " OR UPPER(epi.epi_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi.epi_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("epi_descricao")) 
                        {
                           whereClause += " OR UPPER(epi.epi_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi.epi_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("epi_descricao_adicional")) 
                        {
                           whereClause += " OR UPPER(epi.epi_descricao_adicional) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi.epi_descricao_adicional) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("epi_marcas_homologadas")) 
                        {
                           whereClause += " OR UPPER(epi.epi_marcas_homologadas) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi.epi_marcas_homologadas) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("epi_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(epi.epi_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi.epi_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(epi.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("epi_observacao")) 
                        {
                           whereClause += " OR UPPER(epi.epi_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi.epi_observacao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_epi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.id_epi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.id_epi = :epi_ID_4601 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ID_4601", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "epi_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_identificacao LIKE :epi_Identificacao_5972 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Identificacao_5972", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "epi_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_descricao LIKE :epi_Descricao_3143 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Descricao_3143", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoAdicional" || parametro.FieldName == "epi_descricao_adicional")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_descricao_adicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_descricao_adicional LIKE :epi_DescricaoAdicional_2954 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_DescricaoAdicional_2954", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LotePadrao" || parametro.FieldName == "epi_lote_padrao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_lote_padrao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_lote_padrao = :epi_LotePadrao_6050 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_LotePadrao_6050", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Verde" || parametro.FieldName == "epi_verde")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_verde IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_verde = :epi_Verde_7465 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Verde_7465", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Amarelo" || parametro.FieldName == "epi_amarelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_amarelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_amarelo = :epi_Amarelo_337 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Amarelo_337", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Vermelho" || parametro.FieldName == "epi_vermelho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_vermelho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_vermelho = :epi_Vermelho_2595 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Vermelho_2595", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  epi.id_unidade_medida_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.id_unidade_medida_compra = :epi_UnidadeMedidaCompra_9465 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_UnidadeMedidaCompra_9465", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaUso" || parametro.FieldName == "id_unidade_medida_uso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.id_unidade_medida_uso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.id_unidade_medida_uso = :epi_UnidadeMedidaUso_7444 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_UnidadeMedidaUso_7444", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadesPorUnidadeCompra" || parametro.FieldName == "epi_unidades_por_unidade_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_unidades_por_unidade_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_unidades_por_unidade_compra = :epi_UnidadesPorUnidadeCompra_8706 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_UnidadesPorUnidadeCompra_8706", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LeadTimeCompra" || parametro.FieldName == "epi_lead_time_compra")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_lead_time_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_lead_time_compra = :epi_LeadTimeCompra_6966 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_LeadTimeCompra_6966", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MarcasHomologadas" || parametro.FieldName == "epi_marcas_homologadas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_marcas_homologadas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_marcas_homologadas LIKE :epi_MarcasHomologadas_3905 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_MarcasHomologadas_3905", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpedirSolicitacaoAutomatica" || parametro.FieldName == "epi_impedir_solicitacao_automatica")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_impedir_solicitacao_automatica IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_impedir_solicitacao_automatica = :epi_ImpedirSolicitacaoAutomatica_4273 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ImpedirSolicitacaoAutomatica_4273", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MargemRecebimento" || parametro.FieldName == "epi_margem_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_margem_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_margem_recebimento = :epi_MargemRecebimento_8759 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_MargemRecebimento_8759", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ControleValidade" || parametro.FieldName == "epi_controle_validade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_controle_validade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_controle_validade = :epi_ControleValidade_7652 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ControleValidade_7652", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ControleValidadeMeses" || parametro.FieldName == "epi_controle_validade_meses")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_controle_validade_meses IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_controle_validade_meses = :epi_ControleValidadeMeses_6111 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ControleValidadeMeses_6111", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "epi_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_ultima_revisao LIKE :epi_UltimaRevisao_7180 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_UltimaRevisao_7180", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "epi_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_ultima_revisao_data = :epi_UltimaRevisaoData_2124 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_UltimaRevisaoData_2124", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  epi.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.id_acs_usuario_ultima_revisao = :epi_UltimaRevisaoUsuario_3817 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_UltimaRevisaoUsuario_3817", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  epi.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.entity_uid LIKE :epi_EntityUid_5466 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_EntityUid_5466", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  epi.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.version = :epi_Version_4661 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Version_4661", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacao" || parametro.FieldName == "epi_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_observacao LIKE :epi_Observacao_892 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Observacao_892", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizandoEstoqueSeguranca" || parametro.FieldName == "epi_utilizando_estoque_seguranca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EstoqueSeguranca)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EstoqueSeguranca");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_utilizando_estoque_seguranca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_utilizando_estoque_seguranca = :epi_UtilizandoEstoqueSeguranca_3697 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_UtilizandoEstoqueSeguranca_3697", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizandoEstoqueSegurancaData" || parametro.FieldName == "epi_utilizando_estoque_seguranca_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_utilizando_estoque_seguranca_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_utilizando_estoque_seguranca_data = :epi_UtilizandoEstoqueSegurancaData_2146 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_UtilizandoEstoqueSegurancaData_2146", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EpiCa" || parametro.FieldName == "id_epi_ca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EpiCaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EpiCaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.id_epi_ca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.id_epi_ca = :epi_EpiCa_3749 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_EpiCa_3749", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LoteMinimo" || parametro.FieldName == "epi_lote_minimo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_lote_minimo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_lote_minimo = :epi_LoteMinimo_6311 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_LoteMinimo_6311", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  epi.epi_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_identificacao LIKE :epi_Identificacao_8729 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Identificacao_8729", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  epi.epi_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_descricao LIKE :epi_Descricao_1360 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Descricao_1360", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  epi.epi_descricao_adicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_descricao_adicional LIKE :epi_DescricaoAdicional_1200 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_DescricaoAdicional_1200", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  epi.epi_marcas_homologadas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_marcas_homologadas LIKE :epi_MarcasHomologadas_3246 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_MarcasHomologadas_3246", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  epi.epi_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_ultima_revisao LIKE :epi_UltimaRevisao_8647 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_UltimaRevisao_8647", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  epi.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.entity_uid LIKE :epi_EntityUid_4306 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_EntityUid_4306", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoExato" || parametro.FieldName == "ObservacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi.epi_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi.epi_observacao LIKE :epi_Observacao_3650 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_Observacao_3650", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EpiClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EpiClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EpiClass), Convert.ToInt32(read["id_epi"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EpiClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_epi"]);
                     entidade.Identificacao = (read["epi_identificacao"] != DBNull.Value ? read["epi_identificacao"].ToString() : null);
                     entidade.Descricao = (read["epi_descricao"] != DBNull.Value ? read["epi_descricao"].ToString() : null);
                     entidade.DescricaoAdicional = (read["epi_descricao_adicional"] != DBNull.Value ? read["epi_descricao_adicional"].ToString() : null);
                     entidade.LotePadrao = (double)read["epi_lote_padrao"];
                     entidade.Verde = (double)read["epi_verde"];
                     entidade.Amarelo = (double)read["epi_amarelo"];
                     entidade.Vermelho = (double)read["epi_vermelho"];
                     if (read["id_unidade_medida_compra"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaCompra = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_compra"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaCompra = null ;
                     }
                     if (read["id_unidade_medida_uso"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaUso = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_uso"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaUso = null ;
                     }
                     entidade.UnidadesPorUnidadeCompra = (double)read["epi_unidades_por_unidade_compra"];
                     entidade.LeadTimeCompra = (int)read["epi_lead_time_compra"];
                     entidade.MarcasHomologadas = (read["epi_marcas_homologadas"] != DBNull.Value ? read["epi_marcas_homologadas"].ToString() : null);
                     entidade.ImpedirSolicitacaoAutomatica = Convert.ToBoolean(Convert.ToInt16(read["epi_impedir_solicitacao_automatica"]));
                     entidade.MargemRecebimento = read["epi_margem_recebimento"] as double?;
                     entidade.ControleValidade = Convert.ToBoolean(Convert.ToInt16(read["epi_controle_validade"]));
                     entidade.ControleValidadeMeses = read["epi_controle_validade_meses"] as int?;
                     entidade.UltimaRevisao = (read["epi_ultima_revisao"] != DBNull.Value ? read["epi_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["epi_ultima_revisao_data"] as DateTime?;
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
                     entidade.Observacao = (read["epi_observacao"] != DBNull.Value ? read["epi_observacao"].ToString() : null);
                     entidade.UtilizandoEstoqueSeguranca = (EstoqueSeguranca) (read["epi_utilizando_estoque_seguranca"] != DBNull.Value ? Enum.ToObject(typeof(EstoqueSeguranca), read["epi_utilizando_estoque_seguranca"]) : null);
                     entidade.UtilizandoEstoqueSegurancaData = read["epi_utilizando_estoque_seguranca_data"] as DateTime?;
                     if (read["id_epi_ca"] != DBNull.Value)
                     {
                        entidade.EpiCa = (BibliotecaEntidades.Entidades.EpiCaClass)BibliotecaEntidades.Entidades.EpiCaClass.GetEntidade(Convert.ToInt32(read["id_epi_ca"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EpiCa = null ;
                     }
                     entidade.LoteMinimo = (double)read["epi_lote_minimo"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EpiClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
