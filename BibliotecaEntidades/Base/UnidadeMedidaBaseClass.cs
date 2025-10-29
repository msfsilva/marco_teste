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
     [Table("unidade_medida","unm")]
     public class UnidadeMedidaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do UnidadeMedidaClass";
protected const string ErroDelete = "Erro ao excluir o UnidadeMedidaClass  ";
protected const string ErroSave = "Erro ao salvar o UnidadeMedidaClass.";
protected const string ErroCollectionEpiClassUnidadeMedidaCompra = "Erro ao carregar a coleção de EpiClass.";
protected const string ErroCollectionEpiClassUnidadeMedidaUso = "Erro ao carregar a coleção de EpiClass.";
protected const string ErroCollectionEpiFornecedorClassUnidadeMedidaCompra = "Erro ao carregar a coleção de EpiFornecedorClass.";
protected const string ErroCollectionMaterialClassUnidadeMedida = "Erro ao carregar a coleção de MaterialClass.";
protected const string ErroCollectionMaterialClassUnidadeMedidaCompra = "Erro ao carregar a coleção de MaterialClass.";
protected const string ErroCollectionMaterialFornecedorClassUnidadeMedidaCompra = "Erro ao carregar a coleção de MaterialFornecedorClass.";
protected const string ErroCollectionOrderItemEtiquetaClassUnidadeMedida = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1 = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2 = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3 = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPlanoCorteItemClassUnidadeMedida1 = "Erro ao carregar a coleção de PlanoCorteItemClass.";
protected const string ErroCollectionPlanoCorteItemClassUnidadeMedida2 = "Erro ao carregar a coleção de PlanoCorteItemClass.";
protected const string ErroCollectionPlanoCorteItemClassUnidadeMedida3 = "Erro ao carregar a coleção de PlanoCorteItemClass.";
protected const string ErroCollectionProdutoClassUnidadeMedida = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCollectionProdutoClassUnidadeMedidaCompra = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCollectionProdutoFornecedorClassUnidadeMedidaCompra = "Erro ao carregar a coleção de ProdutoFornecedorClass.";
protected const string ErroCollectionProdutoMaterialClassUnidadeMedidaDimensao1 = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected const string ErroCollectionProdutoMaterialClassUnidadeMedidaDimensao2 = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected const string ErroCollectionProdutoMaterialClassUnidadeMedidaDimensao3 = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected const string ErroAbreviadaObrigatorio = "O campo Abreviada é obrigatório";
protected const string ErroAbreviadaComprimento = "O campo Abreviada deve ter no máximo 255 caracteres";
protected const string ErroNomeUnidadeObrigatorio = "O campo NomeUnidade é obrigatório";
protected const string ErroNomeUnidadeComprimento = "O campo NomeUnidade deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do UnidadeMedidaClass.";
protected const string MensagemUtilizadoCollectionEpiClassUnidadeMedidaCompra =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes EpiClass:";
protected const string MensagemUtilizadoCollectionEpiClassUnidadeMedidaUso =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes EpiClass:";
protected const string MensagemUtilizadoCollectionEpiFornecedorClassUnidadeMedidaCompra =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes EpiFornecedorClass:";
protected const string MensagemUtilizadoCollectionMaterialClassUnidadeMedida =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes MaterialClass:";
protected const string MensagemUtilizadoCollectionMaterialClassUnidadeMedidaCompra =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes MaterialClass:";
protected const string MensagemUtilizadoCollectionMaterialFornecedorClassUnidadeMedidaCompra =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes MaterialFornecedorClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaClassUnidadeMedida =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1 =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2 =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3 =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemClassUnidadeMedida1 =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemClassUnidadeMedida2 =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemClassUnidadeMedida3 =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
protected const string MensagemUtilizadoCollectionProdutoClassUnidadeMedida =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string MensagemUtilizadoCollectionProdutoClassUnidadeMedidaCompra =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string MensagemUtilizadoCollectionProdutoFornecedorClassUnidadeMedidaCompra =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes ProdutoFornecedorClass:";
protected const string MensagemUtilizadoCollectionProdutoMaterialClassUnidadeMedidaDimensao1 =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected const string MensagemUtilizadoCollectionProdutoMaterialClassUnidadeMedidaDimensao2 =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected const string MensagemUtilizadoCollectionProdutoMaterialClassUnidadeMedidaDimensao3 =  "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade UnidadeMedidaClass está sendo utilizada.";
#endregion
       protected string _abreviadaOriginal{get;private set;}
       private string _abreviadaOriginalCommited{get; set;}
        private string _valueAbreviada;
         [Column("unm_abreviada")]
        public virtual string Abreviada
         { 
            get { return this._valueAbreviada; } 
            set 
            { 
                if (this._valueAbreviada == value)return;
                 this._valueAbreviada = value; 
            } 
        } 

       protected string _nomeUnidadeOriginal{get;private set;}
       private string _nomeUnidadeOriginalCommited{get; set;}
        private string _valueNomeUnidade;
         [Column("unm_nome_unidade")]
        public virtual string NomeUnidade
         { 
            get { return this._valueNomeUnidade; } 
            set 
            { 
                if (this._valueNomeUnidade == value)return;
                 this._valueNomeUnidade = value; 
            } 
        } 

       protected string _obsOriginal{get;private set;}
       private string _obsOriginalCommited{get; set;}
        private string _valueObs;
         [Column("unm_obs")]
        public virtual string Obs
         { 
            get { return this._valueObs; } 
            set 
            { 
                if (this._valueObs == value)return;
                 this._valueObs = value; 
            } 
        } 

       private List<long> _collectionEpiClassUnidadeMedidaCompraOriginal;
       private List<Entidades.EpiClass > _collectionEpiClassUnidadeMedidaCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiClassUnidadeMedidaCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiClassUnidadeMedidaCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiClassUnidadeMedidaCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EpiClass> _valueCollectionEpiClassUnidadeMedidaCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EpiClass> CollectionEpiClassUnidadeMedidaCompra 
       { 
           get { if(!_valueCollectionEpiClassUnidadeMedidaCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionEpiClassUnidadeMedidaCompra();}
return this._valueCollectionEpiClassUnidadeMedidaCompra; } 
           set 
           { 
               this._valueCollectionEpiClassUnidadeMedidaCompra = value; 
               this._valueCollectionEpiClassUnidadeMedidaCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionEpiClassUnidadeMedidaUsoOriginal;
       private List<Entidades.EpiClass > _collectionEpiClassUnidadeMedidaUsoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiClassUnidadeMedidaUsoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiClassUnidadeMedidaUsoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiClassUnidadeMedidaUsoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EpiClass> _valueCollectionEpiClassUnidadeMedidaUso { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EpiClass> CollectionEpiClassUnidadeMedidaUso 
       { 
           get { if(!_valueCollectionEpiClassUnidadeMedidaUsoLoaded && !this.DisableLoadCollection){this.LoadCollectionEpiClassUnidadeMedidaUso();}
return this._valueCollectionEpiClassUnidadeMedidaUso; } 
           set 
           { 
               this._valueCollectionEpiClassUnidadeMedidaUso = value; 
               this._valueCollectionEpiClassUnidadeMedidaUsoLoaded = true; 
           } 
       } 

       private List<long> _collectionEpiFornecedorClassUnidadeMedidaCompraOriginal;
       private List<Entidades.EpiFornecedorClass > _collectionEpiFornecedorClassUnidadeMedidaCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiFornecedorClassUnidadeMedidaCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiFornecedorClassUnidadeMedidaCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EpiFornecedorClass> _valueCollectionEpiFornecedorClassUnidadeMedidaCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EpiFornecedorClass> CollectionEpiFornecedorClassUnidadeMedidaCompra 
       { 
           get { if(!_valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionEpiFornecedorClassUnidadeMedidaCompra();}
return this._valueCollectionEpiFornecedorClassUnidadeMedidaCompra; } 
           set 
           { 
               this._valueCollectionEpiFornecedorClassUnidadeMedidaCompra = value; 
               this._valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionMaterialClassUnidadeMedidaOriginal;
       private List<Entidades.MaterialClass > _collectionMaterialClassUnidadeMedidaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassUnidadeMedidaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassUnidadeMedidaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassUnidadeMedidaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialClass> _valueCollectionMaterialClassUnidadeMedida { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialClass> CollectionMaterialClassUnidadeMedida 
       { 
           get { if(!_valueCollectionMaterialClassUnidadeMedidaLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialClassUnidadeMedida();}
return this._valueCollectionMaterialClassUnidadeMedida; } 
           set 
           { 
               this._valueCollectionMaterialClassUnidadeMedida = value; 
               this._valueCollectionMaterialClassUnidadeMedidaLoaded = true; 
           } 
       } 

       private List<long> _collectionMaterialClassUnidadeMedidaCompraOriginal;
       private List<Entidades.MaterialClass > _collectionMaterialClassUnidadeMedidaCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassUnidadeMedidaCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassUnidadeMedidaCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassUnidadeMedidaCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialClass> _valueCollectionMaterialClassUnidadeMedidaCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialClass> CollectionMaterialClassUnidadeMedidaCompra 
       { 
           get { if(!_valueCollectionMaterialClassUnidadeMedidaCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialClassUnidadeMedidaCompra();}
return this._valueCollectionMaterialClassUnidadeMedidaCompra; } 
           set 
           { 
               this._valueCollectionMaterialClassUnidadeMedidaCompra = value; 
               this._valueCollectionMaterialClassUnidadeMedidaCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionMaterialFornecedorClassUnidadeMedidaCompraOriginal;
       private List<Entidades.MaterialFornecedorClass > _collectionMaterialFornecedorClassUnidadeMedidaCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialFornecedorClass> _valueCollectionMaterialFornecedorClassUnidadeMedidaCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialFornecedorClass> CollectionMaterialFornecedorClassUnidadeMedidaCompra 
       { 
           get { if(!_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialFornecedorClassUnidadeMedidaCompra();}
return this._valueCollectionMaterialFornecedorClassUnidadeMedidaCompra; } 
           set 
           { 
               this._valueCollectionMaterialFornecedorClassUnidadeMedidaCompra = value; 
               this._valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaClassUnidadeMedidaOriginal;
       private List<Entidades.OrderItemEtiquetaClass > _collectionOrderItemEtiquetaClassUnidadeMedidaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassUnidadeMedidaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassUnidadeMedidaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaClass> _valueCollectionOrderItemEtiquetaClassUnidadeMedida { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaClass> CollectionOrderItemEtiquetaClassUnidadeMedida 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaClassUnidadeMedida();}
return this._valueCollectionOrderItemEtiquetaClassUnidadeMedida; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaClassUnidadeMedida = value; 
               this._valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaOriginal;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassUnidadeMedida 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Original;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1 = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Original;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2 = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Original;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3 = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemClassUnidadeMedida1Original;
       private List<Entidades.PlanoCorteItemClass > _collectionPlanoCorteItemClassUnidadeMedida1Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassUnidadeMedida1Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassUnidadeMedida1CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemClass> _valueCollectionPlanoCorteItemClassUnidadeMedida1 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemClass> CollectionPlanoCorteItemClassUnidadeMedida1 
       { 
           get { if(!_valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemClassUnidadeMedida1();}
return this._valueCollectionPlanoCorteItemClassUnidadeMedida1; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemClassUnidadeMedida1 = value; 
               this._valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemClassUnidadeMedida2Original;
       private List<Entidades.PlanoCorteItemClass > _collectionPlanoCorteItemClassUnidadeMedida2Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassUnidadeMedida2Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassUnidadeMedida2CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemClass> _valueCollectionPlanoCorteItemClassUnidadeMedida2 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemClass> CollectionPlanoCorteItemClassUnidadeMedida2 
       { 
           get { if(!_valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemClassUnidadeMedida2();}
return this._valueCollectionPlanoCorteItemClassUnidadeMedida2; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemClassUnidadeMedida2 = value; 
               this._valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemClassUnidadeMedida3Original;
       private List<Entidades.PlanoCorteItemClass > _collectionPlanoCorteItemClassUnidadeMedida3Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassUnidadeMedida3Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassUnidadeMedida3CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemClass> _valueCollectionPlanoCorteItemClassUnidadeMedida3 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemClass> CollectionPlanoCorteItemClassUnidadeMedida3 
       { 
           get { if(!_valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemClassUnidadeMedida3();}
return this._valueCollectionPlanoCorteItemClassUnidadeMedida3; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemClassUnidadeMedida3 = value; 
               this._valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassUnidadeMedidaOriginal;
       private List<Entidades.ProdutoClass > _collectionProdutoClassUnidadeMedidaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassUnidadeMedidaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassUnidadeMedidaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassUnidadeMedidaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassUnidadeMedida { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassUnidadeMedida 
       { 
           get { if(!_valueCollectionProdutoClassUnidadeMedidaLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassUnidadeMedida();}
return this._valueCollectionProdutoClassUnidadeMedida; } 
           set 
           { 
               this._valueCollectionProdutoClassUnidadeMedida = value; 
               this._valueCollectionProdutoClassUnidadeMedidaLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassUnidadeMedidaCompraOriginal;
       private List<Entidades.ProdutoClass > _collectionProdutoClassUnidadeMedidaCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassUnidadeMedidaCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassUnidadeMedidaCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassUnidadeMedidaCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassUnidadeMedidaCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassUnidadeMedidaCompra 
       { 
           get { if(!_valueCollectionProdutoClassUnidadeMedidaCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassUnidadeMedidaCompra();}
return this._valueCollectionProdutoClassUnidadeMedidaCompra; } 
           set 
           { 
               this._valueCollectionProdutoClassUnidadeMedidaCompra = value; 
               this._valueCollectionProdutoClassUnidadeMedidaCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoFornecedorClassUnidadeMedidaCompraOriginal;
       private List<Entidades.ProdutoFornecedorClass > _collectionProdutoFornecedorClassUnidadeMedidaCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoFornecedorClass> _valueCollectionProdutoFornecedorClassUnidadeMedidaCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoFornecedorClass> CollectionProdutoFornecedorClassUnidadeMedidaCompra 
       { 
           get { if(!_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoFornecedorClassUnidadeMedidaCompra();}
return this._valueCollectionProdutoFornecedorClassUnidadeMedidaCompra; } 
           set 
           { 
               this._valueCollectionProdutoFornecedorClassUnidadeMedidaCompra = value; 
               this._valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoMaterialClassUnidadeMedidaDimensao1Original;
       private List<Entidades.ProdutoMaterialClass > _collectionProdutoMaterialClassUnidadeMedidaDimensao1Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoMaterialClass> _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoMaterialClass> CollectionProdutoMaterialClassUnidadeMedidaDimensao1 
       { 
           get { if(!_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoMaterialClassUnidadeMedidaDimensao1();}
return this._valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1; } 
           set 
           { 
               this._valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1 = value; 
               this._valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded = true; 
           } 
       } 

       private List<long> _collectionProdutoMaterialClassUnidadeMedidaDimensao2Original;
       private List<Entidades.ProdutoMaterialClass > _collectionProdutoMaterialClassUnidadeMedidaDimensao2Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoMaterialClass> _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoMaterialClass> CollectionProdutoMaterialClassUnidadeMedidaDimensao2 
       { 
           get { if(!_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoMaterialClassUnidadeMedidaDimensao2();}
return this._valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2; } 
           set 
           { 
               this._valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2 = value; 
               this._valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded = true; 
           } 
       } 

       private List<long> _collectionProdutoMaterialClassUnidadeMedidaDimensao3Original;
       private List<Entidades.ProdutoMaterialClass > _collectionProdutoMaterialClassUnidadeMedidaDimensao3Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoMaterialClass> _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoMaterialClass> CollectionProdutoMaterialClassUnidadeMedidaDimensao3 
       { 
           get { if(!_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoMaterialClassUnidadeMedidaDimensao3();}
return this._valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3; } 
           set 
           { 
               this._valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3 = value; 
               this._valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded = true; 
           } 
       } 

        public UnidadeMedidaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static UnidadeMedidaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (UnidadeMedidaClass) GetEntity(typeof(UnidadeMedidaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEpiClassUnidadeMedidaCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEpiClassUnidadeMedidaCompraChanged = true;
                  _valueCollectionEpiClassUnidadeMedidaCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEpiClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionEpiClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.EpiClass item in e.OldItems) 
                 { 
                     _collectionEpiClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEpiClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionEpiClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.EpiClass item in _valueCollectionEpiClassUnidadeMedidaCompra) 
                 { 
                     _collectionEpiClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEpiClassUnidadeMedidaCompra()
         {
            try
            {
                 ObservableCollection<Entidades.EpiClass> oc;
                _valueCollectionEpiClassUnidadeMedidaCompraChanged = false;
                 _valueCollectionEpiClassUnidadeMedidaCompraCommitedChanged = false;
                _collectionEpiClassUnidadeMedidaCompraRemovidos = new List<Entidades.EpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EpiClass>();
                }
                else{ 
                   Entidades.EpiClass search = new Entidades.EpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaCompra", this),                     }                       ).Cast<Entidades.EpiClass>().ToList());
                 }
                 _valueCollectionEpiClassUnidadeMedidaCompra = new BindingList<Entidades.EpiClass>(oc); 
                 _collectionEpiClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionEpiClassUnidadeMedidaCompra select a.ID).ToList();
                 _valueCollectionEpiClassUnidadeMedidaCompraLoaded = true;
                 oc.CollectionChanged += CollectionEpiClassUnidadeMedidaCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEpiClassUnidadeMedidaCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionEpiClassUnidadeMedidaUsoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEpiClassUnidadeMedidaUsoChanged = true;
                  _valueCollectionEpiClassUnidadeMedidaUsoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEpiClassUnidadeMedidaUsoChanged = true; 
                  _valueCollectionEpiClassUnidadeMedidaUsoCommitedChanged = true;
                 foreach (Entidades.EpiClass item in e.OldItems) 
                 { 
                     _collectionEpiClassUnidadeMedidaUsoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEpiClassUnidadeMedidaUsoChanged = true; 
                  _valueCollectionEpiClassUnidadeMedidaUsoCommitedChanged = true;
                 foreach (Entidades.EpiClass item in _valueCollectionEpiClassUnidadeMedidaUso) 
                 { 
                     _collectionEpiClassUnidadeMedidaUsoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEpiClassUnidadeMedidaUso()
         {
            try
            {
                 ObservableCollection<Entidades.EpiClass> oc;
                _valueCollectionEpiClassUnidadeMedidaUsoChanged = false;
                 _valueCollectionEpiClassUnidadeMedidaUsoCommitedChanged = false;
                _collectionEpiClassUnidadeMedidaUsoRemovidos = new List<Entidades.EpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EpiClass>();
                }
                else{ 
                   Entidades.EpiClass search = new Entidades.EpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaUso", this),                     }                       ).Cast<Entidades.EpiClass>().ToList());
                 }
                 _valueCollectionEpiClassUnidadeMedidaUso = new BindingList<Entidades.EpiClass>(oc); 
                 _collectionEpiClassUnidadeMedidaUsoOriginal= (from a in _valueCollectionEpiClassUnidadeMedidaUso select a.ID).ToList();
                 _valueCollectionEpiClassUnidadeMedidaUsoLoaded = true;
                 oc.CollectionChanged += CollectionEpiClassUnidadeMedidaUsoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEpiClassUnidadeMedidaUso+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionEpiFornecedorClassUnidadeMedidaCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEpiFornecedorClassUnidadeMedidaCompraChanged = true;
                  _valueCollectionEpiFornecedorClassUnidadeMedidaCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEpiFornecedorClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionEpiFornecedorClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.EpiFornecedorClass item in e.OldItems) 
                 { 
                     _collectionEpiFornecedorClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEpiFornecedorClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionEpiFornecedorClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.EpiFornecedorClass item in _valueCollectionEpiFornecedorClassUnidadeMedidaCompra) 
                 { 
                     _collectionEpiFornecedorClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEpiFornecedorClassUnidadeMedidaCompra()
         {
            try
            {
                 ObservableCollection<Entidades.EpiFornecedorClass> oc;
                _valueCollectionEpiFornecedorClassUnidadeMedidaCompraChanged = false;
                 _valueCollectionEpiFornecedorClassUnidadeMedidaCompraCommitedChanged = false;
                _collectionEpiFornecedorClassUnidadeMedidaCompraRemovidos = new List<Entidades.EpiFornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EpiFornecedorClass>();
                }
                else{ 
                   Entidades.EpiFornecedorClass search = new Entidades.EpiFornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EpiFornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaCompra", this),                     }                       ).Cast<Entidades.EpiFornecedorClass>().ToList());
                 }
                 _valueCollectionEpiFornecedorClassUnidadeMedidaCompra = new BindingList<Entidades.EpiFornecedorClass>(oc); 
                 _collectionEpiFornecedorClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionEpiFornecedorClassUnidadeMedidaCompra select a.ID).ToList();
                 _valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded = true;
                 oc.CollectionChanged += CollectionEpiFornecedorClassUnidadeMedidaCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEpiFornecedorClassUnidadeMedidaCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMaterialClassUnidadeMedidaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialClassUnidadeMedidaChanged = true;
                  _valueCollectionMaterialClassUnidadeMedidaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialClassUnidadeMedidaChanged = true; 
                  _valueCollectionMaterialClassUnidadeMedidaCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in e.OldItems) 
                 { 
                     _collectionMaterialClassUnidadeMedidaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialClassUnidadeMedidaChanged = true; 
                  _valueCollectionMaterialClassUnidadeMedidaCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in _valueCollectionMaterialClassUnidadeMedida) 
                 { 
                     _collectionMaterialClassUnidadeMedidaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialClassUnidadeMedida()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialClass> oc;
                _valueCollectionMaterialClassUnidadeMedidaChanged = false;
                 _valueCollectionMaterialClassUnidadeMedidaCommitedChanged = false;
                _collectionMaterialClassUnidadeMedidaRemovidos = new List<Entidades.MaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialClass>();
                }
                else{ 
                   Entidades.MaterialClass search = new Entidades.MaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedida", this),                     }                       ).Cast<Entidades.MaterialClass>().ToList());
                 }
                 _valueCollectionMaterialClassUnidadeMedida = new BindingList<Entidades.MaterialClass>(oc); 
                 _collectionMaterialClassUnidadeMedidaOriginal= (from a in _valueCollectionMaterialClassUnidadeMedida select a.ID).ToList();
                 _valueCollectionMaterialClassUnidadeMedidaLoaded = true;
                 oc.CollectionChanged += CollectionMaterialClassUnidadeMedidaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialClassUnidadeMedida+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMaterialClassUnidadeMedidaCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialClassUnidadeMedidaCompraChanged = true;
                  _valueCollectionMaterialClassUnidadeMedidaCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionMaterialClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in e.OldItems) 
                 { 
                     _collectionMaterialClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionMaterialClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in _valueCollectionMaterialClassUnidadeMedidaCompra) 
                 { 
                     _collectionMaterialClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialClassUnidadeMedidaCompra()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialClass> oc;
                _valueCollectionMaterialClassUnidadeMedidaCompraChanged = false;
                 _valueCollectionMaterialClassUnidadeMedidaCompraCommitedChanged = false;
                _collectionMaterialClassUnidadeMedidaCompraRemovidos = new List<Entidades.MaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialClass>();
                }
                else{ 
                   Entidades.MaterialClass search = new Entidades.MaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaCompra", this),                     }                       ).Cast<Entidades.MaterialClass>().ToList());
                 }
                 _valueCollectionMaterialClassUnidadeMedidaCompra = new BindingList<Entidades.MaterialClass>(oc); 
                 _collectionMaterialClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionMaterialClassUnidadeMedidaCompra select a.ID).ToList();
                 _valueCollectionMaterialClassUnidadeMedidaCompraLoaded = true;
                 oc.CollectionChanged += CollectionMaterialClassUnidadeMedidaCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialClassUnidadeMedidaCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMaterialFornecedorClassUnidadeMedidaCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraChanged = true;
                  _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.MaterialFornecedorClass item in e.OldItems) 
                 { 
                     _collectionMaterialFornecedorClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.MaterialFornecedorClass item in _valueCollectionMaterialFornecedorClassUnidadeMedidaCompra) 
                 { 
                     _collectionMaterialFornecedorClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialFornecedorClassUnidadeMedidaCompra()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialFornecedorClass> oc;
                _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraChanged = false;
                 _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraCommitedChanged = false;
                _collectionMaterialFornecedorClassUnidadeMedidaCompraRemovidos = new List<Entidades.MaterialFornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialFornecedorClass>();
                }
                else{ 
                   Entidades.MaterialFornecedorClass search = new Entidades.MaterialFornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialFornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaCompra", this),                     }                       ).Cast<Entidades.MaterialFornecedorClass>().ToList());
                 }
                 _valueCollectionMaterialFornecedorClassUnidadeMedidaCompra = new BindingList<Entidades.MaterialFornecedorClass>(oc); 
                 _collectionMaterialFornecedorClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionMaterialFornecedorClassUnidadeMedidaCompra select a.ID).ToList();
                 _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded = true;
                 oc.CollectionChanged += CollectionMaterialFornecedorClassUnidadeMedidaCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialFornecedorClassUnidadeMedidaCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaClassUnidadeMedidaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaClassUnidadeMedidaChanged = true;
                  _valueCollectionOrderItemEtiquetaClassUnidadeMedidaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaClassUnidadeMedidaChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassUnidadeMedidaCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaClassUnidadeMedidaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaClassUnidadeMedidaChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassUnidadeMedidaCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in _valueCollectionOrderItemEtiquetaClassUnidadeMedida) 
                 { 
                     _collectionOrderItemEtiquetaClassUnidadeMedidaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaClassUnidadeMedida()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaClass> oc;
                _valueCollectionOrderItemEtiquetaClassUnidadeMedidaChanged = false;
                 _valueCollectionOrderItemEtiquetaClassUnidadeMedidaCommitedChanged = false;
                _collectionOrderItemEtiquetaClassUnidadeMedidaRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaClass search = new Entidades.OrderItemEtiquetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedida", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaClassUnidadeMedida = new BindingList<Entidades.OrderItemEtiquetaClass>(oc); 
                 _collectionOrderItemEtiquetaClassUnidadeMedidaOriginal= (from a in _valueCollectionOrderItemEtiquetaClassUnidadeMedida select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaClassUnidadeMedidaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaClassUnidadeMedida+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaChanged = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaChanged = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaCommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedida", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Changed = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Changed = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1CommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaDimensao1", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1 = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1 select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Changed = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Changed = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2CommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaDimensao2", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2 = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2 select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Changed = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Changed = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3CommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaDimensao3", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3 = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3 select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemClassUnidadeMedida1ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida1Changed = true;
                  _valueCollectionPlanoCorteItemClassUnidadeMedida1CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida1Changed = true; 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida1CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemClassUnidadeMedida1Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida1Changed = true; 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida1CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in _valueCollectionPlanoCorteItemClassUnidadeMedida1) 
                 { 
                     _collectionPlanoCorteItemClassUnidadeMedida1Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemClassUnidadeMedida1()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemClass> oc;
                _valueCollectionPlanoCorteItemClassUnidadeMedida1Changed = false;
                 _valueCollectionPlanoCorteItemClassUnidadeMedida1CommitedChanged = false;
                _collectionPlanoCorteItemClassUnidadeMedida1Removidos = new List<Entidades.PlanoCorteItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemClass search = new Entidades.PlanoCorteItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedida1", this)                    }                       ).Cast<Entidades.PlanoCorteItemClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemClassUnidadeMedida1 = new BindingList<Entidades.PlanoCorteItemClass>(oc); 
                 _collectionPlanoCorteItemClassUnidadeMedida1Original= (from a in _valueCollectionPlanoCorteItemClassUnidadeMedida1 select a.ID).ToList();
                 _valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemClassUnidadeMedida1ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemClassUnidadeMedida1+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemClassUnidadeMedida2ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida2Changed = true;
                  _valueCollectionPlanoCorteItemClassUnidadeMedida2CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida2Changed = true; 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida2CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemClassUnidadeMedida2Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida2Changed = true; 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida2CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in _valueCollectionPlanoCorteItemClassUnidadeMedida2) 
                 { 
                     _collectionPlanoCorteItemClassUnidadeMedida2Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemClassUnidadeMedida2()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemClass> oc;
                _valueCollectionPlanoCorteItemClassUnidadeMedida2Changed = false;
                 _valueCollectionPlanoCorteItemClassUnidadeMedida2CommitedChanged = false;
                _collectionPlanoCorteItemClassUnidadeMedida2Removidos = new List<Entidades.PlanoCorteItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemClass search = new Entidades.PlanoCorteItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedida2", this)                    }                       ).Cast<Entidades.PlanoCorteItemClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemClassUnidadeMedida2 = new BindingList<Entidades.PlanoCorteItemClass>(oc); 
                 _collectionPlanoCorteItemClassUnidadeMedida2Original= (from a in _valueCollectionPlanoCorteItemClassUnidadeMedida2 select a.ID).ToList();
                 _valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemClassUnidadeMedida2ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemClassUnidadeMedida2+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemClassUnidadeMedida3ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida3Changed = true;
                  _valueCollectionPlanoCorteItemClassUnidadeMedida3CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida3Changed = true; 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida3CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemClassUnidadeMedida3Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida3Changed = true; 
                  _valueCollectionPlanoCorteItemClassUnidadeMedida3CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in _valueCollectionPlanoCorteItemClassUnidadeMedida3) 
                 { 
                     _collectionPlanoCorteItemClassUnidadeMedida3Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemClassUnidadeMedida3()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemClass> oc;
                _valueCollectionPlanoCorteItemClassUnidadeMedida3Changed = false;
                 _valueCollectionPlanoCorteItemClassUnidadeMedida3CommitedChanged = false;
                _collectionPlanoCorteItemClassUnidadeMedida3Removidos = new List<Entidades.PlanoCorteItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemClass search = new Entidades.PlanoCorteItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedida3", this)                    }                       ).Cast<Entidades.PlanoCorteItemClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemClassUnidadeMedida3 = new BindingList<Entidades.PlanoCorteItemClass>(oc); 
                 _collectionPlanoCorteItemClassUnidadeMedida3Original= (from a in _valueCollectionPlanoCorteItemClassUnidadeMedida3 select a.ID).ToList();
                 _valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemClassUnidadeMedida3ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemClassUnidadeMedida3+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassUnidadeMedidaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassUnidadeMedidaChanged = true;
                  _valueCollectionProdutoClassUnidadeMedidaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassUnidadeMedidaChanged = true; 
                  _valueCollectionProdutoClassUnidadeMedidaCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassUnidadeMedidaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassUnidadeMedidaChanged = true; 
                  _valueCollectionProdutoClassUnidadeMedidaCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassUnidadeMedida) 
                 { 
                     _collectionProdutoClassUnidadeMedidaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassUnidadeMedida()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassUnidadeMedidaChanged = false;
                 _valueCollectionProdutoClassUnidadeMedidaCommitedChanged = false;
                _collectionProdutoClassUnidadeMedidaRemovidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedida", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassUnidadeMedida = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassUnidadeMedidaOriginal= (from a in _valueCollectionProdutoClassUnidadeMedida select a.ID).ToList();
                 _valueCollectionProdutoClassUnidadeMedidaLoaded = true;
                 oc.CollectionChanged += CollectionProdutoClassUnidadeMedidaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassUnidadeMedida+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassUnidadeMedidaCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassUnidadeMedidaCompraChanged = true;
                  _valueCollectionProdutoClassUnidadeMedidaCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionProdutoClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionProdutoClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassUnidadeMedidaCompra) 
                 { 
                     _collectionProdutoClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassUnidadeMedidaCompra()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassUnidadeMedidaCompraChanged = false;
                 _valueCollectionProdutoClassUnidadeMedidaCompraCommitedChanged = false;
                _collectionProdutoClassUnidadeMedidaCompraRemovidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaCompra", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassUnidadeMedidaCompra = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionProdutoClassUnidadeMedidaCompra select a.ID).ToList();
                 _valueCollectionProdutoClassUnidadeMedidaCompraLoaded = true;
                 oc.CollectionChanged += CollectionProdutoClassUnidadeMedidaCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassUnidadeMedidaCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoFornecedorClassUnidadeMedidaCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraChanged = true;
                  _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.ProdutoFornecedorClass item in e.OldItems) 
                 { 
                     _collectionProdutoFornecedorClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraChanged = true; 
                  _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraCommitedChanged = true;
                 foreach (Entidades.ProdutoFornecedorClass item in _valueCollectionProdutoFornecedorClassUnidadeMedidaCompra) 
                 { 
                     _collectionProdutoFornecedorClassUnidadeMedidaCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoFornecedorClassUnidadeMedidaCompra()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoFornecedorClass> oc;
                _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraChanged = false;
                 _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraCommitedChanged = false;
                _collectionProdutoFornecedorClassUnidadeMedidaCompraRemovidos = new List<Entidades.ProdutoFornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoFornecedorClass>();
                }
                else{ 
                   Entidades.ProdutoFornecedorClass search = new Entidades.ProdutoFornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoFornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaCompra", this),                     }                       ).Cast<Entidades.ProdutoFornecedorClass>().ToList());
                 }
                 _valueCollectionProdutoFornecedorClassUnidadeMedidaCompra = new BindingList<Entidades.ProdutoFornecedorClass>(oc); 
                 _collectionProdutoFornecedorClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionProdutoFornecedorClassUnidadeMedidaCompra select a.ID).ToList();
                 _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded = true;
                 oc.CollectionChanged += CollectionProdutoFornecedorClassUnidadeMedidaCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoFornecedorClassUnidadeMedidaCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoMaterialClassUnidadeMedidaDimensao1ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Changed = true;
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Changed = true; 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in e.OldItems) 
                 { 
                     _collectionProdutoMaterialClassUnidadeMedidaDimensao1Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Changed = true; 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1) 
                 { 
                     _collectionProdutoMaterialClassUnidadeMedidaDimensao1Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoMaterialClassUnidadeMedidaDimensao1()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoMaterialClass> oc;
                _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Changed = false;
                 _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1CommitedChanged = false;
                _collectionProdutoMaterialClassUnidadeMedidaDimensao1Removidos = new List<Entidades.ProdutoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoMaterialClass>();
                }
                else{ 
                   Entidades.ProdutoMaterialClass search = new Entidades.ProdutoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaDimensao1", this),                     }                       ).Cast<Entidades.ProdutoMaterialClass>().ToList());
                 }
                 _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1 = new BindingList<Entidades.ProdutoMaterialClass>(oc); 
                 _collectionProdutoMaterialClassUnidadeMedidaDimensao1Original= (from a in _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1 select a.ID).ToList();
                 _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded = true;
                 oc.CollectionChanged += CollectionProdutoMaterialClassUnidadeMedidaDimensao1ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoMaterialClassUnidadeMedidaDimensao1+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoMaterialClassUnidadeMedidaDimensao2ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Changed = true;
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Changed = true; 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in e.OldItems) 
                 { 
                     _collectionProdutoMaterialClassUnidadeMedidaDimensao2Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Changed = true; 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2) 
                 { 
                     _collectionProdutoMaterialClassUnidadeMedidaDimensao2Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoMaterialClassUnidadeMedidaDimensao2()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoMaterialClass> oc;
                _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Changed = false;
                 _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2CommitedChanged = false;
                _collectionProdutoMaterialClassUnidadeMedidaDimensao2Removidos = new List<Entidades.ProdutoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoMaterialClass>();
                }
                else{ 
                   Entidades.ProdutoMaterialClass search = new Entidades.ProdutoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaDimensao2", this),                     }                       ).Cast<Entidades.ProdutoMaterialClass>().ToList());
                 }
                 _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2 = new BindingList<Entidades.ProdutoMaterialClass>(oc); 
                 _collectionProdutoMaterialClassUnidadeMedidaDimensao2Original= (from a in _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2 select a.ID).ToList();
                 _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded = true;
                 oc.CollectionChanged += CollectionProdutoMaterialClassUnidadeMedidaDimensao2ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoMaterialClassUnidadeMedidaDimensao2+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoMaterialClassUnidadeMedidaDimensao3ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Changed = true;
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Changed = true; 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in e.OldItems) 
                 { 
                     _collectionProdutoMaterialClassUnidadeMedidaDimensao3Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Changed = true; 
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3) 
                 { 
                     _collectionProdutoMaterialClassUnidadeMedidaDimensao3Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoMaterialClassUnidadeMedidaDimensao3()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoMaterialClass> oc;
                _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Changed = false;
                 _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3CommitedChanged = false;
                _collectionProdutoMaterialClassUnidadeMedidaDimensao3Removidos = new List<Entidades.ProdutoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoMaterialClass>();
                }
                else{ 
                   Entidades.ProdutoMaterialClass search = new Entidades.ProdutoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("UnidadeMedidaDimensao3", this),                     }                       ).Cast<Entidades.ProdutoMaterialClass>().ToList());
                 }
                 _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3 = new BindingList<Entidades.ProdutoMaterialClass>(oc); 
                 _collectionProdutoMaterialClassUnidadeMedidaDimensao3Original= (from a in _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3 select a.ID).ToList();
                 _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded = true;
                 oc.CollectionChanged += CollectionProdutoMaterialClassUnidadeMedidaDimensao3ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoMaterialClassUnidadeMedidaDimensao3+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Abreviada))
                {
                    throw new Exception(ErroAbreviadaObrigatorio);
                }
                if (Abreviada.Length >255)
                {
                    throw new Exception( ErroAbreviadaComprimento);
                }
                if (string.IsNullOrEmpty(NomeUnidade))
                {
                    throw new Exception(ErroNomeUnidadeObrigatorio);
                }
                if (NomeUnidade.Length >255)
                {
                    throw new Exception( ErroNomeUnidadeComprimento);
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
                    "  public.unidade_medida  " +
                    "WHERE " +
                    "  id_unidade_medida = :id";
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
                        "  public.unidade_medida   " +
                        "SET  " + 
                        "  unm_abreviada = :unm_abreviada, " + 
                        "  unm_nome_unidade = :unm_nome_unidade, " + 
                        "  unm_obs = :unm_obs, " + 
                        "  unm_ultima_revisao = :unm_ultima_revisao, " + 
                        "  unm_ultima_revisao_data = :unm_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_unidade_medida = :id " +
                        "RETURNING id_unidade_medida;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.unidade_medida " +
                        "( " +
                        "  unm_abreviada , " + 
                        "  unm_nome_unidade , " + 
                        "  unm_obs , " + 
                        "  unm_ultima_revisao , " + 
                        "  unm_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :unm_abreviada , " + 
                        "  :unm_nome_unidade , " + 
                        "  :unm_obs , " + 
                        "  :unm_ultima_revisao , " + 
                        "  :unm_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_unidade_medida;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unm_abreviada", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Abreviada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unm_nome_unidade", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeUnidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unm_obs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Obs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unm_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unm_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;

 
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
 if (CollectionEpiClassUnidadeMedidaCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEpiClassUnidadeMedidaCompra+"\r\n";
                foreach (Entidades.EpiClass tmp in CollectionEpiClassUnidadeMedidaCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionEpiClassUnidadeMedidaUso.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEpiClassUnidadeMedidaUso+"\r\n";
                foreach (Entidades.EpiClass tmp in CollectionEpiClassUnidadeMedidaUso)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionEpiFornecedorClassUnidadeMedidaCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEpiFornecedorClassUnidadeMedidaCompra+"\r\n";
                foreach (Entidades.EpiFornecedorClass tmp in CollectionEpiFornecedorClassUnidadeMedidaCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMaterialClassUnidadeMedida.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialClassUnidadeMedida+"\r\n";
                foreach (Entidades.MaterialClass tmp in CollectionMaterialClassUnidadeMedida)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMaterialClassUnidadeMedidaCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialClassUnidadeMedidaCompra+"\r\n";
                foreach (Entidades.MaterialClass tmp in CollectionMaterialClassUnidadeMedidaCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMaterialFornecedorClassUnidadeMedidaCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialFornecedorClassUnidadeMedidaCompra+"\r\n";
                foreach (Entidades.MaterialFornecedorClass tmp in CollectionMaterialFornecedorClassUnidadeMedidaCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaClassUnidadeMedida.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaClassUnidadeMedida+"\r\n";
                foreach (Entidades.OrderItemEtiquetaClass tmp in CollectionOrderItemEtiquetaClassUnidadeMedida)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassUnidadeMedida.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedida)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemClassUnidadeMedida1.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemClassUnidadeMedida1+"\r\n";
                foreach (Entidades.PlanoCorteItemClass tmp in CollectionPlanoCorteItemClassUnidadeMedida1)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemClassUnidadeMedida2.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemClassUnidadeMedida2+"\r\n";
                foreach (Entidades.PlanoCorteItemClass tmp in CollectionPlanoCorteItemClassUnidadeMedida2)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemClassUnidadeMedida3.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemClassUnidadeMedida3+"\r\n";
                foreach (Entidades.PlanoCorteItemClass tmp in CollectionPlanoCorteItemClassUnidadeMedida3)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassUnidadeMedida.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassUnidadeMedida+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassUnidadeMedida)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassUnidadeMedidaCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassUnidadeMedidaCompra+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassUnidadeMedidaCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoFornecedorClassUnidadeMedidaCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoFornecedorClassUnidadeMedidaCompra+"\r\n";
                foreach (Entidades.ProdutoFornecedorClass tmp in CollectionProdutoFornecedorClassUnidadeMedidaCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoMaterialClassUnidadeMedidaDimensao1.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassUnidadeMedidaDimensao1+"\r\n";
                foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassUnidadeMedidaDimensao1)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoMaterialClassUnidadeMedidaDimensao2.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassUnidadeMedidaDimensao2+"\r\n";
                foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassUnidadeMedidaDimensao2)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoMaterialClassUnidadeMedidaDimensao3.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassUnidadeMedidaDimensao3+"\r\n";
                foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassUnidadeMedidaDimensao3)
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
        public static UnidadeMedidaClass CopiarEntidade(UnidadeMedidaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               UnidadeMedidaClass toRet = new UnidadeMedidaClass(usuario,conn);
 toRet.Abreviada= entidadeCopiar.Abreviada;
 toRet.NomeUnidade= entidadeCopiar.NomeUnidade;
 toRet.Obs= entidadeCopiar.Obs;

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
       _abreviadaOriginal = Abreviada;
       _abreviadaOriginalCommited = _abreviadaOriginal;
       _nomeUnidadeOriginal = NomeUnidade;
       _nomeUnidadeOriginalCommited = _nomeUnidadeOriginal;
       _obsOriginal = Obs;
       _obsOriginalCommited = _obsOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;

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
       _abreviadaOriginalCommited = Abreviada;
       _nomeUnidadeOriginalCommited = NomeUnidade;
       _obsOriginalCommited = Obs;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;

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
               if (_valueCollectionEpiClassUnidadeMedidaCompraLoaded) 
               {
                  if (_collectionEpiClassUnidadeMedidaCompraRemovidos != null) 
                  {
                     _collectionEpiClassUnidadeMedidaCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEpiClassUnidadeMedidaCompraRemovidos = new List<Entidades.EpiClass>();
                  }
                  _collectionEpiClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionEpiClassUnidadeMedidaCompra select a.ID).ToList();
                  _valueCollectionEpiClassUnidadeMedidaCompraChanged = false;
                  _valueCollectionEpiClassUnidadeMedidaCompraCommitedChanged = false;
               }
               if (_valueCollectionEpiClassUnidadeMedidaUsoLoaded) 
               {
                  if (_collectionEpiClassUnidadeMedidaUsoRemovidos != null) 
                  {
                     _collectionEpiClassUnidadeMedidaUsoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEpiClassUnidadeMedidaUsoRemovidos = new List<Entidades.EpiClass>();
                  }
                  _collectionEpiClassUnidadeMedidaUsoOriginal= (from a in _valueCollectionEpiClassUnidadeMedidaUso select a.ID).ToList();
                  _valueCollectionEpiClassUnidadeMedidaUsoChanged = false;
                  _valueCollectionEpiClassUnidadeMedidaUsoCommitedChanged = false;
               }
               if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  if (_collectionEpiFornecedorClassUnidadeMedidaCompraRemovidos != null) 
                  {
                     _collectionEpiFornecedorClassUnidadeMedidaCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEpiFornecedorClassUnidadeMedidaCompraRemovidos = new List<Entidades.EpiFornecedorClass>();
                  }
                  _collectionEpiFornecedorClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionEpiFornecedorClassUnidadeMedidaCompra select a.ID).ToList();
                  _valueCollectionEpiFornecedorClassUnidadeMedidaCompraChanged = false;
                  _valueCollectionEpiFornecedorClassUnidadeMedidaCompraCommitedChanged = false;
               }
               if (_valueCollectionMaterialClassUnidadeMedidaLoaded) 
               {
                  if (_collectionMaterialClassUnidadeMedidaRemovidos != null) 
                  {
                     _collectionMaterialClassUnidadeMedidaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialClassUnidadeMedidaRemovidos = new List<Entidades.MaterialClass>();
                  }
                  _collectionMaterialClassUnidadeMedidaOriginal= (from a in _valueCollectionMaterialClassUnidadeMedida select a.ID).ToList();
                  _valueCollectionMaterialClassUnidadeMedidaChanged = false;
                  _valueCollectionMaterialClassUnidadeMedidaCommitedChanged = false;
               }
               if (_valueCollectionMaterialClassUnidadeMedidaCompraLoaded) 
               {
                  if (_collectionMaterialClassUnidadeMedidaCompraRemovidos != null) 
                  {
                     _collectionMaterialClassUnidadeMedidaCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialClassUnidadeMedidaCompraRemovidos = new List<Entidades.MaterialClass>();
                  }
                  _collectionMaterialClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionMaterialClassUnidadeMedidaCompra select a.ID).ToList();
                  _valueCollectionMaterialClassUnidadeMedidaCompraChanged = false;
                  _valueCollectionMaterialClassUnidadeMedidaCompraCommitedChanged = false;
               }
               if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  if (_collectionMaterialFornecedorClassUnidadeMedidaCompraRemovidos != null) 
                  {
                     _collectionMaterialFornecedorClassUnidadeMedidaCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialFornecedorClassUnidadeMedidaCompraRemovidos = new List<Entidades.MaterialFornecedorClass>();
                  }
                  _collectionMaterialFornecedorClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionMaterialFornecedorClassUnidadeMedidaCompra select a.ID).ToList();
                  _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraChanged = false;
                  _valueCollectionMaterialFornecedorClassUnidadeMedidaCompraCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded) 
               {
                  if (_collectionOrderItemEtiquetaClassUnidadeMedidaRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaClassUnidadeMedidaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaClassUnidadeMedidaRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                  }
                  _collectionOrderItemEtiquetaClassUnidadeMedidaOriginal= (from a in _valueCollectionOrderItemEtiquetaClassUnidadeMedida select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaClassUnidadeMedidaChanged = false;
                  _valueCollectionOrderItemEtiquetaClassUnidadeMedidaCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaRemovidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedida select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaChanged = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Removidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1 select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Changed = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1CommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Removidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2 select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Changed = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2CommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Removidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3 select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Changed = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3CommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded) 
               {
                  if (_collectionPlanoCorteItemClassUnidadeMedida1Removidos != null) 
                  {
                     _collectionPlanoCorteItemClassUnidadeMedida1Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemClassUnidadeMedida1Removidos = new List<Entidades.PlanoCorteItemClass>();
                  }
                  _collectionPlanoCorteItemClassUnidadeMedida1Original= (from a in _valueCollectionPlanoCorteItemClassUnidadeMedida1 select a.ID).ToList();
                  _valueCollectionPlanoCorteItemClassUnidadeMedida1Changed = false;
                  _valueCollectionPlanoCorteItemClassUnidadeMedida1CommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded) 
               {
                  if (_collectionPlanoCorteItemClassUnidadeMedida2Removidos != null) 
                  {
                     _collectionPlanoCorteItemClassUnidadeMedida2Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemClassUnidadeMedida2Removidos = new List<Entidades.PlanoCorteItemClass>();
                  }
                  _collectionPlanoCorteItemClassUnidadeMedida2Original= (from a in _valueCollectionPlanoCorteItemClassUnidadeMedida2 select a.ID).ToList();
                  _valueCollectionPlanoCorteItemClassUnidadeMedida2Changed = false;
                  _valueCollectionPlanoCorteItemClassUnidadeMedida2CommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded) 
               {
                  if (_collectionPlanoCorteItemClassUnidadeMedida3Removidos != null) 
                  {
                     _collectionPlanoCorteItemClassUnidadeMedida3Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemClassUnidadeMedida3Removidos = new List<Entidades.PlanoCorteItemClass>();
                  }
                  _collectionPlanoCorteItemClassUnidadeMedida3Original= (from a in _valueCollectionPlanoCorteItemClassUnidadeMedida3 select a.ID).ToList();
                  _valueCollectionPlanoCorteItemClassUnidadeMedida3Changed = false;
                  _valueCollectionPlanoCorteItemClassUnidadeMedida3CommitedChanged = false;
               }
               if (_valueCollectionProdutoClassUnidadeMedidaLoaded) 
               {
                  if (_collectionProdutoClassUnidadeMedidaRemovidos != null) 
                  {
                     _collectionProdutoClassUnidadeMedidaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassUnidadeMedidaRemovidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassUnidadeMedidaOriginal= (from a in _valueCollectionProdutoClassUnidadeMedida select a.ID).ToList();
                  _valueCollectionProdutoClassUnidadeMedidaChanged = false;
                  _valueCollectionProdutoClassUnidadeMedidaCommitedChanged = false;
               }
               if (_valueCollectionProdutoClassUnidadeMedidaCompraLoaded) 
               {
                  if (_collectionProdutoClassUnidadeMedidaCompraRemovidos != null) 
                  {
                     _collectionProdutoClassUnidadeMedidaCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassUnidadeMedidaCompraRemovidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionProdutoClassUnidadeMedidaCompra select a.ID).ToList();
                  _valueCollectionProdutoClassUnidadeMedidaCompraChanged = false;
                  _valueCollectionProdutoClassUnidadeMedidaCompraCommitedChanged = false;
               }
               if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  if (_collectionProdutoFornecedorClassUnidadeMedidaCompraRemovidos != null) 
                  {
                     _collectionProdutoFornecedorClassUnidadeMedidaCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoFornecedorClassUnidadeMedidaCompraRemovidos = new List<Entidades.ProdutoFornecedorClass>();
                  }
                  _collectionProdutoFornecedorClassUnidadeMedidaCompraOriginal= (from a in _valueCollectionProdutoFornecedorClassUnidadeMedidaCompra select a.ID).ToList();
                  _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraChanged = false;
                  _valueCollectionProdutoFornecedorClassUnidadeMedidaCompraCommitedChanged = false;
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  if (_collectionProdutoMaterialClassUnidadeMedidaDimensao1Removidos != null) 
                  {
                     _collectionProdutoMaterialClassUnidadeMedidaDimensao1Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoMaterialClassUnidadeMedidaDimensao1Removidos = new List<Entidades.ProdutoMaterialClass>();
                  }
                  _collectionProdutoMaterialClassUnidadeMedidaDimensao1Original= (from a in _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1 select a.ID).ToList();
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Changed = false;
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1CommitedChanged = false;
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  if (_collectionProdutoMaterialClassUnidadeMedidaDimensao2Removidos != null) 
                  {
                     _collectionProdutoMaterialClassUnidadeMedidaDimensao2Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoMaterialClassUnidadeMedidaDimensao2Removidos = new List<Entidades.ProdutoMaterialClass>();
                  }
                  _collectionProdutoMaterialClassUnidadeMedidaDimensao2Original= (from a in _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2 select a.ID).ToList();
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Changed = false;
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2CommitedChanged = false;
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  if (_collectionProdutoMaterialClassUnidadeMedidaDimensao3Removidos != null) 
                  {
                     _collectionProdutoMaterialClassUnidadeMedidaDimensao3Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoMaterialClassUnidadeMedidaDimensao3Removidos = new List<Entidades.ProdutoMaterialClass>();
                  }
                  _collectionProdutoMaterialClassUnidadeMedidaDimensao3Original= (from a in _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3 select a.ID).ToList();
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Changed = false;
                  _valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3CommitedChanged = false;
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
               Abreviada=_abreviadaOriginal;
               _abreviadaOriginalCommited=_abreviadaOriginal;
               NomeUnidade=_nomeUnidadeOriginal;
               _nomeUnidadeOriginalCommited=_nomeUnidadeOriginal;
               Obs=_obsOriginal;
               _obsOriginalCommited=_obsOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionEpiClassUnidadeMedidaCompraLoaded) 
               {
                  CollectionEpiClassUnidadeMedidaCompra.Clear();
                  foreach(int item in _collectionEpiClassUnidadeMedidaCompraOriginal)
                  {
                    CollectionEpiClassUnidadeMedidaCompra.Add(Entidades.EpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEpiClassUnidadeMedidaCompraRemovidos.Clear();
               }
               if (_valueCollectionEpiClassUnidadeMedidaUsoLoaded) 
               {
                  CollectionEpiClassUnidadeMedidaUso.Clear();
                  foreach(int item in _collectionEpiClassUnidadeMedidaUsoOriginal)
                  {
                    CollectionEpiClassUnidadeMedidaUso.Add(Entidades.EpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEpiClassUnidadeMedidaUsoRemovidos.Clear();
               }
               if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  CollectionEpiFornecedorClassUnidadeMedidaCompra.Clear();
                  foreach(int item in _collectionEpiFornecedorClassUnidadeMedidaCompraOriginal)
                  {
                    CollectionEpiFornecedorClassUnidadeMedidaCompra.Add(Entidades.EpiFornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEpiFornecedorClassUnidadeMedidaCompraRemovidos.Clear();
               }
               if (_valueCollectionMaterialClassUnidadeMedidaLoaded) 
               {
                  CollectionMaterialClassUnidadeMedida.Clear();
                  foreach(int item in _collectionMaterialClassUnidadeMedidaOriginal)
                  {
                    CollectionMaterialClassUnidadeMedida.Add(Entidades.MaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialClassUnidadeMedidaRemovidos.Clear();
               }
               if (_valueCollectionMaterialClassUnidadeMedidaCompraLoaded) 
               {
                  CollectionMaterialClassUnidadeMedidaCompra.Clear();
                  foreach(int item in _collectionMaterialClassUnidadeMedidaCompraOriginal)
                  {
                    CollectionMaterialClassUnidadeMedidaCompra.Add(Entidades.MaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialClassUnidadeMedidaCompraRemovidos.Clear();
               }
               if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  CollectionMaterialFornecedorClassUnidadeMedidaCompra.Clear();
                  foreach(int item in _collectionMaterialFornecedorClassUnidadeMedidaCompraOriginal)
                  {
                    CollectionMaterialFornecedorClassUnidadeMedidaCompra.Add(Entidades.MaterialFornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialFornecedorClassUnidadeMedidaCompraRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded) 
               {
                  CollectionOrderItemEtiquetaClassUnidadeMedida.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaClassUnidadeMedidaOriginal)
                  {
                    CollectionOrderItemEtiquetaClassUnidadeMedida.Add(Entidades.OrderItemEtiquetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaClassUnidadeMedidaRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassUnidadeMedida.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaOriginal)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassUnidadeMedida.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Original)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Removidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Original)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Removidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Original)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Removidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded) 
               {
                  CollectionPlanoCorteItemClassUnidadeMedida1.Clear();
                  foreach(int item in _collectionPlanoCorteItemClassUnidadeMedida1Original)
                  {
                    CollectionPlanoCorteItemClassUnidadeMedida1.Add(Entidades.PlanoCorteItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemClassUnidadeMedida1Removidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded) 
               {
                  CollectionPlanoCorteItemClassUnidadeMedida2.Clear();
                  foreach(int item in _collectionPlanoCorteItemClassUnidadeMedida2Original)
                  {
                    CollectionPlanoCorteItemClassUnidadeMedida2.Add(Entidades.PlanoCorteItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemClassUnidadeMedida2Removidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded) 
               {
                  CollectionPlanoCorteItemClassUnidadeMedida3.Clear();
                  foreach(int item in _collectionPlanoCorteItemClassUnidadeMedida3Original)
                  {
                    CollectionPlanoCorteItemClassUnidadeMedida3.Add(Entidades.PlanoCorteItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemClassUnidadeMedida3Removidos.Clear();
               }
               if (_valueCollectionProdutoClassUnidadeMedidaLoaded) 
               {
                  CollectionProdutoClassUnidadeMedida.Clear();
                  foreach(int item in _collectionProdutoClassUnidadeMedidaOriginal)
                  {
                    CollectionProdutoClassUnidadeMedida.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassUnidadeMedidaRemovidos.Clear();
               }
               if (_valueCollectionProdutoClassUnidadeMedidaCompraLoaded) 
               {
                  CollectionProdutoClassUnidadeMedidaCompra.Clear();
                  foreach(int item in _collectionProdutoClassUnidadeMedidaCompraOriginal)
                  {
                    CollectionProdutoClassUnidadeMedidaCompra.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassUnidadeMedidaCompraRemovidos.Clear();
               }
               if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  CollectionProdutoFornecedorClassUnidadeMedidaCompra.Clear();
                  foreach(int item in _collectionProdutoFornecedorClassUnidadeMedidaCompraOriginal)
                  {
                    CollectionProdutoFornecedorClassUnidadeMedidaCompra.Add(Entidades.ProdutoFornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoFornecedorClassUnidadeMedidaCompraRemovidos.Clear();
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  CollectionProdutoMaterialClassUnidadeMedidaDimensao1.Clear();
                  foreach(int item in _collectionProdutoMaterialClassUnidadeMedidaDimensao1Original)
                  {
                    CollectionProdutoMaterialClassUnidadeMedidaDimensao1.Add(Entidades.ProdutoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoMaterialClassUnidadeMedidaDimensao1Removidos.Clear();
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  CollectionProdutoMaterialClassUnidadeMedidaDimensao2.Clear();
                  foreach(int item in _collectionProdutoMaterialClassUnidadeMedidaDimensao2Original)
                  {
                    CollectionProdutoMaterialClassUnidadeMedidaDimensao2.Add(Entidades.ProdutoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoMaterialClassUnidadeMedidaDimensao2Removidos.Clear();
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  CollectionProdutoMaterialClassUnidadeMedidaDimensao3.Clear();
                  foreach(int item in _collectionProdutoMaterialClassUnidadeMedidaDimensao3Original)
                  {
                    CollectionProdutoMaterialClassUnidadeMedidaDimensao3.Add(Entidades.ProdutoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoMaterialClassUnidadeMedidaDimensao3Removidos.Clear();
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
               if (_valueCollectionEpiClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionEpiClassUnidadeMedidaCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiClassUnidadeMedidaUsoLoaded) 
               {
                  if (_valueCollectionEpiClassUnidadeMedidaUsoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassUnidadeMedidaLoaded) 
               {
                  if (_valueCollectionMaterialClassUnidadeMedidaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionMaterialClassUnidadeMedidaCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassUnidadeMedida1Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassUnidadeMedida2Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassUnidadeMedida3Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassUnidadeMedidaLoaded) 
               {
                  if (_valueCollectionProdutoClassUnidadeMedidaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionProdutoClassUnidadeMedidaCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionEpiClassUnidadeMedidaCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionEpiClassUnidadeMedidaUsoLoaded) 
               {
                   tempRet = CollectionEpiClassUnidadeMedidaUso.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionEpiFornecedorClassUnidadeMedidaCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialClassUnidadeMedidaLoaded) 
               {
                   tempRet = CollectionMaterialClassUnidadeMedida.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionMaterialClassUnidadeMedidaCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionMaterialFornecedorClassUnidadeMedidaCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassUnidadeMedida.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassUnidadeMedida.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassUnidadeMedida1.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassUnidadeMedida2.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassUnidadeMedida3.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassUnidadeMedidaLoaded) 
               {
                   tempRet = CollectionProdutoClassUnidadeMedida.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionProdutoClassUnidadeMedidaCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionProdutoFornecedorClassUnidadeMedidaCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassUnidadeMedidaDimensao1.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassUnidadeMedidaDimensao2.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassUnidadeMedidaDimensao3.Any(item => item.IsDirty());
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
       dirty = _abreviadaOriginal != Abreviada;
      if (dirty) return true;
       dirty = _nomeUnidadeOriginal != NomeUnidade;
      if (dirty) return true;
       dirty = _obsOriginal != Obs;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;

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
               if (_valueCollectionEpiClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionEpiClassUnidadeMedidaCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiClassUnidadeMedidaUsoLoaded) 
               {
                  if (_valueCollectionEpiClassUnidadeMedidaUsoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassUnidadeMedidaLoaded) 
               {
                  if (_valueCollectionMaterialClassUnidadeMedidaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionMaterialClassUnidadeMedidaCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassUnidadeMedida1CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassUnidadeMedida2CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassUnidadeMedida3CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassUnidadeMedidaLoaded) 
               {
                  if (_valueCollectionProdutoClassUnidadeMedidaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionProdutoClassUnidadeMedidaCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionEpiClassUnidadeMedidaCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionEpiClassUnidadeMedidaUsoLoaded) 
               {
                   tempRet = CollectionEpiClassUnidadeMedidaUso.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionEpiFornecedorClassUnidadeMedidaCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialClassUnidadeMedidaLoaded) 
               {
                   tempRet = CollectionMaterialClassUnidadeMedida.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionMaterialClassUnidadeMedidaCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionMaterialFornecedorClassUnidadeMedidaCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassUnidadeMedida.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassUnidadeMedida.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassUnidadeMedida1.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassUnidadeMedida2.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassUnidadeMedida3.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassUnidadeMedidaLoaded) 
               {
                   tempRet = CollectionProdutoClassUnidadeMedida.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionProdutoClassUnidadeMedidaCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                   tempRet = CollectionProdutoFornecedorClassUnidadeMedidaCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassUnidadeMedidaDimensao1.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassUnidadeMedidaDimensao2.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassUnidadeMedidaDimensao3.Any(item => item.IsDirtyCommited());
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
       dirty = _abreviadaOriginalCommited != Abreviada;
      if (dirty) return true;
       dirty = _nomeUnidadeOriginalCommited != NomeUnidade;
      if (dirty) return true;
       dirty = _obsOriginalCommited != Obs;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;

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
               if (_valueCollectionEpiClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(EpiClass item in CollectionEpiClassUnidadeMedidaCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionEpiClassUnidadeMedidaUsoLoaded) 
               {
                  foreach(EpiClass item in CollectionEpiClassUnidadeMedidaUso)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(EpiFornecedorClass item in CollectionEpiFornecedorClassUnidadeMedidaCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMaterialClassUnidadeMedidaLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassUnidadeMedida)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMaterialClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassUnidadeMedidaCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(MaterialFornecedorClass item in CollectionMaterialFornecedorClassUnidadeMedidaCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassUnidadeMedida)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedida)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassUnidadeMedida1)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassUnidadeMedida2)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassUnidadeMedida3)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassUnidadeMedidaLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassUnidadeMedida)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassUnidadeMedidaCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(ProdutoFornecedorClass item in CollectionProdutoFornecedorClassUnidadeMedidaCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassUnidadeMedidaDimensao1)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassUnidadeMedidaDimensao2)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassUnidadeMedidaDimensao3)
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
             case "Abreviada":
                return this.Abreviada;
             case "NomeUnidade":
                return this.NomeUnidade;
             case "Obs":
                return this.Obs;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionEpiClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(EpiClass item in CollectionEpiClassUnidadeMedidaCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionEpiClassUnidadeMedidaUsoLoaded) 
               {
                  foreach(EpiClass item in CollectionEpiClassUnidadeMedidaUso)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionEpiFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(EpiFornecedorClass item in CollectionEpiFornecedorClassUnidadeMedidaCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMaterialClassUnidadeMedidaLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassUnidadeMedida)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMaterialClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassUnidadeMedidaCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMaterialFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(MaterialFornecedorClass item in CollectionMaterialFornecedorClassUnidadeMedidaCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassUnidadeMedidaLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassUnidadeMedida)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedida)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao1)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao2)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassUnidadeMedidaDimensao3)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida1Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassUnidadeMedida1)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida2Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassUnidadeMedida2)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassUnidadeMedida3Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassUnidadeMedida3)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassUnidadeMedidaLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassUnidadeMedida)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassUnidadeMedidaCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoFornecedorClassUnidadeMedidaCompraLoaded) 
               {
                  foreach(ProdutoFornecedorClass item in CollectionProdutoFornecedorClassUnidadeMedidaCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao1Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassUnidadeMedidaDimensao1)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao2Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassUnidadeMedidaDimensao2)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoMaterialClassUnidadeMedidaDimensao3Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassUnidadeMedidaDimensao3)
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
                  command.CommandText += " COUNT(unidade_medida.id_unidade_medida) " ;
               }
               else
               {
               command.CommandText += "unidade_medida.id_unidade_medida, " ;
               command.CommandText += "unidade_medida.unm_abreviada, " ;
               command.CommandText += "unidade_medida.unm_nome_unidade, " ;
               command.CommandText += "unidade_medida.unm_obs, " ;
               command.CommandText += "unidade_medida.unm_ultima_revisao, " ;
               command.CommandText += "unidade_medida.unm_ultima_revisao_data, " ;
               command.CommandText += "unidade_medida.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "unidade_medida.entity_uid, " ;
               command.CommandText += "unidade_medida.version " ;
               }
               command.CommandText += " FROM  unidade_medida ";
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
                        orderByClause += " , unm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(unm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = unidade_medida.id_acs_usuario_ultima_revisao ";
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
                     case "id_unidade_medida":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , unidade_medida.id_unidade_medida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(unidade_medida.id_unidade_medida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "unm_abreviada":
                     case "Abreviada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "unm_nome_unidade":
                     case "NomeUnidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida.unm_nome_unidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida.unm_nome_unidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "unm_obs":
                     case "Obs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida.unm_obs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida.unm_obs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "unm_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida.unm_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida.unm_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "unm_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , unidade_medida.unm_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(unidade_medida.unm_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , unidade_medida.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , unidade_medida.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(unidade_medida.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("unm_abreviada")) 
                        {
                           whereClause += " OR UPPER(unidade_medida.unm_abreviada) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(unidade_medida.unm_abreviada) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("unm_nome_unidade")) 
                        {
                           whereClause += " OR UPPER(unidade_medida.unm_nome_unidade) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(unidade_medida.unm_nome_unidade) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("unm_obs")) 
                        {
                           whereClause += " OR UPPER(unidade_medida.unm_obs) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(unidade_medida.unm_obs) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("unm_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(unidade_medida.unm_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(unidade_medida.unm_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(unidade_medida.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(unidade_medida.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_unidade_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  unidade_medida.id_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.id_unidade_medida = :unidade_medida_ID_4666 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_ID_4666", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Abreviada" || parametro.FieldName == "unm_abreviada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  unidade_medida.unm_abreviada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.unm_abreviada LIKE :unidade_medida_Abreviada_2280 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_Abreviada_2280", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeUnidade" || parametro.FieldName == "unm_nome_unidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  unidade_medida.unm_nome_unidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.unm_nome_unidade LIKE :unidade_medida_NomeUnidade_5642 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_NomeUnidade_5642", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Obs" || parametro.FieldName == "unm_obs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  unidade_medida.unm_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.unm_obs LIKE :unidade_medida_Obs_1218 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_Obs_1218", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "unm_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  unidade_medida.unm_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.unm_ultima_revisao LIKE :unidade_medida_UltimaRevisao_2891 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_UltimaRevisao_2891", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "unm_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  unidade_medida.unm_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.unm_ultima_revisao_data = :unidade_medida_UltimaRevisaoData_2614 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_UltimaRevisaoData_2614", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  unidade_medida.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.id_acs_usuario_ultima_revisao = :unidade_medida_UltimaRevisaoUsuario_9858 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_UltimaRevisaoUsuario_9858", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  unidade_medida.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.entity_uid LIKE :unidade_medida_EntityUid_1804 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_EntityUid_1804", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  unidade_medida.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.version = :unidade_medida_Version_7924 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_Version_7924", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AbreviadaExato" || parametro.FieldName == "AbreviadaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  unidade_medida.unm_abreviada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.unm_abreviada LIKE :unidade_medida_Abreviada_6674 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_Abreviada_6674", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeUnidadeExato" || parametro.FieldName == "NomeUnidadeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  unidade_medida.unm_nome_unidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.unm_nome_unidade LIKE :unidade_medida_NomeUnidade_1274 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_NomeUnidade_1274", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsExato" || parametro.FieldName == "ObsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  unidade_medida.unm_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.unm_obs LIKE :unidade_medida_Obs_5506 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_Obs_5506", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  unidade_medida.unm_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.unm_ultima_revisao LIKE :unidade_medida_UltimaRevisao_7299 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_UltimaRevisao_7299", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  unidade_medida.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  unidade_medida.entity_uid LIKE :unidade_medida_EntityUid_4006 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unidade_medida_EntityUid_4006", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  UnidadeMedidaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (UnidadeMedidaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(UnidadeMedidaClass), Convert.ToInt32(read["id_unidade_medida"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new UnidadeMedidaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_unidade_medida"]);
                     entidade.Abreviada = (read["unm_abreviada"] != DBNull.Value ? read["unm_abreviada"].ToString() : null);
                     entidade.NomeUnidade = (read["unm_nome_unidade"] != DBNull.Value ? read["unm_nome_unidade"].ToString() : null);
                     entidade.Obs = (read["unm_obs"] != DBNull.Value ? read["unm_obs"].ToString() : null);
                     entidade.UltimaRevisao = (read["unm_ultima_revisao"] != DBNull.Value ? read["unm_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["unm_ultima_revisao_data"] as DateTime?;
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
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (UnidadeMedidaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
