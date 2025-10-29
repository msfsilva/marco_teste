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
     [Table("estoque_gaveta_item","egi")]
     public class EstoqueGavetaItemBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EstoqueGavetaItemClass";
protected const string ErroDelete = "Erro ao excluir o EstoqueGavetaItemClass  ";
protected const string ErroSave = "Erro ao salvar o EstoqueGavetaItemClass.";
protected const string ErroCollectionEstoqueMovimentacaoClassEstoqueGavetaItem = "Erro ao carregar a coleção de EstoqueMovimentacaoClass.";
protected const string ErroCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem = "Erro ao carregar a coleção de OrdemProducaoEstoqueClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroEstoqueGavetaObrigatorio = "O campo EstoqueGaveta é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do EstoqueGavetaItemClass.";
protected const string MensagemUtilizadoCollectionEstoqueMovimentacaoClassEstoqueGavetaItem =  "A entidade EstoqueGavetaItemClass está sendo utilizada nos seguintes EstoqueMovimentacaoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem =  "A entidade EstoqueGavetaItemClass está sendo utilizada nos seguintes OrdemProducaoEstoqueClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EstoqueGavetaItemClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _valueEstoqueGaveta;
        [Column("id_estoque_gaveta", "estoque_gaveta", "id_estoque_gaveta")]
       public virtual BibliotecaEntidades.Entidades.EstoqueGavetaClass EstoqueGaveta
        { 
           get {                 return this._valueEstoqueGaveta; } 
           set 
           { 
                if (this._valueEstoqueGaveta == value)return;
                 this._valueEstoqueGaveta = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _valueProduto;
        [Column("id_produto", "produto", "id_produto")]
       public virtual BibliotecaEntidades.Entidades.ProdutoClass Produto
        { 
           get {                 return this._valueProduto; } 
           set 
           { 
                if (this._valueProduto == value)return;
                 this._valueProduto = value; 
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

       protected BibliotecaEntidades.Entidades.RecursoClass _recursoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.RecursoClass _recursoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.RecursoClass _valueRecurso;
        [Column("id_recurso", "recurso", "id_recurso")]
       public virtual BibliotecaEntidades.Entidades.RecursoClass Recurso
        { 
           get {                 return this._valueRecurso; } 
           set 
           { 
                if (this._valueRecurso == value)return;
                 this._valueRecurso = value; 
           } 
       } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("egi_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("egi_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ProdutoKClass _produtoKOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoKClass _produtoKOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoKClass _valueProdutoK;
        [Column("id_produto_k", "produto_k", "id_produto_k")]
       public virtual BibliotecaEntidades.Entidades.ProdutoKClass ProdutoK
        { 
           get {                 return this._valueProdutoK; } 
           set 
           { 
                if (this._valueProdutoK == value)return;
                 this._valueProdutoK = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.EpiClass _epiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EpiClass _epiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EpiClass _valueEpi;
        [Column("id_epi", "epi", "id_epi")]
       public virtual BibliotecaEntidades.Entidades.EpiClass Epi
        { 
           get {                 return this._valueEpi; } 
           set 
           { 
                if (this._valueEpi == value)return;
                 this._valueEpi = value; 
           } 
       } 

       private List<long> _collectionEstoqueMovimentacaoClassEstoqueGavetaItemOriginal;
       private List<Entidades.EstoqueMovimentacaoClass > _collectionEstoqueMovimentacaoClassEstoqueGavetaItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueMovimentacaoClass> _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueMovimentacaoClass> CollectionEstoqueMovimentacaoClassEstoqueGavetaItem 
       { 
           get { if(!_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueMovimentacaoClassEstoqueGavetaItem();}
return this._valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItem; } 
           set 
           { 
               this._valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItem = value; 
               this._valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemOriginal;
       private List<Entidades.OrdemProducaoEstoqueClass > _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEstoqueClass> _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEstoqueClass> CollectionOrdemProducaoEstoqueClassEstoqueGavetaItem 
       { 
           get { if(!_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem();}
return this._valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem = value; 
               this._valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded = true; 
           } 
       } 

        public EstoqueGavetaItemBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Quantidade = 0;
           this.Ativo = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static EstoqueGavetaItemClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EstoqueGavetaItemClass) GetEntity(typeof(EstoqueGavetaItemClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEstoqueMovimentacaoClassEstoqueGavetaItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemChanged = true;
                  _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemChanged = true; 
                  _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemCommitedChanged = true;
                 foreach (Entidades.EstoqueMovimentacaoClass item in e.OldItems) 
                 { 
                     _collectionEstoqueMovimentacaoClassEstoqueGavetaItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemChanged = true; 
                  _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemCommitedChanged = true;
                 foreach (Entidades.EstoqueMovimentacaoClass item in _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItem) 
                 { 
                     _collectionEstoqueMovimentacaoClassEstoqueGavetaItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueMovimentacaoClassEstoqueGavetaItem()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueMovimentacaoClass> oc;
                _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemChanged = false;
                 _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemCommitedChanged = false;
                _collectionEstoqueMovimentacaoClassEstoqueGavetaItemRemovidos = new List<Entidades.EstoqueMovimentacaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueMovimentacaoClass>();
                }
                else{ 
                   Entidades.EstoqueMovimentacaoClass search = new Entidades.EstoqueMovimentacaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueMovimentacaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstoqueGavetaItem", this),                     }                       ).Cast<Entidades.EstoqueMovimentacaoClass>().ToList());
                 }
                 _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItem = new BindingList<Entidades.EstoqueMovimentacaoClass>(oc); 
                 _collectionEstoqueMovimentacaoClassEstoqueGavetaItemOriginal= (from a in _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItem select a.ID).ToList();
                 _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueMovimentacaoClassEstoqueGavetaItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueMovimentacaoClassEstoqueGavetaItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEstoqueClassEstoqueGavetaItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemChanged = true;
                  _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemChanged = true; 
                  _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEstoqueClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemChanged = true; 
                  _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEstoqueClass item in _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem) 
                 { 
                     _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEstoqueClass> oc;
                _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemChanged = false;
                 _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemCommitedChanged = false;
                _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemRemovidos = new List<Entidades.OrdemProducaoEstoqueClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEstoqueClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEstoqueClass search = new Entidades.OrdemProducaoEstoqueClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEstoqueClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstoqueGavetaItem", this),                     }                       ).Cast<Entidades.OrdemProducaoEstoqueClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem = new BindingList<Entidades.OrdemProducaoEstoqueClass>(oc); 
                 _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemOriginal= (from a in _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem select a.ID).ToList();
                 _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEstoqueClassEstoqueGavetaItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueEstoqueGaveta == null)
                {
                    throw new Exception(ErroEstoqueGavetaObrigatorio);
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
                    "  public.estoque_gaveta_item  " +
                    "WHERE " +
                    "  id_estoque_gaveta_item = :id";
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
                        "  public.estoque_gaveta_item   " +
                        "SET  " + 
                        "  id_estoque_gaveta = :id_estoque_gaveta, " + 
                        "  id_produto = :id_produto, " + 
                        "  id_material = :id_material, " + 
                        "  id_documento_copia = :id_documento_copia, " + 
                        "  id_recurso = :id_recurso, " + 
                        "  egi_quantidade = :egi_quantidade, " + 
                        "  egi_ativo = :egi_ativo, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_produto_k = :id_produto_k, " + 
                        "  id_epi = :id_epi "+
                        "WHERE  " +
                        "  id_estoque_gaveta_item = :id " +
                        "RETURNING id_estoque_gaveta_item;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.estoque_gaveta_item " +
                        "( " +
                        "  id_estoque_gaveta , " + 
                        "  id_produto , " + 
                        "  id_material , " + 
                        "  id_documento_copia , " + 
                        "  id_recurso , " + 
                        "  egi_quantidade , " + 
                        "  egi_ativo , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_produto_k , " + 
                        "  id_epi  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_estoque_gaveta , " + 
                        "  :id_produto , " + 
                        "  :id_material , " + 
                        "  :id_documento_copia , " + 
                        "  :id_recurso , " + 
                        "  :egi_quantidade , " + 
                        "  :egi_ativo , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_produto_k , " + 
                        "  :id_epi  "+
                        ")RETURNING id_estoque_gaveta_item;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstoqueGaveta==null ? (object) DBNull.Value : this.EstoqueGaveta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_copia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DocumentoCopia==null ? (object) DBNull.Value : this.DocumentoCopia.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_recurso", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Recurso==null ? (object) DBNull.Value : this.Recurso.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("egi_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("egi_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ProdutoK==null ? (object) DBNull.Value : this.ProdutoK.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Epi==null ? (object) DBNull.Value : this.Epi.ID;

 
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
 if (CollectionEstoqueMovimentacaoClassEstoqueGavetaItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueMovimentacaoClassEstoqueGavetaItem+"\r\n";
                foreach (Entidades.EstoqueMovimentacaoClass tmp in CollectionEstoqueMovimentacaoClassEstoqueGavetaItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEstoqueClassEstoqueGavetaItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem+"\r\n";
                foreach (Entidades.OrdemProducaoEstoqueClass tmp in CollectionOrdemProducaoEstoqueClassEstoqueGavetaItem)
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
        public static EstoqueGavetaItemClass CopiarEntidade(EstoqueGavetaItemClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EstoqueGavetaItemClass toRet = new EstoqueGavetaItemClass(usuario,conn);
 toRet.EstoqueGaveta= entidadeCopiar.EstoqueGaveta;
 toRet.Produto= entidadeCopiar.Produto;
 toRet.Material= entidadeCopiar.Material;
 toRet.DocumentoCopia= entidadeCopiar.DocumentoCopia;
 toRet.Recurso= entidadeCopiar.Recurso;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.Ativo= entidadeCopiar.Ativo;
 toRet.ProdutoK= entidadeCopiar.ProdutoK;
 toRet.Epi= entidadeCopiar.Epi;

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
       _estoqueGavetaOriginal = EstoqueGaveta;
       _estoqueGavetaOriginalCommited = _estoqueGavetaOriginal;
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _documentoCopiaOriginal = DocumentoCopia;
       _documentoCopiaOriginalCommited = _documentoCopiaOriginal;
       _recursoOriginal = Recurso;
       _recursoOriginalCommited = _recursoOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _produtoKOriginal = ProdutoK;
       _produtoKOriginalCommited = _produtoKOriginal;
       _epiOriginal = Epi;
       _epiOriginalCommited = _epiOriginal;

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
       _estoqueGavetaOriginalCommited = EstoqueGaveta;
       _produtoOriginalCommited = Produto;
       _materialOriginalCommited = Material;
       _documentoCopiaOriginalCommited = DocumentoCopia;
       _recursoOriginalCommited = Recurso;
       _quantidadeOriginalCommited = Quantidade;
       _ativoOriginalCommited = Ativo;
       _versionOriginalCommited = Version;
       _produtoKOriginalCommited = ProdutoK;
       _epiOriginalCommited = Epi;

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
               if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded) 
               {
                  if (_collectionEstoqueMovimentacaoClassEstoqueGavetaItemRemovidos != null) 
                  {
                     _collectionEstoqueMovimentacaoClassEstoqueGavetaItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueMovimentacaoClassEstoqueGavetaItemRemovidos = new List<Entidades.EstoqueMovimentacaoClass>();
                  }
                  _collectionEstoqueMovimentacaoClassEstoqueGavetaItemOriginal= (from a in _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItem select a.ID).ToList();
                  _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemChanged = false;
                  _valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded) 
               {
                  if (_collectionOrdemProducaoEstoqueClassEstoqueGavetaItemRemovidos != null) 
                  {
                     _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemRemovidos = new List<Entidades.OrdemProducaoEstoqueClass>();
                  }
                  _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemOriginal= (from a in _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem select a.ID).ToList();
                  _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemChanged = false;
                  _valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemCommitedChanged = false;
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
               EstoqueGaveta=_estoqueGavetaOriginal;
               _estoqueGavetaOriginalCommited=_estoqueGavetaOriginal;
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               DocumentoCopia=_documentoCopiaOriginal;
               _documentoCopiaOriginalCommited=_documentoCopiaOriginal;
               Recurso=_recursoOriginal;
               _recursoOriginalCommited=_recursoOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ProdutoK=_produtoKOriginal;
               _produtoKOriginalCommited=_produtoKOriginal;
               Epi=_epiOriginal;
               _epiOriginalCommited=_epiOriginal;
               if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded) 
               {
                  CollectionEstoqueMovimentacaoClassEstoqueGavetaItem.Clear();
                  foreach(int item in _collectionEstoqueMovimentacaoClassEstoqueGavetaItemOriginal)
                  {
                    CollectionEstoqueMovimentacaoClassEstoqueGavetaItem.Add(Entidades.EstoqueMovimentacaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueMovimentacaoClassEstoqueGavetaItemRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded) 
               {
                  CollectionOrdemProducaoEstoqueClassEstoqueGavetaItem.Clear();
                  foreach(int item in _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemOriginal)
                  {
                    CollectionOrdemProducaoEstoqueClassEstoqueGavetaItem.Add(Entidades.OrdemProducaoEstoqueClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEstoqueClassEstoqueGavetaItemRemovidos.Clear();
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
               if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded) 
               {
                  if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded) 
               {
                   tempRet = CollectionEstoqueMovimentacaoClassEstoqueGavetaItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEstoqueClassEstoqueGavetaItem.Any(item => item.IsDirty());
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
       if (_estoqueGavetaOriginal!=null)
       {
          dirty = !_estoqueGavetaOriginal.Equals(EstoqueGaveta);
       }
       else
       {
            dirty = EstoqueGaveta != null;
       }
      if (dirty) return true;
       if (_produtoOriginal!=null)
       {
          dirty = !_produtoOriginal.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
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
       if (_documentoCopiaOriginal!=null)
       {
          dirty = !_documentoCopiaOriginal.Equals(DocumentoCopia);
       }
       else
       {
            dirty = DocumentoCopia != null;
       }
      if (dirty) return true;
       if (_recursoOriginal!=null)
       {
          dirty = !_recursoOriginal.Equals(Recurso);
       }
       else
       {
            dirty = Recurso != null;
       }
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_produtoKOriginal!=null)
       {
          dirty = !_produtoKOriginal.Equals(ProdutoK);
       }
       else
       {
            dirty = ProdutoK != null;
       }
      if (dirty) return true;
       if (_epiOriginal!=null)
       {
          dirty = !_epiOriginal.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
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
               if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded) 
               {
                  if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded) 
               {
                   tempRet = CollectionEstoqueMovimentacaoClassEstoqueGavetaItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEstoqueClassEstoqueGavetaItem.Any(item => item.IsDirtyCommited());
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
       if (_estoqueGavetaOriginalCommited!=null)
       {
          dirty = !_estoqueGavetaOriginalCommited.Equals(EstoqueGaveta);
       }
       else
       {
            dirty = EstoqueGaveta != null;
       }
      if (dirty) return true;
       if (_produtoOriginalCommited!=null)
       {
          dirty = !_produtoOriginalCommited.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
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
       if (_documentoCopiaOriginalCommited!=null)
       {
          dirty = !_documentoCopiaOriginalCommited.Equals(DocumentoCopia);
       }
       else
       {
            dirty = DocumentoCopia != null;
       }
      if (dirty) return true;
       if (_recursoOriginalCommited!=null)
       {
          dirty = !_recursoOriginalCommited.Equals(Recurso);
       }
       else
       {
            dirty = Recurso != null;
       }
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_produtoKOriginalCommited!=null)
       {
          dirty = !_produtoKOriginalCommited.Equals(ProdutoK);
       }
       else
       {
            dirty = ProdutoK != null;
       }
      if (dirty) return true;
       if (_epiOriginalCommited!=null)
       {
          dirty = !_epiOriginalCommited.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
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
               if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded) 
               {
                  foreach(EstoqueMovimentacaoClass item in CollectionEstoqueMovimentacaoClassEstoqueGavetaItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded) 
               {
                  foreach(OrdemProducaoEstoqueClass item in CollectionOrdemProducaoEstoqueClassEstoqueGavetaItem)
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
             case "EstoqueGaveta":
                return this.EstoqueGaveta;
             case "Produto":
                return this.Produto;
             case "Material":
                return this.Material;
             case "DocumentoCopia":
                return this.DocumentoCopia;
             case "Recurso":
                return this.Recurso;
             case "Quantidade":
                return this.Quantidade;
             case "Ativo":
                return this.Ativo;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ProdutoK":
                return this.ProdutoK;
             case "Epi":
                return this.Epi;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (EstoqueGaveta!=null)
                EstoqueGaveta.ChangeSingleConnection(newConnection);
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
             if (DocumentoCopia!=null)
                DocumentoCopia.ChangeSingleConnection(newConnection);
             if (Recurso!=null)
                Recurso.ChangeSingleConnection(newConnection);
             if (ProdutoK!=null)
                ProdutoK.ChangeSingleConnection(newConnection);
             if (Epi!=null)
                Epi.ChangeSingleConnection(newConnection);
               if (_valueCollectionEstoqueMovimentacaoClassEstoqueGavetaItemLoaded) 
               {
                  foreach(EstoqueMovimentacaoClass item in CollectionEstoqueMovimentacaoClassEstoqueGavetaItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEstoqueClassEstoqueGavetaItemLoaded) 
               {
                  foreach(OrdemProducaoEstoqueClass item in CollectionOrdemProducaoEstoqueClassEstoqueGavetaItem)
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
                  command.CommandText += " COUNT(estoque_gaveta_item.id_estoque_gaveta_item) " ;
               }
               else
               {
               command.CommandText += "estoque_gaveta_item.id_estoque_gaveta_item, " ;
               command.CommandText += "estoque_gaveta_item.id_estoque_gaveta, " ;
               command.CommandText += "estoque_gaveta_item.id_produto, " ;
               command.CommandText += "estoque_gaveta_item.id_material, " ;
               command.CommandText += "estoque_gaveta_item.id_documento_copia, " ;
               command.CommandText += "estoque_gaveta_item.id_recurso, " ;
               command.CommandText += "estoque_gaveta_item.egi_quantidade, " ;
               command.CommandText += "estoque_gaveta_item.egi_ativo, " ;
               command.CommandText += "estoque_gaveta_item.entity_uid, " ;
               command.CommandText += "estoque_gaveta_item.version, " ;
               command.CommandText += "estoque_gaveta_item.id_produto_k, " ;
               command.CommandText += "estoque_gaveta_item.id_epi " ;
               }
               command.CommandText += " FROM  estoque_gaveta_item ";
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
                        orderByClause += " , egi_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(egi_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = estoque_gaveta_item.id_acs_usuario_ultima_revisao ";
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
                     case "id_estoque_gaveta_item":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque_gaveta_item.id_estoque_gaveta_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_gaveta_item.id_estoque_gaveta_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estoque_gaveta":
                     case "EstoqueGaveta":
                     command.CommandText += " LEFT JOIN estoque_gaveta as estoque_gaveta_EstoqueGaveta ON estoque_gaveta_EstoqueGaveta.id_estoque_gaveta = estoque_gaveta_item.id_estoque_gaveta ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_gaveta_EstoqueGaveta.esg_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_gaveta_EstoqueGaveta.esg_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = estoque_gaveta_item.id_produto ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_Produto.pro_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_Produto.pro_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = estoque_gaveta_item.id_material ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_documento_copia":
                     case "DocumentoCopia":
                     command.CommandText += " LEFT JOIN documento_copia as documento_copia_DocumentoCopia ON documento_copia_DocumentoCopia.id_documento_copia = estoque_gaveta_item.id_documento_copia ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_recurso":
                     case "Recurso":
                     command.CommandText += " LEFT JOIN recurso as recurso_Recurso ON recurso_Recurso.id_recurso = estoque_gaveta_item.id_recurso ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , recurso_Recurso.rec_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(recurso_Recurso.rec_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "egi_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque_gaveta_item.egi_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_gaveta_item.egi_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "egi_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque_gaveta_item.egi_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_gaveta_item.egi_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_gaveta_item.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_gaveta_item.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , estoque_gaveta_item.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_gaveta_item.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto_k":
                     case "ProdutoK":
                     command.CommandText += " LEFT JOIN produto_k as produto_k_ProdutoK ON produto_k_ProdutoK.id_produto_k = estoque_gaveta_item.id_produto_k ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k_ProdutoK.prk_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k_ProdutoK.prk_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k_ProdutoK.prk_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k_ProdutoK.prk_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_epi":
                     case "Epi":
                     command.CommandText += " LEFT JOIN epi as epi_Epi ON epi_Epi.id_epi = estoque_gaveta_item.id_epi ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi_Epi.epi_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi_Epi.epi_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(estoque_gaveta_item.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_gaveta_item.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_estoque_gaveta_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta_item.id_estoque_gaveta_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.id_estoque_gaveta_item = :estoque_gaveta_item_ID_7075 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_ID_7075", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstoqueGaveta" || parametro.FieldName == "id_estoque_gaveta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstoqueGavetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstoqueGavetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta_item.id_estoque_gaveta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.id_estoque_gaveta = :estoque_gaveta_item_EstoqueGaveta_2572 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_EstoqueGaveta_2572", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Produto" || parametro.FieldName == "id_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta_item.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.id_produto = :estoque_gaveta_item_Produto_8774 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_Produto_8774", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  estoque_gaveta_item.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.id_material = :estoque_gaveta_item_Material_2411 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_Material_2411", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  estoque_gaveta_item.id_documento_copia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.id_documento_copia = :estoque_gaveta_item_DocumentoCopia_2527 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_DocumentoCopia_2527", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Recurso" || parametro.FieldName == "id_recurso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.RecursoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.RecursoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta_item.id_recurso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.id_recurso = :estoque_gaveta_item_Recurso_2387 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_Recurso_2387", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "egi_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta_item.egi_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.egi_quantidade = :estoque_gaveta_item_Quantidade_8788 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_Quantidade_8788", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "egi_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta_item.egi_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.egi_ativo = :estoque_gaveta_item_Ativo_6536 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_Ativo_6536", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  estoque_gaveta_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.entity_uid LIKE :estoque_gaveta_item_EntityUid_8963 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_EntityUid_8963", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  estoque_gaveta_item.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.version = :estoque_gaveta_item_Version_323 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_Version_323", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoK" || parametro.FieldName == "id_produto_k")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoKClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoKClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta_item.id_produto_k IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.id_produto_k = :estoque_gaveta_item_ProdutoK_2657 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_ProdutoK_2657", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Epi" || parametro.FieldName == "id_epi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EpiClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EpiClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta_item.id_epi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.id_epi = :estoque_gaveta_item_Epi_3838 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_Epi_3838", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  estoque_gaveta_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta_item.entity_uid LIKE :estoque_gaveta_item_EntityUid_2541 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_item_EntityUid_2541", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EstoqueGavetaItemClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EstoqueGavetaItemClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EstoqueGavetaItemClass), Convert.ToInt32(read["id_estoque_gaveta_item"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EstoqueGavetaItemClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_estoque_gaveta_item"]);
                     if (read["id_estoque_gaveta"] != DBNull.Value)
                     {
                        entidade.EstoqueGaveta = (BibliotecaEntidades.Entidades.EstoqueGavetaClass)BibliotecaEntidades.Entidades.EstoqueGavetaClass.GetEntidade(Convert.ToInt32(read["id_estoque_gaveta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstoqueGaveta = null ;
                     }
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     if (read["id_documento_copia"] != DBNull.Value)
                     {
                        entidade.DocumentoCopia = (BibliotecaEntidades.Entidades.DocumentoCopiaClass)BibliotecaEntidades.Entidades.DocumentoCopiaClass.GetEntidade(Convert.ToInt32(read["id_documento_copia"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DocumentoCopia = null ;
                     }
                     if (read["id_recurso"] != DBNull.Value)
                     {
                        entidade.Recurso = (BibliotecaEntidades.Entidades.RecursoClass)BibliotecaEntidades.Entidades.RecursoClass.GetEntidade(Convert.ToInt32(read["id_recurso"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Recurso = null ;
                     }
                     entidade.Quantidade = (double)read["egi_quantidade"];
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["egi_ativo"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_produto_k"] != DBNull.Value)
                     {
                        entidade.ProdutoK = (BibliotecaEntidades.Entidades.ProdutoKClass)BibliotecaEntidades.Entidades.ProdutoKClass.GetEntidade(Convert.ToInt32(read["id_produto_k"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ProdutoK = null ;
                     }
                     if (read["id_epi"] != DBNull.Value)
                     {
                        entidade.Epi = (BibliotecaEntidades.Entidades.EpiClass)BibliotecaEntidades.Entidades.EpiClass.GetEntidade(Convert.ToInt32(read["id_epi"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Epi = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EstoqueGavetaItemClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
