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
     [Table("epi_ca","eca")]
     public class EpiCaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EpiCaClass";
protected const string ErroDelete = "Erro ao excluir o EpiCaClass  ";
protected const string ErroSave = "Erro ao salvar o EpiCaClass.";
protected const string ErroCollectionEpiClassEpiCa = "Erro ao carregar a coleção de EpiClass.";
protected const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
protected const string ErroNomeDocumentoObrigatorio = "O campo NomeDocumento é obrigatório";
protected const string ErroNomeDocumentoComprimento = "O campo NomeDocumento deve ter no máximo 255 caracteres";
protected const string ErroUltimaRevisaoObrigatorio = "O campo UltimaRevisao é obrigatório";
protected const string ErroUltimaRevisaoComprimento = "O campo UltimaRevisao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroDocumentoObrigatorio = "O campo Documento é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do EpiCaClass.";
protected const string MensagemUtilizadoCollectionEpiClassEpiCa =  "A entidade EpiCaClass está sendo utilizada nos seguintes EpiClass:";
protected const string ErroDocumentoLoad = "O campo Documento não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EpiCaClass está sendo utilizada.";
#endregion
       protected string _numeroOriginal{get;private set;}
       private string _numeroOriginalCommited{get; set;}
        private string _valueNumero;
         [Column("eca_numero")]
        public virtual string Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected string _documentoOriginal= null;
        private string _documentoOriginalCommited= null;
        private bool _DocumentoLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool DocumentoLoaded 
       { 
            get {                     return _DocumentoLoaded; } 
           set 
           { 
                this._DocumentoLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueDocumento;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("eca_documento")]
        public virtual byte[] Documento
         { 
            get { 
                   if (!this.DocumentoLoaded) 
                   {
                       this.LoadDocumento();
                   }
                   return this._valueDocumento; } 
            set 
            { 
                DocumentoLoaded = true; 
                if (this._valueDocumento == value)return;
                 this._valueDocumento = value; 
            } 
        } 

       protected string _nomeDocumentoOriginal{get;private set;}
       private string _nomeDocumentoOriginalCommited{get; set;}
        private string _valueNomeDocumento;
         [Column("eca_nome_documento")]
        public virtual string NomeDocumento
         { 
            get { return this._valueNomeDocumento; } 
            set 
            { 
                if (this._valueNomeDocumento == value)return;
                 this._valueNomeDocumento = value; 
            } 
        } 

       protected DateTime _validadeOriginal{get;private set;}
       private DateTime _validadeOriginalCommited{get; set;}
        private DateTime _valueValidade;
         [Column("eca_validade")]
        public virtual DateTime Validade
         { 
            get { return this._valueValidade; } 
            set 
            { 
                if (this._valueValidade == value)return;
                 this._valueValidade = value; 
            } 
        } 

       protected bool _vencidoOriginal{get;private set;}
       private bool _vencidoOriginalCommited{get; set;}
        private bool _valueVencido;
         [Column("eca_vencido")]
        public virtual bool Vencido
         { 
            get { return this._valueVencido; } 
            set 
            { 
                if (this._valueVencido == value)return;
                 this._valueVencido = value; 
            } 
        } 

       private List<long> _collectionEpiClassEpiCaOriginal;
       private List<Entidades.EpiClass > _collectionEpiClassEpiCaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiClassEpiCaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiClassEpiCaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiClassEpiCaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EpiClass> _valueCollectionEpiClassEpiCa { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EpiClass> CollectionEpiClassEpiCa 
       { 
           get { if(!_valueCollectionEpiClassEpiCaLoaded && !this.DisableLoadCollection){this.LoadCollectionEpiClassEpiCa();}
return this._valueCollectionEpiClassEpiCa; } 
           set 
           { 
               this._valueCollectionEpiClassEpiCa = value; 
               this._valueCollectionEpiClassEpiCaLoaded = true; 
           } 
       } 

        public EpiCaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static EpiCaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EpiCaClass) GetEntity(typeof(EpiCaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEpiClassEpiCaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEpiClassEpiCaChanged = true;
                  _valueCollectionEpiClassEpiCaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEpiClassEpiCaChanged = true; 
                  _valueCollectionEpiClassEpiCaCommitedChanged = true;
                 foreach (Entidades.EpiClass item in e.OldItems) 
                 { 
                     _collectionEpiClassEpiCaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEpiClassEpiCaChanged = true; 
                  _valueCollectionEpiClassEpiCaCommitedChanged = true;
                 foreach (Entidades.EpiClass item in _valueCollectionEpiClassEpiCa) 
                 { 
                     _collectionEpiClassEpiCaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEpiClassEpiCa()
         {
            try
            {
                 ObservableCollection<Entidades.EpiClass> oc;
                _valueCollectionEpiClassEpiCaChanged = false;
                 _valueCollectionEpiClassEpiCaCommitedChanged = false;
                _collectionEpiClassEpiCaRemovidos = new List<Entidades.EpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EpiClass>();
                }
                else{ 
                   Entidades.EpiClass search = new Entidades.EpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EpiCa", this)                    }                       ).Cast<Entidades.EpiClass>().ToList());
                 }
                 _valueCollectionEpiClassEpiCa = new BindingList<Entidades.EpiClass>(oc); 
                 _collectionEpiClassEpiCaOriginal= (from a in _valueCollectionEpiClassEpiCa select a.ID).ToList();
                 _valueCollectionEpiClassEpiCaLoaded = true;
                 oc.CollectionChanged += CollectionEpiClassEpiCaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEpiClassEpiCa+"\r\n" + e.Message, e);
            }
         } 
private void LoadDocumento()
        {
            try
            {
                if (this.ID == -1)
                {

                    DocumentoLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT eca_documento FROM epi_ca WHERE id_epi_ca = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueDocumento = (byte[]) tmp;
                }
                if (this._valueDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _documentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                     }
                  } 
                  else 
                  { 
                        _documentoOriginal = null ;
                  } 
                DocumentoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroDocumentoLoad + "\r\n" + e.Message, e);
            }
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Numero))
                {
                    throw new Exception(ErroNumeroObrigatorio);
                }
                if (string.IsNullOrEmpty(NomeDocumento))
                {
                    throw new Exception(ErroNomeDocumentoObrigatorio);
                }
                if (NomeDocumento.Length >255)
                {
                    throw new Exception( ErroNomeDocumentoComprimento);
                }
                if (Documento==null)
                {
                    throw new Exception(ErroDocumentoObrigatorio);
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
                    "  public.epi_ca  " +
                    "WHERE " +
                    "  id_epi_ca = :id";
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
                        "  public.epi_ca   " +
                        "SET  " + 
                        "  eca_numero = :eca_numero, " + 
                        "  eca_documento = :eca_documento, " + 
                        "  eca_nome_documento = :eca_nome_documento, " + 
                        "  eca_validade = :eca_validade, " + 
                        "  eca_vencido = :eca_vencido, " + 
                        "  eca_ultima_revisao = :eca_ultima_revisao, " + 
                        "  eca_ultima_revisao_data = :eca_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_epi_ca = :id " +
                        "RETURNING id_epi_ca;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.epi_ca " +
                        "( " +
                        "  eca_numero , " + 
                        "  eca_documento , " + 
                        "  eca_nome_documento , " + 
                        "  eca_validade , " + 
                        "  eca_vencido , " + 
                        "  eca_ultima_revisao , " + 
                        "  eca_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :eca_numero , " + 
                        "  :eca_documento , " + 
                        "  :eca_nome_documento , " + 
                        "  :eca_validade , " + 
                        "  :eca_vencido , " + 
                        "  :eca_ultima_revisao , " + 
                        "  :eca_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_epi_ca;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("eca_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("eca_documento", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Documento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("eca_nome_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("eca_validade", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Validade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("eca_vencido", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Vencido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("eca_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("eca_ultima_revisao_data", NpgsqlDbType.Timestamp));
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
 if (CollectionEpiClassEpiCa.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEpiClassEpiCa+"\r\n";
                foreach (Entidades.EpiClass tmp in CollectionEpiClassEpiCa)
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
        public static EpiCaClass CopiarEntidade(EpiCaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EpiCaClass toRet = new EpiCaClass(usuario,conn);
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Documento= entidadeCopiar.Documento;
 toRet.NomeDocumento= entidadeCopiar.NomeDocumento;
 toRet.Validade= entidadeCopiar.Validade;
 toRet.Vencido= entidadeCopiar.Vencido;

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
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _nomeDocumentoOriginal = NomeDocumento;
       _nomeDocumentoOriginalCommited = _nomeDocumentoOriginal;
       _validadeOriginal = Validade;
       _validadeOriginalCommited = _validadeOriginal;
       _vencidoOriginal = Vencido;
       _vencidoOriginalCommited = _vencidoOriginal;
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
       _numeroOriginalCommited = Numero;
       _nomeDocumentoOriginalCommited = NomeDocumento;
       _validadeOriginalCommited = Validade;
       _vencidoOriginalCommited = Vencido;
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
               if (DocumentoLoaded)
               {
                  if(this._valueDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _documentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                     }
                  } 
                  else 
                  { 
                        _documentoOriginal = null ;
                  } 
               }
               if (_valueCollectionEpiClassEpiCaLoaded) 
               {
                  if (_collectionEpiClassEpiCaRemovidos != null) 
                  {
                     _collectionEpiClassEpiCaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEpiClassEpiCaRemovidos = new List<Entidades.EpiClass>();
                  }
                  _collectionEpiClassEpiCaOriginal= (from a in _valueCollectionEpiClassEpiCa select a.ID).ToList();
                  _valueCollectionEpiClassEpiCaChanged = false;
                  _valueCollectionEpiClassEpiCaCommitedChanged = false;
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
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               DocumentoLoaded = false;
               this._documentoOriginal = null;
               this._documentoOriginalCommited = null;
               this._valueDocumento = null;
               NomeDocumento=_nomeDocumentoOriginal;
               _nomeDocumentoOriginalCommited=_nomeDocumentoOriginal;
               Validade=_validadeOriginal;
               _validadeOriginalCommited=_validadeOriginal;
               Vencido=_vencidoOriginal;
               _vencidoOriginalCommited=_vencidoOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionEpiClassEpiCaLoaded) 
               {
                  CollectionEpiClassEpiCa.Clear();
                  foreach(int item in _collectionEpiClassEpiCaOriginal)
                  {
                    CollectionEpiClassEpiCa.Add(Entidades.EpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEpiClassEpiCaRemovidos.Clear();
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
               if (_valueCollectionEpiClassEpiCaLoaded) 
               {
                  if (_valueCollectionEpiClassEpiCaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiClassEpiCaLoaded) 
               {
                   tempRet = CollectionEpiClassEpiCa.Any(item => item.IsDirty());
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
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
               if (DocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpDocumento ;
                      if (this._valueDocumento == null) 
                      { 
                         tmpDocumento = null; 
                      } 
                      else 
                      { 
                         tmpDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                      } 
                       dirty = _documentoOriginal != tmpDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _nomeDocumentoOriginal != NomeDocumento;
      if (dirty) return true;
       dirty = _validadeOriginal != Validade;
      if (dirty) return true;
       dirty = _vencidoOriginal != Vencido;
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
               if (_valueCollectionEpiClassEpiCaLoaded) 
               {
                  if (_valueCollectionEpiClassEpiCaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiClassEpiCaLoaded) 
               {
                   tempRet = CollectionEpiClassEpiCa.Any(item => item.IsDirtyCommited());
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
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
               if (DocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpDocumento ;
                      if (this._valueDocumento == null) 
                      { 
                         tmpDocumento = null; 
                      } 
                      else 
                      { 
                         tmpDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                      } 
                       dirty = _documentoOriginalCommited != tmpDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _nomeDocumentoOriginalCommited != NomeDocumento;
      if (dirty) return true;
       dirty = _validadeOriginalCommited != Validade;
      if (dirty) return true;
       dirty = _vencidoOriginalCommited != Vencido;
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
               if (_valueCollectionEpiClassEpiCaLoaded) 
               {
                  foreach(EpiClass item in CollectionEpiClassEpiCa)
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
             case "Numero":
                return this.Numero;
             case "Documento":
                return this.Documento;
             case "NomeDocumento":
                return this.NomeDocumento;
             case "Validade":
                return this.Validade;
             case "Vencido":
                return this.Vencido;
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
               if (_valueCollectionEpiClassEpiCaLoaded) 
               {
                  foreach(EpiClass item in CollectionEpiClassEpiCa)
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
                  command.CommandText += " COUNT(epi_ca.id_epi_ca) " ;
               }
               else
               {
               command.CommandText += "epi_ca.id_epi_ca, " ;
               command.CommandText += "epi_ca.eca_numero, " ;
               command.CommandText += "epi_ca.eca_nome_documento, " ;
               command.CommandText += "epi_ca.eca_validade, " ;
               command.CommandText += "epi_ca.eca_vencido, " ;
               command.CommandText += "epi_ca.eca_ultima_revisao, " ;
               command.CommandText += "epi_ca.eca_ultima_revisao_data, " ;
               command.CommandText += "epi_ca.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "epi_ca.entity_uid, " ;
               command.CommandText += "epi_ca.version " ;
               }
               command.CommandText += " FROM  epi_ca ";
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
                        orderByClause += " , eca_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(eca_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = epi_ca.id_acs_usuario_ultima_revisao ";
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
                     case "id_epi_ca":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_ca.id_epi_ca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_ca.id_epi_ca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "eca_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi_ca.eca_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi_ca.eca_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "eca_documento":
                     case "Documento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_ca.eca_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_ca.eca_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "eca_nome_documento":
                     case "NomeDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi_ca.eca_nome_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi_ca.eca_nome_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "eca_validade":
                     case "Validade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_ca.eca_validade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_ca.eca_validade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "eca_vencido":
                     case "Vencido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_ca.eca_vencido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_ca.eca_vencido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "eca_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi_ca.eca_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi_ca.eca_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "eca_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_ca.eca_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_ca.eca_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , epi_ca.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi_ca.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi_ca.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , epi_ca.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_ca.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("eca_numero")) 
                        {
                           whereClause += " OR UPPER(epi_ca.eca_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi_ca.eca_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("eca_nome_documento")) 
                        {
                           whereClause += " OR UPPER(epi_ca.eca_nome_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi_ca.eca_nome_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("eca_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(epi_ca.eca_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi_ca.eca_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(epi_ca.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi_ca.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_epi_ca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.id_epi_ca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.id_epi_ca = :epi_ca_ID_8874 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_ID_8874", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "eca_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.eca_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_numero LIKE :epi_ca_Numero_2948 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_Numero_2948", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Documento" || parametro.FieldName == "eca_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.eca_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_documento = :epi_ca_Documento_2268 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_Documento_2268", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeDocumento" || parametro.FieldName == "eca_nome_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.eca_nome_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_nome_documento LIKE :epi_ca_NomeDocumento_1126 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_NomeDocumento_1126", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Validade" || parametro.FieldName == "eca_validade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.eca_validade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_validade = :epi_ca_Validade_3961 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_Validade_3961", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Vencido" || parametro.FieldName == "eca_vencido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.eca_vencido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_vencido = :epi_ca_Vencido_3307 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_Vencido_3307", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "eca_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.eca_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_ultima_revisao LIKE :epi_ca_UltimaRevisao_8087 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_UltimaRevisao_8087", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "eca_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.eca_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_ultima_revisao_data = :epi_ca_UltimaRevisaoData_4166 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_UltimaRevisaoData_4166", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  epi_ca.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.id_acs_usuario_ultima_revisao = :epi_ca_UltimaRevisaoUsuario_1779 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_UltimaRevisaoUsuario_1779", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  epi_ca.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.entity_uid LIKE :epi_ca_EntityUid_3203 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_EntityUid_3203", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  epi_ca.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.version = :epi_ca_Version_8443 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_Version_8443", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroExato" || parametro.FieldName == "NumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.eca_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_numero LIKE :epi_ca_Numero_8179 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_Numero_8179", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeDocumentoExato" || parametro.FieldName == "NomeDocumentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_ca.eca_nome_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_nome_documento LIKE :epi_ca_NomeDocumento_4454 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_NomeDocumento_4454", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  epi_ca.eca_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.eca_ultima_revisao LIKE :epi_ca_UltimaRevisao_6029 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_UltimaRevisao_6029", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  epi_ca.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_ca.entity_uid LIKE :epi_ca_EntityUid_9152 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_ca_EntityUid_9152", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EpiCaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EpiCaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EpiCaClass), Convert.ToInt32(read["id_epi_ca"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EpiCaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_epi_ca"]);
                     entidade.Numero = (read["eca_numero"] != DBNull.Value ? read["eca_numero"].ToString() : null);
                     entidade.NomeDocumento = (read["eca_nome_documento"] != DBNull.Value ? read["eca_nome_documento"].ToString() : null);
                     entidade.Validade = (DateTime)read["eca_validade"];
                     entidade.Vencido = Convert.ToBoolean(Convert.ToInt16(read["eca_vencido"]));
                     entidade.UltimaRevisao = (read["eca_ultima_revisao"] != DBNull.Value ? read["eca_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["eca_ultima_revisao_data"] as DateTime?;
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
                     entidade = (EpiCaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
