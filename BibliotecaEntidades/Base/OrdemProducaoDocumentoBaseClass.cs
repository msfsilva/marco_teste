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
     [Table("ordem_producao_documento","opd")]
     public class OrdemProducaoDocumentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoDocumentoClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoDocumentoClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoDocumentoClass.";
protected const string ErroCollectionLiberacaoDocumentoClassOrdemProducaoDocumento = "Erro ao carregar a coleção de LiberacaoDocumentoClass.";
protected const string ErroCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento = "Erro ao carregar a coleção de OrdemProducaoDocumentoOpClass.";
protected const string ErroDocumentoDescricaoObrigatorio = "O campo DocumentoDescricao é obrigatório";
protected const string ErroDocumentoDescricaoComprimento = "O campo DocumentoDescricao deve ter no máximo 255 caracteres";
protected const string ErroDocumentoCopia2Obrigatorio = "O campo DocumentoCopia2 é obrigatório";
protected const string ErroDocumentoCopia2Comprimento = "O campo DocumentoCopia2 deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroDocumentoCopiaObrigatorio = "O campo DocumentoCopia é obrigatório";
protected const string ErroDocumentoTipoFamiliaObrigatorio = "O campo DocumentoTipoFamilia é obrigatório";
protected const string ErroOrdemProducaoGrupoObrigatorio = "O campo OrdemProducaoGrupo é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoDocumentoClass.";
protected const string MensagemUtilizadoCollectionLiberacaoDocumentoClassOrdemProducaoDocumento =  "A entidade OrdemProducaoDocumentoClass está sendo utilizada nos seguintes LiberacaoDocumentoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento =  "A entidade OrdemProducaoDocumentoClass está sendo utilizada nos seguintes OrdemProducaoDocumentoOpClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoDocumentoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.DocumentoCopiaClass _documentoCopiaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.DocumentoCopiaClass _documentoCopiaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DocumentoCopiaClass _valueDocumentoCopia;
        [Column("id_documento_copia", "documento_copia", "id_documento_copia")]
       public virtual BibliotecaEntidades.Entidades.DocumentoCopiaClass DocumentoCopia
        { 
           get {                 return this._valueDocumentoCopia; } 
           set 
           { 
                if (this._valueDocumentoCopia == value)return;
                 this._valueDocumentoCopia = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass _documentoTipoFamiliaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass _documentoTipoFamiliaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass _valueDocumentoTipoFamilia;
        [Column("id_documento_tipo_familia", "documento_tipo_familia", "id_documento_tipo_familia")]
       public virtual BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass DocumentoTipoFamilia
        { 
           get {                 return this._valueDocumentoTipoFamilia; } 
           set 
           { 
                if (this._valueDocumentoTipoFamilia == value)return;
                 this._valueDocumentoTipoFamilia = value; 
           } 
       } 

       protected string _documentoDescricaoOriginal{get;private set;}
       private string _documentoDescricaoOriginalCommited{get; set;}
        private string _valueDocumentoDescricao;
         [Column("opd_documento_descricao")]
        public virtual string DocumentoDescricao
         { 
            get { return this._valueDocumentoDescricao; } 
            set 
            { 
                if (this._valueDocumentoDescricao == value)return;
                 this._valueDocumentoDescricao = value; 
            } 
        } 

       protected string _documentoCopia2Original{get;private set;}
       private string _documentoCopia2OriginalCommited{get; set;}
        private string _valueDocumentoCopia2;
         [Column("opd_documento_copia")]
        public virtual string DocumentoCopia2
         { 
            get { return this._valueDocumentoCopia2; } 
            set 
            { 
                if (this._valueDocumentoCopia2 == value)return;
                 this._valueDocumentoCopia2 = value; 
            } 
        } 

       protected string _documentoTipoCodigoOriginal{get;private set;}
       private string _documentoTipoCodigoOriginalCommited{get; set;}
        private string _valueDocumentoTipoCodigo;
         [Column("opd_documento_tipo_codigo")]
        public virtual string DocumentoTipoCodigo
         { 
            get { return this._valueDocumentoTipoCodigo; } 
            set 
            { 
                if (this._valueDocumentoTipoCodigo == value)return;
                 this._valueDocumentoTipoCodigo = value; 
            } 
        } 

       protected string _documentoTipoTipoOriginal{get;private set;}
       private string _documentoTipoTipoOriginalCommited{get; set;}
        private string _valueDocumentoTipoTipo;
         [Column("opd_documento_tipo_tipo")]
        public virtual string DocumentoTipoTipo
         { 
            get { return this._valueDocumentoTipoTipo; } 
            set 
            { 
                if (this._valueDocumentoTipoTipo == value)return;
                 this._valueDocumentoTipoTipo = value; 
            } 
        } 

       protected string _documentoTipoRevisaoOriginal{get;private set;}
       private string _documentoTipoRevisaoOriginalCommited{get; set;}
        private string _valueDocumentoTipoRevisao;
         [Column("opd_documento_tipo_revisao")]
        public virtual string DocumentoTipoRevisao
         { 
            get { return this._valueDocumentoTipoRevisao; } 
            set 
            { 
                if (this._valueDocumentoTipoRevisao == value)return;
                 this._valueDocumentoTipoRevisao = value; 
            } 
        } 

       protected string _documentoL1Original{get;private set;}
       private string _documentoL1OriginalCommited{get; set;}
        private string _valueDocumentoL1;
         [Column("opd_documento_l1")]
        public virtual string DocumentoL1
         { 
            get { return this._valueDocumentoL1; } 
            set 
            { 
                if (this._valueDocumentoL1 == value)return;
                 this._valueDocumentoL1 = value; 
            } 
        } 

       protected string _documentoL2Original{get;private set;}
       private string _documentoL2OriginalCommited{get; set;}
        private string _valueDocumentoL2;
         [Column("opd_documento_l2")]
        public virtual string DocumentoL2
         { 
            get { return this._valueDocumentoL2; } 
            set 
            { 
                if (this._valueDocumentoL2 == value)return;
                 this._valueDocumentoL2 = value; 
            } 
        } 

       protected string _documentoL3Original{get;private set;}
       private string _documentoL3OriginalCommited{get; set;}
        private string _valueDocumentoL3;
         [Column("opd_documento_l3")]
        public virtual string DocumentoL3
         { 
            get { return this._valueDocumentoL3; } 
            set 
            { 
                if (this._valueDocumentoL3 == value)return;
                 this._valueDocumentoL3 = value; 
            } 
        } 

       protected string _documentoL4Original{get;private set;}
       private string _documentoL4OriginalCommited{get; set;}
        private string _valueDocumentoL4;
         [Column("opd_documento_l4")]
        public virtual string DocumentoL4
         { 
            get { return this._valueDocumentoL4; } 
            set 
            { 
                if (this._valueDocumentoL4 == value)return;
                 this._valueDocumentoL4 = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass _ordemProducaoGrupoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass _ordemProducaoGrupoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass _valueOrdemProducaoGrupo;
        [Column("id_ordem_producao_grupo", "ordem_producao_grupo", "id_ordem_producao_grupo")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass OrdemProducaoGrupo
        { 
           get {                 return this._valueOrdemProducaoGrupo; } 
           set 
           { 
                if (this._valueOrdemProducaoGrupo == value)return;
                 this._valueOrdemProducaoGrupo = value; 
           } 
       } 

       protected TipoValidacaoDocumento _tipoValidacaoOriginal{get;private set;}
       private TipoValidacaoDocumento _tipoValidacaoOriginalCommited{get; set;}
        private TipoValidacaoDocumento _valueTipoValidacao;
         [Column("opd_tipo_validacao")]
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
         [Column("opd_documento_pedido_familia")]
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
         [Column("opd_documento_pedido")]
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
         [Column("opd_documento_pedido_revisao")]
        public virtual string DocumentoPedidoRevisao
         { 
            get { return this._valueDocumentoPedidoRevisao; } 
            set 
            { 
                if (this._valueDocumentoPedidoRevisao == value)return;
                 this._valueDocumentoPedidoRevisao = value; 
            } 
        } 

       protected string _avisoOriginal{get;private set;}
       private string _avisoOriginalCommited{get; set;}
        private string _valueAviso;
         [Column("opd_aviso")]
        public virtual string Aviso
         { 
            get { return this._valueAviso; } 
            set 
            { 
                if (this._valueAviso == value)return;
                 this._valueAviso = value; 
            } 
        } 

       private List<long> _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoOriginal;
       private List<Entidades.LiberacaoDocumentoClass > _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LiberacaoDocumentoClass> _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LiberacaoDocumentoClass> CollectionLiberacaoDocumentoClassOrdemProducaoDocumento 
       { 
           get { if(!_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded && !this.DisableLoadCollection){this.LoadCollectionLiberacaoDocumentoClassOrdemProducaoDocumento();}
return this._valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumento; } 
           set 
           { 
               this._valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumento = value; 
               this._valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoOriginal;
       private List<Entidades.OrdemProducaoDocumentoOpClass > _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoDocumentoOpClass> _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoDocumentoOpClass> CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento 
       { 
           get { if(!_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento();}
return this._valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento; } 
           set 
           { 
               this._valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento = value; 
               this._valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded = true; 
           } 
       } 

        public OrdemProducaoDocumentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.TipoValidacao = (TipoValidacaoDocumento)0;
           this.Aviso = "";
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoDocumentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoDocumentoClass) GetEntity(typeof(OrdemProducaoDocumentoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionLiberacaoDocumentoClassOrdemProducaoDocumentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoChanged = true;
                  _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoChanged = true; 
                  _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoCommitedChanged = true;
                 foreach (Entidades.LiberacaoDocumentoClass item in e.OldItems) 
                 { 
                     _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoChanged = true; 
                  _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoCommitedChanged = true;
                 foreach (Entidades.LiberacaoDocumentoClass item in _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumento) 
                 { 
                     _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLiberacaoDocumentoClassOrdemProducaoDocumento()
         {
            try
            {
                 ObservableCollection<Entidades.LiberacaoDocumentoClass> oc;
                _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoChanged = false;
                 _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoCommitedChanged = false;
                _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoRemovidos = new List<Entidades.LiberacaoDocumentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LiberacaoDocumentoClass>();
                }
                else{ 
                   Entidades.LiberacaoDocumentoClass search = new Entidades.LiberacaoDocumentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LiberacaoDocumentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducaoDocumento", this),                     }                       ).Cast<Entidades.LiberacaoDocumentoClass>().ToList());
                 }
                 _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumento = new BindingList<Entidades.LiberacaoDocumentoClass>(oc); 
                 _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoOriginal= (from a in _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumento select a.ID).ToList();
                 _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded = true;
                 oc.CollectionChanged += CollectionLiberacaoDocumentoClassOrdemProducaoDocumentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLiberacaoDocumentoClassOrdemProducaoDocumento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoChanged = true;
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoOpClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoOpClass item in _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento) 
                 { 
                     _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoDocumentoOpClass> oc;
                _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoChanged = false;
                 _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoCommitedChanged = false;
                _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoRemovidos = new List<Entidades.OrdemProducaoDocumentoOpClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoDocumentoOpClass>();
                }
                else{ 
                   Entidades.OrdemProducaoDocumentoOpClass search = new Entidades.OrdemProducaoDocumentoOpClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoDocumentoOpClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducaoDocumento", this)                    }                       ).Cast<Entidades.OrdemProducaoDocumentoOpClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento = new BindingList<Entidades.OrdemProducaoDocumentoOpClass>(oc); 
                 _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoOriginal= (from a in _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento select a.ID).ToList();
                 _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(DocumentoDescricao))
                {
                    throw new Exception(ErroDocumentoDescricaoObrigatorio);
                }
                if (DocumentoDescricao.Length >255)
                {
                    throw new Exception( ErroDocumentoDescricaoComprimento);
                }
                if (string.IsNullOrEmpty(DocumentoCopia2))
                {
                    throw new Exception(ErroDocumentoCopia2Obrigatorio);
                }
                if (DocumentoCopia2.Length >255)
                {
                    throw new Exception( ErroDocumentoCopia2Comprimento);
                }
                if ( _valueDocumentoCopia == null)
                {
                    throw new Exception(ErroDocumentoCopiaObrigatorio);
                }
                if ( _valueDocumentoTipoFamilia == null)
                {
                    throw new Exception(ErroDocumentoTipoFamiliaObrigatorio);
                }
                if ( _valueOrdemProducaoGrupo == null)
                {
                    throw new Exception(ErroOrdemProducaoGrupoObrigatorio);
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
                    "  public.ordem_producao_documento  " +
                    "WHERE " +
                    "  id_ordem_producao_documento = :id";
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
                        "  public.ordem_producao_documento   " +
                        "SET  " + 
                        "  id_documento_copia = :id_documento_copia, " + 
                        "  id_documento_tipo_familia = :id_documento_tipo_familia, " + 
                        "  opd_documento_descricao = :opd_documento_descricao, " + 
                        "  opd_documento_copia = :opd_documento_copia, " + 
                        "  opd_documento_tipo_codigo = :opd_documento_tipo_codigo, " + 
                        "  opd_documento_tipo_tipo = :opd_documento_tipo_tipo, " + 
                        "  opd_documento_tipo_revisao = :opd_documento_tipo_revisao, " + 
                        "  opd_documento_l1 = :opd_documento_l1, " + 
                        "  opd_documento_l2 = :opd_documento_l2, " + 
                        "  opd_documento_l3 = :opd_documento_l3, " + 
                        "  opd_documento_l4 = :opd_documento_l4, " + 
                        "  id_ordem_producao_grupo = :id_ordem_producao_grupo, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  opd_tipo_validacao = :opd_tipo_validacao, " + 
                        "  opd_documento_pedido_familia = :opd_documento_pedido_familia, " + 
                        "  opd_documento_pedido = :opd_documento_pedido, " + 
                        "  opd_documento_pedido_revisao = :opd_documento_pedido_revisao, " + 
                        "  opd_aviso = :opd_aviso "+
                        "WHERE  " +
                        "  id_ordem_producao_documento = :id " +
                        "RETURNING id_ordem_producao_documento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_documento " +
                        "( " +
                        "  id_documento_copia , " + 
                        "  id_documento_tipo_familia , " + 
                        "  opd_documento_descricao , " + 
                        "  opd_documento_copia , " + 
                        "  opd_documento_tipo_codigo , " + 
                        "  opd_documento_tipo_tipo , " + 
                        "  opd_documento_tipo_revisao , " + 
                        "  opd_documento_l1 , " + 
                        "  opd_documento_l2 , " + 
                        "  opd_documento_l3 , " + 
                        "  opd_documento_l4 , " + 
                        "  id_ordem_producao_grupo , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  opd_tipo_validacao , " + 
                        "  opd_documento_pedido_familia , " + 
                        "  opd_documento_pedido , " + 
                        "  opd_documento_pedido_revisao , " + 
                        "  opd_aviso  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_documento_copia , " + 
                        "  :id_documento_tipo_familia , " + 
                        "  :opd_documento_descricao , " + 
                        "  :opd_documento_copia , " + 
                        "  :opd_documento_tipo_codigo , " + 
                        "  :opd_documento_tipo_tipo , " + 
                        "  :opd_documento_tipo_revisao , " + 
                        "  :opd_documento_l1 , " + 
                        "  :opd_documento_l2 , " + 
                        "  :opd_documento_l3 , " + 
                        "  :opd_documento_l4 , " + 
                        "  :id_ordem_producao_grupo , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :opd_tipo_validacao , " + 
                        "  :opd_documento_pedido_familia , " + 
                        "  :opd_documento_pedido , " + 
                        "  :opd_documento_pedido_revisao , " + 
                        "  :opd_aviso  "+
                        ")RETURNING id_ordem_producao_documento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_copia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DocumentoCopia==null ? (object) DBNull.Value : this.DocumentoCopia.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_tipo_familia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DocumentoTipoFamilia==null ? (object) DBNull.Value : this.DocumentoTipoFamilia.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoDescricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_copia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoCopia2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_tipo_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoTipoCodigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_tipo_tipo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoTipoTipo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_tipo_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoTipoRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_l1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoL1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_l2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoL2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_l3", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoL3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_l4", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoL4 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_grupo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducaoGrupo==null ? (object) DBNull.Value : this.OrdemProducaoGrupo.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_tipo_validacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoValidacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_pedido_familia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoPedidoFamilia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_pedido_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoPedidoRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_aviso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aviso ?? DBNull.Value;

 
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
 if (CollectionLiberacaoDocumentoClassOrdemProducaoDocumento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLiberacaoDocumentoClassOrdemProducaoDocumento+"\r\n";
                foreach (Entidades.LiberacaoDocumentoClass tmp in CollectionLiberacaoDocumentoClassOrdemProducaoDocumento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento+"\r\n";
                foreach (Entidades.OrdemProducaoDocumentoOpClass tmp in CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento)
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
        public static OrdemProducaoDocumentoClass CopiarEntidade(OrdemProducaoDocumentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoDocumentoClass toRet = new OrdemProducaoDocumentoClass(usuario,conn);
 toRet.DocumentoCopia= entidadeCopiar.DocumentoCopia;
 toRet.DocumentoTipoFamilia= entidadeCopiar.DocumentoTipoFamilia;
 toRet.DocumentoDescricao= entidadeCopiar.DocumentoDescricao;
 toRet.DocumentoCopia2= entidadeCopiar.DocumentoCopia2;
 toRet.DocumentoTipoCodigo= entidadeCopiar.DocumentoTipoCodigo;
 toRet.DocumentoTipoTipo= entidadeCopiar.DocumentoTipoTipo;
 toRet.DocumentoTipoRevisao= entidadeCopiar.DocumentoTipoRevisao;
 toRet.DocumentoL1= entidadeCopiar.DocumentoL1;
 toRet.DocumentoL2= entidadeCopiar.DocumentoL2;
 toRet.DocumentoL3= entidadeCopiar.DocumentoL3;
 toRet.DocumentoL4= entidadeCopiar.DocumentoL4;
 toRet.OrdemProducaoGrupo= entidadeCopiar.OrdemProducaoGrupo;
 toRet.TipoValidacao= entidadeCopiar.TipoValidacao;
 toRet.DocumentoPedidoFamilia= entidadeCopiar.DocumentoPedidoFamilia;
 toRet.DocumentoPedido= entidadeCopiar.DocumentoPedido;
 toRet.DocumentoPedidoRevisao= entidadeCopiar.DocumentoPedidoRevisao;
 toRet.Aviso= entidadeCopiar.Aviso;

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
       _documentoCopiaOriginal = DocumentoCopia;
       _documentoCopiaOriginalCommited = _documentoCopiaOriginal;
       _documentoTipoFamiliaOriginal = DocumentoTipoFamilia;
       _documentoTipoFamiliaOriginalCommited = _documentoTipoFamiliaOriginal;
       _documentoDescricaoOriginal = DocumentoDescricao;
       _documentoDescricaoOriginalCommited = _documentoDescricaoOriginal;
       _documentoCopia2Original = DocumentoCopia2;
       _documentoCopia2OriginalCommited = _documentoCopia2Original;
       _documentoTipoCodigoOriginal = DocumentoTipoCodigo;
       _documentoTipoCodigoOriginalCommited = _documentoTipoCodigoOriginal;
       _documentoTipoTipoOriginal = DocumentoTipoTipo;
       _documentoTipoTipoOriginalCommited = _documentoTipoTipoOriginal;
       _documentoTipoRevisaoOriginal = DocumentoTipoRevisao;
       _documentoTipoRevisaoOriginalCommited = _documentoTipoRevisaoOriginal;
       _documentoL1Original = DocumentoL1;
       _documentoL1OriginalCommited = _documentoL1Original;
       _documentoL2Original = DocumentoL2;
       _documentoL2OriginalCommited = _documentoL2Original;
       _documentoL3Original = DocumentoL3;
       _documentoL3OriginalCommited = _documentoL3Original;
       _documentoL4Original = DocumentoL4;
       _documentoL4OriginalCommited = _documentoL4Original;
       _ordemProducaoGrupoOriginal = OrdemProducaoGrupo;
       _ordemProducaoGrupoOriginalCommited = _ordemProducaoGrupoOriginal;
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
       _avisoOriginal = Aviso;
       _avisoOriginalCommited = _avisoOriginal;

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
       _documentoCopiaOriginalCommited = DocumentoCopia;
       _documentoTipoFamiliaOriginalCommited = DocumentoTipoFamilia;
       _documentoDescricaoOriginalCommited = DocumentoDescricao;
       _documentoCopia2OriginalCommited = DocumentoCopia2;
       _documentoTipoCodigoOriginalCommited = DocumentoTipoCodigo;
       _documentoTipoTipoOriginalCommited = DocumentoTipoTipo;
       _documentoTipoRevisaoOriginalCommited = DocumentoTipoRevisao;
       _documentoL1OriginalCommited = DocumentoL1;
       _documentoL2OriginalCommited = DocumentoL2;
       _documentoL3OriginalCommited = DocumentoL3;
       _documentoL4OriginalCommited = DocumentoL4;
       _ordemProducaoGrupoOriginalCommited = OrdemProducaoGrupo;
       _versionOriginalCommited = Version;
       _tipoValidacaoOriginalCommited = TipoValidacao;
       _documentoPedidoFamiliaOriginalCommited = DocumentoPedidoFamilia;
       _documentoPedidoOriginalCommited = DocumentoPedido;
       _documentoPedidoRevisaoOriginalCommited = DocumentoPedidoRevisao;
       _avisoOriginalCommited = Aviso;

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
               if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded) 
               {
                  if (_collectionLiberacaoDocumentoClassOrdemProducaoDocumentoRemovidos != null) 
                  {
                     _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoRemovidos = new List<Entidades.LiberacaoDocumentoClass>();
                  }
                  _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoOriginal= (from a in _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumento select a.ID).ToList();
                  _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoChanged = false;
                  _valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded) 
               {
                  if (_collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoRemovidos != null) 
                  {
                     _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoRemovidos = new List<Entidades.OrdemProducaoDocumentoOpClass>();
                  }
                  _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoOriginal= (from a in _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento select a.ID).ToList();
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoChanged = false;
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoCommitedChanged = false;
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
               DocumentoCopia=_documentoCopiaOriginal;
               _documentoCopiaOriginalCommited=_documentoCopiaOriginal;
               DocumentoTipoFamilia=_documentoTipoFamiliaOriginal;
               _documentoTipoFamiliaOriginalCommited=_documentoTipoFamiliaOriginal;
               DocumentoDescricao=_documentoDescricaoOriginal;
               _documentoDescricaoOriginalCommited=_documentoDescricaoOriginal;
               DocumentoCopia2=_documentoCopia2Original;
               _documentoCopia2OriginalCommited=_documentoCopia2Original;
               DocumentoTipoCodigo=_documentoTipoCodigoOriginal;
               _documentoTipoCodigoOriginalCommited=_documentoTipoCodigoOriginal;
               DocumentoTipoTipo=_documentoTipoTipoOriginal;
               _documentoTipoTipoOriginalCommited=_documentoTipoTipoOriginal;
               DocumentoTipoRevisao=_documentoTipoRevisaoOriginal;
               _documentoTipoRevisaoOriginalCommited=_documentoTipoRevisaoOriginal;
               DocumentoL1=_documentoL1Original;
               _documentoL1OriginalCommited=_documentoL1Original;
               DocumentoL2=_documentoL2Original;
               _documentoL2OriginalCommited=_documentoL2Original;
               DocumentoL3=_documentoL3Original;
               _documentoL3OriginalCommited=_documentoL3Original;
               DocumentoL4=_documentoL4Original;
               _documentoL4OriginalCommited=_documentoL4Original;
               OrdemProducaoGrupo=_ordemProducaoGrupoOriginal;
               _ordemProducaoGrupoOriginalCommited=_ordemProducaoGrupoOriginal;
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
               Aviso=_avisoOriginal;
               _avisoOriginalCommited=_avisoOriginal;
               if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded) 
               {
                  CollectionLiberacaoDocumentoClassOrdemProducaoDocumento.Clear();
                  foreach(int item in _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoOriginal)
                  {
                    CollectionLiberacaoDocumentoClassOrdemProducaoDocumento.Add(Entidades.LiberacaoDocumentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLiberacaoDocumentoClassOrdemProducaoDocumentoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded) 
               {
                  CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento.Clear();
                  foreach(int item in _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoOriginal)
                  {
                    CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento.Add(Entidades.OrdemProducaoDocumentoOpClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoRemovidos.Clear();
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
               if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded) 
               {
                  if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded) 
               {
                   tempRet = CollectionLiberacaoDocumentoClassOrdemProducaoDocumento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento.Any(item => item.IsDirty());
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
       if (_documentoCopiaOriginal!=null)
       {
          dirty = !_documentoCopiaOriginal.Equals(DocumentoCopia);
       }
       else
       {
            dirty = DocumentoCopia != null;
       }
      if (dirty) return true;
       if (_documentoTipoFamiliaOriginal!=null)
       {
          dirty = !_documentoTipoFamiliaOriginal.Equals(DocumentoTipoFamilia);
       }
       else
       {
            dirty = DocumentoTipoFamilia != null;
       }
      if (dirty) return true;
       dirty = _documentoDescricaoOriginal != DocumentoDescricao;
      if (dirty) return true;
       dirty = _documentoCopia2Original != DocumentoCopia2;
      if (dirty) return true;
       dirty = _documentoTipoCodigoOriginal != DocumentoTipoCodigo;
      if (dirty) return true;
       dirty = _documentoTipoTipoOriginal != DocumentoTipoTipo;
      if (dirty) return true;
       dirty = _documentoTipoRevisaoOriginal != DocumentoTipoRevisao;
      if (dirty) return true;
       dirty = _documentoL1Original != DocumentoL1;
      if (dirty) return true;
       dirty = _documentoL2Original != DocumentoL2;
      if (dirty) return true;
       dirty = _documentoL3Original != DocumentoL3;
      if (dirty) return true;
       dirty = _documentoL4Original != DocumentoL4;
      if (dirty) return true;
       if (_ordemProducaoGrupoOriginal!=null)
       {
          dirty = !_ordemProducaoGrupoOriginal.Equals(OrdemProducaoGrupo);
       }
       else
       {
            dirty = OrdemProducaoGrupo != null;
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
       dirty = _avisoOriginal != Aviso;

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
               if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded) 
               {
                  if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded) 
               {
                   tempRet = CollectionLiberacaoDocumentoClassOrdemProducaoDocumento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento.Any(item => item.IsDirtyCommited());
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
       if (_documentoCopiaOriginalCommited!=null)
       {
          dirty = !_documentoCopiaOriginalCommited.Equals(DocumentoCopia);
       }
       else
       {
            dirty = DocumentoCopia != null;
       }
      if (dirty) return true;
       if (_documentoTipoFamiliaOriginalCommited!=null)
       {
          dirty = !_documentoTipoFamiliaOriginalCommited.Equals(DocumentoTipoFamilia);
       }
       else
       {
            dirty = DocumentoTipoFamilia != null;
       }
      if (dirty) return true;
       dirty = _documentoDescricaoOriginalCommited != DocumentoDescricao;
      if (dirty) return true;
       dirty = _documentoCopia2OriginalCommited != DocumentoCopia2;
      if (dirty) return true;
       dirty = _documentoTipoCodigoOriginalCommited != DocumentoTipoCodigo;
      if (dirty) return true;
       dirty = _documentoTipoTipoOriginalCommited != DocumentoTipoTipo;
      if (dirty) return true;
       dirty = _documentoTipoRevisaoOriginalCommited != DocumentoTipoRevisao;
      if (dirty) return true;
       dirty = _documentoL1OriginalCommited != DocumentoL1;
      if (dirty) return true;
       dirty = _documentoL2OriginalCommited != DocumentoL2;
      if (dirty) return true;
       dirty = _documentoL3OriginalCommited != DocumentoL3;
      if (dirty) return true;
       dirty = _documentoL4OriginalCommited != DocumentoL4;
      if (dirty) return true;
       if (_ordemProducaoGrupoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoGrupoOriginalCommited.Equals(OrdemProducaoGrupo);
       }
       else
       {
            dirty = OrdemProducaoGrupo != null;
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
       dirty = _avisoOriginalCommited != Aviso;

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
               if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded) 
               {
                  foreach(LiberacaoDocumentoClass item in CollectionLiberacaoDocumentoClassOrdemProducaoDocumento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded) 
               {
                  foreach(OrdemProducaoDocumentoOpClass item in CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento)
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
             case "DocumentoCopia":
                return this.DocumentoCopia;
             case "DocumentoTipoFamilia":
                return this.DocumentoTipoFamilia;
             case "DocumentoDescricao":
                return this.DocumentoDescricao;
             case "DocumentoCopia2":
                return this.DocumentoCopia2;
             case "DocumentoTipoCodigo":
                return this.DocumentoTipoCodigo;
             case "DocumentoTipoTipo":
                return this.DocumentoTipoTipo;
             case "DocumentoTipoRevisao":
                return this.DocumentoTipoRevisao;
             case "DocumentoL1":
                return this.DocumentoL1;
             case "DocumentoL2":
                return this.DocumentoL2;
             case "DocumentoL3":
                return this.DocumentoL3;
             case "DocumentoL4":
                return this.DocumentoL4;
             case "OrdemProducaoGrupo":
                return this.OrdemProducaoGrupo;
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
             case "Aviso":
                return this.Aviso;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (DocumentoCopia!=null)
                DocumentoCopia.ChangeSingleConnection(newConnection);
             if (DocumentoTipoFamilia!=null)
                DocumentoTipoFamilia.ChangeSingleConnection(newConnection);
             if (OrdemProducaoGrupo!=null)
                OrdemProducaoGrupo.ChangeSingleConnection(newConnection);
               if (_valueCollectionLiberacaoDocumentoClassOrdemProducaoDocumentoLoaded) 
               {
                  foreach(LiberacaoDocumentoClass item in CollectionLiberacaoDocumentoClassOrdemProducaoDocumento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumentoLoaded) 
               {
                  foreach(OrdemProducaoDocumentoOpClass item in CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento)
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
                  command.CommandText += " COUNT(ordem_producao_documento.id_ordem_producao_documento) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_documento.id_ordem_producao_documento, " ;
               command.CommandText += "ordem_producao_documento.id_documento_copia, " ;
               command.CommandText += "ordem_producao_documento.id_documento_tipo_familia, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_descricao, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_copia, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_tipo_codigo, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_tipo_tipo, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_tipo_revisao, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_l1, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_l2, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_l3, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_l4, " ;
               command.CommandText += "ordem_producao_documento.id_ordem_producao_grupo, " ;
               command.CommandText += "ordem_producao_documento.entity_uid, " ;
               command.CommandText += "ordem_producao_documento.version, " ;
               command.CommandText += "ordem_producao_documento.opd_tipo_validacao, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_pedido_familia, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_pedido, " ;
               command.CommandText += "ordem_producao_documento.opd_documento_pedido_revisao, " ;
               command.CommandText += "ordem_producao_documento.opd_aviso " ;
               }
               command.CommandText += " FROM  ordem_producao_documento ";
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
                        orderByClause += " , opd_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(opd_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_documento.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_documento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_documento.id_ordem_producao_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_documento.id_ordem_producao_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_documento_copia":
                     case "DocumentoCopia":
                     command.CommandText += " LEFT JOIN documento_copia as documento_copia_DocumentoCopia ON documento_copia_DocumentoCopia.id_documento_copia = ordem_producao_documento.id_documento_copia ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_copia_DocumentoCopia.doc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_copia_DocumentoCopia.doc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_documento_tipo_familia":
                     case "DocumentoTipoFamilia":
                     command.CommandText += " LEFT JOIN documento_tipo_familia as documento_tipo_familia_DocumentoTipoFamilia ON documento_tipo_familia_DocumentoTipoFamilia.id_documento_tipo_familia = ordem_producao_documento.id_documento_tipo_familia ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_tipo_familia_DocumentoTipoFamilia.id_documento_tipo_familia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo_familia_DocumentoTipoFamilia.id_documento_tipo_familia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_descricao":
                     case "DocumentoDescricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_copia":
                     case "DocumentoCopia2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_copia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_copia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_tipo_codigo":
                     case "DocumentoTipoCodigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_tipo_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_tipo_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_tipo_tipo":
                     case "DocumentoTipoTipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_tipo_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_tipo_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_tipo_revisao":
                     case "DocumentoTipoRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_tipo_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_tipo_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_l1":
                     case "DocumentoL1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_l1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_l1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_l2":
                     case "DocumentoL2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_l2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_l2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_l3":
                     case "DocumentoL3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_l3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_l3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_l4":
                     case "DocumentoL4":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_l4 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_l4) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao_grupo":
                     case "OrdemProducaoGrupo":
                     command.CommandText += " LEFT JOIN ordem_producao_grupo as ordem_producao_grupo_OrdemProducaoGrupo ON ordem_producao_grupo_OrdemProducaoGrupo.id_ordem_producao_grupo = ordem_producao_documento.id_ordem_producao_grupo ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_grupo_OrdemProducaoGrupo.id_ordem_producao_grupo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_grupo_OrdemProducaoGrupo.id_ordem_producao_grupo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_documento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_documento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_tipo_validacao":
                     case "TipoValidacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_documento.opd_tipo_validacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_tipo_validacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_pedido_familia":
                     case "DocumentoPedidoFamilia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_pedido_familia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_pedido_familia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_pedido":
                     case "DocumentoPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_documento_pedido_revisao":
                     case "DocumentoPedidoRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_documento_pedido_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_documento_pedido_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_aviso":
                     case "Aviso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_documento.opd_aviso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_documento.opd_aviso) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_descricao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_copia")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_copia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_copia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_tipo_codigo")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_tipo_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_tipo_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_tipo_tipo")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_tipo_tipo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_tipo_tipo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_tipo_revisao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_tipo_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_tipo_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_l1")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_l1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_l1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_l2")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_l2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_l2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_l3")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_l3) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_l3) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_l4")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_l4) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_l4) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_pedido_familia")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_pedido_familia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_pedido_familia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_pedido")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_documento_pedido_revisao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_documento_pedido_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_documento_pedido_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opd_aviso")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_documento.opd_aviso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_documento.opd_aviso) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.id_ordem_producao_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.id_ordem_producao_documento = :ordem_producao_documento_ID_9137 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_ID_9137", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoCopia" || parametro.FieldName == "id_documento_copia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DocumentoCopiaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DocumentoCopiaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.id_documento_copia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.id_documento_copia = :ordem_producao_documento_DocumentoCopia_6117 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoCopia_6117", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoTipoFamilia" || parametro.FieldName == "id_documento_tipo_familia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.id_documento_tipo_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.id_documento_tipo_familia = :ordem_producao_documento_DocumentoTipoFamilia_7030 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoTipoFamilia_7030", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoDescricao" || parametro.FieldName == "opd_documento_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_descricao LIKE :ordem_producao_documento_DocumentoDescricao_1215 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoDescricao_1215", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoCopia2" || parametro.FieldName == "opd_documento_copia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_copia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_copia LIKE :ordem_producao_documento_DocumentoCopia2_9002 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoCopia2_9002", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoTipoCodigo" || parametro.FieldName == "opd_documento_tipo_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_codigo LIKE :ordem_producao_documento_DocumentoTipoCodigo_8456 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoTipoCodigo_8456", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoTipoTipo" || parametro.FieldName == "opd_documento_tipo_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_tipo LIKE :ordem_producao_documento_DocumentoTipoTipo_4151 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoTipoTipo_4151", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoTipoRevisao" || parametro.FieldName == "opd_documento_tipo_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_revisao LIKE :ordem_producao_documento_DocumentoTipoRevisao_6029 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoTipoRevisao_6029", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoL1" || parametro.FieldName == "opd_documento_l1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l1 LIKE :ordem_producao_documento_DocumentoL1_8636 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoL1_8636", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoL2" || parametro.FieldName == "opd_documento_l2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l2 LIKE :ordem_producao_documento_DocumentoL2_4611 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoL2_4611", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoL3" || parametro.FieldName == "opd_documento_l3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l3 LIKE :ordem_producao_documento_DocumentoL3_3979 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoL3_3979", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoL4" || parametro.FieldName == "opd_documento_l4")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l4 LIKE :ordem_producao_documento_DocumentoL4_8672 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoL4_8672", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoGrupo" || parametro.FieldName == "id_ordem_producao_grupo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.id_ordem_producao_grupo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.id_ordem_producao_grupo = :ordem_producao_documento_OrdemProducaoGrupo_3312 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_OrdemProducaoGrupo_3312", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_documento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.entity_uid LIKE :ordem_producao_documento_EntityUid_7086 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_EntityUid_7086", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_documento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.version = :ordem_producao_documento_Version_9699 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_Version_9699", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoValidacao" || parametro.FieldName == "opd_tipo_validacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoValidacaoDocumento)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoValidacaoDocumento");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_tipo_validacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_tipo_validacao = :ordem_producao_documento_TipoValidacao_7109 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_TipoValidacao_7109", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoPedidoFamilia" || parametro.FieldName == "opd_documento_pedido_familia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_pedido_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_pedido_familia LIKE :ordem_producao_documento_DocumentoPedidoFamilia_6833 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoPedidoFamilia_6833", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoPedido" || parametro.FieldName == "opd_documento_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_pedido LIKE :ordem_producao_documento_DocumentoPedido_6355 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoPedido_6355", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoPedidoRevisao" || parametro.FieldName == "opd_documento_pedido_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_pedido_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_pedido_revisao LIKE :ordem_producao_documento_DocumentoPedidoRevisao_1594 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoPedidoRevisao_1594", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aviso" || parametro.FieldName == "opd_aviso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_aviso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_aviso LIKE :ordem_producao_documento_Aviso_5952 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_Aviso_5952", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoDescricaoExato" || parametro.FieldName == "DocumentoDescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_descricao LIKE :ordem_producao_documento_DocumentoDescricao_9370 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoDescricao_9370", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoCopia2Exato" || parametro.FieldName == "DocumentoCopia2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_copia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_copia LIKE :ordem_producao_documento_DocumentoCopia2_4041 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoCopia2_4041", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoTipoCodigoExato" || parametro.FieldName == "DocumentoTipoCodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_codigo LIKE :ordem_producao_documento_DocumentoTipoCodigo_5620 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoTipoCodigo_5620", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoTipoTipoExato" || parametro.FieldName == "DocumentoTipoTipoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_tipo LIKE :ordem_producao_documento_DocumentoTipoTipo_63 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoTipoTipo_63", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoTipoRevisaoExato" || parametro.FieldName == "DocumentoTipoRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_tipo_revisao LIKE :ordem_producao_documento_DocumentoTipoRevisao_3041 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoTipoRevisao_3041", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoL1Exato" || parametro.FieldName == "DocumentoL1Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l1 LIKE :ordem_producao_documento_DocumentoL1_6021 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoL1_6021", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoL2Exato" || parametro.FieldName == "DocumentoL2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l2 LIKE :ordem_producao_documento_DocumentoL2_5060 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoL2_5060", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoL3Exato" || parametro.FieldName == "DocumentoL3Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l3 LIKE :ordem_producao_documento_DocumentoL3_3166 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoL3_3166", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoL4Exato" || parametro.FieldName == "DocumentoL4Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_l4 LIKE :ordem_producao_documento_DocumentoL4_3541 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoL4_3541", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao_documento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.entity_uid LIKE :ordem_producao_documento_EntityUid_1042 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_EntityUid_1042", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao_documento.opd_documento_pedido_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_pedido_familia LIKE :ordem_producao_documento_DocumentoPedidoFamilia_6479 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoPedidoFamilia_6479", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao_documento.opd_documento_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_pedido LIKE :ordem_producao_documento_DocumentoPedido_8548 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoPedido_8548", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao_documento.opd_documento_pedido_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_documento_pedido_revisao LIKE :ordem_producao_documento_DocumentoPedidoRevisao_8294 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_DocumentoPedidoRevisao_8294", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AvisoExato" || parametro.FieldName == "AvisoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_documento.opd_aviso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_documento.opd_aviso LIKE :ordem_producao_documento_Aviso_7808 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_documento_Aviso_7808", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoDocumentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoDocumentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoDocumentoClass), Convert.ToInt32(read["id_ordem_producao_documento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoDocumentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_documento"]);
                     if (read["id_documento_copia"] != DBNull.Value)
                     {
                        entidade.DocumentoCopia = (BibliotecaEntidades.Entidades.DocumentoCopiaClass)BibliotecaEntidades.Entidades.DocumentoCopiaClass.GetEntidade(Convert.ToInt32(read["id_documento_copia"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DocumentoCopia = null ;
                     }
                     if (read["id_documento_tipo_familia"] != DBNull.Value)
                     {
                        entidade.DocumentoTipoFamilia = (BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass)BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass.GetEntidade(Convert.ToInt32(read["id_documento_tipo_familia"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DocumentoTipoFamilia = null ;
                     }
                     entidade.DocumentoDescricao = (read["opd_documento_descricao"] != DBNull.Value ? read["opd_documento_descricao"].ToString() : null);
                     entidade.DocumentoCopia2 = (read["opd_documento_copia"] != DBNull.Value ? read["opd_documento_copia"].ToString() : null);
                     entidade.DocumentoTipoCodigo = (read["opd_documento_tipo_codigo"] != DBNull.Value ? read["opd_documento_tipo_codigo"].ToString() : null);
                     entidade.DocumentoTipoTipo = (read["opd_documento_tipo_tipo"] != DBNull.Value ? read["opd_documento_tipo_tipo"].ToString() : null);
                     entidade.DocumentoTipoRevisao = (read["opd_documento_tipo_revisao"] != DBNull.Value ? read["opd_documento_tipo_revisao"].ToString() : null);
                     entidade.DocumentoL1 = (read["opd_documento_l1"] != DBNull.Value ? read["opd_documento_l1"].ToString() : null);
                     entidade.DocumentoL2 = (read["opd_documento_l2"] != DBNull.Value ? read["opd_documento_l2"].ToString() : null);
                     entidade.DocumentoL3 = (read["opd_documento_l3"] != DBNull.Value ? read["opd_documento_l3"].ToString() : null);
                     entidade.DocumentoL4 = (read["opd_documento_l4"] != DBNull.Value ? read["opd_documento_l4"].ToString() : null);
                     if (read["id_ordem_producao_grupo"] != DBNull.Value)
                     {
                        entidade.OrdemProducaoGrupo = (BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass)BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao_grupo"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducaoGrupo = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.TipoValidacao = (TipoValidacaoDocumento) (read["opd_tipo_validacao"] != DBNull.Value ? Enum.ToObject(typeof(TipoValidacaoDocumento), read["opd_tipo_validacao"]) : null);
                     entidade.DocumentoPedidoFamilia = (read["opd_documento_pedido_familia"] != DBNull.Value ? read["opd_documento_pedido_familia"].ToString() : null);
                     entidade.DocumentoPedido = (read["opd_documento_pedido"] != DBNull.Value ? read["opd_documento_pedido"].ToString() : null);
                     entidade.DocumentoPedidoRevisao = (read["opd_documento_pedido_revisao"] != DBNull.Value ? read["opd_documento_pedido_revisao"].ToString() : null);
                     entidade.Aviso = (read["opd_aviso"] != DBNull.Value ? read["opd_aviso"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoDocumentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
