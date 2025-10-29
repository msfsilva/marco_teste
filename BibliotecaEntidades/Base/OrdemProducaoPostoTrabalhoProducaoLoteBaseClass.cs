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
     [Table("ordem_producao_posto_trabalho_producao_lote","ent")]
     public class OrdemProducaoPostoTrabalhoProducaoLoteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoPostoTrabalhoProducaoLoteClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoPostoTrabalhoProducaoLoteClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoPostoTrabalhoProducaoLoteClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemProducaoPostoTrabalhoProducaoObrigatorio = "O campo OrdemProducaoPostoTrabalhoProducao é obrigatório";
protected const string ErroLoteObrigatorio = "O campo Lote é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoPostoTrabalhoProducaoLoteClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoPostoTrabalhoProducaoLoteClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoProducaoClass _ordemProducaoPostoTrabalhoProducaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoProducaoClass _ordemProducaoPostoTrabalhoProducaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoProducaoClass _valueOrdemProducaoPostoTrabalhoProducao;
        [Column("id_ordem_producao_posto_trabalho_producao", "ordem_producao_posto_trabalho_producao", "id_ordem_producao_posto_trabalho_producao")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoProducaoClass OrdemProducaoPostoTrabalhoProducao
        { 
           get {                 return this._valueOrdemProducaoPostoTrabalhoProducao; } 
           set 
           { 
                if (this._valueOrdemProducaoPostoTrabalhoProducao == value)return;
                 this._valueOrdemProducaoPostoTrabalhoProducao = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.LoteClass _loteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.LoteClass _loteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.LoteClass _valueLote;
        [Column("id_lote", "lote", "id_lote")]
       public virtual BibliotecaEntidades.Entidades.LoteClass Lote
        { 
           get {                 return this._valueLote; } 
           set 
           { 
                if (this._valueLote == value)return;
                 this._valueLote = value; 
           } 
       } 

        public OrdemProducaoPostoTrabalhoProducaoLoteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static OrdemProducaoPostoTrabalhoProducaoLoteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoPostoTrabalhoProducaoLoteClass) GetEntity(typeof(OrdemProducaoPostoTrabalhoProducaoLoteClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueOrdemProducaoPostoTrabalhoProducao == null)
                {
                    throw new Exception(ErroOrdemProducaoPostoTrabalhoProducaoObrigatorio);
                }
                if ( _valueLote == null)
                {
                    throw new Exception(ErroLoteObrigatorio);
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
                    "  public.ordem_producao_posto_trabalho_producao_lote  " +
                    "WHERE " +
                    "  id_ordem_producao_posto_trabalho_producao_lote = :id";
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
                        "  public.ordem_producao_posto_trabalho_producao_lote   " +
                        "SET  " + 
                        "  id_ordem_producao_posto_trabalho_producao = :id_ordem_producao_posto_trabalho_producao, " + 
                        "  id_lote = :id_lote, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_posto_trabalho_producao_lote = :id " +
                        "RETURNING id_ordem_producao_posto_trabalho_producao_lote;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_posto_trabalho_producao_lote " +
                        "( " +
                        "  id_ordem_producao_posto_trabalho_producao , " + 
                        "  id_lote , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao_posto_trabalho_producao , " + 
                        "  :id_lote , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_posto_trabalho_producao_lote;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducaoPostoTrabalhoProducao==null ? (object) DBNull.Value : this.OrdemProducaoPostoTrabalhoProducao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Lote==null ? (object) DBNull.Value : this.Lote.ID;
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
        public static OrdemProducaoPostoTrabalhoProducaoLoteClass CopiarEntidade(OrdemProducaoPostoTrabalhoProducaoLoteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoPostoTrabalhoProducaoLoteClass toRet = new OrdemProducaoPostoTrabalhoProducaoLoteClass(usuario,conn);
 toRet.OrdemProducaoPostoTrabalhoProducao= entidadeCopiar.OrdemProducaoPostoTrabalhoProducao;
 toRet.Lote= entidadeCopiar.Lote;

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
       _ordemProducaoPostoTrabalhoProducaoOriginal = OrdemProducaoPostoTrabalhoProducao;
       _ordemProducaoPostoTrabalhoProducaoOriginalCommited = _ordemProducaoPostoTrabalhoProducaoOriginal;
       _loteOriginal = Lote;
       _loteOriginalCommited = _loteOriginal;
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
       _ordemProducaoPostoTrabalhoProducaoOriginalCommited = OrdemProducaoPostoTrabalhoProducao;
       _loteOriginalCommited = Lote;
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
               OrdemProducaoPostoTrabalhoProducao=_ordemProducaoPostoTrabalhoProducaoOriginal;
               _ordemProducaoPostoTrabalhoProducaoOriginalCommited=_ordemProducaoPostoTrabalhoProducaoOriginal;
               Lote=_loteOriginal;
               _loteOriginalCommited=_loteOriginal;
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
       if (_ordemProducaoPostoTrabalhoProducaoOriginal!=null)
       {
          dirty = !_ordemProducaoPostoTrabalhoProducaoOriginal.Equals(OrdemProducaoPostoTrabalhoProducao);
       }
       else
       {
            dirty = OrdemProducaoPostoTrabalhoProducao != null;
       }
      if (dirty) return true;
       if (_loteOriginal!=null)
       {
          dirty = !_loteOriginal.Equals(Lote);
       }
       else
       {
            dirty = Lote != null;
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
       if (_ordemProducaoPostoTrabalhoProducaoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoPostoTrabalhoProducaoOriginalCommited.Equals(OrdemProducaoPostoTrabalhoProducao);
       }
       else
       {
            dirty = OrdemProducaoPostoTrabalhoProducao != null;
       }
      if (dirty) return true;
       if (_loteOriginalCommited!=null)
       {
          dirty = !_loteOriginalCommited.Equals(Lote);
       }
       else
       {
            dirty = Lote != null;
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
             case "OrdemProducaoPostoTrabalhoProducao":
                return this.OrdemProducaoPostoTrabalhoProducao;
             case "Lote":
                return this.Lote;
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
             if (OrdemProducaoPostoTrabalhoProducao!=null)
                OrdemProducaoPostoTrabalhoProducao.ChangeSingleConnection(newConnection);
             if (Lote!=null)
                Lote.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao_lote) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao_lote, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao_lote.id_lote, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao_lote.entity_uid, " ;
               command.CommandText += "ordem_producao_posto_trabalho_producao_lote.version " ;
               }
               command.CommandText += " FROM  ordem_producao_posto_trabalho_producao_lote ";
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
                        orderByClause += " , ent_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ent_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_posto_trabalho_producao_lote.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_posto_trabalho_producao_lote":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao_lote) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao_posto_trabalho_producao":
                     case "OrdemProducaoPostoTrabalhoProducao":
                     command.CommandText += " LEFT JOIN ordem_producao_posto_trabalho_producao as ordem_producao_posto_trabalho_producao_OrdemProducaoPostoTrabalhoProducao ON ordem_producao_posto_trabalho_producao_OrdemProducaoPostoTrabalhoProducao.id_ordem_producao_posto_trabalho_producao = ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho_producao_OrdemProducaoPostoTrabalhoProducao.id_ordem_producao_posto_trabalho_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao_OrdemProducaoPostoTrabalhoProducao.id_ordem_producao_posto_trabalho_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_lote":
                     case "Lote":
                     command.CommandText += " LEFT JOIN lote as lote_Lote ON lote_Lote.id_lote = ordem_producao_posto_trabalho_producao_lote.id_lote ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote_Lote.lot_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote_Lote.lot_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho_producao_lote.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao_lote.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_posto_trabalho_producao_lote.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_producao_lote.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho_producao_lote.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho_producao_lote.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_posto_trabalho_producao_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao_lote = :ordem_producao_posto_trabalho_producao_lote_ID_9660 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_lote_ID_9660", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoPostoTrabalhoProducao" || parametro.FieldName == "id_ordem_producao_posto_trabalho_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoProducaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoProducaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.id_ordem_producao_posto_trabalho_producao = :ordem_producao_posto_trabalho_producao_lote_OrdemProducaoPostoTrabalhoProducao_1758 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_lote_OrdemProducaoPostoTrabalhoProducao_1758", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Lote" || parametro.FieldName == "id_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.LoteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.LoteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.id_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.id_lote = :ordem_producao_posto_trabalho_producao_lote_Lote_5976 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_lote_Lote_5976", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.entity_uid LIKE :ordem_producao_posto_trabalho_producao_lote_EntityUid_4504 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_lote_EntityUid_4504", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.version = :ordem_producao_posto_trabalho_producao_lote_Version_5519 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_lote_Version_5519", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho_producao_lote.entity_uid LIKE :ordem_producao_posto_trabalho_producao_lote_EntityUid_2470 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_producao_lote_EntityUid_2470", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoPostoTrabalhoProducaoLoteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoPostoTrabalhoProducaoLoteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoPostoTrabalhoProducaoLoteClass), Convert.ToInt32(read["id_ordem_producao_posto_trabalho_producao_lote"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoPostoTrabalhoProducaoLoteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_posto_trabalho_producao_lote"]);
                     if (read["id_ordem_producao_posto_trabalho_producao"] != DBNull.Value)
                     {
                        entidade.OrdemProducaoPostoTrabalhoProducao = (BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoProducaoClass)BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoProducaoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao_posto_trabalho_producao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducaoPostoTrabalhoProducao = null ;
                     }
                     if (read["id_lote"] != DBNull.Value)
                     {
                        entidade.Lote = (BibliotecaEntidades.Entidades.LoteClass)BibliotecaEntidades.Entidades.LoteClass.GetEntidade(Convert.ToInt32(read["id_lote"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Lote = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoPostoTrabalhoProducaoLoteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
