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
     [Table("nf_tributo_cbs","nts")]
     public class NfTributoCbsBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfTributoCbsClass";
protected const string ErroDelete = "Erro ao excluir o NfTributoCbsClass  ";
protected const string ErroSave = "Erro ao salvar o NfTributoCbsClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfTributoCbsClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfTributoCbsClass está sendo utilizada.";
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

       protected double? _vBcCbsOriginal{get;private set;}
       private double? _vBcCbsOriginalCommited{get; set;}
        private double? _valueVBcCbs;
         [Column("nts_v_bc_cbs")]
        public virtual double? VBcCbs
         { 
            get { return this._valueVBcCbs; } 
            set 
            { 
                if (this._valueVBcCbs == value)return;
                 this._valueVBcCbs = value; 
            } 
        } 

       protected double? _vCbsOriginal{get;private set;}
       private double? _vCbsOriginalCommited{get; set;}
        private double? _valueVCbs;
         [Column("nts_v_cbs")]
        public virtual double? VCbs
         { 
            get { return this._valueVCbs; } 
            set 
            { 
                if (this._valueVCbs == value)return;
                 this._valueVCbs = value; 
            } 
        } 

       protected double? _vBcCbsRetOriginal{get;private set;}
       private double? _vBcCbsRetOriginalCommited{get; set;}
        private double? _valueVBcCbsRet;
         [Column("nts_v_bc_cbs_ret")]
        public virtual double? VBcCbsRet
         { 
            get { return this._valueVBcCbsRet; } 
            set 
            { 
                if (this._valueVBcCbsRet == value)return;
                 this._valueVBcCbsRet = value; 
            } 
        } 

       protected double? _vCbsRetOriginal{get;private set;}
       private double? _vCbsRetOriginalCommited{get; set;}
        private double? _valueVCbsRet;
         [Column("nts_v_cbs_ret")]
        public virtual double? VCbsRet
         { 
            get { return this._valueVCbsRet; } 
            set 
            { 
                if (this._valueVCbsRet == value)return;
                 this._valueVCbsRet = value; 
            } 
        } 

       protected double? _vCbsDifOriginal{get;private set;}
       private double? _vCbsDifOriginalCommited{get; set;}
        private double? _valueVCbsDif;
         [Column("nts_v_cbs_dif")]
        public virtual double? VCbsDif
         { 
            get { return this._valueVCbsDif; } 
            set 
            { 
                if (this._valueVCbsDif == value)return;
                 this._valueVCbsDif = value; 
            } 
        } 

       protected double? _vCbsDevOriginal{get;private set;}
       private double? _vCbsDevOriginalCommited{get; set;}
        private double? _valueVCbsDev;
         [Column("nts_v_cbs_dev")]
        public virtual double? VCbsDev
         { 
            get { return this._valueVCbsDev; } 
            set 
            { 
                if (this._valueVCbsDev == value)return;
                 this._valueVCbsDev = value; 
            } 
        } 

       protected double? _pCbsOriginal{get;private set;}
       private double? _pCbsOriginalCommited{get; set;}
        private double? _valuePCbs;
         [Column("nts_p_cbs")]
        public virtual double? PCbs
         { 
            get { return this._valuePCbs; } 
            set 
            { 
                if (this._valuePCbs == value)return;
                 this._valuePCbs = value; 
            } 
        } 

        public NfTributoCbsBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfTributoCbsClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfTributoCbsClass) GetEntity(typeof(NfTributoCbsClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_tributo_cbs  " +
                    "WHERE " +
                    "  id_nf_tributo_cbs = :id";
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
                        "  public.nf_tributo_cbs   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  nts_v_bc_cbs = :nts_v_bc_cbs, " + 
                        "  nts_v_cbs = :nts_v_cbs, " + 
                        "  nts_v_bc_cbs_ret = :nts_v_bc_cbs_ret, " + 
                        "  nts_v_cbs_ret = :nts_v_cbs_ret, " + 
                        "  nts_v_cbs_dif = :nts_v_cbs_dif, " + 
                        "  nts_v_cbs_dev = :nts_v_cbs_dev, " + 
                        "  nts_p_cbs = :nts_p_cbs, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_nf_tributo_cbs = :id " +
                        "RETURNING id_nf_tributo_cbs;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_tributo_cbs " +
                        "( " +
                        "  id_nf_item , " + 
                        "  nts_v_bc_cbs , " + 
                        "  nts_v_cbs , " + 
                        "  nts_v_bc_cbs_ret , " + 
                        "  nts_v_cbs_ret , " + 
                        "  nts_v_cbs_dif , " + 
                        "  nts_v_cbs_dev , " + 
                        "  nts_p_cbs , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :nts_v_bc_cbs , " + 
                        "  :nts_v_cbs , " + 
                        "  :nts_v_bc_cbs_ret , " + 
                        "  :nts_v_cbs_ret , " + 
                        "  :nts_v_cbs_dif , " + 
                        "  :nts_v_cbs_dev , " + 
                        "  :nts_p_cbs , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_nf_tributo_cbs;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nts_v_bc_cbs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBcCbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nts_v_cbs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nts_v_bc_cbs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VBcCbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nts_v_cbs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nts_v_cbs_dif", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsDif ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nts_v_cbs_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nts_p_cbs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PCbs ?? DBNull.Value;
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
        public static NfTributoCbsClass CopiarEntidade(NfTributoCbsClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfTributoCbsClass toRet = new NfTributoCbsClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.VBcCbs= entidadeCopiar.VBcCbs;
 toRet.VCbs= entidadeCopiar.VCbs;
 toRet.VBcCbsRet= entidadeCopiar.VBcCbsRet;
 toRet.VCbsRet= entidadeCopiar.VCbsRet;
 toRet.VCbsDif= entidadeCopiar.VCbsDif;
 toRet.VCbsDev= entidadeCopiar.VCbsDev;
 toRet.PCbs= entidadeCopiar.PCbs;

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
       _vBcCbsOriginal = VBcCbs;
       _vBcCbsOriginalCommited = _vBcCbsOriginal;
       _vCbsOriginal = VCbs;
       _vCbsOriginalCommited = _vCbsOriginal;
       _vBcCbsRetOriginal = VBcCbsRet;
       _vBcCbsRetOriginalCommited = _vBcCbsRetOriginal;
       _vCbsRetOriginal = VCbsRet;
       _vCbsRetOriginalCommited = _vCbsRetOriginal;
       _vCbsDifOriginal = VCbsDif;
       _vCbsDifOriginalCommited = _vCbsDifOriginal;
       _vCbsDevOriginal = VCbsDev;
       _vCbsDevOriginalCommited = _vCbsDevOriginal;
       _pCbsOriginal = PCbs;
       _pCbsOriginalCommited = _pCbsOriginal;
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
       _vBcCbsOriginalCommited = VBcCbs;
       _vCbsOriginalCommited = VCbs;
       _vBcCbsRetOriginalCommited = VBcCbsRet;
       _vCbsRetOriginalCommited = VCbsRet;
       _vCbsDifOriginalCommited = VCbsDif;
       _vCbsDevOriginalCommited = VCbsDev;
       _pCbsOriginalCommited = PCbs;
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
               VBcCbs=_vBcCbsOriginal;
               _vBcCbsOriginalCommited=_vBcCbsOriginal;
               VCbs=_vCbsOriginal;
               _vCbsOriginalCommited=_vCbsOriginal;
               VBcCbsRet=_vBcCbsRetOriginal;
               _vBcCbsRetOriginalCommited=_vBcCbsRetOriginal;
               VCbsRet=_vCbsRetOriginal;
               _vCbsRetOriginalCommited=_vCbsRetOriginal;
               VCbsDif=_vCbsDifOriginal;
               _vCbsDifOriginalCommited=_vCbsDifOriginal;
               VCbsDev=_vCbsDevOriginal;
               _vCbsDevOriginalCommited=_vCbsDevOriginal;
               PCbs=_pCbsOriginal;
               _pCbsOriginalCommited=_pCbsOriginal;
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
       dirty = _vBcCbsOriginal != VBcCbs;
      if (dirty) return true;
       dirty = _vCbsOriginal != VCbs;
      if (dirty) return true;
       dirty = _vBcCbsRetOriginal != VBcCbsRet;
      if (dirty) return true;
       dirty = _vCbsRetOriginal != VCbsRet;
      if (dirty) return true;
       dirty = _vCbsDifOriginal != VCbsDif;
      if (dirty) return true;
       dirty = _vCbsDevOriginal != VCbsDev;
      if (dirty) return true;
       dirty = _pCbsOriginal != PCbs;
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
       dirty = _vBcCbsOriginalCommited != VBcCbs;
      if (dirty) return true;
       dirty = _vCbsOriginalCommited != VCbs;
      if (dirty) return true;
       dirty = _vBcCbsRetOriginalCommited != VBcCbsRet;
      if (dirty) return true;
       dirty = _vCbsRetOriginalCommited != VCbsRet;
      if (dirty) return true;
       dirty = _vCbsDifOriginalCommited != VCbsDif;
      if (dirty) return true;
       dirty = _vCbsDevOriginalCommited != VCbsDev;
      if (dirty) return true;
       dirty = _pCbsOriginalCommited != PCbs;
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
             case "VBcCbs":
                return this.VBcCbs;
             case "VCbs":
                return this.VCbs;
             case "VBcCbsRet":
                return this.VBcCbsRet;
             case "VCbsRet":
                return this.VCbsRet;
             case "VCbsDif":
                return this.VCbsDif;
             case "VCbsDev":
                return this.VCbsDev;
             case "PCbs":
                return this.PCbs;
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
                  command.CommandText += " COUNT(nf_tributo_cbs.id_nf_tributo_cbs) " ;
               }
               else
               {
               command.CommandText += "nf_tributo_cbs.id_nf_tributo_cbs, " ;
               command.CommandText += "nf_tributo_cbs.id_nf_item, " ;
               command.CommandText += "nf_tributo_cbs.nts_v_bc_cbs, " ;
               command.CommandText += "nf_tributo_cbs.nts_v_cbs, " ;
               command.CommandText += "nf_tributo_cbs.nts_v_bc_cbs_ret, " ;
               command.CommandText += "nf_tributo_cbs.nts_v_cbs_ret, " ;
               command.CommandText += "nf_tributo_cbs.nts_v_cbs_dif, " ;
               command.CommandText += "nf_tributo_cbs.nts_v_cbs_dev, " ;
               command.CommandText += "nf_tributo_cbs.nts_p_cbs, " ;
               command.CommandText += "nf_tributo_cbs.version, " ;
               command.CommandText += "nf_tributo_cbs.entity_uid " ;
               }
               command.CommandText += " FROM  nf_tributo_cbs ";
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
                        orderByClause += " , nts_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nts_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_tributo_cbs.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_tributo_cbs":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_cbs.id_nf_tributo_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_cbs.id_nf_tributo_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_tributo_cbs.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "nts_v_bc_cbs":
                     case "VBcCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_cbs.nts_v_bc_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_cbs.nts_v_bc_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nts_v_cbs":
                     case "VCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_cbs.nts_v_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_cbs.nts_v_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nts_v_bc_cbs_ret":
                     case "VBcCbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_cbs.nts_v_bc_cbs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_cbs.nts_v_bc_cbs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nts_v_cbs_ret":
                     case "VCbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_cbs.nts_v_cbs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_cbs.nts_v_cbs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nts_v_cbs_dif":
                     case "VCbsDif":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_cbs.nts_v_cbs_dif " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_cbs.nts_v_cbs_dif) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nts_v_cbs_dev":
                     case "VCbsDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_cbs.nts_v_cbs_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_cbs.nts_v_cbs_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nts_p_cbs":
                     case "PCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_tributo_cbs.nts_p_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_cbs.nts_p_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_tributo_cbs.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_tributo_cbs.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_tributo_cbs.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_tributo_cbs.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(nf_tributo_cbs.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_tributo_cbs.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_tributo_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_cbs.id_nf_tributo_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.id_nf_tributo_cbs = :nf_tributo_cbs_ID_8610 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_ID_8610", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_cbs.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.id_nf_item = :nf_tributo_cbs_NfItem_526 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_NfItem_526", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBcCbs" || parametro.FieldName == "nts_v_bc_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_bc_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_bc_cbs = :nf_tributo_cbs_VBcCbs_6959 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_VBcCbs_6959", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbs" || parametro.FieldName == "nts_v_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_cbs = :nf_tributo_cbs_VCbs_7631 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_VCbs_7631", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VBcCbsRet" || parametro.FieldName == "nts_v_bc_cbs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_bc_cbs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_bc_cbs_ret = :nf_tributo_cbs_VBcCbsRet_8500 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_VBcCbsRet_8500", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsRet" || parametro.FieldName == "nts_v_cbs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_cbs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_cbs_ret = :nf_tributo_cbs_VCbsRet_621 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_VCbsRet_621", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsDif" || parametro.FieldName == "nts_v_cbs_dif")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_cbs_dif IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_cbs_dif = :nf_tributo_cbs_VCbsDif_1912 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_VCbsDif_1912", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsDev" || parametro.FieldName == "nts_v_cbs_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_cbs_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.nts_v_cbs_dev = :nf_tributo_cbs_VCbsDev_6827 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_VCbsDev_6827", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PCbs" || parametro.FieldName == "nts_p_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_tributo_cbs.nts_p_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.nts_p_cbs = :nf_tributo_cbs_PCbs_7492 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_PCbs_7492", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_tributo_cbs.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.version = :nf_tributo_cbs_Version_98 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_Version_98", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_tributo_cbs.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.entity_uid LIKE :nf_tributo_cbs_EntityUid_2708 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_EntityUid_2708", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_tributo_cbs.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_tributo_cbs.entity_uid LIKE :nf_tributo_cbs_EntityUid_6688 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_tributo_cbs_EntityUid_6688", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfTributoCbsClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfTributoCbsClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfTributoCbsClass), Convert.ToInt32(read["id_nf_tributo_cbs"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfTributoCbsClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_tributo_cbs"]);
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.VBcCbs = read["nts_v_bc_cbs"] as double?;
                     entidade.VCbs = read["nts_v_cbs"] as double?;
                     entidade.VBcCbsRet = read["nts_v_bc_cbs_ret"] as double?;
                     entidade.VCbsRet = read["nts_v_cbs_ret"] as double?;
                     entidade.VCbsDif = read["nts_v_cbs_dif"] as double?;
                     entidade.VCbsDev = read["nts_v_cbs_dev"] as double?;
                     entidade.PCbs = read["nts_p_cbs"] as double?;
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfTributoCbsClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
