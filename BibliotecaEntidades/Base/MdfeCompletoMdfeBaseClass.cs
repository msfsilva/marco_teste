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
     [Table("mdfe_completo_mdfe","mcm")]
     public class MdfeCompletoMdfeBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MdfeCompletoMdfeClass";
protected const string ErroDelete = "Erro ao excluir o MdfeCompletoMdfeClass  ";
protected const string ErroSave = "Erro ao salvar o MdfeCompletoMdfeClass.";
protected const string ErroXmlObrigatorio = "O campo Xml é obrigatório";
protected const string ErroChaveAcessoObrigatorio = "O campo ChaveAcesso é obrigatório";
protected const string ErroChaveAcessoComprimento = "O campo ChaveAcesso deve ter no máximo 50 caracteres";
protected const string ErroCnpjEmitenteObrigatorio = "O campo CnpjEmitente é obrigatório";
protected const string ErroCnpjEmitenteComprimento = "O campo CnpjEmitente deve ter no máximo 14 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroMdfeCompletoLoteObrigatorio = "O campo MdfeCompletoLote é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do MdfeCompletoMdfeClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeCompletoMdfeClass está sendo utilizada.";
#endregion
       protected IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeCompletoLoteClass _mdfeCompletoLoteOriginal{get;private set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeCompletoLoteClass _mdfeCompletoLoteOriginalCommited {get; set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeCompletoLoteClass _valueMdfeCompletoLote;
        [Column("id_mdfe_completo_lote", "mdfe_completo_lote", "id_mdfe_completo_lote")]
       public virtual IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeCompletoLoteClass MdfeCompletoLote
        { 
           get {                 return this._valueMdfeCompletoLote; } 
           set 
           { 
                if (this._valueMdfeCompletoLote == value)return;
                 this._valueMdfeCompletoLote = value; 
           } 
       } 

       protected int _numeroOriginal{get;private set;}
       private int _numeroOriginalCommited{get; set;}
        private int _valueNumero;
         [Column("mcm_numero")]
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
         [Column("mcm_xml")]
        public virtual string Xml
         { 
            get { return this._valueXml; } 
            set 
            { 
                if (this._valueXml == value)return;
                 this._valueXml = value; 
            } 
        } 

       protected MDFeSituacaoMdfeCompleto _situacaoOriginal{get;private set;}
       private MDFeSituacaoMdfeCompleto _situacaoOriginalCommited{get; set;}
        private MDFeSituacaoMdfeCompleto _valueSituacao;
         [Column("mcm_situacao")]
        public virtual MDFeSituacaoMdfeCompleto Situacao
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
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoMdfeCompleto.Enviado; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoMdfeCompleto.Enviado; }
         } 

        public bool Situacao_Autorizado
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoMdfeCompleto.Autorizado; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoMdfeCompleto.Autorizado; }
         } 

        public bool Situacao_Encerrado
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoMdfeCompleto.Encerrado; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoMdfeCompleto.Encerrado; }
         } 

        public bool Situacao_Cancelado
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoMdfeCompleto.Cancelado; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.MDFeSituacaoMdfeCompleto.Cancelado; }
         } 

       protected DateTime _dataSituacaoOriginal{get;private set;}
       private DateTime _dataSituacaoOriginalCommited{get; set;}
        private DateTime _valueDataSituacao;
         [Column("mcm_data_situacao")]
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
         [Column("mcm_situacao_observacao")]
        public virtual string SituacaoObservacao
         { 
            get { return this._valueSituacaoObservacao; } 
            set 
            { 
                if (this._valueSituacaoObservacao == value)return;
                 this._valueSituacaoObservacao = value; 
            } 
        } 

       protected bool _damdfeImpressaOriginal{get;private set;}
       private bool _damdfeImpressaOriginalCommited{get; set;}
        private bool _valueDamdfeImpressa;
         [Column("mcm_damdfe_impressa")]
        public virtual bool DamdfeImpressa
         { 
            get { return this._valueDamdfeImpressa; } 
            set 
            { 
                if (this._valueDamdfeImpressa == value)return;
                 this._valueDamdfeImpressa = value; 
            } 
        } 

       protected bool _xmlGeradoOriginal{get;private set;}
       private bool _xmlGeradoOriginalCommited{get; set;}
        private bool _valueXmlGerado;
         [Column("mcm_xml_gerado")]
        public virtual bool XmlGerado
         { 
            get { return this._valueXmlGerado; } 
            set 
            { 
                if (this._valueXmlGerado == value)return;
                 this._valueXmlGerado = value; 
            } 
        } 

       protected string _chaveAcessoOriginal{get;private set;}
       private string _chaveAcessoOriginalCommited{get; set;}
        private string _valueChaveAcesso;
         [Column("mcm_chave_acesso")]
        public virtual string ChaveAcesso
         { 
            get { return this._valueChaveAcesso; } 
            set 
            { 
                if (this._valueChaveAcesso == value)return;
                 this._valueChaveAcesso = value; 
            } 
        } 

       protected DateTime _dataEmissaoOriginal{get;private set;}
       private DateTime _dataEmissaoOriginalCommited{get; set;}
        private DateTime _valueDataEmissao;
         [Column("mcm_data_emissao")]
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
         [Column("mcm_cnpj_emitente")]
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
         [Column("mcm_serie")]
        public virtual int Serie
         { 
            get { return this._valueSerie; } 
            set 
            { 
                if (this._valueSerie == value)return;
                 this._valueSerie = value; 
            } 
        } 

       protected string _protocoloOriginal{get;private set;}
       private string _protocoloOriginalCommited{get; set;}
        private string _valueProtocolo;
         [Column("mcm_protocolo")]
        public virtual string Protocolo
         { 
            get { return this._valueProtocolo; } 
            set 
            { 
                if (this._valueProtocolo == value)return;
                 this._valueProtocolo = value; 
            } 
        } 

        public MdfeCompletoMdfeBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Situacao = (MDFeSituacaoMdfeCompleto)0;
           this.DataSituacao = Configurations.DataIndependenteClass.GetData();
           this.DamdfeImpressa = false;
           this.XmlGerado = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static MdfeCompletoMdfeClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MdfeCompletoMdfeClass) GetEntity(typeof(MdfeCompletoMdfeClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Xml))
                {
                    throw new Exception(ErroXmlObrigatorio);
                }
                if (string.IsNullOrEmpty(ChaveAcesso))
                {
                    throw new Exception(ErroChaveAcessoObrigatorio);
                }
                if (ChaveAcesso.Length >50)
                {
                    throw new Exception( ErroChaveAcessoComprimento);
                }
                if (string.IsNullOrEmpty(CnpjEmitente))
                {
                    throw new Exception(ErroCnpjEmitenteObrigatorio);
                }
                if (CnpjEmitente.Length >14)
                {
                    throw new Exception( ErroCnpjEmitenteComprimento);
                }
                if ( _valueMdfeCompletoLote == null)
                {
                    throw new Exception(ErroMdfeCompletoLoteObrigatorio);
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
                    "  public.mdfe_completo_mdfe  " +
                    "WHERE " +
                    "  id_mdfe_completo_mdfe = :id";
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
                        "  public.mdfe_completo_mdfe   " +
                        "SET  " + 
                        "  id_mdfe_completo_lote = :id_mdfe_completo_lote, " + 
                        "  mcm_numero = :mcm_numero, " + 
                        "  mcm_xml = :mcm_xml, " + 
                        "  mcm_situacao = :mcm_situacao, " + 
                        "  mcm_data_situacao = :mcm_data_situacao, " + 
                        "  mcm_situacao_observacao = :mcm_situacao_observacao, " + 
                        "  mcm_damdfe_impressa = :mcm_damdfe_impressa, " + 
                        "  mcm_xml_gerado = :mcm_xml_gerado, " + 
                        "  mcm_chave_acesso = :mcm_chave_acesso, " + 
                        "  mcm_data_emissao = :mcm_data_emissao, " + 
                        "  mcm_cnpj_emitente = :mcm_cnpj_emitente, " + 
                        "  mcm_serie = :mcm_serie, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  mcm_protocolo = :mcm_protocolo "+
                        "WHERE  " +
                        "  id_mdfe_completo_mdfe = :id " +
                        "RETURNING id_mdfe_completo_mdfe;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.mdfe_completo_mdfe " +
                        "( " +
                        "  id_mdfe_completo_lote , " + 
                        "  mcm_numero , " + 
                        "  mcm_xml , " + 
                        "  mcm_situacao , " + 
                        "  mcm_data_situacao , " + 
                        "  mcm_situacao_observacao , " + 
                        "  mcm_damdfe_impressa , " + 
                        "  mcm_xml_gerado , " + 
                        "  mcm_chave_acesso , " + 
                        "  mcm_data_emissao , " + 
                        "  mcm_cnpj_emitente , " + 
                        "  mcm_serie , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  mcm_protocolo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_mdfe_completo_lote , " + 
                        "  :mcm_numero , " + 
                        "  :mcm_xml , " + 
                        "  :mcm_situacao , " + 
                        "  :mcm_data_situacao , " + 
                        "  :mcm_situacao_observacao , " + 
                        "  :mcm_damdfe_impressa , " + 
                        "  :mcm_xml_gerado , " + 
                        "  :mcm_chave_acesso , " + 
                        "  :mcm_data_emissao , " + 
                        "  :mcm_cnpj_emitente , " + 
                        "  :mcm_serie , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :mcm_protocolo  "+
                        ")RETURNING id_mdfe_completo_mdfe;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_mdfe_completo_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.MdfeCompletoLote==null ? (object) DBNull.Value : this.MdfeCompletoLote.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_xml", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Xml ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Situacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_data_situacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataSituacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_situacao_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SituacaoObservacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_damdfe_impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DamdfeImpressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_xml_gerado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.XmlGerado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_chave_acesso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ChaveAcesso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_data_emissao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_cnpj_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Serie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mcm_protocolo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Protocolo ?? DBNull.Value;

 
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
        public static MdfeCompletoMdfeClass CopiarEntidade(MdfeCompletoMdfeClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MdfeCompletoMdfeClass toRet = new MdfeCompletoMdfeClass(usuario,conn);
 toRet.MdfeCompletoLote= entidadeCopiar.MdfeCompletoLote;
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Xml= entidadeCopiar.Xml;
 toRet.Situacao= entidadeCopiar.Situacao;
 toRet.DataSituacao= entidadeCopiar.DataSituacao;
 toRet.SituacaoObservacao= entidadeCopiar.SituacaoObservacao;
 toRet.DamdfeImpressa= entidadeCopiar.DamdfeImpressa;
 toRet.XmlGerado= entidadeCopiar.XmlGerado;
 toRet.ChaveAcesso= entidadeCopiar.ChaveAcesso;
 toRet.DataEmissao= entidadeCopiar.DataEmissao;
 toRet.CnpjEmitente= entidadeCopiar.CnpjEmitente;
 toRet.Serie= entidadeCopiar.Serie;
 toRet.Protocolo= entidadeCopiar.Protocolo;

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
       _mdfeCompletoLoteOriginal = MdfeCompletoLote;
       _mdfeCompletoLoteOriginalCommited = _mdfeCompletoLoteOriginal;
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
       _damdfeImpressaOriginal = DamdfeImpressa;
       _damdfeImpressaOriginalCommited = _damdfeImpressaOriginal;
       _xmlGeradoOriginal = XmlGerado;
       _xmlGeradoOriginalCommited = _xmlGeradoOriginal;
       _chaveAcessoOriginal = ChaveAcesso;
       _chaveAcessoOriginalCommited = _chaveAcessoOriginal;
       _dataEmissaoOriginal = DataEmissao;
       _dataEmissaoOriginalCommited = _dataEmissaoOriginal;
       _cnpjEmitenteOriginal = CnpjEmitente;
       _cnpjEmitenteOriginalCommited = _cnpjEmitenteOriginal;
       _serieOriginal = Serie;
       _serieOriginalCommited = _serieOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _protocoloOriginal = Protocolo;
       _protocoloOriginalCommited = _protocoloOriginal;

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
       _mdfeCompletoLoteOriginalCommited = MdfeCompletoLote;
       _numeroOriginalCommited = Numero;
       _xmlOriginalCommited = Xml;
       _situacaoOriginalCommited = Situacao;
       _dataSituacaoOriginalCommited = DataSituacao;
       _situacaoObservacaoOriginalCommited = SituacaoObservacao;
       _damdfeImpressaOriginalCommited = DamdfeImpressa;
       _xmlGeradoOriginalCommited = XmlGerado;
       _chaveAcessoOriginalCommited = ChaveAcesso;
       _dataEmissaoOriginalCommited = DataEmissao;
       _cnpjEmitenteOriginalCommited = CnpjEmitente;
       _serieOriginalCommited = Serie;
       _versionOriginalCommited = Version;
       _protocoloOriginalCommited = Protocolo;

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
               MdfeCompletoLote=_mdfeCompletoLoteOriginal;
               _mdfeCompletoLoteOriginalCommited=_mdfeCompletoLoteOriginal;
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
               DamdfeImpressa=_damdfeImpressaOriginal;
               _damdfeImpressaOriginalCommited=_damdfeImpressaOriginal;
               XmlGerado=_xmlGeradoOriginal;
               _xmlGeradoOriginalCommited=_xmlGeradoOriginal;
               ChaveAcesso=_chaveAcessoOriginal;
               _chaveAcessoOriginalCommited=_chaveAcessoOriginal;
               DataEmissao=_dataEmissaoOriginal;
               _dataEmissaoOriginalCommited=_dataEmissaoOriginal;
               CnpjEmitente=_cnpjEmitenteOriginal;
               _cnpjEmitenteOriginalCommited=_cnpjEmitenteOriginal;
               Serie=_serieOriginal;
               _serieOriginalCommited=_serieOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Protocolo=_protocoloOriginal;
               _protocoloOriginalCommited=_protocoloOriginal;

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
       if (_mdfeCompletoLoteOriginal!=null)
       {
          dirty = !_mdfeCompletoLoteOriginal.Equals(MdfeCompletoLote);
       }
       else
       {
            dirty = MdfeCompletoLote != null;
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
       dirty = _damdfeImpressaOriginal != DamdfeImpressa;
      if (dirty) return true;
       dirty = _xmlGeradoOriginal != XmlGerado;
      if (dirty) return true;
       dirty = _chaveAcessoOriginal != ChaveAcesso;
      if (dirty) return true;
       dirty = _dataEmissaoOriginal != DataEmissao;
      if (dirty) return true;
       dirty = _cnpjEmitenteOriginal != CnpjEmitente;
      if (dirty) return true;
       dirty = _serieOriginal != Serie;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _protocoloOriginal != Protocolo;

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
       if (_mdfeCompletoLoteOriginalCommited!=null)
       {
          dirty = !_mdfeCompletoLoteOriginalCommited.Equals(MdfeCompletoLote);
       }
       else
       {
            dirty = MdfeCompletoLote != null;
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
       dirty = _damdfeImpressaOriginalCommited != DamdfeImpressa;
      if (dirty) return true;
       dirty = _xmlGeradoOriginalCommited != XmlGerado;
      if (dirty) return true;
       dirty = _chaveAcessoOriginalCommited != ChaveAcesso;
      if (dirty) return true;
       dirty = _dataEmissaoOriginalCommited != DataEmissao;
      if (dirty) return true;
       dirty = _cnpjEmitenteOriginalCommited != CnpjEmitente;
      if (dirty) return true;
       dirty = _serieOriginalCommited != Serie;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _protocoloOriginalCommited != Protocolo;

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
             case "MdfeCompletoLote":
                return this.MdfeCompletoLote;
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
             case "DamdfeImpressa":
                return this.DamdfeImpressa;
             case "XmlGerado":
                return this.XmlGerado;
             case "ChaveAcesso":
                return this.ChaveAcesso;
             case "DataEmissao":
                return this.DataEmissao;
             case "CnpjEmitente":
                return this.CnpjEmitente;
             case "Serie":
                return this.Serie;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "Protocolo":
                return this.Protocolo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (MdfeCompletoLote!=null)
                MdfeCompletoLote.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(mdfe_completo_mdfe.id_mdfe_completo_mdfe) " ;
               }
               else
               {
               command.CommandText += "mdfe_completo_mdfe.id_mdfe_completo_mdfe, " ;
               command.CommandText += "mdfe_completo_mdfe.id_mdfe_completo_lote, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_numero, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_xml, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_situacao, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_data_situacao, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_situacao_observacao, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_damdfe_impressa, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_xml_gerado, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_chave_acesso, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_data_emissao, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_cnpj_emitente, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_serie, " ;
               command.CommandText += "mdfe_completo_mdfe.version, " ;
               command.CommandText += "mdfe_completo_mdfe.entity_uid, " ;
               command.CommandText += "mdfe_completo_mdfe.mcm_protocolo " ;
               }
               command.CommandText += " FROM  mdfe_completo_mdfe ";
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
                        orderByClause += " , mcm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mcm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = mdfe_completo_mdfe.id_acs_usuario_ultima_revisao ";
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
                     case "id_mdfe_completo_mdfe":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_mdfe.id_mdfe_completo_mdfe " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.id_mdfe_completo_mdfe) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_mdfe_completo_lote":
                     case "MdfeCompletoLote":
                     orderByClause += " , mdfe_completo_mdfe.id_mdfe_completo_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "mcm_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_mdfe.mcm_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_xml":
                     case "Xml":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_mdfe.mcm_xml " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_xml) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_mdfe.mcm_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_data_situacao":
                     case "DataSituacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_mdfe.mcm_data_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_data_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_situacao_observacao":
                     case "SituacaoObservacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_mdfe.mcm_situacao_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_situacao_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_damdfe_impressa":
                     case "DamdfeImpressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_mdfe.mcm_damdfe_impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_damdfe_impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_xml_gerado":
                     case "XmlGerado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_mdfe.mcm_xml_gerado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_xml_gerado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_chave_acesso":
                     case "ChaveAcesso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_mdfe.mcm_chave_acesso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_chave_acesso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_data_emissao":
                     case "DataEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_mdfe.mcm_data_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_data_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_cnpj_emitente":
                     case "CnpjEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_mdfe.mcm_cnpj_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_cnpj_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_serie":
                     case "Serie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_completo_mdfe.mcm_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , mdfe_completo_mdfe.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_mdfe.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mcm_protocolo":
                     case "Protocolo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_completo_mdfe.mcm_protocolo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_completo_mdfe.mcm_protocolo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcm_xml")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_mdfe.mcm_xml) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_mdfe.mcm_xml) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcm_situacao_observacao")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_mdfe.mcm_situacao_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_mdfe.mcm_situacao_observacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcm_chave_acesso")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_mdfe.mcm_chave_acesso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_mdfe.mcm_chave_acesso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcm_cnpj_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_mdfe.mcm_cnpj_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_mdfe.mcm_cnpj_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_mdfe.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_mdfe.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mcm_protocolo")) 
                        {
                           whereClause += " OR UPPER(mdfe_completo_mdfe.mcm_protocolo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_completo_mdfe.mcm_protocolo) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_mdfe_completo_mdfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.id_mdfe_completo_mdfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.id_mdfe_completo_mdfe = :mdfe_completo_mdfe_ID_8597 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_ID_8597", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MdfeCompletoLote" || parametro.FieldName == "id_mdfe_completo_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeCompletoLoteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeCompletoLoteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.id_mdfe_completo_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.id_mdfe_completo_lote = :mdfe_completo_mdfe_MdfeCompletoLote_9215 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_MdfeCompletoLote_9215", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "mcm_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_numero = :mdfe_completo_mdfe_Numero_3603 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_Numero_3603", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Xml" || parametro.FieldName == "mcm_xml")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_xml LIKE :mdfe_completo_mdfe_Xml_9598 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_Xml_9598", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "mcm_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeSituacaoMdfeCompleto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeSituacaoMdfeCompleto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_situacao = :mdfe_completo_mdfe_Situacao_9420 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_Situacao_9420", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataSituacao" || parametro.FieldName == "mcm_data_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_data_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_data_situacao = :mdfe_completo_mdfe_DataSituacao_525 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_DataSituacao_525", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoObservacao" || parametro.FieldName == "mcm_situacao_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_situacao_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_situacao_observacao LIKE :mdfe_completo_mdfe_SituacaoObservacao_9398 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_SituacaoObservacao_9398", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DamdfeImpressa" || parametro.FieldName == "mcm_damdfe_impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_damdfe_impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_damdfe_impressa = :mdfe_completo_mdfe_DamdfeImpressa_7387 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_DamdfeImpressa_7387", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XmlGerado" || parametro.FieldName == "mcm_xml_gerado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_xml_gerado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_xml_gerado = :mdfe_completo_mdfe_XmlGerado_4364 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_XmlGerado_4364", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveAcesso" || parametro.FieldName == "mcm_chave_acesso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_chave_acesso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_chave_acesso LIKE :mdfe_completo_mdfe_ChaveAcesso_2520 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_ChaveAcesso_2520", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEmissao" || parametro.FieldName == "mcm_data_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_data_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_data_emissao = :mdfe_completo_mdfe_DataEmissao_6255 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_DataEmissao_6255", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjEmitente" || parametro.FieldName == "mcm_cnpj_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_cnpj_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_cnpj_emitente LIKE :mdfe_completo_mdfe_CnpjEmitente_7981 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_CnpjEmitente_7981", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Serie" || parametro.FieldName == "mcm_serie")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_serie = :mdfe_completo_mdfe_Serie_1627 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_Serie_1627", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_completo_mdfe.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.version = :mdfe_completo_mdfe_Version_4091 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_Version_4091", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_completo_mdfe.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.entity_uid LIKE :mdfe_completo_mdfe_EntityUid_8064 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_EntityUid_8064", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Protocolo" || parametro.FieldName == "mcm_protocolo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_protocolo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_protocolo LIKE :mdfe_completo_mdfe_Protocolo_6269 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_Protocolo_6269", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  mdfe_completo_mdfe.mcm_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_xml LIKE :mdfe_completo_mdfe_Xml_7000 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_Xml_7000", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_completo_mdfe.mcm_situacao_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_situacao_observacao LIKE :mdfe_completo_mdfe_SituacaoObservacao_2993 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_SituacaoObservacao_2993", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveAcessoExato" || parametro.FieldName == "ChaveAcessoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_chave_acesso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_chave_acesso LIKE :mdfe_completo_mdfe_ChaveAcesso_5953 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_ChaveAcesso_5953", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_completo_mdfe.mcm_cnpj_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_cnpj_emitente LIKE :mdfe_completo_mdfe_CnpjEmitente_8722 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_CnpjEmitente_8722", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_completo_mdfe.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.entity_uid LIKE :mdfe_completo_mdfe_EntityUid_6545 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_EntityUid_6545", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProtocoloExato" || parametro.FieldName == "ProtocoloExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_protocolo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_completo_mdfe.mcm_protocolo LIKE :mdfe_completo_mdfe_Protocolo_5531 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_completo_mdfe_Protocolo_5531", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MdfeCompletoMdfeClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MdfeCompletoMdfeClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MdfeCompletoMdfeClass), Convert.ToInt32(read["id_mdfe_completo_mdfe"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MdfeCompletoMdfeClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_mdfe_completo_mdfe"]);
                     if (read["id_mdfe_completo_lote"] != DBNull.Value)
                     {
                        entidade.MdfeCompletoLote = (IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeCompletoLoteClass)IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeCompletoLoteClass.GetEntidade(Convert.ToInt32(read["id_mdfe_completo_lote"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.MdfeCompletoLote = null ;
                     }
                     entidade.Numero = (int)read["mcm_numero"];
                     entidade.Xml = (read["mcm_xml"] != DBNull.Value ? read["mcm_xml"].ToString() : null);
                     entidade.Situacao = (MDFeSituacaoMdfeCompleto) (read["mcm_situacao"] != DBNull.Value ? Enum.ToObject(typeof(MDFeSituacaoMdfeCompleto), read["mcm_situacao"]) : null);
                     entidade.DataSituacao = (DateTime)read["mcm_data_situacao"];
                     entidade.SituacaoObservacao = (read["mcm_situacao_observacao"] != DBNull.Value ? read["mcm_situacao_observacao"].ToString() : null);
                     entidade.DamdfeImpressa = Convert.ToBoolean(Convert.ToInt16(read["mcm_damdfe_impressa"]));
                     entidade.XmlGerado = Convert.ToBoolean(Convert.ToInt16(read["mcm_xml_gerado"]));
                     entidade.ChaveAcesso = (read["mcm_chave_acesso"] != DBNull.Value ? read["mcm_chave_acesso"].ToString() : null);
                     entidade.DataEmissao = (DateTime)read["mcm_data_emissao"];
                     entidade.CnpjEmitente = (read["mcm_cnpj_emitente"] != DBNull.Value ? read["mcm_cnpj_emitente"].ToString() : null);
                     entidade.Serie = (int)read["mcm_serie"];
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Protocolo = (read["mcm_protocolo"] != DBNull.Value ? read["mcm_protocolo"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MdfeCompletoMdfeClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
