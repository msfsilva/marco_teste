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
     [Table("historico_carteira","ord")]
     public class HistoricoCarteiraBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do HistoricoCarteiraClass";
protected const string ErroDelete = "Erro ao excluir o HistoricoCarteiraClass  ";
protected const string ErroSave = "Erro ao salvar o HistoricoCarteiraClass.";
protected const string ErroOrderNumberObrigatorio = "O campo OrderNumber é obrigatório";
protected const string ErroOrderNumberComprimento = "O campo OrderNumber deve ter no máximo 30 caracteres";
protected const string ErroBuyerItemCodeObrigatorio = "O campo BuyerItemCode é obrigatório";
protected const string ErroBuyerItemCodeComprimento = "O campo BuyerItemCode deve ter no máximo 50 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do HistoricoCarteiraClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade HistoricoCarteiraClass está sendo utilizada.";
#endregion
       protected string _orderNumberOriginal{get;private set;}
       private string _orderNumberOriginalCommited{get; set;}
        private string _valueOrderNumber;
         [Column("order_number")]
        public virtual string OrderNumber
         { 
            get { return this._valueOrderNumber; } 
            set 
            { 
                if (this._valueOrderNumber == value)return;
                 this._valueOrderNumber = value; 
            } 
        } 

       protected short _orderPosOriginal{get;private set;}
       private short _orderPosOriginalCommited{get; set;}
        private short _valueOrderPos;
         [Column("order_pos")]
        public virtual short OrderPos
         { 
            get { return this._valueOrderPos; } 
            set 
            { 
                if (this._valueOrderPos == value)return;
                 this._valueOrderPos = value; 
            } 
        } 

       protected string _buyerItemCodeOriginal{get;private set;}
       private string _buyerItemCodeOriginalCommited{get; set;}
        private string _valueBuyerItemCode;
         [Column("buyer_item_code")]
        public virtual string BuyerItemCode
         { 
            get { return this._valueBuyerItemCode; } 
            set 
            { 
                if (this._valueBuyerItemCode == value)return;
                 this._valueBuyerItemCode = value; 
            } 
        } 

       protected DateTime? _deliveryDateOriginal{get;private set;}
       private DateTime? _deliveryDateOriginalCommited{get; set;}
        private DateTime? _valueDeliveryDate;
         [Column("delivery_date")]
        public virtual DateTime? DeliveryDate
         { 
            get { return this._valueDeliveryDate; } 
            set 
            { 
                if (this._valueDeliveryDate == value)return;
                 this._valueDeliveryDate = value; 
            } 
        } 

       protected double? _itemQtyOriginal{get;private set;}
       private double? _itemQtyOriginalCommited{get; set;}
        private double? _valueItemQty;
         [Column("item_qty")]
        public virtual double? ItemQty
         { 
            get { return this._valueItemQty; } 
            set 
            { 
                if (this._valueItemQty == value)return;
                 this._valueItemQty = value; 
            } 
        } 

       protected double? _pricePerUnitOriginal{get;private set;}
       private double? _pricePerUnitOriginalCommited{get; set;}
        private double? _valuePricePerUnit;
         [Column("price_per_unit")]
        public virtual double? PricePerUnit
         { 
            get { return this._valuePricePerUnit; } 
            set 
            { 
                if (this._valuePricePerUnit == value)return;
                 this._valuePricePerUnit = value; 
            } 
        } 

       protected double? _icmsOriginal{get;private set;}
       private double? _icmsOriginalCommited{get; set;}
        private double? _valueIcms;
         [Column("icms")]
        public virtual double? Icms
         { 
            get { return this._valueIcms; } 
            set 
            { 
                if (this._valueIcms == value)return;
                 this._valueIcms = value; 
            } 
        } 

       protected int? _actionCodeOriginal{get;private set;}
       private int? _actionCodeOriginalCommited{get; set;}
        private int? _valueActionCode;
         [Column("action_code")]
        public virtual int? ActionCode
         { 
            get { return this._valueActionCode; } 
            set 
            { 
                if (this._valueActionCode == value)return;
                 this._valueActionCode = value; 
            } 
        } 

       protected int? _confirmationStatusOriginal{get;private set;}
       private int? _confirmationStatusOriginalCommited{get; set;}
        private int? _valueConfirmationStatus;
         [Column("confirmation_status")]
        public virtual int? ConfirmationStatus
         { 
            get { return this._valueConfirmationStatus; } 
            set 
            { 
                if (this._valueConfirmationStatus == value)return;
                 this._valueConfirmationStatus = value; 
            } 
        } 

       protected int? _evolutionStatusOriginal{get;private set;}
       private int? _evolutionStatusOriginalCommited{get; set;}
        private int? _valueEvolutionStatus;
         [Column("evolution_status")]
        public virtual int? EvolutionStatus
         { 
            get { return this._valueEvolutionStatus; } 
            set 
            { 
                if (this._valueEvolutionStatus == value)return;
                 this._valueEvolutionStatus = value; 
            } 
        } 

        public HistoricoCarteiraBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static HistoricoCarteiraClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (HistoricoCarteiraClass) GetEntity(typeof(HistoricoCarteiraClass),id,usuarioAtual,connection, operacao);
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
                if (string.IsNullOrEmpty(BuyerItemCode))
                {
                    throw new Exception(ErroBuyerItemCodeObrigatorio);
                }
                if (BuyerItemCode.Length >50)
                {
                    throw new Exception( ErroBuyerItemCodeComprimento);
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
                    "  public.historico_carteira  " +
                    "WHERE " +
                    "  id_historico_carteira = :id";
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
                        "  public.historico_carteira   " +
                        "SET  " + 
                        "  order_number = :order_number, " + 
                        "  order_pos = :order_pos, " + 
                        "  buyer_item_code = :buyer_item_code, " + 
                        "  delivery_date = :delivery_date, " + 
                        "  item_qty = :item_qty, " + 
                        "  price_per_unit = :price_per_unit, " + 
                        "  icms = :icms, " + 
                        "  action_code = :action_code, " + 
                        "  confirmation_status = :confirmation_status, " + 
                        "  evolution_status = :evolution_status, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_historico_carteira = :id " +
                        "RETURNING id_historico_carteira;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.historico_carteira " +
                        "( " +
                        "  order_number , " + 
                        "  order_pos , " + 
                        "  buyer_item_code , " + 
                        "  delivery_date , " + 
                        "  item_qty , " + 
                        "  price_per_unit , " + 
                        "  icms , " + 
                        "  action_code , " + 
                        "  confirmation_status , " + 
                        "  evolution_status , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :order_number , " + 
                        "  :order_pos , " + 
                        "  :buyer_item_code , " + 
                        "  :delivery_date , " + 
                        "  :item_qty , " + 
                        "  :price_per_unit , " + 
                        "  :icms , " + 
                        "  :action_code , " + 
                        "  :confirmation_status , " + 
                        "  :evolution_status , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_historico_carteira;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderNumber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_pos", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderPos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buyer_item_code", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerItemCode ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("delivery_date", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DeliveryDate ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("item_qty", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ItemQty ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("price_per_unit", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PricePerUnit ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("icms", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Icms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("action_code", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ActionCode ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("confirmation_status", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConfirmationStatus ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("evolution_status", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EvolutionStatus ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;

 
                 this.ID = Convert.ToInt32(command.ExecuteScalar()); 
                this.InternalSaveCustom(ref command); 
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
        public static HistoricoCarteiraClass CopiarEntidade(HistoricoCarteiraClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               HistoricoCarteiraClass toRet = new HistoricoCarteiraClass(usuario,conn);
 toRet.OrderNumber= entidadeCopiar.OrderNumber;
 toRet.OrderPos= entidadeCopiar.OrderPos;
 toRet.BuyerItemCode= entidadeCopiar.BuyerItemCode;
 toRet.DeliveryDate= entidadeCopiar.DeliveryDate;
 toRet.ItemQty= entidadeCopiar.ItemQty;
 toRet.PricePerUnit= entidadeCopiar.PricePerUnit;
 toRet.Icms= entidadeCopiar.Icms;
 toRet.ActionCode= entidadeCopiar.ActionCode;
 toRet.ConfirmationStatus= entidadeCopiar.ConfirmationStatus;
 toRet.EvolutionStatus= entidadeCopiar.EvolutionStatus;

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
       _buyerItemCodeOriginal = BuyerItemCode;
       _buyerItemCodeOriginalCommited = _buyerItemCodeOriginal;
       _deliveryDateOriginal = DeliveryDate;
       _deliveryDateOriginalCommited = _deliveryDateOriginal;
       _itemQtyOriginal = ItemQty;
       _itemQtyOriginalCommited = _itemQtyOriginal;
       _pricePerUnitOriginal = PricePerUnit;
       _pricePerUnitOriginalCommited = _pricePerUnitOriginal;
       _icmsOriginal = Icms;
       _icmsOriginalCommited = _icmsOriginal;
       _actionCodeOriginal = ActionCode;
       _actionCodeOriginalCommited = _actionCodeOriginal;
       _confirmationStatusOriginal = ConfirmationStatus;
       _confirmationStatusOriginalCommited = _confirmationStatusOriginal;
       _evolutionStatusOriginal = EvolutionStatus;
       _evolutionStatusOriginalCommited = _evolutionStatusOriginal;
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
       _buyerItemCodeOriginalCommited = BuyerItemCode;
       _deliveryDateOriginalCommited = DeliveryDate;
       _itemQtyOriginalCommited = ItemQty;
       _pricePerUnitOriginalCommited = PricePerUnit;
       _icmsOriginalCommited = Icms;
       _actionCodeOriginalCommited = ActionCode;
       _confirmationStatusOriginalCommited = ConfirmationStatus;
       _evolutionStatusOriginalCommited = EvolutionStatus;
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
               BuyerItemCode=_buyerItemCodeOriginal;
               _buyerItemCodeOriginalCommited=_buyerItemCodeOriginal;
               DeliveryDate=_deliveryDateOriginal;
               _deliveryDateOriginalCommited=_deliveryDateOriginal;
               ItemQty=_itemQtyOriginal;
               _itemQtyOriginalCommited=_itemQtyOriginal;
               PricePerUnit=_pricePerUnitOriginal;
               _pricePerUnitOriginalCommited=_pricePerUnitOriginal;
               Icms=_icmsOriginal;
               _icmsOriginalCommited=_icmsOriginal;
               ActionCode=_actionCodeOriginal;
               _actionCodeOriginalCommited=_actionCodeOriginal;
               ConfirmationStatus=_confirmationStatusOriginal;
               _confirmationStatusOriginalCommited=_confirmationStatusOriginal;
               EvolutionStatus=_evolutionStatusOriginal;
               _evolutionStatusOriginalCommited=_evolutionStatusOriginal;
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
       dirty = _buyerItemCodeOriginal != BuyerItemCode;
      if (dirty) return true;
       dirty = _deliveryDateOriginal != DeliveryDate;
      if (dirty) return true;
       dirty = _itemQtyOriginal != ItemQty;
      if (dirty) return true;
       dirty = _pricePerUnitOriginal != PricePerUnit;
      if (dirty) return true;
       dirty = _icmsOriginal != Icms;
      if (dirty) return true;
       dirty = _actionCodeOriginal != ActionCode;
      if (dirty) return true;
       dirty = _confirmationStatusOriginal != ConfirmationStatus;
      if (dirty) return true;
       dirty = _evolutionStatusOriginal != EvolutionStatus;
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
       dirty = _buyerItemCodeOriginalCommited != BuyerItemCode;
      if (dirty) return true;
       dirty = _deliveryDateOriginalCommited != DeliveryDate;
      if (dirty) return true;
       dirty = _itemQtyOriginalCommited != ItemQty;
      if (dirty) return true;
       dirty = _pricePerUnitOriginalCommited != PricePerUnit;
      if (dirty) return true;
       dirty = _icmsOriginalCommited != Icms;
      if (dirty) return true;
       dirty = _actionCodeOriginalCommited != ActionCode;
      if (dirty) return true;
       dirty = _confirmationStatusOriginalCommited != ConfirmationStatus;
      if (dirty) return true;
       dirty = _evolutionStatusOriginalCommited != EvolutionStatus;
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
             case "BuyerItemCode":
                return this.BuyerItemCode;
             case "DeliveryDate":
                return this.DeliveryDate;
             case "ItemQty":
                return this.ItemQty;
             case "PricePerUnit":
                return this.PricePerUnit;
             case "Icms":
                return this.Icms;
             case "ActionCode":
                return this.ActionCode;
             case "ConfirmationStatus":
                return this.ConfirmationStatus;
             case "EvolutionStatus":
                return this.EvolutionStatus;
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
                  command.CommandText += " COUNT(historico_carteira.id_historico_carteira) " ;
               }
               else
               {
               command.CommandText += "historico_carteira.order_number, " ;
               command.CommandText += "historico_carteira.order_pos, " ;
               command.CommandText += "historico_carteira.buyer_item_code, " ;
               command.CommandText += "historico_carteira.delivery_date, " ;
               command.CommandText += "historico_carteira.item_qty, " ;
               command.CommandText += "historico_carteira.price_per_unit, " ;
               command.CommandText += "historico_carteira.icms, " ;
               command.CommandText += "historico_carteira.action_code, " ;
               command.CommandText += "historico_carteira.confirmation_status, " ;
               command.CommandText += "historico_carteira.evolution_status, " ;
               command.CommandText += "historico_carteira.entity_uid, " ;
               command.CommandText += "historico_carteira.version " ;
               }
               command.CommandText += " FROM  historico_carteira ";
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
                        orderByClause += " , ord_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ord_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = historico_carteira.id_acs_usuario_ultima_revisao ";
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
                     case "order_number":
                     case "OrderNumber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , historico_carteira.order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(historico_carteira.order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "order_pos":
                     case "OrderPos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_carteira.order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_carteira.order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buyer_item_code":
                     case "BuyerItemCode":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , historico_carteira.buyer_item_code " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(historico_carteira.buyer_item_code) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "delivery_date":
                     case "DeliveryDate":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_carteira.delivery_date " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_carteira.delivery_date) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "item_qty":
                     case "ItemQty":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_carteira.item_qty " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_carteira.item_qty) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "price_per_unit":
                     case "PricePerUnit":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_carteira.price_per_unit " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_carteira.price_per_unit) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "icms":
                     case "Icms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_carteira.icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_carteira.icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "action_code":
                     case "ActionCode":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_carteira.action_code " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_carteira.action_code) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "confirmation_status":
                     case "ConfirmationStatus":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_carteira.confirmation_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_carteira.confirmation_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "evolution_status":
                     case "EvolutionStatus":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_carteira.evolution_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_carteira.evolution_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , historico_carteira.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(historico_carteira.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , historico_carteira.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_carteira.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("order_number")) 
                        {
                           whereClause += " OR UPPER(historico_carteira.order_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(historico_carteira.order_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buyer_item_code")) 
                        {
                           whereClause += " OR UPPER(historico_carteira.buyer_item_code) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(historico_carteira.buyer_item_code) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(historico_carteira.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(historico_carteira.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumber" || parametro.FieldName == "order_number")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.order_number LIKE :historico_carteira_OrderNumber_1650 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_OrderNumber_1650", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderPos" || parametro.FieldName == "order_pos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.order_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.order_pos = :historico_carteira_OrderPos_7935 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_OrderPos_7935", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemCode" || parametro.FieldName == "buyer_item_code")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.buyer_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.buyer_item_code LIKE :historico_carteira_BuyerItemCode_2929 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_BuyerItemCode_2929", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DeliveryDate" || parametro.FieldName == "delivery_date")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.delivery_date IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.delivery_date = :historico_carteira_DeliveryDate_9955 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_DeliveryDate_9955", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ItemQty" || parametro.FieldName == "item_qty")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.item_qty IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.item_qty = :historico_carteira_ItemQty_5177 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_ItemQty_5177", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PricePerUnit" || parametro.FieldName == "price_per_unit")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.price_per_unit IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.price_per_unit = :historico_carteira_PricePerUnit_2550 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_PricePerUnit_2550", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Icms" || parametro.FieldName == "icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.icms = :historico_carteira_Icms_6314 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_Icms_6314", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ActionCode" || parametro.FieldName == "action_code")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.action_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.action_code = :historico_carteira_ActionCode_1651 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_ActionCode_1651", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConfirmationStatus" || parametro.FieldName == "confirmation_status")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.confirmation_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.confirmation_status = :historico_carteira_ConfirmationStatus_680 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_ConfirmationStatus_680", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EvolutionStatus" || parametro.FieldName == "evolution_status")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.evolution_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.evolution_status = :historico_carteira_EvolutionStatus_1243 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_EvolutionStatus_1243", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  historico_carteira.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.entity_uid LIKE :historico_carteira_EntityUid_5174 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_EntityUid_5174", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  historico_carteira.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.version = :historico_carteira_Version_2841 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_Version_2841", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  historico_carteira.order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.order_number LIKE :historico_carteira_OrderNumber_8072 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_OrderNumber_8072", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemCodeExato" || parametro.FieldName == "BuyerItemCodeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_carteira.buyer_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.buyer_item_code LIKE :historico_carteira_BuyerItemCode_2350 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_BuyerItemCode_2350", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  historico_carteira.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_carteira.entity_uid LIKE :historico_carteira_EntityUid_5655 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_carteira_EntityUid_5655", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  HistoricoCarteiraClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (HistoricoCarteiraClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(HistoricoCarteiraClass), Convert.ToInt32(read["id_historico_carteira"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new HistoricoCarteiraClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.OrderNumber = (read["order_number"] != DBNull.Value ? read["order_number"].ToString() : null);
                     entidade.OrderPos = (short)read["order_pos"];
                     entidade.BuyerItemCode = (read["buyer_item_code"] != DBNull.Value ? read["buyer_item_code"].ToString() : null);
                     entidade.DeliveryDate = read["delivery_date"] as DateTime?;
                     entidade.ItemQty = read["item_qty"] as double?;
                     entidade.PricePerUnit = read["price_per_unit"] as double?;
                     entidade.Icms = read["icms"] as double?;
                     entidade.ActionCode = read["action_code"] as int?;
                     entidade.ConfirmationStatus = read["confirmation_status"] as int?;
                     entidade.EvolutionStatus = read["evolution_status"] as int?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (HistoricoCarteiraClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
