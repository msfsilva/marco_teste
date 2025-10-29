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
     [Table("programacao","prg")]
     public class ProgramacaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProgramacaoClass";
protected const string ErroDelete = "Erro ao excluir o ProgramacaoClass  ";
protected const string ErroSave = "Erro ao salvar o ProgramacaoClass.";
protected const string ErroCollectionPedidoItemClassProgramacao = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroAcsUsuarioCriacaoObrigatorio = "O campo AcsUsuarioCriacao é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ProgramacaoClass.";
protected const string MensagemUtilizadoCollectionPedidoItemClassProgramacao =  "A entidade ProgramacaoClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProgramacaoClass está sendo utilizada.";
#endregion
       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("prg_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected DateTime _dataCriacaoOriginal{get;private set;}
       private DateTime _dataCriacaoOriginalCommited{get; set;}
        private DateTime _valueDataCriacao;
         [Column("prg_data_criacao")]
        public virtual DateTime DataCriacao
         { 
            get { return this._valueDataCriacao; } 
            set 
            { 
                if (this._valueDataCriacao == value)return;
                 this._valueDataCriacao = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCriacaoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCriacaoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioCriacao;
        [Column("id_acs_usuario_criacao", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioCriacao
        { 
           get {                 return this._valueAcsUsuarioCriacao; } 
           set 
           { 
                if (this._valueAcsUsuarioCriacao == value)return;
                 this._valueAcsUsuarioCriacao = value; 
           } 
       } 

       protected int? _programacaoGadIdOriginal{get;private set;}
       private int? _programacaoGadIdOriginalCommited{get; set;}
        private int? _valueProgramacaoGadId;
         [Column("prg_programacao_gad_id")]
        public virtual int? ProgramacaoGadId
         { 
            get { return this._valueProgramacaoGadId; } 
            set 
            { 
                if (this._valueProgramacaoGadId == value)return;
                 this._valueProgramacaoGadId = value; 
            } 
        } 

       protected GadIntegracaoProgramacaoSituacao _situacaoGadOriginal{get;private set;}
       private GadIntegracaoProgramacaoSituacao _situacaoGadOriginalCommited{get; set;}
        private GadIntegracaoProgramacaoSituacao _valueSituacaoGad;
         [Column("prg_situacao_gad")]
        public virtual GadIntegracaoProgramacaoSituacao SituacaoGad
         { 
            get { return this._valueSituacaoGad; } 
            set 
            { 
                if (this._valueSituacaoGad == value)return;
                 this._valueSituacaoGad = value; 
            } 
        } 

        public bool SituacaoGad_Pendente
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoProgramacaoSituacao.Pendente; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoProgramacaoSituacao.Pendente; }
         } 

        public bool SituacaoGad_Enviada
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoProgramacaoSituacao.Enviada; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoProgramacaoSituacao.Enviada; }
         } 

        public bool SituacaoGad_ErroFinal
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoProgramacaoSituacao.ErroFinal; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoProgramacaoSituacao.ErroFinal; }
         } 

       protected string _situacaoGadMensagemOriginal{get;private set;}
       private string _situacaoGadMensagemOriginalCommited{get; set;}
        private string _valueSituacaoGadMensagem;
         [Column("prg_situacao_gad_mensagem")]
        public virtual string SituacaoGadMensagem
         { 
            get { return this._valueSituacaoGadMensagem; } 
            set 
            { 
                if (this._valueSituacaoGadMensagem == value)return;
                 this._valueSituacaoGadMensagem = value; 
            } 
        } 

       protected short _tentativasEnvioOriginal{get;private set;}
       private short _tentativasEnvioOriginalCommited{get; set;}
        private short _valueTentativasEnvio;
         [Column("prg_tentativas_envio")]
        public virtual short TentativasEnvio
         { 
            get { return this._valueTentativasEnvio; } 
            set 
            { 
                if (this._valueTentativasEnvio == value)return;
                 this._valueTentativasEnvio = value; 
            } 
        } 

       private List<long> _collectionPedidoItemClassProgramacaoOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassProgramacaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassProgramacaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassProgramacaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassProgramacaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassProgramacao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassProgramacao 
       { 
           get { if(!_valueCollectionPedidoItemClassProgramacaoLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassProgramacao();}
return this._valueCollectionPedidoItemClassProgramacao; } 
           set 
           { 
               this._valueCollectionPedidoItemClassProgramacao = value; 
               this._valueCollectionPedidoItemClassProgramacaoLoaded = true; 
           } 
       } 

        public ProgramacaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.DataCriacao = Configurations.DataIndependenteClass.GetData();
           this.SituacaoGad = (GadIntegracaoProgramacaoSituacao)0;
           this.TentativasEnvio = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ProgramacaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProgramacaoClass) GetEntity(typeof(ProgramacaoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionPedidoItemClassProgramacaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassProgramacaoChanged = true;
                  _valueCollectionPedidoItemClassProgramacaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassProgramacaoChanged = true; 
                  _valueCollectionPedidoItemClassProgramacaoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassProgramacaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassProgramacaoChanged = true; 
                  _valueCollectionPedidoItemClassProgramacaoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassProgramacao) 
                 { 
                     _collectionPedidoItemClassProgramacaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassProgramacao()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassProgramacaoChanged = false;
                 _valueCollectionPedidoItemClassProgramacaoCommitedChanged = false;
                _collectionPedidoItemClassProgramacaoRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Programacao", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassProgramacao = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassProgramacaoOriginal= (from a in _valueCollectionPedidoItemClassProgramacao select a.ID).ToList();
                 _valueCollectionPedidoItemClassProgramacaoLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassProgramacaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassProgramacao+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                {
                    throw new Exception(ErroNomeObrigatorio);
                }
                if (Nome.Length >255)
                {
                    throw new Exception( ErroNomeComprimento);
                }
                if ( _valueAcsUsuarioCriacao == null)
                {
                    throw new Exception(ErroAcsUsuarioCriacaoObrigatorio);
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
                    "  public.programacao  " +
                    "WHERE " +
                    "  id_programacao = :id";
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
                        "  public.programacao   " +
                        "SET  " + 
                        "  prg_nome = :prg_nome, " + 
                        "  prg_data_criacao = :prg_data_criacao, " + 
                        "  id_acs_usuario_criacao = :id_acs_usuario_criacao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  prg_programacao_gad_id = :prg_programacao_gad_id, " + 
                        "  prg_situacao_gad = :prg_situacao_gad, " + 
                        "  prg_situacao_gad_mensagem = :prg_situacao_gad_mensagem, " + 
                        "  prg_tentativas_envio = :prg_tentativas_envio "+
                        "WHERE  " +
                        "  id_programacao = :id " +
                        "RETURNING id_programacao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.programacao " +
                        "( " +
                        "  prg_nome , " + 
                        "  prg_data_criacao , " + 
                        "  id_acs_usuario_criacao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  prg_programacao_gad_id , " + 
                        "  prg_situacao_gad , " + 
                        "  prg_situacao_gad_mensagem , " + 
                        "  prg_tentativas_envio  "+
                        ")  " +
                        "VALUES ( " +
                        "  :prg_nome , " + 
                        "  :prg_data_criacao , " + 
                        "  :id_acs_usuario_criacao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :prg_programacao_gad_id , " + 
                        "  :prg_situacao_gad , " + 
                        "  :prg_situacao_gad_mensagem , " + 
                        "  :prg_tentativas_envio  "+
                        ")RETURNING id_programacao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_data_criacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCriacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_criacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioCriacao==null ? (object) DBNull.Value : this.AcsUsuarioCriacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_programacao_gad_id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProgramacaoGadId ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_situacao_gad", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.SituacaoGad);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_situacao_gad_mensagem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SituacaoGadMensagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_tentativas_envio", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TentativasEnvio ?? DBNull.Value;

 
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
 if (CollectionPedidoItemClassProgramacao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassProgramacao+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassProgramacao)
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
        public static ProgramacaoClass CopiarEntidade(ProgramacaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProgramacaoClass toRet = new ProgramacaoClass(usuario,conn);
 toRet.Nome= entidadeCopiar.Nome;
 toRet.DataCriacao= entidadeCopiar.DataCriacao;
 toRet.AcsUsuarioCriacao= entidadeCopiar.AcsUsuarioCriacao;
 toRet.ProgramacaoGadId= entidadeCopiar.ProgramacaoGadId;
 toRet.SituacaoGad= entidadeCopiar.SituacaoGad;
 toRet.SituacaoGadMensagem= entidadeCopiar.SituacaoGadMensagem;
 toRet.TentativasEnvio= entidadeCopiar.TentativasEnvio;

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
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _dataCriacaoOriginal = DataCriacao;
       _dataCriacaoOriginalCommited = _dataCriacaoOriginal;
       _acsUsuarioCriacaoOriginal = AcsUsuarioCriacao;
       _acsUsuarioCriacaoOriginalCommited = _acsUsuarioCriacaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _programacaoGadIdOriginal = ProgramacaoGadId;
       _programacaoGadIdOriginalCommited = _programacaoGadIdOriginal;
       _situacaoGadOriginal = SituacaoGad;
       _situacaoGadOriginalCommited = _situacaoGadOriginal;
       _situacaoGadMensagemOriginal = SituacaoGadMensagem;
       _situacaoGadMensagemOriginalCommited = _situacaoGadMensagemOriginal;
       _tentativasEnvioOriginal = TentativasEnvio;
       _tentativasEnvioOriginalCommited = _tentativasEnvioOriginal;

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
       _nomeOriginalCommited = Nome;
       _dataCriacaoOriginalCommited = DataCriacao;
       _acsUsuarioCriacaoOriginalCommited = AcsUsuarioCriacao;
       _versionOriginalCommited = Version;
       _programacaoGadIdOriginalCommited = ProgramacaoGadId;
       _situacaoGadOriginalCommited = SituacaoGad;
       _situacaoGadMensagemOriginalCommited = SituacaoGadMensagem;
       _tentativasEnvioOriginalCommited = TentativasEnvio;

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
               if (_valueCollectionPedidoItemClassProgramacaoLoaded) 
               {
                  if (_collectionPedidoItemClassProgramacaoRemovidos != null) 
                  {
                     _collectionPedidoItemClassProgramacaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassProgramacaoRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassProgramacaoOriginal= (from a in _valueCollectionPedidoItemClassProgramacao select a.ID).ToList();
                  _valueCollectionPedidoItemClassProgramacaoChanged = false;
                  _valueCollectionPedidoItemClassProgramacaoCommitedChanged = false;
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
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               DataCriacao=_dataCriacaoOriginal;
               _dataCriacaoOriginalCommited=_dataCriacaoOriginal;
               AcsUsuarioCriacao=_acsUsuarioCriacaoOriginal;
               _acsUsuarioCriacaoOriginalCommited=_acsUsuarioCriacaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ProgramacaoGadId=_programacaoGadIdOriginal;
               _programacaoGadIdOriginalCommited=_programacaoGadIdOriginal;
               SituacaoGad=_situacaoGadOriginal;
               _situacaoGadOriginalCommited=_situacaoGadOriginal;
               SituacaoGadMensagem=_situacaoGadMensagemOriginal;
               _situacaoGadMensagemOriginalCommited=_situacaoGadMensagemOriginal;
               TentativasEnvio=_tentativasEnvioOriginal;
               _tentativasEnvioOriginalCommited=_tentativasEnvioOriginal;
               if (_valueCollectionPedidoItemClassProgramacaoLoaded) 
               {
                  CollectionPedidoItemClassProgramacao.Clear();
                  foreach(int item in _collectionPedidoItemClassProgramacaoOriginal)
                  {
                    CollectionPedidoItemClassProgramacao.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassProgramacaoRemovidos.Clear();
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
               if (_valueCollectionPedidoItemClassProgramacaoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassProgramacaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassProgramacaoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassProgramacao.Any(item => item.IsDirty());
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
       dirty = _nomeOriginal != Nome;
      if (dirty) return true;
       dirty = _dataCriacaoOriginal != DataCriacao;
      if (dirty) return true;
       if (_acsUsuarioCriacaoOriginal!=null)
       {
          dirty = !_acsUsuarioCriacaoOriginal.Equals(AcsUsuarioCriacao);
       }
       else
       {
            dirty = AcsUsuarioCriacao != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _programacaoGadIdOriginal != ProgramacaoGadId;
      if (dirty) return true;
       dirty = _situacaoGadOriginal != SituacaoGad;
      if (dirty) return true;
       dirty = _situacaoGadMensagemOriginal != SituacaoGadMensagem;
      if (dirty) return true;
       dirty = _tentativasEnvioOriginal != TentativasEnvio;

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
               if (_valueCollectionPedidoItemClassProgramacaoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassProgramacaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassProgramacaoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassProgramacao.Any(item => item.IsDirtyCommited());
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
       dirty = _nomeOriginalCommited != Nome;
      if (dirty) return true;
       dirty = _dataCriacaoOriginalCommited != DataCriacao;
      if (dirty) return true;
       if (_acsUsuarioCriacaoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioCriacaoOriginalCommited.Equals(AcsUsuarioCriacao);
       }
       else
       {
            dirty = AcsUsuarioCriacao != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _programacaoGadIdOriginalCommited != ProgramacaoGadId;
      if (dirty) return true;
       dirty = _situacaoGadOriginalCommited != SituacaoGad;
      if (dirty) return true;
       dirty = _situacaoGadMensagemOriginalCommited != SituacaoGadMensagem;
      if (dirty) return true;
       dirty = _tentativasEnvioOriginalCommited != TentativasEnvio;

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
               if (_valueCollectionPedidoItemClassProgramacaoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassProgramacao)
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
             case "Nome":
                return this.Nome;
             case "DataCriacao":
                return this.DataCriacao;
             case "AcsUsuarioCriacao":
                return this.AcsUsuarioCriacao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ProgramacaoGadId":
                return this.ProgramacaoGadId;
             case "SituacaoGad":
                return this.SituacaoGad;
             case "SituacaoGadMensagem":
                return this.SituacaoGadMensagem;
             case "TentativasEnvio":
                return this.TentativasEnvio;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (AcsUsuarioCriacao!=null)
                AcsUsuarioCriacao.ChangeSingleConnection(newConnection);
               if (_valueCollectionPedidoItemClassProgramacaoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassProgramacao)
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
                  command.CommandText += " COUNT(programacao.id_programacao) " ;
               }
               else
               {
               command.CommandText += "programacao.id_programacao, " ;
               command.CommandText += "programacao.prg_nome, " ;
               command.CommandText += "programacao.prg_data_criacao, " ;
               command.CommandText += "programacao.id_acs_usuario_criacao, " ;
               command.CommandText += "programacao.entity_uid, " ;
               command.CommandText += "programacao.version, " ;
               command.CommandText += "programacao.prg_programacao_gad_id, " ;
               command.CommandText += "programacao.prg_situacao_gad, " ;
               command.CommandText += "programacao.prg_situacao_gad_mensagem, " ;
               command.CommandText += "programacao.prg_tentativas_envio " ;
               }
               command.CommandText += " FROM  programacao ";
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
                        orderByClause += " , prg_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(prg_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = programacao.id_acs_usuario_ultima_revisao ";
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
                     case "id_programacao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , programacao.id_programacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(programacao.id_programacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prg_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , programacao.prg_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(programacao.prg_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prg_data_criacao":
                     case "DataCriacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , programacao.prg_data_criacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(programacao.prg_data_criacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_criacao":
                     case "AcsUsuarioCriacao":
                     orderByClause += " , programacao.id_acs_usuario_criacao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , programacao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(programacao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , programacao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(programacao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prg_programacao_gad_id":
                     case "ProgramacaoGadId":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , programacao.prg_programacao_gad_id " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(programacao.prg_programacao_gad_id) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prg_situacao_gad":
                     case "SituacaoGad":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , programacao.prg_situacao_gad " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(programacao.prg_situacao_gad) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prg_situacao_gad_mensagem":
                     case "SituacaoGadMensagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , programacao.prg_situacao_gad_mensagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(programacao.prg_situacao_gad_mensagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prg_tentativas_envio":
                     case "TentativasEnvio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , programacao.prg_tentativas_envio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(programacao.prg_tentativas_envio) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prg_nome")) 
                        {
                           whereClause += " OR UPPER(programacao.prg_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(programacao.prg_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(programacao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(programacao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prg_situacao_gad_mensagem")) 
                        {
                           whereClause += " OR UPPER(programacao.prg_situacao_gad_mensagem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(programacao.prg_situacao_gad_mensagem) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_programacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.id_programacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.id_programacao = :programacao_ID_2191 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_ID_2191", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "prg_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.prg_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.prg_nome LIKE :programacao_Nome_5680 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_Nome_5680", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCriacao" || parametro.FieldName == "prg_data_criacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.prg_data_criacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.prg_data_criacao = :programacao_DataCriacao_11 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_DataCriacao_11", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioCriacao" || parametro.FieldName == "id_acs_usuario_criacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.id_acs_usuario_criacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.id_acs_usuario_criacao = :programacao_AcsUsuarioCriacao_1761 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_AcsUsuarioCriacao_1761", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  programacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.entity_uid LIKE :programacao_EntityUid_6414 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_EntityUid_6414", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  programacao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.version = :programacao_Version_7692 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_Version_7692", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProgramacaoGadId" || parametro.FieldName == "prg_programacao_gad_id")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.prg_programacao_gad_id IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.prg_programacao_gad_id = :programacao_ProgramacaoGadId_1408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_ProgramacaoGadId_1408", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoGad" || parametro.FieldName == "prg_situacao_gad")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is GadIntegracaoProgramacaoSituacao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo GadIntegracaoProgramacaoSituacao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.prg_situacao_gad IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.prg_situacao_gad = :programacao_SituacaoGad_7862 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_SituacaoGad_7862", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoGadMensagem" || parametro.FieldName == "prg_situacao_gad_mensagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.prg_situacao_gad_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.prg_situacao_gad_mensagem LIKE :programacao_SituacaoGadMensagem_8427 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_SituacaoGadMensagem_8427", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TentativasEnvio" || parametro.FieldName == "prg_tentativas_envio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.prg_tentativas_envio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.prg_tentativas_envio = :programacao_TentativasEnvio_3797 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_TentativasEnvio_3797", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeExato" || parametro.FieldName == "NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.prg_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.prg_nome LIKE :programacao_Nome_7323 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_Nome_7323", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  programacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.entity_uid LIKE :programacao_EntityUid_8634 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_EntityUid_8634", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoGadMensagemExato" || parametro.FieldName == "SituacaoGadMensagemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  programacao.prg_situacao_gad_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  programacao.prg_situacao_gad_mensagem LIKE :programacao_SituacaoGadMensagem_8663 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("programacao_SituacaoGadMensagem_8663", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProgramacaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProgramacaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProgramacaoClass), Convert.ToInt32(read["id_programacao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProgramacaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_programacao"]);
                     entidade.Nome = (read["prg_nome"] != DBNull.Value ? read["prg_nome"].ToString() : null);
                     entidade.DataCriacao = (DateTime)read["prg_data_criacao"];
                     if (read["id_acs_usuario_criacao"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioCriacao = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_criacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioCriacao = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ProgramacaoGadId = read["prg_programacao_gad_id"] as int?;
                     entidade.SituacaoGad = (GadIntegracaoProgramacaoSituacao) (read["prg_situacao_gad"] != DBNull.Value ? Enum.ToObject(typeof(GadIntegracaoProgramacaoSituacao), read["prg_situacao_gad"]) : null);
                     entidade.SituacaoGadMensagem = (read["prg_situacao_gad_mensagem"] != DBNull.Value ? read["prg_situacao_gad_mensagem"].ToString() : null);
                     entidade.TentativasEnvio = (short)read["prg_tentativas_envio"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProgramacaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
