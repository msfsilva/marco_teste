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
     [Table("acabamento","acb")]
     public class AcabamentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do AcabamentoClass";
protected const string ErroDelete = "Erro ao excluir o AcabamentoClass  ";
protected const string ErroSave = "Erro ao salvar o AcabamentoClass.";
protected const string ErroCollectionMaterialClassAcabamento = "Erro ao carregar a coleção de MaterialClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassAcabamento = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionProdutoClassAcabamento = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCollectionProdutoAcabamentoClassAcabamento = "Erro ao carregar a coleção de ProdutoAcabamentoClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroDescricaoTecnicaObrigatorio = "O campo DescricaoTecnica é obrigatório";
protected const string ErroDescricaoTecnicaComprimento = "O campo DescricaoTecnica deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do AcabamentoClass.";
protected const string MensagemUtilizadoCollectionMaterialClassAcabamento =  "A entidade AcabamentoClass está sendo utilizada nos seguintes MaterialClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassAcabamento =  "A entidade AcabamentoClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionProdutoClassAcabamento =  "A entidade AcabamentoClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string MensagemUtilizadoCollectionProdutoAcabamentoClassAcabamento =  "A entidade AcabamentoClass está sendo utilizada nos seguintes ProdutoAcabamentoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade AcabamentoClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("acb_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected string _descricaoTecnicaOriginal{get;private set;}
       private string _descricaoTecnicaOriginalCommited{get; set;}
        private string _valueDescricaoTecnica;
         [Column("acb_descricao_tecnica")]
        public virtual string DescricaoTecnica
         { 
            get { return this._valueDescricaoTecnica; } 
            set 
            { 
                if (this._valueDescricaoTecnica == value)return;
                 this._valueDescricaoTecnica = value; 
            } 
        } 

       protected string _obsOriginal{get;private set;}
       private string _obsOriginalCommited{get; set;}
        private string _valueObs;
         [Column("acb_obs")]
        public virtual string Obs
         { 
            get { return this._valueObs; } 
            set 
            { 
                if (this._valueObs == value)return;
                 this._valueObs = value; 
            } 
        } 

       protected string _normaClienteOriginal{get;private set;}
       private string _normaClienteOriginalCommited{get; set;}
        private string _valueNormaCliente;
         [Column("acb_norma_cliente")]
        public virtual string NormaCliente
         { 
            get { return this._valueNormaCliente; } 
            set 
            { 
                if (this._valueNormaCliente == value)return;
                 this._valueNormaCliente = value; 
            } 
        } 

       private List<long> _collectionMaterialClassAcabamentoOriginal;
       private List<Entidades.MaterialClass > _collectionMaterialClassAcabamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassAcabamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassAcabamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassAcabamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialClass> _valueCollectionMaterialClassAcabamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialClass> CollectionMaterialClassAcabamento 
       { 
           get { if(!_valueCollectionMaterialClassAcabamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialClassAcabamento();}
return this._valueCollectionMaterialClassAcabamento; } 
           set 
           { 
               this._valueCollectionMaterialClassAcabamento = value; 
               this._valueCollectionMaterialClassAcabamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassAcabamentoOriginal;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassAcabamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassAcabamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassAcabamento 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassAcabamento();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassAcabamento; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassAcabamento = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassAcabamentoOriginal;
       private List<Entidades.ProdutoClass > _collectionProdutoClassAcabamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassAcabamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassAcabamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassAcabamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassAcabamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassAcabamento 
       { 
           get { if(!_valueCollectionProdutoClassAcabamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassAcabamento();}
return this._valueCollectionProdutoClassAcabamento; } 
           set 
           { 
               this._valueCollectionProdutoClassAcabamento = value; 
               this._valueCollectionProdutoClassAcabamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoAcabamentoClassAcabamentoOriginal;
       private List<Entidades.ProdutoAcabamentoClass > _collectionProdutoAcabamentoClassAcabamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoAcabamentoClassAcabamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoAcabamentoClassAcabamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoAcabamentoClassAcabamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoAcabamentoClass> _valueCollectionProdutoAcabamentoClassAcabamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoAcabamentoClass> CollectionProdutoAcabamentoClassAcabamento 
       { 
           get { if(!_valueCollectionProdutoAcabamentoClassAcabamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoAcabamentoClassAcabamento();}
return this._valueCollectionProdutoAcabamentoClassAcabamento; } 
           set 
           { 
               this._valueCollectionProdutoAcabamentoClassAcabamento = value; 
               this._valueCollectionProdutoAcabamentoClassAcabamentoLoaded = true; 
           } 
       } 

        public AcabamentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static AcabamentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (AcabamentoClass) GetEntity(typeof(AcabamentoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionMaterialClassAcabamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialClassAcabamentoChanged = true;
                  _valueCollectionMaterialClassAcabamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialClassAcabamentoChanged = true; 
                  _valueCollectionMaterialClassAcabamentoCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in e.OldItems) 
                 { 
                     _collectionMaterialClassAcabamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialClassAcabamentoChanged = true; 
                  _valueCollectionMaterialClassAcabamentoCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in _valueCollectionMaterialClassAcabamento) 
                 { 
                     _collectionMaterialClassAcabamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialClassAcabamento()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialClass> oc;
                _valueCollectionMaterialClassAcabamentoChanged = false;
                 _valueCollectionMaterialClassAcabamentoCommitedChanged = false;
                _collectionMaterialClassAcabamentoRemovidos = new List<Entidades.MaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialClass>();
                }
                else{ 
                   Entidades.MaterialClass search = new Entidades.MaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Acabamento", this),                     }                       ).Cast<Entidades.MaterialClass>().ToList());
                 }
                 _valueCollectionMaterialClassAcabamento = new BindingList<Entidades.MaterialClass>(oc); 
                 _collectionMaterialClassAcabamentoOriginal= (from a in _valueCollectionMaterialClassAcabamento select a.ID).ToList();
                 _valueCollectionMaterialClassAcabamentoLoaded = true;
                 oc.CollectionChanged += CollectionMaterialClassAcabamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialClassAcabamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassAcabamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoChanged = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassAcabamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassAcabamento) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassAcabamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassAcabamento()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoChanged = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoCommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassAcabamentoRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Acabamento", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassAcabamento = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassAcabamentoOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassAcabamento select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassAcabamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassAcabamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassAcabamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassAcabamentoChanged = true;
                  _valueCollectionProdutoClassAcabamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassAcabamentoChanged = true; 
                  _valueCollectionProdutoClassAcabamentoCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassAcabamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassAcabamentoChanged = true; 
                  _valueCollectionProdutoClassAcabamentoCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassAcabamento) 
                 { 
                     _collectionProdutoClassAcabamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassAcabamento()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassAcabamentoChanged = false;
                 _valueCollectionProdutoClassAcabamentoCommitedChanged = false;
                _collectionProdutoClassAcabamentoRemovidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Acabamento", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassAcabamento = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassAcabamentoOriginal= (from a in _valueCollectionProdutoClassAcabamento select a.ID).ToList();
                 _valueCollectionProdutoClassAcabamentoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoClassAcabamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassAcabamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoAcabamentoClassAcabamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoAcabamentoClassAcabamentoChanged = true;
                  _valueCollectionProdutoAcabamentoClassAcabamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoAcabamentoClassAcabamentoChanged = true; 
                  _valueCollectionProdutoAcabamentoClassAcabamentoCommitedChanged = true;
                 foreach (Entidades.ProdutoAcabamentoClass item in e.OldItems) 
                 { 
                     _collectionProdutoAcabamentoClassAcabamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoAcabamentoClassAcabamentoChanged = true; 
                  _valueCollectionProdutoAcabamentoClassAcabamentoCommitedChanged = true;
                 foreach (Entidades.ProdutoAcabamentoClass item in _valueCollectionProdutoAcabamentoClassAcabamento) 
                 { 
                     _collectionProdutoAcabamentoClassAcabamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoAcabamentoClassAcabamento()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoAcabamentoClass> oc;
                _valueCollectionProdutoAcabamentoClassAcabamentoChanged = false;
                 _valueCollectionProdutoAcabamentoClassAcabamentoCommitedChanged = false;
                _collectionProdutoAcabamentoClassAcabamentoRemovidos = new List<Entidades.ProdutoAcabamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoAcabamentoClass>();
                }
                else{ 
                   Entidades.ProdutoAcabamentoClass search = new Entidades.ProdutoAcabamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoAcabamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Acabamento", this),                     }                       ).Cast<Entidades.ProdutoAcabamentoClass>().ToList());
                 }
                 _valueCollectionProdutoAcabamentoClassAcabamento = new BindingList<Entidades.ProdutoAcabamentoClass>(oc); 
                 _collectionProdutoAcabamentoClassAcabamentoOriginal= (from a in _valueCollectionProdutoAcabamentoClassAcabamento select a.ID).ToList();
                 _valueCollectionProdutoAcabamentoClassAcabamentoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoAcabamentoClassAcabamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoAcabamentoClassAcabamento+"\r\n" + e.Message, e);
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
                if (string.IsNullOrEmpty(DescricaoTecnica))
                {
                    throw new Exception(ErroDescricaoTecnicaObrigatorio);
                }
                if (DescricaoTecnica.Length >255)
                {
                    throw new Exception( ErroDescricaoTecnicaComprimento);
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
                    "  public.acabamento  " +
                    "WHERE " +
                    "  id_acabamento = :id";
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
                        "  public.acabamento   " +
                        "SET  " + 
                        "  acb_identificacao = :acb_identificacao, " + 
                        "  acb_descricao_tecnica = :acb_descricao_tecnica, " + 
                        "  acb_obs = :acb_obs, " + 
                        "  acb_norma_cliente = :acb_norma_cliente, " + 
                        "  acb_ultima_revisao = :acb_ultima_revisao, " + 
                        "  acb_ultima_revisao_data = :acb_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_acabamento = :id " +
                        "RETURNING id_acabamento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.acabamento " +
                        "( " +
                        "  acb_identificacao , " + 
                        "  acb_descricao_tecnica , " + 
                        "  acb_obs , " + 
                        "  acb_norma_cliente , " + 
                        "  acb_ultima_revisao , " + 
                        "  acb_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :acb_identificacao , " + 
                        "  :acb_descricao_tecnica , " + 
                        "  :acb_obs , " + 
                        "  :acb_norma_cliente , " + 
                        "  :acb_ultima_revisao , " + 
                        "  :acb_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_acabamento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_descricao_tecnica", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoTecnica ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_obs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Obs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_norma_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NormaCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_ultima_revisao_data", NpgsqlDbType.Timestamp));
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
 if (CollectionMaterialClassAcabamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialClassAcabamento+"\r\n";
                foreach (Entidades.MaterialClass tmp in CollectionMaterialClassAcabamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassAcabamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassAcabamento+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassAcabamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassAcabamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassAcabamento+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassAcabamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoAcabamentoClassAcabamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoAcabamentoClassAcabamento+"\r\n";
                foreach (Entidades.ProdutoAcabamentoClass tmp in CollectionProdutoAcabamentoClassAcabamento)
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
        public static AcabamentoClass CopiarEntidade(AcabamentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               AcabamentoClass toRet = new AcabamentoClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.DescricaoTecnica= entidadeCopiar.DescricaoTecnica;
 toRet.Obs= entidadeCopiar.Obs;
 toRet.NormaCliente= entidadeCopiar.NormaCliente;

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
       _descricaoTecnicaOriginal = DescricaoTecnica;
       _descricaoTecnicaOriginalCommited = _descricaoTecnicaOriginal;
       _obsOriginal = Obs;
       _obsOriginalCommited = _obsOriginal;
       _normaClienteOriginal = NormaCliente;
       _normaClienteOriginalCommited = _normaClienteOriginal;
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
       _identificacaoOriginalCommited = Identificacao;
       _descricaoTecnicaOriginalCommited = DescricaoTecnica;
       _obsOriginalCommited = Obs;
       _normaClienteOriginalCommited = NormaCliente;
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
               if (_valueCollectionMaterialClassAcabamentoLoaded) 
               {
                  if (_collectionMaterialClassAcabamentoRemovidos != null) 
                  {
                     _collectionMaterialClassAcabamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialClassAcabamentoRemovidos = new List<Entidades.MaterialClass>();
                  }
                  _collectionMaterialClassAcabamentoOriginal= (from a in _valueCollectionMaterialClassAcabamento select a.ID).ToList();
                  _valueCollectionMaterialClassAcabamentoChanged = false;
                  _valueCollectionMaterialClassAcabamentoCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassAcabamentoRemovidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassAcabamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassAcabamentoRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassAcabamentoOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassAcabamento select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoChanged = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoCommitedChanged = false;
               }
               if (_valueCollectionProdutoClassAcabamentoLoaded) 
               {
                  if (_collectionProdutoClassAcabamentoRemovidos != null) 
                  {
                     _collectionProdutoClassAcabamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassAcabamentoRemovidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassAcabamentoOriginal= (from a in _valueCollectionProdutoClassAcabamento select a.ID).ToList();
                  _valueCollectionProdutoClassAcabamentoChanged = false;
                  _valueCollectionProdutoClassAcabamentoCommitedChanged = false;
               }
               if (_valueCollectionProdutoAcabamentoClassAcabamentoLoaded) 
               {
                  if (_collectionProdutoAcabamentoClassAcabamentoRemovidos != null) 
                  {
                     _collectionProdutoAcabamentoClassAcabamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoAcabamentoClassAcabamentoRemovidos = new List<Entidades.ProdutoAcabamentoClass>();
                  }
                  _collectionProdutoAcabamentoClassAcabamentoOriginal= (from a in _valueCollectionProdutoAcabamentoClassAcabamento select a.ID).ToList();
                  _valueCollectionProdutoAcabamentoClassAcabamentoChanged = false;
                  _valueCollectionProdutoAcabamentoClassAcabamentoCommitedChanged = false;
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
               DescricaoTecnica=_descricaoTecnicaOriginal;
               _descricaoTecnicaOriginalCommited=_descricaoTecnicaOriginal;
               Obs=_obsOriginal;
               _obsOriginalCommited=_obsOriginal;
               NormaCliente=_normaClienteOriginal;
               _normaClienteOriginalCommited=_normaClienteOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionMaterialClassAcabamentoLoaded) 
               {
                  CollectionMaterialClassAcabamento.Clear();
                  foreach(int item in _collectionMaterialClassAcabamentoOriginal)
                  {
                    CollectionMaterialClassAcabamento.Add(Entidades.MaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialClassAcabamentoRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassAcabamento.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassAcabamentoOriginal)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassAcabamento.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassAcabamentoRemovidos.Clear();
               }
               if (_valueCollectionProdutoClassAcabamentoLoaded) 
               {
                  CollectionProdutoClassAcabamento.Clear();
                  foreach(int item in _collectionProdutoClassAcabamentoOriginal)
                  {
                    CollectionProdutoClassAcabamento.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassAcabamentoRemovidos.Clear();
               }
               if (_valueCollectionProdutoAcabamentoClassAcabamentoLoaded) 
               {
                  CollectionProdutoAcabamentoClassAcabamento.Clear();
                  foreach(int item in _collectionProdutoAcabamentoClassAcabamentoOriginal)
                  {
                    CollectionProdutoAcabamentoClassAcabamento.Add(Entidades.ProdutoAcabamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoAcabamentoClassAcabamentoRemovidos.Clear();
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
               if (_valueCollectionMaterialClassAcabamentoLoaded) 
               {
                  if (_valueCollectionMaterialClassAcabamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassAcabamentoLoaded) 
               {
                  if (_valueCollectionProdutoClassAcabamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoAcabamentoClassAcabamentoLoaded) 
               {
                  if (_valueCollectionProdutoAcabamentoClassAcabamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassAcabamentoLoaded) 
               {
                   tempRet = CollectionMaterialClassAcabamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassAcabamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassAcabamentoLoaded) 
               {
                   tempRet = CollectionProdutoClassAcabamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoAcabamentoClassAcabamentoLoaded) 
               {
                   tempRet = CollectionProdutoAcabamentoClassAcabamento.Any(item => item.IsDirty());
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
       dirty = _descricaoTecnicaOriginal != DescricaoTecnica;
      if (dirty) return true;
       dirty = _obsOriginal != Obs;
      if (dirty) return true;
       dirty = _normaClienteOriginal != NormaCliente;
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
               if (_valueCollectionMaterialClassAcabamentoLoaded) 
               {
                  if (_valueCollectionMaterialClassAcabamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassAcabamentoLoaded) 
               {
                  if (_valueCollectionProdutoClassAcabamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoAcabamentoClassAcabamentoLoaded) 
               {
                  if (_valueCollectionProdutoAcabamentoClassAcabamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassAcabamentoLoaded) 
               {
                   tempRet = CollectionMaterialClassAcabamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassAcabamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassAcabamentoLoaded) 
               {
                   tempRet = CollectionProdutoClassAcabamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoAcabamentoClassAcabamentoLoaded) 
               {
                   tempRet = CollectionProdutoAcabamentoClassAcabamento.Any(item => item.IsDirtyCommited());
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
       dirty = _descricaoTecnicaOriginalCommited != DescricaoTecnica;
      if (dirty) return true;
       dirty = _obsOriginalCommited != Obs;
      if (dirty) return true;
       dirty = _normaClienteOriginalCommited != NormaCliente;
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
               if (_valueCollectionMaterialClassAcabamentoLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassAcabamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassAcabamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassAcabamentoLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassAcabamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoAcabamentoClassAcabamentoLoaded) 
               {
                  foreach(ProdutoAcabamentoClass item in CollectionProdutoAcabamentoClassAcabamento)
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
             case "DescricaoTecnica":
                return this.DescricaoTecnica;
             case "Obs":
                return this.Obs;
             case "NormaCliente":
                return this.NormaCliente;
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
               if (_valueCollectionMaterialClassAcabamentoLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassAcabamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassAcabamentoLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassAcabamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassAcabamentoLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassAcabamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoAcabamentoClassAcabamentoLoaded) 
               {
                  foreach(ProdutoAcabamentoClass item in CollectionProdutoAcabamentoClassAcabamento)
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
                  command.CommandText += " COUNT(acabamento.id_acabamento) " ;
               }
               else
               {
               command.CommandText += "acabamento.id_acabamento, " ;
               command.CommandText += "acabamento.acb_identificacao, " ;
               command.CommandText += "acabamento.acb_descricao_tecnica, " ;
               command.CommandText += "acabamento.acb_obs, " ;
               command.CommandText += "acabamento.acb_norma_cliente, " ;
               command.CommandText += "acabamento.acb_ultima_revisao, " ;
               command.CommandText += "acabamento.acb_ultima_revisao_data, " ;
               command.CommandText += "acabamento.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "acabamento.entity_uid, " ;
               command.CommandText += "acabamento.version " ;
               }
               command.CommandText += " FROM  acabamento ";
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
                        orderByClause += " , acb_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(acb_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = acabamento.id_acs_usuario_ultima_revisao ";
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
                     case "id_acabamento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , acabamento.id_acabamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(acabamento.id_acabamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "acb_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , acabamento.acb_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(acabamento.acb_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "acb_descricao_tecnica":
                     case "DescricaoTecnica":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , acabamento.acb_descricao_tecnica " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(acabamento.acb_descricao_tecnica) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "acb_obs":
                     case "Obs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , acabamento.acb_obs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(acabamento.acb_obs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "acb_norma_cliente":
                     case "NormaCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , acabamento.acb_norma_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(acabamento.acb_norma_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "acb_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , acabamento.acb_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(acabamento.acb_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "acb_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , acabamento.acb_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(acabamento.acb_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , acabamento.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , acabamento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(acabamento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , acabamento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(acabamento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("acb_identificacao")) 
                        {
                           whereClause += " OR UPPER(acabamento.acb_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(acabamento.acb_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("acb_descricao_tecnica")) 
                        {
                           whereClause += " OR UPPER(acabamento.acb_descricao_tecnica) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(acabamento.acb_descricao_tecnica) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("acb_obs")) 
                        {
                           whereClause += " OR UPPER(acabamento.acb_obs) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(acabamento.acb_obs) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("acb_norma_cliente")) 
                        {
                           whereClause += " OR UPPER(acabamento.acb_norma_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(acabamento.acb_norma_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("acb_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(acabamento.acb_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(acabamento.acb_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(acabamento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(acabamento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_acabamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  acabamento.id_acabamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.id_acabamento = :acabamento_ID_2158 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_ID_2158", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "acb_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  acabamento.acb_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_identificacao LIKE :acabamento_Identificacao_1147 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_Identificacao_1147", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoTecnica" || parametro.FieldName == "acb_descricao_tecnica")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  acabamento.acb_descricao_tecnica IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_descricao_tecnica LIKE :acabamento_DescricaoTecnica_853 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_DescricaoTecnica_853", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Obs" || parametro.FieldName == "acb_obs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  acabamento.acb_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_obs LIKE :acabamento_Obs_7702 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_Obs_7702", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NormaCliente" || parametro.FieldName == "acb_norma_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  acabamento.acb_norma_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_norma_cliente LIKE :acabamento_NormaCliente_5049 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_NormaCliente_5049", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "acb_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  acabamento.acb_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_ultima_revisao LIKE :acabamento_UltimaRevisao_4254 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_UltimaRevisao_4254", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "acb_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  acabamento.acb_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_ultima_revisao_data = :acabamento_UltimaRevisaoData_9343 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_UltimaRevisaoData_9343", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  acabamento.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.id_acs_usuario_ultima_revisao = :acabamento_UltimaRevisaoUsuario_3118 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_UltimaRevisaoUsuario_3118", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  acabamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.entity_uid LIKE :acabamento_EntityUid_4424 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_EntityUid_4424", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  acabamento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.version = :acabamento_Version_4300 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_Version_4300", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  acabamento.acb_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_identificacao LIKE :acabamento_Identificacao_5923 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_Identificacao_5923", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoTecnicaExato" || parametro.FieldName == "DescricaoTecnicaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  acabamento.acb_descricao_tecnica IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_descricao_tecnica LIKE :acabamento_DescricaoTecnica_4464 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_DescricaoTecnica_4464", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  acabamento.acb_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_obs LIKE :acabamento_Obs_3512 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_Obs_3512", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NormaClienteExato" || parametro.FieldName == "NormaClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  acabamento.acb_norma_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_norma_cliente LIKE :acabamento_NormaCliente_9804 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_NormaCliente_9804", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  acabamento.acb_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.acb_ultima_revisao LIKE :acabamento_UltimaRevisao_9251 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_UltimaRevisao_9251", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  acabamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  acabamento.entity_uid LIKE :acabamento_EntityUid_8536 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acabamento_EntityUid_8536", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  AcabamentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (AcabamentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(AcabamentoClass), Convert.ToInt32(read["id_acabamento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new AcabamentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_acabamento"]);
                     entidade.Identificacao = (read["acb_identificacao"] != DBNull.Value ? read["acb_identificacao"].ToString() : null);
                     entidade.DescricaoTecnica = (read["acb_descricao_tecnica"] != DBNull.Value ? read["acb_descricao_tecnica"].ToString() : null);
                     entidade.Obs = (read["acb_obs"] != DBNull.Value ? read["acb_obs"].ToString() : null);
                     entidade.NormaCliente = (read["acb_norma_cliente"] != DBNull.Value ? read["acb_norma_cliente"].ToString() : null);
                     entidade.UltimaRevisao = (read["acb_ultima_revisao"] != DBNull.Value ? read["acb_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["acb_ultima_revisao_data"] as DateTime?;
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
                     entidade = (AcabamentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
