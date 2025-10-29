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
     [Table("pedido_variavel","pev")]
     public class PedidoVariavelBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PedidoVariavelClass";
protected const string ErroDelete = "Erro ao excluir o PedidoVariavelClass  ";
protected const string ErroSave = "Erro ao salvar o PedidoVariavelClass.";
protected const string ErroPedidoNumeroObrigatorio = "O campo PedidoNumero é obrigatório";
protected const string ErroPedidoNumeroComprimento = "O campo PedidoNumero deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroClienteObrigatorio = "O campo Cliente é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do PedidoVariavelClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoVariavelClass está sendo utilizada.";
#endregion
       protected string _pedidoNumeroOriginal{get;private set;}
       private string _pedidoNumeroOriginalCommited{get; set;}
        private string _valuePedidoNumero;
         [Column("pev_pedido_numero")]
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
         [Column("pev_pedido_posicao")]
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
         [Column("pev_codigo")]
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
         [Column("pev_valor")]
        public virtual string Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _valuePedidoItem;
        [Column("id_pedido_item", "pedido_item", "id_pedido_item")]
       public virtual BibliotecaEntidades.Entidades.PedidoItemClass PedidoItem
        { 
           get {                 return this._valuePedidoItem; } 
           set 
           { 
                if (this._valuePedidoItem == value)return;
                 this._valuePedidoItem = value; 
           } 
       } 

        public PedidoVariavelBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static PedidoVariavelClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PedidoVariavelClass) GetEntity(typeof(PedidoVariavelClass),id,usuarioAtual,connection, operacao);
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
                    "  public.pedido_variavel  " +
                    "WHERE " +
                    "  id_pedido_variavel = :id";
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
                        "  public.pedido_variavel   " +
                        "SET  " + 
                        "  pev_pedido_numero = :pev_pedido_numero, " + 
                        "  pev_pedido_posicao = :pev_pedido_posicao, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  pev_codigo = :pev_codigo, " + 
                        "  pev_valor = :pev_valor, " + 
                        "  id_pedido_item = :id_pedido_item, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_pedido_variavel = :id " +
                        "RETURNING id_pedido_variavel;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.pedido_variavel " +
                        "( " +
                        "  pev_pedido_numero , " + 
                        "  pev_pedido_posicao , " + 
                        "  id_cliente , " + 
                        "  pev_codigo , " + 
                        "  pev_valor , " + 
                        "  id_pedido_item , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :pev_pedido_numero , " + 
                        "  :pev_pedido_posicao , " + 
                        "  :id_cliente , " + 
                        "  :pev_codigo , " + 
                        "  :pev_valor , " + 
                        "  :id_pedido_item , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_pedido_variavel;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pev_pedido_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PedidoNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pev_pedido_posicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PedidoPosicao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pev_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pev_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PedidoItem==null ? (object) DBNull.Value : this.PedidoItem.ID;
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
        public static PedidoVariavelClass CopiarEntidade(PedidoVariavelClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PedidoVariavelClass toRet = new PedidoVariavelClass(usuario,conn);
 toRet.PedidoNumero= entidadeCopiar.PedidoNumero;
 toRet.PedidoPosicao= entidadeCopiar.PedidoPosicao;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.PedidoItem= entidadeCopiar.PedidoItem;

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
       _pedidoItemOriginal = PedidoItem;
       _pedidoItemOriginalCommited = _pedidoItemOriginal;
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
       _pedidoItemOriginalCommited = PedidoItem;
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
               PedidoItem=_pedidoItemOriginal;
               _pedidoItemOriginalCommited=_pedidoItemOriginal;
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
       if (_pedidoItemOriginal!=null)
       {
          dirty = !_pedidoItemOriginal.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
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
       if (_pedidoItemOriginalCommited!=null)
       {
          dirty = !_pedidoItemOriginalCommited.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
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
             case "PedidoItem":
                return this.PedidoItem;
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
             if (PedidoItem!=null)
                PedidoItem.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(pedido_variavel.id_pedido_variavel) " ;
               }
               else
               {
               command.CommandText += "pedido_variavel.id_pedido_variavel, " ;
               command.CommandText += "pedido_variavel.pev_pedido_numero, " ;
               command.CommandText += "pedido_variavel.pev_pedido_posicao, " ;
               command.CommandText += "pedido_variavel.id_cliente, " ;
               command.CommandText += "pedido_variavel.pev_codigo, " ;
               command.CommandText += "pedido_variavel.pev_valor, " ;
               command.CommandText += "pedido_variavel.id_pedido_item, " ;
               command.CommandText += "pedido_variavel.entity_uid, " ;
               command.CommandText += "pedido_variavel.version " ;
               }
               command.CommandText += " FROM  pedido_variavel ";
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
                        orderByClause += " , pev_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pev_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = pedido_variavel.id_acs_usuario_ultima_revisao ";
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
                     case "id_pedido_variavel":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_variavel.id_pedido_variavel " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_variavel.id_pedido_variavel) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pev_pedido_numero":
                     case "PedidoNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_variavel.pev_pedido_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_variavel.pev_pedido_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pev_pedido_posicao":
                     case "PedidoPosicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_variavel.pev_pedido_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_variavel.pev_pedido_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = pedido_variavel.id_cliente ";                     switch (parametro.TipoOrdenacao)
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
                     case "pev_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_variavel.pev_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_variavel.pev_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pev_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_variavel.pev_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_variavel.pev_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pedido_item":
                     case "PedidoItem":
                     command.CommandText += " LEFT JOIN pedido_item as pedido_item_PedidoItem ON pedido_item_PedidoItem.id_pedido_item = pedido_variavel.id_pedido_item ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_PedidoItem.pei_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_PedidoItem.pei_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_PedidoItem.pei_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_PedidoItem.pei_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_variavel.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_variavel.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , pedido_variavel.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_variavel.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pev_pedido_numero")) 
                        {
                           whereClause += " OR UPPER(pedido_variavel.pev_pedido_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_variavel.pev_pedido_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pev_codigo")) 
                        {
                           whereClause += " OR UPPER(pedido_variavel.pev_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_variavel.pev_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pev_valor")) 
                        {
                           whereClause += " OR UPPER(pedido_variavel.pev_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_variavel.pev_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(pedido_variavel.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_variavel.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_pedido_variavel")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_variavel.id_pedido_variavel IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.id_pedido_variavel = :pedido_variavel_ID_4024 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_ID_4024", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoNumero" || parametro.FieldName == "pev_pedido_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_variavel.pev_pedido_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.pev_pedido_numero LIKE :pedido_variavel_PedidoNumero_5769 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_PedidoNumero_5769", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoPosicao" || parametro.FieldName == "pev_pedido_posicao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_variavel.pev_pedido_posicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.pev_pedido_posicao = :pedido_variavel_PedidoPosicao_1611 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_PedidoPosicao_1611", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  pedido_variavel.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.id_cliente = :pedido_variavel_Cliente_1718 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_Cliente_1718", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "pev_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_variavel.pev_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.pev_codigo LIKE :pedido_variavel_Codigo_1005 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_Codigo_1005", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "pev_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_variavel.pev_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.pev_valor LIKE :pedido_variavel_Valor_4880 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_Valor_4880", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoItem" || parametro.FieldName == "id_pedido_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PedidoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PedidoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_variavel.id_pedido_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.id_pedido_item = :pedido_variavel_PedidoItem_6135 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_PedidoItem_6135", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  pedido_variavel.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.entity_uid LIKE :pedido_variavel_EntityUid_4983 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_EntityUid_4983", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  pedido_variavel.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.version = :pedido_variavel_Version_8721 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_Version_8721", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  pedido_variavel.pev_pedido_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.pev_pedido_numero LIKE :pedido_variavel_PedidoNumero_900 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_PedidoNumero_900", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  pedido_variavel.pev_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.pev_codigo LIKE :pedido_variavel_Codigo_9546 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_Codigo_9546", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  pedido_variavel.pev_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.pev_valor LIKE :pedido_variavel_Valor_3678 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_Valor_3678", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  pedido_variavel.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_variavel.entity_uid LIKE :pedido_variavel_EntityUid_4099 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_variavel_EntityUid_4099", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PedidoVariavelClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PedidoVariavelClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PedidoVariavelClass), Convert.ToInt32(read["id_pedido_variavel"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PedidoVariavelClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_pedido_variavel"]);
                     entidade.PedidoNumero = (read["pev_pedido_numero"] != DBNull.Value ? read["pev_pedido_numero"].ToString() : null);
                     entidade.PedidoPosicao = (int)read["pev_pedido_posicao"];
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     entidade.Codigo = (read["pev_codigo"] != DBNull.Value ? read["pev_codigo"].ToString() : null);
                     entidade.Valor = (read["pev_valor"] != DBNull.Value ? read["pev_valor"].ToString() : null);
                     if (read["id_pedido_item"] != DBNull.Value)
                     {
                        entidade.PedidoItem = (BibliotecaEntidades.Entidades.PedidoItemClass)BibliotecaEntidades.Entidades.PedidoItemClass.GetEntidade(Convert.ToInt32(read["id_pedido_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PedidoItem = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PedidoVariavelClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
