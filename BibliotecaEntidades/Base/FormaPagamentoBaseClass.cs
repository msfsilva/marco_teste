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
     [Table("forma_pagamento","fop")]
     public class FormaPagamentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do FormaPagamentoClass";
protected const string ErroDelete = "Erro ao excluir o FormaPagamentoClass  ";
protected const string ErroSave = "Erro ao salvar o FormaPagamentoClass.";
protected const string ErroCollectionClienteClassFormaPagamento = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionFornecedorClassFormaPagamento = "Erro ao carregar a coleção de FornecedorClass.";
protected const string ErroCollectionOrcamentoItemClassFormaPagamento = "Erro ao carregar a coleção de OrcamentoItemClass.";
protected const string ErroCollectionOrdemCompraClassFormaPagamento = "Erro ao carregar a coleção de OrdemCompraClass.";
protected const string ErroCollectionPedidoItemClassFormaPagamento = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroParcelasObrigatorio = "O campo Parcelas é obrigatório";
protected const string ErroParcelasComprimento = "O campo Parcelas deve ter no máximo 500 caracteres";
protected const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected const string ErroMeioPagamentoObrigatorio = "O campo MeioPagamento é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do FormaPagamentoClass.";
protected const string MensagemUtilizadoCollectionClienteClassFormaPagamento =  "A entidade FormaPagamentoClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionFornecedorClassFormaPagamento =  "A entidade FormaPagamentoClass está sendo utilizada nos seguintes FornecedorClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemClassFormaPagamento =  "A entidade FormaPagamentoClass está sendo utilizada nos seguintes OrcamentoItemClass:";
protected const string MensagemUtilizadoCollectionOrdemCompraClassFormaPagamento =  "A entidade FormaPagamentoClass está sendo utilizada nos seguintes OrdemCompraClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassFormaPagamento =  "A entidade FormaPagamentoClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade FormaPagamentoClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("fop_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("fop_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected bool _entradaOriginal{get;private set;}
       private bool _entradaOriginalCommited{get; set;}
        private bool _valueEntrada;
         [Column("fop_entrada")]
        public virtual bool Entrada
         { 
            get { return this._valueEntrada; } 
            set 
            { 
                if (this._valueEntrada == value)return;
                 this._valueEntrada = value; 
            } 
        } 

       protected int _diasEntradaOriginal{get;private set;}
       private int _diasEntradaOriginalCommited{get; set;}
        private int _valueDiasEntrada;
         [Column("fop_dias_entrada")]
        public virtual int DiasEntrada
         { 
            get { return this._valueDiasEntrada; } 
            set 
            { 
                if (this._valueDiasEntrada == value)return;
                 this._valueDiasEntrada = value; 
            } 
        } 

       protected int _periodicidadeOriginal{get;private set;}
       private int _periodicidadeOriginalCommited{get; set;}
        private int _valuePeriodicidade;
         [Column("fop_periodicidade")]
        public virtual int Periodicidade
         { 
            get { return this._valuePeriodicidade; } 
            set 
            { 
                if (this._valuePeriodicidade == value)return;
                 this._valuePeriodicidade = value; 
            } 
        } 

       protected int _quantidadeParcelasOriginal{get;private set;}
       private int _quantidadeParcelasOriginalCommited{get; set;}
        private int _valueQuantidadeParcelas;
         [Column("fop_quantidade_parcelas")]
        public virtual int QuantidadeParcelas
         { 
            get { return this._valueQuantidadeParcelas; } 
            set 
            { 
                if (this._valueQuantidadeParcelas == value)return;
                 this._valueQuantidadeParcelas = value; 
            } 
        } 

       protected int _ativoAntigoOriginal{get;private set;}
       private int _ativoAntigoOriginalCommited{get; set;}
        private int _valueAtivoAntigo;
         [Column("fop_ativo_antigo")]
        public virtual int AtivoAntigo
         { 
            get { return this._valueAtivoAntigo; } 
            set 
            { 
                if (this._valueAtivoAntigo == value)return;
                 this._valueAtivoAntigo = value; 
            } 
        } 

       protected string _observacaoOriginal{get;private set;}
       private string _observacaoOriginalCommited{get; set;}
        private string _valueObservacao;
         [Column("fop_observacao")]
        public virtual string Observacao
         { 
            get { return this._valueObservacao; } 
            set 
            { 
                if (this._valueObservacao == value)return;
                 this._valueObservacao = value; 
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

       protected string _descricaoMeioPagtoOutrosOriginal{get;private set;}
       private string _descricaoMeioPagtoOutrosOriginalCommited{get; set;}
        private string _valueDescricaoMeioPagtoOutros;
         [Column("fop_descricao_meio_pagto_outros")]
        public virtual string DescricaoMeioPagtoOutros
         { 
            get { return this._valueDescricaoMeioPagtoOutros; } 
            set 
            { 
                if (this._valueDescricaoMeioPagtoOutros == value)return;
                 this._valueDescricaoMeioPagtoOutros = value; 
            } 
        } 

       protected bool _possuiTaxaAdministracaoOriginal{get;private set;}
       private bool _possuiTaxaAdministracaoOriginalCommited{get; set;}
        private bool _valuePossuiTaxaAdministracao;
         [Column("fop_possui_taxa_administracao")]
        public virtual bool PossuiTaxaAdministracao
         { 
            get { return this._valuePossuiTaxaAdministracao; } 
            set 
            { 
                if (this._valuePossuiTaxaAdministracao == value)return;
                 this._valuePossuiTaxaAdministracao = value; 
            } 
        } 

       protected double _taxaAdministracaoOriginal{get;private set;}
       private double _taxaAdministracaoOriginalCommited{get; set;}
        private double _valueTaxaAdministracao;
         [Column("fop_taxa_administracao")]
        public virtual double TaxaAdministracao
         { 
            get { return this._valueTaxaAdministracao; } 
            set 
            { 
                if (this._valueTaxaAdministracao == value)return;
                 this._valueTaxaAdministracao = value; 
            } 
        } 

       protected long? _idPlanoContaTaxaAdministracaoOriginal{get;private set;}
       private long? _idPlanoContaTaxaAdministracaoOriginalCommited{get; set;}
        private long? _valueIdPlanoContaTaxaAdministracao;
         [Column("id_plano_conta_taxa_administracao")]
        public virtual long? IdPlanoContaTaxaAdministracao
         { 
            get { return this._valueIdPlanoContaTaxaAdministracao; } 
            set 
            { 
                if (this._valueIdPlanoContaTaxaAdministracao == value)return;
                 this._valueIdPlanoContaTaxaAdministracao = value; 
            } 
        } 

       protected bool _possuiTaxaAntecipacaoOriginal{get;private set;}
       private bool _possuiTaxaAntecipacaoOriginalCommited{get; set;}
        private bool _valuePossuiTaxaAntecipacao;
         [Column("fop_possui_taxa_antecipacao")]
        public virtual bool PossuiTaxaAntecipacao
         { 
            get { return this._valuePossuiTaxaAntecipacao; } 
            set 
            { 
                if (this._valuePossuiTaxaAntecipacao == value)return;
                 this._valuePossuiTaxaAntecipacao = value; 
            } 
        } 

       protected double _taxaAntecipacaoOriginal{get;private set;}
       private double _taxaAntecipacaoOriginalCommited{get; set;}
        private double _valueTaxaAntecipacao;
         [Column("fop_taxa_antecipacao")]
        public virtual double TaxaAntecipacao
         { 
            get { return this._valueTaxaAntecipacao; } 
            set 
            { 
                if (this._valueTaxaAntecipacao == value)return;
                 this._valueTaxaAntecipacao = value; 
            } 
        } 

       protected long? _idPlanoContaTaxaAntecipacaoOriginal{get;private set;}
       private long? _idPlanoContaTaxaAntecipacaoOriginalCommited{get; set;}
        private long? _valueIdPlanoContaTaxaAntecipacao;
         [Column("id_plano_conta_taxa_antecipacao")]
        public virtual long? IdPlanoContaTaxaAntecipacao
         { 
            get { return this._valueIdPlanoContaTaxaAntecipacao; } 
            set 
            { 
                if (this._valueIdPlanoContaTaxaAntecipacao == value)return;
                 this._valueIdPlanoContaTaxaAntecipacao = value; 
            } 
        } 

       protected string _parcelasOriginal{get;private set;}
       private string _parcelasOriginalCommited{get; set;}
        private string _valueParcelas;
         [Column("fop_parcelas")]
        public virtual string Parcelas
         { 
            get { return this._valueParcelas; } 
            set 
            { 
                if (this._valueParcelas == value)return;
                 this._valueParcelas = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("fop_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       private List<long> _collectionClienteClassFormaPagamentoOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassFormaPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassFormaPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassFormaPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassFormaPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassFormaPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassFormaPagamento 
       { 
           get { if(!_valueCollectionClienteClassFormaPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassFormaPagamento();}
return this._valueCollectionClienteClassFormaPagamento; } 
           set 
           { 
               this._valueCollectionClienteClassFormaPagamento = value; 
               this._valueCollectionClienteClassFormaPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionFornecedorClassFormaPagamentoOriginal;
       private List<Entidades.FornecedorClass > _collectionFornecedorClassFormaPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassFormaPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassFormaPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassFormaPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FornecedorClass> _valueCollectionFornecedorClassFormaPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FornecedorClass> CollectionFornecedorClassFormaPagamento 
       { 
           get { if(!_valueCollectionFornecedorClassFormaPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionFornecedorClassFormaPagamento();}
return this._valueCollectionFornecedorClassFormaPagamento; } 
           set 
           { 
               this._valueCollectionFornecedorClassFormaPagamento = value; 
               this._valueCollectionFornecedorClassFormaPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemClassFormaPagamentoOriginal;
       private List<Entidades.OrcamentoItemClass > _collectionOrcamentoItemClassFormaPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassFormaPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassFormaPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassFormaPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemClass> _valueCollectionOrcamentoItemClassFormaPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemClass> CollectionOrcamentoItemClassFormaPagamento 
       { 
           get { if(!_valueCollectionOrcamentoItemClassFormaPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemClassFormaPagamento();}
return this._valueCollectionOrcamentoItemClassFormaPagamento; } 
           set 
           { 
               this._valueCollectionOrcamentoItemClassFormaPagamento = value; 
               this._valueCollectionOrcamentoItemClassFormaPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemCompraClassFormaPagamentoOriginal;
       private List<Entidades.OrdemCompraClass > _collectionOrdemCompraClassFormaPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraClassFormaPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraClassFormaPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraClassFormaPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemCompraClass> _valueCollectionOrdemCompraClassFormaPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemCompraClass> CollectionOrdemCompraClassFormaPagamento 
       { 
           get { if(!_valueCollectionOrdemCompraClassFormaPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemCompraClassFormaPagamento();}
return this._valueCollectionOrdemCompraClassFormaPagamento; } 
           set 
           { 
               this._valueCollectionOrdemCompraClassFormaPagamento = value; 
               this._valueCollectionOrdemCompraClassFormaPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassFormaPagamentoOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassFormaPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassFormaPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassFormaPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassFormaPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassFormaPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassFormaPagamento 
       { 
           get { if(!_valueCollectionPedidoItemClassFormaPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassFormaPagamento();}
return this._valueCollectionPedidoItemClassFormaPagamento; } 
           set 
           { 
               this._valueCollectionPedidoItemClassFormaPagamento = value; 
               this._valueCollectionPedidoItemClassFormaPagamentoLoaded = true; 
           } 
       } 

        public FormaPagamentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.QuantidadeParcelas = 0;
           this.AtivoAntigo = 1;
           this.PossuiTaxaAdministracao = false;
           this.TaxaAdministracao = 0;
           this.PossuiTaxaAntecipacao = false;
           this.TaxaAntecipacao = 0;
           this.Parcelas = "";
           this.Ativo = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static FormaPagamentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (FormaPagamentoClass) GetEntity(typeof(FormaPagamentoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionClienteClassFormaPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassFormaPagamentoChanged = true;
                  _valueCollectionClienteClassFormaPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassFormaPagamentoChanged = true; 
                  _valueCollectionClienteClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassFormaPagamentoChanged = true; 
                  _valueCollectionClienteClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassFormaPagamento) 
                 { 
                     _collectionClienteClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassFormaPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassFormaPagamentoChanged = false;
                 _valueCollectionClienteClassFormaPagamentoCommitedChanged = false;
                _collectionClienteClassFormaPagamentoRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FormaPagamento", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassFormaPagamento = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassFormaPagamentoOriginal= (from a in _valueCollectionClienteClassFormaPagamento select a.ID).ToList();
                 _valueCollectionClienteClassFormaPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassFormaPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassFormaPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFornecedorClassFormaPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFornecedorClassFormaPagamentoChanged = true;
                  _valueCollectionFornecedorClassFormaPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFornecedorClassFormaPagamentoChanged = true; 
                  _valueCollectionFornecedorClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in e.OldItems) 
                 { 
                     _collectionFornecedorClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFornecedorClassFormaPagamentoChanged = true; 
                  _valueCollectionFornecedorClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in _valueCollectionFornecedorClassFormaPagamento) 
                 { 
                     _collectionFornecedorClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFornecedorClassFormaPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.FornecedorClass> oc;
                _valueCollectionFornecedorClassFormaPagamentoChanged = false;
                 _valueCollectionFornecedorClassFormaPagamentoCommitedChanged = false;
                _collectionFornecedorClassFormaPagamentoRemovidos = new List<Entidades.FornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FornecedorClass>();
                }
                else{ 
                   Entidades.FornecedorClass search = new Entidades.FornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FormaPagamento", this),                     }                       ).Cast<Entidades.FornecedorClass>().ToList());
                 }
                 _valueCollectionFornecedorClassFormaPagamento = new BindingList<Entidades.FornecedorClass>(oc); 
                 _collectionFornecedorClassFormaPagamentoOriginal= (from a in _valueCollectionFornecedorClassFormaPagamento select a.ID).ToList();
                 _valueCollectionFornecedorClassFormaPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionFornecedorClassFormaPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFornecedorClassFormaPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemClassFormaPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemClassFormaPagamentoChanged = true;
                  _valueCollectionOrcamentoItemClassFormaPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemClassFormaPagamentoChanged = true; 
                  _valueCollectionOrcamentoItemClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemClassFormaPagamentoChanged = true; 
                  _valueCollectionOrcamentoItemClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in _valueCollectionOrcamentoItemClassFormaPagamento) 
                 { 
                     _collectionOrcamentoItemClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemClassFormaPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemClass> oc;
                _valueCollectionOrcamentoItemClassFormaPagamentoChanged = false;
                 _valueCollectionOrcamentoItemClassFormaPagamentoCommitedChanged = false;
                _collectionOrcamentoItemClassFormaPagamentoRemovidos = new List<Entidades.OrcamentoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemClass>();
                }
                else{ 
                   Entidades.OrcamentoItemClass search = new Entidades.OrcamentoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FormaPagamento", this),                     }                       ).Cast<Entidades.OrcamentoItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemClassFormaPagamento = new BindingList<Entidades.OrcamentoItemClass>(oc); 
                 _collectionOrcamentoItemClassFormaPagamentoOriginal= (from a in _valueCollectionOrcamentoItemClassFormaPagamento select a.ID).ToList();
                 _valueCollectionOrcamentoItemClassFormaPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemClassFormaPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemClassFormaPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemCompraClassFormaPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemCompraClassFormaPagamentoChanged = true;
                  _valueCollectionOrdemCompraClassFormaPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemCompraClassFormaPagamentoChanged = true; 
                  _valueCollectionOrdemCompraClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.OrdemCompraClass item in e.OldItems) 
                 { 
                     _collectionOrdemCompraClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemCompraClassFormaPagamentoChanged = true; 
                  _valueCollectionOrdemCompraClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.OrdemCompraClass item in _valueCollectionOrdemCompraClassFormaPagamento) 
                 { 
                     _collectionOrdemCompraClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemCompraClassFormaPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemCompraClass> oc;
                _valueCollectionOrdemCompraClassFormaPagamentoChanged = false;
                 _valueCollectionOrdemCompraClassFormaPagamentoCommitedChanged = false;
                _collectionOrdemCompraClassFormaPagamentoRemovidos = new List<Entidades.OrdemCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemCompraClass>();
                }
                else{ 
                   Entidades.OrdemCompraClass search = new Entidades.OrdemCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FormaPagamento", this),                     }                       ).Cast<Entidades.OrdemCompraClass>().ToList());
                 }
                 _valueCollectionOrdemCompraClassFormaPagamento = new BindingList<Entidades.OrdemCompraClass>(oc); 
                 _collectionOrdemCompraClassFormaPagamentoOriginal= (from a in _valueCollectionOrdemCompraClassFormaPagamento select a.ID).ToList();
                 _valueCollectionOrdemCompraClassFormaPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemCompraClassFormaPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemCompraClassFormaPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassFormaPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassFormaPagamentoChanged = true;
                  _valueCollectionPedidoItemClassFormaPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassFormaPagamentoChanged = true; 
                  _valueCollectionPedidoItemClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassFormaPagamentoChanged = true; 
                  _valueCollectionPedidoItemClassFormaPagamentoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassFormaPagamento) 
                 { 
                     _collectionPedidoItemClassFormaPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassFormaPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassFormaPagamentoChanged = false;
                 _valueCollectionPedidoItemClassFormaPagamentoCommitedChanged = false;
                _collectionPedidoItemClassFormaPagamentoRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("FormaPagamento", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassFormaPagamento = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassFormaPagamentoOriginal= (from a in _valueCollectionPedidoItemClassFormaPagamento select a.ID).ToList();
                 _valueCollectionPedidoItemClassFormaPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassFormaPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassFormaPagamento+"\r\n" + e.Message, e);
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
                if (string.IsNullOrEmpty(Parcelas))
                {
                    throw new Exception(ErroParcelasObrigatorio);
                }
                if (Parcelas.Length >500)
                {
                    throw new Exception( ErroParcelasComprimento);
                }
                if ( _valueContaBancaria == null)
                {
                    throw new Exception(ErroContaBancariaObrigatorio);
                }
                if ( _valueMeioPagamento == null)
                {
                    throw new Exception(ErroMeioPagamentoObrigatorio);
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
                    "  public.forma_pagamento  " +
                    "WHERE " +
                    "  id_forma_pagamento = :id";
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
                        "  public.forma_pagamento   " +
                        "SET  " + 
                        "  fop_identificacao = :fop_identificacao, " + 
                        "  fop_descricao = :fop_descricao, " + 
                        "  fop_entrada = :fop_entrada, " + 
                        "  fop_dias_entrada = :fop_dias_entrada, " + 
                        "  fop_periodicidade = :fop_periodicidade, " + 
                        "  fop_quantidade_parcelas = :fop_quantidade_parcelas, " + 
                        "  fop_ativo_antigo = :fop_ativo_antigo, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  fop_observacao = :fop_observacao, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  id_meio_pagamento = :id_meio_pagamento, " + 
                        "  fop_descricao_meio_pagto_outros = :fop_descricao_meio_pagto_outros, " + 
                        "  fop_possui_taxa_administracao = :fop_possui_taxa_administracao, " + 
                        "  fop_taxa_administracao = :fop_taxa_administracao, " + 
                        "  id_plano_conta_taxa_administracao = :id_plano_conta_taxa_administracao, " + 
                        "  fop_possui_taxa_antecipacao = :fop_possui_taxa_antecipacao, " + 
                        "  fop_taxa_antecipacao = :fop_taxa_antecipacao, " + 
                        "  id_plano_conta_taxa_antecipacao = :id_plano_conta_taxa_antecipacao, " + 
                        "  fop_parcelas = :fop_parcelas, " + 
                        "  fop_ativo = :fop_ativo "+
                        "WHERE  " +
                        "  id_forma_pagamento = :id " +
                        "RETURNING id_forma_pagamento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.forma_pagamento " +
                        "( " +
                        "  fop_identificacao , " + 
                        "  fop_descricao , " + 
                        "  fop_entrada , " + 
                        "  fop_dias_entrada , " + 
                        "  fop_periodicidade , " + 
                        "  fop_quantidade_parcelas , " + 
                        "  fop_ativo_antigo , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  fop_observacao , " + 
                        "  id_conta_bancaria , " + 
                        "  id_meio_pagamento , " + 
                        "  fop_descricao_meio_pagto_outros , " + 
                        "  fop_possui_taxa_administracao , " + 
                        "  fop_taxa_administracao , " + 
                        "  id_plano_conta_taxa_administracao , " + 
                        "  fop_possui_taxa_antecipacao , " + 
                        "  fop_taxa_antecipacao , " + 
                        "  id_plano_conta_taxa_antecipacao , " + 
                        "  fop_parcelas , " + 
                        "  fop_ativo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :fop_identificacao , " + 
                        "  :fop_descricao , " + 
                        "  :fop_entrada , " + 
                        "  :fop_dias_entrada , " + 
                        "  :fop_periodicidade , " + 
                        "  :fop_quantidade_parcelas , " + 
                        "  :fop_ativo_antigo , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :fop_observacao , " + 
                        "  :id_conta_bancaria , " + 
                        "  :id_meio_pagamento , " + 
                        "  :fop_descricao_meio_pagto_outros , " + 
                        "  :fop_possui_taxa_administracao , " + 
                        "  :fop_taxa_administracao , " + 
                        "  :id_plano_conta_taxa_administracao , " + 
                        "  :fop_possui_taxa_antecipacao , " + 
                        "  :fop_taxa_antecipacao , " + 
                        "  :id_plano_conta_taxa_antecipacao , " + 
                        "  :fop_parcelas , " + 
                        "  :fop_ativo  "+
                        ")RETURNING id_forma_pagamento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_entrada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Entrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_dias_entrada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DiasEntrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_periodicidade", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Periodicidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_quantidade_parcelas", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeParcelas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_ativo_antigo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AtivoAntigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_meio_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.MeioPagamento==null ? (object) DBNull.Value : this.MeioPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_descricao_meio_pagto_outros", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoMeioPagtoOutros ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_possui_taxa_administracao", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PossuiTaxaAdministracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_taxa_administracao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TaxaAdministracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_plano_conta_taxa_administracao", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdPlanoContaTaxaAdministracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_possui_taxa_antecipacao", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PossuiTaxaAntecipacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_taxa_antecipacao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TaxaAntecipacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_plano_conta_taxa_antecipacao", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdPlanoContaTaxaAntecipacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_parcelas", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Parcelas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fop_ativo", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;

 
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
 if (CollectionClienteClassFormaPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassFormaPagamento+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassFormaPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFornecedorClassFormaPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFornecedorClassFormaPagamento+"\r\n";
                foreach (Entidades.FornecedorClass tmp in CollectionFornecedorClassFormaPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemClassFormaPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassFormaPagamento+"\r\n";
                foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassFormaPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemCompraClassFormaPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemCompraClassFormaPagamento+"\r\n";
                foreach (Entidades.OrdemCompraClass tmp in CollectionOrdemCompraClassFormaPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassFormaPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassFormaPagamento+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassFormaPagamento)
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
        public static FormaPagamentoClass CopiarEntidade(FormaPagamentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               FormaPagamentoClass toRet = new FormaPagamentoClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Entrada= entidadeCopiar.Entrada;
 toRet.DiasEntrada= entidadeCopiar.DiasEntrada;
 toRet.Periodicidade= entidadeCopiar.Periodicidade;
 toRet.QuantidadeParcelas= entidadeCopiar.QuantidadeParcelas;
 toRet.AtivoAntigo= entidadeCopiar.AtivoAntigo;
 toRet.Observacao= entidadeCopiar.Observacao;
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.MeioPagamento= entidadeCopiar.MeioPagamento;
 toRet.DescricaoMeioPagtoOutros= entidadeCopiar.DescricaoMeioPagtoOutros;
 toRet.PossuiTaxaAdministracao= entidadeCopiar.PossuiTaxaAdministracao;
 toRet.TaxaAdministracao= entidadeCopiar.TaxaAdministracao;
 toRet.IdPlanoContaTaxaAdministracao= entidadeCopiar.IdPlanoContaTaxaAdministracao;
 toRet.PossuiTaxaAntecipacao= entidadeCopiar.PossuiTaxaAntecipacao;
 toRet.TaxaAntecipacao= entidadeCopiar.TaxaAntecipacao;
 toRet.IdPlanoContaTaxaAntecipacao= entidadeCopiar.IdPlanoContaTaxaAntecipacao;
 toRet.Parcelas= entidadeCopiar.Parcelas;
 toRet.Ativo= entidadeCopiar.Ativo;

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
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _entradaOriginal = Entrada;
       _entradaOriginalCommited = _entradaOriginal;
       _diasEntradaOriginal = DiasEntrada;
       _diasEntradaOriginalCommited = _diasEntradaOriginal;
       _periodicidadeOriginal = Periodicidade;
       _periodicidadeOriginalCommited = _periodicidadeOriginal;
       _quantidadeParcelasOriginal = QuantidadeParcelas;
       _quantidadeParcelasOriginalCommited = _quantidadeParcelasOriginal;
       _ativoAntigoOriginal = AtivoAntigo;
       _ativoAntigoOriginalCommited = _ativoAntigoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _observacaoOriginal = Observacao;
       _observacaoOriginalCommited = _observacaoOriginal;
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _meioPagamentoOriginal = MeioPagamento;
       _meioPagamentoOriginalCommited = _meioPagamentoOriginal;
       _descricaoMeioPagtoOutrosOriginal = DescricaoMeioPagtoOutros;
       _descricaoMeioPagtoOutrosOriginalCommited = _descricaoMeioPagtoOutrosOriginal;
       _possuiTaxaAdministracaoOriginal = PossuiTaxaAdministracao;
       _possuiTaxaAdministracaoOriginalCommited = _possuiTaxaAdministracaoOriginal;
       _taxaAdministracaoOriginal = TaxaAdministracao;
       _taxaAdministracaoOriginalCommited = _taxaAdministracaoOriginal;
       _idPlanoContaTaxaAdministracaoOriginal = IdPlanoContaTaxaAdministracao;
       _idPlanoContaTaxaAdministracaoOriginalCommited = _idPlanoContaTaxaAdministracaoOriginal;
       _possuiTaxaAntecipacaoOriginal = PossuiTaxaAntecipacao;
       _possuiTaxaAntecipacaoOriginalCommited = _possuiTaxaAntecipacaoOriginal;
       _taxaAntecipacaoOriginal = TaxaAntecipacao;
       _taxaAntecipacaoOriginalCommited = _taxaAntecipacaoOriginal;
       _idPlanoContaTaxaAntecipacaoOriginal = IdPlanoContaTaxaAntecipacao;
       _idPlanoContaTaxaAntecipacaoOriginalCommited = _idPlanoContaTaxaAntecipacaoOriginal;
       _parcelasOriginal = Parcelas;
       _parcelasOriginalCommited = _parcelasOriginal;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;

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
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
       _entradaOriginalCommited = Entrada;
       _diasEntradaOriginalCommited = DiasEntrada;
       _periodicidadeOriginalCommited = Periodicidade;
       _quantidadeParcelasOriginalCommited = QuantidadeParcelas;
       _ativoAntigoOriginalCommited = AtivoAntigo;
       _versionOriginalCommited = Version;
       _observacaoOriginalCommited = Observacao;
       _contaBancariaOriginalCommited = ContaBancaria;
       _meioPagamentoOriginalCommited = MeioPagamento;
       _descricaoMeioPagtoOutrosOriginalCommited = DescricaoMeioPagtoOutros;
       _possuiTaxaAdministracaoOriginalCommited = PossuiTaxaAdministracao;
       _taxaAdministracaoOriginalCommited = TaxaAdministracao;
       _idPlanoContaTaxaAdministracaoOriginalCommited = IdPlanoContaTaxaAdministracao;
       _possuiTaxaAntecipacaoOriginalCommited = PossuiTaxaAntecipacao;
       _taxaAntecipacaoOriginalCommited = TaxaAntecipacao;
       _idPlanoContaTaxaAntecipacaoOriginalCommited = IdPlanoContaTaxaAntecipacao;
       _parcelasOriginalCommited = Parcelas;
       _ativoOriginalCommited = Ativo;

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
               if (_valueCollectionClienteClassFormaPagamentoLoaded) 
               {
                  if (_collectionClienteClassFormaPagamentoRemovidos != null) 
                  {
                     _collectionClienteClassFormaPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassFormaPagamentoRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassFormaPagamentoOriginal= (from a in _valueCollectionClienteClassFormaPagamento select a.ID).ToList();
                  _valueCollectionClienteClassFormaPagamentoChanged = false;
                  _valueCollectionClienteClassFormaPagamentoCommitedChanged = false;
               }
               if (_valueCollectionFornecedorClassFormaPagamentoLoaded) 
               {
                  if (_collectionFornecedorClassFormaPagamentoRemovidos != null) 
                  {
                     _collectionFornecedorClassFormaPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFornecedorClassFormaPagamentoRemovidos = new List<Entidades.FornecedorClass>();
                  }
                  _collectionFornecedorClassFormaPagamentoOriginal= (from a in _valueCollectionFornecedorClassFormaPagamento select a.ID).ToList();
                  _valueCollectionFornecedorClassFormaPagamentoChanged = false;
                  _valueCollectionFornecedorClassFormaPagamentoCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemClassFormaPagamentoLoaded) 
               {
                  if (_collectionOrcamentoItemClassFormaPagamentoRemovidos != null) 
                  {
                     _collectionOrcamentoItemClassFormaPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemClassFormaPagamentoRemovidos = new List<Entidades.OrcamentoItemClass>();
                  }
                  _collectionOrcamentoItemClassFormaPagamentoOriginal= (from a in _valueCollectionOrcamentoItemClassFormaPagamento select a.ID).ToList();
                  _valueCollectionOrcamentoItemClassFormaPagamentoChanged = false;
                  _valueCollectionOrcamentoItemClassFormaPagamentoCommitedChanged = false;
               }
               if (_valueCollectionOrdemCompraClassFormaPagamentoLoaded) 
               {
                  if (_collectionOrdemCompraClassFormaPagamentoRemovidos != null) 
                  {
                     _collectionOrdemCompraClassFormaPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemCompraClassFormaPagamentoRemovidos = new List<Entidades.OrdemCompraClass>();
                  }
                  _collectionOrdemCompraClassFormaPagamentoOriginal= (from a in _valueCollectionOrdemCompraClassFormaPagamento select a.ID).ToList();
                  _valueCollectionOrdemCompraClassFormaPagamentoChanged = false;
                  _valueCollectionOrdemCompraClassFormaPagamentoCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassFormaPagamentoLoaded) 
               {
                  if (_collectionPedidoItemClassFormaPagamentoRemovidos != null) 
                  {
                     _collectionPedidoItemClassFormaPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassFormaPagamentoRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassFormaPagamentoOriginal= (from a in _valueCollectionPedidoItemClassFormaPagamento select a.ID).ToList();
                  _valueCollectionPedidoItemClassFormaPagamentoChanged = false;
                  _valueCollectionPedidoItemClassFormaPagamentoCommitedChanged = false;
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
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Entrada=_entradaOriginal;
               _entradaOriginalCommited=_entradaOriginal;
               DiasEntrada=_diasEntradaOriginal;
               _diasEntradaOriginalCommited=_diasEntradaOriginal;
               Periodicidade=_periodicidadeOriginal;
               _periodicidadeOriginalCommited=_periodicidadeOriginal;
               QuantidadeParcelas=_quantidadeParcelasOriginal;
               _quantidadeParcelasOriginalCommited=_quantidadeParcelasOriginal;
               AtivoAntigo=_ativoAntigoOriginal;
               _ativoAntigoOriginalCommited=_ativoAntigoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Observacao=_observacaoOriginal;
               _observacaoOriginalCommited=_observacaoOriginal;
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               MeioPagamento=_meioPagamentoOriginal;
               _meioPagamentoOriginalCommited=_meioPagamentoOriginal;
               DescricaoMeioPagtoOutros=_descricaoMeioPagtoOutrosOriginal;
               _descricaoMeioPagtoOutrosOriginalCommited=_descricaoMeioPagtoOutrosOriginal;
               PossuiTaxaAdministracao=_possuiTaxaAdministracaoOriginal;
               _possuiTaxaAdministracaoOriginalCommited=_possuiTaxaAdministracaoOriginal;
               TaxaAdministracao=_taxaAdministracaoOriginal;
               _taxaAdministracaoOriginalCommited=_taxaAdministracaoOriginal;
               IdPlanoContaTaxaAdministracao=_idPlanoContaTaxaAdministracaoOriginal;
               _idPlanoContaTaxaAdministracaoOriginalCommited=_idPlanoContaTaxaAdministracaoOriginal;
               PossuiTaxaAntecipacao=_possuiTaxaAntecipacaoOriginal;
               _possuiTaxaAntecipacaoOriginalCommited=_possuiTaxaAntecipacaoOriginal;
               TaxaAntecipacao=_taxaAntecipacaoOriginal;
               _taxaAntecipacaoOriginalCommited=_taxaAntecipacaoOriginal;
               IdPlanoContaTaxaAntecipacao=_idPlanoContaTaxaAntecipacaoOriginal;
               _idPlanoContaTaxaAntecipacaoOriginalCommited=_idPlanoContaTaxaAntecipacaoOriginal;
               Parcelas=_parcelasOriginal;
               _parcelasOriginalCommited=_parcelasOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               if (_valueCollectionClienteClassFormaPagamentoLoaded) 
               {
                  CollectionClienteClassFormaPagamento.Clear();
                  foreach(int item in _collectionClienteClassFormaPagamentoOriginal)
                  {
                    CollectionClienteClassFormaPagamento.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassFormaPagamentoRemovidos.Clear();
               }
               if (_valueCollectionFornecedorClassFormaPagamentoLoaded) 
               {
                  CollectionFornecedorClassFormaPagamento.Clear();
                  foreach(int item in _collectionFornecedorClassFormaPagamentoOriginal)
                  {
                    CollectionFornecedorClassFormaPagamento.Add(Entidades.FornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFornecedorClassFormaPagamentoRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemClassFormaPagamentoLoaded) 
               {
                  CollectionOrcamentoItemClassFormaPagamento.Clear();
                  foreach(int item in _collectionOrcamentoItemClassFormaPagamentoOriginal)
                  {
                    CollectionOrcamentoItemClassFormaPagamento.Add(Entidades.OrcamentoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemClassFormaPagamentoRemovidos.Clear();
               }
               if (_valueCollectionOrdemCompraClassFormaPagamentoLoaded) 
               {
                  CollectionOrdemCompraClassFormaPagamento.Clear();
                  foreach(int item in _collectionOrdemCompraClassFormaPagamentoOriginal)
                  {
                    CollectionOrdemCompraClassFormaPagamento.Add(Entidades.OrdemCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemCompraClassFormaPagamentoRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassFormaPagamentoLoaded) 
               {
                  CollectionPedidoItemClassFormaPagamento.Clear();
                  foreach(int item in _collectionPedidoItemClassFormaPagamentoOriginal)
                  {
                    CollectionPedidoItemClassFormaPagamento.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassFormaPagamentoRemovidos.Clear();
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
               if (_valueCollectionClienteClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionClienteClassFormaPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionFornecedorClassFormaPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassFormaPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionOrdemCompraClassFormaPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassFormaPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionClienteClassFormaPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionFornecedorClassFormaPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassFormaPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionOrdemCompraClassFormaPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassFormaPagamento.Any(item => item.IsDirty());
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
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _entradaOriginal != Entrada;
      if (dirty) return true;
       dirty = _diasEntradaOriginal != DiasEntrada;
      if (dirty) return true;
       dirty = _periodicidadeOriginal != Periodicidade;
      if (dirty) return true;
       dirty = _quantidadeParcelasOriginal != QuantidadeParcelas;
      if (dirty) return true;
       dirty = _ativoAntigoOriginal != AtivoAntigo;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _observacaoOriginal != Observacao;
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
       if (_meioPagamentoOriginal!=null)
       {
          dirty = !_meioPagamentoOriginal.Equals(MeioPagamento);
       }
       else
       {
            dirty = MeioPagamento != null;
       }
      if (dirty) return true;
       dirty = _descricaoMeioPagtoOutrosOriginal != DescricaoMeioPagtoOutros;
      if (dirty) return true;
       dirty = _possuiTaxaAdministracaoOriginal != PossuiTaxaAdministracao;
      if (dirty) return true;
       dirty = _taxaAdministracaoOriginal != TaxaAdministracao;
      if (dirty) return true;
       dirty = _idPlanoContaTaxaAdministracaoOriginal != IdPlanoContaTaxaAdministracao;
      if (dirty) return true;
       dirty = _possuiTaxaAntecipacaoOriginal != PossuiTaxaAntecipacao;
      if (dirty) return true;
       dirty = _taxaAntecipacaoOriginal != TaxaAntecipacao;
      if (dirty) return true;
       dirty = _idPlanoContaTaxaAntecipacaoOriginal != IdPlanoContaTaxaAntecipacao;
      if (dirty) return true;
       dirty = _parcelasOriginal != Parcelas;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;

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
               if (_valueCollectionClienteClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionClienteClassFormaPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionFornecedorClassFormaPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassFormaPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionOrdemCompraClassFormaPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassFormaPagamentoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassFormaPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionClienteClassFormaPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionFornecedorClassFormaPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassFormaPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionOrdemCompraClassFormaPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassFormaPagamentoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassFormaPagamento.Any(item => item.IsDirtyCommited());
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
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _entradaOriginalCommited != Entrada;
      if (dirty) return true;
       dirty = _diasEntradaOriginalCommited != DiasEntrada;
      if (dirty) return true;
       dirty = _periodicidadeOriginalCommited != Periodicidade;
      if (dirty) return true;
       dirty = _quantidadeParcelasOriginalCommited != QuantidadeParcelas;
      if (dirty) return true;
       dirty = _ativoAntigoOriginalCommited != AtivoAntigo;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _observacaoOriginalCommited != Observacao;
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
       if (_meioPagamentoOriginalCommited!=null)
       {
          dirty = !_meioPagamentoOriginalCommited.Equals(MeioPagamento);
       }
       else
       {
            dirty = MeioPagamento != null;
       }
      if (dirty) return true;
       dirty = _descricaoMeioPagtoOutrosOriginalCommited != DescricaoMeioPagtoOutros;
      if (dirty) return true;
       dirty = _possuiTaxaAdministracaoOriginalCommited != PossuiTaxaAdministracao;
      if (dirty) return true;
       dirty = _taxaAdministracaoOriginalCommited != TaxaAdministracao;
      if (dirty) return true;
       dirty = _idPlanoContaTaxaAdministracaoOriginalCommited != IdPlanoContaTaxaAdministracao;
      if (dirty) return true;
       dirty = _possuiTaxaAntecipacaoOriginalCommited != PossuiTaxaAntecipacao;
      if (dirty) return true;
       dirty = _taxaAntecipacaoOriginalCommited != TaxaAntecipacao;
      if (dirty) return true;
       dirty = _idPlanoContaTaxaAntecipacaoOriginalCommited != IdPlanoContaTaxaAntecipacao;
      if (dirty) return true;
       dirty = _parcelasOriginalCommited != Parcelas;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;

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
               if (_valueCollectionClienteClassFormaPagamentoLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassFormaPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFornecedorClassFormaPagamentoLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassFormaPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemClassFormaPagamentoLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassFormaPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemCompraClassFormaPagamentoLoaded) 
               {
                  foreach(OrdemCompraClass item in CollectionOrdemCompraClassFormaPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassFormaPagamentoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassFormaPagamento)
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
             case "Identificacao":
                return this.Identificacao;
             case "Descricao":
                return this.Descricao;
             case "Entrada":
                return this.Entrada;
             case "DiasEntrada":
                return this.DiasEntrada;
             case "Periodicidade":
                return this.Periodicidade;
             case "QuantidadeParcelas":
                return this.QuantidadeParcelas;
             case "AtivoAntigo":
                return this.AtivoAntigo;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Observacao":
                return this.Observacao;
             case "ContaBancaria":
                return this.ContaBancaria;
             case "MeioPagamento":
                return this.MeioPagamento;
             case "DescricaoMeioPagtoOutros":
                return this.DescricaoMeioPagtoOutros;
             case "PossuiTaxaAdministracao":
                return this.PossuiTaxaAdministracao;
             case "TaxaAdministracao":
                return this.TaxaAdministracao;
             case "IdPlanoContaTaxaAdministracao":
                return this.IdPlanoContaTaxaAdministracao;
             case "PossuiTaxaAntecipacao":
                return this.PossuiTaxaAntecipacao;
             case "TaxaAntecipacao":
                return this.TaxaAntecipacao;
             case "IdPlanoContaTaxaAntecipacao":
                return this.IdPlanoContaTaxaAntecipacao;
             case "Parcelas":
                return this.Parcelas;
             case "Ativo":
                return this.Ativo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (MeioPagamento!=null)
                MeioPagamento.ChangeSingleConnection(newConnection);
               if (_valueCollectionClienteClassFormaPagamentoLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassFormaPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFornecedorClassFormaPagamentoLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassFormaPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemClassFormaPagamentoLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassFormaPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemCompraClassFormaPagamentoLoaded) 
               {
                  foreach(OrdemCompraClass item in CollectionOrdemCompraClassFormaPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassFormaPagamentoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassFormaPagamento)
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
                  command.CommandText += " COUNT(forma_pagamento.id_forma_pagamento) " ;
               }
               else
               {
               command.CommandText += "forma_pagamento.id_forma_pagamento, " ;
               command.CommandText += "forma_pagamento.fop_identificacao, " ;
               command.CommandText += "forma_pagamento.fop_descricao, " ;
               command.CommandText += "forma_pagamento.fop_entrada, " ;
               command.CommandText += "forma_pagamento.fop_dias_entrada, " ;
               command.CommandText += "forma_pagamento.fop_periodicidade, " ;
               command.CommandText += "forma_pagamento.fop_quantidade_parcelas, " ;
               command.CommandText += "forma_pagamento.fop_ativo_antigo, " ;
               command.CommandText += "forma_pagamento.entity_uid, " ;
               command.CommandText += "forma_pagamento.version, " ;
               command.CommandText += "forma_pagamento.fop_observacao, " ;
               command.CommandText += "forma_pagamento.id_conta_bancaria, " ;
               command.CommandText += "forma_pagamento.id_meio_pagamento, " ;
               command.CommandText += "forma_pagamento.fop_descricao_meio_pagto_outros, " ;
               command.CommandText += "forma_pagamento.fop_possui_taxa_administracao, " ;
               command.CommandText += "forma_pagamento.fop_taxa_administracao, " ;
               command.CommandText += "forma_pagamento.id_plano_conta_taxa_administracao, " ;
               command.CommandText += "forma_pagamento.fop_possui_taxa_antecipacao, " ;
               command.CommandText += "forma_pagamento.fop_taxa_antecipacao, " ;
               command.CommandText += "forma_pagamento.id_plano_conta_taxa_antecipacao, " ;
               command.CommandText += "forma_pagamento.fop_parcelas, " ;
               command.CommandText += "forma_pagamento.fop_ativo " ;
               }
               command.CommandText += " FROM  forma_pagamento ";
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
                        orderByClause += " , fop_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(fop_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = forma_pagamento.id_acs_usuario_ultima_revisao ";
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
                     case "id_forma_pagamento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.id_forma_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.id_forma_pagamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , forma_pagamento.fop_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(forma_pagamento.fop_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , forma_pagamento.fop_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(forma_pagamento.fop_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_entrada":
                     case "Entrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_dias_entrada":
                     case "DiasEntrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_dias_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_dias_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_periodicidade":
                     case "Periodicidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_periodicidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_periodicidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_quantidade_parcelas":
                     case "QuantidadeParcelas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_quantidade_parcelas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_quantidade_parcelas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_ativo_antigo":
                     case "AtivoAntigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_ativo_antigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_ativo_antigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , forma_pagamento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(forma_pagamento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , forma_pagamento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_observacao":
                     case "Observacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , forma_pagamento.fop_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(forma_pagamento.fop_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = forma_pagamento.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_meio_pagamento":
                     case "MeioPagamento":
                     orderByClause += " , forma_pagamento.id_meio_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "fop_descricao_meio_pagto_outros":
                     case "DescricaoMeioPagtoOutros":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , forma_pagamento.fop_descricao_meio_pagto_outros " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(forma_pagamento.fop_descricao_meio_pagto_outros) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_possui_taxa_administracao":
                     case "PossuiTaxaAdministracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_possui_taxa_administracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_possui_taxa_administracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_taxa_administracao":
                     case "TaxaAdministracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_taxa_administracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_taxa_administracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_plano_conta_taxa_administracao":
                     case "IdPlanoContaTaxaAdministracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.id_plano_conta_taxa_administracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.id_plano_conta_taxa_administracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_possui_taxa_antecipacao":
                     case "PossuiTaxaAntecipacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_possui_taxa_antecipacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_possui_taxa_antecipacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_taxa_antecipacao":
                     case "TaxaAntecipacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_taxa_antecipacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_taxa_antecipacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_plano_conta_taxa_antecipacao":
                     case "IdPlanoContaTaxaAntecipacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.id_plano_conta_taxa_antecipacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.id_plano_conta_taxa_antecipacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_parcelas":
                     case "Parcelas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , forma_pagamento.fop_parcelas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(forma_pagamento.fop_parcelas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fop_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , forma_pagamento.fop_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(forma_pagamento.fop_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fop_identificacao")) 
                        {
                           whereClause += " OR UPPER(forma_pagamento.fop_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(forma_pagamento.fop_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fop_descricao")) 
                        {
                           whereClause += " OR UPPER(forma_pagamento.fop_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(forma_pagamento.fop_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(forma_pagamento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(forma_pagamento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fop_observacao")) 
                        {
                           whereClause += " OR UPPER(forma_pagamento.fop_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(forma_pagamento.fop_observacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fop_descricao_meio_pagto_outros")) 
                        {
                           whereClause += " OR UPPER(forma_pagamento.fop_descricao_meio_pagto_outros) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(forma_pagamento.fop_descricao_meio_pagto_outros) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fop_parcelas")) 
                        {
                           whereClause += " OR UPPER(forma_pagamento.fop_parcelas) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(forma_pagamento.fop_parcelas) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_forma_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.id_forma_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.id_forma_pagamento = :forma_pagamento_ID_9234 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_ID_9234", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "fop_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_identificacao LIKE :forma_pagamento_Identificacao_4199 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Identificacao_4199", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "fop_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_descricao LIKE :forma_pagamento_Descricao_2872 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Descricao_2872", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Entrada" || parametro.FieldName == "fop_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_entrada = :forma_pagamento_Entrada_3683 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Entrada_3683", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DiasEntrada" || parametro.FieldName == "fop_dias_entrada")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_dias_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_dias_entrada = :forma_pagamento_DiasEntrada_1320 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_DiasEntrada_1320", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Periodicidade" || parametro.FieldName == "fop_periodicidade")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_periodicidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_periodicidade = :forma_pagamento_Periodicidade_5314 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Periodicidade_5314", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeParcelas" || parametro.FieldName == "fop_quantidade_parcelas")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_quantidade_parcelas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_quantidade_parcelas = :forma_pagamento_QuantidadeParcelas_1136 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_QuantidadeParcelas_1136", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AtivoAntigo" || parametro.FieldName == "fop_ativo_antigo")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_ativo_antigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_ativo_antigo = :forma_pagamento_AtivoAntigo_9702 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_AtivoAntigo_9702", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  forma_pagamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.entity_uid LIKE :forma_pagamento_EntityUid_1551 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_EntityUid_1551", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  forma_pagamento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.version = :forma_pagamento_Version_3574 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Version_3574", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacao" || parametro.FieldName == "fop_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_observacao LIKE :forma_pagamento_Observacao_7709 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Observacao_7709", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  forma_pagamento.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.id_conta_bancaria = :forma_pagamento_ContaBancaria_1582 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_ContaBancaria_1582", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  forma_pagamento.id_meio_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.id_meio_pagamento = :forma_pagamento_MeioPagamento_4948 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_MeioPagamento_4948", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoMeioPagtoOutros" || parametro.FieldName == "fop_descricao_meio_pagto_outros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_descricao_meio_pagto_outros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_descricao_meio_pagto_outros LIKE :forma_pagamento_DescricaoMeioPagtoOutros_9749 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_DescricaoMeioPagtoOutros_9749", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PossuiTaxaAdministracao" || parametro.FieldName == "fop_possui_taxa_administracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_possui_taxa_administracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_possui_taxa_administracao = :forma_pagamento_PossuiTaxaAdministracao_2641 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_PossuiTaxaAdministracao_2641", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TaxaAdministracao" || parametro.FieldName == "fop_taxa_administracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_taxa_administracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_taxa_administracao = :forma_pagamento_TaxaAdministracao_3131 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_TaxaAdministracao_3131", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdPlanoContaTaxaAdministracao" || parametro.FieldName == "id_plano_conta_taxa_administracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.id_plano_conta_taxa_administracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.id_plano_conta_taxa_administracao = :forma_pagamento_IdPlanoContaTaxaAdministracao_27 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_IdPlanoContaTaxaAdministracao_27", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PossuiTaxaAntecipacao" || parametro.FieldName == "fop_possui_taxa_antecipacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_possui_taxa_antecipacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_possui_taxa_antecipacao = :forma_pagamento_PossuiTaxaAntecipacao_3578 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_PossuiTaxaAntecipacao_3578", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TaxaAntecipacao" || parametro.FieldName == "fop_taxa_antecipacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_taxa_antecipacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_taxa_antecipacao = :forma_pagamento_TaxaAntecipacao_6360 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_TaxaAntecipacao_6360", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdPlanoContaTaxaAntecipacao" || parametro.FieldName == "id_plano_conta_taxa_antecipacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.id_plano_conta_taxa_antecipacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.id_plano_conta_taxa_antecipacao = :forma_pagamento_IdPlanoContaTaxaAntecipacao_7821 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_IdPlanoContaTaxaAntecipacao_7821", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Parcelas" || parametro.FieldName == "fop_parcelas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_parcelas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_parcelas LIKE :forma_pagamento_Parcelas_6180 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Parcelas_6180", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "fop_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_ativo = :forma_pagamento_Ativo_9981 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Ativo_9981", NpgsqlDbType.Boolean, parametro.Fieldvalue));
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
                         whereClause += "  forma_pagamento.fop_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_identificacao LIKE :forma_pagamento_Identificacao_4092 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Identificacao_4092", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoExato" || parametro.FieldName == "DescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_descricao LIKE :forma_pagamento_Descricao_7936 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Descricao_7936", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  forma_pagamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.entity_uid LIKE :forma_pagamento_EntityUid_5730 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_EntityUid_5730", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoExato" || parametro.FieldName == "ObservacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_observacao LIKE :forma_pagamento_Observacao_7981 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Observacao_7981", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  forma_pagamento.fop_descricao_meio_pagto_outros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_descricao_meio_pagto_outros LIKE :forma_pagamento_DescricaoMeioPagtoOutros_4519 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_DescricaoMeioPagtoOutros_4519", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ParcelasExato" || parametro.FieldName == "ParcelasExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  forma_pagamento.fop_parcelas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  forma_pagamento.fop_parcelas LIKE :forma_pagamento_Parcelas_3476 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("forma_pagamento_Parcelas_3476", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  FormaPagamentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (FormaPagamentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(FormaPagamentoClass), Convert.ToInt32(read["id_forma_pagamento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new FormaPagamentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_forma_pagamento"]);
                     entidade.Identificacao = (read["fop_identificacao"] != DBNull.Value ? read["fop_identificacao"].ToString() : null);
                     entidade.Descricao = (read["fop_descricao"] != DBNull.Value ? read["fop_descricao"].ToString() : null);
                     entidade.Entrada = Convert.ToBoolean(Convert.ToInt16(read["fop_entrada"]));
                     entidade.DiasEntrada = (int)read["fop_dias_entrada"];
                     entidade.Periodicidade = (int)read["fop_periodicidade"];
                     entidade.QuantidadeParcelas = (int)read["fop_quantidade_parcelas"];
                     entidade.AtivoAntigo = (int)read["fop_ativo_antigo"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Observacao = (read["fop_observacao"] != DBNull.Value ? read["fop_observacao"].ToString() : null);
                     if (read["id_conta_bancaria"] != DBNull.Value)
                     {
                        entidade.ContaBancaria = (BibliotecaEntidades.Entidades.ContaBancariaClass)BibliotecaEntidades.Entidades.ContaBancariaClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaBancaria = null ;
                     }
                     if (read["id_meio_pagamento"] != DBNull.Value)
                     {
                        entidade.MeioPagamento = (BibliotecaEntidades.Entidades.MeioPagamentoClass)BibliotecaEntidades.Entidades.MeioPagamentoClass.GetEntidade(Convert.ToInt32(read["id_meio_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.MeioPagamento = null ;
                     }
                     entidade.DescricaoMeioPagtoOutros = (read["fop_descricao_meio_pagto_outros"] != DBNull.Value ? read["fop_descricao_meio_pagto_outros"].ToString() : null);
                     entidade.PossuiTaxaAdministracao = Convert.ToBoolean(read["fop_possui_taxa_administracao"]);
                     entidade.TaxaAdministracao = (double)read["fop_taxa_administracao"];
                     entidade.IdPlanoContaTaxaAdministracao = (read["id_plano_conta_taxa_administracao"] != DBNull.Value ? (long?)Convert.ToInt64(read["id_plano_conta_taxa_administracao"]) : null);
                     entidade.PossuiTaxaAntecipacao = Convert.ToBoolean(read["fop_possui_taxa_antecipacao"]);
                     entidade.TaxaAntecipacao = (double)read["fop_taxa_antecipacao"];
                     entidade.IdPlanoContaTaxaAntecipacao = (read["id_plano_conta_taxa_antecipacao"] != DBNull.Value ? (long?)Convert.ToInt64(read["id_plano_conta_taxa_antecipacao"]) : null);
                     entidade.Parcelas = (read["fop_parcelas"] != DBNull.Value ? read["fop_parcelas"].ToString() : null);
                     entidade.Ativo = Convert.ToBoolean(read["fop_ativo"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (FormaPagamentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
