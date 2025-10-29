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
     [Table("orcamento_item","ori")]
     public class OrcamentoItemBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrcamentoItemClass";
protected const string ErroDelete = "Erro ao excluir o OrcamentoItemClass  ";
protected const string ErroSave = "Erro ao salvar o OrcamentoItemClass.";
protected const string ErroCollectionOrcamentoConfiguradoClassOrcamentoItem = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
protected const string ErroCollectionOrcamentoItemClassOrcamentoItemPai = "Erro ao carregar a coleção de OrcamentoItemClass.";
protected const string ErroCollectionOrcamentoItemVariavelClassOrcamentoItem = "Erro ao carregar a coleção de OrcamentoItemVariavelClass.";
protected const string ErroCollectionOrcamentoKitClassOrcamentoItem = "Erro ao carregar a coleção de OrcamentoKitClass.";
protected const string ErroCollectionOrcamentoVariavelClassOrcamentoItem = "Erro ao carregar a coleção de OrcamentoVariavelClass.";
protected const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
protected const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 255 caracteres";
protected const string ErroProdutoCodigoClienteObrigatorio = "O campo ProdutoCodigoCliente é obrigatório";
protected const string ErroProdutoCodigoClienteComprimento = "O campo ProdutoCodigoCliente deve ter no máximo 255 caracteres";
protected const string ErroProdutoDescricaoClienteObrigatorio = "O campo ProdutoDescricaoCliente é obrigatório";
protected const string ErroProdutoDescricaoClienteComprimento = "O campo ProdutoDescricaoCliente deve ter no máximo 255 caracteres";
protected const string ErroCnpjClienteObrigatorio = "O campo CnpjCliente é obrigatório";
protected const string ErroCnpjClienteComprimento = "O campo CnpjCliente deve ter no máximo 100 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected const string ErroClienteObrigatorio = "O campo Cliente é obrigatório";
protected const string ErroOperacaoObrigatorio = "O campo Operacao é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrcamentoItemClass.";
protected const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassOrcamentoItem =  "A entidade OrcamentoItemClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemClassOrcamentoItemPai =  "A entidade OrcamentoItemClass está sendo utilizada nos seguintes OrcamentoItemClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemVariavelClassOrcamentoItem =  "A entidade OrcamentoItemClass está sendo utilizada nos seguintes OrcamentoItemVariavelClass:";
protected const string MensagemUtilizadoCollectionOrcamentoKitClassOrcamentoItem =  "A entidade OrcamentoItemClass está sendo utilizada nos seguintes OrcamentoKitClass:";
protected const string MensagemUtilizadoCollectionOrcamentoVariavelClassOrcamentoItem =  "A entidade OrcamentoItemClass está sendo utilizada nos seguintes OrcamentoVariavelClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoItemClass está sendo utilizada.";
#endregion
       protected string _numeroOriginal{get;private set;}
       private string _numeroOriginalCommited{get; set;}
        private string _valueNumero;
         [Column("ori_numero")]
        public virtual string Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected int _posicaoOriginal{get;private set;}
       private int _posicaoOriginalCommited{get; set;}
        private int _valuePosicao;
         [Column("ori_posicao")]
        public virtual int Posicao
         { 
            get { return this._valuePosicao; } 
            set 
            { 
                if (this._valuePosicao == value)return;
                 this._valuePosicao = value; 
            } 
        } 

       protected int _subLinhaOriginal{get;private set;}
       private int _subLinhaOriginalCommited{get; set;}
        private int _valueSubLinha;
         [Column("ori_sub_linha")]
        public virtual int SubLinha
         { 
            get { return this._valueSubLinha; } 
            set 
            { 
                if (this._valueSubLinha == value)return;
                 this._valueSubLinha = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _valueProduto;
        [Column("id_produto", "produto", "id_produto")]
       public virtual BibliotecaEntidades.Entidades.ProdutoClass Produto
        { 
           get {                 return this._valueProduto; } 
           set 
           { 
                if (this._valueProduto == value)return;
                 this._valueProduto = value; 
           } 
       } 

       protected string _produtoCodigoClienteOriginal{get;private set;}
       private string _produtoCodigoClienteOriginalCommited{get; set;}
        private string _valueProdutoCodigoCliente;
         [Column("ori_produto_codigo_cliente")]
        public virtual string ProdutoCodigoCliente
         { 
            get { return this._valueProdutoCodigoCliente; } 
            set 
            { 
                if (this._valueProdutoCodigoCliente == value)return;
                 this._valueProdutoCodigoCliente = value; 
            } 
        } 

       protected string _produtoDescricaoClienteOriginal{get;private set;}
       private string _produtoDescricaoClienteOriginalCommited{get; set;}
        private string _valueProdutoDescricaoCliente;
         [Column("ori_produto_descricao_cliente")]
        public virtual string ProdutoDescricaoCliente
         { 
            get { return this._valueProdutoDescricaoCliente; } 
            set 
            { 
                if (this._valueProdutoDescricaoCliente == value)return;
                 this._valueProdutoDescricaoCliente = value; 
            } 
        } 

       protected string _projetoClienteOriginal{get;private set;}
       private string _projetoClienteOriginalCommited{get; set;}
        private string _valueProjetoCliente;
         [Column("ori_projeto_cliente")]
        public virtual string ProjetoCliente
         { 
            get { return this._valueProjetoCliente; } 
            set 
            { 
                if (this._valueProjetoCliente == value)return;
                 this._valueProjetoCliente = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("ori_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected double _precoUnitarioOriginal{get;private set;}
       private double _precoUnitarioOriginalCommited{get; set;}
        private double _valuePrecoUnitario;
         [Column("ori_preco_unitario")]
        public virtual double PrecoUnitario
         { 
            get { return this._valuePrecoUnitario; } 
            set 
            { 
                if (this._valuePrecoUnitario == value)return;
                 this._valuePrecoUnitario = value; 
            } 
        } 

       protected double _precoTotalOriginal{get;private set;}
       private double _precoTotalOriginalCommited{get; set;}
        private double _valuePrecoTotal;
         [Column("ori_preco_total")]
        public virtual double PrecoTotal
         { 
            get { return this._valuePrecoTotal; } 
            set 
            { 
                if (this._valuePrecoTotal == value)return;
                 this._valuePrecoTotal = value; 
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

       protected string _cnpjClienteOriginal{get;private set;}
       private string _cnpjClienteOriginalCommited{get; set;}
        private string _valueCnpjCliente;
         [Column("ori_cnpj_cliente")]
        public virtual string CnpjCliente
         { 
            get { return this._valueCnpjCliente; } 
            set 
            { 
                if (this._valueCnpjCliente == value)return;
                 this._valueCnpjCliente = value; 
            } 
        } 

       protected string _armazenagemClienteOriginal{get;private set;}
       private string _armazenagemClienteOriginalCommited{get; set;}
        private string _valueArmazenagemCliente;
         [Column("ori_armazenagem_cliente")]
        public virtual string ArmazenagemCliente
         { 
            get { return this._valueArmazenagemCliente; } 
            set 
            { 
                if (this._valueArmazenagemCliente == value)return;
                 this._valueArmazenagemCliente = value; 
            } 
        } 

       protected double _freteOriginal{get;private set;}
       private double _freteOriginalCommited{get; set;}
        private double _valueFrete;
         [Column("ori_frete")]
        public virtual double Frete
         { 
            get { return this._valueFrete; } 
            set 
            { 
                if (this._valueFrete == value)return;
                 this._valueFrete = value; 
            } 
        } 

       protected DateTime _dataEntregaOriginal{get;private set;}
       private DateTime _dataEntregaOriginalCommited{get; set;}
        private DateTime _valueDataEntrega;
         [Column("ori_data_entrega")]
        public virtual DateTime DataEntrega
         { 
            get { return this._valueDataEntrega; } 
            set 
            { 
                if (this._valueDataEntrega == value)return;
                 this._valueDataEntrega = value; 
            } 
        } 

       protected StatusOrcamento _statusOriginal{get;private set;}
       private StatusOrcamento _statusOriginalCommited{get; set;}
        private StatusOrcamento _valueStatus;
         [Column("ori_status")]
        public virtual StatusOrcamento Status
         { 
            get { return this._valueStatus; } 
            set 
            { 
                if (this._valueStatus == value)return;
                 this._valueStatus = value; 
            } 
        } 

        public bool Status_Pendente
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusOrcamento.Pendente; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusOrcamento.Pendente; }
         } 

        public bool Status_Aprovado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusOrcamento.Aprovado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusOrcamento.Aprovado; }
         } 

        public bool Status_Cancelado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusOrcamento.Cancelado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusOrcamento.Cancelado; }
         } 

       protected DateTime _dataEntradaOriginal{get;private set;}
       private DateTime _dataEntradaOriginalCommited{get; set;}
        private DateTime _valueDataEntrada;
         [Column("ori_data_entrada")]
        public virtual DateTime DataEntrada
         { 
            get { return this._valueDataEntrada; } 
            set 
            { 
                if (this._valueDataEntrada == value)return;
                 this._valueDataEntrada = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OperacaoClass _operacaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _operacaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _valueOperacao;
        [Column("id_operacao", "operacao", "id_operacao")]
       public virtual BibliotecaEntidades.Entidades.OperacaoClass Operacao
        { 
           get {                 return this._valueOperacao; } 
           set 
           { 
                if (this._valueOperacao == value)return;
                 this._valueOperacao = value; 
           } 
       } 

       protected bool _permiteEntregaParcialOriginal{get;private set;}
       private bool _permiteEntregaParcialOriginalCommited{get; set;}
        private bool _valuePermiteEntregaParcial;
         [Column("ori_permite_entrega_parcial")]
        public virtual bool PermiteEntregaParcial
         { 
            get { return this._valuePermiteEntregaParcial; } 
            set 
            { 
                if (this._valuePermiteEntregaParcial == value)return;
                 this._valuePermiteEntregaParcial = value; 
            } 
        } 

       protected bool _volumeUnicoOriginal{get;private set;}
       private bool _volumeUnicoOriginalCommited{get; set;}
        private bool _valueVolumeUnico;
         [Column("ori_volume_unico")]
        public virtual bool VolumeUnico
         { 
            get { return this._valueVolumeUnico; } 
            set 
            { 
                if (this._valueVolumeUnico == value)return;
                 this._valueVolumeUnico = value; 
            } 
        } 

       protected bool _configuradoOriginal{get;private set;}
       private bool _configuradoOriginalCommited{get; set;}
        private bool _valueConfigurado;
         [Column("ori_configurado")]
        public virtual bool Configurado
         { 
            get { return this._valueConfigurado; } 
            set 
            { 
                if (this._valueConfigurado == value)return;
                 this._valueConfigurado = value; 
            } 
        } 

       protected bool _exportacaoOriginal{get;private set;}
       private bool _exportacaoOriginalCommited{get; set;}
        private bool _valueExportacao;
         [Column("ori_exportacao")]
        public virtual bool Exportacao
         { 
            get { return this._valueExportacao; } 
            set 
            { 
                if (this._valueExportacao == value)return;
                 this._valueExportacao = value; 
            } 
        } 

       protected double _precoTotalOriginalOriginal{get;private set;}
       private double _precoTotalOriginalOriginalCommited{get; set;}
        private double _valuePrecoTotalOriginal;
         [Column("ori_preco_total_original")]
        public virtual double PrecoTotalOriginal
         { 
            get { return this._valuePrecoTotalOriginal; } 
            set 
            { 
                if (this._valuePrecoTotalOriginal == value)return;
                 this._valuePrecoTotalOriginal = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCancelamentoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCancelamentoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioCancelamento;
        [Column("id_acs_usuario_cancelamento", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioCancelamento
        { 
           get {                 return this._valueAcsUsuarioCancelamento; } 
           set 
           { 
                if (this._valueAcsUsuarioCancelamento == value)return;
                 this._valueAcsUsuarioCancelamento = value; 
           } 
       } 

       protected DateTime? _dataCancelamentoOriginal{get;private set;}
       private DateTime? _dataCancelamentoOriginalCommited{get; set;}
        private DateTime? _valueDataCancelamento;
         [Column("ori_data_cancelamento")]
        public virtual DateTime? DataCancelamento
         { 
            get { return this._valueDataCancelamento; } 
            set 
            { 
                if (this._valueDataCancelamento == value)return;
                 this._valueDataCancelamento = value; 
            } 
        } 

       protected string _justificativaCancelamentoOriginal{get;private set;}
       private string _justificativaCancelamentoOriginalCommited{get; set;}
        private string _valueJustificativaCancelamento;
         [Column("ori_justificativa_cancelamento")]
        public virtual string JustificativaCancelamento
         { 
            get { return this._valueJustificativaCancelamento; } 
            set 
            { 
                if (this._valueJustificativaCancelamento == value)return;
                 this._valueJustificativaCancelamento = value; 
            } 
        } 

       protected DateTime? _dataConfiguracaoOriginal{get;private set;}
       private DateTime? _dataConfiguracaoOriginalCommited{get; set;}
        private DateTime? _valueDataConfiguracao;
         [Column("ori_data_configuracao")]
        public virtual DateTime? DataConfiguracao
         { 
            get { return this._valueDataConfiguracao; } 
            set 
            { 
                if (this._valueDataConfiguracao == value)return;
                 this._valueDataConfiguracao = value; 
            } 
        } 

       protected DateTime? _dataEntregaOriginalOriginal{get;private set;}
       private DateTime? _dataEntregaOriginalOriginalCommited{get; set;}
        private DateTime? _valueDataEntregaOriginal;
         [Column("ori_data_entrega_original")]
        public virtual DateTime? DataEntregaOriginal
         { 
            get { return this._valueDataEntregaOriginal; } 
            set 
            { 
                if (this._valueDataEntregaOriginal == value)return;
                 this._valueDataEntregaOriginal = value; 
            } 
        } 

       protected string _informacaoEspecialOriginal{get;private set;}
       private string _informacaoEspecialOriginalCommited{get; set;}
        private string _valueInformacaoEspecial;
         [Column("ori_informacao_especial")]
        public virtual string InformacaoEspecial
         { 
            get { return this._valueInformacaoEspecial; } 
            set 
            { 
                if (this._valueInformacaoEspecial == value)return;
                 this._valueInformacaoEspecial = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _valueContaBancaria;
        [Column("id_conta_bancaria", "conta_bancaria", "id_conta_bancaria")]
       public virtual BibliotecaEntidades.Entidades.ContaBancariaClass ContaBancaria
        { 
           get {                 return this._valueContaBancaria; } 
           set 
           { 
                if (this._valueContaBancaria == value)return;
                 this._valueContaBancaria = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _valueCentroCustoLucro;
        [Column("id_centro_custo_lucro", "centro_custo_lucro", "id_centro_custo_lucro")]
       public virtual BibliotecaEntidades.Entidades.CentroCustoLucroClass CentroCustoLucro
        { 
           get {                 return this._valueCentroCustoLucro; } 
           set 
           { 
                if (this._valueCentroCustoLucro == value)return;
                 this._valueCentroCustoLucro = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.FormaPagamentoClass _formaPagamentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FormaPagamentoClass _formaPagamentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FormaPagamentoClass _valueFormaPagamento;
        [Column("id_forma_pagamento", "forma_pagamento", "id_forma_pagamento")]
       public virtual BibliotecaEntidades.Entidades.FormaPagamentoClass FormaPagamento
        { 
           get {                 return this._valueFormaPagamento; } 
           set 
           { 
                if (this._valueFormaPagamento == value)return;
                 this._valueFormaPagamento = value; 
           } 
       } 

       protected bool _numeroPedidoAutomaticoOriginal{get;private set;}
       private bool _numeroPedidoAutomaticoOriginalCommited{get; set;}
        private bool _valueNumeroPedidoAutomatico;
         [Column("ori_numero_pedido_automatico")]
        public virtual bool NumeroPedidoAutomatico
         { 
            get { return this._valueNumeroPedidoAutomatico; } 
            set 
            { 
                if (this._valueNumeroPedidoAutomatico == value)return;
                 this._valueNumeroPedidoAutomatico = value; 
            } 
        } 

       protected string _ordemVendaOriginal{get;private set;}
       private string _ordemVendaOriginalCommited{get; set;}
        private string _valueOrdemVenda;
         [Column("ori_ordem_venda")]
        public virtual string OrdemVenda
         { 
            get { return this._valueOrdemVenda; } 
            set 
            { 
                if (this._valueOrdemVenda == value)return;
                 this._valueOrdemVenda = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.RepresentanteClass _representanteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.RepresentanteClass _representanteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.RepresentanteClass _valueRepresentante;
        [Column("id_representante", "representante", "id_representante")]
       public virtual BibliotecaEntidades.Entidades.RepresentanteClass Representante
        { 
           get {                 return this._valueRepresentante; } 
           set 
           { 
                if (this._valueRepresentante == value)return;
                 this._valueRepresentante = value; 
           } 
       } 

       protected double? _percComissaoRepresentanteOriginal{get;private set;}
       private double? _percComissaoRepresentanteOriginalCommited{get; set;}
        private double? _valuePercComissaoRepresentante;
         [Column("ori_perc_comissao_representante")]
        public virtual double? PercComissaoRepresentante
         { 
            get { return this._valuePercComissaoRepresentante; } 
            set 
            { 
                if (this._valuePercComissaoRepresentante == value)return;
                 this._valuePercComissaoRepresentante = value; 
            } 
        } 

       protected string _obsPadraoEspelhoOriginal{get;private set;}
       private string _obsPadraoEspelhoOriginalCommited{get; set;}
        private string _valueObsPadraoEspelho;
         [Column("ori_obs_padrao_espelho")]
        public virtual string ObsPadraoEspelho
         { 
            get { return this._valueObsPadraoEspelho; } 
            set 
            { 
                if (this._valueObsPadraoEspelho == value)return;
                 this._valueObsPadraoEspelho = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.VendedorClass _vendedorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.VendedorClass _vendedorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.VendedorClass _valueVendedor;
        [Column("id_vendedor", "vendedor", "id_vendedor")]
       public virtual BibliotecaEntidades.Entidades.VendedorClass Vendedor
        { 
           get {                 return this._valueVendedor; } 
           set 
           { 
                if (this._valueVendedor == value)return;
                 this._valueVendedor = value; 
           } 
       } 

       protected double? _percComissaoVendedorOriginal{get;private set;}
       private double? _percComissaoVendedorOriginalCommited{get; set;}
        private double? _valuePercComissaoVendedor;
         [Column("ori_perc_comissao_vendedor")]
        public virtual double? PercComissaoVendedor
         { 
            get { return this._valuePercComissaoVendedor; } 
            set 
            { 
                if (this._valuePercComissaoVendedor == value)return;
                 this._valuePercComissaoVendedor = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrcamentoItemClass _orcamentoItemPaiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrcamentoItemClass _orcamentoItemPaiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrcamentoItemClass _valueOrcamentoItemPai;
        [Column("id_orcamento_item_pai", "orcamento_item", "id_orcamento_item")]
       public virtual BibliotecaEntidades.Entidades.OrcamentoItemClass OrcamentoItemPai
        { 
           get {                 return this._valueOrcamentoItemPai; } 
           set 
           { 
                if (this._valueOrcamentoItemPai == value)return;
                 this._valueOrcamentoItemPai = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.NcmClass _ncmOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.NcmClass _ncmOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.NcmClass _valueNcm;
        [Column("id_ncm", "ncm", "id_ncm")]
       public virtual BibliotecaEntidades.Entidades.NcmClass Ncm
        { 
           get {                 return this._valueNcm; } 
           set 
           { 
                if (this._valueNcm == value)return;
                 this._valueNcm = value; 
           } 
       } 

       private List<long> _collectionOrcamentoConfiguradoClassOrcamentoItemOriginal;
       private List<Entidades.OrcamentoConfiguradoClass > _collectionOrcamentoConfiguradoClassOrcamentoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassOrcamentoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassOrcamentoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoConfiguradoClass> _valueCollectionOrcamentoConfiguradoClassOrcamentoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoConfiguradoClass> CollectionOrcamentoConfiguradoClassOrcamentoItem 
       { 
           get { if(!_valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoConfiguradoClassOrcamentoItem();}
return this._valueCollectionOrcamentoConfiguradoClassOrcamentoItem; } 
           set 
           { 
               this._valueCollectionOrcamentoConfiguradoClassOrcamentoItem = value; 
               this._valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemClassOrcamentoItemPaiOriginal;
       private List<Entidades.OrcamentoItemClass > _collectionOrcamentoItemClassOrcamentoItemPaiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassOrcamentoItemPaiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassOrcamentoItemPaiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemClass> _valueCollectionOrcamentoItemClassOrcamentoItemPai { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemClass> CollectionOrcamentoItemClassOrcamentoItemPai 
       { 
           get { if(!_valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemClassOrcamentoItemPai();}
return this._valueCollectionOrcamentoItemClassOrcamentoItemPai; } 
           set 
           { 
               this._valueCollectionOrcamentoItemClassOrcamentoItemPai = value; 
               this._valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemVariavelClassOrcamentoItemOriginal;
       private List<Entidades.OrcamentoItemVariavelClass > _collectionOrcamentoItemVariavelClassOrcamentoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemVariavelClassOrcamentoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemVariavelClassOrcamentoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemVariavelClass> _valueCollectionOrcamentoItemVariavelClassOrcamentoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemVariavelClass> CollectionOrcamentoItemVariavelClassOrcamentoItem 
       { 
           get { if(!_valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemVariavelClassOrcamentoItem();}
return this._valueCollectionOrcamentoItemVariavelClassOrcamentoItem; } 
           set 
           { 
               this._valueCollectionOrcamentoItemVariavelClassOrcamentoItem = value; 
               this._valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoKitClassOrcamentoItemOriginal;
       private List<Entidades.OrcamentoKitClass > _collectionOrcamentoKitClassOrcamentoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoKitClassOrcamentoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoKitClassOrcamentoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoKitClassOrcamentoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoKitClass> _valueCollectionOrcamentoKitClassOrcamentoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoKitClass> CollectionOrcamentoKitClassOrcamentoItem 
       { 
           get { if(!_valueCollectionOrcamentoKitClassOrcamentoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoKitClassOrcamentoItem();}
return this._valueCollectionOrcamentoKitClassOrcamentoItem; } 
           set 
           { 
               this._valueCollectionOrcamentoKitClassOrcamentoItem = value; 
               this._valueCollectionOrcamentoKitClassOrcamentoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoVariavelClassOrcamentoItemOriginal;
       private List<Entidades.OrcamentoVariavelClass > _collectionOrcamentoVariavelClassOrcamentoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoVariavelClassOrcamentoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoVariavelClassOrcamentoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoVariavelClass> _valueCollectionOrcamentoVariavelClassOrcamentoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoVariavelClass> CollectionOrcamentoVariavelClassOrcamentoItem 
       { 
           get { if(!_valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoVariavelClassOrcamentoItem();}
return this._valueCollectionOrcamentoVariavelClassOrcamentoItem; } 
           set 
           { 
               this._valueCollectionOrcamentoVariavelClassOrcamentoItem = value; 
               this._valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded = true; 
           } 
       } 

        public OrcamentoItemBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Quantidade = 0;
           this.Frete = 0;
           this.DataEntrada = Configurations.DataIndependenteClass.GetData();
           this.PermiteEntregaParcial = false;
           this.VolumeUnico = false;
           this.Configurado = false;
           this.Exportacao = false;
           this.NumeroPedidoAutomatico = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrcamentoItemClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrcamentoItemClass) GetEntity(typeof(OrcamentoItemClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrcamentoConfiguradoClassOrcamentoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoItemChanged = true;
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoItemChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoItemCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoConfiguradoClassOrcamentoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoItemChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoItemCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in _valueCollectionOrcamentoConfiguradoClassOrcamentoItem) 
                 { 
                     _collectionOrcamentoConfiguradoClassOrcamentoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoConfiguradoClassOrcamentoItem()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoConfiguradoClass> oc;
                _valueCollectionOrcamentoConfiguradoClassOrcamentoItemChanged = false;
                 _valueCollectionOrcamentoConfiguradoClassOrcamentoItemCommitedChanged = false;
                _collectionOrcamentoConfiguradoClassOrcamentoItemRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoConfiguradoClass>();
                }
                else{ 
                   Entidades.OrcamentoConfiguradoClass search = new Entidades.OrcamentoConfiguradoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoConfiguradoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrcamentoItem", this),                     }                       ).Cast<Entidades.OrcamentoConfiguradoClass>().ToList());
                 }
                 _valueCollectionOrcamentoConfiguradoClassOrcamentoItem = new BindingList<Entidades.OrcamentoConfiguradoClass>(oc); 
                 _collectionOrcamentoConfiguradoClassOrcamentoItemOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassOrcamentoItem select a.ID).ToList();
                 _valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoConfiguradoClassOrcamentoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoConfiguradoClassOrcamentoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemClassOrcamentoItemPaiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemClassOrcamentoItemPaiChanged = true;
                  _valueCollectionOrcamentoItemClassOrcamentoItemPaiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemClassOrcamentoItemPaiChanged = true; 
                  _valueCollectionOrcamentoItemClassOrcamentoItemPaiCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemClassOrcamentoItemPaiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemClassOrcamentoItemPaiChanged = true; 
                  _valueCollectionOrcamentoItemClassOrcamentoItemPaiCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in _valueCollectionOrcamentoItemClassOrcamentoItemPai) 
                 { 
                     _collectionOrcamentoItemClassOrcamentoItemPaiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemClassOrcamentoItemPai()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemClass> oc;
                _valueCollectionOrcamentoItemClassOrcamentoItemPaiChanged = false;
                 _valueCollectionOrcamentoItemClassOrcamentoItemPaiCommitedChanged = false;
                _collectionOrcamentoItemClassOrcamentoItemPaiRemovidos = new List<Entidades.OrcamentoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemClass>();
                }
                else{ 
                   Entidades.OrcamentoItemClass search = new Entidades.OrcamentoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrcamentoItemPai", this),                     }                       ).Cast<Entidades.OrcamentoItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemClassOrcamentoItemPai = new BindingList<Entidades.OrcamentoItemClass>(oc); 
                 _collectionOrcamentoItemClassOrcamentoItemPaiOriginal= (from a in _valueCollectionOrcamentoItemClassOrcamentoItemPai select a.ID).ToList();
                 _valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemClassOrcamentoItemPaiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemClassOrcamentoItemPai+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemVariavelClassOrcamentoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemVariavelClassOrcamentoItemChanged = true;
                  _valueCollectionOrcamentoItemVariavelClassOrcamentoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemVariavelClassOrcamentoItemChanged = true; 
                  _valueCollectionOrcamentoItemVariavelClassOrcamentoItemCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemVariavelClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemVariavelClassOrcamentoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemVariavelClassOrcamentoItemChanged = true; 
                  _valueCollectionOrcamentoItemVariavelClassOrcamentoItemCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemVariavelClass item in _valueCollectionOrcamentoItemVariavelClassOrcamentoItem) 
                 { 
                     _collectionOrcamentoItemVariavelClassOrcamentoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemVariavelClassOrcamentoItem()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemVariavelClass> oc;
                _valueCollectionOrcamentoItemVariavelClassOrcamentoItemChanged = false;
                 _valueCollectionOrcamentoItemVariavelClassOrcamentoItemCommitedChanged = false;
                _collectionOrcamentoItemVariavelClassOrcamentoItemRemovidos = new List<Entidades.OrcamentoItemVariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemVariavelClass>();
                }
                else{ 
                   Entidades.OrcamentoItemVariavelClass search = new Entidades.OrcamentoItemVariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemVariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrcamentoItem", this),                     }                       ).Cast<Entidades.OrcamentoItemVariavelClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemVariavelClassOrcamentoItem = new BindingList<Entidades.OrcamentoItemVariavelClass>(oc); 
                 _collectionOrcamentoItemVariavelClassOrcamentoItemOriginal= (from a in _valueCollectionOrcamentoItemVariavelClassOrcamentoItem select a.ID).ToList();
                 _valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemVariavelClassOrcamentoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemVariavelClassOrcamentoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoKitClassOrcamentoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoKitClassOrcamentoItemChanged = true;
                  _valueCollectionOrcamentoKitClassOrcamentoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoKitClassOrcamentoItemChanged = true; 
                  _valueCollectionOrcamentoKitClassOrcamentoItemCommitedChanged = true;
                 foreach (Entidades.OrcamentoKitClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoKitClassOrcamentoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoKitClassOrcamentoItemChanged = true; 
                  _valueCollectionOrcamentoKitClassOrcamentoItemCommitedChanged = true;
                 foreach (Entidades.OrcamentoKitClass item in _valueCollectionOrcamentoKitClassOrcamentoItem) 
                 { 
                     _collectionOrcamentoKitClassOrcamentoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoKitClassOrcamentoItem()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoKitClass> oc;
                _valueCollectionOrcamentoKitClassOrcamentoItemChanged = false;
                 _valueCollectionOrcamentoKitClassOrcamentoItemCommitedChanged = false;
                _collectionOrcamentoKitClassOrcamentoItemRemovidos = new List<Entidades.OrcamentoKitClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoKitClass>();
                }
                else{ 
                   Entidades.OrcamentoKitClass search = new Entidades.OrcamentoKitClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoKitClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrcamentoItem", this),                     }                       ).Cast<Entidades.OrcamentoKitClass>().ToList());
                 }
                 _valueCollectionOrcamentoKitClassOrcamentoItem = new BindingList<Entidades.OrcamentoKitClass>(oc); 
                 _collectionOrcamentoKitClassOrcamentoItemOriginal= (from a in _valueCollectionOrcamentoKitClassOrcamentoItem select a.ID).ToList();
                 _valueCollectionOrcamentoKitClassOrcamentoItemLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoKitClassOrcamentoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoKitClassOrcamentoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoVariavelClassOrcamentoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoVariavelClassOrcamentoItemChanged = true;
                  _valueCollectionOrcamentoVariavelClassOrcamentoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoVariavelClassOrcamentoItemChanged = true; 
                  _valueCollectionOrcamentoVariavelClassOrcamentoItemCommitedChanged = true;
                 foreach (Entidades.OrcamentoVariavelClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoVariavelClassOrcamentoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoVariavelClassOrcamentoItemChanged = true; 
                  _valueCollectionOrcamentoVariavelClassOrcamentoItemCommitedChanged = true;
                 foreach (Entidades.OrcamentoVariavelClass item in _valueCollectionOrcamentoVariavelClassOrcamentoItem) 
                 { 
                     _collectionOrcamentoVariavelClassOrcamentoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoVariavelClassOrcamentoItem()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoVariavelClass> oc;
                _valueCollectionOrcamentoVariavelClassOrcamentoItemChanged = false;
                 _valueCollectionOrcamentoVariavelClassOrcamentoItemCommitedChanged = false;
                _collectionOrcamentoVariavelClassOrcamentoItemRemovidos = new List<Entidades.OrcamentoVariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoVariavelClass>();
                }
                else{ 
                   Entidades.OrcamentoVariavelClass search = new Entidades.OrcamentoVariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoVariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrcamentoItem", this),                     }                       ).Cast<Entidades.OrcamentoVariavelClass>().ToList());
                 }
                 _valueCollectionOrcamentoVariavelClassOrcamentoItem = new BindingList<Entidades.OrcamentoVariavelClass>(oc); 
                 _collectionOrcamentoVariavelClassOrcamentoItemOriginal= (from a in _valueCollectionOrcamentoVariavelClassOrcamentoItem select a.ID).ToList();
                 _valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoVariavelClassOrcamentoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoVariavelClassOrcamentoItem+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Numero))
                {
                    throw new Exception(ErroNumeroObrigatorio);
                }
                if (Numero.Length >255)
                {
                    throw new Exception( ErroNumeroComprimento);
                }
                if (string.IsNullOrEmpty(ProdutoCodigoCliente))
                {
                    throw new Exception(ErroProdutoCodigoClienteObrigatorio);
                }
                if (ProdutoCodigoCliente.Length >255)
                {
                    throw new Exception( ErroProdutoCodigoClienteComprimento);
                }
                if (string.IsNullOrEmpty(ProdutoDescricaoCliente))
                {
                    throw new Exception(ErroProdutoDescricaoClienteObrigatorio);
                }
                if (ProdutoDescricaoCliente.Length >255)
                {
                    throw new Exception( ErroProdutoDescricaoClienteComprimento);
                }
                if (string.IsNullOrEmpty(CnpjCliente))
                {
                    throw new Exception(ErroCnpjClienteObrigatorio);
                }
                if (CnpjCliente.Length >100)
                {
                    throw new Exception( ErroCnpjClienteComprimento);
                }
                if ( _valueProduto == null)
                {
                    throw new Exception(ErroProdutoObrigatorio);
                }
                if ( _valueCliente == null)
                {
                    throw new Exception(ErroClienteObrigatorio);
                }
                if ( _valueOperacao == null)
                {
                    throw new Exception(ErroOperacaoObrigatorio);
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
                    "  public.orcamento_item  " +
                    "WHERE " +
                    "  id_orcamento_item = :id";
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
                        "  public.orcamento_item   " +
                        "SET  " + 
                        "  ori_numero = :ori_numero, " + 
                        "  ori_posicao = :ori_posicao, " + 
                        "  ori_sub_linha = :ori_sub_linha, " + 
                        "  id_produto = :id_produto, " + 
                        "  ori_produto_codigo_cliente = :ori_produto_codigo_cliente, " + 
                        "  ori_produto_descricao_cliente = :ori_produto_descricao_cliente, " + 
                        "  ori_projeto_cliente = :ori_projeto_cliente, " + 
                        "  ori_quantidade = :ori_quantidade, " + 
                        "  ori_preco_unitario = :ori_preco_unitario, " + 
                        "  ori_preco_total = :ori_preco_total, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  ori_cnpj_cliente = :ori_cnpj_cliente, " + 
                        "  ori_armazenagem_cliente = :ori_armazenagem_cliente, " + 
                        "  ori_frete = :ori_frete, " + 
                        "  ori_data_entrega = :ori_data_entrega, " + 
                        "  ori_status = :ori_status, " + 
                        "  ori_data_entrada = :ori_data_entrada, " + 
                        "  id_operacao = :id_operacao, " + 
                        "  ori_permite_entrega_parcial = :ori_permite_entrega_parcial, " + 
                        "  ori_volume_unico = :ori_volume_unico, " + 
                        "  ori_configurado = :ori_configurado, " + 
                        "  ori_exportacao = :ori_exportacao, " + 
                        "  ori_preco_total_original = :ori_preco_total_original, " + 
                        "  id_acs_usuario_cancelamento = :id_acs_usuario_cancelamento, " + 
                        "  ori_data_cancelamento = :ori_data_cancelamento, " + 
                        "  ori_justificativa_cancelamento = :ori_justificativa_cancelamento, " + 
                        "  ori_data_configuracao = :ori_data_configuracao, " + 
                        "  ori_data_entrega_original = :ori_data_entrega_original, " + 
                        "  ori_informacao_especial = :ori_informacao_especial, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  id_forma_pagamento = :id_forma_pagamento, " + 
                        "  ori_numero_pedido_automatico = :ori_numero_pedido_automatico, " + 
                        "  ori_ordem_venda = :ori_ordem_venda, " + 
                        "  id_representante = :id_representante, " + 
                        "  ori_perc_comissao_representante = :ori_perc_comissao_representante, " + 
                        "  ori_obs_padrao_espelho = :ori_obs_padrao_espelho, " + 
                        "  id_vendedor = :id_vendedor, " + 
                        "  ori_perc_comissao_vendedor = :ori_perc_comissao_vendedor, " + 
                        "  id_orcamento_item_pai = :id_orcamento_item_pai, " + 
                        "  id_ncm = :id_ncm "+
                        "WHERE  " +
                        "  id_orcamento_item = :id " +
                        "RETURNING id_orcamento_item;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.orcamento_item " +
                        "( " +
                        "  ori_numero , " + 
                        "  ori_posicao , " + 
                        "  ori_sub_linha , " + 
                        "  id_produto , " + 
                        "  ori_produto_codigo_cliente , " + 
                        "  ori_produto_descricao_cliente , " + 
                        "  ori_projeto_cliente , " + 
                        "  ori_quantidade , " + 
                        "  ori_preco_unitario , " + 
                        "  ori_preco_total , " + 
                        "  id_cliente , " + 
                        "  ori_cnpj_cliente , " + 
                        "  ori_armazenagem_cliente , " + 
                        "  ori_frete , " + 
                        "  ori_data_entrega , " + 
                        "  ori_status , " + 
                        "  ori_data_entrada , " + 
                        "  id_operacao , " + 
                        "  ori_permite_entrega_parcial , " + 
                        "  ori_volume_unico , " + 
                        "  ori_configurado , " + 
                        "  ori_exportacao , " + 
                        "  ori_preco_total_original , " + 
                        "  id_acs_usuario_cancelamento , " + 
                        "  ori_data_cancelamento , " + 
                        "  ori_justificativa_cancelamento , " + 
                        "  ori_data_configuracao , " + 
                        "  ori_data_entrega_original , " + 
                        "  ori_informacao_especial , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_conta_bancaria , " + 
                        "  id_centro_custo_lucro , " + 
                        "  id_forma_pagamento , " + 
                        "  ori_numero_pedido_automatico , " + 
                        "  ori_ordem_venda , " + 
                        "  id_representante , " + 
                        "  ori_perc_comissao_representante , " + 
                        "  ori_obs_padrao_espelho , " + 
                        "  id_vendedor , " + 
                        "  ori_perc_comissao_vendedor , " + 
                        "  id_orcamento_item_pai , " + 
                        "  id_ncm  "+
                        ")  " +
                        "VALUES ( " +
                        "  :ori_numero , " + 
                        "  :ori_posicao , " + 
                        "  :ori_sub_linha , " + 
                        "  :id_produto , " + 
                        "  :ori_produto_codigo_cliente , " + 
                        "  :ori_produto_descricao_cliente , " + 
                        "  :ori_projeto_cliente , " + 
                        "  :ori_quantidade , " + 
                        "  :ori_preco_unitario , " + 
                        "  :ori_preco_total , " + 
                        "  :id_cliente , " + 
                        "  :ori_cnpj_cliente , " + 
                        "  :ori_armazenagem_cliente , " + 
                        "  :ori_frete , " + 
                        "  :ori_data_entrega , " + 
                        "  :ori_status , " + 
                        "  :ori_data_entrada , " + 
                        "  :id_operacao , " + 
                        "  :ori_permite_entrega_parcial , " + 
                        "  :ori_volume_unico , " + 
                        "  :ori_configurado , " + 
                        "  :ori_exportacao , " + 
                        "  :ori_preco_total_original , " + 
                        "  :id_acs_usuario_cancelamento , " + 
                        "  :ori_data_cancelamento , " + 
                        "  :ori_justificativa_cancelamento , " + 
                        "  :ori_data_configuracao , " + 
                        "  :ori_data_entrega_original , " + 
                        "  :ori_informacao_especial , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_conta_bancaria , " + 
                        "  :id_centro_custo_lucro , " + 
                        "  :id_forma_pagamento , " + 
                        "  :ori_numero_pedido_automatico , " + 
                        "  :ori_ordem_venda , " + 
                        "  :id_representante , " + 
                        "  :ori_perc_comissao_representante , " + 
                        "  :ori_obs_padrao_espelho , " + 
                        "  :id_vendedor , " + 
                        "  :ori_perc_comissao_vendedor , " + 
                        "  :id_orcamento_item_pai , " + 
                        "  :id_ncm  "+
                        ")RETURNING id_orcamento_item;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_posicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Posicao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_sub_linha", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SubLinha ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_produto_codigo_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoCodigoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_produto_descricao_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoDescricaoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_projeto_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProjetoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_preco_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_preco_total", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_cnpj_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_armazenagem_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ArmazenagemCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_frete", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Frete ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_data_entrega", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrega ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Status);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_data_entrada", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Operacao==null ? (object) DBNull.Value : this.Operacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_permite_entrega_parcial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PermiteEntregaParcial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_volume_unico", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VolumeUnico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_configurado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Configurado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_exportacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Exportacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_preco_total_original", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoTotalOriginal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioCancelamento==null ? (object) DBNull.Value : this.AcsUsuarioCancelamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_justificativa_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JustificativaCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_data_configuracao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataConfiguracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_data_entrega_original", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntregaOriginal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_informacao_especial", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InformacaoEspecial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_forma_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FormaPagamento==null ? (object) DBNull.Value : this.FormaPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_numero_pedido_automatico", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroPedidoAutomatico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_ordem_venda", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrdemVenda ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_representante", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Representante==null ? (object) DBNull.Value : this.Representante.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_perc_comissao_representante", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercComissaoRepresentante ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_obs_padrao_espelho", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObsPadraoEspelho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_vendedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Vendedor==null ? (object) DBNull.Value : this.Vendedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ori_perc_comissao_vendedor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercComissaoVendedor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_item_pai", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrcamentoItemPai==null ? (object) DBNull.Value : this.OrcamentoItemPai.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ncm", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Ncm==null ? (object) DBNull.Value : this.Ncm.ID;

 
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
 if (CollectionOrcamentoConfiguradoClassOrcamentoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoConfiguradoClassOrcamentoItem+"\r\n";
                foreach (Entidades.OrcamentoConfiguradoClass tmp in CollectionOrcamentoConfiguradoClassOrcamentoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemClassOrcamentoItemPai.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassOrcamentoItemPai+"\r\n";
                foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassOrcamentoItemPai)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemVariavelClassOrcamentoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemVariavelClassOrcamentoItem+"\r\n";
                foreach (Entidades.OrcamentoItemVariavelClass tmp in CollectionOrcamentoItemVariavelClassOrcamentoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoKitClassOrcamentoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoKitClassOrcamentoItem+"\r\n";
                foreach (Entidades.OrcamentoKitClass tmp in CollectionOrcamentoKitClassOrcamentoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoVariavelClassOrcamentoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoVariavelClassOrcamentoItem+"\r\n";
                foreach (Entidades.OrcamentoVariavelClass tmp in CollectionOrcamentoVariavelClassOrcamentoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
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
        public static OrcamentoItemClass CopiarEntidade(OrcamentoItemClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrcamentoItemClass toRet = new OrcamentoItemClass(usuario,conn);
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Posicao= entidadeCopiar.Posicao;
 toRet.SubLinha= entidadeCopiar.SubLinha;
 toRet.Produto= entidadeCopiar.Produto;
 toRet.ProdutoCodigoCliente= entidadeCopiar.ProdutoCodigoCliente;
 toRet.ProdutoDescricaoCliente= entidadeCopiar.ProdutoDescricaoCliente;
 toRet.ProjetoCliente= entidadeCopiar.ProjetoCliente;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.PrecoUnitario= entidadeCopiar.PrecoUnitario;
 toRet.PrecoTotal= entidadeCopiar.PrecoTotal;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.CnpjCliente= entidadeCopiar.CnpjCliente;
 toRet.ArmazenagemCliente= entidadeCopiar.ArmazenagemCliente;
 toRet.Frete= entidadeCopiar.Frete;
 toRet.DataEntrega= entidadeCopiar.DataEntrega;
 toRet.Status= entidadeCopiar.Status;
 toRet.DataEntrada= entidadeCopiar.DataEntrada;
 toRet.Operacao= entidadeCopiar.Operacao;
 toRet.PermiteEntregaParcial= entidadeCopiar.PermiteEntregaParcial;
 toRet.VolumeUnico= entidadeCopiar.VolumeUnico;
 toRet.Configurado= entidadeCopiar.Configurado;
 toRet.Exportacao= entidadeCopiar.Exportacao;
 toRet.PrecoTotalOriginal= entidadeCopiar.PrecoTotalOriginal;
 toRet.AcsUsuarioCancelamento= entidadeCopiar.AcsUsuarioCancelamento;
 toRet.DataCancelamento= entidadeCopiar.DataCancelamento;
 toRet.JustificativaCancelamento= entidadeCopiar.JustificativaCancelamento;
 toRet.DataConfiguracao= entidadeCopiar.DataConfiguracao;
 toRet.DataEntregaOriginal= entidadeCopiar.DataEntregaOriginal;
 toRet.InformacaoEspecial= entidadeCopiar.InformacaoEspecial;
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;
 toRet.FormaPagamento= entidadeCopiar.FormaPagamento;
 toRet.NumeroPedidoAutomatico= entidadeCopiar.NumeroPedidoAutomatico;
 toRet.OrdemVenda= entidadeCopiar.OrdemVenda;
 toRet.Representante= entidadeCopiar.Representante;
 toRet.PercComissaoRepresentante= entidadeCopiar.PercComissaoRepresentante;
 toRet.ObsPadraoEspelho= entidadeCopiar.ObsPadraoEspelho;
 toRet.Vendedor= entidadeCopiar.Vendedor;
 toRet.PercComissaoVendedor= entidadeCopiar.PercComissaoVendedor;
 toRet.OrcamentoItemPai= entidadeCopiar.OrcamentoItemPai;
 toRet.Ncm= entidadeCopiar.Ncm;

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
       _posicaoOriginal = Posicao;
       _posicaoOriginalCommited = _posicaoOriginal;
       _subLinhaOriginal = SubLinha;
       _subLinhaOriginalCommited = _subLinhaOriginal;
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _produtoCodigoClienteOriginal = ProdutoCodigoCliente;
       _produtoCodigoClienteOriginalCommited = _produtoCodigoClienteOriginal;
       _produtoDescricaoClienteOriginal = ProdutoDescricaoCliente;
       _produtoDescricaoClienteOriginalCommited = _produtoDescricaoClienteOriginal;
       _projetoClienteOriginal = ProjetoCliente;
       _projetoClienteOriginalCommited = _projetoClienteOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _precoUnitarioOriginal = PrecoUnitario;
       _precoUnitarioOriginalCommited = _precoUnitarioOriginal;
       _precoTotalOriginal = PrecoTotal;
       _precoTotalOriginalCommited = _precoTotalOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _cnpjClienteOriginal = CnpjCliente;
       _cnpjClienteOriginalCommited = _cnpjClienteOriginal;
       _armazenagemClienteOriginal = ArmazenagemCliente;
       _armazenagemClienteOriginalCommited = _armazenagemClienteOriginal;
       _freteOriginal = Frete;
       _freteOriginalCommited = _freteOriginal;
       _dataEntregaOriginal = DataEntrega;
       _dataEntregaOriginalCommited = _dataEntregaOriginal;
       _statusOriginal = Status;
       _statusOriginalCommited = _statusOriginal;
       _dataEntradaOriginal = DataEntrada;
       _dataEntradaOriginalCommited = _dataEntradaOriginal;
       _operacaoOriginal = Operacao;
       _operacaoOriginalCommited = _operacaoOriginal;
       _permiteEntregaParcialOriginal = PermiteEntregaParcial;
       _permiteEntregaParcialOriginalCommited = _permiteEntregaParcialOriginal;
       _volumeUnicoOriginal = VolumeUnico;
       _volumeUnicoOriginalCommited = _volumeUnicoOriginal;
       _configuradoOriginal = Configurado;
       _configuradoOriginalCommited = _configuradoOriginal;
       _exportacaoOriginal = Exportacao;
       _exportacaoOriginalCommited = _exportacaoOriginal;
       _precoTotalOriginalOriginal = PrecoTotalOriginal;
       _precoTotalOriginalOriginalCommited = _precoTotalOriginalOriginal;
       _acsUsuarioCancelamentoOriginal = AcsUsuarioCancelamento;
       _acsUsuarioCancelamentoOriginalCommited = _acsUsuarioCancelamentoOriginal;
       _dataCancelamentoOriginal = DataCancelamento;
       _dataCancelamentoOriginalCommited = _dataCancelamentoOriginal;
       _justificativaCancelamentoOriginal = JustificativaCancelamento;
       _justificativaCancelamentoOriginalCommited = _justificativaCancelamentoOriginal;
       _dataConfiguracaoOriginal = DataConfiguracao;
       _dataConfiguracaoOriginalCommited = _dataConfiguracaoOriginal;
       _dataEntregaOriginalOriginal = DataEntregaOriginal;
       _dataEntregaOriginalOriginalCommited = _dataEntregaOriginalOriginal;
       _informacaoEspecialOriginal = InformacaoEspecial;
       _informacaoEspecialOriginalCommited = _informacaoEspecialOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;
       _formaPagamentoOriginal = FormaPagamento;
       _formaPagamentoOriginalCommited = _formaPagamentoOriginal;
       _numeroPedidoAutomaticoOriginal = NumeroPedidoAutomatico;
       _numeroPedidoAutomaticoOriginalCommited = _numeroPedidoAutomaticoOriginal;
       _ordemVendaOriginal = OrdemVenda;
       _ordemVendaOriginalCommited = _ordemVendaOriginal;
       _representanteOriginal = Representante;
       _representanteOriginalCommited = _representanteOriginal;
       _percComissaoRepresentanteOriginal = PercComissaoRepresentante;
       _percComissaoRepresentanteOriginalCommited = _percComissaoRepresentanteOriginal;
       _obsPadraoEspelhoOriginal = ObsPadraoEspelho;
       _obsPadraoEspelhoOriginalCommited = _obsPadraoEspelhoOriginal;
       _vendedorOriginal = Vendedor;
       _vendedorOriginalCommited = _vendedorOriginal;
       _percComissaoVendedorOriginal = PercComissaoVendedor;
       _percComissaoVendedorOriginalCommited = _percComissaoVendedorOriginal;
       _orcamentoItemPaiOriginal = OrcamentoItemPai;
       _orcamentoItemPaiOriginalCommited = _orcamentoItemPaiOriginal;
       _ncmOriginal = Ncm;
       _ncmOriginalCommited = _ncmOriginal;

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
       _posicaoOriginalCommited = Posicao;
       _subLinhaOriginalCommited = SubLinha;
       _produtoOriginalCommited = Produto;
       _produtoCodigoClienteOriginalCommited = ProdutoCodigoCliente;
       _produtoDescricaoClienteOriginalCommited = ProdutoDescricaoCliente;
       _projetoClienteOriginalCommited = ProjetoCliente;
       _quantidadeOriginalCommited = Quantidade;
       _precoUnitarioOriginalCommited = PrecoUnitario;
       _precoTotalOriginalCommited = PrecoTotal;
       _clienteOriginalCommited = Cliente;
       _cnpjClienteOriginalCommited = CnpjCliente;
       _armazenagemClienteOriginalCommited = ArmazenagemCliente;
       _freteOriginalCommited = Frete;
       _dataEntregaOriginalCommited = DataEntrega;
       _statusOriginalCommited = Status;
       _dataEntradaOriginalCommited = DataEntrada;
       _operacaoOriginalCommited = Operacao;
       _permiteEntregaParcialOriginalCommited = PermiteEntregaParcial;
       _volumeUnicoOriginalCommited = VolumeUnico;
       _configuradoOriginalCommited = Configurado;
       _exportacaoOriginalCommited = Exportacao;
       _precoTotalOriginalOriginalCommited = PrecoTotalOriginal;
       _acsUsuarioCancelamentoOriginalCommited = AcsUsuarioCancelamento;
       _dataCancelamentoOriginalCommited = DataCancelamento;
       _justificativaCancelamentoOriginalCommited = JustificativaCancelamento;
       _dataConfiguracaoOriginalCommited = DataConfiguracao;
       _dataEntregaOriginalOriginalCommited = DataEntregaOriginal;
       _informacaoEspecialOriginalCommited = InformacaoEspecial;
       _versionOriginalCommited = Version;
       _contaBancariaOriginalCommited = ContaBancaria;
       _centroCustoLucroOriginalCommited = CentroCustoLucro;
       _formaPagamentoOriginalCommited = FormaPagamento;
       _numeroPedidoAutomaticoOriginalCommited = NumeroPedidoAutomatico;
       _ordemVendaOriginalCommited = OrdemVenda;
       _representanteOriginalCommited = Representante;
       _percComissaoRepresentanteOriginalCommited = PercComissaoRepresentante;
       _obsPadraoEspelhoOriginalCommited = ObsPadraoEspelho;
       _vendedorOriginalCommited = Vendedor;
       _percComissaoVendedorOriginalCommited = PercComissaoVendedor;
       _orcamentoItemPaiOriginalCommited = OrcamentoItemPai;
       _ncmOriginalCommited = Ncm;

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
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded) 
               {
                  if (_collectionOrcamentoConfiguradoClassOrcamentoItemRemovidos != null) 
                  {
                     _collectionOrcamentoConfiguradoClassOrcamentoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoConfiguradoClassOrcamentoItemRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                  }
                  _collectionOrcamentoConfiguradoClassOrcamentoItemOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassOrcamentoItem select a.ID).ToList();
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoItemChanged = false;
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoItemCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded) 
               {
                  if (_collectionOrcamentoItemClassOrcamentoItemPaiRemovidos != null) 
                  {
                     _collectionOrcamentoItemClassOrcamentoItemPaiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemClassOrcamentoItemPaiRemovidos = new List<Entidades.OrcamentoItemClass>();
                  }
                  _collectionOrcamentoItemClassOrcamentoItemPaiOriginal= (from a in _valueCollectionOrcamentoItemClassOrcamentoItemPai select a.ID).ToList();
                  _valueCollectionOrcamentoItemClassOrcamentoItemPaiChanged = false;
                  _valueCollectionOrcamentoItemClassOrcamentoItemPaiCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded) 
               {
                  if (_collectionOrcamentoItemVariavelClassOrcamentoItemRemovidos != null) 
                  {
                     _collectionOrcamentoItemVariavelClassOrcamentoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemVariavelClassOrcamentoItemRemovidos = new List<Entidades.OrcamentoItemVariavelClass>();
                  }
                  _collectionOrcamentoItemVariavelClassOrcamentoItemOriginal= (from a in _valueCollectionOrcamentoItemVariavelClassOrcamentoItem select a.ID).ToList();
                  _valueCollectionOrcamentoItemVariavelClassOrcamentoItemChanged = false;
                  _valueCollectionOrcamentoItemVariavelClassOrcamentoItemCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoKitClassOrcamentoItemLoaded) 
               {
                  if (_collectionOrcamentoKitClassOrcamentoItemRemovidos != null) 
                  {
                     _collectionOrcamentoKitClassOrcamentoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoKitClassOrcamentoItemRemovidos = new List<Entidades.OrcamentoKitClass>();
                  }
                  _collectionOrcamentoKitClassOrcamentoItemOriginal= (from a in _valueCollectionOrcamentoKitClassOrcamentoItem select a.ID).ToList();
                  _valueCollectionOrcamentoKitClassOrcamentoItemChanged = false;
                  _valueCollectionOrcamentoKitClassOrcamentoItemCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded) 
               {
                  if (_collectionOrcamentoVariavelClassOrcamentoItemRemovidos != null) 
                  {
                     _collectionOrcamentoVariavelClassOrcamentoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoVariavelClassOrcamentoItemRemovidos = new List<Entidades.OrcamentoVariavelClass>();
                  }
                  _collectionOrcamentoVariavelClassOrcamentoItemOriginal= (from a in _valueCollectionOrcamentoVariavelClassOrcamentoItem select a.ID).ToList();
                  _valueCollectionOrcamentoVariavelClassOrcamentoItemChanged = false;
                  _valueCollectionOrcamentoVariavelClassOrcamentoItemCommitedChanged = false;
               }

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
               Posicao=_posicaoOriginal;
               _posicaoOriginalCommited=_posicaoOriginal;
               SubLinha=_subLinhaOriginal;
               _subLinhaOriginalCommited=_subLinhaOriginal;
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               ProdutoCodigoCliente=_produtoCodigoClienteOriginal;
               _produtoCodigoClienteOriginalCommited=_produtoCodigoClienteOriginal;
               ProdutoDescricaoCliente=_produtoDescricaoClienteOriginal;
               _produtoDescricaoClienteOriginalCommited=_produtoDescricaoClienteOriginal;
               ProjetoCliente=_projetoClienteOriginal;
               _projetoClienteOriginalCommited=_projetoClienteOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               PrecoUnitario=_precoUnitarioOriginal;
               _precoUnitarioOriginalCommited=_precoUnitarioOriginal;
               PrecoTotal=_precoTotalOriginal;
               _precoTotalOriginalCommited=_precoTotalOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               CnpjCliente=_cnpjClienteOriginal;
               _cnpjClienteOriginalCommited=_cnpjClienteOriginal;
               ArmazenagemCliente=_armazenagemClienteOriginal;
               _armazenagemClienteOriginalCommited=_armazenagemClienteOriginal;
               Frete=_freteOriginal;
               _freteOriginalCommited=_freteOriginal;
               DataEntrega=_dataEntregaOriginal;
               _dataEntregaOriginalCommited=_dataEntregaOriginal;
               Status=_statusOriginal;
               _statusOriginalCommited=_statusOriginal;
               DataEntrada=_dataEntradaOriginal;
               _dataEntradaOriginalCommited=_dataEntradaOriginal;
               Operacao=_operacaoOriginal;
               _operacaoOriginalCommited=_operacaoOriginal;
               PermiteEntregaParcial=_permiteEntregaParcialOriginal;
               _permiteEntregaParcialOriginalCommited=_permiteEntregaParcialOriginal;
               VolumeUnico=_volumeUnicoOriginal;
               _volumeUnicoOriginalCommited=_volumeUnicoOriginal;
               Configurado=_configuradoOriginal;
               _configuradoOriginalCommited=_configuradoOriginal;
               Exportacao=_exportacaoOriginal;
               _exportacaoOriginalCommited=_exportacaoOriginal;
               PrecoTotalOriginal=_precoTotalOriginalOriginal;
               _precoTotalOriginalOriginalCommited=_precoTotalOriginalOriginal;
               AcsUsuarioCancelamento=_acsUsuarioCancelamentoOriginal;
               _acsUsuarioCancelamentoOriginalCommited=_acsUsuarioCancelamentoOriginal;
               DataCancelamento=_dataCancelamentoOriginal;
               _dataCancelamentoOriginalCommited=_dataCancelamentoOriginal;
               JustificativaCancelamento=_justificativaCancelamentoOriginal;
               _justificativaCancelamentoOriginalCommited=_justificativaCancelamentoOriginal;
               DataConfiguracao=_dataConfiguracaoOriginal;
               _dataConfiguracaoOriginalCommited=_dataConfiguracaoOriginal;
               DataEntregaOriginal=_dataEntregaOriginalOriginal;
               _dataEntregaOriginalOriginalCommited=_dataEntregaOriginalOriginal;
               InformacaoEspecial=_informacaoEspecialOriginal;
               _informacaoEspecialOriginalCommited=_informacaoEspecialOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;
               FormaPagamento=_formaPagamentoOriginal;
               _formaPagamentoOriginalCommited=_formaPagamentoOriginal;
               NumeroPedidoAutomatico=_numeroPedidoAutomaticoOriginal;
               _numeroPedidoAutomaticoOriginalCommited=_numeroPedidoAutomaticoOriginal;
               OrdemVenda=_ordemVendaOriginal;
               _ordemVendaOriginalCommited=_ordemVendaOriginal;
               Representante=_representanteOriginal;
               _representanteOriginalCommited=_representanteOriginal;
               PercComissaoRepresentante=_percComissaoRepresentanteOriginal;
               _percComissaoRepresentanteOriginalCommited=_percComissaoRepresentanteOriginal;
               ObsPadraoEspelho=_obsPadraoEspelhoOriginal;
               _obsPadraoEspelhoOriginalCommited=_obsPadraoEspelhoOriginal;
               Vendedor=_vendedorOriginal;
               _vendedorOriginalCommited=_vendedorOriginal;
               PercComissaoVendedor=_percComissaoVendedorOriginal;
               _percComissaoVendedorOriginalCommited=_percComissaoVendedorOriginal;
               OrcamentoItemPai=_orcamentoItemPaiOriginal;
               _orcamentoItemPaiOriginalCommited=_orcamentoItemPaiOriginal;
               Ncm=_ncmOriginal;
               _ncmOriginalCommited=_ncmOriginal;
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded) 
               {
                  CollectionOrcamentoConfiguradoClassOrcamentoItem.Clear();
                  foreach(int item in _collectionOrcamentoConfiguradoClassOrcamentoItemOriginal)
                  {
                    CollectionOrcamentoConfiguradoClassOrcamentoItem.Add(Entidades.OrcamentoConfiguradoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoConfiguradoClassOrcamentoItemRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded) 
               {
                  CollectionOrcamentoItemClassOrcamentoItemPai.Clear();
                  foreach(int item in _collectionOrcamentoItemClassOrcamentoItemPaiOriginal)
                  {
                    CollectionOrcamentoItemClassOrcamentoItemPai.Add(Entidades.OrcamentoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemClassOrcamentoItemPaiRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded) 
               {
                  CollectionOrcamentoItemVariavelClassOrcamentoItem.Clear();
                  foreach(int item in _collectionOrcamentoItemVariavelClassOrcamentoItemOriginal)
                  {
                    CollectionOrcamentoItemVariavelClassOrcamentoItem.Add(Entidades.OrcamentoItemVariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemVariavelClassOrcamentoItemRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoKitClassOrcamentoItemLoaded) 
               {
                  CollectionOrcamentoKitClassOrcamentoItem.Clear();
                  foreach(int item in _collectionOrcamentoKitClassOrcamentoItemOriginal)
                  {
                    CollectionOrcamentoKitClassOrcamentoItem.Add(Entidades.OrcamentoKitClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoKitClassOrcamentoItemRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded) 
               {
                  CollectionOrcamentoVariavelClassOrcamentoItem.Clear();
                  foreach(int item in _collectionOrcamentoVariavelClassOrcamentoItemOriginal)
                  {
                    CollectionOrcamentoVariavelClassOrcamentoItem.Add(Entidades.OrcamentoVariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoVariavelClassOrcamentoItemRemovidos.Clear();
               }

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
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded) 
               {
                  if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoKitClassOrcamentoItemLoaded) 
               {
                  if (_valueCollectionOrcamentoKitClassOrcamentoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded) 
               {
                  if (_valueCollectionOrcamentoVariavelClassOrcamentoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassOrcamentoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassOrcamentoItemPai.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded) 
               {
                   tempRet = CollectionOrcamentoItemVariavelClassOrcamentoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoKitClassOrcamentoItemLoaded) 
               {
                   tempRet = CollectionOrcamentoKitClassOrcamentoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded) 
               {
                   tempRet = CollectionOrcamentoVariavelClassOrcamentoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
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
       dirty = _posicaoOriginal != Posicao;
      if (dirty) return true;
       dirty = _subLinhaOriginal != SubLinha;
      if (dirty) return true;
       if (_produtoOriginal!=null)
       {
          dirty = !_produtoOriginal.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       dirty = _produtoCodigoClienteOriginal != ProdutoCodigoCliente;
      if (dirty) return true;
       dirty = _produtoDescricaoClienteOriginal != ProdutoDescricaoCliente;
      if (dirty) return true;
       dirty = _projetoClienteOriginal != ProjetoCliente;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _precoUnitarioOriginal != PrecoUnitario;
      if (dirty) return true;
       dirty = _precoTotalOriginal != PrecoTotal;
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
       dirty = _cnpjClienteOriginal != CnpjCliente;
      if (dirty) return true;
       dirty = _armazenagemClienteOriginal != ArmazenagemCliente;
      if (dirty) return true;
       dirty = _freteOriginal != Frete;
      if (dirty) return true;
       dirty = _dataEntregaOriginal != DataEntrega;
      if (dirty) return true;
       dirty = _statusOriginal != Status;
      if (dirty) return true;
       dirty = _dataEntradaOriginal != DataEntrada;
      if (dirty) return true;
       if (_operacaoOriginal!=null)
       {
          dirty = !_operacaoOriginal.Equals(Operacao);
       }
       else
       {
            dirty = Operacao != null;
       }
      if (dirty) return true;
       dirty = _permiteEntregaParcialOriginal != PermiteEntregaParcial;
      if (dirty) return true;
       dirty = _volumeUnicoOriginal != VolumeUnico;
      if (dirty) return true;
       dirty = _configuradoOriginal != Configurado;
      if (dirty) return true;
       dirty = _exportacaoOriginal != Exportacao;
      if (dirty) return true;
       dirty = _precoTotalOriginalOriginal != PrecoTotalOriginal;
      if (dirty) return true;
       if (_acsUsuarioCancelamentoOriginal!=null)
       {
          dirty = !_acsUsuarioCancelamentoOriginal.Equals(AcsUsuarioCancelamento);
       }
       else
       {
            dirty = AcsUsuarioCancelamento != null;
       }
      if (dirty) return true;
       dirty = _dataCancelamentoOriginal != DataCancelamento;
      if (dirty) return true;
       dirty = _justificativaCancelamentoOriginal != JustificativaCancelamento;
      if (dirty) return true;
       dirty = _dataConfiguracaoOriginal != DataConfiguracao;
      if (dirty) return true;
       dirty = _dataEntregaOriginalOriginal != DataEntregaOriginal;
      if (dirty) return true;
       dirty = _informacaoEspecialOriginal != InformacaoEspecial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_contaBancariaOriginal!=null)
       {
          dirty = !_contaBancariaOriginal.Equals(ContaBancaria);
       }
       else
       {
            dirty = ContaBancaria != null;
       }
      if (dirty) return true;
       if (_centroCustoLucroOriginal!=null)
       {
          dirty = !_centroCustoLucroOriginal.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
      if (dirty) return true;
       if (_formaPagamentoOriginal!=null)
       {
          dirty = !_formaPagamentoOriginal.Equals(FormaPagamento);
       }
       else
       {
            dirty = FormaPagamento != null;
       }
      if (dirty) return true;
       dirty = _numeroPedidoAutomaticoOriginal != NumeroPedidoAutomatico;
      if (dirty) return true;
       dirty = _ordemVendaOriginal != OrdemVenda;
      if (dirty) return true;
       if (_representanteOriginal!=null)
       {
          dirty = !_representanteOriginal.Equals(Representante);
       }
       else
       {
            dirty = Representante != null;
       }
      if (dirty) return true;
       dirty = _percComissaoRepresentanteOriginal != PercComissaoRepresentante;
      if (dirty) return true;
       dirty = _obsPadraoEspelhoOriginal != ObsPadraoEspelho;
      if (dirty) return true;
       if (_vendedorOriginal!=null)
       {
          dirty = !_vendedorOriginal.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       dirty = _percComissaoVendedorOriginal != PercComissaoVendedor;
      if (dirty) return true;
       if (_orcamentoItemPaiOriginal!=null)
       {
          dirty = !_orcamentoItemPaiOriginal.Equals(OrcamentoItemPai);
       }
       else
       {
            dirty = OrcamentoItemPai != null;
       }
      if (dirty) return true;
       if (_ncmOriginal!=null)
       {
          dirty = !_ncmOriginal.Equals(Ncm);
       }
       else
       {
            dirty = Ncm != null;
       }

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
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded) 
               {
                  if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoKitClassOrcamentoItemLoaded) 
               {
                  if (_valueCollectionOrcamentoKitClassOrcamentoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded) 
               {
                  if (_valueCollectionOrcamentoVariavelClassOrcamentoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassOrcamentoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassOrcamentoItemPai.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded) 
               {
                   tempRet = CollectionOrcamentoItemVariavelClassOrcamentoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoKitClassOrcamentoItemLoaded) 
               {
                   tempRet = CollectionOrcamentoKitClassOrcamentoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded) 
               {
                   tempRet = CollectionOrcamentoVariavelClassOrcamentoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
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
       dirty = _posicaoOriginalCommited != Posicao;
      if (dirty) return true;
       dirty = _subLinhaOriginalCommited != SubLinha;
      if (dirty) return true;
       if (_produtoOriginalCommited!=null)
       {
          dirty = !_produtoOriginalCommited.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       dirty = _produtoCodigoClienteOriginalCommited != ProdutoCodigoCliente;
      if (dirty) return true;
       dirty = _produtoDescricaoClienteOriginalCommited != ProdutoDescricaoCliente;
      if (dirty) return true;
       dirty = _projetoClienteOriginalCommited != ProjetoCliente;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _precoUnitarioOriginalCommited != PrecoUnitario;
      if (dirty) return true;
       dirty = _precoTotalOriginalCommited != PrecoTotal;
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
       dirty = _cnpjClienteOriginalCommited != CnpjCliente;
      if (dirty) return true;
       dirty = _armazenagemClienteOriginalCommited != ArmazenagemCliente;
      if (dirty) return true;
       dirty = _freteOriginalCommited != Frete;
      if (dirty) return true;
       dirty = _dataEntregaOriginalCommited != DataEntrega;
      if (dirty) return true;
       dirty = _statusOriginalCommited != Status;
      if (dirty) return true;
       dirty = _dataEntradaOriginalCommited != DataEntrada;
      if (dirty) return true;
       if (_operacaoOriginalCommited!=null)
       {
          dirty = !_operacaoOriginalCommited.Equals(Operacao);
       }
       else
       {
            dirty = Operacao != null;
       }
      if (dirty) return true;
       dirty = _permiteEntregaParcialOriginalCommited != PermiteEntregaParcial;
      if (dirty) return true;
       dirty = _volumeUnicoOriginalCommited != VolumeUnico;
      if (dirty) return true;
       dirty = _configuradoOriginalCommited != Configurado;
      if (dirty) return true;
       dirty = _exportacaoOriginalCommited != Exportacao;
      if (dirty) return true;
       dirty = _precoTotalOriginalOriginalCommited != PrecoTotalOriginal;
      if (dirty) return true;
       if (_acsUsuarioCancelamentoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioCancelamentoOriginalCommited.Equals(AcsUsuarioCancelamento);
       }
       else
       {
            dirty = AcsUsuarioCancelamento != null;
       }
      if (dirty) return true;
       dirty = _dataCancelamentoOriginalCommited != DataCancelamento;
      if (dirty) return true;
       dirty = _justificativaCancelamentoOriginalCommited != JustificativaCancelamento;
      if (dirty) return true;
       dirty = _dataConfiguracaoOriginalCommited != DataConfiguracao;
      if (dirty) return true;
       dirty = _dataEntregaOriginalOriginalCommited != DataEntregaOriginal;
      if (dirty) return true;
       dirty = _informacaoEspecialOriginalCommited != InformacaoEspecial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_contaBancariaOriginalCommited!=null)
       {
          dirty = !_contaBancariaOriginalCommited.Equals(ContaBancaria);
       }
       else
       {
            dirty = ContaBancaria != null;
       }
      if (dirty) return true;
       if (_centroCustoLucroOriginalCommited!=null)
       {
          dirty = !_centroCustoLucroOriginalCommited.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
      if (dirty) return true;
       if (_formaPagamentoOriginalCommited!=null)
       {
          dirty = !_formaPagamentoOriginalCommited.Equals(FormaPagamento);
       }
       else
       {
            dirty = FormaPagamento != null;
       }
      if (dirty) return true;
       dirty = _numeroPedidoAutomaticoOriginalCommited != NumeroPedidoAutomatico;
      if (dirty) return true;
       dirty = _ordemVendaOriginalCommited != OrdemVenda;
      if (dirty) return true;
       if (_representanteOriginalCommited!=null)
       {
          dirty = !_representanteOriginalCommited.Equals(Representante);
       }
       else
       {
            dirty = Representante != null;
       }
      if (dirty) return true;
       dirty = _percComissaoRepresentanteOriginalCommited != PercComissaoRepresentante;
      if (dirty) return true;
       dirty = _obsPadraoEspelhoOriginalCommited != ObsPadraoEspelho;
      if (dirty) return true;
       if (_vendedorOriginalCommited!=null)
       {
          dirty = !_vendedorOriginalCommited.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       dirty = _percComissaoVendedorOriginalCommited != PercComissaoVendedor;
      if (dirty) return true;
       if (_orcamentoItemPaiOriginalCommited!=null)
       {
          dirty = !_orcamentoItemPaiOriginalCommited.Equals(OrcamentoItemPai);
       }
       else
       {
            dirty = OrcamentoItemPai != null;
       }
      if (dirty) return true;
       if (_ncmOriginalCommited!=null)
       {
          dirty = !_ncmOriginalCommited.Equals(Ncm);
       }
       else
       {
            dirty = Ncm != null;
       }

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
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassOrcamentoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassOrcamentoItemPai)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded) 
               {
                  foreach(OrcamentoItemVariavelClass item in CollectionOrcamentoItemVariavelClassOrcamentoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoKitClassOrcamentoItemLoaded) 
               {
                  foreach(OrcamentoKitClass item in CollectionOrcamentoKitClassOrcamentoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded) 
               {
                  foreach(OrcamentoVariavelClass item in CollectionOrcamentoVariavelClassOrcamentoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
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
             case "Posicao":
                return this.Posicao;
             case "SubLinha":
                return this.SubLinha;
             case "Produto":
                return this.Produto;
             case "ProdutoCodigoCliente":
                return this.ProdutoCodigoCliente;
             case "ProdutoDescricaoCliente":
                return this.ProdutoDescricaoCliente;
             case "ProjetoCliente":
                return this.ProjetoCliente;
             case "Quantidade":
                return this.Quantidade;
             case "PrecoUnitario":
                return this.PrecoUnitario;
             case "PrecoTotal":
                return this.PrecoTotal;
             case "Cliente":
                return this.Cliente;
             case "CnpjCliente":
                return this.CnpjCliente;
             case "ArmazenagemCliente":
                return this.ArmazenagemCliente;
             case "Frete":
                return this.Frete;
             case "DataEntrega":
                return this.DataEntrega;
             case "Status":
                return this.Status;
             case "DataEntrada":
                return this.DataEntrada;
             case "Operacao":
                return this.Operacao;
             case "PermiteEntregaParcial":
                return this.PermiteEntregaParcial;
             case "VolumeUnico":
                return this.VolumeUnico;
             case "Configurado":
                return this.Configurado;
             case "Exportacao":
                return this.Exportacao;
             case "PrecoTotalOriginal":
                return this.PrecoTotalOriginal;
             case "AcsUsuarioCancelamento":
                return this.AcsUsuarioCancelamento;
             case "DataCancelamento":
                return this.DataCancelamento;
             case "JustificativaCancelamento":
                return this.JustificativaCancelamento;
             case "DataConfiguracao":
                return this.DataConfiguracao;
             case "DataEntregaOriginal":
                return this.DataEntregaOriginal;
             case "InformacaoEspecial":
                return this.InformacaoEspecial;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ContaBancaria":
                return this.ContaBancaria;
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
             case "FormaPagamento":
                return this.FormaPagamento;
             case "NumeroPedidoAutomatico":
                return this.NumeroPedidoAutomatico;
             case "OrdemVenda":
                return this.OrdemVenda;
             case "Representante":
                return this.Representante;
             case "PercComissaoRepresentante":
                return this.PercComissaoRepresentante;
             case "ObsPadraoEspelho":
                return this.ObsPadraoEspelho;
             case "Vendedor":
                return this.Vendedor;
             case "PercComissaoVendedor":
                return this.PercComissaoVendedor;
             case "OrcamentoItemPai":
                return this.OrcamentoItemPai;
             case "Ncm":
                return this.Ncm;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
             if (Operacao!=null)
                Operacao.ChangeSingleConnection(newConnection);
             if (AcsUsuarioCancelamento!=null)
                AcsUsuarioCancelamento.ChangeSingleConnection(newConnection);
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
             if (FormaPagamento!=null)
                FormaPagamento.ChangeSingleConnection(newConnection);
             if (Representante!=null)
                Representante.ChangeSingleConnection(newConnection);
             if (Vendedor!=null)
                Vendedor.ChangeSingleConnection(newConnection);
             if (OrcamentoItemPai!=null)
                OrcamentoItemPai.ChangeSingleConnection(newConnection);
             if (Ncm!=null)
                Ncm.ChangeSingleConnection(newConnection);
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoItemLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassOrcamentoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemClassOrcamentoItemPaiLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassOrcamentoItemPai)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemVariavelClassOrcamentoItemLoaded) 
               {
                  foreach(OrcamentoItemVariavelClass item in CollectionOrcamentoItemVariavelClassOrcamentoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoKitClassOrcamentoItemLoaded) 
               {
                  foreach(OrcamentoKitClass item in CollectionOrcamentoKitClassOrcamentoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoVariavelClassOrcamentoItemLoaded) 
               {
                  foreach(OrcamentoVariavelClass item in CollectionOrcamentoVariavelClassOrcamentoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
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
                  command.CommandText += " COUNT(orcamento_item.id_orcamento_item) " ;
               }
               else
               {
               command.CommandText += "orcamento_item.id_orcamento_item, " ;
               command.CommandText += "orcamento_item.ori_numero, " ;
               command.CommandText += "orcamento_item.ori_posicao, " ;
               command.CommandText += "orcamento_item.ori_sub_linha, " ;
               command.CommandText += "orcamento_item.id_produto, " ;
               command.CommandText += "orcamento_item.ori_produto_codigo_cliente, " ;
               command.CommandText += "orcamento_item.ori_produto_descricao_cliente, " ;
               command.CommandText += "orcamento_item.ori_projeto_cliente, " ;
               command.CommandText += "orcamento_item.ori_quantidade, " ;
               command.CommandText += "orcamento_item.ori_preco_unitario, " ;
               command.CommandText += "orcamento_item.ori_preco_total, " ;
               command.CommandText += "orcamento_item.id_cliente, " ;
               command.CommandText += "orcamento_item.ori_cnpj_cliente, " ;
               command.CommandText += "orcamento_item.ori_armazenagem_cliente, " ;
               command.CommandText += "orcamento_item.ori_frete, " ;
               command.CommandText += "orcamento_item.ori_data_entrega, " ;
               command.CommandText += "orcamento_item.ori_status, " ;
               command.CommandText += "orcamento_item.ori_data_entrada, " ;
               command.CommandText += "orcamento_item.id_operacao, " ;
               command.CommandText += "orcamento_item.ori_permite_entrega_parcial, " ;
               command.CommandText += "orcamento_item.ori_volume_unico, " ;
               command.CommandText += "orcamento_item.ori_configurado, " ;
               command.CommandText += "orcamento_item.ori_exportacao, " ;
               command.CommandText += "orcamento_item.ori_preco_total_original, " ;
               command.CommandText += "orcamento_item.id_acs_usuario_cancelamento, " ;
               command.CommandText += "orcamento_item.ori_data_cancelamento, " ;
               command.CommandText += "orcamento_item.ori_justificativa_cancelamento, " ;
               command.CommandText += "orcamento_item.ori_data_configuracao, " ;
               command.CommandText += "orcamento_item.ori_data_entrega_original, " ;
               command.CommandText += "orcamento_item.ori_informacao_especial, " ;
               command.CommandText += "orcamento_item.entity_uid, " ;
               command.CommandText += "orcamento_item.version, " ;
               command.CommandText += "orcamento_item.id_conta_bancaria, " ;
               command.CommandText += "orcamento_item.id_centro_custo_lucro, " ;
               command.CommandText += "orcamento_item.id_forma_pagamento, " ;
               command.CommandText += "orcamento_item.ori_numero_pedido_automatico, " ;
               command.CommandText += "orcamento_item.ori_ordem_venda, " ;
               command.CommandText += "orcamento_item.id_representante, " ;
               command.CommandText += "orcamento_item.ori_perc_comissao_representante, " ;
               command.CommandText += "orcamento_item.ori_obs_padrao_espelho, " ;
               command.CommandText += "orcamento_item.id_vendedor, " ;
               command.CommandText += "orcamento_item.ori_perc_comissao_vendedor, " ;
               command.CommandText += "orcamento_item.id_orcamento_item_pai, " ;
               command.CommandText += "orcamento_item.id_ncm " ;
               }
               command.CommandText += " FROM  orcamento_item ";
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
                        orderByClause += " , ori_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ori_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = orcamento_item.id_acs_usuario_ultima_revisao ";
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
                     case "id_orcamento_item":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.id_orcamento_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.id_orcamento_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_posicao":
                     case "Posicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_sub_linha":
                     case "SubLinha":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_sub_linha " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_sub_linha) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = orcamento_item.id_produto ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_Produto.pro_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_Produto.pro_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_produto_codigo_cliente":
                     case "ProdutoCodigoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_produto_codigo_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_produto_codigo_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_produto_descricao_cliente":
                     case "ProdutoDescricaoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_produto_descricao_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_produto_descricao_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_projeto_cliente":
                     case "ProjetoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_projeto_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_projeto_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_preco_unitario":
                     case "PrecoUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_preco_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_preco_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_preco_total":
                     case "PrecoTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_preco_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_preco_total) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = orcamento_item.id_cliente ";                     switch (parametro.TipoOrdenacao)
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
                     case "ori_cnpj_cliente":
                     case "CnpjCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_cnpj_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_cnpj_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_armazenagem_cliente":
                     case "ArmazenagemCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_armazenagem_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_armazenagem_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_frete":
                     case "Frete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_data_entrega":
                     case "DataEntrega":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_data_entrega " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_data_entrega) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_status":
                     case "Status":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_data_entrada":
                     case "DataEntrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_data_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_data_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_operacao":
                     case "Operacao":
                     command.CommandText += " LEFT JOIN operacao as operacao_Operacao ON operacao_Operacao.id_operacao = orcamento_item.id_operacao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_Operacao.ope_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_Operacao.ope_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_permite_entrega_parcial":
                     case "PermiteEntregaParcial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_permite_entrega_parcial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_permite_entrega_parcial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_volume_unico":
                     case "VolumeUnico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_volume_unico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_volume_unico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_configurado":
                     case "Configurado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_configurado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_configurado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_exportacao":
                     case "Exportacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_exportacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_exportacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_preco_total_original":
                     case "PrecoTotalOriginal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_preco_total_original " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_preco_total_original) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_cancelamento":
                     case "AcsUsuarioCancelamento":
                     orderByClause += " , orcamento_item.id_acs_usuario_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "ori_data_cancelamento":
                     case "DataCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_data_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_data_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_justificativa_cancelamento":
                     case "JustificativaCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_justificativa_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_justificativa_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_data_configuracao":
                     case "DataConfiguracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_data_configuracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_data_configuracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_data_entrega_original":
                     case "DataEntregaOriginal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_data_entrega_original " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_data_entrega_original) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_informacao_especial":
                     case "InformacaoEspecial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_informacao_especial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_informacao_especial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , orcamento_item.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = orcamento_item.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria_ContaBancaria.cba_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria_ContaBancaria.cba_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_centro_custo_lucro":
                     case "CentroCustoLucro":
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = orcamento_item.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucro.ccl_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucro.ccl_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucro.ccl_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucro.ccl_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_forma_pagamento":
                     case "FormaPagamento":
                     command.CommandText += " LEFT JOIN forma_pagamento as forma_pagamento_FormaPagamento ON forma_pagamento_FormaPagamento.id_forma_pagamento = orcamento_item.id_forma_pagamento ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , forma_pagamento_FormaPagamento.fop_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(forma_pagamento_FormaPagamento.fop_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_numero_pedido_automatico":
                     case "NumeroPedidoAutomatico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_numero_pedido_automatico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_numero_pedido_automatico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_ordem_venda":
                     case "OrdemVenda":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_ordem_venda " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_ordem_venda) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_representante":
                     case "Representante":
                     command.CommandText += " LEFT JOIN representante as representante_Representante ON representante_Representante.id_representante = orcamento_item.id_representante ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , representante_Representante.rep_razao_social " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(representante_Representante.rep_razao_social) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_perc_comissao_representante":
                     case "PercComissaoRepresentante":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_perc_comissao_representante " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_perc_comissao_representante) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_obs_padrao_espelho":
                     case "ObsPadraoEspelho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_item.ori_obs_padrao_espelho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_item.ori_obs_padrao_espelho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_vendedor":
                     case "Vendedor":
                     command.CommandText += " LEFT JOIN vendedor as vendedor_Vendedor ON vendedor_Vendedor.id_vendedor = orcamento_item.id_vendedor ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor_Vendedor.ven_razao_social " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor_Vendedor.ven_razao_social) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ori_perc_comissao_vendedor":
                     case "PercComissaoVendedor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item.ori_perc_comissao_vendedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item.ori_perc_comissao_vendedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_orcamento_item_pai":
                     case "OrcamentoItemPai":
                     command.CommandText += " LEFT JOIN orcamento_item as orcamento_item_OrcamentoItemPai ON orcamento_item_OrcamentoItemPai.id_orcamento_item = orcamento_item.id_orcamento_item_pai ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item_OrcamentoItemPai.id_orcamento_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item_OrcamentoItemPai.id_orcamento_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ncm":
                     case "Ncm":
                     command.CommandText += " LEFT JOIN ncm as ncm_Ncm ON ncm_Ncm.id_ncm = orcamento_item.id_ncm ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm_Ncm.ncm_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm_Ncm.ncm_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_numero")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_produto_codigo_cliente")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_produto_codigo_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_produto_codigo_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_produto_descricao_cliente")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_produto_descricao_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_produto_descricao_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_projeto_cliente")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_projeto_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_projeto_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_cnpj_cliente")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_cnpj_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_cnpj_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_armazenagem_cliente")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_armazenagem_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_armazenagem_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_justificativa_cancelamento")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_justificativa_cancelamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_justificativa_cancelamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_informacao_especial")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_informacao_especial) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_informacao_especial) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_ordem_venda")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_ordem_venda) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_ordem_venda) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ori_obs_padrao_espelho")) 
                        {
                           whereClause += " OR UPPER(orcamento_item.ori_obs_padrao_espelho) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_item.ori_obs_padrao_espelho) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_orcamento_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_orcamento_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_orcamento_item = :orcamento_item_ID_5583 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ID_5583", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "ori_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_numero LIKE :orcamento_item_Numero_3704 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Numero_3704", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Posicao" || parametro.FieldName == "ori_posicao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_posicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_posicao = :orcamento_item_Posicao_4350 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Posicao_4350", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SubLinha" || parametro.FieldName == "ori_sub_linha")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_sub_linha IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_sub_linha = :orcamento_item_SubLinha_1123 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_SubLinha_1123", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Produto" || parametro.FieldName == "id_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_produto = :orcamento_item_Produto_8129 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Produto_8129", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoCodigoCliente" || parametro.FieldName == "ori_produto_codigo_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_produto_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_produto_codigo_cliente LIKE :orcamento_item_ProdutoCodigoCliente_2072 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ProdutoCodigoCliente_2072", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoDescricaoCliente" || parametro.FieldName == "ori_produto_descricao_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_produto_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_produto_descricao_cliente LIKE :orcamento_item_ProdutoDescricaoCliente_4525 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ProdutoDescricaoCliente_4525", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProjetoCliente" || parametro.FieldName == "ori_projeto_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_projeto_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_projeto_cliente LIKE :orcamento_item_ProjetoCliente_505 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ProjetoCliente_505", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "ori_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_quantidade = :orcamento_item_Quantidade_2847 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Quantidade_2847", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoUnitario" || parametro.FieldName == "ori_preco_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_preco_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_preco_unitario = :orcamento_item_PrecoUnitario_5107 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_PrecoUnitario_5107", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoTotal" || parametro.FieldName == "ori_preco_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_preco_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_preco_total = :orcamento_item_PrecoTotal_7502 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_PrecoTotal_7502", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  orcamento_item.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_cliente = :orcamento_item_Cliente_7928 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Cliente_7928", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjCliente" || parametro.FieldName == "ori_cnpj_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_cnpj_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_cnpj_cliente LIKE :orcamento_item_CnpjCliente_8472 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_CnpjCliente_8472", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ArmazenagemCliente" || parametro.FieldName == "ori_armazenagem_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_armazenagem_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_armazenagem_cliente LIKE :orcamento_item_ArmazenagemCliente_650 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ArmazenagemCliente_650", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Frete" || parametro.FieldName == "ori_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_frete = :orcamento_item_Frete_3792 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Frete_3792", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrega" || parametro.FieldName == "ori_data_entrega")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_data_entrega IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_data_entrega = :orcamento_item_DataEntrega_8680 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_DataEntrega_8680", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Status" || parametro.FieldName == "ori_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is StatusOrcamento)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo StatusOrcamento");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_status = :orcamento_item_Status_8055 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Status_8055", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrada" || parametro.FieldName == "ori_data_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_data_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_data_entrada = :orcamento_item_DataEntrada_2758 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_DataEntrada_2758", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Operacao" || parametro.FieldName == "id_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OperacaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OperacaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_operacao = :orcamento_item_Operacao_2803 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Operacao_2803", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PermiteEntregaParcial" || parametro.FieldName == "ori_permite_entrega_parcial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_permite_entrega_parcial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_permite_entrega_parcial = :orcamento_item_PermiteEntregaParcial_5920 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_PermiteEntregaParcial_5920", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VolumeUnico" || parametro.FieldName == "ori_volume_unico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_volume_unico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_volume_unico = :orcamento_item_VolumeUnico_3556 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_VolumeUnico_3556", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Configurado" || parametro.FieldName == "ori_configurado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_configurado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_configurado = :orcamento_item_Configurado_9336 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Configurado_9336", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Exportacao" || parametro.FieldName == "ori_exportacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_exportacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_exportacao = :orcamento_item_Exportacao_1284 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Exportacao_1284", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoTotalOriginal" || parametro.FieldName == "ori_preco_total_original")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_preco_total_original IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_preco_total_original = :orcamento_item_PrecoTotalOriginal_4208 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_PrecoTotalOriginal_4208", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioCancelamento" || parametro.FieldName == "id_acs_usuario_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_acs_usuario_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_acs_usuario_cancelamento = :orcamento_item_AcsUsuarioCancelamento_1583 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_AcsUsuarioCancelamento_1583", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCancelamento" || parametro.FieldName == "ori_data_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_data_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_data_cancelamento = :orcamento_item_DataCancelamento_6380 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_DataCancelamento_6380", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaCancelamento" || parametro.FieldName == "ori_justificativa_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_justificativa_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_justificativa_cancelamento LIKE :orcamento_item_JustificativaCancelamento_5031 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_JustificativaCancelamento_5031", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataConfiguracao" || parametro.FieldName == "ori_data_configuracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_data_configuracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_data_configuracao = :orcamento_item_DataConfiguracao_853 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_DataConfiguracao_853", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntregaOriginal" || parametro.FieldName == "ori_data_entrega_original")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_data_entrega_original IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_data_entrega_original = :orcamento_item_DataEntregaOriginal_7562 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_DataEntregaOriginal_7562", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacaoEspecial" || parametro.FieldName == "ori_informacao_especial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_informacao_especial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_informacao_especial LIKE :orcamento_item_InformacaoEspecial_9461 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_InformacaoEspecial_9461", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  orcamento_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.entity_uid LIKE :orcamento_item_EntityUid_5576 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_EntityUid_5576", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  orcamento_item.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.version = :orcamento_item_Version_4575 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Version_4575", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaBancaria" || parametro.FieldName == "id_conta_bancaria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ContaBancariaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ContaBancariaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_conta_bancaria = :orcamento_item_ContaBancaria_9327 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ContaBancaria_9327", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CentroCustoLucro" || parametro.FieldName == "id_centro_custo_lucro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CentroCustoLucroClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CentroCustoLucroClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_centro_custo_lucro = :orcamento_item_CentroCustoLucro_5577 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_CentroCustoLucro_5577", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FormaPagamento" || parametro.FieldName == "id_forma_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FormaPagamentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FormaPagamentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_forma_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_forma_pagamento = :orcamento_item_FormaPagamento_7699 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_FormaPagamento_7699", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroPedidoAutomatico" || parametro.FieldName == "ori_numero_pedido_automatico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_numero_pedido_automatico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_numero_pedido_automatico = :orcamento_item_NumeroPedidoAutomatico_8913 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_NumeroPedidoAutomatico_8913", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemVenda" || parametro.FieldName == "ori_ordem_venda")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_ordem_venda IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_ordem_venda LIKE :orcamento_item_OrdemVenda_6386 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_OrdemVenda_6386", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Representante" || parametro.FieldName == "id_representante")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.RepresentanteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.RepresentanteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_representante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_representante = :orcamento_item_Representante_4533 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Representante_4533", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercComissaoRepresentante" || parametro.FieldName == "ori_perc_comissao_representante")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_perc_comissao_representante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_perc_comissao_representante = :orcamento_item_PercComissaoRepresentante_723 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_PercComissaoRepresentante_723", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsPadraoEspelho" || parametro.FieldName == "ori_obs_padrao_espelho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_obs_padrao_espelho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_obs_padrao_espelho LIKE :orcamento_item_ObsPadraoEspelho_6838 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ObsPadraoEspelho_6838", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Vendedor" || parametro.FieldName == "id_vendedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.VendedorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.VendedorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_vendedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_vendedor = :orcamento_item_Vendedor_715 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Vendedor_715", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercComissaoVendedor" || parametro.FieldName == "ori_perc_comissao_vendedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_perc_comissao_vendedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_perc_comissao_vendedor = :orcamento_item_PercComissaoVendedor_339 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_PercComissaoVendedor_339", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrcamentoItemPai" || parametro.FieldName == "id_orcamento_item_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrcamentoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrcamentoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_orcamento_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_orcamento_item_pai = :orcamento_item_OrcamentoItemPai_4044 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_OrcamentoItemPai_4044", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ncm" || parametro.FieldName == "id_ncm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.NcmClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.NcmClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.id_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.id_ncm = :orcamento_item_Ncm_4555 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Ncm_4555", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroExato" || parametro.FieldName == "NumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_numero LIKE :orcamento_item_Numero_1527 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_Numero_1527", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoCodigoClienteExato" || parametro.FieldName == "ProdutoCodigoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_produto_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_produto_codigo_cliente LIKE :orcamento_item_ProdutoCodigoCliente_7782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ProdutoCodigoCliente_7782", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoDescricaoClienteExato" || parametro.FieldName == "ProdutoDescricaoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_produto_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_produto_descricao_cliente LIKE :orcamento_item_ProdutoDescricaoCliente_5220 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ProdutoDescricaoCliente_5220", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProjetoClienteExato" || parametro.FieldName == "ProjetoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_projeto_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_projeto_cliente LIKE :orcamento_item_ProjetoCliente_7294 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ProjetoCliente_7294", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjClienteExato" || parametro.FieldName == "CnpjClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_cnpj_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_cnpj_cliente LIKE :orcamento_item_CnpjCliente_5619 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_CnpjCliente_5619", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ArmazenagemClienteExato" || parametro.FieldName == "ArmazenagemClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_armazenagem_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_armazenagem_cliente LIKE :orcamento_item_ArmazenagemCliente_9661 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ArmazenagemCliente_9661", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaCancelamentoExato" || parametro.FieldName == "JustificativaCancelamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_justificativa_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_justificativa_cancelamento LIKE :orcamento_item_JustificativaCancelamento_724 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_JustificativaCancelamento_724", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacaoEspecialExato" || parametro.FieldName == "InformacaoEspecialExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_informacao_especial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_informacao_especial LIKE :orcamento_item_InformacaoEspecial_776 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_InformacaoEspecial_776", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.entity_uid LIKE :orcamento_item_EntityUid_1082 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_EntityUid_1082", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemVendaExato" || parametro.FieldName == "OrdemVendaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_ordem_venda IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_ordem_venda LIKE :orcamento_item_OrdemVenda_9187 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_OrdemVenda_9187", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsPadraoEspelhoExato" || parametro.FieldName == "ObsPadraoEspelhoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_item.ori_obs_padrao_espelho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_item.ori_obs_padrao_espelho LIKE :orcamento_item_ObsPadraoEspelho_6193 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_item_ObsPadraoEspelho_6193", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrcamentoItemClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrcamentoItemClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrcamentoItemClass), Convert.ToInt32(read["id_orcamento_item"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrcamentoItemClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_orcamento_item"]);
                     entidade.Numero = (read["ori_numero"] != DBNull.Value ? read["ori_numero"].ToString() : null);
                     entidade.Posicao = (int)read["ori_posicao"];
                     entidade.SubLinha = (int)read["ori_sub_linha"];
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     entidade.ProdutoCodigoCliente = (read["ori_produto_codigo_cliente"] != DBNull.Value ? read["ori_produto_codigo_cliente"].ToString() : null);
                     entidade.ProdutoDescricaoCliente = (read["ori_produto_descricao_cliente"] != DBNull.Value ? read["ori_produto_descricao_cliente"].ToString() : null);
                     entidade.ProjetoCliente = (read["ori_projeto_cliente"] != DBNull.Value ? read["ori_projeto_cliente"].ToString() : null);
                     entidade.Quantidade = (double)read["ori_quantidade"];
                     entidade.PrecoUnitario = (double)read["ori_preco_unitario"];
                     entidade.PrecoTotal = (double)read["ori_preco_total"];
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     entidade.CnpjCliente = (read["ori_cnpj_cliente"] != DBNull.Value ? read["ori_cnpj_cliente"].ToString() : null);
                     entidade.ArmazenagemCliente = (read["ori_armazenagem_cliente"] != DBNull.Value ? read["ori_armazenagem_cliente"].ToString() : null);
                     entidade.Frete = (double)read["ori_frete"];
                     entidade.DataEntrega = (DateTime)read["ori_data_entrega"];
                     entidade.Status = (StatusOrcamento) (read["ori_status"] != DBNull.Value ? Enum.ToObject(typeof(StatusOrcamento), read["ori_status"]) : null);
                     entidade.DataEntrada = (DateTime)read["ori_data_entrada"];
                     if (read["id_operacao"] != DBNull.Value)
                     {
                        entidade.Operacao = (BibliotecaEntidades.Entidades.OperacaoClass)BibliotecaEntidades.Entidades.OperacaoClass.GetEntidade(Convert.ToInt32(read["id_operacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Operacao = null ;
                     }
                     entidade.PermiteEntregaParcial = Convert.ToBoolean(Convert.ToInt16(read["ori_permite_entrega_parcial"]));
                     entidade.VolumeUnico = Convert.ToBoolean(Convert.ToInt16(read["ori_volume_unico"]));
                     entidade.Configurado = Convert.ToBoolean(Convert.ToInt16(read["ori_configurado"]));
                     entidade.Exportacao = Convert.ToBoolean(Convert.ToInt16(read["ori_exportacao"]));
                     entidade.PrecoTotalOriginal = (double)read["ori_preco_total_original"];
                     if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioCancelamento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioCancelamento = null ;
                     }
                     entidade.DataCancelamento = read["ori_data_cancelamento"] as DateTime?;
                     entidade.JustificativaCancelamento = (read["ori_justificativa_cancelamento"] != DBNull.Value ? read["ori_justificativa_cancelamento"].ToString() : null);
                     entidade.DataConfiguracao = read["ori_data_configuracao"] as DateTime?;
                     entidade.DataEntregaOriginal = read["ori_data_entrega_original"] as DateTime?;
                     entidade.InformacaoEspecial = (read["ori_informacao_especial"] != DBNull.Value ? read["ori_informacao_especial"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_conta_bancaria"] != DBNull.Value)
                     {
                        entidade.ContaBancaria = (BibliotecaEntidades.Entidades.ContaBancariaClass)BibliotecaEntidades.Entidades.ContaBancariaClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaBancaria = null ;
                     }
                     if (read["id_centro_custo_lucro"] != DBNull.Value)
                     {
                        entidade.CentroCustoLucro = (BibliotecaEntidades.Entidades.CentroCustoLucroClass)BibliotecaEntidades.Entidades.CentroCustoLucroClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CentroCustoLucro = null ;
                     }
                     if (read["id_forma_pagamento"] != DBNull.Value)
                     {
                        entidade.FormaPagamento = (BibliotecaEntidades.Entidades.FormaPagamentoClass)BibliotecaEntidades.Entidades.FormaPagamentoClass.GetEntidade(Convert.ToInt32(read["id_forma_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FormaPagamento = null ;
                     }
                     entidade.NumeroPedidoAutomatico = Convert.ToBoolean(Convert.ToInt16(read["ori_numero_pedido_automatico"]));
                     entidade.OrdemVenda = (read["ori_ordem_venda"] != DBNull.Value ? read["ori_ordem_venda"].ToString() : null);
                     if (read["id_representante"] != DBNull.Value)
                     {
                        entidade.Representante = (BibliotecaEntidades.Entidades.RepresentanteClass)BibliotecaEntidades.Entidades.RepresentanteClass.GetEntidade(Convert.ToInt32(read["id_representante"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Representante = null ;
                     }
                     entidade.PercComissaoRepresentante = read["ori_perc_comissao_representante"] as double?;
                     entidade.ObsPadraoEspelho = (read["ori_obs_padrao_espelho"] != DBNull.Value ? read["ori_obs_padrao_espelho"].ToString() : null);
                     if (read["id_vendedor"] != DBNull.Value)
                     {
                        entidade.Vendedor = (BibliotecaEntidades.Entidades.VendedorClass)BibliotecaEntidades.Entidades.VendedorClass.GetEntidade(Convert.ToInt32(read["id_vendedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Vendedor = null ;
                     }
                     entidade.PercComissaoVendedor = read["ori_perc_comissao_vendedor"] as double?;
                     if (read["id_orcamento_item_pai"] != DBNull.Value)
                     {
                        entidade.OrcamentoItemPai = (BibliotecaEntidades.Entidades.OrcamentoItemClass)BibliotecaEntidades.Entidades.OrcamentoItemClass.GetEntidade(Convert.ToInt32(read["id_orcamento_item_pai"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrcamentoItemPai = null ;
                     }
                     if (read["id_ncm"] != DBNull.Value)
                     {
                        entidade.Ncm = (BibliotecaEntidades.Entidades.NcmClass)BibliotecaEntidades.Entidades.NcmClass.GetEntidade(Convert.ToInt32(read["id_ncm"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Ncm = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrcamentoItemClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
