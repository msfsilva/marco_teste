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
     [Table("plano_corte_item_pedido","pcp")]
     public class PlanoCorteItemPedidoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PlanoCorteItemPedidoClass";
protected const string ErroDelete = "Erro ao excluir o PlanoCorteItemPedidoClass  ";
protected const string ErroSave = "Erro ao salvar o PlanoCorteItemPedidoClass.";
protected const string ErroCodigoItemObrigatorio = "O campo CodigoItem é obrigatório";
protected const string ErroCodigoItemComprimento = "O campo CodigoItem deve ter no máximo 255 caracteres";
protected const string ErroPedidoNumeroObrigatorio = "O campo PedidoNumero é obrigatório";
protected const string ErroPedidoNumeroComprimento = "O campo PedidoNumero deve ter no máximo 255 caracteres";
protected const string ErroPedidoClienteObrigatorio = "O campo PedidoCliente é obrigatório";
protected const string ErroPedidoClienteComprimento = "O campo PedidoCliente deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroPlanoCorteItemObrigatorio = "O campo PlanoCorteItem é obrigatório";
protected const string ErroOrderItemEtiquetaObrigatorio = "O campo OrderItemEtiqueta é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do PlanoCorteItemPedidoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PlanoCorteItemPedidoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.PlanoCorteItemClass _planoCorteItemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PlanoCorteItemClass _planoCorteItemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PlanoCorteItemClass _valuePlanoCorteItem;
        [Column("id_plano_corte_item", "plano_corte_item", "id_plano_corte_item")]
       public virtual BibliotecaEntidades.Entidades.PlanoCorteItemClass PlanoCorteItem
        { 
           get {                 return this._valuePlanoCorteItem; } 
           set 
           { 
                if (this._valuePlanoCorteItem == value)return;
                 this._valuePlanoCorteItem = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _valueOrderItemEtiqueta;
        [Column("id_order_item_etiqueta", "order_item_etiqueta", "id_order_item_etiqueta")]
       public virtual BibliotecaEntidades.Entidades.OrderItemEtiquetaClass OrderItemEtiqueta
        { 
           get {                 return this._valueOrderItemEtiqueta; } 
           set 
           { 
                if (this._valueOrderItemEtiqueta == value)return;
                 this._valueOrderItemEtiqueta = value; 
           } 
       } 

       protected string _codigoItemOriginal{get;private set;}
       private string _codigoItemOriginalCommited{get; set;}
        private string _valueCodigoItem;
         [Column("pcp_codigo_item")]
        public virtual string CodigoItem
         { 
            get { return this._valueCodigoItem; } 
            set 
            { 
                if (this._valueCodigoItem == value)return;
                 this._valueCodigoItem = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("pcp_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected string _pedidoNumeroOriginal{get;private set;}
       private string _pedidoNumeroOriginalCommited{get; set;}
        private string _valuePedidoNumero;
         [Column("pcp_pedido_numero")]
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
         [Column("pcp_pedido_posicao")]
        public virtual int PedidoPosicao
         { 
            get { return this._valuePedidoPosicao; } 
            set 
            { 
                if (this._valuePedidoPosicao == value)return;
                 this._valuePedidoPosicao = value; 
            } 
        } 

       protected string _pedidoClienteOriginal{get;private set;}
       private string _pedidoClienteOriginalCommited{get; set;}
        private string _valuePedidoCliente;
         [Column("pcp_pedido_cliente")]
        public virtual string PedidoCliente
         { 
            get { return this._valuePedidoCliente; } 
            set 
            { 
                if (this._valuePedidoCliente == value)return;
                 this._valuePedidoCliente = value; 
            } 
        } 

        public PlanoCorteItemPedidoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static PlanoCorteItemPedidoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PlanoCorteItemPedidoClass) GetEntity(typeof(PlanoCorteItemPedidoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CodigoItem))
                {
                    throw new Exception(ErroCodigoItemObrigatorio);
                }
                if (CodigoItem.Length >255)
                {
                    throw new Exception( ErroCodigoItemComprimento);
                }
                if (string.IsNullOrEmpty(PedidoNumero))
                {
                    throw new Exception(ErroPedidoNumeroObrigatorio);
                }
                if (PedidoNumero.Length >255)
                {
                    throw new Exception( ErroPedidoNumeroComprimento);
                }
                if (string.IsNullOrEmpty(PedidoCliente))
                {
                    throw new Exception(ErroPedidoClienteObrigatorio);
                }
                if (PedidoCliente.Length >255)
                {
                    throw new Exception( ErroPedidoClienteComprimento);
                }
                if ( _valuePlanoCorteItem == null)
                {
                    throw new Exception(ErroPlanoCorteItemObrigatorio);
                }
                if ( _valueOrderItemEtiqueta == null)
                {
                    throw new Exception(ErroOrderItemEtiquetaObrigatorio);
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
                    "  public.plano_corte_item_pedido  " +
                    "WHERE " +
                    "  id_plano_corte_item_pedido = :id";
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
                        "  public.plano_corte_item_pedido   " +
                        "SET  " + 
                        "  id_plano_corte_item = :id_plano_corte_item, " + 
                        "  id_order_item_etiqueta = :id_order_item_etiqueta, " + 
                        "  pcp_codigo_item = :pcp_codigo_item, " + 
                        "  pcp_quantidade = :pcp_quantidade, " + 
                        "  pcp_pedido_numero = :pcp_pedido_numero, " + 
                        "  pcp_pedido_posicao = :pcp_pedido_posicao, " + 
                        "  pcp_pedido_cliente = :pcp_pedido_cliente, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_plano_corte_item_pedido = :id " +
                        "RETURNING id_plano_corte_item_pedido;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.plano_corte_item_pedido " +
                        "( " +
                        "  id_plano_corte_item , " + 
                        "  id_order_item_etiqueta , " + 
                        "  pcp_codigo_item , " + 
                        "  pcp_quantidade , " + 
                        "  pcp_pedido_numero , " + 
                        "  pcp_pedido_posicao , " + 
                        "  pcp_pedido_cliente , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_plano_corte_item , " + 
                        "  :id_order_item_etiqueta , " + 
                        "  :pcp_codigo_item , " + 
                        "  :pcp_quantidade , " + 
                        "  :pcp_pedido_numero , " + 
                        "  :pcp_pedido_posicao , " + 
                        "  :pcp_pedido_cliente , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_plano_corte_item_pedido;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_plano_corte_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PlanoCorteItem==null ? (object) DBNull.Value : this.PlanoCorteItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiqueta==null ? (object) DBNull.Value : this.OrderItemEtiqueta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcp_codigo_item", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcp_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcp_pedido_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PedidoNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcp_pedido_posicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PedidoPosicao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pcp_pedido_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PedidoCliente ?? DBNull.Value;
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
        public static PlanoCorteItemPedidoClass CopiarEntidade(PlanoCorteItemPedidoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PlanoCorteItemPedidoClass toRet = new PlanoCorteItemPedidoClass(usuario,conn);
 toRet.PlanoCorteItem= entidadeCopiar.PlanoCorteItem;
 toRet.OrderItemEtiqueta= entidadeCopiar.OrderItemEtiqueta;
 toRet.CodigoItem= entidadeCopiar.CodigoItem;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.PedidoNumero= entidadeCopiar.PedidoNumero;
 toRet.PedidoPosicao= entidadeCopiar.PedidoPosicao;
 toRet.PedidoCliente= entidadeCopiar.PedidoCliente;

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
       _planoCorteItemOriginal = PlanoCorteItem;
       _planoCorteItemOriginalCommited = _planoCorteItemOriginal;
       _orderItemEtiquetaOriginal = OrderItemEtiqueta;
       _orderItemEtiquetaOriginalCommited = _orderItemEtiquetaOriginal;
       _codigoItemOriginal = CodigoItem;
       _codigoItemOriginalCommited = _codigoItemOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _pedidoNumeroOriginal = PedidoNumero;
       _pedidoNumeroOriginalCommited = _pedidoNumeroOriginal;
       _pedidoPosicaoOriginal = PedidoPosicao;
       _pedidoPosicaoOriginalCommited = _pedidoPosicaoOriginal;
       _pedidoClienteOriginal = PedidoCliente;
       _pedidoClienteOriginalCommited = _pedidoClienteOriginal;
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
       _planoCorteItemOriginalCommited = PlanoCorteItem;
       _orderItemEtiquetaOriginalCommited = OrderItemEtiqueta;
       _codigoItemOriginalCommited = CodigoItem;
       _quantidadeOriginalCommited = Quantidade;
       _pedidoNumeroOriginalCommited = PedidoNumero;
       _pedidoPosicaoOriginalCommited = PedidoPosicao;
       _pedidoClienteOriginalCommited = PedidoCliente;
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
               PlanoCorteItem=_planoCorteItemOriginal;
               _planoCorteItemOriginalCommited=_planoCorteItemOriginal;
               OrderItemEtiqueta=_orderItemEtiquetaOriginal;
               _orderItemEtiquetaOriginalCommited=_orderItemEtiquetaOriginal;
               CodigoItem=_codigoItemOriginal;
               _codigoItemOriginalCommited=_codigoItemOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               PedidoNumero=_pedidoNumeroOriginal;
               _pedidoNumeroOriginalCommited=_pedidoNumeroOriginal;
               PedidoPosicao=_pedidoPosicaoOriginal;
               _pedidoPosicaoOriginalCommited=_pedidoPosicaoOriginal;
               PedidoCliente=_pedidoClienteOriginal;
               _pedidoClienteOriginalCommited=_pedidoClienteOriginal;
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
       if (_planoCorteItemOriginal!=null)
       {
          dirty = !_planoCorteItemOriginal.Equals(PlanoCorteItem);
       }
       else
       {
            dirty = PlanoCorteItem != null;
       }
      if (dirty) return true;
       if (_orderItemEtiquetaOriginal!=null)
       {
          dirty = !_orderItemEtiquetaOriginal.Equals(OrderItemEtiqueta);
       }
       else
       {
            dirty = OrderItemEtiqueta != null;
       }
      if (dirty) return true;
       dirty = _codigoItemOriginal != CodigoItem;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _pedidoNumeroOriginal != PedidoNumero;
      if (dirty) return true;
       dirty = _pedidoPosicaoOriginal != PedidoPosicao;
      if (dirty) return true;
       dirty = _pedidoClienteOriginal != PedidoCliente;
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
       if (_planoCorteItemOriginalCommited!=null)
       {
          dirty = !_planoCorteItemOriginalCommited.Equals(PlanoCorteItem);
       }
       else
       {
            dirty = PlanoCorteItem != null;
       }
      if (dirty) return true;
       if (_orderItemEtiquetaOriginalCommited!=null)
       {
          dirty = !_orderItemEtiquetaOriginalCommited.Equals(OrderItemEtiqueta);
       }
       else
       {
            dirty = OrderItemEtiqueta != null;
       }
      if (dirty) return true;
       dirty = _codigoItemOriginalCommited != CodigoItem;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _pedidoNumeroOriginalCommited != PedidoNumero;
      if (dirty) return true;
       dirty = _pedidoPosicaoOriginalCommited != PedidoPosicao;
      if (dirty) return true;
       dirty = _pedidoClienteOriginalCommited != PedidoCliente;
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
             case "PlanoCorteItem":
                return this.PlanoCorteItem;
             case "OrderItemEtiqueta":
                return this.OrderItemEtiqueta;
             case "CodigoItem":
                return this.CodigoItem;
             case "Quantidade":
                return this.Quantidade;
             case "PedidoNumero":
                return this.PedidoNumero;
             case "PedidoPosicao":
                return this.PedidoPosicao;
             case "PedidoCliente":
                return this.PedidoCliente;
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
             if (PlanoCorteItem!=null)
                PlanoCorteItem.ChangeSingleConnection(newConnection);
             if (OrderItemEtiqueta!=null)
                OrderItemEtiqueta.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(plano_corte_item_pedido.id_plano_corte_item_pedido) " ;
               }
               else
               {
               command.CommandText += "plano_corte_item_pedido.id_plano_corte_item_pedido, " ;
               command.CommandText += "plano_corte_item_pedido.id_plano_corte_item, " ;
               command.CommandText += "plano_corte_item_pedido.id_order_item_etiqueta, " ;
               command.CommandText += "plano_corte_item_pedido.pcp_codigo_item, " ;
               command.CommandText += "plano_corte_item_pedido.pcp_quantidade, " ;
               command.CommandText += "plano_corte_item_pedido.pcp_pedido_numero, " ;
               command.CommandText += "plano_corte_item_pedido.pcp_pedido_posicao, " ;
               command.CommandText += "plano_corte_item_pedido.pcp_pedido_cliente, " ;
               command.CommandText += "plano_corte_item_pedido.entity_uid, " ;
               command.CommandText += "plano_corte_item_pedido.version " ;
               }
               command.CommandText += " FROM  plano_corte_item_pedido ";
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
                        orderByClause += " , pcp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pcp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = plano_corte_item_pedido.id_acs_usuario_ultima_revisao ";
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
                     case "id_plano_corte_item_pedido":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item_pedido.id_plano_corte_item_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item_pedido.id_plano_corte_item_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_plano_corte_item":
                     case "PlanoCorteItem":
                     command.CommandText += " LEFT JOIN plano_corte_item as plano_corte_item_PlanoCorteItem ON plano_corte_item_PlanoCorteItem.id_plano_corte_item = plano_corte_item_pedido.id_plano_corte_item ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item_PlanoCorteItem.id_plano_corte_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item_PlanoCorteItem.id_plano_corte_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_order_item_etiqueta":
                     case "OrderItemEtiqueta":
                     command.CommandText += " LEFT JOIN order_item_etiqueta as order_item_etiqueta_OrderItemEtiqueta ON order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta = plano_corte_item_pedido.id_order_item_etiqueta ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.oie_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.oie_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.oie_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.oie_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcp_codigo_item":
                     case "CodigoItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item_pedido.pcp_codigo_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item_pedido.pcp_codigo_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcp_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item_pedido.pcp_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item_pedido.pcp_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcp_pedido_numero":
                     case "PedidoNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item_pedido.pcp_pedido_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item_pedido.pcp_pedido_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcp_pedido_posicao":
                     case "PedidoPosicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , plano_corte_item_pedido.pcp_pedido_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item_pedido.pcp_pedido_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pcp_pedido_cliente":
                     case "PedidoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item_pedido.pcp_pedido_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item_pedido.pcp_pedido_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , plano_corte_item_pedido.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(plano_corte_item_pedido.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , plano_corte_item_pedido.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(plano_corte_item_pedido.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcp_codigo_item")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item_pedido.pcp_codigo_item) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item_pedido.pcp_codigo_item) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcp_pedido_numero")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item_pedido.pcp_pedido_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item_pedido.pcp_pedido_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pcp_pedido_cliente")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item_pedido.pcp_pedido_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item_pedido.pcp_pedido_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(plano_corte_item_pedido.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(plano_corte_item_pedido.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_plano_corte_item_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.id_plano_corte_item_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.id_plano_corte_item_pedido = :plano_corte_item_pedido_ID_2388 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_ID_2388", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteItem" || parametro.FieldName == "id_plano_corte_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PlanoCorteItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PlanoCorteItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.id_plano_corte_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.id_plano_corte_item = :plano_corte_item_pedido_PlanoCorteItem_9781 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_PlanoCorteItem_9781", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderItemEtiqueta" || parametro.FieldName == "id_order_item_etiqueta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrderItemEtiquetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.id_order_item_etiqueta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.id_order_item_etiqueta = :plano_corte_item_pedido_OrderItemEtiqueta_6458 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_OrderItemEtiqueta_6458", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItem" || parametro.FieldName == "pcp_codigo_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_codigo_item LIKE :plano_corte_item_pedido_CodigoItem_3734 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_CodigoItem_3734", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "pcp_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_quantidade = :plano_corte_item_pedido_Quantidade_8726 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_Quantidade_8726", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoNumero" || parametro.FieldName == "pcp_pedido_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_numero LIKE :plano_corte_item_pedido_PedidoNumero_5964 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_PedidoNumero_5964", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoPosicao" || parametro.FieldName == "pcp_pedido_posicao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_posicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_posicao = :plano_corte_item_pedido_PedidoPosicao_3344 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_PedidoPosicao_3344", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoCliente" || parametro.FieldName == "pcp_pedido_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_cliente LIKE :plano_corte_item_pedido_PedidoCliente_237 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_PedidoCliente_237", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  plano_corte_item_pedido.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.entity_uid LIKE :plano_corte_item_pedido_EntityUid_7279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_EntityUid_7279", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  plano_corte_item_pedido.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.version = :plano_corte_item_pedido_Version_6211 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_Version_6211", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemExato" || parametro.FieldName == "CodigoItemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_codigo_item LIKE :plano_corte_item_pedido_CodigoItem_58 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_CodigoItem_58", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_numero LIKE :plano_corte_item_pedido_PedidoNumero_786 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_PedidoNumero_786", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoClienteExato" || parametro.FieldName == "PedidoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.pcp_pedido_cliente LIKE :plano_corte_item_pedido_PedidoCliente_7216 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_PedidoCliente_7216", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  plano_corte_item_pedido.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  plano_corte_item_pedido.entity_uid LIKE :plano_corte_item_pedido_EntityUid_4059 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("plano_corte_item_pedido_EntityUid_4059", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PlanoCorteItemPedidoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PlanoCorteItemPedidoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PlanoCorteItemPedidoClass), Convert.ToInt32(read["id_plano_corte_item_pedido"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PlanoCorteItemPedidoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_plano_corte_item_pedido"]);
                     if (read["id_plano_corte_item"] != DBNull.Value)
                     {
                        entidade.PlanoCorteItem = (BibliotecaEntidades.Entidades.PlanoCorteItemClass)BibliotecaEntidades.Entidades.PlanoCorteItemClass.GetEntidade(Convert.ToInt32(read["id_plano_corte_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PlanoCorteItem = null ;
                     }
                     if (read["id_order_item_etiqueta"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiqueta = (BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiqueta = null ;
                     }
                     entidade.CodigoItem = (read["pcp_codigo_item"] != DBNull.Value ? read["pcp_codigo_item"].ToString() : null);
                     entidade.Quantidade = (double)read["pcp_quantidade"];
                     entidade.PedidoNumero = (read["pcp_pedido_numero"] != DBNull.Value ? read["pcp_pedido_numero"].ToString() : null);
                     entidade.PedidoPosicao = (int)read["pcp_pedido_posicao"];
                     entidade.PedidoCliente = (read["pcp_pedido_cliente"] != DBNull.Value ? read["pcp_pedido_cliente"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PlanoCorteItemPedidoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
