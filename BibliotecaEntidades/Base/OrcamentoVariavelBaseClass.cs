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
     [Table("orcamento_variavel","orv")]
     public class OrcamentoVariavelBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrcamentoVariavelClass";
protected const string ErroDelete = "Erro ao excluir o OrcamentoVariavelClass  ";
protected const string ErroSave = "Erro ao salvar o OrcamentoVariavelClass.";
protected const string ErroPedidoNumeroObrigatorio = "O campo PedidoNumero é obrigatório";
protected const string ErroPedidoNumeroComprimento = "O campo PedidoNumero deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroClienteObrigatorio = "O campo Cliente é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrcamentoVariavelClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoVariavelClass está sendo utilizada.";
#endregion
       protected string _pedidoNumeroOriginal{get;private set;}
       private string _pedidoNumeroOriginalCommited{get; set;}
        private string _valuePedidoNumero;
         [Column("orv_pedido_numero")]
        public virtual string PedidoNumero
         { 
            get { return this._valuePedidoNumero; } 
            set 
            { 
                if (this._valuePedidoNumero == value)return;
                 this._valuePedidoNumero = value; 
            } 
        } 

       protected int _pedidoPosicaoOriginal{get;private set;}
       private int _pedidoPosicaoOriginalCommited{get; set;}
        private int _valuePedidoPosicao;
         [Column("orv_pedido_posicao")]
        public virtual int PedidoPosicao
         { 
            get { return this._valuePedidoPosicao; } 
            set 
            { 
                if (this._valuePedidoPosicao == value)return;
                 this._valuePedidoPosicao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ClienteClass _clienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ClienteClass _clienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ClienteClass _valueCliente;
        [Column("id_cliente", "cliente", "id_cliente")]
       public virtual BibliotecaEntidades.Entidades.ClienteClass Cliente
        { 
           get {                 return this._valueCliente; } 
           set 
           { 
                if (this._valueCliente == value)return;
                 this._valueCliente = value; 
           } 
       } 

       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("orv_codigo")]
        public virtual string Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected string _valorOriginal{get;private set;}
       private string _valorOriginalCommited{get; set;}
        private string _valueValor;
         [Column("orv_valor")]
        public virtual string Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrcamentoItemClass _orcamentoItemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrcamentoItemClass _orcamentoItemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrcamentoItemClass _valueOrcamentoItem;
        [Column("id_orcamento_item", "orcamento_item", "id_orcamento_item")]
       public virtual BibliotecaEntidades.Entidades.OrcamentoItemClass OrcamentoItem
        { 
           get {                 return this._valueOrcamentoItem; } 
           set 
           { 
                if (this._valueOrcamentoItem == value)return;
                 this._valueOrcamentoItem = value; 
           } 
       } 

        public OrcamentoVariavelBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static OrcamentoVariavelClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrcamentoVariavelClass) GetEntity(typeof(OrcamentoVariavelClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(PedidoNumero))
                {
                    throw new Exception(ErroPedidoNumeroObrigatorio);
                }
                if (PedidoNumero.Length >255)
                {
                    throw new Exception( ErroPedidoNumeroComprimento);
                }
                if ( _valueCliente == null)
                {
                    throw new Exception(ErroClienteObrigatorio);
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
                    "  public.orcamento_variavel  " +
                    "WHERE " +
                    "  id_orcamento_variavel = :id";
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
                        "  public.orcamento_variavel   " +
                        "SET  " + 
                        "  orv_pedido_numero = :orv_pedido_numero, " + 
                        "  orv_pedido_posicao = :orv_pedido_posicao, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  orv_codigo = :orv_codigo, " + 
                        "  orv_valor = :orv_valor, " + 
                        "  id_orcamento_item = :id_orcamento_item, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_orcamento_variavel = :id " +
                        "RETURNING id_orcamento_variavel;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.orcamento_variavel " +
                        "( " +
                        "  orv_pedido_numero , " + 
                        "  orv_pedido_posicao , " + 
                        "  id_cliente , " + 
                        "  orv_codigo , " + 
                        "  orv_valor , " + 
                        "  id_orcamento_item , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :orv_pedido_numero , " + 
                        "  :orv_pedido_posicao , " + 
                        "  :id_cliente , " + 
                        "  :orv_codigo , " + 
                        "  :orv_valor , " + 
                        "  :id_orcamento_item , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_orcamento_variavel;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orv_pedido_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PedidoNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orv_pedido_posicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PedidoPosicao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orv_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orv_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrcamentoItem==null ? (object) DBNull.Value : this.OrcamentoItem.ID;
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
        public static OrcamentoVariavelClass CopiarEntidade(OrcamentoVariavelClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrcamentoVariavelClass toRet = new OrcamentoVariavelClass(usuario,conn);
 toRet.PedidoNumero= entidadeCopiar.PedidoNumero;
 toRet.PedidoPosicao= entidadeCopiar.PedidoPosicao;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.OrcamentoItem= entidadeCopiar.OrcamentoItem;

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
       _pedidoNumeroOriginal = PedidoNumero;
       _pedidoNumeroOriginalCommited = _pedidoNumeroOriginal;
       _pedidoPosicaoOriginal = PedidoPosicao;
       _pedidoPosicaoOriginalCommited = _pedidoPosicaoOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _valorOriginal = Valor;
       _valorOriginalCommited = _valorOriginal;
       _orcamentoItemOriginal = OrcamentoItem;
       _orcamentoItemOriginalCommited = _orcamentoItemOriginal;
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
       _pedidoNumeroOriginalCommited = PedidoNumero;
       _pedidoPosicaoOriginalCommited = PedidoPosicao;
       _clienteOriginalCommited = Cliente;
       _codigoOriginalCommited = Codigo;
       _valorOriginalCommited = Valor;
       _orcamentoItemOriginalCommited = OrcamentoItem;
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
               PedidoNumero=_pedidoNumeroOriginal;
               _pedidoNumeroOriginalCommited=_pedidoNumeroOriginal;
               PedidoPosicao=_pedidoPosicaoOriginal;
               _pedidoPosicaoOriginalCommited=_pedidoPosicaoOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               Valor=_valorOriginal;
               _valorOriginalCommited=_valorOriginal;
               OrcamentoItem=_orcamentoItemOriginal;
               _orcamentoItemOriginalCommited=_orcamentoItemOriginal;
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
       dirty = _pedidoNumeroOriginal != PedidoNumero;
      if (dirty) return true;
       dirty = _pedidoPosicaoOriginal != PedidoPosicao;
      if (dirty) return true;
       if (_clienteOriginal!=null)
       {
          dirty = !_clienteOriginal.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
      if (dirty) return true;
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       dirty = _valorOriginal != Valor;
      if (dirty) return true;
       if (_orcamentoItemOriginal!=null)
       {
          dirty = !_orcamentoItemOriginal.Equals(OrcamentoItem);
       }
       else
       {
            dirty = OrcamentoItem != null;
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
       dirty = _pedidoNumeroOriginalCommited != PedidoNumero;
      if (dirty) return true;
       dirty = _pedidoPosicaoOriginalCommited != PedidoPosicao;
      if (dirty) return true;
       if (_clienteOriginalCommited!=null)
       {
          dirty = !_clienteOriginalCommited.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
      if (dirty) return true;
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       dirty = _valorOriginalCommited != Valor;
      if (dirty) return true;
       if (_orcamentoItemOriginalCommited!=null)
       {
          dirty = !_orcamentoItemOriginalCommited.Equals(OrcamentoItem);
       }
       else
       {
            dirty = OrcamentoItem != null;
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
             case "PedidoNumero":
                return this.PedidoNumero;
             case "PedidoPosicao":
                return this.PedidoPosicao;
             case "Cliente":
                return this.Cliente;
             case "Codigo":
                return this.Codigo;
             case "Valor":
                return this.Valor;
             case "OrcamentoItem":
                return this.OrcamentoItem;
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
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
             if (OrcamentoItem!=null)
                OrcamentoItem.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(orcamento_variavel.id_orcamento_variavel) " ;
               }
               else
               {
               command.CommandText += "orcamento_variavel.id_orcamento_variavel, " ;
               command.CommandText += "orcamento_variavel.orv_pedido_numero, " ;
               command.CommandText += "orcamento_variavel.orv_pedido_posicao, " ;
               command.CommandText += "orcamento_variavel.id_cliente, " ;
               command.CommandText += "orcamento_variavel.orv_codigo, " ;
               command.CommandText += "orcamento_variavel.orv_valor, " ;
               command.CommandText += "orcamento_variavel.id_orcamento_item, " ;
               command.CommandText += "orcamento_variavel.entity_uid, " ;
               command.CommandText += "orcamento_variavel.version " ;
               }
               command.CommandText += " FROM  orcamento_variavel ";
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
                        orderByClause += " , orv_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(orv_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = orcamento_variavel.id_acs_usuario_ultima_revisao ";
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
                     case "id_orcamento_variavel":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_variavel.id_orcamento_variavel " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_variavel.id_orcamento_variavel) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orv_pedido_numero":
                     case "PedidoNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_variavel.orv_pedido_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_variavel.orv_pedido_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orv_pedido_posicao":
                     case "PedidoPosicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_variavel.orv_pedido_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_variavel.orv_pedido_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = orcamento_variavel.id_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente_Cliente.cli_nome_resumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente_Cliente.cli_nome_resumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orv_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_variavel.orv_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_variavel.orv_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orv_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_variavel.orv_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_variavel.orv_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_orcamento_item":
                     case "OrcamentoItem":
                     command.CommandText += " LEFT JOIN orcamento_item as orcamento_item_OrcamentoItem ON orcamento_item_OrcamentoItem.id_orcamento_item = orcamento_variavel.id_orcamento_item ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item_OrcamentoItem.id_orcamento_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item_OrcamentoItem.id_orcamento_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_variavel.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_variavel.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , orcamento_variavel.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_variavel.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orv_pedido_numero")) 
                        {
                           whereClause += " OR UPPER(orcamento_variavel.orv_pedido_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_variavel.orv_pedido_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orv_codigo")) 
                        {
                           whereClause += " OR UPPER(orcamento_variavel.orv_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_variavel.orv_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orv_valor")) 
                        {
                           whereClause += " OR UPPER(orcamento_variavel.orv_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_variavel.orv_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(orcamento_variavel.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_variavel.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_orcamento_variavel")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.id_orcamento_variavel IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.id_orcamento_variavel = :orcamento_variavel_ID_2519 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_ID_2519", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoNumero" || parametro.FieldName == "orv_pedido_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.orv_pedido_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.orv_pedido_numero LIKE :orcamento_variavel_PedidoNumero_2397 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_PedidoNumero_2397", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoPosicao" || parametro.FieldName == "orv_pedido_posicao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.orv_pedido_posicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.orv_pedido_posicao = :orcamento_variavel_PedidoPosicao_1458 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_PedidoPosicao_1458", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cliente" || parametro.FieldName == "id_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.id_cliente = :orcamento_variavel_Cliente_261 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_Cliente_261", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "orv_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.orv_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.orv_codigo LIKE :orcamento_variavel_Codigo_2408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_Codigo_2408", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "orv_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.orv_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.orv_valor LIKE :orcamento_variavel_Valor_6260 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_Valor_6260", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrcamentoItem" || parametro.FieldName == "id_orcamento_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrcamentoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrcamentoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.id_orcamento_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.id_orcamento_item = :orcamento_variavel_OrcamentoItem_2392 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_OrcamentoItem_2392", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  orcamento_variavel.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.entity_uid LIKE :orcamento_variavel_EntityUid_8653 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_EntityUid_8653", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  orcamento_variavel.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.version = :orcamento_variavel_Version_4197 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_Version_4197", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoNumeroExato" || parametro.FieldName == "PedidoNumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.orv_pedido_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.orv_pedido_numero LIKE :orcamento_variavel_PedidoNumero_4672 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_PedidoNumero_4672", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoExato" || parametro.FieldName == "CodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.orv_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.orv_codigo LIKE :orcamento_variavel_Codigo_5189 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_Codigo_5189", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorExato" || parametro.FieldName == "ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_variavel.orv_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.orv_valor LIKE :orcamento_variavel_Valor_7864 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_Valor_7864", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_variavel.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_variavel.entity_uid LIKE :orcamento_variavel_EntityUid_4006 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_variavel_EntityUid_4006", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrcamentoVariavelClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrcamentoVariavelClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrcamentoVariavelClass), Convert.ToInt32(read["id_orcamento_variavel"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrcamentoVariavelClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_orcamento_variavel"]);
                     entidade.PedidoNumero = (read["orv_pedido_numero"] != DBNull.Value ? read["orv_pedido_numero"].ToString() : null);
                     entidade.PedidoPosicao = (int)read["orv_pedido_posicao"];
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     entidade.Codigo = (read["orv_codigo"] != DBNull.Value ? read["orv_codigo"].ToString() : null);
                     entidade.Valor = (read["orv_valor"] != DBNull.Value ? read["orv_valor"].ToString() : null);
                     if (read["id_orcamento_item"] != DBNull.Value)
                     {
                        entidade.OrcamentoItem = (BibliotecaEntidades.Entidades.OrcamentoItemClass)BibliotecaEntidades.Entidades.OrcamentoItemClass.GetEntidade(Convert.ToInt32(read["id_orcamento_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrcamentoItem = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrcamentoVariavelClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
