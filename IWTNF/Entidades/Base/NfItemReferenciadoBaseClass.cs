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
     [Table("nf_item_referenciado","nir")]
     public class NfItemReferenciadoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfItemReferenciadoClass";
protected const string ErroDelete = "Erro ao excluir o NfItemReferenciadoClass  ";
protected const string ErroSave = "Erro ao salvar o NfItemReferenciadoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfItemReferenciadoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfItemReferenciadoClass está sendo utilizada.";
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

       protected int? _nItemRefOriginal{get;private set;}
       private int? _nItemRefOriginalCommited{get; set;}
        private int? _valueNItemRef;
         [Column("nir_n_item_ref")]
        public virtual int? NItemRef
         { 
            get { return this._valueNItemRef; } 
            set 
            { 
                if (this._valueNItemRef == value)return;
                 this._valueNItemRef = value; 
            } 
        } 

       protected short? _indOrigCredOriginal{get;private set;}
       private short? _indOrigCredOriginalCommited{get; set;}
        private short? _valueIndOrigCred;
         [Column("nir_ind_orig_cred")]
        public virtual short? IndOrigCred
         { 
            get { return this._valueIndOrigCred; } 
            set 
            { 
                if (this._valueIndOrigCred == value)return;
                 this._valueIndOrigCred = value; 
            } 
        } 

       protected string _chaveNfeRefOriginal{get;private set;}
       private string _chaveNfeRefOriginalCommited{get; set;}
        private string _valueChaveNfeRef;
         [Column("nir_chave_nfe_ref")]
        public virtual string ChaveNfeRef
         { 
            get { return this._valueChaveNfeRef; } 
            set 
            { 
                if (this._valueChaveNfeRef == value)return;
                 this._valueChaveNfeRef = value; 
            } 
        } 

       protected double? _vCredOrRefOriginal{get;private set;}
       private double? _vCredOrRefOriginalCommited{get; set;}
        private double? _valueVCredOrRef;
         [Column("nir_v_cred_or_ref")]
        public virtual double? VCredOrRef
         { 
            get { return this._valueVCredOrRef; } 
            set 
            { 
                if (this._valueVCredOrRef == value)return;
                 this._valueVCredOrRef = value; 
            } 
        } 

        public NfItemReferenciadoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfItemReferenciadoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfItemReferenciadoClass) GetEntity(typeof(NfItemReferenciadoClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_item_referenciado  " +
                    "WHERE " +
                    "  id_nf_item_referenciado = :id";
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
                        "  public.nf_item_referenciado   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  nir_n_item_ref = :nir_n_item_ref, " + 
                        "  nir_ind_orig_cred = :nir_ind_orig_cred, " + 
                        "  nir_chave_nfe_ref = :nir_chave_nfe_ref, " + 
                        "  nir_v_cred_or_ref = :nir_v_cred_or_ref, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_nf_item_referenciado = :id " +
                        "RETURNING id_nf_item_referenciado;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_item_referenciado " +
                        "( " +
                        "  id_nf_item , " + 
                        "  nir_n_item_ref , " + 
                        "  nir_ind_orig_cred , " + 
                        "  nir_chave_nfe_ref , " + 
                        "  nir_v_cred_or_ref , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :nir_n_item_ref , " + 
                        "  :nir_ind_orig_cred , " + 
                        "  :nir_chave_nfe_ref , " + 
                        "  :nir_v_cred_or_ref , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_nf_item_referenciado;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nir_n_item_ref", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NItemRef ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nir_ind_orig_cred", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndOrigCred ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nir_chave_nfe_ref", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ChaveNfeRef ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nir_v_cred_or_ref", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCredOrRef ?? DBNull.Value;
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
        public static NfItemReferenciadoClass CopiarEntidade(NfItemReferenciadoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfItemReferenciadoClass toRet = new NfItemReferenciadoClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.NItemRef= entidadeCopiar.NItemRef;
 toRet.IndOrigCred= entidadeCopiar.IndOrigCred;
 toRet.ChaveNfeRef= entidadeCopiar.ChaveNfeRef;
 toRet.VCredOrRef= entidadeCopiar.VCredOrRef;

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
       _nItemRefOriginal = NItemRef;
       _nItemRefOriginalCommited = _nItemRefOriginal;
       _indOrigCredOriginal = IndOrigCred;
       _indOrigCredOriginalCommited = _indOrigCredOriginal;
       _chaveNfeRefOriginal = ChaveNfeRef;
       _chaveNfeRefOriginalCommited = _chaveNfeRefOriginal;
       _vCredOrRefOriginal = VCredOrRef;
       _vCredOrRefOriginalCommited = _vCredOrRefOriginal;
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
       _nItemRefOriginalCommited = NItemRef;
       _indOrigCredOriginalCommited = IndOrigCred;
       _chaveNfeRefOriginalCommited = ChaveNfeRef;
       _vCredOrRefOriginalCommited = VCredOrRef;
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
               NItemRef=_nItemRefOriginal;
               _nItemRefOriginalCommited=_nItemRefOriginal;
               IndOrigCred=_indOrigCredOriginal;
               _indOrigCredOriginalCommited=_indOrigCredOriginal;
               ChaveNfeRef=_chaveNfeRefOriginal;
               _chaveNfeRefOriginalCommited=_chaveNfeRefOriginal;
               VCredOrRef=_vCredOrRefOriginal;
               _vCredOrRefOriginalCommited=_vCredOrRefOriginal;
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
       dirty = _nItemRefOriginal != NItemRef;
      if (dirty) return true;
       dirty = _indOrigCredOriginal != IndOrigCred;
      if (dirty) return true;
       dirty = _chaveNfeRefOriginal != ChaveNfeRef;
      if (dirty) return true;
       dirty = _vCredOrRefOriginal != VCredOrRef;
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
       dirty = _nItemRefOriginalCommited != NItemRef;
      if (dirty) return true;
       dirty = _indOrigCredOriginalCommited != IndOrigCred;
      if (dirty) return true;
       dirty = _chaveNfeRefOriginalCommited != ChaveNfeRef;
      if (dirty) return true;
       dirty = _vCredOrRefOriginalCommited != VCredOrRef;
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
             case "NItemRef":
                return this.NItemRef;
             case "IndOrigCred":
                return this.IndOrigCred;
             case "ChaveNfeRef":
                return this.ChaveNfeRef;
             case "VCredOrRef":
                return this.VCredOrRef;
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
                  command.CommandText += " COUNT(nf_item_referenciado.id_nf_item_referenciado) " ;
               }
               else
               {
               command.CommandText += "nf_item_referenciado.id_nf_item_referenciado, " ;
               command.CommandText += "nf_item_referenciado.id_nf_item, " ;
               command.CommandText += "nf_item_referenciado.nir_n_item_ref, " ;
               command.CommandText += "nf_item_referenciado.nir_ind_orig_cred, " ;
               command.CommandText += "nf_item_referenciado.nir_chave_nfe_ref, " ;
               command.CommandText += "nf_item_referenciado.nir_v_cred_or_ref, " ;
               command.CommandText += "nf_item_referenciado.version, " ;
               command.CommandText += "nf_item_referenciado.entity_uid " ;
               }
               command.CommandText += " FROM  nf_item_referenciado ";
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
                        orderByClause += " , nir_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nir_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_item_referenciado.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_item_referenciado":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_referenciado.id_nf_item_referenciado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_referenciado.id_nf_item_referenciado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_item_referenciado.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "nir_n_item_ref":
                     case "NItemRef":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_referenciado.nir_n_item_ref " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_referenciado.nir_n_item_ref) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nir_ind_orig_cred":
                     case "IndOrigCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_referenciado.nir_ind_orig_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_referenciado.nir_ind_orig_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nir_chave_nfe_ref":
                     case "ChaveNfeRef":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_referenciado.nir_chave_nfe_ref " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_referenciado.nir_chave_nfe_ref) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nir_v_cred_or_ref":
                     case "VCredOrRef":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_referenciado.nir_v_cred_or_ref " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_referenciado.nir_v_cred_or_ref) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_item_referenciado.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_referenciado.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_referenciado.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_referenciado.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nir_chave_nfe_ref")) 
                        {
                           whereClause += " OR UPPER(nf_item_referenciado.nir_chave_nfe_ref) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_referenciado.nir_chave_nfe_ref) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_item_referenciado.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_referenciado.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_item_referenciado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_referenciado.id_nf_item_referenciado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.id_nf_item_referenciado = :nf_item_referenciado_ID_5786 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_ID_5786", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_item_referenciado.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.id_nf_item = :nf_item_referenciado_NfItem_4419 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_NfItem_4419", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NItemRef" || parametro.FieldName == "nir_n_item_ref")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_referenciado.nir_n_item_ref IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.nir_n_item_ref = :nf_item_referenciado_NItemRef_636 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_NItemRef_636", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndOrigCred" || parametro.FieldName == "nir_ind_orig_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_referenciado.nir_ind_orig_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.nir_ind_orig_cred = :nf_item_referenciado_IndOrigCred_5933 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_IndOrigCred_5933", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveNfeRef" || parametro.FieldName == "nir_chave_nfe_ref")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_referenciado.nir_chave_nfe_ref IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.nir_chave_nfe_ref LIKE :nf_item_referenciado_ChaveNfeRef_2977 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_ChaveNfeRef_2977", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCredOrRef" || parametro.FieldName == "nir_v_cred_or_ref")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_referenciado.nir_v_cred_or_ref IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.nir_v_cred_or_ref = :nf_item_referenciado_VCredOrRef_269 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_VCredOrRef_269", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_item_referenciado.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.version = :nf_item_referenciado_Version_5290 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_Version_5290", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_item_referenciado.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.entity_uid LIKE :nf_item_referenciado_EntityUid_7366 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_EntityUid_7366", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveNfeRefExato" || parametro.FieldName == "ChaveNfeRefExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_referenciado.nir_chave_nfe_ref IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.nir_chave_nfe_ref LIKE :nf_item_referenciado_ChaveNfeRef_7082 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_ChaveNfeRef_7082", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_item_referenciado.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_referenciado.entity_uid LIKE :nf_item_referenciado_EntityUid_8097 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_referenciado_EntityUid_8097", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfItemReferenciadoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfItemReferenciadoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfItemReferenciadoClass), Convert.ToInt32(read["id_nf_item_referenciado"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfItemReferenciadoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_item_referenciado"]);
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.NItemRef = read["nir_n_item_ref"] as int?;
                     entidade.IndOrigCred = read["nir_ind_orig_cred"] as short?;
                     entidade.ChaveNfeRef = (read["nir_chave_nfe_ref"] != DBNull.Value ? read["nir_chave_nfe_ref"].ToString() : null);
                     entidade.VCredOrRef = read["nir_v_cred_or_ref"] as double?;
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfItemReferenciadoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
