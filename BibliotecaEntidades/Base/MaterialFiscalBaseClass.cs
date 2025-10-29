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
     [Table("material_fiscal","mfs")]
     public class MaterialFiscalBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MaterialFiscalClass";
protected const string ErroDelete = "Erro ao excluir o MaterialFiscalClass  ";
protected const string ErroSave = "Erro ao salvar o MaterialFiscalClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected const string ErroModeloFiscalIcmsObrigatorio = "O campo ModeloFiscalIcms é obrigatório";
protected const string ErroNcmObrigatorio = "O campo Ncm é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do MaterialFiscalClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MaterialFiscalClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.MaterialClass _materialOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MaterialClass _materialOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MaterialClass _valueMaterial;
        [Column("id_material", "material", "id_material")]
       public virtual BibliotecaEntidades.Entidades.MaterialClass Material
        { 
           get {                 return this._valueMaterial; } 
           set 
           { 
                if (this._valueMaterial == value)return;
                 this._valueMaterial = value; 
           } 
       } 

       protected Origem _origemOriginal{get;private set;}
       private Origem _origemOriginalCommited{get; set;}
        private Origem _valueOrigem;
         [Column("mfs_origem")]
        public virtual Origem Origem
         { 
            get { return this._valueOrigem; } 
            set 
            { 
                if (this._valueOrigem == value)return;
                 this._valueOrigem = value; 
            } 
        } 

        public bool Origem_Nacional
         { 
            get { return this._valueOrigem == BibliotecaEntidades.Base.Origem.Nacional; } 
            set { if (value) this._valueOrigem = BibliotecaEntidades.Base.Origem.Nacional; }
         } 

        public bool Origem_ImportacaoDireta
         { 
            get { return this._valueOrigem == BibliotecaEntidades.Base.Origem.ImportacaoDireta; } 
            set { if (value) this._valueOrigem = BibliotecaEntidades.Base.Origem.ImportacaoDireta; }
         } 

        public bool Origem_ImportacaoIndireta
         { 
            get { return this._valueOrigem == BibliotecaEntidades.Base.Origem.ImportacaoIndireta; } 
            set { if (value) this._valueOrigem = BibliotecaEntidades.Base.Origem.ImportacaoIndireta; }
         } 

       protected string _extipiOriginal{get;private set;}
       private string _extipiOriginalCommited{get; set;}
        private string _valueExtipi;
         [Column("mfs_extipi")]
        public virtual string Extipi
         { 
            get { return this._valueExtipi; } 
            set 
            { 
                if (this._valueExtipi == value)return;
                 this._valueExtipi = value; 
            } 
        } 

       protected int? _generoOriginal{get;private set;}
       private int? _generoOriginalCommited{get; set;}
        private int? _valueGenero;
         [Column("mfs_genero")]
        public virtual int? Genero
         { 
            get { return this._valueGenero; } 
            set 
            { 
                if (this._valueGenero == value)return;
                 this._valueGenero = value; 
            } 
        } 

       protected bool _cofinsOriginal{get;private set;}
       private bool _cofinsOriginalCommited{get; set;}
        private bool _valueCofins;
         [Column("mfs_cofins")]
        public virtual bool Cofins
         { 
            get { return this._valueCofins; } 
            set 
            { 
                if (this._valueCofins == value)return;
                 this._valueCofins = value; 
            } 
        } 

       protected string _cofinsCstOriginal{get;private set;}
       private string _cofinsCstOriginalCommited{get; set;}
        private string _valueCofinsCst;
         [Column("mfs_cofins_cst")]
        public virtual string CofinsCst
         { 
            get { return this._valueCofinsCst; } 
            set 
            { 
                if (this._valueCofinsCst == value)return;
                 this._valueCofinsCst = value; 
            } 
        } 

       protected double? _cofinsAliquotaOriginal{get;private set;}
       private double? _cofinsAliquotaOriginalCommited{get; set;}
        private double? _valueCofinsAliquota;
         [Column("mfs_cofins_aliquota")]
        public virtual double? CofinsAliquota
         { 
            get { return this._valueCofinsAliquota; } 
            set 
            { 
                if (this._valueCofinsAliquota == value)return;
                 this._valueCofinsAliquota = value; 
            } 
        } 

       protected int? _cofinsModalidadeTributacaoOriginal{get;private set;}
       private int? _cofinsModalidadeTributacaoOriginalCommited{get; set;}
        private int? _valueCofinsModalidadeTributacao;
         [Column("mfs_cofins_modalidade_tributacao")]
        public virtual int? CofinsModalidadeTributacao
         { 
            get { return this._valueCofinsModalidadeTributacao; } 
            set 
            { 
                if (this._valueCofinsModalidadeTributacao == value)return;
                 this._valueCofinsModalidadeTributacao = value; 
            } 
        } 

       protected int? _cofinsImpostoRetidoOriginal{get;private set;}
       private int? _cofinsImpostoRetidoOriginalCommited{get; set;}
        private int? _valueCofinsImpostoRetido;
         [Column("mfs_cofins_imposto_retido")]
        public virtual int? CofinsImpostoRetido
         { 
            get { return this._valueCofinsImpostoRetido; } 
            set 
            { 
                if (this._valueCofinsImpostoRetido == value)return;
                 this._valueCofinsImpostoRetido = value; 
            } 
        } 

       protected bool _pisOriginal{get;private set;}
       private bool _pisOriginalCommited{get; set;}
        private bool _valuePis;
         [Column("mfs_pis")]
        public virtual bool Pis
         { 
            get { return this._valuePis; } 
            set 
            { 
                if (this._valuePis == value)return;
                 this._valuePis = value; 
            } 
        } 

       protected string _pisCstOriginal{get;private set;}
       private string _pisCstOriginalCommited{get; set;}
        private string _valuePisCst;
         [Column("mfs_pis_cst")]
        public virtual string PisCst
         { 
            get { return this._valuePisCst; } 
            set 
            { 
                if (this._valuePisCst == value)return;
                 this._valuePisCst = value; 
            } 
        } 

       protected double? _pisAliquotaOriginal{get;private set;}
       private double? _pisAliquotaOriginalCommited{get; set;}
        private double? _valuePisAliquota;
         [Column("mfs_pis_aliquota")]
        public virtual double? PisAliquota
         { 
            get { return this._valuePisAliquota; } 
            set 
            { 
                if (this._valuePisAliquota == value)return;
                 this._valuePisAliquota = value; 
            } 
        } 

       protected int? _pisModalidadeTributacaoOriginal{get;private set;}
       private int? _pisModalidadeTributacaoOriginalCommited{get; set;}
        private int? _valuePisModalidadeTributacao;
         [Column("mfs_pis_modalidade_tributacao")]
        public virtual int? PisModalidadeTributacao
         { 
            get { return this._valuePisModalidadeTributacao; } 
            set 
            { 
                if (this._valuePisModalidadeTributacao == value)return;
                 this._valuePisModalidadeTributacao = value; 
            } 
        } 

       protected int? _pisImpostoRetidoOriginal{get;private set;}
       private int? _pisImpostoRetidoOriginalCommited{get; set;}
        private int? _valuePisImpostoRetido;
         [Column("mfs_pis_imposto_retido")]
        public virtual int? PisImpostoRetido
         { 
            get { return this._valuePisImpostoRetido; } 
            set 
            { 
                if (this._valuePisImpostoRetido == value)return;
                 this._valuePisImpostoRetido = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ModeloFiscalIcmsClass _modeloFiscalIcmsOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ModeloFiscalIcmsClass _modeloFiscalIcmsOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ModeloFiscalIcmsClass _valueModeloFiscalIcms;
        [Column("id_modelo_fiscal_icms", "modelo_fiscal_icms", "id_modelo_fiscal_icms")]
       public virtual BibliotecaEntidades.Entidades.ModeloFiscalIcmsClass ModeloFiscalIcms
        { 
           get {                 return this._valueModeloFiscalIcms; } 
           set 
           { 
                if (this._valueModeloFiscalIcms == value)return;
                 this._valueModeloFiscalIcms = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.NcmClass _ncmOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.NcmClass _ncmOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.NcmClass _valueNcm;
        [Column("id_ncm", "ncm", "id_ncm")]
       public virtual BibliotecaEntidades.Entidades.NcmClass Ncm
        { 
           get {                 return this._valueNcm; } 
           set 
           { 
                if (this._valueNcm == value)return;
                 this._valueNcm = value; 
           } 
       } 

        public MaterialFiscalBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Origem = (Origem)0;
           this.Cofins = false;
           this.Pis = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static MaterialFiscalClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MaterialFiscalClass) GetEntity(typeof(MaterialFiscalClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueMaterial == null)
                {
                    throw new Exception(ErroMaterialObrigatorio);
                }
                if ( _valueModeloFiscalIcms == null)
                {
                    throw new Exception(ErroModeloFiscalIcmsObrigatorio);
                }
                if ( _valueNcm == null)
                {
                    throw new Exception(ErroNcmObrigatorio);
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
                    "  public.material_fiscal  " +
                    "WHERE " +
                    "  id_material_fiscal = :id";
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
                        "  public.material_fiscal   " +
                        "SET  " + 
                        "  id_material = :id_material, " + 
                        "  mfs_origem = :mfs_origem, " + 
                        "  mfs_extipi = :mfs_extipi, " + 
                        "  mfs_genero = :mfs_genero, " + 
                        "  mfs_cofins = :mfs_cofins, " + 
                        "  mfs_cofins_cst = :mfs_cofins_cst, " + 
                        "  mfs_cofins_aliquota = :mfs_cofins_aliquota, " + 
                        "  mfs_cofins_modalidade_tributacao = :mfs_cofins_modalidade_tributacao, " + 
                        "  mfs_cofins_imposto_retido = :mfs_cofins_imposto_retido, " + 
                        "  mfs_pis = :mfs_pis, " + 
                        "  mfs_pis_cst = :mfs_pis_cst, " + 
                        "  mfs_pis_aliquota = :mfs_pis_aliquota, " + 
                        "  mfs_pis_modalidade_tributacao = :mfs_pis_modalidade_tributacao, " + 
                        "  mfs_pis_imposto_retido = :mfs_pis_imposto_retido, " + 
                        "  id_modelo_fiscal_icms = :id_modelo_fiscal_icms, " + 
                        "  id_ncm = :id_ncm, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_material_fiscal = :id " +
                        "RETURNING id_material_fiscal;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.material_fiscal " +
                        "( " +
                        "  id_material , " + 
                        "  mfs_origem , " + 
                        "  mfs_extipi , " + 
                        "  mfs_genero , " + 
                        "  mfs_cofins , " + 
                        "  mfs_cofins_cst , " + 
                        "  mfs_cofins_aliquota , " + 
                        "  mfs_cofins_modalidade_tributacao , " + 
                        "  mfs_cofins_imposto_retido , " + 
                        "  mfs_pis , " + 
                        "  mfs_pis_cst , " + 
                        "  mfs_pis_aliquota , " + 
                        "  mfs_pis_modalidade_tributacao , " + 
                        "  mfs_pis_imposto_retido , " + 
                        "  id_modelo_fiscal_icms , " + 
                        "  id_ncm , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_material , " + 
                        "  :mfs_origem , " + 
                        "  :mfs_extipi , " + 
                        "  :mfs_genero , " + 
                        "  :mfs_cofins , " + 
                        "  :mfs_cofins_cst , " + 
                        "  :mfs_cofins_aliquota , " + 
                        "  :mfs_cofins_modalidade_tributacao , " + 
                        "  :mfs_cofins_imposto_retido , " + 
                        "  :mfs_pis , " + 
                        "  :mfs_pis_cst , " + 
                        "  :mfs_pis_aliquota , " + 
                        "  :mfs_pis_modalidade_tributacao , " + 
                        "  :mfs_pis_imposto_retido , " + 
                        "  :id_modelo_fiscal_icms , " + 
                        "  :id_ncm , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_material_fiscal;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_origem", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Origem);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_extipi", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Extipi ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_genero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Genero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_cofins", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cofins ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_cofins_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_cofins_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_cofins_modalidade_tributacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsModalidadeTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_cofins_imposto_retido", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsImpostoRetido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_pis", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pis ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_pis_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_pis_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_pis_modalidade_tributacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisModalidadeTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfs_pis_imposto_retido", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisImpostoRetido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_modelo_fiscal_icms", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ModeloFiscalIcms==null ? (object) DBNull.Value : this.ModeloFiscalIcms.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ncm", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Ncm==null ? (object) DBNull.Value : this.Ncm.ID;
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
        public static MaterialFiscalClass CopiarEntidade(MaterialFiscalClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MaterialFiscalClass toRet = new MaterialFiscalClass(usuario,conn);
 toRet.Material= entidadeCopiar.Material;
 toRet.Origem= entidadeCopiar.Origem;
 toRet.Extipi= entidadeCopiar.Extipi;
 toRet.Genero= entidadeCopiar.Genero;
 toRet.Cofins= entidadeCopiar.Cofins;
 toRet.CofinsCst= entidadeCopiar.CofinsCst;
 toRet.CofinsAliquota= entidadeCopiar.CofinsAliquota;
 toRet.CofinsModalidadeTributacao= entidadeCopiar.CofinsModalidadeTributacao;
 toRet.CofinsImpostoRetido= entidadeCopiar.CofinsImpostoRetido;
 toRet.Pis= entidadeCopiar.Pis;
 toRet.PisCst= entidadeCopiar.PisCst;
 toRet.PisAliquota= entidadeCopiar.PisAliquota;
 toRet.PisModalidadeTributacao= entidadeCopiar.PisModalidadeTributacao;
 toRet.PisImpostoRetido= entidadeCopiar.PisImpostoRetido;
 toRet.ModeloFiscalIcms= entidadeCopiar.ModeloFiscalIcms;
 toRet.Ncm= entidadeCopiar.Ncm;

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
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _origemOriginal = Origem;
       _origemOriginalCommited = _origemOriginal;
       _extipiOriginal = Extipi;
       _extipiOriginalCommited = _extipiOriginal;
       _generoOriginal = Genero;
       _generoOriginalCommited = _generoOriginal;
       _cofinsOriginal = Cofins;
       _cofinsOriginalCommited = _cofinsOriginal;
       _cofinsCstOriginal = CofinsCst;
       _cofinsCstOriginalCommited = _cofinsCstOriginal;
       _cofinsAliquotaOriginal = CofinsAliquota;
       _cofinsAliquotaOriginalCommited = _cofinsAliquotaOriginal;
       _cofinsModalidadeTributacaoOriginal = CofinsModalidadeTributacao;
       _cofinsModalidadeTributacaoOriginalCommited = _cofinsModalidadeTributacaoOriginal;
       _cofinsImpostoRetidoOriginal = CofinsImpostoRetido;
       _cofinsImpostoRetidoOriginalCommited = _cofinsImpostoRetidoOriginal;
       _pisOriginal = Pis;
       _pisOriginalCommited = _pisOriginal;
       _pisCstOriginal = PisCst;
       _pisCstOriginalCommited = _pisCstOriginal;
       _pisAliquotaOriginal = PisAliquota;
       _pisAliquotaOriginalCommited = _pisAliquotaOriginal;
       _pisModalidadeTributacaoOriginal = PisModalidadeTributacao;
       _pisModalidadeTributacaoOriginalCommited = _pisModalidadeTributacaoOriginal;
       _pisImpostoRetidoOriginal = PisImpostoRetido;
       _pisImpostoRetidoOriginalCommited = _pisImpostoRetidoOriginal;
       _modeloFiscalIcmsOriginal = ModeloFiscalIcms;
       _modeloFiscalIcmsOriginalCommited = _modeloFiscalIcmsOriginal;
       _ncmOriginal = Ncm;
       _ncmOriginalCommited = _ncmOriginal;
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
       _materialOriginalCommited = Material;
       _origemOriginalCommited = Origem;
       _extipiOriginalCommited = Extipi;
       _generoOriginalCommited = Genero;
       _cofinsOriginalCommited = Cofins;
       _cofinsCstOriginalCommited = CofinsCst;
       _cofinsAliquotaOriginalCommited = CofinsAliquota;
       _cofinsModalidadeTributacaoOriginalCommited = CofinsModalidadeTributacao;
       _cofinsImpostoRetidoOriginalCommited = CofinsImpostoRetido;
       _pisOriginalCommited = Pis;
       _pisCstOriginalCommited = PisCst;
       _pisAliquotaOriginalCommited = PisAliquota;
       _pisModalidadeTributacaoOriginalCommited = PisModalidadeTributacao;
       _pisImpostoRetidoOriginalCommited = PisImpostoRetido;
       _modeloFiscalIcmsOriginalCommited = ModeloFiscalIcms;
       _ncmOriginalCommited = Ncm;
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
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               Origem=_origemOriginal;
               _origemOriginalCommited=_origemOriginal;
               Extipi=_extipiOriginal;
               _extipiOriginalCommited=_extipiOriginal;
               Genero=_generoOriginal;
               _generoOriginalCommited=_generoOriginal;
               Cofins=_cofinsOriginal;
               _cofinsOriginalCommited=_cofinsOriginal;
               CofinsCst=_cofinsCstOriginal;
               _cofinsCstOriginalCommited=_cofinsCstOriginal;
               CofinsAliquota=_cofinsAliquotaOriginal;
               _cofinsAliquotaOriginalCommited=_cofinsAliquotaOriginal;
               CofinsModalidadeTributacao=_cofinsModalidadeTributacaoOriginal;
               _cofinsModalidadeTributacaoOriginalCommited=_cofinsModalidadeTributacaoOriginal;
               CofinsImpostoRetido=_cofinsImpostoRetidoOriginal;
               _cofinsImpostoRetidoOriginalCommited=_cofinsImpostoRetidoOriginal;
               Pis=_pisOriginal;
               _pisOriginalCommited=_pisOriginal;
               PisCst=_pisCstOriginal;
               _pisCstOriginalCommited=_pisCstOriginal;
               PisAliquota=_pisAliquotaOriginal;
               _pisAliquotaOriginalCommited=_pisAliquotaOriginal;
               PisModalidadeTributacao=_pisModalidadeTributacaoOriginal;
               _pisModalidadeTributacaoOriginalCommited=_pisModalidadeTributacaoOriginal;
               PisImpostoRetido=_pisImpostoRetidoOriginal;
               _pisImpostoRetidoOriginalCommited=_pisImpostoRetidoOriginal;
               ModeloFiscalIcms=_modeloFiscalIcmsOriginal;
               _modeloFiscalIcmsOriginalCommited=_modeloFiscalIcmsOriginal;
               Ncm=_ncmOriginal;
               _ncmOriginalCommited=_ncmOriginal;
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
       if (_materialOriginal!=null)
       {
          dirty = !_materialOriginal.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
      if (dirty) return true;
       dirty = _origemOriginal != Origem;
      if (dirty) return true;
       dirty = _extipiOriginal != Extipi;
      if (dirty) return true;
       dirty = _generoOriginal != Genero;
      if (dirty) return true;
       dirty = _cofinsOriginal != Cofins;
      if (dirty) return true;
       dirty = _cofinsCstOriginal != CofinsCst;
      if (dirty) return true;
       dirty = _cofinsAliquotaOriginal != CofinsAliquota;
      if (dirty) return true;
       dirty = _cofinsModalidadeTributacaoOriginal != CofinsModalidadeTributacao;
      if (dirty) return true;
       dirty = _cofinsImpostoRetidoOriginal != CofinsImpostoRetido;
      if (dirty) return true;
       dirty = _pisOriginal != Pis;
      if (dirty) return true;
       dirty = _pisCstOriginal != PisCst;
      if (dirty) return true;
       dirty = _pisAliquotaOriginal != PisAliquota;
      if (dirty) return true;
       dirty = _pisModalidadeTributacaoOriginal != PisModalidadeTributacao;
      if (dirty) return true;
       dirty = _pisImpostoRetidoOriginal != PisImpostoRetido;
      if (dirty) return true;
       if (_modeloFiscalIcmsOriginal!=null)
       {
          dirty = !_modeloFiscalIcmsOriginal.Equals(ModeloFiscalIcms);
       }
       else
       {
            dirty = ModeloFiscalIcms != null;
       }
      if (dirty) return true;
       if (_ncmOriginal!=null)
       {
          dirty = !_ncmOriginal.Equals(Ncm);
       }
       else
       {
            dirty = Ncm != null;
       }
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
       if (_materialOriginalCommited!=null)
       {
          dirty = !_materialOriginalCommited.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
      if (dirty) return true;
       dirty = _origemOriginalCommited != Origem;
      if (dirty) return true;
       dirty = _extipiOriginalCommited != Extipi;
      if (dirty) return true;
       dirty = _generoOriginalCommited != Genero;
      if (dirty) return true;
       dirty = _cofinsOriginalCommited != Cofins;
      if (dirty) return true;
       dirty = _cofinsCstOriginalCommited != CofinsCst;
      if (dirty) return true;
       dirty = _cofinsAliquotaOriginalCommited != CofinsAliquota;
      if (dirty) return true;
       dirty = _cofinsModalidadeTributacaoOriginalCommited != CofinsModalidadeTributacao;
      if (dirty) return true;
       dirty = _cofinsImpostoRetidoOriginalCommited != CofinsImpostoRetido;
      if (dirty) return true;
       dirty = _pisOriginalCommited != Pis;
      if (dirty) return true;
       dirty = _pisCstOriginalCommited != PisCst;
      if (dirty) return true;
       dirty = _pisAliquotaOriginalCommited != PisAliquota;
      if (dirty) return true;
       dirty = _pisModalidadeTributacaoOriginalCommited != PisModalidadeTributacao;
      if (dirty) return true;
       dirty = _pisImpostoRetidoOriginalCommited != PisImpostoRetido;
      if (dirty) return true;
       if (_modeloFiscalIcmsOriginalCommited!=null)
       {
          dirty = !_modeloFiscalIcmsOriginalCommited.Equals(ModeloFiscalIcms);
       }
       else
       {
            dirty = ModeloFiscalIcms != null;
       }
      if (dirty) return true;
       if (_ncmOriginalCommited!=null)
       {
          dirty = !_ncmOriginalCommited.Equals(Ncm);
       }
       else
       {
            dirty = Ncm != null;
       }
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
             case "Material":
                return this.Material;
             case "Origem":
                return this.Origem;
             case "Extipi":
                return this.Extipi;
             case "Genero":
                return this.Genero;
             case "Cofins":
                return this.Cofins;
             case "CofinsCst":
                return this.CofinsCst;
             case "CofinsAliquota":
                return this.CofinsAliquota;
             case "CofinsModalidadeTributacao":
                return this.CofinsModalidadeTributacao;
             case "CofinsImpostoRetido":
                return this.CofinsImpostoRetido;
             case "Pis":
                return this.Pis;
             case "PisCst":
                return this.PisCst;
             case "PisAliquota":
                return this.PisAliquota;
             case "PisModalidadeTributacao":
                return this.PisModalidadeTributacao;
             case "PisImpostoRetido":
                return this.PisImpostoRetido;
             case "ModeloFiscalIcms":
                return this.ModeloFiscalIcms;
             case "Ncm":
                return this.Ncm;
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
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
             if (ModeloFiscalIcms!=null)
                ModeloFiscalIcms.ChangeSingleConnection(newConnection);
             if (Ncm!=null)
                Ncm.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(material_fiscal.id_material_fiscal) " ;
               }
               else
               {
               command.CommandText += "material_fiscal.id_material, " ;
               command.CommandText += "material_fiscal.mfs_origem, " ;
               command.CommandText += "material_fiscal.mfs_extipi, " ;
               command.CommandText += "material_fiscal.mfs_genero, " ;
               command.CommandText += "material_fiscal.mfs_cofins, " ;
               command.CommandText += "material_fiscal.mfs_cofins_cst, " ;
               command.CommandText += "material_fiscal.mfs_cofins_aliquota, " ;
               command.CommandText += "material_fiscal.mfs_cofins_modalidade_tributacao, " ;
               command.CommandText += "material_fiscal.mfs_cofins_imposto_retido, " ;
               command.CommandText += "material_fiscal.mfs_pis, " ;
               command.CommandText += "material_fiscal.mfs_pis_cst, " ;
               command.CommandText += "material_fiscal.mfs_pis_aliquota, " ;
               command.CommandText += "material_fiscal.mfs_pis_modalidade_tributacao, " ;
               command.CommandText += "material_fiscal.mfs_pis_imposto_retido, " ;
               command.CommandText += "material_fiscal.id_modelo_fiscal_icms, " ;
               command.CommandText += "material_fiscal.id_ncm, " ;
               command.CommandText += "material_fiscal.entity_uid, " ;
               command.CommandText += "material_fiscal.version, " ;
               command.CommandText += "material_fiscal.id_material_fiscal " ;
               }
               command.CommandText += " FROM  material_fiscal ";
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
                        orderByClause += " , mfs_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mfs_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = material_fiscal.id_acs_usuario_ultima_revisao ";
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
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = material_fiscal.id_material ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material_Material.mat_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material_Material.mat_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_origem":
                     case "Origem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_origem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_origem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_extipi":
                     case "Extipi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material_fiscal.mfs_extipi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material_fiscal.mfs_extipi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_genero":
                     case "Genero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_genero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_genero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_cofins":
                     case "Cofins":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_cofins " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_cofins) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_cofins_cst":
                     case "CofinsCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material_fiscal.mfs_cofins_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material_fiscal.mfs_cofins_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_cofins_aliquota":
                     case "CofinsAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_cofins_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_cofins_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_cofins_modalidade_tributacao":
                     case "CofinsModalidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_cofins_modalidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_cofins_modalidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_cofins_imposto_retido":
                     case "CofinsImpostoRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_cofins_imposto_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_cofins_imposto_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_pis":
                     case "Pis":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_pis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_pis) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_pis_cst":
                     case "PisCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material_fiscal.mfs_pis_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material_fiscal.mfs_pis_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_pis_aliquota":
                     case "PisAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_pis_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_pis_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_pis_modalidade_tributacao":
                     case "PisModalidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_pis_modalidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_pis_modalidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mfs_pis_imposto_retido":
                     case "PisImpostoRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.mfs_pis_imposto_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.mfs_pis_imposto_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_modelo_fiscal_icms":
                     case "ModeloFiscalIcms":
                     command.CommandText += " LEFT JOIN modelo_fiscal_icms as modelo_fiscal_icms_ModeloFiscalIcms ON modelo_fiscal_icms_ModeloFiscalIcms.id_modelo_fiscal_icms = material_fiscal.id_modelo_fiscal_icms ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_fiscal_icms_ModeloFiscalIcms.mfi_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_fiscal_icms_ModeloFiscalIcms.mfi_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ncm":
                     case "Ncm":
                     command.CommandText += " LEFT JOIN ncm as ncm_Ncm ON ncm_Ncm.id_ncm = material_fiscal.id_ncm ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm_Ncm.ncm_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm_Ncm.ncm_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material_fiscal.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material_fiscal.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , material_fiscal.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material_fiscal":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , material_fiscal.id_material_fiscal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(material_fiscal.id_material_fiscal) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mfs_extipi")) 
                        {
                           whereClause += " OR UPPER(material_fiscal.mfs_extipi) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material_fiscal.mfs_extipi) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mfs_cofins_cst")) 
                        {
                           whereClause += " OR UPPER(material_fiscal.mfs_cofins_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material_fiscal.mfs_cofins_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mfs_pis_cst")) 
                        {
                           whereClause += " OR UPPER(material_fiscal.mfs_pis_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material_fiscal.mfs_pis_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(material_fiscal.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(material_fiscal.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "Material" || parametro.FieldName == "id_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MaterialClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MaterialClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.id_material = :material_fiscal_Material_4361 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_Material_4361", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Origem" || parametro.FieldName == "mfs_origem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is Origem)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo Origem");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_origem = :material_fiscal_Origem_3531 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_Origem_3531", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Extipi" || parametro.FieldName == "mfs_extipi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_extipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_extipi LIKE :material_fiscal_Extipi_2390 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_Extipi_2390", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Genero" || parametro.FieldName == "mfs_genero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_genero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_genero = :material_fiscal_Genero_3644 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_Genero_3644", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cofins" || parametro.FieldName == "mfs_cofins")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_cofins IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_cofins = :material_fiscal_Cofins_1742 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_Cofins_1742", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsCst" || parametro.FieldName == "mfs_cofins_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_cofins_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_cofins_cst LIKE :material_fiscal_CofinsCst_3737 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_CofinsCst_3737", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsAliquota" || parametro.FieldName == "mfs_cofins_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_cofins_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_cofins_aliquota = :material_fiscal_CofinsAliquota_9426 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_CofinsAliquota_9426", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsModalidadeTributacao" || parametro.FieldName == "mfs_cofins_modalidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_cofins_modalidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_cofins_modalidade_tributacao = :material_fiscal_CofinsModalidadeTributacao_486 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_CofinsModalidadeTributacao_486", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsImpostoRetido" || parametro.FieldName == "mfs_cofins_imposto_retido")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_cofins_imposto_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_cofins_imposto_retido = :material_fiscal_CofinsImpostoRetido_777 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_CofinsImpostoRetido_777", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pis" || parametro.FieldName == "mfs_pis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_pis = :material_fiscal_Pis_8771 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_Pis_8771", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisCst" || parametro.FieldName == "mfs_pis_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_pis_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_pis_cst LIKE :material_fiscal_PisCst_876 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_PisCst_876", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisAliquota" || parametro.FieldName == "mfs_pis_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_pis_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_pis_aliquota = :material_fiscal_PisAliquota_6875 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_PisAliquota_6875", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisModalidadeTributacao" || parametro.FieldName == "mfs_pis_modalidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_pis_modalidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_pis_modalidade_tributacao = :material_fiscal_PisModalidadeTributacao_6365 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_PisModalidadeTributacao_6365", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisImpostoRetido" || parametro.FieldName == "mfs_pis_imposto_retido")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_pis_imposto_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_pis_imposto_retido = :material_fiscal_PisImpostoRetido_4542 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_PisImpostoRetido_4542", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloFiscalIcms" || parametro.FieldName == "id_modelo_fiscal_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ModeloFiscalIcmsClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ModeloFiscalIcmsClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.id_modelo_fiscal_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.id_modelo_fiscal_icms = :material_fiscal_ModeloFiscalIcms_1378 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_ModeloFiscalIcms_1378", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ncm" || parametro.FieldName == "id_ncm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.NcmClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.NcmClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.id_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.id_ncm = :material_fiscal_Ncm_4892 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_Ncm_4892", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  material_fiscal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.entity_uid LIKE :material_fiscal_EntityUid_8790 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_EntityUid_8790", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  material_fiscal.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.version = :material_fiscal_Version_2971 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_Version_2971", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_material_fiscal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.id_material_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.id_material_fiscal = :material_fiscal_ID_10 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_ID_10", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ExtipiExato" || parametro.FieldName == "ExtipiExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_extipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_extipi LIKE :material_fiscal_Extipi_5931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_Extipi_5931", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsCstExato" || parametro.FieldName == "CofinsCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_cofins_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_cofins_cst LIKE :material_fiscal_CofinsCst_1178 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_CofinsCst_1178", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisCstExato" || parametro.FieldName == "PisCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  material_fiscal.mfs_pis_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.mfs_pis_cst LIKE :material_fiscal_PisCst_8786 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_PisCst_8786", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  material_fiscal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  material_fiscal.entity_uid LIKE :material_fiscal_EntityUid_7669 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("material_fiscal_EntityUid_7669", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MaterialFiscalClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MaterialFiscalClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MaterialFiscalClass), Convert.ToInt32(read["id_material_fiscal"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MaterialFiscalClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     entidade.Origem = (Origem) (read["mfs_origem"] != DBNull.Value ? Enum.ToObject(typeof(Origem), read["mfs_origem"]) : null);
                     entidade.Extipi = (read["mfs_extipi"] != DBNull.Value ? read["mfs_extipi"].ToString() : null);
                     entidade.Genero = read["mfs_genero"] as int?;
                     entidade.Cofins = Convert.ToBoolean(Convert.ToInt16(read["mfs_cofins"]));
                     entidade.CofinsCst = (read["mfs_cofins_cst"] != DBNull.Value ? read["mfs_cofins_cst"].ToString() : null);
                     entidade.CofinsAliquota = read["mfs_cofins_aliquota"] as double?;
                     entidade.CofinsModalidadeTributacao = read["mfs_cofins_modalidade_tributacao"] as int?;
                     entidade.CofinsImpostoRetido = read["mfs_cofins_imposto_retido"] as int?;
                     entidade.Pis = Convert.ToBoolean(Convert.ToInt16(read["mfs_pis"]));
                     entidade.PisCst = (read["mfs_pis_cst"] != DBNull.Value ? read["mfs_pis_cst"].ToString() : null);
                     entidade.PisAliquota = read["mfs_pis_aliquota"] as double?;
                     entidade.PisModalidadeTributacao = read["mfs_pis_modalidade_tributacao"] as int?;
                     entidade.PisImpostoRetido = read["mfs_pis_imposto_retido"] as int?;
                     if (read["id_modelo_fiscal_icms"] != DBNull.Value)
                     {
                        entidade.ModeloFiscalIcms = (BibliotecaEntidades.Entidades.ModeloFiscalIcmsClass)BibliotecaEntidades.Entidades.ModeloFiscalIcmsClass.GetEntidade(Convert.ToInt32(read["id_modelo_fiscal_icms"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ModeloFiscalIcms = null ;
                     }
                     if (read["id_ncm"] != DBNull.Value)
                     {
                        entidade.Ncm = (BibliotecaEntidades.Entidades.NcmClass)BibliotecaEntidades.Entidades.NcmClass.GetEntidade(Convert.ToInt32(read["id_ncm"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Ncm = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ID = Convert.ToInt64(read["id_material_fiscal"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MaterialFiscalClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
