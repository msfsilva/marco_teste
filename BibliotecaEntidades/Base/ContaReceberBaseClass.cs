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
using IWTNF.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("conta_receber","cor")]
     public class ContaReceberBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ContaReceberClass";
protected const string ErroDelete = "Erro ao excluir o ContaReceberClass  ";
protected const string ErroSave = "Erro ao salvar o ContaReceberClass.";
protected const string ErroCollectionLancamentoClassContaReceber = "Erro ao carregar a coleção de LancamentoClass.";
protected const string ErroCollectionMovimentoCaixaClassContaReceber = "Erro ao carregar a coleção de MovimentoCaixaClass.";
protected const string ErroHistoricoObrigatorio = "O campo Historico é obrigatório";
protected const string ErroHistoricoComprimento = "O campo Historico deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
protected const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ContaReceberClass.";
protected const string MensagemUtilizadoCollectionLancamentoClassContaReceber =  "A entidade ContaReceberClass está sendo utilizada nos seguintes LancamentoClass:";
protected const string MensagemUtilizadoCollectionMovimentoCaixaClassContaReceber =  "A entidade ContaReceberClass está sendo utilizada nos seguintes MovimentoCaixaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ContaReceberClass está sendo utilizada.";
#endregion
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

       protected IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _valueNfPrincipal;
        [Column("id_nf_principal", "nf_principal", "id_nf_principal")]
       public virtual IWTNF.Entidades.Entidades.NfPrincipalClass NfPrincipal
        { 
           get {                 return this._valueNfPrincipal; } 
           set 
           { 
                if (this._valueNfPrincipal == value)return;
                 this._valueNfPrincipal = value; 
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

       protected string _numDocumentoOriginal{get;private set;}
       private string _numDocumentoOriginalCommited{get; set;}
        private string _valueNumDocumento;
         [Column("cor_num_documento")]
        public virtual string NumDocumento
         { 
            get { return this._valueNumDocumento; } 
            set 
            { 
                if (this._valueNumDocumento == value)return;
                 this._valueNumDocumento = value; 
            } 
        } 

       protected DateTime _dataVencimentoOriginal{get;private set;}
       private DateTime _dataVencimentoOriginalCommited{get; set;}
        private DateTime _valueDataVencimento;
         [Column("cor_data_vencimento")]
        public virtual DateTime DataVencimento
         { 
            get { return this._valueDataVencimento; } 
            set 
            { 
                if (this._valueDataVencimento == value)return;
                 this._valueDataVencimento = value; 
            } 
        } 

       protected double _valorOriginal{get;private set;}
       private double _valorOriginalCommited{get; set;}
        private double _valueValor;
         [Column("cor_valor")]
        public virtual double Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
            } 
        } 

       protected DateTime? _dataPagamentoOriginal{get;private set;}
       private DateTime? _dataPagamentoOriginalCommited{get; set;}
        private DateTime? _valueDataPagamento;
         [Column("cor_data_pagamento")]
        public virtual DateTime? DataPagamento
         { 
            get { return this._valueDataPagamento; } 
            set 
            { 
                if (this._valueDataPagamento == value)return;
                 this._valueDataPagamento = value; 
            } 
        } 

       protected double? _valorPagoOriginal{get;private set;}
       private double? _valorPagoOriginalCommited{get; set;}
        private double? _valueValorPago;
         [Column("cor_valor_pago")]
        public virtual double? ValorPago
         { 
            get { return this._valueValorPago; } 
            set 
            { 
                if (this._valueValorPago == value)return;
                 this._valueValorPago = value; 
            } 
        } 

       protected string _historicoOriginal{get;private set;}
       private string _historicoOriginalCommited{get; set;}
        private string _valueHistorico;
         [Column("cor_historico")]
        public virtual string Historico
         { 
            get { return this._valueHistorico; } 
            set 
            { 
                if (this._valueHistorico == value)return;
                 this._valueHistorico = value; 
            } 
        } 

       protected DateTime _dataEmissaoOriginal{get;private set;}
       private DateTime _dataEmissaoOriginalCommited{get; set;}
        private DateTime _valueDataEmissao;
         [Column("cor_data_emissao")]
        public virtual DateTime DataEmissao
         { 
            get { return this._valueDataEmissao; } 
            set 
            { 
                if (this._valueDataEmissao == value)return;
                 this._valueDataEmissao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ConciliacaoBancariaClass _conciliacaoBancariaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ConciliacaoBancariaClass _conciliacaoBancariaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ConciliacaoBancariaClass _valueConciliacaoBancaria;
        [Column("id_conciliacao_bancaria", "conciliacao_bancaria", "id_conciliacao_bancaria")]
       public virtual BibliotecaEntidades.Entidades.ConciliacaoBancariaClass ConciliacaoBancaria
        { 
           get {                 return this._valueConciliacaoBancaria; } 
           set 
           { 
                if (this._valueConciliacaoBancaria == value)return;
                 this._valueConciliacaoBancaria = value; 
           } 
       } 

       protected double _descontoOriginal{get;private set;}
       private double _descontoOriginalCommited{get; set;}
        private double _valueDesconto;
         [Column("cor_desconto")]
        public virtual double Desconto
         { 
            get { return this._valueDesconto; } 
            set 
            { 
                if (this._valueDesconto == value)return;
                 this._valueDesconto = value; 
            } 
        } 

       protected double _acrescimoOriginal{get;private set;}
       private double _acrescimoOriginalCommited{get; set;}
        private double _valueAcrescimo;
         [Column("cor_acrescimo")]
        public virtual double Acrescimo
         { 
            get { return this._valueAcrescimo; } 
            set 
            { 
                if (this._valueAcrescimo == value)return;
                 this._valueAcrescimo = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ContaRecorrenteClass _contaRecorrenteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ContaRecorrenteClass _contaRecorrenteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ContaRecorrenteClass _valueContaRecorrente;
        [Column("id_conta_recorrente", "conta_recorrente", "id_conta_recorrente")]
       public virtual BibliotecaEntidades.Entidades.ContaRecorrenteClass ContaRecorrente
        { 
           get {                 return this._valueContaRecorrente; } 
           set 
           { 
                if (this._valueContaRecorrente == value)return;
                 this._valueContaRecorrente = value; 
           } 
       } 

       protected bool _contaEmRevisaoOriginal{get;private set;}
       private bool _contaEmRevisaoOriginalCommited{get; set;}
        private bool _valueContaEmRevisao;
         [Column("cor_conta_em_revisao")]
        public virtual bool ContaEmRevisao
         { 
            get { return this._valueContaEmRevisao; } 
            set 
            { 
                if (this._valueContaEmRevisao == value)return;
                 this._valueContaEmRevisao = value; 
            } 
        } 

       protected DateTime _dataCadastroOriginal{get;private set;}
       private DateTime _dataCadastroOriginalCommited{get; set;}
        private DateTime _valueDataCadastro;
         [Column("cor_data_cadastro")]
        public virtual DateTime DataCadastro
         { 
            get { return this._valueDataCadastro; } 
            set 
            { 
                if (this._valueDataCadastro == value)return;
                 this._valueDataCadastro = value; 
            } 
        } 

       protected string _justificativaEstornoOriginal{get;private set;}
       private string _justificativaEstornoOriginalCommited{get; set;}
        private string _valueJustificativaEstorno;
         [Column("cor_justificativa_estorno")]
        public virtual string JustificativaEstorno
         { 
            get { return this._valueJustificativaEstorno; } 
            set 
            { 
                if (this._valueJustificativaEstorno == value)return;
                 this._valueJustificativaEstorno = value; 
            } 
        } 

       protected int? _idUsuarioEstornoOriginal{get;private set;}
       private int? _idUsuarioEstornoOriginalCommited{get; set;}
        private int? _valueIdUsuarioEstorno;
         [Column("id_usuario_estorno")]
        public virtual int? IdUsuarioEstorno
         { 
            get { return this._valueIdUsuarioEstorno; } 
            set 
            { 
                if (this._valueIdUsuarioEstorno == value)return;
                 this._valueIdUsuarioEstorno = value; 
            } 
        } 

       protected DateTime? _dataHoraEstornoOriginal{get;private set;}
       private DateTime? _dataHoraEstornoOriginalCommited{get; set;}
        private DateTime? _valueDataHoraEstorno;
         [Column("cor_data_hora_estorno")]
        public virtual DateTime? DataHoraEstorno
         { 
            get { return this._valueDataHoraEstorno; } 
            set 
            { 
                if (this._valueDataHoraEstorno == value)return;
                 this._valueDataHoraEstorno = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.FuncionarioClass _funcionarioOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FuncionarioClass _funcionarioOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FuncionarioClass _valueFuncionario;
        [Column("id_funcionario", "funcionario", "id_funcionario")]
       public virtual BibliotecaEntidades.Entidades.FuncionarioClass Funcionario
        { 
           get {                 return this._valueFuncionario; } 
           set 
           { 
                if (this._valueFuncionario == value)return;
                 this._valueFuncionario = value; 
           } 
       } 

       protected bool _comissaoGeradaOriginal{get;private set;}
       private bool _comissaoGeradaOriginalCommited{get; set;}
        private bool _valueComissaoGerada;
         [Column("cor_comissao_gerada")]
        public virtual bool ComissaoGerada
         { 
            get { return this._valueComissaoGerada; } 
            set 
            { 
                if (this._valueComissaoGerada == value)return;
                 this._valueComissaoGerada = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ContaReceberBoletoClass _contaReceberBoletoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ContaReceberBoletoClass _contaReceberBoletoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ContaReceberBoletoClass _valueContaReceberBoleto;
        [Column("id_conta_receber_boleto", "conta_receber_boleto", "id_conta_receber_boleto")]
       public virtual BibliotecaEntidades.Entidades.ContaReceberBoletoClass ContaReceberBoleto
        { 
           get {                 return this._valueContaReceberBoleto; } 
           set 
           { 
                if (this._valueContaReceberBoleto == value)return;
                 this._valueContaReceberBoleto = value; 
           } 
       } 

       protected long? _idCobrancaBoletoOriginal{get;private set;}
       private long? _idCobrancaBoletoOriginalCommited{get; set;}
        private long? _valueIdCobrancaBoleto;
         [Column("id_cobranca_boleto")]
        public virtual long? IdCobrancaBoleto
         { 
            get { return this._valueIdCobrancaBoleto; } 
            set 
            { 
                if (this._valueIdCobrancaBoleto == value)return;
                 this._valueIdCobrancaBoleto = value; 
            } 
        } 

       protected string _cobrancaNossoNumeroOriginal{get;private set;}
       private string _cobrancaNossoNumeroOriginalCommited{get; set;}
        private string _valueCobrancaNossoNumero;
         [Column("cor_cobranca_nosso_numero")]
        public virtual string CobrancaNossoNumero
         { 
            get { return this._valueCobrancaNossoNumero; } 
            set 
            { 
                if (this._valueCobrancaNossoNumero == value)return;
                 this._valueCobrancaNossoNumero = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.AgrupadorContaClass _agrupadorContaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.AgrupadorContaClass _agrupadorContaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.AgrupadorContaClass _valueAgrupadorConta;
        [Column("id_agrupador_conta", "agrupador_conta", "id_agrupador_conta")]
       public virtual BibliotecaEntidades.Entidades.AgrupadorContaClass AgrupadorConta
        { 
           get {                 return this._valueAgrupadorConta; } 
           set 
           { 
                if (this._valueAgrupadorConta == value)return;
                 this._valueAgrupadorConta = value; 
           } 
       } 

       protected long _idDevedorOriginal{get;private set;}
       private long _idDevedorOriginalCommited{get; set;}
        private long _valueIdDevedor;
         [Column("id_devedor")]
        public virtual long IdDevedor
         { 
            get { return this._valueIdDevedor; } 
            set 
            { 
                if (this._valueIdDevedor == value)return;
                 this._valueIdDevedor = value; 
            } 
        } 

       protected double? _tarifaCobrancaOriginal{get;private set;}
       private double? _tarifaCobrancaOriginalCommited{get; set;}
        private double? _valueTarifaCobranca;
         [Column("cor_tarifa_cobranca")]
        public virtual double? TarifaCobranca
         { 
            get { return this._valueTarifaCobranca; } 
            set 
            { 
                if (this._valueTarifaCobranca == value)return;
                 this._valueTarifaCobranca = value; 
            } 
        } 

       protected double _taxasOriginal{get;private set;}
       private double _taxasOriginalCommited{get; set;}
        private double _valueTaxas;
         [Column("cor_taxas")]
        public virtual double Taxas
         { 
            get { return this._valueTaxas; } 
            set 
            { 
                if (this._valueTaxas == value)return;
                 this._valueTaxas = value; 
            } 
        } 

       protected string _usuarioBaixaOriginal{get;private set;}
       private string _usuarioBaixaOriginalCommited{get; set;}
        private string _valueUsuarioBaixa;
         [Column("cor_usuario_baixa")]
        public virtual string UsuarioBaixa
         { 
            get { return this._valueUsuarioBaixa; } 
            set 
            { 
                if (this._valueUsuarioBaixa == value)return;
                 this._valueUsuarioBaixa = value; 
            } 
        } 

       protected DateTime? _dataBaixaOriginal{get;private set;}
       private DateTime? _dataBaixaOriginalCommited{get; set;}
        private DateTime? _valueDataBaixa;
         [Column("cor_data_baixa")]
        public virtual DateTime? DataBaixa
         { 
            get { return this._valueDataBaixa; } 
            set 
            { 
                if (this._valueDataBaixa == value)return;
                 this._valueDataBaixa = value; 
            } 
        } 

       protected string _descricaoMeioPagtoOutrosOriginal{get;private set;}
       private string _descricaoMeioPagtoOutrosOriginalCommited{get; set;}
        private string _valueDescricaoMeioPagtoOutros;
         [Column("cor_descricao_meio_pagto_outros")]
        public virtual string DescricaoMeioPagtoOutros
         { 
            get { return this._valueDescricaoMeioPagtoOutros; } 
            set 
            { 
                if (this._valueDescricaoMeioPagtoOutros == value)return;
                 this._valueDescricaoMeioPagtoOutros = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.MeioPagamentoClass _meioPagamentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MeioPagamentoClass _meioPagamentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MeioPagamentoClass _valueMeioPagamento;
        [Column("id_meio_pagamento", "meio_pagamento", "id_meio_pagamento")]
       public virtual BibliotecaEntidades.Entidades.MeioPagamentoClass MeioPagamento
        { 
           get {                 return this._valueMeioPagamento; } 
           set 
           { 
                if (this._valueMeioPagamento == value)return;
                 this._valueMeioPagamento = value; 
           } 
       } 

       private List<long> _collectionLancamentoClassContaReceberOriginal;
       private List<Entidades.LancamentoClass > _collectionLancamentoClassContaReceberRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLancamentoClassContaReceberLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLancamentoClassContaReceberChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLancamentoClassContaReceberCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LancamentoClass> _valueCollectionLancamentoClassContaReceber { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LancamentoClass> CollectionLancamentoClassContaReceber 
       { 
           get { if(!_valueCollectionLancamentoClassContaReceberLoaded && !this.DisableLoadCollection){this.LoadCollectionLancamentoClassContaReceber();}
return this._valueCollectionLancamentoClassContaReceber; } 
           set 
           { 
               this._valueCollectionLancamentoClassContaReceber = value; 
               this._valueCollectionLancamentoClassContaReceberLoaded = true; 
           } 
       } 

       private List<long> _collectionMovimentoCaixaClassContaReceberOriginal;
       private List<Entidades.MovimentoCaixaClass > _collectionMovimentoCaixaClassContaReceberRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMovimentoCaixaClassContaReceberLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMovimentoCaixaClassContaReceberChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMovimentoCaixaClassContaReceberCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MovimentoCaixaClass> _valueCollectionMovimentoCaixaClassContaReceber { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MovimentoCaixaClass> CollectionMovimentoCaixaClassContaReceber 
       { 
           get { if(!_valueCollectionMovimentoCaixaClassContaReceberLoaded && !this.DisableLoadCollection){this.LoadCollectionMovimentoCaixaClassContaReceber();}
return this._valueCollectionMovimentoCaixaClassContaReceber; } 
           set 
           { 
               this._valueCollectionMovimentoCaixaClassContaReceber = value; 
               this._valueCollectionMovimentoCaixaClassContaReceberLoaded = true; 
           } 
       } 

        public ContaReceberBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Valor = 0;
           this.DataEmissao = Configurations.DataIndependenteClass.GetData();
           this.Desconto = 0;
           this.Acrescimo = 0;
           this.ContaEmRevisao = false;
           this.DataCadastro = Configurations.DataIndependenteClass.GetData();
           this.ComissaoGerada = false;
           this.Taxas = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ContaReceberClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ContaReceberClass) GetEntity(typeof(ContaReceberClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionLancamentoClassContaReceberChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLancamentoClassContaReceberChanged = true;
                  _valueCollectionLancamentoClassContaReceberCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLancamentoClassContaReceberChanged = true; 
                  _valueCollectionLancamentoClassContaReceberCommitedChanged = true;
                 foreach (Entidades.LancamentoClass item in e.OldItems) 
                 { 
                     _collectionLancamentoClassContaReceberRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLancamentoClassContaReceberChanged = true; 
                  _valueCollectionLancamentoClassContaReceberCommitedChanged = true;
                 foreach (Entidades.LancamentoClass item in _valueCollectionLancamentoClassContaReceber) 
                 { 
                     _collectionLancamentoClassContaReceberRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLancamentoClassContaReceber()
         {
            try
            {
                 ObservableCollection<Entidades.LancamentoClass> oc;
                _valueCollectionLancamentoClassContaReceberChanged = false;
                 _valueCollectionLancamentoClassContaReceberCommitedChanged = false;
                _collectionLancamentoClassContaReceberRemovidos = new List<Entidades.LancamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LancamentoClass>();
                }
                else{ 
                   Entidades.LancamentoClass search = new Entidades.LancamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LancamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaReceber", this),                     }                       ).Cast<Entidades.LancamentoClass>().ToList());
                 }
                 _valueCollectionLancamentoClassContaReceber = new BindingList<Entidades.LancamentoClass>(oc); 
                 _collectionLancamentoClassContaReceberOriginal= (from a in _valueCollectionLancamentoClassContaReceber select a.ID).ToList();
                 _valueCollectionLancamentoClassContaReceberLoaded = true;
                 oc.CollectionChanged += CollectionLancamentoClassContaReceberChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLancamentoClassContaReceber+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMovimentoCaixaClassContaReceberChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMovimentoCaixaClassContaReceberChanged = true;
                  _valueCollectionMovimentoCaixaClassContaReceberCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMovimentoCaixaClassContaReceberChanged = true; 
                  _valueCollectionMovimentoCaixaClassContaReceberCommitedChanged = true;
                 foreach (Entidades.MovimentoCaixaClass item in e.OldItems) 
                 { 
                     _collectionMovimentoCaixaClassContaReceberRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMovimentoCaixaClassContaReceberChanged = true; 
                  _valueCollectionMovimentoCaixaClassContaReceberCommitedChanged = true;
                 foreach (Entidades.MovimentoCaixaClass item in _valueCollectionMovimentoCaixaClassContaReceber) 
                 { 
                     _collectionMovimentoCaixaClassContaReceberRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMovimentoCaixaClassContaReceber()
         {
            try
            {
                 ObservableCollection<Entidades.MovimentoCaixaClass> oc;
                _valueCollectionMovimentoCaixaClassContaReceberChanged = false;
                 _valueCollectionMovimentoCaixaClassContaReceberCommitedChanged = false;
                _collectionMovimentoCaixaClassContaReceberRemovidos = new List<Entidades.MovimentoCaixaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MovimentoCaixaClass>();
                }
                else{ 
                   Entidades.MovimentoCaixaClass search = new Entidades.MovimentoCaixaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MovimentoCaixaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaReceber", this),                     }                       ).Cast<Entidades.MovimentoCaixaClass>().ToList());
                 }
                 _valueCollectionMovimentoCaixaClassContaReceber = new BindingList<Entidades.MovimentoCaixaClass>(oc); 
                 _collectionMovimentoCaixaClassContaReceberOriginal= (from a in _valueCollectionMovimentoCaixaClassContaReceber select a.ID).ToList();
                 _valueCollectionMovimentoCaixaClassContaReceberLoaded = true;
                 oc.CollectionChanged += CollectionMovimentoCaixaClassContaReceberChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMovimentoCaixaClassContaReceber+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Historico))
                {
                    throw new Exception(ErroHistoricoObrigatorio);
                }
                if (Historico.Length >255)
                {
                    throw new Exception( ErroHistoricoComprimento);
                }
                if ( _valueCentroCustoLucro == null)
                {
                    throw new Exception(ErroCentroCustoLucroObrigatorio);
                }
                if ( _valueContaBancaria == null)
                {
                    throw new Exception(ErroContaBancariaObrigatorio);
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
                    "  public.conta_receber  " +
                    "WHERE " +
                    "  id_conta_receber = :id";
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
                        "  public.conta_receber   " +
                        "SET  " + 
                        "  id_tipo_pagamento = :id_tipo_pagamento, " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  cor_num_documento = :cor_num_documento, " + 
                        "  cor_data_vencimento = :cor_data_vencimento, " + 
                        "  cor_valor = :cor_valor, " + 
                        "  cor_data_pagamento = :cor_data_pagamento, " + 
                        "  cor_valor_pago = :cor_valor_pago, " + 
                        "  cor_historico = :cor_historico, " + 
                        "  cor_data_emissao = :cor_data_emissao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_conciliacao_bancaria = :id_conciliacao_bancaria, " + 
                        "  cor_desconto = :cor_desconto, " + 
                        "  cor_acrescimo = :cor_acrescimo, " + 
                        "  id_conta_recorrente = :id_conta_recorrente, " + 
                        "  cor_conta_em_revisao = :cor_conta_em_revisao, " + 
                        "  cor_data_cadastro = :cor_data_cadastro, " + 
                        "  cor_justificativa_estorno = :cor_justificativa_estorno, " + 
                        "  id_usuario_estorno = :id_usuario_estorno, " + 
                        "  cor_data_hora_estorno = :cor_data_hora_estorno, " + 
                        "  id_funcionario = :id_funcionario, " + 
                        "  cor_comissao_gerada = :cor_comissao_gerada, " + 
                        "  id_conta_receber_boleto = :id_conta_receber_boleto, " + 
                        "  id_cobranca_boleto = :id_cobranca_boleto, " + 
                        "  cor_cobranca_nosso_numero = :cor_cobranca_nosso_numero, " + 
                        "  id_agrupador_conta = :id_agrupador_conta, " + 
                        "  id_devedor = :id_devedor, " + 
                        "  cor_tarifa_cobranca = :cor_tarifa_cobranca, " + 
                        "  cor_taxas = :cor_taxas, " + 
                        "  cor_usuario_baixa = :cor_usuario_baixa, " + 
                        "  cor_data_baixa = :cor_data_baixa, " + 
                        "  cor_descricao_meio_pagto_outros = :cor_descricao_meio_pagto_outros, " + 
                        "  id_meio_pagamento = :id_meio_pagamento "+
                        "WHERE  " +
                        "  id_conta_receber = :id " +
                        "RETURNING id_conta_receber;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.conta_receber " +
                        "( " +
                        "  id_tipo_pagamento , " + 
                        "  id_nf_principal , " + 
                        "  id_cliente , " + 
                        "  id_centro_custo_lucro , " + 
                        "  id_conta_bancaria , " + 
                        "  cor_num_documento , " + 
                        "  cor_data_vencimento , " + 
                        "  cor_valor , " + 
                        "  cor_data_pagamento , " + 
                        "  cor_valor_pago , " + 
                        "  cor_historico , " + 
                        "  cor_data_emissao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_conciliacao_bancaria , " + 
                        "  cor_desconto , " + 
                        "  cor_acrescimo , " + 
                        "  id_conta_recorrente , " + 
                        "  cor_conta_em_revisao , " + 
                        "  cor_data_cadastro , " + 
                        "  cor_justificativa_estorno , " + 
                        "  id_usuario_estorno , " + 
                        "  cor_data_hora_estorno , " + 
                        "  id_funcionario , " + 
                        "  cor_comissao_gerada , " + 
                        "  id_conta_receber_boleto , " + 
                        "  id_cobranca_boleto , " + 
                        "  cor_cobranca_nosso_numero , " + 
                        "  id_agrupador_conta , " + 
                        "  id_devedor , " + 
                        "  cor_tarifa_cobranca , " + 
                        "  cor_taxas , " + 
                        "  cor_usuario_baixa , " + 
                        "  cor_data_baixa , " + 
                        "  cor_descricao_meio_pagto_outros , " + 
                        "  id_meio_pagamento  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_tipo_pagamento , " + 
                        "  :id_nf_principal , " + 
                        "  :id_cliente , " + 
                        "  :id_centro_custo_lucro , " + 
                        "  :id_conta_bancaria , " + 
                        "  :cor_num_documento , " + 
                        "  :cor_data_vencimento , " + 
                        "  :cor_valor , " + 
                        "  :cor_data_pagamento , " + 
                        "  :cor_valor_pago , " + 
                        "  :cor_historico , " + 
                        "  :cor_data_emissao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_conciliacao_bancaria , " + 
                        "  :cor_desconto , " + 
                        "  :cor_acrescimo , " + 
                        "  :id_conta_recorrente , " + 
                        "  :cor_conta_em_revisao , " + 
                        "  :cor_data_cadastro , " + 
                        "  :cor_justificativa_estorno , " + 
                        "  :id_usuario_estorno , " + 
                        "  :cor_data_hora_estorno , " + 
                        "  :id_funcionario , " + 
                        "  :cor_comissao_gerada , " + 
                        "  :id_conta_receber_boleto , " + 
                        "  :id_cobranca_boleto , " + 
                        "  :cor_cobranca_nosso_numero , " + 
                        "  :id_agrupador_conta , " + 
                        "  :id_devedor , " + 
                        "  :cor_tarifa_cobranca , " + 
                        "  :cor_taxas , " + 
                        "  :cor_usuario_baixa , " + 
                        "  :cor_data_baixa , " + 
                        "  :cor_descricao_meio_pagto_outros , " + 
                        "  :id_meio_pagamento  "+
                        ")RETURNING id_conta_receber;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tipo_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.TipoPagamento==null ? (object) DBNull.Value : this.TipoPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_num_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_data_vencimento", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataVencimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_data_pagamento", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataPagamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_valor_pago", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorPago ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_historico", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Historico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_data_emissao", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conciliacao_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ConciliacaoBancaria==null ? (object) DBNull.Value : this.ConciliacaoBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_desconto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Desconto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_acrescimo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Acrescimo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_recorrente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaRecorrente==null ? (object) DBNull.Value : this.ContaRecorrente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_conta_em_revisao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ContaEmRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_data_cadastro", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCadastro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_justificativa_estorno", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JustificativaEstorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_usuario_estorno", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdUsuarioEstorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_data_hora_estorno", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataHoraEstorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_funcionario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Funcionario==null ? (object) DBNull.Value : this.Funcionario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_comissao_gerada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ComissaoGerada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_receber_boleto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaReceberBoleto==null ? (object) DBNull.Value : this.ContaReceberBoleto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cobranca_boleto", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdCobrancaBoleto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_cobranca_nosso_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CobrancaNossoNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_agrupador_conta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AgrupadorConta==null ? (object) DBNull.Value : this.AgrupadorConta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_devedor", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdDevedor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_tarifa_cobranca", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TarifaCobranca ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_taxas", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Taxas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_usuario_baixa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UsuarioBaixa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_data_baixa", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataBaixa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cor_descricao_meio_pagto_outros", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoMeioPagtoOutros ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_meio_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.MeioPagamento==null ? (object) DBNull.Value : this.MeioPagamento.ID;

 
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
 if (CollectionLancamentoClassContaReceber.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLancamentoClassContaReceber+"\r\n";
                foreach (Entidades.LancamentoClass tmp in CollectionLancamentoClassContaReceber)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMovimentoCaixaClassContaReceber.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMovimentoCaixaClassContaReceber+"\r\n";
                foreach (Entidades.MovimentoCaixaClass tmp in CollectionMovimentoCaixaClassContaReceber)
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
        public static ContaReceberClass CopiarEntidade(ContaReceberClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ContaReceberClass toRet = new ContaReceberClass(usuario,conn);
 toRet.TipoPagamento= entidadeCopiar.TipoPagamento;
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.NumDocumento= entidadeCopiar.NumDocumento;
 toRet.DataVencimento= entidadeCopiar.DataVencimento;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.DataPagamento= entidadeCopiar.DataPagamento;
 toRet.ValorPago= entidadeCopiar.ValorPago;
 toRet.Historico= entidadeCopiar.Historico;
 toRet.DataEmissao= entidadeCopiar.DataEmissao;
 toRet.ConciliacaoBancaria= entidadeCopiar.ConciliacaoBancaria;
 toRet.Desconto= entidadeCopiar.Desconto;
 toRet.Acrescimo= entidadeCopiar.Acrescimo;
 toRet.ContaRecorrente= entidadeCopiar.ContaRecorrente;
 toRet.ContaEmRevisao= entidadeCopiar.ContaEmRevisao;
 toRet.DataCadastro= entidadeCopiar.DataCadastro;
 toRet.JustificativaEstorno= entidadeCopiar.JustificativaEstorno;
 toRet.IdUsuarioEstorno= entidadeCopiar.IdUsuarioEstorno;
 toRet.DataHoraEstorno= entidadeCopiar.DataHoraEstorno;
 toRet.Funcionario= entidadeCopiar.Funcionario;
 toRet.ComissaoGerada= entidadeCopiar.ComissaoGerada;
 toRet.ContaReceberBoleto= entidadeCopiar.ContaReceberBoleto;
 toRet.IdCobrancaBoleto= entidadeCopiar.IdCobrancaBoleto;
 toRet.CobrancaNossoNumero= entidadeCopiar.CobrancaNossoNumero;
 toRet.AgrupadorConta= entidadeCopiar.AgrupadorConta;
 toRet.IdDevedor= entidadeCopiar.IdDevedor;
 toRet.TarifaCobranca= entidadeCopiar.TarifaCobranca;
 toRet.Taxas= entidadeCopiar.Taxas;
 toRet.UsuarioBaixa= entidadeCopiar.UsuarioBaixa;
 toRet.DataBaixa= entidadeCopiar.DataBaixa;
 toRet.DescricaoMeioPagtoOutros= entidadeCopiar.DescricaoMeioPagtoOutros;
 toRet.MeioPagamento= entidadeCopiar.MeioPagamento;

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
       _tipoPagamentoOriginal = TipoPagamento;
       _tipoPagamentoOriginalCommited = _tipoPagamentoOriginal;
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _numDocumentoOriginal = NumDocumento;
       _numDocumentoOriginalCommited = _numDocumentoOriginal;
       _dataVencimentoOriginal = DataVencimento;
       _dataVencimentoOriginalCommited = _dataVencimentoOriginal;
       _valorOriginal = Valor;
       _valorOriginalCommited = _valorOriginal;
       _dataPagamentoOriginal = DataPagamento;
       _dataPagamentoOriginalCommited = _dataPagamentoOriginal;
       _valorPagoOriginal = ValorPago;
       _valorPagoOriginalCommited = _valorPagoOriginal;
       _historicoOriginal = Historico;
       _historicoOriginalCommited = _historicoOriginal;
       _dataEmissaoOriginal = DataEmissao;
       _dataEmissaoOriginalCommited = _dataEmissaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _conciliacaoBancariaOriginal = ConciliacaoBancaria;
       _conciliacaoBancariaOriginalCommited = _conciliacaoBancariaOriginal;
       _descontoOriginal = Desconto;
       _descontoOriginalCommited = _descontoOriginal;
       _acrescimoOriginal = Acrescimo;
       _acrescimoOriginalCommited = _acrescimoOriginal;
       _contaRecorrenteOriginal = ContaRecorrente;
       _contaRecorrenteOriginalCommited = _contaRecorrenteOriginal;
       _contaEmRevisaoOriginal = ContaEmRevisao;
       _contaEmRevisaoOriginalCommited = _contaEmRevisaoOriginal;
       _dataCadastroOriginal = DataCadastro;
       _dataCadastroOriginalCommited = _dataCadastroOriginal;
       _justificativaEstornoOriginal = JustificativaEstorno;
       _justificativaEstornoOriginalCommited = _justificativaEstornoOriginal;
       _idUsuarioEstornoOriginal = IdUsuarioEstorno;
       _idUsuarioEstornoOriginalCommited = _idUsuarioEstornoOriginal;
       _dataHoraEstornoOriginal = DataHoraEstorno;
       _dataHoraEstornoOriginalCommited = _dataHoraEstornoOriginal;
       _funcionarioOriginal = Funcionario;
       _funcionarioOriginalCommited = _funcionarioOriginal;
       _comissaoGeradaOriginal = ComissaoGerada;
       _comissaoGeradaOriginalCommited = _comissaoGeradaOriginal;
       _contaReceberBoletoOriginal = ContaReceberBoleto;
       _contaReceberBoletoOriginalCommited = _contaReceberBoletoOriginal;
       _idCobrancaBoletoOriginal = IdCobrancaBoleto;
       _idCobrancaBoletoOriginalCommited = _idCobrancaBoletoOriginal;
       _cobrancaNossoNumeroOriginal = CobrancaNossoNumero;
       _cobrancaNossoNumeroOriginalCommited = _cobrancaNossoNumeroOriginal;
       _agrupadorContaOriginal = AgrupadorConta;
       _agrupadorContaOriginalCommited = _agrupadorContaOriginal;
       _idDevedorOriginal = IdDevedor;
       _idDevedorOriginalCommited = _idDevedorOriginal;
       _tarifaCobrancaOriginal = TarifaCobranca;
       _tarifaCobrancaOriginalCommited = _tarifaCobrancaOriginal;
       _taxasOriginal = Taxas;
       _taxasOriginalCommited = _taxasOriginal;
       _usuarioBaixaOriginal = UsuarioBaixa;
       _usuarioBaixaOriginalCommited = _usuarioBaixaOriginal;
       _dataBaixaOriginal = DataBaixa;
       _dataBaixaOriginalCommited = _dataBaixaOriginal;
       _descricaoMeioPagtoOutrosOriginal = DescricaoMeioPagtoOutros;
       _descricaoMeioPagtoOutrosOriginalCommited = _descricaoMeioPagtoOutrosOriginal;
       _meioPagamentoOriginal = MeioPagamento;
       _meioPagamentoOriginalCommited = _meioPagamentoOriginal;

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
       _tipoPagamentoOriginalCommited = TipoPagamento;
       _nfPrincipalOriginalCommited = NfPrincipal;
       _clienteOriginalCommited = Cliente;
       _centroCustoLucroOriginalCommited = CentroCustoLucro;
       _contaBancariaOriginalCommited = ContaBancaria;
       _numDocumentoOriginalCommited = NumDocumento;
       _dataVencimentoOriginalCommited = DataVencimento;
       _valorOriginalCommited = Valor;
       _dataPagamentoOriginalCommited = DataPagamento;
       _valorPagoOriginalCommited = ValorPago;
       _historicoOriginalCommited = Historico;
       _dataEmissaoOriginalCommited = DataEmissao;
       _versionOriginalCommited = Version;
       _conciliacaoBancariaOriginalCommited = ConciliacaoBancaria;
       _descontoOriginalCommited = Desconto;
       _acrescimoOriginalCommited = Acrescimo;
       _contaRecorrenteOriginalCommited = ContaRecorrente;
       _contaEmRevisaoOriginalCommited = ContaEmRevisao;
       _dataCadastroOriginalCommited = DataCadastro;
       _justificativaEstornoOriginalCommited = JustificativaEstorno;
       _idUsuarioEstornoOriginalCommited = IdUsuarioEstorno;
       _dataHoraEstornoOriginalCommited = DataHoraEstorno;
       _funcionarioOriginalCommited = Funcionario;
       _comissaoGeradaOriginalCommited = ComissaoGerada;
       _contaReceberBoletoOriginalCommited = ContaReceberBoleto;
       _idCobrancaBoletoOriginalCommited = IdCobrancaBoleto;
       _cobrancaNossoNumeroOriginalCommited = CobrancaNossoNumero;
       _agrupadorContaOriginalCommited = AgrupadorConta;
       _idDevedorOriginalCommited = IdDevedor;
       _tarifaCobrancaOriginalCommited = TarifaCobranca;
       _taxasOriginalCommited = Taxas;
       _usuarioBaixaOriginalCommited = UsuarioBaixa;
       _dataBaixaOriginalCommited = DataBaixa;
       _descricaoMeioPagtoOutrosOriginalCommited = DescricaoMeioPagtoOutros;
       _meioPagamentoOriginalCommited = MeioPagamento;

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
               if (_valueCollectionLancamentoClassContaReceberLoaded) 
               {
                  if (_collectionLancamentoClassContaReceberRemovidos != null) 
                  {
                     _collectionLancamentoClassContaReceberRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLancamentoClassContaReceberRemovidos = new List<Entidades.LancamentoClass>();
                  }
                  _collectionLancamentoClassContaReceberOriginal= (from a in _valueCollectionLancamentoClassContaReceber select a.ID).ToList();
                  _valueCollectionLancamentoClassContaReceberChanged = false;
                  _valueCollectionLancamentoClassContaReceberCommitedChanged = false;
               }
               if (_valueCollectionMovimentoCaixaClassContaReceberLoaded) 
               {
                  if (_collectionMovimentoCaixaClassContaReceberRemovidos != null) 
                  {
                     _collectionMovimentoCaixaClassContaReceberRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMovimentoCaixaClassContaReceberRemovidos = new List<Entidades.MovimentoCaixaClass>();
                  }
                  _collectionMovimentoCaixaClassContaReceberOriginal= (from a in _valueCollectionMovimentoCaixaClassContaReceber select a.ID).ToList();
                  _valueCollectionMovimentoCaixaClassContaReceberChanged = false;
                  _valueCollectionMovimentoCaixaClassContaReceberCommitedChanged = false;
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
               TipoPagamento=_tipoPagamentoOriginal;
               _tipoPagamentoOriginalCommited=_tipoPagamentoOriginal;
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               NumDocumento=_numDocumentoOriginal;
               _numDocumentoOriginalCommited=_numDocumentoOriginal;
               DataVencimento=_dataVencimentoOriginal;
               _dataVencimentoOriginalCommited=_dataVencimentoOriginal;
               Valor=_valorOriginal;
               _valorOriginalCommited=_valorOriginal;
               DataPagamento=_dataPagamentoOriginal;
               _dataPagamentoOriginalCommited=_dataPagamentoOriginal;
               ValorPago=_valorPagoOriginal;
               _valorPagoOriginalCommited=_valorPagoOriginal;
               Historico=_historicoOriginal;
               _historicoOriginalCommited=_historicoOriginal;
               DataEmissao=_dataEmissaoOriginal;
               _dataEmissaoOriginalCommited=_dataEmissaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ConciliacaoBancaria=_conciliacaoBancariaOriginal;
               _conciliacaoBancariaOriginalCommited=_conciliacaoBancariaOriginal;
               Desconto=_descontoOriginal;
               _descontoOriginalCommited=_descontoOriginal;
               Acrescimo=_acrescimoOriginal;
               _acrescimoOriginalCommited=_acrescimoOriginal;
               ContaRecorrente=_contaRecorrenteOriginal;
               _contaRecorrenteOriginalCommited=_contaRecorrenteOriginal;
               ContaEmRevisao=_contaEmRevisaoOriginal;
               _contaEmRevisaoOriginalCommited=_contaEmRevisaoOriginal;
               DataCadastro=_dataCadastroOriginal;
               _dataCadastroOriginalCommited=_dataCadastroOriginal;
               JustificativaEstorno=_justificativaEstornoOriginal;
               _justificativaEstornoOriginalCommited=_justificativaEstornoOriginal;
               IdUsuarioEstorno=_idUsuarioEstornoOriginal;
               _idUsuarioEstornoOriginalCommited=_idUsuarioEstornoOriginal;
               DataHoraEstorno=_dataHoraEstornoOriginal;
               _dataHoraEstornoOriginalCommited=_dataHoraEstornoOriginal;
               Funcionario=_funcionarioOriginal;
               _funcionarioOriginalCommited=_funcionarioOriginal;
               ComissaoGerada=_comissaoGeradaOriginal;
               _comissaoGeradaOriginalCommited=_comissaoGeradaOriginal;
               ContaReceberBoleto=_contaReceberBoletoOriginal;
               _contaReceberBoletoOriginalCommited=_contaReceberBoletoOriginal;
               IdCobrancaBoleto=_idCobrancaBoletoOriginal;
               _idCobrancaBoletoOriginalCommited=_idCobrancaBoletoOriginal;
               CobrancaNossoNumero=_cobrancaNossoNumeroOriginal;
               _cobrancaNossoNumeroOriginalCommited=_cobrancaNossoNumeroOriginal;
               AgrupadorConta=_agrupadorContaOriginal;
               _agrupadorContaOriginalCommited=_agrupadorContaOriginal;
               IdDevedor=_idDevedorOriginal;
               _idDevedorOriginalCommited=_idDevedorOriginal;
               TarifaCobranca=_tarifaCobrancaOriginal;
               _tarifaCobrancaOriginalCommited=_tarifaCobrancaOriginal;
               Taxas=_taxasOriginal;
               _taxasOriginalCommited=_taxasOriginal;
               UsuarioBaixa=_usuarioBaixaOriginal;
               _usuarioBaixaOriginalCommited=_usuarioBaixaOriginal;
               DataBaixa=_dataBaixaOriginal;
               _dataBaixaOriginalCommited=_dataBaixaOriginal;
               DescricaoMeioPagtoOutros=_descricaoMeioPagtoOutrosOriginal;
               _descricaoMeioPagtoOutrosOriginalCommited=_descricaoMeioPagtoOutrosOriginal;
               MeioPagamento=_meioPagamentoOriginal;
               _meioPagamentoOriginalCommited=_meioPagamentoOriginal;
               if (_valueCollectionLancamentoClassContaReceberLoaded) 
               {
                  CollectionLancamentoClassContaReceber.Clear();
                  foreach(int item in _collectionLancamentoClassContaReceberOriginal)
                  {
                    CollectionLancamentoClassContaReceber.Add(Entidades.LancamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLancamentoClassContaReceberRemovidos.Clear();
               }
               if (_valueCollectionMovimentoCaixaClassContaReceberLoaded) 
               {
                  CollectionMovimentoCaixaClassContaReceber.Clear();
                  foreach(int item in _collectionMovimentoCaixaClassContaReceberOriginal)
                  {
                    CollectionMovimentoCaixaClassContaReceber.Add(Entidades.MovimentoCaixaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMovimentoCaixaClassContaReceberRemovidos.Clear();
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
               if (_valueCollectionLancamentoClassContaReceberLoaded) 
               {
                  if (_valueCollectionLancamentoClassContaReceberChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMovimentoCaixaClassContaReceberLoaded) 
               {
                  if (_valueCollectionMovimentoCaixaClassContaReceberChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLancamentoClassContaReceberLoaded) 
               {
                   tempRet = CollectionLancamentoClassContaReceber.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMovimentoCaixaClassContaReceberLoaded) 
               {
                   tempRet = CollectionMovimentoCaixaClassContaReceber.Any(item => item.IsDirty());
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
       if (_tipoPagamentoOriginal!=null)
       {
          dirty = !_tipoPagamentoOriginal.Equals(TipoPagamento);
       }
       else
       {
            dirty = TipoPagamento != null;
       }
      if (dirty) return true;
       if (_nfPrincipalOriginal!=null)
       {
          dirty = !_nfPrincipalOriginal.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
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
       if (_centroCustoLucroOriginal!=null)
       {
          dirty = !_centroCustoLucroOriginal.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
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
       dirty = _numDocumentoOriginal != NumDocumento;
      if (dirty) return true;
       dirty = _dataVencimentoOriginal != DataVencimento;
      if (dirty) return true;
       dirty = _valorOriginal != Valor;
      if (dirty) return true;
       dirty = _dataPagamentoOriginal != DataPagamento;
      if (dirty) return true;
       dirty = _valorPagoOriginal != ValorPago;
      if (dirty) return true;
       dirty = _historicoOriginal != Historico;
      if (dirty) return true;
       dirty = _dataEmissaoOriginal != DataEmissao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_conciliacaoBancariaOriginal!=null)
       {
          dirty = !_conciliacaoBancariaOriginal.Equals(ConciliacaoBancaria);
       }
       else
       {
            dirty = ConciliacaoBancaria != null;
       }
      if (dirty) return true;
       dirty = _descontoOriginal != Desconto;
      if (dirty) return true;
       dirty = _acrescimoOriginal != Acrescimo;
      if (dirty) return true;
       if (_contaRecorrenteOriginal!=null)
       {
          dirty = !_contaRecorrenteOriginal.Equals(ContaRecorrente);
       }
       else
       {
            dirty = ContaRecorrente != null;
       }
      if (dirty) return true;
       dirty = _contaEmRevisaoOriginal != ContaEmRevisao;
      if (dirty) return true;
       dirty = _dataCadastroOriginal != DataCadastro;
      if (dirty) return true;
       dirty = _justificativaEstornoOriginal != JustificativaEstorno;
      if (dirty) return true;
       dirty = _idUsuarioEstornoOriginal != IdUsuarioEstorno;
      if (dirty) return true;
       dirty = _dataHoraEstornoOriginal != DataHoraEstorno;
      if (dirty) return true;
       if (_funcionarioOriginal!=null)
       {
          dirty = !_funcionarioOriginal.Equals(Funcionario);
       }
       else
       {
            dirty = Funcionario != null;
       }
      if (dirty) return true;
       dirty = _comissaoGeradaOriginal != ComissaoGerada;
      if (dirty) return true;
       if (_contaReceberBoletoOriginal!=null)
       {
          dirty = !_contaReceberBoletoOriginal.Equals(ContaReceberBoleto);
       }
       else
       {
            dirty = ContaReceberBoleto != null;
       }
      if (dirty) return true;
       dirty = _idCobrancaBoletoOriginal != IdCobrancaBoleto;
      if (dirty) return true;
       dirty = _cobrancaNossoNumeroOriginal != CobrancaNossoNumero;
      if (dirty) return true;
       if (_agrupadorContaOriginal!=null)
       {
          dirty = !_agrupadorContaOriginal.Equals(AgrupadorConta);
       }
       else
       {
            dirty = AgrupadorConta != null;
       }
      if (dirty) return true;
       dirty = _idDevedorOriginal != IdDevedor;
      if (dirty) return true;
       dirty = _tarifaCobrancaOriginal != TarifaCobranca;
      if (dirty) return true;
       dirty = _taxasOriginal != Taxas;
      if (dirty) return true;
       dirty = _usuarioBaixaOriginal != UsuarioBaixa;
      if (dirty) return true;
       dirty = _dataBaixaOriginal != DataBaixa;
      if (dirty) return true;
       dirty = _descricaoMeioPagtoOutrosOriginal != DescricaoMeioPagtoOutros;
      if (dirty) return true;
       if (_meioPagamentoOriginal!=null)
       {
          dirty = !_meioPagamentoOriginal.Equals(MeioPagamento);
       }
       else
       {
            dirty = MeioPagamento != null;
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
               if (_valueCollectionLancamentoClassContaReceberLoaded) 
               {
                  if (_valueCollectionLancamentoClassContaReceberCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMovimentoCaixaClassContaReceberLoaded) 
               {
                  if (_valueCollectionMovimentoCaixaClassContaReceberCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLancamentoClassContaReceberLoaded) 
               {
                   tempRet = CollectionLancamentoClassContaReceber.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMovimentoCaixaClassContaReceberLoaded) 
               {
                   tempRet = CollectionMovimentoCaixaClassContaReceber.Any(item => item.IsDirtyCommited());
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
       if (_tipoPagamentoOriginalCommited!=null)
       {
          dirty = !_tipoPagamentoOriginalCommited.Equals(TipoPagamento);
       }
       else
       {
            dirty = TipoPagamento != null;
       }
      if (dirty) return true;
       if (_nfPrincipalOriginalCommited!=null)
       {
          dirty = !_nfPrincipalOriginalCommited.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
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
       if (_centroCustoLucroOriginalCommited!=null)
       {
          dirty = !_centroCustoLucroOriginalCommited.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
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
       dirty = _numDocumentoOriginalCommited != NumDocumento;
      if (dirty) return true;
       dirty = _dataVencimentoOriginalCommited != DataVencimento;
      if (dirty) return true;
       dirty = _valorOriginalCommited != Valor;
      if (dirty) return true;
       dirty = _dataPagamentoOriginalCommited != DataPagamento;
      if (dirty) return true;
       dirty = _valorPagoOriginalCommited != ValorPago;
      if (dirty) return true;
       dirty = _historicoOriginalCommited != Historico;
      if (dirty) return true;
       dirty = _dataEmissaoOriginalCommited != DataEmissao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_conciliacaoBancariaOriginalCommited!=null)
       {
          dirty = !_conciliacaoBancariaOriginalCommited.Equals(ConciliacaoBancaria);
       }
       else
       {
            dirty = ConciliacaoBancaria != null;
       }
      if (dirty) return true;
       dirty = _descontoOriginalCommited != Desconto;
      if (dirty) return true;
       dirty = _acrescimoOriginalCommited != Acrescimo;
      if (dirty) return true;
       if (_contaRecorrenteOriginalCommited!=null)
       {
          dirty = !_contaRecorrenteOriginalCommited.Equals(ContaRecorrente);
       }
       else
       {
            dirty = ContaRecorrente != null;
       }
      if (dirty) return true;
       dirty = _contaEmRevisaoOriginalCommited != ContaEmRevisao;
      if (dirty) return true;
       dirty = _dataCadastroOriginalCommited != DataCadastro;
      if (dirty) return true;
       dirty = _justificativaEstornoOriginalCommited != JustificativaEstorno;
      if (dirty) return true;
       dirty = _idUsuarioEstornoOriginalCommited != IdUsuarioEstorno;
      if (dirty) return true;
       dirty = _dataHoraEstornoOriginalCommited != DataHoraEstorno;
      if (dirty) return true;
       if (_funcionarioOriginalCommited!=null)
       {
          dirty = !_funcionarioOriginalCommited.Equals(Funcionario);
       }
       else
       {
            dirty = Funcionario != null;
       }
      if (dirty) return true;
       dirty = _comissaoGeradaOriginalCommited != ComissaoGerada;
      if (dirty) return true;
       if (_contaReceberBoletoOriginalCommited!=null)
       {
          dirty = !_contaReceberBoletoOriginalCommited.Equals(ContaReceberBoleto);
       }
       else
       {
            dirty = ContaReceberBoleto != null;
       }
      if (dirty) return true;
       dirty = _idCobrancaBoletoOriginalCommited != IdCobrancaBoleto;
      if (dirty) return true;
       dirty = _cobrancaNossoNumeroOriginalCommited != CobrancaNossoNumero;
      if (dirty) return true;
       if (_agrupadorContaOriginalCommited!=null)
       {
          dirty = !_agrupadorContaOriginalCommited.Equals(AgrupadorConta);
       }
       else
       {
            dirty = AgrupadorConta != null;
       }
      if (dirty) return true;
       dirty = _idDevedorOriginalCommited != IdDevedor;
      if (dirty) return true;
       dirty = _tarifaCobrancaOriginalCommited != TarifaCobranca;
      if (dirty) return true;
       dirty = _taxasOriginalCommited != Taxas;
      if (dirty) return true;
       dirty = _usuarioBaixaOriginalCommited != UsuarioBaixa;
      if (dirty) return true;
       dirty = _dataBaixaOriginalCommited != DataBaixa;
      if (dirty) return true;
       dirty = _descricaoMeioPagtoOutrosOriginalCommited != DescricaoMeioPagtoOutros;
      if (dirty) return true;
       if (_meioPagamentoOriginalCommited!=null)
       {
          dirty = !_meioPagamentoOriginalCommited.Equals(MeioPagamento);
       }
       else
       {
            dirty = MeioPagamento != null;
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
               if (_valueCollectionLancamentoClassContaReceberLoaded) 
               {
                  foreach(LancamentoClass item in CollectionLancamentoClassContaReceber)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMovimentoCaixaClassContaReceberLoaded) 
               {
                  foreach(MovimentoCaixaClass item in CollectionMovimentoCaixaClassContaReceber)
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
             case "TipoPagamento":
                return this.TipoPagamento;
             case "NfPrincipal":
                return this.NfPrincipal;
             case "Cliente":
                return this.Cliente;
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
             case "ContaBancaria":
                return this.ContaBancaria;
             case "NumDocumento":
                return this.NumDocumento;
             case "DataVencimento":
                return this.DataVencimento;
             case "Valor":
                return this.Valor;
             case "DataPagamento":
                return this.DataPagamento;
             case "ValorPago":
                return this.ValorPago;
             case "Historico":
                return this.Historico;
             case "DataEmissao":
                return this.DataEmissao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ConciliacaoBancaria":
                return this.ConciliacaoBancaria;
             case "Desconto":
                return this.Desconto;
             case "Acrescimo":
                return this.Acrescimo;
             case "ContaRecorrente":
                return this.ContaRecorrente;
             case "ContaEmRevisao":
                return this.ContaEmRevisao;
             case "DataCadastro":
                return this.DataCadastro;
             case "JustificativaEstorno":
                return this.JustificativaEstorno;
             case "IdUsuarioEstorno":
                return this.IdUsuarioEstorno;
             case "DataHoraEstorno":
                return this.DataHoraEstorno;
             case "Funcionario":
                return this.Funcionario;
             case "ComissaoGerada":
                return this.ComissaoGerada;
             case "ContaReceberBoleto":
                return this.ContaReceberBoleto;
             case "IdCobrancaBoleto":
                return this.IdCobrancaBoleto;
             case "CobrancaNossoNumero":
                return this.CobrancaNossoNumero;
             case "AgrupadorConta":
                return this.AgrupadorConta;
             case "IdDevedor":
                return this.IdDevedor;
             case "TarifaCobranca":
                return this.TarifaCobranca;
             case "Taxas":
                return this.Taxas;
             case "UsuarioBaixa":
                return this.UsuarioBaixa;
             case "DataBaixa":
                return this.DataBaixa;
             case "DescricaoMeioPagtoOutros":
                return this.DescricaoMeioPagtoOutros;
             case "MeioPagamento":
                return this.MeioPagamento;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (TipoPagamento!=null)
                TipoPagamento.ChangeSingleConnection(newConnection);
             if (NfPrincipal!=null)
                NfPrincipal.ChangeSingleConnection(newConnection);
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (ConciliacaoBancaria!=null)
                ConciliacaoBancaria.ChangeSingleConnection(newConnection);
             if (ContaRecorrente!=null)
                ContaRecorrente.ChangeSingleConnection(newConnection);
             if (Funcionario!=null)
                Funcionario.ChangeSingleConnection(newConnection);
             if (ContaReceberBoleto!=null)
                ContaReceberBoleto.ChangeSingleConnection(newConnection);
             if (AgrupadorConta!=null)
                AgrupadorConta.ChangeSingleConnection(newConnection);
             if (MeioPagamento!=null)
                MeioPagamento.ChangeSingleConnection(newConnection);
               if (_valueCollectionLancamentoClassContaReceberLoaded) 
               {
                  foreach(LancamentoClass item in CollectionLancamentoClassContaReceber)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMovimentoCaixaClassContaReceberLoaded) 
               {
                  foreach(MovimentoCaixaClass item in CollectionMovimentoCaixaClassContaReceber)
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
                  command.CommandText += " COUNT(conta_receber.id_conta_receber) " ;
               }
               else
               {
               command.CommandText += "conta_receber.id_conta_receber, " ;
               command.CommandText += "conta_receber.id_tipo_pagamento, " ;
               command.CommandText += "conta_receber.id_nf_principal, " ;
               command.CommandText += "conta_receber.id_cliente, " ;
               command.CommandText += "conta_receber.id_centro_custo_lucro, " ;
               command.CommandText += "conta_receber.id_conta_bancaria, " ;
               command.CommandText += "conta_receber.cor_num_documento, " ;
               command.CommandText += "conta_receber.cor_data_vencimento, " ;
               command.CommandText += "conta_receber.cor_valor, " ;
               command.CommandText += "conta_receber.cor_data_pagamento, " ;
               command.CommandText += "conta_receber.cor_valor_pago, " ;
               command.CommandText += "conta_receber.cor_historico, " ;
               command.CommandText += "conta_receber.cor_data_emissao, " ;
               command.CommandText += "conta_receber.entity_uid, " ;
               command.CommandText += "conta_receber.version, " ;
               command.CommandText += "conta_receber.id_conciliacao_bancaria, " ;
               command.CommandText += "conta_receber.cor_desconto, " ;
               command.CommandText += "conta_receber.cor_acrescimo, " ;
               command.CommandText += "conta_receber.id_conta_recorrente, " ;
               command.CommandText += "conta_receber.cor_conta_em_revisao, " ;
               command.CommandText += "conta_receber.cor_data_cadastro, " ;
               command.CommandText += "conta_receber.cor_justificativa_estorno, " ;
               command.CommandText += "conta_receber.id_usuario_estorno, " ;
               command.CommandText += "conta_receber.cor_data_hora_estorno, " ;
               command.CommandText += "conta_receber.id_funcionario, " ;
               command.CommandText += "conta_receber.cor_comissao_gerada, " ;
               command.CommandText += "conta_receber.id_conta_receber_boleto, " ;
               command.CommandText += "conta_receber.id_cobranca_boleto, " ;
               command.CommandText += "conta_receber.cor_cobranca_nosso_numero, " ;
               command.CommandText += "conta_receber.id_agrupador_conta, " ;
               command.CommandText += "conta_receber.id_devedor, " ;
               command.CommandText += "conta_receber.cor_tarifa_cobranca, " ;
               command.CommandText += "conta_receber.cor_taxas, " ;
               command.CommandText += "conta_receber.cor_usuario_baixa, " ;
               command.CommandText += "conta_receber.cor_data_baixa, " ;
               command.CommandText += "conta_receber.cor_descricao_meio_pagto_outros, " ;
               command.CommandText += "conta_receber.id_meio_pagamento " ;
               }
               command.CommandText += " FROM  conta_receber ";
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
                        orderByClause += " , cor_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(cor_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = conta_receber.id_acs_usuario_ultima_revisao ";
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
                     case "id_conta_receber":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.id_conta_receber " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.id_conta_receber) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_tipo_pagamento":
                     case "TipoPagamento":
                     command.CommandText += " LEFT JOIN tipo_pagamento as tipo_pagamento_TipoPagamento ON tipo_pagamento_TipoPagamento.id_tipo_pagamento = conta_receber.id_tipo_pagamento ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_nf_principal":
                     case "NfPrincipal":
                     orderByClause += " , conta_receber.id_nf_principal " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = conta_receber.id_cliente ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_centro_custo_lucro":
                     case "CentroCustoLucro":
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = conta_receber.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = conta_receber.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
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
                     case "cor_num_documento":
                     case "NumDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_receber.cor_num_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_receber.cor_num_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_data_vencimento":
                     case "DataVencimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_data_vencimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_data_vencimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_data_pagamento":
                     case "DataPagamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_data_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_data_pagamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_valor_pago":
                     case "ValorPago":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_valor_pago " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_valor_pago) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_historico":
                     case "Historico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_receber.cor_historico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_receber.cor_historico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_data_emissao":
                     case "DataEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_data_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_data_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_receber.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_receber.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , conta_receber.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conciliacao_bancaria":
                     case "ConciliacaoBancaria":
                     command.CommandText += " LEFT JOIN conciliacao_bancaria as conciliacao_bancaria_ConciliacaoBancaria ON conciliacao_bancaria_ConciliacaoBancaria.id_conciliacao_bancaria = conta_receber.id_conciliacao_bancaria ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conciliacao_bancaria_ConciliacaoBancaria.id_conciliacao_bancaria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conciliacao_bancaria_ConciliacaoBancaria.id_conciliacao_bancaria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_desconto":
                     case "Desconto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_desconto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_desconto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_acrescimo":
                     case "Acrescimo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_acrescimo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_acrescimo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_recorrente":
                     case "ContaRecorrente":
                     command.CommandText += " LEFT JOIN conta_recorrente as conta_recorrente_ContaRecorrente ON conta_recorrente_ContaRecorrente.id_conta_recorrente = conta_receber.id_conta_recorrente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_recorrente_ContaRecorrente.crr_historico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_recorrente_ContaRecorrente.crr_historico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_conta_em_revisao":
                     case "ContaEmRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_conta_em_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_conta_em_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_data_cadastro":
                     case "DataCadastro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_data_cadastro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_data_cadastro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_justificativa_estorno":
                     case "JustificativaEstorno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_receber.cor_justificativa_estorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_receber.cor_justificativa_estorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_usuario_estorno":
                     case "IdUsuarioEstorno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.id_usuario_estorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.id_usuario_estorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_data_hora_estorno":
                     case "DataHoraEstorno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_data_hora_estorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_data_hora_estorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_funcionario":
                     case "Funcionario":
                     command.CommandText += " LEFT JOIN funcionario as funcionario_Funcionario ON funcionario_Funcionario.id_funcionario = conta_receber.id_funcionario ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario_Funcionario.fuc_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario_Funcionario.fuc_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_comissao_gerada":
                     case "ComissaoGerada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_comissao_gerada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_comissao_gerada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_receber_boleto":
                     case "ContaReceberBoleto":
                     orderByClause += " , conta_receber.id_conta_receber_boleto " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_cobranca_boleto":
                     case "IdCobrancaBoleto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.id_cobranca_boleto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.id_cobranca_boleto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_cobranca_nosso_numero":
                     case "CobrancaNossoNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_receber.cor_cobranca_nosso_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_receber.cor_cobranca_nosso_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_agrupador_conta":
                     case "AgrupadorConta":
                     orderByClause += " , conta_receber.id_agrupador_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_devedor":
                     case "IdDevedor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.id_devedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.id_devedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_tarifa_cobranca":
                     case "TarifaCobranca":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_tarifa_cobranca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_tarifa_cobranca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_taxas":
                     case "Taxas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_taxas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_taxas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_usuario_baixa":
                     case "UsuarioBaixa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_receber.cor_usuario_baixa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_receber.cor_usuario_baixa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_data_baixa":
                     case "DataBaixa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_receber.cor_data_baixa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_receber.cor_data_baixa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cor_descricao_meio_pagto_outros":
                     case "DescricaoMeioPagtoOutros":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_receber.cor_descricao_meio_pagto_outros " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_receber.cor_descricao_meio_pagto_outros) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_meio_pagamento":
                     case "MeioPagamento":
                     orderByClause += " , conta_receber.id_meio_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cor_num_documento")) 
                        {
                           whereClause += " OR UPPER(conta_receber.cor_num_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_receber.cor_num_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cor_historico")) 
                        {
                           whereClause += " OR UPPER(conta_receber.cor_historico) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_receber.cor_historico) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(conta_receber.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_receber.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cor_justificativa_estorno")) 
                        {
                           whereClause += " OR UPPER(conta_receber.cor_justificativa_estorno) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_receber.cor_justificativa_estorno) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cor_cobranca_nosso_numero")) 
                        {
                           whereClause += " OR UPPER(conta_receber.cor_cobranca_nosso_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_receber.cor_cobranca_nosso_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cor_usuario_baixa")) 
                        {
                           whereClause += " OR UPPER(conta_receber.cor_usuario_baixa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_receber.cor_usuario_baixa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cor_descricao_meio_pagto_outros")) 
                        {
                           whereClause += " OR UPPER(conta_receber.cor_descricao_meio_pagto_outros) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_receber.cor_descricao_meio_pagto_outros) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_conta_receber")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_conta_receber IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_conta_receber = :conta_receber_ID_1918 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_ID_1918", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  conta_receber.id_tipo_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_tipo_pagamento = :conta_receber_TipoPagamento_8705 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_TipoPagamento_8705", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfPrincipal" || parametro.FieldName == "id_nf_principal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfPrincipalClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfPrincipalClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_nf_principal = :conta_receber_NfPrincipal_100 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_NfPrincipal_100", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_receber.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_cliente = :conta_receber_Cliente_8391 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_Cliente_8391", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_receber.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_centro_custo_lucro = :conta_receber_CentroCustoLucro_742 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_CentroCustoLucro_742", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_receber.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_conta_bancaria = :conta_receber_ContaBancaria_526 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_ContaBancaria_526", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumDocumento" || parametro.FieldName == "cor_num_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_num_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_num_documento LIKE :conta_receber_NumDocumento_8434 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_NumDocumento_8434", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataVencimento" || parametro.FieldName == "cor_data_vencimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_data_vencimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_data_vencimento = :conta_receber_DataVencimento_1009 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_DataVencimento_1009", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "cor_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_valor = :conta_receber_Valor_5734 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_Valor_5734", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataPagamento" || parametro.FieldName == "cor_data_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_data_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_data_pagamento = :conta_receber_DataPagamento_5627 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_DataPagamento_5627", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorPago" || parametro.FieldName == "cor_valor_pago")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_valor_pago IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_valor_pago = :conta_receber_ValorPago_8090 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_ValorPago_8090", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Historico" || parametro.FieldName == "cor_historico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_historico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_historico LIKE :conta_receber_Historico_4373 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_Historico_4373", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEmissao" || parametro.FieldName == "cor_data_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_data_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_data_emissao = :conta_receber_DataEmissao_5971 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_DataEmissao_5971", NpgsqlDbType.Date, parametro.Fieldvalue));
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
                         whereClause += "  conta_receber.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.entity_uid LIKE :conta_receber_EntityUid_75 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_EntityUid_75", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  conta_receber.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.version = :conta_receber_Version_1870 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_Version_1870", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConciliacaoBancaria" || parametro.FieldName == "id_conciliacao_bancaria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ConciliacaoBancariaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ConciliacaoBancariaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_conciliacao_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_conciliacao_bancaria = :conta_receber_ConciliacaoBancaria_5776 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_ConciliacaoBancaria_5776", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Desconto" || parametro.FieldName == "cor_desconto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_desconto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_desconto = :conta_receber_Desconto_2507 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_Desconto_2507", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Acrescimo" || parametro.FieldName == "cor_acrescimo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_acrescimo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_acrescimo = :conta_receber_Acrescimo_2983 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_Acrescimo_2983", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaRecorrente" || parametro.FieldName == "id_conta_recorrente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ContaRecorrenteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ContaRecorrenteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_conta_recorrente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_conta_recorrente = :conta_receber_ContaRecorrente_6277 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_ContaRecorrente_6277", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaEmRevisao" || parametro.FieldName == "cor_conta_em_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_conta_em_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_conta_em_revisao = :conta_receber_ContaEmRevisao_9845 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_ContaEmRevisao_9845", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCadastro" || parametro.FieldName == "cor_data_cadastro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_data_cadastro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_data_cadastro = :conta_receber_DataCadastro_5942 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_DataCadastro_5942", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaEstorno" || parametro.FieldName == "cor_justificativa_estorno")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_justificativa_estorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_justificativa_estorno LIKE :conta_receber_JustificativaEstorno_5394 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_JustificativaEstorno_5394", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdUsuarioEstorno" || parametro.FieldName == "id_usuario_estorno")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_usuario_estorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_usuario_estorno = :conta_receber_IdUsuarioEstorno_82 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_IdUsuarioEstorno_82", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataHoraEstorno" || parametro.FieldName == "cor_data_hora_estorno")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_data_hora_estorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_data_hora_estorno = :conta_receber_DataHoraEstorno_7754 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_DataHoraEstorno_7754", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Funcionario" || parametro.FieldName == "id_funcionario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FuncionarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FuncionarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_funcionario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_funcionario = :conta_receber_Funcionario_8943 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_Funcionario_8943", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ComissaoGerada" || parametro.FieldName == "cor_comissao_gerada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_comissao_gerada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_comissao_gerada = :conta_receber_ComissaoGerada_8902 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_ComissaoGerada_8902", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaReceberBoleto" || parametro.FieldName == "id_conta_receber_boleto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ContaReceberBoletoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ContaReceberBoletoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_conta_receber_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_conta_receber_boleto = :conta_receber_ContaReceberBoleto_4630 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_ContaReceberBoleto_4630", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdCobrancaBoleto" || parametro.FieldName == "id_cobranca_boleto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_cobranca_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_cobranca_boleto = :conta_receber_IdCobrancaBoleto_6063 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_IdCobrancaBoleto_6063", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CobrancaNossoNumero" || parametro.FieldName == "cor_cobranca_nosso_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_cobranca_nosso_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_cobranca_nosso_numero LIKE :conta_receber_CobrancaNossoNumero_1368 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_CobrancaNossoNumero_1368", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AgrupadorConta" || parametro.FieldName == "id_agrupador_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.AgrupadorContaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.AgrupadorContaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_agrupador_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_agrupador_conta = :conta_receber_AgrupadorConta_2243 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_AgrupadorConta_2243", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdDevedor" || parametro.FieldName == "id_devedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_devedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_devedor = :conta_receber_IdDevedor_9760 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_IdDevedor_9760", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TarifaCobranca" || parametro.FieldName == "cor_tarifa_cobranca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_tarifa_cobranca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_tarifa_cobranca = :conta_receber_TarifaCobranca_8727 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_TarifaCobranca_8727", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Taxas" || parametro.FieldName == "cor_taxas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_taxas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_taxas = :conta_receber_Taxas_2002 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_Taxas_2002", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioBaixa" || parametro.FieldName == "cor_usuario_baixa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_usuario_baixa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_usuario_baixa LIKE :conta_receber_UsuarioBaixa_5623 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_UsuarioBaixa_5623", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataBaixa" || parametro.FieldName == "cor_data_baixa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_data_baixa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_data_baixa = :conta_receber_DataBaixa_7649 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_DataBaixa_7649", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoMeioPagtoOutros" || parametro.FieldName == "cor_descricao_meio_pagto_outros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_descricao_meio_pagto_outros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_descricao_meio_pagto_outros LIKE :conta_receber_DescricaoMeioPagtoOutros_9501 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_DescricaoMeioPagtoOutros_9501", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MeioPagamento" || parametro.FieldName == "id_meio_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MeioPagamentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MeioPagamentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.id_meio_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.id_meio_pagamento = :conta_receber_MeioPagamento_8890 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_MeioPagamento_8890", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumDocumentoExato" || parametro.FieldName == "NumDocumentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_num_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_num_documento LIKE :conta_receber_NumDocumento_9942 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_NumDocumento_9942", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "HistoricoExato" || parametro.FieldName == "HistoricoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_historico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_historico LIKE :conta_receber_Historico_3487 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_Historico_3487", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_receber.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.entity_uid LIKE :conta_receber_EntityUid_5659 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_EntityUid_5659", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaEstornoExato" || parametro.FieldName == "JustificativaEstornoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_justificativa_estorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_justificativa_estorno LIKE :conta_receber_JustificativaEstorno_5636 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_JustificativaEstorno_5636", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CobrancaNossoNumeroExato" || parametro.FieldName == "CobrancaNossoNumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_cobranca_nosso_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_cobranca_nosso_numero LIKE :conta_receber_CobrancaNossoNumero_2464 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_CobrancaNossoNumero_2464", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioBaixaExato" || parametro.FieldName == "UsuarioBaixaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_usuario_baixa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_usuario_baixa LIKE :conta_receber_UsuarioBaixa_6546 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_UsuarioBaixa_6546", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoMeioPagtoOutrosExato" || parametro.FieldName == "DescricaoMeioPagtoOutrosExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_receber.cor_descricao_meio_pagto_outros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_receber.cor_descricao_meio_pagto_outros LIKE :conta_receber_DescricaoMeioPagtoOutros_1506 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_receber_DescricaoMeioPagtoOutros_1506", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ContaReceberClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ContaReceberClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ContaReceberClass), Convert.ToInt32(read["id_conta_receber"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ContaReceberClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_conta_receber"]);
                     if (read["id_tipo_pagamento"] != DBNull.Value)
                     {
                        entidade.TipoPagamento = (BibliotecaEntidades.Entidades.TipoPagamentoClass)BibliotecaEntidades.Entidades.TipoPagamentoClass.GetEntidade(Convert.ToInt32(read["id_tipo_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.TipoPagamento = null ;
                     }
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     if (read["id_centro_custo_lucro"] != DBNull.Value)
                     {
                        entidade.CentroCustoLucro = (BibliotecaEntidades.Entidades.CentroCustoLucroClass)BibliotecaEntidades.Entidades.CentroCustoLucroClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CentroCustoLucro = null ;
                     }
                     if (read["id_conta_bancaria"] != DBNull.Value)
                     {
                        entidade.ContaBancaria = (BibliotecaEntidades.Entidades.ContaBancariaClass)BibliotecaEntidades.Entidades.ContaBancariaClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaBancaria = null ;
                     }
                     entidade.NumDocumento = (read["cor_num_documento"] != DBNull.Value ? read["cor_num_documento"].ToString() : null);
                     entidade.DataVencimento = (DateTime)read["cor_data_vencimento"];
                     entidade.Valor = (double)read["cor_valor"];
                     entidade.DataPagamento = read["cor_data_pagamento"] as DateTime?;
                     entidade.ValorPago = read["cor_valor_pago"] as double?;
                     entidade.Historico = (read["cor_historico"] != DBNull.Value ? read["cor_historico"].ToString() : null);
                     entidade.DataEmissao = (DateTime)read["cor_data_emissao"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_conciliacao_bancaria"] != DBNull.Value)
                     {
                        entidade.ConciliacaoBancaria = (BibliotecaEntidades.Entidades.ConciliacaoBancariaClass)BibliotecaEntidades.Entidades.ConciliacaoBancariaClass.GetEntidade(Convert.ToInt32(read["id_conciliacao_bancaria"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ConciliacaoBancaria = null ;
                     }
                     entidade.Desconto = (double)read["cor_desconto"];
                     entidade.Acrescimo = (double)read["cor_acrescimo"];
                     if (read["id_conta_recorrente"] != DBNull.Value)
                     {
                        entidade.ContaRecorrente = (BibliotecaEntidades.Entidades.ContaRecorrenteClass)BibliotecaEntidades.Entidades.ContaRecorrenteClass.GetEntidade(Convert.ToInt32(read["id_conta_recorrente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaRecorrente = null ;
                     }
                     entidade.ContaEmRevisao = Convert.ToBoolean(Convert.ToInt16(read["cor_conta_em_revisao"]));
                     entidade.DataCadastro = (DateTime)read["cor_data_cadastro"];
                     entidade.JustificativaEstorno = (read["cor_justificativa_estorno"] != DBNull.Value ? read["cor_justificativa_estorno"].ToString() : null);
                     entidade.IdUsuarioEstorno = read["id_usuario_estorno"] as int?;
                     entidade.DataHoraEstorno = read["cor_data_hora_estorno"] as DateTime?;
                     if (read["id_funcionario"] != DBNull.Value)
                     {
                        entidade.Funcionario = (BibliotecaEntidades.Entidades.FuncionarioClass)BibliotecaEntidades.Entidades.FuncionarioClass.GetEntidade(Convert.ToInt32(read["id_funcionario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Funcionario = null ;
                     }
                     entidade.ComissaoGerada = Convert.ToBoolean(Convert.ToInt16(read["cor_comissao_gerada"]));
                     if (read["id_conta_receber_boleto"] != DBNull.Value)
                     {
                        entidade.ContaReceberBoleto = (BibliotecaEntidades.Entidades.ContaReceberBoletoClass)BibliotecaEntidades.Entidades.ContaReceberBoletoClass.GetEntidade(Convert.ToInt32(read["id_conta_receber_boleto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaReceberBoleto = null ;
                     }
                     entidade.IdCobrancaBoleto = (read["id_cobranca_boleto"] != DBNull.Value ? (long?)Convert.ToInt64(read["id_cobranca_boleto"]) : null);
                     entidade.CobrancaNossoNumero = (read["cor_cobranca_nosso_numero"] != DBNull.Value ? read["cor_cobranca_nosso_numero"].ToString() : null);
                     if (read["id_agrupador_conta"] != DBNull.Value)
                     {
                        entidade.AgrupadorConta = (BibliotecaEntidades.Entidades.AgrupadorContaClass)BibliotecaEntidades.Entidades.AgrupadorContaClass.GetEntidade(Convert.ToInt32(read["id_agrupador_conta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AgrupadorConta = null ;
                     }
                     entidade.IdDevedor = Convert.ToInt64(read["id_devedor"]);
                     entidade.TarifaCobranca = read["cor_tarifa_cobranca"] as double?;
                     entidade.Taxas = (double)read["cor_taxas"];
                     entidade.UsuarioBaixa = (read["cor_usuario_baixa"] != DBNull.Value ? read["cor_usuario_baixa"].ToString() : null);
                     entidade.DataBaixa = read["cor_data_baixa"] as DateTime?;
                     entidade.DescricaoMeioPagtoOutros = (read["cor_descricao_meio_pagto_outros"] != DBNull.Value ? read["cor_descricao_meio_pagto_outros"].ToString() : null);
                     if (read["id_meio_pagamento"] != DBNull.Value)
                     {
                        entidade.MeioPagamento = (BibliotecaEntidades.Entidades.MeioPagamentoClass)BibliotecaEntidades.Entidades.MeioPagamentoClass.GetEntidade(Convert.ToInt32(read["id_meio_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.MeioPagamento = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ContaReceberClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
