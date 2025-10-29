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
     [Table("embarque","emb")]
     public class EmbarqueBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EmbarqueClass";
protected const string ErroDelete = "Erro ao excluir o EmbarqueClass  ";
protected const string ErroSave = "Erro ao salvar o EmbarqueClass.";
protected const string ErroCollectionOrderItemEtiquetaConferenciaClassEmbarque = "Erro ao carregar a coleção de OrderItemEtiquetaConferenciaClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do EmbarqueClass.";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaClassEmbarque =  "A entidade EmbarqueClass está sendo utilizada nos seguintes OrderItemEtiquetaConferenciaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EmbarqueClass está sendo utilizada.";
#endregion
       protected bool _liberadoNfOriginal{get;private set;}
       private bool _liberadoNfOriginalCommited{get; set;}
        private bool _valueLiberadoNf;
         [Column("emb_liberado_nf")]
        public virtual bool LiberadoNf
         { 
            get { return this._valueLiberadoNf; } 
            set 
            { 
                if (this._valueLiberadoNf == value)return;
                 this._valueLiberadoNf = value; 
            } 
        } 

       protected bool _nfEmitidaOriginal{get;private set;}
       private bool _nfEmitidaOriginalCommited{get; set;}
        private bool _valueNfEmitida;
         [Column("emb_nf_emitida")]
        public virtual bool NfEmitida
         { 
            get { return this._valueNfEmitida; } 
            set 
            { 
                if (this._valueNfEmitida == value)return;
                 this._valueNfEmitida = value; 
            } 
        } 

       protected DateTime? _liberacaoHoraOriginal{get;private set;}
       private DateTime? _liberacaoHoraOriginalCommited{get; set;}
        private DateTime? _valueLiberacaoHora;
         [Column("emb_liberacao_hora")]
        public virtual DateTime? LiberacaoHora
         { 
            get { return this._valueLiberacaoHora; } 
            set 
            { 
                if (this._valueLiberacaoHora == value)return;
                 this._valueLiberacaoHora = value; 
            } 
        } 

       protected string _liberacaoUsuarioOriginal{get;private set;}
       private string _liberacaoUsuarioOriginalCommited{get; set;}
        private string _valueLiberacaoUsuario;
         [Column("emb_liberacao_usuario")]
        public virtual string LiberacaoUsuario
         { 
            get { return this._valueLiberacaoUsuario; } 
            set 
            { 
                if (this._valueLiberacaoUsuario == value)return;
                 this._valueLiberacaoUsuario = value; 
            } 
        } 

       protected string _usuarioOriginal{get;private set;}
       private string _usuarioOriginalCommited{get; set;}
        private string _valueUsuario;
         [Column("emb_usuario")]
        public virtual string Usuario
         { 
            get { return this._valueUsuario; } 
            set 
            { 
                if (this._valueUsuario == value)return;
                 this._valueUsuario = value; 
            } 
        } 

       protected DateTime? _dataHoraOriginal{get;private set;}
       private DateTime? _dataHoraOriginalCommited{get; set;}
        private DateTime? _valueDataHora;
         [Column("emb_data_hora")]
        public virtual DateTime? DataHora
         { 
            get { return this._valueDataHora; } 
            set 
            { 
                if (this._valueDataHora == value)return;
                 this._valueDataHora = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.TransporteClass _transporteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.TransporteClass _transporteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.TransporteClass _valueTransporte;
        [Column("id_transporte", "transporte", "id_transporte")]
       public virtual BibliotecaEntidades.Entidades.TransporteClass Transporte
        { 
           get {                 return this._valueTransporte; } 
           set 
           { 
                if (this._valueTransporte == value)return;
                 this._valueTransporte = value; 
           } 
       } 

       protected bool _nfAutorizadaOriginal{get;private set;}
       private bool _nfAutorizadaOriginalCommited{get; set;}
        private bool _valueNfAutorizada;
         [Column("emb_nf_autorizada")]
        public virtual bool NfAutorizada
         { 
            get { return this._valueNfAutorizada; } 
            set 
            { 
                if (this._valueNfAutorizada == value)return;
                 this._valueNfAutorizada = value; 
            } 
        } 

       private List<long> _collectionOrderItemEtiquetaConferenciaClassEmbarqueOriginal;
       private List<Entidades.OrderItemEtiquetaConferenciaClass > _collectionOrderItemEtiquetaConferenciaClassEmbarqueRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaConferenciaClass> _valueCollectionOrderItemEtiquetaConferenciaClassEmbarque { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaConferenciaClass> CollectionOrderItemEtiquetaConferenciaClassEmbarque 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaConferenciaClassEmbarque();}
return this._valueCollectionOrderItemEtiquetaConferenciaClassEmbarque; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaConferenciaClassEmbarque = value; 
               this._valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded = true; 
           } 
       } 

        public EmbarqueBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.LiberadoNf = false;
           this.NfEmitida = false;
           this.NfAutorizada = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static EmbarqueClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EmbarqueClass) GetEntity(typeof(EmbarqueClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrderItemEtiquetaConferenciaClassEmbarqueChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueChanged = true;
                  _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaClassEmbarqueRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaClass item in _valueCollectionOrderItemEtiquetaConferenciaClassEmbarque) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaClassEmbarqueRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaConferenciaClassEmbarque()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaConferenciaClass> oc;
                _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueChanged = false;
                 _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueCommitedChanged = false;
                _collectionOrderItemEtiquetaConferenciaClassEmbarqueRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaConferenciaClass search = new Entidades.OrderItemEtiquetaConferenciaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Embarque", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaConferenciaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaConferenciaClassEmbarque = new BindingList<Entidades.OrderItemEtiquetaConferenciaClass>(oc); 
                 _collectionOrderItemEtiquetaConferenciaClassEmbarqueOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaClassEmbarque select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaConferenciaClassEmbarqueChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaConferenciaClassEmbarque+"\r\n" + e.Message, e);
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
                    "  public.embarque  " +
                    "WHERE " +
                    "  id_embarque = :id";
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
                        "  public.embarque   " +
                        "SET  " + 
                        "  emb_liberado_nf = :emb_liberado_nf, " + 
                        "  emb_nf_emitida = :emb_nf_emitida, " + 
                        "  emb_liberacao_hora = :emb_liberacao_hora, " + 
                        "  emb_liberacao_usuario = :emb_liberacao_usuario, " + 
                        "  emb_usuario = :emb_usuario, " + 
                        "  emb_data_hora = :emb_data_hora, " + 
                        "  id_transporte = :id_transporte, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  emb_nf_autorizada = :emb_nf_autorizada "+
                        "WHERE  " +
                        "  id_embarque = :id " +
                        "RETURNING id_embarque;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.embarque " +
                        "( " +
                        "  emb_liberado_nf , " + 
                        "  emb_nf_emitida , " + 
                        "  emb_liberacao_hora , " + 
                        "  emb_liberacao_usuario , " + 
                        "  emb_usuario , " + 
                        "  emb_data_hora , " + 
                        "  id_transporte , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  emb_nf_autorizada  "+
                        ")  " +
                        "VALUES ( " +
                        "  :emb_liberado_nf , " + 
                        "  :emb_nf_emitida , " + 
                        "  :emb_liberacao_hora , " + 
                        "  :emb_liberacao_usuario , " + 
                        "  :emb_usuario , " + 
                        "  :emb_data_hora , " + 
                        "  :id_transporte , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :emb_nf_autorizada  "+
                        ")RETURNING id_embarque;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_liberado_nf", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LiberadoNf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_nf_emitida", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NfEmitida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_liberacao_hora", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LiberacaoHora ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_liberacao_usuario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LiberacaoUsuario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_usuario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Usuario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_data_hora", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataHora ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_transporte", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Transporte==null ? (object) DBNull.Value : this.Transporte.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_nf_autorizada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NfAutorizada ?? DBNull.Value;

 
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
 if (CollectionOrderItemEtiquetaConferenciaClassEmbarque.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaClassEmbarque+"\r\n";
                foreach (Entidades.OrderItemEtiquetaConferenciaClass tmp in CollectionOrderItemEtiquetaConferenciaClassEmbarque)
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
        public static EmbarqueClass CopiarEntidade(EmbarqueClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EmbarqueClass toRet = new EmbarqueClass(usuario,conn);
 toRet.LiberadoNf= entidadeCopiar.LiberadoNf;
 toRet.NfEmitida= entidadeCopiar.NfEmitida;
 toRet.LiberacaoHora= entidadeCopiar.LiberacaoHora;
 toRet.LiberacaoUsuario= entidadeCopiar.LiberacaoUsuario;
 toRet.Usuario= entidadeCopiar.Usuario;
 toRet.DataHora= entidadeCopiar.DataHora;
 toRet.Transporte= entidadeCopiar.Transporte;
 toRet.NfAutorizada= entidadeCopiar.NfAutorizada;

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
       _liberadoNfOriginal = LiberadoNf;
       _liberadoNfOriginalCommited = _liberadoNfOriginal;
       _nfEmitidaOriginal = NfEmitida;
       _nfEmitidaOriginalCommited = _nfEmitidaOriginal;
       _liberacaoHoraOriginal = LiberacaoHora;
       _liberacaoHoraOriginalCommited = _liberacaoHoraOriginal;
       _liberacaoUsuarioOriginal = LiberacaoUsuario;
       _liberacaoUsuarioOriginalCommited = _liberacaoUsuarioOriginal;
       _usuarioOriginal = Usuario;
       _usuarioOriginalCommited = _usuarioOriginal;
       _dataHoraOriginal = DataHora;
       _dataHoraOriginalCommited = _dataHoraOriginal;
       _transporteOriginal = Transporte;
       _transporteOriginalCommited = _transporteOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _nfAutorizadaOriginal = NfAutorizada;
       _nfAutorizadaOriginalCommited = _nfAutorizadaOriginal;

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
       _liberadoNfOriginalCommited = LiberadoNf;
       _nfEmitidaOriginalCommited = NfEmitida;
       _liberacaoHoraOriginalCommited = LiberacaoHora;
       _liberacaoUsuarioOriginalCommited = LiberacaoUsuario;
       _usuarioOriginalCommited = Usuario;
       _dataHoraOriginalCommited = DataHora;
       _transporteOriginalCommited = Transporte;
       _versionOriginalCommited = Version;
       _nfAutorizadaOriginalCommited = NfAutorizada;

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
               if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded) 
               {
                  if (_collectionOrderItemEtiquetaConferenciaClassEmbarqueRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaConferenciaClassEmbarqueRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaConferenciaClassEmbarqueRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaClass>();
                  }
                  _collectionOrderItemEtiquetaConferenciaClassEmbarqueOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaClassEmbarque select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueChanged = false;
                  _valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueCommitedChanged = false;
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
               LiberadoNf=_liberadoNfOriginal;
               _liberadoNfOriginalCommited=_liberadoNfOriginal;
               NfEmitida=_nfEmitidaOriginal;
               _nfEmitidaOriginalCommited=_nfEmitidaOriginal;
               LiberacaoHora=_liberacaoHoraOriginal;
               _liberacaoHoraOriginalCommited=_liberacaoHoraOriginal;
               LiberacaoUsuario=_liberacaoUsuarioOriginal;
               _liberacaoUsuarioOriginalCommited=_liberacaoUsuarioOriginal;
               Usuario=_usuarioOriginal;
               _usuarioOriginalCommited=_usuarioOriginal;
               DataHora=_dataHoraOriginal;
               _dataHoraOriginalCommited=_dataHoraOriginal;
               Transporte=_transporteOriginal;
               _transporteOriginalCommited=_transporteOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               NfAutorizada=_nfAutorizadaOriginal;
               _nfAutorizadaOriginalCommited=_nfAutorizadaOriginal;
               if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded) 
               {
                  CollectionOrderItemEtiquetaConferenciaClassEmbarque.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaConferenciaClassEmbarqueOriginal)
                  {
                    CollectionOrderItemEtiquetaConferenciaClassEmbarque.Add(Entidades.OrderItemEtiquetaConferenciaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaConferenciaClassEmbarqueRemovidos.Clear();
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
               if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaClassEmbarque.Any(item => item.IsDirty());
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
       dirty = _liberadoNfOriginal != LiberadoNf;
      if (dirty) return true;
       dirty = _nfEmitidaOriginal != NfEmitida;
      if (dirty) return true;
       dirty = _liberacaoHoraOriginal != LiberacaoHora;
      if (dirty) return true;
       dirty = _liberacaoUsuarioOriginal != LiberacaoUsuario;
      if (dirty) return true;
       dirty = _usuarioOriginal != Usuario;
      if (dirty) return true;
       dirty = _dataHoraOriginal != DataHora;
      if (dirty) return true;
       if (_transporteOriginal!=null)
       {
          dirty = !_transporteOriginal.Equals(Transporte);
       }
       else
       {
            dirty = Transporte != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _nfAutorizadaOriginal != NfAutorizada;

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
               if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaClassEmbarque.Any(item => item.IsDirtyCommited());
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
       dirty = _liberadoNfOriginalCommited != LiberadoNf;
      if (dirty) return true;
       dirty = _nfEmitidaOriginalCommited != NfEmitida;
      if (dirty) return true;
       dirty = _liberacaoHoraOriginalCommited != LiberacaoHora;
      if (dirty) return true;
       dirty = _liberacaoUsuarioOriginalCommited != LiberacaoUsuario;
      if (dirty) return true;
       dirty = _usuarioOriginalCommited != Usuario;
      if (dirty) return true;
       dirty = _dataHoraOriginalCommited != DataHora;
      if (dirty) return true;
       if (_transporteOriginalCommited!=null)
       {
          dirty = !_transporteOriginalCommited.Equals(Transporte);
       }
       else
       {
            dirty = Transporte != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _nfAutorizadaOriginalCommited != NfAutorizada;

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
               if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaClass item in CollectionOrderItemEtiquetaConferenciaClassEmbarque)
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
             case "LiberadoNf":
                return this.LiberadoNf;
             case "NfEmitida":
                return this.NfEmitida;
             case "LiberacaoHora":
                return this.LiberacaoHora;
             case "LiberacaoUsuario":
                return this.LiberacaoUsuario;
             case "Usuario":
                return this.Usuario;
             case "DataHora":
                return this.DataHora;
             case "Transporte":
                return this.Transporte;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "NfAutorizada":
                return this.NfAutorizada;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Transporte!=null)
                Transporte.ChangeSingleConnection(newConnection);
               if (_valueCollectionOrderItemEtiquetaConferenciaClassEmbarqueLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaClass item in CollectionOrderItemEtiquetaConferenciaClassEmbarque)
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
                  command.CommandText += " COUNT(embarque.id_embarque) " ;
               }
               else
               {
               command.CommandText += "embarque.id_embarque, " ;
               command.CommandText += "embarque.emb_liberado_nf, " ;
               command.CommandText += "embarque.emb_nf_emitida, " ;
               command.CommandText += "embarque.emb_liberacao_hora, " ;
               command.CommandText += "embarque.emb_liberacao_usuario, " ;
               command.CommandText += "embarque.emb_usuario, " ;
               command.CommandText += "embarque.emb_data_hora, " ;
               command.CommandText += "embarque.id_transporte, " ;
               command.CommandText += "embarque.entity_uid, " ;
               command.CommandText += "embarque.version, " ;
               command.CommandText += "embarque.emb_nf_autorizada " ;
               }
               command.CommandText += " FROM  embarque ";
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
                        orderByClause += " , emb_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(emb_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = embarque.id_acs_usuario_ultima_revisao ";
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
                     case "id_embarque":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embarque.id_embarque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embarque.id_embarque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_liberado_nf":
                     case "LiberadoNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embarque.emb_liberado_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embarque.emb_liberado_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_nf_emitida":
                     case "NfEmitida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embarque.emb_nf_emitida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embarque.emb_nf_emitida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_liberacao_hora":
                     case "LiberacaoHora":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embarque.emb_liberacao_hora " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embarque.emb_liberacao_hora) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_liberacao_usuario":
                     case "LiberacaoUsuario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , embarque.emb_liberacao_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(embarque.emb_liberacao_usuario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_usuario":
                     case "Usuario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , embarque.emb_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(embarque.emb_usuario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_data_hora":
                     case "DataHora":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embarque.emb_data_hora " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embarque.emb_data_hora) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_transporte":
                     case "Transporte":
                     command.CommandText += " LEFT JOIN transporte as transporte_Transporte ON transporte_Transporte.id_transporte = embarque.id_transporte ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte_Transporte.trp_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte_Transporte.trp_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , embarque.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(embarque.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , embarque.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embarque.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_nf_autorizada":
                     case "NfAutorizada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embarque.emb_nf_autorizada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embarque.emb_nf_autorizada) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("emb_liberacao_usuario")) 
                        {
                           whereClause += " OR UPPER(embarque.emb_liberacao_usuario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(embarque.emb_liberacao_usuario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("emb_usuario")) 
                        {
                           whereClause += " OR UPPER(embarque.emb_usuario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(embarque.emb_usuario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(embarque.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(embarque.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_embarque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.id_embarque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.id_embarque = :embarque_ID_3521 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_ID_3521", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LiberadoNf" || parametro.FieldName == "emb_liberado_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.emb_liberado_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.emb_liberado_nf = :embarque_LiberadoNf_160 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_LiberadoNf_160", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfEmitida" || parametro.FieldName == "emb_nf_emitida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.emb_nf_emitida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.emb_nf_emitida = :embarque_NfEmitida_6094 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_NfEmitida_6094", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LiberacaoHora" || parametro.FieldName == "emb_liberacao_hora")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.emb_liberacao_hora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.emb_liberacao_hora = :embarque_LiberacaoHora_2318 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_LiberacaoHora_2318", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LiberacaoUsuario" || parametro.FieldName == "emb_liberacao_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.emb_liberacao_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.emb_liberacao_usuario LIKE :embarque_LiberacaoUsuario_1654 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_LiberacaoUsuario_1654", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Usuario" || parametro.FieldName == "emb_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.emb_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.emb_usuario LIKE :embarque_Usuario_6001 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_Usuario_6001", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataHora" || parametro.FieldName == "emb_data_hora")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.emb_data_hora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.emb_data_hora = :embarque_DataHora_9162 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_DataHora_9162", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Transporte" || parametro.FieldName == "id_transporte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.TransporteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.TransporteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.id_transporte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.id_transporte = :embarque_Transporte_1012 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_Transporte_1012", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  embarque.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.entity_uid LIKE :embarque_EntityUid_3173 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_EntityUid_3173", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  embarque.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.version = :embarque_Version_819 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_Version_819", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfAutorizada" || parametro.FieldName == "emb_nf_autorizada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.emb_nf_autorizada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.emb_nf_autorizada = :embarque_NfAutorizada_6180 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_NfAutorizada_6180", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LiberacaoUsuarioExato" || parametro.FieldName == "LiberacaoUsuarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.emb_liberacao_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.emb_liberacao_usuario LIKE :embarque_LiberacaoUsuario_3095 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_LiberacaoUsuario_3095", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioExato" || parametro.FieldName == "UsuarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embarque.emb_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.emb_usuario LIKE :embarque_Usuario_7700 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_Usuario_7700", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  embarque.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embarque.entity_uid LIKE :embarque_EntityUid_5233 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embarque_EntityUid_5233", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EmbarqueClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EmbarqueClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EmbarqueClass), Convert.ToInt32(read["id_embarque"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EmbarqueClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_embarque"]);
                     entidade.LiberadoNf = Convert.ToBoolean(Convert.ToInt16(read["emb_liberado_nf"]));
                     entidade.NfEmitida = Convert.ToBoolean(Convert.ToInt16(read["emb_nf_emitida"]));
                     entidade.LiberacaoHora = read["emb_liberacao_hora"] as DateTime?;
                     entidade.LiberacaoUsuario = (read["emb_liberacao_usuario"] != DBNull.Value ? read["emb_liberacao_usuario"].ToString() : null);
                     entidade.Usuario = (read["emb_usuario"] != DBNull.Value ? read["emb_usuario"].ToString() : null);
                     entidade.DataHora = read["emb_data_hora"] as DateTime?;
                     if (read["id_transporte"] != DBNull.Value)
                     {
                        entidade.Transporte = (BibliotecaEntidades.Entidades.TransporteClass)BibliotecaEntidades.Entidades.TransporteClass.GetEntidade(Convert.ToInt32(read["id_transporte"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Transporte = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.NfAutorizada = Convert.ToBoolean(Convert.ToInt16(read["emb_nf_autorizada"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EmbarqueClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
