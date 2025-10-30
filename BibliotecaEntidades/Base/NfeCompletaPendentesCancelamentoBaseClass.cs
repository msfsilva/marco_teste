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
     [Table("nfe_completa_pendentes_cancelamento","npc")]
     public class NfeCompletaPendentesCancelamentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfeCompletaPendentesCancelamentoClass";
protected const string ErroDelete = "Erro ao excluir o NfeCompletaPendentesCancelamentoClass  ";
protected const string ErroSave = "Erro ao salvar o NfeCompletaPendentesCancelamentoClass.";
protected const string ErroCnpjEmitenteObrigatorio = "O campo CnpjEmitente é obrigatório";
protected const string ErroCnpjEmitenteComprimento = "O campo CnpjEmitente deve ter no máximo 30 caracteres";
protected const string ErroJustificativaObrigatorio = "O campo Justificativa é obrigatório";
protected const string ErroJustificativaComprimento = "O campo Justificativa deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroModeloObrigatorio = "O campo Modelo é obrigatório";
protected const string ErroModeloComprimento = "O campo Modelo deve ter no máximo 10 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do NfeCompletaPendentesCancelamentoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfeCompletaPendentesCancelamentoClass está sendo utilizada.";
#endregion
       protected int _numeroOriginal{get;private set;}
       private int _numeroOriginalCommited{get; set;}
        private int _valueNumero;
         [Column("npc_numero")]
        public virtual int Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected int _serieOriginal{get;private set;}
       private int _serieOriginalCommited{get; set;}
        private int _valueSerie;
         [Column("npc_serie")]
        public virtual int Serie
         { 
            get { return this._valueSerie; } 
            set 
            { 
                if (this._valueSerie == value)return;
                 this._valueSerie = value; 
            } 
        } 

       protected string _cnpjEmitenteOriginal{get;private set;}
       private string _cnpjEmitenteOriginalCommited{get; set;}
        private string _valueCnpjEmitente;
         [Column("npc_cnpj_emitente")]
        public virtual string CnpjEmitente
         { 
            get { return this._valueCnpjEmitente; } 
            set 
            { 
                if (this._valueCnpjEmitente == value)return;
                 this._valueCnpjEmitente = value; 
            } 
        } 

       protected string _justificativaOriginal{get;private set;}
       private string _justificativaOriginalCommited{get; set;}
        private string _valueJustificativa;
         [Column("npc_justificativa")]
        public virtual string Justificativa
         { 
            get { return this._valueJustificativa; } 
            set 
            { 
                if (this._valueJustificativa == value)return;
                 this._valueJustificativa = value; 
            } 
        } 

       protected bool _homologacaoOriginal{get;private set;}
       private bool _homologacaoOriginalCommited{get; set;}
        private bool _valueHomologacao;
         [Column("npc_homologacao")]
        public virtual bool Homologacao
         { 
            get { return this._valueHomologacao; } 
            set 
            { 
                if (this._valueHomologacao == value)return;
                 this._valueHomologacao = value; 
            } 
        } 

       protected string _modeloOriginal{get;private set;}
       private string _modeloOriginalCommited{get; set;}
        private string _valueModelo;
         [Column("npc_modelo")]
        public virtual string Modelo
         { 
            get { return this._valueModelo; } 
            set 
            { 
                if (this._valueModelo == value)return;
                 this._valueModelo = value; 
            } 
        } 

        public NfeCompletaPendentesCancelamentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Modelo = "55";
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfeCompletaPendentesCancelamentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfeCompletaPendentesCancelamentoClass) GetEntity(typeof(NfeCompletaPendentesCancelamentoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CnpjEmitente))
                {
                    throw new Exception(ErroCnpjEmitenteObrigatorio);
                }
                if (CnpjEmitente.Length >30)
                {
                    throw new Exception( ErroCnpjEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(Justificativa))
                {
                    throw new Exception(ErroJustificativaObrigatorio);
                }
                if (Justificativa.Length >255)
                {
                    throw new Exception( ErroJustificativaComprimento);
                }
                if (string.IsNullOrEmpty(Modelo))
                {
                    throw new Exception(ErroModeloObrigatorio);
                }
                if (Modelo.Length >10)
                {
                    throw new Exception( ErroModeloComprimento);
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
                    "  public.nfe_completa_pendentes_cancelamento  " +
                    "WHERE " +
                    "  id_nfe_completa_pendentes_cancelamento = :id";
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
                        "  public.nfe_completa_pendentes_cancelamento   " +
                        "SET  " + 
                        "  npc_numero = :npc_numero, " + 
                        "  npc_serie = :npc_serie, " + 
                        "  npc_cnpj_emitente = :npc_cnpj_emitente, " + 
                        "  npc_justificativa = :npc_justificativa, " + 
                        "  npc_homologacao = :npc_homologacao, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  npc_modelo = :npc_modelo "+
                        "WHERE  " +
                        "  id_nfe_completa_pendentes_cancelamento = :id " +
                        "RETURNING id_nfe_completa_pendentes_cancelamento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nfe_completa_pendentes_cancelamento " +
                        "( " +
                        "  npc_numero , " + 
                        "  npc_serie , " + 
                        "  npc_cnpj_emitente , " + 
                        "  npc_justificativa , " + 
                        "  npc_homologacao , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  npc_modelo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :npc_numero , " + 
                        "  :npc_serie , " + 
                        "  :npc_cnpj_emitente , " + 
                        "  :npc_justificativa , " + 
                        "  :npc_homologacao , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :npc_modelo  "+
                        ")RETURNING id_nfe_completa_pendentes_cancelamento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Serie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_cnpj_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Justificativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_homologacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Homologacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Modelo ?? DBNull.Value;

 
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
        public static NfeCompletaPendentesCancelamentoClass CopiarEntidade(NfeCompletaPendentesCancelamentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfeCompletaPendentesCancelamentoClass toRet = new NfeCompletaPendentesCancelamentoClass(usuario,conn);
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Serie= entidadeCopiar.Serie;
 toRet.CnpjEmitente= entidadeCopiar.CnpjEmitente;
 toRet.Justificativa= entidadeCopiar.Justificativa;
 toRet.Homologacao= entidadeCopiar.Homologacao;
 toRet.Modelo= entidadeCopiar.Modelo;

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
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _serieOriginal = Serie;
       _serieOriginalCommited = _serieOriginal;
       _cnpjEmitenteOriginal = CnpjEmitente;
       _cnpjEmitenteOriginalCommited = _cnpjEmitenteOriginal;
       _justificativaOriginal = Justificativa;
       _justificativaOriginalCommited = _justificativaOriginal;
       _homologacaoOriginal = Homologacao;
       _homologacaoOriginalCommited = _homologacaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _modeloOriginal = Modelo;
       _modeloOriginalCommited = _modeloOriginal;

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
       _numeroOriginalCommited = Numero;
       _serieOriginalCommited = Serie;
       _cnpjEmitenteOriginalCommited = CnpjEmitente;
       _justificativaOriginalCommited = Justificativa;
       _homologacaoOriginalCommited = Homologacao;
       _versionOriginalCommited = Version;
       _modeloOriginalCommited = Modelo;

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
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               Serie=_serieOriginal;
               _serieOriginalCommited=_serieOriginal;
               CnpjEmitente=_cnpjEmitenteOriginal;
               _cnpjEmitenteOriginalCommited=_cnpjEmitenteOriginal;
               Justificativa=_justificativaOriginal;
               _justificativaOriginalCommited=_justificativaOriginal;
               Homologacao=_homologacaoOriginal;
               _homologacaoOriginalCommited=_homologacaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Modelo=_modeloOriginal;
               _modeloOriginalCommited=_modeloOriginal;

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
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       dirty = _serieOriginal != Serie;
      if (dirty) return true;
       dirty = _cnpjEmitenteOriginal != CnpjEmitente;
      if (dirty) return true;
       dirty = _justificativaOriginal != Justificativa;
      if (dirty) return true;
       dirty = _homologacaoOriginal != Homologacao;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _modeloOriginal != Modelo;

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
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       dirty = _serieOriginalCommited != Serie;
      if (dirty) return true;
       dirty = _cnpjEmitenteOriginalCommited != CnpjEmitente;
      if (dirty) return true;
       dirty = _justificativaOriginalCommited != Justificativa;
      if (dirty) return true;
       dirty = _homologacaoOriginalCommited != Homologacao;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _modeloOriginalCommited != Modelo;

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
             case "Numero":
                return this.Numero;
             case "Serie":
                return this.Serie;
             case "CnpjEmitente":
                return this.CnpjEmitente;
             case "Justificativa":
                return this.Justificativa;
             case "Homologacao":
                return this.Homologacao;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "Modelo":
                return this.Modelo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
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
                  command.CommandText += " COUNT(nfe_completa_pendentes_cancelamento.id_nfe_completa_pendentes_cancelamento) " ;
               }
               else
               {
               command.CommandText += "nfe_completa_pendentes_cancelamento.id_nfe_completa_pendentes_cancelamento, " ;
               command.CommandText += "nfe_completa_pendentes_cancelamento.npc_numero, " ;
               command.CommandText += "nfe_completa_pendentes_cancelamento.npc_serie, " ;
               command.CommandText += "nfe_completa_pendentes_cancelamento.npc_cnpj_emitente, " ;
               command.CommandText += "nfe_completa_pendentes_cancelamento.npc_justificativa, " ;
               command.CommandText += "nfe_completa_pendentes_cancelamento.npc_homologacao, " ;
               command.CommandText += "nfe_completa_pendentes_cancelamento.version, " ;
               command.CommandText += "nfe_completa_pendentes_cancelamento.entity_uid, " ;
               command.CommandText += "nfe_completa_pendentes_cancelamento.npc_modelo " ;
               }
               command.CommandText += " FROM  nfe_completa_pendentes_cancelamento ";
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
                        orderByClause += " , npc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(npc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nfe_completa_pendentes_cancelamento.id_acs_usuario_ultima_revisao ";
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
                     case "id_nfe_completa_pendentes_cancelamento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completa_pendentes_cancelamento.id_nfe_completa_pendentes_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completa_pendentes_cancelamento.id_nfe_completa_pendentes_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completa_pendentes_cancelamento.npc_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completa_pendentes_cancelamento.npc_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_serie":
                     case "Serie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completa_pendentes_cancelamento.npc_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completa_pendentes_cancelamento.npc_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_cnpj_emitente":
                     case "CnpjEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completa_pendentes_cancelamento.npc_cnpj_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completa_pendentes_cancelamento.npc_cnpj_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_justificativa":
                     case "Justificativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completa_pendentes_cancelamento.npc_justificativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completa_pendentes_cancelamento.npc_justificativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_homologacao":
                     case "Homologacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completa_pendentes_cancelamento.npc_homologacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completa_pendentes_cancelamento.npc_homologacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nfe_completa_pendentes_cancelamento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completa_pendentes_cancelamento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completa_pendentes_cancelamento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completa_pendentes_cancelamento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_modelo":
                     case "Modelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completa_pendentes_cancelamento.npc_modelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completa_pendentes_cancelamento.npc_modelo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npc_cnpj_emitente")) 
                        {
                           whereClause += " OR UPPER(nfe_completa_pendentes_cancelamento.npc_cnpj_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completa_pendentes_cancelamento.npc_cnpj_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npc_justificativa")) 
                        {
                           whereClause += " OR UPPER(nfe_completa_pendentes_cancelamento.npc_justificativa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completa_pendentes_cancelamento.npc_justificativa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nfe_completa_pendentes_cancelamento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completa_pendentes_cancelamento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npc_modelo")) 
                        {
                           whereClause += " OR UPPER(nfe_completa_pendentes_cancelamento.npc_modelo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completa_pendentes_cancelamento.npc_modelo) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nfe_completa_pendentes_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.id_nfe_completa_pendentes_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.id_nfe_completa_pendentes_cancelamento = :nfe_completa_pendentes_cancelamento_ID_6090 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_ID_6090", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "npc_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_numero = :nfe_completa_pendentes_cancelamento_Numero_8081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_Numero_8081", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Serie" || parametro.FieldName == "npc_serie")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_serie = :nfe_completa_pendentes_cancelamento_Serie_8813 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_Serie_8813", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjEmitente" || parametro.FieldName == "npc_cnpj_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_cnpj_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_cnpj_emitente LIKE :nfe_completa_pendentes_cancelamento_CnpjEmitente_6084 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_CnpjEmitente_6084", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Justificativa" || parametro.FieldName == "npc_justificativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_justificativa LIKE :nfe_completa_pendentes_cancelamento_Justificativa_1580 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_Justificativa_1580", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Homologacao" || parametro.FieldName == "npc_homologacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_homologacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_homologacao = :nfe_completa_pendentes_cancelamento_Homologacao_2165 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_Homologacao_2165", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  nfe_completa_pendentes_cancelamento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.version = :nfe_completa_pendentes_cancelamento_Version_8883 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_Version_8883", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nfe_completa_pendentes_cancelamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.entity_uid LIKE :nfe_completa_pendentes_cancelamento_EntityUid_8701 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_EntityUid_8701", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Modelo" || parametro.FieldName == "npc_modelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_modelo LIKE :nfe_completa_pendentes_cancelamento_Modelo_864 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_Modelo_864", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjEmitenteExato" || parametro.FieldName == "CnpjEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_cnpj_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_cnpj_emitente LIKE :nfe_completa_pendentes_cancelamento_CnpjEmitente_146 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_CnpjEmitente_146", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_justificativa LIKE :nfe_completa_pendentes_cancelamento_Justificativa_906 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_Justificativa_906", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_completa_pendentes_cancelamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.entity_uid LIKE :nfe_completa_pendentes_cancelamento_EntityUid_6939 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_EntityUid_6939", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloExato" || parametro.FieldName == "ModeloExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completa_pendentes_cancelamento.npc_modelo LIKE :nfe_completa_pendentes_cancelamento_Modelo_7837 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completa_pendentes_cancelamento_Modelo_7837", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfeCompletaPendentesCancelamentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfeCompletaPendentesCancelamentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfeCompletaPendentesCancelamentoClass), Convert.ToInt32(read["id_nfe_completa_pendentes_cancelamento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfeCompletaPendentesCancelamentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nfe_completa_pendentes_cancelamento"]);
                     entidade.Numero = (int)read["npc_numero"];
                     entidade.Serie = (int)read["npc_serie"];
                     entidade.CnpjEmitente = (read["npc_cnpj_emitente"] != DBNull.Value ? read["npc_cnpj_emitente"].ToString() : null);
                     entidade.Justificativa = (read["npc_justificativa"] != DBNull.Value ? read["npc_justificativa"].ToString() : null);
                     entidade.Homologacao = Convert.ToBoolean(Convert.ToInt16(read["npc_homologacao"]));
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Modelo = (read["npc_modelo"] != DBNull.Value ? read["npc_modelo"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfeCompletaPendentesCancelamentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
