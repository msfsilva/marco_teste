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
using IWTNF.Entidades.Entidades; 
namespace IWTNFCompleto.BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("nfe_completo_nota","nfn")]
     public class NfeCompletoNotaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfeCompletoNotaClass";
protected const string ErroDelete = "Erro ao excluir o NfeCompletoNotaClass  ";
protected const string ErroSave = "Erro ao salvar o NfeCompletoNotaClass.";
protected const string ErroCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota = "Erro ao carregar a coleção de NfeCompletoCartaCorrecaoClass.";
protected const string ErroXmlObrigatorio = "O campo Xml é obrigatório";
protected const string ErroChaveObrigatorio = "O campo Chave é obrigatório";
protected const string ErroChaveComprimento = "O campo Chave deve ter no máximo 50 caracteres";
protected const string ErroCnpjEmitenteObrigatorio = "O campo CnpjEmitente é obrigatório";
protected const string ErroCnpjEmitenteComprimento = "O campo CnpjEmitente deve ter no máximo 50 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroModeloObrigatorio = "O campo Modelo é obrigatório";
protected const string ErroModeloComprimento = "O campo Modelo deve ter no máximo 10 caracteres";
protected const string ErroNfeCompletoLoteObrigatorio = "O campo NfeCompletoLote é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfeCompletoNotaClass.";
protected const string MensagemUtilizadoCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota =  "A entidade NfeCompletoNotaClass está sendo utilizada nos seguintes NfeCompletoCartaCorrecaoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfeCompletoNotaClass está sendo utilizada.";
#endregion
       protected IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoLoteClass _nfeCompletoLoteOriginal{get;private set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoLoteClass _nfeCompletoLoteOriginalCommited {get; set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoLoteClass _valueNfeCompletoLote;
        [Column("id_nfe_completo_lote", "nfe_completo_lote", "id_nfe_completo_lote")]
       public virtual IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoLoteClass NfeCompletoLote
        { 
           get {                 return this._valueNfeCompletoLote; } 
           set 
           { 
                if (this._valueNfeCompletoLote == value)return;
                 this._valueNfeCompletoLote = value; 
           } 
       } 

       protected int _numeroOriginal{get;private set;}
       private int _numeroOriginalCommited{get; set;}
        private int _valueNumero;
         [Column("nfn_numero")]
        public virtual int Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected string _xmlOriginal{get;private set;}
       private string _xmlOriginalCommited{get; set;}
        private string _valueXml;
         [Column("nfn_xml")]
        public virtual string Xml
         { 
            get { return this._valueXml; } 
            set 
            { 
                if (this._valueXml == value)return;
                 this._valueXml = value; 
            } 
        } 

       protected SituacaoNFe _situacaoOriginal{get;private set;}
       private SituacaoNFe _situacaoOriginalCommited{get; set;}
        private SituacaoNFe _valueSituacao;
         [Column("nfn_situacao")]
        public virtual SituacaoNFe Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

        public bool Situacao_Enviada
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Enviada; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Enviada; }
         } 

        public bool Situacao_Autorizada
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Autorizada; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Autorizada; }
         } 

        public bool Situacao_Denegada
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Denegada; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Denegada; }
         } 

        public bool Situacao_Cancelada
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Cancelada; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Cancelada; }
         } 

        public bool Situacao_NaoEncontrada
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.NaoEncontrada; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.NaoEncontrada; }
         } 

        public bool Situacao_Rejeitada
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Rejeitada; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.Rejeitada; }
         } 

        public bool Situacao_NFCeAguardandoEnvio
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.NFCeAguardandoEnvio; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.SituacaoNFe.NFCeAguardandoEnvio; }
         } 

       protected DateTime _dataSituacaoOriginal{get;private set;}
       private DateTime _dataSituacaoOriginalCommited{get; set;}
        private DateTime _valueDataSituacao;
         [Column("nfn_data_situacao")]
        public virtual DateTime DataSituacao
         { 
            get { return this._valueDataSituacao; } 
            set 
            { 
                if (this._valueDataSituacao == value)return;
                 this._valueDataSituacao = value; 
            } 
        } 

       protected string _situacaoObservacaoOriginal{get;private set;}
       private string _situacaoObservacaoOriginalCommited{get; set;}
        private string _valueSituacaoObservacao;
         [Column("nfn_situacao_observacao")]
        public virtual string SituacaoObservacao
         { 
            get { return this._valueSituacaoObservacao; } 
            set 
            { 
                if (this._valueSituacaoObservacao == value)return;
                 this._valueSituacaoObservacao = value; 
            } 
        } 

       protected bool _danfeImpressaOriginal{get;private set;}
       private bool _danfeImpressaOriginalCommited{get; set;}
        private bool _valueDanfeImpressa;
         [Column("nfn_danfe_impressa")]
        public virtual bool DanfeImpressa
         { 
            get { return this._valueDanfeImpressa; } 
            set 
            { 
                if (this._valueDanfeImpressa == value)return;
                 this._valueDanfeImpressa = value; 
            } 
        } 

       protected bool _xmlGeradoOriginal{get;private set;}
       private bool _xmlGeradoOriginalCommited{get; set;}
        private bool _valueXmlGerado;
         [Column("nfn_xml_gerado")]
        public virtual bool XmlGerado
         { 
            get { return this._valueXmlGerado; } 
            set 
            { 
                if (this._valueXmlGerado == value)return;
                 this._valueXmlGerado = value; 
            } 
        } 

       protected string _chaveOriginal{get;private set;}
       private string _chaveOriginalCommited{get; set;}
        private string _valueChave;
         [Column("nfn_chave")]
        public virtual string Chave
         { 
            get { return this._valueChave; } 
            set 
            { 
                if (this._valueChave == value)return;
                 this._valueChave = value; 
            } 
        } 

       protected DateTime _dataEmissaoOriginal{get;private set;}
       private DateTime _dataEmissaoOriginalCommited{get; set;}
        private DateTime _valueDataEmissao;
         [Column("nfn_data_emissao")]
        public virtual DateTime DataEmissao
         { 
            get { return this._valueDataEmissao; } 
            set 
            { 
                if (this._valueDataEmissao == value)return;
                 this._valueDataEmissao = value; 
            } 
        } 

       protected string _cnpjEmitenteOriginal{get;private set;}
       private string _cnpjEmitenteOriginalCommited{get; set;}
        private string _valueCnpjEmitente;
         [Column("nfn_cnpj_emitente")]
        public virtual string CnpjEmitente
         { 
            get { return this._valueCnpjEmitente; } 
            set 
            { 
                if (this._valueCnpjEmitente == value)return;
                 this._valueCnpjEmitente = value; 
            } 
        } 

       protected int _serieOriginal{get;private set;}
       private int _serieOriginalCommited{get; set;}
        private int _valueSerie;
         [Column("nfn_serie")]
        public virtual int Serie
         { 
            get { return this._valueSerie; } 
            set 
            { 
                if (this._valueSerie == value)return;
                 this._valueSerie = value; 
            } 
        } 

       protected string _xmlCancelamentoOriginal{get;private set;}
       private string _xmlCancelamentoOriginalCommited{get; set;}
        private string _valueXmlCancelamento;
         [Column("nfn_xml_cancelamento")]
        public virtual string XmlCancelamento
         { 
            get { return this._valueXmlCancelamento; } 
            set 
            { 
                if (this._valueXmlCancelamento == value)return;
                 this._valueXmlCancelamento = value; 
            } 
        } 

       protected DateTime? _dataCancelamentoOriginal{get;private set;}
       private DateTime? _dataCancelamentoOriginalCommited{get; set;}
        private DateTime? _valueDataCancelamento;
         [Column("nfn_data_cancelamento")]
        public virtual DateTime? DataCancelamento
         { 
            get { return this._valueDataCancelamento; } 
            set 
            { 
                if (this._valueDataCancelamento == value)return;
                 this._valueDataCancelamento = value; 
            } 
        } 

       protected string _justificativaCancelamentoOriginal{get;private set;}
       private string _justificativaCancelamentoOriginalCommited{get; set;}
        private string _valueJustificativaCancelamento;
         [Column("nfn_justificativa_cancelamento")]
        public virtual string JustificativaCancelamento
         { 
            get { return this._valueJustificativaCancelamento; } 
            set 
            { 
                if (this._valueJustificativaCancelamento == value)return;
                 this._valueJustificativaCancelamento = value; 
            } 
        } 

       protected string _usuarioCancelamentoOriginal{get;private set;}
       private string _usuarioCancelamentoOriginalCommited{get; set;}
        private string _valueUsuarioCancelamento;
         [Column("nfn_usuario_cancelamento")]
        public virtual string UsuarioCancelamento
         { 
            get { return this._valueUsuarioCancelamento; } 
            set 
            { 
                if (this._valueUsuarioCancelamento == value)return;
                 this._valueUsuarioCancelamento = value; 
            } 
        } 

       protected bool _homologacaoOriginal{get;private set;}
       private bool _homologacaoOriginalCommited{get; set;}
        private bool _valueHomologacao;
         [Column("nfn_homologacao")]
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
         [Column("nfn_modelo")]
        public virtual string Modelo
         { 
            get { return this._valueModelo; } 
            set 
            { 
                if (this._valueModelo == value)return;
                 this._valueModelo = value; 
            } 
        } 

       protected IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _valueNfPrincipal;
        [Column("id_nf_principal", "nf_principal", "id_nf_principal")]
       public virtual IWTNF.Entidades.Entidades.NfPrincipalClass NfPrincipal
        { 
           get {                 return this._valueNfPrincipal; } 
           set 
           { 
                if (this._valueNfPrincipal == value)return;
                 this._valueNfPrincipal = value; 
           } 
       } 

       private List<long> _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaOriginal;
       private List<Entidades.NfeCompletoCartaCorrecaoClass > _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfeCompletoCartaCorrecaoClass> _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfeCompletoCartaCorrecaoClass> CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota 
       { 
           get { if(!_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded && !this.DisableLoadCollection){this.LoadCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota();}
return this._valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota; } 
           set 
           { 
               this._valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota = value; 
               this._valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded = true; 
           } 
       } 

        public NfeCompletoNotaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Situacao = (SituacaoNFe)0;
           this.DanfeImpressa = false;
           this.XmlGerado = false;
           this.Homologacao = false;
           this.Modelo = "55";
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfeCompletoNotaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfeCompletoNotaClass) GetEntity(typeof(NfeCompletoNotaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaChanged = true;
                  _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaChanged = true; 
                  _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaCommitedChanged = true;
                 foreach (Entidades.NfeCompletoCartaCorrecaoClass item in e.OldItems) 
                 { 
                     _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaChanged = true; 
                  _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaCommitedChanged = true;
                 foreach (Entidades.NfeCompletoCartaCorrecaoClass item in _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota) 
                 { 
                     _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota()
         {
            try
            {
                 ObservableCollection<Entidades.NfeCompletoCartaCorrecaoClass> oc;
                _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaChanged = false;
                 _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaCommitedChanged = false;
                _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaRemovidos = new List<Entidades.NfeCompletoCartaCorrecaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfeCompletoCartaCorrecaoClass>();
                }
                else{ 
                   Entidades.NfeCompletoCartaCorrecaoClass search = new Entidades.NfeCompletoCartaCorrecaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfeCompletoCartaCorrecaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfeCompletoNota", this),                     }                       ).Cast<Entidades.NfeCompletoCartaCorrecaoClass>().ToList());
                 }
                 _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota = new BindingList<Entidades.NfeCompletoCartaCorrecaoClass>(oc); 
                 _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaOriginal= (from a in _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota select a.ID).ToList();
                 _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded = true;
                 oc.CollectionChanged += CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Xml))
                {
                    throw new Exception(ErroXmlObrigatorio);
                }
                if (string.IsNullOrEmpty(Chave))
                {
                    throw new Exception(ErroChaveObrigatorio);
                }
                if (Chave.Length >50)
                {
                    throw new Exception( ErroChaveComprimento);
                }
                if (string.IsNullOrEmpty(CnpjEmitente))
                {
                    throw new Exception(ErroCnpjEmitenteObrigatorio);
                }
                if (CnpjEmitente.Length >50)
                {
                    throw new Exception( ErroCnpjEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(Modelo))
                {
                    throw new Exception(ErroModeloObrigatorio);
                }
                if (Modelo.Length >10)
                {
                    throw new Exception( ErroModeloComprimento);
                }
                if ( _valueNfeCompletoLote == null)
                {
                    throw new Exception(ErroNfeCompletoLoteObrigatorio);
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
                    "  public.nfe_completo_nota  " +
                    "WHERE " +
                    "  id_nfe_completo_nota = :id";
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
                        "  public.nfe_completo_nota   " +
                        "SET  " + 
                        "  id_nfe_completo_lote = :id_nfe_completo_lote, " + 
                        "  nfn_numero = :nfn_numero, " + 
                        "  nfn_xml = :nfn_xml, " + 
                        "  nfn_situacao = :nfn_situacao, " + 
                        "  nfn_data_situacao = :nfn_data_situacao, " + 
                        "  nfn_situacao_observacao = :nfn_situacao_observacao, " + 
                        "  nfn_danfe_impressa = :nfn_danfe_impressa, " + 
                        "  nfn_xml_gerado = :nfn_xml_gerado, " + 
                        "  nfn_chave = :nfn_chave, " + 
                        "  nfn_data_emissao = :nfn_data_emissao, " + 
                        "  nfn_cnpj_emitente = :nfn_cnpj_emitente, " + 
                        "  nfn_serie = :nfn_serie, " + 
                        "  nfn_xml_cancelamento = :nfn_xml_cancelamento, " + 
                        "  nfn_data_cancelamento = :nfn_data_cancelamento, " + 
                        "  nfn_justificativa_cancelamento = :nfn_justificativa_cancelamento, " + 
                        "  nfn_usuario_cancelamento = :nfn_usuario_cancelamento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nfn_homologacao = :nfn_homologacao, " + 
                        "  nfn_modelo = :nfn_modelo, " + 
                        "  id_nf_principal = :id_nf_principal "+
                        "WHERE  " +
                        "  id_nfe_completo_nota = :id " +
                        "RETURNING id_nfe_completo_nota;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nfe_completo_nota " +
                        "( " +
                        "  id_nfe_completo_lote , " + 
                        "  nfn_numero , " + 
                        "  nfn_xml , " + 
                        "  nfn_situacao , " + 
                        "  nfn_data_situacao , " + 
                        "  nfn_situacao_observacao , " + 
                        "  nfn_danfe_impressa , " + 
                        "  nfn_xml_gerado , " + 
                        "  nfn_chave , " + 
                        "  nfn_data_emissao , " + 
                        "  nfn_cnpj_emitente , " + 
                        "  nfn_serie , " + 
                        "  nfn_xml_cancelamento , " + 
                        "  nfn_data_cancelamento , " + 
                        "  nfn_justificativa_cancelamento , " + 
                        "  nfn_usuario_cancelamento , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nfn_homologacao , " + 
                        "  nfn_modelo , " + 
                        "  id_nf_principal  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nfe_completo_lote , " + 
                        "  :nfn_numero , " + 
                        "  :nfn_xml , " + 
                        "  :nfn_situacao , " + 
                        "  :nfn_data_situacao , " + 
                        "  :nfn_situacao_observacao , " + 
                        "  :nfn_danfe_impressa , " + 
                        "  :nfn_xml_gerado , " + 
                        "  :nfn_chave , " + 
                        "  :nfn_data_emissao , " + 
                        "  :nfn_cnpj_emitente , " + 
                        "  :nfn_serie , " + 
                        "  :nfn_xml_cancelamento , " + 
                        "  :nfn_data_cancelamento , " + 
                        "  :nfn_justificativa_cancelamento , " + 
                        "  :nfn_usuario_cancelamento , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nfn_homologacao , " + 
                        "  :nfn_modelo , " + 
                        "  :id_nf_principal  "+
                        ")RETURNING id_nfe_completo_nota;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfeCompletoLote==null ? (object) DBNull.Value : this.NfeCompletoLote.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_xml", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Xml ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Situacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_data_situacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataSituacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_situacao_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SituacaoObservacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_danfe_impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DanfeImpressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_xml_gerado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.XmlGerado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_chave", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Chave ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_data_emissao", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_cnpj_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Serie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_xml_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.XmlCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_justificativa_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JustificativaCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_usuario_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UsuarioCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_homologacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Homologacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Modelo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;

 
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
 if (CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota+"\r\n";
                foreach (Entidades.NfeCompletoCartaCorrecaoClass tmp in CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota)
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
        public static NfeCompletoNotaClass CopiarEntidade(NfeCompletoNotaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfeCompletoNotaClass toRet = new NfeCompletoNotaClass(usuario,conn);
 toRet.NfeCompletoLote= entidadeCopiar.NfeCompletoLote;
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Xml= entidadeCopiar.Xml;
 toRet.Situacao= entidadeCopiar.Situacao;
 toRet.DataSituacao= entidadeCopiar.DataSituacao;
 toRet.SituacaoObservacao= entidadeCopiar.SituacaoObservacao;
 toRet.DanfeImpressa= entidadeCopiar.DanfeImpressa;
 toRet.XmlGerado= entidadeCopiar.XmlGerado;
 toRet.Chave= entidadeCopiar.Chave;
 toRet.DataEmissao= entidadeCopiar.DataEmissao;
 toRet.CnpjEmitente= entidadeCopiar.CnpjEmitente;
 toRet.Serie= entidadeCopiar.Serie;
 toRet.XmlCancelamento= entidadeCopiar.XmlCancelamento;
 toRet.DataCancelamento= entidadeCopiar.DataCancelamento;
 toRet.JustificativaCancelamento= entidadeCopiar.JustificativaCancelamento;
 toRet.UsuarioCancelamento= entidadeCopiar.UsuarioCancelamento;
 toRet.Homologacao= entidadeCopiar.Homologacao;
 toRet.Modelo= entidadeCopiar.Modelo;
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;

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
       _nfeCompletoLoteOriginal = NfeCompletoLote;
       _nfeCompletoLoteOriginalCommited = _nfeCompletoLoteOriginal;
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _xmlOriginal = Xml;
       _xmlOriginalCommited = _xmlOriginal;
       _situacaoOriginal = Situacao;
       _situacaoOriginalCommited = _situacaoOriginal;
       _dataSituacaoOriginal = DataSituacao;
       _dataSituacaoOriginalCommited = _dataSituacaoOriginal;
       _situacaoObservacaoOriginal = SituacaoObservacao;
       _situacaoObservacaoOriginalCommited = _situacaoObservacaoOriginal;
       _danfeImpressaOriginal = DanfeImpressa;
       _danfeImpressaOriginalCommited = _danfeImpressaOriginal;
       _xmlGeradoOriginal = XmlGerado;
       _xmlGeradoOriginalCommited = _xmlGeradoOriginal;
       _chaveOriginal = Chave;
       _chaveOriginalCommited = _chaveOriginal;
       _dataEmissaoOriginal = DataEmissao;
       _dataEmissaoOriginalCommited = _dataEmissaoOriginal;
       _cnpjEmitenteOriginal = CnpjEmitente;
       _cnpjEmitenteOriginalCommited = _cnpjEmitenteOriginal;
       _serieOriginal = Serie;
       _serieOriginalCommited = _serieOriginal;
       _xmlCancelamentoOriginal = XmlCancelamento;
       _xmlCancelamentoOriginalCommited = _xmlCancelamentoOriginal;
       _dataCancelamentoOriginal = DataCancelamento;
       _dataCancelamentoOriginalCommited = _dataCancelamentoOriginal;
       _justificativaCancelamentoOriginal = JustificativaCancelamento;
       _justificativaCancelamentoOriginalCommited = _justificativaCancelamentoOriginal;
       _usuarioCancelamentoOriginal = UsuarioCancelamento;
       _usuarioCancelamentoOriginalCommited = _usuarioCancelamentoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _homologacaoOriginal = Homologacao;
       _homologacaoOriginalCommited = _homologacaoOriginal;
       _modeloOriginal = Modelo;
       _modeloOriginalCommited = _modeloOriginal;
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;

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
       _nfeCompletoLoteOriginalCommited = NfeCompletoLote;
       _numeroOriginalCommited = Numero;
       _xmlOriginalCommited = Xml;
       _situacaoOriginalCommited = Situacao;
       _dataSituacaoOriginalCommited = DataSituacao;
       _situacaoObservacaoOriginalCommited = SituacaoObservacao;
       _danfeImpressaOriginalCommited = DanfeImpressa;
       _xmlGeradoOriginalCommited = XmlGerado;
       _chaveOriginalCommited = Chave;
       _dataEmissaoOriginalCommited = DataEmissao;
       _cnpjEmitenteOriginalCommited = CnpjEmitente;
       _serieOriginalCommited = Serie;
       _xmlCancelamentoOriginalCommited = XmlCancelamento;
       _dataCancelamentoOriginalCommited = DataCancelamento;
       _justificativaCancelamentoOriginalCommited = JustificativaCancelamento;
       _usuarioCancelamentoOriginalCommited = UsuarioCancelamento;
       _versionOriginalCommited = Version;
       _homologacaoOriginalCommited = Homologacao;
       _modeloOriginalCommited = Modelo;
       _nfPrincipalOriginalCommited = NfPrincipal;

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
               if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded) 
               {
                  if (_collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaRemovidos != null) 
                  {
                     _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaRemovidos = new List<Entidades.NfeCompletoCartaCorrecaoClass>();
                  }
                  _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaOriginal= (from a in _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota select a.ID).ToList();
                  _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaChanged = false;
                  _valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaCommitedChanged = false;
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
               NfeCompletoLote=_nfeCompletoLoteOriginal;
               _nfeCompletoLoteOriginalCommited=_nfeCompletoLoteOriginal;
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               Xml=_xmlOriginal;
               _xmlOriginalCommited=_xmlOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               DataSituacao=_dataSituacaoOriginal;
               _dataSituacaoOriginalCommited=_dataSituacaoOriginal;
               SituacaoObservacao=_situacaoObservacaoOriginal;
               _situacaoObservacaoOriginalCommited=_situacaoObservacaoOriginal;
               DanfeImpressa=_danfeImpressaOriginal;
               _danfeImpressaOriginalCommited=_danfeImpressaOriginal;
               XmlGerado=_xmlGeradoOriginal;
               _xmlGeradoOriginalCommited=_xmlGeradoOriginal;
               Chave=_chaveOriginal;
               _chaveOriginalCommited=_chaveOriginal;
               DataEmissao=_dataEmissaoOriginal;
               _dataEmissaoOriginalCommited=_dataEmissaoOriginal;
               CnpjEmitente=_cnpjEmitenteOriginal;
               _cnpjEmitenteOriginalCommited=_cnpjEmitenteOriginal;
               Serie=_serieOriginal;
               _serieOriginalCommited=_serieOriginal;
               XmlCancelamento=_xmlCancelamentoOriginal;
               _xmlCancelamentoOriginalCommited=_xmlCancelamentoOriginal;
               DataCancelamento=_dataCancelamentoOriginal;
               _dataCancelamentoOriginalCommited=_dataCancelamentoOriginal;
               JustificativaCancelamento=_justificativaCancelamentoOriginal;
               _justificativaCancelamentoOriginalCommited=_justificativaCancelamentoOriginal;
               UsuarioCancelamento=_usuarioCancelamentoOriginal;
               _usuarioCancelamentoOriginalCommited=_usuarioCancelamentoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Homologacao=_homologacaoOriginal;
               _homologacaoOriginalCommited=_homologacaoOriginal;
               Modelo=_modeloOriginal;
               _modeloOriginalCommited=_modeloOriginal;
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded) 
               {
                  CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota.Clear();
                  foreach(int item in _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaOriginal)
                  {
                    CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota.Add(Entidades.NfeCompletoCartaCorrecaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaRemovidos.Clear();
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
               if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded) 
               {
                  if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded) 
               {
                   tempRet = CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota.Any(item => item.IsDirty());
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
       if (_nfeCompletoLoteOriginal!=null)
       {
          dirty = !_nfeCompletoLoteOriginal.Equals(NfeCompletoLote);
       }
       else
       {
            dirty = NfeCompletoLote != null;
       }
      if (dirty) return true;
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       dirty = _xmlOriginal != Xml;
      if (dirty) return true;
       dirty = _situacaoOriginal != Situacao;
      if (dirty) return true;
       dirty = _dataSituacaoOriginal != DataSituacao;
      if (dirty) return true;
       dirty = _situacaoObservacaoOriginal != SituacaoObservacao;
      if (dirty) return true;
       dirty = _danfeImpressaOriginal != DanfeImpressa;
      if (dirty) return true;
       dirty = _xmlGeradoOriginal != XmlGerado;
      if (dirty) return true;
       dirty = _chaveOriginal != Chave;
      if (dirty) return true;
       dirty = _dataEmissaoOriginal != DataEmissao;
      if (dirty) return true;
       dirty = _cnpjEmitenteOriginal != CnpjEmitente;
      if (dirty) return true;
       dirty = _serieOriginal != Serie;
      if (dirty) return true;
       dirty = _xmlCancelamentoOriginal != XmlCancelamento;
      if (dirty) return true;
       dirty = _dataCancelamentoOriginal != DataCancelamento;
      if (dirty) return true;
       dirty = _justificativaCancelamentoOriginal != JustificativaCancelamento;
      if (dirty) return true;
       dirty = _usuarioCancelamentoOriginal != UsuarioCancelamento;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _homologacaoOriginal != Homologacao;
      if (dirty) return true;
       dirty = _modeloOriginal != Modelo;
      if (dirty) return true;
       if (_nfPrincipalOriginal!=null)
       {
          dirty = !_nfPrincipalOriginal.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
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
               if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded) 
               {
                  if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded) 
               {
                   tempRet = CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota.Any(item => item.IsDirtyCommited());
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
       if (_nfeCompletoLoteOriginalCommited!=null)
       {
          dirty = !_nfeCompletoLoteOriginalCommited.Equals(NfeCompletoLote);
       }
       else
       {
            dirty = NfeCompletoLote != null;
       }
      if (dirty) return true;
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       dirty = _xmlOriginalCommited != Xml;
      if (dirty) return true;
       dirty = _situacaoOriginalCommited != Situacao;
      if (dirty) return true;
       dirty = _dataSituacaoOriginalCommited != DataSituacao;
      if (dirty) return true;
       dirty = _situacaoObservacaoOriginalCommited != SituacaoObservacao;
      if (dirty) return true;
       dirty = _danfeImpressaOriginalCommited != DanfeImpressa;
      if (dirty) return true;
       dirty = _xmlGeradoOriginalCommited != XmlGerado;
      if (dirty) return true;
       dirty = _chaveOriginalCommited != Chave;
      if (dirty) return true;
       dirty = _dataEmissaoOriginalCommited != DataEmissao;
      if (dirty) return true;
       dirty = _cnpjEmitenteOriginalCommited != CnpjEmitente;
      if (dirty) return true;
       dirty = _serieOriginalCommited != Serie;
      if (dirty) return true;
       dirty = _xmlCancelamentoOriginalCommited != XmlCancelamento;
      if (dirty) return true;
       dirty = _dataCancelamentoOriginalCommited != DataCancelamento;
      if (dirty) return true;
       dirty = _justificativaCancelamentoOriginalCommited != JustificativaCancelamento;
      if (dirty) return true;
       dirty = _usuarioCancelamentoOriginalCommited != UsuarioCancelamento;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _homologacaoOriginalCommited != Homologacao;
      if (dirty) return true;
       dirty = _modeloOriginalCommited != Modelo;
      if (dirty) return true;
       if (_nfPrincipalOriginalCommited!=null)
       {
          dirty = !_nfPrincipalOriginalCommited.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
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
               if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded) 
               {
                  foreach(NfeCompletoCartaCorrecaoClass item in CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota)
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
             case "NfeCompletoLote":
                return this.NfeCompletoLote;
             case "Numero":
                return this.Numero;
             case "Xml":
                return this.Xml;
             case "Situacao":
                return this.Situacao;
             case "DataSituacao":
                return this.DataSituacao;
             case "SituacaoObservacao":
                return this.SituacaoObservacao;
             case "DanfeImpressa":
                return this.DanfeImpressa;
             case "XmlGerado":
                return this.XmlGerado;
             case "Chave":
                return this.Chave;
             case "DataEmissao":
                return this.DataEmissao;
             case "CnpjEmitente":
                return this.CnpjEmitente;
             case "Serie":
                return this.Serie;
             case "XmlCancelamento":
                return this.XmlCancelamento;
             case "DataCancelamento":
                return this.DataCancelamento;
             case "JustificativaCancelamento":
                return this.JustificativaCancelamento;
             case "UsuarioCancelamento":
                return this.UsuarioCancelamento;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Homologacao":
                return this.Homologacao;
             case "Modelo":
                return this.Modelo;
             case "NfPrincipal":
                return this.NfPrincipal;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfeCompletoLote!=null)
                NfeCompletoLote.ChangeSingleConnection(newConnection);
             if (NfPrincipal!=null)
                NfPrincipal.ChangeSingleConnection(newConnection);
               if (_valueCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNotaLoaded) 
               {
                  foreach(NfeCompletoCartaCorrecaoClass item in CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota)
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
                  command.CommandText += " COUNT(nfe_completo_nota.id_nfe_completo_nota) " ;
               }
               else
               {
               command.CommandText += "nfe_completo_nota.id_nfe_completo_nota, " ;
               command.CommandText += "nfe_completo_nota.id_nfe_completo_lote, " ;
               command.CommandText += "nfe_completo_nota.nfn_numero, " ;
               command.CommandText += "nfe_completo_nota.nfn_xml, " ;
               command.CommandText += "nfe_completo_nota.nfn_situacao, " ;
               command.CommandText += "nfe_completo_nota.nfn_data_situacao, " ;
               command.CommandText += "nfe_completo_nota.nfn_situacao_observacao, " ;
               command.CommandText += "nfe_completo_nota.nfn_danfe_impressa, " ;
               command.CommandText += "nfe_completo_nota.nfn_xml_gerado, " ;
               command.CommandText += "nfe_completo_nota.nfn_chave, " ;
               command.CommandText += "nfe_completo_nota.nfn_data_emissao, " ;
               command.CommandText += "nfe_completo_nota.nfn_cnpj_emitente, " ;
               command.CommandText += "nfe_completo_nota.nfn_serie, " ;
               command.CommandText += "nfe_completo_nota.nfn_xml_cancelamento, " ;
               command.CommandText += "nfe_completo_nota.nfn_data_cancelamento, " ;
               command.CommandText += "nfe_completo_nota.nfn_justificativa_cancelamento, " ;
               command.CommandText += "nfe_completo_nota.nfn_usuario_cancelamento, " ;
               command.CommandText += "nfe_completo_nota.entity_uid, " ;
               command.CommandText += "nfe_completo_nota.version, " ;
               command.CommandText += "nfe_completo_nota.nfn_homologacao, " ;
               command.CommandText += "nfe_completo_nota.nfn_modelo, " ;
               command.CommandText += "nfe_completo_nota.id_nf_principal " ;
               }
               command.CommandText += " FROM  nfe_completo_nota ";
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
                        orderByClause += " , nfn_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nfn_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nfe_completo_nota.id_acs_usuario_ultima_revisao ";
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
                     case "id_nfe_completo_nota":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.id_nfe_completo_nota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.id_nfe_completo_nota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nfe_completo_lote":
                     case "NfeCompletoLote":
                     command.CommandText += " LEFT JOIN nfe_completo_lote as nfe_completo_lote_NfeCompletoLote ON nfe_completo_lote_NfeCompletoLote.id_nfe_completo_lote = nfe_completo_nota.id_nfe_completo_lote ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_lote_NfeCompletoLote.ncl_numero_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_lote_NfeCompletoLote.ncl_numero_lote) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.nfn_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_xml":
                     case "Xml":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_nota.nfn_xml " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_xml) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.nfn_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_data_situacao":
                     case "DataSituacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.nfn_data_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_data_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_situacao_observacao":
                     case "SituacaoObservacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_nota.nfn_situacao_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_situacao_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_danfe_impressa":
                     case "DanfeImpressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.nfn_danfe_impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_danfe_impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_xml_gerado":
                     case "XmlGerado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.nfn_xml_gerado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_xml_gerado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_chave":
                     case "Chave":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_nota.nfn_chave " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_chave) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_data_emissao":
                     case "DataEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.nfn_data_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_data_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_cnpj_emitente":
                     case "CnpjEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_nota.nfn_cnpj_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_cnpj_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_serie":
                     case "Serie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.nfn_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_xml_cancelamento":
                     case "XmlCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_nota.nfn_xml_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_xml_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_data_cancelamento":
                     case "DataCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.nfn_data_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_data_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_justificativa_cancelamento":
                     case "JustificativaCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_nota.nfn_justificativa_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_justificativa_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_usuario_cancelamento":
                     case "UsuarioCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_nota.nfn_usuario_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_usuario_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_nota.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_nota.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nfe_completo_nota.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_homologacao":
                     case "Homologacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota.nfn_homologacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_homologacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfn_modelo":
                     case "Modelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_nota.nfn_modelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_nota.nfn_modelo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal":
                     case "NfPrincipal":
                     orderByClause += " , nfe_completo_nota.id_nf_principal " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfn_xml")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_nota.nfn_xml) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_nota.nfn_xml) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfn_situacao_observacao")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_nota.nfn_situacao_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_nota.nfn_situacao_observacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfn_chave")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_nota.nfn_chave) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_nota.nfn_chave) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfn_cnpj_emitente")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_nota.nfn_cnpj_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_nota.nfn_cnpj_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfn_xml_cancelamento")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_nota.nfn_xml_cancelamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_nota.nfn_xml_cancelamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfn_justificativa_cancelamento")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_nota.nfn_justificativa_cancelamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_nota.nfn_justificativa_cancelamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfn_usuario_cancelamento")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_nota.nfn_usuario_cancelamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_nota.nfn_usuario_cancelamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_nota.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_nota.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfn_modelo")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_nota.nfn_modelo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_nota.nfn_modelo) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nfe_completo_nota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.id_nfe_completo_nota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.id_nfe_completo_nota = :nfe_completo_nota_ID_8041 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_ID_8041", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfeCompletoLote" || parametro.FieldName == "id_nfe_completo_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoLoteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoLoteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.id_nfe_completo_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.id_nfe_completo_lote = :nfe_completo_nota_NfeCompletoLote_9041 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_NfeCompletoLote_9041", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "nfn_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_numero = :nfe_completo_nota_Numero_5499 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Numero_5499", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Xml" || parametro.FieldName == "nfn_xml")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml LIKE :nfe_completo_nota_Xml_2252 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Xml_2252", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "nfn_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SituacaoNFe)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SituacaoNFe");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_situacao = :nfe_completo_nota_Situacao_1541 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Situacao_1541", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataSituacao" || parametro.FieldName == "nfn_data_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_data_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_data_situacao = :nfe_completo_nota_DataSituacao_3073 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_DataSituacao_3073", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoObservacao" || parametro.FieldName == "nfn_situacao_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_situacao_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_situacao_observacao LIKE :nfe_completo_nota_SituacaoObservacao_7780 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_SituacaoObservacao_7780", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DanfeImpressa" || parametro.FieldName == "nfn_danfe_impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_danfe_impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_danfe_impressa = :nfe_completo_nota_DanfeImpressa_4224 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_DanfeImpressa_4224", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XmlGerado" || parametro.FieldName == "nfn_xml_gerado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml_gerado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml_gerado = :nfe_completo_nota_XmlGerado_9214 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_XmlGerado_9214", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Chave" || parametro.FieldName == "nfn_chave")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_chave IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_chave LIKE :nfe_completo_nota_Chave_4458 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Chave_4458", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEmissao" || parametro.FieldName == "nfn_data_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_data_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_data_emissao = :nfe_completo_nota_DataEmissao_9291 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_DataEmissao_9291", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjEmitente" || parametro.FieldName == "nfn_cnpj_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_cnpj_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_cnpj_emitente LIKE :nfe_completo_nota_CnpjEmitente_8960 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_CnpjEmitente_8960", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Serie" || parametro.FieldName == "nfn_serie")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_serie = :nfe_completo_nota_Serie_948 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Serie_948", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XmlCancelamento" || parametro.FieldName == "nfn_xml_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml_cancelamento LIKE :nfe_completo_nota_XmlCancelamento_1170 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_XmlCancelamento_1170", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCancelamento" || parametro.FieldName == "nfn_data_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_data_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_data_cancelamento = :nfe_completo_nota_DataCancelamento_1035 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_DataCancelamento_1035", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaCancelamento" || parametro.FieldName == "nfn_justificativa_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_justificativa_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_justificativa_cancelamento LIKE :nfe_completo_nota_JustificativaCancelamento_6997 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_JustificativaCancelamento_6997", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioCancelamento" || parametro.FieldName == "nfn_usuario_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_usuario_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_usuario_cancelamento LIKE :nfe_completo_nota_UsuarioCancelamento_5192 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_UsuarioCancelamento_5192", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_completo_nota.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.entity_uid LIKE :nfe_completo_nota_EntityUid_8791 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_EntityUid_8791", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_completo_nota.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.version = :nfe_completo_nota_Version_5460 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Version_5460", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Homologacao" || parametro.FieldName == "nfn_homologacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_homologacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_homologacao = :nfe_completo_nota_Homologacao_777 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Homologacao_777", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Modelo" || parametro.FieldName == "nfn_modelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_modelo LIKE :nfe_completo_nota_Modelo_1375 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Modelo_1375", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfPrincipal" || parametro.FieldName == "id_nf_principal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfPrincipalClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfPrincipalClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.id_nf_principal = :nfe_completo_nota_NfPrincipal_2949 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_NfPrincipal_2949", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XmlExato" || parametro.FieldName == "XmlExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml LIKE :nfe_completo_nota_Xml_3040 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Xml_3040", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoObservacaoExato" || parametro.FieldName == "SituacaoObservacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_situacao_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_situacao_observacao LIKE :nfe_completo_nota_SituacaoObservacao_2416 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_SituacaoObservacao_2416", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveExato" || parametro.FieldName == "ChaveExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_chave IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_chave LIKE :nfe_completo_nota_Chave_2019 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Chave_2019", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjEmitenteExato" || parametro.FieldName == "CnpjEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_cnpj_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_cnpj_emitente LIKE :nfe_completo_nota_CnpjEmitente_6038 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_CnpjEmitente_6038", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XmlCancelamentoExato" || parametro.FieldName == "XmlCancelamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_xml_cancelamento LIKE :nfe_completo_nota_XmlCancelamento_4241 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_XmlCancelamento_4241", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaCancelamentoExato" || parametro.FieldName == "JustificativaCancelamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_justificativa_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_justificativa_cancelamento LIKE :nfe_completo_nota_JustificativaCancelamento_4877 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_JustificativaCancelamento_4877", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioCancelamentoExato" || parametro.FieldName == "UsuarioCancelamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_nota.nfn_usuario_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_usuario_cancelamento LIKE :nfe_completo_nota_UsuarioCancelamento_1779 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_UsuarioCancelamento_1779", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_completo_nota.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.entity_uid LIKE :nfe_completo_nota_EntityUid_1963 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_EntityUid_1963", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_completo_nota.nfn_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_nota.nfn_modelo LIKE :nfe_completo_nota_Modelo_347 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_nota_Modelo_347", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfeCompletoNotaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfeCompletoNotaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfeCompletoNotaClass), Convert.ToInt32(read["id_nfe_completo_nota"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfeCompletoNotaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nfe_completo_nota"]);
                     if (read["id_nfe_completo_lote"] != DBNull.Value)
                     {
                        entidade.NfeCompletoLote = (IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoLoteClass)IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoLoteClass.GetEntidade(Convert.ToInt32(read["id_nfe_completo_lote"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfeCompletoLote = null ;
                     }
                     entidade.Numero = (int)read["nfn_numero"];
                     entidade.Xml = (read["nfn_xml"] != DBNull.Value ? read["nfn_xml"].ToString() : null);
                     entidade.Situacao = (SituacaoNFe) (read["nfn_situacao"] != DBNull.Value ? Enum.ToObject(typeof(SituacaoNFe), read["nfn_situacao"]) : null);
                     entidade.DataSituacao = (DateTime)read["nfn_data_situacao"];
                     entidade.SituacaoObservacao = (read["nfn_situacao_observacao"] != DBNull.Value ? read["nfn_situacao_observacao"].ToString() : null);
                     entidade.DanfeImpressa = Convert.ToBoolean(Convert.ToInt16(read["nfn_danfe_impressa"]));
                     entidade.XmlGerado = Convert.ToBoolean(Convert.ToInt16(read["nfn_xml_gerado"]));
                     entidade.Chave = (read["nfn_chave"] != DBNull.Value ? read["nfn_chave"].ToString() : null);
                     entidade.DataEmissao = (DateTime)read["nfn_data_emissao"];
                     entidade.CnpjEmitente = (read["nfn_cnpj_emitente"] != DBNull.Value ? read["nfn_cnpj_emitente"].ToString() : null);
                     entidade.Serie = (int)read["nfn_serie"];
                     entidade.XmlCancelamento = (read["nfn_xml_cancelamento"] != DBNull.Value ? read["nfn_xml_cancelamento"].ToString() : null);
                     entidade.DataCancelamento = read["nfn_data_cancelamento"] as DateTime?;
                     entidade.JustificativaCancelamento = (read["nfn_justificativa_cancelamento"] != DBNull.Value ? read["nfn_justificativa_cancelamento"].ToString() : null);
                     entidade.UsuarioCancelamento = (read["nfn_usuario_cancelamento"] != DBNull.Value ? read["nfn_usuario_cancelamento"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Homologacao = Convert.ToBoolean(Convert.ToInt16(read["nfn_homologacao"]));
                     entidade.Modelo = (read["nfn_modelo"] != DBNull.Value ? read["nfn_modelo"].ToString() : null);
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfeCompletoNotaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
