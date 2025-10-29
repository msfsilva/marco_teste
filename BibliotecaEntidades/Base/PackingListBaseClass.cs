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
     [Table("packing_list","pkl")]
     public class PackingListBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PackingListClass";
protected const string ErroDelete = "Erro ao excluir o PackingListClass  ";
protected const string ErroSave = "Erro ao salvar o PackingListClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do PackingListClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PackingListClass está sendo utilizada.";
#endregion
       protected string _ocOriginal{get;private set;}
       private string _ocOriginalCommited{get; set;}
        private string _valueOc;
         [Column("pkl_oc")]
        public virtual string Oc
         { 
            get { return this._valueOc; } 
            set 
            { 
                if (this._valueOc == value)return;
                 this._valueOc = value; 
            } 
        } 

       protected string _posOriginal{get;private set;}
       private string _posOriginalCommited{get; set;}
        private string _valuePos;
         [Column("pkl_pos")]
        public virtual string Pos
         { 
            get { return this._valuePos; } 
            set 
            { 
                if (this._valuePos == value)return;
                 this._valuePos = value; 
            } 
        } 

       protected DateTime? _dataGeracaoOriginal{get;private set;}
       private DateTime? _dataGeracaoOriginalCommited{get; set;}
        private DateTime? _valueDataGeracao;
         [Column("pkl_data_geracao")]
        public virtual DateTime? DataGeracao
         { 
            get { return this._valueDataGeracao; } 
            set 
            { 
                if (this._valueDataGeracao == value)return;
                 this._valueDataGeracao = value; 
            } 
        } 

       protected double? _quantidadeOriginal{get;private set;}
       private double? _quantidadeOriginalCommited{get; set;}
        private double? _valueQuantidade;
         [Column("pkl_quantidade")]
        public virtual double? Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected string _engineeringLevelOriginal{get;private set;}
       private string _engineeringLevelOriginalCommited{get; set;}
        private string _valueEngineeringLevel;
         [Column("pkl_engineering_level")]
        public virtual string EngineeringLevel
         { 
            get { return this._valueEngineeringLevel; } 
            set 
            { 
                if (this._valueEngineeringLevel == value)return;
                 this._valueEngineeringLevel = value; 
            } 
        } 

       protected string _nomeFornecedorOriginal{get;private set;}
       private string _nomeFornecedorOriginalCommited{get; set;}
        private string _valueNomeFornecedor;
         [Column("pkl_nome_fornecedor")]
        public virtual string NomeFornecedor
         { 
            get { return this._valueNomeFornecedor; } 
            set 
            { 
                if (this._valueNomeFornecedor == value)return;
                 this._valueNomeFornecedor = value; 
            } 
        } 

       protected string _enderecoFornecedorOriginal{get;private set;}
       private string _enderecoFornecedorOriginalCommited{get; set;}
        private string _valueEnderecoFornecedor;
         [Column("pkl_endereco_fornecedor")]
        public virtual string EnderecoFornecedor
         { 
            get { return this._valueEnderecoFornecedor; } 
            set 
            { 
                if (this._valueEnderecoFornecedor == value)return;
                 this._valueEnderecoFornecedor = value; 
            } 
        } 

       protected string _cidadeUfPaisFornecOriginal{get;private set;}
       private string _cidadeUfPaisFornecOriginalCommited{get; set;}
        private string _valueCidadeUfPaisFornec;
         [Column("pkl_cidade_uf_pais_fornec")]
        public virtual string CidadeUfPaisFornec
         { 
            get { return this._valueCidadeUfPaisFornec; } 
            set 
            { 
                if (this._valueCidadeUfPaisFornec == value)return;
                 this._valueCidadeUfPaisFornec = value; 
            } 
        } 

       protected int? _itemIdOriginal{get;private set;}
       private int? _itemIdOriginalCommited{get; set;}
        private int? _valueItemId;
         [Column("item_id")]
        public virtual int? ItemId
         { 
            get { return this._valueItemId; } 
            set 
            { 
                if (this._valueItemId == value)return;
                 this._valueItemId = value; 
            } 
        } 

       protected string _buyOrderNumberOriginal{get;private set;}
       private string _buyOrderNumberOriginalCommited{get; set;}
        private string _valueBuyOrderNumber;
         [Column("pkl_buy_order_number")]
        public virtual string BuyOrderNumber
         { 
            get { return this._valueBuyOrderNumber; } 
            set 
            { 
                if (this._valueBuyOrderNumber == value)return;
                 this._valueBuyOrderNumber = value; 
            } 
        } 

       protected string _buyerItemCodeOriginal{get;private set;}
       private string _buyerItemCodeOriginalCommited{get; set;}
        private string _valueBuyerItemCode;
         [Column("pkl_buyer_item_code")]
        public virtual string BuyerItemCode
         { 
            get { return this._valueBuyerItemCode; } 
            set 
            { 
                if (this._valueBuyerItemCode == value)return;
                 this._valueBuyerItemCode = value; 
            } 
        } 

       protected string _buyerItemDescriptionEnOriginal{get;private set;}
       private string _buyerItemDescriptionEnOriginalCommited{get; set;}
        private string _valueBuyerItemDescriptionEn;
         [Column("pkl_buyer_item_description_en")]
        public virtual string BuyerItemDescriptionEn
         { 
            get { return this._valueBuyerItemDescriptionEn; } 
            set 
            { 
                if (this._valueBuyerItemDescriptionEn == value)return;
                 this._valueBuyerItemDescriptionEn = value; 
            } 
        } 

       protected string _buyerItemDescriptionEsOriginal{get;private set;}
       private string _buyerItemDescriptionEsOriginalCommited{get; set;}
        private string _valueBuyerItemDescriptionEs;
         [Column("pkl_buyer_item_description_es")]
        public virtual string BuyerItemDescriptionEs
         { 
            get { return this._valueBuyerItemDescriptionEs; } 
            set 
            { 
                if (this._valueBuyerItemDescriptionEs == value)return;
                 this._valueBuyerItemDescriptionEs = value; 
            } 
        } 

       protected string _buyerItemDescriptionPtOriginal{get;private set;}
       private string _buyerItemDescriptionPtOriginalCommited{get; set;}
        private string _valueBuyerItemDescriptionPt;
         [Column("pkl_buyer_item_description_pt")]
        public virtual string BuyerItemDescriptionPt
         { 
            get { return this._valueBuyerItemDescriptionPt; } 
            set 
            { 
                if (this._valueBuyerItemDescriptionPt == value)return;
                 this._valueBuyerItemDescriptionPt = value; 
            } 
        } 

       protected string _pepOriginal{get;private set;}
       private string _pepOriginalCommited{get; set;}
        private string _valuePep;
         [Column("pkl_pep")]
        public virtual string Pep
         { 
            get { return this._valuePep; } 
            set 
            { 
                if (this._valuePep == value)return;
                 this._valuePep = value; 
            } 
        } 

       protected string _supplierItemCodeOriginal{get;private set;}
       private string _supplierItemCodeOriginalCommited{get; set;}
        private string _valueSupplierItemCode;
         [Column("pkl_supplier_item_code")]
        public virtual string SupplierItemCode
         { 
            get { return this._valueSupplierItemCode; } 
            set 
            { 
                if (this._valueSupplierItemCode == value)return;
                 this._valueSupplierItemCode = value; 
            } 
        } 

       protected string _unitOfMeasureOriginal{get;private set;}
       private string _unitOfMeasureOriginalCommited{get; set;}
        private string _valueUnitOfMeasure;
         [Column("pkl_unit_of_measure")]
        public virtual string UnitOfMeasure
         { 
            get { return this._valueUnitOfMeasure; } 
            set 
            { 
                if (this._valueUnitOfMeasure == value)return;
                 this._valueUnitOfMeasure = value; 
            } 
        } 

       protected short? _flagPaiOriginal{get;private set;}
       private short? _flagPaiOriginalCommited{get; set;}
        private short? _valueFlagPai;
         [Column("pkl_flag_pai")]
        public virtual short? FlagPai
         { 
            get { return this._valueFlagPai; } 
            set 
            { 
                if (this._valueFlagPai == value)return;
                 this._valueFlagPai = value; 
            } 
        } 

       protected int? _supplyerIdOriginal{get;private set;}
       private int? _supplyerIdOriginalCommited{get; set;}
        private int? _valueSupplyerId;
         [Column("pkl_supplyer_id")]
        public virtual int? SupplyerId
         { 
            get { return this._valueSupplyerId; } 
            set 
            { 
                if (this._valueSupplyerId == value)return;
                 this._valueSupplyerId = value; 
            } 
        } 

        public PackingListBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static PackingListClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PackingListClass) GetEntity(typeof(PackingListClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

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
                    "  public.packing_list  " +
                    "WHERE " +
                    "  id_packing_list = :id";
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
                        "  public.packing_list   " +
                        "SET  " + 
                        "  pkl_oc = :pkl_oc, " + 
                        "  pkl_pos = :pkl_pos, " + 
                        "  pkl_data_geracao = :pkl_data_geracao, " + 
                        "  pkl_quantidade = :pkl_quantidade, " + 
                        "  pkl_engineering_level = :pkl_engineering_level, " + 
                        "  pkl_nome_fornecedor = :pkl_nome_fornecedor, " + 
                        "  pkl_endereco_fornecedor = :pkl_endereco_fornecedor, " + 
                        "  pkl_cidade_uf_pais_fornec = :pkl_cidade_uf_pais_fornec, " + 
                        "  item_id = :item_id, " + 
                        "  pkl_buy_order_number = :pkl_buy_order_number, " + 
                        "  pkl_buyer_item_code = :pkl_buyer_item_code, " + 
                        "  pkl_buyer_item_description_en = :pkl_buyer_item_description_en, " + 
                        "  pkl_buyer_item_description_es = :pkl_buyer_item_description_es, " + 
                        "  pkl_buyer_item_description_pt = :pkl_buyer_item_description_pt, " + 
                        "  pkl_pep = :pkl_pep, " + 
                        "  pkl_supplier_item_code = :pkl_supplier_item_code, " + 
                        "  pkl_unit_of_measure = :pkl_unit_of_measure, " + 
                        "  pkl_flag_pai = :pkl_flag_pai, " + 
                        "  pkl_supplyer_id = :pkl_supplyer_id, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_packing_list = :id " +
                        "RETURNING id_packing_list;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.packing_list " +
                        "( " +
                        "  pkl_oc , " + 
                        "  pkl_pos , " + 
                        "  pkl_data_geracao , " + 
                        "  pkl_quantidade , " + 
                        "  pkl_engineering_level , " + 
                        "  pkl_nome_fornecedor , " + 
                        "  pkl_endereco_fornecedor , " + 
                        "  pkl_cidade_uf_pais_fornec , " + 
                        "  item_id , " + 
                        "  pkl_buy_order_number , " + 
                        "  pkl_buyer_item_code , " + 
                        "  pkl_buyer_item_description_en , " + 
                        "  pkl_buyer_item_description_es , " + 
                        "  pkl_buyer_item_description_pt , " + 
                        "  pkl_pep , " + 
                        "  pkl_supplier_item_code , " + 
                        "  pkl_unit_of_measure , " + 
                        "  pkl_flag_pai , " + 
                        "  pkl_supplyer_id , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :pkl_oc , " + 
                        "  :pkl_pos , " + 
                        "  :pkl_data_geracao , " + 
                        "  :pkl_quantidade , " + 
                        "  :pkl_engineering_level , " + 
                        "  :pkl_nome_fornecedor , " + 
                        "  :pkl_endereco_fornecedor , " + 
                        "  :pkl_cidade_uf_pais_fornec , " + 
                        "  :item_id , " + 
                        "  :pkl_buy_order_number , " + 
                        "  :pkl_buyer_item_code , " + 
                        "  :pkl_buyer_item_description_en , " + 
                        "  :pkl_buyer_item_description_es , " + 
                        "  :pkl_buyer_item_description_pt , " + 
                        "  :pkl_pep , " + 
                        "  :pkl_supplier_item_code , " + 
                        "  :pkl_unit_of_measure , " + 
                        "  :pkl_flag_pai , " + 
                        "  :pkl_supplyer_id , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_packing_list;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_oc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Oc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_pos", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_data_geracao", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataGeracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_engineering_level", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EngineeringLevel ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_nome_fornecedor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeFornecedor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_endereco_fornecedor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnderecoFornecedor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_cidade_uf_pais_fornec", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CidadeUfPaisFornec ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("item_id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ItemId ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_buy_order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyOrderNumber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_buyer_item_code", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerItemCode ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_buyer_item_description_en", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerItemDescriptionEn ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_buyer_item_description_es", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerItemDescriptionEs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_buyer_item_description_pt", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BuyerItemDescriptionPt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_pep", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pep ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_supplier_item_code", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SupplierItemCode ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_unit_of_measure", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UnitOfMeasure ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_flag_pai", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FlagPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pkl_supplyer_id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SupplyerId ?? DBNull.Value;
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
        public static PackingListClass CopiarEntidade(PackingListClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PackingListClass toRet = new PackingListClass(usuario,conn);
 toRet.Oc= entidadeCopiar.Oc;
 toRet.Pos= entidadeCopiar.Pos;
 toRet.DataGeracao= entidadeCopiar.DataGeracao;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.EngineeringLevel= entidadeCopiar.EngineeringLevel;
 toRet.NomeFornecedor= entidadeCopiar.NomeFornecedor;
 toRet.EnderecoFornecedor= entidadeCopiar.EnderecoFornecedor;
 toRet.CidadeUfPaisFornec= entidadeCopiar.CidadeUfPaisFornec;
 toRet.ItemId= entidadeCopiar.ItemId;
 toRet.BuyOrderNumber= entidadeCopiar.BuyOrderNumber;
 toRet.BuyerItemCode= entidadeCopiar.BuyerItemCode;
 toRet.BuyerItemDescriptionEn= entidadeCopiar.BuyerItemDescriptionEn;
 toRet.BuyerItemDescriptionEs= entidadeCopiar.BuyerItemDescriptionEs;
 toRet.BuyerItemDescriptionPt= entidadeCopiar.BuyerItemDescriptionPt;
 toRet.Pep= entidadeCopiar.Pep;
 toRet.SupplierItemCode= entidadeCopiar.SupplierItemCode;
 toRet.UnitOfMeasure= entidadeCopiar.UnitOfMeasure;
 toRet.FlagPai= entidadeCopiar.FlagPai;
 toRet.SupplyerId= entidadeCopiar.SupplyerId;

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
       _ocOriginal = Oc;
       _ocOriginalCommited = _ocOriginal;
       _posOriginal = Pos;
       _posOriginalCommited = _posOriginal;
       _dataGeracaoOriginal = DataGeracao;
       _dataGeracaoOriginalCommited = _dataGeracaoOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _engineeringLevelOriginal = EngineeringLevel;
       _engineeringLevelOriginalCommited = _engineeringLevelOriginal;
       _nomeFornecedorOriginal = NomeFornecedor;
       _nomeFornecedorOriginalCommited = _nomeFornecedorOriginal;
       _enderecoFornecedorOriginal = EnderecoFornecedor;
       _enderecoFornecedorOriginalCommited = _enderecoFornecedorOriginal;
       _cidadeUfPaisFornecOriginal = CidadeUfPaisFornec;
       _cidadeUfPaisFornecOriginalCommited = _cidadeUfPaisFornecOriginal;
       _itemIdOriginal = ItemId;
       _itemIdOriginalCommited = _itemIdOriginal;
       _buyOrderNumberOriginal = BuyOrderNumber;
       _buyOrderNumberOriginalCommited = _buyOrderNumberOriginal;
       _buyerItemCodeOriginal = BuyerItemCode;
       _buyerItemCodeOriginalCommited = _buyerItemCodeOriginal;
       _buyerItemDescriptionEnOriginal = BuyerItemDescriptionEn;
       _buyerItemDescriptionEnOriginalCommited = _buyerItemDescriptionEnOriginal;
       _buyerItemDescriptionEsOriginal = BuyerItemDescriptionEs;
       _buyerItemDescriptionEsOriginalCommited = _buyerItemDescriptionEsOriginal;
       _buyerItemDescriptionPtOriginal = BuyerItemDescriptionPt;
       _buyerItemDescriptionPtOriginalCommited = _buyerItemDescriptionPtOriginal;
       _pepOriginal = Pep;
       _pepOriginalCommited = _pepOriginal;
       _supplierItemCodeOriginal = SupplierItemCode;
       _supplierItemCodeOriginalCommited = _supplierItemCodeOriginal;
       _unitOfMeasureOriginal = UnitOfMeasure;
       _unitOfMeasureOriginalCommited = _unitOfMeasureOriginal;
       _flagPaiOriginal = FlagPai;
       _flagPaiOriginalCommited = _flagPaiOriginal;
       _supplyerIdOriginal = SupplyerId;
       _supplyerIdOriginalCommited = _supplyerIdOriginal;
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
       _ocOriginalCommited = Oc;
       _posOriginalCommited = Pos;
       _dataGeracaoOriginalCommited = DataGeracao;
       _quantidadeOriginalCommited = Quantidade;
       _engineeringLevelOriginalCommited = EngineeringLevel;
       _nomeFornecedorOriginalCommited = NomeFornecedor;
       _enderecoFornecedorOriginalCommited = EnderecoFornecedor;
       _cidadeUfPaisFornecOriginalCommited = CidadeUfPaisFornec;
       _itemIdOriginalCommited = ItemId;
       _buyOrderNumberOriginalCommited = BuyOrderNumber;
       _buyerItemCodeOriginalCommited = BuyerItemCode;
       _buyerItemDescriptionEnOriginalCommited = BuyerItemDescriptionEn;
       _buyerItemDescriptionEsOriginalCommited = BuyerItemDescriptionEs;
       _buyerItemDescriptionPtOriginalCommited = BuyerItemDescriptionPt;
       _pepOriginalCommited = Pep;
       _supplierItemCodeOriginalCommited = SupplierItemCode;
       _unitOfMeasureOriginalCommited = UnitOfMeasure;
       _flagPaiOriginalCommited = FlagPai;
       _supplyerIdOriginalCommited = SupplyerId;
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
               Oc=_ocOriginal;
               _ocOriginalCommited=_ocOriginal;
               Pos=_posOriginal;
               _posOriginalCommited=_posOriginal;
               DataGeracao=_dataGeracaoOriginal;
               _dataGeracaoOriginalCommited=_dataGeracaoOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               EngineeringLevel=_engineeringLevelOriginal;
               _engineeringLevelOriginalCommited=_engineeringLevelOriginal;
               NomeFornecedor=_nomeFornecedorOriginal;
               _nomeFornecedorOriginalCommited=_nomeFornecedorOriginal;
               EnderecoFornecedor=_enderecoFornecedorOriginal;
               _enderecoFornecedorOriginalCommited=_enderecoFornecedorOriginal;
               CidadeUfPaisFornec=_cidadeUfPaisFornecOriginal;
               _cidadeUfPaisFornecOriginalCommited=_cidadeUfPaisFornecOriginal;
               ItemId=_itemIdOriginal;
               _itemIdOriginalCommited=_itemIdOriginal;
               BuyOrderNumber=_buyOrderNumberOriginal;
               _buyOrderNumberOriginalCommited=_buyOrderNumberOriginal;
               BuyerItemCode=_buyerItemCodeOriginal;
               _buyerItemCodeOriginalCommited=_buyerItemCodeOriginal;
               BuyerItemDescriptionEn=_buyerItemDescriptionEnOriginal;
               _buyerItemDescriptionEnOriginalCommited=_buyerItemDescriptionEnOriginal;
               BuyerItemDescriptionEs=_buyerItemDescriptionEsOriginal;
               _buyerItemDescriptionEsOriginalCommited=_buyerItemDescriptionEsOriginal;
               BuyerItemDescriptionPt=_buyerItemDescriptionPtOriginal;
               _buyerItemDescriptionPtOriginalCommited=_buyerItemDescriptionPtOriginal;
               Pep=_pepOriginal;
               _pepOriginalCommited=_pepOriginal;
               SupplierItemCode=_supplierItemCodeOriginal;
               _supplierItemCodeOriginalCommited=_supplierItemCodeOriginal;
               UnitOfMeasure=_unitOfMeasureOriginal;
               _unitOfMeasureOriginalCommited=_unitOfMeasureOriginal;
               FlagPai=_flagPaiOriginal;
               _flagPaiOriginalCommited=_flagPaiOriginal;
               SupplyerId=_supplyerIdOriginal;
               _supplyerIdOriginalCommited=_supplyerIdOriginal;
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
       dirty = _ocOriginal != Oc;
      if (dirty) return true;
       dirty = _posOriginal != Pos;
      if (dirty) return true;
       dirty = _dataGeracaoOriginal != DataGeracao;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _engineeringLevelOriginal != EngineeringLevel;
      if (dirty) return true;
       dirty = _nomeFornecedorOriginal != NomeFornecedor;
      if (dirty) return true;
       dirty = _enderecoFornecedorOriginal != EnderecoFornecedor;
      if (dirty) return true;
       dirty = _cidadeUfPaisFornecOriginal != CidadeUfPaisFornec;
      if (dirty) return true;
       dirty = _itemIdOriginal != ItemId;
      if (dirty) return true;
       dirty = _buyOrderNumberOriginal != BuyOrderNumber;
      if (dirty) return true;
       dirty = _buyerItemCodeOriginal != BuyerItemCode;
      if (dirty) return true;
       dirty = _buyerItemDescriptionEnOriginal != BuyerItemDescriptionEn;
      if (dirty) return true;
       dirty = _buyerItemDescriptionEsOriginal != BuyerItemDescriptionEs;
      if (dirty) return true;
       dirty = _buyerItemDescriptionPtOriginal != BuyerItemDescriptionPt;
      if (dirty) return true;
       dirty = _pepOriginal != Pep;
      if (dirty) return true;
       dirty = _supplierItemCodeOriginal != SupplierItemCode;
      if (dirty) return true;
       dirty = _unitOfMeasureOriginal != UnitOfMeasure;
      if (dirty) return true;
       dirty = _flagPaiOriginal != FlagPai;
      if (dirty) return true;
       dirty = _supplyerIdOriginal != SupplyerId;
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
       dirty = _ocOriginalCommited != Oc;
      if (dirty) return true;
       dirty = _posOriginalCommited != Pos;
      if (dirty) return true;
       dirty = _dataGeracaoOriginalCommited != DataGeracao;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _engineeringLevelOriginalCommited != EngineeringLevel;
      if (dirty) return true;
       dirty = _nomeFornecedorOriginalCommited != NomeFornecedor;
      if (dirty) return true;
       dirty = _enderecoFornecedorOriginalCommited != EnderecoFornecedor;
      if (dirty) return true;
       dirty = _cidadeUfPaisFornecOriginalCommited != CidadeUfPaisFornec;
      if (dirty) return true;
       dirty = _itemIdOriginalCommited != ItemId;
      if (dirty) return true;
       dirty = _buyOrderNumberOriginalCommited != BuyOrderNumber;
      if (dirty) return true;
       dirty = _buyerItemCodeOriginalCommited != BuyerItemCode;
      if (dirty) return true;
       dirty = _buyerItemDescriptionEnOriginalCommited != BuyerItemDescriptionEn;
      if (dirty) return true;
       dirty = _buyerItemDescriptionEsOriginalCommited != BuyerItemDescriptionEs;
      if (dirty) return true;
       dirty = _buyerItemDescriptionPtOriginalCommited != BuyerItemDescriptionPt;
      if (dirty) return true;
       dirty = _pepOriginalCommited != Pep;
      if (dirty) return true;
       dirty = _supplierItemCodeOriginalCommited != SupplierItemCode;
      if (dirty) return true;
       dirty = _unitOfMeasureOriginalCommited != UnitOfMeasure;
      if (dirty) return true;
       dirty = _flagPaiOriginalCommited != FlagPai;
      if (dirty) return true;
       dirty = _supplyerIdOriginalCommited != SupplyerId;
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
             case "Oc":
                return this.Oc;
             case "Pos":
                return this.Pos;
             case "DataGeracao":
                return this.DataGeracao;
             case "Quantidade":
                return this.Quantidade;
             case "EngineeringLevel":
                return this.EngineeringLevel;
             case "NomeFornecedor":
                return this.NomeFornecedor;
             case "EnderecoFornecedor":
                return this.EnderecoFornecedor;
             case "CidadeUfPaisFornec":
                return this.CidadeUfPaisFornec;
             case "ItemId":
                return this.ItemId;
             case "BuyOrderNumber":
                return this.BuyOrderNumber;
             case "BuyerItemCode":
                return this.BuyerItemCode;
             case "BuyerItemDescriptionEn":
                return this.BuyerItemDescriptionEn;
             case "BuyerItemDescriptionEs":
                return this.BuyerItemDescriptionEs;
             case "BuyerItemDescriptionPt":
                return this.BuyerItemDescriptionPt;
             case "Pep":
                return this.Pep;
             case "SupplierItemCode":
                return this.SupplierItemCode;
             case "UnitOfMeasure":
                return this.UnitOfMeasure;
             case "FlagPai":
                return this.FlagPai;
             case "SupplyerId":
                return this.SupplyerId;
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
                  command.CommandText += " COUNT(packing_list.id_packing_list) " ;
               }
               else
               {
               command.CommandText += "packing_list.id_packing_list, " ;
               command.CommandText += "packing_list.pkl_oc, " ;
               command.CommandText += "packing_list.pkl_pos, " ;
               command.CommandText += "packing_list.pkl_data_geracao, " ;
               command.CommandText += "packing_list.pkl_quantidade, " ;
               command.CommandText += "packing_list.pkl_engineering_level, " ;
               command.CommandText += "packing_list.pkl_nome_fornecedor, " ;
               command.CommandText += "packing_list.pkl_endereco_fornecedor, " ;
               command.CommandText += "packing_list.pkl_cidade_uf_pais_fornec, " ;
               command.CommandText += "packing_list.item_id, " ;
               command.CommandText += "packing_list.pkl_buy_order_number, " ;
               command.CommandText += "packing_list.pkl_buyer_item_code, " ;
               command.CommandText += "packing_list.pkl_buyer_item_description_en, " ;
               command.CommandText += "packing_list.pkl_buyer_item_description_es, " ;
               command.CommandText += "packing_list.pkl_buyer_item_description_pt, " ;
               command.CommandText += "packing_list.pkl_pep, " ;
               command.CommandText += "packing_list.pkl_supplier_item_code, " ;
               command.CommandText += "packing_list.pkl_unit_of_measure, " ;
               command.CommandText += "packing_list.pkl_flag_pai, " ;
               command.CommandText += "packing_list.pkl_supplyer_id, " ;
               command.CommandText += "packing_list.entity_uid, " ;
               command.CommandText += "packing_list.version " ;
               }
               command.CommandText += " FROM  packing_list ";
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
                        orderByClause += " , pkl_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pkl_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = packing_list.id_acs_usuario_ultima_revisao ";
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
                     case "id_packing_list":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , packing_list.id_packing_list " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(packing_list.id_packing_list) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_oc":
                     case "Oc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_pos":
                     case "Pos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_data_geracao":
                     case "DataGeracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , packing_list.pkl_data_geracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(packing_list.pkl_data_geracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , packing_list.pkl_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(packing_list.pkl_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_engineering_level":
                     case "EngineeringLevel":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_engineering_level " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_engineering_level) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_nome_fornecedor":
                     case "NomeFornecedor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_nome_fornecedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_nome_fornecedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_endereco_fornecedor":
                     case "EnderecoFornecedor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_endereco_fornecedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_endereco_fornecedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_cidade_uf_pais_fornec":
                     case "CidadeUfPaisFornec":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_cidade_uf_pais_fornec " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_cidade_uf_pais_fornec) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "item_id":
                     case "ItemId":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , packing_list.item_id " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(packing_list.item_id) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_buy_order_number":
                     case "BuyOrderNumber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_buy_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_buy_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_buyer_item_code":
                     case "BuyerItemCode":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_buyer_item_code " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_buyer_item_code) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_buyer_item_description_en":
                     case "BuyerItemDescriptionEn":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_buyer_item_description_en " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_buyer_item_description_en) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_buyer_item_description_es":
                     case "BuyerItemDescriptionEs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_buyer_item_description_es " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_buyer_item_description_es) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_buyer_item_description_pt":
                     case "BuyerItemDescriptionPt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_buyer_item_description_pt " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_buyer_item_description_pt) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_pep":
                     case "Pep":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_pep " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_pep) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_supplier_item_code":
                     case "SupplierItemCode":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_supplier_item_code " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_supplier_item_code) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_unit_of_measure":
                     case "UnitOfMeasure":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.pkl_unit_of_measure " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.pkl_unit_of_measure) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_flag_pai":
                     case "FlagPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , packing_list.pkl_flag_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(packing_list.pkl_flag_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pkl_supplyer_id":
                     case "SupplyerId":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , packing_list.pkl_supplyer_id " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(packing_list.pkl_supplyer_id) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , packing_list.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(packing_list.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , packing_list.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(packing_list.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_oc")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_oc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_oc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_pos")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_pos) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_pos) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_engineering_level")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_engineering_level) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_engineering_level) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_nome_fornecedor")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_nome_fornecedor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_nome_fornecedor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_endereco_fornecedor")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_endereco_fornecedor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_endereco_fornecedor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_cidade_uf_pais_fornec")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_cidade_uf_pais_fornec) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_cidade_uf_pais_fornec) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_buy_order_number")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_buy_order_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_buy_order_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_buyer_item_code")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_buyer_item_code) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_buyer_item_code) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_buyer_item_description_en")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_buyer_item_description_en) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_buyer_item_description_en) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_buyer_item_description_es")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_buyer_item_description_es) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_buyer_item_description_es) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_buyer_item_description_pt")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_buyer_item_description_pt) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_buyer_item_description_pt) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_pep")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_pep) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_pep) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_supplier_item_code")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_supplier_item_code) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_supplier_item_code) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pkl_unit_of_measure")) 
                        {
                           whereClause += " OR UPPER(packing_list.pkl_unit_of_measure) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.pkl_unit_of_measure) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(packing_list.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(packing_list.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_packing_list")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.id_packing_list IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.id_packing_list = :packing_list_ID_1548 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_ID_1548", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Oc" || parametro.FieldName == "pkl_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_oc LIKE :packing_list_Oc_6409 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_Oc_6409", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pos" || parametro.FieldName == "pkl_pos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_pos LIKE :packing_list_Pos_164 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_Pos_164", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataGeracao" || parametro.FieldName == "pkl_data_geracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_data_geracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_data_geracao = :packing_list_DataGeracao_2408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_DataGeracao_2408", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "pkl_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_quantidade = :packing_list_Quantidade_8638 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_Quantidade_8638", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EngineeringLevel" || parametro.FieldName == "pkl_engineering_level")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_engineering_level IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_engineering_level LIKE :packing_list_EngineeringLevel_8229 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_EngineeringLevel_8229", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeFornecedor" || parametro.FieldName == "pkl_nome_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_nome_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_nome_fornecedor LIKE :packing_list_NomeFornecedor_3081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_NomeFornecedor_3081", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoFornecedor" || parametro.FieldName == "pkl_endereco_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_endereco_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_endereco_fornecedor LIKE :packing_list_EnderecoFornecedor_762 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_EnderecoFornecedor_762", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CidadeUfPaisFornec" || parametro.FieldName == "pkl_cidade_uf_pais_fornec")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_cidade_uf_pais_fornec IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_cidade_uf_pais_fornec LIKE :packing_list_CidadeUfPaisFornec_9675 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_CidadeUfPaisFornec_9675", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ItemId" || parametro.FieldName == "item_id")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.item_id IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.item_id = :packing_list_ItemId_8257 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_ItemId_8257", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyOrderNumber" || parametro.FieldName == "pkl_buy_order_number")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_buy_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buy_order_number LIKE :packing_list_BuyOrderNumber_5362 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyOrderNumber_5362", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemCode" || parametro.FieldName == "pkl_buyer_item_code")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_buyer_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buyer_item_code LIKE :packing_list_BuyerItemCode_7004 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyerItemCode_7004", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemDescriptionEn" || parametro.FieldName == "pkl_buyer_item_description_en")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_en IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_en LIKE :packing_list_BuyerItemDescriptionEn_8552 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyerItemDescriptionEn_8552", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemDescriptionEs" || parametro.FieldName == "pkl_buyer_item_description_es")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_es IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_es LIKE :packing_list_BuyerItemDescriptionEs_4750 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyerItemDescriptionEs_4750", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemDescriptionPt" || parametro.FieldName == "pkl_buyer_item_description_pt")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_pt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_pt LIKE :packing_list_BuyerItemDescriptionPt_3120 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyerItemDescriptionPt_3120", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pep" || parametro.FieldName == "pkl_pep")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_pep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_pep LIKE :packing_list_Pep_4731 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_Pep_4731", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SupplierItemCode" || parametro.FieldName == "pkl_supplier_item_code")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_supplier_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_supplier_item_code LIKE :packing_list_SupplierItemCode_4637 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_SupplierItemCode_4637", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnitOfMeasure" || parametro.FieldName == "pkl_unit_of_measure")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_unit_of_measure IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_unit_of_measure LIKE :packing_list_UnitOfMeasure_742 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_UnitOfMeasure_742", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FlagPai" || parametro.FieldName == "pkl_flag_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_flag_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_flag_pai = :packing_list_FlagPai_9784 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_FlagPai_9784", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SupplyerId" || parametro.FieldName == "pkl_supplyer_id")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_supplyer_id IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_supplyer_id = :packing_list_SupplyerId_118 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_SupplyerId_118", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  packing_list.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.entity_uid LIKE :packing_list_EntityUid_9160 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_EntityUid_9160", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  packing_list.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.version = :packing_list_Version_2884 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_Version_2884", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OcExato" || parametro.FieldName == "OcExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_oc LIKE :packing_list_Oc_504 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_Oc_504", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PosExato" || parametro.FieldName == "PosExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_pos LIKE :packing_list_Pos_3575 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_Pos_3575", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EngineeringLevelExato" || parametro.FieldName == "EngineeringLevelExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_engineering_level IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_engineering_level LIKE :packing_list_EngineeringLevel_3919 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_EngineeringLevel_3919", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeFornecedorExato" || parametro.FieldName == "NomeFornecedorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_nome_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_nome_fornecedor LIKE :packing_list_NomeFornecedor_8454 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_NomeFornecedor_8454", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoFornecedorExato" || parametro.FieldName == "EnderecoFornecedorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_endereco_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_endereco_fornecedor LIKE :packing_list_EnderecoFornecedor_3414 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_EnderecoFornecedor_3414", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CidadeUfPaisFornecExato" || parametro.FieldName == "CidadeUfPaisFornecExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_cidade_uf_pais_fornec IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_cidade_uf_pais_fornec LIKE :packing_list_CidadeUfPaisFornec_9481 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_CidadeUfPaisFornec_9481", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyOrderNumberExato" || parametro.FieldName == "BuyOrderNumberExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_buy_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buy_order_number LIKE :packing_list_BuyOrderNumber_9052 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyOrderNumber_9052", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  packing_list.pkl_buyer_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buyer_item_code LIKE :packing_list_BuyerItemCode_7555 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyerItemCode_7555", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemDescriptionEnExato" || parametro.FieldName == "BuyerItemDescriptionEnExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_en IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_en LIKE :packing_list_BuyerItemDescriptionEn_8924 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyerItemDescriptionEn_8924", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemDescriptionEsExato" || parametro.FieldName == "BuyerItemDescriptionEsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_es IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_es LIKE :packing_list_BuyerItemDescriptionEs_9997 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyerItemDescriptionEs_9997", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BuyerItemDescriptionPtExato" || parametro.FieldName == "BuyerItemDescriptionPtExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_pt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_buyer_item_description_pt LIKE :packing_list_BuyerItemDescriptionPt_92 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_BuyerItemDescriptionPt_92", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PepExato" || parametro.FieldName == "PepExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  packing_list.pkl_pep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_pep LIKE :packing_list_Pep_4765 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_Pep_4765", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  packing_list.pkl_supplier_item_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_supplier_item_code LIKE :packing_list_SupplierItemCode_3069 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_SupplierItemCode_3069", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  packing_list.pkl_unit_of_measure IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.pkl_unit_of_measure LIKE :packing_list_UnitOfMeasure_4693 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_UnitOfMeasure_4693", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  packing_list.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  packing_list.entity_uid LIKE :packing_list_EntityUid_3935 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("packing_list_EntityUid_3935", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PackingListClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PackingListClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PackingListClass), Convert.ToInt32(read["id_packing_list"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PackingListClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_packing_list"]);
                     entidade.Oc = (read["pkl_oc"] != DBNull.Value ? read["pkl_oc"].ToString() : null);
                     entidade.Pos = (read["pkl_pos"] != DBNull.Value ? read["pkl_pos"].ToString() : null);
                     entidade.DataGeracao = read["pkl_data_geracao"] as DateTime?;
                     entidade.Quantidade = read["pkl_quantidade"] as double?;
                     entidade.EngineeringLevel = (read["pkl_engineering_level"] != DBNull.Value ? read["pkl_engineering_level"].ToString() : null);
                     entidade.NomeFornecedor = (read["pkl_nome_fornecedor"] != DBNull.Value ? read["pkl_nome_fornecedor"].ToString() : null);
                     entidade.EnderecoFornecedor = (read["pkl_endereco_fornecedor"] != DBNull.Value ? read["pkl_endereco_fornecedor"].ToString() : null);
                     entidade.CidadeUfPaisFornec = (read["pkl_cidade_uf_pais_fornec"] != DBNull.Value ? read["pkl_cidade_uf_pais_fornec"].ToString() : null);
                     entidade.ItemId = read["item_id"] as int?;
                     entidade.BuyOrderNumber = (read["pkl_buy_order_number"] != DBNull.Value ? read["pkl_buy_order_number"].ToString() : null);
                     entidade.BuyerItemCode = (read["pkl_buyer_item_code"] != DBNull.Value ? read["pkl_buyer_item_code"].ToString() : null);
                     entidade.BuyerItemDescriptionEn = (read["pkl_buyer_item_description_en"] != DBNull.Value ? read["pkl_buyer_item_description_en"].ToString() : null);
                     entidade.BuyerItemDescriptionEs = (read["pkl_buyer_item_description_es"] != DBNull.Value ? read["pkl_buyer_item_description_es"].ToString() : null);
                     entidade.BuyerItemDescriptionPt = (read["pkl_buyer_item_description_pt"] != DBNull.Value ? read["pkl_buyer_item_description_pt"].ToString() : null);
                     entidade.Pep = (read["pkl_pep"] != DBNull.Value ? read["pkl_pep"].ToString() : null);
                     entidade.SupplierItemCode = (read["pkl_supplier_item_code"] != DBNull.Value ? read["pkl_supplier_item_code"].ToString() : null);
                     entidade.UnitOfMeasure = (read["pkl_unit_of_measure"] != DBNull.Value ? read["pkl_unit_of_measure"].ToString() : null);
                     entidade.FlagPai = read["pkl_flag_pai"] as short?;
                     entidade.SupplyerId = read["pkl_supplyer_id"] as int?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PackingListClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
