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
     [Table("cob_boleto","bol")]
     public class CobBoletoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do CobBoletoClass";
protected const string ErroDelete = "Erro ao excluir o CobBoletoClass  ";
protected const string ErroSave = "Erro ao salvar o CobBoletoClass.";
protected const string ErroCollectionCobBoletoHistoricoClassCobBoleto = "Erro ao carregar a coleção de CobBoletoHistoricoClass.";
protected const string ErroCollectionCobBoletoInstrucoesClassCobBoleto = "Erro ao carregar a coleção de CobBoletoInstrucoesClass.";
protected const string ErroCollectionCobBoletoRetornoClassCobBoleto = "Erro ao carregar a coleção de CobBoletoRetornoClass.";
protected const string ErroCollectionContaReceberBoletoClassCobBoleto = "Erro ao carregar a coleção de ContaReceberBoletoClass.";
protected const string ErroNossoNumeroObrigatorio = "O campo NossoNumero é obrigatório";
protected const string ErroNossoNumeroComprimento = "O campo NossoNumero deve ter no máximo 100 caracteres";
protected const string ErroDvNossoNumeroObrigatorio = "O campo DvNossoNumero é obrigatório";
protected const string ErroDvNossoNumeroComprimento = "O campo DvNossoNumero deve ter no máximo 1 caracteres";
protected const string ErroAgenciaObrigatorio = "O campo Agencia é obrigatório";
protected const string ErroAgenciaComprimento = "O campo Agencia deve ter no máximo 100 caracteres";
protected const string ErroNumeroContaObrigatorio = "O campo NumeroConta é obrigatório";
protected const string ErroNumeroContaComprimento = "O campo NumeroConta deve ter no máximo 100 caracteres";
protected const string ErroDvContaObrigatorio = "O campo DvConta é obrigatório";
protected const string ErroDvContaComprimento = "O campo DvConta deve ter no máximo 1 caracteres";
protected const string ErroEspecieObrigatorio = "O campo Especie é obrigatório";
protected const string ErroEspecieComprimento = "O campo Especie deve ter no máximo 2 caracteres";
protected const string ErroAceiteObrigatorio = "O campo Aceite é obrigatório";
protected const string ErroAceiteComprimento = "O campo Aceite deve ter no máximo 1 caracteres";
protected const string ErroSacadoNumeroDocumentoObrigatorio = "O campo SacadoNumeroDocumento é obrigatório";
protected const string ErroSacadoNumeroDocumentoComprimento = "O campo SacadoNumeroDocumento deve ter no máximo 20 caracteres";
protected const string ErroSacadoNomeObrigatorio = "O campo SacadoNome é obrigatório";
protected const string ErroSacadoNomeComprimento = "O campo SacadoNome deve ter no máximo 255 caracteres";
protected const string ErroSacadoLogradouroObrigatorio = "O campo SacadoLogradouro é obrigatório";
protected const string ErroSacadoLogradouroComprimento = "O campo SacadoLogradouro deve ter no máximo 40 caracteres";
protected const string ErroSacadoRuaObrigatorio = "O campo SacadoRua é obrigatório";
protected const string ErroSacadoRuaComprimento = "O campo SacadoRua deve ter no máximo 255 caracteres";
protected const string ErroSacadoNumeroEnderecoObrigatorio = "O campo SacadoNumeroEndereco é obrigatório";
protected const string ErroSacadoNumeroEnderecoComprimento = "O campo SacadoNumeroEndereco deve ter no máximo 20 caracteres";
protected const string ErroSacadoBairroObrigatorio = "O campo SacadoBairro é obrigatório";
protected const string ErroSacadoBairroComprimento = "O campo SacadoBairro deve ter no máximo 50 caracteres";
protected const string ErroSacadoCepObrigatorio = "O campo SacadoCep é obrigatório";
protected const string ErroSacadoCepComprimento = "O campo SacadoCep deve ter no máximo 8 caracteres";
protected const string ErroCidadeSacadoObrigatorio = "O campo CidadeSacado é obrigatório";
protected const string ErroCidadeSacadoComprimento = "O campo CidadeSacado deve ter no máximo 50 caracteres";
protected const string ErroUfSacadoObrigatorio = "O campo UfSacado é obrigatório";
protected const string ErroUfSacadoComprimento = "O campo UfSacado deve ter no máximo 2 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do CobBoletoClass.";
protected const string MensagemUtilizadoCollectionCobBoletoHistoricoClassCobBoleto =  "A entidade CobBoletoClass está sendo utilizada nos seguintes CobBoletoHistoricoClass:";
protected const string MensagemUtilizadoCollectionCobBoletoInstrucoesClassCobBoleto =  "A entidade CobBoletoClass está sendo utilizada nos seguintes CobBoletoInstrucoesClass:";
protected const string MensagemUtilizadoCollectionCobBoletoRetornoClassCobBoleto =  "A entidade CobBoletoClass está sendo utilizada nos seguintes CobBoletoRetornoClass:";
protected const string MensagemUtilizadoCollectionContaReceberBoletoClassCobBoleto =  "A entidade CobBoletoClass está sendo utilizada nos seguintes ContaReceberBoletoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade CobBoletoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.CobRemessaClass _cobRemessaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CobRemessaClass _cobRemessaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CobRemessaClass _valueCobRemessa;
        [Column("id_cob_remessa", "cob_remessa", "id_cob_remessa")]
       public virtual BibliotecaEntidades.Entidades.CobRemessaClass CobRemessa
        { 
           get {                 return this._valueCobRemessa; } 
           set 
           { 
                if (this._valueCobRemessa == value)return;
                 this._valueCobRemessa = value; 
           } 
       } 

       protected CobrancaStatusBoleto _statusOriginal{get;private set;}
       private CobrancaStatusBoleto _statusOriginalCommited{get; set;}
        private CobrancaStatusBoleto _valueStatus;
         [Column("bol_status")]
        public virtual CobrancaStatusBoleto Status
         { 
            get { return this._valueStatus; } 
            set 
            { 
                if (this._valueStatus == value)return;
                 this._valueStatus = value; 
            } 
        } 

        public bool Status_GeradoNaoEnviado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.CobrancaStatusBoleto.GeradoNaoEnviado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.CobrancaStatusBoleto.GeradoNaoEnviado; }
         } 

        public bool Status_EnviadoAgConfirmacao
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.CobrancaStatusBoleto.EnviadoAgConfirmacao; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.CobrancaStatusBoleto.EnviadoAgConfirmacao; }
         } 

        public bool Status_ConfirmadoEmCarteira
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.CobrancaStatusBoleto.ConfirmadoEmCarteira; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.CobrancaStatusBoleto.ConfirmadoEmCarteira; }
         } 

        public bool Status_Rejeitado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.CobrancaStatusBoleto.Rejeitado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.CobrancaStatusBoleto.Rejeitado; }
         } 

        public bool Status_Pago
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.CobrancaStatusBoleto.Pago; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.CobrancaStatusBoleto.Pago; }
         } 

        public bool Status_Cancelado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.CobrancaStatusBoleto.Cancelado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.CobrancaStatusBoleto.Cancelado; }
         } 

       protected string _numeroDocumentoOriginal{get;private set;}
       private string _numeroDocumentoOriginalCommited{get; set;}
        private string _valueNumeroDocumento;
         [Column("bol_numero_documento")]
        public virtual string NumeroDocumento
         { 
            get { return this._valueNumeroDocumento; } 
            set 
            { 
                if (this._valueNumeroDocumento == value)return;
                 this._valueNumeroDocumento = value; 
            } 
        } 

       protected DateTime _dataVencimentoOriginal{get;private set;}
       private DateTime _dataVencimentoOriginalCommited{get; set;}
        private DateTime _valueDataVencimento;
         [Column("bol_data_vencimento")]
        public virtual DateTime DataVencimento
         { 
            get { return this._valueDataVencimento; } 
            set 
            { 
                if (this._valueDataVencimento == value)return;
                 this._valueDataVencimento = value; 
            } 
        } 

       protected double _valorTituloOriginal{get;private set;}
       private double _valorTituloOriginalCommited{get; set;}
        private double _valueValorTitulo;
         [Column("bol_valor_titulo")]
        public virtual double ValorTitulo
         { 
            get { return this._valueValorTitulo; } 
            set 
            { 
                if (this._valueValorTitulo == value)return;
                 this._valueValorTitulo = value; 
            } 
        } 

       protected int _idTituloSistemaOriginal{get;private set;}
       private int _idTituloSistemaOriginalCommited{get; set;}
        private int _valueIdTituloSistema;
         [Column("id_titulo_sistema")]
        public virtual int IdTituloSistema
         { 
            get { return this._valueIdTituloSistema; } 
            set 
            { 
                if (this._valueIdTituloSistema == value)return;
                 this._valueIdTituloSistema = value; 
            } 
        } 

       protected string _nossoNumeroOriginal{get;private set;}
       private string _nossoNumeroOriginalCommited{get; set;}
        private string _valueNossoNumero;
         [Column("bol_nosso_numero")]
        public virtual string NossoNumero
         { 
            get { return this._valueNossoNumero; } 
            set 
            { 
                if (this._valueNossoNumero == value)return;
                 this._valueNossoNumero = value; 
            } 
        } 

       protected string _dvNossoNumeroOriginal{get;private set;}
       private string _dvNossoNumeroOriginalCommited{get; set;}
        private string _valueDvNossoNumero;
         [Column("bol_dv_nosso_numero")]
        public virtual string DvNossoNumero
         { 
            get { return this._valueDvNossoNumero; } 
            set 
            { 
                if (this._valueDvNossoNumero == value)return;
                 this._valueDvNossoNumero = value; 
            } 
        } 

       protected DateTime _dataEmissaoOriginal{get;private set;}
       private DateTime _dataEmissaoOriginalCommited{get; set;}
        private DateTime _valueDataEmissao;
         [Column("bol_data_emissao")]
        public virtual DateTime DataEmissao
         { 
            get { return this._valueDataEmissao; } 
            set 
            { 
                if (this._valueDataEmissao == value)return;
                 this._valueDataEmissao = value; 
            } 
        } 

       protected string _agenciaOriginal{get;private set;}
       private string _agenciaOriginalCommited{get; set;}
        private string _valueAgencia;
         [Column("bol_agencia")]
        public virtual string Agencia
         { 
            get { return this._valueAgencia; } 
            set 
            { 
                if (this._valueAgencia == value)return;
                 this._valueAgencia = value; 
            } 
        } 

       protected string _dvAgenciaOriginal{get;private set;}
       private string _dvAgenciaOriginalCommited{get; set;}
        private string _valueDvAgencia;
         [Column("bol_dv_agencia")]
        public virtual string DvAgencia
         { 
            get { return this._valueDvAgencia; } 
            set 
            { 
                if (this._valueDvAgencia == value)return;
                 this._valueDvAgencia = value; 
            } 
        } 

       protected string _numeroContaOriginal{get;private set;}
       private string _numeroContaOriginalCommited{get; set;}
        private string _valueNumeroConta;
         [Column("bol_numero_conta")]
        public virtual string NumeroConta
         { 
            get { return this._valueNumeroConta; } 
            set 
            { 
                if (this._valueNumeroConta == value)return;
                 this._valueNumeroConta = value; 
            } 
        } 

       protected string _dvContaOriginal{get;private set;}
       private string _dvContaOriginalCommited{get; set;}
        private string _valueDvConta;
         [Column("bol_dv_conta")]
        public virtual string DvConta
         { 
            get { return this._valueDvConta; } 
            set 
            { 
                if (this._valueDvConta == value)return;
                 this._valueDvConta = value; 
            } 
        } 

       protected string _carteiraOriginal{get;private set;}
       private string _carteiraOriginalCommited{get; set;}
        private string _valueCarteira;
         [Column("bol_carteira")]
        public virtual string Carteira
         { 
            get { return this._valueCarteira; } 
            set 
            { 
                if (this._valueCarteira == value)return;
                 this._valueCarteira = value; 
            } 
        } 

       protected string _codigoCarteiraOriginal{get;private set;}
       private string _codigoCarteiraOriginalCommited{get; set;}
        private string _valueCodigoCarteira;
         [Column("bol_codigo_carteira")]
        public virtual string CodigoCarteira
         { 
            get { return this._valueCodigoCarteira; } 
            set 
            { 
                if (this._valueCodigoCarteira == value)return;
                 this._valueCodigoCarteira = value; 
            } 
        } 

       protected string _especieOriginal{get;private set;}
       private string _especieOriginalCommited{get; set;}
        private string _valueEspecie;
         [Column("bol_especie")]
        public virtual string Especie
         { 
            get { return this._valueEspecie; } 
            set 
            { 
                if (this._valueEspecie == value)return;
                 this._valueEspecie = value; 
            } 
        } 

       protected string _aceiteOriginal{get;private set;}
       private string _aceiteOriginalCommited{get; set;}
        private string _valueAceite;
         [Column("bol_aceite")]
        public virtual string Aceite
         { 
            get { return this._valueAceite; } 
            set 
            { 
                if (this._valueAceite == value)return;
                 this._valueAceite = value; 
            } 
        } 

       protected double _jurosPorDiaOriginal{get;private set;}
       private double _jurosPorDiaOriginalCommited{get; set;}
        private double _valueJurosPorDia;
         [Column("bol_juros_por_dia")]
        public virtual double JurosPorDia
         { 
            get { return this._valueJurosPorDia; } 
            set 
            { 
                if (this._valueJurosPorDia == value)return;
                 this._valueJurosPorDia = value; 
            } 
        } 

       protected DateTime? _dataLimiteDescontoOriginal{get;private set;}
       private DateTime? _dataLimiteDescontoOriginalCommited{get; set;}
        private DateTime? _valueDataLimiteDesconto;
         [Column("bol_data_limite_desconto")]
        public virtual DateTime? DataLimiteDesconto
         { 
            get { return this._valueDataLimiteDesconto; } 
            set 
            { 
                if (this._valueDataLimiteDesconto == value)return;
                 this._valueDataLimiteDesconto = value; 
            } 
        } 

       protected double _valorDescontoOriginal{get;private set;}
       private double _valorDescontoOriginalCommited{get; set;}
        private double _valueValorDesconto;
         [Column("bol_valor_desconto")]
        public virtual double ValorDesconto
         { 
            get { return this._valueValorDesconto; } 
            set 
            { 
                if (this._valueValorDesconto == value)return;
                 this._valueValorDesconto = value; 
            } 
        } 

       protected double _valorAbatimentoOriginal{get;private set;}
       private double _valorAbatimentoOriginalCommited{get; set;}
        private double _valueValorAbatimento;
         [Column("bol_valor_abatimento")]
        public virtual double ValorAbatimento
         { 
            get { return this._valueValorAbatimento; } 
            set 
            { 
                if (this._valueValorAbatimento == value)return;
                 this._valueValorAbatimento = value; 
            } 
        } 

       protected double _valorIofOriginal{get;private set;}
       private double _valorIofOriginalCommited{get; set;}
        private double _valueValorIof;
         [Column("bol_valor_iof")]
        public virtual double ValorIof
         { 
            get { return this._valueValorIof; } 
            set 
            { 
                if (this._valueValorIof == value)return;
                 this._valueValorIof = value; 
            } 
        } 

       protected CobrancaTipoDocumento _sacadoTipoDocumentoOriginal{get;private set;}
       private CobrancaTipoDocumento _sacadoTipoDocumentoOriginalCommited{get; set;}
        private CobrancaTipoDocumento _valueSacadoTipoDocumento;
         [Column("bol_sacado_tipo_documento")]
        public virtual CobrancaTipoDocumento SacadoTipoDocumento
         { 
            get { return this._valueSacadoTipoDocumento; } 
            set 
            { 
                if (this._valueSacadoTipoDocumento == value)return;
                 this._valueSacadoTipoDocumento = value; 
            } 
        } 

        public bool SacadoTipoDocumento_CPF
         { 
            get { return this._valueSacadoTipoDocumento == BibliotecaEntidades.Base.CobrancaTipoDocumento.CPF; } 
            set { if (value) this._valueSacadoTipoDocumento = BibliotecaEntidades.Base.CobrancaTipoDocumento.CPF; }
         } 

        public bool SacadoTipoDocumento_CNPJ
         { 
            get { return this._valueSacadoTipoDocumento == BibliotecaEntidades.Base.CobrancaTipoDocumento.CNPJ; } 
            set { if (value) this._valueSacadoTipoDocumento = BibliotecaEntidades.Base.CobrancaTipoDocumento.CNPJ; }
         } 

       protected string _sacadoNumeroDocumentoOriginal{get;private set;}
       private string _sacadoNumeroDocumentoOriginalCommited{get; set;}
        private string _valueSacadoNumeroDocumento;
         [Column("bol_sacado_numero_documento")]
        public virtual string SacadoNumeroDocumento
         { 
            get { return this._valueSacadoNumeroDocumento; } 
            set 
            { 
                if (this._valueSacadoNumeroDocumento == value)return;
                 this._valueSacadoNumeroDocumento = value; 
            } 
        } 

       protected string _sacadoNomeOriginal{get;private set;}
       private string _sacadoNomeOriginalCommited{get; set;}
        private string _valueSacadoNome;
         [Column("bol_sacado_nome")]
        public virtual string SacadoNome
         { 
            get { return this._valueSacadoNome; } 
            set 
            { 
                if (this._valueSacadoNome == value)return;
                 this._valueSacadoNome = value; 
            } 
        } 

       protected string _sacadoLogradouroOriginal{get;private set;}
       private string _sacadoLogradouroOriginalCommited{get; set;}
        private string _valueSacadoLogradouro;
         [Column("bol_sacado_logradouro")]
        public virtual string SacadoLogradouro
         { 
            get { return this._valueSacadoLogradouro; } 
            set 
            { 
                if (this._valueSacadoLogradouro == value)return;
                 this._valueSacadoLogradouro = value; 
            } 
        } 

       protected string _sacadoRuaOriginal{get;private set;}
       private string _sacadoRuaOriginalCommited{get; set;}
        private string _valueSacadoRua;
         [Column("bol_sacado_rua")]
        public virtual string SacadoRua
         { 
            get { return this._valueSacadoRua; } 
            set 
            { 
                if (this._valueSacadoRua == value)return;
                 this._valueSacadoRua = value; 
            } 
        } 

       protected string _sacadoNumeroEnderecoOriginal{get;private set;}
       private string _sacadoNumeroEnderecoOriginalCommited{get; set;}
        private string _valueSacadoNumeroEndereco;
         [Column("bol_sacado_numero_endereco")]
        public virtual string SacadoNumeroEndereco
         { 
            get { return this._valueSacadoNumeroEndereco; } 
            set 
            { 
                if (this._valueSacadoNumeroEndereco == value)return;
                 this._valueSacadoNumeroEndereco = value; 
            } 
        } 

       protected string _sacadoComplementoEnderecoOriginal{get;private set;}
       private string _sacadoComplementoEnderecoOriginalCommited{get; set;}
        private string _valueSacadoComplementoEndereco;
         [Column("bol_sacado_complemento_endereco")]
        public virtual string SacadoComplementoEndereco
         { 
            get { return this._valueSacadoComplementoEndereco; } 
            set 
            { 
                if (this._valueSacadoComplementoEndereco == value)return;
                 this._valueSacadoComplementoEndereco = value; 
            } 
        } 

       protected string _sacadoBairroOriginal{get;private set;}
       private string _sacadoBairroOriginalCommited{get; set;}
        private string _valueSacadoBairro;
         [Column("bol_sacado_bairro")]
        public virtual string SacadoBairro
         { 
            get { return this._valueSacadoBairro; } 
            set 
            { 
                if (this._valueSacadoBairro == value)return;
                 this._valueSacadoBairro = value; 
            } 
        } 

       protected string _sacadoCepOriginal{get;private set;}
       private string _sacadoCepOriginalCommited{get; set;}
        private string _valueSacadoCep;
         [Column("bol_sacado_cep")]
        public virtual string SacadoCep
         { 
            get { return this._valueSacadoCep; } 
            set 
            { 
                if (this._valueSacadoCep == value)return;
                 this._valueSacadoCep = value; 
            } 
        } 

       protected string _cidadeSacadoOriginal{get;private set;}
       private string _cidadeSacadoOriginalCommited{get; set;}
        private string _valueCidadeSacado;
         [Column("bol_cidade_sacado")]
        public virtual string CidadeSacado
         { 
            get { return this._valueCidadeSacado; } 
            set 
            { 
                if (this._valueCidadeSacado == value)return;
                 this._valueCidadeSacado = value; 
            } 
        } 

       protected string _ufSacadoOriginal{get;private set;}
       private string _ufSacadoOriginalCommited{get; set;}
        private string _valueUfSacado;
         [Column("bol_uf_sacado")]
        public virtual string UfSacado
         { 
            get { return this._valueUfSacado; } 
            set 
            { 
                if (this._valueUfSacado == value)return;
                 this._valueUfSacado = value; 
            } 
        } 

       protected DateTime? _dataCancelamentoOriginal{get;private set;}
       private DateTime? _dataCancelamentoOriginalCommited{get; set;}
        private DateTime? _valueDataCancelamento;
         [Column("bol_data_cancelamento")]
        public virtual DateTime? DataCancelamento
         { 
            get { return this._valueDataCancelamento; } 
            set 
            { 
                if (this._valueDataCancelamento == value)return;
                 this._valueDataCancelamento = value; 
            } 
        } 

       protected DateTime? _dataBaixaOriginal{get;private set;}
       private DateTime? _dataBaixaOriginalCommited{get; set;}
        private DateTime? _valueDataBaixa;
         [Column("bol_data_baixa")]
        public virtual DateTime? DataBaixa
         { 
            get { return this._valueDataBaixa; } 
            set 
            { 
                if (this._valueDataBaixa == value)return;
                 this._valueDataBaixa = value; 
            } 
        } 

       protected DateTime _dataGeracaoOriginal{get;private set;}
       private DateTime _dataGeracaoOriginalCommited{get; set;}
        private DateTime _valueDataGeracao;
         [Column("bol_data_geracao")]
        public virtual DateTime DataGeracao
         { 
            get { return this._valueDataGeracao; } 
            set 
            { 
                if (this._valueDataGeracao == value)return;
                 this._valueDataGeracao = value; 
            } 
        } 

       private List<long> _collectionCobBoletoHistoricoClassCobBoletoOriginal;
       private List<Entidades.CobBoletoHistoricoClass > _collectionCobBoletoHistoricoClassCobBoletoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoHistoricoClassCobBoletoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoHistoricoClassCobBoletoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoHistoricoClassCobBoletoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CobBoletoHistoricoClass> _valueCollectionCobBoletoHistoricoClassCobBoleto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CobBoletoHistoricoClass> CollectionCobBoletoHistoricoClassCobBoleto 
       { 
           get { if(!_valueCollectionCobBoletoHistoricoClassCobBoletoLoaded && !this.DisableLoadCollection){this.LoadCollectionCobBoletoHistoricoClassCobBoleto();}
return this._valueCollectionCobBoletoHistoricoClassCobBoleto; } 
           set 
           { 
               this._valueCollectionCobBoletoHistoricoClassCobBoleto = value; 
               this._valueCollectionCobBoletoHistoricoClassCobBoletoLoaded = true; 
           } 
       } 

       private List<long> _collectionCobBoletoInstrucoesClassCobBoletoOriginal;
       private List<Entidades.CobBoletoInstrucoesClass > _collectionCobBoletoInstrucoesClassCobBoletoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoInstrucoesClassCobBoletoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoInstrucoesClassCobBoletoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CobBoletoInstrucoesClass> _valueCollectionCobBoletoInstrucoesClassCobBoleto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CobBoletoInstrucoesClass> CollectionCobBoletoInstrucoesClassCobBoleto 
       { 
           get { if(!_valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded && !this.DisableLoadCollection){this.LoadCollectionCobBoletoInstrucoesClassCobBoleto();}
return this._valueCollectionCobBoletoInstrucoesClassCobBoleto; } 
           set 
           { 
               this._valueCollectionCobBoletoInstrucoesClassCobBoleto = value; 
               this._valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded = true; 
           } 
       } 

       private List<long> _collectionCobBoletoRetornoClassCobBoletoOriginal;
       private List<Entidades.CobBoletoRetornoClass > _collectionCobBoletoRetornoClassCobBoletoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoRetornoClassCobBoletoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoRetornoClassCobBoletoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoRetornoClassCobBoletoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CobBoletoRetornoClass> _valueCollectionCobBoletoRetornoClassCobBoleto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CobBoletoRetornoClass> CollectionCobBoletoRetornoClassCobBoleto 
       { 
           get { if(!_valueCollectionCobBoletoRetornoClassCobBoletoLoaded && !this.DisableLoadCollection){this.LoadCollectionCobBoletoRetornoClassCobBoleto();}
return this._valueCollectionCobBoletoRetornoClassCobBoleto; } 
           set 
           { 
               this._valueCollectionCobBoletoRetornoClassCobBoleto = value; 
               this._valueCollectionCobBoletoRetornoClassCobBoletoLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberBoletoClassCobBoletoOriginal;
       private List<Entidades.ContaReceberBoletoClass > _collectionContaReceberBoletoClassCobBoletoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberBoletoClassCobBoletoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberBoletoClassCobBoletoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberBoletoClassCobBoletoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberBoletoClass> _valueCollectionContaReceberBoletoClassCobBoleto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberBoletoClass> CollectionContaReceberBoletoClassCobBoleto 
       { 
           get { if(!_valueCollectionContaReceberBoletoClassCobBoletoLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberBoletoClassCobBoleto();}
return this._valueCollectionContaReceberBoletoClassCobBoleto; } 
           set 
           { 
               this._valueCollectionContaReceberBoletoClassCobBoleto = value; 
               this._valueCollectionContaReceberBoletoClassCobBoletoLoaded = true; 
           } 
       } 

        public CobBoletoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ValorTitulo = 0;
           this.JurosPorDia = 0;
           this.ValorDesconto = 0;
           this.ValorAbatimento = 0;
           this.ValorIof = 0;
           this.DataGeracao = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static CobBoletoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (CobBoletoClass) GetEntity(typeof(CobBoletoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionCobBoletoHistoricoClassCobBoletoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCobBoletoHistoricoClassCobBoletoChanged = true;
                  _valueCollectionCobBoletoHistoricoClassCobBoletoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCobBoletoHistoricoClassCobBoletoChanged = true; 
                  _valueCollectionCobBoletoHistoricoClassCobBoletoCommitedChanged = true;
                 foreach (Entidades.CobBoletoHistoricoClass item in e.OldItems) 
                 { 
                     _collectionCobBoletoHistoricoClassCobBoletoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCobBoletoHistoricoClassCobBoletoChanged = true; 
                  _valueCollectionCobBoletoHistoricoClassCobBoletoCommitedChanged = true;
                 foreach (Entidades.CobBoletoHistoricoClass item in _valueCollectionCobBoletoHistoricoClassCobBoleto) 
                 { 
                     _collectionCobBoletoHistoricoClassCobBoletoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCobBoletoHistoricoClassCobBoleto()
         {
            try
            {
                 ObservableCollection<Entidades.CobBoletoHistoricoClass> oc;
                _valueCollectionCobBoletoHistoricoClassCobBoletoChanged = false;
                 _valueCollectionCobBoletoHistoricoClassCobBoletoCommitedChanged = false;
                _collectionCobBoletoHistoricoClassCobBoletoRemovidos = new List<Entidades.CobBoletoHistoricoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CobBoletoHistoricoClass>();
                }
                else{ 
                   Entidades.CobBoletoHistoricoClass search = new Entidades.CobBoletoHistoricoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CobBoletoHistoricoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CobBoleto", this),                     }                       ).Cast<Entidades.CobBoletoHistoricoClass>().ToList());
                 }
                 _valueCollectionCobBoletoHistoricoClassCobBoleto = new BindingList<Entidades.CobBoletoHistoricoClass>(oc); 
                 _collectionCobBoletoHistoricoClassCobBoletoOriginal= (from a in _valueCollectionCobBoletoHistoricoClassCobBoleto select a.ID).ToList();
                 _valueCollectionCobBoletoHistoricoClassCobBoletoLoaded = true;
                 oc.CollectionChanged += CollectionCobBoletoHistoricoClassCobBoletoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCobBoletoHistoricoClassCobBoleto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionCobBoletoInstrucoesClassCobBoletoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCobBoletoInstrucoesClassCobBoletoChanged = true;
                  _valueCollectionCobBoletoInstrucoesClassCobBoletoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCobBoletoInstrucoesClassCobBoletoChanged = true; 
                  _valueCollectionCobBoletoInstrucoesClassCobBoletoCommitedChanged = true;
                 foreach (Entidades.CobBoletoInstrucoesClass item in e.OldItems) 
                 { 
                     _collectionCobBoletoInstrucoesClassCobBoletoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCobBoletoInstrucoesClassCobBoletoChanged = true; 
                  _valueCollectionCobBoletoInstrucoesClassCobBoletoCommitedChanged = true;
                 foreach (Entidades.CobBoletoInstrucoesClass item in _valueCollectionCobBoletoInstrucoesClassCobBoleto) 
                 { 
                     _collectionCobBoletoInstrucoesClassCobBoletoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCobBoletoInstrucoesClassCobBoleto()
         {
            try
            {
                 ObservableCollection<Entidades.CobBoletoInstrucoesClass> oc;
                _valueCollectionCobBoletoInstrucoesClassCobBoletoChanged = false;
                 _valueCollectionCobBoletoInstrucoesClassCobBoletoCommitedChanged = false;
                _collectionCobBoletoInstrucoesClassCobBoletoRemovidos = new List<Entidades.CobBoletoInstrucoesClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CobBoletoInstrucoesClass>();
                }
                else{ 
                   Entidades.CobBoletoInstrucoesClass search = new Entidades.CobBoletoInstrucoesClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CobBoletoInstrucoesClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CobBoleto", this),                     }                       ).Cast<Entidades.CobBoletoInstrucoesClass>().ToList());
                 }
                 _valueCollectionCobBoletoInstrucoesClassCobBoleto = new BindingList<Entidades.CobBoletoInstrucoesClass>(oc); 
                 _collectionCobBoletoInstrucoesClassCobBoletoOriginal= (from a in _valueCollectionCobBoletoInstrucoesClassCobBoleto select a.ID).ToList();
                 _valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded = true;
                 oc.CollectionChanged += CollectionCobBoletoInstrucoesClassCobBoletoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCobBoletoInstrucoesClassCobBoleto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionCobBoletoRetornoClassCobBoletoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCobBoletoRetornoClassCobBoletoChanged = true;
                  _valueCollectionCobBoletoRetornoClassCobBoletoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCobBoletoRetornoClassCobBoletoChanged = true; 
                  _valueCollectionCobBoletoRetornoClassCobBoletoCommitedChanged = true;
                 foreach (Entidades.CobBoletoRetornoClass item in e.OldItems) 
                 { 
                     _collectionCobBoletoRetornoClassCobBoletoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCobBoletoRetornoClassCobBoletoChanged = true; 
                  _valueCollectionCobBoletoRetornoClassCobBoletoCommitedChanged = true;
                 foreach (Entidades.CobBoletoRetornoClass item in _valueCollectionCobBoletoRetornoClassCobBoleto) 
                 { 
                     _collectionCobBoletoRetornoClassCobBoletoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCobBoletoRetornoClassCobBoleto()
         {
            try
            {
                 ObservableCollection<Entidades.CobBoletoRetornoClass> oc;
                _valueCollectionCobBoletoRetornoClassCobBoletoChanged = false;
                 _valueCollectionCobBoletoRetornoClassCobBoletoCommitedChanged = false;
                _collectionCobBoletoRetornoClassCobBoletoRemovidos = new List<Entidades.CobBoletoRetornoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CobBoletoRetornoClass>();
                }
                else{ 
                   Entidades.CobBoletoRetornoClass search = new Entidades.CobBoletoRetornoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CobBoletoRetornoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CobBoleto", this),                     }                       ).Cast<Entidades.CobBoletoRetornoClass>().ToList());
                 }
                 _valueCollectionCobBoletoRetornoClassCobBoleto = new BindingList<Entidades.CobBoletoRetornoClass>(oc); 
                 _collectionCobBoletoRetornoClassCobBoletoOriginal= (from a in _valueCollectionCobBoletoRetornoClassCobBoleto select a.ID).ToList();
                 _valueCollectionCobBoletoRetornoClassCobBoletoLoaded = true;
                 oc.CollectionChanged += CollectionCobBoletoRetornoClassCobBoletoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCobBoletoRetornoClassCobBoleto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberBoletoClassCobBoletoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberBoletoClassCobBoletoChanged = true;
                  _valueCollectionContaReceberBoletoClassCobBoletoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberBoletoClassCobBoletoChanged = true; 
                  _valueCollectionContaReceberBoletoClassCobBoletoCommitedChanged = true;
                 foreach (Entidades.ContaReceberBoletoClass item in e.OldItems) 
                 { 
                     _collectionContaReceberBoletoClassCobBoletoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberBoletoClassCobBoletoChanged = true; 
                  _valueCollectionContaReceberBoletoClassCobBoletoCommitedChanged = true;
                 foreach (Entidades.ContaReceberBoletoClass item in _valueCollectionContaReceberBoletoClassCobBoleto) 
                 { 
                     _collectionContaReceberBoletoClassCobBoletoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberBoletoClassCobBoleto()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberBoletoClass> oc;
                _valueCollectionContaReceberBoletoClassCobBoletoChanged = false;
                 _valueCollectionContaReceberBoletoClassCobBoletoCommitedChanged = false;
                _collectionContaReceberBoletoClassCobBoletoRemovidos = new List<Entidades.ContaReceberBoletoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberBoletoClass>();
                }
                else{ 
                   Entidades.ContaReceberBoletoClass search = new Entidades.ContaReceberBoletoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberBoletoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CobBoleto", this),                     }                       ).Cast<Entidades.ContaReceberBoletoClass>().ToList());
                 }
                 _valueCollectionContaReceberBoletoClassCobBoleto = new BindingList<Entidades.ContaReceberBoletoClass>(oc); 
                 _collectionContaReceberBoletoClassCobBoletoOriginal= (from a in _valueCollectionContaReceberBoletoClassCobBoleto select a.ID).ToList();
                 _valueCollectionContaReceberBoletoClassCobBoletoLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberBoletoClassCobBoletoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberBoletoClassCobBoleto+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NossoNumero))
                {
                    throw new Exception(ErroNossoNumeroObrigatorio);
                }
                if (NossoNumero.Length >100)
                {
                    throw new Exception( ErroNossoNumeroComprimento);
                }
                if (string.IsNullOrEmpty(DvNossoNumero))
                {
                    throw new Exception(ErroDvNossoNumeroObrigatorio);
                }
                if (DvNossoNumero.Length >1)
                {
                    throw new Exception( ErroDvNossoNumeroComprimento);
                }
                if (string.IsNullOrEmpty(Agencia))
                {
                    throw new Exception(ErroAgenciaObrigatorio);
                }
                if (Agencia.Length >100)
                {
                    throw new Exception( ErroAgenciaComprimento);
                }
                if (string.IsNullOrEmpty(NumeroConta))
                {
                    throw new Exception(ErroNumeroContaObrigatorio);
                }
                if (NumeroConta.Length >100)
                {
                    throw new Exception( ErroNumeroContaComprimento);
                }
                if (string.IsNullOrEmpty(DvConta))
                {
                    throw new Exception(ErroDvContaObrigatorio);
                }
                if (DvConta.Length >1)
                {
                    throw new Exception( ErroDvContaComprimento);
                }
                if (string.IsNullOrEmpty(Especie))
                {
                    throw new Exception(ErroEspecieObrigatorio);
                }
                if (Especie.Length >2)
                {
                    throw new Exception( ErroEspecieComprimento);
                }
                if (string.IsNullOrEmpty(Aceite))
                {
                    throw new Exception(ErroAceiteObrigatorio);
                }
                if (Aceite.Length >1)
                {
                    throw new Exception( ErroAceiteComprimento);
                }
                if (string.IsNullOrEmpty(SacadoNumeroDocumento))
                {
                    throw new Exception(ErroSacadoNumeroDocumentoObrigatorio);
                }
                if (SacadoNumeroDocumento.Length >20)
                {
                    throw new Exception( ErroSacadoNumeroDocumentoComprimento);
                }
                if (string.IsNullOrEmpty(SacadoNome))
                {
                    throw new Exception(ErroSacadoNomeObrigatorio);
                }
                if (SacadoNome.Length >255)
                {
                    throw new Exception( ErroSacadoNomeComprimento);
                }
                if (string.IsNullOrEmpty(SacadoLogradouro))
                {
                    throw new Exception(ErroSacadoLogradouroObrigatorio);
                }
                if (SacadoLogradouro.Length >40)
                {
                    throw new Exception( ErroSacadoLogradouroComprimento);
                }
                if (string.IsNullOrEmpty(SacadoRua))
                {
                    throw new Exception(ErroSacadoRuaObrigatorio);
                }
                if (SacadoRua.Length >255)
                {
                    throw new Exception( ErroSacadoRuaComprimento);
                }
                if (string.IsNullOrEmpty(SacadoNumeroEndereco))
                {
                    throw new Exception(ErroSacadoNumeroEnderecoObrigatorio);
                }
                if (SacadoNumeroEndereco.Length >20)
                {
                    throw new Exception( ErroSacadoNumeroEnderecoComprimento);
                }
                if (string.IsNullOrEmpty(SacadoBairro))
                {
                    throw new Exception(ErroSacadoBairroObrigatorio);
                }
                if (SacadoBairro.Length >50)
                {
                    throw new Exception( ErroSacadoBairroComprimento);
                }
                if (string.IsNullOrEmpty(SacadoCep))
                {
                    throw new Exception(ErroSacadoCepObrigatorio);
                }
                if (SacadoCep.Length >8)
                {
                    throw new Exception( ErroSacadoCepComprimento);
                }
                if (string.IsNullOrEmpty(CidadeSacado))
                {
                    throw new Exception(ErroCidadeSacadoObrigatorio);
                }
                if (CidadeSacado.Length >50)
                {
                    throw new Exception( ErroCidadeSacadoComprimento);
                }
                if (string.IsNullOrEmpty(UfSacado))
                {
                    throw new Exception(ErroUfSacadoObrigatorio);
                }
                if (UfSacado.Length >2)
                {
                    throw new Exception( ErroUfSacadoComprimento);
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
                    "  public.cob_boleto  " +
                    "WHERE " +
                    "  id_cob_boleto = :id";
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
                        "  public.cob_boleto   " +
                        "SET  " + 
                        "  id_cob_remessa = :id_cob_remessa, " + 
                        "  bol_status = :bol_status, " + 
                        "  bol_numero_documento = :bol_numero_documento, " + 
                        "  bol_data_vencimento = :bol_data_vencimento, " + 
                        "  bol_valor_titulo = :bol_valor_titulo, " + 
                        "  id_titulo_sistema = :id_titulo_sistema, " + 
                        "  bol_nosso_numero = :bol_nosso_numero, " + 
                        "  bol_dv_nosso_numero = :bol_dv_nosso_numero, " + 
                        "  bol_data_emissao = :bol_data_emissao, " + 
                        "  bol_agencia = :bol_agencia, " + 
                        "  bol_dv_agencia = :bol_dv_agencia, " + 
                        "  bol_numero_conta = :bol_numero_conta, " + 
                        "  bol_dv_conta = :bol_dv_conta, " + 
                        "  bol_carteira = :bol_carteira, " + 
                        "  bol_codigo_carteira = :bol_codigo_carteira, " + 
                        "  bol_especie = :bol_especie, " + 
                        "  bol_aceite = :bol_aceite, " + 
                        "  bol_juros_por_dia = :bol_juros_por_dia, " + 
                        "  bol_data_limite_desconto = :bol_data_limite_desconto, " + 
                        "  bol_valor_desconto = :bol_valor_desconto, " + 
                        "  bol_valor_abatimento = :bol_valor_abatimento, " + 
                        "  bol_valor_iof = :bol_valor_iof, " + 
                        "  bol_sacado_tipo_documento = :bol_sacado_tipo_documento, " + 
                        "  bol_sacado_numero_documento = :bol_sacado_numero_documento, " + 
                        "  bol_sacado_nome = :bol_sacado_nome, " + 
                        "  bol_sacado_logradouro = :bol_sacado_logradouro, " + 
                        "  bol_sacado_rua = :bol_sacado_rua, " + 
                        "  bol_sacado_numero_endereco = :bol_sacado_numero_endereco, " + 
                        "  bol_sacado_complemento_endereco = :bol_sacado_complemento_endereco, " + 
                        "  bol_sacado_bairro = :bol_sacado_bairro, " + 
                        "  bol_sacado_cep = :bol_sacado_cep, " + 
                        "  bol_cidade_sacado = :bol_cidade_sacado, " + 
                        "  bol_uf_sacado = :bol_uf_sacado, " + 
                        "  bol_data_cancelamento = :bol_data_cancelamento, " + 
                        "  bol_data_baixa = :bol_data_baixa, " + 
                        "  bol_data_geracao = :bol_data_geracao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_cob_boleto = :id " +
                        "RETURNING id_cob_boleto;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.cob_boleto " +
                        "( " +
                        "  id_cob_remessa , " + 
                        "  bol_status , " + 
                        "  bol_numero_documento , " + 
                        "  bol_data_vencimento , " + 
                        "  bol_valor_titulo , " + 
                        "  id_titulo_sistema , " + 
                        "  bol_nosso_numero , " + 
                        "  bol_dv_nosso_numero , " + 
                        "  bol_data_emissao , " + 
                        "  bol_agencia , " + 
                        "  bol_dv_agencia , " + 
                        "  bol_numero_conta , " + 
                        "  bol_dv_conta , " + 
                        "  bol_carteira , " + 
                        "  bol_codigo_carteira , " + 
                        "  bol_especie , " + 
                        "  bol_aceite , " + 
                        "  bol_juros_por_dia , " + 
                        "  bol_data_limite_desconto , " + 
                        "  bol_valor_desconto , " + 
                        "  bol_valor_abatimento , " + 
                        "  bol_valor_iof , " + 
                        "  bol_sacado_tipo_documento , " + 
                        "  bol_sacado_numero_documento , " + 
                        "  bol_sacado_nome , " + 
                        "  bol_sacado_logradouro , " + 
                        "  bol_sacado_rua , " + 
                        "  bol_sacado_numero_endereco , " + 
                        "  bol_sacado_complemento_endereco , " + 
                        "  bol_sacado_bairro , " + 
                        "  bol_sacado_cep , " + 
                        "  bol_cidade_sacado , " + 
                        "  bol_uf_sacado , " + 
                        "  bol_data_cancelamento , " + 
                        "  bol_data_baixa , " + 
                        "  bol_data_geracao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_cob_remessa , " + 
                        "  :bol_status , " + 
                        "  :bol_numero_documento , " + 
                        "  :bol_data_vencimento , " + 
                        "  :bol_valor_titulo , " + 
                        "  :id_titulo_sistema , " + 
                        "  :bol_nosso_numero , " + 
                        "  :bol_dv_nosso_numero , " + 
                        "  :bol_data_emissao , " + 
                        "  :bol_agencia , " + 
                        "  :bol_dv_agencia , " + 
                        "  :bol_numero_conta , " + 
                        "  :bol_dv_conta , " + 
                        "  :bol_carteira , " + 
                        "  :bol_codigo_carteira , " + 
                        "  :bol_especie , " + 
                        "  :bol_aceite , " + 
                        "  :bol_juros_por_dia , " + 
                        "  :bol_data_limite_desconto , " + 
                        "  :bol_valor_desconto , " + 
                        "  :bol_valor_abatimento , " + 
                        "  :bol_valor_iof , " + 
                        "  :bol_sacado_tipo_documento , " + 
                        "  :bol_sacado_numero_documento , " + 
                        "  :bol_sacado_nome , " + 
                        "  :bol_sacado_logradouro , " + 
                        "  :bol_sacado_rua , " + 
                        "  :bol_sacado_numero_endereco , " + 
                        "  :bol_sacado_complemento_endereco , " + 
                        "  :bol_sacado_bairro , " + 
                        "  :bol_sacado_cep , " + 
                        "  :bol_cidade_sacado , " + 
                        "  :bol_uf_sacado , " + 
                        "  :bol_data_cancelamento , " + 
                        "  :bol_data_baixa , " + 
                        "  :bol_data_geracao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_cob_boleto;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cob_remessa", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CobRemessa==null ? (object) DBNull.Value : this.CobRemessa.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Status);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_numero_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_data_vencimento", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataVencimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_valor_titulo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTitulo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_titulo_sistema", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdTituloSistema ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_nosso_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NossoNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_dv_nosso_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DvNossoNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_data_emissao", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_agencia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Agencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_dv_agencia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DvAgencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_numero_conta", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroConta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_dv_conta", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DvConta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_carteira", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Carteira ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_codigo_carteira", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoCarteira ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_especie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Especie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_aceite", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aceite ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_juros_por_dia", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JurosPorDia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_data_limite_desconto", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataLimiteDesconto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_valor_desconto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorDesconto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_valor_abatimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorAbatimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_valor_iof", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIof ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_sacado_tipo_documento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.SacadoTipoDocumento);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_sacado_numero_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SacadoNumeroDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_sacado_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SacadoNome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_sacado_logradouro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SacadoLogradouro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_sacado_rua", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SacadoRua ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_sacado_numero_endereco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SacadoNumeroEndereco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_sacado_complemento_endereco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SacadoComplementoEndereco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_sacado_bairro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SacadoBairro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_sacado_cep", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SacadoCep ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_cidade_sacado", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CidadeSacado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_uf_sacado", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfSacado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_data_baixa", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataBaixa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bol_data_geracao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataGeracao ?? DBNull.Value;
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
 if (CollectionCobBoletoHistoricoClassCobBoleto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCobBoletoHistoricoClassCobBoleto+"\r\n";
                foreach (Entidades.CobBoletoHistoricoClass tmp in CollectionCobBoletoHistoricoClassCobBoleto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionCobBoletoInstrucoesClassCobBoleto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCobBoletoInstrucoesClassCobBoleto+"\r\n";
                foreach (Entidades.CobBoletoInstrucoesClass tmp in CollectionCobBoletoInstrucoesClassCobBoleto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionCobBoletoRetornoClassCobBoleto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCobBoletoRetornoClassCobBoleto+"\r\n";
                foreach (Entidades.CobBoletoRetornoClass tmp in CollectionCobBoletoRetornoClassCobBoleto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberBoletoClassCobBoleto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberBoletoClassCobBoleto+"\r\n";
                foreach (Entidades.ContaReceberBoletoClass tmp in CollectionContaReceberBoletoClassCobBoleto)
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
        public static CobBoletoClass CopiarEntidade(CobBoletoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               CobBoletoClass toRet = new CobBoletoClass(usuario,conn);
 toRet.CobRemessa= entidadeCopiar.CobRemessa;
 toRet.Status= entidadeCopiar.Status;
 toRet.NumeroDocumento= entidadeCopiar.NumeroDocumento;
 toRet.DataVencimento= entidadeCopiar.DataVencimento;
 toRet.ValorTitulo= entidadeCopiar.ValorTitulo;
 toRet.IdTituloSistema= entidadeCopiar.IdTituloSistema;
 toRet.NossoNumero= entidadeCopiar.NossoNumero;
 toRet.DvNossoNumero= entidadeCopiar.DvNossoNumero;
 toRet.DataEmissao= entidadeCopiar.DataEmissao;
 toRet.Agencia= entidadeCopiar.Agencia;
 toRet.DvAgencia= entidadeCopiar.DvAgencia;
 toRet.NumeroConta= entidadeCopiar.NumeroConta;
 toRet.DvConta= entidadeCopiar.DvConta;
 toRet.Carteira= entidadeCopiar.Carteira;
 toRet.CodigoCarteira= entidadeCopiar.CodigoCarteira;
 toRet.Especie= entidadeCopiar.Especie;
 toRet.Aceite= entidadeCopiar.Aceite;
 toRet.JurosPorDia= entidadeCopiar.JurosPorDia;
 toRet.DataLimiteDesconto= entidadeCopiar.DataLimiteDesconto;
 toRet.ValorDesconto= entidadeCopiar.ValorDesconto;
 toRet.ValorAbatimento= entidadeCopiar.ValorAbatimento;
 toRet.ValorIof= entidadeCopiar.ValorIof;
 toRet.SacadoTipoDocumento= entidadeCopiar.SacadoTipoDocumento;
 toRet.SacadoNumeroDocumento= entidadeCopiar.SacadoNumeroDocumento;
 toRet.SacadoNome= entidadeCopiar.SacadoNome;
 toRet.SacadoLogradouro= entidadeCopiar.SacadoLogradouro;
 toRet.SacadoRua= entidadeCopiar.SacadoRua;
 toRet.SacadoNumeroEndereco= entidadeCopiar.SacadoNumeroEndereco;
 toRet.SacadoComplementoEndereco= entidadeCopiar.SacadoComplementoEndereco;
 toRet.SacadoBairro= entidadeCopiar.SacadoBairro;
 toRet.SacadoCep= entidadeCopiar.SacadoCep;
 toRet.CidadeSacado= entidadeCopiar.CidadeSacado;
 toRet.UfSacado= entidadeCopiar.UfSacado;
 toRet.DataCancelamento= entidadeCopiar.DataCancelamento;
 toRet.DataBaixa= entidadeCopiar.DataBaixa;
 toRet.DataGeracao= entidadeCopiar.DataGeracao;

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
       _cobRemessaOriginal = CobRemessa;
       _cobRemessaOriginalCommited = _cobRemessaOriginal;
       _statusOriginal = Status;
       _statusOriginalCommited = _statusOriginal;
       _numeroDocumentoOriginal = NumeroDocumento;
       _numeroDocumentoOriginalCommited = _numeroDocumentoOriginal;
       _dataVencimentoOriginal = DataVencimento;
       _dataVencimentoOriginalCommited = _dataVencimentoOriginal;
       _valorTituloOriginal = ValorTitulo;
       _valorTituloOriginalCommited = _valorTituloOriginal;
       _idTituloSistemaOriginal = IdTituloSistema;
       _idTituloSistemaOriginalCommited = _idTituloSistemaOriginal;
       _nossoNumeroOriginal = NossoNumero;
       _nossoNumeroOriginalCommited = _nossoNumeroOriginal;
       _dvNossoNumeroOriginal = DvNossoNumero;
       _dvNossoNumeroOriginalCommited = _dvNossoNumeroOriginal;
       _dataEmissaoOriginal = DataEmissao;
       _dataEmissaoOriginalCommited = _dataEmissaoOriginal;
       _agenciaOriginal = Agencia;
       _agenciaOriginalCommited = _agenciaOriginal;
       _dvAgenciaOriginal = DvAgencia;
       _dvAgenciaOriginalCommited = _dvAgenciaOriginal;
       _numeroContaOriginal = NumeroConta;
       _numeroContaOriginalCommited = _numeroContaOriginal;
       _dvContaOriginal = DvConta;
       _dvContaOriginalCommited = _dvContaOriginal;
       _carteiraOriginal = Carteira;
       _carteiraOriginalCommited = _carteiraOriginal;
       _codigoCarteiraOriginal = CodigoCarteira;
       _codigoCarteiraOriginalCommited = _codigoCarteiraOriginal;
       _especieOriginal = Especie;
       _especieOriginalCommited = _especieOriginal;
       _aceiteOriginal = Aceite;
       _aceiteOriginalCommited = _aceiteOriginal;
       _jurosPorDiaOriginal = JurosPorDia;
       _jurosPorDiaOriginalCommited = _jurosPorDiaOriginal;
       _dataLimiteDescontoOriginal = DataLimiteDesconto;
       _dataLimiteDescontoOriginalCommited = _dataLimiteDescontoOriginal;
       _valorDescontoOriginal = ValorDesconto;
       _valorDescontoOriginalCommited = _valorDescontoOriginal;
       _valorAbatimentoOriginal = ValorAbatimento;
       _valorAbatimentoOriginalCommited = _valorAbatimentoOriginal;
       _valorIofOriginal = ValorIof;
       _valorIofOriginalCommited = _valorIofOriginal;
       _sacadoTipoDocumentoOriginal = SacadoTipoDocumento;
       _sacadoTipoDocumentoOriginalCommited = _sacadoTipoDocumentoOriginal;
       _sacadoNumeroDocumentoOriginal = SacadoNumeroDocumento;
       _sacadoNumeroDocumentoOriginalCommited = _sacadoNumeroDocumentoOriginal;
       _sacadoNomeOriginal = SacadoNome;
       _sacadoNomeOriginalCommited = _sacadoNomeOriginal;
       _sacadoLogradouroOriginal = SacadoLogradouro;
       _sacadoLogradouroOriginalCommited = _sacadoLogradouroOriginal;
       _sacadoRuaOriginal = SacadoRua;
       _sacadoRuaOriginalCommited = _sacadoRuaOriginal;
       _sacadoNumeroEnderecoOriginal = SacadoNumeroEndereco;
       _sacadoNumeroEnderecoOriginalCommited = _sacadoNumeroEnderecoOriginal;
       _sacadoComplementoEnderecoOriginal = SacadoComplementoEndereco;
       _sacadoComplementoEnderecoOriginalCommited = _sacadoComplementoEnderecoOriginal;
       _sacadoBairroOriginal = SacadoBairro;
       _sacadoBairroOriginalCommited = _sacadoBairroOriginal;
       _sacadoCepOriginal = SacadoCep;
       _sacadoCepOriginalCommited = _sacadoCepOriginal;
       _cidadeSacadoOriginal = CidadeSacado;
       _cidadeSacadoOriginalCommited = _cidadeSacadoOriginal;
       _ufSacadoOriginal = UfSacado;
       _ufSacadoOriginalCommited = _ufSacadoOriginal;
       _dataCancelamentoOriginal = DataCancelamento;
       _dataCancelamentoOriginalCommited = _dataCancelamentoOriginal;
       _dataBaixaOriginal = DataBaixa;
       _dataBaixaOriginalCommited = _dataBaixaOriginal;
       _dataGeracaoOriginal = DataGeracao;
       _dataGeracaoOriginalCommited = _dataGeracaoOriginal;
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
       _cobRemessaOriginalCommited = CobRemessa;
       _statusOriginalCommited = Status;
       _numeroDocumentoOriginalCommited = NumeroDocumento;
       _dataVencimentoOriginalCommited = DataVencimento;
       _valorTituloOriginalCommited = ValorTitulo;
       _idTituloSistemaOriginalCommited = IdTituloSistema;
       _nossoNumeroOriginalCommited = NossoNumero;
       _dvNossoNumeroOriginalCommited = DvNossoNumero;
       _dataEmissaoOriginalCommited = DataEmissao;
       _agenciaOriginalCommited = Agencia;
       _dvAgenciaOriginalCommited = DvAgencia;
       _numeroContaOriginalCommited = NumeroConta;
       _dvContaOriginalCommited = DvConta;
       _carteiraOriginalCommited = Carteira;
       _codigoCarteiraOriginalCommited = CodigoCarteira;
       _especieOriginalCommited = Especie;
       _aceiteOriginalCommited = Aceite;
       _jurosPorDiaOriginalCommited = JurosPorDia;
       _dataLimiteDescontoOriginalCommited = DataLimiteDesconto;
       _valorDescontoOriginalCommited = ValorDesconto;
       _valorAbatimentoOriginalCommited = ValorAbatimento;
       _valorIofOriginalCommited = ValorIof;
       _sacadoTipoDocumentoOriginalCommited = SacadoTipoDocumento;
       _sacadoNumeroDocumentoOriginalCommited = SacadoNumeroDocumento;
       _sacadoNomeOriginalCommited = SacadoNome;
       _sacadoLogradouroOriginalCommited = SacadoLogradouro;
       _sacadoRuaOriginalCommited = SacadoRua;
       _sacadoNumeroEnderecoOriginalCommited = SacadoNumeroEndereco;
       _sacadoComplementoEnderecoOriginalCommited = SacadoComplementoEndereco;
       _sacadoBairroOriginalCommited = SacadoBairro;
       _sacadoCepOriginalCommited = SacadoCep;
       _cidadeSacadoOriginalCommited = CidadeSacado;
       _ufSacadoOriginalCommited = UfSacado;
       _dataCancelamentoOriginalCommited = DataCancelamento;
       _dataBaixaOriginalCommited = DataBaixa;
       _dataGeracaoOriginalCommited = DataGeracao;
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
               if (_valueCollectionCobBoletoHistoricoClassCobBoletoLoaded) 
               {
                  if (_collectionCobBoletoHistoricoClassCobBoletoRemovidos != null) 
                  {
                     _collectionCobBoletoHistoricoClassCobBoletoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCobBoletoHistoricoClassCobBoletoRemovidos = new List<Entidades.CobBoletoHistoricoClass>();
                  }
                  _collectionCobBoletoHistoricoClassCobBoletoOriginal= (from a in _valueCollectionCobBoletoHistoricoClassCobBoleto select a.ID).ToList();
                  _valueCollectionCobBoletoHistoricoClassCobBoletoChanged = false;
                  _valueCollectionCobBoletoHistoricoClassCobBoletoCommitedChanged = false;
               }
               if (_valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded) 
               {
                  if (_collectionCobBoletoInstrucoesClassCobBoletoRemovidos != null) 
                  {
                     _collectionCobBoletoInstrucoesClassCobBoletoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCobBoletoInstrucoesClassCobBoletoRemovidos = new List<Entidades.CobBoletoInstrucoesClass>();
                  }
                  _collectionCobBoletoInstrucoesClassCobBoletoOriginal= (from a in _valueCollectionCobBoletoInstrucoesClassCobBoleto select a.ID).ToList();
                  _valueCollectionCobBoletoInstrucoesClassCobBoletoChanged = false;
                  _valueCollectionCobBoletoInstrucoesClassCobBoletoCommitedChanged = false;
               }
               if (_valueCollectionCobBoletoRetornoClassCobBoletoLoaded) 
               {
                  if (_collectionCobBoletoRetornoClassCobBoletoRemovidos != null) 
                  {
                     _collectionCobBoletoRetornoClassCobBoletoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCobBoletoRetornoClassCobBoletoRemovidos = new List<Entidades.CobBoletoRetornoClass>();
                  }
                  _collectionCobBoletoRetornoClassCobBoletoOriginal= (from a in _valueCollectionCobBoletoRetornoClassCobBoleto select a.ID).ToList();
                  _valueCollectionCobBoletoRetornoClassCobBoletoChanged = false;
                  _valueCollectionCobBoletoRetornoClassCobBoletoCommitedChanged = false;
               }
               if (_valueCollectionContaReceberBoletoClassCobBoletoLoaded) 
               {
                  if (_collectionContaReceberBoletoClassCobBoletoRemovidos != null) 
                  {
                     _collectionContaReceberBoletoClassCobBoletoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberBoletoClassCobBoletoRemovidos = new List<Entidades.ContaReceberBoletoClass>();
                  }
                  _collectionContaReceberBoletoClassCobBoletoOriginal= (from a in _valueCollectionContaReceberBoletoClassCobBoleto select a.ID).ToList();
                  _valueCollectionContaReceberBoletoClassCobBoletoChanged = false;
                  _valueCollectionContaReceberBoletoClassCobBoletoCommitedChanged = false;
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
               CobRemessa=_cobRemessaOriginal;
               _cobRemessaOriginalCommited=_cobRemessaOriginal;
               Status=_statusOriginal;
               _statusOriginalCommited=_statusOriginal;
               NumeroDocumento=_numeroDocumentoOriginal;
               _numeroDocumentoOriginalCommited=_numeroDocumentoOriginal;
               DataVencimento=_dataVencimentoOriginal;
               _dataVencimentoOriginalCommited=_dataVencimentoOriginal;
               ValorTitulo=_valorTituloOriginal;
               _valorTituloOriginalCommited=_valorTituloOriginal;
               IdTituloSistema=_idTituloSistemaOriginal;
               _idTituloSistemaOriginalCommited=_idTituloSistemaOriginal;
               NossoNumero=_nossoNumeroOriginal;
               _nossoNumeroOriginalCommited=_nossoNumeroOriginal;
               DvNossoNumero=_dvNossoNumeroOriginal;
               _dvNossoNumeroOriginalCommited=_dvNossoNumeroOriginal;
               DataEmissao=_dataEmissaoOriginal;
               _dataEmissaoOriginalCommited=_dataEmissaoOriginal;
               Agencia=_agenciaOriginal;
               _agenciaOriginalCommited=_agenciaOriginal;
               DvAgencia=_dvAgenciaOriginal;
               _dvAgenciaOriginalCommited=_dvAgenciaOriginal;
               NumeroConta=_numeroContaOriginal;
               _numeroContaOriginalCommited=_numeroContaOriginal;
               DvConta=_dvContaOriginal;
               _dvContaOriginalCommited=_dvContaOriginal;
               Carteira=_carteiraOriginal;
               _carteiraOriginalCommited=_carteiraOriginal;
               CodigoCarteira=_codigoCarteiraOriginal;
               _codigoCarteiraOriginalCommited=_codigoCarteiraOriginal;
               Especie=_especieOriginal;
               _especieOriginalCommited=_especieOriginal;
               Aceite=_aceiteOriginal;
               _aceiteOriginalCommited=_aceiteOriginal;
               JurosPorDia=_jurosPorDiaOriginal;
               _jurosPorDiaOriginalCommited=_jurosPorDiaOriginal;
               DataLimiteDesconto=_dataLimiteDescontoOriginal;
               _dataLimiteDescontoOriginalCommited=_dataLimiteDescontoOriginal;
               ValorDesconto=_valorDescontoOriginal;
               _valorDescontoOriginalCommited=_valorDescontoOriginal;
               ValorAbatimento=_valorAbatimentoOriginal;
               _valorAbatimentoOriginalCommited=_valorAbatimentoOriginal;
               ValorIof=_valorIofOriginal;
               _valorIofOriginalCommited=_valorIofOriginal;
               SacadoTipoDocumento=_sacadoTipoDocumentoOriginal;
               _sacadoTipoDocumentoOriginalCommited=_sacadoTipoDocumentoOriginal;
               SacadoNumeroDocumento=_sacadoNumeroDocumentoOriginal;
               _sacadoNumeroDocumentoOriginalCommited=_sacadoNumeroDocumentoOriginal;
               SacadoNome=_sacadoNomeOriginal;
               _sacadoNomeOriginalCommited=_sacadoNomeOriginal;
               SacadoLogradouro=_sacadoLogradouroOriginal;
               _sacadoLogradouroOriginalCommited=_sacadoLogradouroOriginal;
               SacadoRua=_sacadoRuaOriginal;
               _sacadoRuaOriginalCommited=_sacadoRuaOriginal;
               SacadoNumeroEndereco=_sacadoNumeroEnderecoOriginal;
               _sacadoNumeroEnderecoOriginalCommited=_sacadoNumeroEnderecoOriginal;
               SacadoComplementoEndereco=_sacadoComplementoEnderecoOriginal;
               _sacadoComplementoEnderecoOriginalCommited=_sacadoComplementoEnderecoOriginal;
               SacadoBairro=_sacadoBairroOriginal;
               _sacadoBairroOriginalCommited=_sacadoBairroOriginal;
               SacadoCep=_sacadoCepOriginal;
               _sacadoCepOriginalCommited=_sacadoCepOriginal;
               CidadeSacado=_cidadeSacadoOriginal;
               _cidadeSacadoOriginalCommited=_cidadeSacadoOriginal;
               UfSacado=_ufSacadoOriginal;
               _ufSacadoOriginalCommited=_ufSacadoOriginal;
               DataCancelamento=_dataCancelamentoOriginal;
               _dataCancelamentoOriginalCommited=_dataCancelamentoOriginal;
               DataBaixa=_dataBaixaOriginal;
               _dataBaixaOriginalCommited=_dataBaixaOriginal;
               DataGeracao=_dataGeracaoOriginal;
               _dataGeracaoOriginalCommited=_dataGeracaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionCobBoletoHistoricoClassCobBoletoLoaded) 
               {
                  CollectionCobBoletoHistoricoClassCobBoleto.Clear();
                  foreach(int item in _collectionCobBoletoHistoricoClassCobBoletoOriginal)
                  {
                    CollectionCobBoletoHistoricoClassCobBoleto.Add(Entidades.CobBoletoHistoricoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCobBoletoHistoricoClassCobBoletoRemovidos.Clear();
               }
               if (_valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded) 
               {
                  CollectionCobBoletoInstrucoesClassCobBoleto.Clear();
                  foreach(int item in _collectionCobBoletoInstrucoesClassCobBoletoOriginal)
                  {
                    CollectionCobBoletoInstrucoesClassCobBoleto.Add(Entidades.CobBoletoInstrucoesClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCobBoletoInstrucoesClassCobBoletoRemovidos.Clear();
               }
               if (_valueCollectionCobBoletoRetornoClassCobBoletoLoaded) 
               {
                  CollectionCobBoletoRetornoClassCobBoleto.Clear();
                  foreach(int item in _collectionCobBoletoRetornoClassCobBoletoOriginal)
                  {
                    CollectionCobBoletoRetornoClassCobBoleto.Add(Entidades.CobBoletoRetornoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCobBoletoRetornoClassCobBoletoRemovidos.Clear();
               }
               if (_valueCollectionContaReceberBoletoClassCobBoletoLoaded) 
               {
                  CollectionContaReceberBoletoClassCobBoleto.Clear();
                  foreach(int item in _collectionContaReceberBoletoClassCobBoletoOriginal)
                  {
                    CollectionContaReceberBoletoClassCobBoleto.Add(Entidades.ContaReceberBoletoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberBoletoClassCobBoletoRemovidos.Clear();
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
               if (_valueCollectionCobBoletoHistoricoClassCobBoletoLoaded) 
               {
                  if (_valueCollectionCobBoletoHistoricoClassCobBoletoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded) 
               {
                  if (_valueCollectionCobBoletoInstrucoesClassCobBoletoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoRetornoClassCobBoletoLoaded) 
               {
                  if (_valueCollectionCobBoletoRetornoClassCobBoletoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberBoletoClassCobBoletoLoaded) 
               {
                  if (_valueCollectionContaReceberBoletoClassCobBoletoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoHistoricoClassCobBoletoLoaded) 
               {
                   tempRet = CollectionCobBoletoHistoricoClassCobBoleto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded) 
               {
                   tempRet = CollectionCobBoletoInstrucoesClassCobBoleto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionCobBoletoRetornoClassCobBoletoLoaded) 
               {
                   tempRet = CollectionCobBoletoRetornoClassCobBoleto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberBoletoClassCobBoletoLoaded) 
               {
                   tempRet = CollectionContaReceberBoletoClassCobBoleto.Any(item => item.IsDirty());
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
       if (_cobRemessaOriginal!=null)
       {
          dirty = !_cobRemessaOriginal.Equals(CobRemessa);
       }
       else
       {
            dirty = CobRemessa != null;
       }
      if (dirty) return true;
       dirty = _statusOriginal != Status;
      if (dirty) return true;
       dirty = _numeroDocumentoOriginal != NumeroDocumento;
      if (dirty) return true;
       dirty = _dataVencimentoOriginal != DataVencimento;
      if (dirty) return true;
       dirty = _valorTituloOriginal != ValorTitulo;
      if (dirty) return true;
       dirty = _idTituloSistemaOriginal != IdTituloSistema;
      if (dirty) return true;
       dirty = _nossoNumeroOriginal != NossoNumero;
      if (dirty) return true;
       dirty = _dvNossoNumeroOriginal != DvNossoNumero;
      if (dirty) return true;
       dirty = _dataEmissaoOriginal != DataEmissao;
      if (dirty) return true;
       dirty = _agenciaOriginal != Agencia;
      if (dirty) return true;
       dirty = _dvAgenciaOriginal != DvAgencia;
      if (dirty) return true;
       dirty = _numeroContaOriginal != NumeroConta;
      if (dirty) return true;
       dirty = _dvContaOriginal != DvConta;
      if (dirty) return true;
       dirty = _carteiraOriginal != Carteira;
      if (dirty) return true;
       dirty = _codigoCarteiraOriginal != CodigoCarteira;
      if (dirty) return true;
       dirty = _especieOriginal != Especie;
      if (dirty) return true;
       dirty = _aceiteOriginal != Aceite;
      if (dirty) return true;
       dirty = _jurosPorDiaOriginal != JurosPorDia;
      if (dirty) return true;
       dirty = _dataLimiteDescontoOriginal != DataLimiteDesconto;
      if (dirty) return true;
       dirty = _valorDescontoOriginal != ValorDesconto;
      if (dirty) return true;
       dirty = _valorAbatimentoOriginal != ValorAbatimento;
      if (dirty) return true;
       dirty = _valorIofOriginal != ValorIof;
      if (dirty) return true;
       dirty = _sacadoTipoDocumentoOriginal != SacadoTipoDocumento;
      if (dirty) return true;
       dirty = _sacadoNumeroDocumentoOriginal != SacadoNumeroDocumento;
      if (dirty) return true;
       dirty = _sacadoNomeOriginal != SacadoNome;
      if (dirty) return true;
       dirty = _sacadoLogradouroOriginal != SacadoLogradouro;
      if (dirty) return true;
       dirty = _sacadoRuaOriginal != SacadoRua;
      if (dirty) return true;
       dirty = _sacadoNumeroEnderecoOriginal != SacadoNumeroEndereco;
      if (dirty) return true;
       dirty = _sacadoComplementoEnderecoOriginal != SacadoComplementoEndereco;
      if (dirty) return true;
       dirty = _sacadoBairroOriginal != SacadoBairro;
      if (dirty) return true;
       dirty = _sacadoCepOriginal != SacadoCep;
      if (dirty) return true;
       dirty = _cidadeSacadoOriginal != CidadeSacado;
      if (dirty) return true;
       dirty = _ufSacadoOriginal != UfSacado;
      if (dirty) return true;
       dirty = _dataCancelamentoOriginal != DataCancelamento;
      if (dirty) return true;
       dirty = _dataBaixaOriginal != DataBaixa;
      if (dirty) return true;
       dirty = _dataGeracaoOriginal != DataGeracao;
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
               if (_valueCollectionCobBoletoHistoricoClassCobBoletoLoaded) 
               {
                  if (_valueCollectionCobBoletoHistoricoClassCobBoletoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded) 
               {
                  if (_valueCollectionCobBoletoInstrucoesClassCobBoletoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoRetornoClassCobBoletoLoaded) 
               {
                  if (_valueCollectionCobBoletoRetornoClassCobBoletoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberBoletoClassCobBoletoLoaded) 
               {
                  if (_valueCollectionContaReceberBoletoClassCobBoletoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoHistoricoClassCobBoletoLoaded) 
               {
                   tempRet = CollectionCobBoletoHistoricoClassCobBoleto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded) 
               {
                   tempRet = CollectionCobBoletoInstrucoesClassCobBoleto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionCobBoletoRetornoClassCobBoletoLoaded) 
               {
                   tempRet = CollectionCobBoletoRetornoClassCobBoleto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberBoletoClassCobBoletoLoaded) 
               {
                   tempRet = CollectionContaReceberBoletoClassCobBoleto.Any(item => item.IsDirtyCommited());
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
       if (_cobRemessaOriginalCommited!=null)
       {
          dirty = !_cobRemessaOriginalCommited.Equals(CobRemessa);
       }
       else
       {
            dirty = CobRemessa != null;
       }
      if (dirty) return true;
       dirty = _statusOriginalCommited != Status;
      if (dirty) return true;
       dirty = _numeroDocumentoOriginalCommited != NumeroDocumento;
      if (dirty) return true;
       dirty = _dataVencimentoOriginalCommited != DataVencimento;
      if (dirty) return true;
       dirty = _valorTituloOriginalCommited != ValorTitulo;
      if (dirty) return true;
       dirty = _idTituloSistemaOriginalCommited != IdTituloSistema;
      if (dirty) return true;
       dirty = _nossoNumeroOriginalCommited != NossoNumero;
      if (dirty) return true;
       dirty = _dvNossoNumeroOriginalCommited != DvNossoNumero;
      if (dirty) return true;
       dirty = _dataEmissaoOriginalCommited != DataEmissao;
      if (dirty) return true;
       dirty = _agenciaOriginalCommited != Agencia;
      if (dirty) return true;
       dirty = _dvAgenciaOriginalCommited != DvAgencia;
      if (dirty) return true;
       dirty = _numeroContaOriginalCommited != NumeroConta;
      if (dirty) return true;
       dirty = _dvContaOriginalCommited != DvConta;
      if (dirty) return true;
       dirty = _carteiraOriginalCommited != Carteira;
      if (dirty) return true;
       dirty = _codigoCarteiraOriginalCommited != CodigoCarteira;
      if (dirty) return true;
       dirty = _especieOriginalCommited != Especie;
      if (dirty) return true;
       dirty = _aceiteOriginalCommited != Aceite;
      if (dirty) return true;
       dirty = _jurosPorDiaOriginalCommited != JurosPorDia;
      if (dirty) return true;
       dirty = _dataLimiteDescontoOriginalCommited != DataLimiteDesconto;
      if (dirty) return true;
       dirty = _valorDescontoOriginalCommited != ValorDesconto;
      if (dirty) return true;
       dirty = _valorAbatimentoOriginalCommited != ValorAbatimento;
      if (dirty) return true;
       dirty = _valorIofOriginalCommited != ValorIof;
      if (dirty) return true;
       dirty = _sacadoTipoDocumentoOriginalCommited != SacadoTipoDocumento;
      if (dirty) return true;
       dirty = _sacadoNumeroDocumentoOriginalCommited != SacadoNumeroDocumento;
      if (dirty) return true;
       dirty = _sacadoNomeOriginalCommited != SacadoNome;
      if (dirty) return true;
       dirty = _sacadoLogradouroOriginalCommited != SacadoLogradouro;
      if (dirty) return true;
       dirty = _sacadoRuaOriginalCommited != SacadoRua;
      if (dirty) return true;
       dirty = _sacadoNumeroEnderecoOriginalCommited != SacadoNumeroEndereco;
      if (dirty) return true;
       dirty = _sacadoComplementoEnderecoOriginalCommited != SacadoComplementoEndereco;
      if (dirty) return true;
       dirty = _sacadoBairroOriginalCommited != SacadoBairro;
      if (dirty) return true;
       dirty = _sacadoCepOriginalCommited != SacadoCep;
      if (dirty) return true;
       dirty = _cidadeSacadoOriginalCommited != CidadeSacado;
      if (dirty) return true;
       dirty = _ufSacadoOriginalCommited != UfSacado;
      if (dirty) return true;
       dirty = _dataCancelamentoOriginalCommited != DataCancelamento;
      if (dirty) return true;
       dirty = _dataBaixaOriginalCommited != DataBaixa;
      if (dirty) return true;
       dirty = _dataGeracaoOriginalCommited != DataGeracao;
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
               if (_valueCollectionCobBoletoHistoricoClassCobBoletoLoaded) 
               {
                  foreach(CobBoletoHistoricoClass item in CollectionCobBoletoHistoricoClassCobBoleto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded) 
               {
                  foreach(CobBoletoInstrucoesClass item in CollectionCobBoletoInstrucoesClassCobBoleto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionCobBoletoRetornoClassCobBoletoLoaded) 
               {
                  foreach(CobBoletoRetornoClass item in CollectionCobBoletoRetornoClassCobBoleto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberBoletoClassCobBoletoLoaded) 
               {
                  foreach(ContaReceberBoletoClass item in CollectionContaReceberBoletoClassCobBoleto)
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
             case "CobRemessa":
                return this.CobRemessa;
             case "Status":
                return this.Status;
             case "NumeroDocumento":
                return this.NumeroDocumento;
             case "DataVencimento":
                return this.DataVencimento;
             case "ValorTitulo":
                return this.ValorTitulo;
             case "IdTituloSistema":
                return this.IdTituloSistema;
             case "NossoNumero":
                return this.NossoNumero;
             case "DvNossoNumero":
                return this.DvNossoNumero;
             case "DataEmissao":
                return this.DataEmissao;
             case "Agencia":
                return this.Agencia;
             case "DvAgencia":
                return this.DvAgencia;
             case "NumeroConta":
                return this.NumeroConta;
             case "DvConta":
                return this.DvConta;
             case "Carteira":
                return this.Carteira;
             case "CodigoCarteira":
                return this.CodigoCarteira;
             case "Especie":
                return this.Especie;
             case "Aceite":
                return this.Aceite;
             case "JurosPorDia":
                return this.JurosPorDia;
             case "DataLimiteDesconto":
                return this.DataLimiteDesconto;
             case "ValorDesconto":
                return this.ValorDesconto;
             case "ValorAbatimento":
                return this.ValorAbatimento;
             case "ValorIof":
                return this.ValorIof;
             case "SacadoTipoDocumento":
                return this.SacadoTipoDocumento;
             case "SacadoNumeroDocumento":
                return this.SacadoNumeroDocumento;
             case "SacadoNome":
                return this.SacadoNome;
             case "SacadoLogradouro":
                return this.SacadoLogradouro;
             case "SacadoRua":
                return this.SacadoRua;
             case "SacadoNumeroEndereco":
                return this.SacadoNumeroEndereco;
             case "SacadoComplementoEndereco":
                return this.SacadoComplementoEndereco;
             case "SacadoBairro":
                return this.SacadoBairro;
             case "SacadoCep":
                return this.SacadoCep;
             case "CidadeSacado":
                return this.CidadeSacado;
             case "UfSacado":
                return this.UfSacado;
             case "DataCancelamento":
                return this.DataCancelamento;
             case "DataBaixa":
                return this.DataBaixa;
             case "DataGeracao":
                return this.DataGeracao;
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
             if (CobRemessa!=null)
                CobRemessa.ChangeSingleConnection(newConnection);
               if (_valueCollectionCobBoletoHistoricoClassCobBoletoLoaded) 
               {
                  foreach(CobBoletoHistoricoClass item in CollectionCobBoletoHistoricoClassCobBoleto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionCobBoletoInstrucoesClassCobBoletoLoaded) 
               {
                  foreach(CobBoletoInstrucoesClass item in CollectionCobBoletoInstrucoesClassCobBoleto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionCobBoletoRetornoClassCobBoletoLoaded) 
               {
                  foreach(CobBoletoRetornoClass item in CollectionCobBoletoRetornoClassCobBoleto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberBoletoClassCobBoletoLoaded) 
               {
                  foreach(ContaReceberBoletoClass item in CollectionContaReceberBoletoClassCobBoleto)
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
                  command.CommandText += " COUNT(cob_boleto.id_cob_boleto) " ;
               }
               else
               {
               command.CommandText += "cob_boleto.id_cob_boleto, " ;
               command.CommandText += "cob_boleto.id_cob_remessa, " ;
               command.CommandText += "cob_boleto.bol_status, " ;
               command.CommandText += "cob_boleto.bol_numero_documento, " ;
               command.CommandText += "cob_boleto.bol_data_vencimento, " ;
               command.CommandText += "cob_boleto.bol_valor_titulo, " ;
               command.CommandText += "cob_boleto.id_titulo_sistema, " ;
               command.CommandText += "cob_boleto.bol_nosso_numero, " ;
               command.CommandText += "cob_boleto.bol_dv_nosso_numero, " ;
               command.CommandText += "cob_boleto.bol_data_emissao, " ;
               command.CommandText += "cob_boleto.bol_agencia, " ;
               command.CommandText += "cob_boleto.bol_dv_agencia, " ;
               command.CommandText += "cob_boleto.bol_numero_conta, " ;
               command.CommandText += "cob_boleto.bol_dv_conta, " ;
               command.CommandText += "cob_boleto.bol_carteira, " ;
               command.CommandText += "cob_boleto.bol_codigo_carteira, " ;
               command.CommandText += "cob_boleto.bol_especie, " ;
               command.CommandText += "cob_boleto.bol_aceite, " ;
               command.CommandText += "cob_boleto.bol_juros_por_dia, " ;
               command.CommandText += "cob_boleto.bol_data_limite_desconto, " ;
               command.CommandText += "cob_boleto.bol_valor_desconto, " ;
               command.CommandText += "cob_boleto.bol_valor_abatimento, " ;
               command.CommandText += "cob_boleto.bol_valor_iof, " ;
               command.CommandText += "cob_boleto.bol_sacado_tipo_documento, " ;
               command.CommandText += "cob_boleto.bol_sacado_numero_documento, " ;
               command.CommandText += "cob_boleto.bol_sacado_nome, " ;
               command.CommandText += "cob_boleto.bol_sacado_logradouro, " ;
               command.CommandText += "cob_boleto.bol_sacado_rua, " ;
               command.CommandText += "cob_boleto.bol_sacado_numero_endereco, " ;
               command.CommandText += "cob_boleto.bol_sacado_complemento_endereco, " ;
               command.CommandText += "cob_boleto.bol_sacado_bairro, " ;
               command.CommandText += "cob_boleto.bol_sacado_cep, " ;
               command.CommandText += "cob_boleto.bol_cidade_sacado, " ;
               command.CommandText += "cob_boleto.bol_uf_sacado, " ;
               command.CommandText += "cob_boleto.bol_data_cancelamento, " ;
               command.CommandText += "cob_boleto.bol_data_baixa, " ;
               command.CommandText += "cob_boleto.bol_data_geracao, " ;
               command.CommandText += "cob_boleto.entity_uid, " ;
               command.CommandText += "cob_boleto.version " ;
               }
               command.CommandText += " FROM  cob_boleto ";
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
                        orderByClause += " , bol_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(bol_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = cob_boleto.id_acs_usuario_ultima_revisao ";
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
                     case "id_cob_boleto":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.id_cob_boleto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.id_cob_boleto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cob_remessa":
                     case "CobRemessa":
                     command.CommandText += " LEFT JOIN cob_remessa as cob_remessa_CobRemessa ON cob_remessa_CobRemessa.id_cob_remessa = cob_boleto.id_cob_remessa ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_remessa_CobRemessa.rem_nome_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_remessa_CobRemessa.rem_nome_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_status":
                     case "Status":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_numero_documento":
                     case "NumeroDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_numero_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_numero_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_data_vencimento":
                     case "DataVencimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_data_vencimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_data_vencimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_valor_titulo":
                     case "ValorTitulo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_valor_titulo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_valor_titulo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_titulo_sistema":
                     case "IdTituloSistema":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.id_titulo_sistema " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.id_titulo_sistema) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_nosso_numero":
                     case "NossoNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_nosso_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_nosso_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_dv_nosso_numero":
                     case "DvNossoNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_dv_nosso_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_dv_nosso_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_data_emissao":
                     case "DataEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_data_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_data_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_agencia":
                     case "Agencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_agencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_agencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_dv_agencia":
                     case "DvAgencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_dv_agencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_dv_agencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_numero_conta":
                     case "NumeroConta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_numero_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_numero_conta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_dv_conta":
                     case "DvConta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_dv_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_dv_conta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_carteira":
                     case "Carteira":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_carteira " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_carteira) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_codigo_carteira":
                     case "CodigoCarteira":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_codigo_carteira " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_codigo_carteira) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_especie":
                     case "Especie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_especie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_especie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_aceite":
                     case "Aceite":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_aceite " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_aceite) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_juros_por_dia":
                     case "JurosPorDia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_juros_por_dia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_juros_por_dia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_data_limite_desconto":
                     case "DataLimiteDesconto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_data_limite_desconto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_data_limite_desconto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_valor_desconto":
                     case "ValorDesconto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_valor_desconto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_valor_desconto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_valor_abatimento":
                     case "ValorAbatimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_valor_abatimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_valor_abatimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_valor_iof":
                     case "ValorIof":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_valor_iof " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_valor_iof) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_sacado_tipo_documento":
                     case "SacadoTipoDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_sacado_tipo_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_sacado_tipo_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_sacado_numero_documento":
                     case "SacadoNumeroDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_sacado_numero_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_sacado_numero_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_sacado_nome":
                     case "SacadoNome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_sacado_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_sacado_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_sacado_logradouro":
                     case "SacadoLogradouro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_sacado_logradouro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_sacado_logradouro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_sacado_rua":
                     case "SacadoRua":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_sacado_rua " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_sacado_rua) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_sacado_numero_endereco":
                     case "SacadoNumeroEndereco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_sacado_numero_endereco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_sacado_numero_endereco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_sacado_complemento_endereco":
                     case "SacadoComplementoEndereco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_sacado_complemento_endereco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_sacado_complemento_endereco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_sacado_bairro":
                     case "SacadoBairro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_sacado_bairro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_sacado_bairro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_sacado_cep":
                     case "SacadoCep":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_sacado_cep " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_sacado_cep) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_cidade_sacado":
                     case "CidadeSacado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_cidade_sacado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_cidade_sacado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_uf_sacado":
                     case "UfSacado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.bol_uf_sacado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.bol_uf_sacado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_data_cancelamento":
                     case "DataCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_data_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_data_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_data_baixa":
                     case "DataBaixa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_data_baixa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_data_baixa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bol_data_geracao":
                     case "DataGeracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto.bol_data_geracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.bol_data_geracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , cob_boleto.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_numero_documento")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_numero_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_numero_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_nosso_numero")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_nosso_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_nosso_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_dv_nosso_numero")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_dv_nosso_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_dv_nosso_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_agencia")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_agencia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_agencia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_dv_agencia")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_dv_agencia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_dv_agencia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_numero_conta")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_numero_conta) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_numero_conta) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_dv_conta")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_dv_conta) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_dv_conta) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_carteira")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_carteira) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_carteira) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_codigo_carteira")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_codigo_carteira) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_codigo_carteira) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_especie")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_especie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_especie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_aceite")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_aceite) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_aceite) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_sacado_numero_documento")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_sacado_numero_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_sacado_numero_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_sacado_nome")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_sacado_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_sacado_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_sacado_logradouro")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_sacado_logradouro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_sacado_logradouro) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_sacado_rua")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_sacado_rua) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_sacado_rua) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_sacado_numero_endereco")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_sacado_numero_endereco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_sacado_numero_endereco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_sacado_complemento_endereco")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_sacado_complemento_endereco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_sacado_complemento_endereco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_sacado_bairro")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_sacado_bairro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_sacado_bairro) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_sacado_cep")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_sacado_cep) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_sacado_cep) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_cidade_sacado")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_cidade_sacado) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_cidade_sacado) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bol_uf_sacado")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.bol_uf_sacado) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.bol_uf_sacado) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(cob_boleto.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_cob_boleto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.id_cob_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.id_cob_boleto = :cob_boleto_ID_2288 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_ID_2288", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CobRemessa" || parametro.FieldName == "id_cob_remessa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CobRemessaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CobRemessaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.id_cob_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.id_cob_remessa = :cob_boleto_CobRemessa_3762 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_CobRemessa_3762", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Status" || parametro.FieldName == "bol_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is CobrancaStatusBoleto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo CobrancaStatusBoleto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_status = :cob_boleto_Status_5852 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Status_5852", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroDocumento" || parametro.FieldName == "bol_numero_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_numero_documento LIKE :cob_boleto_NumeroDocumento_4229 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_NumeroDocumento_4229", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataVencimento" || parametro.FieldName == "bol_data_vencimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_data_vencimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_data_vencimento = :cob_boleto_DataVencimento_8730 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DataVencimento_8730", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTitulo" || parametro.FieldName == "bol_valor_titulo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_valor_titulo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_valor_titulo = :cob_boleto_ValorTitulo_4550 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_ValorTitulo_4550", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdTituloSistema" || parametro.FieldName == "id_titulo_sistema")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.id_titulo_sistema IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.id_titulo_sistema = :cob_boleto_IdTituloSistema_8390 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_IdTituloSistema_8390", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NossoNumero" || parametro.FieldName == "bol_nosso_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_nosso_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_nosso_numero LIKE :cob_boleto_NossoNumero_1536 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_NossoNumero_1536", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvNossoNumero" || parametro.FieldName == "bol_dv_nosso_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_dv_nosso_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_dv_nosso_numero LIKE :cob_boleto_DvNossoNumero_1342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DvNossoNumero_1342", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEmissao" || parametro.FieldName == "bol_data_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_data_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_data_emissao = :cob_boleto_DataEmissao_2760 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DataEmissao_2760", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Agencia" || parametro.FieldName == "bol_agencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_agencia LIKE :cob_boleto_Agencia_1055 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Agencia_1055", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvAgencia" || parametro.FieldName == "bol_dv_agencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_dv_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_dv_agencia LIKE :cob_boleto_DvAgencia_1544 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DvAgencia_1544", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroConta" || parametro.FieldName == "bol_numero_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_numero_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_numero_conta LIKE :cob_boleto_NumeroConta_302 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_NumeroConta_302", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvConta" || parametro.FieldName == "bol_dv_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_dv_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_dv_conta LIKE :cob_boleto_DvConta_9272 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DvConta_9272", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Carteira" || parametro.FieldName == "bol_carteira")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_carteira IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_carteira LIKE :cob_boleto_Carteira_8280 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Carteira_8280", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoCarteira" || parametro.FieldName == "bol_codigo_carteira")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_codigo_carteira IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_codigo_carteira LIKE :cob_boleto_CodigoCarteira_6053 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_CodigoCarteira_6053", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Especie" || parametro.FieldName == "bol_especie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_especie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_especie LIKE :cob_boleto_Especie_1500 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Especie_1500", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aceite" || parametro.FieldName == "bol_aceite")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_aceite IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_aceite LIKE :cob_boleto_Aceite_18 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Aceite_18", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JurosPorDia" || parametro.FieldName == "bol_juros_por_dia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_juros_por_dia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_juros_por_dia = :cob_boleto_JurosPorDia_8697 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_JurosPorDia_8697", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataLimiteDesconto" || parametro.FieldName == "bol_data_limite_desconto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_data_limite_desconto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_data_limite_desconto = :cob_boleto_DataLimiteDesconto_1522 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DataLimiteDesconto_1522", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorDesconto" || parametro.FieldName == "bol_valor_desconto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_valor_desconto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_valor_desconto = :cob_boleto_ValorDesconto_2485 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_ValorDesconto_2485", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorAbatimento" || parametro.FieldName == "bol_valor_abatimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_valor_abatimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_valor_abatimento = :cob_boleto_ValorAbatimento_1760 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_ValorAbatimento_1760", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIof" || parametro.FieldName == "bol_valor_iof")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_valor_iof IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_valor_iof = :cob_boleto_ValorIof_4480 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_ValorIof_4480", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoTipoDocumento" || parametro.FieldName == "bol_sacado_tipo_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is CobrancaTipoDocumento)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo CobrancaTipoDocumento");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_tipo_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_tipo_documento = :cob_boleto_SacadoTipoDocumento_8058 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoTipoDocumento_8058", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoNumeroDocumento" || parametro.FieldName == "bol_sacado_numero_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_numero_documento LIKE :cob_boleto_SacadoNumeroDocumento_3957 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoNumeroDocumento_3957", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoNome" || parametro.FieldName == "bol_sacado_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_nome LIKE :cob_boleto_SacadoNome_3276 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoNome_3276", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoLogradouro" || parametro.FieldName == "bol_sacado_logradouro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_logradouro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_logradouro LIKE :cob_boleto_SacadoLogradouro_7417 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoLogradouro_7417", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoRua" || parametro.FieldName == "bol_sacado_rua")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_rua IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_rua LIKE :cob_boleto_SacadoRua_2724 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoRua_2724", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoNumeroEndereco" || parametro.FieldName == "bol_sacado_numero_endereco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_numero_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_numero_endereco LIKE :cob_boleto_SacadoNumeroEndereco_9284 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoNumeroEndereco_9284", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoComplementoEndereco" || parametro.FieldName == "bol_sacado_complemento_endereco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_complemento_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_complemento_endereco LIKE :cob_boleto_SacadoComplementoEndereco_3460 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoComplementoEndereco_3460", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoBairro" || parametro.FieldName == "bol_sacado_bairro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_bairro LIKE :cob_boleto_SacadoBairro_5497 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoBairro_5497", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoCep" || parametro.FieldName == "bol_sacado_cep")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_cep LIKE :cob_boleto_SacadoCep_8874 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoCep_8874", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CidadeSacado" || parametro.FieldName == "bol_cidade_sacado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_cidade_sacado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_cidade_sacado LIKE :cob_boleto_CidadeSacado_5484 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_CidadeSacado_5484", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfSacado" || parametro.FieldName == "bol_uf_sacado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_uf_sacado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_uf_sacado LIKE :cob_boleto_UfSacado_8331 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_UfSacado_8331", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCancelamento" || parametro.FieldName == "bol_data_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_data_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_data_cancelamento = :cob_boleto_DataCancelamento_6342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DataCancelamento_6342", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataBaixa" || parametro.FieldName == "bol_data_baixa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_data_baixa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_data_baixa = :cob_boleto_DataBaixa_6100 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DataBaixa_6100", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataGeracao" || parametro.FieldName == "bol_data_geracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_data_geracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_data_geracao = :cob_boleto_DataGeracao_7173 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DataGeracao_7173", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  cob_boleto.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.entity_uid LIKE :cob_boleto_EntityUid_2778 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_EntityUid_2778", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  cob_boleto.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.version = :cob_boleto_Version_5203 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Version_5203", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  cob_boleto.bol_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_numero_documento LIKE :cob_boleto_NumeroDocumento_335 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_NumeroDocumento_335", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NossoNumeroExato" || parametro.FieldName == "NossoNumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_nosso_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_nosso_numero LIKE :cob_boleto_NossoNumero_5685 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_NossoNumero_5685", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvNossoNumeroExato" || parametro.FieldName == "DvNossoNumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_dv_nosso_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_dv_nosso_numero LIKE :cob_boleto_DvNossoNumero_9597 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DvNossoNumero_9597", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cob_boleto.bol_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_agencia LIKE :cob_boleto_Agencia_3390 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Agencia_3390", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvAgenciaExato" || parametro.FieldName == "DvAgenciaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_dv_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_dv_agencia LIKE :cob_boleto_DvAgencia_6331 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DvAgencia_6331", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroContaExato" || parametro.FieldName == "NumeroContaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_numero_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_numero_conta LIKE :cob_boleto_NumeroConta_2776 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_NumeroConta_2776", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DvContaExato" || parametro.FieldName == "DvContaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_dv_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_dv_conta LIKE :cob_boleto_DvConta_3987 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_DvConta_3987", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CarteiraExato" || parametro.FieldName == "CarteiraExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_carteira IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_carteira LIKE :cob_boleto_Carteira_6045 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Carteira_6045", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoCarteiraExato" || parametro.FieldName == "CodigoCarteiraExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_codigo_carteira IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_codigo_carteira LIKE :cob_boleto_CodigoCarteira_1804 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_CodigoCarteira_1804", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EspecieExato" || parametro.FieldName == "EspecieExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_especie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_especie LIKE :cob_boleto_Especie_5588 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Especie_5588", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AceiteExato" || parametro.FieldName == "AceiteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_aceite IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_aceite LIKE :cob_boleto_Aceite_604 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_Aceite_604", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoNumeroDocumentoExato" || parametro.FieldName == "SacadoNumeroDocumentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_numero_documento LIKE :cob_boleto_SacadoNumeroDocumento_5820 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoNumeroDocumento_5820", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoNomeExato" || parametro.FieldName == "SacadoNomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_nome LIKE :cob_boleto_SacadoNome_827 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoNome_827", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoLogradouroExato" || parametro.FieldName == "SacadoLogradouroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_logradouro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_logradouro LIKE :cob_boleto_SacadoLogradouro_6645 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoLogradouro_6645", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoRuaExato" || parametro.FieldName == "SacadoRuaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_rua IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_rua LIKE :cob_boleto_SacadoRua_1581 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoRua_1581", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoNumeroEnderecoExato" || parametro.FieldName == "SacadoNumeroEnderecoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_numero_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_numero_endereco LIKE :cob_boleto_SacadoNumeroEndereco_7881 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoNumeroEndereco_7881", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoComplementoEnderecoExato" || parametro.FieldName == "SacadoComplementoEnderecoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_complemento_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_complemento_endereco LIKE :cob_boleto_SacadoComplementoEndereco_529 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoComplementoEndereco_529", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoBairroExato" || parametro.FieldName == "SacadoBairroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_bairro LIKE :cob_boleto_SacadoBairro_9280 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoBairro_9280", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SacadoCepExato" || parametro.FieldName == "SacadoCepExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_sacado_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_sacado_cep LIKE :cob_boleto_SacadoCep_7792 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_SacadoCep_7792", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CidadeSacadoExato" || parametro.FieldName == "CidadeSacadoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_cidade_sacado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_cidade_sacado LIKE :cob_boleto_CidadeSacado_273 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_CidadeSacado_273", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfSacadoExato" || parametro.FieldName == "UfSacadoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto.bol_uf_sacado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.bol_uf_sacado LIKE :cob_boleto_UfSacado_5455 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_UfSacado_5455", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cob_boleto.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto.entity_uid LIKE :cob_boleto_EntityUid_7132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_EntityUid_7132", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  CobBoletoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (CobBoletoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(CobBoletoClass), Convert.ToInt32(read["id_cob_boleto"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new CobBoletoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_cob_boleto"]);
                     if (read["id_cob_remessa"] != DBNull.Value)
                     {
                        entidade.CobRemessa = (BibliotecaEntidades.Entidades.CobRemessaClass)BibliotecaEntidades.Entidades.CobRemessaClass.GetEntidade(Convert.ToInt32(read["id_cob_remessa"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CobRemessa = null ;
                     }
                     entidade.Status = (CobrancaStatusBoleto) (read["bol_status"] != DBNull.Value ? Enum.ToObject(typeof(CobrancaStatusBoleto), read["bol_status"]) : null);
                     entidade.NumeroDocumento = (read["bol_numero_documento"] != DBNull.Value ? read["bol_numero_documento"].ToString() : null);
                     entidade.DataVencimento = (DateTime)read["bol_data_vencimento"];
                     entidade.ValorTitulo = (double)read["bol_valor_titulo"];
                     entidade.IdTituloSistema = (int)read["id_titulo_sistema"];
                     entidade.NossoNumero = (read["bol_nosso_numero"] != DBNull.Value ? read["bol_nosso_numero"].ToString() : null);
                     entidade.DvNossoNumero = (read["bol_dv_nosso_numero"] != DBNull.Value ? read["bol_dv_nosso_numero"].ToString() : null);
                     entidade.DataEmissao = (DateTime)read["bol_data_emissao"];
                     entidade.Agencia = (read["bol_agencia"] != DBNull.Value ? read["bol_agencia"].ToString() : null);
                     entidade.DvAgencia = (read["bol_dv_agencia"] != DBNull.Value ? read["bol_dv_agencia"].ToString() : null);
                     entidade.NumeroConta = (read["bol_numero_conta"] != DBNull.Value ? read["bol_numero_conta"].ToString() : null);
                     entidade.DvConta = (read["bol_dv_conta"] != DBNull.Value ? read["bol_dv_conta"].ToString() : null);
                     entidade.Carteira = (read["bol_carteira"] != DBNull.Value ? read["bol_carteira"].ToString() : null);
                     entidade.CodigoCarteira = (read["bol_codigo_carteira"] != DBNull.Value ? read["bol_codigo_carteira"].ToString() : null);
                     entidade.Especie = (read["bol_especie"] != DBNull.Value ? read["bol_especie"].ToString() : null);
                     entidade.Aceite = (read["bol_aceite"] != DBNull.Value ? read["bol_aceite"].ToString() : null);
                     entidade.JurosPorDia = (double)read["bol_juros_por_dia"];
                     entidade.DataLimiteDesconto = read["bol_data_limite_desconto"] as DateTime?;
                     entidade.ValorDesconto = (double)read["bol_valor_desconto"];
                     entidade.ValorAbatimento = (double)read["bol_valor_abatimento"];
                     entidade.ValorIof = (double)read["bol_valor_iof"];
                     entidade.SacadoTipoDocumento = (CobrancaTipoDocumento) (read["bol_sacado_tipo_documento"] != DBNull.Value ? Enum.ToObject(typeof(CobrancaTipoDocumento), read["bol_sacado_tipo_documento"]) : null);
                     entidade.SacadoNumeroDocumento = (read["bol_sacado_numero_documento"] != DBNull.Value ? read["bol_sacado_numero_documento"].ToString() : null);
                     entidade.SacadoNome = (read["bol_sacado_nome"] != DBNull.Value ? read["bol_sacado_nome"].ToString() : null);
                     entidade.SacadoLogradouro = (read["bol_sacado_logradouro"] != DBNull.Value ? read["bol_sacado_logradouro"].ToString() : null);
                     entidade.SacadoRua = (read["bol_sacado_rua"] != DBNull.Value ? read["bol_sacado_rua"].ToString() : null);
                     entidade.SacadoNumeroEndereco = (read["bol_sacado_numero_endereco"] != DBNull.Value ? read["bol_sacado_numero_endereco"].ToString() : null);
                     entidade.SacadoComplementoEndereco = (read["bol_sacado_complemento_endereco"] != DBNull.Value ? read["bol_sacado_complemento_endereco"].ToString() : null);
                     entidade.SacadoBairro = (read["bol_sacado_bairro"] != DBNull.Value ? read["bol_sacado_bairro"].ToString() : null);
                     entidade.SacadoCep = (read["bol_sacado_cep"] != DBNull.Value ? read["bol_sacado_cep"].ToString() : null);
                     entidade.CidadeSacado = (read["bol_cidade_sacado"] != DBNull.Value ? read["bol_cidade_sacado"].ToString() : null);
                     entidade.UfSacado = (read["bol_uf_sacado"] != DBNull.Value ? read["bol_uf_sacado"].ToString() : null);
                     entidade.DataCancelamento = read["bol_data_cancelamento"] as DateTime?;
                     entidade.DataBaixa = read["bol_data_baixa"] as DateTime?;
                     entidade.DataGeracao = (DateTime)read["bol_data_geracao"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (CobBoletoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
