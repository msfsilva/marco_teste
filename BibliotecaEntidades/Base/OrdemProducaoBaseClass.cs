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
     [Table("ordem_producao","orp")]
     public class OrdemProducaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoClass.";
protected const string ErroCollectionOrdemProducaoDiferencaClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoDiferencaClass.";
protected const string ErroCollectionOrdemProducaoDocumentoOpClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoDocumentoOpClass.";
protected const string ErroCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosClass.";
protected const string ErroCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosCancelamentoSaldoClass.";
protected const string ErroCollectionOrdemProducaoEstoqueClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoEstoqueClass.";
protected const string ErroCollectionOrdemProducaoHistoricoClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoHistoricoClass.";
protected const string ErroCollectionOrdemProducaoMaterialClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoMaterialClass.";
protected const string ErroCollectionOrdemProducaoPedidoClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoPedidoClass.";
protected const string ErroCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoClass.";
protected const string ErroCollectionOrdemProducaoProdutoComponenteClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoProdutoComponenteClass.";
protected const string ErroCollectionOrdemProducaoRecursoClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoRecursoClass.";
protected const string ErroCollectionPlanoCorteItemOpClassOrdemProducao = "Erro ao carregar a coleção de PlanoCorteItemOpClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected const string ErroOrdemProducaoGrupoObrigatorio = "O campo OrdemProducaoGrupo é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoClass.";
protected const string MensagemUtilizadoCollectionOrdemProducaoDiferencaClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoDiferencaClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoDocumentoOpClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoDocumentoOpClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosCancelamentoSaldoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEstoqueClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoEstoqueClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoHistoricoClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoHistoricoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoMaterialClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoMaterialClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoPedidoClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoPedidoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoProdutoComponenteClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoProdutoComponenteClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoRecursoClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoRecursoClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemOpClassOrdemProducao =  "A entidade OrdemProducaoClass está sendo utilizada nos seguintes PlanoCorteItemOpClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoClass está sendo utilizada.";
#endregion
       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("orp_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("orp_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected StatusOrdemProducao _situacaoOriginal{get;private set;}
       private StatusOrdemProducao _situacaoOriginalCommited{get; set;}
        private StatusOrdemProducao _valueSituacao;
         [Column("orp_situacao")]
        public virtual StatusOrdemProducao Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

        public bool Situacao_AguardandoInicioProducao
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusOrdemProducao.AguardandoInicioProducao; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusOrdemProducao.AguardandoInicioProducao; }
         } 

        public bool Situacao_Producao
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusOrdemProducao.Producao; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusOrdemProducao.Producao; }
         } 

        public bool Situacao_Encerrada
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusOrdemProducao.Encerrada; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusOrdemProducao.Encerrada; }
         } 

        public bool Situacao_Cancelada
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusOrdemProducao.Cancelada; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusOrdemProducao.Cancelada; }
         } 

        public bool Situacao_AguardandoServicoExterno
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusOrdemProducao.AguardandoServicoExterno; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusOrdemProducao.AguardandoServicoExterno; }
         } 

       protected string _produtoDescricaoOriginal{get;private set;}
       private string _produtoDescricaoOriginalCommited{get; set;}
        private string _valueProdutoDescricao;
         [Column("orp_produto_descricao")]
        public virtual string ProdutoDescricao
         { 
            get { return this._valueProdutoDescricao; } 
            set 
            { 
                if (this._valueProdutoDescricao == value)return;
                 this._valueProdutoDescricao = value; 
            } 
        } 

       protected string _tipoDocumentoOriginal{get;private set;}
       private string _tipoDocumentoOriginalCommited{get; set;}
        private string _valueTipoDocumento;
         [Column("orp_tipo_documento")]
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
         [Column("orp_numero_documento")]
        public virtual string NumeroDocumento
         { 
            get { return this._valueNumeroDocumento; } 
            set 
            { 
                if (this._valueNumeroDocumento == value)return;
                 this._valueNumeroDocumento = value; 
            } 
        } 

       protected string _revisaoDocumentoOriginal{get;private set;}
       private string _revisaoDocumentoOriginalCommited{get; set;}
        private string _valueRevisaoDocumento;
         [Column("orp_revisao_documento")]
        public virtual string RevisaoDocumento
         { 
            get { return this._valueRevisaoDocumento; } 
            set 
            { 
                if (this._valueRevisaoDocumento == value)return;
                 this._valueRevisaoDocumento = value; 
            } 
        } 

       protected string _clienteNaoUsarOriginal{get;private set;}
       private string _clienteNaoUsarOriginalCommited{get; set;}
        private string _valueClienteNaoUsar;
         [Column("orp_cliente_nao_usar")]
        public virtual string ClienteNaoUsar
         { 
            get { return this._valueClienteNaoUsar; } 
            set 
            { 
                if (this._valueClienteNaoUsar == value)return;
                 this._valueClienteNaoUsar = value; 
            } 
        } 

       protected string _dimensaoOriginal{get;private set;}
       private string _dimensaoOriginalCommited{get; set;}
        private string _valueDimensao;
         [Column("orp_dimensao")]
        public virtual string Dimensao
         { 
            get { return this._valueDimensao; } 
            set 
            { 
                if (this._valueDimensao == value)return;
                 this._valueDimensao = value; 
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

       protected string _produtoCodigoOriginal{get;private set;}
       private string _produtoCodigoOriginalCommited{get; set;}
        private string _valueProdutoCodigo;
         [Column("orp_produto_codigo")]
        public virtual string ProdutoCodigo
         { 
            get { return this._valueProdutoCodigo; } 
            set 
            { 
                if (this._valueProdutoCodigo == value)return;
                 this._valueProdutoCodigo = value; 
            } 
        } 

       protected double _quantidadeEstoqueOriginal{get;private set;}
       private double _quantidadeEstoqueOriginalCommited{get; set;}
        private double _valueQuantidadeEstoque;
         [Column("orp_quantidade_estoque")]
        public virtual double QuantidadeEstoque
         { 
            get { return this._valueQuantidadeEstoque; } 
            set 
            { 
                if (this._valueQuantidadeEstoque == value)return;
                 this._valueQuantidadeEstoque = value; 
            } 
        } 

       protected double _quantidadePedidoOriginal{get;private set;}
       private double _quantidadePedidoOriginalCommited{get; set;}
        private double _valueQuantidadePedido;
         [Column("orp_quantidade_pedido")]
        public virtual double QuantidadePedido
         { 
            get { return this._valueQuantidadePedido; } 
            set 
            { 
                if (this._valueQuantidadePedido == value)return;
                 this._valueQuantidadePedido = value; 
            } 
        } 

       protected bool _pendenciaOriginal{get;private set;}
       private bool _pendenciaOriginalCommited{get; set;}
        private bool _valuePendencia;
         [Column("orp_pendencia")]
        public virtual bool Pendencia
         { 
            get { return this._valuePendencia; } 
            set 
            { 
                if (this._valuePendencia == value)return;
                 this._valuePendencia = value; 
            } 
        } 

       protected bool _suspensaOriginal{get;private set;}
       private bool _suspensaOriginalCommited{get; set;}
        private bool _valueSuspensa;
         [Column("orp_suspensa")]
        public virtual bool Suspensa
         { 
            get { return this._valueSuspensa; } 
            set 
            { 
                if (this._valueSuspensa == value)return;
                 this._valueSuspensa = value; 
            } 
        } 

       protected bool _qtdMaiorVerificadaOriginal{get;private set;}
       private bool _qtdMaiorVerificadaOriginalCommited{get; set;}
        private bool _valueQtdMaiorVerificada;
         [Column("orp_qtd_maior_verificada")]
        public virtual bool QtdMaiorVerificada
         { 
            get { return this._valueQtdMaiorVerificada; } 
            set 
            { 
                if (this._valueQtdMaiorVerificada == value)return;
                 this._valueQtdMaiorVerificada = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass _ordemProducaoGrupoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass _ordemProducaoGrupoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass _valueOrdemProducaoGrupo;
        [Column("id_ordem_producao_grupo", "ordem_producao_grupo", "id_ordem_producao_grupo")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass OrdemProducaoGrupo
        { 
           get {                 return this._valueOrdemProducaoGrupo; } 
           set 
           { 
                if (this._valueOrdemProducaoGrupo == value)return;
                 this._valueOrdemProducaoGrupo = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuario;
        [Column("id_acs_usuario", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuario
        { 
           get {                 return this._valueAcsUsuario; } 
           set 
           { 
                if (this._valueAcsUsuario == value)return;
                 this._valueAcsUsuario = value; 
           } 
       } 

       protected DateTime? _dataReimpressaoOriginal{get;private set;}
       private DateTime? _dataReimpressaoOriginalCommited{get; set;}
        private DateTime? _valueDataReimpressao;
         [Column("orp_data_reimpressao")]
        public virtual DateTime? DataReimpressao
         { 
            get { return this._valueDataReimpressao; } 
            set 
            { 
                if (this._valueDataReimpressao == value)return;
                 this._valueDataReimpressao = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioReimpressaoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioReimpressaoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioReimpressao;
        [Column("id_acs_usuario_reimpressao", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioReimpressao
        { 
           get {                 return this._valueAcsUsuarioReimpressao; } 
           set 
           { 
                if (this._valueAcsUsuarioReimpressao == value)return;
                 this._valueAcsUsuarioReimpressao = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioImpressaoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioImpressaoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioImpressao;
        [Column("id_acs_usuario_impressao", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioImpressao
        { 
           get {                 return this._valueAcsUsuarioImpressao; } 
           set 
           { 
                if (this._valueAcsUsuarioImpressao == value)return;
                 this._valueAcsUsuarioImpressao = value; 
           } 
       } 

       protected DateTime? _dataImpressaoOriginal{get;private set;}
       private DateTime? _dataImpressaoOriginalCommited{get; set;}
        private DateTime? _valueDataImpressao;
         [Column("orp_data_impressao")]
        public virtual DateTime? DataImpressao
         { 
            get { return this._valueDataImpressao; } 
            set 
            { 
                if (this._valueDataImpressao == value)return;
                 this._valueDataImpressao = value; 
            } 
        } 

       protected string _agrupadorOpOriginal{get;private set;}
       private string _agrupadorOpOriginalCommited{get; set;}
        private string _valueAgrupadorOp;
         [Column("orp_agrupador_op")]
        public virtual string AgrupadorOp
         { 
            get { return this._valueAgrupadorOp; } 
            set 
            { 
                if (this._valueAgrupadorOp == value)return;
                 this._valueAgrupadorOp = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEncerramentoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEncerramentoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioEncerramento;
        [Column("id_acs_usuario_encerramento", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioEncerramento
        { 
           get {                 return this._valueAcsUsuarioEncerramento; } 
           set 
           { 
                if (this._valueAcsUsuarioEncerramento == value)return;
                 this._valueAcsUsuarioEncerramento = value; 
           } 
       } 

       protected DateTime? _dataEncerramentoOriginal{get;private set;}
       private DateTime? _dataEncerramentoOriginalCommited{get; set;}
        private DateTime? _valueDataEncerramento;
         [Column("orp_data_encerramento")]
        public virtual DateTime? DataEncerramento
         { 
            get { return this._valueDataEncerramento; } 
            set 
            { 
                if (this._valueDataEncerramento == value)return;
                 this._valueDataEncerramento = value; 
            } 
        } 

       protected int _versaoEstruturaProdutoOriginal{get;private set;}
       private int _versaoEstruturaProdutoOriginalCommited{get; set;}
        private int _valueVersaoEstruturaProduto;
         [Column("orp_versao_estrutura_produto")]
        public virtual int VersaoEstruturaProduto
         { 
            get { return this._valueVersaoEstruturaProduto; } 
            set 
            { 
                if (this._valueVersaoEstruturaProduto == value)return;
                 this._valueVersaoEstruturaProduto = value; 
            } 
        } 

       protected bool _rastreamentoMaterialOriginal{get;private set;}
       private bool _rastreamentoMaterialOriginalCommited{get; set;}
        private bool _valueRastreamentoMaterial;
         [Column("orp_rastreamento_material")]
        public virtual bool RastreamentoMaterial
         { 
            get { return this._valueRastreamentoMaterial; } 
            set 
            { 
                if (this._valueRastreamentoMaterial == value)return;
                 this._valueRastreamentoMaterial = value; 
            } 
        } 

       protected double _quantidadeExtraOriginal{get;private set;}
       private double _quantidadeExtraOriginalCommited{get; set;}
        private double _valueQuantidadeExtra;
         [Column("orp_quantidade_extra")]
        public virtual double QuantidadeExtra
         { 
            get { return this._valueQuantidadeExtra; } 
            set 
            { 
                if (this._valueQuantidadeExtra == value)return;
                 this._valueQuantidadeExtra = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _valueEstoqueGaveta;
        [Column("id_estoque_gaveta", "estoque_gaveta", "id_estoque_gaveta")]
       public virtual BibliotecaEntidades.Entidades.EstoqueGavetaClass EstoqueGaveta
        { 
           get {                 return this._valueEstoqueGaveta; } 
           set 
           { 
                if (this._valueEstoqueGaveta == value)return;
                 this._valueEstoqueGaveta = value; 
           } 
       } 

       protected bool _imprimeRelacionadasOriginal{get;private set;}
       private bool _imprimeRelacionadasOriginalCommited{get; set;}
        private bool _valueImprimeRelacionadas;
         [Column("orp_imprime_relacionadas")]
        public virtual bool ImprimeRelacionadas
         { 
            get { return this._valueImprimeRelacionadas; } 
            set 
            { 
                if (this._valueImprimeRelacionadas == value)return;
                 this._valueImprimeRelacionadas = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ProdutoKClass _produtoKOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoKClass _produtoKOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoKClass _valueProdutoK;
        [Column("id_produto_k", "produto_k", "id_produto_k")]
       public virtual BibliotecaEntidades.Entidades.ProdutoKClass ProdutoK
        { 
           get {                 return this._valueProdutoK; } 
           set 
           { 
                if (this._valueProdutoK == value)return;
                 this._valueProdutoK = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioLiberacaoQualidadeOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioLiberacaoQualidadeOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioLiberacaoQualidade;
        [Column("id_acs_usuario_liberacao_qualidade", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioLiberacaoQualidade
        { 
           get {                 return this._valueAcsUsuarioLiberacaoQualidade; } 
           set 
           { 
                if (this._valueAcsUsuarioLiberacaoQualidade == value)return;
                 this._valueAcsUsuarioLiberacaoQualidade = value; 
           } 
       } 

       protected string _observacaoLiberacaoQualidadeOriginal{get;private set;}
       private string _observacaoLiberacaoQualidadeOriginalCommited{get; set;}
        private string _valueObservacaoLiberacaoQualidade;
         [Column("orp_observacao_liberacao_qualidade")]
        public virtual string ObservacaoLiberacaoQualidade
         { 
            get { return this._valueObservacaoLiberacaoQualidade; } 
            set 
            { 
                if (this._valueObservacaoLiberacaoQualidade == value)return;
                 this._valueObservacaoLiberacaoQualidade = value; 
            } 
        } 

       protected double? _quantidadeFinalOriginal{get;private set;}
       private double? _quantidadeFinalOriginalCommited{get; set;}
        private double? _valueQuantidadeFinal;
         [Column("orp_quantidade_final")]
        public virtual double? QuantidadeFinal
         { 
            get { return this._valueQuantidadeFinal; } 
            set 
            { 
                if (this._valueQuantidadeFinal == value)return;
                 this._valueQuantidadeFinal = value; 
            } 
        } 

       protected bool _pendenciaDeQuantidadeOriginal{get;private set;}
       private bool _pendenciaDeQuantidadeOriginalCommited{get; set;}
        private bool _valuePendenciaDeQuantidade;
         [Column("orp_pendencia_de_quantidade")]
        public virtual bool PendenciaDeQuantidade
         { 
            get { return this._valuePendenciaDeQuantidade; } 
            set 
            { 
                if (this._valuePendenciaDeQuantidade == value)return;
                 this._valuePendenciaDeQuantidade = value; 
            } 
        } 

       private List<long> _collectionOrdemProducaoDiferencaClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoDiferencaClass > _collectionOrdemProducaoDiferencaClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoDiferencaClass> _valueCollectionOrdemProducaoDiferencaClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoDiferencaClass> CollectionOrdemProducaoDiferencaClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoDiferencaClassOrdemProducao();}
return this._valueCollectionOrdemProducaoDiferencaClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoDiferencaClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoDocumentoOpClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoDocumentoOpClass > _collectionOrdemProducaoDocumentoOpClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoDocumentoOpClass> _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoDocumentoOpClass> CollectionOrdemProducaoDocumentoOpClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoDocumentoOpClassOrdemProducao();}
return this._valueCollectionOrdemProducaoDocumentoOpClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoDocumentoOpClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoEnvioTerceirosClass > _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao();}
return this._valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass > _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass> _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass> CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao();}
return this._valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEstoqueClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoEstoqueClass > _collectionOrdemProducaoEstoqueClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEstoqueClass> _valueCollectionOrdemProducaoEstoqueClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEstoqueClass> CollectionOrdemProducaoEstoqueClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEstoqueClassOrdemProducao();}
return this._valueCollectionOrdemProducaoEstoqueClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEstoqueClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoHistoricoClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoHistoricoClass > _collectionOrdemProducaoHistoricoClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoHistoricoClass> _valueCollectionOrdemProducaoHistoricoClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoHistoricoClass> CollectionOrdemProducaoHistoricoClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoHistoricoClassOrdemProducao();}
return this._valueCollectionOrdemProducaoHistoricoClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoHistoricoClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoMaterialClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoMaterialClass > _collectionOrdemProducaoMaterialClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoMaterialClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoMaterialClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoMaterialClass> _valueCollectionOrdemProducaoMaterialClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoMaterialClass> CollectionOrdemProducaoMaterialClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoMaterialClassOrdemProducao();}
return this._valueCollectionOrdemProducaoMaterialClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoMaterialClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoPedidoClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoPedidoClass > _collectionOrdemProducaoPedidoClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPedidoClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPedidoClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoPedidoClass> _valueCollectionOrdemProducaoPedidoClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoPedidoClass> CollectionOrdemProducaoPedidoClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoPedidoClassOrdemProducao();}
return this._valueCollectionOrdemProducaoPedidoClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoPedidoClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoPostoTrabalhoClass > _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoPostoTrabalhoClass> _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoPostoTrabalhoClass> CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao();}
return this._valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoProdutoComponenteClass > _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoProdutoComponenteClass> _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoProdutoComponenteClass> CollectionOrdemProducaoProdutoComponenteClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoProdutoComponenteClassOrdemProducao();}
return this._valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoRecursoClassOrdemProducaoOriginal;
       private List<Entidades.OrdemProducaoRecursoClass > _collectionOrdemProducaoRecursoClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoRecursoClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoRecursoClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoRecursoClass> _valueCollectionOrdemProducaoRecursoClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoRecursoClass> CollectionOrdemProducaoRecursoClassOrdemProducao 
       { 
           get { if(!_valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoRecursoClassOrdemProducao();}
return this._valueCollectionOrdemProducaoRecursoClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoRecursoClassOrdemProducao = value; 
               this._valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemOpClassOrdemProducaoOriginal;
       private List<Entidades.PlanoCorteItemOpClass > _collectionPlanoCorteItemOpClassOrdemProducaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemOpClassOrdemProducaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemOpClassOrdemProducaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemOpClass> _valueCollectionPlanoCorteItemOpClassOrdemProducao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemOpClass> CollectionPlanoCorteItemOpClassOrdemProducao 
       { 
           get { if(!_valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemOpClassOrdemProducao();}
return this._valueCollectionPlanoCorteItemOpClassOrdemProducao; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemOpClassOrdemProducao = value; 
               this._valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded = true; 
           } 
       } 

        public OrdemProducaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Quantidade = 0;
           this.Situacao = (StatusOrdemProducao)0;
           this.QuantidadeEstoque = 0;
           this.QuantidadePedido = 0;
           this.Pendencia = false;
           this.Suspensa = false;
           this.QtdMaiorVerificada = false;
           this.VersaoEstruturaProduto = 0;
           this.RastreamentoMaterial = false;
           this.QuantidadeExtra = 0;
           this.ImprimeRelacionadas = false;
           this.PendenciaDeQuantidade = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoClass) GetEntity(typeof(OrdemProducaoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrdemProducaoDiferencaClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDiferencaClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoDiferencaClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDiferencaClass item in _valueCollectionOrdemProducaoDiferencaClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoDiferencaClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoDiferencaClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoDiferencaClass> oc;
                _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoDiferencaClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoDiferencaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoDiferencaClass>();
                }
                else{ 
                   Entidades.OrdemProducaoDiferencaClass search = new Entidades.OrdemProducaoDiferencaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoDiferencaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoDiferencaClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoDiferencaClassOrdemProducao = new BindingList<Entidades.OrdemProducaoDiferencaClass>(oc); 
                 _collectionOrdemProducaoDiferencaClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoDiferencaClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoDiferencaClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoDiferencaClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoDocumentoOpClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoOpClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoDocumentoOpClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoOpClass item in _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoDocumentoOpClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoDocumentoOpClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoDocumentoOpClass> oc;
                _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoDocumentoOpClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoDocumentoOpClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoDocumentoOpClass>();
                }
                else{ 
                   Entidades.OrdemProducaoDocumentoOpClass search = new Entidades.OrdemProducaoDocumentoOpClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoDocumentoOpClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoDocumentoOpClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducao = new BindingList<Entidades.OrdemProducaoDocumentoOpClass>(oc); 
                 _collectionOrdemProducaoDocumentoOpClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoDocumentoOpClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoDocumentoOpClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass> oc;
                _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEnvioTerceirosClass search = new Entidades.OrdemProducaoEnvioTerceirosClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoEnvioTerceirosClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao = new BindingList<Entidades.OrdemProducaoEnvioTerceirosClass>(oc); 
                 _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass item in _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass> oc;
                _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass search = new Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao = new BindingList<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass>(oc); 
                 _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEstoqueClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEstoqueClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEstoqueClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEstoqueClass item in _valueCollectionOrdemProducaoEstoqueClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoEstoqueClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEstoqueClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEstoqueClass> oc;
                _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoEstoqueClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoEstoqueClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEstoqueClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEstoqueClass search = new Entidades.OrdemProducaoEstoqueClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEstoqueClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoEstoqueClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEstoqueClassOrdemProducao = new BindingList<Entidades.OrdemProducaoEstoqueClass>(oc); 
                 _collectionOrdemProducaoEstoqueClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoEstoqueClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEstoqueClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEstoqueClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoHistoricoClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoHistoricoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoHistoricoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoHistoricoClass item in _valueCollectionOrdemProducaoHistoricoClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoHistoricoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoHistoricoClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoHistoricoClass> oc;
                _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoHistoricoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoHistoricoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoHistoricoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoHistoricoClass search = new Entidades.OrdemProducaoHistoricoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoHistoricoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoHistoricoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoHistoricoClassOrdemProducao = new BindingList<Entidades.OrdemProducaoHistoricoClass>(oc); 
                 _collectionOrdemProducaoHistoricoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoHistoricoClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoHistoricoClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoHistoricoClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoMaterialClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoMaterialClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoMaterialClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoMaterialClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoMaterialClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoMaterialClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoMaterialClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoMaterialClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoMaterialClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoMaterialClass item in _valueCollectionOrdemProducaoMaterialClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoMaterialClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoMaterialClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoMaterialClass> oc;
                _valueCollectionOrdemProducaoMaterialClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoMaterialClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoMaterialClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoMaterialClass>();
                }
                else{ 
                   Entidades.OrdemProducaoMaterialClass search = new Entidades.OrdemProducaoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoMaterialClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoMaterialClassOrdemProducao = new BindingList<Entidades.OrdemProducaoMaterialClass>(oc); 
                 _collectionOrdemProducaoMaterialClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoMaterialClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoMaterialClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoMaterialClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoPedidoClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoPedidoClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoPedidoClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoPedidoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoPedidoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPedidoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoPedidoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoPedidoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoPedidoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPedidoClass item in _valueCollectionOrdemProducaoPedidoClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoPedidoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoPedidoClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoPedidoClass> oc;
                _valueCollectionOrdemProducaoPedidoClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoPedidoClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoPedidoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoPedidoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoPedidoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoPedidoClass search = new Entidades.OrdemProducaoPedidoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoPedidoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoPedidoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoPedidoClassOrdemProducao = new BindingList<Entidades.OrdemProducaoPedidoClass>(oc); 
                 _collectionOrdemProducaoPedidoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoPedidoClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoPedidoClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoPedidoClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoClass item in _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoClass> oc;
                _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoPostoTrabalhoClass search = new Entidades.OrdemProducaoPostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoPostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao = new BindingList<Entidades.OrdemProducaoPostoTrabalhoClass>(oc); 
                 _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoProdutoComponenteClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoProdutoComponenteClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoProdutoComponenteClass item in _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoProdutoComponenteClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoProdutoComponenteClass> oc;
                _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoProdutoComponenteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoProdutoComponenteClass>();
                }
                else{ 
                   Entidades.OrdemProducaoProdutoComponenteClass search = new Entidades.OrdemProducaoProdutoComponenteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoProdutoComponenteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoProdutoComponenteClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducao = new BindingList<Entidades.OrdemProducaoProdutoComponenteClass>(oc); 
                 _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoProdutoComponenteClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoProdutoComponenteClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoRecursoClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoRecursoClassOrdemProducaoChanged = true;
                  _valueCollectionOrdemProducaoRecursoClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoRecursoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoRecursoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoRecursoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoRecursoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoRecursoClassOrdemProducaoChanged = true; 
                  _valueCollectionOrdemProducaoRecursoClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoRecursoClass item in _valueCollectionOrdemProducaoRecursoClassOrdemProducao) 
                 { 
                     _collectionOrdemProducaoRecursoClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoRecursoClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoRecursoClass> oc;
                _valueCollectionOrdemProducaoRecursoClassOrdemProducaoChanged = false;
                 _valueCollectionOrdemProducaoRecursoClassOrdemProducaoCommitedChanged = false;
                _collectionOrdemProducaoRecursoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoRecursoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoRecursoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoRecursoClass search = new Entidades.OrdemProducaoRecursoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoRecursoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.OrdemProducaoRecursoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoRecursoClassOrdemProducao = new BindingList<Entidades.OrdemProducaoRecursoClass>(oc); 
                 _collectionOrdemProducaoRecursoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoRecursoClassOrdemProducao select a.ID).ToList();
                 _valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoRecursoClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoRecursoClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemOpClassOrdemProducaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemOpClassOrdemProducaoChanged = true;
                  _valueCollectionPlanoCorteItemOpClassOrdemProducaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemOpClassOrdemProducaoChanged = true; 
                  _valueCollectionPlanoCorteItemOpClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemOpClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemOpClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemOpClassOrdemProducaoChanged = true; 
                  _valueCollectionPlanoCorteItemOpClassOrdemProducaoCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemOpClass item in _valueCollectionPlanoCorteItemOpClassOrdemProducao) 
                 { 
                     _collectionPlanoCorteItemOpClassOrdemProducaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemOpClassOrdemProducao()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemOpClass> oc;
                _valueCollectionPlanoCorteItemOpClassOrdemProducaoChanged = false;
                 _valueCollectionPlanoCorteItemOpClassOrdemProducaoCommitedChanged = false;
                _collectionPlanoCorteItemOpClassOrdemProducaoRemovidos = new List<Entidades.PlanoCorteItemOpClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemOpClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemOpClass search = new Entidades.PlanoCorteItemOpClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemOpClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducao", this),                     }                       ).Cast<Entidades.PlanoCorteItemOpClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemOpClassOrdemProducao = new BindingList<Entidades.PlanoCorteItemOpClass>(oc); 
                 _collectionPlanoCorteItemOpClassOrdemProducaoOriginal= (from a in _valueCollectionPlanoCorteItemOpClassOrdemProducao select a.ID).ToList();
                 _valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemOpClassOrdemProducaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemOpClassOrdemProducao+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueProduto == null)
                {
                    throw new Exception(ErroProdutoObrigatorio);
                }
                if ( _valueOrdemProducaoGrupo == null)
                {
                    throw new Exception(ErroOrdemProducaoGrupoObrigatorio);
                }
                if ( _valueAcsUsuario == null)
                {
                    throw new Exception(ErroAcsUsuarioObrigatorio);
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
                    "  public.ordem_producao  " +
                    "WHERE " +
                    "  id_ordem_producao = :id";
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
                        "  public.ordem_producao   " +
                        "SET  " + 
                        "  orp_quantidade = :orp_quantidade, " + 
                        "  orp_data = :orp_data, " + 
                        "  orp_situacao = :orp_situacao, " + 
                        "  orp_produto_descricao = :orp_produto_descricao, " + 
                        "  orp_tipo_documento = :orp_tipo_documento, " + 
                        "  orp_numero_documento = :orp_numero_documento, " + 
                        "  orp_revisao_documento = :orp_revisao_documento, " + 
                        "  orp_cliente_nao_usar = :orp_cliente_nao_usar, " + 
                        "  orp_dimensao = :orp_dimensao, " + 
                        "  id_produto = :id_produto, " + 
                        "  orp_produto_codigo = :orp_produto_codigo, " + 
                        "  orp_quantidade_estoque = :orp_quantidade_estoque, " + 
                        "  orp_quantidade_pedido = :orp_quantidade_pedido, " + 
                        "  orp_pendencia = :orp_pendencia, " + 
                        "  orp_suspensa = :orp_suspensa, " + 
                        "  orp_qtd_maior_verificada = :orp_qtd_maior_verificada, " + 
                        "  id_ordem_producao_grupo = :id_ordem_producao_grupo, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  orp_data_reimpressao = :orp_data_reimpressao, " + 
                        "  id_acs_usuario_reimpressao = :id_acs_usuario_reimpressao, " + 
                        "  id_acs_usuario_impressao = :id_acs_usuario_impressao, " + 
                        "  orp_data_impressao = :orp_data_impressao, " + 
                        "  orp_agrupador_op = :orp_agrupador_op, " + 
                        "  id_acs_usuario_encerramento = :id_acs_usuario_encerramento, " + 
                        "  orp_data_encerramento = :orp_data_encerramento, " + 
                        "  orp_versao_estrutura_produto = :orp_versao_estrutura_produto, " + 
                        "  orp_rastreamento_material = :orp_rastreamento_material, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  orp_quantidade_extra = :orp_quantidade_extra, " + 
                        "  id_estoque_gaveta = :id_estoque_gaveta, " + 
                        "  orp_imprime_relacionadas = :orp_imprime_relacionadas, " + 
                        "  id_produto_k = :id_produto_k, " + 
                        "  id_acs_usuario_liberacao_qualidade = :id_acs_usuario_liberacao_qualidade, " + 
                        "  orp_observacao_liberacao_qualidade = :orp_observacao_liberacao_qualidade, " + 
                        "  orp_quantidade_final = :orp_quantidade_final, " + 
                        "  orp_pendencia_de_quantidade = :orp_pendencia_de_quantidade "+
                        "WHERE  " +
                        "  id_ordem_producao = :id " +
                        "RETURNING id_ordem_producao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao " +
                        "( " +
                        "  orp_quantidade , " + 
                        "  orp_data , " + 
                        "  orp_situacao , " + 
                        "  orp_produto_descricao , " + 
                        "  orp_tipo_documento , " + 
                        "  orp_numero_documento , " + 
                        "  orp_revisao_documento , " + 
                        "  orp_cliente_nao_usar , " + 
                        "  orp_dimensao , " + 
                        "  id_produto , " + 
                        "  orp_produto_codigo , " + 
                        "  orp_quantidade_estoque , " + 
                        "  orp_quantidade_pedido , " + 
                        "  orp_pendencia , " + 
                        "  orp_suspensa , " + 
                        "  orp_qtd_maior_verificada , " + 
                        "  id_ordem_producao_grupo , " + 
                        "  id_acs_usuario , " + 
                        "  orp_data_reimpressao , " + 
                        "  id_acs_usuario_reimpressao , " + 
                        "  id_acs_usuario_impressao , " + 
                        "  orp_data_impressao , " + 
                        "  orp_agrupador_op , " + 
                        "  id_acs_usuario_encerramento , " + 
                        "  orp_data_encerramento , " + 
                        "  orp_versao_estrutura_produto , " + 
                        "  orp_rastreamento_material , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  orp_quantidade_extra , " + 
                        "  id_estoque_gaveta , " + 
                        "  orp_imprime_relacionadas , " + 
                        "  id_produto_k , " + 
                        "  id_acs_usuario_liberacao_qualidade , " + 
                        "  orp_observacao_liberacao_qualidade , " + 
                        "  orp_quantidade_final , " + 
                        "  orp_pendencia_de_quantidade  "+
                        ")  " +
                        "VALUES ( " +
                        "  :orp_quantidade , " + 
                        "  :orp_data , " + 
                        "  :orp_situacao , " + 
                        "  :orp_produto_descricao , " + 
                        "  :orp_tipo_documento , " + 
                        "  :orp_numero_documento , " + 
                        "  :orp_revisao_documento , " + 
                        "  :orp_cliente_nao_usar , " + 
                        "  :orp_dimensao , " + 
                        "  :id_produto , " + 
                        "  :orp_produto_codigo , " + 
                        "  :orp_quantidade_estoque , " + 
                        "  :orp_quantidade_pedido , " + 
                        "  :orp_pendencia , " + 
                        "  :orp_suspensa , " + 
                        "  :orp_qtd_maior_verificada , " + 
                        "  :id_ordem_producao_grupo , " + 
                        "  :id_acs_usuario , " + 
                        "  :orp_data_reimpressao , " + 
                        "  :id_acs_usuario_reimpressao , " + 
                        "  :id_acs_usuario_impressao , " + 
                        "  :orp_data_impressao , " + 
                        "  :orp_agrupador_op , " + 
                        "  :id_acs_usuario_encerramento , " + 
                        "  :orp_data_encerramento , " + 
                        "  :orp_versao_estrutura_produto , " + 
                        "  :orp_rastreamento_material , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :orp_quantidade_extra , " + 
                        "  :id_estoque_gaveta , " + 
                        "  :orp_imprime_relacionadas , " + 
                        "  :id_produto_k , " + 
                        "  :id_acs_usuario_liberacao_qualidade , " + 
                        "  :orp_observacao_liberacao_qualidade , " + 
                        "  :orp_quantidade_final , " + 
                        "  :orp_pendencia_de_quantidade  "+
                        ")RETURNING id_ordem_producao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Situacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_produto_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoDescricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_tipo_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_numero_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_revisao_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RevisaoDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_cliente_nao_usar", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ClienteNaoUsar ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_dimensao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Dimensao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_produto_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoCodigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade_estoque", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeEstoque ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade_pedido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadePedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_pendencia", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pendencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_suspensa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Suspensa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_qtd_maior_verificada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdMaiorVerificada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_grupo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducaoGrupo==null ? (object) DBNull.Value : this.OrdemProducaoGrupo.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_data_reimpressao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataReimpressao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_reimpressao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioReimpressao==null ? (object) DBNull.Value : this.AcsUsuarioReimpressao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_impressao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioImpressao==null ? (object) DBNull.Value : this.AcsUsuarioImpressao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_data_impressao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataImpressao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_agrupador_op", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AgrupadorOp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_encerramento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioEncerramento==null ? (object) DBNull.Value : this.AcsUsuarioEncerramento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_data_encerramento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEncerramento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_versao_estrutura_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoEstruturaProduto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_rastreamento_material", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RastreamentoMaterial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade_extra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeExtra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstoqueGaveta==null ? (object) DBNull.Value : this.EstoqueGaveta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_imprime_relacionadas", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImprimeRelacionadas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ProdutoK==null ? (object) DBNull.Value : this.ProdutoK.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_liberacao_qualidade", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioLiberacaoQualidade==null ? (object) DBNull.Value : this.AcsUsuarioLiberacaoQualidade.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_observacao_liberacao_qualidade", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacaoLiberacaoQualidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade_final", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeFinal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_pendencia_de_quantidade", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PendenciaDeQuantidade ?? DBNull.Value;

 
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
 if (CollectionOrdemProducaoDiferencaClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoDiferencaClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoDiferencaClass tmp in CollectionOrdemProducaoDiferencaClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoDocumentoOpClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoDocumentoOpClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoDocumentoOpClass tmp in CollectionOrdemProducaoDocumentoOpClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoEnvioTerceirosClass tmp in CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass tmp in CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEstoqueClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEstoqueClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoEstoqueClass tmp in CollectionOrdemProducaoEstoqueClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoHistoricoClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoHistoricoClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoHistoricoClass tmp in CollectionOrdemProducaoHistoricoClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoMaterialClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoMaterialClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoMaterialClass tmp in CollectionOrdemProducaoMaterialClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoPedidoClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoPedidoClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoPedidoClass tmp in CollectionOrdemProducaoPedidoClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoPostoTrabalhoClass tmp in CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoProdutoComponenteClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoProdutoComponenteClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoProdutoComponenteClass tmp in CollectionOrdemProducaoProdutoComponenteClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoRecursoClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoRecursoClassOrdemProducao+"\r\n";
                foreach (Entidades.OrdemProducaoRecursoClass tmp in CollectionOrdemProducaoRecursoClassOrdemProducao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemOpClassOrdemProducao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemOpClassOrdemProducao+"\r\n";
                foreach (Entidades.PlanoCorteItemOpClass tmp in CollectionPlanoCorteItemOpClassOrdemProducao)
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
        public static OrdemProducaoClass CopiarEntidade(OrdemProducaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoClass toRet = new OrdemProducaoClass(usuario,conn);
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.Data= entidadeCopiar.Data;
 toRet.Situacao= entidadeCopiar.Situacao;
 toRet.ProdutoDescricao= entidadeCopiar.ProdutoDescricao;
 toRet.TipoDocumento= entidadeCopiar.TipoDocumento;
 toRet.NumeroDocumento= entidadeCopiar.NumeroDocumento;
 toRet.RevisaoDocumento= entidadeCopiar.RevisaoDocumento;
 toRet.ClienteNaoUsar= entidadeCopiar.ClienteNaoUsar;
 toRet.Dimensao= entidadeCopiar.Dimensao;
 toRet.Produto= entidadeCopiar.Produto;
 toRet.ProdutoCodigo= entidadeCopiar.ProdutoCodigo;
 toRet.QuantidadeEstoque= entidadeCopiar.QuantidadeEstoque;
 toRet.QuantidadePedido= entidadeCopiar.QuantidadePedido;
 toRet.Pendencia= entidadeCopiar.Pendencia;
 toRet.Suspensa= entidadeCopiar.Suspensa;
 toRet.QtdMaiorVerificada= entidadeCopiar.QtdMaiorVerificada;
 toRet.OrdemProducaoGrupo= entidadeCopiar.OrdemProducaoGrupo;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.DataReimpressao= entidadeCopiar.DataReimpressao;
 toRet.AcsUsuarioReimpressao= entidadeCopiar.AcsUsuarioReimpressao;
 toRet.AcsUsuarioImpressao= entidadeCopiar.AcsUsuarioImpressao;
 toRet.DataImpressao= entidadeCopiar.DataImpressao;
 toRet.AgrupadorOp= entidadeCopiar.AgrupadorOp;
 toRet.AcsUsuarioEncerramento= entidadeCopiar.AcsUsuarioEncerramento;
 toRet.DataEncerramento= entidadeCopiar.DataEncerramento;
 toRet.VersaoEstruturaProduto= entidadeCopiar.VersaoEstruturaProduto;
 toRet.RastreamentoMaterial= entidadeCopiar.RastreamentoMaterial;
 toRet.QuantidadeExtra= entidadeCopiar.QuantidadeExtra;
 toRet.EstoqueGaveta= entidadeCopiar.EstoqueGaveta;
 toRet.ImprimeRelacionadas= entidadeCopiar.ImprimeRelacionadas;
 toRet.ProdutoK= entidadeCopiar.ProdutoK;
 toRet.AcsUsuarioLiberacaoQualidade= entidadeCopiar.AcsUsuarioLiberacaoQualidade;
 toRet.ObservacaoLiberacaoQualidade= entidadeCopiar.ObservacaoLiberacaoQualidade;
 toRet.QuantidadeFinal= entidadeCopiar.QuantidadeFinal;
 toRet.PendenciaDeQuantidade= entidadeCopiar.PendenciaDeQuantidade;

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
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _situacaoOriginal = Situacao;
       _situacaoOriginalCommited = _situacaoOriginal;
       _produtoDescricaoOriginal = ProdutoDescricao;
       _produtoDescricaoOriginalCommited = _produtoDescricaoOriginal;
       _tipoDocumentoOriginal = TipoDocumento;
       _tipoDocumentoOriginalCommited = _tipoDocumentoOriginal;
       _numeroDocumentoOriginal = NumeroDocumento;
       _numeroDocumentoOriginalCommited = _numeroDocumentoOriginal;
       _revisaoDocumentoOriginal = RevisaoDocumento;
       _revisaoDocumentoOriginalCommited = _revisaoDocumentoOriginal;
       _clienteNaoUsarOriginal = ClienteNaoUsar;
       _clienteNaoUsarOriginalCommited = _clienteNaoUsarOriginal;
       _dimensaoOriginal = Dimensao;
       _dimensaoOriginalCommited = _dimensaoOriginal;
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _produtoCodigoOriginal = ProdutoCodigo;
       _produtoCodigoOriginalCommited = _produtoCodigoOriginal;
       _quantidadeEstoqueOriginal = QuantidadeEstoque;
       _quantidadeEstoqueOriginalCommited = _quantidadeEstoqueOriginal;
       _quantidadePedidoOriginal = QuantidadePedido;
       _quantidadePedidoOriginalCommited = _quantidadePedidoOriginal;
       _pendenciaOriginal = Pendencia;
       _pendenciaOriginalCommited = _pendenciaOriginal;
       _suspensaOriginal = Suspensa;
       _suspensaOriginalCommited = _suspensaOriginal;
       _qtdMaiorVerificadaOriginal = QtdMaiorVerificada;
       _qtdMaiorVerificadaOriginalCommited = _qtdMaiorVerificadaOriginal;
       _ordemProducaoGrupoOriginal = OrdemProducaoGrupo;
       _ordemProducaoGrupoOriginalCommited = _ordemProducaoGrupoOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _dataReimpressaoOriginal = DataReimpressao;
       _dataReimpressaoOriginalCommited = _dataReimpressaoOriginal;
       _acsUsuarioReimpressaoOriginal = AcsUsuarioReimpressao;
       _acsUsuarioReimpressaoOriginalCommited = _acsUsuarioReimpressaoOriginal;
       _acsUsuarioImpressaoOriginal = AcsUsuarioImpressao;
       _acsUsuarioImpressaoOriginalCommited = _acsUsuarioImpressaoOriginal;
       _dataImpressaoOriginal = DataImpressao;
       _dataImpressaoOriginalCommited = _dataImpressaoOriginal;
       _agrupadorOpOriginal = AgrupadorOp;
       _agrupadorOpOriginalCommited = _agrupadorOpOriginal;
       _acsUsuarioEncerramentoOriginal = AcsUsuarioEncerramento;
       _acsUsuarioEncerramentoOriginalCommited = _acsUsuarioEncerramentoOriginal;
       _dataEncerramentoOriginal = DataEncerramento;
       _dataEncerramentoOriginalCommited = _dataEncerramentoOriginal;
       _versaoEstruturaProdutoOriginal = VersaoEstruturaProduto;
       _versaoEstruturaProdutoOriginalCommited = _versaoEstruturaProdutoOriginal;
       _rastreamentoMaterialOriginal = RastreamentoMaterial;
       _rastreamentoMaterialOriginalCommited = _rastreamentoMaterialOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _quantidadeExtraOriginal = QuantidadeExtra;
       _quantidadeExtraOriginalCommited = _quantidadeExtraOriginal;
       _estoqueGavetaOriginal = EstoqueGaveta;
       _estoqueGavetaOriginalCommited = _estoqueGavetaOriginal;
       _imprimeRelacionadasOriginal = ImprimeRelacionadas;
       _imprimeRelacionadasOriginalCommited = _imprimeRelacionadasOriginal;
       _produtoKOriginal = ProdutoK;
       _produtoKOriginalCommited = _produtoKOriginal;
       _acsUsuarioLiberacaoQualidadeOriginal = AcsUsuarioLiberacaoQualidade;
       _acsUsuarioLiberacaoQualidadeOriginalCommited = _acsUsuarioLiberacaoQualidadeOriginal;
       _observacaoLiberacaoQualidadeOriginal = ObservacaoLiberacaoQualidade;
       _observacaoLiberacaoQualidadeOriginalCommited = _observacaoLiberacaoQualidadeOriginal;
       _quantidadeFinalOriginal = QuantidadeFinal;
       _quantidadeFinalOriginalCommited = _quantidadeFinalOriginal;
       _pendenciaDeQuantidadeOriginal = PendenciaDeQuantidade;
       _pendenciaDeQuantidadeOriginalCommited = _pendenciaDeQuantidadeOriginal;

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
       _quantidadeOriginalCommited = Quantidade;
       _dataOriginalCommited = Data;
       _situacaoOriginalCommited = Situacao;
       _produtoDescricaoOriginalCommited = ProdutoDescricao;
       _tipoDocumentoOriginalCommited = TipoDocumento;
       _numeroDocumentoOriginalCommited = NumeroDocumento;
       _revisaoDocumentoOriginalCommited = RevisaoDocumento;
       _clienteNaoUsarOriginalCommited = ClienteNaoUsar;
       _dimensaoOriginalCommited = Dimensao;
       _produtoOriginalCommited = Produto;
       _produtoCodigoOriginalCommited = ProdutoCodigo;
       _quantidadeEstoqueOriginalCommited = QuantidadeEstoque;
       _quantidadePedidoOriginalCommited = QuantidadePedido;
       _pendenciaOriginalCommited = Pendencia;
       _suspensaOriginalCommited = Suspensa;
       _qtdMaiorVerificadaOriginalCommited = QtdMaiorVerificada;
       _ordemProducaoGrupoOriginalCommited = OrdemProducaoGrupo;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _dataReimpressaoOriginalCommited = DataReimpressao;
       _acsUsuarioReimpressaoOriginalCommited = AcsUsuarioReimpressao;
       _acsUsuarioImpressaoOriginalCommited = AcsUsuarioImpressao;
       _dataImpressaoOriginalCommited = DataImpressao;
       _agrupadorOpOriginalCommited = AgrupadorOp;
       _acsUsuarioEncerramentoOriginalCommited = AcsUsuarioEncerramento;
       _dataEncerramentoOriginalCommited = DataEncerramento;
       _versaoEstruturaProdutoOriginalCommited = VersaoEstruturaProduto;
       _rastreamentoMaterialOriginalCommited = RastreamentoMaterial;
       _versionOriginalCommited = Version;
       _quantidadeExtraOriginalCommited = QuantidadeExtra;
       _estoqueGavetaOriginalCommited = EstoqueGaveta;
       _imprimeRelacionadasOriginalCommited = ImprimeRelacionadas;
       _produtoKOriginalCommited = ProdutoK;
       _acsUsuarioLiberacaoQualidadeOriginalCommited = AcsUsuarioLiberacaoQualidade;
       _observacaoLiberacaoQualidadeOriginalCommited = ObservacaoLiberacaoQualidade;
       _quantidadeFinalOriginalCommited = QuantidadeFinal;
       _pendenciaDeQuantidadeOriginalCommited = PendenciaDeQuantidade;

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
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoDiferencaClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoDiferencaClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoDiferencaClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoDiferencaClass>();
                  }
                  _collectionOrdemProducaoDiferencaClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoDiferencaClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoDocumentoOpClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoDocumentoOpClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoDocumentoOpClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoDocumentoOpClass>();
                  }
                  _collectionOrdemProducaoDocumentoOpClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass>();
                  }
                  _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoEstoqueClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoEstoqueClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEstoqueClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoEstoqueClass>();
                  }
                  _collectionOrdemProducaoEstoqueClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoEstoqueClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoEstoqueClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoHistoricoClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoHistoricoClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoHistoricoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoHistoricoClass>();
                  }
                  _collectionOrdemProducaoHistoricoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoHistoricoClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoHistoricoClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoMaterialClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoMaterialClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoMaterialClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoMaterialClass>();
                  }
                  _collectionOrdemProducaoMaterialClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoMaterialClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoMaterialClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoMaterialClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoPedidoClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoPedidoClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoPedidoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoPedidoClass>();
                  }
                  _collectionOrdemProducaoPedidoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoPedidoClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoPedidoClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoPedidoClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoClass>();
                  }
                  _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoProdutoComponenteClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoProdutoComponenteClass>();
                  }
                  _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded) 
               {
                  if (_collectionOrdemProducaoRecursoClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoRecursoClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoRecursoClassOrdemProducaoRemovidos = new List<Entidades.OrdemProducaoRecursoClass>();
                  }
                  _collectionOrdemProducaoRecursoClassOrdemProducaoOriginal= (from a in _valueCollectionOrdemProducaoRecursoClassOrdemProducao select a.ID).ToList();
                  _valueCollectionOrdemProducaoRecursoClassOrdemProducaoChanged = false;
                  _valueCollectionOrdemProducaoRecursoClassOrdemProducaoCommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded) 
               {
                  if (_collectionPlanoCorteItemOpClassOrdemProducaoRemovidos != null) 
                  {
                     _collectionPlanoCorteItemOpClassOrdemProducaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemOpClassOrdemProducaoRemovidos = new List<Entidades.PlanoCorteItemOpClass>();
                  }
                  _collectionPlanoCorteItemOpClassOrdemProducaoOriginal= (from a in _valueCollectionPlanoCorteItemOpClassOrdemProducao select a.ID).ToList();
                  _valueCollectionPlanoCorteItemOpClassOrdemProducaoChanged = false;
                  _valueCollectionPlanoCorteItemOpClassOrdemProducaoCommitedChanged = false;
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
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               ProdutoDescricao=_produtoDescricaoOriginal;
               _produtoDescricaoOriginalCommited=_produtoDescricaoOriginal;
               TipoDocumento=_tipoDocumentoOriginal;
               _tipoDocumentoOriginalCommited=_tipoDocumentoOriginal;
               NumeroDocumento=_numeroDocumentoOriginal;
               _numeroDocumentoOriginalCommited=_numeroDocumentoOriginal;
               RevisaoDocumento=_revisaoDocumentoOriginal;
               _revisaoDocumentoOriginalCommited=_revisaoDocumentoOriginal;
               ClienteNaoUsar=_clienteNaoUsarOriginal;
               _clienteNaoUsarOriginalCommited=_clienteNaoUsarOriginal;
               Dimensao=_dimensaoOriginal;
               _dimensaoOriginalCommited=_dimensaoOriginal;
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               ProdutoCodigo=_produtoCodigoOriginal;
               _produtoCodigoOriginalCommited=_produtoCodigoOriginal;
               QuantidadeEstoque=_quantidadeEstoqueOriginal;
               _quantidadeEstoqueOriginalCommited=_quantidadeEstoqueOriginal;
               QuantidadePedido=_quantidadePedidoOriginal;
               _quantidadePedidoOriginalCommited=_quantidadePedidoOriginal;
               Pendencia=_pendenciaOriginal;
               _pendenciaOriginalCommited=_pendenciaOriginal;
               Suspensa=_suspensaOriginal;
               _suspensaOriginalCommited=_suspensaOriginal;
               QtdMaiorVerificada=_qtdMaiorVerificadaOriginal;
               _qtdMaiorVerificadaOriginalCommited=_qtdMaiorVerificadaOriginal;
               OrdemProducaoGrupo=_ordemProducaoGrupoOriginal;
               _ordemProducaoGrupoOriginalCommited=_ordemProducaoGrupoOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               DataReimpressao=_dataReimpressaoOriginal;
               _dataReimpressaoOriginalCommited=_dataReimpressaoOriginal;
               AcsUsuarioReimpressao=_acsUsuarioReimpressaoOriginal;
               _acsUsuarioReimpressaoOriginalCommited=_acsUsuarioReimpressaoOriginal;
               AcsUsuarioImpressao=_acsUsuarioImpressaoOriginal;
               _acsUsuarioImpressaoOriginalCommited=_acsUsuarioImpressaoOriginal;
               DataImpressao=_dataImpressaoOriginal;
               _dataImpressaoOriginalCommited=_dataImpressaoOriginal;
               AgrupadorOp=_agrupadorOpOriginal;
               _agrupadorOpOriginalCommited=_agrupadorOpOriginal;
               AcsUsuarioEncerramento=_acsUsuarioEncerramentoOriginal;
               _acsUsuarioEncerramentoOriginalCommited=_acsUsuarioEncerramentoOriginal;
               DataEncerramento=_dataEncerramentoOriginal;
               _dataEncerramentoOriginalCommited=_dataEncerramentoOriginal;
               VersaoEstruturaProduto=_versaoEstruturaProdutoOriginal;
               _versaoEstruturaProdutoOriginalCommited=_versaoEstruturaProdutoOriginal;
               RastreamentoMaterial=_rastreamentoMaterialOriginal;
               _rastreamentoMaterialOriginalCommited=_rastreamentoMaterialOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               QuantidadeExtra=_quantidadeExtraOriginal;
               _quantidadeExtraOriginalCommited=_quantidadeExtraOriginal;
               EstoqueGaveta=_estoqueGavetaOriginal;
               _estoqueGavetaOriginalCommited=_estoqueGavetaOriginal;
               ImprimeRelacionadas=_imprimeRelacionadasOriginal;
               _imprimeRelacionadasOriginalCommited=_imprimeRelacionadasOriginal;
               ProdutoK=_produtoKOriginal;
               _produtoKOriginalCommited=_produtoKOriginal;
               AcsUsuarioLiberacaoQualidade=_acsUsuarioLiberacaoQualidadeOriginal;
               _acsUsuarioLiberacaoQualidadeOriginalCommited=_acsUsuarioLiberacaoQualidadeOriginal;
               ObservacaoLiberacaoQualidade=_observacaoLiberacaoQualidadeOriginal;
               _observacaoLiberacaoQualidadeOriginalCommited=_observacaoLiberacaoQualidadeOriginal;
               QuantidadeFinal=_quantidadeFinalOriginal;
               _quantidadeFinalOriginalCommited=_quantidadeFinalOriginal;
               PendenciaDeQuantidade=_pendenciaDeQuantidadeOriginal;
               _pendenciaDeQuantidadeOriginalCommited=_pendenciaDeQuantidadeOriginal;
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoDiferencaClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoDiferencaClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoDiferencaClassOrdemProducao.Add(Entidades.OrdemProducaoDiferencaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoDiferencaClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoDocumentoOpClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoDocumentoOpClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoDocumentoOpClassOrdemProducao.Add(Entidades.OrdemProducaoDocumentoOpClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoDocumentoOpClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao.Add(Entidades.OrdemProducaoEnvioTerceirosClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao.Add(Entidades.OrdemProducaoEnvioTerceirosCancelamentoSaldoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoEstoqueClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoEstoqueClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoEstoqueClassOrdemProducao.Add(Entidades.OrdemProducaoEstoqueClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEstoqueClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoHistoricoClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoHistoricoClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoHistoricoClassOrdemProducao.Add(Entidades.OrdemProducaoHistoricoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoHistoricoClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoMaterialClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoMaterialClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoMaterialClassOrdemProducao.Add(Entidades.OrdemProducaoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoMaterialClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoPedidoClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoPedidoClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoPedidoClassOrdemProducao.Add(Entidades.OrdemProducaoPedidoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoPedidoClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao.Add(Entidades.OrdemProducaoPostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoPostoTrabalhoClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoProdutoComponenteClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoProdutoComponenteClassOrdemProducao.Add(Entidades.OrdemProducaoProdutoComponenteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoProdutoComponenteClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded) 
               {
                  CollectionOrdemProducaoRecursoClassOrdemProducao.Clear();
                  foreach(int item in _collectionOrdemProducaoRecursoClassOrdemProducaoOriginal)
                  {
                    CollectionOrdemProducaoRecursoClassOrdemProducao.Add(Entidades.OrdemProducaoRecursoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoRecursoClassOrdemProducaoRemovidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded) 
               {
                  CollectionPlanoCorteItemOpClassOrdemProducao.Clear();
                  foreach(int item in _collectionPlanoCorteItemOpClassOrdemProducaoOriginal)
                  {
                    CollectionPlanoCorteItemOpClassOrdemProducao.Add(Entidades.PlanoCorteItemOpClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemOpClassOrdemProducaoRemovidos.Clear();
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
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDiferencaClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoOpClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEstoqueClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoHistoricoClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoMaterialClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPedidoClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoProdutoComponenteClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoRecursoClassOrdemProducao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemOpClassOrdemProducao.Any(item => item.IsDirty());
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
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _dataOriginal != Data;
      if (dirty) return true;
       dirty = _situacaoOriginal != Situacao;
      if (dirty) return true;
       dirty = _produtoDescricaoOriginal != ProdutoDescricao;
      if (dirty) return true;
       dirty = _tipoDocumentoOriginal != TipoDocumento;
      if (dirty) return true;
       dirty = _numeroDocumentoOriginal != NumeroDocumento;
      if (dirty) return true;
       dirty = _revisaoDocumentoOriginal != RevisaoDocumento;
      if (dirty) return true;
       dirty = _clienteNaoUsarOriginal != ClienteNaoUsar;
      if (dirty) return true;
       dirty = _dimensaoOriginal != Dimensao;
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
       dirty = _produtoCodigoOriginal != ProdutoCodigo;
      if (dirty) return true;
       dirty = _quantidadeEstoqueOriginal != QuantidadeEstoque;
      if (dirty) return true;
       dirty = _quantidadePedidoOriginal != QuantidadePedido;
      if (dirty) return true;
       dirty = _pendenciaOriginal != Pendencia;
      if (dirty) return true;
       dirty = _suspensaOriginal != Suspensa;
      if (dirty) return true;
       dirty = _qtdMaiorVerificadaOriginal != QtdMaiorVerificada;
      if (dirty) return true;
       if (_ordemProducaoGrupoOriginal!=null)
       {
          dirty = !_ordemProducaoGrupoOriginal.Equals(OrdemProducaoGrupo);
       }
       else
       {
            dirty = OrdemProducaoGrupo != null;
       }
      if (dirty) return true;
       if (_acsUsuarioOriginal!=null)
       {
          dirty = !_acsUsuarioOriginal.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataReimpressaoOriginal != DataReimpressao;
      if (dirty) return true;
       if (_acsUsuarioReimpressaoOriginal!=null)
       {
          dirty = !_acsUsuarioReimpressaoOriginal.Equals(AcsUsuarioReimpressao);
       }
       else
       {
            dirty = AcsUsuarioReimpressao != null;
       }
      if (dirty) return true;
       if (_acsUsuarioImpressaoOriginal!=null)
       {
          dirty = !_acsUsuarioImpressaoOriginal.Equals(AcsUsuarioImpressao);
       }
       else
       {
            dirty = AcsUsuarioImpressao != null;
       }
      if (dirty) return true;
       dirty = _dataImpressaoOriginal != DataImpressao;
      if (dirty) return true;
       dirty = _agrupadorOpOriginal != AgrupadorOp;
      if (dirty) return true;
       if (_acsUsuarioEncerramentoOriginal!=null)
       {
          dirty = !_acsUsuarioEncerramentoOriginal.Equals(AcsUsuarioEncerramento);
       }
       else
       {
            dirty = AcsUsuarioEncerramento != null;
       }
      if (dirty) return true;
       dirty = _dataEncerramentoOriginal != DataEncerramento;
      if (dirty) return true;
       dirty = _versaoEstruturaProdutoOriginal != VersaoEstruturaProduto;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginal != RastreamentoMaterial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _quantidadeExtraOriginal != QuantidadeExtra;
      if (dirty) return true;
       if (_estoqueGavetaOriginal!=null)
       {
          dirty = !_estoqueGavetaOriginal.Equals(EstoqueGaveta);
       }
       else
       {
            dirty = EstoqueGaveta != null;
       }
      if (dirty) return true;
       dirty = _imprimeRelacionadasOriginal != ImprimeRelacionadas;
      if (dirty) return true;
       if (_produtoKOriginal!=null)
       {
          dirty = !_produtoKOriginal.Equals(ProdutoK);
       }
       else
       {
            dirty = ProdutoK != null;
       }
      if (dirty) return true;
       if (_acsUsuarioLiberacaoQualidadeOriginal!=null)
       {
          dirty = !_acsUsuarioLiberacaoQualidadeOriginal.Equals(AcsUsuarioLiberacaoQualidade);
       }
       else
       {
            dirty = AcsUsuarioLiberacaoQualidade != null;
       }
      if (dirty) return true;
       dirty = _observacaoLiberacaoQualidadeOriginal != ObservacaoLiberacaoQualidade;
      if (dirty) return true;
       dirty = _quantidadeFinalOriginal != QuantidadeFinal;
      if (dirty) return true;
       dirty = _pendenciaDeQuantidadeOriginal != PendenciaDeQuantidade;

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
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDiferencaClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoOpClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEstoqueClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoHistoricoClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoMaterialClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPedidoClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoProdutoComponenteClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoRecursoClassOrdemProducao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemOpClassOrdemProducao.Any(item => item.IsDirtyCommited());
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
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
       dirty = _situacaoOriginalCommited != Situacao;
      if (dirty) return true;
       dirty = _produtoDescricaoOriginalCommited != ProdutoDescricao;
      if (dirty) return true;
       dirty = _tipoDocumentoOriginalCommited != TipoDocumento;
      if (dirty) return true;
       dirty = _numeroDocumentoOriginalCommited != NumeroDocumento;
      if (dirty) return true;
       dirty = _revisaoDocumentoOriginalCommited != RevisaoDocumento;
      if (dirty) return true;
       dirty = _clienteNaoUsarOriginalCommited != ClienteNaoUsar;
      if (dirty) return true;
       dirty = _dimensaoOriginalCommited != Dimensao;
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
       dirty = _produtoCodigoOriginalCommited != ProdutoCodigo;
      if (dirty) return true;
       dirty = _quantidadeEstoqueOriginalCommited != QuantidadeEstoque;
      if (dirty) return true;
       dirty = _quantidadePedidoOriginalCommited != QuantidadePedido;
      if (dirty) return true;
       dirty = _pendenciaOriginalCommited != Pendencia;
      if (dirty) return true;
       dirty = _suspensaOriginalCommited != Suspensa;
      if (dirty) return true;
       dirty = _qtdMaiorVerificadaOriginalCommited != QtdMaiorVerificada;
      if (dirty) return true;
       if (_ordemProducaoGrupoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoGrupoOriginalCommited.Equals(OrdemProducaoGrupo);
       }
       else
       {
            dirty = OrdemProducaoGrupo != null;
       }
      if (dirty) return true;
       if (_acsUsuarioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioOriginalCommited.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataReimpressaoOriginalCommited != DataReimpressao;
      if (dirty) return true;
       if (_acsUsuarioReimpressaoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioReimpressaoOriginalCommited.Equals(AcsUsuarioReimpressao);
       }
       else
       {
            dirty = AcsUsuarioReimpressao != null;
       }
      if (dirty) return true;
       if (_acsUsuarioImpressaoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioImpressaoOriginalCommited.Equals(AcsUsuarioImpressao);
       }
       else
       {
            dirty = AcsUsuarioImpressao != null;
       }
      if (dirty) return true;
       dirty = _dataImpressaoOriginalCommited != DataImpressao;
      if (dirty) return true;
       dirty = _agrupadorOpOriginalCommited != AgrupadorOp;
      if (dirty) return true;
       if (_acsUsuarioEncerramentoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioEncerramentoOriginalCommited.Equals(AcsUsuarioEncerramento);
       }
       else
       {
            dirty = AcsUsuarioEncerramento != null;
       }
      if (dirty) return true;
       dirty = _dataEncerramentoOriginalCommited != DataEncerramento;
      if (dirty) return true;
       dirty = _versaoEstruturaProdutoOriginalCommited != VersaoEstruturaProduto;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginalCommited != RastreamentoMaterial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _quantidadeExtraOriginalCommited != QuantidadeExtra;
      if (dirty) return true;
       if (_estoqueGavetaOriginalCommited!=null)
       {
          dirty = !_estoqueGavetaOriginalCommited.Equals(EstoqueGaveta);
       }
       else
       {
            dirty = EstoqueGaveta != null;
       }
      if (dirty) return true;
       dirty = _imprimeRelacionadasOriginalCommited != ImprimeRelacionadas;
      if (dirty) return true;
       if (_produtoKOriginalCommited!=null)
       {
          dirty = !_produtoKOriginalCommited.Equals(ProdutoK);
       }
       else
       {
            dirty = ProdutoK != null;
       }
      if (dirty) return true;
       if (_acsUsuarioLiberacaoQualidadeOriginalCommited!=null)
       {
          dirty = !_acsUsuarioLiberacaoQualidadeOriginalCommited.Equals(AcsUsuarioLiberacaoQualidade);
       }
       else
       {
            dirty = AcsUsuarioLiberacaoQualidade != null;
       }
      if (dirty) return true;
       dirty = _observacaoLiberacaoQualidadeOriginalCommited != ObservacaoLiberacaoQualidade;
      if (dirty) return true;
       dirty = _quantidadeFinalOriginalCommited != QuantidadeFinal;
      if (dirty) return true;
       dirty = _pendenciaDeQuantidadeOriginalCommited != PendenciaDeQuantidade;

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
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoDiferencaClass item in CollectionOrdemProducaoDiferencaClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoDocumentoOpClass item in CollectionOrdemProducaoDocumentoOpClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosCancelamentoSaldoClass item in CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoEstoqueClass item in CollectionOrdemProducaoEstoqueClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoHistoricoClass item in CollectionOrdemProducaoHistoricoClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoMaterialClass item in CollectionOrdemProducaoMaterialClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoPedidoClass item in CollectionOrdemProducaoPedidoClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoClass item in CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoProdutoComponenteClass item in CollectionOrdemProducaoProdutoComponenteClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoRecursoClass item in CollectionOrdemProducaoRecursoClassOrdemProducao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded) 
               {
                  foreach(PlanoCorteItemOpClass item in CollectionPlanoCorteItemOpClassOrdemProducao)
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
             case "Quantidade":
                return this.Quantidade;
             case "Data":
                return this.Data;
             case "Situacao":
                return this.Situacao;
             case "ProdutoDescricao":
                return this.ProdutoDescricao;
             case "TipoDocumento":
                return this.TipoDocumento;
             case "NumeroDocumento":
                return this.NumeroDocumento;
             case "RevisaoDocumento":
                return this.RevisaoDocumento;
             case "ClienteNaoUsar":
                return this.ClienteNaoUsar;
             case "Dimensao":
                return this.Dimensao;
             case "Produto":
                return this.Produto;
             case "ProdutoCodigo":
                return this.ProdutoCodigo;
             case "QuantidadeEstoque":
                return this.QuantidadeEstoque;
             case "QuantidadePedido":
                return this.QuantidadePedido;
             case "Pendencia":
                return this.Pendencia;
             case "Suspensa":
                return this.Suspensa;
             case "QtdMaiorVerificada":
                return this.QtdMaiorVerificada;
             case "OrdemProducaoGrupo":
                return this.OrdemProducaoGrupo;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "DataReimpressao":
                return this.DataReimpressao;
             case "AcsUsuarioReimpressao":
                return this.AcsUsuarioReimpressao;
             case "AcsUsuarioImpressao":
                return this.AcsUsuarioImpressao;
             case "DataImpressao":
                return this.DataImpressao;
             case "AgrupadorOp":
                return this.AgrupadorOp;
             case "AcsUsuarioEncerramento":
                return this.AcsUsuarioEncerramento;
             case "DataEncerramento":
                return this.DataEncerramento;
             case "VersaoEstruturaProduto":
                return this.VersaoEstruturaProduto;
             case "RastreamentoMaterial":
                return this.RastreamentoMaterial;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "QuantidadeExtra":
                return this.QuantidadeExtra;
             case "EstoqueGaveta":
                return this.EstoqueGaveta;
             case "ImprimeRelacionadas":
                return this.ImprimeRelacionadas;
             case "ProdutoK":
                return this.ProdutoK;
             case "AcsUsuarioLiberacaoQualidade":
                return this.AcsUsuarioLiberacaoQualidade;
             case "ObservacaoLiberacaoQualidade":
                return this.ObservacaoLiberacaoQualidade;
             case "QuantidadeFinal":
                return this.QuantidadeFinal;
             case "PendenciaDeQuantidade":
                return this.PendenciaDeQuantidade;
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
             if (OrdemProducaoGrupo!=null)
                OrdemProducaoGrupo.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
             if (AcsUsuarioReimpressao!=null)
                AcsUsuarioReimpressao.ChangeSingleConnection(newConnection);
             if (AcsUsuarioImpressao!=null)
                AcsUsuarioImpressao.ChangeSingleConnection(newConnection);
             if (AcsUsuarioEncerramento!=null)
                AcsUsuarioEncerramento.ChangeSingleConnection(newConnection);
             if (EstoqueGaveta!=null)
                EstoqueGaveta.ChangeSingleConnection(newConnection);
             if (ProdutoK!=null)
                ProdutoK.ChangeSingleConnection(newConnection);
             if (AcsUsuarioLiberacaoQualidade!=null)
                AcsUsuarioLiberacaoQualidade.ChangeSingleConnection(newConnection);
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoDiferencaClass item in CollectionOrdemProducaoDiferencaClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoOpClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoDocumentoOpClass item in CollectionOrdemProducaoDocumentoOpClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosCancelamentoSaldoClass item in CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEstoqueClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoEstoqueClass item in CollectionOrdemProducaoEstoqueClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoHistoricoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoHistoricoClass item in CollectionOrdemProducaoHistoricoClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoMaterialClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoMaterialClass item in CollectionOrdemProducaoMaterialClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoPedidoClass item in CollectionOrdemProducaoPedidoClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoClass item in CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoProdutoComponenteClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoProdutoComponenteClass item in CollectionOrdemProducaoProdutoComponenteClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoRecursoClassOrdemProducaoLoaded) 
               {
                  foreach(OrdemProducaoRecursoClass item in CollectionOrdemProducaoRecursoClassOrdemProducao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemOpClassOrdemProducaoLoaded) 
               {
                  foreach(PlanoCorteItemOpClass item in CollectionPlanoCorteItemOpClassOrdemProducao)
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
                  command.CommandText += " COUNT(ordem_producao.id_ordem_producao) " ;
               }
               else
               {
               command.CommandText += "ordem_producao.id_ordem_producao, " ;
               command.CommandText += "ordem_producao.orp_quantidade, " ;
               command.CommandText += "ordem_producao.orp_data, " ;
               command.CommandText += "ordem_producao.orp_situacao, " ;
               command.CommandText += "ordem_producao.orp_produto_descricao, " ;
               command.CommandText += "ordem_producao.orp_tipo_documento, " ;
               command.CommandText += "ordem_producao.orp_numero_documento, " ;
               command.CommandText += "ordem_producao.orp_revisao_documento, " ;
               command.CommandText += "ordem_producao.orp_cliente_nao_usar, " ;
               command.CommandText += "ordem_producao.orp_dimensao, " ;
               command.CommandText += "ordem_producao.id_produto, " ;
               command.CommandText += "ordem_producao.orp_produto_codigo, " ;
               command.CommandText += "ordem_producao.orp_quantidade_estoque, " ;
               command.CommandText += "ordem_producao.orp_quantidade_pedido, " ;
               command.CommandText += "ordem_producao.orp_pendencia, " ;
               command.CommandText += "ordem_producao.orp_suspensa, " ;
               command.CommandText += "ordem_producao.orp_qtd_maior_verificada, " ;
               command.CommandText += "ordem_producao.id_ordem_producao_grupo, " ;
               command.CommandText += "ordem_producao.id_acs_usuario, " ;
               command.CommandText += "ordem_producao.orp_data_reimpressao, " ;
               command.CommandText += "ordem_producao.id_acs_usuario_reimpressao, " ;
               command.CommandText += "ordem_producao.id_acs_usuario_impressao, " ;
               command.CommandText += "ordem_producao.orp_data_impressao, " ;
               command.CommandText += "ordem_producao.orp_agrupador_op, " ;
               command.CommandText += "ordem_producao.id_acs_usuario_encerramento, " ;
               command.CommandText += "ordem_producao.orp_data_encerramento, " ;
               command.CommandText += "ordem_producao.orp_versao_estrutura_produto, " ;
               command.CommandText += "ordem_producao.orp_rastreamento_material, " ;
               command.CommandText += "ordem_producao.entity_uid, " ;
               command.CommandText += "ordem_producao.version, " ;
               command.CommandText += "ordem_producao.orp_quantidade_extra, " ;
               command.CommandText += "ordem_producao.id_estoque_gaveta, " ;
               command.CommandText += "ordem_producao.orp_imprime_relacionadas, " ;
               command.CommandText += "ordem_producao.id_produto_k, " ;
               command.CommandText += "ordem_producao.id_acs_usuario_liberacao_qualidade, " ;
               command.CommandText += "ordem_producao.orp_observacao_liberacao_qualidade, " ;
               command.CommandText += "ordem_producao.orp_quantidade_final, " ;
               command.CommandText += "ordem_producao.orp_pendencia_de_quantidade " ;
               }
               command.CommandText += " FROM  ordem_producao ";
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
                        orderByClause += " , orp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(orp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.id_ordem_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.id_ordem_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_produto_descricao":
                     case "ProdutoDescricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.orp_produto_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.orp_produto_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_tipo_documento":
                     case "TipoDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.orp_tipo_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.orp_tipo_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_numero_documento":
                     case "NumeroDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.orp_numero_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.orp_numero_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_revisao_documento":
                     case "RevisaoDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.orp_revisao_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.orp_revisao_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_cliente_nao_usar":
                     case "ClienteNaoUsar":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.orp_cliente_nao_usar " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.orp_cliente_nao_usar) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_dimensao":
                     case "Dimensao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.orp_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.orp_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = ordem_producao.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "orp_produto_codigo":
                     case "ProdutoCodigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.orp_produto_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.orp_produto_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_quantidade_estoque":
                     case "QuantidadeEstoque":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_quantidade_estoque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_quantidade_estoque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_quantidade_pedido":
                     case "QuantidadePedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_quantidade_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_quantidade_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_pendencia":
                     case "Pendencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_pendencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_pendencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_suspensa":
                     case "Suspensa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_suspensa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_suspensa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_qtd_maior_verificada":
                     case "QtdMaiorVerificada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_qtd_maior_verificada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_qtd_maior_verificada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao_grupo":
                     case "OrdemProducaoGrupo":
                     command.CommandText += " LEFT JOIN ordem_producao_grupo as ordem_producao_grupo_OrdemProducaoGrupo ON ordem_producao_grupo_OrdemProducaoGrupo.id_ordem_producao_grupo = ordem_producao.id_ordem_producao_grupo ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_grupo_OrdemProducaoGrupo.id_ordem_producao_grupo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_grupo_OrdemProducaoGrupo.id_ordem_producao_grupo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , ordem_producao.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "orp_data_reimpressao":
                     case "DataReimpressao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_data_reimpressao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_data_reimpressao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_reimpressao":
                     case "AcsUsuarioReimpressao":
                     orderByClause += " , ordem_producao.id_acs_usuario_reimpressao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_acs_usuario_impressao":
                     case "AcsUsuarioImpressao":
                     orderByClause += " , ordem_producao.id_acs_usuario_impressao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "orp_data_impressao":
                     case "DataImpressao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_data_impressao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_data_impressao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_agrupador_op":
                     case "AgrupadorOp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.orp_agrupador_op " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.orp_agrupador_op) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_encerramento":
                     case "AcsUsuarioEncerramento":
                     orderByClause += " , ordem_producao.id_acs_usuario_encerramento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "orp_data_encerramento":
                     case "DataEncerramento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_data_encerramento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_data_encerramento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_versao_estrutura_produto":
                     case "VersaoEstruturaProduto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_versao_estrutura_produto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_versao_estrutura_produto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_rastreamento_material":
                     case "RastreamentoMaterial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_rastreamento_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_rastreamento_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_quantidade_extra":
                     case "QuantidadeExtra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_quantidade_extra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_quantidade_extra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estoque_gaveta":
                     case "EstoqueGaveta":
                     command.CommandText += " LEFT JOIN estoque_gaveta as estoque_gaveta_EstoqueGaveta ON estoque_gaveta_EstoqueGaveta.id_estoque_gaveta = ordem_producao.id_estoque_gaveta ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_gaveta_EstoqueGaveta.esg_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_gaveta_EstoqueGaveta.esg_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_imprime_relacionadas":
                     case "ImprimeRelacionadas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_imprime_relacionadas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_imprime_relacionadas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto_k":
                     case "ProdutoK":
                     command.CommandText += " LEFT JOIN produto_k as produto_k_ProdutoK ON produto_k_ProdutoK.id_produto_k = ordem_producao.id_produto_k ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k_ProdutoK.prk_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k_ProdutoK.prk_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k_ProdutoK.prk_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k_ProdutoK.prk_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_liberacao_qualidade":
                     case "AcsUsuarioLiberacaoQualidade":
                     orderByClause += " , ordem_producao.id_acs_usuario_liberacao_qualidade " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "orp_observacao_liberacao_qualidade":
                     case "ObservacaoLiberacaoQualidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao.orp_observacao_liberacao_qualidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao.orp_observacao_liberacao_qualidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_quantidade_final":
                     case "QuantidadeFinal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_quantidade_final " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_quantidade_final) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orp_pendencia_de_quantidade":
                     case "PendenciaDeQuantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao.orp_pendencia_de_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao.orp_pendencia_de_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orp_produto_descricao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.orp_produto_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.orp_produto_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orp_tipo_documento")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.orp_tipo_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.orp_tipo_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orp_numero_documento")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.orp_numero_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.orp_numero_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orp_revisao_documento")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.orp_revisao_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.orp_revisao_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orp_cliente_nao_usar")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.orp_cliente_nao_usar) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.orp_cliente_nao_usar) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orp_dimensao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.orp_dimensao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.orp_dimensao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orp_produto_codigo")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.orp_produto_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.orp_produto_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orp_agrupador_op")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.orp_agrupador_op) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.orp_agrupador_op) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orp_observacao_liberacao_qualidade")) 
                        {
                           whereClause += " OR UPPER(ordem_producao.orp_observacao_liberacao_qualidade) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao.orp_observacao_liberacao_qualidade) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.id_ordem_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_ordem_producao = :ordem_producao_ID_4088 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ID_4088", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "orp_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_quantidade = :ordem_producao_Quantidade_9315 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_Quantidade_9315", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "orp_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_data = :ordem_producao_Data_8293 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_Data_8293", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "orp_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is StatusOrdemProducao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo StatusOrdemProducao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_situacao = :ordem_producao_Situacao_129 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_Situacao_129", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoDescricao" || parametro.FieldName == "orp_produto_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_produto_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_produto_descricao LIKE :ordem_producao_ProdutoDescricao_1957 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ProdutoDescricao_1957", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDocumento" || parametro.FieldName == "orp_tipo_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_tipo_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_tipo_documento LIKE :ordem_producao_TipoDocumento_8298 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_TipoDocumento_8298", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroDocumento" || parametro.FieldName == "orp_numero_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_numero_documento LIKE :ordem_producao_NumeroDocumento_1057 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_NumeroDocumento_1057", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RevisaoDocumento" || parametro.FieldName == "orp_revisao_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_revisao_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_revisao_documento LIKE :ordem_producao_RevisaoDocumento_3912 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_RevisaoDocumento_3912", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClienteNaoUsar" || parametro.FieldName == "orp_cliente_nao_usar")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_cliente_nao_usar IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_cliente_nao_usar LIKE :ordem_producao_ClienteNaoUsar_7631 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ClienteNaoUsar_7631", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao" || parametro.FieldName == "orp_dimensao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_dimensao LIKE :ordem_producao_Dimensao_367 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_Dimensao_367", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_produto = :ordem_producao_Produto_1878 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_Produto_1878", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoCodigo" || parametro.FieldName == "orp_produto_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_produto_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_produto_codigo LIKE :ordem_producao_ProdutoCodigo_2417 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ProdutoCodigo_2417", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeEstoque" || parametro.FieldName == "orp_quantidade_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_quantidade_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_quantidade_estoque = :ordem_producao_QuantidadeEstoque_584 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_QuantidadeEstoque_584", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadePedido" || parametro.FieldName == "orp_quantidade_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_quantidade_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_quantidade_pedido = :ordem_producao_QuantidadePedido_1881 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_QuantidadePedido_1881", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pendencia" || parametro.FieldName == "orp_pendencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_pendencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_pendencia = :ordem_producao_Pendencia_5568 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_Pendencia_5568", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Suspensa" || parametro.FieldName == "orp_suspensa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_suspensa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_suspensa = :ordem_producao_Suspensa_9867 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_Suspensa_9867", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdMaiorVerificada" || parametro.FieldName == "orp_qtd_maior_verificada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_qtd_maior_verificada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_qtd_maior_verificada = :ordem_producao_QtdMaiorVerificada_4114 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_QtdMaiorVerificada_4114", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoGrupo" || parametro.FieldName == "id_ordem_producao_grupo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.id_ordem_producao_grupo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_ordem_producao_grupo = :ordem_producao_OrdemProducaoGrupo_7951 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_OrdemProducaoGrupo_7951", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuario" || parametro.FieldName == "id_acs_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_acs_usuario = :ordem_producao_AcsUsuario_8282 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_AcsUsuario_8282", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataReimpressao" || parametro.FieldName == "orp_data_reimpressao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_data_reimpressao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_data_reimpressao = :ordem_producao_DataReimpressao_8071 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_DataReimpressao_8071", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioReimpressao" || parametro.FieldName == "id_acs_usuario_reimpressao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.id_acs_usuario_reimpressao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_acs_usuario_reimpressao = :ordem_producao_AcsUsuarioReimpressao_1206 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_AcsUsuarioReimpressao_1206", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioImpressao" || parametro.FieldName == "id_acs_usuario_impressao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.id_acs_usuario_impressao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_acs_usuario_impressao = :ordem_producao_AcsUsuarioImpressao_2217 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_AcsUsuarioImpressao_2217", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataImpressao" || parametro.FieldName == "orp_data_impressao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_data_impressao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_data_impressao = :ordem_producao_DataImpressao_6563 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_DataImpressao_6563", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgrupadorOp" || parametro.FieldName == "orp_agrupador_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_agrupador_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_agrupador_op LIKE :ordem_producao_AgrupadorOp_5001 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_AgrupadorOp_5001", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioEncerramento" || parametro.FieldName == "id_acs_usuario_encerramento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.id_acs_usuario_encerramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_acs_usuario_encerramento = :ordem_producao_AcsUsuarioEncerramento_1708 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_AcsUsuarioEncerramento_1708", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEncerramento" || parametro.FieldName == "orp_data_encerramento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_data_encerramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_data_encerramento = :ordem_producao_DataEncerramento_6117 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_DataEncerramento_6117", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoEstruturaProduto" || parametro.FieldName == "orp_versao_estrutura_produto")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_versao_estrutura_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_versao_estrutura_produto = :ordem_producao_VersaoEstruturaProduto_8759 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_VersaoEstruturaProduto_8759", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RastreamentoMaterial" || parametro.FieldName == "orp_rastreamento_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_rastreamento_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_rastreamento_material = :ordem_producao_RastreamentoMaterial_2931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_RastreamentoMaterial_2931", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.entity_uid LIKE :ordem_producao_EntityUid_6218 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_EntityUid_6218", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.version = :ordem_producao_Version_125 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_Version_125", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeExtra" || parametro.FieldName == "orp_quantidade_extra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_quantidade_extra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_quantidade_extra = :ordem_producao_QuantidadeExtra_4231 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_QuantidadeExtra_4231", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstoqueGaveta" || parametro.FieldName == "id_estoque_gaveta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstoqueGavetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstoqueGavetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.id_estoque_gaveta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_estoque_gaveta = :ordem_producao_EstoqueGaveta_1294 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_EstoqueGaveta_1294", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImprimeRelacionadas" || parametro.FieldName == "orp_imprime_relacionadas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_imprime_relacionadas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_imprime_relacionadas = :ordem_producao_ImprimeRelacionadas_236 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ImprimeRelacionadas_236", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoK" || parametro.FieldName == "id_produto_k")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoKClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoKClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.id_produto_k IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_produto_k = :ordem_producao_ProdutoK_5139 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ProdutoK_5139", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioLiberacaoQualidade" || parametro.FieldName == "id_acs_usuario_liberacao_qualidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.id_acs_usuario_liberacao_qualidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.id_acs_usuario_liberacao_qualidade = :ordem_producao_AcsUsuarioLiberacaoQualidade_7161 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_AcsUsuarioLiberacaoQualidade_7161", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoLiberacaoQualidade" || parametro.FieldName == "orp_observacao_liberacao_qualidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_observacao_liberacao_qualidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_observacao_liberacao_qualidade LIKE :ordem_producao_ObservacaoLiberacaoQualidade_3885 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ObservacaoLiberacaoQualidade_3885", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeFinal" || parametro.FieldName == "orp_quantidade_final")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_quantidade_final IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_quantidade_final = :ordem_producao_QuantidadeFinal_47 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_QuantidadeFinal_47", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PendenciaDeQuantidade" || parametro.FieldName == "orp_pendencia_de_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_pendencia_de_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_pendencia_de_quantidade = :ordem_producao_PendenciaDeQuantidade_9262 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_PendenciaDeQuantidade_9262", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao.orp_produto_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_produto_descricao LIKE :ordem_producao_ProdutoDescricao_3888 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ProdutoDescricao_3888", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao.orp_tipo_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_tipo_documento LIKE :ordem_producao_TipoDocumento_6551 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_TipoDocumento_6551", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao.orp_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_numero_documento LIKE :ordem_producao_NumeroDocumento_1575 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_NumeroDocumento_1575", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao.orp_revisao_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_revisao_documento LIKE :ordem_producao_RevisaoDocumento_1816 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_RevisaoDocumento_1816", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClienteNaoUsarExato" || parametro.FieldName == "ClienteNaoUsarExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_cliente_nao_usar IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_cliente_nao_usar LIKE :ordem_producao_ClienteNaoUsar_8331 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ClienteNaoUsar_8331", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao.orp_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_dimensao LIKE :ordem_producao_Dimensao_5341 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_Dimensao_5341", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao.orp_produto_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_produto_codigo LIKE :ordem_producao_ProdutoCodigo_8324 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ProdutoCodigo_8324", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgrupadorOpExato" || parametro.FieldName == "AgrupadorOpExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_agrupador_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_agrupador_op LIKE :ordem_producao_AgrupadorOp_7676 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_AgrupadorOp_7676", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.entity_uid LIKE :ordem_producao_EntityUid_3382 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_EntityUid_3382", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoLiberacaoQualidadeExato" || parametro.FieldName == "ObservacaoLiberacaoQualidadeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao.orp_observacao_liberacao_qualidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao.orp_observacao_liberacao_qualidade LIKE :ordem_producao_ObservacaoLiberacaoQualidade_1996 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_ObservacaoLiberacaoQualidade_1996", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoClass), Convert.ToInt32(read["id_ordem_producao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao"]);
                     entidade.Quantidade = (double)read["orp_quantidade"];
                     entidade.Data = (DateTime)read["orp_data"];
                     entidade.Situacao = (StatusOrdemProducao) (read["orp_situacao"] != DBNull.Value ? Enum.ToObject(typeof(StatusOrdemProducao), read["orp_situacao"]) : null);
                     entidade.ProdutoDescricao = (read["orp_produto_descricao"] != DBNull.Value ? read["orp_produto_descricao"].ToString() : null);
                     entidade.TipoDocumento = (read["orp_tipo_documento"] != DBNull.Value ? read["orp_tipo_documento"].ToString() : null);
                     entidade.NumeroDocumento = (read["orp_numero_documento"] != DBNull.Value ? read["orp_numero_documento"].ToString() : null);
                     entidade.RevisaoDocumento = (read["orp_revisao_documento"] != DBNull.Value ? read["orp_revisao_documento"].ToString() : null);
                     entidade.ClienteNaoUsar = (read["orp_cliente_nao_usar"] != DBNull.Value ? read["orp_cliente_nao_usar"].ToString() : null);
                     entidade.Dimensao = (read["orp_dimensao"] != DBNull.Value ? read["orp_dimensao"].ToString() : null);
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     entidade.ProdutoCodigo = (read["orp_produto_codigo"] != DBNull.Value ? read["orp_produto_codigo"].ToString() : null);
                     entidade.QuantidadeEstoque = (double)read["orp_quantidade_estoque"];
                     entidade.QuantidadePedido = (double)read["orp_quantidade_pedido"];
                     entidade.Pendencia = Convert.ToBoolean(Convert.ToInt16(read["orp_pendencia"]));
                     entidade.Suspensa = Convert.ToBoolean(Convert.ToInt16(read["orp_suspensa"]));
                     entidade.QtdMaiorVerificada = Convert.ToBoolean(Convert.ToInt16(read["orp_qtd_maior_verificada"]));
                     if (read["id_ordem_producao_grupo"] != DBNull.Value)
                     {
                        entidade.OrdemProducaoGrupo = (BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass)BibliotecaEntidades.Entidades.OrdemProducaoGrupoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao_grupo"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducaoGrupo = null ;
                     }
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.DataReimpressao = read["orp_data_reimpressao"] as DateTime?;
                     if (read["id_acs_usuario_reimpressao"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioReimpressao = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_reimpressao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioReimpressao = null ;
                     }
                     if (read["id_acs_usuario_impressao"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioImpressao = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_impressao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioImpressao = null ;
                     }
                     entidade.DataImpressao = read["orp_data_impressao"] as DateTime?;
                     entidade.AgrupadorOp = (read["orp_agrupador_op"] != DBNull.Value ? read["orp_agrupador_op"].ToString() : null);
                     if (read["id_acs_usuario_encerramento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioEncerramento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_encerramento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioEncerramento = null ;
                     }
                     entidade.DataEncerramento = read["orp_data_encerramento"] as DateTime?;
                     entidade.VersaoEstruturaProduto = (int)read["orp_versao_estrutura_produto"];
                     entidade.RastreamentoMaterial = Convert.ToBoolean(Convert.ToInt16(read["orp_rastreamento_material"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.QuantidadeExtra = (double)read["orp_quantidade_extra"];
                     if (read["id_estoque_gaveta"] != DBNull.Value)
                     {
                        entidade.EstoqueGaveta = (BibliotecaEntidades.Entidades.EstoqueGavetaClass)BibliotecaEntidades.Entidades.EstoqueGavetaClass.GetEntidade(Convert.ToInt32(read["id_estoque_gaveta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstoqueGaveta = null ;
                     }
                     entidade.ImprimeRelacionadas = Convert.ToBoolean(Convert.ToInt16(read["orp_imprime_relacionadas"]));
                     if (read["id_produto_k"] != DBNull.Value)
                     {
                        entidade.ProdutoK = (BibliotecaEntidades.Entidades.ProdutoKClass)BibliotecaEntidades.Entidades.ProdutoKClass.GetEntidade(Convert.ToInt32(read["id_produto_k"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ProdutoK = null ;
                     }
                     if (read["id_acs_usuario_liberacao_qualidade"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioLiberacaoQualidade = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_liberacao_qualidade"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioLiberacaoQualidade = null ;
                     }
                     entidade.ObservacaoLiberacaoQualidade = (read["orp_observacao_liberacao_qualidade"] != DBNull.Value ? read["orp_observacao_liberacao_qualidade"].ToString() : null);
                     entidade.QuantidadeFinal = read["orp_quantidade_final"] as double?;
                     entidade.PendenciaDeQuantidade = Convert.ToBoolean(Convert.ToInt16(read["orp_pendencia_de_quantidade"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
