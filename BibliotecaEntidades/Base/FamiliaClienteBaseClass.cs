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
     [Table("familia_cliente","fac")]
     public class FamiliaClienteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do FamiliaClienteClass";
protected const string ErroDelete = "Erro ao excluir o FamiliaClienteClass  ";
protected const string ErroSave = "Erro ao salvar o FamiliaClienteClass.";
protected const string ErroCollectionClienteClassFamiliaCliente = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionProdutoClassFamiliaCliente = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCollectionVariavelClassFamiliaCliente = "Erro ao carregar a coleção de VariavelClass.";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do FamiliaClienteClass.";
protected const string MensagemUtilizadoCollectionClienteClassFamiliaCliente =  "A entidade FamiliaClienteClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionProdutoClassFamiliaCliente =  "A entidade FamiliaClienteClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string MensagemUtilizadoCollectionVariavelClassFamiliaCliente =  "A entidade FamiliaClienteClass está sendo utilizada nos seguintes VariavelClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade FamiliaClienteClass está sendo utilizada.";
#endregion
       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("fac_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected TipoFamiliaEspecial _tipoEspecialOriginal{get;private set;}
       private TipoFamiliaEspecial _tipoEspecialOriginalCommited{get; set;}
        private TipoFamiliaEspecial _valueTipoEspecial;
         [Column("fac_tipo_especial")]
        public virtual TipoFamiliaEspecial TipoEspecial
         { 
            get { return this._valueTipoEspecial; } 
            set 
            { 
                if (this._valueTipoEspecial == value)return;
                 this._valueTipoEspecial = value; 
            } 
        } 

        public bool TipoEspecial_ClienteComum
         { 
            get { return this._valueTipoEspecial == BibliotecaEntidades.Base.TipoFamiliaEspecial.ClienteComum; } 
            set { if (value) this._valueTipoEspecial = BibliotecaEntidades.Base.TipoFamiliaEspecial.ClienteComum; }
         } 

        public bool TipoEspecial_EASSA
         { 
            get { return this._valueTipoEspecial == BibliotecaEntidades.Base.TipoFamiliaEspecial.EASSA; } 
            set { if (value) this._valueTipoEspecial = BibliotecaEntidades.Base.TipoFamiliaEspecial.EASSA; }
         } 

       private List<long> _collectionClienteClassFamiliaClienteOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassFamiliaClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassFamiliaClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassFamiliaClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassFamiliaClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassFamiliaCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassFamiliaCliente 
       { 
           get { if(!_valueCollectionClienteClassFamiliaClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassFamiliaCliente();}
return this._valueCollectionClienteClassFamiliaCliente; } 
           set 
           { 
               this._valueCollectionClienteClassFamiliaCliente = value; 
               this._valueCollectionClienteClassFamiliaClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassFamiliaClienteOriginal;
       private List<Entidades.ProdutoClass > _collectionProdutoClassFamiliaClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassFamiliaClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassFamiliaClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassFamiliaClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassFamiliaCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassFamiliaCliente 
       { 
           get { if(!_valueCollectionProdutoClassFamiliaClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassFamiliaCliente();}
return this._valueCollectionProdutoClassFamiliaCliente; } 
           set 
           { 
               this._valueCollectionProdutoClassFamiliaCliente = value; 
               this._valueCollectionProdutoClassFamiliaClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionVariavelClassFamiliaClienteOriginal;
       private List<Entidades.VariavelClass > _collectionVariavelClassFamiliaClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVariavelClassFamiliaClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVariavelClassFamiliaClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVariavelClassFamiliaClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.VariavelClass> _valueCollectionVariavelClassFamiliaCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.VariavelClass> CollectionVariavelClassFamiliaCliente 
       { 
           get { if(!_valueCollectionVariavelClassFamiliaClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionVariavelClassFamiliaCliente();}
return this._valueCollectionVariavelClassFamiliaCliente; } 
           set 
           { 
               this._valueCollectionVariavelClassFamiliaCliente = value; 
               this._valueCollectionVariavelClassFamiliaClienteLoaded = true; 
           } 
       } 

        public FamiliaClienteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.TipoEspecial = (TipoFamiliaEspecial)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static FamiliaClienteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (FamiliaClienteClass) GetEntity(typeof(FamiliaClienteClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionClienteClassFamiliaClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassFamiliaClienteChanged = true;
                  _valueCollectionClienteClassFamiliaClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassFamiliaClienteChanged = true; 
                  _valueCollectionClienteClassFamiliaClienteCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassFamiliaClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassFamiliaClienteChanged = true; 
                  _valueCollectionClienteClassFamiliaClienteCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassFamiliaCliente) 
                 { 
                     _collectionClienteClassFamiliaClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassFamiliaCliente()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassFamiliaClienteChanged = false;
                 _valueCollectionClienteClassFamiliaClienteCommitedChanged = false;
                _collectionClienteClassFamiliaClienteRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FamiliaCliente", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassFamiliaCliente = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassFamiliaClienteOriginal= (from a in _valueCollectionClienteClassFamiliaCliente select a.ID).ToList();
                 _valueCollectionClienteClassFamiliaClienteLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassFamiliaClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassFamiliaCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassFamiliaClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassFamiliaClienteChanged = true;
                  _valueCollectionProdutoClassFamiliaClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassFamiliaClienteChanged = true; 
                  _valueCollectionProdutoClassFamiliaClienteCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassFamiliaClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassFamiliaClienteChanged = true; 
                  _valueCollectionProdutoClassFamiliaClienteCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassFamiliaCliente) 
                 { 
                     _collectionProdutoClassFamiliaClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassFamiliaCliente()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassFamiliaClienteChanged = false;
                 _valueCollectionProdutoClassFamiliaClienteCommitedChanged = false;
                _collectionProdutoClassFamiliaClienteRemovidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FamiliaCliente", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassFamiliaCliente = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassFamiliaClienteOriginal= (from a in _valueCollectionProdutoClassFamiliaCliente select a.ID).ToList();
                 _valueCollectionProdutoClassFamiliaClienteLoaded = true;
                 oc.CollectionChanged += CollectionProdutoClassFamiliaClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassFamiliaCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionVariavelClassFamiliaClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionVariavelClassFamiliaClienteChanged = true;
                  _valueCollectionVariavelClassFamiliaClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionVariavelClassFamiliaClienteChanged = true; 
                  _valueCollectionVariavelClassFamiliaClienteCommitedChanged = true;
                 foreach (Entidades.VariavelClass item in e.OldItems) 
                 { 
                     _collectionVariavelClassFamiliaClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionVariavelClassFamiliaClienteChanged = true; 
                  _valueCollectionVariavelClassFamiliaClienteCommitedChanged = true;
                 foreach (Entidades.VariavelClass item in _valueCollectionVariavelClassFamiliaCliente) 
                 { 
                     _collectionVariavelClassFamiliaClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionVariavelClassFamiliaCliente()
         {
            try
            {
                 ObservableCollection<Entidades.VariavelClass> oc;
                _valueCollectionVariavelClassFamiliaClienteChanged = false;
                 _valueCollectionVariavelClassFamiliaClienteCommitedChanged = false;
                _collectionVariavelClassFamiliaClienteRemovidos = new List<Entidades.VariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.VariavelClass>();
                }
                else{ 
                   Entidades.VariavelClass search = new Entidades.VariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.VariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FamiliaCliente", this),                     }                       ).Cast<Entidades.VariavelClass>().ToList());
                 }
                 _valueCollectionVariavelClassFamiliaCliente = new BindingList<Entidades.VariavelClass>(oc); 
                 _collectionVariavelClassFamiliaClienteOriginal= (from a in _valueCollectionVariavelClassFamiliaCliente select a.ID).ToList();
                 _valueCollectionVariavelClassFamiliaClienteLoaded = true;
                 oc.CollectionChanged += CollectionVariavelClassFamiliaClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionVariavelClassFamiliaCliente+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                {
                    throw new Exception(ErroNomeObrigatorio);
                }
                if (Nome.Length >255)
                {
                    throw new Exception( ErroNomeComprimento);
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
                    "  public.familia_cliente  " +
                    "WHERE " +
                    "  id_familia_cliente = :id";
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
                        "  public.familia_cliente   " +
                        "SET  " + 
                        "  fac_nome = :fac_nome, " + 
                        "  fac_tipo_especial = :fac_tipo_especial, " + 
                        "  fac_ultima_revisao = :fac_ultima_revisao, " + 
                        "  fac_ultima_revisao_data = :fac_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_familia_cliente = :id " +
                        "RETURNING id_familia_cliente;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.familia_cliente " +
                        "( " +
                        "  fac_nome , " + 
                        "  fac_tipo_especial , " + 
                        "  fac_ultima_revisao , " + 
                        "  fac_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :fac_nome , " + 
                        "  :fac_tipo_especial , " + 
                        "  :fac_ultima_revisao , " + 
                        "  :fac_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_familia_cliente;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fac_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fac_tipo_especial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoEspecial);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fac_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fac_ultima_revisao_data", NpgsqlDbType.Timestamp));
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
 if (CollectionClienteClassFamiliaCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassFamiliaCliente+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassFamiliaCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassFamiliaCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassFamiliaCliente+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassFamiliaCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionVariavelClassFamiliaCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionVariavelClassFamiliaCliente+"\r\n";
                foreach (Entidades.VariavelClass tmp in CollectionVariavelClassFamiliaCliente)
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
        public static FamiliaClienteClass CopiarEntidade(FamiliaClienteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               FamiliaClienteClass toRet = new FamiliaClienteClass(usuario,conn);
 toRet.Nome= entidadeCopiar.Nome;
 toRet.TipoEspecial= entidadeCopiar.TipoEspecial;

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
       _tipoEspecialOriginal = TipoEspecial;
       _tipoEspecialOriginalCommited = _tipoEspecialOriginal;
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
       _nomeOriginalCommited = Nome;
       _tipoEspecialOriginalCommited = TipoEspecial;
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
               if (_valueCollectionClienteClassFamiliaClienteLoaded) 
               {
                  if (_collectionClienteClassFamiliaClienteRemovidos != null) 
                  {
                     _collectionClienteClassFamiliaClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassFamiliaClienteRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassFamiliaClienteOriginal= (from a in _valueCollectionClienteClassFamiliaCliente select a.ID).ToList();
                  _valueCollectionClienteClassFamiliaClienteChanged = false;
                  _valueCollectionClienteClassFamiliaClienteCommitedChanged = false;
               }
               if (_valueCollectionProdutoClassFamiliaClienteLoaded) 
               {
                  if (_collectionProdutoClassFamiliaClienteRemovidos != null) 
                  {
                     _collectionProdutoClassFamiliaClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassFamiliaClienteRemovidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassFamiliaClienteOriginal= (from a in _valueCollectionProdutoClassFamiliaCliente select a.ID).ToList();
                  _valueCollectionProdutoClassFamiliaClienteChanged = false;
                  _valueCollectionProdutoClassFamiliaClienteCommitedChanged = false;
               }
               if (_valueCollectionVariavelClassFamiliaClienteLoaded) 
               {
                  if (_collectionVariavelClassFamiliaClienteRemovidos != null) 
                  {
                     _collectionVariavelClassFamiliaClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionVariavelClassFamiliaClienteRemovidos = new List<Entidades.VariavelClass>();
                  }
                  _collectionVariavelClassFamiliaClienteOriginal= (from a in _valueCollectionVariavelClassFamiliaCliente select a.ID).ToList();
                  _valueCollectionVariavelClassFamiliaClienteChanged = false;
                  _valueCollectionVariavelClassFamiliaClienteCommitedChanged = false;
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
               TipoEspecial=_tipoEspecialOriginal;
               _tipoEspecialOriginalCommited=_tipoEspecialOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionClienteClassFamiliaClienteLoaded) 
               {
                  CollectionClienteClassFamiliaCliente.Clear();
                  foreach(int item in _collectionClienteClassFamiliaClienteOriginal)
                  {
                    CollectionClienteClassFamiliaCliente.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassFamiliaClienteRemovidos.Clear();
               }
               if (_valueCollectionProdutoClassFamiliaClienteLoaded) 
               {
                  CollectionProdutoClassFamiliaCliente.Clear();
                  foreach(int item in _collectionProdutoClassFamiliaClienteOriginal)
                  {
                    CollectionProdutoClassFamiliaCliente.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassFamiliaClienteRemovidos.Clear();
               }
               if (_valueCollectionVariavelClassFamiliaClienteLoaded) 
               {
                  CollectionVariavelClassFamiliaCliente.Clear();
                  foreach(int item in _collectionVariavelClassFamiliaClienteOriginal)
                  {
                    CollectionVariavelClassFamiliaCliente.Add(Entidades.VariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionVariavelClassFamiliaClienteRemovidos.Clear();
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
               if (_valueCollectionClienteClassFamiliaClienteLoaded) 
               {
                  if (_valueCollectionClienteClassFamiliaClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassFamiliaClienteLoaded) 
               {
                  if (_valueCollectionProdutoClassFamiliaClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionVariavelClassFamiliaClienteLoaded) 
               {
                  if (_valueCollectionVariavelClassFamiliaClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassFamiliaClienteLoaded) 
               {
                   tempRet = CollectionClienteClassFamiliaCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassFamiliaClienteLoaded) 
               {
                   tempRet = CollectionProdutoClassFamiliaCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionVariavelClassFamiliaClienteLoaded) 
               {
                   tempRet = CollectionVariavelClassFamiliaCliente.Any(item => item.IsDirty());
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
       dirty = _tipoEspecialOriginal != TipoEspecial;
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
               if (_valueCollectionClienteClassFamiliaClienteLoaded) 
               {
                  if (_valueCollectionClienteClassFamiliaClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassFamiliaClienteLoaded) 
               {
                  if (_valueCollectionProdutoClassFamiliaClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionVariavelClassFamiliaClienteLoaded) 
               {
                  if (_valueCollectionVariavelClassFamiliaClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassFamiliaClienteLoaded) 
               {
                   tempRet = CollectionClienteClassFamiliaCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassFamiliaClienteLoaded) 
               {
                   tempRet = CollectionProdutoClassFamiliaCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionVariavelClassFamiliaClienteLoaded) 
               {
                   tempRet = CollectionVariavelClassFamiliaCliente.Any(item => item.IsDirtyCommited());
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
       dirty = _tipoEspecialOriginalCommited != TipoEspecial;
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
               if (_valueCollectionClienteClassFamiliaClienteLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassFamiliaCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassFamiliaClienteLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassFamiliaCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionVariavelClassFamiliaClienteLoaded) 
               {
                  foreach(VariavelClass item in CollectionVariavelClassFamiliaCliente)
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
             case "TipoEspecial":
                return this.TipoEspecial;
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
               if (_valueCollectionClienteClassFamiliaClienteLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassFamiliaCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassFamiliaClienteLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassFamiliaCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionVariavelClassFamiliaClienteLoaded) 
               {
                  foreach(VariavelClass item in CollectionVariavelClassFamiliaCliente)
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
                  command.CommandText += " COUNT(familia_cliente.id_familia_cliente) " ;
               }
               else
               {
               command.CommandText += "familia_cliente.id_familia_cliente, " ;
               command.CommandText += "familia_cliente.fac_nome, " ;
               command.CommandText += "familia_cliente.fac_tipo_especial, " ;
               command.CommandText += "familia_cliente.fac_ultima_revisao, " ;
               command.CommandText += "familia_cliente.fac_ultima_revisao_data, " ;
               command.CommandText += "familia_cliente.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "familia_cliente.entity_uid, " ;
               command.CommandText += "familia_cliente.version " ;
               }
               command.CommandText += " FROM  familia_cliente ";
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
                        orderByClause += " , fac_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(fac_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = familia_cliente.id_acs_usuario_ultima_revisao ";
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
                     case "id_familia_cliente":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , familia_cliente.id_familia_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(familia_cliente.id_familia_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fac_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_cliente.fac_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_cliente.fac_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fac_tipo_especial":
                     case "TipoEspecial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , familia_cliente.fac_tipo_especial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(familia_cliente.fac_tipo_especial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fac_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_cliente.fac_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_cliente.fac_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fac_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , familia_cliente.fac_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(familia_cliente.fac_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , familia_cliente.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_cliente.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_cliente.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , familia_cliente.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(familia_cliente.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fac_nome")) 
                        {
                           whereClause += " OR UPPER(familia_cliente.fac_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(familia_cliente.fac_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fac_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(familia_cliente.fac_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(familia_cliente.fac_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(familia_cliente.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(familia_cliente.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_familia_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_cliente.id_familia_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.id_familia_cliente = :familia_cliente_ID_6203 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_ID_6203", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "fac_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_cliente.fac_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.fac_nome LIKE :familia_cliente_Nome_7425 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_Nome_7425", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoEspecial" || parametro.FieldName == "fac_tipo_especial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoFamiliaEspecial)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoFamiliaEspecial");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_cliente.fac_tipo_especial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.fac_tipo_especial = :familia_cliente_TipoEspecial_9136 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_TipoEspecial_9136", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "fac_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_cliente.fac_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.fac_ultima_revisao LIKE :familia_cliente_UltimaRevisao_6879 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_UltimaRevisao_6879", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "fac_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_cliente.fac_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.fac_ultima_revisao_data = :familia_cliente_UltimaRevisaoData_6962 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_UltimaRevisaoData_6962", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  familia_cliente.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.id_acs_usuario_ultima_revisao = :familia_cliente_UltimaRevisaoUsuario_2942 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_UltimaRevisaoUsuario_2942", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  familia_cliente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.entity_uid LIKE :familia_cliente_EntityUid_1065 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_EntityUid_1065", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  familia_cliente.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.version = :familia_cliente_Version_2598 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_Version_2598", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  familia_cliente.fac_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.fac_nome LIKE :familia_cliente_Nome_6904 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_Nome_6904", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  familia_cliente.fac_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.fac_ultima_revisao LIKE :familia_cliente_UltimaRevisao_2635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_UltimaRevisao_2635", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  familia_cliente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_cliente.entity_uid LIKE :familia_cliente_EntityUid_6796 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_cliente_EntityUid_6796", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  FamiliaClienteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (FamiliaClienteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(FamiliaClienteClass), Convert.ToInt32(read["id_familia_cliente"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new FamiliaClienteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_familia_cliente"]);
                     entidade.Nome = (read["fac_nome"] != DBNull.Value ? read["fac_nome"].ToString() : null);
                     entidade.TipoEspecial = (TipoFamiliaEspecial) (read["fac_tipo_especial"] != DBNull.Value ? Enum.ToObject(typeof(TipoFamiliaEspecial), read["fac_tipo_especial"]) : null);
                     entidade.UltimaRevisao = (read["fac_ultima_revisao"] != DBNull.Value ? read["fac_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["fac_ultima_revisao_data"] as DateTime?;
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
                     entidade = (FamiliaClienteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
