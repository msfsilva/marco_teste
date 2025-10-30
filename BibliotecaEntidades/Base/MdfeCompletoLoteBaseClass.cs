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
     [Table("mdfe_completo_lote","mcl")]
     public class MdfeCompletoLoteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MdfeCompletoLoteClass";
protected const string ErroDelete = "Erro ao excluir o MdfeCompletoLoteClass  ";
protected const string ErroSave = "Erro ao salvar o MdfeCompletoLoteClass.";
protected const string ErroCollectionMdfeCompletoMdfeClassMdfeCompletoLote = "Erro ao carregar a coleção de MdfeCompletoMdfeClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCnpjEmissorObrigatorio = "O campo CnpjEmissor é obrigatório";
protected const string ErroCnpjEmissorComprimento = "O campo CnpjEmissor deve ter no máximo 14 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do MdfeCompletoLoteClass.";
protected const string MensagemUtilizadoCollectionMdfeCompletoMdfeClassMdfeCompletoLote =  "A entidade MdfeCompletoLoteClass está sendo utilizada nos seguintes MdfeCompletoMdfeClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeCompletoLoteClass está sendo utilizada.";
#endregion
       protected int _numeroLoteOriginal{get;private set;}
       private int _numeroLoteOriginalCommited{get; set;}
        private int _valueNumeroLote;
         [Column("mcl_numero_lote")]
        public virtual int NumeroLote
         { 
            get { return this._valueNumeroLote; } 
            set 
            { 
                if (this._valueNumeroLote == value)return;
                 this._valueNumeroLote = value; 
            } 
        } 

       protected string _versaoOriginal{get;private set;}
       private string _versaoOriginalCommited{get; set;}
        private string _valueVersao;
         [Column("mcl_versao")]
        public virtual string Versao
         { 
            get { return this._valueVersao; } 
            set 
            { 
                if (this._valueVersao == value)return;
                 this._valueVersao = value; 
            } 
        } 

       protected string _ufAtendeuOriginal{get;private set;}
       private string _ufAtendeuOriginalCommited{get; set;}
        private string _valueUfAtendeu;
         [Column("mcl_uf_atendeu")]
        public virtual string UfAtendeu
         { 
            get { return this._valueUfAtendeu; } 
            set 
            { 
                if (this._valueUfAtendeu == value)return;
                 this._valueUfAtendeu = value; 
            } 
        } 

       protected string _versaoAplicativoOriginal{get;private set;}
       private string _versaoAplicativoOriginalCommited{get; set;}
        private string _valueVersaoAplicativo;
         [Column("mcl_versao_aplicativo")]
        public virtual string VersaoAplicativo
         { 
            get { return this._valueVersaoAplicativo; } 
            set 
            { 
                if (this._valueVersaoAplicativo == value)return;
                 this._valueVersaoAplicativo = value; 
            } 
        } 

       protected string _motivoOriginal{get;private set;}
       private string _motivoOriginalCommited{get; set;}
        private string _valueMotivo;
         [Column("mcl_motivo")]
        public virtual string Motivo
         { 
            get { return this._valueMotivo; } 
            set 
            { 
                if (this._valueMotivo == value)return;
                 this._valueMotivo = value; 
            } 
        } 

       protected string _numeroReciboOriginal{get;private set;}
       private string _numeroReciboOriginalCommited{get; set;}
        private string _valueNumeroRecibo;
         [Column("mcl_numero_recibo")]
        public virtual string NumeroRecibo
         { 
            get { return this._valueNumeroRecibo; } 
            set 
            { 
                if (this._valueNumeroRecibo == value)return;
                 this._valueNumeroRecibo = value; 
            } 
        } 

       protected string _cnpjEmissorOriginal{get;private set;}
       private string _cnpjEmissorOriginalCommited{get; set;}
        private string _valueCnpjEmissor;
         [Column("mcl_cnpj_emissor")]
        public virtual string CnpjEmissor
         { 
            get { return this._valueCnpjEmissor; } 
            set 
            { 
                if (this._valueCnpjEmissor == value)return;
                 this._valueCnpjEmissor = value; 
            } 
        } 

       protected DateTime? _dataRecebimentoOriginal{get;private set;}
       private DateTime? _dataRecebimentoOriginalCommited{get; set;}
        private DateTime? _valueDataRecebimento;
         [Column("mcl_data_recebimento")]
        public virtual DateTime? DataRecebimento
         { 
            get { return this._valueDataRecebimento; } 
            set 
            { 
                if (this._valueDataRecebimento == value)return;
                 this._valueDataRecebimento = value; 
            } 
        } 

       protected bool _homologacaoOriginal{get;private set;}
       private bool _homologacaoOriginalCommited{get; set;}
        private bool _valueHomologacao;
         [Column("mcl_homologacao")]
        public virtual bool Homologacao
         { 
            get { return this._valueHomologacao; } 
            set 
            { 
                if (this._valueHomologacao == value)return;
                 this._valueHomologacao = value; 
            } 
        } 

       protected MDFeSituacaoLote _situacaoOriginal{get;private set;}
       private MDFeSituacaoLote _situacaoOriginalCommited{get; set;}
        private MDFeSituacaoLote _valueSituacao;
         [Column("mcl_situacao")]
        public virtual MDFeSituacaoLote Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

        public bool Situacao_Contingencia
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoLote.Contingencia; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoLote.Contingencia; }
         } 

        public bool Situacao_Enviado
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoLote.Enviado; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoLote.Enviado; }
         } 

        public bool Situacao_Processado
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoLote.Processado; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoLote.Processado; }
         } 

       private List<long> _collectionMdfeCompletoMdfeClassMdfeCompletoLoteOriginal;
       private List<Entidades.MdfeCompletoMdfeClass > _collectionMdfeCompletoMdfeClassMdfeCompletoLoteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfeCompletoMdfeClass> _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLote { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfeCompletoMdfeClass> CollectionMdfeCompletoMdfeClassMdfeCompletoLote 
       { 
           get { if(!_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfeCompletoMdfeClassMdfeCompletoLote();}
return this._valueCollectionMdfeCompletoMdfeClassMdfeCompletoLote; } 
           set 
           { 
               this._valueCollectionMdfeCompletoMdfeClassMdfeCompletoLote = value; 
               this._valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded = true; 
           } 
       } 

        public MdfeCompletoLoteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Homologacao = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static MdfeCompletoLoteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MdfeCompletoLoteClass) GetEntity(typeof(MdfeCompletoLoteClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionMdfeCompletoMdfeClassMdfeCompletoLoteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteChanged = true;
                  _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteChanged = true; 
                  _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteCommitedChanged = true;
                 foreach (Entidades.MdfeCompletoMdfeClass item in e.OldItems) 
                 { 
                     _collectionMdfeCompletoMdfeClassMdfeCompletoLoteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteChanged = true; 
                  _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteCommitedChanged = true;
                 foreach (Entidades.MdfeCompletoMdfeClass item in _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLote) 
                 { 
                     _collectionMdfeCompletoMdfeClassMdfeCompletoLoteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfeCompletoMdfeClassMdfeCompletoLote()
         {
            try
            {
                 ObservableCollection<Entidades.MdfeCompletoMdfeClass> oc;
                _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteChanged = false;
                 _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteCommitedChanged = false;
                _collectionMdfeCompletoMdfeClassMdfeCompletoLoteRemovidos = new List<Entidades.MdfeCompletoMdfeClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfeCompletoMdfeClass>();
                }
                else{ 
                   Entidades.MdfeCompletoMdfeClass search = new Entidades.MdfeCompletoMdfeClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfeCompletoMdfeClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MdfeCompletoLote", this),                     }                       ).Cast<Entidades.MdfeCompletoMdfeClass>().ToList());
                 }
                 _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLote = new BindingList<Entidades.MdfeCompletoMdfeClass>(oc); 
                 _collectionMdfeCompletoMdfeClassMdfeCompletoLoteOriginal= (from a in _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLote select a.ID).ToList();
                 _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded = true;
                 oc.CollectionChanged += CollectionMdfeCompletoMdfeClassMdfeCompletoLoteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfeCompletoMdfeClassMdfeCompletoLote+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CnpjEmissor))
                {
                    throw new Exception(ErroCnpjEmissorObrigatorio);
                }
                if (CnpjEmissor.Length >14)
                {
                    throw new Exception( ErroCnpjEmissorComprimento);
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
                    "  public.mdfe_completo_lote  " +
                    "WHERE " +
                    "  id_mdfe_completo_lote = :id";
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
                        "  public.mdfe_completo_lote   " +
                        "SET  " + 
                        "  mcl_numero_lote = :mcl_numero_lote, " + 
                        "  mcl_versao = :mcl_versao, " + 
                        "  mcl_uf_atendeu = :mcl_uf_atendeu, " + 
                        "  mcl_versao_aplicativo = :mcl_versao_aplicativo, " + 
                        "  mcl_motivo = :mcl_motivo, " + 
                        "  mcl_numero_recibo = :mcl_numero_recibo, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  mcl_cnpj_emissor = :mcl_cnpj_emissor, " + 
                        "  mcl_data_recebimento = :mcl_data_recebimento, " + 
                        "  mcl_homologacao = :mcl_homologacao, " + 
                        "  mcl_situacao = :mcl_situacao "+
                        "WHERE  " +
                        "  id_mdfe_completo_lote = :id " +
                        "RETURNING id_mdfe_completo_lote;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.mdfe_completo_lote " +
                        "( " +
                        "  mcl_numero_lote , " + 
                        "  mcl_versao , " + 
                        "  mcl_uf_atendeu , " + 
                        "  mcl_versao_aplicativo , " + 
                        "  mcl_motivo , " + 
                        "  mcl_numero_recibo , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  mcl_cnpj_emissor , " + 
                        "  mcl_data_recebimento , " + 
                        "  mcl_homologacao , " + 
                        "  mcl_situacao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :mcl_numero_lote , " + 
                        "  :mcl_versao , " + 
                        "  :mcl_uf_atendeu , " + 
                        "  :mcl_versao_aplicativo , " + 
                        "  :mcl_motivo , " + 
                        "  :mcl_numero_recibo , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :mcl_cnpj_emissor , " + 
                        "  :mcl_data_recebimento , " + 
                        "  :mcl_homologacao , " + 
                        "  :mcl_situacao  "+
                        ")RETURNING id_mdfe_completo_lote;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_numero_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroLote ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_versao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Versao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_uf_atendeu", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfAtendeu ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_versao_aplicativo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoAplicativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_motivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Motivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_numero_recibo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroRecibo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_cnpj_emissor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjEmissor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_data_recebimento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_homologacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Homologacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcl_situacao", NpgsqlDbType.Smallint));
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
 if (CollectionMdfeCompletoMdfeClassMdfeCompletoLote.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfeCompletoMdfeClassMdfeCompletoLote+"\r\n";
                foreach (Entidades.MdfeCompletoMdfeClass tmp in CollectionMdfeCompletoMdfeClassMdfeCompletoLote)
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
        public static MdfeCompletoLoteClass CopiarEntidade(MdfeCompletoLoteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MdfeCompletoLoteClass toRet = new MdfeCompletoLoteClass(usuario,conn);
 toRet.NumeroLote= entidadeCopiar.NumeroLote;
 toRet.Versao= entidadeCopiar.Versao;
 toRet.UfAtendeu= entidadeCopiar.UfAtendeu;
 toRet.VersaoAplicativo= entidadeCopiar.VersaoAplicativo;
 toRet.Motivo= entidadeCopiar.Motivo;
 toRet.NumeroRecibo= entidadeCopiar.NumeroRecibo;
 toRet.CnpjEmissor= entidadeCopiar.CnpjEmissor;
 toRet.DataRecebimento= entidadeCopiar.DataRecebimento;
 toRet.Homologacao= entidadeCopiar.Homologacao;
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
       _numeroLoteOriginal = NumeroLote;
       _numeroLoteOriginalCommited = _numeroLoteOriginal;
       _versaoOriginal = Versao;
       _versaoOriginalCommited = _versaoOriginal;
       _ufAtendeuOriginal = UfAtendeu;
       _ufAtendeuOriginalCommited = _ufAtendeuOriginal;
       _versaoAplicativoOriginal = VersaoAplicativo;
       _versaoAplicativoOriginalCommited = _versaoAplicativoOriginal;
       _motivoOriginal = Motivo;
       _motivoOriginalCommited = _motivoOriginal;
       _numeroReciboOriginal = NumeroRecibo;
       _numeroReciboOriginalCommited = _numeroReciboOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _cnpjEmissorOriginal = CnpjEmissor;
       _cnpjEmissorOriginalCommited = _cnpjEmissorOriginal;
       _dataRecebimentoOriginal = DataRecebimento;
       _dataRecebimentoOriginalCommited = _dataRecebimentoOriginal;
       _homologacaoOriginal = Homologacao;
       _homologacaoOriginalCommited = _homologacaoOriginal;
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
       _numeroLoteOriginalCommited = NumeroLote;
       _versaoOriginalCommited = Versao;
       _ufAtendeuOriginalCommited = UfAtendeu;
       _versaoAplicativoOriginalCommited = VersaoAplicativo;
       _motivoOriginalCommited = Motivo;
       _numeroReciboOriginalCommited = NumeroRecibo;
       _versionOriginalCommited = Version;
       _cnpjEmissorOriginalCommited = CnpjEmissor;
       _dataRecebimentoOriginalCommited = DataRecebimento;
       _homologacaoOriginalCommited = Homologacao;
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
               if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded) 
               {
                  if (_collectionMdfeCompletoMdfeClassMdfeCompletoLoteRemovidos != null) 
                  {
                     _collectionMdfeCompletoMdfeClassMdfeCompletoLoteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfeCompletoMdfeClassMdfeCompletoLoteRemovidos = new List<Entidades.MdfeCompletoMdfeClass>();
                  }
                  _collectionMdfeCompletoMdfeClassMdfeCompletoLoteOriginal= (from a in _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLote select a.ID).ToList();
                  _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteChanged = false;
                  _valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteCommitedChanged = false;
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
               Versao=_versaoOriginal;
               _versaoOriginalCommited=_versaoOriginal;
               UfAtendeu=_ufAtendeuOriginal;
               _ufAtendeuOriginalCommited=_ufAtendeuOriginal;
               VersaoAplicativo=_versaoAplicativoOriginal;
               _versaoAplicativoOriginalCommited=_versaoAplicativoOriginal;
               Motivo=_motivoOriginal;
               _motivoOriginalCommited=_motivoOriginal;
               NumeroRecibo=_numeroReciboOriginal;
               _numeroReciboOriginalCommited=_numeroReciboOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CnpjEmissor=_cnpjEmissorOriginal;
               _cnpjEmissorOriginalCommited=_cnpjEmissorOriginal;
               DataRecebimento=_dataRecebimentoOriginal;
               _dataRecebimentoOriginalCommited=_dataRecebimentoOriginal;
               Homologacao=_homologacaoOriginal;
               _homologacaoOriginalCommited=_homologacaoOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded) 
               {
                  CollectionMdfeCompletoMdfeClassMdfeCompletoLote.Clear();
                  foreach(int item in _collectionMdfeCompletoMdfeClassMdfeCompletoLoteOriginal)
                  {
                    CollectionMdfeCompletoMdfeClassMdfeCompletoLote.Add(Entidades.MdfeCompletoMdfeClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfeCompletoMdfeClassMdfeCompletoLoteRemovidos.Clear();
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
               if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded) 
               {
                  if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded) 
               {
                   tempRet = CollectionMdfeCompletoMdfeClassMdfeCompletoLote.Any(item => item.IsDirty());
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
       dirty = _versaoOriginal != Versao;
      if (dirty) return true;
       dirty = _ufAtendeuOriginal != UfAtendeu;
      if (dirty) return true;
       dirty = _versaoAplicativoOriginal != VersaoAplicativo;
      if (dirty) return true;
       dirty = _motivoOriginal != Motivo;
      if (dirty) return true;
       dirty = _numeroReciboOriginal != NumeroRecibo;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cnpjEmissorOriginal != CnpjEmissor;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginal != DataRecebimento;
      if (dirty) return true;
       dirty = _homologacaoOriginal != Homologacao;
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
               if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded) 
               {
                  if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded) 
               {
                   tempRet = CollectionMdfeCompletoMdfeClassMdfeCompletoLote.Any(item => item.IsDirtyCommited());
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
       dirty = _versaoOriginalCommited != Versao;
      if (dirty) return true;
       dirty = _ufAtendeuOriginalCommited != UfAtendeu;
      if (dirty) return true;
       dirty = _versaoAplicativoOriginalCommited != VersaoAplicativo;
      if (dirty) return true;
       dirty = _motivoOriginalCommited != Motivo;
      if (dirty) return true;
       dirty = _numeroReciboOriginalCommited != NumeroRecibo;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cnpjEmissorOriginalCommited != CnpjEmissor;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginalCommited != DataRecebimento;
      if (dirty) return true;
       dirty = _homologacaoOriginalCommited != Homologacao;
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
               if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded) 
               {
                  foreach(MdfeCompletoMdfeClass item in CollectionMdfeCompletoMdfeClassMdfeCompletoLote)
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
             case "Versao":
                return this.Versao;
             case "UfAtendeu":
                return this.UfAtendeu;
             case "VersaoAplicativo":
                return this.VersaoAplicativo;
             case "Motivo":
                return this.Motivo;
             case "NumeroRecibo":
                return this.NumeroRecibo;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "CnpjEmissor":
                return this.CnpjEmissor;
             case "DataRecebimento":
                return this.DataRecebimento;
             case "Homologacao":
                return this.Homologacao;
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
               if (_valueCollectionMdfeCompletoMdfeClassMdfeCompletoLoteLoaded) 
               {
                  foreach(MdfeCompletoMdfeClass item in CollectionMdfeCompletoMdfeClassMdfeCompletoLote)
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
                  command.CommandText += " COUNT(mdfe_completo_lote.id_mdfe_completo_lote) " ;
               }
               else
               {
               command.CommandText += "mdfe_completo_lote.id_mdfe_completo_lote, " ;
               command.CommandText += "mdfe_completo_lote.mcl_numero_lote, " ;
               command.CommandText += "mdfe_completo_lote.mcl_versao, " ;
               command.CommandText += "mdfe_completo_lote.mcl_uf_atendeu, " ;
               command.CommandText += "mdfe_completo_lote.mcl_versao_aplicativo, " ;
               command.CommandText += "mdfe_completo_lote.mcl_motivo, " ;
               command.CommandText += "mdfe_completo_lote.mcl_numero_recibo, " ;
               command.CommandText += "mdfe_completo_lote.version, " ;
               command.CommandText += "mdfe_completo_lote.entity_uid, " ;
               command.CommandText += "mdfe_completo_lote.mcl_cnpj_emissor, " ;
               command.CommandText += "mdfe_completo_lote.mcl_data_recebimento, " ;
               command.CommandText += "mdfe_completo_lote.mcl_homologacao, " ;
               command.CommandText += "mdfe_completo_lote.mcl_situacao " ;
               }
               command.CommandText += " FROM  mdfe_completo_lote ";
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
                        orderByClause += " , mcl_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mcl_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = mdfe_completo_lote.id_acs_usuario_ultima_revisao ";
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
                     case "id_mdfe_completo_lote":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_lote.id_mdfe_completo_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_lote.id_mdfe_completo_lote) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_numero_lote":
                     case "NumeroLote":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_lote.mcl_numero_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_numero_lote) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_versao":
                     case "Versao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_lote.mcl_versao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_versao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_uf_atendeu":
                     case "UfAtendeu":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_lote.mcl_uf_atendeu " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_uf_atendeu) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_versao_aplicativo":
                     case "VersaoAplicativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_lote.mcl_versao_aplicativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_versao_aplicativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_motivo":
                     case "Motivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_lote.mcl_motivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_motivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_numero_recibo":
                     case "NumeroRecibo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_lote.mcl_numero_recibo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_numero_recibo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , mdfe_completo_lote.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_lote.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_lote.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_lote.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_cnpj_emissor":
                     case "CnpjEmissor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_lote.mcl_cnpj_emissor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_cnpj_emissor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_data_recebimento":
                     case "DataRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_lote.mcl_data_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_data_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_homologacao":
                     case "Homologacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_lote.mcl_homologacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_homologacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcl_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_lote.mcl_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_lote.mcl_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcl_versao")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_lote.mcl_versao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_lote.mcl_versao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcl_uf_atendeu")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_lote.mcl_uf_atendeu) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_lote.mcl_uf_atendeu) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcl_versao_aplicativo")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_lote.mcl_versao_aplicativo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_lote.mcl_versao_aplicativo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcl_motivo")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_lote.mcl_motivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_lote.mcl_motivo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcl_numero_recibo")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_lote.mcl_numero_recibo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_lote.mcl_numero_recibo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_lote.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_lote.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcl_cnpj_emissor")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_lote.mcl_cnpj_emissor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_lote.mcl_cnpj_emissor) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_mdfe_completo_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.id_mdfe_completo_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.id_mdfe_completo_lote = :mdfe_completo_lote_ID_6962 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_ID_6962", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroLote" || parametro.FieldName == "mcl_numero_lote")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_numero_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_numero_lote = :mdfe_completo_lote_NumeroLote_3229 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_NumeroLote_3229", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Versao" || parametro.FieldName == "mcl_versao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_versao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_versao LIKE :mdfe_completo_lote_Versao_8450 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_Versao_8450", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfAtendeu" || parametro.FieldName == "mcl_uf_atendeu")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_uf_atendeu IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_uf_atendeu LIKE :mdfe_completo_lote_UfAtendeu_1616 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_UfAtendeu_1616", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoAplicativo" || parametro.FieldName == "mcl_versao_aplicativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_versao_aplicativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_versao_aplicativo LIKE :mdfe_completo_lote_VersaoAplicativo_7143 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_VersaoAplicativo_7143", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Motivo" || parametro.FieldName == "mcl_motivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_motivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_motivo LIKE :mdfe_completo_lote_Motivo_1610 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_Motivo_1610", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroRecibo" || parametro.FieldName == "mcl_numero_recibo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_numero_recibo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_numero_recibo LIKE :mdfe_completo_lote_NumeroRecibo_6607 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_NumeroRecibo_6607", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  mdfe_completo_lote.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.version = :mdfe_completo_lote_Version_2641 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_Version_2641", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_completo_lote.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.entity_uid LIKE :mdfe_completo_lote_EntityUid_2922 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_EntityUid_2922", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjEmissor" || parametro.FieldName == "mcl_cnpj_emissor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_cnpj_emissor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_cnpj_emissor LIKE :mdfe_completo_lote_CnpjEmissor_7831 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_CnpjEmissor_7831", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRecebimento" || parametro.FieldName == "mcl_data_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_data_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_data_recebimento = :mdfe_completo_lote_DataRecebimento_6765 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_DataRecebimento_6765", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Homologacao" || parametro.FieldName == "mcl_homologacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_homologacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_homologacao = :mdfe_completo_lote_Homologacao_5089 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_Homologacao_5089", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "mcl_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeSituacaoLote)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeSituacaoLote");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_situacao = :mdfe_completo_lote_Situacao_4744 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_Situacao_4744", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoExato" || parametro.FieldName == "VersaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_versao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_versao LIKE :mdfe_completo_lote_Versao_2130 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_Versao_2130", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfAtendeuExato" || parametro.FieldName == "UfAtendeuExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_uf_atendeu IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_uf_atendeu LIKE :mdfe_completo_lote_UfAtendeu_3061 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_UfAtendeu_3061", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoAplicativoExato" || parametro.FieldName == "VersaoAplicativoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_versao_aplicativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_versao_aplicativo LIKE :mdfe_completo_lote_VersaoAplicativo_9946 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_VersaoAplicativo_9946", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoExato" || parametro.FieldName == "MotivoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_motivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_motivo LIKE :mdfe_completo_lote_Motivo_56 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_Motivo_56", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroReciboExato" || parametro.FieldName == "NumeroReciboExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_numero_recibo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_numero_recibo LIKE :mdfe_completo_lote_NumeroRecibo_5992 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_NumeroRecibo_5992", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_completo_lote.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.entity_uid LIKE :mdfe_completo_lote_EntityUid_15 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_EntityUid_15", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjEmissorExato" || parametro.FieldName == "CnpjEmissorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_lote.mcl_cnpj_emissor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_lote.mcl_cnpj_emissor LIKE :mdfe_completo_lote_CnpjEmissor_6803 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_lote_CnpjEmissor_6803", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MdfeCompletoLoteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MdfeCompletoLoteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MdfeCompletoLoteClass), Convert.ToInt32(read["id_mdfe_completo_lote"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MdfeCompletoLoteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_mdfe_completo_lote"]);
                     entidade.NumeroLote = (int)read["mcl_numero_lote"];
                     entidade.Versao = (read["mcl_versao"] != DBNull.Value ? read["mcl_versao"].ToString() : null);
                     entidade.UfAtendeu = (read["mcl_uf_atendeu"] != DBNull.Value ? read["mcl_uf_atendeu"].ToString() : null);
                     entidade.VersaoAplicativo = (read["mcl_versao_aplicativo"] != DBNull.Value ? read["mcl_versao_aplicativo"].ToString() : null);
                     entidade.Motivo = (read["mcl_motivo"] != DBNull.Value ? read["mcl_motivo"].ToString() : null);
                     entidade.NumeroRecibo = (read["mcl_numero_recibo"] != DBNull.Value ? read["mcl_numero_recibo"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.CnpjEmissor = (read["mcl_cnpj_emissor"] != DBNull.Value ? read["mcl_cnpj_emissor"].ToString() : null);
                     entidade.DataRecebimento = read["mcl_data_recebimento"] as DateTime?;
                     entidade.Homologacao = Convert.ToBoolean(Convert.ToInt16(read["mcl_homologacao"]));
                     entidade.Situacao = (MDFeSituacaoLote) (read["mcl_situacao"] != DBNull.Value ? Enum.ToObject(typeof(MDFeSituacaoLote), read["mcl_situacao"]) : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MdfeCompletoLoteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
