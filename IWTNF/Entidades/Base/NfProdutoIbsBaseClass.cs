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
using IWTNF.Entidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNF.Entidades.Base 
{ 
    [Serializable()]
     [Table("nf_produto_ibs","npb")]
     public class NfProdutoIbsBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoIbsClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoIbsClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoIbsClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoIbsClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoIbsClass está sendo utilizada.";
#endregion
       protected IWTNF.Entidades.Entidades.NfItemClass _nfItemOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfItemClass _nfItemOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfItemClass _valueNfItem;
        [Column("id_nf_item", "nf_item", "id_nf_item")]
       public virtual IWTNF.Entidades.Entidades.NfItemClass NfItem
        { 
           get {                 return this._valueNfItem; } 
           set 
           { 
                if (this._valueNfItem == value)return;
                 this._valueNfItem = value; 
           } 
       } 

       protected string _cstIbsOriginal{get;private set;}
       private string _cstIbsOriginalCommited{get; set;}
        private string _valueCstIbs;
         [Column("npb_cst_ibs")]
        public virtual string CstIbs
         { 
            get { return this._valueCstIbs; } 
            set 
            { 
                if (this._valueCstIbs == value)return;
                 this._valueCstIbs = value; 
            } 
        } 

       protected double? _vBaseCalcIbsOriginal{get;private set;}
       private double? _vBaseCalcIbsOriginalCommited{get; set;}
        private double? _valueVBaseCalcIbs;
         [Column("npb_v_base_calc_ibs")]
        public virtual double? VBaseCalcIbs
         { 
            get { return this._valueVBaseCalcIbs; } 
            set 
            { 
                if (this._valueVBaseCalcIbs == value)return;
                 this._valueVBaseCalcIbs = value; 
            } 
        } 

       protected double? _pIbsUfOriginal{get;private set;}
       private double? _pIbsUfOriginalCommited{get; set;}
        private double? _valuePIbsUf;
         [Column("npb_p_ibs_uf")]
        public virtual double? PIbsUf
         { 
            get { return this._valuePIbsUf; } 
            set 
            { 
                if (this._valuePIbsUf == value)return;
                 this._valuePIbsUf = value; 
            } 
        } 

       protected bool _compoeTotalOriginal{get;private set;}
       private bool _compoeTotalOriginalCommited{get; set;}
        private bool _valueCompoeTotal;
         [Column("npb_compoe_total")]
        public virtual bool CompoeTotal
         { 
            get { return this._valueCompoeTotal; } 
            set 
            { 
                if (this._valueCompoeTotal == value)return;
                 this._valueCompoeTotal = value; 
            } 
        } 

       protected string _cClassTribOriginal{get;private set;}
       private string _cClassTribOriginalCommited{get; set;}
        private string _valueCClassTrib;
         [Column("npb_c_class_trib")]
        public virtual string CClassTrib
         { 
            get { return this._valueCClassTrib; } 
            set 
            { 
                if (this._valueCClassTrib == value)return;
                 this._valueCClassTrib = value; 
            } 
        } 

       protected string _indDoacaoOriginal{get;private set;}
       private string _indDoacaoOriginalCommited{get; set;}
        private string _valueIndDoacao;
         [Column("npb_ind_doacao")]
        public virtual string IndDoacao
         { 
            get { return this._valueIndDoacao; } 
            set 
            { 
                if (this._valueIndDoacao == value)return;
                 this._valueIndDoacao = value; 
            } 
        } 

       protected double? _pIbsMunOriginal{get;private set;}
       private double? _pIbsMunOriginalCommited{get; set;}
        private double? _valuePIbsMun;
         [Column("npb_p_ibs_mun")]
        public virtual double? PIbsMun
         { 
            get { return this._valuePIbsMun; } 
            set 
            { 
                if (this._valuePIbsMun == value)return;
                 this._valuePIbsMun = value; 
            } 
        } 

       protected double? _pDifOriginal{get;private set;}
       private double? _pDifOriginalCommited{get; set;}
        private double? _valuePDif;
         [Column("npb_p_dif")]
        public virtual double? PDif
         { 
            get { return this._valuePDif; } 
            set 
            { 
                if (this._valuePDif == value)return;
                 this._valuePDif = value; 
            } 
        } 

       protected double? _pRedAliqOriginal{get;private set;}
       private double? _pRedAliqOriginalCommited{get; set;}
        private double? _valuePRedAliq;
         [Column("npb_p_red_aliq")]
        public virtual double? PRedAliq
         { 
            get { return this._valuePRedAliq; } 
            set 
            { 
                if (this._valuePRedAliq == value)return;
                 this._valuePRedAliq = value; 
            } 
        } 

       protected string _cstRegOriginal{get;private set;}
       private string _cstRegOriginalCommited{get; set;}
        private string _valueCstReg;
         [Column("npb_cst_reg")]
        public virtual string CstReg
         { 
            get { return this._valueCstReg; } 
            set 
            { 
                if (this._valueCstReg == value)return;
                 this._valueCstReg = value; 
            } 
        } 

       protected string _cClassTribRegOriginal{get;private set;}
       private string _cClassTribRegOriginalCommited{get; set;}
        private string _valueCClassTribReg;
         [Column("npb_c_class_trib_reg")]
        public virtual string CClassTribReg
         { 
            get { return this._valueCClassTribReg; } 
            set 
            { 
                if (this._valueCClassTribReg == value)return;
                 this._valueCClassTribReg = value; 
            } 
        } 

       protected double? _pAliqEfetRegIbsUfOriginal{get;private set;}
       private double? _pAliqEfetRegIbsUfOriginalCommited{get; set;}
        private double? _valuePAliqEfetRegIbsUf;
         [Column("npb_p_aliq_efet_reg_ibs_uf")]
        public virtual double? PAliqEfetRegIbsUf
         { 
            get { return this._valuePAliqEfetRegIbsUf; } 
            set 
            { 
                if (this._valuePAliqEfetRegIbsUf == value)return;
                 this._valuePAliqEfetRegIbsUf = value; 
            } 
        } 

       protected double? _pAliqEfetRegIbsMunOriginal{get;private set;}
       private double? _pAliqEfetRegIbsMunOriginalCommited{get; set;}
        private double? _valuePAliqEfetRegIbsMun;
         [Column("npb_p_aliq_efet_reg_ibs_mun")]
        public virtual double? PAliqEfetRegIbsMun
         { 
            get { return this._valuePAliqEfetRegIbsMun; } 
            set 
            { 
                if (this._valuePAliqEfetRegIbsMun == value)return;
                 this._valuePAliqEfetRegIbsMun = value; 
            } 
        } 

       protected double? _pAliqIbsUfGovOriginal{get;private set;}
       private double? _pAliqIbsUfGovOriginalCommited{get; set;}
        private double? _valuePAliqIbsUfGov;
         [Column("npb_p_aliq_ibs_uf_gov")]
        public virtual double? PAliqIbsUfGov
         { 
            get { return this._valuePAliqIbsUfGov; } 
            set 
            { 
                if (this._valuePAliqIbsUfGov == value)return;
                 this._valuePAliqIbsUfGov = value; 
            } 
        } 

       protected double? _pAliqIbsMunGovOriginal{get;private set;}
       private double? _pAliqIbsMunGovOriginalCommited{get; set;}
        private double? _valuePAliqIbsMunGov;
         [Column("npb_p_aliq_ibs_mun_gov")]
        public virtual double? PAliqIbsMunGov
         { 
            get { return this._valuePAliqIbsMunGov; } 
            set 
            { 
                if (this._valuePAliqIbsMunGov == value)return;
                 this._valuePAliqIbsMunGov = value; 
            } 
        } 

       protected string _competApurAjusteOriginal{get;private set;}
       private string _competApurAjusteOriginalCommited{get; set;}
        private string _valueCompetApurAjuste;
         [Column("npb_compet_apur_ajuste")]
        public virtual string CompetApurAjuste
         { 
            get { return this._valueCompetApurAjuste; } 
            set 
            { 
                if (this._valueCompetApurAjuste == value)return;
                 this._valueCompetApurAjuste = value; 
            } 
        } 

       protected double? _vBcCredPresOriginal{get;private set;}
       private double? _vBcCredPresOriginalCommited{get; set;}
        private double? _valueVBcCredPres;
         [Column("npb_v_bc_cred_pres")]
        public virtual double? VBcCredPres
         { 
            get { return this._valueVBcCredPres; } 
            set 
            { 
                if (this._valueVBcCredPres == value)return;
                 this._valueVBcCredPres = value; 
            } 
        } 

       protected string _cCredPresOriginal{get;private set;}
       private string _cCredPresOriginalCommited{get; set;}
        private string _valueCCredPres;
         [Column("npb_c_cred_pres")]
        public virtual string CCredPres
         { 
            get { return this._valueCCredPres; } 
            set 
            { 
                if (this._valueCCredPres == value)return;
                 this._valueCCredPres = value; 
            } 
        } 

       protected double? _pCredPresOriginal{get;private set;}
       private double? _pCredPresOriginalCommited{get; set;}
        private double? _valuePCredPres;
         [Column("npb_p_cred_pres")]
        public virtual double? PCredPres
         { 
            get { return this._valuePCredPres; } 
            set 
            { 
                if (this._valuePCredPres == value)return;
                 this._valuePCredPres = value; 
            } 
        } 

       protected string _competApurZfmOriginal{get;private set;}
       private string _competApurZfmOriginalCommited{get; set;}
        private string _valueCompetApurZfm;
         [Column("npb_compet_apur_zfm")]
        public virtual string CompetApurZfm
         { 
            get { return this._valueCompetApurZfm; } 
            set 
            { 
                if (this._valueCompetApurZfm == value)return;
                 this._valueCompetApurZfm = value; 
            } 
        } 

       protected double? _vIbsTransfCredOriginal{get;private set;}
       private double? _vIbsTransfCredOriginalCommited{get; set;}
        private double? _valueVIbsTransfCred;
         [Column("npb_v_ibs_transf_cred")]
        public virtual double? VIbsTransfCred
         { 
            get { return this._valueVIbsTransfCred; } 
            set 
            { 
                if (this._valueVIbsTransfCred == value)return;
                 this._valueVIbsTransfCred = value; 
            } 
        } 

       protected double? _vIbsAjusteOriginal{get;private set;}
       private double? _vIbsAjusteOriginalCommited{get; set;}
        private double? _valueVIbsAjuste;
         [Column("npb_v_ibs_ajuste")]
        public virtual double? VIbsAjuste
         { 
            get { return this._valueVIbsAjuste; } 
            set 
            { 
                if (this._valueVIbsAjuste == value)return;
                 this._valueVIbsAjuste = value; 
            } 
        } 

       protected double? _vIbsEstornoCredOriginal{get;private set;}
       private double? _vIbsEstornoCredOriginalCommited{get; set;}
        private double? _valueVIbsEstornoCred;
         [Column("npb_v_ibs_estorno_cred")]
        public virtual double? VIbsEstornoCred
         { 
            get { return this._valueVIbsEstornoCred; } 
            set 
            { 
                if (this._valueVIbsEstornoCred == value)return;
                 this._valueVIbsEstornoCred = value; 
            } 
        } 

       protected double? _vCredPresIbszfmOriginal{get;private set;}
       private double? _vCredPresIbszfmOriginalCommited{get; set;}
        private double? _valueVCredPresIbszfm;
         [Column("npb_v_cred_pres_ibszfm")]
        public virtual double? VCredPresIbszfm
         { 
            get { return this._valueVCredPresIbszfm; } 
            set 
            { 
                if (this._valueVCredPresIbszfm == value)return;
                 this._valueVCredPresIbszfm = value; 
            } 
        } 

        public NfProdutoIbsBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.CompoeTotal = true;
           this.PIbsMun = 0;
           this.PDif = 0;
           this.PRedAliq = 0;
           this.PAliqEfetRegIbsUf = 0;
           this.PAliqEfetRegIbsMun = 0;
           this.PAliqIbsUfGov = 0;
           this.PAliqIbsMunGov = 0;
           this.VBcCredPres = 0;
           this.PCredPres = 0;
           this.VIbsTransfCred = 0;
           this.VIbsAjuste = 0;
           this.VIbsEstornoCred = 0;
           this.VCredPresIbszfm = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfProdutoIbsClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoIbsClass) GetEntity(typeof(NfProdutoIbsClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueNfItem == null)
                {
                    throw new Exception(ErroNfItemObrigatorio);
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
                    "  public.nf_produto_ibs  " +
                    "WHERE " +
                    "  id_nf_produto_ibs = :id";
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
                        "  public.nf_produto_ibs   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  npb_cst_ibs = :npb_cst_ibs, " + 
                        "  npb_v_base_calc_ibs = :npb_v_base_calc_ibs, " + 
                        "  npb_p_ibs_uf = :npb_p_ibs_uf, " + 
                        "  npb_compoe_total = :npb_compoe_total, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  npb_c_class_trib = :npb_c_class_trib, " + 
                        "  npb_ind_doacao = :npb_ind_doacao, " + 
                        "  npb_p_ibs_mun = :npb_p_ibs_mun, " + 
                        "  npb_p_dif = :npb_p_dif, " + 
                        "  npb_p_red_aliq = :npb_p_red_aliq, " + 
                        "  npb_cst_reg = :npb_cst_reg, " + 
                        "  npb_c_class_trib_reg = :npb_c_class_trib_reg, " + 
                        "  npb_p_aliq_efet_reg_ibs_uf = :npb_p_aliq_efet_reg_ibs_uf, " + 
                        "  npb_p_aliq_efet_reg_ibs_mun = :npb_p_aliq_efet_reg_ibs_mun, " + 
                        "  npb_p_aliq_ibs_uf_gov = :npb_p_aliq_ibs_uf_gov, " + 
                        "  npb_p_aliq_ibs_mun_gov = :npb_p_aliq_ibs_mun_gov, " + 
                        "  npb_compet_apur_ajuste = :npb_compet_apur_ajuste, " + 
                        "  npb_v_bc_cred_pres = :npb_v_bc_cred_pres, " + 
                        "  npb_c_cred_pres = :npb_c_cred_pres, " + 
                        "  npb_p_cred_pres = :npb_p_cred_pres, " + 
                        "  npb_compet_apur_zfm = :npb_compet_apur_zfm, " + 
                        "  npb_v_ibs_transf_cred = :npb_v_ibs_transf_cred, " + 
                        "  npb_v_ibs_ajuste = :npb_v_ibs_ajuste, " + 
                        "  npb_v_ibs_estorno_cred = :npb_v_ibs_estorno_cred, " + 
                        "  npb_v_cred_pres_ibszfm = :npb_v_cred_pres_ibszfm "+
                        "WHERE  " +
                        "  id_nf_produto_ibs = :id " +
                        "RETURNING id_nf_produto_ibs;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto_ibs " +
                        "( " +
                        "  id_nf_item , " + 
                        "  npb_cst_ibs , " + 
                        "  npb_v_base_calc_ibs , " + 
                        "  npb_p_ibs_uf , " + 
                        "  npb_compoe_total , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  npb_c_class_trib , " + 
                        "  npb_ind_doacao , " + 
                        "  npb_p_ibs_mun , " + 
                        "  npb_p_dif , " + 
                        "  npb_p_red_aliq , " + 
                        "  npb_cst_reg , " + 
                        "  npb_c_class_trib_reg , " + 
                        "  npb_p_aliq_efet_reg_ibs_uf , " + 
                        "  npb_p_aliq_efet_reg_ibs_mun , " + 
                        "  npb_p_aliq_ibs_uf_gov , " + 
                        "  npb_p_aliq_ibs_mun_gov , " + 
                        "  npb_compet_apur_ajuste , " + 
                        "  npb_v_bc_cred_pres , " + 
                        "  npb_c_cred_pres , " + 
                        "  npb_p_cred_pres , " + 
                        "  npb_compet_apur_zfm , " + 
                        "  npb_v_ibs_transf_cred , " + 
                        "  npb_v_ibs_ajuste , " + 
                        "  npb_v_ibs_estorno_cred , " + 
                        "  npb_v_cred_pres_ibszfm  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :npb_cst_ibs , " + 
                        "  :npb_v_base_calc_ibs , " + 
                        "  :npb_p_ibs_uf , " + 
                        "  :npb_compoe_total , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :npb_c_class_trib , " + 
                        "  :npb_ind_doacao , " + 
                        "  :npb_p_ibs_mun , " + 
                        "  :npb_p_dif , " + 
                        "  :npb_p_red_aliq , " + 
                        "  :npb_cst_reg , " + 
                        "  :npb_c_class_trib_reg , " + 
                        "  :npb_p_aliq_efet_reg_ibs_uf , " + 
                        "  :npb_p_aliq_efet_reg_ibs_mun , " + 
                        "  :npb_p_aliq_ibs_uf_gov , " + 
                        "  :npb_p_aliq_ibs_mun_gov , " + 
                        "  :npb_compet_apur_ajuste , " + 
                        "  :npb_v_bc_cred_pres , " + 
                        "  :npb_c_cred_pres , " + 
                        "  :npb_p_cred_pres , " + 
                        "  :npb_compet_apur_zfm , " + 
                        "  :npb_v_ibs_transf_cred , " + 
                        "  :npb_v_ibs_ajuste , " + 
                        "  :npb_v_ibs_estorno_cred , " + 
                        "  :npb_v_cred_pres_ibszfm  "+
                        ")RETURNING id_nf_produto_ibs;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_cst_ibs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CstIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_v_base_calc_ibs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBaseCalcIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_ibs_uf", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PIbsUf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_compoe_total", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompoeTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_c_class_trib", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CClassTrib ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_ind_doacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndDoacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_ibs_mun", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PIbsMun ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_dif", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PDif ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_red_aliq", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PRedAliq ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_cst_reg", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CstReg ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_c_class_trib_reg", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CClassTribReg ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_aliq_efet_reg_ibs_uf", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PAliqEfetRegIbsUf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_aliq_efet_reg_ibs_mun", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PAliqEfetRegIbsMun ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_aliq_ibs_uf_gov", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PAliqIbsUfGov ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_aliq_ibs_mun_gov", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PAliqIbsMunGov ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_compet_apur_ajuste", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompetApurAjuste ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_v_bc_cred_pres", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBcCredPres ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_c_cred_pres", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CCredPres ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_cred_pres", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PCredPres ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_compet_apur_zfm", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompetApurZfm ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_v_ibs_transf_cred", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsTransfCred ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_v_ibs_ajuste", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsAjuste ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_v_ibs_estorno_cred", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsEstornoCred ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_v_cred_pres_ibszfm", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCredPresIbszfm ?? DBNull.Value;

 
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
        public static NfProdutoIbsClass CopiarEntidade(NfProdutoIbsClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoIbsClass toRet = new NfProdutoIbsClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.CstIbs= entidadeCopiar.CstIbs;
 toRet.VBaseCalcIbs= entidadeCopiar.VBaseCalcIbs;
 toRet.PIbsUf= entidadeCopiar.PIbsUf;
 toRet.CompoeTotal= entidadeCopiar.CompoeTotal;
 toRet.CClassTrib= entidadeCopiar.CClassTrib;
 toRet.IndDoacao= entidadeCopiar.IndDoacao;
 toRet.PIbsMun= entidadeCopiar.PIbsMun;
 toRet.PDif= entidadeCopiar.PDif;
 toRet.PRedAliq= entidadeCopiar.PRedAliq;
 toRet.CstReg= entidadeCopiar.CstReg;
 toRet.CClassTribReg= entidadeCopiar.CClassTribReg;
 toRet.PAliqEfetRegIbsUf= entidadeCopiar.PAliqEfetRegIbsUf;
 toRet.PAliqEfetRegIbsMun= entidadeCopiar.PAliqEfetRegIbsMun;
 toRet.PAliqIbsUfGov= entidadeCopiar.PAliqIbsUfGov;
 toRet.PAliqIbsMunGov= entidadeCopiar.PAliqIbsMunGov;
 toRet.CompetApurAjuste= entidadeCopiar.CompetApurAjuste;
 toRet.VBcCredPres= entidadeCopiar.VBcCredPres;
 toRet.CCredPres= entidadeCopiar.CCredPres;
 toRet.PCredPres= entidadeCopiar.PCredPres;
 toRet.CompetApurZfm= entidadeCopiar.CompetApurZfm;
 toRet.VIbsTransfCred= entidadeCopiar.VIbsTransfCred;
 toRet.VIbsAjuste= entidadeCopiar.VIbsAjuste;
 toRet.VIbsEstornoCred= entidadeCopiar.VIbsEstornoCred;
 toRet.VCredPresIbszfm= entidadeCopiar.VCredPresIbszfm;

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
       _nfItemOriginal = NfItem;
       _nfItemOriginalCommited = _nfItemOriginal;
       _cstIbsOriginal = CstIbs;
       _cstIbsOriginalCommited = _cstIbsOriginal;
       _vBaseCalcIbsOriginal = VBaseCalcIbs;
       _vBaseCalcIbsOriginalCommited = _vBaseCalcIbsOriginal;
       _pIbsUfOriginal = PIbsUf;
       _pIbsUfOriginalCommited = _pIbsUfOriginal;
       _compoeTotalOriginal = CompoeTotal;
       _compoeTotalOriginalCommited = _compoeTotalOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _cClassTribOriginal = CClassTrib;
       _cClassTribOriginalCommited = _cClassTribOriginal;
       _indDoacaoOriginal = IndDoacao;
       _indDoacaoOriginalCommited = _indDoacaoOriginal;
       _pIbsMunOriginal = PIbsMun;
       _pIbsMunOriginalCommited = _pIbsMunOriginal;
       _pDifOriginal = PDif;
       _pDifOriginalCommited = _pDifOriginal;
       _pRedAliqOriginal = PRedAliq;
       _pRedAliqOriginalCommited = _pRedAliqOriginal;
       _cstRegOriginal = CstReg;
       _cstRegOriginalCommited = _cstRegOriginal;
       _cClassTribRegOriginal = CClassTribReg;
       _cClassTribRegOriginalCommited = _cClassTribRegOriginal;
       _pAliqEfetRegIbsUfOriginal = PAliqEfetRegIbsUf;
       _pAliqEfetRegIbsUfOriginalCommited = _pAliqEfetRegIbsUfOriginal;
       _pAliqEfetRegIbsMunOriginal = PAliqEfetRegIbsMun;
       _pAliqEfetRegIbsMunOriginalCommited = _pAliqEfetRegIbsMunOriginal;
       _pAliqIbsUfGovOriginal = PAliqIbsUfGov;
       _pAliqIbsUfGovOriginalCommited = _pAliqIbsUfGovOriginal;
       _pAliqIbsMunGovOriginal = PAliqIbsMunGov;
       _pAliqIbsMunGovOriginalCommited = _pAliqIbsMunGovOriginal;
       _competApurAjusteOriginal = CompetApurAjuste;
       _competApurAjusteOriginalCommited = _competApurAjusteOriginal;
       _vBcCredPresOriginal = VBcCredPres;
       _vBcCredPresOriginalCommited = _vBcCredPresOriginal;
       _cCredPresOriginal = CCredPres;
       _cCredPresOriginalCommited = _cCredPresOriginal;
       _pCredPresOriginal = PCredPres;
       _pCredPresOriginalCommited = _pCredPresOriginal;
       _competApurZfmOriginal = CompetApurZfm;
       _competApurZfmOriginalCommited = _competApurZfmOriginal;
       _vIbsTransfCredOriginal = VIbsTransfCred;
       _vIbsTransfCredOriginalCommited = _vIbsTransfCredOriginal;
       _vIbsAjusteOriginal = VIbsAjuste;
       _vIbsAjusteOriginalCommited = _vIbsAjusteOriginal;
       _vIbsEstornoCredOriginal = VIbsEstornoCred;
       _vIbsEstornoCredOriginalCommited = _vIbsEstornoCredOriginal;
       _vCredPresIbszfmOriginal = VCredPresIbszfm;
       _vCredPresIbszfmOriginalCommited = _vCredPresIbszfmOriginal;

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
       _nfItemOriginalCommited = NfItem;
       _cstIbsOriginalCommited = CstIbs;
       _vBaseCalcIbsOriginalCommited = VBaseCalcIbs;
       _pIbsUfOriginalCommited = PIbsUf;
       _compoeTotalOriginalCommited = CompoeTotal;
       _versionOriginalCommited = Version;
       _cClassTribOriginalCommited = CClassTrib;
       _indDoacaoOriginalCommited = IndDoacao;
       _pIbsMunOriginalCommited = PIbsMun;
       _pDifOriginalCommited = PDif;
       _pRedAliqOriginalCommited = PRedAliq;
       _cstRegOriginalCommited = CstReg;
       _cClassTribRegOriginalCommited = CClassTribReg;
       _pAliqEfetRegIbsUfOriginalCommited = PAliqEfetRegIbsUf;
       _pAliqEfetRegIbsMunOriginalCommited = PAliqEfetRegIbsMun;
       _pAliqIbsUfGovOriginalCommited = PAliqIbsUfGov;
       _pAliqIbsMunGovOriginalCommited = PAliqIbsMunGov;
       _competApurAjusteOriginalCommited = CompetApurAjuste;
       _vBcCredPresOriginalCommited = VBcCredPres;
       _cCredPresOriginalCommited = CCredPres;
       _pCredPresOriginalCommited = PCredPres;
       _competApurZfmOriginalCommited = CompetApurZfm;
       _vIbsTransfCredOriginalCommited = VIbsTransfCred;
       _vIbsAjusteOriginalCommited = VIbsAjuste;
       _vIbsEstornoCredOriginalCommited = VIbsEstornoCred;
       _vCredPresIbszfmOriginalCommited = VCredPresIbszfm;

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
               NfItem=_nfItemOriginal;
               _nfItemOriginalCommited=_nfItemOriginal;
               CstIbs=_cstIbsOriginal;
               _cstIbsOriginalCommited=_cstIbsOriginal;
               VBaseCalcIbs=_vBaseCalcIbsOriginal;
               _vBaseCalcIbsOriginalCommited=_vBaseCalcIbsOriginal;
               PIbsUf=_pIbsUfOriginal;
               _pIbsUfOriginalCommited=_pIbsUfOriginal;
               CompoeTotal=_compoeTotalOriginal;
               _compoeTotalOriginalCommited=_compoeTotalOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CClassTrib=_cClassTribOriginal;
               _cClassTribOriginalCommited=_cClassTribOriginal;
               IndDoacao=_indDoacaoOriginal;
               _indDoacaoOriginalCommited=_indDoacaoOriginal;
               PIbsMun=_pIbsMunOriginal;
               _pIbsMunOriginalCommited=_pIbsMunOriginal;
               PDif=_pDifOriginal;
               _pDifOriginalCommited=_pDifOriginal;
               PRedAliq=_pRedAliqOriginal;
               _pRedAliqOriginalCommited=_pRedAliqOriginal;
               CstReg=_cstRegOriginal;
               _cstRegOriginalCommited=_cstRegOriginal;
               CClassTribReg=_cClassTribRegOriginal;
               _cClassTribRegOriginalCommited=_cClassTribRegOriginal;
               PAliqEfetRegIbsUf=_pAliqEfetRegIbsUfOriginal;
               _pAliqEfetRegIbsUfOriginalCommited=_pAliqEfetRegIbsUfOriginal;
               PAliqEfetRegIbsMun=_pAliqEfetRegIbsMunOriginal;
               _pAliqEfetRegIbsMunOriginalCommited=_pAliqEfetRegIbsMunOriginal;
               PAliqIbsUfGov=_pAliqIbsUfGovOriginal;
               _pAliqIbsUfGovOriginalCommited=_pAliqIbsUfGovOriginal;
               PAliqIbsMunGov=_pAliqIbsMunGovOriginal;
               _pAliqIbsMunGovOriginalCommited=_pAliqIbsMunGovOriginal;
               CompetApurAjuste=_competApurAjusteOriginal;
               _competApurAjusteOriginalCommited=_competApurAjusteOriginal;
               VBcCredPres=_vBcCredPresOriginal;
               _vBcCredPresOriginalCommited=_vBcCredPresOriginal;
               CCredPres=_cCredPresOriginal;
               _cCredPresOriginalCommited=_cCredPresOriginal;
               PCredPres=_pCredPresOriginal;
               _pCredPresOriginalCommited=_pCredPresOriginal;
               CompetApurZfm=_competApurZfmOriginal;
               _competApurZfmOriginalCommited=_competApurZfmOriginal;
               VIbsTransfCred=_vIbsTransfCredOriginal;
               _vIbsTransfCredOriginalCommited=_vIbsTransfCredOriginal;
               VIbsAjuste=_vIbsAjusteOriginal;
               _vIbsAjusteOriginalCommited=_vIbsAjusteOriginal;
               VIbsEstornoCred=_vIbsEstornoCredOriginal;
               _vIbsEstornoCredOriginalCommited=_vIbsEstornoCredOriginal;
               VCredPresIbszfm=_vCredPresIbszfmOriginal;
               _vCredPresIbszfmOriginalCommited=_vCredPresIbszfmOriginal;

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
       if (_nfItemOriginal!=null)
       {
          dirty = !_nfItemOriginal.Equals(NfItem);
       }
       else
       {
            dirty = NfItem != null;
       }
      if (dirty) return true;
       dirty = _cstIbsOriginal != CstIbs;
      if (dirty) return true;
       dirty = _vBaseCalcIbsOriginal != VBaseCalcIbs;
      if (dirty) return true;
       dirty = _pIbsUfOriginal != PIbsUf;
      if (dirty) return true;
       dirty = _compoeTotalOriginal != CompoeTotal;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cClassTribOriginal != CClassTrib;
      if (dirty) return true;
       dirty = _indDoacaoOriginal != IndDoacao;
      if (dirty) return true;
       dirty = _pIbsMunOriginal != PIbsMun;
      if (dirty) return true;
       dirty = _pDifOriginal != PDif;
      if (dirty) return true;
       dirty = _pRedAliqOriginal != PRedAliq;
      if (dirty) return true;
       dirty = _cstRegOriginal != CstReg;
      if (dirty) return true;
       dirty = _cClassTribRegOriginal != CClassTribReg;
      if (dirty) return true;
       dirty = _pAliqEfetRegIbsUfOriginal != PAliqEfetRegIbsUf;
      if (dirty) return true;
       dirty = _pAliqEfetRegIbsMunOriginal != PAliqEfetRegIbsMun;
      if (dirty) return true;
       dirty = _pAliqIbsUfGovOriginal != PAliqIbsUfGov;
      if (dirty) return true;
       dirty = _pAliqIbsMunGovOriginal != PAliqIbsMunGov;
      if (dirty) return true;
       dirty = _competApurAjusteOriginal != CompetApurAjuste;
      if (dirty) return true;
       dirty = _vBcCredPresOriginal != VBcCredPres;
      if (dirty) return true;
       dirty = _cCredPresOriginal != CCredPres;
      if (dirty) return true;
       dirty = _pCredPresOriginal != PCredPres;
      if (dirty) return true;
       dirty = _competApurZfmOriginal != CompetApurZfm;
      if (dirty) return true;
       dirty = _vIbsTransfCredOriginal != VIbsTransfCred;
      if (dirty) return true;
       dirty = _vIbsAjusteOriginal != VIbsAjuste;
      if (dirty) return true;
       dirty = _vIbsEstornoCredOriginal != VIbsEstornoCred;
      if (dirty) return true;
       dirty = _vCredPresIbszfmOriginal != VCredPresIbszfm;

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
       if (_nfItemOriginalCommited!=null)
       {
          dirty = !_nfItemOriginalCommited.Equals(NfItem);
       }
       else
       {
            dirty = NfItem != null;
       }
      if (dirty) return true;
       dirty = _cstIbsOriginalCommited != CstIbs;
      if (dirty) return true;
       dirty = _vBaseCalcIbsOriginalCommited != VBaseCalcIbs;
      if (dirty) return true;
       dirty = _pIbsUfOriginalCommited != PIbsUf;
      if (dirty) return true;
       dirty = _compoeTotalOriginalCommited != CompoeTotal;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cClassTribOriginalCommited != CClassTrib;
      if (dirty) return true;
       dirty = _indDoacaoOriginalCommited != IndDoacao;
      if (dirty) return true;
       dirty = _pIbsMunOriginalCommited != PIbsMun;
      if (dirty) return true;
       dirty = _pDifOriginalCommited != PDif;
      if (dirty) return true;
       dirty = _pRedAliqOriginalCommited != PRedAliq;
      if (dirty) return true;
       dirty = _cstRegOriginalCommited != CstReg;
      if (dirty) return true;
       dirty = _cClassTribRegOriginalCommited != CClassTribReg;
      if (dirty) return true;
       dirty = _pAliqEfetRegIbsUfOriginalCommited != PAliqEfetRegIbsUf;
      if (dirty) return true;
       dirty = _pAliqEfetRegIbsMunOriginalCommited != PAliqEfetRegIbsMun;
      if (dirty) return true;
       dirty = _pAliqIbsUfGovOriginalCommited != PAliqIbsUfGov;
      if (dirty) return true;
       dirty = _pAliqIbsMunGovOriginalCommited != PAliqIbsMunGov;
      if (dirty) return true;
       dirty = _competApurAjusteOriginalCommited != CompetApurAjuste;
      if (dirty) return true;
       dirty = _vBcCredPresOriginalCommited != VBcCredPres;
      if (dirty) return true;
       dirty = _cCredPresOriginalCommited != CCredPres;
      if (dirty) return true;
       dirty = _pCredPresOriginalCommited != PCredPres;
      if (dirty) return true;
       dirty = _competApurZfmOriginalCommited != CompetApurZfm;
      if (dirty) return true;
       dirty = _vIbsTransfCredOriginalCommited != VIbsTransfCred;
      if (dirty) return true;
       dirty = _vIbsAjusteOriginalCommited != VIbsAjuste;
      if (dirty) return true;
       dirty = _vIbsEstornoCredOriginalCommited != VIbsEstornoCred;
      if (dirty) return true;
       dirty = _vCredPresIbszfmOriginalCommited != VCredPresIbszfm;

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
             case "NfItem":
                return this.NfItem;
             case "CstIbs":
                return this.CstIbs;
             case "VBaseCalcIbs":
                return this.VBaseCalcIbs;
             case "PIbsUf":
                return this.PIbsUf;
             case "CompoeTotal":
                return this.CompoeTotal;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "CClassTrib":
                return this.CClassTrib;
             case "IndDoacao":
                return this.IndDoacao;
             case "PIbsMun":
                return this.PIbsMun;
             case "PDif":
                return this.PDif;
             case "PRedAliq":
                return this.PRedAliq;
             case "CstReg":
                return this.CstReg;
             case "CClassTribReg":
                return this.CClassTribReg;
             case "PAliqEfetRegIbsUf":
                return this.PAliqEfetRegIbsUf;
             case "PAliqEfetRegIbsMun":
                return this.PAliqEfetRegIbsMun;
             case "PAliqIbsUfGov":
                return this.PAliqIbsUfGov;
             case "PAliqIbsMunGov":
                return this.PAliqIbsMunGov;
             case "CompetApurAjuste":
                return this.CompetApurAjuste;
             case "VBcCredPres":
                return this.VBcCredPres;
             case "CCredPres":
                return this.CCredPres;
             case "PCredPres":
                return this.PCredPres;
             case "CompetApurZfm":
                return this.CompetApurZfm;
             case "VIbsTransfCred":
                return this.VIbsTransfCred;
             case "VIbsAjuste":
                return this.VIbsAjuste;
             case "VIbsEstornoCred":
                return this.VIbsEstornoCred;
             case "VCredPresIbszfm":
                return this.VCredPresIbszfm;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfItem!=null)
                NfItem.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(nf_produto_ibs.id_nf_produto_ibs) " ;
               }
               else
               {
               command.CommandText += "nf_produto_ibs.id_nf_produto_ibs, " ;
               command.CommandText += "nf_produto_ibs.id_nf_item, " ;
               command.CommandText += "nf_produto_ibs.npb_cst_ibs, " ;
               command.CommandText += "nf_produto_ibs.npb_v_base_calc_ibs, " ;
               command.CommandText += "nf_produto_ibs.npb_p_ibs_uf, " ;
               command.CommandText += "nf_produto_ibs.npb_compoe_total, " ;
               command.CommandText += "nf_produto_ibs.version, " ;
               command.CommandText += "nf_produto_ibs.entity_uid, " ;
               command.CommandText += "nf_produto_ibs.npb_c_class_trib, " ;
               command.CommandText += "nf_produto_ibs.npb_ind_doacao, " ;
               command.CommandText += "nf_produto_ibs.npb_p_ibs_mun, " ;
               command.CommandText += "nf_produto_ibs.npb_p_dif, " ;
               command.CommandText += "nf_produto_ibs.npb_p_red_aliq, " ;
               command.CommandText += "nf_produto_ibs.npb_cst_reg, " ;
               command.CommandText += "nf_produto_ibs.npb_c_class_trib_reg, " ;
               command.CommandText += "nf_produto_ibs.npb_p_aliq_efet_reg_ibs_uf, " ;
               command.CommandText += "nf_produto_ibs.npb_p_aliq_efet_reg_ibs_mun, " ;
               command.CommandText += "nf_produto_ibs.npb_p_aliq_ibs_uf_gov, " ;
               command.CommandText += "nf_produto_ibs.npb_p_aliq_ibs_mun_gov, " ;
               command.CommandText += "nf_produto_ibs.npb_compet_apur_ajuste, " ;
               command.CommandText += "nf_produto_ibs.npb_v_bc_cred_pres, " ;
               command.CommandText += "nf_produto_ibs.npb_c_cred_pres, " ;
               command.CommandText += "nf_produto_ibs.npb_p_cred_pres, " ;
               command.CommandText += "nf_produto_ibs.npb_compet_apur_zfm, " ;
               command.CommandText += "nf_produto_ibs.npb_v_ibs_transf_cred, " ;
               command.CommandText += "nf_produto_ibs.npb_v_ibs_ajuste, " ;
               command.CommandText += "nf_produto_ibs.npb_v_ibs_estorno_cred, " ;
               command.CommandText += "nf_produto_ibs.npb_v_cred_pres_ibszfm " ;
               }
               command.CommandText += " FROM  nf_produto_ibs ";
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
                        orderByClause += " , npb_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(npb_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto_ibs.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_produto_ibs":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.id_nf_produto_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.id_nf_produto_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_produto_ibs.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "npb_cst_ibs":
                     case "CstIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ibs.npb_cst_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_cst_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_v_base_calc_ibs":
                     case "VBaseCalcIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_v_base_calc_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_v_base_calc_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_ibs_uf":
                     case "PIbsUf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_ibs_uf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_ibs_uf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_compoe_total":
                     case "CompoeTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_compoe_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_compoe_total) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto_ibs.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ibs.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ibs.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_c_class_trib":
                     case "CClassTrib":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ibs.npb_c_class_trib " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_c_class_trib) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_ind_doacao":
                     case "IndDoacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ibs.npb_ind_doacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_ind_doacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_ibs_mun":
                     case "PIbsMun":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_ibs_mun " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_ibs_mun) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_dif":
                     case "PDif":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_dif " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_dif) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_red_aliq":
                     case "PRedAliq":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_red_aliq " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_red_aliq) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_cst_reg":
                     case "CstReg":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ibs.npb_cst_reg " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_cst_reg) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_c_class_trib_reg":
                     case "CClassTribReg":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ibs.npb_c_class_trib_reg " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_c_class_trib_reg) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_aliq_efet_reg_ibs_uf":
                     case "PAliqEfetRegIbsUf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_aliq_efet_reg_ibs_uf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_aliq_efet_reg_ibs_uf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_aliq_efet_reg_ibs_mun":
                     case "PAliqEfetRegIbsMun":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_aliq_efet_reg_ibs_mun " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_aliq_efet_reg_ibs_mun) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_aliq_ibs_uf_gov":
                     case "PAliqIbsUfGov":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_aliq_ibs_uf_gov " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_aliq_ibs_uf_gov) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_aliq_ibs_mun_gov":
                     case "PAliqIbsMunGov":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_aliq_ibs_mun_gov " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_aliq_ibs_mun_gov) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_compet_apur_ajuste":
                     case "CompetApurAjuste":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ibs.npb_compet_apur_ajuste " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_compet_apur_ajuste) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_v_bc_cred_pres":
                     case "VBcCredPres":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_v_bc_cred_pres " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_v_bc_cred_pres) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_c_cred_pres":
                     case "CCredPres":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ibs.npb_c_cred_pres " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_c_cred_pres) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_cred_pres":
                     case "PCredPres":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_cred_pres " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_cred_pres) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_compet_apur_zfm":
                     case "CompetApurZfm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ibs.npb_compet_apur_zfm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_compet_apur_zfm) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_v_ibs_transf_cred":
                     case "VIbsTransfCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_v_ibs_transf_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_v_ibs_transf_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_v_ibs_ajuste":
                     case "VIbsAjuste":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_v_ibs_ajuste " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_v_ibs_ajuste) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_v_ibs_estorno_cred":
                     case "VIbsEstornoCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_v_ibs_estorno_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_v_ibs_estorno_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_v_cred_pres_ibszfm":
                     case "VCredPresIbszfm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_v_cred_pres_ibszfm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_v_cred_pres_ibszfm) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npb_cst_ibs")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ibs.npb_cst_ibs) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ibs.npb_cst_ibs) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ibs.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ibs.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npb_c_class_trib")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ibs.npb_c_class_trib) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ibs.npb_c_class_trib) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npb_ind_doacao")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ibs.npb_ind_doacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ibs.npb_ind_doacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npb_cst_reg")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ibs.npb_cst_reg) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ibs.npb_cst_reg) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npb_c_class_trib_reg")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ibs.npb_c_class_trib_reg) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ibs.npb_c_class_trib_reg) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npb_compet_apur_ajuste")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ibs.npb_compet_apur_ajuste) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ibs.npb_compet_apur_ajuste) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npb_c_cred_pres")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ibs.npb_c_cred_pres) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ibs.npb_c_cred_pres) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npb_compet_apur_zfm")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ibs.npb_compet_apur_zfm) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ibs.npb_compet_apur_zfm) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.id_nf_produto_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.id_nf_produto_ibs = :nf_produto_ibs_ID_2737 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_ID_2737", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfItem" || parametro.FieldName == "id_nf_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.id_nf_item = :nf_produto_ibs_NfItem_9735 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_NfItem_9735", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstIbs" || parametro.FieldName == "npb_cst_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_cst_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_cst_ibs LIKE :nf_produto_ibs_CstIbs_6501 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CstIbs_6501", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBaseCalcIbs" || parametro.FieldName == "npb_v_base_calc_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_v_base_calc_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_v_base_calc_ibs = :nf_produto_ibs_VBaseCalcIbs_4682 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VBaseCalcIbs_4682", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PIbsUf" || parametro.FieldName == "npb_p_ibs_uf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_ibs_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_ibs_uf = :nf_produto_ibs_PIbsUf_9463 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PIbsUf_9463", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompoeTotal" || parametro.FieldName == "npb_compoe_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_compoe_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_compoe_total = :nf_produto_ibs_CompoeTotal_9723 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CompoeTotal_9723", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_ibs.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.version = :nf_produto_ibs_Version_4512 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_Version_4512", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_ibs.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.entity_uid LIKE :nf_produto_ibs_EntityUid_3346 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_EntityUid_3346", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CClassTrib" || parametro.FieldName == "npb_c_class_trib")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_c_class_trib IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_c_class_trib LIKE :nf_produto_ibs_CClassTrib_284 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CClassTrib_284", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndDoacao" || parametro.FieldName == "npb_ind_doacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_ind_doacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_ind_doacao LIKE :nf_produto_ibs_IndDoacao_1108 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_IndDoacao_1108", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PIbsMun" || parametro.FieldName == "npb_p_ibs_mun")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_ibs_mun IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_ibs_mun = :nf_produto_ibs_PIbsMun_4894 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PIbsMun_4894", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PDif" || parametro.FieldName == "npb_p_dif")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_dif IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_dif = :nf_produto_ibs_PDif_5938 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PDif_5938", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PRedAliq" || parametro.FieldName == "npb_p_red_aliq")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_red_aliq IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_red_aliq = :nf_produto_ibs_PRedAliq_4682 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PRedAliq_4682", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstReg" || parametro.FieldName == "npb_cst_reg")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_cst_reg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_cst_reg LIKE :nf_produto_ibs_CstReg_2069 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CstReg_2069", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CClassTribReg" || parametro.FieldName == "npb_c_class_trib_reg")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_c_class_trib_reg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_c_class_trib_reg LIKE :nf_produto_ibs_CClassTribReg_1952 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CClassTribReg_1952", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PAliqEfetRegIbsUf" || parametro.FieldName == "npb_p_aliq_efet_reg_ibs_uf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_aliq_efet_reg_ibs_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_aliq_efet_reg_ibs_uf = :nf_produto_ibs_PAliqEfetRegIbsUf_7650 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PAliqEfetRegIbsUf_7650", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PAliqEfetRegIbsMun" || parametro.FieldName == "npb_p_aliq_efet_reg_ibs_mun")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_aliq_efet_reg_ibs_mun IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_aliq_efet_reg_ibs_mun = :nf_produto_ibs_PAliqEfetRegIbsMun_4346 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PAliqEfetRegIbsMun_4346", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PAliqIbsUfGov" || parametro.FieldName == "npb_p_aliq_ibs_uf_gov")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_aliq_ibs_uf_gov IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_aliq_ibs_uf_gov = :nf_produto_ibs_PAliqIbsUfGov_9506 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PAliqIbsUfGov_9506", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PAliqIbsMunGov" || parametro.FieldName == "npb_p_aliq_ibs_mun_gov")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_aliq_ibs_mun_gov IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_aliq_ibs_mun_gov = :nf_produto_ibs_PAliqIbsMunGov_1530 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PAliqIbsMunGov_1530", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompetApurAjuste" || parametro.FieldName == "npb_compet_apur_ajuste")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_compet_apur_ajuste IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_compet_apur_ajuste LIKE :nf_produto_ibs_CompetApurAjuste_8784 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CompetApurAjuste_8784", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBcCredPres" || parametro.FieldName == "npb_v_bc_cred_pres")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_v_bc_cred_pres IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_v_bc_cred_pres = :nf_produto_ibs_VBcCredPres_780 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VBcCredPres_780", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CCredPres" || parametro.FieldName == "npb_c_cred_pres")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_c_cred_pres IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_c_cred_pres LIKE :nf_produto_ibs_CCredPres_9807 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CCredPres_9807", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PCredPres" || parametro.FieldName == "npb_p_cred_pres")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_cred_pres IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_cred_pres = :nf_produto_ibs_PCredPres_9448 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PCredPres_9448", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompetApurZfm" || parametro.FieldName == "npb_compet_apur_zfm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_compet_apur_zfm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_compet_apur_zfm LIKE :nf_produto_ibs_CompetApurZfm_8005 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CompetApurZfm_8005", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsTransfCred" || parametro.FieldName == "npb_v_ibs_transf_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_transf_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_transf_cred = :nf_produto_ibs_VIbsTransfCred_3710 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VIbsTransfCred_3710", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsAjuste" || parametro.FieldName == "npb_v_ibs_ajuste")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_ajuste IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_ajuste = :nf_produto_ibs_VIbsAjuste_7278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VIbsAjuste_7278", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsEstornoCred" || parametro.FieldName == "npb_v_ibs_estorno_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_estorno_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_estorno_cred = :nf_produto_ibs_VIbsEstornoCred_8578 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VIbsEstornoCred_8578", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCredPresIbszfm" || parametro.FieldName == "npb_v_cred_pres_ibszfm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_v_cred_pres_ibszfm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_v_cred_pres_ibszfm = :nf_produto_ibs_VCredPresIbszfm_7245 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VCredPresIbszfm_7245", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstIbsExato" || parametro.FieldName == "CstIbsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_cst_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_cst_ibs LIKE :nf_produto_ibs_CstIbs_3875 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CstIbs_3875", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_ibs.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.entity_uid LIKE :nf_produto_ibs_EntityUid_9821 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_EntityUid_9821", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CClassTribExato" || parametro.FieldName == "CClassTribExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_c_class_trib IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_c_class_trib LIKE :nf_produto_ibs_CClassTrib_9454 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CClassTrib_9454", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndDoacaoExato" || parametro.FieldName == "IndDoacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_ind_doacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_ind_doacao LIKE :nf_produto_ibs_IndDoacao_23 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_IndDoacao_23", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstRegExato" || parametro.FieldName == "CstRegExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_cst_reg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_cst_reg LIKE :nf_produto_ibs_CstReg_3623 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CstReg_3623", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CClassTribRegExato" || parametro.FieldName == "CClassTribRegExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_c_class_trib_reg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_c_class_trib_reg LIKE :nf_produto_ibs_CClassTribReg_2438 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CClassTribReg_2438", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompetApurAjusteExato" || parametro.FieldName == "CompetApurAjusteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_compet_apur_ajuste IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_compet_apur_ajuste LIKE :nf_produto_ibs_CompetApurAjuste_9607 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CompetApurAjuste_9607", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CCredPresExato" || parametro.FieldName == "CCredPresExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_c_cred_pres IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_c_cred_pres LIKE :nf_produto_ibs_CCredPres_6988 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CCredPres_6988", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompetApurZfmExato" || parametro.FieldName == "CompetApurZfmExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_compet_apur_zfm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_compet_apur_zfm LIKE :nf_produto_ibs_CompetApurZfm_7168 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CompetApurZfm_7168", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoIbsClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoIbsClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoIbsClass), Convert.ToInt32(read["id_nf_produto_ibs"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoIbsClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_produto_ibs"]);
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.CstIbs = (read["npb_cst_ibs"] != DBNull.Value ? read["npb_cst_ibs"].ToString() : null);
                     entidade.VBaseCalcIbs = read["npb_v_base_calc_ibs"] as double?;
                     entidade.PIbsUf = read["npb_p_ibs_uf"] as double?;
                     entidade.CompoeTotal = Convert.ToBoolean(Convert.ToInt16(read["npb_compoe_total"]));
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.CClassTrib = (read["npb_c_class_trib"] != DBNull.Value ? read["npb_c_class_trib"].ToString() : null);
                     entidade.IndDoacao = (read["npb_ind_doacao"] != DBNull.Value ? read["npb_ind_doacao"].ToString() : null);
                     entidade.PIbsMun = read["npb_p_ibs_mun"] as double?;
                     entidade.PDif = read["npb_p_dif"] as double?;
                     entidade.PRedAliq = read["npb_p_red_aliq"] as double?;
                     entidade.CstReg = (read["npb_cst_reg"] != DBNull.Value ? read["npb_cst_reg"].ToString() : null);
                     entidade.CClassTribReg = (read["npb_c_class_trib_reg"] != DBNull.Value ? read["npb_c_class_trib_reg"].ToString() : null);
                     entidade.PAliqEfetRegIbsUf = read["npb_p_aliq_efet_reg_ibs_uf"] as double?;
                     entidade.PAliqEfetRegIbsMun = read["npb_p_aliq_efet_reg_ibs_mun"] as double?;
                     entidade.PAliqIbsUfGov = read["npb_p_aliq_ibs_uf_gov"] as double?;
                     entidade.PAliqIbsMunGov = read["npb_p_aliq_ibs_mun_gov"] as double?;
                     entidade.CompetApurAjuste = (read["npb_compet_apur_ajuste"] != DBNull.Value ? read["npb_compet_apur_ajuste"].ToString() : null);
                     entidade.VBcCredPres = read["npb_v_bc_cred_pres"] as double?;
                     entidade.CCredPres = (read["npb_c_cred_pres"] != DBNull.Value ? read["npb_c_cred_pres"].ToString() : null);
                     entidade.PCredPres = read["npb_p_cred_pres"] as double?;
                     entidade.CompetApurZfm = (read["npb_compet_apur_zfm"] != DBNull.Value ? read["npb_compet_apur_zfm"].ToString() : null);
                     entidade.VIbsTransfCred = read["npb_v_ibs_transf_cred"] as double?;
                     entidade.VIbsAjuste = read["npb_v_ibs_ajuste"] as double?;
                     entidade.VIbsEstornoCred = read["npb_v_ibs_estorno_cred"] as double?;
                     entidade.VCredPresIbszfm = read["npb_v_cred_pres_ibszfm"] as double?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoIbsClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
