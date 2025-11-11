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
     [Table("nf_produto_cbs","nps")]
     public class NfProdutoCbsBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoCbsClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoCbsClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoCbsClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoCbsClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoCbsClass está sendo utilizada.";
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

       protected string _cstCbsOriginal{get;private set;}
       private string _cstCbsOriginalCommited{get; set;}
        private string _valueCstCbs;
         [Column("nps_cst_cbs")]
        public virtual string CstCbs
         { 
            get { return this._valueCstCbs; } 
            set 
            { 
                if (this._valueCstCbs == value)return;
                 this._valueCstCbs = value; 
            } 
        } 

       protected double? _vBaseCalcCbsOriginal{get;private set;}
       private double? _vBaseCalcCbsOriginalCommited{get; set;}
        private double? _valueVBaseCalcCbs;
         [Column("nps_v_base_calc_cbs")]
        public virtual double? VBaseCalcCbs
         { 
            get { return this._valueVBaseCalcCbs; } 
            set 
            { 
                if (this._valueVBaseCalcCbs == value)return;
                 this._valueVBaseCalcCbs = value; 
            } 
        } 

       protected double? _pCbsOriginal{get;private set;}
       private double? _pCbsOriginalCommited{get; set;}
        private double? _valuePCbs;
         [Column("nps_p_cbs")]
        public virtual double? PCbs
         { 
            get { return this._valuePCbs; } 
            set 
            { 
                if (this._valuePCbs == value)return;
                 this._valuePCbs = value; 
            } 
        } 

       protected bool _compoeTotalOriginal{get;private set;}
       private bool _compoeTotalOriginalCommited{get; set;}
        private bool _valueCompoeTotal;
         [Column("nps_compoe_total")]
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
         [Column("nps_c_class_trib")]
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
         [Column("nps_ind_doacao")]
        public virtual string IndDoacao
         { 
            get { return this._valueIndDoacao; } 
            set 
            { 
                if (this._valueIndDoacao == value)return;
                 this._valueIndDoacao = value; 
            } 
        } 

       protected double? _pDifOriginal{get;private set;}
       private double? _pDifOriginalCommited{get; set;}
        private double? _valuePDif;
         [Column("nps_p_dif")]
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
         [Column("nps_p_red_aliq")]
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
         [Column("nps_cst_reg")]
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
         [Column("nps_c_class_trib_reg")]
        public virtual string CClassTribReg
         { 
            get { return this._valueCClassTribReg; } 
            set 
            { 
                if (this._valueCClassTribReg == value)return;
                 this._valueCClassTribReg = value; 
            } 
        } 

       protected double? _pAliqEfetRegCbsOriginal{get;private set;}
       private double? _pAliqEfetRegCbsOriginalCommited{get; set;}
        private double? _valuePAliqEfetRegCbs;
         [Column("nps_p_aliq_efet_reg_cbs")]
        public virtual double? PAliqEfetRegCbs
         { 
            get { return this._valuePAliqEfetRegCbs; } 
            set 
            { 
                if (this._valuePAliqEfetRegCbs == value)return;
                 this._valuePAliqEfetRegCbs = value; 
            } 
        } 

       protected double? _pAliqCbsGovOriginal{get;private set;}
       private double? _pAliqCbsGovOriginalCommited{get; set;}
        private double? _valuePAliqCbsGov;
         [Column("nps_p_aliq_cbs_gov")]
        public virtual double? PAliqCbsGov
         { 
            get { return this._valuePAliqCbsGov; } 
            set 
            { 
                if (this._valuePAliqCbsGov == value)return;
                 this._valuePAliqCbsGov = value; 
            } 
        } 

       protected string _competApurAjusteOriginal{get;private set;}
       private string _competApurAjusteOriginalCommited{get; set;}
        private string _valueCompetApurAjuste;
         [Column("nps_compet_apur_ajuste")]
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
         [Column("nps_v_bc_cred_pres")]
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
         [Column("nps_c_cred_pres")]
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
         [Column("nps_p_cred_pres")]
        public virtual double? PCredPres
         { 
            get { return this._valuePCredPres; } 
            set 
            { 
                if (this._valuePCredPres == value)return;
                 this._valuePCredPres = value; 
            } 
        } 

       protected double? _vCbsTransfCredOriginal{get;private set;}
       private double? _vCbsTransfCredOriginalCommited{get; set;}
        private double? _valueVCbsTransfCred;
         [Column("nps_v_cbs_transf_cred")]
        public virtual double? VCbsTransfCred
         { 
            get { return this._valueVCbsTransfCred; } 
            set 
            { 
                if (this._valueVCbsTransfCred == value)return;
                 this._valueVCbsTransfCred = value; 
            } 
        } 

       protected double? _vCbsAjusteOriginal{get;private set;}
       private double? _vCbsAjusteOriginalCommited{get; set;}
        private double? _valueVCbsAjuste;
         [Column("nps_v_cbs_ajuste")]
        public virtual double? VCbsAjuste
         { 
            get { return this._valueVCbsAjuste; } 
            set 
            { 
                if (this._valueVCbsAjuste == value)return;
                 this._valueVCbsAjuste = value; 
            } 
        } 

       protected double? _vCbsEstornoCredOriginal{get;private set;}
       private double? _vCbsEstornoCredOriginalCommited{get; set;}
        private double? _valueVCbsEstornoCred;
         [Column("nps_v_cbs_estorno_cred")]
        public virtual double? VCbsEstornoCred
         { 
            get { return this._valueVCbsEstornoCred; } 
            set 
            { 
                if (this._valueVCbsEstornoCred == value)return;
                 this._valueVCbsEstornoCred = value; 
            } 
        } 

        public NfProdutoCbsBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.CompoeTotal = true;
           this.PDif = 0;
           this.PRedAliq = 0;
           this.PAliqEfetRegCbs = 0;
           this.PAliqCbsGov = 0;
           this.VBcCredPres = 0;
           this.PCredPres = 0;
           this.VCbsTransfCred = 0;
           this.VCbsAjuste = 0;
           this.VCbsEstornoCred = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfProdutoCbsClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoCbsClass) GetEntity(typeof(NfProdutoCbsClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_produto_cbs  " +
                    "WHERE " +
                    "  id_nf_produto_cbs = :id";
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
                        "  public.nf_produto_cbs   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  nps_cst_cbs = :nps_cst_cbs, " + 
                        "  nps_v_base_calc_cbs = :nps_v_base_calc_cbs, " + 
                        "  nps_p_cbs = :nps_p_cbs, " + 
                        "  nps_compoe_total = :nps_compoe_total, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  nps_c_class_trib = :nps_c_class_trib, " + 
                        "  nps_ind_doacao = :nps_ind_doacao, " + 
                        "  nps_p_dif = :nps_p_dif, " + 
                        "  nps_p_red_aliq = :nps_p_red_aliq, " + 
                        "  nps_cst_reg = :nps_cst_reg, " + 
                        "  nps_c_class_trib_reg = :nps_c_class_trib_reg, " + 
                        "  nps_p_aliq_efet_reg_cbs = :nps_p_aliq_efet_reg_cbs, " + 
                        "  nps_p_aliq_cbs_gov = :nps_p_aliq_cbs_gov, " + 
                        "  nps_compet_apur_ajuste = :nps_compet_apur_ajuste, " + 
                        "  nps_v_bc_cred_pres = :nps_v_bc_cred_pres, " + 
                        "  nps_c_cred_pres = :nps_c_cred_pres, " + 
                        "  nps_p_cred_pres = :nps_p_cred_pres, " + 
                        "  nps_v_cbs_transf_cred = :nps_v_cbs_transf_cred, " + 
                        "  nps_v_cbs_ajuste = :nps_v_cbs_ajuste, " + 
                        "  nps_v_cbs_estorno_cred = :nps_v_cbs_estorno_cred "+
                        "WHERE  " +
                        "  id_nf_produto_cbs = :id " +
                        "RETURNING id_nf_produto_cbs;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto_cbs " +
                        "( " +
                        "  id_nf_item , " + 
                        "  nps_cst_cbs , " + 
                        "  nps_v_base_calc_cbs , " + 
                        "  nps_p_cbs , " + 
                        "  nps_compoe_total , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  nps_c_class_trib , " + 
                        "  nps_ind_doacao , " + 
                        "  nps_p_dif , " + 
                        "  nps_p_red_aliq , " + 
                        "  nps_cst_reg , " + 
                        "  nps_c_class_trib_reg , " + 
                        "  nps_p_aliq_efet_reg_cbs , " + 
                        "  nps_p_aliq_cbs_gov , " + 
                        "  nps_compet_apur_ajuste , " + 
                        "  nps_v_bc_cred_pres , " + 
                        "  nps_c_cred_pres , " + 
                        "  nps_p_cred_pres , " + 
                        "  nps_v_cbs_transf_cred , " + 
                        "  nps_v_cbs_ajuste , " + 
                        "  nps_v_cbs_estorno_cred  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :nps_cst_cbs , " + 
                        "  :nps_v_base_calc_cbs , " + 
                        "  :nps_p_cbs , " + 
                        "  :nps_compoe_total , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :nps_c_class_trib , " + 
                        "  :nps_ind_doacao , " + 
                        "  :nps_p_dif , " + 
                        "  :nps_p_red_aliq , " + 
                        "  :nps_cst_reg , " + 
                        "  :nps_c_class_trib_reg , " + 
                        "  :nps_p_aliq_efet_reg_cbs , " + 
                        "  :nps_p_aliq_cbs_gov , " + 
                        "  :nps_compet_apur_ajuste , " + 
                        "  :nps_v_bc_cred_pres , " + 
                        "  :nps_c_cred_pres , " + 
                        "  :nps_p_cred_pres , " + 
                        "  :nps_v_cbs_transf_cred , " + 
                        "  :nps_v_cbs_ajuste , " + 
                        "  :nps_v_cbs_estorno_cred  "+
                        ")RETURNING id_nf_produto_cbs;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_cst_cbs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CstCbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_v_base_calc_cbs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBaseCalcCbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_p_cbs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PCbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_compoe_total", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompoeTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_c_class_trib", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CClassTrib ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_ind_doacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndDoacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_p_dif", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PDif ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_p_red_aliq", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PRedAliq ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_cst_reg", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CstReg ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_c_class_trib_reg", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CClassTribReg ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_p_aliq_efet_reg_cbs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PAliqEfetRegCbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_p_aliq_cbs_gov", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PAliqCbsGov ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_compet_apur_ajuste", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompetApurAjuste ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_v_bc_cred_pres", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBcCredPres ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_c_cred_pres", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CCredPres ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_p_cred_pres", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PCredPres ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_v_cbs_transf_cred", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsTransfCred ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_v_cbs_ajuste", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsAjuste ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_v_cbs_estorno_cred", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsEstornoCred ?? DBNull.Value;

 
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
        public static NfProdutoCbsClass CopiarEntidade(NfProdutoCbsClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoCbsClass toRet = new NfProdutoCbsClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.CstCbs= entidadeCopiar.CstCbs;
 toRet.VBaseCalcCbs= entidadeCopiar.VBaseCalcCbs;
 toRet.PCbs= entidadeCopiar.PCbs;
 toRet.CompoeTotal= entidadeCopiar.CompoeTotal;
 toRet.CClassTrib= entidadeCopiar.CClassTrib;
 toRet.IndDoacao= entidadeCopiar.IndDoacao;
 toRet.PDif= entidadeCopiar.PDif;
 toRet.PRedAliq= entidadeCopiar.PRedAliq;
 toRet.CstReg= entidadeCopiar.CstReg;
 toRet.CClassTribReg= entidadeCopiar.CClassTribReg;
 toRet.PAliqEfetRegCbs= entidadeCopiar.PAliqEfetRegCbs;
 toRet.PAliqCbsGov= entidadeCopiar.PAliqCbsGov;
 toRet.CompetApurAjuste= entidadeCopiar.CompetApurAjuste;
 toRet.VBcCredPres= entidadeCopiar.VBcCredPres;
 toRet.CCredPres= entidadeCopiar.CCredPres;
 toRet.PCredPres= entidadeCopiar.PCredPres;
 toRet.VCbsTransfCred= entidadeCopiar.VCbsTransfCred;
 toRet.VCbsAjuste= entidadeCopiar.VCbsAjuste;
 toRet.VCbsEstornoCred= entidadeCopiar.VCbsEstornoCred;

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
       _cstCbsOriginal = CstCbs;
       _cstCbsOriginalCommited = _cstCbsOriginal;
       _vBaseCalcCbsOriginal = VBaseCalcCbs;
       _vBaseCalcCbsOriginalCommited = _vBaseCalcCbsOriginal;
       _pCbsOriginal = PCbs;
       _pCbsOriginalCommited = _pCbsOriginal;
       _compoeTotalOriginal = CompoeTotal;
       _compoeTotalOriginalCommited = _compoeTotalOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _cClassTribOriginal = CClassTrib;
       _cClassTribOriginalCommited = _cClassTribOriginal;
       _indDoacaoOriginal = IndDoacao;
       _indDoacaoOriginalCommited = _indDoacaoOriginal;
       _pDifOriginal = PDif;
       _pDifOriginalCommited = _pDifOriginal;
       _pRedAliqOriginal = PRedAliq;
       _pRedAliqOriginalCommited = _pRedAliqOriginal;
       _cstRegOriginal = CstReg;
       _cstRegOriginalCommited = _cstRegOriginal;
       _cClassTribRegOriginal = CClassTribReg;
       _cClassTribRegOriginalCommited = _cClassTribRegOriginal;
       _pAliqEfetRegCbsOriginal = PAliqEfetRegCbs;
       _pAliqEfetRegCbsOriginalCommited = _pAliqEfetRegCbsOriginal;
       _pAliqCbsGovOriginal = PAliqCbsGov;
       _pAliqCbsGovOriginalCommited = _pAliqCbsGovOriginal;
       _competApurAjusteOriginal = CompetApurAjuste;
       _competApurAjusteOriginalCommited = _competApurAjusteOriginal;
       _vBcCredPresOriginal = VBcCredPres;
       _vBcCredPresOriginalCommited = _vBcCredPresOriginal;
       _cCredPresOriginal = CCredPres;
       _cCredPresOriginalCommited = _cCredPresOriginal;
       _pCredPresOriginal = PCredPres;
       _pCredPresOriginalCommited = _pCredPresOriginal;
       _vCbsTransfCredOriginal = VCbsTransfCred;
       _vCbsTransfCredOriginalCommited = _vCbsTransfCredOriginal;
       _vCbsAjusteOriginal = VCbsAjuste;
       _vCbsAjusteOriginalCommited = _vCbsAjusteOriginal;
       _vCbsEstornoCredOriginal = VCbsEstornoCred;
       _vCbsEstornoCredOriginalCommited = _vCbsEstornoCredOriginal;

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
       _cstCbsOriginalCommited = CstCbs;
       _vBaseCalcCbsOriginalCommited = VBaseCalcCbs;
       _pCbsOriginalCommited = PCbs;
       _compoeTotalOriginalCommited = CompoeTotal;
       _versionOriginalCommited = Version;
       _cClassTribOriginalCommited = CClassTrib;
       _indDoacaoOriginalCommited = IndDoacao;
       _pDifOriginalCommited = PDif;
       _pRedAliqOriginalCommited = PRedAliq;
       _cstRegOriginalCommited = CstReg;
       _cClassTribRegOriginalCommited = CClassTribReg;
       _pAliqEfetRegCbsOriginalCommited = PAliqEfetRegCbs;
       _pAliqCbsGovOriginalCommited = PAliqCbsGov;
       _competApurAjusteOriginalCommited = CompetApurAjuste;
       _vBcCredPresOriginalCommited = VBcCredPres;
       _cCredPresOriginalCommited = CCredPres;
       _pCredPresOriginalCommited = PCredPres;
       _vCbsTransfCredOriginalCommited = VCbsTransfCred;
       _vCbsAjusteOriginalCommited = VCbsAjuste;
       _vCbsEstornoCredOriginalCommited = VCbsEstornoCred;

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
               CstCbs=_cstCbsOriginal;
               _cstCbsOriginalCommited=_cstCbsOriginal;
               VBaseCalcCbs=_vBaseCalcCbsOriginal;
               _vBaseCalcCbsOriginalCommited=_vBaseCalcCbsOriginal;
               PCbs=_pCbsOriginal;
               _pCbsOriginalCommited=_pCbsOriginal;
               CompoeTotal=_compoeTotalOriginal;
               _compoeTotalOriginalCommited=_compoeTotalOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CClassTrib=_cClassTribOriginal;
               _cClassTribOriginalCommited=_cClassTribOriginal;
               IndDoacao=_indDoacaoOriginal;
               _indDoacaoOriginalCommited=_indDoacaoOriginal;
               PDif=_pDifOriginal;
               _pDifOriginalCommited=_pDifOriginal;
               PRedAliq=_pRedAliqOriginal;
               _pRedAliqOriginalCommited=_pRedAliqOriginal;
               CstReg=_cstRegOriginal;
               _cstRegOriginalCommited=_cstRegOriginal;
               CClassTribReg=_cClassTribRegOriginal;
               _cClassTribRegOriginalCommited=_cClassTribRegOriginal;
               PAliqEfetRegCbs=_pAliqEfetRegCbsOriginal;
               _pAliqEfetRegCbsOriginalCommited=_pAliqEfetRegCbsOriginal;
               PAliqCbsGov=_pAliqCbsGovOriginal;
               _pAliqCbsGovOriginalCommited=_pAliqCbsGovOriginal;
               CompetApurAjuste=_competApurAjusteOriginal;
               _competApurAjusteOriginalCommited=_competApurAjusteOriginal;
               VBcCredPres=_vBcCredPresOriginal;
               _vBcCredPresOriginalCommited=_vBcCredPresOriginal;
               CCredPres=_cCredPresOriginal;
               _cCredPresOriginalCommited=_cCredPresOriginal;
               PCredPres=_pCredPresOriginal;
               _pCredPresOriginalCommited=_pCredPresOriginal;
               VCbsTransfCred=_vCbsTransfCredOriginal;
               _vCbsTransfCredOriginalCommited=_vCbsTransfCredOriginal;
               VCbsAjuste=_vCbsAjusteOriginal;
               _vCbsAjusteOriginalCommited=_vCbsAjusteOriginal;
               VCbsEstornoCred=_vCbsEstornoCredOriginal;
               _vCbsEstornoCredOriginalCommited=_vCbsEstornoCredOriginal;

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
       dirty = _cstCbsOriginal != CstCbs;
      if (dirty) return true;
       dirty = _vBaseCalcCbsOriginal != VBaseCalcCbs;
      if (dirty) return true;
       dirty = _pCbsOriginal != PCbs;
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
       dirty = _pDifOriginal != PDif;
      if (dirty) return true;
       dirty = _pRedAliqOriginal != PRedAliq;
      if (dirty) return true;
       dirty = _cstRegOriginal != CstReg;
      if (dirty) return true;
       dirty = _cClassTribRegOriginal != CClassTribReg;
      if (dirty) return true;
       dirty = _pAliqEfetRegCbsOriginal != PAliqEfetRegCbs;
      if (dirty) return true;
       dirty = _pAliqCbsGovOriginal != PAliqCbsGov;
      if (dirty) return true;
       dirty = _competApurAjusteOriginal != CompetApurAjuste;
      if (dirty) return true;
       dirty = _vBcCredPresOriginal != VBcCredPres;
      if (dirty) return true;
       dirty = _cCredPresOriginal != CCredPres;
      if (dirty) return true;
       dirty = _pCredPresOriginal != PCredPres;
      if (dirty) return true;
       dirty = _vCbsTransfCredOriginal != VCbsTransfCred;
      if (dirty) return true;
       dirty = _vCbsAjusteOriginal != VCbsAjuste;
      if (dirty) return true;
       dirty = _vCbsEstornoCredOriginal != VCbsEstornoCred;

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
       dirty = _cstCbsOriginalCommited != CstCbs;
      if (dirty) return true;
       dirty = _vBaseCalcCbsOriginalCommited != VBaseCalcCbs;
      if (dirty) return true;
       dirty = _pCbsOriginalCommited != PCbs;
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
       dirty = _pDifOriginalCommited != PDif;
      if (dirty) return true;
       dirty = _pRedAliqOriginalCommited != PRedAliq;
      if (dirty) return true;
       dirty = _cstRegOriginalCommited != CstReg;
      if (dirty) return true;
       dirty = _cClassTribRegOriginalCommited != CClassTribReg;
      if (dirty) return true;
       dirty = _pAliqEfetRegCbsOriginalCommited != PAliqEfetRegCbs;
      if (dirty) return true;
       dirty = _pAliqCbsGovOriginalCommited != PAliqCbsGov;
      if (dirty) return true;
       dirty = _competApurAjusteOriginalCommited != CompetApurAjuste;
      if (dirty) return true;
       dirty = _vBcCredPresOriginalCommited != VBcCredPres;
      if (dirty) return true;
       dirty = _cCredPresOriginalCommited != CCredPres;
      if (dirty) return true;
       dirty = _pCredPresOriginalCommited != PCredPres;
      if (dirty) return true;
       dirty = _vCbsTransfCredOriginalCommited != VCbsTransfCred;
      if (dirty) return true;
       dirty = _vCbsAjusteOriginalCommited != VCbsAjuste;
      if (dirty) return true;
       dirty = _vCbsEstornoCredOriginalCommited != VCbsEstornoCred;

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
             case "CstCbs":
                return this.CstCbs;
             case "VBaseCalcCbs":
                return this.VBaseCalcCbs;
             case "PCbs":
                return this.PCbs;
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
             case "PDif":
                return this.PDif;
             case "PRedAliq":
                return this.PRedAliq;
             case "CstReg":
                return this.CstReg;
             case "CClassTribReg":
                return this.CClassTribReg;
             case "PAliqEfetRegCbs":
                return this.PAliqEfetRegCbs;
             case "PAliqCbsGov":
                return this.PAliqCbsGov;
             case "CompetApurAjuste":
                return this.CompetApurAjuste;
             case "VBcCredPres":
                return this.VBcCredPres;
             case "CCredPres":
                return this.CCredPres;
             case "PCredPres":
                return this.PCredPres;
             case "VCbsTransfCred":
                return this.VCbsTransfCred;
             case "VCbsAjuste":
                return this.VCbsAjuste;
             case "VCbsEstornoCred":
                return this.VCbsEstornoCred;
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
                  command.CommandText += " COUNT(nf_produto_cbs.id_nf_produto_cbs) " ;
               }
               else
               {
               command.CommandText += "nf_produto_cbs.id_nf_produto_cbs, " ;
               command.CommandText += "nf_produto_cbs.id_nf_item, " ;
               command.CommandText += "nf_produto_cbs.nps_cst_cbs, " ;
               command.CommandText += "nf_produto_cbs.nps_v_base_calc_cbs, " ;
               command.CommandText += "nf_produto_cbs.nps_p_cbs, " ;
               command.CommandText += "nf_produto_cbs.nps_compoe_total, " ;
               command.CommandText += "nf_produto_cbs.version, " ;
               command.CommandText += "nf_produto_cbs.entity_uid, " ;
               command.CommandText += "nf_produto_cbs.nps_c_class_trib, " ;
               command.CommandText += "nf_produto_cbs.nps_ind_doacao, " ;
               command.CommandText += "nf_produto_cbs.nps_p_dif, " ;
               command.CommandText += "nf_produto_cbs.nps_p_red_aliq, " ;
               command.CommandText += "nf_produto_cbs.nps_cst_reg, " ;
               command.CommandText += "nf_produto_cbs.nps_c_class_trib_reg, " ;
               command.CommandText += "nf_produto_cbs.nps_p_aliq_efet_reg_cbs, " ;
               command.CommandText += "nf_produto_cbs.nps_p_aliq_cbs_gov, " ;
               command.CommandText += "nf_produto_cbs.nps_compet_apur_ajuste, " ;
               command.CommandText += "nf_produto_cbs.nps_v_bc_cred_pres, " ;
               command.CommandText += "nf_produto_cbs.nps_c_cred_pres, " ;
               command.CommandText += "nf_produto_cbs.nps_p_cred_pres, " ;
               command.CommandText += "nf_produto_cbs.nps_v_cbs_transf_cred, " ;
               command.CommandText += "nf_produto_cbs.nps_v_cbs_ajuste, " ;
               command.CommandText += "nf_produto_cbs.nps_v_cbs_estorno_cred " ;
               }
               command.CommandText += " FROM  nf_produto_cbs ";
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
                        orderByClause += " , nps_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nps_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto_cbs.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_produto_cbs":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.id_nf_produto_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.id_nf_produto_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_produto_cbs.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "nps_cst_cbs":
                     case "CstCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_cbs.nps_cst_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_cst_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_v_base_calc_cbs":
                     case "VBaseCalcCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_v_base_calc_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_v_base_calc_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_p_cbs":
                     case "PCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_p_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_p_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_compoe_total":
                     case "CompoeTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_compoe_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_compoe_total) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto_cbs.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_cbs.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_cbs.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_c_class_trib":
                     case "CClassTrib":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_cbs.nps_c_class_trib " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_c_class_trib) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_ind_doacao":
                     case "IndDoacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_cbs.nps_ind_doacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_ind_doacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_p_dif":
                     case "PDif":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_p_dif " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_p_dif) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_p_red_aliq":
                     case "PRedAliq":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_p_red_aliq " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_p_red_aliq) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_cst_reg":
                     case "CstReg":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_cbs.nps_cst_reg " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_cst_reg) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_c_class_trib_reg":
                     case "CClassTribReg":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_cbs.nps_c_class_trib_reg " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_c_class_trib_reg) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_p_aliq_efet_reg_cbs":
                     case "PAliqEfetRegCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_p_aliq_efet_reg_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_p_aliq_efet_reg_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_p_aliq_cbs_gov":
                     case "PAliqCbsGov":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_p_aliq_cbs_gov " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_p_aliq_cbs_gov) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_compet_apur_ajuste":
                     case "CompetApurAjuste":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_cbs.nps_compet_apur_ajuste " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_compet_apur_ajuste) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_v_bc_cred_pres":
                     case "VBcCredPres":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_v_bc_cred_pres " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_v_bc_cred_pres) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_c_cred_pres":
                     case "CCredPres":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_cbs.nps_c_cred_pres " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_c_cred_pres) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_p_cred_pres":
                     case "PCredPres":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_p_cred_pres " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_p_cred_pres) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_v_cbs_transf_cred":
                     case "VCbsTransfCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_v_cbs_transf_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_v_cbs_transf_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_v_cbs_ajuste":
                     case "VCbsAjuste":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_v_cbs_ajuste " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_v_cbs_ajuste) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_v_cbs_estorno_cred":
                     case "VCbsEstornoCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_v_cbs_estorno_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_v_cbs_estorno_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nps_cst_cbs")) 
                        {
                           whereClause += " OR UPPER(nf_produto_cbs.nps_cst_cbs) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_cbs.nps_cst_cbs) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_produto_cbs.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_cbs.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nps_c_class_trib")) 
                        {
                           whereClause += " OR UPPER(nf_produto_cbs.nps_c_class_trib) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_cbs.nps_c_class_trib) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nps_ind_doacao")) 
                        {
                           whereClause += " OR UPPER(nf_produto_cbs.nps_ind_doacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_cbs.nps_ind_doacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nps_cst_reg")) 
                        {
                           whereClause += " OR UPPER(nf_produto_cbs.nps_cst_reg) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_cbs.nps_cst_reg) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nps_c_class_trib_reg")) 
                        {
                           whereClause += " OR UPPER(nf_produto_cbs.nps_c_class_trib_reg) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_cbs.nps_c_class_trib_reg) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nps_compet_apur_ajuste")) 
                        {
                           whereClause += " OR UPPER(nf_produto_cbs.nps_compet_apur_ajuste) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_cbs.nps_compet_apur_ajuste) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nps_c_cred_pres")) 
                        {
                           whereClause += " OR UPPER(nf_produto_cbs.nps_c_cred_pres) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_cbs.nps_c_cred_pres) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.id_nf_produto_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.id_nf_produto_cbs = :nf_produto_cbs_ID_4307 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_ID_4307", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_cbs.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.id_nf_item = :nf_produto_cbs_NfItem_2170 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_NfItem_2170", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstCbs" || parametro.FieldName == "nps_cst_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_cst_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_cst_cbs LIKE :nf_produto_cbs_CstCbs_1158 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CstCbs_1158", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBaseCalcCbs" || parametro.FieldName == "nps_v_base_calc_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_v_base_calc_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_v_base_calc_cbs = :nf_produto_cbs_VBaseCalcCbs_5515 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_VBaseCalcCbs_5515", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PCbs" || parametro.FieldName == "nps_p_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_p_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_p_cbs = :nf_produto_cbs_PCbs_1190 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_PCbs_1190", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompoeTotal" || parametro.FieldName == "nps_compoe_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_compoe_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_compoe_total = :nf_produto_cbs_CompoeTotal_8149 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CompoeTotal_8149", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_cbs.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.version = :nf_produto_cbs_Version_6942 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_Version_6942", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_cbs.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.entity_uid LIKE :nf_produto_cbs_EntityUid_9513 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_EntityUid_9513", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CClassTrib" || parametro.FieldName == "nps_c_class_trib")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_c_class_trib IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_c_class_trib LIKE :nf_produto_cbs_CClassTrib_2720 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CClassTrib_2720", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndDoacao" || parametro.FieldName == "nps_ind_doacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_ind_doacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_ind_doacao LIKE :nf_produto_cbs_IndDoacao_5015 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_IndDoacao_5015", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PDif" || parametro.FieldName == "nps_p_dif")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_p_dif IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_p_dif = :nf_produto_cbs_PDif_9404 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_PDif_9404", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PRedAliq" || parametro.FieldName == "nps_p_red_aliq")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_p_red_aliq IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_p_red_aliq = :nf_produto_cbs_PRedAliq_4366 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_PRedAliq_4366", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstReg" || parametro.FieldName == "nps_cst_reg")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_cst_reg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_cst_reg LIKE :nf_produto_cbs_CstReg_918 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CstReg_918", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CClassTribReg" || parametro.FieldName == "nps_c_class_trib_reg")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_c_class_trib_reg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_c_class_trib_reg LIKE :nf_produto_cbs_CClassTribReg_3444 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CClassTribReg_3444", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PAliqEfetRegCbs" || parametro.FieldName == "nps_p_aliq_efet_reg_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_p_aliq_efet_reg_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_p_aliq_efet_reg_cbs = :nf_produto_cbs_PAliqEfetRegCbs_7063 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_PAliqEfetRegCbs_7063", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PAliqCbsGov" || parametro.FieldName == "nps_p_aliq_cbs_gov")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_p_aliq_cbs_gov IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_p_aliq_cbs_gov = :nf_produto_cbs_PAliqCbsGov_2960 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_PAliqCbsGov_2960", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompetApurAjuste" || parametro.FieldName == "nps_compet_apur_ajuste")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_compet_apur_ajuste IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_compet_apur_ajuste LIKE :nf_produto_cbs_CompetApurAjuste_591 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CompetApurAjuste_591", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBcCredPres" || parametro.FieldName == "nps_v_bc_cred_pres")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_v_bc_cred_pres IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_v_bc_cred_pres = :nf_produto_cbs_VBcCredPres_3627 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_VBcCredPres_3627", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CCredPres" || parametro.FieldName == "nps_c_cred_pres")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_c_cred_pres IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_c_cred_pres LIKE :nf_produto_cbs_CCredPres_7283 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CCredPres_7283", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PCredPres" || parametro.FieldName == "nps_p_cred_pres")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_p_cred_pres IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_p_cred_pres = :nf_produto_cbs_PCredPres_7728 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_PCredPres_7728", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsTransfCred" || parametro.FieldName == "nps_v_cbs_transf_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_v_cbs_transf_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_v_cbs_transf_cred = :nf_produto_cbs_VCbsTransfCred_3444 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_VCbsTransfCred_3444", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsAjuste" || parametro.FieldName == "nps_v_cbs_ajuste")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_v_cbs_ajuste IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_v_cbs_ajuste = :nf_produto_cbs_VCbsAjuste_483 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_VCbsAjuste_483", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsEstornoCred" || parametro.FieldName == "nps_v_cbs_estorno_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_v_cbs_estorno_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_v_cbs_estorno_cred = :nf_produto_cbs_VCbsEstornoCred_435 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_VCbsEstornoCred_435", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstCbsExato" || parametro.FieldName == "CstCbsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_cst_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_cst_cbs LIKE :nf_produto_cbs_CstCbs_4869 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CstCbs_4869", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_cbs.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.entity_uid LIKE :nf_produto_cbs_EntityUid_4525 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_EntityUid_4525", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_cbs.nps_c_class_trib IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_c_class_trib LIKE :nf_produto_cbs_CClassTrib_4748 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CClassTrib_4748", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_cbs.nps_ind_doacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_ind_doacao LIKE :nf_produto_cbs_IndDoacao_5378 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_IndDoacao_5378", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_cbs.nps_cst_reg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_cst_reg LIKE :nf_produto_cbs_CstReg_3338 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CstReg_3338", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_cbs.nps_c_class_trib_reg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_c_class_trib_reg LIKE :nf_produto_cbs_CClassTribReg_631 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CClassTribReg_631", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_cbs.nps_compet_apur_ajuste IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_compet_apur_ajuste LIKE :nf_produto_cbs_CompetApurAjuste_2182 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CompetApurAjuste_2182", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_cbs.nps_c_cred_pres IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_c_cred_pres LIKE :nf_produto_cbs_CCredPres_6405 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CCredPres_6405", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoCbsClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoCbsClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoCbsClass), Convert.ToInt32(read["id_nf_produto_cbs"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoCbsClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_produto_cbs"]);
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.CstCbs = (read["nps_cst_cbs"] != DBNull.Value ? read["nps_cst_cbs"].ToString() : null);
                     entidade.VBaseCalcCbs = read["nps_v_base_calc_cbs"] as double?;
                     entidade.PCbs = read["nps_p_cbs"] as double?;
                     entidade.CompoeTotal = Convert.ToBoolean(Convert.ToInt16(read["nps_compoe_total"]));
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.CClassTrib = (read["nps_c_class_trib"] != DBNull.Value ? read["nps_c_class_trib"].ToString() : null);
                     entidade.IndDoacao = (read["nps_ind_doacao"] != DBNull.Value ? read["nps_ind_doacao"].ToString() : null);
                     entidade.PDif = read["nps_p_dif"] as double?;
                     entidade.PRedAliq = read["nps_p_red_aliq"] as double?;
                     entidade.CstReg = (read["nps_cst_reg"] != DBNull.Value ? read["nps_cst_reg"].ToString() : null);
                     entidade.CClassTribReg = (read["nps_c_class_trib_reg"] != DBNull.Value ? read["nps_c_class_trib_reg"].ToString() : null);
                     entidade.PAliqEfetRegCbs = read["nps_p_aliq_efet_reg_cbs"] as double?;
                     entidade.PAliqCbsGov = read["nps_p_aliq_cbs_gov"] as double?;
                     entidade.CompetApurAjuste = (read["nps_compet_apur_ajuste"] != DBNull.Value ? read["nps_compet_apur_ajuste"].ToString() : null);
                     entidade.VBcCredPres = read["nps_v_bc_cred_pres"] as double?;
                     entidade.CCredPres = (read["nps_c_cred_pres"] != DBNull.Value ? read["nps_c_cred_pres"].ToString() : null);
                     entidade.PCredPres = read["nps_p_cred_pres"] as double?;
                     entidade.VCbsTransfCred = read["nps_v_cbs_transf_cred"] as double?;
                     entidade.VCbsAjuste = read["nps_v_cbs_ajuste"] as double?;
                     entidade.VCbsEstornoCred = read["nps_v_cbs_estorno_cred"] as double?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoCbsClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
