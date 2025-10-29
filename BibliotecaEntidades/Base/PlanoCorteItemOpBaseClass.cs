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
     [Table("plano_corte_item_op","pco")]
     public class PlanoCorteItemOpBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PlanoCorteItemOpClass";
protected const string ErroDelete = "Erro ao excluir o PlanoCorteItemOpClass  ";
protected const string ErroSave = "Erro ao salvar o PlanoCorteItemOpClass.";
protected const string ErroCodigoItemObrigatorio = "O campo CodigoItem é obrigatório";
protected const string ErroCodigoItemComprimento = "O campo CodigoItem deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroPlanoCorteItemObrigatorio = "O campo PlanoCorteItem é obrigatório";
protected const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do PlanoCorteItemOpClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PlanoCorteItemOpClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.PlanoCorteItemClass _planoCorteItemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PlanoCorteItemClass _planoCorteItemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PlanoCorteItemClass _valuePlanoCorteItem;
        [Column("id_plano_corte_item", "plano_corte_item", "id_plano_corte_item")]
       public virtual BibliotecaEntidades.Entidades.PlanoCorteItemClass PlanoCorteItem
        { 
           get {                 return this._valuePlanoCorteItem; } 
           set 
           { 
                if (this._valuePlanoCorteItem == value)return;
                 this._valuePlanoCorteItem = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _valueOrdemProducao;
        [Column("id_ordem_producao", "ordem_producao", "id_ordem_producao")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoClass OrdemProducao
        { 
           get {                 return this._valueOrdemProducao; } 
           set 
           { 
                if (this._valueOrdemProducao == value)return;
                 this._valueOrdemProducao = value; 
           } 
       } 

       protected string _codigoItemOriginal{get;private set;}
       private string _codigoItemOriginalCommited{get; set;}
        private string _valueCodigoItem;
         [Column("pco_codigo_item")]
        public virtual string CodigoItem
         { 
            get { return this._valueCodigoItem; } 
            set 
            { 
                if (this._valueCodigoItem == value)return;
                 this._valueCodigoItem = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("pco_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

        public PlanoCorteItemOpBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static PlanoCorteItemOpClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PlanoCorteItemOpClass) GetEntity(typeof(PlanoCorteItemOpClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CodigoItem))
                {
                    throw new Exception(ErroCodigoItemObrigatorio);
                }
                if (CodigoItem.Length >255)
                {
                    throw new Exception( ErroCodigoItemComprimento);
                }
                if ( _valuePlanoCorteItem == null)
                {
                    throw new Exception(ErroPlanoCorteItemObrigatorio);
                }
                if ( _valueOrdemProducao == null)
                {
                    throw new Exception(ErroOrdemProducaoObrigatorio);
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
                    "  public.plano_corte_item_op  " +
                    "WHERE " +
                    "  id_plano_corte_item_op = :id";
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
                        "  public.plano_corte_item_op   " +
                        "SET  " + 
                        "  id_plano_corte_item = :id_plano_corte_item, " + 
                        "  id_ordem_producao = :id_ordem_producao, " + 
                        "  pco_codigo_item = :pco_codigo_item, " + 
                        "  pco_quantidade = :pco_quantidade, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_plano_corte_item_op = :id " +
                        "RETURNING id_plano_corte_item_op;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.plano_corte_item_op " +
                        "( " +
                        "  id_plano_corte_item , " + 
                        "  id_ordem_producao , " + 
                        "  pco_codigo_item , " + 
                        "  pco_quantidade , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_plano_corte_item , " + 
                        "  :id_ordem_producao , " + 
                        "  :pco_codigo_item , " + 
                        "  :pco_quantidade , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_plano_corte_item_op;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_plano_corte_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PlanoCorteItem==null ? (object) DBNull.Value : this.PlanoCorteItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducao==null ? (object) DBNull.Value : this.OrdemProducao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pco_codigo_item", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pco_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
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
        public static PlanoCorteItemOpClass CopiarEntidade(PlanoCorteItemOpClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PlanoCorteItemOpClass toRet = new PlanoCorteItemOpClass(usuario,conn);
 toRet.PlanoCorteItem= entidadeCopiar.PlanoCorteItem;
 toRet.OrdemProducao= entidadeCopiar.OrdemProducao;
 toRet.CodigoItem= entidadeCopiar.CodigoItem;
 toRet.Quantidade= entidadeCopiar.Quantidade;

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
       _planoCorteItemOriginal = PlanoCorteItem;
       _planoCorteItemOriginalCommited = _planoCorteItemOriginal;
       _ordemProducaoOriginal = OrdemProducao;
       _ordemProducaoOriginalCommited = _ordemProducaoOriginal;
       _codigoItemOriginal = CodigoItem;
       _codigoItemOriginalCommited = _codigoItemOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
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
       _planoCorteItemOriginalCommited = PlanoCorteItem;
       _ordemProducaoOriginalCommited = OrdemProducao;
       _codigoItemOriginalCommited = CodigoItem;
       _quantidadeOriginalCommited = Quantidade;
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
               PlanoCorteItem=_planoCorteItemOriginal;
               _planoCorteItemOriginalCommited=_planoCorteItemOriginal;
               OrdemProducao=_ordemProducaoOriginal;
               _ordemProducaoOriginalCommited=_ordemProducaoOriginal;
               CodigoItem=_codigoItemOriginal;
               _codigoItemOriginalCommited=_codigoItemOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
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
       if (_planoCorteItemOriginal!=null)
       {
          dirty = !_planoCorteItemOriginal.Equals(PlanoCorteItem);
       }
       else
       {
            dirty = PlanoCorteItem != null;
       }
      if (dirty) return true;
       if (_ordemProducaoOriginal!=null)
       {
          dirty = !_ordemProducaoOriginal.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
       }
      if (dirty) return true;
       dirty = _codigoItemOriginal != CodigoItem;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
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
       if (_planoCorteItemOriginalCommited!=null)
       {
          dirty = !_planoCorteItemOriginalCommited.Equals(PlanoCorteItem);
       }
       else
       {
            dirty = PlanoCorteItem != null;
       }
      if (dirty) return true;
       if (_ordemProducaoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoOriginalCommited.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
       }
      if (dirty) return true;
       dirty = _codigoItemOriginalCommited != CodigoItem;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
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
             case "PlanoCorteItem":
                return this.PlanoCorteItem;
             case "OrdemProducao":
                return this.OrdemProducao;
             case "CodigoItem":
                return this.CodigoItem;
             case "Quantidade":
                return this.Quantidade;
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
             if (PlanoCorteItem!=null)
                PlanoCorteItem.ChangeSingleConnection(newConnection);
             if (OrdemProducao!=null)
                OrdemProducao.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(plano_corte_item_op.id_plano_corte_item_op) " ;
               }
               else
               {
               command.CommandText += "plano_corte_item_op.id_plano_corte_item_op, " ;
               command.CommandText += "plano_corte_item_op.id_plano_corte_item, " ;
               command.CommandText += "plano_corte_item_op.id_ordem_producao, " ;
               command.CommandText += "plano_corte_item_op.pco_codigo_item, " ;
               command.CommandText += "plano_corte_item_op.pco_quantidade, " ;
               command.CommandText += "plano_corte_item_op.entity_uid, " ;
               command.CommandText += "plano_corte_item_op.version " ;
               }
               command.CommandText += " FROM  plano_corte_item_op ";
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
                        orderByClause += " , pco_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pco_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = plano_corte_item_op.id_acs_usuario_ultima_revisao ";
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
                     case "id_plano_corte_item_op":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item_op.id_plano_corte_item_op " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item_op.id_plano_corte_item_op) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_plano_corte_item":
                     case "PlanoCorteItem":
                     command.CommandText += " LEFT JOIN plano_corte_item as plano_corte_item_PlanoCorteItem ON plano_corte_item_PlanoCorteItem.id_plano_corte_item = plano_corte_item_op.id_plano_corte_item ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item_PlanoCorteItem.id_plano_corte_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item_PlanoCorteItem.id_plano_corte_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao":
                     case "OrdemProducao":
                     command.CommandText += " LEFT JOIN ordem_producao as ordem_producao_OrdemProducao ON ordem_producao_OrdemProducao.id_ordem_producao = plano_corte_item_op.id_ordem_producao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_OrdemProducao.id_ordem_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_OrdemProducao.id_ordem_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pco_codigo_item":
                     case "CodigoItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item_op.pco_codigo_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item_op.pco_codigo_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pco_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item_op.pco_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item_op.pco_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item_op.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item_op.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , plano_corte_item_op.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item_op.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pco_codigo_item")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item_op.pco_codigo_item) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item_op.pco_codigo_item) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item_op.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item_op.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_plano_corte_item_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_op.id_plano_corte_item_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_op.id_plano_corte_item_op = :plano_corte_item_op_ID_4024 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_op_ID_4024", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteItem" || parametro.FieldName == "id_plano_corte_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PlanoCorteItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PlanoCorteItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_op.id_plano_corte_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_op.id_plano_corte_item = :plano_corte_item_op_PlanoCorteItem_5769 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_op_PlanoCorteItem_5769", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducao" || parametro.FieldName == "id_ordem_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_op.id_ordem_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_op.id_ordem_producao = :plano_corte_item_op_OrdemProducao_1611 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_op_OrdemProducao_1611", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItem" || parametro.FieldName == "pco_codigo_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_op.pco_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_op.pco_codigo_item LIKE :plano_corte_item_op_CodigoItem_1718 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_op_CodigoItem_1718", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "pco_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_op.pco_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_op.pco_quantidade = :plano_corte_item_op_Quantidade_1005 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_op_Quantidade_1005", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  plano_corte_item_op.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_op.entity_uid LIKE :plano_corte_item_op_EntityUid_4880 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_op_EntityUid_4880", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  plano_corte_item_op.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_op.version = :plano_corte_item_op_Version_6135 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_op_Version_6135", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemExato" || parametro.FieldName == "CodigoItemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_op.pco_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_op.pco_codigo_item LIKE :plano_corte_item_op_CodigoItem_4983 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_op_CodigoItem_4983", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  plano_corte_item_op.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_op.entity_uid LIKE :plano_corte_item_op_EntityUid_8721 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_op_EntityUid_8721", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PlanoCorteItemOpClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PlanoCorteItemOpClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PlanoCorteItemOpClass), Convert.ToInt32(read["id_plano_corte_item_op"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PlanoCorteItemOpClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_plano_corte_item_op"]);
                     if (read["id_plano_corte_item"] != DBNull.Value)
                     {
                        entidade.PlanoCorteItem = (BibliotecaEntidades.Entidades.PlanoCorteItemClass)BibliotecaEntidades.Entidades.PlanoCorteItemClass.GetEntidade(Convert.ToInt32(read["id_plano_corte_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PlanoCorteItem = null ;
                     }
                     if (read["id_ordem_producao"] != DBNull.Value)
                     {
                        entidade.OrdemProducao = (BibliotecaEntidades.Entidades.OrdemProducaoClass)BibliotecaEntidades.Entidades.OrdemProducaoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducao = null ;
                     }
                     entidade.CodigoItem = (read["pco_codigo_item"] != DBNull.Value ? read["pco_codigo_item"].ToString() : null);
                     entidade.Quantidade = (double)read["pco_quantidade"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PlanoCorteItemOpClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
