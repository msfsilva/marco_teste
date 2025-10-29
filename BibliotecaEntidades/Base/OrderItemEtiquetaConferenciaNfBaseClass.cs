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
     [Table("order_item_etiqueta_conferencia_nf","oin")]
     public class OrderItemEtiquetaConferenciaNfBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrderItemEtiquetaConferenciaNfClass";
protected const string ErroDelete = "Erro ao excluir o OrderItemEtiquetaConferenciaNfClass  ";
protected const string ErroSave = "Erro ao salvar o OrderItemEtiquetaConferenciaNfClass.";
protected const string ErroOrderNumberObrigatorio = "O campo OrderNumber é obrigatório";
protected const string ErroOrderNumberComprimento = "O campo OrderNumber deve ter no máximo 30 caracteres";
protected const string ErroIdentificacaoEstacaoObrigatorio = "O campo IdentificacaoEstacao é obrigatório";
protected const string ErroIdentificacaoEstacaoComprimento = "O campo IdentificacaoEstacao deve ter no máximo 255 caracteres";
protected const string ErroIdentificacaoUsuarioObrigatorio = "O campo IdentificacaoUsuario é obrigatório";
protected const string ErroIdentificacaoUsuarioComprimento = "O campo IdentificacaoUsuario deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrderItemEtiquetaObrigatorio = "O campo OrderItemEtiqueta é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrderItemEtiquetaConferenciaNfClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrderItemEtiquetaConferenciaNfClass está sendo utilizada.";
#endregion
       protected string _orderNumberOriginal{get;private set;}
       private string _orderNumberOriginalCommited{get; set;}
        private string _valueOrderNumber;
         [Column("oin_order_number")]
        public virtual string OrderNumber
         { 
            get { return this._valueOrderNumber; } 
            set 
            { 
                if (this._valueOrderNumber == value)return;
                 this._valueOrderNumber = value; 
            } 
        } 

       protected int _orderPosOriginal{get;private set;}
       private int _orderPosOriginalCommited{get; set;}
        private int _valueOrderPos;
         [Column("oin_order_pos")]
        public virtual int OrderPos
         { 
            get { return this._valueOrderPos; } 
            set 
            { 
                if (this._valueOrderPos == value)return;
                 this._valueOrderPos = value; 
            } 
        } 

       protected double _quantidadeConferidaOriginal{get;private set;}
       private double _quantidadeConferidaOriginalCommited{get; set;}
        private double _valueQuantidadeConferida;
         [Column("oin_quantidade_conferida")]
        public virtual double QuantidadeConferida
         { 
            get { return this._valueQuantidadeConferida; } 
            set 
            { 
                if (this._valueQuantidadeConferida == value)return;
                 this._valueQuantidadeConferida = value; 
            } 
        } 

       protected DateTime _dataConferenciaOriginal{get;private set;}
       private DateTime _dataConferenciaOriginalCommited{get; set;}
        private DateTime _valueDataConferencia;
         [Column("oin_data_conferencia")]
        public virtual DateTime DataConferencia
         { 
            get { return this._valueDataConferencia; } 
            set 
            { 
                if (this._valueDataConferencia == value)return;
                 this._valueDataConferencia = value; 
            } 
        } 

       protected string _identificacaoEstacaoOriginal{get;private set;}
       private string _identificacaoEstacaoOriginalCommited{get; set;}
        private string _valueIdentificacaoEstacao;
         [Column("oin_identificacao_estacao")]
        public virtual string IdentificacaoEstacao
         { 
            get { return this._valueIdentificacaoEstacao; } 
            set 
            { 
                if (this._valueIdentificacaoEstacao == value)return;
                 this._valueIdentificacaoEstacao = value; 
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

       protected string _identificacaoUsuarioOriginal{get;private set;}
       private string _identificacaoUsuarioOriginalCommited{get; set;}
        private string _valueIdentificacaoUsuario;
         [Column("oin_identificacao_usuario")]
        public virtual string IdentificacaoUsuario
         { 
            get { return this._valueIdentificacaoUsuario; } 
            set 
            { 
                if (this._valueIdentificacaoUsuario == value)return;
                 this._valueIdentificacaoUsuario = value; 
            } 
        } 

       protected long? _palletSequenciaOriginal{get;private set;}
       private long? _palletSequenciaOriginalCommited{get; set;}
        private long? _valuePalletSequencia;
         [Column("oin_pallet_sequencia")]
        public virtual long? PalletSequencia
         { 
            get { return this._valuePalletSequencia; } 
            set 
            { 
                if (this._valuePalletSequencia == value)return;
                 this._valuePalletSequencia = value; 
            } 
        } 

       protected short? _palletOriginal{get;private set;}
       private short? _palletOriginalCommited{get; set;}
        private short? _valuePallet;
         [Column("oin_pallet")]
        public virtual short? Pallet
         { 
            get { return this._valuePallet; } 
            set 
            { 
                if (this._valuePallet == value)return;
                 this._valuePallet = value; 
            } 
        } 

        public OrderItemEtiquetaConferenciaNfBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static OrderItemEtiquetaConferenciaNfClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrderItemEtiquetaConferenciaNfClass) GetEntity(typeof(OrderItemEtiquetaConferenciaNfClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(OrderNumber))
                {
                    throw new Exception(ErroOrderNumberObrigatorio);
                }
                if (OrderNumber.Length >30)
                {
                    throw new Exception( ErroOrderNumberComprimento);
                }
                if (string.IsNullOrEmpty(IdentificacaoEstacao))
                {
                    throw new Exception(ErroIdentificacaoEstacaoObrigatorio);
                }
                if (IdentificacaoEstacao.Length >255)
                {
                    throw new Exception( ErroIdentificacaoEstacaoComprimento);
                }
                if (string.IsNullOrEmpty(IdentificacaoUsuario))
                {
                    throw new Exception(ErroIdentificacaoUsuarioObrigatorio);
                }
                if (IdentificacaoUsuario.Length >255)
                {
                    throw new Exception( ErroIdentificacaoUsuarioComprimento);
                }
                if ( _valueOrderItemEtiqueta == null)
                {
                    throw new Exception(ErroOrderItemEtiquetaObrigatorio);
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
                    "  public.order_item_etiqueta_conferencia_nf  " +
                    "WHERE " +
                    "  id_order_item_etiqueta_conferencia_nf = :id";
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
                        "  public.order_item_etiqueta_conferencia_nf   " +
                        "SET  " + 
                        "  oin_order_number = :oin_order_number, " + 
                        "  oin_order_pos = :oin_order_pos, " + 
                        "  oin_quantidade_conferida = :oin_quantidade_conferida, " + 
                        "  oin_data_conferencia = :oin_data_conferencia, " + 
                        "  oin_identificacao_estacao = :oin_identificacao_estacao, " + 
                        "  id_order_item_etiqueta = :id_order_item_etiqueta, " + 
                        "  oin_identificacao_usuario = :oin_identificacao_usuario, " + 
                        "  oin_pallet_sequencia = :oin_pallet_sequencia, " + 
                        "  oin_pallet = :oin_pallet, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_order_item_etiqueta_conferencia_nf = :id " +
                        "RETURNING id_order_item_etiqueta_conferencia_nf;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.order_item_etiqueta_conferencia_nf " +
                        "( " +
                        "  oin_order_number , " + 
                        "  oin_order_pos , " + 
                        "  oin_quantidade_conferida , " + 
                        "  oin_data_conferencia , " + 
                        "  oin_identificacao_estacao , " + 
                        "  id_order_item_etiqueta , " + 
                        "  oin_identificacao_usuario , " + 
                        "  oin_pallet_sequencia , " + 
                        "  oin_pallet , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :oin_order_number , " + 
                        "  :oin_order_pos , " + 
                        "  :oin_quantidade_conferida , " + 
                        "  :oin_data_conferencia , " + 
                        "  :oin_identificacao_estacao , " + 
                        "  :id_order_item_etiqueta , " + 
                        "  :oin_identificacao_usuario , " + 
                        "  :oin_pallet_sequencia , " + 
                        "  :oin_pallet , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_order_item_etiqueta_conferencia_nf;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderNumber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_order_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderPos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_quantidade_conferida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeConferida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_data_conferencia", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataConferencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_identificacao_estacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdentificacaoEstacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiqueta==null ? (object) DBNull.Value : this.OrderItemEtiqueta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_identificacao_usuario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdentificacaoUsuario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_pallet_sequencia", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PalletSequencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_pallet", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pallet ?? DBNull.Value;
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
        public static OrderItemEtiquetaConferenciaNfClass CopiarEntidade(OrderItemEtiquetaConferenciaNfClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrderItemEtiquetaConferenciaNfClass toRet = new OrderItemEtiquetaConferenciaNfClass(usuario,conn);
 toRet.OrderNumber= entidadeCopiar.OrderNumber;
 toRet.OrderPos= entidadeCopiar.OrderPos;
 toRet.QuantidadeConferida= entidadeCopiar.QuantidadeConferida;
 toRet.DataConferencia= entidadeCopiar.DataConferencia;
 toRet.IdentificacaoEstacao= entidadeCopiar.IdentificacaoEstacao;
 toRet.OrderItemEtiqueta= entidadeCopiar.OrderItemEtiqueta;
 toRet.IdentificacaoUsuario= entidadeCopiar.IdentificacaoUsuario;
 toRet.PalletSequencia= entidadeCopiar.PalletSequencia;
 toRet.Pallet= entidadeCopiar.Pallet;

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
       _orderNumberOriginal = OrderNumber;
       _orderNumberOriginalCommited = _orderNumberOriginal;
       _orderPosOriginal = OrderPos;
       _orderPosOriginalCommited = _orderPosOriginal;
       _quantidadeConferidaOriginal = QuantidadeConferida;
       _quantidadeConferidaOriginalCommited = _quantidadeConferidaOriginal;
       _dataConferenciaOriginal = DataConferencia;
       _dataConferenciaOriginalCommited = _dataConferenciaOriginal;
       _identificacaoEstacaoOriginal = IdentificacaoEstacao;
       _identificacaoEstacaoOriginalCommited = _identificacaoEstacaoOriginal;
       _orderItemEtiquetaOriginal = OrderItemEtiqueta;
       _orderItemEtiquetaOriginalCommited = _orderItemEtiquetaOriginal;
       _identificacaoUsuarioOriginal = IdentificacaoUsuario;
       _identificacaoUsuarioOriginalCommited = _identificacaoUsuarioOriginal;
       _palletSequenciaOriginal = PalletSequencia;
       _palletSequenciaOriginalCommited = _palletSequenciaOriginal;
       _palletOriginal = Pallet;
       _palletOriginalCommited = _palletOriginal;
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
       _orderNumberOriginalCommited = OrderNumber;
       _orderPosOriginalCommited = OrderPos;
       _quantidadeConferidaOriginalCommited = QuantidadeConferida;
       _dataConferenciaOriginalCommited = DataConferencia;
       _identificacaoEstacaoOriginalCommited = IdentificacaoEstacao;
       _orderItemEtiquetaOriginalCommited = OrderItemEtiqueta;
       _identificacaoUsuarioOriginalCommited = IdentificacaoUsuario;
       _palletSequenciaOriginalCommited = PalletSequencia;
       _palletOriginalCommited = Pallet;
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
               OrderNumber=_orderNumberOriginal;
               _orderNumberOriginalCommited=_orderNumberOriginal;
               OrderPos=_orderPosOriginal;
               _orderPosOriginalCommited=_orderPosOriginal;
               QuantidadeConferida=_quantidadeConferidaOriginal;
               _quantidadeConferidaOriginalCommited=_quantidadeConferidaOriginal;
               DataConferencia=_dataConferenciaOriginal;
               _dataConferenciaOriginalCommited=_dataConferenciaOriginal;
               IdentificacaoEstacao=_identificacaoEstacaoOriginal;
               _identificacaoEstacaoOriginalCommited=_identificacaoEstacaoOriginal;
               OrderItemEtiqueta=_orderItemEtiquetaOriginal;
               _orderItemEtiquetaOriginalCommited=_orderItemEtiquetaOriginal;
               IdentificacaoUsuario=_identificacaoUsuarioOriginal;
               _identificacaoUsuarioOriginalCommited=_identificacaoUsuarioOriginal;
               PalletSequencia=_palletSequenciaOriginal;
               _palletSequenciaOriginalCommited=_palletSequenciaOriginal;
               Pallet=_palletOriginal;
               _palletOriginalCommited=_palletOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;

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
       dirty = _orderNumberOriginal != OrderNumber;
      if (dirty) return true;
       dirty = _orderPosOriginal != OrderPos;
      if (dirty) return true;
       dirty = _quantidadeConferidaOriginal != QuantidadeConferida;
      if (dirty) return true;
       dirty = _dataConferenciaOriginal != DataConferencia;
      if (dirty) return true;
       dirty = _identificacaoEstacaoOriginal != IdentificacaoEstacao;
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
       dirty = _identificacaoUsuarioOriginal != IdentificacaoUsuario;
      if (dirty) return true;
       dirty = _palletSequenciaOriginal != PalletSequencia;
      if (dirty) return true;
       dirty = _palletOriginal != Pallet;
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
       dirty = _orderNumberOriginalCommited != OrderNumber;
      if (dirty) return true;
       dirty = _orderPosOriginalCommited != OrderPos;
      if (dirty) return true;
       dirty = _quantidadeConferidaOriginalCommited != QuantidadeConferida;
      if (dirty) return true;
       dirty = _dataConferenciaOriginalCommited != DataConferencia;
      if (dirty) return true;
       dirty = _identificacaoEstacaoOriginalCommited != IdentificacaoEstacao;
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
       dirty = _identificacaoUsuarioOriginalCommited != IdentificacaoUsuario;
      if (dirty) return true;
       dirty = _palletSequenciaOriginalCommited != PalletSequencia;
      if (dirty) return true;
       dirty = _palletOriginalCommited != Pallet;
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
             case "OrderNumber":
                return this.OrderNumber;
             case "OrderPos":
                return this.OrderPos;
             case "QuantidadeConferida":
                return this.QuantidadeConferida;
             case "DataConferencia":
                return this.DataConferencia;
             case "IdentificacaoEstacao":
                return this.IdentificacaoEstacao;
             case "OrderItemEtiqueta":
                return this.OrderItemEtiqueta;
             case "IdentificacaoUsuario":
                return this.IdentificacaoUsuario;
             case "PalletSequencia":
                return this.PalletSequencia;
             case "Pallet":
                return this.Pallet;
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
             if (OrderItemEtiqueta!=null)
                OrderItemEtiqueta.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(order_item_etiqueta_conferencia_nf.id_order_item_etiqueta_conferencia_nf) " ;
               }
               else
               {
               command.CommandText += "order_item_etiqueta_conferencia_nf.id_order_item_etiqueta_conferencia_nf, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.oin_order_number, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.oin_order_pos, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.oin_quantidade_conferida, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.oin_data_conferencia, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.oin_identificacao_estacao, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.id_order_item_etiqueta, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.oin_identificacao_usuario, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.oin_pallet_sequencia, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.oin_pallet, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.entity_uid, " ;
               command.CommandText += "order_item_etiqueta_conferencia_nf.version " ;
               }
               command.CommandText += " FROM  order_item_etiqueta_conferencia_nf ";
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
                        orderByClause += " , oin_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(oin_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = order_item_etiqueta_conferencia_nf.id_acs_usuario_ultima_revisao ";
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
                     case "id_order_item_etiqueta_conferencia_nf":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.id_order_item_etiqueta_conferencia_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.id_order_item_etiqueta_conferencia_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oin_order_number":
                     case "OrderNumber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.oin_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.oin_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oin_order_pos":
                     case "OrderPos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.oin_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.oin_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oin_quantidade_conferida":
                     case "QuantidadeConferida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.oin_quantidade_conferida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.oin_quantidade_conferida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oin_data_conferencia":
                     case "DataConferencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.oin_data_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.oin_data_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oin_identificacao_estacao":
                     case "IdentificacaoEstacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.oin_identificacao_estacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.oin_identificacao_estacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_order_item_etiqueta":
                     case "OrderItemEtiqueta":
                     command.CommandText += " LEFT JOIN order_item_etiqueta as order_item_etiqueta_OrderItemEtiqueta ON order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta = order_item_etiqueta_conferencia_nf.id_order_item_etiqueta ";                     switch (parametro.TipoOrdenacao)
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
                     case "oin_identificacao_usuario":
                     case "IdentificacaoUsuario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.oin_identificacao_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.oin_identificacao_usuario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oin_pallet_sequencia":
                     case "PalletSequencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.oin_pallet_sequencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.oin_pallet_sequencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oin_pallet":
                     case "Pallet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.oin_pallet " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.oin_pallet) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia_nf.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item_etiqueta_conferencia_nf.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_nf.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oin_order_number")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia_nf.oin_order_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia_nf.oin_order_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oin_identificacao_estacao")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia_nf.oin_identificacao_estacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia_nf.oin_identificacao_estacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oin_identificacao_usuario")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia_nf.oin_identificacao_usuario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia_nf.oin_identificacao_usuario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia_nf.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia_nf.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_order_item_etiqueta_conferencia_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.id_order_item_etiqueta_conferencia_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.id_order_item_etiqueta_conferencia_nf = :order_item_etiqueta_conferencia_nf_ID_7119 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_ID_7119", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumber" || parametro.FieldName == "oin_order_number")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_order_number LIKE :order_item_etiqueta_conferencia_nf_OrderNumber_6089 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_OrderNumber_6089", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderPos" || parametro.FieldName == "oin_order_pos")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_order_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_order_pos = :order_item_etiqueta_conferencia_nf_OrderPos_2030 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_OrderPos_2030", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeConferida" || parametro.FieldName == "oin_quantidade_conferida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_quantidade_conferida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_quantidade_conferida = :order_item_etiqueta_conferencia_nf_QuantidadeConferida_6931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_QuantidadeConferida_6931", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataConferencia" || parametro.FieldName == "oin_data_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_data_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_data_conferencia = :order_item_etiqueta_conferencia_nf_DataConferencia_6313 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_DataConferencia_6313", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoEstacao" || parametro.FieldName == "oin_identificacao_estacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_identificacao_estacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_identificacao_estacao LIKE :order_item_etiqueta_conferencia_nf_IdentificacaoEstacao_671 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_IdentificacaoEstacao_671", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item_etiqueta_conferencia_nf.id_order_item_etiqueta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.id_order_item_etiqueta = :order_item_etiqueta_conferencia_nf_OrderItemEtiqueta_1128 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_OrderItemEtiqueta_1128", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoUsuario" || parametro.FieldName == "oin_identificacao_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_identificacao_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_identificacao_usuario LIKE :order_item_etiqueta_conferencia_nf_IdentificacaoUsuario_1018 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_IdentificacaoUsuario_1018", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PalletSequencia" || parametro.FieldName == "oin_pallet_sequencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_pallet_sequencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_pallet_sequencia = :order_item_etiqueta_conferencia_nf_PalletSequencia_2278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_PalletSequencia_2278", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pallet" || parametro.FieldName == "oin_pallet")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_pallet IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_pallet = :order_item_etiqueta_conferencia_nf_Pallet_1305 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_Pallet_1305", NpgsqlDbType.Smallint, parametro.Fieldvalue));
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
                         whereClause += "  order_item_etiqueta_conferencia_nf.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.entity_uid LIKE :order_item_etiqueta_conferencia_nf_EntityUid_2791 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_EntityUid_2791", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item_etiqueta_conferencia_nf.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.version = :order_item_etiqueta_conferencia_nf_Version_8308 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_Version_8308", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumberExato" || parametro.FieldName == "OrderNumberExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_order_number LIKE :order_item_etiqueta_conferencia_nf_OrderNumber_9896 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_OrderNumber_9896", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoEstacaoExato" || parametro.FieldName == "IdentificacaoEstacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_identificacao_estacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_identificacao_estacao LIKE :order_item_etiqueta_conferencia_nf_IdentificacaoEstacao_2200 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_IdentificacaoEstacao_2200", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoUsuarioExato" || parametro.FieldName == "IdentificacaoUsuarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_identificacao_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.oin_identificacao_usuario LIKE :order_item_etiqueta_conferencia_nf_IdentificacaoUsuario_534 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_IdentificacaoUsuario_534", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  order_item_etiqueta_conferencia_nf.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_nf.entity_uid LIKE :order_item_etiqueta_conferencia_nf_EntityUid_520 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_nf_EntityUid_520", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrderItemEtiquetaConferenciaNfClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrderItemEtiquetaConferenciaNfClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrderItemEtiquetaConferenciaNfClass), Convert.ToInt32(read["id_order_item_etiqueta_conferencia_nf"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrderItemEtiquetaConferenciaNfClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_order_item_etiqueta_conferencia_nf"]);
                     entidade.OrderNumber = (read["oin_order_number"] != DBNull.Value ? read["oin_order_number"].ToString() : null);
                     entidade.OrderPos = (int)read["oin_order_pos"];
                     entidade.QuantidadeConferida = (double)read["oin_quantidade_conferida"];
                     entidade.DataConferencia = (DateTime)read["oin_data_conferencia"];
                     entidade.IdentificacaoEstacao = (read["oin_identificacao_estacao"] != DBNull.Value ? read["oin_identificacao_estacao"].ToString() : null);
                     if (read["id_order_item_etiqueta"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiqueta = (BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiqueta = null ;
                     }
                     entidade.IdentificacaoUsuario = (read["oin_identificacao_usuario"] != DBNull.Value ? read["oin_identificacao_usuario"].ToString() : null);
                     entidade.PalletSequencia = (read["oin_pallet_sequencia"] != DBNull.Value ? (long?)Convert.ToInt64(read["oin_pallet_sequencia"]) : null);
                     entidade.Pallet = read["oin_pallet"] as short?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrderItemEtiquetaConferenciaNfClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
