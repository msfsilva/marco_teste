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
     [Table("plano_corte","plc")]
     public class PlanoCorteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PlanoCorteClass";
protected const string ErroDelete = "Erro ao excluir o PlanoCorteClass  ";
protected const string ErroSave = "Erro ao salvar o PlanoCorteClass.";
protected const string ErroCollectionPlanoCorteItemClassPlanoCorte = "Erro ao carregar a coleção de PlanoCorteItemClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do PlanoCorteClass.";
protected const string MensagemUtilizadoCollectionPlanoCorteItemClassPlanoCorte =  "A entidade PlanoCorteClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PlanoCorteClass está sendo utilizada.";
#endregion
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

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("plc_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected bool _canceladoOriginal{get;private set;}
       private bool _canceladoOriginalCommited{get; set;}
        private bool _valueCancelado;
         [Column("plc_cancelado")]
        public virtual bool Cancelado
         { 
            get { return this._valueCancelado; } 
            set 
            { 
                if (this._valueCancelado == value)return;
                 this._valueCancelado = value; 
            } 
        } 

       protected string _cancelamentoJustificativaOriginal{get;private set;}
       private string _cancelamentoJustificativaOriginalCommited{get; set;}
        private string _valueCancelamentoJustificativa;
         [Column("plc_cancelamento_justificativa")]
        public virtual string CancelamentoJustificativa
         { 
            get { return this._valueCancelamentoJustificativa; } 
            set 
            { 
                if (this._valueCancelamentoJustificativa == value)return;
                 this._valueCancelamentoJustificativa = value; 
            } 
        } 

       protected DateTime? _cancelamentoDataOriginal{get;private set;}
       private DateTime? _cancelamentoDataOriginalCommited{get; set;}
        private DateTime? _valueCancelamentoData;
         [Column("plc_cancelamento_data")]
        public virtual DateTime? CancelamentoData
         { 
            get { return this._valueCancelamentoData; } 
            set 
            { 
                if (this._valueCancelamentoData == value)return;
                 this._valueCancelamentoData = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCancelamentoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCancelamentoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioCancelamento;
        [Column("id_acs_usuario_cancelamento", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioCancelamento
        { 
           get {                 return this._valueAcsUsuarioCancelamento; } 
           set 
           { 
                if (this._valueAcsUsuarioCancelamento == value)return;
                 this._valueAcsUsuarioCancelamento = value; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemClassPlanoCorteOriginal;
       private List<Entidades.PlanoCorteItemClass > _collectionPlanoCorteItemClassPlanoCorteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassPlanoCorteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassPlanoCorteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemClassPlanoCorteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemClass> _valueCollectionPlanoCorteItemClassPlanoCorte { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemClass> CollectionPlanoCorteItemClassPlanoCorte 
       { 
           get { if(!_valueCollectionPlanoCorteItemClassPlanoCorteLoaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemClassPlanoCorte();}
return this._valueCollectionPlanoCorteItemClassPlanoCorte; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemClassPlanoCorte = value; 
               this._valueCollectionPlanoCorteItemClassPlanoCorteLoaded = true; 
           } 
       } 

        public PlanoCorteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Cancelado = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static PlanoCorteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PlanoCorteClass) GetEntity(typeof(PlanoCorteClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionPlanoCorteItemClassPlanoCorteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemClassPlanoCorteChanged = true;
                  _valueCollectionPlanoCorteItemClassPlanoCorteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemClassPlanoCorteChanged = true; 
                  _valueCollectionPlanoCorteItemClassPlanoCorteCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemClassPlanoCorteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemClassPlanoCorteChanged = true; 
                  _valueCollectionPlanoCorteItemClassPlanoCorteCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemClass item in _valueCollectionPlanoCorteItemClassPlanoCorte) 
                 { 
                     _collectionPlanoCorteItemClassPlanoCorteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemClassPlanoCorte()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemClass> oc;
                _valueCollectionPlanoCorteItemClassPlanoCorteChanged = false;
                 _valueCollectionPlanoCorteItemClassPlanoCorteCommitedChanged = false;
                _collectionPlanoCorteItemClassPlanoCorteRemovidos = new List<Entidades.PlanoCorteItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemClass search = new Entidades.PlanoCorteItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PlanoCorte", this)                    }                       ).Cast<Entidades.PlanoCorteItemClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemClassPlanoCorte = new BindingList<Entidades.PlanoCorteItemClass>(oc); 
                 _collectionPlanoCorteItemClassPlanoCorteOriginal= (from a in _valueCollectionPlanoCorteItemClassPlanoCorte select a.ID).ToList();
                 _valueCollectionPlanoCorteItemClassPlanoCorteLoaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemClassPlanoCorteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemClassPlanoCorte+"\r\n" + e.Message, e);
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
                    "  public.plano_corte  " +
                    "WHERE " +
                    "  id_plano_corte = :id";
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
                        "  public.plano_corte   " +
                        "SET  " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  plc_data = :plc_data, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  plc_cancelado = :plc_cancelado, " + 
                        "  plc_cancelamento_justificativa = :plc_cancelamento_justificativa, " + 
                        "  plc_cancelamento_data = :plc_cancelamento_data, " + 
                        "  id_acs_usuario_cancelamento = :id_acs_usuario_cancelamento "+
                        "WHERE  " +
                        "  id_plano_corte = :id " +
                        "RETURNING id_plano_corte;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.plano_corte " +
                        "( " +
                        "  id_acs_usuario , " + 
                        "  plc_data , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  plc_cancelado , " + 
                        "  plc_cancelamento_justificativa , " + 
                        "  plc_cancelamento_data , " + 
                        "  id_acs_usuario_cancelamento  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_acs_usuario , " + 
                        "  :plc_data , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :plc_cancelado , " + 
                        "  :plc_cancelamento_justificativa , " + 
                        "  :plc_cancelamento_data , " + 
                        "  :id_acs_usuario_cancelamento  "+
                        ")RETURNING id_plano_corte;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plc_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plc_cancelado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cancelado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plc_cancelamento_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CancelamentoJustificativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plc_cancelamento_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CancelamentoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioCancelamento==null ? (object) DBNull.Value : this.AcsUsuarioCancelamento.ID;

 
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
 if (CollectionPlanoCorteItemClassPlanoCorte.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemClassPlanoCorte+"\r\n";
                foreach (Entidades.PlanoCorteItemClass tmp in CollectionPlanoCorteItemClassPlanoCorte)
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
        public static PlanoCorteClass CopiarEntidade(PlanoCorteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PlanoCorteClass toRet = new PlanoCorteClass(usuario,conn);
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Data= entidadeCopiar.Data;
 toRet.Cancelado= entidadeCopiar.Cancelado;
 toRet.CancelamentoJustificativa= entidadeCopiar.CancelamentoJustificativa;
 toRet.CancelamentoData= entidadeCopiar.CancelamentoData;
 toRet.AcsUsuarioCancelamento= entidadeCopiar.AcsUsuarioCancelamento;

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
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _canceladoOriginal = Cancelado;
       _canceladoOriginalCommited = _canceladoOriginal;
       _cancelamentoJustificativaOriginal = CancelamentoJustificativa;
       _cancelamentoJustificativaOriginalCommited = _cancelamentoJustificativaOriginal;
       _cancelamentoDataOriginal = CancelamentoData;
       _cancelamentoDataOriginalCommited = _cancelamentoDataOriginal;
       _acsUsuarioCancelamentoOriginal = AcsUsuarioCancelamento;
       _acsUsuarioCancelamentoOriginalCommited = _acsUsuarioCancelamentoOriginal;

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
       _acsUsuarioOriginalCommited = AcsUsuario;
       _dataOriginalCommited = Data;
       _versionOriginalCommited = Version;
       _canceladoOriginalCommited = Cancelado;
       _cancelamentoJustificativaOriginalCommited = CancelamentoJustificativa;
       _cancelamentoDataOriginalCommited = CancelamentoData;
       _acsUsuarioCancelamentoOriginalCommited = AcsUsuarioCancelamento;

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
               if (_valueCollectionPlanoCorteItemClassPlanoCorteLoaded) 
               {
                  if (_collectionPlanoCorteItemClassPlanoCorteRemovidos != null) 
                  {
                     _collectionPlanoCorteItemClassPlanoCorteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemClassPlanoCorteRemovidos = new List<Entidades.PlanoCorteItemClass>();
                  }
                  _collectionPlanoCorteItemClassPlanoCorteOriginal= (from a in _valueCollectionPlanoCorteItemClassPlanoCorte select a.ID).ToList();
                  _valueCollectionPlanoCorteItemClassPlanoCorteChanged = false;
                  _valueCollectionPlanoCorteItemClassPlanoCorteCommitedChanged = false;
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
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Cancelado=_canceladoOriginal;
               _canceladoOriginalCommited=_canceladoOriginal;
               CancelamentoJustificativa=_cancelamentoJustificativaOriginal;
               _cancelamentoJustificativaOriginalCommited=_cancelamentoJustificativaOriginal;
               CancelamentoData=_cancelamentoDataOriginal;
               _cancelamentoDataOriginalCommited=_cancelamentoDataOriginal;
               AcsUsuarioCancelamento=_acsUsuarioCancelamentoOriginal;
               _acsUsuarioCancelamentoOriginalCommited=_acsUsuarioCancelamentoOriginal;
               if (_valueCollectionPlanoCorteItemClassPlanoCorteLoaded) 
               {
                  CollectionPlanoCorteItemClassPlanoCorte.Clear();
                  foreach(int item in _collectionPlanoCorteItemClassPlanoCorteOriginal)
                  {
                    CollectionPlanoCorteItemClassPlanoCorte.Add(Entidades.PlanoCorteItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemClassPlanoCorteRemovidos.Clear();
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
               if (_valueCollectionPlanoCorteItemClassPlanoCorteLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassPlanoCorteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassPlanoCorteLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassPlanoCorte.Any(item => item.IsDirty());
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
       if (_acsUsuarioOriginal!=null)
       {
          dirty = !_acsUsuarioOriginal.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataOriginal != Data;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _canceladoOriginal != Cancelado;
      if (dirty) return true;
       dirty = _cancelamentoJustificativaOriginal != CancelamentoJustificativa;
      if (dirty) return true;
       dirty = _cancelamentoDataOriginal != CancelamentoData;
      if (dirty) return true;
       if (_acsUsuarioCancelamentoOriginal!=null)
       {
          dirty = !_acsUsuarioCancelamentoOriginal.Equals(AcsUsuarioCancelamento);
       }
       else
       {
            dirty = AcsUsuarioCancelamento != null;
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
               if (_valueCollectionPlanoCorteItemClassPlanoCorteLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemClassPlanoCorteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemClassPlanoCorteLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemClassPlanoCorte.Any(item => item.IsDirtyCommited());
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
       if (_acsUsuarioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioOriginalCommited.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _canceladoOriginalCommited != Cancelado;
      if (dirty) return true;
       dirty = _cancelamentoJustificativaOriginalCommited != CancelamentoJustificativa;
      if (dirty) return true;
       dirty = _cancelamentoDataOriginalCommited != CancelamentoData;
      if (dirty) return true;
       if (_acsUsuarioCancelamentoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioCancelamentoOriginalCommited.Equals(AcsUsuarioCancelamento);
       }
       else
       {
            dirty = AcsUsuarioCancelamento != null;
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
               if (_valueCollectionPlanoCorteItemClassPlanoCorteLoaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassPlanoCorte)
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
             case "AcsUsuario":
                return this.AcsUsuario;
             case "Data":
                return this.Data;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Cancelado":
                return this.Cancelado;
             case "CancelamentoJustificativa":
                return this.CancelamentoJustificativa;
             case "CancelamentoData":
                return this.CancelamentoData;
             case "AcsUsuarioCancelamento":
                return this.AcsUsuarioCancelamento;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
             if (AcsUsuarioCancelamento!=null)
                AcsUsuarioCancelamento.ChangeSingleConnection(newConnection);
               if (_valueCollectionPlanoCorteItemClassPlanoCorteLoaded) 
               {
                  foreach(PlanoCorteItemClass item in CollectionPlanoCorteItemClassPlanoCorte)
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
                  command.CommandText += " COUNT(plano_corte.id_plano_corte) " ;
               }
               else
               {
               command.CommandText += "plano_corte.id_plano_corte, " ;
               command.CommandText += "plano_corte.id_acs_usuario, " ;
               command.CommandText += "plano_corte.plc_data, " ;
               command.CommandText += "plano_corte.entity_uid, " ;
               command.CommandText += "plano_corte.version, " ;
               command.CommandText += "plano_corte.plc_cancelado, " ;
               command.CommandText += "plano_corte.plc_cancelamento_justificativa, " ;
               command.CommandText += "plano_corte.plc_cancelamento_data, " ;
               command.CommandText += "plano_corte.id_acs_usuario_cancelamento " ;
               }
               command.CommandText += " FROM  plano_corte ";
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
                        orderByClause += " , plc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(plc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = plano_corte.id_acs_usuario_ultima_revisao ";
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
                     case "id_plano_corte":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte.id_plano_corte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte.id_plano_corte) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , plano_corte.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "plc_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte.plc_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte.plc_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , plano_corte.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "plc_cancelado":
                     case "Cancelado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte.plc_cancelado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte.plc_cancelado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "plc_cancelamento_justificativa":
                     case "CancelamentoJustificativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte.plc_cancelamento_justificativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte.plc_cancelamento_justificativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "plc_cancelamento_data":
                     case "CancelamentoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte.plc_cancelamento_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte.plc_cancelamento_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_cancelamento":
                     case "AcsUsuarioCancelamento":
                     orderByClause += " , plano_corte.id_acs_usuario_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(plano_corte.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("plc_cancelamento_justificativa")) 
                        {
                           whereClause += " OR UPPER(plano_corte.plc_cancelamento_justificativa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte.plc_cancelamento_justificativa) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_plano_corte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte.id_plano_corte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.id_plano_corte = :plano_corte_ID_6127 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_ID_6127", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  plano_corte.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.id_acs_usuario = :plano_corte_AcsUsuario_2134 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_AcsUsuario_2134", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "plc_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte.plc_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.plc_data = :plano_corte_Data_2541 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_Data_2541", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  plano_corte.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.entity_uid LIKE :plano_corte_EntityUid_8153 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_EntityUid_8153", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  plano_corte.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.version = :plano_corte_Version_7699 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_Version_7699", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cancelado" || parametro.FieldName == "plc_cancelado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte.plc_cancelado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.plc_cancelado = :plano_corte_Cancelado_2948 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_Cancelado_2948", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CancelamentoJustificativa" || parametro.FieldName == "plc_cancelamento_justificativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte.plc_cancelamento_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.plc_cancelamento_justificativa LIKE :plano_corte_CancelamentoJustificativa_1266 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_CancelamentoJustificativa_1266", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CancelamentoData" || parametro.FieldName == "plc_cancelamento_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte.plc_cancelamento_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.plc_cancelamento_data = :plano_corte_CancelamentoData_3651 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_CancelamentoData_3651", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioCancelamento" || parametro.FieldName == "id_acs_usuario_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte.id_acs_usuario_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.id_acs_usuario_cancelamento = :plano_corte_AcsUsuarioCancelamento_9135 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_AcsUsuarioCancelamento_9135", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  plano_corte.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.entity_uid LIKE :plano_corte_EntityUid_1919 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_EntityUid_1919", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CancelamentoJustificativaExato" || parametro.FieldName == "CancelamentoJustificativaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte.plc_cancelamento_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte.plc_cancelamento_justificativa LIKE :plano_corte_CancelamentoJustificativa_5497 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_CancelamentoJustificativa_5497", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PlanoCorteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PlanoCorteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PlanoCorteClass), Convert.ToInt32(read["id_plano_corte"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PlanoCorteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_plano_corte"]);
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.Data = (DateTime)read["plc_data"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Cancelado = Convert.ToBoolean(Convert.ToInt16(read["plc_cancelado"]));
                     entidade.CancelamentoJustificativa = (read["plc_cancelamento_justificativa"] != DBNull.Value ? read["plc_cancelamento_justificativa"].ToString() : null);
                     entidade.CancelamentoData = read["plc_cancelamento_data"] as DateTime?;
                     if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioCancelamento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioCancelamento = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PlanoCorteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
