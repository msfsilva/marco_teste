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
     [Table("buffer_email","buf")]
     public class BufferEmailBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do BufferEmailClass";
protected const string ErroDelete = "Erro ao excluir o BufferEmailClass  ";
protected const string ErroSave = "Erro ao salvar o BufferEmailClass.";
protected const string ErroCollectionBufferEmailAnexoClassBufferEmail = "Erro ao carregar a coleção de BufferEmailAnexoClass.";
protected const string ErroRemetenteObrigatorio = "O campo Remetente é obrigatório";
protected const string ErroDestinatarioObrigatorio = "O campo Destinatario é obrigatório";
protected const string ErroTituloObrigatorio = "O campo Titulo é obrigatório";
protected const string ErroCorpoMensagemObrigatorio = "O campo CorpoMensagem é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do BufferEmailClass.";
protected const string MensagemUtilizadoCollectionBufferEmailAnexoClassBufferEmail =  "A entidade BufferEmailClass está sendo utilizada nos seguintes BufferEmailAnexoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade BufferEmailClass está sendo utilizada.";
#endregion
       protected string _remetenteOriginal{get;private set;}
       private string _remetenteOriginalCommited{get; set;}
        private string _valueRemetente;
         [Column("buf_remetente")]
        public virtual string Remetente
         { 
            get { return this._valueRemetente; } 
            set 
            { 
                if (this._valueRemetente == value)return;
                 this._valueRemetente = value; 
            } 
        } 

       protected string _destinatarioOriginal{get;private set;}
       private string _destinatarioOriginalCommited{get; set;}
        private string _valueDestinatario;
         [Column("buf_destinatario")]
        public virtual string Destinatario
         { 
            get { return this._valueDestinatario; } 
            set 
            { 
                if (this._valueDestinatario == value)return;
                 this._valueDestinatario = value; 
            } 
        } 

       protected string _tituloOriginal{get;private set;}
       private string _tituloOriginalCommited{get; set;}
        private string _valueTitulo;
         [Column("buf_titulo")]
        public virtual string Titulo
         { 
            get { return this._valueTitulo; } 
            set 
            { 
                if (this._valueTitulo == value)return;
                 this._valueTitulo = value; 
            } 
        } 

       protected bool _corpoHtmlOriginal{get;private set;}
       private bool _corpoHtmlOriginalCommited{get; set;}
        private bool _valueCorpoHtml;
         [Column("buf_corpo_html")]
        public virtual bool CorpoHtml
         { 
            get { return this._valueCorpoHtml; } 
            set 
            { 
                if (this._valueCorpoHtml == value)return;
                 this._valueCorpoHtml = value; 
            } 
        } 

       protected string _corpoMensagemOriginal{get;private set;}
       private string _corpoMensagemOriginalCommited{get; set;}
        private string _valueCorpoMensagem;
         [Column("buf_corpo_mensagem")]
        public virtual string CorpoMensagem
         { 
            get { return this._valueCorpoMensagem; } 
            set 
            { 
                if (this._valueCorpoMensagem == value)return;
                 this._valueCorpoMensagem = value; 
            } 
        } 

       protected DateTime _dataEntradaOriginal{get;private set;}
       private DateTime _dataEntradaOriginalCommited{get; set;}
        private DateTime _valueDataEntrada;
         [Column("buf_data_entrada")]
        public virtual DateTime DataEntrada
         { 
            get { return this._valueDataEntrada; } 
            set 
            { 
                if (this._valueDataEntrada == value)return;
                 this._valueDataEntrada = value; 
            } 
        } 

       protected DateTime? _dataEnvioOriginal{get;private set;}
       private DateTime? _dataEnvioOriginalCommited{get; set;}
        private DateTime? _valueDataEnvio;
         [Column("buf_data_envio")]
        public virtual DateTime? DataEnvio
         { 
            get { return this._valueDataEnvio; } 
            set 
            { 
                if (this._valueDataEnvio == value)return;
                 this._valueDataEnvio = value; 
            } 
        } 

       protected DateTime? _dataUltimaTentativaOriginal{get;private set;}
       private DateTime? _dataUltimaTentativaOriginalCommited{get; set;}
        private DateTime? _valueDataUltimaTentativa;
         [Column("buf_data_ultima_tentativa")]
        public virtual DateTime? DataUltimaTentativa
         { 
            get { return this._valueDataUltimaTentativa; } 
            set 
            { 
                if (this._valueDataUltimaTentativa == value)return;
                 this._valueDataUltimaTentativa = value; 
            } 
        } 

       protected string _ultimoErroOriginal{get;private set;}
       private string _ultimoErroOriginalCommited{get; set;}
        private string _valueUltimoErro;
         [Column("buf_ultimo_erro")]
        public virtual string UltimoErro
         { 
            get { return this._valueUltimoErro; } 
            set 
            { 
                if (this._valueUltimoErro == value)return;
                 this._valueUltimoErro = value; 
            } 
        } 

       protected short _numeroTentativasEnvioOriginal{get;private set;}
       private short _numeroTentativasEnvioOriginalCommited{get; set;}
        private short _valueNumeroTentativasEnvio;
         [Column("buf_numero_tentativas_envio")]
        public virtual short NumeroTentativasEnvio
         { 
            get { return this._valueNumeroTentativasEnvio; } 
            set 
            { 
                if (this._valueNumeroTentativasEnvio == value)return;
                 this._valueNumeroTentativasEnvio = value; 
            } 
        } 

       protected BufferEmailSituacao _situacaoOriginal{get;private set;}
       private BufferEmailSituacao _situacaoOriginalCommited{get; set;}
        private BufferEmailSituacao _valueSituacao;
         [Column("buf_situacao")]
        public virtual BufferEmailSituacao Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

        public bool Situacao_Pendente
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.BufferEmailSituacao.Pendente; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.BufferEmailSituacao.Pendente; }
         } 

        public bool Situacao_Enviado
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.BufferEmailSituacao.Enviado; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.BufferEmailSituacao.Enviado; }
         } 

        public bool Situacao_Erro
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.BufferEmailSituacao.Erro; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.BufferEmailSituacao.Erro; }
         } 

       private List<long> _collectionBufferEmailAnexoClassBufferEmailOriginal;
       private List<Entidades.BufferEmailAnexoClass > _collectionBufferEmailAnexoClassBufferEmailRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBufferEmailAnexoClassBufferEmailLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBufferEmailAnexoClassBufferEmailChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBufferEmailAnexoClassBufferEmailCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.BufferEmailAnexoClass> _valueCollectionBufferEmailAnexoClassBufferEmail { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.BufferEmailAnexoClass> CollectionBufferEmailAnexoClassBufferEmail 
       { 
           get { if(!_valueCollectionBufferEmailAnexoClassBufferEmailLoaded && !this.DisableLoadCollection){this.LoadCollectionBufferEmailAnexoClassBufferEmail();}
return this._valueCollectionBufferEmailAnexoClassBufferEmail; } 
           set 
           { 
               this._valueCollectionBufferEmailAnexoClassBufferEmail = value; 
               this._valueCollectionBufferEmailAnexoClassBufferEmailLoaded = true; 
           } 
       } 

        public BufferEmailBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.NumeroTentativasEnvio = 0;
           this.Situacao = (BufferEmailSituacao)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static BufferEmailClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (BufferEmailClass) GetEntity(typeof(BufferEmailClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionBufferEmailAnexoClassBufferEmailChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionBufferEmailAnexoClassBufferEmailChanged = true;
                  _valueCollectionBufferEmailAnexoClassBufferEmailCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionBufferEmailAnexoClassBufferEmailChanged = true; 
                  _valueCollectionBufferEmailAnexoClassBufferEmailCommitedChanged = true;
                 foreach (Entidades.BufferEmailAnexoClass item in e.OldItems) 
                 { 
                     _collectionBufferEmailAnexoClassBufferEmailRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionBufferEmailAnexoClassBufferEmailChanged = true; 
                  _valueCollectionBufferEmailAnexoClassBufferEmailCommitedChanged = true;
                 foreach (Entidades.BufferEmailAnexoClass item in _valueCollectionBufferEmailAnexoClassBufferEmail) 
                 { 
                     _collectionBufferEmailAnexoClassBufferEmailRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionBufferEmailAnexoClassBufferEmail()
         {
            try
            {
                 ObservableCollection<Entidades.BufferEmailAnexoClass> oc;
                _valueCollectionBufferEmailAnexoClassBufferEmailChanged = false;
                 _valueCollectionBufferEmailAnexoClassBufferEmailCommitedChanged = false;
                _collectionBufferEmailAnexoClassBufferEmailRemovidos = new List<Entidades.BufferEmailAnexoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.BufferEmailAnexoClass>();
                }
                else{ 
                   Entidades.BufferEmailAnexoClass search = new Entidades.BufferEmailAnexoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.BufferEmailAnexoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("BufferEmail", this),                     }                       ).Cast<Entidades.BufferEmailAnexoClass>().ToList());
                 }
                 _valueCollectionBufferEmailAnexoClassBufferEmail = new BindingList<Entidades.BufferEmailAnexoClass>(oc); 
                 _collectionBufferEmailAnexoClassBufferEmailOriginal= (from a in _valueCollectionBufferEmailAnexoClassBufferEmail select a.ID).ToList();
                 _valueCollectionBufferEmailAnexoClassBufferEmailLoaded = true;
                 oc.CollectionChanged += CollectionBufferEmailAnexoClassBufferEmailChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionBufferEmailAnexoClassBufferEmail+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Remetente))
                {
                    throw new Exception(ErroRemetenteObrigatorio);
                }
                if (string.IsNullOrEmpty(Destinatario))
                {
                    throw new Exception(ErroDestinatarioObrigatorio);
                }
                if (string.IsNullOrEmpty(Titulo))
                {
                    throw new Exception(ErroTituloObrigatorio);
                }
                if (string.IsNullOrEmpty(CorpoMensagem))
                {
                    throw new Exception(ErroCorpoMensagemObrigatorio);
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
                    "  public.buffer_email  " +
                    "WHERE " +
                    "  id_buffer_email = :id";
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
                        "  public.buffer_email   " +
                        "SET  " + 
                        "  buf_remetente = :buf_remetente, " + 
                        "  buf_destinatario = :buf_destinatario, " + 
                        "  buf_titulo = :buf_titulo, " + 
                        "  buf_corpo_html = :buf_corpo_html, " + 
                        "  buf_corpo_mensagem = :buf_corpo_mensagem, " + 
                        "  buf_data_entrada = :buf_data_entrada, " + 
                        "  buf_data_envio = :buf_data_envio, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  buf_data_ultima_tentativa = :buf_data_ultima_tentativa, " + 
                        "  buf_ultimo_erro = :buf_ultimo_erro, " + 
                        "  buf_numero_tentativas_envio = :buf_numero_tentativas_envio, " + 
                        "  buf_situacao = :buf_situacao "+
                        "WHERE  " +
                        "  id_buffer_email = :id " +
                        "RETURNING id_buffer_email;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.buffer_email " +
                        "( " +
                        "  buf_remetente , " + 
                        "  buf_destinatario , " + 
                        "  buf_titulo , " + 
                        "  buf_corpo_html , " + 
                        "  buf_corpo_mensagem , " + 
                        "  buf_data_entrada , " + 
                        "  buf_data_envio , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  buf_data_ultima_tentativa , " + 
                        "  buf_ultimo_erro , " + 
                        "  buf_numero_tentativas_envio , " + 
                        "  buf_situacao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :buf_remetente , " + 
                        "  :buf_destinatario , " + 
                        "  :buf_titulo , " + 
                        "  :buf_corpo_html , " + 
                        "  :buf_corpo_mensagem , " + 
                        "  :buf_data_entrada , " + 
                        "  :buf_data_envio , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :buf_data_ultima_tentativa , " + 
                        "  :buf_ultimo_erro , " + 
                        "  :buf_numero_tentativas_envio , " + 
                        "  :buf_situacao  "+
                        ")RETURNING id_buffer_email;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_remetente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Remetente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_destinatario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Destinatario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_titulo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Titulo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_corpo_html", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CorpoHtml ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_corpo_mensagem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CorpoMensagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_data_entrada", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_data_envio", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEnvio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_data_ultima_tentativa", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataUltimaTentativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_ultimo_erro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimoErro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_numero_tentativas_envio", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroTentativasEnvio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buf_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Situacao);

 
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
 if (CollectionBufferEmailAnexoClassBufferEmail.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionBufferEmailAnexoClassBufferEmail+"\r\n";
                foreach (Entidades.BufferEmailAnexoClass tmp in CollectionBufferEmailAnexoClassBufferEmail)
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
        public static BufferEmailClass CopiarEntidade(BufferEmailClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               BufferEmailClass toRet = new BufferEmailClass(usuario,conn);
 toRet.Remetente= entidadeCopiar.Remetente;
 toRet.Destinatario= entidadeCopiar.Destinatario;
 toRet.Titulo= entidadeCopiar.Titulo;
 toRet.CorpoHtml= entidadeCopiar.CorpoHtml;
 toRet.CorpoMensagem= entidadeCopiar.CorpoMensagem;
 toRet.DataEntrada= entidadeCopiar.DataEntrada;
 toRet.DataEnvio= entidadeCopiar.DataEnvio;
 toRet.DataUltimaTentativa= entidadeCopiar.DataUltimaTentativa;
 toRet.UltimoErro= entidadeCopiar.UltimoErro;
 toRet.NumeroTentativasEnvio= entidadeCopiar.NumeroTentativasEnvio;
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
       _remetenteOriginal = Remetente;
       _remetenteOriginalCommited = _remetenteOriginal;
       _destinatarioOriginal = Destinatario;
       _destinatarioOriginalCommited = _destinatarioOriginal;
       _tituloOriginal = Titulo;
       _tituloOriginalCommited = _tituloOriginal;
       _corpoHtmlOriginal = CorpoHtml;
       _corpoHtmlOriginalCommited = _corpoHtmlOriginal;
       _corpoMensagemOriginal = CorpoMensagem;
       _corpoMensagemOriginalCommited = _corpoMensagemOriginal;
       _dataEntradaOriginal = DataEntrada;
       _dataEntradaOriginalCommited = _dataEntradaOriginal;
       _dataEnvioOriginal = DataEnvio;
       _dataEnvioOriginalCommited = _dataEnvioOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _dataUltimaTentativaOriginal = DataUltimaTentativa;
       _dataUltimaTentativaOriginalCommited = _dataUltimaTentativaOriginal;
       _ultimoErroOriginal = UltimoErro;
       _ultimoErroOriginalCommited = _ultimoErroOriginal;
       _numeroTentativasEnvioOriginal = NumeroTentativasEnvio;
       _numeroTentativasEnvioOriginalCommited = _numeroTentativasEnvioOriginal;
       _situacaoOriginal = Situacao;
       _situacaoOriginalCommited = _situacaoOriginal;

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
       _remetenteOriginalCommited = Remetente;
       _destinatarioOriginalCommited = Destinatario;
       _tituloOriginalCommited = Titulo;
       _corpoHtmlOriginalCommited = CorpoHtml;
       _corpoMensagemOriginalCommited = CorpoMensagem;
       _dataEntradaOriginalCommited = DataEntrada;
       _dataEnvioOriginalCommited = DataEnvio;
       _versionOriginalCommited = Version;
       _dataUltimaTentativaOriginalCommited = DataUltimaTentativa;
       _ultimoErroOriginalCommited = UltimoErro;
       _numeroTentativasEnvioOriginalCommited = NumeroTentativasEnvio;
       _situacaoOriginalCommited = Situacao;

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
               if (_valueCollectionBufferEmailAnexoClassBufferEmailLoaded) 
               {
                  if (_collectionBufferEmailAnexoClassBufferEmailRemovidos != null) 
                  {
                     _collectionBufferEmailAnexoClassBufferEmailRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionBufferEmailAnexoClassBufferEmailRemovidos = new List<Entidades.BufferEmailAnexoClass>();
                  }
                  _collectionBufferEmailAnexoClassBufferEmailOriginal= (from a in _valueCollectionBufferEmailAnexoClassBufferEmail select a.ID).ToList();
                  _valueCollectionBufferEmailAnexoClassBufferEmailChanged = false;
                  _valueCollectionBufferEmailAnexoClassBufferEmailCommitedChanged = false;
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
               Remetente=_remetenteOriginal;
               _remetenteOriginalCommited=_remetenteOriginal;
               Destinatario=_destinatarioOriginal;
               _destinatarioOriginalCommited=_destinatarioOriginal;
               Titulo=_tituloOriginal;
               _tituloOriginalCommited=_tituloOriginal;
               CorpoHtml=_corpoHtmlOriginal;
               _corpoHtmlOriginalCommited=_corpoHtmlOriginal;
               CorpoMensagem=_corpoMensagemOriginal;
               _corpoMensagemOriginalCommited=_corpoMensagemOriginal;
               DataEntrada=_dataEntradaOriginal;
               _dataEntradaOriginalCommited=_dataEntradaOriginal;
               DataEnvio=_dataEnvioOriginal;
               _dataEnvioOriginalCommited=_dataEnvioOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               DataUltimaTentativa=_dataUltimaTentativaOriginal;
               _dataUltimaTentativaOriginalCommited=_dataUltimaTentativaOriginal;
               UltimoErro=_ultimoErroOriginal;
               _ultimoErroOriginalCommited=_ultimoErroOriginal;
               NumeroTentativasEnvio=_numeroTentativasEnvioOriginal;
               _numeroTentativasEnvioOriginalCommited=_numeroTentativasEnvioOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               if (_valueCollectionBufferEmailAnexoClassBufferEmailLoaded) 
               {
                  CollectionBufferEmailAnexoClassBufferEmail.Clear();
                  foreach(int item in _collectionBufferEmailAnexoClassBufferEmailOriginal)
                  {
                    CollectionBufferEmailAnexoClassBufferEmail.Add(Entidades.BufferEmailAnexoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionBufferEmailAnexoClassBufferEmailRemovidos.Clear();
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
               if (_valueCollectionBufferEmailAnexoClassBufferEmailLoaded) 
               {
                  if (_valueCollectionBufferEmailAnexoClassBufferEmailChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionBufferEmailAnexoClassBufferEmailLoaded) 
               {
                   tempRet = CollectionBufferEmailAnexoClassBufferEmail.Any(item => item.IsDirty());
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
       dirty = _remetenteOriginal != Remetente;
      if (dirty) return true;
       dirty = _destinatarioOriginal != Destinatario;
      if (dirty) return true;
       dirty = _tituloOriginal != Titulo;
      if (dirty) return true;
       dirty = _corpoHtmlOriginal != CorpoHtml;
      if (dirty) return true;
       dirty = _corpoMensagemOriginal != CorpoMensagem;
      if (dirty) return true;
       dirty = _dataEntradaOriginal != DataEntrada;
      if (dirty) return true;
       dirty = _dataEnvioOriginal != DataEnvio;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _dataUltimaTentativaOriginal != DataUltimaTentativa;
      if (dirty) return true;
       dirty = _ultimoErroOriginal != UltimoErro;
      if (dirty) return true;
       dirty = _numeroTentativasEnvioOriginal != NumeroTentativasEnvio;
      if (dirty) return true;
       dirty = _situacaoOriginal != Situacao;

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
               if (_valueCollectionBufferEmailAnexoClassBufferEmailLoaded) 
               {
                  if (_valueCollectionBufferEmailAnexoClassBufferEmailCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionBufferEmailAnexoClassBufferEmailLoaded) 
               {
                   tempRet = CollectionBufferEmailAnexoClassBufferEmail.Any(item => item.IsDirtyCommited());
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
       dirty = _remetenteOriginalCommited != Remetente;
      if (dirty) return true;
       dirty = _destinatarioOriginalCommited != Destinatario;
      if (dirty) return true;
       dirty = _tituloOriginalCommited != Titulo;
      if (dirty) return true;
       dirty = _corpoHtmlOriginalCommited != CorpoHtml;
      if (dirty) return true;
       dirty = _corpoMensagemOriginalCommited != CorpoMensagem;
      if (dirty) return true;
       dirty = _dataEntradaOriginalCommited != DataEntrada;
      if (dirty) return true;
       dirty = _dataEnvioOriginalCommited != DataEnvio;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _dataUltimaTentativaOriginalCommited != DataUltimaTentativa;
      if (dirty) return true;
       dirty = _ultimoErroOriginalCommited != UltimoErro;
      if (dirty) return true;
       dirty = _numeroTentativasEnvioOriginalCommited != NumeroTentativasEnvio;
      if (dirty) return true;
       dirty = _situacaoOriginalCommited != Situacao;

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
               if (_valueCollectionBufferEmailAnexoClassBufferEmailLoaded) 
               {
                  foreach(BufferEmailAnexoClass item in CollectionBufferEmailAnexoClassBufferEmail)
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
             case "Remetente":
                return this.Remetente;
             case "Destinatario":
                return this.Destinatario;
             case "Titulo":
                return this.Titulo;
             case "CorpoHtml":
                return this.CorpoHtml;
             case "CorpoMensagem":
                return this.CorpoMensagem;
             case "DataEntrada":
                return this.DataEntrada;
             case "DataEnvio":
                return this.DataEnvio;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "DataUltimaTentativa":
                return this.DataUltimaTentativa;
             case "UltimoErro":
                return this.UltimoErro;
             case "NumeroTentativasEnvio":
                return this.NumeroTentativasEnvio;
             case "Situacao":
                return this.Situacao;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionBufferEmailAnexoClassBufferEmailLoaded) 
               {
                  foreach(BufferEmailAnexoClass item in CollectionBufferEmailAnexoClassBufferEmail)
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
                  command.CommandText += " COUNT(buffer_email.id_buffer_email) " ;
               }
               else
               {
               command.CommandText += "buffer_email.id_buffer_email, " ;
               command.CommandText += "buffer_email.buf_remetente, " ;
               command.CommandText += "buffer_email.buf_destinatario, " ;
               command.CommandText += "buffer_email.buf_titulo, " ;
               command.CommandText += "buffer_email.buf_corpo_html, " ;
               command.CommandText += "buffer_email.buf_corpo_mensagem, " ;
               command.CommandText += "buffer_email.buf_data_entrada, " ;
               command.CommandText += "buffer_email.buf_data_envio, " ;
               command.CommandText += "buffer_email.entity_uid, " ;
               command.CommandText += "buffer_email.version, " ;
               command.CommandText += "buffer_email.buf_data_ultima_tentativa, " ;
               command.CommandText += "buffer_email.buf_ultimo_erro, " ;
               command.CommandText += "buffer_email.buf_numero_tentativas_envio, " ;
               command.CommandText += "buffer_email.buf_situacao " ;
               }
               command.CommandText += " FROM  buffer_email ";
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
                        orderByClause += " , buf_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(buf_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = buffer_email.id_acs_usuario_ultima_revisao ";
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
                     case "id_buffer_email":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , buffer_email.id_buffer_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email.id_buffer_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_remetente":
                     case "Remetente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , buffer_email.buf_remetente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(buffer_email.buf_remetente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_destinatario":
                     case "Destinatario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , buffer_email.buf_destinatario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(buffer_email.buf_destinatario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_titulo":
                     case "Titulo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , buffer_email.buf_titulo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(buffer_email.buf_titulo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_corpo_html":
                     case "CorpoHtml":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , buffer_email.buf_corpo_html " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email.buf_corpo_html) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_corpo_mensagem":
                     case "CorpoMensagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , buffer_email.buf_corpo_mensagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(buffer_email.buf_corpo_mensagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_data_entrada":
                     case "DataEntrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , buffer_email.buf_data_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email.buf_data_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_data_envio":
                     case "DataEnvio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , buffer_email.buf_data_envio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email.buf_data_envio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , buffer_email.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(buffer_email.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , buffer_email.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_data_ultima_tentativa":
                     case "DataUltimaTentativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , buffer_email.buf_data_ultima_tentativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email.buf_data_ultima_tentativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_ultimo_erro":
                     case "UltimoErro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , buffer_email.buf_ultimo_erro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(buffer_email.buf_ultimo_erro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_numero_tentativas_envio":
                     case "NumeroTentativasEnvio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , buffer_email.buf_numero_tentativas_envio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email.buf_numero_tentativas_envio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buf_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , buffer_email.buf_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email.buf_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buf_remetente")) 
                        {
                           whereClause += " OR UPPER(buffer_email.buf_remetente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(buffer_email.buf_remetente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buf_destinatario")) 
                        {
                           whereClause += " OR UPPER(buffer_email.buf_destinatario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(buffer_email.buf_destinatario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buf_titulo")) 
                        {
                           whereClause += " OR UPPER(buffer_email.buf_titulo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(buffer_email.buf_titulo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buf_corpo_mensagem")) 
                        {
                           whereClause += " OR UPPER(buffer_email.buf_corpo_mensagem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(buffer_email.buf_corpo_mensagem) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(buffer_email.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(buffer_email.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buf_ultimo_erro")) 
                        {
                           whereClause += " OR UPPER(buffer_email.buf_ultimo_erro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(buffer_email.buf_ultimo_erro) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_buffer_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.id_buffer_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.id_buffer_email = :buffer_email_ID_7304 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_ID_7304", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Remetente" || parametro.FieldName == "buf_remetente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_remetente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_remetente LIKE :buffer_email_Remetente_6028 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_Remetente_6028", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Destinatario" || parametro.FieldName == "buf_destinatario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_destinatario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_destinatario LIKE :buffer_email_Destinatario_5430 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_Destinatario_5430", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Titulo" || parametro.FieldName == "buf_titulo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_titulo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_titulo LIKE :buffer_email_Titulo_1259 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_Titulo_1259", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CorpoHtml" || parametro.FieldName == "buf_corpo_html")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_corpo_html IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_corpo_html = :buffer_email_CorpoHtml_4413 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_CorpoHtml_4413", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CorpoMensagem" || parametro.FieldName == "buf_corpo_mensagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_corpo_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_corpo_mensagem LIKE :buffer_email_CorpoMensagem_1270 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_CorpoMensagem_1270", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrada" || parametro.FieldName == "buf_data_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_data_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_data_entrada = :buffer_email_DataEntrada_9421 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_DataEntrada_9421", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEnvio" || parametro.FieldName == "buf_data_envio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_data_envio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_data_envio = :buffer_email_DataEnvio_8907 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_DataEnvio_8907", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  buffer_email.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.entity_uid LIKE :buffer_email_EntityUid_8343 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_EntityUid_8343", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  buffer_email.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.version = :buffer_email_Version_7508 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_Version_7508", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataUltimaTentativa" || parametro.FieldName == "buf_data_ultima_tentativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_data_ultima_tentativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_data_ultima_tentativa = :buffer_email_DataUltimaTentativa_1756 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_DataUltimaTentativa_1756", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimoErro" || parametro.FieldName == "buf_ultimo_erro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_ultimo_erro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_ultimo_erro LIKE :buffer_email_UltimoErro_3629 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_UltimoErro_3629", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroTentativasEnvio" || parametro.FieldName == "buf_numero_tentativas_envio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_numero_tentativas_envio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_numero_tentativas_envio = :buffer_email_NumeroTentativasEnvio_7876 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_NumeroTentativasEnvio_7876", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "buf_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BufferEmailSituacao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BufferEmailSituacao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_situacao = :buffer_email_Situacao_7674 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_Situacao_7674", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RemetenteExato" || parametro.FieldName == "RemetenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_remetente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_remetente LIKE :buffer_email_Remetente_6324 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_Remetente_6324", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DestinatarioExato" || parametro.FieldName == "DestinatarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_destinatario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_destinatario LIKE :buffer_email_Destinatario_1801 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_Destinatario_1801", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TituloExato" || parametro.FieldName == "TituloExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_titulo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_titulo LIKE :buffer_email_Titulo_5739 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_Titulo_5739", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CorpoMensagemExato" || parametro.FieldName == "CorpoMensagemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_corpo_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_corpo_mensagem LIKE :buffer_email_CorpoMensagem_2818 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_CorpoMensagem_2818", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  buffer_email.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.entity_uid LIKE :buffer_email_EntityUid_6468 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_EntityUid_6468", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimoErroExato" || parametro.FieldName == "UltimoErroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email.buf_ultimo_erro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email.buf_ultimo_erro LIKE :buffer_email_UltimoErro_7481 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_UltimoErro_7481", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  BufferEmailClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (BufferEmailClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(BufferEmailClass), Convert.ToInt32(read["id_buffer_email"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new BufferEmailClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_buffer_email"]);
                     entidade.Remetente = (read["buf_remetente"] != DBNull.Value ? read["buf_remetente"].ToString() : null);
                     entidade.Destinatario = (read["buf_destinatario"] != DBNull.Value ? read["buf_destinatario"].ToString() : null);
                     entidade.Titulo = (read["buf_titulo"] != DBNull.Value ? read["buf_titulo"].ToString() : null);
                     entidade.CorpoHtml = Convert.ToBoolean(Convert.ToInt16(read["buf_corpo_html"]));
                     entidade.CorpoMensagem = (read["buf_corpo_mensagem"] != DBNull.Value ? read["buf_corpo_mensagem"].ToString() : null);
                     entidade.DataEntrada = (DateTime)read["buf_data_entrada"];
                     entidade.DataEnvio = read["buf_data_envio"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.DataUltimaTentativa = read["buf_data_ultima_tentativa"] as DateTime?;
                     entidade.UltimoErro = (read["buf_ultimo_erro"] != DBNull.Value ? read["buf_ultimo_erro"].ToString() : null);
                     entidade.NumeroTentativasEnvio = (short)read["buf_numero_tentativas_envio"];
                     entidade.Situacao = (BufferEmailSituacao) (read["buf_situacao"] != DBNull.Value ? Enum.ToObject(typeof(BufferEmailSituacao), read["buf_situacao"]) : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (BufferEmailClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
