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
     [Table("variavel","var")]
     public class VariavelBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do VariavelClass";
protected const string ErroDelete = "Erro ao excluir o VariavelClass  ";
protected const string ErroSave = "Erro ao salvar o VariavelClass.";
protected const string ErroCollectionProdutoClassVariavel1 = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCollectionProdutoClassVariavel2 = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCollectionProdutoClassVariavel3 = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCollectionProdutoClassVariavel4 = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do VariavelClass.";
protected const string MensagemUtilizadoCollectionProdutoClassVariavel1 =  "A entidade VariavelClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string MensagemUtilizadoCollectionProdutoClassVariavel2 =  "A entidade VariavelClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string MensagemUtilizadoCollectionProdutoClassVariavel3 =  "A entidade VariavelClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string MensagemUtilizadoCollectionProdutoClassVariavel4 =  "A entidade VariavelClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade VariavelClass está sendo utilizada.";
#endregion
       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("var_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("var_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.FamiliaClienteClass _familiaClienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FamiliaClienteClass _familiaClienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FamiliaClienteClass _valueFamiliaCliente;
        [Column("id_familia_cliente", "familia_cliente", "id_familia_cliente")]
       public virtual BibliotecaEntidades.Entidades.FamiliaClienteClass FamiliaCliente
        { 
           get {                 return this._valueFamiliaCliente; } 
           set 
           { 
                if (this._valueFamiliaCliente == value)return;
                 this._valueFamiliaCliente = value; 
           } 
       } 

       protected TipoRegra _tipoOriginal{get;private set;}
       private TipoRegra _tipoOriginalCommited{get; set;}
        private TipoRegra _valueTipo;
         [Column("var_tipo")]
        public virtual TipoRegra Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_RetornoNumero
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoRegra.RetornoNumero; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoRegra.RetornoNumero; }
         } 

        public bool Tipo_RetornoBoolean
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoRegra.RetornoBoolean; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoRegra.RetornoBoolean; }
         } 

        public bool Tipo_RetornoTexto
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoRegra.RetornoTexto; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoRegra.RetornoTexto; }
         } 

       private List<long> _collectionProdutoClassVariavel1Original;
       private List<Entidades.ProdutoClass > _collectionProdutoClassVariavel1Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel1Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel1Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel1CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassVariavel1 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassVariavel1 
       { 
           get { if(!_valueCollectionProdutoClassVariavel1Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassVariavel1();}
return this._valueCollectionProdutoClassVariavel1; } 
           set 
           { 
               this._valueCollectionProdutoClassVariavel1 = value; 
               this._valueCollectionProdutoClassVariavel1Loaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassVariavel2Original;
       private List<Entidades.ProdutoClass > _collectionProdutoClassVariavel2Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel2Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel2Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel2CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassVariavel2 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassVariavel2 
       { 
           get { if(!_valueCollectionProdutoClassVariavel2Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassVariavel2();}
return this._valueCollectionProdutoClassVariavel2; } 
           set 
           { 
               this._valueCollectionProdutoClassVariavel2 = value; 
               this._valueCollectionProdutoClassVariavel2Loaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassVariavel3Original;
       private List<Entidades.ProdutoClass > _collectionProdutoClassVariavel3Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel3Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel3Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel3CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassVariavel3 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassVariavel3 
       { 
           get { if(!_valueCollectionProdutoClassVariavel3Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassVariavel3();}
return this._valueCollectionProdutoClassVariavel3; } 
           set 
           { 
               this._valueCollectionProdutoClassVariavel3 = value; 
               this._valueCollectionProdutoClassVariavel3Loaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassVariavel4Original;
       private List<Entidades.ProdutoClass > _collectionProdutoClassVariavel4Removidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel4Loaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel4Changed { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassVariavel4CommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassVariavel4 { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassVariavel4 
       { 
           get { if(!_valueCollectionProdutoClassVariavel4Loaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassVariavel4();}
return this._valueCollectionProdutoClassVariavel4; } 
           set 
           { 
               this._valueCollectionProdutoClassVariavel4 = value; 
               this._valueCollectionProdutoClassVariavel4Loaded = true; 
           } 
       } 

        public VariavelBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Tipo = (TipoRegra)2;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static VariavelClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (VariavelClass) GetEntity(typeof(VariavelClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionProdutoClassVariavel1ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassVariavel1Changed = true;
                  _valueCollectionProdutoClassVariavel1CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassVariavel1Changed = true; 
                  _valueCollectionProdutoClassVariavel1CommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassVariavel1Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassVariavel1Changed = true; 
                  _valueCollectionProdutoClassVariavel1CommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassVariavel1) 
                 { 
                     _collectionProdutoClassVariavel1Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassVariavel1()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassVariavel1Changed = false;
                 _valueCollectionProdutoClassVariavel1CommitedChanged = false;
                _collectionProdutoClassVariavel1Removidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Variavel1", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassVariavel1 = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassVariavel1Original= (from a in _valueCollectionProdutoClassVariavel1 select a.ID).ToList();
                 _valueCollectionProdutoClassVariavel1Loaded = true;
                 oc.CollectionChanged += CollectionProdutoClassVariavel1ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassVariavel1+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassVariavel2ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassVariavel2Changed = true;
                  _valueCollectionProdutoClassVariavel2CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassVariavel2Changed = true; 
                  _valueCollectionProdutoClassVariavel2CommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassVariavel2Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassVariavel2Changed = true; 
                  _valueCollectionProdutoClassVariavel2CommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassVariavel2) 
                 { 
                     _collectionProdutoClassVariavel2Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassVariavel2()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassVariavel2Changed = false;
                 _valueCollectionProdutoClassVariavel2CommitedChanged = false;
                _collectionProdutoClassVariavel2Removidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Variavel2", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassVariavel2 = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassVariavel2Original= (from a in _valueCollectionProdutoClassVariavel2 select a.ID).ToList();
                 _valueCollectionProdutoClassVariavel2Loaded = true;
                 oc.CollectionChanged += CollectionProdutoClassVariavel2ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassVariavel2+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassVariavel3ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassVariavel3Changed = true;
                  _valueCollectionProdutoClassVariavel3CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassVariavel3Changed = true; 
                  _valueCollectionProdutoClassVariavel3CommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassVariavel3Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassVariavel3Changed = true; 
                  _valueCollectionProdutoClassVariavel3CommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassVariavel3) 
                 { 
                     _collectionProdutoClassVariavel3Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassVariavel3()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassVariavel3Changed = false;
                 _valueCollectionProdutoClassVariavel3CommitedChanged = false;
                _collectionProdutoClassVariavel3Removidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Variavel3", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassVariavel3 = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassVariavel3Original= (from a in _valueCollectionProdutoClassVariavel3 select a.ID).ToList();
                 _valueCollectionProdutoClassVariavel3Loaded = true;
                 oc.CollectionChanged += CollectionProdutoClassVariavel3ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassVariavel3+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassVariavel4ChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassVariavel4Changed = true;
                  _valueCollectionProdutoClassVariavel4CommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassVariavel4Changed = true; 
                  _valueCollectionProdutoClassVariavel4CommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassVariavel4Removidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassVariavel4Changed = true; 
                  _valueCollectionProdutoClassVariavel4CommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassVariavel4) 
                 { 
                     _collectionProdutoClassVariavel4Removidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassVariavel4()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassVariavel4Changed = false;
                 _valueCollectionProdutoClassVariavel4CommitedChanged = false;
                _collectionProdutoClassVariavel4Removidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Variavel4", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassVariavel4 = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassVariavel4Original= (from a in _valueCollectionProdutoClassVariavel4 select a.ID).ToList();
                 _valueCollectionProdutoClassVariavel4Loaded = true;
                 oc.CollectionChanged += CollectionProdutoClassVariavel4ChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassVariavel4+"\r\n" + e.Message, e);
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
                    "  public.variavel  " +
                    "WHERE " +
                    "  id_variavel = :id";
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
                        "  public.variavel   " +
                        "SET  " + 
                        "  var_nome = :var_nome, " + 
                        "  var_descricao = :var_descricao, " + 
                        "  id_familia_cliente = :id_familia_cliente, " + 
                        "  var_ultima_revisao = :var_ultima_revisao, " + 
                        "  var_ultima_revisao_data = :var_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  var_tipo = :var_tipo "+
                        "WHERE  " +
                        "  id_variavel = :id " +
                        "RETURNING id_variavel;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.variavel " +
                        "( " +
                        "  var_nome , " + 
                        "  var_descricao , " + 
                        "  id_familia_cliente , " + 
                        "  var_ultima_revisao , " + 
                        "  var_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  var_tipo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :var_nome , " + 
                        "  :var_descricao , " + 
                        "  :id_familia_cliente , " + 
                        "  :var_ultima_revisao , " + 
                        "  :var_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :var_tipo  "+
                        ")RETURNING id_variavel;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("var_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("var_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_familia_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FamiliaCliente==null ? (object) DBNull.Value : this.FamiliaCliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("var_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("var_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("var_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);

 
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
 if (CollectionProdutoClassVariavel1.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassVariavel1+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassVariavel1)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassVariavel2.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassVariavel2+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassVariavel2)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassVariavel3.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassVariavel3+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassVariavel3)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassVariavel4.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassVariavel4+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassVariavel4)
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
        public static VariavelClass CopiarEntidade(VariavelClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               VariavelClass toRet = new VariavelClass(usuario,conn);
 toRet.Nome= entidadeCopiar.Nome;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.FamiliaCliente= entidadeCopiar.FamiliaCliente;
 toRet.Tipo= entidadeCopiar.Tipo;

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
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _familiaClienteOriginal = FamiliaCliente;
       _familiaClienteOriginalCommited = _familiaClienteOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;

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
       _descricaoOriginalCommited = Descricao;
       _familiaClienteOriginalCommited = FamiliaCliente;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;
       _tipoOriginalCommited = Tipo;

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
               if (_valueCollectionProdutoClassVariavel1Loaded) 
               {
                  if (_collectionProdutoClassVariavel1Removidos != null) 
                  {
                     _collectionProdutoClassVariavel1Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassVariavel1Removidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassVariavel1Original= (from a in _valueCollectionProdutoClassVariavel1 select a.ID).ToList();
                  _valueCollectionProdutoClassVariavel1Changed = false;
                  _valueCollectionProdutoClassVariavel1CommitedChanged = false;
               }
               if (_valueCollectionProdutoClassVariavel2Loaded) 
               {
                  if (_collectionProdutoClassVariavel2Removidos != null) 
                  {
                     _collectionProdutoClassVariavel2Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassVariavel2Removidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassVariavel2Original= (from a in _valueCollectionProdutoClassVariavel2 select a.ID).ToList();
                  _valueCollectionProdutoClassVariavel2Changed = false;
                  _valueCollectionProdutoClassVariavel2CommitedChanged = false;
               }
               if (_valueCollectionProdutoClassVariavel3Loaded) 
               {
                  if (_collectionProdutoClassVariavel3Removidos != null) 
                  {
                     _collectionProdutoClassVariavel3Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassVariavel3Removidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassVariavel3Original= (from a in _valueCollectionProdutoClassVariavel3 select a.ID).ToList();
                  _valueCollectionProdutoClassVariavel3Changed = false;
                  _valueCollectionProdutoClassVariavel3CommitedChanged = false;
               }
               if (_valueCollectionProdutoClassVariavel4Loaded) 
               {
                  if (_collectionProdutoClassVariavel4Removidos != null) 
                  {
                     _collectionProdutoClassVariavel4Removidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassVariavel4Removidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassVariavel4Original= (from a in _valueCollectionProdutoClassVariavel4 select a.ID).ToList();
                  _valueCollectionProdutoClassVariavel4Changed = false;
                  _valueCollectionProdutoClassVariavel4CommitedChanged = false;
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
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               FamiliaCliente=_familiaClienteOriginal;
               _familiaClienteOriginalCommited=_familiaClienteOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               if (_valueCollectionProdutoClassVariavel1Loaded) 
               {
                  CollectionProdutoClassVariavel1.Clear();
                  foreach(int item in _collectionProdutoClassVariavel1Original)
                  {
                    CollectionProdutoClassVariavel1.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassVariavel1Removidos.Clear();
               }
               if (_valueCollectionProdutoClassVariavel2Loaded) 
               {
                  CollectionProdutoClassVariavel2.Clear();
                  foreach(int item in _collectionProdutoClassVariavel2Original)
                  {
                    CollectionProdutoClassVariavel2.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassVariavel2Removidos.Clear();
               }
               if (_valueCollectionProdutoClassVariavel3Loaded) 
               {
                  CollectionProdutoClassVariavel3.Clear();
                  foreach(int item in _collectionProdutoClassVariavel3Original)
                  {
                    CollectionProdutoClassVariavel3.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassVariavel3Removidos.Clear();
               }
               if (_valueCollectionProdutoClassVariavel4Loaded) 
               {
                  CollectionProdutoClassVariavel4.Clear();
                  foreach(int item in _collectionProdutoClassVariavel4Original)
                  {
                    CollectionProdutoClassVariavel4.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassVariavel4Removidos.Clear();
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
               if (_valueCollectionProdutoClassVariavel1Loaded) 
               {
                  if (_valueCollectionProdutoClassVariavel1Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassVariavel2Loaded) 
               {
                  if (_valueCollectionProdutoClassVariavel2Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassVariavel3Loaded) 
               {
                  if (_valueCollectionProdutoClassVariavel3Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassVariavel4Loaded) 
               {
                  if (_valueCollectionProdutoClassVariavel4Changed)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassVariavel1Loaded) 
               {
                   tempRet = CollectionProdutoClassVariavel1.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassVariavel2Loaded) 
               {
                   tempRet = CollectionProdutoClassVariavel2.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassVariavel3Loaded) 
               {
                   tempRet = CollectionProdutoClassVariavel3.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassVariavel4Loaded) 
               {
                   tempRet = CollectionProdutoClassVariavel4.Any(item => item.IsDirty());
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
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       if (_familiaClienteOriginal!=null)
       {
          dirty = !_familiaClienteOriginal.Equals(FamiliaCliente);
       }
       else
       {
            dirty = FamiliaCliente != null;
       }
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;

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
               if (_valueCollectionProdutoClassVariavel1Loaded) 
               {
                  if (_valueCollectionProdutoClassVariavel1CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassVariavel2Loaded) 
               {
                  if (_valueCollectionProdutoClassVariavel2CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassVariavel3Loaded) 
               {
                  if (_valueCollectionProdutoClassVariavel3CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassVariavel4Loaded) 
               {
                  if (_valueCollectionProdutoClassVariavel4CommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassVariavel1Loaded) 
               {
                   tempRet = CollectionProdutoClassVariavel1.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassVariavel2Loaded) 
               {
                   tempRet = CollectionProdutoClassVariavel2.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassVariavel3Loaded) 
               {
                   tempRet = CollectionProdutoClassVariavel3.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassVariavel4Loaded) 
               {
                   tempRet = CollectionProdutoClassVariavel4.Any(item => item.IsDirtyCommited());
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
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       if (_familiaClienteOriginalCommited!=null)
       {
          dirty = !_familiaClienteOriginalCommited.Equals(FamiliaCliente);
       }
       else
       {
            dirty = FamiliaCliente != null;
       }
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;

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
               if (_valueCollectionProdutoClassVariavel1Loaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassVariavel1)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassVariavel2Loaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassVariavel2)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassVariavel3Loaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassVariavel3)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassVariavel4Loaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassVariavel4)
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
             case "Descricao":
                return this.Descricao;
             case "FamiliaCliente":
                return this.FamiliaCliente;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Tipo":
                return this.Tipo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (FamiliaCliente!=null)
                FamiliaCliente.ChangeSingleConnection(newConnection);
               if (_valueCollectionProdutoClassVariavel1Loaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassVariavel1)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassVariavel2Loaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassVariavel2)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassVariavel3Loaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassVariavel3)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassVariavel4Loaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassVariavel4)
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
                  command.CommandText += " COUNT(variavel.id_variavel) " ;
               }
               else
               {
               command.CommandText += "variavel.id_variavel, " ;
               command.CommandText += "variavel.var_nome, " ;
               command.CommandText += "variavel.var_descricao, " ;
               command.CommandText += "variavel.id_familia_cliente, " ;
               command.CommandText += "variavel.var_ultima_revisao, " ;
               command.CommandText += "variavel.var_ultima_revisao_data, " ;
               command.CommandText += "variavel.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "variavel.entity_uid, " ;
               command.CommandText += "variavel.version, " ;
               command.CommandText += "variavel.var_tipo " ;
               }
               command.CommandText += " FROM  variavel ";
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
                        orderByClause += " , var_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(var_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = variavel.id_acs_usuario_ultima_revisao ";
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
                     case "id_variavel":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , variavel.id_variavel " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(variavel.id_variavel) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "var_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , variavel.var_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(variavel.var_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "var_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , variavel.var_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(variavel.var_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_familia_cliente":
                     case "FamiliaCliente":
                     command.CommandText += " LEFT JOIN familia_cliente as familia_cliente_FamiliaCliente ON familia_cliente_FamiliaCliente.id_familia_cliente = variavel.id_familia_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_cliente_FamiliaCliente.fac_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_cliente_FamiliaCliente.fac_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "var_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , variavel.var_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(variavel.var_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "var_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , variavel.var_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(variavel.var_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , variavel.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , variavel.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(variavel.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , variavel.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(variavel.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "var_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , variavel.var_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(variavel.var_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("var_nome")) 
                        {
                           whereClause += " OR UPPER(variavel.var_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(variavel.var_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("var_descricao")) 
                        {
                           whereClause += " OR UPPER(variavel.var_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(variavel.var_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("var_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(variavel.var_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(variavel.var_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(variavel.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(variavel.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_variavel")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  variavel.id_variavel IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.id_variavel = :variavel_ID_2563 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_ID_2563", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "var_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  variavel.var_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.var_nome LIKE :variavel_Nome_5915 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_Nome_5915", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "var_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  variavel.var_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.var_descricao LIKE :variavel_Descricao_4712 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_Descricao_4712", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FamiliaCliente" || parametro.FieldName == "id_familia_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FamiliaClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FamiliaClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  variavel.id_familia_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.id_familia_cliente = :variavel_FamiliaCliente_4781 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_FamiliaCliente_4781", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "var_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  variavel.var_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.var_ultima_revisao LIKE :variavel_UltimaRevisao_6194 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_UltimaRevisao_6194", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "var_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  variavel.var_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.var_ultima_revisao_data = :variavel_UltimaRevisaoData_4545 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_UltimaRevisaoData_4545", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  variavel.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.id_acs_usuario_ultima_revisao = :variavel_UltimaRevisaoUsuario_4730 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_UltimaRevisaoUsuario_4730", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  variavel.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.entity_uid LIKE :variavel_EntityUid_3136 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_EntityUid_3136", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  variavel.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.version = :variavel_Version_7510 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_Version_7510", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "var_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoRegra)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoRegra");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  variavel.var_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.var_tipo = :variavel_Tipo_5654 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_Tipo_5654", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  variavel.var_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.var_nome LIKE :variavel_Nome_5323 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_Nome_5323", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  variavel.var_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.var_descricao LIKE :variavel_Descricao_2336 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_Descricao_2336", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  variavel.var_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.var_ultima_revisao LIKE :variavel_UltimaRevisao_1363 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_UltimaRevisao_1363", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  variavel.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  variavel.entity_uid LIKE :variavel_EntityUid_4056 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("variavel_EntityUid_4056", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  VariavelClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (VariavelClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(VariavelClass), Convert.ToInt32(read["id_variavel"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new VariavelClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_variavel"]);
                     entidade.Nome = (read["var_nome"] != DBNull.Value ? read["var_nome"].ToString() : null);
                     entidade.Descricao = (read["var_descricao"] != DBNull.Value ? read["var_descricao"].ToString() : null);
                     if (read["id_familia_cliente"] != DBNull.Value)
                     {
                        entidade.FamiliaCliente = (BibliotecaEntidades.Entidades.FamiliaClienteClass)BibliotecaEntidades.Entidades.FamiliaClienteClass.GetEntidade(Convert.ToInt32(read["id_familia_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FamiliaCliente = null ;
                     }
                     entidade.UltimaRevisao = (read["var_ultima_revisao"] != DBNull.Value ? read["var_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["var_ultima_revisao_data"] as DateTime?;
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
                     entidade.Tipo = (TipoRegra) (read["var_tipo"] != DBNull.Value ? Enum.ToObject(typeof(TipoRegra), read["var_tipo"]) : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (VariavelClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
