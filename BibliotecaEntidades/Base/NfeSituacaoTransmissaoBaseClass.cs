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
     [Table("nfe_situacao_transmissao","nst")]
     public class NfeSituacaoTransmissaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfeSituacaoTransmissaoClass";
protected const string ErroDelete = "Erro ao excluir o NfeSituacaoTransmissaoClass  ";
protected const string ErroSave = "Erro ao salvar o NfeSituacaoTransmissaoClass.";
protected const string ErroMensagemObrigatorio = "O campo Mensagem é obrigatório";
protected const string ErroNotaModeloObrigatorio = "O campo NotaModelo é obrigatório";
protected const string ErroNotaEmitenteObrigatorio = "O campo NotaEmitente é obrigatório";
protected const string ErroNotaDestinatarioObrigatorio = "O campo NotaDestinatario é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do NfeSituacaoTransmissaoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfeSituacaoTransmissaoClass está sendo utilizada.";
#endregion
       protected int? _idNfPrincipalOriginal{get;private set;}
       private int? _idNfPrincipalOriginalCommited{get; set;}
        private int? _valueIdNfPrincipal;
         [Column("id_nf_principal")]
        public virtual int? IdNfPrincipal
         { 
            get { return this._valueIdNfPrincipal; } 
            set 
            { 
                if (this._valueIdNfPrincipal == value)return;
                 this._valueIdNfPrincipal = value; 
            } 
        } 

       protected int? _idNfCompletoNotaOriginal{get;private set;}
       private int? _idNfCompletoNotaOriginalCommited{get; set;}
        private int? _valueIdNfCompletoNota;
         [Column("id_nf_completo_nota")]
        public virtual int? IdNfCompletoNota
         { 
            get { return this._valueIdNfCompletoNota; } 
            set 
            { 
                if (this._valueIdNfCompletoNota == value)return;
                 this._valueIdNfCompletoNota = value; 
            } 
        } 

       protected IWTNFTipoNota _notaTipoOriginal{get;private set;}
       private IWTNFTipoNota _notaTipoOriginalCommited{get; set;}
        private IWTNFTipoNota _valueNotaTipo;
         [Column("nst_nota_tipo")]
        public virtual IWTNFTipoNota NotaTipo
         { 
            get { return this._valueNotaTipo; } 
            set 
            { 
                if (this._valueNotaTipo == value)return;
                 this._valueNotaTipo = value; 
            } 
        } 

        public bool NotaTipo_NFe
         { 
            get { return this._valueNotaTipo == IWTNFCompleto.BibliotecaEntidades.Base.IWTNFTipoNota.NFe; } 
            set { if (value) this._valueNotaTipo = IWTNFCompleto.BibliotecaEntidades.Base.IWTNFTipoNota.NFe; }
         } 

        public bool NotaTipo_NFCe
         { 
            get { return this._valueNotaTipo == IWTNFCompleto.BibliotecaEntidades.Base.IWTNFTipoNota.NFCe; } 
            set { if (value) this._valueNotaTipo = IWTNFCompleto.BibliotecaEntidades.Base.IWTNFTipoNota.NFCe; }
         } 

        public bool NotaTipo_NFServicosLondrina
         { 
            get { return this._valueNotaTipo == IWTNFCompleto.BibliotecaEntidades.Base.IWTNFTipoNota.NFServicosLondrina; } 
            set { if (value) this._valueNotaTipo = IWTNFCompleto.BibliotecaEntidades.Base.IWTNFTipoNota.NFServicosLondrina; }
         } 

       protected IWTNFSituacaoTransmissao _situacaoOriginal{get;private set;}
       private IWTNFSituacaoTransmissao _situacaoOriginalCommited{get; set;}
        private IWTNFSituacaoTransmissao _valueSituacao;
         [Column("nst_situacao")]
        public virtual IWTNFSituacaoTransmissao Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

        public bool Situacao_AguardandoEnvio
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.AguardandoEnvio; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.AguardandoEnvio; }
         } 

        public bool Situacao_AguardandoResposta
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.AguardandoResposta; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.AguardandoResposta; }
         } 

        public bool Situacao_Processada
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.Processada; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.Processada; }
         } 

        public bool Situacao_Rejeitada
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.Rejeitada; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.Rejeitada; }
         } 

        public bool Situacao_Denegada
         { 
            get { return this._valueSituacao == IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.Denegada; } 
            set { if (value) this._valueSituacao = IWTNFCompleto.BibliotecaEntidades.Base.IWTNFSituacaoTransmissao.Denegada; }
         } 

       protected string _mensagemOriginal{get;private set;}
       private string _mensagemOriginalCommited{get; set;}
        private string _valueMensagem;
         [Column("nst_mensagem")]
        public virtual string Mensagem
         { 
            get { return this._valueMensagem; } 
            set 
            { 
                if (this._valueMensagem == value)return;
                 this._valueMensagem = value; 
            } 
        } 

       protected DateTime _dataAtualizacaoOriginal{get;private set;}
       private DateTime _dataAtualizacaoOriginalCommited{get; set;}
        private DateTime _valueDataAtualizacao;
         [Column("nst_data_atualizacao")]
        public virtual DateTime DataAtualizacao
         { 
            get { return this._valueDataAtualizacao; } 
            set 
            { 
                if (this._valueDataAtualizacao == value)return;
                 this._valueDataAtualizacao = value; 
            } 
        } 

       protected int? _notaNumeroOriginal{get;private set;}
       private int? _notaNumeroOriginalCommited{get; set;}
        private int? _valueNotaNumero;
         [Column("nst_nota_numero")]
        public virtual int? NotaNumero
         { 
            get { return this._valueNotaNumero; } 
            set 
            { 
                if (this._valueNotaNumero == value)return;
                 this._valueNotaNumero = value; 
            } 
        } 

       protected string _notaSerieOriginal{get;private set;}
       private string _notaSerieOriginalCommited{get; set;}
        private string _valueNotaSerie;
         [Column("nst_nota_serie")]
        public virtual string NotaSerie
         { 
            get { return this._valueNotaSerie; } 
            set 
            { 
                if (this._valueNotaSerie == value)return;
                 this._valueNotaSerie = value; 
            } 
        } 

       protected string _notaModeloOriginal{get;private set;}
       private string _notaModeloOriginalCommited{get; set;}
        private string _valueNotaModelo;
         [Column("nst_nota_modelo")]
        public virtual string NotaModelo
         { 
            get { return this._valueNotaModelo; } 
            set 
            { 
                if (this._valueNotaModelo == value)return;
                 this._valueNotaModelo = value; 
            } 
        } 

       protected string _notaEmitenteOriginal{get;private set;}
       private string _notaEmitenteOriginalCommited{get; set;}
        private string _valueNotaEmitente;
         [Column("nst_nota_emitente")]
        public virtual string NotaEmitente
         { 
            get { return this._valueNotaEmitente; } 
            set 
            { 
                if (this._valueNotaEmitente == value)return;
                 this._valueNotaEmitente = value; 
            } 
        } 

       protected string _notaDestinatarioOriginal{get;private set;}
       private string _notaDestinatarioOriginalCommited{get; set;}
        private string _valueNotaDestinatario;
         [Column("nst_nota_destinatario")]
        public virtual string NotaDestinatario
         { 
            get { return this._valueNotaDestinatario; } 
            set 
            { 
                if (this._valueNotaDestinatario == value)return;
                 this._valueNotaDestinatario = value; 
            } 
        } 

       protected DateTime _notaDataEmissaoOriginal{get;private set;}
       private DateTime _notaDataEmissaoOriginalCommited{get; set;}
        private DateTime _valueNotaDataEmissao;
         [Column("nst_nota_data_emissao")]
        public virtual DateTime NotaDataEmissao
         { 
            get { return this._valueNotaDataEmissao; } 
            set 
            { 
                if (this._valueNotaDataEmissao == value)return;
                 this._valueNotaDataEmissao = value; 
            } 
        } 

       protected string _notaChaveOriginal{get;private set;}
       private string _notaChaveOriginalCommited{get; set;}
        private string _valueNotaChave;
         [Column("nst_nota_chave")]
        public virtual string NotaChave
         { 
            get { return this._valueNotaChave; } 
            set 
            { 
                if (this._valueNotaChave == value)return;
                 this._valueNotaChave = value; 
            } 
        } 

       protected string _notaEnderecoConsultaDiretoOriginal{get;private set;}
       private string _notaEnderecoConsultaDiretoOriginalCommited{get; set;}
        private string _valueNotaEnderecoConsultaDireto;
         [Column("nst_nota_endereco_consulta_direto")]
        public virtual string NotaEnderecoConsultaDireto
         { 
            get { return this._valueNotaEnderecoConsultaDireto; } 
            set 
            { 
                if (this._valueNotaEnderecoConsultaDireto == value)return;
                 this._valueNotaEnderecoConsultaDireto = value; 
            } 
        } 

       protected int? _idNfeLondrinaOriginal{get;private set;}
       private int? _idNfeLondrinaOriginalCommited{get; set;}
        private int? _valueIdNfeLondrina;
         [Column("id_nfe_londrina")]
        public virtual int? IdNfeLondrina
         { 
            get { return this._valueIdNfeLondrina; } 
            set 
            { 
                if (this._valueIdNfeLondrina == value)return;
                 this._valueIdNfeLondrina = value; 
            } 
        } 

       protected string _xmlEnviadoOriginal{get;private set;}
       private string _xmlEnviadoOriginalCommited{get; set;}
        private string _valueXmlEnviado;
         [Column("nst_xml_enviado")]
        public virtual string XmlEnviado
         { 
            get { return this._valueXmlEnviado; } 
            set 
            { 
                if (this._valueXmlEnviado == value)return;
                 this._valueXmlEnviado = value; 
            } 
        } 

        public NfeSituacaoTransmissaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Situacao = (IWTNFSituacaoTransmissao)0;
           this.DataAtualizacao = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfeSituacaoTransmissaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfeSituacaoTransmissaoClass) GetEntity(typeof(NfeSituacaoTransmissaoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Mensagem))
                {
                    throw new Exception(ErroMensagemObrigatorio);
                }
                if (string.IsNullOrEmpty(NotaModelo))
                {
                    throw new Exception(ErroNotaModeloObrigatorio);
                }
                if (string.IsNullOrEmpty(NotaEmitente))
                {
                    throw new Exception(ErroNotaEmitenteObrigatorio);
                }
                if (string.IsNullOrEmpty(NotaDestinatario))
                {
                    throw new Exception(ErroNotaDestinatarioObrigatorio);
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
                    "  public.nfe_situacao_transmissao  " +
                    "WHERE " +
                    "  id_nfe_situacao_transmissao = :id";
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
                        "  public.nfe_situacao_transmissao   " +
                        "SET  " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  id_nf_completo_nota = :id_nf_completo_nota, " + 
                        "  nst_nota_tipo = :nst_nota_tipo, " + 
                        "  nst_situacao = :nst_situacao, " + 
                        "  nst_mensagem = :nst_mensagem, " + 
                        "  nst_data_atualizacao = :nst_data_atualizacao, " + 
                        "  nst_nota_numero = :nst_nota_numero, " + 
                        "  nst_nota_serie = :nst_nota_serie, " + 
                        "  nst_nota_modelo = :nst_nota_modelo, " + 
                        "  nst_nota_emitente = :nst_nota_emitente, " + 
                        "  nst_nota_destinatario = :nst_nota_destinatario, " + 
                        "  nst_nota_data_emissao = :nst_nota_data_emissao, " + 
                        "  nst_nota_chave = :nst_nota_chave, " + 
                        "  nst_nota_endereco_consulta_direto = :nst_nota_endereco_consulta_direto, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_nfe_londrina = :id_nfe_londrina, " + 
                        "  nst_xml_enviado = :nst_xml_enviado "+
                        "WHERE  " +
                        "  id_nfe_situacao_transmissao = :id " +
                        "RETURNING id_nfe_situacao_transmissao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nfe_situacao_transmissao " +
                        "( " +
                        "  id_nf_principal , " + 
                        "  id_nf_completo_nota , " + 
                        "  nst_nota_tipo , " + 
                        "  nst_situacao , " + 
                        "  nst_mensagem , " + 
                        "  nst_data_atualizacao , " + 
                        "  nst_nota_numero , " + 
                        "  nst_nota_serie , " + 
                        "  nst_nota_modelo , " + 
                        "  nst_nota_emitente , " + 
                        "  nst_nota_destinatario , " + 
                        "  nst_nota_data_emissao , " + 
                        "  nst_nota_chave , " + 
                        "  nst_nota_endereco_consulta_direto , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_nfe_londrina , " + 
                        "  nst_xml_enviado  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_principal , " + 
                        "  :id_nf_completo_nota , " + 
                        "  :nst_nota_tipo , " + 
                        "  :nst_situacao , " + 
                        "  :nst_mensagem , " + 
                        "  :nst_data_atualizacao , " + 
                        "  :nst_nota_numero , " + 
                        "  :nst_nota_serie , " + 
                        "  :nst_nota_modelo , " + 
                        "  :nst_nota_emitente , " + 
                        "  :nst_nota_destinatario , " + 
                        "  :nst_nota_data_emissao , " + 
                        "  :nst_nota_chave , " + 
                        "  :nst_nota_endereco_consulta_direto , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_nfe_londrina , " + 
                        "  :nst_xml_enviado  "+
                        ")RETURNING id_nfe_situacao_transmissao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdNfPrincipal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_completo_nota", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdNfCompletoNota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_nota_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.NotaTipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Situacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_mensagem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Mensagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_data_atualizacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAtualizacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_nota_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_nota_serie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaSerie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_nota_modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaModelo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_nota_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_nota_destinatario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaDestinatario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_nota_data_emissao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaDataEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_nota_chave", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaChave ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_nota_endereco_consulta_direto", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaEnderecoConsultaDireto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_londrina", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdNfeLondrina ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nst_xml_enviado", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.XmlEnviado ?? DBNull.Value;

 
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
        public static NfeSituacaoTransmissaoClass CopiarEntidade(NfeSituacaoTransmissaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfeSituacaoTransmissaoClass toRet = new NfeSituacaoTransmissaoClass(usuario,conn);
 toRet.IdNfPrincipal= entidadeCopiar.IdNfPrincipal;
 toRet.IdNfCompletoNota= entidadeCopiar.IdNfCompletoNota;
 toRet.NotaTipo= entidadeCopiar.NotaTipo;
 toRet.Situacao= entidadeCopiar.Situacao;
 toRet.Mensagem= entidadeCopiar.Mensagem;
 toRet.DataAtualizacao= entidadeCopiar.DataAtualizacao;
 toRet.NotaNumero= entidadeCopiar.NotaNumero;
 toRet.NotaSerie= entidadeCopiar.NotaSerie;
 toRet.NotaModelo= entidadeCopiar.NotaModelo;
 toRet.NotaEmitente= entidadeCopiar.NotaEmitente;
 toRet.NotaDestinatario= entidadeCopiar.NotaDestinatario;
 toRet.NotaDataEmissao= entidadeCopiar.NotaDataEmissao;
 toRet.NotaChave= entidadeCopiar.NotaChave;
 toRet.NotaEnderecoConsultaDireto= entidadeCopiar.NotaEnderecoConsultaDireto;
 toRet.IdNfeLondrina= entidadeCopiar.IdNfeLondrina;
 toRet.XmlEnviado= entidadeCopiar.XmlEnviado;

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
       _idNfPrincipalOriginal = IdNfPrincipal;
       _idNfPrincipalOriginalCommited = _idNfPrincipalOriginal;
       _idNfCompletoNotaOriginal = IdNfCompletoNota;
       _idNfCompletoNotaOriginalCommited = _idNfCompletoNotaOriginal;
       _notaTipoOriginal = NotaTipo;
       _notaTipoOriginalCommited = _notaTipoOriginal;
       _situacaoOriginal = Situacao;
       _situacaoOriginalCommited = _situacaoOriginal;
       _mensagemOriginal = Mensagem;
       _mensagemOriginalCommited = _mensagemOriginal;
       _dataAtualizacaoOriginal = DataAtualizacao;
       _dataAtualizacaoOriginalCommited = _dataAtualizacaoOriginal;
       _notaNumeroOriginal = NotaNumero;
       _notaNumeroOriginalCommited = _notaNumeroOriginal;
       _notaSerieOriginal = NotaSerie;
       _notaSerieOriginalCommited = _notaSerieOriginal;
       _notaModeloOriginal = NotaModelo;
       _notaModeloOriginalCommited = _notaModeloOriginal;
       _notaEmitenteOriginal = NotaEmitente;
       _notaEmitenteOriginalCommited = _notaEmitenteOriginal;
       _notaDestinatarioOriginal = NotaDestinatario;
       _notaDestinatarioOriginalCommited = _notaDestinatarioOriginal;
       _notaDataEmissaoOriginal = NotaDataEmissao;
       _notaDataEmissaoOriginalCommited = _notaDataEmissaoOriginal;
       _notaChaveOriginal = NotaChave;
       _notaChaveOriginalCommited = _notaChaveOriginal;
       _notaEnderecoConsultaDiretoOriginal = NotaEnderecoConsultaDireto;
       _notaEnderecoConsultaDiretoOriginalCommited = _notaEnderecoConsultaDiretoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _idNfeLondrinaOriginal = IdNfeLondrina;
       _idNfeLondrinaOriginalCommited = _idNfeLondrinaOriginal;
       _xmlEnviadoOriginal = XmlEnviado;
       _xmlEnviadoOriginalCommited = _xmlEnviadoOriginal;

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
       _idNfPrincipalOriginalCommited = IdNfPrincipal;
       _idNfCompletoNotaOriginalCommited = IdNfCompletoNota;
       _notaTipoOriginalCommited = NotaTipo;
       _situacaoOriginalCommited = Situacao;
       _mensagemOriginalCommited = Mensagem;
       _dataAtualizacaoOriginalCommited = DataAtualizacao;
       _notaNumeroOriginalCommited = NotaNumero;
       _notaSerieOriginalCommited = NotaSerie;
       _notaModeloOriginalCommited = NotaModelo;
       _notaEmitenteOriginalCommited = NotaEmitente;
       _notaDestinatarioOriginalCommited = NotaDestinatario;
       _notaDataEmissaoOriginalCommited = NotaDataEmissao;
       _notaChaveOriginalCommited = NotaChave;
       _notaEnderecoConsultaDiretoOriginalCommited = NotaEnderecoConsultaDireto;
       _versionOriginalCommited = Version;
       _idNfeLondrinaOriginalCommited = IdNfeLondrina;
       _xmlEnviadoOriginalCommited = XmlEnviado;

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
               IdNfPrincipal=_idNfPrincipalOriginal;
               _idNfPrincipalOriginalCommited=_idNfPrincipalOriginal;
               IdNfCompletoNota=_idNfCompletoNotaOriginal;
               _idNfCompletoNotaOriginalCommited=_idNfCompletoNotaOriginal;
               NotaTipo=_notaTipoOriginal;
               _notaTipoOriginalCommited=_notaTipoOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               Mensagem=_mensagemOriginal;
               _mensagemOriginalCommited=_mensagemOriginal;
               DataAtualizacao=_dataAtualizacaoOriginal;
               _dataAtualizacaoOriginalCommited=_dataAtualizacaoOriginal;
               NotaNumero=_notaNumeroOriginal;
               _notaNumeroOriginalCommited=_notaNumeroOriginal;
               NotaSerie=_notaSerieOriginal;
               _notaSerieOriginalCommited=_notaSerieOriginal;
               NotaModelo=_notaModeloOriginal;
               _notaModeloOriginalCommited=_notaModeloOriginal;
               NotaEmitente=_notaEmitenteOriginal;
               _notaEmitenteOriginalCommited=_notaEmitenteOriginal;
               NotaDestinatario=_notaDestinatarioOriginal;
               _notaDestinatarioOriginalCommited=_notaDestinatarioOriginal;
               NotaDataEmissao=_notaDataEmissaoOriginal;
               _notaDataEmissaoOriginalCommited=_notaDataEmissaoOriginal;
               NotaChave=_notaChaveOriginal;
               _notaChaveOriginalCommited=_notaChaveOriginal;
               NotaEnderecoConsultaDireto=_notaEnderecoConsultaDiretoOriginal;
               _notaEnderecoConsultaDiretoOriginalCommited=_notaEnderecoConsultaDiretoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               IdNfeLondrina=_idNfeLondrinaOriginal;
               _idNfeLondrinaOriginalCommited=_idNfeLondrinaOriginal;
               XmlEnviado=_xmlEnviadoOriginal;
               _xmlEnviadoOriginalCommited=_xmlEnviadoOriginal;

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
       dirty = _idNfPrincipalOriginal != IdNfPrincipal;
      if (dirty) return true;
       dirty = _idNfCompletoNotaOriginal != IdNfCompletoNota;
      if (dirty) return true;
       dirty = _notaTipoOriginal != NotaTipo;
      if (dirty) return true;
       dirty = _situacaoOriginal != Situacao;
      if (dirty) return true;
       dirty = _mensagemOriginal != Mensagem;
      if (dirty) return true;
       dirty = _dataAtualizacaoOriginal != DataAtualizacao;
      if (dirty) return true;
       dirty = _notaNumeroOriginal != NotaNumero;
      if (dirty) return true;
       dirty = _notaSerieOriginal != NotaSerie;
      if (dirty) return true;
       dirty = _notaModeloOriginal != NotaModelo;
      if (dirty) return true;
       dirty = _notaEmitenteOriginal != NotaEmitente;
      if (dirty) return true;
       dirty = _notaDestinatarioOriginal != NotaDestinatario;
      if (dirty) return true;
       dirty = _notaDataEmissaoOriginal != NotaDataEmissao;
      if (dirty) return true;
       dirty = _notaChaveOriginal != NotaChave;
      if (dirty) return true;
       dirty = _notaEnderecoConsultaDiretoOriginal != NotaEnderecoConsultaDireto;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _idNfeLondrinaOriginal != IdNfeLondrina;
      if (dirty) return true;
       dirty = _xmlEnviadoOriginal != XmlEnviado;

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
       dirty = _idNfPrincipalOriginalCommited != IdNfPrincipal;
      if (dirty) return true;
       dirty = _idNfCompletoNotaOriginalCommited != IdNfCompletoNota;
      if (dirty) return true;
       dirty = _notaTipoOriginalCommited != NotaTipo;
      if (dirty) return true;
       dirty = _situacaoOriginalCommited != Situacao;
      if (dirty) return true;
       dirty = _mensagemOriginalCommited != Mensagem;
      if (dirty) return true;
       dirty = _dataAtualizacaoOriginalCommited != DataAtualizacao;
      if (dirty) return true;
       dirty = _notaNumeroOriginalCommited != NotaNumero;
      if (dirty) return true;
       dirty = _notaSerieOriginalCommited != NotaSerie;
      if (dirty) return true;
       dirty = _notaModeloOriginalCommited != NotaModelo;
      if (dirty) return true;
       dirty = _notaEmitenteOriginalCommited != NotaEmitente;
      if (dirty) return true;
       dirty = _notaDestinatarioOriginalCommited != NotaDestinatario;
      if (dirty) return true;
       dirty = _notaDataEmissaoOriginalCommited != NotaDataEmissao;
      if (dirty) return true;
       dirty = _notaChaveOriginalCommited != NotaChave;
      if (dirty) return true;
       dirty = _notaEnderecoConsultaDiretoOriginalCommited != NotaEnderecoConsultaDireto;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _idNfeLondrinaOriginalCommited != IdNfeLondrina;
      if (dirty) return true;
       dirty = _xmlEnviadoOriginalCommited != XmlEnviado;

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
             case "IdNfPrincipal":
                return this.IdNfPrincipal;
             case "IdNfCompletoNota":
                return this.IdNfCompletoNota;
             case "NotaTipo":
                return this.NotaTipo;
             case "Situacao":
                return this.Situacao;
             case "Mensagem":
                return this.Mensagem;
             case "DataAtualizacao":
                return this.DataAtualizacao;
             case "NotaNumero":
                return this.NotaNumero;
             case "NotaSerie":
                return this.NotaSerie;
             case "NotaModelo":
                return this.NotaModelo;
             case "NotaEmitente":
                return this.NotaEmitente;
             case "NotaDestinatario":
                return this.NotaDestinatario;
             case "NotaDataEmissao":
                return this.NotaDataEmissao;
             case "NotaChave":
                return this.NotaChave;
             case "NotaEnderecoConsultaDireto":
                return this.NotaEnderecoConsultaDireto;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "IdNfeLondrina":
                return this.IdNfeLondrina;
             case "XmlEnviado":
                return this.XmlEnviado;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
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
                  command.CommandText += " COUNT(nfe_situacao_transmissao.id_nfe_situacao_transmissao) " ;
               }
               else
               {
               command.CommandText += "nfe_situacao_transmissao.id_nfe_situacao_transmissao, " ;
               command.CommandText += "nfe_situacao_transmissao.id_nf_principal, " ;
               command.CommandText += "nfe_situacao_transmissao.id_nf_completo_nota, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_nota_tipo, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_situacao, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_mensagem, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_data_atualizacao, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_nota_numero, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_nota_serie, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_nota_modelo, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_nota_emitente, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_nota_destinatario, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_nota_data_emissao, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_nota_chave, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_nota_endereco_consulta_direto, " ;
               command.CommandText += "nfe_situacao_transmissao.entity_uid, " ;
               command.CommandText += "nfe_situacao_transmissao.version, " ;
               command.CommandText += "nfe_situacao_transmissao.id_nfe_londrina, " ;
               command.CommandText += "nfe_situacao_transmissao.nst_xml_enviado " ;
               }
               command.CommandText += " FROM  nfe_situacao_transmissao ";
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
                        orderByClause += " , nst_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nst_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nfe_situacao_transmissao.id_acs_usuario_ultima_revisao ";
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
                     case "id_nfe_situacao_transmissao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_situacao_transmissao.id_nfe_situacao_transmissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.id_nfe_situacao_transmissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal":
                     case "IdNfPrincipal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_situacao_transmissao.id_nf_principal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.id_nf_principal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_completo_nota":
                     case "IdNfCompletoNota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_situacao_transmissao.id_nf_completo_nota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.id_nf_completo_nota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_nota_tipo":
                     case "NotaTipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_situacao_transmissao.nst_nota_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_nota_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_situacao_transmissao.nst_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_mensagem":
                     case "Mensagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_situacao_transmissao.nst_mensagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_mensagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_data_atualizacao":
                     case "DataAtualizacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_situacao_transmissao.nst_data_atualizacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_data_atualizacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_nota_numero":
                     case "NotaNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_situacao_transmissao.nst_nota_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_nota_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_nota_serie":
                     case "NotaSerie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_situacao_transmissao.nst_nota_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_nota_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_nota_modelo":
                     case "NotaModelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_situacao_transmissao.nst_nota_modelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_nota_modelo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_nota_emitente":
                     case "NotaEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_situacao_transmissao.nst_nota_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_nota_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_nota_destinatario":
                     case "NotaDestinatario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_situacao_transmissao.nst_nota_destinatario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_nota_destinatario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_nota_data_emissao":
                     case "NotaDataEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_situacao_transmissao.nst_nota_data_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_nota_data_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_nota_chave":
                     case "NotaChave":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_situacao_transmissao.nst_nota_chave " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_nota_chave) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_nota_endereco_consulta_direto":
                     case "NotaEnderecoConsultaDireto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_situacao_transmissao.nst_nota_endereco_consulta_direto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_nota_endereco_consulta_direto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_situacao_transmissao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nfe_situacao_transmissao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nfe_londrina":
                     case "IdNfeLondrina":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_situacao_transmissao.id_nfe_londrina " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.id_nfe_londrina) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nst_xml_enviado":
                     case "XmlEnviado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_situacao_transmissao.nst_xml_enviado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_situacao_transmissao.nst_xml_enviado) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nst_mensagem")) 
                        {
                           whereClause += " OR UPPER(nfe_situacao_transmissao.nst_mensagem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_situacao_transmissao.nst_mensagem) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nst_nota_serie")) 
                        {
                           whereClause += " OR UPPER(nfe_situacao_transmissao.nst_nota_serie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_situacao_transmissao.nst_nota_serie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nst_nota_modelo")) 
                        {
                           whereClause += " OR UPPER(nfe_situacao_transmissao.nst_nota_modelo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_situacao_transmissao.nst_nota_modelo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nst_nota_emitente")) 
                        {
                           whereClause += " OR UPPER(nfe_situacao_transmissao.nst_nota_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_situacao_transmissao.nst_nota_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nst_nota_destinatario")) 
                        {
                           whereClause += " OR UPPER(nfe_situacao_transmissao.nst_nota_destinatario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_situacao_transmissao.nst_nota_destinatario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nst_nota_chave")) 
                        {
                           whereClause += " OR UPPER(nfe_situacao_transmissao.nst_nota_chave) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_situacao_transmissao.nst_nota_chave) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nst_nota_endereco_consulta_direto")) 
                        {
                           whereClause += " OR UPPER(nfe_situacao_transmissao.nst_nota_endereco_consulta_direto) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_situacao_transmissao.nst_nota_endereco_consulta_direto) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nfe_situacao_transmissao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_situacao_transmissao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nst_xml_enviado")) 
                        {
                           whereClause += " OR UPPER(nfe_situacao_transmissao.nst_xml_enviado) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_situacao_transmissao.nst_xml_enviado) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nfe_situacao_transmissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.id_nfe_situacao_transmissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.id_nfe_situacao_transmissao = :nfe_situacao_transmissao_ID_9993 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_ID_9993", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdNfPrincipal" || parametro.FieldName == "id_nf_principal")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.id_nf_principal = :nfe_situacao_transmissao_IdNfPrincipal_3 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_IdNfPrincipal_3", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdNfCompletoNota" || parametro.FieldName == "id_nf_completo_nota")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.id_nf_completo_nota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.id_nf_completo_nota = :nfe_situacao_transmissao_IdNfCompletoNota_2186 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_IdNfCompletoNota_2186", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaTipo" || parametro.FieldName == "nst_nota_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFTipoNota)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFTipoNota");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_tipo = :nfe_situacao_transmissao_NotaTipo_8418 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaTipo_8418", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "nst_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFSituacaoTransmissao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFSituacaoTransmissao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_situacao = :nfe_situacao_transmissao_Situacao_1502 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_Situacao_1502", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Mensagem" || parametro.FieldName == "nst_mensagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_mensagem LIKE :nfe_situacao_transmissao_Mensagem_3981 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_Mensagem_3981", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAtualizacao" || parametro.FieldName == "nst_data_atualizacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_data_atualizacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_data_atualizacao = :nfe_situacao_transmissao_DataAtualizacao_6678 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_DataAtualizacao_6678", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaNumero" || parametro.FieldName == "nst_nota_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_numero = :nfe_situacao_transmissao_NotaNumero_9745 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaNumero_9745", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaSerie" || parametro.FieldName == "nst_nota_serie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_serie LIKE :nfe_situacao_transmissao_NotaSerie_7567 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaSerie_7567", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaModelo" || parametro.FieldName == "nst_nota_modelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_modelo LIKE :nfe_situacao_transmissao_NotaModelo_8770 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaModelo_8770", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaEmitente" || parametro.FieldName == "nst_nota_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_emitente LIKE :nfe_situacao_transmissao_NotaEmitente_7677 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaEmitente_7677", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaDestinatario" || parametro.FieldName == "nst_nota_destinatario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_destinatario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_destinatario LIKE :nfe_situacao_transmissao_NotaDestinatario_983 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaDestinatario_983", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaDataEmissao" || parametro.FieldName == "nst_nota_data_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_data_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_data_emissao = :nfe_situacao_transmissao_NotaDataEmissao_4058 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaDataEmissao_4058", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaChave" || parametro.FieldName == "nst_nota_chave")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_chave IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_chave LIKE :nfe_situacao_transmissao_NotaChave_2449 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaChave_2449", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaEnderecoConsultaDireto" || parametro.FieldName == "nst_nota_endereco_consulta_direto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_endereco_consulta_direto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_endereco_consulta_direto LIKE :nfe_situacao_transmissao_NotaEnderecoConsultaDireto_8025 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaEnderecoConsultaDireto_8025", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_situacao_transmissao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.entity_uid LIKE :nfe_situacao_transmissao_EntityUid_599 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_EntityUid_599", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_situacao_transmissao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.version = :nfe_situacao_transmissao_Version_5503 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_Version_5503", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdNfeLondrina" || parametro.FieldName == "id_nfe_londrina")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.id_nfe_londrina IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.id_nfe_londrina = :nfe_situacao_transmissao_IdNfeLondrina_992 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_IdNfeLondrina_992", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XmlEnviado" || parametro.FieldName == "nst_xml_enviado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_xml_enviado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_xml_enviado LIKE :nfe_situacao_transmissao_XmlEnviado_3852 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_XmlEnviado_3852", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MensagemExato" || parametro.FieldName == "MensagemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_mensagem LIKE :nfe_situacao_transmissao_Mensagem_810 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_Mensagem_810", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaSerieExato" || parametro.FieldName == "NotaSerieExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_serie LIKE :nfe_situacao_transmissao_NotaSerie_2564 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaSerie_2564", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaModeloExato" || parametro.FieldName == "NotaModeloExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_modelo LIKE :nfe_situacao_transmissao_NotaModelo_9002 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaModelo_9002", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaEmitenteExato" || parametro.FieldName == "NotaEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_emitente LIKE :nfe_situacao_transmissao_NotaEmitente_5431 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaEmitente_5431", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaDestinatarioExato" || parametro.FieldName == "NotaDestinatarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_destinatario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_destinatario LIKE :nfe_situacao_transmissao_NotaDestinatario_714 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaDestinatario_714", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaChaveExato" || parametro.FieldName == "NotaChaveExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_chave IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_chave LIKE :nfe_situacao_transmissao_NotaChave_2401 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaChave_2401", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaEnderecoConsultaDiretoExato" || parametro.FieldName == "NotaEnderecoConsultaDiretoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_endereco_consulta_direto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_nota_endereco_consulta_direto LIKE :nfe_situacao_transmissao_NotaEnderecoConsultaDireto_5425 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_NotaEnderecoConsultaDireto_5425", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_situacao_transmissao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.entity_uid LIKE :nfe_situacao_transmissao_EntityUid_768 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_EntityUid_768", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XmlEnviadoExato" || parametro.FieldName == "XmlEnviadoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_xml_enviado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_situacao_transmissao.nst_xml_enviado LIKE :nfe_situacao_transmissao_XmlEnviado_6955 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_situacao_transmissao_XmlEnviado_6955", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfeSituacaoTransmissaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfeSituacaoTransmissaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfeSituacaoTransmissaoClass), Convert.ToInt32(read["id_nfe_situacao_transmissao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfeSituacaoTransmissaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nfe_situacao_transmissao"]);
                     entidade.IdNfPrincipal = read["id_nf_principal"] as int?;
                     entidade.IdNfCompletoNota = read["id_nf_completo_nota"] as int?;
                     entidade.NotaTipo = (IWTNFTipoNota) (read["nst_nota_tipo"] != DBNull.Value ? Enum.ToObject(typeof(IWTNFTipoNota), read["nst_nota_tipo"]) : null);
                     entidade.Situacao = (IWTNFSituacaoTransmissao) (read["nst_situacao"] != DBNull.Value ? Enum.ToObject(typeof(IWTNFSituacaoTransmissao), read["nst_situacao"]) : null);
                     entidade.Mensagem = (read["nst_mensagem"] != DBNull.Value ? read["nst_mensagem"].ToString() : null);
                     entidade.DataAtualizacao = (DateTime)read["nst_data_atualizacao"];
                     entidade.NotaNumero = read["nst_nota_numero"] as int?;
                     entidade.NotaSerie = (read["nst_nota_serie"] != DBNull.Value ? read["nst_nota_serie"].ToString() : null);
                     entidade.NotaModelo = (read["nst_nota_modelo"] != DBNull.Value ? read["nst_nota_modelo"].ToString() : null);
                     entidade.NotaEmitente = (read["nst_nota_emitente"] != DBNull.Value ? read["nst_nota_emitente"].ToString() : null);
                     entidade.NotaDestinatario = (read["nst_nota_destinatario"] != DBNull.Value ? read["nst_nota_destinatario"].ToString() : null);
                     entidade.NotaDataEmissao = (DateTime)read["nst_nota_data_emissao"];
                     entidade.NotaChave = (read["nst_nota_chave"] != DBNull.Value ? read["nst_nota_chave"].ToString() : null);
                     entidade.NotaEnderecoConsultaDireto = (read["nst_nota_endereco_consulta_direto"] != DBNull.Value ? read["nst_nota_endereco_consulta_direto"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.IdNfeLondrina = read["id_nfe_londrina"] as int?;
                     entidade.XmlEnviado = (read["nst_xml_enviado"] != DBNull.Value ? read["nst_xml_enviado"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfeSituacaoTransmissaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
