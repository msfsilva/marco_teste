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
     [Table("mdfe","mdf")]
     public class MdfeBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MdfeClass";
protected const string ErroDelete = "Erro ao excluir o MdfeClass  ";
protected const string ErroSave = "Erro ao salvar o MdfeClass.";
protected const string ErroCollectionMdfeLacreClassMdfe = "Erro ao carregar a coleção de MdfeLacreClass.";
protected const string ErroCollectionMdfeModalRodoviarioClassMdfe = "Erro ao carregar a coleção de MdfeModalRodoviarioClass.";
protected const string ErroCollectionMdfeMunicipioCarregamentoClassMdfe = "Erro ao carregar a coleção de MdfeMunicipioCarregamentoClass.";
protected const string ErroCollectionMdfeMunicipioDescarregamentoClassMdfe = "Erro ao carregar a coleção de MdfeMunicipioDescarregamentoClass.";
protected const string ErroCollectionMdfeNfeClassMdfe = "Erro ao carregar a coleção de MdfeNfeClass.";
protected const string ErroCollectionMdfePercursoClassMdfe = "Erro ao carregar a coleção de MdfePercursoClass.";
protected const string ErroChaveAcessoObrigatorio = "O campo ChaveAcesso é obrigatório";
protected const string ErroChaveAcessoComprimento = "O campo ChaveAcesso deve ter no máximo 48 caracteres";
protected const string ErroVersaoObrigatorio = "O campo Versao é obrigatório";
protected const string ErroVersaoComprimento = "O campo Versao deve ter no máximo 10 caracteres";
protected const string ErroVersaoAplicativoObrigatorio = "O campo VersaoAplicativo é obrigatório";
protected const string ErroVersaoAplicativoComprimento = "O campo VersaoAplicativo deve ter no máximo 20 caracteres";
protected const string ErroUfCarregamentoObrigatorio = "O campo UfCarregamento é obrigatório";
protected const string ErroUfCarregamentoComprimento = "O campo UfCarregamento deve ter no máximo 2 caracteres";
protected const string ErroUfDescarregamentoObrigatorio = "O campo UfDescarregamento é obrigatório";
protected const string ErroUfDescarregamentoComprimento = "O campo UfDescarregamento deve ter no máximo 2 caracteres";
protected const string ErroCnpjEmitenteObrigatorio = "O campo CnpjEmitente é obrigatório";
protected const string ErroCnpjEmitenteComprimento = "O campo CnpjEmitente deve ter no máximo 14 caracteres";
protected const string ErroIeEmitenteObrigatorio = "O campo IeEmitente é obrigatório";
protected const string ErroIeEmitenteComprimento = "O campo IeEmitente deve ter no máximo 14 caracteres";
protected const string ErroRazaoEmitenteObrigatorio = "O campo RazaoEmitente é obrigatório";
protected const string ErroRazaoEmitenteComprimento = "O campo RazaoEmitente deve ter no máximo 60 caracteres";
protected const string ErroLogradouroEmitenteObrigatorio = "O campo LogradouroEmitente é obrigatório";
protected const string ErroLogradouroEmitenteComprimento = "O campo LogradouroEmitente deve ter no máximo 60 caracteres";
protected const string ErroNumeroEnderecoEmitenteObrigatorio = "O campo NumeroEnderecoEmitente é obrigatório";
protected const string ErroNumeroEnderecoEmitenteComprimento = "O campo NumeroEnderecoEmitente deve ter no máximo 60 caracteres";
protected const string ErroBairroEmitenteObrigatorio = "O campo BairroEmitente é obrigatório";
protected const string ErroBairroEmitenteComprimento = "O campo BairroEmitente deve ter no máximo 60 caracteres";
protected const string ErroMunicipioEmitenteObrigatorio = "O campo MunicipioEmitente é obrigatório";
protected const string ErroMunicipioEmitenteComprimento = "O campo MunicipioEmitente deve ter no máximo 60 caracteres";
protected const string ErroUfEmitenteObrigatorio = "O campo UfEmitente é obrigatório";
protected const string ErroUfEmitenteComprimento = "O campo UfEmitente deve ter no máximo 2 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do MdfeClass.";
protected const string MensagemUtilizadoCollectionMdfeLacreClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeLacreClass:";
protected const string MensagemUtilizadoCollectionMdfeModalRodoviarioClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeModalRodoviarioClass:";
protected const string MensagemUtilizadoCollectionMdfeMunicipioCarregamentoClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeMunicipioCarregamentoClass:";
protected const string MensagemUtilizadoCollectionMdfeMunicipioDescarregamentoClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeMunicipioDescarregamentoClass:";
protected const string MensagemUtilizadoCollectionMdfeNfeClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeNfeClass:";
protected const string MensagemUtilizadoCollectionMdfePercursoClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfePercursoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeClass está sendo utilizada.";
#endregion
       protected int _numeroOriginal{get;private set;}
       private int _numeroOriginalCommited{get; set;}
        private int _valueNumero;
         [Column("mdf_numero")]
        public virtual int Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected int _serieOriginal{get;private set;}
       private int _serieOriginalCommited{get; set;}
        private int _valueSerie;
         [Column("mdf_serie")]
        public virtual int Serie
         { 
            get { return this._valueSerie; } 
            set 
            { 
                if (this._valueSerie == value)return;
                 this._valueSerie = value; 
            } 
        } 

       protected int _codigoOriginal{get;private set;}
       private int _codigoOriginalCommited{get; set;}
        private int _valueCodigo;
         [Column("mdf_codigo")]
        public virtual int Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected string _chaveAcessoOriginal{get;private set;}
       private string _chaveAcessoOriginalCommited{get; set;}
        private string _valueChaveAcesso;
         [Column("mdf_chave_acesso")]
        public virtual string ChaveAcesso
         { 
            get { return this._valueChaveAcesso; } 
            set 
            { 
                if (this._valueChaveAcesso == value)return;
                 this._valueChaveAcesso = value; 
            } 
        } 

       protected int _dvChaveAcessoOriginal{get;private set;}
       private int _dvChaveAcessoOriginalCommited{get; set;}
        private int _valueDvChaveAcesso;
         [Column("mdf_dv_chave_acesso")]
        public virtual int DvChaveAcesso
         { 
            get { return this._valueDvChaveAcesso; } 
            set 
            { 
                if (this._valueDvChaveAcesso == value)return;
                 this._valueDvChaveAcesso = value; 
            } 
        } 

       protected string _versaoOriginal{get;private set;}
       private string _versaoOriginalCommited{get; set;}
        private string _valueVersao;
         [Column("mdf_versao")]
        public virtual string Versao
         { 
            get { return this._valueVersao; } 
            set 
            { 
                if (this._valueVersao == value)return;
                 this._valueVersao = value; 
            } 
        } 

       protected int _codIbgeUfEmitenteOriginal{get;private set;}
       private int _codIbgeUfEmitenteOriginalCommited{get; set;}
        private int _valueCodIbgeUfEmitente;
         [Column("mdf_cod_ibge_uf_emitente")]
        public virtual int CodIbgeUfEmitente
         { 
            get { return this._valueCodIbgeUfEmitente; } 
            set 
            { 
                if (this._valueCodIbgeUfEmitente == value)return;
                 this._valueCodIbgeUfEmitente = value; 
            } 
        } 

       protected MDFeTipoAmbiente _tipoAmbienteOriginal{get;private set;}
       private MDFeTipoAmbiente _tipoAmbienteOriginalCommited{get; set;}
        private MDFeTipoAmbiente _valueTipoAmbiente;
         [Column("mdf_tipo_ambiente")]
        public virtual MDFeTipoAmbiente TipoAmbiente
         { 
            get { return this._valueTipoAmbiente; } 
            set 
            { 
                if (this._valueTipoAmbiente == value)return;
                 this._valueTipoAmbiente = value; 
            } 
        } 

        public bool TipoAmbiente_Producao
         { 
            get { return this._valueTipoAmbiente == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoAmbiente.Producao; } 
            set { if (value) this._valueTipoAmbiente = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoAmbiente.Producao; }
         } 

        public bool TipoAmbiente_Homologacao
         { 
            get { return this._valueTipoAmbiente == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoAmbiente.Homologacao; } 
            set { if (value) this._valueTipoAmbiente = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoAmbiente.Homologacao; }
         } 

       protected MDFeTipoEmitente _tipoEmitenteOriginal{get;private set;}
       private MDFeTipoEmitente _tipoEmitenteOriginalCommited{get; set;}
        private MDFeTipoEmitente _valueTipoEmitente;
         [Column("mdf_tipo_emitente")]
        public virtual MDFeTipoEmitente TipoEmitente
         { 
            get { return this._valueTipoEmitente; } 
            set 
            { 
                if (this._valueTipoEmitente == value)return;
                 this._valueTipoEmitente = value; 
            } 
        } 

        public bool TipoEmitente_PrestadorServicoTransporte
         { 
            get { return this._valueTipoEmitente == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoEmitente.PrestadorServicoTransporte; } 
            set { if (value) this._valueTipoEmitente = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoEmitente.PrestadorServicoTransporte; }
         } 

        public bool TipoEmitente_TransportadorCargaPropria
         { 
            get { return this._valueTipoEmitente == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoEmitente.TransportadorCargaPropria; } 
            set { if (value) this._valueTipoEmitente = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoEmitente.TransportadorCargaPropria; }
         } 

       protected int _modeloManifestoOriginal{get;private set;}
       private int _modeloManifestoOriginalCommited{get; set;}
        private int _valueModeloManifesto;
         [Column("mdf_modelo_manifesto")]
        public virtual int ModeloManifesto
         { 
            get { return this._valueModeloManifesto; } 
            set 
            { 
                if (this._valueModeloManifesto == value)return;
                 this._valueModeloManifesto = value; 
            } 
        } 

       protected MDFeModalidadeTransporte _modalidadeTransporteOriginal{get;private set;}
       private MDFeModalidadeTransporte _modalidadeTransporteOriginalCommited{get; set;}
        private MDFeModalidadeTransporte _valueModalidadeTransporte;
         [Column("mdf_modalidade_transporte")]
        public virtual MDFeModalidadeTransporte ModalidadeTransporte
         { 
            get { return this._valueModalidadeTransporte; } 
            set 
            { 
                if (this._valueModalidadeTransporte == value)return;
                 this._valueModalidadeTransporte = value; 
            } 
        } 

        public bool ModalidadeTransporte_Rodoviario
         { 
            get { return this._valueModalidadeTransporte == IWTNFCompleto.BibliotecaEntidades.Base.MDFeModalidadeTransporte.Rodoviario; } 
            set { if (value) this._valueModalidadeTransporte = IWTNFCompleto.BibliotecaEntidades.Base.MDFeModalidadeTransporte.Rodoviario; }
         } 

        public bool ModalidadeTransporte_Aereo
         { 
            get { return this._valueModalidadeTransporte == IWTNFCompleto.BibliotecaEntidades.Base.MDFeModalidadeTransporte.Aereo; } 
            set { if (value) this._valueModalidadeTransporte = IWTNFCompleto.BibliotecaEntidades.Base.MDFeModalidadeTransporte.Aereo; }
         } 

        public bool ModalidadeTransporte_Aquaviario
         { 
            get { return this._valueModalidadeTransporte == IWTNFCompleto.BibliotecaEntidades.Base.MDFeModalidadeTransporte.Aquaviario; } 
            set { if (value) this._valueModalidadeTransporte = IWTNFCompleto.BibliotecaEntidades.Base.MDFeModalidadeTransporte.Aquaviario; }
         } 

        public bool ModalidadeTransporte_Ferroviario
         { 
            get { return this._valueModalidadeTransporte == IWTNFCompleto.BibliotecaEntidades.Base.MDFeModalidadeTransporte.Ferroviario; } 
            set { if (value) this._valueModalidadeTransporte = IWTNFCompleto.BibliotecaEntidades.Base.MDFeModalidadeTransporte.Ferroviario; }
         } 

       protected DateTime _dataEmissaoOriginal{get;private set;}
       private DateTime _dataEmissaoOriginalCommited{get; set;}
        private DateTime _valueDataEmissao;
         [Column("mdf_data_emissao")]
        public virtual DateTime DataEmissao
         { 
            get { return this._valueDataEmissao; } 
            set 
            { 
                if (this._valueDataEmissao == value)return;
                 this._valueDataEmissao = value; 
            } 
        } 

       protected MDFeFormaEmissao _formaEmissaoOriginal{get;private set;}
       private MDFeFormaEmissao _formaEmissaoOriginalCommited{get; set;}
        private MDFeFormaEmissao _valueFormaEmissao;
         [Column("mdf_forma_emissao")]
        public virtual MDFeFormaEmissao FormaEmissao
         { 
            get { return this._valueFormaEmissao; } 
            set 
            { 
                if (this._valueFormaEmissao == value)return;
                 this._valueFormaEmissao = value; 
            } 
        } 

        public bool FormaEmissao_Normal
         { 
            get { return this._valueFormaEmissao == IWTNFCompleto.BibliotecaEntidades.Base.MDFeFormaEmissao.Normal; } 
            set { if (value) this._valueFormaEmissao = IWTNFCompleto.BibliotecaEntidades.Base.MDFeFormaEmissao.Normal; }
         } 

        public bool FormaEmissao_Contingencia
         { 
            get { return this._valueFormaEmissao == IWTNFCompleto.BibliotecaEntidades.Base.MDFeFormaEmissao.Contingencia; } 
            set { if (value) this._valueFormaEmissao = IWTNFCompleto.BibliotecaEntidades.Base.MDFeFormaEmissao.Contingencia; }
         } 

       protected int _processoEmissaoOriginal{get;private set;}
       private int _processoEmissaoOriginalCommited{get; set;}
        private int _valueProcessoEmissao;
         [Column("mdf_processo_emissao")]
        public virtual int ProcessoEmissao
         { 
            get { return this._valueProcessoEmissao; } 
            set 
            { 
                if (this._valueProcessoEmissao == value)return;
                 this._valueProcessoEmissao = value; 
            } 
        } 

       protected string _versaoAplicativoOriginal{get;private set;}
       private string _versaoAplicativoOriginalCommited{get; set;}
        private string _valueVersaoAplicativo;
         [Column("mdf_versao_aplicativo")]
        public virtual string VersaoAplicativo
         { 
            get { return this._valueVersaoAplicativo; } 
            set 
            { 
                if (this._valueVersaoAplicativo == value)return;
                 this._valueVersaoAplicativo = value; 
            } 
        } 

       protected string _ufCarregamentoOriginal{get;private set;}
       private string _ufCarregamentoOriginalCommited{get; set;}
        private string _valueUfCarregamento;
         [Column("mdf_uf_carregamento")]
        public virtual string UfCarregamento
         { 
            get { return this._valueUfCarregamento; } 
            set 
            { 
                if (this._valueUfCarregamento == value)return;
                 this._valueUfCarregamento = value; 
            } 
        } 

       protected string _ufDescarregamentoOriginal{get;private set;}
       private string _ufDescarregamentoOriginalCommited{get; set;}
        private string _valueUfDescarregamento;
         [Column("mdf_uf_descarregamento")]
        public virtual string UfDescarregamento
         { 
            get { return this._valueUfDescarregamento; } 
            set 
            { 
                if (this._valueUfDescarregamento == value)return;
                 this._valueUfDescarregamento = value; 
            } 
        } 

       protected string _cnpjEmitenteOriginal{get;private set;}
       private string _cnpjEmitenteOriginalCommited{get; set;}
        private string _valueCnpjEmitente;
         [Column("mdf_cnpj_emitente")]
        public virtual string CnpjEmitente
         { 
            get { return this._valueCnpjEmitente; } 
            set 
            { 
                if (this._valueCnpjEmitente == value)return;
                 this._valueCnpjEmitente = value; 
            } 
        } 

       protected string _ieEmitenteOriginal{get;private set;}
       private string _ieEmitenteOriginalCommited{get; set;}
        private string _valueIeEmitente;
         [Column("mdf_ie_emitente")]
        public virtual string IeEmitente
         { 
            get { return this._valueIeEmitente; } 
            set 
            { 
                if (this._valueIeEmitente == value)return;
                 this._valueIeEmitente = value; 
            } 
        } 

       protected string _razaoEmitenteOriginal{get;private set;}
       private string _razaoEmitenteOriginalCommited{get; set;}
        private string _valueRazaoEmitente;
         [Column("mdf_razao_emitente")]
        public virtual string RazaoEmitente
         { 
            get { return this._valueRazaoEmitente; } 
            set 
            { 
                if (this._valueRazaoEmitente == value)return;
                 this._valueRazaoEmitente = value; 
            } 
        } 

       protected string _nomeFantasiaEmitenteOriginal{get;private set;}
       private string _nomeFantasiaEmitenteOriginalCommited{get; set;}
        private string _valueNomeFantasiaEmitente;
         [Column("mdf_nome_fantasia_emitente")]
        public virtual string NomeFantasiaEmitente
         { 
            get { return this._valueNomeFantasiaEmitente; } 
            set 
            { 
                if (this._valueNomeFantasiaEmitente == value)return;
                 this._valueNomeFantasiaEmitente = value; 
            } 
        } 

       protected string _logradouroEmitenteOriginal{get;private set;}
       private string _logradouroEmitenteOriginalCommited{get; set;}
        private string _valueLogradouroEmitente;
         [Column("mdf_logradouro_emitente")]
        public virtual string LogradouroEmitente
         { 
            get { return this._valueLogradouroEmitente; } 
            set 
            { 
                if (this._valueLogradouroEmitente == value)return;
                 this._valueLogradouroEmitente = value; 
            } 
        } 

       protected string _numeroEnderecoEmitenteOriginal{get;private set;}
       private string _numeroEnderecoEmitenteOriginalCommited{get; set;}
        private string _valueNumeroEnderecoEmitente;
         [Column("mdf_numero_endereco_emitente")]
        public virtual string NumeroEnderecoEmitente
         { 
            get { return this._valueNumeroEnderecoEmitente; } 
            set 
            { 
                if (this._valueNumeroEnderecoEmitente == value)return;
                 this._valueNumeroEnderecoEmitente = value; 
            } 
        } 

       protected string _complementoEnderecoEmitenteOriginal{get;private set;}
       private string _complementoEnderecoEmitenteOriginalCommited{get; set;}
        private string _valueComplementoEnderecoEmitente;
         [Column("mdf_complemento_endereco_emitente")]
        public virtual string ComplementoEnderecoEmitente
         { 
            get { return this._valueComplementoEnderecoEmitente; } 
            set 
            { 
                if (this._valueComplementoEnderecoEmitente == value)return;
                 this._valueComplementoEnderecoEmitente = value; 
            } 
        } 

       protected string _bairroEmitenteOriginal{get;private set;}
       private string _bairroEmitenteOriginalCommited{get; set;}
        private string _valueBairroEmitente;
         [Column("mdf_bairro_emitente")]
        public virtual string BairroEmitente
         { 
            get { return this._valueBairroEmitente; } 
            set 
            { 
                if (this._valueBairroEmitente == value)return;
                 this._valueBairroEmitente = value; 
            } 
        } 

       protected int _codigoIbgeMunicipioEmitenteOriginal{get;private set;}
       private int _codigoIbgeMunicipioEmitenteOriginalCommited{get; set;}
        private int _valueCodigoIbgeMunicipioEmitente;
         [Column("mdf_codigo_ibge_municipio_emitente")]
        public virtual int CodigoIbgeMunicipioEmitente
         { 
            get { return this._valueCodigoIbgeMunicipioEmitente; } 
            set 
            { 
                if (this._valueCodigoIbgeMunicipioEmitente == value)return;
                 this._valueCodigoIbgeMunicipioEmitente = value; 
            } 
        } 

       protected string _municipioEmitenteOriginal{get;private set;}
       private string _municipioEmitenteOriginalCommited{get; set;}
        private string _valueMunicipioEmitente;
         [Column("mdf_municipio_emitente")]
        public virtual string MunicipioEmitente
         { 
            get { return this._valueMunicipioEmitente; } 
            set 
            { 
                if (this._valueMunicipioEmitente == value)return;
                 this._valueMunicipioEmitente = value; 
            } 
        } 

       protected int? _cepEmitenteOriginal{get;private set;}
       private int? _cepEmitenteOriginalCommited{get; set;}
        private int? _valueCepEmitente;
         [Column("mdf_cep_emitente")]
        public virtual int? CepEmitente
         { 
            get { return this._valueCepEmitente; } 
            set 
            { 
                if (this._valueCepEmitente == value)return;
                 this._valueCepEmitente = value; 
            } 
        } 

       protected string _ufEmitenteOriginal{get;private set;}
       private string _ufEmitenteOriginalCommited{get; set;}
        private string _valueUfEmitente;
         [Column("mdf_uf_emitente")]
        public virtual string UfEmitente
         { 
            get { return this._valueUfEmitente; } 
            set 
            { 
                if (this._valueUfEmitente == value)return;
                 this._valueUfEmitente = value; 
            } 
        } 

       protected int? _telefoneEmitenteOriginal{get;private set;}
       private int? _telefoneEmitenteOriginalCommited{get; set;}
        private int? _valueTelefoneEmitente;
         [Column("mdf_telefone_emitente")]
        public virtual int? TelefoneEmitente
         { 
            get { return this._valueTelefoneEmitente; } 
            set 
            { 
                if (this._valueTelefoneEmitente == value)return;
                 this._valueTelefoneEmitente = value; 
            } 
        } 

       protected string _emailEmitenteOriginal{get;private set;}
       private string _emailEmitenteOriginalCommited{get; set;}
        private string _valueEmailEmitente;
         [Column("mdf_email_emitente")]
        public virtual string EmailEmitente
         { 
            get { return this._valueEmailEmitente; } 
            set 
            { 
                if (this._valueEmailEmitente == value)return;
                 this._valueEmailEmitente = value; 
            } 
        } 

       protected int? _qtdNfeOriginal{get;private set;}
       private int? _qtdNfeOriginalCommited{get; set;}
        private int? _valueQtdNfe;
         [Column("mdf_qtd_nfe")]
        public virtual int? QtdNfe
         { 
            get { return this._valueQtdNfe; } 
            set 
            { 
                if (this._valueQtdNfe == value)return;
                 this._valueQtdNfe = value; 
            } 
        } 

       protected double _valorTotalMercadoriaOriginal{get;private set;}
       private double _valorTotalMercadoriaOriginalCommited{get; set;}
        private double _valueValorTotalMercadoria;
         [Column("mdf_valor_total_mercadoria")]
        public virtual double ValorTotalMercadoria
         { 
            get { return this._valueValorTotalMercadoria; } 
            set 
            { 
                if (this._valueValorTotalMercadoria == value)return;
                 this._valueValorTotalMercadoria = value; 
            } 
        } 

       protected MDFeUnidadeMedidaPeso _unidadeMedidaPesoCargaOriginal{get;private set;}
       private MDFeUnidadeMedidaPeso _unidadeMedidaPesoCargaOriginalCommited{get; set;}
        private MDFeUnidadeMedidaPeso _valueUnidadeMedidaPesoCarga;
         [Column("mdf_unidade_medida_peso_carga")]
        public virtual MDFeUnidadeMedidaPeso UnidadeMedidaPesoCarga
         { 
            get { return this._valueUnidadeMedidaPesoCarga; } 
            set 
            { 
                if (this._valueUnidadeMedidaPesoCarga == value)return;
                 this._valueUnidadeMedidaPesoCarga = value; 
            } 
        } 

        public bool UnidadeMedidaPesoCarga_KG
         { 
            get { return this._valueUnidadeMedidaPesoCarga == IWTNFCompleto.BibliotecaEntidades.Base.MDFeUnidadeMedidaPeso.KG; } 
            set { if (value) this._valueUnidadeMedidaPesoCarga = IWTNFCompleto.BibliotecaEntidades.Base.MDFeUnidadeMedidaPeso.KG; }
         } 

        public bool UnidadeMedidaPesoCarga_TON
         { 
            get { return this._valueUnidadeMedidaPesoCarga == IWTNFCompleto.BibliotecaEntidades.Base.MDFeUnidadeMedidaPeso.TON; } 
            set { if (value) this._valueUnidadeMedidaPesoCarga = IWTNFCompleto.BibliotecaEntidades.Base.MDFeUnidadeMedidaPeso.TON; }
         } 

       protected double _pesoBrutoCargaOriginal{get;private set;}
       private double _pesoBrutoCargaOriginalCommited{get; set;}
        private double _valuePesoBrutoCarga;
         [Column("mdf_peso_bruto_carga")]
        public virtual double PesoBrutoCarga
         { 
            get { return this._valuePesoBrutoCarga; } 
            set 
            { 
                if (this._valuePesoBrutoCarga == value)return;
                 this._valuePesoBrutoCarga = value; 
            } 
        } 

       protected string _infoAddicionalFiscoOriginal{get;private set;}
       private string _infoAddicionalFiscoOriginalCommited{get; set;}
        private string _valueInfoAddicionalFisco;
         [Column("mdf_info_addicional_fisco")]
        public virtual string InfoAddicionalFisco
         { 
            get { return this._valueInfoAddicionalFisco; } 
            set 
            { 
                if (this._valueInfoAddicionalFisco == value)return;
                 this._valueInfoAddicionalFisco = value; 
            } 
        } 

       protected string _infoAdicionalContribuinteOriginal{get;private set;}
       private string _infoAdicionalContribuinteOriginalCommited{get; set;}
        private string _valueInfoAdicionalContribuinte;
         [Column("mdf_info_adicional_contribuinte")]
        public virtual string InfoAdicionalContribuinte
         { 
            get { return this._valueInfoAdicionalContribuinte; } 
            set 
            { 
                if (this._valueInfoAdicionalContribuinte == value)return;
                 this._valueInfoAdicionalContribuinte = value; 
            } 
        } 

       protected DateTime? _dataHoraInicioViagemOriginal{get;private set;}
       private DateTime? _dataHoraInicioViagemOriginalCommited{get; set;}
        private DateTime? _valueDataHoraInicioViagem;
         [Column("mdf_data_hora_inicio_viagem")]
        public virtual DateTime? DataHoraInicioViagem
         { 
            get { return this._valueDataHoraInicioViagem; } 
            set 
            { 
                if (this._valueDataHoraInicioViagem == value)return;
                 this._valueDataHoraInicioViagem = value; 
            } 
        } 

       protected bool _enviarReceitaOriginal{get;private set;}
       private bool _enviarReceitaOriginalCommited{get; set;}
        private bool _valueEnviarReceita;
         [Column("mdf_enviar_receita")]
        public virtual bool EnviarReceita
         { 
            get { return this._valueEnviarReceita; } 
            set 
            { 
                if (this._valueEnviarReceita == value)return;
                 this._valueEnviarReceita = value; 
            } 
        } 

       private List<long> _collectionMdfeLacreClassMdfeOriginal;
       private List<Entidades.MdfeLacreClass > _collectionMdfeLacreClassMdfeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeLacreClassMdfeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeLacreClassMdfeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeLacreClassMdfeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfeLacreClass> _valueCollectionMdfeLacreClassMdfe { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfeLacreClass> CollectionMdfeLacreClassMdfe 
       { 
           get { if(!_valueCollectionMdfeLacreClassMdfeLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfeLacreClassMdfe();}
return this._valueCollectionMdfeLacreClassMdfe; } 
           set 
           { 
               this._valueCollectionMdfeLacreClassMdfe = value; 
               this._valueCollectionMdfeLacreClassMdfeLoaded = true; 
           } 
       } 

       private List<long> _collectionMdfeModalRodoviarioClassMdfeOriginal;
       private List<Entidades.MdfeModalRodoviarioClass > _collectionMdfeModalRodoviarioClassMdfeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeModalRodoviarioClassMdfeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeModalRodoviarioClassMdfeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeModalRodoviarioClassMdfeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfeModalRodoviarioClass> _valueCollectionMdfeModalRodoviarioClassMdfe { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfeModalRodoviarioClass> CollectionMdfeModalRodoviarioClassMdfe 
       { 
           get { if(!_valueCollectionMdfeModalRodoviarioClassMdfeLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfeModalRodoviarioClassMdfe();}
return this._valueCollectionMdfeModalRodoviarioClassMdfe; } 
           set 
           { 
               this._valueCollectionMdfeModalRodoviarioClassMdfe = value; 
               this._valueCollectionMdfeModalRodoviarioClassMdfeLoaded = true; 
           } 
       } 

       private List<long> _collectionMdfeMunicipioCarregamentoClassMdfeOriginal;
       private List<Entidades.MdfeMunicipioCarregamentoClass > _collectionMdfeMunicipioCarregamentoClassMdfeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeMunicipioCarregamentoClassMdfeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeMunicipioCarregamentoClassMdfeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfeMunicipioCarregamentoClass> _valueCollectionMdfeMunicipioCarregamentoClassMdfe { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfeMunicipioCarregamentoClass> CollectionMdfeMunicipioCarregamentoClassMdfe 
       { 
           get { if(!_valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfeMunicipioCarregamentoClassMdfe();}
return this._valueCollectionMdfeMunicipioCarregamentoClassMdfe; } 
           set 
           { 
               this._valueCollectionMdfeMunicipioCarregamentoClassMdfe = value; 
               this._valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded = true; 
           } 
       } 

       private List<long> _collectionMdfeMunicipioDescarregamentoClassMdfeOriginal;
       private List<Entidades.MdfeMunicipioDescarregamentoClass > _collectionMdfeMunicipioDescarregamentoClassMdfeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeMunicipioDescarregamentoClassMdfeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeMunicipioDescarregamentoClassMdfeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfeMunicipioDescarregamentoClass> _valueCollectionMdfeMunicipioDescarregamentoClassMdfe { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfeMunicipioDescarregamentoClass> CollectionMdfeMunicipioDescarregamentoClassMdfe 
       { 
           get { if(!_valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfeMunicipioDescarregamentoClassMdfe();}
return this._valueCollectionMdfeMunicipioDescarregamentoClassMdfe; } 
           set 
           { 
               this._valueCollectionMdfeMunicipioDescarregamentoClassMdfe = value; 
               this._valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded = true; 
           } 
       } 

       private List<long> _collectionMdfeNfeClassMdfeOriginal;
       private List<Entidades.MdfeNfeClass > _collectionMdfeNfeClassMdfeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeNfeClassMdfeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeNfeClassMdfeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeNfeClassMdfeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfeNfeClass> _valueCollectionMdfeNfeClassMdfe { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfeNfeClass> CollectionMdfeNfeClassMdfe 
       { 
           get { if(!_valueCollectionMdfeNfeClassMdfeLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfeNfeClassMdfe();}
return this._valueCollectionMdfeNfeClassMdfe; } 
           set 
           { 
               this._valueCollectionMdfeNfeClassMdfe = value; 
               this._valueCollectionMdfeNfeClassMdfeLoaded = true; 
           } 
       } 

       private List<long> _collectionMdfePercursoClassMdfeOriginal;
       private List<Entidades.MdfePercursoClass > _collectionMdfePercursoClassMdfeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfePercursoClassMdfeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfePercursoClassMdfeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfePercursoClassMdfeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfePercursoClass> _valueCollectionMdfePercursoClassMdfe { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfePercursoClass> CollectionMdfePercursoClassMdfe 
       { 
           get { if(!_valueCollectionMdfePercursoClassMdfeLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfePercursoClassMdfe();}
return this._valueCollectionMdfePercursoClassMdfe; } 
           set 
           { 
               this._valueCollectionMdfePercursoClassMdfe = value; 
               this._valueCollectionMdfePercursoClassMdfeLoaded = true; 
           } 
       } 

        public MdfeBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ModeloManifesto = 58;
           this.EnviarReceita = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static MdfeClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MdfeClass) GetEntity(typeof(MdfeClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionMdfeLacreClassMdfeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfeLacreClassMdfeChanged = true;
                  _valueCollectionMdfeLacreClassMdfeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfeLacreClassMdfeChanged = true; 
                  _valueCollectionMdfeLacreClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeLacreClass item in e.OldItems) 
                 { 
                     _collectionMdfeLacreClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfeLacreClassMdfeChanged = true; 
                  _valueCollectionMdfeLacreClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeLacreClass item in _valueCollectionMdfeLacreClassMdfe) 
                 { 
                     _collectionMdfeLacreClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfeLacreClassMdfe()
         {
            try
            {
                 ObservableCollection<Entidades.MdfeLacreClass> oc;
                _valueCollectionMdfeLacreClassMdfeChanged = false;
                 _valueCollectionMdfeLacreClassMdfeCommitedChanged = false;
                _collectionMdfeLacreClassMdfeRemovidos = new List<Entidades.MdfeLacreClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfeLacreClass>();
                }
                else{ 
                   Entidades.MdfeLacreClass search = new Entidades.MdfeLacreClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfeLacreClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Mdfe", this),                     }                       ).Cast<Entidades.MdfeLacreClass>().ToList());
                 }
                 _valueCollectionMdfeLacreClassMdfe = new BindingList<Entidades.MdfeLacreClass>(oc); 
                 _collectionMdfeLacreClassMdfeOriginal= (from a in _valueCollectionMdfeLacreClassMdfe select a.ID).ToList();
                 _valueCollectionMdfeLacreClassMdfeLoaded = true;
                 oc.CollectionChanged += CollectionMdfeLacreClassMdfeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfeLacreClassMdfe+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMdfeModalRodoviarioClassMdfeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfeModalRodoviarioClassMdfeChanged = true;
                  _valueCollectionMdfeModalRodoviarioClassMdfeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfeModalRodoviarioClassMdfeChanged = true; 
                  _valueCollectionMdfeModalRodoviarioClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeModalRodoviarioClass item in e.OldItems) 
                 { 
                     _collectionMdfeModalRodoviarioClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfeModalRodoviarioClassMdfeChanged = true; 
                  _valueCollectionMdfeModalRodoviarioClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeModalRodoviarioClass item in _valueCollectionMdfeModalRodoviarioClassMdfe) 
                 { 
                     _collectionMdfeModalRodoviarioClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfeModalRodoviarioClassMdfe()
         {
            try
            {
                 ObservableCollection<Entidades.MdfeModalRodoviarioClass> oc;
                _valueCollectionMdfeModalRodoviarioClassMdfeChanged = false;
                 _valueCollectionMdfeModalRodoviarioClassMdfeCommitedChanged = false;
                _collectionMdfeModalRodoviarioClassMdfeRemovidos = new List<Entidades.MdfeModalRodoviarioClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfeModalRodoviarioClass>();
                }
                else{ 
                   Entidades.MdfeModalRodoviarioClass search = new Entidades.MdfeModalRodoviarioClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfeModalRodoviarioClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Mdfe", this),                     }                       ).Cast<Entidades.MdfeModalRodoviarioClass>().ToList());
                 }
                 _valueCollectionMdfeModalRodoviarioClassMdfe = new BindingList<Entidades.MdfeModalRodoviarioClass>(oc); 
                 _collectionMdfeModalRodoviarioClassMdfeOriginal= (from a in _valueCollectionMdfeModalRodoviarioClassMdfe select a.ID).ToList();
                 _valueCollectionMdfeModalRodoviarioClassMdfeLoaded = true;
                 oc.CollectionChanged += CollectionMdfeModalRodoviarioClassMdfeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfeModalRodoviarioClassMdfe+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMdfeMunicipioCarregamentoClassMdfeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfeMunicipioCarregamentoClassMdfeChanged = true;
                  _valueCollectionMdfeMunicipioCarregamentoClassMdfeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfeMunicipioCarregamentoClassMdfeChanged = true; 
                  _valueCollectionMdfeMunicipioCarregamentoClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeMunicipioCarregamentoClass item in e.OldItems) 
                 { 
                     _collectionMdfeMunicipioCarregamentoClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfeMunicipioCarregamentoClassMdfeChanged = true; 
                  _valueCollectionMdfeMunicipioCarregamentoClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeMunicipioCarregamentoClass item in _valueCollectionMdfeMunicipioCarregamentoClassMdfe) 
                 { 
                     _collectionMdfeMunicipioCarregamentoClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfeMunicipioCarregamentoClassMdfe()
         {
            try
            {
                 ObservableCollection<Entidades.MdfeMunicipioCarregamentoClass> oc;
                _valueCollectionMdfeMunicipioCarregamentoClassMdfeChanged = false;
                 _valueCollectionMdfeMunicipioCarregamentoClassMdfeCommitedChanged = false;
                _collectionMdfeMunicipioCarregamentoClassMdfeRemovidos = new List<Entidades.MdfeMunicipioCarregamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfeMunicipioCarregamentoClass>();
                }
                else{ 
                   Entidades.MdfeMunicipioCarregamentoClass search = new Entidades.MdfeMunicipioCarregamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfeMunicipioCarregamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Mdfe", this),                     }                       ).Cast<Entidades.MdfeMunicipioCarregamentoClass>().ToList());
                 }
                 _valueCollectionMdfeMunicipioCarregamentoClassMdfe = new BindingList<Entidades.MdfeMunicipioCarregamentoClass>(oc); 
                 _collectionMdfeMunicipioCarregamentoClassMdfeOriginal= (from a in _valueCollectionMdfeMunicipioCarregamentoClassMdfe select a.ID).ToList();
                 _valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded = true;
                 oc.CollectionChanged += CollectionMdfeMunicipioCarregamentoClassMdfeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfeMunicipioCarregamentoClassMdfe+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMdfeMunicipioDescarregamentoClassMdfeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfeMunicipioDescarregamentoClassMdfeChanged = true;
                  _valueCollectionMdfeMunicipioDescarregamentoClassMdfeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfeMunicipioDescarregamentoClassMdfeChanged = true; 
                  _valueCollectionMdfeMunicipioDescarregamentoClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeMunicipioDescarregamentoClass item in e.OldItems) 
                 { 
                     _collectionMdfeMunicipioDescarregamentoClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfeMunicipioDescarregamentoClassMdfeChanged = true; 
                  _valueCollectionMdfeMunicipioDescarregamentoClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeMunicipioDescarregamentoClass item in _valueCollectionMdfeMunicipioDescarregamentoClassMdfe) 
                 { 
                     _collectionMdfeMunicipioDescarregamentoClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfeMunicipioDescarregamentoClassMdfe()
         {
            try
            {
                 ObservableCollection<Entidades.MdfeMunicipioDescarregamentoClass> oc;
                _valueCollectionMdfeMunicipioDescarregamentoClassMdfeChanged = false;
                 _valueCollectionMdfeMunicipioDescarregamentoClassMdfeCommitedChanged = false;
                _collectionMdfeMunicipioDescarregamentoClassMdfeRemovidos = new List<Entidades.MdfeMunicipioDescarregamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfeMunicipioDescarregamentoClass>();
                }
                else{ 
                   Entidades.MdfeMunicipioDescarregamentoClass search = new Entidades.MdfeMunicipioDescarregamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfeMunicipioDescarregamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Mdfe", this),                     }                       ).Cast<Entidades.MdfeMunicipioDescarregamentoClass>().ToList());
                 }
                 _valueCollectionMdfeMunicipioDescarregamentoClassMdfe = new BindingList<Entidades.MdfeMunicipioDescarregamentoClass>(oc); 
                 _collectionMdfeMunicipioDescarregamentoClassMdfeOriginal= (from a in _valueCollectionMdfeMunicipioDescarregamentoClassMdfe select a.ID).ToList();
                 _valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded = true;
                 oc.CollectionChanged += CollectionMdfeMunicipioDescarregamentoClassMdfeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfeMunicipioDescarregamentoClassMdfe+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMdfeNfeClassMdfeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfeNfeClassMdfeChanged = true;
                  _valueCollectionMdfeNfeClassMdfeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfeNfeClassMdfeChanged = true; 
                  _valueCollectionMdfeNfeClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeNfeClass item in e.OldItems) 
                 { 
                     _collectionMdfeNfeClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfeNfeClassMdfeChanged = true; 
                  _valueCollectionMdfeNfeClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfeNfeClass item in _valueCollectionMdfeNfeClassMdfe) 
                 { 
                     _collectionMdfeNfeClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfeNfeClassMdfe()
         {
            try
            {
                 ObservableCollection<Entidades.MdfeNfeClass> oc;
                _valueCollectionMdfeNfeClassMdfeChanged = false;
                 _valueCollectionMdfeNfeClassMdfeCommitedChanged = false;
                _collectionMdfeNfeClassMdfeRemovidos = new List<Entidades.MdfeNfeClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfeNfeClass>();
                }
                else{ 
                   Entidades.MdfeNfeClass search = new Entidades.MdfeNfeClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfeNfeClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Mdfe", this),                     }                       ).Cast<Entidades.MdfeNfeClass>().ToList());
                 }
                 _valueCollectionMdfeNfeClassMdfe = new BindingList<Entidades.MdfeNfeClass>(oc); 
                 _collectionMdfeNfeClassMdfeOriginal= (from a in _valueCollectionMdfeNfeClassMdfe select a.ID).ToList();
                 _valueCollectionMdfeNfeClassMdfeLoaded = true;
                 oc.CollectionChanged += CollectionMdfeNfeClassMdfeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfeNfeClassMdfe+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMdfePercursoClassMdfeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfePercursoClassMdfeChanged = true;
                  _valueCollectionMdfePercursoClassMdfeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfePercursoClassMdfeChanged = true; 
                  _valueCollectionMdfePercursoClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfePercursoClass item in e.OldItems) 
                 { 
                     _collectionMdfePercursoClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfePercursoClassMdfeChanged = true; 
                  _valueCollectionMdfePercursoClassMdfeCommitedChanged = true;
                 foreach (Entidades.MdfePercursoClass item in _valueCollectionMdfePercursoClassMdfe) 
                 { 
                     _collectionMdfePercursoClassMdfeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfePercursoClassMdfe()
         {
            try
            {
                 ObservableCollection<Entidades.MdfePercursoClass> oc;
                _valueCollectionMdfePercursoClassMdfeChanged = false;
                 _valueCollectionMdfePercursoClassMdfeCommitedChanged = false;
                _collectionMdfePercursoClassMdfeRemovidos = new List<Entidades.MdfePercursoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfePercursoClass>();
                }
                else{ 
                   Entidades.MdfePercursoClass search = new Entidades.MdfePercursoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfePercursoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Mdfe", this),                     }                       ).Cast<Entidades.MdfePercursoClass>().ToList());
                 }
                 _valueCollectionMdfePercursoClassMdfe = new BindingList<Entidades.MdfePercursoClass>(oc); 
                 _collectionMdfePercursoClassMdfeOriginal= (from a in _valueCollectionMdfePercursoClassMdfe select a.ID).ToList();
                 _valueCollectionMdfePercursoClassMdfeLoaded = true;
                 oc.CollectionChanged += CollectionMdfePercursoClassMdfeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfePercursoClassMdfe+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(ChaveAcesso))
                {
                    throw new Exception(ErroChaveAcessoObrigatorio);
                }
                if (ChaveAcesso.Length >48)
                {
                    throw new Exception( ErroChaveAcessoComprimento);
                }
                if (string.IsNullOrEmpty(Versao))
                {
                    throw new Exception(ErroVersaoObrigatorio);
                }
                if (Versao.Length >10)
                {
                    throw new Exception( ErroVersaoComprimento);
                }
                if (string.IsNullOrEmpty(VersaoAplicativo))
                {
                    throw new Exception(ErroVersaoAplicativoObrigatorio);
                }
                if (VersaoAplicativo.Length >20)
                {
                    throw new Exception( ErroVersaoAplicativoComprimento);
                }
                if (string.IsNullOrEmpty(UfCarregamento))
                {
                    throw new Exception(ErroUfCarregamentoObrigatorio);
                }
                if (UfCarregamento.Length >2)
                {
                    throw new Exception( ErroUfCarregamentoComprimento);
                }
                if (string.IsNullOrEmpty(UfDescarregamento))
                {
                    throw new Exception(ErroUfDescarregamentoObrigatorio);
                }
                if (UfDescarregamento.Length >2)
                {
                    throw new Exception( ErroUfDescarregamentoComprimento);
                }
                if (string.IsNullOrEmpty(CnpjEmitente))
                {
                    throw new Exception(ErroCnpjEmitenteObrigatorio);
                }
                if (CnpjEmitente.Length >14)
                {
                    throw new Exception( ErroCnpjEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(IeEmitente))
                {
                    throw new Exception(ErroIeEmitenteObrigatorio);
                }
                if (IeEmitente.Length >14)
                {
                    throw new Exception( ErroIeEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(RazaoEmitente))
                {
                    throw new Exception(ErroRazaoEmitenteObrigatorio);
                }
                if (RazaoEmitente.Length >60)
                {
                    throw new Exception( ErroRazaoEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(LogradouroEmitente))
                {
                    throw new Exception(ErroLogradouroEmitenteObrigatorio);
                }
                if (LogradouroEmitente.Length >60)
                {
                    throw new Exception( ErroLogradouroEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(NumeroEnderecoEmitente))
                {
                    throw new Exception(ErroNumeroEnderecoEmitenteObrigatorio);
                }
                if (NumeroEnderecoEmitente.Length >60)
                {
                    throw new Exception( ErroNumeroEnderecoEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(BairroEmitente))
                {
                    throw new Exception(ErroBairroEmitenteObrigatorio);
                }
                if (BairroEmitente.Length >60)
                {
                    throw new Exception( ErroBairroEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(MunicipioEmitente))
                {
                    throw new Exception(ErroMunicipioEmitenteObrigatorio);
                }
                if (MunicipioEmitente.Length >60)
                {
                    throw new Exception( ErroMunicipioEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(UfEmitente))
                {
                    throw new Exception(ErroUfEmitenteObrigatorio);
                }
                if (UfEmitente.Length >2)
                {
                    throw new Exception( ErroUfEmitenteComprimento);
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
                    "  public.mdfe  " +
                    "WHERE " +
                    "  id_mdfe = :id";
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
                        "  public.mdfe   " +
                        "SET  " + 
                        "  mdf_numero = :mdf_numero, " + 
                        "  mdf_serie = :mdf_serie, " + 
                        "  mdf_codigo = :mdf_codigo, " + 
                        "  mdf_chave_acesso = :mdf_chave_acesso, " + 
                        "  mdf_dv_chave_acesso = :mdf_dv_chave_acesso, " + 
                        "  mdf_versao = :mdf_versao, " + 
                        "  mdf_cod_ibge_uf_emitente = :mdf_cod_ibge_uf_emitente, " + 
                        "  mdf_tipo_ambiente = :mdf_tipo_ambiente, " + 
                        "  mdf_tipo_emitente = :mdf_tipo_emitente, " + 
                        "  mdf_modelo_manifesto = :mdf_modelo_manifesto, " + 
                        "  mdf_modalidade_transporte = :mdf_modalidade_transporte, " + 
                        "  mdf_data_emissao = :mdf_data_emissao, " + 
                        "  mdf_forma_emissao = :mdf_forma_emissao, " + 
                        "  mdf_processo_emissao = :mdf_processo_emissao, " + 
                        "  mdf_versao_aplicativo = :mdf_versao_aplicativo, " + 
                        "  mdf_uf_carregamento = :mdf_uf_carregamento, " + 
                        "  mdf_uf_descarregamento = :mdf_uf_descarregamento, " + 
                        "  mdf_cnpj_emitente = :mdf_cnpj_emitente, " + 
                        "  mdf_ie_emitente = :mdf_ie_emitente, " + 
                        "  mdf_razao_emitente = :mdf_razao_emitente, " + 
                        "  mdf_nome_fantasia_emitente = :mdf_nome_fantasia_emitente, " + 
                        "  mdf_logradouro_emitente = :mdf_logradouro_emitente, " + 
                        "  mdf_numero_endereco_emitente = :mdf_numero_endereco_emitente, " + 
                        "  mdf_complemento_endereco_emitente = :mdf_complemento_endereco_emitente, " + 
                        "  mdf_bairro_emitente = :mdf_bairro_emitente, " + 
                        "  mdf_codigo_ibge_municipio_emitente = :mdf_codigo_ibge_municipio_emitente, " + 
                        "  mdf_municipio_emitente = :mdf_municipio_emitente, " + 
                        "  mdf_cep_emitente = :mdf_cep_emitente, " + 
                        "  mdf_uf_emitente = :mdf_uf_emitente, " + 
                        "  mdf_telefone_emitente = :mdf_telefone_emitente, " + 
                        "  mdf_email_emitente = :mdf_email_emitente, " + 
                        "  mdf_qtd_nfe = :mdf_qtd_nfe, " + 
                        "  mdf_valor_total_mercadoria = :mdf_valor_total_mercadoria, " + 
                        "  mdf_unidade_medida_peso_carga = :mdf_unidade_medida_peso_carga, " + 
                        "  mdf_peso_bruto_carga = :mdf_peso_bruto_carga, " + 
                        "  mdf_info_addicional_fisco = :mdf_info_addicional_fisco, " + 
                        "  mdf_info_adicional_contribuinte = :mdf_info_adicional_contribuinte, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  mdf_data_hora_inicio_viagem = :mdf_data_hora_inicio_viagem, " + 
                        "  mdf_enviar_receita = :mdf_enviar_receita "+
                        "WHERE  " +
                        "  id_mdfe = :id " +
                        "RETURNING id_mdfe;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.mdfe " +
                        "( " +
                        "  mdf_numero , " + 
                        "  mdf_serie , " + 
                        "  mdf_codigo , " + 
                        "  mdf_chave_acesso , " + 
                        "  mdf_dv_chave_acesso , " + 
                        "  mdf_versao , " + 
                        "  mdf_cod_ibge_uf_emitente , " + 
                        "  mdf_tipo_ambiente , " + 
                        "  mdf_tipo_emitente , " + 
                        "  mdf_modelo_manifesto , " + 
                        "  mdf_modalidade_transporte , " + 
                        "  mdf_data_emissao , " + 
                        "  mdf_forma_emissao , " + 
                        "  mdf_processo_emissao , " + 
                        "  mdf_versao_aplicativo , " + 
                        "  mdf_uf_carregamento , " + 
                        "  mdf_uf_descarregamento , " + 
                        "  mdf_cnpj_emitente , " + 
                        "  mdf_ie_emitente , " + 
                        "  mdf_razao_emitente , " + 
                        "  mdf_nome_fantasia_emitente , " + 
                        "  mdf_logradouro_emitente , " + 
                        "  mdf_numero_endereco_emitente , " + 
                        "  mdf_complemento_endereco_emitente , " + 
                        "  mdf_bairro_emitente , " + 
                        "  mdf_codigo_ibge_municipio_emitente , " + 
                        "  mdf_municipio_emitente , " + 
                        "  mdf_cep_emitente , " + 
                        "  mdf_uf_emitente , " + 
                        "  mdf_telefone_emitente , " + 
                        "  mdf_email_emitente , " + 
                        "  mdf_qtd_nfe , " + 
                        "  mdf_valor_total_mercadoria , " + 
                        "  mdf_unidade_medida_peso_carga , " + 
                        "  mdf_peso_bruto_carga , " + 
                        "  mdf_info_addicional_fisco , " + 
                        "  mdf_info_adicional_contribuinte , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  mdf_data_hora_inicio_viagem , " + 
                        "  mdf_enviar_receita  "+
                        ")  " +
                        "VALUES ( " +
                        "  :mdf_numero , " + 
                        "  :mdf_serie , " + 
                        "  :mdf_codigo , " + 
                        "  :mdf_chave_acesso , " + 
                        "  :mdf_dv_chave_acesso , " + 
                        "  :mdf_versao , " + 
                        "  :mdf_cod_ibge_uf_emitente , " + 
                        "  :mdf_tipo_ambiente , " + 
                        "  :mdf_tipo_emitente , " + 
                        "  :mdf_modelo_manifesto , " + 
                        "  :mdf_modalidade_transporte , " + 
                        "  :mdf_data_emissao , " + 
                        "  :mdf_forma_emissao , " + 
                        "  :mdf_processo_emissao , " + 
                        "  :mdf_versao_aplicativo , " + 
                        "  :mdf_uf_carregamento , " + 
                        "  :mdf_uf_descarregamento , " + 
                        "  :mdf_cnpj_emitente , " + 
                        "  :mdf_ie_emitente , " + 
                        "  :mdf_razao_emitente , " + 
                        "  :mdf_nome_fantasia_emitente , " + 
                        "  :mdf_logradouro_emitente , " + 
                        "  :mdf_numero_endereco_emitente , " + 
                        "  :mdf_complemento_endereco_emitente , " + 
                        "  :mdf_bairro_emitente , " + 
                        "  :mdf_codigo_ibge_municipio_emitente , " + 
                        "  :mdf_municipio_emitente , " + 
                        "  :mdf_cep_emitente , " + 
                        "  :mdf_uf_emitente , " + 
                        "  :mdf_telefone_emitente , " + 
                        "  :mdf_email_emitente , " + 
                        "  :mdf_qtd_nfe , " + 
                        "  :mdf_valor_total_mercadoria , " + 
                        "  :mdf_unidade_medida_peso_carga , " + 
                        "  :mdf_peso_bruto_carga , " + 
                        "  :mdf_info_addicional_fisco , " + 
                        "  :mdf_info_adicional_contribuinte , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :mdf_data_hora_inicio_viagem , " + 
                        "  :mdf_enviar_receita  "+
                        ")RETURNING id_mdfe;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Serie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_codigo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_chave_acesso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ChaveAcesso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_dv_chave_acesso", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DvChaveAcesso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_versao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Versao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_cod_ibge_uf_emitente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodIbgeUfEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_tipo_ambiente", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoAmbiente);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_tipo_emitente", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoEmitente);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_modelo_manifesto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ModeloManifesto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_modalidade_transporte", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ModalidadeTransporte);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_data_emissao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_forma_emissao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.FormaEmissao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_processo_emissao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProcessoEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_versao_aplicativo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoAplicativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_uf_carregamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfCarregamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_uf_descarregamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfDescarregamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_cnpj_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_ie_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IeEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_razao_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RazaoEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_nome_fantasia_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeFantasiaEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_logradouro_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LogradouroEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_numero_endereco_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroEnderecoEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_complemento_endereco_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ComplementoEnderecoEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_bairro_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BairroEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_codigo_ibge_municipio_emitente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoIbgeMunicipioEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_municipio_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MunicipioEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_cep_emitente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CepEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_uf_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_telefone_emitente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TelefoneEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_email_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_qtd_nfe", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdNfe ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_valor_total_mercadoria", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalMercadoria ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_unidade_medida_peso_carga", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.UnidadeMedidaPesoCarga);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_peso_bruto_carga", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PesoBrutoCarga ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_info_addicional_fisco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InfoAddicionalFisco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_info_adicional_contribuinte", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InfoAdicionalContribuinte ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_data_hora_inicio_viagem", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataHoraInicioViagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdf_enviar_receita", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnviarReceita ?? DBNull.Value;

 
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
 if (CollectionMdfeLacreClassMdfe.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfeLacreClassMdfe+"\r\n";
                foreach (Entidades.MdfeLacreClass tmp in CollectionMdfeLacreClassMdfe)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMdfeModalRodoviarioClassMdfe.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfeModalRodoviarioClassMdfe+"\r\n";
                foreach (Entidades.MdfeModalRodoviarioClass tmp in CollectionMdfeModalRodoviarioClassMdfe)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMdfeMunicipioCarregamentoClassMdfe.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfeMunicipioCarregamentoClassMdfe+"\r\n";
                foreach (Entidades.MdfeMunicipioCarregamentoClass tmp in CollectionMdfeMunicipioCarregamentoClassMdfe)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMdfeMunicipioDescarregamentoClassMdfe.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfeMunicipioDescarregamentoClassMdfe+"\r\n";
                foreach (Entidades.MdfeMunicipioDescarregamentoClass tmp in CollectionMdfeMunicipioDescarregamentoClassMdfe)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMdfeNfeClassMdfe.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfeNfeClassMdfe+"\r\n";
                foreach (Entidades.MdfeNfeClass tmp in CollectionMdfeNfeClassMdfe)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMdfePercursoClassMdfe.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfePercursoClassMdfe+"\r\n";
                foreach (Entidades.MdfePercursoClass tmp in CollectionMdfePercursoClassMdfe)
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
        public static MdfeClass CopiarEntidade(MdfeClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MdfeClass toRet = new MdfeClass(usuario,conn);
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Serie= entidadeCopiar.Serie;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.ChaveAcesso= entidadeCopiar.ChaveAcesso;
 toRet.DvChaveAcesso= entidadeCopiar.DvChaveAcesso;
 toRet.Versao= entidadeCopiar.Versao;
 toRet.CodIbgeUfEmitente= entidadeCopiar.CodIbgeUfEmitente;
 toRet.TipoAmbiente= entidadeCopiar.TipoAmbiente;
 toRet.TipoEmitente= entidadeCopiar.TipoEmitente;
 toRet.ModeloManifesto= entidadeCopiar.ModeloManifesto;
 toRet.ModalidadeTransporte= entidadeCopiar.ModalidadeTransporte;
 toRet.DataEmissao= entidadeCopiar.DataEmissao;
 toRet.FormaEmissao= entidadeCopiar.FormaEmissao;
 toRet.ProcessoEmissao= entidadeCopiar.ProcessoEmissao;
 toRet.VersaoAplicativo= entidadeCopiar.VersaoAplicativo;
 toRet.UfCarregamento= entidadeCopiar.UfCarregamento;
 toRet.UfDescarregamento= entidadeCopiar.UfDescarregamento;
 toRet.CnpjEmitente= entidadeCopiar.CnpjEmitente;
 toRet.IeEmitente= entidadeCopiar.IeEmitente;
 toRet.RazaoEmitente= entidadeCopiar.RazaoEmitente;
 toRet.NomeFantasiaEmitente= entidadeCopiar.NomeFantasiaEmitente;
 toRet.LogradouroEmitente= entidadeCopiar.LogradouroEmitente;
 toRet.NumeroEnderecoEmitente= entidadeCopiar.NumeroEnderecoEmitente;
 toRet.ComplementoEnderecoEmitente= entidadeCopiar.ComplementoEnderecoEmitente;
 toRet.BairroEmitente= entidadeCopiar.BairroEmitente;
 toRet.CodigoIbgeMunicipioEmitente= entidadeCopiar.CodigoIbgeMunicipioEmitente;
 toRet.MunicipioEmitente= entidadeCopiar.MunicipioEmitente;
 toRet.CepEmitente= entidadeCopiar.CepEmitente;
 toRet.UfEmitente= entidadeCopiar.UfEmitente;
 toRet.TelefoneEmitente= entidadeCopiar.TelefoneEmitente;
 toRet.EmailEmitente= entidadeCopiar.EmailEmitente;
 toRet.QtdNfe= entidadeCopiar.QtdNfe;
 toRet.ValorTotalMercadoria= entidadeCopiar.ValorTotalMercadoria;
 toRet.UnidadeMedidaPesoCarga= entidadeCopiar.UnidadeMedidaPesoCarga;
 toRet.PesoBrutoCarga= entidadeCopiar.PesoBrutoCarga;
 toRet.InfoAddicionalFisco= entidadeCopiar.InfoAddicionalFisco;
 toRet.InfoAdicionalContribuinte= entidadeCopiar.InfoAdicionalContribuinte;
 toRet.DataHoraInicioViagem= entidadeCopiar.DataHoraInicioViagem;
 toRet.EnviarReceita= entidadeCopiar.EnviarReceita;

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
       _serieOriginal = Serie;
       _serieOriginalCommited = _serieOriginal;
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _chaveAcessoOriginal = ChaveAcesso;
       _chaveAcessoOriginalCommited = _chaveAcessoOriginal;
       _dvChaveAcessoOriginal = DvChaveAcesso;
       _dvChaveAcessoOriginalCommited = _dvChaveAcessoOriginal;
       _versaoOriginal = Versao;
       _versaoOriginalCommited = _versaoOriginal;
       _codIbgeUfEmitenteOriginal = CodIbgeUfEmitente;
       _codIbgeUfEmitenteOriginalCommited = _codIbgeUfEmitenteOriginal;
       _tipoAmbienteOriginal = TipoAmbiente;
       _tipoAmbienteOriginalCommited = _tipoAmbienteOriginal;
       _tipoEmitenteOriginal = TipoEmitente;
       _tipoEmitenteOriginalCommited = _tipoEmitenteOriginal;
       _modeloManifestoOriginal = ModeloManifesto;
       _modeloManifestoOriginalCommited = _modeloManifestoOriginal;
       _modalidadeTransporteOriginal = ModalidadeTransporte;
       _modalidadeTransporteOriginalCommited = _modalidadeTransporteOriginal;
       _dataEmissaoOriginal = DataEmissao;
       _dataEmissaoOriginalCommited = _dataEmissaoOriginal;
       _formaEmissaoOriginal = FormaEmissao;
       _formaEmissaoOriginalCommited = _formaEmissaoOriginal;
       _processoEmissaoOriginal = ProcessoEmissao;
       _processoEmissaoOriginalCommited = _processoEmissaoOriginal;
       _versaoAplicativoOriginal = VersaoAplicativo;
       _versaoAplicativoOriginalCommited = _versaoAplicativoOriginal;
       _ufCarregamentoOriginal = UfCarregamento;
       _ufCarregamentoOriginalCommited = _ufCarregamentoOriginal;
       _ufDescarregamentoOriginal = UfDescarregamento;
       _ufDescarregamentoOriginalCommited = _ufDescarregamentoOriginal;
       _cnpjEmitenteOriginal = CnpjEmitente;
       _cnpjEmitenteOriginalCommited = _cnpjEmitenteOriginal;
       _ieEmitenteOriginal = IeEmitente;
       _ieEmitenteOriginalCommited = _ieEmitenteOriginal;
       _razaoEmitenteOriginal = RazaoEmitente;
       _razaoEmitenteOriginalCommited = _razaoEmitenteOriginal;
       _nomeFantasiaEmitenteOriginal = NomeFantasiaEmitente;
       _nomeFantasiaEmitenteOriginalCommited = _nomeFantasiaEmitenteOriginal;
       _logradouroEmitenteOriginal = LogradouroEmitente;
       _logradouroEmitenteOriginalCommited = _logradouroEmitenteOriginal;
       _numeroEnderecoEmitenteOriginal = NumeroEnderecoEmitente;
       _numeroEnderecoEmitenteOriginalCommited = _numeroEnderecoEmitenteOriginal;
       _complementoEnderecoEmitenteOriginal = ComplementoEnderecoEmitente;
       _complementoEnderecoEmitenteOriginalCommited = _complementoEnderecoEmitenteOriginal;
       _bairroEmitenteOriginal = BairroEmitente;
       _bairroEmitenteOriginalCommited = _bairroEmitenteOriginal;
       _codigoIbgeMunicipioEmitenteOriginal = CodigoIbgeMunicipioEmitente;
       _codigoIbgeMunicipioEmitenteOriginalCommited = _codigoIbgeMunicipioEmitenteOriginal;
       _municipioEmitenteOriginal = MunicipioEmitente;
       _municipioEmitenteOriginalCommited = _municipioEmitenteOriginal;
       _cepEmitenteOriginal = CepEmitente;
       _cepEmitenteOriginalCommited = _cepEmitenteOriginal;
       _ufEmitenteOriginal = UfEmitente;
       _ufEmitenteOriginalCommited = _ufEmitenteOriginal;
       _telefoneEmitenteOriginal = TelefoneEmitente;
       _telefoneEmitenteOriginalCommited = _telefoneEmitenteOriginal;
       _emailEmitenteOriginal = EmailEmitente;
       _emailEmitenteOriginalCommited = _emailEmitenteOriginal;
       _qtdNfeOriginal = QtdNfe;
       _qtdNfeOriginalCommited = _qtdNfeOriginal;
       _valorTotalMercadoriaOriginal = ValorTotalMercadoria;
       _valorTotalMercadoriaOriginalCommited = _valorTotalMercadoriaOriginal;
       _unidadeMedidaPesoCargaOriginal = UnidadeMedidaPesoCarga;
       _unidadeMedidaPesoCargaOriginalCommited = _unidadeMedidaPesoCargaOriginal;
       _pesoBrutoCargaOriginal = PesoBrutoCarga;
       _pesoBrutoCargaOriginalCommited = _pesoBrutoCargaOriginal;
       _infoAddicionalFiscoOriginal = InfoAddicionalFisco;
       _infoAddicionalFiscoOriginalCommited = _infoAddicionalFiscoOriginal;
       _infoAdicionalContribuinteOriginal = InfoAdicionalContribuinte;
       _infoAdicionalContribuinteOriginalCommited = _infoAdicionalContribuinteOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _dataHoraInicioViagemOriginal = DataHoraInicioViagem;
       _dataHoraInicioViagemOriginalCommited = _dataHoraInicioViagemOriginal;
       _enviarReceitaOriginal = EnviarReceita;
       _enviarReceitaOriginalCommited = _enviarReceitaOriginal;

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
       _serieOriginalCommited = Serie;
       _codigoOriginalCommited = Codigo;
       _chaveAcessoOriginalCommited = ChaveAcesso;
       _dvChaveAcessoOriginalCommited = DvChaveAcesso;
       _versaoOriginalCommited = Versao;
       _codIbgeUfEmitenteOriginalCommited = CodIbgeUfEmitente;
       _tipoAmbienteOriginalCommited = TipoAmbiente;
       _tipoEmitenteOriginalCommited = TipoEmitente;
       _modeloManifestoOriginalCommited = ModeloManifesto;
       _modalidadeTransporteOriginalCommited = ModalidadeTransporte;
       _dataEmissaoOriginalCommited = DataEmissao;
       _formaEmissaoOriginalCommited = FormaEmissao;
       _processoEmissaoOriginalCommited = ProcessoEmissao;
       _versaoAplicativoOriginalCommited = VersaoAplicativo;
       _ufCarregamentoOriginalCommited = UfCarregamento;
       _ufDescarregamentoOriginalCommited = UfDescarregamento;
       _cnpjEmitenteOriginalCommited = CnpjEmitente;
       _ieEmitenteOriginalCommited = IeEmitente;
       _razaoEmitenteOriginalCommited = RazaoEmitente;
       _nomeFantasiaEmitenteOriginalCommited = NomeFantasiaEmitente;
       _logradouroEmitenteOriginalCommited = LogradouroEmitente;
       _numeroEnderecoEmitenteOriginalCommited = NumeroEnderecoEmitente;
       _complementoEnderecoEmitenteOriginalCommited = ComplementoEnderecoEmitente;
       _bairroEmitenteOriginalCommited = BairroEmitente;
       _codigoIbgeMunicipioEmitenteOriginalCommited = CodigoIbgeMunicipioEmitente;
       _municipioEmitenteOriginalCommited = MunicipioEmitente;
       _cepEmitenteOriginalCommited = CepEmitente;
       _ufEmitenteOriginalCommited = UfEmitente;
       _telefoneEmitenteOriginalCommited = TelefoneEmitente;
       _emailEmitenteOriginalCommited = EmailEmitente;
       _qtdNfeOriginalCommited = QtdNfe;
       _valorTotalMercadoriaOriginalCommited = ValorTotalMercadoria;
       _unidadeMedidaPesoCargaOriginalCommited = UnidadeMedidaPesoCarga;
       _pesoBrutoCargaOriginalCommited = PesoBrutoCarga;
       _infoAddicionalFiscoOriginalCommited = InfoAddicionalFisco;
       _infoAdicionalContribuinteOriginalCommited = InfoAdicionalContribuinte;
       _versionOriginalCommited = Version;
       _dataHoraInicioViagemOriginalCommited = DataHoraInicioViagem;
       _enviarReceitaOriginalCommited = EnviarReceita;

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
               if (_valueCollectionMdfeLacreClassMdfeLoaded) 
               {
                  if (_collectionMdfeLacreClassMdfeRemovidos != null) 
                  {
                     _collectionMdfeLacreClassMdfeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfeLacreClassMdfeRemovidos = new List<Entidades.MdfeLacreClass>();
                  }
                  _collectionMdfeLacreClassMdfeOriginal= (from a in _valueCollectionMdfeLacreClassMdfe select a.ID).ToList();
                  _valueCollectionMdfeLacreClassMdfeChanged = false;
                  _valueCollectionMdfeLacreClassMdfeCommitedChanged = false;
               }
               if (_valueCollectionMdfeModalRodoviarioClassMdfeLoaded) 
               {
                  if (_collectionMdfeModalRodoviarioClassMdfeRemovidos != null) 
                  {
                     _collectionMdfeModalRodoviarioClassMdfeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfeModalRodoviarioClassMdfeRemovidos = new List<Entidades.MdfeModalRodoviarioClass>();
                  }
                  _collectionMdfeModalRodoviarioClassMdfeOriginal= (from a in _valueCollectionMdfeModalRodoviarioClassMdfe select a.ID).ToList();
                  _valueCollectionMdfeModalRodoviarioClassMdfeChanged = false;
                  _valueCollectionMdfeModalRodoviarioClassMdfeCommitedChanged = false;
               }
               if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded) 
               {
                  if (_collectionMdfeMunicipioCarregamentoClassMdfeRemovidos != null) 
                  {
                     _collectionMdfeMunicipioCarregamentoClassMdfeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfeMunicipioCarregamentoClassMdfeRemovidos = new List<Entidades.MdfeMunicipioCarregamentoClass>();
                  }
                  _collectionMdfeMunicipioCarregamentoClassMdfeOriginal= (from a in _valueCollectionMdfeMunicipioCarregamentoClassMdfe select a.ID).ToList();
                  _valueCollectionMdfeMunicipioCarregamentoClassMdfeChanged = false;
                  _valueCollectionMdfeMunicipioCarregamentoClassMdfeCommitedChanged = false;
               }
               if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded) 
               {
                  if (_collectionMdfeMunicipioDescarregamentoClassMdfeRemovidos != null) 
                  {
                     _collectionMdfeMunicipioDescarregamentoClassMdfeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfeMunicipioDescarregamentoClassMdfeRemovidos = new List<Entidades.MdfeMunicipioDescarregamentoClass>();
                  }
                  _collectionMdfeMunicipioDescarregamentoClassMdfeOriginal= (from a in _valueCollectionMdfeMunicipioDescarregamentoClassMdfe select a.ID).ToList();
                  _valueCollectionMdfeMunicipioDescarregamentoClassMdfeChanged = false;
                  _valueCollectionMdfeMunicipioDescarregamentoClassMdfeCommitedChanged = false;
               }
               if (_valueCollectionMdfeNfeClassMdfeLoaded) 
               {
                  if (_collectionMdfeNfeClassMdfeRemovidos != null) 
                  {
                     _collectionMdfeNfeClassMdfeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfeNfeClassMdfeRemovidos = new List<Entidades.MdfeNfeClass>();
                  }
                  _collectionMdfeNfeClassMdfeOriginal= (from a in _valueCollectionMdfeNfeClassMdfe select a.ID).ToList();
                  _valueCollectionMdfeNfeClassMdfeChanged = false;
                  _valueCollectionMdfeNfeClassMdfeCommitedChanged = false;
               }
               if (_valueCollectionMdfePercursoClassMdfeLoaded) 
               {
                  if (_collectionMdfePercursoClassMdfeRemovidos != null) 
                  {
                     _collectionMdfePercursoClassMdfeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfePercursoClassMdfeRemovidos = new List<Entidades.MdfePercursoClass>();
                  }
                  _collectionMdfePercursoClassMdfeOriginal= (from a in _valueCollectionMdfePercursoClassMdfe select a.ID).ToList();
                  _valueCollectionMdfePercursoClassMdfeChanged = false;
                  _valueCollectionMdfePercursoClassMdfeCommitedChanged = false;
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
               Serie=_serieOriginal;
               _serieOriginalCommited=_serieOriginal;
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               ChaveAcesso=_chaveAcessoOriginal;
               _chaveAcessoOriginalCommited=_chaveAcessoOriginal;
               DvChaveAcesso=_dvChaveAcessoOriginal;
               _dvChaveAcessoOriginalCommited=_dvChaveAcessoOriginal;
               Versao=_versaoOriginal;
               _versaoOriginalCommited=_versaoOriginal;
               CodIbgeUfEmitente=_codIbgeUfEmitenteOriginal;
               _codIbgeUfEmitenteOriginalCommited=_codIbgeUfEmitenteOriginal;
               TipoAmbiente=_tipoAmbienteOriginal;
               _tipoAmbienteOriginalCommited=_tipoAmbienteOriginal;
               TipoEmitente=_tipoEmitenteOriginal;
               _tipoEmitenteOriginalCommited=_tipoEmitenteOriginal;
               ModeloManifesto=_modeloManifestoOriginal;
               _modeloManifestoOriginalCommited=_modeloManifestoOriginal;
               ModalidadeTransporte=_modalidadeTransporteOriginal;
               _modalidadeTransporteOriginalCommited=_modalidadeTransporteOriginal;
               DataEmissao=_dataEmissaoOriginal;
               _dataEmissaoOriginalCommited=_dataEmissaoOriginal;
               FormaEmissao=_formaEmissaoOriginal;
               _formaEmissaoOriginalCommited=_formaEmissaoOriginal;
               ProcessoEmissao=_processoEmissaoOriginal;
               _processoEmissaoOriginalCommited=_processoEmissaoOriginal;
               VersaoAplicativo=_versaoAplicativoOriginal;
               _versaoAplicativoOriginalCommited=_versaoAplicativoOriginal;
               UfCarregamento=_ufCarregamentoOriginal;
               _ufCarregamentoOriginalCommited=_ufCarregamentoOriginal;
               UfDescarregamento=_ufDescarregamentoOriginal;
               _ufDescarregamentoOriginalCommited=_ufDescarregamentoOriginal;
               CnpjEmitente=_cnpjEmitenteOriginal;
               _cnpjEmitenteOriginalCommited=_cnpjEmitenteOriginal;
               IeEmitente=_ieEmitenteOriginal;
               _ieEmitenteOriginalCommited=_ieEmitenteOriginal;
               RazaoEmitente=_razaoEmitenteOriginal;
               _razaoEmitenteOriginalCommited=_razaoEmitenteOriginal;
               NomeFantasiaEmitente=_nomeFantasiaEmitenteOriginal;
               _nomeFantasiaEmitenteOriginalCommited=_nomeFantasiaEmitenteOriginal;
               LogradouroEmitente=_logradouroEmitenteOriginal;
               _logradouroEmitenteOriginalCommited=_logradouroEmitenteOriginal;
               NumeroEnderecoEmitente=_numeroEnderecoEmitenteOriginal;
               _numeroEnderecoEmitenteOriginalCommited=_numeroEnderecoEmitenteOriginal;
               ComplementoEnderecoEmitente=_complementoEnderecoEmitenteOriginal;
               _complementoEnderecoEmitenteOriginalCommited=_complementoEnderecoEmitenteOriginal;
               BairroEmitente=_bairroEmitenteOriginal;
               _bairroEmitenteOriginalCommited=_bairroEmitenteOriginal;
               CodigoIbgeMunicipioEmitente=_codigoIbgeMunicipioEmitenteOriginal;
               _codigoIbgeMunicipioEmitenteOriginalCommited=_codigoIbgeMunicipioEmitenteOriginal;
               MunicipioEmitente=_municipioEmitenteOriginal;
               _municipioEmitenteOriginalCommited=_municipioEmitenteOriginal;
               CepEmitente=_cepEmitenteOriginal;
               _cepEmitenteOriginalCommited=_cepEmitenteOriginal;
               UfEmitente=_ufEmitenteOriginal;
               _ufEmitenteOriginalCommited=_ufEmitenteOriginal;
               TelefoneEmitente=_telefoneEmitenteOriginal;
               _telefoneEmitenteOriginalCommited=_telefoneEmitenteOriginal;
               EmailEmitente=_emailEmitenteOriginal;
               _emailEmitenteOriginalCommited=_emailEmitenteOriginal;
               QtdNfe=_qtdNfeOriginal;
               _qtdNfeOriginalCommited=_qtdNfeOriginal;
               ValorTotalMercadoria=_valorTotalMercadoriaOriginal;
               _valorTotalMercadoriaOriginalCommited=_valorTotalMercadoriaOriginal;
               UnidadeMedidaPesoCarga=_unidadeMedidaPesoCargaOriginal;
               _unidadeMedidaPesoCargaOriginalCommited=_unidadeMedidaPesoCargaOriginal;
               PesoBrutoCarga=_pesoBrutoCargaOriginal;
               _pesoBrutoCargaOriginalCommited=_pesoBrutoCargaOriginal;
               InfoAddicionalFisco=_infoAddicionalFiscoOriginal;
               _infoAddicionalFiscoOriginalCommited=_infoAddicionalFiscoOriginal;
               InfoAdicionalContribuinte=_infoAdicionalContribuinteOriginal;
               _infoAdicionalContribuinteOriginalCommited=_infoAdicionalContribuinteOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               DataHoraInicioViagem=_dataHoraInicioViagemOriginal;
               _dataHoraInicioViagemOriginalCommited=_dataHoraInicioViagemOriginal;
               EnviarReceita=_enviarReceitaOriginal;
               _enviarReceitaOriginalCommited=_enviarReceitaOriginal;
               if (_valueCollectionMdfeLacreClassMdfeLoaded) 
               {
                  CollectionMdfeLacreClassMdfe.Clear();
                  foreach(int item in _collectionMdfeLacreClassMdfeOriginal)
                  {
                    CollectionMdfeLacreClassMdfe.Add(Entidades.MdfeLacreClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfeLacreClassMdfeRemovidos.Clear();
               }
               if (_valueCollectionMdfeModalRodoviarioClassMdfeLoaded) 
               {
                  CollectionMdfeModalRodoviarioClassMdfe.Clear();
                  foreach(int item in _collectionMdfeModalRodoviarioClassMdfeOriginal)
                  {
                    CollectionMdfeModalRodoviarioClassMdfe.Add(Entidades.MdfeModalRodoviarioClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfeModalRodoviarioClassMdfeRemovidos.Clear();
               }
               if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded) 
               {
                  CollectionMdfeMunicipioCarregamentoClassMdfe.Clear();
                  foreach(int item in _collectionMdfeMunicipioCarregamentoClassMdfeOriginal)
                  {
                    CollectionMdfeMunicipioCarregamentoClassMdfe.Add(Entidades.MdfeMunicipioCarregamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfeMunicipioCarregamentoClassMdfeRemovidos.Clear();
               }
               if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded) 
               {
                  CollectionMdfeMunicipioDescarregamentoClassMdfe.Clear();
                  foreach(int item in _collectionMdfeMunicipioDescarregamentoClassMdfeOriginal)
                  {
                    CollectionMdfeMunicipioDescarregamentoClassMdfe.Add(Entidades.MdfeMunicipioDescarregamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfeMunicipioDescarregamentoClassMdfeRemovidos.Clear();
               }
               if (_valueCollectionMdfeNfeClassMdfeLoaded) 
               {
                  CollectionMdfeNfeClassMdfe.Clear();
                  foreach(int item in _collectionMdfeNfeClassMdfeOriginal)
                  {
                    CollectionMdfeNfeClassMdfe.Add(Entidades.MdfeNfeClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfeNfeClassMdfeRemovidos.Clear();
               }
               if (_valueCollectionMdfePercursoClassMdfeLoaded) 
               {
                  CollectionMdfePercursoClassMdfe.Clear();
                  foreach(int item in _collectionMdfePercursoClassMdfeOriginal)
                  {
                    CollectionMdfePercursoClassMdfe.Add(Entidades.MdfePercursoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfePercursoClassMdfeRemovidos.Clear();
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
               if (_valueCollectionMdfeLacreClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeLacreClassMdfeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeModalRodoviarioClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeModalRodoviarioClassMdfeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeNfeClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeNfeClassMdfeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfePercursoClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfePercursoClassMdfeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeLacreClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeLacreClassMdfe.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeModalRodoviarioClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeModalRodoviarioClassMdfe.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeMunicipioCarregamentoClassMdfe.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeMunicipioDescarregamentoClassMdfe.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeNfeClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeNfeClassMdfe.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfePercursoClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfePercursoClassMdfe.Any(item => item.IsDirty());
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
       dirty = _serieOriginal != Serie;
      if (dirty) return true;
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       dirty = _chaveAcessoOriginal != ChaveAcesso;
      if (dirty) return true;
       dirty = _dvChaveAcessoOriginal != DvChaveAcesso;
      if (dirty) return true;
       dirty = _versaoOriginal != Versao;
      if (dirty) return true;
       dirty = _codIbgeUfEmitenteOriginal != CodIbgeUfEmitente;
      if (dirty) return true;
       dirty = _tipoAmbienteOriginal != TipoAmbiente;
      if (dirty) return true;
       dirty = _tipoEmitenteOriginal != TipoEmitente;
      if (dirty) return true;
       dirty = _modeloManifestoOriginal != ModeloManifesto;
      if (dirty) return true;
       dirty = _modalidadeTransporteOriginal != ModalidadeTransporte;
      if (dirty) return true;
       dirty = _dataEmissaoOriginal != DataEmissao;
      if (dirty) return true;
       dirty = _formaEmissaoOriginal != FormaEmissao;
      if (dirty) return true;
       dirty = _processoEmissaoOriginal != ProcessoEmissao;
      if (dirty) return true;
       dirty = _versaoAplicativoOriginal != VersaoAplicativo;
      if (dirty) return true;
       dirty = _ufCarregamentoOriginal != UfCarregamento;
      if (dirty) return true;
       dirty = _ufDescarregamentoOriginal != UfDescarregamento;
      if (dirty) return true;
       dirty = _cnpjEmitenteOriginal != CnpjEmitente;
      if (dirty) return true;
       dirty = _ieEmitenteOriginal != IeEmitente;
      if (dirty) return true;
       dirty = _razaoEmitenteOriginal != RazaoEmitente;
      if (dirty) return true;
       dirty = _nomeFantasiaEmitenteOriginal != NomeFantasiaEmitente;
      if (dirty) return true;
       dirty = _logradouroEmitenteOriginal != LogradouroEmitente;
      if (dirty) return true;
       dirty = _numeroEnderecoEmitenteOriginal != NumeroEnderecoEmitente;
      if (dirty) return true;
       dirty = _complementoEnderecoEmitenteOriginal != ComplementoEnderecoEmitente;
      if (dirty) return true;
       dirty = _bairroEmitenteOriginal != BairroEmitente;
      if (dirty) return true;
       dirty = _codigoIbgeMunicipioEmitenteOriginal != CodigoIbgeMunicipioEmitente;
      if (dirty) return true;
       dirty = _municipioEmitenteOriginal != MunicipioEmitente;
      if (dirty) return true;
       dirty = _cepEmitenteOriginal != CepEmitente;
      if (dirty) return true;
       dirty = _ufEmitenteOriginal != UfEmitente;
      if (dirty) return true;
       dirty = _telefoneEmitenteOriginal != TelefoneEmitente;
      if (dirty) return true;
       dirty = _emailEmitenteOriginal != EmailEmitente;
      if (dirty) return true;
       dirty = _qtdNfeOriginal != QtdNfe;
      if (dirty) return true;
       dirty = _valorTotalMercadoriaOriginal != ValorTotalMercadoria;
      if (dirty) return true;
       dirty = _unidadeMedidaPesoCargaOriginal != UnidadeMedidaPesoCarga;
      if (dirty) return true;
       dirty = _pesoBrutoCargaOriginal != PesoBrutoCarga;
      if (dirty) return true;
       dirty = _infoAddicionalFiscoOriginal != InfoAddicionalFisco;
      if (dirty) return true;
       dirty = _infoAdicionalContribuinteOriginal != InfoAdicionalContribuinte;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _dataHoraInicioViagemOriginal != DataHoraInicioViagem;
      if (dirty) return true;
       dirty = _enviarReceitaOriginal != EnviarReceita;

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
               if (_valueCollectionMdfeLacreClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeLacreClassMdfeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeModalRodoviarioClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeModalRodoviarioClassMdfeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeNfeClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfeNfeClassMdfeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfePercursoClassMdfeLoaded) 
               {
                  if (_valueCollectionMdfePercursoClassMdfeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeLacreClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeLacreClassMdfe.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeModalRodoviarioClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeModalRodoviarioClassMdfe.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeMunicipioCarregamentoClassMdfe.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeMunicipioDescarregamentoClassMdfe.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeNfeClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfeNfeClassMdfe.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfePercursoClassMdfeLoaded) 
               {
                   tempRet = CollectionMdfePercursoClassMdfe.Any(item => item.IsDirtyCommited());
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
       dirty = _serieOriginalCommited != Serie;
      if (dirty) return true;
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       dirty = _chaveAcessoOriginalCommited != ChaveAcesso;
      if (dirty) return true;
       dirty = _dvChaveAcessoOriginalCommited != DvChaveAcesso;
      if (dirty) return true;
       dirty = _versaoOriginalCommited != Versao;
      if (dirty) return true;
       dirty = _codIbgeUfEmitenteOriginalCommited != CodIbgeUfEmitente;
      if (dirty) return true;
       dirty = _tipoAmbienteOriginalCommited != TipoAmbiente;
      if (dirty) return true;
       dirty = _tipoEmitenteOriginalCommited != TipoEmitente;
      if (dirty) return true;
       dirty = _modeloManifestoOriginalCommited != ModeloManifesto;
      if (dirty) return true;
       dirty = _modalidadeTransporteOriginalCommited != ModalidadeTransporte;
      if (dirty) return true;
       dirty = _dataEmissaoOriginalCommited != DataEmissao;
      if (dirty) return true;
       dirty = _formaEmissaoOriginalCommited != FormaEmissao;
      if (dirty) return true;
       dirty = _processoEmissaoOriginalCommited != ProcessoEmissao;
      if (dirty) return true;
       dirty = _versaoAplicativoOriginalCommited != VersaoAplicativo;
      if (dirty) return true;
       dirty = _ufCarregamentoOriginalCommited != UfCarregamento;
      if (dirty) return true;
       dirty = _ufDescarregamentoOriginalCommited != UfDescarregamento;
      if (dirty) return true;
       dirty = _cnpjEmitenteOriginalCommited != CnpjEmitente;
      if (dirty) return true;
       dirty = _ieEmitenteOriginalCommited != IeEmitente;
      if (dirty) return true;
       dirty = _razaoEmitenteOriginalCommited != RazaoEmitente;
      if (dirty) return true;
       dirty = _nomeFantasiaEmitenteOriginalCommited != NomeFantasiaEmitente;
      if (dirty) return true;
       dirty = _logradouroEmitenteOriginalCommited != LogradouroEmitente;
      if (dirty) return true;
       dirty = _numeroEnderecoEmitenteOriginalCommited != NumeroEnderecoEmitente;
      if (dirty) return true;
       dirty = _complementoEnderecoEmitenteOriginalCommited != ComplementoEnderecoEmitente;
      if (dirty) return true;
       dirty = _bairroEmitenteOriginalCommited != BairroEmitente;
      if (dirty) return true;
       dirty = _codigoIbgeMunicipioEmitenteOriginalCommited != CodigoIbgeMunicipioEmitente;
      if (dirty) return true;
       dirty = _municipioEmitenteOriginalCommited != MunicipioEmitente;
      if (dirty) return true;
       dirty = _cepEmitenteOriginalCommited != CepEmitente;
      if (dirty) return true;
       dirty = _ufEmitenteOriginalCommited != UfEmitente;
      if (dirty) return true;
       dirty = _telefoneEmitenteOriginalCommited != TelefoneEmitente;
      if (dirty) return true;
       dirty = _emailEmitenteOriginalCommited != EmailEmitente;
      if (dirty) return true;
       dirty = _qtdNfeOriginalCommited != QtdNfe;
      if (dirty) return true;
       dirty = _valorTotalMercadoriaOriginalCommited != ValorTotalMercadoria;
      if (dirty) return true;
       dirty = _unidadeMedidaPesoCargaOriginalCommited != UnidadeMedidaPesoCarga;
      if (dirty) return true;
       dirty = _pesoBrutoCargaOriginalCommited != PesoBrutoCarga;
      if (dirty) return true;
       dirty = _infoAddicionalFiscoOriginalCommited != InfoAddicionalFisco;
      if (dirty) return true;
       dirty = _infoAdicionalContribuinteOriginalCommited != InfoAdicionalContribuinte;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _dataHoraInicioViagemOriginalCommited != DataHoraInicioViagem;
      if (dirty) return true;
       dirty = _enviarReceitaOriginalCommited != EnviarReceita;

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
               if (_valueCollectionMdfeLacreClassMdfeLoaded) 
               {
                  foreach(MdfeLacreClass item in CollectionMdfeLacreClassMdfe)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMdfeModalRodoviarioClassMdfeLoaded) 
               {
                  foreach(MdfeModalRodoviarioClass item in CollectionMdfeModalRodoviarioClassMdfe)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded) 
               {
                  foreach(MdfeMunicipioCarregamentoClass item in CollectionMdfeMunicipioCarregamentoClassMdfe)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded) 
               {
                  foreach(MdfeMunicipioDescarregamentoClass item in CollectionMdfeMunicipioDescarregamentoClassMdfe)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMdfeNfeClassMdfeLoaded) 
               {
                  foreach(MdfeNfeClass item in CollectionMdfeNfeClassMdfe)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMdfePercursoClassMdfeLoaded) 
               {
                  foreach(MdfePercursoClass item in CollectionMdfePercursoClassMdfe)
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
             case "Serie":
                return this.Serie;
             case "Codigo":
                return this.Codigo;
             case "ChaveAcesso":
                return this.ChaveAcesso;
             case "DvChaveAcesso":
                return this.DvChaveAcesso;
             case "Versao":
                return this.Versao;
             case "CodIbgeUfEmitente":
                return this.CodIbgeUfEmitente;
             case "TipoAmbiente":
                return this.TipoAmbiente;
             case "TipoEmitente":
                return this.TipoEmitente;
             case "ModeloManifesto":
                return this.ModeloManifesto;
             case "ModalidadeTransporte":
                return this.ModalidadeTransporte;
             case "DataEmissao":
                return this.DataEmissao;
             case "FormaEmissao":
                return this.FormaEmissao;
             case "ProcessoEmissao":
                return this.ProcessoEmissao;
             case "VersaoAplicativo":
                return this.VersaoAplicativo;
             case "UfCarregamento":
                return this.UfCarregamento;
             case "UfDescarregamento":
                return this.UfDescarregamento;
             case "CnpjEmitente":
                return this.CnpjEmitente;
             case "IeEmitente":
                return this.IeEmitente;
             case "RazaoEmitente":
                return this.RazaoEmitente;
             case "NomeFantasiaEmitente":
                return this.NomeFantasiaEmitente;
             case "LogradouroEmitente":
                return this.LogradouroEmitente;
             case "NumeroEnderecoEmitente":
                return this.NumeroEnderecoEmitente;
             case "ComplementoEnderecoEmitente":
                return this.ComplementoEnderecoEmitente;
             case "BairroEmitente":
                return this.BairroEmitente;
             case "CodigoIbgeMunicipioEmitente":
                return this.CodigoIbgeMunicipioEmitente;
             case "MunicipioEmitente":
                return this.MunicipioEmitente;
             case "CepEmitente":
                return this.CepEmitente;
             case "UfEmitente":
                return this.UfEmitente;
             case "TelefoneEmitente":
                return this.TelefoneEmitente;
             case "EmailEmitente":
                return this.EmailEmitente;
             case "QtdNfe":
                return this.QtdNfe;
             case "ValorTotalMercadoria":
                return this.ValorTotalMercadoria;
             case "UnidadeMedidaPesoCarga":
                return this.UnidadeMedidaPesoCarga;
             case "PesoBrutoCarga":
                return this.PesoBrutoCarga;
             case "InfoAddicionalFisco":
                return this.InfoAddicionalFisco;
             case "InfoAdicionalContribuinte":
                return this.InfoAdicionalContribuinte;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "DataHoraInicioViagem":
                return this.DataHoraInicioViagem;
             case "EnviarReceita":
                return this.EnviarReceita;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionMdfeLacreClassMdfeLoaded) 
               {
                  foreach(MdfeLacreClass item in CollectionMdfeLacreClassMdfe)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMdfeModalRodoviarioClassMdfeLoaded) 
               {
                  foreach(MdfeModalRodoviarioClass item in CollectionMdfeModalRodoviarioClassMdfe)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMdfeMunicipioCarregamentoClassMdfeLoaded) 
               {
                  foreach(MdfeMunicipioCarregamentoClass item in CollectionMdfeMunicipioCarregamentoClassMdfe)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMdfeMunicipioDescarregamentoClassMdfeLoaded) 
               {
                  foreach(MdfeMunicipioDescarregamentoClass item in CollectionMdfeMunicipioDescarregamentoClassMdfe)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMdfeNfeClassMdfeLoaded) 
               {
                  foreach(MdfeNfeClass item in CollectionMdfeNfeClassMdfe)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMdfePercursoClassMdfeLoaded) 
               {
                  foreach(MdfePercursoClass item in CollectionMdfePercursoClassMdfe)
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
                  command.CommandText += " COUNT(mdfe.id_mdfe) " ;
               }
               else
               {
               command.CommandText += "mdfe.id_mdfe, " ;
               command.CommandText += "mdfe.mdf_numero, " ;
               command.CommandText += "mdfe.mdf_serie, " ;
               command.CommandText += "mdfe.mdf_codigo, " ;
               command.CommandText += "mdfe.mdf_chave_acesso, " ;
               command.CommandText += "mdfe.mdf_dv_chave_acesso, " ;
               command.CommandText += "mdfe.mdf_versao, " ;
               command.CommandText += "mdfe.mdf_cod_ibge_uf_emitente, " ;
               command.CommandText += "mdfe.mdf_tipo_ambiente, " ;
               command.CommandText += "mdfe.mdf_tipo_emitente, " ;
               command.CommandText += "mdfe.mdf_modelo_manifesto, " ;
               command.CommandText += "mdfe.mdf_modalidade_transporte, " ;
               command.CommandText += "mdfe.mdf_data_emissao, " ;
               command.CommandText += "mdfe.mdf_forma_emissao, " ;
               command.CommandText += "mdfe.mdf_processo_emissao, " ;
               command.CommandText += "mdfe.mdf_versao_aplicativo, " ;
               command.CommandText += "mdfe.mdf_uf_carregamento, " ;
               command.CommandText += "mdfe.mdf_uf_descarregamento, " ;
               command.CommandText += "mdfe.mdf_cnpj_emitente, " ;
               command.CommandText += "mdfe.mdf_ie_emitente, " ;
               command.CommandText += "mdfe.mdf_razao_emitente, " ;
               command.CommandText += "mdfe.mdf_nome_fantasia_emitente, " ;
               command.CommandText += "mdfe.mdf_logradouro_emitente, " ;
               command.CommandText += "mdfe.mdf_numero_endereco_emitente, " ;
               command.CommandText += "mdfe.mdf_complemento_endereco_emitente, " ;
               command.CommandText += "mdfe.mdf_bairro_emitente, " ;
               command.CommandText += "mdfe.mdf_codigo_ibge_municipio_emitente, " ;
               command.CommandText += "mdfe.mdf_municipio_emitente, " ;
               command.CommandText += "mdfe.mdf_cep_emitente, " ;
               command.CommandText += "mdfe.mdf_uf_emitente, " ;
               command.CommandText += "mdfe.mdf_telefone_emitente, " ;
               command.CommandText += "mdfe.mdf_email_emitente, " ;
               command.CommandText += "mdfe.mdf_qtd_nfe, " ;
               command.CommandText += "mdfe.mdf_valor_total_mercadoria, " ;
               command.CommandText += "mdfe.mdf_unidade_medida_peso_carga, " ;
               command.CommandText += "mdfe.mdf_peso_bruto_carga, " ;
               command.CommandText += "mdfe.mdf_info_addicional_fisco, " ;
               command.CommandText += "mdfe.mdf_info_adicional_contribuinte, " ;
               command.CommandText += "mdfe.version, " ;
               command.CommandText += "mdfe.entity_uid, " ;
               command.CommandText += "mdfe.mdf_data_hora_inicio_viagem, " ;
               command.CommandText += "mdfe.mdf_enviar_receita " ;
               }
               command.CommandText += " FROM  mdfe ";
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
                        orderByClause += " , mdf_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mdf_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = mdfe.id_acs_usuario_ultima_revisao ";
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
                     case "id_mdfe":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.id_mdfe " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.id_mdfe) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_serie":
                     case "Serie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_chave_acesso":
                     case "ChaveAcesso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_chave_acesso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_chave_acesso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_dv_chave_acesso":
                     case "DvChaveAcesso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_dv_chave_acesso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_dv_chave_acesso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_versao":
                     case "Versao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_versao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_versao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_cod_ibge_uf_emitente":
                     case "CodIbgeUfEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_cod_ibge_uf_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_cod_ibge_uf_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_tipo_ambiente":
                     case "TipoAmbiente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_tipo_ambiente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_tipo_ambiente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_tipo_emitente":
                     case "TipoEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_tipo_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_tipo_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_modelo_manifesto":
                     case "ModeloManifesto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_modelo_manifesto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_modelo_manifesto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_modalidade_transporte":
                     case "ModalidadeTransporte":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_modalidade_transporte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_modalidade_transporte) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_data_emissao":
                     case "DataEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_data_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_data_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_forma_emissao":
                     case "FormaEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_forma_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_forma_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_processo_emissao":
                     case "ProcessoEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_processo_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_processo_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_versao_aplicativo":
                     case "VersaoAplicativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_versao_aplicativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_versao_aplicativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_uf_carregamento":
                     case "UfCarregamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_uf_carregamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_uf_carregamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_uf_descarregamento":
                     case "UfDescarregamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_uf_descarregamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_uf_descarregamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_cnpj_emitente":
                     case "CnpjEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_cnpj_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_cnpj_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_ie_emitente":
                     case "IeEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_ie_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_ie_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_razao_emitente":
                     case "RazaoEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_razao_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_razao_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_nome_fantasia_emitente":
                     case "NomeFantasiaEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_nome_fantasia_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_nome_fantasia_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_logradouro_emitente":
                     case "LogradouroEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_logradouro_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_logradouro_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_numero_endereco_emitente":
                     case "NumeroEnderecoEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_numero_endereco_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_numero_endereco_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_complemento_endereco_emitente":
                     case "ComplementoEnderecoEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_complemento_endereco_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_complemento_endereco_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_bairro_emitente":
                     case "BairroEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_bairro_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_bairro_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_codigo_ibge_municipio_emitente":
                     case "CodigoIbgeMunicipioEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_codigo_ibge_municipio_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_codigo_ibge_municipio_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_municipio_emitente":
                     case "MunicipioEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_municipio_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_municipio_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_cep_emitente":
                     case "CepEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_cep_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_cep_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_uf_emitente":
                     case "UfEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_uf_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_uf_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_telefone_emitente":
                     case "TelefoneEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_telefone_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_telefone_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_email_emitente":
                     case "EmailEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_email_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_email_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_qtd_nfe":
                     case "QtdNfe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_qtd_nfe " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_qtd_nfe) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_valor_total_mercadoria":
                     case "ValorTotalMercadoria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_valor_total_mercadoria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_valor_total_mercadoria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_unidade_medida_peso_carga":
                     case "UnidadeMedidaPesoCarga":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_unidade_medida_peso_carga " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_unidade_medida_peso_carga) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_peso_bruto_carga":
                     case "PesoBrutoCarga":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_peso_bruto_carga " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_peso_bruto_carga) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_info_addicional_fisco":
                     case "InfoAddicionalFisco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_info_addicional_fisco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_info_addicional_fisco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_info_adicional_contribuinte":
                     case "InfoAdicionalContribuinte":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.mdf_info_adicional_contribuinte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.mdf_info_adicional_contribuinte) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , mdfe.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_data_hora_inicio_viagem":
                     case "DataHoraInicioViagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_data_hora_inicio_viagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_data_hora_inicio_viagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdf_enviar_receita":
                     case "EnviarReceita":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe.mdf_enviar_receita " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe.mdf_enviar_receita) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_chave_acesso")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_chave_acesso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_chave_acesso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_versao")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_versao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_versao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_versao_aplicativo")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_versao_aplicativo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_versao_aplicativo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_uf_carregamento")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_uf_carregamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_uf_carregamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_uf_descarregamento")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_uf_descarregamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_uf_descarregamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_cnpj_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_cnpj_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_cnpj_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_ie_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_ie_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_ie_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_razao_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_razao_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_razao_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_nome_fantasia_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_nome_fantasia_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_nome_fantasia_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_logradouro_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_logradouro_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_logradouro_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_numero_endereco_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_numero_endereco_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_numero_endereco_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_complemento_endereco_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_complemento_endereco_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_complemento_endereco_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_bairro_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_bairro_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_bairro_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_municipio_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_municipio_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_municipio_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_uf_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_uf_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_uf_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_email_emitente")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_email_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_email_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_info_addicional_fisco")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_info_addicional_fisco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_info_addicional_fisco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdf_info_adicional_contribuinte")) 
                        {
                           whereClause += " OR UPPER(mdfe.mdf_info_adicional_contribuinte) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.mdf_info_adicional_contribuinte) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(mdfe.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_mdfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.id_mdfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.id_mdfe = :mdfe_ID_9469 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_ID_9469", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "mdf_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_numero = :mdfe_Numero_4362 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_Numero_4362", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Serie" || parametro.FieldName == "mdf_serie")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_serie = :mdfe_Serie_3241 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_Serie_3241", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "mdf_codigo")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_codigo = :mdfe_Codigo_5130 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_Codigo_5130", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveAcesso" || parametro.FieldName == "mdf_chave_acesso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_chave_acesso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_chave_acesso LIKE :mdfe_ChaveAcesso_4985 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_ChaveAcesso_4985", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvChaveAcesso" || parametro.FieldName == "mdf_dv_chave_acesso")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_dv_chave_acesso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_dv_chave_acesso = :mdfe_DvChaveAcesso_9968 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_DvChaveAcesso_9968", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Versao" || parametro.FieldName == "mdf_versao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_versao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_versao LIKE :mdfe_Versao_7123 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_Versao_7123", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodIbgeUfEmitente" || parametro.FieldName == "mdf_cod_ibge_uf_emitente")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_cod_ibge_uf_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_cod_ibge_uf_emitente = :mdfe_CodIbgeUfEmitente_1328 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_CodIbgeUfEmitente_1328", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoAmbiente" || parametro.FieldName == "mdf_tipo_ambiente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeTipoAmbiente)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeTipoAmbiente");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_tipo_ambiente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_tipo_ambiente = :mdfe_TipoAmbiente_6422 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_TipoAmbiente_6422", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoEmitente" || parametro.FieldName == "mdf_tipo_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeTipoEmitente)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeTipoEmitente");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_tipo_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_tipo_emitente = :mdfe_TipoEmitente_207 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_TipoEmitente_207", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloManifesto" || parametro.FieldName == "mdf_modelo_manifesto")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_modelo_manifesto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_modelo_manifesto = :mdfe_ModeloManifesto_2116 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_ModeloManifesto_2116", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeTransporte" || parametro.FieldName == "mdf_modalidade_transporte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeModalidadeTransporte)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeModalidadeTransporte");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_modalidade_transporte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_modalidade_transporte = :mdfe_ModalidadeTransporte_6132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_ModalidadeTransporte_6132", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEmissao" || parametro.FieldName == "mdf_data_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_data_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_data_emissao = :mdfe_DataEmissao_8531 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_DataEmissao_8531", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FormaEmissao" || parametro.FieldName == "mdf_forma_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeFormaEmissao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeFormaEmissao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_forma_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_forma_emissao = :mdfe_FormaEmissao_6330 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_FormaEmissao_6330", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProcessoEmissao" || parametro.FieldName == "mdf_processo_emissao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_processo_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_processo_emissao = :mdfe_ProcessoEmissao_7082 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_ProcessoEmissao_7082", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoAplicativo" || parametro.FieldName == "mdf_versao_aplicativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_versao_aplicativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_versao_aplicativo LIKE :mdfe_VersaoAplicativo_2822 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_VersaoAplicativo_2822", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfCarregamento" || parametro.FieldName == "mdf_uf_carregamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_uf_carregamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_uf_carregamento LIKE :mdfe_UfCarregamento_2175 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_UfCarregamento_2175", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfDescarregamento" || parametro.FieldName == "mdf_uf_descarregamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_uf_descarregamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_uf_descarregamento LIKE :mdfe_UfDescarregamento_2394 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_UfDescarregamento_2394", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjEmitente" || parametro.FieldName == "mdf_cnpj_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_cnpj_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_cnpj_emitente LIKE :mdfe_CnpjEmitente_8898 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_CnpjEmitente_8898", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeEmitente" || parametro.FieldName == "mdf_ie_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_ie_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_ie_emitente LIKE :mdfe_IeEmitente_4784 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_IeEmitente_4784", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RazaoEmitente" || parametro.FieldName == "mdf_razao_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_razao_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_razao_emitente LIKE :mdfe_RazaoEmitente_2837 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_RazaoEmitente_2837", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeFantasiaEmitente" || parametro.FieldName == "mdf_nome_fantasia_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_nome_fantasia_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_nome_fantasia_emitente LIKE :mdfe_NomeFantasiaEmitente_970 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_NomeFantasiaEmitente_970", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LogradouroEmitente" || parametro.FieldName == "mdf_logradouro_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_logradouro_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_logradouro_emitente LIKE :mdfe_LogradouroEmitente_2352 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_LogradouroEmitente_2352", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroEnderecoEmitente" || parametro.FieldName == "mdf_numero_endereco_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_numero_endereco_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_numero_endereco_emitente LIKE :mdfe_NumeroEnderecoEmitente_1541 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_NumeroEnderecoEmitente_1541", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ComplementoEnderecoEmitente" || parametro.FieldName == "mdf_complemento_endereco_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_complemento_endereco_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_complemento_endereco_emitente LIKE :mdfe_ComplementoEnderecoEmitente_3449 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_ComplementoEnderecoEmitente_3449", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BairroEmitente" || parametro.FieldName == "mdf_bairro_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_bairro_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_bairro_emitente LIKE :mdfe_BairroEmitente_9763 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_BairroEmitente_9763", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoIbgeMunicipioEmitente" || parametro.FieldName == "mdf_codigo_ibge_municipio_emitente")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_codigo_ibge_municipio_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_codigo_ibge_municipio_emitente = :mdfe_CodigoIbgeMunicipioEmitente_5445 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_CodigoIbgeMunicipioEmitente_5445", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MunicipioEmitente" || parametro.FieldName == "mdf_municipio_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_municipio_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_municipio_emitente LIKE :mdfe_MunicipioEmitente_9150 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_MunicipioEmitente_9150", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CepEmitente" || parametro.FieldName == "mdf_cep_emitente")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_cep_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_cep_emitente = :mdfe_CepEmitente_6692 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_CepEmitente_6692", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfEmitente" || parametro.FieldName == "mdf_uf_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_uf_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_uf_emitente LIKE :mdfe_UfEmitente_6743 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_UfEmitente_6743", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TelefoneEmitente" || parametro.FieldName == "mdf_telefone_emitente")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_telefone_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_telefone_emitente = :mdfe_TelefoneEmitente_5360 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_TelefoneEmitente_5360", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailEmitente" || parametro.FieldName == "mdf_email_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_email_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_email_emitente LIKE :mdfe_EmailEmitente_9056 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_EmailEmitente_9056", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdNfe" || parametro.FieldName == "mdf_qtd_nfe")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_qtd_nfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_qtd_nfe = :mdfe_QtdNfe_4467 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_QtdNfe_4467", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalMercadoria" || parametro.FieldName == "mdf_valor_total_mercadoria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_valor_total_mercadoria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_valor_total_mercadoria = :mdfe_ValorTotalMercadoria_1453 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_ValorTotalMercadoria_1453", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaPesoCarga" || parametro.FieldName == "mdf_unidade_medida_peso_carga")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeUnidadeMedidaPeso)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeUnidadeMedidaPeso");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_unidade_medida_peso_carga IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_unidade_medida_peso_carga = :mdfe_UnidadeMedidaPesoCarga_1007 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_UnidadeMedidaPesoCarga_1007", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PesoBrutoCarga" || parametro.FieldName == "mdf_peso_bruto_carga")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_peso_bruto_carga IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_peso_bruto_carga = :mdfe_PesoBrutoCarga_4605 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_PesoBrutoCarga_4605", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InfoAddicionalFisco" || parametro.FieldName == "mdf_info_addicional_fisco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_info_addicional_fisco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_info_addicional_fisco LIKE :mdfe_InfoAddicionalFisco_3004 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_InfoAddicionalFisco_3004", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InfoAdicionalContribuinte" || parametro.FieldName == "mdf_info_adicional_contribuinte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_info_adicional_contribuinte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_info_adicional_contribuinte LIKE :mdfe_InfoAdicionalContribuinte_1936 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_InfoAdicionalContribuinte_1936", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  mdfe.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.version = :mdfe_Version_441 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_Version_441", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.entity_uid LIKE :mdfe_EntityUid_6156 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_EntityUid_6156", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataHoraInicioViagem" || parametro.FieldName == "mdf_data_hora_inicio_viagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_data_hora_inicio_viagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_data_hora_inicio_viagem = :mdfe_DataHoraInicioViagem_2646 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_DataHoraInicioViagem_2646", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnviarReceita" || parametro.FieldName == "mdf_enviar_receita")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_enviar_receita IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_enviar_receita = :mdfe_EnviarReceita_9183 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_EnviarReceita_9183", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveAcessoExato" || parametro.FieldName == "ChaveAcessoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_chave_acesso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_chave_acesso LIKE :mdfe_ChaveAcesso_7844 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_ChaveAcesso_7844", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoExato" || parametro.FieldName == "VersaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_versao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_versao LIKE :mdfe_Versao_1418 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_Versao_1418", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoAplicativoExato" || parametro.FieldName == "VersaoAplicativoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_versao_aplicativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_versao_aplicativo LIKE :mdfe_VersaoAplicativo_2048 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_VersaoAplicativo_2048", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfCarregamentoExato" || parametro.FieldName == "UfCarregamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_uf_carregamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_uf_carregamento LIKE :mdfe_UfCarregamento_9540 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_UfCarregamento_9540", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfDescarregamentoExato" || parametro.FieldName == "UfDescarregamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_uf_descarregamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_uf_descarregamento LIKE :mdfe_UfDescarregamento_5779 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_UfDescarregamento_5779", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjEmitenteExato" || parametro.FieldName == "CnpjEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_cnpj_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_cnpj_emitente LIKE :mdfe_CnpjEmitente_147 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_CnpjEmitente_147", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeEmitenteExato" || parametro.FieldName == "IeEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_ie_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_ie_emitente LIKE :mdfe_IeEmitente_9290 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_IeEmitente_9290", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RazaoEmitenteExato" || parametro.FieldName == "RazaoEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_razao_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_razao_emitente LIKE :mdfe_RazaoEmitente_4519 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_RazaoEmitente_4519", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeFantasiaEmitenteExato" || parametro.FieldName == "NomeFantasiaEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_nome_fantasia_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_nome_fantasia_emitente LIKE :mdfe_NomeFantasiaEmitente_8698 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_NomeFantasiaEmitente_8698", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LogradouroEmitenteExato" || parametro.FieldName == "LogradouroEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_logradouro_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_logradouro_emitente LIKE :mdfe_LogradouroEmitente_8464 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_LogradouroEmitente_8464", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroEnderecoEmitenteExato" || parametro.FieldName == "NumeroEnderecoEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_numero_endereco_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_numero_endereco_emitente LIKE :mdfe_NumeroEnderecoEmitente_4045 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_NumeroEnderecoEmitente_4045", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ComplementoEnderecoEmitenteExato" || parametro.FieldName == "ComplementoEnderecoEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_complemento_endereco_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_complemento_endereco_emitente LIKE :mdfe_ComplementoEnderecoEmitente_4351 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_ComplementoEnderecoEmitente_4351", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BairroEmitenteExato" || parametro.FieldName == "BairroEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_bairro_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_bairro_emitente LIKE :mdfe_BairroEmitente_8738 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_BairroEmitente_8738", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MunicipioEmitenteExato" || parametro.FieldName == "MunicipioEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_municipio_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_municipio_emitente LIKE :mdfe_MunicipioEmitente_8500 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_MunicipioEmitente_8500", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfEmitenteExato" || parametro.FieldName == "UfEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_uf_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_uf_emitente LIKE :mdfe_UfEmitente_2011 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_UfEmitente_2011", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailEmitenteExato" || parametro.FieldName == "EmailEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_email_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_email_emitente LIKE :mdfe_EmailEmitente_1700 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_EmailEmitente_1700", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InfoAddicionalFiscoExato" || parametro.FieldName == "InfoAddicionalFiscoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_info_addicional_fisco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_info_addicional_fisco LIKE :mdfe_InfoAddicionalFisco_1681 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_InfoAddicionalFisco_1681", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InfoAdicionalContribuinteExato" || parametro.FieldName == "InfoAdicionalContribuinteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe.mdf_info_adicional_contribuinte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.mdf_info_adicional_contribuinte LIKE :mdfe_InfoAdicionalContribuinte_5221 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_InfoAdicionalContribuinte_5221", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe.entity_uid LIKE :mdfe_EntityUid_4523 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_EntityUid_4523", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MdfeClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MdfeClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MdfeClass), Convert.ToInt32(read["id_mdfe"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MdfeClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_mdfe"]);
                     entidade.Numero = (int)read["mdf_numero"];
                     entidade.Serie = (int)read["mdf_serie"];
                     entidade.Codigo = (int)read["mdf_codigo"];
                     entidade.ChaveAcesso = (read["mdf_chave_acesso"] != DBNull.Value ? read["mdf_chave_acesso"].ToString() : null);
                     entidade.DvChaveAcesso = (int)read["mdf_dv_chave_acesso"];
                     entidade.Versao = (read["mdf_versao"] != DBNull.Value ? read["mdf_versao"].ToString() : null);
                     entidade.CodIbgeUfEmitente = (int)read["mdf_cod_ibge_uf_emitente"];
                     entidade.TipoAmbiente = (MDFeTipoAmbiente) (read["mdf_tipo_ambiente"] != DBNull.Value ? Enum.ToObject(typeof(MDFeTipoAmbiente), read["mdf_tipo_ambiente"]) : null);
                     entidade.TipoEmitente = (MDFeTipoEmitente) (read["mdf_tipo_emitente"] != DBNull.Value ? Enum.ToObject(typeof(MDFeTipoEmitente), read["mdf_tipo_emitente"]) : null);
                     entidade.ModeloManifesto = (int)read["mdf_modelo_manifesto"];
                     entidade.ModalidadeTransporte = (MDFeModalidadeTransporte) (read["mdf_modalidade_transporte"] != DBNull.Value ? Enum.ToObject(typeof(MDFeModalidadeTransporte), read["mdf_modalidade_transporte"]) : null);
                     entidade.DataEmissao = (DateTime)read["mdf_data_emissao"];
                     entidade.FormaEmissao = (MDFeFormaEmissao) (read["mdf_forma_emissao"] != DBNull.Value ? Enum.ToObject(typeof(MDFeFormaEmissao), read["mdf_forma_emissao"]) : null);
                     entidade.ProcessoEmissao = (int)read["mdf_processo_emissao"];
                     entidade.VersaoAplicativo = (read["mdf_versao_aplicativo"] != DBNull.Value ? read["mdf_versao_aplicativo"].ToString() : null);
                     entidade.UfCarregamento = (read["mdf_uf_carregamento"] != DBNull.Value ? read["mdf_uf_carregamento"].ToString() : null);
                     entidade.UfDescarregamento = (read["mdf_uf_descarregamento"] != DBNull.Value ? read["mdf_uf_descarregamento"].ToString() : null);
                     entidade.CnpjEmitente = (read["mdf_cnpj_emitente"] != DBNull.Value ? read["mdf_cnpj_emitente"].ToString() : null);
                     entidade.IeEmitente = (read["mdf_ie_emitente"] != DBNull.Value ? read["mdf_ie_emitente"].ToString() : null);
                     entidade.RazaoEmitente = (read["mdf_razao_emitente"] != DBNull.Value ? read["mdf_razao_emitente"].ToString() : null);
                     entidade.NomeFantasiaEmitente = (read["mdf_nome_fantasia_emitente"] != DBNull.Value ? read["mdf_nome_fantasia_emitente"].ToString() : null);
                     entidade.LogradouroEmitente = (read["mdf_logradouro_emitente"] != DBNull.Value ? read["mdf_logradouro_emitente"].ToString() : null);
                     entidade.NumeroEnderecoEmitente = (read["mdf_numero_endereco_emitente"] != DBNull.Value ? read["mdf_numero_endereco_emitente"].ToString() : null);
                     entidade.ComplementoEnderecoEmitente = (read["mdf_complemento_endereco_emitente"] != DBNull.Value ? read["mdf_complemento_endereco_emitente"].ToString() : null);
                     entidade.BairroEmitente = (read["mdf_bairro_emitente"] != DBNull.Value ? read["mdf_bairro_emitente"].ToString() : null);
                     entidade.CodigoIbgeMunicipioEmitente = (int)read["mdf_codigo_ibge_municipio_emitente"];
                     entidade.MunicipioEmitente = (read["mdf_municipio_emitente"] != DBNull.Value ? read["mdf_municipio_emitente"].ToString() : null);
                     entidade.CepEmitente = read["mdf_cep_emitente"] as int?;
                     entidade.UfEmitente = (read["mdf_uf_emitente"] != DBNull.Value ? read["mdf_uf_emitente"].ToString() : null);
                     entidade.TelefoneEmitente = read["mdf_telefone_emitente"] as int?;
                     entidade.EmailEmitente = (read["mdf_email_emitente"] != DBNull.Value ? read["mdf_email_emitente"].ToString() : null);
                     entidade.QtdNfe = read["mdf_qtd_nfe"] as int?;
                     entidade.ValorTotalMercadoria = (double)read["mdf_valor_total_mercadoria"];
                     entidade.UnidadeMedidaPesoCarga = (MDFeUnidadeMedidaPeso) (read["mdf_unidade_medida_peso_carga"] != DBNull.Value ? Enum.ToObject(typeof(MDFeUnidadeMedidaPeso), read["mdf_unidade_medida_peso_carga"]) : null);
                     entidade.PesoBrutoCarga = (double)read["mdf_peso_bruto_carga"];
                     entidade.InfoAddicionalFisco = (read["mdf_info_addicional_fisco"] != DBNull.Value ? read["mdf_info_addicional_fisco"].ToString() : null);
                     entidade.InfoAdicionalContribuinte = (read["mdf_info_adicional_contribuinte"] != DBNull.Value ? read["mdf_info_adicional_contribuinte"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.DataHoraInicioViagem = read["mdf_data_hora_inicio_viagem"] as DateTime?;
                     entidade.EnviarReceita = Convert.ToBoolean(Convert.ToInt16(read["mdf_enviar_receita"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MdfeClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
