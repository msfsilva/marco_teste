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
using IWTNF.Entidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNF.Entidades.Base 
{ 
    [Serializable()]
     [Table("nf_principal","nfp")]
     public class NfPrincipalBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfPrincipalClass";
protected const string ErroDelete = "Erro ao excluir o NfPrincipalClass  ";
protected const string ErroSave = "Erro ao salvar o NfPrincipalClass.";
protected const string ErroCollectionNfAtributoClassNfPrincipal = "Erro ao carregar a coleção de NfAtributoClass.";
protected const string ErroCollectionNfClienteClassNfPrincipal = "Erro ao carregar a coleção de NfClienteClass.";
protected const string ErroCollectionNfClienteEnderecoClassNfPrincipal = "Erro ao carregar a coleção de NfClienteEnderecoClass.";
protected const string ErroCollectionNfCobrancaClassNfPrincipal = "Erro ao carregar a coleção de NfCobrancaClass.";
protected const string ErroCollectionNfDuplicataClassNfPrincipal = "Erro ao carregar a coleção de NfDuplicataClass.";
protected const string ErroCollectionNfEmitenteClassNfPrincipal = "Erro ao carregar a coleção de NfEmitenteClass.";
protected const string ErroCollectionNfEmitenteEnderecoClassNfPrincipal = "Erro ao carregar a coleção de NfEmitenteEnderecoClass.";
protected const string ErroCollectionNfExtrasClassNfPrincipal = "Erro ao carregar a coleção de NfExtrasClass.";
protected const string ErroCollectionNfFaturaClassNfPrincipal = "Erro ao carregar a coleção de NfFaturaClass.";
protected const string ErroCollectionNfItemClassNfPrincipal = "Erro ao carregar a coleção de NfItemClass.";
protected const string ErroCollectionNfNotasRelacionadasClassNfPrincipal = "Erro ao carregar a coleção de NfNotasRelacionadasClass.";
protected const string ErroCollectionNfPagamentoClassNfPrincipal = "Erro ao carregar a coleção de NfPagamentoClass.";
protected const string ErroCollectionNfPrincipalClassNfPrincipalSubstituida = "Erro ao carregar a coleção de NfPrincipalClass.";
protected const string ErroCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal = "Erro ao carregar a coleção de NfPrincipalAutorizacaoXmlClass.";
protected const string ErroCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal = "Erro ao carregar a coleção de NfPrincipalCancelamentoJustificativaClass.";
protected const string ErroCollectionNfTotaisClassNfPrincipal = "Erro ao carregar a coleção de NfTotaisClass.";
protected const string ErroCollectionNfTransporteClassNfPrincipal = "Erro ao carregar a coleção de NfTransporteClass.";
protected const string ErroNaturezaOperacaoObrigatorio = "O campo NaturezaOperacao é obrigatório";
protected const string ErroNaturezaOperacaoComprimento = "O campo NaturezaOperacao deve ter no máximo 60 caracteres";
protected const string ErroModeloDocFiscalObrigatorio = "O campo ModeloDocFiscal é obrigatório";
protected const string ErroModeloDocFiscalComprimento = "O campo ModeloDocFiscal deve ter no máximo 2 caracteres";
protected const string ErroVersaoProcessoEmissaoObrigatorio = "O campo VersaoProcessoEmissao é obrigatório";
protected const string ErroVersaoProcessoEmissaoComprimento = "O campo VersaoProcessoEmissao deve ter no máximo 20 caracteres";
protected const string ErroTipoEmitenteObrigatorio = "O campo TipoEmitente é obrigatório";
protected const string ErroTipoEmitenteComprimento = "O campo TipoEmitente deve ter no máximo 1 caracteres";
protected const string ErroSituacaoObrigatorio = "O campo Situacao é obrigatório";
protected const string ErroSituacaoComprimento = "O campo Situacao deve ter no máximo 1 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do NfPrincipalClass.";
protected const string MensagemUtilizadoCollectionNfAtributoClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfAtributoClass:";
protected const string MensagemUtilizadoCollectionNfClienteClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfClienteClass:";
protected const string MensagemUtilizadoCollectionNfClienteEnderecoClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfClienteEnderecoClass:";
protected const string MensagemUtilizadoCollectionNfCobrancaClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfCobrancaClass:";
protected const string MensagemUtilizadoCollectionNfDuplicataClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfDuplicataClass:";
protected const string MensagemUtilizadoCollectionNfEmitenteClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfEmitenteClass:";
protected const string MensagemUtilizadoCollectionNfEmitenteEnderecoClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfEmitenteEnderecoClass:";
protected const string MensagemUtilizadoCollectionNfExtrasClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfExtrasClass:";
protected const string MensagemUtilizadoCollectionNfFaturaClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfFaturaClass:";
protected const string MensagemUtilizadoCollectionNfItemClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfItemClass:";
protected const string MensagemUtilizadoCollectionNfNotasRelacionadasClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfNotasRelacionadasClass:";
protected const string MensagemUtilizadoCollectionNfPagamentoClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfPagamentoClass:";
protected const string MensagemUtilizadoCollectionNfPrincipalClassNfPrincipalSubstituida =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfPrincipalClass:";
protected const string MensagemUtilizadoCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfPrincipalAutorizacaoXmlClass:";
protected const string MensagemUtilizadoCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfPrincipalCancelamentoJustificativaClass:";
protected const string MensagemUtilizadoCollectionNfTotaisClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfTotaisClass:";
protected const string MensagemUtilizadoCollectionNfTransporteClassNfPrincipal =  "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfTransporteClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfPrincipalClass está sendo utilizada.";
#endregion
       protected int _numeroOriginal{get;private set;}
       private int _numeroOriginalCommited{get; set;}
        private int _valueNumero;
         [Column("nfp_numero")]
        public virtual int Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected string _naturezaOperacaoOriginal{get;private set;}
       private string _naturezaOperacaoOriginalCommited{get; set;}
        private string _valueNaturezaOperacao;
         [Column("nfp_natureza_operacao")]
        public virtual string NaturezaOperacao
         { 
            get { return this._valueNaturezaOperacao; } 
            set 
            { 
                if (this._valueNaturezaOperacao == value)return;
                 this._valueNaturezaOperacao = value; 
            } 
        } 

       protected int _serieOriginal{get;private set;}
       private int _serieOriginalCommited{get; set;}
        private int _valueSerie;
         [Column("nfp_serie")]
        public virtual int Serie
         { 
            get { return this._valueSerie; } 
            set 
            { 
                if (this._valueSerie == value)return;
                 this._valueSerie = value; 
            } 
        } 

       protected FormaPagamento _formaPagamentoOriginal{get;private set;}
       private FormaPagamento _formaPagamentoOriginalCommited{get; set;}
        private FormaPagamento _valueFormaPagamento;
         [Column("nfp_forma_pagamento")]
        public virtual FormaPagamento FormaPagamento
         { 
            get { return this._valueFormaPagamento; } 
            set 
            { 
                if (this._valueFormaPagamento == value)return;
                 this._valueFormaPagamento = value; 
            } 
        } 

        public bool FormaPagamento_AVista
         { 
            get { return this._valueFormaPagamento == IWTNF.Entidades.Base.FormaPagamento.AVista; } 
            set { if (value) this._valueFormaPagamento = IWTNF.Entidades.Base.FormaPagamento.AVista; }
         } 

        public bool FormaPagamento_APrazo
         { 
            get { return this._valueFormaPagamento == IWTNF.Entidades.Base.FormaPagamento.APrazo; } 
            set { if (value) this._valueFormaPagamento = IWTNF.Entidades.Base.FormaPagamento.APrazo; }
         } 

        public bool FormaPagamento_Outros
         { 
            get { return this._valueFormaPagamento == IWTNF.Entidades.Base.FormaPagamento.Outros; } 
            set { if (value) this._valueFormaPagamento = IWTNF.Entidades.Base.FormaPagamento.Outros; }
         } 

       protected string _modeloDocFiscalOriginal{get;private set;}
       private string _modeloDocFiscalOriginalCommited{get; set;}
        private string _valueModeloDocFiscal;
         [Column("nfp_modelo_doc_fiscal")]
        public virtual string ModeloDocFiscal
         { 
            get { return this._valueModeloDocFiscal; } 
            set 
            { 
                if (this._valueModeloDocFiscal == value)return;
                 this._valueModeloDocFiscal = value; 
            } 
        } 

       protected DateTime _dataEmissaoOriginal{get;private set;}
       private DateTime _dataEmissaoOriginalCommited{get; set;}
        private DateTime _valueDataEmissao;
         [Column("nfp_data_emissao")]
        public virtual DateTime DataEmissao
         { 
            get { return this._valueDataEmissao; } 
            set 
            { 
                if (this._valueDataEmissao == value)return;
                 this._valueDataEmissao = value; 
            } 
        } 

       protected DateTime? _dataSaidaEntradaOriginal{get;private set;}
       private DateTime? _dataSaidaEntradaOriginalCommited{get; set;}
        private DateTime? _valueDataSaidaEntrada;
         [Column("nfp_data_saida_entrada")]
        public virtual DateTime? DataSaidaEntrada
         { 
            get { return this._valueDataSaidaEntrada; } 
            set 
            { 
                if (this._valueDataSaidaEntrada == value)return;
                 this._valueDataSaidaEntrada = value; 
            } 
        } 

       protected TipoNota _tipoOriginal{get;private set;}
       private TipoNota _tipoOriginalCommited{get; set;}
        private TipoNota _valueTipo;
         [Column("nfp_tipo")]
        public virtual TipoNota Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_Entrada
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.TipoNota.Entrada; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.TipoNota.Entrada; }
         } 

        public bool Tipo_Saida
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.TipoNota.Saida; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.TipoNota.Saida; }
         } 

       protected int _codMunicipioFatoGeradorOriginal{get;private set;}
       private int _codMunicipioFatoGeradorOriginalCommited{get; set;}
        private int _valueCodMunicipioFatoGerador;
         [Column("nfp_cod_municipio_fato_gerador")]
        public virtual int CodMunicipioFatoGerador
         { 
            get { return this._valueCodMunicipioFatoGerador; } 
            set 
            { 
                if (this._valueCodMunicipioFatoGerador == value)return;
                 this._valueCodMunicipioFatoGerador = value; 
            } 
        } 

       protected FormatoImpressao _formatoImpressaoOriginal{get;private set;}
       private FormatoImpressao _formatoImpressaoOriginalCommited{get; set;}
        private FormatoImpressao _valueFormatoImpressao;
         [Column("nfp_formato_impressao")]
        public virtual FormatoImpressao FormatoImpressao
         { 
            get { return this._valueFormatoImpressao; } 
            set 
            { 
                if (this._valueFormatoImpressao == value)return;
                 this._valueFormatoImpressao = value; 
            } 
        } 

        public bool FormatoImpressao_Retrato
         { 
            get { return this._valueFormatoImpressao == IWTNF.Entidades.Base.FormatoImpressao.Retrato; } 
            set { if (value) this._valueFormatoImpressao = IWTNF.Entidades.Base.FormatoImpressao.Retrato; }
         } 

        public bool FormatoImpressao_Paisagem
         { 
            get { return this._valueFormatoImpressao == IWTNF.Entidades.Base.FormatoImpressao.Paisagem; } 
            set { if (value) this._valueFormatoImpressao = IWTNF.Entidades.Base.FormatoImpressao.Paisagem; }
         } 

       protected FormaEmissaoNFe _formaEmissaoOriginal{get;private set;}
       private FormaEmissaoNFe _formaEmissaoOriginalCommited{get; set;}
        private FormaEmissaoNFe _valueFormaEmissao;
         [Column("nfp_forma_emissao")]
        public virtual FormaEmissaoNFe FormaEmissao
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
            get { return this._valueFormaEmissao == IWTNF.Entidades.Base.FormaEmissaoNFe.Normal; } 
            set { if (value) this._valueFormaEmissao = IWTNF.Entidades.Base.FormaEmissaoNFe.Normal; }
         } 

        public bool FormaEmissao_ContingenciaScan
         { 
            get { return this._valueFormaEmissao == IWTNF.Entidades.Base.FormaEmissaoNFe.ContingenciaScan; } 
            set { if (value) this._valueFormaEmissao = IWTNF.Entidades.Base.FormaEmissaoNFe.ContingenciaScan; }
         } 

       protected int _identificacaoAmbienteOriginal{get;private set;}
       private int _identificacaoAmbienteOriginalCommited{get; set;}
        private int _valueIdentificacaoAmbiente;
         [Column("nfp_identificacao_ambiente")]
        public virtual int IdentificacaoAmbiente
         { 
            get { return this._valueIdentificacaoAmbiente; } 
            set 
            { 
                if (this._valueIdentificacaoAmbiente == value)return;
                 this._valueIdentificacaoAmbiente = value; 
            } 
        } 

       protected Finalidade _finalidadeEmissaoOriginal{get;private set;}
       private Finalidade _finalidadeEmissaoOriginalCommited{get; set;}
        private Finalidade _valueFinalidadeEmissao;
         [Column("nfp_finalidade_emissao")]
        public virtual Finalidade FinalidadeEmissao
         { 
            get { return this._valueFinalidadeEmissao; } 
            set 
            { 
                if (this._valueFinalidadeEmissao == value)return;
                 this._valueFinalidadeEmissao = value; 
            } 
        } 

        public bool FinalidadeEmissao_Complementar
         { 
            get { return this._valueFinalidadeEmissao == IWTNF.Entidades.Base.Finalidade.Complementar; } 
            set { if (value) this._valueFinalidadeEmissao = IWTNF.Entidades.Base.Finalidade.Complementar; }
         } 

        public bool FinalidadeEmissao_Ajuste
         { 
            get { return this._valueFinalidadeEmissao == IWTNF.Entidades.Base.Finalidade.Ajuste; } 
            set { if (value) this._valueFinalidadeEmissao = IWTNF.Entidades.Base.Finalidade.Ajuste; }
         } 

        public bool FinalidadeEmissao_Normal
         { 
            get { return this._valueFinalidadeEmissao == IWTNF.Entidades.Base.Finalidade.Normal; } 
            set { if (value) this._valueFinalidadeEmissao = IWTNF.Entidades.Base.Finalidade.Normal; }
         } 

        public bool FinalidadeEmissao_DevolucaoMercadoria
         { 
            get { return this._valueFinalidadeEmissao == IWTNF.Entidades.Base.Finalidade.DevolucaoMercadoria; } 
            set { if (value) this._valueFinalidadeEmissao = IWTNF.Entidades.Base.Finalidade.DevolucaoMercadoria; }
         } 

       protected Processo _processoEmissaoOriginal{get;private set;}
       private Processo _processoEmissaoOriginalCommited{get; set;}
        private Processo _valueProcessoEmissao;
         [Column("nfp_processo_emissao")]
        public virtual Processo ProcessoEmissao
         { 
            get { return this._valueProcessoEmissao; } 
            set 
            { 
                if (this._valueProcessoEmissao == value)return;
                 this._valueProcessoEmissao = value; 
            } 
        } 

        public bool ProcessoEmissao_AplicativoContribuinte
         { 
            get { return this._valueProcessoEmissao == IWTNF.Entidades.Base.Processo.AplicativoContribuinte; } 
            set { if (value) this._valueProcessoEmissao = IWTNF.Entidades.Base.Processo.AplicativoContribuinte; }
         } 

        public bool ProcessoEmissao_AvulsaFisco
         { 
            get { return this._valueProcessoEmissao == IWTNF.Entidades.Base.Processo.AvulsaFisco; } 
            set { if (value) this._valueProcessoEmissao = IWTNF.Entidades.Base.Processo.AvulsaFisco; }
         } 

        public bool ProcessoEmissao_AvulsaSiteFisco
         { 
            get { return this._valueProcessoEmissao == IWTNF.Entidades.Base.Processo.AvulsaSiteFisco; } 
            set { if (value) this._valueProcessoEmissao = IWTNF.Entidades.Base.Processo.AvulsaSiteFisco; }
         } 

        public bool ProcessoEmissao_ContribuinteAplicativoFisco
         { 
            get { return this._valueProcessoEmissao == IWTNF.Entidades.Base.Processo.ContribuinteAplicativoFisco; } 
            set { if (value) this._valueProcessoEmissao = IWTNF.Entidades.Base.Processo.ContribuinteAplicativoFisco; }
         } 

       protected string _versaoProcessoEmissaoOriginal{get;private set;}
       private string _versaoProcessoEmissaoOriginalCommited{get; set;}
        private string _valueVersaoProcessoEmissao;
         [Column("nfp_versao_processo_emissao")]
        public virtual string VersaoProcessoEmissao
         { 
            get { return this._valueVersaoProcessoEmissao; } 
            set 
            { 
                if (this._valueVersaoProcessoEmissao == value)return;
                 this._valueVersaoProcessoEmissao = value; 
            } 
        } 

       protected string _tipoEmitenteOriginal{get;private set;}
       private string _tipoEmitenteOriginalCommited{get; set;}
        private string _valueTipoEmitente;
         [Column("nfp_tipo_emitente")]
        public virtual string TipoEmitente
         { 
            get { return this._valueTipoEmitente; } 
            set 
            { 
                if (this._valueTipoEmitente == value)return;
                 this._valueTipoEmitente = value; 
            } 
        } 

       protected string _situacaoOriginal{get;private set;}
       private string _situacaoOriginalCommited{get; set;}
        private string _valueSituacao;
         [Column("nfp_situacao")]
        public virtual string Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

       protected string _observacoesOriginal{get;private set;}
       private string _observacoesOriginalCommited{get; set;}
        private string _valueObservacoes;
         [Column("nfp_observacoes")]
        public virtual string Observacoes
         { 
            get { return this._valueObservacoes; } 
            set 
            { 
                if (this._valueObservacoes == value)return;
                 this._valueObservacoes = value; 
            } 
        } 

       protected string _observacoesFiscoOriginal{get;private set;}
       private string _observacoesFiscoOriginalCommited{get; set;}
        private string _valueObservacoesFisco;
         [Column("nfp_observacoes_fisco")]
        public virtual string ObservacoesFisco
         { 
            get { return this._valueObservacoesFisco; } 
            set 
            { 
                if (this._valueObservacoesFisco == value)return;
                 this._valueObservacoesFisco = value; 
            } 
        } 

       protected bool _enviarNfeReceitaOriginal{get;private set;}
       private bool _enviarNfeReceitaOriginalCommited{get; set;}
        private bool _valueEnviarNfeReceita;
         [Column("nfp_enviar_nfe_receita")]
        public virtual bool EnviarNfeReceita
         { 
            get { return this._valueEnviarNfeReceita; } 
            set 
            { 
                if (this._valueEnviarNfeReceita == value)return;
                 this._valueEnviarNfeReceita = value; 
            } 
        } 

       protected bool _homologacaoOriginal{get;private set;}
       private bool _homologacaoOriginalCommited{get; set;}
        private bool _valueHomologacao;
         [Column("nfp_homologacao")]
        public virtual bool Homologacao
         { 
            get { return this._valueHomologacao; } 
            set 
            { 
                if (this._valueHomologacao == value)return;
                 this._valueHomologacao = value; 
            } 
        } 

       protected short _impressaOriginal{get;private set;}
       private short _impressaOriginalCommited{get; set;}
        private short _valueImpressa;
         [Column("impressa")]
        public virtual short Impressa
         { 
            get { return this._valueImpressa; } 
            set 
            { 
                if (this._valueImpressa == value)return;
                 this._valueImpressa = value; 
            } 
        } 

       protected bool _enviarNfseLondrinaOriginal{get;private set;}
       private bool _enviarNfseLondrinaOriginalCommited{get; set;}
        private bool _valueEnviarNfseLondrina;
         [Column("nfp_enviar_nfse_londrina")]
        public virtual bool EnviarNfseLondrina
         { 
            get { return this._valueEnviarNfseLondrina; } 
            set 
            { 
                if (this._valueEnviarNfseLondrina == value)return;
                 this._valueEnviarNfseLondrina = value; 
            } 
        } 

       protected bool _tributadaEmissorOriginal{get;private set;}
       private bool _tributadaEmissorOriginalCommited{get; set;}
        private bool _valueTributadaEmissor;
         [Column("nfp_tributada_emissor")]
        public virtual bool TributadaEmissor
         { 
            get { return this._valueTributadaEmissor; } 
            set 
            { 
                if (this._valueTributadaEmissor == value)return;
                 this._valueTributadaEmissor = value; 
            } 
        } 

       protected double _bcIssRetidoOriginal{get;private set;}
       private double _bcIssRetidoOriginalCommited{get; set;}
        private double _valueBcIssRetido;
         [Column("nfp_bc_iss_retido")]
        public virtual double BcIssRetido
         { 
            get { return this._valueBcIssRetido; } 
            set 
            { 
                if (this._valueBcIssRetido == value)return;
                 this._valueBcIssRetido = value; 
            } 
        } 

       protected double _valorIssRetidoOriginal{get;private set;}
       private double _valorIssRetidoOriginalCommited{get; set;}
        private double _valueValorIssRetido;
         [Column("nfp_valor_iss_retido")]
        public virtual double ValorIssRetido
         { 
            get { return this._valueValorIssRetido; } 
            set 
            { 
                if (this._valueValorIssRetido == value)return;
                 this._valueValorIssRetido = value; 
            } 
        } 

       protected int? _rpsNumeroOriginal{get;private set;}
       private int? _rpsNumeroOriginalCommited{get; set;}
        private int? _valueRpsNumero;
         [Column("nfp_rps_numero")]
        public virtual int? RpsNumero
         { 
            get { return this._valueRpsNumero; } 
            set 
            { 
                if (this._valueRpsNumero == value)return;
                 this._valueRpsNumero = value; 
            } 
        } 

       protected string _rpsSerieOriginal{get;private set;}
       private string _rpsSerieOriginalCommited{get; set;}
        private string _valueRpsSerie;
         [Column("nfp_rps_serie")]
        public virtual string RpsSerie
         { 
            get { return this._valueRpsSerie; } 
            set 
            { 
                if (this._valueRpsSerie == value)return;
                 this._valueRpsSerie = value; 
            } 
        } 

       protected DateTime? _rpsDataOriginal{get;private set;}
       private DateTime? _rpsDataOriginalCommited{get; set;}
        private DateTime? _valueRpsData;
         [Column("nfp_rps_data")]
        public virtual DateTime? RpsData
         { 
            get { return this._valueRpsData; } 
            set 
            { 
                if (this._valueRpsData == value)return;
                 this._valueRpsData = value; 
            } 
        } 

       protected bool _consumidorFinalOriginal{get;private set;}
       private bool _consumidorFinalOriginalCommited{get; set;}
        private bool _valueConsumidorFinal;
         [Column("nfp_consumidor_final")]
        public virtual bool ConsumidorFinal
         { 
            get { return this._valueConsumidorFinal; } 
            set 
            { 
                if (this._valueConsumidorFinal == value)return;
                 this._valueConsumidorFinal = value; 
            } 
        } 

       protected PresencaComprador _presencaCompradorOriginal{get;private set;}
       private PresencaComprador _presencaCompradorOriginalCommited{get; set;}
        private PresencaComprador _valuePresencaComprador;
         [Column("nfp_presenca_comprador")]
        public virtual PresencaComprador PresencaComprador
         { 
            get { return this._valuePresencaComprador; } 
            set 
            { 
                if (this._valuePresencaComprador == value)return;
                 this._valuePresencaComprador = value; 
            } 
        } 

        public bool PresencaComprador_ForaEstabelecimento
         { 
            get { return this._valuePresencaComprador == IWTNF.Entidades.Base.PresencaComprador.ForaEstabelecimento; } 
            set { if (value) this._valuePresencaComprador = IWTNF.Entidades.Base.PresencaComprador.ForaEstabelecimento; }
         } 

        public bool PresencaComprador_NFCeEntregaDomicilio
         { 
            get { return this._valuePresencaComprador == IWTNF.Entidades.Base.PresencaComprador.NFCeEntregaDomicilio; } 
            set { if (value) this._valuePresencaComprador = IWTNF.Entidades.Base.PresencaComprador.NFCeEntregaDomicilio; }
         } 

        public bool PresencaComprador_NaoAplicavel
         { 
            get { return this._valuePresencaComprador == IWTNF.Entidades.Base.PresencaComprador.NaoAplicavel; } 
            set { if (value) this._valuePresencaComprador = IWTNF.Entidades.Base.PresencaComprador.NaoAplicavel; }
         } 

        public bool PresencaComprador_Presencial
         { 
            get { return this._valuePresencaComprador == IWTNF.Entidades.Base.PresencaComprador.Presencial; } 
            set { if (value) this._valuePresencaComprador = IWTNF.Entidades.Base.PresencaComprador.Presencial; }
         } 

        public bool PresencaComprador_Internet
         { 
            get { return this._valuePresencaComprador == IWTNF.Entidades.Base.PresencaComprador.Internet; } 
            set { if (value) this._valuePresencaComprador = IWTNF.Entidades.Base.PresencaComprador.Internet; }
         } 

        public bool PresencaComprador_Teleatendimento
         { 
            get { return this._valuePresencaComprador == IWTNF.Entidades.Base.PresencaComprador.Teleatendimento; } 
            set { if (value) this._valuePresencaComprador = IWTNF.Entidades.Base.PresencaComprador.Teleatendimento; }
         } 

        public bool PresencaComprador_NaoPresencialOutros
         { 
            get { return this._valuePresencaComprador == IWTNF.Entidades.Base.PresencaComprador.NaoPresencialOutros; } 
            set { if (value) this._valuePresencaComprador = IWTNF.Entidades.Base.PresencaComprador.NaoPresencialOutros; }
         } 

       protected IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalSubstituidaOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalSubstituidaOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _valueNfPrincipalSubstituida;
        [Column("id_nf_principal_substituida", "nf_principal", "id_nf_principal")]
       public virtual IWTNF.Entidades.Entidades.NfPrincipalClass NfPrincipalSubstituida
        { 
           get {                 return this._valueNfPrincipalSubstituida; } 
           set 
           { 
                if (this._valueNfPrincipalSubstituida == value)return;
                 this._valueNfPrincipalSubstituida = value; 
           } 
       } 

       protected string _textoQrCodeOriginal{get;private set;}
       private string _textoQrCodeOriginalCommited{get; set;}
        private string _valueTextoQrCode;
         [Column("nfp_texto_qr_code")]
        public virtual string TextoQrCode
         { 
            get { return this._valueTextoQrCode; } 
            set 
            { 
                if (this._valueTextoQrCode == value)return;
                 this._valueTextoQrCode = value; 
            } 
        } 

       protected bool _impressaoDanfeLiberadaOriginal{get;private set;}
       private bool _impressaoDanfeLiberadaOriginalCommited{get; set;}
        private bool _valueImpressaoDanfeLiberada;
         [Column("nfp_impressao_danfe_liberada")]
        public virtual bool ImpressaoDanfeLiberada
         { 
            get { return this._valueImpressaoDanfeLiberada; } 
            set 
            { 
                if (this._valueImpressaoDanfeLiberada == value)return;
                 this._valueImpressaoDanfeLiberada = value; 
            } 
        } 

       protected bool _impressaoDanfeContingenciaOriginal{get;private set;}
       private bool _impressaoDanfeContingenciaOriginalCommited{get; set;}
        private bool _valueImpressaoDanfeContingencia;
         [Column("nfp_impressao_danfe_contingencia")]
        public virtual bool ImpressaoDanfeContingencia
         { 
            get { return this._valueImpressaoDanfeContingencia; } 
            set 
            { 
                if (this._valueImpressaoDanfeContingencia == value)return;
                 this._valueImpressaoDanfeContingencia = value; 
            } 
        } 

       protected short? _estoqueMovimentadoOriginal{get;private set;}
       private short? _estoqueMovimentadoOriginalCommited{get; set;}
        private short? _valueEstoqueMovimentado;
         [Column("nfp_estoque_movimentado")]
        public virtual short? EstoqueMovimentado
         { 
            get { return this._valueEstoqueMovimentado; } 
            set 
            { 
                if (this._valueEstoqueMovimentado == value)return;
                 this._valueEstoqueMovimentado = value; 
            } 
        } 

       protected string _cClassTribOriginal{get;private set;}
       private string _cClassTribOriginalCommited{get; set;}
        private string _valueCClassTrib;
         [Column("npr_c_class_trib")]
        public virtual string CClassTrib
         { 
            get { return this._valueCClassTrib; } 
            set 
            { 
                if (this._valueCClassTrib == value)return;
                 this._valueCClassTrib = value; 
            } 
        } 

       protected short? _finDebOriginal{get;private set;}
       private short? _finDebOriginalCommited{get; set;}
        private short? _valueFinDeb;
         [Column("npr_fin_deb")]
        public virtual short? FinDeb
         { 
            get { return this._valueFinDeb; } 
            set 
            { 
                if (this._valueFinDeb == value)return;
                 this._valueFinDeb = value; 
            } 
        } 

       protected short? _finCredOriginal{get;private set;}
       private short? _finCredOriginalCommited{get; set;}
        private short? _valueFinCred;
         [Column("npr_fin_cred")]
        public virtual short? FinCred
         { 
            get { return this._valueFinCred; } 
            set 
            { 
                if (this._valueFinCred == value)return;
                 this._valueFinCred = value; 
            } 
        } 

       private List<long> _collectionNfAtributoClassNfPrincipalOriginal;
       private List<Entidades.NfAtributoClass > _collectionNfAtributoClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfAtributoClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfAtributoClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfAtributoClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfAtributoClass> _valueCollectionNfAtributoClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfAtributoClass> CollectionNfAtributoClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfAtributoClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfAtributoClassNfPrincipal();}
return this._valueCollectionNfAtributoClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfAtributoClassNfPrincipal = value; 
               this._valueCollectionNfAtributoClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfClienteClassNfPrincipalOriginal;
       private List<Entidades.NfClienteClass > _collectionNfClienteClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfClienteClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfClienteClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfClienteClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfClienteClass> _valueCollectionNfClienteClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfClienteClass> CollectionNfClienteClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfClienteClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfClienteClassNfPrincipal();}
return this._valueCollectionNfClienteClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfClienteClassNfPrincipal = value; 
               this._valueCollectionNfClienteClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfClienteEnderecoClassNfPrincipalOriginal;
       private List<Entidades.NfClienteEnderecoClass > _collectionNfClienteEnderecoClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfClienteEnderecoClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfClienteEnderecoClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfClienteEnderecoClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfClienteEnderecoClass> _valueCollectionNfClienteEnderecoClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfClienteEnderecoClass> CollectionNfClienteEnderecoClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfClienteEnderecoClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfClienteEnderecoClassNfPrincipal();}
return this._valueCollectionNfClienteEnderecoClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfClienteEnderecoClassNfPrincipal = value; 
               this._valueCollectionNfClienteEnderecoClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfCobrancaClassNfPrincipalOriginal;
       private List<Entidades.NfCobrancaClass > _collectionNfCobrancaClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfCobrancaClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfCobrancaClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfCobrancaClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfCobrancaClass> _valueCollectionNfCobrancaClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfCobrancaClass> CollectionNfCobrancaClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfCobrancaClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfCobrancaClassNfPrincipal();}
return this._valueCollectionNfCobrancaClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfCobrancaClassNfPrincipal = value; 
               this._valueCollectionNfCobrancaClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfDuplicataClassNfPrincipalOriginal;
       private List<Entidades.NfDuplicataClass > _collectionNfDuplicataClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfDuplicataClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfDuplicataClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfDuplicataClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfDuplicataClass> _valueCollectionNfDuplicataClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfDuplicataClass> CollectionNfDuplicataClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfDuplicataClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfDuplicataClassNfPrincipal();}
return this._valueCollectionNfDuplicataClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfDuplicataClassNfPrincipal = value; 
               this._valueCollectionNfDuplicataClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfEmitenteClassNfPrincipalOriginal;
       private List<Entidades.NfEmitenteClass > _collectionNfEmitenteClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfEmitenteClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfEmitenteClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfEmitenteClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfEmitenteClass> _valueCollectionNfEmitenteClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfEmitenteClass> CollectionNfEmitenteClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfEmitenteClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfEmitenteClassNfPrincipal();}
return this._valueCollectionNfEmitenteClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfEmitenteClassNfPrincipal = value; 
               this._valueCollectionNfEmitenteClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfEmitenteEnderecoClassNfPrincipalOriginal;
       private List<Entidades.NfEmitenteEnderecoClass > _collectionNfEmitenteEnderecoClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfEmitenteEnderecoClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfEmitenteEnderecoClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfEmitenteEnderecoClass> _valueCollectionNfEmitenteEnderecoClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfEmitenteEnderecoClass> CollectionNfEmitenteEnderecoClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfEmitenteEnderecoClassNfPrincipal();}
return this._valueCollectionNfEmitenteEnderecoClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfEmitenteEnderecoClassNfPrincipal = value; 
               this._valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfExtrasClassNfPrincipalOriginal;
       private List<Entidades.NfExtrasClass > _collectionNfExtrasClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfExtrasClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfExtrasClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfExtrasClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfExtrasClass> _valueCollectionNfExtrasClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfExtrasClass> CollectionNfExtrasClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfExtrasClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfExtrasClassNfPrincipal();}
return this._valueCollectionNfExtrasClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfExtrasClassNfPrincipal = value; 
               this._valueCollectionNfExtrasClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfFaturaClassNfPrincipalOriginal;
       private List<Entidades.NfFaturaClass > _collectionNfFaturaClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfFaturaClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfFaturaClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfFaturaClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfFaturaClass> _valueCollectionNfFaturaClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfFaturaClass> CollectionNfFaturaClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfFaturaClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfFaturaClassNfPrincipal();}
return this._valueCollectionNfFaturaClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfFaturaClassNfPrincipal = value; 
               this._valueCollectionNfFaturaClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfItemClassNfPrincipalOriginal;
       private List<Entidades.NfItemClass > _collectionNfItemClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfItemClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfItemClass> _valueCollectionNfItemClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfItemClass> CollectionNfItemClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfItemClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfItemClassNfPrincipal();}
return this._valueCollectionNfItemClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfItemClassNfPrincipal = value; 
               this._valueCollectionNfItemClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfNotasRelacionadasClassNfPrincipalOriginal;
       private List<Entidades.NfNotasRelacionadasClass > _collectionNfNotasRelacionadasClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfNotasRelacionadasClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfNotasRelacionadasClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfNotasRelacionadasClass> _valueCollectionNfNotasRelacionadasClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfNotasRelacionadasClass> CollectionNfNotasRelacionadasClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfNotasRelacionadasClassNfPrincipal();}
return this._valueCollectionNfNotasRelacionadasClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfNotasRelacionadasClassNfPrincipal = value; 
               this._valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfPagamentoClassNfPrincipalOriginal;
       private List<Entidades.NfPagamentoClass > _collectionNfPagamentoClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPagamentoClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPagamentoClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPagamentoClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfPagamentoClass> _valueCollectionNfPagamentoClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfPagamentoClass> CollectionNfPagamentoClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfPagamentoClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfPagamentoClassNfPrincipal();}
return this._valueCollectionNfPagamentoClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfPagamentoClassNfPrincipal = value; 
               this._valueCollectionNfPagamentoClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfPrincipalClassNfPrincipalSubstituidaOriginal;
       private List<Entidades.NfPrincipalClass > _collectionNfPrincipalClassNfPrincipalSubstituidaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPrincipalClassNfPrincipalSubstituidaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPrincipalClassNfPrincipalSubstituidaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfPrincipalClass> _valueCollectionNfPrincipalClassNfPrincipalSubstituida { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfPrincipalClass> CollectionNfPrincipalClassNfPrincipalSubstituida 
       { 
           get { if(!_valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded && !this.DisableLoadCollection){this.LoadCollectionNfPrincipalClassNfPrincipalSubstituida();}
return this._valueCollectionNfPrincipalClassNfPrincipalSubstituida; } 
           set 
           { 
               this._valueCollectionNfPrincipalClassNfPrincipalSubstituida = value; 
               this._valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded = true; 
           } 
       } 

       private List<long> _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalOriginal;
       private List<Entidades.NfPrincipalAutorizacaoXmlClass > _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfPrincipalAutorizacaoXmlClass> _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfPrincipalAutorizacaoXmlClass> CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal();}
return this._valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal = value; 
               this._valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalOriginal;
       private List<Entidades.NfPrincipalCancelamentoJustificativaClass > _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfPrincipalCancelamentoJustificativaClass> _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfPrincipalCancelamentoJustificativaClass> CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal();}
