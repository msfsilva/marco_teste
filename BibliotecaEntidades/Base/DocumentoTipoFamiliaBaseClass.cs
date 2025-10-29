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
     [Table("documento_tipo_familia","ent")]
     public class DocumentoTipoFamiliaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DocumentoTipoFamiliaClass";
protected const string ErroDelete = "Erro ao excluir o DocumentoTipoFamiliaClass  ";
protected const string ErroSave = "Erro ao salvar o DocumentoTipoFamiliaClass.";
protected const string ErroCollectionDocumentoCopiaClassDocumentoTipoFamilia = "Erro ao carregar a coleção de DocumentoCopiaClass.";
protected const string ErroCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia = "Erro ao carregar a coleção de OrdemCompraDocumentoEnviadoClass.";
protected const string ErroCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia = "Erro ao carregar a coleção de OrdemProducaoDocumentoClass.";
protected const string ErroCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia = "Erro ao carregar a coleção de ProdutoDocumentoTipoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroDocumentoTipoObrigatorio = "O campo DocumentoTipo é obrigatório";
protected const string ErroFamiliaDocumentoObrigatorio = "O campo FamiliaDocumento é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do DocumentoTipoFamiliaClass.";
protected const string MensagemUtilizadoCollectionDocumentoCopiaClassDocumentoTipoFamilia =  "A entidade DocumentoTipoFamiliaClass está sendo utilizada nos seguintes DocumentoCopiaClass:";
protected const string MensagemUtilizadoCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia =  "A entidade DocumentoTipoFamiliaClass está sendo utilizada nos seguintes OrdemCompraDocumentoEnviadoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia =  "A entidade DocumentoTipoFamiliaClass está sendo utilizada nos seguintes OrdemProducaoDocumentoClass:";
protected const string MensagemUtilizadoCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia =  "A entidade DocumentoTipoFamiliaClass está sendo utilizada nos seguintes ProdutoDocumentoTipoClass:";
protected const string ErroDocumentoLoad = "O campo Documento não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DocumentoTipoFamiliaClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.DocumentoTipoClass _documentoTipoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.DocumentoTipoClass _documentoTipoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DocumentoTipoClass _valueDocumentoTipo;
        [Column("id_documento_tipo", "documento_tipo", "id_documento_tipo")]
       public virtual BibliotecaEntidades.Entidades.DocumentoTipoClass DocumentoTipo
        { 
           get {                 return this._valueDocumentoTipo; } 
           set 
           { 
                if (this._valueDocumentoTipo == value)return;
                 this._valueDocumentoTipo = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.FamiliaDocumentoClass _familiaDocumentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FamiliaDocumentoClass _familiaDocumentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FamiliaDocumentoClass _valueFamiliaDocumento;
        [Column("id_familia_documento", "familia_documento", "id_familia_documento")]
       public virtual BibliotecaEntidades.Entidades.FamiliaDocumentoClass FamiliaDocumento
        { 
           get {                 return this._valueFamiliaDocumento; } 
           set 
           { 
                if (this._valueFamiliaDocumento == value)return;
                 this._valueFamiliaDocumento = value; 
           } 
       } 

       protected TipoValidacaoDocumento _tipoValidacaoOriginal{get;private set;}
       private TipoValidacaoDocumento _tipoValidacaoOriginalCommited{get; set;}
        private TipoValidacaoDocumento _valueTipoValidacao;
         [Column("dtf_tipo_validacao")]
        public virtual TipoValidacaoDocumento TipoValidacao
         { 
            get { return this._valueTipoValidacao; } 
            set 
            { 
                if (this._valueTipoValidacao == value)return;
                 this._valueTipoValidacao = value; 
            } 
        } 

        public bool TipoValidacao_NaoValidar
         { 
            get { return this._valueTipoValidacao == BibliotecaEntidades.Base.TipoValidacaoDocumento.NaoValidar; } 
            set { if (value) this._valueTipoValidacao = BibliotecaEntidades.Base.TipoValidacaoDocumento.NaoValidar; }
         } 

        public bool TipoValidacao_ValidarAviso
         { 
            get { return this._valueTipoValidacao == BibliotecaEntidades.Base.TipoValidacaoDocumento.ValidarAviso; } 
            set { if (value) this._valueTipoValidacao = BibliotecaEntidades.Base.TipoValidacaoDocumento.ValidarAviso; }
         } 

        public bool TipoValidacao_ValidarBloqueio
         { 
            get { return this._valueTipoValidacao == BibliotecaEntidades.Base.TipoValidacaoDocumento.ValidarBloqueio; } 
            set { if (value) this._valueTipoValidacao = BibliotecaEntidades.Base.TipoValidacaoDocumento.ValidarBloqueio; }
         } 

       protected string _documentoPedidoFamiliaOriginal{get;private set;}
       private string _documentoPedidoFamiliaOriginalCommited{get; set;}
        private string _valueDocumentoPedidoFamilia;
         [Column("dtf_documento_pedido_familia")]
        public virtual string DocumentoPedidoFamilia
         { 
            get { return this._valueDocumentoPedidoFamilia; } 
            set 
            { 
                if (this._valueDocumentoPedidoFamilia == value)return;
                 this._valueDocumentoPedidoFamilia = value; 
            } 
        } 

       protected string _documentoPedidoOriginal{get;private set;}
       private string _documentoPedidoOriginalCommited{get; set;}
        private string _valueDocumentoPedido;
         [Column("dtf_documento_pedido")]
        public virtual string DocumentoPedido
         { 
            get { return this._valueDocumentoPedido; } 
            set 
            { 
                if (this._valueDocumentoPedido == value)return;
                 this._valueDocumentoPedido = value; 
            } 
        } 

       protected string _documentoPedidoRevisaoOriginal{get;private set;}
       private string _documentoPedidoRevisaoOriginalCommited{get; set;}
        private string _valueDocumentoPedidoRevisao;
         [Column("dtf_documento_pedido_revisao")]
        public virtual string DocumentoPedidoRevisao
         { 
            get { return this._valueDocumentoPedidoRevisao; } 
            set 
            { 
                if (this._valueDocumentoPedidoRevisao == value)return;
                 this._valueDocumentoPedidoRevisao = value; 
            } 
        } 

       protected string _documentoOriginal= null;
        private string _documentoOriginalCommited= null;
        private bool _DocumentoLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool DocumentoLoaded 
       { 
            get {                     return _DocumentoLoaded; } 
           set 
           { 
                this._DocumentoLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueDocumento;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("dtf_documento")]
        public virtual byte[] Documento
         { 
            get { 
                   if (!this.DocumentoLoaded) 
                   {
                       this.LoadDocumento();
                   }
                   return this._valueDocumento; } 
            set 
            { 
                DocumentoLoaded = true; 
                if (this._valueDocumento == value)return;
                 this._valueDocumento = value; 
            } 
        } 

       protected string _documentoNomeOriginal{get;private set;}
       private string _documentoNomeOriginalCommited{get; set;}
        private string _valueDocumentoNome;
         [Column("dtf_documento_nome")]
        public virtual string DocumentoNome
         { 
            get { return this._valueDocumentoNome; } 
            set 
            { 
                if (this._valueDocumentoNome == value)return;
                 this._valueDocumentoNome = value; 
            } 
        } 

       protected bool _bloqueadoOriginal{get;private set;}
       private bool _bloqueadoOriginalCommited{get; set;}
        private bool _valueBloqueado;
         [Column("dtf_bloqueado")]
        public virtual bool Bloqueado
         { 
            get { return this._valueBloqueado; } 
            set 
            { 
                if (this._valueBloqueado == value)return;
                 this._valueBloqueado = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioBloqueioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioBloqueioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioBloqueio;
        [Column("id_acs_usuario_bloqueio", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioBloqueio
        { 
           get {                 return this._valueAcsUsuarioBloqueio; } 
           set 
           { 
                if (this._valueAcsUsuarioBloqueio == value)return;
                 this._valueAcsUsuarioBloqueio = value; 
           } 
       } 

       protected DateTime? _bloqueioDataOriginal{get;private set;}
       private DateTime? _bloqueioDataOriginalCommited{get; set;}
        private DateTime? _valueBloqueioData;
         [Column("dtf_bloqueio_data")]
        public virtual DateTime? BloqueioData
         { 
            get { return this._valueBloqueioData; } 
            set 
            { 
                if (this._valueBloqueioData == value)return;
                 this._valueBloqueioData = value; 
            } 
        } 

       private List<long> _collectionDocumentoCopiaClassDocumentoTipoFamiliaOriginal;
       private List<Entidades.DocumentoCopiaClass > _collectionDocumentoCopiaClassDocumentoTipoFamiliaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.DocumentoCopiaClass> _valueCollectionDocumentoCopiaClassDocumentoTipoFamilia { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.DocumentoCopiaClass> CollectionDocumentoCopiaClassDocumentoTipoFamilia 
       { 
           get { if(!_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded && !this.DisableLoadCollection){this.LoadCollectionDocumentoCopiaClassDocumentoTipoFamilia();}
return this._valueCollectionDocumentoCopiaClassDocumentoTipoFamilia; } 
           set 
           { 
               this._valueCollectionDocumentoCopiaClassDocumentoTipoFamilia = value; 
               this._valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaOriginal;
       private List<Entidades.OrdemCompraDocumentoEnviadoClass > _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemCompraDocumentoEnviadoClass> _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemCompraDocumentoEnviadoClass> CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia 
       { 
           get { if(!_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia();}
return this._valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia; } 
           set 
           { 
               this._valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia = value; 
               this._valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaOriginal;
       private List<Entidades.OrdemProducaoDocumentoClass > _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoDocumentoClass> _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoDocumentoClass> CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia 
       { 
           get { if(!_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia();}
return this._valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia; } 
           set 
           { 
               this._valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia = value; 
               this._valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaOriginal;
       private List<Entidades.ProdutoDocumentoTipoClass > _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoDocumentoTipoClass> _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoDocumentoTipoClass> CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia 
       { 
           get { if(!_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia();}
return this._valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia; } 
           set 
           { 
               this._valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia = value; 
               this._valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded = true; 
           } 
       } 

        public DocumentoTipoFamiliaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.TipoValidacao = (TipoValidacaoDocumento)0;
           this.Bloqueado = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static DocumentoTipoFamiliaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DocumentoTipoFamiliaClass) GetEntity(typeof(DocumentoTipoFamiliaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionDocumentoCopiaClassDocumentoTipoFamiliaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaChanged = true;
                  _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaChanged = true; 
                  _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaCommitedChanged = true;
                 foreach (Entidades.DocumentoCopiaClass item in e.OldItems) 
                 { 
                     _collectionDocumentoCopiaClassDocumentoTipoFamiliaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaChanged = true; 
                  _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaCommitedChanged = true;
                 foreach (Entidades.DocumentoCopiaClass item in _valueCollectionDocumentoCopiaClassDocumentoTipoFamilia) 
                 { 
                     _collectionDocumentoCopiaClassDocumentoTipoFamiliaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionDocumentoCopiaClassDocumentoTipoFamilia()
         {
            try
            {
                 ObservableCollection<Entidades.DocumentoCopiaClass> oc;
                _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaChanged = false;
                 _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaCommitedChanged = false;
                _collectionDocumentoCopiaClassDocumentoTipoFamiliaRemovidos = new List<Entidades.DocumentoCopiaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.DocumentoCopiaClass>();
                }
                else{ 
                   Entidades.DocumentoCopiaClass search = new Entidades.DocumentoCopiaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.DocumentoCopiaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DocumentoTipoFamilia", this),                     }                       ).Cast<Entidades.DocumentoCopiaClass>().ToList());
                 }
                 _valueCollectionDocumentoCopiaClassDocumentoTipoFamilia = new BindingList<Entidades.DocumentoCopiaClass>(oc); 
                 _collectionDocumentoCopiaClassDocumentoTipoFamiliaOriginal= (from a in _valueCollectionDocumentoCopiaClassDocumentoTipoFamilia select a.ID).ToList();
                 _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded = true;
                 oc.CollectionChanged += CollectionDocumentoCopiaClassDocumentoTipoFamiliaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionDocumentoCopiaClassDocumentoTipoFamilia+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaChanged = true;
                  _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaChanged = true; 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaCommitedChanged = true;
                 foreach (Entidades.OrdemCompraDocumentoEnviadoClass item in e.OldItems) 
                 { 
                     _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaChanged = true; 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaCommitedChanged = true;
                 foreach (Entidades.OrdemCompraDocumentoEnviadoClass item in _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia) 
                 { 
                     _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemCompraDocumentoEnviadoClass> oc;
                _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaChanged = false;
                 _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaCommitedChanged = false;
                _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaRemovidos = new List<Entidades.OrdemCompraDocumentoEnviadoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemCompraDocumentoEnviadoClass>();
                }
                else{ 
                   Entidades.OrdemCompraDocumentoEnviadoClass search = new Entidades.OrdemCompraDocumentoEnviadoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemCompraDocumentoEnviadoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DocumentoTipoFamilia", this),                     }                       ).Cast<Entidades.OrdemCompraDocumentoEnviadoClass>().ToList());
                 }
                 _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia = new BindingList<Entidades.OrdemCompraDocumentoEnviadoClass>(oc); 
                 _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaOriginal= (from a in _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia select a.ID).ToList();
                 _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded = true;
                 oc.CollectionChanged += CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaChanged = true;
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoClass item in _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia) 
                 { 
                     _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoDocumentoClass> oc;
                _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaChanged = false;
                 _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaCommitedChanged = false;
                _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaRemovidos = new List<Entidades.OrdemProducaoDocumentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoDocumentoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoDocumentoClass search = new Entidades.OrdemProducaoDocumentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoDocumentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DocumentoTipoFamilia", this),                     }                       ).Cast<Entidades.OrdemProducaoDocumentoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia = new BindingList<Entidades.OrdemProducaoDocumentoClass>(oc); 
                 _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaOriginal= (from a in _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia select a.ID).ToList();
                 _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaChanged = true;
                  _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaChanged = true; 
                  _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaCommitedChanged = true;
                 foreach (Entidades.ProdutoDocumentoTipoClass item in e.OldItems) 
                 { 
                     _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaChanged = true; 
                  _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaCommitedChanged = true;
                 foreach (Entidades.ProdutoDocumentoTipoClass item in _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia) 
                 { 
                     _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoDocumentoTipoClass> oc;
                _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaChanged = false;
                 _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaCommitedChanged = false;
                _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaRemovidos = new List<Entidades.ProdutoDocumentoTipoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoDocumentoTipoClass>();
                }
                else{ 
                   Entidades.ProdutoDocumentoTipoClass search = new Entidades.ProdutoDocumentoTipoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoDocumentoTipoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DocumentoTipoFamilia", this),                     }                       ).Cast<Entidades.ProdutoDocumentoTipoClass>().ToList());
                 }
                 _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia = new BindingList<Entidades.ProdutoDocumentoTipoClass>(oc); 
                 _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaOriginal= (from a in _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia select a.ID).ToList();
                 _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded = true;
                 oc.CollectionChanged += CollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia+"\r\n" + e.Message, e);
            }
         } 
private void LoadDocumento()
        {
            try
            {
                if (this.ID == -1)
                {

                    DocumentoLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT dtf_documento FROM documento_tipo_familia WHERE id_documento_tipo_familia = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueDocumento = (byte[]) tmp;
                }
                if (this._valueDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _documentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                     }
                  } 
                  else 
                  { 
                        _documentoOriginal = null ;
                  } 
                DocumentoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroDocumentoLoad + "\r\n" + e.Message, e);
            }
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueDocumentoTipo == null)
                {
                    throw new Exception(ErroDocumentoTipoObrigatorio);
                }
                if ( _valueFamiliaDocumento == null)
                {
                    throw new Exception(ErroFamiliaDocumentoObrigatorio);
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
                    "  public.documento_tipo_familia  " +
                    "WHERE " +
                    "  id_documento_tipo_familia = :id";
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
                        "  public.documento_tipo_familia   " +
                        "SET  " + 
                        "  id_documento_tipo = :id_documento_tipo, " + 
                        "  id_familia_documento = :id_familia_documento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  dtf_tipo_validacao = :dtf_tipo_validacao, " + 
                        "  dtf_documento_pedido_familia = :dtf_documento_pedido_familia, " + 
                        "  dtf_documento_pedido = :dtf_documento_pedido, " + 
                        "  dtf_documento_pedido_revisao = :dtf_documento_pedido_revisao, " + 
                        "  dtf_documento = :dtf_documento, " + 
                        "  dtf_documento_nome = :dtf_documento_nome, " + 
                        "  dtf_bloqueado = :dtf_bloqueado, " + 
                        "  id_acs_usuario_bloqueio = :id_acs_usuario_bloqueio, " + 
                        "  dtf_bloqueio_data = :dtf_bloqueio_data "+
                        "WHERE  " +
                        "  id_documento_tipo_familia = :id " +
                        "RETURNING id_documento_tipo_familia;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.documento_tipo_familia " +
                        "( " +
                        "  id_documento_tipo , " + 
                        "  id_familia_documento , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  dtf_tipo_validacao , " + 
                        "  dtf_documento_pedido_familia , " + 
                        "  dtf_documento_pedido , " + 
                        "  dtf_documento_pedido_revisao , " + 
                        "  dtf_documento , " + 
                        "  dtf_documento_nome , " + 
                        "  dtf_bloqueado , " + 
                        "  id_acs_usuario_bloqueio , " + 
                        "  dtf_bloqueio_data  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_documento_tipo , " + 
                        "  :id_familia_documento , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :dtf_tipo_validacao , " + 
                        "  :dtf_documento_pedido_familia , " + 
                        "  :dtf_documento_pedido , " + 
                        "  :dtf_documento_pedido_revisao , " + 
                        "  :dtf_documento , " + 
                        "  :dtf_documento_nome , " + 
                        "  :dtf_bloqueado , " + 
                        "  :id_acs_usuario_bloqueio , " + 
                        "  :dtf_bloqueio_data  "+
                        ")RETURNING id_documento_tipo_familia;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_tipo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DocumentoTipo==null ? (object) DBNull.Value : this.DocumentoTipo.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_familia_documento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FamiliaDocumento==null ? (object) DBNull.Value : this.FamiliaDocumento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dtf_tipo_validacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoValidacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dtf_documento_pedido_familia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoPedidoFamilia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dtf_documento_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dtf_documento_pedido_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoPedidoRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dtf_documento", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Documento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dtf_documento_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoNome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dtf_bloqueado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Bloqueado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_bloqueio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioBloqueio==null ? (object) DBNull.Value : this.AcsUsuarioBloqueio.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dtf_bloqueio_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BloqueioData ?? DBNull.Value;

 
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
 if (CollectionDocumentoCopiaClassDocumentoTipoFamilia.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionDocumentoCopiaClassDocumentoTipoFamilia+"\r\n";
                foreach (Entidades.DocumentoCopiaClass tmp in CollectionDocumentoCopiaClassDocumentoTipoFamilia)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia+"\r\n";
                foreach (Entidades.OrdemCompraDocumentoEnviadoClass tmp in CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia+"\r\n";
                foreach (Entidades.OrdemProducaoDocumentoClass tmp in CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia+"\r\n";
                foreach (Entidades.ProdutoDocumentoTipoClass tmp in CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia)
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
        public static DocumentoTipoFamiliaClass CopiarEntidade(DocumentoTipoFamiliaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DocumentoTipoFamiliaClass toRet = new DocumentoTipoFamiliaClass(usuario,conn);
 toRet.DocumentoTipo= entidadeCopiar.DocumentoTipo;
 toRet.FamiliaDocumento= entidadeCopiar.FamiliaDocumento;
 toRet.TipoValidacao= entidadeCopiar.TipoValidacao;
 toRet.DocumentoPedidoFamilia= entidadeCopiar.DocumentoPedidoFamilia;
 toRet.DocumentoPedido= entidadeCopiar.DocumentoPedido;
 toRet.DocumentoPedidoRevisao= entidadeCopiar.DocumentoPedidoRevisao;
 toRet.Documento= entidadeCopiar.Documento;
 toRet.DocumentoNome= entidadeCopiar.DocumentoNome;
 toRet.Bloqueado= entidadeCopiar.Bloqueado;
 toRet.AcsUsuarioBloqueio= entidadeCopiar.AcsUsuarioBloqueio;
 toRet.BloqueioData= entidadeCopiar.BloqueioData;

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
       _documentoTipoOriginal = DocumentoTipo;
       _documentoTipoOriginalCommited = _documentoTipoOriginal;
       _familiaDocumentoOriginal = FamiliaDocumento;
       _familiaDocumentoOriginalCommited = _familiaDocumentoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _tipoValidacaoOriginal = TipoValidacao;
       _tipoValidacaoOriginalCommited = _tipoValidacaoOriginal;
       _documentoPedidoFamiliaOriginal = DocumentoPedidoFamilia;
       _documentoPedidoFamiliaOriginalCommited = _documentoPedidoFamiliaOriginal;
       _documentoPedidoOriginal = DocumentoPedido;
       _documentoPedidoOriginalCommited = _documentoPedidoOriginal;
       _documentoPedidoRevisaoOriginal = DocumentoPedidoRevisao;
       _documentoPedidoRevisaoOriginalCommited = _documentoPedidoRevisaoOriginal;
       _documentoNomeOriginal = DocumentoNome;
       _documentoNomeOriginalCommited = _documentoNomeOriginal;
       _bloqueadoOriginal = Bloqueado;
       _bloqueadoOriginalCommited = _bloqueadoOriginal;
       _acsUsuarioBloqueioOriginal = AcsUsuarioBloqueio;
       _acsUsuarioBloqueioOriginalCommited = _acsUsuarioBloqueioOriginal;
       _bloqueioDataOriginal = BloqueioData;
       _bloqueioDataOriginalCommited = _bloqueioDataOriginal;

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
       _documentoTipoOriginalCommited = DocumentoTipo;
       _familiaDocumentoOriginalCommited = FamiliaDocumento;
       _versionOriginalCommited = Version;
       _tipoValidacaoOriginalCommited = TipoValidacao;
       _documentoPedidoFamiliaOriginalCommited = DocumentoPedidoFamilia;
       _documentoPedidoOriginalCommited = DocumentoPedido;
       _documentoPedidoRevisaoOriginalCommited = DocumentoPedidoRevisao;
       _documentoNomeOriginalCommited = DocumentoNome;
       _bloqueadoOriginalCommited = Bloqueado;
       _acsUsuarioBloqueioOriginalCommited = AcsUsuarioBloqueio;
       _bloqueioDataOriginalCommited = BloqueioData;

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
               if (DocumentoLoaded)
               {
                  if(this._valueDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _documentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                     }
                  } 
                  else 
                  { 
                        _documentoOriginal = null ;
                  } 
               }
               if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_collectionDocumentoCopiaClassDocumentoTipoFamiliaRemovidos != null) 
                  {
                     _collectionDocumentoCopiaClassDocumentoTipoFamiliaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionDocumentoCopiaClassDocumentoTipoFamiliaRemovidos = new List<Entidades.DocumentoCopiaClass>();
                  }
                  _collectionDocumentoCopiaClassDocumentoTipoFamiliaOriginal= (from a in _valueCollectionDocumentoCopiaClassDocumentoTipoFamilia select a.ID).ToList();
                  _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaChanged = false;
                  _valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaCommitedChanged = false;
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaRemovidos != null) 
                  {
                     _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaRemovidos = new List<Entidades.OrdemCompraDocumentoEnviadoClass>();
                  }
                  _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaOriginal= (from a in _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia select a.ID).ToList();
                  _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaChanged = false;
                  _valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaRemovidos != null) 
                  {
                     _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaRemovidos = new List<Entidades.OrdemProducaoDocumentoClass>();
                  }
                  _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaOriginal= (from a in _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia select a.ID).ToList();
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaChanged = false;
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaCommitedChanged = false;
               }
               if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaRemovidos != null) 
                  {
                     _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaRemovidos = new List<Entidades.ProdutoDocumentoTipoClass>();
                  }
                  _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaOriginal= (from a in _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia select a.ID).ToList();
                  _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaChanged = false;
                  _valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaCommitedChanged = false;
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
               DocumentoTipo=_documentoTipoOriginal;
               _documentoTipoOriginalCommited=_documentoTipoOriginal;
               FamiliaDocumento=_familiaDocumentoOriginal;
               _familiaDocumentoOriginalCommited=_familiaDocumentoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               TipoValidacao=_tipoValidacaoOriginal;
               _tipoValidacaoOriginalCommited=_tipoValidacaoOriginal;
               DocumentoPedidoFamilia=_documentoPedidoFamiliaOriginal;
               _documentoPedidoFamiliaOriginalCommited=_documentoPedidoFamiliaOriginal;
               DocumentoPedido=_documentoPedidoOriginal;
               _documentoPedidoOriginalCommited=_documentoPedidoOriginal;
               DocumentoPedidoRevisao=_documentoPedidoRevisaoOriginal;
               _documentoPedidoRevisaoOriginalCommited=_documentoPedidoRevisaoOriginal;
               DocumentoLoaded = false;
               this._documentoOriginal = null;
               this._documentoOriginalCommited = null;
               this._valueDocumento = null;
               DocumentoNome=_documentoNomeOriginal;
               _documentoNomeOriginalCommited=_documentoNomeOriginal;
               Bloqueado=_bloqueadoOriginal;
               _bloqueadoOriginalCommited=_bloqueadoOriginal;
               AcsUsuarioBloqueio=_acsUsuarioBloqueioOriginal;
               _acsUsuarioBloqueioOriginalCommited=_acsUsuarioBloqueioOriginal;
               BloqueioData=_bloqueioDataOriginal;
               _bloqueioDataOriginalCommited=_bloqueioDataOriginal;
               if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded) 
               {
                  CollectionDocumentoCopiaClassDocumentoTipoFamilia.Clear();
                  foreach(int item in _collectionDocumentoCopiaClassDocumentoTipoFamiliaOriginal)
                  {
                    CollectionDocumentoCopiaClassDocumentoTipoFamilia.Add(Entidades.DocumentoCopiaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionDocumentoCopiaClassDocumentoTipoFamiliaRemovidos.Clear();
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded) 
               {
                  CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia.Clear();
                  foreach(int item in _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaOriginal)
                  {
                    CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia.Add(Entidades.OrdemCompraDocumentoEnviadoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded) 
               {
                  CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia.Clear();
                  foreach(int item in _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaOriginal)
                  {
                    CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia.Add(Entidades.OrdemProducaoDocumentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaRemovidos.Clear();
               }
               if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded) 
               {
                  CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia.Clear();
                  foreach(int item in _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaOriginal)
                  {
                    CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia.Add(Entidades.ProdutoDocumentoTipoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoDocumentoTipoClassDocumentoTipoFamiliaRemovidos.Clear();
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
               if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded) 
               {
                   tempRet = CollectionDocumentoCopiaClassDocumentoTipoFamilia.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded) 
               {
                   tempRet = CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded) 
               {
                   tempRet = CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia.Any(item => item.IsDirty());
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
       if (_documentoTipoOriginal!=null)
       {
          dirty = !_documentoTipoOriginal.Equals(DocumentoTipo);
       }
       else
       {
            dirty = DocumentoTipo != null;
       }
      if (dirty) return true;
       if (_familiaDocumentoOriginal!=null)
       {
          dirty = !_familiaDocumentoOriginal.Equals(FamiliaDocumento);
       }
       else
       {
            dirty = FamiliaDocumento != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _tipoValidacaoOriginal != TipoValidacao;
      if (dirty) return true;
       dirty = _documentoPedidoFamiliaOriginal != DocumentoPedidoFamilia;
      if (dirty) return true;
       dirty = _documentoPedidoOriginal != DocumentoPedido;
      if (dirty) return true;
       dirty = _documentoPedidoRevisaoOriginal != DocumentoPedidoRevisao;
      if (dirty) return true;
               if (DocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpDocumento ;
                      if (this._valueDocumento == null) 
                      { 
                         tmpDocumento = null; 
                      } 
                      else 
                      { 
                         tmpDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                      } 
                       dirty = _documentoOriginal != tmpDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _documentoNomeOriginal != DocumentoNome;
      if (dirty) return true;
       dirty = _bloqueadoOriginal != Bloqueado;
      if (dirty) return true;
       if (_acsUsuarioBloqueioOriginal!=null)
       {
          dirty = !_acsUsuarioBloqueioOriginal.Equals(AcsUsuarioBloqueio);
       }
       else
       {
            dirty = AcsUsuarioBloqueio != null;
       }
      if (dirty) return true;
       dirty = _bloqueioDataOriginal != BloqueioData;

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
               if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded) 
               {
                  if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded) 
               {
                   tempRet = CollectionDocumentoCopiaClassDocumentoTipoFamilia.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded) 
               {
                   tempRet = CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded) 
               {
                   tempRet = CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia.Any(item => item.IsDirtyCommited());
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
       if (_documentoTipoOriginalCommited!=null)
       {
          dirty = !_documentoTipoOriginalCommited.Equals(DocumentoTipo);
       }
       else
       {
            dirty = DocumentoTipo != null;
       }
      if (dirty) return true;
       if (_familiaDocumentoOriginalCommited!=null)
       {
          dirty = !_familiaDocumentoOriginalCommited.Equals(FamiliaDocumento);
       }
       else
       {
            dirty = FamiliaDocumento != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _tipoValidacaoOriginalCommited != TipoValidacao;
      if (dirty) return true;
       dirty = _documentoPedidoFamiliaOriginalCommited != DocumentoPedidoFamilia;
      if (dirty) return true;
       dirty = _documentoPedidoOriginalCommited != DocumentoPedido;
      if (dirty) return true;
       dirty = _documentoPedidoRevisaoOriginalCommited != DocumentoPedidoRevisao;
      if (dirty) return true;
               if (DocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpDocumento ;
                      if (this._valueDocumento == null) 
                      { 
                         tmpDocumento = null; 
                      } 
                      else 
                      { 
                         tmpDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                      } 
                       dirty = _documentoOriginalCommited != tmpDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _documentoNomeOriginalCommited != DocumentoNome;
      if (dirty) return true;
       dirty = _bloqueadoOriginalCommited != Bloqueado;
      if (dirty) return true;
       if (_acsUsuarioBloqueioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioBloqueioOriginalCommited.Equals(AcsUsuarioBloqueio);
       }
       else
       {
            dirty = AcsUsuarioBloqueio != null;
       }
      if (dirty) return true;
       dirty = _bloqueioDataOriginalCommited != BloqueioData;

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
               if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded) 
               {
                  foreach(DocumentoCopiaClass item in CollectionDocumentoCopiaClassDocumentoTipoFamilia)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded) 
               {
                  foreach(OrdemCompraDocumentoEnviadoClass item in CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded) 
               {
                  foreach(OrdemProducaoDocumentoClass item in CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded) 
               {
                  foreach(ProdutoDocumentoTipoClass item in CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia)
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
             case "DocumentoTipo":
                return this.DocumentoTipo;
             case "FamiliaDocumento":
                return this.FamiliaDocumento;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "TipoValidacao":
                return this.TipoValidacao;
             case "DocumentoPedidoFamilia":
                return this.DocumentoPedidoFamilia;
             case "DocumentoPedido":
                return this.DocumentoPedido;
             case "DocumentoPedidoRevisao":
                return this.DocumentoPedidoRevisao;
             case "Documento":
                return this.Documento;
             case "DocumentoNome":
                return this.DocumentoNome;
             case "Bloqueado":
                return this.Bloqueado;
             case "AcsUsuarioBloqueio":
                return this.AcsUsuarioBloqueio;
             case "BloqueioData":
                return this.BloqueioData;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (DocumentoTipo!=null)
                DocumentoTipo.ChangeSingleConnection(newConnection);
             if (FamiliaDocumento!=null)
                FamiliaDocumento.ChangeSingleConnection(newConnection);
             if (AcsUsuarioBloqueio!=null)
                AcsUsuarioBloqueio.ChangeSingleConnection(newConnection);
               if (_valueCollectionDocumentoCopiaClassDocumentoTipoFamiliaLoaded) 
               {
                  foreach(DocumentoCopiaClass item in CollectionDocumentoCopiaClassDocumentoTipoFamilia)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamiliaLoaded) 
               {
                  foreach(OrdemCompraDocumentoEnviadoClass item in CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoTipoFamiliaLoaded) 
               {
                  foreach(OrdemProducaoDocumentoClass item in CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoDocumentoTipoClassDocumentoTipoFamiliaLoaded) 
               {
                  foreach(ProdutoDocumentoTipoClass item in CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia)
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
                  command.CommandText += " COUNT(documento_tipo_familia.id_documento_tipo_familia) " ;
               }
               else
               {
               command.CommandText += "documento_tipo_familia.id_documento_tipo_familia, " ;
               command.CommandText += "documento_tipo_familia.id_documento_tipo, " ;
               command.CommandText += "documento_tipo_familia.id_familia_documento, " ;
               command.CommandText += "documento_tipo_familia.entity_uid, " ;
               command.CommandText += "documento_tipo_familia.version, " ;
               command.CommandText += "documento_tipo_familia.dtf_tipo_validacao, " ;
               command.CommandText += "documento_tipo_familia.dtf_documento_pedido_familia, " ;
               command.CommandText += "documento_tipo_familia.dtf_documento_pedido, " ;
               command.CommandText += "documento_tipo_familia.dtf_documento_pedido_revisao, " ;
               command.CommandText += "documento_tipo_familia.dtf_documento_nome, " ;
               command.CommandText += "documento_tipo_familia.dtf_bloqueado, " ;
               command.CommandText += "documento_tipo_familia.id_acs_usuario_bloqueio, " ;
               command.CommandText += "documento_tipo_familia.dtf_bloqueio_data " ;
               }
               command.CommandText += " FROM  documento_tipo_familia ";
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
                        orderByClause += " , ent_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ent_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = documento_tipo_familia.id_acs_usuario_ultima_revisao ";
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
                     case "id_documento_tipo_familia":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_tipo_familia.id_documento_tipo_familia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo_familia.id_documento_tipo_familia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_documento_tipo":
                     case "DocumentoTipo":
                     command.CommandText += " LEFT JOIN documento_tipo as documento_tipo_DocumentoTipo ON documento_tipo_DocumentoTipo.id_documento_tipo = documento_tipo_familia.id_documento_tipo ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo_DocumentoTipo.dot_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo_DocumentoTipo.dot_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_familia_documento":
                     case "FamiliaDocumento":
                     command.CommandText += " LEFT JOIN familia_documento as familia_documento_FamiliaDocumento ON familia_documento_FamiliaDocumento.id_familia_documento = documento_tipo_familia.id_familia_documento ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_documento_FamiliaDocumento.fad_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_documento_FamiliaDocumento.fad_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo_familia.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo_familia.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , documento_tipo_familia.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo_familia.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dtf_tipo_validacao":
                     case "TipoValidacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_tipo_familia.dtf_tipo_validacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo_familia.dtf_tipo_validacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dtf_documento_pedido_familia":
                     case "DocumentoPedidoFamilia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo_familia.dtf_documento_pedido_familia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo_familia.dtf_documento_pedido_familia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dtf_documento_pedido":
                     case "DocumentoPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo_familia.dtf_documento_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo_familia.dtf_documento_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dtf_documento_pedido_revisao":
                     case "DocumentoPedidoRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo_familia.dtf_documento_pedido_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo_familia.dtf_documento_pedido_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dtf_documento":
                     case "Documento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_tipo_familia.dtf_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo_familia.dtf_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dtf_documento_nome":
                     case "DocumentoNome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo_familia.dtf_documento_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo_familia.dtf_documento_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dtf_bloqueado":
                     case "Bloqueado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_tipo_familia.dtf_bloqueado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo_familia.dtf_bloqueado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_bloqueio":
                     case "AcsUsuarioBloqueio":
                     orderByClause += " , documento_tipo_familia.id_acs_usuario_bloqueio " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "dtf_bloqueio_data":
                     case "BloqueioData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_tipo_familia.dtf_bloqueio_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo_familia.dtf_bloqueio_data) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(documento_tipo_familia.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo_familia.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dtf_documento_pedido_familia")) 
                        {
                           whereClause += " OR UPPER(documento_tipo_familia.dtf_documento_pedido_familia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo_familia.dtf_documento_pedido_familia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dtf_documento_pedido")) 
                        {
                           whereClause += " OR UPPER(documento_tipo_familia.dtf_documento_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo_familia.dtf_documento_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dtf_documento_pedido_revisao")) 
                        {
                           whereClause += " OR UPPER(documento_tipo_familia.dtf_documento_pedido_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo_familia.dtf_documento_pedido_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dtf_documento_nome")) 
                        {
                           whereClause += " OR UPPER(documento_tipo_familia.dtf_documento_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo_familia.dtf_documento_nome) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_documento_tipo_familia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.id_documento_tipo_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.id_documento_tipo_familia = :documento_tipo_familia_ID_9616 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_ID_9616", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoTipo" || parametro.FieldName == "id_documento_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DocumentoTipoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DocumentoTipoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.id_documento_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.id_documento_tipo = :documento_tipo_familia_DocumentoTipo_8238 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_DocumentoTipo_8238", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FamiliaDocumento" || parametro.FieldName == "id_familia_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FamiliaDocumentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FamiliaDocumentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.id_familia_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.id_familia_documento = :documento_tipo_familia_FamiliaDocumento_2722 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_FamiliaDocumento_2722", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  documento_tipo_familia.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.entity_uid LIKE :documento_tipo_familia_EntityUid_9982 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_EntityUid_9982", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  documento_tipo_familia.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.version = :documento_tipo_familia_Version_1733 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_Version_1733", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoValidacao" || parametro.FieldName == "dtf_tipo_validacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoValidacaoDocumento)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoValidacaoDocumento");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_tipo_validacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_tipo_validacao = :documento_tipo_familia_TipoValidacao_4185 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_TipoValidacao_4185", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoPedidoFamilia" || parametro.FieldName == "dtf_documento_pedido_familia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido_familia LIKE :documento_tipo_familia_DocumentoPedidoFamilia_1368 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_DocumentoPedidoFamilia_1368", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoPedido" || parametro.FieldName == "dtf_documento_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido LIKE :documento_tipo_familia_DocumentoPedido_9966 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_DocumentoPedido_9966", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoPedidoRevisao" || parametro.FieldName == "dtf_documento_pedido_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido_revisao LIKE :documento_tipo_familia_DocumentoPedidoRevisao_6468 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_DocumentoPedidoRevisao_6468", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Documento" || parametro.FieldName == "dtf_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento = :documento_tipo_familia_Documento_2193 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_Documento_2193", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoNome" || parametro.FieldName == "dtf_documento_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_nome LIKE :documento_tipo_familia_DocumentoNome_9406 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_DocumentoNome_9406", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Bloqueado" || parametro.FieldName == "dtf_bloqueado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_bloqueado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_bloqueado = :documento_tipo_familia_Bloqueado_9051 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_Bloqueado_9051", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioBloqueio" || parametro.FieldName == "id_acs_usuario_bloqueio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.id_acs_usuario_bloqueio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.id_acs_usuario_bloqueio = :documento_tipo_familia_AcsUsuarioBloqueio_1482 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_AcsUsuarioBloqueio_1482", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BloqueioData" || parametro.FieldName == "dtf_bloqueio_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_bloqueio_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_bloqueio_data = :documento_tipo_familia_BloqueioData_2675 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_BloqueioData_2675", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  documento_tipo_familia.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.entity_uid LIKE :documento_tipo_familia_EntityUid_6803 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_EntityUid_6803", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoPedidoFamiliaExato" || parametro.FieldName == "DocumentoPedidoFamiliaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido_familia LIKE :documento_tipo_familia_DocumentoPedidoFamilia_3400 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_DocumentoPedidoFamilia_3400", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoPedidoExato" || parametro.FieldName == "DocumentoPedidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido LIKE :documento_tipo_familia_DocumentoPedido_352 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_DocumentoPedido_352", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoPedidoRevisaoExato" || parametro.FieldName == "DocumentoPedidoRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_pedido_revisao LIKE :documento_tipo_familia_DocumentoPedidoRevisao_9980 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_DocumentoPedidoRevisao_9980", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoNomeExato" || parametro.FieldName == "DocumentoNomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo_familia.dtf_documento_nome LIKE :documento_tipo_familia_DocumentoNome_9892 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_familia_DocumentoNome_9892", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DocumentoTipoFamiliaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DocumentoTipoFamiliaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DocumentoTipoFamiliaClass), Convert.ToInt32(read["id_documento_tipo_familia"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DocumentoTipoFamiliaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_documento_tipo_familia"]);
                     if (read["id_documento_tipo"] != DBNull.Value)
                     {
                        entidade.DocumentoTipo = (BibliotecaEntidades.Entidades.DocumentoTipoClass)BibliotecaEntidades.Entidades.DocumentoTipoClass.GetEntidade(Convert.ToInt32(read["id_documento_tipo"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DocumentoTipo = null ;
                     }
                     if (read["id_familia_documento"] != DBNull.Value)
                     {
                        entidade.FamiliaDocumento = (BibliotecaEntidades.Entidades.FamiliaDocumentoClass)BibliotecaEntidades.Entidades.FamiliaDocumentoClass.GetEntidade(Convert.ToInt32(read["id_familia_documento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FamiliaDocumento = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.TipoValidacao = (TipoValidacaoDocumento) (read["dtf_tipo_validacao"] != DBNull.Value ? Enum.ToObject(typeof(TipoValidacaoDocumento), read["dtf_tipo_validacao"]) : null);
                     entidade.DocumentoPedidoFamilia = (read["dtf_documento_pedido_familia"] != DBNull.Value ? read["dtf_documento_pedido_familia"].ToString() : null);
                     entidade.DocumentoPedido = (read["dtf_documento_pedido"] != DBNull.Value ? read["dtf_documento_pedido"].ToString() : null);
                     entidade.DocumentoPedidoRevisao = (read["dtf_documento_pedido_revisao"] != DBNull.Value ? read["dtf_documento_pedido_revisao"].ToString() : null);
                     entidade.DocumentoNome = (read["dtf_documento_nome"] != DBNull.Value ? read["dtf_documento_nome"].ToString() : null);
                     entidade.Bloqueado = Convert.ToBoolean(Convert.ToInt16(read["dtf_bloqueado"]));
                     if (read["id_acs_usuario_bloqueio"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioBloqueio = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_bloqueio"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioBloqueio = null ;
                     }
                     entidade.BloqueioData = read["dtf_bloqueio_data"] as DateTime?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DocumentoTipoFamiliaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
