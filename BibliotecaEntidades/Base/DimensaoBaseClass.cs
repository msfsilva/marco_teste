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
     [Table("dimensao","dim")]
     public class DimensaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DimensaoClass";
protected const string ErroDelete = "Erro ao excluir o DimensaoClass  ";
protected const string ErroSave = "Erro ao salvar o DimensaoClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1 = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2 = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3 = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPlanoCorteItemClassDimensao1 = "Erro ao carregar a coleção de PlanoCorteItemClass.";
protected const string ErroCollectionPlanoCorteItemClassDimensao2 = "Erro ao carregar a coleção de PlanoCorteItemClass.";
protected const string ErroCollectionPlanoCorteItemClassDimensao3 = "Erro ao carregar a coleção de PlanoCorteItemClass.";
protected const string ErroCollectionProdutoMaterialClassDimensao1 = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected const string ErroCollectionProdutoMaterialClassDimensao2 = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected const string ErroCollectionProdutoMaterialClassDimensao3 = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do DimensaoClass.";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1 =  "A entidade DimensaoClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2 =  "A entidade DimensaoClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3 =  "A entidade DimensaoClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemClassDimensao1 =  "A entidade DimensaoClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemClassDimensao2 =  "A entidade DimensaoClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemClassDimensao3 =  "A entidade DimensaoClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
protected const string MensagemUtilizadoCollectionProdutoMaterialClassDimensao1 =  "A entidade DimensaoClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected const string MensagemUtilizadoCollectionProdutoMaterialClassDimensao2 =  "A entidade DimensaoClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected const string MensagemUtilizadoCollectionProdutoMaterialClassDimensao3 =  "A entidade DimensaoClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DimensaoClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("dim_identificacao")]
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
         [Column("dim_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Original;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1 = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Original;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2 = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Original;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3 = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemClassDimensao1Original;
       private List<Entidades.PlanoCorteItemClass > _collectionPlanoCorteItemClassDimensao1Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassDimensao1Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassDimensao1Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassDimensao1CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemClass> _valueCollectionPlanoCorteItemClassDimensao1 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemClass> CollectionPlanoCorteItemClassDimensao1 
       { 
           get { if(!_valueCollectionPlanoCorteItemClassDimensao1Loaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemClassDimensao1();}
return this._valueCollectionPlanoCorteItemClassDimensao1; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemClassDimensao1 = value; 
               this._valueCollectionPlanoCorteItemClassDimensao1Loaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemClassDimensao2Original;
       private List<Entidades.PlanoCorteItemClass > _collectionPlanoCorteItemClassDimensao2Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassDimensao2Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassDimensao2Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassDimensao2CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemClass> _valueCollectionPlanoCorteItemClassDimensao2 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemClass> CollectionPlanoCorteItemClassDimensao2 
       { 
           get { if(!_valueCollectionPlanoCorteItemClassDimensao2Loaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemClassDimensao2();}
return this._valueCollectionPlanoCorteItemClassDimensao2; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemClassDimensao2 = value; 
               this._valueCollectionPlanoCorteItemClassDimensao2Loaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemClassDimensao3Original;
       private List<Entidades.PlanoCorteItemClass > _collectionPlanoCorteItemClassDimensao3Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassDimensao3Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassDimensao3Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassDimensao3CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemClass> _valueCollectionPlanoCorteItemClassDimensao3 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemClass> CollectionPlanoCorteItemClassDimensao3 
       { 
           get { if(!_valueCollectionPlanoCorteItemClassDimensao3Loaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemClassDimensao3();}
return this._valueCollectionPlanoCorteItemClassDimensao3; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemClassDimensao3 = value; 
               this._valueCollectionPlanoCorteItemClassDimensao3Loaded = true; 
           } 
       } 

       private List<long> _collectionProdutoMaterialClassDimensao1Original;
       private List<Entidades.ProdutoMaterialClass > _collectionProdutoMaterialClassDimensao1Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassDimensao1Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassDimensao1Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassDimensao1CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoMaterialClass> _valueCollectionProdutoMaterialClassDimensao1 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoMaterialClass> CollectionProdutoMaterialClassDimensao1 
       { 
           get { if(!_valueCollectionProdutoMaterialClassDimensao1Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoMaterialClassDimensao1();}
return this._valueCollectionProdutoMaterialClassDimensao1; } 
           set 
           { 
               this._valueCollectionProdutoMaterialClassDimensao1 = value; 
               this._valueCollectionProdutoMaterialClassDimensao1Loaded = true; 
           } 
       } 

       private List<long> _collectionProdutoMaterialClassDimensao2Original;
       private List<Entidades.ProdutoMaterialClass > _collectionProdutoMaterialClassDimensao2Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassDimensao2Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassDimensao2Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassDimensao2CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoMaterialClass> _valueCollectionProdutoMaterialClassDimensao2 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoMaterialClass> CollectionProdutoMaterialClassDimensao2 
       { 
           get { if(!_valueCollectionProdutoMaterialClassDimensao2Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoMaterialClassDimensao2();}
return this._valueCollectionProdutoMaterialClassDimensao2; } 
           set 
           { 
               this._valueCollectionProdutoMaterialClassDimensao2 = value; 
               this._valueCollectionProdutoMaterialClassDimensao2Loaded = true; 
           } 
       } 

       private List<long> _collectionProdutoMaterialClassDimensao3Original;
       private List<Entidades.ProdutoMaterialClass > _collectionProdutoMaterialClassDimensao3Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassDimensao3Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassDimensao3Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoMaterialClassDimensao3CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoMaterialClass> _valueCollectionProdutoMaterialClassDimensao3 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoMaterialClass> CollectionProdutoMaterialClassDimensao3 
       { 
           get { if(!_valueCollectionProdutoMaterialClassDimensao3Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoMaterialClassDimensao3();}
return this._valueCollectionProdutoMaterialClassDimensao3; } 
           set 
           { 
               this._valueCollectionProdutoMaterialClassDimensao3 = value; 
               this._valueCollectionProdutoMaterialClassDimensao3Loaded = true; 
           } 
       } 

        public DimensaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static DimensaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DimensaoClass) GetEntity(typeof(DimensaoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Changed = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Changed = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1CommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DimensaoCorte1", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1 = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1 select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Changed = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Changed = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2CommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DimensaoCorte2", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2 = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2 select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Changed = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Changed = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3CommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Changed = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3CommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DimensaoCorte3", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3 = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3 select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemClassDimensao1ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemClassDimensao1Changed = true;
                  _valueCollectionPlanoCorteItemClassDimensao1CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemClassDimensao1Changed = true; 
                  _valueCollectionPlanoCorteItemClassDimensao1CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemClassDimensao1Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemClassDimensao1Changed = true; 
                  _valueCollectionPlanoCorteItemClassDimensao1CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in _valueCollectionPlanoCorteItemClassDimensao1) 
                 { 
                     _collectionPlanoCorteItemClassDimensao1Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemClassDimensao1()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemClass> oc;
                _valueCollectionPlanoCorteItemClassDimensao1Changed = false;
                 _valueCollectionPlanoCorteItemClassDimensao1CommitedChanged = false;
                _collectionPlanoCorteItemClassDimensao1Removidos = new List<Entidades.PlanoCorteItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemClass search = new Entidades.PlanoCorteItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Dimensao1", this)                    }                       ).Cast<Entidades.PlanoCorteItemClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemClassDimensao1 = new BindingList<Entidades.PlanoCorteItemClass>(oc); 
                 _collectionPlanoCorteItemClassDimensao1Original= (from a in _valueCollectionPlanoCorteItemClassDimensao1 select a.ID).ToList();
                 _valueCollectionPlanoCorteItemClassDimensao1Loaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemClassDimensao1ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemClassDimensao1+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemClassDimensao2ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemClassDimensao2Changed = true;
                  _valueCollectionPlanoCorteItemClassDimensao2CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemClassDimensao2Changed = true; 
                  _valueCollectionPlanoCorteItemClassDimensao2CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemClassDimensao2Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemClassDimensao2Changed = true; 
                  _valueCollectionPlanoCorteItemClassDimensao2CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in _valueCollectionPlanoCorteItemClassDimensao2) 
                 { 
                     _collectionPlanoCorteItemClassDimensao2Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemClassDimensao2()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemClass> oc;
                _valueCollectionPlanoCorteItemClassDimensao2Changed = false;
                 _valueCollectionPlanoCorteItemClassDimensao2CommitedChanged = false;
                _collectionPlanoCorteItemClassDimensao2Removidos = new List<Entidades.PlanoCorteItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemClass search = new Entidades.PlanoCorteItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Dimensao2", this)                    }                       ).Cast<Entidades.PlanoCorteItemClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemClassDimensao2 = new BindingList<Entidades.PlanoCorteItemClass>(oc); 
                 _collectionPlanoCorteItemClassDimensao2Original= (from a in _valueCollectionPlanoCorteItemClassDimensao2 select a.ID).ToList();
                 _valueCollectionPlanoCorteItemClassDimensao2Loaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemClassDimensao2ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemClassDimensao2+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemClassDimensao3ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemClassDimensao3Changed = true;
                  _valueCollectionPlanoCorteItemClassDimensao3CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemClassDimensao3Changed = true; 
                  _valueCollectionPlanoCorteItemClassDimensao3CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemClassDimensao3Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemClassDimensao3Changed = true; 
                  _valueCollectionPlanoCorteItemClassDimensao3CommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in _valueCollectionPlanoCorteItemClassDimensao3) 
                 { 
                     _collectionPlanoCorteItemClassDimensao3Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemClassDimensao3()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemClass> oc;
                _valueCollectionPlanoCorteItemClassDimensao3Changed = false;
                 _valueCollectionPlanoCorteItemClassDimensao3CommitedChanged = false;
                _collectionPlanoCorteItemClassDimensao3Removidos = new List<Entidades.PlanoCorteItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemClass search = new Entidades.PlanoCorteItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Dimensao3", this)                    }                       ).Cast<Entidades.PlanoCorteItemClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemClassDimensao3 = new BindingList<Entidades.PlanoCorteItemClass>(oc); 
                 _collectionPlanoCorteItemClassDimensao3Original= (from a in _valueCollectionPlanoCorteItemClassDimensao3 select a.ID).ToList();
                 _valueCollectionPlanoCorteItemClassDimensao3Loaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemClassDimensao3ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemClassDimensao3+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoMaterialClassDimensao1ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoMaterialClassDimensao1Changed = true;
                  _valueCollectionProdutoMaterialClassDimensao1CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoMaterialClassDimensao1Changed = true; 
                  _valueCollectionProdutoMaterialClassDimensao1CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in e.OldItems) 
                 { 
                     _collectionProdutoMaterialClassDimensao1Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoMaterialClassDimensao1Changed = true; 
                  _valueCollectionProdutoMaterialClassDimensao1CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in _valueCollectionProdutoMaterialClassDimensao1) 
                 { 
                     _collectionProdutoMaterialClassDimensao1Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoMaterialClassDimensao1()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoMaterialClass> oc;
                _valueCollectionProdutoMaterialClassDimensao1Changed = false;
                 _valueCollectionProdutoMaterialClassDimensao1CommitedChanged = false;
                _collectionProdutoMaterialClassDimensao1Removidos = new List<Entidades.ProdutoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoMaterialClass>();
                }
                else{ 
                   Entidades.ProdutoMaterialClass search = new Entidades.ProdutoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Dimensao1", this),                     }                       ).Cast<Entidades.ProdutoMaterialClass>().ToList());
                 }
                 _valueCollectionProdutoMaterialClassDimensao1 = new BindingList<Entidades.ProdutoMaterialClass>(oc); 
                 _collectionProdutoMaterialClassDimensao1Original= (from a in _valueCollectionProdutoMaterialClassDimensao1 select a.ID).ToList();
                 _valueCollectionProdutoMaterialClassDimensao1Loaded = true;
                 oc.CollectionChanged += CollectionProdutoMaterialClassDimensao1ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoMaterialClassDimensao1+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoMaterialClassDimensao2ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoMaterialClassDimensao2Changed = true;
                  _valueCollectionProdutoMaterialClassDimensao2CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoMaterialClassDimensao2Changed = true; 
                  _valueCollectionProdutoMaterialClassDimensao2CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in e.OldItems) 
                 { 
                     _collectionProdutoMaterialClassDimensao2Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoMaterialClassDimensao2Changed = true; 
                  _valueCollectionProdutoMaterialClassDimensao2CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in _valueCollectionProdutoMaterialClassDimensao2) 
                 { 
                     _collectionProdutoMaterialClassDimensao2Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoMaterialClassDimensao2()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoMaterialClass> oc;
                _valueCollectionProdutoMaterialClassDimensao2Changed = false;
                 _valueCollectionProdutoMaterialClassDimensao2CommitedChanged = false;
                _collectionProdutoMaterialClassDimensao2Removidos = new List<Entidades.ProdutoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoMaterialClass>();
                }
                else{ 
                   Entidades.ProdutoMaterialClass search = new Entidades.ProdutoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Dimensao2", this),                     }                       ).Cast<Entidades.ProdutoMaterialClass>().ToList());
                 }
                 _valueCollectionProdutoMaterialClassDimensao2 = new BindingList<Entidades.ProdutoMaterialClass>(oc); 
                 _collectionProdutoMaterialClassDimensao2Original= (from a in _valueCollectionProdutoMaterialClassDimensao2 select a.ID).ToList();
                 _valueCollectionProdutoMaterialClassDimensao2Loaded = true;
                 oc.CollectionChanged += CollectionProdutoMaterialClassDimensao2ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoMaterialClassDimensao2+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoMaterialClassDimensao3ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoMaterialClassDimensao3Changed = true;
                  _valueCollectionProdutoMaterialClassDimensao3CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoMaterialClassDimensao3Changed = true; 
                  _valueCollectionProdutoMaterialClassDimensao3CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in e.OldItems) 
                 { 
                     _collectionProdutoMaterialClassDimensao3Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoMaterialClassDimensao3Changed = true; 
                  _valueCollectionProdutoMaterialClassDimensao3CommitedChanged = true;
                 foreach (Entidades.ProdutoMaterialClass item in _valueCollectionProdutoMaterialClassDimensao3) 
                 { 
                     _collectionProdutoMaterialClassDimensao3Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoMaterialClassDimensao3()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoMaterialClass> oc;
                _valueCollectionProdutoMaterialClassDimensao3Changed = false;
                 _valueCollectionProdutoMaterialClassDimensao3CommitedChanged = false;
                _collectionProdutoMaterialClassDimensao3Removidos = new List<Entidades.ProdutoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoMaterialClass>();
                }
                else{ 
                   Entidades.ProdutoMaterialClass search = new Entidades.ProdutoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Dimensao3", this),                     }                       ).Cast<Entidades.ProdutoMaterialClass>().ToList());
                 }
                 _valueCollectionProdutoMaterialClassDimensao3 = new BindingList<Entidades.ProdutoMaterialClass>(oc); 
                 _collectionProdutoMaterialClassDimensao3Original= (from a in _valueCollectionProdutoMaterialClassDimensao3 select a.ID).ToList();
                 _valueCollectionProdutoMaterialClassDimensao3Loaded = true;
                 oc.CollectionChanged += CollectionProdutoMaterialClassDimensao3ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoMaterialClassDimensao3+"\r\n" + e.Message, e);
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
                if (Identificacao.Length >255)
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
                    "  public.dimensao  " +
                    "WHERE " +
                    "  id_dimensao = :id";
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
                        "  public.dimensao   " +
                        "SET  " + 
                        "  dim_identificacao = :dim_identificacao, " + 
                        "  dim_descricao = :dim_descricao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  dim_ultima_revisao = :dim_ultima_revisao, " + 
                        "  dim_ultima_revisao_data = :dim_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao "+
                        "WHERE  " +
                        "  id_dimensao = :id " +
                        "RETURNING id_dimensao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.dimensao " +
                        "( " +
                        "  dim_identificacao , " + 
                        "  dim_descricao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  dim_ultima_revisao , " + 
                        "  dim_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :dim_identificacao , " + 
                        "  :dim_descricao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :dim_ultima_revisao , " + 
                        "  :dim_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao  "+
                        ")RETURNING id_dimensao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dim_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dim_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dim_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dim_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;

 
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
 if (CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemClassDimensao1.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemClassDimensao1+"\r\n";
                foreach (Entidades.PlanoCorteItemClass tmp in CollectionPlanoCorteItemClassDimensao1)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemClassDimensao2.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemClassDimensao2+"\r\n";
                foreach (Entidades.PlanoCorteItemClass tmp in CollectionPlanoCorteItemClassDimensao2)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemClassDimensao3.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemClassDimensao3+"\r\n";
                foreach (Entidades.PlanoCorteItemClass tmp in CollectionPlanoCorteItemClassDimensao3)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoMaterialClassDimensao1.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassDimensao1+"\r\n";
                foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassDimensao1)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoMaterialClassDimensao2.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassDimensao2+"\r\n";
                foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassDimensao2)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoMaterialClassDimensao3.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassDimensao3+"\r\n";
                foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassDimensao3)
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
        public static DimensaoClass CopiarEntidade(DimensaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DimensaoClass toRet = new DimensaoClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
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
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;

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
       _versionOriginalCommited = Version;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;

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
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Removidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1 select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Changed = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1CommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Removidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2 select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Changed = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2CommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Removidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Removidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Original= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3 select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Changed = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3CommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemClassDimensao1Loaded) 
               {
                  if (_collectionPlanoCorteItemClassDimensao1Removidos != null) 
                  {
                     _collectionPlanoCorteItemClassDimensao1Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemClassDimensao1Removidos = new List<Entidades.PlanoCorteItemClass>();
                  }
                  _collectionPlanoCorteItemClassDimensao1Original= (from a in _valueCollectionPlanoCorteItemClassDimensao1 select a.ID).ToList();
                  _valueCollectionPlanoCorteItemClassDimensao1Changed = false;
                  _valueCollectionPlanoCorteItemClassDimensao1CommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemClassDimensao2Loaded) 
               {
                  if (_collectionPlanoCorteItemClassDimensao2Removidos != null) 
                  {
                     _collectionPlanoCorteItemClassDimensao2Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemClassDimensao2Removidos = new List<Entidades.PlanoCorteItemClass>();
                  }
                  _collectionPlanoCorteItemClassDimensao2Original= (from a in _valueCollectionPlanoCorteItemClassDimensao2 select a.ID).ToList();
                  _valueCollectionPlanoCorteItemClassDimensao2Changed = false;
                  _valueCollectionPlanoCorteItemClassDimensao2CommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemClassDimensao3Loaded) 
               {
                  if (_collectionPlanoCorteItemClassDimensao3Removidos != null) 
                  {
                     _collectionPlanoCorteItemClassDimensao3Removidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemClassDimensao3Removidos = new List<Entidades.PlanoCorteItemClass>();
                  }
                  _collectionPlanoCorteItemClassDimensao3Original= (from a in _valueCollectionPlanoCorteItemClassDimensao3 select a.ID).ToList();
                  _valueCollectionPlanoCorteItemClassDimensao3Changed = false;
                  _valueCollectionPlanoCorteItemClassDimensao3CommitedChanged = false;
               }
               if (_valueCollectionProdutoMaterialClassDimensao1Loaded) 
               {
                  if (_collectionProdutoMaterialClassDimensao1Removidos != null) 
                  {
                     _collectionProdutoMaterialClassDimensao1Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoMaterialClassDimensao1Removidos = new List<Entidades.ProdutoMaterialClass>();
                  }
                  _collectionProdutoMaterialClassDimensao1Original= (from a in _valueCollectionProdutoMaterialClassDimensao1 select a.ID).ToList();
                  _valueCollectionProdutoMaterialClassDimensao1Changed = false;
                  _valueCollectionProdutoMaterialClassDimensao1CommitedChanged = false;
               }
               if (_valueCollectionProdutoMaterialClassDimensao2Loaded) 
               {
                  if (_collectionProdutoMaterialClassDimensao2Removidos != null) 
                  {
                     _collectionProdutoMaterialClassDimensao2Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoMaterialClassDimensao2Removidos = new List<Entidades.ProdutoMaterialClass>();
                  }
                  _collectionProdutoMaterialClassDimensao2Original= (from a in _valueCollectionProdutoMaterialClassDimensao2 select a.ID).ToList();
                  _valueCollectionProdutoMaterialClassDimensao2Changed = false;
                  _valueCollectionProdutoMaterialClassDimensao2CommitedChanged = false;
               }
               if (_valueCollectionProdutoMaterialClassDimensao3Loaded) 
               {
                  if (_collectionProdutoMaterialClassDimensao3Removidos != null) 
                  {
                     _collectionProdutoMaterialClassDimensao3Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoMaterialClassDimensao3Removidos = new List<Entidades.ProdutoMaterialClass>();
                  }
                  _collectionProdutoMaterialClassDimensao3Original= (from a in _valueCollectionProdutoMaterialClassDimensao3 select a.ID).ToList();
                  _valueCollectionProdutoMaterialClassDimensao3Changed = false;
                  _valueCollectionProdutoMaterialClassDimensao3CommitedChanged = false;
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
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Original)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Removidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Original)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Removidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Original)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Removidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemClassDimensao1Loaded) 
               {
                  CollectionPlanoCorteItemClassDimensao1.Clear();
                  foreach(int item in _collectionPlanoCorteItemClassDimensao1Original)
                  {
                    CollectionPlanoCorteItemClassDimensao1.Add(Entidades.PlanoCorteItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemClassDimensao1Removidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemClassDimensao2Loaded) 
               {
                  CollectionPlanoCorteItemClassDimensao2.Clear();
                  foreach(int item in _collectionPlanoCorteItemClassDimensao2Original)
                  {
                    CollectionPlanoCorteItemClassDimensao2.Add(Entidades.PlanoCorteItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemClassDimensao2Removidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemClassDimensao3Loaded) 
               {
                  CollectionPlanoCorteItemClassDimensao3.Clear();
                  foreach(int item in _collectionPlanoCorteItemClassDimensao3Original)
                  {
                    CollectionPlanoCorteItemClassDimensao3.Add(Entidades.PlanoCorteItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemClassDimensao3Removidos.Clear();
               }
               if (_valueCollectionProdutoMaterialClassDimensao1Loaded) 
               {
                  CollectionProdutoMaterialClassDimensao1.Clear();
                  foreach(int item in _collectionProdutoMaterialClassDimensao1Original)
                  {
                    CollectionProdutoMaterialClassDimensao1.Add(Entidades.ProdutoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoMaterialClassDimensao1Removidos.Clear();
               }
               if (_valueCollectionProdutoMaterialClassDimensao2Loaded) 
               {
                  CollectionProdutoMaterialClassDimensao2.Clear();
                  foreach(int item in _collectionProdutoMaterialClassDimensao2Original)
                  {
                    CollectionProdutoMaterialClassDimensao2.Add(Entidades.ProdutoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoMaterialClassDimensao2Removidos.Clear();
               }
               if (_valueCollectionProdutoMaterialClassDimensao3Loaded) 
               {
                  CollectionProdutoMaterialClassDimensao3.Clear();
                  foreach(int item in _collectionProdutoMaterialClassDimensao3Original)
                  {
                    CollectionProdutoMaterialClassDimensao3.Add(Entidades.ProdutoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoMaterialClassDimensao3Removidos.Clear();
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
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao1Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassDimensao1Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao2Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassDimensao2Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao3Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassDimensao3Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao1Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassDimensao1Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao2Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassDimensao2Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao3Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassDimensao3Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassDimensao1Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassDimensao1.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassDimensao2Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassDimensao2.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassDimensao3Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassDimensao3.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassDimensao1Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassDimensao1.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassDimensao2Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassDimensao2.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassDimensao3Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassDimensao3.Any(item => item.IsDirty());
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
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;

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
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao1Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassDimensao1CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao2Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassDimensao2CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao3Loaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassDimensao3CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao1Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassDimensao1CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao2Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassDimensao2CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao3Loaded) 
               {
                  if (_valueCollectionProdutoMaterialClassDimensao3CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassDimensao1Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassDimensao1.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassDimensao2Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassDimensao2.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemClassDimensao3Loaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassDimensao3.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassDimensao1Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassDimensao1.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassDimensao2Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassDimensao2.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoMaterialClassDimensao3Loaded) 
               {
                   tempRet = CollectionProdutoMaterialClassDimensao3.Any(item => item.IsDirtyCommited());
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
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;

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
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao1Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassDimensao1)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao2Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassDimensao2)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao3Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassDimensao3)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao1Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassDimensao1)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao2Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassDimensao2)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao3Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassDimensao3)
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
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte1)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte2)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3Loaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassDimensaoCorte3)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao1Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassDimensao1)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao2Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassDimensao2)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemClassDimensao3Loaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassDimensao3)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao1Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassDimensao1)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao2Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassDimensao2)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoMaterialClassDimensao3Loaded) 
               {
                  foreach(ProdutoMaterialClass item in CollectionProdutoMaterialClassDimensao3)
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
                  command.CommandText += " COUNT(dimensao.id_dimensao) " ;
               }
               else
               {
               command.CommandText += "dimensao.id_dimensao, " ;
               command.CommandText += "dimensao.dim_identificacao, " ;
               command.CommandText += "dimensao.dim_descricao, " ;
               command.CommandText += "dimensao.entity_uid, " ;
               command.CommandText += "dimensao.version, " ;
               command.CommandText += "dimensao.dim_ultima_revisao, " ;
               command.CommandText += "dimensao.dim_ultima_revisao_data, " ;
               command.CommandText += "dimensao.id_acs_usuario_ultima_revisao " ;
               }
               command.CommandText += " FROM  dimensao ";
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
                        orderByClause += " , dim_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(dim_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = dimensao.id_acs_usuario_ultima_revisao ";
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
                     case "id_dimensao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dimensao.id_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dimensao.id_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dim_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dim_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao.dim_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao.dim_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , dimensao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dimensao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dim_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao.dim_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao.dim_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dim_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dimensao.dim_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dimensao.dim_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , dimensao.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dim_identificacao")) 
                        {
                           whereClause += " OR UPPER(dimensao.dim_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(dimensao.dim_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dim_descricao")) 
                        {
                           whereClause += " OR UPPER(dimensao.dim_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(dimensao.dim_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(dimensao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(dimensao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dim_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(dimensao.dim_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(dimensao.dim_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_dimensao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dimensao.id_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.id_dimensao = :dimensao_ID_5287 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_ID_5287", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "dim_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dimensao.dim_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.dim_identificacao LIKE :dimensao_Identificacao_6001 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_Identificacao_6001", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "dim_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dimensao.dim_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.dim_descricao LIKE :dimensao_Descricao_430 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_Descricao_430", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  dimensao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.entity_uid LIKE :dimensao_EntityUid_6974 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_EntityUid_6974", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  dimensao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.version = :dimensao_Version_1724 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_Version_1724", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "dim_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dimensao.dim_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.dim_ultima_revisao LIKE :dimensao_UltimaRevisao_3483 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_UltimaRevisao_3483", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "dim_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dimensao.dim_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.dim_ultima_revisao_data = :dimensao_UltimaRevisaoData_6398 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_UltimaRevisaoData_6398", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  dimensao.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.id_acs_usuario_ultima_revisao = :dimensao_UltimaRevisaoUsuario_3897 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_UltimaRevisaoUsuario_3897", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  dimensao.dim_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.dim_identificacao LIKE :dimensao_Identificacao_1984 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_Identificacao_1984", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  dimensao.dim_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.dim_descricao LIKE :dimensao_Descricao_4202 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_Descricao_4202", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  dimensao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.entity_uid LIKE :dimensao_EntityUid_568 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_EntityUid_568", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  dimensao.dim_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dimensao.dim_ultima_revisao LIKE :dimensao_UltimaRevisao_3266 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dimensao_UltimaRevisao_3266", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DimensaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DimensaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DimensaoClass), Convert.ToInt32(read["id_dimensao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DimensaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_dimensao"]);
                     entidade.Identificacao = (read["dim_identificacao"] != DBNull.Value ? read["dim_identificacao"].ToString() : null);
                     entidade.Descricao = (read["dim_descricao"] != DBNull.Value ? read["dim_descricao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.UltimaRevisao = (read["dim_ultima_revisao"] != DBNull.Value ? read["dim_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["dim_ultima_revisao_data"] as DateTime?;
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DimensaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
