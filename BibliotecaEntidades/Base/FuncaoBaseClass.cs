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
     [Table("funcao","fun")]
     public class FuncaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do FuncaoClass";
protected const string ErroDelete = "Erro ao excluir o FuncaoClass  ";
protected const string ErroSave = "Erro ao salvar o FuncaoClass.";
protected const string ErroCollectionFuncaoEpiClassFuncao = "Erro ao carregar a coleção de FuncaoEpiClass.";
protected const string ErroCollectionFuncionarioFuncaoClassFuncao = "Erro ao carregar a coleção de FuncionarioFuncaoClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 50 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroUltimaRevisaoObrigatorio = "O campo UltimaRevisao é obrigatório";
protected const string ErroUltimaRevisaoComprimento = "O campo UltimaRevisao deve ter no máximo 255 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do FuncaoClass.";
protected const string MensagemUtilizadoCollectionFuncaoEpiClassFuncao =  "A entidade FuncaoClass está sendo utilizada nos seguintes FuncaoEpiClass:";
protected const string MensagemUtilizadoCollectionFuncionarioFuncaoClassFuncao =  "A entidade FuncaoClass está sendo utilizada nos seguintes FuncionarioFuncaoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade FuncaoClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("fun_identificacao")]
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
         [Column("fun_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected string _descricaoCompletaOriginal{get;private set;}
       private string _descricaoCompletaOriginalCommited{get; set;}
        private string _valueDescricaoCompleta;
         [Column("fun_descricao_completa")]
        public virtual string DescricaoCompleta
         { 
            get { return this._valueDescricaoCompleta; } 
            set 
            { 
                if (this._valueDescricaoCompleta == value)return;
                 this._valueDescricaoCompleta = value; 
            } 
        } 

       private List<long> _collectionFuncaoEpiClassFuncaoOriginal;
       private List<Entidades.FuncaoEpiClass > _collectionFuncaoEpiClassFuncaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncaoEpiClassFuncaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncaoEpiClassFuncaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncaoEpiClassFuncaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FuncaoEpiClass> _valueCollectionFuncaoEpiClassFuncao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FuncaoEpiClass> CollectionFuncaoEpiClassFuncao 
       { 
           get { if(!_valueCollectionFuncaoEpiClassFuncaoLoaded && !this.DisableLoadCollection){this.LoadCollectionFuncaoEpiClassFuncao();}
return this._valueCollectionFuncaoEpiClassFuncao; } 
           set 
           { 
               this._valueCollectionFuncaoEpiClassFuncao = value; 
               this._valueCollectionFuncaoEpiClassFuncaoLoaded = true; 
           } 
       } 

       private List<long> _collectionFuncionarioFuncaoClassFuncaoOriginal;
       private List<Entidades.FuncionarioFuncaoClass > _collectionFuncionarioFuncaoClassFuncaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioFuncaoClassFuncaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioFuncaoClassFuncaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioFuncaoClassFuncaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FuncionarioFuncaoClass> _valueCollectionFuncionarioFuncaoClassFuncao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FuncionarioFuncaoClass> CollectionFuncionarioFuncaoClassFuncao 
       { 
           get { if(!_valueCollectionFuncionarioFuncaoClassFuncaoLoaded && !this.DisableLoadCollection){this.LoadCollectionFuncionarioFuncaoClassFuncao();}
return this._valueCollectionFuncionarioFuncaoClassFuncao; } 
           set 
           { 
               this._valueCollectionFuncionarioFuncaoClassFuncao = value; 
               this._valueCollectionFuncionarioFuncaoClassFuncaoLoaded = true; 
           } 
       } 

        public FuncaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static FuncaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (FuncaoClass) GetEntity(typeof(FuncaoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionFuncaoEpiClassFuncaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFuncaoEpiClassFuncaoChanged = true;
                  _valueCollectionFuncaoEpiClassFuncaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFuncaoEpiClassFuncaoChanged = true; 
                  _valueCollectionFuncaoEpiClassFuncaoCommitedChanged = true;
                 foreach (Entidades.FuncaoEpiClass item in e.OldItems) 
                 { 
                     _collectionFuncaoEpiClassFuncaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFuncaoEpiClassFuncaoChanged = true; 
                  _valueCollectionFuncaoEpiClassFuncaoCommitedChanged = true;
                 foreach (Entidades.FuncaoEpiClass item in _valueCollectionFuncaoEpiClassFuncao) 
                 { 
                     _collectionFuncaoEpiClassFuncaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFuncaoEpiClassFuncao()
         {
            try
            {
                 ObservableCollection<Entidades.FuncaoEpiClass> oc;
                _valueCollectionFuncaoEpiClassFuncaoChanged = false;
                 _valueCollectionFuncaoEpiClassFuncaoCommitedChanged = false;
                _collectionFuncaoEpiClassFuncaoRemovidos = new List<Entidades.FuncaoEpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FuncaoEpiClass>();
                }
                else{ 
                   Entidades.FuncaoEpiClass search = new Entidades.FuncaoEpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FuncaoEpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Funcao", this),                     }                       ).Cast<Entidades.FuncaoEpiClass>().ToList());
                 }
                 _valueCollectionFuncaoEpiClassFuncao = new BindingList<Entidades.FuncaoEpiClass>(oc); 
                 _collectionFuncaoEpiClassFuncaoOriginal= (from a in _valueCollectionFuncaoEpiClassFuncao select a.ID).ToList();
                 _valueCollectionFuncaoEpiClassFuncaoLoaded = true;
                 oc.CollectionChanged += CollectionFuncaoEpiClassFuncaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFuncaoEpiClassFuncao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFuncionarioFuncaoClassFuncaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFuncionarioFuncaoClassFuncaoChanged = true;
                  _valueCollectionFuncionarioFuncaoClassFuncaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFuncionarioFuncaoClassFuncaoChanged = true; 
                  _valueCollectionFuncionarioFuncaoClassFuncaoCommitedChanged = true;
                 foreach (Entidades.FuncionarioFuncaoClass item in e.OldItems) 
                 { 
                     _collectionFuncionarioFuncaoClassFuncaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFuncionarioFuncaoClassFuncaoChanged = true; 
                  _valueCollectionFuncionarioFuncaoClassFuncaoCommitedChanged = true;
                 foreach (Entidades.FuncionarioFuncaoClass item in _valueCollectionFuncionarioFuncaoClassFuncao) 
                 { 
                     _collectionFuncionarioFuncaoClassFuncaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFuncionarioFuncaoClassFuncao()
         {
            try
            {
                 ObservableCollection<Entidades.FuncionarioFuncaoClass> oc;
                _valueCollectionFuncionarioFuncaoClassFuncaoChanged = false;
                 _valueCollectionFuncionarioFuncaoClassFuncaoCommitedChanged = false;
                _collectionFuncionarioFuncaoClassFuncaoRemovidos = new List<Entidades.FuncionarioFuncaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FuncionarioFuncaoClass>();
                }
                else{ 
                   Entidades.FuncionarioFuncaoClass search = new Entidades.FuncionarioFuncaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FuncionarioFuncaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Funcao", this),                     }                       ).Cast<Entidades.FuncionarioFuncaoClass>().ToList());
                 }
                 _valueCollectionFuncionarioFuncaoClassFuncao = new BindingList<Entidades.FuncionarioFuncaoClass>(oc); 
                 _collectionFuncionarioFuncaoClassFuncaoOriginal= (from a in _valueCollectionFuncionarioFuncaoClassFuncao select a.ID).ToList();
                 _valueCollectionFuncionarioFuncaoClassFuncaoLoaded = true;
                 oc.CollectionChanged += CollectionFuncionarioFuncaoClassFuncaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFuncionarioFuncaoClassFuncao+"\r\n" + e.Message, e);
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
                if (Identificacao.Length >50)
                {
                    throw new Exception( ErroIdentificacaoComprimento);
                }
                if (string.IsNullOrEmpty(Descricao))
                {
                    throw new Exception(ErroDescricaoObrigatorio);
                }
                if (Descricao.Length >255)
                {
                    throw new Exception( ErroDescricaoComprimento);
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
                    "  public.funcao  " +
                    "WHERE " +
                    "  id_funcao = :id";
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
                        "  public.funcao   " +
                        "SET  " + 
                        "  fun_identificacao = :fun_identificacao, " + 
                        "  fun_descricao = :fun_descricao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  fun_ultima_revisao = :fun_ultima_revisao, " + 
                        "  fun_ultima_revisao_data = :fun_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  fun_descricao_completa = :fun_descricao_completa "+
                        "WHERE  " +
                        "  id_funcao = :id " +
                        "RETURNING id_funcao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.funcao " +
                        "( " +
                        "  fun_identificacao , " + 
                        "  fun_descricao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  fun_ultima_revisao , " + 
                        "  fun_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  fun_descricao_completa  "+
                        ")  " +
                        "VALUES ( " +
                        "  :fun_identificacao , " + 
                        "  :fun_descricao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :fun_ultima_revisao , " + 
                        "  :fun_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :fun_descricao_completa  "+
                        ")RETURNING id_funcao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fun_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fun_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fun_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fun_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fun_descricao_completa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoCompleta ?? DBNull.Value;

 
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
 if (CollectionFuncaoEpiClassFuncao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFuncaoEpiClassFuncao+"\r\n";
                foreach (Entidades.FuncaoEpiClass tmp in CollectionFuncaoEpiClassFuncao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFuncionarioFuncaoClassFuncao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFuncionarioFuncaoClassFuncao+"\r\n";
                foreach (Entidades.FuncionarioFuncaoClass tmp in CollectionFuncionarioFuncaoClassFuncao)
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
        public static FuncaoClass CopiarEntidade(FuncaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               FuncaoClass toRet = new FuncaoClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.DescricaoCompleta= entidadeCopiar.DescricaoCompleta;

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
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _descricaoCompletaOriginal = DescricaoCompleta;
       _descricaoCompletaOriginalCommited = _descricaoCompletaOriginal;

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
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
       _versionOriginalCommited = Version;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _descricaoCompletaOriginalCommited = DescricaoCompleta;

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
               if (_valueCollectionFuncaoEpiClassFuncaoLoaded) 
               {
                  if (_collectionFuncaoEpiClassFuncaoRemovidos != null) 
                  {
                     _collectionFuncaoEpiClassFuncaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFuncaoEpiClassFuncaoRemovidos = new List<Entidades.FuncaoEpiClass>();
                  }
                  _collectionFuncaoEpiClassFuncaoOriginal= (from a in _valueCollectionFuncaoEpiClassFuncao select a.ID).ToList();
                  _valueCollectionFuncaoEpiClassFuncaoChanged = false;
                  _valueCollectionFuncaoEpiClassFuncaoCommitedChanged = false;
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncaoLoaded) 
               {
                  if (_collectionFuncionarioFuncaoClassFuncaoRemovidos != null) 
                  {
                     _collectionFuncionarioFuncaoClassFuncaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFuncionarioFuncaoClassFuncaoRemovidos = new List<Entidades.FuncionarioFuncaoClass>();
                  }
                  _collectionFuncionarioFuncaoClassFuncaoOriginal= (from a in _valueCollectionFuncionarioFuncaoClassFuncao select a.ID).ToList();
                  _valueCollectionFuncionarioFuncaoClassFuncaoChanged = false;
                  _valueCollectionFuncionarioFuncaoClassFuncaoCommitedChanged = false;
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
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               DescricaoCompleta=_descricaoCompletaOriginal;
               _descricaoCompletaOriginalCommited=_descricaoCompletaOriginal;
               if (_valueCollectionFuncaoEpiClassFuncaoLoaded) 
               {
                  CollectionFuncaoEpiClassFuncao.Clear();
                  foreach(int item in _collectionFuncaoEpiClassFuncaoOriginal)
                  {
                    CollectionFuncaoEpiClassFuncao.Add(Entidades.FuncaoEpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFuncaoEpiClassFuncaoRemovidos.Clear();
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncaoLoaded) 
               {
                  CollectionFuncionarioFuncaoClassFuncao.Clear();
                  foreach(int item in _collectionFuncionarioFuncaoClassFuncaoOriginal)
                  {
                    CollectionFuncionarioFuncaoClassFuncao.Add(Entidades.FuncionarioFuncaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFuncionarioFuncaoClassFuncaoRemovidos.Clear();
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
               if (_valueCollectionFuncaoEpiClassFuncaoLoaded) 
               {
                  if (_valueCollectionFuncaoEpiClassFuncaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncaoLoaded) 
               {
                  if (_valueCollectionFuncionarioFuncaoClassFuncaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncaoEpiClassFuncaoLoaded) 
               {
                   tempRet = CollectionFuncaoEpiClassFuncao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncaoLoaded) 
               {
                   tempRet = CollectionFuncionarioFuncaoClassFuncao.Any(item => item.IsDirty());
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
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
       dirty = _descricaoCompletaOriginal != DescricaoCompleta;

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
               if (_valueCollectionFuncaoEpiClassFuncaoLoaded) 
               {
                  if (_valueCollectionFuncaoEpiClassFuncaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncaoLoaded) 
               {
                  if (_valueCollectionFuncionarioFuncaoClassFuncaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncaoEpiClassFuncaoLoaded) 
               {
                   tempRet = CollectionFuncaoEpiClassFuncao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncaoLoaded) 
               {
                   tempRet = CollectionFuncionarioFuncaoClassFuncao.Any(item => item.IsDirtyCommited());
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
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
       dirty = _descricaoCompletaOriginalCommited != DescricaoCompleta;

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
               if (_valueCollectionFuncaoEpiClassFuncaoLoaded) 
               {
                  foreach(FuncaoEpiClass item in CollectionFuncaoEpiClassFuncao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncaoLoaded) 
               {
                  foreach(FuncionarioFuncaoClass item in CollectionFuncionarioFuncaoClassFuncao)
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
             case "Identificacao":
                return this.Identificacao;
             case "Descricao":
                return this.Descricao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "DescricaoCompleta":
                return this.DescricaoCompleta;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionFuncaoEpiClassFuncaoLoaded) 
               {
                  foreach(FuncaoEpiClass item in CollectionFuncaoEpiClassFuncao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncaoLoaded) 
               {
                  foreach(FuncionarioFuncaoClass item in CollectionFuncionarioFuncaoClassFuncao)
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
                  command.CommandText += " COUNT(funcao.id_funcao) " ;
               }
               else
               {
               command.CommandText += "funcao.id_funcao, " ;
               command.CommandText += "funcao.fun_identificacao, " ;
               command.CommandText += "funcao.fun_descricao, " ;
               command.CommandText += "funcao.entity_uid, " ;
               command.CommandText += "funcao.version, " ;
               command.CommandText += "funcao.fun_ultima_revisao, " ;
               command.CommandText += "funcao.fun_ultima_revisao_data, " ;
               command.CommandText += "funcao.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "funcao.fun_descricao_completa " ;
               }
               command.CommandText += " FROM  funcao ";
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
                        orderByClause += " , fun_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(fun_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = funcao.id_acs_usuario_ultima_revisao ";
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
                     case "id_funcao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcao.id_funcao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcao.id_funcao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fun_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcao.fun_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcao.fun_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fun_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcao.fun_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcao.fun_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , funcao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fun_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcao.fun_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcao.fun_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fun_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcao.fun_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcao.fun_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , funcao.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "fun_descricao_completa":
                     case "DescricaoCompleta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcao.fun_descricao_completa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcao.fun_descricao_completa) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fun_identificacao")) 
                        {
                           whereClause += " OR UPPER(funcao.fun_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcao.fun_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fun_descricao")) 
                        {
                           whereClause += " OR UPPER(funcao.fun_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcao.fun_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(funcao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fun_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(funcao.fun_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcao.fun_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fun_descricao_completa")) 
                        {
                           whereClause += " OR UPPER(funcao.fun_descricao_completa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcao.fun_descricao_completa) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_funcao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcao.id_funcao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.id_funcao = :funcao_ID_9409 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_ID_9409", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "fun_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcao.fun_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.fun_identificacao LIKE :funcao_Identificacao_333 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_Identificacao_333", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "fun_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcao.fun_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.fun_descricao LIKE :funcao_Descricao_1126 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_Descricao_1126", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  funcao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.entity_uid LIKE :funcao_EntityUid_4730 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_EntityUid_4730", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  funcao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.version = :funcao_Version_8787 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_Version_8787", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "fun_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcao.fun_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.fun_ultima_revisao LIKE :funcao_UltimaRevisao_3895 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_UltimaRevisao_3895", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "fun_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcao.fun_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.fun_ultima_revisao_data = :funcao_UltimaRevisaoData_2522 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_UltimaRevisaoData_2522", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  funcao.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.id_acs_usuario_ultima_revisao = :funcao_UltimaRevisaoUsuario_2603 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_UltimaRevisaoUsuario_2603", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoCompleta" || parametro.FieldName == "fun_descricao_completa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcao.fun_descricao_completa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.fun_descricao_completa LIKE :funcao_DescricaoCompleta_1783 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_DescricaoCompleta_1783", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  funcao.fun_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.fun_identificacao LIKE :funcao_Identificacao_3017 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_Identificacao_3017", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcao.fun_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.fun_descricao LIKE :funcao_Descricao_2976 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_Descricao_2976", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.entity_uid LIKE :funcao_EntityUid_3132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_EntityUid_3132", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcao.fun_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.fun_ultima_revisao LIKE :funcao_UltimaRevisao_9093 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_UltimaRevisao_9093", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoCompletaExato" || parametro.FieldName == "DescricaoCompletaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcao.fun_descricao_completa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcao.fun_descricao_completa LIKE :funcao_DescricaoCompleta_9746 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcao_DescricaoCompleta_9746", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  FuncaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (FuncaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(FuncaoClass), Convert.ToInt32(read["id_funcao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new FuncaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_funcao"]);
                     entidade.Identificacao = (read["fun_identificacao"] != DBNull.Value ? read["fun_identificacao"].ToString() : null);
                     entidade.Descricao = (read["fun_descricao"] != DBNull.Value ? read["fun_descricao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.UltimaRevisao = (read["fun_ultima_revisao"] != DBNull.Value ? read["fun_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["fun_ultima_revisao_data"] as DateTime?;
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.DescricaoCompleta = (read["fun_descricao_completa"] != DBNull.Value ? read["fun_descricao_completa"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (FuncaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
