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
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("produto_preco","prp")]
     public class ProdutoPrecoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProdutoPrecoClass";
protected const string ErroDelete = "Erro ao excluir o ProdutoPrecoClass  ";
protected const string ErroSave = "Erro ao salvar o ProdutoPrecoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ProdutoPrecoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoPrecoClass está sendo utilizada.";
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

       protected double _precoOriginal{get;private set;}
       private double _precoOriginalCommited{get; set;}
        private double _valuePreco;
         [Column("prp_preco")]
        public virtual double Preco
         { 
            get { return this._valuePreco; } 
            set 
            { 
                if (this._valuePreco == value)return;
                 this._valuePreco = value; 
            } 
        } 

       protected string _regraOriginal{get;private set;}
       private string _regraOriginalCommited{get; set;}
        private string _valueRegra;
         [Column("prp_regra")]
        public virtual string Regra
         { 
            get { return this._valueRegra; } 
            set 
            { 
                if (this._valueRegra == value)return;
                 this._valueRegra = value; 
            } 
        } 

       protected DateTime _inicioVigenciaOriginal{get;private set;}
       private DateTime _inicioVigenciaOriginalCommited{get; set;}
        private DateTime _valueInicioVigencia;
         [Column("prp_inicio_vigencia")]
        public virtual DateTime InicioVigencia
         { 
            get { return this._valueInicioVigencia; } 
            set 
            { 
                if (this._valueInicioVigencia == value)return;
                 this._valueInicioVigencia = value; 
            } 
        } 

       protected DateTime? _fimVigenciaOriginal{get;private set;}
       private DateTime? _fimVigenciaOriginalCommited{get; set;}
        private DateTime? _valueFimVigencia;
         [Column("prp_fim_vigencia")]
        public virtual DateTime? FimVigencia
         { 
            get { return this._valueFimVigencia; } 
            set 
            { 
                if (this._valueFimVigencia == value)return;
                 this._valueFimVigencia = value; 
            } 
        } 

       protected string _justificativaOriginal{get;private set;}
       private string _justificativaOriginalCommited{get; set;}
        private string _valueJustificativa;
         [Column("prp_justificativa")]
        public virtual string Justificativa
         { 
            get { return this._valueJustificativa; } 
            set 
            { 
                if (this._valueJustificativa == value)return;
                 this._valueJustificativa = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuario;
        [Column("id_acs_usuario", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuario
        { 
           get {                 return this._valueAcsUsuario; } 
           set 
           { 
                if (this._valueAcsUsuario == value)return;
                 this._valueAcsUsuario = value; 
           } 
       } 

        public ProdutoPrecoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Preco = 0;
           this.InicioVigencia = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ProdutoPrecoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProdutoPrecoClass) GetEntity(typeof(ProdutoPrecoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueProduto == null)
                {
                    throw new Exception(ErroProdutoObrigatorio);
                }
                if ( _valueAcsUsuario == null)
                {
                    throw new Exception(ErroAcsUsuarioObrigatorio);
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
                    "  public.produto_preco  " +
                    "WHERE " +
                    "  id_produto_preco = :id";
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
                        "  public.produto_preco   " +
                        "SET  " + 
                        "  id_produto = :id_produto, " + 
                        "  prp_preco = :prp_preco, " + 
                        "  prp_regra = :prp_regra, " + 
                        "  prp_inicio_vigencia = :prp_inicio_vigencia, " + 
                        "  prp_fim_vigencia = :prp_fim_vigencia, " + 
                        "  prp_justificativa = :prp_justificativa, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_produto_preco = :id " +
                        "RETURNING id_produto_preco;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.produto_preco " +
                        "( " +
                        "  id_produto , " + 
                        "  prp_preco , " + 
                        "  prp_regra , " + 
                        "  prp_inicio_vigencia , " + 
                        "  prp_fim_vigencia , " + 
                        "  prp_justificativa , " + 
                        "  id_acs_usuario , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto , " + 
                        "  :prp_preco , " + 
                        "  :prp_regra , " + 
                        "  :prp_inicio_vigencia , " + 
                        "  :prp_fim_vigencia , " + 
                        "  :prp_justificativa , " + 
                        "  :id_acs_usuario , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_produto_preco;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prp_preco", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Preco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prp_regra", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Regra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prp_inicio_vigencia", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InicioVigencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prp_fim_vigencia", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FimVigencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prp_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Justificativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
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
        public static ProdutoPrecoClass CopiarEntidade(ProdutoPrecoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProdutoPrecoClass toRet = new ProdutoPrecoClass(usuario,conn);
 toRet.Produto= entidadeCopiar.Produto;
 toRet.Preco= entidadeCopiar.Preco;
 toRet.Regra= entidadeCopiar.Regra;
 toRet.InicioVigencia= entidadeCopiar.InicioVigencia;
 toRet.FimVigencia= entidadeCopiar.FimVigencia;
 toRet.Justificativa= entidadeCopiar.Justificativa;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;

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
       _precoOriginal = Preco;
       _precoOriginalCommited = _precoOriginal;
       _regraOriginal = Regra;
       _regraOriginalCommited = _regraOriginal;
       _inicioVigenciaOriginal = InicioVigencia;
       _inicioVigenciaOriginalCommited = _inicioVigenciaOriginal;
       _fimVigenciaOriginal = FimVigencia;
       _fimVigenciaOriginalCommited = _fimVigenciaOriginal;
       _justificativaOriginal = Justificativa;
       _justificativaOriginalCommited = _justificativaOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
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
       _precoOriginalCommited = Preco;
       _regraOriginalCommited = Regra;
       _inicioVigenciaOriginalCommited = InicioVigencia;
       _fimVigenciaOriginalCommited = FimVigencia;
       _justificativaOriginalCommited = Justificativa;
       _acsUsuarioOriginalCommited = AcsUsuario;
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
               Preco=_precoOriginal;
               _precoOriginalCommited=_precoOriginal;
               Regra=_regraOriginal;
               _regraOriginalCommited=_regraOriginal;
               InicioVigencia=_inicioVigenciaOriginal;
               _inicioVigenciaOriginalCommited=_inicioVigenciaOriginal;
               FimVigencia=_fimVigenciaOriginal;
               _fimVigenciaOriginalCommited=_fimVigenciaOriginal;
               Justificativa=_justificativaOriginal;
               _justificativaOriginalCommited=_justificativaOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
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
       dirty = _precoOriginal != Preco;
      if (dirty) return true;
       dirty = _regraOriginal != Regra;
      if (dirty) return true;
       dirty = _inicioVigenciaOriginal != InicioVigencia;
      if (dirty) return true;
       dirty = _fimVigenciaOriginal != FimVigencia;
      if (dirty) return true;
       dirty = _justificativaOriginal != Justificativa;
      if (dirty) return true;
       if (_acsUsuarioOriginal!=null)
       {
          dirty = !_acsUsuarioOriginal.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
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
       if (_produtoOriginalCommited!=null)
       {
          dirty = !_produtoOriginalCommited.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       dirty = _precoOriginalCommited != Preco;
      if (dirty) return true;
       dirty = _regraOriginalCommited != Regra;
      if (dirty) return true;
       dirty = _inicioVigenciaOriginalCommited != InicioVigencia;
      if (dirty) return true;
       dirty = _fimVigenciaOriginalCommited != FimVigencia;
      if (dirty) return true;
       dirty = _justificativaOriginalCommited != Justificativa;
      if (dirty) return true;
       if (_acsUsuarioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioOriginalCommited.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
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
             case "Produto":
                return this.Produto;
             case "Preco":
                return this.Preco;
             case "Regra":
                return this.Regra;
             case "InicioVigencia":
                return this.InicioVigencia;
             case "FimVigencia":
                return this.FimVigencia;
             case "Justificativa":
                return this.Justificativa;
             case "AcsUsuario":
                return this.AcsUsuario;
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
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(produto_preco.id_produto_preco) " ;
               }
               else
               {
               command.CommandText += "produto_preco.id_produto_preco, " ;
               command.CommandText += "produto_preco.id_produto, " ;
               command.CommandText += "produto_preco.prp_preco, " ;
               command.CommandText += "produto_preco.prp_regra, " ;
               command.CommandText += "produto_preco.prp_inicio_vigencia, " ;
               command.CommandText += "produto_preco.prp_fim_vigencia, " ;
               command.CommandText += "produto_preco.prp_justificativa, " ;
               command.CommandText += "produto_preco.id_acs_usuario, " ;
               command.CommandText += "produto_preco.entity_uid, " ;
               command.CommandText += "produto_preco.version " ;
               }
               command.CommandText += " FROM  produto_preco ";
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
                        orderByClause += " , prp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(prp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = produto_preco.id_acs_usuario_ultima_revisao ";
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
                     case "id_produto_preco":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_preco.id_produto_preco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_preco.id_produto_preco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = produto_preco.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "prp_preco":
                     case "Preco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_preco.prp_preco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_preco.prp_preco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prp_regra":
                     case "Regra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_preco.prp_regra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_preco.prp_regra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prp_inicio_vigencia":
                     case "InicioVigencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_preco.prp_inicio_vigencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_preco.prp_inicio_vigencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prp_fim_vigencia":
                     case "FimVigencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_preco.prp_fim_vigencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_preco.prp_fim_vigencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prp_justificativa":
                     case "Justificativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_preco.prp_justificativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_preco.prp_justificativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , produto_preco.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_preco.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_preco.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , produto_preco.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_preco.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prp_regra")) 
                        {
                           whereClause += " OR UPPER(produto_preco.prp_regra) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_preco.prp_regra) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prp_justificativa")) 
                        {
                           whereClause += " OR UPPER(produto_preco.prp_justificativa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_preco.prp_justificativa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(produto_preco.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_preco.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_produto_preco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_preco.id_produto_preco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.id_produto_preco = :produto_preco_ID_3991 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_ID_3991", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  produto_preco.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.id_produto = :produto_preco_Produto_1236 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_Produto_1236", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Preco" || parametro.FieldName == "prp_preco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_preco.prp_preco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.prp_preco = :produto_preco_Preco_2453 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_Preco_2453", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Regra" || parametro.FieldName == "prp_regra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_preco.prp_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.prp_regra LIKE :produto_preco_Regra_7659 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_Regra_7659", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InicioVigencia" || parametro.FieldName == "prp_inicio_vigencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_preco.prp_inicio_vigencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.prp_inicio_vigencia = :produto_preco_InicioVigencia_9638 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_InicioVigencia_9638", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FimVigencia" || parametro.FieldName == "prp_fim_vigencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_preco.prp_fim_vigencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.prp_fim_vigencia = :produto_preco_FimVigencia_1442 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_FimVigencia_1442", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Justificativa" || parametro.FieldName == "prp_justificativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_preco.prp_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.prp_justificativa LIKE :produto_preco_Justificativa_4073 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_Justificativa_4073", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuario" || parametro.FieldName == "id_acs_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_preco.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.id_acs_usuario = :produto_preco_AcsUsuario_239 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_AcsUsuario_239", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  produto_preco.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.entity_uid LIKE :produto_preco_EntityUid_4718 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_EntityUid_4718", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_preco.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.version = :produto_preco_Version_1403 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_Version_1403", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegraExato" || parametro.FieldName == "RegraExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_preco.prp_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.prp_regra LIKE :produto_preco_Regra_8146 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_Regra_8146", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaExato" || parametro.FieldName == "JustificativaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_preco.prp_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.prp_justificativa LIKE :produto_preco_Justificativa_9506 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_Justificativa_9506", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_preco.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_preco.entity_uid LIKE :produto_preco_EntityUid_8945 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_preco_EntityUid_8945", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProdutoPrecoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProdutoPrecoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProdutoPrecoClass), Convert.ToInt32(read["id_produto_preco"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProdutoPrecoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_produto_preco"]);
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     entidade.Preco = (double)read["prp_preco"];
                     entidade.Regra = (read["prp_regra"] != DBNull.Value ? read["prp_regra"].ToString() : null);
                     entidade.InicioVigencia = (DateTime)read["prp_inicio_vigencia"];
                     entidade.FimVigencia = read["prp_fim_vigencia"] as DateTime?;
                     entidade.Justificativa = (read["prp_justificativa"] != DBNull.Value ? read["prp_justificativa"].ToString() : null);
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProdutoPrecoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
