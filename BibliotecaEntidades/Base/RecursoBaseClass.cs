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
     [Table("recurso","rec")]
     public class RecursoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do RecursoClass";
protected const string ErroDelete = "Erro ao excluir o RecursoClass  ";
protected const string ErroSave = "Erro ao salvar o RecursoClass.";
protected const string ErroCollectionEstoqueGavetaItemClassRecurso = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected const string ErroCollectionOrdemProducaoRecursoClassRecurso = "Erro ao carregar a coleção de OrdemProducaoRecursoClass.";
protected const string ErroCollectionProdutoRecursoClassRecurso = "Erro ao carregar a coleção de ProdutoRecursoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroPostoTrabalhoObrigatorio = "O campo PostoTrabalho é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do RecursoClass.";
protected const string MensagemUtilizadoCollectionEstoqueGavetaItemClassRecurso =  "A entidade RecursoClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoRecursoClassRecurso =  "A entidade RecursoClass está sendo utilizada nos seguintes OrdemProducaoRecursoClass:";
protected const string MensagemUtilizadoCollectionProdutoRecursoClassRecurso =  "A entidade RecursoClass está sendo utilizada nos seguintes ProdutoRecursoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade RecursoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _valuePostoTrabalho;
        [Column("id_posto_trabalho", "posto_trabalho", "id_posto_trabalho")]
       public virtual BibliotecaEntidades.Entidades.PostoTrabalhoClass PostoTrabalho
        { 
           get {                 return this._valuePostoTrabalho; } 
           set 
           { 
                if (this._valuePostoTrabalho == value)return;
                 this._valuePostoTrabalho = value; 
           } 
       } 

       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("rec_codigo")]
        public virtual string Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("rec_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected string _revisaoOriginal{get;private set;}
       private string _revisaoOriginalCommited{get; set;}
        private string _valueRevisao;
         [Column("rec_revisao")]
        public virtual string Revisao
         { 
            get { return this._valueRevisao; } 
            set 
            { 
                if (this._valueRevisao == value)return;
                 this._valueRevisao = value; 
            } 
        } 

       protected DateTime? _dataInicioOriginal{get;private set;}
       private DateTime? _dataInicioOriginalCommited{get; set;}
        private DateTime? _valueDataInicio;
         [Column("rec_data_inicio")]
        public virtual DateTime? DataInicio
         { 
            get { return this._valueDataInicio; } 
            set 
            { 
                if (this._valueDataInicio == value)return;
                 this._valueDataInicio = value; 
            } 
        } 

       protected DateTime? _dataTerminoOriginal{get;private set;}
       private DateTime? _dataTerminoOriginalCommited{get; set;}
        private DateTime? _valueDataTermino;
         [Column("rec_data_termino")]
        public virtual DateTime? DataTermino
         { 
            get { return this._valueDataTermino; } 
            set 
            { 
                if (this._valueDataTermino == value)return;
                 this._valueDataTermino = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.FamiliaRecursoClass _familiaRecursoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FamiliaRecursoClass _familiaRecursoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FamiliaRecursoClass _valueFamiliaRecurso;
        [Column("id_familia_recurso", "familia_recurso", "id_familia_recurso")]
       public virtual BibliotecaEntidades.Entidades.FamiliaRecursoClass FamiliaRecurso
        { 
           get {                 return this._valueFamiliaRecurso; } 
           set 
           { 
                if (this._valueFamiliaRecurso == value)return;
                 this._valueFamiliaRecurso = value; 
           } 
       } 

       protected TipoRecurso _tipoOriginal{get;private set;}
       private TipoRecurso _tipoOriginalCommited{get; set;}
        private TipoRecurso _valueTipo;
         [Column("rec_tipo")]
        public virtual TipoRecurso Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_Normal
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoRecurso.Normal; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoRecurso.Normal; }
         } 

        public bool Tipo_Formulario
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoRecurso.Formulario; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoRecurso.Formulario; }
         } 

        public bool Tipo_CNC
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoRecurso.CNC; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoRecurso.CNC; }
         } 

       protected string _diretorioOrigemOriginal{get;private set;}
       private string _diretorioOrigemOriginalCommited{get; set;}
        private string _valueDiretorioOrigem;
         [Column("rec_diretorio_origem")]
        public virtual string DiretorioOrigem
         { 
            get { return this._valueDiretorioOrigem; } 
            set 
            { 
                if (this._valueDiretorioOrigem == value)return;
                 this._valueDiretorioOrigem = value; 
            } 
        } 

       protected string _diretorioDestinoOriginal{get;private set;}
       private string _diretorioDestinoOriginalCommited{get; set;}
        private string _valueDiretorioDestino;
         [Column("rec_diretorio_destino")]
        public virtual string DiretorioDestino
         { 
            get { return this._valueDiretorioDestino; } 
            set 
            { 
                if (this._valueDiretorioDestino == value)return;
                 this._valueDiretorioDestino = value; 
            } 
        } 

       private List<long> _collectionEstoqueGavetaItemClassRecursoOriginal;
       private List<Entidades.EstoqueGavetaItemClass > _collectionEstoqueGavetaItemClassRecursoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassRecursoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassRecursoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassRecursoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueGavetaItemClass> _valueCollectionEstoqueGavetaItemClassRecurso { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueGavetaItemClass> CollectionEstoqueGavetaItemClassRecurso 
       { 
           get { if(!_valueCollectionEstoqueGavetaItemClassRecursoLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueGavetaItemClassRecurso();}
return this._valueCollectionEstoqueGavetaItemClassRecurso; } 
           set 
           { 
               this._valueCollectionEstoqueGavetaItemClassRecurso = value; 
               this._valueCollectionEstoqueGavetaItemClassRecursoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoRecursoClassRecursoOriginal;
       private List<Entidades.OrdemProducaoRecursoClass > _collectionOrdemProducaoRecursoClassRecursoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoRecursoClassRecursoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoRecursoClassRecursoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoRecursoClassRecursoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoRecursoClass> _valueCollectionOrdemProducaoRecursoClassRecurso { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoRecursoClass> CollectionOrdemProducaoRecursoClassRecurso 
       { 
           get { if(!_valueCollectionOrdemProducaoRecursoClassRecursoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoRecursoClassRecurso();}
return this._valueCollectionOrdemProducaoRecursoClassRecurso; } 
           set 
           { 
               this._valueCollectionOrdemProducaoRecursoClassRecurso = value; 
               this._valueCollectionOrdemProducaoRecursoClassRecursoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoRecursoClassRecursoOriginal;
       private List<Entidades.ProdutoRecursoClass > _collectionProdutoRecursoClassRecursoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoRecursoClassRecursoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoRecursoClassRecursoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoRecursoClassRecursoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoRecursoClass> _valueCollectionProdutoRecursoClassRecurso { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoRecursoClass> CollectionProdutoRecursoClassRecurso 
       { 
           get { if(!_valueCollectionProdutoRecursoClassRecursoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoRecursoClassRecurso();}
return this._valueCollectionProdutoRecursoClassRecurso; } 
           set 
           { 
               this._valueCollectionProdutoRecursoClassRecurso = value; 
               this._valueCollectionProdutoRecursoClassRecursoLoaded = true; 
           } 
       } 

        public RecursoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Tipo = (TipoRecurso)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static RecursoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (RecursoClass) GetEntity(typeof(RecursoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEstoqueGavetaItemClassRecursoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueGavetaItemClassRecursoChanged = true;
                  _valueCollectionEstoqueGavetaItemClassRecursoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueGavetaItemClassRecursoChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassRecursoCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in e.OldItems) 
                 { 
                     _collectionEstoqueGavetaItemClassRecursoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueGavetaItemClassRecursoChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassRecursoCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in _valueCollectionEstoqueGavetaItemClassRecurso) 
                 { 
                     _collectionEstoqueGavetaItemClassRecursoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueGavetaItemClassRecurso()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueGavetaItemClass> oc;
                _valueCollectionEstoqueGavetaItemClassRecursoChanged = false;
                 _valueCollectionEstoqueGavetaItemClassRecursoCommitedChanged = false;
                _collectionEstoqueGavetaItemClassRecursoRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueGavetaItemClass>();
                }
                else{ 
                   Entidades.EstoqueGavetaItemClass search = new Entidades.EstoqueGavetaItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueGavetaItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Recurso", this),                     }                       ).Cast<Entidades.EstoqueGavetaItemClass>().ToList());
                 }
                 _valueCollectionEstoqueGavetaItemClassRecurso = new BindingList<Entidades.EstoqueGavetaItemClass>(oc); 
                 _collectionEstoqueGavetaItemClassRecursoOriginal= (from a in _valueCollectionEstoqueGavetaItemClassRecurso select a.ID).ToList();
                 _valueCollectionEstoqueGavetaItemClassRecursoLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueGavetaItemClassRecursoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueGavetaItemClassRecurso+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoRecursoClassRecursoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoRecursoClassRecursoChanged = true;
                  _valueCollectionOrdemProducaoRecursoClassRecursoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoRecursoClassRecursoChanged = true; 
                  _valueCollectionOrdemProducaoRecursoClassRecursoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoRecursoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoRecursoClassRecursoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoRecursoClassRecursoChanged = true; 
                  _valueCollectionOrdemProducaoRecursoClassRecursoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoRecursoClass item in _valueCollectionOrdemProducaoRecursoClassRecurso) 
                 { 
                     _collectionOrdemProducaoRecursoClassRecursoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoRecursoClassRecurso()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoRecursoClass> oc;
                _valueCollectionOrdemProducaoRecursoClassRecursoChanged = false;
                 _valueCollectionOrdemProducaoRecursoClassRecursoCommitedChanged = false;
                _collectionOrdemProducaoRecursoClassRecursoRemovidos = new List<Entidades.OrdemProducaoRecursoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoRecursoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoRecursoClass search = new Entidades.OrdemProducaoRecursoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoRecursoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Recurso", this),                     }                       ).Cast<Entidades.OrdemProducaoRecursoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoRecursoClassRecurso = new BindingList<Entidades.OrdemProducaoRecursoClass>(oc); 
                 _collectionOrdemProducaoRecursoClassRecursoOriginal= (from a in _valueCollectionOrdemProducaoRecursoClassRecurso select a.ID).ToList();
                 _valueCollectionOrdemProducaoRecursoClassRecursoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoRecursoClassRecursoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoRecursoClassRecurso+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoRecursoClassRecursoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoRecursoClassRecursoChanged = true;
                  _valueCollectionProdutoRecursoClassRecursoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoRecursoClassRecursoChanged = true; 
                  _valueCollectionProdutoRecursoClassRecursoCommitedChanged = true;
                 foreach (Entidades.ProdutoRecursoClass item in e.OldItems) 
                 { 
                     _collectionProdutoRecursoClassRecursoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoRecursoClassRecursoChanged = true; 
                  _valueCollectionProdutoRecursoClassRecursoCommitedChanged = true;
                 foreach (Entidades.ProdutoRecursoClass item in _valueCollectionProdutoRecursoClassRecurso) 
                 { 
                     _collectionProdutoRecursoClassRecursoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoRecursoClassRecurso()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoRecursoClass> oc;
                _valueCollectionProdutoRecursoClassRecursoChanged = false;
                 _valueCollectionProdutoRecursoClassRecursoCommitedChanged = false;
                _collectionProdutoRecursoClassRecursoRemovidos = new List<Entidades.ProdutoRecursoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoRecursoClass>();
                }
                else{ 
                   Entidades.ProdutoRecursoClass search = new Entidades.ProdutoRecursoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoRecursoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Recurso", this),                     }                       ).Cast<Entidades.ProdutoRecursoClass>().ToList());
                 }
                 _valueCollectionProdutoRecursoClassRecurso = new BindingList<Entidades.ProdutoRecursoClass>(oc); 
                 _collectionProdutoRecursoClassRecursoOriginal= (from a in _valueCollectionProdutoRecursoClassRecurso select a.ID).ToList();
                 _valueCollectionProdutoRecursoClassRecursoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoRecursoClassRecursoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoRecursoClassRecurso+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valuePostoTrabalho == null)
                {
                    throw new Exception(ErroPostoTrabalhoObrigatorio);
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
                    "  public.recurso  " +
                    "WHERE " +
                    "  id_recurso = :id";
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
                        "  public.recurso   " +
                        "SET  " + 
                        "  id_posto_trabalho = :id_posto_trabalho, " + 
                        "  rec_codigo = :rec_codigo, " + 
                        "  rec_nome = :rec_nome, " + 
                        "  rec_revisao = :rec_revisao, " + 
                        "  rec_data_inicio = :rec_data_inicio, " + 
                        "  rec_data_termino = :rec_data_termino, " + 
                        "  id_familia_recurso = :id_familia_recurso, " + 
                        "  rec_ultima_revisao = :rec_ultima_revisao, " + 
                        "  rec_ultima_revisao_data = :rec_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  rec_tipo = :rec_tipo, " + 
                        "  rec_diretorio_origem = :rec_diretorio_origem, " + 
                        "  rec_diretorio_destino = :rec_diretorio_destino "+
                        "WHERE  " +
                        "  id_recurso = :id " +
                        "RETURNING id_recurso;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.recurso " +
                        "( " +
                        "  id_posto_trabalho , " + 
                        "  rec_codigo , " + 
                        "  rec_nome , " + 
                        "  rec_revisao , " + 
                        "  rec_data_inicio , " + 
                        "  rec_data_termino , " + 
                        "  id_familia_recurso , " + 
                        "  rec_ultima_revisao , " + 
                        "  rec_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  rec_tipo , " + 
                        "  rec_diretorio_origem , " + 
                        "  rec_diretorio_destino  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_posto_trabalho , " + 
                        "  :rec_codigo , " + 
                        "  :rec_nome , " + 
                        "  :rec_revisao , " + 
                        "  :rec_data_inicio , " + 
                        "  :rec_data_termino , " + 
                        "  :id_familia_recurso , " + 
                        "  :rec_ultima_revisao , " + 
                        "  :rec_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :rec_tipo , " + 
                        "  :rec_diretorio_origem , " + 
                        "  :rec_diretorio_destino  "+
                        ")RETURNING id_recurso;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PostoTrabalho==null ? (object) DBNull.Value : this.PostoTrabalho.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Revisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_data_inicio", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataInicio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_data_termino", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataTermino ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_familia_recurso", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FamiliaRecurso==null ? (object) DBNull.Value : this.FamiliaRecurso.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_diretorio_origem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DiretorioOrigem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rec_diretorio_destino", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DiretorioDestino ?? DBNull.Value;

 
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
 if (CollectionEstoqueGavetaItemClassRecurso.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueGavetaItemClassRecurso+"\r\n";
                foreach (Entidades.EstoqueGavetaItemClass tmp in CollectionEstoqueGavetaItemClassRecurso)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoRecursoClassRecurso.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoRecursoClassRecurso+"\r\n";
                foreach (Entidades.OrdemProducaoRecursoClass tmp in CollectionOrdemProducaoRecursoClassRecurso)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoRecursoClassRecurso.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoRecursoClassRecurso+"\r\n";
                foreach (Entidades.ProdutoRecursoClass tmp in CollectionProdutoRecursoClassRecurso)
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
        public static RecursoClass CopiarEntidade(RecursoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               RecursoClass toRet = new RecursoClass(usuario,conn);
 toRet.PostoTrabalho= entidadeCopiar.PostoTrabalho;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Nome= entidadeCopiar.Nome;
 toRet.Revisao= entidadeCopiar.Revisao;
 toRet.DataInicio= entidadeCopiar.DataInicio;
 toRet.DataTermino= entidadeCopiar.DataTermino;
 toRet.FamiliaRecurso= entidadeCopiar.FamiliaRecurso;
 toRet.Tipo= entidadeCopiar.Tipo;
 toRet.DiretorioOrigem= entidadeCopiar.DiretorioOrigem;
 toRet.DiretorioDestino= entidadeCopiar.DiretorioDestino;

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
       _postoTrabalhoOriginal = PostoTrabalho;
       _postoTrabalhoOriginalCommited = _postoTrabalhoOriginal;
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _revisaoOriginal = Revisao;
       _revisaoOriginalCommited = _revisaoOriginal;
       _dataInicioOriginal = DataInicio;
       _dataInicioOriginalCommited = _dataInicioOriginal;
       _dataTerminoOriginal = DataTermino;
       _dataTerminoOriginalCommited = _dataTerminoOriginal;
       _familiaRecursoOriginal = FamiliaRecurso;
       _familiaRecursoOriginalCommited = _familiaRecursoOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
       _diretorioOrigemOriginal = DiretorioOrigem;
       _diretorioOrigemOriginalCommited = _diretorioOrigemOriginal;
       _diretorioDestinoOriginal = DiretorioDestino;
       _diretorioDestinoOriginalCommited = _diretorioDestinoOriginal;

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
       _postoTrabalhoOriginalCommited = PostoTrabalho;
       _codigoOriginalCommited = Codigo;
       _nomeOriginalCommited = Nome;
       _revisaoOriginalCommited = Revisao;
       _dataInicioOriginalCommited = DataInicio;
       _dataTerminoOriginalCommited = DataTermino;
       _familiaRecursoOriginalCommited = FamiliaRecurso;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;
       _tipoOriginalCommited = Tipo;
       _diretorioOrigemOriginalCommited = DiretorioOrigem;
       _diretorioDestinoOriginalCommited = DiretorioDestino;

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
               if (_valueCollectionEstoqueGavetaItemClassRecursoLoaded) 
               {
                  if (_collectionEstoqueGavetaItemClassRecursoRemovidos != null) 
                  {
                     _collectionEstoqueGavetaItemClassRecursoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueGavetaItemClassRecursoRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                  }
                  _collectionEstoqueGavetaItemClassRecursoOriginal= (from a in _valueCollectionEstoqueGavetaItemClassRecurso select a.ID).ToList();
                  _valueCollectionEstoqueGavetaItemClassRecursoChanged = false;
                  _valueCollectionEstoqueGavetaItemClassRecursoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoRecursoClassRecursoLoaded) 
               {
                  if (_collectionOrdemProducaoRecursoClassRecursoRemovidos != null) 
                  {
                     _collectionOrdemProducaoRecursoClassRecursoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoRecursoClassRecursoRemovidos = new List<Entidades.OrdemProducaoRecursoClass>();
                  }
                  _collectionOrdemProducaoRecursoClassRecursoOriginal= (from a in _valueCollectionOrdemProducaoRecursoClassRecurso select a.ID).ToList();
                  _valueCollectionOrdemProducaoRecursoClassRecursoChanged = false;
                  _valueCollectionOrdemProducaoRecursoClassRecursoCommitedChanged = false;
               }
               if (_valueCollectionProdutoRecursoClassRecursoLoaded) 
               {
                  if (_collectionProdutoRecursoClassRecursoRemovidos != null) 
                  {
                     _collectionProdutoRecursoClassRecursoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoRecursoClassRecursoRemovidos = new List<Entidades.ProdutoRecursoClass>();
                  }
                  _collectionProdutoRecursoClassRecursoOriginal= (from a in _valueCollectionProdutoRecursoClassRecurso select a.ID).ToList();
                  _valueCollectionProdutoRecursoClassRecursoChanged = false;
                  _valueCollectionProdutoRecursoClassRecursoCommitedChanged = false;
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
               PostoTrabalho=_postoTrabalhoOriginal;
               _postoTrabalhoOriginalCommited=_postoTrabalhoOriginal;
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               Revisao=_revisaoOriginal;
               _revisaoOriginalCommited=_revisaoOriginal;
               DataInicio=_dataInicioOriginal;
               _dataInicioOriginalCommited=_dataInicioOriginal;
               DataTermino=_dataTerminoOriginal;
               _dataTerminoOriginalCommited=_dataTerminoOriginal;
               FamiliaRecurso=_familiaRecursoOriginal;
               _familiaRecursoOriginalCommited=_familiaRecursoOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               DiretorioOrigem=_diretorioOrigemOriginal;
               _diretorioOrigemOriginalCommited=_diretorioOrigemOriginal;
               DiretorioDestino=_diretorioDestinoOriginal;
               _diretorioDestinoOriginalCommited=_diretorioDestinoOriginal;
               if (_valueCollectionEstoqueGavetaItemClassRecursoLoaded) 
               {
                  CollectionEstoqueGavetaItemClassRecurso.Clear();
                  foreach(int item in _collectionEstoqueGavetaItemClassRecursoOriginal)
                  {
                    CollectionEstoqueGavetaItemClassRecurso.Add(Entidades.EstoqueGavetaItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueGavetaItemClassRecursoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoRecursoClassRecursoLoaded) 
               {
                  CollectionOrdemProducaoRecursoClassRecurso.Clear();
                  foreach(int item in _collectionOrdemProducaoRecursoClassRecursoOriginal)
                  {
                    CollectionOrdemProducaoRecursoClassRecurso.Add(Entidades.OrdemProducaoRecursoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoRecursoClassRecursoRemovidos.Clear();
               }
               if (_valueCollectionProdutoRecursoClassRecursoLoaded) 
               {
                  CollectionProdutoRecursoClassRecurso.Clear();
                  foreach(int item in _collectionProdutoRecursoClassRecursoOriginal)
                  {
                    CollectionProdutoRecursoClassRecurso.Add(Entidades.ProdutoRecursoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoRecursoClassRecursoRemovidos.Clear();
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
               if (_valueCollectionEstoqueGavetaItemClassRecursoLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassRecursoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassRecursoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoRecursoClassRecursoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoRecursoClassRecursoLoaded) 
               {
                  if (_valueCollectionProdutoRecursoClassRecursoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassRecursoLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassRecurso.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoRecursoClassRecursoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoRecursoClassRecurso.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoRecursoClassRecursoLoaded) 
               {
                   tempRet = CollectionProdutoRecursoClassRecurso.Any(item => item.IsDirty());
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
       if (_postoTrabalhoOriginal!=null)
       {
          dirty = !_postoTrabalhoOriginal.Equals(PostoTrabalho);
       }
       else
       {
            dirty = PostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       dirty = _nomeOriginal != Nome;
      if (dirty) return true;
       dirty = _revisaoOriginal != Revisao;
      if (dirty) return true;
       dirty = _dataInicioOriginal != DataInicio;
      if (dirty) return true;
       dirty = _dataTerminoOriginal != DataTermino;
      if (dirty) return true;
       if (_familiaRecursoOriginal!=null)
       {
          dirty = !_familiaRecursoOriginal.Equals(FamiliaRecurso);
       }
       else
       {
            dirty = FamiliaRecurso != null;
       }
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;
      if (dirty) return true;
       dirty = _diretorioOrigemOriginal != DiretorioOrigem;
      if (dirty) return true;
       dirty = _diretorioDestinoOriginal != DiretorioDestino;

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
               if (_valueCollectionEstoqueGavetaItemClassRecursoLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassRecursoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassRecursoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoRecursoClassRecursoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoRecursoClassRecursoLoaded) 
               {
                  if (_valueCollectionProdutoRecursoClassRecursoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassRecursoLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassRecurso.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoRecursoClassRecursoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoRecursoClassRecurso.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoRecursoClassRecursoLoaded) 
               {
                   tempRet = CollectionProdutoRecursoClassRecurso.Any(item => item.IsDirtyCommited());
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
       if (_postoTrabalhoOriginalCommited!=null)
       {
          dirty = !_postoTrabalhoOriginalCommited.Equals(PostoTrabalho);
       }
       else
       {
            dirty = PostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       dirty = _nomeOriginalCommited != Nome;
      if (dirty) return true;
       dirty = _revisaoOriginalCommited != Revisao;
      if (dirty) return true;
       dirty = _dataInicioOriginalCommited != DataInicio;
      if (dirty) return true;
       dirty = _dataTerminoOriginalCommited != DataTermino;
      if (dirty) return true;
       if (_familiaRecursoOriginalCommited!=null)
       {
          dirty = !_familiaRecursoOriginalCommited.Equals(FamiliaRecurso);
       }
       else
       {
            dirty = FamiliaRecurso != null;
       }
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;
      if (dirty) return true;
       dirty = _diretorioOrigemOriginalCommited != DiretorioOrigem;
      if (dirty) return true;
       dirty = _diretorioDestinoOriginalCommited != DiretorioDestino;

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
               if (_valueCollectionEstoqueGavetaItemClassRecursoLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassRecurso)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassRecursoLoaded) 
               {
                  foreach(OrdemProducaoRecursoClass item in CollectionOrdemProducaoRecursoClassRecurso)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoRecursoClassRecursoLoaded) 
               {
                  foreach(ProdutoRecursoClass item in CollectionProdutoRecursoClassRecurso)
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
             case "PostoTrabalho":
                return this.PostoTrabalho;
             case "Codigo":
                return this.Codigo;
             case "Nome":
                return this.Nome;
             case "Revisao":
                return this.Revisao;
             case "DataInicio":
                return this.DataInicio;
             case "DataTermino":
                return this.DataTermino;
             case "FamiliaRecurso":
                return this.FamiliaRecurso;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Tipo":
                return this.Tipo;
             case "DiretorioOrigem":
                return this.DiretorioOrigem;
             case "DiretorioDestino":
                return this.DiretorioDestino;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (PostoTrabalho!=null)
                PostoTrabalho.ChangeSingleConnection(newConnection);
             if (FamiliaRecurso!=null)
                FamiliaRecurso.ChangeSingleConnection(newConnection);
               if (_valueCollectionEstoqueGavetaItemClassRecursoLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassRecurso)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassRecursoLoaded) 
               {
                  foreach(OrdemProducaoRecursoClass item in CollectionOrdemProducaoRecursoClassRecurso)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoRecursoClassRecursoLoaded) 
               {
                  foreach(ProdutoRecursoClass item in CollectionProdutoRecursoClassRecurso)
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
                  command.CommandText += " COUNT(recurso.id_recurso) " ;
               }
               else
               {
               command.CommandText += "recurso.id_recurso, " ;
               command.CommandText += "recurso.id_posto_trabalho, " ;
               command.CommandText += "recurso.rec_codigo, " ;
               command.CommandText += "recurso.rec_nome, " ;
               command.CommandText += "recurso.rec_revisao, " ;
               command.CommandText += "recurso.rec_data_inicio, " ;
               command.CommandText += "recurso.rec_data_termino, " ;
               command.CommandText += "recurso.id_familia_recurso, " ;
               command.CommandText += "recurso.rec_ultima_revisao, " ;
               command.CommandText += "recurso.rec_ultima_revisao_data, " ;
               command.CommandText += "recurso.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "recurso.entity_uid, " ;
               command.CommandText += "recurso.version, " ;
               command.CommandText += "recurso.rec_tipo, " ;
               command.CommandText += "recurso.rec_diretorio_origem, " ;
               command.CommandText += "recurso.rec_diretorio_destino " ;
               }
               command.CommandText += " FROM  recurso ";
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
                        orderByClause += " , rec_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(rec_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = recurso.id_acs_usuario_ultima_revisao ";
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
                     case "id_recurso":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , recurso.id_recurso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(recurso.id_recurso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_posto_trabalho":
                     case "PostoTrabalho":
                     command.CommandText += " LEFT JOIN posto_trabalho as posto_trabalho_PostoTrabalho ON posto_trabalho_PostoTrabalho.id_posto_trabalho = recurso.id_posto_trabalho ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho_PostoTrabalho.pos_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho_PostoTrabalho.pos_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , recurso.rec_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(recurso.rec_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , recurso.rec_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(recurso.rec_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_revisao":
                     case "Revisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , recurso.rec_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(recurso.rec_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_data_inicio":
                     case "DataInicio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , recurso.rec_data_inicio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(recurso.rec_data_inicio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_data_termino":
                     case "DataTermino":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , recurso.rec_data_termino " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(recurso.rec_data_termino) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_familia_recurso":
                     case "FamiliaRecurso":
                     command.CommandText += " LEFT JOIN familia_recurso as familia_recurso_FamiliaRecurso ON familia_recurso_FamiliaRecurso.id_familia_recurso = recurso.id_familia_recurso ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_recurso_FamiliaRecurso.far_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_recurso_FamiliaRecurso.far_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , recurso.rec_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(recurso.rec_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , recurso.rec_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(recurso.rec_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , recurso.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , recurso.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(recurso.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , recurso.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(recurso.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , recurso.rec_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(recurso.rec_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_diretorio_origem":
                     case "DiretorioOrigem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , recurso.rec_diretorio_origem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(recurso.rec_diretorio_origem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rec_diretorio_destino":
                     case "DiretorioDestino":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , recurso.rec_diretorio_destino " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(recurso.rec_diretorio_destino) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rec_codigo")) 
                        {
                           whereClause += " OR UPPER(recurso.rec_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(recurso.rec_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rec_nome")) 
                        {
                           whereClause += " OR UPPER(recurso.rec_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(recurso.rec_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rec_revisao")) 
                        {
                           whereClause += " OR UPPER(recurso.rec_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(recurso.rec_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rec_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(recurso.rec_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(recurso.rec_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(recurso.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(recurso.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rec_diretorio_origem")) 
                        {
                           whereClause += " OR UPPER(recurso.rec_diretorio_origem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(recurso.rec_diretorio_origem) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rec_diretorio_destino")) 
                        {
                           whereClause += " OR UPPER(recurso.rec_diretorio_destino) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(recurso.rec_diretorio_destino) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_recurso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.id_recurso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.id_recurso = :recurso_ID_9530 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_ID_9530", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalho" || parametro.FieldName == "id_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PostoTrabalhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PostoTrabalhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.id_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.id_posto_trabalho = :recurso_PostoTrabalho_9141 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_PostoTrabalho_9141", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "rec_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_codigo LIKE :recurso_Codigo_978 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_Codigo_978", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "rec_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_nome LIKE :recurso_Nome_7977 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_Nome_7977", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Revisao" || parametro.FieldName == "rec_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_revisao LIKE :recurso_Revisao_1838 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_Revisao_1838", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataInicio" || parametro.FieldName == "rec_data_inicio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_data_inicio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_data_inicio = :recurso_DataInicio_2173 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_DataInicio_2173", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataTermino" || parametro.FieldName == "rec_data_termino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_data_termino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_data_termino = :recurso_DataTermino_4659 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_DataTermino_4659", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FamiliaRecurso" || parametro.FieldName == "id_familia_recurso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FamiliaRecursoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FamiliaRecursoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.id_familia_recurso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.id_familia_recurso = :recurso_FamiliaRecurso_6030 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_FamiliaRecurso_6030", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "rec_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_ultima_revisao LIKE :recurso_UltimaRevisao_2865 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_UltimaRevisao_2865", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "rec_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_ultima_revisao_data = :recurso_UltimaRevisaoData_4715 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_UltimaRevisaoData_4715", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  recurso.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.id_acs_usuario_ultima_revisao = :recurso_UltimaRevisaoUsuario_4410 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_UltimaRevisaoUsuario_4410", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  recurso.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.entity_uid LIKE :recurso_EntityUid_6443 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_EntityUid_6443", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  recurso.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.version = :recurso_Version_2049 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_Version_2049", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "rec_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoRecurso)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoRecurso");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_tipo = :recurso_Tipo_3737 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_Tipo_3737", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DiretorioOrigem" || parametro.FieldName == "rec_diretorio_origem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_diretorio_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_diretorio_origem LIKE :recurso_DiretorioOrigem_1615 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_DiretorioOrigem_1615", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DiretorioDestino" || parametro.FieldName == "rec_diretorio_destino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_diretorio_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_diretorio_destino LIKE :recurso_DiretorioDestino_7371 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_DiretorioDestino_7371", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  recurso.rec_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_codigo LIKE :recurso_Codigo_8489 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_Codigo_8489", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  recurso.rec_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_nome LIKE :recurso_Nome_2129 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_Nome_2129", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RevisaoExato" || parametro.FieldName == "RevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_revisao LIKE :recurso_Revisao_6240 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_Revisao_6240", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  recurso.rec_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_ultima_revisao LIKE :recurso_UltimaRevisao_8188 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_UltimaRevisao_8188", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  recurso.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.entity_uid LIKE :recurso_EntityUid_6844 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_EntityUid_6844", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DiretorioOrigemExato" || parametro.FieldName == "DiretorioOrigemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_diretorio_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_diretorio_origem LIKE :recurso_DiretorioOrigem_1585 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_DiretorioOrigem_1585", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DiretorioDestinoExato" || parametro.FieldName == "DiretorioDestinoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  recurso.rec_diretorio_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  recurso.rec_diretorio_destino LIKE :recurso_DiretorioDestino_7523 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("recurso_DiretorioDestino_7523", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  RecursoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (RecursoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(RecursoClass), Convert.ToInt32(read["id_recurso"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new RecursoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_recurso"]);
                     if (read["id_posto_trabalho"] != DBNull.Value)
                     {
                        entidade.PostoTrabalho = (BibliotecaEntidades.Entidades.PostoTrabalhoClass)BibliotecaEntidades.Entidades.PostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_posto_trabalho"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PostoTrabalho = null ;
                     }
                     entidade.Codigo = (read["rec_codigo"] != DBNull.Value ? read["rec_codigo"].ToString() : null);
                     entidade.Nome = (read["rec_nome"] != DBNull.Value ? read["rec_nome"].ToString() : null);
                     entidade.Revisao = (read["rec_revisao"] != DBNull.Value ? read["rec_revisao"].ToString() : null);
                     entidade.DataInicio = read["rec_data_inicio"] as DateTime?;
                     entidade.DataTermino = read["rec_data_termino"] as DateTime?;
                     if (read["id_familia_recurso"] != DBNull.Value)
                     {
                        entidade.FamiliaRecurso = (BibliotecaEntidades.Entidades.FamiliaRecursoClass)BibliotecaEntidades.Entidades.FamiliaRecursoClass.GetEntidade(Convert.ToInt32(read["id_familia_recurso"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FamiliaRecurso = null ;
                     }
                     entidade.UltimaRevisao = (read["rec_ultima_revisao"] != DBNull.Value ? read["rec_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["rec_ultima_revisao_data"] as DateTime?;
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
                     entidade.Tipo = (TipoRecurso) (read["rec_tipo"] != DBNull.Value ? Enum.ToObject(typeof(TipoRecurso), read["rec_tipo"]) : null);
                     entidade.DiretorioOrigem = (read["rec_diretorio_origem"] != DBNull.Value ? read["rec_diretorio_origem"].ToString() : null);
                     entidade.DiretorioDestino = (read["rec_diretorio_destino"] != DBNull.Value ? read["rec_diretorio_destino"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (RecursoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
