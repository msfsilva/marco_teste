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
     [Table("order_item","ite")]
     public class OrderItemBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrderItemClass";
protected const string ErroDelete = "Erro ao excluir o OrderItemClass  ";
protected const string ErroSave = "Erro ao salvar o OrderItemClass.";
protected const string ErroOrderNumberObrigatorio = "O campo OrderNumber é obrigatório";
protected const string ErroOrderNumberComprimento = "O campo OrderNumber deve ter no máximo 30 caracteres";
protected const string ErroBuyerItemCodeObrigatorio = "O campo BuyerItemCode é obrigatório";
protected const string ErroBuyerItemCodeComprimento = "O campo BuyerItemCode deve ter no máximo 50 caracteres";
protected const string ErroStatusObrigatorio = "O campo Status é obrigatório";
protected const string ErroStatusComprimento = "O campo Status deve ter no máximo 10 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do OrderItemClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrderItemClass está sendo utilizada.";
#endregion
       protected int _itemIdOriginal{get;private set;}
       private int _itemIdOriginalCommited{get; set;}
        private int _valueItemId;
         [Column("item_id")]
        public virtual int ItemId
         { 
            get { return this._valueItemId; } 
            set 
            { 
                if (this._valueItemId == value)return;
                 this._valueItemId = value; 
            } 
        } 

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

       protected string _orderNumber2Original{get;private set;}
       private string _orderNumber2OriginalCommited{get; set;}
        private string _valueOrderNumber2;
         [Column("buy_order_number")]
        public virtual string OrderNumber2
         { 
            get { return this._valueOrderNumber2; } 
            set 
            { 
                if (this._valueOrderNumber2 == value)return;
                 this._valueOrderNumber2 = value; 
            } 
        } 

       protected int? _buyerIdOriginal{get;private set;}
       private int? _buyerIdOriginalCommited{get; set;}
        private int? _valueBuyerId;
         [Column("buyer_id")]
        public virtual int? BuyerId
         { 
            get { return this._valueBuyerId; } 
            set 
            { 
                if (this._valueBuyerId == value)return;
                 this._valueBuyerId = value; 
            } 
        } 

       protected int? _supplyerIdOriginal{get;private set;}
       private int? _supplyerIdOriginalCommited{get; set;}
        private int? _valueSupplyerId;
         [Column("supplyer_id")]
        public virtual int? SupplyerId
         { 
            get { return this._valueSupplyerId; } 
            set 
            { 
                if (this._valueSupplyerId == value)return;
                 this._valueSupplyerId = value; 
            } 
        } 

       protected int? _buyerPlantIdOriginal{get;private set;}
       private int? _buyerPlantIdOriginalCommited{get; set;}
        private int? _valueBuyerPlantId;
         [Column("buyer_plant_id")]
        public virtual int? BuyerPlantId
         { 
            get { return this._valueBuyerPlantId; } 
            set 
            { 
                if (this._valueBuyerPlantId == value)return;
                 this._valueBuyerPlantId = value; 
            } 
        } 

       protected string _currencyOriginal{get;private set;}
       private string _currencyOriginalCommited{get; set;}
        private string _valueCurrency;
         [Column("currency")]
        public virtual string Currency
         { 
            get { return this._valueCurrency; } 
            set 
            { 
                if (this._valueCurrency == value)return;
                 this._valueCurrency = value; 
            } 
        } 

       protected DateTime? _orderDateOriginal{get;private set;}
       private DateTime? _orderDateOriginalCommited{get; set;}
        private DateTime? _valueOrderDate;
         [Column("order_date")]
        public virtual DateTime? OrderDate
         { 
            get { return this._valueOrderDate; } 
            set 
            { 
                if (this._valueOrderDate == value)return;
                 this._valueOrderDate = value; 
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

       protected short _engineeringLevelOriginal{get;private set;}
       private short _engineeringLevelOriginalCommited{get; set;}
        private short _valueEngineeringLevel;
         [Column("engineering_level")]
        public virtual short EngineeringLevel
         { 
            get { return this._valueEngineeringLevel; } 
            set 
            { 
                if (this._valueEngineeringLevel == value)return;
                 this._valueEngineeringLevel = value; 
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

       protected string _supplierItemCodeOriginal{get;private set;}
       private string _supplierItemCodeOriginalCommited{get; set;}
        private string _valueSupplierItemCode;
         [Column("supplier_item_code")]
        public virtual string SupplierItemCode
         { 
            get { return this._valueSupplierItemCode; } 
            set 
            { 
                if (this._valueSupplierItemCode == value)return;
                 this._valueSupplierItemCode = value; 
            } 
        } 

       protected string _buyerItemDescriptionOriginal{get;private set;}
       private string _buyerItemDescriptionOriginalCommited{get; set;}
        private string _valueBuyerItemDescription;
         [Column("buyer_item_description")]
        public virtual string BuyerItemDescription
         { 
            get { return this._valueBuyerItemDescription; } 
            set 
            { 
                if (this._valueBuyerItemDescription == value)return;
                 this._valueBuyerItemDescription = value; 
            } 
        } 

       protected string _supplierItemDescriptionOriginal{get;private set;}
       private string _supplierItemDescriptionOriginalCommited{get; set;}
        private string _valueSupplierItemDescription;
         [Column("supplier_item_description")]
        public virtual string SupplierItemDescription
         { 
            get { return this._valueSupplierItemDescription; } 
            set 
            { 
                if (this._valueSupplierItemDescription == value)return;
                 this._valueSupplierItemDescription = value; 
            } 
        } 

       protected double _itemQtyOriginal{get;private set;}
       private double _itemQtyOriginalCommited{get; set;}
        private double _valueItemQty;
         [Column("item_qty")]
        public virtual double ItemQty
         { 
            get { return this._valueItemQty; } 
            set 
            { 
                if (this._valueItemQty == value)return;
                 this._valueItemQty = value; 
            } 
        } 

       protected string _unitOfMeasureOriginal{get;private set;}
       private string _unitOfMeasureOriginalCommited{get; set;}
        private string _valueUnitOfMeasure;
         [Column("unit_of_measure")]
        public virtual string UnitOfMeasure
         { 
            get { return this._valueUnitOfMeasure; } 
            set 
            { 
                if (this._valueUnitOfMeasure == value)return;
                 this._valueUnitOfMeasure = value; 
            } 
        } 

       protected double? _priceUnitOriginal{get;private set;}
       private double? _priceUnitOriginalCommited{get; set;}
        private double? _valuePriceUnit;
         [Column("price_unit")]
        public virtual double? PriceUnit
         { 
            get { return this._valuePriceUnit; } 
            set 
            { 
                if (this._valuePriceUnit == value)return;
                 this._valuePriceUnit = value; 
            } 
        } 

       protected string _documentNumberOriginal{get;private set;}
       private string _documentNumberOriginalCommited{get; set;}
        private string _valueDocumentNumber;
         [Column("document_number")]
        public virtual string DocumentNumber
         { 
            get { return this._valueDocumentNumber; } 
            set 
            { 
                if (this._valueDocumentNumber == value)return;
                 this._valueDocumentNumber = value; 
            } 
        } 

       protected string _documentRevisionOriginal{get;private set;}
       private string _documentRevisionOriginalCommited{get; set;}
        private string _valueDocumentRevision;
         [Column("document_revision")]
        public virtual string DocumentRevision
         { 
            get { return this._valueDocumentRevision; } 
            set 
            { 
                if (this._valueDocumentRevision == value)return;
                 this._valueDocumentRevision = value; 
            } 
        } 

       protected string _buyerDepartamentOriginal{get;private set;}
       private string _buyerDepartamentOriginalCommited{get; set;}
        private string _valueBuyerDepartament;
         [Column("buyer_departament")]
        public virtual string BuyerDepartament
         { 
            get { return this._valueBuyerDepartament; } 
            set 
            { 
                if (this._valueBuyerDepartament == value)return;
                 this._valueBuyerDepartament = value; 
            } 
        } 

       protected string _statusOriginal{get;private set;}
       private string _statusOriginalCommited{get; set;}
        private string _valueStatus;
         [Column("status")]
        public virtual string Status
         { 
            get { return this._valueStatus; } 
            set 
            { 
                if (this._valueStatus == value)return;
                 this._valueStatus = value; 
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

       protected short? _exportedOriginal{get;private set;}
       private short? _exportedOriginalCommited{get; set;}
        private short? _valueExported;
         [Column("exported")]
        public virtual short? Exported
         { 
            get { return this._valueExported; } 
            set 
            { 
                if (this._valueExported == value)return;
                 this._valueExported = value; 
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

       protected string _evolutionStatusOriginal{get;private set;}
       private string _evolutionStatusOriginalCommited{get; set;}
        private string _valueEvolutionStatus;
         [Column("evolution_status")]
        public virtual string EvolutionStatus
         { 
            get { return this._valueEvolutionStatus; } 
            set 
            { 
                if (this._valueEvolutionStatus == value)return;
                 this._valueEvolutionStatus = value; 
            } 
        } 

       protected string _changedStatusOriginal{get;private set;}
       private string _changedStatusOriginalCommited{get; set;}
        private string _valueChangedStatus;
         [Column("changed_status")]
        public virtual string ChangedStatus
         { 
            get { return this._valueChangedStatus; } 
            set 
            { 
                if (this._valueChangedStatus == value)return;
                 this._valueChangedStatus = value; 
            } 
        } 

       protected double? _saldoOriginal{get;private set;}
       private double? _saldoOriginalCommited{get; set;}
        private double? _valueSaldo;
         [Column("saldo")]
        public virtual double? Saldo
         { 
            get { return this._valueSaldo; } 
            set 
            { 
                if (this._valueSaldo == value)return;
                 this._valueSaldo = value; 
            } 
        } 

       protected string _classificacaoContabilOriginal{get;private set;}
       private string _classificacaoContabilOriginalCommited{get; set;}
        private string _valueClassificacaoContabil;
         [Column("classificacao_contabil")]
        public virtual string ClassificacaoContabil
         { 
            get { return this._valueClassificacaoContabil; } 
            set 
            { 
                if (this._valueClassificacaoContabil == value)return;
                 this._valueClassificacaoContabil = value; 
            } 
        } 

       protected string _depsOriginal{get;private set;}
       private string _depsOriginalCommited{get; set;}
        private string _valueDeps;
         [Column("deps")]
        public virtual string Deps
         { 
            get { return this._valueDeps; } 
            set 
            { 
                if (this._valueDeps == value)return;
                 this._valueDeps = value; 
            } 
        } 

       protected string _pepsOriginal{get;private set;}
       private string _pepsOriginalCommited{get; set;}
        private string _valuePeps;
         [Column("peps")]
        public virtual string Peps
         { 
            get { return this._valuePeps; } 
            set 
            { 
                if (this._valuePeps == value)return;
                 this._valuePeps = value; 
            } 
        } 

       protected string _ovmOriginal{get;private set;}
       private string _ovmOriginalCommited{get; set;}
        private string _valueOvm;
         [Column("ovm")]
        public virtual string Ovm
         { 
            get { return this._valueOvm; } 
            set 
            { 
                if (this._valueOvm == value)return;
                 this._valueOvm = value; 
            } 
        } 

        public OrderItemBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ChangedStatus = "0";
           this.Saldo = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrderItemClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrderItemClass) GetEntity(typeof(OrderItemClass),id,usuarioAtual,connection, operacao);
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
                if (string.IsNullOrEmpty(Status))
                {
                    throw new Exception(ErroStatusObrigatorio);
                }
                if (Status.Length >10)
                {
                    throw new Exception( ErroStatusComprimento);
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
                    "  public.order_item  " +
                    "WHERE " +
                    "  id_order_item = :id";
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
                        "  public.order_item   " +
                        "SET  " + 
                        "  item_id = :item_id, " + 
                        "  order_number = :order_number, " + 
                        "  order_pos = :order_pos, " + 
                        "  buy_order_number = :buy_order_number, " + 
                        "  buyer_id = :buyer_id, " + 
                        "  supplyer_id = :supplyer_id, " + 
                        "  buyer_plant_id = :buyer_plant_id, " + 
                        "  currency = :currency, " + 
                        "  order_date = :order_date, " + 
                        "  delivery_date = :delivery_date, " + 
                        "  engineering_level = :engineering_level, " + 
                        "  buyer_item_code = :buyer_item_code, " + 
                        "  supplier_item_code = :supplier_item_code, " + 
                        "  buyer_item_description = :buyer_item_description, " + 
                        "  supplier_item_description = :supplier_item_description, " + 
                        "  item_qty = :item_qty, " + 
                        "  unit_of_measure = :unit_of_measure, " + 
                        "  price_unit = :price_unit, " + 
                        "  document_number = :document_number, " + 
                        "  document_revision = :document_revision, " + 
                        "  buyer_departament = :buyer_departament, " + 
                        "  status = :status, " + 
                        "  price_per_unit = :price_per_unit, " + 
                        "  exported = :exported, " + 
                        "  icms = :icms, " + 
                        "  evolution_status = :evolution_status, " + 
                        "  changed_status = :changed_status, " + 
                        "  saldo = :saldo, " + 
                        "  classificacao_contabil = :classificacao_contabil, " + 
                        "  deps = :deps, " + 
                        "  peps = :peps, " + 
                        "  ovm = :ovm, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_order_item = :id " +
                        "RETURNING id_order_item;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.order_item " +
                        "( " +
                        "  item_id , " + 
                        "  order_number , " + 
                        "  order_pos , " + 
                        "  buy_order_number , " + 
                        "  buyer_id , " + 
                        "  supplyer_id , " + 
                        "  buyer_plant_id , " + 
                        "  currency , " + 
                        "  order_date , " + 
                        "  delivery_date , " + 
                        "  engineering_level , " + 
                        "  buyer_item_code , " + 
                        "  supplier_item_code , " + 
                        "  buyer_item_description , " + 
                        "  supplier_item_description , " + 
                        "  item_qty , " + 
                        "  unit_of_measure , " + 
                        "  price_unit , " + 
                        "  document_number , " + 
                        "  document_revision , " + 
                        "  buyer_departament , " + 
                        "  status , " + 
                        "  price_per_unit , " + 
                        "  exported , " + 
                        "  icms , " + 
                        "  evolution_status , " + 
                        "  changed_status , " + 
                        "  saldo , " + 
                        "  classificacao_contabil , " + 
                        "  deps , " + 
                        "  peps , " + 
                        "  ovm , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :item_id , " + 
                        "  :order_number , " + 
                        "  :order_pos , " + 
                        "  :buy_order_number , " + 
                        "  :buyer_id , " + 
                        "  :supplyer_id , " + 
                        "  :buyer_plant_id , " + 
                        "  :currency , " + 
                        "  :order_date , " + 
                        "  :delivery_date , " + 
                        "  :engineering_level , " + 
                        "  :buyer_item_code , " + 
                        "  :supplier_item_code , " + 
                        "  :buyer_item_description , " + 
                        "  :supplier_item_description , " + 
                        "  :item_qty , " + 
                        "  :unit_of_measure , " + 
                        "  :price_unit , " + 
                        "  :document_number , " + 
                        "  :document_revision , " + 
                        "  :buyer_departament , " + 
                        "  :status , " + 
                        "  :price_per_unit , " + 
                        "  :exported , " + 
                        "  :icms , " + 
                        "  :evolution_status , " + 
                        "  :changed_status , " + 
                        "  :saldo , " + 
                        "  :classificacao_contabil , " + 
                        "  :deps , " + 
                        "  :peps , " + 
                        "  :ovm , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_order_item;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("item_id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ItemId ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderNumber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_pos", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderPos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buy_order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderNumber2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buyer_id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerId ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("supplyer_id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SupplyerId ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buyer_plant_id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerPlantId ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("currency", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Currency ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_date", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderDate ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("delivery_date", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DeliveryDate ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("engineering_level", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EngineeringLevel ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buyer_item_code", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerItemCode ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("supplier_item_code", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SupplierItemCode ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buyer_item_description", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerItemDescription ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("supplier_item_description", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SupplierItemDescription ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("item_qty", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ItemQty ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("unit_of_measure", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UnitOfMeasure ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("price_unit", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PriceUnit ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("document_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentNumber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("document_revision", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DocumentRevision ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buyer_departament", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerDepartament ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("status", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Status ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("price_per_unit", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PricePerUnit ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("exported", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Exported ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("icms", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Icms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("evolution_status", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EvolutionStatus ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("changed_status", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ChangedStatus ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("saldo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Saldo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_contabil", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ClassificacaoContabil ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("deps", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Deps ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peps", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Peps ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ovm", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ovm ?? DBNull.Value;
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
        public static OrderItemClass CopiarEntidade(OrderItemClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrderItemClass toRet = new OrderItemClass(usuario,conn);
 toRet.ItemId= entidadeCopiar.ItemId;
 toRet.OrderNumber= entidadeCopiar.OrderNumber;
 toRet.OrderPos= entidadeCopiar.OrderPos;
 toRet.OrderNumber2= entidadeCopiar.OrderNumber2;
 toRet.BuyerId= entidadeCopiar.BuyerId;
 toRet.SupplyerId= entidadeCopiar.SupplyerId;
 toRet.BuyerPlantId= entidadeCopiar.BuyerPlantId;
 toRet.Currency= entidadeCopiar.Currency;
 toRet.OrderDate= entidadeCopiar.OrderDate;
 toRet.DeliveryDate= entidadeCopiar.DeliveryDate;
 toRet.EngineeringLevel= entidadeCopiar.EngineeringLevel;
 toRet.BuyerItemCode= entidadeCopiar.BuyerItemCode;
 toRet.SupplierItemCode= entidadeCopiar.SupplierItemCode;
 toRet.BuyerItemDescription= entidadeCopiar.BuyerItemDescription;
 toRet.SupplierItemDescription= entidadeCopiar.SupplierItemDescription;
 toRet.ItemQty= entidadeCopiar.ItemQty;
 toRet.UnitOfMeasure= entidadeCopiar.UnitOfMeasure;
 toRet.PriceUnit= entidadeCopiar.PriceUnit;
 toRet.DocumentNumber= entidadeCopiar.DocumentNumber;
 toRet.DocumentRevision= entidadeCopiar.DocumentRevision;
 toRet.BuyerDepartament= entidadeCopiar.BuyerDepartament;
 toRet.Status= entidadeCopiar.Status;
 toRet.PricePerUnit= entidadeCopiar.PricePerUnit;
 toRet.Exported= entidadeCopiar.Exported;
 toRet.Icms= entidadeCopiar.Icms;
 toRet.EvolutionStatus= entidadeCopiar.EvolutionStatus;
 toRet.ChangedStatus= entidadeCopiar.ChangedStatus;
 toRet.Saldo= entidadeCopiar.Saldo;
 toRet.ClassificacaoContabil= entidadeCopiar.ClassificacaoContabil;
 toRet.Deps= entidadeCopiar.Deps;
 toRet.Peps= entidadeCopiar.Peps;
 toRet.Ovm= entidadeCopiar.Ovm;

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
       _itemIdOriginal = ItemId;
       _itemIdOriginalCommited = _itemIdOriginal;
       _orderNumberOriginal = OrderNumber;
       _orderNumberOriginalCommited = _orderNumberOriginal;
       _orderPosOriginal = OrderPos;
       _orderPosOriginalCommited = _orderPosOriginal;
       _orderNumber2Original = OrderNumber2;
       _orderNumber2OriginalCommited = _orderNumber2Original;
       _buyerIdOriginal = BuyerId;
       _buyerIdOriginalCommited = _buyerIdOriginal;
       _supplyerIdOriginal = SupplyerId;
       _supplyerIdOriginalCommited = _supplyerIdOriginal;
       _buyerPlantIdOriginal = BuyerPlantId;
       _buyerPlantIdOriginalCommited = _buyerPlantIdOriginal;
       _currencyOriginal = Currency;
       _currencyOriginalCommited = _currencyOriginal;
       _orderDateOriginal = OrderDate;
       _orderDateOriginalCommited = _orderDateOriginal;
       _deliveryDateOriginal = DeliveryDate;
       _deliveryDateOriginalCommited = _deliveryDateOriginal;
       _engineeringLevelOriginal = EngineeringLevel;
       _engineeringLevelOriginalCommited = _engineeringLevelOriginal;
       _buyerItemCodeOriginal = BuyerItemCode;
       _buyerItemCodeOriginalCommited = _buyerItemCodeOriginal;
       _supplierItemCodeOriginal = SupplierItemCode;
       _supplierItemCodeOriginalCommited = _supplierItemCodeOriginal;
       _buyerItemDescriptionOriginal = BuyerItemDescription;
       _buyerItemDescriptionOriginalCommited = _buyerItemDescriptionOriginal;
       _supplierItemDescriptionOriginal = SupplierItemDescription;
       _supplierItemDescriptionOriginalCommited = _supplierItemDescriptionOriginal;
       _itemQtyOriginal = ItemQty;
       _itemQtyOriginalCommited = _itemQtyOriginal;
       _unitOfMeasureOriginal = UnitOfMeasure;
       _unitOfMeasureOriginalCommited = _unitOfMeasureOriginal;
       _priceUnitOriginal = PriceUnit;
       _priceUnitOriginalCommited = _priceUnitOriginal;
       _documentNumberOriginal = DocumentNumber;
       _documentNumberOriginalCommited = _documentNumberOriginal;
       _documentRevisionOriginal = DocumentRevision;
       _documentRevisionOriginalCommited = _documentRevisionOriginal;
       _buyerDepartamentOriginal = BuyerDepartament;
       _buyerDepartamentOriginalCommited = _buyerDepartamentOriginal;
       _statusOriginal = Status;
       _statusOriginalCommited = _statusOriginal;
       _pricePerUnitOriginal = PricePerUnit;
       _pricePerUnitOriginalCommited = _pricePerUnitOriginal;
       _exportedOriginal = Exported;
       _exportedOriginalCommited = _exportedOriginal;
       _icmsOriginal = Icms;
       _icmsOriginalCommited = _icmsOriginal;
       _evolutionStatusOriginal = EvolutionStatus;
       _evolutionStatusOriginalCommited = _evolutionStatusOriginal;
       _changedStatusOriginal = ChangedStatus;
       _changedStatusOriginalCommited = _changedStatusOriginal;
       _saldoOriginal = Saldo;
       _saldoOriginalCommited = _saldoOriginal;
       _classificacaoContabilOriginal = ClassificacaoContabil;
       _classificacaoContabilOriginalCommited = _classificacaoContabilOriginal;
       _depsOriginal = Deps;
       _depsOriginalCommited = _depsOriginal;
       _pepsOriginal = Peps;
       _pepsOriginalCommited = _pepsOriginal;
       _ovmOriginal = Ovm;
       _ovmOriginalCommited = _ovmOriginal;
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
       _itemIdOriginalCommited = ItemId;
       _orderNumberOriginalCommited = OrderNumber;
       _orderPosOriginalCommited = OrderPos;
       _orderNumber2OriginalCommited = OrderNumber2;
       _buyerIdOriginalCommited = BuyerId;
       _supplyerIdOriginalCommited = SupplyerId;
       _buyerPlantIdOriginalCommited = BuyerPlantId;
       _currencyOriginalCommited = Currency;
       _orderDateOriginalCommited = OrderDate;
       _deliveryDateOriginalCommited = DeliveryDate;
       _engineeringLevelOriginalCommited = EngineeringLevel;
       _buyerItemCodeOriginalCommited = BuyerItemCode;
       _supplierItemCodeOriginalCommited = SupplierItemCode;
       _buyerItemDescriptionOriginalCommited = BuyerItemDescription;
       _supplierItemDescriptionOriginalCommited = SupplierItemDescription;
       _itemQtyOriginalCommited = ItemQty;
       _unitOfMeasureOriginalCommited = UnitOfMeasure;
       _priceUnitOriginalCommited = PriceUnit;
       _documentNumberOriginalCommited = DocumentNumber;
       _documentRevisionOriginalCommited = DocumentRevision;
       _buyerDepartamentOriginalCommited = BuyerDepartament;
       _statusOriginalCommited = Status;
       _pricePerUnitOriginalCommited = PricePerUnit;
       _exportedOriginalCommited = Exported;
       _icmsOriginalCommited = Icms;
       _evolutionStatusOriginalCommited = EvolutionStatus;
       _changedStatusOriginalCommited = ChangedStatus;
       _saldoOriginalCommited = Saldo;
       _classificacaoContabilOriginalCommited = ClassificacaoContabil;
       _depsOriginalCommited = Deps;
       _pepsOriginalCommited = Peps;
       _ovmOriginalCommited = Ovm;
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
               ItemId=_itemIdOriginal;
               _itemIdOriginalCommited=_itemIdOriginal;
               OrderNumber=_orderNumberOriginal;
               _orderNumberOriginalCommited=_orderNumberOriginal;
               OrderPos=_orderPosOriginal;
               _orderPosOriginalCommited=_orderPosOriginal;
               OrderNumber2=_orderNumber2Original;
               _orderNumber2OriginalCommited=_orderNumber2Original;
               BuyerId=_buyerIdOriginal;
               _buyerIdOriginalCommited=_buyerIdOriginal;
               SupplyerId=_supplyerIdOriginal;
               _supplyerIdOriginalCommited=_supplyerIdOriginal;
               BuyerPlantId=_buyerPlantIdOriginal;
               _buyerPlantIdOriginalCommited=_buyerPlantIdOriginal;
               Currency=_currencyOriginal;
               _currencyOriginalCommited=_currencyOriginal;
               OrderDate=_orderDateOriginal;
               _orderDateOriginalCommited=_orderDateOriginal;
               DeliveryDate=_deliveryDateOriginal;
               _deliveryDateOriginalCommited=_deliveryDateOriginal;
               EngineeringLevel=_engineeringLevelOriginal;
               _engineeringLevelOriginalCommited=_engineeringLevelOriginal;
               BuyerItemCode=_buyerItemCodeOriginal;
               _buyerItemCodeOriginalCommited=_buyerItemCodeOriginal;
               SupplierItemCode=_supplierItemCodeOriginal;
               _supplierItemCodeOriginalCommited=_supplierItemCodeOriginal;
               BuyerItemDescription=_buyerItemDescriptionOriginal;
               _buyerItemDescriptionOriginalCommited=_buyerItemDescriptionOriginal;
               SupplierItemDescription=_supplierItemDescriptionOriginal;
               _supplierItemDescriptionOriginalCommited=_supplierItemDescriptionOriginal;
               ItemQty=_itemQtyOriginal;
               _itemQtyOriginalCommited=_itemQtyOriginal;
               UnitOfMeasure=_unitOfMeasureOriginal;
               _unitOfMeasureOriginalCommited=_unitOfMeasureOriginal;
               PriceUnit=_priceUnitOriginal;
               _priceUnitOriginalCommited=_priceUnitOriginal;
               DocumentNumber=_documentNumberOriginal;
               _documentNumberOriginalCommited=_documentNumberOriginal;
               DocumentRevision=_documentRevisionOriginal;
               _documentRevisionOriginalCommited=_documentRevisionOriginal;
               BuyerDepartament=_buyerDepartamentOriginal;
               _buyerDepartamentOriginalCommited=_buyerDepartamentOriginal;
               Status=_statusOriginal;
               _statusOriginalCommited=_statusOriginal;
               PricePerUnit=_pricePerUnitOriginal;
               _pricePerUnitOriginalCommited=_pricePerUnitOriginal;
               Exported=_exportedOriginal;
               _exportedOriginalCommited=_exportedOriginal;
               Icms=_icmsOriginal;
               _icmsOriginalCommited=_icmsOriginal;
               EvolutionStatus=_evolutionStatusOriginal;
               _evolutionStatusOriginalCommited=_evolutionStatusOriginal;
               ChangedStatus=_changedStatusOriginal;
               _changedStatusOriginalCommited=_changedStatusOriginal;
               Saldo=_saldoOriginal;
               _saldoOriginalCommited=_saldoOriginal;
               ClassificacaoContabil=_classificacaoContabilOriginal;
               _classificacaoContabilOriginalCommited=_classificacaoContabilOriginal;
               Deps=_depsOriginal;
               _depsOriginalCommited=_depsOriginal;
               Peps=_pepsOriginal;
               _pepsOriginalCommited=_pepsOriginal;
               Ovm=_ovmOriginal;
               _ovmOriginalCommited=_ovmOriginal;
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
       dirty = _itemIdOriginal != ItemId;
      if (dirty) return true;
       dirty = _orderNumberOriginal != OrderNumber;
      if (dirty) return true;
       dirty = _orderPosOriginal != OrderPos;
      if (dirty) return true;
       dirty = _orderNumber2Original != OrderNumber2;
      if (dirty) return true;
       dirty = _buyerIdOriginal != BuyerId;
      if (dirty) return true;
       dirty = _supplyerIdOriginal != SupplyerId;
      if (dirty) return true;
       dirty = _buyerPlantIdOriginal != BuyerPlantId;
      if (dirty) return true;
       dirty = _currencyOriginal != Currency;
      if (dirty) return true;
       dirty = _orderDateOriginal != OrderDate;
      if (dirty) return true;
       dirty = _deliveryDateOriginal != DeliveryDate;
      if (dirty) return true;
       dirty = _engineeringLevelOriginal != EngineeringLevel;
      if (dirty) return true;
       dirty = _buyerItemCodeOriginal != BuyerItemCode;
      if (dirty) return true;
       dirty = _supplierItemCodeOriginal != SupplierItemCode;
      if (dirty) return true;
       dirty = _buyerItemDescriptionOriginal != BuyerItemDescription;
      if (dirty) return true;
       dirty = _supplierItemDescriptionOriginal != SupplierItemDescription;
      if (dirty) return true;
       dirty = _itemQtyOriginal != ItemQty;
      if (dirty) return true;
       dirty = _unitOfMeasureOriginal != UnitOfMeasure;
      if (dirty) return true;
       dirty = _priceUnitOriginal != PriceUnit;
      if (dirty) return true;
       dirty = _documentNumberOriginal != DocumentNumber;
      if (dirty) return true;
       dirty = _documentRevisionOriginal != DocumentRevision;
      if (dirty) return true;
       dirty = _buyerDepartamentOriginal != BuyerDepartament;
      if (dirty) return true;
       dirty = _statusOriginal != Status;
      if (dirty) return true;
       dirty = _pricePerUnitOriginal != PricePerUnit;
      if (dirty) return true;
       dirty = _exportedOriginal != Exported;
      if (dirty) return true;
       dirty = _icmsOriginal != Icms;
      if (dirty) return true;
       dirty = _evolutionStatusOriginal != EvolutionStatus;
      if (dirty) return true;
       dirty = _changedStatusOriginal != ChangedStatus;
      if (dirty) return true;
       dirty = _saldoOriginal != Saldo;
      if (dirty) return true;
       dirty = _classificacaoContabilOriginal != ClassificacaoContabil;
      if (dirty) return true;
       dirty = _depsOriginal != Deps;
      if (dirty) return true;
       dirty = _pepsOriginal != Peps;
      if (dirty) return true;
       dirty = _ovmOriginal != Ovm;
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
       dirty = _itemIdOriginalCommited != ItemId;
      if (dirty) return true;
       dirty = _orderNumberOriginalCommited != OrderNumber;
      if (dirty) return true;
       dirty = _orderPosOriginalCommited != OrderPos;
      if (dirty) return true;
       dirty = _orderNumber2OriginalCommited != OrderNumber2;
      if (dirty) return true;
       dirty = _buyerIdOriginalCommited != BuyerId;
      if (dirty) return true;
       dirty = _supplyerIdOriginalCommited != SupplyerId;
      if (dirty) return true;
       dirty = _buyerPlantIdOriginalCommited != BuyerPlantId;
      if (dirty) return true;
       dirty = _currencyOriginalCommited != Currency;
      if (dirty) return true;
       dirty = _orderDateOriginalCommited != OrderDate;
      if (dirty) return true;
       dirty = _deliveryDateOriginalCommited != DeliveryDate;
      if (dirty) return true;
       dirty = _engineeringLevelOriginalCommited != EngineeringLevel;
      if (dirty) return true;
       dirty = _buyerItemCodeOriginalCommited != BuyerItemCode;
      if (dirty) return true;
       dirty = _supplierItemCodeOriginalCommited != SupplierItemCode;
      if (dirty) return true;
       dirty = _buyerItemDescriptionOriginalCommited != BuyerItemDescription;
      if (dirty) return true;
       dirty = _supplierItemDescriptionOriginalCommited != SupplierItemDescription;
      if (dirty) return true;
       dirty = _itemQtyOriginalCommited != ItemQty;
      if (dirty) return true;
       dirty = _unitOfMeasureOriginalCommited != UnitOfMeasure;
      if (dirty) return true;
       dirty = _priceUnitOriginalCommited != PriceUnit;
      if (dirty) return true;
       dirty = _documentNumberOriginalCommited != DocumentNumber;
      if (dirty) return true;
       dirty = _documentRevisionOriginalCommited != DocumentRevision;
      if (dirty) return true;
       dirty = _buyerDepartamentOriginalCommited != BuyerDepartament;
      if (dirty) return true;
       dirty = _statusOriginalCommited != Status;
      if (dirty) return true;
       dirty = _pricePerUnitOriginalCommited != PricePerUnit;
      if (dirty) return true;
       dirty = _exportedOriginalCommited != Exported;
      if (dirty) return true;
       dirty = _icmsOriginalCommited != Icms;
      if (dirty) return true;
       dirty = _evolutionStatusOriginalCommited != EvolutionStatus;
      if (dirty) return true;
       dirty = _changedStatusOriginalCommited != ChangedStatus;
      if (dirty) return true;
       dirty = _saldoOriginalCommited != Saldo;
      if (dirty) return true;
       dirty = _classificacaoContabilOriginalCommited != ClassificacaoContabil;
      if (dirty) return true;
       dirty = _depsOriginalCommited != Deps;
      if (dirty) return true;
       dirty = _pepsOriginalCommited != Peps;
      if (dirty) return true;
       dirty = _ovmOriginalCommited != Ovm;
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
             case "ItemId":
                return this.ItemId;
             case "OrderNumber":
                return this.OrderNumber;
             case "OrderPos":
                return this.OrderPos;
             case "OrderNumber2":
                return this.OrderNumber2;
             case "BuyerId":
                return this.BuyerId;
             case "SupplyerId":
                return this.SupplyerId;
             case "BuyerPlantId":
                return this.BuyerPlantId;
             case "Currency":
                return this.Currency;
             case "OrderDate":
                return this.OrderDate;
             case "DeliveryDate":
                return this.DeliveryDate;
             case "EngineeringLevel":
                return this.EngineeringLevel;
             case "BuyerItemCode":
                return this.BuyerItemCode;
             case "SupplierItemCode":
                return this.SupplierItemCode;
             case "BuyerItemDescription":
                return this.BuyerItemDescription;
             case "SupplierItemDescription":
                return this.SupplierItemDescription;
             case "ItemQty":
                return this.ItemQty;
             case "UnitOfMeasure":
                return this.UnitOfMeasure;
             case "PriceUnit":
                return this.PriceUnit;
             case "DocumentNumber":
                return this.DocumentNumber;
             case "DocumentRevision":
                return this.DocumentRevision;
             case "BuyerDepartament":
                return this.BuyerDepartament;
             case "Status":
                return this.Status;
             case "PricePerUnit":
                return this.PricePerUnit;
             case "Exported":
                return this.Exported;
             case "Icms":
                return this.Icms;
             case "EvolutionStatus":
                return this.EvolutionStatus;
             case "ChangedStatus":
                return this.ChangedStatus;
             case "Saldo":
                return this.Saldo;
             case "ClassificacaoContabil":
                return this.ClassificacaoContabil;
             case "Deps":
                return this.Deps;
             case "Peps":
                return this.Peps;
             case "Ovm":
                return this.Ovm;
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
                  command.CommandText += " COUNT(order_item.id_order_item) " ;
               }
               else
               {
               command.CommandText += "order_item.item_id, " ;
               command.CommandText += "order_item.order_number, " ;
               command.CommandText += "order_item.order_pos, " ;
               command.CommandText += "order_item.buy_order_number, " ;
               command.CommandText += "order_item.buyer_id, " ;
               command.CommandText += "order_item.supplyer_id, " ;
               command.CommandText += "order_item.buyer_plant_id, " ;
               command.CommandText += "order_item.currency, " ;
               command.CommandText += "order_item.order_date, " ;
               command.CommandText += "order_item.delivery_date, " ;
               command.CommandText += "order_item.engineering_level, " ;
               command.CommandText += "order_item.buyer_item_code, " ;
               command.CommandText += "order_item.supplier_item_code, " ;
               command.CommandText += "order_item.buyer_item_description, " ;
               command.CommandText += "order_item.supplier_item_description, " ;
               command.CommandText += "order_item.item_qty, " ;
               command.CommandText += "order_item.unit_of_measure, " ;
               command.CommandText += "order_item.price_unit, " ;
               command.CommandText += "order_item.document_number, " ;
               command.CommandText += "order_item.document_revision, " ;
               command.CommandText += "order_item.buyer_departament, " ;
               command.CommandText += "order_item.status, " ;
               command.CommandText += "order_item.price_per_unit, " ;
               command.CommandText += "order_item.exported, " ;
               command.CommandText += "order_item.icms, " ;
               command.CommandText += "order_item.evolution_status, " ;
               command.CommandText += "order_item.changed_status, " ;
               command.CommandText += "order_item.saldo, " ;
               command.CommandText += "order_item.classificacao_contabil, " ;
               command.CommandText += "order_item.deps, " ;
               command.CommandText += "order_item.peps, " ;
               command.CommandText += "order_item.ovm, " ;
               command.CommandText += "order_item.entity_uid, " ;
               command.CommandText += "order_item.version " ;
               }
               command.CommandText += " FROM  order_item ";
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
                        orderByClause += " , ite_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ite_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = order_item.id_acs_usuario_ultima_revisao ";
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
                     case "item_id":
                     case "ItemId":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item.item_id " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.item_id) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "order_number":
                     case "OrderNumber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item.order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buy_order_number":
                     case "OrderNumber2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.buy_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.buy_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buyer_id":
                     case "BuyerId":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item.buyer_id " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.buyer_id) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "supplyer_id":
                     case "SupplyerId":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item.supplyer_id " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.supplyer_id) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buyer_plant_id":
                     case "BuyerPlantId":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item.buyer_plant_id " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.buyer_plant_id) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "currency":
                     case "Currency":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.currency " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.currency) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "order_date":
                     case "OrderDate":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item.order_date " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.order_date) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item.delivery_date " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.delivery_date) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "engineering_level":
                     case "EngineeringLevel":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item.engineering_level " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.engineering_level) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buyer_item_code":
                     case "BuyerItemCode":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.buyer_item_code " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.buyer_item_code) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "supplier_item_code":
                     case "SupplierItemCode":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.supplier_item_code " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.supplier_item_code) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buyer_item_description":
                     case "BuyerItemDescription":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.buyer_item_description " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.buyer_item_description) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "supplier_item_description":
                     case "SupplierItemDescription":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.supplier_item_description " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.supplier_item_description) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item.item_qty " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.item_qty) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "unit_of_measure":
                     case "UnitOfMeasure":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.unit_of_measure " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.unit_of_measure) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "price_unit":
                     case "PriceUnit":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item.price_unit " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.price_unit) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "document_number":
                     case "DocumentNumber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.document_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.document_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "document_revision":
                     case "DocumentRevision":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.document_revision " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.document_revision) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "buyer_departament":
                     case "BuyerDepartament":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.buyer_departament " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.buyer_departament) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "status":
                     case "Status":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.status) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item.price_per_unit " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.price_per_unit) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "exported":
                     case "Exported":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item.exported " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.exported) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item.icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "evolution_status":
                     case "EvolutionStatus":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.evolution_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.evolution_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "changed_status":
                     case "ChangedStatus":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.changed_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.changed_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "saldo":
                     case "Saldo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item.saldo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.saldo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "classificacao_contabil":
                     case "ClassificacaoContabil":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.classificacao_contabil " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.classificacao_contabil) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "deps":
                     case "Deps":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.deps " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.deps) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "peps":
                     case "Peps":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.peps " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.peps) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ovm":
                     case "Ovm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.ovm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.ovm) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(order_item.order_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.order_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buy_order_number")) 
                        {
                           whereClause += " OR UPPER(order_item.buy_order_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.buy_order_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("currency")) 
                        {
                           whereClause += " OR UPPER(order_item.currency) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.currency) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buyer_item_code")) 
                        {
                           whereClause += " OR UPPER(order_item.buyer_item_code) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.buyer_item_code) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("supplier_item_code")) 
                        {
                           whereClause += " OR UPPER(order_item.supplier_item_code) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.supplier_item_code) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buyer_item_description")) 
                        {
                           whereClause += " OR UPPER(order_item.buyer_item_description) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.buyer_item_description) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("supplier_item_description")) 
                        {
                           whereClause += " OR UPPER(order_item.supplier_item_description) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.supplier_item_description) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("unit_of_measure")) 
                        {
                           whereClause += " OR UPPER(order_item.unit_of_measure) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.unit_of_measure) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("document_number")) 
                        {
                           whereClause += " OR UPPER(order_item.document_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.document_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("document_revision")) 
                        {
                           whereClause += " OR UPPER(order_item.document_revision) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.document_revision) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("buyer_departament")) 
                        {
                           whereClause += " OR UPPER(order_item.buyer_departament) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.buyer_departament) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("status")) 
                        {
                           whereClause += " OR UPPER(order_item.status) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.status) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("evolution_status")) 
                        {
                           whereClause += " OR UPPER(order_item.evolution_status) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.evolution_status) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("changed_status")) 
                        {
                           whereClause += " OR UPPER(order_item.changed_status) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.changed_status) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("classificacao_contabil")) 
                        {
                           whereClause += " OR UPPER(order_item.classificacao_contabil) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.classificacao_contabil) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("deps")) 
                        {
                           whereClause += " OR UPPER(order_item.deps) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.deps) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("peps")) 
                        {
                           whereClause += " OR UPPER(order_item.peps) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.peps) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ovm")) 
                        {
                           whereClause += " OR UPPER(order_item.ovm) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.ovm) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(order_item.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ItemId" || parametro.FieldName == "item_id")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.item_id IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.item_id = :order_item_ItemId_855 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_ItemId_855", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
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
                         whereClause += "  order_item.order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.order_number LIKE :order_item_OrderNumber_8081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_OrderNumber_8081", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item.order_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.order_pos = :order_item_OrderPos_9887 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_OrderPos_9887", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumber2" || parametro.FieldName == "buy_order_number")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.buy_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buy_order_number LIKE :order_item_OrderNumber2_3151 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_OrderNumber2_3151", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerId" || parametro.FieldName == "buyer_id")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.buyer_id IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buyer_id = :order_item_BuyerId_8875 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_BuyerId_8875", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SupplyerId" || parametro.FieldName == "supplyer_id")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.supplyer_id IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.supplyer_id = :order_item_SupplyerId_3099 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_SupplyerId_3099", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerPlantId" || parametro.FieldName == "buyer_plant_id")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.buyer_plant_id IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buyer_plant_id = :order_item_BuyerPlantId_8388 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_BuyerPlantId_8388", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Currency" || parametro.FieldName == "currency")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.currency IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.currency LIKE :order_item_Currency_6657 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Currency_6657", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderDate" || parametro.FieldName == "order_date")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.order_date IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.order_date = :order_item_OrderDate_6389 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_OrderDate_6389", NpgsqlDbType.Date, parametro.Fieldvalue));
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
                         whereClause += "  order_item.delivery_date IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.delivery_date = :order_item_DeliveryDate_4272 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_DeliveryDate_4272", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EngineeringLevel" || parametro.FieldName == "engineering_level")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.engineering_level IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.engineering_level = :order_item_EngineeringLevel_615 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_EngineeringLevel_615", NpgsqlDbType.Smallint, parametro.Fieldvalue));
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
                         whereClause += "  order_item.buyer_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buyer_item_code LIKE :order_item_BuyerItemCode_3530 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_BuyerItemCode_3530", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SupplierItemCode" || parametro.FieldName == "supplier_item_code")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.supplier_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.supplier_item_code LIKE :order_item_SupplierItemCode_6765 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_SupplierItemCode_6765", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemDescription" || parametro.FieldName == "buyer_item_description")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.buyer_item_description IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buyer_item_description LIKE :order_item_BuyerItemDescription_3571 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_BuyerItemDescription_3571", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SupplierItemDescription" || parametro.FieldName == "supplier_item_description")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.supplier_item_description IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.supplier_item_description LIKE :order_item_SupplierItemDescription_8902 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_SupplierItemDescription_8902", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ItemQty" || parametro.FieldName == "item_qty")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.item_qty IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.item_qty = :order_item_ItemQty_6216 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_ItemQty_6216", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnitOfMeasure" || parametro.FieldName == "unit_of_measure")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.unit_of_measure IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.unit_of_measure LIKE :order_item_UnitOfMeasure_2522 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_UnitOfMeasure_2522", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PriceUnit" || parametro.FieldName == "price_unit")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.price_unit IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.price_unit = :order_item_PriceUnit_2390 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_PriceUnit_2390", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentNumber" || parametro.FieldName == "document_number")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.document_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.document_number LIKE :order_item_DocumentNumber_1683 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_DocumentNumber_1683", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentRevision" || parametro.FieldName == "document_revision")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.document_revision IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.document_revision LIKE :order_item_DocumentRevision_987 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_DocumentRevision_987", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerDepartament" || parametro.FieldName == "buyer_departament")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.buyer_departament IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buyer_departament LIKE :order_item_BuyerDepartament_8955 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_BuyerDepartament_8955", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Status" || parametro.FieldName == "status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.status LIKE :order_item_Status_2266 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Status_2266", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item.price_per_unit IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.price_per_unit = :order_item_PricePerUnit_8458 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_PricePerUnit_8458", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Exported" || parametro.FieldName == "exported")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.exported IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.exported = :order_item_Exported_451 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Exported_451", NpgsqlDbType.Smallint, parametro.Fieldvalue));
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
                         whereClause += "  order_item.icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.icms = :order_item_Icms_6094 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Icms_6094", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EvolutionStatus" || parametro.FieldName == "evolution_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.evolution_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.evolution_status LIKE :order_item_EvolutionStatus_2941 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_EvolutionStatus_2941", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChangedStatus" || parametro.FieldName == "changed_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.changed_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.changed_status LIKE :order_item_ChangedStatus_296 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_ChangedStatus_296", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Saldo" || parametro.FieldName == "saldo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.saldo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.saldo = :order_item_Saldo_2739 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Saldo_2739", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClassificacaoContabil" || parametro.FieldName == "classificacao_contabil")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.classificacao_contabil IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.classificacao_contabil LIKE :order_item_ClassificacaoContabil_447 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_ClassificacaoContabil_447", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Deps" || parametro.FieldName == "deps")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.deps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.deps LIKE :order_item_Deps_1753 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Deps_1753", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Peps" || parametro.FieldName == "peps")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.peps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.peps LIKE :order_item_Peps_1408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Peps_1408", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ovm" || parametro.FieldName == "ovm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.ovm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.ovm LIKE :order_item_Ovm_1682 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Ovm_1682", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.entity_uid LIKE :order_item_EntityUid_8796 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_EntityUid_8796", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.version = :order_item_Version_8245 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Version_8245", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  order_item.order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.order_number LIKE :order_item_OrderNumber_8905 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_OrderNumber_8905", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumber2Exato" || parametro.FieldName == "OrderNumber2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.buy_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buy_order_number LIKE :order_item_OrderNumber2_9451 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_OrderNumber2_9451", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CurrencyExato" || parametro.FieldName == "CurrencyExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.currency IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.currency LIKE :order_item_Currency_8460 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Currency_8460", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  order_item.buyer_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buyer_item_code LIKE :order_item_BuyerItemCode_4318 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_BuyerItemCode_4318", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SupplierItemCodeExato" || parametro.FieldName == "SupplierItemCodeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.supplier_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.supplier_item_code LIKE :order_item_SupplierItemCode_2311 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_SupplierItemCode_2311", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemDescriptionExato" || parametro.FieldName == "BuyerItemDescriptionExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.buyer_item_description IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buyer_item_description LIKE :order_item_BuyerItemDescription_6250 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_BuyerItemDescription_6250", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SupplierItemDescriptionExato" || parametro.FieldName == "SupplierItemDescriptionExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.supplier_item_description IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.supplier_item_description LIKE :order_item_SupplierItemDescription_959 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_SupplierItemDescription_959", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnitOfMeasureExato" || parametro.FieldName == "UnitOfMeasureExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.unit_of_measure IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.unit_of_measure LIKE :order_item_UnitOfMeasure_7806 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_UnitOfMeasure_7806", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentNumberExato" || parametro.FieldName == "DocumentNumberExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.document_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.document_number LIKE :order_item_DocumentNumber_4371 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_DocumentNumber_4371", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentRevisionExato" || parametro.FieldName == "DocumentRevisionExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.document_revision IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.document_revision LIKE :order_item_DocumentRevision_6522 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_DocumentRevision_6522", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerDepartamentExato" || parametro.FieldName == "BuyerDepartamentExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.buyer_departament IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.buyer_departament LIKE :order_item_BuyerDepartament_5330 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_BuyerDepartament_5330", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "StatusExato" || parametro.FieldName == "StatusExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.status LIKE :order_item_Status_7339 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Status_7339", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EvolutionStatusExato" || parametro.FieldName == "EvolutionStatusExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.evolution_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.evolution_status LIKE :order_item_EvolutionStatus_5225 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_EvolutionStatus_5225", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChangedStatusExato" || parametro.FieldName == "ChangedStatusExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.changed_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.changed_status LIKE :order_item_ChangedStatus_4620 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_ChangedStatus_4620", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClassificacaoContabilExato" || parametro.FieldName == "ClassificacaoContabilExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.classificacao_contabil IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.classificacao_contabil LIKE :order_item_ClassificacaoContabil_8753 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_ClassificacaoContabil_8753", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DepsExato" || parametro.FieldName == "DepsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.deps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.deps LIKE :order_item_Deps_827 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Deps_827", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PepsExato" || parametro.FieldName == "PepsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.peps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.peps LIKE :order_item_Peps_8770 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Peps_8770", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OvmExato" || parametro.FieldName == "OvmExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item.ovm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.ovm LIKE :order_item_Ovm_6368 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_Ovm_6368", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  order_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item.entity_uid LIKE :order_item_EntityUid_9280 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_EntityUid_9280", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrderItemClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrderItemClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrderItemClass), Convert.ToInt32(read["id_order_item"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrderItemClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ItemId = (int)read["item_id"];
                     entidade.OrderNumber = (read["order_number"] != DBNull.Value ? read["order_number"].ToString() : null);
                     entidade.OrderPos = (short)read["order_pos"];
                     entidade.OrderNumber2 = (read["buy_order_number"] != DBNull.Value ? read["buy_order_number"].ToString() : null);
                     entidade.BuyerId = read["buyer_id"] as int?;
                     entidade.SupplyerId = read["supplyer_id"] as int?;
                     entidade.BuyerPlantId = read["buyer_plant_id"] as int?;
                     entidade.Currency = (read["currency"] != DBNull.Value ? read["currency"].ToString() : null);
                     entidade.OrderDate = read["order_date"] as DateTime?;
                     entidade.DeliveryDate = read["delivery_date"] as DateTime?;
                     entidade.EngineeringLevel = (short)read["engineering_level"];
                     entidade.BuyerItemCode = (read["buyer_item_code"] != DBNull.Value ? read["buyer_item_code"].ToString() : null);
                     entidade.SupplierItemCode = (read["supplier_item_code"] != DBNull.Value ? read["supplier_item_code"].ToString() : null);
                     entidade.BuyerItemDescription = (read["buyer_item_description"] != DBNull.Value ? read["buyer_item_description"].ToString() : null);
                     entidade.SupplierItemDescription = (read["supplier_item_description"] != DBNull.Value ? read["supplier_item_description"].ToString() : null);
                     entidade.ItemQty = (double)read["item_qty"];
                     entidade.UnitOfMeasure = (read["unit_of_measure"] != DBNull.Value ? read["unit_of_measure"].ToString() : null);
                     entidade.PriceUnit = read["price_unit"] as double?;
                     entidade.DocumentNumber = (read["document_number"] != DBNull.Value ? read["document_number"].ToString() : null);
                     entidade.DocumentRevision = (read["document_revision"] != DBNull.Value ? read["document_revision"].ToString() : null);
                     entidade.BuyerDepartament = (read["buyer_departament"] != DBNull.Value ? read["buyer_departament"].ToString() : null);
                     entidade.Status = (read["status"] != DBNull.Value ? read["status"].ToString() : null);
                     entidade.PricePerUnit = read["price_per_unit"] as double?;
                     entidade.Exported = read["exported"] as short?;
                     entidade.Icms = read["icms"] as double?;
                     entidade.EvolutionStatus = (read["evolution_status"] != DBNull.Value ? read["evolution_status"].ToString() : null);
                     entidade.ChangedStatus = (read["changed_status"] != DBNull.Value ? read["changed_status"].ToString() : null);
                     entidade.Saldo = read["saldo"] as double?;
                     entidade.ClassificacaoContabil = (read["classificacao_contabil"] != DBNull.Value ? read["classificacao_contabil"].ToString() : null);
                     entidade.Deps = (read["deps"] != DBNull.Value ? read["deps"].ToString() : null);
                     entidade.Peps = (read["peps"] != DBNull.Value ? read["peps"].ToString() : null);
                     entidade.Ovm = (read["ovm"] != DBNull.Value ? read["ovm"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrderItemClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
