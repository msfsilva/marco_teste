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
     [Table("budget","bud")]
     public class BudgetBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do BudgetClass";
protected const string ErroDelete = "Erro ao excluir o BudgetClass  ";
protected const string ErroSave = "Erro ao salvar o BudgetClass.";
protected const string ErroCollectionBudgetLinhaClassBudget = "Erro ao carregar a coleção de BudgetLinhaClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroAcsUsuarioCriadorObrigatorio = "O campo AcsUsuarioCriador é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do BudgetClass.";
protected const string MensagemUtilizadoCollectionBudgetLinhaClassBudget =  "A entidade BudgetClass está sendo utilizada nos seguintes BudgetLinhaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade BudgetClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("bud_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected int _anoOriginal{get;private set;}
       private int _anoOriginalCommited{get; set;}
        private int _valueAno;
         [Column("bud_ano")]
        public virtual int Ano
         { 
            get { return this._valueAno; } 
            set 
            { 
                if (this._valueAno == value)return;
                 this._valueAno = value; 
            } 
        } 

       protected int _ativoOriginal{get;private set;}
       private int _ativoOriginalCommited{get; set;}
        private int _valueAtivo;
         [Column("bud_ativo")]
        public virtual int Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCriadorOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCriadorOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioCriador;
        [Column("id_acs_usuario_criador", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioCriador
        { 
           get {                 return this._valueAcsUsuarioCriador; } 
           set 
           { 
                if (this._valueAcsUsuarioCriador == value)return;
                 this._valueAcsUsuarioCriador = value; 
           } 
       } 

       protected DateTime _dataCriacaoOriginal{get;private set;}
       private DateTime _dataCriacaoOriginalCommited{get; set;}
        private DateTime _valueDataCriacao;
         [Column("bud_data_criacao")]
        public virtual DateTime DataCriacao
         { 
            get { return this._valueDataCriacao; } 
            set 
            { 
                if (this._valueDataCriacao == value)return;
                 this._valueDataCriacao = value; 
            } 
        } 

       protected EasiSituacaoBudget _situacaoOriginal{get;private set;}
       private EasiSituacaoBudget _situacaoOriginalCommited{get; set;}
        private EasiSituacaoBudget _valueSituacao;
         [Column("bud_situacao")]
        public virtual EasiSituacaoBudget Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

        public bool Situacao_EmElaboracao
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.EasiSituacaoBudget.EmElaboracao; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.EasiSituacaoBudget.EmElaboracao; }
         } 

        public bool Situacao_Aprovado
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.EasiSituacaoBudget.Aprovado; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.EasiSituacaoBudget.Aprovado; }
         } 

        public bool Situacao_EmRevisao
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.EasiSituacaoBudget.EmRevisao; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.EasiSituacaoBudget.EmRevisao; }
         } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioAprovacaoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioAprovacaoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioAprovacao;
        [Column("id_acs_usuario_aprovacao", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioAprovacao
        { 
           get {                 return this._valueAcsUsuarioAprovacao; } 
           set 
           { 
                if (this._valueAcsUsuarioAprovacao == value)return;
                 this._valueAcsUsuarioAprovacao = value; 
           } 
       } 

       protected DateTime? _dataAprovacaoOriginal{get;private set;}
       private DateTime? _dataAprovacaoOriginalCommited{get; set;}
        private DateTime? _valueDataAprovacao;
         [Column("bud_data_aprovacao")]
        public virtual DateTime? DataAprovacao
         { 
            get { return this._valueDataAprovacao; } 
            set 
            { 
                if (this._valueDataAprovacao == value)return;
                 this._valueDataAprovacao = value; 
            } 
        } 

       protected string _justificativaRevisaoOriginal{get;private set;}
       private string _justificativaRevisaoOriginalCommited{get; set;}
        private string _valueJustificativaRevisao;
         [Column("bud_justificativa_revisao")]
        public virtual string JustificativaRevisao
         { 
            get { return this._valueJustificativaRevisao; } 
            set 
            { 
                if (this._valueJustificativaRevisao == value)return;
                 this._valueJustificativaRevisao = value; 
            } 
        } 

       private List<long> _collectionBudgetLinhaClassBudgetOriginal;
       private List<Entidades.BudgetLinhaClass > _collectionBudgetLinhaClassBudgetRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBudgetLinhaClassBudgetLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBudgetLinhaClassBudgetChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBudgetLinhaClassBudgetCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.BudgetLinhaClass> _valueCollectionBudgetLinhaClassBudget { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.BudgetLinhaClass> CollectionBudgetLinhaClassBudget 
       { 
           get { if(!_valueCollectionBudgetLinhaClassBudgetLoaded && !this.DisableLoadCollection){this.LoadCollectionBudgetLinhaClassBudget();}
return this._valueCollectionBudgetLinhaClassBudget; } 
           set 
           { 
               this._valueCollectionBudgetLinhaClassBudget = value; 
               this._valueCollectionBudgetLinhaClassBudgetLoaded = true; 
           } 
       } 

        public BudgetBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Ativo = 1;
           this.DataCriacao = Configurations.DataIndependenteClass.GetData();
           this.Situacao = (EasiSituacaoBudget)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static BudgetClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (BudgetClass) GetEntity(typeof(BudgetClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionBudgetLinhaClassBudgetChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionBudgetLinhaClassBudgetChanged = true;
                  _valueCollectionBudgetLinhaClassBudgetCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionBudgetLinhaClassBudgetChanged = true; 
                  _valueCollectionBudgetLinhaClassBudgetCommitedChanged = true;
                 foreach (Entidades.BudgetLinhaClass item in e.OldItems) 
                 { 
                     _collectionBudgetLinhaClassBudgetRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionBudgetLinhaClassBudgetChanged = true; 
                  _valueCollectionBudgetLinhaClassBudgetCommitedChanged = true;
                 foreach (Entidades.BudgetLinhaClass item in _valueCollectionBudgetLinhaClassBudget) 
                 { 
                     _collectionBudgetLinhaClassBudgetRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionBudgetLinhaClassBudget()
         {
            try
            {
                 ObservableCollection<Entidades.BudgetLinhaClass> oc;
                _valueCollectionBudgetLinhaClassBudgetChanged = false;
                 _valueCollectionBudgetLinhaClassBudgetCommitedChanged = false;
                _collectionBudgetLinhaClassBudgetRemovidos = new List<Entidades.BudgetLinhaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.BudgetLinhaClass>();
                }
                else{ 
                   Entidades.BudgetLinhaClass search = new Entidades.BudgetLinhaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.BudgetLinhaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Budget", this),                     }                       ).Cast<Entidades.BudgetLinhaClass>().ToList());
                 }
                 _valueCollectionBudgetLinhaClassBudget = new BindingList<Entidades.BudgetLinhaClass>(oc); 
                 _collectionBudgetLinhaClassBudgetOriginal= (from a in _valueCollectionBudgetLinhaClassBudget select a.ID).ToList();
                 _valueCollectionBudgetLinhaClassBudgetLoaded = true;
                 oc.CollectionChanged += CollectionBudgetLinhaClassBudgetChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionBudgetLinhaClassBudget+"\r\n" + e.Message, e);
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
                if ( _valueAcsUsuarioCriador == null)
                {
                    throw new Exception(ErroAcsUsuarioCriadorObrigatorio);
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
                    "  public.budget  " +
                    "WHERE " +
                    "  id_budget = :id";
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
                        "  public.budget   " +
                        "SET  " + 
                        "  bud_identificacao = :bud_identificacao, " + 
                        "  bud_ano = :bud_ano, " + 
                        "  bud_ativo = :bud_ativo, " + 
                        "  id_acs_usuario_criador = :id_acs_usuario_criador, " + 
                        "  bud_data_criacao = :bud_data_criacao, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  bud_ultima_revisao = :bud_ultima_revisao, " + 
                        "  bud_ultima_revisao_data = :bud_ultima_revisao_data, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  bud_situacao = :bud_situacao, " + 
                        "  id_acs_usuario_aprovacao = :id_acs_usuario_aprovacao, " + 
                        "  bud_data_aprovacao = :bud_data_aprovacao, " + 
                        "  bud_justificativa_revisao = :bud_justificativa_revisao "+
                        "WHERE  " +
                        "  id_budget = :id " +
                        "RETURNING id_budget;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.budget " +
                        "( " +
                        "  bud_identificacao , " + 
                        "  bud_ano , " + 
                        "  bud_ativo , " + 
                        "  id_acs_usuario_criador , " + 
                        "  bud_data_criacao , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  bud_ultima_revisao , " + 
                        "  bud_ultima_revisao_data , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  bud_situacao , " + 
                        "  id_acs_usuario_aprovacao , " + 
                        "  bud_data_aprovacao , " + 
                        "  bud_justificativa_revisao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :bud_identificacao , " + 
                        "  :bud_ano , " + 
                        "  :bud_ativo , " + 
                        "  :id_acs_usuario_criador , " + 
                        "  :bud_data_criacao , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :bud_ultima_revisao , " + 
                        "  :bud_ultima_revisao_data , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :bud_situacao , " + 
                        "  :id_acs_usuario_aprovacao , " + 
                        "  :bud_data_aprovacao , " + 
                        "  :bud_justificativa_revisao  "+
                        ")RETURNING id_budget;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bud_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bud_ano", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ano ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bud_ativo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_criador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioCriador==null ? (object) DBNull.Value : this.AcsUsuarioCriador.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bud_data_criacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCriacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bud_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bud_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bud_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Situacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_aprovacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioAprovacao==null ? (object) DBNull.Value : this.AcsUsuarioAprovacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bud_data_aprovacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAprovacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bud_justificativa_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JustificativaRevisao ?? DBNull.Value;

 
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
 if (CollectionBudgetLinhaClassBudget.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionBudgetLinhaClassBudget+"\r\n";
                foreach (Entidades.BudgetLinhaClass tmp in CollectionBudgetLinhaClassBudget)
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
        public static BudgetClass CopiarEntidade(BudgetClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               BudgetClass toRet = new BudgetClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Ano= entidadeCopiar.Ano;
 toRet.Ativo= entidadeCopiar.Ativo;
 toRet.AcsUsuarioCriador= entidadeCopiar.AcsUsuarioCriador;
 toRet.DataCriacao= entidadeCopiar.DataCriacao;
 toRet.Situacao= entidadeCopiar.Situacao;
 toRet.AcsUsuarioAprovacao= entidadeCopiar.AcsUsuarioAprovacao;
 toRet.DataAprovacao= entidadeCopiar.DataAprovacao;
 toRet.JustificativaRevisao= entidadeCopiar.JustificativaRevisao;

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
       _anoOriginal = Ano;
       _anoOriginalCommited = _anoOriginal;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;
       _acsUsuarioCriadorOriginal = AcsUsuarioCriador;
       _acsUsuarioCriadorOriginalCommited = _acsUsuarioCriadorOriginal;
       _dataCriacaoOriginal = DataCriacao;
       _dataCriacaoOriginalCommited = _dataCriacaoOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _situacaoOriginal = Situacao;
       _situacaoOriginalCommited = _situacaoOriginal;
       _acsUsuarioAprovacaoOriginal = AcsUsuarioAprovacao;
       _acsUsuarioAprovacaoOriginalCommited = _acsUsuarioAprovacaoOriginal;
       _dataAprovacaoOriginal = DataAprovacao;
       _dataAprovacaoOriginalCommited = _dataAprovacaoOriginal;
       _justificativaRevisaoOriginal = JustificativaRevisao;
       _justificativaRevisaoOriginalCommited = _justificativaRevisaoOriginal;

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
       _anoOriginalCommited = Ano;
       _ativoOriginalCommited = Ativo;
       _acsUsuarioCriadorOriginalCommited = AcsUsuarioCriador;
       _dataCriacaoOriginalCommited = DataCriacao;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;
       _situacaoOriginalCommited = Situacao;
       _acsUsuarioAprovacaoOriginalCommited = AcsUsuarioAprovacao;
       _dataAprovacaoOriginalCommited = DataAprovacao;
       _justificativaRevisaoOriginalCommited = JustificativaRevisao;

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
               if (_valueCollectionBudgetLinhaClassBudgetLoaded) 
               {
                  if (_collectionBudgetLinhaClassBudgetRemovidos != null) 
                  {
                     _collectionBudgetLinhaClassBudgetRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionBudgetLinhaClassBudgetRemovidos = new List<Entidades.BudgetLinhaClass>();
                  }
                  _collectionBudgetLinhaClassBudgetOriginal= (from a in _valueCollectionBudgetLinhaClassBudget select a.ID).ToList();
                  _valueCollectionBudgetLinhaClassBudgetChanged = false;
                  _valueCollectionBudgetLinhaClassBudgetCommitedChanged = false;
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
               Ano=_anoOriginal;
               _anoOriginalCommited=_anoOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               AcsUsuarioCriador=_acsUsuarioCriadorOriginal;
               _acsUsuarioCriadorOriginalCommited=_acsUsuarioCriadorOriginal;
               DataCriacao=_dataCriacaoOriginal;
               _dataCriacaoOriginalCommited=_dataCriacaoOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               AcsUsuarioAprovacao=_acsUsuarioAprovacaoOriginal;
               _acsUsuarioAprovacaoOriginalCommited=_acsUsuarioAprovacaoOriginal;
               DataAprovacao=_dataAprovacaoOriginal;
               _dataAprovacaoOriginalCommited=_dataAprovacaoOriginal;
               JustificativaRevisao=_justificativaRevisaoOriginal;
               _justificativaRevisaoOriginalCommited=_justificativaRevisaoOriginal;
               if (_valueCollectionBudgetLinhaClassBudgetLoaded) 
               {
                  CollectionBudgetLinhaClassBudget.Clear();
                  foreach(int item in _collectionBudgetLinhaClassBudgetOriginal)
                  {
                    CollectionBudgetLinhaClassBudget.Add(Entidades.BudgetLinhaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionBudgetLinhaClassBudgetRemovidos.Clear();
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
               if (_valueCollectionBudgetLinhaClassBudgetLoaded) 
               {
                  if (_valueCollectionBudgetLinhaClassBudgetChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionBudgetLinhaClassBudgetLoaded) 
               {
                   tempRet = CollectionBudgetLinhaClassBudget.Any(item => item.IsDirty());
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
       dirty = _anoOriginal != Ano;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;
      if (dirty) return true;
       if (_acsUsuarioCriadorOriginal!=null)
       {
          dirty = !_acsUsuarioCriadorOriginal.Equals(AcsUsuarioCriador);
       }
       else
       {
            dirty = AcsUsuarioCriador != null;
       }
      if (dirty) return true;
       dirty = _dataCriacaoOriginal != DataCriacao;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _situacaoOriginal != Situacao;
      if (dirty) return true;
       if (_acsUsuarioAprovacaoOriginal!=null)
       {
          dirty = !_acsUsuarioAprovacaoOriginal.Equals(AcsUsuarioAprovacao);
       }
       else
       {
            dirty = AcsUsuarioAprovacao != null;
       }
      if (dirty) return true;
       dirty = _dataAprovacaoOriginal != DataAprovacao;
      if (dirty) return true;
       dirty = _justificativaRevisaoOriginal != JustificativaRevisao;

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
               if (_valueCollectionBudgetLinhaClassBudgetLoaded) 
               {
                  if (_valueCollectionBudgetLinhaClassBudgetCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionBudgetLinhaClassBudgetLoaded) 
               {
                   tempRet = CollectionBudgetLinhaClassBudget.Any(item => item.IsDirtyCommited());
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
       dirty = _anoOriginalCommited != Ano;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;
      if (dirty) return true;
       if (_acsUsuarioCriadorOriginalCommited!=null)
       {
          dirty = !_acsUsuarioCriadorOriginalCommited.Equals(AcsUsuarioCriador);
       }
       else
       {
            dirty = AcsUsuarioCriador != null;
       }
      if (dirty) return true;
       dirty = _dataCriacaoOriginalCommited != DataCriacao;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _situacaoOriginalCommited != Situacao;
      if (dirty) return true;
       if (_acsUsuarioAprovacaoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioAprovacaoOriginalCommited.Equals(AcsUsuarioAprovacao);
       }
       else
       {
            dirty = AcsUsuarioAprovacao != null;
       }
      if (dirty) return true;
       dirty = _dataAprovacaoOriginalCommited != DataAprovacao;
      if (dirty) return true;
       dirty = _justificativaRevisaoOriginalCommited != JustificativaRevisao;

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
               if (_valueCollectionBudgetLinhaClassBudgetLoaded) 
               {
                  foreach(BudgetLinhaClass item in CollectionBudgetLinhaClassBudget)
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
             case "Ano":
                return this.Ano;
             case "Ativo":
                return this.Ativo;
             case "AcsUsuarioCriador":
                return this.AcsUsuarioCriador;
             case "DataCriacao":
                return this.DataCriacao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Situacao":
                return this.Situacao;
             case "AcsUsuarioAprovacao":
                return this.AcsUsuarioAprovacao;
             case "DataAprovacao":
                return this.DataAprovacao;
             case "JustificativaRevisao":
                return this.JustificativaRevisao;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (AcsUsuarioCriador!=null)
                AcsUsuarioCriador.ChangeSingleConnection(newConnection);
             if (AcsUsuarioAprovacao!=null)
                AcsUsuarioAprovacao.ChangeSingleConnection(newConnection);
               if (_valueCollectionBudgetLinhaClassBudgetLoaded) 
               {
                  foreach(BudgetLinhaClass item in CollectionBudgetLinhaClassBudget)
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
                  command.CommandText += " COUNT(budget.id_budget) " ;
               }
               else
               {
               command.CommandText += "budget.id_budget, " ;
               command.CommandText += "budget.bud_identificacao, " ;
               command.CommandText += "budget.bud_ano, " ;
               command.CommandText += "budget.bud_ativo, " ;
               command.CommandText += "budget.id_acs_usuario_criador, " ;
               command.CommandText += "budget.bud_data_criacao, " ;
               command.CommandText += "budget.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "budget.bud_ultima_revisao, " ;
               command.CommandText += "budget.bud_ultima_revisao_data, " ;
               command.CommandText += "budget.entity_uid, " ;
               command.CommandText += "budget.version, " ;
               command.CommandText += "budget.bud_situacao, " ;
               command.CommandText += "budget.id_acs_usuario_aprovacao, " ;
               command.CommandText += "budget.bud_data_aprovacao, " ;
               command.CommandText += "budget.bud_justificativa_revisao " ;
               }
               command.CommandText += " FROM  budget ";
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
                        orderByClause += " , bud_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(bud_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = budget.id_acs_usuario_ultima_revisao ";
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
                     case "id_budget":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , budget.id_budget " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget.id_budget) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bud_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , budget.bud_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(budget.bud_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bud_ano":
                     case "Ano":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , budget.bud_ano " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget.bud_ano) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bud_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , budget.bud_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget.bud_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_criador":
                     case "AcsUsuarioCriador":
                     orderByClause += " , budget.id_acs_usuario_criador " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "bud_data_criacao":
                     case "DataCriacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , budget.bud_data_criacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget.bud_data_criacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , budget.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "bud_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , budget.bud_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(budget.bud_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bud_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , budget.bud_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget.bud_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , budget.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(budget.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , budget.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bud_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , budget.bud_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget.bud_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_aprovacao":
                     case "AcsUsuarioAprovacao":
                     orderByClause += " , budget.id_acs_usuario_aprovacao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "bud_data_aprovacao":
                     case "DataAprovacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , budget.bud_data_aprovacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget.bud_data_aprovacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bud_justificativa_revisao":
                     case "JustificativaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , budget.bud_justificativa_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(budget.bud_justificativa_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bud_identificacao")) 
                        {
                           whereClause += " OR UPPER(budget.bud_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(budget.bud_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bud_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(budget.bud_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(budget.bud_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(budget.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(budget.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bud_justificativa_revisao")) 
                        {
                           whereClause += " OR UPPER(budget.bud_justificativa_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(budget.bud_justificativa_revisao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_budget")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.id_budget IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.id_budget = :budget_ID_1602 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_ID_1602", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "bud_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_identificacao LIKE :budget_Identificacao_973 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_Identificacao_973", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ano" || parametro.FieldName == "bud_ano")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_ano IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_ano = :budget_Ano_2750 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_Ano_2750", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "bud_ativo")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_ativo = :budget_Ativo_356 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_Ativo_356", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioCriador" || parametro.FieldName == "id_acs_usuario_criador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.id_acs_usuario_criador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.id_acs_usuario_criador = :budget_AcsUsuarioCriador_7168 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_AcsUsuarioCriador_7168", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCriacao" || parametro.FieldName == "bud_data_criacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_data_criacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_data_criacao = :budget_DataCriacao_6802 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_DataCriacao_6802", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  budget.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.id_acs_usuario_ultima_revisao = :budget_UltimaRevisaoUsuario_7725 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_UltimaRevisaoUsuario_7725", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "bud_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_ultima_revisao LIKE :budget_UltimaRevisao_9952 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_UltimaRevisao_9952", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "bud_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_ultima_revisao_data = :budget_UltimaRevisaoData_9274 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_UltimaRevisaoData_9274", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  budget.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.entity_uid LIKE :budget_EntityUid_6238 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_EntityUid_6238", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  budget.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.version = :budget_Version_8958 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_Version_8958", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "bud_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EasiSituacaoBudget)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EasiSituacaoBudget");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_situacao = :budget_Situacao_5442 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_Situacao_5442", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioAprovacao" || parametro.FieldName == "id_acs_usuario_aprovacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.id_acs_usuario_aprovacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.id_acs_usuario_aprovacao = :budget_AcsUsuarioAprovacao_2834 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_AcsUsuarioAprovacao_2834", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAprovacao" || parametro.FieldName == "bud_data_aprovacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_data_aprovacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_data_aprovacao = :budget_DataAprovacao_6883 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_DataAprovacao_6883", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaRevisao" || parametro.FieldName == "bud_justificativa_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_justificativa_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_justificativa_revisao LIKE :budget_JustificativaRevisao_2222 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_JustificativaRevisao_2222", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  budget.bud_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_identificacao LIKE :budget_Identificacao_9264 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_Identificacao_9264", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  budget.bud_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_ultima_revisao LIKE :budget_UltimaRevisao_8018 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_UltimaRevisao_8018", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  budget.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.entity_uid LIKE :budget_EntityUid_2992 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_EntityUid_2992", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaRevisaoExato" || parametro.FieldName == "JustificativaRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget.bud_justificativa_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget.bud_justificativa_revisao LIKE :budget_JustificativaRevisao_7897 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_JustificativaRevisao_7897", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  BudgetClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (BudgetClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(BudgetClass), Convert.ToInt32(read["id_budget"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new BudgetClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_budget"]);
                     entidade.Identificacao = (read["bud_identificacao"] != DBNull.Value ? read["bud_identificacao"].ToString() : null);
                     entidade.Ano = (int)read["bud_ano"];
                     entidade.Ativo = (int)read["bud_ativo"];
                     if (read["id_acs_usuario_criador"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioCriador = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_criador"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioCriador = null ;
                     }
                     entidade.DataCriacao = (DateTime)read["bud_data_criacao"];
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.UltimaRevisao = (read["bud_ultima_revisao"] != DBNull.Value ? read["bud_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["bud_ultima_revisao_data"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Situacao = (EasiSituacaoBudget) (read["bud_situacao"] != DBNull.Value ? Enum.ToObject(typeof(EasiSituacaoBudget), read["bud_situacao"]) : null);
                     if (read["id_acs_usuario_aprovacao"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioAprovacao = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_aprovacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioAprovacao = null ;
                     }
                     entidade.DataAprovacao = read["bud_data_aprovacao"] as DateTime?;
                     entidade.JustificativaRevisao = (read["bud_justificativa_revisao"] != DBNull.Value ? read["bud_justificativa_revisao"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (BudgetClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
