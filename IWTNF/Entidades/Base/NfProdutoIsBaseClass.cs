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
     [Table("nf_produto_is","npl")]
     public class NfProdutoIsBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoIsClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoIsClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoIsClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoIsClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoIsClass está sendo utilizada.";
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

       protected string _cstIsOriginal{get;private set;}
       private string _cstIsOriginalCommited{get; set;}
        private string _valueCstIs;
         [Column("npl_cst_is")]
        public virtual string CstIs
         { 
            get { return this._valueCstIs; } 
            set 
            { 
                if (this._valueCstIs == value)return;
                 this._valueCstIs = value; 
            } 
        } 

       protected double? _vBaseCalcIsOriginal{get;private set;}
       private double? _vBaseCalcIsOriginalCommited{get; set;}
        private double? _valueVBaseCalcIs;
         [Column("npl_v_base_calc_is")]
        public virtual double? VBaseCalcIs
         { 
            get { return this._valueVBaseCalcIs; } 
            set 
            { 
                if (this._valueVBaseCalcIs == value)return;
                 this._valueVBaseCalcIs = value; 
            } 
        } 

       protected double? _pIsOriginal{get;private set;}
       private double? _pIsOriginalCommited{get; set;}
        private double? _valuePIs;
         [Column("npl_p_is")]
        public virtual double? PIs
         { 
            get { return this._valuePIs; } 
            set 
            { 
                if (this._valuePIs == value)return;
                 this._valuePIs = value; 
            } 
        } 

       protected double? _vBaseCalcIsRetOriginal{get;private set;}
       private double? _vBaseCalcIsRetOriginalCommited{get; set;}
        private double? _valueVBaseCalcIsRet;
         [Column("npl_v_base_calc_is_ret")]
        public virtual double? VBaseCalcIsRet
         { 
            get { return this._valueVBaseCalcIsRet; } 
            set 
            { 
                if (this._valueVBaseCalcIsRet == value)return;
                 this._valueVBaseCalcIsRet = value; 
            } 
        } 

       protected double? _pIsRetOriginal{get;private set;}
       private double? _pIsRetOriginalCommited{get; set;}
        private double? _valuePIsRet;
         [Column("npl_p_is_ret")]
        public virtual double? PIsRet
         { 
            get { return this._valuePIsRet; } 
            set 
            { 
                if (this._valuePIsRet == value)return;
                 this._valuePIsRet = value; 
            } 
        } 

       protected short? _indIsRetOriginal{get;private set;}
       private short? _indIsRetOriginalCommited{get; set;}
        private short? _valueIndIsRet;
         [Column("npl_ind_is_ret")]
        public virtual short? IndIsRet
         { 
            get { return this._valueIndIsRet; } 
            set 
            { 
                if (this._valueIndIsRet == value)return;
                 this._valueIndIsRet = value; 
            } 
        } 

       protected short? _indSomIsOriginal{get;private set;}
       private short? _indSomIsOriginalCommited{get; set;}
        private short? _valueIndSomIs;
         [Column("npl_ind_som_is")]
        public virtual short? IndSomIs
         { 
            get { return this._valueIndSomIs; } 
            set 
            { 
                if (this._valueIndSomIs == value)return;
                 this._valueIndSomIs = value; 
            } 
        } 

       protected bool _compoeTotalOriginal{get;private set;}
       private bool _compoeTotalOriginalCommited{get; set;}
        private bool _valueCompoeTotal;
         [Column("npl_compoe_total")]
        public virtual bool CompoeTotal
         { 
            get { return this._valueCompoeTotal; } 
            set 
            { 
                if (this._valueCompoeTotal == value)return;
                 this._valueCompoeTotal = value; 
            } 
        } 

        public NfProdutoIsBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfProdutoIsClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoIsClass) GetEntity(typeof(NfProdutoIsClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_produto_is  " +
                    "WHERE " +
                    "  id_nf_produto_is = :id";
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
                        "  public.nf_produto_is   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  npl_cst_is = :npl_cst_is, " + 
                        "  npl_v_base_calc_is = :npl_v_base_calc_is, " + 
                        "  npl_p_is = :npl_p_is, " + 
                        "  npl_v_base_calc_is_ret = :npl_v_base_calc_is_ret, " + 
                        "  npl_p_is_ret = :npl_p_is_ret, " + 
                        "  npl_ind_is_ret = :npl_ind_is_ret, " + 
                        "  npl_ind_som_is = :npl_ind_som_is, " + 
                        "  npl_compoe_total = :npl_compoe_total, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_nf_produto_is = :id " +
                        "RETURNING id_nf_produto_is;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto_is " +
                        "( " +
                        "  id_nf_item , " + 
                        "  npl_cst_is , " + 
                        "  npl_v_base_calc_is , " + 
                        "  npl_p_is , " + 
                        "  npl_v_base_calc_is_ret , " + 
                        "  npl_p_is_ret , " + 
                        "  npl_ind_is_ret , " + 
                        "  npl_ind_som_is , " + 
                        "  npl_compoe_total , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :npl_cst_is , " + 
                        "  :npl_v_base_calc_is , " + 
                        "  :npl_p_is , " + 
                        "  :npl_v_base_calc_is_ret , " + 
                        "  :npl_p_is_ret , " + 
                        "  :npl_ind_is_ret , " + 
                        "  :npl_ind_som_is , " + 
                        "  :npl_compoe_total , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_nf_produto_is;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npl_cst_is", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CstIs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npl_v_base_calc_is", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBaseCalcIs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npl_p_is", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PIs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npl_v_base_calc_is_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBaseCalcIsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npl_p_is_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PIsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npl_ind_is_ret", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndIsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npl_ind_som_is", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndSomIs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npl_compoe_total", NpgsqlDbType.Smallint));
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
        public static NfProdutoIsClass CopiarEntidade(NfProdutoIsClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoIsClass toRet = new NfProdutoIsClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.CstIs= entidadeCopiar.CstIs;
 toRet.VBaseCalcIs= entidadeCopiar.VBaseCalcIs;
 toRet.PIs= entidadeCopiar.PIs;
 toRet.VBaseCalcIsRet= entidadeCopiar.VBaseCalcIsRet;
 toRet.PIsRet= entidadeCopiar.PIsRet;
 toRet.IndIsRet= entidadeCopiar.IndIsRet;
 toRet.IndSomIs= entidadeCopiar.IndSomIs;
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
       _cstIsOriginal = CstIs;
       _cstIsOriginalCommited = _cstIsOriginal;
       _vBaseCalcIsOriginal = VBaseCalcIs;
       _vBaseCalcIsOriginalCommited = _vBaseCalcIsOriginal;
       _pIsOriginal = PIs;
       _pIsOriginalCommited = _pIsOriginal;
       _vBaseCalcIsRetOriginal = VBaseCalcIsRet;
       _vBaseCalcIsRetOriginalCommited = _vBaseCalcIsRetOriginal;
       _pIsRetOriginal = PIsRet;
       _pIsRetOriginalCommited = _pIsRetOriginal;
       _indIsRetOriginal = IndIsRet;
       _indIsRetOriginalCommited = _indIsRetOriginal;
       _indSomIsOriginal = IndSomIs;
       _indSomIsOriginalCommited = _indSomIsOriginal;
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
       _cstIsOriginalCommited = CstIs;
       _vBaseCalcIsOriginalCommited = VBaseCalcIs;
       _pIsOriginalCommited = PIs;
       _vBaseCalcIsRetOriginalCommited = VBaseCalcIsRet;
       _pIsRetOriginalCommited = PIsRet;
       _indIsRetOriginalCommited = IndIsRet;
       _indSomIsOriginalCommited = IndSomIs;
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
               CstIs=_cstIsOriginal;
               _cstIsOriginalCommited=_cstIsOriginal;
               VBaseCalcIs=_vBaseCalcIsOriginal;
               _vBaseCalcIsOriginalCommited=_vBaseCalcIsOriginal;
               PIs=_pIsOriginal;
               _pIsOriginalCommited=_pIsOriginal;
               VBaseCalcIsRet=_vBaseCalcIsRetOriginal;
               _vBaseCalcIsRetOriginalCommited=_vBaseCalcIsRetOriginal;
               PIsRet=_pIsRetOriginal;
               _pIsRetOriginalCommited=_pIsRetOriginal;
               IndIsRet=_indIsRetOriginal;
               _indIsRetOriginalCommited=_indIsRetOriginal;
               IndSomIs=_indSomIsOriginal;
               _indSomIsOriginalCommited=_indSomIsOriginal;
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
       dirty = _cstIsOriginal != CstIs;
      if (dirty) return true;
       dirty = _vBaseCalcIsOriginal != VBaseCalcIs;
      if (dirty) return true;
       dirty = _pIsOriginal != PIs;
      if (dirty) return true;
       dirty = _vBaseCalcIsRetOriginal != VBaseCalcIsRet;
      if (dirty) return true;
       dirty = _pIsRetOriginal != PIsRet;
      if (dirty) return true;
       dirty = _indIsRetOriginal != IndIsRet;
      if (dirty) return true;
       dirty = _indSomIsOriginal != IndSomIs;
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
       dirty = _cstIsOriginalCommited != CstIs;
      if (dirty) return true;
       dirty = _vBaseCalcIsOriginalCommited != VBaseCalcIs;
      if (dirty) return true;
       dirty = _pIsOriginalCommited != PIs;
      if (dirty) return true;
       dirty = _vBaseCalcIsRetOriginalCommited != VBaseCalcIsRet;
      if (dirty) return true;
       dirty = _pIsRetOriginalCommited != PIsRet;
      if (dirty) return true;
       dirty = _indIsRetOriginalCommited != IndIsRet;
      if (dirty) return true;
       dirty = _indSomIsOriginalCommited != IndSomIs;
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
             case "CstIs":
                return this.CstIs;
             case "VBaseCalcIs":
                return this.VBaseCalcIs;
             case "PIs":
                return this.PIs;
             case "VBaseCalcIsRet":
                return this.VBaseCalcIsRet;
             case "PIsRet":
                return this.PIsRet;
             case "IndIsRet":
                return this.IndIsRet;
             case "IndSomIs":
                return this.IndSomIs;
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
                  command.CommandText += " COUNT(nf_produto_is.id_nf_produto_is) " ;
               }
               else
               {
               command.CommandText += "nf_produto_is.id_nf_produto_is, " ;
               command.CommandText += "nf_produto_is.id_nf_item, " ;
               command.CommandText += "nf_produto_is.npl_cst_is, " ;
               command.CommandText += "nf_produto_is.npl_v_base_calc_is, " ;
               command.CommandText += "nf_produto_is.npl_p_is, " ;
               command.CommandText += "nf_produto_is.npl_v_base_calc_is_ret, " ;
               command.CommandText += "nf_produto_is.npl_p_is_ret, " ;
               command.CommandText += "nf_produto_is.npl_ind_is_ret, " ;
               command.CommandText += "nf_produto_is.npl_ind_som_is, " ;
               command.CommandText += "nf_produto_is.npl_compoe_total, " ;
               command.CommandText += "nf_produto_is.version, " ;
               command.CommandText += "nf_produto_is.entity_uid " ;
               }
               command.CommandText += " FROM  nf_produto_is ";
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
                        orderByClause += " , npl_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(npl_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto_is.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_produto_is":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_is.id_nf_produto_is " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_is.id_nf_produto_is) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_produto_is.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "npl_cst_is":
                     case "CstIs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_is.npl_cst_is " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_is.npl_cst_is) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npl_v_base_calc_is":
                     case "VBaseCalcIs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_is.npl_v_base_calc_is " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_is.npl_v_base_calc_is) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npl_p_is":
                     case "PIs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_is.npl_p_is " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_is.npl_p_is) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npl_v_base_calc_is_ret":
                     case "VBaseCalcIsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_is.npl_v_base_calc_is_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_is.npl_v_base_calc_is_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npl_p_is_ret":
                     case "PIsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_is.npl_p_is_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_is.npl_p_is_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npl_ind_is_ret":
                     case "IndIsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_is.npl_ind_is_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_is.npl_ind_is_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npl_ind_som_is":
                     case "IndSomIs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_is.npl_ind_som_is " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_is.npl_ind_som_is) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npl_compoe_total":
                     case "CompoeTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_is.npl_compoe_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_is.npl_compoe_total) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto_is.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_is.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_is.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_is.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npl_cst_is")) 
                        {
                           whereClause += " OR UPPER(nf_produto_is.npl_cst_is) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_is.npl_cst_is) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_produto_is.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_is.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto_is")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.id_nf_produto_is IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.id_nf_produto_is = :nf_produto_is_ID_248 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_ID_248", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_is.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.id_nf_item = :nf_produto_is_NfItem_6512 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_NfItem_6512", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstIs" || parametro.FieldName == "npl_cst_is")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.npl_cst_is IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.npl_cst_is LIKE :nf_produto_is_CstIs_2112 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_CstIs_2112", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBaseCalcIs" || parametro.FieldName == "npl_v_base_calc_is")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.npl_v_base_calc_is IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.npl_v_base_calc_is = :nf_produto_is_VBaseCalcIs_5615 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_VBaseCalcIs_5615", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PIs" || parametro.FieldName == "npl_p_is")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.npl_p_is IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.npl_p_is = :nf_produto_is_PIs_779 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_PIs_779", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBaseCalcIsRet" || parametro.FieldName == "npl_v_base_calc_is_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.npl_v_base_calc_is_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.npl_v_base_calc_is_ret = :nf_produto_is_VBaseCalcIsRet_9535 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_VBaseCalcIsRet_9535", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PIsRet" || parametro.FieldName == "npl_p_is_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.npl_p_is_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.npl_p_is_ret = :nf_produto_is_PIsRet_4703 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_PIsRet_4703", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndIsRet" || parametro.FieldName == "npl_ind_is_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.npl_ind_is_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.npl_ind_is_ret = :nf_produto_is_IndIsRet_1575 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_IndIsRet_1575", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndSomIs" || parametro.FieldName == "npl_ind_som_is")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.npl_ind_som_is IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.npl_ind_som_is = :nf_produto_is_IndSomIs_8934 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_IndSomIs_8934", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompoeTotal" || parametro.FieldName == "npl_compoe_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.npl_compoe_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.npl_compoe_total = :nf_produto_is_CompoeTotal_4785 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_CompoeTotal_4785", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_is.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.version = :nf_produto_is_Version_2198 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_Version_2198", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_is.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.entity_uid LIKE :nf_produto_is_EntityUid_9580 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_EntityUid_9580", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstIsExato" || parametro.FieldName == "CstIsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_is.npl_cst_is IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.npl_cst_is LIKE :nf_produto_is_CstIs_3166 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_CstIs_3166", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_is.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_is.entity_uid LIKE :nf_produto_is_EntityUid_9775 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_is_EntityUid_9775", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoIsClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoIsClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoIsClass), Convert.ToInt32(read["id_nf_produto_is"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoIsClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_produto_is"]);
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.CstIs = (read["npl_cst_is"] != DBNull.Value ? read["npl_cst_is"].ToString() : null);
                     entidade.VBaseCalcIs = read["npl_v_base_calc_is"] as double?;
                     entidade.PIs = read["npl_p_is"] as double?;
                     entidade.VBaseCalcIsRet = read["npl_v_base_calc_is_ret"] as double?;
                     entidade.PIsRet = read["npl_p_is_ret"] as double?;
                     entidade.IndIsRet = read["npl_ind_is_ret"] as short?;
                     entidade.IndSomIs = read["npl_ind_som_is"] as short?;
                     entidade.CompoeTotal = Convert.ToBoolean(Convert.ToInt16(read["npl_compoe_total"]));
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoIsClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