return this._valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal = value; 
               this._valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfTotaisClassNfPrincipalOriginal;
       private List<Entidades.NfTotaisClass > _collectionNfTotaisClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTotaisClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTotaisClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTotaisClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfTotaisClass> _valueCollectionNfTotaisClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfTotaisClass> CollectionNfTotaisClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfTotaisClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfTotaisClassNfPrincipal();}
return this._valueCollectionNfTotaisClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfTotaisClassNfPrincipal = value; 
               this._valueCollectionNfTotaisClassNfPrincipalLoaded = true; 
           } 
       } 

       private List<long> _collectionNfTransporteClassNfPrincipalOriginal;
       private List<Entidades.NfTransporteClass > _collectionNfTransporteClassNfPrincipalRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTransporteClassNfPrincipalLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTransporteClassNfPrincipalChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfTransporteClassNfPrincipalCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfTransporteClass> _valueCollectionNfTransporteClassNfPrincipal { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfTransporteClass> CollectionNfTransporteClassNfPrincipal 
       { 
           get { if(!_valueCollectionNfTransporteClassNfPrincipalLoaded && !this.DisableLoadCollection){this.LoadCollectionNfTransporteClassNfPrincipal();}
return this._valueCollectionNfTransporteClassNfPrincipal; } 
           set 
           { 
               this._valueCollectionNfTransporteClassNfPrincipal = value; 
               this._valueCollectionNfTransporteClassNfPrincipalLoaded = true; 
           } 
       } 

        public NfPrincipalBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.TipoEmitente = "P";
           this.Situacao = "N";
           this.EnviarNfeReceita = false;
           this.Homologacao = false;
           this.Impressa = 0;
           this.EnviarNfseLondrina = false;
           this.TributadaEmissor = true;
           this.BcIssRetido = 0;
           this.ValorIssRetido = 0;
           this.ConsumidorFinal = false;
           this.PresencaComprador = (PresencaComprador)9;
           this.ImpressaoDanfeLiberada = false;
           this.ImpressaoDanfeContingencia = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfPrincipalClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfPrincipalClass) GetEntity(typeof(NfPrincipalClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionNfAtributoClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfAtributoClassNfPrincipalChanged = true;
                  _valueCollectionNfAtributoClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfAtributoClassNfPrincipalChanged = true; 
                  _valueCollectionNfAtributoClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfAtributoClass item in e.OldItems) 
                 { 
                     _collectionNfAtributoClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfAtributoClassNfPrincipalChanged = true; 
                  _valueCollectionNfAtributoClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfAtributoClass item in _valueCollectionNfAtributoClassNfPrincipal) 
                 { 
                     _collectionNfAtributoClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfAtributoClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfAtributoClass> oc;
                _valueCollectionNfAtributoClassNfPrincipalChanged = false;
                 _valueCollectionNfAtributoClassNfPrincipalCommitedChanged = false;
                _collectionNfAtributoClassNfPrincipalRemovidos = new List<Entidades.NfAtributoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfAtributoClass>();
                }
                else{ 
                   Entidades.NfAtributoClass search = new Entidades.NfAtributoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfAtributoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfAtributoClass>().ToList());
                 }
                 _valueCollectionNfAtributoClassNfPrincipal = new BindingList<Entidades.NfAtributoClass>(oc); 
                 _collectionNfAtributoClassNfPrincipalOriginal= (from a in _valueCollectionNfAtributoClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfAtributoClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfAtributoClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfAtributoClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfClienteClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfClienteClassNfPrincipalChanged = true;
                  _valueCollectionNfClienteClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfClienteClassNfPrincipalChanged = true; 
                  _valueCollectionNfClienteClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfClienteClass item in e.OldItems) 
                 { 
                     _collectionNfClienteClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfClienteClassNfPrincipalChanged = true; 
                  _valueCollectionNfClienteClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfClienteClass item in _valueCollectionNfClienteClassNfPrincipal) 
                 { 
                     _collectionNfClienteClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfClienteClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfClienteClass> oc;
                _valueCollectionNfClienteClassNfPrincipalChanged = false;
                 _valueCollectionNfClienteClassNfPrincipalCommitedChanged = false;
                _collectionNfClienteClassNfPrincipalRemovidos = new List<Entidades.NfClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfClienteClass>();
                }
                else{ 
                   Entidades.NfClienteClass search = new Entidades.NfClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfClienteClass>().ToList());
                 }
                 _valueCollectionNfClienteClassNfPrincipal = new BindingList<Entidades.NfClienteClass>(oc); 
                 _collectionNfClienteClassNfPrincipalOriginal= (from a in _valueCollectionNfClienteClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfClienteClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfClienteClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfClienteClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfClienteEnderecoClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfClienteEnderecoClassNfPrincipalChanged = true;
                  _valueCollectionNfClienteEnderecoClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfClienteEnderecoClassNfPrincipalChanged = true; 
                  _valueCollectionNfClienteEnderecoClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfClienteEnderecoClass item in e.OldItems) 
                 { 
                     _collectionNfClienteEnderecoClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfClienteEnderecoClassNfPrincipalChanged = true; 
                  _valueCollectionNfClienteEnderecoClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfClienteEnderecoClass item in _valueCollectionNfClienteEnderecoClassNfPrincipal) 
                 { 
                     _collectionNfClienteEnderecoClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfClienteEnderecoClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfClienteEnderecoClass> oc;
                _valueCollectionNfClienteEnderecoClassNfPrincipalChanged = false;
                 _valueCollectionNfClienteEnderecoClassNfPrincipalCommitedChanged = false;
                _collectionNfClienteEnderecoClassNfPrincipalRemovidos = new List<Entidades.NfClienteEnderecoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfClienteEnderecoClass>();
                }
                else{ 
                   Entidades.NfClienteEnderecoClass search = new Entidades.NfClienteEnderecoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfClienteEnderecoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfClienteEnderecoClass>().ToList());
                 }
                 _valueCollectionNfClienteEnderecoClassNfPrincipal = new BindingList<Entidades.NfClienteEnderecoClass>(oc); 
                 _collectionNfClienteEnderecoClassNfPrincipalOriginal= (from a in _valueCollectionNfClienteEnderecoClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfClienteEnderecoClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfClienteEnderecoClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfClienteEnderecoClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfCobrancaClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfCobrancaClassNfPrincipalChanged = true;
                  _valueCollectionNfCobrancaClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfCobrancaClassNfPrincipalChanged = true; 
                  _valueCollectionNfCobrancaClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfCobrancaClass item in e.OldItems) 
                 { 
                     _collectionNfCobrancaClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfCobrancaClassNfPrincipalChanged = true; 
                  _valueCollectionNfCobrancaClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfCobrancaClass item in _valueCollectionNfCobrancaClassNfPrincipal) 
                 { 
                     _collectionNfCobrancaClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfCobrancaClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfCobrancaClass> oc;
                _valueCollectionNfCobrancaClassNfPrincipalChanged = false;
                 _valueCollectionNfCobrancaClassNfPrincipalCommitedChanged = false;
                _collectionNfCobrancaClassNfPrincipalRemovidos = new List<Entidades.NfCobrancaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfCobrancaClass>();
                }
                else{ 
                   Entidades.NfCobrancaClass search = new Entidades.NfCobrancaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfCobrancaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfCobrancaClass>().ToList());
                 }
                 _valueCollectionNfCobrancaClassNfPrincipal = new BindingList<Entidades.NfCobrancaClass>(oc); 
                 _collectionNfCobrancaClassNfPrincipalOriginal= (from a in _valueCollectionNfCobrancaClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfCobrancaClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfCobrancaClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfCobrancaClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfDuplicataClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfDuplicataClassNfPrincipalChanged = true;
                  _valueCollectionNfDuplicataClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfDuplicataClassNfPrincipalChanged = true; 
                  _valueCollectionNfDuplicataClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfDuplicataClass item in e.OldItems) 
                 { 
                     _collectionNfDuplicataClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfDuplicataClassNfPrincipalChanged = true; 
                  _valueCollectionNfDuplicataClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfDuplicataClass item in _valueCollectionNfDuplicataClassNfPrincipal) 
                 { 
                     _collectionNfDuplicataClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfDuplicataClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfDuplicataClass> oc;
                _valueCollectionNfDuplicataClassNfPrincipalChanged = false;
                 _valueCollectionNfDuplicataClassNfPrincipalCommitedChanged = false;
                _collectionNfDuplicataClassNfPrincipalRemovidos = new List<Entidades.NfDuplicataClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfDuplicataClass>();
                }
                else{ 
                   Entidades.NfDuplicataClass search = new Entidades.NfDuplicataClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfDuplicataClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfDuplicataClass>().ToList());
                 }
                 _valueCollectionNfDuplicataClassNfPrincipal = new BindingList<Entidades.NfDuplicataClass>(oc); 
                 _collectionNfDuplicataClassNfPrincipalOriginal= (from a in _valueCollectionNfDuplicataClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfDuplicataClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfDuplicataClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfDuplicataClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfEmitenteClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfEmitenteClassNfPrincipalChanged = true;
                  _valueCollectionNfEmitenteClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfEmitenteClassNfPrincipalChanged = true; 
                  _valueCollectionNfEmitenteClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfEmitenteClass item in e.OldItems) 
                 { 
                     _collectionNfEmitenteClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfEmitenteClassNfPrincipalChanged = true; 
                  _valueCollectionNfEmitenteClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfEmitenteClass item in _valueCollectionNfEmitenteClassNfPrincipal) 
                 { 
                     _collectionNfEmitenteClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfEmitenteClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfEmitenteClass> oc;
                _valueCollectionNfEmitenteClassNfPrincipalChanged = false;
                 _valueCollectionNfEmitenteClassNfPrincipalCommitedChanged = false;
                _collectionNfEmitenteClassNfPrincipalRemovidos = new List<Entidades.NfEmitenteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfEmitenteClass>();
                }
                else{ 
                   Entidades.NfEmitenteClass search = new Entidades.NfEmitenteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfEmitenteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfEmitenteClass>().ToList());
                 }
                 _valueCollectionNfEmitenteClassNfPrincipal = new BindingList<Entidades.NfEmitenteClass>(oc); 
                 _collectionNfEmitenteClassNfPrincipalOriginal= (from a in _valueCollectionNfEmitenteClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfEmitenteClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfEmitenteClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfEmitenteClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfEmitenteEnderecoClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfEmitenteEnderecoClassNfPrincipalChanged = true;
                  _valueCollectionNfEmitenteEnderecoClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfEmitenteEnderecoClassNfPrincipalChanged = true; 
                  _valueCollectionNfEmitenteEnderecoClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfEmitenteEnderecoClass item in e.OldItems) 
                 { 
                     _collectionNfEmitenteEnderecoClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfEmitenteEnderecoClassNfPrincipalChanged = true; 
                  _valueCollectionNfEmitenteEnderecoClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfEmitenteEnderecoClass item in _valueCollectionNfEmitenteEnderecoClassNfPrincipal) 
                 { 
                     _collectionNfEmitenteEnderecoClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfEmitenteEnderecoClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfEmitenteEnderecoClass> oc;
                _valueCollectionNfEmitenteEnderecoClassNfPrincipalChanged = false;
                 _valueCollectionNfEmitenteEnderecoClassNfPrincipalCommitedChanged = false;
                _collectionNfEmitenteEnderecoClassNfPrincipalRemovidos = new List<Entidades.NfEmitenteEnderecoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfEmitenteEnderecoClass>();
                }
                else{ 
                   Entidades.NfEmitenteEnderecoClass search = new Entidades.NfEmitenteEnderecoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfEmitenteEnderecoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfEmitenteEnderecoClass>().ToList());
                 }
                 _valueCollectionNfEmitenteEnderecoClassNfPrincipal = new BindingList<Entidades.NfEmitenteEnderecoClass>(oc); 
                 _collectionNfEmitenteEnderecoClassNfPrincipalOriginal= (from a in _valueCollectionNfEmitenteEnderecoClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfEmitenteEnderecoClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfEmitenteEnderecoClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfExtrasClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfExtrasClassNfPrincipalChanged = true;
                  _valueCollectionNfExtrasClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfExtrasClassNfPrincipalChanged = true; 
                  _valueCollectionNfExtrasClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfExtrasClass item in e.OldItems) 
                 { 
                     _collectionNfExtrasClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfExtrasClassNfPrincipalChanged = true; 
                  _valueCollectionNfExtrasClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfExtrasClass item in _valueCollectionNfExtrasClassNfPrincipal) 
                 { 
                     _collectionNfExtrasClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfExtrasClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfExtrasClass> oc;
                _valueCollectionNfExtrasClassNfPrincipalChanged = false;
                 _valueCollectionNfExtrasClassNfPrincipalCommitedChanged = false;
                _collectionNfExtrasClassNfPrincipalRemovidos = new List<Entidades.NfExtrasClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfExtrasClass>();
                }
                else{ 
                   Entidades.NfExtrasClass search = new Entidades.NfExtrasClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfExtrasClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfExtrasClass>().ToList());
                 }
                 _valueCollectionNfExtrasClassNfPrincipal = new BindingList<Entidades.NfExtrasClass>(oc); 
                 _collectionNfExtrasClassNfPrincipalOriginal= (from a in _valueCollectionNfExtrasClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfExtrasClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfExtrasClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfExtrasClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfFaturaClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfFaturaClassNfPrincipalChanged = true;
                  _valueCollectionNfFaturaClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfFaturaClassNfPrincipalChanged = true; 
                  _valueCollectionNfFaturaClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfFaturaClass item in e.OldItems) 
                 { 
                     _collectionNfFaturaClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfFaturaClassNfPrincipalChanged = true; 
                  _valueCollectionNfFaturaClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfFaturaClass item in _valueCollectionNfFaturaClassNfPrincipal) 
                 { 
                     _collectionNfFaturaClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfFaturaClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfFaturaClass> oc;
                _valueCollectionNfFaturaClassNfPrincipalChanged = false;
                 _valueCollectionNfFaturaClassNfPrincipalCommitedChanged = false;
                _collectionNfFaturaClassNfPrincipalRemovidos = new List<Entidades.NfFaturaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfFaturaClass>();
                }
                else{ 
                   Entidades.NfFaturaClass search = new Entidades.NfFaturaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfFaturaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfFaturaClass>().ToList());
                 }
                 _valueCollectionNfFaturaClassNfPrincipal = new BindingList<Entidades.NfFaturaClass>(oc); 
                 _collectionNfFaturaClassNfPrincipalOriginal= (from a in _valueCollectionNfFaturaClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfFaturaClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfFaturaClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfFaturaClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfItemClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfItemClassNfPrincipalChanged = true;
                  _valueCollectionNfItemClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfItemClassNfPrincipalChanged = true; 
                  _valueCollectionNfItemClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfItemClass item in e.OldItems) 
                 { 
                     _collectionNfItemClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfItemClassNfPrincipalChanged = true; 
                  _valueCollectionNfItemClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfItemClass item in _valueCollectionNfItemClassNfPrincipal) 
                 { 
                     _collectionNfItemClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfItemClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfItemClass> oc;
                _valueCollectionNfItemClassNfPrincipalChanged = false;
                 _valueCollectionNfItemClassNfPrincipalCommitedChanged = false;
                _collectionNfItemClassNfPrincipalRemovidos = new List<Entidades.NfItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfItemClass>();
                }
                else{ 
                   Entidades.NfItemClass search = new Entidades.NfItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfItemClass>().ToList());
                 }
                 _valueCollectionNfItemClassNfPrincipal = new BindingList<Entidades.NfItemClass>(oc); 
                 _collectionNfItemClassNfPrincipalOriginal= (from a in _valueCollectionNfItemClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfItemClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfItemClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfItemClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfNotasRelacionadasClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfNotasRelacionadasClassNfPrincipalChanged = true;
                  _valueCollectionNfNotasRelacionadasClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfNotasRelacionadasClassNfPrincipalChanged = true; 
                  _valueCollectionNfNotasRelacionadasClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfNotasRelacionadasClass item in e.OldItems) 
                 { 
                     _collectionNfNotasRelacionadasClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfNotasRelacionadasClassNfPrincipalChanged = true; 
                  _valueCollectionNfNotasRelacionadasClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfNotasRelacionadasClass item in _valueCollectionNfNotasRelacionadasClassNfPrincipal) 
                 { 
                     _collectionNfNotasRelacionadasClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfNotasRelacionadasClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfNotasRelacionadasClass> oc;
                _valueCollectionNfNotasRelacionadasClassNfPrincipalChanged = false;
                 _valueCollectionNfNotasRelacionadasClassNfPrincipalCommitedChanged = false;
                _collectionNfNotasRelacionadasClassNfPrincipalRemovidos = new List<Entidades.NfNotasRelacionadasClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfNotasRelacionadasClass>();
                }
                else{ 
                   Entidades.NfNotasRelacionadasClass search = new Entidades.NfNotasRelacionadasClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfNotasRelacionadasClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfNotasRelacionadasClass>().ToList());
                 }
                 _valueCollectionNfNotasRelacionadasClassNfPrincipal = new BindingList<Entidades.NfNotasRelacionadasClass>(oc); 
                 _collectionNfNotasRelacionadasClassNfPrincipalOriginal= (from a in _valueCollectionNfNotasRelacionadasClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfNotasRelacionadasClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfNotasRelacionadasClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfPagamentoClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfPagamentoClassNfPrincipalChanged = true;
                  _valueCollectionNfPagamentoClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfPagamentoClassNfPrincipalChanged = true; 
                  _valueCollectionNfPagamentoClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfPagamentoClass item in e.OldItems) 
                 { 
                     _collectionNfPagamentoClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfPagamentoClassNfPrincipalChanged = true; 
                  _valueCollectionNfPagamentoClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfPagamentoClass item in _valueCollectionNfPagamentoClassNfPrincipal) 
                 { 
                     _collectionNfPagamentoClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfPagamentoClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfPagamentoClass> oc;
                _valueCollectionNfPagamentoClassNfPrincipalChanged = false;
                 _valueCollectionNfPagamentoClassNfPrincipalCommitedChanged = false;
                _collectionNfPagamentoClassNfPrincipalRemovidos = new List<Entidades.NfPagamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfPagamentoClass>();
                }
                else{ 
                   Entidades.NfPagamentoClass search = new Entidades.NfPagamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfPagamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this),                     }                       ).Cast<Entidades.NfPagamentoClass>().ToList());
                 }
                 _valueCollectionNfPagamentoClassNfPrincipal = new BindingList<Entidades.NfPagamentoClass>(oc); 
                 _collectionNfPagamentoClassNfPrincipalOriginal= (from a in _valueCollectionNfPagamentoClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfPagamentoClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfPagamentoClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfPagamentoClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfPrincipalClassNfPrincipalSubstituidaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfPrincipalClassNfPrincipalSubstituidaChanged = true;
                  _valueCollectionNfPrincipalClassNfPrincipalSubstituidaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfPrincipalClassNfPrincipalSubstituidaChanged = true; 
                  _valueCollectionNfPrincipalClassNfPrincipalSubstituidaCommitedChanged = true;
                 foreach (Entidades.NfPrincipalClass item in e.OldItems) 
                 { 
                     _collectionNfPrincipalClassNfPrincipalSubstituidaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfPrincipalClassNfPrincipalSubstituidaChanged = true; 
                  _valueCollectionNfPrincipalClassNfPrincipalSubstituidaCommitedChanged = true;
                 foreach (Entidades.NfPrincipalClass item in _valueCollectionNfPrincipalClassNfPrincipalSubstituida) 
                 { 
                     _collectionNfPrincipalClassNfPrincipalSubstituidaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfPrincipalClassNfPrincipalSubstituida()
         {
            try
            {
                 ObservableCollection<Entidades.NfPrincipalClass> oc;
                _valueCollectionNfPrincipalClassNfPrincipalSubstituidaChanged = false;
                 _valueCollectionNfPrincipalClassNfPrincipalSubstituidaCommitedChanged = false;
                _collectionNfPrincipalClassNfPrincipalSubstituidaRemovidos = new List<Entidades.NfPrincipalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfPrincipalClass>();
                }
                else{ 
                   Entidades.NfPrincipalClass search = new Entidades.NfPrincipalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfPrincipalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipalSubstituida", this),                     }                       ).Cast<Entidades.NfPrincipalClass>().ToList());
                 }
                 _valueCollectionNfPrincipalClassNfPrincipalSubstituida = new BindingList<Entidades.NfPrincipalClass>(oc); 
                 _collectionNfPrincipalClassNfPrincipalSubstituidaOriginal= (from a in _valueCollectionNfPrincipalClassNfPrincipalSubstituida select a.ID).ToList();
                 _valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded = true;
                 oc.CollectionChanged += CollectionNfPrincipalClassNfPrincipalSubstituidaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfPrincipalClassNfPrincipalSubstituida+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfPrincipalAutorizacaoXmlClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalChanged = true;
                  _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalChanged = true; 
                  _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfPrincipalAutorizacaoXmlClass item in e.OldItems) 
                 { 
                     _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalChanged = true; 
                  _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfPrincipalAutorizacaoXmlClass item in _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal) 
                 { 
                     _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfPrincipalAutorizacaoXmlClass> oc;
                _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalChanged = false;
                 _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalCommitedChanged = false;
                _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalRemovidos = new List<Entidades.NfPrincipalAutorizacaoXmlClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfPrincipalAutorizacaoXmlClass>();
                }
                else{ 
                   Entidades.NfPrincipalAutorizacaoXmlClass search = new Entidades.NfPrincipalAutorizacaoXmlClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfPrincipalAutorizacaoXmlClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this),                     }                       ).Cast<Entidades.NfPrincipalAutorizacaoXmlClass>().ToList());
                 }
                 _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal = new BindingList<Entidades.NfPrincipalAutorizacaoXmlClass>(oc); 
                 _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalOriginal= (from a in _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfPrincipalAutorizacaoXmlClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalChanged = true;
                  _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalChanged = true; 
                  _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfPrincipalCancelamentoJustificativaClass item in e.OldItems) 
                 { 
                     _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalChanged = true; 
                  _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfPrincipalCancelamentoJustificativaClass item in _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal) 
                 { 
                     _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfPrincipalCancelamentoJustificativaClass> oc;
                _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalChanged = false;
                 _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalCommitedChanged = false;
                _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalRemovidos = new List<Entidades.NfPrincipalCancelamentoJustificativaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfPrincipalCancelamentoJustificativaClass>();
                }
                else{ 
                   Entidades.NfPrincipalCancelamentoJustificativaClass search = new Entidades.NfPrincipalCancelamentoJustificativaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfPrincipalCancelamentoJustificativaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfPrincipalCancelamentoJustificativaClass>().ToList());
                 }
                 _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal = new BindingList<Entidades.NfPrincipalCancelamentoJustificativaClass>(oc); 
                 _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalOriginal= (from a in _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfTotaisClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfTotaisClassNfPrincipalChanged = true;
                  _valueCollectionNfTotaisClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfTotaisClassNfPrincipalChanged = true; 
                  _valueCollectionNfTotaisClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfTotaisClass item in e.OldItems) 
                 { 
                     _collectionNfTotaisClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfTotaisClassNfPrincipalChanged = true; 
                  _valueCollectionNfTotaisClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfTotaisClass item in _valueCollectionNfTotaisClassNfPrincipal) 
                 { 
                     _collectionNfTotaisClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfTotaisClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfTotaisClass> oc;
                _valueCollectionNfTotaisClassNfPrincipalChanged = false;
                 _valueCollectionNfTotaisClassNfPrincipalCommitedChanged = false;
                _collectionNfTotaisClassNfPrincipalRemovidos = new List<Entidades.NfTotaisClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfTotaisClass>();
                }
                else{ 
                   Entidades.NfTotaisClass search = new Entidades.NfTotaisClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfTotaisClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfTotaisClass>().ToList());
                 }
                 _valueCollectionNfTotaisClassNfPrincipal = new BindingList<Entidades.NfTotaisClass>(oc); 
                 _collectionNfTotaisClassNfPrincipalOriginal= (from a in _valueCollectionNfTotaisClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfTotaisClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfTotaisClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfTotaisClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNfTransporteClassNfPrincipalChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfTransporteClassNfPrincipalChanged = true;
                  _valueCollectionNfTransporteClassNfPrincipalCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfTransporteClassNfPrincipalChanged = true; 
                  _valueCollectionNfTransporteClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfTransporteClass item in e.OldItems) 
                 { 
                     _collectionNfTransporteClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfTransporteClassNfPrincipalChanged = true; 
                  _valueCollectionNfTransporteClassNfPrincipalCommitedChanged = true;
                 foreach (Entidades.NfTransporteClass item in _valueCollectionNfTransporteClassNfPrincipal) 
                 { 
                     _collectionNfTransporteClassNfPrincipalRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfTransporteClassNfPrincipal()
         {
            try
            {
                 ObservableCollection<Entidades.NfTransporteClass> oc;
                _valueCollectionNfTransporteClassNfPrincipalChanged = false;
                 _valueCollectionNfTransporteClassNfPrincipalCommitedChanged = false;
                _collectionNfTransporteClassNfPrincipalRemovidos = new List<Entidades.NfTransporteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfTransporteClass>();
                }
                else{ 
                   Entidades.NfTransporteClass search = new Entidades.NfTransporteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfTransporteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfPrincipal", this)                    }                       ).Cast<Entidades.NfTransporteClass>().ToList());
                 }
                 _valueCollectionNfTransporteClassNfPrincipal = new BindingList<Entidades.NfTransporteClass>(oc); 
                 _collectionNfTransporteClassNfPrincipalOriginal= (from a in _valueCollectionNfTransporteClassNfPrincipal select a.ID).ToList();
                 _valueCollectionNfTransporteClassNfPrincipalLoaded = true;
                 oc.CollectionChanged += CollectionNfTransporteClassNfPrincipalChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfTransporteClassNfPrincipal+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NaturezaOperacao))
                {
                    throw new Exception(ErroNaturezaOperacaoObrigatorio);
                }
                if (NaturezaOperacao.Length >60)
                {
                    throw new Exception( ErroNaturezaOperacaoComprimento);
                }
                if (string.IsNullOrEmpty(ModeloDocFiscal))
                {
                    throw new Exception(ErroModeloDocFiscalObrigatorio);
                }
                if (ModeloDocFiscal.Length >2)
                {
                    throw new Exception( ErroModeloDocFiscalComprimento);
                }
                if (string.IsNullOrEmpty(VersaoProcessoEmissao))
                {
                    throw new Exception(ErroVersaoProcessoEmissaoObrigatorio);
                }
                if (VersaoProcessoEmissao.Length >20)
                {
                    throw new Exception( ErroVersaoProcessoEmissaoComprimento);
                }
                if (string.IsNullOrEmpty(TipoEmitente))
                {
                    throw new Exception(ErroTipoEmitenteObrigatorio);
                }
                if (TipoEmitente.Length >1)
                {
                    throw new Exception( ErroTipoEmitenteComprimento);
                }
                if (string.IsNullOrEmpty(Situacao))
                {
                    throw new Exception(ErroSituacaoObrigatorio);
                }
                if (Situacao.Length >1)
                {
                    throw new Exception( ErroSituacaoComprimento);
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
                    "  public.nf_principal  " +
                    "WHERE " +
                    "  id_nf_principal = :id";
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
                        "  public.nf_principal   " +
                        "SET  " + 
                        "  nfp_numero = :nfp_numero, " + 
                        "  nfp_natureza_operacao = :nfp_natureza_operacao, " + 
                        "  nfp_serie = :nfp_serie, " + 
                        "  nfp_forma_pagamento = :nfp_forma_pagamento, " + 
                        "  nfp_modelo_doc_fiscal = :nfp_modelo_doc_fiscal, " + 
                        "  nfp_data_emissao = :nfp_data_emissao, " + 
                        "  nfp_data_saida_entrada = :nfp_data_saida_entrada, " + 
                        "  nfp_tipo = :nfp_tipo, " + 
                        "  nfp_cod_municipio_fato_gerador = :nfp_cod_municipio_fato_gerador, " + 
                        "  nfp_formato_impressao = :nfp_formato_impressao, " + 
                        "  nfp_forma_emissao = :nfp_forma_emissao, " + 
                        "  nfp_identificacao_ambiente = :nfp_identificacao_ambiente, " + 
                        "  nfp_finalidade_emissao = :nfp_finalidade_emissao, " + 
                        "  nfp_processo_emissao = :nfp_processo_emissao, " + 
                        "  nfp_versao_processo_emissao = :nfp_versao_processo_emissao, " + 
                        "  nfp_tipo_emitente = :nfp_tipo_emitente, " + 
                        "  nfp_situacao = :nfp_situacao, " + 
                        "  nfp_observacoes = :nfp_observacoes, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nfp_observacoes_fisco = :nfp_observacoes_fisco, " + 
                        "  nfp_enviar_nfe_receita = :nfp_enviar_nfe_receita, " + 
                        "  nfp_homologacao = :nfp_homologacao, " + 
                        "  impressa = :impressa, " + 
                        "  nfp_enviar_nfse_londrina = :nfp_enviar_nfse_londrina, " + 
                        "  nfp_tributada_emissor = :nfp_tributada_emissor, " + 
                        "  nfp_bc_iss_retido = :nfp_bc_iss_retido, " + 
                        "  nfp_valor_iss_retido = :nfp_valor_iss_retido, " + 
                        "  nfp_rps_numero = :nfp_rps_numero, " + 
                        "  nfp_rps_serie = :nfp_rps_serie, " + 
                        "  nfp_rps_data = :nfp_rps_data, " + 
                        "  nfp_consumidor_final = :nfp_consumidor_final, " + 
                        "  nfp_presenca_comprador = :nfp_presenca_comprador, " + 
                        "  id_nf_principal_substituida = :id_nf_principal_substituida, " + 
                        "  nfp_texto_qr_code = :nfp_texto_qr_code, " + 
                        "  nfp_impressao_danfe_liberada = :nfp_impressao_danfe_liberada, " + 
                        "  nfp_impressao_danfe_contingencia = :nfp_impressao_danfe_contingencia, " + 
                        "  nfp_estoque_movimentado = :nfp_estoque_movimentado, " + 
                        "  npr_c_class_trib = :npr_c_class_trib, " + 
                        "  npr_fin_deb = :npr_fin_deb, " + 
                        "  npr_fin_cred = :npr_fin_cred "+
                        "WHERE  " +
                        "  id_nf_principal = :id " +
                        "RETURNING id_nf_principal;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_principal " +
                        "( " +
                        "  nfp_numero , " + 
                        "  nfp_natureza_operacao , " + 
                        "  nfp_serie , " + 
                        "  nfp_forma_pagamento , " + 
                        "  nfp_modelo_doc_fiscal , " + 
                        "  nfp_data_emissao , " + 
                        "  nfp_data_saida_entrada , " + 
                        "  nfp_tipo , " + 
                        "  nfp_cod_municipio_fato_gerador , " + 
                        "  nfp_formato_impressao , " + 
                        "  nfp_forma_emissao , " + 
                        "  nfp_identificacao_ambiente , " + 
                        "  nfp_finalidade_emissao , " + 
                        "  nfp_processo_emissao , " + 
                        "  nfp_versao_processo_emissao , " + 
                        "  nfp_tipo_emitente , " + 
                        "  nfp_situacao , " + 
                        "  nfp_observacoes , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nfp_observacoes_fisco , " + 
                        "  nfp_enviar_nfe_receita , " + 
                        "  nfp_homologacao , " + 
                        "  impressa , " + 
                        "  nfp_enviar_nfse_londrina , " + 
                        "  nfp_tributada_emissor , " + 
                        "  nfp_bc_iss_retido , " + 
                        "  nfp_valor_iss_retido , " + 
                        "  nfp_rps_numero , " + 
                        "  nfp_rps_serie , " + 
                        "  nfp_rps_data , " + 
                        "  nfp_consumidor_final , " + 
                        "  nfp_presenca_comprador , " + 
                        "  id_nf_principal_substituida , " + 
                        "  nfp_texto_qr_code , " + 
                        "  nfp_impressao_danfe_liberada , " + 
                        "  nfp_impressao_danfe_contingencia , " + 
                        "  nfp_estoque_movimentado , " + 
                        "  npr_c_class_trib , " + 
                        "  npr_fin_deb , " + 
                        "  npr_fin_cred  "+
                        ")  " +
                        "VALUES ( " +
                        "  :nfp_numero , " + 
                        "  :nfp_natureza_operacao , " + 
                        "  :nfp_serie , " + 
                        "  :nfp_forma_pagamento , " + 
                        "  :nfp_modelo_doc_fiscal , " + 
                        "  :nfp_data_emissao , " + 
                        "  :nfp_data_saida_entrada , " + 
                        "  :nfp_tipo , " + 
                        "  :nfp_cod_municipio_fato_gerador , " + 
                        "  :nfp_formato_impressao , " + 
                        "  :nfp_forma_emissao , " + 
                        "  :nfp_identificacao_ambiente , " + 
                        "  :nfp_finalidade_emissao , " + 
                        "  :nfp_processo_emissao , " + 
                        "  :nfp_versao_processo_emissao , " + 
                        "  :nfp_tipo_emitente , " + 
                        "  :nfp_situacao , " + 
                        "  :nfp_observacoes , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nfp_observacoes_fisco , " + 
                        "  :nfp_enviar_nfe_receita , " + 
                        "  :nfp_homologacao , " + 
                        "  :impressa , " + 
                        "  :nfp_enviar_nfse_londrina , " + 
                        "  :nfp_tributada_emissor , " + 
                        "  :nfp_bc_iss_retido , " + 
                        "  :nfp_valor_iss_retido , " + 
                        "  :nfp_rps_numero , " + 
                        "  :nfp_rps_serie , " + 
                        "  :nfp_rps_data , " + 
                        "  :nfp_consumidor_final , " + 
                        "  :nfp_presenca_comprador , " + 
                        "  :id_nf_principal_substituida , " + 
                        "  :nfp_texto_qr_code , " + 
                        "  :nfp_impressao_danfe_liberada , " + 
                        "  :nfp_impressao_danfe_contingencia , " + 
                        "  :nfp_estoque_movimentado , " + 
                        "  :npr_c_class_trib , " + 
                        "  :npr_fin_deb , " + 
                        "  :npr_fin_cred  "+
                        ")RETURNING id_nf_principal;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_natureza_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NaturezaOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Serie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_forma_pagamento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.FormaPagamento);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_modelo_doc_fiscal", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ModeloDocFiscal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_data_emissao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_data_saida_entrada", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataSaidaEntrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_cod_municipio_fato_gerador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodMunicipioFatoGerador ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_formato_impressao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.FormatoImpressao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_forma_emissao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.FormaEmissao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_identificacao_ambiente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdentificacaoAmbiente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_finalidade_emissao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.FinalidadeEmissao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_processo_emissao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ProcessoEmissao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_versao_processo_emissao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoProcessoEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_tipo_emitente", NpgsqlDbType.Char));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoEmitente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_situacao", NpgsqlDbType.Char));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Situacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_observacoes", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacoes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_observacoes_fisco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacoesFisco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_enviar_nfe_receita", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnviarNfeReceita ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_homologacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Homologacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Impressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_enviar_nfse_londrina", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnviarNfseLondrina ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_tributada_emissor", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TributadaEmissor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_bc_iss_retido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BcIssRetido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_valor_iss_retido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIssRetido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_rps_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RpsNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_rps_serie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RpsSerie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_rps_data", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RpsData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_consumidor_final", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConsumidorFinal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_presenca_comprador", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.PresencaComprador);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal_substituida", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipalSubstituida==null ? (object) DBNull.Value : this.NfPrincipalSubstituida.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_texto_qr_code", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TextoQrCode ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_impressao_danfe_liberada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpressaoDanfeLiberada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_impressao_danfe_contingencia", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpressaoDanfeContingencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_estoque_movimentado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EstoqueMovimentado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npr_c_class_trib", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CClassTrib ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npr_fin_deb", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FinDeb ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npr_fin_cred", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FinCred ?? DBNull.Value;

 
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
 if (CollectionNfAtributoClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfAtributoClassNfPrincipal+"\r\n";
                foreach (Entidades.NfAtributoClass tmp in CollectionNfAtributoClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfClienteClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfClienteClassNfPrincipal+"\r\n";
                foreach (Entidades.NfClienteClass tmp in CollectionNfClienteClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfClienteEnderecoClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfClienteEnderecoClassNfPrincipal+"\r\n";
                foreach (Entidades.NfClienteEnderecoClass tmp in CollectionNfClienteEnderecoClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfCobrancaClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfCobrancaClassNfPrincipal+"\r\n";
                foreach (Entidades.NfCobrancaClass tmp in CollectionNfCobrancaClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfDuplicataClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfDuplicataClassNfPrincipal+"\r\n";
                foreach (Entidades.NfDuplicataClass tmp in CollectionNfDuplicataClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfEmitenteClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfEmitenteClassNfPrincipal+"\r\n";
                foreach (Entidades.NfEmitenteClass tmp in CollectionNfEmitenteClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfEmitenteEnderecoClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfEmitenteEnderecoClassNfPrincipal+"\r\n";
                foreach (Entidades.NfEmitenteEnderecoClass tmp in CollectionNfEmitenteEnderecoClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfExtrasClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfExtrasClassNfPrincipal+"\r\n";
                foreach (Entidades.NfExtrasClass tmp in CollectionNfExtrasClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfFaturaClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfFaturaClassNfPrincipal+"\r\n";
                foreach (Entidades.NfFaturaClass tmp in CollectionNfFaturaClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfItemClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfItemClassNfPrincipal+"\r\n";
                foreach (Entidades.NfItemClass tmp in CollectionNfItemClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfNotasRelacionadasClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfNotasRelacionadasClassNfPrincipal+"\r\n";
                foreach (Entidades.NfNotasRelacionadasClass tmp in CollectionNfNotasRelacionadasClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfPagamentoClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfPagamentoClassNfPrincipal+"\r\n";
                foreach (Entidades.NfPagamentoClass tmp in CollectionNfPagamentoClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfPrincipalClassNfPrincipalSubstituida.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfPrincipalClassNfPrincipalSubstituida+"\r\n";
                foreach (Entidades.NfPrincipalClass tmp in CollectionNfPrincipalClassNfPrincipalSubstituida)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal+"\r\n";
                foreach (Entidades.NfPrincipalAutorizacaoXmlClass tmp in CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal+"\r\n";
                foreach (Entidades.NfPrincipalCancelamentoJustificativaClass tmp in CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfTotaisClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfTotaisClassNfPrincipal+"\r\n";
                foreach (Entidades.NfTotaisClass tmp in CollectionNfTotaisClassNfPrincipal)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNfTransporteClassNfPrincipal.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfTransporteClassNfPrincipal+"\r\n";
                foreach (Entidades.NfTransporteClass tmp in CollectionNfTransporteClassNfPrincipal)
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
        public static NfPrincipalClass CopiarEntidade(NfPrincipalClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfPrincipalClass toRet = new NfPrincipalClass(usuario,conn);
 toRet.Numero= entidadeCopiar.Numero;
 toRet.NaturezaOperacao= entidadeCopiar.NaturezaOperacao;
 toRet.Serie= entidadeCopiar.Serie;
 toRet.FormaPagamento= entidadeCopiar.FormaPagamento;
 toRet.ModeloDocFiscal= entidadeCopiar.ModeloDocFiscal;
 toRet.DataEmissao= entidadeCopiar.DataEmissao;
 toRet.DataSaidaEntrada= entidadeCopiar.DataSaidaEntrada;
 toRet.Tipo= entidadeCopiar.Tipo;
 toRet.CodMunicipioFatoGerador= entidadeCopiar.CodMunicipioFatoGerador;
 toRet.FormatoImpressao= entidadeCopiar.FormatoImpressao;
 toRet.FormaEmissao= entidadeCopiar.FormaEmissao;
 toRet.IdentificacaoAmbiente= entidadeCopiar.IdentificacaoAmbiente;
 toRet.FinalidadeEmissao= entidadeCopiar.FinalidadeEmissao;
 toRet.ProcessoEmissao= entidadeCopiar.ProcessoEmissao;
 toRet.VersaoProcessoEmissao= entidadeCopiar.VersaoProcessoEmissao;
 toRet.TipoEmitente= entidadeCopiar.TipoEmitente;
 toRet.Situacao= entidadeCopiar.Situacao;
 toRet.Observacoes= entidadeCopiar.Observacoes;
 toRet.ObservacoesFisco= entidadeCopiar.ObservacoesFisco;
 toRet.EnviarNfeReceita= entidadeCopiar.EnviarNfeReceita;
 toRet.Homologacao= entidadeCopiar.Homologacao;
 toRet.Impressa= entidadeCopiar.Impressa;
 toRet.EnviarNfseLondrina= entidadeCopiar.EnviarNfseLondrina;
 toRet.TributadaEmissor= entidadeCopiar.TributadaEmissor;
 toRet.BcIssRetido= entidadeCopiar.BcIssRetido;
 toRet.ValorIssRetido= entidadeCopiar.ValorIssRetido;
 toRet.RpsNumero= entidadeCopiar.RpsNumero;
 toRet.RpsSerie= entidadeCopiar.RpsSerie;
 toRet.RpsData= entidadeCopiar.RpsData;
 toRet.ConsumidorFinal= entidadeCopiar.ConsumidorFinal;
 toRet.PresencaComprador= entidadeCopiar.PresencaComprador;
 toRet.NfPrincipalSubstituida= entidadeCopiar.NfPrincipalSubstituida;
 toRet.TextoQrCode= entidadeCopiar.TextoQrCode;
 toRet.ImpressaoDanfeLiberada= entidadeCopiar.ImpressaoDanfeLiberada;
 toRet.ImpressaoDanfeContingencia= entidadeCopiar.ImpressaoDanfeContingencia;
 toRet.EstoqueMovimentado= entidadeCopiar.EstoqueMovimentado;
 toRet.CClassTrib= entidadeCopiar.CClassTrib;
 toRet.FinDeb= entidadeCopiar.FinDeb;
 toRet.FinCred= entidadeCopiar.FinCred;

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
       _naturezaOperacaoOriginal = NaturezaOperacao;
       _naturezaOperacaoOriginalCommited = _naturezaOperacaoOriginal;
       _serieOriginal = Serie;
       _serieOriginalCommited = _serieOriginal;
       _formaPagamentoOriginal = FormaPagamento;
       _formaPagamentoOriginalCommited = _formaPagamentoOriginal;
       _modeloDocFiscalOriginal = ModeloDocFiscal;
       _modeloDocFiscalOriginalCommited = _modeloDocFiscalOriginal;
       _dataEmissaoOriginal = DataEmissao;
       _dataEmissaoOriginalCommited = _dataEmissaoOriginal;
       _dataSaidaEntradaOriginal = DataSaidaEntrada;
       _dataSaidaEntradaOriginalCommited = _dataSaidaEntradaOriginal;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
       _codMunicipioFatoGeradorOriginal = CodMunicipioFatoGerador;
       _codMunicipioFatoGeradorOriginalCommited = _codMunicipioFatoGeradorOriginal;
       _formatoImpressaoOriginal = FormatoImpressao;
       _formatoImpressaoOriginalCommited = _formatoImpressaoOriginal;
       _formaEmissaoOriginal = FormaEmissao;
       _formaEmissaoOriginalCommited = _formaEmissaoOriginal;
       _identificacaoAmbienteOriginal = IdentificacaoAmbiente;
       _identificacaoAmbienteOriginalCommited = _identificacaoAmbienteOriginal;
       _finalidadeEmissaoOriginal = FinalidadeEmissao;
       _finalidadeEmissaoOriginalCommited = _finalidadeEmissaoOriginal;
       _processoEmissaoOriginal = ProcessoEmissao;
       _processoEmissaoOriginalCommited = _processoEmissaoOriginal;
       _versaoProcessoEmissaoOriginal = VersaoProcessoEmissao;
       _versaoProcessoEmissaoOriginalCommited = _versaoProcessoEmissaoOriginal;
       _tipoEmitenteOriginal = TipoEmitente;
       _tipoEmitenteOriginalCommited = _tipoEmitenteOriginal;
       _situacaoOriginal = Situacao;
       _situacaoOriginalCommited = _situacaoOriginal;
       _observacoesOriginal = Observacoes;
       _observacoesOriginalCommited = _observacoesOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _observacoesFiscoOriginal = ObservacoesFisco;
       _observacoesFiscoOriginalCommited = _observacoesFiscoOriginal;
       _enviarNfeReceitaOriginal = EnviarNfeReceita;
       _enviarNfeReceitaOriginalCommited = _enviarNfeReceitaOriginal;
       _homologacaoOriginal = Homologacao;
       _homologacaoOriginalCommited = _homologacaoOriginal;
       _impressaOriginal = Impressa;
       _impressaOriginalCommited = _impressaOriginal;
       _enviarNfseLondrinaOriginal = EnviarNfseLondrina;
       _enviarNfseLondrinaOriginalCommited = _enviarNfseLondrinaOriginal;
       _tributadaEmissorOriginal = TributadaEmissor;
       _tributadaEmissorOriginalCommited = _tributadaEmissorOriginal;
       _bcIssRetidoOriginal = BcIssRetido;
       _bcIssRetidoOriginalCommited = _bcIssRetidoOriginal;
       _valorIssRetidoOriginal = ValorIssRetido;
       _valorIssRetidoOriginalCommited = _valorIssRetidoOriginal;
       _rpsNumeroOriginal = RpsNumero;
       _rpsNumeroOriginalCommited = _rpsNumeroOriginal;
       _rpsSerieOriginal = RpsSerie;
       _rpsSerieOriginalCommited = _rpsSerieOriginal;
       _rpsDataOriginal = RpsData;
       _rpsDataOriginalCommited = _rpsDataOriginal;
       _consumidorFinalOriginal = ConsumidorFinal;
       _consumidorFinalOriginalCommited = _consumidorFinalOriginal;
       _presencaCompradorOriginal = PresencaComprador;
       _presencaCompradorOriginalCommited = _presencaCompradorOriginal;
       _nfPrincipalSubstituidaOriginal = NfPrincipalSubstituida;
       _nfPrincipalSubstituidaOriginalCommited = _nfPrincipalSubstituidaOriginal;
       _textoQrCodeOriginal = TextoQrCode;
       _textoQrCodeOriginalCommited = _textoQrCodeOriginal;
       _impressaoDanfeLiberadaOriginal = ImpressaoDanfeLiberada;
       _impressaoDanfeLiberadaOriginalCommited = _impressaoDanfeLiberadaOriginal;
       _impressaoDanfeContingenciaOriginal = ImpressaoDanfeContingencia;
       _impressaoDanfeContingenciaOriginalCommited = _impressaoDanfeContingenciaOriginal;
       _estoqueMovimentadoOriginal = EstoqueMovimentado;
       _estoqueMovimentadoOriginalCommited = _estoqueMovimentadoOriginal;
       _cClassTribOriginal = CClassTrib;
       _cClassTribOriginalCommited = _cClassTribOriginal;
       _finDebOriginal = FinDeb;
       _finDebOriginalCommited = _finDebOriginal;
       _finCredOriginal = FinCred;
       _finCredOriginalCommited = _finCredOriginal;

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
       _naturezaOperacaoOriginalCommited = NaturezaOperacao;
       _serieOriginalCommited = Serie;
       _formaPagamentoOriginalCommited = FormaPagamento;
       _modeloDocFiscalOriginalCommited = ModeloDocFiscal;
       _dataEmissaoOriginalCommited = DataEmissao;
       _dataSaidaEntradaOriginalCommited = DataSaidaEntrada;
       _tipoOriginalCommited = Tipo;
       _codMunicipioFatoGeradorOriginalCommited = CodMunicipioFatoGerador;
       _formatoImpressaoOriginalCommited = FormatoImpressao;
       _formaEmissaoOriginalCommited = FormaEmissao;
       _identificacaoAmbienteOriginalCommited = IdentificacaoAmbiente;
       _finalidadeEmissaoOriginalCommited = FinalidadeEmissao;
       _processoEmissaoOriginalCommited = ProcessoEmissao;
       _versaoProcessoEmissaoOriginalCommited = VersaoProcessoEmissao;
       _tipoEmitenteOriginalCommited = TipoEmitente;
       _situacaoOriginalCommited = Situacao;
       _observacoesOriginalCommited = Observacoes;
       _versionOriginalCommited = Version;
       _observacoesFiscoOriginalCommited = ObservacoesFisco;
       _enviarNfeReceitaOriginalCommited = EnviarNfeReceita;
       _homologacaoOriginalCommited = Homologacao;
       _impressaOriginalCommited = Impressa;
       _enviarNfseLondrinaOriginalCommited = EnviarNfseLondrina;
       _tributadaEmissorOriginalCommited = TributadaEmissor;
       _bcIssRetidoOriginalCommited = BcIssRetido;
       _valorIssRetidoOriginalCommited = ValorIssRetido;
       _rpsNumeroOriginalCommited = RpsNumero;
       _rpsSerieOriginalCommited = RpsSerie;
       _rpsDataOriginalCommited = RpsData;
       _consumidorFinalOriginalCommited = ConsumidorFinal;
       _presencaCompradorOriginalCommited = PresencaComprador;
       _nfPrincipalSubstituidaOriginalCommited = NfPrincipalSubstituida;
       _textoQrCodeOriginalCommited = TextoQrCode;
       _impressaoDanfeLiberadaOriginalCommited = ImpressaoDanfeLiberada;
       _impressaoDanfeContingenciaOriginalCommited = ImpressaoDanfeContingencia;
       _estoqueMovimentadoOriginalCommited = EstoqueMovimentado;
       _cClassTribOriginalCommited = CClassTrib;
       _finDebOriginalCommited = FinDeb;
       _finCredOriginalCommited = FinCred;

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
               if (_valueCollectionNfAtributoClassNfPrincipalLoaded) 
               {
                  if (_collectionNfAtributoClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfAtributoClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfAtributoClassNfPrincipalRemovidos = new List<Entidades.NfAtributoClass>();
                  }
                  _collectionNfAtributoClassNfPrincipalOriginal= (from a in _valueCollectionNfAtributoClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfAtributoClassNfPrincipalChanged = false;
                  _valueCollectionNfAtributoClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfClienteClassNfPrincipalLoaded) 
               {
                  if (_collectionNfClienteClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfClienteClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfClienteClassNfPrincipalRemovidos = new List<Entidades.NfClienteClass>();
                  }
                  _collectionNfClienteClassNfPrincipalOriginal= (from a in _valueCollectionNfClienteClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfClienteClassNfPrincipalChanged = false;
                  _valueCollectionNfClienteClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfClienteEnderecoClassNfPrincipalLoaded) 
               {
                  if (_collectionNfClienteEnderecoClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfClienteEnderecoClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfClienteEnderecoClassNfPrincipalRemovidos = new List<Entidades.NfClienteEnderecoClass>();
                  }
                  _collectionNfClienteEnderecoClassNfPrincipalOriginal= (from a in _valueCollectionNfClienteEnderecoClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfClienteEnderecoClassNfPrincipalChanged = false;
                  _valueCollectionNfClienteEnderecoClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfCobrancaClassNfPrincipalLoaded) 
               {
                  if (_collectionNfCobrancaClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfCobrancaClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfCobrancaClassNfPrincipalRemovidos = new List<Entidades.NfCobrancaClass>();
                  }
                  _collectionNfCobrancaClassNfPrincipalOriginal= (from a in _valueCollectionNfCobrancaClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfCobrancaClassNfPrincipalChanged = false;
                  _valueCollectionNfCobrancaClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfDuplicataClassNfPrincipalLoaded) 
               {
                  if (_collectionNfDuplicataClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfDuplicataClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfDuplicataClassNfPrincipalRemovidos = new List<Entidades.NfDuplicataClass>();
                  }
                  _collectionNfDuplicataClassNfPrincipalOriginal= (from a in _valueCollectionNfDuplicataClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfDuplicataClassNfPrincipalChanged = false;
                  _valueCollectionNfDuplicataClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfEmitenteClassNfPrincipalLoaded) 
               {
                  if (_collectionNfEmitenteClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfEmitenteClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfEmitenteClassNfPrincipalRemovidos = new List<Entidades.NfEmitenteClass>();
                  }
                  _collectionNfEmitenteClassNfPrincipalOriginal= (from a in _valueCollectionNfEmitenteClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfEmitenteClassNfPrincipalChanged = false;
                  _valueCollectionNfEmitenteClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded) 
               {
                  if (_collectionNfEmitenteEnderecoClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfEmitenteEnderecoClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfEmitenteEnderecoClassNfPrincipalRemovidos = new List<Entidades.NfEmitenteEnderecoClass>();
                  }
                  _collectionNfEmitenteEnderecoClassNfPrincipalOriginal= (from a in _valueCollectionNfEmitenteEnderecoClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfEmitenteEnderecoClassNfPrincipalChanged = false;
                  _valueCollectionNfEmitenteEnderecoClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfExtrasClassNfPrincipalLoaded) 
               {
                  if (_collectionNfExtrasClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfExtrasClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfExtrasClassNfPrincipalRemovidos = new List<Entidades.NfExtrasClass>();
                  }
                  _collectionNfExtrasClassNfPrincipalOriginal= (from a in _valueCollectionNfExtrasClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfExtrasClassNfPrincipalChanged = false;
                  _valueCollectionNfExtrasClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfFaturaClassNfPrincipalLoaded) 
               {
                  if (_collectionNfFaturaClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfFaturaClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfFaturaClassNfPrincipalRemovidos = new List<Entidades.NfFaturaClass>();
                  }
                  _collectionNfFaturaClassNfPrincipalOriginal= (from a in _valueCollectionNfFaturaClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfFaturaClassNfPrincipalChanged = false;
                  _valueCollectionNfFaturaClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfItemClassNfPrincipalLoaded) 
               {
                  if (_collectionNfItemClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfItemClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfItemClassNfPrincipalRemovidos = new List<Entidades.NfItemClass>();
                  }
                  _collectionNfItemClassNfPrincipalOriginal= (from a in _valueCollectionNfItemClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfItemClassNfPrincipalChanged = false;
                  _valueCollectionNfItemClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded) 
               {
                  if (_collectionNfNotasRelacionadasClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfNotasRelacionadasClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfNotasRelacionadasClassNfPrincipalRemovidos = new List<Entidades.NfNotasRelacionadasClass>();
                  }
                  _collectionNfNotasRelacionadasClassNfPrincipalOriginal= (from a in _valueCollectionNfNotasRelacionadasClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfNotasRelacionadasClassNfPrincipalChanged = false;
                  _valueCollectionNfNotasRelacionadasClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfPagamentoClassNfPrincipalLoaded) 
               {
                  if (_collectionNfPagamentoClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfPagamentoClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfPagamentoClassNfPrincipalRemovidos = new List<Entidades.NfPagamentoClass>();
                  }
                  _collectionNfPagamentoClassNfPrincipalOriginal= (from a in _valueCollectionNfPagamentoClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfPagamentoClassNfPrincipalChanged = false;
                  _valueCollectionNfPagamentoClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded) 
               {
                  if (_collectionNfPrincipalClassNfPrincipalSubstituidaRemovidos != null) 
                  {
                     _collectionNfPrincipalClassNfPrincipalSubstituidaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfPrincipalClassNfPrincipalSubstituidaRemovidos = new List<Entidades.NfPrincipalClass>();
                  }
                  _collectionNfPrincipalClassNfPrincipalSubstituidaOriginal= (from a in _valueCollectionNfPrincipalClassNfPrincipalSubstituida select a.ID).ToList();
                  _valueCollectionNfPrincipalClassNfPrincipalSubstituidaChanged = false;
                  _valueCollectionNfPrincipalClassNfPrincipalSubstituidaCommitedChanged = false;
               }
               if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded) 
               {
                  if (_collectionNfPrincipalAutorizacaoXmlClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalRemovidos = new List<Entidades.NfPrincipalAutorizacaoXmlClass>();
                  }
                  _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalOriginal= (from a in _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalChanged = false;
                  _valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded) 
               {
                  if (_collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalRemovidos = new List<Entidades.NfPrincipalCancelamentoJustificativaClass>();
                  }
                  _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalOriginal= (from a in _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalChanged = false;
                  _valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfTotaisClassNfPrincipalLoaded) 
               {
                  if (_collectionNfTotaisClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfTotaisClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfTotaisClassNfPrincipalRemovidos = new List<Entidades.NfTotaisClass>();
                  }
                  _collectionNfTotaisClassNfPrincipalOriginal= (from a in _valueCollectionNfTotaisClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfTotaisClassNfPrincipalChanged = false;
                  _valueCollectionNfTotaisClassNfPrincipalCommitedChanged = false;
               }
               if (_valueCollectionNfTransporteClassNfPrincipalLoaded) 
               {
                  if (_collectionNfTransporteClassNfPrincipalRemovidos != null) 
                  {
                     _collectionNfTransporteClassNfPrincipalRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfTransporteClassNfPrincipalRemovidos = new List<Entidades.NfTransporteClass>();
                  }
                  _collectionNfTransporteClassNfPrincipalOriginal= (from a in _valueCollectionNfTransporteClassNfPrincipal select a.ID).ToList();
                  _valueCollectionNfTransporteClassNfPrincipalChanged = false;
                  _valueCollectionNfTransporteClassNfPrincipalCommitedChanged = false;
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
               NaturezaOperacao=_naturezaOperacaoOriginal;
               _naturezaOperacaoOriginalCommited=_naturezaOperacaoOriginal;
               Serie=_serieOriginal;
               _serieOriginalCommited=_serieOriginal;
               FormaPagamento=_formaPagamentoOriginal;
               _formaPagamentoOriginalCommited=_formaPagamentoOriginal;
               ModeloDocFiscal=_modeloDocFiscalOriginal;
               _modeloDocFiscalOriginalCommited=_modeloDocFiscalOriginal;
               DataEmissao=_dataEmissaoOriginal;
               _dataEmissaoOriginalCommited=_dataEmissaoOriginal;
               DataSaidaEntrada=_dataSaidaEntradaOriginal;
               _dataSaidaEntradaOriginalCommited=_dataSaidaEntradaOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               CodMunicipioFatoGerador=_codMunicipioFatoGeradorOriginal;
               _codMunicipioFatoGeradorOriginalCommited=_codMunicipioFatoGeradorOriginal;
               FormatoImpressao=_formatoImpressaoOriginal;
               _formatoImpressaoOriginalCommited=_formatoImpressaoOriginal;
               FormaEmissao=_formaEmissaoOriginal;
               _formaEmissaoOriginalCommited=_formaEmissaoOriginal;
               IdentificacaoAmbiente=_identificacaoAmbienteOriginal;
               _identificacaoAmbienteOriginalCommited=_identificacaoAmbienteOriginal;
               FinalidadeEmissao=_finalidadeEmissaoOriginal;
               _finalidadeEmissaoOriginalCommited=_finalidadeEmissaoOriginal;
               ProcessoEmissao=_processoEmissaoOriginal;
               _processoEmissaoOriginalCommited=_processoEmissaoOriginal;
               VersaoProcessoEmissao=_versaoProcessoEmissaoOriginal;
               _versaoProcessoEmissaoOriginalCommited=_versaoProcessoEmissaoOriginal;
               TipoEmitente=_tipoEmitenteOriginal;
               _tipoEmitenteOriginalCommited=_tipoEmitenteOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               Observacoes=_observacoesOriginal;
               _observacoesOriginalCommited=_observacoesOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ObservacoesFisco=_observacoesFiscoOriginal;
               _observacoesFiscoOriginalCommited=_observacoesFiscoOriginal;
               EnviarNfeReceita=_enviarNfeReceitaOriginal;
               _enviarNfeReceitaOriginalCommited=_enviarNfeReceitaOriginal;
               Homologacao=_homologacaoOriginal;
               _homologacaoOriginalCommited=_homologacaoOriginal;
               Impressa=_impressaOriginal;
               _impressaOriginalCommited=_impressaOriginal;
               EnviarNfseLondrina=_enviarNfseLondrinaOriginal;
               _enviarNfseLondrinaOriginalCommited=_enviarNfseLondrinaOriginal;
               TributadaEmissor=_tributadaEmissorOriginal;
               _tributadaEmissorOriginalCommited=_tributadaEmissorOriginal;
               BcIssRetido=_bcIssRetidoOriginal;
               _bcIssRetidoOriginalCommited=_bcIssRetidoOriginal;
               ValorIssRetido=_valorIssRetidoOriginal;
               _valorIssRetidoOriginalCommited=_valorIssRetidoOriginal;
               RpsNumero=_rpsNumeroOriginal;
               _rpsNumeroOriginalCommited=_rpsNumeroOriginal;
               RpsSerie=_rpsSerieOriginal;
               _rpsSerieOriginalCommited=_rpsSerieOriginal;
               RpsData=_rpsDataOriginal;
               _rpsDataOriginalCommited=_rpsDataOriginal;
               ConsumidorFinal=_consumidorFinalOriginal;
               _consumidorFinalOriginalCommited=_consumidorFinalOriginal;
               PresencaComprador=_presencaCompradorOriginal;
               _presencaCompradorOriginalCommited=_presencaCompradorOriginal;
               NfPrincipalSubstituida=_nfPrincipalSubstituidaOriginal;
               _nfPrincipalSubstituidaOriginalCommited=_nfPrincipalSubstituidaOriginal;
               TextoQrCode=_textoQrCodeOriginal;
               _textoQrCodeOriginalCommited=_textoQrCodeOriginal;
               ImpressaoDanfeLiberada=_impressaoDanfeLiberadaOriginal;
               _impressaoDanfeLiberadaOriginalCommited=_impressaoDanfeLiberadaOriginal;
               ImpressaoDanfeContingencia=_impressaoDanfeContingenciaOriginal;
               _impressaoDanfeContingenciaOriginalCommited=_impressaoDanfeContingenciaOriginal;
               EstoqueMovimentado=_estoqueMovimentadoOriginal;
               _estoqueMovimentadoOriginalCommited=_estoqueMovimentadoOriginal;
               CClassTrib=_cClassTribOriginal;
               _cClassTribOriginalCommited=_cClassTribOriginal;
               FinDeb=_finDebOriginal;
               _finDebOriginalCommited=_finDebOriginal;
               FinCred=_finCredOriginal;
               _finCredOriginalCommited=_finCredOriginal;
               if (_valueCollectionNfAtributoClassNfPrincipalLoaded) 
               {
                  CollectionNfAtributoClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfAtributoClassNfPrincipalOriginal)
                  {
                    CollectionNfAtributoClassNfPrincipal.Add(Entidades.NfAtributoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfAtributoClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfClienteClassNfPrincipalLoaded) 
               {
                  CollectionNfClienteClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfClienteClassNfPrincipalOriginal)
                  {
                    CollectionNfClienteClassNfPrincipal.Add(Entidades.NfClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfClienteClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfClienteEnderecoClassNfPrincipalLoaded) 
               {
                  CollectionNfClienteEnderecoClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfClienteEnderecoClassNfPrincipalOriginal)
                  {
                    CollectionNfClienteEnderecoClassNfPrincipal.Add(Entidades.NfClienteEnderecoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfClienteEnderecoClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfCobrancaClassNfPrincipalLoaded) 
               {
                  CollectionNfCobrancaClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfCobrancaClassNfPrincipalOriginal)
                  {
                    CollectionNfCobrancaClassNfPrincipal.Add(Entidades.NfCobrancaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfCobrancaClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfDuplicataClassNfPrincipalLoaded) 
               {
                  CollectionNfDuplicataClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfDuplicataClassNfPrincipalOriginal)
                  {
                    CollectionNfDuplicataClassNfPrincipal.Add(Entidades.NfDuplicataClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfDuplicataClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfEmitenteClassNfPrincipalLoaded) 
               {
                  CollectionNfEmitenteClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfEmitenteClassNfPrincipalOriginal)
                  {
                    CollectionNfEmitenteClassNfPrincipal.Add(Entidades.NfEmitenteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfEmitenteClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded) 
               {
                  CollectionNfEmitenteEnderecoClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfEmitenteEnderecoClassNfPrincipalOriginal)
                  {
                    CollectionNfEmitenteEnderecoClassNfPrincipal.Add(Entidades.NfEmitenteEnderecoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfEmitenteEnderecoClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfExtrasClassNfPrincipalLoaded) 
               {
                  CollectionNfExtrasClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfExtrasClassNfPrincipalOriginal)
                  {
                    CollectionNfExtrasClassNfPrincipal.Add(Entidades.NfExtrasClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfExtrasClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfFaturaClassNfPrincipalLoaded) 
               {
                  CollectionNfFaturaClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfFaturaClassNfPrincipalOriginal)
                  {
                    CollectionNfFaturaClassNfPrincipal.Add(Entidades.NfFaturaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfFaturaClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfItemClassNfPrincipalLoaded) 
               {
                  CollectionNfItemClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfItemClassNfPrincipalOriginal)
                  {
                    CollectionNfItemClassNfPrincipal.Add(Entidades.NfItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfItemClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded) 
               {
                  CollectionNfNotasRelacionadasClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfNotasRelacionadasClassNfPrincipalOriginal)
                  {
                    CollectionNfNotasRelacionadasClassNfPrincipal.Add(Entidades.NfNotasRelacionadasClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfNotasRelacionadasClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfPagamentoClassNfPrincipalLoaded) 
               {
                  CollectionNfPagamentoClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfPagamentoClassNfPrincipalOriginal)
                  {
                    CollectionNfPagamentoClassNfPrincipal.Add(Entidades.NfPagamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfPagamentoClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded) 
               {
                  CollectionNfPrincipalClassNfPrincipalSubstituida.Clear();
                  foreach(int item in _collectionNfPrincipalClassNfPrincipalSubstituidaOriginal)
                  {
                    CollectionNfPrincipalClassNfPrincipalSubstituida.Add(Entidades.NfPrincipalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfPrincipalClassNfPrincipalSubstituidaRemovidos.Clear();
               }
               if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded) 
               {
                  CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalOriginal)
                  {
                    CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Add(Entidades.NfPrincipalAutorizacaoXmlClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfPrincipalAutorizacaoXmlClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded) 
               {
                  CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalOriginal)
                  {
                    CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal.Add(Entidades.NfPrincipalCancelamentoJustificativaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfPrincipalCancelamentoJustificativaClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfTotaisClassNfPrincipalLoaded) 
               {
                  CollectionNfTotaisClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfTotaisClassNfPrincipalOriginal)
                  {
                    CollectionNfTotaisClassNfPrincipal.Add(Entidades.NfTotaisClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfTotaisClassNfPrincipalRemovidos.Clear();
               }
               if (_valueCollectionNfTransporteClassNfPrincipalLoaded) 
               {
                  CollectionNfTransporteClassNfPrincipal.Clear();
                  foreach(int item in _collectionNfTransporteClassNfPrincipalOriginal)
                  {
                    CollectionNfTransporteClassNfPrincipal.Add(Entidades.NfTransporteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfTransporteClassNfPrincipalRemovidos.Clear();
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
               if (_valueCollectionNfAtributoClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfAtributoClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfClienteClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfClienteClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfClienteEnderecoClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfClienteEnderecoClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfCobrancaClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfCobrancaClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfDuplicataClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfDuplicataClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfEmitenteClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfEmitenteClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfExtrasClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfExtrasClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfFaturaClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfFaturaClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfItemClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfNotasRelacionadasClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfPagamentoClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfPagamentoClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded) 
               {
                  if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTotaisClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfTotaisClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTransporteClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfTransporteClassNfPrincipalChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfAtributoClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfAtributoClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfClienteClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfClienteClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfClienteEnderecoClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfClienteEnderecoClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfCobrancaClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfCobrancaClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfDuplicataClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfDuplicataClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfEmitenteClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfEmitenteClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfEmitenteEnderecoClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfExtrasClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfExtrasClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfFaturaClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfFaturaClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfItemClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfNotasRelacionadasClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfPagamentoClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfPagamentoClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded) 
               {
                   tempRet = CollectionNfPrincipalClassNfPrincipalSubstituida.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTotaisClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfTotaisClassNfPrincipal.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTransporteClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfTransporteClassNfPrincipal.Any(item => item.IsDirty());
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
       dirty = _naturezaOperacaoOriginal != NaturezaOperacao;
      if (dirty) return true;
       dirty = _serieOriginal != Serie;
      if (dirty) return true;
       dirty = _formaPagamentoOriginal != FormaPagamento;
      if (dirty) return true;
       dirty = _modeloDocFiscalOriginal != ModeloDocFiscal;
      if (dirty) return true;
       dirty = _dataEmissaoOriginal != DataEmissao;
      if (dirty) return true;
       dirty = _dataSaidaEntradaOriginal != DataSaidaEntrada;
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;
      if (dirty) return true;
       dirty = _codMunicipioFatoGeradorOriginal != CodMunicipioFatoGerador;
      if (dirty) return true;
       dirty = _formatoImpressaoOriginal != FormatoImpressao;
      if (dirty) return true;
       dirty = _formaEmissaoOriginal != FormaEmissao;
      if (dirty) return true;
       dirty = _identificacaoAmbienteOriginal != IdentificacaoAmbiente;
      if (dirty) return true;
       dirty = _finalidadeEmissaoOriginal != FinalidadeEmissao;
      if (dirty) return true;
       dirty = _processoEmissaoOriginal != ProcessoEmissao;
      if (dirty) return true;
       dirty = _versaoProcessoEmissaoOriginal != VersaoProcessoEmissao;
      if (dirty) return true;
       dirty = _tipoEmitenteOriginal != TipoEmitente;
      if (dirty) return true;
       dirty = _situacaoOriginal != Situacao;
      if (dirty) return true;
       dirty = _observacoesOriginal != Observacoes;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _observacoesFiscoOriginal != ObservacoesFisco;
      if (dirty) return true;
       dirty = _enviarNfeReceitaOriginal != EnviarNfeReceita;
      if (dirty) return true;
       dirty = _homologacaoOriginal != Homologacao;
      if (dirty) return true;
       dirty = _impressaOriginal != Impressa;
      if (dirty) return true;
       dirty = _enviarNfseLondrinaOriginal != EnviarNfseLondrina;
      if (dirty) return true;
       dirty = _tributadaEmissorOriginal != TributadaEmissor;
      if (dirty) return true;
       dirty = _bcIssRetidoOriginal != BcIssRetido;
      if (dirty) return true;
       dirty = _valorIssRetidoOriginal != ValorIssRetido;
      if (dirty) return true;
       dirty = _rpsNumeroOriginal != RpsNumero;
      if (dirty) return true;
       dirty = _rpsSerieOriginal != RpsSerie;
      if (dirty) return true;
       dirty = _rpsDataOriginal != RpsData;
      if (dirty) return true;
       dirty = _consumidorFinalOriginal != ConsumidorFinal;
      if (dirty) return true;
       dirty = _presencaCompradorOriginal != PresencaComprador;
      if (dirty) return true;
       if (_nfPrincipalSubstituidaOriginal!=null)
       {
          dirty = !_nfPrincipalSubstituidaOriginal.Equals(NfPrincipalSubstituida);
       }
       else
       {
            dirty = NfPrincipalSubstituida != null;
       }
      if (dirty) return true;
       dirty = _textoQrCodeOriginal != TextoQrCode;
      if (dirty) return true;
       dirty = _impressaoDanfeLiberadaOriginal != ImpressaoDanfeLiberada;
      if (dirty) return true;
       dirty = _impressaoDanfeContingenciaOriginal != ImpressaoDanfeContingencia;
      if (dirty) return true;
       dirty = _estoqueMovimentadoOriginal != EstoqueMovimentado;
      if (dirty) return true;
       dirty = _cClassTribOriginal != CClassTrib;
      if (dirty) return true;
       dirty = _finDebOriginal != FinDeb;
      if (dirty) return true;
       dirty = _finCredOriginal != FinCred;

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
               if (_valueCollectionNfAtributoClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfAtributoClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfClienteClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfClienteClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfClienteEnderecoClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfClienteEnderecoClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfCobrancaClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfCobrancaClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfDuplicataClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfDuplicataClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfEmitenteClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfEmitenteClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfExtrasClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfExtrasClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfFaturaClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfFaturaClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfItemClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfItemClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfNotasRelacionadasClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfPagamentoClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfPagamentoClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded) 
               {
                  if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTotaisClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfTotaisClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfTransporteClassNfPrincipalLoaded) 
               {
                  if (_valueCollectionNfTransporteClassNfPrincipalCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfAtributoClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfAtributoClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfClienteClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfClienteClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfClienteEnderecoClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfClienteEnderecoClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfCobrancaClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfCobrancaClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfDuplicataClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfDuplicataClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfEmitenteClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfEmitenteClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfEmitenteEnderecoClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfExtrasClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfExtrasClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfFaturaClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfFaturaClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfItemClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfItemClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfNotasRelacionadasClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfPagamentoClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfPagamentoClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded) 
               {
                   tempRet = CollectionNfPrincipalClassNfPrincipalSubstituida.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTotaisClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfTotaisClassNfPrincipal.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNfTransporteClassNfPrincipalLoaded) 
               {
                   tempRet = CollectionNfTransporteClassNfPrincipal.Any(item => item.IsDirtyCommited());
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
       dirty = _naturezaOperacaoOriginalCommited != NaturezaOperacao;
      if (dirty) return true;
       dirty = _serieOriginalCommited != Serie;
      if (dirty) return true;
       dirty = _formaPagamentoOriginalCommited != FormaPagamento;
      if (dirty) return true;
       dirty = _modeloDocFiscalOriginalCommited != ModeloDocFiscal;
      if (dirty) return true;
       dirty = _dataEmissaoOriginalCommited != DataEmissao;
      if (dirty) return true;
       dirty = _dataSaidaEntradaOriginalCommited != DataSaidaEntrada;
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;
      if (dirty) return true;
       dirty = _codMunicipioFatoGeradorOriginalCommited != CodMunicipioFatoGerador;
      if (dirty) return true;
       dirty = _formatoImpressaoOriginalCommited != FormatoImpressao;
      if (dirty) return true;
       dirty = _formaEmissaoOriginalCommited != FormaEmissao;
      if (dirty) return true;
       dirty = _identificacaoAmbienteOriginalCommited != IdentificacaoAmbiente;
      if (dirty) return true;
       dirty = _finalidadeEmissaoOriginalCommited != FinalidadeEmissao;
      if (dirty) return true;
       dirty = _processoEmissaoOriginalCommited != ProcessoEmissao;
      if (dirty) return true;
       dirty = _versaoProcessoEmissaoOriginalCommited != VersaoProcessoEmissao;
      if (dirty) return true;
       dirty = _tipoEmitenteOriginalCommited != TipoEmitente;
      if (dirty) return true;
       dirty = _situacaoOriginalCommited != Situacao;
      if (dirty) return true;
       dirty = _observacoesOriginalCommited != Observacoes;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _observacoesFiscoOriginalCommited != ObservacoesFisco;
      if (dirty) return true;
       dirty = _enviarNfeReceitaOriginalCommited != EnviarNfeReceita;
      if (dirty) return true;
       dirty = _homologacaoOriginalCommited != Homologacao;
      if (dirty) return true;
       dirty = _impressaOriginalCommited != Impressa;
      if (dirty) return true;
       dirty = _enviarNfseLondrinaOriginalCommited != EnviarNfseLondrina;
      if (dirty) return true;
       dirty = _tributadaEmissorOriginalCommited != TributadaEmissor;
      if (dirty) return true;
       dirty = _bcIssRetidoOriginalCommited != BcIssRetido;
      if (dirty) return true;
       dirty = _valorIssRetidoOriginalCommited != ValorIssRetido;
      if (dirty) return true;
       dirty = _rpsNumeroOriginalCommited != RpsNumero;
      if (dirty) return true;
       dirty = _rpsSerieOriginalCommited != RpsSerie;
      if (dirty) return true;
       dirty = _rpsDataOriginalCommited != RpsData;
      if (dirty) return true;
       dirty = _consumidorFinalOriginalCommited != ConsumidorFinal;
      if (dirty) return true;
       dirty = _presencaCompradorOriginalCommited != PresencaComprador;
      if (dirty) return true;
       if (_nfPrincipalSubstituidaOriginalCommited!=null)
       {
          dirty = !_nfPrincipalSubstituidaOriginalCommited.Equals(NfPrincipalSubstituida);
       }
       else
       {
            dirty = NfPrincipalSubstituida != null;
       }
      if (dirty) return true;
       dirty = _textoQrCodeOriginalCommited != TextoQrCode;
      if (dirty) return true;
       dirty = _impressaoDanfeLiberadaOriginalCommited != ImpressaoDanfeLiberada;
      if (dirty) return true;
       dirty = _impressaoDanfeContingenciaOriginalCommited != ImpressaoDanfeContingencia;
      if (dirty) return true;
       dirty = _estoqueMovimentadoOriginalCommited != EstoqueMovimentado;
      if (dirty) return true;
       dirty = _cClassTribOriginalCommited != CClassTrib;
      if (dirty) return true;
       dirty = _finDebOriginalCommited != FinDeb;
      if (dirty) return true;
       dirty = _finCredOriginalCommited != FinCred;

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
               if (_valueCollectionNfAtributoClassNfPrincipalLoaded) 
               {
                  foreach(NfAtributoClass item in CollectionNfAtributoClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfClienteClassNfPrincipalLoaded) 
               {
                  foreach(NfClienteClass item in CollectionNfClienteClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfClienteEnderecoClassNfPrincipalLoaded) 
               {
                  foreach(NfClienteEnderecoClass item in CollectionNfClienteEnderecoClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfCobrancaClassNfPrincipalLoaded) 
               {
                  foreach(NfCobrancaClass item in CollectionNfCobrancaClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfDuplicataClassNfPrincipalLoaded) 
               {
                  foreach(NfDuplicataClass item in CollectionNfDuplicataClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfEmitenteClassNfPrincipalLoaded) 
               {
                  foreach(NfEmitenteClass item in CollectionNfEmitenteClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded) 
               {
                  foreach(NfEmitenteEnderecoClass item in CollectionNfEmitenteEnderecoClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfExtrasClassNfPrincipalLoaded) 
               {
                  foreach(NfExtrasClass item in CollectionNfExtrasClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfFaturaClassNfPrincipalLoaded) 
               {
                  foreach(NfFaturaClass item in CollectionNfFaturaClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfItemClassNfPrincipalLoaded) 
               {
                  foreach(NfItemClass item in CollectionNfItemClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded) 
               {
                  foreach(NfNotasRelacionadasClass item in CollectionNfNotasRelacionadasClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfPagamentoClassNfPrincipalLoaded) 
               {
                  foreach(NfPagamentoClass item in CollectionNfPagamentoClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded) 
               {
                  foreach(NfPrincipalClass item in CollectionNfPrincipalClassNfPrincipalSubstituida)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded) 
               {
                  foreach(NfPrincipalAutorizacaoXmlClass item in CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded) 
               {
                  foreach(NfPrincipalCancelamentoJustificativaClass item in CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfTotaisClassNfPrincipalLoaded) 
               {
                  foreach(NfTotaisClass item in CollectionNfTotaisClassNfPrincipal)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNfTransporteClassNfPrincipalLoaded) 
               {
                  foreach(NfTransporteClass item in CollectionNfTransporteClassNfPrincipal)
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
             case "NaturezaOperacao":
                return this.NaturezaOperacao;
             case "Serie":
                return this.Serie;
             case "FormaPagamento":
                return this.FormaPagamento;
             case "ModeloDocFiscal":
                return this.ModeloDocFiscal;
             case "DataEmissao":
                return this.DataEmissao;
             case "DataSaidaEntrada":
                return this.DataSaidaEntrada;
             case "Tipo":
                return this.Tipo;
             case "CodMunicipioFatoGerador":
                return this.CodMunicipioFatoGerador;
             case "FormatoImpressao":
                return this.FormatoImpressao;
             case "FormaEmissao":
                return this.FormaEmissao;
             case "IdentificacaoAmbiente":
                return this.IdentificacaoAmbiente;
             case "FinalidadeEmissao":
                return this.FinalidadeEmissao;
             case "ProcessoEmissao":
                return this.ProcessoEmissao;
             case "VersaoProcessoEmissao":
                return this.VersaoProcessoEmissao;
             case "TipoEmitente":
                return this.TipoEmitente;
             case "Situacao":
                return this.Situacao;
             case "Observacoes":
                return this.Observacoes;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ObservacoesFisco":
                return this.ObservacoesFisco;
             case "EnviarNfeReceita":
                return this.EnviarNfeReceita;
             case "Homologacao":
                return this.Homologacao;
             case "Impressa":
                return this.Impressa;
             case "EnviarNfseLondrina":
                return this.EnviarNfseLondrina;
             case "TributadaEmissor":
                return this.TributadaEmissor;
             case "BcIssRetido":
                return this.BcIssRetido;
             case "ValorIssRetido":
                return this.ValorIssRetido;
             case "RpsNumero":
                return this.RpsNumero;
             case "RpsSerie":
                return this.RpsSerie;
             case "RpsData":
                return this.RpsData;
             case "ConsumidorFinal":
                return this.ConsumidorFinal;
             case "PresencaComprador":
                return this.PresencaComprador;
             case "NfPrincipalSubstituida":
                return this.NfPrincipalSubstituida;
             case "TextoQrCode":
                return this.TextoQrCode;
             case "ImpressaoDanfeLiberada":
                return this.ImpressaoDanfeLiberada;
             case "ImpressaoDanfeContingencia":
                return this.ImpressaoDanfeContingencia;
             case "EstoqueMovimentado":
                return this.EstoqueMovimentado;
             case "CClassTrib":
                return this.CClassTrib;
             case "FinDeb":
                return this.FinDeb;
             case "FinCred":
                return this.FinCred;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfPrincipalSubstituida!=null)
                NfPrincipalSubstituida.ChangeSingleConnection(newConnection);
               if (_valueCollectionNfAtributoClassNfPrincipalLoaded) 
               {
                  foreach(NfAtributoClass item in CollectionNfAtributoClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfClienteClassNfPrincipalLoaded) 
               {
                  foreach(NfClienteClass item in CollectionNfClienteClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfClienteEnderecoClassNfPrincipalLoaded) 
               {
                  foreach(NfClienteEnderecoClass item in CollectionNfClienteEnderecoClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfCobrancaClassNfPrincipalLoaded) 
               {
                  foreach(NfCobrancaClass item in CollectionNfCobrancaClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfDuplicataClassNfPrincipalLoaded) 
               {
                  foreach(NfDuplicataClass item in CollectionNfDuplicataClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfEmitenteClassNfPrincipalLoaded) 
               {
                  foreach(NfEmitenteClass item in CollectionNfEmitenteClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfPrincipalLoaded) 
               {
                  foreach(NfEmitenteEnderecoClass item in CollectionNfEmitenteEnderecoClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfExtrasClassNfPrincipalLoaded) 
               {
                  foreach(NfExtrasClass item in CollectionNfExtrasClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfFaturaClassNfPrincipalLoaded) 
               {
                  foreach(NfFaturaClass item in CollectionNfFaturaClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfItemClassNfPrincipalLoaded) 
               {
                  foreach(NfItemClass item in CollectionNfItemClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfNotasRelacionadasClassNfPrincipalLoaded) 
               {
                  foreach(NfNotasRelacionadasClass item in CollectionNfNotasRelacionadasClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfPagamentoClassNfPrincipalLoaded) 
               {
                  foreach(NfPagamentoClass item in CollectionNfPagamentoClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfPrincipalClassNfPrincipalSubstituidaLoaded) 
               {
                  foreach(NfPrincipalClass item in CollectionNfPrincipalClassNfPrincipalSubstituida)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfPrincipalAutorizacaoXmlClassNfPrincipalLoaded) 
               {
                  foreach(NfPrincipalAutorizacaoXmlClass item in CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipalLoaded) 
               {
                  foreach(NfPrincipalCancelamentoJustificativaClass item in CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfTotaisClassNfPrincipalLoaded) 
               {
                  foreach(NfTotaisClass item in CollectionNfTotaisClassNfPrincipal)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNfTransporteClassNfPrincipalLoaded) 
               {
                  foreach(NfTransporteClass item in CollectionNfTransporteClassNfPrincipal)
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
                  command.CommandText += " COUNT(nf_principal.id_nf_principal) " ;
               }
               else
               {
               command.CommandText += "nf_principal.id_nf_principal, " ;
               command.CommandText += "nf_principal.nfp_numero, " ;
               command.CommandText += "nf_principal.nfp_natureza_operacao, " ;
               command.CommandText += "nf_principal.nfp_serie, " ;
               command.CommandText += "nf_principal.nfp_forma_pagamento, " ;
               command.CommandText += "nf_principal.nfp_modelo_doc_fiscal, " ;
               command.CommandText += "nf_principal.nfp_data_emissao, " ;
               command.CommandText += "nf_principal.nfp_data_saida_entrada, " ;
               command.CommandText += "nf_principal.nfp_tipo, " ;
               command.CommandText += "nf_principal.nfp_cod_municipio_fato_gerador, " ;
               command.CommandText += "nf_principal.nfp_formato_impressao, " ;
               command.CommandText += "nf_principal.nfp_forma_emissao, " ;
               command.CommandText += "nf_principal.nfp_identificacao_ambiente, " ;
               command.CommandText += "nf_principal.nfp_finalidade_emissao, " ;
               command.CommandText += "nf_principal.nfp_processo_emissao, " ;
               command.CommandText += "nf_principal.nfp_versao_processo_emissao, " ;
               command.CommandText += "nf_principal.nfp_tipo_emitente, " ;
               command.CommandText += "nf_principal.nfp_situacao, " ;
               command.CommandText += "nf_principal.nfp_observacoes, " ;
               command.CommandText += "nf_principal.entity_uid, " ;
               command.CommandText += "nf_principal.version, " ;
               command.CommandText += "nf_principal.nfp_observacoes_fisco, " ;
               command.CommandText += "nf_principal.nfp_enviar_nfe_receita, " ;
               command.CommandText += "nf_principal.nfp_homologacao, " ;
               command.CommandText += "nf_principal.impressa, " ;
               command.CommandText += "nf_principal.nfp_enviar_nfse_londrina, " ;
               command.CommandText += "nf_principal.nfp_tributada_emissor, " ;
               command.CommandText += "nf_principal.nfp_bc_iss_retido, " ;
               command.CommandText += "nf_principal.nfp_valor_iss_retido, " ;
               command.CommandText += "nf_principal.nfp_rps_numero, " ;
               command.CommandText += "nf_principal.nfp_rps_serie, " ;
               command.CommandText += "nf_principal.nfp_rps_data, " ;
               command.CommandText += "nf_principal.nfp_consumidor_final, " ;
               command.CommandText += "nf_principal.nfp_presenca_comprador, " ;
               command.CommandText += "nf_principal.id_nf_principal_substituida, " ;
               command.CommandText += "nf_principal.nfp_texto_qr_code, " ;
               command.CommandText += "nf_principal.nfp_impressao_danfe_liberada, " ;
               command.CommandText += "nf_principal.nfp_impressao_danfe_contingencia, " ;
               command.CommandText += "nf_principal.nfp_estoque_movimentado, " ;
               command.CommandText += "nf_principal.npr_c_class_trib, " ;
               command.CommandText += "nf_principal.npr_fin_deb, " ;
               command.CommandText += "nf_principal.npr_fin_cred " ;
               }
               command.CommandText += " FROM  nf_principal ";
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
                        orderByClause += " , nfp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nfp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_principal.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_principal":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.id_nf_principal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.id_nf_principal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_natureza_operacao":
                     case "NaturezaOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.nfp_natureza_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.nfp_natureza_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_serie":
                     case "Serie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_forma_pagamento":
                     case "FormaPagamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_forma_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_forma_pagamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_modelo_doc_fiscal":
                     case "ModeloDocFiscal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.nfp_modelo_doc_fiscal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.nfp_modelo_doc_fiscal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_data_emissao":
                     case "DataEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_data_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_data_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_data_saida_entrada":
                     case "DataSaidaEntrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_data_saida_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_data_saida_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_cod_municipio_fato_gerador":
                     case "CodMunicipioFatoGerador":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_cod_municipio_fato_gerador " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_cod_municipio_fato_gerador) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_formato_impressao":
                     case "FormatoImpressao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_formato_impressao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_formato_impressao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_forma_emissao":
                     case "FormaEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_forma_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_forma_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_identificacao_ambiente":
                     case "IdentificacaoAmbiente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_identificacao_ambiente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_identificacao_ambiente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_finalidade_emissao":
                     case "FinalidadeEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_finalidade_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_finalidade_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_processo_emissao":
                     case "ProcessoEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_processo_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_processo_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_versao_processo_emissao":
                     case "VersaoProcessoEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.nfp_versao_processo_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.nfp_versao_processo_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_tipo_emitente":
                     case "TipoEmitente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.nfp_tipo_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.nfp_tipo_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.nfp_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.nfp_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_observacoes":
                     case "Observacoes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.nfp_observacoes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.nfp_observacoes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_principal.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_observacoes_fisco":
                     case "ObservacoesFisco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.nfp_observacoes_fisco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.nfp_observacoes_fisco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_enviar_nfe_receita":
                     case "EnviarNfeReceita":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_enviar_nfe_receita " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_enviar_nfe_receita) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_homologacao":
                     case "Homologacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_homologacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_homologacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "impressa":
                     case "Impressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_enviar_nfse_londrina":
                     case "EnviarNfseLondrina":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_enviar_nfse_londrina " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_enviar_nfse_londrina) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_tributada_emissor":
                     case "TributadaEmissor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_tributada_emissor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_tributada_emissor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_bc_iss_retido":
                     case "BcIssRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_bc_iss_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_bc_iss_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_valor_iss_retido":
                     case "ValorIssRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_valor_iss_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_valor_iss_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_rps_numero":
                     case "RpsNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_rps_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_rps_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_rps_serie":
                     case "RpsSerie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.nfp_rps_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.nfp_rps_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_rps_data":
                     case "RpsData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_rps_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_rps_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_consumidor_final":
                     case "ConsumidorFinal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_consumidor_final " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_consumidor_final) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_presenca_comprador":
                     case "PresencaComprador":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_presenca_comprador " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_presenca_comprador) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal_substituida":
                     case "NfPrincipalSubstituida":
                     command.CommandText += " LEFT JOIN nf_principal as nf_principal_NfPrincipalSubstituida ON nf_principal_NfPrincipalSubstituida.id_nf_principal = nf_principal.id_nf_principal_substituida ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal_NfPrincipalSubstituida.nfp_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal_NfPrincipalSubstituida.nfp_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_texto_qr_code":
                     case "TextoQrCode":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.nfp_texto_qr_code " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.nfp_texto_qr_code) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_impressao_danfe_liberada":
                     case "ImpressaoDanfeLiberada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_impressao_danfe_liberada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_impressao_danfe_liberada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_impressao_danfe_contingencia":
                     case "ImpressaoDanfeContingencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_impressao_danfe_contingencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_impressao_danfe_contingencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_estoque_movimentado":
                     case "EstoqueMovimentado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.nfp_estoque_movimentado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.nfp_estoque_movimentado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npr_c_class_trib":
                     case "CClassTrib":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_principal.npr_c_class_trib " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_principal.npr_c_class_trib) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npr_fin_deb":
                     case "FinDeb":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.npr_fin_deb " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.npr_fin_deb) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npr_fin_cred":
                     case "FinCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal.npr_fin_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal.npr_fin_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_natureza_operacao")) 
                        {
                           whereClause += " OR UPPER(nf_principal.nfp_natureza_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.nfp_natureza_operacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_modelo_doc_fiscal")) 
                        {
                           whereClause += " OR UPPER(nf_principal.nfp_modelo_doc_fiscal) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.nfp_modelo_doc_fiscal) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_versao_processo_emissao")) 
                        {
                           whereClause += " OR UPPER(nf_principal.nfp_versao_processo_emissao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.nfp_versao_processo_emissao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_tipo_emitente")) 
                        {
                           whereClause += " OR UPPER(nf_principal.nfp_tipo_emitente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.nfp_tipo_emitente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_situacao")) 
                        {
                           whereClause += " OR UPPER(nf_principal.nfp_situacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.nfp_situacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_observacoes")) 
                        {
                           whereClause += " OR UPPER(nf_principal.nfp_observacoes) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.nfp_observacoes) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_principal.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_observacoes_fisco")) 
                        {
                           whereClause += " OR UPPER(nf_principal.nfp_observacoes_fisco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.nfp_observacoes_fisco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_rps_serie")) 
                        {
                           whereClause += " OR UPPER(nf_principal.nfp_rps_serie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.nfp_rps_serie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_texto_qr_code")) 
                        {
                           whereClause += " OR UPPER(nf_principal.nfp_texto_qr_code) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.nfp_texto_qr_code) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npr_c_class_trib")) 
                        {
                           whereClause += " OR UPPER(nf_principal.npr_c_class_trib) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_principal.npr_c_class_trib) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_principal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.id_nf_principal = :nf_principal_ID_8782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ID_8782", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "nfp_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_numero = :nf_principal_Numero_2575 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Numero_2575", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NaturezaOperacao" || parametro.FieldName == "nfp_natureza_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_natureza_operacao LIKE :nf_principal_NaturezaOperacao_5846 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_NaturezaOperacao_5846", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Serie" || parametro.FieldName == "nfp_serie")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_serie = :nf_principal_Serie_4619 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Serie_4619", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FormaPagamento" || parametro.FieldName == "nfp_forma_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is FormaPagamento)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo FormaPagamento");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_forma_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_forma_pagamento = :nf_principal_FormaPagamento_4129 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_FormaPagamento_4129", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloDocFiscal" || parametro.FieldName == "nfp_modelo_doc_fiscal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_modelo_doc_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_modelo_doc_fiscal LIKE :nf_principal_ModeloDocFiscal_7530 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ModeloDocFiscal_7530", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEmissao" || parametro.FieldName == "nfp_data_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_data_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_data_emissao = :nf_principal_DataEmissao_4142 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_DataEmissao_4142", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataSaidaEntrada" || parametro.FieldName == "nfp_data_saida_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_data_saida_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_data_saida_entrada = :nf_principal_DataSaidaEntrada_8016 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_DataSaidaEntrada_8016", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "nfp_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoNota)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoNota");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_tipo = :nf_principal_Tipo_2712 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Tipo_2712", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodMunicipioFatoGerador" || parametro.FieldName == "nfp_cod_municipio_fato_gerador")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_cod_municipio_fato_gerador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_cod_municipio_fato_gerador = :nf_principal_CodMunicipioFatoGerador_8598 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_CodMunicipioFatoGerador_8598", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FormatoImpressao" || parametro.FieldName == "nfp_formato_impressao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is FormatoImpressao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo FormatoImpressao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_formato_impressao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_formato_impressao = :nf_principal_FormatoImpressao_6716 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_FormatoImpressao_6716", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FormaEmissao" || parametro.FieldName == "nfp_forma_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is FormaEmissaoNFe)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo FormaEmissaoNFe");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_forma_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_forma_emissao = :nf_principal_FormaEmissao_9886 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_FormaEmissao_9886", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoAmbiente" || parametro.FieldName == "nfp_identificacao_ambiente")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_identificacao_ambiente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_identificacao_ambiente = :nf_principal_IdentificacaoAmbiente_9234 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_IdentificacaoAmbiente_9234", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FinalidadeEmissao" || parametro.FieldName == "nfp_finalidade_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is Finalidade)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo Finalidade");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_finalidade_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_finalidade_emissao = :nf_principal_FinalidadeEmissao_8380 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_FinalidadeEmissao_8380", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProcessoEmissao" || parametro.FieldName == "nfp_processo_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is Processo)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo Processo");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_processo_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_processo_emissao = :nf_principal_ProcessoEmissao_702 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ProcessoEmissao_702", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoProcessoEmissao" || parametro.FieldName == "nfp_versao_processo_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_versao_processo_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_versao_processo_emissao LIKE :nf_principal_VersaoProcessoEmissao_844 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_VersaoProcessoEmissao_844", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoEmitente" || parametro.FieldName == "nfp_tipo_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_tipo_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_tipo_emitente LIKE :nf_principal_TipoEmitente_4820 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_TipoEmitente_4820", NpgsqlDbType.Char,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "nfp_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_situacao LIKE :nf_principal_Situacao_6663 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Situacao_6663", NpgsqlDbType.Char,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacoes" || parametro.FieldName == "nfp_observacoes")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_observacoes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_observacoes LIKE :nf_principal_Observacoes_386 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Observacoes_386", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_principal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.entity_uid LIKE :nf_principal_EntityUid_7152 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_EntityUid_7152", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_principal.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.version = :nf_principal_Version_8424 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Version_8424", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacoesFisco" || parametro.FieldName == "nfp_observacoes_fisco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_observacoes_fisco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_observacoes_fisco LIKE :nf_principal_ObservacoesFisco_9944 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ObservacoesFisco_9944", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnviarNfeReceita" || parametro.FieldName == "nfp_enviar_nfe_receita")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_enviar_nfe_receita IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_enviar_nfe_receita = :nf_principal_EnviarNfeReceita_6412 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_EnviarNfeReceita_6412", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Homologacao" || parametro.FieldName == "nfp_homologacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_homologacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_homologacao = :nf_principal_Homologacao_9835 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Homologacao_9835", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Impressa" || parametro.FieldName == "impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.impressa = :nf_principal_Impressa_3640 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Impressa_3640", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnviarNfseLondrina" || parametro.FieldName == "nfp_enviar_nfse_londrina")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_enviar_nfse_londrina IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_enviar_nfse_londrina = :nf_principal_EnviarNfseLondrina_7962 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_EnviarNfseLondrina_7962", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TributadaEmissor" || parametro.FieldName == "nfp_tributada_emissor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_tributada_emissor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_tributada_emissor = :nf_principal_TributadaEmissor_1733 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_TributadaEmissor_1733", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BcIssRetido" || parametro.FieldName == "nfp_bc_iss_retido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_bc_iss_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_bc_iss_retido = :nf_principal_BcIssRetido_9436 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_BcIssRetido_9436", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIssRetido" || parametro.FieldName == "nfp_valor_iss_retido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_valor_iss_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_valor_iss_retido = :nf_principal_ValorIssRetido_4688 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ValorIssRetido_4688", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RpsNumero" || parametro.FieldName == "nfp_rps_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_rps_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_rps_numero = :nf_principal_RpsNumero_3158 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_RpsNumero_3158", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RpsSerie" || parametro.FieldName == "nfp_rps_serie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_rps_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_rps_serie LIKE :nf_principal_RpsSerie_4798 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_RpsSerie_4798", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RpsData" || parametro.FieldName == "nfp_rps_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_rps_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_rps_data = :nf_principal_RpsData_9962 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_RpsData_9962", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConsumidorFinal" || parametro.FieldName == "nfp_consumidor_final")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_consumidor_final IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_consumidor_final = :nf_principal_ConsumidorFinal_9185 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ConsumidorFinal_9185", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PresencaComprador" || parametro.FieldName == "nfp_presenca_comprador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is PresencaComprador)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo PresencaComprador");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_presenca_comprador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_presenca_comprador = :nf_principal_PresencaComprador_3279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_PresencaComprador_3279", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfPrincipalSubstituida" || parametro.FieldName == "id_nf_principal_substituida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfPrincipalClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfPrincipalClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.id_nf_principal_substituida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.id_nf_principal_substituida = :nf_principal_NfPrincipalSubstituida_1182 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_NfPrincipalSubstituida_1182", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TextoQrCode" || parametro.FieldName == "nfp_texto_qr_code")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_texto_qr_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_texto_qr_code LIKE :nf_principal_TextoQrCode_147 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_TextoQrCode_147", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpressaoDanfeLiberada" || parametro.FieldName == "nfp_impressao_danfe_liberada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_impressao_danfe_liberada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_impressao_danfe_liberada = :nf_principal_ImpressaoDanfeLiberada_41 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ImpressaoDanfeLiberada_41", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpressaoDanfeContingencia" || parametro.FieldName == "nfp_impressao_danfe_contingencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_impressao_danfe_contingencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_impressao_danfe_contingencia = :nf_principal_ImpressaoDanfeContingencia_2757 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ImpressaoDanfeContingencia_2757", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstoqueMovimentado" || parametro.FieldName == "nfp_estoque_movimentado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_estoque_movimentado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_estoque_movimentado = :nf_principal_EstoqueMovimentado_6844 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_EstoqueMovimentado_6844", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CClassTrib" || parametro.FieldName == "npr_c_class_trib")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.npr_c_class_trib IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.npr_c_class_trib LIKE :nf_principal_CClassTrib_242 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_CClassTrib_242", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FinDeb" || parametro.FieldName == "npr_fin_deb")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.npr_fin_deb IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.npr_fin_deb = :nf_principal_FinDeb_4326 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_FinDeb_4326", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FinCred" || parametro.FieldName == "npr_fin_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.npr_fin_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.npr_fin_cred = :nf_principal_FinCred_557 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_FinCred_557", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NaturezaOperacaoExato" || parametro.FieldName == "NaturezaOperacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_natureza_operacao LIKE :nf_principal_NaturezaOperacao_7401 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_NaturezaOperacao_7401", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloDocFiscalExato" || parametro.FieldName == "ModeloDocFiscalExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_modelo_doc_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_modelo_doc_fiscal LIKE :nf_principal_ModeloDocFiscal_5968 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ModeloDocFiscal_5968", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoProcessoEmissaoExato" || parametro.FieldName == "VersaoProcessoEmissaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_versao_processo_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_versao_processo_emissao LIKE :nf_principal_VersaoProcessoEmissao_5863 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_VersaoProcessoEmissao_5863", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoEmitenteExato" || parametro.FieldName == "TipoEmitenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_tipo_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_tipo_emitente LIKE :nf_principal_TipoEmitente_3639 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_TipoEmitente_3639", NpgsqlDbType.Char,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoExato" || parametro.FieldName == "SituacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_situacao LIKE :nf_principal_Situacao_8766 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Situacao_8766", NpgsqlDbType.Char,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_principal.nfp_observacoes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_observacoes LIKE :nf_principal_Observacoes_1836 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_Observacoes_1836", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_principal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.entity_uid LIKE :nf_principal_EntityUid_5858 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_EntityUid_5858", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacoesFiscoExato" || parametro.FieldName == "ObservacoesFiscoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_observacoes_fisco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_observacoes_fisco LIKE :nf_principal_ObservacoesFisco_8044 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_ObservacoesFisco_8044", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RpsSerieExato" || parametro.FieldName == "RpsSerieExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_rps_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_rps_serie LIKE :nf_principal_RpsSerie_8982 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_RpsSerie_8982", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TextoQrCodeExato" || parametro.FieldName == "TextoQrCodeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.nfp_texto_qr_code IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.nfp_texto_qr_code LIKE :nf_principal_TextoQrCode_8518 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_TextoQrCode_8518", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CClassTribExato" || parametro.FieldName == "CClassTribExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_principal.npr_c_class_trib IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_principal.npr_c_class_trib LIKE :nf_principal_CClassTrib_4335 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_principal_CClassTrib_4335", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfPrincipalClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfPrincipalClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfPrincipalClass), Convert.ToInt32(read["id_nf_principal"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfPrincipalClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_principal"]);
                     entidade.Numero = (int)read["nfp_numero"];
                     entidade.NaturezaOperacao = (read["nfp_natureza_operacao"] != DBNull.Value ? read["nfp_natureza_operacao"].ToString() : null);
                     entidade.Serie = (int)read["nfp_serie"];
                     entidade.FormaPagamento = (FormaPagamento) (read["nfp_forma_pagamento"] != DBNull.Value ? Enum.ToObject(typeof(FormaPagamento), read["nfp_forma_pagamento"]) : null);
                     entidade.ModeloDocFiscal = (read["nfp_modelo_doc_fiscal"] != DBNull.Value ? read["nfp_modelo_doc_fiscal"].ToString() : null);
                     entidade.DataEmissao = (DateTime)read["nfp_data_emissao"];
                     entidade.DataSaidaEntrada = read["nfp_data_saida_entrada"] as DateTime?;
                     entidade.Tipo = (TipoNota) (read["nfp_tipo"] != DBNull.Value ? Enum.ToObject(typeof(TipoNota), read["nfp_tipo"]) : null);
                     entidade.CodMunicipioFatoGerador = (int)read["nfp_cod_municipio_fato_gerador"];
                     entidade.FormatoImpressao = (FormatoImpressao) (read["nfp_formato_impressao"] != DBNull.Value ? Enum.ToObject(typeof(FormatoImpressao), read["nfp_formato_impressao"]) : null);
                     entidade.FormaEmissao = (FormaEmissaoNFe) (read["nfp_forma_emissao"] != DBNull.Value ? Enum.ToObject(typeof(FormaEmissaoNFe), read["nfp_forma_emissao"]) : null);
                     entidade.IdentificacaoAmbiente = (int)read["nfp_identificacao_ambiente"];
                     entidade.FinalidadeEmissao = (Finalidade) (read["nfp_finalidade_emissao"] != DBNull.Value ? Enum.ToObject(typeof(Finalidade), read["nfp_finalidade_emissao"]) : null);
                     entidade.ProcessoEmissao = (Processo) (read["nfp_processo_emissao"] != DBNull.Value ? Enum.ToObject(typeof(Processo), read["nfp_processo_emissao"]) : null);
                     entidade.VersaoProcessoEmissao = (read["nfp_versao_processo_emissao"] != DBNull.Value ? read["nfp_versao_processo_emissao"].ToString() : null);
                     entidade.TipoEmitente = (read["nfp_tipo_emitente"] != DBNull.Value ? read["nfp_tipo_emitente"].ToString() : null);
                     entidade.Situacao = (read["nfp_situacao"] != DBNull.Value ? read["nfp_situacao"].ToString() : null);
                     entidade.Observacoes = (read["nfp_observacoes"] != DBNull.Value ? read["nfp_observacoes"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ObservacoesFisco = (read["nfp_observacoes_fisco"] != DBNull.Value ? read["nfp_observacoes_fisco"].ToString() : null);
                     entidade.EnviarNfeReceita = Convert.ToBoolean(Convert.ToInt16(read["nfp_enviar_nfe_receita"]));
                     entidade.Homologacao = Convert.ToBoolean(Convert.ToInt16(read["nfp_homologacao"]));
                     entidade.Impressa = (short)read["impressa"];
                     entidade.EnviarNfseLondrina = Convert.ToBoolean(Convert.ToInt16(read["nfp_enviar_nfse_londrina"]));
                     entidade.TributadaEmissor = Convert.ToBoolean(Convert.ToInt16(read["nfp_tributada_emissor"]));
                     entidade.BcIssRetido = (double)read["nfp_bc_iss_retido"];
                     entidade.ValorIssRetido = (double)read["nfp_valor_iss_retido"];
                     entidade.RpsNumero = read["nfp_rps_numero"] as int?;
                     entidade.RpsSerie = (read["nfp_rps_serie"] != DBNull.Value ? read["nfp_rps_serie"].ToString() : null);
                     entidade.RpsData = read["nfp_rps_data"] as DateTime?;
                     entidade.ConsumidorFinal = Convert.ToBoolean(Convert.ToInt16(read["nfp_consumidor_final"]));
                     entidade.PresencaComprador = (PresencaComprador) (read["nfp_presenca_comprador"] != DBNull.Value ? Enum.ToObject(typeof(PresencaComprador), read["nfp_presenca_comprador"]) : null);
                     if (read["id_nf_principal_substituida"] != DBNull.Value)
                     {
                        entidade.NfPrincipalSubstituida = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal_substituida"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipalSubstituida = null ;
                     }
                     entidade.TextoQrCode = (read["nfp_texto_qr_code"] != DBNull.Value ? read["nfp_texto_qr_code"].ToString() : null);
                     entidade.ImpressaoDanfeLiberada = Convert.ToBoolean(Convert.ToInt16(read["nfp_impressao_danfe_liberada"]));
                     entidade.ImpressaoDanfeContingencia = Convert.ToBoolean(Convert.ToInt16(read["nfp_impressao_danfe_contingencia"]));
                     entidade.EstoqueMovimentado = read["nfp_estoque_movimentado"] as short?;
                     entidade.CClassTrib = (read["npr_c_class_trib"] != DBNull.Value ? read["npr_c_class_trib"].ToString() : null);
                     entidade.FinDeb = read["npr_fin_deb"] as short?;
                     entidade.FinCred = read["npr_fin_cred"] as short?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfPrincipalClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
