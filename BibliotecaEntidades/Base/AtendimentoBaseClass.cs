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
using IWTNF.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("atendimento","ate")]
     public class AtendimentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do AtendimentoClass";
protected const string ErroDelete = "Erro ao excluir o AtendimentoClass  ";
protected const string ErroSave = "Erro ao salvar o AtendimentoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do AtendimentoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade AtendimentoClass está sendo utilizada.";
#endregion
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

       protected BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _valueOrderItemEtiqueta;
        [Column("id_order_item_etiqueta", "order_item_etiqueta", "id_order_item_etiqueta")]
       public virtual BibliotecaEntidades.Entidades.OrderItemEtiquetaClass OrderItemEtiqueta
        { 
           get {                 return this._valueOrderItemEtiqueta; } 
           set 
           { 
                if (this._valueOrderItemEtiqueta == value)return;
                 this._valueOrderItemEtiqueta = value; 
           } 
       } 

       protected double? _quantidadeOriginal{get;private set;}
       private double? _quantidadeOriginalCommited{get; set;}
        private double? _valueQuantidade;
         [Column("ate_quantidade")]
        public virtual double? Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected int _volumesOriginal{get;private set;}
       private int _volumesOriginalCommited{get; set;}
        private int _valueVolumes;
         [Column("ate_volumes")]
        public virtual int Volumes
         { 
            get { return this._valueVolumes; } 
            set 
            { 
                if (this._valueVolumes == value)return;
                 this._valueVolumes = value; 
            } 
        } 

       protected bool _atualizadoAccessOriginal{get;private set;}
       private bool _atualizadoAccessOriginalCommited{get; set;}
        private bool _valueAtualizadoAccess;
         [Column("ate_atualizado_access")]
        public virtual bool AtualizadoAccess
         { 
            get { return this._valueAtualizadoAccess; } 
            set 
            { 
                if (this._valueAtualizadoAccess == value)return;
                 this._valueAtualizadoAccess = value; 
            } 
        } 

       protected bool _geradoInvoiceOriginal{get;private set;}
       private bool _geradoInvoiceOriginalCommited{get; set;}
        private bool _valueGeradoInvoice;
         [Column("ate_gerado_invoice")]
        public virtual bool GeradoInvoice
         { 
            get { return this._valueGeradoInvoice; } 
            set 
            { 
                if (this._valueGeradoInvoice == value)return;
                 this._valueGeradoInvoice = value; 
            } 
        } 

       protected bool _atlasOriginal{get;private set;}
       private bool _atlasOriginalCommited{get; set;}
        private bool _valueAtlas;
         [Column("ate_atlas")]
        public virtual bool Atlas
         { 
            get { return this._valueAtlas; } 
            set 
            { 
                if (this._valueAtlas == value)return;
                 this._valueAtlas = value; 
            } 
        } 

       protected int? _linhaNfOriginal{get;private set;}
       private int? _linhaNfOriginalCommited{get; set;}
        private int? _valueLinhaNf;
         [Column("ate_linha_nf")]
        public virtual int? LinhaNf
         { 
            get { return this._valueLinhaNf; } 
            set 
            { 
                if (this._valueLinhaNf == value)return;
                 this._valueLinhaNf = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass _orderItemEtiquetaConferenciaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass _orderItemEtiquetaConferenciaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass _valueOrderItemEtiquetaConferencia;
        [Column("id_order_item_etiqueta_conferencia", "order_item_etiqueta_conferencia", "id_order_item_etiqueta_conferencia")]
       public virtual BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass OrderItemEtiquetaConferencia
        { 
           get {                 return this._valueOrderItemEtiquetaConferencia; } 
           set 
           { 
                if (this._valueOrderItemEtiquetaConferencia == value)return;
                 this._valueOrderItemEtiquetaConferencia = value; 
           } 
       } 

       protected string _usuarioOriginal{get;private set;}
       private string _usuarioOriginalCommited{get; set;}
        private string _valueUsuario;
         [Column("ate_usuario")]
        public virtual string Usuario
         { 
            get { return this._valueUsuario; } 
            set 
            { 
                if (this._valueUsuario == value)return;
                 this._valueUsuario = value; 
            } 
        } 

       protected DateTime? _dataHoraOriginal{get;private set;}
       private DateTime? _dataHoraOriginalCommited{get; set;}
        private DateTime? _valueDataHora;
         [Column("ate_data_hora")]
        public virtual DateTime? DataHora
         { 
            get { return this._valueDataHora; } 
            set 
            { 
                if (this._valueDataHora == value)return;
                 this._valueDataHora = value; 
            } 
        } 

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

       protected bool _comissaoGeradaOriginal{get;private set;}
       private bool _comissaoGeradaOriginalCommited{get; set;}
        private bool _valueComissaoGerada;
         [Column("ate_comissao_gerada")]
        public virtual bool ComissaoGerada
         { 
            get { return this._valueComissaoGerada; } 
            set 
            { 
                if (this._valueComissaoGerada == value)return;
                 this._valueComissaoGerada = value; 
            } 
        } 

        public AtendimentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.AtualizadoAccess = false;
           this.GeradoInvoice = false;
           this.Atlas = true;
           this.ComissaoGerada = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static AtendimentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (AtendimentoClass) GetEntity(typeof(AtendimentoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueNfPrincipal == null)
                {
                    throw new Exception(ErroNfPrincipalObrigatorio);
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
                    "  public.atendimento  " +
                    "WHERE " +
                    "  id_atendimento = :id";
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
                        "  public.atendimento   " +
                        "SET  " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  id_order_item_etiqueta = :id_order_item_etiqueta, " + 
                        "  ate_quantidade = :ate_quantidade, " + 
                        "  ate_volumes = :ate_volumes, " + 
                        "  ate_atualizado_access = :ate_atualizado_access, " + 
                        "  ate_gerado_invoice = :ate_gerado_invoice, " + 
                        "  ate_atlas = :ate_atlas, " + 
                        "  ate_linha_nf = :ate_linha_nf, " + 
                        "  id_order_item_etiqueta_conferencia = :id_order_item_etiqueta_conferencia, " + 
                        "  ate_usuario = :ate_usuario, " + 
                        "  ate_data_hora = :ate_data_hora, " + 
                        "  id_pedido_item = :id_pedido_item, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  ate_comissao_gerada = :ate_comissao_gerada "+
                        "WHERE  " +
                        "  id_atendimento = :id " +
                        "RETURNING id_atendimento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.atendimento " +
                        "( " +
                        "  id_nf_principal , " + 
                        "  id_order_item_etiqueta , " + 
                        "  ate_quantidade , " + 
                        "  ate_volumes , " + 
                        "  ate_atualizado_access , " + 
                        "  ate_gerado_invoice , " + 
                        "  ate_atlas , " + 
                        "  ate_linha_nf , " + 
                        "  id_order_item_etiqueta_conferencia , " + 
                        "  ate_usuario , " + 
                        "  ate_data_hora , " + 
                        "  id_pedido_item , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  ate_comissao_gerada  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_principal , " + 
                        "  :id_order_item_etiqueta , " + 
                        "  :ate_quantidade , " + 
                        "  :ate_volumes , " + 
                        "  :ate_atualizado_access , " + 
                        "  :ate_gerado_invoice , " + 
                        "  :ate_atlas , " + 
                        "  :ate_linha_nf , " + 
                        "  :id_order_item_etiqueta_conferencia , " + 
                        "  :ate_usuario , " + 
                        "  :ate_data_hora , " + 
                        "  :id_pedido_item , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :ate_comissao_gerada  "+
                        ")RETURNING id_atendimento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiqueta==null ? (object) DBNull.Value : this.OrderItemEtiqueta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_volumes", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Volumes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_atualizado_access", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AtualizadoAccess ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_gerado_invoice", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GeradoInvoice ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_atlas", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Atlas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_linha_nf", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LinhaNf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta_conferencia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiquetaConferencia==null ? (object) DBNull.Value : this.OrderItemEtiquetaConferencia.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_usuario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Usuario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_data_hora", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataHora ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PedidoItem==null ? (object) DBNull.Value : this.PedidoItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_comissao_gerada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ComissaoGerada ?? DBNull.Value;

 
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
        public static AtendimentoClass CopiarEntidade(AtendimentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               AtendimentoClass toRet = new AtendimentoClass(usuario,conn);
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.OrderItemEtiqueta= entidadeCopiar.OrderItemEtiqueta;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.Volumes= entidadeCopiar.Volumes;
 toRet.AtualizadoAccess= entidadeCopiar.AtualizadoAccess;
 toRet.GeradoInvoice= entidadeCopiar.GeradoInvoice;
 toRet.Atlas= entidadeCopiar.Atlas;
 toRet.LinhaNf= entidadeCopiar.LinhaNf;
 toRet.OrderItemEtiquetaConferencia= entidadeCopiar.OrderItemEtiquetaConferencia;
 toRet.Usuario= entidadeCopiar.Usuario;
 toRet.DataHora= entidadeCopiar.DataHora;
 toRet.PedidoItem= entidadeCopiar.PedidoItem;
 toRet.ComissaoGerada= entidadeCopiar.ComissaoGerada;

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
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;
       _orderItemEtiquetaOriginal = OrderItemEtiqueta;
       _orderItemEtiquetaOriginalCommited = _orderItemEtiquetaOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _volumesOriginal = Volumes;
       _volumesOriginalCommited = _volumesOriginal;
       _atualizadoAccessOriginal = AtualizadoAccess;
       _atualizadoAccessOriginalCommited = _atualizadoAccessOriginal;
       _geradoInvoiceOriginal = GeradoInvoice;
       _geradoInvoiceOriginalCommited = _geradoInvoiceOriginal;
       _atlasOriginal = Atlas;
       _atlasOriginalCommited = _atlasOriginal;
       _linhaNfOriginal = LinhaNf;
       _linhaNfOriginalCommited = _linhaNfOriginal;
       _orderItemEtiquetaConferenciaOriginal = OrderItemEtiquetaConferencia;
       _orderItemEtiquetaConferenciaOriginalCommited = _orderItemEtiquetaConferenciaOriginal;
       _usuarioOriginal = Usuario;
       _usuarioOriginalCommited = _usuarioOriginal;
       _dataHoraOriginal = DataHora;
       _dataHoraOriginalCommited = _dataHoraOriginal;
       _pedidoItemOriginal = PedidoItem;
       _pedidoItemOriginalCommited = _pedidoItemOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _comissaoGeradaOriginal = ComissaoGerada;
       _comissaoGeradaOriginalCommited = _comissaoGeradaOriginal;

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
       _nfPrincipalOriginalCommited = NfPrincipal;
       _orderItemEtiquetaOriginalCommited = OrderItemEtiqueta;
       _quantidadeOriginalCommited = Quantidade;
       _volumesOriginalCommited = Volumes;
       _atualizadoAccessOriginalCommited = AtualizadoAccess;
       _geradoInvoiceOriginalCommited = GeradoInvoice;
       _atlasOriginalCommited = Atlas;
       _linhaNfOriginalCommited = LinhaNf;
       _orderItemEtiquetaConferenciaOriginalCommited = OrderItemEtiquetaConferencia;
       _usuarioOriginalCommited = Usuario;
       _dataHoraOriginalCommited = DataHora;
       _pedidoItemOriginalCommited = PedidoItem;
       _versionOriginalCommited = Version;
       _comissaoGeradaOriginalCommited = ComissaoGerada;

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
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               OrderItemEtiqueta=_orderItemEtiquetaOriginal;
               _orderItemEtiquetaOriginalCommited=_orderItemEtiquetaOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               Volumes=_volumesOriginal;
               _volumesOriginalCommited=_volumesOriginal;
               AtualizadoAccess=_atualizadoAccessOriginal;
               _atualizadoAccessOriginalCommited=_atualizadoAccessOriginal;
               GeradoInvoice=_geradoInvoiceOriginal;
               _geradoInvoiceOriginalCommited=_geradoInvoiceOriginal;
               Atlas=_atlasOriginal;
               _atlasOriginalCommited=_atlasOriginal;
               LinhaNf=_linhaNfOriginal;
               _linhaNfOriginalCommited=_linhaNfOriginal;
               OrderItemEtiquetaConferencia=_orderItemEtiquetaConferenciaOriginal;
               _orderItemEtiquetaConferenciaOriginalCommited=_orderItemEtiquetaConferenciaOriginal;
               Usuario=_usuarioOriginal;
               _usuarioOriginalCommited=_usuarioOriginal;
               DataHora=_dataHoraOriginal;
               _dataHoraOriginalCommited=_dataHoraOriginal;
               PedidoItem=_pedidoItemOriginal;
               _pedidoItemOriginalCommited=_pedidoItemOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ComissaoGerada=_comissaoGeradaOriginal;
               _comissaoGeradaOriginalCommited=_comissaoGeradaOriginal;

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
       if (_nfPrincipalOriginal!=null)
       {
          dirty = !_nfPrincipalOriginal.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       if (_orderItemEtiquetaOriginal!=null)
       {
          dirty = !_orderItemEtiquetaOriginal.Equals(OrderItemEtiqueta);
       }
       else
       {
            dirty = OrderItemEtiqueta != null;
       }
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _volumesOriginal != Volumes;
      if (dirty) return true;
       dirty = _atualizadoAccessOriginal != AtualizadoAccess;
      if (dirty) return true;
       dirty = _geradoInvoiceOriginal != GeradoInvoice;
      if (dirty) return true;
       dirty = _atlasOriginal != Atlas;
      if (dirty) return true;
       dirty = _linhaNfOriginal != LinhaNf;
      if (dirty) return true;
       if (_orderItemEtiquetaConferenciaOriginal!=null)
       {
          dirty = !_orderItemEtiquetaConferenciaOriginal.Equals(OrderItemEtiquetaConferencia);
       }
       else
       {
            dirty = OrderItemEtiquetaConferencia != null;
       }
      if (dirty) return true;
       dirty = _usuarioOriginal != Usuario;
      if (dirty) return true;
       dirty = _dataHoraOriginal != DataHora;
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
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _comissaoGeradaOriginal != ComissaoGerada;

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
       if (_nfPrincipalOriginalCommited!=null)
       {
          dirty = !_nfPrincipalOriginalCommited.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       if (_orderItemEtiquetaOriginalCommited!=null)
       {
          dirty = !_orderItemEtiquetaOriginalCommited.Equals(OrderItemEtiqueta);
       }
       else
       {
            dirty = OrderItemEtiqueta != null;
       }
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _volumesOriginalCommited != Volumes;
      if (dirty) return true;
       dirty = _atualizadoAccessOriginalCommited != AtualizadoAccess;
      if (dirty) return true;
       dirty = _geradoInvoiceOriginalCommited != GeradoInvoice;
      if (dirty) return true;
       dirty = _atlasOriginalCommited != Atlas;
      if (dirty) return true;
       dirty = _linhaNfOriginalCommited != LinhaNf;
      if (dirty) return true;
       if (_orderItemEtiquetaConferenciaOriginalCommited!=null)
       {
          dirty = !_orderItemEtiquetaConferenciaOriginalCommited.Equals(OrderItemEtiquetaConferencia);
       }
       else
       {
            dirty = OrderItemEtiquetaConferencia != null;
       }
      if (dirty) return true;
       dirty = _usuarioOriginalCommited != Usuario;
      if (dirty) return true;
       dirty = _dataHoraOriginalCommited != DataHora;
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
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _comissaoGeradaOriginalCommited != ComissaoGerada;

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
             case "NfPrincipal":
                return this.NfPrincipal;
             case "OrderItemEtiqueta":
                return this.OrderItemEtiqueta;
             case "Quantidade":
                return this.Quantidade;
             case "Volumes":
                return this.Volumes;
             case "AtualizadoAccess":
                return this.AtualizadoAccess;
             case "GeradoInvoice":
                return this.GeradoInvoice;
             case "Atlas":
                return this.Atlas;
             case "LinhaNf":
                return this.LinhaNf;
             case "OrderItemEtiquetaConferencia":
                return this.OrderItemEtiquetaConferencia;
             case "Usuario":
                return this.Usuario;
             case "DataHora":
                return this.DataHora;
             case "PedidoItem":
                return this.PedidoItem;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ComissaoGerada":
                return this.ComissaoGerada;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfPrincipal!=null)
                NfPrincipal.ChangeSingleConnection(newConnection);
             if (OrderItemEtiqueta!=null)
                OrderItemEtiqueta.ChangeSingleConnection(newConnection);
             if (OrderItemEtiquetaConferencia!=null)
                OrderItemEtiquetaConferencia.ChangeSingleConnection(newConnection);
             if (PedidoItem!=null)
                PedidoItem.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(atendimento.id_atendimento) " ;
               }
               else
               {
               command.CommandText += "atendimento.id_atendimento, " ;
               command.CommandText += "atendimento.id_nf_principal, " ;
               command.CommandText += "atendimento.id_order_item_etiqueta, " ;
               command.CommandText += "atendimento.ate_quantidade, " ;
               command.CommandText += "atendimento.ate_volumes, " ;
               command.CommandText += "atendimento.ate_atualizado_access, " ;
               command.CommandText += "atendimento.ate_gerado_invoice, " ;
               command.CommandText += "atendimento.ate_atlas, " ;
               command.CommandText += "atendimento.ate_linha_nf, " ;
               command.CommandText += "atendimento.id_order_item_etiqueta_conferencia, " ;
               command.CommandText += "atendimento.ate_usuario, " ;
               command.CommandText += "atendimento.ate_data_hora, " ;
               command.CommandText += "atendimento.id_pedido_item, " ;
               command.CommandText += "atendimento.entity_uid, " ;
               command.CommandText += "atendimento.version, " ;
               command.CommandText += "atendimento.ate_comissao_gerada " ;
               }
               command.CommandText += " FROM  atendimento ";
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
                        orderByClause += " , ate_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ate_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = atendimento.id_acs_usuario_ultima_revisao ";
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
                     case "id_atendimento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , atendimento.id_atendimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.id_atendimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal":
                     case "NfPrincipal":
                     orderByClause += " , atendimento.id_nf_principal " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_order_item_etiqueta":
                     case "OrderItemEtiqueta":
                     command.CommandText += " LEFT JOIN order_item_etiqueta as order_item_etiqueta_OrderItemEtiqueta ON order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta = atendimento.id_order_item_etiqueta ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.oie_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.oie_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.oie_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.oie_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ate_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , atendimento.ate_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.ate_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ate_volumes":
                     case "Volumes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , atendimento.ate_volumes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.ate_volumes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ate_atualizado_access":
                     case "AtualizadoAccess":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , atendimento.ate_atualizado_access " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.ate_atualizado_access) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ate_gerado_invoice":
                     case "GeradoInvoice":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , atendimento.ate_gerado_invoice " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.ate_gerado_invoice) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ate_atlas":
                     case "Atlas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , atendimento.ate_atlas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.ate_atlas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ate_linha_nf":
                     case "LinhaNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , atendimento.ate_linha_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.ate_linha_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_order_item_etiqueta_conferencia":
                     case "OrderItemEtiquetaConferencia":
                     command.CommandText += " LEFT JOIN order_item_etiqueta_conferencia as order_item_etiqueta_conferencia_OrderItemEtiquetaConferencia ON order_item_etiqueta_conferencia_OrderItemEtiquetaConferencia.id_order_item_etiqueta_conferencia = atendimento.id_order_item_etiqueta_conferencia ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_OrderItemEtiquetaConferencia.id_order_item_etiqueta_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_OrderItemEtiquetaConferencia.id_order_item_etiqueta_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ate_usuario":
                     case "Usuario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , atendimento.ate_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(atendimento.ate_usuario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ate_data_hora":
                     case "DataHora":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , atendimento.ate_data_hora " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.ate_data_hora) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pedido_item":
                     case "PedidoItem":
                     command.CommandText += " LEFT JOIN pedido_item as pedido_item_PedidoItem ON pedido_item_PedidoItem.id_pedido_item = atendimento.id_pedido_item ";                     switch (parametro.TipoOrdenacao)
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
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , atendimento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(atendimento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , atendimento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ate_comissao_gerada":
                     case "ComissaoGerada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , atendimento.ate_comissao_gerada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(atendimento.ate_comissao_gerada) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ate_usuario")) 
                        {
                           whereClause += " OR UPPER(atendimento.ate_usuario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(atendimento.ate_usuario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(atendimento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(atendimento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_atendimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.id_atendimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.id_atendimento = :atendimento_ID_9648 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_ID_9648", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  atendimento.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.id_nf_principal = :atendimento_NfPrincipal_14 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_NfPrincipal_14", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderItemEtiqueta" || parametro.FieldName == "id_order_item_etiqueta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrderItemEtiquetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.id_order_item_etiqueta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.id_order_item_etiqueta = :atendimento_OrderItemEtiqueta_6063 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_OrderItemEtiqueta_6063", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "ate_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_quantidade = :atendimento_Quantidade_4188 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_Quantidade_4188", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Volumes" || parametro.FieldName == "ate_volumes")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_volumes = :atendimento_Volumes_7208 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_Volumes_7208", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AtualizadoAccess" || parametro.FieldName == "ate_atualizado_access")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_atualizado_access IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_atualizado_access = :atendimento_AtualizadoAccess_5894 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_AtualizadoAccess_5894", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GeradoInvoice" || parametro.FieldName == "ate_gerado_invoice")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_gerado_invoice IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_gerado_invoice = :atendimento_GeradoInvoice_8827 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_GeradoInvoice_8827", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Atlas" || parametro.FieldName == "ate_atlas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_atlas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_atlas = :atendimento_Atlas_4431 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_Atlas_4431", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LinhaNf" || parametro.FieldName == "ate_linha_nf")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_linha_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_linha_nf = :atendimento_LinhaNf_924 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_LinhaNf_924", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderItemEtiquetaConferencia" || parametro.FieldName == "id_order_item_etiqueta_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.id_order_item_etiqueta_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.id_order_item_etiqueta_conferencia = :atendimento_OrderItemEtiquetaConferencia_1926 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_OrderItemEtiquetaConferencia_1926", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Usuario" || parametro.FieldName == "ate_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_usuario LIKE :atendimento_Usuario_573 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_Usuario_573", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataHora" || parametro.FieldName == "ate_data_hora")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_data_hora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_data_hora = :atendimento_DataHora_3421 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_DataHora_3421", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  atendimento.id_pedido_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.id_pedido_item = :atendimento_PedidoItem_9722 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_PedidoItem_9722", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  atendimento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.entity_uid LIKE :atendimento_EntityUid_5604 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_EntityUid_5604", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  atendimento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.version = :atendimento_Version_5230 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_Version_5230", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ComissaoGerada" || parametro.FieldName == "ate_comissao_gerada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_comissao_gerada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_comissao_gerada = :atendimento_ComissaoGerada_5663 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_ComissaoGerada_5663", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioExato" || parametro.FieldName == "UsuarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  atendimento.ate_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.ate_usuario LIKE :atendimento_Usuario_7707 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_Usuario_7707", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  atendimento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  atendimento.entity_uid LIKE :atendimento_EntityUid_792 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("atendimento_EntityUid_792", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  AtendimentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (AtendimentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(AtendimentoClass), Convert.ToInt32(read["id_atendimento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new AtendimentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_atendimento"]);
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     if (read["id_order_item_etiqueta"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiqueta = (BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiqueta = null ;
                     }
                     entidade.Quantidade = read["ate_quantidade"] as double?;
                     entidade.Volumes = (int)read["ate_volumes"];
                     entidade.AtualizadoAccess = Convert.ToBoolean(Convert.ToInt16(read["ate_atualizado_access"]));
                     entidade.GeradoInvoice = Convert.ToBoolean(Convert.ToInt16(read["ate_gerado_invoice"]));
                     entidade.Atlas = Convert.ToBoolean(Convert.ToInt16(read["ate_atlas"]));
                     entidade.LinhaNf = read["ate_linha_nf"] as int?;
                     if (read["id_order_item_etiqueta_conferencia"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiquetaConferencia = (BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta_conferencia"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiquetaConferencia = null ;
                     }
                     entidade.Usuario = (read["ate_usuario"] != DBNull.Value ? read["ate_usuario"].ToString() : null);
                     entidade.DataHora = read["ate_data_hora"] as DateTime?;
                     if (read["id_pedido_item"] != DBNull.Value)
                     {
                        entidade.PedidoItem = (BibliotecaEntidades.Entidades.PedidoItemClass)BibliotecaEntidades.Entidades.PedidoItemClass.GetEntidade(Convert.ToInt32(read["id_pedido_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PedidoItem = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ComissaoGerada = Convert.ToBoolean(Convert.ToInt16(read["ate_comissao_gerada"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (AtendimentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
