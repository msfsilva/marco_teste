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
     [Table("conta_pagar","cop")]
     public class ContaPagarBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ContaPagarClass";
protected const string ErroDelete = "Erro ao excluir o ContaPagarClass  ";
protected const string ErroSave = "Erro ao salvar o ContaPagarClass.";
protected const string ErroCollectionLancamentoClassContaPagar = "Erro ao carregar a coleção de LancamentoClass.";
protected const string ErroCollectionMovimentoCaixaClassContaPagar = "Erro ao carregar a coleção de MovimentoCaixaClass.";
protected const string ErroHistoricoObrigatorio = "O campo Historico é obrigatório";
protected const string ErroHistoricoComprimento = "O campo Historico deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
protected const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ContaPagarClass.";
protected const string MensagemUtilizadoCollectionLancamentoClassContaPagar =  "A entidade ContaPagarClass está sendo utilizada nos seguintes LancamentoClass:";
protected const string MensagemUtilizadoCollectionMovimentoCaixaClassContaPagar =  "A entidade ContaPagarClass está sendo utilizada nos seguintes MovimentoCaixaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ContaPagarClass está sendo utilizada.";
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

       protected BibliotecaEntidades.Entidades.NotaFiscalEntradaClass _notaFiscalEntradaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.NotaFiscalEntradaClass _notaFiscalEntradaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.NotaFiscalEntradaClass _valueNotaFiscalEntrada;
        [Column("id_nota_fiscal_entrada", "nota_fiscal_entrada", "id_nota_fiscal_entrada")]
       public virtual BibliotecaEntidades.Entidades.NotaFiscalEntradaClass NotaFiscalEntrada
        { 
           get {                 return this._valueNotaFiscalEntrada; } 
           set 
           { 
                if (this._valueNotaFiscalEntrada == value)return;
                 this._valueNotaFiscalEntrada = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.FornecedorClass _fornecedorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FornecedorClass _fornecedorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FornecedorClass _valueFornecedor;
        [Column("id_fornecedor", "fornecedor", "id_fornecedor")]
       public virtual BibliotecaEntidades.Entidades.FornecedorClass Fornecedor
        { 
           get {                 return this._valueFornecedor; } 
           set 
           { 
                if (this._valueFornecedor == value)return;
                 this._valueFornecedor = value; 
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
         [Column("cop_num_documento")]
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
         [Column("cop_data_vencimento")]
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
         [Column("cop_valor")]
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
         [Column("cop_data_pagamento")]
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
         [Column("cop_valor_pago")]
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
         [Column("cop_historico")]
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
         [Column("cop_data_emissao")]
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

       protected double _acrescimoOriginal{get;private set;}
       private double _acrescimoOriginalCommited{get; set;}
        private double _valueAcrescimo;
         [Column("cop_acrescimo")]
        public virtual double Acrescimo
         { 
            get { return this._valueAcrescimo; } 
            set 
            { 
                if (this._valueAcrescimo == value)return;
                 this._valueAcrescimo = value; 
            } 
        } 

       protected double _descontoOriginal{get;private set;}
       private double _descontoOriginalCommited{get; set;}
        private double _valueDesconto;
         [Column("cop_desconto")]
        public virtual double Desconto
         { 
            get { return this._valueDesconto; } 
            set 
            { 
                if (this._valueDesconto == value)return;
                 this._valueDesconto = value; 
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
         [Column("cop_conta_em_revisao")]
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
         [Column("cop_data_cadastro")]
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
         [Column("cop_justificativa_estorno")]
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
         [Column("cop_data_hora_estorno")]
        public virtual DateTime? DataHoraEstorno
         { 
            get { return this._valueDataHoraEstorno; } 
            set 
            { 
                if (this._valueDataHoraEstorno == value)return;
                 this._valueDataHoraEstorno = value; 
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

       protected DateTime? _dataOriginal{get;private set;}
       private DateTime? _dataOriginalCommited{get; set;}
        private DateTime? _valueData;
         [Column("data")]
        public virtual DateTime? Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
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

       protected long _idCredorOriginal{get;private set;}
       private long _idCredorOriginalCommited{get; set;}
        private long _valueIdCredor;
         [Column("id_credor")]
        public virtual long IdCredor
         { 
            get { return this._valueIdCredor; } 
            set 
            { 
                if (this._valueIdCredor == value)return;
                 this._valueIdCredor = value; 
            } 
        } 

       protected string _usuarioBaixaOriginal{get;private set;}
       private string _usuarioBaixaOriginalCommited{get; set;}
        private string _valueUsuarioBaixa;
         [Column("cop_usuario_baixa")]
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
         [Column("cop_data_baixa")]
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
         [Column("cop_descricao_meio_pagto_outros")]
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

       private List<long> _collectionLancamentoClassContaPagarOriginal;
       private List<Entidades.LancamentoClass > _collectionLancamentoClassContaPagarRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLancamentoClassContaPagarLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLancamentoClassContaPagarChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLancamentoClassContaPagarCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LancamentoClass> _valueCollectionLancamentoClassContaPagar { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LancamentoClass> CollectionLancamentoClassContaPagar 
       { 
           get { if(!_valueCollectionLancamentoClassContaPagarLoaded && !this.DisableLoadCollection){this.LoadCollectionLancamentoClassContaPagar();}
return this._valueCollectionLancamentoClassContaPagar; } 
           set 
           { 
               this._valueCollectionLancamentoClassContaPagar = value; 
               this._valueCollectionLancamentoClassContaPagarLoaded = true; 
           } 
       } 

       private List<long> _collectionMovimentoCaixaClassContaPagarOriginal;
       private List<Entidades.MovimentoCaixaClass > _collectionMovimentoCaixaClassContaPagarRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMovimentoCaixaClassContaPagarLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMovimentoCaixaClassContaPagarChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMovimentoCaixaClassContaPagarCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MovimentoCaixaClass> _valueCollectionMovimentoCaixaClassContaPagar { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MovimentoCaixaClass> CollectionMovimentoCaixaClassContaPagar 
       { 
           get { if(!_valueCollectionMovimentoCaixaClassContaPagarLoaded && !this.DisableLoadCollection){this.LoadCollectionMovimentoCaixaClassContaPagar();}
return this._valueCollectionMovimentoCaixaClassContaPagar; } 
           set 
           { 
               this._valueCollectionMovimentoCaixaClassContaPagar = value; 
               this._valueCollectionMovimentoCaixaClassContaPagarLoaded = true; 
           } 
       } 

        public ContaPagarBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
           this.Acrescimo = 0;
           this.Desconto = 0;
           this.ContaEmRevisao = false;
           this.DataCadastro = Configurations.DataIndependenteClass.GetData();
           this.Data = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ContaPagarClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ContaPagarClass) GetEntity(typeof(ContaPagarClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionLancamentoClassContaPagarChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLancamentoClassContaPagarChanged = true;
                  _valueCollectionLancamentoClassContaPagarCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLancamentoClassContaPagarChanged = true; 
                  _valueCollectionLancamentoClassContaPagarCommitedChanged = true;
                 foreach (Entidades.LancamentoClass item in e.OldItems) 
                 { 
                     _collectionLancamentoClassContaPagarRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLancamentoClassContaPagarChanged = true; 
                  _valueCollectionLancamentoClassContaPagarCommitedChanged = true;
                 foreach (Entidades.LancamentoClass item in _valueCollectionLancamentoClassContaPagar) 
                 { 
                     _collectionLancamentoClassContaPagarRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLancamentoClassContaPagar()
         {
            try
            {
                 ObservableCollection<Entidades.LancamentoClass> oc;
                _valueCollectionLancamentoClassContaPagarChanged = false;
                 _valueCollectionLancamentoClassContaPagarCommitedChanged = false;
                _collectionLancamentoClassContaPagarRemovidos = new List<Entidades.LancamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LancamentoClass>();
                }
                else{ 
                   Entidades.LancamentoClass search = new Entidades.LancamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LancamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaPagar", this),                     }                       ).Cast<Entidades.LancamentoClass>().ToList());
                 }
                 _valueCollectionLancamentoClassContaPagar = new BindingList<Entidades.LancamentoClass>(oc); 
                 _collectionLancamentoClassContaPagarOriginal= (from a in _valueCollectionLancamentoClassContaPagar select a.ID).ToList();
                 _valueCollectionLancamentoClassContaPagarLoaded = true;
                 oc.CollectionChanged += CollectionLancamentoClassContaPagarChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLancamentoClassContaPagar+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMovimentoCaixaClassContaPagarChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMovimentoCaixaClassContaPagarChanged = true;
                  _valueCollectionMovimentoCaixaClassContaPagarCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMovimentoCaixaClassContaPagarChanged = true; 
                  _valueCollectionMovimentoCaixaClassContaPagarCommitedChanged = true;
                 foreach (Entidades.MovimentoCaixaClass item in e.OldItems) 
                 { 
                     _collectionMovimentoCaixaClassContaPagarRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMovimentoCaixaClassContaPagarChanged = true; 
                  _valueCollectionMovimentoCaixaClassContaPagarCommitedChanged = true;
                 foreach (Entidades.MovimentoCaixaClass item in _valueCollectionMovimentoCaixaClassContaPagar) 
                 { 
                     _collectionMovimentoCaixaClassContaPagarRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMovimentoCaixaClassContaPagar()
         {
            try
            {
                 ObservableCollection<Entidades.MovimentoCaixaClass> oc;
                _valueCollectionMovimentoCaixaClassContaPagarChanged = false;
                 _valueCollectionMovimentoCaixaClassContaPagarCommitedChanged = false;
                _collectionMovimentoCaixaClassContaPagarRemovidos = new List<Entidades.MovimentoCaixaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MovimentoCaixaClass>();
                }
                else{ 
                   Entidades.MovimentoCaixaClass search = new Entidades.MovimentoCaixaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MovimentoCaixaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaPagar", this),                     }                       ).Cast<Entidades.MovimentoCaixaClass>().ToList());
                 }
                 _valueCollectionMovimentoCaixaClassContaPagar = new BindingList<Entidades.MovimentoCaixaClass>(oc); 
                 _collectionMovimentoCaixaClassContaPagarOriginal= (from a in _valueCollectionMovimentoCaixaClassContaPagar select a.ID).ToList();
                 _valueCollectionMovimentoCaixaClassContaPagarLoaded = true;
                 oc.CollectionChanged += CollectionMovimentoCaixaClassContaPagarChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMovimentoCaixaClassContaPagar+"\r\n" + e.Message, e);
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
                    "  public.conta_pagar  " +
                    "WHERE " +
                    "  id_conta_pagar = :id";
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
                        "  public.conta_pagar   " +
                        "SET  " + 
                        "  id_tipo_pagamento = :id_tipo_pagamento, " + 
                        "  id_nota_fiscal_entrada = :id_nota_fiscal_entrada, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  cop_num_documento = :cop_num_documento, " + 
                        "  cop_data_vencimento = :cop_data_vencimento, " + 
                        "  cop_valor = :cop_valor, " + 
                        "  cop_data_pagamento = :cop_data_pagamento, " + 
                        "  cop_valor_pago = :cop_valor_pago, " + 
                        "  cop_historico = :cop_historico, " + 
                        "  cop_data_emissao = :cop_data_emissao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_conciliacao_bancaria = :id_conciliacao_bancaria, " + 
                        "  cop_acrescimo = :cop_acrescimo, " + 
                        "  cop_desconto = :cop_desconto, " + 
                        "  id_conta_recorrente = :id_conta_recorrente, " + 
                        "  cop_conta_em_revisao = :cop_conta_em_revisao, " + 
                        "  cop_data_cadastro = :cop_data_cadastro, " + 
                        "  cop_justificativa_estorno = :cop_justificativa_estorno, " + 
                        "  id_usuario_estorno = :id_usuario_estorno, " + 
                        "  cop_data_hora_estorno = :cop_data_hora_estorno, " + 
                        "  id_representante = :id_representante, " + 
                        "  id_funcionario = :id_funcionario, " + 
                        "  id_vendedor = :id_vendedor, " + 
                        "  data = :data, " + 
                        "  id_agrupador_conta = :id_agrupador_conta, " + 
                        "  id_credor = :id_credor, " + 
                        "  cop_usuario_baixa = :cop_usuario_baixa, " + 
                        "  cop_data_baixa = :cop_data_baixa, " + 
                        "  cop_descricao_meio_pagto_outros = :cop_descricao_meio_pagto_outros, " + 
                        "  id_meio_pagamento = :id_meio_pagamento "+
                        "WHERE  " +
                        "  id_conta_pagar = :id " +
                        "RETURNING id_conta_pagar;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.conta_pagar " +
                        "( " +
                        "  id_tipo_pagamento , " + 
                        "  id_nota_fiscal_entrada , " + 
                        "  id_fornecedor , " + 
                        "  id_centro_custo_lucro , " + 
                        "  id_conta_bancaria , " + 
                        "  cop_num_documento , " + 
                        "  cop_data_vencimento , " + 
                        "  cop_valor , " + 
                        "  cop_data_pagamento , " + 
                        "  cop_valor_pago , " + 
                        "  cop_historico , " + 
                        "  cop_data_emissao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_conciliacao_bancaria , " + 
                        "  cop_acrescimo , " + 
                        "  cop_desconto , " + 
                        "  id_conta_recorrente , " + 
                        "  cop_conta_em_revisao , " + 
                        "  cop_data_cadastro , " + 
                        "  cop_justificativa_estorno , " + 
                        "  id_usuario_estorno , " + 
                        "  cop_data_hora_estorno , " + 
                        "  id_representante , " + 
                        "  id_funcionario , " + 
                        "  id_vendedor , " + 
                        "  data , " + 
                        "  id_agrupador_conta , " + 
                        "  id_credor , " + 
                        "  cop_usuario_baixa , " + 
                        "  cop_data_baixa , " + 
                        "  cop_descricao_meio_pagto_outros , " + 
                        "  id_meio_pagamento  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_tipo_pagamento , " + 
                        "  :id_nota_fiscal_entrada , " + 
                        "  :id_fornecedor , " + 
                        "  :id_centro_custo_lucro , " + 
                        "  :id_conta_bancaria , " + 
                        "  :cop_num_documento , " + 
                        "  :cop_data_vencimento , " + 
                        "  :cop_valor , " + 
                        "  :cop_data_pagamento , " + 
                        "  :cop_valor_pago , " + 
                        "  :cop_historico , " + 
                        "  :cop_data_emissao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_conciliacao_bancaria , " + 
                        "  :cop_acrescimo , " + 
                        "  :cop_desconto , " + 
                        "  :id_conta_recorrente , " + 
                        "  :cop_conta_em_revisao , " + 
                        "  :cop_data_cadastro , " + 
                        "  :cop_justificativa_estorno , " + 
                        "  :id_usuario_estorno , " + 
                        "  :cop_data_hora_estorno , " + 
                        "  :id_representante , " + 
                        "  :id_funcionario , " + 
                        "  :id_vendedor , " + 
                        "  :data , " + 
                        "  :id_agrupador_conta , " + 
                        "  :id_credor , " + 
                        "  :cop_usuario_baixa , " + 
                        "  :cop_data_baixa , " + 
                        "  :cop_descricao_meio_pagto_outros , " + 
                        "  :id_meio_pagamento  "+
                        ")RETURNING id_conta_pagar;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tipo_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.TipoPagamento==null ? (object) DBNull.Value : this.TipoPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NotaFiscalEntrada==null ? (object) DBNull.Value : this.NotaFiscalEntrada.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_num_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_data_vencimento", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataVencimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_data_pagamento", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataPagamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_valor_pago", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorPago ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_historico", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Historico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_data_emissao", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conciliacao_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ConciliacaoBancaria==null ? (object) DBNull.Value : this.ConciliacaoBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_acrescimo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Acrescimo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_desconto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Desconto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_recorrente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaRecorrente==null ? (object) DBNull.Value : this.ContaRecorrente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_conta_em_revisao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ContaEmRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_data_cadastro", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCadastro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_justificativa_estorno", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JustificativaEstorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_usuario_estorno", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdUsuarioEstorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_data_hora_estorno", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataHoraEstorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_representante", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Representante==null ? (object) DBNull.Value : this.Representante.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_funcionario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Funcionario==null ? (object) DBNull.Value : this.Funcionario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_vendedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Vendedor==null ? (object) DBNull.Value : this.Vendedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_agrupador_conta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AgrupadorConta==null ? (object) DBNull.Value : this.AgrupadorConta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_credor", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdCredor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_usuario_baixa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UsuarioBaixa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_data_baixa", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataBaixa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cop_descricao_meio_pagto_outros", NpgsqlDbType.Varchar));
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
 if (CollectionLancamentoClassContaPagar.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLancamentoClassContaPagar+"\r\n";
                foreach (Entidades.LancamentoClass tmp in CollectionLancamentoClassContaPagar)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMovimentoCaixaClassContaPagar.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMovimentoCaixaClassContaPagar+"\r\n";
                foreach (Entidades.MovimentoCaixaClass tmp in CollectionMovimentoCaixaClassContaPagar)
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
        public static ContaPagarClass CopiarEntidade(ContaPagarClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ContaPagarClass toRet = new ContaPagarClass(usuario,conn);
 toRet.TipoPagamento= entidadeCopiar.TipoPagamento;
 toRet.NotaFiscalEntrada= entidadeCopiar.NotaFiscalEntrada;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
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
 toRet.Acrescimo= entidadeCopiar.Acrescimo;
 toRet.Desconto= entidadeCopiar.Desconto;
 toRet.ContaRecorrente= entidadeCopiar.ContaRecorrente;
 toRet.ContaEmRevisao= entidadeCopiar.ContaEmRevisao;
 toRet.DataCadastro= entidadeCopiar.DataCadastro;
 toRet.JustificativaEstorno= entidadeCopiar.JustificativaEstorno;
 toRet.IdUsuarioEstorno= entidadeCopiar.IdUsuarioEstorno;
 toRet.DataHoraEstorno= entidadeCopiar.DataHoraEstorno;
 toRet.Representante= entidadeCopiar.Representante;
 toRet.Funcionario= entidadeCopiar.Funcionario;
 toRet.Vendedor= entidadeCopiar.Vendedor;
 toRet.Data= entidadeCopiar.Data;
 toRet.AgrupadorConta= entidadeCopiar.AgrupadorConta;
 toRet.IdCredor= entidadeCopiar.IdCredor;
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
       _notaFiscalEntradaOriginal = NotaFiscalEntrada;
       _notaFiscalEntradaOriginalCommited = _notaFiscalEntradaOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
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
       _acrescimoOriginal = Acrescimo;
       _acrescimoOriginalCommited = _acrescimoOriginal;
       _descontoOriginal = Desconto;
       _descontoOriginalCommited = _descontoOriginal;
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
       _representanteOriginal = Representante;
       _representanteOriginalCommited = _representanteOriginal;
       _funcionarioOriginal = Funcionario;
       _funcionarioOriginalCommited = _funcionarioOriginal;
       _vendedorOriginal = Vendedor;
       _vendedorOriginalCommited = _vendedorOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _agrupadorContaOriginal = AgrupadorConta;
       _agrupadorContaOriginalCommited = _agrupadorContaOriginal;
       _idCredorOriginal = IdCredor;
       _idCredorOriginalCommited = _idCredorOriginal;
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
       _notaFiscalEntradaOriginalCommited = NotaFiscalEntrada;
       _fornecedorOriginalCommited = Fornecedor;
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
       _acrescimoOriginalCommited = Acrescimo;
       _descontoOriginalCommited = Desconto;
       _contaRecorrenteOriginalCommited = ContaRecorrente;
       _contaEmRevisaoOriginalCommited = ContaEmRevisao;
       _dataCadastroOriginalCommited = DataCadastro;
       _justificativaEstornoOriginalCommited = JustificativaEstorno;
       _idUsuarioEstornoOriginalCommited = IdUsuarioEstorno;
       _dataHoraEstornoOriginalCommited = DataHoraEstorno;
       _representanteOriginalCommited = Representante;
       _funcionarioOriginalCommited = Funcionario;
       _vendedorOriginalCommited = Vendedor;
       _dataOriginalCommited = Data;
       _agrupadorContaOriginalCommited = AgrupadorConta;
       _idCredorOriginalCommited = IdCredor;
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
               if (_valueCollectionLancamentoClassContaPagarLoaded) 
               {
                  if (_collectionLancamentoClassContaPagarRemovidos != null) 
                  {
                     _collectionLancamentoClassContaPagarRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLancamentoClassContaPagarRemovidos = new List<Entidades.LancamentoClass>();
                  }
                  _collectionLancamentoClassContaPagarOriginal= (from a in _valueCollectionLancamentoClassContaPagar select a.ID).ToList();
                  _valueCollectionLancamentoClassContaPagarChanged = false;
                  _valueCollectionLancamentoClassContaPagarCommitedChanged = false;
               }
               if (_valueCollectionMovimentoCaixaClassContaPagarLoaded) 
               {
                  if (_collectionMovimentoCaixaClassContaPagarRemovidos != null) 
                  {
                     _collectionMovimentoCaixaClassContaPagarRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMovimentoCaixaClassContaPagarRemovidos = new List<Entidades.MovimentoCaixaClass>();
                  }
                  _collectionMovimentoCaixaClassContaPagarOriginal= (from a in _valueCollectionMovimentoCaixaClassContaPagar select a.ID).ToList();
                  _valueCollectionMovimentoCaixaClassContaPagarChanged = false;
                  _valueCollectionMovimentoCaixaClassContaPagarCommitedChanged = false;
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
               NotaFiscalEntrada=_notaFiscalEntradaOriginal;
               _notaFiscalEntradaOriginalCommited=_notaFiscalEntradaOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
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
               Acrescimo=_acrescimoOriginal;
               _acrescimoOriginalCommited=_acrescimoOriginal;
               Desconto=_descontoOriginal;
               _descontoOriginalCommited=_descontoOriginal;
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
               Representante=_representanteOriginal;
               _representanteOriginalCommited=_representanteOriginal;
               Funcionario=_funcionarioOriginal;
               _funcionarioOriginalCommited=_funcionarioOriginal;
               Vendedor=_vendedorOriginal;
               _vendedorOriginalCommited=_vendedorOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               AgrupadorConta=_agrupadorContaOriginal;
               _agrupadorContaOriginalCommited=_agrupadorContaOriginal;
               IdCredor=_idCredorOriginal;
               _idCredorOriginalCommited=_idCredorOriginal;
               UsuarioBaixa=_usuarioBaixaOriginal;
               _usuarioBaixaOriginalCommited=_usuarioBaixaOriginal;
               DataBaixa=_dataBaixaOriginal;
               _dataBaixaOriginalCommited=_dataBaixaOriginal;
               DescricaoMeioPagtoOutros=_descricaoMeioPagtoOutrosOriginal;
               _descricaoMeioPagtoOutrosOriginalCommited=_descricaoMeioPagtoOutrosOriginal;
               MeioPagamento=_meioPagamentoOriginal;
               _meioPagamentoOriginalCommited=_meioPagamentoOriginal;
               if (_valueCollectionLancamentoClassContaPagarLoaded) 
               {
                  CollectionLancamentoClassContaPagar.Clear();
                  foreach(int item in _collectionLancamentoClassContaPagarOriginal)
                  {
                    CollectionLancamentoClassContaPagar.Add(Entidades.LancamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLancamentoClassContaPagarRemovidos.Clear();
               }
               if (_valueCollectionMovimentoCaixaClassContaPagarLoaded) 
               {
                  CollectionMovimentoCaixaClassContaPagar.Clear();
                  foreach(int item in _collectionMovimentoCaixaClassContaPagarOriginal)
                  {
                    CollectionMovimentoCaixaClassContaPagar.Add(Entidades.MovimentoCaixaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMovimentoCaixaClassContaPagarRemovidos.Clear();
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
               if (_valueCollectionLancamentoClassContaPagarLoaded) 
               {
                  if (_valueCollectionLancamentoClassContaPagarChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMovimentoCaixaClassContaPagarLoaded) 
               {
                  if (_valueCollectionMovimentoCaixaClassContaPagarChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLancamentoClassContaPagarLoaded) 
               {
                   tempRet = CollectionLancamentoClassContaPagar.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMovimentoCaixaClassContaPagarLoaded) 
               {
                   tempRet = CollectionMovimentoCaixaClassContaPagar.Any(item => item.IsDirty());
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
       if (_notaFiscalEntradaOriginal!=null)
       {
          dirty = !_notaFiscalEntradaOriginal.Equals(NotaFiscalEntrada);
       }
       else
       {
            dirty = NotaFiscalEntrada != null;
       }
      if (dirty) return true;
       if (_fornecedorOriginal!=null)
       {
          dirty = !_fornecedorOriginal.Equals(Fornecedor);
       }
       else
       {
            dirty = Fornecedor != null;
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
       dirty = _acrescimoOriginal != Acrescimo;
      if (dirty) return true;
       dirty = _descontoOriginal != Desconto;
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
       if (_representanteOriginal!=null)
       {
          dirty = !_representanteOriginal.Equals(Representante);
       }
       else
       {
            dirty = Representante != null;
       }
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
       if (_vendedorOriginal!=null)
       {
          dirty = !_vendedorOriginal.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       dirty = _dataOriginal != Data;
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
       dirty = _idCredorOriginal != IdCredor;
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
               if (_valueCollectionLancamentoClassContaPagarLoaded) 
               {
                  if (_valueCollectionLancamentoClassContaPagarCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMovimentoCaixaClassContaPagarLoaded) 
               {
                  if (_valueCollectionMovimentoCaixaClassContaPagarCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLancamentoClassContaPagarLoaded) 
               {
                   tempRet = CollectionLancamentoClassContaPagar.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMovimentoCaixaClassContaPagarLoaded) 
               {
                   tempRet = CollectionMovimentoCaixaClassContaPagar.Any(item => item.IsDirtyCommited());
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
       if (_notaFiscalEntradaOriginalCommited!=null)
       {
          dirty = !_notaFiscalEntradaOriginalCommited.Equals(NotaFiscalEntrada);
       }
       else
       {
            dirty = NotaFiscalEntrada != null;
       }
      if (dirty) return true;
       if (_fornecedorOriginalCommited!=null)
       {
          dirty = !_fornecedorOriginalCommited.Equals(Fornecedor);
       }
       else
       {
            dirty = Fornecedor != null;
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
       dirty = _acrescimoOriginalCommited != Acrescimo;
      if (dirty) return true;
       dirty = _descontoOriginalCommited != Desconto;
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
       if (_representanteOriginalCommited!=null)
       {
          dirty = !_representanteOriginalCommited.Equals(Representante);
       }
       else
       {
            dirty = Representante != null;
       }
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
       if (_vendedorOriginalCommited!=null)
       {
          dirty = !_vendedorOriginalCommited.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
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
       dirty = _idCredorOriginalCommited != IdCredor;
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
               if (_valueCollectionLancamentoClassContaPagarLoaded) 
               {
                  foreach(LancamentoClass item in CollectionLancamentoClassContaPagar)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMovimentoCaixaClassContaPagarLoaded) 
               {
                  foreach(MovimentoCaixaClass item in CollectionMovimentoCaixaClassContaPagar)
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
             case "NotaFiscalEntrada":
                return this.NotaFiscalEntrada;
             case "Fornecedor":
                return this.Fornecedor;
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
             case "Acrescimo":
                return this.Acrescimo;
             case "Desconto":
                return this.Desconto;
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
             case "Representante":
                return this.Representante;
             case "Funcionario":
                return this.Funcionario;
             case "Vendedor":
                return this.Vendedor;
             case "Data":
                return this.Data;
             case "AgrupadorConta":
                return this.AgrupadorConta;
             case "IdCredor":
                return this.IdCredor;
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
             if (NotaFiscalEntrada!=null)
                NotaFiscalEntrada.ChangeSingleConnection(newConnection);
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (ConciliacaoBancaria!=null)
                ConciliacaoBancaria.ChangeSingleConnection(newConnection);
             if (ContaRecorrente!=null)
                ContaRecorrente.ChangeSingleConnection(newConnection);
             if (Representante!=null)
                Representante.ChangeSingleConnection(newConnection);
             if (Funcionario!=null)
                Funcionario.ChangeSingleConnection(newConnection);
             if (Vendedor!=null)
                Vendedor.ChangeSingleConnection(newConnection);
             if (AgrupadorConta!=null)
                AgrupadorConta.ChangeSingleConnection(newConnection);
             if (MeioPagamento!=null)
                MeioPagamento.ChangeSingleConnection(newConnection);
               if (_valueCollectionLancamentoClassContaPagarLoaded) 
               {
                  foreach(LancamentoClass item in CollectionLancamentoClassContaPagar)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMovimentoCaixaClassContaPagarLoaded) 
               {
                  foreach(MovimentoCaixaClass item in CollectionMovimentoCaixaClassContaPagar)
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
                  command.CommandText += " COUNT(conta_pagar.id_conta_pagar) " ;
               }
               else
               {
               command.CommandText += "conta_pagar.id_conta_pagar, " ;
               command.CommandText += "conta_pagar.id_tipo_pagamento, " ;
               command.CommandText += "conta_pagar.id_nota_fiscal_entrada, " ;
               command.CommandText += "conta_pagar.id_fornecedor, " ;
               command.CommandText += "conta_pagar.id_centro_custo_lucro, " ;
               command.CommandText += "conta_pagar.id_conta_bancaria, " ;
               command.CommandText += "conta_pagar.cop_num_documento, " ;
               command.CommandText += "conta_pagar.cop_data_vencimento, " ;
               command.CommandText += "conta_pagar.cop_valor, " ;
               command.CommandText += "conta_pagar.cop_data_pagamento, " ;
               command.CommandText += "conta_pagar.cop_valor_pago, " ;
               command.CommandText += "conta_pagar.cop_historico, " ;
               command.CommandText += "conta_pagar.cop_data_emissao, " ;
               command.CommandText += "conta_pagar.entity_uid, " ;
               command.CommandText += "conta_pagar.version, " ;
               command.CommandText += "conta_pagar.id_conciliacao_bancaria, " ;
               command.CommandText += "conta_pagar.cop_acrescimo, " ;
               command.CommandText += "conta_pagar.cop_desconto, " ;
               command.CommandText += "conta_pagar.id_conta_recorrente, " ;
               command.CommandText += "conta_pagar.cop_conta_em_revisao, " ;
               command.CommandText += "conta_pagar.cop_data_cadastro, " ;
               command.CommandText += "conta_pagar.cop_justificativa_estorno, " ;
               command.CommandText += "conta_pagar.id_usuario_estorno, " ;
               command.CommandText += "conta_pagar.cop_data_hora_estorno, " ;
               command.CommandText += "conta_pagar.id_representante, " ;
               command.CommandText += "conta_pagar.id_funcionario, " ;
               command.CommandText += "conta_pagar.id_vendedor, " ;
               command.CommandText += "conta_pagar.data, " ;
               command.CommandText += "conta_pagar.id_agrupador_conta, " ;
               command.CommandText += "conta_pagar.id_credor, " ;
               command.CommandText += "conta_pagar.cop_usuario_baixa, " ;
               command.CommandText += "conta_pagar.cop_data_baixa, " ;
               command.CommandText += "conta_pagar.cop_descricao_meio_pagto_outros, " ;
               command.CommandText += "conta_pagar.id_meio_pagamento " ;
               }
               command.CommandText += " FROM  conta_pagar ";
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
                        orderByClause += " , cop_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(cop_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = conta_pagar.id_acs_usuario_ultima_revisao ";
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
                     case "id_conta_pagar":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.id_conta_pagar " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.id_conta_pagar) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_tipo_pagamento":
                     case "TipoPagamento":
                     command.CommandText += " LEFT JOIN tipo_pagamento as tipo_pagamento_TipoPagamento ON tipo_pagamento_TipoPagamento.id_tipo_pagamento = conta_pagar.id_tipo_pagamento ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_nota_fiscal_entrada":
                     case "NotaFiscalEntrada":
                     command.CommandText += " LEFT JOIN nota_fiscal_entrada as nota_fiscal_entrada_NotaFiscalEntrada ON nota_fiscal_entrada_NotaFiscalEntrada.id_nota_fiscal_entrada = conta_pagar.id_nota_fiscal_entrada ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_NotaFiscalEntrada.id_nota_fiscal_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_NotaFiscalEntrada.id_nota_fiscal_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = conta_pagar.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor_Fornecedor.for_nome_fantasia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor_Fornecedor.for_nome_fantasia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_centro_custo_lucro":
                     case "CentroCustoLucro":
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = conta_pagar.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = conta_pagar.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
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
                     case "cop_num_documento":
                     case "NumDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_pagar.cop_num_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_pagar.cop_num_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_data_vencimento":
                     case "DataVencimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_data_vencimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_data_vencimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_data_pagamento":
                     case "DataPagamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_data_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_data_pagamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_valor_pago":
                     case "ValorPago":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_valor_pago " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_valor_pago) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_historico":
                     case "Historico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_pagar.cop_historico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_pagar.cop_historico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_data_emissao":
                     case "DataEmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_data_emissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_data_emissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_pagar.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_pagar.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , conta_pagar.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conciliacao_bancaria":
                     case "ConciliacaoBancaria":
                     command.CommandText += " LEFT JOIN conciliacao_bancaria as conciliacao_bancaria_ConciliacaoBancaria ON conciliacao_bancaria_ConciliacaoBancaria.id_conciliacao_bancaria = conta_pagar.id_conciliacao_bancaria ";                     switch (parametro.TipoOrdenacao)
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
                     case "cop_acrescimo":
                     case "Acrescimo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_acrescimo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_acrescimo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_desconto":
                     case "Desconto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_desconto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_desconto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_recorrente":
                     case "ContaRecorrente":
                     command.CommandText += " LEFT JOIN conta_recorrente as conta_recorrente_ContaRecorrente ON conta_recorrente_ContaRecorrente.id_conta_recorrente = conta_pagar.id_conta_recorrente ";                     switch (parametro.TipoOrdenacao)
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
                     case "cop_conta_em_revisao":
                     case "ContaEmRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_conta_em_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_conta_em_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_data_cadastro":
                     case "DataCadastro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_data_cadastro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_data_cadastro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_justificativa_estorno":
                     case "JustificativaEstorno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_pagar.cop_justificativa_estorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_pagar.cop_justificativa_estorno) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , conta_pagar.id_usuario_estorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.id_usuario_estorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_data_hora_estorno":
                     case "DataHoraEstorno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_data_hora_estorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_data_hora_estorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_representante":
                     case "Representante":
                     command.CommandText += " LEFT JOIN representante as representante_Representante ON representante_Representante.id_representante = conta_pagar.id_representante ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_funcionario":
                     case "Funcionario":
                     command.CommandText += " LEFT JOIN funcionario as funcionario_Funcionario ON funcionario_Funcionario.id_funcionario = conta_pagar.id_funcionario ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_vendedor":
                     case "Vendedor":
                     command.CommandText += " LEFT JOIN vendedor as vendedor_Vendedor ON vendedor_Vendedor.id_vendedor = conta_pagar.id_vendedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_agrupador_conta":
                     case "AgrupadorConta":
                     orderByClause += " , conta_pagar.id_agrupador_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_credor":
                     case "IdCredor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.id_credor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.id_credor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_usuario_baixa":
                     case "UsuarioBaixa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_pagar.cop_usuario_baixa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_pagar.cop_usuario_baixa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_data_baixa":
                     case "DataBaixa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_pagar.cop_data_baixa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_pagar.cop_data_baixa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cop_descricao_meio_pagto_outros":
                     case "DescricaoMeioPagtoOutros":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_pagar.cop_descricao_meio_pagto_outros " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_pagar.cop_descricao_meio_pagto_outros) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_meio_pagamento":
                     case "MeioPagamento":
                     orderByClause += " , conta_pagar.id_meio_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cop_num_documento")) 
                        {
                           whereClause += " OR UPPER(conta_pagar.cop_num_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_pagar.cop_num_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cop_historico")) 
                        {
                           whereClause += " OR UPPER(conta_pagar.cop_historico) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_pagar.cop_historico) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(conta_pagar.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_pagar.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cop_justificativa_estorno")) 
                        {
                           whereClause += " OR UPPER(conta_pagar.cop_justificativa_estorno) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_pagar.cop_justificativa_estorno) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cop_usuario_baixa")) 
                        {
                           whereClause += " OR UPPER(conta_pagar.cop_usuario_baixa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_pagar.cop_usuario_baixa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cop_descricao_meio_pagto_outros")) 
                        {
                           whereClause += " OR UPPER(conta_pagar.cop_descricao_meio_pagto_outros) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_pagar.cop_descricao_meio_pagto_outros) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_conta_pagar")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.id_conta_pagar IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_conta_pagar = :conta_pagar_ID_2474 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_ID_2474", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  conta_pagar.id_tipo_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_tipo_pagamento = :conta_pagar_TipoPagamento_8878 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_TipoPagamento_8878", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaFiscalEntrada" || parametro.FieldName == "id_nota_fiscal_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.NotaFiscalEntradaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.NotaFiscalEntradaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.id_nota_fiscal_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_nota_fiscal_entrada = :conta_pagar_NotaFiscalEntrada_8202 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_NotaFiscalEntrada_8202", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fornecedor" || parametro.FieldName == "id_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FornecedorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FornecedorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_fornecedor = :conta_pagar_Fornecedor_5739 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Fornecedor_5739", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_pagar.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_centro_custo_lucro = :conta_pagar_CentroCustoLucro_8620 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_CentroCustoLucro_8620", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_pagar.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_conta_bancaria = :conta_pagar_ContaBancaria_7976 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_ContaBancaria_7976", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumDocumento" || parametro.FieldName == "cop_num_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_num_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_num_documento LIKE :conta_pagar_NumDocumento_53 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_NumDocumento_53", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataVencimento" || parametro.FieldName == "cop_data_vencimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_data_vencimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_data_vencimento = :conta_pagar_DataVencimento_4173 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_DataVencimento_4173", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "cop_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_valor = :conta_pagar_Valor_884 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Valor_884", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataPagamento" || parametro.FieldName == "cop_data_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_data_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_data_pagamento = :conta_pagar_DataPagamento_3689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_DataPagamento_3689", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorPago" || parametro.FieldName == "cop_valor_pago")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_valor_pago IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_valor_pago = :conta_pagar_ValorPago_5054 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_ValorPago_5054", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Historico" || parametro.FieldName == "cop_historico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_historico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_historico LIKE :conta_pagar_Historico_3394 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Historico_3394", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEmissao" || parametro.FieldName == "cop_data_emissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_data_emissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_data_emissao = :conta_pagar_DataEmissao_6649 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_DataEmissao_6649", NpgsqlDbType.Date, parametro.Fieldvalue));
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
                         whereClause += "  conta_pagar.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.entity_uid LIKE :conta_pagar_EntityUid_2997 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_EntityUid_2997", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  conta_pagar.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.version = :conta_pagar_Version_8899 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Version_8899", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  conta_pagar.id_conciliacao_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_conciliacao_bancaria = :conta_pagar_ConciliacaoBancaria_5048 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_ConciliacaoBancaria_5048", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Acrescimo" || parametro.FieldName == "cop_acrescimo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_acrescimo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_acrescimo = :conta_pagar_Acrescimo_4316 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Acrescimo_4316", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Desconto" || parametro.FieldName == "cop_desconto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_desconto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_desconto = :conta_pagar_Desconto_7183 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Desconto_7183", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  conta_pagar.id_conta_recorrente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_conta_recorrente = :conta_pagar_ContaRecorrente_6771 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_ContaRecorrente_6771", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaEmRevisao" || parametro.FieldName == "cop_conta_em_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_conta_em_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_conta_em_revisao = :conta_pagar_ContaEmRevisao_7792 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_ContaEmRevisao_7792", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCadastro" || parametro.FieldName == "cop_data_cadastro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_data_cadastro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_data_cadastro = :conta_pagar_DataCadastro_1114 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_DataCadastro_1114", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaEstorno" || parametro.FieldName == "cop_justificativa_estorno")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_justificativa_estorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_justificativa_estorno LIKE :conta_pagar_JustificativaEstorno_7977 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_JustificativaEstorno_7977", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  conta_pagar.id_usuario_estorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_usuario_estorno = :conta_pagar_IdUsuarioEstorno_5866 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_IdUsuarioEstorno_5866", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataHoraEstorno" || parametro.FieldName == "cop_data_hora_estorno")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_data_hora_estorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_data_hora_estorno = :conta_pagar_DataHoraEstorno_6967 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_DataHoraEstorno_6967", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  conta_pagar.id_representante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_representante = :conta_pagar_Representante_2118 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Representante_2118", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_pagar.id_funcionario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_funcionario = :conta_pagar_Funcionario_7833 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Funcionario_7833", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_pagar.id_vendedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_vendedor = :conta_pagar_Vendedor_7486 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Vendedor_7486", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.data = :conta_pagar_Data_691 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Data_691", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  conta_pagar.id_agrupador_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_agrupador_conta = :conta_pagar_AgrupadorConta_296 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_AgrupadorConta_296", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdCredor" || parametro.FieldName == "id_credor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.id_credor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_credor = :conta_pagar_IdCredor_4401 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_IdCredor_4401", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioBaixa" || parametro.FieldName == "cop_usuario_baixa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_usuario_baixa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_usuario_baixa LIKE :conta_pagar_UsuarioBaixa_7356 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_UsuarioBaixa_7356", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataBaixa" || parametro.FieldName == "cop_data_baixa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_data_baixa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_data_baixa = :conta_pagar_DataBaixa_1615 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_DataBaixa_1615", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoMeioPagtoOutros" || parametro.FieldName == "cop_descricao_meio_pagto_outros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_pagar.cop_descricao_meio_pagto_outros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_descricao_meio_pagto_outros LIKE :conta_pagar_DescricaoMeioPagtoOutros_3686 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_DescricaoMeioPagtoOutros_3686", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  conta_pagar.id_meio_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.id_meio_pagamento = :conta_pagar_MeioPagamento_8295 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_MeioPagamento_8295", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_pagar.cop_num_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_num_documento LIKE :conta_pagar_NumDocumento_7045 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_NumDocumento_7045", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_pagar.cop_historico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_historico LIKE :conta_pagar_Historico_2264 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_Historico_2264", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_pagar.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.entity_uid LIKE :conta_pagar_EntityUid_5990 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_EntityUid_5990", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_pagar.cop_justificativa_estorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_justificativa_estorno LIKE :conta_pagar_JustificativaEstorno_7109 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_JustificativaEstorno_7109", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_pagar.cop_usuario_baixa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_usuario_baixa LIKE :conta_pagar_UsuarioBaixa_6822 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_UsuarioBaixa_6822", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_pagar.cop_descricao_meio_pagto_outros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_pagar.cop_descricao_meio_pagto_outros LIKE :conta_pagar_DescricaoMeioPagtoOutros_6753 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_pagar_DescricaoMeioPagtoOutros_6753", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ContaPagarClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ContaPagarClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ContaPagarClass), Convert.ToInt32(read["id_conta_pagar"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ContaPagarClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_conta_pagar"]);
                     if (read["id_tipo_pagamento"] != DBNull.Value)
                     {
                        entidade.TipoPagamento = (BibliotecaEntidades.Entidades.TipoPagamentoClass)BibliotecaEntidades.Entidades.TipoPagamentoClass.GetEntidade(Convert.ToInt32(read["id_tipo_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.TipoPagamento = null ;
                     }
                     if (read["id_nota_fiscal_entrada"] != DBNull.Value)
                     {
                        entidade.NotaFiscalEntrada = (BibliotecaEntidades.Entidades.NotaFiscalEntradaClass)BibliotecaEntidades.Entidades.NotaFiscalEntradaClass.GetEntidade(Convert.ToInt32(read["id_nota_fiscal_entrada"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NotaFiscalEntrada = null ;
                     }
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
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
                     entidade.NumDocumento = (read["cop_num_documento"] != DBNull.Value ? read["cop_num_documento"].ToString() : null);
                     entidade.DataVencimento = (DateTime)read["cop_data_vencimento"];
                     entidade.Valor = (double)read["cop_valor"];
                     entidade.DataPagamento = read["cop_data_pagamento"] as DateTime?;
                     entidade.ValorPago = read["cop_valor_pago"] as double?;
                     entidade.Historico = (read["cop_historico"] != DBNull.Value ? read["cop_historico"].ToString() : null);
                     entidade.DataEmissao = (DateTime)read["cop_data_emissao"];
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
                     entidade.Acrescimo = (double)read["cop_acrescimo"];
                     entidade.Desconto = (double)read["cop_desconto"];
                     if (read["id_conta_recorrente"] != DBNull.Value)
                     {
                        entidade.ContaRecorrente = (BibliotecaEntidades.Entidades.ContaRecorrenteClass)BibliotecaEntidades.Entidades.ContaRecorrenteClass.GetEntidade(Convert.ToInt32(read["id_conta_recorrente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaRecorrente = null ;
                     }
                     entidade.ContaEmRevisao = Convert.ToBoolean(Convert.ToInt16(read["cop_conta_em_revisao"]));
                     entidade.DataCadastro = (DateTime)read["cop_data_cadastro"];
                     entidade.JustificativaEstorno = (read["cop_justificativa_estorno"] != DBNull.Value ? read["cop_justificativa_estorno"].ToString() : null);
                     entidade.IdUsuarioEstorno = read["id_usuario_estorno"] as int?;
                     entidade.DataHoraEstorno = read["cop_data_hora_estorno"] as DateTime?;
                     if (read["id_representante"] != DBNull.Value)
                     {
                        entidade.Representante = (BibliotecaEntidades.Entidades.RepresentanteClass)BibliotecaEntidades.Entidades.RepresentanteClass.GetEntidade(Convert.ToInt32(read["id_representante"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Representante = null ;
                     }
                     if (read["id_funcionario"] != DBNull.Value)
                     {
                        entidade.Funcionario = (BibliotecaEntidades.Entidades.FuncionarioClass)BibliotecaEntidades.Entidades.FuncionarioClass.GetEntidade(Convert.ToInt32(read["id_funcionario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Funcionario = null ;
                     }
                     if (read["id_vendedor"] != DBNull.Value)
                     {
                        entidade.Vendedor = (BibliotecaEntidades.Entidades.VendedorClass)BibliotecaEntidades.Entidades.VendedorClass.GetEntidade(Convert.ToInt32(read["id_vendedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Vendedor = null ;
                     }
                     entidade.Data = read["data"] as DateTime?;
                     if (read["id_agrupador_conta"] != DBNull.Value)
                     {
                        entidade.AgrupadorConta = (BibliotecaEntidades.Entidades.AgrupadorContaClass)BibliotecaEntidades.Entidades.AgrupadorContaClass.GetEntidade(Convert.ToInt32(read["id_agrupador_conta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AgrupadorConta = null ;
                     }
                     entidade.IdCredor = Convert.ToInt64(read["id_credor"]);
                     entidade.UsuarioBaixa = (read["cop_usuario_baixa"] != DBNull.Value ? read["cop_usuario_baixa"].ToString() : null);
                     entidade.DataBaixa = read["cop_data_baixa"] as DateTime?;
                     entidade.DescricaoMeioPagtoOutros = (read["cop_descricao_meio_pagto_outros"] != DBNull.Value ? read["cop_descricao_meio_pagto_outros"].ToString() : null);
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
                     entidade = (ContaPagarClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
