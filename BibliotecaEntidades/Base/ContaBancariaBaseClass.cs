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
     [Table("conta_bancaria","cba")]
     public class ContaBancariaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ContaBancariaClass";
protected const string ErroDelete = "Erro ao excluir o ContaBancariaClass  ";
protected const string ErroSave = "Erro ao salvar o ContaBancariaClass.";
protected const string ErroCollectionClienteClassContaBancaria = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionCobRemessaClassContaBancaria = "Erro ao carregar a coleção de CobRemessaClass.";
protected const string ErroCollectionConciliacaoBancariaClassContaBancaria = "Erro ao carregar a coleção de ConciliacaoBancariaClass.";
protected const string ErroCollectionContaPagarClassContaBancaria = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionContaReceberClassContaBancaria = "Erro ao carregar a coleção de ContaReceberClass.";
protected const string ErroCollectionContaReceberBoletoClassContaBancaria = "Erro ao carregar a coleção de ContaReceberBoletoClass.";
protected const string ErroCollectionContaRecorrenteClassContaBancaria = "Erro ao carregar a coleção de ContaRecorrenteClass.";
protected const string ErroCollectionFormaPagamentoClassContaBancaria = "Erro ao carregar a coleção de FormaPagamentoClass.";
protected const string ErroCollectionFornecedorClassContaBancaria = "Erro ao carregar a coleção de FornecedorClass.";
protected const string ErroCollectionOrcamentoItemClassContaBancaria = "Erro ao carregar a coleção de OrcamentoItemClass.";
protected const string ErroCollectionPedidoItemClassContaBancaria = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionRepresentanteClassContaBancaria = "Erro ao carregar a coleção de RepresentanteClass.";
protected const string ErroCollectionTransferenciaBancariaClassContaBancariaOrigem = "Erro ao carregar a coleção de TransferenciaBancariaClass.";
protected const string ErroCollectionTransferenciaBancariaClassContaBancariaDestino = "Erro ao carregar a coleção de TransferenciaBancariaClass.";
protected const string ErroCollectionVendedorClassContaBancaria = "Erro ao carregar a coleção de VendedorClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do ContaBancariaClass.";
protected const string MensagemUtilizadoCollectionClienteClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionCobRemessaClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes CobRemessaClass:";
protected const string MensagemUtilizadoCollectionConciliacaoBancariaClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes ConciliacaoBancariaClass:";
protected const string MensagemUtilizadoCollectionContaPagarClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionContaReceberClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes ContaReceberClass:";
protected const string MensagemUtilizadoCollectionContaReceberBoletoClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes ContaReceberBoletoClass:";
protected const string MensagemUtilizadoCollectionContaRecorrenteClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
protected const string MensagemUtilizadoCollectionFormaPagamentoClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes FormaPagamentoClass:";
protected const string MensagemUtilizadoCollectionFornecedorClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes FornecedorClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes OrcamentoItemClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionRepresentanteClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes RepresentanteClass:";
protected const string MensagemUtilizadoCollectionTransferenciaBancariaClassContaBancariaOrigem =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes TransferenciaBancariaClass:";
protected const string MensagemUtilizadoCollectionTransferenciaBancariaClassContaBancariaDestino =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes TransferenciaBancariaClass:";
protected const string MensagemUtilizadoCollectionVendedorClassContaBancaria =  "A entidade ContaBancariaClass está sendo utilizada nos seguintes VendedorClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ContaBancariaClass está sendo utilizada.";
#endregion
       protected string _nomeBancoOriginal{get;private set;}
       private string _nomeBancoOriginalCommited{get; set;}
        private string _valueNomeBanco;
         [Column("cba_nome_banco")]
        public virtual string NomeBanco
         { 
            get { return this._valueNomeBanco; } 
            set 
            { 
                if (this._valueNomeBanco == value)return;
                 this._valueNomeBanco = value; 
            } 
        } 

       protected string _codigoBancoOriginal{get;private set;}
       private string _codigoBancoOriginalCommited{get; set;}
        private string _valueCodigoBanco;
         [Column("cba_codigo_banco")]
        public virtual string CodigoBanco
         { 
            get { return this._valueCodigoBanco; } 
            set 
            { 
                if (this._valueCodigoBanco == value)return;
                 this._valueCodigoBanco = value; 
            } 
        } 

       protected string _numeroContaOriginal{get;private set;}
       private string _numeroContaOriginalCommited{get; set;}
        private string _valueNumeroConta;
         [Column("cba_numero_conta")]
        public virtual string NumeroConta
         { 
            get { return this._valueNumeroConta; } 
            set 
            { 
                if (this._valueNumeroConta == value)return;
                 this._valueNumeroConta = value; 
            } 
        } 

       protected string _agenciaOriginal{get;private set;}
       private string _agenciaOriginalCommited{get; set;}
        private string _valueAgencia;
         [Column("cba_agencia")]
        public virtual string Agencia
         { 
            get { return this._valueAgencia; } 
            set 
            { 
                if (this._valueAgencia == value)return;
                 this._valueAgencia = value; 
            } 
        } 

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("cba_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected string _agenciaDvOriginal{get;private set;}
       private string _agenciaDvOriginalCommited{get; set;}
        private string _valueAgenciaDv;
         [Column("cba_agencia_dv")]
        public virtual string AgenciaDv
         { 
            get { return this._valueAgenciaDv; } 
            set 
            { 
                if (this._valueAgenciaDv == value)return;
                 this._valueAgenciaDv = value; 
            } 
        } 

       protected string _contaDvOriginal{get;private set;}
       private string _contaDvOriginalCommited{get; set;}
        private string _valueContaDv;
         [Column("cba_conta_dv")]
        public virtual string ContaDv
         { 
            get { return this._valueContaDv; } 
            set 
            { 
                if (this._valueContaDv == value)return;
                 this._valueContaDv = value; 
            } 
        } 

       protected string _numeroCarteiraBoletoOriginal{get;private set;}
       private string _numeroCarteiraBoletoOriginalCommited{get; set;}
        private string _valueNumeroCarteiraBoleto;
         [Column("cba_numero_carteira_boleto")]
        public virtual string NumeroCarteiraBoleto
         { 
            get { return this._valueNumeroCarteiraBoleto; } 
            set 
            { 
                if (this._valueNumeroCarteiraBoleto == value)return;
                 this._valueNumeroCarteiraBoleto = value; 
            } 
        } 

       protected string _codigoCarteiraBoletoOriginal{get;private set;}
       private string _codigoCarteiraBoletoOriginalCommited{get; set;}
        private string _valueCodigoCarteiraBoleto;
         [Column("cba_codigo_carteira_boleto")]
        public virtual string CodigoCarteiraBoleto
         { 
            get { return this._valueCodigoCarteiraBoleto; } 
            set 
            { 
                if (this._valueCodigoCarteiraBoleto == value)return;
                 this._valueCodigoCarteiraBoleto = value; 
            } 
        } 

       protected long? _idCobrancaContaBancariaOriginal{get;private set;}
       private long? _idCobrancaContaBancariaOriginalCommited{get; set;}
        private long? _valueIdCobrancaContaBancaria;
         [Column("cob_id_cobranca_conta_bancaria")]
        public virtual long? IdCobrancaContaBancaria
         { 
            get { return this._valueIdCobrancaContaBancaria; } 
            set 
            { 
                if (this._valueIdCobrancaContaBancaria == value)return;
                 this._valueIdCobrancaContaBancaria = value; 
            } 
        } 

       protected bool _geracaoAutomaticaBoletoOriginal{get;private set;}
       private bool _geracaoAutomaticaBoletoOriginalCommited{get; set;}
        private bool _valueGeracaoAutomaticaBoleto;
         [Column("cob_geracao_automatica_boleto")]
        public virtual bool GeracaoAutomaticaBoleto
         { 
            get { return this._valueGeracaoAutomaticaBoleto; } 
            set 
            { 
                if (this._valueGeracaoAutomaticaBoleto == value)return;
                 this._valueGeracaoAutomaticaBoleto = value; 
            } 
        } 

       protected int _geracaoAutomaticaBoletoIntervaloOriginal{get;private set;}
       private int _geracaoAutomaticaBoletoIntervaloOriginalCommited{get; set;}
        private int _valueGeracaoAutomaticaBoletoIntervalo;
         [Column("cob_geracao_automatica_boleto_intervalo")]
        public virtual int GeracaoAutomaticaBoletoIntervalo
         { 
            get { return this._valueGeracaoAutomaticaBoletoIntervalo; } 
            set 
            { 
                if (this._valueGeracaoAutomaticaBoletoIntervalo == value)return;
                 this._valueGeracaoAutomaticaBoletoIntervalo = value; 
            } 
        } 

       protected bool _geracaoAutomaticaRemessaOriginal{get;private set;}
       private bool _geracaoAutomaticaRemessaOriginalCommited{get; set;}
        private bool _valueGeracaoAutomaticaRemessa;
         [Column("cob_geracao_automatica_remessa")]
        public virtual bool GeracaoAutomaticaRemessa
         { 
            get { return this._valueGeracaoAutomaticaRemessa; } 
            set 
            { 
                if (this._valueGeracaoAutomaticaRemessa == value)return;
                 this._valueGeracaoAutomaticaRemessa = value; 
            } 
        } 

       protected string _geracaoAutomaticaBoletoDiretorioOriginal{get;private set;}
       private string _geracaoAutomaticaBoletoDiretorioOriginalCommited{get; set;}
        private string _valueGeracaoAutomaticaBoletoDiretorio;
         [Column("cob_geracao_automatica_boleto_diretorio")]
        public virtual string GeracaoAutomaticaBoletoDiretorio
         { 
            get { return this._valueGeracaoAutomaticaBoletoDiretorio; } 
            set 
            { 
                if (this._valueGeracaoAutomaticaBoletoDiretorio == value)return;
                 this._valueGeracaoAutomaticaBoletoDiretorio = value; 
            } 
        } 

       protected string _geracaoAutomaticaRemessaDiretorioOriginal{get;private set;}
       private string _geracaoAutomaticaRemessaDiretorioOriginalCommited{get; set;}
        private string _valueGeracaoAutomaticaRemessaDiretorio;
         [Column("cob_geracao_automatica_remessa_diretorio")]
        public virtual string GeracaoAutomaticaRemessaDiretorio
         { 
            get { return this._valueGeracaoAutomaticaRemessaDiretorio; } 
            set 
            { 
                if (this._valueGeracaoAutomaticaRemessaDiretorio == value)return;
                 this._valueGeracaoAutomaticaRemessaDiretorio = value; 
            } 
        } 

       protected string _cpfCnpjOriginal{get;private set;}
       private string _cpfCnpjOriginalCommited{get; set;}
        private string _valueCpfCnpj;
         [Column("cob_cpf_cnpj")]
        public virtual string CpfCnpj
         { 
            get { return this._valueCpfCnpj; } 
            set 
            { 
                if (this._valueCpfCnpj == value)return;
                 this._valueCpfCnpj = value; 
            } 
        } 

       protected string _chavePixOriginal{get;private set;}
       private string _chavePixOriginalCommited{get; set;}
        private string _valueChavePix;
         [Column("cob_chave_pix")]
        public virtual string ChavePix
         { 
            get { return this._valueChavePix; } 
            set 
            { 
                if (this._valueChavePix == value)return;
                 this._valueChavePix = value; 
            } 
        } 

       protected double _jurosAntecipacaoOriginal{get;private set;}
       private double _jurosAntecipacaoOriginalCommited{get; set;}
        private double _valueJurosAntecipacao;
         [Column("cob_juros_antecipacao")]
        public virtual double JurosAntecipacao
         { 
            get { return this._valueJurosAntecipacao; } 
            set 
            { 
                if (this._valueJurosAntecipacao == value)return;
                 this._valueJurosAntecipacao = value; 
            } 
        } 

       private List<long> _collectionClienteClassContaBancariaOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassContaBancaria 
       { 
           get { if(!_valueCollectionClienteClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassContaBancaria();}
return this._valueCollectionClienteClassContaBancaria; } 
           set 
           { 
               this._valueCollectionClienteClassContaBancaria = value; 
               this._valueCollectionClienteClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionCobRemessaClassContaBancariaOriginal;
       private List<Entidades.CobRemessaClass > _collectionCobRemessaClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobRemessaClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobRemessaClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobRemessaClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CobRemessaClass> _valueCollectionCobRemessaClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CobRemessaClass> CollectionCobRemessaClassContaBancaria 
       { 
           get { if(!_valueCollectionCobRemessaClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionCobRemessaClassContaBancaria();}
return this._valueCollectionCobRemessaClassContaBancaria; } 
           set 
           { 
               this._valueCollectionCobRemessaClassContaBancaria = value; 
               this._valueCollectionCobRemessaClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionConciliacaoBancariaClassContaBancariaOriginal;
       private List<Entidades.ConciliacaoBancariaClass > _collectionConciliacaoBancariaClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionConciliacaoBancariaClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionConciliacaoBancariaClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionConciliacaoBancariaClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ConciliacaoBancariaClass> _valueCollectionConciliacaoBancariaClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ConciliacaoBancariaClass> CollectionConciliacaoBancariaClassContaBancaria 
       { 
           get { if(!_valueCollectionConciliacaoBancariaClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionConciliacaoBancariaClassContaBancaria();}
return this._valueCollectionConciliacaoBancariaClassContaBancaria; } 
           set 
           { 
               this._valueCollectionConciliacaoBancariaClassContaBancaria = value; 
               this._valueCollectionConciliacaoBancariaClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionContaPagarClassContaBancariaOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassContaBancaria 
       { 
           get { if(!_valueCollectionContaPagarClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassContaBancaria();}
return this._valueCollectionContaPagarClassContaBancaria; } 
           set 
           { 
               this._valueCollectionContaPagarClassContaBancaria = value; 
               this._valueCollectionContaPagarClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberClassContaBancariaOriginal;
       private List<Entidades.ContaReceberClass > _collectionContaReceberClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberClass> _valueCollectionContaReceberClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberClass> CollectionContaReceberClassContaBancaria 
       { 
           get { if(!_valueCollectionContaReceberClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberClassContaBancaria();}
return this._valueCollectionContaReceberClassContaBancaria; } 
           set 
           { 
               this._valueCollectionContaReceberClassContaBancaria = value; 
               this._valueCollectionContaReceberClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberBoletoClassContaBancariaOriginal;
       private List<Entidades.ContaReceberBoletoClass > _collectionContaReceberBoletoClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberBoletoClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberBoletoClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberBoletoClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberBoletoClass> _valueCollectionContaReceberBoletoClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberBoletoClass> CollectionContaReceberBoletoClassContaBancaria 
       { 
           get { if(!_valueCollectionContaReceberBoletoClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberBoletoClassContaBancaria();}
return this._valueCollectionContaReceberBoletoClassContaBancaria; } 
           set 
           { 
               this._valueCollectionContaReceberBoletoClassContaBancaria = value; 
               this._valueCollectionContaReceberBoletoClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionContaRecorrenteClassContaBancariaOriginal;
       private List<Entidades.ContaRecorrenteClass > _collectionContaRecorrenteClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaRecorrenteClass> _valueCollectionContaRecorrenteClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaRecorrenteClass> CollectionContaRecorrenteClassContaBancaria 
       { 
           get { if(!_valueCollectionContaRecorrenteClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionContaRecorrenteClassContaBancaria();}
return this._valueCollectionContaRecorrenteClassContaBancaria; } 
           set 
           { 
               this._valueCollectionContaRecorrenteClassContaBancaria = value; 
               this._valueCollectionContaRecorrenteClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionFormaPagamentoClassContaBancariaOriginal;
       private List<Entidades.FormaPagamentoClass > _collectionFormaPagamentoClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFormaPagamentoClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFormaPagamentoClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFormaPagamentoClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FormaPagamentoClass> _valueCollectionFormaPagamentoClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FormaPagamentoClass> CollectionFormaPagamentoClassContaBancaria 
       { 
           get { if(!_valueCollectionFormaPagamentoClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionFormaPagamentoClassContaBancaria();}
return this._valueCollectionFormaPagamentoClassContaBancaria; } 
           set 
           { 
               this._valueCollectionFormaPagamentoClassContaBancaria = value; 
               this._valueCollectionFormaPagamentoClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionFornecedorClassContaBancariaOriginal;
       private List<Entidades.FornecedorClass > _collectionFornecedorClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FornecedorClass> _valueCollectionFornecedorClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FornecedorClass> CollectionFornecedorClassContaBancaria 
       { 
           get { if(!_valueCollectionFornecedorClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionFornecedorClassContaBancaria();}
return this._valueCollectionFornecedorClassContaBancaria; } 
           set 
           { 
               this._valueCollectionFornecedorClassContaBancaria = value; 
               this._valueCollectionFornecedorClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemClassContaBancariaOriginal;
       private List<Entidades.OrcamentoItemClass > _collectionOrcamentoItemClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemClass> _valueCollectionOrcamentoItemClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemClass> CollectionOrcamentoItemClassContaBancaria 
       { 
           get { if(!_valueCollectionOrcamentoItemClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemClassContaBancaria();}
return this._valueCollectionOrcamentoItemClassContaBancaria; } 
           set 
           { 
               this._valueCollectionOrcamentoItemClassContaBancaria = value; 
               this._valueCollectionOrcamentoItemClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassContaBancariaOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassContaBancaria 
       { 
           get { if(!_valueCollectionPedidoItemClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassContaBancaria();}
return this._valueCollectionPedidoItemClassContaBancaria; } 
           set 
           { 
               this._valueCollectionPedidoItemClassContaBancaria = value; 
               this._valueCollectionPedidoItemClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionRepresentanteClassContaBancariaOriginal;
       private List<Entidades.RepresentanteClass > _collectionRepresentanteClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.RepresentanteClass> _valueCollectionRepresentanteClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.RepresentanteClass> CollectionRepresentanteClassContaBancaria 
       { 
           get { if(!_valueCollectionRepresentanteClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionRepresentanteClassContaBancaria();}
return this._valueCollectionRepresentanteClassContaBancaria; } 
           set 
           { 
               this._valueCollectionRepresentanteClassContaBancaria = value; 
               this._valueCollectionRepresentanteClassContaBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionTransferenciaBancariaClassContaBancariaOrigemOriginal;
       private List<Entidades.TransferenciaBancariaClass > _collectionTransferenciaBancariaClassContaBancariaOrigemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassContaBancariaOrigemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassContaBancariaOrigemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.TransferenciaBancariaClass> _valueCollectionTransferenciaBancariaClassContaBancariaOrigem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.TransferenciaBancariaClass> CollectionTransferenciaBancariaClassContaBancariaOrigem 
       { 
           get { if(!_valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded && !this.DisableLoadCollection){this.LoadCollectionTransferenciaBancariaClassContaBancariaOrigem();}
return this._valueCollectionTransferenciaBancariaClassContaBancariaOrigem; } 
           set 
           { 
               this._valueCollectionTransferenciaBancariaClassContaBancariaOrigem = value; 
               this._valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded = true; 
           } 
       } 

       private List<long> _collectionTransferenciaBancariaClassContaBancariaDestinoOriginal;
       private List<Entidades.TransferenciaBancariaClass > _collectionTransferenciaBancariaClassContaBancariaDestinoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassContaBancariaDestinoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassContaBancariaDestinoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.TransferenciaBancariaClass> _valueCollectionTransferenciaBancariaClassContaBancariaDestino { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.TransferenciaBancariaClass> CollectionTransferenciaBancariaClassContaBancariaDestino 
       { 
           get { if(!_valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded && !this.DisableLoadCollection){this.LoadCollectionTransferenciaBancariaClassContaBancariaDestino();}
return this._valueCollectionTransferenciaBancariaClassContaBancariaDestino; } 
           set 
           { 
               this._valueCollectionTransferenciaBancariaClassContaBancariaDestino = value; 
               this._valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded = true; 
           } 
       } 

       private List<long> _collectionVendedorClassContaBancariaOriginal;
       private List<Entidades.VendedorClass > _collectionVendedorClassContaBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVendedorClassContaBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVendedorClassContaBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVendedorClassContaBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.VendedorClass> _valueCollectionVendedorClassContaBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.VendedorClass> CollectionVendedorClassContaBancaria 
       { 
           get { if(!_valueCollectionVendedorClassContaBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionVendedorClassContaBancaria();}
return this._valueCollectionVendedorClassContaBancaria; } 
           set 
           { 
               this._valueCollectionVendedorClassContaBancaria = value; 
               this._valueCollectionVendedorClassContaBancariaLoaded = true; 
           } 
       } 

        public ContaBancariaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.GeracaoAutomaticaBoleto = false;
           this.GeracaoAutomaticaBoletoIntervalo = 0;
           this.GeracaoAutomaticaRemessa = false;
           this.JurosAntecipacao = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ContaBancariaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ContaBancariaClass) GetEntity(typeof(ContaBancariaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionClienteClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassContaBancariaChanged = true;
                  _valueCollectionClienteClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassContaBancariaChanged = true; 
                  _valueCollectionClienteClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassContaBancariaChanged = true; 
                  _valueCollectionClienteClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassContaBancaria) 
                 { 
                     _collectionClienteClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassContaBancariaChanged = false;
                 _valueCollectionClienteClassContaBancariaCommitedChanged = false;
                _collectionClienteClassContaBancariaRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassContaBancaria = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassContaBancariaOriginal= (from a in _valueCollectionClienteClassContaBancaria select a.ID).ToList();
                 _valueCollectionClienteClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionCobRemessaClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCobRemessaClassContaBancariaChanged = true;
                  _valueCollectionCobRemessaClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCobRemessaClassContaBancariaChanged = true; 
                  _valueCollectionCobRemessaClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.CobRemessaClass item in e.OldItems) 
                 { 
                     _collectionCobRemessaClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCobRemessaClassContaBancariaChanged = true; 
                  _valueCollectionCobRemessaClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.CobRemessaClass item in _valueCollectionCobRemessaClassContaBancaria) 
                 { 
                     _collectionCobRemessaClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCobRemessaClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.CobRemessaClass> oc;
                _valueCollectionCobRemessaClassContaBancariaChanged = false;
                 _valueCollectionCobRemessaClassContaBancariaCommitedChanged = false;
                _collectionCobRemessaClassContaBancariaRemovidos = new List<Entidades.CobRemessaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CobRemessaClass>();
                }
                else{ 
                   Entidades.CobRemessaClass search = new Entidades.CobRemessaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CobRemessaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.CobRemessaClass>().ToList());
                 }
                 _valueCollectionCobRemessaClassContaBancaria = new BindingList<Entidades.CobRemessaClass>(oc); 
                 _collectionCobRemessaClassContaBancariaOriginal= (from a in _valueCollectionCobRemessaClassContaBancaria select a.ID).ToList();
                 _valueCollectionCobRemessaClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionCobRemessaClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCobRemessaClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionConciliacaoBancariaClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionConciliacaoBancariaClassContaBancariaChanged = true;
                  _valueCollectionConciliacaoBancariaClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionConciliacaoBancariaClassContaBancariaChanged = true; 
                  _valueCollectionConciliacaoBancariaClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ConciliacaoBancariaClass item in e.OldItems) 
                 { 
                     _collectionConciliacaoBancariaClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionConciliacaoBancariaClassContaBancariaChanged = true; 
                  _valueCollectionConciliacaoBancariaClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ConciliacaoBancariaClass item in _valueCollectionConciliacaoBancariaClassContaBancaria) 
                 { 
                     _collectionConciliacaoBancariaClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionConciliacaoBancariaClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.ConciliacaoBancariaClass> oc;
                _valueCollectionConciliacaoBancariaClassContaBancariaChanged = false;
                 _valueCollectionConciliacaoBancariaClassContaBancariaCommitedChanged = false;
                _collectionConciliacaoBancariaClassContaBancariaRemovidos = new List<Entidades.ConciliacaoBancariaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ConciliacaoBancariaClass>();
                }
                else{ 
                   Entidades.ConciliacaoBancariaClass search = new Entidades.ConciliacaoBancariaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ConciliacaoBancariaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this)                    }                       ).Cast<Entidades.ConciliacaoBancariaClass>().ToList());
                 }
                 _valueCollectionConciliacaoBancariaClassContaBancaria = new BindingList<Entidades.ConciliacaoBancariaClass>(oc); 
                 _collectionConciliacaoBancariaClassContaBancariaOriginal= (from a in _valueCollectionConciliacaoBancariaClassContaBancaria select a.ID).ToList();
                 _valueCollectionConciliacaoBancariaClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionConciliacaoBancariaClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionConciliacaoBancariaClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaPagarClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassContaBancariaChanged = true;
                  _valueCollectionContaPagarClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassContaBancariaChanged = true; 
                  _valueCollectionContaPagarClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassContaBancariaChanged = true; 
                  _valueCollectionContaPagarClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassContaBancaria) 
                 { 
                     _collectionContaPagarClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassContaBancariaChanged = false;
                 _valueCollectionContaPagarClassContaBancariaCommitedChanged = false;
                _collectionContaPagarClassContaBancariaRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassContaBancaria = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassContaBancariaOriginal= (from a in _valueCollectionContaPagarClassContaBancaria select a.ID).ToList();
                 _valueCollectionContaPagarClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberClassContaBancariaChanged = true;
                  _valueCollectionContaReceberClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberClassContaBancariaChanged = true; 
                  _valueCollectionContaReceberClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in e.OldItems) 
                 { 
                     _collectionContaReceberClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberClassContaBancariaChanged = true; 
                  _valueCollectionContaReceberClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in _valueCollectionContaReceberClassContaBancaria) 
                 { 
                     _collectionContaReceberClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberClass> oc;
                _valueCollectionContaReceberClassContaBancariaChanged = false;
                 _valueCollectionContaReceberClassContaBancariaCommitedChanged = false;
                _collectionContaReceberClassContaBancariaRemovidos = new List<Entidades.ContaReceberClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberClass>();
                }
                else{ 
                   Entidades.ContaReceberClass search = new Entidades.ContaReceberClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this)                    }                       ).Cast<Entidades.ContaReceberClass>().ToList());
                 }
                 _valueCollectionContaReceberClassContaBancaria = new BindingList<Entidades.ContaReceberClass>(oc); 
                 _collectionContaReceberClassContaBancariaOriginal= (from a in _valueCollectionContaReceberClassContaBancaria select a.ID).ToList();
                 _valueCollectionContaReceberClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberBoletoClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberBoletoClassContaBancariaChanged = true;
                  _valueCollectionContaReceberBoletoClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberBoletoClassContaBancariaChanged = true; 
                  _valueCollectionContaReceberBoletoClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ContaReceberBoletoClass item in e.OldItems) 
                 { 
                     _collectionContaReceberBoletoClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberBoletoClassContaBancariaChanged = true; 
                  _valueCollectionContaReceberBoletoClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ContaReceberBoletoClass item in _valueCollectionContaReceberBoletoClassContaBancaria) 
                 { 
                     _collectionContaReceberBoletoClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberBoletoClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberBoletoClass> oc;
                _valueCollectionContaReceberBoletoClassContaBancariaChanged = false;
                 _valueCollectionContaReceberBoletoClassContaBancariaCommitedChanged = false;
                _collectionContaReceberBoletoClassContaBancariaRemovidos = new List<Entidades.ContaReceberBoletoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberBoletoClass>();
                }
                else{ 
                   Entidades.ContaReceberBoletoClass search = new Entidades.ContaReceberBoletoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberBoletoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.ContaReceberBoletoClass>().ToList());
                 }
                 _valueCollectionContaReceberBoletoClassContaBancaria = new BindingList<Entidades.ContaReceberBoletoClass>(oc); 
                 _collectionContaReceberBoletoClassContaBancariaOriginal= (from a in _valueCollectionContaReceberBoletoClassContaBancaria select a.ID).ToList();
                 _valueCollectionContaReceberBoletoClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberBoletoClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberBoletoClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaRecorrenteClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaRecorrenteClassContaBancariaChanged = true;
                  _valueCollectionContaRecorrenteClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaRecorrenteClassContaBancariaChanged = true; 
                  _valueCollectionContaRecorrenteClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in e.OldItems) 
                 { 
                     _collectionContaRecorrenteClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaRecorrenteClassContaBancariaChanged = true; 
                  _valueCollectionContaRecorrenteClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in _valueCollectionContaRecorrenteClassContaBancaria) 
                 { 
                     _collectionContaRecorrenteClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaRecorrenteClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.ContaRecorrenteClass> oc;
                _valueCollectionContaRecorrenteClassContaBancariaChanged = false;
                 _valueCollectionContaRecorrenteClassContaBancariaCommitedChanged = false;
                _collectionContaRecorrenteClassContaBancariaRemovidos = new List<Entidades.ContaRecorrenteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaRecorrenteClass>();
                }
                else{ 
                   Entidades.ContaRecorrenteClass search = new Entidades.ContaRecorrenteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaRecorrenteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.ContaRecorrenteClass>().ToList());
                 }
                 _valueCollectionContaRecorrenteClassContaBancaria = new BindingList<Entidades.ContaRecorrenteClass>(oc); 
                 _collectionContaRecorrenteClassContaBancariaOriginal= (from a in _valueCollectionContaRecorrenteClassContaBancaria select a.ID).ToList();
                 _valueCollectionContaRecorrenteClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionContaRecorrenteClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaRecorrenteClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFormaPagamentoClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFormaPagamentoClassContaBancariaChanged = true;
                  _valueCollectionFormaPagamentoClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFormaPagamentoClassContaBancariaChanged = true; 
                  _valueCollectionFormaPagamentoClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.FormaPagamentoClass item in e.OldItems) 
                 { 
                     _collectionFormaPagamentoClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFormaPagamentoClassContaBancariaChanged = true; 
                  _valueCollectionFormaPagamentoClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.FormaPagamentoClass item in _valueCollectionFormaPagamentoClassContaBancaria) 
                 { 
                     _collectionFormaPagamentoClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFormaPagamentoClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.FormaPagamentoClass> oc;
                _valueCollectionFormaPagamentoClassContaBancariaChanged = false;
                 _valueCollectionFormaPagamentoClassContaBancariaCommitedChanged = false;
                _collectionFormaPagamentoClassContaBancariaRemovidos = new List<Entidades.FormaPagamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FormaPagamentoClass>();
                }
                else{ 
                   Entidades.FormaPagamentoClass search = new Entidades.FormaPagamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FormaPagamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.FormaPagamentoClass>().ToList());
                 }
                 _valueCollectionFormaPagamentoClassContaBancaria = new BindingList<Entidades.FormaPagamentoClass>(oc); 
                 _collectionFormaPagamentoClassContaBancariaOriginal= (from a in _valueCollectionFormaPagamentoClassContaBancaria select a.ID).ToList();
                 _valueCollectionFormaPagamentoClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionFormaPagamentoClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFormaPagamentoClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFornecedorClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFornecedorClassContaBancariaChanged = true;
                  _valueCollectionFornecedorClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFornecedorClassContaBancariaChanged = true; 
                  _valueCollectionFornecedorClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in e.OldItems) 
                 { 
                     _collectionFornecedorClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFornecedorClassContaBancariaChanged = true; 
                  _valueCollectionFornecedorClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in _valueCollectionFornecedorClassContaBancaria) 
                 { 
                     _collectionFornecedorClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFornecedorClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.FornecedorClass> oc;
                _valueCollectionFornecedorClassContaBancariaChanged = false;
                 _valueCollectionFornecedorClassContaBancariaCommitedChanged = false;
                _collectionFornecedorClassContaBancariaRemovidos = new List<Entidades.FornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FornecedorClass>();
                }
                else{ 
                   Entidades.FornecedorClass search = new Entidades.FornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.FornecedorClass>().ToList());
                 }
                 _valueCollectionFornecedorClassContaBancaria = new BindingList<Entidades.FornecedorClass>(oc); 
                 _collectionFornecedorClassContaBancariaOriginal= (from a in _valueCollectionFornecedorClassContaBancaria select a.ID).ToList();
                 _valueCollectionFornecedorClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionFornecedorClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFornecedorClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemClassContaBancariaChanged = true;
                  _valueCollectionOrcamentoItemClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemClassContaBancariaChanged = true; 
                  _valueCollectionOrcamentoItemClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemClassContaBancariaChanged = true; 
                  _valueCollectionOrcamentoItemClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in _valueCollectionOrcamentoItemClassContaBancaria) 
                 { 
                     _collectionOrcamentoItemClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemClass> oc;
                _valueCollectionOrcamentoItemClassContaBancariaChanged = false;
                 _valueCollectionOrcamentoItemClassContaBancariaCommitedChanged = false;
                _collectionOrcamentoItemClassContaBancariaRemovidos = new List<Entidades.OrcamentoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemClass>();
                }
                else{ 
                   Entidades.OrcamentoItemClass search = new Entidades.OrcamentoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.OrcamentoItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemClassContaBancaria = new BindingList<Entidades.OrcamentoItemClass>(oc); 
                 _collectionOrcamentoItemClassContaBancariaOriginal= (from a in _valueCollectionOrcamentoItemClassContaBancaria select a.ID).ToList();
                 _valueCollectionOrcamentoItemClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassContaBancariaChanged = true;
                  _valueCollectionPedidoItemClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassContaBancariaChanged = true; 
                  _valueCollectionPedidoItemClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassContaBancariaChanged = true; 
                  _valueCollectionPedidoItemClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassContaBancaria) 
                 { 
                     _collectionPedidoItemClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassContaBancariaChanged = false;
                 _valueCollectionPedidoItemClassContaBancariaCommitedChanged = false;
                _collectionPedidoItemClassContaBancariaRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassContaBancaria = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassContaBancariaOriginal= (from a in _valueCollectionPedidoItemClassContaBancaria select a.ID).ToList();
                 _valueCollectionPedidoItemClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionRepresentanteClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionRepresentanteClassContaBancariaChanged = true;
                  _valueCollectionRepresentanteClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionRepresentanteClassContaBancariaChanged = true; 
                  _valueCollectionRepresentanteClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.RepresentanteClass item in e.OldItems) 
                 { 
                     _collectionRepresentanteClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionRepresentanteClassContaBancariaChanged = true; 
                  _valueCollectionRepresentanteClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.RepresentanteClass item in _valueCollectionRepresentanteClassContaBancaria) 
                 { 
                     _collectionRepresentanteClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionRepresentanteClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.RepresentanteClass> oc;
                _valueCollectionRepresentanteClassContaBancariaChanged = false;
                 _valueCollectionRepresentanteClassContaBancariaCommitedChanged = false;
                _collectionRepresentanteClassContaBancariaRemovidos = new List<Entidades.RepresentanteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.RepresentanteClass>();
                }
                else{ 
                   Entidades.RepresentanteClass search = new Entidades.RepresentanteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.RepresentanteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.RepresentanteClass>().ToList());
                 }
                 _valueCollectionRepresentanteClassContaBancaria = new BindingList<Entidades.RepresentanteClass>(oc); 
                 _collectionRepresentanteClassContaBancariaOriginal= (from a in _valueCollectionRepresentanteClassContaBancaria select a.ID).ToList();
                 _valueCollectionRepresentanteClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionRepresentanteClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionRepresentanteClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionTransferenciaBancariaClassContaBancariaOrigemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionTransferenciaBancariaClassContaBancariaOrigemChanged = true;
                  _valueCollectionTransferenciaBancariaClassContaBancariaOrigemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionTransferenciaBancariaClassContaBancariaOrigemChanged = true; 
                  _valueCollectionTransferenciaBancariaClassContaBancariaOrigemCommitedChanged = true;
                 foreach (Entidades.TransferenciaBancariaClass item in e.OldItems) 
                 { 
                     _collectionTransferenciaBancariaClassContaBancariaOrigemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionTransferenciaBancariaClassContaBancariaOrigemChanged = true; 
                  _valueCollectionTransferenciaBancariaClassContaBancariaOrigemCommitedChanged = true;
                 foreach (Entidades.TransferenciaBancariaClass item in _valueCollectionTransferenciaBancariaClassContaBancariaOrigem) 
                 { 
                     _collectionTransferenciaBancariaClassContaBancariaOrigemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionTransferenciaBancariaClassContaBancariaOrigem()
         {
            try
            {
                 ObservableCollection<Entidades.TransferenciaBancariaClass> oc;
                _valueCollectionTransferenciaBancariaClassContaBancariaOrigemChanged = false;
                 _valueCollectionTransferenciaBancariaClassContaBancariaOrigemCommitedChanged = false;
                _collectionTransferenciaBancariaClassContaBancariaOrigemRemovidos = new List<Entidades.TransferenciaBancariaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.TransferenciaBancariaClass>();
                }
                else{ 
                   Entidades.TransferenciaBancariaClass search = new Entidades.TransferenciaBancariaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.TransferenciaBancariaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancariaOrigem", this),                     }                       ).Cast<Entidades.TransferenciaBancariaClass>().ToList());
                 }
                 _valueCollectionTransferenciaBancariaClassContaBancariaOrigem = new BindingList<Entidades.TransferenciaBancariaClass>(oc); 
                 _collectionTransferenciaBancariaClassContaBancariaOrigemOriginal= (from a in _valueCollectionTransferenciaBancariaClassContaBancariaOrigem select a.ID).ToList();
                 _valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded = true;
                 oc.CollectionChanged += CollectionTransferenciaBancariaClassContaBancariaOrigemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionTransferenciaBancariaClassContaBancariaOrigem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionTransferenciaBancariaClassContaBancariaDestinoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionTransferenciaBancariaClassContaBancariaDestinoChanged = true;
                  _valueCollectionTransferenciaBancariaClassContaBancariaDestinoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionTransferenciaBancariaClassContaBancariaDestinoChanged = true; 
                  _valueCollectionTransferenciaBancariaClassContaBancariaDestinoCommitedChanged = true;
                 foreach (Entidades.TransferenciaBancariaClass item in e.OldItems) 
                 { 
                     _collectionTransferenciaBancariaClassContaBancariaDestinoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionTransferenciaBancariaClassContaBancariaDestinoChanged = true; 
                  _valueCollectionTransferenciaBancariaClassContaBancariaDestinoCommitedChanged = true;
                 foreach (Entidades.TransferenciaBancariaClass item in _valueCollectionTransferenciaBancariaClassContaBancariaDestino) 
                 { 
                     _collectionTransferenciaBancariaClassContaBancariaDestinoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionTransferenciaBancariaClassContaBancariaDestino()
         {
            try
            {
                 ObservableCollection<Entidades.TransferenciaBancariaClass> oc;
                _valueCollectionTransferenciaBancariaClassContaBancariaDestinoChanged = false;
                 _valueCollectionTransferenciaBancariaClassContaBancariaDestinoCommitedChanged = false;
                _collectionTransferenciaBancariaClassContaBancariaDestinoRemovidos = new List<Entidades.TransferenciaBancariaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.TransferenciaBancariaClass>();
                }
                else{ 
                   Entidades.TransferenciaBancariaClass search = new Entidades.TransferenciaBancariaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.TransferenciaBancariaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancariaDestino", this),                     }                       ).Cast<Entidades.TransferenciaBancariaClass>().ToList());
                 }
                 _valueCollectionTransferenciaBancariaClassContaBancariaDestino = new BindingList<Entidades.TransferenciaBancariaClass>(oc); 
                 _collectionTransferenciaBancariaClassContaBancariaDestinoOriginal= (from a in _valueCollectionTransferenciaBancariaClassContaBancariaDestino select a.ID).ToList();
                 _valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded = true;
                 oc.CollectionChanged += CollectionTransferenciaBancariaClassContaBancariaDestinoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionTransferenciaBancariaClassContaBancariaDestino+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionVendedorClassContaBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionVendedorClassContaBancariaChanged = true;
                  _valueCollectionVendedorClassContaBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionVendedorClassContaBancariaChanged = true; 
                  _valueCollectionVendedorClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.VendedorClass item in e.OldItems) 
                 { 
                     _collectionVendedorClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionVendedorClassContaBancariaChanged = true; 
                  _valueCollectionVendedorClassContaBancariaCommitedChanged = true;
                 foreach (Entidades.VendedorClass item in _valueCollectionVendedorClassContaBancaria) 
                 { 
                     _collectionVendedorClassContaBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionVendedorClassContaBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.VendedorClass> oc;
                _valueCollectionVendedorClassContaBancariaChanged = false;
                 _valueCollectionVendedorClassContaBancariaCommitedChanged = false;
                _collectionVendedorClassContaBancariaRemovidos = new List<Entidades.VendedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.VendedorClass>();
                }
                else{ 
                   Entidades.VendedorClass search = new Entidades.VendedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.VendedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaBancaria", this),                     }                       ).Cast<Entidades.VendedorClass>().ToList());
                 }
                 _valueCollectionVendedorClassContaBancaria = new BindingList<Entidades.VendedorClass>(oc); 
                 _collectionVendedorClassContaBancariaOriginal= (from a in _valueCollectionVendedorClassContaBancaria select a.ID).ToList();
                 _valueCollectionVendedorClassContaBancariaLoaded = true;
                 oc.CollectionChanged += CollectionVendedorClassContaBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionVendedorClassContaBancaria+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Identificacao))
                {
                    throw new Exception(ErroIdentificacaoObrigatorio);
                }
                if (Identificacao.Length >255)
                {
                    throw new Exception( ErroIdentificacaoComprimento);
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
                    "  public.conta_bancaria  " +
                    "WHERE " +
                    "  id_conta_bancaria = :id";
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
                        "  public.conta_bancaria   " +
                        "SET  " + 
                        "  cba_nome_banco = :cba_nome_banco, " + 
                        "  cba_codigo_banco = :cba_codigo_banco, " + 
                        "  cba_numero_conta = :cba_numero_conta, " + 
                        "  cba_agencia = :cba_agencia, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  cba_identificacao = :cba_identificacao, " + 
                        "  cba_agencia_dv = :cba_agencia_dv, " + 
                        "  cba_conta_dv = :cba_conta_dv, " + 
                        "  cba_numero_carteira_boleto = :cba_numero_carteira_boleto, " + 
                        "  cba_codigo_carteira_boleto = :cba_codigo_carteira_boleto, " + 
                        "  cob_id_cobranca_conta_bancaria = :cob_id_cobranca_conta_bancaria, " + 
                        "  cob_geracao_automatica_boleto = :cob_geracao_automatica_boleto, " + 
                        "  cob_geracao_automatica_boleto_intervalo = :cob_geracao_automatica_boleto_intervalo, " + 
                        "  cob_geracao_automatica_remessa = :cob_geracao_automatica_remessa, " + 
                        "  cob_geracao_automatica_boleto_diretorio = :cob_geracao_automatica_boleto_diretorio, " + 
                        "  cob_geracao_automatica_remessa_diretorio = :cob_geracao_automatica_remessa_diretorio, " + 
                        "  cob_cpf_cnpj = :cob_cpf_cnpj, " + 
                        "  cob_chave_pix = :cob_chave_pix, " + 
                        "  cob_juros_antecipacao = :cob_juros_antecipacao "+
                        "WHERE  " +
                        "  id_conta_bancaria = :id " +
                        "RETURNING id_conta_bancaria;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.conta_bancaria " +
                        "( " +
                        "  cba_nome_banco , " + 
                        "  cba_codigo_banco , " + 
                        "  cba_numero_conta , " + 
                        "  cba_agencia , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  cba_identificacao , " + 
                        "  cba_agencia_dv , " + 
                        "  cba_conta_dv , " + 
                        "  cba_numero_carteira_boleto , " + 
                        "  cba_codigo_carteira_boleto , " + 
                        "  cob_id_cobranca_conta_bancaria , " + 
                        "  cob_geracao_automatica_boleto , " + 
                        "  cob_geracao_automatica_boleto_intervalo , " + 
                        "  cob_geracao_automatica_remessa , " + 
                        "  cob_geracao_automatica_boleto_diretorio , " + 
                        "  cob_geracao_automatica_remessa_diretorio , " + 
                        "  cob_cpf_cnpj , " + 
                        "  cob_chave_pix , " + 
                        "  cob_juros_antecipacao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :cba_nome_banco , " + 
                        "  :cba_codigo_banco , " + 
                        "  :cba_numero_conta , " + 
                        "  :cba_agencia , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :cba_identificacao , " + 
                        "  :cba_agencia_dv , " + 
                        "  :cba_conta_dv , " + 
                        "  :cba_numero_carteira_boleto , " + 
                        "  :cba_codigo_carteira_boleto , " + 
                        "  :cob_id_cobranca_conta_bancaria , " + 
                        "  :cob_geracao_automatica_boleto , " + 
                        "  :cob_geracao_automatica_boleto_intervalo , " + 
                        "  :cob_geracao_automatica_remessa , " + 
                        "  :cob_geracao_automatica_boleto_diretorio , " + 
                        "  :cob_geracao_automatica_remessa_diretorio , " + 
                        "  :cob_cpf_cnpj , " + 
                        "  :cob_chave_pix , " + 
                        "  :cob_juros_antecipacao  "+
                        ")RETURNING id_conta_bancaria;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cba_nome_banco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeBanco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cba_codigo_banco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoBanco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cba_numero_conta", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroConta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cba_agencia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Agencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cba_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cba_agencia_dv", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AgenciaDv ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cba_conta_dv", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ContaDv ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cba_numero_carteira_boleto", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroCarteiraBoleto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cba_codigo_carteira_boleto", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoCarteiraBoleto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_id_cobranca_conta_bancaria", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdCobrancaContaBancaria ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_geracao_automatica_boleto", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GeracaoAutomaticaBoleto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_geracao_automatica_boleto_intervalo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GeracaoAutomaticaBoletoIntervalo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_geracao_automatica_remessa", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GeracaoAutomaticaRemessa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_geracao_automatica_boleto_diretorio", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GeracaoAutomaticaBoletoDiretorio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_geracao_automatica_remessa_diretorio", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GeracaoAutomaticaRemessaDiretorio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_cpf_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CpfCnpj ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_chave_pix", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ChavePix ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_juros_antecipacao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JurosAntecipacao ?? DBNull.Value;

 
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
 if (CollectionClienteClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassContaBancaria+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionCobRemessaClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCobRemessaClassContaBancaria+"\r\n";
                foreach (Entidades.CobRemessaClass tmp in CollectionCobRemessaClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionConciliacaoBancariaClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionConciliacaoBancariaClassContaBancaria+"\r\n";
                foreach (Entidades.ConciliacaoBancariaClass tmp in CollectionConciliacaoBancariaClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaPagarClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassContaBancaria+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberClassContaBancaria+"\r\n";
                foreach (Entidades.ContaReceberClass tmp in CollectionContaReceberClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberBoletoClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberBoletoClassContaBancaria+"\r\n";
                foreach (Entidades.ContaReceberBoletoClass tmp in CollectionContaReceberBoletoClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaRecorrenteClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaRecorrenteClassContaBancaria+"\r\n";
                foreach (Entidades.ContaRecorrenteClass tmp in CollectionContaRecorrenteClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFormaPagamentoClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFormaPagamentoClassContaBancaria+"\r\n";
                foreach (Entidades.FormaPagamentoClass tmp in CollectionFormaPagamentoClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFornecedorClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFornecedorClassContaBancaria+"\r\n";
                foreach (Entidades.FornecedorClass tmp in CollectionFornecedorClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassContaBancaria+"\r\n";
                foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassContaBancaria+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionRepresentanteClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionRepresentanteClassContaBancaria+"\r\n";
                foreach (Entidades.RepresentanteClass tmp in CollectionRepresentanteClassContaBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionTransferenciaBancariaClassContaBancariaOrigem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionTransferenciaBancariaClassContaBancariaOrigem+"\r\n";
                foreach (Entidades.TransferenciaBancariaClass tmp in CollectionTransferenciaBancariaClassContaBancariaOrigem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionTransferenciaBancariaClassContaBancariaDestino.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionTransferenciaBancariaClassContaBancariaDestino+"\r\n";
                foreach (Entidades.TransferenciaBancariaClass tmp in CollectionTransferenciaBancariaClassContaBancariaDestino)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionVendedorClassContaBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionVendedorClassContaBancaria+"\r\n";
                foreach (Entidades.VendedorClass tmp in CollectionVendedorClassContaBancaria)
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
        public static ContaBancariaClass CopiarEntidade(ContaBancariaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ContaBancariaClass toRet = new ContaBancariaClass(usuario,conn);
 toRet.NomeBanco= entidadeCopiar.NomeBanco;
 toRet.CodigoBanco= entidadeCopiar.CodigoBanco;
 toRet.NumeroConta= entidadeCopiar.NumeroConta;
 toRet.Agencia= entidadeCopiar.Agencia;
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.AgenciaDv= entidadeCopiar.AgenciaDv;
 toRet.ContaDv= entidadeCopiar.ContaDv;
 toRet.NumeroCarteiraBoleto= entidadeCopiar.NumeroCarteiraBoleto;
 toRet.CodigoCarteiraBoleto= entidadeCopiar.CodigoCarteiraBoleto;
 toRet.IdCobrancaContaBancaria= entidadeCopiar.IdCobrancaContaBancaria;
 toRet.GeracaoAutomaticaBoleto= entidadeCopiar.GeracaoAutomaticaBoleto;
 toRet.GeracaoAutomaticaBoletoIntervalo= entidadeCopiar.GeracaoAutomaticaBoletoIntervalo;
 toRet.GeracaoAutomaticaRemessa= entidadeCopiar.GeracaoAutomaticaRemessa;
 toRet.GeracaoAutomaticaBoletoDiretorio= entidadeCopiar.GeracaoAutomaticaBoletoDiretorio;
 toRet.GeracaoAutomaticaRemessaDiretorio= entidadeCopiar.GeracaoAutomaticaRemessaDiretorio;
 toRet.CpfCnpj= entidadeCopiar.CpfCnpj;
 toRet.ChavePix= entidadeCopiar.ChavePix;
 toRet.JurosAntecipacao= entidadeCopiar.JurosAntecipacao;

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
       _nomeBancoOriginal = NomeBanco;
       _nomeBancoOriginalCommited = _nomeBancoOriginal;
       _codigoBancoOriginal = CodigoBanco;
       _codigoBancoOriginalCommited = _codigoBancoOriginal;
       _numeroContaOriginal = NumeroConta;
       _numeroContaOriginalCommited = _numeroContaOriginal;
       _agenciaOriginal = Agencia;
       _agenciaOriginalCommited = _agenciaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _agenciaDvOriginal = AgenciaDv;
       _agenciaDvOriginalCommited = _agenciaDvOriginal;
       _contaDvOriginal = ContaDv;
       _contaDvOriginalCommited = _contaDvOriginal;
       _numeroCarteiraBoletoOriginal = NumeroCarteiraBoleto;
       _numeroCarteiraBoletoOriginalCommited = _numeroCarteiraBoletoOriginal;
       _codigoCarteiraBoletoOriginal = CodigoCarteiraBoleto;
       _codigoCarteiraBoletoOriginalCommited = _codigoCarteiraBoletoOriginal;
       _idCobrancaContaBancariaOriginal = IdCobrancaContaBancaria;
       _idCobrancaContaBancariaOriginalCommited = _idCobrancaContaBancariaOriginal;
       _geracaoAutomaticaBoletoOriginal = GeracaoAutomaticaBoleto;
       _geracaoAutomaticaBoletoOriginalCommited = _geracaoAutomaticaBoletoOriginal;
       _geracaoAutomaticaBoletoIntervaloOriginal = GeracaoAutomaticaBoletoIntervalo;
       _geracaoAutomaticaBoletoIntervaloOriginalCommited = _geracaoAutomaticaBoletoIntervaloOriginal;
       _geracaoAutomaticaRemessaOriginal = GeracaoAutomaticaRemessa;
       _geracaoAutomaticaRemessaOriginalCommited = _geracaoAutomaticaRemessaOriginal;
       _geracaoAutomaticaBoletoDiretorioOriginal = GeracaoAutomaticaBoletoDiretorio;
       _geracaoAutomaticaBoletoDiretorioOriginalCommited = _geracaoAutomaticaBoletoDiretorioOriginal;
       _geracaoAutomaticaRemessaDiretorioOriginal = GeracaoAutomaticaRemessaDiretorio;
       _geracaoAutomaticaRemessaDiretorioOriginalCommited = _geracaoAutomaticaRemessaDiretorioOriginal;
       _cpfCnpjOriginal = CpfCnpj;
       _cpfCnpjOriginalCommited = _cpfCnpjOriginal;
       _chavePixOriginal = ChavePix;
       _chavePixOriginalCommited = _chavePixOriginal;
       _jurosAntecipacaoOriginal = JurosAntecipacao;
       _jurosAntecipacaoOriginalCommited = _jurosAntecipacaoOriginal;

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
       _nomeBancoOriginalCommited = NomeBanco;
       _codigoBancoOriginalCommited = CodigoBanco;
       _numeroContaOriginalCommited = NumeroConta;
       _agenciaOriginalCommited = Agencia;
       _versionOriginalCommited = Version;
       _identificacaoOriginalCommited = Identificacao;
       _agenciaDvOriginalCommited = AgenciaDv;
       _contaDvOriginalCommited = ContaDv;
       _numeroCarteiraBoletoOriginalCommited = NumeroCarteiraBoleto;
       _codigoCarteiraBoletoOriginalCommited = CodigoCarteiraBoleto;
       _idCobrancaContaBancariaOriginalCommited = IdCobrancaContaBancaria;
       _geracaoAutomaticaBoletoOriginalCommited = GeracaoAutomaticaBoleto;
       _geracaoAutomaticaBoletoIntervaloOriginalCommited = GeracaoAutomaticaBoletoIntervalo;
       _geracaoAutomaticaRemessaOriginalCommited = GeracaoAutomaticaRemessa;
       _geracaoAutomaticaBoletoDiretorioOriginalCommited = GeracaoAutomaticaBoletoDiretorio;
       _geracaoAutomaticaRemessaDiretorioOriginalCommited = GeracaoAutomaticaRemessaDiretorio;
       _cpfCnpjOriginalCommited = CpfCnpj;
       _chavePixOriginalCommited = ChavePix;
       _jurosAntecipacaoOriginalCommited = JurosAntecipacao;

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
               if (_valueCollectionClienteClassContaBancariaLoaded) 
               {
                  if (_collectionClienteClassContaBancariaRemovidos != null) 
                  {
                     _collectionClienteClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassContaBancariaRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassContaBancariaOriginal= (from a in _valueCollectionClienteClassContaBancaria select a.ID).ToList();
                  _valueCollectionClienteClassContaBancariaChanged = false;
                  _valueCollectionClienteClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionCobRemessaClassContaBancariaLoaded) 
               {
                  if (_collectionCobRemessaClassContaBancariaRemovidos != null) 
                  {
                     _collectionCobRemessaClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCobRemessaClassContaBancariaRemovidos = new List<Entidades.CobRemessaClass>();
                  }
                  _collectionCobRemessaClassContaBancariaOriginal= (from a in _valueCollectionCobRemessaClassContaBancaria select a.ID).ToList();
                  _valueCollectionCobRemessaClassContaBancariaChanged = false;
                  _valueCollectionCobRemessaClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionConciliacaoBancariaClassContaBancariaLoaded) 
               {
                  if (_collectionConciliacaoBancariaClassContaBancariaRemovidos != null) 
                  {
                     _collectionConciliacaoBancariaClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionConciliacaoBancariaClassContaBancariaRemovidos = new List<Entidades.ConciliacaoBancariaClass>();
                  }
                  _collectionConciliacaoBancariaClassContaBancariaOriginal= (from a in _valueCollectionConciliacaoBancariaClassContaBancaria select a.ID).ToList();
                  _valueCollectionConciliacaoBancariaClassContaBancariaChanged = false;
                  _valueCollectionConciliacaoBancariaClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionContaPagarClassContaBancariaLoaded) 
               {
                  if (_collectionContaPagarClassContaBancariaRemovidos != null) 
                  {
                     _collectionContaPagarClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassContaBancariaRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassContaBancariaOriginal= (from a in _valueCollectionContaPagarClassContaBancaria select a.ID).ToList();
                  _valueCollectionContaPagarClassContaBancariaChanged = false;
                  _valueCollectionContaPagarClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionContaReceberClassContaBancariaLoaded) 
               {
                  if (_collectionContaReceberClassContaBancariaRemovidos != null) 
                  {
                     _collectionContaReceberClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberClassContaBancariaRemovidos = new List<Entidades.ContaReceberClass>();
                  }
                  _collectionContaReceberClassContaBancariaOriginal= (from a in _valueCollectionContaReceberClassContaBancaria select a.ID).ToList();
                  _valueCollectionContaReceberClassContaBancariaChanged = false;
                  _valueCollectionContaReceberClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionContaReceberBoletoClassContaBancariaLoaded) 
               {
                  if (_collectionContaReceberBoletoClassContaBancariaRemovidos != null) 
                  {
                     _collectionContaReceberBoletoClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberBoletoClassContaBancariaRemovidos = new List<Entidades.ContaReceberBoletoClass>();
                  }
                  _collectionContaReceberBoletoClassContaBancariaOriginal= (from a in _valueCollectionContaReceberBoletoClassContaBancaria select a.ID).ToList();
                  _valueCollectionContaReceberBoletoClassContaBancariaChanged = false;
                  _valueCollectionContaReceberBoletoClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionContaRecorrenteClassContaBancariaLoaded) 
               {
                  if (_collectionContaRecorrenteClassContaBancariaRemovidos != null) 
                  {
                     _collectionContaRecorrenteClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaRecorrenteClassContaBancariaRemovidos = new List<Entidades.ContaRecorrenteClass>();
                  }
                  _collectionContaRecorrenteClassContaBancariaOriginal= (from a in _valueCollectionContaRecorrenteClassContaBancaria select a.ID).ToList();
                  _valueCollectionContaRecorrenteClassContaBancariaChanged = false;
                  _valueCollectionContaRecorrenteClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionFormaPagamentoClassContaBancariaLoaded) 
               {
                  if (_collectionFormaPagamentoClassContaBancariaRemovidos != null) 
                  {
                     _collectionFormaPagamentoClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFormaPagamentoClassContaBancariaRemovidos = new List<Entidades.FormaPagamentoClass>();
                  }
                  _collectionFormaPagamentoClassContaBancariaOriginal= (from a in _valueCollectionFormaPagamentoClassContaBancaria select a.ID).ToList();
                  _valueCollectionFormaPagamentoClassContaBancariaChanged = false;
                  _valueCollectionFormaPagamentoClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionFornecedorClassContaBancariaLoaded) 
               {
                  if (_collectionFornecedorClassContaBancariaRemovidos != null) 
                  {
                     _collectionFornecedorClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFornecedorClassContaBancariaRemovidos = new List<Entidades.FornecedorClass>();
                  }
                  _collectionFornecedorClassContaBancariaOriginal= (from a in _valueCollectionFornecedorClassContaBancaria select a.ID).ToList();
                  _valueCollectionFornecedorClassContaBancariaChanged = false;
                  _valueCollectionFornecedorClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemClassContaBancariaLoaded) 
               {
                  if (_collectionOrcamentoItemClassContaBancariaRemovidos != null) 
                  {
                     _collectionOrcamentoItemClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemClassContaBancariaRemovidos = new List<Entidades.OrcamentoItemClass>();
                  }
                  _collectionOrcamentoItemClassContaBancariaOriginal= (from a in _valueCollectionOrcamentoItemClassContaBancaria select a.ID).ToList();
                  _valueCollectionOrcamentoItemClassContaBancariaChanged = false;
                  _valueCollectionOrcamentoItemClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassContaBancariaLoaded) 
               {
                  if (_collectionPedidoItemClassContaBancariaRemovidos != null) 
                  {
                     _collectionPedidoItemClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassContaBancariaRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassContaBancariaOriginal= (from a in _valueCollectionPedidoItemClassContaBancaria select a.ID).ToList();
                  _valueCollectionPedidoItemClassContaBancariaChanged = false;
                  _valueCollectionPedidoItemClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionRepresentanteClassContaBancariaLoaded) 
               {
                  if (_collectionRepresentanteClassContaBancariaRemovidos != null) 
                  {
                     _collectionRepresentanteClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionRepresentanteClassContaBancariaRemovidos = new List<Entidades.RepresentanteClass>();
                  }
                  _collectionRepresentanteClassContaBancariaOriginal= (from a in _valueCollectionRepresentanteClassContaBancaria select a.ID).ToList();
                  _valueCollectionRepresentanteClassContaBancariaChanged = false;
                  _valueCollectionRepresentanteClassContaBancariaCommitedChanged = false;
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded) 
               {
                  if (_collectionTransferenciaBancariaClassContaBancariaOrigemRemovidos != null) 
                  {
                     _collectionTransferenciaBancariaClassContaBancariaOrigemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionTransferenciaBancariaClassContaBancariaOrigemRemovidos = new List<Entidades.TransferenciaBancariaClass>();
                  }
                  _collectionTransferenciaBancariaClassContaBancariaOrigemOriginal= (from a in _valueCollectionTransferenciaBancariaClassContaBancariaOrigem select a.ID).ToList();
                  _valueCollectionTransferenciaBancariaClassContaBancariaOrigemChanged = false;
                  _valueCollectionTransferenciaBancariaClassContaBancariaOrigemCommitedChanged = false;
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded) 
               {
                  if (_collectionTransferenciaBancariaClassContaBancariaDestinoRemovidos != null) 
                  {
                     _collectionTransferenciaBancariaClassContaBancariaDestinoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionTransferenciaBancariaClassContaBancariaDestinoRemovidos = new List<Entidades.TransferenciaBancariaClass>();
                  }
                  _collectionTransferenciaBancariaClassContaBancariaDestinoOriginal= (from a in _valueCollectionTransferenciaBancariaClassContaBancariaDestino select a.ID).ToList();
                  _valueCollectionTransferenciaBancariaClassContaBancariaDestinoChanged = false;
                  _valueCollectionTransferenciaBancariaClassContaBancariaDestinoCommitedChanged = false;
               }
               if (_valueCollectionVendedorClassContaBancariaLoaded) 
               {
                  if (_collectionVendedorClassContaBancariaRemovidos != null) 
                  {
                     _collectionVendedorClassContaBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionVendedorClassContaBancariaRemovidos = new List<Entidades.VendedorClass>();
                  }
                  _collectionVendedorClassContaBancariaOriginal= (from a in _valueCollectionVendedorClassContaBancaria select a.ID).ToList();
                  _valueCollectionVendedorClassContaBancariaChanged = false;
                  _valueCollectionVendedorClassContaBancariaCommitedChanged = false;
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
               NomeBanco=_nomeBancoOriginal;
               _nomeBancoOriginalCommited=_nomeBancoOriginal;
               CodigoBanco=_codigoBancoOriginal;
               _codigoBancoOriginalCommited=_codigoBancoOriginal;
               NumeroConta=_numeroContaOriginal;
               _numeroContaOriginalCommited=_numeroContaOriginal;
               Agencia=_agenciaOriginal;
               _agenciaOriginalCommited=_agenciaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               AgenciaDv=_agenciaDvOriginal;
               _agenciaDvOriginalCommited=_agenciaDvOriginal;
               ContaDv=_contaDvOriginal;
               _contaDvOriginalCommited=_contaDvOriginal;
               NumeroCarteiraBoleto=_numeroCarteiraBoletoOriginal;
               _numeroCarteiraBoletoOriginalCommited=_numeroCarteiraBoletoOriginal;
               CodigoCarteiraBoleto=_codigoCarteiraBoletoOriginal;
               _codigoCarteiraBoletoOriginalCommited=_codigoCarteiraBoletoOriginal;
               IdCobrancaContaBancaria=_idCobrancaContaBancariaOriginal;
               _idCobrancaContaBancariaOriginalCommited=_idCobrancaContaBancariaOriginal;
               GeracaoAutomaticaBoleto=_geracaoAutomaticaBoletoOriginal;
               _geracaoAutomaticaBoletoOriginalCommited=_geracaoAutomaticaBoletoOriginal;
               GeracaoAutomaticaBoletoIntervalo=_geracaoAutomaticaBoletoIntervaloOriginal;
               _geracaoAutomaticaBoletoIntervaloOriginalCommited=_geracaoAutomaticaBoletoIntervaloOriginal;
               GeracaoAutomaticaRemessa=_geracaoAutomaticaRemessaOriginal;
               _geracaoAutomaticaRemessaOriginalCommited=_geracaoAutomaticaRemessaOriginal;
               GeracaoAutomaticaBoletoDiretorio=_geracaoAutomaticaBoletoDiretorioOriginal;
               _geracaoAutomaticaBoletoDiretorioOriginalCommited=_geracaoAutomaticaBoletoDiretorioOriginal;
               GeracaoAutomaticaRemessaDiretorio=_geracaoAutomaticaRemessaDiretorioOriginal;
               _geracaoAutomaticaRemessaDiretorioOriginalCommited=_geracaoAutomaticaRemessaDiretorioOriginal;
               CpfCnpj=_cpfCnpjOriginal;
               _cpfCnpjOriginalCommited=_cpfCnpjOriginal;
               ChavePix=_chavePixOriginal;
               _chavePixOriginalCommited=_chavePixOriginal;
               JurosAntecipacao=_jurosAntecipacaoOriginal;
               _jurosAntecipacaoOriginalCommited=_jurosAntecipacaoOriginal;
               if (_valueCollectionClienteClassContaBancariaLoaded) 
               {
                  CollectionClienteClassContaBancaria.Clear();
                  foreach(int item in _collectionClienteClassContaBancariaOriginal)
                  {
                    CollectionClienteClassContaBancaria.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionCobRemessaClassContaBancariaLoaded) 
               {
                  CollectionCobRemessaClassContaBancaria.Clear();
                  foreach(int item in _collectionCobRemessaClassContaBancariaOriginal)
                  {
                    CollectionCobRemessaClassContaBancaria.Add(Entidades.CobRemessaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCobRemessaClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionConciliacaoBancariaClassContaBancariaLoaded) 
               {
                  CollectionConciliacaoBancariaClassContaBancaria.Clear();
                  foreach(int item in _collectionConciliacaoBancariaClassContaBancariaOriginal)
                  {
                    CollectionConciliacaoBancariaClassContaBancaria.Add(Entidades.ConciliacaoBancariaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionConciliacaoBancariaClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionContaPagarClassContaBancariaLoaded) 
               {
                  CollectionContaPagarClassContaBancaria.Clear();
                  foreach(int item in _collectionContaPagarClassContaBancariaOriginal)
                  {
                    CollectionContaPagarClassContaBancaria.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionContaReceberClassContaBancariaLoaded) 
               {
                  CollectionContaReceberClassContaBancaria.Clear();
                  foreach(int item in _collectionContaReceberClassContaBancariaOriginal)
                  {
                    CollectionContaReceberClassContaBancaria.Add(Entidades.ContaReceberClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionContaReceberBoletoClassContaBancariaLoaded) 
               {
                  CollectionContaReceberBoletoClassContaBancaria.Clear();
                  foreach(int item in _collectionContaReceberBoletoClassContaBancariaOriginal)
                  {
                    CollectionContaReceberBoletoClassContaBancaria.Add(Entidades.ContaReceberBoletoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberBoletoClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionContaRecorrenteClassContaBancariaLoaded) 
               {
                  CollectionContaRecorrenteClassContaBancaria.Clear();
                  foreach(int item in _collectionContaRecorrenteClassContaBancariaOriginal)
                  {
                    CollectionContaRecorrenteClassContaBancaria.Add(Entidades.ContaRecorrenteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaRecorrenteClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionFormaPagamentoClassContaBancariaLoaded) 
               {
                  CollectionFormaPagamentoClassContaBancaria.Clear();
                  foreach(int item in _collectionFormaPagamentoClassContaBancariaOriginal)
                  {
                    CollectionFormaPagamentoClassContaBancaria.Add(Entidades.FormaPagamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFormaPagamentoClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionFornecedorClassContaBancariaLoaded) 
               {
                  CollectionFornecedorClassContaBancaria.Clear();
                  foreach(int item in _collectionFornecedorClassContaBancariaOriginal)
                  {
                    CollectionFornecedorClassContaBancaria.Add(Entidades.FornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFornecedorClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemClassContaBancariaLoaded) 
               {
                  CollectionOrcamentoItemClassContaBancaria.Clear();
                  foreach(int item in _collectionOrcamentoItemClassContaBancariaOriginal)
                  {
                    CollectionOrcamentoItemClassContaBancaria.Add(Entidades.OrcamentoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassContaBancariaLoaded) 
               {
                  CollectionPedidoItemClassContaBancaria.Clear();
                  foreach(int item in _collectionPedidoItemClassContaBancariaOriginal)
                  {
                    CollectionPedidoItemClassContaBancaria.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionRepresentanteClassContaBancariaLoaded) 
               {
                  CollectionRepresentanteClassContaBancaria.Clear();
                  foreach(int item in _collectionRepresentanteClassContaBancariaOriginal)
                  {
                    CollectionRepresentanteClassContaBancaria.Add(Entidades.RepresentanteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionRepresentanteClassContaBancariaRemovidos.Clear();
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded) 
               {
                  CollectionTransferenciaBancariaClassContaBancariaOrigem.Clear();
                  foreach(int item in _collectionTransferenciaBancariaClassContaBancariaOrigemOriginal)
                  {
                    CollectionTransferenciaBancariaClassContaBancariaOrigem.Add(Entidades.TransferenciaBancariaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionTransferenciaBancariaClassContaBancariaOrigemRemovidos.Clear();
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded) 
               {
                  CollectionTransferenciaBancariaClassContaBancariaDestino.Clear();
                  foreach(int item in _collectionTransferenciaBancariaClassContaBancariaDestinoOriginal)
                  {
                    CollectionTransferenciaBancariaClassContaBancariaDestino.Add(Entidades.TransferenciaBancariaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionTransferenciaBancariaClassContaBancariaDestinoRemovidos.Clear();
               }
               if (_valueCollectionVendedorClassContaBancariaLoaded) 
               {
                  CollectionVendedorClassContaBancaria.Clear();
                  foreach(int item in _collectionVendedorClassContaBancariaOriginal)
                  {
                    CollectionVendedorClassContaBancaria.Add(Entidades.VendedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionVendedorClassContaBancariaRemovidos.Clear();
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
               if (_valueCollectionClienteClassContaBancariaLoaded) 
               {
                  if (_valueCollectionClienteClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobRemessaClassContaBancariaLoaded) 
               {
                  if (_valueCollectionCobRemessaClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionConciliacaoBancariaClassContaBancariaLoaded) 
               {
                  if (_valueCollectionConciliacaoBancariaClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassContaBancariaLoaded) 
               {
                  if (_valueCollectionContaPagarClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassContaBancariaLoaded) 
               {
                  if (_valueCollectionContaReceberClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberBoletoClassContaBancariaLoaded) 
               {
                  if (_valueCollectionContaReceberBoletoClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassContaBancariaLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFormaPagamentoClassContaBancariaLoaded) 
               {
                  if (_valueCollectionFormaPagamentoClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassContaBancariaLoaded) 
               {
                  if (_valueCollectionFornecedorClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassContaBancariaLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassContaBancariaLoaded) 
               {
                  if (_valueCollectionPedidoItemClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRepresentanteClassContaBancariaLoaded) 
               {
                  if (_valueCollectionRepresentanteClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded) 
               {
                  if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded) 
               {
                  if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionVendedorClassContaBancariaLoaded) 
               {
                  if (_valueCollectionVendedorClassContaBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassContaBancariaLoaded) 
               {
                   tempRet = CollectionClienteClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionCobRemessaClassContaBancariaLoaded) 
               {
                   tempRet = CollectionCobRemessaClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionConciliacaoBancariaClassContaBancariaLoaded) 
               {
                   tempRet = CollectionConciliacaoBancariaClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaPagarClassContaBancariaLoaded) 
               {
                   tempRet = CollectionContaPagarClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassContaBancariaLoaded) 
               {
                   tempRet = CollectionContaReceberClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberBoletoClassContaBancariaLoaded) 
               {
                   tempRet = CollectionContaReceberBoletoClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassContaBancariaLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFormaPagamentoClassContaBancariaLoaded) 
               {
                   tempRet = CollectionFormaPagamentoClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassContaBancariaLoaded) 
               {
                   tempRet = CollectionFornecedorClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassContaBancariaLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassContaBancariaLoaded) 
               {
                   tempRet = CollectionPedidoItemClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionRepresentanteClassContaBancariaLoaded) 
               {
                   tempRet = CollectionRepresentanteClassContaBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded) 
               {
                   tempRet = CollectionTransferenciaBancariaClassContaBancariaOrigem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded) 
               {
                   tempRet = CollectionTransferenciaBancariaClassContaBancariaDestino.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionVendedorClassContaBancariaLoaded) 
               {
                   tempRet = CollectionVendedorClassContaBancaria.Any(item => item.IsDirty());
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
       dirty = _nomeBancoOriginal != NomeBanco;
      if (dirty) return true;
       dirty = _codigoBancoOriginal != CodigoBanco;
      if (dirty) return true;
       dirty = _numeroContaOriginal != NumeroConta;
      if (dirty) return true;
       dirty = _agenciaOriginal != Agencia;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _agenciaDvOriginal != AgenciaDv;
      if (dirty) return true;
       dirty = _contaDvOriginal != ContaDv;
      if (dirty) return true;
       dirty = _numeroCarteiraBoletoOriginal != NumeroCarteiraBoleto;
      if (dirty) return true;
       dirty = _codigoCarteiraBoletoOriginal != CodigoCarteiraBoleto;
      if (dirty) return true;
       dirty = _idCobrancaContaBancariaOriginal != IdCobrancaContaBancaria;
      if (dirty) return true;
       dirty = _geracaoAutomaticaBoletoOriginal != GeracaoAutomaticaBoleto;
      if (dirty) return true;
       dirty = _geracaoAutomaticaBoletoIntervaloOriginal != GeracaoAutomaticaBoletoIntervalo;
      if (dirty) return true;
       dirty = _geracaoAutomaticaRemessaOriginal != GeracaoAutomaticaRemessa;
      if (dirty) return true;
       dirty = _geracaoAutomaticaBoletoDiretorioOriginal != GeracaoAutomaticaBoletoDiretorio;
      if (dirty) return true;
       dirty = _geracaoAutomaticaRemessaDiretorioOriginal != GeracaoAutomaticaRemessaDiretorio;
      if (dirty) return true;
       dirty = _cpfCnpjOriginal != CpfCnpj;
      if (dirty) return true;
       dirty = _chavePixOriginal != ChavePix;
      if (dirty) return true;
       dirty = _jurosAntecipacaoOriginal != JurosAntecipacao;

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
               if (_valueCollectionClienteClassContaBancariaLoaded) 
               {
                  if (_valueCollectionClienteClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobRemessaClassContaBancariaLoaded) 
               {
                  if (_valueCollectionCobRemessaClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionConciliacaoBancariaClassContaBancariaLoaded) 
               {
                  if (_valueCollectionConciliacaoBancariaClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassContaBancariaLoaded) 
               {
                  if (_valueCollectionContaPagarClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassContaBancariaLoaded) 
               {
                  if (_valueCollectionContaReceberClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberBoletoClassContaBancariaLoaded) 
               {
                  if (_valueCollectionContaReceberBoletoClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassContaBancariaLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFormaPagamentoClassContaBancariaLoaded) 
               {
                  if (_valueCollectionFormaPagamentoClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassContaBancariaLoaded) 
               {
                  if (_valueCollectionFornecedorClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassContaBancariaLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassContaBancariaLoaded) 
               {
                  if (_valueCollectionPedidoItemClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRepresentanteClassContaBancariaLoaded) 
               {
                  if (_valueCollectionRepresentanteClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded) 
               {
                  if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded) 
               {
                  if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionVendedorClassContaBancariaLoaded) 
               {
                  if (_valueCollectionVendedorClassContaBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassContaBancariaLoaded) 
               {
                   tempRet = CollectionClienteClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionCobRemessaClassContaBancariaLoaded) 
               {
                   tempRet = CollectionCobRemessaClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionConciliacaoBancariaClassContaBancariaLoaded) 
               {
                   tempRet = CollectionConciliacaoBancariaClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaPagarClassContaBancariaLoaded) 
               {
                   tempRet = CollectionContaPagarClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassContaBancariaLoaded) 
               {
                   tempRet = CollectionContaReceberClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberBoletoClassContaBancariaLoaded) 
               {
                   tempRet = CollectionContaReceberBoletoClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassContaBancariaLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFormaPagamentoClassContaBancariaLoaded) 
               {
                   tempRet = CollectionFormaPagamentoClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassContaBancariaLoaded) 
               {
                   tempRet = CollectionFornecedorClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassContaBancariaLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassContaBancariaLoaded) 
               {
                   tempRet = CollectionPedidoItemClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionRepresentanteClassContaBancariaLoaded) 
               {
                   tempRet = CollectionRepresentanteClassContaBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded) 
               {
                   tempRet = CollectionTransferenciaBancariaClassContaBancariaOrigem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded) 
               {
                   tempRet = CollectionTransferenciaBancariaClassContaBancariaDestino.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionVendedorClassContaBancariaLoaded) 
               {
                   tempRet = CollectionVendedorClassContaBancaria.Any(item => item.IsDirtyCommited());
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
       dirty = _nomeBancoOriginalCommited != NomeBanco;
      if (dirty) return true;
       dirty = _codigoBancoOriginalCommited != CodigoBanco;
      if (dirty) return true;
       dirty = _numeroContaOriginalCommited != NumeroConta;
      if (dirty) return true;
       dirty = _agenciaOriginalCommited != Agencia;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _agenciaDvOriginalCommited != AgenciaDv;
      if (dirty) return true;
       dirty = _contaDvOriginalCommited != ContaDv;
      if (dirty) return true;
       dirty = _numeroCarteiraBoletoOriginalCommited != NumeroCarteiraBoleto;
      if (dirty) return true;
       dirty = _codigoCarteiraBoletoOriginalCommited != CodigoCarteiraBoleto;
      if (dirty) return true;
       dirty = _idCobrancaContaBancariaOriginalCommited != IdCobrancaContaBancaria;
      if (dirty) return true;
       dirty = _geracaoAutomaticaBoletoOriginalCommited != GeracaoAutomaticaBoleto;
      if (dirty) return true;
       dirty = _geracaoAutomaticaBoletoIntervaloOriginalCommited != GeracaoAutomaticaBoletoIntervalo;
      if (dirty) return true;
       dirty = _geracaoAutomaticaRemessaOriginalCommited != GeracaoAutomaticaRemessa;
      if (dirty) return true;
       dirty = _geracaoAutomaticaBoletoDiretorioOriginalCommited != GeracaoAutomaticaBoletoDiretorio;
      if (dirty) return true;
       dirty = _geracaoAutomaticaRemessaDiretorioOriginalCommited != GeracaoAutomaticaRemessaDiretorio;
      if (dirty) return true;
       dirty = _cpfCnpjOriginalCommited != CpfCnpj;
      if (dirty) return true;
       dirty = _chavePixOriginalCommited != ChavePix;
      if (dirty) return true;
       dirty = _jurosAntecipacaoOriginalCommited != JurosAntecipacao;

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
               if (_valueCollectionClienteClassContaBancariaLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionCobRemessaClassContaBancariaLoaded) 
               {
                  foreach(CobRemessaClass item in CollectionCobRemessaClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionConciliacaoBancariaClassContaBancariaLoaded) 
               {
                  foreach(ConciliacaoBancariaClass item in CollectionConciliacaoBancariaClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaPagarClassContaBancariaLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberClassContaBancariaLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberBoletoClassContaBancariaLoaded) 
               {
                  foreach(ContaReceberBoletoClass item in CollectionContaReceberBoletoClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaRecorrenteClassContaBancariaLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFormaPagamentoClassContaBancariaLoaded) 
               {
                  foreach(FormaPagamentoClass item in CollectionFormaPagamentoClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFornecedorClassContaBancariaLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemClassContaBancariaLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassContaBancariaLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionRepresentanteClassContaBancariaLoaded) 
               {
                  foreach(RepresentanteClass item in CollectionRepresentanteClassContaBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded) 
               {
                  foreach(TransferenciaBancariaClass item in CollectionTransferenciaBancariaClassContaBancariaOrigem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded) 
               {
                  foreach(TransferenciaBancariaClass item in CollectionTransferenciaBancariaClassContaBancariaDestino)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionVendedorClassContaBancariaLoaded) 
               {
                  foreach(VendedorClass item in CollectionVendedorClassContaBancaria)
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
             case "NomeBanco":
                return this.NomeBanco;
             case "CodigoBanco":
                return this.CodigoBanco;
             case "NumeroConta":
                return this.NumeroConta;
             case "Agencia":
                return this.Agencia;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Identificacao":
                return this.Identificacao;
             case "AgenciaDv":
                return this.AgenciaDv;
             case "ContaDv":
                return this.ContaDv;
             case "NumeroCarteiraBoleto":
                return this.NumeroCarteiraBoleto;
             case "CodigoCarteiraBoleto":
                return this.CodigoCarteiraBoleto;
             case "IdCobrancaContaBancaria":
                return this.IdCobrancaContaBancaria;
             case "GeracaoAutomaticaBoleto":
                return this.GeracaoAutomaticaBoleto;
             case "GeracaoAutomaticaBoletoIntervalo":
                return this.GeracaoAutomaticaBoletoIntervalo;
             case "GeracaoAutomaticaRemessa":
                return this.GeracaoAutomaticaRemessa;
             case "GeracaoAutomaticaBoletoDiretorio":
                return this.GeracaoAutomaticaBoletoDiretorio;
             case "GeracaoAutomaticaRemessaDiretorio":
                return this.GeracaoAutomaticaRemessaDiretorio;
             case "CpfCnpj":
                return this.CpfCnpj;
             case "ChavePix":
                return this.ChavePix;
             case "JurosAntecipacao":
                return this.JurosAntecipacao;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionClienteClassContaBancariaLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionCobRemessaClassContaBancariaLoaded) 
               {
                  foreach(CobRemessaClass item in CollectionCobRemessaClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionConciliacaoBancariaClassContaBancariaLoaded) 
               {
                  foreach(ConciliacaoBancariaClass item in CollectionConciliacaoBancariaClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaPagarClassContaBancariaLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberClassContaBancariaLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberBoletoClassContaBancariaLoaded) 
               {
                  foreach(ContaReceberBoletoClass item in CollectionContaReceberBoletoClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaRecorrenteClassContaBancariaLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFormaPagamentoClassContaBancariaLoaded) 
               {
                  foreach(FormaPagamentoClass item in CollectionFormaPagamentoClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFornecedorClassContaBancariaLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemClassContaBancariaLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassContaBancariaLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionRepresentanteClassContaBancariaLoaded) 
               {
                  foreach(RepresentanteClass item in CollectionRepresentanteClassContaBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaOrigemLoaded) 
               {
                  foreach(TransferenciaBancariaClass item in CollectionTransferenciaBancariaClassContaBancariaOrigem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassContaBancariaDestinoLoaded) 
               {
                  foreach(TransferenciaBancariaClass item in CollectionTransferenciaBancariaClassContaBancariaDestino)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionVendedorClassContaBancariaLoaded) 
               {
                  foreach(VendedorClass item in CollectionVendedorClassContaBancaria)
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
                  command.CommandText += " COUNT(conta_bancaria.id_conta_bancaria) " ;
               }
               else
               {
               command.CommandText += "conta_bancaria.id_conta_bancaria, " ;
               command.CommandText += "conta_bancaria.cba_nome_banco, " ;
               command.CommandText += "conta_bancaria.cba_codigo_banco, " ;
               command.CommandText += "conta_bancaria.cba_numero_conta, " ;
               command.CommandText += "conta_bancaria.cba_agencia, " ;
               command.CommandText += "conta_bancaria.entity_uid, " ;
               command.CommandText += "conta_bancaria.version, " ;
               command.CommandText += "conta_bancaria.cba_identificacao, " ;
               command.CommandText += "conta_bancaria.cba_agencia_dv, " ;
               command.CommandText += "conta_bancaria.cba_conta_dv, " ;
               command.CommandText += "conta_bancaria.cba_numero_carteira_boleto, " ;
               command.CommandText += "conta_bancaria.cba_codigo_carteira_boleto, " ;
               command.CommandText += "conta_bancaria.cob_id_cobranca_conta_bancaria, " ;
               command.CommandText += "conta_bancaria.cob_geracao_automatica_boleto, " ;
               command.CommandText += "conta_bancaria.cob_geracao_automatica_boleto_intervalo, " ;
               command.CommandText += "conta_bancaria.cob_geracao_automatica_remessa, " ;
               command.CommandText += "conta_bancaria.cob_geracao_automatica_boleto_diretorio, " ;
               command.CommandText += "conta_bancaria.cob_geracao_automatica_remessa_diretorio, " ;
               command.CommandText += "conta_bancaria.cob_cpf_cnpj, " ;
               command.CommandText += "conta_bancaria.cob_chave_pix, " ;
               command.CommandText += "conta_bancaria.cob_juros_antecipacao " ;
               }
               command.CommandText += " FROM  conta_bancaria ";
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
                        orderByClause += " , cba_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(cba_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = conta_bancaria.id_acs_usuario_ultima_revisao ";
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
                     case "id_conta_bancaria":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_bancaria.id_conta_bancaria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_bancaria.id_conta_bancaria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cba_nome_banco":
                     case "NomeBanco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cba_nome_banco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cba_nome_banco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cba_codigo_banco":
                     case "CodigoBanco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cba_codigo_banco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cba_codigo_banco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cba_numero_conta":
                     case "NumeroConta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cba_numero_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cba_numero_conta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cba_agencia":
                     case "Agencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cba_agencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cba_agencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , conta_bancaria.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_bancaria.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cba_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cba_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cba_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cba_agencia_dv":
                     case "AgenciaDv":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cba_agencia_dv " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cba_agencia_dv) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cba_conta_dv":
                     case "ContaDv":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cba_conta_dv " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cba_conta_dv) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cba_numero_carteira_boleto":
                     case "NumeroCarteiraBoleto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cba_numero_carteira_boleto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cba_numero_carteira_boleto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cba_codigo_carteira_boleto":
                     case "CodigoCarteiraBoleto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cba_codigo_carteira_boleto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cba_codigo_carteira_boleto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_id_cobranca_conta_bancaria":
                     case "IdCobrancaContaBancaria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_bancaria.cob_id_cobranca_conta_bancaria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_bancaria.cob_id_cobranca_conta_bancaria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_geracao_automatica_boleto":
                     case "GeracaoAutomaticaBoleto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_bancaria.cob_geracao_automatica_boleto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_bancaria.cob_geracao_automatica_boleto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_geracao_automatica_boleto_intervalo":
                     case "GeracaoAutomaticaBoletoIntervalo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_bancaria.cob_geracao_automatica_boleto_intervalo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_bancaria.cob_geracao_automatica_boleto_intervalo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_geracao_automatica_remessa":
                     case "GeracaoAutomaticaRemessa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_bancaria.cob_geracao_automatica_remessa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_bancaria.cob_geracao_automatica_remessa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_geracao_automatica_boleto_diretorio":
                     case "GeracaoAutomaticaBoletoDiretorio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cob_geracao_automatica_boleto_diretorio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cob_geracao_automatica_boleto_diretorio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_geracao_automatica_remessa_diretorio":
                     case "GeracaoAutomaticaRemessaDiretorio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cob_geracao_automatica_remessa_diretorio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cob_geracao_automatica_remessa_diretorio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_cpf_cnpj":
                     case "CpfCnpj":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cob_cpf_cnpj " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cob_cpf_cnpj) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_chave_pix":
                     case "ChavePix":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria.cob_chave_pix " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria.cob_chave_pix) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_juros_antecipacao":
                     case "JurosAntecipacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_bancaria.cob_juros_antecipacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_bancaria.cob_juros_antecipacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cba_nome_banco")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cba_nome_banco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cba_nome_banco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cba_codigo_banco")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cba_codigo_banco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cba_codigo_banco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cba_numero_conta")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cba_numero_conta) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cba_numero_conta) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cba_agencia")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cba_agencia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cba_agencia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cba_identificacao")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cba_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cba_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cba_agencia_dv")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cba_agencia_dv) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cba_agencia_dv) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cba_conta_dv")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cba_conta_dv) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cba_conta_dv) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cba_numero_carteira_boleto")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cba_numero_carteira_boleto) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cba_numero_carteira_boleto) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cba_codigo_carteira_boleto")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cba_codigo_carteira_boleto) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cba_codigo_carteira_boleto) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cob_geracao_automatica_boleto_diretorio")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cob_geracao_automatica_boleto_diretorio) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cob_geracao_automatica_boleto_diretorio) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cob_geracao_automatica_remessa_diretorio")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cob_geracao_automatica_remessa_diretorio) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cob_geracao_automatica_remessa_diretorio) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cob_cpf_cnpj")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cob_cpf_cnpj) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cob_cpf_cnpj) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cob_chave_pix")) 
                        {
                           whereClause += " OR UPPER(conta_bancaria.cob_chave_pix) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_bancaria.cob_chave_pix) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_conta_bancaria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.id_conta_bancaria = :conta_bancaria_ID_1395 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_ID_1395", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeBanco" || parametro.FieldName == "cba_nome_banco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_nome_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_nome_banco LIKE :conta_bancaria_NomeBanco_3066 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_NomeBanco_3066", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoBanco" || parametro.FieldName == "cba_codigo_banco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_codigo_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_codigo_banco LIKE :conta_bancaria_CodigoBanco_1155 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_CodigoBanco_1155", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroConta" || parametro.FieldName == "cba_numero_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_numero_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_numero_conta LIKE :conta_bancaria_NumeroConta_5103 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_NumeroConta_5103", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Agencia" || parametro.FieldName == "cba_agencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_agencia LIKE :conta_bancaria_Agencia_4225 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_Agencia_4225", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  conta_bancaria.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.entity_uid LIKE :conta_bancaria_EntityUid_6512 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_EntityUid_6512", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  conta_bancaria.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.version = :conta_bancaria_Version_8878 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_Version_8878", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "cba_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_identificacao LIKE :conta_bancaria_Identificacao_2590 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_Identificacao_2590", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgenciaDv" || parametro.FieldName == "cba_agencia_dv")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_agencia_dv IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_agencia_dv LIKE :conta_bancaria_AgenciaDv_4589 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_AgenciaDv_4589", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaDv" || parametro.FieldName == "cba_conta_dv")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_conta_dv IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_conta_dv LIKE :conta_bancaria_ContaDv_7062 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_ContaDv_7062", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroCarteiraBoleto" || parametro.FieldName == "cba_numero_carteira_boleto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_numero_carteira_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_numero_carteira_boleto LIKE :conta_bancaria_NumeroCarteiraBoleto_2528 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_NumeroCarteiraBoleto_2528", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoCarteiraBoleto" || parametro.FieldName == "cba_codigo_carteira_boleto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_codigo_carteira_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_codigo_carteira_boleto LIKE :conta_bancaria_CodigoCarteiraBoleto_9522 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_CodigoCarteiraBoleto_9522", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdCobrancaContaBancaria" || parametro.FieldName == "cob_id_cobranca_conta_bancaria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_id_cobranca_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_id_cobranca_conta_bancaria = :conta_bancaria_IdCobrancaContaBancaria_447 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_IdCobrancaContaBancaria_447", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GeracaoAutomaticaBoleto" || parametro.FieldName == "cob_geracao_automatica_boleto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_boleto = :conta_bancaria_GeracaoAutomaticaBoleto_3957 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_GeracaoAutomaticaBoleto_3957", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GeracaoAutomaticaBoletoIntervalo" || parametro.FieldName == "cob_geracao_automatica_boleto_intervalo")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_boleto_intervalo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_boleto_intervalo = :conta_bancaria_GeracaoAutomaticaBoletoIntervalo_927 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_GeracaoAutomaticaBoletoIntervalo_927", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GeracaoAutomaticaRemessa" || parametro.FieldName == "cob_geracao_automatica_remessa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_remessa = :conta_bancaria_GeracaoAutomaticaRemessa_7998 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_GeracaoAutomaticaRemessa_7998", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GeracaoAutomaticaBoletoDiretorio" || parametro.FieldName == "cob_geracao_automatica_boleto_diretorio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_boleto_diretorio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_boleto_diretorio LIKE :conta_bancaria_GeracaoAutomaticaBoletoDiretorio_9177 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_GeracaoAutomaticaBoletoDiretorio_9177", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GeracaoAutomaticaRemessaDiretorio" || parametro.FieldName == "cob_geracao_automatica_remessa_diretorio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_remessa_diretorio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_remessa_diretorio LIKE :conta_bancaria_GeracaoAutomaticaRemessaDiretorio_4384 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_GeracaoAutomaticaRemessaDiretorio_4384", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfCnpj" || parametro.FieldName == "cob_cpf_cnpj")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_cpf_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_cpf_cnpj LIKE :conta_bancaria_CpfCnpj_1326 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_CpfCnpj_1326", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChavePix" || parametro.FieldName == "cob_chave_pix")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_chave_pix IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_chave_pix LIKE :conta_bancaria_ChavePix_3820 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_ChavePix_3820", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JurosAntecipacao" || parametro.FieldName == "cob_juros_antecipacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_juros_antecipacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_juros_antecipacao = :conta_bancaria_JurosAntecipacao_6215 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_JurosAntecipacao_6215", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeBancoExato" || parametro.FieldName == "NomeBancoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_nome_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_nome_banco LIKE :conta_bancaria_NomeBanco_7360 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_NomeBanco_7360", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoBancoExato" || parametro.FieldName == "CodigoBancoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_codigo_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_codigo_banco LIKE :conta_bancaria_CodigoBanco_7001 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_CodigoBanco_7001", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_bancaria.cba_numero_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_numero_conta LIKE :conta_bancaria_NumeroConta_8581 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_NumeroConta_8581", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_bancaria.cba_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_agencia LIKE :conta_bancaria_Agencia_9991 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_Agencia_9991", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_bancaria.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.entity_uid LIKE :conta_bancaria_EntityUid_3242 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_EntityUid_3242", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoExato" || parametro.FieldName == "IdentificacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_identificacao LIKE :conta_bancaria_Identificacao_9306 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_Identificacao_9306", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgenciaDvExato" || parametro.FieldName == "AgenciaDvExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_agencia_dv IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_agencia_dv LIKE :conta_bancaria_AgenciaDv_8258 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_AgenciaDv_8258", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaDvExato" || parametro.FieldName == "ContaDvExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_conta_dv IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_conta_dv LIKE :conta_bancaria_ContaDv_655 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_ContaDv_655", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroCarteiraBoletoExato" || parametro.FieldName == "NumeroCarteiraBoletoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_numero_carteira_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_numero_carteira_boleto LIKE :conta_bancaria_NumeroCarteiraBoleto_7362 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_NumeroCarteiraBoleto_7362", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoCarteiraBoletoExato" || parametro.FieldName == "CodigoCarteiraBoletoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cba_codigo_carteira_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cba_codigo_carteira_boleto LIKE :conta_bancaria_CodigoCarteiraBoleto_331 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_CodigoCarteiraBoleto_331", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GeracaoAutomaticaBoletoDiretorioExato" || parametro.FieldName == "GeracaoAutomaticaBoletoDiretorioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_boleto_diretorio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_boleto_diretorio LIKE :conta_bancaria_GeracaoAutomaticaBoletoDiretorio_4012 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_GeracaoAutomaticaBoletoDiretorio_4012", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GeracaoAutomaticaRemessaDiretorioExato" || parametro.FieldName == "GeracaoAutomaticaRemessaDiretorioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_remessa_diretorio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_geracao_automatica_remessa_diretorio LIKE :conta_bancaria_GeracaoAutomaticaRemessaDiretorio_5689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_GeracaoAutomaticaRemessaDiretorio_5689", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfCnpjExato" || parametro.FieldName == "CpfCnpjExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_cpf_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_cpf_cnpj LIKE :conta_bancaria_CpfCnpj_4730 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_CpfCnpj_4730", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChavePixExato" || parametro.FieldName == "ChavePixExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_bancaria.cob_chave_pix IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_bancaria.cob_chave_pix LIKE :conta_bancaria_ChavePix_8816 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_bancaria_ChavePix_8816", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ContaBancariaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ContaBancariaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ContaBancariaClass), Convert.ToInt32(read["id_conta_bancaria"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ContaBancariaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_conta_bancaria"]);
                     entidade.NomeBanco = (read["cba_nome_banco"] != DBNull.Value ? read["cba_nome_banco"].ToString() : null);
                     entidade.CodigoBanco = (read["cba_codigo_banco"] != DBNull.Value ? read["cba_codigo_banco"].ToString() : null);
                     entidade.NumeroConta = (read["cba_numero_conta"] != DBNull.Value ? read["cba_numero_conta"].ToString() : null);
                     entidade.Agencia = (read["cba_agencia"] != DBNull.Value ? read["cba_agencia"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Identificacao = (read["cba_identificacao"] != DBNull.Value ? read["cba_identificacao"].ToString() : null);
                     entidade.AgenciaDv = (read["cba_agencia_dv"] != DBNull.Value ? read["cba_agencia_dv"].ToString() : null);
                     entidade.ContaDv = (read["cba_conta_dv"] != DBNull.Value ? read["cba_conta_dv"].ToString() : null);
                     entidade.NumeroCarteiraBoleto = (read["cba_numero_carteira_boleto"] != DBNull.Value ? read["cba_numero_carteira_boleto"].ToString() : null);
                     entidade.CodigoCarteiraBoleto = (read["cba_codigo_carteira_boleto"] != DBNull.Value ? read["cba_codigo_carteira_boleto"].ToString() : null);
                     entidade.IdCobrancaContaBancaria = (read["cob_id_cobranca_conta_bancaria"] != DBNull.Value ? (long?)Convert.ToInt64(read["cob_id_cobranca_conta_bancaria"]) : null);
                     entidade.GeracaoAutomaticaBoleto = Convert.ToBoolean(read["cob_geracao_automatica_boleto"]);
                     entidade.GeracaoAutomaticaBoletoIntervalo = (int)read["cob_geracao_automatica_boleto_intervalo"];
                     entidade.GeracaoAutomaticaRemessa = Convert.ToBoolean(read["cob_geracao_automatica_remessa"]);
                     entidade.GeracaoAutomaticaBoletoDiretorio = (read["cob_geracao_automatica_boleto_diretorio"] != DBNull.Value ? read["cob_geracao_automatica_boleto_diretorio"].ToString() : null);
                     entidade.GeracaoAutomaticaRemessaDiretorio = (read["cob_geracao_automatica_remessa_diretorio"] != DBNull.Value ? read["cob_geracao_automatica_remessa_diretorio"].ToString() : null);
                     entidade.CpfCnpj = (read["cob_cpf_cnpj"] != DBNull.Value ? read["cob_cpf_cnpj"].ToString() : null);
                     entidade.ChavePix = (read["cob_chave_pix"] != DBNull.Value ? read["cob_chave_pix"].ToString() : null);
                     entidade.JurosAntecipacao = (double)read["cob_juros_antecipacao"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ContaBancariaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
