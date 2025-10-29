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
     [Table("estoque_corredor","esc")]
     public class EstoqueCorredorBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EstoqueCorredorClass";
protected const string ErroDelete = "Erro ao excluir o EstoqueCorredorClass  ";
protected const string ErroSave = "Erro ao salvar o EstoqueCorredorClass.";
protected const string ErroCollectionEstoquePrateleiraClassEstoqueCorredor = "Erro ao carregar a coleção de EstoquePrateleiraClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroEstoqueObrigatorio = "O campo Estoque é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do EstoqueCorredorClass.";
protected const string MensagemUtilizadoCollectionEstoquePrateleiraClassEstoqueCorredor =  "A entidade EstoqueCorredorClass está sendo utilizada nos seguintes EstoquePrateleiraClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EstoqueCorredorClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.EstoqueClass _estoqueOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstoqueClass _estoqueOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstoqueClass _valueEstoque;
        [Column("id_estoque", "estoque", "id_estoque")]
       public virtual BibliotecaEntidades.Entidades.EstoqueClass Estoque
        { 
           get {                 return this._valueEstoque; } 
           set 
           { 
                if (this._valueEstoque == value)return;
                 this._valueEstoque = value; 
           } 
       } 

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("esc_identificacao")]
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
         [Column("esc_descricao")]
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
         [Column("esc_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       private List<long> _collectionEstoquePrateleiraClassEstoqueCorredorOriginal;
       private List<Entidades.EstoquePrateleiraClass > _collectionEstoquePrateleiraClassEstoqueCorredorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoquePrateleiraClassEstoqueCorredorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoquePrateleiraClassEstoqueCorredorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoquePrateleiraClass> _valueCollectionEstoquePrateleiraClassEstoqueCorredor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoquePrateleiraClass> CollectionEstoquePrateleiraClassEstoqueCorredor 
       { 
           get { if(!_valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoquePrateleiraClassEstoqueCorredor();}
return this._valueCollectionEstoquePrateleiraClassEstoqueCorredor; } 
           set 
           { 
               this._valueCollectionEstoquePrateleiraClassEstoqueCorredor = value; 
               this._valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded = true; 
           } 
       } 

        public EstoqueCorredorBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static EstoqueCorredorClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EstoqueCorredorClass) GetEntity(typeof(EstoqueCorredorClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEstoquePrateleiraClassEstoqueCorredorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoquePrateleiraClassEstoqueCorredorChanged = true;
                  _valueCollectionEstoquePrateleiraClassEstoqueCorredorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoquePrateleiraClassEstoqueCorredorChanged = true; 
                  _valueCollectionEstoquePrateleiraClassEstoqueCorredorCommitedChanged = true;
                 foreach (Entidades.EstoquePrateleiraClass item in e.OldItems) 
                 { 
                     _collectionEstoquePrateleiraClassEstoqueCorredorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoquePrateleiraClassEstoqueCorredorChanged = true; 
                  _valueCollectionEstoquePrateleiraClassEstoqueCorredorCommitedChanged = true;
                 foreach (Entidades.EstoquePrateleiraClass item in _valueCollectionEstoquePrateleiraClassEstoqueCorredor) 
                 { 
                     _collectionEstoquePrateleiraClassEstoqueCorredorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoquePrateleiraClassEstoqueCorredor()
         {
            try
            {
                 ObservableCollection<Entidades.EstoquePrateleiraClass> oc;
                _valueCollectionEstoquePrateleiraClassEstoqueCorredorChanged = false;
                 _valueCollectionEstoquePrateleiraClassEstoqueCorredorCommitedChanged = false;
                _collectionEstoquePrateleiraClassEstoqueCorredorRemovidos = new List<Entidades.EstoquePrateleiraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoquePrateleiraClass>();
                }
                else{ 
                   Entidades.EstoquePrateleiraClass search = new Entidades.EstoquePrateleiraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoquePrateleiraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstoqueCorredor", this)                    }                       ).Cast<Entidades.EstoquePrateleiraClass>().ToList());
                 }
                 _valueCollectionEstoquePrateleiraClassEstoqueCorredor = new BindingList<Entidades.EstoquePrateleiraClass>(oc); 
                 _collectionEstoquePrateleiraClassEstoqueCorredorOriginal= (from a in _valueCollectionEstoquePrateleiraClassEstoqueCorredor select a.ID).ToList();
                 _valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded = true;
                 oc.CollectionChanged += CollectionEstoquePrateleiraClassEstoqueCorredorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoquePrateleiraClassEstoqueCorredor+"\r\n" + e.Message, e);
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
                if ( _valueEstoque == null)
                {
                    throw new Exception(ErroEstoqueObrigatorio);
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
                    "  public.estoque_corredor  " +
                    "WHERE " +
                    "  id_estoque_corredor = :id";
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
                        "  public.estoque_corredor   " +
                        "SET  " + 
                        "  id_estoque = :id_estoque, " + 
                        "  esc_identificacao = :esc_identificacao, " + 
                        "  esc_descricao = :esc_descricao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  esc_ativo = :esc_ativo "+
                        "WHERE  " +
                        "  id_estoque_corredor = :id " +
                        "RETURNING id_estoque_corredor;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.estoque_corredor " +
                        "( " +
                        "  id_estoque , " + 
                        "  esc_identificacao , " + 
                        "  esc_descricao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  esc_ativo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_estoque , " + 
                        "  :esc_identificacao , " + 
                        "  :esc_descricao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :esc_ativo  "+
                        ")RETURNING id_estoque_corredor;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Estoque==null ? (object) DBNull.Value : this.Estoque.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esc_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esc_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esc_ativo", NpgsqlDbType.Smallint));
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
 if (CollectionEstoquePrateleiraClassEstoqueCorredor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoquePrateleiraClassEstoqueCorredor+"\r\n";
                foreach (Entidades.EstoquePrateleiraClass tmp in CollectionEstoquePrateleiraClassEstoqueCorredor)
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
        public static EstoqueCorredorClass CopiarEntidade(EstoqueCorredorClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EstoqueCorredorClass toRet = new EstoqueCorredorClass(usuario,conn);
 toRet.Estoque= entidadeCopiar.Estoque;
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
       _estoqueOriginal = Estoque;
       _estoqueOriginalCommited = _estoqueOriginal;
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
       _estoqueOriginalCommited = Estoque;
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
               if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded) 
               {
                  if (_collectionEstoquePrateleiraClassEstoqueCorredorRemovidos != null) 
                  {
                     _collectionEstoquePrateleiraClassEstoqueCorredorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoquePrateleiraClassEstoqueCorredorRemovidos = new List<Entidades.EstoquePrateleiraClass>();
                  }
                  _collectionEstoquePrateleiraClassEstoqueCorredorOriginal= (from a in _valueCollectionEstoquePrateleiraClassEstoqueCorredor select a.ID).ToList();
                  _valueCollectionEstoquePrateleiraClassEstoqueCorredorChanged = false;
                  _valueCollectionEstoquePrateleiraClassEstoqueCorredorCommitedChanged = false;
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
               Estoque=_estoqueOriginal;
               _estoqueOriginalCommited=_estoqueOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded) 
               {
                  CollectionEstoquePrateleiraClassEstoqueCorredor.Clear();
                  foreach(int item in _collectionEstoquePrateleiraClassEstoqueCorredorOriginal)
                  {
                    CollectionEstoquePrateleiraClassEstoqueCorredor.Add(Entidades.EstoquePrateleiraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoquePrateleiraClassEstoqueCorredorRemovidos.Clear();
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
               if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded) 
               {
                  if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded) 
               {
                   tempRet = CollectionEstoquePrateleiraClassEstoqueCorredor.Any(item => item.IsDirty());
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
       if (_estoqueOriginal!=null)
       {
          dirty = !_estoqueOriginal.Equals(Estoque);
       }
       else
       {
            dirty = Estoque != null;
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
               if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded) 
               {
                  if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded) 
               {
                   tempRet = CollectionEstoquePrateleiraClassEstoqueCorredor.Any(item => item.IsDirtyCommited());
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
       if (_estoqueOriginalCommited!=null)
       {
          dirty = !_estoqueOriginalCommited.Equals(Estoque);
       }
       else
       {
            dirty = Estoque != null;
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
               if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded) 
               {
                  foreach(EstoquePrateleiraClass item in CollectionEstoquePrateleiraClassEstoqueCorredor)
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
             case "Estoque":
                return this.Estoque;
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
             if (Estoque!=null)
                Estoque.ChangeSingleConnection(newConnection);
               if (_valueCollectionEstoquePrateleiraClassEstoqueCorredorLoaded) 
               {
                  foreach(EstoquePrateleiraClass item in CollectionEstoquePrateleiraClassEstoqueCorredor)
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
                  command.CommandText += " COUNT(estoque_corredor.id_estoque_corredor) " ;
               }
               else
               {
               command.CommandText += "estoque_corredor.id_estoque_corredor, " ;
               command.CommandText += "estoque_corredor.id_estoque, " ;
               command.CommandText += "estoque_corredor.esc_identificacao, " ;
               command.CommandText += "estoque_corredor.esc_descricao, " ;
               command.CommandText += "estoque_corredor.entity_uid, " ;
               command.CommandText += "estoque_corredor.version, " ;
               command.CommandText += "estoque_corredor.esc_ativo " ;
               }
               command.CommandText += " FROM  estoque_corredor ";
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
                        orderByClause += " , esc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(esc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = estoque_corredor.id_acs_usuario_ultima_revisao ";
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
                     case "id_estoque_corredor":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque_corredor.id_estoque_corredor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_corredor.id_estoque_corredor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estoque":
                     case "Estoque":
                     command.CommandText += " LEFT JOIN estoque as estoque_Estoque ON estoque_Estoque.id_estoque = estoque_corredor.id_estoque ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_Estoque.est_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_Estoque.est_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "esc_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_corredor.esc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_corredor.esc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "esc_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_corredor.esc_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_corredor.esc_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_corredor.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_corredor.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , estoque_corredor.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_corredor.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "esc_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque_corredor.esc_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_corredor.esc_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("esc_identificacao")) 
                        {
                           whereClause += " OR UPPER(estoque_corredor.esc_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_corredor.esc_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("esc_descricao")) 
                        {
                           whereClause += " OR UPPER(estoque_corredor.esc_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_corredor.esc_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(estoque_corredor.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_corredor.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_estoque_corredor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_corredor.id_estoque_corredor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.id_estoque_corredor = :estoque_corredor_ID_5124 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_ID_5124", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Estoque" || parametro.FieldName == "id_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstoqueClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstoqueClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_corredor.id_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.id_estoque = :estoque_corredor_Estoque_1613 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_Estoque_1613", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "esc_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_corredor.esc_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.esc_identificacao LIKE :estoque_corredor_Identificacao_2089 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_Identificacao_2089", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "esc_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_corredor.esc_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.esc_descricao LIKE :estoque_corredor_Descricao_6243 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_Descricao_6243", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  estoque_corredor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.entity_uid LIKE :estoque_corredor_EntityUid_2566 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_EntityUid_2566", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  estoque_corredor.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.version = :estoque_corredor_Version_1478 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_Version_1478", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "esc_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_corredor.esc_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.esc_ativo = :estoque_corredor_Ativo_9890 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_Ativo_9890", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  estoque_corredor.esc_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.esc_identificacao LIKE :estoque_corredor_Identificacao_1015 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_Identificacao_1015", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estoque_corredor.esc_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.esc_descricao LIKE :estoque_corredor_Descricao_612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_Descricao_612", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estoque_corredor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_corredor.entity_uid LIKE :estoque_corredor_EntityUid_6009 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_corredor_EntityUid_6009", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EstoqueCorredorClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EstoqueCorredorClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EstoqueCorredorClass), Convert.ToInt32(read["id_estoque_corredor"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EstoqueCorredorClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_estoque_corredor"]);
                     if (read["id_estoque"] != DBNull.Value)
                     {
                        entidade.Estoque = (BibliotecaEntidades.Entidades.EstoqueClass)BibliotecaEntidades.Entidades.EstoqueClass.GetEntidade(Convert.ToInt32(read["id_estoque"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Estoque = null ;
                     }
                     entidade.Identificacao = (read["esc_identificacao"] != DBNull.Value ? read["esc_identificacao"].ToString() : null);
                     entidade.Descricao = (read["esc_descricao"] != DBNull.Value ? read["esc_descricao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["esc_ativo"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EstoqueCorredorClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
