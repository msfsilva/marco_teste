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
     [Table("estoque_prateleira","esp")]
     public class EstoquePrateleiraBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EstoquePrateleiraClass";
protected const string ErroDelete = "Erro ao excluir o EstoquePrateleiraClass  ";
protected const string ErroSave = "Erro ao salvar o EstoquePrateleiraClass.";
protected const string ErroCollectionEstoqueGavetaClassEstoquePrateleira = "Erro ao carregar a coleção de EstoqueGavetaClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroEstoqueCorredorObrigatorio = "O campo EstoqueCorredor é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do EstoquePrateleiraClass.";
protected const string MensagemUtilizadoCollectionEstoqueGavetaClassEstoquePrateleira =  "A entidade EstoquePrateleiraClass está sendo utilizada nos seguintes EstoqueGavetaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EstoquePrateleiraClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.EstoqueCorredorClass _estoqueCorredorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstoqueCorredorClass _estoqueCorredorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstoqueCorredorClass _valueEstoqueCorredor;
        [Column("id_estoque_corredor", "estoque_corredor", "id_estoque_corredor")]
       public virtual BibliotecaEntidades.Entidades.EstoqueCorredorClass EstoqueCorredor
        { 
           get {                 return this._valueEstoqueCorredor; } 
           set 
           { 
                if (this._valueEstoqueCorredor == value)return;
                 this._valueEstoqueCorredor = value; 
           } 
       } 

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("esp_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("esp_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("esp_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       private List<long> _collectionEstoqueGavetaClassEstoquePrateleiraOriginal;
       private List<Entidades.EstoqueGavetaClass > _collectionEstoqueGavetaClassEstoquePrateleiraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaClassEstoquePrateleiraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaClassEstoquePrateleiraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueGavetaClass> _valueCollectionEstoqueGavetaClassEstoquePrateleira { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueGavetaClass> CollectionEstoqueGavetaClassEstoquePrateleira 
       { 
           get { if(!_valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueGavetaClassEstoquePrateleira();}
return this._valueCollectionEstoqueGavetaClassEstoquePrateleira; } 
           set 
           { 
               this._valueCollectionEstoqueGavetaClassEstoquePrateleira = value; 
               this._valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded = true; 
           } 
       } 

        public EstoquePrateleiraBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Ativo = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static EstoquePrateleiraClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EstoquePrateleiraClass) GetEntity(typeof(EstoquePrateleiraClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEstoqueGavetaClassEstoquePrateleiraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueGavetaClassEstoquePrateleiraChanged = true;
                  _valueCollectionEstoqueGavetaClassEstoquePrateleiraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueGavetaClassEstoquePrateleiraChanged = true; 
                  _valueCollectionEstoqueGavetaClassEstoquePrateleiraCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaClass item in e.OldItems) 
                 { 
                     _collectionEstoqueGavetaClassEstoquePrateleiraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueGavetaClassEstoquePrateleiraChanged = true; 
                  _valueCollectionEstoqueGavetaClassEstoquePrateleiraCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaClass item in _valueCollectionEstoqueGavetaClassEstoquePrateleira) 
                 { 
                     _collectionEstoqueGavetaClassEstoquePrateleiraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueGavetaClassEstoquePrateleira()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueGavetaClass> oc;
                _valueCollectionEstoqueGavetaClassEstoquePrateleiraChanged = false;
                 _valueCollectionEstoqueGavetaClassEstoquePrateleiraCommitedChanged = false;
                _collectionEstoqueGavetaClassEstoquePrateleiraRemovidos = new List<Entidades.EstoqueGavetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueGavetaClass>();
                }
                else{ 
                   Entidades.EstoqueGavetaClass search = new Entidades.EstoqueGavetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueGavetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstoquePrateleira", this)                    }                       ).Cast<Entidades.EstoqueGavetaClass>().ToList());
                 }
                 _valueCollectionEstoqueGavetaClassEstoquePrateleira = new BindingList<Entidades.EstoqueGavetaClass>(oc); 
                 _collectionEstoqueGavetaClassEstoquePrateleiraOriginal= (from a in _valueCollectionEstoqueGavetaClassEstoquePrateleira select a.ID).ToList();
                 _valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueGavetaClassEstoquePrateleiraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueGavetaClassEstoquePrateleira+"\r\n" + e.Message, e);
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
                if ( _valueEstoqueCorredor == null)
                {
                    throw new Exception(ErroEstoqueCorredorObrigatorio);
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
                    "  public.estoque_prateleira  " +
                    "WHERE " +
                    "  id_estoque_prateleira = :id";
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
                        "  public.estoque_prateleira   " +
                        "SET  " + 
                        "  id_estoque_corredor = :id_estoque_corredor, " + 
                        "  esp_identificacao = :esp_identificacao, " + 
                        "  esp_descricao = :esp_descricao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  esp_ativo = :esp_ativo "+
                        "WHERE  " +
                        "  id_estoque_prateleira = :id " +
                        "RETURNING id_estoque_prateleira;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.estoque_prateleira " +
                        "( " +
                        "  id_estoque_corredor , " + 
                        "  esp_identificacao , " + 
                        "  esp_descricao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  esp_ativo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_estoque_corredor , " + 
                        "  :esp_identificacao , " + 
                        "  :esp_descricao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :esp_ativo  "+
                        ")RETURNING id_estoque_prateleira;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_corredor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstoqueCorredor==null ? (object) DBNull.Value : this.EstoqueCorredor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esp_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esp_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esp_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;

 
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
 if (CollectionEstoqueGavetaClassEstoquePrateleira.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueGavetaClassEstoquePrateleira+"\r\n";
                foreach (Entidades.EstoqueGavetaClass tmp in CollectionEstoqueGavetaClassEstoquePrateleira)
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
        public static EstoquePrateleiraClass CopiarEntidade(EstoquePrateleiraClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EstoquePrateleiraClass toRet = new EstoquePrateleiraClass(usuario,conn);
 toRet.EstoqueCorredor= entidadeCopiar.EstoqueCorredor;
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Ativo= entidadeCopiar.Ativo;

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
       _estoqueCorredorOriginal = EstoqueCorredor;
       _estoqueCorredorOriginalCommited = _estoqueCorredorOriginal;
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;

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
       _estoqueCorredorOriginalCommited = EstoqueCorredor;
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
       _versionOriginalCommited = Version;
       _ativoOriginalCommited = Ativo;

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
               if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded) 
               {
                  if (_collectionEstoqueGavetaClassEstoquePrateleiraRemovidos != null) 
                  {
                     _collectionEstoqueGavetaClassEstoquePrateleiraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueGavetaClassEstoquePrateleiraRemovidos = new List<Entidades.EstoqueGavetaClass>();
                  }
                  _collectionEstoqueGavetaClassEstoquePrateleiraOriginal= (from a in _valueCollectionEstoqueGavetaClassEstoquePrateleira select a.ID).ToList();
                  _valueCollectionEstoqueGavetaClassEstoquePrateleiraChanged = false;
                  _valueCollectionEstoqueGavetaClassEstoquePrateleiraCommitedChanged = false;
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
               EstoqueCorredor=_estoqueCorredorOriginal;
               _estoqueCorredorOriginalCommited=_estoqueCorredorOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded) 
               {
                  CollectionEstoqueGavetaClassEstoquePrateleira.Clear();
                  foreach(int item in _collectionEstoqueGavetaClassEstoquePrateleiraOriginal)
                  {
                    CollectionEstoqueGavetaClassEstoquePrateleira.Add(Entidades.EstoqueGavetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueGavetaClassEstoquePrateleiraRemovidos.Clear();
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
               if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaClassEstoquePrateleira.Any(item => item.IsDirty());
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
       if (_estoqueCorredorOriginal!=null)
       {
          dirty = !_estoqueCorredorOriginal.Equals(EstoqueCorredor);
       }
       else
       {
            dirty = EstoqueCorredor != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;

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
               if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaClassEstoquePrateleira.Any(item => item.IsDirtyCommited());
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
       if (_estoqueCorredorOriginalCommited!=null)
       {
          dirty = !_estoqueCorredorOriginalCommited.Equals(EstoqueCorredor);
       }
       else
       {
            dirty = EstoqueCorredor != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;

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
               if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded) 
               {
                  foreach(EstoqueGavetaClass item in CollectionEstoqueGavetaClassEstoquePrateleira)
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
             case "EstoqueCorredor":
                return this.EstoqueCorredor;
             case "Identificacao":
                return this.Identificacao;
             case "Descricao":
                return this.Descricao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Ativo":
                return this.Ativo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (EstoqueCorredor!=null)
                EstoqueCorredor.ChangeSingleConnection(newConnection);
               if (_valueCollectionEstoqueGavetaClassEstoquePrateleiraLoaded) 
               {
                  foreach(EstoqueGavetaClass item in CollectionEstoqueGavetaClassEstoquePrateleira)
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
                  command.CommandText += " COUNT(estoque_prateleira.id_estoque_prateleira) " ;
               }
               else
               {
               command.CommandText += "estoque_prateleira.id_estoque_prateleira, " ;
               command.CommandText += "estoque_prateleira.id_estoque_corredor, " ;
               command.CommandText += "estoque_prateleira.esp_identificacao, " ;
               command.CommandText += "estoque_prateleira.esp_descricao, " ;
               command.CommandText += "estoque_prateleira.entity_uid, " ;
               command.CommandText += "estoque_prateleira.version, " ;
               command.CommandText += "estoque_prateleira.esp_ativo " ;
               }
               command.CommandText += " FROM  estoque_prateleira ";
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
                        orderByClause += " , esp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(esp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = estoque_prateleira.id_acs_usuario_ultima_revisao ";
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
                     case "id_estoque_prateleira":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque_prateleira.id_estoque_prateleira " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_prateleira.id_estoque_prateleira) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estoque_corredor":
                     case "EstoqueCorredor":
                     command.CommandText += " LEFT JOIN estoque_corredor as estoque_corredor_EstoqueCorredor ON estoque_corredor_EstoqueCorredor.id_estoque_corredor = estoque_prateleira.id_estoque_corredor ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_corredor_EstoqueCorredor.esc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_corredor_EstoqueCorredor.esc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "esp_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_prateleira.esp_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_prateleira.esp_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "esp_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_prateleira.esp_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_prateleira.esp_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_prateleira.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_prateleira.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , estoque_prateleira.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_prateleira.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "esp_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque_prateleira.esp_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_prateleira.esp_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("esp_identificacao")) 
                        {
                           whereClause += " OR UPPER(estoque_prateleira.esp_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_prateleira.esp_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("esp_descricao")) 
                        {
                           whereClause += " OR UPPER(estoque_prateleira.esp_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_prateleira.esp_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(estoque_prateleira.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_prateleira.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_estoque_prateleira")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_prateleira.id_estoque_prateleira IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.id_estoque_prateleira = :estoque_prateleira_ID_2616 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_ID_2616", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstoqueCorredor" || parametro.FieldName == "id_estoque_corredor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstoqueCorredorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstoqueCorredorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_prateleira.id_estoque_corredor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.id_estoque_corredor = :estoque_prateleira_EstoqueCorredor_479 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_EstoqueCorredor_479", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "esp_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_prateleira.esp_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.esp_identificacao LIKE :estoque_prateleira_Identificacao_7298 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_Identificacao_7298", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "esp_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_prateleira.esp_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.esp_descricao LIKE :estoque_prateleira_Descricao_2729 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_Descricao_2729", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  estoque_prateleira.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.entity_uid LIKE :estoque_prateleira_EntityUid_4725 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_EntityUid_4725", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  estoque_prateleira.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.version = :estoque_prateleira_Version_3118 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_Version_3118", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "esp_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_prateleira.esp_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.esp_ativo = :estoque_prateleira_Ativo_9374 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_Ativo_9374", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  estoque_prateleira.esp_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.esp_identificacao LIKE :estoque_prateleira_Identificacao_2328 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_Identificacao_2328", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estoque_prateleira.esp_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.esp_descricao LIKE :estoque_prateleira_Descricao_7110 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_Descricao_7110", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estoque_prateleira.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_prateleira.entity_uid LIKE :estoque_prateleira_EntityUid_3635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_prateleira_EntityUid_3635", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EstoquePrateleiraClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EstoquePrateleiraClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EstoquePrateleiraClass), Convert.ToInt32(read["id_estoque_prateleira"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EstoquePrateleiraClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_estoque_prateleira"]);
                     if (read["id_estoque_corredor"] != DBNull.Value)
                     {
                        entidade.EstoqueCorredor = (BibliotecaEntidades.Entidades.EstoqueCorredorClass)BibliotecaEntidades.Entidades.EstoqueCorredorClass.GetEntidade(Convert.ToInt32(read["id_estoque_corredor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstoqueCorredor = null ;
                     }
                     entidade.Identificacao = (read["esp_identificacao"] != DBNull.Value ? read["esp_identificacao"].ToString() : null);
                     entidade.Descricao = (read["esp_descricao"] != DBNull.Value ? read["esp_descricao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["esp_ativo"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EstoquePrateleiraClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
