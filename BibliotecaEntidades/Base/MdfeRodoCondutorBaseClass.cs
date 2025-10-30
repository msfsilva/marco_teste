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
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNFCompleto.BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("mdfe_rodo_condutor","mrc")]
     public class MdfeRodoCondutorBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MdfeRodoCondutorClass";
protected const string ErroDelete = "Erro ao excluir o MdfeRodoCondutorClass  ";
protected const string ErroSave = "Erro ao salvar o MdfeRodoCondutorClass.";
protected const string ErroNomeCondutorObrigatorio = "O campo NomeCondutor é obrigatório";
protected const string ErroNomeCondutorComprimento = "O campo NomeCondutor deve ter no máximo 60 caracteres";
protected const string ErroCpfObrigatorio = "O campo Cpf é obrigatório";
protected const string ErroCpfComprimento = "O campo Cpf deve ter no máximo 11 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroMdfeModalRodoviarioObrigatorio = "O campo MdfeModalRodoviario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do MdfeRodoCondutorClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeRodoCondutorClass está sendo utilizada.";
#endregion
       protected IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass _mdfeModalRodoviarioOriginal{get;private set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass _mdfeModalRodoviarioOriginalCommited {get; set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass _valueMdfeModalRodoviario;
        [Column("id_mdfe_modal_rodoviario", "mdfe_modal_rodoviario", "id_mdfe_modal_rodoviario")]
       public virtual IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass MdfeModalRodoviario
        { 
           get {                 return this._valueMdfeModalRodoviario; } 
           set 
           { 
                if (this._valueMdfeModalRodoviario == value)return;
                 this._valueMdfeModalRodoviario = value; 
           } 
       } 

       protected string _nomeCondutorOriginal{get;private set;}
       private string _nomeCondutorOriginalCommited{get; set;}
        private string _valueNomeCondutor;
         [Column("mrc_nome_condutor")]
        public virtual string NomeCondutor
         { 
            get { return this._valueNomeCondutor; } 
            set 
            { 
                if (this._valueNomeCondutor == value)return;
                 this._valueNomeCondutor = value; 
            } 
        } 

       protected string _cpfOriginal{get;private set;}
       private string _cpfOriginalCommited{get; set;}
        private string _valueCpf;
         [Column("mrc_cpf")]
        public virtual string Cpf
         { 
            get { return this._valueCpf; } 
            set 
            { 
                if (this._valueCpf == value)return;
                 this._valueCpf = value; 
            } 
        } 

        public MdfeRodoCondutorBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static MdfeRodoCondutorClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MdfeRodoCondutorClass) GetEntity(typeof(MdfeRodoCondutorClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NomeCondutor))
                {
                    throw new Exception(ErroNomeCondutorObrigatorio);
                }
                if (NomeCondutor.Length >60)
                {
                    throw new Exception( ErroNomeCondutorComprimento);
                }
                if (string.IsNullOrEmpty(Cpf))
                {
                    throw new Exception(ErroCpfObrigatorio);
                }
                if (Cpf.Length >11)
                {
                    throw new Exception( ErroCpfComprimento);
                }
                if ( _valueMdfeModalRodoviario == null)
                {
                    throw new Exception(ErroMdfeModalRodoviarioObrigatorio);
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
                    "  public.mdfe_rodo_condutor  " +
                    "WHERE " +
                    "  id_mdfe_rodo_condutor = :id";
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
                        "  public.mdfe_rodo_condutor   " +
                        "SET  " + 
                        "  id_mdfe_modal_rodoviario = :id_mdfe_modal_rodoviario, " + 
                        "  mrc_nome_condutor = :mrc_nome_condutor, " + 
                        "  mrc_cpf = :mrc_cpf, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_mdfe_rodo_condutor = :id " +
                        "RETURNING id_mdfe_rodo_condutor;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.mdfe_rodo_condutor " +
                        "( " +
                        "  id_mdfe_modal_rodoviario , " + 
                        "  mrc_nome_condutor , " + 
                        "  mrc_cpf , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_mdfe_modal_rodoviario , " + 
                        "  :mrc_nome_condutor , " + 
                        "  :mrc_cpf , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_mdfe_rodo_condutor;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_mdfe_modal_rodoviario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.MdfeModalRodoviario==null ? (object) DBNull.Value : this.MdfeModalRodoviario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrc_nome_condutor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeCondutor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrc_cpf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cpf ?? DBNull.Value;
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
        public static MdfeRodoCondutorClass CopiarEntidade(MdfeRodoCondutorClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MdfeRodoCondutorClass toRet = new MdfeRodoCondutorClass(usuario,conn);
 toRet.MdfeModalRodoviario= entidadeCopiar.MdfeModalRodoviario;
 toRet.NomeCondutor= entidadeCopiar.NomeCondutor;
 toRet.Cpf= entidadeCopiar.Cpf;

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
       _mdfeModalRodoviarioOriginal = MdfeModalRodoviario;
       _mdfeModalRodoviarioOriginalCommited = _mdfeModalRodoviarioOriginal;
       _nomeCondutorOriginal = NomeCondutor;
       _nomeCondutorOriginalCommited = _nomeCondutorOriginal;
       _cpfOriginal = Cpf;
       _cpfOriginalCommited = _cpfOriginal;
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
       _mdfeModalRodoviarioOriginalCommited = MdfeModalRodoviario;
       _nomeCondutorOriginalCommited = NomeCondutor;
       _cpfOriginalCommited = Cpf;
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
               MdfeModalRodoviario=_mdfeModalRodoviarioOriginal;
               _mdfeModalRodoviarioOriginalCommited=_mdfeModalRodoviarioOriginal;
               NomeCondutor=_nomeCondutorOriginal;
               _nomeCondutorOriginalCommited=_nomeCondutorOriginal;
               Cpf=_cpfOriginal;
               _cpfOriginalCommited=_cpfOriginal;
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
       if (_mdfeModalRodoviarioOriginal!=null)
       {
          dirty = !_mdfeModalRodoviarioOriginal.Equals(MdfeModalRodoviario);
       }
       else
       {
            dirty = MdfeModalRodoviario != null;
       }
      if (dirty) return true;
       dirty = _nomeCondutorOriginal != NomeCondutor;
      if (dirty) return true;
       dirty = _cpfOriginal != Cpf;
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
       if (_mdfeModalRodoviarioOriginalCommited!=null)
       {
          dirty = !_mdfeModalRodoviarioOriginalCommited.Equals(MdfeModalRodoviario);
       }
       else
       {
            dirty = MdfeModalRodoviario != null;
       }
      if (dirty) return true;
       dirty = _nomeCondutorOriginalCommited != NomeCondutor;
      if (dirty) return true;
       dirty = _cpfOriginalCommited != Cpf;
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
             case "MdfeModalRodoviario":
                return this.MdfeModalRodoviario;
             case "NomeCondutor":
                return this.NomeCondutor;
             case "Cpf":
                return this.Cpf;
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
             if (MdfeModalRodoviario!=null)
                MdfeModalRodoviario.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(mdfe_rodo_condutor.id_mdfe_rodo_condutor) " ;
               }
               else
               {
               command.CommandText += "mdfe_rodo_condutor.id_mdfe_rodo_condutor, " ;
               command.CommandText += "mdfe_rodo_condutor.id_mdfe_modal_rodoviario, " ;
               command.CommandText += "mdfe_rodo_condutor.mrc_nome_condutor, " ;
               command.CommandText += "mdfe_rodo_condutor.mrc_cpf, " ;
               command.CommandText += "mdfe_rodo_condutor.version, " ;
               command.CommandText += "mdfe_rodo_condutor.entity_uid " ;
               }
               command.CommandText += " FROM  mdfe_rodo_condutor ";
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
                        orderByClause += " , mrc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mrc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = mdfe_rodo_condutor.id_acs_usuario_ultima_revisao ";
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
                     case "id_mdfe_rodo_condutor":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_condutor.id_mdfe_rodo_condutor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_condutor.id_mdfe_rodo_condutor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_mdfe_modal_rodoviario":
                     case "MdfeModalRodoviario":
                     orderByClause += " , mdfe_rodo_condutor.id_mdfe_modal_rodoviario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "mrc_nome_condutor":
                     case "NomeCondutor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_condutor.mrc_nome_condutor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_condutor.mrc_nome_condutor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrc_cpf":
                     case "Cpf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_condutor.mrc_cpf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_condutor.mrc_cpf) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , mdfe_rodo_condutor.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_condutor.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_condutor.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_condutor.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrc_nome_condutor")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_condutor.mrc_nome_condutor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_condutor.mrc_nome_condutor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrc_cpf")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_condutor.mrc_cpf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_condutor.mrc_cpf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_condutor.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_condutor.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_mdfe_rodo_condutor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_condutor.id_mdfe_rodo_condutor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_condutor.id_mdfe_rodo_condutor = :mdfe_rodo_condutor_ID_5359 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_condutor_ID_5359", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MdfeModalRodoviario" || parametro.FieldName == "id_mdfe_modal_rodoviario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_condutor.id_mdfe_modal_rodoviario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_condutor.id_mdfe_modal_rodoviario = :mdfe_rodo_condutor_MdfeModalRodoviario_1776 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_condutor_MdfeModalRodoviario_1776", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeCondutor" || parametro.FieldName == "mrc_nome_condutor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_condutor.mrc_nome_condutor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_condutor.mrc_nome_condutor LIKE :mdfe_rodo_condutor_NomeCondutor_2457 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_condutor_NomeCondutor_2457", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cpf" || parametro.FieldName == "mrc_cpf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_condutor.mrc_cpf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_condutor.mrc_cpf LIKE :mdfe_rodo_condutor_Cpf_7689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_condutor_Cpf_7689", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  mdfe_rodo_condutor.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_condutor.version = :mdfe_rodo_condutor_Version_6231 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_condutor_Version_6231", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_rodo_condutor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_condutor.entity_uid LIKE :mdfe_rodo_condutor_EntityUid_6132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_condutor_EntityUid_6132", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeCondutorExato" || parametro.FieldName == "NomeCondutorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_condutor.mrc_nome_condutor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_condutor.mrc_nome_condutor LIKE :mdfe_rodo_condutor_NomeCondutor_5879 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_condutor_NomeCondutor_5879", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfExato" || parametro.FieldName == "CpfExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_condutor.mrc_cpf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_condutor.mrc_cpf LIKE :mdfe_rodo_condutor_Cpf_2638 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_condutor_Cpf_2638", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_rodo_condutor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_condutor.entity_uid LIKE :mdfe_rodo_condutor_EntityUid_5483 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_condutor_EntityUid_5483", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MdfeRodoCondutorClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MdfeRodoCondutorClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MdfeRodoCondutorClass), Convert.ToInt32(read["id_mdfe_rodo_condutor"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MdfeRodoCondutorClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_mdfe_rodo_condutor"]);
                     if (read["id_mdfe_modal_rodoviario"] != DBNull.Value)
                     {
                        entidade.MdfeModalRodoviario = (IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass)IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass.GetEntidade(Convert.ToInt32(read["id_mdfe_modal_rodoviario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.MdfeModalRodoviario = null ;
                     }
                     entidade.NomeCondutor = (read["mrc_nome_condutor"] != DBNull.Value ? read["mrc_nome_condutor"].ToString() : null);
                     entidade.Cpf = (read["mrc_cpf"] != DBNull.Value ? read["mrc_cpf"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MdfeRodoCondutorClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
