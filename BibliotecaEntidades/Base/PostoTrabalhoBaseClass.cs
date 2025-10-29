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
     [Table("posto_trabalho","pos")]
     public class PostoTrabalhoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PostoTrabalhoClass";
protected const string ErroDelete = "Erro ao excluir o PostoTrabalhoClass  ";
protected const string ErroSave = "Erro ao salvar o PostoTrabalhoClass.";
protected const string ErroCollectionNotificacaoDesvioClassPostoTrabalho = "Erro ao carregar a coleção de NotificacaoDesvioClass.";
protected const string ErroCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoClass.";
protected const string ErroCollectionOrdemProducaoRecursoClassPostoTrabalho = "Erro ao carregar a coleção de OrdemProducaoRecursoClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPlanoCorteItemClassPostoTrabalhoCorte = "Erro ao carregar a coleção de PlanoCorteItemClass.";
protected const string ErroCollectionProdutoMaterialClassPostoTrabalhoCorte = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected const string ErroCollectionProdutoPostoTrabalhoClassPostoTrabalho = "Erro ao carregar a coleção de ProdutoPostoTrabalhoClass.";
protected const string ErroCollectionRecursoClassPostoTrabalho = "Erro ao carregar a coleção de RecursoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do PostoTrabalhoClass.";
protected const string MensagemUtilizadoCollectionNotificacaoDesvioClassPostoTrabalho =  "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes NotificacaoDesvioClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho =  "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoRecursoClassPostoTrabalho =  "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes OrdemProducaoRecursoClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte =  "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemClassPostoTrabalhoCorte =  "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
protected const string MensagemUtilizadoCollectionProdutoMaterialClassPostoTrabalhoCorte =  "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected const string MensagemUtilizadoCollectionProdutoPostoTrabalhoClassPostoTrabalho =  "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes ProdutoPostoTrabalhoClass:";
protected const string MensagemUtilizadoCollectionRecursoClassPostoTrabalho =  "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes RecursoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PostoTrabalhoClass está sendo utilizada.";
#endregion
       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("pos_codigo")]
        public virtual string Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("pos_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected string _operacaoPostoOriginal{get;private set;}
       private string _operacaoPostoOriginalCommited{get; set;}
        private string _valueOperacaoPosto;
         [Column("pos_operacao_posto")]
        public virtual string OperacaoPosto
         { 
            get { return this._valueOperacaoPosto; } 
            set 
            { 
                if (this._valueOperacaoPosto == value)return;
                 this._valueOperacaoPosto = value; 
            } 
        } 

       protected bool _rastreamentoOriginal{get;private set;}
       private bool _rastreamentoOriginalCommited{get; set;}
        private bool _valueRastreamento;
         [Column("pos_rastreamento")]
        public virtual bool Rastreamento
         { 
            get { return this._valueRastreamento; } 
            set 
            { 
                if (this._valueRastreamento == value)return;
                 this._valueRastreamento = value; 
            } 
        } 

       protected PostoTrabalhoAcompanhamento _acompanhamentoOriginal{get;private set;}
       private PostoTrabalhoAcompanhamento _acompanhamentoOriginalCommited{get; set;}
        private PostoTrabalhoAcompanhamento _valueAcompanhamento;
         [Column("pos_acompanhamento")]
        public virtual PostoTrabalhoAcompanhamento Acompanhamento
         { 
            get { return this._valueAcompanhamento; } 
            set 
            { 
                if (this._valueAcompanhamento == value)return;
                 this._valueAcompanhamento = value; 
            } 
        } 

        public bool Acompanhamento_SemAcompanhamento
         { 
            get { return this._valueAcompanhamento == BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.SemAcompanhamento; } 
            set { if (value) this._valueAcompanhamento = BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.SemAcompanhamento; }
         } 

        public bool Acompanhamento_UmTempo
         { 
            get { return this._valueAcompanhamento == BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.UmTempo; } 
            set { if (value) this._valueAcompanhamento = BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.UmTempo; }
         } 

        public bool Acompanhamento_DoisTempos
         { 
            get { return this._valueAcompanhamento == BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.DoisTempos; } 
            set { if (value) this._valueAcompanhamento = BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.DoisTempos; }
         } 

        public bool Acompanhamento_TresTempos
         { 
            get { return this._valueAcompanhamento == BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.TresTempos; } 
            set { if (value) this._valueAcompanhamento = BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.TresTempos; }
         } 

        public bool Acompanhamento_UmTempoComQtd
         { 
            get { return this._valueAcompanhamento == BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.UmTempoComQtd; } 
            set { if (value) this._valueAcompanhamento = BibliotecaEntidades.Base.PostoTrabalhoAcompanhamento.UmTempoComQtd; }
         } 

       protected bool _produtivoOriginal{get;private set;}
       private bool _produtivoOriginalCommited{get; set;}
        private bool _valueProdutivo;
         [Column("pos_produtivo")]
        public virtual bool Produtivo
         { 
            get { return this._valueProdutivo; } 
            set 
            { 
                if (this._valueProdutivo == value)return;
                 this._valueProdutivo = value; 
            } 
        } 

       protected bool _conferenciaSequencialOriginal{get;private set;}
       private bool _conferenciaSequencialOriginalCommited{get; set;}
        private bool _valueConferenciaSequencial;
         [Column("pos_conferencia_sequencial")]
        public virtual bool ConferenciaSequencial
         { 
            get { return this._valueConferenciaSequencial; } 
            set 
            { 
                if (this._valueConferenciaSequencial == value)return;
                 this._valueConferenciaSequencial = value; 
            } 
        } 

       protected bool _rastreamentoMaterialOriginal{get;private set;}
       private bool _rastreamentoMaterialOriginalCommited{get; set;}
        private bool _valueRastreamentoMaterial;
         [Column("pos_rastreamento_material")]
        public virtual bool RastreamentoMaterial
         { 
            get { return this._valueRastreamentoMaterial; } 
            set 
            { 
                if (this._valueRastreamentoMaterial == value)return;
                 this._valueRastreamentoMaterial = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.AgrupadorPostoTrabalhoClass _agrupadorPostoTrabalhoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.AgrupadorPostoTrabalhoClass _agrupadorPostoTrabalhoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.AgrupadorPostoTrabalhoClass _valueAgrupadorPostoTrabalho;
        [Column("id_agrupador_posto_trabalho", "agrupador_posto_trabalho", "id_agrupador_posto_trabalho")]
       public virtual BibliotecaEntidades.Entidades.AgrupadorPostoTrabalhoClass AgrupadorPostoTrabalho
        { 
           get {                 return this._valueAgrupadorPostoTrabalho; } 
           set 
           { 
                if (this._valueAgrupadorPostoTrabalho == value)return;
                 this._valueAgrupadorPostoTrabalho = value; 
           } 
       } 

       protected bool _postoExternoOriginal{get;private set;}
       private bool _postoExternoOriginalCommited{get; set;}
        private bool _valuePostoExterno;
         [Column("pos_posto_externo")]
        public virtual bool PostoExterno
         { 
            get { return this._valuePostoExterno; } 
            set 
            { 
                if (this._valuePostoExterno == value)return;
                 this._valuePostoExterno = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OperacaoClass _operacaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _operacaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _valueOperacao;
        [Column("id_operacao", "operacao", "id_operacao")]
       public virtual BibliotecaEntidades.Entidades.OperacaoClass Operacao
        { 
           get {                 return this._valueOperacao; } 
           set 
           { 
                if (this._valueOperacao == value)return;
                 this._valueOperacao = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.OperacaoCompletaClass _operacaoCompletaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OperacaoCompletaClass _operacaoCompletaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OperacaoCompletaClass _valueOperacaoCompleta;
        [Column("id_operacao_completa", "operacao_completa", "id_operacao_completa")]
       public virtual BibliotecaEntidades.Entidades.OperacaoCompletaClass OperacaoCompleta
        { 
           get {                 return this._valueOperacaoCompleta; } 
           set 
           { 
                if (this._valueOperacaoCompleta == value)return;
                 this._valueOperacaoCompleta = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.FornecedorClass _fornecedorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FornecedorClass _fornecedorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FornecedorClass _valueFornecedor;
        [Column("id_fornecedor", "fornecedor", "id_fornecedor")]
       public virtual BibliotecaEntidades.Entidades.FornecedorClass Fornecedor
        { 
           get {                 return this._valueFornecedor; } 
           set 
           { 
                if (this._valueFornecedor == value)return;
                 this._valueFornecedor = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.TransporteClass _transporteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.TransporteClass _transporteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.TransporteClass _valueTransporte;
        [Column("id_transporte", "transporte", "id_transporte")]
       public virtual BibliotecaEntidades.Entidades.TransporteClass Transporte
        { 
           get {                 return this._valueTransporte; } 
           set 
           { 
                if (this._valueTransporte == value)return;
                 this._valueTransporte = value; 
           } 
       } 

       protected string _corDestaqueEvolucaoOriginal{get;private set;}
       private string _corDestaqueEvolucaoOriginalCommited{get; set;}
        private string _valueCorDestaqueEvolucao;
         [Column("pos_cor_destaque_evolucao")]
        public virtual string CorDestaqueEvolucao
         { 
            get { return this._valueCorDestaqueEvolucao; } 
            set 
            { 
                if (this._valueCorDestaqueEvolucao == value)return;
                 this._valueCorDestaqueEvolucao = value; 
            } 
        } 

       protected double _taxaHoraOriginal{get;private set;}
       private double _taxaHoraOriginalCommited{get; set;}
        private double _valueTaxaHora;
         [Column("pos_taxa_hora")]
        public virtual double TaxaHora
         { 
            get { return this._valueTaxaHora; } 
            set 
            { 
                if (this._valueTaxaHora == value)return;
                 this._valueTaxaHora = value; 
            } 
        } 

       private List<long> _collectionNotificacaoDesvioClassPostoTrabalhoOriginal;
       private List<Entidades.NotificacaoDesvioClass > _collectionNotificacaoDesvioClassPostoTrabalhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotificacaoDesvioClassPostoTrabalhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotificacaoDesvioClassPostoTrabalhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NotificacaoDesvioClass> _valueCollectionNotificacaoDesvioClassPostoTrabalho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NotificacaoDesvioClass> CollectionNotificacaoDesvioClassPostoTrabalho 
       { 
           get { if(!_valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded && !this.DisableLoadCollection){this.LoadCollectionNotificacaoDesvioClassPostoTrabalho();}
return this._valueCollectionNotificacaoDesvioClassPostoTrabalho; } 
           set 
           { 
               this._valueCollectionNotificacaoDesvioClassPostoTrabalho = value; 
               this._valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoOriginal;
       private List<Entidades.OrdemProducaoPostoTrabalhoClass > _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoPostoTrabalhoClass> _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoPostoTrabalhoClass> CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho 
       { 
           get { if(!_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho();}
return this._valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho; } 
           set 
           { 
               this._valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho = value; 
               this._valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoRecursoClassPostoTrabalhoOriginal;
       private List<Entidades.OrdemProducaoRecursoClass > _collectionOrdemProducaoRecursoClassPostoTrabalhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoRecursoClass> _valueCollectionOrdemProducaoRecursoClassPostoTrabalho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoRecursoClass> CollectionOrdemProducaoRecursoClassPostoTrabalho 
       { 
           get { if(!_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoRecursoClassPostoTrabalho();}
return this._valueCollectionOrdemProducaoRecursoClassPostoTrabalho; } 
           set 
           { 
               this._valueCollectionOrdemProducaoRecursoClassPostoTrabalho = value; 
               this._valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteOriginal;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemClassPostoTrabalhoCorteOriginal;
       private List<Entidades.PlanoCorteItemClass > _collectionPlanoCorteItemClassPostoTrabalhoCorteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemClass> _valueCollectionPlanoCorteItemClassPostoTrabalhoCorte { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemClass> CollectionPlanoCorteItemClassPostoTrabalhoCorte 
       { 
           get { if(!_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemClassPostoTrabalhoCorte();}
return this._valueCollectionPlanoCorteItemClassPostoTrabalhoCorte; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemClassPostoTrabalhoCorte = value; 
               this._valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoMaterialClassPostoTrabalhoCorteOriginal;
       private List<Entidades.ProdutoMaterialClass > _collectionProdutoMaterialClassPostoTrabalhoCorteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassPostoTrabalhoCorteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassPostoTrabalhoCorteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoMaterialClass> _valueCollectionProdutoMaterialClassPostoTrabalhoCorte { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoMaterialClass> CollectionProdutoMaterialClassPostoTrabalhoCorte 
       { 
           get { if(!_valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoMaterialClassPostoTrabalhoCorte();}
return this._valueCollectionProdutoMaterialClassPostoTrabalhoCorte; } 
           set 
           { 
               this._valueCollectionProdutoMaterialClassPostoTrabalhoCorte = value; 
               this._valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoPostoTrabalhoClassPostoTrabalhoOriginal;
       private List<Entidades.ProdutoPostoTrabalhoClass > _collectionProdutoPostoTrabalhoClassPostoTrabalhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoPostoTrabalhoClass> _valueCollectionProdutoPostoTrabalhoClassPostoTrabalho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoPostoTrabalhoClass> CollectionProdutoPostoTrabalhoClassPostoTrabalho 
       { 
           get { if(!_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoPostoTrabalhoClassPostoTrabalho();}
return this._valueCollectionProdutoPostoTrabalhoClassPostoTrabalho; } 
           set 
           { 
               this._valueCollectionProdutoPostoTrabalhoClassPostoTrabalho = value; 
               this._valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded = true; 
           } 
       } 

       private List<long> _collectionRecursoClassPostoTrabalhoOriginal;
       private List<Entidades.RecursoClass > _collectionRecursoClassPostoTrabalhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRecursoClassPostoTrabalhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRecursoClassPostoTrabalhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRecursoClassPostoTrabalhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.RecursoClass> _valueCollectionRecursoClassPostoTrabalho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.RecursoClass> CollectionRecursoClassPostoTrabalho 
       { 
           get { if(!_valueCollectionRecursoClassPostoTrabalhoLoaded && !this.DisableLoadCollection){this.LoadCollectionRecursoClassPostoTrabalho();}
return this._valueCollectionRecursoClassPostoTrabalho; } 
           set 
           { 
               this._valueCollectionRecursoClassPostoTrabalho = value; 
               this._valueCollectionRecursoClassPostoTrabalhoLoaded = true; 
           } 
       } 

        public PostoTrabalhoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Rastreamento = false;
           this.Acompanhamento = (PostoTrabalhoAcompanhamento)0;
           this.Produtivo = false;
           this.ConferenciaSequencial = false;
           this.RastreamentoMaterial = false;
           this.PostoExterno = false;
           this.TaxaHora = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static PostoTrabalhoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PostoTrabalhoClass) GetEntity(typeof(PostoTrabalhoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionNotificacaoDesvioClassPostoTrabalhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNotificacaoDesvioClassPostoTrabalhoChanged = true;
                  _valueCollectionNotificacaoDesvioClassPostoTrabalhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNotificacaoDesvioClassPostoTrabalhoChanged = true; 
                  _valueCollectionNotificacaoDesvioClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.NotificacaoDesvioClass item in e.OldItems) 
                 { 
                     _collectionNotificacaoDesvioClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNotificacaoDesvioClassPostoTrabalhoChanged = true; 
                  _valueCollectionNotificacaoDesvioClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.NotificacaoDesvioClass item in _valueCollectionNotificacaoDesvioClassPostoTrabalho) 
                 { 
                     _collectionNotificacaoDesvioClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNotificacaoDesvioClassPostoTrabalho()
         {
            try
            {
                 ObservableCollection<Entidades.NotificacaoDesvioClass> oc;
                _valueCollectionNotificacaoDesvioClassPostoTrabalhoChanged = false;
                 _valueCollectionNotificacaoDesvioClassPostoTrabalhoCommitedChanged = false;
                _collectionNotificacaoDesvioClassPostoTrabalhoRemovidos = new List<Entidades.NotificacaoDesvioClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NotificacaoDesvioClass>();
                }
                else{ 
                   Entidades.NotificacaoDesvioClass search = new Entidades.NotificacaoDesvioClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NotificacaoDesvioClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PostoTrabalho", this),                     }                       ).Cast<Entidades.NotificacaoDesvioClass>().ToList());
                 }
                 _valueCollectionNotificacaoDesvioClassPostoTrabalho = new BindingList<Entidades.NotificacaoDesvioClass>(oc); 
                 _collectionNotificacaoDesvioClassPostoTrabalhoOriginal= (from a in _valueCollectionNotificacaoDesvioClassPostoTrabalho select a.ID).ToList();
                 _valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded = true;
                 oc.CollectionChanged += CollectionNotificacaoDesvioClassPostoTrabalhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNotificacaoDesvioClassPostoTrabalho+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoChanged = true;
                  _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoClass item in _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoClass> oc;
                _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoChanged = false;
                 _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoCommitedChanged = false;
                _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoPostoTrabalhoClass search = new Entidades.OrdemProducaoPostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PostoTrabalho", this),                     }                       ).Cast<Entidades.OrdemProducaoPostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho = new BindingList<Entidades.OrdemProducaoPostoTrabalhoClass>(oc); 
                 _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho select a.ID).ToList();
                 _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoRecursoClassPostoTrabalhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoChanged = true;
                  _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoChanged = true; 
                  _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoRecursoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoRecursoClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoChanged = true; 
                  _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoRecursoClass item in _valueCollectionOrdemProducaoRecursoClassPostoTrabalho) 
                 { 
                     _collectionOrdemProducaoRecursoClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoRecursoClassPostoTrabalho()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoRecursoClass> oc;
                _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoChanged = false;
                 _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoCommitedChanged = false;
                _collectionOrdemProducaoRecursoClassPostoTrabalhoRemovidos = new List<Entidades.OrdemProducaoRecursoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoRecursoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoRecursoClass search = new Entidades.OrdemProducaoRecursoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoRecursoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PostoTrabalho", this),                     }                       ).Cast<Entidades.OrdemProducaoRecursoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoRecursoClassPostoTrabalho = new BindingList<Entidades.OrdemProducaoRecursoClass>(oc); 
                 _collectionOrdemProducaoRecursoClassPostoTrabalhoOriginal= (from a in _valueCollectionOrdemProducaoRecursoClassPostoTrabalho select a.ID).ToList();
                 _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoRecursoClassPostoTrabalhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoRecursoClassPostoTrabalho+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteChanged = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteChanged = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteCommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PostoTrabalhoCorte", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemClassPostoTrabalhoCorteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteChanged = true;
                  _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteChanged = true; 
                  _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemClassPostoTrabalhoCorteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteChanged = true; 
                  _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in _valueCollectionPlanoCorteItemClassPostoTrabalhoCorte) 
                 { 
                     _collectionPlanoCorteItemClassPostoTrabalhoCorteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemClassPostoTrabalhoCorte()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemClass> oc;
                _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteChanged = false;
                 _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteCommitedChanged = false;
                _collectionPlanoCorteItemClassPostoTrabalhoCorteRemovidos = new List<Entidades.PlanoCorteItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemClass search = new Entidades.PlanoCorteItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PostoTrabalhoCorte", this)                    }                       ).Cast<Entidades.PlanoCorteItemClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemClassPostoTrabalhoCorte = new BindingList<Entidades.PlanoCorteItemClass>(oc); 
                 _collectionPlanoCorteItemClassPostoTrabalhoCorteOriginal= (from a in _valueCollectionPlanoCorteItemClassPostoTrabalhoCorte select a.ID).ToList();
                 _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemClassPostoTrabalhoCorteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemClassPostoTrabalhoCorte+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoMaterialClassPostoTrabalhoCorteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoMaterialClassPostoTrabalhoCorteChanged = true;
                  _valueCollectionProdutoMaterialClassPostoTrabalhoCorteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoMaterialClassPostoTrabalhoCorteChanged = true; 
                  _valueCollectionProdutoMaterialClassPostoTrabalhoCorteCommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in e.OldItems) 
                 { 
                     _collectionProdutoMaterialClassPostoTrabalhoCorteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoMaterialClassPostoTrabalhoCorteChanged = true; 
                  _valueCollectionProdutoMaterialClassPostoTrabalhoCorteCommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in _valueCollectionProdutoMaterialClassPostoTrabalhoCorte) 
                 { 
                     _collectionProdutoMaterialClassPostoTrabalhoCorteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoMaterialClassPostoTrabalhoCorte()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoMaterialClass> oc;
                _valueCollectionProdutoMaterialClassPostoTrabalhoCorteChanged = false;
                 _valueCollectionProdutoMaterialClassPostoTrabalhoCorteCommitedChanged = false;
                _collectionProdutoMaterialClassPostoTrabalhoCorteRemovidos = new List<Entidades.ProdutoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoMaterialClass>();
                }
                else{ 
                   Entidades.ProdutoMaterialClass search = new Entidades.ProdutoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PostoTrabalhoCorte", this),                     }                       ).Cast<Entidades.ProdutoMaterialClass>().ToList());
                 }
                 _valueCollectionProdutoMaterialClassPostoTrabalhoCorte = new BindingList<Entidades.ProdutoMaterialClass>(oc); 
                 _collectionProdutoMaterialClassPostoTrabalhoCorteOriginal= (from a in _valueCollectionProdutoMaterialClassPostoTrabalhoCorte select a.ID).ToList();
                 _valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded = true;
                 oc.CollectionChanged += CollectionProdutoMaterialClassPostoTrabalhoCorteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoMaterialClassPostoTrabalhoCorte+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoPostoTrabalhoClassPostoTrabalhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoChanged = true;
                  _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoChanged = true; 
                  _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.ProdutoPostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionProdutoPostoTrabalhoClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoChanged = true; 
                  _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.ProdutoPostoTrabalhoClass item in _valueCollectionProdutoPostoTrabalhoClassPostoTrabalho) 
                 { 
                     _collectionProdutoPostoTrabalhoClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoPostoTrabalhoClassPostoTrabalho()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoPostoTrabalhoClass> oc;
                _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoChanged = false;
                 _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoCommitedChanged = false;
                _collectionProdutoPostoTrabalhoClassPostoTrabalhoRemovidos = new List<Entidades.ProdutoPostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoPostoTrabalhoClass>();
                }
                else{ 
                   Entidades.ProdutoPostoTrabalhoClass search = new Entidades.ProdutoPostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoPostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PostoTrabalho", this),                     }                       ).Cast<Entidades.ProdutoPostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionProdutoPostoTrabalhoClassPostoTrabalho = new BindingList<Entidades.ProdutoPostoTrabalhoClass>(oc); 
                 _collectionProdutoPostoTrabalhoClassPostoTrabalhoOriginal= (from a in _valueCollectionProdutoPostoTrabalhoClassPostoTrabalho select a.ID).ToList();
                 _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoPostoTrabalhoClassPostoTrabalhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoPostoTrabalhoClassPostoTrabalho+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionRecursoClassPostoTrabalhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionRecursoClassPostoTrabalhoChanged = true;
                  _valueCollectionRecursoClassPostoTrabalhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionRecursoClassPostoTrabalhoChanged = true; 
                  _valueCollectionRecursoClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.RecursoClass item in e.OldItems) 
                 { 
                     _collectionRecursoClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionRecursoClassPostoTrabalhoChanged = true; 
                  _valueCollectionRecursoClassPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.RecursoClass item in _valueCollectionRecursoClassPostoTrabalho) 
                 { 
                     _collectionRecursoClassPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionRecursoClassPostoTrabalho()
         {
            try
            {
                 ObservableCollection<Entidades.RecursoClass> oc;
                _valueCollectionRecursoClassPostoTrabalhoChanged = false;
                 _valueCollectionRecursoClassPostoTrabalhoCommitedChanged = false;
                _collectionRecursoClassPostoTrabalhoRemovidos = new List<Entidades.RecursoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.RecursoClass>();
                }
                else{ 
                   Entidades.RecursoClass search = new Entidades.RecursoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.RecursoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PostoTrabalho", this),                     }                       ).Cast<Entidades.RecursoClass>().ToList());
                 }
                 _valueCollectionRecursoClassPostoTrabalho = new BindingList<Entidades.RecursoClass>(oc); 
                 _collectionRecursoClassPostoTrabalhoOriginal= (from a in _valueCollectionRecursoClassPostoTrabalho select a.ID).ToList();
                 _valueCollectionRecursoClassPostoTrabalhoLoaded = true;
                 oc.CollectionChanged += CollectionRecursoClassPostoTrabalhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionRecursoClassPostoTrabalho+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

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
                    "  public.posto_trabalho  " +
                    "WHERE " +
                    "  id_posto_trabalho = :id";
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
                        "  public.posto_trabalho   " +
                        "SET  " + 
                        "  pos_codigo = :pos_codigo, " + 
                        "  pos_nome = :pos_nome, " + 
                        "  pos_operacao_posto = :pos_operacao_posto, " + 
                        "  pos_rastreamento = :pos_rastreamento, " + 
                        "  pos_acompanhamento = :pos_acompanhamento, " + 
                        "  pos_produtivo = :pos_produtivo, " + 
                        "  pos_conferencia_sequencial = :pos_conferencia_sequencial, " + 
                        "  pos_ultima_revisao = :pos_ultima_revisao, " + 
                        "  pos_ultima_revisao_data = :pos_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  pos_rastreamento_material = :pos_rastreamento_material, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_agrupador_posto_trabalho = :id_agrupador_posto_trabalho, " + 
                        "  pos_posto_externo = :pos_posto_externo, " + 
                        "  id_operacao = :id_operacao, " + 
                        "  id_operacao_completa = :id_operacao_completa, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  id_transporte = :id_transporte, " + 
                        "  pos_cor_destaque_evolucao = :pos_cor_destaque_evolucao, " + 
                        "  pos_taxa_hora = :pos_taxa_hora "+
                        "WHERE  " +
                        "  id_posto_trabalho = :id " +
                        "RETURNING id_posto_trabalho;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.posto_trabalho " +
                        "( " +
                        "  pos_codigo , " + 
                        "  pos_nome , " + 
                        "  pos_operacao_posto , " + 
                        "  pos_rastreamento , " + 
                        "  pos_acompanhamento , " + 
                        "  pos_produtivo , " + 
                        "  pos_conferencia_sequencial , " + 
                        "  pos_ultima_revisao , " + 
                        "  pos_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  pos_rastreamento_material , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_agrupador_posto_trabalho , " + 
                        "  pos_posto_externo , " + 
                        "  id_operacao , " + 
                        "  id_operacao_completa , " + 
                        "  id_fornecedor , " + 
                        "  id_transporte , " + 
                        "  pos_cor_destaque_evolucao , " + 
                        "  pos_taxa_hora  "+
                        ")  " +
                        "VALUES ( " +
                        "  :pos_codigo , " + 
                        "  :pos_nome , " + 
                        "  :pos_operacao_posto , " + 
                        "  :pos_rastreamento , " + 
                        "  :pos_acompanhamento , " + 
                        "  :pos_produtivo , " + 
                        "  :pos_conferencia_sequencial , " + 
                        "  :pos_ultima_revisao , " + 
                        "  :pos_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :pos_rastreamento_material , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_agrupador_posto_trabalho , " + 
                        "  :pos_posto_externo , " + 
                        "  :id_operacao , " + 
                        "  :id_operacao_completa , " + 
                        "  :id_fornecedor , " + 
                        "  :id_transporte , " + 
                        "  :pos_cor_destaque_evolucao , " + 
                        "  :pos_taxa_hora  "+
                        ")RETURNING id_posto_trabalho;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_operacao_posto", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OperacaoPosto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_rastreamento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Rastreamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_acompanhamento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Acompanhamento);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_produtivo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Produtivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_conferencia_sequencial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConferenciaSequencial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_rastreamento_material", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RastreamentoMaterial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_agrupador_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AgrupadorPostoTrabalho==null ? (object) DBNull.Value : this.AgrupadorPostoTrabalho.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_posto_externo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PostoExterno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Operacao==null ? (object) DBNull.Value : this.Operacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao_completa", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OperacaoCompleta==null ? (object) DBNull.Value : this.OperacaoCompleta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_transporte", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Transporte==null ? (object) DBNull.Value : this.Transporte.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_cor_destaque_evolucao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CorDestaqueEvolucao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_taxa_hora", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TaxaHora ?? DBNull.Value;

 
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
 if (CollectionNotificacaoDesvioClassPostoTrabalho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNotificacaoDesvioClassPostoTrabalho+"\r\n";
                foreach (Entidades.NotificacaoDesvioClass tmp in CollectionNotificacaoDesvioClassPostoTrabalho)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho+"\r\n";
                foreach (Entidades.OrdemProducaoPostoTrabalhoClass tmp in CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoRecursoClassPostoTrabalho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoRecursoClassPostoTrabalho+"\r\n";
                foreach (Entidades.OrdemProducaoRecursoClass tmp in CollectionOrdemProducaoRecursoClassPostoTrabalho)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemClassPostoTrabalhoCorte.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemClassPostoTrabalhoCorte+"\r\n";
                foreach (Entidades.PlanoCorteItemClass tmp in CollectionPlanoCorteItemClassPostoTrabalhoCorte)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoMaterialClassPostoTrabalhoCorte.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassPostoTrabalhoCorte+"\r\n";
                foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassPostoTrabalhoCorte)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoPostoTrabalhoClassPostoTrabalho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoPostoTrabalhoClassPostoTrabalho+"\r\n";
                foreach (Entidades.ProdutoPostoTrabalhoClass tmp in CollectionProdutoPostoTrabalhoClassPostoTrabalho)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionRecursoClassPostoTrabalho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionRecursoClassPostoTrabalho+"\r\n";
                foreach (Entidades.RecursoClass tmp in CollectionRecursoClassPostoTrabalho)
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
        public static PostoTrabalhoClass CopiarEntidade(PostoTrabalhoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PostoTrabalhoClass toRet = new PostoTrabalhoClass(usuario,conn);
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Nome= entidadeCopiar.Nome;
 toRet.OperacaoPosto= entidadeCopiar.OperacaoPosto;
 toRet.Rastreamento= entidadeCopiar.Rastreamento;
 toRet.Acompanhamento= entidadeCopiar.Acompanhamento;
 toRet.Produtivo= entidadeCopiar.Produtivo;
 toRet.ConferenciaSequencial= entidadeCopiar.ConferenciaSequencial;
 toRet.RastreamentoMaterial= entidadeCopiar.RastreamentoMaterial;
 toRet.AgrupadorPostoTrabalho= entidadeCopiar.AgrupadorPostoTrabalho;
 toRet.PostoExterno= entidadeCopiar.PostoExterno;
 toRet.Operacao= entidadeCopiar.Operacao;
 toRet.OperacaoCompleta= entidadeCopiar.OperacaoCompleta;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.Transporte= entidadeCopiar.Transporte;
 toRet.CorDestaqueEvolucao= entidadeCopiar.CorDestaqueEvolucao;
 toRet.TaxaHora= entidadeCopiar.TaxaHora;

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
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _operacaoPostoOriginal = OperacaoPosto;
       _operacaoPostoOriginalCommited = _operacaoPostoOriginal;
       _rastreamentoOriginal = Rastreamento;
       _rastreamentoOriginalCommited = _rastreamentoOriginal;
       _acompanhamentoOriginal = Acompanhamento;
       _acompanhamentoOriginalCommited = _acompanhamentoOriginal;
       _produtivoOriginal = Produtivo;
       _produtivoOriginalCommited = _produtivoOriginal;
       _conferenciaSequencialOriginal = ConferenciaSequencial;
       _conferenciaSequencialOriginalCommited = _conferenciaSequencialOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _rastreamentoMaterialOriginal = RastreamentoMaterial;
       _rastreamentoMaterialOriginalCommited = _rastreamentoMaterialOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _agrupadorPostoTrabalhoOriginal = AgrupadorPostoTrabalho;
       _agrupadorPostoTrabalhoOriginalCommited = _agrupadorPostoTrabalhoOriginal;
       _postoExternoOriginal = PostoExterno;
       _postoExternoOriginalCommited = _postoExternoOriginal;
       _operacaoOriginal = Operacao;
       _operacaoOriginalCommited = _operacaoOriginal;
       _operacaoCompletaOriginal = OperacaoCompleta;
       _operacaoCompletaOriginalCommited = _operacaoCompletaOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _transporteOriginal = Transporte;
       _transporteOriginalCommited = _transporteOriginal;
       _corDestaqueEvolucaoOriginal = CorDestaqueEvolucao;
       _corDestaqueEvolucaoOriginalCommited = _corDestaqueEvolucaoOriginal;
       _taxaHoraOriginal = TaxaHora;
       _taxaHoraOriginalCommited = _taxaHoraOriginal;

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
       _nomeOriginalCommited = Nome;
       _operacaoPostoOriginalCommited = OperacaoPosto;
       _rastreamentoOriginalCommited = Rastreamento;
       _acompanhamentoOriginalCommited = Acompanhamento;
       _produtivoOriginalCommited = Produtivo;
       _conferenciaSequencialOriginalCommited = ConferenciaSequencial;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _rastreamentoMaterialOriginalCommited = RastreamentoMaterial;
       _versionOriginalCommited = Version;
       _agrupadorPostoTrabalhoOriginalCommited = AgrupadorPostoTrabalho;
       _postoExternoOriginalCommited = PostoExterno;
       _operacaoOriginalCommited = Operacao;
       _operacaoCompletaOriginalCommited = OperacaoCompleta;
       _fornecedorOriginalCommited = Fornecedor;
       _transporteOriginalCommited = Transporte;
       _corDestaqueEvolucaoOriginalCommited = CorDestaqueEvolucao;
       _taxaHoraOriginalCommited = TaxaHora;

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
               if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded) 
               {
                  if (_collectionNotificacaoDesvioClassPostoTrabalhoRemovidos != null) 
                  {
                     _collectionNotificacaoDesvioClassPostoTrabalhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNotificacaoDesvioClassPostoTrabalhoRemovidos = new List<Entidades.NotificacaoDesvioClass>();
                  }
                  _collectionNotificacaoDesvioClassPostoTrabalhoOriginal= (from a in _valueCollectionNotificacaoDesvioClassPostoTrabalho select a.ID).ToList();
                  _valueCollectionNotificacaoDesvioClassPostoTrabalhoChanged = false;
                  _valueCollectionNotificacaoDesvioClassPostoTrabalhoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  if (_collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoRemovidos != null) 
                  {
                     _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoClass>();
                  }
                  _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho select a.ID).ToList();
                  _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoChanged = false;
                  _valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded) 
               {
                  if (_collectionOrdemProducaoRecursoClassPostoTrabalhoRemovidos != null) 
                  {
                     _collectionOrdemProducaoRecursoClassPostoTrabalhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoRecursoClassPostoTrabalhoRemovidos = new List<Entidades.OrdemProducaoRecursoClass>();
                  }
                  _collectionOrdemProducaoRecursoClassPostoTrabalhoOriginal= (from a in _valueCollectionOrdemProducaoRecursoClassPostoTrabalho select a.ID).ToList();
                  _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoChanged = false;
                  _valueCollectionOrdemProducaoRecursoClassPostoTrabalhoCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteRemovidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteChanged = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteCommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded) 
               {
                  if (_collectionPlanoCorteItemClassPostoTrabalhoCorteRemovidos != null) 
                  {
                     _collectionPlanoCorteItemClassPostoTrabalhoCorteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemClassPostoTrabalhoCorteRemovidos = new List<Entidades.PlanoCorteItemClass>();
                  }
                  _collectionPlanoCorteItemClassPostoTrabalhoCorteOriginal= (from a in _valueCollectionPlanoCorteItemClassPostoTrabalhoCorte select a.ID).ToList();
                  _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteChanged = false;
                  _valueCollectionPlanoCorteItemClassPostoTrabalhoCorteCommitedChanged = false;
               }
               if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  if (_collectionProdutoMaterialClassPostoTrabalhoCorteRemovidos != null) 
                  {
                     _collectionProdutoMaterialClassPostoTrabalhoCorteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoMaterialClassPostoTrabalhoCorteRemovidos = new List<Entidades.ProdutoMaterialClass>();
                  }
                  _collectionProdutoMaterialClassPostoTrabalhoCorteOriginal= (from a in _valueCollectionProdutoMaterialClassPostoTrabalhoCorte select a.ID).ToList();
                  _valueCollectionProdutoMaterialClassPostoTrabalhoCorteChanged = false;
                  _valueCollectionProdutoMaterialClassPostoTrabalhoCorteCommitedChanged = false;
               }
               if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  if (_collectionProdutoPostoTrabalhoClassPostoTrabalhoRemovidos != null) 
                  {
                     _collectionProdutoPostoTrabalhoClassPostoTrabalhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoPostoTrabalhoClassPostoTrabalhoRemovidos = new List<Entidades.ProdutoPostoTrabalhoClass>();
                  }
                  _collectionProdutoPostoTrabalhoClassPostoTrabalhoOriginal= (from a in _valueCollectionProdutoPostoTrabalhoClassPostoTrabalho select a.ID).ToList();
                  _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoChanged = false;
                  _valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoCommitedChanged = false;
               }
               if (_valueCollectionRecursoClassPostoTrabalhoLoaded) 
               {
                  if (_collectionRecursoClassPostoTrabalhoRemovidos != null) 
                  {
                     _collectionRecursoClassPostoTrabalhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionRecursoClassPostoTrabalhoRemovidos = new List<Entidades.RecursoClass>();
                  }
                  _collectionRecursoClassPostoTrabalhoOriginal= (from a in _valueCollectionRecursoClassPostoTrabalho select a.ID).ToList();
                  _valueCollectionRecursoClassPostoTrabalhoChanged = false;
                  _valueCollectionRecursoClassPostoTrabalhoCommitedChanged = false;
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
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               OperacaoPosto=_operacaoPostoOriginal;
               _operacaoPostoOriginalCommited=_operacaoPostoOriginal;
               Rastreamento=_rastreamentoOriginal;
               _rastreamentoOriginalCommited=_rastreamentoOriginal;
               Acompanhamento=_acompanhamentoOriginal;
               _acompanhamentoOriginalCommited=_acompanhamentoOriginal;
               Produtivo=_produtivoOriginal;
               _produtivoOriginalCommited=_produtivoOriginal;
               ConferenciaSequencial=_conferenciaSequencialOriginal;
               _conferenciaSequencialOriginalCommited=_conferenciaSequencialOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               RastreamentoMaterial=_rastreamentoMaterialOriginal;
               _rastreamentoMaterialOriginalCommited=_rastreamentoMaterialOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               AgrupadorPostoTrabalho=_agrupadorPostoTrabalhoOriginal;
               _agrupadorPostoTrabalhoOriginalCommited=_agrupadorPostoTrabalhoOriginal;
               PostoExterno=_postoExternoOriginal;
               _postoExternoOriginalCommited=_postoExternoOriginal;
               Operacao=_operacaoOriginal;
               _operacaoOriginalCommited=_operacaoOriginal;
               OperacaoCompleta=_operacaoCompletaOriginal;
               _operacaoCompletaOriginalCommited=_operacaoCompletaOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               Transporte=_transporteOriginal;
               _transporteOriginalCommited=_transporteOriginal;
               CorDestaqueEvolucao=_corDestaqueEvolucaoOriginal;
               _corDestaqueEvolucaoOriginalCommited=_corDestaqueEvolucaoOriginal;
               TaxaHora=_taxaHoraOriginal;
               _taxaHoraOriginalCommited=_taxaHoraOriginal;
               if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded) 
               {
                  CollectionNotificacaoDesvioClassPostoTrabalho.Clear();
                  foreach(int item in _collectionNotificacaoDesvioClassPostoTrabalhoOriginal)
                  {
                    CollectionNotificacaoDesvioClassPostoTrabalho.Add(Entidades.NotificacaoDesvioClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNotificacaoDesvioClassPostoTrabalhoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho.Clear();
                  foreach(int item in _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoOriginal)
                  {
                    CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho.Add(Entidades.OrdemProducaoPostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded) 
               {
                  CollectionOrdemProducaoRecursoClassPostoTrabalho.Clear();
                  foreach(int item in _collectionOrdemProducaoRecursoClassPostoTrabalhoOriginal)
                  {
                    CollectionOrdemProducaoRecursoClassPostoTrabalho.Add(Entidades.OrdemProducaoRecursoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoRecursoClassPostoTrabalhoRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteOriginal)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteRemovidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded) 
               {
                  CollectionPlanoCorteItemClassPostoTrabalhoCorte.Clear();
                  foreach(int item in _collectionPlanoCorteItemClassPostoTrabalhoCorteOriginal)
                  {
                    CollectionPlanoCorteItemClassPostoTrabalhoCorte.Add(Entidades.PlanoCorteItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemClassPostoTrabalhoCorteRemovidos.Clear();
               }
               if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  CollectionProdutoMaterialClassPostoTrabalhoCorte.Clear();
                  foreach(int item in _collectionProdutoMaterialClassPostoTrabalhoCorteOriginal)
                  {
                    CollectionProdutoMaterialClassPostoTrabalhoCorte.Add(Entidades.ProdutoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoMaterialClassPostoTrabalhoCorteRemovidos.Clear();
               }
               if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  CollectionProdutoPostoTrabalhoClassPostoTrabalho.Clear();
                  foreach(int item in _collectionProdutoPostoTrabalhoClassPostoTrabalhoOriginal)
                  {
                    CollectionProdutoPostoTrabalhoClassPostoTrabalho.Add(Entidades.ProdutoPostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoPostoTrabalhoClassPostoTrabalhoRemovidos.Clear();
               }
               if (_valueCollectionRecursoClassPostoTrabalhoLoaded) 
               {
                  CollectionRecursoClassPostoTrabalho.Clear();
                  foreach(int item in _collectionRecursoClassPostoTrabalhoOriginal)
                  {
                    CollectionRecursoClassPostoTrabalho.Add(Entidades.RecursoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionRecursoClassPostoTrabalhoRemovidos.Clear();
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
               if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRecursoClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionRecursoClassPostoTrabalhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionNotificacaoDesvioClassPostoTrabalho.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoRecursoClassPostoTrabalho.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassPostoTrabalhoCorte.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                   tempRet = CollectionProdutoMaterialClassPostoTrabalhoCorte.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionProdutoPostoTrabalhoClassPostoTrabalho.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionRecursoClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionRecursoClassPostoTrabalho.Any(item => item.IsDirty());
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
       dirty = _nomeOriginal != Nome;
      if (dirty) return true;
       dirty = _operacaoPostoOriginal != OperacaoPosto;
      if (dirty) return true;
       dirty = _rastreamentoOriginal != Rastreamento;
      if (dirty) return true;
       dirty = _acompanhamentoOriginal != Acompanhamento;
      if (dirty) return true;
       dirty = _produtivoOriginal != Produtivo;
      if (dirty) return true;
       dirty = _conferenciaSequencialOriginal != ConferenciaSequencial;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginal != RastreamentoMaterial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_agrupadorPostoTrabalhoOriginal!=null)
       {
          dirty = !_agrupadorPostoTrabalhoOriginal.Equals(AgrupadorPostoTrabalho);
       }
       else
       {
            dirty = AgrupadorPostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _postoExternoOriginal != PostoExterno;
      if (dirty) return true;
       if (_operacaoOriginal!=null)
       {
          dirty = !_operacaoOriginal.Equals(Operacao);
       }
       else
       {
            dirty = Operacao != null;
       }
      if (dirty) return true;
       if (_operacaoCompletaOriginal!=null)
       {
          dirty = !_operacaoCompletaOriginal.Equals(OperacaoCompleta);
       }
       else
       {
            dirty = OperacaoCompleta != null;
       }
      if (dirty) return true;
       if (_fornecedorOriginal!=null)
       {
          dirty = !_fornecedorOriginal.Equals(Fornecedor);
       }
       else
       {
            dirty = Fornecedor != null;
       }
      if (dirty) return true;
       if (_transporteOriginal!=null)
       {
          dirty = !_transporteOriginal.Equals(Transporte);
       }
       else
       {
            dirty = Transporte != null;
       }
      if (dirty) return true;
       dirty = _corDestaqueEvolucaoOriginal != CorDestaqueEvolucao;
      if (dirty) return true;
       dirty = _taxaHoraOriginal != TaxaHora;

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
               if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRecursoClassPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionRecursoClassPostoTrabalhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionNotificacaoDesvioClassPostoTrabalho.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoRecursoClassPostoTrabalho.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassPostoTrabalhoCorte.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                   tempRet = CollectionProdutoMaterialClassPostoTrabalhoCorte.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionProdutoPostoTrabalhoClassPostoTrabalho.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionRecursoClassPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionRecursoClassPostoTrabalho.Any(item => item.IsDirtyCommited());
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
       dirty = _nomeOriginalCommited != Nome;
      if (dirty) return true;
       dirty = _operacaoPostoOriginalCommited != OperacaoPosto;
      if (dirty) return true;
       dirty = _rastreamentoOriginalCommited != Rastreamento;
      if (dirty) return true;
       dirty = _acompanhamentoOriginalCommited != Acompanhamento;
      if (dirty) return true;
       dirty = _produtivoOriginalCommited != Produtivo;
      if (dirty) return true;
       dirty = _conferenciaSequencialOriginalCommited != ConferenciaSequencial;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginalCommited != RastreamentoMaterial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_agrupadorPostoTrabalhoOriginalCommited!=null)
       {
          dirty = !_agrupadorPostoTrabalhoOriginalCommited.Equals(AgrupadorPostoTrabalho);
       }
       else
       {
            dirty = AgrupadorPostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _postoExternoOriginalCommited != PostoExterno;
      if (dirty) return true;
       if (_operacaoOriginalCommited!=null)
       {
          dirty = !_operacaoOriginalCommited.Equals(Operacao);
       }
       else
       {
            dirty = Operacao != null;
       }
      if (dirty) return true;
       if (_operacaoCompletaOriginalCommited!=null)
       {
          dirty = !_operacaoCompletaOriginalCommited.Equals(OperacaoCompleta);
       }
       else
       {
            dirty = OperacaoCompleta != null;
       }
      if (dirty) return true;
       if (_fornecedorOriginalCommited!=null)
       {
          dirty = !_fornecedorOriginalCommited.Equals(Fornecedor);
       }
       else
       {
            dirty = Fornecedor != null;
       }
      if (dirty) return true;
       if (_transporteOriginalCommited!=null)
       {
          dirty = !_transporteOriginalCommited.Equals(Transporte);
       }
       else
       {
            dirty = Transporte != null;
       }
      if (dirty) return true;
       dirty = _corDestaqueEvolucaoOriginalCommited != CorDestaqueEvolucao;
      if (dirty) return true;
       dirty = _taxaHoraOriginalCommited != TaxaHora;

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
               if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded) 
               {
                  foreach(NotificacaoDesvioClass item in CollectionNotificacaoDesvioClassPostoTrabalho)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoClass item in CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded) 
               {
                  foreach(OrdemProducaoRecursoClass item in CollectionOrdemProducaoRecursoClassPostoTrabalho)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassPostoTrabalhoCorte)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassPostoTrabalhoCorte)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  foreach(ProdutoPostoTrabalhoClass item in CollectionProdutoPostoTrabalhoClassPostoTrabalho)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionRecursoClassPostoTrabalhoLoaded) 
               {
                  foreach(RecursoClass item in CollectionRecursoClassPostoTrabalho)
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
             case "Nome":
                return this.Nome;
             case "OperacaoPosto":
                return this.OperacaoPosto;
             case "Rastreamento":
                return this.Rastreamento;
             case "Acompanhamento":
                return this.Acompanhamento;
             case "Produtivo":
                return this.Produtivo;
             case "ConferenciaSequencial":
                return this.ConferenciaSequencial;
             case "RastreamentoMaterial":
                return this.RastreamentoMaterial;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "AgrupadorPostoTrabalho":
                return this.AgrupadorPostoTrabalho;
             case "PostoExterno":
                return this.PostoExterno;
             case "Operacao":
                return this.Operacao;
             case "OperacaoCompleta":
                return this.OperacaoCompleta;
             case "Fornecedor":
                return this.Fornecedor;
             case "Transporte":
                return this.Transporte;
             case "CorDestaqueEvolucao":
                return this.CorDestaqueEvolucao;
             case "TaxaHora":
                return this.TaxaHora;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (AgrupadorPostoTrabalho!=null)
                AgrupadorPostoTrabalho.ChangeSingleConnection(newConnection);
             if (Operacao!=null)
                Operacao.ChangeSingleConnection(newConnection);
             if (OperacaoCompleta!=null)
                OperacaoCompleta.ChangeSingleConnection(newConnection);
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (Transporte!=null)
                Transporte.ChangeSingleConnection(newConnection);
               if (_valueCollectionNotificacaoDesvioClassPostoTrabalhoLoaded) 
               {
                  foreach(NotificacaoDesvioClass item in CollectionNotificacaoDesvioClassPostoTrabalho)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoClass item in CollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassPostoTrabalhoLoaded) 
               {
                  foreach(OrdemProducaoRecursoClass item in CollectionOrdemProducaoRecursoClassPostoTrabalho)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassPostoTrabalhoCorte)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassPostoTrabalhoCorteLoaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassPostoTrabalhoCorte)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoMaterialClassPostoTrabalhoCorteLoaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassPostoTrabalhoCorte)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoPostoTrabalhoClassPostoTrabalhoLoaded) 
               {
                  foreach(ProdutoPostoTrabalhoClass item in CollectionProdutoPostoTrabalhoClassPostoTrabalho)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionRecursoClassPostoTrabalhoLoaded) 
               {
                  foreach(RecursoClass item in CollectionRecursoClassPostoTrabalho)
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
                  command.CommandText += " COUNT(posto_trabalho.id_posto_trabalho) " ;
               }
               else
               {
               command.CommandText += "posto_trabalho.id_posto_trabalho, " ;
               command.CommandText += "posto_trabalho.pos_codigo, " ;
               command.CommandText += "posto_trabalho.pos_nome, " ;
               command.CommandText += "posto_trabalho.pos_operacao_posto, " ;
               command.CommandText += "posto_trabalho.pos_rastreamento, " ;
               command.CommandText += "posto_trabalho.pos_acompanhamento, " ;
               command.CommandText += "posto_trabalho.pos_produtivo, " ;
               command.CommandText += "posto_trabalho.pos_conferencia_sequencial, " ;
               command.CommandText += "posto_trabalho.pos_ultima_revisao, " ;
               command.CommandText += "posto_trabalho.pos_ultima_revisao_data, " ;
               command.CommandText += "posto_trabalho.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "posto_trabalho.pos_rastreamento_material, " ;
               command.CommandText += "posto_trabalho.entity_uid, " ;
               command.CommandText += "posto_trabalho.version, " ;
               command.CommandText += "posto_trabalho.id_agrupador_posto_trabalho, " ;
               command.CommandText += "posto_trabalho.pos_posto_externo, " ;
               command.CommandText += "posto_trabalho.id_operacao, " ;
               command.CommandText += "posto_trabalho.id_operacao_completa, " ;
               command.CommandText += "posto_trabalho.id_fornecedor, " ;
               command.CommandText += "posto_trabalho.id_transporte, " ;
               command.CommandText += "posto_trabalho.pos_cor_destaque_evolucao, " ;
               command.CommandText += "posto_trabalho.pos_taxa_hora " ;
               }
               command.CommandText += " FROM  posto_trabalho ";
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
                        orderByClause += " , pos_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pos_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = posto_trabalho.id_acs_usuario_ultima_revisao ";
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
                     case "id_posto_trabalho":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , posto_trabalho.id_posto_trabalho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.id_posto_trabalho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho.pos_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho.pos_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho.pos_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho.pos_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_operacao_posto":
                     case "OperacaoPosto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho.pos_operacao_posto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho.pos_operacao_posto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_rastreamento":
                     case "Rastreamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , posto_trabalho.pos_rastreamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.pos_rastreamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_acompanhamento":
                     case "Acompanhamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , posto_trabalho.pos_acompanhamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.pos_acompanhamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_produtivo":
                     case "Produtivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , posto_trabalho.pos_produtivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.pos_produtivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_conferencia_sequencial":
                     case "ConferenciaSequencial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , posto_trabalho.pos_conferencia_sequencial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.pos_conferencia_sequencial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho.pos_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho.pos_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , posto_trabalho.pos_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.pos_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , posto_trabalho.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "pos_rastreamento_material":
                     case "RastreamentoMaterial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , posto_trabalho.pos_rastreamento_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.pos_rastreamento_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , posto_trabalho.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_agrupador_posto_trabalho":
                     case "AgrupadorPostoTrabalho":
                     command.CommandText += " LEFT JOIN agrupador_posto_trabalho as agrupador_posto_trabalho_AgrupadorPostoTrabalho ON agrupador_posto_trabalho_AgrupadorPostoTrabalho.id_agrupador_posto_trabalho = posto_trabalho.id_agrupador_posto_trabalho ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_posto_trabalho_AgrupadorPostoTrabalho.apt_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_posto_trabalho_AgrupadorPostoTrabalho.apt_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_posto_externo":
                     case "PostoExterno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , posto_trabalho.pos_posto_externo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.pos_posto_externo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_operacao":
                     case "Operacao":
                     command.CommandText += " LEFT JOIN operacao as operacao_Operacao ON operacao_Operacao.id_operacao = posto_trabalho.id_operacao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_Operacao.ope_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_Operacao.ope_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_operacao_completa":
                     case "OperacaoCompleta":
                     command.CommandText += " LEFT JOIN operacao_completa as operacao_completa_OperacaoCompleta ON operacao_completa_OperacaoCompleta.id_operacao_completa = posto_trabalho.id_operacao_completa ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa_OperacaoCompleta.opc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa_OperacaoCompleta.opc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = posto_trabalho.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor_Fornecedor.for_nome_fantasia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor_Fornecedor.for_nome_fantasia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_transporte":
                     case "Transporte":
                     command.CommandText += " LEFT JOIN transporte as transporte_Transporte ON transporte_Transporte.id_transporte = posto_trabalho.id_transporte ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte_Transporte.trp_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte_Transporte.trp_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_cor_destaque_evolucao":
                     case "CorDestaqueEvolucao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho.pos_cor_destaque_evolucao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho.pos_cor_destaque_evolucao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pos_taxa_hora":
                     case "TaxaHora":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , posto_trabalho.pos_taxa_hora " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(posto_trabalho.pos_taxa_hora) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pos_codigo")) 
                        {
                           whereClause += " OR UPPER(posto_trabalho.pos_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(posto_trabalho.pos_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pos_nome")) 
                        {
                           whereClause += " OR UPPER(posto_trabalho.pos_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(posto_trabalho.pos_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pos_operacao_posto")) 
                        {
                           whereClause += " OR UPPER(posto_trabalho.pos_operacao_posto) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(posto_trabalho.pos_operacao_posto) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pos_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(posto_trabalho.pos_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(posto_trabalho.pos_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(posto_trabalho.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(posto_trabalho.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pos_cor_destaque_evolucao")) 
                        {
                           whereClause += " OR UPPER(posto_trabalho.pos_cor_destaque_evolucao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(posto_trabalho.pos_cor_destaque_evolucao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.id_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.id_posto_trabalho = :posto_trabalho_ID_960 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_ID_960", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "pos_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_codigo LIKE :posto_trabalho_Codigo_4462 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Codigo_4462", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "pos_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_nome LIKE :posto_trabalho_Nome_8717 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Nome_8717", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperacaoPosto" || parametro.FieldName == "pos_operacao_posto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_operacao_posto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_operacao_posto LIKE :posto_trabalho_OperacaoPosto_856 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_OperacaoPosto_856", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Rastreamento" || parametro.FieldName == "pos_rastreamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_rastreamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_rastreamento = :posto_trabalho_Rastreamento_5282 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Rastreamento_5282", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Acompanhamento" || parametro.FieldName == "pos_acompanhamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is PostoTrabalhoAcompanhamento)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo PostoTrabalhoAcompanhamento");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_acompanhamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_acompanhamento = :posto_trabalho_Acompanhamento_9068 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Acompanhamento_9068", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Produtivo" || parametro.FieldName == "pos_produtivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_produtivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_produtivo = :posto_trabalho_Produtivo_4002 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Produtivo_4002", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaSequencial" || parametro.FieldName == "pos_conferencia_sequencial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_conferencia_sequencial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_conferencia_sequencial = :posto_trabalho_ConferenciaSequencial_3133 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_ConferenciaSequencial_3133", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "pos_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_ultima_revisao LIKE :posto_trabalho_UltimaRevisao_73 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_UltimaRevisao_73", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "pos_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_ultima_revisao_data = :posto_trabalho_UltimaRevisaoData_464 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_UltimaRevisaoData_464", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  posto_trabalho.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.id_acs_usuario_ultima_revisao = :posto_trabalho_UltimaRevisaoUsuario_7233 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_UltimaRevisaoUsuario_7233", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RastreamentoMaterial" || parametro.FieldName == "pos_rastreamento_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_rastreamento_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_rastreamento_material = :posto_trabalho_RastreamentoMaterial_3614 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_RastreamentoMaterial_3614", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  posto_trabalho.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.entity_uid LIKE :posto_trabalho_EntityUid_9631 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_EntityUid_9631", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  posto_trabalho.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.version = :posto_trabalho_Version_8897 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Version_8897", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgrupadorPostoTrabalho" || parametro.FieldName == "id_agrupador_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.AgrupadorPostoTrabalhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.AgrupadorPostoTrabalhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.id_agrupador_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.id_agrupador_posto_trabalho = :posto_trabalho_AgrupadorPostoTrabalho_7662 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_AgrupadorPostoTrabalho_7662", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoExterno" || parametro.FieldName == "pos_posto_externo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_posto_externo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_posto_externo = :posto_trabalho_PostoExterno_3196 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_PostoExterno_3196", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Operacao" || parametro.FieldName == "id_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OperacaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OperacaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.id_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.id_operacao = :posto_trabalho_Operacao_5472 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Operacao_5472", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperacaoCompleta" || parametro.FieldName == "id_operacao_completa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OperacaoCompletaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OperacaoCompletaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.id_operacao_completa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.id_operacao_completa = :posto_trabalho_OperacaoCompleta_5730 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_OperacaoCompleta_5730", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fornecedor" || parametro.FieldName == "id_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FornecedorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FornecedorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.id_fornecedor = :posto_trabalho_Fornecedor_9678 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Fornecedor_9678", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Transporte" || parametro.FieldName == "id_transporte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.TransporteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.TransporteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.id_transporte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.id_transporte = :posto_trabalho_Transporte_2197 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Transporte_2197", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CorDestaqueEvolucao" || parametro.FieldName == "pos_cor_destaque_evolucao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_cor_destaque_evolucao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_cor_destaque_evolucao LIKE :posto_trabalho_CorDestaqueEvolucao_8307 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_CorDestaqueEvolucao_8307", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TaxaHora" || parametro.FieldName == "pos_taxa_hora")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_taxa_hora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_taxa_hora = :posto_trabalho_TaxaHora_9604 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_TaxaHora_9604", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  posto_trabalho.pos_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_codigo LIKE :posto_trabalho_Codigo_6834 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Codigo_6834", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeExato" || parametro.FieldName == "NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_nome LIKE :posto_trabalho_Nome_446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_Nome_446", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperacaoPostoExato" || parametro.FieldName == "OperacaoPostoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_operacao_posto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_operacao_posto LIKE :posto_trabalho_OperacaoPosto_6511 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_OperacaoPosto_6511", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  posto_trabalho.pos_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_ultima_revisao LIKE :posto_trabalho_UltimaRevisao_180 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_UltimaRevisao_180", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  posto_trabalho.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.entity_uid LIKE :posto_trabalho_EntityUid_4594 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_EntityUid_4594", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CorDestaqueEvolucaoExato" || parametro.FieldName == "CorDestaqueEvolucaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  posto_trabalho.pos_cor_destaque_evolucao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  posto_trabalho.pos_cor_destaque_evolucao LIKE :posto_trabalho_CorDestaqueEvolucao_8111 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("posto_trabalho_CorDestaqueEvolucao_8111", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PostoTrabalhoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PostoTrabalhoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PostoTrabalhoClass), Convert.ToInt32(read["id_posto_trabalho"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PostoTrabalhoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_posto_trabalho"]);
                     entidade.Codigo = (read["pos_codigo"] != DBNull.Value ? read["pos_codigo"].ToString() : null);
                     entidade.Nome = (read["pos_nome"] != DBNull.Value ? read["pos_nome"].ToString() : null);
                     entidade.OperacaoPosto = (read["pos_operacao_posto"] != DBNull.Value ? read["pos_operacao_posto"].ToString() : null);
                     entidade.Rastreamento = Convert.ToBoolean(Convert.ToInt16(read["pos_rastreamento"]));
                     entidade.Acompanhamento = (PostoTrabalhoAcompanhamento) (read["pos_acompanhamento"] != DBNull.Value ? Enum.ToObject(typeof(PostoTrabalhoAcompanhamento), read["pos_acompanhamento"]) : null);
                     entidade.Produtivo = Convert.ToBoolean(Convert.ToInt16(read["pos_produtivo"]));
                     entidade.ConferenciaSequencial = Convert.ToBoolean(Convert.ToInt16(read["pos_conferencia_sequencial"]));
                     entidade.UltimaRevisao = (read["pos_ultima_revisao"] != DBNull.Value ? read["pos_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["pos_ultima_revisao_data"] as DateTime?;
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.RastreamentoMaterial = Convert.ToBoolean(Convert.ToInt16(read["pos_rastreamento_material"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_agrupador_posto_trabalho"] != DBNull.Value)
                     {
                        entidade.AgrupadorPostoTrabalho = (BibliotecaEntidades.Entidades.AgrupadorPostoTrabalhoClass)BibliotecaEntidades.Entidades.AgrupadorPostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_agrupador_posto_trabalho"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AgrupadorPostoTrabalho = null ;
                     }
                     entidade.PostoExterno = Convert.ToBoolean(Convert.ToInt16(read["pos_posto_externo"]));
                     if (read["id_operacao"] != DBNull.Value)
                     {
                        entidade.Operacao = (BibliotecaEntidades.Entidades.OperacaoClass)BibliotecaEntidades.Entidades.OperacaoClass.GetEntidade(Convert.ToInt32(read["id_operacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Operacao = null ;
                     }
                     if (read["id_operacao_completa"] != DBNull.Value)
                     {
                        entidade.OperacaoCompleta = (BibliotecaEntidades.Entidades.OperacaoCompletaClass)BibliotecaEntidades.Entidades.OperacaoCompletaClass.GetEntidade(Convert.ToInt32(read["id_operacao_completa"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OperacaoCompleta = null ;
                     }
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     if (read["id_transporte"] != DBNull.Value)
                     {
                        entidade.Transporte = (BibliotecaEntidades.Entidades.TransporteClass)BibliotecaEntidades.Entidades.TransporteClass.GetEntidade(Convert.ToInt32(read["id_transporte"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Transporte = null ;
                     }
                     entidade.CorDestaqueEvolucao = (read["pos_cor_destaque_evolucao"] != DBNull.Value ? read["pos_cor_destaque_evolucao"].ToString() : null);
                     entidade.TaxaHora = (double)read["pos_taxa_hora"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PostoTrabalhoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
