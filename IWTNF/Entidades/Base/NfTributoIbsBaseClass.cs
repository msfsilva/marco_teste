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
     [Table("nf_tributo_ibs","ntb")]
     public class NfTributoIbsBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfTributoIbsClass";
protected const string ErroDelete = "Erro ao excluir o NfTributoIbsClass  ";
protected const string ErroSave = "Erro ao salvar o NfTributoIbsClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCstIbsObrigatorio = "O campo CstIbs é obrigatório";
protected const string ErroCstIbsComprimento = "O campo CstIbs deve ter no máximo 2 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfTributoIbsClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfTributoIbsClass está sendo utilizada.";
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

       protected double? _vBcIbsOriginal{get;private set;}
       private double? _vBcIbsOriginalCommited{get; set;}
        private double? _valueVBcIbs;
         [Column("ntb_v_bc_ibs")]
        public virtual double? VBcIbs
         { 
            get { return this._valueVBcIbs; } 
            set 
            { 
                if (this._valueVBcIbs == value)return;
                 this._valueVBcIbs = value; 
            } 
        } 

       protected double? _vIbsOriginal{get;private set;}
       private double? _vIbsOriginalCommited{get; set;}
        private double? _valueVIbs;
         [Column("ntb_v_ibs")]
        public virtual double? VIbs
         { 
            get { return this._valueVIbs; } 
            set 
            { 
                if (this._valueVIbs == value)return;
                 this._valueVIbs = value; 
            } 
        } 

       protected double? _vIbsDifOriginal{get;private set;}
       private double? _vIbsDifOriginalCommited{get; set;}
        private double? _valueVIbsDif;
         [Column("ntb_v_ibs_dif")]
        public virtual double? VIbsDif
         { 
            get { return this._valueVIbsDif; } 
            set 
            { 
                if (this._valueVIbsDif == value)return;
                 this._valueVIbsDif = value; 
            } 
        } 

       protected double? _vIbsDevOriginal{get;private set;}
       private double? _vIbsDevOriginalCommited{get; set;}
        private double? _valueVIbsDev;
         [Column("ntb_v_ibs_dev")]
        public virtual double? VIbsDev
         { 
            get { return this._valueVIbsDev; } 
            set 
            { 
                if (this._valueVIbsDev == value)return;
                 this._valueVIbsDev = value; 
            } 
        } 

       protected string _cstIbsOriginal{get;private set;}
       private string _cstIbsOriginalCommited{get; set;}
        private string _valueCstIbs;
         [Column("ntb_cst_ibs")]
        public virtual string CstIbs
         { 
            get { return this._valueCstIbs; } 
            set 
            { 
                if (this._valueCstIbs == value)return;
                 this._valueCstIbs = value; 
            } 
        } 

       protected double? _vIbsUfOriginal{get;private set;}
       private double? _vIbsUfOriginalCommited{get; set;}
        private double? _valueVIbsUf;
         [Column("ntb_v_ibs_uf")]
        public virtual double? VIbsUf
         { 
            get { return this._valueVIbsUf; } 
            set 
            { 
                if (this._valueVIbsUf == value)return;
                 this._valueVIbsUf = value; 
            } 
        } 

       protected double? _vIbsMunOriginal{get;private set;}
       private double? _vIbsMunOriginalCommited{get; set;}
        private double? _valueVIbsMun;
         [Column("ntb_v_ibs_mun")]
        public virtual double? VIbsMun
         { 
            get { return this._valueVIbsMun; } 
            set 
            { 
                if (this._valueVIbsMun == value)return;
                 this._valueVIbsMun = value; 
            } 
        } 

       protected double? _pAliqEfetOriginal{get;private set;}
       private double? _pAliqEfetOriginalCommited{get; set;}
        private double? _valuePAliqEfet;
         [Column("ntb_p_aliq_efet")]
        public virtual double? PAliqEfet
         { 
            get { return this._valuePAliqEfet; } 
            set 
            { 
                if (this._valuePAliqEfet == value)return;
                 this._valuePAliqEfet = value; 
            } 
        } 

       protected double? _vTribRegIbsUfOriginal{get;private set;}
       private double? _vTribRegIbsUfOriginalCommited{get; set;}
        private double? _valueVTribRegIbsUf;
         [Column("ntb_v_trib_reg_ibs_uf")]
        public virtual double? VTribRegIbsUf
         { 
            get { return this._valueVTribRegIbsUf; } 
            set 
            { 
                if (this._valueVTribRegIbsUf == value)return;
                 this._valueVTribRegIbsUf = value; 
            } 
        } 

       protected double? _vTribRegIbsMunOriginal{get;private set;}
       private double? _vTribRegIbsMunOriginalCommited{get; set;}
        private double? _valueVTribRegIbsMun;
         [Column("ntb_v_trib_reg_ibs_mun")]
        public virtual double? VTribRegIbsMun
         { 
            get { return this._valueVTribRegIbsMun; } 
            set 
            { 
                if (this._valueVTribRegIbsMun == value)return;
                 this._valueVTribRegIbsMun = value; 
            } 
        } 

       protected double? _vTribIbsUfGovOriginal{get;private set;}
       private double? _vTribIbsUfGovOriginalCommited{get; set;}
        private double? _valueVTribIbsUfGov;
         [Column("ntb_v_trib_ibs_uf_gov")]
        public virtual double? VTribIbsUfGov
         { 
            get { return this._valueVTribIbsUfGov; } 
            set 
            { 
                if (this._valueVTribIbsUfGov == value)return;
                 this._valueVTribIbsUfGov = value; 
            } 
        } 

       protected double? _vTribIbsMunGovOriginal{get;private set;}
       private double? _vTribIbsMunGovOriginalCommited{get; set;}
        private double? _valueVTribIbsMunGov;
         [Column("ntb_v_trib_ibs_mun_gov")]
        public virtual double? VTribIbsMunGov
         { 
            get { return this._valueVTribIbsMunGov; } 
            set 
            { 
                if (this._valueVTribIbsMunGov == value)return;
                 this._valueVTribIbsMunGov = value; 
            } 
        } 

       protected double? _vIbsTransfCredOriginal{get;private set;}
       private double? _vIbsTransfCredOriginalCommited{get; set;}
        private double? _valueVIbsTransfCred;
         [Column("ntb_v_ibs_transf_cred")]
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
         [Column("ntb_v_ibs_ajuste")]
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
         [Column("ntb_v_ibs_estorno_cred")]
        public virtual double? VIbsEstornoCred
         { 
            get { return this._valueVIbsEstornoCred; } 
            set 
            { 
                if (this._valueVIbsEstornoCred == value)return;
                 this._valueVIbsEstornoCred = value; 
            } 
        } 

       protected double? _vCredPresOriginal{get;private set;}
       private double? _vCredPresOriginalCommited{get; set;}
        private double? _valueVCredPres;
         [Column("ntb_v_cred_pres")]
        public virtual double? VCredPres
         { 
            get { return this._valueVCredPres; } 
            set 
            { 
                if (this._valueVCredPres == value)return;
                 this._valueVCredPres = value; 
            } 
        } 

       protected double? _vCredPresCondSusOriginal{get;private set;}
       private double? _vCredPresCondSusOriginalCommited{get; set;}
        private double? _valueVCredPresCondSus;
         [Column("ntb_v_cred_pres_cond_sus")]
        public virtual double? VCredPresCondSus
         { 
            get { return this._valueVCredPresCondSus; } 
            set 
            { 
                if (this._valueVCredPresCondSus == value)return;
                 this._valueVCredPresCondSus = value; 
            } 
        } 

       protected double? _vCredPresIbszfmOriginal{get;private set;}
       private double? _vCredPresIbszfmOriginalCommited{get; set;}
        private double? _valueVCredPresIbszfm;
         [Column("ntb_v_cred_pres_ibszfm")]
        public virtual double? VCredPresIbszfm
         { 
            get { return this._valueVCredPresIbszfm; } 
            set 
            { 
                if (this._valueVCredPresIbszfm == value)return;
                 this._valueVCredPresIbszfm = value; 
            } 
        } 

        public NfTributoIbsBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.VIbsUf = 0;
           this.VIbsMun = 0;
           this.PAliqEfet = 0;
           this.VTribRegIbsUf = 0;
           this.VTribRegIbsMun = 0;
           this.VTribIbsUfGov = 0;
           this.VTribIbsMunGov = 0;
           this.VIbsTransfCred = 0;
           this.VIbsAjuste = 0;
           this.VIbsEstornoCred = 0;
           this.VCredPres = 0;
           this.VCredPresCondSus = 0;
           this.VCredPresIbszfm = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfTributoIbsClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfTributoIbsClass) GetEntity(typeof(NfTributoIbsClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CstIbs))
                {
                    throw new Exception(ErroCstIbsObrigatorio);
                }
                if (CstIbs.Length >2)
                {
                    throw new Exception( ErroCstIbsComprimento);
                }
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
                    "  public.nf_tributo_ibs  " +
                    "WHERE " +
                    "  id_nf_tributo_ibs = :id";
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
                        "  public.nf_tributo_ibs   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  ntb_v_bc_ibs = :ntb_v_bc_ibs, " + 
                        "  ntb_v_ibs = :ntb_v_ibs, " + 
                        "  ntb_v_ibs_dif = :ntb_v_ibs_dif, " + 
                        "  ntb_v_ibs_dev = :ntb_v_ibs_dev, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  ntb_cst_ibs = :ntb_cst_ibs, " + 
                        "  ntb_v_ibs_uf = :ntb_v_ibs_uf, " + 
                        "  ntb_v_ibs_mun = :ntb_v_ibs_mun, " + 
                        "  ntb_p_aliq_efet = :ntb_p_aliq_efet, " + 
                        "  ntb_v_trib_reg_ibs_uf = :ntb_v_trib_reg_ibs_uf, " + 
                        "  ntb_v_trib_reg_ibs_mun = :ntb_v_trib_reg_ibs_mun, " + 
                        "  ntb_v_trib_ibs_uf_gov = :ntb_v_trib_ibs_uf_gov, " + 
                        "  ntb_v_trib_ibs_mun_gov = :ntb_v_trib_ibs_mun_gov, " + 
                        "  ntb_v_ibs_transf_cred = :ntb_v_ibs_transf_cred, " + 
                        "  ntb_v_ibs_ajuste = :ntb_v_ibs_ajuste, " + 
                        "  ntb_v_ibs_estorno_cred = :ntb_v_ibs_estorno_cred, " + 
                        "  ntb_v_cred_pres = :ntb_v_cred_pres, " + 
                        "  ntb_v_cred_pres_cond_sus = :ntb_v_cred_pres_cond_sus, " + 
                        "  ntb_v_cred_pres_ibszfm = :ntb_v_cred_pres_ibszfm "+
                        "WHERE  " +
                        "  id_nf_tributo_ibs = :id " +
                        "RETURNING id_nf_tributo_ibs;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_tributo_ibs " +
                        "( " +
                        "  id_nf_item , " + 
                        "  ntb_v_bc_ibs , " + 
                        "  ntb_v_ibs , " + 
                        "  ntb_v_ibs_dif , " + 
                        "  ntb_v_ibs_dev , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  ntb_cst_ibs , " + 
                        "  ntb_v_ibs_uf , " + 
                        "  ntb_v_ibs_mun , " + 
                        "  ntb_p_aliq_efet , " + 
                        "  ntb_v_trib_reg_ibs_uf , " + 
                        "  ntb_v_trib_reg_ibs_mun , " + 
                        "  ntb_v_trib_ibs_uf_gov , " + 
                        "  ntb_v_trib_ibs_mun_gov , " + 
                        "  ntb_v_ibs_transf_cred , " + 
                        "  ntb_v_ibs_ajuste , " + 
                        "  ntb_v_ibs_estorno_cred , " + 
                        "  ntb_v_cred_pres , " + 
                        "  ntb_v_cred_pres_cond_sus , " + 
                        "  ntb_v_cred_pres_ibszfm  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :ntb_v_bc_ibs , " + 
                        "  :ntb_v_ibs , " + 
                        "  :ntb_v_ibs_dif , " + 
                        "  :ntb_v_ibs_dev , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :ntb_cst_ibs , " + 
                        "  :ntb_v_ibs_uf , " + 
                        "  :ntb_v_ibs_mun , " + 
                        "  :ntb_p_aliq_efet , " + 
                        "  :ntb_v_trib_reg_ibs_uf , " + 
                        "  :ntb_v_trib_reg_ibs_mun , " + 
                        "  :ntb_v_trib_ibs_uf_gov , " + 
                        "  :ntb_v_trib_ibs_mun_gov , " + 
                        "  :ntb_v_ibs_transf_cred , " + 
                        "  :ntb_v_ibs_ajuste , " + 
                        "  :ntb_v_ibs_estorno_cred , " + 
                        "  :ntb_v_cred_pres , " + 
                        "  :ntb_v_cred_pres_cond_sus , " + 
                        "  :ntb_v_cred_pres_ibszfm  "+
                        ")RETURNING id_nf_tributo_ibs;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_bc_ibs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBcIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_dif", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsDif ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_cst_ibs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CstIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_uf", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsUf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_mun", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsMun ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_p_aliq_efet", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PAliqEfet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_trib_reg_ibs_uf", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VTribRegIbsUf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_trib_reg_ibs_mun", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VTribRegIbsMun ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_trib_ibs_uf_gov", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VTribIbsUfGov ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_trib_ibs_mun_gov", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VTribIbsMunGov ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_transf_cred", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsTransfCred ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_ajuste", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsAjuste ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_estorno_cred", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsEstornoCred ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_cred_pres", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCredPres ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_cred_pres_cond_sus", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCredPresCondSus ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_cred_pres_ibszfm", NpgsqlDbType.Double));
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
        public static NfTributoIbsClass CopiarEntidade(NfTributoIbsClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfTributoIbsClass toRet = new NfTributoIbsClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.VBcIbs= entidadeCopiar.VBcIbs;
 toRet.VIbs= entidadeCopiar.VIbs;
 toRet.VIbsDif= entidadeCopiar.VIbsDif;
 toRet.VIbsDev= entidadeCopiar.VIbsDev;
 toRet.CstIbs= entidadeCopiar.CstIbs;
 toRet.VIbsUf= entidadeCopiar.VIbsUf;
 toRet.VIbsMun= entidadeCopiar.VIbsMun;
 toRet.PAliqEfet= entidadeCopiar.PAliqEfet;
 toRet.VTribRegIbsUf= entidadeCopiar.VTribRegIbsUf;
 toRet.VTribRegIbsMun= entidadeCopiar.VTribRegIbsMun;
 toRet.VTribIbsUfGov= entidadeCopiar.VTribIbsUfGov;
 toRet.VTribIbsMunGov= entidadeCopiar.VTribIbsMunGov;
 toRet.VIbsTransfCred= entidadeCopiar.VIbsTransfCred;
 toRet.VIbsAjuste= entidadeCopiar.VIbsAjuste;
 toRet.VIbsEstornoCred= entidadeCopiar.VIbsEstornoCred;
 toRet.VCredPres= entidadeCopiar.VCredPres;
 toRet.VCredPresCondSus= entidadeCopiar.VCredPresCondSus;
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
       _vBcIbsOriginal = VBcIbs;
       _vBcIbsOriginalCommited = _vBcIbsOriginal;
       _vIbsOriginal = VIbs;
       _vIbsOriginalCommited = _vIbsOriginal;
       _vIbsDifOriginal = VIbsDif;
       _vIbsDifOriginalCommited = _vIbsDifOriginal;
       _vIbsDevOriginal = VIbsDev;
       _vIbsDevOriginalCommited = _vIbsDevOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _cstIbsOriginal = CstIbs;
       _cstIbsOriginalCommited = _cstIbsOriginal;
       _vIbsUfOriginal = VIbsUf;
       _vIbsUfOriginalCommited = _vIbsUfOriginal;
       _vIbsMunOriginal = VIbsMun;
       _vIbsMunOriginalCommited = _vIbsMunOriginal;
       _pAliqEfetOriginal = PAliqEfet;
       _pAliqEfetOriginalCommited = _pAliqEfetOriginal;
       _vTribRegIbsUfOriginal = VTribRegIbsUf;
       _vTribRegIbsUfOriginalCommited = _vTribRegIbsUfOriginal;
       _vTribRegIbsMunOriginal = VTribRegIbsMun;
       _vTribRegIbsMunOriginalCommited = _vTribRegIbsMunOriginal;
       _vTribIbsUfGovOriginal = VTribIbsUfGov;
       _vTribIbsUfGovOriginalCommited = _vTribIbsUfGovOriginal;
       _vTribIbsMunGovOriginal = VTribIbsMunGov;
       _vTribIbsMunGovOriginalCommited = _vTribIbsMunGovOriginal;
       _vIbsTransfCredOriginal = VIbsTransfCred;
       _vIbsTransfCredOriginalCommited = _vIbsTransfCredOriginal;
       _vIbsAjusteOriginal = VIbsAjuste;
       _vIbsAjusteOriginalCommited = _vIbsAjusteOriginal;
       _vIbsEstornoCredOriginal = VIbsEstornoCred;
       _vIbsEstornoCredOriginalCommited = _vIbsEstornoCredOriginal;
       _vCredPresOriginal = VCredPres;
       _vCredPresOriginalCommited = _vCredPresOriginal;
       _vCredPresCondSusOriginal = VCredPresCondSus;
       _vCredPresCondSusOriginalCommited = _vCredPresCondSusOriginal;
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
       _vBcIbsOriginalCommited = VBcIbs;
       _vIbsOriginalCommited = VIbs;
       _vIbsDifOriginalCommited = VIbsDif;
       _vIbsDevOriginalCommited = VIbsDev;
       _versionOriginalCommited = Version;
       _cstIbsOriginalCommited = CstIbs;
       _vIbsUfOriginalCommited = VIbsUf;
       _vIbsMunOriginalCommited = VIbsMun;
       _pAliqEfetOriginalCommited = PAliqEfet;
       _vTribRegIbsUfOriginalCommited = VTribRegIbsUf;
       _vTribRegIbsMunOriginalCommited = VTribRegIbsMun;
       _vTribIbsUfGovOriginalCommited = VTribIbsUfGov;
       _vTribIbsMunGovOriginalCommited = VTribIbsMunGov;
       _vIbsTransfCredOriginalCommited = VIbsTransfCred;
       _vIbsAjusteOriginalCommited = VIbsAjuste;
       _vIbsEstornoCredOriginalCommited = VIbsEstornoCred;
       _vCredPresOriginalCommited = VCredPres;
       _vCredPresCondSusOriginalCommited = VCredPresCondSus;
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
               VBcIbs=_vBcIbsOriginal;
               _vBcIbsOriginalCommited=_vBcIbsOriginal;
               VIbs=_vIbsOriginal;
               _vIbsOriginalCommited=_vIbsOriginal;
               VIbsDif=_vIbsDifOriginal;
               _vIbsDifOriginalCommited=_vIbsDifOriginal;
               VIbsDev=_vIbsDevOriginal;
               _vIbsDevOriginalCommited=_vIbsDevOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CstIbs=_cstIbsOriginal;
               _cstIbsOriginalCommited=_cstIbsOriginal;
               VIbsUf=_vIbsUfOriginal;
               _vIbsUfOriginalCommited=_vIbsUfOriginal;
               VIbsMun=_vIbsMunOriginal;
               _vIbsMunOriginalCommited=_vIbsMunOriginal;
               PAliqEfet=_pAliqEfetOriginal;
               _pAliqEfetOriginalCommited=_pAliqEfetOriginal;
               VTribRegIbsUf=_vTribRegIbsUfOriginal;
               _vTribRegIbsUfOriginalCommited=_vTribRegIbsUfOriginal;
               VTribRegIbsMun=_vTribRegIbsMunOriginal;
               _vTribRegIbsMunOriginalCommited=_vTribRegIbsMunOriginal;
               VTribIbsUfGov=_vTribIbsUfGovOriginal;
               _vTribIbsUfGovOriginalCommited=_vTribIbsUfGovOriginal;
               VTribIbsMunGov=_vTribIbsMunGovOriginal;
               _vTribIbsMunGovOriginalCommited=_vTribIbsMunGovOriginal;
               VIbsTransfCred=_vIbsTransfCredOriginal;
               _vIbsTransfCredOriginalCommited=_vIbsTransfCredOriginal;
               VIbsAjuste=_vIbsAjusteOriginal;
               _vIbsAjusteOriginalCommited=_vIbsAjusteOriginal;
               VIbsEstornoCred=_vIbsEstornoCredOriginal;
               _vIbsEstornoCredOriginalCommited=_vIbsEstornoCredOriginal;
               VCredPres=_vCredPresOriginal;
               _vCredPresOriginalCommited=_vCredPresOriginal;
               VCredPresCondSus=_vCredPresCondSusOriginal;
               _vCredPresCondSusOriginalCommited=_vCredPresCondSusOriginal;
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
       dirty = _vBcIbsOriginal != VBcIbs;
      if (dirty) return true;
       dirty = _vIbsOriginal != VIbs;
      if (dirty) return true;
       dirty = _vIbsDifOriginal != VIbsDif;
      if (dirty) return true;
       dirty = _vIbsDevOriginal != VIbsDev;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cstIbsOriginal != CstIbs;
      if (dirty) return true;
       dirty = _vIbsUfOriginal != VIbsUf;
      if (dirty) return true;
       dirty = _vIbsMunOriginal != VIbsMun;
      if (dirty) return true;
       dirty = _pAliqEfetOriginal != PAliqEfet;
      if (dirty) return true;
       dirty = _vTribRegIbsUfOriginal != VTribRegIbsUf;
      if (dirty) return true;
       dirty = _vTribRegIbsMunOriginal != VTribRegIbsMun;
      if (dirty) return true;
       dirty = _vTribIbsUfGovOriginal != VTribIbsUfGov;
      if (dirty) return true;
       dirty = _vTribIbsMunGovOriginal != VTribIbsMunGov;
      if (dirty) return true;
       dirty = _vIbsTransfCredOriginal != VIbsTransfCred;
      if (dirty) return true;
       dirty = _vIbsAjusteOriginal != VIbsAjuste;
      if (dirty) return true;
       dirty = _vIbsEstornoCredOriginal != VIbsEstornoCred;
      if (dirty) return true;
       dirty = _vCredPresOriginal != VCredPres;
      if (dirty) return true;
       dirty = _vCredPresCondSusOriginal != VCredPresCondSus;
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
       dirty = _vBcIbsOriginalCommited != VBcIbs;
      if (dirty) return true;
       dirty = _vIbsOriginalCommited != VIbs;
      if (dirty) return true;
       dirty = _vIbsDifOriginalCommited != VIbsDif;
      if (dirty) return true;
       dirty = _vIbsDevOriginalCommited != VIbsDev;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cstIbsOriginalCommited != CstIbs;
      if (dirty) return true;
       dirty = _vIbsUfOriginalCommited != VIbsUf;
      if (dirty) return true;
       dirty = _vIbsMunOriginalCommited != VIbsMun;
      if (dirty) return true;
       dirty = _pAliqEfetOriginalCommited != PAliqEfet;
      if (dirty) return true;
       dirty = _vTribRegIbsUfOriginalCommited != VTribRegIbsUf;
      if (dirty) return true;
       dirty = _vTribRegIbsMunOriginalCommited != VTribRegIbsMun;
      if (dirty) return true;
       dirty = _vTribIbsUfGovOriginalCommited != VTribIbsUfGov;
      if (dirty) return true;
       dirty = _vTribIbsMunGovOriginalCommited != VTribIbsMunGov;
      if (dirty) return true;
       dirty = _vIbsTransfCredOriginalCommited != VIbsTransfCred;
      if (dirty) return true;
       dirty = _vIbsAjusteOriginalCommited != VIbsAjuste;
      if (dirty) return true;
       dirty = _vIbsEstornoCredOriginalCommited != VIbsEstornoCred;
      if (dirty) return true;
       dirty = _vCredPresOriginalCommited != VCredPres;
      if (dirty) return true;
       dirty = _vCredPresCondSusOriginalCommited != VCredPresCondSus;
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
             case "VBcIbs":
                return this.VBcIbs;
             case "VIbs":
                return this.VIbs;
             case "VIbsDif":
                return this.VIbsDif;
             case "VIbsDev":
                return this.VIbsDev;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "CstIbs":
                return this.CstIbs;
             case "VIbsUf":
                return this.VIbsUf;
             case "VIbsMun":
                return this.VIbsMun;
             case "PAliqEfet":
                return this.PAliqEfet;
             case "VTribRegIbsUf":
                return this.VTribRegIbsUf;
             case "VTribRegIbsMun":
                return this.VTribRegIbsMun;
             case "VTribIbsUfGov":
                return this.VTribIbsUfGov;
             case "VTribIbsMunGov":
                return this.VTribIbsMunGov;
             case "VIbsTransfCred":
                return this.VIbsTransfCred;
             case "VIbsAjuste":
                return this.VIbsAjuste;
             case "VIbsEstornoCred":
                return this.VIbsEstornoCred;
             case "VCredPres":
                return this.VCredPres;
             case "VCredPresCondSus":
                return this.VCredPresCondSus;
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
                  command.CommandText += " COUNT(nf_tributo_ibs.id_nf_tributo_ibs) " ;
               }
               else
               {
               command.CommandText += "nf_tributo_ibs.id_nf_tributo_ibs, " ;
               command.CommandText += "nf_tributo_ibs.id_nf_item, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_bc_ibs, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_dif, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_dev, " ;
               command.CommandText += "nf_tributo_ibs.version, " ;
               command.CommandText += "nf_tributo_ibs.entity_uid, " ;
               command.CommandText += "nf_tributo_ibs.ntb_cst_ibs, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_uf, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_mun, " ;
               command.CommandText += "nf_tributo_ibs.ntb_p_aliq_efet, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_trib_reg_ibs_uf, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_trib_reg_ibs_mun, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_trib_ibs_uf_gov, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_trib_ibs_mun_gov, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_transf_cred, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_ajuste, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_estorno_cred, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_cred_pres, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_cred_pres_cond_sus, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_cred_pres_ibszfm " ;
               }
               command.CommandText += " FROM  nf_tributo_ibs ";
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
                        orderByClause += " , ntb_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ntb_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_tributo_ibs.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_tributo_ibs":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.id_nf_tributo_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.id_nf_tributo_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_tributo_ibs.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "ntb_v_bc_ibs":
                     case "VBcIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_bc_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_bc_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_ibs":
                     case "VIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_ibs_dif":
                     case "VIbsDif":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs_dif " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs_dif) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_ibs_dev":
                     case "VIbsDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_tributo_ibs.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_tributo_ibs.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_tributo_ibs.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_cst_ibs":
                     case "CstIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_tributo_ibs.ntb_cst_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_cst_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_ibs_uf":
                     case "VIbsUf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs_uf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs_uf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_ibs_mun":
                     case "VIbsMun":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs_mun " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs_mun) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_p_aliq_efet":
                     case "PAliqEfet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_p_aliq_efet " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_p_aliq_efet) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_trib_reg_ibs_uf":
                     case "VTribRegIbsUf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_trib_reg_ibs_uf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_trib_reg_ibs_uf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_trib_reg_ibs_mun":
                     case "VTribRegIbsMun":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_trib_reg_ibs_mun " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_trib_reg_ibs_mun) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_trib_ibs_uf_gov":
                     case "VTribIbsUfGov":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_trib_ibs_uf_gov " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_trib_ibs_uf_gov) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_trib_ibs_mun_gov":
                     case "VTribIbsMunGov":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_trib_ibs_mun_gov " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_trib_ibs_mun_gov) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_ibs_transf_cred":
                     case "VIbsTransfCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs_transf_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs_transf_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_ibs_ajuste":
                     case "VIbsAjuste":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs_ajuste " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs_ajuste) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_ibs_estorno_cred":
                     case "VIbsEstornoCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs_estorno_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs_estorno_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_cred_pres":
                     case "VCredPres":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_cred_pres " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_cred_pres) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_cred_pres_cond_sus":
                     case "VCredPresCondSus":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_cred_pres_cond_sus " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_cred_pres_cond_sus) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_cred_pres_ibszfm":
                     case "VCredPresIbszfm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_cred_pres_ibszfm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_cred_pres_ibszfm) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_tributo_ibs.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_tributo_ibs.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ntb_cst_ibs")) 
                        {
                           whereClause += " OR UPPER(nf_tributo_ibs.ntb_cst_ibs) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_tributo_ibs.ntb_cst_ibs) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_tributo_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.id_nf_tributo_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.id_nf_tributo_ibs = :nf_tributo_ibs_ID_9070 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_ID_9070", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_ibs.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.id_nf_item = :nf_tributo_ibs_NfItem_5767 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_NfItem_5767", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBcIbs" || parametro.FieldName == "ntb_v_bc_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_bc_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_bc_ibs = :nf_tributo_ibs_VBcIbs_8360 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VBcIbs_8360", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbs" || parametro.FieldName == "ntb_v_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs = :nf_tributo_ibs_VIbs_8077 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbs_8077", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsDif" || parametro.FieldName == "ntb_v_ibs_dif")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_dif IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_dif = :nf_tributo_ibs_VIbsDif_3272 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsDif_3272", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsDev" || parametro.FieldName == "ntb_v_ibs_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_dev = :nf_tributo_ibs_VIbsDev_2673 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsDev_2673", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_ibs.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.version = :nf_tributo_ibs_Version_1408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_Version_1408", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_tributo_ibs.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.entity_uid LIKE :nf_tributo_ibs_EntityUid_5634 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_EntityUid_5634", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstIbs" || parametro.FieldName == "ntb_cst_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_cst_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_cst_ibs LIKE :nf_tributo_ibs_CstIbs_2840 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_CstIbs_2840", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsUf" || parametro.FieldName == "ntb_v_ibs_uf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_uf = :nf_tributo_ibs_VIbsUf_2689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsUf_2689", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsMun" || parametro.FieldName == "ntb_v_ibs_mun")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_mun IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_mun = :nf_tributo_ibs_VIbsMun_9464 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsMun_9464", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PAliqEfet" || parametro.FieldName == "ntb_p_aliq_efet")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_p_aliq_efet IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_p_aliq_efet = :nf_tributo_ibs_PAliqEfet_349 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_PAliqEfet_349", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VTribRegIbsUf" || parametro.FieldName == "ntb_v_trib_reg_ibs_uf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_trib_reg_ibs_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_trib_reg_ibs_uf = :nf_tributo_ibs_VTribRegIbsUf_2637 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VTribRegIbsUf_2637", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VTribRegIbsMun" || parametro.FieldName == "ntb_v_trib_reg_ibs_mun")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_trib_reg_ibs_mun IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_trib_reg_ibs_mun = :nf_tributo_ibs_VTribRegIbsMun_2649 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VTribRegIbsMun_2649", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VTribIbsUfGov" || parametro.FieldName == "ntb_v_trib_ibs_uf_gov")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_trib_ibs_uf_gov IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_trib_ibs_uf_gov = :nf_tributo_ibs_VTribIbsUfGov_3605 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VTribIbsUfGov_3605", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VTribIbsMunGov" || parametro.FieldName == "ntb_v_trib_ibs_mun_gov")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_trib_ibs_mun_gov IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_trib_ibs_mun_gov = :nf_tributo_ibs_VTribIbsMunGov_5946 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VTribIbsMunGov_5946", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsTransfCred" || parametro.FieldName == "ntb_v_ibs_transf_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_transf_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_transf_cred = :nf_tributo_ibs_VIbsTransfCred_1247 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsTransfCred_1247", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsAjuste" || parametro.FieldName == "ntb_v_ibs_ajuste")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_ajuste IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_ajuste = :nf_tributo_ibs_VIbsAjuste_9157 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsAjuste_9157", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsEstornoCred" || parametro.FieldName == "ntb_v_ibs_estorno_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_estorno_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_estorno_cred = :nf_tributo_ibs_VIbsEstornoCred_8724 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsEstornoCred_8724", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCredPres" || parametro.FieldName == "ntb_v_cred_pres")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_cred_pres IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_cred_pres = :nf_tributo_ibs_VCredPres_9926 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VCredPres_9926", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCredPresCondSus" || parametro.FieldName == "ntb_v_cred_pres_cond_sus")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_cred_pres_cond_sus IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_cred_pres_cond_sus = :nf_tributo_ibs_VCredPresCondSus_322 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VCredPresCondSus_322", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCredPresIbszfm" || parametro.FieldName == "ntb_v_cred_pres_ibszfm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_cred_pres_ibszfm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_cred_pres_ibszfm = :nf_tributo_ibs_VCredPresIbszfm_989 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VCredPresIbszfm_989", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_ibs.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.entity_uid LIKE :nf_tributo_ibs_EntityUid_3632 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_EntityUid_3632", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_tributo_ibs.ntb_cst_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_cst_ibs LIKE :nf_tributo_ibs_CstIbs_9773 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_CstIbs_9773", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfTributoIbsClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfTributoIbsClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfTributoIbsClass), Convert.ToInt32(read["id_nf_tributo_ibs"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfTributoIbsClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_tributo_ibs"]);
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.VBcIbs = read["ntb_v_bc_ibs"] as double?;
                     entidade.VIbs = read["ntb_v_ibs"] as double?;
                     entidade.VIbsDif = read["ntb_v_ibs_dif"] as double?;
                     entidade.VIbsDev = read["ntb_v_ibs_dev"] as double?;
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.CstIbs = (read["ntb_cst_ibs"] != DBNull.Value ? read["ntb_cst_ibs"].ToString() : null);
                     entidade.VIbsUf = read["ntb_v_ibs_uf"] as double?;
                     entidade.VIbsMun = read["ntb_v_ibs_mun"] as double?;
                     entidade.PAliqEfet = read["ntb_p_aliq_efet"] as double?;
                     entidade.VTribRegIbsUf = read["ntb_v_trib_reg_ibs_uf"] as double?;
                     entidade.VTribRegIbsMun = read["ntb_v_trib_reg_ibs_mun"] as double?;
                     entidade.VTribIbsUfGov = read["ntb_v_trib_ibs_uf_gov"] as double?;
                     entidade.VTribIbsMunGov = read["ntb_v_trib_ibs_mun_gov"] as double?;
                     entidade.VIbsTransfCred = read["ntb_v_ibs_transf_cred"] as double?;
                     entidade.VIbsAjuste = read["ntb_v_ibs_ajuste"] as double?;
                     entidade.VIbsEstornoCred = read["ntb_v_ibs_estorno_cred"] as double?;
                     entidade.VCredPres = read["ntb_v_cred_pres"] as double?;
                     entidade.VCredPresCondSus = read["ntb_v_cred_pres_cond_sus"] as double?;
                     entidade.VCredPresIbszfm = read["ntb_v_cred_pres_ibszfm"] as double?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfTributoIbsClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
