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

       protected double? _pIbsOriginal{get;private set;}
       private double? _pIbsOriginalCommited{get; set;}
        private double? _valuePIbs;
         [Column("npb_p_ibs")]
        public virtual double? PIbs
         { 
            get { return this._valuePIbs; } 
            set 
            { 
                if (this._valuePIbs == value)return;
                 this._valuePIbs = value; 
            } 
        } 

       protected double? _vBaseCalcIbsRetOriginal{get;private set;}
       private double? _vBaseCalcIbsRetOriginalCommited{get; set;}
        private double? _valueVBaseCalcIbsRet;
         [Column("npb_v_base_calc_ibs_ret")]
        public virtual double? VBaseCalcIbsRet
         { 
            get { return this._valueVBaseCalcIbsRet; } 
            set 
            { 
                if (this._valueVBaseCalcIbsRet == value)return;
                 this._valueVBaseCalcIbsRet = value; 
            } 
        } 

       protected double? _pIbsRetOriginal{get;private set;}
       private double? _pIbsRetOriginalCommited{get; set;}
        private double? _valuePIbsRet;
         [Column("npb_p_ibs_ret")]
        public virtual double? PIbsRet
         { 
            get { return this._valuePIbsRet; } 
            set 
            { 
                if (this._valuePIbsRet == value)return;
                 this._valuePIbsRet = value; 
            } 
        } 

       protected short? _indRetIbsOriginal{get;private set;}
       private short? _indRetIbsOriginalCommited{get; set;}
        private short? _valueIndRetIbs;
         [Column("npb_ind_ret_ibs")]
        public virtual short? IndRetIbs
         { 
            get { return this._valueIndRetIbs; } 
            set 
            { 
                if (this._valueIndRetIbs == value)return;
                 this._valueIndRetIbs = value; 
            } 
        } 

       protected short? _indDifIbsOriginal{get;private set;}
       private short? _indDifIbsOriginalCommited{get; set;}
        private short? _valueIndDifIbs;
         [Column("npb_ind_dif_ibs")]
        public virtual short? IndDifIbs
         { 
            get { return this._valueIndDifIbs; } 
            set 
            { 
                if (this._valueIndDifIbs == value)return;
                 this._valueIndDifIbs = value; 
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

       protected double? _vIbsDifOriginal{get;private set;}
       private double? _vIbsDifOriginalCommited{get; set;}
        private double? _valueVIbsDif;
         [Column("npb_v_ibs_dif")]
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
         [Column("npb_v_ibs_dev")]
        public virtual double? VIbsDev
         { 
            get { return this._valueVIbsDev; } 
            set 
            { 
                if (this._valueVIbsDev == value)return;
                 this._valueVIbsDev = value; 
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
           this.VIbsDif = 0;
           this.VIbsDev = 0;
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
                        "  npb_p_ibs = :npb_p_ibs, " + 
                        "  npb_v_base_calc_ibs_ret = :npb_v_base_calc_ibs_ret, " + 
                        "  npb_p_ibs_ret = :npb_p_ibs_ret, " + 
                        "  npb_ind_ret_ibs = :npb_ind_ret_ibs, " + 
                        "  npb_ind_dif_ibs = :npb_ind_dif_ibs, " + 
                        "  npb_compoe_total = :npb_compoe_total, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  npb_v_ibs_dif = :npb_v_ibs_dif, " + 
                        "  npb_v_ibs_dev = :npb_v_ibs_dev "+
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
                        "  npb_p_ibs , " + 
                        "  npb_v_base_calc_ibs_ret , " + 
                        "  npb_p_ibs_ret , " + 
                        "  npb_ind_ret_ibs , " + 
                        "  npb_ind_dif_ibs , " + 
                        "  npb_compoe_total , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  npb_v_ibs_dif , " + 
                        "  npb_v_ibs_dev  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :npb_cst_ibs , " + 
                        "  :npb_v_base_calc_ibs , " + 
                        "  :npb_p_ibs , " + 
                        "  :npb_v_base_calc_ibs_ret , " + 
                        "  :npb_p_ibs_ret , " + 
                        "  :npb_ind_ret_ibs , " + 
                        "  :npb_ind_dif_ibs , " + 
                        "  :npb_compoe_total , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :npb_v_ibs_dif , " + 
                        "  :npb_v_ibs_dev  "+
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
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_ibs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_v_base_calc_ibs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBaseCalcIbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_p_ibs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PIbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_ind_ret_ibs", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndRetIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_ind_dif_ibs", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndDifIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_compoe_total", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompoeTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_v_ibs_dif", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsDif ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npb_v_ibs_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsDev ?? DBNull.Value;

 
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
 toRet.PIbs= entidadeCopiar.PIbs;
 toRet.VBaseCalcIbsRet= entidadeCopiar.VBaseCalcIbsRet;
 toRet.PIbsRet= entidadeCopiar.PIbsRet;
 toRet.IndRetIbs= entidadeCopiar.IndRetIbs;
 toRet.IndDifIbs= entidadeCopiar.IndDifIbs;
 toRet.CompoeTotal= entidadeCopiar.CompoeTotal;
 toRet.VIbsDif= entidadeCopiar.VIbsDif;
 toRet.VIbsDev= entidadeCopiar.VIbsDev;

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
       _pIbsOriginal = PIbs;
       _pIbsOriginalCommited = _pIbsOriginal;
       _vBaseCalcIbsRetOriginal = VBaseCalcIbsRet;
       _vBaseCalcIbsRetOriginalCommited = _vBaseCalcIbsRetOriginal;
       _pIbsRetOriginal = PIbsRet;
       _pIbsRetOriginalCommited = _pIbsRetOriginal;
       _indRetIbsOriginal = IndRetIbs;
       _indRetIbsOriginalCommited = _indRetIbsOriginal;
       _indDifIbsOriginal = IndDifIbs;
       _indDifIbsOriginalCommited = _indDifIbsOriginal;
       _compoeTotalOriginal = CompoeTotal;
       _compoeTotalOriginalCommited = _compoeTotalOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _vIbsDifOriginal = VIbsDif;
       _vIbsDifOriginalCommited = _vIbsDifOriginal;
       _vIbsDevOriginal = VIbsDev;
       _vIbsDevOriginalCommited = _vIbsDevOriginal;

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
       _pIbsOriginalCommited = PIbs;
       _vBaseCalcIbsRetOriginalCommited = VBaseCalcIbsRet;
       _pIbsRetOriginalCommited = PIbsRet;
       _indRetIbsOriginalCommited = IndRetIbs;
       _indDifIbsOriginalCommited = IndDifIbs;
       _compoeTotalOriginalCommited = CompoeTotal;
       _versionOriginalCommited = Version;
       _vIbsDifOriginalCommited = VIbsDif;
       _vIbsDevOriginalCommited = VIbsDev;

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
               PIbs=_pIbsOriginal;
               _pIbsOriginalCommited=_pIbsOriginal;
               VBaseCalcIbsRet=_vBaseCalcIbsRetOriginal;
               _vBaseCalcIbsRetOriginalCommited=_vBaseCalcIbsRetOriginal;
               PIbsRet=_pIbsRetOriginal;
               _pIbsRetOriginalCommited=_pIbsRetOriginal;
               IndRetIbs=_indRetIbsOriginal;
               _indRetIbsOriginalCommited=_indRetIbsOriginal;
               IndDifIbs=_indDifIbsOriginal;
               _indDifIbsOriginalCommited=_indDifIbsOriginal;
               CompoeTotal=_compoeTotalOriginal;
               _compoeTotalOriginalCommited=_compoeTotalOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               VIbsDif=_vIbsDifOriginal;
               _vIbsDifOriginalCommited=_vIbsDifOriginal;
               VIbsDev=_vIbsDevOriginal;
               _vIbsDevOriginalCommited=_vIbsDevOriginal;

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
       dirty = _pIbsOriginal != PIbs;
      if (dirty) return true;
       dirty = _vBaseCalcIbsRetOriginal != VBaseCalcIbsRet;
      if (dirty) return true;
       dirty = _pIbsRetOriginal != PIbsRet;
      if (dirty) return true;
       dirty = _indRetIbsOriginal != IndRetIbs;
      if (dirty) return true;
       dirty = _indDifIbsOriginal != IndDifIbs;
      if (dirty) return true;
       dirty = _compoeTotalOriginal != CompoeTotal;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _vIbsDifOriginal != VIbsDif;
      if (dirty) return true;
       dirty = _vIbsDevOriginal != VIbsDev;

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
       dirty = _pIbsOriginalCommited != PIbs;
      if (dirty) return true;
       dirty = _vBaseCalcIbsRetOriginalCommited != VBaseCalcIbsRet;
      if (dirty) return true;
       dirty = _pIbsRetOriginalCommited != PIbsRet;
      if (dirty) return true;
       dirty = _indRetIbsOriginalCommited != IndRetIbs;
      if (dirty) return true;
       dirty = _indDifIbsOriginalCommited != IndDifIbs;
      if (dirty) return true;
       dirty = _compoeTotalOriginalCommited != CompoeTotal;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _vIbsDifOriginalCommited != VIbsDif;
      if (dirty) return true;
       dirty = _vIbsDevOriginalCommited != VIbsDev;

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
             case "PIbs":
                return this.PIbs;
             case "VBaseCalcIbsRet":
                return this.VBaseCalcIbsRet;
             case "PIbsRet":
                return this.PIbsRet;
             case "IndRetIbs":
                return this.IndRetIbs;
             case "IndDifIbs":
                return this.IndDifIbs;
             case "CompoeTotal":
                return this.CompoeTotal;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "VIbsDif":
                return this.VIbsDif;
             case "VIbsDev":
                return this.VIbsDev;
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
               command.CommandText += "nf_produto_ibs.npb_p_ibs, " ;
               command.CommandText += "nf_produto_ibs.npb_v_base_calc_ibs_ret, " ;
               command.CommandText += "nf_produto_ibs.npb_p_ibs_ret, " ;
               command.CommandText += "nf_produto_ibs.npb_ind_ret_ibs, " ;
               command.CommandText += "nf_produto_ibs.npb_ind_dif_ibs, " ;
               command.CommandText += "nf_produto_ibs.npb_compoe_total, " ;
               command.CommandText += "nf_produto_ibs.version, " ;
               command.CommandText += "nf_produto_ibs.entity_uid, " ;
               command.CommandText += "nf_produto_ibs.npb_v_ibs_dif, " ;
               command.CommandText += "nf_produto_ibs.npb_v_ibs_dev " ;
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
                     case "npb_p_ibs":
                     case "PIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_v_base_calc_ibs_ret":
                     case "VBaseCalcIbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_v_base_calc_ibs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_v_base_calc_ibs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_p_ibs_ret":
                     case "PIbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_p_ibs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_p_ibs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_ind_ret_ibs":
                     case "IndRetIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_ind_ret_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_ind_ret_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_ind_dif_ibs":
                     case "IndDifIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_ind_dif_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_ind_dif_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                     case "npb_v_ibs_dif":
                     case "VIbsDif":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_v_ibs_dif " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_v_ibs_dif) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npb_v_ibs_dev":
                     case "VIbsDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ibs.npb_v_ibs_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ibs.npb_v_ibs_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                         whereClause += "  nf_produto_ibs.id_nf_produto_ibs = :nf_produto_ibs_ID_840 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_ID_840", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_ibs.id_nf_item = :nf_produto_ibs_NfItem_797 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_NfItem_797", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  nf_produto_ibs.npb_cst_ibs LIKE :nf_produto_ibs_CstIbs_3499 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CstIbs_3499", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_ibs.npb_v_base_calc_ibs = :nf_produto_ibs_VBaseCalcIbs_9786 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VBaseCalcIbs_9786", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PIbs" || parametro.FieldName == "npb_p_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_ibs = :nf_produto_ibs_PIbs_9412 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PIbs_9412", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBaseCalcIbsRet" || parametro.FieldName == "npb_v_base_calc_ibs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_v_base_calc_ibs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_v_base_calc_ibs_ret = :nf_produto_ibs_VBaseCalcIbsRet_7462 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VBaseCalcIbsRet_7462", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PIbsRet" || parametro.FieldName == "npb_p_ibs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_p_ibs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_p_ibs_ret = :nf_produto_ibs_PIbsRet_43 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_PIbsRet_43", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndRetIbs" || parametro.FieldName == "npb_ind_ret_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_ind_ret_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_ind_ret_ibs = :nf_produto_ibs_IndRetIbs_6486 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_IndRetIbs_6486", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndDifIbs" || parametro.FieldName == "npb_ind_dif_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_ind_dif_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_ind_dif_ibs = :nf_produto_ibs_IndDifIbs_8440 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_IndDifIbs_8440", NpgsqlDbType.Smallint, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_ibs.npb_compoe_total = :nf_produto_ibs_CompoeTotal_6943 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CompoeTotal_6943", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_ibs.version = :nf_produto_ibs_Version_3056 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_Version_3056", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_ibs.entity_uid LIKE :nf_produto_ibs_EntityUid_2021 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_EntityUid_2021", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsDif" || parametro.FieldName == "npb_v_ibs_dif")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_dif IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_dif = :nf_produto_ibs_VIbsDif_3112 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VIbsDif_3112", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsDev" || parametro.FieldName == "npb_v_ibs_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ibs.npb_v_ibs_dev = :nf_produto_ibs_VIbsDev_2159 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_VIbsDev_2159", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_ibs.npb_cst_ibs LIKE :nf_produto_ibs_CstIbs_4540 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_CstIbs_4540", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_ibs.entity_uid LIKE :nf_produto_ibs_EntityUid_4501 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ibs_EntityUid_4501", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                     entidade.PIbs = read["npb_p_ibs"] as double?;
                     entidade.VBaseCalcIbsRet = read["npb_v_base_calc_ibs_ret"] as double?;
                     entidade.PIbsRet = read["npb_p_ibs_ret"] as double?;
                     entidade.IndRetIbs = read["npb_ind_ret_ibs"] as short?;
                     entidade.IndDifIbs = read["npb_ind_dif_ibs"] as short?;
                     entidade.CompoeTotal = Convert.ToBoolean(Convert.ToInt16(read["npb_compoe_total"]));
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.VIbsDif = read["npb_v_ibs_dif"] as double?;
                     entidade.VIbsDev = read["npb_v_ibs_dev"] as double?;
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
