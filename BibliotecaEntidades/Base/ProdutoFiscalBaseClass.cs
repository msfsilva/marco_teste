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
     [Table("produto_fiscal","prf")]
     public class ProdutoFiscalBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProdutoFiscalClass";
protected const string ErroDelete = "Erro ao excluir o ProdutoFiscalClass  ";
protected const string ErroSave = "Erro ao salvar o ProdutoFiscalClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected const string ErroNcmObrigatorio = "O campo Ncm é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ProdutoFiscalClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoFiscalClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _valueProduto;
        [Column("id_produto", "produto", "id_produto")]
       public virtual BibliotecaEntidades.Entidades.ProdutoClass Produto
        { 
           get {                 return this._valueProduto; } 
           set 
           { 
                if (this._valueProduto == value)return;
                 this._valueProduto = value; 
           } 
       } 

       protected Origem _origemOriginal{get;private set;}
       private Origem _origemOriginalCommited{get; set;}
        private Origem _valueOrigem;
         [Column("prf_origem")]
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
         [Column("prf_extipi")]
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
         [Column("prf_genero")]
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
         [Column("prf_cofins")]
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
         [Column("prf_cofins_cst")]
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
         [Column("prf_cofins_aliquota")]
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
         [Column("prf_cofins_modalidade_tributacao")]
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
         [Column("prf_cofins_imposto_retido")]
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
         [Column("prf_pis")]
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
         [Column("prf_pis_cst")]
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
         [Column("prf_pis_aliquota")]
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
         [Column("prf_pis_modalidade_tributacao")]
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
         [Column("prf_pis_imposto_retido")]
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

        public ProdutoFiscalBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static ProdutoFiscalClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProdutoFiscalClass) GetEntity(typeof(ProdutoFiscalClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueProduto == null)
                {
                    throw new Exception(ErroProdutoObrigatorio);
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
                    "  public.produto_fiscal  " +
                    "WHERE " +
                    "  id_produto_fiscal = :id";
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
                        "  public.produto_fiscal   " +
                        "SET  " + 
                        "  id_produto = :id_produto, " + 
                        "  prf_origem = :prf_origem, " + 
                        "  prf_extipi = :prf_extipi, " + 
                        "  prf_genero = :prf_genero, " + 
                        "  prf_cofins = :prf_cofins, " + 
                        "  prf_cofins_cst = :prf_cofins_cst, " + 
                        "  prf_cofins_aliquota = :prf_cofins_aliquota, " + 
                        "  prf_cofins_modalidade_tributacao = :prf_cofins_modalidade_tributacao, " + 
                        "  prf_cofins_imposto_retido = :prf_cofins_imposto_retido, " + 
                        "  prf_pis = :prf_pis, " + 
                        "  prf_pis_cst = :prf_pis_cst, " + 
                        "  prf_pis_aliquota = :prf_pis_aliquota, " + 
                        "  prf_pis_modalidade_tributacao = :prf_pis_modalidade_tributacao, " + 
                        "  prf_pis_imposto_retido = :prf_pis_imposto_retido, " + 
                        "  id_modelo_fiscal_icms = :id_modelo_fiscal_icms, " + 
                        "  id_ncm = :id_ncm, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_produto_fiscal = :id " +
                        "RETURNING id_produto_fiscal;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.produto_fiscal " +
                        "( " +
                        "  id_produto , " + 
                        "  prf_origem , " + 
                        "  prf_extipi , " + 
                        "  prf_genero , " + 
                        "  prf_cofins , " + 
                        "  prf_cofins_cst , " + 
                        "  prf_cofins_aliquota , " + 
                        "  prf_cofins_modalidade_tributacao , " + 
                        "  prf_cofins_imposto_retido , " + 
                        "  prf_pis , " + 
                        "  prf_pis_cst , " + 
                        "  prf_pis_aliquota , " + 
                        "  prf_pis_modalidade_tributacao , " + 
                        "  prf_pis_imposto_retido , " + 
                        "  id_modelo_fiscal_icms , " + 
                        "  id_ncm , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto , " + 
                        "  :prf_origem , " + 
                        "  :prf_extipi , " + 
                        "  :prf_genero , " + 
                        "  :prf_cofins , " + 
                        "  :prf_cofins_cst , " + 
                        "  :prf_cofins_aliquota , " + 
                        "  :prf_cofins_modalidade_tributacao , " + 
                        "  :prf_cofins_imposto_retido , " + 
                        "  :prf_pis , " + 
                        "  :prf_pis_cst , " + 
                        "  :prf_pis_aliquota , " + 
                        "  :prf_pis_modalidade_tributacao , " + 
                        "  :prf_pis_imposto_retido , " + 
                        "  :id_modelo_fiscal_icms , " + 
                        "  :id_ncm , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_produto_fiscal;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_origem", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Origem);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_extipi", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Extipi ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_genero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Genero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cofins ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins_modalidade_tributacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsModalidadeTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins_imposto_retido", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsImpostoRetido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pis ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis_modalidade_tributacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisModalidadeTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis_imposto_retido", NpgsqlDbType.Integer));
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
        public static ProdutoFiscalClass CopiarEntidade(ProdutoFiscalClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProdutoFiscalClass toRet = new ProdutoFiscalClass(usuario,conn);
 toRet.Produto= entidadeCopiar.Produto;
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
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
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
       _produtoOriginalCommited = Produto;
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
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
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
       if (_produtoOriginal!=null)
       {
          dirty = !_produtoOriginal.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
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
       if (_produtoOriginalCommited!=null)
       {
          dirty = !_produtoOriginalCommited.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
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
             case "Produto":
                return this.Produto;
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
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(produto_fiscal.id_produto_fiscal) " ;
               }
               else
               {
               command.CommandText += "produto_fiscal.id_produto, " ;
               command.CommandText += "produto_fiscal.prf_origem, " ;
               command.CommandText += "produto_fiscal.prf_extipi, " ;
               command.CommandText += "produto_fiscal.prf_genero, " ;
               command.CommandText += "produto_fiscal.prf_cofins, " ;
               command.CommandText += "produto_fiscal.prf_cofins_cst, " ;
               command.CommandText += "produto_fiscal.prf_cofins_aliquota, " ;
               command.CommandText += "produto_fiscal.prf_cofins_modalidade_tributacao, " ;
               command.CommandText += "produto_fiscal.prf_cofins_imposto_retido, " ;
               command.CommandText += "produto_fiscal.prf_pis, " ;
               command.CommandText += "produto_fiscal.prf_pis_cst, " ;
               command.CommandText += "produto_fiscal.prf_pis_aliquota, " ;
               command.CommandText += "produto_fiscal.prf_pis_modalidade_tributacao, " ;
               command.CommandText += "produto_fiscal.prf_pis_imposto_retido, " ;
               command.CommandText += "produto_fiscal.id_modelo_fiscal_icms, " ;
               command.CommandText += "produto_fiscal.id_ncm, " ;
               command.CommandText += "produto_fiscal.entity_uid, " ;
               command.CommandText += "produto_fiscal.version, " ;
               command.CommandText += "produto_fiscal.id_produto_fiscal " ;
               }
               command.CommandText += " FROM  produto_fiscal ";
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
                        orderByClause += " , prf_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(prf_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = produto_fiscal.id_acs_usuario_ultima_revisao ";
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
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = produto_fiscal.id_produto ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_Produto.pro_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_Produto.pro_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_origem":
                     case "Origem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_origem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_origem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_extipi":
                     case "Extipi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_fiscal.prf_extipi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_fiscal.prf_extipi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_genero":
                     case "Genero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_genero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_genero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_cofins":
                     case "Cofins":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_cofins " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_cofins) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_cofins_cst":
                     case "CofinsCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_fiscal.prf_cofins_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_fiscal.prf_cofins_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_cofins_aliquota":
                     case "CofinsAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_cofins_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_cofins_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_cofins_modalidade_tributacao":
                     case "CofinsModalidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_cofins_modalidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_cofins_modalidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_cofins_imposto_retido":
                     case "CofinsImpostoRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_cofins_imposto_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_cofins_imposto_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_pis":
                     case "Pis":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_pis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_pis) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_pis_cst":
                     case "PisCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_fiscal.prf_pis_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_fiscal.prf_pis_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_pis_aliquota":
                     case "PisAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_pis_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_pis_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_pis_modalidade_tributacao":
                     case "PisModalidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_pis_modalidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_pis_modalidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prf_pis_imposto_retido":
                     case "PisImpostoRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.prf_pis_imposto_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.prf_pis_imposto_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_modelo_fiscal_icms":
                     case "ModeloFiscalIcms":
                     command.CommandText += " LEFT JOIN modelo_fiscal_icms as modelo_fiscal_icms_ModeloFiscalIcms ON modelo_fiscal_icms_ModeloFiscalIcms.id_modelo_fiscal_icms = produto_fiscal.id_modelo_fiscal_icms ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN ncm as ncm_Ncm ON ncm_Ncm.id_ncm = produto_fiscal.id_ncm ";                     switch (parametro.TipoOrdenacao)
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
                           orderByClause += " , produto_fiscal.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_fiscal.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , produto_fiscal.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto_fiscal":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_fiscal.id_produto_fiscal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_fiscal.id_produto_fiscal) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prf_extipi")) 
                        {
                           whereClause += " OR UPPER(produto_fiscal.prf_extipi) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_fiscal.prf_extipi) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prf_cofins_cst")) 
                        {
                           whereClause += " OR UPPER(produto_fiscal.prf_cofins_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_fiscal.prf_cofins_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prf_pis_cst")) 
                        {
                           whereClause += " OR UPPER(produto_fiscal.prf_pis_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_fiscal.prf_pis_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(produto_fiscal.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_fiscal.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "Produto" || parametro.FieldName == "id_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.id_produto = :produto_fiscal_Produto_1111 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_Produto_1111", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Origem" || parametro.FieldName == "prf_origem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is Origem)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo Origem");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_origem = :produto_fiscal_Origem_9866 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_Origem_9866", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Extipi" || parametro.FieldName == "prf_extipi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_extipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_extipi LIKE :produto_fiscal_Extipi_2962 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_Extipi_2962", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Genero" || parametro.FieldName == "prf_genero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_genero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_genero = :produto_fiscal_Genero_1125 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_Genero_1125", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cofins" || parametro.FieldName == "prf_cofins")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_cofins IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_cofins = :produto_fiscal_Cofins_2018 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_Cofins_2018", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsCst" || parametro.FieldName == "prf_cofins_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_cofins_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_cofins_cst LIKE :produto_fiscal_CofinsCst_6228 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_CofinsCst_6228", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsAliquota" || parametro.FieldName == "prf_cofins_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_cofins_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_cofins_aliquota = :produto_fiscal_CofinsAliquota_234 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_CofinsAliquota_234", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsModalidadeTributacao" || parametro.FieldName == "prf_cofins_modalidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_cofins_modalidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_cofins_modalidade_tributacao = :produto_fiscal_CofinsModalidadeTributacao_6278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_CofinsModalidadeTributacao_6278", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsImpostoRetido" || parametro.FieldName == "prf_cofins_imposto_retido")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_cofins_imposto_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_cofins_imposto_retido = :produto_fiscal_CofinsImpostoRetido_2135 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_CofinsImpostoRetido_2135", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pis" || parametro.FieldName == "prf_pis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_pis = :produto_fiscal_Pis_7170 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_Pis_7170", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisCst" || parametro.FieldName == "prf_pis_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_pis_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_pis_cst LIKE :produto_fiscal_PisCst_4797 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_PisCst_4797", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisAliquota" || parametro.FieldName == "prf_pis_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_pis_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_pis_aliquota = :produto_fiscal_PisAliquota_4763 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_PisAliquota_4763", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisModalidadeTributacao" || parametro.FieldName == "prf_pis_modalidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_pis_modalidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_pis_modalidade_tributacao = :produto_fiscal_PisModalidadeTributacao_2461 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_PisModalidadeTributacao_2461", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisImpostoRetido" || parametro.FieldName == "prf_pis_imposto_retido")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.prf_pis_imposto_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_pis_imposto_retido = :produto_fiscal_PisImpostoRetido_7568 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_PisImpostoRetido_7568", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  produto_fiscal.id_modelo_fiscal_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.id_modelo_fiscal_icms = :produto_fiscal_ModeloFiscalIcms_7365 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_ModeloFiscalIcms_7365", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  produto_fiscal.id_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.id_ncm = :produto_fiscal_Ncm_2983 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_Ncm_2983", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  produto_fiscal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.entity_uid LIKE :produto_fiscal_EntityUid_3170 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_EntityUid_3170", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_fiscal.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.version = :produto_fiscal_Version_9994 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_Version_9994", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_produto_fiscal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_fiscal.id_produto_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.id_produto_fiscal = :produto_fiscal_ID_8485 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_ID_8485", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  produto_fiscal.prf_extipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_extipi LIKE :produto_fiscal_Extipi_5679 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_Extipi_5679", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_fiscal.prf_cofins_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_cofins_cst LIKE :produto_fiscal_CofinsCst_778 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_CofinsCst_778", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_fiscal.prf_pis_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.prf_pis_cst LIKE :produto_fiscal_PisCst_5202 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_PisCst_5202", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_fiscal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_fiscal.entity_uid LIKE :produto_fiscal_EntityUid_7143 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_fiscal_EntityUid_7143", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProdutoFiscalClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProdutoFiscalClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProdutoFiscalClass), Convert.ToInt32(read["id_produto_fiscal"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProdutoFiscalClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     entidade.Origem = (Origem) (read["prf_origem"] != DBNull.Value ? Enum.ToObject(typeof(Origem), read["prf_origem"]) : null);
                     entidade.Extipi = (read["prf_extipi"] != DBNull.Value ? read["prf_extipi"].ToString() : null);
                     entidade.Genero = read["prf_genero"] as int?;
                     entidade.Cofins = Convert.ToBoolean(Convert.ToInt16(read["prf_cofins"]));
                     entidade.CofinsCst = (read["prf_cofins_cst"] != DBNull.Value ? read["prf_cofins_cst"].ToString() : null);
                     entidade.CofinsAliquota = read["prf_cofins_aliquota"] as double?;
                     entidade.CofinsModalidadeTributacao = read["prf_cofins_modalidade_tributacao"] as int?;
                     entidade.CofinsImpostoRetido = read["prf_cofins_imposto_retido"] as int?;
                     entidade.Pis = Convert.ToBoolean(Convert.ToInt16(read["prf_pis"]));
                     entidade.PisCst = (read["prf_pis_cst"] != DBNull.Value ? read["prf_pis_cst"].ToString() : null);
                     entidade.PisAliquota = read["prf_pis_aliquota"] as double?;
                     entidade.PisModalidadeTributacao = read["prf_pis_modalidade_tributacao"] as int?;
                     entidade.PisImpostoRetido = read["prf_pis_imposto_retido"] as int?;
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
                     entidade.ID = Convert.ToInt64(read["id_produto_fiscal"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProdutoFiscalClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
