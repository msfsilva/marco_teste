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
     [Table("cliente","cli")]
     public class ClienteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ClienteClass";
protected const string ErroDelete = "Erro ao excluir o ClienteClass  ";
protected const string ErroSave = "Erro ao salvar o ClienteClass.";
protected const string ErroCollectionCliEassaIdentificaClienteClassCliente = "Erro ao carregar a coleção de CliEassaIdentificaClienteClass.";
protected const string ErroCollectionClienteContatoClassCliente = "Erro ao carregar a coleção de ClienteContatoClass.";
protected const string ErroCollectionContaReceberClassCliente = "Erro ao carregar a coleção de ContaReceberClass.";
protected const string ErroCollectionContaReceberBoletoClassCliente = "Erro ao carregar a coleção de ContaReceberBoletoClass.";
protected const string ErroCollectionContaRecorrenteClassCliente = "Erro ao carregar a coleção de ContaRecorrenteClass.";
protected const string ErroCollectionCredorDevedorClassCliente = "Erro ao carregar a coleção de CredorDevedorClass.";
protected const string ErroCollectionLoteClassCliente = "Erro ao carregar a coleção de LoteClass.";
protected const string ErroCollectionOrcamentoConfiguradoClassCliente = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
protected const string ErroCollectionOrcamentoItemClassCliente = "Erro ao carregar a coleção de OrcamentoItemClass.";
protected const string ErroCollectionOrcamentoItemVariavelClassCliente = "Erro ao carregar a coleção de OrcamentoItemVariavelClass.";
protected const string ErroCollectionOrcamentoKitClassCliente = "Erro ao carregar a coleção de OrcamentoKitClass.";
protected const string ErroCollectionOrcamentoVariavelClassCliente = "Erro ao carregar a coleção de OrcamentoVariavelClass.";
protected const string ErroCollectionOrderItemEtiquetaClassCliente = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
protected const string ErroCollectionPedidoItemClassCliente = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionPedidoItemClassClienteEnvioTerceiros = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionPedidoItemVariavelClassCliente = "Erro ao carregar a coleção de PedidoItemVariavelClass.";
protected const string ErroCollectionPedidoKitClassCliente = "Erro ao carregar a coleção de PedidoKitClass.";
protected const string ErroCollectionPedidoVariavelClassCliente = "Erro ao carregar a coleção de PedidoVariavelClass.";
protected const string ErroCollectionProdutoClassCliente = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCollectionTabelaPrecoItemVariavelClassCliente = "Erro ao carregar a coleção de TabelaPrecoItemVariavelClass.";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do ClienteClass.";
protected const string MensagemUtilizadoCollectionCliEassaIdentificaClienteClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes CliEassaIdentificaClienteClass:";
protected const string MensagemUtilizadoCollectionClienteContatoClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes ClienteContatoClass:";
protected const string MensagemUtilizadoCollectionContaReceberClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes ContaReceberClass:";
protected const string MensagemUtilizadoCollectionContaReceberBoletoClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes ContaReceberBoletoClass:";
protected const string MensagemUtilizadoCollectionContaRecorrenteClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
protected const string MensagemUtilizadoCollectionCredorDevedorClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes CredorDevedorClass:";
protected const string MensagemUtilizadoCollectionLoteClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes LoteClass:";
protected const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoItemClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemVariavelClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoItemVariavelClass:";
protected const string MensagemUtilizadoCollectionOrcamentoKitClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoKitClass:";
protected const string MensagemUtilizadoCollectionOrcamentoVariavelClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoVariavelClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassClienteEnvioTerceiros =  "A entidade ClienteClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionPedidoItemVariavelClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes PedidoItemVariavelClass:";
protected const string MensagemUtilizadoCollectionPedidoKitClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes PedidoKitClass:";
protected const string MensagemUtilizadoCollectionPedidoVariavelClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes PedidoVariavelClass:";
protected const string MensagemUtilizadoCollectionProdutoClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string MensagemUtilizadoCollectionTabelaPrecoItemVariavelClassCliente =  "A entidade ClienteClass está sendo utilizada nos seguintes TabelaPrecoItemVariavelClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ClienteClass está sendo utilizada.";
#endregion
       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("cli_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected string _nomeResumidoOriginal{get;private set;}
       private string _nomeResumidoOriginalCommited{get; set;}
        private string _valueNomeResumido;
         [Column("cli_nome_resumido")]
        public virtual string NomeResumido
         { 
            get { return this._valueNomeResumido; } 
            set 
            { 
                if (this._valueNomeResumido == value)return;
                 this._valueNomeResumido = value; 
            } 
        } 

       protected DateTime? _dataImplantacaoOriginal{get;private set;}
       private DateTime? _dataImplantacaoOriginalCommited{get; set;}
        private DateTime? _valueDataImplantacao;
         [Column("cli_data_implantacao")]
        public virtual DateTime? DataImplantacao
         { 
            get { return this._valueDataImplantacao; } 
            set 
            { 
                if (this._valueDataImplantacao == value)return;
                 this._valueDataImplantacao = value; 
            } 
        } 

       protected string _enderecoOriginal{get;private set;}
       private string _enderecoOriginalCommited{get; set;}
        private string _valueEndereco;
         [Column("cli_endereco")]
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
         [Column("cli_bairro")]
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
         [Column("cli_cep")]
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
         [Column("cli_fone1")]
        public virtual string Fone1
         { 
            get { return this._valueFone1; } 
            set 
            { 
                if (this._valueFone1 == value)return;
                 this._valueFone1 = value; 
            } 
        } 

       protected string _ramal1Original{get;private set;}
       private string _ramal1OriginalCommited{get; set;}
        private string _valueRamal1;
         [Column("cli_ramal1")]
        public virtual string Ramal1
         { 
            get { return this._valueRamal1; } 
            set 
            { 
                if (this._valueRamal1 == value)return;
                 this._valueRamal1 = value; 
            } 
        } 

       protected string _fone2Original{get;private set;}
       private string _fone2OriginalCommited{get; set;}
        private string _valueFone2;
         [Column("cli_fone2")]
        public virtual string Fone2
         { 
            get { return this._valueFone2; } 
            set 
            { 
                if (this._valueFone2 == value)return;
                 this._valueFone2 = value; 
            } 
        } 

       protected string _ramal2Original{get;private set;}
       private string _ramal2OriginalCommited{get; set;}
        private string _valueRamal2;
         [Column("cli_ramal2")]
        public virtual string Ramal2
         { 
            get { return this._valueRamal2; } 
            set 
            { 
                if (this._valueRamal2 == value)return;
                 this._valueRamal2 = value; 
            } 
        } 

       protected string _faxOriginal{get;private set;}
       private string _faxOriginalCommited{get; set;}
        private string _valueFax;
         [Column("cli_fax")]
        public virtual string Fax
         { 
            get { return this._valueFax; } 
            set 
            { 
                if (this._valueFax == value)return;
                 this._valueFax = value; 
            } 
        } 

       protected string _faxRamalOriginal{get;private set;}
       private string _faxRamalOriginalCommited{get; set;}
        private string _valueFaxRamal;
         [Column("cli_fax_ramal")]
        public virtual string FaxRamal
         { 
            get { return this._valueFaxRamal; } 
            set 
            { 
                if (this._valueFaxRamal == value)return;
                 this._valueFaxRamal = value; 
            } 
        } 

       protected string _emailOriginal{get;private set;}
       private string _emailOriginalCommited{get; set;}
        private string _valueEmail;
         [Column("cli_email")]
        public virtual string Email
         { 
            get { return this._valueEmail; } 
            set 
            { 
                if (this._valueEmail == value)return;
                 this._valueEmail = value; 
            } 
        } 

       protected string _cnpjOriginal{get;private set;}
       private string _cnpjOriginalCommited{get; set;}
        private string _valueCnpj;
         [Column("cli_cnpj")]
        public virtual string Cnpj
         { 
            get { return this._valueCnpj; } 
            set 
            { 
                if (this._valueCnpj == value)return;
                 this._valueCnpj = value; 
            } 
        } 

       protected string _ieOriginal{get;private set;}
       private string _ieOriginalCommited{get; set;}
        private string _valueIe;
         [Column("cli_ie")]
        public virtual string Ie
         { 
            get { return this._valueIe; } 
            set 
            { 
                if (this._valueIe == value)return;
                 this._valueIe = value; 
            } 
        } 

       protected string _inscricaoMunicipalOriginal{get;private set;}
       private string _inscricaoMunicipalOriginalCommited{get; set;}
        private string _valueInscricaoMunicipal;
         [Column("cli_inscricao_municipal")]
        public virtual string InscricaoMunicipal
         { 
            get { return this._valueInscricaoMunicipal; } 
            set 
            { 
                if (this._valueInscricaoMunicipal == value)return;
                 this._valueInscricaoMunicipal = value; 
            } 
        } 

       protected string _inscricaoInssOriginal{get;private set;}
       private string _inscricaoInssOriginalCommited{get; set;}
        private string _valueInscricaoInss;
         [Column("cli_inscricao_inss")]
        public virtual string InscricaoInss
         { 
            get { return this._valueInscricaoInss; } 
            set 
            { 
                if (this._valueInscricaoInss == value)return;
                 this._valueInscricaoInss = value; 
            } 
        } 

       protected string _paisOriginal{get;private set;}
       private string _paisOriginalCommited{get; set;}
        private string _valuePais;
         [Column("cli_pais")]
        public virtual string Pais
         { 
            get { return this._valuePais; } 
            set 
            { 
                if (this._valuePais == value)return;
                 this._valuePais = value; 
            } 
        } 

       protected string _enderecoCobOriginal{get;private set;}
       private string _enderecoCobOriginalCommited{get; set;}
        private string _valueEnderecoCob;
         [Column("cli_endereco_cob")]
        public virtual string EnderecoCob
         { 
            get { return this._valueEnderecoCob; } 
            set 
            { 
                if (this._valueEnderecoCob == value)return;
                 this._valueEnderecoCob = value; 
            } 
        } 

       protected string _bairroCobOriginal{get;private set;}
       private string _bairroCobOriginalCommited{get; set;}
        private string _valueBairroCob;
         [Column("cli_bairro_cob")]
        public virtual string BairroCob
         { 
            get { return this._valueBairroCob; } 
            set 
            { 
                if (this._valueBairroCob == value)return;
                 this._valueBairroCob = value; 
            } 
        } 

       protected string _cepCobOriginal{get;private set;}
       private string _cepCobOriginalCommited{get; set;}
        private string _valueCepCob;
         [Column("cli_cep_cob")]
        public virtual string CepCob
         { 
            get { return this._valueCepCob; } 
            set 
            { 
                if (this._valueCepCob == value)return;
                 this._valueCepCob = value; 
            } 
        } 

       protected string _paisCobOriginal{get;private set;}
       private string _paisCobOriginalCommited{get; set;}
        private string _valuePaisCob;
         [Column("cli_pais_cob")]
        public virtual string PaisCob
         { 
            get { return this._valuePaisCob; } 
            set 
            { 
                if (this._valuePaisCob == value)return;
                 this._valuePaisCob = value; 
            } 
        } 

       protected string _observacoesOriginal{get;private set;}
       private string _observacoesOriginalCommited{get; set;}
        private string _valueObservacoes;
         [Column("cli_observacoes")]
        public virtual string Observacoes
         { 
            get { return this._valueObservacoes; } 
            set 
            { 
                if (this._valueObservacoes == value)return;
                 this._valueObservacoes = value; 
            } 
        } 

       protected string _enderecoNumeroCobOriginal{get;private set;}
       private string _enderecoNumeroCobOriginalCommited{get; set;}
        private string _valueEnderecoNumeroCob;
         [Column("cli_endereco_numero_cob")]
        public virtual string EnderecoNumeroCob
         { 
            get { return this._valueEnderecoNumeroCob; } 
            set 
            { 
                if (this._valueEnderecoNumeroCob == value)return;
                 this._valueEnderecoNumeroCob = value; 
            } 
        } 

       protected string _complementoCobOriginal{get;private set;}
       private string _complementoCobOriginalCommited{get; set;}
        private string _valueComplementoCob;
         [Column("cli_complemento_cob")]
        public virtual string ComplementoCob
         { 
            get { return this._valueComplementoCob; } 
            set 
            { 
                if (this._valueComplementoCob == value)return;
                 this._valueComplementoCob = value; 
            } 
        } 

       protected int? _codigoPaisCobOriginal{get;private set;}
       private int? _codigoPaisCobOriginalCommited{get; set;}
        private int? _valueCodigoPaisCob;
         [Column("cli_codigo_pais_cob")]
        public virtual int? CodigoPaisCob
         { 
            get { return this._valueCodigoPaisCob; } 
            set 
            { 
                if (this._valueCodigoPaisCob == value)return;
                 this._valueCodigoPaisCob = value; 
            } 
        } 

       protected string _compradorClienteOriginal{get;private set;}
       private string _compradorClienteOriginalCommited{get; set;}
        private string _valueCompradorCliente;
         [Column("cli_comprador_cliente")]
        public virtual string CompradorCliente
         { 
            get { return this._valueCompradorCliente; } 
            set 
            { 
                if (this._valueCompradorCliente == value)return;
                 this._valueCompradorCliente = value; 
            } 
        } 

       protected bool? _permiteCustomizacaoProdutoOriginal{get;private set;}
       private bool? _permiteCustomizacaoProdutoOriginalCommited{get; set;}
        private bool? _valuePermiteCustomizacaoProduto;
         [Column("cli_permite_customizacao_produto")]
        public virtual bool? PermiteCustomizacaoProduto
         { 
            get { return this._valuePermiteCustomizacaoProduto; } 
            set 
            { 
                if (this._valuePermiteCustomizacaoProduto == value)return;
                 this._valuePermiteCustomizacaoProduto = value; 
            } 
        } 

       protected string _complementoOriginal{get;private set;}
       private string _complementoOriginalCommited{get; set;}
        private string _valueComplemento;
         [Column("cli_complemento")]
        public virtual string Complemento
         { 
            get { return this._valueComplemento; } 
            set 
            { 
                if (this._valueComplemento == value)return;
                 this._valueComplemento = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EstadoClass _estadoCobOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstadoClass _estadoCobOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstadoClass _valueEstadoCob;
        [Column("id_estado_cob", "estado", "id_estado")]
       public virtual BibliotecaEntidades.Entidades.EstadoClass EstadoCob
        { 
           get {                 return this._valueEstadoCob; } 
           set 
           { 
                if (this._valueEstadoCob == value)return;
                 this._valueEstadoCob = value; 
           } 
       } 

       protected string _enderecoNumeroOriginal{get;private set;}
       private string _enderecoNumeroOriginalCommited{get; set;}
        private string _valueEnderecoNumero;
         [Column("cli_endereco_numero")]
        public virtual string EnderecoNumero
         { 
            get { return this._valueEnderecoNumero; } 
            set 
            { 
                if (this._valueEnderecoNumero == value)return;
                 this._valueEnderecoNumero = value; 
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

       protected BibliotecaEntidades.Entidades.FamiliaClienteClass _familiaClienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FamiliaClienteClass _familiaClienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FamiliaClienteClass _valueFamiliaCliente;
        [Column("id_familia_cliente", "familia_cliente", "id_familia_cliente")]
       public virtual BibliotecaEntidades.Entidades.FamiliaClienteClass FamiliaCliente
        { 
           get {                 return this._valueFamiliaCliente; } 
           set 
           { 
                if (this._valueFamiliaCliente == value)return;
                 this._valueFamiliaCliente = value; 
           } 
       } 

       protected ClienteTipoDimensionamentoVolumetrico _tipoDimensionamentoVolumetricoOriginal{get;private set;}
       private ClienteTipoDimensionamentoVolumetrico _tipoDimensionamentoVolumetricoOriginalCommited{get; set;}
        private ClienteTipoDimensionamentoVolumetrico _valueTipoDimensionamentoVolumetrico;
         [Column("cli_tipo_dimensionamento_volumetrico")]
        public virtual ClienteTipoDimensionamentoVolumetrico TipoDimensionamentoVolumetrico
         { 
            get { return this._valueTipoDimensionamentoVolumetrico; } 
            set 
            { 
                if (this._valueTipoDimensionamentoVolumetrico == value)return;
                 this._valueTipoDimensionamentoVolumetrico = value; 
            } 
        } 

        public bool TipoDimensionamentoVolumetrico_Cubagem
         { 
            get { return this._valueTipoDimensionamentoVolumetrico == BibliotecaEntidades.Base.ClienteTipoDimensionamentoVolumetrico.Cubagem; } 
            set { if (value) this._valueTipoDimensionamentoVolumetrico = BibliotecaEntidades.Base.ClienteTipoDimensionamentoVolumetrico.Cubagem; }
         } 

        public bool TipoDimensionamentoVolumetrico_Dimensoes
         { 
            get { return this._valueTipoDimensionamentoVolumetrico == BibliotecaEntidades.Base.ClienteTipoDimensionamentoVolumetrico.Dimensoes; } 
            set { if (value) this._valueTipoDimensionamentoVolumetrico = BibliotecaEntidades.Base.ClienteTipoDimensionamentoVolumetrico.Dimensoes; }
         } 

       protected bool _utilizarControlesClienteOriginal{get;private set;}
       private bool _utilizarControlesClienteOriginalCommited{get; set;}
        private bool _valueUtilizarControlesCliente;
         [Column("cli_utilizar_controles_cliente")]
        public virtual bool UtilizarControlesCliente
         { 
            get { return this._valueUtilizarControlesCliente; } 
            set 
            { 
                if (this._valueUtilizarControlesCliente == value)return;
                 this._valueUtilizarControlesCliente = value; 
            } 
        } 

       protected ResponsavelFrete _responsavelFreteOriginal{get;private set;}
       private ResponsavelFrete _responsavelFreteOriginalCommited{get; set;}
        private ResponsavelFrete _valueResponsavelFrete;
         [Column("cli_responsavel_frete")]
        public virtual ResponsavelFrete ResponsavelFrete
         { 
            get { return this._valueResponsavelFrete; } 
            set 
            { 
                if (this._valueResponsavelFrete == value)return;
                 this._valueResponsavelFrete = value; 
            } 
        } 

        public bool ResponsavelFrete_ProprioRemetente
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.ProprioRemetente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.ProprioRemetente; }
         } 

        public bool ResponsavelFrete_ProprioDestinatario
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.ProprioDestinatario; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.ProprioDestinatario; }
         } 

        public bool ResponsavelFrete_Emitente
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.Emitente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Emitente; }
         } 

        public bool ResponsavelFrete_Cliente
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.Cliente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Cliente; }
         } 

        public bool ResponsavelFrete_Terceiros
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.Terceiros; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Terceiros; }
         } 

        public bool ResponsavelFrete_SemFrete
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.SemFrete; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.SemFrete; }
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

       protected BibliotecaEntidades.Entidades.CidadeClass _cidadeCobOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CidadeClass _cidadeCobOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CidadeClass _valueCidadeCob;
        [Column("id_cidade_cob", "cidade", "id_cidade")]
       public virtual BibliotecaEntidades.Entidades.CidadeClass CidadeCob
        { 
           get {                 return this._valueCidadeCob; } 
           set 
           { 
                if (this._valueCidadeCob == value)return;
                 this._valueCidadeCob = value; 
           } 
       } 

       protected string _observacaoPadraoNfeOriginal{get;private set;}
       private string _observacaoPadraoNfeOriginalCommited{get; set;}
        private string _valueObservacaoPadraoNfe;
         [Column("cli_observacao_padrao_nfe")]
        public virtual string ObservacaoPadraoNfe
         { 
            get { return this._valueObservacaoPadraoNfe; } 
            set 
            { 
                if (this._valueObservacaoPadraoNfe == value)return;
                 this._valueObservacaoPadraoNfe = value; 
            } 
        } 

       protected bool _envioEmailOriginal{get;private set;}
       private bool _envioEmailOriginalCommited{get; set;}
        private bool _valueEnvioEmail;
         [Column("cli_envio_email")]
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
         [Column("cli_email_pedido")]
        public virtual string EmailPedido
         { 
            get { return this._valueEmailPedido; } 
            set 
            { 
                if (this._valueEmailPedido == value)return;
                 this._valueEmailPedido = value; 
            } 
        } 

       protected string _emailOrcamentoOriginal{get;private set;}
       private string _emailOrcamentoOriginalCommited{get; set;}
        private string _valueEmailOrcamento;
         [Column("cli_email_orcamento")]
        public virtual string EmailOrcamento
         { 
            get { return this._valueEmailOrcamento; } 
            set 
            { 
                if (this._valueEmailOrcamento == value)return;
                 this._valueEmailOrcamento = value; 
            } 
        } 

       protected string _contatoOriginal{get;private set;}
       private string _contatoOriginalCommited{get; set;}
        private string _valueContato;
         [Column("cli_contato")]
        public virtual string Contato
         { 
            get { return this._valueContato; } 
            set 
            { 
                if (this._valueContato == value)return;
                 this._valueContato = value; 
            } 
        } 

       protected string _emailDanfeOriginal{get;private set;}
       private string _emailDanfeOriginalCommited{get; set;}
        private string _valueEmailDanfe;
         [Column("cli_email_danfe")]
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
         [Column("cli_email_xml")]
        public virtual string EmailXml
         { 
            get { return this._valueEmailXml; } 
            set 
            { 
                if (this._valueEmailXml == value)return;
                 this._valueEmailXml = value; 
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

       protected double? _percComissaoRepresentanteOriginal{get;private set;}
       private double? _percComissaoRepresentanteOriginalCommited{get; set;}
        private double? _valuePercComissaoRepresentante;
         [Column("cli_perc_comissao_representante")]
        public virtual double? PercComissaoRepresentante
         { 
            get { return this._valuePercComissaoRepresentante; } 
            set 
            { 
                if (this._valuePercComissaoRepresentante == value)return;
                 this._valuePercComissaoRepresentante = value; 
            } 
        } 

       protected double? _percComissaoVendedorOriginal{get;private set;}
       private double? _percComissaoVendedorOriginalCommited{get; set;}
        private double? _valuePercComissaoVendedor;
         [Column("cli_perc_comissao_vendedor")]
        public virtual double? PercComissaoVendedor
         { 
            get { return this._valuePercComissaoVendedor; } 
            set 
            { 
                if (this._valuePercComissaoVendedor == value)return;
                 this._valuePercComissaoVendedor = value; 
            } 
        } 

       protected string _avisoFaturamentoOriginal{get;private set;}
       private string _avisoFaturamentoOriginalCommited{get; set;}
        private string _valueAvisoFaturamento;
         [Column("cli_aviso_faturamento")]
        public virtual string AvisoFaturamento
         { 
            get { return this._valueAvisoFaturamento; } 
            set 
            { 
                if (this._valueAvisoFaturamento == value)return;
                 this._valueAvisoFaturamento = value; 
            } 
        } 

       protected IWTNFIndicadorIE _indicadorIeOriginal{get;private set;}
       private IWTNFIndicadorIE _indicadorIeOriginalCommited{get; set;}
        private IWTNFIndicadorIE _valueIndicadorIe;
         [Column("cli_indicador_ie")]
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

       protected string _inscricaoSuframaOriginal{get;private set;}
       private string _inscricaoSuframaOriginalCommited{get; set;}
        private string _valueInscricaoSuframa;
         [Column("cli_inscricao_suframa")]
        public virtual string InscricaoSuframa
         { 
            get { return this._valueInscricaoSuframa; } 
            set 
            { 
                if (this._valueInscricaoSuframa == value)return;
                 this._valueInscricaoSuframa = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.TipoPagamentoClass _tipoPagamentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.TipoPagamentoClass _tipoPagamentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.TipoPagamentoClass _valueTipoPagamento;
        [Column("id_tipo_pagamento", "tipo_pagamento", "id_tipo_pagamento")]
       public virtual BibliotecaEntidades.Entidades.TipoPagamentoClass TipoPagamento
        { 
           get {                 return this._valueTipoPagamento; } 
           set 
           { 
                if (this._valueTipoPagamento == value)return;
                 this._valueTipoPagamento = value; 
           } 
       } 

       private List<long> _collectionCliEassaIdentificaClienteClassClienteOriginal;
       private List<Entidades.CliEassaIdentificaClienteClass > _collectionCliEassaIdentificaClienteClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCliEassaIdentificaClienteClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCliEassaIdentificaClienteClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCliEassaIdentificaClienteClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CliEassaIdentificaClienteClass> _valueCollectionCliEassaIdentificaClienteClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CliEassaIdentificaClienteClass> CollectionCliEassaIdentificaClienteClassCliente 
       { 
           get { if(!_valueCollectionCliEassaIdentificaClienteClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionCliEassaIdentificaClienteClassCliente();}
return this._valueCollectionCliEassaIdentificaClienteClassCliente; } 
           set 
           { 
               this._valueCollectionCliEassaIdentificaClienteClassCliente = value; 
               this._valueCollectionCliEassaIdentificaClienteClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionClienteContatoClassClienteOriginal;
       private List<Entidades.ClienteContatoClass > _collectionClienteContatoClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteContatoClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteContatoClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteContatoClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteContatoClass> _valueCollectionClienteContatoClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteContatoClass> CollectionClienteContatoClassCliente 
       { 
           get { if(!_valueCollectionClienteContatoClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteContatoClassCliente();}
return this._valueCollectionClienteContatoClassCliente; } 
           set 
           { 
               this._valueCollectionClienteContatoClassCliente = value; 
               this._valueCollectionClienteContatoClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberClassClienteOriginal;
       private List<Entidades.ContaReceberClass > _collectionContaReceberClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberClass> _valueCollectionContaReceberClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberClass> CollectionContaReceberClassCliente 
       { 
           get { if(!_valueCollectionContaReceberClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberClassCliente();}
return this._valueCollectionContaReceberClassCliente; } 
           set 
           { 
               this._valueCollectionContaReceberClassCliente = value; 
               this._valueCollectionContaReceberClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberBoletoClassClienteOriginal;
       private List<Entidades.ContaReceberBoletoClass > _collectionContaReceberBoletoClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberBoletoClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberBoletoClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberBoletoClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberBoletoClass> _valueCollectionContaReceberBoletoClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberBoletoClass> CollectionContaReceberBoletoClassCliente 
       { 
           get { if(!_valueCollectionContaReceberBoletoClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberBoletoClassCliente();}
return this._valueCollectionContaReceberBoletoClassCliente; } 
           set 
           { 
               this._valueCollectionContaReceberBoletoClassCliente = value; 
               this._valueCollectionContaReceberBoletoClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionContaRecorrenteClassClienteOriginal;
       private List<Entidades.ContaRecorrenteClass > _collectionContaRecorrenteClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaRecorrenteClass> _valueCollectionContaRecorrenteClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaRecorrenteClass> CollectionContaRecorrenteClassCliente 
       { 
           get { if(!_valueCollectionContaRecorrenteClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionContaRecorrenteClassCliente();}
return this._valueCollectionContaRecorrenteClassCliente; } 
           set 
           { 
               this._valueCollectionContaRecorrenteClassCliente = value; 
               this._valueCollectionContaRecorrenteClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionCredorDevedorClassClienteOriginal;
       private List<Entidades.CredorDevedorClass > _collectionCredorDevedorClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CredorDevedorClass> _valueCollectionCredorDevedorClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CredorDevedorClass> CollectionCredorDevedorClassCliente 
       { 
           get { if(!_valueCollectionCredorDevedorClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionCredorDevedorClassCliente();}
return this._valueCollectionCredorDevedorClassCliente; } 
           set 
           { 
               this._valueCollectionCredorDevedorClassCliente = value; 
               this._valueCollectionCredorDevedorClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionLoteClassClienteOriginal;
       private List<Entidades.LoteClass > _collectionLoteClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LoteClass> _valueCollectionLoteClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LoteClass> CollectionLoteClassCliente 
       { 
           get { if(!_valueCollectionLoteClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionLoteClassCliente();}
return this._valueCollectionLoteClassCliente; } 
           set 
           { 
               this._valueCollectionLoteClassCliente = value; 
               this._valueCollectionLoteClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoConfiguradoClassClienteOriginal;
       private List<Entidades.OrcamentoConfiguradoClass > _collectionOrcamentoConfiguradoClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoConfiguradoClass> _valueCollectionOrcamentoConfiguradoClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoConfiguradoClass> CollectionOrcamentoConfiguradoClassCliente 
       { 
           get { if(!_valueCollectionOrcamentoConfiguradoClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoConfiguradoClassCliente();}
return this._valueCollectionOrcamentoConfiguradoClassCliente; } 
           set 
           { 
               this._valueCollectionOrcamentoConfiguradoClassCliente = value; 
               this._valueCollectionOrcamentoConfiguradoClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemClassClienteOriginal;
       private List<Entidades.OrcamentoItemClass > _collectionOrcamentoItemClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemClass> _valueCollectionOrcamentoItemClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemClass> CollectionOrcamentoItemClassCliente 
       { 
           get { if(!_valueCollectionOrcamentoItemClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemClassCliente();}
return this._valueCollectionOrcamentoItemClassCliente; } 
           set 
           { 
               this._valueCollectionOrcamentoItemClassCliente = value; 
               this._valueCollectionOrcamentoItemClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemVariavelClassClienteOriginal;
       private List<Entidades.OrcamentoItemVariavelClass > _collectionOrcamentoItemVariavelClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemVariavelClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemVariavelClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemVariavelClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemVariavelClass> _valueCollectionOrcamentoItemVariavelClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemVariavelClass> CollectionOrcamentoItemVariavelClassCliente 
       { 
           get { if(!_valueCollectionOrcamentoItemVariavelClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemVariavelClassCliente();}
return this._valueCollectionOrcamentoItemVariavelClassCliente; } 
           set 
           { 
               this._valueCollectionOrcamentoItemVariavelClassCliente = value; 
               this._valueCollectionOrcamentoItemVariavelClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoKitClassClienteOriginal;
       private List<Entidades.OrcamentoKitClass > _collectionOrcamentoKitClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoKitClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoKitClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoKitClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoKitClass> _valueCollectionOrcamentoKitClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoKitClass> CollectionOrcamentoKitClassCliente 
       { 
           get { if(!_valueCollectionOrcamentoKitClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoKitClassCliente();}
return this._valueCollectionOrcamentoKitClassCliente; } 
           set 
           { 
               this._valueCollectionOrcamentoKitClassCliente = value; 
               this._valueCollectionOrcamentoKitClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoVariavelClassClienteOriginal;
       private List<Entidades.OrcamentoVariavelClass > _collectionOrcamentoVariavelClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoVariavelClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoVariavelClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoVariavelClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoVariavelClass> _valueCollectionOrcamentoVariavelClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoVariavelClass> CollectionOrcamentoVariavelClassCliente 
       { 
           get { if(!_valueCollectionOrcamentoVariavelClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoVariavelClassCliente();}
return this._valueCollectionOrcamentoVariavelClassCliente; } 
           set 
           { 
               this._valueCollectionOrcamentoVariavelClassCliente = value; 
               this._valueCollectionOrcamentoVariavelClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaClassClienteOriginal;
       private List<Entidades.OrderItemEtiquetaClass > _collectionOrderItemEtiquetaClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaClass> _valueCollectionOrderItemEtiquetaClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaClass> CollectionOrderItemEtiquetaClassCliente 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaClassCliente();}
return this._valueCollectionOrderItemEtiquetaClassCliente; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaClassCliente = value; 
               this._valueCollectionOrderItemEtiquetaClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassClienteOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassCliente 
       { 
           get { if(!_valueCollectionPedidoItemClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassCliente();}
return this._valueCollectionPedidoItemClassCliente; } 
           set 
           { 
               this._valueCollectionPedidoItemClassCliente = value; 
               this._valueCollectionPedidoItemClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassClienteEnvioTerceirosOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassClienteEnvioTerceirosRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassClienteEnvioTerceirosChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassClienteEnvioTerceirosCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassClienteEnvioTerceiros { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassClienteEnvioTerceiros 
       { 
           get { if(!_valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassClienteEnvioTerceiros();}
return this._valueCollectionPedidoItemClassClienteEnvioTerceiros; } 
           set 
           { 
               this._valueCollectionPedidoItemClassClienteEnvioTerceiros = value; 
               this._valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemVariavelClassClienteOriginal;
       private List<Entidades.PedidoItemVariavelClass > _collectionPedidoItemVariavelClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemVariavelClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemVariavelClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemVariavelClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemVariavelClass> _valueCollectionPedidoItemVariavelClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemVariavelClass> CollectionPedidoItemVariavelClassCliente 
       { 
           get { if(!_valueCollectionPedidoItemVariavelClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemVariavelClassCliente();}
return this._valueCollectionPedidoItemVariavelClassCliente; } 
           set 
           { 
               this._valueCollectionPedidoItemVariavelClassCliente = value; 
               this._valueCollectionPedidoItemVariavelClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoKitClassClienteOriginal;
       private List<Entidades.PedidoKitClass > _collectionPedidoKitClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoKitClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoKitClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoKitClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoKitClass> _valueCollectionPedidoKitClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoKitClass> CollectionPedidoKitClassCliente 
       { 
           get { if(!_valueCollectionPedidoKitClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoKitClassCliente();}
return this._valueCollectionPedidoKitClassCliente; } 
           set 
           { 
               this._valueCollectionPedidoKitClassCliente = value; 
               this._valueCollectionPedidoKitClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoVariavelClassClienteOriginal;
       private List<Entidades.PedidoVariavelClass > _collectionPedidoVariavelClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoVariavelClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoVariavelClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoVariavelClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoVariavelClass> _valueCollectionPedidoVariavelClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoVariavelClass> CollectionPedidoVariavelClassCliente 
       { 
           get { if(!_valueCollectionPedidoVariavelClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoVariavelClassCliente();}
return this._valueCollectionPedidoVariavelClassCliente; } 
           set 
           { 
               this._valueCollectionPedidoVariavelClassCliente = value; 
               this._valueCollectionPedidoVariavelClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassClienteOriginal;
       private List<Entidades.ProdutoClass > _collectionProdutoClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassCliente 
       { 
           get { if(!_valueCollectionProdutoClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassCliente();}
return this._valueCollectionProdutoClassCliente; } 
           set 
           { 
               this._valueCollectionProdutoClassCliente = value; 
               this._valueCollectionProdutoClassClienteLoaded = true; 
           } 
       } 

       private List<long> _collectionTabelaPrecoItemVariavelClassClienteOriginal;
       private List<Entidades.TabelaPrecoItemVariavelClass > _collectionTabelaPrecoItemVariavelClassClienteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTabelaPrecoItemVariavelClassClienteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTabelaPrecoItemVariavelClassClienteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTabelaPrecoItemVariavelClassClienteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.TabelaPrecoItemVariavelClass> _valueCollectionTabelaPrecoItemVariavelClassCliente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.TabelaPrecoItemVariavelClass> CollectionTabelaPrecoItemVariavelClassCliente 
       { 
           get { if(!_valueCollectionTabelaPrecoItemVariavelClassClienteLoaded && !this.DisableLoadCollection){this.LoadCollectionTabelaPrecoItemVariavelClassCliente();}
return this._valueCollectionTabelaPrecoItemVariavelClassCliente; } 
           set 
           { 
               this._valueCollectionTabelaPrecoItemVariavelClassCliente = value; 
               this._valueCollectionTabelaPrecoItemVariavelClassClienteLoaded = true; 
           } 
       } 

        public ClienteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.PermiteCustomizacaoProduto = false;
           this.TipoDimensionamentoVolumetrico = (ClienteTipoDimensionamentoVolumetrico)0;
           this.UtilizarControlesCliente = false;
           this.ResponsavelFrete = (ResponsavelFrete)0;
           this.EnvioEmail = false;
           this.IndicadorIe = (IWTNFIndicadorIE)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ClienteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ClienteClass) GetEntity(typeof(ClienteClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionCliEassaIdentificaClienteClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCliEassaIdentificaClienteClassClienteChanged = true;
                  _valueCollectionCliEassaIdentificaClienteClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCliEassaIdentificaClienteClassClienteChanged = true; 
                  _valueCollectionCliEassaIdentificaClienteClassClienteCommitedChanged = true;
                 foreach (Entidades.CliEassaIdentificaClienteClass item in e.OldItems) 
                 { 
                     _collectionCliEassaIdentificaClienteClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCliEassaIdentificaClienteClassClienteChanged = true; 
                  _valueCollectionCliEassaIdentificaClienteClassClienteCommitedChanged = true;
                 foreach (Entidades.CliEassaIdentificaClienteClass item in _valueCollectionCliEassaIdentificaClienteClassCliente) 
                 { 
                     _collectionCliEassaIdentificaClienteClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCliEassaIdentificaClienteClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.CliEassaIdentificaClienteClass> oc;
                _valueCollectionCliEassaIdentificaClienteClassClienteChanged = false;
                 _valueCollectionCliEassaIdentificaClienteClassClienteCommitedChanged = false;
                _collectionCliEassaIdentificaClienteClassClienteRemovidos = new List<Entidades.CliEassaIdentificaClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CliEassaIdentificaClienteClass>();
                }
                else{ 
                   Entidades.CliEassaIdentificaClienteClass search = new Entidades.CliEassaIdentificaClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CliEassaIdentificaClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.CliEassaIdentificaClienteClass>().ToList());
                 }
                 _valueCollectionCliEassaIdentificaClienteClassCliente = new BindingList<Entidades.CliEassaIdentificaClienteClass>(oc); 
                 _collectionCliEassaIdentificaClienteClassClienteOriginal= (from a in _valueCollectionCliEassaIdentificaClienteClassCliente select a.ID).ToList();
                 _valueCollectionCliEassaIdentificaClienteClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionCliEassaIdentificaClienteClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCliEassaIdentificaClienteClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionClienteContatoClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteContatoClassClienteChanged = true;
                  _valueCollectionClienteContatoClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteContatoClassClienteChanged = true; 
                  _valueCollectionClienteContatoClassClienteCommitedChanged = true;
                 foreach (Entidades.ClienteContatoClass item in e.OldItems) 
                 { 
                     _collectionClienteContatoClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteContatoClassClienteChanged = true; 
                  _valueCollectionClienteContatoClassClienteCommitedChanged = true;
                 foreach (Entidades.ClienteContatoClass item in _valueCollectionClienteContatoClassCliente) 
                 { 
                     _collectionClienteContatoClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteContatoClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteContatoClass> oc;
                _valueCollectionClienteContatoClassClienteChanged = false;
                 _valueCollectionClienteContatoClassClienteCommitedChanged = false;
                _collectionClienteContatoClassClienteRemovidos = new List<Entidades.ClienteContatoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteContatoClass>();
                }
                else{ 
                   Entidades.ClienteContatoClass search = new Entidades.ClienteContatoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteContatoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.ClienteContatoClass>().ToList());
                 }
                 _valueCollectionClienteContatoClassCliente = new BindingList<Entidades.ClienteContatoClass>(oc); 
                 _collectionClienteContatoClassClienteOriginal= (from a in _valueCollectionClienteContatoClassCliente select a.ID).ToList();
                 _valueCollectionClienteContatoClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionClienteContatoClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteContatoClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberClassClienteChanged = true;
                  _valueCollectionContaReceberClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberClassClienteChanged = true; 
                  _valueCollectionContaReceberClassClienteCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in e.OldItems) 
                 { 
                     _collectionContaReceberClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberClassClienteChanged = true; 
                  _valueCollectionContaReceberClassClienteCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in _valueCollectionContaReceberClassCliente) 
                 { 
                     _collectionContaReceberClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberClass> oc;
                _valueCollectionContaReceberClassClienteChanged = false;
                 _valueCollectionContaReceberClassClienteCommitedChanged = false;
                _collectionContaReceberClassClienteRemovidos = new List<Entidades.ContaReceberClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberClass>();
                }
                else{ 
                   Entidades.ContaReceberClass search = new Entidades.ContaReceberClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this)                    }                       ).Cast<Entidades.ContaReceberClass>().ToList());
                 }
                 _valueCollectionContaReceberClassCliente = new BindingList<Entidades.ContaReceberClass>(oc); 
                 _collectionContaReceberClassClienteOriginal= (from a in _valueCollectionContaReceberClassCliente select a.ID).ToList();
                 _valueCollectionContaReceberClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberBoletoClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberBoletoClassClienteChanged = true;
                  _valueCollectionContaReceberBoletoClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberBoletoClassClienteChanged = true; 
                  _valueCollectionContaReceberBoletoClassClienteCommitedChanged = true;
                 foreach (Entidades.ContaReceberBoletoClass item in e.OldItems) 
                 { 
                     _collectionContaReceberBoletoClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberBoletoClassClienteChanged = true; 
                  _valueCollectionContaReceberBoletoClassClienteCommitedChanged = true;
                 foreach (Entidades.ContaReceberBoletoClass item in _valueCollectionContaReceberBoletoClassCliente) 
                 { 
                     _collectionContaReceberBoletoClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberBoletoClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberBoletoClass> oc;
                _valueCollectionContaReceberBoletoClassClienteChanged = false;
                 _valueCollectionContaReceberBoletoClassClienteCommitedChanged = false;
                _collectionContaReceberBoletoClassClienteRemovidos = new List<Entidades.ContaReceberBoletoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberBoletoClass>();
                }
                else{ 
                   Entidades.ContaReceberBoletoClass search = new Entidades.ContaReceberBoletoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberBoletoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.ContaReceberBoletoClass>().ToList());
                 }
                 _valueCollectionContaReceberBoletoClassCliente = new BindingList<Entidades.ContaReceberBoletoClass>(oc); 
                 _collectionContaReceberBoletoClassClienteOriginal= (from a in _valueCollectionContaReceberBoletoClassCliente select a.ID).ToList();
                 _valueCollectionContaReceberBoletoClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberBoletoClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberBoletoClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaRecorrenteClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaRecorrenteClassClienteChanged = true;
                  _valueCollectionContaRecorrenteClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaRecorrenteClassClienteChanged = true; 
                  _valueCollectionContaRecorrenteClassClienteCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in e.OldItems) 
                 { 
                     _collectionContaRecorrenteClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaRecorrenteClassClienteChanged = true; 
                  _valueCollectionContaRecorrenteClassClienteCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in _valueCollectionContaRecorrenteClassCliente) 
                 { 
                     _collectionContaRecorrenteClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaRecorrenteClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.ContaRecorrenteClass> oc;
                _valueCollectionContaRecorrenteClassClienteChanged = false;
                 _valueCollectionContaRecorrenteClassClienteCommitedChanged = false;
                _collectionContaRecorrenteClassClienteRemovidos = new List<Entidades.ContaRecorrenteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaRecorrenteClass>();
                }
                else{ 
                   Entidades.ContaRecorrenteClass search = new Entidades.ContaRecorrenteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaRecorrenteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.ContaRecorrenteClass>().ToList());
                 }
                 _valueCollectionContaRecorrenteClassCliente = new BindingList<Entidades.ContaRecorrenteClass>(oc); 
                 _collectionContaRecorrenteClassClienteOriginal= (from a in _valueCollectionContaRecorrenteClassCliente select a.ID).ToList();
                 _valueCollectionContaRecorrenteClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionContaRecorrenteClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaRecorrenteClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionCredorDevedorClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCredorDevedorClassClienteChanged = true;
                  _valueCollectionCredorDevedorClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCredorDevedorClassClienteChanged = true; 
                  _valueCollectionCredorDevedorClassClienteCommitedChanged = true;
                 foreach (Entidades.CredorDevedorClass item in e.OldItems) 
                 { 
                     _collectionCredorDevedorClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCredorDevedorClassClienteChanged = true; 
                  _valueCollectionCredorDevedorClassClienteCommitedChanged = true;
                 foreach (Entidades.CredorDevedorClass item in _valueCollectionCredorDevedorClassCliente) 
                 { 
                     _collectionCredorDevedorClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCredorDevedorClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.CredorDevedorClass> oc;
                _valueCollectionCredorDevedorClassClienteChanged = false;
                 _valueCollectionCredorDevedorClassClienteCommitedChanged = false;
                _collectionCredorDevedorClassClienteRemovidos = new List<Entidades.CredorDevedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CredorDevedorClass>();
                }
                else{ 
                   Entidades.CredorDevedorClass search = new Entidades.CredorDevedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CredorDevedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.CredorDevedorClass>().ToList());
                 }
                 _valueCollectionCredorDevedorClassCliente = new BindingList<Entidades.CredorDevedorClass>(oc); 
                 _collectionCredorDevedorClassClienteOriginal= (from a in _valueCollectionCredorDevedorClassCliente select a.ID).ToList();
                 _valueCollectionCredorDevedorClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionCredorDevedorClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCredorDevedorClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionLoteClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLoteClassClienteChanged = true;
                  _valueCollectionLoteClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLoteClassClienteChanged = true; 
                  _valueCollectionLoteClassClienteCommitedChanged = true;
                 foreach (Entidades.LoteClass item in e.OldItems) 
                 { 
                     _collectionLoteClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLoteClassClienteChanged = true; 
                  _valueCollectionLoteClassClienteCommitedChanged = true;
                 foreach (Entidades.LoteClass item in _valueCollectionLoteClassCliente) 
                 { 
                     _collectionLoteClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLoteClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.LoteClass> oc;
                _valueCollectionLoteClassClienteChanged = false;
                 _valueCollectionLoteClassClienteCommitedChanged = false;
                _collectionLoteClassClienteRemovidos = new List<Entidades.LoteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LoteClass>();
                }
                else{ 
                   Entidades.LoteClass search = new Entidades.LoteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LoteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.LoteClass>().ToList());
                 }
                 _valueCollectionLoteClassCliente = new BindingList<Entidades.LoteClass>(oc); 
                 _collectionLoteClassClienteOriginal= (from a in _valueCollectionLoteClassCliente select a.ID).ToList();
                 _valueCollectionLoteClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionLoteClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLoteClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoConfiguradoClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoConfiguradoClassClienteChanged = true;
                  _valueCollectionOrcamentoConfiguradoClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoConfiguradoClassClienteChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoConfiguradoClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoConfiguradoClassClienteChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in _valueCollectionOrcamentoConfiguradoClassCliente) 
                 { 
                     _collectionOrcamentoConfiguradoClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoConfiguradoClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoConfiguradoClass> oc;
                _valueCollectionOrcamentoConfiguradoClassClienteChanged = false;
                 _valueCollectionOrcamentoConfiguradoClassClienteCommitedChanged = false;
                _collectionOrcamentoConfiguradoClassClienteRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoConfiguradoClass>();
                }
                else{ 
                   Entidades.OrcamentoConfiguradoClass search = new Entidades.OrcamentoConfiguradoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoConfiguradoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.OrcamentoConfiguradoClass>().ToList());
                 }
                 _valueCollectionOrcamentoConfiguradoClassCliente = new BindingList<Entidades.OrcamentoConfiguradoClass>(oc); 
                 _collectionOrcamentoConfiguradoClassClienteOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassCliente select a.ID).ToList();
                 _valueCollectionOrcamentoConfiguradoClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoConfiguradoClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoConfiguradoClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemClassClienteChanged = true;
                  _valueCollectionOrcamentoItemClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemClassClienteChanged = true; 
                  _valueCollectionOrcamentoItemClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemClassClienteChanged = true; 
                  _valueCollectionOrcamentoItemClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in _valueCollectionOrcamentoItemClassCliente) 
                 { 
                     _collectionOrcamentoItemClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemClass> oc;
                _valueCollectionOrcamentoItemClassClienteChanged = false;
                 _valueCollectionOrcamentoItemClassClienteCommitedChanged = false;
                _collectionOrcamentoItemClassClienteRemovidos = new List<Entidades.OrcamentoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemClass>();
                }
                else{ 
                   Entidades.OrcamentoItemClass search = new Entidades.OrcamentoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.OrcamentoItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemClassCliente = new BindingList<Entidades.OrcamentoItemClass>(oc); 
                 _collectionOrcamentoItemClassClienteOriginal= (from a in _valueCollectionOrcamentoItemClassCliente select a.ID).ToList();
                 _valueCollectionOrcamentoItemClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemVariavelClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemVariavelClassClienteChanged = true;
                  _valueCollectionOrcamentoItemVariavelClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemVariavelClassClienteChanged = true; 
                  _valueCollectionOrcamentoItemVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemVariavelClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemVariavelClassClienteChanged = true; 
                  _valueCollectionOrcamentoItemVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemVariavelClass item in _valueCollectionOrcamentoItemVariavelClassCliente) 
                 { 
                     _collectionOrcamentoItemVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemVariavelClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemVariavelClass> oc;
                _valueCollectionOrcamentoItemVariavelClassClienteChanged = false;
                 _valueCollectionOrcamentoItemVariavelClassClienteCommitedChanged = false;
                _collectionOrcamentoItemVariavelClassClienteRemovidos = new List<Entidades.OrcamentoItemVariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemVariavelClass>();
                }
                else{ 
                   Entidades.OrcamentoItemVariavelClass search = new Entidades.OrcamentoItemVariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemVariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.OrcamentoItemVariavelClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemVariavelClassCliente = new BindingList<Entidades.OrcamentoItemVariavelClass>(oc); 
                 _collectionOrcamentoItemVariavelClassClienteOriginal= (from a in _valueCollectionOrcamentoItemVariavelClassCliente select a.ID).ToList();
                 _valueCollectionOrcamentoItemVariavelClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemVariavelClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemVariavelClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoKitClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoKitClassClienteChanged = true;
                  _valueCollectionOrcamentoKitClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoKitClassClienteChanged = true; 
                  _valueCollectionOrcamentoKitClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoKitClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoKitClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoKitClassClienteChanged = true; 
                  _valueCollectionOrcamentoKitClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoKitClass item in _valueCollectionOrcamentoKitClassCliente) 
                 { 
                     _collectionOrcamentoKitClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoKitClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoKitClass> oc;
                _valueCollectionOrcamentoKitClassClienteChanged = false;
                 _valueCollectionOrcamentoKitClassClienteCommitedChanged = false;
                _collectionOrcamentoKitClassClienteRemovidos = new List<Entidades.OrcamentoKitClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoKitClass>();
                }
                else{ 
                   Entidades.OrcamentoKitClass search = new Entidades.OrcamentoKitClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoKitClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.OrcamentoKitClass>().ToList());
                 }
                 _valueCollectionOrcamentoKitClassCliente = new BindingList<Entidades.OrcamentoKitClass>(oc); 
                 _collectionOrcamentoKitClassClienteOriginal= (from a in _valueCollectionOrcamentoKitClassCliente select a.ID).ToList();
                 _valueCollectionOrcamentoKitClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoKitClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoKitClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoVariavelClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoVariavelClassClienteChanged = true;
                  _valueCollectionOrcamentoVariavelClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoVariavelClassClienteChanged = true; 
                  _valueCollectionOrcamentoVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoVariavelClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoVariavelClassClienteChanged = true; 
                  _valueCollectionOrcamentoVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.OrcamentoVariavelClass item in _valueCollectionOrcamentoVariavelClassCliente) 
                 { 
                     _collectionOrcamentoVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoVariavelClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoVariavelClass> oc;
                _valueCollectionOrcamentoVariavelClassClienteChanged = false;
                 _valueCollectionOrcamentoVariavelClassClienteCommitedChanged = false;
                _collectionOrcamentoVariavelClassClienteRemovidos = new List<Entidades.OrcamentoVariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoVariavelClass>();
                }
                else{ 
                   Entidades.OrcamentoVariavelClass search = new Entidades.OrcamentoVariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoVariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.OrcamentoVariavelClass>().ToList());
                 }
                 _valueCollectionOrcamentoVariavelClassCliente = new BindingList<Entidades.OrcamentoVariavelClass>(oc); 
                 _collectionOrcamentoVariavelClassClienteOriginal= (from a in _valueCollectionOrcamentoVariavelClassCliente select a.ID).ToList();
                 _valueCollectionOrcamentoVariavelClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoVariavelClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoVariavelClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaClassClienteChanged = true;
                  _valueCollectionOrderItemEtiquetaClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaClassClienteChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassClienteCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaClassClienteChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassClienteCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in _valueCollectionOrderItemEtiquetaClassCliente) 
                 { 
                     _collectionOrderItemEtiquetaClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaClass> oc;
                _valueCollectionOrderItemEtiquetaClassClienteChanged = false;
                 _valueCollectionOrderItemEtiquetaClassClienteCommitedChanged = false;
                _collectionOrderItemEtiquetaClassClienteRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaClass search = new Entidades.OrderItemEtiquetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaClassCliente = new BindingList<Entidades.OrderItemEtiquetaClass>(oc); 
                 _collectionOrderItemEtiquetaClassClienteOriginal= (from a in _valueCollectionOrderItemEtiquetaClassCliente select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassClienteChanged = true;
                  _valueCollectionPedidoItemClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassClienteChanged = true; 
                  _valueCollectionPedidoItemClassClienteCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassClienteChanged = true; 
                  _valueCollectionPedidoItemClassClienteCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassCliente) 
                 { 
                     _collectionPedidoItemClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassClienteChanged = false;
                 _valueCollectionPedidoItemClassClienteCommitedChanged = false;
                _collectionPedidoItemClassClienteRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassCliente = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassClienteOriginal= (from a in _valueCollectionPedidoItemClassCliente select a.ID).ToList();
                 _valueCollectionPedidoItemClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassClienteEnvioTerceirosChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassClienteEnvioTerceirosChanged = true;
                  _valueCollectionPedidoItemClassClienteEnvioTerceirosCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassClienteEnvioTerceirosChanged = true; 
                  _valueCollectionPedidoItemClassClienteEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassClienteEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassClienteEnvioTerceirosChanged = true; 
                  _valueCollectionPedidoItemClassClienteEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassClienteEnvioTerceiros) 
                 { 
                     _collectionPedidoItemClassClienteEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassClienteEnvioTerceiros()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassClienteEnvioTerceirosChanged = false;
                 _valueCollectionPedidoItemClassClienteEnvioTerceirosCommitedChanged = false;
                _collectionPedidoItemClassClienteEnvioTerceirosRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ClienteEnvioTerceiros", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassClienteEnvioTerceiros = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassClienteEnvioTerceirosOriginal= (from a in _valueCollectionPedidoItemClassClienteEnvioTerceiros select a.ID).ToList();
                 _valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassClienteEnvioTerceirosChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassClienteEnvioTerceiros+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemVariavelClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemVariavelClassClienteChanged = true;
                  _valueCollectionPedidoItemVariavelClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemVariavelClassClienteChanged = true; 
                  _valueCollectionPedidoItemVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.PedidoItemVariavelClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemVariavelClassClienteChanged = true; 
                  _valueCollectionPedidoItemVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.PedidoItemVariavelClass item in _valueCollectionPedidoItemVariavelClassCliente) 
                 { 
                     _collectionPedidoItemVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemVariavelClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemVariavelClass> oc;
                _valueCollectionPedidoItemVariavelClassClienteChanged = false;
                 _valueCollectionPedidoItemVariavelClassClienteCommitedChanged = false;
                _collectionPedidoItemVariavelClassClienteRemovidos = new List<Entidades.PedidoItemVariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemVariavelClass>();
                }
                else{ 
                   Entidades.PedidoItemVariavelClass search = new Entidades.PedidoItemVariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemVariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.PedidoItemVariavelClass>().ToList());
                 }
                 _valueCollectionPedidoItemVariavelClassCliente = new BindingList<Entidades.PedidoItemVariavelClass>(oc); 
                 _collectionPedidoItemVariavelClassClienteOriginal= (from a in _valueCollectionPedidoItemVariavelClassCliente select a.ID).ToList();
                 _valueCollectionPedidoItemVariavelClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemVariavelClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemVariavelClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoKitClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoKitClassClienteChanged = true;
                  _valueCollectionPedidoKitClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoKitClassClienteChanged = true; 
                  _valueCollectionPedidoKitClassClienteCommitedChanged = true;
                 foreach (Entidades.PedidoKitClass item in e.OldItems) 
                 { 
                     _collectionPedidoKitClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoKitClassClienteChanged = true; 
                  _valueCollectionPedidoKitClassClienteCommitedChanged = true;
                 foreach (Entidades.PedidoKitClass item in _valueCollectionPedidoKitClassCliente) 
                 { 
                     _collectionPedidoKitClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoKitClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoKitClass> oc;
                _valueCollectionPedidoKitClassClienteChanged = false;
                 _valueCollectionPedidoKitClassClienteCommitedChanged = false;
                _collectionPedidoKitClassClienteRemovidos = new List<Entidades.PedidoKitClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoKitClass>();
                }
                else{ 
                   Entidades.PedidoKitClass search = new Entidades.PedidoKitClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoKitClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.PedidoKitClass>().ToList());
                 }
                 _valueCollectionPedidoKitClassCliente = new BindingList<Entidades.PedidoKitClass>(oc); 
                 _collectionPedidoKitClassClienteOriginal= (from a in _valueCollectionPedidoKitClassCliente select a.ID).ToList();
                 _valueCollectionPedidoKitClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionPedidoKitClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoKitClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoVariavelClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoVariavelClassClienteChanged = true;
                  _valueCollectionPedidoVariavelClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoVariavelClassClienteChanged = true; 
                  _valueCollectionPedidoVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.PedidoVariavelClass item in e.OldItems) 
                 { 
                     _collectionPedidoVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoVariavelClassClienteChanged = true; 
                  _valueCollectionPedidoVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.PedidoVariavelClass item in _valueCollectionPedidoVariavelClassCliente) 
                 { 
                     _collectionPedidoVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoVariavelClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoVariavelClass> oc;
                _valueCollectionPedidoVariavelClassClienteChanged = false;
                 _valueCollectionPedidoVariavelClassClienteCommitedChanged = false;
                _collectionPedidoVariavelClassClienteRemovidos = new List<Entidades.PedidoVariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoVariavelClass>();
                }
                else{ 
                   Entidades.PedidoVariavelClass search = new Entidades.PedidoVariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoVariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.PedidoVariavelClass>().ToList());
                 }
                 _valueCollectionPedidoVariavelClassCliente = new BindingList<Entidades.PedidoVariavelClass>(oc); 
                 _collectionPedidoVariavelClassClienteOriginal= (from a in _valueCollectionPedidoVariavelClassCliente select a.ID).ToList();
                 _valueCollectionPedidoVariavelClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionPedidoVariavelClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoVariavelClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassClienteChanged = true;
                  _valueCollectionProdutoClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassClienteChanged = true; 
                  _valueCollectionProdutoClassClienteCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassClienteChanged = true; 
                  _valueCollectionProdutoClassClienteCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassCliente) 
                 { 
                     _collectionProdutoClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassClienteChanged = false;
                 _valueCollectionProdutoClassClienteCommitedChanged = false;
                _collectionProdutoClassClienteRemovidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassCliente = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassClienteOriginal= (from a in _valueCollectionProdutoClassCliente select a.ID).ToList();
                 _valueCollectionProdutoClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionProdutoClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassCliente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionTabelaPrecoItemVariavelClassClienteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionTabelaPrecoItemVariavelClassClienteChanged = true;
                  _valueCollectionTabelaPrecoItemVariavelClassClienteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionTabelaPrecoItemVariavelClassClienteChanged = true; 
                  _valueCollectionTabelaPrecoItemVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.TabelaPrecoItemVariavelClass item in e.OldItems) 
                 { 
                     _collectionTabelaPrecoItemVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionTabelaPrecoItemVariavelClassClienteChanged = true; 
                  _valueCollectionTabelaPrecoItemVariavelClassClienteCommitedChanged = true;
                 foreach (Entidades.TabelaPrecoItemVariavelClass item in _valueCollectionTabelaPrecoItemVariavelClassCliente) 
                 { 
                     _collectionTabelaPrecoItemVariavelClassClienteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionTabelaPrecoItemVariavelClassCliente()
         {
            try
            {
                 ObservableCollection<Entidades.TabelaPrecoItemVariavelClass> oc;
                _valueCollectionTabelaPrecoItemVariavelClassClienteChanged = false;
                 _valueCollectionTabelaPrecoItemVariavelClassClienteCommitedChanged = false;
                _collectionTabelaPrecoItemVariavelClassClienteRemovidos = new List<Entidades.TabelaPrecoItemVariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.TabelaPrecoItemVariavelClass>();
                }
                else{ 
                   Entidades.TabelaPrecoItemVariavelClass search = new Entidades.TabelaPrecoItemVariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.TabelaPrecoItemVariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cliente", this),                     }                       ).Cast<Entidades.TabelaPrecoItemVariavelClass>().ToList());
                 }
                 _valueCollectionTabelaPrecoItemVariavelClassCliente = new BindingList<Entidades.TabelaPrecoItemVariavelClass>(oc); 
                 _collectionTabelaPrecoItemVariavelClassClienteOriginal= (from a in _valueCollectionTabelaPrecoItemVariavelClassCliente select a.ID).ToList();
                 _valueCollectionTabelaPrecoItemVariavelClassClienteLoaded = true;
                 oc.CollectionChanged += CollectionTabelaPrecoItemVariavelClassClienteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionTabelaPrecoItemVariavelClassCliente+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                {
                    throw new Exception(ErroNomeObrigatorio);
                }
                if (Nome.Length >255)
                {
                    throw new Exception( ErroNomeComprimento);
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
                    "  public.cliente  " +
                    "WHERE " +
                    "  id_cliente = :id";
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
                        "  public.cliente   " +
                        "SET  " + 
                        "  cli_nome = :cli_nome, " + 
                        "  cli_nome_resumido = :cli_nome_resumido, " + 
                        "  cli_data_implantacao = :cli_data_implantacao, " + 
                        "  cli_endereco = :cli_endereco, " + 
                        "  cli_bairro = :cli_bairro, " + 
                        "  cli_cep = :cli_cep, " + 
                        "  cli_fone1 = :cli_fone1, " + 
                        "  cli_ramal1 = :cli_ramal1, " + 
                        "  cli_fone2 = :cli_fone2, " + 
                        "  cli_ramal2 = :cli_ramal2, " + 
                        "  cli_fax = :cli_fax, " + 
                        "  cli_fax_ramal = :cli_fax_ramal, " + 
                        "  cli_email = :cli_email, " + 
                        "  cli_cnpj = :cli_cnpj, " + 
                        "  cli_ie = :cli_ie, " + 
                        "  cli_inscricao_municipal = :cli_inscricao_municipal, " + 
                        "  cli_inscricao_inss = :cli_inscricao_inss, " + 
                        "  cli_pais = :cli_pais, " + 
                        "  cli_endereco_cob = :cli_endereco_cob, " + 
                        "  cli_bairro_cob = :cli_bairro_cob, " + 
                        "  cli_cep_cob = :cli_cep_cob, " + 
                        "  cli_pais_cob = :cli_pais_cob, " + 
                        "  cli_observacoes = :cli_observacoes, " + 
                        "  cli_endereco_numero_cob = :cli_endereco_numero_cob, " + 
                        "  cli_complemento_cob = :cli_complemento_cob, " + 
                        "  cli_codigo_pais_cob = :cli_codigo_pais_cob, " + 
                        "  cli_comprador_cliente = :cli_comprador_cliente, " + 
                        "  cli_permite_customizacao_produto = :cli_permite_customizacao_produto, " + 
                        "  cli_complemento = :cli_complemento, " + 
                        "  id_estado_cob = :id_estado_cob, " + 
                        "  cli_endereco_numero = :cli_endereco_numero, " + 
                        "  id_estado = :id_estado, " + 
                        "  id_familia_cliente = :id_familia_cliente, " + 
                        "  cli_tipo_dimensionamento_volumetrico = :cli_tipo_dimensionamento_volumetrico, " + 
                        "  cli_utilizar_controles_cliente = :cli_utilizar_controles_cliente, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  cli_ultima_revisao = :cli_ultima_revisao, " + 
                        "  cli_ultima_revisao_data = :cli_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  cli_responsavel_frete = :cli_responsavel_frete, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  id_forma_pagamento = :id_forma_pagamento, " + 
                        "  id_cidade = :id_cidade, " + 
                        "  id_cidade_cob = :id_cidade_cob, " + 
                        "  cli_observacao_padrao_nfe = :cli_observacao_padrao_nfe, " + 
                        "  cli_envio_email = :cli_envio_email, " + 
                        "  cli_email_pedido = :cli_email_pedido, " + 
                        "  cli_email_orcamento = :cli_email_orcamento, " + 
                        "  cli_contato = :cli_contato, " + 
                        "  cli_email_danfe = :cli_email_danfe, " + 
                        "  cli_email_xml = :cli_email_xml, " + 
                        "  id_representante = :id_representante, " + 
                        "  id_vendedor = :id_vendedor, " + 
                        "  cli_perc_comissao_representante = :cli_perc_comissao_representante, " + 
                        "  cli_perc_comissao_vendedor = :cli_perc_comissao_vendedor, " + 
                        "  cli_aviso_faturamento = :cli_aviso_faturamento, " + 
                        "  cli_indicador_ie = :cli_indicador_ie, " + 
                        "  cli_inscricao_suframa = :cli_inscricao_suframa, " + 
                        "  id_tipo_pagamento = :id_tipo_pagamento "+
                        "WHERE  " +
                        "  id_cliente = :id " +
                        "RETURNING id_cliente;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.cliente " +
                        "( " +
                        "  cli_nome , " + 
                        "  cli_nome_resumido , " + 
                        "  cli_data_implantacao , " + 
                        "  cli_endereco , " + 
                        "  cli_bairro , " + 
                        "  cli_cep , " + 
                        "  cli_fone1 , " + 
                        "  cli_ramal1 , " + 
                        "  cli_fone2 , " + 
                        "  cli_ramal2 , " + 
                        "  cli_fax , " + 
                        "  cli_fax_ramal , " + 
                        "  cli_email , " + 
                        "  cli_cnpj , " + 
                        "  cli_ie , " + 
                        "  cli_inscricao_municipal , " + 
                        "  cli_inscricao_inss , " + 
                        "  cli_pais , " + 
                        "  cli_endereco_cob , " + 
                        "  cli_bairro_cob , " + 
                        "  cli_cep_cob , " + 
                        "  cli_pais_cob , " + 
                        "  cli_observacoes , " + 
                        "  cli_endereco_numero_cob , " + 
                        "  cli_complemento_cob , " + 
                        "  cli_codigo_pais_cob , " + 
                        "  cli_comprador_cliente , " + 
                        "  cli_permite_customizacao_produto , " + 
                        "  cli_complemento , " + 
                        "  id_estado_cob , " + 
                        "  cli_endereco_numero , " + 
                        "  id_estado , " + 
                        "  id_familia_cliente , " + 
                        "  cli_tipo_dimensionamento_volumetrico , " + 
                        "  cli_utilizar_controles_cliente , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  cli_ultima_revisao , " + 
                        "  cli_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  cli_responsavel_frete , " + 
                        "  id_conta_bancaria , " + 
                        "  id_centro_custo_lucro , " + 
                        "  id_forma_pagamento , " + 
                        "  id_cidade , " + 
                        "  id_cidade_cob , " + 
                        "  cli_observacao_padrao_nfe , " + 
                        "  cli_envio_email , " + 
                        "  cli_email_pedido , " + 
                        "  cli_email_orcamento , " + 
                        "  cli_contato , " + 
                        "  cli_email_danfe , " + 
                        "  cli_email_xml , " + 
                        "  id_representante , " + 
                        "  id_vendedor , " + 
                        "  cli_perc_comissao_representante , " + 
                        "  cli_perc_comissao_vendedor , " + 
                        "  cli_aviso_faturamento , " + 
                        "  cli_indicador_ie , " + 
                        "  cli_inscricao_suframa , " + 
                        "  id_tipo_pagamento  "+
                        ")  " +
                        "VALUES ( " +
                        "  :cli_nome , " + 
                        "  :cli_nome_resumido , " + 
                        "  :cli_data_implantacao , " + 
                        "  :cli_endereco , " + 
                        "  :cli_bairro , " + 
                        "  :cli_cep , " + 
                        "  :cli_fone1 , " + 
                        "  :cli_ramal1 , " + 
                        "  :cli_fone2 , " + 
                        "  :cli_ramal2 , " + 
                        "  :cli_fax , " + 
                        "  :cli_fax_ramal , " + 
                        "  :cli_email , " + 
                        "  :cli_cnpj , " + 
                        "  :cli_ie , " + 
                        "  :cli_inscricao_municipal , " + 
                        "  :cli_inscricao_inss , " + 
                        "  :cli_pais , " + 
                        "  :cli_endereco_cob , " + 
                        "  :cli_bairro_cob , " + 
                        "  :cli_cep_cob , " + 
                        "  :cli_pais_cob , " + 
                        "  :cli_observacoes , " + 
                        "  :cli_endereco_numero_cob , " + 
                        "  :cli_complemento_cob , " + 
                        "  :cli_codigo_pais_cob , " + 
                        "  :cli_comprador_cliente , " + 
                        "  :cli_permite_customizacao_produto , " + 
                        "  :cli_complemento , " + 
                        "  :id_estado_cob , " + 
                        "  :cli_endereco_numero , " + 
                        "  :id_estado , " + 
                        "  :id_familia_cliente , " + 
                        "  :cli_tipo_dimensionamento_volumetrico , " + 
                        "  :cli_utilizar_controles_cliente , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :cli_ultima_revisao , " + 
                        "  :cli_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :cli_responsavel_frete , " + 
                        "  :id_conta_bancaria , " + 
                        "  :id_centro_custo_lucro , " + 
                        "  :id_forma_pagamento , " + 
                        "  :id_cidade , " + 
                        "  :id_cidade_cob , " + 
                        "  :cli_observacao_padrao_nfe , " + 
                        "  :cli_envio_email , " + 
                        "  :cli_email_pedido , " + 
                        "  :cli_email_orcamento , " + 
                        "  :cli_contato , " + 
                        "  :cli_email_danfe , " + 
                        "  :cli_email_xml , " + 
                        "  :id_representante , " + 
                        "  :id_vendedor , " + 
                        "  :cli_perc_comissao_representante , " + 
                        "  :cli_perc_comissao_vendedor , " + 
                        "  :cli_aviso_faturamento , " + 
                        "  :cli_indicador_ie , " + 
                        "  :cli_inscricao_suframa , " + 
                        "  :id_tipo_pagamento  "+
                        ")RETURNING id_cliente;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_nome_resumido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeResumido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_data_implantacao", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataImplantacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_endereco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Endereco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_bairro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Bairro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_cep", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cep ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_fone1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_ramal1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ramal1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_fone2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_ramal2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ramal2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_fax", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fax ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_fax_ramal", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FaxRamal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_email", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Email ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnpj ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_ie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_inscricao_municipal", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InscricaoMunicipal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_inscricao_inss", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InscricaoInss ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_pais", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_endereco_cob", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnderecoCob ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_bairro_cob", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BairroCob ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_cep_cob", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CepCob ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_pais_cob", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PaisCob ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_observacoes", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacoes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_endereco_numero_cob", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnderecoNumeroCob ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_complemento_cob", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ComplementoCob ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_codigo_pais_cob", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoPaisCob ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_comprador_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompradorCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_permite_customizacao_produto", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PermiteCustomizacaoProduto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_complemento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Complemento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado_cob", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstadoCob==null ? (object) DBNull.Value : this.EstadoCob.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_endereco_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnderecoNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Estado==null ? (object) DBNull.Value : this.Estado.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_familia_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FamiliaCliente==null ? (object) DBNull.Value : this.FamiliaCliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_tipo_dimensionamento_volumetrico", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoDimensionamentoVolumetrico);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_utilizar_controles_cliente", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UtilizarControlesCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_responsavel_frete", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ResponsavelFrete);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_forma_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FormaPagamento==null ? (object) DBNull.Value : this.FormaPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cidade", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cidade==null ? (object) DBNull.Value : this.Cidade.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cidade_cob", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CidadeCob==null ? (object) DBNull.Value : this.CidadeCob.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_observacao_padrao_nfe", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacaoPadraoNfe ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_envio_email", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnvioEmail ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_email_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_email_orcamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailOrcamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_contato", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Contato ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_email_danfe", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailDanfe ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_email_xml", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailXml ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_representante", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Representante==null ? (object) DBNull.Value : this.Representante.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_vendedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Vendedor==null ? (object) DBNull.Value : this.Vendedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_perc_comissao_representante", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercComissaoRepresentante ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_perc_comissao_vendedor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercComissaoVendedor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_aviso_faturamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AvisoFaturamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_indicador_ie", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.IndicadorIe);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cli_inscricao_suframa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InscricaoSuframa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tipo_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.TipoPagamento==null ? (object) DBNull.Value : this.TipoPagamento.ID;

 
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
 if (CollectionCliEassaIdentificaClienteClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCliEassaIdentificaClienteClassCliente+"\r\n";
                foreach (Entidades.CliEassaIdentificaClienteClass tmp in CollectionCliEassaIdentificaClienteClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionClienteContatoClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteContatoClassCliente+"\r\n";
                foreach (Entidades.ClienteContatoClass tmp in CollectionClienteContatoClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberClassCliente+"\r\n";
                foreach (Entidades.ContaReceberClass tmp in CollectionContaReceberClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberBoletoClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberBoletoClassCliente+"\r\n";
                foreach (Entidades.ContaReceberBoletoClass tmp in CollectionContaReceberBoletoClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaRecorrenteClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaRecorrenteClassCliente+"\r\n";
                foreach (Entidades.ContaRecorrenteClass tmp in CollectionContaRecorrenteClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionCredorDevedorClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCredorDevedorClassCliente+"\r\n";
                foreach (Entidades.CredorDevedorClass tmp in CollectionCredorDevedorClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionLoteClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLoteClassCliente+"\r\n";
                foreach (Entidades.LoteClass tmp in CollectionLoteClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoConfiguradoClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoConfiguradoClassCliente+"\r\n";
                foreach (Entidades.OrcamentoConfiguradoClass tmp in CollectionOrcamentoConfiguradoClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassCliente+"\r\n";
                foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemVariavelClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemVariavelClassCliente+"\r\n";
                foreach (Entidades.OrcamentoItemVariavelClass tmp in CollectionOrcamentoItemVariavelClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoKitClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoKitClassCliente+"\r\n";
                foreach (Entidades.OrcamentoKitClass tmp in CollectionOrcamentoKitClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoVariavelClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoVariavelClassCliente+"\r\n";
                foreach (Entidades.OrcamentoVariavelClass tmp in CollectionOrcamentoVariavelClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaClassCliente+"\r\n";
                foreach (Entidades.OrderItemEtiquetaClass tmp in CollectionOrderItemEtiquetaClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassCliente+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassClienteEnvioTerceiros.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassClienteEnvioTerceiros+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassClienteEnvioTerceiros)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemVariavelClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemVariavelClassCliente+"\r\n";
                foreach (Entidades.PedidoItemVariavelClass tmp in CollectionPedidoItemVariavelClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoKitClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoKitClassCliente+"\r\n";
                foreach (Entidades.PedidoKitClass tmp in CollectionPedidoKitClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoVariavelClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoVariavelClassCliente+"\r\n";
                foreach (Entidades.PedidoVariavelClass tmp in CollectionPedidoVariavelClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassCliente+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassCliente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionTabelaPrecoItemVariavelClassCliente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionTabelaPrecoItemVariavelClassCliente+"\r\n";
                foreach (Entidades.TabelaPrecoItemVariavelClass tmp in CollectionTabelaPrecoItemVariavelClassCliente)
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
        public static ClienteClass CopiarEntidade(ClienteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ClienteClass toRet = new ClienteClass(usuario,conn);
 toRet.Nome= entidadeCopiar.Nome;
 toRet.NomeResumido= entidadeCopiar.NomeResumido;
 toRet.DataImplantacao= entidadeCopiar.DataImplantacao;
 toRet.Endereco= entidadeCopiar.Endereco;
 toRet.Bairro= entidadeCopiar.Bairro;
 toRet.Cep= entidadeCopiar.Cep;
 toRet.Fone1= entidadeCopiar.Fone1;
 toRet.Ramal1= entidadeCopiar.Ramal1;
 toRet.Fone2= entidadeCopiar.Fone2;
 toRet.Ramal2= entidadeCopiar.Ramal2;
 toRet.Fax= entidadeCopiar.Fax;
 toRet.FaxRamal= entidadeCopiar.FaxRamal;
 toRet.Email= entidadeCopiar.Email;
 toRet.Cnpj= entidadeCopiar.Cnpj;
 toRet.Ie= entidadeCopiar.Ie;
 toRet.InscricaoMunicipal= entidadeCopiar.InscricaoMunicipal;
 toRet.InscricaoInss= entidadeCopiar.InscricaoInss;
 toRet.Pais= entidadeCopiar.Pais;
 toRet.EnderecoCob= entidadeCopiar.EnderecoCob;
 toRet.BairroCob= entidadeCopiar.BairroCob;
 toRet.CepCob= entidadeCopiar.CepCob;
 toRet.PaisCob= entidadeCopiar.PaisCob;
 toRet.Observacoes= entidadeCopiar.Observacoes;
 toRet.EnderecoNumeroCob= entidadeCopiar.EnderecoNumeroCob;
 toRet.ComplementoCob= entidadeCopiar.ComplementoCob;
 toRet.CodigoPaisCob= entidadeCopiar.CodigoPaisCob;
 toRet.CompradorCliente= entidadeCopiar.CompradorCliente;
 toRet.PermiteCustomizacaoProduto= entidadeCopiar.PermiteCustomizacaoProduto;
 toRet.Complemento= entidadeCopiar.Complemento;
 toRet.EstadoCob= entidadeCopiar.EstadoCob;
 toRet.EnderecoNumero= entidadeCopiar.EnderecoNumero;
 toRet.Estado= entidadeCopiar.Estado;
 toRet.FamiliaCliente= entidadeCopiar.FamiliaCliente;
 toRet.TipoDimensionamentoVolumetrico= entidadeCopiar.TipoDimensionamentoVolumetrico;
 toRet.UtilizarControlesCliente= entidadeCopiar.UtilizarControlesCliente;
 toRet.ResponsavelFrete= entidadeCopiar.ResponsavelFrete;
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;
 toRet.FormaPagamento= entidadeCopiar.FormaPagamento;
 toRet.Cidade= entidadeCopiar.Cidade;
 toRet.CidadeCob= entidadeCopiar.CidadeCob;
 toRet.ObservacaoPadraoNfe= entidadeCopiar.ObservacaoPadraoNfe;
 toRet.EnvioEmail= entidadeCopiar.EnvioEmail;
 toRet.EmailPedido= entidadeCopiar.EmailPedido;
 toRet.EmailOrcamento= entidadeCopiar.EmailOrcamento;
 toRet.Contato= entidadeCopiar.Contato;
 toRet.EmailDanfe= entidadeCopiar.EmailDanfe;
 toRet.EmailXml= entidadeCopiar.EmailXml;
 toRet.Representante= entidadeCopiar.Representante;
 toRet.Vendedor= entidadeCopiar.Vendedor;
 toRet.PercComissaoRepresentante= entidadeCopiar.PercComissaoRepresentante;
 toRet.PercComissaoVendedor= entidadeCopiar.PercComissaoVendedor;
 toRet.AvisoFaturamento= entidadeCopiar.AvisoFaturamento;
 toRet.IndicadorIe= entidadeCopiar.IndicadorIe;
 toRet.InscricaoSuframa= entidadeCopiar.InscricaoSuframa;
 toRet.TipoPagamento= entidadeCopiar.TipoPagamento;

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
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _nomeResumidoOriginal = NomeResumido;
       _nomeResumidoOriginalCommited = _nomeResumidoOriginal;
       _dataImplantacaoOriginal = DataImplantacao;
       _dataImplantacaoOriginalCommited = _dataImplantacaoOriginal;
       _enderecoOriginal = Endereco;
       _enderecoOriginalCommited = _enderecoOriginal;
       _bairroOriginal = Bairro;
       _bairroOriginalCommited = _bairroOriginal;
       _cepOriginal = Cep;
       _cepOriginalCommited = _cepOriginal;
       _fone1Original = Fone1;
       _fone1OriginalCommited = _fone1Original;
       _ramal1Original = Ramal1;
       _ramal1OriginalCommited = _ramal1Original;
       _fone2Original = Fone2;
       _fone2OriginalCommited = _fone2Original;
       _ramal2Original = Ramal2;
       _ramal2OriginalCommited = _ramal2Original;
       _faxOriginal = Fax;
       _faxOriginalCommited = _faxOriginal;
       _faxRamalOriginal = FaxRamal;
       _faxRamalOriginalCommited = _faxRamalOriginal;
       _emailOriginal = Email;
       _emailOriginalCommited = _emailOriginal;
       _cnpjOriginal = Cnpj;
       _cnpjOriginalCommited = _cnpjOriginal;
       _ieOriginal = Ie;
       _ieOriginalCommited = _ieOriginal;
       _inscricaoMunicipalOriginal = InscricaoMunicipal;
       _inscricaoMunicipalOriginalCommited = _inscricaoMunicipalOriginal;
       _inscricaoInssOriginal = InscricaoInss;
       _inscricaoInssOriginalCommited = _inscricaoInssOriginal;
       _paisOriginal = Pais;
       _paisOriginalCommited = _paisOriginal;
       _enderecoCobOriginal = EnderecoCob;
       _enderecoCobOriginalCommited = _enderecoCobOriginal;
       _bairroCobOriginal = BairroCob;
       _bairroCobOriginalCommited = _bairroCobOriginal;
       _cepCobOriginal = CepCob;
       _cepCobOriginalCommited = _cepCobOriginal;
       _paisCobOriginal = PaisCob;
       _paisCobOriginalCommited = _paisCobOriginal;
       _observacoesOriginal = Observacoes;
       _observacoesOriginalCommited = _observacoesOriginal;
       _enderecoNumeroCobOriginal = EnderecoNumeroCob;
       _enderecoNumeroCobOriginalCommited = _enderecoNumeroCobOriginal;
       _complementoCobOriginal = ComplementoCob;
       _complementoCobOriginalCommited = _complementoCobOriginal;
       _codigoPaisCobOriginal = CodigoPaisCob;
       _codigoPaisCobOriginalCommited = _codigoPaisCobOriginal;
       _compradorClienteOriginal = CompradorCliente;
       _compradorClienteOriginalCommited = _compradorClienteOriginal;
       _permiteCustomizacaoProdutoOriginal = PermiteCustomizacaoProduto;
       _permiteCustomizacaoProdutoOriginalCommited = _permiteCustomizacaoProdutoOriginal;
       _complementoOriginal = Complemento;
       _complementoOriginalCommited = _complementoOriginal;
       _estadoCobOriginal = EstadoCob;
       _estadoCobOriginalCommited = _estadoCobOriginal;
       _enderecoNumeroOriginal = EnderecoNumero;
       _enderecoNumeroOriginalCommited = _enderecoNumeroOriginal;
       _estadoOriginal = Estado;
       _estadoOriginalCommited = _estadoOriginal;
       _familiaClienteOriginal = FamiliaCliente;
       _familiaClienteOriginalCommited = _familiaClienteOriginal;
       _tipoDimensionamentoVolumetricoOriginal = TipoDimensionamentoVolumetrico;
       _tipoDimensionamentoVolumetricoOriginalCommited = _tipoDimensionamentoVolumetricoOriginal;
       _utilizarControlesClienteOriginal = UtilizarControlesCliente;
       _utilizarControlesClienteOriginalCommited = _utilizarControlesClienteOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _responsavelFreteOriginal = ResponsavelFrete;
       _responsavelFreteOriginalCommited = _responsavelFreteOriginal;
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;
       _formaPagamentoOriginal = FormaPagamento;
       _formaPagamentoOriginalCommited = _formaPagamentoOriginal;
       _cidadeOriginal = Cidade;
       _cidadeOriginalCommited = _cidadeOriginal;
       _cidadeCobOriginal = CidadeCob;
       _cidadeCobOriginalCommited = _cidadeCobOriginal;
       _observacaoPadraoNfeOriginal = ObservacaoPadraoNfe;
       _observacaoPadraoNfeOriginalCommited = _observacaoPadraoNfeOriginal;
       _envioEmailOriginal = EnvioEmail;
       _envioEmailOriginalCommited = _envioEmailOriginal;
       _emailPedidoOriginal = EmailPedido;
       _emailPedidoOriginalCommited = _emailPedidoOriginal;
       _emailOrcamentoOriginal = EmailOrcamento;
       _emailOrcamentoOriginalCommited = _emailOrcamentoOriginal;
       _contatoOriginal = Contato;
       _contatoOriginalCommited = _contatoOriginal;
       _emailDanfeOriginal = EmailDanfe;
       _emailDanfeOriginalCommited = _emailDanfeOriginal;
       _emailXmlOriginal = EmailXml;
       _emailXmlOriginalCommited = _emailXmlOriginal;
       _representanteOriginal = Representante;
       _representanteOriginalCommited = _representanteOriginal;
       _vendedorOriginal = Vendedor;
       _vendedorOriginalCommited = _vendedorOriginal;
       _percComissaoRepresentanteOriginal = PercComissaoRepresentante;
       _percComissaoRepresentanteOriginalCommited = _percComissaoRepresentanteOriginal;
       _percComissaoVendedorOriginal = PercComissaoVendedor;
       _percComissaoVendedorOriginalCommited = _percComissaoVendedorOriginal;
       _avisoFaturamentoOriginal = AvisoFaturamento;
       _avisoFaturamentoOriginalCommited = _avisoFaturamentoOriginal;
       _indicadorIeOriginal = IndicadorIe;
       _indicadorIeOriginalCommited = _indicadorIeOriginal;
       _inscricaoSuframaOriginal = InscricaoSuframa;
       _inscricaoSuframaOriginalCommited = _inscricaoSuframaOriginal;
       _tipoPagamentoOriginal = TipoPagamento;
       _tipoPagamentoOriginalCommited = _tipoPagamentoOriginal;

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
       _nomeOriginalCommited = Nome;
       _nomeResumidoOriginalCommited = NomeResumido;
       _dataImplantacaoOriginalCommited = DataImplantacao;
       _enderecoOriginalCommited = Endereco;
       _bairroOriginalCommited = Bairro;
       _cepOriginalCommited = Cep;
       _fone1OriginalCommited = Fone1;
       _ramal1OriginalCommited = Ramal1;
       _fone2OriginalCommited = Fone2;
       _ramal2OriginalCommited = Ramal2;
       _faxOriginalCommited = Fax;
       _faxRamalOriginalCommited = FaxRamal;
       _emailOriginalCommited = Email;
       _cnpjOriginalCommited = Cnpj;
       _ieOriginalCommited = Ie;
       _inscricaoMunicipalOriginalCommited = InscricaoMunicipal;
       _inscricaoInssOriginalCommited = InscricaoInss;
       _paisOriginalCommited = Pais;
       _enderecoCobOriginalCommited = EnderecoCob;
       _bairroCobOriginalCommited = BairroCob;
       _cepCobOriginalCommited = CepCob;
       _paisCobOriginalCommited = PaisCob;
       _observacoesOriginalCommited = Observacoes;
       _enderecoNumeroCobOriginalCommited = EnderecoNumeroCob;
       _complementoCobOriginalCommited = ComplementoCob;
       _codigoPaisCobOriginalCommited = CodigoPaisCob;
       _compradorClienteOriginalCommited = CompradorCliente;
       _permiteCustomizacaoProdutoOriginalCommited = PermiteCustomizacaoProduto;
       _complementoOriginalCommited = Complemento;
       _estadoCobOriginalCommited = EstadoCob;
       _enderecoNumeroOriginalCommited = EnderecoNumero;
       _estadoOriginalCommited = Estado;
       _familiaClienteOriginalCommited = FamiliaCliente;
       _tipoDimensionamentoVolumetricoOriginalCommited = TipoDimensionamentoVolumetrico;
       _utilizarControlesClienteOriginalCommited = UtilizarControlesCliente;
       _versionOriginalCommited = Version;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _responsavelFreteOriginalCommited = ResponsavelFrete;
       _contaBancariaOriginalCommited = ContaBancaria;
       _centroCustoLucroOriginalCommited = CentroCustoLucro;
       _formaPagamentoOriginalCommited = FormaPagamento;
       _cidadeOriginalCommited = Cidade;
       _cidadeCobOriginalCommited = CidadeCob;
       _observacaoPadraoNfeOriginalCommited = ObservacaoPadraoNfe;
       _envioEmailOriginalCommited = EnvioEmail;
       _emailPedidoOriginalCommited = EmailPedido;
       _emailOrcamentoOriginalCommited = EmailOrcamento;
       _contatoOriginalCommited = Contato;
       _emailDanfeOriginalCommited = EmailDanfe;
       _emailXmlOriginalCommited = EmailXml;
       _representanteOriginalCommited = Representante;
       _vendedorOriginalCommited = Vendedor;
       _percComissaoRepresentanteOriginalCommited = PercComissaoRepresentante;
       _percComissaoVendedorOriginalCommited = PercComissaoVendedor;
       _avisoFaturamentoOriginalCommited = AvisoFaturamento;
       _indicadorIeOriginalCommited = IndicadorIe;
       _inscricaoSuframaOriginalCommited = InscricaoSuframa;
       _tipoPagamentoOriginalCommited = TipoPagamento;

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
               if (_valueCollectionCliEassaIdentificaClienteClassClienteLoaded) 
               {
                  if (_collectionCliEassaIdentificaClienteClassClienteRemovidos != null) 
                  {
                     _collectionCliEassaIdentificaClienteClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCliEassaIdentificaClienteClassClienteRemovidos = new List<Entidades.CliEassaIdentificaClienteClass>();
                  }
                  _collectionCliEassaIdentificaClienteClassClienteOriginal= (from a in _valueCollectionCliEassaIdentificaClienteClassCliente select a.ID).ToList();
                  _valueCollectionCliEassaIdentificaClienteClassClienteChanged = false;
                  _valueCollectionCliEassaIdentificaClienteClassClienteCommitedChanged = false;
               }
               if (_valueCollectionClienteContatoClassClienteLoaded) 
               {
                  if (_collectionClienteContatoClassClienteRemovidos != null) 
                  {
                     _collectionClienteContatoClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteContatoClassClienteRemovidos = new List<Entidades.ClienteContatoClass>();
                  }
                  _collectionClienteContatoClassClienteOriginal= (from a in _valueCollectionClienteContatoClassCliente select a.ID).ToList();
                  _valueCollectionClienteContatoClassClienteChanged = false;
                  _valueCollectionClienteContatoClassClienteCommitedChanged = false;
               }
               if (_valueCollectionContaReceberClassClienteLoaded) 
               {
                  if (_collectionContaReceberClassClienteRemovidos != null) 
                  {
                     _collectionContaReceberClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberClassClienteRemovidos = new List<Entidades.ContaReceberClass>();
                  }
                  _collectionContaReceberClassClienteOriginal= (from a in _valueCollectionContaReceberClassCliente select a.ID).ToList();
                  _valueCollectionContaReceberClassClienteChanged = false;
                  _valueCollectionContaReceberClassClienteCommitedChanged = false;
               }
               if (_valueCollectionContaReceberBoletoClassClienteLoaded) 
               {
                  if (_collectionContaReceberBoletoClassClienteRemovidos != null) 
                  {
                     _collectionContaReceberBoletoClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberBoletoClassClienteRemovidos = new List<Entidades.ContaReceberBoletoClass>();
                  }
                  _collectionContaReceberBoletoClassClienteOriginal= (from a in _valueCollectionContaReceberBoletoClassCliente select a.ID).ToList();
                  _valueCollectionContaReceberBoletoClassClienteChanged = false;
                  _valueCollectionContaReceberBoletoClassClienteCommitedChanged = false;
               }
               if (_valueCollectionContaRecorrenteClassClienteLoaded) 
               {
                  if (_collectionContaRecorrenteClassClienteRemovidos != null) 
                  {
                     _collectionContaRecorrenteClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaRecorrenteClassClienteRemovidos = new List<Entidades.ContaRecorrenteClass>();
                  }
                  _collectionContaRecorrenteClassClienteOriginal= (from a in _valueCollectionContaRecorrenteClassCliente select a.ID).ToList();
                  _valueCollectionContaRecorrenteClassClienteChanged = false;
                  _valueCollectionContaRecorrenteClassClienteCommitedChanged = false;
               }
               if (_valueCollectionCredorDevedorClassClienteLoaded) 
               {
                  if (_collectionCredorDevedorClassClienteRemovidos != null) 
                  {
                     _collectionCredorDevedorClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCredorDevedorClassClienteRemovidos = new List<Entidades.CredorDevedorClass>();
                  }
                  _collectionCredorDevedorClassClienteOriginal= (from a in _valueCollectionCredorDevedorClassCliente select a.ID).ToList();
                  _valueCollectionCredorDevedorClassClienteChanged = false;
                  _valueCollectionCredorDevedorClassClienteCommitedChanged = false;
               }
               if (_valueCollectionLoteClassClienteLoaded) 
               {
                  if (_collectionLoteClassClienteRemovidos != null) 
                  {
                     _collectionLoteClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLoteClassClienteRemovidos = new List<Entidades.LoteClass>();
                  }
                  _collectionLoteClassClienteOriginal= (from a in _valueCollectionLoteClassCliente select a.ID).ToList();
                  _valueCollectionLoteClassClienteChanged = false;
                  _valueCollectionLoteClassClienteCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoConfiguradoClassClienteLoaded) 
               {
                  if (_collectionOrcamentoConfiguradoClassClienteRemovidos != null) 
                  {
                     _collectionOrcamentoConfiguradoClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoConfiguradoClassClienteRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                  }
                  _collectionOrcamentoConfiguradoClassClienteOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassCliente select a.ID).ToList();
                  _valueCollectionOrcamentoConfiguradoClassClienteChanged = false;
                  _valueCollectionOrcamentoConfiguradoClassClienteCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemClassClienteLoaded) 
               {
                  if (_collectionOrcamentoItemClassClienteRemovidos != null) 
                  {
                     _collectionOrcamentoItemClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemClassClienteRemovidos = new List<Entidades.OrcamentoItemClass>();
                  }
                  _collectionOrcamentoItemClassClienteOriginal= (from a in _valueCollectionOrcamentoItemClassCliente select a.ID).ToList();
                  _valueCollectionOrcamentoItemClassClienteChanged = false;
                  _valueCollectionOrcamentoItemClassClienteCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemVariavelClassClienteLoaded) 
               {
                  if (_collectionOrcamentoItemVariavelClassClienteRemovidos != null) 
                  {
                     _collectionOrcamentoItemVariavelClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemVariavelClassClienteRemovidos = new List<Entidades.OrcamentoItemVariavelClass>();
                  }
                  _collectionOrcamentoItemVariavelClassClienteOriginal= (from a in _valueCollectionOrcamentoItemVariavelClassCliente select a.ID).ToList();
                  _valueCollectionOrcamentoItemVariavelClassClienteChanged = false;
                  _valueCollectionOrcamentoItemVariavelClassClienteCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoKitClassClienteLoaded) 
               {
                  if (_collectionOrcamentoKitClassClienteRemovidos != null) 
                  {
                     _collectionOrcamentoKitClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoKitClassClienteRemovidos = new List<Entidades.OrcamentoKitClass>();
                  }
                  _collectionOrcamentoKitClassClienteOriginal= (from a in _valueCollectionOrcamentoKitClassCliente select a.ID).ToList();
                  _valueCollectionOrcamentoKitClassClienteChanged = false;
                  _valueCollectionOrcamentoKitClassClienteCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoVariavelClassClienteLoaded) 
               {
                  if (_collectionOrcamentoVariavelClassClienteRemovidos != null) 
                  {
                     _collectionOrcamentoVariavelClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoVariavelClassClienteRemovidos = new List<Entidades.OrcamentoVariavelClass>();
                  }
                  _collectionOrcamentoVariavelClassClienteOriginal= (from a in _valueCollectionOrcamentoVariavelClassCliente select a.ID).ToList();
                  _valueCollectionOrcamentoVariavelClassClienteChanged = false;
                  _valueCollectionOrcamentoVariavelClassClienteCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaClassClienteLoaded) 
               {
                  if (_collectionOrderItemEtiquetaClassClienteRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaClassClienteRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                  }
                  _collectionOrderItemEtiquetaClassClienteOriginal= (from a in _valueCollectionOrderItemEtiquetaClassCliente select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaClassClienteChanged = false;
                  _valueCollectionOrderItemEtiquetaClassClienteCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassClienteLoaded) 
               {
                  if (_collectionPedidoItemClassClienteRemovidos != null) 
                  {
                     _collectionPedidoItemClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassClienteRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassClienteOriginal= (from a in _valueCollectionPedidoItemClassCliente select a.ID).ToList();
                  _valueCollectionPedidoItemClassClienteChanged = false;
                  _valueCollectionPedidoItemClassClienteCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded) 
               {
                  if (_collectionPedidoItemClassClienteEnvioTerceirosRemovidos != null) 
                  {
                     _collectionPedidoItemClassClienteEnvioTerceirosRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassClienteEnvioTerceirosRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassClienteEnvioTerceirosOriginal= (from a in _valueCollectionPedidoItemClassClienteEnvioTerceiros select a.ID).ToList();
                  _valueCollectionPedidoItemClassClienteEnvioTerceirosChanged = false;
                  _valueCollectionPedidoItemClassClienteEnvioTerceirosCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemVariavelClassClienteLoaded) 
               {
                  if (_collectionPedidoItemVariavelClassClienteRemovidos != null) 
                  {
                     _collectionPedidoItemVariavelClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemVariavelClassClienteRemovidos = new List<Entidades.PedidoItemVariavelClass>();
                  }
                  _collectionPedidoItemVariavelClassClienteOriginal= (from a in _valueCollectionPedidoItemVariavelClassCliente select a.ID).ToList();
                  _valueCollectionPedidoItemVariavelClassClienteChanged = false;
                  _valueCollectionPedidoItemVariavelClassClienteCommitedChanged = false;
               }
               if (_valueCollectionPedidoKitClassClienteLoaded) 
               {
                  if (_collectionPedidoKitClassClienteRemovidos != null) 
                  {
                     _collectionPedidoKitClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoKitClassClienteRemovidos = new List<Entidades.PedidoKitClass>();
                  }
                  _collectionPedidoKitClassClienteOriginal= (from a in _valueCollectionPedidoKitClassCliente select a.ID).ToList();
                  _valueCollectionPedidoKitClassClienteChanged = false;
                  _valueCollectionPedidoKitClassClienteCommitedChanged = false;
               }
               if (_valueCollectionPedidoVariavelClassClienteLoaded) 
               {
                  if (_collectionPedidoVariavelClassClienteRemovidos != null) 
                  {
                     _collectionPedidoVariavelClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoVariavelClassClienteRemovidos = new List<Entidades.PedidoVariavelClass>();
                  }
                  _collectionPedidoVariavelClassClienteOriginal= (from a in _valueCollectionPedidoVariavelClassCliente select a.ID).ToList();
                  _valueCollectionPedidoVariavelClassClienteChanged = false;
                  _valueCollectionPedidoVariavelClassClienteCommitedChanged = false;
               }
               if (_valueCollectionProdutoClassClienteLoaded) 
               {
                  if (_collectionProdutoClassClienteRemovidos != null) 
                  {
                     _collectionProdutoClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassClienteRemovidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassClienteOriginal= (from a in _valueCollectionProdutoClassCliente select a.ID).ToList();
                  _valueCollectionProdutoClassClienteChanged = false;
                  _valueCollectionProdutoClassClienteCommitedChanged = false;
               }
               if (_valueCollectionTabelaPrecoItemVariavelClassClienteLoaded) 
               {
                  if (_collectionTabelaPrecoItemVariavelClassClienteRemovidos != null) 
                  {
                     _collectionTabelaPrecoItemVariavelClassClienteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionTabelaPrecoItemVariavelClassClienteRemovidos = new List<Entidades.TabelaPrecoItemVariavelClass>();
                  }
                  _collectionTabelaPrecoItemVariavelClassClienteOriginal= (from a in _valueCollectionTabelaPrecoItemVariavelClassCliente select a.ID).ToList();
                  _valueCollectionTabelaPrecoItemVariavelClassClienteChanged = false;
                  _valueCollectionTabelaPrecoItemVariavelClassClienteCommitedChanged = false;
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
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               NomeResumido=_nomeResumidoOriginal;
               _nomeResumidoOriginalCommited=_nomeResumidoOriginal;
               DataImplantacao=_dataImplantacaoOriginal;
               _dataImplantacaoOriginalCommited=_dataImplantacaoOriginal;
               Endereco=_enderecoOriginal;
               _enderecoOriginalCommited=_enderecoOriginal;
               Bairro=_bairroOriginal;
               _bairroOriginalCommited=_bairroOriginal;
               Cep=_cepOriginal;
               _cepOriginalCommited=_cepOriginal;
               Fone1=_fone1Original;
               _fone1OriginalCommited=_fone1Original;
               Ramal1=_ramal1Original;
               _ramal1OriginalCommited=_ramal1Original;
               Fone2=_fone2Original;
               _fone2OriginalCommited=_fone2Original;
               Ramal2=_ramal2Original;
               _ramal2OriginalCommited=_ramal2Original;
               Fax=_faxOriginal;
               _faxOriginalCommited=_faxOriginal;
               FaxRamal=_faxRamalOriginal;
               _faxRamalOriginalCommited=_faxRamalOriginal;
               Email=_emailOriginal;
               _emailOriginalCommited=_emailOriginal;
               Cnpj=_cnpjOriginal;
               _cnpjOriginalCommited=_cnpjOriginal;
               Ie=_ieOriginal;
               _ieOriginalCommited=_ieOriginal;
               InscricaoMunicipal=_inscricaoMunicipalOriginal;
               _inscricaoMunicipalOriginalCommited=_inscricaoMunicipalOriginal;
               InscricaoInss=_inscricaoInssOriginal;
               _inscricaoInssOriginalCommited=_inscricaoInssOriginal;
               Pais=_paisOriginal;
               _paisOriginalCommited=_paisOriginal;
               EnderecoCob=_enderecoCobOriginal;
               _enderecoCobOriginalCommited=_enderecoCobOriginal;
               BairroCob=_bairroCobOriginal;
               _bairroCobOriginalCommited=_bairroCobOriginal;
               CepCob=_cepCobOriginal;
               _cepCobOriginalCommited=_cepCobOriginal;
               PaisCob=_paisCobOriginal;
               _paisCobOriginalCommited=_paisCobOriginal;
               Observacoes=_observacoesOriginal;
               _observacoesOriginalCommited=_observacoesOriginal;
               EnderecoNumeroCob=_enderecoNumeroCobOriginal;
               _enderecoNumeroCobOriginalCommited=_enderecoNumeroCobOriginal;
               ComplementoCob=_complementoCobOriginal;
               _complementoCobOriginalCommited=_complementoCobOriginal;
               CodigoPaisCob=_codigoPaisCobOriginal;
               _codigoPaisCobOriginalCommited=_codigoPaisCobOriginal;
               CompradorCliente=_compradorClienteOriginal;
               _compradorClienteOriginalCommited=_compradorClienteOriginal;
               PermiteCustomizacaoProduto=_permiteCustomizacaoProdutoOriginal;
               _permiteCustomizacaoProdutoOriginalCommited=_permiteCustomizacaoProdutoOriginal;
               Complemento=_complementoOriginal;
               _complementoOriginalCommited=_complementoOriginal;
               EstadoCob=_estadoCobOriginal;
               _estadoCobOriginalCommited=_estadoCobOriginal;
               EnderecoNumero=_enderecoNumeroOriginal;
               _enderecoNumeroOriginalCommited=_enderecoNumeroOriginal;
               Estado=_estadoOriginal;
               _estadoOriginalCommited=_estadoOriginal;
               FamiliaCliente=_familiaClienteOriginal;
               _familiaClienteOriginalCommited=_familiaClienteOriginal;
               TipoDimensionamentoVolumetrico=_tipoDimensionamentoVolumetricoOriginal;
               _tipoDimensionamentoVolumetricoOriginalCommited=_tipoDimensionamentoVolumetricoOriginal;
               UtilizarControlesCliente=_utilizarControlesClienteOriginal;
               _utilizarControlesClienteOriginalCommited=_utilizarControlesClienteOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               ResponsavelFrete=_responsavelFreteOriginal;
               _responsavelFreteOriginalCommited=_responsavelFreteOriginal;
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;
               FormaPagamento=_formaPagamentoOriginal;
               _formaPagamentoOriginalCommited=_formaPagamentoOriginal;
               Cidade=_cidadeOriginal;
               _cidadeOriginalCommited=_cidadeOriginal;
               CidadeCob=_cidadeCobOriginal;
               _cidadeCobOriginalCommited=_cidadeCobOriginal;
               ObservacaoPadraoNfe=_observacaoPadraoNfeOriginal;
               _observacaoPadraoNfeOriginalCommited=_observacaoPadraoNfeOriginal;
               EnvioEmail=_envioEmailOriginal;
               _envioEmailOriginalCommited=_envioEmailOriginal;
               EmailPedido=_emailPedidoOriginal;
               _emailPedidoOriginalCommited=_emailPedidoOriginal;
               EmailOrcamento=_emailOrcamentoOriginal;
               _emailOrcamentoOriginalCommited=_emailOrcamentoOriginal;
               Contato=_contatoOriginal;
               _contatoOriginalCommited=_contatoOriginal;
               EmailDanfe=_emailDanfeOriginal;
               _emailDanfeOriginalCommited=_emailDanfeOriginal;
               EmailXml=_emailXmlOriginal;
               _emailXmlOriginalCommited=_emailXmlOriginal;
               Representante=_representanteOriginal;
               _representanteOriginalCommited=_representanteOriginal;
               Vendedor=_vendedorOriginal;
               _vendedorOriginalCommited=_vendedorOriginal;
               PercComissaoRepresentante=_percComissaoRepresentanteOriginal;
               _percComissaoRepresentanteOriginalCommited=_percComissaoRepresentanteOriginal;
               PercComissaoVendedor=_percComissaoVendedorOriginal;
               _percComissaoVendedorOriginalCommited=_percComissaoVendedorOriginal;
               AvisoFaturamento=_avisoFaturamentoOriginal;
               _avisoFaturamentoOriginalCommited=_avisoFaturamentoOriginal;
               IndicadorIe=_indicadorIeOriginal;
               _indicadorIeOriginalCommited=_indicadorIeOriginal;
               InscricaoSuframa=_inscricaoSuframaOriginal;
               _inscricaoSuframaOriginalCommited=_inscricaoSuframaOriginal;
               TipoPagamento=_tipoPagamentoOriginal;
               _tipoPagamentoOriginalCommited=_tipoPagamentoOriginal;
               if (_valueCollectionCliEassaIdentificaClienteClassClienteLoaded) 
               {
                  CollectionCliEassaIdentificaClienteClassCliente.Clear();
                  foreach(int item in _collectionCliEassaIdentificaClienteClassClienteOriginal)
                  {
                    CollectionCliEassaIdentificaClienteClassCliente.Add(Entidades.CliEassaIdentificaClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCliEassaIdentificaClienteClassClienteRemovidos.Clear();
               }
               if (_valueCollectionClienteContatoClassClienteLoaded) 
               {
                  CollectionClienteContatoClassCliente.Clear();
                  foreach(int item in _collectionClienteContatoClassClienteOriginal)
                  {
                    CollectionClienteContatoClassCliente.Add(Entidades.ClienteContatoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteContatoClassClienteRemovidos.Clear();
               }
               if (_valueCollectionContaReceberClassClienteLoaded) 
               {
                  CollectionContaReceberClassCliente.Clear();
                  foreach(int item in _collectionContaReceberClassClienteOriginal)
                  {
                    CollectionContaReceberClassCliente.Add(Entidades.ContaReceberClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberClassClienteRemovidos.Clear();
               }
               if (_valueCollectionContaReceberBoletoClassClienteLoaded) 
               {
                  CollectionContaReceberBoletoClassCliente.Clear();
                  foreach(int item in _collectionContaReceberBoletoClassClienteOriginal)
                  {
                    CollectionContaReceberBoletoClassCliente.Add(Entidades.ContaReceberBoletoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberBoletoClassClienteRemovidos.Clear();
               }
               if (_valueCollectionContaRecorrenteClassClienteLoaded) 
               {
                  CollectionContaRecorrenteClassCliente.Clear();
                  foreach(int item in _collectionContaRecorrenteClassClienteOriginal)
                  {
                    CollectionContaRecorrenteClassCliente.Add(Entidades.ContaRecorrenteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaRecorrenteClassClienteRemovidos.Clear();
               }
               if (_valueCollectionCredorDevedorClassClienteLoaded) 
               {
                  CollectionCredorDevedorClassCliente.Clear();
                  foreach(int item in _collectionCredorDevedorClassClienteOriginal)
                  {
                    CollectionCredorDevedorClassCliente.Add(Entidades.CredorDevedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCredorDevedorClassClienteRemovidos.Clear();
               }
               if (_valueCollectionLoteClassClienteLoaded) 
               {
                  CollectionLoteClassCliente.Clear();
                  foreach(int item in _collectionLoteClassClienteOriginal)
                  {
                    CollectionLoteClassCliente.Add(Entidades.LoteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLoteClassClienteRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoConfiguradoClassClienteLoaded) 
               {
                  CollectionOrcamentoConfiguradoClassCliente.Clear();
                  foreach(int item in _collectionOrcamentoConfiguradoClassClienteOriginal)
                  {
                    CollectionOrcamentoConfiguradoClassCliente.Add(Entidades.OrcamentoConfiguradoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoConfiguradoClassClienteRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemClassClienteLoaded) 
               {
                  CollectionOrcamentoItemClassCliente.Clear();
                  foreach(int item in _collectionOrcamentoItemClassClienteOriginal)
                  {
                    CollectionOrcamentoItemClassCliente.Add(Entidades.OrcamentoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemClassClienteRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemVariavelClassClienteLoaded) 
               {
                  CollectionOrcamentoItemVariavelClassCliente.Clear();
                  foreach(int item in _collectionOrcamentoItemVariavelClassClienteOriginal)
                  {
                    CollectionOrcamentoItemVariavelClassCliente.Add(Entidades.OrcamentoItemVariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemVariavelClassClienteRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoKitClassClienteLoaded) 
               {
                  CollectionOrcamentoKitClassCliente.Clear();
                  foreach(int item in _collectionOrcamentoKitClassClienteOriginal)
                  {
                    CollectionOrcamentoKitClassCliente.Add(Entidades.OrcamentoKitClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoKitClassClienteRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoVariavelClassClienteLoaded) 
               {
                  CollectionOrcamentoVariavelClassCliente.Clear();
                  foreach(int item in _collectionOrcamentoVariavelClassClienteOriginal)
                  {
                    CollectionOrcamentoVariavelClassCliente.Add(Entidades.OrcamentoVariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoVariavelClassClienteRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaClassClienteLoaded) 
               {
                  CollectionOrderItemEtiquetaClassCliente.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaClassClienteOriginal)
                  {
                    CollectionOrderItemEtiquetaClassCliente.Add(Entidades.OrderItemEtiquetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaClassClienteRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassClienteLoaded) 
               {
                  CollectionPedidoItemClassCliente.Clear();
                  foreach(int item in _collectionPedidoItemClassClienteOriginal)
                  {
                    CollectionPedidoItemClassCliente.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassClienteRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded) 
               {
                  CollectionPedidoItemClassClienteEnvioTerceiros.Clear();
                  foreach(int item in _collectionPedidoItemClassClienteEnvioTerceirosOriginal)
                  {
                    CollectionPedidoItemClassClienteEnvioTerceiros.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassClienteEnvioTerceirosRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemVariavelClassClienteLoaded) 
               {
                  CollectionPedidoItemVariavelClassCliente.Clear();
                  foreach(int item in _collectionPedidoItemVariavelClassClienteOriginal)
                  {
                    CollectionPedidoItemVariavelClassCliente.Add(Entidades.PedidoItemVariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemVariavelClassClienteRemovidos.Clear();
               }
               if (_valueCollectionPedidoKitClassClienteLoaded) 
               {
                  CollectionPedidoKitClassCliente.Clear();
                  foreach(int item in _collectionPedidoKitClassClienteOriginal)
                  {
                    CollectionPedidoKitClassCliente.Add(Entidades.PedidoKitClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoKitClassClienteRemovidos.Clear();
               }
               if (_valueCollectionPedidoVariavelClassClienteLoaded) 
               {
                  CollectionPedidoVariavelClassCliente.Clear();
                  foreach(int item in _collectionPedidoVariavelClassClienteOriginal)
                  {
                    CollectionPedidoVariavelClassCliente.Add(Entidades.PedidoVariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoVariavelClassClienteRemovidos.Clear();
               }
               if (_valueCollectionProdutoClassClienteLoaded) 
               {
                  CollectionProdutoClassCliente.Clear();
                  foreach(int item in _collectionProdutoClassClienteOriginal)
                  {
                    CollectionProdutoClassCliente.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassClienteRemovidos.Clear();
               }
               if (_valueCollectionTabelaPrecoItemVariavelClassClienteLoaded) 
               {
                  CollectionTabelaPrecoItemVariavelClassCliente.Clear();
                  foreach(int item in _collectionTabelaPrecoItemVariavelClassClienteOriginal)
                  {
                    CollectionTabelaPrecoItemVariavelClassCliente.Add(Entidades.TabelaPrecoItemVariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionTabelaPrecoItemVariavelClassClienteRemovidos.Clear();
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
               if (_valueCollectionCliEassaIdentificaClienteClassClienteLoaded) 
               {
                  if (_valueCollectionCliEassaIdentificaClienteClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteContatoClassClienteLoaded) 
               {
                  if (_valueCollectionClienteContatoClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassClienteLoaded) 
               {
                  if (_valueCollectionContaReceberClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberBoletoClassClienteLoaded) 
               {
                  if (_valueCollectionContaReceberBoletoClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassClienteLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCredorDevedorClassClienteLoaded) 
               {
                  if (_valueCollectionCredorDevedorClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassClienteLoaded) 
               {
                  if (_valueCollectionLoteClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoItemVariavelClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoKitClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoKitClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoVariavelClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassClienteLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassClienteLoaded) 
               {
                  if (_valueCollectionPedidoItemClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionPedidoItemClassClienteEnvioTerceirosChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionPedidoItemVariavelClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoKitClassClienteLoaded) 
               {
                  if (_valueCollectionPedidoKitClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionPedidoVariavelClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassClienteLoaded) 
               {
                  if (_valueCollectionProdutoClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTabelaPrecoItemVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionTabelaPrecoItemVariavelClassClienteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCliEassaIdentificaClienteClassClienteLoaded) 
               {
                   tempRet = CollectionCliEassaIdentificaClienteClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteContatoClassClienteLoaded) 
               {
                   tempRet = CollectionClienteContatoClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassClienteLoaded) 
               {
                   tempRet = CollectionContaReceberClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberBoletoClassClienteLoaded) 
               {
                   tempRet = CollectionContaReceberBoletoClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassClienteLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionCredorDevedorClassClienteLoaded) 
               {
                   tempRet = CollectionCredorDevedorClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassClienteLoaded) 
               {
                   tempRet = CollectionLoteClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoConfiguradoClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoItemVariavelClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoKitClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoKitClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoVariavelClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassClienteLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassClienteLoaded) 
               {
                   tempRet = CollectionPedidoItemClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionPedidoItemClassClienteEnvioTerceiros.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionPedidoItemVariavelClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoKitClassClienteLoaded) 
               {
                   tempRet = CollectionPedidoKitClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionPedidoVariavelClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassClienteLoaded) 
               {
                   tempRet = CollectionProdutoClassCliente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionTabelaPrecoItemVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionTabelaPrecoItemVariavelClassCliente.Any(item => item.IsDirty());
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
       dirty = _nomeOriginal != Nome;
      if (dirty) return true;
       dirty = _nomeResumidoOriginal != NomeResumido;
      if (dirty) return true;
       dirty = _dataImplantacaoOriginal != DataImplantacao;
      if (dirty) return true;
       dirty = _enderecoOriginal != Endereco;
      if (dirty) return true;
       dirty = _bairroOriginal != Bairro;
      if (dirty) return true;
       dirty = _cepOriginal != Cep;
      if (dirty) return true;
       dirty = _fone1Original != Fone1;
      if (dirty) return true;
       dirty = _ramal1Original != Ramal1;
      if (dirty) return true;
       dirty = _fone2Original != Fone2;
      if (dirty) return true;
       dirty = _ramal2Original != Ramal2;
      if (dirty) return true;
       dirty = _faxOriginal != Fax;
      if (dirty) return true;
       dirty = _faxRamalOriginal != FaxRamal;
      if (dirty) return true;
       dirty = _emailOriginal != Email;
      if (dirty) return true;
       dirty = _cnpjOriginal != Cnpj;
      if (dirty) return true;
       dirty = _ieOriginal != Ie;
      if (dirty) return true;
       dirty = _inscricaoMunicipalOriginal != InscricaoMunicipal;
      if (dirty) return true;
       dirty = _inscricaoInssOriginal != InscricaoInss;
      if (dirty) return true;
       dirty = _paisOriginal != Pais;
      if (dirty) return true;
       dirty = _enderecoCobOriginal != EnderecoCob;
      if (dirty) return true;
       dirty = _bairroCobOriginal != BairroCob;
      if (dirty) return true;
       dirty = _cepCobOriginal != CepCob;
      if (dirty) return true;
       dirty = _paisCobOriginal != PaisCob;
      if (dirty) return true;
       dirty = _observacoesOriginal != Observacoes;
      if (dirty) return true;
       dirty = _enderecoNumeroCobOriginal != EnderecoNumeroCob;
      if (dirty) return true;
       dirty = _complementoCobOriginal != ComplementoCob;
      if (dirty) return true;
       dirty = _codigoPaisCobOriginal != CodigoPaisCob;
      if (dirty) return true;
       dirty = _compradorClienteOriginal != CompradorCliente;
      if (dirty) return true;
       dirty = _permiteCustomizacaoProdutoOriginal != PermiteCustomizacaoProduto;
      if (dirty) return true;
       dirty = _complementoOriginal != Complemento;
      if (dirty) return true;
       if (_estadoCobOriginal!=null)
       {
          dirty = !_estadoCobOriginal.Equals(EstadoCob);
       }
       else
       {
            dirty = EstadoCob != null;
       }
      if (dirty) return true;
       dirty = _enderecoNumeroOriginal != EnderecoNumero;
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
       if (_familiaClienteOriginal!=null)
       {
          dirty = !_familiaClienteOriginal.Equals(FamiliaCliente);
       }
       else
       {
            dirty = FamiliaCliente != null;
       }
      if (dirty) return true;
       dirty = _tipoDimensionamentoVolumetricoOriginal != TipoDimensionamentoVolumetrico;
      if (dirty) return true;
       dirty = _utilizarControlesClienteOriginal != UtilizarControlesCliente;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
       dirty = _responsavelFreteOriginal != ResponsavelFrete;
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
       if (_cidadeOriginal!=null)
       {
          dirty = !_cidadeOriginal.Equals(Cidade);
       }
       else
       {
            dirty = Cidade != null;
       }
      if (dirty) return true;
       if (_cidadeCobOriginal!=null)
       {
          dirty = !_cidadeCobOriginal.Equals(CidadeCob);
       }
       else
       {
            dirty = CidadeCob != null;
       }
      if (dirty) return true;
       dirty = _observacaoPadraoNfeOriginal != ObservacaoPadraoNfe;
      if (dirty) return true;
       dirty = _envioEmailOriginal != EnvioEmail;
      if (dirty) return true;
       dirty = _emailPedidoOriginal != EmailPedido;
      if (dirty) return true;
       dirty = _emailOrcamentoOriginal != EmailOrcamento;
      if (dirty) return true;
       dirty = _contatoOriginal != Contato;
      if (dirty) return true;
       dirty = _emailDanfeOriginal != EmailDanfe;
      if (dirty) return true;
       dirty = _emailXmlOriginal != EmailXml;
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
       if (_vendedorOriginal!=null)
       {
          dirty = !_vendedorOriginal.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       dirty = _percComissaoRepresentanteOriginal != PercComissaoRepresentante;
      if (dirty) return true;
       dirty = _percComissaoVendedorOriginal != PercComissaoVendedor;
      if (dirty) return true;
       dirty = _avisoFaturamentoOriginal != AvisoFaturamento;
      if (dirty) return true;
       dirty = _indicadorIeOriginal != IndicadorIe;
      if (dirty) return true;
       dirty = _inscricaoSuframaOriginal != InscricaoSuframa;
      if (dirty) return true;
       if (_tipoPagamentoOriginal!=null)
       {
          dirty = !_tipoPagamentoOriginal.Equals(TipoPagamento);
       }
       else
       {
            dirty = TipoPagamento != null;
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
               if (_valueCollectionCliEassaIdentificaClienteClassClienteLoaded) 
               {
                  if (_valueCollectionCliEassaIdentificaClienteClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteContatoClassClienteLoaded) 
               {
                  if (_valueCollectionClienteContatoClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassClienteLoaded) 
               {
                  if (_valueCollectionContaReceberClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberBoletoClassClienteLoaded) 
               {
                  if (_valueCollectionContaReceberBoletoClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassClienteLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCredorDevedorClassClienteLoaded) 
               {
                  if (_valueCollectionCredorDevedorClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteClassClienteLoaded) 
               {
                  if (_valueCollectionLoteClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoItemVariavelClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoKitClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoKitClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionOrcamentoVariavelClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassClienteLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassClienteLoaded) 
               {
                  if (_valueCollectionPedidoItemClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionPedidoItemClassClienteEnvioTerceirosCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionPedidoItemVariavelClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoKitClassClienteLoaded) 
               {
                  if (_valueCollectionPedidoKitClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionPedidoVariavelClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassClienteLoaded) 
               {
                  if (_valueCollectionProdutoClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTabelaPrecoItemVariavelClassClienteLoaded) 
               {
                  if (_valueCollectionTabelaPrecoItemVariavelClassClienteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCliEassaIdentificaClienteClassClienteLoaded) 
               {
                   tempRet = CollectionCliEassaIdentificaClienteClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteContatoClassClienteLoaded) 
               {
                   tempRet = CollectionClienteContatoClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassClienteLoaded) 
               {
                   tempRet = CollectionContaReceberClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberBoletoClassClienteLoaded) 
               {
                   tempRet = CollectionContaReceberBoletoClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassClienteLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionCredorDevedorClassClienteLoaded) 
               {
                   tempRet = CollectionCredorDevedorClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteClassClienteLoaded) 
               {
                   tempRet = CollectionLoteClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoConfiguradoClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoItemVariavelClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoKitClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoKitClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionOrcamentoVariavelClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassClienteLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassClienteLoaded) 
               {
                   tempRet = CollectionPedidoItemClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionPedidoItemClassClienteEnvioTerceiros.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionPedidoItemVariavelClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoKitClassClienteLoaded) 
               {
                   tempRet = CollectionPedidoKitClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionPedidoVariavelClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassClienteLoaded) 
               {
                   tempRet = CollectionProdutoClassCliente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionTabelaPrecoItemVariavelClassClienteLoaded) 
               {
                   tempRet = CollectionTabelaPrecoItemVariavelClassCliente.Any(item => item.IsDirtyCommited());
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
       dirty = _nomeOriginalCommited != Nome;
      if (dirty) return true;
       dirty = _nomeResumidoOriginalCommited != NomeResumido;
      if (dirty) return true;
       dirty = _dataImplantacaoOriginalCommited != DataImplantacao;
      if (dirty) return true;
       dirty = _enderecoOriginalCommited != Endereco;
      if (dirty) return true;
       dirty = _bairroOriginalCommited != Bairro;
      if (dirty) return true;
       dirty = _cepOriginalCommited != Cep;
      if (dirty) return true;
       dirty = _fone1OriginalCommited != Fone1;
      if (dirty) return true;
       dirty = _ramal1OriginalCommited != Ramal1;
      if (dirty) return true;
       dirty = _fone2OriginalCommited != Fone2;
      if (dirty) return true;
       dirty = _ramal2OriginalCommited != Ramal2;
      if (dirty) return true;
       dirty = _faxOriginalCommited != Fax;
      if (dirty) return true;
       dirty = _faxRamalOriginalCommited != FaxRamal;
      if (dirty) return true;
       dirty = _emailOriginalCommited != Email;
      if (dirty) return true;
       dirty = _cnpjOriginalCommited != Cnpj;
      if (dirty) return true;
       dirty = _ieOriginalCommited != Ie;
      if (dirty) return true;
       dirty = _inscricaoMunicipalOriginalCommited != InscricaoMunicipal;
      if (dirty) return true;
       dirty = _inscricaoInssOriginalCommited != InscricaoInss;
      if (dirty) return true;
       dirty = _paisOriginalCommited != Pais;
      if (dirty) return true;
       dirty = _enderecoCobOriginalCommited != EnderecoCob;
      if (dirty) return true;
       dirty = _bairroCobOriginalCommited != BairroCob;
      if (dirty) return true;
       dirty = _cepCobOriginalCommited != CepCob;
      if (dirty) return true;
       dirty = _paisCobOriginalCommited != PaisCob;
      if (dirty) return true;
       dirty = _observacoesOriginalCommited != Observacoes;
      if (dirty) return true;
       dirty = _enderecoNumeroCobOriginalCommited != EnderecoNumeroCob;
      if (dirty) return true;
       dirty = _complementoCobOriginalCommited != ComplementoCob;
      if (dirty) return true;
       dirty = _codigoPaisCobOriginalCommited != CodigoPaisCob;
      if (dirty) return true;
       dirty = _compradorClienteOriginalCommited != CompradorCliente;
      if (dirty) return true;
       dirty = _permiteCustomizacaoProdutoOriginalCommited != PermiteCustomizacaoProduto;
      if (dirty) return true;
       dirty = _complementoOriginalCommited != Complemento;
      if (dirty) return true;
       if (_estadoCobOriginalCommited!=null)
       {
          dirty = !_estadoCobOriginalCommited.Equals(EstadoCob);
       }
       else
       {
            dirty = EstadoCob != null;
       }
      if (dirty) return true;
       dirty = _enderecoNumeroOriginalCommited != EnderecoNumero;
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
       if (_familiaClienteOriginalCommited!=null)
       {
          dirty = !_familiaClienteOriginalCommited.Equals(FamiliaCliente);
       }
       else
       {
            dirty = FamiliaCliente != null;
       }
      if (dirty) return true;
       dirty = _tipoDimensionamentoVolumetricoOriginalCommited != TipoDimensionamentoVolumetrico;
      if (dirty) return true;
       dirty = _utilizarControlesClienteOriginalCommited != UtilizarControlesCliente;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
       dirty = _responsavelFreteOriginalCommited != ResponsavelFrete;
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
       if (_cidadeOriginalCommited!=null)
       {
          dirty = !_cidadeOriginalCommited.Equals(Cidade);
       }
       else
       {
            dirty = Cidade != null;
       }
      if (dirty) return true;
       if (_cidadeCobOriginalCommited!=null)
       {
          dirty = !_cidadeCobOriginalCommited.Equals(CidadeCob);
       }
       else
       {
            dirty = CidadeCob != null;
       }
      if (dirty) return true;
       dirty = _observacaoPadraoNfeOriginalCommited != ObservacaoPadraoNfe;
      if (dirty) return true;
       dirty = _envioEmailOriginalCommited != EnvioEmail;
      if (dirty) return true;
       dirty = _emailPedidoOriginalCommited != EmailPedido;
      if (dirty) return true;
       dirty = _emailOrcamentoOriginalCommited != EmailOrcamento;
      if (dirty) return true;
       dirty = _contatoOriginalCommited != Contato;
      if (dirty) return true;
       dirty = _emailDanfeOriginalCommited != EmailDanfe;
      if (dirty) return true;
       dirty = _emailXmlOriginalCommited != EmailXml;
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
       if (_vendedorOriginalCommited!=null)
       {
          dirty = !_vendedorOriginalCommited.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       dirty = _percComissaoRepresentanteOriginalCommited != PercComissaoRepresentante;
      if (dirty) return true;
       dirty = _percComissaoVendedorOriginalCommited != PercComissaoVendedor;
      if (dirty) return true;
       dirty = _avisoFaturamentoOriginalCommited != AvisoFaturamento;
      if (dirty) return true;
       dirty = _indicadorIeOriginalCommited != IndicadorIe;
      if (dirty) return true;
       dirty = _inscricaoSuframaOriginalCommited != InscricaoSuframa;
      if (dirty) return true;
       if (_tipoPagamentoOriginalCommited!=null)
       {
          dirty = !_tipoPagamentoOriginalCommited.Equals(TipoPagamento);
       }
       else
       {
            dirty = TipoPagamento != null;
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
               if (_valueCollectionCliEassaIdentificaClienteClassClienteLoaded) 
               {
                  foreach(CliEassaIdentificaClienteClass item in CollectionCliEassaIdentificaClienteClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionClienteContatoClassClienteLoaded) 
               {
                  foreach(ClienteContatoClass item in CollectionClienteContatoClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberClassClienteLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberBoletoClassClienteLoaded) 
               {
                  foreach(ContaReceberBoletoClass item in CollectionContaReceberBoletoClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaRecorrenteClassClienteLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionCredorDevedorClassClienteLoaded) 
               {
                  foreach(CredorDevedorClass item in CollectionCredorDevedorClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionLoteClassClienteLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassClienteLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemClassClienteLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemVariavelClassClienteLoaded) 
               {
                  foreach(OrcamentoItemVariavelClass item in CollectionOrcamentoItemVariavelClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoKitClassClienteLoaded) 
               {
                  foreach(OrcamentoKitClass item in CollectionOrcamentoKitClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoVariavelClassClienteLoaded) 
               {
                  foreach(OrcamentoVariavelClass item in CollectionOrcamentoVariavelClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassClienteLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassClienteLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassClienteEnvioTerceiros)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemVariavelClassClienteLoaded) 
               {
                  foreach(PedidoItemVariavelClass item in CollectionPedidoItemVariavelClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoKitClassClienteLoaded) 
               {
                  foreach(PedidoKitClass item in CollectionPedidoKitClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoVariavelClassClienteLoaded) 
               {
                  foreach(PedidoVariavelClass item in CollectionPedidoVariavelClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassClienteLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassCliente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionTabelaPrecoItemVariavelClassClienteLoaded) 
               {
                  foreach(TabelaPrecoItemVariavelClass item in CollectionTabelaPrecoItemVariavelClassCliente)
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
             case "Nome":
                return this.Nome;
             case "NomeResumido":
                return this.NomeResumido;
             case "DataImplantacao":
                return this.DataImplantacao;
             case "Endereco":
                return this.Endereco;
             case "Bairro":
                return this.Bairro;
             case "Cep":
                return this.Cep;
             case "Fone1":
                return this.Fone1;
             case "Ramal1":
                return this.Ramal1;
             case "Fone2":
                return this.Fone2;
             case "Ramal2":
                return this.Ramal2;
             case "Fax":
                return this.Fax;
             case "FaxRamal":
                return this.FaxRamal;
             case "Email":
                return this.Email;
             case "Cnpj":
                return this.Cnpj;
             case "Ie":
                return this.Ie;
             case "InscricaoMunicipal":
                return this.InscricaoMunicipal;
             case "InscricaoInss":
                return this.InscricaoInss;
             case "Pais":
                return this.Pais;
             case "EnderecoCob":
                return this.EnderecoCob;
             case "BairroCob":
                return this.BairroCob;
             case "CepCob":
                return this.CepCob;
             case "PaisCob":
                return this.PaisCob;
             case "Observacoes":
                return this.Observacoes;
             case "EnderecoNumeroCob":
                return this.EnderecoNumeroCob;
             case "ComplementoCob":
                return this.ComplementoCob;
             case "CodigoPaisCob":
                return this.CodigoPaisCob;
             case "CompradorCliente":
                return this.CompradorCliente;
             case "PermiteCustomizacaoProduto":
                return this.PermiteCustomizacaoProduto;
             case "Complemento":
                return this.Complemento;
             case "EstadoCob":
                return this.EstadoCob;
             case "EnderecoNumero":
                return this.EnderecoNumero;
             case "Estado":
                return this.Estado;
             case "FamiliaCliente":
                return this.FamiliaCliente;
             case "TipoDimensionamentoVolumetrico":
                return this.TipoDimensionamentoVolumetrico;
             case "UtilizarControlesCliente":
                return this.UtilizarControlesCliente;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ResponsavelFrete":
                return this.ResponsavelFrete;
             case "ContaBancaria":
                return this.ContaBancaria;
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
             case "FormaPagamento":
                return this.FormaPagamento;
             case "Cidade":
                return this.Cidade;
             case "CidadeCob":
                return this.CidadeCob;
             case "ObservacaoPadraoNfe":
                return this.ObservacaoPadraoNfe;
             case "EnvioEmail":
                return this.EnvioEmail;
             case "EmailPedido":
                return this.EmailPedido;
             case "EmailOrcamento":
                return this.EmailOrcamento;
             case "Contato":
                return this.Contato;
             case "EmailDanfe":
                return this.EmailDanfe;
             case "EmailXml":
                return this.EmailXml;
             case "Representante":
                return this.Representante;
             case "Vendedor":
                return this.Vendedor;
             case "PercComissaoRepresentante":
                return this.PercComissaoRepresentante;
             case "PercComissaoVendedor":
                return this.PercComissaoVendedor;
             case "AvisoFaturamento":
                return this.AvisoFaturamento;
             case "IndicadorIe":
                return this.IndicadorIe;
             case "InscricaoSuframa":
                return this.InscricaoSuframa;
             case "TipoPagamento":
                return this.TipoPagamento;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (EstadoCob!=null)
                EstadoCob.ChangeSingleConnection(newConnection);
             if (Estado!=null)
                Estado.ChangeSingleConnection(newConnection);
             if (FamiliaCliente!=null)
                FamiliaCliente.ChangeSingleConnection(newConnection);
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
             if (FormaPagamento!=null)
                FormaPagamento.ChangeSingleConnection(newConnection);
             if (Cidade!=null)
                Cidade.ChangeSingleConnection(newConnection);
             if (CidadeCob!=null)
                CidadeCob.ChangeSingleConnection(newConnection);
             if (Representante!=null)
                Representante.ChangeSingleConnection(newConnection);
             if (Vendedor!=null)
                Vendedor.ChangeSingleConnection(newConnection);
             if (TipoPagamento!=null)
                TipoPagamento.ChangeSingleConnection(newConnection);
               if (_valueCollectionCliEassaIdentificaClienteClassClienteLoaded) 
               {
                  foreach(CliEassaIdentificaClienteClass item in CollectionCliEassaIdentificaClienteClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionClienteContatoClassClienteLoaded) 
               {
                  foreach(ClienteContatoClass item in CollectionClienteContatoClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberClassClienteLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberBoletoClassClienteLoaded) 
               {
                  foreach(ContaReceberBoletoClass item in CollectionContaReceberBoletoClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaRecorrenteClassClienteLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionCredorDevedorClassClienteLoaded) 
               {
                  foreach(CredorDevedorClass item in CollectionCredorDevedorClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionLoteClassClienteLoaded) 
               {
                  foreach(LoteClass item in CollectionLoteClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassClienteLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemClassClienteLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemVariavelClassClienteLoaded) 
               {
                  foreach(OrcamentoItemVariavelClass item in CollectionOrcamentoItemVariavelClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoKitClassClienteLoaded) 
               {
                  foreach(OrcamentoKitClass item in CollectionOrcamentoKitClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoVariavelClassClienteLoaded) 
               {
                  foreach(OrcamentoVariavelClass item in CollectionOrcamentoVariavelClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassClienteLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassClienteLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassClienteEnvioTerceirosLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassClienteEnvioTerceiros)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemVariavelClassClienteLoaded) 
               {
                  foreach(PedidoItemVariavelClass item in CollectionPedidoItemVariavelClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoKitClassClienteLoaded) 
               {
                  foreach(PedidoKitClass item in CollectionPedidoKitClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoVariavelClassClienteLoaded) 
               {
                  foreach(PedidoVariavelClass item in CollectionPedidoVariavelClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassClienteLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassCliente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionTabelaPrecoItemVariavelClassClienteLoaded) 
               {
                  foreach(TabelaPrecoItemVariavelClass item in CollectionTabelaPrecoItemVariavelClassCliente)
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
                  command.CommandText += " COUNT(cliente.id_cliente) " ;
               }
               else
               {
               command.CommandText += "cliente.id_cliente, " ;
               command.CommandText += "cliente.cli_nome, " ;
               command.CommandText += "cliente.cli_nome_resumido, " ;
               command.CommandText += "cliente.cli_data_implantacao, " ;
               command.CommandText += "cliente.cli_endereco, " ;
               command.CommandText += "cliente.cli_bairro, " ;
               command.CommandText += "cliente.cli_cep, " ;
               command.CommandText += "cliente.cli_fone1, " ;
               command.CommandText += "cliente.cli_ramal1, " ;
               command.CommandText += "cliente.cli_fone2, " ;
               command.CommandText += "cliente.cli_ramal2, " ;
               command.CommandText += "cliente.cli_fax, " ;
               command.CommandText += "cliente.cli_fax_ramal, " ;
               command.CommandText += "cliente.cli_email, " ;
               command.CommandText += "cliente.cli_cnpj, " ;
               command.CommandText += "cliente.cli_ie, " ;
               command.CommandText += "cliente.cli_inscricao_municipal, " ;
               command.CommandText += "cliente.cli_inscricao_inss, " ;
               command.CommandText += "cliente.cli_pais, " ;
               command.CommandText += "cliente.cli_endereco_cob, " ;
               command.CommandText += "cliente.cli_bairro_cob, " ;
               command.CommandText += "cliente.cli_cep_cob, " ;
               command.CommandText += "cliente.cli_pais_cob, " ;
               command.CommandText += "cliente.cli_observacoes, " ;
               command.CommandText += "cliente.cli_endereco_numero_cob, " ;
               command.CommandText += "cliente.cli_complemento_cob, " ;
               command.CommandText += "cliente.cli_codigo_pais_cob, " ;
               command.CommandText += "cliente.cli_comprador_cliente, " ;
               command.CommandText += "cliente.cli_permite_customizacao_produto, " ;
               command.CommandText += "cliente.cli_complemento, " ;
               command.CommandText += "cliente.id_estado_cob, " ;
               command.CommandText += "cliente.cli_endereco_numero, " ;
               command.CommandText += "cliente.id_estado, " ;
               command.CommandText += "cliente.id_familia_cliente, " ;
               command.CommandText += "cliente.cli_tipo_dimensionamento_volumetrico, " ;
               command.CommandText += "cliente.cli_utilizar_controles_cliente, " ;
               command.CommandText += "cliente.entity_uid, " ;
               command.CommandText += "cliente.version, " ;
               command.CommandText += "cliente.cli_ultima_revisao, " ;
               command.CommandText += "cliente.cli_ultima_revisao_data, " ;
               command.CommandText += "cliente.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "cliente.cli_responsavel_frete, " ;
               command.CommandText += "cliente.id_conta_bancaria, " ;
               command.CommandText += "cliente.id_centro_custo_lucro, " ;
               command.CommandText += "cliente.id_forma_pagamento, " ;
               command.CommandText += "cliente.id_cidade, " ;
               command.CommandText += "cliente.id_cidade_cob, " ;
               command.CommandText += "cliente.cli_observacao_padrao_nfe, " ;
               command.CommandText += "cliente.cli_envio_email, " ;
               command.CommandText += "cliente.cli_email_pedido, " ;
               command.CommandText += "cliente.cli_email_orcamento, " ;
               command.CommandText += "cliente.cli_contato, " ;
               command.CommandText += "cliente.cli_email_danfe, " ;
               command.CommandText += "cliente.cli_email_xml, " ;
               command.CommandText += "cliente.id_representante, " ;
               command.CommandText += "cliente.id_vendedor, " ;
               command.CommandText += "cliente.cli_perc_comissao_representante, " ;
               command.CommandText += "cliente.cli_perc_comissao_vendedor, " ;
               command.CommandText += "cliente.cli_aviso_faturamento, " ;
               command.CommandText += "cliente.cli_indicador_ie, " ;
               command.CommandText += "cliente.cli_inscricao_suframa, " ;
               command.CommandText += "cliente.id_tipo_pagamento " ;
               }
               command.CommandText += " FROM  cliente ";
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
                        orderByClause += " , cli_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(cli_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = cliente.id_acs_usuario_ultima_revisao ";
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
                     case "id_cliente":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.id_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.id_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_nome_resumido":
                     case "NomeResumido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_nome_resumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_nome_resumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_data_implantacao":
                     case "DataImplantacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_data_implantacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_data_implantacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_endereco":
                     case "Endereco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_endereco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_endereco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_bairro":
                     case "Bairro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_bairro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_bairro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_cep":
                     case "Cep":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_cep " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_cep) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_fone1":
                     case "Fone1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_fone1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_fone1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_ramal1":
                     case "Ramal1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_ramal1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_ramal1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_fone2":
                     case "Fone2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_fone2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_fone2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_ramal2":
                     case "Ramal2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_ramal2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_ramal2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_fax":
                     case "Fax":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_fax " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_fax) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_fax_ramal":
                     case "FaxRamal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_fax_ramal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_fax_ramal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_email":
                     case "Email":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_cnpj":
                     case "Cnpj":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_cnpj " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_cnpj) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_ie":
                     case "Ie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_ie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_ie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_inscricao_municipal":
                     case "InscricaoMunicipal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_inscricao_municipal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_inscricao_municipal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_inscricao_inss":
                     case "InscricaoInss":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_inscricao_inss " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_inscricao_inss) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_pais":
                     case "Pais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_pais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_pais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_endereco_cob":
                     case "EnderecoCob":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_endereco_cob " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_endereco_cob) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_bairro_cob":
                     case "BairroCob":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_bairro_cob " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_bairro_cob) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_cep_cob":
                     case "CepCob":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_cep_cob " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_cep_cob) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_pais_cob":
                     case "PaisCob":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_pais_cob " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_pais_cob) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_observacoes":
                     case "Observacoes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_observacoes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_observacoes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_endereco_numero_cob":
                     case "EnderecoNumeroCob":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_endereco_numero_cob " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_endereco_numero_cob) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_complemento_cob":
                     case "ComplementoCob":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_complemento_cob " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_complemento_cob) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_codigo_pais_cob":
                     case "CodigoPaisCob":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_codigo_pais_cob " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_codigo_pais_cob) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_comprador_cliente":
                     case "CompradorCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_comprador_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_comprador_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_permite_customizacao_produto":
                     case "PermiteCustomizacaoProduto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_permite_customizacao_produto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_permite_customizacao_produto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_complemento":
                     case "Complemento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_complemento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_complemento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estado_cob":
                     case "EstadoCob":
                     command.CommandText += " LEFT JOIN estado as estado_EstadoCob ON estado_EstadoCob.id_estado = cliente.id_estado_cob ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_EstadoCob.est_sigla " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_EstadoCob.est_sigla) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_EstadoCob.est_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_EstadoCob.est_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_endereco_numero":
                     case "EnderecoNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_endereco_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_endereco_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estado":
                     case "Estado":
                     command.CommandText += " LEFT JOIN estado as estado_Estado ON estado_Estado.id_estado = cliente.id_estado ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_familia_cliente":
                     case "FamiliaCliente":
                     command.CommandText += " LEFT JOIN familia_cliente as familia_cliente_FamiliaCliente ON familia_cliente_FamiliaCliente.id_familia_cliente = cliente.id_familia_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , familia_cliente_FamiliaCliente.fac_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(familia_cliente_FamiliaCliente.fac_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_tipo_dimensionamento_volumetrico":
                     case "TipoDimensionamentoVolumetrico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_tipo_dimensionamento_volumetrico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_tipo_dimensionamento_volumetrico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_utilizar_controles_cliente":
                     case "UtilizarControlesCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_utilizar_controles_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_utilizar_controles_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , cliente.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , cliente.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "cli_responsavel_frete":
                     case "ResponsavelFrete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_responsavel_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_responsavel_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = cliente.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = cliente.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN forma_pagamento as forma_pagamento_FormaPagamento ON forma_pagamento_FormaPagamento.id_forma_pagamento = cliente.id_forma_pagamento ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_cidade":
                     case "Cidade":
                     command.CommandText += " LEFT JOIN cidade as cidade_Cidade ON cidade_Cidade.id_cidade = cliente.id_cidade ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_cidade_cob":
                     case "CidadeCob":
                     command.CommandText += " LEFT JOIN cidade as cidade_CidadeCob ON cidade_CidadeCob.id_cidade = cliente.id_cidade_cob ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cidade_CidadeCob.cid_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cidade_CidadeCob.cid_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_observacao_padrao_nfe":
                     case "ObservacaoPadraoNfe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_observacao_padrao_nfe " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_observacao_padrao_nfe) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_envio_email":
                     case "EnvioEmail":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_envio_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_envio_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_email_pedido":
                     case "EmailPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_email_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_email_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_email_orcamento":
                     case "EmailOrcamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_email_orcamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_email_orcamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_contato":
                     case "Contato":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_contato " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_contato) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_email_danfe":
                     case "EmailDanfe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_email_danfe " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_email_danfe) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_email_xml":
                     case "EmailXml":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_email_xml " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_email_xml) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_representante":
                     case "Representante":
                     command.CommandText += " LEFT JOIN representante as representante_Representante ON representante_Representante.id_representante = cliente.id_representante ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_vendedor":
                     case "Vendedor":
                     command.CommandText += " LEFT JOIN vendedor as vendedor_Vendedor ON vendedor_Vendedor.id_vendedor = cliente.id_vendedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "cli_perc_comissao_representante":
                     case "PercComissaoRepresentante":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_perc_comissao_representante " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_perc_comissao_representante) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_perc_comissao_vendedor":
                     case "PercComissaoVendedor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_perc_comissao_vendedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_perc_comissao_vendedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_aviso_faturamento":
                     case "AvisoFaturamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_aviso_faturamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_aviso_faturamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_indicador_ie":
                     case "IndicadorIe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cliente.cli_indicador_ie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cliente.cli_indicador_ie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cli_inscricao_suframa":
                     case "InscricaoSuframa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente.cli_inscricao_suframa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente.cli_inscricao_suframa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_tipo_pagamento":
                     case "TipoPagamento":
                     command.CommandText += " LEFT JOIN tipo_pagamento as tipo_pagamento_TipoPagamento ON tipo_pagamento_TipoPagamento.id_tipo_pagamento = cliente.id_tipo_pagamento ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_pagamento_TipoPagamento.tip_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_pagamento_TipoPagamento.tip_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_nome")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_nome_resumido")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_nome_resumido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_nome_resumido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_endereco")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_endereco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_endereco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_bairro")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_bairro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_bairro) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_cep")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_cep) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_cep) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_fone1")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_fone1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_fone1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_ramal1")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_ramal1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_ramal1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_fone2")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_fone2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_fone2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_ramal2")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_ramal2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_ramal2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_fax")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_fax) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_fax) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_fax_ramal")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_fax_ramal) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_fax_ramal) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_email")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_email) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_email) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_cnpj")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_cnpj) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_cnpj) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_ie")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_ie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_ie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_inscricao_municipal")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_inscricao_municipal) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_inscricao_municipal) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_inscricao_inss")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_inscricao_inss) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_inscricao_inss) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_pais")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_pais) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_pais) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_endereco_cob")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_endereco_cob) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_endereco_cob) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_bairro_cob")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_bairro_cob) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_bairro_cob) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_cep_cob")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_cep_cob) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_cep_cob) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_pais_cob")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_pais_cob) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_pais_cob) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_observacoes")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_observacoes) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_observacoes) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_endereco_numero_cob")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_endereco_numero_cob) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_endereco_numero_cob) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_complemento_cob")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_complemento_cob) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_complemento_cob) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_comprador_cliente")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_comprador_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_comprador_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_complemento")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_complemento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_complemento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_endereco_numero")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_endereco_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_endereco_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(cliente.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_observacao_padrao_nfe")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_observacao_padrao_nfe) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_observacao_padrao_nfe) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_email_pedido")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_email_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_email_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_email_orcamento")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_email_orcamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_email_orcamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_contato")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_contato) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_contato) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_email_danfe")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_email_danfe) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_email_danfe) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_email_xml")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_email_xml) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_email_xml) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_aviso_faturamento")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_aviso_faturamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_aviso_faturamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cli_inscricao_suframa")) 
                        {
                           whereClause += " OR UPPER(cliente.cli_inscricao_suframa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cliente.cli_inscricao_suframa) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_cliente = :cliente_ID_8743 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_ID_8743", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "cli_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_nome LIKE :cliente_Nome_334 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Nome_334", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeResumido" || parametro.FieldName == "cli_nome_resumido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_nome_resumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_nome_resumido LIKE :cliente_NomeResumido_7268 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_NomeResumido_7268", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataImplantacao" || parametro.FieldName == "cli_data_implantacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_data_implantacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_data_implantacao = :cliente_DataImplantacao_4599 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_DataImplantacao_4599", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Endereco" || parametro.FieldName == "cli_endereco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_endereco LIKE :cliente_Endereco_281 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Endereco_281", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Bairro" || parametro.FieldName == "cli_bairro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_bairro LIKE :cliente_Bairro_3011 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Bairro_3011", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cep" || parametro.FieldName == "cli_cep")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_cep LIKE :cliente_Cep_9040 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Cep_9040", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone1" || parametro.FieldName == "cli_fone1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_fone1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_fone1 LIKE :cliente_Fone1_5748 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Fone1_5748", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ramal1" || parametro.FieldName == "cli_ramal1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_ramal1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_ramal1 LIKE :cliente_Ramal1_4861 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Ramal1_4861", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone2" || parametro.FieldName == "cli_fone2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_fone2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_fone2 LIKE :cliente_Fone2_4742 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Fone2_4742", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ramal2" || parametro.FieldName == "cli_ramal2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_ramal2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_ramal2 LIKE :cliente_Ramal2_3312 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Ramal2_3312", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fax" || parametro.FieldName == "cli_fax")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_fax IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_fax LIKE :cliente_Fax_1101 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Fax_1101", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FaxRamal" || parametro.FieldName == "cli_fax_ramal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_fax_ramal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_fax_ramal LIKE :cliente_FaxRamal_7664 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_FaxRamal_7664", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Email" || parametro.FieldName == "cli_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email LIKE :cliente_Email_6561 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Email_6561", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnpj" || parametro.FieldName == "cli_cnpj")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_cnpj LIKE :cliente_Cnpj_125 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Cnpj_125", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ie" || parametro.FieldName == "cli_ie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_ie LIKE :cliente_Ie_7616 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Ie_7616", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoMunicipal" || parametro.FieldName == "cli_inscricao_municipal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_inscricao_municipal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_inscricao_municipal LIKE :cliente_InscricaoMunicipal_4054 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_InscricaoMunicipal_4054", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoInss" || parametro.FieldName == "cli_inscricao_inss")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_inscricao_inss IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_inscricao_inss LIKE :cliente_InscricaoInss_5789 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_InscricaoInss_5789", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pais" || parametro.FieldName == "cli_pais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_pais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_pais LIKE :cliente_Pais_1021 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Pais_1021", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoCob" || parametro.FieldName == "cli_endereco_cob")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_endereco_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_endereco_cob LIKE :cliente_EnderecoCob_1770 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EnderecoCob_1770", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BairroCob" || parametro.FieldName == "cli_bairro_cob")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_bairro_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_bairro_cob LIKE :cliente_BairroCob_2136 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_BairroCob_2136", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CepCob" || parametro.FieldName == "cli_cep_cob")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_cep_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_cep_cob LIKE :cliente_CepCob_2644 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_CepCob_2644", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PaisCob" || parametro.FieldName == "cli_pais_cob")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_pais_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_pais_cob LIKE :cliente_PaisCob_8895 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_PaisCob_8895", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacoes" || parametro.FieldName == "cli_observacoes")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_observacoes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_observacoes LIKE :cliente_Observacoes_2681 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Observacoes_2681", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoNumeroCob" || parametro.FieldName == "cli_endereco_numero_cob")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_endereco_numero_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_endereco_numero_cob LIKE :cliente_EnderecoNumeroCob_1012 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EnderecoNumeroCob_1012", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ComplementoCob" || parametro.FieldName == "cli_complemento_cob")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_complemento_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_complemento_cob LIKE :cliente_ComplementoCob_1666 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_ComplementoCob_1666", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoPaisCob" || parametro.FieldName == "cli_codigo_pais_cob")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_codigo_pais_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_codigo_pais_cob = :cliente_CodigoPaisCob_5160 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_CodigoPaisCob_5160", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompradorCliente" || parametro.FieldName == "cli_comprador_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_comprador_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_comprador_cliente LIKE :cliente_CompradorCliente_2415 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_CompradorCliente_2415", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PermiteCustomizacaoProduto" || parametro.FieldName == "cli_permite_customizacao_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_permite_customizacao_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_permite_customizacao_produto = :cliente_PermiteCustomizacaoProduto_8876 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_PermiteCustomizacaoProduto_8876", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Complemento" || parametro.FieldName == "cli_complemento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_complemento LIKE :cliente_Complemento_5685 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Complemento_5685", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstadoCob" || parametro.FieldName == "id_estado_cob")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstadoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstadoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.id_estado_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_estado_cob = :cliente_EstadoCob_5010 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EstadoCob_5010", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoNumero" || parametro.FieldName == "cli_endereco_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_endereco_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_endereco_numero LIKE :cliente_EnderecoNumero_2262 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EnderecoNumero_2262", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  cliente.id_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_estado = :cliente_Estado_8757 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Estado_8757", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FamiliaCliente" || parametro.FieldName == "id_familia_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FamiliaClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FamiliaClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.id_familia_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_familia_cliente = :cliente_FamiliaCliente_8483 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_FamiliaCliente_8483", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDimensionamentoVolumetrico" || parametro.FieldName == "cli_tipo_dimensionamento_volumetrico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ClienteTipoDimensionamentoVolumetrico)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ClienteTipoDimensionamentoVolumetrico");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_tipo_dimensionamento_volumetrico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_tipo_dimensionamento_volumetrico = :cliente_TipoDimensionamentoVolumetrico_4092 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_TipoDimensionamentoVolumetrico_4092", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizarControlesCliente" || parametro.FieldName == "cli_utilizar_controles_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_utilizar_controles_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_utilizar_controles_cliente = :cliente_UtilizarControlesCliente_6859 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_UtilizarControlesCliente_6859", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  cliente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.entity_uid LIKE :cliente_EntityUid_4047 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EntityUid_4047", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  cliente.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.version = :cliente_Version_5564 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Version_5564", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "cli_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_ultima_revisao LIKE :cliente_UltimaRevisao_1945 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_UltimaRevisao_1945", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "cli_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_ultima_revisao_data = :cliente_UltimaRevisaoData_1364 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_UltimaRevisaoData_1364", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario" || parametro.FieldName == "id_acs_usuario_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_acs_usuario_ultima_revisao = :cliente_UltimaRevisaoUsuario_312 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_UltimaRevisaoUsuario_312", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ResponsavelFrete" || parametro.FieldName == "cli_responsavel_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ResponsavelFrete)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ResponsavelFrete");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_responsavel_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_responsavel_frete = :cliente_ResponsavelFrete_5379 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_ResponsavelFrete_5379", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  cliente.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_conta_bancaria = :cliente_ContaBancaria_2898 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_ContaBancaria_2898", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  cliente.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_centro_custo_lucro = :cliente_CentroCustoLucro_6240 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_CentroCustoLucro_6240", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  cliente.id_forma_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_forma_pagamento = :cliente_FormaPagamento_6902 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_FormaPagamento_6902", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  cliente.id_cidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_cidade = :cliente_Cidade_9481 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Cidade_9481", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CidadeCob" || parametro.FieldName == "id_cidade_cob")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CidadeClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CidadeClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.id_cidade_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_cidade_cob = :cliente_CidadeCob_5740 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_CidadeCob_5740", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoPadraoNfe" || parametro.FieldName == "cli_observacao_padrao_nfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_observacao_padrao_nfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_observacao_padrao_nfe LIKE :cliente_ObservacaoPadraoNfe_5515 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_ObservacaoPadraoNfe_5515", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnvioEmail" || parametro.FieldName == "cli_envio_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_envio_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_envio_email = :cliente_EnvioEmail_9821 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EnvioEmail_9821", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailPedido" || parametro.FieldName == "cli_email_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_email_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email_pedido LIKE :cliente_EmailPedido_1443 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EmailPedido_1443", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailOrcamento" || parametro.FieldName == "cli_email_orcamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_email_orcamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email_orcamento LIKE :cliente_EmailOrcamento_9629 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EmailOrcamento_9629", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Contato" || parametro.FieldName == "cli_contato")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_contato IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_contato LIKE :cliente_Contato_109 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Contato_109", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailDanfe" || parametro.FieldName == "cli_email_danfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_email_danfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email_danfe LIKE :cliente_EmailDanfe_9112 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EmailDanfe_9112", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailXml" || parametro.FieldName == "cli_email_xml")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_email_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email_xml LIKE :cliente_EmailXml_2719 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EmailXml_2719", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  cliente.id_representante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_representante = :cliente_Representante_5319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Representante_5319", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  cliente.id_vendedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_vendedor = :cliente_Vendedor_6100 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Vendedor_6100", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercComissaoRepresentante" || parametro.FieldName == "cli_perc_comissao_representante")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_perc_comissao_representante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_perc_comissao_representante = :cliente_PercComissaoRepresentante_1437 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_PercComissaoRepresentante_1437", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercComissaoVendedor" || parametro.FieldName == "cli_perc_comissao_vendedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_perc_comissao_vendedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_perc_comissao_vendedor = :cliente_PercComissaoVendedor_4587 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_PercComissaoVendedor_4587", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AvisoFaturamento" || parametro.FieldName == "cli_aviso_faturamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_aviso_faturamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_aviso_faturamento LIKE :cliente_AvisoFaturamento_3587 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_AvisoFaturamento_3587", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndicadorIe" || parametro.FieldName == "cli_indicador_ie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFIndicadorIE)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFIndicadorIE");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_indicador_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_indicador_ie = :cliente_IndicadorIe_8613 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_IndicadorIe_8613", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoSuframa" || parametro.FieldName == "cli_inscricao_suframa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_inscricao_suframa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_inscricao_suframa LIKE :cliente_InscricaoSuframa_7850 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_InscricaoSuframa_7850", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoPagamento" || parametro.FieldName == "id_tipo_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.TipoPagamentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.TipoPagamentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.id_tipo_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.id_tipo_pagamento = :cliente_TipoPagamento_6625 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_TipoPagamento_6625", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeExato" || parametro.FieldName == "NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_nome LIKE :cliente_Nome_6870 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Nome_6870", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeResumidoExato" || parametro.FieldName == "NomeResumidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_nome_resumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_nome_resumido LIKE :cliente_NomeResumido_9174 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_NomeResumido_9174", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_endereco LIKE :cliente_Endereco_9731 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Endereco_9731", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_bairro LIKE :cliente_Bairro_1051 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Bairro_1051", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_cep LIKE :cliente_Cep_2342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Cep_2342", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_fone1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_fone1 LIKE :cliente_Fone1_9180 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Fone1_9180", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ramal1Exato" || parametro.FieldName == "Ramal1Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_ramal1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_ramal1 LIKE :cliente_Ramal1_2470 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Ramal1_2470", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_fone2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_fone2 LIKE :cliente_Fone2_3265 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Fone2_3265", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ramal2Exato" || parametro.FieldName == "Ramal2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_ramal2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_ramal2 LIKE :cliente_Ramal2_3570 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Ramal2_3570", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_fax IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_fax LIKE :cliente_Fax_8489 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Fax_8489", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FaxRamalExato" || parametro.FieldName == "FaxRamalExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_fax_ramal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_fax_ramal LIKE :cliente_FaxRamal_3844 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_FaxRamal_3844", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email LIKE :cliente_Email_9656 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Email_9656", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_cnpj LIKE :cliente_Cnpj_1459 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Cnpj_1459", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeExato" || parametro.FieldName == "IeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_ie LIKE :cliente_Ie_6755 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Ie_6755", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoMunicipalExato" || parametro.FieldName == "InscricaoMunicipalExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_inscricao_municipal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_inscricao_municipal LIKE :cliente_InscricaoMunicipal_9745 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_InscricaoMunicipal_9745", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoInssExato" || parametro.FieldName == "InscricaoInssExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_inscricao_inss IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_inscricao_inss LIKE :cliente_InscricaoInss_2656 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_InscricaoInss_2656", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_pais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_pais LIKE :cliente_Pais_5778 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Pais_5778", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoCobExato" || parametro.FieldName == "EnderecoCobExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_endereco_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_endereco_cob LIKE :cliente_EnderecoCob_1530 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EnderecoCob_1530", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BairroCobExato" || parametro.FieldName == "BairroCobExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_bairro_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_bairro_cob LIKE :cliente_BairroCob_5925 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_BairroCob_5925", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CepCobExato" || parametro.FieldName == "CepCobExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_cep_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_cep_cob LIKE :cliente_CepCob_9644 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_CepCob_9644", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PaisCobExato" || parametro.FieldName == "PaisCobExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_pais_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_pais_cob LIKE :cliente_PaisCob_2593 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_PaisCob_2593", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacoesExato" || parametro.FieldName == "ObservacoesExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_observacoes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_observacoes LIKE :cliente_Observacoes_7434 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Observacoes_7434", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoNumeroCobExato" || parametro.FieldName == "EnderecoNumeroCobExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_endereco_numero_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_endereco_numero_cob LIKE :cliente_EnderecoNumeroCob_6054 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EnderecoNumeroCob_6054", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ComplementoCobExato" || parametro.FieldName == "ComplementoCobExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_complemento_cob IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_complemento_cob LIKE :cliente_ComplementoCob_4902 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_ComplementoCob_4902", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompradorClienteExato" || parametro.FieldName == "CompradorClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_comprador_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_comprador_cliente LIKE :cliente_CompradorCliente_3149 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_CompradorCliente_3149", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ComplementoExato" || parametro.FieldName == "ComplementoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_complemento LIKE :cliente_Complemento_6038 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Complemento_6038", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoNumeroExato" || parametro.FieldName == "EnderecoNumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_endereco_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_endereco_numero LIKE :cliente_EnderecoNumero_3164 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EnderecoNumero_3164", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.entity_uid LIKE :cliente_EntityUid_7991 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EntityUid_7991", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoExato" || parametro.FieldName == "UltimaRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_ultima_revisao LIKE :cliente_UltimaRevisao_5422 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_UltimaRevisao_5422", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoPadraoNfeExato" || parametro.FieldName == "ObservacaoPadraoNfeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_observacao_padrao_nfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_observacao_padrao_nfe LIKE :cliente_ObservacaoPadraoNfe_9458 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_ObservacaoPadraoNfe_9458", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_email_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email_pedido LIKE :cliente_EmailPedido_1977 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EmailPedido_1977", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailOrcamentoExato" || parametro.FieldName == "EmailOrcamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_email_orcamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email_orcamento LIKE :cliente_EmailOrcamento_3330 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EmailOrcamento_3330", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_contato IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_contato LIKE :cliente_Contato_3512 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_Contato_3512", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_email_danfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email_danfe LIKE :cliente_EmailDanfe_3686 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EmailDanfe_3686", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_email_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_email_xml LIKE :cliente_EmailXml_8508 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_EmailXml_8508", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AvisoFaturamentoExato" || parametro.FieldName == "AvisoFaturamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cliente.cli_aviso_faturamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_aviso_faturamento LIKE :cliente_AvisoFaturamento_3722 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_AvisoFaturamento_3722", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cliente.cli_inscricao_suframa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cliente.cli_inscricao_suframa LIKE :cliente_InscricaoSuframa_6508 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cliente_InscricaoSuframa_6508", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ClienteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ClienteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ClienteClass), Convert.ToInt32(read["id_cliente"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ClienteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_cliente"]);
                     entidade.Nome = (read["cli_nome"] != DBNull.Value ? read["cli_nome"].ToString() : null);
                     entidade.NomeResumido = (read["cli_nome_resumido"] != DBNull.Value ? read["cli_nome_resumido"].ToString() : null);
                     entidade.DataImplantacao = read["cli_data_implantacao"] as DateTime?;
                     entidade.Endereco = (read["cli_endereco"] != DBNull.Value ? read["cli_endereco"].ToString() : null);
                     entidade.Bairro = (read["cli_bairro"] != DBNull.Value ? read["cli_bairro"].ToString() : null);
                     entidade.Cep = (read["cli_cep"] != DBNull.Value ? read["cli_cep"].ToString() : null);
                     entidade.Fone1 = (read["cli_fone1"] != DBNull.Value ? read["cli_fone1"].ToString() : null);
                     entidade.Ramal1 = (read["cli_ramal1"] != DBNull.Value ? read["cli_ramal1"].ToString() : null);
                     entidade.Fone2 = (read["cli_fone2"] != DBNull.Value ? read["cli_fone2"].ToString() : null);
                     entidade.Ramal2 = (read["cli_ramal2"] != DBNull.Value ? read["cli_ramal2"].ToString() : null);
                     entidade.Fax = (read["cli_fax"] != DBNull.Value ? read["cli_fax"].ToString() : null);
                     entidade.FaxRamal = (read["cli_fax_ramal"] != DBNull.Value ? read["cli_fax_ramal"].ToString() : null);
                     entidade.Email = (read["cli_email"] != DBNull.Value ? read["cli_email"].ToString() : null);
                     entidade.Cnpj = (read["cli_cnpj"] != DBNull.Value ? read["cli_cnpj"].ToString() : null);
                     entidade.Ie = (read["cli_ie"] != DBNull.Value ? read["cli_ie"].ToString() : null);
                     entidade.InscricaoMunicipal = (read["cli_inscricao_municipal"] != DBNull.Value ? read["cli_inscricao_municipal"].ToString() : null);
                     entidade.InscricaoInss = (read["cli_inscricao_inss"] != DBNull.Value ? read["cli_inscricao_inss"].ToString() : null);
                     entidade.Pais = (read["cli_pais"] != DBNull.Value ? read["cli_pais"].ToString() : null);
                     entidade.EnderecoCob = (read["cli_endereco_cob"] != DBNull.Value ? read["cli_endereco_cob"].ToString() : null);
                     entidade.BairroCob = (read["cli_bairro_cob"] != DBNull.Value ? read["cli_bairro_cob"].ToString() : null);
                     entidade.CepCob = (read["cli_cep_cob"] != DBNull.Value ? read["cli_cep_cob"].ToString() : null);
                     entidade.PaisCob = (read["cli_pais_cob"] != DBNull.Value ? read["cli_pais_cob"].ToString() : null);
                     entidade.Observacoes = (read["cli_observacoes"] != DBNull.Value ? read["cli_observacoes"].ToString() : null);
                     entidade.EnderecoNumeroCob = (read["cli_endereco_numero_cob"] != DBNull.Value ? read["cli_endereco_numero_cob"].ToString() : null);
                     entidade.ComplementoCob = (read["cli_complemento_cob"] != DBNull.Value ? read["cli_complemento_cob"].ToString() : null);
                     entidade.CodigoPaisCob = read["cli_codigo_pais_cob"] as int?;
                     entidade.CompradorCliente = (read["cli_comprador_cliente"] != DBNull.Value ? read["cli_comprador_cliente"].ToString() : null);
                     entidade.PermiteCustomizacaoProduto = (read["cli_permite_customizacao_produto"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["cli_permite_customizacao_produto"])) : null);
                     entidade.Complemento = (read["cli_complemento"] != DBNull.Value ? read["cli_complemento"].ToString() : null);
                     if (read["id_estado_cob"] != DBNull.Value)
                     {
                        entidade.EstadoCob = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado_cob"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstadoCob = null ;
                     }
                     entidade.EnderecoNumero = (read["cli_endereco_numero"] != DBNull.Value ? read["cli_endereco_numero"].ToString() : null);
                     if (read["id_estado"] != DBNull.Value)
                     {
                        entidade.Estado = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Estado = null ;
                     }
                     if (read["id_familia_cliente"] != DBNull.Value)
                     {
                        entidade.FamiliaCliente = (BibliotecaEntidades.Entidades.FamiliaClienteClass)BibliotecaEntidades.Entidades.FamiliaClienteClass.GetEntidade(Convert.ToInt32(read["id_familia_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FamiliaCliente = null ;
                     }
                     entidade.TipoDimensionamentoVolumetrico = (ClienteTipoDimensionamentoVolumetrico) (read["cli_tipo_dimensionamento_volumetrico"] != DBNull.Value ? Enum.ToObject(typeof(ClienteTipoDimensionamentoVolumetrico), read["cli_tipo_dimensionamento_volumetrico"]) : null);
                     entidade.UtilizarControlesCliente = Convert.ToBoolean(Convert.ToInt16(read["cli_utilizar_controles_cliente"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.UltimaRevisao = (read["cli_ultima_revisao"] != DBNull.Value ? read["cli_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["cli_ultima_revisao_data"] as DateTime?;
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.ResponsavelFrete = (ResponsavelFrete) (read["cli_responsavel_frete"] != DBNull.Value ? Enum.ToObject(typeof(ResponsavelFrete), read["cli_responsavel_frete"]) : null);
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
                     if (read["id_cidade"] != DBNull.Value)
                     {
                        entidade.Cidade = (BibliotecaEntidades.Entidades.CidadeClass)BibliotecaEntidades.Entidades.CidadeClass.GetEntidade(Convert.ToInt32(read["id_cidade"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cidade = null ;
                     }
                     if (read["id_cidade_cob"] != DBNull.Value)
                     {
                        entidade.CidadeCob = (BibliotecaEntidades.Entidades.CidadeClass)BibliotecaEntidades.Entidades.CidadeClass.GetEntidade(Convert.ToInt32(read["id_cidade_cob"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CidadeCob = null ;
                     }
                     entidade.ObservacaoPadraoNfe = (read["cli_observacao_padrao_nfe"] != DBNull.Value ? read["cli_observacao_padrao_nfe"].ToString() : null);
                     entidade.EnvioEmail = Convert.ToBoolean(Convert.ToInt16(read["cli_envio_email"]));
                     entidade.EmailPedido = (read["cli_email_pedido"] != DBNull.Value ? read["cli_email_pedido"].ToString() : null);
                     entidade.EmailOrcamento = (read["cli_email_orcamento"] != DBNull.Value ? read["cli_email_orcamento"].ToString() : null);
                     entidade.Contato = (read["cli_contato"] != DBNull.Value ? read["cli_contato"].ToString() : null);
                     entidade.EmailDanfe = (read["cli_email_danfe"] != DBNull.Value ? read["cli_email_danfe"].ToString() : null);
                     entidade.EmailXml = (read["cli_email_xml"] != DBNull.Value ? read["cli_email_xml"].ToString() : null);
                     if (read["id_representante"] != DBNull.Value)
                     {
                        entidade.Representante = (BibliotecaEntidades.Entidades.RepresentanteClass)BibliotecaEntidades.Entidades.RepresentanteClass.GetEntidade(Convert.ToInt32(read["id_representante"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Representante = null ;
                     }
                     if (read["id_vendedor"] != DBNull.Value)
                     {
                        entidade.Vendedor = (BibliotecaEntidades.Entidades.VendedorClass)BibliotecaEntidades.Entidades.VendedorClass.GetEntidade(Convert.ToInt32(read["id_vendedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Vendedor = null ;
                     }
                     entidade.PercComissaoRepresentante = read["cli_perc_comissao_representante"] as double?;
                     entidade.PercComissaoVendedor = read["cli_perc_comissao_vendedor"] as double?;
                     entidade.AvisoFaturamento = (read["cli_aviso_faturamento"] != DBNull.Value ? read["cli_aviso_faturamento"].ToString() : null);
                     entidade.IndicadorIe = (IWTNFIndicadorIE) (read["cli_indicador_ie"] != DBNull.Value ? Enum.ToObject(typeof(IWTNFIndicadorIE), read["cli_indicador_ie"]) : null);
                     entidade.InscricaoSuframa = (read["cli_inscricao_suframa"] != DBNull.Value ? read["cli_inscricao_suframa"].ToString() : null);
                     if (read["id_tipo_pagamento"] != DBNull.Value)
                     {
                        entidade.TipoPagamento = (BibliotecaEntidades.Entidades.TipoPagamentoClass)BibliotecaEntidades.Entidades.TipoPagamentoClass.GetEntidade(Convert.ToInt32(read["id_tipo_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.TipoPagamento = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ClienteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
