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
     [Table("mdfe_rodo_vale_pedagio","mrv")]
     public class MdfeRodoValePedagioBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MdfeRodoValePedagioClass";
protected const string ErroDelete = "Erro ao excluir o MdfeRodoValePedagioClass  ";
protected const string ErroSave = "Erro ao salvar o MdfeRodoValePedagioClass.";
protected const string ErroCnpjFornecedorObrigatorio = "O campo CnpjFornecedor é obrigatório";
protected const string ErroCnpjFornecedorComprimento = "O campo CnpjFornecedor deve ter no máximo 14 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroMdfeModalRodoviarioObrigatorio = "O campo MdfeModalRodoviario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do MdfeRodoValePedagioClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeRodoValePedagioClass está sendo utilizada.";
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

       protected string _cnpjFornecedorOriginal{get;private set;}
       private string _cnpjFornecedorOriginalCommited{get; set;}
        private string _valueCnpjFornecedor;
         [Column("mrv_cnpj_fornecedor")]
        public virtual string CnpjFornecedor
         { 
            get { return this._valueCnpjFornecedor; } 
            set 
            { 
                if (this._valueCnpjFornecedor == value)return;
                 this._valueCnpjFornecedor = value; 
            } 
        } 

       protected string _cnpjResponsavelPagamentoOriginal{get;private set;}
       private string _cnpjResponsavelPagamentoOriginalCommited{get; set;}
        private string _valueCnpjResponsavelPagamento;
         [Column("mrv_cnpj_responsavel_pagamento")]
        public virtual string CnpjResponsavelPagamento
         { 
            get { return this._valueCnpjResponsavelPagamento; } 
            set 
            { 
                if (this._valueCnpjResponsavelPagamento == value)return;
                 this._valueCnpjResponsavelPagamento = value; 
            } 
        } 

       protected int _numeroOrdemCompraOriginal{get;private set;}
       private int _numeroOrdemCompraOriginalCommited{get; set;}
        private int _valueNumeroOrdemCompra;
         [Column("mrv_numero_ordem_compra")]
        public virtual int NumeroOrdemCompra
         { 
            get { return this._valueNumeroOrdemCompra; } 
            set 
            { 
                if (this._valueNumeroOrdemCompra == value)return;
                 this._valueNumeroOrdemCompra = value; 
            } 
        } 

        public MdfeRodoValePedagioBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static MdfeRodoValePedagioClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MdfeRodoValePedagioClass) GetEntity(typeof(MdfeRodoValePedagioClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CnpjFornecedor))
                {
                    throw new Exception(ErroCnpjFornecedorObrigatorio);
                }
                if (CnpjFornecedor.Length >14)
                {
                    throw new Exception( ErroCnpjFornecedorComprimento);
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
                    "  public.mdfe_rodo_vale_pedagio  " +
                    "WHERE " +
                    "  id_mdfe_rodo_vale_pedagio = :id";
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
                        "  public.mdfe_rodo_vale_pedagio   " +
                        "SET  " + 
                        "  id_mdfe_modal_rodoviario = :id_mdfe_modal_rodoviario, " + 
                        "  mrv_cnpj_fornecedor = :mrv_cnpj_fornecedor, " + 
                        "  mrv_cnpj_responsavel_pagamento = :mrv_cnpj_responsavel_pagamento, " + 
                        "  mrv_numero_ordem_compra = :mrv_numero_ordem_compra, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_mdfe_rodo_vale_pedagio = :id " +
                        "RETURNING id_mdfe_rodo_vale_pedagio;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.mdfe_rodo_vale_pedagio " +
                        "( " +
                        "  id_mdfe_modal_rodoviario , " + 
                        "  mrv_cnpj_fornecedor , " + 
                        "  mrv_cnpj_responsavel_pagamento , " + 
                        "  mrv_numero_ordem_compra , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_mdfe_modal_rodoviario , " + 
                        "  :mrv_cnpj_fornecedor , " + 
                        "  :mrv_cnpj_responsavel_pagamento , " + 
                        "  :mrv_numero_ordem_compra , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_mdfe_rodo_vale_pedagio;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_mdfe_modal_rodoviario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.MdfeModalRodoviario==null ? (object) DBNull.Value : this.MdfeModalRodoviario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrv_cnpj_fornecedor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjFornecedor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrv_cnpj_responsavel_pagamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjResponsavelPagamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrv_numero_ordem_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroOrdemCompra ?? DBNull.Value;
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
        public static MdfeRodoValePedagioClass CopiarEntidade(MdfeRodoValePedagioClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MdfeRodoValePedagioClass toRet = new MdfeRodoValePedagioClass(usuario,conn);
 toRet.MdfeModalRodoviario= entidadeCopiar.MdfeModalRodoviario;
 toRet.CnpjFornecedor= entidadeCopiar.CnpjFornecedor;
 toRet.CnpjResponsavelPagamento= entidadeCopiar.CnpjResponsavelPagamento;
 toRet.NumeroOrdemCompra= entidadeCopiar.NumeroOrdemCompra;

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
       _cnpjFornecedorOriginal = CnpjFornecedor;
       _cnpjFornecedorOriginalCommited = _cnpjFornecedorOriginal;
       _cnpjResponsavelPagamentoOriginal = CnpjResponsavelPagamento;
       _cnpjResponsavelPagamentoOriginalCommited = _cnpjResponsavelPagamentoOriginal;
       _numeroOrdemCompraOriginal = NumeroOrdemCompra;
       _numeroOrdemCompraOriginalCommited = _numeroOrdemCompraOriginal;
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
       _cnpjFornecedorOriginalCommited = CnpjFornecedor;
       _cnpjResponsavelPagamentoOriginalCommited = CnpjResponsavelPagamento;
       _numeroOrdemCompraOriginalCommited = NumeroOrdemCompra;
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
               CnpjFornecedor=_cnpjFornecedorOriginal;
               _cnpjFornecedorOriginalCommited=_cnpjFornecedorOriginal;
               CnpjResponsavelPagamento=_cnpjResponsavelPagamentoOriginal;
               _cnpjResponsavelPagamentoOriginalCommited=_cnpjResponsavelPagamentoOriginal;
               NumeroOrdemCompra=_numeroOrdemCompraOriginal;
               _numeroOrdemCompraOriginalCommited=_numeroOrdemCompraOriginal;
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
       dirty = _cnpjFornecedorOriginal != CnpjFornecedor;
      if (dirty) return true;
       dirty = _cnpjResponsavelPagamentoOriginal != CnpjResponsavelPagamento;
      if (dirty) return true;
       dirty = _numeroOrdemCompraOriginal != NumeroOrdemCompra;
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
       dirty = _cnpjFornecedorOriginalCommited != CnpjFornecedor;
      if (dirty) return true;
       dirty = _cnpjResponsavelPagamentoOriginalCommited != CnpjResponsavelPagamento;
      if (dirty) return true;
       dirty = _numeroOrdemCompraOriginalCommited != NumeroOrdemCompra;
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
             case "CnpjFornecedor":
                return this.CnpjFornecedor;
             case "CnpjResponsavelPagamento":
                return this.CnpjResponsavelPagamento;
             case "NumeroOrdemCompra":
                return this.NumeroOrdemCompra;
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
                  command.CommandText += " COUNT(mdfe_rodo_vale_pedagio.id_mdfe_rodo_vale_pedagio) " ;
               }
               else
               {
               command.CommandText += "mdfe_rodo_vale_pedagio.id_mdfe_rodo_vale_pedagio, " ;
               command.CommandText += "mdfe_rodo_vale_pedagio.id_mdfe_modal_rodoviario, " ;
               command.CommandText += "mdfe_rodo_vale_pedagio.mrv_cnpj_fornecedor, " ;
               command.CommandText += "mdfe_rodo_vale_pedagio.mrv_cnpj_responsavel_pagamento, " ;
               command.CommandText += "mdfe_rodo_vale_pedagio.mrv_numero_ordem_compra, " ;
               command.CommandText += "mdfe_rodo_vale_pedagio.version, " ;
               command.CommandText += "mdfe_rodo_vale_pedagio.entity_uid " ;
               }
               command.CommandText += " FROM  mdfe_rodo_vale_pedagio ";
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
                        orderByClause += " , mrv_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mrv_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = mdfe_rodo_vale_pedagio.id_acs_usuario_ultima_revisao ";
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
                     case "id_mdfe_rodo_vale_pedagio":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_vale_pedagio.id_mdfe_rodo_vale_pedagio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_vale_pedagio.id_mdfe_rodo_vale_pedagio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_mdfe_modal_rodoviario":
                     case "MdfeModalRodoviario":
                     orderByClause += " , mdfe_rodo_vale_pedagio.id_mdfe_modal_rodoviario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "mrv_cnpj_fornecedor":
                     case "CnpjFornecedor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_vale_pedagio.mrv_cnpj_fornecedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_vale_pedagio.mrv_cnpj_fornecedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrv_cnpj_responsavel_pagamento":
                     case "CnpjResponsavelPagamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_vale_pedagio.mrv_cnpj_responsavel_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_vale_pedagio.mrv_cnpj_responsavel_pagamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrv_numero_ordem_compra":
                     case "NumeroOrdemCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_vale_pedagio.mrv_numero_ordem_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_vale_pedagio.mrv_numero_ordem_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , mdfe_rodo_vale_pedagio.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_vale_pedagio.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_vale_pedagio.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_vale_pedagio.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrv_cnpj_fornecedor")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_vale_pedagio.mrv_cnpj_fornecedor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_vale_pedagio.mrv_cnpj_fornecedor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrv_cnpj_responsavel_pagamento")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_vale_pedagio.mrv_cnpj_responsavel_pagamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_vale_pedagio.mrv_cnpj_responsavel_pagamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_vale_pedagio.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_vale_pedagio.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_mdfe_rodo_vale_pedagio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.id_mdfe_rodo_vale_pedagio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.id_mdfe_rodo_vale_pedagio = :mdfe_rodo_vale_pedagio_ID_3407 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_ID_3407", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  mdfe_rodo_vale_pedagio.id_mdfe_modal_rodoviario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.id_mdfe_modal_rodoviario = :mdfe_rodo_vale_pedagio_MdfeModalRodoviario_816 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_MdfeModalRodoviario_816", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjFornecedor" || parametro.FieldName == "mrv_cnpj_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_cnpj_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_cnpj_fornecedor LIKE :mdfe_rodo_vale_pedagio_CnpjFornecedor_5770 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_CnpjFornecedor_5770", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjResponsavelPagamento" || parametro.FieldName == "mrv_cnpj_responsavel_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_cnpj_responsavel_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_cnpj_responsavel_pagamento LIKE :mdfe_rodo_vale_pedagio_CnpjResponsavelPagamento_1523 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_CnpjResponsavelPagamento_1523", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroOrdemCompra" || parametro.FieldName == "mrv_numero_ordem_compra")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_numero_ordem_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_numero_ordem_compra = :mdfe_rodo_vale_pedagio_NumeroOrdemCompra_6270 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_NumeroOrdemCompra_6270", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_rodo_vale_pedagio.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.version = :mdfe_rodo_vale_pedagio_Version_5224 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_Version_5224", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_rodo_vale_pedagio.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.entity_uid LIKE :mdfe_rodo_vale_pedagio_EntityUid_6981 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_EntityUid_6981", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjFornecedorExato" || parametro.FieldName == "CnpjFornecedorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_cnpj_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_cnpj_fornecedor LIKE :mdfe_rodo_vale_pedagio_CnpjFornecedor_7115 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_CnpjFornecedor_7115", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjResponsavelPagamentoExato" || parametro.FieldName == "CnpjResponsavelPagamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_cnpj_responsavel_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.mrv_cnpj_responsavel_pagamento LIKE :mdfe_rodo_vale_pedagio_CnpjResponsavelPagamento_7130 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_CnpjResponsavelPagamento_7130", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_rodo_vale_pedagio.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_vale_pedagio.entity_uid LIKE :mdfe_rodo_vale_pedagio_EntityUid_8328 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_vale_pedagio_EntityUid_8328", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MdfeRodoValePedagioClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MdfeRodoValePedagioClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MdfeRodoValePedagioClass), Convert.ToInt32(read["id_mdfe_rodo_vale_pedagio"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MdfeRodoValePedagioClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_mdfe_rodo_vale_pedagio"]);
                     if (read["id_mdfe_modal_rodoviario"] != DBNull.Value)
                     {
                        entidade.MdfeModalRodoviario = (IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass)IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass.GetEntidade(Convert.ToInt32(read["id_mdfe_modal_rodoviario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.MdfeModalRodoviario = null ;
                     }
                     entidade.CnpjFornecedor = (read["mrv_cnpj_fornecedor"] != DBNull.Value ? read["mrv_cnpj_fornecedor"].ToString() : null);
                     entidade.CnpjResponsavelPagamento = (read["mrv_cnpj_responsavel_pagamento"] != DBNull.Value ? read["mrv_cnpj_responsavel_pagamento"].ToString() : null);
                     entidade.NumeroOrdemCompra = (int)read["mrv_numero_ordem_compra"];
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MdfeRodoValePedagioClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
