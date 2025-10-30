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

       protected double? _vBaseCalcCbsRetOriginal{get;private set;}
       private double? _vBaseCalcCbsRetOriginalCommited{get; set;}
        private double? _valueVBaseCalcCbsRet;
         [Column("nps_v_base_calc_cbs_ret")]
        public virtual double? VBaseCalcCbsRet
         { 
            get { return this._valueVBaseCalcCbsRet; } 
            set 
            { 
                if (this._valueVBaseCalcCbsRet == value)return;
                 this._valueVBaseCalcCbsRet = value; 
            } 
        } 

       protected double? _pCbsRetOriginal{get;private set;}
       private double? _pCbsRetOriginalCommited{get; set;}
        private double? _valuePCbsRet;
         [Column("nps_p_cbs_ret")]
        public virtual double? PCbsRet
         { 
            get { return this._valuePCbsRet; } 
            set 
            { 
                if (this._valuePCbsRet == value)return;
                 this._valuePCbsRet = value; 
            } 
        } 

       protected short? _indRetCbsOriginal{get;private set;}
       private short? _indRetCbsOriginalCommited{get; set;}
        private short? _valueIndRetCbs;
         [Column("nps_ind_ret_cbs")]
        public virtual short? IndRetCbs
         { 
            get { return this._valueIndRetCbs; } 
            set 
            { 
                if (this._valueIndRetCbs == value)return;
                 this._valueIndRetCbs = value; 
            } 
        } 

       protected short? _indDifCbsOriginal{get;private set;}
       private short? _indDifCbsOriginalCommited{get; set;}
        private short? _valueIndDifCbs;
         [Column("nps_ind_dif_cbs")]
        public virtual short? IndDifCbs
         { 
            get { return this._valueIndDifCbs; } 
            set 
            { 
                if (this._valueIndDifCbs == value)return;
                 this._valueIndDifCbs = value; 
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
                        "  nps_v_base_calc_cbs_ret = :nps_v_base_calc_cbs_ret, " + 
                        "  nps_p_cbs_ret = :nps_p_cbs_ret, " + 
                        "  nps_ind_ret_cbs = :nps_ind_ret_cbs, " + 
                        "  nps_ind_dif_cbs = :nps_ind_dif_cbs, " + 
                        "  nps_compoe_total = :nps_compoe_total, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
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
                        "  nps_v_base_calc_cbs_ret , " + 
                        "  nps_p_cbs_ret , " + 
                        "  nps_ind_ret_cbs , " + 
                        "  nps_ind_dif_cbs , " + 
                        "  nps_compoe_total , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :nps_cst_cbs , " + 
                        "  :nps_v_base_calc_cbs , " + 
                        "  :nps_p_cbs , " + 
                        "  :nps_v_base_calc_cbs_ret , " + 
                        "  :nps_p_cbs_ret , " + 
                        "  :nps_ind_ret_cbs , " + 
                        "  :nps_ind_dif_cbs , " + 
                        "  :nps_compoe_total , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
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
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_v_base_calc_cbs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBaseCalcCbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_p_cbs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PCbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_ind_ret_cbs", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndRetCbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_ind_dif_cbs", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndDifCbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nps_compoe_total", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompoeTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;

 
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
 toRet.VBaseCalcCbsRet= entidadeCopiar.VBaseCalcCbsRet;
 toRet.PCbsRet= entidadeCopiar.PCbsRet;
 toRet.IndRetCbs= entidadeCopiar.IndRetCbs;
 toRet.IndDifCbs= entidadeCopiar.IndDifCbs;
 toRet.CompoeTotal= entidadeCopiar.CompoeTotal;

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
       _vBaseCalcCbsRetOriginal = VBaseCalcCbsRet;
       _vBaseCalcCbsRetOriginalCommited = _vBaseCalcCbsRetOriginal;
       _pCbsRetOriginal = PCbsRet;
       _pCbsRetOriginalCommited = _pCbsRetOriginal;
       _indRetCbsOriginal = IndRetCbs;
       _indRetCbsOriginalCommited = _indRetCbsOriginal;
       _indDifCbsOriginal = IndDifCbs;
       _indDifCbsOriginalCommited = _indDifCbsOriginal;
       _compoeTotalOriginal = CompoeTotal;
       _compoeTotalOriginalCommited = _compoeTotalOriginal;
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
       _nfItemOriginalCommited = NfItem;
       _cstCbsOriginalCommited = CstCbs;
       _vBaseCalcCbsOriginalCommited = VBaseCalcCbs;
       _pCbsOriginalCommited = PCbs;
       _vBaseCalcCbsRetOriginalCommited = VBaseCalcCbsRet;
       _pCbsRetOriginalCommited = PCbsRet;
       _indRetCbsOriginalCommited = IndRetCbs;
       _indDifCbsOriginalCommited = IndDifCbs;
       _compoeTotalOriginalCommited = CompoeTotal;
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
               NfItem=_nfItemOriginal;
               _nfItemOriginalCommited=_nfItemOriginal;
               CstCbs=_cstCbsOriginal;
               _cstCbsOriginalCommited=_cstCbsOriginal;
               VBaseCalcCbs=_vBaseCalcCbsOriginal;
               _vBaseCalcCbsOriginalCommited=_vBaseCalcCbsOriginal;
               PCbs=_pCbsOriginal;
               _pCbsOriginalCommited=_pCbsOriginal;
               VBaseCalcCbsRet=_vBaseCalcCbsRetOriginal;
               _vBaseCalcCbsRetOriginalCommited=_vBaseCalcCbsRetOriginal;
               PCbsRet=_pCbsRetOriginal;
               _pCbsRetOriginalCommited=_pCbsRetOriginal;
               IndRetCbs=_indRetCbsOriginal;
               _indRetCbsOriginalCommited=_indRetCbsOriginal;
               IndDifCbs=_indDifCbsOriginal;
               _indDifCbsOriginalCommited=_indDifCbsOriginal;
               CompoeTotal=_compoeTotalOriginal;
               _compoeTotalOriginalCommited=_compoeTotalOriginal;
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
       dirty = _vBaseCalcCbsRetOriginal != VBaseCalcCbsRet;
      if (dirty) return true;
       dirty = _pCbsRetOriginal != PCbsRet;
      if (dirty) return true;
       dirty = _indRetCbsOriginal != IndRetCbs;
      if (dirty) return true;
       dirty = _indDifCbsOriginal != IndDifCbs;
      if (dirty) return true;
       dirty = _compoeTotalOriginal != CompoeTotal;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;

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
       dirty = _vBaseCalcCbsRetOriginalCommited != VBaseCalcCbsRet;
      if (dirty) return true;
       dirty = _pCbsRetOriginalCommited != PCbsRet;
      if (dirty) return true;
       dirty = _indRetCbsOriginalCommited != IndRetCbs;
      if (dirty) return true;
       dirty = _indDifCbsOriginalCommited != IndDifCbs;
      if (dirty) return true;
       dirty = _compoeTotalOriginalCommited != CompoeTotal;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;

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
             case "VBaseCalcCbsRet":
                return this.VBaseCalcCbsRet;
             case "PCbsRet":
                return this.PCbsRet;
             case "IndRetCbs":
                return this.IndRetCbs;
             case "IndDifCbs":
                return this.IndDifCbs;
             case "CompoeTotal":
                return this.CompoeTotal;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
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
               command.CommandText += "nf_produto_cbs.nps_v_base_calc_cbs_ret, " ;
               command.CommandText += "nf_produto_cbs.nps_p_cbs_ret, " ;
               command.CommandText += "nf_produto_cbs.nps_ind_ret_cbs, " ;
               command.CommandText += "nf_produto_cbs.nps_ind_dif_cbs, " ;
               command.CommandText += "nf_produto_cbs.nps_compoe_total, " ;
               command.CommandText += "nf_produto_cbs.version, " ;
               command.CommandText += "nf_produto_cbs.entity_uid " ;
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
                     case "nps_v_base_calc_cbs_ret":
                     case "VBaseCalcCbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_v_base_calc_cbs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_v_base_calc_cbs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_p_cbs_ret":
                     case "PCbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_p_cbs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_p_cbs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_ind_ret_cbs":
                     case "IndRetCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_ind_ret_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_ind_ret_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nps_ind_dif_cbs":
                     case "IndDifCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_cbs.nps_ind_dif_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_cbs.nps_ind_dif_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                         whereClause += "  nf_produto_cbs.id_nf_produto_cbs = :nf_produto_cbs_ID_6658 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_ID_6658", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_cbs.id_nf_item = :nf_produto_cbs_NfItem_9565 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_NfItem_9565", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  nf_produto_cbs.nps_cst_cbs LIKE :nf_produto_cbs_CstCbs_274 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CstCbs_274", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_cbs.nps_v_base_calc_cbs = :nf_produto_cbs_VBaseCalcCbs_1465 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_VBaseCalcCbs_1465", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_cbs.nps_p_cbs = :nf_produto_cbs_PCbs_8540 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_PCbs_8540", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBaseCalcCbsRet" || parametro.FieldName == "nps_v_base_calc_cbs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_v_base_calc_cbs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_v_base_calc_cbs_ret = :nf_produto_cbs_VBaseCalcCbsRet_9711 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_VBaseCalcCbsRet_9711", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PCbsRet" || parametro.FieldName == "nps_p_cbs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_p_cbs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_p_cbs_ret = :nf_produto_cbs_PCbsRet_3015 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_PCbsRet_3015", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndRetCbs" || parametro.FieldName == "nps_ind_ret_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_ind_ret_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_ind_ret_cbs = :nf_produto_cbs_IndRetCbs_1306 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_IndRetCbs_1306", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndDifCbs" || parametro.FieldName == "nps_ind_dif_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_cbs.nps_ind_dif_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_cbs.nps_ind_dif_cbs = :nf_produto_cbs_IndDifCbs_9140 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_IndDifCbs_9140", NpgsqlDbType.Smallint, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_cbs.nps_compoe_total = :nf_produto_cbs_CompoeTotal_5784 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CompoeTotal_5784", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_cbs.version = :nf_produto_cbs_Version_4321 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_Version_4321", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_cbs.entity_uid LIKE :nf_produto_cbs_EntityUid_4667 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_EntityUid_4667", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_cbs.nps_cst_cbs LIKE :nf_produto_cbs_CstCbs_3174 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_CstCbs_3174", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_cbs.entity_uid LIKE :nf_produto_cbs_EntityUid_6535 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_cbs_EntityUid_6535", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                     entidade.VBaseCalcCbsRet = read["nps_v_base_calc_cbs_ret"] as double?;
                     entidade.PCbsRet = read["nps_p_cbs_ret"] as double?;
                     entidade.IndRetCbs = read["nps_ind_ret_cbs"] as short?;
                     entidade.IndDifCbs = read["nps_ind_dif_cbs"] as short?;
                     entidade.CompoeTotal = Convert.ToBoolean(Convert.ToInt16(read["nps_compoe_total"]));
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
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
