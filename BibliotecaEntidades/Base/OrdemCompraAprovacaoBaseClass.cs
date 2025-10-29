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
     [Table("ordem_compra_aprovacao","oca")]
     public class OrdemCompraAprovacaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemCompraAprovacaoClass";
protected const string ErroDelete = "Erro ao excluir o OrdemCompraAprovacaoClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemCompraAprovacaoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemCompraObrigatorio = "O campo OrdemCompra é obrigatório";
protected const string ErroAcsUsuarioAprovadorObrigatorio = "O campo AcsUsuarioAprovador é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemCompraAprovacaoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemCompraAprovacaoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrdemCompraClass _ordemCompraOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemCompraClass _ordemCompraOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemCompraClass _valueOrdemCompra;
        [Column("id_ordem_compra", "ordem_compra", "id_ordem_compra")]
       public virtual BibliotecaEntidades.Entidades.OrdemCompraClass OrdemCompra
        { 
           get {                 return this._valueOrdemCompra; } 
           set 
           { 
                if (this._valueOrdemCompra == value)return;
                 this._valueOrdemCompra = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioAprovadorOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioAprovadorOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioAprovador;
        [Column("id_acs_usuario_aprovador", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioAprovador
        { 
           get {                 return this._valueAcsUsuarioAprovador; } 
           set 
           { 
                if (this._valueAcsUsuarioAprovador == value)return;
                 this._valueAcsUsuarioAprovador = value; 
           } 
       } 

       protected int _sequenciaOriginal{get;private set;}
       private int _sequenciaOriginalCommited{get; set;}
        private int _valueSequencia;
         [Column("oca_sequencia")]
        public virtual int Sequencia
         { 
            get { return this._valueSequencia; } 
            set 
            { 
                if (this._valueSequencia == value)return;
                 this._valueSequencia = value; 
            } 
        } 

       protected DateTime _dataEntradaOriginal{get;private set;}
       private DateTime _dataEntradaOriginalCommited{get; set;}
        private DateTime _valueDataEntrada;
         [Column("oca_data_entrada")]
        public virtual DateTime DataEntrada
         { 
            get { return this._valueDataEntrada; } 
            set 
            { 
                if (this._valueDataEntrada == value)return;
                 this._valueDataEntrada = value; 
            } 
        } 

       protected bool? _aprovadoOriginal{get;private set;}
       private bool? _aprovadoOriginalCommited{get; set;}
        private bool? _valueAprovado;
         [Column("oca_aprovado")]
        public virtual bool? Aprovado
         { 
            get { return this._valueAprovado; } 
            set 
            { 
                if (this._valueAprovado == value)return;
                 this._valueAprovado = value; 
            } 
        } 

       protected DateTime? _dataAvaliacaoOriginal{get;private set;}
       private DateTime? _dataAvaliacaoOriginalCommited{get; set;}
        private DateTime? _valueDataAvaliacao;
         [Column("oca_data_avaliacao")]
        public virtual DateTime? DataAvaliacao
         { 
            get { return this._valueDataAvaliacao; } 
            set 
            { 
                if (this._valueDataAvaliacao == value)return;
                 this._valueDataAvaliacao = value; 
            } 
        } 

        public OrdemCompraAprovacaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Sequencia = 0;
           this.DataEntrada = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemCompraAprovacaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemCompraAprovacaoClass) GetEntity(typeof(OrdemCompraAprovacaoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueOrdemCompra == null)
                {
                    throw new Exception(ErroOrdemCompraObrigatorio);
                }
                if ( _valueAcsUsuarioAprovador == null)
                {
                    throw new Exception(ErroAcsUsuarioAprovadorObrigatorio);
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
                    "  public.ordem_compra_aprovacao  " +
                    "WHERE " +
                    "  id_ordem_compra_aprovacao = :id";
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
                        "  public.ordem_compra_aprovacao   " +
                        "SET  " + 
                        "  id_ordem_compra = :id_ordem_compra, " + 
                        "  id_acs_usuario_aprovador = :id_acs_usuario_aprovador, " + 
                        "  oca_sequencia = :oca_sequencia, " + 
                        "  oca_data_entrada = :oca_data_entrada, " + 
                        "  oca_aprovado = :oca_aprovado, " + 
                        "  oca_data_avaliacao = :oca_data_avaliacao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_compra_aprovacao = :id " +
                        "RETURNING id_ordem_compra_aprovacao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_compra_aprovacao " +
                        "( " +
                        "  id_ordem_compra , " + 
                        "  id_acs_usuario_aprovador , " + 
                        "  oca_sequencia , " + 
                        "  oca_data_entrada , " + 
                        "  oca_aprovado , " + 
                        "  oca_data_avaliacao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_compra , " + 
                        "  :id_acs_usuario_aprovador , " + 
                        "  :oca_sequencia , " + 
                        "  :oca_data_entrada , " + 
                        "  :oca_aprovado , " + 
                        "  :oca_data_avaliacao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_compra_aprovacao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemCompra==null ? (object) DBNull.Value : this.OrdemCompra.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_aprovador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioAprovador==null ? (object) DBNull.Value : this.AcsUsuarioAprovador.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oca_sequencia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Sequencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oca_data_entrada", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oca_aprovado", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aprovado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oca_data_avaliacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAvaliacao ?? DBNull.Value;
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
        public static OrdemCompraAprovacaoClass CopiarEntidade(OrdemCompraAprovacaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemCompraAprovacaoClass toRet = new OrdemCompraAprovacaoClass(usuario,conn);
 toRet.OrdemCompra= entidadeCopiar.OrdemCompra;
 toRet.AcsUsuarioAprovador= entidadeCopiar.AcsUsuarioAprovador;
 toRet.Sequencia= entidadeCopiar.Sequencia;
 toRet.DataEntrada= entidadeCopiar.DataEntrada;
 toRet.Aprovado= entidadeCopiar.Aprovado;
 toRet.DataAvaliacao= entidadeCopiar.DataAvaliacao;

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
       _ordemCompraOriginal = OrdemCompra;
       _ordemCompraOriginalCommited = _ordemCompraOriginal;
       _acsUsuarioAprovadorOriginal = AcsUsuarioAprovador;
       _acsUsuarioAprovadorOriginalCommited = _acsUsuarioAprovadorOriginal;
       _sequenciaOriginal = Sequencia;
       _sequenciaOriginalCommited = _sequenciaOriginal;
       _dataEntradaOriginal = DataEntrada;
       _dataEntradaOriginalCommited = _dataEntradaOriginal;
       _aprovadoOriginal = Aprovado;
       _aprovadoOriginalCommited = _aprovadoOriginal;
       _dataAvaliacaoOriginal = DataAvaliacao;
       _dataAvaliacaoOriginalCommited = _dataAvaliacaoOriginal;
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
       _ordemCompraOriginalCommited = OrdemCompra;
       _acsUsuarioAprovadorOriginalCommited = AcsUsuarioAprovador;
       _sequenciaOriginalCommited = Sequencia;
       _dataEntradaOriginalCommited = DataEntrada;
       _aprovadoOriginalCommited = Aprovado;
       _dataAvaliacaoOriginalCommited = DataAvaliacao;
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
               OrdemCompra=_ordemCompraOriginal;
               _ordemCompraOriginalCommited=_ordemCompraOriginal;
               AcsUsuarioAprovador=_acsUsuarioAprovadorOriginal;
               _acsUsuarioAprovadorOriginalCommited=_acsUsuarioAprovadorOriginal;
               Sequencia=_sequenciaOriginal;
               _sequenciaOriginalCommited=_sequenciaOriginal;
               DataEntrada=_dataEntradaOriginal;
               _dataEntradaOriginalCommited=_dataEntradaOriginal;
               Aprovado=_aprovadoOriginal;
               _aprovadoOriginalCommited=_aprovadoOriginal;
               DataAvaliacao=_dataAvaliacaoOriginal;
               _dataAvaliacaoOriginalCommited=_dataAvaliacaoOriginal;
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
       if (_ordemCompraOriginal!=null)
       {
          dirty = !_ordemCompraOriginal.Equals(OrdemCompra);
       }
       else
       {
            dirty = OrdemCompra != null;
       }
      if (dirty) return true;
       if (_acsUsuarioAprovadorOriginal!=null)
       {
          dirty = !_acsUsuarioAprovadorOriginal.Equals(AcsUsuarioAprovador);
       }
       else
       {
            dirty = AcsUsuarioAprovador != null;
       }
      if (dirty) return true;
       dirty = _sequenciaOriginal != Sequencia;
      if (dirty) return true;
       dirty = _dataEntradaOriginal != DataEntrada;
      if (dirty) return true;
       dirty = _aprovadoOriginal != Aprovado;
      if (dirty) return true;
       dirty = _dataAvaliacaoOriginal != DataAvaliacao;
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
       if (_ordemCompraOriginalCommited!=null)
       {
          dirty = !_ordemCompraOriginalCommited.Equals(OrdemCompra);
       }
       else
       {
            dirty = OrdemCompra != null;
       }
      if (dirty) return true;
       if (_acsUsuarioAprovadorOriginalCommited!=null)
       {
          dirty = !_acsUsuarioAprovadorOriginalCommited.Equals(AcsUsuarioAprovador);
       }
       else
       {
            dirty = AcsUsuarioAprovador != null;
       }
      if (dirty) return true;
       dirty = _sequenciaOriginalCommited != Sequencia;
      if (dirty) return true;
       dirty = _dataEntradaOriginalCommited != DataEntrada;
      if (dirty) return true;
       dirty = _aprovadoOriginalCommited != Aprovado;
      if (dirty) return true;
       dirty = _dataAvaliacaoOriginalCommited != DataAvaliacao;
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
             case "OrdemCompra":
                return this.OrdemCompra;
             case "AcsUsuarioAprovador":
                return this.AcsUsuarioAprovador;
             case "Sequencia":
                return this.Sequencia;
             case "DataEntrada":
                return this.DataEntrada;
             case "Aprovado":
                return this.Aprovado;
             case "DataAvaliacao":
                return this.DataAvaliacao;
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
             if (OrdemCompra!=null)
                OrdemCompra.ChangeSingleConnection(newConnection);
             if (AcsUsuarioAprovador!=null)
                AcsUsuarioAprovador.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(ordem_compra_aprovacao.id_ordem_compra_aprovacao) " ;
               }
               else
               {
               command.CommandText += "ordem_compra_aprovacao.id_ordem_compra_aprovacao, " ;
               command.CommandText += "ordem_compra_aprovacao.id_ordem_compra, " ;
               command.CommandText += "ordem_compra_aprovacao.id_acs_usuario_aprovador, " ;
               command.CommandText += "ordem_compra_aprovacao.oca_sequencia, " ;
               command.CommandText += "ordem_compra_aprovacao.oca_data_entrada, " ;
               command.CommandText += "ordem_compra_aprovacao.oca_aprovado, " ;
               command.CommandText += "ordem_compra_aprovacao.oca_data_avaliacao, " ;
               command.CommandText += "ordem_compra_aprovacao.entity_uid, " ;
               command.CommandText += "ordem_compra_aprovacao.version " ;
               }
               command.CommandText += " FROM  ordem_compra_aprovacao ";
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
                        orderByClause += " , oca_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(oca_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_compra_aprovacao.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_compra_aprovacao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra_aprovacao.id_ordem_compra_aprovacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra_aprovacao.id_ordem_compra_aprovacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_compra":
                     case "OrdemCompra":
                     command.CommandText += " LEFT JOIN ordem_compra as ordem_compra_OrdemCompra ON ordem_compra_OrdemCompra.id_ordem_compra = ordem_compra_aprovacao.id_ordem_compra ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra_OrdemCompra.id_ordem_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra_OrdemCompra.id_ordem_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_aprovador":
                     case "AcsUsuarioAprovador":
                     orderByClause += " , ordem_compra_aprovacao.id_acs_usuario_aprovador " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "oca_sequencia":
                     case "Sequencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra_aprovacao.oca_sequencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra_aprovacao.oca_sequencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oca_data_entrada":
                     case "DataEntrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra_aprovacao.oca_data_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra_aprovacao.oca_data_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oca_aprovado":
                     case "Aprovado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra_aprovacao.oca_aprovado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra_aprovacao.oca_aprovado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oca_data_avaliacao":
                     case "DataAvaliacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra_aprovacao.oca_data_avaliacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra_aprovacao.oca_data_avaliacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_compra_aprovacao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_compra_aprovacao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_compra_aprovacao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra_aprovacao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(ordem_compra_aprovacao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_compra_aprovacao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_compra_aprovacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra_aprovacao.id_ordem_compra_aprovacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.id_ordem_compra_aprovacao = :ordem_compra_aprovacao_ID_5594 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_ID_5594", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemCompra" || parametro.FieldName == "id_ordem_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemCompraClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemCompraClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra_aprovacao.id_ordem_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.id_ordem_compra = :ordem_compra_aprovacao_OrdemCompra_2689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_OrdemCompra_2689", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioAprovador" || parametro.FieldName == "id_acs_usuario_aprovador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra_aprovacao.id_acs_usuario_aprovador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.id_acs_usuario_aprovador = :ordem_compra_aprovacao_AcsUsuarioAprovador_8446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_AcsUsuarioAprovador_8446", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Sequencia" || parametro.FieldName == "oca_sequencia")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra_aprovacao.oca_sequencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.oca_sequencia = :ordem_compra_aprovacao_Sequencia_1585 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_Sequencia_1585", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrada" || parametro.FieldName == "oca_data_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra_aprovacao.oca_data_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.oca_data_entrada = :ordem_compra_aprovacao_DataEntrada_553 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_DataEntrada_553", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aprovado" || parametro.FieldName == "oca_aprovado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra_aprovacao.oca_aprovado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.oca_aprovado = :ordem_compra_aprovacao_Aprovado_6917 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_Aprovado_6917", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAvaliacao" || parametro.FieldName == "oca_data_avaliacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra_aprovacao.oca_data_avaliacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.oca_data_avaliacao = :ordem_compra_aprovacao_DataAvaliacao_4801 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_DataAvaliacao_4801", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  ordem_compra_aprovacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.entity_uid LIKE :ordem_compra_aprovacao_EntityUid_242 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_EntityUid_242", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_compra_aprovacao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.version = :ordem_compra_aprovacao_Version_2157 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_Version_2157", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_compra_aprovacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra_aprovacao.entity_uid LIKE :ordem_compra_aprovacao_EntityUid_6593 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_aprovacao_EntityUid_6593", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemCompraAprovacaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemCompraAprovacaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemCompraAprovacaoClass), Convert.ToInt32(read["id_ordem_compra_aprovacao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemCompraAprovacaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_compra_aprovacao"]);
                     if (read["id_ordem_compra"] != DBNull.Value)
                     {
                        entidade.OrdemCompra = (BibliotecaEntidades.Entidades.OrdemCompraClass)BibliotecaEntidades.Entidades.OrdemCompraClass.GetEntidade(Convert.ToInt32(read["id_ordem_compra"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemCompra = null ;
                     }
                     if (read["id_acs_usuario_aprovador"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioAprovador = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_aprovador"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioAprovador = null ;
                     }
                     entidade.Sequencia = (int)read["oca_sequencia"];
                     entidade.DataEntrada = (DateTime)read["oca_data_entrada"];
                     entidade.Aprovado = (read["oca_aprovado"] != DBNull.Value ? (bool?)Convert.ToBoolean(read["oca_aprovado"]) : null);
                     entidade.DataAvaliacao = read["oca_data_avaliacao"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemCompraAprovacaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
