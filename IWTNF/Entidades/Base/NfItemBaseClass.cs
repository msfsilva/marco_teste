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
     [Table("nf_item","nfi")]
     public class NfItemBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfItemClass";
protected const string ErroDelete = "Erro ao excluir o NfItemClass  ";
protected const string ErroSave = "Erro ao salvar o NfItemClass.";
protected const string ErroCollectionNfItemReferenciadoClassNfItem = "Erro ao carregar a coleção de NfItemReferenciadoClass.";
protected const string ErroCollectionNfItemTributoClassNfItem = "Erro ao carregar a coleção de NfItemTributoClass.";
protected const string ErroCollectionNfItemTributoCofinsClassNfItem = "Erro ao carregar a coleção de NfItemTributoCofinsClass.";
protected const string ErroCollectionNfItemTributoIcmsClassNfItem = "Erro ao carregar a coleção de NfItemTributoIcmsClass.";
protected const string ErroCollectionNfItemTributoIimpClassNfItem = "Erro ao carregar a coleção de NfItemTributoIimpClass.";
protected const string ErroCollectionNfItemTributoIpiClassNfItem = "Erro ao carregar a coleção de NfItemTributoIpiClass.";
protected const string ErroCollectionNfItemTributoIssClassNfItem = "Erro ao carregar a coleção de NfItemTributoIssClass.";
protected const string ErroCollectionNfItemTributoPisClassNfItem = "Erro ao carregar a coleção de NfItemTributoPisClass.";
protected const string ErroCollectionNfProdutoClassNfItem = "Erro ao carregar a coleção de NfProdutoClass.";
protected const string ErroCollectionNfProdutoCbsClassNfItem = "Erro ao carregar a coleção de NfProdutoCbsClass.";
protected const string ErroCollectionNfProdutoCofinsClassNfItem = "Erro ao carregar a coleção de NfProdutoCofinsClass.";
protected const string ErroCollectionNfProdutoDeclaracaoImportacaoClassNfItem = "Erro ao carregar a coleção de NfProdutoDeclaracaoImportacaoClass.";
protected const string ErroCollectionNfProdutoDevolucaoClassNfItem = "Erro ao carregar a coleção de NfProdutoDevolucaoClass.";
protected const string ErroCollectionNfProdutoIbsClassNfItem = "Erro ao carregar a coleção de NfProdutoIbsClass.";
protected const string ErroCollectionNfProdutoIcmsClassNfItem = "Erro ao carregar a coleção de NfProdutoIcmsClass.";
protected const string ErroCollectionNfProdutoIimpClassNfItem = "Erro ao carregar a coleção de NfProdutoIimpClass.";
protected const string ErroCollectionNfProdutoIpiClassNfItem = "Erro ao carregar a coleção de NfProdutoIpiClass.";
protected const string ErroCollectionNfProdutoIsClassNfItem = "Erro ao carregar a coleção de NfProdutoIsClass.";
protected const string ErroCollectionNfProdutoIssClassNfItem = "Erro ao carregar a coleção de NfProdutoIssClass.";
protected const string ErroCollectionNfProdutoPisClassNfItem = "Erro ao carregar a coleção de NfProdutoPisClass.";
protected const string ErroCollectionNfTributoCbsClassNfItem = "Erro ao carregar a coleção de NfTributoCbsClass.";
protected const string ErroCollectionNfTributoDevolucaoClassNfItem = "Erro ao carregar a coleção de NfTributoDevolucaoClass.";
protected const string ErroCollectionNfTributoIbsClassNfItem = "Erro ao carregar a coleção de NfTributoIbsClass.";
protected const string ErroCollectionNfTributoIsClassNfItem = "Erro ao carregar a coleção de NfTributoIsClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfItemClass.";
protected const string MensagemUtilizadoCollectionNfItemReferenciadoClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfItemReferenciadoClass:";
protected const string MensagemUtilizadoCollectionNfItemTributoClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoClass:";
protected const string MensagemUtilizadoCollectionNfItemTributoCofinsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoCofinsClass:";
protected const string MensagemUtilizadoCollectionNfItemTributoIcmsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoIcmsClass:";
protected const string MensagemUtilizadoCollectionNfItemTributoIimpClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoIimpClass:";
protected const string MensagemUtilizadoCollectionNfItemTributoIpiClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoIpiClass:";
protected const string MensagemUtilizadoCollectionNfItemTributoIssClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoIssClass:";
protected const string MensagemUtilizadoCollectionNfItemTributoPisClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoPisClass:";
protected const string MensagemUtilizadoCollectionNfProdutoClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoClass:";
protected const string MensagemUtilizadoCollectionNfProdutoCbsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoCbsClass:";
protected const string MensagemUtilizadoCollectionNfProdutoCofinsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoCofinsClass:";
protected const string MensagemUtilizadoCollectionNfProdutoDeclaracaoImportacaoClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoDeclaracaoImportacaoClass:";
protected const string MensagemUtilizadoCollectionNfProdutoDevolucaoClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoDevolucaoClass:";
protected const string MensagemUtilizadoCollectionNfProdutoIbsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIbsClass:";
protected const string MensagemUtilizadoCollectionNfProdutoIcmsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIcmsClass:";
protected const string MensagemUtilizadoCollectionNfProdutoIimpClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIimpClass:";
protected const string MensagemUtilizadoCollectionNfProdutoIpiClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIpiClass:";
protected const string MensagemUtilizadoCollectionNfProdutoIsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIsClass:";
protected const string MensagemUtilizadoCollectionNfProdutoIssClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIssClass:";
protected const string MensagemUtilizadoCollectionNfProdutoPisClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoPisClass:";
protected const string MensagemUtilizadoCollectionNfTributoCbsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfTributoCbsClass:";
protected const string MensagemUtilizadoCollectionNfTributoDevolucaoClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfTributoDevolucaoClass:";
protected const string MensagemUtilizadoCollectionNfTributoIbsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfTributoIbsClass:";
protected const string MensagemUtilizadoCollectionNfTributoIsClassNfItem =  "A entidade NfItemClass está sendo utilizada nos seguintes NfTributoIsClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfItemClass está sendo utilizada.";
#endregion
       protected IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _valueNfPrincipal;
        [Column("id_nf_principal", "nf_principal", "id_nf_principal")]
       public virtual IWTNF.Entidades.Entidades.NfPrincipalClass NfPrincipal
        { 
           get {                 return this._valueNfPrincipal; } 
           set 
           { 
                if (this._valueNfPrincipal == value)return;
                 this._valueNfPrincipal = value; 
           } 
       } 

       protected int _numeroItemOriginal{get;private set;}
       private int _numeroItemOriginalCommited{get; set;}
        private int _valueNumeroItem;
         [Column("nfi_numero_item")]
        public virtual int NumeroItem
         { 
            get { return this._valueNumeroItem; } 
            set 
            { 
                if (this._valueNumeroItem == value)return;
                 this._valueNumeroItem = value; 
            } 
        } 

       protected string _informacoesAddOriginal{get;private set;}
       private string _informacoesAddOriginalCommited{get; set;}
        private string _valueInformacoesAdd;
         [Column("nfi_informacoes_add")]
        public virtual string InformacoesAdd
         { 
            get { return this._valueInformacoesAdd; } 
            set 
            { 
                if (this._valueInformacoesAdd == value)return;
                 this._valueInformacoesAdd = value; 
            } 
        } 

       protected int _cfopOriginal{get;private set;}
       private int _cfopOriginalCommited{get; set;}
        private int _valueCfop;
         [Column("nfi_cfop")]
        public virtual int Cfop
         { 
            get { return this._valueCfop; } 
            set 
            { 
                if (this._valueCfop == value)return;
                 this._valueCfop = value; 
            } 
        } 

       protected double? _valorTotalAproximadoTributosOriginal{get;private set;}
       private double? _valorTotalAproximadoTributosOriginalCommited{get; set;}
        private double? _valueValorTotalAproximadoTributos;
         [Column("nfi_valor_total_aproximado_tributos")]
        public virtual double? ValorTotalAproximadoTributos
         { 
            get { return this._valueValorTotalAproximadoTributos; } 
            set 
            { 
                if (this._valueValorTotalAproximadoTributos == value)return;
                 this._valueValorTotalAproximadoTributos = value; 
            } 
        } 

       protected bool _cfopPartilhaIcmsOriginal{get;private set;}
       private bool _cfopPartilhaIcmsOriginalCommited{get; set;}
        private bool _valueCfopPartilhaIcms;
         [Column("nfi_cfop_partilha_icms")]
        public virtual bool CfopPartilhaIcms
         { 
            get { return this._valueCfopPartilhaIcms; } 
            set 
            { 
                if (this._valueCfopPartilhaIcms == value)return;
                 this._valueCfopPartilhaIcms = value; 
            } 
        } 

       protected double _alquotaFundoCombatePobrezaOriginal{get;private set;}
       private double _alquotaFundoCombatePobrezaOriginalCommited{get; set;}
        private double _valueAlquotaFundoCombatePobreza;
         [Column("nfi_alquota_fundo_combate_pobreza")]
        public virtual double AlquotaFundoCombatePobreza
         { 
            get { return this._valueAlquotaFundoCombatePobreza; } 
            set 
            { 
                if (this._valueAlquotaFundoCombatePobreza == value)return;
                 this._valueAlquotaFundoCombatePobreza = value; 
            } 
        } 

       private List<long> _collectionNfItemReferenciadoClassNfItemOriginal;
       private List<Entidades.NfItemReferenciadoClass > _collectionNfItemReferenciadoClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemReferenciadoClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemReferenciadoClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemReferenciadoClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfItemReferenciadoClass> _valueCollectionNfItemReferenciadoClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfItemReferenciadoClass> CollectionNfItemReferenciadoClassNfItem 
       { 
           get { if(!_valueCollectionNfItemReferenciadoClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfItemReferenciadoClassNfItem();}
return this._valueCollectionNfItemReferenciadoClassNfItem; } 
           set 
           { 
               this._valueCollectionNfItemReferenciadoClassNfItem = value; 
               this._valueCollectionNfItemReferenciadoClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfItemTributoClassNfItemOriginal;
       private List<Entidades.NfItemTributoClass > _collectionNfItemTributoClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfItemTributoClass> _valueCollectionNfItemTributoClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfItemTributoClass> CollectionNfItemTributoClassNfItem 
       { 
           get { if(!_valueCollectionNfItemTributoClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfItemTributoClassNfItem();}
return this._valueCollectionNfItemTributoClassNfItem; } 
           set 
           { 
               this._valueCollectionNfItemTributoClassNfItem = value; 
               this._valueCollectionNfItemTributoClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfItemTributoCofinsClassNfItemOriginal;
       private List<Entidades.NfItemTributoCofinsClass > _collectionNfItemTributoCofinsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoCofinsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoCofinsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoCofinsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfItemTributoCofinsClass> _valueCollectionNfItemTributoCofinsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfItemTributoCofinsClass> CollectionNfItemTributoCofinsClassNfItem 
       { 
           get { if(!_valueCollectionNfItemTributoCofinsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfItemTributoCofinsClassNfItem();}
return this._valueCollectionNfItemTributoCofinsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfItemTributoCofinsClassNfItem = value; 
               this._valueCollectionNfItemTributoCofinsClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfItemTributoIcmsClassNfItemOriginal;
       private List<Entidades.NfItemTributoIcmsClass > _collectionNfItemTributoIcmsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIcmsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIcmsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIcmsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfItemTributoIcmsClass> _valueCollectionNfItemTributoIcmsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfItemTributoIcmsClass> CollectionNfItemTributoIcmsClassNfItem 
       { 
           get { if(!_valueCollectionNfItemTributoIcmsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfItemTributoIcmsClassNfItem();}
return this._valueCollectionNfItemTributoIcmsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfItemTributoIcmsClassNfItem = value; 
               this._valueCollectionNfItemTributoIcmsClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfItemTributoIimpClassNfItemOriginal;
       private List<Entidades.NfItemTributoIimpClass > _collectionNfItemTributoIimpClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIimpClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIimpClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIimpClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfItemTributoIimpClass> _valueCollectionNfItemTributoIimpClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfItemTributoIimpClass> CollectionNfItemTributoIimpClassNfItem 
       { 
           get { if(!_valueCollectionNfItemTributoIimpClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfItemTributoIimpClassNfItem();}
return this._valueCollectionNfItemTributoIimpClassNfItem; } 
           set 
           { 
               this._valueCollectionNfItemTributoIimpClassNfItem = value; 
               this._valueCollectionNfItemTributoIimpClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfItemTributoIpiClassNfItemOriginal;
       private List<Entidades.NfItemTributoIpiClass > _collectionNfItemTributoIpiClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIpiClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIpiClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIpiClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfItemTributoIpiClass> _valueCollectionNfItemTributoIpiClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfItemTributoIpiClass> CollectionNfItemTributoIpiClassNfItem 
       { 
           get { if(!_valueCollectionNfItemTributoIpiClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfItemTributoIpiClassNfItem();}
return this._valueCollectionNfItemTributoIpiClassNfItem; } 
           set 
           { 
               this._valueCollectionNfItemTributoIpiClassNfItem = value; 
               this._valueCollectionNfItemTributoIpiClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfItemTributoIssClassNfItemOriginal;
       private List<Entidades.NfItemTributoIssClass > _collectionNfItemTributoIssClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIssClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIssClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoIssClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfItemTributoIssClass> _valueCollectionNfItemTributoIssClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfItemTributoIssClass> CollectionNfItemTributoIssClassNfItem 
       { 
           get { if(!_valueCollectionNfItemTributoIssClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfItemTributoIssClassNfItem();}
return this._valueCollectionNfItemTributoIssClassNfItem; } 
           set 
           { 
               this._valueCollectionNfItemTributoIssClassNfItem = value; 
               this._valueCollectionNfItemTributoIssClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfItemTributoPisClassNfItemOriginal;
       private List<Entidades.NfItemTributoPisClass > _collectionNfItemTributoPisClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoPisClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoPisClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemTributoPisClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfItemTributoPisClass> _valueCollectionNfItemTributoPisClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfItemTributoPisClass> CollectionNfItemTributoPisClassNfItem 
       { 
           get { if(!_valueCollectionNfItemTributoPisClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfItemTributoPisClassNfItem();}
return this._valueCollectionNfItemTributoPisClassNfItem; } 
           set 
           { 
               this._valueCollectionNfItemTributoPisClassNfItem = value; 
               this._valueCollectionNfItemTributoPisClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoClassNfItemOriginal;
       private List<Entidades.NfProdutoClass > _collectionNfProdutoClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoClass> _valueCollectionNfProdutoClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoClass> CollectionNfProdutoClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoClassNfItem();}
return this._valueCollectionNfProdutoClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoClassNfItem = value; 
               this._valueCollectionNfProdutoClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoCbsClassNfItemOriginal;
       private List<Entidades.NfProdutoCbsClass > _collectionNfProdutoCbsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoCbsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoCbsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoCbsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoCbsClass> _valueCollectionNfProdutoCbsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoCbsClass> CollectionNfProdutoCbsClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoCbsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoCbsClassNfItem();}
return this._valueCollectionNfProdutoCbsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoCbsClassNfItem = value; 
               this._valueCollectionNfProdutoCbsClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoCofinsClassNfItemOriginal;
       private List<Entidades.NfProdutoCofinsClass > _collectionNfProdutoCofinsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoCofinsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoCofinsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoCofinsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoCofinsClass> _valueCollectionNfProdutoCofinsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoCofinsClass> CollectionNfProdutoCofinsClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoCofinsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoCofinsClassNfItem();}
return this._valueCollectionNfProdutoCofinsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoCofinsClassNfItem = value; 
               this._valueCollectionNfProdutoCofinsClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoDeclaracaoImportacaoClassNfItemOriginal;
       private List<Entidades.NfProdutoDeclaracaoImportacaoClass > _collectionNfProdutoDeclaracaoImportacaoClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoDeclaracaoImportacaoClass> _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoDeclaracaoImportacaoClass> CollectionNfProdutoDeclaracaoImportacaoClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoDeclaracaoImportacaoClassNfItem();}
return this._valueCollectionNfProdutoDeclaracaoImportacaoClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoDeclaracaoImportacaoClassNfItem = value; 
               this._valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoDevolucaoClassNfItemOriginal;
       private List<Entidades.NfProdutoDevolucaoClass > _collectionNfProdutoDevolucaoClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoDevolucaoClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoDevolucaoClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoDevolucaoClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoDevolucaoClass> _valueCollectionNfProdutoDevolucaoClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoDevolucaoClass> CollectionNfProdutoDevolucaoClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoDevolucaoClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoDevolucaoClassNfItem();}
return this._valueCollectionNfProdutoDevolucaoClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoDevolucaoClassNfItem = value; 
               this._valueCollectionNfProdutoDevolucaoClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoIbsClassNfItemOriginal;
       private List<Entidades.NfProdutoIbsClass > _collectionNfProdutoIbsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIbsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIbsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIbsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoIbsClass> _valueCollectionNfProdutoIbsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoIbsClass> CollectionNfProdutoIbsClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoIbsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoIbsClassNfItem();}
return this._valueCollectionNfProdutoIbsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoIbsClassNfItem = value; 
               this._valueCollectionNfProdutoIbsClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoIcmsClassNfItemOriginal;
       private List<Entidades.NfProdutoIcmsClass > _collectionNfProdutoIcmsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIcmsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIcmsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIcmsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoIcmsClass> _valueCollectionNfProdutoIcmsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoIcmsClass> CollectionNfProdutoIcmsClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoIcmsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoIcmsClassNfItem();}
return this._valueCollectionNfProdutoIcmsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoIcmsClassNfItem = value; 
               this._valueCollectionNfProdutoIcmsClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoIimpClassNfItemOriginal;
       private List<Entidades.NfProdutoIimpClass > _collectionNfProdutoIimpClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIimpClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIimpClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIimpClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoIimpClass> _valueCollectionNfProdutoIimpClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoIimpClass> CollectionNfProdutoIimpClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoIimpClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoIimpClassNfItem();}
return this._valueCollectionNfProdutoIimpClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoIimpClassNfItem = value; 
               this._valueCollectionNfProdutoIimpClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoIpiClassNfItemOriginal;
       private List<Entidades.NfProdutoIpiClass > _collectionNfProdutoIpiClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIpiClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIpiClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIpiClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoIpiClass> _valueCollectionNfProdutoIpiClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoIpiClass> CollectionNfProdutoIpiClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoIpiClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoIpiClassNfItem();}
return this._valueCollectionNfProdutoIpiClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoIpiClassNfItem = value; 
               this._valueCollectionNfProdutoIpiClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoIsClassNfItemOriginal;
       private List<Entidades.NfProdutoIsClass > _collectionNfProdutoIsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoIsClass> _valueCollectionNfProdutoIsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoIsClass> CollectionNfProdutoIsClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoIsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoIsClassNfItem();}
return this._valueCollectionNfProdutoIsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoIsClassNfItem = value; 
               this._valueCollectionNfProdutoIsClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoIssClassNfItemOriginal;
       private List<Entidades.NfProdutoIssClass > _collectionNfProdutoIssClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIssClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIssClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoIssClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoIssClass> _valueCollectionNfProdutoIssClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoIssClass> CollectionNfProdutoIssClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoIssClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoIssClassNfItem();}
return this._valueCollectionNfProdutoIssClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoIssClassNfItem = value; 
               this._valueCollectionNfProdutoIssClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfProdutoPisClassNfItemOriginal;
       private List<Entidades.NfProdutoPisClass > _collectionNfProdutoPisClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoPisClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoPisClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoPisClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoPisClass> _valueCollectionNfProdutoPisClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoPisClass> CollectionNfProdutoPisClassNfItem 
       { 
           get { if(!_valueCollectionNfProdutoPisClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoPisClassNfItem();}
return this._valueCollectionNfProdutoPisClassNfItem; } 
           set 
           { 
               this._valueCollectionNfProdutoPisClassNfItem = value; 
               this._valueCollectionNfProdutoPisClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfTributoCbsClassNfItemOriginal;
       private List<Entidades.NfTributoCbsClass > _collectionNfTributoCbsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoCbsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoCbsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoCbsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfTributoCbsClass> _valueCollectionNfTributoCbsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfTributoCbsClass> CollectionNfTributoCbsClassNfItem 
       { 
           get { if(!_valueCollectionNfTributoCbsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfTributoCbsClassNfItem();}
return this._valueCollectionNfTributoCbsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfTributoCbsClassNfItem = value; 
               this._valueCollectionNfTributoCbsClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfTributoDevolucaoClassNfItemOriginal;
       private List<Entidades.NfTributoDevolucaoClass > _collectionNfTributoDevolucaoClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoDevolucaoClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoDevolucaoClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoDevolucaoClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfTributoDevolucaoClass> _valueCollectionNfTributoDevolucaoClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfTributoDevolucaoClass> CollectionNfTributoDevolucaoClassNfItem 
       { 
           get { if(!_valueCollectionNfTributoDevolucaoClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfTributoDevolucaoClassNfItem();}
return this._valueCollectionNfTributoDevolucaoClassNfItem; } 
           set 
           { 
               this._valueCollectionNfTributoDevolucaoClassNfItem = value; 
               this._valueCollectionNfTributoDevolucaoClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfTributoIbsClassNfItemOriginal;
       private List<Entidades.NfTributoIbsClass > _collectionNfTributoIbsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoIbsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoIbsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoIbsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfTributoIbsClass> _valueCollectionNfTributoIbsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfTributoIbsClass> CollectionNfTributoIbsClassNfItem 
       { 
           get { if(!_valueCollectionNfTributoIbsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfTributoIbsClassNfItem();}
return this._valueCollectionNfTributoIbsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfTributoIbsClassNfItem = value; 
               this._valueCollectionNfTributoIbsClassNfItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNfTributoIsClassNfItemOriginal;
       private List<Entidades.NfTributoIsClass > _collectionNfTributoIsClassNfItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoIsClassNfItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoIsClassNfItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTributoIsClassNfItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfTributoIsClass> _valueCollectionNfTributoIsClassNfItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfTributoIsClass> CollectionNfTributoIsClassNfItem 
       { 
           get { if(!_valueCollectionNfTributoIsClassNfItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNfTributoIsClassNfItem();}
return this._valueCollectionNfTributoIsClassNfItem; } 
           set 
           { 
               this._valueCollectionNfTributoIsClassNfItem = value; 
               this._valueCollectionNfTributoIsClassNfItemLoaded = true; 
           } 
       } 

        public NfItemBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.CfopPartilhaIcms = false;
           this.AlquotaFundoCombatePobreza = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfItemClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfItemClass) GetEntity(typeof(NfItemClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionNfItemReferenciadoClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfItemReferenciadoClassNfItemChanged = true;
                  _valueCollectionNfItemReferenciadoClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfItemReferenciadoClassNfItemChanged = true; 
                  _valueCollectionNfItemReferenciadoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemReferenciadoClass item in e.OldItems) 
                 { 
                     _collectionNfItemReferenciadoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfItemReferenciadoClassNfItemChanged = true; 
                  _valueCollectionNfItemReferenciadoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemReferenciadoClass item in _valueCollectionNfItemReferenciadoClassNfItem) 
                 { 
                     _collectionNfItemReferenciadoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfItemReferenciadoClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfItemReferenciadoClass> oc;
                _valueCollectionNfItemReferenciadoClassNfItemChanged = false;
                 _valueCollectionNfItemReferenciadoClassNfItemCommitedChanged = false;
                _collectionNfItemReferenciadoClassNfItemRemovidos = new List<Entidades.NfItemReferenciadoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfItemReferenciadoClass>();
                }
                else{ 
                   Entidades.NfItemReferenciadoClass search = new Entidades.NfItemReferenciadoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfItemReferenciadoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this),                     }                       ).Cast<Entidades.NfItemReferenciadoClass>().ToList());
                 }
                 _valueCollectionNfItemReferenciadoClassNfItem = new BindingList<Entidades.NfItemReferenciadoClass>(oc); 
                 _collectionNfItemReferenciadoClassNfItemOriginal= (from a in _valueCollectionNfItemReferenciadoClassNfItem select a.ID).ToList();
                 _valueCollectionNfItemReferenciadoClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfItemReferenciadoClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfItemReferenciadoClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfItemTributoClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfItemTributoClassNfItemChanged = true;
                  _valueCollectionNfItemTributoClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfItemTributoClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoClass item in e.OldItems) 
                 { 
                     _collectionNfItemTributoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfItemTributoClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoClass item in _valueCollectionNfItemTributoClassNfItem) 
                 { 
                     _collectionNfItemTributoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfItemTributoClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfItemTributoClass> oc;
                _valueCollectionNfItemTributoClassNfItemChanged = false;
                 _valueCollectionNfItemTributoClassNfItemCommitedChanged = false;
                _collectionNfItemTributoClassNfItemRemovidos = new List<Entidades.NfItemTributoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfItemTributoClass>();
                }
                else{ 
                   Entidades.NfItemTributoClass search = new Entidades.NfItemTributoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfItemTributoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfItemTributoClass>().ToList());
                 }
                 _valueCollectionNfItemTributoClassNfItem = new BindingList<Entidades.NfItemTributoClass>(oc); 
                 _collectionNfItemTributoClassNfItemOriginal= (from a in _valueCollectionNfItemTributoClassNfItem select a.ID).ToList();
                 _valueCollectionNfItemTributoClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfItemTributoClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfItemTributoClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfItemTributoCofinsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfItemTributoCofinsClassNfItemChanged = true;
                  _valueCollectionNfItemTributoCofinsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfItemTributoCofinsClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoCofinsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoCofinsClass item in e.OldItems) 
                 { 
                     _collectionNfItemTributoCofinsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfItemTributoCofinsClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoCofinsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoCofinsClass item in _valueCollectionNfItemTributoCofinsClassNfItem) 
                 { 
                     _collectionNfItemTributoCofinsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfItemTributoCofinsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfItemTributoCofinsClass> oc;
                _valueCollectionNfItemTributoCofinsClassNfItemChanged = false;
                 _valueCollectionNfItemTributoCofinsClassNfItemCommitedChanged = false;
                _collectionNfItemTributoCofinsClassNfItemRemovidos = new List<Entidades.NfItemTributoCofinsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfItemTributoCofinsClass>();
                }
                else{ 
                   Entidades.NfItemTributoCofinsClass search = new Entidades.NfItemTributoCofinsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfItemTributoCofinsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfItemTributoCofinsClass>().ToList());
                 }
                 _valueCollectionNfItemTributoCofinsClassNfItem = new BindingList<Entidades.NfItemTributoCofinsClass>(oc); 
                 _collectionNfItemTributoCofinsClassNfItemOriginal= (from a in _valueCollectionNfItemTributoCofinsClassNfItem select a.ID).ToList();
                 _valueCollectionNfItemTributoCofinsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfItemTributoCofinsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfItemTributoCofinsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfItemTributoIcmsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfItemTributoIcmsClassNfItemChanged = true;
                  _valueCollectionNfItemTributoIcmsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfItemTributoIcmsClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoIcmsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoIcmsClass item in e.OldItems) 
                 { 
                     _collectionNfItemTributoIcmsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfItemTributoIcmsClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoIcmsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoIcmsClass item in _valueCollectionNfItemTributoIcmsClassNfItem) 
                 { 
                     _collectionNfItemTributoIcmsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfItemTributoIcmsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfItemTributoIcmsClass> oc;
                _valueCollectionNfItemTributoIcmsClassNfItemChanged = false;
                 _valueCollectionNfItemTributoIcmsClassNfItemCommitedChanged = false;
                _collectionNfItemTributoIcmsClassNfItemRemovidos = new List<Entidades.NfItemTributoIcmsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfItemTributoIcmsClass>();
                }
                else{ 
                   Entidades.NfItemTributoIcmsClass search = new Entidades.NfItemTributoIcmsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfItemTributoIcmsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfItemTributoIcmsClass>().ToList());
                 }
                 _valueCollectionNfItemTributoIcmsClassNfItem = new BindingList<Entidades.NfItemTributoIcmsClass>(oc); 
                 _collectionNfItemTributoIcmsClassNfItemOriginal= (from a in _valueCollectionNfItemTributoIcmsClassNfItem select a.ID).ToList();
                 _valueCollectionNfItemTributoIcmsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfItemTributoIcmsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfItemTributoIcmsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfItemTributoIimpClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfItemTributoIimpClassNfItemChanged = true;
                  _valueCollectionNfItemTributoIimpClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfItemTributoIimpClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoIimpClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoIimpClass item in e.OldItems) 
                 { 
                     _collectionNfItemTributoIimpClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfItemTributoIimpClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoIimpClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoIimpClass item in _valueCollectionNfItemTributoIimpClassNfItem) 
                 { 
                     _collectionNfItemTributoIimpClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfItemTributoIimpClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfItemTributoIimpClass> oc;
                _valueCollectionNfItemTributoIimpClassNfItemChanged = false;
                 _valueCollectionNfItemTributoIimpClassNfItemCommitedChanged = false;
                _collectionNfItemTributoIimpClassNfItemRemovidos = new List<Entidades.NfItemTributoIimpClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfItemTributoIimpClass>();
                }
                else{ 
                   Entidades.NfItemTributoIimpClass search = new Entidades.NfItemTributoIimpClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfItemTributoIimpClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfItemTributoIimpClass>().ToList());
                 }
                 _valueCollectionNfItemTributoIimpClassNfItem = new BindingList<Entidades.NfItemTributoIimpClass>(oc); 
                 _collectionNfItemTributoIimpClassNfItemOriginal= (from a in _valueCollectionNfItemTributoIimpClassNfItem select a.ID).ToList();
                 _valueCollectionNfItemTributoIimpClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfItemTributoIimpClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfItemTributoIimpClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfItemTributoIpiClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfItemTributoIpiClassNfItemChanged = true;
                  _valueCollectionNfItemTributoIpiClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfItemTributoIpiClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoIpiClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoIpiClass item in e.OldItems) 
                 { 
                     _collectionNfItemTributoIpiClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfItemTributoIpiClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoIpiClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoIpiClass item in _valueCollectionNfItemTributoIpiClassNfItem) 
                 { 
                     _collectionNfItemTributoIpiClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfItemTributoIpiClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfItemTributoIpiClass> oc;
                _valueCollectionNfItemTributoIpiClassNfItemChanged = false;
                 _valueCollectionNfItemTributoIpiClassNfItemCommitedChanged = false;
                _collectionNfItemTributoIpiClassNfItemRemovidos = new List<Entidades.NfItemTributoIpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfItemTributoIpiClass>();
                }
                else{ 
                   Entidades.NfItemTributoIpiClass search = new Entidades.NfItemTributoIpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfItemTributoIpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfItemTributoIpiClass>().ToList());
                 }
                 _valueCollectionNfItemTributoIpiClassNfItem = new BindingList<Entidades.NfItemTributoIpiClass>(oc); 
                 _collectionNfItemTributoIpiClassNfItemOriginal= (from a in _valueCollectionNfItemTributoIpiClassNfItem select a.ID).ToList();
                 _valueCollectionNfItemTributoIpiClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfItemTributoIpiClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfItemTributoIpiClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfItemTributoIssClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfItemTributoIssClassNfItemChanged = true;
                  _valueCollectionNfItemTributoIssClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfItemTributoIssClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoIssClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoIssClass item in e.OldItems) 
                 { 
                     _collectionNfItemTributoIssClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfItemTributoIssClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoIssClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoIssClass item in _valueCollectionNfItemTributoIssClassNfItem) 
                 { 
                     _collectionNfItemTributoIssClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfItemTributoIssClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfItemTributoIssClass> oc;
                _valueCollectionNfItemTributoIssClassNfItemChanged = false;
                 _valueCollectionNfItemTributoIssClassNfItemCommitedChanged = false;
                _collectionNfItemTributoIssClassNfItemRemovidos = new List<Entidades.NfItemTributoIssClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfItemTributoIssClass>();
                }
                else{ 
                   Entidades.NfItemTributoIssClass search = new Entidades.NfItemTributoIssClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfItemTributoIssClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfItemTributoIssClass>().ToList());
                 }
                 _valueCollectionNfItemTributoIssClassNfItem = new BindingList<Entidades.NfItemTributoIssClass>(oc); 
                 _collectionNfItemTributoIssClassNfItemOriginal= (from a in _valueCollectionNfItemTributoIssClassNfItem select a.ID).ToList();
                 _valueCollectionNfItemTributoIssClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfItemTributoIssClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfItemTributoIssClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfItemTributoPisClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfItemTributoPisClassNfItemChanged = true;
                  _valueCollectionNfItemTributoPisClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfItemTributoPisClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoPisClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoPisClass item in e.OldItems) 
                 { 
                     _collectionNfItemTributoPisClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfItemTributoPisClassNfItemChanged = true; 
                  _valueCollectionNfItemTributoPisClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfItemTributoPisClass item in _valueCollectionNfItemTributoPisClassNfItem) 
                 { 
                     _collectionNfItemTributoPisClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfItemTributoPisClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfItemTributoPisClass> oc;
                _valueCollectionNfItemTributoPisClassNfItemChanged = false;
                 _valueCollectionNfItemTributoPisClassNfItemCommitedChanged = false;
                _collectionNfItemTributoPisClassNfItemRemovidos = new List<Entidades.NfItemTributoPisClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfItemTributoPisClass>();
                }
                else{ 
                   Entidades.NfItemTributoPisClass search = new Entidades.NfItemTributoPisClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfItemTributoPisClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfItemTributoPisClass>().ToList());
                 }
                 _valueCollectionNfItemTributoPisClassNfItem = new BindingList<Entidades.NfItemTributoPisClass>(oc); 
                 _collectionNfItemTributoPisClassNfItemOriginal= (from a in _valueCollectionNfItemTributoPisClassNfItem select a.ID).ToList();
                 _valueCollectionNfItemTributoPisClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfItemTributoPisClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfItemTributoPisClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoClassNfItemChanged = true;
                  _valueCollectionNfProdutoClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoClassNfItemChanged = true; 
                  _valueCollectionNfProdutoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoClassNfItemChanged = true; 
                  _valueCollectionNfProdutoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoClass item in _valueCollectionNfProdutoClassNfItem) 
                 { 
                     _collectionNfProdutoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoClass> oc;
                _valueCollectionNfProdutoClassNfItemChanged = false;
                 _valueCollectionNfProdutoClassNfItemCommitedChanged = false;
                _collectionNfProdutoClassNfItemRemovidos = new List<Entidades.NfProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoClass>();
                }
                else{ 
                   Entidades.NfProdutoClass search = new Entidades.NfProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfProdutoClass>().ToList());
                 }
                 _valueCollectionNfProdutoClassNfItem = new BindingList<Entidades.NfProdutoClass>(oc); 
                 _collectionNfProdutoClassNfItemOriginal= (from a in _valueCollectionNfProdutoClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoCbsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoCbsClassNfItemChanged = true;
                  _valueCollectionNfProdutoCbsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoCbsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoCbsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoCbsClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoCbsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoCbsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoCbsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoCbsClass item in _valueCollectionNfProdutoCbsClassNfItem) 
                 { 
                     _collectionNfProdutoCbsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoCbsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoCbsClass> oc;
                _valueCollectionNfProdutoCbsClassNfItemChanged = false;
                 _valueCollectionNfProdutoCbsClassNfItemCommitedChanged = false;
                _collectionNfProdutoCbsClassNfItemRemovidos = new List<Entidades.NfProdutoCbsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoCbsClass>();
                }
                else{ 
                   Entidades.NfProdutoCbsClass search = new Entidades.NfProdutoCbsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoCbsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this),                     }                       ).Cast<Entidades.NfProdutoCbsClass>().ToList());
                 }
                 _valueCollectionNfProdutoCbsClassNfItem = new BindingList<Entidades.NfProdutoCbsClass>(oc); 
                 _collectionNfProdutoCbsClassNfItemOriginal= (from a in _valueCollectionNfProdutoCbsClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoCbsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoCbsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoCbsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoCofinsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoCofinsClassNfItemChanged = true;
                  _valueCollectionNfProdutoCofinsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoCofinsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoCofinsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoCofinsClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoCofinsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoCofinsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoCofinsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoCofinsClass item in _valueCollectionNfProdutoCofinsClassNfItem) 
                 { 
                     _collectionNfProdutoCofinsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoCofinsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoCofinsClass> oc;
                _valueCollectionNfProdutoCofinsClassNfItemChanged = false;
                 _valueCollectionNfProdutoCofinsClassNfItemCommitedChanged = false;
                _collectionNfProdutoCofinsClassNfItemRemovidos = new List<Entidades.NfProdutoCofinsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoCofinsClass>();
                }
                else{ 
                   Entidades.NfProdutoCofinsClass search = new Entidades.NfProdutoCofinsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoCofinsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfProdutoCofinsClass>().ToList());
                 }
                 _valueCollectionNfProdutoCofinsClassNfItem = new BindingList<Entidades.NfProdutoCofinsClass>(oc); 
                 _collectionNfProdutoCofinsClassNfItemOriginal= (from a in _valueCollectionNfProdutoCofinsClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoCofinsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoCofinsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoCofinsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoDeclaracaoImportacaoClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemChanged = true;
                  _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemChanged = true; 
                  _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoDeclaracaoImportacaoClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoDeclaracaoImportacaoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemChanged = true; 
                  _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoDeclaracaoImportacaoClass item in _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItem) 
                 { 
                     _collectionNfProdutoDeclaracaoImportacaoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoDeclaracaoImportacaoClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoDeclaracaoImportacaoClass> oc;
                _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemChanged = false;
                 _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemCommitedChanged = false;
                _collectionNfProdutoDeclaracaoImportacaoClassNfItemRemovidos = new List<Entidades.NfProdutoDeclaracaoImportacaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoDeclaracaoImportacaoClass>();
                }
                else{ 
                   Entidades.NfProdutoDeclaracaoImportacaoClass search = new Entidades.NfProdutoDeclaracaoImportacaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoDeclaracaoImportacaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfProdutoDeclaracaoImportacaoClass>().ToList());
                 }
                 _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItem = new BindingList<Entidades.NfProdutoDeclaracaoImportacaoClass>(oc); 
                 _collectionNfProdutoDeclaracaoImportacaoClassNfItemOriginal= (from a in _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoDeclaracaoImportacaoClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoDeclaracaoImportacaoClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoDevolucaoClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoDevolucaoClassNfItemChanged = true;
                  _valueCollectionNfProdutoDevolucaoClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoDevolucaoClassNfItemChanged = true; 
                  _valueCollectionNfProdutoDevolucaoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoDevolucaoClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoDevolucaoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoDevolucaoClassNfItemChanged = true; 
                  _valueCollectionNfProdutoDevolucaoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoDevolucaoClass item in _valueCollectionNfProdutoDevolucaoClassNfItem) 
                 { 
                     _collectionNfProdutoDevolucaoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoDevolucaoClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoDevolucaoClass> oc;
                _valueCollectionNfProdutoDevolucaoClassNfItemChanged = false;
                 _valueCollectionNfProdutoDevolucaoClassNfItemCommitedChanged = false;
                _collectionNfProdutoDevolucaoClassNfItemRemovidos = new List<Entidades.NfProdutoDevolucaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoDevolucaoClass>();
                }
                else{ 
                   Entidades.NfProdutoDevolucaoClass search = new Entidades.NfProdutoDevolucaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoDevolucaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this),                     }                       ).Cast<Entidades.NfProdutoDevolucaoClass>().ToList());
                 }
                 _valueCollectionNfProdutoDevolucaoClassNfItem = new BindingList<Entidades.NfProdutoDevolucaoClass>(oc); 
                 _collectionNfProdutoDevolucaoClassNfItemOriginal= (from a in _valueCollectionNfProdutoDevolucaoClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoDevolucaoClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoDevolucaoClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoDevolucaoClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoIbsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoIbsClassNfItemChanged = true;
                  _valueCollectionNfProdutoIbsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoIbsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIbsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIbsClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoIbsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoIbsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIbsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIbsClass item in _valueCollectionNfProdutoIbsClassNfItem) 
                 { 
                     _collectionNfProdutoIbsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoIbsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoIbsClass> oc;
                _valueCollectionNfProdutoIbsClassNfItemChanged = false;
                 _valueCollectionNfProdutoIbsClassNfItemCommitedChanged = false;
                _collectionNfProdutoIbsClassNfItemRemovidos = new List<Entidades.NfProdutoIbsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoIbsClass>();
                }
                else{ 
                   Entidades.NfProdutoIbsClass search = new Entidades.NfProdutoIbsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoIbsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this),                     }                       ).Cast<Entidades.NfProdutoIbsClass>().ToList());
                 }
                 _valueCollectionNfProdutoIbsClassNfItem = new BindingList<Entidades.NfProdutoIbsClass>(oc); 
                 _collectionNfProdutoIbsClassNfItemOriginal= (from a in _valueCollectionNfProdutoIbsClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoIbsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoIbsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoIbsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoIcmsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoIcmsClassNfItemChanged = true;
                  _valueCollectionNfProdutoIcmsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoIcmsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIcmsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIcmsClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoIcmsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoIcmsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIcmsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIcmsClass item in _valueCollectionNfProdutoIcmsClassNfItem) 
                 { 
                     _collectionNfProdutoIcmsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoIcmsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoIcmsClass> oc;
                _valueCollectionNfProdutoIcmsClassNfItemChanged = false;
                 _valueCollectionNfProdutoIcmsClassNfItemCommitedChanged = false;
                _collectionNfProdutoIcmsClassNfItemRemovidos = new List<Entidades.NfProdutoIcmsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoIcmsClass>();
                }
                else{ 
                   Entidades.NfProdutoIcmsClass search = new Entidades.NfProdutoIcmsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoIcmsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfProdutoIcmsClass>().ToList());
                 }
                 _valueCollectionNfProdutoIcmsClassNfItem = new BindingList<Entidades.NfProdutoIcmsClass>(oc); 
                 _collectionNfProdutoIcmsClassNfItemOriginal= (from a in _valueCollectionNfProdutoIcmsClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoIcmsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoIcmsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoIcmsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoIimpClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoIimpClassNfItemChanged = true;
                  _valueCollectionNfProdutoIimpClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoIimpClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIimpClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIimpClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoIimpClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoIimpClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIimpClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIimpClass item in _valueCollectionNfProdutoIimpClassNfItem) 
                 { 
                     _collectionNfProdutoIimpClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoIimpClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoIimpClass> oc;
                _valueCollectionNfProdutoIimpClassNfItemChanged = false;
                 _valueCollectionNfProdutoIimpClassNfItemCommitedChanged = false;
                _collectionNfProdutoIimpClassNfItemRemovidos = new List<Entidades.NfProdutoIimpClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoIimpClass>();
                }
                else{ 
                   Entidades.NfProdutoIimpClass search = new Entidades.NfProdutoIimpClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoIimpClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfProdutoIimpClass>().ToList());
                 }
                 _valueCollectionNfProdutoIimpClassNfItem = new BindingList<Entidades.NfProdutoIimpClass>(oc); 
                 _collectionNfProdutoIimpClassNfItemOriginal= (from a in _valueCollectionNfProdutoIimpClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoIimpClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoIimpClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoIimpClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoIpiClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoIpiClassNfItemChanged = true;
                  _valueCollectionNfProdutoIpiClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoIpiClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIpiClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIpiClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoIpiClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoIpiClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIpiClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIpiClass item in _valueCollectionNfProdutoIpiClassNfItem) 
                 { 
                     _collectionNfProdutoIpiClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoIpiClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoIpiClass> oc;
                _valueCollectionNfProdutoIpiClassNfItemChanged = false;
                 _valueCollectionNfProdutoIpiClassNfItemCommitedChanged = false;
                _collectionNfProdutoIpiClassNfItemRemovidos = new List<Entidades.NfProdutoIpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoIpiClass>();
                }
                else{ 
                   Entidades.NfProdutoIpiClass search = new Entidades.NfProdutoIpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoIpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfProdutoIpiClass>().ToList());
                 }
                 _valueCollectionNfProdutoIpiClassNfItem = new BindingList<Entidades.NfProdutoIpiClass>(oc); 
                 _collectionNfProdutoIpiClassNfItemOriginal= (from a in _valueCollectionNfProdutoIpiClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoIpiClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoIpiClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoIpiClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoIsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoIsClassNfItemChanged = true;
                  _valueCollectionNfProdutoIsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoIsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIsClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoIsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoIsClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIsClass item in _valueCollectionNfProdutoIsClassNfItem) 
                 { 
                     _collectionNfProdutoIsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoIsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoIsClass> oc;
                _valueCollectionNfProdutoIsClassNfItemChanged = false;
                 _valueCollectionNfProdutoIsClassNfItemCommitedChanged = false;
                _collectionNfProdutoIsClassNfItemRemovidos = new List<Entidades.NfProdutoIsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoIsClass>();
                }
                else{ 
                   Entidades.NfProdutoIsClass search = new Entidades.NfProdutoIsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoIsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this),                     }                       ).Cast<Entidades.NfProdutoIsClass>().ToList());
                 }
                 _valueCollectionNfProdutoIsClassNfItem = new BindingList<Entidades.NfProdutoIsClass>(oc); 
                 _collectionNfProdutoIsClassNfItemOriginal= (from a in _valueCollectionNfProdutoIsClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoIsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoIsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoIsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoIssClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoIssClassNfItemChanged = true;
                  _valueCollectionNfProdutoIssClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoIssClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIssClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIssClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoIssClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoIssClassNfItemChanged = true; 
                  _valueCollectionNfProdutoIssClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoIssClass item in _valueCollectionNfProdutoIssClassNfItem) 
                 { 
                     _collectionNfProdutoIssClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoIssClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoIssClass> oc;
                _valueCollectionNfProdutoIssClassNfItemChanged = false;
                 _valueCollectionNfProdutoIssClassNfItemCommitedChanged = false;
                _collectionNfProdutoIssClassNfItemRemovidos = new List<Entidades.NfProdutoIssClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoIssClass>();
                }
                else{ 
                   Entidades.NfProdutoIssClass search = new Entidades.NfProdutoIssClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoIssClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfProdutoIssClass>().ToList());
                 }
                 _valueCollectionNfProdutoIssClassNfItem = new BindingList<Entidades.NfProdutoIssClass>(oc); 
                 _collectionNfProdutoIssClassNfItemOriginal= (from a in _valueCollectionNfProdutoIssClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoIssClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoIssClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoIssClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfProdutoPisClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoPisClassNfItemChanged = true;
                  _valueCollectionNfProdutoPisClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoPisClassNfItemChanged = true; 
                  _valueCollectionNfProdutoPisClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoPisClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoPisClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoPisClassNfItemChanged = true; 
                  _valueCollectionNfProdutoPisClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfProdutoPisClass item in _valueCollectionNfProdutoPisClassNfItem) 
                 { 
                     _collectionNfProdutoPisClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoPisClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoPisClass> oc;
                _valueCollectionNfProdutoPisClassNfItemChanged = false;
                 _valueCollectionNfProdutoPisClassNfItemCommitedChanged = false;
                _collectionNfProdutoPisClassNfItemRemovidos = new List<Entidades.NfProdutoPisClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoPisClass>();
                }
                else{ 
                   Entidades.NfProdutoPisClass search = new Entidades.NfProdutoPisClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoPisClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this)                    }                       ).Cast<Entidades.NfProdutoPisClass>().ToList());
                 }
                 _valueCollectionNfProdutoPisClassNfItem = new BindingList<Entidades.NfProdutoPisClass>(oc); 
                 _collectionNfProdutoPisClassNfItemOriginal= (from a in _valueCollectionNfProdutoPisClassNfItem select a.ID).ToList();
                 _valueCollectionNfProdutoPisClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoPisClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoPisClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfTributoCbsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfTributoCbsClassNfItemChanged = true;
                  _valueCollectionNfTributoCbsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfTributoCbsClassNfItemChanged = true; 
                  _valueCollectionNfTributoCbsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfTributoCbsClass item in e.OldItems) 
                 { 
                     _collectionNfTributoCbsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfTributoCbsClassNfItemChanged = true; 
                  _valueCollectionNfTributoCbsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfTributoCbsClass item in _valueCollectionNfTributoCbsClassNfItem) 
                 { 
                     _collectionNfTributoCbsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfTributoCbsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfTributoCbsClass> oc;
                _valueCollectionNfTributoCbsClassNfItemChanged = false;
                 _valueCollectionNfTributoCbsClassNfItemCommitedChanged = false;
                _collectionNfTributoCbsClassNfItemRemovidos = new List<Entidades.NfTributoCbsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfTributoCbsClass>();
                }
                else{ 
                   Entidades.NfTributoCbsClass search = new Entidades.NfTributoCbsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfTributoCbsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this),                     }                       ).Cast<Entidades.NfTributoCbsClass>().ToList());
                 }
                 _valueCollectionNfTributoCbsClassNfItem = new BindingList<Entidades.NfTributoCbsClass>(oc); 
                 _collectionNfTributoCbsClassNfItemOriginal= (from a in _valueCollectionNfTributoCbsClassNfItem select a.ID).ToList();
                 _valueCollectionNfTributoCbsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfTributoCbsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfTributoCbsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfTributoDevolucaoClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfTributoDevolucaoClassNfItemChanged = true;
                  _valueCollectionNfTributoDevolucaoClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfTributoDevolucaoClassNfItemChanged = true; 
                  _valueCollectionNfTributoDevolucaoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfTributoDevolucaoClass item in e.OldItems) 
                 { 
                     _collectionNfTributoDevolucaoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfTributoDevolucaoClassNfItemChanged = true; 
                  _valueCollectionNfTributoDevolucaoClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfTributoDevolucaoClass item in _valueCollectionNfTributoDevolucaoClassNfItem) 
                 { 
                     _collectionNfTributoDevolucaoClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfTributoDevolucaoClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfTributoDevolucaoClass> oc;
                _valueCollectionNfTributoDevolucaoClassNfItemChanged = false;
                 _valueCollectionNfTributoDevolucaoClassNfItemCommitedChanged = false;
                _collectionNfTributoDevolucaoClassNfItemRemovidos = new List<Entidades.NfTributoDevolucaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfTributoDevolucaoClass>();
                }
                else{ 
                   Entidades.NfTributoDevolucaoClass search = new Entidades.NfTributoDevolucaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfTributoDevolucaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this),                     }                       ).Cast<Entidades.NfTributoDevolucaoClass>().ToList());
                 }
                 _valueCollectionNfTributoDevolucaoClassNfItem = new BindingList<Entidades.NfTributoDevolucaoClass>(oc); 
                 _collectionNfTributoDevolucaoClassNfItemOriginal= (from a in _valueCollectionNfTributoDevolucaoClassNfItem select a.ID).ToList();
                 _valueCollectionNfTributoDevolucaoClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfTributoDevolucaoClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfTributoDevolucaoClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfTributoIbsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfTributoIbsClassNfItemChanged = true;
                  _valueCollectionNfTributoIbsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfTributoIbsClassNfItemChanged = true; 
                  _valueCollectionNfTributoIbsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfTributoIbsClass item in e.OldItems) 
                 { 
                     _collectionNfTributoIbsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfTributoIbsClassNfItemChanged = true; 
                  _valueCollectionNfTributoIbsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfTributoIbsClass item in _valueCollectionNfTributoIbsClassNfItem) 
                 { 
                     _collectionNfTributoIbsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfTributoIbsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfTributoIbsClass> oc;
                _valueCollectionNfTributoIbsClassNfItemChanged = false;
                 _valueCollectionNfTributoIbsClassNfItemCommitedChanged = false;
                _collectionNfTributoIbsClassNfItemRemovidos = new List<Entidades.NfTributoIbsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfTributoIbsClass>();
                }
                else{ 
                   Entidades.NfTributoIbsClass search = new Entidades.NfTributoIbsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfTributoIbsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this),                     }                       ).Cast<Entidades.NfTributoIbsClass>().ToList());
                 }
                 _valueCollectionNfTributoIbsClassNfItem = new BindingList<Entidades.NfTributoIbsClass>(oc); 
                 _collectionNfTributoIbsClassNfItemOriginal= (from a in _valueCollectionNfTributoIbsClassNfItem select a.ID).ToList();
                 _valueCollectionNfTributoIbsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfTributoIbsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfTributoIbsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfTributoIsClassNfItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfTributoIsClassNfItemChanged = true;
                  _valueCollectionNfTributoIsClassNfItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfTributoIsClassNfItemChanged = true; 
                  _valueCollectionNfTributoIsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfTributoIsClass item in e.OldItems) 
                 { 
                     _collectionNfTributoIsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfTributoIsClassNfItemChanged = true; 
                  _valueCollectionNfTributoIsClassNfItemCommitedChanged = true;
                 foreach (Entidades.NfTributoIsClass item in _valueCollectionNfTributoIsClassNfItem) 
                 { 
                     _collectionNfTributoIsClassNfItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfTributoIsClassNfItem()
         {
            try
            {
                 ObservableCollection<Entidades.NfTributoIsClass> oc;
                _valueCollectionNfTributoIsClassNfItemChanged = false;
                 _valueCollectionNfTributoIsClassNfItemCommitedChanged = false;
                _collectionNfTributoIsClassNfItemRemovidos = new List<Entidades.NfTributoIsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfTributoIsClass>();
                }
                else{ 
                   Entidades.NfTributoIsClass search = new Entidades.NfTributoIsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfTributoIsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfItem", this),                     }                       ).Cast<Entidades.NfTributoIsClass>().ToList());
                 }
                 _valueCollectionNfTributoIsClassNfItem = new BindingList<Entidades.NfTributoIsClass>(oc); 
                 _collectionNfTributoIsClassNfItemOriginal= (from a in _valueCollectionNfTributoIsClassNfItem select a.ID).ToList();
                 _valueCollectionNfTributoIsClassNfItemLoaded = true;
                 oc.CollectionChanged += CollectionNfTributoIsClassNfItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfTributoIsClassNfItem+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueNfPrincipal == null)
                {
                    throw new Exception(ErroNfPrincipalObrigatorio);
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
                    "  public.nf_item  " +
                    "WHERE " +
                    "  id_nf_item = :id";
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
                        "  public.nf_item   " +
                        "SET  " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  nfi_numero_item = :nfi_numero_item, " + 
                        "  nfi_informacoes_add = :nfi_informacoes_add, " + 
                        "  nfi_cfop = :nfi_cfop, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nfi_valor_total_aproximado_tributos = :nfi_valor_total_aproximado_tributos, " + 
                        "  nfi_cfop_partilha_icms = :nfi_cfop_partilha_icms, " + 
                        "  nfi_alquota_fundo_combate_pobreza = :nfi_alquota_fundo_combate_pobreza "+
                        "WHERE  " +
                        "  id_nf_item = :id " +
                        "RETURNING id_nf_item;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_item " +
                        "( " +
                        "  id_nf_principal , " + 
                        "  nfi_numero_item , " + 
                        "  nfi_informacoes_add , " + 
                        "  nfi_cfop , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nfi_valor_total_aproximado_tributos , " + 
                        "  nfi_cfop_partilha_icms , " + 
                        "  nfi_alquota_fundo_combate_pobreza  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_principal , " + 
                        "  :nfi_numero_item , " + 
                        "  :nfi_informacoes_add , " + 
                        "  :nfi_cfop , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nfi_valor_total_aproximado_tributos , " + 
                        "  :nfi_cfop_partilha_icms , " + 
                        "  :nfi_alquota_fundo_combate_pobreza  "+
                        ")RETURNING id_nf_item;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfi_numero_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfi_informacoes_add", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InformacoesAdd ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfi_cfop", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cfop ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfi_valor_total_aproximado_tributos", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalAproximadoTributos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfi_cfop_partilha_icms", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CfopPartilhaIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfi_alquota_fundo_combate_pobreza", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AlquotaFundoCombatePobreza ?? DBNull.Value;

 
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
 if (CollectionNfItemReferenciadoClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfItemReferenciadoClassNfItem+"\r\n";
                foreach (Entidades.NfItemReferenciadoClass tmp in CollectionNfItemReferenciadoClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfItemTributoClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfItemTributoClassNfItem+"\r\n";
                foreach (Entidades.NfItemTributoClass tmp in CollectionNfItemTributoClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfItemTributoCofinsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfItemTributoCofinsClassNfItem+"\r\n";
                foreach (Entidades.NfItemTributoCofinsClass tmp in CollectionNfItemTributoCofinsClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfItemTributoIcmsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfItemTributoIcmsClassNfItem+"\r\n";
                foreach (Entidades.NfItemTributoIcmsClass tmp in CollectionNfItemTributoIcmsClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfItemTributoIimpClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfItemTributoIimpClassNfItem+"\r\n";
                foreach (Entidades.NfItemTributoIimpClass tmp in CollectionNfItemTributoIimpClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfItemTributoIpiClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfItemTributoIpiClassNfItem+"\r\n";
                foreach (Entidades.NfItemTributoIpiClass tmp in CollectionNfItemTributoIpiClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfItemTributoIssClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfItemTributoIssClassNfItem+"\r\n";
                foreach (Entidades.NfItemTributoIssClass tmp in CollectionNfItemTributoIssClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfItemTributoPisClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfItemTributoPisClassNfItem+"\r\n";
                foreach (Entidades.NfItemTributoPisClass tmp in CollectionNfItemTributoPisClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoClass tmp in CollectionNfProdutoClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoCbsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoCbsClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoCbsClass tmp in CollectionNfProdutoCbsClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoCofinsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoCofinsClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoCofinsClass tmp in CollectionNfProdutoCofinsClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoDeclaracaoImportacaoClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoDeclaracaoImportacaoClass tmp in CollectionNfProdutoDeclaracaoImportacaoClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoDevolucaoClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoDevolucaoClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoDevolucaoClass tmp in CollectionNfProdutoDevolucaoClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoIbsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoIbsClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoIbsClass tmp in CollectionNfProdutoIbsClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoIcmsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoIcmsClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoIcmsClass tmp in CollectionNfProdutoIcmsClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoIimpClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoIimpClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoIimpClass tmp in CollectionNfProdutoIimpClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoIpiClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoIpiClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoIpiClass tmp in CollectionNfProdutoIpiClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoIsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoIsClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoIsClass tmp in CollectionNfProdutoIsClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoIssClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoIssClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoIssClass tmp in CollectionNfProdutoIssClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfProdutoPisClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoPisClassNfItem+"\r\n";
                foreach (Entidades.NfProdutoPisClass tmp in CollectionNfProdutoPisClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfTributoCbsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfTributoCbsClassNfItem+"\r\n";
                foreach (Entidades.NfTributoCbsClass tmp in CollectionNfTributoCbsClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfTributoDevolucaoClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfTributoDevolucaoClassNfItem+"\r\n";
                foreach (Entidades.NfTributoDevolucaoClass tmp in CollectionNfTributoDevolucaoClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfTributoIbsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfTributoIbsClassNfItem+"\r\n";
                foreach (Entidades.NfTributoIbsClass tmp in CollectionNfTributoIbsClassNfItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfTributoIsClassNfItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfTributoIsClassNfItem+"\r\n";
                foreach (Entidades.NfTributoIsClass tmp in CollectionNfTributoIsClassNfItem)
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
        public static NfItemClass CopiarEntidade(NfItemClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfItemClass toRet = new NfItemClass(usuario,conn);
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.NumeroItem= entidadeCopiar.NumeroItem;
 toRet.InformacoesAdd= entidadeCopiar.InformacoesAdd;
 toRet.Cfop= entidadeCopiar.Cfop;
 toRet.ValorTotalAproximadoTributos= entidadeCopiar.ValorTotalAproximadoTributos;
 toRet.CfopPartilhaIcms= entidadeCopiar.CfopPartilhaIcms;
 toRet.AlquotaFundoCombatePobreza= entidadeCopiar.AlquotaFundoCombatePobreza;

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
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;
       _numeroItemOriginal = NumeroItem;
       _numeroItemOriginalCommited = _numeroItemOriginal;
       _informacoesAddOriginal = InformacoesAdd;
       _informacoesAddOriginalCommited = _informacoesAddOriginal;
       _cfopOriginal = Cfop;
       _cfopOriginalCommited = _cfopOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _valorTotalAproximadoTributosOriginal = ValorTotalAproximadoTributos;
       _valorTotalAproximadoTributosOriginalCommited = _valorTotalAproximadoTributosOriginal;
       _cfopPartilhaIcmsOriginal = CfopPartilhaIcms;
       _cfopPartilhaIcmsOriginalCommited = _cfopPartilhaIcmsOriginal;
       _alquotaFundoCombatePobrezaOriginal = AlquotaFundoCombatePobreza;
       _alquotaFundoCombatePobrezaOriginalCommited = _alquotaFundoCombatePobrezaOriginal;

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
       _nfPrincipalOriginalCommited = NfPrincipal;
       _numeroItemOriginalCommited = NumeroItem;
       _informacoesAddOriginalCommited = InformacoesAdd;
       _cfopOriginalCommited = Cfop;
       _versionOriginalCommited = Version;
       _valorTotalAproximadoTributosOriginalCommited = ValorTotalAproximadoTributos;
       _cfopPartilhaIcmsOriginalCommited = CfopPartilhaIcms;
       _alquotaFundoCombatePobrezaOriginalCommited = AlquotaFundoCombatePobreza;

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
               if (_valueCollectionNfItemReferenciadoClassNfItemLoaded) 
               {
                  if (_collectionNfItemReferenciadoClassNfItemRemovidos != null) 
                  {
                     _collectionNfItemReferenciadoClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfItemReferenciadoClassNfItemRemovidos = new List<Entidades.NfItemReferenciadoClass>();
                  }
                  _collectionNfItemReferenciadoClassNfItemOriginal= (from a in _valueCollectionNfItemReferenciadoClassNfItem select a.ID).ToList();
                  _valueCollectionNfItemReferenciadoClassNfItemChanged = false;
                  _valueCollectionNfItemReferenciadoClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfItemTributoClassNfItemLoaded) 
               {
                  if (_collectionNfItemTributoClassNfItemRemovidos != null) 
                  {
                     _collectionNfItemTributoClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfItemTributoClassNfItemRemovidos = new List<Entidades.NfItemTributoClass>();
                  }
                  _collectionNfItemTributoClassNfItemOriginal= (from a in _valueCollectionNfItemTributoClassNfItem select a.ID).ToList();
                  _valueCollectionNfItemTributoClassNfItemChanged = false;
                  _valueCollectionNfItemTributoClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfItemTributoCofinsClassNfItemLoaded) 
               {
                  if (_collectionNfItemTributoCofinsClassNfItemRemovidos != null) 
                  {
                     _collectionNfItemTributoCofinsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfItemTributoCofinsClassNfItemRemovidos = new List<Entidades.NfItemTributoCofinsClass>();
                  }
                  _collectionNfItemTributoCofinsClassNfItemOriginal= (from a in _valueCollectionNfItemTributoCofinsClassNfItem select a.ID).ToList();
                  _valueCollectionNfItemTributoCofinsClassNfItemChanged = false;
                  _valueCollectionNfItemTributoCofinsClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfItemTributoIcmsClassNfItemLoaded) 
               {
                  if (_collectionNfItemTributoIcmsClassNfItemRemovidos != null) 
                  {
                     _collectionNfItemTributoIcmsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfItemTributoIcmsClassNfItemRemovidos = new List<Entidades.NfItemTributoIcmsClass>();
                  }
                  _collectionNfItemTributoIcmsClassNfItemOriginal= (from a in _valueCollectionNfItemTributoIcmsClassNfItem select a.ID).ToList();
                  _valueCollectionNfItemTributoIcmsClassNfItemChanged = false;
                  _valueCollectionNfItemTributoIcmsClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfItemTributoIimpClassNfItemLoaded) 
               {
                  if (_collectionNfItemTributoIimpClassNfItemRemovidos != null) 
                  {
                     _collectionNfItemTributoIimpClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfItemTributoIimpClassNfItemRemovidos = new List<Entidades.NfItemTributoIimpClass>();
                  }
                  _collectionNfItemTributoIimpClassNfItemOriginal= (from a in _valueCollectionNfItemTributoIimpClassNfItem select a.ID).ToList();
                  _valueCollectionNfItemTributoIimpClassNfItemChanged = false;
                  _valueCollectionNfItemTributoIimpClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfItemTributoIpiClassNfItemLoaded) 
               {
                  if (_collectionNfItemTributoIpiClassNfItemRemovidos != null) 
                  {
                     _collectionNfItemTributoIpiClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfItemTributoIpiClassNfItemRemovidos = new List<Entidades.NfItemTributoIpiClass>();
                  }
                  _collectionNfItemTributoIpiClassNfItemOriginal= (from a in _valueCollectionNfItemTributoIpiClassNfItem select a.ID).ToList();
                  _valueCollectionNfItemTributoIpiClassNfItemChanged = false;
                  _valueCollectionNfItemTributoIpiClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfItemTributoIssClassNfItemLoaded) 
               {
                  if (_collectionNfItemTributoIssClassNfItemRemovidos != null) 
                  {
                     _collectionNfItemTributoIssClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfItemTributoIssClassNfItemRemovidos = new List<Entidades.NfItemTributoIssClass>();
                  }
                  _collectionNfItemTributoIssClassNfItemOriginal= (from a in _valueCollectionNfItemTributoIssClassNfItem select a.ID).ToList();
                  _valueCollectionNfItemTributoIssClassNfItemChanged = false;
                  _valueCollectionNfItemTributoIssClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfItemTributoPisClassNfItemLoaded) 
               {
                  if (_collectionNfItemTributoPisClassNfItemRemovidos != null) 
                  {
                     _collectionNfItemTributoPisClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfItemTributoPisClassNfItemRemovidos = new List<Entidades.NfItemTributoPisClass>();
                  }
                  _collectionNfItemTributoPisClassNfItemOriginal= (from a in _valueCollectionNfItemTributoPisClassNfItem select a.ID).ToList();
                  _valueCollectionNfItemTributoPisClassNfItemChanged = false;
                  _valueCollectionNfItemTributoPisClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoClassNfItemRemovidos = new List<Entidades.NfProdutoClass>();
                  }
                  _collectionNfProdutoClassNfItemOriginal= (from a in _valueCollectionNfProdutoClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoClassNfItemChanged = false;
                  _valueCollectionNfProdutoClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoCbsClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoCbsClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoCbsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoCbsClassNfItemRemovidos = new List<Entidades.NfProdutoCbsClass>();
                  }
                  _collectionNfProdutoCbsClassNfItemOriginal= (from a in _valueCollectionNfProdutoCbsClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoCbsClassNfItemChanged = false;
                  _valueCollectionNfProdutoCbsClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoCofinsClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoCofinsClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoCofinsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoCofinsClassNfItemRemovidos = new List<Entidades.NfProdutoCofinsClass>();
                  }
                  _collectionNfProdutoCofinsClassNfItemOriginal= (from a in _valueCollectionNfProdutoCofinsClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoCofinsClassNfItemChanged = false;
                  _valueCollectionNfProdutoCofinsClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoDeclaracaoImportacaoClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoDeclaracaoImportacaoClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoDeclaracaoImportacaoClassNfItemRemovidos = new List<Entidades.NfProdutoDeclaracaoImportacaoClass>();
                  }
                  _collectionNfProdutoDeclaracaoImportacaoClassNfItemOriginal= (from a in _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemChanged = false;
                  _valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoDevolucaoClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoDevolucaoClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoDevolucaoClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoDevolucaoClassNfItemRemovidos = new List<Entidades.NfProdutoDevolucaoClass>();
                  }
                  _collectionNfProdutoDevolucaoClassNfItemOriginal= (from a in _valueCollectionNfProdutoDevolucaoClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoDevolucaoClassNfItemChanged = false;
                  _valueCollectionNfProdutoDevolucaoClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoIbsClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoIbsClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoIbsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoIbsClassNfItemRemovidos = new List<Entidades.NfProdutoIbsClass>();
                  }
                  _collectionNfProdutoIbsClassNfItemOriginal= (from a in _valueCollectionNfProdutoIbsClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoIbsClassNfItemChanged = false;
                  _valueCollectionNfProdutoIbsClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoIcmsClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoIcmsClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoIcmsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoIcmsClassNfItemRemovidos = new List<Entidades.NfProdutoIcmsClass>();
                  }
                  _collectionNfProdutoIcmsClassNfItemOriginal= (from a in _valueCollectionNfProdutoIcmsClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoIcmsClassNfItemChanged = false;
                  _valueCollectionNfProdutoIcmsClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoIimpClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoIimpClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoIimpClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoIimpClassNfItemRemovidos = new List<Entidades.NfProdutoIimpClass>();
                  }
                  _collectionNfProdutoIimpClassNfItemOriginal= (from a in _valueCollectionNfProdutoIimpClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoIimpClassNfItemChanged = false;
                  _valueCollectionNfProdutoIimpClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoIpiClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoIpiClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoIpiClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoIpiClassNfItemRemovidos = new List<Entidades.NfProdutoIpiClass>();
                  }
                  _collectionNfProdutoIpiClassNfItemOriginal= (from a in _valueCollectionNfProdutoIpiClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoIpiClassNfItemChanged = false;
                  _valueCollectionNfProdutoIpiClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoIsClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoIsClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoIsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoIsClassNfItemRemovidos = new List<Entidades.NfProdutoIsClass>();
                  }
                  _collectionNfProdutoIsClassNfItemOriginal= (from a in _valueCollectionNfProdutoIsClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoIsClassNfItemChanged = false;
                  _valueCollectionNfProdutoIsClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoIssClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoIssClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoIssClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoIssClassNfItemRemovidos = new List<Entidades.NfProdutoIssClass>();
                  }
                  _collectionNfProdutoIssClassNfItemOriginal= (from a in _valueCollectionNfProdutoIssClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoIssClassNfItemChanged = false;
                  _valueCollectionNfProdutoIssClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfProdutoPisClassNfItemLoaded) 
               {
                  if (_collectionNfProdutoPisClassNfItemRemovidos != null) 
                  {
                     _collectionNfProdutoPisClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoPisClassNfItemRemovidos = new List<Entidades.NfProdutoPisClass>();
                  }
                  _collectionNfProdutoPisClassNfItemOriginal= (from a in _valueCollectionNfProdutoPisClassNfItem select a.ID).ToList();
                  _valueCollectionNfProdutoPisClassNfItemChanged = false;
                  _valueCollectionNfProdutoPisClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfTributoCbsClassNfItemLoaded) 
               {
                  if (_collectionNfTributoCbsClassNfItemRemovidos != null) 
                  {
                     _collectionNfTributoCbsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfTributoCbsClassNfItemRemovidos = new List<Entidades.NfTributoCbsClass>();
                  }
                  _collectionNfTributoCbsClassNfItemOriginal= (from a in _valueCollectionNfTributoCbsClassNfItem select a.ID).ToList();
                  _valueCollectionNfTributoCbsClassNfItemChanged = false;
                  _valueCollectionNfTributoCbsClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfTributoDevolucaoClassNfItemLoaded) 
               {
                  if (_collectionNfTributoDevolucaoClassNfItemRemovidos != null) 
                  {
                     _collectionNfTributoDevolucaoClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfTributoDevolucaoClassNfItemRemovidos = new List<Entidades.NfTributoDevolucaoClass>();
                  }
                  _collectionNfTributoDevolucaoClassNfItemOriginal= (from a in _valueCollectionNfTributoDevolucaoClassNfItem select a.ID).ToList();
                  _valueCollectionNfTributoDevolucaoClassNfItemChanged = false;
                  _valueCollectionNfTributoDevolucaoClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfTributoIbsClassNfItemLoaded) 
               {
                  if (_collectionNfTributoIbsClassNfItemRemovidos != null) 
                  {
                     _collectionNfTributoIbsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfTributoIbsClassNfItemRemovidos = new List<Entidades.NfTributoIbsClass>();
                  }
                  _collectionNfTributoIbsClassNfItemOriginal= (from a in _valueCollectionNfTributoIbsClassNfItem select a.ID).ToList();
                  _valueCollectionNfTributoIbsClassNfItemChanged = false;
                  _valueCollectionNfTributoIbsClassNfItemCommitedChanged = false;
               }
               if (_valueCollectionNfTributoIsClassNfItemLoaded) 
               {
                  if (_collectionNfTributoIsClassNfItemRemovidos != null) 
                  {
                     _collectionNfTributoIsClassNfItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfTributoIsClassNfItemRemovidos = new List<Entidades.NfTributoIsClass>();
                  }
                  _collectionNfTributoIsClassNfItemOriginal= (from a in _valueCollectionNfTributoIsClassNfItem select a.ID).ToList();
                  _valueCollectionNfTributoIsClassNfItemChanged = false;
                  _valueCollectionNfTributoIsClassNfItemCommitedChanged = false;
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
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               NumeroItem=_numeroItemOriginal;
               _numeroItemOriginalCommited=_numeroItemOriginal;
               InformacoesAdd=_informacoesAddOriginal;
               _informacoesAddOriginalCommited=_informacoesAddOriginal;
               Cfop=_cfopOriginal;
               _cfopOriginalCommited=_cfopOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ValorTotalAproximadoTributos=_valorTotalAproximadoTributosOriginal;
               _valorTotalAproximadoTributosOriginalCommited=_valorTotalAproximadoTributosOriginal;
               CfopPartilhaIcms=_cfopPartilhaIcmsOriginal;
               _cfopPartilhaIcmsOriginalCommited=_cfopPartilhaIcmsOriginal;
               AlquotaFundoCombatePobreza=_alquotaFundoCombatePobrezaOriginal;
               _alquotaFundoCombatePobrezaOriginalCommited=_alquotaFundoCombatePobrezaOriginal;
               if (_valueCollectionNfItemReferenciadoClassNfItemLoaded) 
               {
                  CollectionNfItemReferenciadoClassNfItem.Clear();
                  foreach(int item in _collectionNfItemReferenciadoClassNfItemOriginal)
                  {
                    CollectionNfItemReferenciadoClassNfItem.Add(Entidades.NfItemReferenciadoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfItemReferenciadoClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfItemTributoClassNfItemLoaded) 
               {
                  CollectionNfItemTributoClassNfItem.Clear();
                  foreach(int item in _collectionNfItemTributoClassNfItemOriginal)
                  {
                    CollectionNfItemTributoClassNfItem.Add(Entidades.NfItemTributoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfItemTributoClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfItemTributoCofinsClassNfItemLoaded) 
               {
                  CollectionNfItemTributoCofinsClassNfItem.Clear();
                  foreach(int item in _collectionNfItemTributoCofinsClassNfItemOriginal)
                  {
                    CollectionNfItemTributoCofinsClassNfItem.Add(Entidades.NfItemTributoCofinsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfItemTributoCofinsClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfItemTributoIcmsClassNfItemLoaded) 
               {
                  CollectionNfItemTributoIcmsClassNfItem.Clear();
                  foreach(int item in _collectionNfItemTributoIcmsClassNfItemOriginal)
                  {
                    CollectionNfItemTributoIcmsClassNfItem.Add(Entidades.NfItemTributoIcmsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfItemTributoIcmsClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfItemTributoIimpClassNfItemLoaded) 
               {
                  CollectionNfItemTributoIimpClassNfItem.Clear();
                  foreach(int item in _collectionNfItemTributoIimpClassNfItemOriginal)
                  {
                    CollectionNfItemTributoIimpClassNfItem.Add(Entidades.NfItemTributoIimpClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfItemTributoIimpClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfItemTributoIpiClassNfItemLoaded) 
               {
                  CollectionNfItemTributoIpiClassNfItem.Clear();
                  foreach(int item in _collectionNfItemTributoIpiClassNfItemOriginal)
                  {
                    CollectionNfItemTributoIpiClassNfItem.Add(Entidades.NfItemTributoIpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfItemTributoIpiClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfItemTributoIssClassNfItemLoaded) 
               {
                  CollectionNfItemTributoIssClassNfItem.Clear();
                  foreach(int item in _collectionNfItemTributoIssClassNfItemOriginal)
                  {
                    CollectionNfItemTributoIssClassNfItem.Add(Entidades.NfItemTributoIssClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfItemTributoIssClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfItemTributoPisClassNfItemLoaded) 
               {
                  CollectionNfItemTributoPisClassNfItem.Clear();
                  foreach(int item in _collectionNfItemTributoPisClassNfItemOriginal)
                  {
                    CollectionNfItemTributoPisClassNfItem.Add(Entidades.NfItemTributoPisClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfItemTributoPisClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoClassNfItemLoaded) 
               {
                  CollectionNfProdutoClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoClassNfItemOriginal)
                  {
                    CollectionNfProdutoClassNfItem.Add(Entidades.NfProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoCbsClassNfItemLoaded) 
               {
                  CollectionNfProdutoCbsClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoCbsClassNfItemOriginal)
                  {
                    CollectionNfProdutoCbsClassNfItem.Add(Entidades.NfProdutoCbsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoCbsClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoCofinsClassNfItemLoaded) 
               {
                  CollectionNfProdutoCofinsClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoCofinsClassNfItemOriginal)
                  {
                    CollectionNfProdutoCofinsClassNfItem.Add(Entidades.NfProdutoCofinsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoCofinsClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded) 
               {
                  CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoDeclaracaoImportacaoClassNfItemOriginal)
                  {
                    CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Add(Entidades.NfProdutoDeclaracaoImportacaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoDeclaracaoImportacaoClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoDevolucaoClassNfItemLoaded) 
               {
                  CollectionNfProdutoDevolucaoClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoDevolucaoClassNfItemOriginal)
                  {
                    CollectionNfProdutoDevolucaoClassNfItem.Add(Entidades.NfProdutoDevolucaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoDevolucaoClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoIbsClassNfItemLoaded) 
               {
                  CollectionNfProdutoIbsClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoIbsClassNfItemOriginal)
                  {
                    CollectionNfProdutoIbsClassNfItem.Add(Entidades.NfProdutoIbsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoIbsClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoIcmsClassNfItemLoaded) 
               {
                  CollectionNfProdutoIcmsClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoIcmsClassNfItemOriginal)
                  {
                    CollectionNfProdutoIcmsClassNfItem.Add(Entidades.NfProdutoIcmsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoIcmsClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoIimpClassNfItemLoaded) 
               {
                  CollectionNfProdutoIimpClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoIimpClassNfItemOriginal)
                  {
                    CollectionNfProdutoIimpClassNfItem.Add(Entidades.NfProdutoIimpClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoIimpClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoIpiClassNfItemLoaded) 
               {
                  CollectionNfProdutoIpiClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoIpiClassNfItemOriginal)
                  {
                    CollectionNfProdutoIpiClassNfItem.Add(Entidades.NfProdutoIpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoIpiClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoIsClassNfItemLoaded) 
               {
                  CollectionNfProdutoIsClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoIsClassNfItemOriginal)
                  {
                    CollectionNfProdutoIsClassNfItem.Add(Entidades.NfProdutoIsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoIsClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoIssClassNfItemLoaded) 
               {
                  CollectionNfProdutoIssClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoIssClassNfItemOriginal)
                  {
                    CollectionNfProdutoIssClassNfItem.Add(Entidades.NfProdutoIssClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoIssClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfProdutoPisClassNfItemLoaded) 
               {
                  CollectionNfProdutoPisClassNfItem.Clear();
                  foreach(int item in _collectionNfProdutoPisClassNfItemOriginal)
                  {
                    CollectionNfProdutoPisClassNfItem.Add(Entidades.NfProdutoPisClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoPisClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfTributoCbsClassNfItemLoaded) 
               {
                  CollectionNfTributoCbsClassNfItem.Clear();
                  foreach(int item in _collectionNfTributoCbsClassNfItemOriginal)
                  {
                    CollectionNfTributoCbsClassNfItem.Add(Entidades.NfTributoCbsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfTributoCbsClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfTributoDevolucaoClassNfItemLoaded) 
               {
                  CollectionNfTributoDevolucaoClassNfItem.Clear();
                  foreach(int item in _collectionNfTributoDevolucaoClassNfItemOriginal)
                  {
                    CollectionNfTributoDevolucaoClassNfItem.Add(Entidades.NfTributoDevolucaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfTributoDevolucaoClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfTributoIbsClassNfItemLoaded) 
               {
                  CollectionNfTributoIbsClassNfItem.Clear();
                  foreach(int item in _collectionNfTributoIbsClassNfItemOriginal)
                  {
                    CollectionNfTributoIbsClassNfItem.Add(Entidades.NfTributoIbsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfTributoIbsClassNfItemRemovidos.Clear();
               }
               if (_valueCollectionNfTributoIsClassNfItemLoaded) 
               {
                  CollectionNfTributoIsClassNfItem.Clear();
                  foreach(int item in _collectionNfTributoIsClassNfItemOriginal)
                  {
                    CollectionNfTributoIsClassNfItem.Add(Entidades.NfTributoIsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfTributoIsClassNfItemRemovidos.Clear();
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
               if (_valueCollectionNfItemReferenciadoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemReferenciadoClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoCofinsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoCofinsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoIcmsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoIcmsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoIimpClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoIimpClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoIpiClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoIpiClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoIssClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoIssClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoPisClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoPisClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoCbsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoCbsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoCofinsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoCofinsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoDevolucaoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoDevolucaoClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIbsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIbsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIcmsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIcmsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIimpClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIimpClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIpiClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIpiClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIssClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIssClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoPisClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoPisClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTributoCbsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfTributoCbsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTributoDevolucaoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfTributoDevolucaoClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTributoIbsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfTributoIbsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTributoIsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfTributoIsClassNfItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemReferenciadoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemReferenciadoClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoCofinsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoCofinsClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoIcmsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoIcmsClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoIimpClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoIimpClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoIpiClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoIpiClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoIssClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoIssClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoPisClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoPisClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoCbsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoCbsClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoCofinsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoCofinsClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoDevolucaoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoDevolucaoClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIbsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIbsClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIcmsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIcmsClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIimpClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIimpClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIpiClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIpiClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIsClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIssClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIssClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoPisClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoPisClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTributoCbsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfTributoCbsClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTributoDevolucaoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfTributoDevolucaoClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTributoIbsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfTributoIbsClassNfItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTributoIsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfTributoIsClassNfItem.Any(item => item.IsDirty());
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
       if (_nfPrincipalOriginal!=null)
       {
          dirty = !_nfPrincipalOriginal.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       dirty = _numeroItemOriginal != NumeroItem;
      if (dirty) return true;
       dirty = _informacoesAddOriginal != InformacoesAdd;
      if (dirty) return true;
       dirty = _cfopOriginal != Cfop;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _valorTotalAproximadoTributosOriginal != ValorTotalAproximadoTributos;
      if (dirty) return true;
       dirty = _cfopPartilhaIcmsOriginal != CfopPartilhaIcms;
      if (dirty) return true;
       dirty = _alquotaFundoCombatePobrezaOriginal != AlquotaFundoCombatePobreza;

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
               if (_valueCollectionNfItemReferenciadoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemReferenciadoClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoCofinsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoCofinsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoIcmsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoIcmsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoIimpClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoIimpClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoIpiClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoIpiClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoIssClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoIssClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemTributoPisClassNfItemLoaded) 
               {
                  if (_valueCollectionNfItemTributoPisClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoCbsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoCbsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoCofinsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoCofinsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoDevolucaoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoDevolucaoClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIbsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIbsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIcmsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIcmsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIimpClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIimpClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIpiClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIpiClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoIssClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoIssClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoPisClassNfItemLoaded) 
               {
                  if (_valueCollectionNfProdutoPisClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTributoCbsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfTributoCbsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTributoDevolucaoClassNfItemLoaded) 
               {
                  if (_valueCollectionNfTributoDevolucaoClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTributoIbsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfTributoIbsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTributoIsClassNfItemLoaded) 
               {
                  if (_valueCollectionNfTributoIsClassNfItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemReferenciadoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemReferenciadoClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoCofinsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoCofinsClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoIcmsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoIcmsClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoIimpClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoIimpClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoIpiClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoIpiClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoIssClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoIssClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemTributoPisClassNfItemLoaded) 
               {
                   tempRet = CollectionNfItemTributoPisClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoCbsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoCbsClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoCofinsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoCofinsClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoDevolucaoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoDevolucaoClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIbsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIbsClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIcmsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIcmsClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIimpClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIimpClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIpiClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIpiClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIsClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoIssClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoIssClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfProdutoPisClassNfItemLoaded) 
               {
                   tempRet = CollectionNfProdutoPisClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTributoCbsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfTributoCbsClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTributoDevolucaoClassNfItemLoaded) 
               {
                   tempRet = CollectionNfTributoDevolucaoClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTributoIbsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfTributoIbsClassNfItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTributoIsClassNfItemLoaded) 
               {
                   tempRet = CollectionNfTributoIsClassNfItem.Any(item => item.IsDirtyCommited());
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
       if (_nfPrincipalOriginalCommited!=null)
       {
          dirty = !_nfPrincipalOriginalCommited.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       dirty = _numeroItemOriginalCommited != NumeroItem;
      if (dirty) return true;
       dirty = _informacoesAddOriginalCommited != InformacoesAdd;
      if (dirty) return true;
       dirty = _cfopOriginalCommited != Cfop;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _valorTotalAproximadoTributosOriginalCommited != ValorTotalAproximadoTributos;
      if (dirty) return true;
       dirty = _cfopPartilhaIcmsOriginalCommited != CfopPartilhaIcms;
      if (dirty) return true;
       dirty = _alquotaFundoCombatePobrezaOriginalCommited != AlquotaFundoCombatePobreza;

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
               if (_valueCollectionNfItemReferenciadoClassNfItemLoaded) 
               {
                  foreach(NfItemReferenciadoClass item in CollectionNfItemReferenciadoClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfItemTributoClassNfItemLoaded) 
               {
                  foreach(NfItemTributoClass item in CollectionNfItemTributoClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfItemTributoCofinsClassNfItemLoaded) 
               {
                  foreach(NfItemTributoCofinsClass item in CollectionNfItemTributoCofinsClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfItemTributoIcmsClassNfItemLoaded) 
               {
                  foreach(NfItemTributoIcmsClass item in CollectionNfItemTributoIcmsClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfItemTributoIimpClassNfItemLoaded) 
               {
                  foreach(NfItemTributoIimpClass item in CollectionNfItemTributoIimpClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfItemTributoIpiClassNfItemLoaded) 
               {
                  foreach(NfItemTributoIpiClass item in CollectionNfItemTributoIpiClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfItemTributoIssClassNfItemLoaded) 
               {
                  foreach(NfItemTributoIssClass item in CollectionNfItemTributoIssClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfItemTributoPisClassNfItemLoaded) 
               {
                  foreach(NfItemTributoPisClass item in CollectionNfItemTributoPisClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoClassNfItemLoaded) 
               {
                  foreach(NfProdutoClass item in CollectionNfProdutoClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoCbsClassNfItemLoaded) 
               {
                  foreach(NfProdutoCbsClass item in CollectionNfProdutoCbsClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoCofinsClassNfItemLoaded) 
               {
                  foreach(NfProdutoCofinsClass item in CollectionNfProdutoCofinsClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded) 
               {
                  foreach(NfProdutoDeclaracaoImportacaoClass item in CollectionNfProdutoDeclaracaoImportacaoClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoDevolucaoClassNfItemLoaded) 
               {
                  foreach(NfProdutoDevolucaoClass item in CollectionNfProdutoDevolucaoClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoIbsClassNfItemLoaded) 
               {
                  foreach(NfProdutoIbsClass item in CollectionNfProdutoIbsClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoIcmsClassNfItemLoaded) 
               {
                  foreach(NfProdutoIcmsClass item in CollectionNfProdutoIcmsClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoIimpClassNfItemLoaded) 
               {
                  foreach(NfProdutoIimpClass item in CollectionNfProdutoIimpClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoIpiClassNfItemLoaded) 
               {
                  foreach(NfProdutoIpiClass item in CollectionNfProdutoIpiClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoIsClassNfItemLoaded) 
               {
                  foreach(NfProdutoIsClass item in CollectionNfProdutoIsClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoIssClassNfItemLoaded) 
               {
                  foreach(NfProdutoIssClass item in CollectionNfProdutoIssClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfProdutoPisClassNfItemLoaded) 
               {
                  foreach(NfProdutoPisClass item in CollectionNfProdutoPisClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfTributoCbsClassNfItemLoaded) 
               {
                  foreach(NfTributoCbsClass item in CollectionNfTributoCbsClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfTributoDevolucaoClassNfItemLoaded) 
               {
                  foreach(NfTributoDevolucaoClass item in CollectionNfTributoDevolucaoClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfTributoIbsClassNfItemLoaded) 
               {
                  foreach(NfTributoIbsClass item in CollectionNfTributoIbsClassNfItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfTributoIsClassNfItemLoaded) 
               {
                  foreach(NfTributoIsClass item in CollectionNfTributoIsClassNfItem)
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
             case "NfPrincipal":
                return this.NfPrincipal;
             case "NumeroItem":
                return this.NumeroItem;
             case "InformacoesAdd":
                return this.InformacoesAdd;
             case "Cfop":
                return this.Cfop;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ValorTotalAproximadoTributos":
                return this.ValorTotalAproximadoTributos;
             case "CfopPartilhaIcms":
                return this.CfopPartilhaIcms;
             case "AlquotaFundoCombatePobreza":
                return this.AlquotaFundoCombatePobreza;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfPrincipal!=null)
                NfPrincipal.ChangeSingleConnection(newConnection);
               if (_valueCollectionNfItemReferenciadoClassNfItemLoaded) 
               {
                  foreach(NfItemReferenciadoClass item in CollectionNfItemReferenciadoClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfItemTributoClassNfItemLoaded) 
               {
                  foreach(NfItemTributoClass item in CollectionNfItemTributoClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfItemTributoCofinsClassNfItemLoaded) 
               {
                  foreach(NfItemTributoCofinsClass item in CollectionNfItemTributoCofinsClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfItemTributoIcmsClassNfItemLoaded) 
               {
                  foreach(NfItemTributoIcmsClass item in CollectionNfItemTributoIcmsClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfItemTributoIimpClassNfItemLoaded) 
               {
                  foreach(NfItemTributoIimpClass item in CollectionNfItemTributoIimpClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfItemTributoIpiClassNfItemLoaded) 
               {
                  foreach(NfItemTributoIpiClass item in CollectionNfItemTributoIpiClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfItemTributoIssClassNfItemLoaded) 
               {
                  foreach(NfItemTributoIssClass item in CollectionNfItemTributoIssClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfItemTributoPisClassNfItemLoaded) 
               {
                  foreach(NfItemTributoPisClass item in CollectionNfItemTributoPisClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoClassNfItemLoaded) 
               {
                  foreach(NfProdutoClass item in CollectionNfProdutoClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoCbsClassNfItemLoaded) 
               {
                  foreach(NfProdutoCbsClass item in CollectionNfProdutoCbsClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoCofinsClassNfItemLoaded) 
               {
                  foreach(NfProdutoCofinsClass item in CollectionNfProdutoCofinsClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded) 
               {
                  foreach(NfProdutoDeclaracaoImportacaoClass item in CollectionNfProdutoDeclaracaoImportacaoClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoDevolucaoClassNfItemLoaded) 
               {
                  foreach(NfProdutoDevolucaoClass item in CollectionNfProdutoDevolucaoClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoIbsClassNfItemLoaded) 
               {
                  foreach(NfProdutoIbsClass item in CollectionNfProdutoIbsClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoIcmsClassNfItemLoaded) 
               {
                  foreach(NfProdutoIcmsClass item in CollectionNfProdutoIcmsClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoIimpClassNfItemLoaded) 
               {
                  foreach(NfProdutoIimpClass item in CollectionNfProdutoIimpClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoIpiClassNfItemLoaded) 
               {
                  foreach(NfProdutoIpiClass item in CollectionNfProdutoIpiClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoIsClassNfItemLoaded) 
               {
                  foreach(NfProdutoIsClass item in CollectionNfProdutoIsClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoIssClassNfItemLoaded) 
               {
                  foreach(NfProdutoIssClass item in CollectionNfProdutoIssClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfProdutoPisClassNfItemLoaded) 
               {
                  foreach(NfProdutoPisClass item in CollectionNfProdutoPisClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfTributoCbsClassNfItemLoaded) 
               {
                  foreach(NfTributoCbsClass item in CollectionNfTributoCbsClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfTributoDevolucaoClassNfItemLoaded) 
               {
                  foreach(NfTributoDevolucaoClass item in CollectionNfTributoDevolucaoClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfTributoIbsClassNfItemLoaded) 
               {
                  foreach(NfTributoIbsClass item in CollectionNfTributoIbsClassNfItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfTributoIsClassNfItemLoaded) 
               {
                  foreach(NfTributoIsClass item in CollectionNfTributoIsClassNfItem)
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
                  command.CommandText += " COUNT(nf_item.id_nf_item) " ;
               }
               else
               {
               command.CommandText += "nf_item.id_nf_item, " ;
               command.CommandText += "nf_item.id_nf_principal, " ;
               command.CommandText += "nf_item.nfi_numero_item, " ;
               command.CommandText += "nf_item.nfi_informacoes_add, " ;
               command.CommandText += "nf_item.nfi_cfop, " ;
               command.CommandText += "nf_item.entity_uid, " ;
               command.CommandText += "nf_item.version, " ;
               command.CommandText += "nf_item.nfi_valor_total_aproximado_tributos, " ;
               command.CommandText += "nf_item.nfi_cfop_partilha_icms, " ;
               command.CommandText += "nf_item.nfi_alquota_fundo_combate_pobreza " ;
               }
               command.CommandText += " FROM  nf_item ";
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
                        orderByClause += " , nfi_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nfi_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_item.id_acs_usuario_ultima_revisao ";
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
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item.id_nf_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal":
                     case "NfPrincipal":
                     command.CommandText += " LEFT JOIN nf_principal as nf_principal_NfPrincipal ON nf_principal_NfPrincipal.id_nf_principal = nf_item.id_nf_principal ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal_NfPrincipal.nfp_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal_NfPrincipal.nfp_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfi_numero_item":
                     case "NumeroItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item.nfi_numero_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item.nfi_numero_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfi_informacoes_add":
                     case "InformacoesAdd":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item.nfi_informacoes_add " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item.nfi_informacoes_add) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfi_cfop":
                     case "Cfop":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item.nfi_cfop " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item.nfi_cfop) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_item.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfi_valor_total_aproximado_tributos":
                     case "ValorTotalAproximadoTributos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item.nfi_valor_total_aproximado_tributos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item.nfi_valor_total_aproximado_tributos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfi_cfop_partilha_icms":
                     case "CfopPartilhaIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item.nfi_cfop_partilha_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item.nfi_cfop_partilha_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfi_alquota_fundo_combate_pobreza":
                     case "AlquotaFundoCombatePobreza":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item.nfi_alquota_fundo_combate_pobreza " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item.nfi_alquota_fundo_combate_pobreza) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfi_informacoes_add")) 
                        {
                           whereClause += " OR UPPER(nf_item.nfi_informacoes_add) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item.nfi_informacoes_add) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_item.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.id_nf_item = :nf_item_ID_2057 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_ID_2057", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfPrincipal" || parametro.FieldName == "id_nf_principal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfPrincipalClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfPrincipalClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.id_nf_principal = :nf_item_NfPrincipal_5873 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_NfPrincipal_5873", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroItem" || parametro.FieldName == "nfi_numero_item")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item.nfi_numero_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.nfi_numero_item = :nf_item_NumeroItem_9700 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_NumeroItem_9700", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacoesAdd" || parametro.FieldName == "nfi_informacoes_add")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item.nfi_informacoes_add IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.nfi_informacoes_add LIKE :nf_item_InformacoesAdd_4793 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_InformacoesAdd_4793", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cfop" || parametro.FieldName == "nfi_cfop")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item.nfi_cfop IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.nfi_cfop = :nf_item_Cfop_4635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_Cfop_4635", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.entity_uid LIKE :nf_item_EntityUid_5302 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_EntityUid_5302", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_item.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.version = :nf_item_Version_4278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_Version_4278", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalAproximadoTributos" || parametro.FieldName == "nfi_valor_total_aproximado_tributos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item.nfi_valor_total_aproximado_tributos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.nfi_valor_total_aproximado_tributos = :nf_item_ValorTotalAproximadoTributos_8941 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_ValorTotalAproximadoTributos_8941", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CfopPartilhaIcms" || parametro.FieldName == "nfi_cfop_partilha_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item.nfi_cfop_partilha_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.nfi_cfop_partilha_icms = :nf_item_CfopPartilhaIcms_1061 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_CfopPartilhaIcms_1061", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AlquotaFundoCombatePobreza" || parametro.FieldName == "nfi_alquota_fundo_combate_pobreza")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item.nfi_alquota_fundo_combate_pobreza IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.nfi_alquota_fundo_combate_pobreza = :nf_item_AlquotaFundoCombatePobreza_9151 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_AlquotaFundoCombatePobreza_9151", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacoesAddExato" || parametro.FieldName == "InformacoesAddExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item.nfi_informacoes_add IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.nfi_informacoes_add LIKE :nf_item_InformacoesAdd_6718 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_InformacoesAdd_6718", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item.entity_uid LIKE :nf_item_EntityUid_4223 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_EntityUid_4223", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfItemClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfItemClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfItemClass), Convert.ToInt32(read["id_nf_item"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfItemClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_item"]);
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     entidade.NumeroItem = (int)read["nfi_numero_item"];
                     entidade.InformacoesAdd = (read["nfi_informacoes_add"] != DBNull.Value ? read["nfi_informacoes_add"].ToString() : null);
                     entidade.Cfop = (int)read["nfi_cfop"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ValorTotalAproximadoTributos = read["nfi_valor_total_aproximado_tributos"] as double?;
                     entidade.CfopPartilhaIcms = Convert.ToBoolean(Convert.ToInt16(read["nfi_cfop_partilha_icms"]));
                     entidade.AlquotaFundoCombatePobreza = (double)read["nfi_alquota_fundo_combate_pobreza"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfItemClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
