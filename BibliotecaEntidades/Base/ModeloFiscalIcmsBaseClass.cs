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
     [Table("modelo_fiscal_icms","mfi")]
     public class ModeloFiscalIcmsBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ModeloFiscalIcmsClass";
protected const string ErroDelete = "Erro ao excluir o ModeloFiscalIcmsClass  ";
protected const string ErroSave = "Erro ao salvar o ModeloFiscalIcmsClass.";
protected const string ErroCollectionMaterialFiscalClassModeloFiscalIcms = "Erro ao carregar a coleção de MaterialFiscalClass.";
protected const string ErroCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms = "Erro ao carregar a coleção de ModeloFiscalIcmsEstadoClass.";
protected const string ErroCollectionProdutoFiscalClassModeloFiscalIcms = "Erro ao carregar a coleção de ProdutoFiscalClass.";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
protected const string ErroCstObrigatorio = "O campo Cst é obrigatório";
protected const string ErroCstComprimento = "O campo Cst deve ter no máximo 3 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do ModeloFiscalIcmsClass.";
protected const string MensagemUtilizadoCollectionMaterialFiscalClassModeloFiscalIcms =  "A entidade ModeloFiscalIcmsClass está sendo utilizada nos seguintes MaterialFiscalClass:";
protected const string MensagemUtilizadoCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms =  "A entidade ModeloFiscalIcmsClass está sendo utilizada nos seguintes ModeloFiscalIcmsEstadoClass:";
protected const string MensagemUtilizadoCollectionProdutoFiscalClassModeloFiscalIcms =  "A entidade ModeloFiscalIcmsClass está sendo utilizada nos seguintes ProdutoFiscalClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ModeloFiscalIcmsClass está sendo utilizada.";
#endregion
       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("mfi_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected string _cstOriginal{get;private set;}
       private string _cstOriginalCommited{get; set;}
        private string _valueCst;
         [Column("mfi_cst")]
        public virtual string Cst
         { 
            get { return this._valueCst; } 
            set 
            { 
                if (this._valueCst == value)return;
                 this._valueCst = value; 
            } 
        } 

       protected int? _modalidadeDeterminacaoBcOriginal{get;private set;}
       private int? _modalidadeDeterminacaoBcOriginalCommited{get; set;}
        private int? _valueModalidadeDeterminacaoBc;
         [Column("mfi_modalidade_determinacao_bc")]
        public virtual int? ModalidadeDeterminacaoBc
         { 
            get { return this._valueModalidadeDeterminacaoBc; } 
            set 
            { 
                if (this._valueModalidadeDeterminacaoBc == value)return;
                 this._valueModalidadeDeterminacaoBc = value; 
            } 
        } 

       protected bool _reducaoBcOriginal{get;private set;}
       private bool _reducaoBcOriginalCommited{get; set;}
        private bool _valueReducaoBc;
         [Column("mfi_reducao_bc")]
        public virtual bool ReducaoBc
         { 
            get { return this._valueReducaoBc; } 
            set 
            { 
                if (this._valueReducaoBc == value)return;
                 this._valueReducaoBc = value; 
            } 
        } 

       protected double? _percentualReducaoBcOriginal{get;private set;}
       private double? _percentualReducaoBcOriginalCommited{get; set;}
        private double? _valuePercentualReducaoBc;
         [Column("mfi_percentual_reducao_bc")]
        public virtual double? PercentualReducaoBc
         { 
            get { return this._valuePercentualReducaoBc; } 
            set 
            { 
                if (this._valuePercentualReducaoBc == value)return;
                 this._valuePercentualReducaoBc = value; 
            } 
        } 

       protected TipoTributacaoST _stOriginal{get;private set;}
       private TipoTributacaoST _stOriginalCommited{get; set;}
        private TipoTributacaoST _valueSt;
         [Column("mfi_st")]
        public virtual TipoTributacaoST St
         { 
            get { return this._valueSt; } 
            set 
            { 
                if (this._valueSt == value)return;
                 this._valueSt = value; 
            } 
        } 

        public bool St_STComReducaoBCST
         { 
            get { return this._valueSt == BibliotecaEntidades.Base.TipoTributacaoST.STComReducaoBCST; } 
            set { if (value) this._valueSt = BibliotecaEntidades.Base.TipoTributacaoST.STComReducaoBCST; }
         } 

        public bool St_SemST
         { 
            get { return this._valueSt == BibliotecaEntidades.Base.TipoTributacaoST.SemST; } 
            set { if (value) this._valueSt = BibliotecaEntidades.Base.TipoTributacaoST.SemST; }
         } 

        public bool St_SomenteST
         { 
            get { return this._valueSt == BibliotecaEntidades.Base.TipoTributacaoST.SomenteST; } 
            set { if (value) this._valueSt = BibliotecaEntidades.Base.TipoTributacaoST.SomenteST; }
         } 

       protected int? _modalidadeDeterminicaoBcStOriginal{get;private set;}
       private int? _modalidadeDeterminicaoBcStOriginalCommited{get; set;}
        private int? _valueModalidadeDeterminicaoBcSt;
         [Column("mfi_modalidade_determinicao_bc_st")]
        public virtual int? ModalidadeDeterminicaoBcSt
         { 
            get { return this._valueModalidadeDeterminicaoBcSt; } 
            set 
            { 
                if (this._valueModalidadeDeterminicaoBcSt == value)return;
                 this._valueModalidadeDeterminicaoBcSt = value; 
            } 
        } 

       protected double? _percentualReducaoBcStOriginal{get;private set;}
       private double? _percentualReducaoBcStOriginalCommited{get; set;}
        private double? _valuePercentualReducaoBcSt;
         [Column("mfi_percentual_reducao_bc_st")]
        public virtual double? PercentualReducaoBcSt
         { 
            get { return this._valuePercentualReducaoBcSt; } 
            set 
            { 
                if (this._valuePercentualReducaoBcSt == value)return;
                 this._valuePercentualReducaoBcSt = value; 
            } 
        } 

       protected double? _percentualMvaStOriginal{get;private set;}
       private double? _percentualMvaStOriginalCommited{get; set;}
        private double? _valuePercentualMvaSt;
         [Column("mfi_percentual_mva_st")]
        public virtual double? PercentualMvaSt
         { 
            get { return this._valuePercentualMvaSt; } 
            set 
            { 
                if (this._valuePercentualMvaSt == value)return;
                 this._valuePercentualMvaSt = value; 
            } 
        } 

       protected double? _percentualBcPropriaOriginal{get;private set;}
       private double? _percentualBcPropriaOriginalCommited{get; set;}
        private double? _valuePercentualBcPropria;
         [Column("mfi_percentual_bc_propria")]
        public virtual double? PercentualBcPropria
         { 
            get { return this._valuePercentualBcPropria; } 
            set 
            { 
                if (this._valuePercentualBcPropria == value)return;
                 this._valuePercentualBcPropria = value; 
            } 
        } 

       protected string _ufStOriginal{get;private set;}
       private string _ufStOriginalCommited{get; set;}
        private string _valueUfSt;
         [Column("mfi_uf_st")]
        public virtual string UfSt
         { 
            get { return this._valueUfSt; } 
            set 
            { 
                if (this._valueUfSt == value)return;
                 this._valueUfSt = value; 
            } 
        } 

       protected double? _aliquotaCreditoOriginal{get;private set;}
       private double? _aliquotaCreditoOriginalCommited{get; set;}
        private double? _valueAliquotaCredito;
         [Column("mfi_aliquota_credito")]
        public virtual double? AliquotaCredito
         { 
            get { return this._valueAliquotaCredito; } 
            set 
            { 
                if (this._valueAliquotaCredito == value)return;
                 this._valueAliquotaCredito = value; 
            } 
        } 

       protected double _percentualDiferimentoOriginal{get;private set;}
       private double _percentualDiferimentoOriginalCommited{get; set;}
        private double _valuePercentualDiferimento;
         [Column("mfi_percentual_diferimento")]
        public virtual double PercentualDiferimento
         { 
            get { return this._valuePercentualDiferimento; } 
            set 
            { 
                if (this._valuePercentualDiferimento == value)return;
                 this._valuePercentualDiferimento = value; 
            } 
        } 

       protected string _obsDiferimentoOriginal{get;private set;}
       private string _obsDiferimentoOriginalCommited{get; set;}
        private string _valueObsDiferimento;
         [Column("mfi_obs_diferimento")]
        public virtual string ObsDiferimento
         { 
            get { return this._valueObsDiferimento; } 
            set 
            { 
                if (this._valueObsDiferimento == value)return;
                 this._valueObsDiferimento = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EstadoClass _estadoStOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstadoClass _estadoStOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstadoClass _valueEstadoSt;
        [Column("id_estado_st", "estado", "id_estado")]
       public virtual BibliotecaEntidades.Entidades.EstadoClass EstadoSt
        { 
           get {                 return this._valueEstadoSt; } 
           set 
           { 
                if (this._valueEstadoSt == value)return;
                 this._valueEstadoSt = value; 
           } 
       } 

       protected double? _percentualCreditoPresumidoOriginal{get;private set;}
       private double? _percentualCreditoPresumidoOriginalCommited{get; set;}
        private double? _valuePercentualCreditoPresumido;
         [Column("mfi_percentual_credito_presumido")]
        public virtual double? PercentualCreditoPresumido
         { 
            get { return this._valuePercentualCreditoPresumido; } 
            set 
            { 
                if (this._valuePercentualCreditoPresumido == value)return;
                 this._valuePercentualCreditoPresumido = value; 
            } 
        } 

       protected double? _percentualLimiteCreditoPresumidoOriginal{get;private set;}
       private double? _percentualLimiteCreditoPresumidoOriginalCommited{get; set;}
        private double? _valuePercentualLimiteCreditoPresumido;
         [Column("mfi_percentual_limite_credito_presumido")]
        public virtual double? PercentualLimiteCreditoPresumido
         { 
            get { return this._valuePercentualLimiteCreditoPresumido; } 
            set 
            { 
                if (this._valuePercentualLimiteCreditoPresumido == value)return;
                 this._valuePercentualLimiteCreditoPresumido = value; 
            } 
        } 

       protected string _observacaoCreditoPresumidoOriginal{get;private set;}
       private string _observacaoCreditoPresumidoOriginalCommited{get; set;}
        private string _valueObservacaoCreditoPresumido;
         [Column("mfi_observacao_credito_presumido")]
        public virtual string ObservacaoCreditoPresumido
         { 
            get { return this._valueObservacaoCreditoPresumido; } 
            set 
            { 
                if (this._valueObservacaoCreditoPresumido == value)return;
                 this._valueObservacaoCreditoPresumido = value; 
            } 
        } 

       protected string _observacaoCreditoIcmsOriginal{get;private set;}
       private string _observacaoCreditoIcmsOriginalCommited{get; set;}
        private string _valueObservacaoCreditoIcms;
         [Column("mfi_observacao_credito_icms")]
        public virtual string ObservacaoCreditoIcms
         { 
            get { return this._valueObservacaoCreditoIcms; } 
            set 
            { 
                if (this._valueObservacaoCreditoIcms == value)return;
                 this._valueObservacaoCreditoIcms = value; 
            } 
        } 

       private List<long> _collectionMaterialFiscalClassModeloFiscalIcmsOriginal;
       private List<Entidades.MaterialFiscalClass > _collectionMaterialFiscalClassModeloFiscalIcmsRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFiscalClassModeloFiscalIcmsChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFiscalClassModeloFiscalIcmsCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialFiscalClass> _valueCollectionMaterialFiscalClassModeloFiscalIcms { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialFiscalClass> CollectionMaterialFiscalClassModeloFiscalIcms 
       { 
           get { if(!_valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialFiscalClassModeloFiscalIcms();}
return this._valueCollectionMaterialFiscalClassModeloFiscalIcms; } 
           set 
           { 
               this._valueCollectionMaterialFiscalClassModeloFiscalIcms = value; 
               this._valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded = true; 
           } 
       } 

       private List<long> _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsOriginal;
       private List<Entidades.ModeloFiscalIcmsEstadoClass > _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ModeloFiscalIcmsEstadoClass> _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ModeloFiscalIcmsEstadoClass> CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms 
       { 
           get { if(!_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded && !this.DisableLoadCollection){this.LoadCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms();}
return this._valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms; } 
           set 
           { 
               this._valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms = value; 
               this._valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoFiscalClassModeloFiscalIcmsOriginal;
       private List<Entidades.ProdutoFiscalClass > _collectionProdutoFiscalClassModeloFiscalIcmsRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFiscalClassModeloFiscalIcmsChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFiscalClassModeloFiscalIcmsCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoFiscalClass> _valueCollectionProdutoFiscalClassModeloFiscalIcms { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoFiscalClass> CollectionProdutoFiscalClassModeloFiscalIcms 
       { 
           get { if(!_valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoFiscalClassModeloFiscalIcms();}
return this._valueCollectionProdutoFiscalClassModeloFiscalIcms; } 
           set 
           { 
               this._valueCollectionProdutoFiscalClassModeloFiscalIcms = value; 
               this._valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded = true; 
           } 
       } 

        public ModeloFiscalIcmsBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ReducaoBc = false;
           this.St = (TipoTributacaoST)0;
           this.PercentualDiferimento = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ModeloFiscalIcmsClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ModeloFiscalIcmsClass) GetEntity(typeof(ModeloFiscalIcmsClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionMaterialFiscalClassModeloFiscalIcmsChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialFiscalClassModeloFiscalIcmsChanged = true;
                  _valueCollectionMaterialFiscalClassModeloFiscalIcmsCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialFiscalClassModeloFiscalIcmsChanged = true; 
                  _valueCollectionMaterialFiscalClassModeloFiscalIcmsCommitedChanged = true;
                 foreach (Entidades.MaterialFiscalClass item in e.OldItems) 
                 { 
                     _collectionMaterialFiscalClassModeloFiscalIcmsRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialFiscalClassModeloFiscalIcmsChanged = true; 
                  _valueCollectionMaterialFiscalClassModeloFiscalIcmsCommitedChanged = true;
                 foreach (Entidades.MaterialFiscalClass item in _valueCollectionMaterialFiscalClassModeloFiscalIcms) 
                 { 
                     _collectionMaterialFiscalClassModeloFiscalIcmsRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialFiscalClassModeloFiscalIcms()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialFiscalClass> oc;
                _valueCollectionMaterialFiscalClassModeloFiscalIcmsChanged = false;
                 _valueCollectionMaterialFiscalClassModeloFiscalIcmsCommitedChanged = false;
                _collectionMaterialFiscalClassModeloFiscalIcmsRemovidos = new List<Entidades.MaterialFiscalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialFiscalClass>();
                }
                else{ 
                   Entidades.MaterialFiscalClass search = new Entidades.MaterialFiscalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialFiscalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ModeloFiscalIcms", this),                     }                       ).Cast<Entidades.MaterialFiscalClass>().ToList());
                 }
                 _valueCollectionMaterialFiscalClassModeloFiscalIcms = new BindingList<Entidades.MaterialFiscalClass>(oc); 
                 _collectionMaterialFiscalClassModeloFiscalIcmsOriginal= (from a in _valueCollectionMaterialFiscalClassModeloFiscalIcms select a.ID).ToList();
                 _valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded = true;
                 oc.CollectionChanged += CollectionMaterialFiscalClassModeloFiscalIcmsChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialFiscalClassModeloFiscalIcms+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsChanged = true;
                  _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsChanged = true; 
                  _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsCommitedChanged = true;
                 foreach (Entidades.ModeloFiscalIcmsEstadoClass item in e.OldItems) 
                 { 
                     _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsChanged = true; 
                  _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsCommitedChanged = true;
                 foreach (Entidades.ModeloFiscalIcmsEstadoClass item in _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms) 
                 { 
                     _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms()
         {
            try
            {
                 ObservableCollection<Entidades.ModeloFiscalIcmsEstadoClass> oc;
                _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsChanged = false;
                 _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsCommitedChanged = false;
                _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsRemovidos = new List<Entidades.ModeloFiscalIcmsEstadoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ModeloFiscalIcmsEstadoClass>();
                }
                else{ 
                   Entidades.ModeloFiscalIcmsEstadoClass search = new Entidades.ModeloFiscalIcmsEstadoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ModeloFiscalIcmsEstadoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ModeloFiscalIcms", this),                     }                       ).Cast<Entidades.ModeloFiscalIcmsEstadoClass>().ToList());
                 }
                 _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms = new BindingList<Entidades.ModeloFiscalIcmsEstadoClass>(oc); 
                 _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsOriginal= (from a in _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms select a.ID).ToList();
                 _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded = true;
                 oc.CollectionChanged += CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoFiscalClassModeloFiscalIcmsChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoFiscalClassModeloFiscalIcmsChanged = true;
                  _valueCollectionProdutoFiscalClassModeloFiscalIcmsCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoFiscalClassModeloFiscalIcmsChanged = true; 
                  _valueCollectionProdutoFiscalClassModeloFiscalIcmsCommitedChanged = true;
                 foreach (Entidades.ProdutoFiscalClass item in e.OldItems) 
                 { 
                     _collectionProdutoFiscalClassModeloFiscalIcmsRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoFiscalClassModeloFiscalIcmsChanged = true; 
                  _valueCollectionProdutoFiscalClassModeloFiscalIcmsCommitedChanged = true;
                 foreach (Entidades.ProdutoFiscalClass item in _valueCollectionProdutoFiscalClassModeloFiscalIcms) 
                 { 
                     _collectionProdutoFiscalClassModeloFiscalIcmsRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoFiscalClassModeloFiscalIcms()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoFiscalClass> oc;
                _valueCollectionProdutoFiscalClassModeloFiscalIcmsChanged = false;
                 _valueCollectionProdutoFiscalClassModeloFiscalIcmsCommitedChanged = false;
                _collectionProdutoFiscalClassModeloFiscalIcmsRemovidos = new List<Entidades.ProdutoFiscalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoFiscalClass>();
                }
                else{ 
                   Entidades.ProdutoFiscalClass search = new Entidades.ProdutoFiscalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoFiscalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ModeloFiscalIcms", this),                     }                       ).Cast<Entidades.ProdutoFiscalClass>().ToList());
                 }
                 _valueCollectionProdutoFiscalClassModeloFiscalIcms = new BindingList<Entidades.ProdutoFiscalClass>(oc); 
                 _collectionProdutoFiscalClassModeloFiscalIcmsOriginal= (from a in _valueCollectionProdutoFiscalClassModeloFiscalIcms select a.ID).ToList();
                 _valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded = true;
                 oc.CollectionChanged += CollectionProdutoFiscalClassModeloFiscalIcmsChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoFiscalClassModeloFiscalIcms+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                {
                    throw new Exception(ErroNomeObrigatorio);
                }
                if (Nome.Length >255)
                {
                    throw new Exception( ErroNomeComprimento);
                }
                if (string.IsNullOrEmpty(Cst))
                {
                    throw new Exception(ErroCstObrigatorio);
                }
                if (Cst.Length >3)
                {
                    throw new Exception( ErroCstComprimento);
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
                    "  public.modelo_fiscal_icms  " +
                    "WHERE " +
                    "  id_modelo_fiscal_icms = :id";
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
                        "  public.modelo_fiscal_icms   " +
                        "SET  " + 
                        "  mfi_nome = :mfi_nome, " + 
                        "  mfi_cst = :mfi_cst, " + 
                        "  mfi_modalidade_determinacao_bc = :mfi_modalidade_determinacao_bc, " + 
                        "  mfi_reducao_bc = :mfi_reducao_bc, " + 
                        "  mfi_percentual_reducao_bc = :mfi_percentual_reducao_bc, " + 
                        "  mfi_st = :mfi_st, " + 
                        "  mfi_modalidade_determinicao_bc_st = :mfi_modalidade_determinicao_bc_st, " + 
                        "  mfi_percentual_reducao_bc_st = :mfi_percentual_reducao_bc_st, " + 
                        "  mfi_percentual_mva_st = :mfi_percentual_mva_st, " + 
                        "  mfi_percentual_bc_propria = :mfi_percentual_bc_propria, " + 
                        "  mfi_uf_st = :mfi_uf_st, " + 
                        "  mfi_aliquota_credito = :mfi_aliquota_credito, " + 
                        "  mfi_percentual_diferimento = :mfi_percentual_diferimento, " + 
                        "  mfi_obs_diferimento = :mfi_obs_diferimento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_estado_st = :id_estado_st, " + 
                        "  mfi_percentual_credito_presumido = :mfi_percentual_credito_presumido, " + 
                        "  mfi_percentual_limite_credito_presumido = :mfi_percentual_limite_credito_presumido, " + 
                        "  mfi_observacao_credito_presumido = :mfi_observacao_credito_presumido, " + 
                        "  mfi_observacao_credito_icms = :mfi_observacao_credito_icms "+
                        "WHERE  " +
                        "  id_modelo_fiscal_icms = :id " +
                        "RETURNING id_modelo_fiscal_icms;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.modelo_fiscal_icms " +
                        "( " +
                        "  mfi_nome , " + 
                        "  mfi_cst , " + 
                        "  mfi_modalidade_determinacao_bc , " + 
                        "  mfi_reducao_bc , " + 
                        "  mfi_percentual_reducao_bc , " + 
                        "  mfi_st , " + 
                        "  mfi_modalidade_determinicao_bc_st , " + 
                        "  mfi_percentual_reducao_bc_st , " + 
                        "  mfi_percentual_mva_st , " + 
                        "  mfi_percentual_bc_propria , " + 
                        "  mfi_uf_st , " + 
                        "  mfi_aliquota_credito , " + 
                        "  mfi_percentual_diferimento , " + 
                        "  mfi_obs_diferimento , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_estado_st , " + 
                        "  mfi_percentual_credito_presumido , " + 
                        "  mfi_percentual_limite_credito_presumido , " + 
                        "  mfi_observacao_credito_presumido , " + 
                        "  mfi_observacao_credito_icms  "+
                        ")  " +
                        "VALUES ( " +
                        "  :mfi_nome , " + 
                        "  :mfi_cst , " + 
                        "  :mfi_modalidade_determinacao_bc , " + 
                        "  :mfi_reducao_bc , " + 
                        "  :mfi_percentual_reducao_bc , " + 
                        "  :mfi_st , " + 
                        "  :mfi_modalidade_determinicao_bc_st , " + 
                        "  :mfi_percentual_reducao_bc_st , " + 
                        "  :mfi_percentual_mva_st , " + 
                        "  :mfi_percentual_bc_propria , " + 
                        "  :mfi_uf_st , " + 
                        "  :mfi_aliquota_credito , " + 
                        "  :mfi_percentual_diferimento , " + 
                        "  :mfi_obs_diferimento , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_estado_st , " + 
                        "  :mfi_percentual_credito_presumido , " + 
                        "  :mfi_percentual_limite_credito_presumido , " + 
                        "  :mfi_observacao_credito_presumido , " + 
                        "  :mfi_observacao_credito_icms  "+
                        ")RETURNING id_modelo_fiscal_icms;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_modalidade_determinacao_bc", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ModalidadeDeterminacaoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_reducao_bc", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ReducaoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_reducao_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualReducaoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_st", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.St);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_modalidade_determinicao_bc_st", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ModalidadeDeterminicaoBcSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_reducao_bc_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualReducaoBcSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_mva_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualMvaSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_bc_propria", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualBcPropria ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_uf_st", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_aliquota_credito", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaCredito ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_diferimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_obs_diferimento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObsDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado_st", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstadoSt==null ? (object) DBNull.Value : this.EstadoSt.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_credito_presumido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualCreditoPresumido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_limite_credito_presumido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualLimiteCreditoPresumido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_observacao_credito_presumido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacaoCreditoPresumido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_observacao_credito_icms", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacaoCreditoIcms ?? DBNull.Value;

 
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
 if (CollectionMaterialFiscalClassModeloFiscalIcms.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialFiscalClassModeloFiscalIcms+"\r\n";
                foreach (Entidades.MaterialFiscalClass tmp in CollectionMaterialFiscalClassModeloFiscalIcms)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms+"\r\n";
                foreach (Entidades.ModeloFiscalIcmsEstadoClass tmp in CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoFiscalClassModeloFiscalIcms.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoFiscalClassModeloFiscalIcms+"\r\n";
                foreach (Entidades.ProdutoFiscalClass tmp in CollectionProdutoFiscalClassModeloFiscalIcms)
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
        public static ModeloFiscalIcmsClass CopiarEntidade(ModeloFiscalIcmsClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ModeloFiscalIcmsClass toRet = new ModeloFiscalIcmsClass(usuario,conn);
 toRet.Nome= entidadeCopiar.Nome;
 toRet.Cst= entidadeCopiar.Cst;
 toRet.ModalidadeDeterminacaoBc= entidadeCopiar.ModalidadeDeterminacaoBc;
 toRet.ReducaoBc= entidadeCopiar.ReducaoBc;
 toRet.PercentualReducaoBc= entidadeCopiar.PercentualReducaoBc;
 toRet.St= entidadeCopiar.St;
 toRet.ModalidadeDeterminicaoBcSt= entidadeCopiar.ModalidadeDeterminicaoBcSt;
 toRet.PercentualReducaoBcSt= entidadeCopiar.PercentualReducaoBcSt;
 toRet.PercentualMvaSt= entidadeCopiar.PercentualMvaSt;
 toRet.PercentualBcPropria= entidadeCopiar.PercentualBcPropria;
 toRet.UfSt= entidadeCopiar.UfSt;
 toRet.AliquotaCredito= entidadeCopiar.AliquotaCredito;
 toRet.PercentualDiferimento= entidadeCopiar.PercentualDiferimento;
 toRet.ObsDiferimento= entidadeCopiar.ObsDiferimento;
 toRet.EstadoSt= entidadeCopiar.EstadoSt;
 toRet.PercentualCreditoPresumido= entidadeCopiar.PercentualCreditoPresumido;
 toRet.PercentualLimiteCreditoPresumido= entidadeCopiar.PercentualLimiteCreditoPresumido;
 toRet.ObservacaoCreditoPresumido= entidadeCopiar.ObservacaoCreditoPresumido;
 toRet.ObservacaoCreditoIcms= entidadeCopiar.ObservacaoCreditoIcms;

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
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _cstOriginal = Cst;
       _cstOriginalCommited = _cstOriginal;
       _modalidadeDeterminacaoBcOriginal = ModalidadeDeterminacaoBc;
       _modalidadeDeterminacaoBcOriginalCommited = _modalidadeDeterminacaoBcOriginal;
       _reducaoBcOriginal = ReducaoBc;
       _reducaoBcOriginalCommited = _reducaoBcOriginal;
       _percentualReducaoBcOriginal = PercentualReducaoBc;
       _percentualReducaoBcOriginalCommited = _percentualReducaoBcOriginal;
       _stOriginal = St;
       _stOriginalCommited = _stOriginal;
       _modalidadeDeterminicaoBcStOriginal = ModalidadeDeterminicaoBcSt;
       _modalidadeDeterminicaoBcStOriginalCommited = _modalidadeDeterminicaoBcStOriginal;
       _percentualReducaoBcStOriginal = PercentualReducaoBcSt;
       _percentualReducaoBcStOriginalCommited = _percentualReducaoBcStOriginal;
       _percentualMvaStOriginal = PercentualMvaSt;
       _percentualMvaStOriginalCommited = _percentualMvaStOriginal;
       _percentualBcPropriaOriginal = PercentualBcPropria;
       _percentualBcPropriaOriginalCommited = _percentualBcPropriaOriginal;
       _ufStOriginal = UfSt;
       _ufStOriginalCommited = _ufStOriginal;
       _aliquotaCreditoOriginal = AliquotaCredito;
       _aliquotaCreditoOriginalCommited = _aliquotaCreditoOriginal;
       _percentualDiferimentoOriginal = PercentualDiferimento;
       _percentualDiferimentoOriginalCommited = _percentualDiferimentoOriginal;
       _obsDiferimentoOriginal = ObsDiferimento;
       _obsDiferimentoOriginalCommited = _obsDiferimentoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _estadoStOriginal = EstadoSt;
       _estadoStOriginalCommited = _estadoStOriginal;
       _percentualCreditoPresumidoOriginal = PercentualCreditoPresumido;
       _percentualCreditoPresumidoOriginalCommited = _percentualCreditoPresumidoOriginal;
       _percentualLimiteCreditoPresumidoOriginal = PercentualLimiteCreditoPresumido;
       _percentualLimiteCreditoPresumidoOriginalCommited = _percentualLimiteCreditoPresumidoOriginal;
       _observacaoCreditoPresumidoOriginal = ObservacaoCreditoPresumido;
       _observacaoCreditoPresumidoOriginalCommited = _observacaoCreditoPresumidoOriginal;
       _observacaoCreditoIcmsOriginal = ObservacaoCreditoIcms;
       _observacaoCreditoIcmsOriginalCommited = _observacaoCreditoIcmsOriginal;

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
       _nomeOriginalCommited = Nome;
       _cstOriginalCommited = Cst;
       _modalidadeDeterminacaoBcOriginalCommited = ModalidadeDeterminacaoBc;
       _reducaoBcOriginalCommited = ReducaoBc;
       _percentualReducaoBcOriginalCommited = PercentualReducaoBc;
       _stOriginalCommited = St;
       _modalidadeDeterminicaoBcStOriginalCommited = ModalidadeDeterminicaoBcSt;
       _percentualReducaoBcStOriginalCommited = PercentualReducaoBcSt;
       _percentualMvaStOriginalCommited = PercentualMvaSt;
       _percentualBcPropriaOriginalCommited = PercentualBcPropria;
       _ufStOriginalCommited = UfSt;
       _aliquotaCreditoOriginalCommited = AliquotaCredito;
       _percentualDiferimentoOriginalCommited = PercentualDiferimento;
       _obsDiferimentoOriginalCommited = ObsDiferimento;
       _versionOriginalCommited = Version;
       _estadoStOriginalCommited = EstadoSt;
       _percentualCreditoPresumidoOriginalCommited = PercentualCreditoPresumido;
       _percentualLimiteCreditoPresumidoOriginalCommited = PercentualLimiteCreditoPresumido;
       _observacaoCreditoPresumidoOriginalCommited = ObservacaoCreditoPresumido;
       _observacaoCreditoIcmsOriginalCommited = ObservacaoCreditoIcms;

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
               if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded) 
               {
                  if (_collectionMaterialFiscalClassModeloFiscalIcmsRemovidos != null) 
                  {
                     _collectionMaterialFiscalClassModeloFiscalIcmsRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialFiscalClassModeloFiscalIcmsRemovidos = new List<Entidades.MaterialFiscalClass>();
                  }
                  _collectionMaterialFiscalClassModeloFiscalIcmsOriginal= (from a in _valueCollectionMaterialFiscalClassModeloFiscalIcms select a.ID).ToList();
                  _valueCollectionMaterialFiscalClassModeloFiscalIcmsChanged = false;
                  _valueCollectionMaterialFiscalClassModeloFiscalIcmsCommitedChanged = false;
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded) 
               {
                  if (_collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsRemovidos != null) 
                  {
                     _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsRemovidos = new List<Entidades.ModeloFiscalIcmsEstadoClass>();
                  }
                  _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsOriginal= (from a in _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms select a.ID).ToList();
                  _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsChanged = false;
                  _valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsCommitedChanged = false;
               }
               if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded) 
               {
                  if (_collectionProdutoFiscalClassModeloFiscalIcmsRemovidos != null) 
                  {
                     _collectionProdutoFiscalClassModeloFiscalIcmsRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoFiscalClassModeloFiscalIcmsRemovidos = new List<Entidades.ProdutoFiscalClass>();
                  }
                  _collectionProdutoFiscalClassModeloFiscalIcmsOriginal= (from a in _valueCollectionProdutoFiscalClassModeloFiscalIcms select a.ID).ToList();
                  _valueCollectionProdutoFiscalClassModeloFiscalIcmsChanged = false;
                  _valueCollectionProdutoFiscalClassModeloFiscalIcmsCommitedChanged = false;
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
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               Cst=_cstOriginal;
               _cstOriginalCommited=_cstOriginal;
               ModalidadeDeterminacaoBc=_modalidadeDeterminacaoBcOriginal;
               _modalidadeDeterminacaoBcOriginalCommited=_modalidadeDeterminacaoBcOriginal;
               ReducaoBc=_reducaoBcOriginal;
               _reducaoBcOriginalCommited=_reducaoBcOriginal;
               PercentualReducaoBc=_percentualReducaoBcOriginal;
               _percentualReducaoBcOriginalCommited=_percentualReducaoBcOriginal;
               St=_stOriginal;
               _stOriginalCommited=_stOriginal;
               ModalidadeDeterminicaoBcSt=_modalidadeDeterminicaoBcStOriginal;
               _modalidadeDeterminicaoBcStOriginalCommited=_modalidadeDeterminicaoBcStOriginal;
               PercentualReducaoBcSt=_percentualReducaoBcStOriginal;
               _percentualReducaoBcStOriginalCommited=_percentualReducaoBcStOriginal;
               PercentualMvaSt=_percentualMvaStOriginal;
               _percentualMvaStOriginalCommited=_percentualMvaStOriginal;
               PercentualBcPropria=_percentualBcPropriaOriginal;
               _percentualBcPropriaOriginalCommited=_percentualBcPropriaOriginal;
               UfSt=_ufStOriginal;
               _ufStOriginalCommited=_ufStOriginal;
               AliquotaCredito=_aliquotaCreditoOriginal;
               _aliquotaCreditoOriginalCommited=_aliquotaCreditoOriginal;
               PercentualDiferimento=_percentualDiferimentoOriginal;
               _percentualDiferimentoOriginalCommited=_percentualDiferimentoOriginal;
               ObsDiferimento=_obsDiferimentoOriginal;
               _obsDiferimentoOriginalCommited=_obsDiferimentoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               EstadoSt=_estadoStOriginal;
               _estadoStOriginalCommited=_estadoStOriginal;
               PercentualCreditoPresumido=_percentualCreditoPresumidoOriginal;
               _percentualCreditoPresumidoOriginalCommited=_percentualCreditoPresumidoOriginal;
               PercentualLimiteCreditoPresumido=_percentualLimiteCreditoPresumidoOriginal;
               _percentualLimiteCreditoPresumidoOriginalCommited=_percentualLimiteCreditoPresumidoOriginal;
               ObservacaoCreditoPresumido=_observacaoCreditoPresumidoOriginal;
               _observacaoCreditoPresumidoOriginalCommited=_observacaoCreditoPresumidoOriginal;
               ObservacaoCreditoIcms=_observacaoCreditoIcmsOriginal;
               _observacaoCreditoIcmsOriginalCommited=_observacaoCreditoIcmsOriginal;
               if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded) 
               {
                  CollectionMaterialFiscalClassModeloFiscalIcms.Clear();
                  foreach(int item in _collectionMaterialFiscalClassModeloFiscalIcmsOriginal)
                  {
                    CollectionMaterialFiscalClassModeloFiscalIcms.Add(Entidades.MaterialFiscalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialFiscalClassModeloFiscalIcmsRemovidos.Clear();
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded) 
               {
                  CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.Clear();
                  foreach(int item in _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsOriginal)
                  {
                    CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.Add(Entidades.ModeloFiscalIcmsEstadoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsRemovidos.Clear();
               }
               if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded) 
               {
                  CollectionProdutoFiscalClassModeloFiscalIcms.Clear();
                  foreach(int item in _collectionProdutoFiscalClassModeloFiscalIcmsOriginal)
                  {
                    CollectionProdutoFiscalClassModeloFiscalIcms.Add(Entidades.ProdutoFiscalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoFiscalClassModeloFiscalIcmsRemovidos.Clear();
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
               if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded) 
               {
                  if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded) 
               {
                  if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded) 
               {
                  if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded) 
               {
                   tempRet = CollectionMaterialFiscalClassModeloFiscalIcms.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded) 
               {
                   tempRet = CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded) 
               {
                   tempRet = CollectionProdutoFiscalClassModeloFiscalIcms.Any(item => item.IsDirty());
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
       dirty = _nomeOriginal != Nome;
      if (dirty) return true;
       dirty = _cstOriginal != Cst;
      if (dirty) return true;
       dirty = _modalidadeDeterminacaoBcOriginal != ModalidadeDeterminacaoBc;
      if (dirty) return true;
       dirty = _reducaoBcOriginal != ReducaoBc;
      if (dirty) return true;
       dirty = _percentualReducaoBcOriginal != PercentualReducaoBc;
      if (dirty) return true;
       dirty = _stOriginal != St;
      if (dirty) return true;
       dirty = _modalidadeDeterminicaoBcStOriginal != ModalidadeDeterminicaoBcSt;
      if (dirty) return true;
       dirty = _percentualReducaoBcStOriginal != PercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _percentualMvaStOriginal != PercentualMvaSt;
      if (dirty) return true;
       dirty = _percentualBcPropriaOriginal != PercentualBcPropria;
      if (dirty) return true;
       dirty = _ufStOriginal != UfSt;
      if (dirty) return true;
       dirty = _aliquotaCreditoOriginal != AliquotaCredito;
      if (dirty) return true;
       dirty = _percentualDiferimentoOriginal != PercentualDiferimento;
      if (dirty) return true;
       dirty = _obsDiferimentoOriginal != ObsDiferimento;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_estadoStOriginal!=null)
       {
          dirty = !_estadoStOriginal.Equals(EstadoSt);
       }
       else
       {
            dirty = EstadoSt != null;
       }
      if (dirty) return true;
       dirty = _percentualCreditoPresumidoOriginal != PercentualCreditoPresumido;
      if (dirty) return true;
       dirty = _percentualLimiteCreditoPresumidoOriginal != PercentualLimiteCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoPresumidoOriginal != ObservacaoCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoIcmsOriginal != ObservacaoCreditoIcms;

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
               if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded) 
               {
                  if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded) 
               {
                  if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded) 
               {
                  if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded) 
               {
                   tempRet = CollectionMaterialFiscalClassModeloFiscalIcms.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded) 
               {
                   tempRet = CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded) 
               {
                   tempRet = CollectionProdutoFiscalClassModeloFiscalIcms.Any(item => item.IsDirtyCommited());
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
       dirty = _nomeOriginalCommited != Nome;
      if (dirty) return true;
       dirty = _cstOriginalCommited != Cst;
      if (dirty) return true;
       dirty = _modalidadeDeterminacaoBcOriginalCommited != ModalidadeDeterminacaoBc;
      if (dirty) return true;
       dirty = _reducaoBcOriginalCommited != ReducaoBc;
      if (dirty) return true;
       dirty = _percentualReducaoBcOriginalCommited != PercentualReducaoBc;
      if (dirty) return true;
       dirty = _stOriginalCommited != St;
      if (dirty) return true;
       dirty = _modalidadeDeterminicaoBcStOriginalCommited != ModalidadeDeterminicaoBcSt;
      if (dirty) return true;
       dirty = _percentualReducaoBcStOriginalCommited != PercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _percentualMvaStOriginalCommited != PercentualMvaSt;
      if (dirty) return true;
       dirty = _percentualBcPropriaOriginalCommited != PercentualBcPropria;
      if (dirty) return true;
       dirty = _ufStOriginalCommited != UfSt;
      if (dirty) return true;
       dirty = _aliquotaCreditoOriginalCommited != AliquotaCredito;
      if (dirty) return true;
       dirty = _percentualDiferimentoOriginalCommited != PercentualDiferimento;
      if (dirty) return true;
       dirty = _obsDiferimentoOriginalCommited != ObsDiferimento;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_estadoStOriginalCommited!=null)
       {
          dirty = !_estadoStOriginalCommited.Equals(EstadoSt);
       }
       else
       {
            dirty = EstadoSt != null;
       }
      if (dirty) return true;
       dirty = _percentualCreditoPresumidoOriginalCommited != PercentualCreditoPresumido;
      if (dirty) return true;
       dirty = _percentualLimiteCreditoPresumidoOriginalCommited != PercentualLimiteCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoPresumidoOriginalCommited != ObservacaoCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoIcmsOriginalCommited != ObservacaoCreditoIcms;

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
               if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded) 
               {
                  foreach(MaterialFiscalClass item in CollectionMaterialFiscalClassModeloFiscalIcms)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded) 
               {
                  foreach(ModeloFiscalIcmsEstadoClass item in CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded) 
               {
                  foreach(ProdutoFiscalClass item in CollectionProdutoFiscalClassModeloFiscalIcms)
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
             case "Nome":
                return this.Nome;
             case "Cst":
                return this.Cst;
             case "ModalidadeDeterminacaoBc":
                return this.ModalidadeDeterminacaoBc;
             case "ReducaoBc":
                return this.ReducaoBc;
             case "PercentualReducaoBc":
                return this.PercentualReducaoBc;
             case "St":
                return this.St;
             case "ModalidadeDeterminicaoBcSt":
                return this.ModalidadeDeterminicaoBcSt;
             case "PercentualReducaoBcSt":
                return this.PercentualReducaoBcSt;
             case "PercentualMvaSt":
                return this.PercentualMvaSt;
             case "PercentualBcPropria":
                return this.PercentualBcPropria;
             case "UfSt":
                return this.UfSt;
             case "AliquotaCredito":
                return this.AliquotaCredito;
             case "PercentualDiferimento":
                return this.PercentualDiferimento;
             case "ObsDiferimento":
                return this.ObsDiferimento;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "EstadoSt":
                return this.EstadoSt;
             case "PercentualCreditoPresumido":
                return this.PercentualCreditoPresumido;
             case "PercentualLimiteCreditoPresumido":
                return this.PercentualLimiteCreditoPresumido;
             case "ObservacaoCreditoPresumido":
                return this.ObservacaoCreditoPresumido;
             case "ObservacaoCreditoIcms":
                return this.ObservacaoCreditoIcms;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (EstadoSt!=null)
                EstadoSt.ChangeSingleConnection(newConnection);
               if (_valueCollectionMaterialFiscalClassModeloFiscalIcmsLoaded) 
               {
                  foreach(MaterialFiscalClass item in CollectionMaterialFiscalClassModeloFiscalIcms)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcmsLoaded) 
               {
                  foreach(ModeloFiscalIcmsEstadoClass item in CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoFiscalClassModeloFiscalIcmsLoaded) 
               {
                  foreach(ProdutoFiscalClass item in CollectionProdutoFiscalClassModeloFiscalIcms)
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
                  command.CommandText += " COUNT(modelo_fiscal_icms.id_modelo_fiscal_icms) " ;
               }
               else
               {
               command.CommandText += "modelo_fiscal_icms.id_modelo_fiscal_icms, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_nome, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_cst, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_modalidade_determinacao_bc, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_reducao_bc, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_percentual_reducao_bc, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_st, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_modalidade_determinicao_bc_st, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_percentual_reducao_bc_st, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_percentual_mva_st, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_percentual_bc_propria, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_uf_st, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_aliquota_credito, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_percentual_diferimento, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_obs_diferimento, " ;
               command.CommandText += "modelo_fiscal_icms.entity_uid, " ;
               command.CommandText += "modelo_fiscal_icms.version, " ;
               command.CommandText += "modelo_fiscal_icms.id_estado_st, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_percentual_credito_presumido, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_percentual_limite_credito_presumido, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_observacao_credito_presumido, " ;
               command.CommandText += "modelo_fiscal_icms.mfi_observacao_credito_icms " ;
               }
               command.CommandText += " FROM  modelo_fiscal_icms ";
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
                        orderByClause += " , mfi_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mfi_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = modelo_fiscal_icms.id_acs_usuario_ultima_revisao ";
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
                     case "id_modelo_fiscal_icms":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.id_modelo_fiscal_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.id_modelo_fiscal_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_fiscal_icms.mfi_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_cst":
                     case "Cst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_fiscal_icms.mfi_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_modalidade_determinacao_bc":
                     case "ModalidadeDeterminacaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_modalidade_determinacao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_modalidade_determinacao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_reducao_bc":
                     case "ReducaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_reducao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_reducao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_percentual_reducao_bc":
                     case "PercentualReducaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_percentual_reducao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_percentual_reducao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_st":
                     case "St":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_modalidade_determinicao_bc_st":
                     case "ModalidadeDeterminicaoBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_modalidade_determinicao_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_modalidade_determinicao_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_percentual_reducao_bc_st":
                     case "PercentualReducaoBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_percentual_reducao_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_percentual_reducao_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_percentual_mva_st":
                     case "PercentualMvaSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_percentual_mva_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_percentual_mva_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_percentual_bc_propria":
                     case "PercentualBcPropria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_percentual_bc_propria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_percentual_bc_propria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_uf_st":
                     case "UfSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_fiscal_icms.mfi_uf_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_uf_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_aliquota_credito":
                     case "AliquotaCredito":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_aliquota_credito " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_aliquota_credito) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_percentual_diferimento":
                     case "PercentualDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_percentual_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_percentual_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_obs_diferimento":
                     case "ObsDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_fiscal_icms.mfi_obs_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_obs_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_fiscal_icms.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_fiscal_icms.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , modelo_fiscal_icms.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estado_st":
                     case "EstadoSt":
                     command.CommandText += " LEFT JOIN estado as estado_EstadoSt ON estado_EstadoSt.id_estado = modelo_fiscal_icms.id_estado_st ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_EstadoSt.est_sigla " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_EstadoSt.est_sigla) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_EstadoSt.est_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_EstadoSt.est_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_percentual_credito_presumido":
                     case "PercentualCreditoPresumido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_percentual_credito_presumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_percentual_credito_presumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_percentual_limite_credito_presumido":
                     case "PercentualLimiteCreditoPresumido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_fiscal_icms.mfi_percentual_limite_credito_presumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_percentual_limite_credito_presumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_observacao_credito_presumido":
                     case "ObservacaoCreditoPresumido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_fiscal_icms.mfi_observacao_credito_presumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_observacao_credito_presumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfi_observacao_credito_icms":
                     case "ObservacaoCreditoIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_fiscal_icms.mfi_observacao_credito_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_fiscal_icms.mfi_observacao_credito_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mfi_nome")) 
                        {
                           whereClause += " OR UPPER(modelo_fiscal_icms.mfi_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_fiscal_icms.mfi_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mfi_cst")) 
                        {
                           whereClause += " OR UPPER(modelo_fiscal_icms.mfi_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_fiscal_icms.mfi_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mfi_uf_st")) 
                        {
                           whereClause += " OR UPPER(modelo_fiscal_icms.mfi_uf_st) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_fiscal_icms.mfi_uf_st) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mfi_obs_diferimento")) 
                        {
                           whereClause += " OR UPPER(modelo_fiscal_icms.mfi_obs_diferimento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_fiscal_icms.mfi_obs_diferimento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(modelo_fiscal_icms.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_fiscal_icms.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mfi_observacao_credito_presumido")) 
                        {
                           whereClause += " OR UPPER(modelo_fiscal_icms.mfi_observacao_credito_presumido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_fiscal_icms.mfi_observacao_credito_presumido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mfi_observacao_credito_icms")) 
                        {
                           whereClause += " OR UPPER(modelo_fiscal_icms.mfi_observacao_credito_icms) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_fiscal_icms.mfi_observacao_credito_icms) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_modelo_fiscal_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.id_modelo_fiscal_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.id_modelo_fiscal_icms = :modelo_fiscal_icms_ID_2584 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ID_2584", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "mfi_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_nome LIKE :modelo_fiscal_icms_Nome_8704 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_Nome_8704", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cst" || parametro.FieldName == "mfi_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_cst LIKE :modelo_fiscal_icms_Cst_3957 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_Cst_3957", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeDeterminacaoBc" || parametro.FieldName == "mfi_modalidade_determinacao_bc")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_modalidade_determinacao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_modalidade_determinacao_bc = :modelo_fiscal_icms_ModalidadeDeterminacaoBc_8523 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ModalidadeDeterminacaoBc_8523", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ReducaoBc" || parametro.FieldName == "mfi_reducao_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_reducao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_reducao_bc = :modelo_fiscal_icms_ReducaoBc_9248 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ReducaoBc_9248", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualReducaoBc" || parametro.FieldName == "mfi_percentual_reducao_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_reducao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_reducao_bc = :modelo_fiscal_icms_PercentualReducaoBc_1409 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_PercentualReducaoBc_1409", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "St" || parametro.FieldName == "mfi_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoTributacaoST)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoTributacaoST");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_st = :modelo_fiscal_icms_St_1915 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_St_1915", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeDeterminicaoBcSt" || parametro.FieldName == "mfi_modalidade_determinicao_bc_st")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_modalidade_determinicao_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_modalidade_determinicao_bc_st = :modelo_fiscal_icms_ModalidadeDeterminicaoBcSt_7863 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ModalidadeDeterminicaoBcSt_7863", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualReducaoBcSt" || parametro.FieldName == "mfi_percentual_reducao_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_reducao_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_reducao_bc_st = :modelo_fiscal_icms_PercentualReducaoBcSt_2656 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_PercentualReducaoBcSt_2656", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualMvaSt" || parametro.FieldName == "mfi_percentual_mva_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_mva_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_mva_st = :modelo_fiscal_icms_PercentualMvaSt_3902 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_PercentualMvaSt_3902", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualBcPropria" || parametro.FieldName == "mfi_percentual_bc_propria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_bc_propria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_bc_propria = :modelo_fiscal_icms_PercentualBcPropria_7754 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_PercentualBcPropria_7754", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfSt" || parametro.FieldName == "mfi_uf_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_uf_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_uf_st LIKE :modelo_fiscal_icms_UfSt_6405 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_UfSt_6405", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaCredito" || parametro.FieldName == "mfi_aliquota_credito")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_aliquota_credito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_aliquota_credito = :modelo_fiscal_icms_AliquotaCredito_7400 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_AliquotaCredito_7400", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualDiferimento" || parametro.FieldName == "mfi_percentual_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_diferimento = :modelo_fiscal_icms_PercentualDiferimento_3260 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_PercentualDiferimento_3260", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsDiferimento" || parametro.FieldName == "mfi_obs_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_obs_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_obs_diferimento LIKE :modelo_fiscal_icms_ObsDiferimento_7253 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ObsDiferimento_7253", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  modelo_fiscal_icms.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.entity_uid LIKE :modelo_fiscal_icms_EntityUid_294 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_EntityUid_294", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  modelo_fiscal_icms.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.version = :modelo_fiscal_icms_Version_9962 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_Version_9962", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstadoSt" || parametro.FieldName == "id_estado_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstadoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstadoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.id_estado_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.id_estado_st = :modelo_fiscal_icms_EstadoSt_8567 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_EstadoSt_8567", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualCreditoPresumido" || parametro.FieldName == "mfi_percentual_credito_presumido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_credito_presumido = :modelo_fiscal_icms_PercentualCreditoPresumido_8577 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_PercentualCreditoPresumido_8577", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualLimiteCreditoPresumido" || parametro.FieldName == "mfi_percentual_limite_credito_presumido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_limite_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_percentual_limite_credito_presumido = :modelo_fiscal_icms_PercentualLimiteCreditoPresumido_1889 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_PercentualLimiteCreditoPresumido_1889", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoPresumido" || parametro.FieldName == "mfi_observacao_credito_presumido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_observacao_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_observacao_credito_presumido LIKE :modelo_fiscal_icms_ObservacaoCreditoPresumido_3150 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ObservacaoCreditoPresumido_3150", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoIcms" || parametro.FieldName == "mfi_observacao_credito_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_observacao_credito_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_observacao_credito_icms LIKE :modelo_fiscal_icms_ObservacaoCreditoIcms_3362 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ObservacaoCreditoIcms_3362", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  modelo_fiscal_icms.mfi_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_nome LIKE :modelo_fiscal_icms_Nome_7910 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_Nome_7910", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstExato" || parametro.FieldName == "CstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_cst LIKE :modelo_fiscal_icms_Cst_1443 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_Cst_1443", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfStExato" || parametro.FieldName == "UfStExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_uf_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_uf_st LIKE :modelo_fiscal_icms_UfSt_3309 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_UfSt_3309", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsDiferimentoExato" || parametro.FieldName == "ObsDiferimentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_obs_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_obs_diferimento LIKE :modelo_fiscal_icms_ObsDiferimento_1748 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ObsDiferimento_1748", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  modelo_fiscal_icms.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.entity_uid LIKE :modelo_fiscal_icms_EntityUid_6287 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_EntityUid_6287", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoPresumidoExato" || parametro.FieldName == "ObservacaoCreditoPresumidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_observacao_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_observacao_credito_presumido LIKE :modelo_fiscal_icms_ObservacaoCreditoPresumido_3085 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ObservacaoCreditoPresumido_3085", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoIcmsExato" || parametro.FieldName == "ObservacaoCreditoIcmsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_observacao_credito_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_fiscal_icms.mfi_observacao_credito_icms LIKE :modelo_fiscal_icms_ObservacaoCreditoIcms_4907 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_fiscal_icms_ObservacaoCreditoIcms_4907", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ModeloFiscalIcmsClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ModeloFiscalIcmsClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ModeloFiscalIcmsClass), Convert.ToInt32(read["id_modelo_fiscal_icms"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ModeloFiscalIcmsClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_modelo_fiscal_icms"]);
                     entidade.Nome = (read["mfi_nome"] != DBNull.Value ? read["mfi_nome"].ToString() : null);
                     entidade.Cst = (read["mfi_cst"] != DBNull.Value ? read["mfi_cst"].ToString() : null);
                     entidade.ModalidadeDeterminacaoBc = read["mfi_modalidade_determinacao_bc"] as int?;
                     entidade.ReducaoBc = Convert.ToBoolean(Convert.ToInt16(read["mfi_reducao_bc"]));
                     entidade.PercentualReducaoBc = read["mfi_percentual_reducao_bc"] as double?;
                     entidade.St = (TipoTributacaoST) (read["mfi_st"] != DBNull.Value ? Enum.ToObject(typeof(TipoTributacaoST), read["mfi_st"]) : null);
                     entidade.ModalidadeDeterminicaoBcSt = read["mfi_modalidade_determinicao_bc_st"] as int?;
                     entidade.PercentualReducaoBcSt = read["mfi_percentual_reducao_bc_st"] as double?;
                     entidade.PercentualMvaSt = read["mfi_percentual_mva_st"] as double?;
                     entidade.PercentualBcPropria = read["mfi_percentual_bc_propria"] as double?;
                     entidade.UfSt = (read["mfi_uf_st"] != DBNull.Value ? read["mfi_uf_st"].ToString() : null);
                     entidade.AliquotaCredito = read["mfi_aliquota_credito"] as double?;
                     entidade.PercentualDiferimento = (double)read["mfi_percentual_diferimento"];
                     entidade.ObsDiferimento = (read["mfi_obs_diferimento"] != DBNull.Value ? read["mfi_obs_diferimento"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_estado_st"] != DBNull.Value)
                     {
                        entidade.EstadoSt = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado_st"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstadoSt = null ;
                     }
                     entidade.PercentualCreditoPresumido = read["mfi_percentual_credito_presumido"] as double?;
                     entidade.PercentualLimiteCreditoPresumido = read["mfi_percentual_limite_credito_presumido"] as double?;
                     entidade.ObservacaoCreditoPresumido = (read["mfi_observacao_credito_presumido"] != DBNull.Value ? read["mfi_observacao_credito_presumido"].ToString() : null);
                     entidade.ObservacaoCreditoIcms = (read["mfi_observacao_credito_icms"] != DBNull.Value ? read["mfi_observacao_credito_icms"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ModeloFiscalIcmsClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
