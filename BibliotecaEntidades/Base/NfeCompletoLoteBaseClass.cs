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
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNFCompleto.BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("nfe_completo_lote","ncl")]
     public class NfeCompletoLoteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfeCompletoLoteClass";
protected const string ErroDelete = "Erro ao excluir o NfeCompletoLoteClass  ";
protected const string ErroSave = "Erro ao salvar o NfeCompletoLoteClass.";
protected const string ErroCollectionNfeCompletoNotaClassNfeCompletoLote = "Erro ao carregar a coleção de NfeCompletoNotaClass.";
protected const string ErroCnpjTransmissorObrigatorio = "O campo CnpjTransmissor é obrigatório";
protected const string ErroCnpjTransmissorComprimento = "O campo CnpjTransmissor deve ter no máximo 30 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroModeloObrigatorio = "O campo Modelo é obrigatório";
protected const string ErroModeloComprimento = "O campo Modelo deve ter no máximo 10 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do NfeCompletoLoteClass.";
protected const string MensagemUtilizadoCollectionNfeCompletoNotaClassNfeCompletoLote =  "A entidade NfeCompletoLoteClass está sendo utilizada nos seguintes NfeCompletoNotaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfeCompletoLoteClass está sendo utilizada.";
#endregion
       protected int _numeroLoteOriginal{get;private set;}
       private int _numeroLoteOriginalCommited{get; set;}
        private int _valueNumeroLote;
         [Column("ncl_numero_lote")]
        public virtual int NumeroLote
         { 
            get { return this._valueNumeroLote; } 
            set 
            { 
                if (this._valueNumeroLote == value)return;
                 this._valueNumeroLote = value; 
            } 
        } 

       protected string _reciboOriginal{get;private set;}
       private string _reciboOriginalCommited{get; set;}
        private string _valueRecibo;
         [Column("ncl_recibo")]
        public virtual string Recibo
         { 
            get { return this._valueRecibo; } 
            set 
            { 
                if (this._valueRecibo == value)return;
                 this._valueRecibo = value; 
            } 
        } 

       protected DateTime _dataEnvioOriginal{get;private set;}
       private DateTime _dataEnvioOriginalCommited{get; set;}
        private DateTime _valueDataEnvio;
         [Column("ncl_data_envio")]
        public virtual DateTime DataEnvio
         { 
            get { return this._valueDataEnvio; } 
            set 
            { 
                if (this._valueDataEnvio == value)return;
                 this._valueDataEnvio = value; 
            } 
        } 

       protected SituacaoLote _situacaoOriginal{get;private set;}
       private SituacaoLote _situacaoOriginalCommited{get; set;}
        private SituacaoLote _valueSituacao;
         [Column("ncl_situacao")]
        public virtual SituacaoLote Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

        public bool Situacao_Enviado
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoLote.Enviado; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoLote.Enviado; }
         } 

        public bool Situacao_Processado
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoLote.Processado; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoLote.Processado; }
         } 

        public bool Situacao_AguardandoEnvio
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoLote.AguardandoEnvio; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoLote.AguardandoEnvio; }
         } 

        public bool Situacao_ErroLote
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoLote.ErroLote; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoLote.ErroLote; }
         } 

       protected string _resultadoObsOriginal{get;private set;}
       private string _resultadoObsOriginalCommited{get; set;}
        private string _valueResultadoObs;
         [Column("ncl_resultado_obs")]
        public virtual string ResultadoObs
         { 
            get { return this._valueResultadoObs; } 
            set 
            { 
                if (this._valueResultadoObs == value)return;
                 this._valueResultadoObs = value; 
            } 
        } 

       protected string _cnpjTransmissorOriginal{get;private set;}
       private string _cnpjTransmissorOriginalCommited{get; set;}
        private string _valueCnpjTransmissor;
         [Column("ncl_cnpj_transmissor")]
        public virtual string CnpjTransmissor
         { 
            get { return this._valueCnpjTransmissor; } 
            set 
            { 
                if (this._valueCnpjTransmissor == value)return;
                 this._valueCnpjTransmissor = value; 
            } 
        } 

       protected bool _scanOriginal{get;private set;}
       private bool _scanOriginalCommited{get; set;}
        private bool _valueScan;
         [Column("ncl_scan")]
        public virtual bool Scan
         { 
            get { return this._valueScan; } 
            set 
            { 
                if (this._valueScan == value)return;
                 this._valueScan = value; 
            } 
        } 

       protected bool _homologacaoOriginal{get;private set;}
       private bool _homologacaoOriginalCommited{get; set;}
        private bool _valueHomologacao;
         [Column("ncl_homologacao")]
        public virtual bool Homologacao
         { 
            get { return this._valueHomologacao; } 
            set 
            { 
                if (this._valueHomologacao == value)return;
                 this._valueHomologacao = value; 
            } 
        } 

       protected string _modeloOriginal{get;private set;}
       private string _modeloOriginalCommited{get; set;}
        private string _valueModelo;
         [Column("ncl_modelo")]
        public virtual string Modelo
         { 
            get { return this._valueModelo; } 
            set 
            { 
                if (this._valueModelo == value)return;
                 this._valueModelo = value; 
            } 
        } 

       private List<long> _collectionNfeCompletoNotaClassNfeCompletoLoteOriginal;
       private List<Entidades.NfeCompletoNotaClass > _collectionNfeCompletoNotaClassNfeCompletoLoteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfeCompletoNotaClassNfeCompletoLoteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfeCompletoNotaClassNfeCompletoLoteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfeCompletoNotaClass> _valueCollectionNfeCompletoNotaClassNfeCompletoLote { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfeCompletoNotaClass> CollectionNfeCompletoNotaClassNfeCompletoLote 
       { 
           get { if(!_valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded && !this.DisableLoadCollection){this.LoadCollectionNfeCompletoNotaClassNfeCompletoLote();}
return this._valueCollectionNfeCompletoNotaClassNfeCompletoLote; } 
           set 
           { 
               this._valueCollectionNfeCompletoNotaClassNfeCompletoLote = value; 
               this._valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded = true; 
           } 
       } 

        public NfeCompletoLoteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Situacao = (SituacaoLote)0;
           this.Scan = false;
           this.Homologacao = false;
           this.Modelo = "55";
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfeCompletoLoteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfeCompletoLoteClass) GetEntity(typeof(NfeCompletoLoteClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionNfeCompletoNotaClassNfeCompletoLoteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfeCompletoNotaClassNfeCompletoLoteChanged = true;
                  _valueCollectionNfeCompletoNotaClassNfeCompletoLoteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfeCompletoNotaClassNfeCompletoLoteChanged = true; 
                  _valueCollectionNfeCompletoNotaClassNfeCompletoLoteCommitedChanged = true;
                 foreach (Entidades.NfeCompletoNotaClass item in e.OldItems) 
                 { 
                     _collectionNfeCompletoNotaClassNfeCompletoLoteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfeCompletoNotaClassNfeCompletoLoteChanged = true; 
                  _valueCollectionNfeCompletoNotaClassNfeCompletoLoteCommitedChanged = true;
                 foreach (Entidades.NfeCompletoNotaClass item in _valueCollectionNfeCompletoNotaClassNfeCompletoLote) 
                 { 
                     _collectionNfeCompletoNotaClassNfeCompletoLoteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfeCompletoNotaClassNfeCompletoLote()
         {
            try
            {
                 ObservableCollection<Entidades.NfeCompletoNotaClass> oc;
                _valueCollectionNfeCompletoNotaClassNfeCompletoLoteChanged = false;
                 _valueCollectionNfeCompletoNotaClassNfeCompletoLoteCommitedChanged = false;
                _collectionNfeCompletoNotaClassNfeCompletoLoteRemovidos = new List<Entidades.NfeCompletoNotaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfeCompletoNotaClass>();
                }
                else{ 
                   Entidades.NfeCompletoNotaClass search = new Entidades.NfeCompletoNotaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfeCompletoNotaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfeCompletoLote", this),                     }                       ).Cast<Entidades.NfeCompletoNotaClass>().ToList());
                 }
                 _valueCollectionNfeCompletoNotaClassNfeCompletoLote = new BindingList<Entidades.NfeCompletoNotaClass>(oc); 
                 _collectionNfeCompletoNotaClassNfeCompletoLoteOriginal= (from a in _valueCollectionNfeCompletoNotaClassNfeCompletoLote select a.ID).ToList();
                 _valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded = true;
                 oc.CollectionChanged += CollectionNfeCompletoNotaClassNfeCompletoLoteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfeCompletoNotaClassNfeCompletoLote+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CnpjTransmissor))
                {
                    throw new Exception(ErroCnpjTransmissorObrigatorio);
                }
                if (CnpjTransmissor.Length >30)
                {
                    throw new Exception( ErroCnpjTransmissorComprimento);
                }
                if (string.IsNullOrEmpty(Modelo))
                {
                    throw new Exception(ErroModeloObrigatorio);
                }
                if (Modelo.Length >10)
                {
                    throw new Exception( ErroModeloComprimento);
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
                    "  public.nfe_completo_lote  " +
                    "WHERE " +
                    "  id_nfe_completo_lote = :id";
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
                        "  public.nfe_completo_lote   " +
                        "SET  " + 
                        "  ncl_numero_lote = :ncl_numero_lote, " + 
                        "  ncl_recibo = :ncl_recibo, " + 
                        "  ncl_data_envio = :ncl_data_envio, " + 
                        "  ncl_situacao = :ncl_situacao, " + 
                        "  ncl_resultado_obs = :ncl_resultado_obs, " + 
                        "  ncl_cnpj_transmissor = :ncl_cnpj_transmissor, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  ncl_scan = :ncl_scan, " + 
                        "  ncl_homologacao = :ncl_homologacao, " + 
                        "  ncl_modelo = :ncl_modelo "+
                        "WHERE  " +
                        "  id_nfe_completo_lote = :id " +
                        "RETURNING id_nfe_completo_lote;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nfe_completo_lote " +
                        "( " +
                        "  ncl_numero_lote , " + 
                        "  ncl_recibo , " + 
                        "  ncl_data_envio , " + 
                        "  ncl_situacao , " + 
                        "  ncl_resultado_obs , " + 
                        "  ncl_cnpj_transmissor , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  ncl_scan , " + 
                        "  ncl_homologacao , " + 
                        "  ncl_modelo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :ncl_numero_lote , " + 
                        "  :ncl_recibo , " + 
                        "  :ncl_data_envio , " + 
                        "  :ncl_situacao , " + 
                        "  :ncl_resultado_obs , " + 
                        "  :ncl_cnpj_transmissor , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :ncl_scan , " + 
                        "  :ncl_homologacao , " + 
                        "  :ncl_modelo  "+
                        ")RETURNING id_nfe_completo_lote;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_numero_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroLote ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_recibo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Recibo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_data_envio", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEnvio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Situacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_resultado_obs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ResultadoObs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_cnpj_transmissor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjTransmissor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_scan", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Scan ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_homologacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Homologacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Modelo ?? DBNull.Value;

 
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
 if (CollectionNfeCompletoNotaClassNfeCompletoLote.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfeCompletoNotaClassNfeCompletoLote+"\r\n";
                foreach (Entidades.NfeCompletoNotaClass tmp in CollectionNfeCompletoNotaClassNfeCompletoLote)
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
        public static NfeCompletoLoteClass CopiarEntidade(NfeCompletoLoteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfeCompletoLoteClass toRet = new NfeCompletoLoteClass(usuario,conn);
 toRet.NumeroLote= entidadeCopiar.NumeroLote;
 toRet.Recibo= entidadeCopiar.Recibo;
 toRet.DataEnvio= entidadeCopiar.DataEnvio;
 toRet.Situacao= entidadeCopiar.Situacao;
 toRet.ResultadoObs= entidadeCopiar.ResultadoObs;
 toRet.CnpjTransmissor= entidadeCopiar.CnpjTransmissor;
 toRet.Scan= entidadeCopiar.Scan;
 toRet.Homologacao= entidadeCopiar.Homologacao;
 toRet.Modelo= entidadeCopiar.Modelo;

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
       _numeroLoteOriginal = NumeroLote;
       _numeroLoteOriginalCommited = _numeroLoteOriginal;
       _reciboOriginal = Recibo;
       _reciboOriginalCommited = _reciboOriginal;
       _dataEnvioOriginal = DataEnvio;
       _dataEnvioOriginalCommited = _dataEnvioOriginal;
       _situacaoOriginal = Situacao;
       _situacaoOriginalCommited = _situacaoOriginal;
       _resultadoObsOriginal = ResultadoObs;
       _resultadoObsOriginalCommited = _resultadoObsOriginal;
       _cnpjTransmissorOriginal = CnpjTransmissor;
       _cnpjTransmissorOriginalCommited = _cnpjTransmissorOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _scanOriginal = Scan;
       _scanOriginalCommited = _scanOriginal;
       _homologacaoOriginal = Homologacao;
       _homologacaoOriginalCommited = _homologacaoOriginal;
       _modeloOriginal = Modelo;
       _modeloOriginalCommited = _modeloOriginal;

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
       _numeroLoteOriginalCommited = NumeroLote;
       _reciboOriginalCommited = Recibo;
       _dataEnvioOriginalCommited = DataEnvio;
       _situacaoOriginalCommited = Situacao;
       _resultadoObsOriginalCommited = ResultadoObs;
       _cnpjTransmissorOriginalCommited = CnpjTransmissor;
       _versionOriginalCommited = Version;
       _scanOriginalCommited = Scan;
       _homologacaoOriginalCommited = Homologacao;
       _modeloOriginalCommited = Modelo;

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
               if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded) 
               {
                  if (_collectionNfeCompletoNotaClassNfeCompletoLoteRemovidos != null) 
                  {
                     _collectionNfeCompletoNotaClassNfeCompletoLoteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfeCompletoNotaClassNfeCompletoLoteRemovidos = new List<Entidades.NfeCompletoNotaClass>();
                  }
                  _collectionNfeCompletoNotaClassNfeCompletoLoteOriginal= (from a in _valueCollectionNfeCompletoNotaClassNfeCompletoLote select a.ID).ToList();
                  _valueCollectionNfeCompletoNotaClassNfeCompletoLoteChanged = false;
                  _valueCollectionNfeCompletoNotaClassNfeCompletoLoteCommitedChanged = false;
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
               NumeroLote=_numeroLoteOriginal;
               _numeroLoteOriginalCommited=_numeroLoteOriginal;
               Recibo=_reciboOriginal;
               _reciboOriginalCommited=_reciboOriginal;
               DataEnvio=_dataEnvioOriginal;
               _dataEnvioOriginalCommited=_dataEnvioOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               ResultadoObs=_resultadoObsOriginal;
               _resultadoObsOriginalCommited=_resultadoObsOriginal;
               CnpjTransmissor=_cnpjTransmissorOriginal;
               _cnpjTransmissorOriginalCommited=_cnpjTransmissorOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Scan=_scanOriginal;
               _scanOriginalCommited=_scanOriginal;
               Homologacao=_homologacaoOriginal;
               _homologacaoOriginalCommited=_homologacaoOriginal;
               Modelo=_modeloOriginal;
               _modeloOriginalCommited=_modeloOriginal;
               if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded) 
               {
                  CollectionNfeCompletoNotaClassNfeCompletoLote.Clear();
                  foreach(int item in _collectionNfeCompletoNotaClassNfeCompletoLoteOriginal)
                  {
                    CollectionNfeCompletoNotaClassNfeCompletoLote.Add(Entidades.NfeCompletoNotaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfeCompletoNotaClassNfeCompletoLoteRemovidos.Clear();
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
               if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded) 
               {
                  if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded) 
               {
                   tempRet = CollectionNfeCompletoNotaClassNfeCompletoLote.Any(item => item.IsDirty());
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
       dirty = _numeroLoteOriginal != NumeroLote;
      if (dirty) return true;
       dirty = _reciboOriginal != Recibo;
      if (dirty) return true;
       dirty = _dataEnvioOriginal != DataEnvio;
      if (dirty) return true;
       dirty = _situacaoOriginal != Situacao;
      if (dirty) return true;
       dirty = _resultadoObsOriginal != ResultadoObs;
      if (dirty) return true;
       dirty = _cnpjTransmissorOriginal != CnpjTransmissor;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _scanOriginal != Scan;
      if (dirty) return true;
       dirty = _homologacaoOriginal != Homologacao;
      if (dirty) return true;
       dirty = _modeloOriginal != Modelo;

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
               if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded) 
               {
                  if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded) 
               {
                   tempRet = CollectionNfeCompletoNotaClassNfeCompletoLote.Any(item => item.IsDirtyCommited());
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
       dirty = _numeroLoteOriginalCommited != NumeroLote;
      if (dirty) return true;
       dirty = _reciboOriginalCommited != Recibo;
      if (dirty) return true;
       dirty = _dataEnvioOriginalCommited != DataEnvio;
      if (dirty) return true;
       dirty = _situacaoOriginalCommited != Situacao;
      if (dirty) return true;
       dirty = _resultadoObsOriginalCommited != ResultadoObs;
      if (dirty) return true;
       dirty = _cnpjTransmissorOriginalCommited != CnpjTransmissor;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _scanOriginalCommited != Scan;
      if (dirty) return true;
       dirty = _homologacaoOriginalCommited != Homologacao;
      if (dirty) return true;
       dirty = _modeloOriginalCommited != Modelo;

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
               if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded) 
               {
                  foreach(NfeCompletoNotaClass item in CollectionNfeCompletoNotaClassNfeCompletoLote)
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
             case "NumeroLote":
                return this.NumeroLote;
             case "Recibo":
                return this.Recibo;
             case "DataEnvio":
                return this.DataEnvio;
             case "Situacao":
                return this.Situacao;
             case "ResultadoObs":
                return this.ResultadoObs;
             case "CnpjTransmissor":
                return this.CnpjTransmissor;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Scan":
                return this.Scan;
             case "Homologacao":
                return this.Homologacao;
             case "Modelo":
                return this.Modelo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionNfeCompletoNotaClassNfeCompletoLoteLoaded) 
               {
                  foreach(NfeCompletoNotaClass item in CollectionNfeCompletoNotaClassNfeCompletoLote)
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
                  command.CommandText += " COUNT(nfe_completo_lote.id_nfe_completo_lote) " ;
               }
               else
               {
               command.CommandText += "nfe_completo_lote.id_nfe_completo_lote, " ;
               command.CommandText += "nfe_completo_lote.ncl_numero_lote, " ;
               command.CommandText += "nfe_completo_lote.ncl_recibo, " ;
               command.CommandText += "nfe_completo_lote.ncl_data_envio, " ;
               command.CommandText += "nfe_completo_lote.ncl_situacao, " ;
               command.CommandText += "nfe_completo_lote.ncl_resultado_obs, " ;
               command.CommandText += "nfe_completo_lote.ncl_cnpj_transmissor, " ;
               command.CommandText += "nfe_completo_lote.entity_uid, " ;
               command.CommandText += "nfe_completo_lote.version, " ;
               command.CommandText += "nfe_completo_lote.ncl_scan, " ;
               command.CommandText += "nfe_completo_lote.ncl_homologacao, " ;
               command.CommandText += "nfe_completo_lote.ncl_modelo " ;
               }
               command.CommandText += " FROM  nfe_completo_lote ";
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
                        orderByClause += " , ncl_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ncl_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nfe_completo_lote.id_acs_usuario_ultima_revisao ";
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
                     case "id_nfe_completo_lote":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_lote.id_nfe_completo_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_lote.id_nfe_completo_lote) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncl_numero_lote":
                     case "NumeroLote":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_lote.ncl_numero_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_lote.ncl_numero_lote) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncl_recibo":
                     case "Recibo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_lote.ncl_recibo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_lote.ncl_recibo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncl_data_envio":
                     case "DataEnvio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_lote.ncl_data_envio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_lote.ncl_data_envio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncl_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_lote.ncl_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_lote.ncl_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncl_resultado_obs":
                     case "ResultadoObs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_lote.ncl_resultado_obs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_lote.ncl_resultado_obs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncl_cnpj_transmissor":
                     case "CnpjTransmissor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_lote.ncl_cnpj_transmissor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_lote.ncl_cnpj_transmissor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_lote.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_lote.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nfe_completo_lote.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_lote.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncl_scan":
                     case "Scan":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_lote.ncl_scan " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_lote.ncl_scan) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncl_homologacao":
                     case "Homologacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_lote.ncl_homologacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_lote.ncl_homologacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncl_modelo":
                     case "Modelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_lote.ncl_modelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_lote.ncl_modelo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncl_recibo")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_lote.ncl_recibo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_lote.ncl_recibo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncl_resultado_obs")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_lote.ncl_resultado_obs) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_lote.ncl_resultado_obs) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncl_cnpj_transmissor")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_lote.ncl_cnpj_transmissor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_lote.ncl_cnpj_transmissor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_lote.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_lote.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncl_modelo")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_lote.ncl_modelo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_lote.ncl_modelo) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nfe_completo_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.id_nfe_completo_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.id_nfe_completo_lote = :nfe_completo_lote_ID_2502 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_ID_2502", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroLote" || parametro.FieldName == "ncl_numero_lote")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_numero_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_numero_lote = :nfe_completo_lote_NumeroLote_1136 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_NumeroLote_1136", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Recibo" || parametro.FieldName == "ncl_recibo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_recibo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_recibo LIKE :nfe_completo_lote_Recibo_6975 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_Recibo_6975", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEnvio" || parametro.FieldName == "ncl_data_envio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_data_envio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_data_envio = :nfe_completo_lote_DataEnvio_1934 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_DataEnvio_1934", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "ncl_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SituacaoLote)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SituacaoLote");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_situacao = :nfe_completo_lote_Situacao_9341 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_Situacao_9341", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ResultadoObs" || parametro.FieldName == "ncl_resultado_obs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_resultado_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_resultado_obs LIKE :nfe_completo_lote_ResultadoObs_2341 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_ResultadoObs_2341", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjTransmissor" || parametro.FieldName == "ncl_cnpj_transmissor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_cnpj_transmissor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_cnpj_transmissor LIKE :nfe_completo_lote_CnpjTransmissor_7194 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_CnpjTransmissor_7194", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_completo_lote.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.entity_uid LIKE :nfe_completo_lote_EntityUid_8432 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_EntityUid_8432", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_completo_lote.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.version = :nfe_completo_lote_Version_1069 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_Version_1069", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Scan" || parametro.FieldName == "ncl_scan")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_scan IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_scan = :nfe_completo_lote_Scan_1146 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_Scan_1146", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Homologacao" || parametro.FieldName == "ncl_homologacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_homologacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_homologacao = :nfe_completo_lote_Homologacao_3029 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_Homologacao_3029", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Modelo" || parametro.FieldName == "ncl_modelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_modelo LIKE :nfe_completo_lote_Modelo_2025 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_Modelo_2025", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ReciboExato" || parametro.FieldName == "ReciboExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_recibo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_recibo LIKE :nfe_completo_lote_Recibo_7845 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_Recibo_7845", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ResultadoObsExato" || parametro.FieldName == "ResultadoObsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_resultado_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_resultado_obs LIKE :nfe_completo_lote_ResultadoObs_6649 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_ResultadoObs_6649", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjTransmissorExato" || parametro.FieldName == "CnpjTransmissorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_cnpj_transmissor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_cnpj_transmissor LIKE :nfe_completo_lote_CnpjTransmissor_2048 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_CnpjTransmissor_2048", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_completo_lote.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.entity_uid LIKE :nfe_completo_lote_EntityUid_3472 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_EntityUid_3472", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloExato" || parametro.FieldName == "ModeloExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_lote.ncl_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_lote.ncl_modelo LIKE :nfe_completo_lote_Modelo_7623 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_lote_Modelo_7623", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfeCompletoLoteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfeCompletoLoteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfeCompletoLoteClass), Convert.ToInt32(read["id_nfe_completo_lote"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfeCompletoLoteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nfe_completo_lote"]);
                     entidade.NumeroLote = (int)read["ncl_numero_lote"];
                     entidade.Recibo = (read["ncl_recibo"] != DBNull.Value ? read["ncl_recibo"].ToString() : null);
                     entidade.DataEnvio = (DateTime)read["ncl_data_envio"];
                     entidade.Situacao = (SituacaoLote) (read["ncl_situacao"] != DBNull.Value ? Enum.ToObject(typeof(SituacaoLote), read["ncl_situacao"]) : null);
                     entidade.ResultadoObs = (read["ncl_resultado_obs"] != DBNull.Value ? read["ncl_resultado_obs"].ToString() : null);
                     entidade.CnpjTransmissor = (read["ncl_cnpj_transmissor"] != DBNull.Value ? read["ncl_cnpj_transmissor"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Scan = Convert.ToBoolean(Convert.ToInt16(read["ncl_scan"]));
                     entidade.Homologacao = Convert.ToBoolean(Convert.ToInt16(read["ncl_homologacao"]));
                     entidade.Modelo = (read["ncl_modelo"] != DBNull.Value ? read["ncl_modelo"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfeCompletoLoteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
