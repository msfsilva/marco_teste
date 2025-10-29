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
     [Table("ordem_producao_posto_trabalho_producao","opo")]
     public class OrdemProducaoPostoTrabalhoProducaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoPostoTrabalhoProducaoClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoPostoTrabalhoProducaoClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoPostoTrabalhoProducaoClass.";
protected const string ErroCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoProducaoLoteClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemProducaoPostoTrabalhoObrigatorio = "O campo OrdemProducaoPostoTrabalho é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoPostoTrabalhoProducaoClass.";
protected const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao =  "A entidade OrdemProducaoPostoTrabalhoProducaoClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoProducaoLoteClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoPostoTrabalhoProducaoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass _ordemProducaoPostoTrabalhoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass _ordemProducaoPostoTrabalhoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass _valueOrdemProducaoPostoTrabalho;
        [Column("id_ordem_producao_posto_trabalho", "ordem_producao_posto_trabalho", "id_ordem_producao_posto_trabalho")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass OrdemProducaoPostoTrabalho
        { 
           get {                 return this._valueOrdemProducaoPostoTrabalho; } 
           set 
           { 
                if (this._valueOrdemProducaoPostoTrabalho == value)return;
                 this._valueOrdemProducaoPostoTrabalho = value; 
           } 
       } 

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

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("opo_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected DateTime _dataHoraOriginal{get;private set;}
       private DateTime _dataHoraOriginalCommited{get; set;}
        private DateTime _valueDataHora;
         [Column("opo_data_hora")]
        public virtual DateTime DataHora
         { 
            get { return this._valueDataHora; } 
            set 
            { 
                if (this._valueDataHora == value)return;
                 this._valueDataHora = value; 
            } 
        } 

       protected bool _encerradaOriginal{get;private set;}
       private bool _encerradaOriginalCommited{get; set;}
        private bool _valueEncerrada;
         [Column("opo_encerrada")]
        public virtual bool Encerrada
         { 
            get { return this._valueEncerrada; } 
            set 
            { 
                if (this._valueEncerrada == value)return;
                 this._valueEncerrada = value; 
            } 
        } 

       protected DateTime? _dataHoraFimOriginal{get;private set;}
       private DateTime? _dataHoraFimOriginalCommited{get; set;}
        private DateTime? _valueDataHoraFim;
         [Column("opo_data_hora_fim")]
        public virtual DateTime? DataHoraFim
         { 
            get { return this._valueDataHoraFim; } 
            set 
            { 
                if (this._valueDataHoraFim == value)return;
                 this._valueDataHoraFim = value; 
            } 
        } 

       private List<long> _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoOriginal;
       private List<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass > _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass> _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass> CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao();}
return this._valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao = value; 
               this._valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded = true; 
           } 
       } 

        public OrdemProducaoPostoTrabalhoProducaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.DataHora = Configurations.DataIndependenteClass.GetData();
           this.Encerrada = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoPostoTrabalhoProducaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoPostoTrabalhoProducaoClass) GetEntity(typeof(OrdemProducaoPostoTrabalhoProducaoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoChanged = true;
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass item in _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass> oc;
                _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoChanged = false;
                 _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoCommitedChanged = false;
                _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>();
                }
                else{ 
                   Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass search = new Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducaoPostoTrabalhoProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao = new BindingList<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>(oc); 
                 _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueOrdemProducaoPostoTrabalho == null)
                {
                    throw new Exception(ErroOrdemProducaoPostoTrabalhoObrigatorio);
                }
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
                    "  public.ordem_producao_posto_trabalho_producao  " +
                    "WHERE " +
                    "  id_ordem_producao_posto_trabalho_producao = :id";
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
                        "  public.ordem_producao_posto_trabalho_producao   " +
                        "SET  " + 
                        "  id_ordem_producao_posto_trabalho = :id_ordem_producao_posto_trabalho, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  opo_quantidade = :opo_quantidade, " + 
                        "  opo_data_hora = :opo_data_hora, " + 
                        "  opo_encerrada = :opo_encerrada, " + 
                        "  opo_data_hora_fim = :opo_data_hora_fim, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_posto_trabalho_producao = :id " +
                        "RETURNING id_ordem_producao_posto_trabalho_producao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_posto_trabalho_producao " +
                        "( " +
                        "  id_ordem_producao_posto_trabalho , " + 
                        "  id_acs_usuario , " + 
                        "  opo_quantidade , " + 
                        "  opo_data_hora , " + 
                        "  opo_encerrada , " + 
                        "  opo_data_hora_fim , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao_posto_trabalho , " + 
                        "  :id_acs_usuario , " + 
                        "  :opo_quantidade , " + 
                        "  :opo_data_hora , " + 
                        "  :opo_encerrada , " + 
                        "  :opo_data_hora_fim , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_posto_trabalho_producao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducaoPostoTrabalho==null ? (object) DBNull.Value : this.OrdemProducaoPostoTrabalho.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opo_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opo_data_hora", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataHora ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opo_encerrada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Encerrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opo_data_hora_fim", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataHoraFim ?? DBNull.Value;
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
 if (CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao+"\r\n";
                foreach (Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass tmp in CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao)
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
        public static OrdemProducaoPostoTrabalhoProducaoClass CopiarEntidade(OrdemProducaoPostoTrabalhoProducaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoPostoTrabalhoProducaoClass toRet = new OrdemProducaoPostoTrabalhoProducaoClass(usuario,conn);
 toRet.OrdemProducaoPostoTrabalho= entidadeCopiar.OrdemProducaoPostoTrabalho;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.DataHora= entidadeCopiar.DataHora;
 toRet.Encerrada= entidadeCopiar.Encerrada;
 toRet.DataHoraFim= entidadeCopiar.DataHoraFim;

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
       _ordemProducaoPostoTrabalhoOriginal = OrdemProducaoPostoTrabalho;
       _ordemProducaoPostoTrabalhoOriginalCommited = _ordemProducaoPostoTrabalhoOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _dataHoraOriginal = DataHora;
       _dataHoraOriginalCommited = _dataHoraOriginal;
       _encerradaOriginal = Encerrada;
       _encerradaOriginalCommited = _encerradaOriginal;
       _dataHoraFimOriginal = DataHoraFim;
       _dataHoraFimOriginalCommited = _dataHoraFimOriginal;
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
       _ordemProducaoPostoTrabalhoOriginalCommited = OrdemProducaoPostoTrabalho;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _quantidadeOriginalCommited = Quantidade;
       _dataHoraOriginalCommited = DataHora;
       _encerradaOriginalCommited = Encerrada;
       _dataHoraFimOriginalCommited = DataHoraFim;
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
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>();
                  }
                  _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoChanged = false;
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoCommitedChanged = false;
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
               OrdemProducaoPostoTrabalho=_ordemProducaoPostoTrabalhoOriginal;
               _ordemProducaoPostoTrabalhoOriginalCommited=_ordemProducaoPostoTrabalhoOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               DataHora=_dataHoraOriginal;
               _dataHoraOriginalCommited=_dataHoraOriginal;
               Encerrada=_encerradaOriginal;
               _encerradaOriginalCommited=_encerradaOriginal;
               DataHoraFim=_dataHoraFimOriginal;
               _dataHoraFimOriginalCommited=_dataHoraFimOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded) 
               {
                  CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoOriginal)
                  {
                    CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao.Add(Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoRemovidos.Clear();
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
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao.Any(item => item.IsDirty());
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
       if (_ordemProducaoPostoTrabalhoOriginal!=null)
       {
          dirty = !_ordemProducaoPostoTrabalhoOriginal.Equals(OrdemProducaoPostoTrabalho);
       }
       else
       {
            dirty = OrdemProducaoPostoTrabalho != null;
       }
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
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _dataHoraOriginal != DataHora;
      if (dirty) return true;
       dirty = _encerradaOriginal != Encerrada;
      if (dirty) return true;
       dirty = _dataHoraFimOriginal != DataHoraFim;
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
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao.Any(item => item.IsDirtyCommited());
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
       if (_ordemProducaoPostoTrabalhoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoPostoTrabalhoOriginalCommited.Equals(OrdemProducaoPostoTrabalho);
       }
       else
       {
            dirty = OrdemProducaoPostoTrabalho != null;
       }
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
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _dataHoraOriginalCommited != DataHora;
      if (dirty) return true;
       dirty = _encerradaOriginalCommited != Encerrada;
      if (dirty) return true;
       dirty = _dataHoraFimOriginalCommited != DataHoraFim;
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
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoProducaoLoteClass item in CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao)
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
             case "OrdemProducaoPostoTrabalho":
                return this.OrdemProducaoPostoTrabalho;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "Quantidade":
                return this.Quantidade;
             case "DataHora":
                return this.DataHora;
             case "Encerrada":
                return this.Encerrada;
             case "DataHoraFim":
                return this.DataHoraFim;
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
             if (OrdemProducaoPostoTrabalho!=null)
                OrdemProducaoPostoTrabalho.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducaoLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoProducaoLoteClass item in CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao)
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
                  command.CommandText += " COUNT(ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho_producao) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho_producao, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao.id_acs_usuario, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao.opo_quantidade, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao.opo_data_hora, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao.opo_encerrada, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao.opo_data_hora_fim, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao.entity_uid, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao.version " ;
               }
               command.CommandText += " FROM  ordem_producao_posto_trabalho_producao ";
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
                        orderByClause += " , opo_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(opo_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_posto_trabalho_producao.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_posto_trabalho_producao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao_posto_trabalho":
                     case "OrdemProducaoPostoTrabalho":
                     command.CommandText += " LEFT JOIN ordem_producao_posto_trabalho as ordem_producao_posto_trabalho_OrdemProducaoPostoTrabalho ON ordem_producao_posto_trabalho_OrdemProducaoPostoTrabalho.id_ordem_producao_posto_trabalho = ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho_OrdemProducaoPostoTrabalho.id_ordem_producao_posto_trabalho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_OrdemProducaoPostoTrabalho.id_ordem_producao_posto_trabalho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , ordem_producao_posto_trabalho_producao.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "opo_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho_producao.opo_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao.opo_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opo_data_hora":
                     case "DataHora":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho_producao.opo_data_hora " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao.opo_data_hora) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opo_encerrada":
                     case "Encerrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho_producao.opo_encerrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao.opo_encerrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opo_data_hora_fim":
                     case "DataHoraFim":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho_producao.opo_data_hora_fim " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao.opo_data_hora_fim) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho_producao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_posto_trabalho_producao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho_producao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho_producao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_posto_trabalho_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho_producao = :ordem_producao_posto_trabalho_producao_ID_8024 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_ID_8024", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoPostoTrabalho" || parametro.FieldName == "id_ordem_producao_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho = :ordem_producao_posto_trabalho_producao_OrdemProducaoPostoTrabalho_5770 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_OrdemProducaoPostoTrabalho_5770", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_posto_trabalho_producao.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.id_acs_usuario = :ordem_producao_posto_trabalho_producao_AcsUsuario_825 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_AcsUsuario_825", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "opo_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.opo_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.opo_quantidade = :ordem_producao_posto_trabalho_producao_Quantidade_6520 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_Quantidade_6520", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataHora" || parametro.FieldName == "opo_data_hora")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.opo_data_hora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.opo_data_hora = :ordem_producao_posto_trabalho_producao_DataHora_3242 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_DataHora_3242", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Encerrada" || parametro.FieldName == "opo_encerrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.opo_encerrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.opo_encerrada = :ordem_producao_posto_trabalho_producao_Encerrada_3554 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_Encerrada_3554", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataHoraFim" || parametro.FieldName == "opo_data_hora_fim")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.opo_data_hora_fim IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.opo_data_hora_fim = :ordem_producao_posto_trabalho_producao_DataHoraFim_916 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_DataHoraFim_916", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  ordem_producao_posto_trabalho_producao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.entity_uid LIKE :ordem_producao_posto_trabalho_producao_EntityUid_9700 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_EntityUid_9700", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_posto_trabalho_producao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.version = :ordem_producao_posto_trabalho_producao_Version_8339 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_Version_8339", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao_posto_trabalho_producao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao.entity_uid LIKE :ordem_producao_posto_trabalho_producao_EntityUid_8487 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_EntityUid_8487", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoPostoTrabalhoProducaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoPostoTrabalhoProducaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoPostoTrabalhoProducaoClass), Convert.ToInt32(read["id_ordem_producao_posto_trabalho_producao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoPostoTrabalhoProducaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_posto_trabalho_producao"]);
                     if (read["id_ordem_producao_posto_trabalho"] != DBNull.Value)
                     {
                        entidade.OrdemProducaoPostoTrabalho = (BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass)BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao_posto_trabalho"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducaoPostoTrabalho = null ;
                     }
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.Quantidade = (double)read["opo_quantidade"];
                     entidade.DataHora = (DateTime)read["opo_data_hora"];
                     entidade.Encerrada = Convert.ToBoolean(Convert.ToInt16(read["opo_encerrada"]));
                     entidade.DataHoraFim = read["opo_data_hora_fim"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoPostoTrabalhoProducaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
