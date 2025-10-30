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
     [Table("nf_tributo_devolucao","ntv")]
     public class NfTributoDevolucaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfTributoDevolucaoClass";
protected const string ErroDelete = "Erro ao excluir o NfTributoDevolucaoClass  ";
protected const string ErroSave = "Erro ao salvar o NfTributoDevolucaoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfTributoDevolucaoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfTributoDevolucaoClass está sendo utilizada.";
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

       protected double? _vIpiDevOriginal{get;private set;}
       private double? _vIpiDevOriginalCommited{get; set;}
        private double? _valueVIpiDev;
         [Column("ntv_v_ipi_dev")]
        public virtual double? VIpiDev
         { 
            get { return this._valueVIpiDev; } 
            set 
            { 
                if (this._valueVIpiDev == value)return;
                 this._valueVIpiDev = value; 
            } 
        } 

       protected double? _vBcIcmsDevOriginal{get;private set;}
       private double? _vBcIcmsDevOriginalCommited{get; set;}
        private double? _valueVBcIcmsDev;
         [Column("ntv_v_bc_icms_dev")]
        public virtual double? VBcIcmsDev
         { 
            get { return this._valueVBcIcmsDev; } 
            set 
            { 
                if (this._valueVBcIcmsDev == value)return;
                 this._valueVBcIcmsDev = value; 
            } 
        } 

       protected double? _vIcmsDevOriginal{get;private set;}
       private double? _vIcmsDevOriginalCommited{get; set;}
        private double? _valueVIcmsDev;
         [Column("ntv_v_icms_dev")]
        public virtual double? VIcmsDev
         { 
            get { return this._valueVIcmsDev; } 
            set 
            { 
                if (this._valueVIcmsDev == value)return;
                 this._valueVIcmsDev = value; 
            } 
        } 

       protected double? _vBcIcmsStDevOriginal{get;private set;}
       private double? _vBcIcmsStDevOriginalCommited{get; set;}
        private double? _valueVBcIcmsStDev;
         [Column("ntv_v_bc_icms_st_dev")]
        public virtual double? VBcIcmsStDev
         { 
            get { return this._valueVBcIcmsStDev; } 
            set 
            { 
                if (this._valueVBcIcmsStDev == value)return;
                 this._valueVBcIcmsStDev = value; 
            } 
        } 

       protected double? _vIcmsStDevOriginal{get;private set;}
       private double? _vIcmsStDevOriginalCommited{get; set;}
        private double? _valueVIcmsStDev;
         [Column("ntv_v_icms_st_dev")]
        public virtual double? VIcmsStDev
         { 
            get { return this._valueVIcmsStDev; } 
            set 
            { 
                if (this._valueVIcmsStDev == value)return;
                 this._valueVIcmsStDev = value; 
            } 
        } 

       protected double? _vPisDevOriginal{get;private set;}
       private double? _vPisDevOriginalCommited{get; set;}
        private double? _valueVPisDev;
         [Column("ntv_v_pis_dev")]
        public virtual double? VPisDev
         { 
            get { return this._valueVPisDev; } 
            set 
            { 
                if (this._valueVPisDev == value)return;
                 this._valueVPisDev = value; 
            } 
        } 

       protected double? _vCofinsDevOriginal{get;private set;}
       private double? _vCofinsDevOriginalCommited{get; set;}
        private double? _valueVCofinsDev;
         [Column("ntv_v_cofins_dev")]
        public virtual double? VCofinsDev
         { 
            get { return this._valueVCofinsDev; } 
            set 
            { 
                if (this._valueVCofinsDev == value)return;
                 this._valueVCofinsDev = value; 
            } 
        } 

        public NfTributoDevolucaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfTributoDevolucaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfTributoDevolucaoClass) GetEntity(typeof(NfTributoDevolucaoClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_tributo_devolucao  " +
                    "WHERE " +
                    "  id_nf_tributo_devolucao = :id";
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
                        "  public.nf_tributo_devolucao   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  ntv_v_ipi_dev = :ntv_v_ipi_dev, " + 
                        "  ntv_v_bc_icms_dev = :ntv_v_bc_icms_dev, " + 
                        "  ntv_v_icms_dev = :ntv_v_icms_dev, " + 
                        "  ntv_v_bc_icms_st_dev = :ntv_v_bc_icms_st_dev, " + 
                        "  ntv_v_icms_st_dev = :ntv_v_icms_st_dev, " + 
                        "  ntv_v_pis_dev = :ntv_v_pis_dev, " + 
                        "  ntv_v_cofins_dev = :ntv_v_cofins_dev, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_nf_tributo_devolucao = :id " +
                        "RETURNING id_nf_tributo_devolucao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_tributo_devolucao " +
                        "( " +
                        "  id_nf_item , " + 
                        "  ntv_v_ipi_dev , " + 
                        "  ntv_v_bc_icms_dev , " + 
                        "  ntv_v_icms_dev , " + 
                        "  ntv_v_bc_icms_st_dev , " + 
                        "  ntv_v_icms_st_dev , " + 
                        "  ntv_v_pis_dev , " + 
                        "  ntv_v_cofins_dev , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :ntv_v_ipi_dev , " + 
                        "  :ntv_v_bc_icms_dev , " + 
                        "  :ntv_v_icms_dev , " + 
                        "  :ntv_v_bc_icms_st_dev , " + 
                        "  :ntv_v_icms_st_dev , " + 
                        "  :ntv_v_pis_dev , " + 
                        "  :ntv_v_cofins_dev , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_nf_tributo_devolucao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntv_v_ipi_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIpiDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntv_v_bc_icms_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBcIcmsDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntv_v_icms_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIcmsDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntv_v_bc_icms_st_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBcIcmsStDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntv_v_icms_st_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIcmsStDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntv_v_pis_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VPisDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntv_v_cofins_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCofinsDev ?? DBNull.Value;
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
        public static NfTributoDevolucaoClass CopiarEntidade(NfTributoDevolucaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfTributoDevolucaoClass toRet = new NfTributoDevolucaoClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.VIpiDev= entidadeCopiar.VIpiDev;
 toRet.VBcIcmsDev= entidadeCopiar.VBcIcmsDev;
 toRet.VIcmsDev= entidadeCopiar.VIcmsDev;
 toRet.VBcIcmsStDev= entidadeCopiar.VBcIcmsStDev;
 toRet.VIcmsStDev= entidadeCopiar.VIcmsStDev;
 toRet.VPisDev= entidadeCopiar.VPisDev;
 toRet.VCofinsDev= entidadeCopiar.VCofinsDev;

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
       _vIpiDevOriginal = VIpiDev;
       _vIpiDevOriginalCommited = _vIpiDevOriginal;
       _vBcIcmsDevOriginal = VBcIcmsDev;
       _vBcIcmsDevOriginalCommited = _vBcIcmsDevOriginal;
       _vIcmsDevOriginal = VIcmsDev;
       _vIcmsDevOriginalCommited = _vIcmsDevOriginal;
       _vBcIcmsStDevOriginal = VBcIcmsStDev;
       _vBcIcmsStDevOriginalCommited = _vBcIcmsStDevOriginal;
       _vIcmsStDevOriginal = VIcmsStDev;
       _vIcmsStDevOriginalCommited = _vIcmsStDevOriginal;
       _vPisDevOriginal = VPisDev;
       _vPisDevOriginalCommited = _vPisDevOriginal;
       _vCofinsDevOriginal = VCofinsDev;
       _vCofinsDevOriginalCommited = _vCofinsDevOriginal;
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
       _vIpiDevOriginalCommited = VIpiDev;
       _vBcIcmsDevOriginalCommited = VBcIcmsDev;
       _vIcmsDevOriginalCommited = VIcmsDev;
       _vBcIcmsStDevOriginalCommited = VBcIcmsStDev;
       _vIcmsStDevOriginalCommited = VIcmsStDev;
       _vPisDevOriginalCommited = VPisDev;
       _vCofinsDevOriginalCommited = VCofinsDev;
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
               VIpiDev=_vIpiDevOriginal;
               _vIpiDevOriginalCommited=_vIpiDevOriginal;
               VBcIcmsDev=_vBcIcmsDevOriginal;
               _vBcIcmsDevOriginalCommited=_vBcIcmsDevOriginal;
               VIcmsDev=_vIcmsDevOriginal;
               _vIcmsDevOriginalCommited=_vIcmsDevOriginal;
               VBcIcmsStDev=_vBcIcmsStDevOriginal;
               _vBcIcmsStDevOriginalCommited=_vBcIcmsStDevOriginal;
               VIcmsStDev=_vIcmsStDevOriginal;
               _vIcmsStDevOriginalCommited=_vIcmsStDevOriginal;
               VPisDev=_vPisDevOriginal;
               _vPisDevOriginalCommited=_vPisDevOriginal;
               VCofinsDev=_vCofinsDevOriginal;
               _vCofinsDevOriginalCommited=_vCofinsDevOriginal;
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
       dirty = _vIpiDevOriginal != VIpiDev;
      if (dirty) return true;
       dirty = _vBcIcmsDevOriginal != VBcIcmsDev;
      if (dirty) return true;
       dirty = _vIcmsDevOriginal != VIcmsDev;
      if (dirty) return true;
       dirty = _vBcIcmsStDevOriginal != VBcIcmsStDev;
      if (dirty) return true;
       dirty = _vIcmsStDevOriginal != VIcmsStDev;
      if (dirty) return true;
       dirty = _vPisDevOriginal != VPisDev;
      if (dirty) return true;
       dirty = _vCofinsDevOriginal != VCofinsDev;
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
       dirty = _vIpiDevOriginalCommited != VIpiDev;
      if (dirty) return true;
       dirty = _vBcIcmsDevOriginalCommited != VBcIcmsDev;
      if (dirty) return true;
       dirty = _vIcmsDevOriginalCommited != VIcmsDev;
      if (dirty) return true;
       dirty = _vBcIcmsStDevOriginalCommited != VBcIcmsStDev;
      if (dirty) return true;
       dirty = _vIcmsStDevOriginalCommited != VIcmsStDev;
      if (dirty) return true;
       dirty = _vPisDevOriginalCommited != VPisDev;
      if (dirty) return true;
       dirty = _vCofinsDevOriginalCommited != VCofinsDev;
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
             case "VIpiDev":
                return this.VIpiDev;
             case "VBcIcmsDev":
                return this.VBcIcmsDev;
             case "VIcmsDev":
                return this.VIcmsDev;
             case "VBcIcmsStDev":
                return this.VBcIcmsStDev;
             case "VIcmsStDev":
                return this.VIcmsStDev;
             case "VPisDev":
                return this.VPisDev;
             case "VCofinsDev":
                return this.VCofinsDev;
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
                  command.CommandText += " COUNT(nf_tributo_devolucao.id_nf_tributo_devolucao) " ;
               }
               else
               {
               command.CommandText += "nf_tributo_devolucao.id_nf_tributo_devolucao, " ;
               command.CommandText += "nf_tributo_devolucao.id_nf_item, " ;
               command.CommandText += "nf_tributo_devolucao.ntv_v_ipi_dev, " ;
               command.CommandText += "nf_tributo_devolucao.ntv_v_bc_icms_dev, " ;
               command.CommandText += "nf_tributo_devolucao.ntv_v_icms_dev, " ;
               command.CommandText += "nf_tributo_devolucao.ntv_v_bc_icms_st_dev, " ;
               command.CommandText += "nf_tributo_devolucao.ntv_v_icms_st_dev, " ;
               command.CommandText += "nf_tributo_devolucao.ntv_v_pis_dev, " ;
               command.CommandText += "nf_tributo_devolucao.ntv_v_cofins_dev, " ;
               command.CommandText += "nf_tributo_devolucao.version, " ;
               command.CommandText += "nf_tributo_devolucao.entity_uid " ;
               }
               command.CommandText += " FROM  nf_tributo_devolucao ";
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
                        orderByClause += " , ntv_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ntv_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_tributo_devolucao.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_tributo_devolucao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_devolucao.id_nf_tributo_devolucao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_devolucao.id_nf_tributo_devolucao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_tributo_devolucao.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "ntv_v_ipi_dev":
                     case "VIpiDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_devolucao.ntv_v_ipi_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_devolucao.ntv_v_ipi_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntv_v_bc_icms_dev":
                     case "VBcIcmsDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_devolucao.ntv_v_bc_icms_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_devolucao.ntv_v_bc_icms_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntv_v_icms_dev":
                     case "VIcmsDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_devolucao.ntv_v_icms_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_devolucao.ntv_v_icms_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntv_v_bc_icms_st_dev":
                     case "VBcIcmsStDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_devolucao.ntv_v_bc_icms_st_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_devolucao.ntv_v_bc_icms_st_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntv_v_icms_st_dev":
                     case "VIcmsStDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_devolucao.ntv_v_icms_st_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_devolucao.ntv_v_icms_st_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntv_v_pis_dev":
                     case "VPisDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_devolucao.ntv_v_pis_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_devolucao.ntv_v_pis_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntv_v_cofins_dev":
                     case "VCofinsDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_devolucao.ntv_v_cofins_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_devolucao.ntv_v_cofins_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_tributo_devolucao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_devolucao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_tributo_devolucao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_tributo_devolucao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(nf_tributo_devolucao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_tributo_devolucao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_tributo_devolucao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_devolucao.id_nf_tributo_devolucao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.id_nf_tributo_devolucao = :nf_tributo_devolucao_ID_387 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_ID_387", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_devolucao.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.id_nf_item = :nf_tributo_devolucao_NfItem_4028 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_NfItem_4028", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIpiDev" || parametro.FieldName == "ntv_v_ipi_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_ipi_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_ipi_dev = :nf_tributo_devolucao_VIpiDev_1841 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_VIpiDev_1841", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBcIcmsDev" || parametro.FieldName == "ntv_v_bc_icms_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_bc_icms_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_bc_icms_dev = :nf_tributo_devolucao_VBcIcmsDev_8543 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_VBcIcmsDev_8543", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIcmsDev" || parametro.FieldName == "ntv_v_icms_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_icms_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_icms_dev = :nf_tributo_devolucao_VIcmsDev_5042 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_VIcmsDev_5042", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBcIcmsStDev" || parametro.FieldName == "ntv_v_bc_icms_st_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_bc_icms_st_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_bc_icms_st_dev = :nf_tributo_devolucao_VBcIcmsStDev_3007 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_VBcIcmsStDev_3007", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIcmsStDev" || parametro.FieldName == "ntv_v_icms_st_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_icms_st_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_icms_st_dev = :nf_tributo_devolucao_VIcmsStDev_4870 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_VIcmsStDev_4870", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VPisDev" || parametro.FieldName == "ntv_v_pis_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_pis_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_pis_dev = :nf_tributo_devolucao_VPisDev_8019 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_VPisDev_8019", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCofinsDev" || parametro.FieldName == "ntv_v_cofins_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_cofins_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.ntv_v_cofins_dev = :nf_tributo_devolucao_VCofinsDev_151 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_VCofinsDev_151", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_devolucao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.version = :nf_tributo_devolucao_Version_3790 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_Version_3790", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_tributo_devolucao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.entity_uid LIKE :nf_tributo_devolucao_EntityUid_4806 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_EntityUid_4806", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_tributo_devolucao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_devolucao.entity_uid LIKE :nf_tributo_devolucao_EntityUid_8608 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_devolucao_EntityUid_8608", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfTributoDevolucaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfTributoDevolucaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfTributoDevolucaoClass), Convert.ToInt32(read["id_nf_tributo_devolucao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfTributoDevolucaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_tributo_devolucao"]);
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.VIpiDev = read["ntv_v_ipi_dev"] as double?;
                     entidade.VBcIcmsDev = read["ntv_v_bc_icms_dev"] as double?;
                     entidade.VIcmsDev = read["ntv_v_icms_dev"] as double?;
                     entidade.VBcIcmsStDev = read["ntv_v_bc_icms_st_dev"] as double?;
                     entidade.VIcmsStDev = read["ntv_v_icms_st_dev"] as double?;
                     entidade.VPisDev = read["ntv_v_pis_dev"] as double?;
                     entidade.VCofinsDev = read["ntv_v_cofins_dev"] as double?;
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfTributoDevolucaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
