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
     [Table("cob_remessa","rem")]
     public class CobRemessaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do CobRemessaClass";
protected const string ErroDelete = "Erro ao excluir o CobRemessaClass  ";
protected const string ErroSave = "Erro ao salvar o CobRemessaClass.";
protected const string ErroCollectionCobBoletoClassCobRemessa = "Erro ao carregar a coleção de CobBoletoClass.";
protected const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected const string ErroNomeArquivoComprimento = "O campo NomeArquivo deve ter no máximo 255 caracteres";
protected const string ErroAgenciaObrigatorio = "O campo Agencia é obrigatório";
protected const string ErroAgenciaComprimento = "O campo Agencia deve ter no máximo 100 caracteres";
protected const string ErroDvAgenciaObrigatorio = "O campo DvAgencia é obrigatório";
protected const string ErroDvAgenciaComprimento = "O campo DvAgencia deve ter no máximo 1 caracteres";
protected const string ErroNumeroContaObrigatorio = "O campo NumeroConta é obrigatório";
protected const string ErroNumeroContaComprimento = "O campo NumeroConta deve ter no máximo 100 caracteres";
protected const string ErroDvContaObrigatorio = "O campo DvConta é obrigatório";
protected const string ErroDvContaComprimento = "O campo DvConta deve ter no máximo 1 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do CobRemessaClass.";
protected const string MensagemUtilizadoCollectionCobBoletoClassCobRemessa =  "A entidade CobRemessaClass está sendo utilizada nos seguintes CobBoletoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade CobRemessaClass está sendo utilizada.";
#endregion
       protected short _bancoOriginal{get;private set;}
       private short _bancoOriginalCommited{get; set;}
        private short _valueBanco;
         [Column("rem_banco")]
        public virtual short Banco
         { 
            get { return this._valueBanco; } 
            set 
            { 
                if (this._valueBanco == value)return;
                 this._valueBanco = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _valueContaBancaria;
        [Column("id_conta_bancaria", "conta_bancaria", "id_conta_bancaria")]
       public virtual BibliotecaEntidades.Entidades.ContaBancariaClass ContaBancaria
        { 
           get {                 return this._valueContaBancaria; } 
           set 
           { 
                if (this._valueContaBancaria == value)return;
                 this._valueContaBancaria = value; 
           } 
       } 

       protected string _nomeArquivoOriginal{get;private set;}
       private string _nomeArquivoOriginalCommited{get; set;}
        private string _valueNomeArquivo;
         [Column("rem_nome_arquivo")]
        public virtual string NomeArquivo
         { 
            get { return this._valueNomeArquivo; } 
            set 
            { 
                if (this._valueNomeArquivo == value)return;
                 this._valueNomeArquivo = value; 
            } 
        } 

       protected string _agenciaOriginal{get;private set;}
       private string _agenciaOriginalCommited{get; set;}
        private string _valueAgencia;
         [Column("rem_agencia")]
        public virtual string Agencia
         { 
            get { return this._valueAgencia; } 
            set 
            { 
                if (this._valueAgencia == value)return;
                 this._valueAgencia = value; 
            } 
        } 

       protected string _dvAgenciaOriginal{get;private set;}
       private string _dvAgenciaOriginalCommited{get; set;}
        private string _valueDvAgencia;
         [Column("rem_dv_agencia")]
        public virtual string DvAgencia
         { 
            get { return this._valueDvAgencia; } 
            set 
            { 
                if (this._valueDvAgencia == value)return;
                 this._valueDvAgencia = value; 
            } 
        } 

       protected string _numeroContaOriginal{get;private set;}
       private string _numeroContaOriginalCommited{get; set;}
        private string _valueNumeroConta;
         [Column("rem_numero_conta")]
        public virtual string NumeroConta
         { 
            get { return this._valueNumeroConta; } 
            set 
            { 
                if (this._valueNumeroConta == value)return;
                 this._valueNumeroConta = value; 
            } 
        } 

       protected string _dvContaOriginal{get;private set;}
       private string _dvContaOriginalCommited{get; set;}
        private string _valueDvConta;
         [Column("rem_dv_conta")]
        public virtual string DvConta
         { 
            get { return this._valueDvConta; } 
            set 
            { 
                if (this._valueDvConta == value)return;
                 this._valueDvConta = value; 
            } 
        } 

       protected DateTime _dataGeracaoOriginal{get;private set;}
       private DateTime _dataGeracaoOriginalCommited{get; set;}
        private DateTime _valueDataGeracao;
         [Column("rem_data_geracao")]
        public virtual DateTime DataGeracao
         { 
            get { return this._valueDataGeracao; } 
            set 
            { 
                if (this._valueDataGeracao == value)return;
                 this._valueDataGeracao = value; 
            } 
        } 

       protected int? _idAcsUsuarioGeracaoOriginal{get;private set;}
       private int? _idAcsUsuarioGeracaoOriginalCommited{get; set;}
        private int? _valueIdAcsUsuarioGeracao;
         [Column("id_acs_usuario_geracao")]
        public virtual int? IdAcsUsuarioGeracao
         { 
            get { return this._valueIdAcsUsuarioGeracao; } 
            set 
            { 
                if (this._valueIdAcsUsuarioGeracao == value)return;
                 this._valueIdAcsUsuarioGeracao = value; 
            } 
        } 

       protected short _layoutOriginal{get;private set;}
       private short _layoutOriginalCommited{get; set;}
        private short _valueLayout;
         [Column("rem_layout")]
        public virtual short Layout
         { 
            get { return this._valueLayout; } 
            set 
            { 
                if (this._valueLayout == value)return;
                 this._valueLayout = value; 
            } 
        } 

       protected int _numeroRemessaOriginal{get;private set;}
       private int _numeroRemessaOriginalCommited{get; set;}
        private int _valueNumeroRemessa;
         [Column("rem_numero_remessa")]
        public virtual int NumeroRemessa
         { 
            get { return this._valueNumeroRemessa; } 
            set 
            { 
                if (this._valueNumeroRemessa == value)return;
                 this._valueNumeroRemessa = value; 
            } 
        } 

       private List<long> _collectionCobBoletoClassCobRemessaOriginal;
       private List<Entidades.CobBoletoClass > _collectionCobBoletoClassCobRemessaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoClassCobRemessaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoClassCobRemessaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoClassCobRemessaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CobBoletoClass> _valueCollectionCobBoletoClassCobRemessa { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CobBoletoClass> CollectionCobBoletoClassCobRemessa 
       { 
           get { if(!_valueCollectionCobBoletoClassCobRemessaLoaded && !this.DisableLoadCollection){this.LoadCollectionCobBoletoClassCobRemessa();}
return this._valueCollectionCobBoletoClassCobRemessa; } 
           set 
           { 
               this._valueCollectionCobBoletoClassCobRemessa = value; 
               this._valueCollectionCobBoletoClassCobRemessaLoaded = true; 
           } 
       } 

        public CobRemessaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.DataGeracao = Configurations.DataIndependenteClass.GetData();
           this.NumeroRemessa = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static CobRemessaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (CobRemessaClass) GetEntity(typeof(CobRemessaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionCobBoletoClassCobRemessaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCobBoletoClassCobRemessaChanged = true;
                  _valueCollectionCobBoletoClassCobRemessaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCobBoletoClassCobRemessaChanged = true; 
                  _valueCollectionCobBoletoClassCobRemessaCommitedChanged = true;
                 foreach (Entidades.CobBoletoClass item in e.OldItems) 
                 { 
                     _collectionCobBoletoClassCobRemessaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCobBoletoClassCobRemessaChanged = true; 
                  _valueCollectionCobBoletoClassCobRemessaCommitedChanged = true;
                 foreach (Entidades.CobBoletoClass item in _valueCollectionCobBoletoClassCobRemessa) 
                 { 
                     _collectionCobBoletoClassCobRemessaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCobBoletoClassCobRemessa()
         {
            try
            {
                 ObservableCollection<Entidades.CobBoletoClass> oc;
                _valueCollectionCobBoletoClassCobRemessaChanged = false;
                 _valueCollectionCobBoletoClassCobRemessaCommitedChanged = false;
                _collectionCobBoletoClassCobRemessaRemovidos = new List<Entidades.CobBoletoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CobBoletoClass>();
                }
                else{ 
                   Entidades.CobBoletoClass search = new Entidades.CobBoletoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CobBoletoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CobRemessa", this),                     }                       ).Cast<Entidades.CobBoletoClass>().ToList());
                 }
                 _valueCollectionCobBoletoClassCobRemessa = new BindingList<Entidades.CobBoletoClass>(oc); 
                 _collectionCobBoletoClassCobRemessaOriginal= (from a in _valueCollectionCobBoletoClassCobRemessa select a.ID).ToList();
                 _valueCollectionCobBoletoClassCobRemessaLoaded = true;
                 oc.CollectionChanged += CollectionCobBoletoClassCobRemessaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCobBoletoClassCobRemessa+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NomeArquivo))
                {
                    throw new Exception(ErroNomeArquivoObrigatorio);
                }
                if (NomeArquivo.Length >255)
                {
                    throw new Exception( ErroNomeArquivoComprimento);
                }
                if (string.IsNullOrEmpty(Agencia))
                {
                    throw new Exception(ErroAgenciaObrigatorio);
                }
                if (Agencia.Length >100)
                {
                    throw new Exception( ErroAgenciaComprimento);
                }
                if (string.IsNullOrEmpty(DvAgencia))
                {
                    throw new Exception(ErroDvAgenciaObrigatorio);
                }
                if (DvAgencia.Length >1)
                {
                    throw new Exception( ErroDvAgenciaComprimento);
                }
                if (string.IsNullOrEmpty(NumeroConta))
                {
                    throw new Exception(ErroNumeroContaObrigatorio);
                }
                if (NumeroConta.Length >100)
                {
                    throw new Exception( ErroNumeroContaComprimento);
                }
                if (string.IsNullOrEmpty(DvConta))
                {
                    throw new Exception(ErroDvContaObrigatorio);
                }
                if (DvConta.Length >1)
                {
                    throw new Exception( ErroDvContaComprimento);
                }
                if ( _valueContaBancaria == null)
                {
                    throw new Exception(ErroContaBancariaObrigatorio);
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
                    "  public.cob_remessa  " +
                    "WHERE " +
                    "  id_cob_remessa = :id";
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
                        "  public.cob_remessa   " +
                        "SET  " + 
                        "  rem_banco = :rem_banco, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  rem_nome_arquivo = :rem_nome_arquivo, " + 
                        "  rem_agencia = :rem_agencia, " + 
                        "  rem_dv_agencia = :rem_dv_agencia, " + 
                        "  rem_numero_conta = :rem_numero_conta, " + 
                        "  rem_dv_conta = :rem_dv_conta, " + 
                        "  rem_data_geracao = :rem_data_geracao, " + 
                        "  id_acs_usuario_geracao = :id_acs_usuario_geracao, " + 
                        "  rem_layout = :rem_layout, " + 
                        "  rem_numero_remessa = :rem_numero_remessa, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_cob_remessa = :id " +
                        "RETURNING id_cob_remessa;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.cob_remessa " +
                        "( " +
                        "  rem_banco , " + 
                        "  id_conta_bancaria , " + 
                        "  rem_nome_arquivo , " + 
                        "  rem_agencia , " + 
                        "  rem_dv_agencia , " + 
                        "  rem_numero_conta , " + 
                        "  rem_dv_conta , " + 
                        "  rem_data_geracao , " + 
                        "  id_acs_usuario_geracao , " + 
                        "  rem_layout , " + 
                        "  rem_numero_remessa , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :rem_banco , " + 
                        "  :id_conta_bancaria , " + 
                        "  :rem_nome_arquivo , " + 
                        "  :rem_agencia , " + 
                        "  :rem_dv_agencia , " + 
                        "  :rem_numero_conta , " + 
                        "  :rem_dv_conta , " + 
                        "  :rem_data_geracao , " + 
                        "  :id_acs_usuario_geracao , " + 
                        "  :rem_layout , " + 
                        "  :rem_numero_remessa , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_cob_remessa;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rem_banco", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Banco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rem_nome_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeArquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rem_agencia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Agencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rem_dv_agencia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DvAgencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rem_numero_conta", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroConta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rem_dv_conta", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DvConta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rem_data_geracao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataGeracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_geracao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdAcsUsuarioGeracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rem_layout", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Layout ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("rem_numero_remessa", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroRemessa ?? DBNull.Value;
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
 if (CollectionCobBoletoClassCobRemessa.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCobBoletoClassCobRemessa+"\r\n";
                foreach (Entidades.CobBoletoClass tmp in CollectionCobBoletoClassCobRemessa)
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
        public static CobRemessaClass CopiarEntidade(CobRemessaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               CobRemessaClass toRet = new CobRemessaClass(usuario,conn);
 toRet.Banco= entidadeCopiar.Banco;
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.NomeArquivo= entidadeCopiar.NomeArquivo;
 toRet.Agencia= entidadeCopiar.Agencia;
 toRet.DvAgencia= entidadeCopiar.DvAgencia;
 toRet.NumeroConta= entidadeCopiar.NumeroConta;
 toRet.DvConta= entidadeCopiar.DvConta;
 toRet.DataGeracao= entidadeCopiar.DataGeracao;
 toRet.IdAcsUsuarioGeracao= entidadeCopiar.IdAcsUsuarioGeracao;
 toRet.Layout= entidadeCopiar.Layout;
 toRet.NumeroRemessa= entidadeCopiar.NumeroRemessa;

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
       _bancoOriginal = Banco;
       _bancoOriginalCommited = _bancoOriginal;
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _nomeArquivoOriginal = NomeArquivo;
       _nomeArquivoOriginalCommited = _nomeArquivoOriginal;
       _agenciaOriginal = Agencia;
       _agenciaOriginalCommited = _agenciaOriginal;
       _dvAgenciaOriginal = DvAgencia;
       _dvAgenciaOriginalCommited = _dvAgenciaOriginal;
       _numeroContaOriginal = NumeroConta;
       _numeroContaOriginalCommited = _numeroContaOriginal;
       _dvContaOriginal = DvConta;
       _dvContaOriginalCommited = _dvContaOriginal;
       _dataGeracaoOriginal = DataGeracao;
       _dataGeracaoOriginalCommited = _dataGeracaoOriginal;
       _idAcsUsuarioGeracaoOriginal = IdAcsUsuarioGeracao;
       _idAcsUsuarioGeracaoOriginalCommited = _idAcsUsuarioGeracaoOriginal;
       _layoutOriginal = Layout;
       _layoutOriginalCommited = _layoutOriginal;
       _numeroRemessaOriginal = NumeroRemessa;
       _numeroRemessaOriginalCommited = _numeroRemessaOriginal;
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
       _bancoOriginalCommited = Banco;
       _contaBancariaOriginalCommited = ContaBancaria;
       _nomeArquivoOriginalCommited = NomeArquivo;
       _agenciaOriginalCommited = Agencia;
       _dvAgenciaOriginalCommited = DvAgencia;
       _numeroContaOriginalCommited = NumeroConta;
       _dvContaOriginalCommited = DvConta;
       _dataGeracaoOriginalCommited = DataGeracao;
       _idAcsUsuarioGeracaoOriginalCommited = IdAcsUsuarioGeracao;
       _layoutOriginalCommited = Layout;
       _numeroRemessaOriginalCommited = NumeroRemessa;
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
               if (_valueCollectionCobBoletoClassCobRemessaLoaded) 
               {
                  if (_collectionCobBoletoClassCobRemessaRemovidos != null) 
                  {
                     _collectionCobBoletoClassCobRemessaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCobBoletoClassCobRemessaRemovidos = new List<Entidades.CobBoletoClass>();
                  }
                  _collectionCobBoletoClassCobRemessaOriginal= (from a in _valueCollectionCobBoletoClassCobRemessa select a.ID).ToList();
                  _valueCollectionCobBoletoClassCobRemessaChanged = false;
                  _valueCollectionCobBoletoClassCobRemessaCommitedChanged = false;
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
               Banco=_bancoOriginal;
               _bancoOriginalCommited=_bancoOriginal;
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               NomeArquivo=_nomeArquivoOriginal;
               _nomeArquivoOriginalCommited=_nomeArquivoOriginal;
               Agencia=_agenciaOriginal;
               _agenciaOriginalCommited=_agenciaOriginal;
               DvAgencia=_dvAgenciaOriginal;
               _dvAgenciaOriginalCommited=_dvAgenciaOriginal;
               NumeroConta=_numeroContaOriginal;
               _numeroContaOriginalCommited=_numeroContaOriginal;
               DvConta=_dvContaOriginal;
               _dvContaOriginalCommited=_dvContaOriginal;
               DataGeracao=_dataGeracaoOriginal;
               _dataGeracaoOriginalCommited=_dataGeracaoOriginal;
               IdAcsUsuarioGeracao=_idAcsUsuarioGeracaoOriginal;
               _idAcsUsuarioGeracaoOriginalCommited=_idAcsUsuarioGeracaoOriginal;
               Layout=_layoutOriginal;
               _layoutOriginalCommited=_layoutOriginal;
               NumeroRemessa=_numeroRemessaOriginal;
               _numeroRemessaOriginalCommited=_numeroRemessaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionCobBoletoClassCobRemessaLoaded) 
               {
                  CollectionCobBoletoClassCobRemessa.Clear();
                  foreach(int item in _collectionCobBoletoClassCobRemessaOriginal)
                  {
                    CollectionCobBoletoClassCobRemessa.Add(Entidades.CobBoletoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCobBoletoClassCobRemessaRemovidos.Clear();
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
               if (_valueCollectionCobBoletoClassCobRemessaLoaded) 
               {
                  if (_valueCollectionCobBoletoClassCobRemessaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoClassCobRemessaLoaded) 
               {
                   tempRet = CollectionCobBoletoClassCobRemessa.Any(item => item.IsDirty());
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
       dirty = _bancoOriginal != Banco;
      if (dirty) return true;
       if (_contaBancariaOriginal!=null)
       {
          dirty = !_contaBancariaOriginal.Equals(ContaBancaria);
       }
       else
       {
            dirty = ContaBancaria != null;
       }
      if (dirty) return true;
       dirty = _nomeArquivoOriginal != NomeArquivo;
      if (dirty) return true;
       dirty = _agenciaOriginal != Agencia;
      if (dirty) return true;
       dirty = _dvAgenciaOriginal != DvAgencia;
      if (dirty) return true;
       dirty = _numeroContaOriginal != NumeroConta;
      if (dirty) return true;
       dirty = _dvContaOriginal != DvConta;
      if (dirty) return true;
       dirty = _dataGeracaoOriginal != DataGeracao;
      if (dirty) return true;
       dirty = _idAcsUsuarioGeracaoOriginal != IdAcsUsuarioGeracao;
      if (dirty) return true;
       dirty = _layoutOriginal != Layout;
      if (dirty) return true;
       dirty = _numeroRemessaOriginal != NumeroRemessa;
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
               if (_valueCollectionCobBoletoClassCobRemessaLoaded) 
               {
                  if (_valueCollectionCobBoletoClassCobRemessaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoClassCobRemessaLoaded) 
               {
                   tempRet = CollectionCobBoletoClassCobRemessa.Any(item => item.IsDirtyCommited());
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
       dirty = _bancoOriginalCommited != Banco;
      if (dirty) return true;
       if (_contaBancariaOriginalCommited!=null)
       {
          dirty = !_contaBancariaOriginalCommited.Equals(ContaBancaria);
       }
       else
       {
            dirty = ContaBancaria != null;
       }
      if (dirty) return true;
       dirty = _nomeArquivoOriginalCommited != NomeArquivo;
      if (dirty) return true;
       dirty = _agenciaOriginalCommited != Agencia;
      if (dirty) return true;
       dirty = _dvAgenciaOriginalCommited != DvAgencia;
      if (dirty) return true;
       dirty = _numeroContaOriginalCommited != NumeroConta;
      if (dirty) return true;
       dirty = _dvContaOriginalCommited != DvConta;
      if (dirty) return true;
       dirty = _dataGeracaoOriginalCommited != DataGeracao;
      if (dirty) return true;
       dirty = _idAcsUsuarioGeracaoOriginalCommited != IdAcsUsuarioGeracao;
      if (dirty) return true;
       dirty = _layoutOriginalCommited != Layout;
      if (dirty) return true;
       dirty = _numeroRemessaOriginalCommited != NumeroRemessa;
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
               if (_valueCollectionCobBoletoClassCobRemessaLoaded) 
               {
                  foreach(CobBoletoClass item in CollectionCobBoletoClassCobRemessa)
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
             case "Banco":
                return this.Banco;
             case "ContaBancaria":
                return this.ContaBancaria;
             case "NomeArquivo":
                return this.NomeArquivo;
             case "Agencia":
                return this.Agencia;
             case "DvAgencia":
                return this.DvAgencia;
             case "NumeroConta":
                return this.NumeroConta;
             case "DvConta":
                return this.DvConta;
             case "DataGeracao":
                return this.DataGeracao;
             case "IdAcsUsuarioGeracao":
                return this.IdAcsUsuarioGeracao;
             case "Layout":
                return this.Layout;
             case "NumeroRemessa":
                return this.NumeroRemessa;
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
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
               if (_valueCollectionCobBoletoClassCobRemessaLoaded) 
               {
                  foreach(CobBoletoClass item in CollectionCobBoletoClassCobRemessa)
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
                  command.CommandText += " COUNT(cob_remessa.id_cob_remessa) " ;
               }
               else
               {
               command.CommandText += "cob_remessa.id_cob_remessa, " ;
               command.CommandText += "cob_remessa.rem_banco, " ;
               command.CommandText += "cob_remessa.id_conta_bancaria, " ;
               command.CommandText += "cob_remessa.rem_nome_arquivo, " ;
               command.CommandText += "cob_remessa.rem_agencia, " ;
               command.CommandText += "cob_remessa.rem_dv_agencia, " ;
               command.CommandText += "cob_remessa.rem_numero_conta, " ;
               command.CommandText += "cob_remessa.rem_dv_conta, " ;
               command.CommandText += "cob_remessa.rem_data_geracao, " ;
               command.CommandText += "cob_remessa.id_acs_usuario_geracao, " ;
               command.CommandText += "cob_remessa.rem_layout, " ;
               command.CommandText += "cob_remessa.rem_numero_remessa, " ;
               command.CommandText += "cob_remessa.entity_uid, " ;
               command.CommandText += "cob_remessa.version " ;
               }
               command.CommandText += " FROM  cob_remessa ";
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
                        orderByClause += " , rem_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(rem_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = cob_remessa.id_acs_usuario_ultima_revisao ";
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
                     case "id_cob_remessa":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_remessa.id_cob_remessa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_remessa.id_cob_remessa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rem_banco":
                     case "Banco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_remessa.rem_banco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_remessa.rem_banco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = cob_remessa.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria_ContaBancaria.cba_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria_ContaBancaria.cba_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rem_nome_arquivo":
                     case "NomeArquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_remessa.rem_nome_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_remessa.rem_nome_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rem_agencia":
                     case "Agencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_remessa.rem_agencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_remessa.rem_agencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rem_dv_agencia":
                     case "DvAgencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_remessa.rem_dv_agencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_remessa.rem_dv_agencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rem_numero_conta":
                     case "NumeroConta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_remessa.rem_numero_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_remessa.rem_numero_conta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rem_dv_conta":
                     case "DvConta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_remessa.rem_dv_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_remessa.rem_dv_conta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rem_data_geracao":
                     case "DataGeracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_remessa.rem_data_geracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_remessa.rem_data_geracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_geracao":
                     case "IdAcsUsuarioGeracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_remessa.id_acs_usuario_geracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_remessa.id_acs_usuario_geracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rem_layout":
                     case "Layout":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_remessa.rem_layout " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_remessa.rem_layout) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "rem_numero_remessa":
                     case "NumeroRemessa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_remessa.rem_numero_remessa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_remessa.rem_numero_remessa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_remessa.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_remessa.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , cob_remessa.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_remessa.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rem_nome_arquivo")) 
                        {
                           whereClause += " OR UPPER(cob_remessa.rem_nome_arquivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_remessa.rem_nome_arquivo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rem_agencia")) 
                        {
                           whereClause += " OR UPPER(cob_remessa.rem_agencia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_remessa.rem_agencia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rem_dv_agencia")) 
                        {
                           whereClause += " OR UPPER(cob_remessa.rem_dv_agencia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_remessa.rem_dv_agencia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rem_numero_conta")) 
                        {
                           whereClause += " OR UPPER(cob_remessa.rem_numero_conta) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_remessa.rem_numero_conta) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("rem_dv_conta")) 
                        {
                           whereClause += " OR UPPER(cob_remessa.rem_dv_conta) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_remessa.rem_dv_conta) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(cob_remessa.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_remessa.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_cob_remessa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.id_cob_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.id_cob_remessa = :cob_remessa_ID_9222 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_ID_9222", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Banco" || parametro.FieldName == "rem_banco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_banco = :cob_remessa_Banco_2455 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_Banco_2455", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaBancaria" || parametro.FieldName == "id_conta_bancaria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ContaBancariaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ContaBancariaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.id_conta_bancaria = :cob_remessa_ContaBancaria_2960 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_ContaBancaria_2960", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivo" || parametro.FieldName == "rem_nome_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_nome_arquivo LIKE :cob_remessa_NomeArquivo_3368 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_NomeArquivo_3368", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Agencia" || parametro.FieldName == "rem_agencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_agencia LIKE :cob_remessa_Agencia_3010 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_Agencia_3010", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvAgencia" || parametro.FieldName == "rem_dv_agencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_dv_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_dv_agencia LIKE :cob_remessa_DvAgencia_8738 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_DvAgencia_8738", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroConta" || parametro.FieldName == "rem_numero_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_numero_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_numero_conta LIKE :cob_remessa_NumeroConta_6257 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_NumeroConta_6257", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvConta" || parametro.FieldName == "rem_dv_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_dv_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_dv_conta LIKE :cob_remessa_DvConta_9685 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_DvConta_9685", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataGeracao" || parametro.FieldName == "rem_data_geracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_data_geracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_data_geracao = :cob_remessa_DataGeracao_2692 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_DataGeracao_2692", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdAcsUsuarioGeracao" || parametro.FieldName == "id_acs_usuario_geracao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.id_acs_usuario_geracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.id_acs_usuario_geracao = :cob_remessa_IdAcsUsuarioGeracao_2325 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_IdAcsUsuarioGeracao_2325", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Layout" || parametro.FieldName == "rem_layout")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_layout IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_layout = :cob_remessa_Layout_8740 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_Layout_8740", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroRemessa" || parametro.FieldName == "rem_numero_remessa")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_numero_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_numero_remessa = :cob_remessa_NumeroRemessa_1480 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_NumeroRemessa_1480", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  cob_remessa.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.entity_uid LIKE :cob_remessa_EntityUid_5834 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_EntityUid_5834", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  cob_remessa.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.version = :cob_remessa_Version_2151 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_Version_2151", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivoExato" || parametro.FieldName == "NomeArquivoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_nome_arquivo LIKE :cob_remessa_NomeArquivo_7227 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_NomeArquivo_7227", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgenciaExato" || parametro.FieldName == "AgenciaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_agencia LIKE :cob_remessa_Agencia_3907 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_Agencia_3907", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvAgenciaExato" || parametro.FieldName == "DvAgenciaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_dv_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_dv_agencia LIKE :cob_remessa_DvAgencia_7570 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_DvAgencia_7570", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroContaExato" || parametro.FieldName == "NumeroContaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_numero_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_numero_conta LIKE :cob_remessa_NumeroConta_9414 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_NumeroConta_9414", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvContaExato" || parametro.FieldName == "DvContaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_remessa.rem_dv_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.rem_dv_conta LIKE :cob_remessa_DvConta_9319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_DvConta_9319", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cob_remessa.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_remessa.entity_uid LIKE :cob_remessa_EntityUid_5594 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_remessa_EntityUid_5594", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  CobRemessaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (CobRemessaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(CobRemessaClass), Convert.ToInt32(read["id_cob_remessa"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new CobRemessaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_cob_remessa"]);
                     entidade.Banco = (short)read["rem_banco"];
                     if (read["id_conta_bancaria"] != DBNull.Value)
                     {
                        entidade.ContaBancaria = (BibliotecaEntidades.Entidades.ContaBancariaClass)BibliotecaEntidades.Entidades.ContaBancariaClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaBancaria = null ;
                     }
                     entidade.NomeArquivo = (read["rem_nome_arquivo"] != DBNull.Value ? read["rem_nome_arquivo"].ToString() : null);
                     entidade.Agencia = (read["rem_agencia"] != DBNull.Value ? read["rem_agencia"].ToString() : null);
                     entidade.DvAgencia = (read["rem_dv_agencia"] != DBNull.Value ? read["rem_dv_agencia"].ToString() : null);
                     entidade.NumeroConta = (read["rem_numero_conta"] != DBNull.Value ? read["rem_numero_conta"].ToString() : null);
                     entidade.DvConta = (read["rem_dv_conta"] != DBNull.Value ? read["rem_dv_conta"].ToString() : null);
                     entidade.DataGeracao = (DateTime)read["rem_data_geracao"];
                     entidade.IdAcsUsuarioGeracao = read["id_acs_usuario_geracao"] as int?;
                     entidade.Layout = (short)read["rem_layout"];
                     entidade.NumeroRemessa = (int)read["rem_numero_remessa"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (CobRemessaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
