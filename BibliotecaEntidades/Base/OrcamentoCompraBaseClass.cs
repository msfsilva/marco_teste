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
     [Table("orcamento_compra","oco")]
     public class OrcamentoCompraBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrcamentoCompraClass";
protected const string ErroDelete = "Erro ao excluir o OrcamentoCompraClass  ";
protected const string ErroSave = "Erro ao salvar o OrcamentoCompraClass.";
protected const string ErroCollectionOrcamentoCompraItemClassOrcamentoCompra = "Erro ao carregar a coleção de OrcamentoCompraItemClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrcamentoCompraClass.";
protected const string MensagemUtilizadoCollectionOrcamentoCompraItemClassOrcamentoCompra =  "A entidade OrcamentoCompraClass está sendo utilizada nos seguintes OrcamentoCompraItemClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoCompraClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.FornecedorClass _fornecedorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FornecedorClass _fornecedorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FornecedorClass _valueFornecedor;
        [Column("id_fornecedor", "fornecedor", "id_fornecedor")]
       public virtual BibliotecaEntidades.Entidades.FornecedorClass Fornecedor
        { 
           get {                 return this._valueFornecedor; } 
           set 
           { 
                if (this._valueFornecedor == value)return;
                 this._valueFornecedor = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuario;
        [Column("id_acs_usuario", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuario
        { 
           get {                 return this._valueAcsUsuario; } 
           set 
           { 
                if (this._valueAcsUsuario == value)return;
                 this._valueAcsUsuario = value; 
           } 
       } 

       protected DateTime _dataAberturaOriginal{get;private set;}
       private DateTime _dataAberturaOriginalCommited{get; set;}
        private DateTime _valueDataAbertura;
         [Column("oco_data_abertura")]
        public virtual DateTime DataAbertura
         { 
            get { return this._valueDataAbertura; } 
            set 
            { 
                if (this._valueDataAbertura == value)return;
                 this._valueDataAbertura = value; 
            } 
        } 

       protected int _prazoOriginal{get;private set;}
       private int _prazoOriginalCommited{get; set;}
        private int _valuePrazo;
         [Column("oco_prazo")]
        public virtual int Prazo
         { 
            get { return this._valuePrazo; } 
            set 
            { 
                if (this._valuePrazo == value)return;
                 this._valuePrazo = value; 
            } 
        } 

       protected StatusOrcamentoCompra _situacaoOriginal{get;private set;}
       private StatusOrcamentoCompra _situacaoOriginalCommited{get; set;}
        private StatusOrcamentoCompra _valueSituacao;
         [Column("oco_situacao")]
        public virtual StatusOrcamentoCompra Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

        public bool Situacao_Novo
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusOrcamentoCompra.Novo; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusOrcamentoCompra.Novo; }
         } 

        public bool Situacao_AguardandoRetorno
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusOrcamentoCompra.AguardandoRetorno; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusOrcamentoCompra.AguardandoRetorno; }
         } 

        public bool Situacao_RetornoParcial
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusOrcamentoCompra.RetornoParcial; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusOrcamentoCompra.RetornoParcial; }
         } 

        public bool Situacao_Encerrado
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusOrcamentoCompra.Encerrado; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusOrcamentoCompra.Encerrado; }
         } 

       private List<long> _collectionOrcamentoCompraItemClassOrcamentoCompraOriginal;
       private List<Entidades.OrcamentoCompraItemClass > _collectionOrcamentoCompraItemClassOrcamentoCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassOrcamentoCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraItemClassOrcamentoCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoCompraItemClass> _valueCollectionOrcamentoCompraItemClassOrcamentoCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoCompraItemClass> CollectionOrcamentoCompraItemClassOrcamentoCompra 
       { 
           get { if(!_valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoCompraItemClassOrcamentoCompra();}
return this._valueCollectionOrcamentoCompraItemClassOrcamentoCompra; } 
           set 
           { 
               this._valueCollectionOrcamentoCompraItemClassOrcamentoCompra = value; 
               this._valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded = true; 
           } 
       } 

        public OrcamentoCompraBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Situacao = (StatusOrcamentoCompra)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrcamentoCompraClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrcamentoCompraClass) GetEntity(typeof(OrcamentoCompraClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrcamentoCompraItemClassOrcamentoCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoCompraItemClassOrcamentoCompraChanged = true;
                  _valueCollectionOrcamentoCompraItemClassOrcamentoCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoCompraItemClassOrcamentoCompraChanged = true; 
                  _valueCollectionOrcamentoCompraItemClassOrcamentoCompraCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoCompraItemClassOrcamentoCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoCompraItemClassOrcamentoCompraChanged = true; 
                  _valueCollectionOrcamentoCompraItemClassOrcamentoCompraCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraItemClass item in _valueCollectionOrcamentoCompraItemClassOrcamentoCompra) 
                 { 
                     _collectionOrcamentoCompraItemClassOrcamentoCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoCompraItemClassOrcamentoCompra()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoCompraItemClass> oc;
                _valueCollectionOrcamentoCompraItemClassOrcamentoCompraChanged = false;
                 _valueCollectionOrcamentoCompraItemClassOrcamentoCompraCommitedChanged = false;
                _collectionOrcamentoCompraItemClassOrcamentoCompraRemovidos = new List<Entidades.OrcamentoCompraItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoCompraItemClass>();
                }
                else{ 
                   Entidades.OrcamentoCompraItemClass search = new Entidades.OrcamentoCompraItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoCompraItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrcamentoCompra", this),                     }                       ).Cast<Entidades.OrcamentoCompraItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoCompraItemClassOrcamentoCompra = new BindingList<Entidades.OrcamentoCompraItemClass>(oc); 
                 _collectionOrcamentoCompraItemClassOrcamentoCompraOriginal= (from a in _valueCollectionOrcamentoCompraItemClassOrcamentoCompra select a.ID).ToList();
                 _valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoCompraItemClassOrcamentoCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoCompraItemClassOrcamentoCompra+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueAcsUsuario == null)
                {
                    throw new Exception(ErroAcsUsuarioObrigatorio);
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
                    "  public.orcamento_compra  " +
                    "WHERE " +
                    "  id_orcamento_compra = :id";
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
                        "  public.orcamento_compra   " +
                        "SET  " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  oco_data_abertura = :oco_data_abertura, " + 
                        "  oco_prazo = :oco_prazo, " + 
                        "  oco_situacao = :oco_situacao, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_orcamento_compra = :id " +
                        "RETURNING id_orcamento_compra;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.orcamento_compra " +
                        "( " +
                        "  id_fornecedor , " + 
                        "  id_acs_usuario , " + 
                        "  oco_data_abertura , " + 
                        "  oco_prazo , " + 
                        "  oco_situacao , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_fornecedor , " + 
                        "  :id_acs_usuario , " + 
                        "  :oco_data_abertura , " + 
                        "  :oco_prazo , " + 
                        "  :oco_situacao , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_orcamento_compra;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oco_data_abertura", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAbertura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oco_prazo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Prazo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oco_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Situacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;

 
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
 if (CollectionOrcamentoCompraItemClassOrcamentoCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoCompraItemClassOrcamentoCompra+"\r\n";
                foreach (Entidades.OrcamentoCompraItemClass tmp in CollectionOrcamentoCompraItemClassOrcamentoCompra)
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
        public static OrcamentoCompraClass CopiarEntidade(OrcamentoCompraClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrcamentoCompraClass toRet = new OrcamentoCompraClass(usuario,conn);
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.DataAbertura= entidadeCopiar.DataAbertura;
 toRet.Prazo= entidadeCopiar.Prazo;
 toRet.Situacao= entidadeCopiar.Situacao;

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
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _dataAberturaOriginal = DataAbertura;
       _dataAberturaOriginalCommited = _dataAberturaOriginal;
       _prazoOriginal = Prazo;
       _prazoOriginalCommited = _prazoOriginal;
       _situacaoOriginal = Situacao;
       _situacaoOriginalCommited = _situacaoOriginal;
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
       _fornecedorOriginalCommited = Fornecedor;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _dataAberturaOriginalCommited = DataAbertura;
       _prazoOriginalCommited = Prazo;
       _situacaoOriginalCommited = Situacao;
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
               if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded) 
               {
                  if (_collectionOrcamentoCompraItemClassOrcamentoCompraRemovidos != null) 
                  {
                     _collectionOrcamentoCompraItemClassOrcamentoCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoCompraItemClassOrcamentoCompraRemovidos = new List<Entidades.OrcamentoCompraItemClass>();
                  }
                  _collectionOrcamentoCompraItemClassOrcamentoCompraOriginal= (from a in _valueCollectionOrcamentoCompraItemClassOrcamentoCompra select a.ID).ToList();
                  _valueCollectionOrcamentoCompraItemClassOrcamentoCompraChanged = false;
                  _valueCollectionOrcamentoCompraItemClassOrcamentoCompraCommitedChanged = false;
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
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               DataAbertura=_dataAberturaOriginal;
               _dataAberturaOriginalCommited=_dataAberturaOriginal;
               Prazo=_prazoOriginal;
               _prazoOriginalCommited=_prazoOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded) 
               {
                  CollectionOrcamentoCompraItemClassOrcamentoCompra.Clear();
                  foreach(int item in _collectionOrcamentoCompraItemClassOrcamentoCompraOriginal)
                  {
                    CollectionOrcamentoCompraItemClassOrcamentoCompra.Add(Entidades.OrcamentoCompraItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoCompraItemClassOrcamentoCompraRemovidos.Clear();
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
               if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraItemClassOrcamentoCompra.Any(item => item.IsDirty());
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
       if (_fornecedorOriginal!=null)
       {
          dirty = !_fornecedorOriginal.Equals(Fornecedor);
       }
       else
       {
            dirty = Fornecedor != null;
       }
      if (dirty) return true;
       if (_acsUsuarioOriginal!=null)
       {
          dirty = !_acsUsuarioOriginal.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataAberturaOriginal != DataAbertura;
      if (dirty) return true;
       dirty = _prazoOriginal != Prazo;
      if (dirty) return true;
       dirty = _situacaoOriginal != Situacao;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;

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
               if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraItemClassOrcamentoCompra.Any(item => item.IsDirtyCommited());
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
       if (_fornecedorOriginalCommited!=null)
       {
          dirty = !_fornecedorOriginalCommited.Equals(Fornecedor);
       }
       else
       {
            dirty = Fornecedor != null;
       }
      if (dirty) return true;
       if (_acsUsuarioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioOriginalCommited.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataAberturaOriginalCommited != DataAbertura;
      if (dirty) return true;
       dirty = _prazoOriginalCommited != Prazo;
      if (dirty) return true;
       dirty = _situacaoOriginalCommited != Situacao;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;

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
               if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded) 
               {
                  foreach(OrcamentoCompraItemClass item in CollectionOrcamentoCompraItemClassOrcamentoCompra)
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
             case "Fornecedor":
                return this.Fornecedor;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "DataAbertura":
                return this.DataAbertura;
             case "Prazo":
                return this.Prazo;
             case "Situacao":
                return this.Situacao;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
               if (_valueCollectionOrcamentoCompraItemClassOrcamentoCompraLoaded) 
               {
                  foreach(OrcamentoCompraItemClass item in CollectionOrcamentoCompraItemClassOrcamentoCompra)
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
                  command.CommandText += " COUNT(orcamento_compra.id_orcamento_compra) " ;
               }
               else
               {
               command.CommandText += "orcamento_compra.id_orcamento_compra, " ;
               command.CommandText += "orcamento_compra.id_fornecedor, " ;
               command.CommandText += "orcamento_compra.id_acs_usuario, " ;
               command.CommandText += "orcamento_compra.oco_data_abertura, " ;
               command.CommandText += "orcamento_compra.oco_prazo, " ;
               command.CommandText += "orcamento_compra.oco_situacao, " ;
               command.CommandText += "orcamento_compra.version, " ;
               command.CommandText += "orcamento_compra.entity_uid " ;
               }
               command.CommandText += " FROM  orcamento_compra ";
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
                        orderByClause += " , oco_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(oco_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = orcamento_compra.id_acs_usuario_ultima_revisao ";
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
                     case "id_orcamento_compra":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra.id_orcamento_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra.id_orcamento_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = orcamento_compra.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor_Fornecedor.for_nome_fantasia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor_Fornecedor.for_nome_fantasia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , orcamento_compra.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "oco_data_abertura":
                     case "DataAbertura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra.oco_data_abertura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra.oco_data_abertura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oco_prazo":
                     case "Prazo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra.oco_prazo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra.oco_prazo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oco_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra.oco_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra.oco_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , orcamento_compra.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_compra.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_compra.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(orcamento_compra.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_compra.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_orcamento_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra.id_orcamento_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra.id_orcamento_compra = :orcamento_compra_ID_6661 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_ID_6661", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fornecedor" || parametro.FieldName == "id_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FornecedorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FornecedorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra.id_fornecedor = :orcamento_compra_Fornecedor_6757 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_Fornecedor_6757", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuario" || parametro.FieldName == "id_acs_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra.id_acs_usuario = :orcamento_compra_AcsUsuario_5583 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_AcsUsuario_5583", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAbertura" || parametro.FieldName == "oco_data_abertura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra.oco_data_abertura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra.oco_data_abertura = :orcamento_compra_DataAbertura_1906 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_DataAbertura_1906", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Prazo" || parametro.FieldName == "oco_prazo")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra.oco_prazo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra.oco_prazo = :orcamento_compra_Prazo_6638 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_Prazo_6638", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "oco_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is StatusOrcamentoCompra)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo StatusOrcamentoCompra");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra.oco_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra.oco_situacao = :orcamento_compra_Situacao_1807 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_Situacao_1807", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  orcamento_compra.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra.version = :orcamento_compra_Version_1097 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_Version_1097", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  orcamento_compra.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra.entity_uid LIKE :orcamento_compra_EntityUid_1808 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_EntityUid_1808", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  orcamento_compra.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra.entity_uid LIKE :orcamento_compra_EntityUid_9590 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_EntityUid_9590", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrcamentoCompraClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrcamentoCompraClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrcamentoCompraClass), Convert.ToInt32(read["id_orcamento_compra"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrcamentoCompraClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_orcamento_compra"]);
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.DataAbertura = (DateTime)read["oco_data_abertura"];
                     entidade.Prazo = (int)read["oco_prazo"];
                     entidade.Situacao = (StatusOrcamentoCompra) (read["oco_situacao"] != DBNull.Value ? Enum.ToObject(typeof(StatusOrcamentoCompra), read["oco_situacao"]) : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrcamentoCompraClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
