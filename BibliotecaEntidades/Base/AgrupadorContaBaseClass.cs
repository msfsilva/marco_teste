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
     [Table("agrupador_conta","agc")]
     public class AgrupadorContaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do AgrupadorContaClass";
protected const string ErroDelete = "Erro ao excluir o AgrupadorContaClass  ";
protected const string ErroSave = "Erro ao salvar o AgrupadorContaClass.";
protected const string ErroCollectionContaPagarClassAgrupadorConta = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionContaReceberClassAgrupadorConta = "Erro ao carregar a coleção de ContaReceberClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do AgrupadorContaClass.";
protected const string MensagemUtilizadoCollectionContaPagarClassAgrupadorConta =  "A entidade AgrupadorContaClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionContaReceberClassAgrupadorConta =  "A entidade AgrupadorContaClass está sendo utilizada nos seguintes ContaReceberClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade AgrupadorContaClass está sendo utilizada.";
#endregion
       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("agc_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected string _observacaoOriginal{get;private set;}
       private string _observacaoOriginalCommited{get; set;}
        private string _valueObservacao;
         [Column("agc_observacao")]
        public virtual string Observacao
         { 
            get { return this._valueObservacao; } 
            set 
            { 
                if (this._valueObservacao == value)return;
                 this._valueObservacao = value; 
            } 
        } 

       private List<long> _collectionContaPagarClassAgrupadorContaOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassAgrupadorContaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassAgrupadorContaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassAgrupadorContaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassAgrupadorContaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassAgrupadorConta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassAgrupadorConta 
       { 
           get { if(!_valueCollectionContaPagarClassAgrupadorContaLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassAgrupadorConta();}
return this._valueCollectionContaPagarClassAgrupadorConta; } 
           set 
           { 
               this._valueCollectionContaPagarClassAgrupadorConta = value; 
               this._valueCollectionContaPagarClassAgrupadorContaLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberClassAgrupadorContaOriginal;
       private List<Entidades.ContaReceberClass > _collectionContaReceberClassAgrupadorContaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassAgrupadorContaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassAgrupadorContaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassAgrupadorContaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberClass> _valueCollectionContaReceberClassAgrupadorConta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberClass> CollectionContaReceberClassAgrupadorConta 
       { 
           get { if(!_valueCollectionContaReceberClassAgrupadorContaLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberClassAgrupadorConta();}
return this._valueCollectionContaReceberClassAgrupadorConta; } 
           set 
           { 
               this._valueCollectionContaReceberClassAgrupadorConta = value; 
               this._valueCollectionContaReceberClassAgrupadorContaLoaded = true; 
           } 
       } 

        public AgrupadorContaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Data = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static AgrupadorContaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (AgrupadorContaClass) GetEntity(typeof(AgrupadorContaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionContaPagarClassAgrupadorContaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassAgrupadorContaChanged = true;
                  _valueCollectionContaPagarClassAgrupadorContaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassAgrupadorContaChanged = true; 
                  _valueCollectionContaPagarClassAgrupadorContaCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassAgrupadorContaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassAgrupadorContaChanged = true; 
                  _valueCollectionContaPagarClassAgrupadorContaCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassAgrupadorConta) 
                 { 
                     _collectionContaPagarClassAgrupadorContaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassAgrupadorConta()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassAgrupadorContaChanged = false;
                 _valueCollectionContaPagarClassAgrupadorContaCommitedChanged = false;
                _collectionContaPagarClassAgrupadorContaRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("AgrupadorConta", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassAgrupadorConta = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassAgrupadorContaOriginal= (from a in _valueCollectionContaPagarClassAgrupadorConta select a.ID).ToList();
                 _valueCollectionContaPagarClassAgrupadorContaLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassAgrupadorContaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassAgrupadorConta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberClassAgrupadorContaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberClassAgrupadorContaChanged = true;
                  _valueCollectionContaReceberClassAgrupadorContaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberClassAgrupadorContaChanged = true; 
                  _valueCollectionContaReceberClassAgrupadorContaCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in e.OldItems) 
                 { 
                     _collectionContaReceberClassAgrupadorContaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberClassAgrupadorContaChanged = true; 
                  _valueCollectionContaReceberClassAgrupadorContaCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in _valueCollectionContaReceberClassAgrupadorConta) 
                 { 
                     _collectionContaReceberClassAgrupadorContaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberClassAgrupadorConta()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberClass> oc;
                _valueCollectionContaReceberClassAgrupadorContaChanged = false;
                 _valueCollectionContaReceberClassAgrupadorContaCommitedChanged = false;
                _collectionContaReceberClassAgrupadorContaRemovidos = new List<Entidades.ContaReceberClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberClass>();
                }
                else{ 
                   Entidades.ContaReceberClass search = new Entidades.ContaReceberClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("AgrupadorConta", this),                     }                       ).Cast<Entidades.ContaReceberClass>().ToList());
                 }
                 _valueCollectionContaReceberClassAgrupadorConta = new BindingList<Entidades.ContaReceberClass>(oc); 
                 _collectionContaReceberClassAgrupadorContaOriginal= (from a in _valueCollectionContaReceberClassAgrupadorConta select a.ID).ToList();
                 _valueCollectionContaReceberClassAgrupadorContaLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberClassAgrupadorContaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberClassAgrupadorConta+"\r\n" + e.Message, e);
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
                    "  public.agrupador_conta  " +
                    "WHERE " +
                    "  id_agrupador_conta = :id";
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
                        "  public.agrupador_conta   " +
                        "SET  " + 
                        "  agc_data = :agc_data, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  agc_observacao = :agc_observacao "+
                        "WHERE  " +
                        "  id_agrupador_conta = :id " +
                        "RETURNING id_agrupador_conta;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.agrupador_conta " +
                        "( " +
                        "  agc_data , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  agc_observacao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :agc_data , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :agc_observacao  "+
                        ")RETURNING id_agrupador_conta;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agc_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agc_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacao ?? DBNull.Value;

 
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
 if (CollectionContaPagarClassAgrupadorConta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassAgrupadorConta+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassAgrupadorConta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberClassAgrupadorConta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberClassAgrupadorConta+"\r\n";
                foreach (Entidades.ContaReceberClass tmp in CollectionContaReceberClassAgrupadorConta)
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
        public static AgrupadorContaClass CopiarEntidade(AgrupadorContaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               AgrupadorContaClass toRet = new AgrupadorContaClass(usuario,conn);
 toRet.Data= entidadeCopiar.Data;
 toRet.Observacao= entidadeCopiar.Observacao;

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
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _observacaoOriginal = Observacao;
       _observacaoOriginalCommited = _observacaoOriginal;

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
       _dataOriginalCommited = Data;
       _versionOriginalCommited = Version;
       _observacaoOriginalCommited = Observacao;

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
               if (_valueCollectionContaPagarClassAgrupadorContaLoaded) 
               {
                  if (_collectionContaPagarClassAgrupadorContaRemovidos != null) 
                  {
                     _collectionContaPagarClassAgrupadorContaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassAgrupadorContaRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassAgrupadorContaOriginal= (from a in _valueCollectionContaPagarClassAgrupadorConta select a.ID).ToList();
                  _valueCollectionContaPagarClassAgrupadorContaChanged = false;
                  _valueCollectionContaPagarClassAgrupadorContaCommitedChanged = false;
               }
               if (_valueCollectionContaReceberClassAgrupadorContaLoaded) 
               {
                  if (_collectionContaReceberClassAgrupadorContaRemovidos != null) 
                  {
                     _collectionContaReceberClassAgrupadorContaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberClassAgrupadorContaRemovidos = new List<Entidades.ContaReceberClass>();
                  }
                  _collectionContaReceberClassAgrupadorContaOriginal= (from a in _valueCollectionContaReceberClassAgrupadorConta select a.ID).ToList();
                  _valueCollectionContaReceberClassAgrupadorContaChanged = false;
                  _valueCollectionContaReceberClassAgrupadorContaCommitedChanged = false;
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
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Observacao=_observacaoOriginal;
               _observacaoOriginalCommited=_observacaoOriginal;
               if (_valueCollectionContaPagarClassAgrupadorContaLoaded) 
               {
                  CollectionContaPagarClassAgrupadorConta.Clear();
                  foreach(int item in _collectionContaPagarClassAgrupadorContaOriginal)
                  {
                    CollectionContaPagarClassAgrupadorConta.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassAgrupadorContaRemovidos.Clear();
               }
               if (_valueCollectionContaReceberClassAgrupadorContaLoaded) 
               {
                  CollectionContaReceberClassAgrupadorConta.Clear();
                  foreach(int item in _collectionContaReceberClassAgrupadorContaOriginal)
                  {
                    CollectionContaReceberClassAgrupadorConta.Add(Entidades.ContaReceberClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberClassAgrupadorContaRemovidos.Clear();
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
               if (_valueCollectionContaPagarClassAgrupadorContaLoaded) 
               {
                  if (_valueCollectionContaPagarClassAgrupadorContaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassAgrupadorContaLoaded) 
               {
                  if (_valueCollectionContaReceberClassAgrupadorContaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassAgrupadorContaLoaded) 
               {
                   tempRet = CollectionContaPagarClassAgrupadorConta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassAgrupadorContaLoaded) 
               {
                   tempRet = CollectionContaReceberClassAgrupadorConta.Any(item => item.IsDirty());
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
       dirty = _dataOriginal != Data;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _observacaoOriginal != Observacao;

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
               if (_valueCollectionContaPagarClassAgrupadorContaLoaded) 
               {
                  if (_valueCollectionContaPagarClassAgrupadorContaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassAgrupadorContaLoaded) 
               {
                  if (_valueCollectionContaReceberClassAgrupadorContaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassAgrupadorContaLoaded) 
               {
                   tempRet = CollectionContaPagarClassAgrupadorConta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassAgrupadorContaLoaded) 
               {
                   tempRet = CollectionContaReceberClassAgrupadorConta.Any(item => item.IsDirtyCommited());
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
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _observacaoOriginalCommited != Observacao;

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
               if (_valueCollectionContaPagarClassAgrupadorContaLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassAgrupadorConta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberClassAgrupadorContaLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassAgrupadorConta)
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
             case "Data":
                return this.Data;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "Observacao":
                return this.Observacao;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionContaPagarClassAgrupadorContaLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassAgrupadorConta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberClassAgrupadorContaLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassAgrupadorConta)
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
                  command.CommandText += " COUNT(agrupador_conta.id_agrupador_conta) " ;
               }
               else
               {
               command.CommandText += "agrupador_conta.id_agrupador_conta, " ;
               command.CommandText += "agrupador_conta.agc_data, " ;
               command.CommandText += "agrupador_conta.version, " ;
               command.CommandText += "agrupador_conta.entity_uid, " ;
               command.CommandText += "agrupador_conta.agc_observacao " ;
               }
               command.CommandText += " FROM  agrupador_conta ";
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
                        orderByClause += " , agc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(agc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = agrupador_conta.id_acs_usuario_ultima_revisao ";
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
                     case "id_agrupador_conta":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , agrupador_conta.id_agrupador_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_conta.id_agrupador_conta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "agc_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , agrupador_conta.agc_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_conta.agc_data) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , agrupador_conta.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_conta.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_conta.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_conta.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "agc_observacao":
                     case "Observacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_conta.agc_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_conta.agc_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(agrupador_conta.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_conta.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("agc_observacao")) 
                        {
                           whereClause += " OR UPPER(agrupador_conta.agc_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_conta.agc_observacao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_agrupador_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_conta.id_agrupador_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_conta.id_agrupador_conta = :agrupador_conta_ID_3717 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_conta_ID_3717", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "agc_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_conta.agc_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_conta.agc_data = :agrupador_conta_Data_9081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_conta_Data_9081", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  agrupador_conta.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_conta.version = :agrupador_conta_Version_3593 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_conta_Version_3593", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  agrupador_conta.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_conta.entity_uid LIKE :agrupador_conta_EntityUid_7107 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_conta_EntityUid_7107", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacao" || parametro.FieldName == "agc_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_conta.agc_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_conta.agc_observacao LIKE :agrupador_conta_Observacao_2176 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_conta_Observacao_2176", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  agrupador_conta.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_conta.entity_uid LIKE :agrupador_conta_EntityUid_1446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_conta_EntityUid_1446", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoExato" || parametro.FieldName == "ObservacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_conta.agc_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_conta.agc_observacao LIKE :agrupador_conta_Observacao_7733 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_conta_Observacao_7733", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  AgrupadorContaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (AgrupadorContaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(AgrupadorContaClass), Convert.ToInt32(read["id_agrupador_conta"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new AgrupadorContaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_agrupador_conta"]);
                     entidade.Data = (DateTime)read["agc_data"];
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Observacao = (read["agc_observacao"] != DBNull.Value ? read["agc_observacao"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (AgrupadorContaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
