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
     [Table("cob_boleto_instrucoes","bii")]
     public class CobBoletoInstrucoesBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do CobBoletoInstrucoesClass";
protected const string ErroDelete = "Erro ao excluir o CobBoletoInstrucoesClass  ";
protected const string ErroSave = "Erro ao salvar o CobBoletoInstrucoesClass.";
protected const string ErroInstrucaoObrigatorio = "O campo Instrucao é obrigatório";
protected const string ErroInstrucaoComprimento = "O campo Instrucao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCobBoletoObrigatorio = "O campo CobBoleto é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do CobBoletoInstrucoesClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade CobBoletoInstrucoesClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.CobBoletoClass _cobBoletoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CobBoletoClass _cobBoletoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CobBoletoClass _valueCobBoleto;
        [Column("id_cob_boleto", "cob_boleto", "id_cob_boleto")]
       public virtual BibliotecaEntidades.Entidades.CobBoletoClass CobBoleto
        { 
           get {                 return this._valueCobBoleto; } 
           set 
           { 
                if (this._valueCobBoleto == value)return;
                 this._valueCobBoleto = value; 
           } 
       } 

       protected string _instrucaoOriginal{get;private set;}
       private string _instrucaoOriginalCommited{get; set;}
        private string _valueInstrucao;
         [Column("bii_instrucao")]
        public virtual string Instrucao
         { 
            get { return this._valueInstrucao; } 
            set 
            { 
                if (this._valueInstrucao == value)return;
                 this._valueInstrucao = value; 
            } 
        } 

       protected CobrancaTipoInstrucao _tipoOriginal{get;private set;}
       private CobrancaTipoInstrucao _tipoOriginalCommited{get; set;}
        private CobrancaTipoInstrucao _valueTipo;
         [Column("bii_tipo")]
        public virtual CobrancaTipoInstrucao Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_LocalPagamrnto
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.LocalPagamrnto; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.LocalPagamrnto; }
         } 

        public bool Tipo_InstrucaoAoSacado
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.InstrucaoAoSacado; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.InstrucaoAoSacado; }
         } 

        public bool Tipo_Instrucao1
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao1; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao1; }
         } 

        public bool Tipo_Instrucao2
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao2; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao2; }
         } 

        public bool Tipo_Instrucao3
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao3; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao3; }
         } 

        public bool Tipo_Instrucao4
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao4; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao4; }
         } 

        public bool Tipo_Instrucao5
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao5; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao5; }
         } 

        public bool Tipo_Instrucao6
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao6; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao6; }
         } 

        public bool Tipo_Instrucao7
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao7; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao7; }
         } 

        public bool Tipo_Instrucao8
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao8; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.CobrancaTipoInstrucao.Instrucao8; }
         } 

        public CobBoletoInstrucoesBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Tipo = (CobrancaTipoInstrucao)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static CobBoletoInstrucoesClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (CobBoletoInstrucoesClass) GetEntity(typeof(CobBoletoInstrucoesClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Instrucao))
                {
                    throw new Exception(ErroInstrucaoObrigatorio);
                }
                if (Instrucao.Length >255)
                {
                    throw new Exception( ErroInstrucaoComprimento);
                }
                if ( _valueCobBoleto == null)
                {
                    throw new Exception(ErroCobBoletoObrigatorio);
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
                    "  public.cob_boleto_instrucoes  " +
                    "WHERE " +
                    "  id_cob_boleto_instrucoes = :id";
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
                        "  public.cob_boleto_instrucoes   " +
                        "SET  " + 
                        "  id_cob_boleto = :id_cob_boleto, " + 
                        "  bii_instrucao = :bii_instrucao, " + 
                        "  bii_tipo = :bii_tipo, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_cob_boleto_instrucoes = :id " +
                        "RETURNING id_cob_boleto_instrucoes;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.cob_boleto_instrucoes " +
                        "( " +
                        "  id_cob_boleto , " + 
                        "  bii_instrucao , " + 
                        "  bii_tipo , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_cob_boleto , " + 
                        "  :bii_instrucao , " + 
                        "  :bii_tipo , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_cob_boleto_instrucoes;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cob_boleto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CobBoleto==null ? (object) DBNull.Value : this.CobBoleto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bii_instrucao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Instrucao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bii_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
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
        public static CobBoletoInstrucoesClass CopiarEntidade(CobBoletoInstrucoesClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               CobBoletoInstrucoesClass toRet = new CobBoletoInstrucoesClass(usuario,conn);
 toRet.CobBoleto= entidadeCopiar.CobBoleto;
 toRet.Instrucao= entidadeCopiar.Instrucao;
 toRet.Tipo= entidadeCopiar.Tipo;

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
       _cobBoletoOriginal = CobBoleto;
       _cobBoletoOriginalCommited = _cobBoletoOriginal;
       _instrucaoOriginal = Instrucao;
       _instrucaoOriginalCommited = _instrucaoOriginal;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
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
       _cobBoletoOriginalCommited = CobBoleto;
       _instrucaoOriginalCommited = Instrucao;
       _tipoOriginalCommited = Tipo;
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
               CobBoleto=_cobBoletoOriginal;
               _cobBoletoOriginalCommited=_cobBoletoOriginal;
               Instrucao=_instrucaoOriginal;
               _instrucaoOriginalCommited=_instrucaoOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
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
       if (_cobBoletoOriginal!=null)
       {
          dirty = !_cobBoletoOriginal.Equals(CobBoleto);
       }
       else
       {
            dirty = CobBoleto != null;
       }
      if (dirty) return true;
       dirty = _instrucaoOriginal != Instrucao;
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;
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
       if (_cobBoletoOriginalCommited!=null)
       {
          dirty = !_cobBoletoOriginalCommited.Equals(CobBoleto);
       }
       else
       {
            dirty = CobBoleto != null;
       }
      if (dirty) return true;
       dirty = _instrucaoOriginalCommited != Instrucao;
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;
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
             case "CobBoleto":
                return this.CobBoleto;
             case "Instrucao":
                return this.Instrucao;
             case "Tipo":
                return this.Tipo;
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
             if (CobBoleto!=null)
                CobBoleto.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(cob_boleto_instrucoes.id_cob_boleto_instrucoes) " ;
               }
               else
               {
               command.CommandText += "cob_boleto_instrucoes.id_cob_boleto_instrucoes, " ;
               command.CommandText += "cob_boleto_instrucoes.id_cob_boleto, " ;
               command.CommandText += "cob_boleto_instrucoes.bii_instrucao, " ;
               command.CommandText += "cob_boleto_instrucoes.bii_tipo, " ;
               command.CommandText += "cob_boleto_instrucoes.entity_uid, " ;
               command.CommandText += "cob_boleto_instrucoes.version " ;
               }
               command.CommandText += " FROM  cob_boleto_instrucoes ";
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
                        orderByClause += " , bii_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(bii_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = cob_boleto_instrucoes.id_acs_usuario_ultima_revisao ";
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
                     case "id_cob_boleto_instrucoes":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_instrucoes.id_cob_boleto_instrucoes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_instrucoes.id_cob_boleto_instrucoes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cob_boleto":
                     case "CobBoleto":
                     command.CommandText += " LEFT JOIN cob_boleto as cob_boleto_CobBoleto ON cob_boleto_CobBoleto.id_cob_boleto = cob_boleto_instrucoes.id_cob_boleto ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto_CobBoleto.bol_nosso_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto_CobBoleto.bol_nosso_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bii_instrucao":
                     case "Instrucao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto_instrucoes.bii_instrucao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto_instrucoes.bii_instrucao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bii_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_instrucoes.bii_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_instrucoes.bii_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto_instrucoes.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto_instrucoes.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , cob_boleto_instrucoes.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_instrucoes.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bii_instrucao")) 
                        {
                           whereClause += " OR UPPER(cob_boleto_instrucoes.bii_instrucao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto_instrucoes.bii_instrucao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(cob_boleto_instrucoes.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto_instrucoes.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_cob_boleto_instrucoes")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_instrucoes.id_cob_boleto_instrucoes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_instrucoes.id_cob_boleto_instrucoes = :cob_boleto_instrucoes_ID_3684 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_instrucoes_ID_3684", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CobBoleto" || parametro.FieldName == "id_cob_boleto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CobBoletoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CobBoletoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_instrucoes.id_cob_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_instrucoes.id_cob_boleto = :cob_boleto_instrucoes_CobBoleto_4548 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_instrucoes_CobBoleto_4548", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Instrucao" || parametro.FieldName == "bii_instrucao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_instrucoes.bii_instrucao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_instrucoes.bii_instrucao LIKE :cob_boleto_instrucoes_Instrucao_4435 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_instrucoes_Instrucao_4435", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "bii_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is CobrancaTipoInstrucao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo CobrancaTipoInstrucao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_instrucoes.bii_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_instrucoes.bii_tipo = :cob_boleto_instrucoes_Tipo_3050 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_instrucoes_Tipo_3050", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  cob_boleto_instrucoes.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_instrucoes.entity_uid LIKE :cob_boleto_instrucoes_EntityUid_812 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_instrucoes_EntityUid_812", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  cob_boleto_instrucoes.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_instrucoes.version = :cob_boleto_instrucoes_Version_8006 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_instrucoes_Version_8006", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InstrucaoExato" || parametro.FieldName == "InstrucaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_instrucoes.bii_instrucao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_instrucoes.bii_instrucao LIKE :cob_boleto_instrucoes_Instrucao_5670 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_instrucoes_Instrucao_5670", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cob_boleto_instrucoes.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_instrucoes.entity_uid LIKE :cob_boleto_instrucoes_EntityUid_3894 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_instrucoes_EntityUid_3894", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  CobBoletoInstrucoesClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (CobBoletoInstrucoesClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(CobBoletoInstrucoesClass), Convert.ToInt32(read["id_cob_boleto_instrucoes"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new CobBoletoInstrucoesClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_cob_boleto_instrucoes"]);
                     if (read["id_cob_boleto"] != DBNull.Value)
                     {
                        entidade.CobBoleto = (BibliotecaEntidades.Entidades.CobBoletoClass)BibliotecaEntidades.Entidades.CobBoletoClass.GetEntidade(Convert.ToInt32(read["id_cob_boleto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CobBoleto = null ;
                     }
                     entidade.Instrucao = (read["bii_instrucao"] != DBNull.Value ? read["bii_instrucao"].ToString() : null);
                     entidade.Tipo = (CobrancaTipoInstrucao) (read["bii_tipo"] != DBNull.Value ? Enum.ToObject(typeof(CobrancaTipoInstrucao), read["bii_tipo"]) : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (CobBoletoInstrucoesClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
