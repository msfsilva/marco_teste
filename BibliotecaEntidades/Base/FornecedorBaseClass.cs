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
     [Table("fornecedor","for")]
     public class FornecedorBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do FornecedorClass";
protected const string ErroDelete = "Erro ao excluir o FornecedorClass  ";
protected const string ErroSave = "Erro ao salvar o FornecedorClass.";
protected const string ErroCollectionContaPagarClassFornecedor = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionContaRecorrenteClassFornecedor = "Erro ao carregar a coleção de ContaRecorrenteClass.";
protected const string ErroCollectionContratoFornecimentoClassFornecedor = "Erro ao carregar a coleção de ContratoFornecimentoClass.";
protected const string ErroCollectionCredorDevedorClassFornecedor = "Erro ao carregar a coleção de CredorDevedorClass.";
protected const string ErroCollectionDeclaracaoImportacaoClassFornecedor = "Erro ao carregar a coleção de DeclaracaoImportacaoClass.";
protected const string ErroCollectionEpiFornecedorClassFornecedor = "Erro ao carregar a coleção de EpiFornecedorClass.";
protected const string ErroCollectionFornecedorContatoClassFornecedor = "Erro ao carregar a coleção de FornecedorContatoClass.";
protected const string ErroCollectionHistoricoCompraEpiClassFornecedor = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
protected const string ErroCollectionHistoricoCompraMaterialClassFornecedor = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
protected const string ErroCollectionHistoricoCompraProdutoClassFornecedor = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
protected const string ErroCollectionLoteClassFornecedor = "Erro ao carregar a coleção de LoteClass.";
protected const string ErroCollectionMaterialFornecedorClassFornecedor = "Erro ao carregar a coleção de MaterialFornecedorClass.";
protected const string ErroCollectionNotaFiscalEntradaClassFornecedor = "Erro ao carregar a coleção de NotaFiscalEntradaClass.";
protected const string ErroCollectionOrcamentoCompraClassFornecedor = "Erro ao carregar a coleção de OrcamentoCompraClass.";
protected const string ErroCollectionOrdemCompraClassFornecedor = "Erro ao carregar a coleção de OrdemCompraClass.";
protected const string ErroCollectionOrdemProducaoEnvioTerceirosClassFornecedor = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosClass.";
protected const string ErroCollectionPostoTrabalhoClassFornecedor = "Erro ao carregar a coleção de PostoTrabalhoClass.";
protected const string ErroCollectionProdutoFornecedorClassFornecedor = "Erro ao carregar a coleção de ProdutoFornecedorClass.";
protected const string ErroCollectionServicoClassFornecedor = "Erro ao carregar a coleção de ServicoClass.";
protected const string ErroRazaoSocialObrigatorio = "O campo RazaoSocial é obrigatório";
protected const string ErroRazaoSocialComprimento = "O campo RazaoSocial deve ter no máximo 255 caracteres";
protected const string ErroNomeFantasiaObrigatorio = "O campo NomeFantasia é obrigatório";
protected const string ErroNomeFantasiaComprimento = "O campo NomeFantasia deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do FornecedorClass.";
protected const string MensagemUtilizadoCollectionContaPagarClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionContaRecorrenteClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
protected const string MensagemUtilizadoCollectionContratoFornecimentoClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes ContratoFornecimentoClass:";
protected const string MensagemUtilizadoCollectionCredorDevedorClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes CredorDevedorClass:";
protected const string MensagemUtilizadoCollectionDeclaracaoImportacaoClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes DeclaracaoImportacaoClass:";
protected const string MensagemUtilizadoCollectionEpiFornecedorClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes EpiFornecedorClass:";
protected const string MensagemUtilizadoCollectionFornecedorContatoClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes FornecedorContatoClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraEpiClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
protected const string MensagemUtilizadoCollectionLoteClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes LoteClass:";
protected const string MensagemUtilizadoCollectionMaterialFornecedorClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes MaterialFornecedorClass:";
protected const string MensagemUtilizadoCollectionNotaFiscalEntradaClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes NotaFiscalEntradaClass:";
protected const string MensagemUtilizadoCollectionOrcamentoCompraClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes OrcamentoCompraClass:";
protected const string MensagemUtilizadoCollectionOrdemCompraClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes OrdemCompraClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosClass:";
protected const string MensagemUtilizadoCollectionPostoTrabalhoClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes PostoTrabalhoClass:";
protected const string MensagemUtilizadoCollectionProdutoFornecedorClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes ProdutoFornecedorClass:";
protected const string MensagemUtilizadoCollectionServicoClassFornecedor =  "A entidade FornecedorClass está sendo utilizada nos seguintes ServicoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade FornecedorClass está sendo utilizada.";
#endregion
       protected string _razaoSocialOriginal{get;private set;}
       private string _razaoSocialOriginalCommited{get; set;}
        private string _valueRazaoSocial;
         [Column("for_razao_social")]
        public virtual string RazaoSocial
         { 
            get { return this._valueRazaoSocial; } 
            set 
            { 
                if (this._valueRazaoSocial == value)return;
                 this._valueRazaoSocial = value; 
            } 
        } 

       protected string _nomeFantasiaOriginal{get;private set;}
       private string _nomeFantasiaOriginalCommited{get; set;}
        private string _valueNomeFantasia;
         [Column("for_nome_fantasia")]
        public virtual string NomeFantasia
         { 
            get { return this._valueNomeFantasia; } 
            set 
            { 
                if (this._valueNomeFantasia == value)return;
                 this._valueNomeFantasia = value; 
            } 
        } 

       protected string _cnpjOriginal{get;private set;}
       private string _cnpjOriginalCommited{get; set;}
        private string _valueCnpj;
         [Column("for_cnpj")]
        public virtual string Cnpj
         { 
            get { return this._valueCnpj; } 
            set 
            { 
                if (this._valueCnpj == value)return;
                 this._valueCnpj = value; 
            } 
        } 

       protected string _inscEstadualOriginal{get;private set;}
       private string _inscEstadualOriginalCommited{get; set;}
        private string _valueInscEstadual;
         [Column("for_insc_estadual")]
        public virtual string InscEstadual
         { 
            get { return this._valueInscEstadual; } 
            set 
            { 
                if (this._valueInscEstadual == value)return;
                 this._valueInscEstadual = value; 
            } 
        } 

       protected string _inscMunicipalOriginal{get;private set;}
       private string _inscMunicipalOriginalCommited{get; set;}
        private string _valueInscMunicipal;
         [Column("for_insc_municipal")]
        public virtual string InscMunicipal
         { 
            get { return this._valueInscMunicipal; } 
            set 
            { 
                if (this._valueInscMunicipal == value)return;
                 this._valueInscMunicipal = value; 
            } 
        } 

       protected string _enderecoOriginal{get;private set;}
       private string _enderecoOriginalCommited{get; set;}
        private string _valueEndereco;
         [Column("for_endereco")]
        public virtual string Endereco
         { 
            get { return this._valueEndereco; } 
            set 
            { 
                if (this._valueEndereco == value)return;
                 this._valueEndereco = value; 
            } 
        } 

       protected string _bairroOriginal{get;private set;}
       private string _bairroOriginalCommited{get; set;}
        private string _valueBairro;
         [Column("for_bairro")]
        public virtual string Bairro
         { 
            get { return this._valueBairro; } 
            set 
            { 
                if (this._valueBairro == value)return;
                 this._valueBairro = value; 
            } 
        } 

       protected string _cepOriginal{get;private set;}
       private string _cepOriginalCommited{get; set;}
        private string _valueCep;
         [Column("for_cep")]
        public virtual string Cep
         { 
            get { return this._valueCep; } 
            set 
            { 
                if (this._valueCep == value)return;
                 this._valueCep = value; 
            } 
        } 

       protected string _fone1Original{get;private set;}
       private string _fone1OriginalCommited{get; set;}
        private string _valueFone1;
         [Column("for_fone1")]
        public virtual string Fone1
         { 
            get { return this._valueFone1; } 
            set 
            { 
                if (this._valueFone1 == value)return;
                 this._valueFone1 = value; 
            } 
        } 

       protected string _fone2Original{get;private set;}
       private string _fone2OriginalCommited{get; set;}
        private string _valueFone2;
         [Column("for_fone2")]
        public virtual string Fone2
         { 
            get { return this._valueFone2; } 
            set 
            { 
                if (this._valueFone2 == value)return;
                 this._valueFone2 = value; 
            } 
        } 

       protected string _fone3Original{get;private set;}
       private string _fone3OriginalCommited{get; set;}
        private string _valueFone3;
         [Column("for_fone3")]
        public virtual string Fone3
         { 
            get { return this._valueFone3; } 
            set 
            { 
                if (this._valueFone3 == value)return;
                 this._valueFone3 = value; 
            } 
        } 

       protected string _faxOriginal{get;private set;}
       private string _faxOriginalCommited{get; set;}
        private string _valueFax;
         [Column("for_fax")]
        public virtual string Fax
         { 
            get { return this._valueFax; } 
            set 
            { 
                if (this._valueFax == value)return;
                 this._valueFax = value; 
            } 
        } 

       protected string _emailOriginal{get;private set;}
       private string _emailOriginalCommited{get; set;}
        private string _valueEmail;
         [Column("for_email")]
        public virtual string Email
         { 
            get { return this._valueEmail; } 
            set 
            { 
                if (this._valueEmail == value)return;
                 this._valueEmail = value; 
            } 
        } 

       protected string _siteOriginal{get;private set;}
       private string _siteOriginalCommited{get; set;}
        private string _valueSite;
         [Column("for_site")]
        public virtual string Site
         { 
            get { return this._valueSite; } 
            set 
            { 
                if (this._valueSite == value)return;
                 this._valueSite = value; 
            } 
        } 

       protected string _obsOriginal{get;private set;}
       private string _obsOriginalCommited{get; set;}
        private string _valueObs;
         [Column("for_obs")]
        public virtual string Obs
         { 
            get { return this._valueObs; } 
            set 
            { 
                if (this._valueObs == value)return;
                 this._valueObs = value; 
            } 
        } 

       protected TipoPessoa? _tipoPessoaOriginal{get;private set;}
       private TipoPessoa? _tipoPessoaOriginalCommited{get; set;}
        private TipoPessoa? _valueTipoPessoa;
         [Column("for_tipo_pessoa")]
        public virtual TipoPessoa? TipoPessoa
         { 
            get { return this._valueTipoPessoa; } 
            set 
            { 
                if (this._valueTipoPessoa == value)return;
                 this._valueTipoPessoa = value; 
            } 
        } 

        public bool TipoPessoa_PJ
         { 
            get { return this._valueTipoPessoa.HasValue && this._valueTipoPessoa.Value == BibliotecaEntidades.Base.TipoPessoa.PJ; } 
            set { if (value) this._valueTipoPessoa = BibliotecaEntidades.Base.TipoPessoa.PJ; }
         } 

        public bool TipoPessoa_PF
         { 
            get { return this._valueTipoPessoa.HasValue && this._valueTipoPessoa.Value == BibliotecaEntidades.Base.TipoPessoa.PF; } 
            set { if (value) this._valueTipoPessoa = BibliotecaEntidades.Base.TipoPessoa.PF; }
         } 

       protected string _endNumeroOriginal{get;private set;}
       private string _endNumeroOriginalCommited{get; set;}
        private string _valueEndNumero;
         [Column("for_end_numero")]
        public virtual string EndNumero
         { 
            get { return this._valueEndNumero; } 
            set 
            { 
                if (this._valueEndNumero == value)return;
                 this._valueEndNumero = value; 
            } 
        } 

       protected string _endComplementoOriginal{get;private set;}
       private string _endComplementoOriginalCommited{get; set;}
        private string _valueEndComplemento;
         [Column("for_end_complemento")]
        public virtual string EndComplemento
         { 
            get { return this._valueEndComplemento; } 
            set 
            { 
                if (this._valueEndComplemento == value)return;
                 this._valueEndComplemento = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EstadoClass _estadoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstadoClass _estadoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstadoClass _valueEstado;
        [Column("id_estado", "estado", "id_estado")]
       public virtual BibliotecaEntidades.Entidades.EstadoClass Estado
        { 
           get {                 return this._valueEstado; } 
           set 
           { 
                if (this._valueEstado == value)return;
                 this._valueEstado = value; 
           } 
       } 

       protected string _bancoOriginal{get;private set;}
       private string _bancoOriginalCommited{get; set;}
        private string _valueBanco;
         [Column("for_banco")]
        public virtual string Banco
         { 
            get { return this._valueBanco; } 
            set 
            { 
                if (this._valueBanco == value)return;
                 this._valueBanco = value; 
            } 
        } 

       protected string _agenciaOriginal{get;private set;}
       private string _agenciaOriginalCommited{get; set;}
        private string _valueAgencia;
         [Column("for_agencia")]
        public virtual string Agencia
         { 
            get { return this._valueAgencia; } 
            set 
            { 
                if (this._valueAgencia == value)return;
                 this._valueAgencia = value; 
            } 
        } 

       protected string _contaOriginal{get;private set;}
       private string _contaOriginalCommited{get; set;}
        private string _valueConta;
         [Column("for_conta")]
        public virtual string Conta
         { 
            get { return this._valueConta; } 
            set 
            { 
                if (this._valueConta == value)return;
                 this._valueConta = value; 
            } 
        } 

       protected string _contatoOriginal{get;private set;}
       private string _contatoOriginalCommited{get; set;}
        private string _valueContato;
         [Column("for_contato")]
        public virtual string Contato
         { 
            get { return this._valueContato; } 
            set 
            { 
                if (this._valueContato == value)return;
                 this._valueContato = value; 
            } 
        } 

       protected bool _envioEmailOriginal{get;private set;}
       private bool _envioEmailOriginalCommited{get; set;}
        private bool _valueEnvioEmail;
         [Column("for_envio_email")]
        public virtual bool EnvioEmail
         { 
            get { return this._valueEnvioEmail; } 
            set 
            { 
                if (this._valueEnvioEmail == value)return;
                 this._valueEnvioEmail = value; 
            } 
        } 

       protected string _emailPedidoOriginal{get;private set;}
       private string _emailPedidoOriginalCommited{get; set;}
        private string _valueEmailPedido;
         [Column("for_email_pedido")]
        public virtual string EmailPedido
         { 
            get { return this._valueEmailPedido; } 
            set 
            { 
                if (this._valueEmailPedido == value)return;
                 this._valueEmailPedido = value; 
            } 
        } 

       protected string _emailCotacaoOriginal{get;private set;}
       private string _emailCotacaoOriginalCommited{get; set;}
        private string _valueEmailCotacao;
         [Column("for_email_cotacao")]
        public virtual string EmailCotacao
         { 
            get { return this._valueEmailCotacao; } 
            set 
            { 
                if (this._valueEmailCotacao == value)return;
                 this._valueEmailCotacao = value; 
            } 
        } 

       protected bool _realizaRecebimentoOriginal{get;private set;}
       private bool _realizaRecebimentoOriginalCommited{get; set;}
        private bool _valueRealizaRecebimento;
         [Column("for_realiza_recebimento")]
        public virtual bool RealizaRecebimento
         { 
            get { return this._valueRealizaRecebimento; } 
            set 
            { 
                if (this._valueRealizaRecebimento == value)return;
                 this._valueRealizaRecebimento = value; 
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

       protected BibliotecaEntidades.Entidades.CidadeClass _cidadeOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CidadeClass _cidadeOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CidadeClass _valueCidade;
        [Column("id_cidade", "cidade", "id_cidade")]
       public virtual BibliotecaEntidades.Entidades.CidadeClass Cidade
        { 
           get {                 return this._valueCidade; } 
           set 
           { 
                if (this._valueCidade == value)return;
                 this._valueCidade = value; 
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

       protected bool _estrangeiroOriginal{get;private set;}
       private bool _estrangeiroOriginalCommited{get; set;}
        private bool _valueEstrangeiro;
         [Column("for_estrangeiro")]
        public virtual bool Estrangeiro
         { 
            get { return this._valueEstrangeiro; } 
            set 
            { 
                if (this._valueEstrangeiro == value)return;
                 this._valueEstrangeiro = value; 
            } 
        } 

       protected string _inscricaoSuframaOriginal{get;private set;}
       private string _inscricaoSuframaOriginalCommited{get; set;}
        private string _valueInscricaoSuframa;
         [Column("for_inscricao_suframa")]
        public virtual string InscricaoSuframa
         { 
            get { return this._valueInscricaoSuframa; } 
            set 
            { 
                if (this._valueInscricaoSuframa == value)return;
                 this._valueInscricaoSuframa = value; 
            } 
        } 

       protected string _emailDanfeOriginal{get;private set;}
       private string _emailDanfeOriginalCommited{get; set;}
        private string _valueEmailDanfe;
         [Column("for_email_danfe")]
        public virtual string EmailDanfe
         { 
            get { return this._valueEmailDanfe; } 
            set 
            { 
                if (this._valueEmailDanfe == value)return;
                 this._valueEmailDanfe = value; 
            } 
        } 

       protected string _emailXmlOriginal{get;private set;}
       private string _emailXmlOriginalCommited{get; set;}
        private string _valueEmailXml;
         [Column("for_email_xml")]
        public virtual string EmailXml
         { 
            get { return this._valueEmailXml; } 
            set 
            { 
                if (this._valueEmailXml == value)return;
                 this._valueEmailXml = value; 
            } 
        } 

       protected string _paisOriginal{get;private set;}
       private string _paisOriginalCommited{get; set;}
        private string _valuePais;
         [Column("for_pais")]
        public virtual string Pais
         { 
            get { return this._valuePais; } 
            set 
            { 
                if (this._valuePais == value)return;
                 this._valuePais = value; 
            } 
        } 

       protected int? _codigoPaisOriginal{get;private set;}
       private int? _codigoPaisOriginalCommited{get; set;}
        private int? _valueCodigoPais;
         [Column("for_codigo_pais")]
        public virtual int? CodigoPais
         { 
            get { return this._valueCodigoPais; } 
            set 
            { 
                if (this._valueCodigoPais == value)return;
                 this._valueCodigoPais = value; 
            } 
        } 

       protected IWTNFIndicadorIE _indicadorIeOriginal{get;private set;}
       private IWTNFIndicadorIE _indicadorIeOriginalCommited{get; set;}
        private IWTNFIndicadorIE _valueIndicadorIe;
         [Column("for_indicador_ie")]
        public virtual IWTNFIndicadorIE IndicadorIe
         { 
            get { return this._valueIndicadorIe; } 
            set 
            { 
                if (this._valueIndicadorIe == value)return;
                 this._valueIndicadorIe = value; 
            } 
        } 

        public bool IndicadorIe_ContribuinteICMS
         { 
            get { return this._valueIndicadorIe == BibliotecaEntidades.Base.IWTNFIndicadorIE.ContribuinteICMS; } 
            set { if (value) this._valueIndicadorIe = BibliotecaEntidades.Base.IWTNFIndicadorIE.ContribuinteICMS; }
         } 

        public bool IndicadorIe_Isento
         { 
            get { return this._valueIndicadorIe == BibliotecaEntidades.Base.IWTNFIndicadorIE.Isento; } 
            set { if (value) this._valueIndicadorIe = BibliotecaEntidades.Base.IWTNFIndicadorIE.Isento; }
         } 

        public bool IndicadorIe_NaoContribuinte
         { 
            get { return this._valueIndicadorIe == BibliotecaEntidades.Base.IWTNFIndicadorIE.NaoContribuinte; } 
            set { if (value) this._valueIndicadorIe = BibliotecaEntidades.Base.IWTNFIndicadorIE.NaoContribuinte; }
         } 

       protected bool _contaRevisarRecebimentoOriginal{get;private set;}
       private bool _contaRevisarRecebimentoOriginalCommited{get; set;}
        private bool _valueContaRevisarRecebimento;
         [Column("for_conta_revisar_recebimento")]
        public virtual bool ContaRevisarRecebimento
         { 
            get { return this._valueContaRevisarRecebimento; } 
            set 
            { 
                if (this._valueContaRevisarRecebimento == value)return;
                 this._valueContaRevisarRecebimento = value; 
            } 
        } 

       private List<long> _collectionContaPagarClassFornecedorOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassFornecedor 
       { 
           get { if(!_valueCollectionContaPagarClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassFornecedor();}
return this._valueCollectionContaPagarClassFornecedor; } 
           set 
           { 
               this._valueCollectionContaPagarClassFornecedor = value; 
               this._valueCollectionContaPagarClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionContaRecorrenteClassFornecedorOriginal;
       private List<Entidades.ContaRecorrenteClass > _collectionContaRecorrenteClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaRecorrenteClass> _valueCollectionContaRecorrenteClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaRecorrenteClass> CollectionContaRecorrenteClassFornecedor 
       { 
           get { if(!_valueCollectionContaRecorrenteClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionContaRecorrenteClassFornecedor();}
return this._valueCollectionContaRecorrenteClassFornecedor; } 
           set 
           { 
               this._valueCollectionContaRecorrenteClassFornecedor = value; 
               this._valueCollectionContaRecorrenteClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionContratoFornecimentoClassFornecedorOriginal;
       private List<Entidades.ContratoFornecimentoClass > _collectionContratoFornecimentoClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContratoFornecimentoClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContratoFornecimentoClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContratoFornecimentoClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContratoFornecimentoClass> _valueCollectionContratoFornecimentoClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContratoFornecimentoClass> CollectionContratoFornecimentoClassFornecedor 
       { 
           get { if(!_valueCollectionContratoFornecimentoClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionContratoFornecimentoClassFornecedor();}
return this._valueCollectionContratoFornecimentoClassFornecedor; } 
           set 
           { 
               this._valueCollectionContratoFornecimentoClassFornecedor = value; 
               this._valueCollectionContratoFornecimentoClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionCredorDevedorClassFornecedorOriginal;
       private List<Entidades.CredorDevedorClass > _collectionCredorDevedorClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CredorDevedorClass> _valueCollectionCredorDevedorClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CredorDevedorClass> CollectionCredorDevedorClassFornecedor 
       { 
           get { if(!_valueCollectionCredorDevedorClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionCredorDevedorClassFornecedor();}
return this._valueCollectionCredorDevedorClassFornecedor; } 
           set 
           { 
               this._valueCollectionCredorDevedorClassFornecedor = value; 
               this._valueCollectionCredorDevedorClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionDeclaracaoImportacaoClassFornecedorOriginal;
       private List<Entidades.DeclaracaoImportacaoClass > _collectionDeclaracaoImportacaoClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.DeclaracaoImportacaoClass> _valueCollectionDeclaracaoImportacaoClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.DeclaracaoImportacaoClass> CollectionDeclaracaoImportacaoClassFornecedor 
       { 
           get { if(!_valueCollectionDeclaracaoImportacaoClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionDeclaracaoImportacaoClassFornecedor();}
return this._valueCollectionDeclaracaoImportacaoClassFornecedor; } 
           set 
           { 
               this._valueCollectionDeclaracaoImportacaoClassFornecedor = value; 
               this._valueCollectionDeclaracaoImportacaoClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionEpiFornecedorClassFornecedorOriginal;
       private List<Entidades.EpiFornecedorClass > _collectionEpiFornecedorClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiFornecedorClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiFornecedorClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEpiFornecedorClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EpiFornecedorClass> _valueCollectionEpiFornecedorClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EpiFornecedorClass> CollectionEpiFornecedorClassFornecedor 
       { 
           get { if(!_valueCollectionEpiFornecedorClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionEpiFornecedorClassFornecedor();}
return this._valueCollectionEpiFornecedorClassFornecedor; } 
           set 
           { 
               this._valueCollectionEpiFornecedorClassFornecedor = value; 
               this._valueCollectionEpiFornecedorClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionFornecedorContatoClassFornecedorOriginal;
       private List<Entidades.FornecedorContatoClass > _collectionFornecedorContatoClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorContatoClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorContatoClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorContatoClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FornecedorContatoClass> _valueCollectionFornecedorContatoClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FornecedorContatoClass> CollectionFornecedorContatoClassFornecedor 
       { 
           get { if(!_valueCollectionFornecedorContatoClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionFornecedorContatoClassFornecedor();}
return this._valueCollectionFornecedorContatoClassFornecedor; } 
           set 
           { 
               this._valueCollectionFornecedorContatoClassFornecedor = value; 
               this._valueCollectionFornecedorContatoClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraEpiClassFornecedorOriginal;
       private List<Entidades.HistoricoCompraEpiClass > _collectionHistoricoCompraEpiClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraEpiClass> _valueCollectionHistoricoCompraEpiClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraEpiClass> CollectionHistoricoCompraEpiClassFornecedor 
       { 
           get { if(!_valueCollectionHistoricoCompraEpiClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraEpiClassFornecedor();}
return this._valueCollectionHistoricoCompraEpiClassFornecedor; } 
           set 
           { 
               this._valueCollectionHistoricoCompraEpiClassFornecedor = value; 
               this._valueCollectionHistoricoCompraEpiClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraMaterialClassFornecedorOriginal;
       private List<Entidades.HistoricoCompraMaterialClass > _collectionHistoricoCompraMaterialClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraMaterialClass> _valueCollectionHistoricoCompraMaterialClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraMaterialClass> CollectionHistoricoCompraMaterialClassFornecedor 
       { 
           get { if(!_valueCollectionHistoricoCompraMaterialClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraMaterialClassFornecedor();}
return this._valueCollectionHistoricoCompraMaterialClassFornecedor; } 
           set 
           { 
               this._valueCollectionHistoricoCompraMaterialClassFornecedor = value; 
               this._valueCollectionHistoricoCompraMaterialClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraProdutoClassFornecedorOriginal;
       private List<Entidades.HistoricoCompraProdutoClass > _collectionHistoricoCompraProdutoClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraProdutoClass> _valueCollectionHistoricoCompraProdutoClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraProdutoClass> CollectionHistoricoCompraProdutoClassFornecedor 
       { 
           get { if(!_valueCollectionHistoricoCompraProdutoClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraProdutoClassFornecedor();}
return this._valueCollectionHistoricoCompraProdutoClassFornecedor; } 
           set 
           { 
               this._valueCollectionHistoricoCompraProdutoClassFornecedor = value; 
               this._valueCollectionHistoricoCompraProdutoClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionLoteClassFornecedorOriginal;
       private List<Entidades.LoteClass > _collectionLoteClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LoteClass> _valueCollectionLoteClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LoteClass> CollectionLoteClassFornecedor 
       { 
           get { if(!_valueCollectionLoteClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionLoteClassFornecedor();}
return this._valueCollectionLoteClassFornecedor; } 
           set 
           { 
               this._valueCollectionLoteClassFornecedor = value; 
               this._valueCollectionLoteClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionMaterialFornecedorClassFornecedorOriginal;
       private List<Entidades.MaterialFornecedorClass > _collectionMaterialFornecedorClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFornecedorClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFornecedorClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialFornecedorClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialFornecedorClass> _valueCollectionMaterialFornecedorClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialFornecedorClass> CollectionMaterialFornecedorClassFornecedor 
       { 
           get { if(!_valueCollectionMaterialFornecedorClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialFornecedorClassFornecedor();}
return this._valueCollectionMaterialFornecedorClassFornecedor; } 
           set 
           { 
               this._valueCollectionMaterialFornecedorClassFornecedor = value; 
               this._valueCollectionMaterialFornecedorClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionNotaFiscalEntradaClassFornecedorOriginal;
       private List<Entidades.NotaFiscalEntradaClass > _collectionNotaFiscalEntradaClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotaFiscalEntradaClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotaFiscalEntradaClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotaFiscalEntradaClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NotaFiscalEntradaClass> _valueCollectionNotaFiscalEntradaClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NotaFiscalEntradaClass> CollectionNotaFiscalEntradaClassFornecedor 
       { 
           get { if(!_valueCollectionNotaFiscalEntradaClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionNotaFiscalEntradaClassFornecedor();}
return this._valueCollectionNotaFiscalEntradaClassFornecedor; } 
           set 
           { 
               this._valueCollectionNotaFiscalEntradaClassFornecedor = value; 
               this._valueCollectionNotaFiscalEntradaClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoCompraClassFornecedorOriginal;
       private List<Entidades.OrcamentoCompraClass > _collectionOrcamentoCompraClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoCompraClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoCompraClass> _valueCollectionOrcamentoCompraClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoCompraClass> CollectionOrcamentoCompraClassFornecedor 
       { 
           get { if(!_valueCollectionOrcamentoCompraClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoCompraClassFornecedor();}
return this._valueCollectionOrcamentoCompraClassFornecedor; } 
           set 
           { 
               this._valueCollectionOrcamentoCompraClassFornecedor = value; 
               this._valueCollectionOrcamentoCompraClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemCompraClassFornecedorOriginal;
       private List<Entidades.OrdemCompraClass > _collectionOrdemCompraClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemCompraClass> _valueCollectionOrdemCompraClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemCompraClass> CollectionOrdemCompraClassFornecedor 
       { 
           get { if(!_valueCollectionOrdemCompraClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemCompraClassFornecedor();}
return this._valueCollectionOrdemCompraClassFornecedor; } 
           set 
           { 
               this._valueCollectionOrdemCompraClassFornecedor = value; 
               this._valueCollectionOrdemCompraClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEnvioTerceirosClassFornecedorOriginal;
       private List<Entidades.OrdemProducaoEnvioTerceirosClass > _collectionOrdemProducaoEnvioTerceirosClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> CollectionOrdemProducaoEnvioTerceirosClassFornecedor 
       { 
           get { if(!_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEnvioTerceirosClassFornecedor();}
return this._valueCollectionOrdemProducaoEnvioTerceirosClassFornecedor; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassFornecedor = value; 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionPostoTrabalhoClassFornecedorOriginal;
       private List<Entidades.PostoTrabalhoClass > _collectionPostoTrabalhoClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PostoTrabalhoClass> _valueCollectionPostoTrabalhoClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PostoTrabalhoClass> CollectionPostoTrabalhoClassFornecedor 
       { 
           get { if(!_valueCollectionPostoTrabalhoClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionPostoTrabalhoClassFornecedor();}
return this._valueCollectionPostoTrabalhoClassFornecedor; } 
           set 
           { 
               this._valueCollectionPostoTrabalhoClassFornecedor = value; 
               this._valueCollectionPostoTrabalhoClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoFornecedorClassFornecedorOriginal;
       private List<Entidades.ProdutoFornecedorClass > _collectionProdutoFornecedorClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFornecedorClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFornecedorClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoFornecedorClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoFornecedorClass> _valueCollectionProdutoFornecedorClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoFornecedorClass> CollectionProdutoFornecedorClassFornecedor 
       { 
           get { if(!_valueCollectionProdutoFornecedorClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoFornecedorClassFornecedor();}
return this._valueCollectionProdutoFornecedorClassFornecedor; } 
           set 
           { 
               this._valueCollectionProdutoFornecedorClassFornecedor = value; 
               this._valueCollectionProdutoFornecedorClassFornecedorLoaded = true; 
           } 
       } 

       private List<long> _collectionServicoClassFornecedorOriginal;
       private List<Entidades.ServicoClass > _collectionServicoClassFornecedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionServicoClassFornecedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionServicoClassFornecedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionServicoClassFornecedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ServicoClass> _valueCollectionServicoClassFornecedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ServicoClass> CollectionServicoClassFornecedor 
       { 
           get { if(!_valueCollectionServicoClassFornecedorLoaded && !this.DisableLoadCollection){this.LoadCollectionServicoClassFornecedor();}
return this._valueCollectionServicoClassFornecedor; } 
           set 
           { 
               this._valueCollectionServicoClassFornecedor = value; 
               this._valueCollectionServicoClassFornecedorLoaded = true; 
           } 
       } 

        public FornecedorBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.TipoPessoa = (TipoPessoa?)0;
           this.EnvioEmail = false;
           this.RealizaRecebimento = true;
           this.Estrangeiro = false;
           this.IndicadorIe = (IWTNFIndicadorIE)0;
           this.ContaRevisarRecebimento = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static FornecedorClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (FornecedorClass) GetEntity(typeof(FornecedorClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionContaPagarClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassFornecedorChanged = true;
                  _valueCollectionContaPagarClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassFornecedorChanged = true; 
                  _valueCollectionContaPagarClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassFornecedorChanged = true; 
                  _valueCollectionContaPagarClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassFornecedor) 
                 { 
                     _collectionContaPagarClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassFornecedorChanged = false;
                 _valueCollectionContaPagarClassFornecedorCommitedChanged = false;
                _collectionContaPagarClassFornecedorRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassFornecedor = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassFornecedorOriginal= (from a in _valueCollectionContaPagarClassFornecedor select a.ID).ToList();
                 _valueCollectionContaPagarClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaRecorrenteClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaRecorrenteClassFornecedorChanged = true;
                  _valueCollectionContaRecorrenteClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaRecorrenteClassFornecedorChanged = true; 
                  _valueCollectionContaRecorrenteClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in e.OldItems) 
                 { 
                     _collectionContaRecorrenteClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaRecorrenteClassFornecedorChanged = true; 
                  _valueCollectionContaRecorrenteClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in _valueCollectionContaRecorrenteClassFornecedor) 
                 { 
                     _collectionContaRecorrenteClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaRecorrenteClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.ContaRecorrenteClass> oc;
                _valueCollectionContaRecorrenteClassFornecedorChanged = false;
                 _valueCollectionContaRecorrenteClassFornecedorCommitedChanged = false;
                _collectionContaRecorrenteClassFornecedorRemovidos = new List<Entidades.ContaRecorrenteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaRecorrenteClass>();
                }
                else{ 
                   Entidades.ContaRecorrenteClass search = new Entidades.ContaRecorrenteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaRecorrenteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.ContaRecorrenteClass>().ToList());
                 }
                 _valueCollectionContaRecorrenteClassFornecedor = new BindingList<Entidades.ContaRecorrenteClass>(oc); 
                 _collectionContaRecorrenteClassFornecedorOriginal= (from a in _valueCollectionContaRecorrenteClassFornecedor select a.ID).ToList();
                 _valueCollectionContaRecorrenteClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionContaRecorrenteClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaRecorrenteClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContratoFornecimentoClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContratoFornecimentoClassFornecedorChanged = true;
                  _valueCollectionContratoFornecimentoClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContratoFornecimentoClassFornecedorChanged = true; 
                  _valueCollectionContratoFornecimentoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ContratoFornecimentoClass item in e.OldItems) 
                 { 
                     _collectionContratoFornecimentoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContratoFornecimentoClassFornecedorChanged = true; 
                  _valueCollectionContratoFornecimentoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ContratoFornecimentoClass item in _valueCollectionContratoFornecimentoClassFornecedor) 
                 { 
                     _collectionContratoFornecimentoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContratoFornecimentoClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.ContratoFornecimentoClass> oc;
                _valueCollectionContratoFornecimentoClassFornecedorChanged = false;
                 _valueCollectionContratoFornecimentoClassFornecedorCommitedChanged = false;
                _collectionContratoFornecimentoClassFornecedorRemovidos = new List<Entidades.ContratoFornecimentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContratoFornecimentoClass>();
                }
                else{ 
                   Entidades.ContratoFornecimentoClass search = new Entidades.ContratoFornecimentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContratoFornecimentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.ContratoFornecimentoClass>().ToList());
                 }
                 _valueCollectionContratoFornecimentoClassFornecedor = new BindingList<Entidades.ContratoFornecimentoClass>(oc); 
                 _collectionContratoFornecimentoClassFornecedorOriginal= (from a in _valueCollectionContratoFornecimentoClassFornecedor select a.ID).ToList();
                 _valueCollectionContratoFornecimentoClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionContratoFornecimentoClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContratoFornecimentoClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionCredorDevedorClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCredorDevedorClassFornecedorChanged = true;
                  _valueCollectionCredorDevedorClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCredorDevedorClassFornecedorChanged = true; 
                  _valueCollectionCredorDevedorClassFornecedorCommitedChanged = true;
                 foreach (Entidades.CredorDevedorClass item in e.OldItems) 
                 { 
                     _collectionCredorDevedorClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCredorDevedorClassFornecedorChanged = true; 
                  _valueCollectionCredorDevedorClassFornecedorCommitedChanged = true;
                 foreach (Entidades.CredorDevedorClass item in _valueCollectionCredorDevedorClassFornecedor) 
                 { 
                     _collectionCredorDevedorClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCredorDevedorClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.CredorDevedorClass> oc;
                _valueCollectionCredorDevedorClassFornecedorChanged = false;
                 _valueCollectionCredorDevedorClassFornecedorCommitedChanged = false;
                _collectionCredorDevedorClassFornecedorRemovidos = new List<Entidades.CredorDevedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CredorDevedorClass>();
                }
                else{ 
                   Entidades.CredorDevedorClass search = new Entidades.CredorDevedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CredorDevedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.CredorDevedorClass>().ToList());
                 }
                 _valueCollectionCredorDevedorClassFornecedor = new BindingList<Entidades.CredorDevedorClass>(oc); 
                 _collectionCredorDevedorClassFornecedorOriginal= (from a in _valueCollectionCredorDevedorClassFornecedor select a.ID).ToList();
                 _valueCollectionCredorDevedorClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionCredorDevedorClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCredorDevedorClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionDeclaracaoImportacaoClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionDeclaracaoImportacaoClassFornecedorChanged = true;
                  _valueCollectionDeclaracaoImportacaoClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionDeclaracaoImportacaoClassFornecedorChanged = true; 
                  _valueCollectionDeclaracaoImportacaoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.DeclaracaoImportacaoClass item in e.OldItems) 
                 { 
                     _collectionDeclaracaoImportacaoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionDeclaracaoImportacaoClassFornecedorChanged = true; 
                  _valueCollectionDeclaracaoImportacaoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.DeclaracaoImportacaoClass item in _valueCollectionDeclaracaoImportacaoClassFornecedor) 
                 { 
                     _collectionDeclaracaoImportacaoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionDeclaracaoImportacaoClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.DeclaracaoImportacaoClass> oc;
                _valueCollectionDeclaracaoImportacaoClassFornecedorChanged = false;
                 _valueCollectionDeclaracaoImportacaoClassFornecedorCommitedChanged = false;
                _collectionDeclaracaoImportacaoClassFornecedorRemovidos = new List<Entidades.DeclaracaoImportacaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.DeclaracaoImportacaoClass>();
                }
                else{ 
                   Entidades.DeclaracaoImportacaoClass search = new Entidades.DeclaracaoImportacaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.DeclaracaoImportacaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this)                    }                       ).Cast<Entidades.DeclaracaoImportacaoClass>().ToList());
                 }
                 _valueCollectionDeclaracaoImportacaoClassFornecedor = new BindingList<Entidades.DeclaracaoImportacaoClass>(oc); 
                 _collectionDeclaracaoImportacaoClassFornecedorOriginal= (from a in _valueCollectionDeclaracaoImportacaoClassFornecedor select a.ID).ToList();
                 _valueCollectionDeclaracaoImportacaoClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionDeclaracaoImportacaoClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionDeclaracaoImportacaoClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionEpiFornecedorClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEpiFornecedorClassFornecedorChanged = true;
                  _valueCollectionEpiFornecedorClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEpiFornecedorClassFornecedorChanged = true; 
                  _valueCollectionEpiFornecedorClassFornecedorCommitedChanged = true;
                 foreach (Entidades.EpiFornecedorClass item in e.OldItems) 
                 { 
                     _collectionEpiFornecedorClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEpiFornecedorClassFornecedorChanged = true; 
                  _valueCollectionEpiFornecedorClassFornecedorCommitedChanged = true;
                 foreach (Entidades.EpiFornecedorClass item in _valueCollectionEpiFornecedorClassFornecedor) 
                 { 
                     _collectionEpiFornecedorClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEpiFornecedorClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.EpiFornecedorClass> oc;
                _valueCollectionEpiFornecedorClassFornecedorChanged = false;
                 _valueCollectionEpiFornecedorClassFornecedorCommitedChanged = false;
                _collectionEpiFornecedorClassFornecedorRemovidos = new List<Entidades.EpiFornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EpiFornecedorClass>();
                }
                else{ 
                   Entidades.EpiFornecedorClass search = new Entidades.EpiFornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EpiFornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.EpiFornecedorClass>().ToList());
                 }
                 _valueCollectionEpiFornecedorClassFornecedor = new BindingList<Entidades.EpiFornecedorClass>(oc); 
                 _collectionEpiFornecedorClassFornecedorOriginal= (from a in _valueCollectionEpiFornecedorClassFornecedor select a.ID).ToList();
                 _valueCollectionEpiFornecedorClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionEpiFornecedorClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEpiFornecedorClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFornecedorContatoClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFornecedorContatoClassFornecedorChanged = true;
                  _valueCollectionFornecedorContatoClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFornecedorContatoClassFornecedorChanged = true; 
                  _valueCollectionFornecedorContatoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.FornecedorContatoClass item in e.OldItems) 
                 { 
                     _collectionFornecedorContatoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFornecedorContatoClassFornecedorChanged = true; 
                  _valueCollectionFornecedorContatoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.FornecedorContatoClass item in _valueCollectionFornecedorContatoClassFornecedor) 
                 { 
                     _collectionFornecedorContatoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFornecedorContatoClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.FornecedorContatoClass> oc;
                _valueCollectionFornecedorContatoClassFornecedorChanged = false;
                 _valueCollectionFornecedorContatoClassFornecedorCommitedChanged = false;
                _collectionFornecedorContatoClassFornecedorRemovidos = new List<Entidades.FornecedorContatoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FornecedorContatoClass>();
                }
                else{ 
                   Entidades.FornecedorContatoClass search = new Entidades.FornecedorContatoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FornecedorContatoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.FornecedorContatoClass>().ToList());
                 }
                 _valueCollectionFornecedorContatoClassFornecedor = new BindingList<Entidades.FornecedorContatoClass>(oc); 
                 _collectionFornecedorContatoClassFornecedorOriginal= (from a in _valueCollectionFornecedorContatoClassFornecedor select a.ID).ToList();
                 _valueCollectionFornecedorContatoClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionFornecedorContatoClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFornecedorContatoClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraEpiClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraEpiClassFornecedorChanged = true;
                  _valueCollectionHistoricoCompraEpiClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraEpiClassFornecedorChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassFornecedorCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraEpiClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraEpiClassFornecedorChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassFornecedorCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in _valueCollectionHistoricoCompraEpiClassFornecedor) 
                 { 
                     _collectionHistoricoCompraEpiClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraEpiClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraEpiClass> oc;
                _valueCollectionHistoricoCompraEpiClassFornecedorChanged = false;
                 _valueCollectionHistoricoCompraEpiClassFornecedorCommitedChanged = false;
                _collectionHistoricoCompraEpiClassFornecedorRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraEpiClass>();
                }
                else{ 
                   Entidades.HistoricoCompraEpiClass search = new Entidades.HistoricoCompraEpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraEpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.HistoricoCompraEpiClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraEpiClassFornecedor = new BindingList<Entidades.HistoricoCompraEpiClass>(oc); 
                 _collectionHistoricoCompraEpiClassFornecedorOriginal= (from a in _valueCollectionHistoricoCompraEpiClassFornecedor select a.ID).ToList();
                 _valueCollectionHistoricoCompraEpiClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraEpiClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraEpiClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraMaterialClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraMaterialClassFornecedorChanged = true;
                  _valueCollectionHistoricoCompraMaterialClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraMaterialClassFornecedorChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassFornecedorCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraMaterialClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraMaterialClassFornecedorChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassFornecedorCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in _valueCollectionHistoricoCompraMaterialClassFornecedor) 
                 { 
                     _collectionHistoricoCompraMaterialClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraMaterialClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraMaterialClass> oc;
                _valueCollectionHistoricoCompraMaterialClassFornecedorChanged = false;
                 _valueCollectionHistoricoCompraMaterialClassFornecedorCommitedChanged = false;
                _collectionHistoricoCompraMaterialClassFornecedorRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraMaterialClass>();
                }
                else{ 
                   Entidades.HistoricoCompraMaterialClass search = new Entidades.HistoricoCompraMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.HistoricoCompraMaterialClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraMaterialClassFornecedor = new BindingList<Entidades.HistoricoCompraMaterialClass>(oc); 
                 _collectionHistoricoCompraMaterialClassFornecedorOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassFornecedor select a.ID).ToList();
                 _valueCollectionHistoricoCompraMaterialClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraMaterialClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraMaterialClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraProdutoClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraProdutoClassFornecedorChanged = true;
                  _valueCollectionHistoricoCompraProdutoClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraProdutoClassFornecedorChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraProdutoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraProdutoClassFornecedorChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in _valueCollectionHistoricoCompraProdutoClassFornecedor) 
                 { 
                     _collectionHistoricoCompraProdutoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraProdutoClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraProdutoClass> oc;
                _valueCollectionHistoricoCompraProdutoClassFornecedorChanged = false;
                 _valueCollectionHistoricoCompraProdutoClassFornecedorCommitedChanged = false;
                _collectionHistoricoCompraProdutoClassFornecedorRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraProdutoClass>();
                }
                else{ 
                   Entidades.HistoricoCompraProdutoClass search = new Entidades.HistoricoCompraProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.HistoricoCompraProdutoClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraProdutoClassFornecedor = new BindingList<Entidades.HistoricoCompraProdutoClass>(oc); 
                 _collectionHistoricoCompraProdutoClassFornecedorOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassFornecedor select a.ID).ToList();
                 _valueCollectionHistoricoCompraProdutoClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraProdutoClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraProdutoClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionLoteClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLoteClassFornecedorChanged = true;
                  _valueCollectionLoteClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLoteClassFornecedorChanged = true; 
                  _valueCollectionLoteClassFornecedorCommitedChanged = true;
                 foreach (Entidades.LoteClass item in e.OldItems) 
                 { 
                     _collectionLoteClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLoteClassFornecedorChanged = true; 
                  _valueCollectionLoteClassFornecedorCommitedChanged = true;
                 foreach (Entidades.LoteClass item in _valueCollectionLoteClassFornecedor) 
                 { 
                     _collectionLoteClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLoteClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.LoteClass> oc;
                _valueCollectionLoteClassFornecedorChanged = false;
                 _valueCollectionLoteClassFornecedorCommitedChanged = false;
                _collectionLoteClassFornecedorRemovidos = new List<Entidades.LoteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LoteClass>();
                }
                else{ 
                   Entidades.LoteClass search = new Entidades.LoteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LoteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.LoteClass>().ToList());
                 }
                 _valueCollectionLoteClassFornecedor = new BindingList<Entidades.LoteClass>(oc); 
                 _collectionLoteClassFornecedorOriginal= (from a in _valueCollectionLoteClassFornecedor select a.ID).ToList();
                 _valueCollectionLoteClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionLoteClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLoteClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMaterialFornecedorClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialFornecedorClassFornecedorChanged = true;
                  _valueCollectionMaterialFornecedorClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialFornecedorClassFornecedorChanged = true; 
                  _valueCollectionMaterialFornecedorClassFornecedorCommitedChanged = true;
                 foreach (Entidades.MaterialFornecedorClass item in e.OldItems) 
                 { 
                     _collectionMaterialFornecedorClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialFornecedorClassFornecedorChanged = true; 
                  _valueCollectionMaterialFornecedorClassFornecedorCommitedChanged = true;
                 foreach (Entidades.MaterialFornecedorClass item in _valueCollectionMaterialFornecedorClassFornecedor) 
                 { 
                     _collectionMaterialFornecedorClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialFornecedorClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialFornecedorClass> oc;
                _valueCollectionMaterialFornecedorClassFornecedorChanged = false;
                 _valueCollectionMaterialFornecedorClassFornecedorCommitedChanged = false;
                _collectionMaterialFornecedorClassFornecedorRemovidos = new List<Entidades.MaterialFornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialFornecedorClass>();
                }
                else{ 
                   Entidades.MaterialFornecedorClass search = new Entidades.MaterialFornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialFornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.MaterialFornecedorClass>().ToList());
                 }
                 _valueCollectionMaterialFornecedorClassFornecedor = new BindingList<Entidades.MaterialFornecedorClass>(oc); 
                 _collectionMaterialFornecedorClassFornecedorOriginal= (from a in _valueCollectionMaterialFornecedorClassFornecedor select a.ID).ToList();
                 _valueCollectionMaterialFornecedorClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionMaterialFornecedorClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialFornecedorClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNotaFiscalEntradaClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNotaFiscalEntradaClassFornecedorChanged = true;
                  _valueCollectionNotaFiscalEntradaClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNotaFiscalEntradaClassFornecedorChanged = true; 
                  _valueCollectionNotaFiscalEntradaClassFornecedorCommitedChanged = true;
                 foreach (Entidades.NotaFiscalEntradaClass item in e.OldItems) 
                 { 
                     _collectionNotaFiscalEntradaClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNotaFiscalEntradaClassFornecedorChanged = true; 
                  _valueCollectionNotaFiscalEntradaClassFornecedorCommitedChanged = true;
                 foreach (Entidades.NotaFiscalEntradaClass item in _valueCollectionNotaFiscalEntradaClassFornecedor) 
                 { 
                     _collectionNotaFiscalEntradaClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNotaFiscalEntradaClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.NotaFiscalEntradaClass> oc;
                _valueCollectionNotaFiscalEntradaClassFornecedorChanged = false;
                 _valueCollectionNotaFiscalEntradaClassFornecedorCommitedChanged = false;
                _collectionNotaFiscalEntradaClassFornecedorRemovidos = new List<Entidades.NotaFiscalEntradaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NotaFiscalEntradaClass>();
                }
                else{ 
                   Entidades.NotaFiscalEntradaClass search = new Entidades.NotaFiscalEntradaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NotaFiscalEntradaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.NotaFiscalEntradaClass>().ToList());
                 }
                 _valueCollectionNotaFiscalEntradaClassFornecedor = new BindingList<Entidades.NotaFiscalEntradaClass>(oc); 
                 _collectionNotaFiscalEntradaClassFornecedorOriginal= (from a in _valueCollectionNotaFiscalEntradaClassFornecedor select a.ID).ToList();
                 _valueCollectionNotaFiscalEntradaClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionNotaFiscalEntradaClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNotaFiscalEntradaClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoCompraClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoCompraClassFornecedorChanged = true;
                  _valueCollectionOrcamentoCompraClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoCompraClassFornecedorChanged = true; 
                  _valueCollectionOrcamentoCompraClassFornecedorCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoCompraClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoCompraClassFornecedorChanged = true; 
                  _valueCollectionOrcamentoCompraClassFornecedorCommitedChanged = true;
                 foreach (Entidades.OrcamentoCompraClass item in _valueCollectionOrcamentoCompraClassFornecedor) 
                 { 
                     _collectionOrcamentoCompraClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoCompraClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoCompraClass> oc;
                _valueCollectionOrcamentoCompraClassFornecedorChanged = false;
                 _valueCollectionOrcamentoCompraClassFornecedorCommitedChanged = false;
                _collectionOrcamentoCompraClassFornecedorRemovidos = new List<Entidades.OrcamentoCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoCompraClass>();
                }
                else{ 
                   Entidades.OrcamentoCompraClass search = new Entidades.OrcamentoCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.OrcamentoCompraClass>().ToList());
                 }
                 _valueCollectionOrcamentoCompraClassFornecedor = new BindingList<Entidades.OrcamentoCompraClass>(oc); 
                 _collectionOrcamentoCompraClassFornecedorOriginal= (from a in _valueCollectionOrcamentoCompraClassFornecedor select a.ID).ToList();
                 _valueCollectionOrcamentoCompraClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoCompraClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoCompraClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemCompraClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemCompraClassFornecedorChanged = true;
                  _valueCollectionOrdemCompraClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemCompraClassFornecedorChanged = true; 
                  _valueCollectionOrdemCompraClassFornecedorCommitedChanged = true;
                 foreach (Entidades.OrdemCompraClass item in e.OldItems) 
                 { 
                     _collectionOrdemCompraClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemCompraClassFornecedorChanged = true; 
                  _valueCollectionOrdemCompraClassFornecedorCommitedChanged = true;
                 foreach (Entidades.OrdemCompraClass item in _valueCollectionOrdemCompraClassFornecedor) 
                 { 
                     _collectionOrdemCompraClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemCompraClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemCompraClass> oc;
                _valueCollectionOrdemCompraClassFornecedorChanged = false;
                 _valueCollectionOrdemCompraClassFornecedorCommitedChanged = false;
                _collectionOrdemCompraClassFornecedorRemovidos = new List<Entidades.OrdemCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemCompraClass>();
                }
                else{ 
                   Entidades.OrdemCompraClass search = new Entidades.OrdemCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.OrdemCompraClass>().ToList());
                 }
                 _valueCollectionOrdemCompraClassFornecedor = new BindingList<Entidades.OrdemCompraClass>(oc); 
                 _collectionOrdemCompraClassFornecedorOriginal= (from a in _valueCollectionOrdemCompraClassFornecedor select a.ID).ToList();
                 _valueCollectionOrdemCompraClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionOrdemCompraClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemCompraClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEnvioTerceirosClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorChanged = true;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedor) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEnvioTerceirosClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass> oc;
                _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorChanged = false;
                 _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorCommitedChanged = false;
                _collectionOrdemProducaoEnvioTerceirosClassFornecedorRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEnvioTerceirosClass search = new Entidades.OrdemProducaoEnvioTerceirosClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.OrdemProducaoEnvioTerceirosClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedor = new BindingList<Entidades.OrdemProducaoEnvioTerceirosClass>(oc); 
                 _collectionOrdemProducaoEnvioTerceirosClassFornecedorOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedor select a.ID).ToList();
                 _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEnvioTerceirosClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEnvioTerceirosClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPostoTrabalhoClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPostoTrabalhoClassFornecedorChanged = true;
                  _valueCollectionPostoTrabalhoClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPostoTrabalhoClassFornecedorChanged = true; 
                  _valueCollectionPostoTrabalhoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionPostoTrabalhoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPostoTrabalhoClassFornecedorChanged = true; 
                  _valueCollectionPostoTrabalhoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in _valueCollectionPostoTrabalhoClassFornecedor) 
                 { 
                     _collectionPostoTrabalhoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPostoTrabalhoClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.PostoTrabalhoClass> oc;
                _valueCollectionPostoTrabalhoClassFornecedorChanged = false;
                 _valueCollectionPostoTrabalhoClassFornecedorCommitedChanged = false;
                _collectionPostoTrabalhoClassFornecedorRemovidos = new List<Entidades.PostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PostoTrabalhoClass>();
                }
                else{ 
                   Entidades.PostoTrabalhoClass search = new Entidades.PostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.PostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionPostoTrabalhoClassFornecedor = new BindingList<Entidades.PostoTrabalhoClass>(oc); 
                 _collectionPostoTrabalhoClassFornecedorOriginal= (from a in _valueCollectionPostoTrabalhoClassFornecedor select a.ID).ToList();
                 _valueCollectionPostoTrabalhoClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionPostoTrabalhoClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPostoTrabalhoClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoFornecedorClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoFornecedorClassFornecedorChanged = true;
                  _valueCollectionProdutoFornecedorClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoFornecedorClassFornecedorChanged = true; 
                  _valueCollectionProdutoFornecedorClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ProdutoFornecedorClass item in e.OldItems) 
                 { 
                     _collectionProdutoFornecedorClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoFornecedorClassFornecedorChanged = true; 
                  _valueCollectionProdutoFornecedorClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ProdutoFornecedorClass item in _valueCollectionProdutoFornecedorClassFornecedor) 
                 { 
                     _collectionProdutoFornecedorClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoFornecedorClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoFornecedorClass> oc;
                _valueCollectionProdutoFornecedorClassFornecedorChanged = false;
                 _valueCollectionProdutoFornecedorClassFornecedorCommitedChanged = false;
                _collectionProdutoFornecedorClassFornecedorRemovidos = new List<Entidades.ProdutoFornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoFornecedorClass>();
                }
                else{ 
                   Entidades.ProdutoFornecedorClass search = new Entidades.ProdutoFornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoFornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.ProdutoFornecedorClass>().ToList());
                 }
                 _valueCollectionProdutoFornecedorClassFornecedor = new BindingList<Entidades.ProdutoFornecedorClass>(oc); 
                 _collectionProdutoFornecedorClassFornecedorOriginal= (from a in _valueCollectionProdutoFornecedorClassFornecedor select a.ID).ToList();
                 _valueCollectionProdutoFornecedorClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionProdutoFornecedorClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoFornecedorClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionServicoClassFornecedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionServicoClassFornecedorChanged = true;
                  _valueCollectionServicoClassFornecedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionServicoClassFornecedorChanged = true; 
                  _valueCollectionServicoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ServicoClass item in e.OldItems) 
                 { 
                     _collectionServicoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionServicoClassFornecedorChanged = true; 
                  _valueCollectionServicoClassFornecedorCommitedChanged = true;
                 foreach (Entidades.ServicoClass item in _valueCollectionServicoClassFornecedor) 
                 { 
                     _collectionServicoClassFornecedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionServicoClassFornecedor()
         {
            try
            {
                 ObservableCollection<Entidades.ServicoClass> oc;
                _valueCollectionServicoClassFornecedorChanged = false;
                 _valueCollectionServicoClassFornecedorCommitedChanged = false;
                _collectionServicoClassFornecedorRemovidos = new List<Entidades.ServicoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ServicoClass>();
                }
                else{ 
                   Entidades.ServicoClass search = new Entidades.ServicoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ServicoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Fornecedor", this),                     }                       ).Cast<Entidades.ServicoClass>().ToList());
                 }
                 _valueCollectionServicoClassFornecedor = new BindingList<Entidades.ServicoClass>(oc); 
                 _collectionServicoClassFornecedorOriginal= (from a in _valueCollectionServicoClassFornecedor select a.ID).ToList();
                 _valueCollectionServicoClassFornecedorLoaded = true;
                 oc.CollectionChanged += CollectionServicoClassFornecedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionServicoClassFornecedor+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(RazaoSocial))
                {
                    throw new Exception(ErroRazaoSocialObrigatorio);
                }
                if (RazaoSocial.Length >255)
                {
                    throw new Exception( ErroRazaoSocialComprimento);
                }
                if (string.IsNullOrEmpty(NomeFantasia))
                {
                    throw new Exception(ErroNomeFantasiaObrigatorio);
                }
                if (NomeFantasia.Length >255)
                {
                    throw new Exception( ErroNomeFantasiaComprimento);
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
                    "  public.fornecedor  " +
                    "WHERE " +
                    "  id_fornecedor = :id";
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
                        "  public.fornecedor   " +
                        "SET  " + 
                        "  for_razao_social = :for_razao_social, " + 
                        "  for_nome_fantasia = :for_nome_fantasia, " + 
                        "  for_cnpj = :for_cnpj, " + 
                        "  for_insc_estadual = :for_insc_estadual, " + 
                        "  for_insc_municipal = :for_insc_municipal, " + 
                        "  for_endereco = :for_endereco, " + 
                        "  for_bairro = :for_bairro, " + 
                        "  for_cep = :for_cep, " + 
                        "  for_fone1 = :for_fone1, " + 
                        "  for_fone2 = :for_fone2, " + 
                        "  for_fone3 = :for_fone3, " + 
                        "  for_fax = :for_fax, " + 
                        "  for_email = :for_email, " + 
                        "  for_site = :for_site, " + 
                        "  for_obs = :for_obs, " + 
                        "  for_tipo_pessoa = :for_tipo_pessoa, " + 
                        "  for_end_numero = :for_end_numero, " + 
                        "  for_end_complemento = :for_end_complemento, " + 
                        "  id_estado = :id_estado, " + 
                        "  for_banco = :for_banco, " + 
                        "  for_agencia = :for_agencia, " + 
                        "  for_conta = :for_conta, " + 
                        "  for_contato = :for_contato, " + 
                        "  for_envio_email = :for_envio_email, " + 
                        "  for_email_pedido = :for_email_pedido, " + 
                        "  for_email_cotacao = :for_email_cotacao, " + 
                        "  for_realiza_recebimento = :for_realiza_recebimento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  id_cidade = :id_cidade, " + 
                        "  id_forma_pagamento = :id_forma_pagamento, " + 
                        "  for_estrangeiro = :for_estrangeiro, " + 
                        "  for_inscricao_suframa = :for_inscricao_suframa, " + 
                        "  for_email_danfe = :for_email_danfe, " + 
                        "  for_email_xml = :for_email_xml, " + 
                        "  for_pais = :for_pais, " + 
                        "  for_codigo_pais = :for_codigo_pais, " + 
                        "  for_indicador_ie = :for_indicador_ie, " + 
                        "  for_conta_revisar_recebimento = :for_conta_revisar_recebimento "+
                        "WHERE  " +
                        "  id_fornecedor = :id " +
                        "RETURNING id_fornecedor;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.fornecedor " +
                        "( " +
                        "  for_razao_social , " + 
                        "  for_nome_fantasia , " + 
                        "  for_cnpj , " + 
                        "  for_insc_estadual , " + 
                        "  for_insc_municipal , " + 
                        "  for_endereco , " + 
                        "  for_bairro , " + 
                        "  for_cep , " + 
                        "  for_fone1 , " + 
                        "  for_fone2 , " + 
                        "  for_fone3 , " + 
                        "  for_fax , " + 
                        "  for_email , " + 
                        "  for_site , " + 
                        "  for_obs , " + 
                        "  for_tipo_pessoa , " + 
                        "  for_end_numero , " + 
                        "  for_end_complemento , " + 
                        "  id_estado , " + 
                        "  for_banco , " + 
                        "  for_agencia , " + 
                        "  for_conta , " + 
                        "  for_contato , " + 
                        "  for_envio_email , " + 
                        "  for_email_pedido , " + 
                        "  for_email_cotacao , " + 
                        "  for_realiza_recebimento , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_conta_bancaria , " + 
                        "  id_centro_custo_lucro , " + 
                        "  id_cidade , " + 
                        "  id_forma_pagamento , " + 
                        "  for_estrangeiro , " + 
                        "  for_inscricao_suframa , " + 
                        "  for_email_danfe , " + 
                        "  for_email_xml , " + 
                        "  for_pais , " + 
                        "  for_codigo_pais , " + 
                        "  for_indicador_ie , " + 
                        "  for_conta_revisar_recebimento  "+
                        ")  " +
                        "VALUES ( " +
                        "  :for_razao_social , " + 
                        "  :for_nome_fantasia , " + 
                        "  :for_cnpj , " + 
                        "  :for_insc_estadual , " + 
                        "  :for_insc_municipal , " + 
                        "  :for_endereco , " + 
                        "  :for_bairro , " + 
                        "  :for_cep , " + 
                        "  :for_fone1 , " + 
                        "  :for_fone2 , " + 
                        "  :for_fone3 , " + 
                        "  :for_fax , " + 
                        "  :for_email , " + 
                        "  :for_site , " + 
                        "  :for_obs , " + 
                        "  :for_tipo_pessoa , " + 
                        "  :for_end_numero , " + 
                        "  :for_end_complemento , " + 
                        "  :id_estado , " + 
                        "  :for_banco , " + 
                        "  :for_agencia , " + 
                        "  :for_conta , " + 
                        "  :for_contato , " + 
                        "  :for_envio_email , " + 
                        "  :for_email_pedido , " + 
                        "  :for_email_cotacao , " + 
                        "  :for_realiza_recebimento , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_conta_bancaria , " + 
                        "  :id_centro_custo_lucro , " + 
                        "  :id_cidade , " + 
                        "  :id_forma_pagamento , " + 
                        "  :for_estrangeiro , " + 
                        "  :for_inscricao_suframa , " + 
                        "  :for_email_danfe , " + 
                        "  :for_email_xml , " + 
                        "  :for_pais , " + 
                        "  :for_codigo_pais , " + 
                        "  :for_indicador_ie , " + 
                        "  :for_conta_revisar_recebimento  "+
                        ")RETURNING id_fornecedor;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_razao_social", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RazaoSocial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_nome_fantasia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeFantasia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnpj ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_insc_estadual", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InscEstadual ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_insc_municipal", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InscMunicipal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_endereco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Endereco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_bairro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Bairro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_cep", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cep ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_fone1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_fone2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_fone3", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_fax", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fax ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_email", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Email ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_site", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Site ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_obs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Obs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_tipo_pessoa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.TipoPessoa.HasValue ? (object)Convert.ToInt16(this.TipoPessoa) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_end_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EndNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_end_complemento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EndComplemento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Estado==null ? (object) DBNull.Value : this.Estado.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_banco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Banco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_agencia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Agencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_conta", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Conta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_contato", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Contato ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_envio_email", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnvioEmail ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_email_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_email_cotacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailCotacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_realiza_recebimento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RealizaRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cidade", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cidade==null ? (object) DBNull.Value : this.Cidade.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_forma_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FormaPagamento==null ? (object) DBNull.Value : this.FormaPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_estrangeiro", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Estrangeiro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_inscricao_suframa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InscricaoSuframa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_email_danfe", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailDanfe ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_email_xml", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailXml ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_pais", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_codigo_pais", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoPais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_indicador_ie", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.IndicadorIe);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("for_conta_revisar_recebimento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ContaRevisarRecebimento ?? DBNull.Value;

 
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
 if (CollectionContaPagarClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassFornecedor+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaRecorrenteClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaRecorrenteClassFornecedor+"\r\n";
                foreach (Entidades.ContaRecorrenteClass tmp in CollectionContaRecorrenteClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContratoFornecimentoClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContratoFornecimentoClassFornecedor+"\r\n";
                foreach (Entidades.ContratoFornecimentoClass tmp in CollectionContratoFornecimentoClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionCredorDevedorClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCredorDevedorClassFornecedor+"\r\n";
                foreach (Entidades.CredorDevedorClass tmp in CollectionCredorDevedorClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionDeclaracaoImportacaoClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionDeclaracaoImportacaoClassFornecedor+"\r\n";
                foreach (Entidades.DeclaracaoImportacaoClass tmp in CollectionDeclaracaoImportacaoClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionEpiFornecedorClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEpiFornecedorClassFornecedor+"\r\n";
                foreach (Entidades.EpiFornecedorClass tmp in CollectionEpiFornecedorClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFornecedorContatoClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFornecedorContatoClassFornecedor+"\r\n";
                foreach (Entidades.FornecedorContatoClass tmp in CollectionFornecedorContatoClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraEpiClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraEpiClassFornecedor+"\r\n";
                foreach (Entidades.HistoricoCompraEpiClass tmp in CollectionHistoricoCompraEpiClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraMaterialClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraMaterialClassFornecedor+"\r\n";
                foreach (Entidades.HistoricoCompraMaterialClass tmp in CollectionHistoricoCompraMaterialClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraProdutoClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraProdutoClassFornecedor+"\r\n";
                foreach (Entidades.HistoricoCompraProdutoClass tmp in CollectionHistoricoCompraProdutoClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionLoteClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLoteClassFornecedor+"\r\n";
                foreach (Entidades.LoteClass tmp in CollectionLoteClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMaterialFornecedorClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialFornecedorClassFornecedor+"\r\n";
                foreach (Entidades.MaterialFornecedorClass tmp in CollectionMaterialFornecedorClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNotaFiscalEntradaClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNotaFiscalEntradaClassFornecedor+"\r\n";
                foreach (Entidades.NotaFiscalEntradaClass tmp in CollectionNotaFiscalEntradaClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoCompraClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoCompraClassFornecedor+"\r\n";
                foreach (Entidades.OrcamentoCompraClass tmp in CollectionOrcamentoCompraClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemCompraClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemCompraClassFornecedor+"\r\n";
                foreach (Entidades.OrdemCompraClass tmp in CollectionOrdemCompraClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEnvioTerceirosClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassFornecedor+"\r\n";
                foreach (Entidades.OrdemProducaoEnvioTerceirosClass tmp in CollectionOrdemProducaoEnvioTerceirosClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPostoTrabalhoClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPostoTrabalhoClassFornecedor+"\r\n";
                foreach (Entidades.PostoTrabalhoClass tmp in CollectionPostoTrabalhoClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoFornecedorClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoFornecedorClassFornecedor+"\r\n";
                foreach (Entidades.ProdutoFornecedorClass tmp in CollectionProdutoFornecedorClassFornecedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionServicoClassFornecedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionServicoClassFornecedor+"\r\n";
                foreach (Entidades.ServicoClass tmp in CollectionServicoClassFornecedor)
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
        public static FornecedorClass CopiarEntidade(FornecedorClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               FornecedorClass toRet = new FornecedorClass(usuario,conn);
 toRet.RazaoSocial= entidadeCopiar.RazaoSocial;
 toRet.NomeFantasia= entidadeCopiar.NomeFantasia;
 toRet.Cnpj= entidadeCopiar.Cnpj;
 toRet.InscEstadual= entidadeCopiar.InscEstadual;
 toRet.InscMunicipal= entidadeCopiar.InscMunicipal;
 toRet.Endereco= entidadeCopiar.Endereco;
 toRet.Bairro= entidadeCopiar.Bairro;
 toRet.Cep= entidadeCopiar.Cep;
 toRet.Fone1= entidadeCopiar.Fone1;
 toRet.Fone2= entidadeCopiar.Fone2;
 toRet.Fone3= entidadeCopiar.Fone3;
 toRet.Fax= entidadeCopiar.Fax;
 toRet.Email= entidadeCopiar.Email;
 toRet.Site= entidadeCopiar.Site;
 toRet.Obs= entidadeCopiar.Obs;
 toRet.TipoPessoa= entidadeCopiar.TipoPessoa;
 toRet.EndNumero= entidadeCopiar.EndNumero;
 toRet.EndComplemento= entidadeCopiar.EndComplemento;
 toRet.Estado= entidadeCopiar.Estado;
 toRet.Banco= entidadeCopiar.Banco;
 toRet.Agencia= entidadeCopiar.Agencia;
 toRet.Conta= entidadeCopiar.Conta;
 toRet.Contato= entidadeCopiar.Contato;
 toRet.EnvioEmail= entidadeCopiar.EnvioEmail;
 toRet.EmailPedido= entidadeCopiar.EmailPedido;
 toRet.EmailCotacao= entidadeCopiar.EmailCotacao;
 toRet.RealizaRecebimento= entidadeCopiar.RealizaRecebimento;
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;
 toRet.Cidade= entidadeCopiar.Cidade;
 toRet.FormaPagamento= entidadeCopiar.FormaPagamento;
 toRet.Estrangeiro= entidadeCopiar.Estrangeiro;
 toRet.InscricaoSuframa= entidadeCopiar.InscricaoSuframa;
 toRet.EmailDanfe= entidadeCopiar.EmailDanfe;
 toRet.EmailXml= entidadeCopiar.EmailXml;
 toRet.Pais= entidadeCopiar.Pais;
 toRet.CodigoPais= entidadeCopiar.CodigoPais;
 toRet.IndicadorIe= entidadeCopiar.IndicadorIe;
 toRet.ContaRevisarRecebimento= entidadeCopiar.ContaRevisarRecebimento;

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
       _razaoSocialOriginal = RazaoSocial;
       _razaoSocialOriginalCommited = _razaoSocialOriginal;
       _nomeFantasiaOriginal = NomeFantasia;
       _nomeFantasiaOriginalCommited = _nomeFantasiaOriginal;
       _cnpjOriginal = Cnpj;
       _cnpjOriginalCommited = _cnpjOriginal;
       _inscEstadualOriginal = InscEstadual;
       _inscEstadualOriginalCommited = _inscEstadualOriginal;
       _inscMunicipalOriginal = InscMunicipal;
       _inscMunicipalOriginalCommited = _inscMunicipalOriginal;
       _enderecoOriginal = Endereco;
       _enderecoOriginalCommited = _enderecoOriginal;
       _bairroOriginal = Bairro;
       _bairroOriginalCommited = _bairroOriginal;
       _cepOriginal = Cep;
       _cepOriginalCommited = _cepOriginal;
       _fone1Original = Fone1;
       _fone1OriginalCommited = _fone1Original;
       _fone2Original = Fone2;
       _fone2OriginalCommited = _fone2Original;
       _fone3Original = Fone3;
       _fone3OriginalCommited = _fone3Original;
       _faxOriginal = Fax;
       _faxOriginalCommited = _faxOriginal;
       _emailOriginal = Email;
       _emailOriginalCommited = _emailOriginal;
       _siteOriginal = Site;
       _siteOriginalCommited = _siteOriginal;
       _obsOriginal = Obs;
       _obsOriginalCommited = _obsOriginal;
       _tipoPessoaOriginal = TipoPessoa;
       _tipoPessoaOriginalCommited = _tipoPessoaOriginal;
       _endNumeroOriginal = EndNumero;
       _endNumeroOriginalCommited = _endNumeroOriginal;
       _endComplementoOriginal = EndComplemento;
       _endComplementoOriginalCommited = _endComplementoOriginal;
       _estadoOriginal = Estado;
       _estadoOriginalCommited = _estadoOriginal;
       _bancoOriginal = Banco;
       _bancoOriginalCommited = _bancoOriginal;
       _agenciaOriginal = Agencia;
       _agenciaOriginalCommited = _agenciaOriginal;
       _contaOriginal = Conta;
       _contaOriginalCommited = _contaOriginal;
       _contatoOriginal = Contato;
       _contatoOriginalCommited = _contatoOriginal;
       _envioEmailOriginal = EnvioEmail;
       _envioEmailOriginalCommited = _envioEmailOriginal;
       _emailPedidoOriginal = EmailPedido;
       _emailPedidoOriginalCommited = _emailPedidoOriginal;
       _emailCotacaoOriginal = EmailCotacao;
       _emailCotacaoOriginalCommited = _emailCotacaoOriginal;
       _realizaRecebimentoOriginal = RealizaRecebimento;
       _realizaRecebimentoOriginalCommited = _realizaRecebimentoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;
       _cidadeOriginal = Cidade;
       _cidadeOriginalCommited = _cidadeOriginal;
       _formaPagamentoOriginal = FormaPagamento;
       _formaPagamentoOriginalCommited = _formaPagamentoOriginal;
       _estrangeiroOriginal = Estrangeiro;
       _estrangeiroOriginalCommited = _estrangeiroOriginal;
       _inscricaoSuframaOriginal = InscricaoSuframa;
       _inscricaoSuframaOriginalCommited = _inscricaoSuframaOriginal;
       _emailDanfeOriginal = EmailDanfe;
       _emailDanfeOriginalCommited = _emailDanfeOriginal;
       _emailXmlOriginal = EmailXml;
       _emailXmlOriginalCommited = _emailXmlOriginal;
       _paisOriginal = Pais;
       _paisOriginalCommited = _paisOriginal;
       _codigoPaisOriginal = CodigoPais;
       _codigoPaisOriginalCommited = _codigoPaisOriginal;
       _indicadorIeOriginal = IndicadorIe;
       _indicadorIeOriginalCommited = _indicadorIeOriginal;
       _contaRevisarRecebimentoOriginal = ContaRevisarRecebimento;
       _contaRevisarRecebimentoOriginalCommited = _contaRevisarRecebimentoOriginal;

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
       _razaoSocialOriginalCommited = RazaoSocial;
       _nomeFantasiaOriginalCommited = NomeFantasia;
       _cnpjOriginalCommited = Cnpj;
       _inscEstadualOriginalCommited = InscEstadual;
       _inscMunicipalOriginalCommited = InscMunicipal;
       _enderecoOriginalCommited = Endereco;
       _bairroOriginalCommited = Bairro;
       _cepOriginalCommited = Cep;
       _fone1OriginalCommited = Fone1;
       _fone2OriginalCommited = Fone2;
       _fone3OriginalCommited = Fone3;
       _faxOriginalCommited = Fax;
       _emailOriginalCommited = Email;
       _siteOriginalCommited = Site;
       _obsOriginalCommited = Obs;
       _tipoPessoaOriginalCommited = TipoPessoa;
       _endNumeroOriginalCommited = EndNumero;
       _endComplementoOriginalCommited = EndComplemento;
       _estadoOriginalCommited = Estado;
       _bancoOriginalCommited = Banco;
       _agenciaOriginalCommited = Agencia;
       _contaOriginalCommited = Conta;
       _contatoOriginalCommited = Contato;
       _envioEmailOriginalCommited = EnvioEmail;
       _emailPedidoOriginalCommited = EmailPedido;
       _emailCotacaoOriginalCommited = EmailCotacao;
       _realizaRecebimentoOriginalCommited = RealizaRecebimento;
       _versionOriginalCommited = Version;
       _contaBancariaOriginalCommited = ContaBancaria;
       _centroCustoLucroOriginalCommited = CentroCustoLucro;
       _cidadeOriginalCommited = Cidade;
       _formaPagamentoOriginalCommited = FormaPagamento;
       _estrangeiroOriginalCommited = Estrangeiro;
       _inscricaoSuframaOriginalCommited = InscricaoSuframa;
       _emailDanfeOriginalCommited = EmailDanfe;
       _emailXmlOriginalCommited = EmailXml;
       _paisOriginalCommited = Pais;
       _codigoPaisOriginalCommited = CodigoPais;
       _indicadorIeOriginalCommited = IndicadorIe;
       _contaRevisarRecebimentoOriginalCommited = ContaRevisarRecebimento;

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
               if (_valueCollectionContaPagarClassFornecedorLoaded) 
               {
                  if (_collectionContaPagarClassFornecedorRemovidos != null) 
                  {
                     _collectionContaPagarClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassFornecedorRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassFornecedorOriginal= (from a in _valueCollectionContaPagarClassFornecedor select a.ID).ToList();
                  _valueCollectionContaPagarClassFornecedorChanged = false;
                  _valueCollectionContaPagarClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionContaRecorrenteClassFornecedorLoaded) 
               {
                  if (_collectionContaRecorrenteClassFornecedorRemovidos != null) 
                  {
                     _collectionContaRecorrenteClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaRecorrenteClassFornecedorRemovidos = new List<Entidades.ContaRecorrenteClass>();
                  }
                  _collectionContaRecorrenteClassFornecedorOriginal= (from a in _valueCollectionContaRecorrenteClassFornecedor select a.ID).ToList();
                  _valueCollectionContaRecorrenteClassFornecedorChanged = false;
                  _valueCollectionContaRecorrenteClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionContratoFornecimentoClassFornecedorLoaded) 
               {
                  if (_collectionContratoFornecimentoClassFornecedorRemovidos != null) 
                  {
                     _collectionContratoFornecimentoClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContratoFornecimentoClassFornecedorRemovidos = new List<Entidades.ContratoFornecimentoClass>();
                  }
                  _collectionContratoFornecimentoClassFornecedorOriginal= (from a in _valueCollectionContratoFornecimentoClassFornecedor select a.ID).ToList();
                  _valueCollectionContratoFornecimentoClassFornecedorChanged = false;
                  _valueCollectionContratoFornecimentoClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionCredorDevedorClassFornecedorLoaded) 
               {
                  if (_collectionCredorDevedorClassFornecedorRemovidos != null) 
                  {
                     _collectionCredorDevedorClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCredorDevedorClassFornecedorRemovidos = new List<Entidades.CredorDevedorClass>();
                  }
                  _collectionCredorDevedorClassFornecedorOriginal= (from a in _valueCollectionCredorDevedorClassFornecedor select a.ID).ToList();
                  _valueCollectionCredorDevedorClassFornecedorChanged = false;
                  _valueCollectionCredorDevedorClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionDeclaracaoImportacaoClassFornecedorLoaded) 
               {
                  if (_collectionDeclaracaoImportacaoClassFornecedorRemovidos != null) 
                  {
                     _collectionDeclaracaoImportacaoClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionDeclaracaoImportacaoClassFornecedorRemovidos = new List<Entidades.DeclaracaoImportacaoClass>();
                  }
                  _collectionDeclaracaoImportacaoClassFornecedorOriginal= (from a in _valueCollectionDeclaracaoImportacaoClassFornecedor select a.ID).ToList();
                  _valueCollectionDeclaracaoImportacaoClassFornecedorChanged = false;
                  _valueCollectionDeclaracaoImportacaoClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionEpiFornecedorClassFornecedorLoaded) 
               {
                  if (_collectionEpiFornecedorClassFornecedorRemovidos != null) 
                  {
                     _collectionEpiFornecedorClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEpiFornecedorClassFornecedorRemovidos = new List<Entidades.EpiFornecedorClass>();
                  }
                  _collectionEpiFornecedorClassFornecedorOriginal= (from a in _valueCollectionEpiFornecedorClassFornecedor select a.ID).ToList();
                  _valueCollectionEpiFornecedorClassFornecedorChanged = false;
                  _valueCollectionEpiFornecedorClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionFornecedorContatoClassFornecedorLoaded) 
               {
                  if (_collectionFornecedorContatoClassFornecedorRemovidos != null) 
                  {
                     _collectionFornecedorContatoClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFornecedorContatoClassFornecedorRemovidos = new List<Entidades.FornecedorContatoClass>();
                  }
                  _collectionFornecedorContatoClassFornecedorOriginal= (from a in _valueCollectionFornecedorContatoClassFornecedor select a.ID).ToList();
                  _valueCollectionFornecedorContatoClassFornecedorChanged = false;
                  _valueCollectionFornecedorContatoClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraEpiClassFornecedorLoaded) 
               {
                  if (_collectionHistoricoCompraEpiClassFornecedorRemovidos != null) 
                  {
                     _collectionHistoricoCompraEpiClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraEpiClassFornecedorRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                  }
                  _collectionHistoricoCompraEpiClassFornecedorOriginal= (from a in _valueCollectionHistoricoCompraEpiClassFornecedor select a.ID).ToList();
                  _valueCollectionHistoricoCompraEpiClassFornecedorChanged = false;
                  _valueCollectionHistoricoCompraEpiClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraMaterialClassFornecedorLoaded) 
               {
                  if (_collectionHistoricoCompraMaterialClassFornecedorRemovidos != null) 
                  {
                     _collectionHistoricoCompraMaterialClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraMaterialClassFornecedorRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                  }
                  _collectionHistoricoCompraMaterialClassFornecedorOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassFornecedor select a.ID).ToList();
                  _valueCollectionHistoricoCompraMaterialClassFornecedorChanged = false;
                  _valueCollectionHistoricoCompraMaterialClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraProdutoClassFornecedorLoaded) 
               {
                  if (_collectionHistoricoCompraProdutoClassFornecedorRemovidos != null) 
                  {
                     _collectionHistoricoCompraProdutoClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraProdutoClassFornecedorRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                  }
                  _collectionHistoricoCompraProdutoClassFornecedorOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassFornecedor select a.ID).ToList();
                  _valueCollectionHistoricoCompraProdutoClassFornecedorChanged = false;
                  _valueCollectionHistoricoCompraProdutoClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionLoteClassFornecedorLoaded) 
               {
                  if (_collectionLoteClassFornecedorRemovidos != null) 
                  {
                     _collectionLoteClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLoteClassFornecedorRemovidos = new List<Entidades.LoteClass>();
                  }
                  _collectionLoteClassFornecedorOriginal= (from a in _valueCollectionLoteClassFornecedor select a.ID).ToList();
                  _valueCollectionLoteClassFornecedorChanged = false;
                  _valueCollectionLoteClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionMaterialFornecedorClassFornecedorLoaded) 
               {
                  if (_collectionMaterialFornecedorClassFornecedorRemovidos != null) 
                  {
                     _collectionMaterialFornecedorClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialFornecedorClassFornecedorRemovidos = new List<Entidades.MaterialFornecedorClass>();
                  }
                  _collectionMaterialFornecedorClassFornecedorOriginal= (from a in _valueCollectionMaterialFornecedorClassFornecedor select a.ID).ToList();
                  _valueCollectionMaterialFornecedorClassFornecedorChanged = false;
                  _valueCollectionMaterialFornecedorClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionNotaFiscalEntradaClassFornecedorLoaded) 
               {
                  if (_collectionNotaFiscalEntradaClassFornecedorRemovidos != null) 
                  {
                     _collectionNotaFiscalEntradaClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNotaFiscalEntradaClassFornecedorRemovidos = new List<Entidades.NotaFiscalEntradaClass>();
                  }
                  _collectionNotaFiscalEntradaClassFornecedorOriginal= (from a in _valueCollectionNotaFiscalEntradaClassFornecedor select a.ID).ToList();
                  _valueCollectionNotaFiscalEntradaClassFornecedorChanged = false;
                  _valueCollectionNotaFiscalEntradaClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoCompraClassFornecedorLoaded) 
               {
                  if (_collectionOrcamentoCompraClassFornecedorRemovidos != null) 
                  {
                     _collectionOrcamentoCompraClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoCompraClassFornecedorRemovidos = new List<Entidades.OrcamentoCompraClass>();
                  }
                  _collectionOrcamentoCompraClassFornecedorOriginal= (from a in _valueCollectionOrcamentoCompraClassFornecedor select a.ID).ToList();
                  _valueCollectionOrcamentoCompraClassFornecedorChanged = false;
                  _valueCollectionOrcamentoCompraClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionOrdemCompraClassFornecedorLoaded) 
               {
                  if (_collectionOrdemCompraClassFornecedorRemovidos != null) 
                  {
                     _collectionOrdemCompraClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemCompraClassFornecedorRemovidos = new List<Entidades.OrdemCompraClass>();
                  }
                  _collectionOrdemCompraClassFornecedorOriginal= (from a in _valueCollectionOrdemCompraClassFornecedor select a.ID).ToList();
                  _valueCollectionOrdemCompraClassFornecedorChanged = false;
                  _valueCollectionOrdemCompraClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded) 
               {
                  if (_collectionOrdemProducaoEnvioTerceirosClassFornecedorRemovidos != null) 
                  {
                     _collectionOrdemProducaoEnvioTerceirosClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEnvioTerceirosClassFornecedorRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassFornecedorOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedor select a.ID).ToList();
                  _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorChanged = false;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionPostoTrabalhoClassFornecedorLoaded) 
               {
                  if (_collectionPostoTrabalhoClassFornecedorRemovidos != null) 
                  {
                     _collectionPostoTrabalhoClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPostoTrabalhoClassFornecedorRemovidos = new List<Entidades.PostoTrabalhoClass>();
                  }
                  _collectionPostoTrabalhoClassFornecedorOriginal= (from a in _valueCollectionPostoTrabalhoClassFornecedor select a.ID).ToList();
                  _valueCollectionPostoTrabalhoClassFornecedorChanged = false;
                  _valueCollectionPostoTrabalhoClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionProdutoFornecedorClassFornecedorLoaded) 
               {
                  if (_collectionProdutoFornecedorClassFornecedorRemovidos != null) 
                  {
                     _collectionProdutoFornecedorClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoFornecedorClassFornecedorRemovidos = new List<Entidades.ProdutoFornecedorClass>();
                  }
                  _collectionProdutoFornecedorClassFornecedorOriginal= (from a in _valueCollectionProdutoFornecedorClassFornecedor select a.ID).ToList();
                  _valueCollectionProdutoFornecedorClassFornecedorChanged = false;
                  _valueCollectionProdutoFornecedorClassFornecedorCommitedChanged = false;
               }
               if (_valueCollectionServicoClassFornecedorLoaded) 
               {
                  if (_collectionServicoClassFornecedorRemovidos != null) 
                  {
                     _collectionServicoClassFornecedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionServicoClassFornecedorRemovidos = new List<Entidades.ServicoClass>();
                  }
                  _collectionServicoClassFornecedorOriginal= (from a in _valueCollectionServicoClassFornecedor select a.ID).ToList();
                  _valueCollectionServicoClassFornecedorChanged = false;
                  _valueCollectionServicoClassFornecedorCommitedChanged = false;
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
               RazaoSocial=_razaoSocialOriginal;
               _razaoSocialOriginalCommited=_razaoSocialOriginal;
               NomeFantasia=_nomeFantasiaOriginal;
               _nomeFantasiaOriginalCommited=_nomeFantasiaOriginal;
               Cnpj=_cnpjOriginal;
               _cnpjOriginalCommited=_cnpjOriginal;
               InscEstadual=_inscEstadualOriginal;
               _inscEstadualOriginalCommited=_inscEstadualOriginal;
               InscMunicipal=_inscMunicipalOriginal;
               _inscMunicipalOriginalCommited=_inscMunicipalOriginal;
               Endereco=_enderecoOriginal;
               _enderecoOriginalCommited=_enderecoOriginal;
               Bairro=_bairroOriginal;
               _bairroOriginalCommited=_bairroOriginal;
               Cep=_cepOriginal;
               _cepOriginalCommited=_cepOriginal;
               Fone1=_fone1Original;
               _fone1OriginalCommited=_fone1Original;
               Fone2=_fone2Original;
               _fone2OriginalCommited=_fone2Original;
               Fone3=_fone3Original;
               _fone3OriginalCommited=_fone3Original;
               Fax=_faxOriginal;
               _faxOriginalCommited=_faxOriginal;
               Email=_emailOriginal;
               _emailOriginalCommited=_emailOriginal;
               Site=_siteOriginal;
               _siteOriginalCommited=_siteOriginal;
               Obs=_obsOriginal;
               _obsOriginalCommited=_obsOriginal;
               TipoPessoa=_tipoPessoaOriginal;
               _tipoPessoaOriginalCommited=_tipoPessoaOriginal;
               EndNumero=_endNumeroOriginal;
               _endNumeroOriginalCommited=_endNumeroOriginal;
               EndComplemento=_endComplementoOriginal;
               _endComplementoOriginalCommited=_endComplementoOriginal;
               Estado=_estadoOriginal;
               _estadoOriginalCommited=_estadoOriginal;
               Banco=_bancoOriginal;
               _bancoOriginalCommited=_bancoOriginal;
               Agencia=_agenciaOriginal;
               _agenciaOriginalCommited=_agenciaOriginal;
               Conta=_contaOriginal;
               _contaOriginalCommited=_contaOriginal;
               Contato=_contatoOriginal;
               _contatoOriginalCommited=_contatoOriginal;
               EnvioEmail=_envioEmailOriginal;
               _envioEmailOriginalCommited=_envioEmailOriginal;
               EmailPedido=_emailPedidoOriginal;
               _emailPedidoOriginalCommited=_emailPedidoOriginal;
               EmailCotacao=_emailCotacaoOriginal;
               _emailCotacaoOriginalCommited=_emailCotacaoOriginal;
               RealizaRecebimento=_realizaRecebimentoOriginal;
               _realizaRecebimentoOriginalCommited=_realizaRecebimentoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;
               Cidade=_cidadeOriginal;
               _cidadeOriginalCommited=_cidadeOriginal;
               FormaPagamento=_formaPagamentoOriginal;
               _formaPagamentoOriginalCommited=_formaPagamentoOriginal;
               Estrangeiro=_estrangeiroOriginal;
               _estrangeiroOriginalCommited=_estrangeiroOriginal;
               InscricaoSuframa=_inscricaoSuframaOriginal;
               _inscricaoSuframaOriginalCommited=_inscricaoSuframaOriginal;
               EmailDanfe=_emailDanfeOriginal;
               _emailDanfeOriginalCommited=_emailDanfeOriginal;
               EmailXml=_emailXmlOriginal;
               _emailXmlOriginalCommited=_emailXmlOriginal;
               Pais=_paisOriginal;
               _paisOriginalCommited=_paisOriginal;
               CodigoPais=_codigoPaisOriginal;
               _codigoPaisOriginalCommited=_codigoPaisOriginal;
               IndicadorIe=_indicadorIeOriginal;
               _indicadorIeOriginalCommited=_indicadorIeOriginal;
               ContaRevisarRecebimento=_contaRevisarRecebimentoOriginal;
               _contaRevisarRecebimentoOriginalCommited=_contaRevisarRecebimentoOriginal;
               if (_valueCollectionContaPagarClassFornecedorLoaded) 
               {
                  CollectionContaPagarClassFornecedor.Clear();
                  foreach(int item in _collectionContaPagarClassFornecedorOriginal)
                  {
                    CollectionContaPagarClassFornecedor.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionContaRecorrenteClassFornecedorLoaded) 
               {
                  CollectionContaRecorrenteClassFornecedor.Clear();
                  foreach(int item in _collectionContaRecorrenteClassFornecedorOriginal)
                  {
                    CollectionContaRecorrenteClassFornecedor.Add(Entidades.ContaRecorrenteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaRecorrenteClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionContratoFornecimentoClassFornecedorLoaded) 
               {
                  CollectionContratoFornecimentoClassFornecedor.Clear();
                  foreach(int item in _collectionContratoFornecimentoClassFornecedorOriginal)
                  {
                    CollectionContratoFornecimentoClassFornecedor.Add(Entidades.ContratoFornecimentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContratoFornecimentoClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionCredorDevedorClassFornecedorLoaded) 
               {
                  CollectionCredorDevedorClassFornecedor.Clear();
                  foreach(int item in _collectionCredorDevedorClassFornecedorOriginal)
                  {
                    CollectionCredorDevedorClassFornecedor.Add(Entidades.CredorDevedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCredorDevedorClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionDeclaracaoImportacaoClassFornecedorLoaded) 
               {
                  CollectionDeclaracaoImportacaoClassFornecedor.Clear();
                  foreach(int item in _collectionDeclaracaoImportacaoClassFornecedorOriginal)
                  {
                    CollectionDeclaracaoImportacaoClassFornecedor.Add(Entidades.DeclaracaoImportacaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionDeclaracaoImportacaoClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionEpiFornecedorClassFornecedorLoaded) 
               {
                  CollectionEpiFornecedorClassFornecedor.Clear();
                  foreach(int item in _collectionEpiFornecedorClassFornecedorOriginal)
                  {
                    CollectionEpiFornecedorClassFornecedor.Add(Entidades.EpiFornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEpiFornecedorClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionFornecedorContatoClassFornecedorLoaded) 
               {
                  CollectionFornecedorContatoClassFornecedor.Clear();
                  foreach(int item in _collectionFornecedorContatoClassFornecedorOriginal)
                  {
                    CollectionFornecedorContatoClassFornecedor.Add(Entidades.FornecedorContatoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFornecedorContatoClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraEpiClassFornecedorLoaded) 
               {
                  CollectionHistoricoCompraEpiClassFornecedor.Clear();
                  foreach(int item in _collectionHistoricoCompraEpiClassFornecedorOriginal)
                  {
                    CollectionHistoricoCompraEpiClassFornecedor.Add(Entidades.HistoricoCompraEpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraEpiClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraMaterialClassFornecedorLoaded) 
               {
                  CollectionHistoricoCompraMaterialClassFornecedor.Clear();
                  foreach(int item in _collectionHistoricoCompraMaterialClassFornecedorOriginal)
                  {
                    CollectionHistoricoCompraMaterialClassFornecedor.Add(Entidades.HistoricoCompraMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraMaterialClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraProdutoClassFornecedorLoaded) 
               {
                  CollectionHistoricoCompraProdutoClassFornecedor.Clear();
                  foreach(int item in _collectionHistoricoCompraProdutoClassFornecedorOriginal)
                  {
                    CollectionHistoricoCompraProdutoClassFornecedor.Add(Entidades.HistoricoCompraProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraProdutoClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionLoteClassFornecedorLoaded) 
               {
                  CollectionLoteClassFornecedor.Clear();
                  foreach(int item in _collectionLoteClassFornecedorOriginal)
                  {
                    CollectionLoteClassFornecedor.Add(Entidades.LoteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLoteClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionMaterialFornecedorClassFornecedorLoaded) 
               {
                  CollectionMaterialFornecedorClassFornecedor.Clear();
                  foreach(int item in _collectionMaterialFornecedorClassFornecedorOriginal)
                  {
                    CollectionMaterialFornecedorClassFornecedor.Add(Entidades.MaterialFornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialFornecedorClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionNotaFiscalEntradaClassFornecedorLoaded) 
               {
                  CollectionNotaFiscalEntradaClassFornecedor.Clear();
                  foreach(int item in _collectionNotaFiscalEntradaClassFornecedorOriginal)
                  {
                    CollectionNotaFiscalEntradaClassFornecedor.Add(Entidades.NotaFiscalEntradaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNotaFiscalEntradaClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoCompraClassFornecedorLoaded) 
               {
                  CollectionOrcamentoCompraClassFornecedor.Clear();
                  foreach(int item in _collectionOrcamentoCompraClassFornecedorOriginal)
                  {
                    CollectionOrcamentoCompraClassFornecedor.Add(Entidades.OrcamentoCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoCompraClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionOrdemCompraClassFornecedorLoaded) 
               {
                  CollectionOrdemCompraClassFornecedor.Clear();
                  foreach(int item in _collectionOrdemCompraClassFornecedorOriginal)
                  {
                    CollectionOrdemCompraClassFornecedor.Add(Entidades.OrdemCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemCompraClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded) 
               {
                  CollectionOrdemProducaoEnvioTerceirosClassFornecedor.Clear();
                  foreach(int item in _collectionOrdemProducaoEnvioTerceirosClassFornecedorOriginal)
                  {
                    CollectionOrdemProducaoEnvioTerceirosClassFornecedor.Add(Entidades.OrdemProducaoEnvioTerceirosClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionPostoTrabalhoClassFornecedorLoaded) 
               {
                  CollectionPostoTrabalhoClassFornecedor.Clear();
                  foreach(int item in _collectionPostoTrabalhoClassFornecedorOriginal)
                  {
                    CollectionPostoTrabalhoClassFornecedor.Add(Entidades.PostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPostoTrabalhoClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionProdutoFornecedorClassFornecedorLoaded) 
               {
                  CollectionProdutoFornecedorClassFornecedor.Clear();
                  foreach(int item in _collectionProdutoFornecedorClassFornecedorOriginal)
                  {
                    CollectionProdutoFornecedorClassFornecedor.Add(Entidades.ProdutoFornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoFornecedorClassFornecedorRemovidos.Clear();
               }
               if (_valueCollectionServicoClassFornecedorLoaded) 
               {
                  CollectionServicoClassFornecedor.Clear();
                  foreach(int item in _collectionServicoClassFornecedorOriginal)
                  {
                    CollectionServicoClassFornecedor.Add(Entidades.ServicoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionServicoClassFornecedorRemovidos.Clear();
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
               if (_valueCollectionContaPagarClassFornecedorLoaded) 
               {
                  if (_valueCollectionContaPagarClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassFornecedorLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContratoFornecimentoClassFornecedorLoaded) 
               {
                  if (_valueCollectionContratoFornecimentoClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCredorDevedorClassFornecedorLoaded) 
               {
                  if (_valueCollectionCredorDevedorClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoClassFornecedorLoaded) 
               {
                  if (_valueCollectionDeclaracaoImportacaoClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiFornecedorClassFornecedorLoaded) 
               {
                  if (_valueCollectionEpiFornecedorClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorContatoClassFornecedorLoaded) 
               {
                  if (_valueCollectionFornecedorContatoClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassFornecedorLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassFornecedorLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassFornecedorLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassFornecedorLoaded) 
               {
                  if (_valueCollectionLoteClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFornecedorClassFornecedorLoaded) 
               {
                  if (_valueCollectionMaterialFornecedorClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotaFiscalEntradaClassFornecedorLoaded) 
               {
                  if (_valueCollectionNotaFiscalEntradaClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraClassFornecedorLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraClassFornecedorLoaded) 
               {
                  if (_valueCollectionOrdemCompraClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassFornecedorLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFornecedorClassFornecedorLoaded) 
               {
                  if (_valueCollectionProdutoFornecedorClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionServicoClassFornecedorLoaded) 
               {
                  if (_valueCollectionServicoClassFornecedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassFornecedorLoaded) 
               {
                   tempRet = CollectionContaPagarClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassFornecedorLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContratoFornecimentoClassFornecedorLoaded) 
               {
                   tempRet = CollectionContratoFornecimentoClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionCredorDevedorClassFornecedorLoaded) 
               {
                   tempRet = CollectionCredorDevedorClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionDeclaracaoImportacaoClassFornecedorLoaded) 
               {
                   tempRet = CollectionDeclaracaoImportacaoClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionEpiFornecedorClassFornecedorLoaded) 
               {
                   tempRet = CollectionEpiFornecedorClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorContatoClassFornecedorLoaded) 
               {
                   tempRet = CollectionFornecedorContatoClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraEpiClassFornecedorLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassFornecedorLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassFornecedorLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassFornecedorLoaded) 
               {
                   tempRet = CollectionLoteClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFornecedorClassFornecedorLoaded) 
               {
                   tempRet = CollectionMaterialFornecedorClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNotaFiscalEntradaClassFornecedorLoaded) 
               {
                   tempRet = CollectionNotaFiscalEntradaClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoCompraClassFornecedorLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraClassFornecedorLoaded) 
               {
                   tempRet = CollectionOrdemCompraClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPostoTrabalhoClassFornecedorLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFornecedorClassFornecedorLoaded) 
               {
                   tempRet = CollectionProdutoFornecedorClassFornecedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionServicoClassFornecedorLoaded) 
               {
                   tempRet = CollectionServicoClassFornecedor.Any(item => item.IsDirty());
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
       dirty = _razaoSocialOriginal != RazaoSocial;
      if (dirty) return true;
       dirty = _nomeFantasiaOriginal != NomeFantasia;
      if (dirty) return true;
       dirty = _cnpjOriginal != Cnpj;
      if (dirty) return true;
       dirty = _inscEstadualOriginal != InscEstadual;
      if (dirty) return true;
       dirty = _inscMunicipalOriginal != InscMunicipal;
      if (dirty) return true;
       dirty = _enderecoOriginal != Endereco;
      if (dirty) return true;
       dirty = _bairroOriginal != Bairro;
      if (dirty) return true;
       dirty = _cepOriginal != Cep;
      if (dirty) return true;
       dirty = _fone1Original != Fone1;
      if (dirty) return true;
       dirty = _fone2Original != Fone2;
      if (dirty) return true;
       dirty = _fone3Original != Fone3;
      if (dirty) return true;
       dirty = _faxOriginal != Fax;
      if (dirty) return true;
       dirty = _emailOriginal != Email;
      if (dirty) return true;
       dirty = _siteOriginal != Site;
      if (dirty) return true;
       dirty = _obsOriginal != Obs;
      if (dirty) return true;
       dirty = _tipoPessoaOriginal != TipoPessoa;
      if (dirty) return true;
       dirty = _endNumeroOriginal != EndNumero;
      if (dirty) return true;
       dirty = _endComplementoOriginal != EndComplemento;
      if (dirty) return true;
       if (_estadoOriginal!=null)
       {
          dirty = !_estadoOriginal.Equals(Estado);
       }
       else
       {
            dirty = Estado != null;
       }
      if (dirty) return true;
       dirty = _bancoOriginal != Banco;
      if (dirty) return true;
       dirty = _agenciaOriginal != Agencia;
      if (dirty) return true;
       dirty = _contaOriginal != Conta;
      if (dirty) return true;
       dirty = _contatoOriginal != Contato;
      if (dirty) return true;
       dirty = _envioEmailOriginal != EnvioEmail;
      if (dirty) return true;
       dirty = _emailPedidoOriginal != EmailPedido;
      if (dirty) return true;
       dirty = _emailCotacaoOriginal != EmailCotacao;
      if (dirty) return true;
       dirty = _realizaRecebimentoOriginal != RealizaRecebimento;
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
       if (_cidadeOriginal!=null)
       {
          dirty = !_cidadeOriginal.Equals(Cidade);
       }
       else
       {
            dirty = Cidade != null;
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
       dirty = _estrangeiroOriginal != Estrangeiro;
      if (dirty) return true;
       dirty = _inscricaoSuframaOriginal != InscricaoSuframa;
      if (dirty) return true;
       dirty = _emailDanfeOriginal != EmailDanfe;
      if (dirty) return true;
       dirty = _emailXmlOriginal != EmailXml;
      if (dirty) return true;
       dirty = _paisOriginal != Pais;
      if (dirty) return true;
       dirty = _codigoPaisOriginal != CodigoPais;
      if (dirty) return true;
       dirty = _indicadorIeOriginal != IndicadorIe;
      if (dirty) return true;
       dirty = _contaRevisarRecebimentoOriginal != ContaRevisarRecebimento;

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
               if (_valueCollectionContaPagarClassFornecedorLoaded) 
               {
                  if (_valueCollectionContaPagarClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassFornecedorLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContratoFornecimentoClassFornecedorLoaded) 
               {
                  if (_valueCollectionContratoFornecimentoClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCredorDevedorClassFornecedorLoaded) 
               {
                  if (_valueCollectionCredorDevedorClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoClassFornecedorLoaded) 
               {
                  if (_valueCollectionDeclaracaoImportacaoClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEpiFornecedorClassFornecedorLoaded) 
               {
                  if (_valueCollectionEpiFornecedorClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorContatoClassFornecedorLoaded) 
               {
                  if (_valueCollectionFornecedorContatoClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassFornecedorLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassFornecedorLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassFornecedorLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassFornecedorLoaded) 
               {
                  if (_valueCollectionLoteClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialFornecedorClassFornecedorLoaded) 
               {
                  if (_valueCollectionMaterialFornecedorClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotaFiscalEntradaClassFornecedorLoaded) 
               {
                  if (_valueCollectionNotaFiscalEntradaClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoCompraClassFornecedorLoaded) 
               {
                  if (_valueCollectionOrcamentoCompraClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraClassFornecedorLoaded) 
               {
                  if (_valueCollectionOrdemCompraClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassFornecedorLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoFornecedorClassFornecedorLoaded) 
               {
                  if (_valueCollectionProdutoFornecedorClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionServicoClassFornecedorLoaded) 
               {
                  if (_valueCollectionServicoClassFornecedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassFornecedorLoaded) 
               {
                   tempRet = CollectionContaPagarClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassFornecedorLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContratoFornecimentoClassFornecedorLoaded) 
               {
                   tempRet = CollectionContratoFornecimentoClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionCredorDevedorClassFornecedorLoaded) 
               {
                   tempRet = CollectionCredorDevedorClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionDeclaracaoImportacaoClassFornecedorLoaded) 
               {
                   tempRet = CollectionDeclaracaoImportacaoClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionEpiFornecedorClassFornecedorLoaded) 
               {
                   tempRet = CollectionEpiFornecedorClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorContatoClassFornecedorLoaded) 
               {
                   tempRet = CollectionFornecedorContatoClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraEpiClassFornecedorLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassFornecedorLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassFornecedorLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassFornecedorLoaded) 
               {
                   tempRet = CollectionLoteClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialFornecedorClassFornecedorLoaded) 
               {
                   tempRet = CollectionMaterialFornecedorClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNotaFiscalEntradaClassFornecedorLoaded) 
               {
                   tempRet = CollectionNotaFiscalEntradaClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoCompraClassFornecedorLoaded) 
               {
                   tempRet = CollectionOrcamentoCompraClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraClassFornecedorLoaded) 
               {
                   tempRet = CollectionOrdemCompraClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPostoTrabalhoClassFornecedorLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoFornecedorClassFornecedorLoaded) 
               {
                   tempRet = CollectionProdutoFornecedorClassFornecedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionServicoClassFornecedorLoaded) 
               {
                   tempRet = CollectionServicoClassFornecedor.Any(item => item.IsDirtyCommited());
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
       dirty = _razaoSocialOriginalCommited != RazaoSocial;
      if (dirty) return true;
       dirty = _nomeFantasiaOriginalCommited != NomeFantasia;
      if (dirty) return true;
       dirty = _cnpjOriginalCommited != Cnpj;
      if (dirty) return true;
       dirty = _inscEstadualOriginalCommited != InscEstadual;
      if (dirty) return true;
       dirty = _inscMunicipalOriginalCommited != InscMunicipal;
      if (dirty) return true;
       dirty = _enderecoOriginalCommited != Endereco;
      if (dirty) return true;
       dirty = _bairroOriginalCommited != Bairro;
      if (dirty) return true;
       dirty = _cepOriginalCommited != Cep;
      if (dirty) return true;
       dirty = _fone1OriginalCommited != Fone1;
      if (dirty) return true;
       dirty = _fone2OriginalCommited != Fone2;
      if (dirty) return true;
       dirty = _fone3OriginalCommited != Fone3;
      if (dirty) return true;
       dirty = _faxOriginalCommited != Fax;
      if (dirty) return true;
       dirty = _emailOriginalCommited != Email;
      if (dirty) return true;
       dirty = _siteOriginalCommited != Site;
      if (dirty) return true;
       dirty = _obsOriginalCommited != Obs;
      if (dirty) return true;
       dirty = _tipoPessoaOriginalCommited != TipoPessoa;
      if (dirty) return true;
       dirty = _endNumeroOriginalCommited != EndNumero;
      if (dirty) return true;
       dirty = _endComplementoOriginalCommited != EndComplemento;
      if (dirty) return true;
       if (_estadoOriginalCommited!=null)
       {
          dirty = !_estadoOriginalCommited.Equals(Estado);
       }
       else
       {
            dirty = Estado != null;
       }
      if (dirty) return true;
       dirty = _bancoOriginalCommited != Banco;
      if (dirty) return true;
       dirty = _agenciaOriginalCommited != Agencia;
      if (dirty) return true;
       dirty = _contaOriginalCommited != Conta;
      if (dirty) return true;
       dirty = _contatoOriginalCommited != Contato;
      if (dirty) return true;
       dirty = _envioEmailOriginalCommited != EnvioEmail;
      if (dirty) return true;
       dirty = _emailPedidoOriginalCommited != EmailPedido;
      if (dirty) return true;
       dirty = _emailCotacaoOriginalCommited != EmailCotacao;
      if (dirty) return true;
       dirty = _realizaRecebimentoOriginalCommited != RealizaRecebimento;
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
       if (_cidadeOriginalCommited!=null)
       {
          dirty = !_cidadeOriginalCommited.Equals(Cidade);
       }
       else
       {
            dirty = Cidade != null;
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
       dirty = _estrangeiroOriginalCommited != Estrangeiro;
      if (dirty) return true;
       dirty = _inscricaoSuframaOriginalCommited != InscricaoSuframa;
      if (dirty) return true;
       dirty = _emailDanfeOriginalCommited != EmailDanfe;
      if (dirty) return true;
       dirty = _emailXmlOriginalCommited != EmailXml;
      if (dirty) return true;
       dirty = _paisOriginalCommited != Pais;
      if (dirty) return true;
       dirty = _codigoPaisOriginalCommited != CodigoPais;
      if (dirty) return true;
       dirty = _indicadorIeOriginalCommited != IndicadorIe;
      if (dirty) return true;
       dirty = _contaRevisarRecebimentoOriginalCommited != ContaRevisarRecebimento;

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
               if (_valueCollectionContaPagarClassFornecedorLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaRecorrenteClassFornecedorLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContratoFornecimentoClassFornecedorLoaded) 
               {
                  foreach(ContratoFornecimentoClass item in CollectionContratoFornecimentoClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionCredorDevedorClassFornecedorLoaded) 
               {
                  foreach(CredorDevedorClass item in CollectionCredorDevedorClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoClassFornecedorLoaded) 
               {
                  foreach(DeclaracaoImportacaoClass item in CollectionDeclaracaoImportacaoClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionEpiFornecedorClassFornecedorLoaded) 
               {
                  foreach(EpiFornecedorClass item in CollectionEpiFornecedorClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFornecedorContatoClassFornecedorLoaded) 
               {
                  foreach(FornecedorContatoClass item in CollectionFornecedorContatoClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassFornecedorLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassFornecedorLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassFornecedorLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionLoteClassFornecedorLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMaterialFornecedorClassFornecedorLoaded) 
               {
                  foreach(MaterialFornecedorClass item in CollectionMaterialFornecedorClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNotaFiscalEntradaClassFornecedorLoaded) 
               {
                  foreach(NotaFiscalEntradaClass item in CollectionNotaFiscalEntradaClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoCompraClassFornecedorLoaded) 
               {
                  foreach(OrcamentoCompraClass item in CollectionOrcamentoCompraClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemCompraClassFornecedorLoaded) 
               {
                  foreach(OrdemCompraClass item in CollectionOrdemCompraClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPostoTrabalhoClassFornecedorLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoFornecedorClassFornecedorLoaded) 
               {
                  foreach(ProdutoFornecedorClass item in CollectionProdutoFornecedorClassFornecedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionServicoClassFornecedorLoaded) 
               {
                  foreach(ServicoClass item in CollectionServicoClassFornecedor)
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
             case "RazaoSocial":
                return this.RazaoSocial;
             case "NomeFantasia":
                return this.NomeFantasia;
             case "Cnpj":
                return this.Cnpj;
             case "InscEstadual":
                return this.InscEstadual;
             case "InscMunicipal":
                return this.InscMunicipal;
             case "Endereco":
                return this.Endereco;
             case "Bairro":
                return this.Bairro;
             case "Cep":
                return this.Cep;
             case "Fone1":
                return this.Fone1;
             case "Fone2":
                return this.Fone2;
             case "Fone3":
                return this.Fone3;
             case "Fax":
                return this.Fax;
             case "Email":
                return this.Email;
             case "Site":
                return this.Site;
             case "Obs":
                return this.Obs;
             case "TipoPessoa":
                return this.TipoPessoa;
             case "EndNumero":
                return this.EndNumero;
             case "EndComplemento":
                return this.EndComplemento;
             case "Estado":
                return this.Estado;
             case "Banco":
                return this.Banco;
             case "Agencia":
                return this.Agencia;
             case "Conta":
                return this.Conta;
             case "Contato":
                return this.Contato;
             case "EnvioEmail":
                return this.EnvioEmail;
             case "EmailPedido":
                return this.EmailPedido;
             case "EmailCotacao":
                return this.EmailCotacao;
             case "RealizaRecebimento":
                return this.RealizaRecebimento;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ContaBancaria":
                return this.ContaBancaria;
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
             case "Cidade":
                return this.Cidade;
             case "FormaPagamento":
                return this.FormaPagamento;
             case "Estrangeiro":
                return this.Estrangeiro;
             case "InscricaoSuframa":
                return this.InscricaoSuframa;
             case "EmailDanfe":
                return this.EmailDanfe;
             case "EmailXml":
                return this.EmailXml;
             case "Pais":
                return this.Pais;
             case "CodigoPais":
                return this.CodigoPais;
             case "IndicadorIe":
                return this.IndicadorIe;
             case "ContaRevisarRecebimento":
                return this.ContaRevisarRecebimento;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Estado!=null)
                Estado.ChangeSingleConnection(newConnection);
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
             if (Cidade!=null)
                Cidade.ChangeSingleConnection(newConnection);
             if (FormaPagamento!=null)
                FormaPagamento.ChangeSingleConnection(newConnection);
               if (_valueCollectionContaPagarClassFornecedorLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaRecorrenteClassFornecedorLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContratoFornecimentoClassFornecedorLoaded) 
               {
                  foreach(ContratoFornecimentoClass item in CollectionContratoFornecimentoClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionCredorDevedorClassFornecedorLoaded) 
               {
                  foreach(CredorDevedorClass item in CollectionCredorDevedorClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoClassFornecedorLoaded) 
               {
                  foreach(DeclaracaoImportacaoClass item in CollectionDeclaracaoImportacaoClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionEpiFornecedorClassFornecedorLoaded) 
               {
                  foreach(EpiFornecedorClass item in CollectionEpiFornecedorClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFornecedorContatoClassFornecedorLoaded) 
               {
                  foreach(FornecedorContatoClass item in CollectionFornecedorContatoClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassFornecedorLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassFornecedorLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassFornecedorLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionLoteClassFornecedorLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMaterialFornecedorClassFornecedorLoaded) 
               {
                  foreach(MaterialFornecedorClass item in CollectionMaterialFornecedorClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNotaFiscalEntradaClassFornecedorLoaded) 
               {
                  foreach(NotaFiscalEntradaClass item in CollectionNotaFiscalEntradaClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoCompraClassFornecedorLoaded) 
               {
                  foreach(OrcamentoCompraClass item in CollectionOrcamentoCompraClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemCompraClassFornecedorLoaded) 
               {
                  foreach(OrdemCompraClass item in CollectionOrdemCompraClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassFornecedorLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPostoTrabalhoClassFornecedorLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoFornecedorClassFornecedorLoaded) 
               {
                  foreach(ProdutoFornecedorClass item in CollectionProdutoFornecedorClassFornecedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionServicoClassFornecedorLoaded) 
               {
                  foreach(ServicoClass item in CollectionServicoClassFornecedor)
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
                  command.CommandText += " COUNT(fornecedor.id_fornecedor) " ;
               }
               else
               {
               command.CommandText += "fornecedor.id_fornecedor, " ;
               command.CommandText += "fornecedor.for_razao_social, " ;
               command.CommandText += "fornecedor.for_nome_fantasia, " ;
               command.CommandText += "fornecedor.for_cnpj, " ;
               command.CommandText += "fornecedor.for_insc_estadual, " ;
               command.CommandText += "fornecedor.for_insc_municipal, " ;
               command.CommandText += "fornecedor.for_endereco, " ;
               command.CommandText += "fornecedor.for_bairro, " ;
               command.CommandText += "fornecedor.for_cep, " ;
               command.CommandText += "fornecedor.for_fone1, " ;
               command.CommandText += "fornecedor.for_fone2, " ;
               command.CommandText += "fornecedor.for_fone3, " ;
               command.CommandText += "fornecedor.for_fax, " ;
               command.CommandText += "fornecedor.for_email, " ;
               command.CommandText += "fornecedor.for_site, " ;
               command.CommandText += "fornecedor.for_obs, " ;
               command.CommandText += "fornecedor.for_tipo_pessoa, " ;
               command.CommandText += "fornecedor.for_end_numero, " ;
               command.CommandText += "fornecedor.for_end_complemento, " ;
               command.CommandText += "fornecedor.id_estado, " ;
               command.CommandText += "fornecedor.for_banco, " ;
               command.CommandText += "fornecedor.for_agencia, " ;
               command.CommandText += "fornecedor.for_conta, " ;
               command.CommandText += "fornecedor.for_contato, " ;
               command.CommandText += "fornecedor.for_envio_email, " ;
               command.CommandText += "fornecedor.for_email_pedido, " ;
               command.CommandText += "fornecedor.for_email_cotacao, " ;
               command.CommandText += "fornecedor.for_realiza_recebimento, " ;
               command.CommandText += "fornecedor.entity_uid, " ;
               command.CommandText += "fornecedor.version, " ;
               command.CommandText += "fornecedor.id_conta_bancaria, " ;
               command.CommandText += "fornecedor.id_centro_custo_lucro, " ;
               command.CommandText += "fornecedor.id_cidade, " ;
               command.CommandText += "fornecedor.id_forma_pagamento, " ;
               command.CommandText += "fornecedor.for_estrangeiro, " ;
               command.CommandText += "fornecedor.for_inscricao_suframa, " ;
               command.CommandText += "fornecedor.for_email_danfe, " ;
               command.CommandText += "fornecedor.for_email_xml, " ;
               command.CommandText += "fornecedor.for_pais, " ;
               command.CommandText += "fornecedor.for_codigo_pais, " ;
               command.CommandText += "fornecedor.for_indicador_ie, " ;
               command.CommandText += "fornecedor.for_conta_revisar_recebimento " ;
               }
               command.CommandText += " FROM  fornecedor ";
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
                        orderByClause += " , for_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(for_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = fornecedor.id_acs_usuario_ultima_revisao ";
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
                     case "id_fornecedor":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fornecedor.id_fornecedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fornecedor.id_fornecedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_razao_social":
                     case "RazaoSocial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_razao_social " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_razao_social) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_nome_fantasia":
                     case "NomeFantasia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_nome_fantasia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_nome_fantasia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_cnpj":
                     case "Cnpj":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_cnpj " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_cnpj) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_insc_estadual":
                     case "InscEstadual":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_insc_estadual " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_insc_estadual) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_insc_municipal":
                     case "InscMunicipal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_insc_municipal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_insc_municipal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_endereco":
                     case "Endereco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_endereco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_endereco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_bairro":
                     case "Bairro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_bairro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_bairro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_cep":
                     case "Cep":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_cep " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_cep) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_fone1":
                     case "Fone1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_fone1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_fone1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_fone2":
                     case "Fone2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_fone2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_fone2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_fone3":
                     case "Fone3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_fone3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_fone3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_fax":
                     case "Fax":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_fax " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_fax) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_email":
                     case "Email":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_site":
                     case "Site":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_site " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_site) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_obs":
                     case "Obs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_obs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_obs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_tipo_pessoa":
                     case "TipoPessoa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fornecedor.for_tipo_pessoa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fornecedor.for_tipo_pessoa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_end_numero":
                     case "EndNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_end_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_end_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_end_complemento":
                     case "EndComplemento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_end_complemento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_end_complemento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estado":
                     case "Estado":
                     command.CommandText += " LEFT JOIN estado as estado_Estado ON estado_Estado.id_estado = fornecedor.id_estado ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_Estado.est_sigla " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_Estado.est_sigla) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_Estado.est_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_Estado.est_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_banco":
                     case "Banco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_banco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_banco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_agencia":
                     case "Agencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_agencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_agencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_conta":
                     case "Conta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_conta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_contato":
                     case "Contato":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_contato " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_contato) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_envio_email":
                     case "EnvioEmail":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fornecedor.for_envio_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fornecedor.for_envio_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_email_pedido":
                     case "EmailPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_email_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_email_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_email_cotacao":
                     case "EmailCotacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_email_cotacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_email_cotacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_realiza_recebimento":
                     case "RealizaRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fornecedor.for_realiza_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fornecedor.for_realiza_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , fornecedor.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fornecedor.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = fornecedor.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = fornecedor.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_cidade":
                     case "Cidade":
                     command.CommandText += " LEFT JOIN cidade as cidade_Cidade ON cidade_Cidade.id_cidade = fornecedor.id_cidade ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cidade_Cidade.cid_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cidade_Cidade.cid_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_forma_pagamento":
                     case "FormaPagamento":
                     command.CommandText += " LEFT JOIN forma_pagamento as forma_pagamento_FormaPagamento ON forma_pagamento_FormaPagamento.id_forma_pagamento = fornecedor.id_forma_pagamento ";                     switch (parametro.TipoOrdenacao)
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
                     case "for_estrangeiro":
                     case "Estrangeiro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fornecedor.for_estrangeiro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fornecedor.for_estrangeiro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_inscricao_suframa":
                     case "InscricaoSuframa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_inscricao_suframa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_inscricao_suframa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_email_danfe":
                     case "EmailDanfe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_email_danfe " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_email_danfe) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_email_xml":
                     case "EmailXml":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_email_xml " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_email_xml) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_pais":
                     case "Pais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor.for_pais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor.for_pais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_codigo_pais":
                     case "CodigoPais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fornecedor.for_codigo_pais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fornecedor.for_codigo_pais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_indicador_ie":
                     case "IndicadorIe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fornecedor.for_indicador_ie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fornecedor.for_indicador_ie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "for_conta_revisar_recebimento":
                     case "ContaRevisarRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fornecedor.for_conta_revisar_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fornecedor.for_conta_revisar_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_razao_social")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_razao_social) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_razao_social) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_nome_fantasia")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_nome_fantasia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_nome_fantasia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_cnpj")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_cnpj) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_cnpj) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_insc_estadual")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_insc_estadual) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_insc_estadual) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_insc_municipal")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_insc_municipal) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_insc_municipal) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_endereco")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_endereco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_endereco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_bairro")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_bairro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_bairro) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_cep")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_cep) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_cep) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_fone1")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_fone1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_fone1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_fone2")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_fone2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_fone2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_fone3")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_fone3) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_fone3) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_fax")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_fax) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_fax) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_email")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_email) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_email) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_site")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_site) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_site) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_obs")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_obs) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_obs) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_end_numero")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_end_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_end_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_end_complemento")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_end_complemento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_end_complemento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_banco")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_banco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_banco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_agencia")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_agencia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_agencia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_conta")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_conta) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_conta) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_contato")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_contato) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_contato) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_email_pedido")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_email_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_email_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_email_cotacao")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_email_cotacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_email_cotacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(fornecedor.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_inscricao_suframa")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_inscricao_suframa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_inscricao_suframa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_email_danfe")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_email_danfe) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_email_danfe) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_email_xml")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_email_xml) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_email_xml) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("for_pais")) 
                        {
                           whereClause += " OR UPPER(fornecedor.for_pais) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fornecedor.for_pais) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.id_fornecedor = :fornecedor_ID_5298 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_ID_5298", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RazaoSocial" || parametro.FieldName == "for_razao_social")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_razao_social IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_razao_social LIKE :fornecedor_RazaoSocial_7745 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_RazaoSocial_7745", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeFantasia" || parametro.FieldName == "for_nome_fantasia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_nome_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_nome_fantasia LIKE :fornecedor_NomeFantasia_343 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_NomeFantasia_343", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnpj" || parametro.FieldName == "for_cnpj")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_cnpj LIKE :fornecedor_Cnpj_7290 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Cnpj_7290", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscEstadual" || parametro.FieldName == "for_insc_estadual")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_insc_estadual IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_insc_estadual LIKE :fornecedor_InscEstadual_35 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_InscEstadual_35", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscMunicipal" || parametro.FieldName == "for_insc_municipal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_insc_municipal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_insc_municipal LIKE :fornecedor_InscMunicipal_59 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_InscMunicipal_59", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Endereco" || parametro.FieldName == "for_endereco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_endereco LIKE :fornecedor_Endereco_1278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Endereco_1278", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Bairro" || parametro.FieldName == "for_bairro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_bairro LIKE :fornecedor_Bairro_3914 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Bairro_3914", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cep" || parametro.FieldName == "for_cep")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_cep LIKE :fornecedor_Cep_843 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Cep_843", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone1" || parametro.FieldName == "for_fone1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_fone1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_fone1 LIKE :fornecedor_Fone1_5451 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Fone1_5451", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone2" || parametro.FieldName == "for_fone2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_fone2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_fone2 LIKE :fornecedor_Fone2_9535 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Fone2_9535", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone3" || parametro.FieldName == "for_fone3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_fone3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_fone3 LIKE :fornecedor_Fone3_3368 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Fone3_3368", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fax" || parametro.FieldName == "for_fax")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_fax IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_fax LIKE :fornecedor_Fax_3576 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Fax_3576", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Email" || parametro.FieldName == "for_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email LIKE :fornecedor_Email_389 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Email_389", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Site" || parametro.FieldName == "for_site")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_site IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_site LIKE :fornecedor_Site_2571 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Site_2571", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Obs" || parametro.FieldName == "for_obs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_obs LIKE :fornecedor_Obs_4433 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Obs_4433", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoPessoa" || parametro.FieldName == "for_tipo_pessoa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoPessoa?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoPessoa?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_tipo_pessoa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_tipo_pessoa = :fornecedor_TipoPessoa_924 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_TipoPessoa_924", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EndNumero" || parametro.FieldName == "for_end_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_end_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_end_numero LIKE :fornecedor_EndNumero_3576 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EndNumero_3576", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EndComplemento" || parametro.FieldName == "for_end_complemento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_end_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_end_complemento LIKE :fornecedor_EndComplemento_4036 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EndComplemento_4036", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Estado" || parametro.FieldName == "id_estado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstadoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstadoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.id_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.id_estado = :fornecedor_Estado_5833 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Estado_5833", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Banco" || parametro.FieldName == "for_banco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_banco LIKE :fornecedor_Banco_8356 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Banco_8356", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Agencia" || parametro.FieldName == "for_agencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_agencia LIKE :fornecedor_Agencia_3324 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Agencia_3324", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Conta" || parametro.FieldName == "for_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_conta LIKE :fornecedor_Conta_6604 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Conta_6604", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Contato" || parametro.FieldName == "for_contato")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_contato IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_contato LIKE :fornecedor_Contato_1302 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Contato_1302", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnvioEmail" || parametro.FieldName == "for_envio_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_envio_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_envio_email = :fornecedor_EnvioEmail_745 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EnvioEmail_745", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailPedido" || parametro.FieldName == "for_email_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email_pedido LIKE :fornecedor_EmailPedido_5938 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EmailPedido_5938", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailCotacao" || parametro.FieldName == "for_email_cotacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email_cotacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email_cotacao LIKE :fornecedor_EmailCotacao_3932 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EmailCotacao_3932", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RealizaRecebimento" || parametro.FieldName == "for_realiza_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_realiza_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_realiza_recebimento = :fornecedor_RealizaRecebimento_2496 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_RealizaRecebimento_2496", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  fornecedor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.entity_uid LIKE :fornecedor_EntityUid_7510 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EntityUid_7510", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  fornecedor.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.version = :fornecedor_Version_3216 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Version_3216", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  fornecedor.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.id_conta_bancaria = :fornecedor_ContaBancaria_4120 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_ContaBancaria_4120", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  fornecedor.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.id_centro_custo_lucro = :fornecedor_CentroCustoLucro_8741 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_CentroCustoLucro_8741", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cidade" || parametro.FieldName == "id_cidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CidadeClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CidadeClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.id_cidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.id_cidade = :fornecedor_Cidade_6579 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Cidade_6579", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  fornecedor.id_forma_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.id_forma_pagamento = :fornecedor_FormaPagamento_2124 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_FormaPagamento_2124", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Estrangeiro" || parametro.FieldName == "for_estrangeiro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_estrangeiro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_estrangeiro = :fornecedor_Estrangeiro_9418 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Estrangeiro_9418", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoSuframa" || parametro.FieldName == "for_inscricao_suframa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_inscricao_suframa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_inscricao_suframa LIKE :fornecedor_InscricaoSuframa_186 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_InscricaoSuframa_186", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailDanfe" || parametro.FieldName == "for_email_danfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email_danfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email_danfe LIKE :fornecedor_EmailDanfe_4244 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EmailDanfe_4244", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailXml" || parametro.FieldName == "for_email_xml")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email_xml LIKE :fornecedor_EmailXml_4276 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EmailXml_4276", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pais" || parametro.FieldName == "for_pais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_pais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_pais LIKE :fornecedor_Pais_3895 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Pais_3895", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoPais" || parametro.FieldName == "for_codigo_pais")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_codigo_pais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_codigo_pais = :fornecedor_CodigoPais_1406 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_CodigoPais_1406", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndicadorIe" || parametro.FieldName == "for_indicador_ie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFIndicadorIE)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFIndicadorIE");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_indicador_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_indicador_ie = :fornecedor_IndicadorIe_6244 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_IndicadorIe_6244", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaRevisarRecebimento" || parametro.FieldName == "for_conta_revisar_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_conta_revisar_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_conta_revisar_recebimento = :fornecedor_ContaRevisarRecebimento_5730 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_ContaRevisarRecebimento_5730", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RazaoSocialExato" || parametro.FieldName == "RazaoSocialExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_razao_social IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_razao_social LIKE :fornecedor_RazaoSocial_8465 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_RazaoSocial_8465", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeFantasiaExato" || parametro.FieldName == "NomeFantasiaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_nome_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_nome_fantasia LIKE :fornecedor_NomeFantasia_4439 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_NomeFantasia_4439", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjExato" || parametro.FieldName == "CnpjExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_cnpj LIKE :fornecedor_Cnpj_8178 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Cnpj_8178", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscEstadualExato" || parametro.FieldName == "InscEstadualExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_insc_estadual IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_insc_estadual LIKE :fornecedor_InscEstadual_9281 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_InscEstadual_9281", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscMunicipalExato" || parametro.FieldName == "InscMunicipalExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_insc_municipal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_insc_municipal LIKE :fornecedor_InscMunicipal_4698 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_InscMunicipal_4698", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoExato" || parametro.FieldName == "EnderecoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_endereco LIKE :fornecedor_Endereco_3976 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Endereco_3976", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BairroExato" || parametro.FieldName == "BairroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_bairro LIKE :fornecedor_Bairro_3412 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Bairro_3412", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CepExato" || parametro.FieldName == "CepExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_cep LIKE :fornecedor_Cep_3858 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Cep_3858", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone1Exato" || parametro.FieldName == "Fone1Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_fone1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_fone1 LIKE :fornecedor_Fone1_7201 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Fone1_7201", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone2Exato" || parametro.FieldName == "Fone2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_fone2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_fone2 LIKE :fornecedor_Fone2_4400 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Fone2_4400", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone3Exato" || parametro.FieldName == "Fone3Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_fone3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_fone3 LIKE :fornecedor_Fone3_8967 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Fone3_8967", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FaxExato" || parametro.FieldName == "FaxExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_fax IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_fax LIKE :fornecedor_Fax_4102 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Fax_4102", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailExato" || parametro.FieldName == "EmailExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email LIKE :fornecedor_Email_7840 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Email_7840", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiteExato" || parametro.FieldName == "SiteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_site IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_site LIKE :fornecedor_Site_1975 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Site_1975", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsExato" || parametro.FieldName == "ObsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_obs LIKE :fornecedor_Obs_1141 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Obs_1141", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EndNumeroExato" || parametro.FieldName == "EndNumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_end_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_end_numero LIKE :fornecedor_EndNumero_9039 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EndNumero_9039", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EndComplementoExato" || parametro.FieldName == "EndComplementoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_end_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_end_complemento LIKE :fornecedor_EndComplemento_6545 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EndComplemento_6545", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BancoExato" || parametro.FieldName == "BancoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_banco LIKE :fornecedor_Banco_4095 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Banco_4095", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgenciaExato" || parametro.FieldName == "AgenciaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_agencia LIKE :fornecedor_Agencia_6126 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Agencia_6126", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaExato" || parametro.FieldName == "ContaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_conta LIKE :fornecedor_Conta_8780 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Conta_8780", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContatoExato" || parametro.FieldName == "ContatoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_contato IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_contato LIKE :fornecedor_Contato_6402 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Contato_6402", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailPedidoExato" || parametro.FieldName == "EmailPedidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email_pedido LIKE :fornecedor_EmailPedido_7626 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EmailPedido_7626", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailCotacaoExato" || parametro.FieldName == "EmailCotacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email_cotacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email_cotacao LIKE :fornecedor_EmailCotacao_1332 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EmailCotacao_1332", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  fornecedor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.entity_uid LIKE :fornecedor_EntityUid_795 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EntityUid_795", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoSuframaExato" || parametro.FieldName == "InscricaoSuframaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_inscricao_suframa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_inscricao_suframa LIKE :fornecedor_InscricaoSuframa_6788 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_InscricaoSuframa_6788", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailDanfeExato" || parametro.FieldName == "EmailDanfeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email_danfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email_danfe LIKE :fornecedor_EmailDanfe_1452 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EmailDanfe_1452", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailXmlExato" || parametro.FieldName == "EmailXmlExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_email_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_email_xml LIKE :fornecedor_EmailXml_970 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_EmailXml_970", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PaisExato" || parametro.FieldName == "PaisExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fornecedor.for_pais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fornecedor.for_pais LIKE :fornecedor_Pais_2386 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fornecedor_Pais_2386", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  FornecedorClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (FornecedorClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(FornecedorClass), Convert.ToInt32(read["id_fornecedor"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new FornecedorClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_fornecedor"]);
                     entidade.RazaoSocial = (read["for_razao_social"] != DBNull.Value ? read["for_razao_social"].ToString() : null);
                     entidade.NomeFantasia = (read["for_nome_fantasia"] != DBNull.Value ? read["for_nome_fantasia"].ToString() : null);
                     entidade.Cnpj = (read["for_cnpj"] != DBNull.Value ? read["for_cnpj"].ToString() : null);
                     entidade.InscEstadual = (read["for_insc_estadual"] != DBNull.Value ? read["for_insc_estadual"].ToString() : null);
                     entidade.InscMunicipal = (read["for_insc_municipal"] != DBNull.Value ? read["for_insc_municipal"].ToString() : null);
                     entidade.Endereco = (read["for_endereco"] != DBNull.Value ? read["for_endereco"].ToString() : null);
                     entidade.Bairro = (read["for_bairro"] != DBNull.Value ? read["for_bairro"].ToString() : null);
                     entidade.Cep = (read["for_cep"] != DBNull.Value ? read["for_cep"].ToString() : null);
                     entidade.Fone1 = (read["for_fone1"] != DBNull.Value ? read["for_fone1"].ToString() : null);
                     entidade.Fone2 = (read["for_fone2"] != DBNull.Value ? read["for_fone2"].ToString() : null);
                     entidade.Fone3 = (read["for_fone3"] != DBNull.Value ? read["for_fone3"].ToString() : null);
                     entidade.Fax = (read["for_fax"] != DBNull.Value ? read["for_fax"].ToString() : null);
                     entidade.Email = (read["for_email"] != DBNull.Value ? read["for_email"].ToString() : null);
                     entidade.Site = (read["for_site"] != DBNull.Value ? read["for_site"].ToString() : null);
                     entidade.Obs = (read["for_obs"] != DBNull.Value ? read["for_obs"].ToString() : null);
                     entidade.TipoPessoa = (TipoPessoa?) (read["for_tipo_pessoa"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(TipoPessoa?)), read["for_tipo_pessoa"]) : null);
                     entidade.EndNumero = (read["for_end_numero"] != DBNull.Value ? read["for_end_numero"].ToString() : null);
                     entidade.EndComplemento = (read["for_end_complemento"] != DBNull.Value ? read["for_end_complemento"].ToString() : null);
                     if (read["id_estado"] != DBNull.Value)
                     {
                        entidade.Estado = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Estado = null ;
                     }
                     entidade.Banco = (read["for_banco"] != DBNull.Value ? read["for_banco"].ToString() : null);
                     entidade.Agencia = (read["for_agencia"] != DBNull.Value ? read["for_agencia"].ToString() : null);
                     entidade.Conta = (read["for_conta"] != DBNull.Value ? read["for_conta"].ToString() : null);
                     entidade.Contato = (read["for_contato"] != DBNull.Value ? read["for_contato"].ToString() : null);
                     entidade.EnvioEmail = Convert.ToBoolean(Convert.ToInt16(read["for_envio_email"]));
                     entidade.EmailPedido = (read["for_email_pedido"] != DBNull.Value ? read["for_email_pedido"].ToString() : null);
                     entidade.EmailCotacao = (read["for_email_cotacao"] != DBNull.Value ? read["for_email_cotacao"].ToString() : null);
                     entidade.RealizaRecebimento = Convert.ToBoolean(Convert.ToInt16(read["for_realiza_recebimento"]));
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
                     if (read["id_cidade"] != DBNull.Value)
                     {
                        entidade.Cidade = (BibliotecaEntidades.Entidades.CidadeClass)BibliotecaEntidades.Entidades.CidadeClass.GetEntidade(Convert.ToInt32(read["id_cidade"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cidade = null ;
                     }
                     if (read["id_forma_pagamento"] != DBNull.Value)
                     {
                        entidade.FormaPagamento = (BibliotecaEntidades.Entidades.FormaPagamentoClass)BibliotecaEntidades.Entidades.FormaPagamentoClass.GetEntidade(Convert.ToInt32(read["id_forma_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FormaPagamento = null ;
                     }
                     entidade.Estrangeiro = Convert.ToBoolean(Convert.ToInt16(read["for_estrangeiro"]));
                     entidade.InscricaoSuframa = (read["for_inscricao_suframa"] != DBNull.Value ? read["for_inscricao_suframa"].ToString() : null);
                     entidade.EmailDanfe = (read["for_email_danfe"] != DBNull.Value ? read["for_email_danfe"].ToString() : null);
                     entidade.EmailXml = (read["for_email_xml"] != DBNull.Value ? read["for_email_xml"].ToString() : null);
                     entidade.Pais = (read["for_pais"] != DBNull.Value ? read["for_pais"].ToString() : null);
                     entidade.CodigoPais = read["for_codigo_pais"] as int?;
                     entidade.IndicadorIe = (IWTNFIndicadorIE) (read["for_indicador_ie"] != DBNull.Value ? Enum.ToObject(typeof(IWTNFIndicadorIE), read["for_indicador_ie"]) : null);
                     entidade.ContaRevisarRecebimento = Convert.ToBoolean(Convert.ToInt16(read["for_conta_revisar_recebimento"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (FornecedorClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
