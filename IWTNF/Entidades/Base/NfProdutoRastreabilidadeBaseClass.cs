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
     [Table("nf_produto_rastreabilidade","npr")]
     public class NfProdutoRastreabilidadeBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoRastreabilidadeClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoRastreabilidadeClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoRastreabilidadeClass.";
protected const string ErroNumeroLoteObrigatorio = "O campo NumeroLote é obrigatório";
protected const string ErroNumeroLoteComprimento = "O campo NumeroLote deve ter no máximo 20 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfProdutoObrigatorio = "O campo NfProduto é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoRastreabilidadeClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoRastreabilidadeClass está sendo utilizada.";
#endregion
       protected IWTNF.Entidades.Entidades.NfProdutoClass _nfProdutoOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfProdutoClass _nfProdutoOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfProdutoClass _valueNfProduto;
        [Column("id_nf_produto", "nf_produto", "id_nf_produto")]
       public virtual IWTNF.Entidades.Entidades.NfProdutoClass NfProduto
        { 
           get {                 return this._valueNfProduto; } 
           set 
           { 
                if (this._valueNfProduto == value)return;
                 this._valueNfProduto = value; 
           } 
       } 

       protected string _numeroLoteOriginal{get;private set;}
       private string _numeroLoteOriginalCommited{get; set;}
        private string _valueNumeroLote;
         [Column("npr_numero_lote")]
        public virtual string NumeroLote
         { 
            get { return this._valueNumeroLote; } 
            set 
            { 
                if (this._valueNumeroLote == value)return;
                 this._valueNumeroLote = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("npr_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected DateTime _dataFabricacaoOriginal{get;private set;}
       private DateTime _dataFabricacaoOriginalCommited{get; set;}
        private DateTime _valueDataFabricacao;
         [Column("npr_data_fabricacao")]
        public virtual DateTime DataFabricacao
         { 
            get { return this._valueDataFabricacao; } 
            set 
            { 
                if (this._valueDataFabricacao == value)return;
                 this._valueDataFabricacao = value; 
            } 
        } 

       protected DateTime _dataValidadeOriginal{get;private set;}
       private DateTime _dataValidadeOriginalCommited{get; set;}
        private DateTime _valueDataValidade;
         [Column("npr_data_validade")]
        public virtual DateTime DataValidade
         { 
            get { return this._valueDataValidade; } 
            set 
            { 
                if (this._valueDataValidade == value)return;
                 this._valueDataValidade = value; 
            } 
        } 

       protected string _codigoAgregacaoOriginal{get;private set;}
       private string _codigoAgregacaoOriginalCommited{get; set;}
        private string _valueCodigoAgregacao;
         [Column("npr_codigo_agregacao")]
        public virtual string CodigoAgregacao
         { 
            get { return this._valueCodigoAgregacao; } 
            set 
            { 
                if (this._valueCodigoAgregacao == value)return;
                 this._valueCodigoAgregacao = value; 
            } 
        } 

        public NfProdutoRastreabilidadeBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfProdutoRastreabilidadeClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoRastreabilidadeClass) GetEntity(typeof(NfProdutoRastreabilidadeClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NumeroLote))
                {
                    throw new Exception(ErroNumeroLoteObrigatorio);
                }
                if (NumeroLote.Length >20)
                {
                    throw new Exception( ErroNumeroLoteComprimento);
                }
                if ( _valueNfProduto == null)
                {
                    throw new Exception(ErroNfProdutoObrigatorio);
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
                    "  public.nf_produto_rastreabilidade  " +
                    "WHERE " +
                    "  id_nf_produto_rastreabilidade = :id";
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
                        "  public.nf_produto_rastreabilidade   " +
                        "SET  " + 
                        "  id_nf_produto = :id_nf_produto, " + 
                        "  npr_numero_lote = :npr_numero_lote, " + 
                        "  npr_quantidade = :npr_quantidade, " + 
                        "  npr_data_fabricacao = :npr_data_fabricacao, " + 
                        "  npr_data_validade = :npr_data_validade, " + 
                        "  npr_codigo_agregacao = :npr_codigo_agregacao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_nf_produto_rastreabilidade = :id " +
                        "RETURNING id_nf_produto_rastreabilidade;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto_rastreabilidade " +
                        "( " +
                        "  id_nf_produto , " + 
                        "  npr_numero_lote , " + 
                        "  npr_quantidade , " + 
                        "  npr_data_fabricacao , " + 
                        "  npr_data_validade , " + 
                        "  npr_codigo_agregacao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_produto , " + 
                        "  :npr_numero_lote , " + 
                        "  :npr_quantidade , " + 
                        "  :npr_data_fabricacao , " + 
                        "  :npr_data_validade , " + 
                        "  :npr_codigo_agregacao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_nf_produto_rastreabilidade;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfProduto==null ? (object) DBNull.Value : this.NfProduto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npr_numero_lote", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroLote ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npr_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npr_data_fabricacao", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataFabricacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npr_data_validade", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataValidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npr_codigo_agregacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoAgregacao ?? DBNull.Value;
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
        public static NfProdutoRastreabilidadeClass CopiarEntidade(NfProdutoRastreabilidadeClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoRastreabilidadeClass toRet = new NfProdutoRastreabilidadeClass(usuario,conn);
 toRet.NfProduto= entidadeCopiar.NfProduto;
 toRet.NumeroLote= entidadeCopiar.NumeroLote;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.DataFabricacao= entidadeCopiar.DataFabricacao;
 toRet.DataValidade= entidadeCopiar.DataValidade;
 toRet.CodigoAgregacao= entidadeCopiar.CodigoAgregacao;

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
       _nfProdutoOriginal = NfProduto;
       _nfProdutoOriginalCommited = _nfProdutoOriginal;
       _numeroLoteOriginal = NumeroLote;
       _numeroLoteOriginalCommited = _numeroLoteOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _dataFabricacaoOriginal = DataFabricacao;
       _dataFabricacaoOriginalCommited = _dataFabricacaoOriginal;
       _dataValidadeOriginal = DataValidade;
       _dataValidadeOriginalCommited = _dataValidadeOriginal;
       _codigoAgregacaoOriginal = CodigoAgregacao;
       _codigoAgregacaoOriginalCommited = _codigoAgregacaoOriginal;
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
       _nfProdutoOriginalCommited = NfProduto;
       _numeroLoteOriginalCommited = NumeroLote;
       _quantidadeOriginalCommited = Quantidade;
       _dataFabricacaoOriginalCommited = DataFabricacao;
       _dataValidadeOriginalCommited = DataValidade;
       _codigoAgregacaoOriginalCommited = CodigoAgregacao;
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
               NfProduto=_nfProdutoOriginal;
               _nfProdutoOriginalCommited=_nfProdutoOriginal;
               NumeroLote=_numeroLoteOriginal;
               _numeroLoteOriginalCommited=_numeroLoteOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               DataFabricacao=_dataFabricacaoOriginal;
               _dataFabricacaoOriginalCommited=_dataFabricacaoOriginal;
               DataValidade=_dataValidadeOriginal;
               _dataValidadeOriginalCommited=_dataValidadeOriginal;
               CodigoAgregacao=_codigoAgregacaoOriginal;
               _codigoAgregacaoOriginalCommited=_codigoAgregacaoOriginal;
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
       if (_nfProdutoOriginal!=null)
       {
          dirty = !_nfProdutoOriginal.Equals(NfProduto);
       }
       else
       {
            dirty = NfProduto != null;
       }
      if (dirty) return true;
       dirty = _numeroLoteOriginal != NumeroLote;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _dataFabricacaoOriginal != DataFabricacao;
      if (dirty) return true;
       dirty = _dataValidadeOriginal != DataValidade;
      if (dirty) return true;
       dirty = _codigoAgregacaoOriginal != CodigoAgregacao;
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
       if (_nfProdutoOriginalCommited!=null)
       {
          dirty = !_nfProdutoOriginalCommited.Equals(NfProduto);
       }
       else
       {
            dirty = NfProduto != null;
       }
      if (dirty) return true;
       dirty = _numeroLoteOriginalCommited != NumeroLote;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _dataFabricacaoOriginalCommited != DataFabricacao;
      if (dirty) return true;
       dirty = _dataValidadeOriginalCommited != DataValidade;
      if (dirty) return true;
       dirty = _codigoAgregacaoOriginalCommited != CodigoAgregacao;
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
             case "NfProduto":
                return this.NfProduto;
             case "NumeroLote":
                return this.NumeroLote;
             case "Quantidade":
                return this.Quantidade;
             case "DataFabricacao":
                return this.DataFabricacao;
             case "DataValidade":
                return this.DataValidade;
             case "CodigoAgregacao":
                return this.CodigoAgregacao;
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
             if (NfProduto!=null)
                NfProduto.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(nf_produto_rastreabilidade.id_nf_produto_rastreabilidade) " ;
               }
               else
               {
               command.CommandText += "nf_produto_rastreabilidade.id_nf_produto_rastreabilidade, " ;
               command.CommandText += "nf_produto_rastreabilidade.id_nf_produto, " ;
               command.CommandText += "nf_produto_rastreabilidade.npr_numero_lote, " ;
               command.CommandText += "nf_produto_rastreabilidade.npr_quantidade, " ;
               command.CommandText += "nf_produto_rastreabilidade.npr_data_fabricacao, " ;
               command.CommandText += "nf_produto_rastreabilidade.npr_data_validade, " ;
               command.CommandText += "nf_produto_rastreabilidade.npr_codigo_agregacao, " ;
               command.CommandText += "nf_produto_rastreabilidade.entity_uid, " ;
               command.CommandText += "nf_produto_rastreabilidade.version " ;
               }
               command.CommandText += " FROM  nf_produto_rastreabilidade ";
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
                        orderByClause += " , npr_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(npr_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto_rastreabilidade.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_produto_rastreabilidade":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_rastreabilidade.id_nf_produto_rastreabilidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_rastreabilidade.id_nf_produto_rastreabilidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_produto":
                     case "NfProduto":
                     orderByClause += " , nf_produto_rastreabilidade.id_nf_produto " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "npr_numero_lote":
                     case "NumeroLote":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_rastreabilidade.npr_numero_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_rastreabilidade.npr_numero_lote) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npr_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_rastreabilidade.npr_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_rastreabilidade.npr_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npr_data_fabricacao":
                     case "DataFabricacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_rastreabilidade.npr_data_fabricacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_rastreabilidade.npr_data_fabricacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npr_data_validade":
                     case "DataValidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_rastreabilidade.npr_data_validade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_rastreabilidade.npr_data_validade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npr_codigo_agregacao":
                     case "CodigoAgregacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_rastreabilidade.npr_codigo_agregacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_rastreabilidade.npr_codigo_agregacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_rastreabilidade.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_rastreabilidade.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto_rastreabilidade.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_rastreabilidade.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npr_numero_lote")) 
                        {
                           whereClause += " OR UPPER(nf_produto_rastreabilidade.npr_numero_lote) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_rastreabilidade.npr_numero_lote) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npr_codigo_agregacao")) 
                        {
                           whereClause += " OR UPPER(nf_produto_rastreabilidade.npr_codigo_agregacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_rastreabilidade.npr_codigo_agregacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_produto_rastreabilidade.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_rastreabilidade.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto_rastreabilidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_rastreabilidade.id_nf_produto_rastreabilidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.id_nf_produto_rastreabilidade = :nf_produto_rastreabilidade_ID_1326 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_ID_1326", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfProduto" || parametro.FieldName == "id_nf_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_rastreabilidade.id_nf_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.id_nf_produto = :nf_produto_rastreabilidade_NfProduto_9565 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_NfProduto_9565", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroLote" || parametro.FieldName == "npr_numero_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_numero_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_numero_lote LIKE :nf_produto_rastreabilidade_NumeroLote_3345 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_NumeroLote_3345", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "npr_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_quantidade = :nf_produto_rastreabilidade_Quantidade_6398 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_Quantidade_6398", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataFabricacao" || parametro.FieldName == "npr_data_fabricacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_data_fabricacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_data_fabricacao = :nf_produto_rastreabilidade_DataFabricacao_9286 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_DataFabricacao_9286", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataValidade" || parametro.FieldName == "npr_data_validade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_data_validade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_data_validade = :nf_produto_rastreabilidade_DataValidade_9269 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_DataValidade_9269", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoAgregacao" || parametro.FieldName == "npr_codigo_agregacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_codigo_agregacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_codigo_agregacao LIKE :nf_produto_rastreabilidade_CodigoAgregacao_1275 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_CodigoAgregacao_1275", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_rastreabilidade.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.entity_uid LIKE :nf_produto_rastreabilidade_EntityUid_2878 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_EntityUid_2878", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_rastreabilidade.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.version = :nf_produto_rastreabilidade_Version_5680 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_Version_5680", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroLoteExato" || parametro.FieldName == "NumeroLoteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_numero_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_numero_lote LIKE :nf_produto_rastreabilidade_NumeroLote_1648 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_NumeroLote_1648", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoAgregacaoExato" || parametro.FieldName == "CodigoAgregacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_codigo_agregacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.npr_codigo_agregacao LIKE :nf_produto_rastreabilidade_CodigoAgregacao_4489 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_CodigoAgregacao_4489", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_rastreabilidade.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_rastreabilidade.entity_uid LIKE :nf_produto_rastreabilidade_EntityUid_3651 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_rastreabilidade_EntityUid_3651", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoRastreabilidadeClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoRastreabilidadeClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoRastreabilidadeClass), Convert.ToInt32(read["id_nf_produto_rastreabilidade"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoRastreabilidadeClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_produto_rastreabilidade"]);
                     if (read["id_nf_produto"] != DBNull.Value)
                     {
                        entidade.NfProduto = (IWTNF.Entidades.Entidades.NfProdutoClass)IWTNF.Entidades.Entidades.NfProdutoClass.GetEntidade(Convert.ToInt32(read["id_nf_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfProduto = null ;
                     }
                     entidade.NumeroLote = (read["npr_numero_lote"] != DBNull.Value ? read["npr_numero_lote"].ToString() : null);
                     entidade.Quantidade = (double)read["npr_quantidade"];
                     entidade.DataFabricacao = (DateTime)read["npr_data_fabricacao"];
                     entidade.DataValidade = (DateTime)read["npr_data_validade"];
                     entidade.CodigoAgregacao = (read["npr_codigo_agregacao"] != DBNull.Value ? read["npr_codigo_agregacao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoRastreabilidadeClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
