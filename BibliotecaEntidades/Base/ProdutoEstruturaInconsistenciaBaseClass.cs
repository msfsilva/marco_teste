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
     [Table("produto_estrutura_inconsistencia","pri")]
     public class ProdutoEstruturaInconsistenciaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProdutoEstruturaInconsistenciaClass";
protected const string ErroDelete = "Erro ao excluir o ProdutoEstruturaInconsistenciaClass  ";
protected const string ErroSave = "Erro ao salvar o ProdutoEstruturaInconsistenciaClass.";
protected const string ErroDadosObrigatorio = "O campo Dados é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ProdutoEstruturaInconsistenciaClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoEstruturaInconsistenciaClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _valueProduto;
        [Column("id_produto", "produto", "id_produto")]
       public virtual BibliotecaEntidades.Entidades.ProdutoClass Produto
        { 
           get {                 return this._valueProduto; } 
           set 
           { 
                if (this._valueProduto == value)return;
                 this._valueProduto = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ProdutoPaiFilhoClass _produtoPaiFilhoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoPaiFilhoClass _produtoPaiFilhoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoPaiFilhoClass _valueProdutoPaiFilho;
        [Column("id_produto_pai_filho", "produto_pai_filho", "id_produto_pai_filho")]
       public virtual BibliotecaEntidades.Entidades.ProdutoPaiFilhoClass ProdutoPaiFilho
        { 
           get {                 return this._valueProdutoPaiFilho; } 
           set 
           { 
                if (this._valueProdutoPaiFilho == value)return;
                 this._valueProdutoPaiFilho = value; 
           } 
       } 

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("pri_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected string _dadosOriginal{get;private set;}
       private string _dadosOriginalCommited{get; set;}
        private string _valueDados;
         [Column("pri_dados")]
        public virtual string Dados
         { 
            get { return this._valueDados; } 
            set 
            { 
                if (this._valueDados == value)return;
                 this._valueDados = value; 
            } 
        } 

       protected int? _versaoEstruturaOriginal{get;private set;}
       private int? _versaoEstruturaOriginalCommited{get; set;}
        private int? _valueVersaoEstrutura;
         [Column("pri_versao_estrutura")]
        public virtual int? VersaoEstrutura
         { 
            get { return this._valueVersaoEstrutura; } 
            set 
            { 
                if (this._valueVersaoEstrutura == value)return;
                 this._valueVersaoEstrutura = value; 
            } 
        } 

        public ProdutoEstruturaInconsistenciaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Data = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ProdutoEstruturaInconsistenciaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProdutoEstruturaInconsistenciaClass) GetEntity(typeof(ProdutoEstruturaInconsistenciaClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Dados))
                {
                    throw new Exception(ErroDadosObrigatorio);
                }
                if ( _valueProduto == null)
                {
                    throw new Exception(ErroProdutoObrigatorio);
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
                    "  public.produto_estrutura_inconsistencia  " +
                    "WHERE " +
                    "  id_produto_estrutura_inconsistencia = :id";
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
                        "  public.produto_estrutura_inconsistencia   " +
                        "SET  " + 
                        "  id_produto = :id_produto, " + 
                        "  id_produto_pai_filho = :id_produto_pai_filho, " + 
                        "  pri_data = :pri_data, " + 
                        "  pri_dados = :pri_dados, " + 
                        "  pri_versao_estrutura = :pri_versao_estrutura, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_produto_estrutura_inconsistencia = :id " +
                        "RETURNING id_produto_estrutura_inconsistencia;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.produto_estrutura_inconsistencia " +
                        "( " +
                        "  id_produto , " + 
                        "  id_produto_pai_filho , " + 
                        "  pri_data , " + 
                        "  pri_dados , " + 
                        "  pri_versao_estrutura , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto , " + 
                        "  :id_produto_pai_filho , " + 
                        "  :pri_data , " + 
                        "  :pri_dados , " + 
                        "  :pri_versao_estrutura , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_produto_estrutura_inconsistencia;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_pai_filho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ProdutoPaiFilho==null ? (object) DBNull.Value : this.ProdutoPaiFilho.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pri_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pri_dados", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Dados ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pri_versao_estrutura", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoEstrutura ?? DBNull.Value;
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
        public static ProdutoEstruturaInconsistenciaClass CopiarEntidade(ProdutoEstruturaInconsistenciaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProdutoEstruturaInconsistenciaClass toRet = new ProdutoEstruturaInconsistenciaClass(usuario,conn);
 toRet.Produto= entidadeCopiar.Produto;
 toRet.ProdutoPaiFilho= entidadeCopiar.ProdutoPaiFilho;
 toRet.Data= entidadeCopiar.Data;
 toRet.Dados= entidadeCopiar.Dados;
 toRet.VersaoEstrutura= entidadeCopiar.VersaoEstrutura;

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
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _produtoPaiFilhoOriginal = ProdutoPaiFilho;
       _produtoPaiFilhoOriginalCommited = _produtoPaiFilhoOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _dadosOriginal = Dados;
       _dadosOriginalCommited = _dadosOriginal;
       _versaoEstruturaOriginal = VersaoEstrutura;
       _versaoEstruturaOriginalCommited = _versaoEstruturaOriginal;
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
       _produtoOriginalCommited = Produto;
       _produtoPaiFilhoOriginalCommited = ProdutoPaiFilho;
       _dataOriginalCommited = Data;
       _dadosOriginalCommited = Dados;
       _versaoEstruturaOriginalCommited = VersaoEstrutura;
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
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               ProdutoPaiFilho=_produtoPaiFilhoOriginal;
               _produtoPaiFilhoOriginalCommited=_produtoPaiFilhoOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Dados=_dadosOriginal;
               _dadosOriginalCommited=_dadosOriginal;
               VersaoEstrutura=_versaoEstruturaOriginal;
               _versaoEstruturaOriginalCommited=_versaoEstruturaOriginal;
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
       if (_produtoOriginal!=null)
       {
          dirty = !_produtoOriginal.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       if (_produtoPaiFilhoOriginal!=null)
       {
          dirty = !_produtoPaiFilhoOriginal.Equals(ProdutoPaiFilho);
       }
       else
       {
            dirty = ProdutoPaiFilho != null;
       }
      if (dirty) return true;
       dirty = _dataOriginal != Data;
      if (dirty) return true;
       dirty = _dadosOriginal != Dados;
      if (dirty) return true;
       dirty = _versaoEstruturaOriginal != VersaoEstrutura;
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
       if (_produtoOriginalCommited!=null)
       {
          dirty = !_produtoOriginalCommited.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       if (_produtoPaiFilhoOriginalCommited!=null)
       {
          dirty = !_produtoPaiFilhoOriginalCommited.Equals(ProdutoPaiFilho);
       }
       else
       {
            dirty = ProdutoPaiFilho != null;
       }
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
       dirty = _dadosOriginalCommited != Dados;
      if (dirty) return true;
       dirty = _versaoEstruturaOriginalCommited != VersaoEstrutura;
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
             case "Produto":
                return this.Produto;
             case "ProdutoPaiFilho":
                return this.ProdutoPaiFilho;
             case "Data":
                return this.Data;
             case "Dados":
                return this.Dados;
             case "VersaoEstrutura":
                return this.VersaoEstrutura;
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
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (ProdutoPaiFilho!=null)
                ProdutoPaiFilho.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(produto_estrutura_inconsistencia.id_produto_estrutura_inconsistencia) " ;
               }
               else
               {
               command.CommandText += "produto_estrutura_inconsistencia.id_produto_estrutura_inconsistencia, " ;
               command.CommandText += "produto_estrutura_inconsistencia.id_produto, " ;
               command.CommandText += "produto_estrutura_inconsistencia.id_produto_pai_filho, " ;
               command.CommandText += "produto_estrutura_inconsistencia.pri_data, " ;
               command.CommandText += "produto_estrutura_inconsistencia.pri_dados, " ;
               command.CommandText += "produto_estrutura_inconsistencia.pri_versao_estrutura, " ;
               command.CommandText += "produto_estrutura_inconsistencia.version, " ;
               command.CommandText += "produto_estrutura_inconsistencia.entity_uid " ;
               }
               command.CommandText += " FROM  produto_estrutura_inconsistencia ";
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
                        orderByClause += " , pri_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pri_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = produto_estrutura_inconsistencia.id_acs_usuario_ultima_revisao ";
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
                     case "id_produto_estrutura_inconsistencia":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_estrutura_inconsistencia.id_produto_estrutura_inconsistencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_estrutura_inconsistencia.id_produto_estrutura_inconsistencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = produto_estrutura_inconsistencia.id_produto ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_Produto.pro_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_Produto.pro_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto_pai_filho":
                     case "ProdutoPaiFilho":
                     command.CommandText += " LEFT JOIN produto_pai_filho as produto_pai_filho_ProdutoPaiFilho ON produto_pai_filho_ProdutoPaiFilho.id_produto_pai_filho = produto_estrutura_inconsistencia.id_produto_pai_filho ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_pai_filho_ProdutoPaiFilho.id_produto_pai_filho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_pai_filho_ProdutoPaiFilho.id_produto_pai_filho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pri_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_estrutura_inconsistencia.pri_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_estrutura_inconsistencia.pri_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pri_dados":
                     case "Dados":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_estrutura_inconsistencia.pri_dados " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_estrutura_inconsistencia.pri_dados) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pri_versao_estrutura":
                     case "VersaoEstrutura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_estrutura_inconsistencia.pri_versao_estrutura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_estrutura_inconsistencia.pri_versao_estrutura) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , produto_estrutura_inconsistencia.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_estrutura_inconsistencia.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_estrutura_inconsistencia.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_estrutura_inconsistencia.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pri_dados")) 
                        {
                           whereClause += " OR UPPER(produto_estrutura_inconsistencia.pri_dados) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_estrutura_inconsistencia.pri_dados) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(produto_estrutura_inconsistencia.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_estrutura_inconsistencia.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_produto_estrutura_inconsistencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_estrutura_inconsistencia.id_produto_estrutura_inconsistencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.id_produto_estrutura_inconsistencia = :produto_estrutura_inconsistencia_ID_32 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_ID_32", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Produto" || parametro.FieldName == "id_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_estrutura_inconsistencia.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.id_produto = :produto_estrutura_inconsistencia_Produto_4053 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_Produto_4053", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoPaiFilho" || parametro.FieldName == "id_produto_pai_filho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoPaiFilhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoPaiFilhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_estrutura_inconsistencia.id_produto_pai_filho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.id_produto_pai_filho = :produto_estrutura_inconsistencia_ProdutoPaiFilho_5913 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_ProdutoPaiFilho_5913", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "pri_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_estrutura_inconsistencia.pri_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.pri_data = :produto_estrutura_inconsistencia_Data_489 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_Data_489", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dados" || parametro.FieldName == "pri_dados")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_estrutura_inconsistencia.pri_dados IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.pri_dados LIKE :produto_estrutura_inconsistencia_Dados_7620 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_Dados_7620", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoEstrutura" || parametro.FieldName == "pri_versao_estrutura")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_estrutura_inconsistencia.pri_versao_estrutura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.pri_versao_estrutura = :produto_estrutura_inconsistencia_VersaoEstrutura_4765 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_VersaoEstrutura_4765", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  produto_estrutura_inconsistencia.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.version = :produto_estrutura_inconsistencia_Version_9059 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_Version_9059", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  produto_estrutura_inconsistencia.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.entity_uid LIKE :produto_estrutura_inconsistencia_EntityUid_4695 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_EntityUid_4695", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DadosExato" || parametro.FieldName == "DadosExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_estrutura_inconsistencia.pri_dados IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.pri_dados LIKE :produto_estrutura_inconsistencia_Dados_5840 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_Dados_5840", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_estrutura_inconsistencia.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_estrutura_inconsistencia.entity_uid LIKE :produto_estrutura_inconsistencia_EntityUid_545 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_estrutura_inconsistencia_EntityUid_545", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProdutoEstruturaInconsistenciaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProdutoEstruturaInconsistenciaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProdutoEstruturaInconsistenciaClass), Convert.ToInt32(read["id_produto_estrutura_inconsistencia"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProdutoEstruturaInconsistenciaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_produto_estrutura_inconsistencia"]);
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     if (read["id_produto_pai_filho"] != DBNull.Value)
                     {
                        entidade.ProdutoPaiFilho = (BibliotecaEntidades.Entidades.ProdutoPaiFilhoClass)BibliotecaEntidades.Entidades.ProdutoPaiFilhoClass.GetEntidade(Convert.ToInt32(read["id_produto_pai_filho"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ProdutoPaiFilho = null ;
                     }
                     entidade.Data = (DateTime)read["pri_data"];
                     entidade.Dados = (read["pri_dados"] != DBNull.Value ? read["pri_dados"].ToString() : null);
                     entidade.VersaoEstrutura = read["pri_versao_estrutura"] as int?;
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProdutoEstruturaInconsistenciaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
