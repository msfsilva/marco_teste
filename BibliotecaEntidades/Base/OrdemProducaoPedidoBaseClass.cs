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
     [Table("ordem_producao_pedido","opp")]
     public class OrdemProducaoPedidoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoPedidoClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoPedidoClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoPedidoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoPedidoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoPedidoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _valueOrdemProducao;
        [Column("id_ordem_producao", "ordem_producao", "id_ordem_producao")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoClass OrdemProducao
        { 
           get {                 return this._valueOrdemProducao; } 
           set 
           { 
                if (this._valueOrdemProducao == value)return;
                 this._valueOrdemProducao = value; 
           } 
       } 

       protected string _produtoCodigoOriginal{get;private set;}
       private string _produtoCodigoOriginalCommited{get; set;}
        private string _valueProdutoCodigo;
         [Column("opp_produto_codigo")]
        public virtual string ProdutoCodigo
         { 
            get { return this._valueProdutoCodigo; } 
            set 
            { 
                if (this._valueProdutoCodigo == value)return;
                 this._valueProdutoCodigo = value; 
            } 
        } 

       protected string _produtoDescricaoOriginal{get;private set;}
       private string _produtoDescricaoOriginalCommited{get; set;}
        private string _valueProdutoDescricao;
         [Column("opp_produto_descricao")]
        public virtual string ProdutoDescricao
         { 
            get { return this._valueProdutoDescricao; } 
            set 
            { 
                if (this._valueProdutoDescricao == value)return;
                 this._valueProdutoDescricao = value; 
            } 
        } 

       protected string _orderNumberOriginal{get;private set;}
       private string _orderNumberOriginalCommited{get; set;}
        private string _valueOrderNumber;
         [Column("opp_order_number")]
        public virtual string OrderNumber
         { 
            get { return this._valueOrderNumber; } 
            set 
            { 
                if (this._valueOrderNumber == value)return;
                 this._valueOrderNumber = value; 
            } 
        } 

       protected int? _orderPosOriginal{get;private set;}
       private int? _orderPosOriginalCommited{get; set;}
        private int? _valueOrderPos;
         [Column("opp_order_pos")]
        public virtual int? OrderPos
         { 
            get { return this._valueOrderPos; } 
            set 
            { 
                if (this._valueOrderPos == value)return;
                 this._valueOrderPos = value; 
            } 
        } 

       protected string _variavel1Original{get;private set;}
       private string _variavel1OriginalCommited{get; set;}
        private string _valueVariavel1;
         [Column("opp_variavel_1")]
        public virtual string Variavel1
         { 
            get { return this._valueVariavel1; } 
            set 
            { 
                if (this._valueVariavel1 == value)return;
                 this._valueVariavel1 = value; 
            } 
        } 

       protected string _valorVariavel1Original{get;private set;}
       private string _valorVariavel1OriginalCommited{get; set;}
        private string _valueValorVariavel1;
         [Column("opp_valor_variavel_1")]
        public virtual string ValorVariavel1
         { 
            get { return this._valueValorVariavel1; } 
            set 
            { 
                if (this._valueValorVariavel1 == value)return;
                 this._valueValorVariavel1 = value; 
            } 
        } 

       protected string _variavel2Original{get;private set;}
       private string _variavel2OriginalCommited{get; set;}
        private string _valueVariavel2;
         [Column("opp_variavel_2")]
        public virtual string Variavel2
         { 
            get { return this._valueVariavel2; } 
            set 
            { 
                if (this._valueVariavel2 == value)return;
                 this._valueVariavel2 = value; 
            } 
        } 

       protected string _valorVariavel2Original{get;private set;}
       private string _valorVariavel2OriginalCommited{get; set;}
        private string _valueValorVariavel2;
         [Column("opp_valor_variavel_2")]
        public virtual string ValorVariavel2
         { 
            get { return this._valueValorVariavel2; } 
            set 
            { 
                if (this._valueValorVariavel2 == value)return;
                 this._valueValorVariavel2 = value; 
            } 
        } 

       protected string _variavel3Original{get;private set;}
       private string _variavel3OriginalCommited{get; set;}
        private string _valueVariavel3;
         [Column("opp_variavel_3")]
        public virtual string Variavel3
         { 
            get { return this._valueVariavel3; } 
            set 
            { 
                if (this._valueVariavel3 == value)return;
                 this._valueVariavel3 = value; 
            } 
        } 

       protected string _valorVariavel3Original{get;private set;}
       private string _valorVariavel3OriginalCommited{get; set;}
        private string _valueValorVariavel3;
         [Column("opp_valor_variavel_3")]
        public virtual string ValorVariavel3
         { 
            get { return this._valueValorVariavel3; } 
            set 
            { 
                if (this._valueValorVariavel3 == value)return;
                 this._valueValorVariavel3 = value; 
            } 
        } 

       protected string _variavel4Original{get;private set;}
       private string _variavel4OriginalCommited{get; set;}
        private string _valueVariavel4;
         [Column("opp_variavel_4")]
        public virtual string Variavel4
         { 
            get { return this._valueVariavel4; } 
            set 
            { 
                if (this._valueVariavel4 == value)return;
                 this._valueVariavel4 = value; 
            } 
        } 

       protected string _valorVariavel4Original{get;private set;}
       private string _valorVariavel4OriginalCommited{get; set;}
        private string _valueValorVariavel4;
         [Column("opp_valor_variavel_4")]
        public virtual string ValorVariavel4
         { 
            get { return this._valueValorVariavel4; } 
            set 
            { 
                if (this._valueValorVariavel4 == value)return;
                 this._valueValorVariavel4 = value; 
            } 
        } 

       protected double? _quantidadeOriginal{get;private set;}
       private double? _quantidadeOriginalCommited{get; set;}
        private double? _valueQuantidade;
         [Column("opp_quantidade")]
        public virtual double? Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected string _tipoDocumentoOriginal{get;private set;}
       private string _tipoDocumentoOriginalCommited{get; set;}
        private string _valueTipoDocumento;
         [Column("opp_tipo_documento")]
        public virtual string TipoDocumento
         { 
            get { return this._valueTipoDocumento; } 
            set 
            { 
                if (this._valueTipoDocumento == value)return;
                 this._valueTipoDocumento = value; 
            } 
        } 

       protected string _numeroDocumentoOriginal{get;private set;}
       private string _numeroDocumentoOriginalCommited{get; set;}
        private string _valueNumeroDocumento;
         [Column("opp_numero_documento")]
        public virtual string NumeroDocumento
         { 
            get { return this._valueNumeroDocumento; } 
            set 
            { 
                if (this._valueNumeroDocumento == value)return;
                 this._valueNumeroDocumento = value; 
            } 
        } 

       protected string _safOriginal{get;private set;}
       private string _safOriginalCommited{get; set;}
        private string _valueSaf;
         [Column("opp_saf")]
        public virtual string Saf
         { 
            get { return this._valueSaf; } 
            set 
            { 
                if (this._valueSaf == value)return;
                 this._valueSaf = value; 
            } 
        } 

       protected string _cncOriginal{get;private set;}
       private string _cncOriginalCommited{get; set;}
        private string _valueCnc;
         [Column("opp_cnc")]
        public virtual string Cnc
         { 
            get { return this._valueCnc; } 
            set 
            { 
                if (this._valueCnc == value)return;
                 this._valueCnc = value; 
            } 
        } 

       protected string _tipoLigacaoOriginal{get;private set;}
       private string _tipoLigacaoOriginalCommited{get; set;}
        private string _valueTipoLigacao;
         [Column("opp_tipo_ligacao")]
        public virtual string TipoLigacao
         { 
            get { return this._valueTipoLigacao; } 
            set 
            { 
                if (this._valueTipoLigacao == value)return;
                 this._valueTipoLigacao = value; 
            } 
        } 

       protected string _produtoCodigoPaiOriginal{get;private set;}
       private string _produtoCodigoPaiOriginalCommited{get; set;}
        private string _valueProdutoCodigoPai;
         [Column("opp_produto_codigo_pai")]
        public virtual string ProdutoCodigoPai
         { 
            get { return this._valueProdutoCodigoPai; } 
            set 
            { 
                if (this._valueProdutoCodigoPai == value)return;
                 this._valueProdutoCodigoPai = value; 
            } 
        } 

       protected string _clienteOriginal{get;private set;}
       private string _clienteOriginalCommited{get; set;}
        private string _valueCliente;
         [Column("opp_cliente")]
        public virtual string Cliente
         { 
            get { return this._valueCliente; } 
            set 
            { 
                if (this._valueCliente == value)return;
                 this._valueCliente = value; 
            } 
        } 

       protected int? _semanaEntregaOriginal{get;private set;}
       private int? _semanaEntregaOriginalCommited{get; set;}
        private int? _valueSemanaEntrega;
         [Column("opp_semana_entrega")]
        public virtual int? SemanaEntrega
         { 
            get { return this._valueSemanaEntrega; } 
            set 
            { 
                if (this._valueSemanaEntrega == value)return;
                 this._valueSemanaEntrega = value; 
            } 
        } 

       protected string _revisaoDocumentoOriginal{get;private set;}
       private string _revisaoDocumentoOriginalCommited{get; set;}
        private string _valueRevisaoDocumento;
         [Column("opp_revisao_documento")]
        public virtual string RevisaoDocumento
         { 
            get { return this._valueRevisaoDocumento; } 
            set 
            { 
                if (this._valueRevisaoDocumento == value)return;
                 this._valueRevisaoDocumento = value; 
            } 
        } 

       protected string _dimensaoOriginal{get;private set;}
       private string _dimensaoOriginalCommited{get; set;}
        private string _valueDimensao;
         [Column("opp_dimensao")]
        public virtual string Dimensao
         { 
            get { return this._valueDimensao; } 
            set 
            { 
                if (this._valueDimensao == value)return;
                 this._valueDimensao = value; 
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

       protected string _produtoAcabamentoPaiOriginal{get;private set;}
       private string _produtoAcabamentoPaiOriginalCommited{get; set;}
        private string _valueProdutoAcabamentoPai;
         [Column("opp_produto_acabamento_pai")]
        public virtual string ProdutoAcabamentoPai
         { 
            get { return this._valueProdutoAcabamentoPai; } 
            set 
            { 
                if (this._valueProdutoAcabamentoPai == value)return;
                 this._valueProdutoAcabamentoPai = value; 
            } 
        } 

       protected string _produtoDescricaoPaiOriginal{get;private set;}
       private string _produtoDescricaoPaiOriginalCommited{get; set;}
        private string _valueProdutoDescricaoPai;
         [Column("opp_produto_descricao_pai")]
        public virtual string ProdutoDescricaoPai
         { 
            get { return this._valueProdutoDescricaoPai; } 
            set 
            { 
                if (this._valueProdutoDescricaoPai == value)return;
                 this._valueProdutoDescricaoPai = value; 
            } 
        } 

        public OrdemProducaoPedidoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static OrdemProducaoPedidoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoPedidoClass) GetEntity(typeof(OrdemProducaoPedidoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

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
                    "  public.ordem_producao_pedido  " +
                    "WHERE " +
                    "  id_ordem_producao_pedido = :id";
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
                        "  public.ordem_producao_pedido   " +
                        "SET  " + 
                        "  id_ordem_producao = :id_ordem_producao, " + 
                        "  opp_produto_codigo = :opp_produto_codigo, " + 
                        "  opp_produto_descricao = :opp_produto_descricao, " + 
                        "  opp_order_number = :opp_order_number, " + 
                        "  opp_order_pos = :opp_order_pos, " + 
                        "  opp_variavel_1 = :opp_variavel_1, " + 
                        "  opp_valor_variavel_1 = :opp_valor_variavel_1, " + 
                        "  opp_variavel_2 = :opp_variavel_2, " + 
                        "  opp_valor_variavel_2 = :opp_valor_variavel_2, " + 
                        "  opp_variavel_3 = :opp_variavel_3, " + 
                        "  opp_valor_variavel_3 = :opp_valor_variavel_3, " + 
                        "  opp_variavel_4 = :opp_variavel_4, " + 
                        "  opp_valor_variavel_4 = :opp_valor_variavel_4, " + 
                        "  opp_quantidade = :opp_quantidade, " + 
                        "  opp_tipo_documento = :opp_tipo_documento, " + 
                        "  opp_numero_documento = :opp_numero_documento, " + 
                        "  opp_saf = :opp_saf, " + 
                        "  opp_cnc = :opp_cnc, " + 
                        "  opp_tipo_ligacao = :opp_tipo_ligacao, " + 
                        "  opp_produto_codigo_pai = :opp_produto_codigo_pai, " + 
                        "  opp_cliente = :opp_cliente, " + 
                        "  opp_semana_entrega = :opp_semana_entrega, " + 
                        "  opp_revisao_documento = :opp_revisao_documento, " + 
                        "  opp_dimensao = :opp_dimensao, " + 
                        "  id_order_item_etiqueta = :id_order_item_etiqueta, " + 
                        "  opp_produto_acabamento_pai = :opp_produto_acabamento_pai, " + 
                        "  opp_produto_descricao_pai = :opp_produto_descricao_pai, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_pedido = :id " +
                        "RETURNING id_ordem_producao_pedido;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_pedido " +
                        "( " +
                        "  id_ordem_producao , " + 
                        "  opp_produto_codigo , " + 
                        "  opp_produto_descricao , " + 
                        "  opp_order_number , " + 
                        "  opp_order_pos , " + 
                        "  opp_variavel_1 , " + 
                        "  opp_valor_variavel_1 , " + 
                        "  opp_variavel_2 , " + 
                        "  opp_valor_variavel_2 , " + 
                        "  opp_variavel_3 , " + 
                        "  opp_valor_variavel_3 , " + 
                        "  opp_variavel_4 , " + 
                        "  opp_valor_variavel_4 , " + 
                        "  opp_quantidade , " + 
                        "  opp_tipo_documento , " + 
                        "  opp_numero_documento , " + 
                        "  opp_saf , " + 
                        "  opp_cnc , " + 
                        "  opp_tipo_ligacao , " + 
                        "  opp_produto_codigo_pai , " + 
                        "  opp_cliente , " + 
                        "  opp_semana_entrega , " + 
                        "  opp_revisao_documento , " + 
                        "  opp_dimensao , " + 
                        "  id_order_item_etiqueta , " + 
                        "  opp_produto_acabamento_pai , " + 
                        "  opp_produto_descricao_pai , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao , " + 
                        "  :opp_produto_codigo , " + 
                        "  :opp_produto_descricao , " + 
                        "  :opp_order_number , " + 
                        "  :opp_order_pos , " + 
                        "  :opp_variavel_1 , " + 
                        "  :opp_valor_variavel_1 , " + 
                        "  :opp_variavel_2 , " + 
                        "  :opp_valor_variavel_2 , " + 
                        "  :opp_variavel_3 , " + 
                        "  :opp_valor_variavel_3 , " + 
                        "  :opp_variavel_4 , " + 
                        "  :opp_valor_variavel_4 , " + 
                        "  :opp_quantidade , " + 
                        "  :opp_tipo_documento , " + 
                        "  :opp_numero_documento , " + 
                        "  :opp_saf , " + 
                        "  :opp_cnc , " + 
                        "  :opp_tipo_ligacao , " + 
                        "  :opp_produto_codigo_pai , " + 
                        "  :opp_cliente , " + 
                        "  :opp_semana_entrega , " + 
                        "  :opp_revisao_documento , " + 
                        "  :opp_dimensao , " + 
                        "  :id_order_item_etiqueta , " + 
                        "  :opp_produto_acabamento_pai , " + 
                        "  :opp_produto_descricao_pai , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_pedido;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducao==null ? (object) DBNull.Value : this.OrdemProducao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoCodigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoDescricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderNumber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_order_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderPos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_variavel_1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Variavel1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_valor_variavel_1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorVariavel1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_variavel_2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Variavel2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_valor_variavel_2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorVariavel2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_variavel_3", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Variavel3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_valor_variavel_3", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorVariavel3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_variavel_4", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Variavel4 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_valor_variavel_4", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorVariavel4 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_tipo_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_numero_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_saf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Saf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_cnc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_tipo_ligacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoLigacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_codigo_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoCodigoPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_semana_entrega", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SemanaEntrega ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_revisao_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RevisaoDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_dimensao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Dimensao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiqueta==null ? (object) DBNull.Value : this.OrderItemEtiqueta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_acabamento_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoAcabamentoPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_descricao_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoDescricaoPai ?? DBNull.Value;
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
        public static OrdemProducaoPedidoClass CopiarEntidade(OrdemProducaoPedidoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoPedidoClass toRet = new OrdemProducaoPedidoClass(usuario,conn);
 toRet.OrdemProducao= entidadeCopiar.OrdemProducao;
 toRet.ProdutoCodigo= entidadeCopiar.ProdutoCodigo;
 toRet.ProdutoDescricao= entidadeCopiar.ProdutoDescricao;
 toRet.OrderNumber= entidadeCopiar.OrderNumber;
 toRet.OrderPos= entidadeCopiar.OrderPos;
 toRet.Variavel1= entidadeCopiar.Variavel1;
 toRet.ValorVariavel1= entidadeCopiar.ValorVariavel1;
 toRet.Variavel2= entidadeCopiar.Variavel2;
 toRet.ValorVariavel2= entidadeCopiar.ValorVariavel2;
 toRet.Variavel3= entidadeCopiar.Variavel3;
 toRet.ValorVariavel3= entidadeCopiar.ValorVariavel3;
 toRet.Variavel4= entidadeCopiar.Variavel4;
 toRet.ValorVariavel4= entidadeCopiar.ValorVariavel4;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.TipoDocumento= entidadeCopiar.TipoDocumento;
 toRet.NumeroDocumento= entidadeCopiar.NumeroDocumento;
 toRet.Saf= entidadeCopiar.Saf;
 toRet.Cnc= entidadeCopiar.Cnc;
 toRet.TipoLigacao= entidadeCopiar.TipoLigacao;
 toRet.ProdutoCodigoPai= entidadeCopiar.ProdutoCodigoPai;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.SemanaEntrega= entidadeCopiar.SemanaEntrega;
 toRet.RevisaoDocumento= entidadeCopiar.RevisaoDocumento;
 toRet.Dimensao= entidadeCopiar.Dimensao;
 toRet.OrderItemEtiqueta= entidadeCopiar.OrderItemEtiqueta;
 toRet.ProdutoAcabamentoPai= entidadeCopiar.ProdutoAcabamentoPai;
 toRet.ProdutoDescricaoPai= entidadeCopiar.ProdutoDescricaoPai;

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
       _ordemProducaoOriginal = OrdemProducao;
       _ordemProducaoOriginalCommited = _ordemProducaoOriginal;
       _produtoCodigoOriginal = ProdutoCodigo;
       _produtoCodigoOriginalCommited = _produtoCodigoOriginal;
       _produtoDescricaoOriginal = ProdutoDescricao;
       _produtoDescricaoOriginalCommited = _produtoDescricaoOriginal;
       _orderNumberOriginal = OrderNumber;
       _orderNumberOriginalCommited = _orderNumberOriginal;
       _orderPosOriginal = OrderPos;
       _orderPosOriginalCommited = _orderPosOriginal;
       _variavel1Original = Variavel1;
       _variavel1OriginalCommited = _variavel1Original;
       _valorVariavel1Original = ValorVariavel1;
       _valorVariavel1OriginalCommited = _valorVariavel1Original;
       _variavel2Original = Variavel2;
       _variavel2OriginalCommited = _variavel2Original;
       _valorVariavel2Original = ValorVariavel2;
       _valorVariavel2OriginalCommited = _valorVariavel2Original;
       _variavel3Original = Variavel3;
       _variavel3OriginalCommited = _variavel3Original;
       _valorVariavel3Original = ValorVariavel3;
       _valorVariavel3OriginalCommited = _valorVariavel3Original;
       _variavel4Original = Variavel4;
       _variavel4OriginalCommited = _variavel4Original;
       _valorVariavel4Original = ValorVariavel4;
       _valorVariavel4OriginalCommited = _valorVariavel4Original;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _tipoDocumentoOriginal = TipoDocumento;
       _tipoDocumentoOriginalCommited = _tipoDocumentoOriginal;
       _numeroDocumentoOriginal = NumeroDocumento;
       _numeroDocumentoOriginalCommited = _numeroDocumentoOriginal;
       _safOriginal = Saf;
       _safOriginalCommited = _safOriginal;
       _cncOriginal = Cnc;
       _cncOriginalCommited = _cncOriginal;
       _tipoLigacaoOriginal = TipoLigacao;
       _tipoLigacaoOriginalCommited = _tipoLigacaoOriginal;
       _produtoCodigoPaiOriginal = ProdutoCodigoPai;
       _produtoCodigoPaiOriginalCommited = _produtoCodigoPaiOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _semanaEntregaOriginal = SemanaEntrega;
       _semanaEntregaOriginalCommited = _semanaEntregaOriginal;
       _revisaoDocumentoOriginal = RevisaoDocumento;
       _revisaoDocumentoOriginalCommited = _revisaoDocumentoOriginal;
       _dimensaoOriginal = Dimensao;
       _dimensaoOriginalCommited = _dimensaoOriginal;
       _orderItemEtiquetaOriginal = OrderItemEtiqueta;
       _orderItemEtiquetaOriginalCommited = _orderItemEtiquetaOriginal;
       _produtoAcabamentoPaiOriginal = ProdutoAcabamentoPai;
       _produtoAcabamentoPaiOriginalCommited = _produtoAcabamentoPaiOriginal;
       _produtoDescricaoPaiOriginal = ProdutoDescricaoPai;
       _produtoDescricaoPaiOriginalCommited = _produtoDescricaoPaiOriginal;
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
       _ordemProducaoOriginalCommited = OrdemProducao;
       _produtoCodigoOriginalCommited = ProdutoCodigo;
       _produtoDescricaoOriginalCommited = ProdutoDescricao;
       _orderNumberOriginalCommited = OrderNumber;
       _orderPosOriginalCommited = OrderPos;
       _variavel1OriginalCommited = Variavel1;
       _valorVariavel1OriginalCommited = ValorVariavel1;
       _variavel2OriginalCommited = Variavel2;
       _valorVariavel2OriginalCommited = ValorVariavel2;
       _variavel3OriginalCommited = Variavel3;
       _valorVariavel3OriginalCommited = ValorVariavel3;
       _variavel4OriginalCommited = Variavel4;
       _valorVariavel4OriginalCommited = ValorVariavel4;
       _quantidadeOriginalCommited = Quantidade;
       _tipoDocumentoOriginalCommited = TipoDocumento;
       _numeroDocumentoOriginalCommited = NumeroDocumento;
       _safOriginalCommited = Saf;
       _cncOriginalCommited = Cnc;
       _tipoLigacaoOriginalCommited = TipoLigacao;
       _produtoCodigoPaiOriginalCommited = ProdutoCodigoPai;
       _clienteOriginalCommited = Cliente;
       _semanaEntregaOriginalCommited = SemanaEntrega;
       _revisaoDocumentoOriginalCommited = RevisaoDocumento;
       _dimensaoOriginalCommited = Dimensao;
       _orderItemEtiquetaOriginalCommited = OrderItemEtiqueta;
       _produtoAcabamentoPaiOriginalCommited = ProdutoAcabamentoPai;
       _produtoDescricaoPaiOriginalCommited = ProdutoDescricaoPai;
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
               OrdemProducao=_ordemProducaoOriginal;
               _ordemProducaoOriginalCommited=_ordemProducaoOriginal;
               ProdutoCodigo=_produtoCodigoOriginal;
               _produtoCodigoOriginalCommited=_produtoCodigoOriginal;
               ProdutoDescricao=_produtoDescricaoOriginal;
               _produtoDescricaoOriginalCommited=_produtoDescricaoOriginal;
               OrderNumber=_orderNumberOriginal;
               _orderNumberOriginalCommited=_orderNumberOriginal;
               OrderPos=_orderPosOriginal;
               _orderPosOriginalCommited=_orderPosOriginal;
               Variavel1=_variavel1Original;
               _variavel1OriginalCommited=_variavel1Original;
               ValorVariavel1=_valorVariavel1Original;
               _valorVariavel1OriginalCommited=_valorVariavel1Original;
               Variavel2=_variavel2Original;
               _variavel2OriginalCommited=_variavel2Original;
               ValorVariavel2=_valorVariavel2Original;
               _valorVariavel2OriginalCommited=_valorVariavel2Original;
               Variavel3=_variavel3Original;
               _variavel3OriginalCommited=_variavel3Original;
               ValorVariavel3=_valorVariavel3Original;
               _valorVariavel3OriginalCommited=_valorVariavel3Original;
               Variavel4=_variavel4Original;
               _variavel4OriginalCommited=_variavel4Original;
               ValorVariavel4=_valorVariavel4Original;
               _valorVariavel4OriginalCommited=_valorVariavel4Original;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               TipoDocumento=_tipoDocumentoOriginal;
               _tipoDocumentoOriginalCommited=_tipoDocumentoOriginal;
               NumeroDocumento=_numeroDocumentoOriginal;
               _numeroDocumentoOriginalCommited=_numeroDocumentoOriginal;
               Saf=_safOriginal;
               _safOriginalCommited=_safOriginal;
               Cnc=_cncOriginal;
               _cncOriginalCommited=_cncOriginal;
               TipoLigacao=_tipoLigacaoOriginal;
               _tipoLigacaoOriginalCommited=_tipoLigacaoOriginal;
               ProdutoCodigoPai=_produtoCodigoPaiOriginal;
               _produtoCodigoPaiOriginalCommited=_produtoCodigoPaiOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               SemanaEntrega=_semanaEntregaOriginal;
               _semanaEntregaOriginalCommited=_semanaEntregaOriginal;
               RevisaoDocumento=_revisaoDocumentoOriginal;
               _revisaoDocumentoOriginalCommited=_revisaoDocumentoOriginal;
               Dimensao=_dimensaoOriginal;
               _dimensaoOriginalCommited=_dimensaoOriginal;
               OrderItemEtiqueta=_orderItemEtiquetaOriginal;
               _orderItemEtiquetaOriginalCommited=_orderItemEtiquetaOriginal;
               ProdutoAcabamentoPai=_produtoAcabamentoPaiOriginal;
               _produtoAcabamentoPaiOriginalCommited=_produtoAcabamentoPaiOriginal;
               ProdutoDescricaoPai=_produtoDescricaoPaiOriginal;
               _produtoDescricaoPaiOriginalCommited=_produtoDescricaoPaiOriginal;
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
       if (_ordemProducaoOriginal!=null)
       {
          dirty = !_ordemProducaoOriginal.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
       }
      if (dirty) return true;
       dirty = _produtoCodigoOriginal != ProdutoCodigo;
      if (dirty) return true;
       dirty = _produtoDescricaoOriginal != ProdutoDescricao;
      if (dirty) return true;
       dirty = _orderNumberOriginal != OrderNumber;
      if (dirty) return true;
       dirty = _orderPosOriginal != OrderPos;
      if (dirty) return true;
       dirty = _variavel1Original != Variavel1;
      if (dirty) return true;
       dirty = _valorVariavel1Original != ValorVariavel1;
      if (dirty) return true;
       dirty = _variavel2Original != Variavel2;
      if (dirty) return true;
       dirty = _valorVariavel2Original != ValorVariavel2;
      if (dirty) return true;
       dirty = _variavel3Original != Variavel3;
      if (dirty) return true;
       dirty = _valorVariavel3Original != ValorVariavel3;
      if (dirty) return true;
       dirty = _variavel4Original != Variavel4;
      if (dirty) return true;
       dirty = _valorVariavel4Original != ValorVariavel4;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _tipoDocumentoOriginal != TipoDocumento;
      if (dirty) return true;
       dirty = _numeroDocumentoOriginal != NumeroDocumento;
      if (dirty) return true;
       dirty = _safOriginal != Saf;
      if (dirty) return true;
       dirty = _cncOriginal != Cnc;
      if (dirty) return true;
       dirty = _tipoLigacaoOriginal != TipoLigacao;
      if (dirty) return true;
       dirty = _produtoCodigoPaiOriginal != ProdutoCodigoPai;
      if (dirty) return true;
       dirty = _clienteOriginal != Cliente;
      if (dirty) return true;
       dirty = _semanaEntregaOriginal != SemanaEntrega;
      if (dirty) return true;
       dirty = _revisaoDocumentoOriginal != RevisaoDocumento;
      if (dirty) return true;
       dirty = _dimensaoOriginal != Dimensao;
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
       dirty = _produtoAcabamentoPaiOriginal != ProdutoAcabamentoPai;
      if (dirty) return true;
       dirty = _produtoDescricaoPaiOriginal != ProdutoDescricaoPai;
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
       if (_ordemProducaoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoOriginalCommited.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
       }
      if (dirty) return true;
       dirty = _produtoCodigoOriginalCommited != ProdutoCodigo;
      if (dirty) return true;
       dirty = _produtoDescricaoOriginalCommited != ProdutoDescricao;
      if (dirty) return true;
       dirty = _orderNumberOriginalCommited != OrderNumber;
      if (dirty) return true;
       dirty = _orderPosOriginalCommited != OrderPos;
      if (dirty) return true;
       dirty = _variavel1OriginalCommited != Variavel1;
      if (dirty) return true;
       dirty = _valorVariavel1OriginalCommited != ValorVariavel1;
      if (dirty) return true;
       dirty = _variavel2OriginalCommited != Variavel2;
      if (dirty) return true;
       dirty = _valorVariavel2OriginalCommited != ValorVariavel2;
      if (dirty) return true;
       dirty = _variavel3OriginalCommited != Variavel3;
      if (dirty) return true;
       dirty = _valorVariavel3OriginalCommited != ValorVariavel3;
      if (dirty) return true;
       dirty = _variavel4OriginalCommited != Variavel4;
      if (dirty) return true;
       dirty = _valorVariavel4OriginalCommited != ValorVariavel4;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _tipoDocumentoOriginalCommited != TipoDocumento;
      if (dirty) return true;
       dirty = _numeroDocumentoOriginalCommited != NumeroDocumento;
      if (dirty) return true;
       dirty = _safOriginalCommited != Saf;
      if (dirty) return true;
       dirty = _cncOriginalCommited != Cnc;
      if (dirty) return true;
       dirty = _tipoLigacaoOriginalCommited != TipoLigacao;
      if (dirty) return true;
       dirty = _produtoCodigoPaiOriginalCommited != ProdutoCodigoPai;
      if (dirty) return true;
       dirty = _clienteOriginalCommited != Cliente;
      if (dirty) return true;
       dirty = _semanaEntregaOriginalCommited != SemanaEntrega;
      if (dirty) return true;
       dirty = _revisaoDocumentoOriginalCommited != RevisaoDocumento;
      if (dirty) return true;
       dirty = _dimensaoOriginalCommited != Dimensao;
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
       dirty = _produtoAcabamentoPaiOriginalCommited != ProdutoAcabamentoPai;
      if (dirty) return true;
       dirty = _produtoDescricaoPaiOriginalCommited != ProdutoDescricaoPai;
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
             case "OrdemProducao":
                return this.OrdemProducao;
             case "ProdutoCodigo":
                return this.ProdutoCodigo;
             case "ProdutoDescricao":
                return this.ProdutoDescricao;
             case "OrderNumber":
                return this.OrderNumber;
             case "OrderPos":
                return this.OrderPos;
             case "Variavel1":
                return this.Variavel1;
             case "ValorVariavel1":
                return this.ValorVariavel1;
             case "Variavel2":
                return this.Variavel2;
             case "ValorVariavel2":
                return this.ValorVariavel2;
             case "Variavel3":
                return this.Variavel3;
             case "ValorVariavel3":
                return this.ValorVariavel3;
             case "Variavel4":
                return this.Variavel4;
             case "ValorVariavel4":
                return this.ValorVariavel4;
             case "Quantidade":
                return this.Quantidade;
             case "TipoDocumento":
                return this.TipoDocumento;
             case "NumeroDocumento":
                return this.NumeroDocumento;
             case "Saf":
                return this.Saf;
             case "Cnc":
                return this.Cnc;
             case "TipoLigacao":
                return this.TipoLigacao;
             case "ProdutoCodigoPai":
                return this.ProdutoCodigoPai;
             case "Cliente":
                return this.Cliente;
             case "SemanaEntrega":
                return this.SemanaEntrega;
             case "RevisaoDocumento":
                return this.RevisaoDocumento;
             case "Dimensao":
                return this.Dimensao;
             case "OrderItemEtiqueta":
                return this.OrderItemEtiqueta;
             case "ProdutoAcabamentoPai":
                return this.ProdutoAcabamentoPai;
             case "ProdutoDescricaoPai":
                return this.ProdutoDescricaoPai;
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
             if (OrdemProducao!=null)
                OrdemProducao.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(ordem_producao_pedido.id_ordem_producao_pedido) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_pedido.id_ordem_producao_pedido, " ;
               command.CommandText += "ordem_producao_pedido.id_ordem_producao, " ;
               command.CommandText += "ordem_producao_pedido.opp_produto_codigo, " ;
               command.CommandText += "ordem_producao_pedido.opp_produto_descricao, " ;
               command.CommandText += "ordem_producao_pedido.opp_order_number, " ;
               command.CommandText += "ordem_producao_pedido.opp_order_pos, " ;
               command.CommandText += "ordem_producao_pedido.opp_variavel_1, " ;
               command.CommandText += "ordem_producao_pedido.opp_valor_variavel_1, " ;
               command.CommandText += "ordem_producao_pedido.opp_variavel_2, " ;
               command.CommandText += "ordem_producao_pedido.opp_valor_variavel_2, " ;
               command.CommandText += "ordem_producao_pedido.opp_variavel_3, " ;
               command.CommandText += "ordem_producao_pedido.opp_valor_variavel_3, " ;
               command.CommandText += "ordem_producao_pedido.opp_variavel_4, " ;
               command.CommandText += "ordem_producao_pedido.opp_valor_variavel_4, " ;
               command.CommandText += "ordem_producao_pedido.opp_quantidade, " ;
               command.CommandText += "ordem_producao_pedido.opp_tipo_documento, " ;
               command.CommandText += "ordem_producao_pedido.opp_numero_documento, " ;
               command.CommandText += "ordem_producao_pedido.opp_saf, " ;
               command.CommandText += "ordem_producao_pedido.opp_cnc, " ;
               command.CommandText += "ordem_producao_pedido.opp_tipo_ligacao, " ;
               command.CommandText += "ordem_producao_pedido.opp_produto_codigo_pai, " ;
               command.CommandText += "ordem_producao_pedido.opp_cliente, " ;
               command.CommandText += "ordem_producao_pedido.opp_semana_entrega, " ;
               command.CommandText += "ordem_producao_pedido.opp_revisao_documento, " ;
               command.CommandText += "ordem_producao_pedido.opp_dimensao, " ;
               command.CommandText += "ordem_producao_pedido.id_order_item_etiqueta, " ;
               command.CommandText += "ordem_producao_pedido.opp_produto_acabamento_pai, " ;
               command.CommandText += "ordem_producao_pedido.opp_produto_descricao_pai, " ;
               command.CommandText += "ordem_producao_pedido.entity_uid, " ;
               command.CommandText += "ordem_producao_pedido.version " ;
               }
               command.CommandText += " FROM  ordem_producao_pedido ";
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
                        orderByClause += " , opp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(opp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_pedido.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_pedido":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_pedido.id_ordem_producao_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_pedido.id_ordem_producao_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao":
                     case "OrdemProducao":
                     command.CommandText += " LEFT JOIN ordem_producao as ordem_producao_OrdemProducao ON ordem_producao_OrdemProducao.id_ordem_producao = ordem_producao_pedido.id_ordem_producao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_OrdemProducao.id_ordem_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_OrdemProducao.id_ordem_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_produto_codigo":
                     case "ProdutoCodigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_produto_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_produto_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_produto_descricao":
                     case "ProdutoDescricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_produto_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_produto_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_order_number":
                     case "OrderNumber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_order_pos":
                     case "OrderPos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_pedido.opp_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_variavel_1":
                     case "Variavel1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_variavel_1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_variavel_1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_valor_variavel_1":
                     case "ValorVariavel1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_valor_variavel_1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_valor_variavel_1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_variavel_2":
                     case "Variavel2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_variavel_2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_variavel_2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_valor_variavel_2":
                     case "ValorVariavel2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_valor_variavel_2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_valor_variavel_2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_variavel_3":
                     case "Variavel3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_variavel_3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_variavel_3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_valor_variavel_3":
                     case "ValorVariavel3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_valor_variavel_3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_valor_variavel_3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_variavel_4":
                     case "Variavel4":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_variavel_4 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_variavel_4) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_valor_variavel_4":
                     case "ValorVariavel4":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_valor_variavel_4 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_valor_variavel_4) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_pedido.opp_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_tipo_documento":
                     case "TipoDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_tipo_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_tipo_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_numero_documento":
                     case "NumeroDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_numero_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_numero_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_saf":
                     case "Saf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_saf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_saf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_cnc":
                     case "Cnc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_cnc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_cnc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_tipo_ligacao":
                     case "TipoLigacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_tipo_ligacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_tipo_ligacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_produto_codigo_pai":
                     case "ProdutoCodigoPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_produto_codigo_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_produto_codigo_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_cliente":
                     case "Cliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_semana_entrega":
                     case "SemanaEntrega":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_pedido.opp_semana_entrega " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_semana_entrega) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_revisao_documento":
                     case "RevisaoDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_revisao_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_revisao_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_dimensao":
                     case "Dimensao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_order_item_etiqueta":
                     case "OrderItemEtiqueta":
                     command.CommandText += " LEFT JOIN order_item_etiqueta as order_item_etiqueta_OrderItemEtiqueta ON order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta = ordem_producao_pedido.id_order_item_etiqueta ";                     switch (parametro.TipoOrdenacao)
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
                     case "opp_produto_acabamento_pai":
                     case "ProdutoAcabamentoPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_produto_acabamento_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_produto_acabamento_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opp_produto_descricao_pai":
                     case "ProdutoDescricaoPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.opp_produto_descricao_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.opp_produto_descricao_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_pedido.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_pedido.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_pedido.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_pedido.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_produto_codigo")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_produto_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_produto_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_produto_descricao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_produto_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_produto_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_order_number")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_order_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_order_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_variavel_1")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_variavel_1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_variavel_1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_valor_variavel_1")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_valor_variavel_1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_valor_variavel_1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_variavel_2")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_variavel_2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_variavel_2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_valor_variavel_2")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_valor_variavel_2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_valor_variavel_2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_variavel_3")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_variavel_3) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_variavel_3) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_valor_variavel_3")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_valor_variavel_3) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_valor_variavel_3) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_variavel_4")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_variavel_4) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_variavel_4) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_valor_variavel_4")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_valor_variavel_4) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_valor_variavel_4) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_tipo_documento")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_tipo_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_tipo_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_numero_documento")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_numero_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_numero_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_saf")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_saf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_saf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_cnc")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_cnc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_cnc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_tipo_ligacao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_tipo_ligacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_tipo_ligacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_produto_codigo_pai")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_produto_codigo_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_produto_codigo_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_cliente")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_revisao_documento")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_revisao_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_revisao_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_dimensao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_dimensao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_dimensao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_produto_acabamento_pai")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_produto_acabamento_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_produto_acabamento_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opp_produto_descricao_pai")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.opp_produto_descricao_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.opp_produto_descricao_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_pedido.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_pedido.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.id_ordem_producao_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.id_ordem_producao_pedido = :ordem_producao_pedido_ID_534 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ID_534", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducao" || parametro.FieldName == "id_ordem_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.id_ordem_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.id_ordem_producao = :ordem_producao_pedido_OrdemProducao_6903 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_OrdemProducao_6903", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoCodigo" || parametro.FieldName == "opp_produto_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_codigo LIKE :ordem_producao_pedido_ProdutoCodigo_5613 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoCodigo_5613", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoDescricao" || parametro.FieldName == "opp_produto_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_descricao LIKE :ordem_producao_pedido_ProdutoDescricao_36 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoDescricao_36", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumber" || parametro.FieldName == "opp_order_number")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_order_number LIKE :ordem_producao_pedido_OrderNumber_1084 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_OrderNumber_1084", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderPos" || parametro.FieldName == "opp_order_pos")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_order_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_order_pos = :ordem_producao_pedido_OrderPos_1914 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_OrderPos_1914", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel1" || parametro.FieldName == "opp_variavel_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_1 LIKE :ordem_producao_pedido_Variavel1_1431 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Variavel1_1431", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorVariavel1" || parametro.FieldName == "opp_valor_variavel_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_1 LIKE :ordem_producao_pedido_ValorVariavel1_8387 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ValorVariavel1_8387", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel2" || parametro.FieldName == "opp_variavel_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_2 LIKE :ordem_producao_pedido_Variavel2_1841 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Variavel2_1841", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorVariavel2" || parametro.FieldName == "opp_valor_variavel_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_2 LIKE :ordem_producao_pedido_ValorVariavel2_863 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ValorVariavel2_863", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel3" || parametro.FieldName == "opp_variavel_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_3 LIKE :ordem_producao_pedido_Variavel3_5401 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Variavel3_5401", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorVariavel3" || parametro.FieldName == "opp_valor_variavel_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_3 LIKE :ordem_producao_pedido_ValorVariavel3_1673 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ValorVariavel3_1673", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel4" || parametro.FieldName == "opp_variavel_4")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_4 LIKE :ordem_producao_pedido_Variavel4_5743 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Variavel4_5743", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorVariavel4" || parametro.FieldName == "opp_valor_variavel_4")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_4 LIKE :ordem_producao_pedido_ValorVariavel4_5443 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ValorVariavel4_5443", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "opp_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_quantidade = :ordem_producao_pedido_Quantidade_9659 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Quantidade_9659", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDocumento" || parametro.FieldName == "opp_tipo_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_tipo_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_tipo_documento LIKE :ordem_producao_pedido_TipoDocumento_1440 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_TipoDocumento_1440", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroDocumento" || parametro.FieldName == "opp_numero_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_numero_documento LIKE :ordem_producao_pedido_NumeroDocumento_5336 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_NumeroDocumento_5336", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Saf" || parametro.FieldName == "opp_saf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_saf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_saf LIKE :ordem_producao_pedido_Saf_4354 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Saf_4354", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnc" || parametro.FieldName == "opp_cnc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_cnc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_cnc LIKE :ordem_producao_pedido_Cnc_9491 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Cnc_9491", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoLigacao" || parametro.FieldName == "opp_tipo_ligacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_tipo_ligacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_tipo_ligacao LIKE :ordem_producao_pedido_TipoLigacao_8039 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_TipoLigacao_8039", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoCodigoPai" || parametro.FieldName == "opp_produto_codigo_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_codigo_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_codigo_pai LIKE :ordem_producao_pedido_ProdutoCodigoPai_5389 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoCodigoPai_5389", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cliente" || parametro.FieldName == "opp_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_cliente LIKE :ordem_producao_pedido_Cliente_7512 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Cliente_7512", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SemanaEntrega" || parametro.FieldName == "opp_semana_entrega")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_semana_entrega IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_semana_entrega = :ordem_producao_pedido_SemanaEntrega_2227 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_SemanaEntrega_2227", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RevisaoDocumento" || parametro.FieldName == "opp_revisao_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_revisao_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_revisao_documento LIKE :ordem_producao_pedido_RevisaoDocumento_9146 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_RevisaoDocumento_9146", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao" || parametro.FieldName == "opp_dimensao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_dimensao LIKE :ordem_producao_pedido_Dimensao_250 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Dimensao_250", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_pedido.id_order_item_etiqueta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.id_order_item_etiqueta = :ordem_producao_pedido_OrderItemEtiqueta_6477 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_OrderItemEtiqueta_6477", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoAcabamentoPai" || parametro.FieldName == "opp_produto_acabamento_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_acabamento_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_acabamento_pai LIKE :ordem_producao_pedido_ProdutoAcabamentoPai_8730 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoAcabamentoPai_8730", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoDescricaoPai" || parametro.FieldName == "opp_produto_descricao_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_descricao_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_descricao_pai LIKE :ordem_producao_pedido_ProdutoDescricaoPai_618 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoDescricaoPai_618", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_pedido.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.entity_uid LIKE :ordem_producao_pedido_EntityUid_240 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_EntityUid_240", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_pedido.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.version = :ordem_producao_pedido_Version_8544 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Version_8544", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoCodigoExato" || parametro.FieldName == "ProdutoCodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_codigo LIKE :ordem_producao_pedido_ProdutoCodigo_3329 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoCodigo_3329", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoDescricaoExato" || parametro.FieldName == "ProdutoDescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_descricao LIKE :ordem_producao_pedido_ProdutoDescricao_7318 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoDescricao_7318", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumberExato" || parametro.FieldName == "OrderNumberExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_order_number LIKE :ordem_producao_pedido_OrderNumber_1269 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_OrderNumber_1269", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel1Exato" || parametro.FieldName == "Variavel1Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_1 LIKE :ordem_producao_pedido_Variavel1_2908 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Variavel1_2908", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorVariavel1Exato" || parametro.FieldName == "ValorVariavel1Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_1 LIKE :ordem_producao_pedido_ValorVariavel1_1856 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ValorVariavel1_1856", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel2Exato" || parametro.FieldName == "Variavel2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_2 LIKE :ordem_producao_pedido_Variavel2_1737 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Variavel2_1737", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorVariavel2Exato" || parametro.FieldName == "ValorVariavel2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_2 LIKE :ordem_producao_pedido_ValorVariavel2_3061 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ValorVariavel2_3061", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel3Exato" || parametro.FieldName == "Variavel3Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_3 LIKE :ordem_producao_pedido_Variavel3_3947 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Variavel3_3947", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorVariavel3Exato" || parametro.FieldName == "ValorVariavel3Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_3 LIKE :ordem_producao_pedido_ValorVariavel3_2182 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ValorVariavel3_2182", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Variavel4Exato" || parametro.FieldName == "Variavel4Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_variavel_4 LIKE :ordem_producao_pedido_Variavel4_4157 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Variavel4_4157", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorVariavel4Exato" || parametro.FieldName == "ValorVariavel4Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_valor_variavel_4 LIKE :ordem_producao_pedido_ValorVariavel4_3531 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ValorVariavel4_3531", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDocumentoExato" || parametro.FieldName == "TipoDocumentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_tipo_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_tipo_documento LIKE :ordem_producao_pedido_TipoDocumento_554 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_TipoDocumento_554", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroDocumentoExato" || parametro.FieldName == "NumeroDocumentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_numero_documento LIKE :ordem_producao_pedido_NumeroDocumento_1691 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_NumeroDocumento_1691", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SafExato" || parametro.FieldName == "SafExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_saf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_saf LIKE :ordem_producao_pedido_Saf_4163 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Saf_4163", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CncExato" || parametro.FieldName == "CncExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_cnc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_cnc LIKE :ordem_producao_pedido_Cnc_8989 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Cnc_8989", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoLigacaoExato" || parametro.FieldName == "TipoLigacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_tipo_ligacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_tipo_ligacao LIKE :ordem_producao_pedido_TipoLigacao_9177 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_TipoLigacao_9177", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoCodigoPaiExato" || parametro.FieldName == "ProdutoCodigoPaiExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_codigo_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_codigo_pai LIKE :ordem_producao_pedido_ProdutoCodigoPai_7455 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoCodigoPai_7455", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClienteExato" || parametro.FieldName == "ClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_cliente LIKE :ordem_producao_pedido_Cliente_612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Cliente_612", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RevisaoDocumentoExato" || parametro.FieldName == "RevisaoDocumentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_revisao_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_revisao_documento LIKE :ordem_producao_pedido_RevisaoDocumento_2826 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_RevisaoDocumento_2826", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DimensaoExato" || parametro.FieldName == "DimensaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_dimensao LIKE :ordem_producao_pedido_Dimensao_8214 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_Dimensao_8214", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoAcabamentoPaiExato" || parametro.FieldName == "ProdutoAcabamentoPaiExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_acabamento_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_acabamento_pai LIKE :ordem_producao_pedido_ProdutoAcabamentoPai_4442 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoAcabamentoPai_4442", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoDescricaoPaiExato" || parametro.FieldName == "ProdutoDescricaoPaiExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_descricao_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.opp_produto_descricao_pai LIKE :ordem_producao_pedido_ProdutoDescricaoPai_54 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_ProdutoDescricaoPai_54", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao_pedido.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_pedido.entity_uid LIKE :ordem_producao_pedido_EntityUid_2307 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_pedido_EntityUid_2307", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoPedidoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoPedidoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoPedidoClass), Convert.ToInt32(read["id_ordem_producao_pedido"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoPedidoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_pedido"]);
                     if (read["id_ordem_producao"] != DBNull.Value)
                     {
                        entidade.OrdemProducao = (BibliotecaEntidades.Entidades.OrdemProducaoClass)BibliotecaEntidades.Entidades.OrdemProducaoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducao = null ;
                     }
                     entidade.ProdutoCodigo = (read["opp_produto_codigo"] != DBNull.Value ? read["opp_produto_codigo"].ToString() : null);
                     entidade.ProdutoDescricao = (read["opp_produto_descricao"] != DBNull.Value ? read["opp_produto_descricao"].ToString() : null);
                     entidade.OrderNumber = (read["opp_order_number"] != DBNull.Value ? read["opp_order_number"].ToString() : null);
                     entidade.OrderPos = read["opp_order_pos"] as int?;
                     entidade.Variavel1 = (read["opp_variavel_1"] != DBNull.Value ? read["opp_variavel_1"].ToString() : null);
                     entidade.ValorVariavel1 = (read["opp_valor_variavel_1"] != DBNull.Value ? read["opp_valor_variavel_1"].ToString() : null);
                     entidade.Variavel2 = (read["opp_variavel_2"] != DBNull.Value ? read["opp_variavel_2"].ToString() : null);
                     entidade.ValorVariavel2 = (read["opp_valor_variavel_2"] != DBNull.Value ? read["opp_valor_variavel_2"].ToString() : null);
                     entidade.Variavel3 = (read["opp_variavel_3"] != DBNull.Value ? read["opp_variavel_3"].ToString() : null);
                     entidade.ValorVariavel3 = (read["opp_valor_variavel_3"] != DBNull.Value ? read["opp_valor_variavel_3"].ToString() : null);
                     entidade.Variavel4 = (read["opp_variavel_4"] != DBNull.Value ? read["opp_variavel_4"].ToString() : null);
                     entidade.ValorVariavel4 = (read["opp_valor_variavel_4"] != DBNull.Value ? read["opp_valor_variavel_4"].ToString() : null);
                     entidade.Quantidade = read["opp_quantidade"] as double?;
                     entidade.TipoDocumento = (read["opp_tipo_documento"] != DBNull.Value ? read["opp_tipo_documento"].ToString() : null);
                     entidade.NumeroDocumento = (read["opp_numero_documento"] != DBNull.Value ? read["opp_numero_documento"].ToString() : null);
                     entidade.Saf = (read["opp_saf"] != DBNull.Value ? read["opp_saf"].ToString() : null);
                     entidade.Cnc = (read["opp_cnc"] != DBNull.Value ? read["opp_cnc"].ToString() : null);
                     entidade.TipoLigacao = (read["opp_tipo_ligacao"] != DBNull.Value ? read["opp_tipo_ligacao"].ToString() : null);
                     entidade.ProdutoCodigoPai = (read["opp_produto_codigo_pai"] != DBNull.Value ? read["opp_produto_codigo_pai"].ToString() : null);
                     entidade.Cliente = (read["opp_cliente"] != DBNull.Value ? read["opp_cliente"].ToString() : null);
                     entidade.SemanaEntrega = read["opp_semana_entrega"] as int?;
                     entidade.RevisaoDocumento = (read["opp_revisao_documento"] != DBNull.Value ? read["opp_revisao_documento"].ToString() : null);
                     entidade.Dimensao = (read["opp_dimensao"] != DBNull.Value ? read["opp_dimensao"].ToString() : null);
                     if (read["id_order_item_etiqueta"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiqueta = (BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiqueta = null ;
                     }
                     entidade.ProdutoAcabamentoPai = (read["opp_produto_acabamento_pai"] != DBNull.Value ? read["opp_produto_acabamento_pai"].ToString() : null);
                     entidade.ProdutoDescricaoPai = (read["opp_produto_descricao_pai"] != DBNull.Value ? read["opp_produto_descricao_pai"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoPedidoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
