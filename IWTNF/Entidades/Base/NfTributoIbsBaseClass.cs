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

       protected double? _vBcIbsRetOriginal{get;private set;}
       private double? _vBcIbsRetOriginalCommited{get; set;}
        private double? _valueVBcIbsRet;
         [Column("ntb_v_bc_ibs_ret")]
        public virtual double? VBcIbsRet
         { 
            get { return this._valueVBcIbsRet; } 
            set 
            { 
                if (this._valueVBcIbsRet == value)return;
                 this._valueVBcIbsRet = value; 
            } 
        } 

       protected double? _vIbsRetOriginal{get;private set;}
       private double? _vIbsRetOriginalCommited{get; set;}
        private double? _valueVIbsRet;
         [Column("ntb_v_ibs_ret")]
        public virtual double? VIbsRet
         { 
            get { return this._valueVIbsRet; } 
            set 
            { 
                if (this._valueVIbsRet == value)return;
                 this._valueVIbsRet = value; 
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

       protected double? _pIbsOriginal{get;private set;}
       private double? _pIbsOriginalCommited{get; set;}
        private double? _valuePIbs;
         [Column("ntb_p_ibs")]
        public virtual double? PIbs
         { 
            get { return this._valuePIbs; } 
            set 
            { 
                if (this._valuePIbs == value)return;
                 this._valuePIbs = value; 
            } 
        } 

       protected double? _vIbsCredOriginal{get;private set;}
       private double? _vIbsCredOriginalCommited{get; set;}
        private double? _valueVIbsCred;
         [Column("ntb_v_ibs_cred")]
        public virtual double? VIbsCred
         { 
            get { return this._valueVIbsCred; } 
            set 
            { 
                if (this._valueVIbsCred == value)return;
                 this._valueVIbsCred = value; 
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

        public NfTributoIbsBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.VIbsCred = 0;
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
                        "  ntb_v_bc_ibs_ret = :ntb_v_bc_ibs_ret, " + 
                        "  ntb_v_ibs_ret = :ntb_v_ibs_ret, " + 
                        "  ntb_v_ibs_dif = :ntb_v_ibs_dif, " + 
                        "  ntb_v_ibs_dev = :ntb_v_ibs_dev, " + 
                        "  ntb_p_ibs = :ntb_p_ibs, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  ntb_v_ibs_cred = :ntb_v_ibs_cred, " + 
                        "  ntb_cst_ibs = :ntb_cst_ibs "+
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
                        "  ntb_v_bc_ibs_ret , " + 
                        "  ntb_v_ibs_ret , " + 
                        "  ntb_v_ibs_dif , " + 
                        "  ntb_v_ibs_dev , " + 
                        "  ntb_p_ibs , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  ntb_v_ibs_cred , " + 
                        "  ntb_cst_ibs  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :ntb_v_bc_ibs , " + 
                        "  :ntb_v_ibs , " + 
                        "  :ntb_v_bc_ibs_ret , " + 
                        "  :ntb_v_ibs_ret , " + 
                        "  :ntb_v_ibs_dif , " + 
                        "  :ntb_v_ibs_dev , " + 
                        "  :ntb_p_ibs , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :ntb_v_ibs_cred , " + 
                        "  :ntb_cst_ibs  "+
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
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_bc_ibs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBcIbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_dif", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsDif ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_p_ibs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_v_ibs_cred", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsCred ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntb_cst_ibs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CstIbs ?? DBNull.Value;

 
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
 toRet.VBcIbsRet= entidadeCopiar.VBcIbsRet;
 toRet.VIbsRet= entidadeCopiar.VIbsRet;
 toRet.VIbsDif= entidadeCopiar.VIbsDif;
 toRet.VIbsDev= entidadeCopiar.VIbsDev;
 toRet.PIbs= entidadeCopiar.PIbs;
 toRet.VIbsCred= entidadeCopiar.VIbsCred;
 toRet.CstIbs= entidadeCopiar.CstIbs;

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
       _vBcIbsRetOriginal = VBcIbsRet;
       _vBcIbsRetOriginalCommited = _vBcIbsRetOriginal;
       _vIbsRetOriginal = VIbsRet;
       _vIbsRetOriginalCommited = _vIbsRetOriginal;
       _vIbsDifOriginal = VIbsDif;
       _vIbsDifOriginalCommited = _vIbsDifOriginal;
       _vIbsDevOriginal = VIbsDev;
       _vIbsDevOriginalCommited = _vIbsDevOriginal;
       _pIbsOriginal = PIbs;
       _pIbsOriginalCommited = _pIbsOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _vIbsCredOriginal = VIbsCred;
       _vIbsCredOriginalCommited = _vIbsCredOriginal;
       _cstIbsOriginal = CstIbs;
       _cstIbsOriginalCommited = _cstIbsOriginal;

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
       _vBcIbsRetOriginalCommited = VBcIbsRet;
       _vIbsRetOriginalCommited = VIbsRet;
       _vIbsDifOriginalCommited = VIbsDif;
       _vIbsDevOriginalCommited = VIbsDev;
       _pIbsOriginalCommited = PIbs;
       _versionOriginalCommited = Version;
       _vIbsCredOriginalCommited = VIbsCred;
       _cstIbsOriginalCommited = CstIbs;

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
               VBcIbsRet=_vBcIbsRetOriginal;
               _vBcIbsRetOriginalCommited=_vBcIbsRetOriginal;
               VIbsRet=_vIbsRetOriginal;
               _vIbsRetOriginalCommited=_vIbsRetOriginal;
               VIbsDif=_vIbsDifOriginal;
               _vIbsDifOriginalCommited=_vIbsDifOriginal;
               VIbsDev=_vIbsDevOriginal;
               _vIbsDevOriginalCommited=_vIbsDevOriginal;
               PIbs=_pIbsOriginal;
               _pIbsOriginalCommited=_pIbsOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               VIbsCred=_vIbsCredOriginal;
               _vIbsCredOriginalCommited=_vIbsCredOriginal;
               CstIbs=_cstIbsOriginal;
               _cstIbsOriginalCommited=_cstIbsOriginal;

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
       dirty = _vBcIbsRetOriginal != VBcIbsRet;
      if (dirty) return true;
       dirty = _vIbsRetOriginal != VIbsRet;
      if (dirty) return true;
       dirty = _vIbsDifOriginal != VIbsDif;
      if (dirty) return true;
       dirty = _vIbsDevOriginal != VIbsDev;
      if (dirty) return true;
       dirty = _pIbsOriginal != PIbs;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _vIbsCredOriginal != VIbsCred;
      if (dirty) return true;
       dirty = _cstIbsOriginal != CstIbs;

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
       dirty = _vBcIbsRetOriginalCommited != VBcIbsRet;
      if (dirty) return true;
       dirty = _vIbsRetOriginalCommited != VIbsRet;
      if (dirty) return true;
       dirty = _vIbsDifOriginalCommited != VIbsDif;
      if (dirty) return true;
       dirty = _vIbsDevOriginalCommited != VIbsDev;
      if (dirty) return true;
       dirty = _pIbsOriginalCommited != PIbs;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _vIbsCredOriginalCommited != VIbsCred;
      if (dirty) return true;
       dirty = _cstIbsOriginalCommited != CstIbs;

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
             case "VBcIbsRet":
                return this.VBcIbsRet;
             case "VIbsRet":
                return this.VIbsRet;
             case "VIbsDif":
                return this.VIbsDif;
             case "VIbsDev":
                return this.VIbsDev;
             case "PIbs":
                return this.PIbs;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "VIbsCred":
                return this.VIbsCred;
             case "CstIbs":
                return this.CstIbs;
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
               command.CommandText += "nf_tributo_ibs.ntb_v_bc_ibs_ret, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_ret, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_dif, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_dev, " ;
               command.CommandText += "nf_tributo_ibs.ntb_p_ibs, " ;
               command.CommandText += "nf_tributo_ibs.version, " ;
               command.CommandText += "nf_tributo_ibs.entity_uid, " ;
               command.CommandText += "nf_tributo_ibs.ntb_v_ibs_cred, " ;
               command.CommandText += "nf_tributo_ibs.ntb_cst_ibs " ;
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
                     case "ntb_v_bc_ibs_ret":
                     case "VBcIbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_bc_ibs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_bc_ibs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntb_v_ibs_ret":
                     case "VIbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                     case "ntb_p_ibs":
                     case "PIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_p_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_p_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                     case "ntb_v_ibs_cred":
                     case "VIbsCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_ibs.ntb_v_ibs_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_ibs.ntb_v_ibs_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                         whereClause += "  nf_tributo_ibs.id_nf_tributo_ibs = :nf_tributo_ibs_ID_6379 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_ID_6379", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_ibs.id_nf_item = :nf_tributo_ibs_NfItem_8702 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_NfItem_8702", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  nf_tributo_ibs.ntb_v_bc_ibs = :nf_tributo_ibs_VBcIbs_2024 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VBcIbs_2024", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs = :nf_tributo_ibs_VIbs_107 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbs_107", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBcIbsRet" || parametro.FieldName == "ntb_v_bc_ibs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_bc_ibs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_bc_ibs_ret = :nf_tributo_ibs_VBcIbsRet_1612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VBcIbsRet_1612", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsRet" || parametro.FieldName == "ntb_v_ibs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_ret = :nf_tributo_ibs_VIbsRet_8194 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsRet_8194", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_dif = :nf_tributo_ibs_VIbsDif_629 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsDif_629", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_dev = :nf_tributo_ibs_VIbsDev_2279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsDev_2279", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PIbs" || parametro.FieldName == "ntb_p_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_p_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_p_ibs = :nf_tributo_ibs_PIbs_6587 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_PIbs_6587", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_ibs.version = :nf_tributo_ibs_Version_257 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_Version_257", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_tributo_ibs.entity_uid LIKE :nf_tributo_ibs_EntityUid_9318 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_EntityUid_9318", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsCred" || parametro.FieldName == "ntb_v_ibs_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_ibs.ntb_v_ibs_cred = :nf_tributo_ibs_VIbsCred_8955 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_VIbsCred_8955", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_ibs.ntb_cst_ibs LIKE :nf_tributo_ibs_CstIbs_6214 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_CstIbs_6214", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_tributo_ibs.entity_uid LIKE :nf_tributo_ibs_EntityUid_6678 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_EntityUid_6678", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_tributo_ibs.ntb_cst_ibs LIKE :nf_tributo_ibs_CstIbs_3527 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_ibs_CstIbs_3527", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                     entidade.VBcIbsRet = read["ntb_v_bc_ibs_ret"] as double?;
                     entidade.VIbsRet = read["ntb_v_ibs_ret"] as double?;
                     entidade.VIbsDif = read["ntb_v_ibs_dif"] as double?;
                     entidade.VIbsDev = read["ntb_v_ibs_dev"] as double?;
                     entidade.PIbs = read["ntb_p_ibs"] as double?;
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.VIbsCred = read["ntb_v_ibs_cred"] as double?;
                     entidade.CstIbs = (read["ntb_cst_ibs"] != DBNull.Value ? read["ntb_cst_ibs"].ToString() : null);
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
