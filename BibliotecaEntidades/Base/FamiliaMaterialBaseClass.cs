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
     [Table("familia_material","fam")]
     public class FamiliaMaterialBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do FamiliaMaterialClass";
protected const string ErroDelete = "Erro ao excluir o FamiliaMaterialClass  ";
protected const string ErroSave = "Erro ao salvar o FamiliaMaterialClass.";
protected const string ErroCollectionMaterialClassFamiliaMaterial = "Erro ao carregar a coleção de MaterialClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do FamiliaMaterialClass.";
protected const string MensagemUtilizadoCollectionMaterialClassFamiliaMaterial =  "A entidade FamiliaMaterialClass está sendo utilizada nos seguintes MaterialClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial =  "A entidade FamiliaMaterialClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade FamiliaMaterialClass está sendo utilizada.";
#endregion
       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("fam_codigo")]
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
         [Column("fam_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected bool _materialAuxiliarOriginal{get;private set;}
       private bool _materialAuxiliarOriginalCommited{get; set;}
        private bool _valueMaterialAuxiliar;
         [Column("fam_material_auxiliar")]
        public virtual bool MaterialAuxiliar
         { 
            get { return this._valueMaterialAuxiliar; } 
            set 
            { 
                if (this._valueMaterialAuxiliar == value)return;
                 this._valueMaterialAuxiliar = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.AgrupadorMaterialClass _agrupadorMaterialOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.AgrupadorMaterialClass _agrupadorMaterialOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.AgrupadorMaterialClass _valueAgrupadorMaterial;
        [Column("id_agrupador_material", "agrupador_material", "id_agrupador_material")]
       public virtual BibliotecaEntidades.Entidades.AgrupadorMaterialClass AgrupadorMaterial
        { 
           get {                 return this._valueAgrupadorMaterial; } 
           set 
           { 
                if (this._valueAgrupadorMaterial == value)return;
                 this._valueAgrupadorMaterial = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.CompradorClass _compradorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CompradorClass _compradorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CompradorClass _valueComprador;
        [Column("id_comprador", "comprador", "id_comprador")]
       public virtual BibliotecaEntidades.Entidades.CompradorClass Comprador
        { 
           get {                 return this._valueComprador; } 
           set 
           { 
                if (this._valueComprador == value)return;
                 this._valueComprador = value; 
           } 
       } 

       private List<long> _collectionMaterialClassFamiliaMaterialOriginal;
       private List<Entidades.MaterialClass > _collectionMaterialClassFamiliaMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassFamiliaMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassFamiliaMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassFamiliaMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialClass> _valueCollectionMaterialClassFamiliaMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialClass> CollectionMaterialClassFamiliaMaterial 
       { 
           get { if(!_valueCollectionMaterialClassFamiliaMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialClassFamiliaMaterial();}
return this._valueCollectionMaterialClassFamiliaMaterial; } 
           set 
           { 
               this._valueCollectionMaterialClassFamiliaMaterial = value; 
               this._valueCollectionMaterialClassFamiliaMaterialLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialOriginal;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded = true; 
           } 
       } 

        public FamiliaMaterialBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.MaterialAuxiliar = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static FamiliaMaterialClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (FamiliaMaterialClass) GetEntity(typeof(FamiliaMaterialClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionMaterialClassFamiliaMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialClassFamiliaMaterialChanged = true;
                  _valueCollectionMaterialClassFamiliaMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialClassFamiliaMaterialChanged = true; 
                  _valueCollectionMaterialClassFamiliaMaterialCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in e.OldItems) 
                 { 
                     _collectionMaterialClassFamiliaMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialClassFamiliaMaterialChanged = true; 
                  _valueCollectionMaterialClassFamiliaMaterialCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in _valueCollectionMaterialClassFamiliaMaterial) 
                 { 
                     _collectionMaterialClassFamiliaMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialClassFamiliaMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialClass> oc;
                _valueCollectionMaterialClassFamiliaMaterialChanged = false;
                 _valueCollectionMaterialClassFamiliaMaterialCommitedChanged = false;
                _collectionMaterialClassFamiliaMaterialRemovidos = new List<Entidades.MaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialClass>();
                }
                else{ 
                   Entidades.MaterialClass search = new Entidades.MaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FamiliaMaterial", this),                     }                       ).Cast<Entidades.MaterialClass>().ToList());
                 }
                 _valueCollectionMaterialClassFamiliaMaterial = new BindingList<Entidades.MaterialClass>(oc); 
                 _collectionMaterialClassFamiliaMaterialOriginal= (from a in _valueCollectionMaterialClassFamiliaMaterial select a.ID).ToList();
                 _valueCollectionMaterialClassFamiliaMaterialLoaded = true;
                 oc.CollectionChanged += CollectionMaterialClassFamiliaMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialClassFamiliaMaterial+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialChanged = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialChanged = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialCommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FamiliaMaterial", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial+"\r\n" + e.Message, e);
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
                if (Codigo.Length >255)
                {
                    throw new Exception( ErroCodigoComprimento);
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
                    "  public.familia_material  " +
                    "WHERE " +
                    "  id_familia_material = :id";
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
                        "  public.familia_material   " +
                        "SET  " + 
                        "  fam_codigo = :fam_codigo, " + 
                        "  fam_descricao = :fam_descricao, " + 
                        "  fam_material_auxiliar = :fam_material_auxiliar, " + 
                        "  id_agrupador_material = :id_agrupador_material, " + 
                        "  fam_ultima_revisao = :fam_ultima_revisao, " + 
                        "  fam_ultima_revisao_data = :fam_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_comprador = :id_comprador "+
                        "WHERE  " +
                        "  id_familia_material = :id " +
                        "RETURNING id_familia_material;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.familia_material " +
                        "( " +
                        "  fam_codigo , " + 
                        "  fam_descricao , " + 
                        "  fam_material_auxiliar , " + 
                        "  id_agrupador_material , " + 
                        "  fam_ultima_revisao , " + 
                        "  fam_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_comprador  "+
                        ")  " +
                        "VALUES ( " +
                        "  :fam_codigo , " + 
                        "  :fam_descricao , " + 
                        "  :fam_material_auxiliar , " + 
                        "  :id_agrupador_material , " + 
                        "  :fam_ultima_revisao , " + 
                        "  :fam_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_comprador  "+
                        ")RETURNING id_familia_material;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fam_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fam_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fam_material_auxiliar", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialAuxiliar ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_agrupador_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AgrupadorMaterial==null ? (object) DBNull.Value : this.AgrupadorMaterial.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fam_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fam_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_comprador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Comprador==null ? (object) DBNull.Value : this.Comprador.ID;

 
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
 if (CollectionMaterialClassFamiliaMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialClassFamiliaMaterial+"\r\n";
                foreach (Entidades.MaterialClass tmp in CollectionMaterialClassFamiliaMaterial)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial)
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
        public static FamiliaMaterialClass CopiarEntidade(FamiliaMaterialClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               FamiliaMaterialClass toRet = new FamiliaMaterialClass(usuario,conn);
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.MaterialAuxiliar= entidadeCopiar.MaterialAuxiliar;
 toRet.AgrupadorMaterial= entidadeCopiar.AgrupadorMaterial;
 toRet.Comprador= entidadeCopiar.Comprador;

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
       _materialAuxiliarOriginal = MaterialAuxiliar;
       _materialAuxiliarOriginalCommited = _materialAuxiliarOriginal;
       _agrupadorMaterialOriginal = AgrupadorMaterial;
       _agrupadorMaterialOriginalCommited = _agrupadorMaterialOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _compradorOriginal = Comprador;
       _compradorOriginalCommited = _compradorOriginal;

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
       _materialAuxiliarOriginalCommited = MaterialAuxiliar;
       _agrupadorMaterialOriginalCommited = AgrupadorMaterial;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;
       _compradorOriginalCommited = Comprador;

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
               if (_valueCollectionMaterialClassFamiliaMaterialLoaded) 
               {
                  if (_collectionMaterialClassFamiliaMaterialRemovidos != null) 
                  {
                     _collectionMaterialClassFamiliaMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialClassFamiliaMaterialRemovidos = new List<Entidades.MaterialClass>();
                  }
                  _collectionMaterialClassFamiliaMaterialOriginal= (from a in _valueCollectionMaterialClassFamiliaMaterial select a.ID).ToList();
                  _valueCollectionMaterialClassFamiliaMaterialChanged = false;
                  _valueCollectionMaterialClassFamiliaMaterialCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialRemovidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialChanged = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialCommitedChanged = false;
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
               MaterialAuxiliar=_materialAuxiliarOriginal;
               _materialAuxiliarOriginalCommited=_materialAuxiliarOriginal;
               AgrupadorMaterial=_agrupadorMaterialOriginal;
               _agrupadorMaterialOriginalCommited=_agrupadorMaterialOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Comprador=_compradorOriginal;
               _compradorOriginalCommited=_compradorOriginal;
               if (_valueCollectionMaterialClassFamiliaMaterialLoaded) 
               {
                  CollectionMaterialClassFamiliaMaterial.Clear();
                  foreach(int item in _collectionMaterialClassFamiliaMaterialOriginal)
                  {
                    CollectionMaterialClassFamiliaMaterial.Add(Entidades.MaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialClassFamiliaMaterialRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialOriginal)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassFamiliaMaterialRemovidos.Clear();
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
               if (_valueCollectionMaterialClassFamiliaMaterialLoaded) 
               {
                  if (_valueCollectionMaterialClassFamiliaMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassFamiliaMaterialLoaded) 
               {
                   tempRet = CollectionMaterialClassFamiliaMaterial.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial.Any(item => item.IsDirty());
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
       dirty = _materialAuxiliarOriginal != MaterialAuxiliar;
      if (dirty) return true;
       if (_agrupadorMaterialOriginal!=null)
       {
          dirty = !_agrupadorMaterialOriginal.Equals(AgrupadorMaterial);
       }
       else
       {
            dirty = AgrupadorMaterial != null;
       }
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_compradorOriginal!=null)
       {
          dirty = !_compradorOriginal.Equals(Comprador);
       }
       else
       {
            dirty = Comprador != null;
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
               if (_valueCollectionMaterialClassFamiliaMaterialLoaded) 
               {
                  if (_valueCollectionMaterialClassFamiliaMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassFamiliaMaterialLoaded) 
               {
                   tempRet = CollectionMaterialClassFamiliaMaterial.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial.Any(item => item.IsDirtyCommited());
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
       dirty = _materialAuxiliarOriginalCommited != MaterialAuxiliar;
      if (dirty) return true;
       if (_agrupadorMaterialOriginalCommited!=null)
       {
          dirty = !_agrupadorMaterialOriginalCommited.Equals(AgrupadorMaterial);
       }
       else
       {
            dirty = AgrupadorMaterial != null;
       }
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_compradorOriginalCommited!=null)
       {
          dirty = !_compradorOriginalCommited.Equals(Comprador);
       }
       else
       {
            dirty = Comprador != null;
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
               if (_valueCollectionMaterialClassFamiliaMaterialLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassFamiliaMaterial)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial)
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
             case "MaterialAuxiliar":
                return this.MaterialAuxiliar;
             case "AgrupadorMaterial":
                return this.AgrupadorMaterial;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Comprador":
                return this.Comprador;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (AgrupadorMaterial!=null)
                AgrupadorMaterial.ChangeSingleConnection(newConnection);
             if (Comprador!=null)
                Comprador.ChangeSingleConnection(newConnection);
               if (_valueCollectionMaterialClassFamiliaMaterialLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassFamiliaMaterial)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassFamiliaMaterialLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassFamiliaMaterial)
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
                  command.CommandText += " COUNT(familia_material.id_familia_material) " ;
               }
               else
               {
               command.CommandText += "familia_material.id_familia_material, " ;
               command.CommandText += "familia_material.fam_codigo, " ;
               command.CommandText += "familia_material.fam_descricao, " ;
               command.CommandText += "familia_material.fam_material_auxiliar, " ;
               command.CommandText += "familia_material.id_agrupador_material, " ;
               command.CommandText += "familia_material.fam_ultima_revisao, " ;
               command.CommandText += "familia_material.fam_ultima_revisao_data, " ;
               command.CommandText += "familia_material.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "familia_material.entity_uid, " ;
               command.CommandText += "familia_material.version, " ;
               command.CommandText += "familia_material.id_comprador " ;
               }
               command.CommandText += " FROM  familia_material ";
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
                        orderByClause += " , fam_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(fam_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = familia_material.id_acs_usuario_ultima_revisao ";
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
                     case "id_familia_material":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , familia_material.id_familia_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(familia_material.id_familia_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fam_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_material.fam_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_material.fam_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fam_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_material.fam_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_material.fam_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fam_material_auxiliar":
                     case "MaterialAuxiliar":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , familia_material.fam_material_auxiliar " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(familia_material.fam_material_auxiliar) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_agrupador_material":
                     case "AgrupadorMaterial":
                     command.CommandText += " LEFT JOIN agrupador_material as agrupador_material_AgrupadorMaterial ON agrupador_material_AgrupadorMaterial.id_agrupador_material = familia_material.id_agrupador_material ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_material_AgrupadorMaterial.agm_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_material_AgrupadorMaterial.agm_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fam_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_material.fam_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_material.fam_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fam_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , familia_material.fam_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(familia_material.fam_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , familia_material.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_material.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_material.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , familia_material.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(familia_material.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_comprador":
                     case "Comprador":
                     command.CommandText += " LEFT JOIN comprador as comprador_Comprador ON comprador_Comprador.id_comprador = familia_material.id_comprador ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador_Comprador.com_apelido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador_Comprador.com_apelido) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fam_codigo")) 
                        {
                           whereClause += " OR UPPER(familia_material.fam_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(familia_material.fam_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fam_descricao")) 
                        {
                           whereClause += " OR UPPER(familia_material.fam_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(familia_material.fam_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fam_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(familia_material.fam_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(familia_material.fam_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(familia_material.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(familia_material.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_familia_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_material.id_familia_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.id_familia_material = :familia_material_ID_1744 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_ID_1744", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "fam_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_material.fam_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.fam_codigo LIKE :familia_material_Codigo_5332 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_Codigo_5332", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "fam_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_material.fam_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.fam_descricao LIKE :familia_material_Descricao_7661 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_Descricao_7661", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialAuxiliar" || parametro.FieldName == "fam_material_auxiliar")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_material.fam_material_auxiliar IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.fam_material_auxiliar = :familia_material_MaterialAuxiliar_7197 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_MaterialAuxiliar_7197", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgrupadorMaterial" || parametro.FieldName == "id_agrupador_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.AgrupadorMaterialClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.AgrupadorMaterialClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_material.id_agrupador_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.id_agrupador_material = :familia_material_AgrupadorMaterial_9160 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_AgrupadorMaterial_9160", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "fam_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_material.fam_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.fam_ultima_revisao LIKE :familia_material_UltimaRevisao_3674 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_UltimaRevisao_3674", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "fam_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_material.fam_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.fam_ultima_revisao_data = :familia_material_UltimaRevisaoData_1652 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_UltimaRevisaoData_1652", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  familia_material.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.id_acs_usuario_ultima_revisao = :familia_material_UltimaRevisaoUsuario_8388 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_UltimaRevisaoUsuario_8388", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  familia_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.entity_uid LIKE :familia_material_EntityUid_5052 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_EntityUid_5052", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  familia_material.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.version = :familia_material_Version_5948 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_Version_5948", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Comprador" || parametro.FieldName == "id_comprador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CompradorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CompradorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  familia_material.id_comprador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.id_comprador = :familia_material_Comprador_3060 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_Comprador_3060", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  familia_material.fam_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.fam_codigo LIKE :familia_material_Codigo_2625 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_Codigo_2625", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  familia_material.fam_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.fam_descricao LIKE :familia_material_Descricao_8736 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_Descricao_8736", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  familia_material.fam_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.fam_ultima_revisao LIKE :familia_material_UltimaRevisao_3951 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_UltimaRevisao_3951", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  familia_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  familia_material.entity_uid LIKE :familia_material_EntityUid_6662 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("familia_material_EntityUid_6662", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  FamiliaMaterialClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (FamiliaMaterialClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(FamiliaMaterialClass), Convert.ToInt32(read["id_familia_material"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new FamiliaMaterialClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_familia_material"]);
                     entidade.Codigo = (read["fam_codigo"] != DBNull.Value ? read["fam_codigo"].ToString() : null);
                     entidade.Descricao = (read["fam_descricao"] != DBNull.Value ? read["fam_descricao"].ToString() : null);
                     entidade.MaterialAuxiliar = Convert.ToBoolean(Convert.ToInt16(read["fam_material_auxiliar"]));
                     if (read["id_agrupador_material"] != DBNull.Value)
                     {
                        entidade.AgrupadorMaterial = (BibliotecaEntidades.Entidades.AgrupadorMaterialClass)BibliotecaEntidades.Entidades.AgrupadorMaterialClass.GetEntidade(Convert.ToInt32(read["id_agrupador_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AgrupadorMaterial = null ;
                     }
                     entidade.UltimaRevisao = (read["fam_ultima_revisao"] != DBNull.Value ? read["fam_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["fam_ultima_revisao_data"] as DateTime?;
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
                     if (read["id_comprador"] != DBNull.Value)
                     {
                        entidade.Comprador = (BibliotecaEntidades.Entidades.CompradorClass)BibliotecaEntidades.Entidades.CompradorClass.GetEntidade(Convert.ToInt32(read["id_comprador"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Comprador = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (FamiliaMaterialClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
