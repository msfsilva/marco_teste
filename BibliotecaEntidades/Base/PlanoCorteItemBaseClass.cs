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
     [Table("plano_corte_item","pci")]
     public class PlanoCorteItemBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PlanoCorteItemClass";
protected const string ErroDelete = "Erro ao excluir o PlanoCorteItemClass  ";
protected const string ErroSave = "Erro ao salvar o PlanoCorteItemClass.";
protected const string ErroCollectionPlanoCorteItemOpClassPlanoCorteItem = "Erro ao carregar a coleção de PlanoCorteItemOpClass.";
protected const string ErroCollectionPlanoCorteItemPedidoClassPlanoCorteItem = "Erro ao carregar a coleção de PlanoCorteItemPedidoClass.";
protected const string ErroMaterialCodigoObrigatorio = "O campo MaterialCodigo é obrigatório";
protected const string ErroMaterialCodigoComprimento = "O campo MaterialCodigo deve ter no máximo 255 caracteres";
protected const string ErroMaterialFamiliaObrigatorio = "O campo MaterialFamilia é obrigatório";
protected const string ErroMaterialFamiliaComprimento = "O campo MaterialFamilia deve ter no máximo 255 caracteres";
protected const string ErroMaterialAgrupadorObrigatorio = "O campo MaterialAgrupador é obrigatório";
protected const string ErroMaterialAgrupadorComprimento = "O campo MaterialAgrupador deve ter no máximo 255 caracteres";
protected const string ErroPostoNomeObrigatorio = "O campo PostoNome é obrigatório";
protected const string ErroPostoNomeComprimento = "O campo PostoNome deve ter no máximo 255 caracteres";
protected const string ErroPostoDescricaoObrigatorio = "O campo PostoDescricao é obrigatório";
protected const string ErroPostoDescricaoComprimento = "O campo PostoDescricao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroPlanoCorteObrigatorio = "O campo PlanoCorte é obrigatório";
protected const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected const string ErroPostoTrabalhoCorteObrigatorio = "O campo PostoTrabalhoCorte é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do PlanoCorteItemClass.";
protected const string MensagemUtilizadoCollectionPlanoCorteItemOpClassPlanoCorteItem =  "A entidade PlanoCorteItemClass está sendo utilizada nos seguintes PlanoCorteItemOpClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemPedidoClassPlanoCorteItem =  "A entidade PlanoCorteItemClass está sendo utilizada nos seguintes PlanoCorteItemPedidoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PlanoCorteItemClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.PlanoCorteClass _planoCorteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PlanoCorteClass _planoCorteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PlanoCorteClass _valuePlanoCorte;
        [Column("id_plano_corte", "plano_corte", "id_plano_corte")]
       public virtual BibliotecaEntidades.Entidades.PlanoCorteClass PlanoCorte
        { 
           get {                 return this._valuePlanoCorte; } 
           set 
           { 
                if (this._valuePlanoCorte == value)return;
                 this._valuePlanoCorte = value; 
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

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("pci_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.DimensaoClass _dimensao1Original{get;private set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _dimensao1OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _valueDimensao1;
        [Column("id_dimensao_1", "dimensao", "id_dimensao")]
       public virtual BibliotecaEntidades.Entidades.DimensaoClass Dimensao1
        { 
           get {                 return this._valueDimensao1; } 
           set 
           { 
                if (this._valueDimensao1 == value)return;
                 this._valueDimensao1 = value; 
           } 
       } 

       protected string _dimensao1ValorOriginal{get;private set;}
       private string _dimensao1ValorOriginalCommited{get; set;}
        private string _valueDimensao1Valor;
         [Column("pci_dimensao_1_valor")]
        public virtual string Dimensao1Valor
         { 
            get { return this._valueDimensao1Valor; } 
            set 
            { 
                if (this._valueDimensao1Valor == value)return;
                 this._valueDimensao1Valor = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.DimensaoClass _dimensao2Original{get;private set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _dimensao2OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _valueDimensao2;
        [Column("id_dimensao_2", "dimensao", "id_dimensao")]
       public virtual BibliotecaEntidades.Entidades.DimensaoClass Dimensao2
        { 
           get {                 return this._valueDimensao2; } 
           set 
           { 
                if (this._valueDimensao2 == value)return;
                 this._valueDimensao2 = value; 
           } 
       } 

       protected string _dimensao2ValorOriginal{get;private set;}
       private string _dimensao2ValorOriginalCommited{get; set;}
        private string _valueDimensao2Valor;
         [Column("pci_dimensao_2_valor")]
        public virtual string Dimensao2Valor
         { 
            get { return this._valueDimensao2Valor; } 
            set 
            { 
                if (this._valueDimensao2Valor == value)return;
                 this._valueDimensao2Valor = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.DimensaoClass _dimensao3Original{get;private set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _dimensao3OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _valueDimensao3;
        [Column("id_dimensao_3", "dimensao", "id_dimensao")]
       public virtual BibliotecaEntidades.Entidades.DimensaoClass Dimensao3
        { 
           get {                 return this._valueDimensao3; } 
           set 
           { 
                if (this._valueDimensao3 == value)return;
                 this._valueDimensao3 = value; 
           } 
       } 

       protected string _dimensao3ValorOriginal{get;private set;}
       private string _dimensao3ValorOriginalCommited{get; set;}
        private string _valueDimensao3Valor;
         [Column("pci_dimensao_3_valor")]
        public virtual string Dimensao3Valor
         { 
            get { return this._valueDimensao3Valor; } 
            set 
            { 
                if (this._valueDimensao3Valor == value)return;
                 this._valueDimensao3Valor = value; 
            } 
        } 

       protected string _informacoesAdicionaisOriginal{get;private set;}
       private string _informacoesAdicionaisOriginalCommited{get; set;}
        private string _valueInformacoesAdicionais;
         [Column("pci_informacoes_adicionais")]
        public virtual string InformacoesAdicionais
         { 
            get { return this._valueInformacoesAdicionais; } 
            set 
            { 
                if (this._valueInformacoesAdicionais == value)return;
                 this._valueInformacoesAdicionais = value; 
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

       protected string _materialCodigoOriginal{get;private set;}
       private string _materialCodigoOriginalCommited{get; set;}
        private string _valueMaterialCodigo;
         [Column("pci_material_codigo")]
        public virtual string MaterialCodigo
         { 
            get { return this._valueMaterialCodigo; } 
            set 
            { 
                if (this._valueMaterialCodigo == value)return;
                 this._valueMaterialCodigo = value; 
            } 
        } 

       protected string _materialFamiliaOriginal{get;private set;}
       private string _materialFamiliaOriginalCommited{get; set;}
        private string _valueMaterialFamilia;
         [Column("pci_material_familia")]
        public virtual string MaterialFamilia
         { 
            get { return this._valueMaterialFamilia; } 
            set 
            { 
                if (this._valueMaterialFamilia == value)return;
                 this._valueMaterialFamilia = value; 
            } 
        } 

       protected string _materialAgrupadorOriginal{get;private set;}
       private string _materialAgrupadorOriginalCommited{get; set;}
        private string _valueMaterialAgrupador;
         [Column("pci_material_agrupador")]
        public virtual string MaterialAgrupador
         { 
            get { return this._valueMaterialAgrupador; } 
            set 
            { 
                if (this._valueMaterialAgrupador == value)return;
                 this._valueMaterialAgrupador = value; 
            } 
        } 

       protected string _postoNomeOriginal{get;private set;}
       private string _postoNomeOriginalCommited{get; set;}
        private string _valuePostoNome;
         [Column("pci_posto_nome")]
        public virtual string PostoNome
         { 
            get { return this._valuePostoNome; } 
            set 
            { 
                if (this._valuePostoNome == value)return;
                 this._valuePostoNome = value; 
            } 
        } 

       protected string _postoDescricaoOriginal{get;private set;}
       private string _postoDescricaoOriginalCommited{get; set;}
        private string _valuePostoDescricao;
         [Column("pci_posto_descricao")]
        public virtual string PostoDescricao
         { 
            get { return this._valuePostoDescricao; } 
            set 
            { 
                if (this._valuePostoDescricao == value)return;
                 this._valuePostoDescricao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedida1Original{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedida1OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedida1;
        [Column("id_unidade_medida_1", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedida1
        { 
           get {                 return this._valueUnidadeMedida1; } 
           set 
           { 
                if (this._valueUnidadeMedida1 == value)return;
                 this._valueUnidadeMedida1 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedida2Original{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedida2OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedida2;
        [Column("id_unidade_medida_2", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedida2
        { 
           get {                 return this._valueUnidadeMedida2; } 
           set 
           { 
                if (this._valueUnidadeMedida2 == value)return;
                 this._valueUnidadeMedida2 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedida3Original{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedida3OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedida3;
        [Column("id_unidade_medida_3", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedida3
        { 
           get {                 return this._valueUnidadeMedida3; } 
           set 
           { 
                if (this._valueUnidadeMedida3 == value)return;
                 this._valueUnidadeMedida3 = value; 
           } 
       } 

       protected bool _canceladoOriginal{get;private set;}
       private bool _canceladoOriginalCommited{get; set;}
        private bool _valueCancelado;
         [Column("pci_cancelado")]
        public virtual bool Cancelado
         { 
            get { return this._valueCancelado; } 
            set 
            { 
                if (this._valueCancelado == value)return;
                 this._valueCancelado = value; 
            } 
        } 

       protected string _cancelamentoJustificativaOriginal{get;private set;}
       private string _cancelamentoJustificativaOriginalCommited{get; set;}
        private string _valueCancelamentoJustificativa;
         [Column("pci_cancelamento_justificativa")]
        public virtual string CancelamentoJustificativa
         { 
            get { return this._valueCancelamentoJustificativa; } 
            set 
            { 
                if (this._valueCancelamentoJustificativa == value)return;
                 this._valueCancelamentoJustificativa = value; 
            } 
        } 

       protected DateTime? _cancelamentoDataOriginal{get;private set;}
       private DateTime? _cancelamentoDataOriginalCommited{get; set;}
        private DateTime? _valueCancelamentoData;
         [Column("pci_cancelamento_data")]
        public virtual DateTime? CancelamentoData
         { 
            get { return this._valueCancelamentoData; } 
            set 
            { 
                if (this._valueCancelamentoData == value)return;
                 this._valueCancelamentoData = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCancelamentoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCancelamentoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioCancelamento;
        [Column("id_acs_usuario_cancelamento", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioCancelamento
        { 
           get {                 return this._valueAcsUsuarioCancelamento; } 
           set 
           { 
                if (this._valueAcsUsuarioCancelamento == value)return;
                 this._valueAcsUsuarioCancelamento = value; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemOpClassPlanoCorteItemOriginal;
       private List<Entidades.PlanoCorteItemOpClass > _collectionPlanoCorteItemOpClassPlanoCorteItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemOpClassPlanoCorteItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemOpClassPlanoCorteItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemOpClass> _valueCollectionPlanoCorteItemOpClassPlanoCorteItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemOpClass> CollectionPlanoCorteItemOpClassPlanoCorteItem 
       { 
           get { if(!_valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemOpClassPlanoCorteItem();}
return this._valueCollectionPlanoCorteItemOpClassPlanoCorteItem; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemOpClassPlanoCorteItem = value; 
               this._valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemPedidoClassPlanoCorteItemOriginal;
       private List<Entidades.PlanoCorteItemPedidoClass > _collectionPlanoCorteItemPedidoClassPlanoCorteItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemPedidoClass> _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemPedidoClass> CollectionPlanoCorteItemPedidoClassPlanoCorteItem 
       { 
           get { if(!_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemPedidoClassPlanoCorteItem();}
return this._valueCollectionPlanoCorteItemPedidoClassPlanoCorteItem; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemPedidoClassPlanoCorteItem = value; 
               this._valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded = true; 
           } 
       } 

        public PlanoCorteItemBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Cancelado = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static PlanoCorteItemClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PlanoCorteItemClass) GetEntity(typeof(PlanoCorteItemClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionPlanoCorteItemOpClassPlanoCorteItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemOpClassPlanoCorteItemChanged = true;
                  _valueCollectionPlanoCorteItemOpClassPlanoCorteItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemOpClassPlanoCorteItemChanged = true; 
                  _valueCollectionPlanoCorteItemOpClassPlanoCorteItemCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemOpClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemOpClassPlanoCorteItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemOpClassPlanoCorteItemChanged = true; 
                  _valueCollectionPlanoCorteItemOpClassPlanoCorteItemCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemOpClass item in _valueCollectionPlanoCorteItemOpClassPlanoCorteItem) 
                 { 
                     _collectionPlanoCorteItemOpClassPlanoCorteItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemOpClassPlanoCorteItem()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemOpClass> oc;
                _valueCollectionPlanoCorteItemOpClassPlanoCorteItemChanged = false;
                 _valueCollectionPlanoCorteItemOpClassPlanoCorteItemCommitedChanged = false;
                _collectionPlanoCorteItemOpClassPlanoCorteItemRemovidos = new List<Entidades.PlanoCorteItemOpClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemOpClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemOpClass search = new Entidades.PlanoCorteItemOpClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemOpClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PlanoCorteItem", this),                     }                       ).Cast<Entidades.PlanoCorteItemOpClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemOpClassPlanoCorteItem = new BindingList<Entidades.PlanoCorteItemOpClass>(oc); 
                 _collectionPlanoCorteItemOpClassPlanoCorteItemOriginal= (from a in _valueCollectionPlanoCorteItemOpClassPlanoCorteItem select a.ID).ToList();
                 _valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemOpClassPlanoCorteItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemOpClassPlanoCorteItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemPedidoClassPlanoCorteItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemChanged = true;
                  _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemChanged = true; 
                  _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemPedidoClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemPedidoClassPlanoCorteItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemChanged = true; 
                  _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemPedidoClass item in _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItem) 
                 { 
                     _collectionPlanoCorteItemPedidoClassPlanoCorteItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemPedidoClassPlanoCorteItem()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemPedidoClass> oc;
                _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemChanged = false;
                 _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemCommitedChanged = false;
                _collectionPlanoCorteItemPedidoClassPlanoCorteItemRemovidos = new List<Entidades.PlanoCorteItemPedidoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemPedidoClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemPedidoClass search = new Entidades.PlanoCorteItemPedidoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemPedidoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PlanoCorteItem", this),                     }                       ).Cast<Entidades.PlanoCorteItemPedidoClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItem = new BindingList<Entidades.PlanoCorteItemPedidoClass>(oc); 
                 _collectionPlanoCorteItemPedidoClassPlanoCorteItemOriginal= (from a in _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItem select a.ID).ToList();
                 _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemPedidoClassPlanoCorteItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemPedidoClassPlanoCorteItem+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(MaterialCodigo))
                {
                    throw new Exception(ErroMaterialCodigoObrigatorio);
                }
                if (MaterialCodigo.Length >255)
                {
                    throw new Exception( ErroMaterialCodigoComprimento);
                }
                if (string.IsNullOrEmpty(MaterialFamilia))
                {
                    throw new Exception(ErroMaterialFamiliaObrigatorio);
                }
                if (MaterialFamilia.Length >255)
                {
                    throw new Exception( ErroMaterialFamiliaComprimento);
                }
                if (string.IsNullOrEmpty(MaterialAgrupador))
                {
                    throw new Exception(ErroMaterialAgrupadorObrigatorio);
                }
                if (MaterialAgrupador.Length >255)
                {
                    throw new Exception( ErroMaterialAgrupadorComprimento);
                }
                if (string.IsNullOrEmpty(PostoNome))
                {
                    throw new Exception(ErroPostoNomeObrigatorio);
                }
                if (PostoNome.Length >255)
                {
                    throw new Exception( ErroPostoNomeComprimento);
                }
                if (string.IsNullOrEmpty(PostoDescricao))
                {
                    throw new Exception(ErroPostoDescricaoObrigatorio);
                }
                if (PostoDescricao.Length >255)
                {
                    throw new Exception( ErroPostoDescricaoComprimento);
                }
                if ( _valuePlanoCorte == null)
                {
                    throw new Exception(ErroPlanoCorteObrigatorio);
                }
                if ( _valueMaterial == null)
                {
                    throw new Exception(ErroMaterialObrigatorio);
                }
                if ( _valuePostoTrabalhoCorte == null)
                {
                    throw new Exception(ErroPostoTrabalhoCorteObrigatorio);
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
                    "  public.plano_corte_item  " +
                    "WHERE " +
                    "  id_plano_corte_item = :id";
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
                        "  public.plano_corte_item   " +
                        "SET  " + 
                        "  id_plano_corte = :id_plano_corte, " + 
                        "  id_material = :id_material, " + 
                        "  pci_quantidade = :pci_quantidade, " + 
                        "  id_dimensao_1 = :id_dimensao_1, " + 
                        "  pci_dimensao_1_valor = :pci_dimensao_1_valor, " + 
                        "  id_dimensao_2 = :id_dimensao_2, " + 
                        "  pci_dimensao_2_valor = :pci_dimensao_2_valor, " + 
                        "  id_dimensao_3 = :id_dimensao_3, " + 
                        "  pci_dimensao_3_valor = :pci_dimensao_3_valor, " + 
                        "  pci_informacoes_adicionais = :pci_informacoes_adicionais, " + 
                        "  id_posto_trabalho_corte = :id_posto_trabalho_corte, " + 
                        "  pci_material_codigo = :pci_material_codigo, " + 
                        "  pci_material_familia = :pci_material_familia, " + 
                        "  pci_material_agrupador = :pci_material_agrupador, " + 
                        "  pci_posto_nome = :pci_posto_nome, " + 
                        "  pci_posto_descricao = :pci_posto_descricao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_unidade_medida_1 = :id_unidade_medida_1, " + 
                        "  id_unidade_medida_2 = :id_unidade_medida_2, " + 
                        "  id_unidade_medida_3 = :id_unidade_medida_3, " + 
                        "  pci_cancelado = :pci_cancelado, " + 
                        "  pci_cancelamento_justificativa = :pci_cancelamento_justificativa, " + 
                        "  pci_cancelamento_data = :pci_cancelamento_data, " + 
                        "  id_acs_usuario_cancelamento = :id_acs_usuario_cancelamento "+
                        "WHERE  " +
                        "  id_plano_corte_item = :id " +
                        "RETURNING id_plano_corte_item;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.plano_corte_item " +
                        "( " +
                        "  id_plano_corte , " + 
                        "  id_material , " + 
                        "  pci_quantidade , " + 
                        "  id_dimensao_1 , " + 
                        "  pci_dimensao_1_valor , " + 
                        "  id_dimensao_2 , " + 
                        "  pci_dimensao_2_valor , " + 
                        "  id_dimensao_3 , " + 
                        "  pci_dimensao_3_valor , " + 
                        "  pci_informacoes_adicionais , " + 
                        "  id_posto_trabalho_corte , " + 
                        "  pci_material_codigo , " + 
                        "  pci_material_familia , " + 
                        "  pci_material_agrupador , " + 
                        "  pci_posto_nome , " + 
                        "  pci_posto_descricao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_unidade_medida_1 , " + 
                        "  id_unidade_medida_2 , " + 
                        "  id_unidade_medida_3 , " + 
                        "  pci_cancelado , " + 
                        "  pci_cancelamento_justificativa , " + 
                        "  pci_cancelamento_data , " + 
                        "  id_acs_usuario_cancelamento  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_plano_corte , " + 
                        "  :id_material , " + 
                        "  :pci_quantidade , " + 
                        "  :id_dimensao_1 , " + 
                        "  :pci_dimensao_1_valor , " + 
                        "  :id_dimensao_2 , " + 
                        "  :pci_dimensao_2_valor , " + 
                        "  :id_dimensao_3 , " + 
                        "  :pci_dimensao_3_valor , " + 
                        "  :pci_informacoes_adicionais , " + 
                        "  :id_posto_trabalho_corte , " + 
                        "  :pci_material_codigo , " + 
                        "  :pci_material_familia , " + 
                        "  :pci_material_agrupador , " + 
                        "  :pci_posto_nome , " + 
                        "  :pci_posto_descricao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_unidade_medida_1 , " + 
                        "  :id_unidade_medida_2 , " + 
                        "  :id_unidade_medida_3 , " + 
                        "  :pci_cancelado , " + 
                        "  :pci_cancelamento_justificativa , " + 
                        "  :pci_cancelamento_data , " + 
                        "  :id_acs_usuario_cancelamento  "+
                        ")RETURNING id_plano_corte_item;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_plano_corte", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PlanoCorte==null ? (object) DBNull.Value : this.PlanoCorte.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_dimensao_1", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Dimensao1==null ? (object) DBNull.Value : this.Dimensao1.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_dimensao_1_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Dimensao1Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_dimensao_2", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Dimensao2==null ? (object) DBNull.Value : this.Dimensao2.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_dimensao_2_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Dimensao2Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_dimensao_3", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Dimensao3==null ? (object) DBNull.Value : this.Dimensao3.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_dimensao_3_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Dimensao3Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_informacoes_adicionais", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InformacoesAdicionais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho_corte", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PostoTrabalhoCorte==null ? (object) DBNull.Value : this.PostoTrabalhoCorte.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_material_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialCodigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_material_familia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialFamilia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_material_agrupador", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialAgrupador ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_posto_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PostoNome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_posto_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PostoDescricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_1", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedida1==null ? (object) DBNull.Value : this.UnidadeMedida1.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_2", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedida2==null ? (object) DBNull.Value : this.UnidadeMedida2.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_3", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedida3==null ? (object) DBNull.Value : this.UnidadeMedida3.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_cancelado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cancelado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_cancelamento_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CancelamentoJustificativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pci_cancelamento_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CancelamentoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioCancelamento==null ? (object) DBNull.Value : this.AcsUsuarioCancelamento.ID;

 
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
 if (CollectionPlanoCorteItemOpClassPlanoCorteItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemOpClassPlanoCorteItem+"\r\n";
                foreach (Entidades.PlanoCorteItemOpClass tmp in CollectionPlanoCorteItemOpClassPlanoCorteItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemPedidoClassPlanoCorteItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemPedidoClassPlanoCorteItem+"\r\n";
                foreach (Entidades.PlanoCorteItemPedidoClass tmp in CollectionPlanoCorteItemPedidoClassPlanoCorteItem)
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
        public static PlanoCorteItemClass CopiarEntidade(PlanoCorteItemClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PlanoCorteItemClass toRet = new PlanoCorteItemClass(usuario,conn);
 toRet.PlanoCorte= entidadeCopiar.PlanoCorte;
 toRet.Material= entidadeCopiar.Material;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.Dimensao1= entidadeCopiar.Dimensao1;
 toRet.Dimensao1Valor= entidadeCopiar.Dimensao1Valor;
 toRet.Dimensao2= entidadeCopiar.Dimensao2;
 toRet.Dimensao2Valor= entidadeCopiar.Dimensao2Valor;
 toRet.Dimensao3= entidadeCopiar.Dimensao3;
 toRet.Dimensao3Valor= entidadeCopiar.Dimensao3Valor;
 toRet.InformacoesAdicionais= entidadeCopiar.InformacoesAdicionais;
 toRet.PostoTrabalhoCorte= entidadeCopiar.PostoTrabalhoCorte;
 toRet.MaterialCodigo= entidadeCopiar.MaterialCodigo;
 toRet.MaterialFamilia= entidadeCopiar.MaterialFamilia;
 toRet.MaterialAgrupador= entidadeCopiar.MaterialAgrupador;
 toRet.PostoNome= entidadeCopiar.PostoNome;
 toRet.PostoDescricao= entidadeCopiar.PostoDescricao;
 toRet.UnidadeMedida1= entidadeCopiar.UnidadeMedida1;
 toRet.UnidadeMedida2= entidadeCopiar.UnidadeMedida2;
 toRet.UnidadeMedida3= entidadeCopiar.UnidadeMedida3;
 toRet.Cancelado= entidadeCopiar.Cancelado;
 toRet.CancelamentoJustificativa= entidadeCopiar.CancelamentoJustificativa;
 toRet.CancelamentoData= entidadeCopiar.CancelamentoData;
 toRet.AcsUsuarioCancelamento= entidadeCopiar.AcsUsuarioCancelamento;

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
       _planoCorteOriginal = PlanoCorte;
       _planoCorteOriginalCommited = _planoCorteOriginal;
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _dimensao1Original = Dimensao1;
       _dimensao1OriginalCommited = _dimensao1Original;
       _dimensao1ValorOriginal = Dimensao1Valor;
       _dimensao1ValorOriginalCommited = _dimensao1ValorOriginal;
       _dimensao2Original = Dimensao2;
       _dimensao2OriginalCommited = _dimensao2Original;
       _dimensao2ValorOriginal = Dimensao2Valor;
       _dimensao2ValorOriginalCommited = _dimensao2ValorOriginal;
       _dimensao3Original = Dimensao3;
       _dimensao3OriginalCommited = _dimensao3Original;
       _dimensao3ValorOriginal = Dimensao3Valor;
       _dimensao3ValorOriginalCommited = _dimensao3ValorOriginal;
       _informacoesAdicionaisOriginal = InformacoesAdicionais;
       _informacoesAdicionaisOriginalCommited = _informacoesAdicionaisOriginal;
       _postoTrabalhoCorteOriginal = PostoTrabalhoCorte;
       _postoTrabalhoCorteOriginalCommited = _postoTrabalhoCorteOriginal;
       _materialCodigoOriginal = MaterialCodigo;
       _materialCodigoOriginalCommited = _materialCodigoOriginal;
       _materialFamiliaOriginal = MaterialFamilia;
       _materialFamiliaOriginalCommited = _materialFamiliaOriginal;
       _materialAgrupadorOriginal = MaterialAgrupador;
       _materialAgrupadorOriginalCommited = _materialAgrupadorOriginal;
       _postoNomeOriginal = PostoNome;
       _postoNomeOriginalCommited = _postoNomeOriginal;
       _postoDescricaoOriginal = PostoDescricao;
       _postoDescricaoOriginalCommited = _postoDescricaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _unidadeMedida1Original = UnidadeMedida1;
       _unidadeMedida1OriginalCommited = _unidadeMedida1Original;
       _unidadeMedida2Original = UnidadeMedida2;
       _unidadeMedida2OriginalCommited = _unidadeMedida2Original;
       _unidadeMedida3Original = UnidadeMedida3;
       _unidadeMedida3OriginalCommited = _unidadeMedida3Original;
       _canceladoOriginal = Cancelado;
       _canceladoOriginalCommited = _canceladoOriginal;
       _cancelamentoJustificativaOriginal = CancelamentoJustificativa;
       _cancelamentoJustificativaOriginalCommited = _cancelamentoJustificativaOriginal;
       _cancelamentoDataOriginal = CancelamentoData;
       _cancelamentoDataOriginalCommited = _cancelamentoDataOriginal;
       _acsUsuarioCancelamentoOriginal = AcsUsuarioCancelamento;
       _acsUsuarioCancelamentoOriginalCommited = _acsUsuarioCancelamentoOriginal;

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
       _planoCorteOriginalCommited = PlanoCorte;
       _materialOriginalCommited = Material;
       _quantidadeOriginalCommited = Quantidade;
       _dimensao1OriginalCommited = Dimensao1;
       _dimensao1ValorOriginalCommited = Dimensao1Valor;
       _dimensao2OriginalCommited = Dimensao2;
       _dimensao2ValorOriginalCommited = Dimensao2Valor;
       _dimensao3OriginalCommited = Dimensao3;
       _dimensao3ValorOriginalCommited = Dimensao3Valor;
       _informacoesAdicionaisOriginalCommited = InformacoesAdicionais;
       _postoTrabalhoCorteOriginalCommited = PostoTrabalhoCorte;
       _materialCodigoOriginalCommited = MaterialCodigo;
       _materialFamiliaOriginalCommited = MaterialFamilia;
       _materialAgrupadorOriginalCommited = MaterialAgrupador;
       _postoNomeOriginalCommited = PostoNome;
       _postoDescricaoOriginalCommited = PostoDescricao;
       _versionOriginalCommited = Version;
       _unidadeMedida1OriginalCommited = UnidadeMedida1;
       _unidadeMedida2OriginalCommited = UnidadeMedida2;
       _unidadeMedida3OriginalCommited = UnidadeMedida3;
       _canceladoOriginalCommited = Cancelado;
       _cancelamentoJustificativaOriginalCommited = CancelamentoJustificativa;
       _cancelamentoDataOriginalCommited = CancelamentoData;
       _acsUsuarioCancelamentoOriginalCommited = AcsUsuarioCancelamento;

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
               if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded) 
               {
                  if (_collectionPlanoCorteItemOpClassPlanoCorteItemRemovidos != null) 
                  {
                     _collectionPlanoCorteItemOpClassPlanoCorteItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemOpClassPlanoCorteItemRemovidos = new List<Entidades.PlanoCorteItemOpClass>();
                  }
                  _collectionPlanoCorteItemOpClassPlanoCorteItemOriginal= (from a in _valueCollectionPlanoCorteItemOpClassPlanoCorteItem select a.ID).ToList();
                  _valueCollectionPlanoCorteItemOpClassPlanoCorteItemChanged = false;
                  _valueCollectionPlanoCorteItemOpClassPlanoCorteItemCommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded) 
               {
                  if (_collectionPlanoCorteItemPedidoClassPlanoCorteItemRemovidos != null) 
                  {
                     _collectionPlanoCorteItemPedidoClassPlanoCorteItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemPedidoClassPlanoCorteItemRemovidos = new List<Entidades.PlanoCorteItemPedidoClass>();
                  }
                  _collectionPlanoCorteItemPedidoClassPlanoCorteItemOriginal= (from a in _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItem select a.ID).ToList();
                  _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemChanged = false;
                  _valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemCommitedChanged = false;
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
               PlanoCorte=_planoCorteOriginal;
               _planoCorteOriginalCommited=_planoCorteOriginal;
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               Dimensao1=_dimensao1Original;
               _dimensao1OriginalCommited=_dimensao1Original;
               Dimensao1Valor=_dimensao1ValorOriginal;
               _dimensao1ValorOriginalCommited=_dimensao1ValorOriginal;
               Dimensao2=_dimensao2Original;
               _dimensao2OriginalCommited=_dimensao2Original;
               Dimensao2Valor=_dimensao2ValorOriginal;
               _dimensao2ValorOriginalCommited=_dimensao2ValorOriginal;
               Dimensao3=_dimensao3Original;
               _dimensao3OriginalCommited=_dimensao3Original;
               Dimensao3Valor=_dimensao3ValorOriginal;
               _dimensao3ValorOriginalCommited=_dimensao3ValorOriginal;
               InformacoesAdicionais=_informacoesAdicionaisOriginal;
               _informacoesAdicionaisOriginalCommited=_informacoesAdicionaisOriginal;
               PostoTrabalhoCorte=_postoTrabalhoCorteOriginal;
               _postoTrabalhoCorteOriginalCommited=_postoTrabalhoCorteOriginal;
               MaterialCodigo=_materialCodigoOriginal;
               _materialCodigoOriginalCommited=_materialCodigoOriginal;
               MaterialFamilia=_materialFamiliaOriginal;
               _materialFamiliaOriginalCommited=_materialFamiliaOriginal;
               MaterialAgrupador=_materialAgrupadorOriginal;
               _materialAgrupadorOriginalCommited=_materialAgrupadorOriginal;
               PostoNome=_postoNomeOriginal;
               _postoNomeOriginalCommited=_postoNomeOriginal;
               PostoDescricao=_postoDescricaoOriginal;
               _postoDescricaoOriginalCommited=_postoDescricaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               UnidadeMedida1=_unidadeMedida1Original;
               _unidadeMedida1OriginalCommited=_unidadeMedida1Original;
               UnidadeMedida2=_unidadeMedida2Original;
               _unidadeMedida2OriginalCommited=_unidadeMedida2Original;
               UnidadeMedida3=_unidadeMedida3Original;
               _unidadeMedida3OriginalCommited=_unidadeMedida3Original;
               Cancelado=_canceladoOriginal;
               _canceladoOriginalCommited=_canceladoOriginal;
               CancelamentoJustificativa=_cancelamentoJustificativaOriginal;
               _cancelamentoJustificativaOriginalCommited=_cancelamentoJustificativaOriginal;
               CancelamentoData=_cancelamentoDataOriginal;
               _cancelamentoDataOriginalCommited=_cancelamentoDataOriginal;
               AcsUsuarioCancelamento=_acsUsuarioCancelamentoOriginal;
               _acsUsuarioCancelamentoOriginalCommited=_acsUsuarioCancelamentoOriginal;
               if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded) 
               {
                  CollectionPlanoCorteItemOpClassPlanoCorteItem.Clear();
                  foreach(int item in _collectionPlanoCorteItemOpClassPlanoCorteItemOriginal)
                  {
                    CollectionPlanoCorteItemOpClassPlanoCorteItem.Add(Entidades.PlanoCorteItemOpClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemOpClassPlanoCorteItemRemovidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded) 
               {
                  CollectionPlanoCorteItemPedidoClassPlanoCorteItem.Clear();
                  foreach(int item in _collectionPlanoCorteItemPedidoClassPlanoCorteItemOriginal)
                  {
                    CollectionPlanoCorteItemPedidoClassPlanoCorteItem.Add(Entidades.PlanoCorteItemPedidoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemPedidoClassPlanoCorteItemRemovidos.Clear();
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
               if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemOpClassPlanoCorteItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemPedidoClassPlanoCorteItem.Any(item => item.IsDirty());
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
       if (_planoCorteOriginal!=null)
       {
          dirty = !_planoCorteOriginal.Equals(PlanoCorte);
       }
       else
       {
            dirty = PlanoCorte != null;
       }
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
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       if (_dimensao1Original!=null)
       {
          dirty = !_dimensao1Original.Equals(Dimensao1);
       }
       else
       {
            dirty = Dimensao1 != null;
       }
      if (dirty) return true;
       dirty = _dimensao1ValorOriginal != Dimensao1Valor;
      if (dirty) return true;
       if (_dimensao2Original!=null)
       {
          dirty = !_dimensao2Original.Equals(Dimensao2);
       }
       else
       {
            dirty = Dimensao2 != null;
       }
      if (dirty) return true;
       dirty = _dimensao2ValorOriginal != Dimensao2Valor;
      if (dirty) return true;
       if (_dimensao3Original!=null)
       {
          dirty = !_dimensao3Original.Equals(Dimensao3);
       }
       else
       {
            dirty = Dimensao3 != null;
       }
      if (dirty) return true;
       dirty = _dimensao3ValorOriginal != Dimensao3Valor;
      if (dirty) return true;
       dirty = _informacoesAdicionaisOriginal != InformacoesAdicionais;
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
       dirty = _materialCodigoOriginal != MaterialCodigo;
      if (dirty) return true;
       dirty = _materialFamiliaOriginal != MaterialFamilia;
      if (dirty) return true;
       dirty = _materialAgrupadorOriginal != MaterialAgrupador;
      if (dirty) return true;
       dirty = _postoNomeOriginal != PostoNome;
      if (dirty) return true;
       dirty = _postoDescricaoOriginal != PostoDescricao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_unidadeMedida1Original!=null)
       {
          dirty = !_unidadeMedida1Original.Equals(UnidadeMedida1);
       }
       else
       {
            dirty = UnidadeMedida1 != null;
       }
      if (dirty) return true;
       if (_unidadeMedida2Original!=null)
       {
          dirty = !_unidadeMedida2Original.Equals(UnidadeMedida2);
       }
       else
       {
            dirty = UnidadeMedida2 != null;
       }
      if (dirty) return true;
       if (_unidadeMedida3Original!=null)
       {
          dirty = !_unidadeMedida3Original.Equals(UnidadeMedida3);
       }
       else
       {
            dirty = UnidadeMedida3 != null;
       }
      if (dirty) return true;
       dirty = _canceladoOriginal != Cancelado;
      if (dirty) return true;
       dirty = _cancelamentoJustificativaOriginal != CancelamentoJustificativa;
      if (dirty) return true;
       dirty = _cancelamentoDataOriginal != CancelamentoData;
      if (dirty) return true;
       if (_acsUsuarioCancelamentoOriginal!=null)
       {
          dirty = !_acsUsuarioCancelamentoOriginal.Equals(AcsUsuarioCancelamento);
       }
       else
       {
            dirty = AcsUsuarioCancelamento != null;
       }

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
               if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemOpClassPlanoCorteItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemPedidoClassPlanoCorteItem.Any(item => item.IsDirtyCommited());
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
       if (_planoCorteOriginalCommited!=null)
       {
          dirty = !_planoCorteOriginalCommited.Equals(PlanoCorte);
       }
       else
       {
            dirty = PlanoCorte != null;
       }
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
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       if (_dimensao1OriginalCommited!=null)
       {
          dirty = !_dimensao1OriginalCommited.Equals(Dimensao1);
       }
       else
       {
            dirty = Dimensao1 != null;
       }
      if (dirty) return true;
       dirty = _dimensao1ValorOriginalCommited != Dimensao1Valor;
      if (dirty) return true;
       if (_dimensao2OriginalCommited!=null)
       {
          dirty = !_dimensao2OriginalCommited.Equals(Dimensao2);
       }
       else
       {
            dirty = Dimensao2 != null;
       }
      if (dirty) return true;
       dirty = _dimensao2ValorOriginalCommited != Dimensao2Valor;
      if (dirty) return true;
       if (_dimensao3OriginalCommited!=null)
       {
          dirty = !_dimensao3OriginalCommited.Equals(Dimensao3);
       }
       else
       {
            dirty = Dimensao3 != null;
       }
      if (dirty) return true;
       dirty = _dimensao3ValorOriginalCommited != Dimensao3Valor;
      if (dirty) return true;
       dirty = _informacoesAdicionaisOriginalCommited != InformacoesAdicionais;
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
       dirty = _materialCodigoOriginalCommited != MaterialCodigo;
      if (dirty) return true;
       dirty = _materialFamiliaOriginalCommited != MaterialFamilia;
      if (dirty) return true;
       dirty = _materialAgrupadorOriginalCommited != MaterialAgrupador;
      if (dirty) return true;
       dirty = _postoNomeOriginalCommited != PostoNome;
      if (dirty) return true;
       dirty = _postoDescricaoOriginalCommited != PostoDescricao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_unidadeMedida1OriginalCommited!=null)
       {
          dirty = !_unidadeMedida1OriginalCommited.Equals(UnidadeMedida1);
       }
       else
       {
            dirty = UnidadeMedida1 != null;
       }
      if (dirty) return true;
       if (_unidadeMedida2OriginalCommited!=null)
       {
          dirty = !_unidadeMedida2OriginalCommited.Equals(UnidadeMedida2);
       }
       else
       {
            dirty = UnidadeMedida2 != null;
       }
      if (dirty) return true;
       if (_unidadeMedida3OriginalCommited!=null)
       {
          dirty = !_unidadeMedida3OriginalCommited.Equals(UnidadeMedida3);
       }
       else
       {
            dirty = UnidadeMedida3 != null;
       }
      if (dirty) return true;
       dirty = _canceladoOriginalCommited != Cancelado;
      if (dirty) return true;
       dirty = _cancelamentoJustificativaOriginalCommited != CancelamentoJustificativa;
      if (dirty) return true;
       dirty = _cancelamentoDataOriginalCommited != CancelamentoData;
      if (dirty) return true;
       if (_acsUsuarioCancelamentoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioCancelamentoOriginalCommited.Equals(AcsUsuarioCancelamento);
       }
       else
       {
            dirty = AcsUsuarioCancelamento != null;
       }

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
               if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded) 
               {
                  foreach(PlanoCorteItemOpClass item in CollectionPlanoCorteItemOpClassPlanoCorteItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded) 
               {
                  foreach(PlanoCorteItemPedidoClass item in CollectionPlanoCorteItemPedidoClassPlanoCorteItem)
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
             case "PlanoCorte":
                return this.PlanoCorte;
             case "Material":
                return this.Material;
             case "Quantidade":
                return this.Quantidade;
             case "Dimensao1":
                return this.Dimensao1;
             case "Dimensao1Valor":
                return this.Dimensao1Valor;
             case "Dimensao2":
                return this.Dimensao2;
             case "Dimensao2Valor":
                return this.Dimensao2Valor;
             case "Dimensao3":
                return this.Dimensao3;
             case "Dimensao3Valor":
                return this.Dimensao3Valor;
             case "InformacoesAdicionais":
                return this.InformacoesAdicionais;
             case "PostoTrabalhoCorte":
                return this.PostoTrabalhoCorte;
             case "MaterialCodigo":
                return this.MaterialCodigo;
             case "MaterialFamilia":
                return this.MaterialFamilia;
             case "MaterialAgrupador":
                return this.MaterialAgrupador;
             case "PostoNome":
                return this.PostoNome;
             case "PostoDescricao":
                return this.PostoDescricao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "UnidadeMedida1":
                return this.UnidadeMedida1;
             case "UnidadeMedida2":
                return this.UnidadeMedida2;
             case "UnidadeMedida3":
                return this.UnidadeMedida3;
             case "Cancelado":
                return this.Cancelado;
             case "CancelamentoJustificativa":
                return this.CancelamentoJustificativa;
             case "CancelamentoData":
                return this.CancelamentoData;
             case "AcsUsuarioCancelamento":
                return this.AcsUsuarioCancelamento;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (PlanoCorte!=null)
                PlanoCorte.ChangeSingleConnection(newConnection);
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
             if (Dimensao1!=null)
                Dimensao1.ChangeSingleConnection(newConnection);
             if (Dimensao2!=null)
                Dimensao2.ChangeSingleConnection(newConnection);
             if (Dimensao3!=null)
                Dimensao3.ChangeSingleConnection(newConnection);
             if (PostoTrabalhoCorte!=null)
                PostoTrabalhoCorte.ChangeSingleConnection(newConnection);
             if (UnidadeMedida1!=null)
                UnidadeMedida1.ChangeSingleConnection(newConnection);
             if (UnidadeMedida2!=null)
                UnidadeMedida2.ChangeSingleConnection(newConnection);
             if (UnidadeMedida3!=null)
                UnidadeMedida3.ChangeSingleConnection(newConnection);
             if (AcsUsuarioCancelamento!=null)
                AcsUsuarioCancelamento.ChangeSingleConnection(newConnection);
               if (_valueCollectionPlanoCorteItemOpClassPlanoCorteItemLoaded) 
               {
                  foreach(PlanoCorteItemOpClass item in CollectionPlanoCorteItemOpClassPlanoCorteItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemPedidoClassPlanoCorteItemLoaded) 
               {
                  foreach(PlanoCorteItemPedidoClass item in CollectionPlanoCorteItemPedidoClassPlanoCorteItem)
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
                  command.CommandText += " COUNT(plano_corte_item.id_plano_corte_item) " ;
               }
               else
               {
               command.CommandText += "plano_corte_item.id_plano_corte_item, " ;
               command.CommandText += "plano_corte_item.id_plano_corte, " ;
               command.CommandText += "plano_corte_item.id_material, " ;
               command.CommandText += "plano_corte_item.pci_quantidade, " ;
               command.CommandText += "plano_corte_item.id_dimensao_1, " ;
               command.CommandText += "plano_corte_item.pci_dimensao_1_valor, " ;
               command.CommandText += "plano_corte_item.id_dimensao_2, " ;
               command.CommandText += "plano_corte_item.pci_dimensao_2_valor, " ;
               command.CommandText += "plano_corte_item.id_dimensao_3, " ;
               command.CommandText += "plano_corte_item.pci_dimensao_3_valor, " ;
               command.CommandText += "plano_corte_item.pci_informacoes_adicionais, " ;
               command.CommandText += "plano_corte_item.id_posto_trabalho_corte, " ;
               command.CommandText += "plano_corte_item.pci_material_codigo, " ;
               command.CommandText += "plano_corte_item.pci_material_familia, " ;
               command.CommandText += "plano_corte_item.pci_material_agrupador, " ;
               command.CommandText += "plano_corte_item.pci_posto_nome, " ;
               command.CommandText += "plano_corte_item.pci_posto_descricao, " ;
               command.CommandText += "plano_corte_item.entity_uid, " ;
               command.CommandText += "plano_corte_item.version, " ;
               command.CommandText += "plano_corte_item.id_unidade_medida_1, " ;
               command.CommandText += "plano_corte_item.id_unidade_medida_2, " ;
               command.CommandText += "plano_corte_item.id_unidade_medida_3, " ;
               command.CommandText += "plano_corte_item.pci_cancelado, " ;
               command.CommandText += "plano_corte_item.pci_cancelamento_justificativa, " ;
               command.CommandText += "plano_corte_item.pci_cancelamento_data, " ;
               command.CommandText += "plano_corte_item.id_acs_usuario_cancelamento " ;
               }
               command.CommandText += " FROM  plano_corte_item ";
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
                        orderByClause += " , pci_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pci_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = plano_corte_item.id_acs_usuario_ultima_revisao ";
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
                     case "id_plano_corte_item":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item.id_plano_corte_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item.id_plano_corte_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_plano_corte":
                     case "PlanoCorte":
                     command.CommandText += " LEFT JOIN plano_corte as plano_corte_PlanoCorte ON plano_corte_PlanoCorte.id_plano_corte = plano_corte_item.id_plano_corte ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_PlanoCorte.id_plano_corte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_PlanoCorte.id_plano_corte) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = plano_corte_item.id_material ";                     switch (parametro.TipoOrdenacao)
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
                     case "pci_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item.pci_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item.pci_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_dimensao_1":
                     case "Dimensao1":
                     command.CommandText += " LEFT JOIN dimensao as dimensao_Dimensao1 ON dimensao_Dimensao1.id_dimensao = plano_corte_item.id_dimensao_1 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao_Dimensao1.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao_Dimensao1.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_dimensao_1_valor":
                     case "Dimensao1Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_dimensao_1_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_dimensao_1_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_dimensao_2":
                     case "Dimensao2":
                     command.CommandText += " LEFT JOIN dimensao as dimensao_Dimensao2 ON dimensao_Dimensao2.id_dimensao = plano_corte_item.id_dimensao_2 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao_Dimensao2.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao_Dimensao2.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_dimensao_2_valor":
                     case "Dimensao2Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_dimensao_2_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_dimensao_2_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_dimensao_3":
                     case "Dimensao3":
                     command.CommandText += " LEFT JOIN dimensao as dimensao_Dimensao3 ON dimensao_Dimensao3.id_dimensao = plano_corte_item.id_dimensao_3 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao_Dimensao3.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao_Dimensao3.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_dimensao_3_valor":
                     case "Dimensao3Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_dimensao_3_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_dimensao_3_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_informacoes_adicionais":
                     case "InformacoesAdicionais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_informacoes_adicionais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_informacoes_adicionais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_posto_trabalho_corte":
                     case "PostoTrabalhoCorte":
                     command.CommandText += " LEFT JOIN posto_trabalho as posto_trabalho_PostoTrabalhoCorte ON posto_trabalho_PostoTrabalhoCorte.id_posto_trabalho = plano_corte_item.id_posto_trabalho_corte ";                     switch (parametro.TipoOrdenacao)
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
                     case "pci_material_codigo":
                     case "MaterialCodigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_material_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_material_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_material_familia":
                     case "MaterialFamilia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_material_familia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_material_familia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_material_agrupador":
                     case "MaterialAgrupador":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_material_agrupador " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_material_agrupador) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_posto_nome":
                     case "PostoNome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_posto_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_posto_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_posto_descricao":
                     case "PostoDescricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_posto_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_posto_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , plano_corte_item.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_1":
                     case "UnidadeMedida1":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedida1 ON unidade_medida_UnidadeMedida1.id_unidade_medida = plano_corte_item.id_unidade_medida_1 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedida1.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedida1.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_2":
                     case "UnidadeMedida2":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedida2 ON unidade_medida_UnidadeMedida2.id_unidade_medida = plano_corte_item.id_unidade_medida_2 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedida2.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedida2.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_3":
                     case "UnidadeMedida3":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedida3 ON unidade_medida_UnidadeMedida3.id_unidade_medida = plano_corte_item.id_unidade_medida_3 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedida3.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedida3.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_cancelado":
                     case "Cancelado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item.pci_cancelado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item.pci_cancelado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_cancelamento_justificativa":
                     case "CancelamentoJustificativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item.pci_cancelamento_justificativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item.pci_cancelamento_justificativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pci_cancelamento_data":
                     case "CancelamentoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item.pci_cancelamento_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item.pci_cancelamento_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_cancelamento":
                     case "AcsUsuarioCancelamento":
                     orderByClause += " , plano_corte_item.id_acs_usuario_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_dimensao_1_valor")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_dimensao_1_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_dimensao_1_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_dimensao_2_valor")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_dimensao_2_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_dimensao_2_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_dimensao_3_valor")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_dimensao_3_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_dimensao_3_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_informacoes_adicionais")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_informacoes_adicionais) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_informacoes_adicionais) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_material_codigo")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_material_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_material_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_material_familia")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_material_familia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_material_familia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_material_agrupador")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_material_agrupador) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_material_agrupador) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_posto_nome")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_posto_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_posto_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_posto_descricao")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_posto_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_posto_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pci_cancelamento_justificativa")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item.pci_cancelamento_justificativa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item.pci_cancelamento_justificativa) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_plano_corte_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.id_plano_corte_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_plano_corte_item = :plano_corte_item_ID_7927 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_ID_7927", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorte" || parametro.FieldName == "id_plano_corte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PlanoCorteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PlanoCorteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.id_plano_corte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_plano_corte = :plano_corte_item_PlanoCorte_7688 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_PlanoCorte_7688", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  plano_corte_item.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_material = :plano_corte_item_Material_4982 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Material_4982", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "pci_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_quantidade = :plano_corte_item_Quantidade_4052 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Quantidade_4052", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao1" || parametro.FieldName == "id_dimensao_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DimensaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DimensaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.id_dimensao_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_dimensao_1 = :plano_corte_item_Dimensao1_926 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Dimensao1_926", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao1Valor" || parametro.FieldName == "pci_dimensao_1_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_1_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_1_valor LIKE :plano_corte_item_Dimensao1Valor_6696 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Dimensao1Valor_6696", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao2" || parametro.FieldName == "id_dimensao_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DimensaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DimensaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.id_dimensao_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_dimensao_2 = :plano_corte_item_Dimensao2_3931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Dimensao2_3931", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao2Valor" || parametro.FieldName == "pci_dimensao_2_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_2_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_2_valor LIKE :plano_corte_item_Dimensao2Valor_6027 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Dimensao2Valor_6027", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao3" || parametro.FieldName == "id_dimensao_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DimensaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DimensaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.id_dimensao_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_dimensao_3 = :plano_corte_item_Dimensao3_5426 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Dimensao3_5426", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao3Valor" || parametro.FieldName == "pci_dimensao_3_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_3_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_3_valor LIKE :plano_corte_item_Dimensao3Valor_9524 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Dimensao3Valor_9524", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacoesAdicionais" || parametro.FieldName == "pci_informacoes_adicionais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_informacoes_adicionais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_informacoes_adicionais LIKE :plano_corte_item_InformacoesAdicionais_6320 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_InformacoesAdicionais_6320", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  plano_corte_item.id_posto_trabalho_corte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_posto_trabalho_corte = :plano_corte_item_PostoTrabalhoCorte_7720 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_PostoTrabalhoCorte_7720", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialCodigo" || parametro.FieldName == "pci_material_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_material_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_material_codigo LIKE :plano_corte_item_MaterialCodigo_319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_MaterialCodigo_319", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialFamilia" || parametro.FieldName == "pci_material_familia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_material_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_material_familia LIKE :plano_corte_item_MaterialFamilia_8578 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_MaterialFamilia_8578", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialAgrupador" || parametro.FieldName == "pci_material_agrupador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_material_agrupador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_material_agrupador LIKE :plano_corte_item_MaterialAgrupador_2698 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_MaterialAgrupador_2698", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoNome" || parametro.FieldName == "pci_posto_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_posto_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_posto_nome LIKE :plano_corte_item_PostoNome_2545 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_PostoNome_2545", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoDescricao" || parametro.FieldName == "pci_posto_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_posto_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_posto_descricao LIKE :plano_corte_item_PostoDescricao_24 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_PostoDescricao_24", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  plano_corte_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.entity_uid LIKE :plano_corte_item_EntityUid_732 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_EntityUid_732", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  plano_corte_item.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.version = :plano_corte_item_Version_5841 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Version_5841", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedida1" || parametro.FieldName == "id_unidade_medida_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.id_unidade_medida_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_unidade_medida_1 = :plano_corte_item_UnidadeMedida1_8190 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_UnidadeMedida1_8190", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedida2" || parametro.FieldName == "id_unidade_medida_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.id_unidade_medida_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_unidade_medida_2 = :plano_corte_item_UnidadeMedida2_2220 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_UnidadeMedida2_2220", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedida3" || parametro.FieldName == "id_unidade_medida_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.id_unidade_medida_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_unidade_medida_3 = :plano_corte_item_UnidadeMedida3_2934 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_UnidadeMedida3_2934", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cancelado" || parametro.FieldName == "pci_cancelado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_cancelado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_cancelado = :plano_corte_item_Cancelado_5578 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Cancelado_5578", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CancelamentoJustificativa" || parametro.FieldName == "pci_cancelamento_justificativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_cancelamento_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_cancelamento_justificativa LIKE :plano_corte_item_CancelamentoJustificativa_3763 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_CancelamentoJustificativa_3763", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CancelamentoData" || parametro.FieldName == "pci_cancelamento_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_cancelamento_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_cancelamento_data = :plano_corte_item_CancelamentoData_4005 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_CancelamentoData_4005", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioCancelamento" || parametro.FieldName == "id_acs_usuario_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.id_acs_usuario_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.id_acs_usuario_cancelamento = :plano_corte_item_AcsUsuarioCancelamento_6200 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_AcsUsuarioCancelamento_6200", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao1ValorExato" || parametro.FieldName == "Dimensao1ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_1_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_1_valor LIKE :plano_corte_item_Dimensao1Valor_9887 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Dimensao1Valor_9887", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao2ValorExato" || parametro.FieldName == "Dimensao2ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_2_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_2_valor LIKE :plano_corte_item_Dimensao2Valor_3602 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Dimensao2Valor_3602", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao3ValorExato" || parametro.FieldName == "Dimensao3ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_3_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_dimensao_3_valor LIKE :plano_corte_item_Dimensao3Valor_2249 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_Dimensao3Valor_2249", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacoesAdicionaisExato" || parametro.FieldName == "InformacoesAdicionaisExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_informacoes_adicionais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_informacoes_adicionais LIKE :plano_corte_item_InformacoesAdicionais_7949 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_InformacoesAdicionais_7949", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialCodigoExato" || parametro.FieldName == "MaterialCodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_material_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_material_codigo LIKE :plano_corte_item_MaterialCodigo_6590 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_MaterialCodigo_6590", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialFamiliaExato" || parametro.FieldName == "MaterialFamiliaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_material_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_material_familia LIKE :plano_corte_item_MaterialFamilia_1101 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_MaterialFamilia_1101", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialAgrupadorExato" || parametro.FieldName == "MaterialAgrupadorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_material_agrupador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_material_agrupador LIKE :plano_corte_item_MaterialAgrupador_1951 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_MaterialAgrupador_1951", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoNomeExato" || parametro.FieldName == "PostoNomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_posto_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_posto_nome LIKE :plano_corte_item_PostoNome_825 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_PostoNome_825", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoDescricaoExato" || parametro.FieldName == "PostoDescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_posto_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_posto_descricao LIKE :plano_corte_item_PostoDescricao_749 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_PostoDescricao_749", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  plano_corte_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.entity_uid LIKE :plano_corte_item_EntityUid_4763 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_EntityUid_4763", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CancelamentoJustificativaExato" || parametro.FieldName == "CancelamentoJustificativaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item.pci_cancelamento_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item.pci_cancelamento_justificativa LIKE :plano_corte_item_CancelamentoJustificativa_9173 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_CancelamentoJustificativa_9173", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PlanoCorteItemClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PlanoCorteItemClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PlanoCorteItemClass), Convert.ToInt32(read["id_plano_corte_item"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PlanoCorteItemClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_plano_corte_item"]);
                     if (read["id_plano_corte"] != DBNull.Value)
                     {
                        entidade.PlanoCorte = (BibliotecaEntidades.Entidades.PlanoCorteClass)BibliotecaEntidades.Entidades.PlanoCorteClass.GetEntidade(Convert.ToInt32(read["id_plano_corte"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PlanoCorte = null ;
                     }
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     entidade.Quantidade = (double)read["pci_quantidade"];
                     if (read["id_dimensao_1"] != DBNull.Value)
                     {
                        entidade.Dimensao1 = (BibliotecaEntidades.Entidades.DimensaoClass)BibliotecaEntidades.Entidades.DimensaoClass.GetEntidade(Convert.ToInt32(read["id_dimensao_1"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Dimensao1 = null ;
                     }
                     entidade.Dimensao1Valor = (read["pci_dimensao_1_valor"] != DBNull.Value ? read["pci_dimensao_1_valor"].ToString() : null);
                     if (read["id_dimensao_2"] != DBNull.Value)
                     {
                        entidade.Dimensao2 = (BibliotecaEntidades.Entidades.DimensaoClass)BibliotecaEntidades.Entidades.DimensaoClass.GetEntidade(Convert.ToInt32(read["id_dimensao_2"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Dimensao2 = null ;
                     }
                     entidade.Dimensao2Valor = (read["pci_dimensao_2_valor"] != DBNull.Value ? read["pci_dimensao_2_valor"].ToString() : null);
                     if (read["id_dimensao_3"] != DBNull.Value)
                     {
                        entidade.Dimensao3 = (BibliotecaEntidades.Entidades.DimensaoClass)BibliotecaEntidades.Entidades.DimensaoClass.GetEntidade(Convert.ToInt32(read["id_dimensao_3"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Dimensao3 = null ;
                     }
                     entidade.Dimensao3Valor = (read["pci_dimensao_3_valor"] != DBNull.Value ? read["pci_dimensao_3_valor"].ToString() : null);
                     entidade.InformacoesAdicionais = (read["pci_informacoes_adicionais"] != DBNull.Value ? read["pci_informacoes_adicionais"].ToString() : null);
                     if (read["id_posto_trabalho_corte"] != DBNull.Value)
                     {
                        entidade.PostoTrabalhoCorte = (BibliotecaEntidades.Entidades.PostoTrabalhoClass)BibliotecaEntidades.Entidades.PostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_posto_trabalho_corte"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PostoTrabalhoCorte = null ;
                     }
                     entidade.MaterialCodigo = (read["pci_material_codigo"] != DBNull.Value ? read["pci_material_codigo"].ToString() : null);
                     entidade.MaterialFamilia = (read["pci_material_familia"] != DBNull.Value ? read["pci_material_familia"].ToString() : null);
                     entidade.MaterialAgrupador = (read["pci_material_agrupador"] != DBNull.Value ? read["pci_material_agrupador"].ToString() : null);
                     entidade.PostoNome = (read["pci_posto_nome"] != DBNull.Value ? read["pci_posto_nome"].ToString() : null);
                     entidade.PostoDescricao = (read["pci_posto_descricao"] != DBNull.Value ? read["pci_posto_descricao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_unidade_medida_1"] != DBNull.Value)
                     {
                        entidade.UnidadeMedida1 = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_1"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedida1 = null ;
                     }
                     if (read["id_unidade_medida_2"] != DBNull.Value)
                     {
                        entidade.UnidadeMedida2 = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_2"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedida2 = null ;
                     }
                     if (read["id_unidade_medida_3"] != DBNull.Value)
                     {
                        entidade.UnidadeMedida3 = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_3"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedida3 = null ;
                     }
                     entidade.Cancelado = Convert.ToBoolean(Convert.ToInt16(read["pci_cancelado"]));
                     entidade.CancelamentoJustificativa = (read["pci_cancelamento_justificativa"] != DBNull.Value ? read["pci_cancelamento_justificativa"].ToString() : null);
                     entidade.CancelamentoData = read["pci_cancelamento_data"] as DateTime?;
                     if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioCancelamento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioCancelamento = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PlanoCorteItemClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
