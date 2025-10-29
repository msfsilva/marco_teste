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
     [Table("ncm","ncm")]
     public class NcmBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NcmClass";
protected const string ErroDelete = "Erro ao excluir o NcmClass  ";
protected const string ErroSave = "Erro ao salvar o NcmClass.";
protected const string ErroCollectionAliquotaFundoCombatePobrezaClassNcm = "Erro ao carregar a coleção de AliquotaFundoCombatePobrezaClass.";
protected const string ErroCollectionMaterialFiscalClassNcm = "Erro ao carregar a coleção de MaterialFiscalClass.";
protected const string ErroCollectionNcmBeneficioFiscalClassNcm = "Erro ao carregar a coleção de NcmBeneficioFiscalClass.";
protected const string ErroCollectionObservacaoAdicionalNfeClassNcm = "Erro ao carregar a coleção de ObservacaoAdicionalNfeClass.";
protected const string ErroCollectionOrcamentoItemClassNcm = "Erro ao carregar a coleção de OrcamentoItemClass.";
protected const string ErroCollectionPedidoItemClassNcm = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionProdutoFiscalClassNcm = "Erro ao carregar a coleção de ProdutoFiscalClass.";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 8 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroIpiCodigoEnquadramentoObrigatorio = "O campo IpiCodigoEnquadramento é obrigatório";
protected const string ErroIpiCodigoEnquadramentoComprimento = "O campo IpiCodigoEnquadramento deve ter no máximo 3 caracteres";
protected const string ErroIpiCstObrigatorio = "O campo IpiCst é obrigatório";
protected const string ErroIpiCstComprimento = "O campo IpiCst deve ter no máximo 2 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do NcmClass.";
protected const string MensagemUtilizadoCollectionAliquotaFundoCombatePobrezaClassNcm =  "A entidade NcmClass está sendo utilizada nos seguintes AliquotaFundoCombatePobrezaClass:";
protected const string MensagemUtilizadoCollectionMaterialFiscalClassNcm =  "A entidade NcmClass está sendo utilizada nos seguintes MaterialFiscalClass:";
protected const string MensagemUtilizadoCollectionNcmBeneficioFiscalClassNcm =  "A entidade NcmClass está sendo utilizada nos seguintes NcmBeneficioFiscalClass:";
protected const string MensagemUtilizadoCollectionObservacaoAdicionalNfeClassNcm =  "A entidade NcmClass está sendo utilizada nos seguintes ObservacaoAdicionalNfeClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemClassNcm =  "A entidade NcmClass está sendo utilizada nos seguintes OrcamentoItemClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassNcm =  "A entidade NcmClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionProdutoFiscalClassNcm =  "A entidade NcmClass está sendo utilizada nos seguintes ProdutoFiscalClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NcmClass está sendo utilizada.";
#endregion
       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("ncm_codigo")]
        public virtual string Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("ncm_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected string _ipiCodigoEnquadramentoOriginal{get;private set;}
       private string _ipiCodigoEnquadramentoOriginalCommited{get; set;}
        private string _valueIpiCodigoEnquadramento;
         [Column("ncm_ipi_codigo_enquadramento")]
        public virtual string IpiCodigoEnquadramento
         { 
            get { return this._valueIpiCodigoEnquadramento; } 
            set 
            { 
                if (this._valueIpiCodigoEnquadramento == value)return;
                 this._valueIpiCodigoEnquadramento = value; 
            } 
        } 

       protected string _ipiCstOriginal{get;private set;}
       private string _ipiCstOriginalCommited{get; set;}
        private string _valueIpiCst;
         [Column("ncm_ipi_cst")]
        public virtual string IpiCst
         { 
            get { return this._valueIpiCst; } 
            set 
            { 
                if (this._valueIpiCst == value)return;
                 this._valueIpiCst = value; 
            } 
        } 

       protected double _ipiAliquotaOriginal{get;private set;}
       private double _ipiAliquotaOriginalCommited{get; set;}
        private double _valueIpiAliquota;
         [Column("ncm_ipi_aliquota")]
        public virtual double IpiAliquota
         { 
            get { return this._valueIpiAliquota; } 
            set 
            { 
                if (this._valueIpiAliquota == value)return;
                 this._valueIpiAliquota = value; 
            } 
        } 

       protected int _ipiModalidadeTributacaoOriginal{get;private set;}
       private int _ipiModalidadeTributacaoOriginalCommited{get; set;}
        private int _valueIpiModalidadeTributacao;
         [Column("ncm_ipi_modalidade_tributacao")]
        public virtual int IpiModalidadeTributacao
         { 
            get { return this._valueIpiModalidadeTributacao; } 
            set 
            { 
                if (this._valueIpiModalidadeTributacao == value)return;
                 this._valueIpiModalidadeTributacao = value; 
            } 
        } 

       protected double _iiAliquotaOriginal{get;private set;}
       private double _iiAliquotaOriginalCommited{get; set;}
        private double _valueIiAliquota;
         [Column("ncm_ii_aliquota")]
        public virtual double IiAliquota
         { 
            get { return this._valueIiAliquota; } 
            set 
            { 
                if (this._valueIiAliquota == value)return;
                 this._valueIiAliquota = value; 
            } 
        } 

       protected string _cestOriginal{get;private set;}
       private string _cestOriginalCommited{get; set;}
        private string _valueCest;
         [Column("ncm_cest")]
        public virtual string Cest
         { 
            get { return this._valueCest; } 
            set 
            { 
                if (this._valueCest == value)return;
                 this._valueCest = value; 
            } 
        } 

       private List<long> _collectionAliquotaFundoCombatePobrezaClassNcmOriginal;
       private List<Entidades.AliquotaFundoCombatePobrezaClass > _collectionAliquotaFundoCombatePobrezaClassNcmRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAliquotaFundoCombatePobrezaClassNcmChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAliquotaFundoCombatePobrezaClassNcmCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.AliquotaFundoCombatePobrezaClass> _valueCollectionAliquotaFundoCombatePobrezaClassNcm { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.AliquotaFundoCombatePobrezaClass> CollectionAliquotaFundoCombatePobrezaClassNcm 
       { 
           get { if(!_valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded && !this.DisableLoadCollection){this.LoadCollectionAliquotaFundoCombatePobrezaClassNcm();}
return this._valueCollectionAliquotaFundoCombatePobrezaClassNcm; } 
           set 
           { 
               this._valueCollectionAliquotaFundoCombatePobrezaClassNcm = value; 
               this._valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded = true; 
           } 
       } 

       private List<long> _collectionMaterialFiscalClassNcmOriginal;
       private List<Entidades.MaterialFiscalClass > _collectionMaterialFiscalClassNcmRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFiscalClassNcmLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFiscalClassNcmChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFiscalClassNcmCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialFiscalClass> _valueCollectionMaterialFiscalClassNcm { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialFiscalClass> CollectionMaterialFiscalClassNcm 
       { 
           get { if(!_valueCollectionMaterialFiscalClassNcmLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialFiscalClassNcm();}
return this._valueCollectionMaterialFiscalClassNcm; } 
           set 
           { 
               this._valueCollectionMaterialFiscalClassNcm = value; 
               this._valueCollectionMaterialFiscalClassNcmLoaded = true; 
           } 
       } 

       private List<long> _collectionNcmBeneficioFiscalClassNcmOriginal;
       private List<Entidades.NcmBeneficioFiscalClass > _collectionNcmBeneficioFiscalClassNcmRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNcmBeneficioFiscalClassNcmLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNcmBeneficioFiscalClassNcmChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNcmBeneficioFiscalClassNcmCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NcmBeneficioFiscalClass> _valueCollectionNcmBeneficioFiscalClassNcm { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NcmBeneficioFiscalClass> CollectionNcmBeneficioFiscalClassNcm 
       { 
           get { if(!_valueCollectionNcmBeneficioFiscalClassNcmLoaded && !this.DisableLoadCollection){this.LoadCollectionNcmBeneficioFiscalClassNcm();}
return this._valueCollectionNcmBeneficioFiscalClassNcm; } 
           set 
           { 
               this._valueCollectionNcmBeneficioFiscalClassNcm = value; 
               this._valueCollectionNcmBeneficioFiscalClassNcmLoaded = true; 
           } 
       } 

       private List<long> _collectionObservacaoAdicionalNfeClassNcmOriginal;
       private List<Entidades.ObservacaoAdicionalNfeClass > _collectionObservacaoAdicionalNfeClassNcmRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionObservacaoAdicionalNfeClassNcmLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionObservacaoAdicionalNfeClassNcmChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionObservacaoAdicionalNfeClassNcmCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ObservacaoAdicionalNfeClass> _valueCollectionObservacaoAdicionalNfeClassNcm { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ObservacaoAdicionalNfeClass> CollectionObservacaoAdicionalNfeClassNcm 
       { 
           get { if(!_valueCollectionObservacaoAdicionalNfeClassNcmLoaded && !this.DisableLoadCollection){this.LoadCollectionObservacaoAdicionalNfeClassNcm();}
return this._valueCollectionObservacaoAdicionalNfeClassNcm; } 
           set 
           { 
               this._valueCollectionObservacaoAdicionalNfeClassNcm = value; 
               this._valueCollectionObservacaoAdicionalNfeClassNcmLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemClassNcmOriginal;
       private List<Entidades.OrcamentoItemClass > _collectionOrcamentoItemClassNcmRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassNcmLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassNcmChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassNcmCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemClass> _valueCollectionOrcamentoItemClassNcm { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemClass> CollectionOrcamentoItemClassNcm 
       { 
           get { if(!_valueCollectionOrcamentoItemClassNcmLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemClassNcm();}
return this._valueCollectionOrcamentoItemClassNcm; } 
           set 
           { 
               this._valueCollectionOrcamentoItemClassNcm = value; 
               this._valueCollectionOrcamentoItemClassNcmLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassNcmOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassNcmRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassNcmLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassNcmChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassNcmCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassNcm { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassNcm 
       { 
           get { if(!_valueCollectionPedidoItemClassNcmLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassNcm();}
return this._valueCollectionPedidoItemClassNcm; } 
           set 
           { 
               this._valueCollectionPedidoItemClassNcm = value; 
               this._valueCollectionPedidoItemClassNcmLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoFiscalClassNcmOriginal;
       private List<Entidades.ProdutoFiscalClass > _collectionProdutoFiscalClassNcmRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFiscalClassNcmLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFiscalClassNcmChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFiscalClassNcmCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoFiscalClass> _valueCollectionProdutoFiscalClassNcm { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoFiscalClass> CollectionProdutoFiscalClassNcm 
       { 
           get { if(!_valueCollectionProdutoFiscalClassNcmLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoFiscalClassNcm();}
return this._valueCollectionProdutoFiscalClassNcm; } 
           set 
           { 
               this._valueCollectionProdutoFiscalClassNcm = value; 
               this._valueCollectionProdutoFiscalClassNcmLoaded = true; 
           } 
       } 

        public NcmBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.IpiCodigoEnquadramento = "999";
           this.IpiAliquota = 0;
           this.IiAliquota = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NcmClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NcmClass) GetEntity(typeof(NcmClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionAliquotaFundoCombatePobrezaClassNcmChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionAliquotaFundoCombatePobrezaClassNcmChanged = true;
                  _valueCollectionAliquotaFundoCombatePobrezaClassNcmCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionAliquotaFundoCombatePobrezaClassNcmChanged = true; 
                  _valueCollectionAliquotaFundoCombatePobrezaClassNcmCommitedChanged = true;
                 foreach (Entidades.AliquotaFundoCombatePobrezaClass item in e.OldItems) 
                 { 
                     _collectionAliquotaFundoCombatePobrezaClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionAliquotaFundoCombatePobrezaClassNcmChanged = true; 
                  _valueCollectionAliquotaFundoCombatePobrezaClassNcmCommitedChanged = true;
                 foreach (Entidades.AliquotaFundoCombatePobrezaClass item in _valueCollectionAliquotaFundoCombatePobrezaClassNcm) 
                 { 
                     _collectionAliquotaFundoCombatePobrezaClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionAliquotaFundoCombatePobrezaClassNcm()
         {
            try
            {
                 ObservableCollection<Entidades.AliquotaFundoCombatePobrezaClass> oc;
                _valueCollectionAliquotaFundoCombatePobrezaClassNcmChanged = false;
                 _valueCollectionAliquotaFundoCombatePobrezaClassNcmCommitedChanged = false;
                _collectionAliquotaFundoCombatePobrezaClassNcmRemovidos = new List<Entidades.AliquotaFundoCombatePobrezaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.AliquotaFundoCombatePobrezaClass>();
                }
                else{ 
                   Entidades.AliquotaFundoCombatePobrezaClass search = new Entidades.AliquotaFundoCombatePobrezaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.AliquotaFundoCombatePobrezaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Ncm", this),                     }                       ).Cast<Entidades.AliquotaFundoCombatePobrezaClass>().ToList());
                 }
                 _valueCollectionAliquotaFundoCombatePobrezaClassNcm = new BindingList<Entidades.AliquotaFundoCombatePobrezaClass>(oc); 
                 _collectionAliquotaFundoCombatePobrezaClassNcmOriginal= (from a in _valueCollectionAliquotaFundoCombatePobrezaClassNcm select a.ID).ToList();
                 _valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded = true;
                 oc.CollectionChanged += CollectionAliquotaFundoCombatePobrezaClassNcmChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionAliquotaFundoCombatePobrezaClassNcm+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMaterialFiscalClassNcmChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialFiscalClassNcmChanged = true;
                  _valueCollectionMaterialFiscalClassNcmCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialFiscalClassNcmChanged = true; 
                  _valueCollectionMaterialFiscalClassNcmCommitedChanged = true;
                 foreach (Entidades.MaterialFiscalClass item in e.OldItems) 
                 { 
                     _collectionMaterialFiscalClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialFiscalClassNcmChanged = true; 
                  _valueCollectionMaterialFiscalClassNcmCommitedChanged = true;
                 foreach (Entidades.MaterialFiscalClass item in _valueCollectionMaterialFiscalClassNcm) 
                 { 
                     _collectionMaterialFiscalClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialFiscalClassNcm()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialFiscalClass> oc;
                _valueCollectionMaterialFiscalClassNcmChanged = false;
                 _valueCollectionMaterialFiscalClassNcmCommitedChanged = false;
                _collectionMaterialFiscalClassNcmRemovidos = new List<Entidades.MaterialFiscalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialFiscalClass>();
                }
                else{ 
                   Entidades.MaterialFiscalClass search = new Entidades.MaterialFiscalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialFiscalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Ncm", this),                     }                       ).Cast<Entidades.MaterialFiscalClass>().ToList());
                 }
                 _valueCollectionMaterialFiscalClassNcm = new BindingList<Entidades.MaterialFiscalClass>(oc); 
                 _collectionMaterialFiscalClassNcmOriginal= (from a in _valueCollectionMaterialFiscalClassNcm select a.ID).ToList();
                 _valueCollectionMaterialFiscalClassNcmLoaded = true;
                 oc.CollectionChanged += CollectionMaterialFiscalClassNcmChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialFiscalClassNcm+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNcmBeneficioFiscalClassNcmChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNcmBeneficioFiscalClassNcmChanged = true;
                  _valueCollectionNcmBeneficioFiscalClassNcmCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNcmBeneficioFiscalClassNcmChanged = true; 
                  _valueCollectionNcmBeneficioFiscalClassNcmCommitedChanged = true;
                 foreach (Entidades.NcmBeneficioFiscalClass item in e.OldItems) 
                 { 
                     _collectionNcmBeneficioFiscalClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNcmBeneficioFiscalClassNcmChanged = true; 
                  _valueCollectionNcmBeneficioFiscalClassNcmCommitedChanged = true;
                 foreach (Entidades.NcmBeneficioFiscalClass item in _valueCollectionNcmBeneficioFiscalClassNcm) 
                 { 
                     _collectionNcmBeneficioFiscalClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNcmBeneficioFiscalClassNcm()
         {
            try
            {
                 ObservableCollection<Entidades.NcmBeneficioFiscalClass> oc;
                _valueCollectionNcmBeneficioFiscalClassNcmChanged = false;
                 _valueCollectionNcmBeneficioFiscalClassNcmCommitedChanged = false;
                _collectionNcmBeneficioFiscalClassNcmRemovidos = new List<Entidades.NcmBeneficioFiscalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NcmBeneficioFiscalClass>();
                }
                else{ 
                   Entidades.NcmBeneficioFiscalClass search = new Entidades.NcmBeneficioFiscalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NcmBeneficioFiscalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Ncm", this),                     }                       ).Cast<Entidades.NcmBeneficioFiscalClass>().ToList());
                 }
                 _valueCollectionNcmBeneficioFiscalClassNcm = new BindingList<Entidades.NcmBeneficioFiscalClass>(oc); 
                 _collectionNcmBeneficioFiscalClassNcmOriginal= (from a in _valueCollectionNcmBeneficioFiscalClassNcm select a.ID).ToList();
                 _valueCollectionNcmBeneficioFiscalClassNcmLoaded = true;
                 oc.CollectionChanged += CollectionNcmBeneficioFiscalClassNcmChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNcmBeneficioFiscalClassNcm+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionObservacaoAdicionalNfeClassNcmChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionObservacaoAdicionalNfeClassNcmChanged = true;
                  _valueCollectionObservacaoAdicionalNfeClassNcmCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionObservacaoAdicionalNfeClassNcmChanged = true; 
                  _valueCollectionObservacaoAdicionalNfeClassNcmCommitedChanged = true;
                 foreach (Entidades.ObservacaoAdicionalNfeClass item in e.OldItems) 
                 { 
                     _collectionObservacaoAdicionalNfeClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionObservacaoAdicionalNfeClassNcmChanged = true; 
                  _valueCollectionObservacaoAdicionalNfeClassNcmCommitedChanged = true;
                 foreach (Entidades.ObservacaoAdicionalNfeClass item in _valueCollectionObservacaoAdicionalNfeClassNcm) 
                 { 
                     _collectionObservacaoAdicionalNfeClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionObservacaoAdicionalNfeClassNcm()
         {
            try
            {
                 ObservableCollection<Entidades.ObservacaoAdicionalNfeClass> oc;
                _valueCollectionObservacaoAdicionalNfeClassNcmChanged = false;
                 _valueCollectionObservacaoAdicionalNfeClassNcmCommitedChanged = false;
                _collectionObservacaoAdicionalNfeClassNcmRemovidos = new List<Entidades.ObservacaoAdicionalNfeClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ObservacaoAdicionalNfeClass>();
                }
                else{ 
                   Entidades.ObservacaoAdicionalNfeClass search = new Entidades.ObservacaoAdicionalNfeClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ObservacaoAdicionalNfeClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Ncm", this)                    }                       ).Cast<Entidades.ObservacaoAdicionalNfeClass>().ToList());
                 }
                 _valueCollectionObservacaoAdicionalNfeClassNcm = new BindingList<Entidades.ObservacaoAdicionalNfeClass>(oc); 
                 _collectionObservacaoAdicionalNfeClassNcmOriginal= (from a in _valueCollectionObservacaoAdicionalNfeClassNcm select a.ID).ToList();
                 _valueCollectionObservacaoAdicionalNfeClassNcmLoaded = true;
                 oc.CollectionChanged += CollectionObservacaoAdicionalNfeClassNcmChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionObservacaoAdicionalNfeClassNcm+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemClassNcmChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemClassNcmChanged = true;
                  _valueCollectionOrcamentoItemClassNcmCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemClassNcmChanged = true; 
                  _valueCollectionOrcamentoItemClassNcmCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemClassNcmChanged = true; 
                  _valueCollectionOrcamentoItemClassNcmCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in _valueCollectionOrcamentoItemClassNcm) 
                 { 
                     _collectionOrcamentoItemClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemClassNcm()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemClass> oc;
                _valueCollectionOrcamentoItemClassNcmChanged = false;
                 _valueCollectionOrcamentoItemClassNcmCommitedChanged = false;
                _collectionOrcamentoItemClassNcmRemovidos = new List<Entidades.OrcamentoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemClass>();
                }
                else{ 
                   Entidades.OrcamentoItemClass search = new Entidades.OrcamentoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Ncm", this),                     }                       ).Cast<Entidades.OrcamentoItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemClassNcm = new BindingList<Entidades.OrcamentoItemClass>(oc); 
                 _collectionOrcamentoItemClassNcmOriginal= (from a in _valueCollectionOrcamentoItemClassNcm select a.ID).ToList();
                 _valueCollectionOrcamentoItemClassNcmLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemClassNcmChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemClassNcm+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassNcmChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassNcmChanged = true;
                  _valueCollectionPedidoItemClassNcmCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassNcmChanged = true; 
                  _valueCollectionPedidoItemClassNcmCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassNcmChanged = true; 
                  _valueCollectionPedidoItemClassNcmCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassNcm) 
                 { 
                     _collectionPedidoItemClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassNcm()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassNcmChanged = false;
                 _valueCollectionPedidoItemClassNcmCommitedChanged = false;
                _collectionPedidoItemClassNcmRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Ncm", this)                    }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassNcm = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassNcmOriginal= (from a in _valueCollectionPedidoItemClassNcm select a.ID).ToList();
                 _valueCollectionPedidoItemClassNcmLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassNcmChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassNcm+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoFiscalClassNcmChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoFiscalClassNcmChanged = true;
                  _valueCollectionProdutoFiscalClassNcmCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoFiscalClassNcmChanged = true; 
                  _valueCollectionProdutoFiscalClassNcmCommitedChanged = true;
                 foreach (Entidades.ProdutoFiscalClass item in e.OldItems) 
                 { 
                     _collectionProdutoFiscalClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoFiscalClassNcmChanged = true; 
                  _valueCollectionProdutoFiscalClassNcmCommitedChanged = true;
                 foreach (Entidades.ProdutoFiscalClass item in _valueCollectionProdutoFiscalClassNcm) 
                 { 
                     _collectionProdutoFiscalClassNcmRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoFiscalClassNcm()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoFiscalClass> oc;
                _valueCollectionProdutoFiscalClassNcmChanged = false;
                 _valueCollectionProdutoFiscalClassNcmCommitedChanged = false;
                _collectionProdutoFiscalClassNcmRemovidos = new List<Entidades.ProdutoFiscalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoFiscalClass>();
                }
                else{ 
                   Entidades.ProdutoFiscalClass search = new Entidades.ProdutoFiscalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoFiscalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Ncm", this),                     }                       ).Cast<Entidades.ProdutoFiscalClass>().ToList());
                 }
                 _valueCollectionProdutoFiscalClassNcm = new BindingList<Entidades.ProdutoFiscalClass>(oc); 
                 _collectionProdutoFiscalClassNcmOriginal= (from a in _valueCollectionProdutoFiscalClassNcm select a.ID).ToList();
                 _valueCollectionProdutoFiscalClassNcmLoaded = true;
                 oc.CollectionChanged += CollectionProdutoFiscalClassNcmChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoFiscalClassNcm+"\r\n" + e.Message, e);
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
                if (Codigo.Length >8)
                {
                    throw new Exception( ErroCodigoComprimento);
                }
                if (string.IsNullOrEmpty(Descricao))
                {
                    throw new Exception(ErroDescricaoObrigatorio);
                }
                if (Descricao.Length >255)
                {
                    throw new Exception( ErroDescricaoComprimento);
                }
                if (string.IsNullOrEmpty(IpiCodigoEnquadramento))
                {
                    throw new Exception(ErroIpiCodigoEnquadramentoObrigatorio);
                }
                if (IpiCodigoEnquadramento.Length >3)
                {
                    throw new Exception( ErroIpiCodigoEnquadramentoComprimento);
                }
                if (string.IsNullOrEmpty(IpiCst))
                {
                    throw new Exception(ErroIpiCstObrigatorio);
                }
                if (IpiCst.Length >2)
                {
                    throw new Exception( ErroIpiCstComprimento);
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
                    "  public.ncm  " +
                    "WHERE " +
                    "  id_ncm = :id";
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
                        "  public.ncm   " +
                        "SET  " + 
                        "  ncm_codigo = :ncm_codigo, " + 
                        "  ncm_descricao = :ncm_descricao, " + 
                        "  ncm_ipi_codigo_enquadramento = :ncm_ipi_codigo_enquadramento, " + 
                        "  ncm_ipi_cst = :ncm_ipi_cst, " + 
                        "  ncm_ipi_aliquota = :ncm_ipi_aliquota, " + 
                        "  ncm_ipi_modalidade_tributacao = :ncm_ipi_modalidade_tributacao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  ncm_ii_aliquota = :ncm_ii_aliquota, " + 
                        "  ncm_cest = :ncm_cest "+
                        "WHERE  " +
                        "  id_ncm = :id " +
                        "RETURNING id_ncm;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ncm " +
                        "( " +
                        "  ncm_codigo , " + 
                        "  ncm_descricao , " + 
                        "  ncm_ipi_codigo_enquadramento , " + 
                        "  ncm_ipi_cst , " + 
                        "  ncm_ipi_aliquota , " + 
                        "  ncm_ipi_modalidade_tributacao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  ncm_ii_aliquota , " + 
                        "  ncm_cest  "+
                        ")  " +
                        "VALUES ( " +
                        "  :ncm_codigo , " + 
                        "  :ncm_descricao , " + 
                        "  :ncm_ipi_codigo_enquadramento , " + 
                        "  :ncm_ipi_cst , " + 
                        "  :ncm_ipi_aliquota , " + 
                        "  :ncm_ipi_modalidade_tributacao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :ncm_ii_aliquota , " + 
                        "  :ncm_cest  "+
                        ")RETURNING id_ncm;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_ipi_codigo_enquadramento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiCodigoEnquadramento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_ipi_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_ipi_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_ipi_modalidade_tributacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiModalidadeTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_ii_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IiAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_cest", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cest ?? DBNull.Value;

 
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
 if (CollectionAliquotaFundoCombatePobrezaClassNcm.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionAliquotaFundoCombatePobrezaClassNcm+"\r\n";
                foreach (Entidades.AliquotaFundoCombatePobrezaClass tmp in CollectionAliquotaFundoCombatePobrezaClassNcm)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMaterialFiscalClassNcm.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialFiscalClassNcm+"\r\n";
                foreach (Entidades.MaterialFiscalClass tmp in CollectionMaterialFiscalClassNcm)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNcmBeneficioFiscalClassNcm.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNcmBeneficioFiscalClassNcm+"\r\n";
                foreach (Entidades.NcmBeneficioFiscalClass tmp in CollectionNcmBeneficioFiscalClassNcm)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionObservacaoAdicionalNfeClassNcm.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionObservacaoAdicionalNfeClassNcm+"\r\n";
                foreach (Entidades.ObservacaoAdicionalNfeClass tmp in CollectionObservacaoAdicionalNfeClassNcm)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemClassNcm.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassNcm+"\r\n";
                foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassNcm)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassNcm.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassNcm+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassNcm)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoFiscalClassNcm.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoFiscalClassNcm+"\r\n";
                foreach (Entidades.ProdutoFiscalClass tmp in CollectionProdutoFiscalClassNcm)
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
        public static NcmClass CopiarEntidade(NcmClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NcmClass toRet = new NcmClass(usuario,conn);
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.IpiCodigoEnquadramento= entidadeCopiar.IpiCodigoEnquadramento;
 toRet.IpiCst= entidadeCopiar.IpiCst;
 toRet.IpiAliquota= entidadeCopiar.IpiAliquota;
 toRet.IpiModalidadeTributacao= entidadeCopiar.IpiModalidadeTributacao;
 toRet.IiAliquota= entidadeCopiar.IiAliquota;
 toRet.Cest= entidadeCopiar.Cest;

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
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _ipiCodigoEnquadramentoOriginal = IpiCodigoEnquadramento;
       _ipiCodigoEnquadramentoOriginalCommited = _ipiCodigoEnquadramentoOriginal;
       _ipiCstOriginal = IpiCst;
       _ipiCstOriginalCommited = _ipiCstOriginal;
       _ipiAliquotaOriginal = IpiAliquota;
       _ipiAliquotaOriginalCommited = _ipiAliquotaOriginal;
       _ipiModalidadeTributacaoOriginal = IpiModalidadeTributacao;
       _ipiModalidadeTributacaoOriginalCommited = _ipiModalidadeTributacaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _iiAliquotaOriginal = IiAliquota;
       _iiAliquotaOriginalCommited = _iiAliquotaOriginal;
       _cestOriginal = Cest;
       _cestOriginalCommited = _cestOriginal;

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
       _descricaoOriginalCommited = Descricao;
       _ipiCodigoEnquadramentoOriginalCommited = IpiCodigoEnquadramento;
       _ipiCstOriginalCommited = IpiCst;
       _ipiAliquotaOriginalCommited = IpiAliquota;
       _ipiModalidadeTributacaoOriginalCommited = IpiModalidadeTributacao;
       _versionOriginalCommited = Version;
       _iiAliquotaOriginalCommited = IiAliquota;
       _cestOriginalCommited = Cest;

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
               if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded) 
               {
                  if (_collectionAliquotaFundoCombatePobrezaClassNcmRemovidos != null) 
                  {
                     _collectionAliquotaFundoCombatePobrezaClassNcmRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionAliquotaFundoCombatePobrezaClassNcmRemovidos = new List<Entidades.AliquotaFundoCombatePobrezaClass>();
                  }
                  _collectionAliquotaFundoCombatePobrezaClassNcmOriginal= (from a in _valueCollectionAliquotaFundoCombatePobrezaClassNcm select a.ID).ToList();
                  _valueCollectionAliquotaFundoCombatePobrezaClassNcmChanged = false;
                  _valueCollectionAliquotaFundoCombatePobrezaClassNcmCommitedChanged = false;
               }
               if (_valueCollectionMaterialFiscalClassNcmLoaded) 
               {
                  if (_collectionMaterialFiscalClassNcmRemovidos != null) 
                  {
                     _collectionMaterialFiscalClassNcmRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialFiscalClassNcmRemovidos = new List<Entidades.MaterialFiscalClass>();
                  }
                  _collectionMaterialFiscalClassNcmOriginal= (from a in _valueCollectionMaterialFiscalClassNcm select a.ID).ToList();
                  _valueCollectionMaterialFiscalClassNcmChanged = false;
                  _valueCollectionMaterialFiscalClassNcmCommitedChanged = false;
               }
               if (_valueCollectionNcmBeneficioFiscalClassNcmLoaded) 
               {
                  if (_collectionNcmBeneficioFiscalClassNcmRemovidos != null) 
                  {
                     _collectionNcmBeneficioFiscalClassNcmRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNcmBeneficioFiscalClassNcmRemovidos = new List<Entidades.NcmBeneficioFiscalClass>();
                  }
                  _collectionNcmBeneficioFiscalClassNcmOriginal= (from a in _valueCollectionNcmBeneficioFiscalClassNcm select a.ID).ToList();
                  _valueCollectionNcmBeneficioFiscalClassNcmChanged = false;
                  _valueCollectionNcmBeneficioFiscalClassNcmCommitedChanged = false;
               }
               if (_valueCollectionObservacaoAdicionalNfeClassNcmLoaded) 
               {
                  if (_collectionObservacaoAdicionalNfeClassNcmRemovidos != null) 
                  {
                     _collectionObservacaoAdicionalNfeClassNcmRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionObservacaoAdicionalNfeClassNcmRemovidos = new List<Entidades.ObservacaoAdicionalNfeClass>();
                  }
                  _collectionObservacaoAdicionalNfeClassNcmOriginal= (from a in _valueCollectionObservacaoAdicionalNfeClassNcm select a.ID).ToList();
                  _valueCollectionObservacaoAdicionalNfeClassNcmChanged = false;
                  _valueCollectionObservacaoAdicionalNfeClassNcmCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemClassNcmLoaded) 
               {
                  if (_collectionOrcamentoItemClassNcmRemovidos != null) 
                  {
                     _collectionOrcamentoItemClassNcmRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemClassNcmRemovidos = new List<Entidades.OrcamentoItemClass>();
                  }
                  _collectionOrcamentoItemClassNcmOriginal= (from a in _valueCollectionOrcamentoItemClassNcm select a.ID).ToList();
                  _valueCollectionOrcamentoItemClassNcmChanged = false;
                  _valueCollectionOrcamentoItemClassNcmCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassNcmLoaded) 
               {
                  if (_collectionPedidoItemClassNcmRemovidos != null) 
                  {
                     _collectionPedidoItemClassNcmRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassNcmRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassNcmOriginal= (from a in _valueCollectionPedidoItemClassNcm select a.ID).ToList();
                  _valueCollectionPedidoItemClassNcmChanged = false;
                  _valueCollectionPedidoItemClassNcmCommitedChanged = false;
               }
               if (_valueCollectionProdutoFiscalClassNcmLoaded) 
               {
                  if (_collectionProdutoFiscalClassNcmRemovidos != null) 
                  {
                     _collectionProdutoFiscalClassNcmRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoFiscalClassNcmRemovidos = new List<Entidades.ProdutoFiscalClass>();
                  }
                  _collectionProdutoFiscalClassNcmOriginal= (from a in _valueCollectionProdutoFiscalClassNcm select a.ID).ToList();
                  _valueCollectionProdutoFiscalClassNcmChanged = false;
                  _valueCollectionProdutoFiscalClassNcmCommitedChanged = false;
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
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               IpiCodigoEnquadramento=_ipiCodigoEnquadramentoOriginal;
               _ipiCodigoEnquadramentoOriginalCommited=_ipiCodigoEnquadramentoOriginal;
               IpiCst=_ipiCstOriginal;
               _ipiCstOriginalCommited=_ipiCstOriginal;
               IpiAliquota=_ipiAliquotaOriginal;
               _ipiAliquotaOriginalCommited=_ipiAliquotaOriginal;
               IpiModalidadeTributacao=_ipiModalidadeTributacaoOriginal;
               _ipiModalidadeTributacaoOriginalCommited=_ipiModalidadeTributacaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               IiAliquota=_iiAliquotaOriginal;
               _iiAliquotaOriginalCommited=_iiAliquotaOriginal;
               Cest=_cestOriginal;
               _cestOriginalCommited=_cestOriginal;
               if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded) 
               {
                  CollectionAliquotaFundoCombatePobrezaClassNcm.Clear();
                  foreach(int item in _collectionAliquotaFundoCombatePobrezaClassNcmOriginal)
                  {
                    CollectionAliquotaFundoCombatePobrezaClassNcm.Add(Entidades.AliquotaFundoCombatePobrezaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionAliquotaFundoCombatePobrezaClassNcmRemovidos.Clear();
               }
               if (_valueCollectionMaterialFiscalClassNcmLoaded) 
               {
                  CollectionMaterialFiscalClassNcm.Clear();
                  foreach(int item in _collectionMaterialFiscalClassNcmOriginal)
                  {
                    CollectionMaterialFiscalClassNcm.Add(Entidades.MaterialFiscalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialFiscalClassNcmRemovidos.Clear();
               }
               if (_valueCollectionNcmBeneficioFiscalClassNcmLoaded) 
               {
                  CollectionNcmBeneficioFiscalClassNcm.Clear();
                  foreach(int item in _collectionNcmBeneficioFiscalClassNcmOriginal)
                  {
                    CollectionNcmBeneficioFiscalClassNcm.Add(Entidades.NcmBeneficioFiscalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNcmBeneficioFiscalClassNcmRemovidos.Clear();
               }
               if (_valueCollectionObservacaoAdicionalNfeClassNcmLoaded) 
               {
                  CollectionObservacaoAdicionalNfeClassNcm.Clear();
                  foreach(int item in _collectionObservacaoAdicionalNfeClassNcmOriginal)
                  {
                    CollectionObservacaoAdicionalNfeClassNcm.Add(Entidades.ObservacaoAdicionalNfeClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionObservacaoAdicionalNfeClassNcmRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemClassNcmLoaded) 
               {
                  CollectionOrcamentoItemClassNcm.Clear();
                  foreach(int item in _collectionOrcamentoItemClassNcmOriginal)
                  {
                    CollectionOrcamentoItemClassNcm.Add(Entidades.OrcamentoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemClassNcmRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassNcmLoaded) 
               {
                  CollectionPedidoItemClassNcm.Clear();
                  foreach(int item in _collectionPedidoItemClassNcmOriginal)
                  {
                    CollectionPedidoItemClassNcm.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassNcmRemovidos.Clear();
               }
               if (_valueCollectionProdutoFiscalClassNcmLoaded) 
               {
                  CollectionProdutoFiscalClassNcm.Clear();
                  foreach(int item in _collectionProdutoFiscalClassNcmOriginal)
                  {
                    CollectionProdutoFiscalClassNcm.Add(Entidades.ProdutoFiscalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoFiscalClassNcmRemovidos.Clear();
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
               if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded) 
               {
                  if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFiscalClassNcmLoaded) 
               {
                  if (_valueCollectionMaterialFiscalClassNcmChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNcmBeneficioFiscalClassNcmLoaded) 
               {
                  if (_valueCollectionNcmBeneficioFiscalClassNcmChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionObservacaoAdicionalNfeClassNcmLoaded) 
               {
                  if (_valueCollectionObservacaoAdicionalNfeClassNcmChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassNcmLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassNcmChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassNcmLoaded) 
               {
                  if (_valueCollectionPedidoItemClassNcmChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFiscalClassNcmLoaded) 
               {
                  if (_valueCollectionProdutoFiscalClassNcmChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded) 
               {
                   tempRet = CollectionAliquotaFundoCombatePobrezaClassNcm.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFiscalClassNcmLoaded) 
               {
                   tempRet = CollectionMaterialFiscalClassNcm.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNcmBeneficioFiscalClassNcmLoaded) 
               {
                   tempRet = CollectionNcmBeneficioFiscalClassNcm.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionObservacaoAdicionalNfeClassNcmLoaded) 
               {
                   tempRet = CollectionObservacaoAdicionalNfeClassNcm.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassNcmLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassNcm.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassNcmLoaded) 
               {
                   tempRet = CollectionPedidoItemClassNcm.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFiscalClassNcmLoaded) 
               {
                   tempRet = CollectionProdutoFiscalClassNcm.Any(item => item.IsDirty());
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
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _ipiCodigoEnquadramentoOriginal != IpiCodigoEnquadramento;
      if (dirty) return true;
       dirty = _ipiCstOriginal != IpiCst;
      if (dirty) return true;
       dirty = _ipiAliquotaOriginal != IpiAliquota;
      if (dirty) return true;
       dirty = _ipiModalidadeTributacaoOriginal != IpiModalidadeTributacao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _iiAliquotaOriginal != IiAliquota;
      if (dirty) return true;
       dirty = _cestOriginal != Cest;

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
               if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded) 
               {
                  if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFiscalClassNcmLoaded) 
               {
                  if (_valueCollectionMaterialFiscalClassNcmCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNcmBeneficioFiscalClassNcmLoaded) 
               {
                  if (_valueCollectionNcmBeneficioFiscalClassNcmCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionObservacaoAdicionalNfeClassNcmLoaded) 
               {
                  if (_valueCollectionObservacaoAdicionalNfeClassNcmCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassNcmLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassNcmCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassNcmLoaded) 
               {
                  if (_valueCollectionPedidoItemClassNcmCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFiscalClassNcmLoaded) 
               {
                  if (_valueCollectionProdutoFiscalClassNcmCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded) 
               {
                   tempRet = CollectionAliquotaFundoCombatePobrezaClassNcm.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFiscalClassNcmLoaded) 
               {
                   tempRet = CollectionMaterialFiscalClassNcm.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNcmBeneficioFiscalClassNcmLoaded) 
               {
                   tempRet = CollectionNcmBeneficioFiscalClassNcm.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionObservacaoAdicionalNfeClassNcmLoaded) 
               {
                   tempRet = CollectionObservacaoAdicionalNfeClassNcm.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassNcmLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassNcm.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassNcmLoaded) 
               {
                   tempRet = CollectionPedidoItemClassNcm.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFiscalClassNcmLoaded) 
               {
                   tempRet = CollectionProdutoFiscalClassNcm.Any(item => item.IsDirtyCommited());
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
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _ipiCodigoEnquadramentoOriginalCommited != IpiCodigoEnquadramento;
      if (dirty) return true;
       dirty = _ipiCstOriginalCommited != IpiCst;
      if (dirty) return true;
       dirty = _ipiAliquotaOriginalCommited != IpiAliquota;
      if (dirty) return true;
       dirty = _ipiModalidadeTributacaoOriginalCommited != IpiModalidadeTributacao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _iiAliquotaOriginalCommited != IiAliquota;
      if (dirty) return true;
       dirty = _cestOriginalCommited != Cest;

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
               if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded) 
               {
                  foreach(AliquotaFundoCombatePobrezaClass item in CollectionAliquotaFundoCombatePobrezaClassNcm)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMaterialFiscalClassNcmLoaded) 
               {
                  foreach(MaterialFiscalClass item in CollectionMaterialFiscalClassNcm)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNcmBeneficioFiscalClassNcmLoaded) 
               {
                  foreach(NcmBeneficioFiscalClass item in CollectionNcmBeneficioFiscalClassNcm)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionObservacaoAdicionalNfeClassNcmLoaded) 
               {
                  foreach(ObservacaoAdicionalNfeClass item in CollectionObservacaoAdicionalNfeClassNcm)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemClassNcmLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassNcm)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassNcmLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassNcm)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoFiscalClassNcmLoaded) 
               {
                  foreach(ProdutoFiscalClass item in CollectionProdutoFiscalClassNcm)
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
             case "Descricao":
                return this.Descricao;
             case "IpiCodigoEnquadramento":
                return this.IpiCodigoEnquadramento;
             case "IpiCst":
                return this.IpiCst;
             case "IpiAliquota":
                return this.IpiAliquota;
             case "IpiModalidadeTributacao":
                return this.IpiModalidadeTributacao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "IiAliquota":
                return this.IiAliquota;
             case "Cest":
                return this.Cest;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionAliquotaFundoCombatePobrezaClassNcmLoaded) 
               {
                  foreach(AliquotaFundoCombatePobrezaClass item in CollectionAliquotaFundoCombatePobrezaClassNcm)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMaterialFiscalClassNcmLoaded) 
               {
                  foreach(MaterialFiscalClass item in CollectionMaterialFiscalClassNcm)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNcmBeneficioFiscalClassNcmLoaded) 
               {
                  foreach(NcmBeneficioFiscalClass item in CollectionNcmBeneficioFiscalClassNcm)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionObservacaoAdicionalNfeClassNcmLoaded) 
               {
                  foreach(ObservacaoAdicionalNfeClass item in CollectionObservacaoAdicionalNfeClassNcm)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemClassNcmLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassNcm)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassNcmLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassNcm)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoFiscalClassNcmLoaded) 
               {
                  foreach(ProdutoFiscalClass item in CollectionProdutoFiscalClassNcm)
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
                  command.CommandText += " COUNT(ncm.id_ncm) " ;
               }
               else
               {
               command.CommandText += "ncm.id_ncm, " ;
               command.CommandText += "ncm.ncm_codigo, " ;
               command.CommandText += "ncm.ncm_descricao, " ;
               command.CommandText += "ncm.ncm_ipi_codigo_enquadramento, " ;
               command.CommandText += "ncm.ncm_ipi_cst, " ;
               command.CommandText += "ncm.ncm_ipi_aliquota, " ;
               command.CommandText += "ncm.ncm_ipi_modalidade_tributacao, " ;
               command.CommandText += "ncm.entity_uid, " ;
               command.CommandText += "ncm.version, " ;
               command.CommandText += "ncm.ncm_ii_aliquota, " ;
               command.CommandText += "ncm.ncm_cest " ;
               }
               command.CommandText += " FROM  ncm ";
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
                        orderByClause += " , ncm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ncm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ncm.id_acs_usuario_ultima_revisao ";
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
                     case "id_ncm":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ncm.id_ncm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ncm.id_ncm) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncm_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm.ncm_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm.ncm_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncm_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm.ncm_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm.ncm_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncm_ipi_codigo_enquadramento":
                     case "IpiCodigoEnquadramento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm.ncm_ipi_codigo_enquadramento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm.ncm_ipi_codigo_enquadramento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncm_ipi_cst":
                     case "IpiCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm.ncm_ipi_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm.ncm_ipi_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncm_ipi_aliquota":
                     case "IpiAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ncm.ncm_ipi_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ncm.ncm_ipi_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncm_ipi_modalidade_tributacao":
                     case "IpiModalidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ncm.ncm_ipi_modalidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ncm.ncm_ipi_modalidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ncm.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ncm.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncm_ii_aliquota":
                     case "IiAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ncm.ncm_ii_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ncm.ncm_ii_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncm_cest":
                     case "Cest":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm.ncm_cest " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm.ncm_cest) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncm_codigo")) 
                        {
                           whereClause += " OR UPPER(ncm.ncm_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ncm.ncm_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncm_descricao")) 
                        {
                           whereClause += " OR UPPER(ncm.ncm_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ncm.ncm_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncm_ipi_codigo_enquadramento")) 
                        {
                           whereClause += " OR UPPER(ncm.ncm_ipi_codigo_enquadramento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ncm.ncm_ipi_codigo_enquadramento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncm_ipi_cst")) 
                        {
                           whereClause += " OR UPPER(ncm.ncm_ipi_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ncm.ncm_ipi_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ncm.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ncm.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncm_cest")) 
                        {
                           whereClause += " OR UPPER(ncm.ncm_cest) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ncm.ncm_cest) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ncm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.id_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.id_ncm = :ncm_ID_2028 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_ID_2028", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "ncm_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_codigo LIKE :ncm_Codigo_8530 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_Codigo_8530", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "ncm_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_descricao LIKE :ncm_Descricao_5853 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_Descricao_5853", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCodigoEnquadramento" || parametro.FieldName == "ncm_ipi_codigo_enquadramento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_ipi_codigo_enquadramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_ipi_codigo_enquadramento LIKE :ncm_IpiCodigoEnquadramento_1177 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_IpiCodigoEnquadramento_1177", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCst" || parametro.FieldName == "ncm_ipi_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_ipi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_ipi_cst LIKE :ncm_IpiCst_1369 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_IpiCst_1369", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiAliquota" || parametro.FieldName == "ncm_ipi_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_ipi_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_ipi_aliquota = :ncm_IpiAliquota_3958 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_IpiAliquota_3958", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiModalidadeTributacao" || parametro.FieldName == "ncm_ipi_modalidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_ipi_modalidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_ipi_modalidade_tributacao = :ncm_IpiModalidadeTributacao_297 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_IpiModalidadeTributacao_297", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ncm.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.entity_uid LIKE :ncm_EntityUid_4699 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_EntityUid_4699", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ncm.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.version = :ncm_Version_7506 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_Version_7506", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IiAliquota" || parametro.FieldName == "ncm_ii_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_ii_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_ii_aliquota = :ncm_IiAliquota_5840 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_IiAliquota_5840", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cest" || parametro.FieldName == "ncm_cest")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_cest IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_cest LIKE :ncm_Cest_792 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_Cest_792", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ncm.ncm_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_codigo LIKE :ncm_Codigo_7383 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_Codigo_7383", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ncm.ncm_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_descricao LIKE :ncm_Descricao_6722 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_Descricao_6722", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCodigoEnquadramentoExato" || parametro.FieldName == "IpiCodigoEnquadramentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_ipi_codigo_enquadramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_ipi_codigo_enquadramento LIKE :ncm_IpiCodigoEnquadramento_339 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_IpiCodigoEnquadramento_339", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCstExato" || parametro.FieldName == "IpiCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_ipi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_ipi_cst LIKE :ncm_IpiCst_224 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_IpiCst_224", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ncm.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.entity_uid LIKE :ncm_EntityUid_1022 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_EntityUid_1022", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CestExato" || parametro.FieldName == "CestExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm.ncm_cest IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm.ncm_cest LIKE :ncm_Cest_8154 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_Cest_8154", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NcmClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NcmClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NcmClass), Convert.ToInt32(read["id_ncm"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NcmClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ncm"]);
                     entidade.Codigo = (read["ncm_codigo"] != DBNull.Value ? read["ncm_codigo"].ToString() : null);
                     entidade.Descricao = (read["ncm_descricao"] != DBNull.Value ? read["ncm_descricao"].ToString() : null);
                     entidade.IpiCodigoEnquadramento = (read["ncm_ipi_codigo_enquadramento"] != DBNull.Value ? read["ncm_ipi_codigo_enquadramento"].ToString() : null);
                     entidade.IpiCst = (read["ncm_ipi_cst"] != DBNull.Value ? read["ncm_ipi_cst"].ToString() : null);
                     entidade.IpiAliquota = (double)read["ncm_ipi_aliquota"];
                     entidade.IpiModalidadeTributacao = (int)read["ncm_ipi_modalidade_tributacao"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.IiAliquota = (double)read["ncm_ii_aliquota"];
                     entidade.Cest = (read["ncm_cest"] != DBNull.Value ? read["ncm_cest"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NcmClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
