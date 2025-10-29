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
     [Table("documento_copia","doc")]
     public class DocumentoCopiaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DocumentoCopiaClass";
protected const string ErroDelete = "Erro ao excluir o DocumentoCopiaClass  ";
protected const string ErroSave = "Erro ao salvar o DocumentoCopiaClass.";
protected const string ErroCollectionEstoqueGavetaItemClassDocumentoCopia = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected const string ErroCollectionLiberacaoDocumentoClassDocumentoCopia = "Erro ao carregar a coleção de LiberacaoDocumentoClass.";
protected const string ErroCollectionOrdemProducaoDocumentoClassDocumentoCopia = "Erro ao carregar a coleção de OrdemProducaoDocumentoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do DocumentoCopiaClass.";
protected const string MensagemUtilizadoCollectionEstoqueGavetaItemClassDocumentoCopia =  "A entidade DocumentoCopiaClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected const string MensagemUtilizadoCollectionLiberacaoDocumentoClassDocumentoCopia =  "A entidade DocumentoCopiaClass está sendo utilizada nos seguintes LiberacaoDocumentoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoDocumentoClassDocumentoCopia =  "A entidade DocumentoCopiaClass está sendo utilizada nos seguintes OrdemProducaoDocumentoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DocumentoCopiaClass está sendo utilizada.";
#endregion
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

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("doc_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected DateTime _dataCriacaoOriginal{get;private set;}
       private DateTime _dataCriacaoOriginalCommited{get; set;}
        private DateTime _valueDataCriacao;
         [Column("doc_data_criacao")]
        public virtual DateTime DataCriacao
         { 
            get { return this._valueDataCriacao; } 
            set 
            { 
                if (this._valueDataCriacao == value)return;
                 this._valueDataCriacao = value; 
            } 
        } 

       protected bool _ativaOriginal{get;private set;}
       private bool _ativaOriginalCommited{get; set;}
        private bool _valueAtiva;
         [Column("doc_ativa")]
        public virtual bool Ativa
         { 
            get { return this._valueAtiva; } 
            set 
            { 
                if (this._valueAtiva == value)return;
                 this._valueAtiva = value; 
            } 
        } 

       protected bool _ocupadaOriginal{get;private set;}
       private bool _ocupadaOriginalCommited{get; set;}
        private bool _valueOcupada;
         [Column("doc_ocupada")]
        public virtual bool Ocupada
         { 
            get { return this._valueOcupada; } 
            set 
            { 
                if (this._valueOcupada == value)return;
                 this._valueOcupada = value; 
            } 
        } 

       protected bool _permiteUtilizarOpOriginal{get;private set;}
       private bool _permiteUtilizarOpOriginalCommited{get; set;}
        private bool _valuePermiteUtilizarOp;
         [Column("doc_permite_utilizar_op")]
        public virtual bool PermiteUtilizarOp
         { 
            get { return this._valuePermiteUtilizarOp; } 
            set 
            { 
                if (this._valuePermiteUtilizarOp == value)return;
                 this._valuePermiteUtilizarOp = value; 
            } 
        } 

       protected bool _correcaoBugOcupadoOriginal{get;private set;}
       private bool _correcaoBugOcupadoOriginalCommited{get; set;}
        private bool _valueCorrecaoBugOcupado;
         [Column("doc_correcao_bug_ocupado")]
        public virtual bool CorrecaoBugOcupado
         { 
            get { return this._valueCorrecaoBugOcupado; } 
            set 
            { 
                if (this._valueCorrecaoBugOcupado == value)return;
                 this._valueCorrecaoBugOcupado = value; 
            } 
        } 

       protected bool _etiquetaImpressaOriginal{get;private set;}
       private bool _etiquetaImpressaOriginalCommited{get; set;}
        private bool _valueEtiquetaImpressa;
         [Column("doc_etiqueta_impressa")]
        public virtual bool EtiquetaImpressa
         { 
            get { return this._valueEtiquetaImpressa; } 
            set 
            { 
                if (this._valueEtiquetaImpressa == value)return;
                 this._valueEtiquetaImpressa = value; 
            } 
        } 

       protected DateTime? _dataImpressaoOriginal{get;private set;}
       private DateTime? _dataImpressaoOriginalCommited{get; set;}
        private DateTime? _valueDataImpressao;
         [Column("doc_data_impressao")]
        public virtual DateTime? DataImpressao
         { 
            get { return this._valueDataImpressao; } 
            set 
            { 
                if (this._valueDataImpressao == value)return;
                 this._valueDataImpressao = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioImpressaoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioImpressaoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioImpressao;
        [Column("id_acs_usuario_impressao", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioImpressao
        { 
           get {                 return this._valueAcsUsuarioImpressao; } 
           set 
           { 
                if (this._valueAcsUsuarioImpressao == value)return;
                 this._valueAcsUsuarioImpressao = value; 
           } 
       } 

       private List<long> _collectionEstoqueGavetaItemClassDocumentoCopiaOriginal;
       private List<Entidades.EstoqueGavetaItemClass > _collectionEstoqueGavetaItemClassDocumentoCopiaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassDocumentoCopiaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassDocumentoCopiaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueGavetaItemClass> _valueCollectionEstoqueGavetaItemClassDocumentoCopia { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueGavetaItemClass> CollectionEstoqueGavetaItemClassDocumentoCopia 
       { 
           get { if(!_valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueGavetaItemClassDocumentoCopia();}
return this._valueCollectionEstoqueGavetaItemClassDocumentoCopia; } 
           set 
           { 
               this._valueCollectionEstoqueGavetaItemClassDocumentoCopia = value; 
               this._valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded = true; 
           } 
       } 

       private List<long> _collectionLiberacaoDocumentoClassDocumentoCopiaOriginal;
       private List<Entidades.LiberacaoDocumentoClass > _collectionLiberacaoDocumentoClassDocumentoCopiaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLiberacaoDocumentoClassDocumentoCopiaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLiberacaoDocumentoClassDocumentoCopiaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LiberacaoDocumentoClass> _valueCollectionLiberacaoDocumentoClassDocumentoCopia { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LiberacaoDocumentoClass> CollectionLiberacaoDocumentoClassDocumentoCopia 
       { 
           get { if(!_valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded && !this.DisableLoadCollection){this.LoadCollectionLiberacaoDocumentoClassDocumentoCopia();}
return this._valueCollectionLiberacaoDocumentoClassDocumentoCopia; } 
           set 
           { 
               this._valueCollectionLiberacaoDocumentoClassDocumentoCopia = value; 
               this._valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoDocumentoClassDocumentoCopiaOriginal;
       private List<Entidades.OrdemProducaoDocumentoClass > _collectionOrdemProducaoDocumentoClassDocumentoCopiaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoDocumentoClass> _valueCollectionOrdemProducaoDocumentoClassDocumentoCopia { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoDocumentoClass> CollectionOrdemProducaoDocumentoClassDocumentoCopia 
       { 
           get { if(!_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoDocumentoClassDocumentoCopia();}
return this._valueCollectionOrdemProducaoDocumentoClassDocumentoCopia; } 
           set 
           { 
               this._valueCollectionOrdemProducaoDocumentoClassDocumentoCopia = value; 
               this._valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded = true; 
           } 
       } 

        public DocumentoCopiaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.DataCriacao = Configurations.DataIndependenteClass.GetData();
           this.Ativa = true;
           this.Ocupada = false;
           this.PermiteUtilizarOp = true;
           this.CorrecaoBugOcupado = false;
           this.EtiquetaImpressa = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static DocumentoCopiaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DocumentoCopiaClass) GetEntity(typeof(DocumentoCopiaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEstoqueGavetaItemClassDocumentoCopiaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueGavetaItemClassDocumentoCopiaChanged = true;
                  _valueCollectionEstoqueGavetaItemClassDocumentoCopiaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueGavetaItemClassDocumentoCopiaChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassDocumentoCopiaCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in e.OldItems) 
                 { 
                     _collectionEstoqueGavetaItemClassDocumentoCopiaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueGavetaItemClassDocumentoCopiaChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassDocumentoCopiaCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in _valueCollectionEstoqueGavetaItemClassDocumentoCopia) 
                 { 
                     _collectionEstoqueGavetaItemClassDocumentoCopiaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueGavetaItemClassDocumentoCopia()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueGavetaItemClass> oc;
                _valueCollectionEstoqueGavetaItemClassDocumentoCopiaChanged = false;
                 _valueCollectionEstoqueGavetaItemClassDocumentoCopiaCommitedChanged = false;
                _collectionEstoqueGavetaItemClassDocumentoCopiaRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueGavetaItemClass>();
                }
                else{ 
                   Entidades.EstoqueGavetaItemClass search = new Entidades.EstoqueGavetaItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueGavetaItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DocumentoCopia", this),                     }                       ).Cast<Entidades.EstoqueGavetaItemClass>().ToList());
                 }
                 _valueCollectionEstoqueGavetaItemClassDocumentoCopia = new BindingList<Entidades.EstoqueGavetaItemClass>(oc); 
                 _collectionEstoqueGavetaItemClassDocumentoCopiaOriginal= (from a in _valueCollectionEstoqueGavetaItemClassDocumentoCopia select a.ID).ToList();
                 _valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueGavetaItemClassDocumentoCopiaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueGavetaItemClassDocumentoCopia+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionLiberacaoDocumentoClassDocumentoCopiaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLiberacaoDocumentoClassDocumentoCopiaChanged = true;
                  _valueCollectionLiberacaoDocumentoClassDocumentoCopiaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLiberacaoDocumentoClassDocumentoCopiaChanged = true; 
                  _valueCollectionLiberacaoDocumentoClassDocumentoCopiaCommitedChanged = true;
                 foreach (Entidades.LiberacaoDocumentoClass item in e.OldItems) 
                 { 
                     _collectionLiberacaoDocumentoClassDocumentoCopiaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLiberacaoDocumentoClassDocumentoCopiaChanged = true; 
                  _valueCollectionLiberacaoDocumentoClassDocumentoCopiaCommitedChanged = true;
                 foreach (Entidades.LiberacaoDocumentoClass item in _valueCollectionLiberacaoDocumentoClassDocumentoCopia) 
                 { 
                     _collectionLiberacaoDocumentoClassDocumentoCopiaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLiberacaoDocumentoClassDocumentoCopia()
         {
            try
            {
                 ObservableCollection<Entidades.LiberacaoDocumentoClass> oc;
                _valueCollectionLiberacaoDocumentoClassDocumentoCopiaChanged = false;
                 _valueCollectionLiberacaoDocumentoClassDocumentoCopiaCommitedChanged = false;
                _collectionLiberacaoDocumentoClassDocumentoCopiaRemovidos = new List<Entidades.LiberacaoDocumentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LiberacaoDocumentoClass>();
                }
                else{ 
                   Entidades.LiberacaoDocumentoClass search = new Entidades.LiberacaoDocumentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LiberacaoDocumentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DocumentoCopia", this),                     }                       ).Cast<Entidades.LiberacaoDocumentoClass>().ToList());
                 }
                 _valueCollectionLiberacaoDocumentoClassDocumentoCopia = new BindingList<Entidades.LiberacaoDocumentoClass>(oc); 
                 _collectionLiberacaoDocumentoClassDocumentoCopiaOriginal= (from a in _valueCollectionLiberacaoDocumentoClassDocumentoCopia select a.ID).ToList();
                 _valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded = true;
                 oc.CollectionChanged += CollectionLiberacaoDocumentoClassDocumentoCopiaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLiberacaoDocumentoClassDocumentoCopia+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoDocumentoClassDocumentoCopiaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaChanged = true;
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoDocumentoClassDocumentoCopiaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoClass item in _valueCollectionOrdemProducaoDocumentoClassDocumentoCopia) 
                 { 
                     _collectionOrdemProducaoDocumentoClassDocumentoCopiaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoDocumentoClassDocumentoCopia()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoDocumentoClass> oc;
                _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaChanged = false;
                 _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaCommitedChanged = false;
                _collectionOrdemProducaoDocumentoClassDocumentoCopiaRemovidos = new List<Entidades.OrdemProducaoDocumentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoDocumentoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoDocumentoClass search = new Entidades.OrdemProducaoDocumentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoDocumentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DocumentoCopia", this),                     }                       ).Cast<Entidades.OrdemProducaoDocumentoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoDocumentoClassDocumentoCopia = new BindingList<Entidades.OrdemProducaoDocumentoClass>(oc); 
                 _collectionOrdemProducaoDocumentoClassDocumentoCopiaOriginal= (from a in _valueCollectionOrdemProducaoDocumentoClassDocumentoCopia select a.ID).ToList();
                 _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoDocumentoClassDocumentoCopiaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoDocumentoClassDocumentoCopia+"\r\n" + e.Message, e);
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
                    "  public.documento_copia  " +
                    "WHERE " +
                    "  id_documento_copia = :id";
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
                        "  public.documento_copia   " +
                        "SET  " + 
                        "  id_documento_tipo_familia = :id_documento_tipo_familia, " + 
                        "  doc_identificacao = :doc_identificacao, " + 
                        "  doc_data_criacao = :doc_data_criacao, " + 
                        "  doc_ativa = :doc_ativa, " + 
                        "  doc_ocupada = :doc_ocupada, " + 
                        "  doc_permite_utilizar_op = :doc_permite_utilizar_op, " + 
                        "  doc_correcao_bug_ocupado = :doc_correcao_bug_ocupado, " + 
                        "  doc_etiqueta_impressa = :doc_etiqueta_impressa, " + 
                        "  doc_data_impressao = :doc_data_impressao, " + 
                        "  id_acs_usuario_impressao = :id_acs_usuario_impressao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_documento_copia = :id " +
                        "RETURNING id_documento_copia;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.documento_copia " +
                        "( " +
                        "  id_documento_tipo_familia , " + 
                        "  doc_identificacao , " + 
                        "  doc_data_criacao , " + 
                        "  doc_ativa , " + 
                        "  doc_ocupada , " + 
                        "  doc_permite_utilizar_op , " + 
                        "  doc_correcao_bug_ocupado , " + 
                        "  doc_etiqueta_impressa , " + 
                        "  doc_data_impressao , " + 
                        "  id_acs_usuario_impressao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_documento_tipo_familia , " + 
                        "  :doc_identificacao , " + 
                        "  :doc_data_criacao , " + 
                        "  :doc_ativa , " + 
                        "  :doc_ocupada , " + 
                        "  :doc_permite_utilizar_op , " + 
                        "  :doc_correcao_bug_ocupado , " + 
                        "  :doc_etiqueta_impressa , " + 
                        "  :doc_data_impressao , " + 
                        "  :id_acs_usuario_impressao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_documento_copia;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_tipo_familia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DocumentoTipoFamilia==null ? (object) DBNull.Value : this.DocumentoTipoFamilia.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("doc_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("doc_data_criacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCriacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("doc_ativa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("doc_ocupada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ocupada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("doc_permite_utilizar_op", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PermiteUtilizarOp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("doc_correcao_bug_ocupado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CorrecaoBugOcupado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("doc_etiqueta_impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaImpressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("doc_data_impressao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataImpressao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_impressao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioImpressao==null ? (object) DBNull.Value : this.AcsUsuarioImpressao.ID;
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
 if (CollectionEstoqueGavetaItemClassDocumentoCopia.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueGavetaItemClassDocumentoCopia+"\r\n";
                foreach (Entidades.EstoqueGavetaItemClass tmp in CollectionEstoqueGavetaItemClassDocumentoCopia)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionLiberacaoDocumentoClassDocumentoCopia.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLiberacaoDocumentoClassDocumentoCopia+"\r\n";
                foreach (Entidades.LiberacaoDocumentoClass tmp in CollectionLiberacaoDocumentoClassDocumentoCopia)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoDocumentoClassDocumentoCopia.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoDocumentoClassDocumentoCopia+"\r\n";
                foreach (Entidades.OrdemProducaoDocumentoClass tmp in CollectionOrdemProducaoDocumentoClassDocumentoCopia)
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
        public static DocumentoCopiaClass CopiarEntidade(DocumentoCopiaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DocumentoCopiaClass toRet = new DocumentoCopiaClass(usuario,conn);
 toRet.DocumentoTipoFamilia= entidadeCopiar.DocumentoTipoFamilia;
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.DataCriacao= entidadeCopiar.DataCriacao;
 toRet.Ativa= entidadeCopiar.Ativa;
 toRet.Ocupada= entidadeCopiar.Ocupada;
 toRet.PermiteUtilizarOp= entidadeCopiar.PermiteUtilizarOp;
 toRet.CorrecaoBugOcupado= entidadeCopiar.CorrecaoBugOcupado;
 toRet.EtiquetaImpressa= entidadeCopiar.EtiquetaImpressa;
 toRet.DataImpressao= entidadeCopiar.DataImpressao;
 toRet.AcsUsuarioImpressao= entidadeCopiar.AcsUsuarioImpressao;

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
       _documentoTipoFamiliaOriginal = DocumentoTipoFamilia;
       _documentoTipoFamiliaOriginalCommited = _documentoTipoFamiliaOriginal;
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _dataCriacaoOriginal = DataCriacao;
       _dataCriacaoOriginalCommited = _dataCriacaoOriginal;
       _ativaOriginal = Ativa;
       _ativaOriginalCommited = _ativaOriginal;
       _ocupadaOriginal = Ocupada;
       _ocupadaOriginalCommited = _ocupadaOriginal;
       _permiteUtilizarOpOriginal = PermiteUtilizarOp;
       _permiteUtilizarOpOriginalCommited = _permiteUtilizarOpOriginal;
       _correcaoBugOcupadoOriginal = CorrecaoBugOcupado;
       _correcaoBugOcupadoOriginalCommited = _correcaoBugOcupadoOriginal;
       _etiquetaImpressaOriginal = EtiquetaImpressa;
       _etiquetaImpressaOriginalCommited = _etiquetaImpressaOriginal;
       _dataImpressaoOriginal = DataImpressao;
       _dataImpressaoOriginalCommited = _dataImpressaoOriginal;
       _acsUsuarioImpressaoOriginal = AcsUsuarioImpressao;
       _acsUsuarioImpressaoOriginalCommited = _acsUsuarioImpressaoOriginal;
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
       _documentoTipoFamiliaOriginalCommited = DocumentoTipoFamilia;
       _identificacaoOriginalCommited = Identificacao;
       _dataCriacaoOriginalCommited = DataCriacao;
       _ativaOriginalCommited = Ativa;
       _ocupadaOriginalCommited = Ocupada;
       _permiteUtilizarOpOriginalCommited = PermiteUtilizarOp;
       _correcaoBugOcupadoOriginalCommited = CorrecaoBugOcupado;
       _etiquetaImpressaOriginalCommited = EtiquetaImpressa;
       _dataImpressaoOriginalCommited = DataImpressao;
       _acsUsuarioImpressaoOriginalCommited = AcsUsuarioImpressao;
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
               if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded) 
               {
                  if (_collectionEstoqueGavetaItemClassDocumentoCopiaRemovidos != null) 
                  {
                     _collectionEstoqueGavetaItemClassDocumentoCopiaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueGavetaItemClassDocumentoCopiaRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                  }
                  _collectionEstoqueGavetaItemClassDocumentoCopiaOriginal= (from a in _valueCollectionEstoqueGavetaItemClassDocumentoCopia select a.ID).ToList();
                  _valueCollectionEstoqueGavetaItemClassDocumentoCopiaChanged = false;
                  _valueCollectionEstoqueGavetaItemClassDocumentoCopiaCommitedChanged = false;
               }
               if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  if (_collectionLiberacaoDocumentoClassDocumentoCopiaRemovidos != null) 
                  {
                     _collectionLiberacaoDocumentoClassDocumentoCopiaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLiberacaoDocumentoClassDocumentoCopiaRemovidos = new List<Entidades.LiberacaoDocumentoClass>();
                  }
                  _collectionLiberacaoDocumentoClassDocumentoCopiaOriginal= (from a in _valueCollectionLiberacaoDocumentoClassDocumentoCopia select a.ID).ToList();
                  _valueCollectionLiberacaoDocumentoClassDocumentoCopiaChanged = false;
                  _valueCollectionLiberacaoDocumentoClassDocumentoCopiaCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  if (_collectionOrdemProducaoDocumentoClassDocumentoCopiaRemovidos != null) 
                  {
                     _collectionOrdemProducaoDocumentoClassDocumentoCopiaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoDocumentoClassDocumentoCopiaRemovidos = new List<Entidades.OrdemProducaoDocumentoClass>();
                  }
                  _collectionOrdemProducaoDocumentoClassDocumentoCopiaOriginal= (from a in _valueCollectionOrdemProducaoDocumentoClassDocumentoCopia select a.ID).ToList();
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaChanged = false;
                  _valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaCommitedChanged = false;
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
               DocumentoTipoFamilia=_documentoTipoFamiliaOriginal;
               _documentoTipoFamiliaOriginalCommited=_documentoTipoFamiliaOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               DataCriacao=_dataCriacaoOriginal;
               _dataCriacaoOriginalCommited=_dataCriacaoOriginal;
               Ativa=_ativaOriginal;
               _ativaOriginalCommited=_ativaOriginal;
               Ocupada=_ocupadaOriginal;
               _ocupadaOriginalCommited=_ocupadaOriginal;
               PermiteUtilizarOp=_permiteUtilizarOpOriginal;
               _permiteUtilizarOpOriginalCommited=_permiteUtilizarOpOriginal;
               CorrecaoBugOcupado=_correcaoBugOcupadoOriginal;
               _correcaoBugOcupadoOriginalCommited=_correcaoBugOcupadoOriginal;
               EtiquetaImpressa=_etiquetaImpressaOriginal;
               _etiquetaImpressaOriginalCommited=_etiquetaImpressaOriginal;
               DataImpressao=_dataImpressaoOriginal;
               _dataImpressaoOriginalCommited=_dataImpressaoOriginal;
               AcsUsuarioImpressao=_acsUsuarioImpressaoOriginal;
               _acsUsuarioImpressaoOriginalCommited=_acsUsuarioImpressaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded) 
               {
                  CollectionEstoqueGavetaItemClassDocumentoCopia.Clear();
                  foreach(int item in _collectionEstoqueGavetaItemClassDocumentoCopiaOriginal)
                  {
                    CollectionEstoqueGavetaItemClassDocumentoCopia.Add(Entidades.EstoqueGavetaItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueGavetaItemClassDocumentoCopiaRemovidos.Clear();
               }
               if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  CollectionLiberacaoDocumentoClassDocumentoCopia.Clear();
                  foreach(int item in _collectionLiberacaoDocumentoClassDocumentoCopiaOriginal)
                  {
                    CollectionLiberacaoDocumentoClassDocumentoCopia.Add(Entidades.LiberacaoDocumentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLiberacaoDocumentoClassDocumentoCopiaRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  CollectionOrdemProducaoDocumentoClassDocumentoCopia.Clear();
                  foreach(int item in _collectionOrdemProducaoDocumentoClassDocumentoCopiaOriginal)
                  {
                    CollectionOrdemProducaoDocumentoClassDocumentoCopia.Add(Entidades.OrdemProducaoDocumentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoDocumentoClassDocumentoCopiaRemovidos.Clear();
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
               if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassDocumentoCopia.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded) 
               {
                   tempRet = CollectionLiberacaoDocumentoClassDocumentoCopia.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoClassDocumentoCopia.Any(item => item.IsDirty());
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
       if (_documentoTipoFamiliaOriginal!=null)
       {
          dirty = !_documentoTipoFamiliaOriginal.Equals(DocumentoTipoFamilia);
       }
       else
       {
            dirty = DocumentoTipoFamilia != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _dataCriacaoOriginal != DataCriacao;
      if (dirty) return true;
       dirty = _ativaOriginal != Ativa;
      if (dirty) return true;
       dirty = _ocupadaOriginal != Ocupada;
      if (dirty) return true;
       dirty = _permiteUtilizarOpOriginal != PermiteUtilizarOp;
      if (dirty) return true;
       dirty = _correcaoBugOcupadoOriginal != CorrecaoBugOcupado;
      if (dirty) return true;
       dirty = _etiquetaImpressaOriginal != EtiquetaImpressa;
      if (dirty) return true;
       dirty = _dataImpressaoOriginal != DataImpressao;
      if (dirty) return true;
       if (_acsUsuarioImpressaoOriginal!=null)
       {
          dirty = !_acsUsuarioImpressaoOriginal.Equals(AcsUsuarioImpressao);
       }
       else
       {
            dirty = AcsUsuarioImpressao != null;
       }
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
               if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassDocumentoCopia.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded) 
               {
                   tempRet = CollectionLiberacaoDocumentoClassDocumentoCopia.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoClassDocumentoCopia.Any(item => item.IsDirtyCommited());
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
       if (_documentoTipoFamiliaOriginalCommited!=null)
       {
          dirty = !_documentoTipoFamiliaOriginalCommited.Equals(DocumentoTipoFamilia);
       }
       else
       {
            dirty = DocumentoTipoFamilia != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _dataCriacaoOriginalCommited != DataCriacao;
      if (dirty) return true;
       dirty = _ativaOriginalCommited != Ativa;
      if (dirty) return true;
       dirty = _ocupadaOriginalCommited != Ocupada;
      if (dirty) return true;
       dirty = _permiteUtilizarOpOriginalCommited != PermiteUtilizarOp;
      if (dirty) return true;
       dirty = _correcaoBugOcupadoOriginalCommited != CorrecaoBugOcupado;
      if (dirty) return true;
       dirty = _etiquetaImpressaOriginalCommited != EtiquetaImpressa;
      if (dirty) return true;
       dirty = _dataImpressaoOriginalCommited != DataImpressao;
      if (dirty) return true;
       if (_acsUsuarioImpressaoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioImpressaoOriginalCommited.Equals(AcsUsuarioImpressao);
       }
       else
       {
            dirty = AcsUsuarioImpressao != null;
       }
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
               if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassDocumentoCopia)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  foreach(LiberacaoDocumentoClass item in CollectionLiberacaoDocumentoClassDocumentoCopia)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  foreach(OrdemProducaoDocumentoClass item in CollectionOrdemProducaoDocumentoClassDocumentoCopia)
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
             case "DocumentoTipoFamilia":
                return this.DocumentoTipoFamilia;
             case "Identificacao":
                return this.Identificacao;
             case "DataCriacao":
                return this.DataCriacao;
             case "Ativa":
                return this.Ativa;
             case "Ocupada":
                return this.Ocupada;
             case "PermiteUtilizarOp":
                return this.PermiteUtilizarOp;
             case "CorrecaoBugOcupado":
                return this.CorrecaoBugOcupado;
             case "EtiquetaImpressa":
                return this.EtiquetaImpressa;
             case "DataImpressao":
                return this.DataImpressao;
             case "AcsUsuarioImpressao":
                return this.AcsUsuarioImpressao;
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
             if (DocumentoTipoFamilia!=null)
                DocumentoTipoFamilia.ChangeSingleConnection(newConnection);
             if (AcsUsuarioImpressao!=null)
                AcsUsuarioImpressao.ChangeSingleConnection(newConnection);
               if (_valueCollectionEstoqueGavetaItemClassDocumentoCopiaLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassDocumentoCopia)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionLiberacaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  foreach(LiberacaoDocumentoClass item in CollectionLiberacaoDocumentoClassDocumentoCopia)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassDocumentoCopiaLoaded) 
               {
                  foreach(OrdemProducaoDocumentoClass item in CollectionOrdemProducaoDocumentoClassDocumentoCopia)
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
                  command.CommandText += " COUNT(documento_copia.id_documento_copia) " ;
               }
               else
               {
               command.CommandText += "documento_copia.id_documento_copia, " ;
               command.CommandText += "documento_copia.id_documento_tipo_familia, " ;
               command.CommandText += "documento_copia.doc_identificacao, " ;
               command.CommandText += "documento_copia.doc_data_criacao, " ;
               command.CommandText += "documento_copia.doc_ativa, " ;
               command.CommandText += "documento_copia.doc_ocupada, " ;
               command.CommandText += "documento_copia.doc_permite_utilizar_op, " ;
               command.CommandText += "documento_copia.doc_correcao_bug_ocupado, " ;
               command.CommandText += "documento_copia.doc_etiqueta_impressa, " ;
               command.CommandText += "documento_copia.doc_data_impressao, " ;
               command.CommandText += "documento_copia.id_acs_usuario_impressao, " ;
               command.CommandText += "documento_copia.entity_uid, " ;
               command.CommandText += "documento_copia.version " ;
               }
               command.CommandText += " FROM  documento_copia ";
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
                        orderByClause += " , doc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(doc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = documento_copia.id_acs_usuario_ultima_revisao ";
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
                     case "id_documento_copia":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_copia.id_documento_copia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_copia.id_documento_copia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_documento_tipo_familia":
                     case "DocumentoTipoFamilia":
                     command.CommandText += " LEFT JOIN documento_tipo_familia as documento_tipo_familia_DocumentoTipoFamilia ON documento_tipo_familia_DocumentoTipoFamilia.id_documento_tipo_familia = documento_copia.id_documento_tipo_familia ";                     switch (parametro.TipoOrdenacao)
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
                     case "doc_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_copia.doc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_copia.doc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "doc_data_criacao":
                     case "DataCriacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_copia.doc_data_criacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_copia.doc_data_criacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "doc_ativa":
                     case "Ativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_copia.doc_ativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_copia.doc_ativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "doc_ocupada":
                     case "Ocupada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_copia.doc_ocupada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_copia.doc_ocupada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "doc_permite_utilizar_op":
                     case "PermiteUtilizarOp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_copia.doc_permite_utilizar_op " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_copia.doc_permite_utilizar_op) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "doc_correcao_bug_ocupado":
                     case "CorrecaoBugOcupado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_copia.doc_correcao_bug_ocupado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_copia.doc_correcao_bug_ocupado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "doc_etiqueta_impressa":
                     case "EtiquetaImpressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_copia.doc_etiqueta_impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_copia.doc_etiqueta_impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "doc_data_impressao":
                     case "DataImpressao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_copia.doc_data_impressao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_copia.doc_data_impressao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_impressao":
                     case "AcsUsuarioImpressao":
                     orderByClause += " , documento_copia.id_acs_usuario_impressao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_copia.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_copia.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , documento_copia.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_copia.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("doc_identificacao")) 
                        {
                           whereClause += " OR UPPER(documento_copia.doc_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_copia.doc_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(documento_copia.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_copia.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_documento_copia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.id_documento_copia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.id_documento_copia = :documento_copia_ID_490 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_ID_490", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  documento_copia.id_documento_tipo_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.id_documento_tipo_familia = :documento_copia_DocumentoTipoFamilia_3386 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_DocumentoTipoFamilia_3386", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "doc_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.doc_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.doc_identificacao LIKE :documento_copia_Identificacao_2359 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_Identificacao_2359", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCriacao" || parametro.FieldName == "doc_data_criacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.doc_data_criacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.doc_data_criacao = :documento_copia_DataCriacao_5514 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_DataCriacao_5514", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativa" || parametro.FieldName == "doc_ativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.doc_ativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.doc_ativa = :documento_copia_Ativa_7296 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_Ativa_7296", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ocupada" || parametro.FieldName == "doc_ocupada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.doc_ocupada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.doc_ocupada = :documento_copia_Ocupada_3629 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_Ocupada_3629", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PermiteUtilizarOp" || parametro.FieldName == "doc_permite_utilizar_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.doc_permite_utilizar_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.doc_permite_utilizar_op = :documento_copia_PermiteUtilizarOp_9091 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_PermiteUtilizarOp_9091", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CorrecaoBugOcupado" || parametro.FieldName == "doc_correcao_bug_ocupado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.doc_correcao_bug_ocupado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.doc_correcao_bug_ocupado = :documento_copia_CorrecaoBugOcupado_3906 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_CorrecaoBugOcupado_3906", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaImpressa" || parametro.FieldName == "doc_etiqueta_impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.doc_etiqueta_impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.doc_etiqueta_impressa = :documento_copia_EtiquetaImpressa_8526 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_EtiquetaImpressa_8526", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataImpressao" || parametro.FieldName == "doc_data_impressao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.doc_data_impressao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.doc_data_impressao = :documento_copia_DataImpressao_9878 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_DataImpressao_9878", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioImpressao" || parametro.FieldName == "id_acs_usuario_impressao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_copia.id_acs_usuario_impressao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.id_acs_usuario_impressao = :documento_copia_AcsUsuarioImpressao_5267 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_AcsUsuarioImpressao_5267", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  documento_copia.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.entity_uid LIKE :documento_copia_EntityUid_7201 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_EntityUid_7201", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  documento_copia.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.version = :documento_copia_Version_8386 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_Version_8386", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  documento_copia.doc_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.doc_identificacao LIKE :documento_copia_Identificacao_4914 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_Identificacao_4914", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  documento_copia.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_copia.entity_uid LIKE :documento_copia_EntityUid_5821 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_copia_EntityUid_5821", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DocumentoCopiaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DocumentoCopiaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DocumentoCopiaClass), Convert.ToInt32(read["id_documento_copia"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DocumentoCopiaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_documento_copia"]);
                     if (read["id_documento_tipo_familia"] != DBNull.Value)
                     {
                        entidade.DocumentoTipoFamilia = (BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass)BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass.GetEntidade(Convert.ToInt32(read["id_documento_tipo_familia"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DocumentoTipoFamilia = null ;
                     }
                     entidade.Identificacao = (read["doc_identificacao"] != DBNull.Value ? read["doc_identificacao"].ToString() : null);
                     entidade.DataCriacao = (DateTime)read["doc_data_criacao"];
                     entidade.Ativa = Convert.ToBoolean(Convert.ToInt16(read["doc_ativa"]));
                     entidade.Ocupada = Convert.ToBoolean(Convert.ToInt16(read["doc_ocupada"]));
                     entidade.PermiteUtilizarOp = Convert.ToBoolean(Convert.ToInt16(read["doc_permite_utilizar_op"]));
                     entidade.CorrecaoBugOcupado = Convert.ToBoolean(Convert.ToInt16(read["doc_correcao_bug_ocupado"]));
                     entidade.EtiquetaImpressa = Convert.ToBoolean(Convert.ToInt16(read["doc_etiqueta_impressa"]));
                     entidade.DataImpressao = read["doc_data_impressao"] as DateTime?;
                     if (read["id_acs_usuario_impressao"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioImpressao = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_impressao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioImpressao = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DocumentoCopiaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
