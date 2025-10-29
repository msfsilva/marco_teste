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
     [Table("notificacao_desvio","nod")]
     public class NotificacaoDesvioBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NotificacaoDesvioClass";
protected const string ErroDelete = "Erro ao excluir o NotificacaoDesvioClass  ";
protected const string ErroSave = "Erro ao salvar o NotificacaoDesvioClass.";
protected const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
protected const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 255 caracteres";
protected const string ErroDescricaoDefeitoObrigatorio = "O campo DescricaoDefeito é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroPedidoItemObrigatorio = "O campo PedidoItem é obrigatório";
protected const string ErroTipoNotificacaoDesvioObrigatorio = "O campo TipoNotificacaoDesvio é obrigatório";
protected const string ErroAcsUsuarioNotificacaoObrigatorio = "O campo AcsUsuarioNotificacao é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NotificacaoDesvioClass.";
protected const string ErroDocumentoLoad = "O campo Documento não pode ser carregado";
protected const string ErroNfDevolucaoDocumentoLoad = "O campo NfDevolucaoDocumento não pode ser carregado";
protected const string ErroPlanoAcaoDocumentoLoad = "O campo PlanoAcaoDocumento não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NotificacaoDesvioClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _valuePedidoItem;
        [Column("id_pedido_item", "pedido_item", "id_pedido_item")]
       public virtual BibliotecaEntidades.Entidades.PedidoItemClass PedidoItem
        { 
           get {                 return this._valuePedidoItem; } 
           set 
           { 
                if (this._valuePedidoItem == value)return;
                 this._valuePedidoItem = value; 
           } 
       } 

       protected string _numeroOriginal{get;private set;}
       private string _numeroOriginalCommited{get; set;}
        private string _valueNumero;
         [Column("nod_numero")]
        public virtual string Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.TipoNotificacaoDesvioClass _tipoNotificacaoDesvioOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.TipoNotificacaoDesvioClass _tipoNotificacaoDesvioOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.TipoNotificacaoDesvioClass _valueTipoNotificacaoDesvio;
        [Column("id_tipo_notificacao_desvio", "tipo_notificacao_desvio", "id_tipo_notificacao_desvio")]
       public virtual BibliotecaEntidades.Entidades.TipoNotificacaoDesvioClass TipoNotificacaoDesvio
        { 
           get {                 return this._valueTipoNotificacaoDesvio; } 
           set 
           { 
                if (this._valueTipoNotificacaoDesvio == value)return;
                 this._valueTipoNotificacaoDesvio = value; 
           } 
       } 

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("nod_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected string _descricaoDefeitoOriginal{get;private set;}
       private string _descricaoDefeitoOriginalCommited{get; set;}
        private string _valueDescricaoDefeito;
         [Column("nod_descricao_defeito")]
        public virtual string DescricaoDefeito
         { 
            get { return this._valueDescricaoDefeito; } 
            set 
            { 
                if (this._valueDescricaoDefeito == value)return;
                 this._valueDescricaoDefeito = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.TipoDefeitoClass _tipoDefeitoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.TipoDefeitoClass _tipoDefeitoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.TipoDefeitoClass _valueTipoDefeito;
        [Column("id_tipo_defeito", "tipo_defeito", "id_tipo_defeito")]
       public virtual BibliotecaEntidades.Entidades.TipoDefeitoClass TipoDefeito
        { 
           get {                 return this._valueTipoDefeito; } 
           set 
           { 
                if (this._valueTipoDefeito == value)return;
                 this._valueTipoDefeito = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _valuePostoTrabalho;
        [Column("id_posto_trabalho", "posto_trabalho", "id_posto_trabalho")]
       public virtual BibliotecaEntidades.Entidades.PostoTrabalhoClass PostoTrabalho
        { 
           get {                 return this._valuePostoTrabalho; } 
           set 
           { 
                if (this._valuePostoTrabalho == value)return;
                 this._valuePostoTrabalho = value; 
           } 
       } 

       protected double _qtdPecasDefeituosasOriginal{get;private set;}
       private double _qtdPecasDefeituosasOriginalCommited{get; set;}
        private double _valueQtdPecasDefeituosas;
         [Column("nod_qtd_pecas_defeituosas")]
        public virtual double QtdPecasDefeituosas
         { 
            get { return this._valueQtdPecasDefeituosas; } 
            set 
            { 
                if (this._valueQtdPecasDefeituosas == value)return;
                 this._valueQtdPecasDefeituosas = value; 
            } 
        } 

       protected double _qtdPecasDevolvidasOriginal{get;private set;}
       private double _qtdPecasDevolvidasOriginalCommited{get; set;}
        private double _valueQtdPecasDevolvidas;
         [Column("nod_qtd_pecas_devolvidas")]
        public virtual double QtdPecasDevolvidas
         { 
            get { return this._valueQtdPecasDevolvidas; } 
            set 
            { 
                if (this._valueQtdPecasDevolvidas == value)return;
                 this._valueQtdPecasDevolvidas = value; 
            } 
        } 

       protected string _numeroNfClienteOriginal{get;private set;}
       private string _numeroNfClienteOriginalCommited{get; set;}
        private string _valueNumeroNfCliente;
         [Column("nod_numero_nf_cliente")]
        public virtual string NumeroNfCliente
         { 
            get { return this._valueNumeroNfCliente; } 
            set 
            { 
                if (this._valueNumeroNfCliente == value)return;
                 this._valueNumeroNfCliente = value; 
            } 
        } 

       protected DateTime? _dataEmissaoNfClienteOriginal{get;private set;}
       private DateTime? _dataEmissaoNfClienteOriginalCommited{get; set;}
        private DateTime? _valueDataEmissaoNfCliente;
         [Column("nod_data_emissao_nf_cliente")]
        public virtual DateTime? DataEmissaoNfCliente
         { 
            get { return this._valueDataEmissaoNfCliente; } 
            set 
            { 
                if (this._valueDataEmissaoNfCliente == value)return;
                 this._valueDataEmissaoNfCliente = value; 
            } 
        } 

       protected double? _valorNfClienteOriginal{get;private set;}
       private double? _valorNfClienteOriginalCommited{get; set;}
        private double? _valueValorNfCliente;
         [Column("nod_valor_nf_cliente")]
        public virtual double? ValorNfCliente
         { 
            get { return this._valueValorNfCliente; } 
            set 
            { 
                if (this._valueValorNfCliente == value)return;
                 this._valueValorNfCliente = value; 
            } 
        } 

       protected string _justificativaProducaoOriginal{get;private set;}
       private string _justificativaProducaoOriginalCommited{get; set;}
        private string _valueJustificativaProducao;
         [Column("nod_justificativa_producao")]
        public virtual string JustificativaProducao
         { 
            get { return this._valueJustificativaProducao; } 
            set 
            { 
                if (this._valueJustificativaProducao == value)return;
                 this._valueJustificativaProducao = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioNotificacaoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioNotificacaoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioNotificacao;
        [Column("id_acs_usuario_notificacao", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioNotificacao
        { 
           get {                 return this._valueAcsUsuarioNotificacao; } 
           set 
           { 
                if (this._valueAcsUsuarioNotificacao == value)return;
                 this._valueAcsUsuarioNotificacao = value; 
           } 
       } 

       protected string _documentoOriginal= null;
        private string _documentoOriginalCommited= null;
        private bool _DocumentoLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool DocumentoLoaded 
       { 
            get {                     return _DocumentoLoaded; } 
           set 
           { 
                this._DocumentoLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueDocumento;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("nod_documento")]
        public virtual byte[] Documento
         { 
            get { 
                   if (!this.DocumentoLoaded) 
                   {
                       this.LoadDocumento();
                   }
                   return this._valueDocumento; } 
            set 
            { 
                DocumentoLoaded = true; 
                if (this._valueDocumento == value)return;
                 this._valueDocumento = value; 
            } 
        } 

       protected string _documentoNomeOriginal{get;private set;}
       private string _documentoNomeOriginalCommited{get; set;}
        private string _valueDocumentoNome;
         [Column("nod_documento_nome")]
        public virtual string DocumentoNome
         { 
            get { return this._valueDocumentoNome; } 
            set 
            { 
                if (this._valueDocumentoNome == value)return;
                 this._valueDocumentoNome = value; 
            } 
        } 

       protected string _nfDevolucaoDocumentoOriginal= null;
        private string _nfDevolucaoDocumentoOriginalCommited= null;
        private bool _NfDevolucaoDocumentoLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool NfDevolucaoDocumentoLoaded 
       { 
            get {                     return _NfDevolucaoDocumentoLoaded; } 
           set 
           { 
                this._NfDevolucaoDocumentoLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueNfDevolucaoDocumento;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("nod_nf_devolucao_documento")]
        public virtual byte[] NfDevolucaoDocumento
         { 
            get { 
                   if (!this.NfDevolucaoDocumentoLoaded) 
                   {
                       this.LoadNfDevolucaoDocumento();
                   }
                   return this._valueNfDevolucaoDocumento; } 
            set 
            { 
                NfDevolucaoDocumentoLoaded = true; 
                if (this._valueNfDevolucaoDocumento == value)return;
                 this._valueNfDevolucaoDocumento = value; 
            } 
        } 

       protected string _nfDevolucaoDocumentoNomeOriginal{get;private set;}
       private string _nfDevolucaoDocumentoNomeOriginalCommited{get; set;}
        private string _valueNfDevolucaoDocumentoNome;
         [Column("nod_nf_devolucao_documento_nome")]
        public virtual string NfDevolucaoDocumentoNome
         { 
            get { return this._valueNfDevolucaoDocumentoNome; } 
            set 
            { 
                if (this._valueNfDevolucaoDocumentoNome == value)return;
                 this._valueNfDevolucaoDocumentoNome = value; 
            } 
        } 

       protected string _planoAcaoDocumentoOriginal= null;
        private string _planoAcaoDocumentoOriginalCommited= null;
        private bool _PlanoAcaoDocumentoLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool PlanoAcaoDocumentoLoaded 
       { 
            get {                     return _PlanoAcaoDocumentoLoaded; } 
           set 
           { 
                this._PlanoAcaoDocumentoLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valuePlanoAcaoDocumento;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("nod_plano_acao_documento")]
        public virtual byte[] PlanoAcaoDocumento
         { 
            get { 
                   if (!this.PlanoAcaoDocumentoLoaded) 
                   {
                       this.LoadPlanoAcaoDocumento();
                   }
                   return this._valuePlanoAcaoDocumento; } 
            set 
            { 
                PlanoAcaoDocumentoLoaded = true; 
                if (this._valuePlanoAcaoDocumento == value)return;
                 this._valuePlanoAcaoDocumento = value; 
            } 
        } 

       protected string _planoAcaoDocumentoNomeOriginal{get;private set;}
       private string _planoAcaoDocumentoNomeOriginalCommited{get; set;}
        private string _valuePlanoAcaoDocumentoNome;
         [Column("nod_plano_acao_documento_nome")]
        public virtual string PlanoAcaoDocumentoNome
         { 
            get { return this._valuePlanoAcaoDocumentoNome; } 
            set 
            { 
                if (this._valuePlanoAcaoDocumentoNome == value)return;
                 this._valuePlanoAcaoDocumentoNome = value; 
            } 
        } 

        public NotificacaoDesvioBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.QtdPecasDefeituosas = 0;
           this.QtdPecasDevolvidas = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NotificacaoDesvioClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NotificacaoDesvioClass) GetEntity(typeof(NotificacaoDesvioClass),id,usuarioAtual,connection, operacao);
        }
private void LoadDocumento()
        {
            try
            {
                if (this.ID == -1)
                {

                    DocumentoLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT nod_documento FROM notificacao_desvio WHERE id_notificacao_desvio = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueDocumento = (byte[]) tmp;
                }
                if (this._valueDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _documentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                     }
                  } 
                  else 
                  { 
                        _documentoOriginal = null ;
                  } 
                DocumentoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroDocumentoLoad + "\r\n" + e.Message, e);
            }
        }
private void LoadNfDevolucaoDocumento()
        {
            try
            {
                if (this.ID == -1)
                {

                    NfDevolucaoDocumentoLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT nod_nf_devolucao_documento FROM notificacao_desvio WHERE id_notificacao_desvio = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueNfDevolucaoDocumento = (byte[]) tmp;
                }
                if (this._valueNfDevolucaoDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _nfDevolucaoDocumentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueNfDevolucaoDocumento));
                     }
                  } 
                  else 
                  { 
                        _nfDevolucaoDocumentoOriginal = null ;
                  } 
                NfDevolucaoDocumentoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroNfDevolucaoDocumentoLoad + "\r\n" + e.Message, e);
            }
        }
private void LoadPlanoAcaoDocumento()
        {
            try
            {
                if (this.ID == -1)
                {

                    PlanoAcaoDocumentoLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT nod_plano_acao_documento FROM notificacao_desvio WHERE id_notificacao_desvio = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valuePlanoAcaoDocumento = (byte[]) tmp;
                }
                if (this._valuePlanoAcaoDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _planoAcaoDocumentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valuePlanoAcaoDocumento));
                     }
                  } 
                  else 
                  { 
                        _planoAcaoDocumentoOriginal = null ;
                  } 
                PlanoAcaoDocumentoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroPlanoAcaoDocumentoLoad + "\r\n" + e.Message, e);
            }
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Numero))
                {
                    throw new Exception(ErroNumeroObrigatorio);
                }
                if (Numero.Length >255)
                {
                    throw new Exception( ErroNumeroComprimento);
                }
                if (string.IsNullOrEmpty(DescricaoDefeito))
                {
                    throw new Exception(ErroDescricaoDefeitoObrigatorio);
                }
                if ( _valuePedidoItem == null)
                {
                    throw new Exception(ErroPedidoItemObrigatorio);
                }
                if ( _valueTipoNotificacaoDesvio == null)
                {
                    throw new Exception(ErroTipoNotificacaoDesvioObrigatorio);
                }
                if ( _valueAcsUsuarioNotificacao == null)
                {
                    throw new Exception(ErroAcsUsuarioNotificacaoObrigatorio);
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
                    "  public.notificacao_desvio  " +
                    "WHERE " +
                    "  id_notificacao_desvio = :id";
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
                        "  public.notificacao_desvio   " +
                        "SET  " + 
                        "  id_pedido_item = :id_pedido_item, " + 
                        "  nod_numero = :nod_numero, " + 
                        "  id_tipo_notificacao_desvio = :id_tipo_notificacao_desvio, " + 
                        "  nod_data = :nod_data, " + 
                        "  nod_descricao_defeito = :nod_descricao_defeito, " + 
                        "  id_tipo_defeito = :id_tipo_defeito, " + 
                        "  id_posto_trabalho = :id_posto_trabalho, " + 
                        "  nod_qtd_pecas_defeituosas = :nod_qtd_pecas_defeituosas, " + 
                        "  nod_qtd_pecas_devolvidas = :nod_qtd_pecas_devolvidas, " + 
                        "  nod_numero_nf_cliente = :nod_numero_nf_cliente, " + 
                        "  nod_data_emissao_nf_cliente = :nod_data_emissao_nf_cliente, " + 
                        "  nod_valor_nf_cliente = :nod_valor_nf_cliente, " + 
                        "  nod_justificativa_producao = :nod_justificativa_producao, " + 
                        "  id_acs_usuario_notificacao = :id_acs_usuario_notificacao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nod_documento = :nod_documento, " + 
                        "  nod_documento_nome = :nod_documento_nome, " + 
                        "  nod_nf_devolucao_documento = :nod_nf_devolucao_documento, " + 
                        "  nod_nf_devolucao_documento_nome = :nod_nf_devolucao_documento_nome, " + 
                        "  nod_plano_acao_documento = :nod_plano_acao_documento, " + 
                        "  nod_plano_acao_documento_nome = :nod_plano_acao_documento_nome "+
                        "WHERE  " +
                        "  id_notificacao_desvio = :id " +
                        "RETURNING id_notificacao_desvio;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.notificacao_desvio " +
                        "( " +
                        "  id_pedido_item , " + 
                        "  nod_numero , " + 
                        "  id_tipo_notificacao_desvio , " + 
                        "  nod_data , " + 
                        "  nod_descricao_defeito , " + 
                        "  id_tipo_defeito , " + 
                        "  id_posto_trabalho , " + 
                        "  nod_qtd_pecas_defeituosas , " + 
                        "  nod_qtd_pecas_devolvidas , " + 
                        "  nod_numero_nf_cliente , " + 
                        "  nod_data_emissao_nf_cliente , " + 
                        "  nod_valor_nf_cliente , " + 
                        "  nod_justificativa_producao , " + 
                        "  id_acs_usuario_notificacao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nod_documento , " + 
                        "  nod_documento_nome , " + 
                        "  nod_nf_devolucao_documento , " + 
                        "  nod_nf_devolucao_documento_nome , " + 
                        "  nod_plano_acao_documento , " + 
                        "  nod_plano_acao_documento_nome  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_pedido_item , " + 
                        "  :nod_numero , " + 
                        "  :id_tipo_notificacao_desvio , " + 
                        "  :nod_data , " + 
                        "  :nod_descricao_defeito , " + 
                        "  :id_tipo_defeito , " + 
                        "  :id_posto_trabalho , " + 
                        "  :nod_qtd_pecas_defeituosas , " + 
                        "  :nod_qtd_pecas_devolvidas , " + 
                        "  :nod_numero_nf_cliente , " + 
                        "  :nod_data_emissao_nf_cliente , " + 
                        "  :nod_valor_nf_cliente , " + 
                        "  :nod_justificativa_producao , " + 
                        "  :id_acs_usuario_notificacao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nod_documento , " + 
                        "  :nod_documento_nome , " + 
                        "  :nod_nf_devolucao_documento , " + 
                        "  :nod_nf_devolucao_documento_nome , " + 
                        "  :nod_plano_acao_documento , " + 
                        "  :nod_plano_acao_documento_nome  "+
                        ")RETURNING id_notificacao_desvio;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PedidoItem==null ? (object) DBNull.Value : this.PedidoItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tipo_notificacao_desvio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.TipoNotificacaoDesvio==null ? (object) DBNull.Value : this.TipoNotificacaoDesvio.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_descricao_defeito", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoDefeito ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tipo_defeito", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.TipoDefeito==null ? (object) DBNull.Value : this.TipoDefeito.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PostoTrabalho==null ? (object) DBNull.Value : this.PostoTrabalho.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_qtd_pecas_defeituosas", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdPecasDefeituosas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_qtd_pecas_devolvidas", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdPecasDevolvidas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_numero_nf_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroNfCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_data_emissao_nf_cliente", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEmissaoNfCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_valor_nf_cliente", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorNfCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_justificativa_producao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JustificativaProducao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_notificacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioNotificacao==null ? (object) DBNull.Value : this.AcsUsuarioNotificacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_documento", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Documento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_documento_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentoNome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_nf_devolucao_documento", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NfDevolucaoDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_nf_devolucao_documento_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NfDevolucaoDocumentoNome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_plano_acao_documento", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoAcaoDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_plano_acao_documento_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoAcaoDocumentoNome ?? DBNull.Value;

 
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
        public static NotificacaoDesvioClass CopiarEntidade(NotificacaoDesvioClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NotificacaoDesvioClass toRet = new NotificacaoDesvioClass(usuario,conn);
 toRet.PedidoItem= entidadeCopiar.PedidoItem;
 toRet.Numero= entidadeCopiar.Numero;
 toRet.TipoNotificacaoDesvio= entidadeCopiar.TipoNotificacaoDesvio;
 toRet.Data= entidadeCopiar.Data;
 toRet.DescricaoDefeito= entidadeCopiar.DescricaoDefeito;
 toRet.TipoDefeito= entidadeCopiar.TipoDefeito;
 toRet.PostoTrabalho= entidadeCopiar.PostoTrabalho;
 toRet.QtdPecasDefeituosas= entidadeCopiar.QtdPecasDefeituosas;
 toRet.QtdPecasDevolvidas= entidadeCopiar.QtdPecasDevolvidas;
 toRet.NumeroNfCliente= entidadeCopiar.NumeroNfCliente;
 toRet.DataEmissaoNfCliente= entidadeCopiar.DataEmissaoNfCliente;
 toRet.ValorNfCliente= entidadeCopiar.ValorNfCliente;
 toRet.JustificativaProducao= entidadeCopiar.JustificativaProducao;
 toRet.AcsUsuarioNotificacao= entidadeCopiar.AcsUsuarioNotificacao;
 toRet.Documento= entidadeCopiar.Documento;
 toRet.DocumentoNome= entidadeCopiar.DocumentoNome;
 toRet.NfDevolucaoDocumento= entidadeCopiar.NfDevolucaoDocumento;
 toRet.NfDevolucaoDocumentoNome= entidadeCopiar.NfDevolucaoDocumentoNome;
 toRet.PlanoAcaoDocumento= entidadeCopiar.PlanoAcaoDocumento;
 toRet.PlanoAcaoDocumentoNome= entidadeCopiar.PlanoAcaoDocumentoNome;

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
       _pedidoItemOriginal = PedidoItem;
       _pedidoItemOriginalCommited = _pedidoItemOriginal;
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _tipoNotificacaoDesvioOriginal = TipoNotificacaoDesvio;
       _tipoNotificacaoDesvioOriginalCommited = _tipoNotificacaoDesvioOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _descricaoDefeitoOriginal = DescricaoDefeito;
       _descricaoDefeitoOriginalCommited = _descricaoDefeitoOriginal;
       _tipoDefeitoOriginal = TipoDefeito;
       _tipoDefeitoOriginalCommited = _tipoDefeitoOriginal;
       _postoTrabalhoOriginal = PostoTrabalho;
       _postoTrabalhoOriginalCommited = _postoTrabalhoOriginal;
       _qtdPecasDefeituosasOriginal = QtdPecasDefeituosas;
       _qtdPecasDefeituosasOriginalCommited = _qtdPecasDefeituosasOriginal;
       _qtdPecasDevolvidasOriginal = QtdPecasDevolvidas;
       _qtdPecasDevolvidasOriginalCommited = _qtdPecasDevolvidasOriginal;
       _numeroNfClienteOriginal = NumeroNfCliente;
       _numeroNfClienteOriginalCommited = _numeroNfClienteOriginal;
       _dataEmissaoNfClienteOriginal = DataEmissaoNfCliente;
       _dataEmissaoNfClienteOriginalCommited = _dataEmissaoNfClienteOriginal;
       _valorNfClienteOriginal = ValorNfCliente;
       _valorNfClienteOriginalCommited = _valorNfClienteOriginal;
       _justificativaProducaoOriginal = JustificativaProducao;
       _justificativaProducaoOriginalCommited = _justificativaProducaoOriginal;
       _acsUsuarioNotificacaoOriginal = AcsUsuarioNotificacao;
       _acsUsuarioNotificacaoOriginalCommited = _acsUsuarioNotificacaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _documentoNomeOriginal = DocumentoNome;
       _documentoNomeOriginalCommited = _documentoNomeOriginal;
       _nfDevolucaoDocumentoNomeOriginal = NfDevolucaoDocumentoNome;
       _nfDevolucaoDocumentoNomeOriginalCommited = _nfDevolucaoDocumentoNomeOriginal;
       _planoAcaoDocumentoNomeOriginal = PlanoAcaoDocumentoNome;
       _planoAcaoDocumentoNomeOriginalCommited = _planoAcaoDocumentoNomeOriginal;

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
       _pedidoItemOriginalCommited = PedidoItem;
       _numeroOriginalCommited = Numero;
       _tipoNotificacaoDesvioOriginalCommited = TipoNotificacaoDesvio;
       _dataOriginalCommited = Data;
       _descricaoDefeitoOriginalCommited = DescricaoDefeito;
       _tipoDefeitoOriginalCommited = TipoDefeito;
       _postoTrabalhoOriginalCommited = PostoTrabalho;
       _qtdPecasDefeituosasOriginalCommited = QtdPecasDefeituosas;
       _qtdPecasDevolvidasOriginalCommited = QtdPecasDevolvidas;
       _numeroNfClienteOriginalCommited = NumeroNfCliente;
       _dataEmissaoNfClienteOriginalCommited = DataEmissaoNfCliente;
       _valorNfClienteOriginalCommited = ValorNfCliente;
       _justificativaProducaoOriginalCommited = JustificativaProducao;
       _acsUsuarioNotificacaoOriginalCommited = AcsUsuarioNotificacao;
       _versionOriginalCommited = Version;
       _documentoNomeOriginalCommited = DocumentoNome;
       _nfDevolucaoDocumentoNomeOriginalCommited = NfDevolucaoDocumentoNome;
       _planoAcaoDocumentoNomeOriginalCommited = PlanoAcaoDocumentoNome;

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
               if (DocumentoLoaded)
               {
                  if(this._valueDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _documentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                     }
                  } 
                  else 
                  { 
                        _documentoOriginal = null ;
                  } 
               }
               if (NfDevolucaoDocumentoLoaded)
               {
                  if(this._valueNfDevolucaoDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _nfDevolucaoDocumentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueNfDevolucaoDocumento));
                     }
                  } 
                  else 
                  { 
                        _nfDevolucaoDocumentoOriginal = null ;
                  } 
               }
               if (PlanoAcaoDocumentoLoaded)
               {
                  if(this._valuePlanoAcaoDocumento != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _planoAcaoDocumentoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valuePlanoAcaoDocumento));
                     }
                  } 
                  else 
                  { 
                        _planoAcaoDocumentoOriginal = null ;
                  } 
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
               PedidoItem=_pedidoItemOriginal;
               _pedidoItemOriginalCommited=_pedidoItemOriginal;
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               TipoNotificacaoDesvio=_tipoNotificacaoDesvioOriginal;
               _tipoNotificacaoDesvioOriginalCommited=_tipoNotificacaoDesvioOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               DescricaoDefeito=_descricaoDefeitoOriginal;
               _descricaoDefeitoOriginalCommited=_descricaoDefeitoOriginal;
               TipoDefeito=_tipoDefeitoOriginal;
               _tipoDefeitoOriginalCommited=_tipoDefeitoOriginal;
               PostoTrabalho=_postoTrabalhoOriginal;
               _postoTrabalhoOriginalCommited=_postoTrabalhoOriginal;
               QtdPecasDefeituosas=_qtdPecasDefeituosasOriginal;
               _qtdPecasDefeituosasOriginalCommited=_qtdPecasDefeituosasOriginal;
               QtdPecasDevolvidas=_qtdPecasDevolvidasOriginal;
               _qtdPecasDevolvidasOriginalCommited=_qtdPecasDevolvidasOriginal;
               NumeroNfCliente=_numeroNfClienteOriginal;
               _numeroNfClienteOriginalCommited=_numeroNfClienteOriginal;
               DataEmissaoNfCliente=_dataEmissaoNfClienteOriginal;
               _dataEmissaoNfClienteOriginalCommited=_dataEmissaoNfClienteOriginal;
               ValorNfCliente=_valorNfClienteOriginal;
               _valorNfClienteOriginalCommited=_valorNfClienteOriginal;
               JustificativaProducao=_justificativaProducaoOriginal;
               _justificativaProducaoOriginalCommited=_justificativaProducaoOriginal;
               AcsUsuarioNotificacao=_acsUsuarioNotificacaoOriginal;
               _acsUsuarioNotificacaoOriginalCommited=_acsUsuarioNotificacaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               DocumentoLoaded = false;
               this._documentoOriginal = null;
               this._documentoOriginalCommited = null;
               this._valueDocumento = null;
               DocumentoNome=_documentoNomeOriginal;
               _documentoNomeOriginalCommited=_documentoNomeOriginal;
               NfDevolucaoDocumentoLoaded = false;
               this._nfDevolucaoDocumentoOriginal = null;
               this._nfDevolucaoDocumentoOriginalCommited = null;
               this._valueNfDevolucaoDocumento = null;
               NfDevolucaoDocumentoNome=_nfDevolucaoDocumentoNomeOriginal;
               _nfDevolucaoDocumentoNomeOriginalCommited=_nfDevolucaoDocumentoNomeOriginal;
               PlanoAcaoDocumentoLoaded = false;
               this._planoAcaoDocumentoOriginal = null;
               this._planoAcaoDocumentoOriginalCommited = null;
               this._valuePlanoAcaoDocumento = null;
               PlanoAcaoDocumentoNome=_planoAcaoDocumentoNomeOriginal;
               _planoAcaoDocumentoNomeOriginalCommited=_planoAcaoDocumentoNomeOriginal;

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
       if (_pedidoItemOriginal!=null)
       {
          dirty = !_pedidoItemOriginal.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
       }
      if (dirty) return true;
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       if (_tipoNotificacaoDesvioOriginal!=null)
       {
          dirty = !_tipoNotificacaoDesvioOriginal.Equals(TipoNotificacaoDesvio);
       }
       else
       {
            dirty = TipoNotificacaoDesvio != null;
       }
      if (dirty) return true;
       dirty = _dataOriginal != Data;
      if (dirty) return true;
       dirty = _descricaoDefeitoOriginal != DescricaoDefeito;
      if (dirty) return true;
       if (_tipoDefeitoOriginal!=null)
       {
          dirty = !_tipoDefeitoOriginal.Equals(TipoDefeito);
       }
       else
       {
            dirty = TipoDefeito != null;
       }
      if (dirty) return true;
       if (_postoTrabalhoOriginal!=null)
       {
          dirty = !_postoTrabalhoOriginal.Equals(PostoTrabalho);
       }
       else
       {
            dirty = PostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _qtdPecasDefeituosasOriginal != QtdPecasDefeituosas;
      if (dirty) return true;
       dirty = _qtdPecasDevolvidasOriginal != QtdPecasDevolvidas;
      if (dirty) return true;
       dirty = _numeroNfClienteOriginal != NumeroNfCliente;
      if (dirty) return true;
       dirty = _dataEmissaoNfClienteOriginal != DataEmissaoNfCliente;
      if (dirty) return true;
       dirty = _valorNfClienteOriginal != ValorNfCliente;
      if (dirty) return true;
       dirty = _justificativaProducaoOriginal != JustificativaProducao;
      if (dirty) return true;
       if (_acsUsuarioNotificacaoOriginal!=null)
       {
          dirty = !_acsUsuarioNotificacaoOriginal.Equals(AcsUsuarioNotificacao);
       }
       else
       {
            dirty = AcsUsuarioNotificacao != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
               if (DocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpDocumento ;
                      if (this._valueDocumento == null) 
                      { 
                         tmpDocumento = null; 
                      } 
                      else 
                      { 
                         tmpDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                      } 
                       dirty = _documentoOriginal != tmpDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _documentoNomeOriginal != DocumentoNome;
      if (dirty) return true;
               if (NfDevolucaoDocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpNfDevolucaoDocumento ;
                      if (this._valueNfDevolucaoDocumento == null) 
                      { 
                         tmpNfDevolucaoDocumento = null; 
                      } 
                      else 
                      { 
                         tmpNfDevolucaoDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valueNfDevolucaoDocumento));
                      } 
                       dirty = _nfDevolucaoDocumentoOriginal != tmpNfDevolucaoDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _nfDevolucaoDocumentoNomeOriginal != NfDevolucaoDocumentoNome;
      if (dirty) return true;
               if (PlanoAcaoDocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpPlanoAcaoDocumento ;
                      if (this._valuePlanoAcaoDocumento == null) 
                      { 
                         tmpPlanoAcaoDocumento = null; 
                      } 
                      else 
                      { 
                         tmpPlanoAcaoDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valuePlanoAcaoDocumento));
                      } 
                       dirty = _planoAcaoDocumentoOriginal != tmpPlanoAcaoDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _planoAcaoDocumentoNomeOriginal != PlanoAcaoDocumentoNome;

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
       if (_pedidoItemOriginalCommited!=null)
       {
          dirty = !_pedidoItemOriginalCommited.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
       }
      if (dirty) return true;
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       if (_tipoNotificacaoDesvioOriginalCommited!=null)
       {
          dirty = !_tipoNotificacaoDesvioOriginalCommited.Equals(TipoNotificacaoDesvio);
       }
       else
       {
            dirty = TipoNotificacaoDesvio != null;
       }
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
       dirty = _descricaoDefeitoOriginalCommited != DescricaoDefeito;
      if (dirty) return true;
       if (_tipoDefeitoOriginalCommited!=null)
       {
          dirty = !_tipoDefeitoOriginalCommited.Equals(TipoDefeito);
       }
       else
       {
            dirty = TipoDefeito != null;
       }
      if (dirty) return true;
       if (_postoTrabalhoOriginalCommited!=null)
       {
          dirty = !_postoTrabalhoOriginalCommited.Equals(PostoTrabalho);
       }
       else
       {
            dirty = PostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _qtdPecasDefeituosasOriginalCommited != QtdPecasDefeituosas;
      if (dirty) return true;
       dirty = _qtdPecasDevolvidasOriginalCommited != QtdPecasDevolvidas;
      if (dirty) return true;
       dirty = _numeroNfClienteOriginalCommited != NumeroNfCliente;
      if (dirty) return true;
       dirty = _dataEmissaoNfClienteOriginalCommited != DataEmissaoNfCliente;
      if (dirty) return true;
       dirty = _valorNfClienteOriginalCommited != ValorNfCliente;
      if (dirty) return true;
       dirty = _justificativaProducaoOriginalCommited != JustificativaProducao;
      if (dirty) return true;
       if (_acsUsuarioNotificacaoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioNotificacaoOriginalCommited.Equals(AcsUsuarioNotificacao);
       }
       else
       {
            dirty = AcsUsuarioNotificacao != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
               if (DocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpDocumento ;
                      if (this._valueDocumento == null) 
                      { 
                         tmpDocumento = null; 
                      } 
                      else 
                      { 
                         tmpDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valueDocumento));
                      } 
                       dirty = _documentoOriginalCommited != tmpDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _documentoNomeOriginalCommited != DocumentoNome;
      if (dirty) return true;
               if (NfDevolucaoDocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpNfDevolucaoDocumento ;
                      if (this._valueNfDevolucaoDocumento == null) 
                      { 
                         tmpNfDevolucaoDocumento = null; 
                      } 
                      else 
                      { 
                         tmpNfDevolucaoDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valueNfDevolucaoDocumento));
                      } 
                       dirty = _nfDevolucaoDocumentoOriginalCommited != tmpNfDevolucaoDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _nfDevolucaoDocumentoNomeOriginalCommited != NfDevolucaoDocumentoNome;
      if (dirty) return true;
               if (PlanoAcaoDocumentoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpPlanoAcaoDocumento ;
                      if (this._valuePlanoAcaoDocumento == null) 
                      { 
                         tmpPlanoAcaoDocumento = null; 
                      } 
                      else 
                      { 
                         tmpPlanoAcaoDocumento = Convert.ToBase64String(sha1.ComputeHash(this._valuePlanoAcaoDocumento));
                      } 
                       dirty = _planoAcaoDocumentoOriginalCommited != tmpPlanoAcaoDocumento;
                   }
               }
      if (dirty) return true;
       dirty = _planoAcaoDocumentoNomeOriginalCommited != PlanoAcaoDocumentoNome;

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
             case "PedidoItem":
                return this.PedidoItem;
             case "Numero":
                return this.Numero;
             case "TipoNotificacaoDesvio":
                return this.TipoNotificacaoDesvio;
             case "Data":
                return this.Data;
             case "DescricaoDefeito":
                return this.DescricaoDefeito;
             case "TipoDefeito":
                return this.TipoDefeito;
             case "PostoTrabalho":
                return this.PostoTrabalho;
             case "QtdPecasDefeituosas":
                return this.QtdPecasDefeituosas;
             case "QtdPecasDevolvidas":
                return this.QtdPecasDevolvidas;
             case "NumeroNfCliente":
                return this.NumeroNfCliente;
             case "DataEmissaoNfCliente":
                return this.DataEmissaoNfCliente;
             case "ValorNfCliente":
                return this.ValorNfCliente;
             case "JustificativaProducao":
                return this.JustificativaProducao;
             case "AcsUsuarioNotificacao":
                return this.AcsUsuarioNotificacao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Documento":
                return this.Documento;
             case "DocumentoNome":
                return this.DocumentoNome;
             case "NfDevolucaoDocumento":
                return this.NfDevolucaoDocumento;
             case "NfDevolucaoDocumentoNome":
                return this.NfDevolucaoDocumentoNome;
             case "PlanoAcaoDocumento":
                return this.PlanoAcaoDocumento;
             case "PlanoAcaoDocumentoNome":
                return this.PlanoAcaoDocumentoNome;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (PedidoItem!=null)
                PedidoItem.ChangeSingleConnection(newConnection);
             if (TipoNotificacaoDesvio!=null)
                TipoNotificacaoDesvio.ChangeSingleConnection(newConnection);
             if (TipoDefeito!=null)
                TipoDefeito.ChangeSingleConnection(newConnection);
             if (PostoTrabalho!=null)
                PostoTrabalho.ChangeSingleConnection(newConnection);
             if (AcsUsuarioNotificacao!=null)
                AcsUsuarioNotificacao.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(notificacao_desvio.id_notificacao_desvio) " ;
               }
               else
               {
               command.CommandText += "notificacao_desvio.id_notificacao_desvio, " ;
               command.CommandText += "notificacao_desvio.id_pedido_item, " ;
               command.CommandText += "notificacao_desvio.nod_numero, " ;
               command.CommandText += "notificacao_desvio.id_tipo_notificacao_desvio, " ;
               command.CommandText += "notificacao_desvio.nod_data, " ;
               command.CommandText += "notificacao_desvio.nod_descricao_defeito, " ;
               command.CommandText += "notificacao_desvio.id_tipo_defeito, " ;
               command.CommandText += "notificacao_desvio.id_posto_trabalho, " ;
               command.CommandText += "notificacao_desvio.nod_qtd_pecas_defeituosas, " ;
               command.CommandText += "notificacao_desvio.nod_qtd_pecas_devolvidas, " ;
               command.CommandText += "notificacao_desvio.nod_numero_nf_cliente, " ;
               command.CommandText += "notificacao_desvio.nod_data_emissao_nf_cliente, " ;
               command.CommandText += "notificacao_desvio.nod_valor_nf_cliente, " ;
               command.CommandText += "notificacao_desvio.nod_justificativa_producao, " ;
               command.CommandText += "notificacao_desvio.id_acs_usuario_notificacao, " ;
               command.CommandText += "notificacao_desvio.entity_uid, " ;
               command.CommandText += "notificacao_desvio.version, " ;
               command.CommandText += "notificacao_desvio.nod_documento_nome, " ;
               command.CommandText += "notificacao_desvio.nod_nf_devolucao_documento_nome, " ;
               command.CommandText += "notificacao_desvio.nod_plano_acao_documento_nome " ;
               }
               command.CommandText += " FROM  notificacao_desvio ";
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
                        orderByClause += " , nod_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nod_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = notificacao_desvio.id_acs_usuario_ultima_revisao ";
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
                     case "id_notificacao_desvio":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , notificacao_desvio.id_notificacao_desvio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.id_notificacao_desvio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pedido_item":
                     case "PedidoItem":
                     command.CommandText += " LEFT JOIN pedido_item as pedido_item_PedidoItem ON pedido_item_PedidoItem.id_pedido_item = notificacao_desvio.id_pedido_item ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_PedidoItem.pei_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_PedidoItem.pei_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_PedidoItem.pei_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_PedidoItem.pei_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , notificacao_desvio.nod_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(notificacao_desvio.nod_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_tipo_notificacao_desvio":
                     case "TipoNotificacaoDesvio":
                     command.CommandText += " LEFT JOIN tipo_notificacao_desvio as tipo_notificacao_desvio_TipoNotificacaoDesvio ON tipo_notificacao_desvio_TipoNotificacaoDesvio.id_tipo_notificacao_desvio = notificacao_desvio.id_tipo_notificacao_desvio ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_notificacao_desvio_TipoNotificacaoDesvio.tnd_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_notificacao_desvio_TipoNotificacaoDesvio.tnd_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , notificacao_desvio.nod_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.nod_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_descricao_defeito":
                     case "DescricaoDefeito":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , notificacao_desvio.nod_descricao_defeito " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(notificacao_desvio.nod_descricao_defeito) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_tipo_defeito":
                     case "TipoDefeito":
                     command.CommandText += " LEFT JOIN tipo_defeito as tipo_defeito_TipoDefeito ON tipo_defeito_TipoDefeito.id_tipo_defeito = notificacao_desvio.id_tipo_defeito ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_defeito_TipoDefeito.tde_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_defeito_TipoDefeito.tde_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_posto_trabalho":
                     case "PostoTrabalho":
                     command.CommandText += " LEFT JOIN posto_trabalho as posto_trabalho_PostoTrabalho ON posto_trabalho_PostoTrabalho.id_posto_trabalho = notificacao_desvio.id_posto_trabalho ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho_PostoTrabalho.pos_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho_PostoTrabalho.pos_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_qtd_pecas_defeituosas":
                     case "QtdPecasDefeituosas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , notificacao_desvio.nod_qtd_pecas_defeituosas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.nod_qtd_pecas_defeituosas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_qtd_pecas_devolvidas":
                     case "QtdPecasDevolvidas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , notificacao_desvio.nod_qtd_pecas_devolvidas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.nod_qtd_pecas_devolvidas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_numero_nf_cliente":
                     case "NumeroNfCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , notificacao_desvio.nod_numero_nf_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(notificacao_desvio.nod_numero_nf_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_data_emissao_nf_cliente":
                     case "DataEmissaoNfCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , notificacao_desvio.nod_data_emissao_nf_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.nod_data_emissao_nf_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_valor_nf_cliente":
                     case "ValorNfCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , notificacao_desvio.nod_valor_nf_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.nod_valor_nf_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_justificativa_producao":
                     case "JustificativaProducao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , notificacao_desvio.nod_justificativa_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(notificacao_desvio.nod_justificativa_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_notificacao":
                     case "AcsUsuarioNotificacao":
                     orderByClause += " , notificacao_desvio.id_acs_usuario_notificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , notificacao_desvio.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(notificacao_desvio.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , notificacao_desvio.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_documento":
                     case "Documento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , notificacao_desvio.nod_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.nod_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_documento_nome":
                     case "DocumentoNome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , notificacao_desvio.nod_documento_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(notificacao_desvio.nod_documento_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_nf_devolucao_documento":
                     case "NfDevolucaoDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , notificacao_desvio.nod_nf_devolucao_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.nod_nf_devolucao_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_nf_devolucao_documento_nome":
                     case "NfDevolucaoDocumentoNome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , notificacao_desvio.nod_nf_devolucao_documento_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(notificacao_desvio.nod_nf_devolucao_documento_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_plano_acao_documento":
                     case "PlanoAcaoDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , notificacao_desvio.nod_plano_acao_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(notificacao_desvio.nod_plano_acao_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nod_plano_acao_documento_nome":
                     case "PlanoAcaoDocumentoNome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , notificacao_desvio.nod_plano_acao_documento_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(notificacao_desvio.nod_plano_acao_documento_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nod_numero")) 
                        {
                           whereClause += " OR UPPER(notificacao_desvio.nod_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(notificacao_desvio.nod_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nod_descricao_defeito")) 
                        {
                           whereClause += " OR UPPER(notificacao_desvio.nod_descricao_defeito) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(notificacao_desvio.nod_descricao_defeito) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nod_numero_nf_cliente")) 
                        {
                           whereClause += " OR UPPER(notificacao_desvio.nod_numero_nf_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(notificacao_desvio.nod_numero_nf_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nod_justificativa_producao")) 
                        {
                           whereClause += " OR UPPER(notificacao_desvio.nod_justificativa_producao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(notificacao_desvio.nod_justificativa_producao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(notificacao_desvio.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(notificacao_desvio.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nod_documento_nome")) 
                        {
                           whereClause += " OR UPPER(notificacao_desvio.nod_documento_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(notificacao_desvio.nod_documento_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nod_nf_devolucao_documento_nome")) 
                        {
                           whereClause += " OR UPPER(notificacao_desvio.nod_nf_devolucao_documento_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(notificacao_desvio.nod_nf_devolucao_documento_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nod_plano_acao_documento_nome")) 
                        {
                           whereClause += " OR UPPER(notificacao_desvio.nod_plano_acao_documento_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(notificacao_desvio.nod_plano_acao_documento_nome) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_notificacao_desvio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.id_notificacao_desvio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.id_notificacao_desvio = :notificacao_desvio_ID_6694 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_ID_6694", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoItem" || parametro.FieldName == "id_pedido_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PedidoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PedidoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.id_pedido_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.id_pedido_item = :notificacao_desvio_PedidoItem_1292 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_PedidoItem_1292", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "nod_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_numero LIKE :notificacao_desvio_Numero_4740 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_Numero_4740", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoNotificacaoDesvio" || parametro.FieldName == "id_tipo_notificacao_desvio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.TipoNotificacaoDesvioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.TipoNotificacaoDesvioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.id_tipo_notificacao_desvio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.id_tipo_notificacao_desvio = :notificacao_desvio_TipoNotificacaoDesvio_5963 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_TipoNotificacaoDesvio_5963", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "nod_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_data = :notificacao_desvio_Data_8002 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_Data_8002", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoDefeito" || parametro.FieldName == "nod_descricao_defeito")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_descricao_defeito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_descricao_defeito LIKE :notificacao_desvio_DescricaoDefeito_5245 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_DescricaoDefeito_5245", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDefeito" || parametro.FieldName == "id_tipo_defeito")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.TipoDefeitoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.TipoDefeitoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.id_tipo_defeito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.id_tipo_defeito = :notificacao_desvio_TipoDefeito_3159 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_TipoDefeito_3159", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalho" || parametro.FieldName == "id_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PostoTrabalhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PostoTrabalhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.id_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.id_posto_trabalho = :notificacao_desvio_PostoTrabalho_6552 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_PostoTrabalho_6552", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdPecasDefeituosas" || parametro.FieldName == "nod_qtd_pecas_defeituosas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_qtd_pecas_defeituosas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_qtd_pecas_defeituosas = :notificacao_desvio_QtdPecasDefeituosas_3595 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_QtdPecasDefeituosas_3595", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdPecasDevolvidas" || parametro.FieldName == "nod_qtd_pecas_devolvidas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_qtd_pecas_devolvidas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_qtd_pecas_devolvidas = :notificacao_desvio_QtdPecasDevolvidas_1467 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_QtdPecasDevolvidas_1467", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroNfCliente" || parametro.FieldName == "nod_numero_nf_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_numero_nf_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_numero_nf_cliente LIKE :notificacao_desvio_NumeroNfCliente_1195 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_NumeroNfCliente_1195", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEmissaoNfCliente" || parametro.FieldName == "nod_data_emissao_nf_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_data_emissao_nf_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_data_emissao_nf_cliente = :notificacao_desvio_DataEmissaoNfCliente_6169 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_DataEmissaoNfCliente_6169", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorNfCliente" || parametro.FieldName == "nod_valor_nf_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_valor_nf_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_valor_nf_cliente = :notificacao_desvio_ValorNfCliente_2919 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_ValorNfCliente_2919", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaProducao" || parametro.FieldName == "nod_justificativa_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_justificativa_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_justificativa_producao LIKE :notificacao_desvio_JustificativaProducao_2619 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_JustificativaProducao_2619", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioNotificacao" || parametro.FieldName == "id_acs_usuario_notificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.id_acs_usuario_notificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.id_acs_usuario_notificacao = :notificacao_desvio_AcsUsuarioNotificacao_193 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_AcsUsuarioNotificacao_193", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  notificacao_desvio.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.entity_uid LIKE :notificacao_desvio_EntityUid_7993 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_EntityUid_7993", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  notificacao_desvio.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.version = :notificacao_desvio_Version_550 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_Version_550", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Documento" || parametro.FieldName == "nod_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_documento = :notificacao_desvio_Documento_6366 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_Documento_6366", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoNome" || parametro.FieldName == "nod_documento_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_documento_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_documento_nome LIKE :notificacao_desvio_DocumentoNome_7861 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_DocumentoNome_7861", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfDevolucaoDocumento" || parametro.FieldName == "nod_nf_devolucao_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_nf_devolucao_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_nf_devolucao_documento = :notificacao_desvio_NfDevolucaoDocumento_9866 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_NfDevolucaoDocumento_9866", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfDevolucaoDocumentoNome" || parametro.FieldName == "nod_nf_devolucao_documento_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_nf_devolucao_documento_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_nf_devolucao_documento_nome LIKE :notificacao_desvio_NfDevolucaoDocumentoNome_4137 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_NfDevolucaoDocumentoNome_4137", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoAcaoDocumento" || parametro.FieldName == "nod_plano_acao_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_plano_acao_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_plano_acao_documento = :notificacao_desvio_PlanoAcaoDocumento_649 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_PlanoAcaoDocumento_649", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoAcaoDocumentoNome" || parametro.FieldName == "nod_plano_acao_documento_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_plano_acao_documento_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_plano_acao_documento_nome LIKE :notificacao_desvio_PlanoAcaoDocumentoNome_8031 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_PlanoAcaoDocumentoNome_8031", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroExato" || parametro.FieldName == "NumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_numero LIKE :notificacao_desvio_Numero_6509 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_Numero_6509", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoDefeitoExato" || parametro.FieldName == "DescricaoDefeitoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_descricao_defeito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_descricao_defeito LIKE :notificacao_desvio_DescricaoDefeito_7940 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_DescricaoDefeito_7940", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroNfClienteExato" || parametro.FieldName == "NumeroNfClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_numero_nf_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_numero_nf_cliente LIKE :notificacao_desvio_NumeroNfCliente_319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_NumeroNfCliente_319", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaProducaoExato" || parametro.FieldName == "JustificativaProducaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_justificativa_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_justificativa_producao LIKE :notificacao_desvio_JustificativaProducao_9172 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_JustificativaProducao_9172", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  notificacao_desvio.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.entity_uid LIKE :notificacao_desvio_EntityUid_27 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_EntityUid_27", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoNomeExato" || parametro.FieldName == "DocumentoNomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_documento_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_documento_nome LIKE :notificacao_desvio_DocumentoNome_9813 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_DocumentoNome_9813", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfDevolucaoDocumentoNomeExato" || parametro.FieldName == "NfDevolucaoDocumentoNomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_nf_devolucao_documento_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_nf_devolucao_documento_nome LIKE :notificacao_desvio_NfDevolucaoDocumentoNome_7248 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_NfDevolucaoDocumentoNome_7248", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoAcaoDocumentoNomeExato" || parametro.FieldName == "PlanoAcaoDocumentoNomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  notificacao_desvio.nod_plano_acao_documento_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  notificacao_desvio.nod_plano_acao_documento_nome LIKE :notificacao_desvio_PlanoAcaoDocumentoNome_5869 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("notificacao_desvio_PlanoAcaoDocumentoNome_5869", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NotificacaoDesvioClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NotificacaoDesvioClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NotificacaoDesvioClass), Convert.ToInt32(read["id_notificacao_desvio"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NotificacaoDesvioClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_notificacao_desvio"]);
                     if (read["id_pedido_item"] != DBNull.Value)
                     {
                        entidade.PedidoItem = (BibliotecaEntidades.Entidades.PedidoItemClass)BibliotecaEntidades.Entidades.PedidoItemClass.GetEntidade(Convert.ToInt32(read["id_pedido_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PedidoItem = null ;
                     }
                     entidade.Numero = (read["nod_numero"] != DBNull.Value ? read["nod_numero"].ToString() : null);
                     if (read["id_tipo_notificacao_desvio"] != DBNull.Value)
                     {
                        entidade.TipoNotificacaoDesvio = (BibliotecaEntidades.Entidades.TipoNotificacaoDesvioClass)BibliotecaEntidades.Entidades.TipoNotificacaoDesvioClass.GetEntidade(Convert.ToInt32(read["id_tipo_notificacao_desvio"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.TipoNotificacaoDesvio = null ;
                     }
                     entidade.Data = (DateTime)read["nod_data"];
                     entidade.DescricaoDefeito = (read["nod_descricao_defeito"] != DBNull.Value ? read["nod_descricao_defeito"].ToString() : null);
                     if (read["id_tipo_defeito"] != DBNull.Value)
                     {
                        entidade.TipoDefeito = (BibliotecaEntidades.Entidades.TipoDefeitoClass)BibliotecaEntidades.Entidades.TipoDefeitoClass.GetEntidade(Convert.ToInt32(read["id_tipo_defeito"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.TipoDefeito = null ;
                     }
                     if (read["id_posto_trabalho"] != DBNull.Value)
                     {
                        entidade.PostoTrabalho = (BibliotecaEntidades.Entidades.PostoTrabalhoClass)BibliotecaEntidades.Entidades.PostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_posto_trabalho"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PostoTrabalho = null ;
                     }
                     entidade.QtdPecasDefeituosas = (double)read["nod_qtd_pecas_defeituosas"];
                     entidade.QtdPecasDevolvidas = (double)read["nod_qtd_pecas_devolvidas"];
                     entidade.NumeroNfCliente = (read["nod_numero_nf_cliente"] != DBNull.Value ? read["nod_numero_nf_cliente"].ToString() : null);
                     entidade.DataEmissaoNfCliente = read["nod_data_emissao_nf_cliente"] as DateTime?;
                     entidade.ValorNfCliente = read["nod_valor_nf_cliente"] as double?;
                     entidade.JustificativaProducao = (read["nod_justificativa_producao"] != DBNull.Value ? read["nod_justificativa_producao"].ToString() : null);
                     if (read["id_acs_usuario_notificacao"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioNotificacao = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_notificacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioNotificacao = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.DocumentoNome = (read["nod_documento_nome"] != DBNull.Value ? read["nod_documento_nome"].ToString() : null);
                     entidade.NfDevolucaoDocumentoNome = (read["nod_nf_devolucao_documento_nome"] != DBNull.Value ? read["nod_nf_devolucao_documento_nome"].ToString() : null);
                     entidade.PlanoAcaoDocumentoNome = (read["nod_plano_acao_documento_nome"] != DBNull.Value ? read["nod_plano_acao_documento_nome"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NotificacaoDesvioClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
