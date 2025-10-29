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
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("orcamento_kit","ork")]
     public class OrcamentoKitBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrcamentoKitClass";
protected const string ErroDelete = "Erro ao excluir o OrcamentoKitClass  ";
protected const string ErroSave = "Erro ao salvar o OrcamentoKitClass.";
protected const string ErroOcObrigatorio = "O campo Oc é obrigatório";
protected const string ErroOcComprimento = "O campo Oc deve ter no máximo 255 caracteres";
protected const string ErroTipoKitObrigatorio = "O campo TipoKit é obrigatório";
protected const string ErroTipoKitComprimento = "O campo TipoKit deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do OrcamentoKitClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoKitClass está sendo utilizada.";
#endregion
       protected string _ocOriginal{get;private set;}
       private string _ocOriginalCommited{get; set;}
        private string _valueOc;
         [Column("ork_oc")]
        public virtual string Oc
         { 
            get { return this._valueOc; } 
            set 
            { 
                if (this._valueOc == value)return;
                 this._valueOc = value; 
            } 
        } 

       protected int _posOriginal{get;private set;}
       private int _posOriginalCommited{get; set;}
        private int _valuePos;
         [Column("ork_pos")]
        public virtual int Pos
         { 
            get { return this._valuePos; } 
            set 
            { 
                if (this._valuePos == value)return;
                 this._valuePos = value; 
            } 
        } 

       protected string _tipoKitOriginal{get;private set;}
       private string _tipoKitOriginalCommited{get; set;}
        private string _valueTipoKit;
         [Column("ork_tipo_kit")]
        public virtual string TipoKit
         { 
            get { return this._valueTipoKit; } 
            set 
            { 
                if (this._valueTipoKit == value)return;
                 this._valueTipoKit = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ClienteClass _clienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ClienteClass _clienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ClienteClass _valueCliente;
        [Column("id_cliente", "cliente", "id_cliente")]
       public virtual BibliotecaEntidades.Entidades.ClienteClass Cliente
        { 
           get {                 return this._valueCliente; } 
           set 
           { 
                if (this._valueCliente == value)return;
                 this._valueCliente = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.OrcamentoItemClass _orcamentoItemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrcamentoItemClass _orcamentoItemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrcamentoItemClass _valueOrcamentoItem;
        [Column("id_orcamento_item", "orcamento_item", "id_orcamento_item")]
       public virtual BibliotecaEntidades.Entidades.OrcamentoItemClass OrcamentoItem
        { 
           get {                 return this._valueOrcamentoItem; } 
           set 
           { 
                if (this._valueOrcamentoItem == value)return;
                 this._valueOrcamentoItem = value; 
           } 
       } 

        public OrcamentoKitBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static OrcamentoKitClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrcamentoKitClass) GetEntity(typeof(OrcamentoKitClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Oc))
                {
                    throw new Exception(ErroOcObrigatorio);
                }
                if (Oc.Length >255)
                {
                    throw new Exception( ErroOcComprimento);
                }
                if (string.IsNullOrEmpty(TipoKit))
                {
                    throw new Exception(ErroTipoKitObrigatorio);
                }
                if (TipoKit.Length >255)
                {
                    throw new Exception( ErroTipoKitComprimento);
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
                    "  public.orcamento_kit  " +
                    "WHERE " +
                    "  id_orcamento_kit = :id";
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
                        "  public.orcamento_kit   " +
                        "SET  " + 
                        "  ork_oc = :ork_oc, " + 
                        "  ork_pos = :ork_pos, " + 
                        "  ork_tipo_kit = :ork_tipo_kit, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  id_orcamento_item = :id_orcamento_item, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_orcamento_kit = :id " +
                        "RETURNING id_orcamento_kit;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.orcamento_kit " +
                        "( " +
                        "  ork_oc , " + 
                        "  ork_pos , " + 
                        "  ork_tipo_kit , " + 
                        "  id_cliente , " + 
                        "  id_orcamento_item , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :ork_oc , " + 
                        "  :ork_pos , " + 
                        "  :ork_tipo_kit , " + 
                        "  :id_cliente , " + 
                        "  :id_orcamento_item , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_orcamento_kit;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ork_oc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Oc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ork_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ork_tipo_kit", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoKit ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrcamentoItem==null ? (object) DBNull.Value : this.OrcamentoItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;

 
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
        public static OrcamentoKitClass CopiarEntidade(OrcamentoKitClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrcamentoKitClass toRet = new OrcamentoKitClass(usuario,conn);
 toRet.Oc= entidadeCopiar.Oc;
 toRet.Pos= entidadeCopiar.Pos;
 toRet.TipoKit= entidadeCopiar.TipoKit;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.OrcamentoItem= entidadeCopiar.OrcamentoItem;

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
       _ocOriginal = Oc;
       _ocOriginalCommited = _ocOriginal;
       _posOriginal = Pos;
       _posOriginalCommited = _posOriginal;
       _tipoKitOriginal = TipoKit;
       _tipoKitOriginalCommited = _tipoKitOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _orcamentoItemOriginal = OrcamentoItem;
       _orcamentoItemOriginalCommited = _orcamentoItemOriginal;
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
       _ocOriginalCommited = Oc;
       _posOriginalCommited = Pos;
       _tipoKitOriginalCommited = TipoKit;
       _clienteOriginalCommited = Cliente;
       _orcamentoItemOriginalCommited = OrcamentoItem;
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
               Oc=_ocOriginal;
               _ocOriginalCommited=_ocOriginal;
               Pos=_posOriginal;
               _posOriginalCommited=_posOriginal;
               TipoKit=_tipoKitOriginal;
               _tipoKitOriginalCommited=_tipoKitOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               OrcamentoItem=_orcamentoItemOriginal;
               _orcamentoItemOriginalCommited=_orcamentoItemOriginal;
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
       dirty = _ocOriginal != Oc;
      if (dirty) return true;
       dirty = _posOriginal != Pos;
      if (dirty) return true;
       dirty = _tipoKitOriginal != TipoKit;
      if (dirty) return true;
       if (_clienteOriginal!=null)
       {
          dirty = !_clienteOriginal.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
      if (dirty) return true;
       if (_orcamentoItemOriginal!=null)
       {
          dirty = !_orcamentoItemOriginal.Equals(OrcamentoItem);
       }
       else
       {
            dirty = OrcamentoItem != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;

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
       dirty = _ocOriginalCommited != Oc;
      if (dirty) return true;
       dirty = _posOriginalCommited != Pos;
      if (dirty) return true;
       dirty = _tipoKitOriginalCommited != TipoKit;
      if (dirty) return true;
       if (_clienteOriginalCommited!=null)
       {
          dirty = !_clienteOriginalCommited.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
      if (dirty) return true;
       if (_orcamentoItemOriginalCommited!=null)
       {
          dirty = !_orcamentoItemOriginalCommited.Equals(OrcamentoItem);
       }
       else
       {
            dirty = OrcamentoItem != null;
       }
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;

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
             case "Oc":
                return this.Oc;
             case "Pos":
                return this.Pos;
             case "TipoKit":
                return this.TipoKit;
             case "Cliente":
                return this.Cliente;
             case "OrcamentoItem":
                return this.OrcamentoItem;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
             if (OrcamentoItem!=null)
                OrcamentoItem.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(orcamento_kit.id_orcamento_kit) " ;
               }
               else
               {
               command.CommandText += "orcamento_kit.id_orcamento_kit, " ;
               command.CommandText += "orcamento_kit.ork_oc, " ;
               command.CommandText += "orcamento_kit.ork_pos, " ;
               command.CommandText += "orcamento_kit.ork_tipo_kit, " ;
               command.CommandText += "orcamento_kit.id_cliente, " ;
               command.CommandText += "orcamento_kit.id_orcamento_item, " ;
               command.CommandText += "orcamento_kit.entity_uid, " ;
               command.CommandText += "orcamento_kit.version " ;
               }
               command.CommandText += " FROM  orcamento_kit ";
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
                        orderByClause += " , ork_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ork_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = orcamento_kit.id_acs_usuario_ultima_revisao ";
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
                     case "id_orcamento_kit":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_kit.id_orcamento_kit " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_kit.id_orcamento_kit) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ork_oc":
                     case "Oc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_kit.ork_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_kit.ork_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ork_pos":
                     case "Pos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_kit.ork_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_kit.ork_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ork_tipo_kit":
                     case "TipoKit":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_kit.ork_tipo_kit " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_kit.ork_tipo_kit) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = orcamento_kit.id_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente_Cliente.cli_nome_resumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente_Cliente.cli_nome_resumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_orcamento_item":
                     case "OrcamentoItem":
                     command.CommandText += " LEFT JOIN orcamento_item as orcamento_item_OrcamentoItem ON orcamento_item_OrcamentoItem.id_orcamento_item = orcamento_kit.id_orcamento_item ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item_OrcamentoItem.id_orcamento_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item_OrcamentoItem.id_orcamento_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_kit.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_kit.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , orcamento_kit.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_kit.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ork_oc")) 
                        {
                           whereClause += " OR UPPER(orcamento_kit.ork_oc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_kit.ork_oc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ork_tipo_kit")) 
                        {
                           whereClause += " OR UPPER(orcamento_kit.ork_tipo_kit) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_kit.ork_tipo_kit) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(orcamento_kit.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_kit.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_orcamento_kit")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_kit.id_orcamento_kit IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.id_orcamento_kit = :orcamento_kit_ID_8929 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_ID_8929", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Oc" || parametro.FieldName == "ork_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_kit.ork_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.ork_oc LIKE :orcamento_kit_Oc_5450 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_Oc_5450", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pos" || parametro.FieldName == "ork_pos")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_kit.ork_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.ork_pos = :orcamento_kit_Pos_9618 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_Pos_9618", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoKit" || parametro.FieldName == "ork_tipo_kit")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_kit.ork_tipo_kit IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.ork_tipo_kit LIKE :orcamento_kit_TipoKit_6109 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_TipoKit_6109", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cliente" || parametro.FieldName == "id_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_kit.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.id_cliente = :orcamento_kit_Cliente_171 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_Cliente_171", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrcamentoItem" || parametro.FieldName == "id_orcamento_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrcamentoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrcamentoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_kit.id_orcamento_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.id_orcamento_item = :orcamento_kit_OrcamentoItem_6437 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_OrcamentoItem_6437", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  orcamento_kit.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.entity_uid LIKE :orcamento_kit_EntityUid_703 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_EntityUid_703", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  orcamento_kit.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.version = :orcamento_kit_Version_8384 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_Version_8384", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OcExato" || parametro.FieldName == "OcExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_kit.ork_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.ork_oc LIKE :orcamento_kit_Oc_4402 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_Oc_4402", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoKitExato" || parametro.FieldName == "TipoKitExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_kit.ork_tipo_kit IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.ork_tipo_kit LIKE :orcamento_kit_TipoKit_5671 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_TipoKit_5671", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_kit.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_kit.entity_uid LIKE :orcamento_kit_EntityUid_7311 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_kit_EntityUid_7311", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrcamentoKitClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrcamentoKitClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrcamentoKitClass), Convert.ToInt32(read["id_orcamento_kit"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrcamentoKitClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_orcamento_kit"]);
                     entidade.Oc = (read["ork_oc"] != DBNull.Value ? read["ork_oc"].ToString() : null);
                     entidade.Pos = (int)read["ork_pos"];
                     entidade.TipoKit = (read["ork_tipo_kit"] != DBNull.Value ? read["ork_tipo_kit"].ToString() : null);
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     if (read["id_orcamento_item"] != DBNull.Value)
                     {
                        entidade.OrcamentoItem = (BibliotecaEntidades.Entidades.OrcamentoItemClass)BibliotecaEntidades.Entidades.OrcamentoItemClass.GetEntidade(Convert.ToInt32(read["id_orcamento_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrcamentoItem = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrcamentoKitClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
